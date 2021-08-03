using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Reflection.Metadata;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a method or function.
    /// </summary>
    [Symbol]
    public abstract partial class MethodSymbol : BehavioralMemberSymbol
    {
        [SymbolProperty]
        public virtual bool IsAsync => false;

        [SymbolProperty]
        public abstract TypeSymbol ReturnType { get; }

        [SymbolProperty]
        public abstract ImmutableArray<ParameterSymbol> Parameters { get; }

        [SymbolProperty]
        public abstract StatementSymbol Body { get; }


        public virtual bool IsScriptInitializer => false;

        public bool IsEntryPointCandidate { get; }
        public bool IsGenericMethod { get; }

    }
}