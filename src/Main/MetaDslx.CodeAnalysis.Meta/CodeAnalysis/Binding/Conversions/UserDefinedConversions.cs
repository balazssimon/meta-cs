using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public sealed class UserDefinedConversions : Conversions
    {
        public UserDefinedConversions(LanguageCompilation compilation) 
            : base(compilation)
        {
        }

        public override Conversion ClassifyConversionFromExpression(ExpressionSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // TODO:MetaDslx see UserDefinedConversions.cs in the Roslyn implementation to load user defined conversion operators
            return NoConversion;
        }

        public override Conversion ClassifyConversionFromType(TypeSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            // TODO:MetaDslx see UserDefinedConversions.cs in the Roslyn implementation to load user defined conversion operators
            return NoConversion;
        }
    }
}
