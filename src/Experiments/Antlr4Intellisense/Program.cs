using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4Intellisense.Syntax;
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
    public class Program
    {
        public static void Main(string[] args)
        {
            //*/        0123456789012
            var text = "var a = 1 + 2\r\nvar b = a+1\r\n";
            var change = ImmutableArray<TextChangeRange>.Empty;

            var lexer = SandyLanguage.Instance.InternalSyntaxFactory.CreateLexer(SourceText.From(text), null, null);
            /*LexerMode mode = null;
            InternalSyntaxToken token;
            do
            {
                token = lexer.Lex(ref mode);
                Console.WriteLine(token.KindText + ": " + token.Text);
            } while (token.Kind != SandySyntaxKind.Eof);
            Console.WriteLine("Lookahead: {0}..{1}", lexer.MinLookahead, lexer.MaxLookahead);*/

            var parser = SandyLanguage.Instance.InternalSyntaxFactory.CreateParser(SourceText.From(text), null, null, null);
            var tree = parser.Parse();
            Console.WriteLine(tree);

            /*
            var lexer = Lex(text, change, null);
            Console.WriteLine("----");
            var tree = Parse(text, change, null);
            Console.WriteLine("====");
            Intellisense(tree, 0);
            Intellisense(tree, 1);
            Intellisense(tree, 3);
            Intellisense(tree, 4);
            Intellisense(tree, 5);
            Intellisense(tree, 6);
            Intellisense(tree, 7);
            Intellisense(tree, 8);
            Intellisense(tree, 9);
            Intellisense(tree, 10);
            Intellisense(tree, 11);
            Intellisense(tree, 12);
            Intellisense(tree, 13);
            Console.WriteLine("====");

            text = "var a = 13 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1));

            lexer = Lex(text, change, lexer);
            Console.WriteLine("----");
            tree = Parse(text, change, tree);
            Console.WriteLine("====");

            text = "var a = 3 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(8, 9), 0));

            lexer = Lex(text, change, lexer);
            Console.WriteLine("----");
            tree = Parse(text, change, tree);
            Console.WriteLine("====");

            text = "var a = 34 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1));

            lexer = Lex(text, change, lexer);
            Console.WriteLine("----");
            tree = Parse(text, change, tree);
            Console.WriteLine("====");

            text = "var a = 3+4 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1));

            lexer = Lex(text, change, lexer);
            Console.WriteLine("----");
            tree = Parse(text, change, tree);
            Console.WriteLine("====");

            EmptyFile();
            AfterVar();
            AfterEquals();
            AfterLiteral();
            AfterAddition();
            */
        }
        /*
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

        private static SandySyntaxTree Parse(string text, ImmutableArray<TextChangeRange> changes, SandySyntaxTree oldTree)
        {
            var sourceText = SourceText.From(text);
            var oldRoot = oldTree?.GetRoot();
            var parser = new SandySyntaxParser(sourceText, null, oldRoot, changes);
            var tree = SandySyntaxTree.Create(parser);
            Console.WriteLine(PrintSyntaxTree(tree, parser));
            return tree;
        }

        public static string PrintSyntaxTree(SandySyntaxTree tree, SandySyntaxParser parser)
        {
            StringBuilder buf = new StringBuilder();
            Recursive(parser, tree.GetRoot(), buf, 0, parser.Antlr4Parser.RuleNames.ToList());
            return buf.ToString();
        }

        private static void Recursive(SandySyntaxParser parser, SandySyntaxNode node, StringBuilder buf, int offset, List<string> ruleNames)
        {
            for (int i = 0; i < offset; i++)
            {
                buf.Append("  ");
            }
            buf.Append(node.Kind);
            buf.Append($" ({parser.GetVersion(node.Green)})").AppendLine();
            foreach (var child in node.ChildNodesAndTokens())
            {
                if (child.IsToken)
                {
                    for (int i = 0; i < offset+1; i++)
                    {
                        buf.Append("  ");
                    }
                    buf.Append((SandySyntaxKind)child.GetKind());
                    buf.Append(": " + child.AsToken().Text);
                    buf.AppendLine();
                }
                else
                {
                    Recursive(parser, (SandySyntaxNode)child.AsNode(), buf, offset + 1, ruleNames);
                }
            }
        }

        public static string PrintSyntaxTree(IncrementalAntlr4Parser parser, IParseTree root)
        {
            StringBuilder buf = new StringBuilder();
            Recursive(parser, root, buf, 0, parser.Antlr4Parser.RuleNames.ToList());
            return buf.ToString();
        }

        private static void Recursive(IncrementalAntlr4Parser parser, IParseTree root, StringBuilder buf, int offset, List<string> ruleNames)
        {
            for (int i = 0; i < offset; i++)
            {
                buf.Append("  ");
            }
            buf.Append(Trees.GetNodeText(root, ruleNames));
            if (root is ParserRuleContext prc) 
            {
                buf.Append($" ({parser.GetVersion(prc)})").AppendLine();
                if (prc.children != null)
                {
                    foreach (IParseTree child in prc.children)
                    {
                        Recursive(parser, child, buf, offset + 1, ruleNames);
                    }
                }
            }
            else
            {
                buf.AppendLine();
            }
        }

        private static void Intellisense(SandySyntaxTree tree, int position)
        {
            if (!IncrementalAntlr4Parser.TryGetParser(tree.GetRoot(), out var parser)) return;
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
        }*/
    }
}
