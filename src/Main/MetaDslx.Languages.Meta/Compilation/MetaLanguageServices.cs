using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Symbols;
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
    }
}
