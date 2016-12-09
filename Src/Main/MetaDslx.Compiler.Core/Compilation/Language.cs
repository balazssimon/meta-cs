using MetaDslx.Compiler.Core.Syntax;
using MetaDslx.Compiler.Core.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Core
{
    public abstract class Language
    {
        internal static readonly Language Default = new DefaultLanguage();

        public abstract string Name { get; }
        public abstract SyntaxFacts SyntaxFacts { get; }
        public abstract SyntaxFactory SyntaxFactory { get; }
        public abstract InternalSyntaxFactory InternalSyntaxFactory { get; }
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

        public override SyntaxFacts SyntaxFacts
        {
            get
            {
                return SyntaxFacts.Default;
            }
        }

        public override SyntaxFactory SyntaxFactory
        {
            get
            {
                return SyntaxFactory.Default;
            }
        }

        public override InternalSyntaxFactory InternalSyntaxFactory
        {
            get
            {
                return InternalSyntaxFactory.Default;
            }
        }
    }
}
