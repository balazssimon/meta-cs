using Antlr4Intellisense.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;

namespace Antlr4Intellisense
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EmptyFile();
            AfterVar();
            AfterEquals();
            AfterLiteral();
            AfterAddition();
        }

        private static void EmptyFile()
        {
            var code = "";
            var completion = new Antlr4CompletionSource(code).GetTokenSuggestions();
            PrintResult("EmptyFile", completion);
        }

        private static void AfterVar()
        {
            var code = "var";
            var completion = new Antlr4CompletionSource(code).GetTokenSuggestions();
            PrintResult("AfterVar", completion);
        }

        private static void AfterEquals()
        {
            var code = "var a =";
            var completion = new Antlr4CompletionSource(code).GetTokenSuggestions();
            PrintResult("AfterEquals", completion);
        }

        private static void AfterLiteral()
        {
            var code = "var a = 1";
            var completion = new Antlr4CompletionSource(code).GetTokenSuggestions();
            PrintResult("AfterLiteral", completion);
        }

        private static void AfterAddition()
        {
            var code = "var a = 1 +";
            var completion = new Antlr4CompletionSource(code).GetTokenSuggestions();
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
