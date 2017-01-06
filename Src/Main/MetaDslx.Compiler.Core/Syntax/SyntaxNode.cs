using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using System.Diagnostics;
using System.Threading;

namespace MetaDslx.Compiler.Syntax
{
    public abstract class SyntaxNode : RedNode
    {
        private SyntaxTree _syntaxTree;

        protected SyntaxNode(InternalSyntaxNode green, SyntaxTree syntaxTree, int position) 
            : base(green, null, position)
        {
            Debug.Assert(syntaxTree != null, "syntaxTree cannot be null");

            this._syntaxTree = syntaxTree;
        }

        protected SyntaxNode(InternalSyntaxNode green, SyntaxNode parent, int position) 
            : base(green, parent, position)
        {
            Debug.Assert(parent != null, "parent cannot be null");
        }

        internal InternalSyntaxNode GreenNode
        {
            get { return (InternalSyntaxNode)this.Green; }
        }

        public override SyntaxTree SyntaxTree 
        {
            get
            {
                if (this._syntaxTree != null) return this._syntaxTree;
                Interlocked.CompareExchange(ref this._syntaxTree, this.Parent?.SyntaxTree, null);
                return this._syntaxTree;
            }
        }

        public SyntaxNode WithAnnotations(params SyntaxAnnotation[] annotations)
        {
            return (SyntaxNode)((InternalSyntaxNode)this.Green.WithAnnotations(annotations)).CreateRed();
        }

        public abstract TResult Accept<TResult>(SyntaxVisitor<TResult> visitor);

        public abstract void Accept(SyntaxVisitor visitor);

    }
}
