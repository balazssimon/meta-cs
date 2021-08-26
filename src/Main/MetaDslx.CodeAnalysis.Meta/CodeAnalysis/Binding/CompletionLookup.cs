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
        All = ReplaceLeft | ReplaceRight | Insert
    }

    public struct CompletionLookup
    {
        private SyntaxToken _leftToken;
        private SyntaxToken _rightToken;
        private TextSpan _searchSpan;
        private CompletionSearchFlags _search;

        private CompletionLookup(SyntaxToken leftToken, SyntaxToken rightToken, TextSpan searchSpan, CompletionSearchFlags search)
        {
            _leftToken = leftToken;
            _rightToken = rightToken;
            _searchSpan = searchSpan;
            _search = search;
        }

        public bool HasLeftToken => _leftToken.GetKind() != SyntaxKind.None;

        public SyntaxToken LeftToken => _leftToken;

        public bool HasRightToken => _rightToken.GetKind() != SyntaxKind.None;

        public SyntaxToken RightToken => _rightToken;

        public TextSpan SearchSpan => _searchSpan;

        public CompletionSearchFlags Search => _search;

        public static CompletionLookup GetLookup(LanguageSyntaxTree syntaxTree, int position)
        {
            var root = syntaxTree.GetRoot();
            if (root == null) return default;
            var token = root.FindToken(position, true);
            if (token.GetKind() == SyntaxKind.None) return default;
            SyntaxToken leftToken;
            SyntaxToken rightToken;
            TextSpan searchSpan;
            CompletionSearchFlags search;
            if (position <= token.Span.Start)
            {
                var prevToken = token.GetPreviousToken();
                searchSpan = TextSpan.FromBounds(prevToken.GetKind() == SyntaxKind.None ? token.FullSpan.Start : prevToken.Span.End, position);
                search = CompletionSearchFlags.Insert;
                if (position == searchSpan.Start) search |= CompletionSearchFlags.ReplaceLeft;
                if (position == searchSpan.End) search |= CompletionSearchFlags.ReplaceRight;
                leftToken = prevToken;
                rightToken = token;
            }
            else if (position >= token.Span.End)
            {
                var nextToken = token.GetNextToken();
                searchSpan = TextSpan.FromBounds(position, nextToken.GetKind() == SyntaxKind.None ? token.FullSpan.End : nextToken.Span.Start);
                search = CompletionSearchFlags.Insert;
                if (position == searchSpan.Start) search |= CompletionSearchFlags.ReplaceLeft;
                if (position == searchSpan.End) search |= CompletionSearchFlags.ReplaceRight;
                leftToken = token;
                rightToken = nextToken;
            }
            else
            {
                searchSpan = TextSpan.FromBounds(token.SpanStart, token.SpanStart);
                search = CompletionSearchFlags.ReplaceRight;
                leftToken = default;
                rightToken = token;
            }
            return new CompletionLookup(leftToken, rightToken, searchSpan, search);
        }
    }
}
