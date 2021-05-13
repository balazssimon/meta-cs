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
        private bool _resetting;

        public Antlr4SyntaxLexer(Language language, SourceText text, LanguageParseOptions options) 
            : base(language, text, options)
        {
            _stream = new Antlr4InputStream(this, this.TextWindow);
            _lexer = ((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Lexer(_stream);
            _lexer.TokenFactory = new IncrementalTokenFactory();
            _lexer.RemoveErrorListeners();
            _lexer.AddErrorListener(this);
            _syntaxFacts = Language.SyntaxFacts;
        }

        public Antlr4Lexer Antlr4Lexer => _lexer;

        internal Antlr4InputStream InputStream => _stream;

        internal bool Resetting => _resetting;

        protected override object? SaveLexerState()
        {
            if (_lexer.CurrentMode == 0 && _lexer.ModeStack.Count == 0) return null;
            else return new Antlr4LexerState(this);
        }

        protected override bool IsLexerInState(object? state)
        {
            if (state == null) return _lexer.CurrentMode == 0 && _lexer.ModeStack.Count == 0;
            var antlr4State = (Antlr4LexerState)state;
            if (_lexer.CurrentMode != antlr4State.Mode) return true;
            if (_lexer.ModeStack.Count != antlr4State.ModeStackReversed.Length) return true;
            int i = 0;
            foreach (var item in _lexer.ModeStack)
            {
                if (item != antlr4State.ModeStackReversed[i]) return true;
                ++i;
            }
            return false;
        }

        public override void RestoreLexerState(object? state)
        {
            var mode = state as Antlr4LexerState;
            _resetting = true;
            _lexer.Reset();
            _resetting = false;
            if (mode != null)
            {
                foreach (var m in mode.ModeStackReversed)
                {
                    _lexer.ModeStack.Push(m);
                }
                _lexer.CurrentMode = mode.Mode;
            }
        }

        protected override (SyntaxKind kind, bool cache) ScanLexeme()
        {
            var token = _lexer.NextToken();
            var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
            var cache = _syntaxFacts.IsFixedToken(kind);
            return (kind, cache);
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.AddError(Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
        }
    }
}
