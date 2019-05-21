#define NO_METAx
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Bootstrap.Meta
{
#if !NO_META
    using MetaDslx.Bootstrap.Meta.Syntax.InternalSyntax;
#endif

    public class MetaLanguage : Language
    {
        public static readonly MetaLanguage Instance = new MetaLanguage();
        public override string Name => throw new NotImplementedException();

#if !NO_META
        internal new MetaInternalSyntaxFactory InternalSyntaxFactory => null;
        public new MetaSyntaxFactory SyntaxFactory => null;
#endif

        protected override SyntaxFacts SyntaxFactsCore => throw new NotImplementedException();

        protected override LookupPosition LookupPositionCore => throw new NotImplementedException();

        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => throw new NotImplementedException();

        protected override SyntaxFactory SyntaxFactoryCore => throw new NotImplementedException();

        protected override CompilationFactory CompilationFactoryCore => throw new NotImplementedException();

        protected override SymbolFacts SymbolFactsCore => throw new NotImplementedException();
    }
}
