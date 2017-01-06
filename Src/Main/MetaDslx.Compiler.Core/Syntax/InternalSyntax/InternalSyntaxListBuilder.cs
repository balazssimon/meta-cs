using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    public sealed class InternalTokenListBuilder
    {
        public InternalTokenListBuilder(int size)
        {

        }

        public InternalTokenList ToList()
        {
            return null;
        }
    }

    public sealed class InternalTriviaListBuilder
    {
        public InternalTriviaListBuilder(int size)
        {

        }

        public InternalTriviaList ToList()
        {
            return null;
        }
    }


    public sealed class InternalNodeListBuilder<TNode>
        where TNode : InternalSyntaxNode
    {
        public InternalNodeListBuilder(int size)
        {

        }

        public InternalNodeList ToList(bool weak = false)
        {
            return null;
        }
    }

    public sealed class InternalSeparatedNodeListBuilder<TNode>
        where TNode : InternalSyntaxNode
    {
        public InternalSeparatedNodeListBuilder(int size)
        {

        }

        public InternalSeparatedNodeList ToList(bool weak = false)
        {
            return null;
        }
    }
}
