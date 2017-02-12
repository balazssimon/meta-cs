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
        public static IEnumerable<IMetaSymbol> GetChildren(this IMetaSymbol symbol, string name)
        {
            foreach (var child in symbol.MChildren)
            {
                if (name == null || child.MName == name)
                {
                    yield return child; 
                }
            }
        }

        public static bool IsOfKind(this IMetaSymbol symbol, Type kind)
        {
            return kind.Equals(symbol.MId.SymbolInfo.ImmutableType);
        }

        public static bool IsOfType(this IMetaSymbol symbol, Type type)
        {
            return type.IsAssignableFrom(symbol.MId.SymbolInfo.ImmutableType);
        }
    }
}
