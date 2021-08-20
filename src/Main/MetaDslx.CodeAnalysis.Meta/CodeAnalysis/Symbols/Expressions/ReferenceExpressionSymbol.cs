using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a qualified or unqualified reference to a type, a member or a varialble symbol.
    /// </summary>
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
        /// Referenced symbol (e.g., a type, a variable or a member).
        /// </summary>
        [SymbolProperty]
        public virtual DeclaredSymbol ReferencedSymbol { get; }

        /// <summary>
        /// The containing type of the referenced member, if different from type of the <see cref="Qualifier" />.
        /// </summary>
        [SymbolProperty]
        public virtual TypeSymbol? ContainingType { get; }

        public override bool IsInstanceReceiver => !IsStaticReceiver;

        public override bool IsStaticReceiver => (ReferencedSymbol is TypeSymbol) || ReferencedSymbol.IsStatic;


        protected virtual void BindReferencedSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
           /* var compilation = this.DeclaringCompilation;
            if (compilation is null) return;
            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            var result = OverloadResolutionResult<MethodLikeSymbol>.GetInstance();
            compilation.OverloadResolution.MethodInvocationOverloadResolution();
            if (result.SingleValid())
            {
                var bestResult = result.Best;
            }
            if (useSiteDiagnostics is not null)
            {
                var location = this.Locations.FirstOrNone();
                foreach (var diag in useSiteDiagnostics)
                {
                    diagnostics.Add(diag.ToDiagnostic(location));
                }
            }
            result.Free();*/
        }
    }

}
