using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class IncrementalAntlr4Lexer<TLexer> : IncrementalLexer, IAntlr4Lexer
        where TLexer : Antlr4.Runtime.Lexer
    {
        private TLexer _lexer;
        private SyntaxFacts _syntaxFacts;
        private InternalSyntaxFactory _syntaxFactory;
        private IToken _lastToken;

        public IncrementalAntlr4Lexer(Language language, SourceText text, IncrementalAntlr4Lexer<TLexer> oldLexer, ImmutableArray<TextChangeRange> changes)
            : base(language, text, oldLexer, changes)
        {
            _lexer = this.CreateLexer(new IncrementalInputStream(text));
            _syntaxFacts = language.SyntaxFacts;
            _syntaxFactory = language.InternalSyntaxFactory;
        }

        public TLexer Lexer => _lexer;

        Antlr4.Runtime.Lexer IAntlr4Lexer.Lexer => this.Lexer;

        protected abstract TLexer CreateLexer(IncrementalInputStream inputStream);

        public override InternalSyntaxToken Lex()
        {
            var token = _lastToken ?? _lexer.NextToken();
            var leadingTriviaBuilder = ArrayBuilder<InternalSyntaxTrivia>.GetInstance();
            while (token != null && token.Type >= 0 && (token.Channel != 0 || string.IsNullOrWhiteSpace(token.Text)))
            {
                var triviaKind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
                var trivia = _syntaxFactory.Trivia(triviaKind, token.Text);
                leadingTriviaBuilder.Add(trivia);
                token = _lexer.NextToken();
            }
            var leadingTriviaArray = leadingTriviaBuilder.ToArrayAndFree();
            var leadingTrivia = leadingTriviaArray.Length > 0 ? _syntaxFactory.List(leadingTriviaArray).Node : null;
            if (token == null || token.Type < 0)
            {
                var result = _syntaxFactory.EndOfFile;
                if (leadingTrivia != null) result = (InternalSyntaxToken)result.WithLeadingTrivia(leadingTrivia);
                return result;
            }
            else
            {
                _lastToken = token;
                bool reachedLineEnd = EndsWithLineEnd(_lastToken);
                var trailingTriviaBuilder = ArrayBuilder<InternalSyntaxTrivia>.GetInstance();
                _lastToken = _lexer.NextToken();
                while (_lastToken != null && _lastToken.Type >= 0 && (_lastToken.Channel != 0 || string.IsNullOrWhiteSpace(_lastToken.Text)) && !reachedLineEnd)
                {
                    if (EndsWithLineEnd(_lastToken)) reachedLineEnd = true;
                    var triviaKind = _lastToken.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
                    var trivia = _syntaxFactory.Trivia(triviaKind, _lastToken.Text);
                    trailingTriviaBuilder.Add(trivia);
                    _lastToken = _lexer.NextToken();
                }
                var trailingTriviaArray = trailingTriviaBuilder.ToArrayAndFree();
                var trailingTrivia = trailingTriviaArray.Length > 0 ? _syntaxFactory.List(trailingTriviaArray).Node : null;
                var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
                if (this.Language.SyntaxFacts.IsFixedToken(kind))
                {
                    return _syntaxFactory.Token(leadingTrivia, kind, trailingTrivia);
                }
                else
                {
                    string text = token.Text;
                    var value = this.Language.SyntaxFacts.ExtractValue(text);
                    return _syntaxFactory.Token(leadingTrivia, kind, text, value, trailingTrivia);
                }
            }
        }

        private bool EndsWithLineEnd(IToken token)
        {
            var text = token.Text;
            return text != null && (text.EndsWith("\r") || text.EndsWith("\n"));
        }

        public override object GetState()
        {
            return new Antlr4LexerState(this);
        }

        public override void RestoreState(object state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (state is Antlr4LexerState antlr4LexerState) antlr4LexerState.Restore(this);
            else throw new ArgumentException($"Invalid state type '{state.GetType()}' for IncrementalAntlr4Lexer", nameof(state));
        }
    }
}
