using MetaDslx.CodeAnalysis.InternalUtilities;
using Microsoft.CodeAnalysis;
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
    public abstract class SyntaxLexer : AbstractLexer
    {
        private static readonly BufferedLexeme DefaultLexeme = new BufferedLexeme(SyntaxKind.None, string.Empty, null, null);

        private readonly InternalSyntaxFactory InternalSyntaxFactory;
        private readonly LanguageParseOptions _options;
        private List<(int position, LexerState? state)> _resetStack;
        private readonly Queue<BufferedLexeme> _buffer;
        private readonly TextKeyedCache<InternalSyntaxToken> _tokenCache = TextKeyedCache<InternalSyntaxToken>.GetInstance();
        private readonly TextKeyedCache<InternalSyntaxTrivia> _triviaCache = TextKeyedCache<InternalSyntaxTrivia>.GetInstance();
        private readonly CachingIdentityFactory<string, SyntaxKind> _keywordKindMap;
        internal const int MaxKeywordLength = 10;
        private readonly SyntaxListBuilder _leadingTriviaCache = new SyntaxListBuilder(10);
        private readonly SyntaxListBuilder _trailingTriviaCache = new SyntaxListBuilder(10);
        private int _position;
        private LexerState? _state;
        private DirectiveStack _directives;

        public SyntaxLexer(Language language, SourceText text, LanguageParseOptions options)
            : base(language, text)
        {
            InternalSyntaxFactory = language.InternalSyntaxFactory;
            _tokenCache = TextKeyedCache<InternalSyntaxToken>.GetInstance();
            _triviaCache = TextKeyedCache<InternalSyntaxTrivia>.GetInstance();
            _keywordKindMap = language.InternalSyntaxFactory.KeywordKindPool.Allocate();
            _options = options;
            _buffer = new Queue<BufferedLexeme>();
            _resetStack = new List<(int position, LexerState? state)>();
        }

        public DirectiveStack Directives => _directives;

        public LanguageParseOptions Options => _options;

        public int Position => _position;

        public LexerState? State => _state;

        protected virtual LexerStateManager? StateManager => null;

        public int MinLookahead => TextWindow.MinLookahead;

        public int MaxLookahead => TextWindow.MaxLookahead;

        public override void Dispose()
        {
            _keywordKindMap.Free();
            _triviaCache.Free();
            _tokenCache.Free();
            base.Dispose();
        }

        public void Reset()
        {
            if (_resetStack.Count == 0) throw new InvalidOperationException("There is no reset point saved. Call MarkResetPoint() before calling Reset().");
            var resetPoint = _resetStack[_resetStack.Count - 1];
            _resetStack.RemoveAt(_resetStack.Count - 1);
            this.ResetTo(resetPoint.position, resetPoint.state);
        }

        public void ResetTo(int position, LexerState? state)
        {
            TextWindow.ResetTo(position);
            StateManager?.InternalRestoreState(state);
            _position = position;
            _buffer.Clear();
        }

        public int MarkResetPoint()
        {
            _resetStack.Add((TextWindow.Position, StateManager?.State));
            return _resetStack.Count;
        }

        public void ReleaseResetPoint(int resetPoint)
        {
            if (resetPoint != _resetStack.Count) throw new ArgumentOutOfRangeException(nameof(resetPoint));
            if (_resetStack.Count > 0)
            {
                _resetStack.RemoveAt(_resetStack.Count - 1);
            }
        }

        public InternalSyntaxToken? Lex()
        {
            return this.LexSyntaxToken();
        }

        protected void StartLexeme()
        {
            TextWindow.Start();
            this.ClearErrors();
        }

        private BufferedLexeme NextLexeme()
        {
            if (_buffer.Count == 0)
            {
                this.StartLexeme();
                var lexeme = this.ScanLexeme();
                if (lexeme.kind != SyntaxKind.None)
                {
                    this.AppendLexeme(lexeme.kind, lexeme.cache);
                }
            }
            return _buffer.Count > 0 ? _buffer.Dequeue() : DefaultLexeme;
        }

        /// <summary>
        /// Scans a token or syntax trivia. End of line should be scanned as a separate trivia.
        /// </summary>
        /// <returns>The syntax kind of the token or trivia and whether to try to cache the result.</returns>
        protected abstract (SyntaxKind kind, bool cache) ScanLexeme();

        protected void AppendLexeme(SyntaxKind kind, bool cache)
        {
            var errors = GetAndClearErrors(0);
            object? textOrGreenNode = null;
            if (Language.SyntaxFacts.IsTrivia(kind))
            {
                textOrGreenNode = CreateTrivia(kind, cache);
            }
            else
            {
                if (cache) textOrGreenNode = CachedSyntaxToken(kind);
            }
            if (textOrGreenNode == null) textOrGreenNode = TextWindow.GetText(intern: cache);
            StateManager?.InternalChanged();
            _buffer.Enqueue(new BufferedLexeme(kind, textOrGreenNode, StateManager?.State, errors));
        }

        private InternalSyntaxToken? CachedSyntaxToken(SyntaxKind kind)
        {
            InternalSyntaxToken? token = null;
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
                token = LookupToken(kind, TextWindow.CharacterWindow, TextWindow.LexemeRelativeStart, width, hashCode);
                return token;
            }
            return token;
        }

        private InternalSyntaxTrivia CreateTrivia(SyntaxKind kind, bool cache)
        {
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
                        onlySpaces = false;
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
                if (cache && width < Language.SyntaxFacts.MaxCachedTokenSize)
                {
                    trivia = LookupTrivia(kind, TextWindow.CharacterWindow, TextWindow.LexemeRelativeStart, width, hashCode);
                }
                else
                {
                    trivia = this.CreateTrivia(kind, TextWindow.GetText(intern: cache));
                }
            }
            else
            {
                trivia = CreateTrivia(kind, TextWindow.GetText(intern: cache));
            }
            if (this.HasErrors)
            {
                trivia = trivia.WithDiagnosticsGreen(this.GetAndClearErrors(leadingTriviaWidth: 0));
            }
            return trivia;
        }

        private InternalSyntaxToken LexSyntaxToken()
        {
            _leadingTriviaCache.Clear();
            this.LexSyntaxTrivia(isTrailing: false, triviaList: _leadingTriviaCache);
            var leading = _leadingTriviaCache;

            var lexeme = this.NextLexeme();
            if (lexeme.Kind == SyntaxKind.None) return null;

            _trailingTriviaCache.Clear();
            this.LexSyntaxTrivia(isTrailing: true, triviaList: _trailingTriviaCache);
            var trailing = _trailingTriviaCache;

            var result = Create(lexeme, leading.ToListNode(), trailing.ToListNode());
            _state = lexeme.EndState;
            _position += result.FullWidth;
            return result;
        }

        private InternalSyntaxToken Create(BufferedLexeme lexeme, GreenNode leadingTrivia, GreenNode trailingTrivia)
        {
            var errors = lexeme.GetErrors(leadingTrivia?.FullWidth ?? 0);
            if (lexeme.IsToken)
            {
                return lexeme.Token.WithDiagnosticsGreen(errors);
            }
            Debug.Assert(lexeme.IsText);
            InternalSyntaxToken token;
            switch (lexeme.Kind.Switch())
            {
                case SyntaxKind.Eof:
                    token = leadingTrivia != null ? (InternalSyntaxToken)InternalSyntaxFactory.EndOfFile.WithLeadingTrivia(leadingTrivia) : InternalSyntaxFactory.EndOfFile;
                    break;
                case SyntaxKind.None:
                    token = InternalSyntaxFactory.BadToken(leadingTrivia, lexeme.Text, trailingTrivia);
                    break;
                default:
                    token = CreateToken(leadingTrivia, lexeme.Kind, lexeme.Text, trailingTrivia);
                    break;
            }
            if (errors != null)
            {
                token = token.WithDiagnosticsGreen(errors);
            }
            return token;
        }


        private void LexSyntaxTrivia(bool isTrailing, SyntaxListBuilder triviaList)
        {
            while (true)
            {
                var lexeme = this.NextLexeme();
                if (!lexeme.IsTrivia) return;
                triviaList.Add(lexeme.Trivia);
                if (isTrailing && (Language.SyntaxFacts.IsTriviaWithEndOfLine(lexeme.Kind) || Language.SyntaxFacts.IsTriviaWithEndOfLine(lexeme.Trivia))) return;
            }
        }

        protected abstract InternalSyntaxToken CreateToken(GreenNode? leadingTrivia, SyntaxKind kind, string text, GreenNode? trailingTrivia);

        protected abstract InternalSyntaxTrivia CreateTrivia(SyntaxKind kind, string text);

        protected bool TryGetKeywordKind(string key, out SyntaxKind kind)
        {
            if (key.Length > MaxKeywordLength)
            {
                kind = SyntaxKind.None;
                return false;
            }

            kind = _keywordKindMap.GetOrMakeValue(key);
            return kind != SyntaxKind.None;
        }

        private InternalSyntaxToken LookupToken(
            SyntaxKind kind,
            char[] textBuffer,
            int keyStart,
            int keyLength,
            int hashCode)
        {
            var value = _tokenCache.FindItem(textBuffer, keyStart, keyLength, hashCode);

            if (value == null)
            {
                value = this.CreateToken(null, kind, TextWindow.GetInternedText(), null);
                _tokenCache.AddItem(textBuffer, keyStart, keyLength, hashCode, value);
            }

            return value;
        }

        private InternalSyntaxTrivia LookupTrivia(
            SyntaxKind kind,
            char[] textBuffer,
            int keyStart,
            int keyLength,
            int hashCode)
        {
            var value = _triviaCache.FindItem(textBuffer, keyStart, keyLength, hashCode);

            if (value == null)
            {
                value = this.CreateTrivia(kind, false);
                _triviaCache.AddItem(textBuffer, keyStart, keyLength, hashCode, value);
            }

            return value;
        }

        private struct BufferedLexeme
        {
            public readonly SyntaxKind Kind;
            private readonly object TextOrGreenNode;
            public readonly LexerState? EndState;
            private readonly SyntaxDiagnosticInfo[]? Errors;

            public BufferedLexeme(SyntaxKind kind, object textOrGreenNode, LexerState? endState, SyntaxDiagnosticInfo[]? errors)
            {
                Kind = kind;
                TextOrGreenNode = textOrGreenNode;
                EndState = endState;
                Errors = errors;
            }

            public bool IsToken => TextOrGreenNode is InternalSyntaxToken;
            public bool IsTrivia => TextOrGreenNode is InternalSyntaxTrivia;
            public bool IsText => TextOrGreenNode is string;
            public InternalSyntaxToken? Token => TextOrGreenNode as InternalSyntaxToken;
            public InternalSyntaxTrivia? Trivia => TextOrGreenNode as InternalSyntaxTrivia;
            public string? Text => TextOrGreenNode as string;

            public SyntaxDiagnosticInfo[]? GetErrors(int leadingTriviaWidth)
            {
                if (Errors != null && Errors.Length > 0)
                {
                    if (leadingTriviaWidth > 0)
                    {
                        var array = new SyntaxDiagnosticInfo[Errors.Length];
                        for (int i = 0; i < Errors.Length; i++)
                        {
                            // fixup error positioning to account for leading trivia
                            array[i] = Errors[i].WithOffset(Errors[i].Offset + leadingTriviaWidth);
                        }
                        return array;
                    }
                    else
                    {
                        return Errors;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
