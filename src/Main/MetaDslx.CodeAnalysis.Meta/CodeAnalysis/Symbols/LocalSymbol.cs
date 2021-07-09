using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SubSymbolKindType = "LocalKind")]
    public abstract partial class LocalSymbol : DeclaredSymbol
    {
        public override bool IsStatic => false;

        public bool IsConst { get; internal set; }
        public bool IsRef { get; internal set; }
        public RefKind RefKind { get; internal set; }
        public bool HasConstantValue { get; internal set; }
        public object ConstantValue { get; internal set; }
        public bool IsFixed { get; internal set; }
        internal TypeWithAnnotations TypeWithAnnotations { get;  set; }

    }
}
