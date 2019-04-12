using MetaDslx.Compiler.Binding;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Symbols
{
    public static class CompilerAttachedMethods
    {
        public static bool MIsOfKind(this ISymbol0 symbol, Type kind)
        {
            return kind.Equals(symbol.MId.SymbolInfo.ImmutableType);
        }

        public static bool MIsOfType(this ISymbol0 symbol, Type type)
        {
            return type.IsAssignableFrom(symbol.MId.SymbolInfo.ImmutableType);
        }

        public static bool MIsNamedType(this ISymbol0 symbol)
        {
            return symbol.MIsType && !string.IsNullOrEmpty(symbol.MName);
        }

        public static bool MCanBeReferencedByName(this ISymbol0 symbol)
        {
            return !string.IsNullOrEmpty(symbol.MName);
        }

        public static bool MIsScriptClass(this ISymbol0 symbol)
        {
            return false;
        }

        public static bool MIsErrorType(this ISymbol0 symbol)
        {
            return false;
        }

        public static ImmutableArray<SyntaxReference> DeclaringSyntaxReferences(this ISymbol0 symbol)
        {
            return (ImmutableArray<SyntaxReference>)symbol.MGet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty);
        }
    }
}
