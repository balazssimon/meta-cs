using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using System.Diagnostics;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
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

        public override RedNode CreateRed(RedNode parent, int position, int index)
        {
            Debug.Assert(parent == null || parent is SyntaxNode, "parent must be a SyntaxNode");
            return this.CreateRed(parent as SyntaxNode, position);
        }

        public abstract SyntaxNode CreateRed(SyntaxNode parent, int position);
    }
}
