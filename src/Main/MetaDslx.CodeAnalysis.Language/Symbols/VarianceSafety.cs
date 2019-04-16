// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// This class groups together all of the functionality needed to check for error CS1961, ERR_UnexpectedVariance.
    /// Its functionality is accessible through the NamedTypeSymbol extension method CheckInterfaceVarianceSafety and
    /// the MethodSymbol extension method CheckMethodVarianceSafety (for checking delegate Invoke).
    /// </summary>
    internal static class VarianceSafety
    {
        #region Interface variance safety

        /// <summary>
        /// Accumulate diagnostics related to the variance safety of an interface.
        /// </summary>
        internal static void CheckInterfaceVarianceSafety(this NamedTypeSymbol interfaceType, DiagnosticBag diagnostics)
        {
            Debug.Assert((object)interfaceType != null && interfaceType.IsInterface);

            foreach (NamedTypeSymbol baseInterface in interfaceType.InterfacesNoUseSiteDiagnostics())
            {
                IsVarianceUnsafe(
                    baseInterface,
                    requireOutputSafety: true,
                    requireInputSafety: false,
                    context: baseInterface,
                    locationProvider: i => null,
                    locationArg: baseInterface,
                    diagnostics: diagnostics);
            }

            foreach (Symbol member in interfaceType.GetMembersUnordered())
            {
                switch (member.Kind)
                {
                    case SymbolKind.Method:
                        if (!member.IsAccessor())
                        {
                            CheckMethodVarianceSafety((MethodSymbol)member, diagnostics);
                        }
                        break;
                    case SymbolKind.Property:
                        CheckPropertyVarianceSafety((PropertySymbol)member, diagnostics);
                        break;
                    case SymbolKind.Event:
                        CheckEventVarianceSafety((EventSymbol)member, diagnostics);
                        break;
                }
            }
        }

        /// <summary>
        /// Accumulate diagnostics related to the variance safety of a delegate.
        /// </summary>
        internal static void CheckDelegateVarianceSafety(this SourceDelegateMethodSymbol method, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Accumulate diagnostics related to the variance safety of an interface method.
        /// </summary>
        private static void CheckMethodVarianceSafety(this MethodSymbol method, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static void CheckMethodVarianceSafety(this MethodSymbol method, LocationProvider<MethodSymbol> returnTypeLocationProvider, DiagnosticBag diagnostics)
        {
            // Spec 13.2.1: "Furthermore, each class type constraint, interface type constraint and
            // type parameter constraint on any type parameter of the method must be input-safe."
            CheckTypeParametersVarianceSafety(method.TypeParameters, method, diagnostics);

            //spec only applies this to non-void methods, but it falls out of our impl anyway
            IsVarianceUnsafe(
                method.ReturnType,
                requireOutputSafety: true,
                requireInputSafety: method.RefKind != RefKind.None,
                context: method,
                locationProvider: returnTypeLocationProvider,
                locationArg: method,
                diagnostics: diagnostics);

            CheckParametersVarianceSafety(method.Parameters, method, diagnostics);
        }

        /// <summary>
        /// Accumulate diagnostics related to the variance safety of an interface property.
        /// </summary>
        private static void CheckPropertyVarianceSafety(PropertySymbol property, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Accumulate diagnostics related to the variance safety of an interface event.
        /// </summary>
        private static void CheckEventVarianceSafety(EventSymbol @event, DiagnosticBag diagnostics)
        {
            IsVarianceUnsafe(
                @event.Type,
                requireOutputSafety: false,
                requireInputSafety: true,
                context: @event,
                locationProvider: e => e.Locations[0],
                locationArg: @event,
                diagnostics: diagnostics);
        }

        /// <summary>
        /// Accumulate diagnostics related to the variance safety of an interface method/property parameter.
        /// </summary>
        private static void CheckParametersVarianceSafety(ImmutableArray<ParameterSymbol> parameters, Symbol context, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Accumulate diagnostics related to the variance safety of an interface method type parameters.
        /// </summary>
        private static void CheckTypeParametersVarianceSafety(ImmutableArray<TypeParameterSymbol> typeParameters, MethodSymbol context, DiagnosticBag diagnostics)
        {
            foreach (TypeParameterSymbol typeParameter in typeParameters)
            {
                foreach (TypeWithAnnotations constraintType in typeParameter.ConstraintTypesNoUseSiteDiagnostics)
                {
                    IsVarianceUnsafe(constraintType.Type,
                        requireOutputSafety: false,
                        requireInputSafety: true,
                        context: context,
                        locationProvider: t => t.Locations[0],
                        locationArg: typeParameter,
                        diagnostics: diagnostics);
                }
            }
        }

        #endregion Interface variance safety

        #region Input- and output- unsafeness

        /// <summary>
        /// Returns true if the type is output-unsafe or input-unsafe, as defined in the C# spec.
        /// Roughly, a type is output-unsafe if it could not be the return type of a method and
        /// input-unsafe if it could not be a parameter type of a method.
        /// </summary>
        /// <remarks>
        /// This method is intended to match spec section 13.1.3.1 as closely as possible 
        /// (except that the output-unsafe and input-unsafe checks are merged).
        /// </remarks>
        private static bool IsVarianceUnsafe<T>(
            TypeSymbol type,
            bool requireOutputSafety,
            bool requireInputSafety,
            Symbol context,
            LocationProvider<T> locationProvider,
            T locationArg,
            DiagnosticBag diagnostics)
            where T : Symbol
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// 3) T is an interface, class, struct, enum, or delegate type <![CDATA[S<A_1, ..., A_k>]]> constructed
        /// from a generic type <![CDATA[S<X_1, ..., X_k>]]> where for at least one A_i one
        /// of the following holds:
        ///     a) X_i is covariant or invariant and A_i is output-unsafe [input-unsafe]
        ///     b) X_i is contravariant or invariant and A_i is input-unsafe [output-unsafe] (note: spec has "input-safe", but it's a typo)
        /// </summary>
        /// <remarks>
        /// Slight rewrite to make it more idiomatic for C#:
        ///     a) X_i is covariant and A_i is input-unsafe
        ///     b) X_i is contravariant and A_i is output-unsafe
        ///     c) X_i is invariant and A_i is input-unsafe or output-unsafe
        /// </remarks>
        private static bool IsVarianceUnsafe<T>(
            NamedTypeSymbol namedType,
            bool requireOutputSafety,
            bool requireInputSafety,
            Symbol context,
            LocationProvider<T> locationProvider,
            T locationArg,
            DiagnosticBag diagnostics)
            where T : Symbol
        {
            Debug.Assert(requireOutputSafety || requireInputSafety);

            switch (namedType.TypeKind)
            {
                case TypeKind.Class:
                case TypeKind.Struct:
                case TypeKind.Enum: // Can't be generic, but can be nested in generic.
                case TypeKind.Interface:
                case TypeKind.Delegate:
                case TypeKind.Error:
                    break;
                default:
                    return false;
            }

            while ((object)namedType != null)
            {
                for (int i = 0; i < namedType.Arity; i++)
                {
                    TypeParameterSymbol typeParam = namedType.TypeParameters[i];
                    TypeSymbol typeArg = namedType.TypeArgumentsWithAnnotationsNoUseSiteDiagnostics[i].Type;

                    bool requireOut;
                    bool requireIn;

                    switch (typeParam.Variance)
                    {
                        case VarianceKind.Out:
                            // a) X_i is covariant and A_i is output-unsafe [input-unsafe]
                            requireOut = requireOutputSafety;
                            requireIn = requireInputSafety;
                            break;
                        case VarianceKind.In:
                            // b) X_i is contravariant and A_i is input-unsafe [output-unsafe]
                            requireOut = requireInputSafety;
                            requireIn = requireOutputSafety;
                            break;
                        case VarianceKind.None:
                            // c) X_i is invariant and A_i is output-unsafe or input-unsafe
                            requireIn = true;
                            requireOut = true;
                            break;
                        default:
                            throw ExceptionUtilities.UnexpectedValue(typeParam.Variance);
                    }

                    if (IsVarianceUnsafe(typeArg, requireOut, requireIn, context, locationProvider, locationArg, diagnostics))
                    {
                        return true;
                    }
                }

                namedType = namedType.ContainingType;
            }

            return false;
        }

        #endregion Input- and output- unsafeness

        #region Adding diagnostics

        private delegate Location LocationProvider<T>(T arg);
                
        private static T GetDeclaringSyntax<T>(this Symbol symbol) where T : SyntaxNode
        {
            var syntaxRefs = symbol.DeclaringSyntaxReferences;
            if (syntaxRefs.Length == 0)
            {
                return null;
            }
            return syntaxRefs[0].GetSyntax() as T;
        }

        #endregion Adding diagnostics
    }
}
