using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Languages.Calculator.Syntax.InternalSyntax;
using MetaDslx.Languages.Calculator.Syntax;

namespace MetaDslx.Languages.Calculator
{
    public class CalculatorLanguage : Language
    {
        public const string LanguageName = "Calculator";

        public static readonly CalculatorLanguage Instance = new CalculatorLanguage();

        private CalculatorLanguage()
        {
        }

        public override string Name
        {
            get { return CalculatorLanguage.LanguageName; }
        }

        protected override SyntaxFacts SyntaxFactsCore
        {
            get { return CalculatorSyntaxFacts.Instance; }
        }

        public new CalculatorSyntaxFacts SyntaxFacts
        {
            get { return (CalculatorSyntaxFacts)base.SyntaxFacts; }
        }

        protected override InternalSyntaxFactory InternalSyntaxFactoryCore
        {
            get { return CalculatorGreenFactory.Instance; }
        }

        internal CalculatorGreenFactory InternalSyntaxFactory
        {
            get { return (CalculatorGreenFactory)this.InternalSyntaxFactoryCore; }
        }

        protected override SyntaxFactory SyntaxFactoryCore
        {
            get { return CalculatorSyntaxFactory.Instance; }
        }

        public new CalculatorSyntaxFactory SyntaxFactory
        {
            get { return (CalculatorSyntaxFactory)base.SyntaxFactory; }
        }

        protected override CompilationFactory CompilationFactoryCore
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

