using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public sealed class NoConversions : Conversions
    {
        public NoConversions(LanguageCompilation compilation) 
            : base(compilation)
        {
        }

        public override Conversion ClassifyConversionFromExpression(ExpressionSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return NoConversion;
        }

        public override Conversion ClassifyConversionFromType(TypeSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return NoConversion;
        }
    }
}
