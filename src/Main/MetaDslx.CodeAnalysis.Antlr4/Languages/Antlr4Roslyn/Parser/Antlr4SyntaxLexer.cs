using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
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
    public abstract class Antlr4SyntaxLexer : SyntaxLexer, IAntlr4Lexer, IAntlrErrorListener<int>
    {
        private readonly Antlr4InputStream _stream;
        private readonly Antlr4.Runtime.Lexer _lexer;
        private readonly SyntaxFacts _syntaxFacts;
        private bool _readNextToken;
        private int _position;
        private Antlr4LexerMode _lastReadMode;
        private Antlr4LexerMode _currentMode;

        public Antlr4SyntaxLexer(Language language, SourceText text, LanguageParseOptions options) 
            : base(language, text, options)
        {
            _stream = new Antlr4InputStream(this.TextWindow);
            _lexer = ((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Lexer(_stream);
            _lexer.TokenFactory = new IncrementalTokenFactory();
            _lexer.RemoveErrorListeners();
            _lexer.AddErrorListener(this);
            _syntaxFacts = Language.SyntaxFacts;
            _readNextToken = true;
        }

        public Antlr4.Runtime.Lexer Antlr4Lexer => _lexer;

        public override int Position => _position;

        internal Antlr4InputStream InputStream => _stream;

        public override void Reset(int position, DirectiveStack directives)
        {
            base.Reset(position, directives);
            _position = position;
        }

        protected sealed override bool HasLexerModeChanged(LexerMode previousMode)
        {
            if (_currentMode == null) return previousMode == null;
            return !_currentMode.Equals(previousMode);
        }

        protected sealed override LexerMode CreateLexerModeSnapshot()
        {
            return _currentMode;
        }

        protected sealed override void RestoreLexerMode(LexerMode mode)
        {
            //if (HasAntlr4LexerModeSnapshotChanged((Antlr4LexerMode)mode)) 
            this.RestoreAntlr4LexerMode((Antlr4LexerMode)mode);
        }

        protected virtual bool HasAntlr4LexerModeSnapshotChanged(Antlr4LexerMode previousMode)
        {
            var antlr4Mode = (Antlr4LexerMode)previousMode;
            if ((antlr4Mode == null && (_lexer._modeStack.Count != 0 || _lexer._mode != 0)) ||
                (antlr4Mode != null && antlr4Mode.HasChanged(this)))
            {
                if (_lexer._modeStack.Count == 0 && _lexer._mode == 0) return false;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual Antlr4LexerMode CreateAntlr4LexerModeSnapshot()
        {
            if (_lexer._modeStack.Count == 0 && _lexer._mode == 0) return null;
            return new Antlr4LexerMode(this);
        }

        protected virtual void RestoreAntlr4LexerMode(Antlr4LexerMode mode)
        {
            base.RestoreLexerMode(mode);
            _lexer.Reset();
            _lexer.InputStream.Seek(_position);
            _lexer._modeStack.Clear();
            if (mode != null)
            {
                _lexer._modeStack.AddRange(mode.ModeStack);
                _lexer._mode = mode.Mode;
            }
            else
            {
                _lexer._mode = 0;
            }
            _currentMode = mode;
            _lastReadMode = _currentMode;
            _readNextToken = true;
        }

        protected override SyntaxKind ScanSyntaxToken()
        {
            IToken token = ReadNextToken(false);
            if (token == null) return SyntaxKind.None;
            if (token.Type == -1) return SyntaxKind.Eof;
            var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
            return kind;
        }

        protected override SyntaxKind ScanSyntaxTrivia(bool afterFirstToken, bool isTrailing)
        {
            IToken token = ReadNextToken(true);
            if (token == null || token.Type == -1) return SyntaxKind.None;
            var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
            return kind;
        }

        private IToken ReadNextToken(bool readTrivia)
        {
            IToken token;
            RestoreAntlr4LexerMode(_currentMode);
            if (_readNextToken)
            {
                _readNextToken = false;
                this.Start();
                token = _lexer.NextToken();
                if (this.HasAntlr4LexerModeSnapshotChanged(_lastReadMode)) _lastReadMode = this.CreateAntlr4LexerModeSnapshot();
            }
            else
            {
                token = _lexer.Token;
            }
            if (token == null) return null;
            if ((readTrivia && token.Channel != 0) || (!readTrivia && token.Channel == 0))
            {
                _readNextToken = true;
                _position = _lexer.InputStream.Index;
                _currentMode = _lastReadMode;
                return token;
            }
            _readNextToken = false;
            return null;
        }

        public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] int offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            this.AddError(Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
        }
    }
}
