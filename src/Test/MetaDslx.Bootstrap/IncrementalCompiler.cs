using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.InternalUtilities;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.Bootstrap
{
    public class IncrementalCompiler : Antlr4RoslynTestBase
    {
        public override Language Language => TestLexerModeLanguage.Instance;

        public TestLexerModeSyntaxTree IncrementalParse(SourceText text, TestLexerModeSyntaxTree oldTree = null, bool assertEmptyDiagnostics = true)
        {
            var options = TestLexerModeParseOptions.Default.WithIncremental(true);
            var tree = oldTree != null ? (TestLexerModeSyntaxTree)oldTree.WithChangedText(text) : TestLexerModeSyntaxTree.ParseText(text, options);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(diagnostics);
            var antlr4Diagnostics = Antlr4Parse(text, assertEmptyDiagnostics);

            var wasEnabled = CallLogger.Enabled;
            CallLogger.Enabled = true;

            CallLogger.Instance.Log("===========================================");
            CallLogger.Instance.Log("Text length: " + text.Length);
            CallLogger.Instance.Log("----");
            CallLogger.Instance.Log(text);
            CallLogger.Instance.Log("----");
            CallLogger.Instance.Log(PrintSyntaxTree(tree));
            CallLogger.Instance.Log("===========================================");

            var formatter = new DiagnosticFormatter();
            CallLogger.Instance.Log("Antlr4 diagnostics:");
            foreach (var diag in antlr4Diagnostics)
            {
                CallLogger.Instance.Log("  "+formatter.Format(diag));
            }
            CallLogger.Instance.Log("MetaDslx diagnostics:");
            foreach (var diag in diagnostics)
            {
                CallLogger.Instance.Log("  " + formatter.Format(diag));
            }
            CallLogger.Instance.Log("----");

            CallLogger.Enabled = wasEnabled;

            Assert.Equal(antlr4Diagnostics.Length, diagnostics.Length);
            return tree;
        }

        public static string PrintSyntaxTree(LanguageSyntaxTree tree)
        {
            StringBuilder buf = new StringBuilder();
            PrintSyntaxTreeRecursive((LanguageSyntaxNode)tree.GetRoot(), buf, 0);
            return buf.ToString();
        }

        private static void PrintSyntaxTreeRecursive(LanguageSyntaxNode node, StringBuilder buf, int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                buf.Append("  ");
            }
            var annot = SyntaxParser.GetNodeAnnotation(node.Green);
            if (annot != null)
            {
#if DEBUG
                buf.Append($"[{annot.Version} (startState={((Antlr4ParserState)annot.StartState).State},endState={((Antlr4ParserState)annot.EndState).State},ltb={annot.LookaheadTokensBefore},lta={annot.LookaheadTokensAfter},lb={annot.LookaheadBefore},la={annot.LookaheadAfter})] ");
#else
                buf.Append($"[(startState={((Antlr4ParserState)annot.StartState).State},endState={((Antlr4ParserState)annot.EndState).State},ltb={annot.LookaheadTokensBefore},lta={annot.LookaheadTokensAfter},lb={annot.LookaheadBefore},la={annot.LookaheadAfter})] ");
#endif
            }
            buf.Append(node.Kind);
            buf.AppendLine();
            foreach (var child in node.ChildNodesAndTokens())
            {
                if (child.IsToken)
                {
                    var token = child.AsToken();
                    var tokenAnnot = SyntaxLexer.GetTokenAnnotation(token.Node);
                    for (int i = 0; i < indent + 1; i++)
                    {
                        buf.Append("  ");
                    }
                    if (tokenAnnot != null)
                    {
                        buf.Append($"[(startMode={((Antlr4LexerMode)tokenAnnot.StartMode)?.Mode ?? 0},endState={((Antlr4LexerMode)tokenAnnot.EndMode)?.Mode ?? 0})] ");
                    }
                    else
                    {
                        buf.Append($"[(startMode=0,endState=0)] ");
                    }
                    buf.Append(child.GetKind());
                    buf.Append(": " + token.Text);
                    buf.AppendLine();
                }
                else
                {
                    PrintSyntaxTreeRecursive((LanguageSyntaxNode)child.AsNode(), buf, indent + 1);
                }
            }
        }

        public override Lexer CreateAntlr4Lexer(ICharStream stream)
        {
            return new TestLexerModeLexer(stream);
        }

        public override Parser CreateAntlr4Parser(ITokenStream stream)
        {
            return new TestLexerModeParser(stream);
        }

        public override ParserRuleContext Antlr4MainRule(Parser parser)
        {
            return ((TestLexerModeParser)parser).main();
        }

    }
}
