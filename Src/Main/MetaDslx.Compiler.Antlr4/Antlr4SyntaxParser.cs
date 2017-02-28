using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Languages.Antlr4Roslyn.Compiler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Antlr4Roslyn
{
    public abstract class Antlr4SyntaxParser<TLexer, TParser> : SyntaxParser, IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
        where TLexer : Lexer
        where TParser : Parser
    {
        private IList<IToken> tokens;

        public Antlr4SyntaxParser(SourceText text, Language language, ParseOptions options, SyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default(CancellationToken))
            : base(text, language, options, oldTree, changes, cancellationToken)
        {
            this.Antlr4Errors = new Dictionary<int, string>();
            AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
            this.Lexer = this.CreateLexer(inputStream);
            this.CommonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = this.CreateParser(this.CommonTokenStream);
            this.Lexer.RemoveErrorListeners();
            this.Parser.RemoveErrorListeners();
            this.Lexer.AddErrorListener(this);
            this.Parser.AddErrorListener(this);
            this.tokens = this.CommonTokenStream.GetTokens();
        }

        public AntlrInputStream InputStream { get; private set; }
        public TLexer Lexer { get; private set; }
        public TParser Parser { get; private set; }
        public CommonTokenStream CommonTokenStream { get; private set; }
        public Dictionary<int, string> Antlr4Errors { get; private set; }

        protected abstract TLexer CreateLexer(AntlrInputStream inputStream);
        protected abstract TParser CreateParser(CommonTokenStream tokenStream);

        private int GetLeadingTriviaTokenStartIndex(IToken token, IToken previousToken)
        {
            int lastNewLine = -1;
            int i = token.TokenIndex - 1;
            int lastTriviaToken = token.TokenIndex;
            int lastTriviaTokenBeforeNewLine = lastTriviaToken;
            int startIndex = previousToken != null ? previousToken.TokenIndex + 1 : 0;
            while (i >= startIndex)
            {
                IToken t = tokens[i];
                int kind = t.Type;
                if (this.Language.SyntaxFacts.IsTriviaWithEndOfLine(kind))
                {
                    lastTriviaTokenBeforeNewLine = lastTriviaToken;
                    lastNewLine = i;
                }
                lastTriviaToken = i;
                --i;
            }
            if (lastNewLine < 0) return lastTriviaToken;
            else return lastTriviaTokenBeforeNewLine;
        }

        private int GetTrailingTriviaTokenEndIndex(IToken token, IToken nextToken)
        {
            int i = token.TokenIndex + 1;
            int lastTriviaToken = token.TokenIndex;
            int endIndex = nextToken != null ? nextToken.TokenIndex - 1 : tokens.Count - 1;
            while (i <= endIndex)
            {
                IToken t = tokens[i];
                int kind = t.Type;
                if (t.Channel == 0)
                {
                    return token.TokenIndex;
                }
                else if (this.Language.SyntaxFacts.IsTriviaWithEndOfLine(kind))
                {
                    return i;
                }
                ++i;
            }
            return lastTriviaToken;
        }

        private GreenNode GetLeadingTrivia(IToken token, IToken previousToken)
        {
            int startIndex = this.GetLeadingTriviaTokenStartIndex(token, previousToken);
            int endIndex = token.TokenIndex - 1;
            if (startIndex >= 0 && startIndex <= endIndex)
            {
                InternalSyntaxTrivia[] triviaArray = new InternalSyntaxTrivia[endIndex - startIndex + 1];
                for (int i = startIndex; i <= endIndex; i++)
                {
                    IToken t = this.tokens[i];
                    int kind = t.Type;
                    InternalSyntaxTrivia trivia = this.factory.Trivia(kind, t.Text);
                    trivia = (InternalSyntaxTrivia)this.AddDiagnostic(trivia, i);
                    triviaArray[i - startIndex] = trivia;
                }
                return new InternalSyntaxTriviaList(triviaArray, null, null);
            }
            return null;
        }

        private GreenNode GetTrailingTrivia(IToken token)
        {
            int startIndex = token.TokenIndex + 1;
            int endIndex = GetTrailingTriviaTokenEndIndex(token, null);
            if (startIndex >= 0 && startIndex <= endIndex)
            {
                InternalSyntaxTrivia[] triviaArray = new InternalSyntaxTrivia[endIndex - startIndex + 1];
                for (int i = startIndex; i <= endIndex; i++)
                {
                    IToken t = this.tokens[i];
                    int kind = t.Type;
                    InternalSyntaxTrivia trivia = this.factory.Trivia(kind, t.Text);
                    trivia = (InternalSyntaxTrivia)this.AddDiagnostic(trivia, i);
                    triviaArray[i - startIndex] = trivia;
                }
                return new InternalSyntaxTriviaList(triviaArray, null, null);
            }
            return null;
        }

        private GreenNode AddDiagnostic(GreenNode token, int tokenIndex)
        {
            string errorMessage;
            if (this.Antlr4Errors.TryGetValue(tokenIndex, out errorMessage))
            {
                SyntaxDiagnosticInfo diagnosticInfo = this.MakeError(token.GetLeadingTriviaWidth(), token.Width, Antlr4RoslynErrorCode.ERR_SyntaxError, errorMessage);
                return token.WithDiagnostics(new DiagnosticInfo[] { diagnosticInfo });
            }
            return token;
        }


        protected GreenNode VisitTerminal(ITerminalNode node, IToken previousToken)
        {
            if (node == null) return null;
            InternalSyntaxToken result = null;
            bool addTrivia = true;
            IToken token = node.Symbol;
            if (token.Type >= 0)
            {
                int kind = token.Type;
                if (token.StartIndex < 0 || token.StopIndex < token.StartIndex)
                {
                    result = this.factory.MissingToken(kind);
                    return this.AddDiagnostic(result, token.TokenIndex);
                }
                if (this.Language.SyntaxFacts.IsFixedToken(kind))
                {
                    result = this.factory.Token(kind);
                }
                else
                {
                    string text = node.GetText();
                    result = this.factory.Token(this.GetLeadingTrivia(token, previousToken), kind, text, text, this.GetTrailingTrivia(token));
                    addTrivia = false;
                }
            }
            else
            {
                result = this.factory.Token(SyntaxKind.Eof);
            }
            if (addTrivia)
            {
                GreenNode leadingTrivia = this.GetLeadingTrivia(token, previousToken);
                if (leadingTrivia != null) result = result.WithLeadingTrivia(leadingTrivia);
                GreenNode trailingTrivia = this.GetTrailingTrivia(token);
                if (trailingTrivia != null) result = result.WithTrailingTrivia(trailingTrivia);
            }
            return this.AddDiagnostic(result, token.TokenIndex);
        }

        protected GreenNode VisitErrorNode(IErrorNode node)
        {
            int kind = node.Symbol.Type;
            GreenNode result = this.factory.MissingToken(kind);
            return this.AddDiagnostic(result, node.Symbol.TokenIndex);
        }
        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.Antlr4Errors[offendingSymbol] = msg;
        }

        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (offendingSymbol != null)
            {
                this.Antlr4Errors[offendingSymbol.TokenIndex] = msg;
            }
        }
    }
}
