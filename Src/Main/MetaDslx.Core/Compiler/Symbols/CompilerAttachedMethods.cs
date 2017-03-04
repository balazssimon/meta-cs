using MetaDslx.Compiler.Binding;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Symbols
{
    public static class CompilerAttachedMethods
    {
        public static bool IsOfKind(this ISymbol symbol, Type kind)
        {
            return kind.Equals(symbol.MId.SymbolInfo.ImmutableType);
        }

        public static bool IsOfType(this ISymbol symbol, Type type)
        {
            return type.IsAssignableFrom(symbol.MId.SymbolInfo.ImmutableType);
        }
    }
}
