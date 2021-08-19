using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class UserDefinedUnaryOperators : UnaryOperators
    {
        public UserDefinedUnaryOperators(LanguageCompilation compilation) 
            : base(compilation)
        {
        }

        public override UnaryOperatorSignature ClassifyOperatorByType(UnaryOperatorKind kind, TypeSymbol operand)
        {
            // TODO:MetaDslx see UnaryOperatorOverloadResolution.cs in the Roslyn implementation to load user defined unary operators
            return UnaryOperatorSignature.Error;
        }
    }
}
