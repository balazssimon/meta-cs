// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Core;
using System.Collections.Immutable;

namespace MetaDslx.Compiler.Diagnostics
{
    internal class DiagnosticInfoWithSymbols : DiagnosticInfo
    {
        // not serialized:
        internal readonly ImmutableArray<ISymbol> Symbols;

        internal DiagnosticInfoWithSymbols(DiagnosticDescriptor descriptor, object[] arguments, ImmutableArray<ISymbol> symbols)
            : base(descriptor, arguments)
        {
            this.Symbols = symbols;
        }

        internal DiagnosticInfoWithSymbols(DiagnosticDescriptor descriptor, bool isWarningAsError, int errorCode, object[] arguments, ImmutableArray<ISymbol> symbols)
            : base(isWarningAsError, descriptor, arguments)
        {
            this.Symbols = symbols;
        }
    }
}
