using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class TypeParameterSymbol : TypeSymbol
    {
        public new TypeParameterSymbol OriginalDefinition => this;
    }
}
