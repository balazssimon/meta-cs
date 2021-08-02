using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a method or method-like symbol (including constructor,
    /// destructor, operator, or property/event accessor).
    /// </summary>
    public abstract class BehavioralMemberSymbol : MemberSymbol
    {
        [SymbolProperty]
        public virtual bool IsAsync => false;
        [SymbolProperty]
        public abstract TypeSymbol ReturnType { get; }
        [SymbolProperty]
        public abstract ImmutableArray<ParameterSymbol> Parameters { get; }
    }
}
