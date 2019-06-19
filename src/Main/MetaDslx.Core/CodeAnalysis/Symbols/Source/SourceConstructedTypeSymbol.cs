using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceConstructedTypeSymbol : SourceTypeSymbol
    {
        public SourceConstructedTypeSymbol(Symbol containingSymbol, SyntaxReference syntaxReference, IMetaSymbol modelObject) 
            : base(containingSymbol, syntaxReference, modelObject)
        {
        }

        public override LanguageSymbolKind Kind => LanguageSymbolKind.ConstructedType;

        public override LanguageTypeKind TypeKind => LanguageTypeKind.Constructed;
    }
}
