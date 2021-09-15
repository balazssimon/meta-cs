using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a method or method-like symbol (including constructor,
    /// destructor, operator, or property/event accessor).
    /// </summary>
    public abstract partial class MethodLikeSymbol : MemberSymbol, IInvocableMember
    {
        [SymbolProperty]
        public virtual bool IsAsync => false;

        [SymbolProperty]
        public abstract ParameterSymbol? Result { get; }

        [SymbolProperty]
        public abstract ImmutableArray<ParameterSymbol> Parameters { get; }

        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

        public bool IsVarArg => this.Parameters.Any(p => p.IsVarArg);

        internal bool CheckConstraints(LanguageCompilation compilation, Location location, DiagnosticBag diagnostics)
        {
            return true;
        }
    }
}
