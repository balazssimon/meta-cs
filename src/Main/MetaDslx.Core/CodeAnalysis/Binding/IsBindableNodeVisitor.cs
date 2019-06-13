using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class IsBindableNodeVisitor : SyntaxVisitor<bool>
    {
        private readonly BoundTree _boundTree;
        private int _position;

        public IsBindableNodeVisitor(BoundTree boundTree)
        {
            _boundTree = boundTree;
        }

        public void Initialize(int position)
        {
            _position = position;
        }

        protected int Position => _position;

        protected BoundTree BoundTree => _boundTree;

        protected LanguageSyntaxTree SyntaxTree => _boundTree.SyntaxTree;

        protected Language Language => _boundTree.Language;

        protected LanguageCompilation Compilation => _boundTree.Compilation;

        protected bool InScript => _boundTree.InScript;
    }
}
