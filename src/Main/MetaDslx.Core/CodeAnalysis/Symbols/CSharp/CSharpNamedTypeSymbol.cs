using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;
    using CSharpSymbol = Microsoft.CodeAnalysis.CSharp.Symbol;

    public class CSharpNamedTypeSymbol : NamedTypeSymbol
    {
        private CSharpModuleSymbol _module;
        private CSharpSymbols.NamedTypeSymbol _csharpSymbol;

        private CSharpNamedTypeSymbol(CSharpModuleSymbol module, CSharpSymbols.NamedTypeSymbol csharpSymbol)
        {
            _module = module;
            _csharpSymbol = csharpSymbol;
        }

        internal static CSharpNamedTypeSymbol FromCSharp(CSharpSymbols.NamedTypeSymbol csharpSymbol)
        {
            return new CSharpNamedTypeSymbol(CSharpSymbolMap.GetModuleSymbol(csharpSymbol.ContainingModule), csharpSymbol);
        }
    }
}
