using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class UserDefinedBinaryOperators : BinaryOperators
    {
        public UserDefinedBinaryOperators(LanguageCompilation compilation) 
            : base(compilation)
        {
        }

        public override BinaryOperatorSignature ClassifyOperatorByType(BinaryOperatorKind kind, TypeSymbol left, TypeSymbol right)
        {
            return BinaryOperatorSignature.Error;
        }
    }
}
