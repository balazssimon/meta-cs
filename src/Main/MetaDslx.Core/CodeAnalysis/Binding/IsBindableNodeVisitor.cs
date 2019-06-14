using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class IsBindableNodeVisitor : SyntaxVisitor<bool>
    {
        private readonly BoundTree _boundTree;
        private int _position;
        private bool _isBindableRoot;

        public IsBindableNodeVisitor(BoundTree boundTree)
        {
            _boundTree = boundTree;
        }

        public void Initialize(int position, bool isBindableRoot)
        {
            _position = position;
            _isBindableRoot = isBindableRoot;
        }

        protected int Position => _position;

        protected bool IsBindableRoot => _isBindableRoot;

        protected BoundTree BoundTree => _boundTree;

        protected LanguageSyntaxTree SyntaxTree => _boundTree.SyntaxTree;

        protected Language Language => _boundTree.Language;

        protected LanguageCompilation Compilation => _boundTree.Compilation;

        protected bool InScript => _boundTree.InScript;
    }
}
