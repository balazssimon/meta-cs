using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4Intellisense.Syntax;
using Antlr4Intellisense.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax;
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
            //*/        01234567890123 4 567890123456 7
            var text = "var a = 1 + 2\r\nvar b = a+1\r\n";
            var change = ImmutableArray<TextChangeRange>.Empty;

            Antlr4SyntaxLexer lexer = null;
            //lexer = Lex(text, change, null);
            //Console.WriteLine("----");
            var tree = Parse(text, change, null);
            Console.WriteLine("====");
            //Intellisense(tree, 0);
            //Intellisense(tree, 1);
            //Intellisense(tree, 3);
            //Intellisense(tree, 4);
            //Intellisense(tree, 5);
            //Intellisense(tree, 6);
            //Intellisense(tree, 7);
            //Intellisense(tree, 8);
            //Intellisense(tree, 9);
            //Intellisense(tree, 10);
            //Intellisense(tree, 11);
            //Intellisense(tree, 12);
            //Intellisense(tree, 13);
            //Console.WriteLine("====");
            
            text = "var a = 13 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1));

            //lexer = Lex(text, change, lexer);
            //Console.WriteLine("----");
            tree = Parse(text, change, tree);
            Console.WriteLine("====");

            text = "var a = 3 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(8, 9), 0));

            //lexer = Lex(text, change, lexer);
            //Console.WriteLine("----");
            tree = Parse(text, change, tree);
            Console.WriteLine("====");

            text = "var a = 34 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1));

            //lexer = Lex(text, change, lexer);
            //Console.WriteLine("----");
            tree = Parse(text, change, tree);
            Console.WriteLine("====");

            text = "var a = 3+4 + 2\r\nvar b = a+1\r\n";
            change = ImmutableArray.Create(new TextChangeRange(TextSpan.FromBounds(9, 9), 1));

            //lexer = Lex(text, change, lexer);
            //Console.WriteLine("----");
            tree = Parse(text, change, tree);
            Console.WriteLine("====");

            //*/

            //*/

            EmptyFile();
            AfterVar();
            AfterEquals();
            AfterLiteral();
            AfterAddition();

            //*/

            /*/

            TypeTest(@"namespace A { metamodel M; associationx B.c with C.b; class B { C c; } class C { B b; } }");

            //*/
        }

        private static void TypeTest(string source)
        {
            var options = MetaParseOptions.Default.WithIncremental(true);
            SourceText text = null;
            MetaSyntaxTree tree = null;
            for (int i = 0; i < source.Length; i++)
            {
                string currentSource = source.Substring(0, i);
                if (i == 0)
                {
                    text = SourceText.From(currentSource);
                    tree = MetaSyntaxTree.ParseText(text, options);
                }
                else
                {
                    text = text.WithChanges(new TextChange(new TextSpan(text.Length, 0), source.Substring(i - 1, 1)));
                    tree = (MetaSyntaxTree)tree.WithChangedText(text);
                }
            }
        }

        private static Antlr4SyntaxLexer Lex(string text, ImmutableArray<TextChangeRange>  changes, Antlr4SyntaxLexer oldLexer)
        {
            var sourceText = SourceText.From(text);
            var lexer = (SandySyntaxLexer)SandyLanguage.Instance.InternalSyntaxFactory.CreateLexer(sourceText, SandyParseOptions.Default);
            InternalSyntaxToken? token;
            do
            {
                token = lexer.Lex();
                Console.WriteLine(token);
            }
            while (token != null && token.Kind != SyntaxKind.Eof);
            //var stream = (IncrementalAntlr4InputStream)lexer.Antlr4Lexer.InputStream;
            //Console.WriteLine("Affected old token range: " + lexer.AffectedOldTokenRange.a + ".." + lexer.AffectedOldTokenRange.b);
            //Console.WriteLine("Lookahead range: " + stream.OverallMinMaxLookahead);
            return lexer;
        }

        private static SandySyntaxTree Parse(string text, ImmutableArray<TextChangeRange> changes, SandySyntaxTree? oldTree)
        {
            var sourceText = SourceText.From(text);
            var oldRoot = oldTree?.GetRoot();

            var parser = (SandySyntaxParser)SandyLanguage.Instance.InternalSyntaxFactory.CreateParser(sourceText, SandyParseOptions.Default.WithIncremental(true), oldRoot, oldTree?.GetParseData(), changes);
            var newRoot = (SandySyntaxNode)parser.Parse();
            Console.WriteLine(PrintSyntaxTree(newRoot, parser));
            return SandySyntaxTree.Create(newRoot, parser.ParseData);
        }

        public static string PrintSyntaxTree(SandySyntaxNode tree, SandySyntaxParser parser)
        {
            StringBuilder buf = new StringBuilder();
            Recursive(parser, tree, buf, 0);
            return buf.ToString();
        }

        private static void Recursive(SandySyntaxParser parser, SandySyntaxNode node, StringBuilder buf, int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                buf.Append("  ");
            }
            if (parser.ParseData.TryGetIncrementalData(node.Green, out var data))
            {
#if DEBUG
                buf.Append($"[{data.Version}({data.LookaheadBefore},{data.LookaheadAfter})]");
#else
                buf.Append($"[({data.LookaheadBefore},{data.LookaheadAfter})]");
#endif
            }
            buf.Append(node.Kind);
            //buf.Append($" ({parser.GetVersion(node.Green)})");
            buf.AppendLine();
            foreach (var child in node.ChildNodesAndTokens())
            {
                if (child.IsToken)
                {
                    for (int i = 0; i < indent+1; i++)
                    {
                        buf.Append("  ");
                    }
                    buf.Append((SandySyntaxKind)child.GetKind());
                    buf.Append(": " + child.AsToken().Text);
                    buf.AppendLine();
                }
                else
                {
                    Recursive(parser, (SandySyntaxNode)child.AsNode(), buf, indent + 1);
                }
            }
        }

        private static void Intellisense(SandySyntaxTree tree, int position)
        {
            var completion = tree.LookupTokens(position);
            Console.WriteLine("Position: "+position);
            foreach (var item in completion)
            {
                if (item != SyntaxKind.None)
                {
                    Console.WriteLine("  " + item.GetValue()+ " ("+item.GetName()+")");
                }
            }
        }

        private static void Intellisense(string title, string code, int position)
        {
            Console.WriteLine(title);
            Console.WriteLine("  "+code);
            var tree = SandySyntaxTree.ParseText(code);
            var completion = tree.LookupTokens(position);
            Console.WriteLine("Position: " + position);
            foreach (var item in completion)
            {
                if (item != SyntaxKind.None)
                {
                    Console.WriteLine("  " + item.GetValue() + " (" + item.GetName() + ")");
                }
            }
        }
        //*/
        private static void EmptyFile()
        {
            Intellisense("EmptyFile", "var a = 1 + 2", 0);
        }

        private static void AfterVar()
        {
            Intellisense("AfterVar", "var a = 1 + 2", 4);
        }

        private static void AfterEquals()
        {
            Intellisense("AfterEquals", "var a = 1 + 2", 7);
        }

        private static void AfterLiteral()
        {
            Intellisense("AfterLiteral", "var a = 1 + 2", 9);
        }

        private static void AfterAddition()
        {
            Intellisense("AfterAddition", "var a = 1 + 2", 11);
        }

        //*/
    }
}
