using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceConstructedTypeSymbol : SourceTypeSymbol
    {
        private SymbolCompletionState _state;

        public SourceConstructedTypeSymbol(SourceAssemblySymbol containingAssembly, SyntaxReference syntaxReference, IMetaSymbol modelObject) 
            : base(containingAssembly, syntaxReference, modelObject)
        {
            _state = SymbolCompletionState.Create(containingAssembly.Language);
        }

        public override LanguageSymbolKind Kind => LanguageSymbolKind.ConstructedType;

        public override LanguageTypeKind TypeKind => LanguageTypeKind.Constructed;

    }
}
