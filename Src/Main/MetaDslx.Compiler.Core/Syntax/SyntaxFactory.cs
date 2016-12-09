using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Core.Syntax
{
    public abstract class SyntaxFactory
    {
        internal static SyntaxFactory Default = new DefaultSyntaxFactory();

    }

    internal class DefaultSyntaxFactory : SyntaxFactory
    {

    }
}
