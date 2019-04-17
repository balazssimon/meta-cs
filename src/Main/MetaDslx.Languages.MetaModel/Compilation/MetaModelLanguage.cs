using MetaDslx.Languages.MetaModel.Syntax;
using MetaDslx.Languages.MetaModel.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Diagnostics;

namespace MetaDslx.Languages.MetaModel
{
    public sealed class MetaModelLanguage : Language
    {
        public static readonly MetaModelLanguage Instance = new MetaModelLanguage();

        public override string Name => throw new NotImplementedException();

        public new MetaModelSyntaxFacts SyntaxFacts => (MetaModelSyntaxFacts)this.SyntaxFactsCore;
        protected override SyntaxFacts SyntaxFactsCore => new MetaModelSyntaxFacts();

        public new MetaModelLookupPosition LookupPosition => (MetaModelLookupPosition)this.LookupPositionCore;
        protected override LookupPosition LookupPositionCore => new MetaModelLookupPosition();

        internal new MetaModelInternalSyntaxFactory InternalSyntaxFactory => (MetaModelInternalSyntaxFactory)this.InternalSyntaxFactoryCore;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => new MetaModelInternalSyntaxFactory();

        public new MetaModelSyntaxFactory SyntaxFactory => (MetaModelSyntaxFactory)this.SyntaxFactoryCore;
        protected override SyntaxFactory SyntaxFactoryCore => throw new NotImplementedException();
    }
}
