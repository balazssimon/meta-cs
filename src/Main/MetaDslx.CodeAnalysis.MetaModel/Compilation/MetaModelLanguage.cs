using MetaDslx.CodeAnalysis.MetaModel.Syntax;
using MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;
using System;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.MetaModel
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
