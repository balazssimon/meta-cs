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
        private BoundNodeFactoryState _state;

        public IsBindableNodeVisitor(BoundTree boundTree)
        {
            _boundTree = boundTree;
        }

        public void Initialize(int position, bool isBindableRoot, BoundNodeFactoryState state)
        {
            _position = position;
            _isBindableRoot = isBindableRoot;
            _state = state;
        }

        protected int Position => _position;

        protected LanguageSyntaxTree SyntaxTree => _boundTree.SyntaxTree;

        protected Language Language => _boundTree.Language;

        protected LanguageCompilation Compilation => _boundTree.Compilation;

        protected bool InScript => _boundTree.InScript;

        protected bool IsBindableRott => _isBindableRoot;

        protected BoundNodeFactoryState State
        {
            get { return _state; }
            set { _state = value; }
        }

    }
}
