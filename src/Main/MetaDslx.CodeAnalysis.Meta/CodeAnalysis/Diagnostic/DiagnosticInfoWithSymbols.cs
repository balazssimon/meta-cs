// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis.Internal
{
    public class DiagnosticInfoWithSymbols : DiagnosticInfo
    {
        // not serialized:
        internal readonly ImmutableArray<Symbol> Symbols;

        internal DiagnosticInfoWithSymbols(ErrorCode errorCode, object[] arguments, ImmutableArray<Symbol> symbols)
            : base(errorCode.MessageProvider, errorCode.Code, arguments)
        {
            this.Symbols = symbols;
        }

        internal DiagnosticInfoWithSymbols(bool isWarningAsError, ErrorCode errorCode, object[] arguments, ImmutableArray<Symbol> symbols)
            : base(errorCode.MessageProvider, isWarningAsError, errorCode.Code, arguments)
        {
            this.Symbols = symbols;
        }
    }
}
