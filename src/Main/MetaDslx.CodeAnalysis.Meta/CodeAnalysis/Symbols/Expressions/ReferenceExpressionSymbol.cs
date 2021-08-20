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
    /// Represents a non-member-access reference to a declared symbol.
    /// </summary>
    [Symbol]
    public abstract partial class ReferenceExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// If the reference is a member access, this is the type or instance of which the member is accessed.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? Receiver { get; }

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
        public virtual DeclaredSymbol ReferencedSymbol { get; }

        /// <summary>
        /// The containing type of the referenced member, if different from type of the <see cref="Receiver" />.
        /// </summary>
        public virtual TypeSymbol? ContainingType { get; }

        public override bool IsInstanceReceiver => Receiver?.IsInstanceReceiver ?? !(ReferencedSymbol is TypeSymbol);

        public override bool IsStaticReceiver => ReferencedSymbol is TypeSymbol;


        [SymbolCompletionPart]
        protected virtual void BindReferencedSymbol(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {

        }
        /*{
            var compilation = this.DeclaringCompilation;
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
            result.Free();
        }*/
    }

    public class A
    {
        public static class C
        {
            public const string X = "X";
        }
    }

    public class B : A
    {
        public static new class C
        {
            public const string X = A.C.X;
        }
    }
}
