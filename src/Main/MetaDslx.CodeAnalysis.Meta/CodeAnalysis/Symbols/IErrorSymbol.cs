using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IErrorSymbol
    {
        DiagnosticInfo? ErrorInfo { get; }
    }
}
