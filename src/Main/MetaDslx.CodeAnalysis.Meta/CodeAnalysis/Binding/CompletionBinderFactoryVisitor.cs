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
        private readonly ArrayBuilder<(object, TextSpan)> _results;
        private int _position;
        private CompletionLookup _lookup;
        private SyntaxNode? _currentNode;

        public CompletionBinderFactoryVisitor(BinderFactory binderFactory)
        {
            _factory = binderFactory;
            _results = new ArrayBuilder<(object, TextSpan)>();
        }

        protected Language Language => _factory.Language;

        protected LanguageCompilation Compilation => _factory.Compilation;

        protected LanguageSyntaxTree SyntaxTree => _factory.SyntaxTree;

        protected BuckStopsHereBinder BuckStopsHereBinder => _factory.BuckStopsHereBinder;

        protected bool InScript => _factory.InScript;

        protected BinderFactory BinderFactory => _factory;

        protected CompletionSearchFlags Search => _lookup.Search;

        protected TextSpan SearchSpan => _lookup.SearchSpan;

        protected TextSpan LeftSpan => _lookup.LeftToken.Span;

        protected TextSpan RightSpan => _lookup.RightToken.Span;

        protected TextSpan InsertionSpan => TextSpan.FromBounds(_position, _position);

        protected int LeftPosition { get; set; }

        protected int RightPosition { get; set; }

        protected bool VisitChildren { get; set; }

        internal void Initialize(int position)
        {
            _results.Clear();
            _position = position;
            _lookup = CompletionLookup.GetLookup(SyntaxTree, _position);
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

        protected TextSpan GetOperationSpan(CompletionSearchFlags operation)
        {
            if (operation == CompletionSearchFlags.ReplaceLeft) return LeftSpan;
            if (operation == CompletionSearchFlags.ReplaceRight) return RightSpan;
            return InsertionSpan;
        }

        protected void AddResults(SyntaxNode parent, SyntaxNodeOrToken syntax, CompletionSearchFlags operation, params SyntaxKind[] expectedKinds)
        {
            var span = GetOperationSpan(operation);
            if (syntax.IsToken)
            {
                bool hasResult = false;
                var syntaxFacts = Language.SyntaxFacts;
                foreach (var tokenKind in expectedKinds)
                {
                    if (syntaxFacts.IsFixedToken(tokenKind))
                    {
                        _results.Add((tokenKind, span));
                        hasResult = true;
                    }
                }
                if (syntaxFacts.IsIdentifier(syntax.GetKind()))
                {
                    var binder = Compilation.GetBinder(syntax);
                    _results.Add((binder, span));
                    hasResult = true;
                }
                if (!hasResult)
                {
                    var binder = Compilation.GetBinder(parent);
                    _results.Add((binder, span));
                }
                return;
            }
            else if (syntax.IsNull)
            {
                bool hasResult = false;
                var syntaxFacts = Language.SyntaxFacts;
                foreach (var tokenKind in expectedKinds)
                {
                    if (syntaxFacts.IsFixedToken(tokenKind))
                    {
                        _results.Add((tokenKind, span));
                        hasResult = true;
                    }
                }
                if (!hasResult)
                {
                    var binder = Compilation.GetBinder(parent);
                    _results.Add((binder, span));
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

        public ImmutableArray<(object BinderOrTokenKind, TextSpan TextSpan)> CollectBinders()
        {
            if (_lookup.Search == CompletionSearchFlags.None) return ImmutableArray<(object, TextSpan)>.Empty;
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
