using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

/*
SPEC:

Type inference occurs as part of the compile-time processing of a method invocation
and takes place before the overload resolution step of the invocation. When a
particular method group is specified in a method invocation, and no type arguments
are specified as part of the method invocation, type inference is applied to each
generic method in the method group. If type inference succeeds, then the inferred
type arguments are used to determine the types of formal parameters for subsequent 
overload resolution. If overload resolution chooses a generic method as the one to
invoke then the inferred type arguments are used as the actual type arguments for the
invocation. If type inference for a particular method fails, that method does not
participate in overload resolution. The failure of type inference, in and of itself,
does not cause a compile-time error. However, it often leads to a compile-time error
when overload resolution then fails to find any applicable methods.

If the supplied number of arguments is different than the number of parameters in
the method, then inference immediately fails. Otherwise, assume that the generic
method has the following signature:

Tr M<X1...Xn>(T1 x1 ... Tm xm)

With a method call of the form M(E1...Em) the task of type inference is to find
unique type arguments S1...Sn for each of the type parameters X1...Xn so that the
call M<S1...Sn>(E1...Em)becomes valid.

During the process of inference each type parameter Xi is either fixed to a particular
type Si or unfixed with an associated set of bounds. Each of the bounds is some type T.
Each bound is classified as an upper bound, lower bound or exact bound.
Initially each type variable Xi is unfixed with an empty set of bounds.

*/

// This file contains the implementation for method type inference on calls (with
// arguments, and method type inference on conversion of method groups to delegate
// types (which will not have arguments.)

namespace MetaDslx.CodeAnalysis.Binding
{
    // Method type inference can fail, but we still might have some best guesses. 
    internal struct MethodTypeInferenceResult
    {
        public readonly ImmutableArray<TypeWithAnnotations> InferredTypeArguments;
        public readonly bool Success;

        public MethodTypeInferenceResult(
            bool success,
            ImmutableArray<TypeWithAnnotations> inferredTypeArguments)
        {
            this.Success = success;
            this.InferredTypeArguments = inferredTypeArguments;
        }
    }

    internal sealed class MethodTypeInferrer
    {
        internal abstract class Extensions
        {
            internal static readonly Extensions Default = new DefaultExtensions();

            internal abstract TypeWithAnnotations GetTypeWithAnnotations(ExpressionSymbol expr);

            internal abstract TypeWithAnnotations GetMethodGroupResultType(ReferenceExpressionSymbol group, MethodSymbol method);

            private sealed class DefaultExtensions : Extensions
            {
                internal override TypeWithAnnotations GetTypeWithAnnotations(ExpressionSymbol expr)
                {
                    return TypeWithAnnotations.Create(expr.Type);
                }

                internal override TypeWithAnnotations GetMethodGroupResultType(ReferenceExpressionSymbol group, MethodSymbol method)
                {
                    return method.Result?.TypeWithAnnotations;
                }
            }
        }

        private enum InferenceResult
        {
            InferenceFailed,
            MadeProgress,
            NoProgress,
            Success
        }

        private enum Dependency
        {
            Unknown = 0x00,
            NotDependent = 0x01,
            DependsMask = 0x10,
            Direct = 0x11,
            Indirect = 0x12
        }

        private readonly LanguageCompilation _compilation;
        private readonly ImmutableArray<TypeParameterSymbol> _methodTypeParameters;
        private readonly NamedTypeSymbol _constructedContainingTypeOfMethod;
        private readonly ImmutableArray<TypeWithAnnotations> _formalParameterTypes;
        private readonly ImmutableArray<RefKind> _formalParameterRefKinds;
        private readonly ImmutableArray<ExpressionSymbol> _arguments;
        private readonly Extensions _extensions;

        private readonly TypeWithAnnotations[] _fixedResults;
        private readonly HashSet<TypeWithAnnotations>[] _exactBounds;
        private readonly HashSet<TypeWithAnnotations>[] _upperBounds;
        private readonly HashSet<TypeWithAnnotations>[] _lowerBounds;
        private Dependency[,] _dependencies; // Initialized lazily
        private bool _dependenciesDirty;

        /// <summary>
        /// For error recovery, we allow a mismatch between the number of arguments and parameters
        /// during type inference. This sometimes enables inferring the type for a lambda parameter.
        /// </summary>
        private int NumberArgumentsToProcess => System.Math.Min(_arguments.Length, _formalParameterTypes.Length);

        public static MethodTypeInferenceResult Infer(
            LanguageCompilation compilation,
            ImmutableArray<TypeParameterSymbol> methodTypeParameters,
            // We are attempting to build a map from method type parameters 
            // to inferred type arguments.

            NamedTypeSymbol constructedContainingTypeOfMethod,
            ImmutableArray<TypeWithAnnotations> formalParameterTypes,

            // We have some unusual requirements for the types that flow into the inference engine.
            // Consider the following inference problems:
            // 
            // Scenario one: 
            //
            // class C<T> 
            // {
            //   delegate Y FT<X, Y>(T t, X x);
            //   static void M<U, V>(U u, FT<U, V> f);
            //   ...
            //   C<double>.M(123, (t,x)=>t+x);
            //
            // From the first argument we infer that U is int. How now must we make an inference on
            // the second argument? The *declared* type of the formal is C<T>.FT<U,V>. The
            // actual type at the time of inference is known to be C<double>.FT<int, something>
            // where "something" is to be determined by inferring the return type of the 
            // lambda by determine the type of "double + int". 
            // 
            // Therefore when we do type inference, if a formal parameter type is a generic delegate
            // then *its* formal parameter types must be the formal parameter types of the 
            // *constructed* generic delegate C<double>.FT<...>, not C<T>.FT<...>. 
            //
            // One would therefore suppose that we'd expect the formal parameter types to here
            // be passed in with the types constructed with the information known from the
            // call site, not the declared types.
            //
            // Contrast that with this scenario:
            //
            // Scenario Two:
            //
            // interface I<T> 
            // { 
            //    void M<U>(T t, U u); 
            // }
            // ...
            // static void Goo<V>(V v, I<V> iv) 
            // {
            //   iv.M(v, "");
            // }
            //
            // Obviously inference should succeed here; it should infer that U is string. 
            //
            // But consider what happens during the inference process on the first argument.
            // The first thing we will do is say "what's the type of the argument? V. What's
            // the type of the corresponding formal parameter? The first formal parameter of
            // I<V>.M<whatever> is of type V. The inference engine will then say "V is a 
            // method type parameter, and therefore we have an inference from V to V". 
            // But *V* is not one of the method type parameters being inferred; the only 
            // method type parameter being inferred here is *U*.
            //
            // This is perhaps some evidence that the formal parameters passed in should be
            // the formal parameters of the *declared* method; in this case, (T, U), not
            // the formal parameters of the *constructed* method, (V, U). 
            //
            // However, one might make the argument that no, we could just add a check
            // to ensure that if we see a method type parameter as a formal parameter type,
            // then we only perform the inference if the method type parameter is a type 
            // parameter of the method for which inference is being performed.
            //
            // Unfortunately, that does not work either:
            //
            // Scenario three:
            //
            // class C<T>
            // {
            //   static void M<U>(T t, U u)
            //   {
            //     ...
            //     C<U>.M(u, 123);
            //     ...
            //   }
            // }
            //
            // The *original* formal parameter types are (T, U); the *constructed* formal parameter types
            // are (U, U), but *those are logically two different U's*. The first U is from the outer caller;
            // the second U is the U of the recursive call.
            //
            // That is, suppose someone called C<string>.M<double>(string, double).  The recursive call should be to
            // C<double>.M<int>(double, int). We should absolutely not make an inference on the first argument
            // from U to U just because C<U>.M<something>'s first formal parameter is of type U.  If we did then
            // inference would fail, because we'd end up with two bounds on 'U' -- 'U' and 'int'. We only want
            // the latter bound.
            //
            // What these three scenarios show is that for a "normal" inference we need to have the
            // formal parameters of the *original* method definition, but when making an inference from a lambda
            // to a delegate, we need to have the *constructed* method signature in order that the formal
            // parameters *of the delegate* be correct.
            //
            // How to solve this problem?
            //
            // We solve it by passing in the formal parameters in their *original* form, but also getting
            // the *fully constructed* type that the method call is on. When constructing the fixed
            // delegate type for inference from a lambda, we do the appropriate type substitution on
            // the delegate.

            ImmutableArray<RefKind> formalParameterRefKinds, // Optional; assume all value if missing.
            ImmutableArray<ExpressionSymbol> arguments,// Required; in scenarios like method group conversions where there are
                                                      // no arguments per se we cons up some fake arguments.
            ref HashSet<DiagnosticInfo> useSiteDiagnostics,
            Extensions extensions = null)
        {
            Debug.Assert(!methodTypeParameters.IsDefault);
            Debug.Assert(methodTypeParameters.Length > 0);
            Debug.Assert(!formalParameterTypes.IsDefault);
            Debug.Assert(formalParameterRefKinds.IsDefault || formalParameterRefKinds.Length == formalParameterTypes.Length);
            Debug.Assert(!arguments.IsDefault);

            // Early out: if the method has no formal parameters then we know that inference will fail.
            if (formalParameterTypes.Length == 0)
            {
                return new MethodTypeInferenceResult(false, default(ImmutableArray<TypeWithAnnotations>));

                // UNDONE: OPTIMIZATION: We could check to see whether there is a type
                // UNDONE: parameter which is never used in any formal parameter; if
                // UNDONE: so then we know ahead of time that inference will fail.
            }

            var inferrer = new MethodTypeInferrer(
                compilation,
                methodTypeParameters,
                constructedContainingTypeOfMethod,
                formalParameterTypes,
                formalParameterRefKinds,
                arguments,
                extensions);
            return inferrer.InferTypeArgs(ref useSiteDiagnostics);
        }

        ////////////////////////////////////////////////////////////////////////////////
        //
        // Fixed, unfixed and bounded type parameters
        //
        // SPEC: During the process of inference each type parameter is either fixed to
        // SPEC: a particular type or unfixed with an associated set of bounds. Each of
        // SPEC: the bounds is of some type T. Initially each type parameter is unfixed
        // SPEC: with an empty set of bounds.

        private MethodTypeInferrer(
            LanguageCompilation compilation,
            ImmutableArray<TypeParameterSymbol> methodTypeParameters,
            NamedTypeSymbol constructedContainingTypeOfMethod,
            ImmutableArray<TypeWithAnnotations> formalParameterTypes,
            ImmutableArray<RefKind> formalParameterRefKinds,
            ImmutableArray<ExpressionSymbol> arguments,
            Extensions extensions)
        {
            _compilation = compilation;
            _methodTypeParameters = methodTypeParameters;
            _constructedContainingTypeOfMethod = constructedContainingTypeOfMethod;
            _formalParameterTypes = formalParameterTypes;
            _formalParameterRefKinds = formalParameterRefKinds;
            _arguments = arguments;
            _extensions = extensions ?? Extensions.Default;
            _fixedResults = new TypeWithAnnotations[methodTypeParameters.Length];
            _exactBounds = new HashSet<TypeWithAnnotations>[methodTypeParameters.Length];
            _upperBounds = new HashSet<TypeWithAnnotations>[methodTypeParameters.Length];
            _lowerBounds = new HashSet<TypeWithAnnotations>[methodTypeParameters.Length];
            _dependencies = null;
            _dependenciesDirty = false;
        }

#if DEBUG

        internal string Dump()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Method type inference internal state");
            sb.AppendFormat("Inferring method type parameters <{0}>\n", string.Join(", ", _methodTypeParameters));
            sb.Append("Formal parameter types (");
            for (int i = 0; i < _formalParameterTypes.Length; ++i)
            {
                if (i != 0)
                {
                    sb.Append(", ");
                }

                sb.Append(GetRefKind(i).ToParameterPrefix());
                sb.Append(_formalParameterTypes[i]);
            }

            sb.Append("\n");

            sb.AppendFormat("Argument types ({0})\n", string.Join(", ", from a in _arguments select a.Type));

            if (_dependencies == null)
            {
                sb.AppendLine("Dependencies are not yet calculated");
            }
            else
            {
                sb.AppendFormat("Dependencies are {0}\n", _dependenciesDirty ? "out of date" : "up to date");
                sb.AppendLine("dependency matrix (Not dependent / Direct / Indirect / Unknown):");
                for (int i = 0; i < _methodTypeParameters.Length; ++i)
                {
                    for (int j = 0; j < _methodTypeParameters.Length; ++j)
                    {
                        switch (_dependencies[i, j])
                        {
                            case Dependency.NotDependent:
                                sb.Append("N");
                                break;
                            case Dependency.Direct:
                                sb.Append("D");
                                break;
                            case Dependency.Indirect:
                                sb.Append("I");
                                break;
                            case Dependency.Unknown:
                                sb.Append("U");
                                break;
                        }
                    }
                    sb.AppendLine();
                }
            }

            for (int i = 0; i < _methodTypeParameters.Length; ++i)
            {
                sb.AppendFormat("Method type parameter {0}: ", _methodTypeParameters[i].Name);

                var fixedType = _fixedResults[i];

                if (!fixedType.HasType)
                {
                    sb.Append("UNFIXED ");
                }
                else
                {
                    sb.AppendFormat("FIXED to {0} ", fixedType);
                }

                sb.AppendFormat("upper bounds: ({0}) ", (_upperBounds[i] == null) ? "" : string.Join(", ", _upperBounds[i]));
                sb.AppendFormat("lower bounds: ({0}) ", (_lowerBounds[i] == null) ? "" : string.Join(", ", _lowerBounds[i]));
                sb.AppendFormat("exact bounds: ({0}) ", (_exactBounds[i] == null) ? "" : string.Join(", ", _exactBounds[i]));
                sb.AppendLine();
            }

            return sb.ToString();
        }

#endif

        private RefKind GetRefKind(int index)
        {
            Debug.Assert(0 <= index && index < _formalParameterTypes.Length);
            return _formalParameterRefKinds.IsDefault ? RefKind.None : _formalParameterRefKinds[index];
        }

        private ImmutableArray<TypeWithAnnotations> GetResults()
        {
            // Anything we didn't infer a type for, give the error type.
            // Note: the error type will have the same name as the name
            // of the type parameter we were trying to infer.  This will give a
            // nice user experience where by we will show something like
            // the following:
            //
            // user types: customers.Select(
            // we show   : IE<TResult> IE<Customer>.Select<Customer,TResult>(Func<Customer,TResult> selector)
            //
            // Initially we thought we'd just show ?.  i.e.:
            //
            //  IE<?> IE<Customer>.Select<Customer,?>(Func<Customer,?> selector)
            //
            // This is nice and concise.  However, it falls down if there are multiple
            // type params that we have left.

            for (int i = 0; i < _methodTypeParameters.Length; i++)
            {
                if (_fixedResults[i].HasType)
                {
                    if (!_fixedResults[i].Type.IsError)
                    {
                        continue;
                    }

                    var errorTypeName = _fixedResults[i].Type.Name;
                    if (errorTypeName != null)
                    {
                        continue;
                    }
                }
                _fixedResults[i] = TypeWithAnnotations.Create(_compilation.SourceModule.SymbolFactory.MakeMetadataErrorSymbol<NamedTypeSymbol>(_constructedContainingTypeOfMethod, _methodTypeParameters[i].Name, _methodTypeParameters[i].Name, ErrorKind.Invalid));
            }

            return _fixedResults.AsImmutable();
        }

        ////////////////////////////////////////////////////////////////////////////////
        //
        // Phases
        //

        private MethodTypeInferenceResult InferTypeArgs(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // SPEC: Type inference takes place in phases. Each phase will try to infer type 
            // SPEC: arguments for more type parameters based on the findings of the previous
            // SPEC: phase. The first phase makes some initial inferences of bounds, whereas
            // SPEC: the second phase fixes type parameters to specific types and infers further
            // SPEC: bounds. The second phase may have to be repeated a number of times.
            InferTypeArgsFirstPhase(ref useSiteDiagnostics);
            bool success = InferTypeArgsSecondPhase(ref useSiteDiagnostics);
            return new MethodTypeInferenceResult(success, GetResults());
        }

        ////////////////////////////////////////////////////////////////////////////////
        //
        // The first phase
        //

        private void InferTypeArgsFirstPhase(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert(!_formalParameterTypes.IsDefault);
            Debug.Assert(!_arguments.IsDefault);

            // We expect that we have been handed a list of arguments and a list of the 
            // formal parameter types they correspond to; all the details about named and 
            // optional parameters have already been dealt with.

            // TODO:MetaDslx
        }

        ////////////////////////////////////////////////////////////////////////////////
        //
        // The second phase
        //

        private bool InferTypeArgsSecondPhase(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // TODO:MetaDslx
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////
        //
        // Helper methods
        //


        ////////////////////////////////////////////////////////////////////////////////
        //
        // In error recovery and reporting scenarios we sometimes end up in a situation
        // like this:
        //
        // x.Goo( y=>
        //
        // and the question is, "is Goo a valid extension method of x?"  If Goo is
        // generic, then Goo will be something like:
        //
        // static Blah Goo<T>(this Bar<T> bar, Func<T, T> f){ ... }
        //
        // What we would like to know is: given _only_ the expression x, can we infer
        // what T is in Bar<T> ?  If we can, then for error recovery and reporting
        // we can provisionally consider Goo to be an extension method of x. If we 
        // cannot deduce this just from x then we should consider Goo to not be an
        // extension method of x, at least until we have more information.
        //
        // Clearly it is pointless to run multiple phases
        public static ImmutableArray<TypeWithAnnotations> InferTypeArgumentsFromFirstArgument(
            LanguageCompilation compilation,
            MethodLikeSymbol method,
            ImmutableArray<ExpressionSymbol> arguments,
            ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert((object)method != null);
            Debug.Assert(method.Arity > 0);
            Debug.Assert(!arguments.IsDefault);

            // We need at least one formal parameter type and at least one argument.
            if ((method.Parameters.Length < 1) || (arguments.Length < 1))
            {
                return default(ImmutableArray<TypeWithAnnotations>);
            }

            Debug.Assert(method.Parameters[0].Type is not DynamicTypeSymbol);

            var constructedFromMethod = (MethodLikeSymbol)method.ConstructedFrom;

            var inferrer = new MethodTypeInferrer(
                compilation,
                constructedFromMethod.TypeParameters,
                constructedFromMethod.ContainingType,
                constructedFromMethod.Parameters.Select(p => p.TypeWithAnnotations).ToImmutableArray(),
                constructedFromMethod.Parameters.Select(p => p.RefKind).ToImmutableArray(),
                arguments,
                extensions: null);

            if (!inferrer.InferTypeArgumentsFromFirstArgument(ref useSiteDiagnostics))
            {
                return default(ImmutableArray<TypeWithAnnotations>);
            }

            return inferrer.GetInferredTypeArguments();
        }

        ////////////////////////////////////////////////////////////////////////////////

        private bool InferTypeArgumentsFromFirstArgument(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // TODO:MetaDslx
            return false;
        }

        /// <summary>
        /// Return the inferred type arguments using null
        /// for any type arguments that were not inferred.
        /// </summary>
        private ImmutableArray<TypeWithAnnotations> GetInferredTypeArguments()
        {
            return _fixedResults.AsImmutable();
        }
    }

}
