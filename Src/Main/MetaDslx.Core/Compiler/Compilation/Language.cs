using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public abstract class Language
    {
        internal static readonly Language Default = new DefaultLanguage();

        public abstract string Name { get; }
        public SyntaxFacts SyntaxFacts { get { return this.SyntaxFactsCore; } }
        protected abstract SyntaxFacts SyntaxFactsCore { get; }
        public SyntaxFactory SyntaxFactory { get { return this.SyntaxFactoryCore; } }
        protected abstract SyntaxFactory SyntaxFactoryCore { get; }
        public InternalSyntaxFactory InternalSyntaxFactory { get { return this.InternalSyntaxFactoryCore; } }
        protected abstract InternalSyntaxFactory InternalSyntaxFactoryCore { get; }
        public CompilationFactory CompilationFactory { get { return this.CompilationFactoryCore; } }
        protected abstract CompilationFactory CompilationFactoryCore { get; }
    }

    internal class DefaultLanguage : Language
    {
        public override string Name
        {
            get
            {
                return "Default";
            }
        }

        protected override SyntaxFacts SyntaxFactsCore
        {
            get
            {
                return SyntaxFacts.Default;
            }
        }

        protected override SyntaxFactory SyntaxFactoryCore
        {
            get
            {
                return SyntaxFactory.Default;
            }
        }

        protected override InternalSyntaxFactory InternalSyntaxFactoryCore
        {
            get
            {
                return InternalSyntaxFactory.Default;
            }
        }

        protected override CompilationFactory CompilationFactoryCore
        {
            get
            {
                return CompilationFactory.Default;
            }
        }
    }
}
