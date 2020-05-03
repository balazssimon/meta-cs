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
    public abstract class IncrementalAntlr4Lexer : IncrementalLexer, IAntlr4Lexer
    {
        private readonly IncrementalAntlr4InputStream _stream;
        private readonly Antlr4.Runtime.Lexer _lexer;
        private readonly SyntaxFacts _syntaxFacts;
        private bool _readNextToken;
        private int _position;

        public IncrementalAntlr4Lexer(Language language, SourceText text, LanguageParseOptions options, IEnumerable<TextChangeRange> changes) 
            : base(language, text, options, changes)
        {
            _stream = new IncrementalAntlr4InputStream(this.TextWindow);
            _lexer = ((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Lexer(_stream);
            _lexer.TokenFactory = new IncrementalTokenFactory();
            _syntaxFacts = Language.SyntaxFacts;
            _readNextToken = true;
        }

        Antlr4.Runtime.Lexer IAntlr4Lexer.Antlr4Lexer => _lexer;

        public override int Position => _position;

        public override void Reset(int position, DirectiveStack directives)
        {
            base.Reset(position, directives);
            _lexer.InputStream.Seek(position);
            _position = position;
            _readNextToken = true;
            _lexer._hitEOF = false;
        }

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
            }
            base.RestoreLexerMode(mode);
        }

        protected override SyntaxKind ScanSyntaxToken()
        {
            IToken token = ReadNextToken(false);
            if (token == null) return SyntaxKind.None;
            if (token.Type == -1)
            {
                return SyntaxKind.Eof;
            }
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
            if (_readNextToken)
            {
                _readNextToken = false;
                this.Start();
                token = _lexer.NextToken();
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
                return token;
            }
            _readNextToken = false;
            return null;
        }
    }
}
