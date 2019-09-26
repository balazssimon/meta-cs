using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceAnonymousTypeSymbol : SourceNamedTypeSymbol
    {
        public SourceAnonymousTypeSymbol(DeclaredSymbol containingSymbol, MergedDeclaration declaration, DiagnosticBag diagnostics) 
            : base(containingSymbol, declaration, diagnostics)
        {
        }

        public override LanguageTypeKind TypeKind => LanguageTypeKind.AnonymousType;
    }
}
