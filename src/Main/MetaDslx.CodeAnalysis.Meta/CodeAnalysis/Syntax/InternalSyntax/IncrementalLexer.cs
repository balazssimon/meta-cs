﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class IncrementalLexer : AbstractLexer
    {
        public const string IncrementalTokenAnnotationKind = "MetaDslx.IncementalToken";

        private readonly InternalSyntaxFactory InternalSyntaxFactory;
        private readonly IEnumerable<TextChangeRange> _changes;
        private readonly LanguageParseOptions _options;
        private readonly LexerCache _cache;
        private readonly Func<InternalSyntaxToken> _createCachedTokenFunction;
        private Func<InternalSyntaxTrivia> _createWhitespaceTriviaFunction;
        private DirectiveStack _directives;
        private LexerMode _mode;

        public IncrementalLexer(Language language, SourceText text, LanguageParseOptions options, IEnumerable<TextChangeRange> changes)
            : base(language, text)
        {
            InternalSyntaxFactory = language.InternalSyntaxFactory;
            _changes = changes;
            _cache = new LexerCache(language);
            _createCachedTokenFunction = this.CreateCachedToken;
        }


        public DirectiveStack Directives => _directives;

        public LanguageParseOptions Options => _options;

        public virtual void Reset(int position, DirectiveStack directives)
        {
            this.TextWindow.Reset(position);
            _directives = directives;
        }

        public InternalSyntaxToken Lex(ref LexerMode mode)
        {
            var result = Lex(mode);
            _mode = mode = this.SaveLexerMode();
            return result;
        }

        protected LexerMode SaveLexerMode()
        {
            return SaveLexerMode(_mode);
        }

        protected virtual LexerMode SaveLexerMode(LexerMode previousMode)
        {
            return _mode;
        }

        protected virtual void RestoreLexerMode(LexerMode mode)
        {
            _mode = mode;
        }

        public LexerMode Mode => _mode;

#if DEBUG
        internal static int TokensLexed;
#endif

        private InternalSyntaxToken Lex(LexerMode mode)
        {
#if DEBUG
            TokensLexed++;
#endif
            this.RestoreLexerMode(mode);
            return this.CachedSyntaxToken() ?? this.LexSyntaxToken();
        }

        private SyntaxListBuilder _leadingTriviaCache = new SyntaxListBuilder(10);
        private SyntaxListBuilder _trailingTriviaCache = new SyntaxListBuilder(10);

        private static int GetFullWidth(SyntaxListBuilder builder)
        {
            int width = 0;

            if (builder != null)
            {
                for (int i = 0; i < builder.Count; i++)
                {
                    width += builder[i].FullWidth;
                }
            }

            return width;
        }

        private InternalSyntaxToken LexSyntaxToken()
        {
            var startMode = _mode;

            _leadingTriviaCache.Clear();
            this.LexSyntaxTrivia(afterFirstToken: this.Position > 0, isTrailing: false, triviaList: _leadingTriviaCache);
            var leading = _leadingTriviaCache;

            var kind = this.ScanSyntaxToken();
            if (kind == SyntaxKind.None) return null;
            var errors = this.GetErrors(GetFullWidth(leading));
            var text = TextWindow.GetText(intern: false);

            _trailingTriviaCache.Clear();
            this.LexSyntaxTrivia(afterFirstToken: true, isTrailing: true, triviaList: _trailingTriviaCache);
            var trailing = _trailingTriviaCache;

            return Create(kind, text, leading.ToListNode(), trailing.ToListNode(), startMode, errors);
        }

        private InternalSyntaxToken CachedSyntaxToken()
        {
            InternalSyntaxToken token = null;
            if (this.QuickScanSyntaxToken())
            {
                var width = TextWindow.Width;
                if (width <= Language.SyntaxFacts.MaxCachedTokenSize)
                {
                    var start = TextWindow.LexemeRelativeStart;
                    int hashCode = Hash.FnvOffsetBias;
                    for (int i = 0; i < width; i++)
                    {
                        var ch = TextWindow.CharacterWindow[start + i];
                        hashCode = Hash.CombineFNVHash(hashCode, ch);
                    }
                    token = _cache.LookupToken(
                        TextWindow.CharacterWindow,
                        TextWindow.LexemeRelativeStart,
                        width,
                        hashCode,
                        _createCachedTokenFunction);
                    return token;
                }
            }
            return token;
        }

        protected virtual bool QuickScanSyntaxToken()
        {
            return false;
        }

        private InternalSyntaxToken Create(SyntaxKind kind, string text, GreenNode leadingTrivia, GreenNode trailingTrivia, LexerMode mode, SyntaxDiagnosticInfo[] errors)
        {
            InternalSyntaxToken token;
            switch (kind.Switch())
            {
                case SyntaxKind.Eof:
                    token = leadingTrivia != null ? (InternalSyntaxToken)InternalSyntaxFactory.EndOfFile.WithLeadingTrivia(leadingTrivia) : InternalSyntaxFactory.EndOfFile;
                    break;
                case SyntaxKind.None:
                    token = InternalSyntaxFactory.BadToken(leadingTrivia, text, trailingTrivia);
                    break;
                default:
                    token = CreateToken(leadingTrivia, kind, text, trailingTrivia);
                    break;
            }
            if (errors != null)
            {
                token = token.WithDiagnosticsGreen(errors);
            }
            if (mode != null)
            {
                token = token.WithAdditionalAnnotationsGreen(new SyntaxAnnotation(IncrementalTokenAnnotationKind, new IncrementalTokenAnnotation(mode)));
            }
            return token;
        }

        private InternalSyntaxToken CreateCachedToken()
        {
#if DEBUG
            var quickWidth = TextWindow.Width;
#endif
            this.Reset(TextWindow.LexemeStartPosition, this.Directives);
            var token = this.LexSyntaxToken();
#if DEBUG
            Debug.Assert(quickWidth == token.FullWidth);
#endif
            return token;
        }

        private void LexSyntaxTrivia(bool afterFirstToken, bool isTrailing, SyntaxListBuilder triviaList)
        {
            while (true)
            {
                var kind = this.ScanSyntaxTrivia(afterFirstToken, isTrailing);
                if (kind == SyntaxKind.None) return;
                var trivia = this.AddTrivia(kind, triviaList);
                if (isTrailing && (trivia.Text.EndsWith("\r") || trivia.Text.EndsWith("\n"))) return;
            }
        }

        private InternalSyntaxTrivia AddTrivia(SyntaxKind kind, SyntaxListBuilder list)
        {
            if (_createWhitespaceTriviaFunction == null)
            {
                _createWhitespaceTriviaFunction = this.CreateWhitespaceTrivia;
            }

            int hashCode = Hash.FnvOffsetBias;  // FNV base
            bool onlySpaces = true;
            bool onlyWhiteSpace = true;
            var width = TextWindow.Width;
            var start = TextWindow.LexemeRelativeStart;
            for (int i = 0; i < width; i++)
            {
                var ch = TextWindow.CharacterWindow[start + i];
                switch (ch)
                {
                    case '\t':       // Horizontal tab
                    case '\v':       // Vertical Tab
                    case '\f':       // Form-feed
                    case '\u001A':
                        onlySpaces = false;
                        goto case ' ';

                    case ' ':
                        hashCode = Hash.CombineFNVHash(hashCode, ch);
                        break;

                    case '\r':      // Carriage Return
                    case '\n':      // Line-feed
                        break;

                    default:
                        if (ch > 127 && char.IsWhiteSpace(ch))
                        {
                            goto case '\t';
                        }
                        else
                        {
                            onlySpaces = false;
                            onlyWhiteSpace = false;
                            i = width;
                        }
                        break;
                }

            }

            InternalSyntaxTrivia trivia;
            if (width == 1 && onlySpaces)
            {
                trivia = InternalSyntaxFactory.Space;
            }
            else if (onlyWhiteSpace)
            {
                if (width < Language.SyntaxFacts.MaxCachedTokenSize)
                {
                    trivia = _cache.LookupTrivia(
                        TextWindow.CharacterWindow,
                        TextWindow.LexemeRelativeStart,
                        width,
                        hashCode,
                        _createWhitespaceTriviaFunction);
                }
                else
                {
                    trivia = _createWhitespaceTriviaFunction();
                }
            }
            else
            {
                trivia = CreateTrivia(kind, TextWindow.GetText(intern: false));
            }
            if (this.HasErrors)
            {
                trivia = trivia.WithDiagnosticsGreen(this.GetErrors(leadingTriviaWidth: 0));
            }
            list.Add(trivia);
            return trivia;
        }

        private InternalSyntaxTrivia CreateWhitespaceTrivia()
        {
            return InternalSyntaxFactory.Whitespace(TextWindow.GetText(intern: true));
        }

        /// <summary>
        /// Scans a syntax token.
        /// </summary>
        /// <returns>The syntax kind of the token.</returns>
        protected abstract SyntaxKind ScanSyntaxToken();

        protected abstract InternalSyntaxToken CreateToken(GreenNode leadingTrivia, SyntaxKind kind, string text, GreenNode trailingTrivia);

        /// <summary>
        /// Scans a syntax trivia. End of line should be scanned as a separate trivia.
        /// </summary>
        /// <returns>The syntax kind of the trivia.</returns>
        protected abstract SyntaxKind ScanSyntaxTrivia(bool afterFirstToken, bool isTrailing);

        protected abstract InternalSyntaxTrivia CreateTrivia(SyntaxKind kind, string text);

        public static IncrementalTokenAnnotation GetTokenAnnotation(GreenNode node)
        {
            if (node == null) return null;
            var annot = node.GetAnnotations(IncrementalLexer.IncrementalTokenAnnotationKind).FirstOrDefault();
            return annot?.ObjectData as IncrementalTokenAnnotation;
        }
    }
}
