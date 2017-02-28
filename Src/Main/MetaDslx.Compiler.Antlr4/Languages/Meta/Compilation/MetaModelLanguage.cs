using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Meta
{
    public sealed class MetaModelLanguage : Language
    {
        internal const string LanguageName = "MetaModel";

        internal static readonly MetaModelLanguage Instance = new MetaModelLanguage();

        private MetaModelLanguage()
        {
        }

        public override string Name
        {
            get { return MetaModelLanguage.LanguageName; }
        }

        protected override SyntaxFacts SyntaxFactsCore
        {
            get { return MetaModelSyntaxFacts.Instance; }
        }

        public new MetaModelSyntaxFacts SyntaxFacts
        {
            get { return (MetaModelSyntaxFacts)base.SyntaxFacts; }
        }

        protected override InternalSyntaxFactory InternalSyntaxFactoryCore
        {
            get { return MetaModelGreenFactory.Instance; }
        }

        internal MetaModelGreenFactory InternalSyntaxFactory
        {
            get { return (MetaModelGreenFactory)this.InternalSyntaxFactoryCore; }
        }

        protected override SyntaxFactory SyntaxFactoryCore
        {
            get { return MetaModelSyntaxFactory.Instance; }
        }

        public new MetaModelSyntaxFactory SyntaxFactory
        {
            get { return (MetaModelSyntaxFactory)base.SyntaxFactory; }
        }

        protected override CompilationFactory CompilationFactoryCore
        {
            get { return MetaModelCompilationFactory.Instance; }
        }

        internal MetaModelCompilationFactory CompilationFactory
        {
            get { return (MetaModelCompilationFactory)this.CompilationFactoryCore; }
        }
    }
}

