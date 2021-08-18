using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// A tuple of TypeParameterSymbol and DiagnosticInfo, created for errors
    /// reported from ConstraintsHelper rather than creating Diagnostics directly.
    /// This decouples constraints checking from syntax and Locations, and supports
    /// callers that may want to create Location instances lazily or not at all.
    /// </summary>
    internal readonly struct TypeParameterDiagnosticInfo
    {
        public readonly TypeParameterSymbol TypeParameter;
        public readonly DiagnosticInfo DiagnosticInfo;

        public TypeParameterDiagnosticInfo(TypeParameterSymbol typeParameter, DiagnosticInfo diagnosticInfo)
        {
            this.TypeParameter = typeParameter;
            this.DiagnosticInfo = diagnosticInfo;
        }
    }
}
