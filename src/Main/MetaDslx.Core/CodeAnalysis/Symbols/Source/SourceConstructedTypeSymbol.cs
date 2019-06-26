using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceConstructedTypeSymbol : SourceTypeSymbol
    {
        public SourceConstructedTypeSymbol(SourceAssemblySymbol containingAssembly, SyntaxReference syntaxReference, IMetaSymbol modelObject) 
            : base(containingAssembly, syntaxReference, modelObject)
        {
        }

        public override LanguageSymbolKind Kind => LanguageSymbolKind.ConstructedType;

        public override LanguageTypeKind TypeKind => LanguageTypeKind.Constructed;
    }
}
