using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class MemberBoundTree : BoundTree
    {
        private BoundTree _parent;
        private LanguageSyntaxNode _root;

        public MemberBoundTree(BoundTree parent, LanguageSyntaxNode root, Binder rootBinder)
            : base(parent.Compilation, parent.SyntaxTree, rootBinder, parent.DiagnosticBag)
        {
            _parent = parent;
            _root = root;
        }

        public MemberBoundTree(LanguageCompilation compilation, LanguageSyntaxNode root, Binder rootBinder, DiagnosticBag diagnostics)
            : base(compilation, (LanguageSyntaxTree)root.SyntaxTree, rootBinder, diagnostics)
        {
            _parent = null;
            _root = root;
        }

        public BoundTree Parent => _parent;

        public override LanguageSyntaxNode Root => _root;


    }
}
