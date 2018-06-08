using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding
{
    public class BoundNodeFactoryVisitor : SyntaxVisitor<BoundNode>
    {
        private readonly BoundTree _boundTree;
        private int _position;
        private bool _bindChild;

        public BoundNodeFactoryVisitor(BoundTree boundTree)
        {
            _boundTree = boundTree;
        }

        public BoundTree BoundTree
        {
            get { return _boundTree; }
        }

        public CompilationBase Compilation
        {
            get { return _boundTree.Compilation; }
        }

        public SyntaxTree SyntaxTree
        {
            get { return _boundTree.SyntaxTree; }
        }

        public int Position
        {
            get { return _position; }
        }

        public bool BindChild
        {
            get { return _bindChild; }
        }

        internal void Reset(int position, bool bindChild)
        {
            _position = position;
            _bindChild = bindChild;
        }

        protected override BoundNode DefaultVisit(SyntaxNode node)
        {
            return null;
        }
    }
}
