using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.InternalUtilities;
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
using System.IO;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class Antlr4SyntaxLexer : SyntaxLexer, IAntlr4Lexer, IAntlrErrorListener<int>
    {
        internal static readonly IncrementalToken InvalidToken = new IncrementalToken(0, string.Empty);

        private readonly Antlr4InputStream _stream;
        private readonly Antlr4Lexer _lexer;
        private readonly SyntaxFacts _syntaxFacts;
        private bool _readNextToken;
        private bool _eof;
        private Antlr4LexerMode _currentMode;
        private Antlr4LexerMode _lastMode;

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

        public Antlr4Lexer Antlr4Lexer => _lexer;

        internal Antlr4InputStream InputStream => _stream;

        public override void Reset(int position, DirectiveStack directives)
        {
            base.Reset(position, directives);
            _readNextToken = true;
            _eof = false;
            _lexer.HitEOF = false;
            _lexer.ModeStack.Clear();
            _lexer.CurrentMode = 0;
            _lexer.InputStream.Seek(position);
            CallLogger.Instance.Call(CreateAntlr4LexerModeSnapshot());
            CallLogger.Instance.Log("  position=" + position);
            CallLogger.Instance.Log("  Text=" + Text.GetSubText(TextSpan.FromBounds(position, Math.Min(Text.Length, position + 10))) + (position+10 < Text.Length ? "..." : ""));
        }

        protected sealed override bool HasLexerModeChanged(LexerMode previousMode)
        {
            return !LexerMode.SameMode(_currentMode, previousMode);
        }

        protected sealed override LexerMode CreateLexerModeSnapshot()
        {
            return _currentMode;
        }

        protected sealed override void RestoreLexerMode(LexerMode mode)
        {
            this.RestoreAntlr4LexerMode((Antlr4LexerMode)mode);
        }

        /*protected virtual bool HasAntlr4LexerModeChanged(Antlr4LexerMode previousMode)
        {
            var antlr4Mode = (Antlr4LexerMode)previousMode;
            if ((antlr4Mode == null && (_lexer.ModeStack.Count != 0 || _lexer.CurrentMode != 0)) ||
                (antlr4Mode != null && antlr4Mode.HasChanged(this)))
            {
                if (_lexer.ModeStack.Count == 0 && _lexer.CurrentMode == 0) return false;
                return true;
            }
            else
            {
                return false;
            }
        }*/

        protected virtual Antlr4LexerMode CreateAntlr4LexerModeSnapshot()
        {
            if (_lexer.ModeStack.Count == 0 && _lexer.CurrentMode == 0) return null;
            return new Antlr4LexerMode(this);
        }

        protected virtual void RestoreAntlr4LexerMode(Antlr4LexerMode mode)
        {
            base.RestoreLexerMode(mode);
            var position = this.Position;
            _lexer.HitEOF = false;
            _lexer.ModeStack.Clear();
            _lexer.InputStream.Seek(position);
            if (mode != null)
            {
                foreach (var m in mode.ModeStackReversed)
                {
                    _lexer.ModeStack.Push(m);
                }
                _lexer.CurrentMode = mode.Mode;
            }
            _readNextToken = true;
            _eof = false;
            _currentMode = mode;
            _lastMode = mode;
        }

        protected override SyntaxKind ScanSyntaxToken()
        {
            CallLogger.Instance.Call(CreateAntlr4LexerModeSnapshot());
            IToken token = ReadNextToken(false);
            if (token == null || token.Type == 0 || token.Type < -1) return SyntaxKind.None;
            if (token.Type == -1) return SyntaxKind.Eof;
            var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
            return kind;
        }

        protected override SyntaxKind ScanSyntaxTrivia(bool afterFirstToken, bool isTrailing)
        {
            CallLogger.Instance.Call(CreateAntlr4LexerModeSnapshot());
            IToken token = ReadNextToken(true);
            if (token == null || token.Type <= 0) return SyntaxKind.None;
            var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
            return kind;
        }

        private IToken ReadNextToken(bool readTrivia)
        {
            //if (_eof) return null;
            CallLogger.Instance.Call("readTrivia="+readTrivia+", readNextToken="+_readNextToken);
            CallLogger.Instance.Log("  LexerMode=" + CreateAntlr4LexerModeSnapshot());
            CallLogger.Instance.Log("  _lastMode=" + _lastMode);
            IToken token;
            if (_eof)
            {
                token = null;
                _readNextToken = false;
            }
            else if (_readNextToken)
            {
                this.Start();
                _readNextToken = false;
                token = _lexer.NextToken();
                /*if (HasAntlr4LexerModeChanged(_lastMode))*/ _lastMode = CreateAntlr4LexerModeSnapshot();
                if (token.Type == TokenConstants.EOF)
                {
                    TextWindow.Start();
                }
            }
            else
            {
                token = _lexer.Token;
            }
            CallLogger.Instance.Log("  token=" + token);
            CallLogger.Instance.Log("  LexerMode=" + CreateAntlr4LexerModeSnapshot());
            CallLogger.Instance.Log("  _currentMode=" + _currentMode);
            CallLogger.Instance.Log("  _lastMode=" + _lastMode);
            if (token == null) return null;
            if ((readTrivia && token.Channel != 0) || (!readTrivia && token.Channel == 0))
            {
                _eof = token.Type == TokenConstants.EOF;
                _readNextToken = true;
                _currentMode = _lastMode;
                CallLogger.Instance.Log("  _currentMode=" + _currentMode);
                CallLogger.Instance.Log("  result=" + token);
                return token;
            }
            _readNextToken = false;
            return null;
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.AddError(Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
            CallLogger.Instance.Log("  Lexer error: " + msg);
        }
    }
}
