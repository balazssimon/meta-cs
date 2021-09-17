using MetaDslx.CodeAnalysis.Binding;
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
    public abstract partial class ReferenceExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// If the reference is a qualified access, this is the qualifier.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? Qualifier { get; }

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
                if (this.ReferencedSymbol is FieldLikeSymbol field) return false;
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
                return null;
            }
        }
    }


    namespace Completion
    {
        public partial class CompletionReferenceExpressionSymbol
        {
            private UnaryOperatorAnalysisResult _analysisResult;

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
                var qualifierOpt = ReferenceThroughType ?? Qualifier?.Type;
                var candidates = LookupCandidates.GetInstance();
                foreach (var location in this.Locations)
                {
                    var sourceLocation = location as SourceLocation;
                    if (sourceLocation is null) continue;
                    var binder = compilation.GetBinder(sourceLocation.GetSyntax());
                    if (binder is null) continue;
                    binder.AddLookupCandidateSymbols(candidates, new LookupConstraints(binder, sourceLocation, this.Name, this.MetadataName, qualifierOpt));
                }
                var isMethod = false;
                var isProperty = false;
                var arguments = ImmutableArray<ArgumentSymbol>.Empty;
                if (this.ContainingSymbol is IInvocationExpressionSymbol invocation)
                {
                    arguments = invocation.Arguments;
                    isMethod = invocation.IsMethodInvocation;
                    isProperty = invocation.IsPropertyInvocation;
                }
                var analyzedArguments = AnalyzedArguments.GetInstance(arguments);
                var typeArguments = ArrayBuilder<TypeWithAnnotations>.GetInstance();
                typeArguments.AddRange(this.TypeArguments.Select(arg => TypeWithAnnotations.Create(arg)));
                if (isMethod)
                {
                    var methodResult = OverloadResolutionResult<MethodLikeSymbol>.GetInstance();
                    HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                    var methods = ArrayBuilder<MethodLikeSymbol>.GetInstance();
                    methods.AddRange(candidates.Symbols.OfType<MethodLikeSymbol>());
                    compilation.OverloadResolution.MethodInvocationOverloadResolution(methods, typeArguments, Qualifier, analyzedArguments, ContainingType, false, methodResult, ref useSiteDiagnostics);
                    methods.Free();
                    AddSymbolDiagnostics(useSiteDiagnostics);
                    result = methodResult.BestResult.Member;
                    methodResult.Free();
                }
                else if (isProperty)
                {
                    var indexerResult = OverloadResolutionResult<IndexerSymbol>.GetInstance();
                    HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                    var indexers = ArrayBuilder<IndexerSymbol>.GetInstance();
                    indexers.AddRange(candidates.Symbols.OfType<IndexerSymbol>());
                    compilation.OverloadResolution.IndexerOverloadResolution(indexers, Qualifier, analyzedArguments, ContainingType, false, indexerResult, false, ref useSiteDiagnostics);
                    indexers.Free();
                    AddSymbolDiagnostics(useSiteDiagnostics);
                    result = indexerResult.BestResult.Member;
                    indexerResult.Free();
                }
                candidates.Free();
                typeArguments.Free();
                analyzedArguments.Free();
                return result;
            }
        }
    }

}
