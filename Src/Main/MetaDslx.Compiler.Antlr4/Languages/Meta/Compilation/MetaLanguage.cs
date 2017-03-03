using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Meta
{
    public sealed class MetaLanguage : Language
    {
        internal const string LanguageName = "Meta";

        public static readonly MetaLanguage Instance = new MetaLanguage();

        private MetaLanguage()
        {
        }

        public override string Name
        {
            get { return MetaLanguage.LanguageName; }
        }

        protected override SyntaxFacts SyntaxFactsCore
        {
            get { return MetaSyntaxFacts.Instance; }
        }

        public new MetaSyntaxFacts SyntaxFacts
        {
            get { return (MetaSyntaxFacts)base.SyntaxFacts; }
        }

        protected override InternalSyntaxFactory InternalSyntaxFactoryCore
        {
            get { return MetaGreenFactory.Instance; }
        }

        internal MetaGreenFactory InternalSyntaxFactory
        {
            get { return (MetaGreenFactory)this.InternalSyntaxFactoryCore; }
        }

        protected override SyntaxFactory SyntaxFactoryCore
        {
            get { return MetaSyntaxFactory.Instance; }
        }

        public new MetaSyntaxFactory SyntaxFactory
        {
            get { return (MetaSyntaxFactory)base.SyntaxFactory; }
        }

        protected override CompilationFactory CompilationFactoryCore
        {
            get { return MetaCompilationFactory.Instance; }
        }

        internal MetaCompilationFactory CompilationFactory
        {
            get { return (MetaCompilationFactory)this.CompilationFactoryCore; }
        }
    }
}

