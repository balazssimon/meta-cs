using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IVariableTypeInferrer
    {
        TypeSymbol? VariableType { get; }
        bool? IsConstVariable { get; }
        ExpressionSymbol? VariableInitializer { get; }
    }
}
