using Antlr4Intellisense.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Antlr4Intellisense
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lexer = Lex("var a = 1 + 2", ImmutableArray<TextChangeRange>.Empty, null);
            Console.WriteLine("----");
            lexer = Lex("var a = 13 + 2", ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1)), lexer);
            Console.WriteLine("----");
            lexer = Lex("var a = 3 + 2", ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(8, 9), 0)), lexer);
            Console.WriteLine("----");
            lexer = Lex("var a = 34 + 2", ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1)), lexer);
            Console.WriteLine("----");
            lexer = Lex("var a = 3+4 + 2", ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1)), lexer);
            Console.WriteLine("----");

            lexer.Seek(0);
            var parser = new SandyParser(lexer);
            var tree = parser.sandyFile();
            Console.WriteLine(tree);

            EmptyFile();
            AfterVar();
            AfterEquals();
            AfterLiteral();
            AfterAddition();

        }

        private static IncrementalAntlr4Lexer Lex(string text, ImmutableArray<TextChangeRange>  changes, IncrementalAntlr4Lexer oldLexer)
        {
            var sourceText = SourceText.From(text);
            var lexer = new IncrementalAntlr4Lexer(SandyLanguage.Instance, sourceText, changes, oldLexer);
            InternalSyntaxToken token = null;
            do
            {
                token = lexer.Lex();
                Console.WriteLine(token);
            }
            while (token != null && token.Kind != SyntaxKind.Eof);
            var stream = (IncrementalInputStream)lexer.Antlr4Lexer.InputStream;
            Console.WriteLine("Lookahead range: " + stream.OverallMinMaxLookahead);
            return lexer;
        }

        private static void EmptyFile()
        {
            var code = "var a = 1 + 2";
            var completion = new Antlr4CompletionSource(code, 0).GetTokenSuggestions();
            PrintResult("EmptyFile", completion);
        }

        private static void AfterVar()
        {
            var code = "var a = 1 + 2";
            var completion = new Antlr4CompletionSource(code, 4).GetTokenSuggestions();
            PrintResult("AfterVar", completion);
        }

        private static void AfterEquals()
        {
            var code = "var a = 1 + 2";
            var completion = new Antlr4CompletionSource(code, 7).GetTokenSuggestions();
            PrintResult("AfterEquals", completion);
        }

        private static void AfterLiteral()
        {
            var code = "var a = 1 + 2";
            var completion = new Antlr4CompletionSource(code, 9).GetTokenSuggestions();
            PrintResult("AfterLiteral", completion);
        }

        private static void AfterAddition()
        {
            var code = "var a = 1 + 2";
            var completion = new Antlr4CompletionSource(code, 11).GetTokenSuggestions();
            PrintResult("AfterAddition", completion);
        }

        private static void PrintResult(string name, HashSet<int> completion)
        {
            var vocabulary = SandyLexer.DefaultVocabulary;
            Console.WriteLine(name);
            foreach (var tokenType in completion)
            {
                //Console.WriteLine("  "+(char)tokenType);
                Console.WriteLine("  " + tokenType + " (" + vocabulary.GetDisplayName(tokenType) + ": " + vocabulary.GetSymbolicName(tokenType) + ")");
            }
        }
    }
}
