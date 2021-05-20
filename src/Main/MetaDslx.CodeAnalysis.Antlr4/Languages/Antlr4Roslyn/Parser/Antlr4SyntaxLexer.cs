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
        private Antlr4LexerStateManager _stateManager;
        private bool _hitEof;

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

        protected override (SyntaxKind kind, bool isTrivia, bool cache) ScanLexeme()
        {
            var token = _lexer.NextToken();
            var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
            if (kind == SyntaxKind.Eof)
            {
                if (_hitEof) return (SyntaxKind.None, false, false);
                else _hitEof = true;
            }
            var cache = _syntaxFacts.IsFixedToken(kind);
            return (kind, token.Channel != 0, cache);
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.AddError(Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
            this.AppendLexeme(SyntaxKind.BadToken, true, false);
            this.StartLexeme();
        }

        protected override LexerStateManager? CreateStateManager()
        {
            return new Antlr4LexerStateManager(this);
        }

        protected class Antlr4LexerStateManager : LexerStateManager
        {
            public Antlr4LexerStateManager(Antlr4SyntaxLexer lexer) 
                : base(lexer)
            {
            }

            public new Antlr4SyntaxLexer Lexer => (Antlr4SyntaxLexer)base.Lexer;
            public Antlr4Lexer Antlr4Lexer => Lexer.Antlr4Lexer;

            protected override int ComputeStateHash()
            {
                var antlr4Lexer = Antlr4Lexer;
                var hash = Hash.Combine(antlr4Lexer.CurrentMode, antlr4Lexer.ModeStack.Count);
                foreach (var item in antlr4Lexer.ModeStack)
                {
                    hash = Hash.Combine(item, hash);
                }
                return hash;
            }

            protected override bool IsInState(LexerState? state)
            {
                var antlr4Lexer = Antlr4Lexer;
                if (state == null) return antlr4Lexer.CurrentMode == 0 && antlr4Lexer.ModeStack.Count == 0;
                var antlr4State = (Antlr4LexerState)state;
                if (antlr4Lexer.CurrentMode != antlr4State.Mode) return false;
                if (antlr4State.ModeStackReversed == null) return antlr4Lexer.ModeStack.Count == 0;
                if (antlr4Lexer.ModeStack.Count != antlr4State.ModeStackReversed.Length) return false;
                int i = 0;
                foreach (var item in antlr4Lexer.ModeStack)
                {
                    if (item != antlr4State.ModeStackReversed[i]) return false;
                    ++i;
                }
                return true;
            }

            protected override void RestoreState(LexerState? state)
            {
                var antlr4State = state as Antlr4LexerState;
                var antlr4Lexer = Antlr4Lexer;
                Lexer._resetting = true;
                antlr4Lexer.Reset();
                Lexer._resetting = false;
                if (antlr4State != null)
                {
                    if (antlr4State.ModeStackReversed != null)
                    {
                        foreach (var m in antlr4State.ModeStackReversed)
                        {
                            antlr4Lexer.ModeStack.Push(m);
                        }
                    }
                    antlr4Lexer.CurrentMode = antlr4State.Mode;
                }
                Lexer._hitEof = false;
            }

            protected override LexerState? SaveState(int hashCode)
            {
                var antlr4Lexer = Antlr4Lexer;
                if (antlr4Lexer.CurrentMode == 0 && antlr4Lexer.ModeStack.Count == 0) return null;
                else return new Antlr4LexerState(hashCode, Antlr4Lexer.CurrentMode, Antlr4Lexer.ModeStack.Count == 0 ? null : Antlr4Lexer.ModeStack.ToArray());
            }
        }
    }
}
