using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    public class SyntaxVisitor<TResult>
    {
        public virtual TResult Visit(SyntaxNode node)
        {
            if (node != null)
            {
                return node.Accept(this);
            }

            // should not come here too often so we will put this at the end of the method.
            return default(TResult);
        }

        protected virtual TResult DefaultVisit(SyntaxNode node)
        {
            return default(TResult);
        }
    }

    public class SyntaxVisitor
    {
        public virtual void Visit(SyntaxNode node)
        {
            if (node != null)
            {
                node.Accept(this);
            }
        }

        public virtual void DefaultVisit(SyntaxNode node)
        {
        }
    }
}
