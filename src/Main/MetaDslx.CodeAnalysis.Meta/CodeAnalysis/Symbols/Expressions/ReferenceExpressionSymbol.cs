using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a qualified or unqualified reference to a type, a member or a varialble symbol.
    /// </summary>
    [Symbol]
    public abstract partial class ReferenceExpressionSymbol : ExpressionSymbol, IInvocationReceiver
    {
        /// <summary>
        /// If the reference is a qualified access, this is the qualifier.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? Qualifier { get; }

        /// <summary>
        /// The name of the referenced symbol.
        /// </summary>
        [SymbolProperty]
        public virtual string? ReferencedName { get; }

        /// <summary>
        /// The metadata name of the referenced symbol.
        /// </summary>
        [SymbolProperty]
        public virtual string? ReferencedMetadataName { get; }

        /// <summary>
        /// Indicates whether member access is null conditional (?. operator)
        /// </summary>
        [SymbolProperty]
        public abstract bool IsNullConditional { get; }

        /// <summary>
        /// Type arguments.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<TypeSymbol> TypeArguments { get; }

        /// <summary>
        /// True if this reference is also the declaration site of this variable. This is true in out variable declarations
        /// and in deconstruction operations where a new variable is being declared.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsDeclaration { get; }

        /// <summary>
        /// The containing type of the referenced member, if different from type of the <see cref="Qualifier" />.
        /// </summary>
        [SymbolProperty]
        public virtual TypeSymbol? ReferenceThroughType { get; }

        /// <summary>
        /// Referenced symbol (e.g., a type, a variable or a member).
        /// </summary>
        [SymbolProperty]
        public virtual DeclaredSymbol ReferencedSymbol { get; }

        public override bool IsConstant
        {
            get
            {
                if (this.ReferencedSymbol is TypeSymbol) return true;
                if (this.ReferencedSymbol is VariableSymbol variable) return variable.IsConst ?? false;
                if (this.ReferencedSymbol is FieldLikeSymbol) return false;
                if (this.ReferencedSymbol is MethodLikeSymbol) return false;
                return false;
            }
        }

        public override TypeSymbol? Type
        {
            get
            {
                if (this.ReferencedSymbol is TypeSymbol type) return type;
                if (this.ReferencedSymbol is VariableSymbol variable) return variable.Type;
                if (this.ReferencedSymbol is FieldLikeSymbol field) return field.Type;
                if (this.ReferencedSymbol is MethodLikeSymbol method) return method?.Result?.Type;
                return null;
            }
        }
    }


    namespace Completion
    {
        public partial class CompletionReferenceExpressionSymbol
        {
            protected virtual DeclaredSymbol? CompleteSymbolProperty_ReferencedSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                if (SymbolImplementation.AssignSymbolPropertyValue<DeclaredSymbol>(this, nameof(ReferencedSymbol), diagnostics, cancellationToken, out var result))
                {
                    return result;
                }
                else
                {
                    return BindSourceReferencedSymbol(diagnostics, cancellationToken);
                }
            }

            protected DeclaredSymbol? BindSourceReferencedSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                DeclaredSymbol? result = null;
                var compilation = this.DeclaringCompilation;
                if (compilation is null) return null;
                var isMethod = false;
                var isProperty = false;
                var arguments = ImmutableArray<ArgumentSymbol>.Empty;
                if (this.ContainingSymbol is IInvocation invocation)
                {
                    arguments = invocation.Arguments;
                    isMethod = invocation.IsMethodInvocation;
                    isProperty = invocation.IsPropertyInvocation;
                }
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                var qualifierOpt = ReferenceThroughType ?? Qualifier?.Type;
                if (isMethod || isProperty)
                {
                    var candidates = LookupCandidates.GetInstance();
                    foreach (var location in this.Locations)
                    {
                        var sourceLocation = location as SourceLocation;
                        if (sourceLocation is null) continue;
                        var binder = compilation.GetBinder(sourceLocation.GetSyntax());
                        if (binder is null) continue;
                        binder.AddLookupCandidateSymbols(candidates, new LookupConstraints(binder, sourceLocation, this.ReferencedName, this.ReferencedMetadataName, qualifierOpt));
                    }
                    if (candidates.IsClear)
                    {
                        diagnostics.Add(ModelErrorCode.ERR_NameDoesNotExist.ToDiagnostic(this.GetLocation(), this.ReferencedName ?? string.Empty));
                        candidates.Free();
                        return result;
                    }
                    var analyzedArguments = AnalyzedArguments.GetInstance(arguments);
                    var typeArguments = ArrayBuilder<TypeWithAnnotations>.GetInstance();
                    typeArguments.AddRange(this.TypeArguments.Select(arg => TypeWithAnnotations.Create(arg)));
                    if (isMethod)
                    {
                        var methodResult = OverloadResolutionResult<MethodLikeSymbol>.GetInstance();
                        var methods = ArrayBuilder<MethodLikeSymbol>.GetInstance();
                        methods.AddRange(candidates.Symbols.OfType<MethodLikeSymbol>());
                        compilation.OverloadResolution.MethodInvocationOverloadResolution(methods, typeArguments, Qualifier, analyzedArguments, ContainingType, false, methodResult, ref useSiteDiagnostics);
                        methods.Free();
                        AddSymbolDiagnostics(useSiteDiagnostics);
                        if (useSiteDiagnostics is null || useSiteDiagnostics.Count == 0)
                        {
                            if (!methodResult.Succeeded)
                            {
                                diagnostics.Add(ModelErrorCode.ERR_NameDoesNotExist.ToDiagnostic(this.GetLocation(), this.ReferencedName ?? string.Empty));
                            }
                        }
                        if (methodResult.Succeeded) result = methodResult.BestResult.Member;
                        methodResult.Free();
                    }
                    else if (isProperty)
                    {
                        var indexerResult = OverloadResolutionResult<IndexerSymbol>.GetInstance();
                        var indexers = ArrayBuilder<IndexerSymbol>.GetInstance();
                        indexers.AddRange(candidates.Symbols.OfType<IndexerSymbol>());
                        compilation.OverloadResolution.IndexerOverloadResolution(indexers, Qualifier, analyzedArguments, ContainingType, false, indexerResult, false, ref useSiteDiagnostics);
                        indexers.Free();
                        AddSymbolDiagnostics(useSiteDiagnostics);
                        if (useSiteDiagnostics is null || useSiteDiagnostics.Count == 0)
                        {
                            if (!indexerResult.Succeeded)
                            {
                                diagnostics.Add(ModelErrorCode.ERR_NameDoesNotExist.ToDiagnostic(this.GetLocation(), this.ReferencedName ?? string.Empty));
                            }
                        }
                        if (indexerResult.Succeeded) result = indexerResult.BestResult.Member;
                        indexerResult.Free();
                    }
                    candidates.Free();
                    typeArguments.Free();
                    analyzedArguments.Free();
                }
                else
                {
                    var results = LookupResult.GetInstance();
                    Binder? lastBinder = null;
                    foreach (var location in this.Locations)
                    {
                        var sourceLocation = location as SourceLocation;
                        if (sourceLocation is null) continue;
                        var binder = compilation.GetBinder(sourceLocation.GetSyntax());
                        if (binder is null) continue;
                        lastBinder = binder;
                        binder.LookupSymbols(results, new LookupConstraints(binder, sourceLocation, this.ReferencedName, this.ReferencedMetadataName, qualifierOpt), ref useSiteDiagnostics);
                        AddSymbolDiagnostics(useSiteDiagnostics);
                        if (useSiteDiagnostics is null || useSiteDiagnostics.Count == 0)
                        {
                            if (results.Error is not null)
                            {
                                diagnostics.Add(results.Error.ToDiagnostic(this.GetLocation()));
                            }
                        }
                    }
                    if (results.IsSingleViable)
                    {
                        result = results.SingleSymbolOrDefault;
                    }
                }
                return result;
            }
        }
    }

}
