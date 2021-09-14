// NOTE: This is an auto-generated file. However, it will not be changed or regenerated unless you delete it.
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Core;
using MetaDslx.Languages.Core.Symbols;
using MetaDslx.Languages.Core.Syntax;
using MetaDslx.Languages.Core.Syntax.InternalSyntax;
using MetaDslx.Languages.Core.Model;
using MetaDslx.Languages.Meta.Symbols;

namespace MetaDslx.Languages.Core
{
    public class CoreLanguageServices : CoreLanguageServicesBase
    {
        public override SymbolFacts CreateSymbolFacts()
        {
            return new CustomCoreSymbolFacts();
        }
    }
}

