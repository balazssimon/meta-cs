using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal static class ConstraintsHelper
    {
        internal static bool CheckMethodConstraints(MethodSymbol method, Conversions conversions, LanguageCompilation compilation, ArrayBuilder<TypeParameterDiagnosticInfo> diagnosticsBuilder, object nullabilityDiagnosticsBuilderOpt, ref ArrayBuilder<TypeParameterDiagnosticInfo>? useSiteDiagnosticsBuilder)
        {
            // TODO:MetaDslx
            return true;
        }
    }
}
