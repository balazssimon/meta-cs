using MetaDslx.Compiler.Core.Diagnostics;
using MetaDslx.Compiler.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Core.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxFactory
    {
        internal static readonly InternalSyntaxFactory Default = new DefaultInternalSyntaxFactory();

        public abstract InternalSyntaxList List(int kind, GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations);
    }

    internal class DefaultInternalSyntaxFactory : InternalSyntaxFactory
    {
        public override InternalSyntaxList List(int kind, GreenNode[] children, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}
