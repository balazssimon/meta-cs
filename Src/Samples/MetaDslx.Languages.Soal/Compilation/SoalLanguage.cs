using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Languages.Soal.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Soal
{
    public class SoalLanguage : Language
    {
        public const string LanguageName = "Soal";

        public static readonly SoalLanguage Instance = new SoalLanguage();

        private SoalLanguage()
        {
        }

        public override string Name
        {
            get { return SoalLanguage.LanguageName; }
        }

        protected override MessageProvider MessageProviderCore
        {
            get { return SoalMessageProvider.Instance; }
        }

        public new SoalMessageProvider MessageProvider
        {
            get { return (SoalMessageProvider)base.MessageProvider; }
        }

        protected override SyntaxFacts SyntaxFactsCore
        {
            get { return SoalSyntaxFacts.Instance; }
        }

        public new SoalSyntaxFacts SyntaxFacts
        {
            get { return (SoalSyntaxFacts)base.SyntaxFacts; }
        }

        protected override InternalSyntaxFactory InternalSyntaxFactoryCore
        {
            get { return SoalGreenFactory.Instance; }
        }

        internal new SoalGreenFactory InternalSyntaxFactory
        {
            get { return (SoalGreenFactory)base.InternalSyntaxFactory; }
        }

        protected override SyntaxFactory SyntaxFactoryCore
        {
            get { return SoalSyntaxFactory.Instance; }
        }

        public new SoalSyntaxFactory SyntaxFactory
        {
            get { return (SoalSyntaxFactory)base.SyntaxFactory; }
        }
    }
}

