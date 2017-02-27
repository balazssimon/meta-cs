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
    public sealed class SoalLanguage : Language
    {
        internal const string LanguageName = "Soal";

        internal static readonly SoalLanguage Instance = new SoalLanguage();

        internal SoalLanguage()
        {
        }

        public override string Name
        {
            get { return SoalLanguage.LanguageName; }
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

        internal SoalGreenFactory InternalSyntaxFactory
        {
            get { return (SoalGreenFactory)this.InternalSyntaxFactoryCore; }
        }

        protected override SyntaxFactory SyntaxFactoryCore
        {
            get { return SoalSyntaxFactory.Instance; }
        }

        public new SoalSyntaxFactory SyntaxFactory
        {
            get { return (SoalSyntaxFactory)base.SyntaxFactory; }
        }

        protected override CompilationFactory CompilationFactoryCore
        {
            get { return SoalCompilationFactory.Instance; }
        }

        internal SoalCompilationFactory CompilationFactory
        {
            get { return (SoalCompilationFactory)this.CompilationFactoryCore; }
        }
    }
}

