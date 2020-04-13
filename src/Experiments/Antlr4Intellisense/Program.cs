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
    class IncrementalSandyLexer : IncrementalAntlr4Lexer<SandyLexer>
    {
        public IncrementalSandyLexer(Language language, SourceText text, IncrementalSandyLexer oldLexer, ImmutableArray<TextChangeRange> changes)
            : base(language, text, oldLexer, changes)
        {
        }

        protected override SandyLexer CreateLexer(IncrementalInputStream inputStream)
        {
            return new SandyLexer(inputStream);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var text = SourceText.From("var a = 1 + 2");
            var lexer = new IncrementalSandyLexer(SandyLanguage.Instance, text, null, ImmutableArray<TextChangeRange>.Empty);
            InternalSyntaxToken token = null;
            do
            {
                token = lexer.Lex();
                Console.WriteLine(token);
            }
            while (token.Kind != SyntaxKind.Eof);
            var stream = (IncrementalInputStream)lexer.Lexer.InputStream;
            Console.WriteLine("Lookahead range: "+stream.OverallMinMaxLookahead);

            Console.WriteLine();

            EmptyFile();
            AfterVar();
            AfterEquals();
            AfterLiteral();
            AfterAddition();

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
