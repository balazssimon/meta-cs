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

        protected SyntaxFactory SyntaxFactory => Language.SyntaxFactory;

        protected CompletionSearchFlags Search => _lookup.Search;

        protected TextSpan Span => _lookup.Span;

        protected TextSpan FullSpan => _lookup.FullSpan;

        protected TextSpan LeftSpan => _lookup.LeftToken.Span;

        protected TextSpan RightSpan => _lookup.RightToken.Span;

        protected TextSpan InsertionSpan => TextSpan.FromBounds(_position, _position);

        internal void Initialize(int position)
        {
            _results.Clear();
            _position = position;
            _lookup = CompletionLookup.GetLookup(SyntaxTree, _position);
        }

        protected CompletionSearchFlags GetOperation(int position, SyntaxNode? syntax)
        {
            if (syntax is null || syntax.IsMissing || syntax.GetKind() == SyntaxKind.List)
            {
                return GetOperation(position, null, TextSpan.FromBounds(position, position));
            }
            else
            {
                return GetOperation(position, syntax.Green, syntax.FullSpan);
            }

        }

        protected CompletionSearchFlags GetOperation(int position, SyntaxToken syntax)
        {
            if (syntax.IsMissing || syntax.GetKind() == SyntaxKind.None)
            {
                return GetOperation(position, null, TextSpan.FromBounds(position, position));
            }
            else
            {
                return GetOperation(position, syntax.Node, syntax.FullSpan);
            }
        }

        protected CompletionSearchFlags GetOperation(int position, SyntaxNodeOrToken syntax)
        {
            if (syntax.IsMissing || syntax.GetKind() == SyntaxKind.None)
            {
                return GetOperation(position, null, TextSpan.FromBounds(position, position));
            }
            else
            {
                return GetOperation(position, syntax.UnderlyingNode, syntax.FullSpan);
            }
        }

        private CompletionSearchFlags GetOperation(int position, GreenNode? syntax, TextSpan fullSpan)
        {
            var result = CompletionSearchFlags.None;
            if (syntax is null)
            {
                if (position >= _lookup.FullSpan.Start && position <= _lookup.FullSpan.End && _lookup.Search.HasFlag(CompletionSearchFlags.Insert)) result = CompletionSearchFlags.Insert;
            }
            else
            {
                var startPosition = position;
                var endPosition = position + syntax.FullWidth;
                var leftPosition = position + syntax.GetLeadingTriviaWidth();
                var rightPosition = endPosition - syntax.GetTrailingTriviaWidth();
                if (startPosition < rightPosition && rightPosition == _lookup.Span.Start && _lookup.Search.HasFlag(CompletionSearchFlags.ReplaceLeft)) result = CompletionSearchFlags.ReplaceLeft;
                if (leftPosition < endPosition && leftPosition == _lookup.Span.End && _lookup.Search.HasFlag(CompletionSearchFlags.ReplaceRight)) result = CompletionSearchFlags.ReplaceRight;
                if (fullSpan.IntersectsWith(Span) && result == CompletionSearchFlags.None)
                {
                    return CompletionSearchFlags.StepInto;
                }
            }
            return result;
        }

        protected void AddBinder(Binder binder, SyntaxKind tokenKind, CompletionSearchFlags operation)
        {
            var span = GetOperationSpan(operation);
            if (Language.SyntaxFacts.IsFixedToken(tokenKind))
            {
                _results.Add((tokenKind, span));
            }
            else if (binder.IsValidCompletionBinder)
            {
                _results.Add((binder, span));
            }
        }

        protected void AddBinder(SyntaxNodeOrToken syntax, CompletionSearchFlags operation)
        {
            if (syntax.IsToken)
            {
                var token = syntax.AsToken();
                if (_lookup.HasLeftToken && token == _lookup.LeftToken) return;
                if (_lookup.HasRightToken && token == _lookup.RightToken) return;
            }
            var span = GetOperationSpan(operation);
            var tokenKind = syntax.GetKind();
            if (Language.SyntaxFacts.IsFixedToken(tokenKind))
            {
                _results.Add((tokenKind, span));
            }
            else 
            {
                var binder = Compilation.GetBinder(syntax);
                if (binder.IsValidCompletionBinder)
                {
                    _results.Add((binder, span));
                }
            }
        }

        protected TextSpan GetOperationSpan(CompletionSearchFlags operation)
        {
            if (operation == CompletionSearchFlags.ReplaceLeft) return LeftSpan;
            if (operation == CompletionSearchFlags.ReplaceRight) return RightSpan;
            return InsertionSpan;
        }

        protected void VisitCore(SyntaxNode node)
        {
            ((LanguageSyntaxNode)node).Accept(this);
        }

        protected void VisitParent(SyntaxNode node)
        {
            if (node.Parent is not null)
            {
                VisitCore(node.Parent);
            }
        }

        public ImmutableArray<(object BinderOrTokenKind, TextSpan TextSpan)> CollectBinders()
        {
            if (_lookup.Search == CompletionSearchFlags.None) return ImmutableArray<(object, TextSpan)>.Empty;
            VisitCore(_factory.SyntaxTree.GetRoot());
            return _results.ToImmutable();
        }

    }
}
