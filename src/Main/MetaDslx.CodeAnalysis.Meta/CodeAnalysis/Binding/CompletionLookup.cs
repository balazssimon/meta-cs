using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    [Flags]
    public enum CompletionSearchFlags
    {
        None,
        ReplaceLeft = 1,
        ReplaceRight = 2,
        Insert = 4,
        StepInto = 8,
        All = ReplaceLeft | ReplaceRight | Insert
    }

    public struct CompletionLookup
    {
        private SyntaxToken _leftToken;
        private SyntaxToken _rightToken;
        private TextSpan _fullSpan;
        private TextSpan _span;
        private CompletionSearchFlags _search;

        private CompletionLookup(SyntaxToken leftToken, SyntaxToken rightToken, TextSpan fullSpan, TextSpan span, CompletionSearchFlags search)
        {
            _leftToken = leftToken;
            _rightToken = rightToken;
            _fullSpan = fullSpan;
            _span = span;
            _search = search;
        }

        public bool HasLeftToken => _leftToken.GetKind() != SyntaxKind.None;

        public SyntaxToken LeftToken => _leftToken;

        public bool HasRightToken => _rightToken.GetKind() != SyntaxKind.None;

        public SyntaxToken RightToken => _rightToken;

        public TextSpan Span => _span;

        public TextSpan FullSpan => _fullSpan;

        public CompletionSearchFlags Search => _search;

        public static CompletionLookup GetLookup(LanguageSyntaxTree syntaxTree, int position)
        {
            var root = syntaxTree.GetRoot();
            if (root == null) return default;
            var token = root.FindToken(position, true);
            if (token.GetKind() == SyntaxKind.None) return default;
            var prevFullToken = token.GetPreviousToken();
            var nextFullToken = token.GetNextToken();
            //var fullSpan = TextSpan.FromBounds(
            //    prevFullToken.GetKind() == SyntaxKind.None ? token.FullSpan.Start : prevFullToken.Span.End,
            //    nextFullToken.GetKind() == SyntaxKind.None ? token.FullSpan.End : nextFullToken.Span.Start);
            SyntaxToken leftToken;
            SyntaxToken rightToken;
            TextSpan span;
            CompletionSearchFlags search;
            if (position <= token.Span.Start)
            {
                var prevToken = token.GetPreviousToken(includeZeroWidth: true, includeSkipped: true, includeDirectives: true, includeDocumentationComments: true);
                span = TextSpan.FromBounds(prevToken.GetKind() == SyntaxKind.None ? token.FullSpan.Start : prevToken.Span.End, position);
                search = CompletionSearchFlags.Insert;
                if (position == span.Start) search |= CompletionSearchFlags.ReplaceLeft;
                if (position == span.End) search |= CompletionSearchFlags.ReplaceRight;
                leftToken = prevToken;
                rightToken = token;
            }
            else if (position >= token.Span.End)
            {
                var nextToken = token.GetNextToken(includeZeroWidth: true, includeSkipped: true, includeDirectives: true, includeDocumentationComments: true);
                span = TextSpan.FromBounds(position, nextToken.GetKind() == SyntaxKind.None ? token.FullSpan.End : nextToken.Span.Start);
                search = CompletionSearchFlags.Insert;
                if (position == span.Start) search |= CompletionSearchFlags.ReplaceLeft;
                if (position == span.End) search |= CompletionSearchFlags.ReplaceRight;
                leftToken = token;
                rightToken = nextToken;
            }
            else
            {
                span = TextSpan.FromBounds(token.SpanStart, token.SpanStart);
                search = CompletionSearchFlags.ReplaceRight;
                leftToken = default;
                rightToken = token;
            }
            var fullSpan = span;
            return new CompletionLookup(leftToken, rightToken, fullSpan, span, search);
        }
    }
}
