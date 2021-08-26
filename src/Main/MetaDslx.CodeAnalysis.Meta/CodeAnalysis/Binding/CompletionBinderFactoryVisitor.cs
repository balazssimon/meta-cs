using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class CompletionBinderFactoryVisitor : SyntaxVisitor
    {
        private readonly BinderFactory _factory;
        private readonly ArrayBuilder<(object, CompletionSearchFlags)> _results;
        private CompletionLookup _lookup;
        private SyntaxNode? _currentNode;

        public CompletionBinderFactoryVisitor(BinderFactory binderFactory)
        {
            _factory = binderFactory;
            _results = new ArrayBuilder<(object, CompletionSearchFlags)>();
        }

        protected Language Language => _factory.Language;

        protected LanguageCompilation Compilation => _factory.Compilation;

        protected LanguageSyntaxTree SyntaxTree => _factory.SyntaxTree;

        protected BuckStopsHereBinder BuckStopsHereBinder => _factory.BuckStopsHereBinder;

        protected bool InScript => _factory.InScript;

        protected BinderFactory BinderFactory => _factory;

        protected CompletionSearchFlags Search => _lookup.Search;

        protected TextSpan SearchSpan => _lookup.SearchSpan;

        protected int LeftPosition { get; set; }

        protected int RightPosition { get; set; }

        protected bool VisitChildren { get; set; }

        internal void Initialize(int position)
        {
            _results.Clear();
            _lookup = CompletionLookup.GetLookup(SyntaxTree, position);
        }

        protected CompletionSearchFlags GetOperation(ref int position, SyntaxNodeOrToken syntax, bool searchLeft, bool searchRight)
        {
            var result = CompletionSearchFlags.None;
            if (syntax.IsNull || syntax.IsMissing)
            {
                if (position >= _lookup.SearchSpan.Start && position <= _lookup.SearchSpan.End && _lookup.Search.HasFlag(CompletionSearchFlags.Insert)) result = CompletionSearchFlags.Insert;
            }
            else
            {
                var startPosition = position;
                var endPosition = position + syntax.FullWidth;
                var leftPosition = position + syntax.UnderlyingNode!.GetLeadingTriviaWidth();
                var rightPosition = endPosition - syntax.UnderlyingNode!.GetTrailingTriviaWidth();
                if (searchLeft && startPosition < rightPosition && rightPosition == _lookup.SearchSpan.Start && _lookup.Search.HasFlag(CompletionSearchFlags.ReplaceLeft)) result = CompletionSearchFlags.ReplaceLeft;
                if (searchRight && leftPosition < endPosition && leftPosition == _lookup.SearchSpan.End && _lookup.Search.HasFlag(CompletionSearchFlags.ReplaceRight)) result = CompletionSearchFlags.ReplaceRight;
                position += syntax.FullWidth;
            }
            return result;
        }

        protected void AddResults(SyntaxNode parent, SyntaxNodeOrToken syntax, CompletionSearchFlags operation, params SyntaxKind[] expectedKinds)
        {
            if (syntax.IsToken)
            {
                var syntaxFacts = Language.SyntaxFacts;
                foreach (var tokenKind in expectedKinds)
                {
                    if (syntaxFacts.IsFixedToken(tokenKind))
                    {
                        _results.Add((tokenKind, operation));
                    }
                }
                if (syntaxFacts.IsIdentifier(syntax.GetKind()))
                {
                    var binder = Compilation.GetBinder(syntax);
                    _results.Add((binder, operation));
                }
                return;
            }
            else if (syntax.IsNull)
            {
                var syntaxFacts = Language.SyntaxFacts;
                foreach (var tokenKind in expectedKinds)
                {
                    if (syntaxFacts.IsFixedToken(tokenKind))
                    {
                        _results.Add((tokenKind, operation));
                    }
                }
                return;
            }
            if (VisitChildren)
            {
                var node = syntax.AsNode();
                VisitCore(node);
            }
            else
            {
                VisitChildren = true;
                var node = syntax.AsNode();
                if (node != _currentNode)
                {
                    VisitCore(node);
                }
                VisitChildren = false;
            }
        }

        protected void VisitCore(SyntaxNode node)
        {
            ((LanguageSyntaxNode)node).Accept(this);
        }

        protected void VisitParent(SyntaxNode node)
        {
            _currentNode = node;
            if (node.Parent is not null)
            {
                VisitCore(node.Parent);
            }
        }

        public ImmutableArray<(object BinderOrTokenKind, CompletionSearchFlags Operation)> CollectBinders()
        {
            if (_lookup.Search == CompletionSearchFlags.None) return ImmutableArray<(object, CompletionSearchFlags)>.Empty;
            var parent = _lookup.LeftToken.Parent;
            if (parent is not null)
            {
                this.VisitChildren = false;
                this.LeftPosition = _lookup.SearchSpan.Start;
                this.RightPosition = _lookup.SearchSpan.End;
                this.Visit(parent);
            }
            parent = _lookup.RightToken.Parent;
            if (parent is not null)
            {
                this.VisitChildren = false;
                this.LeftPosition = _lookup.SearchSpan.Start;
                this.RightPosition = _lookup.SearchSpan.End;
                this.Visit(parent);
            }
            return _results.ToImmutable();
        }

    }
}
