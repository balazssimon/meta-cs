using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BoundNodeFactoryVisitor : SyntaxVisitor<BoundNode>
    {
        private readonly BoundTree _boundTree;
        private int _position;
        private Binder _binder;

        public BoundNodeFactoryVisitor(BoundTree boundTree)
        {
            _boundTree = boundTree;
        }

        public void Initialize(int position, Binder binder)
        {
            _position = position;
            _binder = binder;
        }

        protected int Position => _position;

        protected Binder Binder => _binder;

        protected BoundTree BoundTree => _boundTree;

        protected LanguageSyntaxTree SyntaxTree => _boundTree.SyntaxTree;

        protected Language Language => _boundTree.Language;

        protected LanguageCompilation Compilation => _boundTree.Compilation;

        protected bool InScript => _boundTree.InScript;

        protected DiagnosticBag DiagnosticBag => _boundTree.DiagnosticBag;

        // TODO:MetaDslx - Visit should create BoundNodes and add them to NodeMap
    }
}
