using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class NoUnaryOperators : UnaryOperators
    {
        public NoUnaryOperators(LanguageCompilation compilation) 
            : base(compilation)
        {
        }

        public override UnaryOperatorSignature ClassifyOperatorByType(UnaryOperatorKind kind, TypeSymbol operand)
        {
            return UnaryOperatorSignature.Error;
        }
    }
}
