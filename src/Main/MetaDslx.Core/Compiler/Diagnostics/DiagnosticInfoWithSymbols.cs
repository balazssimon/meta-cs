// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Symbols;
using System.Collections.Immutable;

namespace MetaDslx.Compiler.Diagnostics
{
    internal class DiagnosticInfoWithSymbols : DiagnosticInfo
    {
        // not serialized:
        internal readonly ImmutableArray<ISymbol0> Symbols;

        internal DiagnosticInfoWithSymbols(DiagnosticDescriptor descriptor, object[] arguments, ImmutableArray<ISymbol0> symbols)
            : base(descriptor, arguments)
        {
            this.Symbols = symbols;
        }

        internal DiagnosticInfoWithSymbols(DiagnosticDescriptor descriptor, bool isWarningAsError, int errorCode, object[] arguments, ImmutableArray<ISymbol0> symbols)
            : base(isWarningAsError, descriptor, arguments)
        {
            this.Symbols = symbols;
        }
    }
}
