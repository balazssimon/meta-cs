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
        public virtual bool IsScriptInitializer => false;

        public bool IsEntryPointCandidate { get; internal set; }
        public bool IsGenericMethod { get; internal set; }

    }
}
