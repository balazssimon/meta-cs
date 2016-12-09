using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Core.Diagnostics;

namespace MetaDslx.Compiler.Core.Syntax.InternalSyntax
{
    public abstract class InternalSyntaxNode : GreenNode
    {
        protected InternalSyntaxNode(int kind, int fullWidth, DiagnosticInfo[] diagnostics, SyntaxAnnotation[] annotations) 
            : base(kind, fullWidth, diagnostics, annotations)
        {
        }

        public override bool IsNode
        {
            get { return true; }
        }
    }
}
