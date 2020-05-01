using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class IncrementalAntlr4Lexer : IncrementalLexer, IAntlr4Lexer, ITokenStream
    {
        private readonly IncrementalAntlr4InputStream _stream;
        private readonly Antlr4.Runtime.Lexer _lexer;
        private readonly List<IToken> _tokens;
        private readonly List<InternalSyntaxToken> _roslynTokens;
        private readonly SyntaxFacts _syntaxFacts;
        private bool _fetchedEof;
        private int _index;
        private bool _readNextToken;

        public IncrementalAntlr4Lexer(Language language, SourceText text, LanguageParseOptions options, IEnumerable<TextChangeRange> changes) 
            : base(language, text, options, changes)
        {
            _stream = new IncrementalAntlr4InputStream(this.TextWindow);
            _lexer = ((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Lexer(_stream);
            _lexer.TokenFactory = new IncrementalTokenFactory();
            _tokens = new List<IToken>();
            _roslynTokens = new List<InternalSyntaxToken>();
            _index = 0;
            _fetchedEof = false;
            _syntaxFacts = Language.SyntaxFacts;
            _readNextToken = true;
            ITokenFactory tf;
        }

        Antlr4.Runtime.Lexer IAntlr4Lexer.Antlr4Lexer => _lexer;

        ITokenSource ITokenStream.TokenSource => _lexer;

        int IIntStream.Index => _index;

        int IIntStream.Size
        {
            get
            {
                FetchAllTokens();
                return _tokens.Count;
            }
        }

        string IIntStream.SourceName => _lexer.SourceName;

        protected override LexerMode SaveLexerMode(LexerMode previousMode)
        {
            var antlr4Mode = (Antlr4LexerMode)previousMode;
            if ((antlr4Mode == null && (_lexer._modeStack.Count != 0 || _lexer._mode != 0)) ||
                (antlr4Mode != null && antlr4Mode.HasChanged(this)))
            {
                if (_lexer._modeStack.Count == 0 && _lexer._mode == 0) return null;
                return new Antlr4LexerMode(this);
            }
            else
            {
                return previousMode;
            }
        }

        protected override void RestoreLexerMode(LexerMode mode)
        {
            if (mode != this.Mode)
            {
                var antlr4Mode = (Antlr4LexerMode)mode;
                _lexer._modeStack.Clear();
                if (antlr4Mode != null)
                {
                    _lexer._modeStack.AddRange(antlr4Mode.ModeStack);
                    _lexer._mode = antlr4Mode.Mode;
                }
                else
                {
                    _lexer._mode = 0;
                }
                _readNextToken = true;
            }
            base.RestoreLexerMode(mode);
        }

        private void EnsureTokensFetchedAtIndex(int index)
        {
            while (!_fetchedEof && index >= _tokens.Count) Fetch();
        }

        private void FetchAllTokens()
        {
            while (!_fetchedEof) Fetch();
        }

        private void Fetch()
        {
            if (_fetchedEof) return;
            var mode = this.Mode;
            var token = this.Lex(ref mode);
            _roslynTokens.Add(token);
            ((IncrementalToken)_tokens[_roslynTokens.Count - 1]).SetGreenToken(token);
        }

        private InternalSyntaxToken GetRoslynTokenAt(int index)
        {
            EnsureTokensFetchedAtIndex(index);
            if (index < 0 || index >= _roslynTokens.Count) return null;
            return _roslynTokens[index];
        }

        private IToken GetAntlr4TokenAt(int index)
        {
            EnsureTokensFetchedAtIndex(index);
            if (index < 0 || index >= _tokens.Count) return null;
            return _tokens[index];
        }

        protected override SyntaxKind ScanSyntaxToken()
        {
            if (_fetchedEof) return SyntaxKind.None;
            IToken token;
            if (_readNextToken)
            {
                this.Start();
                token = _lexer.NextToken();
            }
            else
            {
                token = _lexer.Token;
            }
            if (token == null) return SyntaxKind.None;
            if (token.Type == -1)
            {
                _tokens.Add(token);
                _fetchedEof = true;
                return SyntaxKind.Eof;
            }
            var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
            if (token.Channel == 0)
            {
                _tokens.Add(token);
                _readNextToken = true;
                return kind;
            }
            else
            {
                _readNextToken = false;
                return SyntaxKind.None;
            }
        }

        protected override SyntaxKind ScanSyntaxTrivia(bool afterFirstToken, bool isTrailing)
        {
            if (_fetchedEof) return SyntaxKind.None;
            IToken token;
            if (_readNextToken)
            {
                this.Start();
                token = _lexer.NextToken();
            }
            else
            {
                token = _lexer.Token;
            }
            if (token == null || token.Type == -1) return SyntaxKind.None;
            var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
            if (token.Channel != 0)
            {
                _readNextToken = true;
                return kind;
            }
            else
            {
                _readNextToken = false;
                return SyntaxKind.None;
            }
        }

        void IIntStream.Consume()
        {
            ++_index;
        }

        int IIntStream.La(int i)
        {
            if (i > 0) return ((ITokenStream)this).Get(_index + i - 1)?.Type ?? -1;
            else if (i < 0) return ((ITokenStream)this).Get(_index + i)?.Type ?? -1;
            else return -1;
        }

        int IIntStream.Mark()
        {
            // do nothing: we have buffering
            return -1;
        }

        void IIntStream.Release(int marker)
        {
            // do nothing: we have buffering
        }

        void IIntStream.Seek(int index)
        {
            _index = index;
        }

        IToken ITokenStream.Lt(int k)
        {
            if (k > 0) return ((ITokenStream)this).Get(_index + k - 1);
            else if (k < 0) return ((ITokenStream)this).Get(_index + k);
            else return null;
        }

        IToken ITokenStream.Get(int i)
        {
            return GetAntlr4TokenAt(i);
        }

        string ITokenStream.GetText(Interval interval)
        {
            var start = interval.a;
            var stop = interval.b;
            return GetText(start, stop);
        }

        string ITokenStream.GetText()
        {
            return this.TextWindow.Text.ToString();
        }

        string ITokenStream.GetText(RuleContext ctx)
        {
            var start = ctx.SourceInterval.a;
            var stop = ctx.SourceInterval.b;
            return GetText(start, stop);
        }

        string ITokenStream.GetText(IToken startToken, IToken stopToken)
        {
            var start = _tokens.IndexOf(startToken);
            var stop = _tokens.IndexOf(stopToken);
            return GetText(start, stop);
        }

        private string GetText(int start, int stop)
        {
            if (start >= 0 && start <= stop) return this.TextWindow.Text.GetSubText(new TextSpan(start, stop - start + 1)).ToString();
            else return null;
        }
    }
}
