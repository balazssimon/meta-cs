using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4Intellisense.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace Antlr4Intellisense
{
    public class IncrementalSandyParser : IncrementalAntlr4Parser
    {
        public IncrementalSandyParser(Language language, SourceText text, LanguageParseOptions options, ImmutableArray<TextChangeRange> changes, IncrementalAntlr4Parser oldParser, CancellationToken cancellationToken = default) 
            : base(language, text, options, changes, oldParser, cancellationToken)
        {
        }

        public override GreenNode Parse()
        {
            var parser = (SandyParser)this.Antlr4Parser;
            var sandyFile = parser.sandyFile();
            return null;
        }

        public IParseTree ParseTree()
        {
            var parser = (SandyParser)this.Antlr4Parser;
            var sandyFile = parser.sandyFile();
            return sandyFile;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //*/        0123456789012
            var text = "var a = 1 + 2\r\nvar b = a+1\r\n";
            var change = ImmutableArray<TextChangeRange>.Empty;
            
            var lexer = Lex(text, change, null);
            Console.WriteLine("----");
            var parser = Parse(text, change, null);
            Console.WriteLine("====");
            Intellisense(parser, 0);
            Intellisense(parser, 1);
            Intellisense(parser, 3);
            Intellisense(parser, 4);
            Intellisense(parser, 5);
            Intellisense(parser, 6);
            Intellisense(parser, 7);
            Intellisense(parser, 8);
            Intellisense(parser, 9);
            Intellisense(parser, 10);
            Intellisense(parser, 11);
            Intellisense(parser, 12);
            Intellisense(parser, 13);
            Console.WriteLine("====");

            text = "var a = 13 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1));

            lexer = Lex(text, change, lexer);
            Console.WriteLine("----");
            parser = Parse(text, change, parser);
            Console.WriteLine("====");

            text = "var a = 3 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(8, 9), 0));

            lexer = Lex(text, change, lexer);
            Console.WriteLine("----");
            parser = Parse(text, change, parser);
            Console.WriteLine("====");

            text = "var a = 34 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1));

            lexer = Lex(text, change, lexer);
            Console.WriteLine("----");
            parser = Parse(text, change, parser);
            Console.WriteLine("====");

            text = "var a = 3+4 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1));

            lexer = Lex(text, change, lexer);
            Console.WriteLine("----");
            parser = Parse(text, change, parser);
            Console.WriteLine("====");
            //*/

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
            //var stream = (IncrementalAntlr4InputStream)lexer.Antlr4Lexer.InputStream;
            Console.WriteLine("Affected old token range: " + lexer.AffectedOldTokenRange.a + ".." + lexer.AffectedOldTokenRange.b);
            //Console.WriteLine("Lookahead range: " + stream.OverallMinMaxLookahead);
            return lexer;
        }

        private static IncrementalSandyParser Parse(string text, ImmutableArray<TextChangeRange> changes, IncrementalSandyParser oldParser)
        {
            var sourceText = SourceText.From(text);
            var parser = new IncrementalSandyParser(SandyLanguage.Instance, sourceText, null, changes, oldParser);
            var tree = parser.ParseTree();
            var treeAsString = PrintSyntaxTree(parser.Antlr4Parser, tree);
            Console.WriteLine(treeAsString);
            return parser;
        }

        public static string PrintSyntaxTree(Parser parser, IParseTree root)
        {
            StringBuilder buf = new StringBuilder();
            Recursive(root, buf, 0, parser.RuleNames.ToList());
            return buf.ToString();
        }

        private static void Recursive(IParseTree root, StringBuilder buf, int offset, List<string> ruleNames)
        {
            for (int i = 0; i < offset; i++)
            {
                buf.Append("  ");
            }
            buf.Append(Trees.GetNodeText(root, ruleNames));
            if (root is IncrementalParserRuleContext prc) 
            {
                buf.Append($" ({prc.Version})").AppendLine();
                if (prc.children != null)
                {
                    foreach (IParseTree child in prc.children)
                    {
                        Recursive(child, buf, offset + 1, ruleNames);
                    }
                }
            }
            else
            {
                buf.AppendLine();
            }
        }

        private static void Intellisense(IncrementalSandyParser parser, int position)
        {
            var completion = parser.GetCompletionTokensAt(position);
            Console.WriteLine("Position: "+position);
            foreach (var item in completion)
            {
                if (item >= 0)
                {
                    Console.WriteLine("  " + item + " (" + parser.Antlr4Parser.Vocabulary.GetSymbolicName(item) + ")");
                }
            }
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
