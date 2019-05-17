using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace MetaDslx.Languages.Antlr4Roslyn.Parser
{
    public abstract class Antlr4SyntaxParser<TLexer, TParser> : SyntaxParser, IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
        where TLexer : Antlr4.Runtime.Lexer
        where TParser : Antlr4.Runtime.Parser
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
            return previousToken != null ? previousToken.TokenIndex + 1 : 0;
            /*int lastNewLine = -1;
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
            if (lastNewLine < 0 || previousToken == null) return lastTriviaToken;
            else return lastTriviaTokenBeforeNewLine;*/
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

        private GreenNode GetTrailingTrivia(IToken token, ref IToken lastTokenOrTrivia)
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
                lastTokenOrTrivia = this.tokens[endIndex];
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


        protected GreenNode VisitTerminal(ITerminalNode node, ref IToken previousTokenOrTrivia)
        {
            if (node == null) return null;
            InternalSyntaxToken result = null;
            bool addTrivia = true;
            bool updatePreviousTokenOrTrivia = true;
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
                    GreenNode leadingTrivia = this.GetLeadingTrivia(token, previousTokenOrTrivia);
                    previousTokenOrTrivia = token;
                    GreenNode trailingTrivia = this.GetTrailingTrivia(token, ref previousTokenOrTrivia);
                    result = this.factory.Token(leadingTrivia, kind, text, text, trailingTrivia);
                    addTrivia = false;
                    updatePreviousTokenOrTrivia = false;
                }
            }
            else
            {
                result = this.factory.Token(SyntaxKind.Eof);
            }
            if (addTrivia)
            {
                GreenNode leadingTrivia = this.GetLeadingTrivia(token, previousTokenOrTrivia);
                if (leadingTrivia != null) result = result.WithLeadingTrivia(leadingTrivia);
                previousTokenOrTrivia = token;
                GreenNode trailingTrivia = this.GetTrailingTrivia(token, ref previousTokenOrTrivia);
                if (trailingTrivia != null) result = result.WithTrailingTrivia(trailingTrivia);
                updatePreviousTokenOrTrivia = false;
            }
            if (updatePreviousTokenOrTrivia)
            {
                previousTokenOrTrivia = token;
            }
            return this.AddDiagnostic(result, token.TokenIndex);
        }

        protected GreenNode VisitErrorNode(IErrorNode node)
        {
            int kind = node.Symbol.Type;
            GreenNode result = this.factory.MissingToken(kind);
            return this.AddDiagnostic(result, node.Symbol.TokenIndex);
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.Antlr4Errors[offendingSymbol] = msg;
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (offendingSymbol != null)
            {
                this.Antlr4Errors[offendingSymbol.TokenIndex] = msg;
            }
        }
    }
}
