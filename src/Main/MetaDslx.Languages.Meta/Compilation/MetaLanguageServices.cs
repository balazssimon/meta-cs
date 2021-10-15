using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta
{
    public class MetaLanguageServices : MetaLanguageServicesBase
    {
        public override SymbolFacts CreateSymbolFacts()
        {
            return new CustomMetaSymbolFacts();
        }

        public override InternalSyntaxFactory CreateInternalSyntaxFactory(SyntaxFacts syntaxFacts)
        {
            return new CustomMetaInternalSyntaxFactory((MetaSyntaxFacts)syntaxFacts);
        }
    }
}
