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
    public class IncrementalCompiler
    {
        public void Type(string source, int delta = 1)
        {
            SourceText oldText = null;
            TestLexerModeSyntaxTree oldTree = null;
            bool reachedEnd = false;
            for (int i = 0; !reachedEnd; i += delta)
            {
                var currentDelta = delta;
                if (i >= source.Length)
                {
                    currentDelta = source.Length - (i - delta);
                    i = source.Length;
                }
                string currentSource = source.Substring(0, i);
                //try
                {
                    if (i == 0)
                    {
                        oldText = SourceText.From(currentSource);
                        oldTree = IncrementalParse(oldText, assertEmptyDiagnostics: false);
                    }
                    else
                    {
                        (oldText, oldTree) = IncrementalParseWithInsertedText((oldText, oldTree), i - currentDelta, source.Substring(i - currentDelta, currentDelta), assertEmptyDiagnostics: false);
                    }
                }
                /*catch (Exception ex)
                {
                    Console.WriteLine($"Typing failed at position {i}:\r\n----\r\n{currentSource}\r\n----\r\nOriginal source is:\r\n----\r\n{source}\r\n----\r\n");
                    throw;
                }*/
                if (i == source.Length) reachedEnd = true;
                Console.WriteLine(i+"/"+source.Length);
            }
        }

        protected ImmutableArray<Diagnostic> Antlr4Parse(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var errors = new Antlr4ErrorListener("", diagnostics);
            var lexer = new TestLexerModeLexer(new AntlrInputStream(text.ToString()));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errors);
            var parser = new TestLexerModeParser(new CommonTokenStream(lexer));
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errors);
            parser.main();
            var result = diagnostics.ToReadOnlyAndFree();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(result);
            return result;
        }

        public TestLexerModeSyntaxTree Parse(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var options = TestLexerModeParseOptions.Default.WithIncremental(false);
            var tree = TestLexerModeSyntaxTree.ParseText(text, options);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(diagnostics);
            var antlr4Diagnostics = Antlr4Parse(text, assertEmptyDiagnostics);
            Assert.Equal(antlr4Diagnostics.Length, diagnostics.Length);
            return tree;
        }

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

        protected (SourceText, TestLexerModeSyntaxTree) IncrementalParseWithInsertedText((SourceText oldText, TestLexerModeSyntaxTree oldTree) old, int position, string insertedText, bool assertEmptyDiagnostics = true)
        {
            var text = old.oldText.WithChanges(new TextChange(TextSpan.FromBounds(position, position), insertedText));
            var tree = IncrementalParse(text, old.oldTree, assertEmptyDiagnostics);
            return (text, tree);
        }

        protected (SourceText, TestLexerModeSyntaxTree) IncrementalParseWithDeletedText((SourceText oldText, TestLexerModeSyntaxTree oldTree) old, int position, int length, bool assertEmptyDiagnostics = true)
        {
            var text = old.oldText.WithChanges(new TextChange(TextSpan.FromBounds(position, position + length), string.Empty));
            var tree = IncrementalParse(text, old.oldTree, assertEmptyDiagnostics);
            return (text, tree);
        }

        protected TestLexerModeCompilation Compile(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var st = Parse(text, assertEmptyDiagnostics);
            var options = new TestLexerModeCompilationOptions(TestLexerModeLanguage.Instance, Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility/*, concurrentBuild: false*/);
            var comp = TestLexerModeCompilation.Create("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp.GetDiagnostics());
            return comp;
        }

        protected TestLexerModeCompilation IncrementalCompile(SourceText text, TestLexerModeSyntaxTree oldTree = null, bool assertEmptyDiagnostics = true)
        {
            var st = IncrementalParse(text, oldTree, assertEmptyDiagnostics);
            var options = new TestLexerModeCompilationOptions(TestLexerModeLanguage.Instance, Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility/*, concurrentBuild: false*/);
            var comp = TestLexerModeCompilation.Create("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp.GetDiagnostics());
            return comp;
        }

        protected void AssertEmptyDiagnostics(IEnumerable<Diagnostic> diagnostics)
        {
            Assert.Null(diagnostics.FirstOrDefault());
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

        private class Antlr4ErrorListener : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
        {
            private string _filePath;
            private DiagnosticBag _diagnostics;

            public Antlr4ErrorListener(string filePath, DiagnosticBag diagnostics)
            {
                _filePath = filePath;
                _diagnostics = diagnostics;
            }

            public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] int offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
            {
                _diagnostics.Add(TestLexerModeErrorCode.ERR_GeneralError.ToDiagnostic(Location.Create(_filePath, TextSpan.FromBounds(recognizer.InputStream.Index, recognizer.InputStream.Index + 1), new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine))), msg));
            }

            public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
            {
                _diagnostics.Add(TestLexerModeErrorCode.ERR_GeneralError.ToDiagnostic(Location.Create(_filePath, TextSpan.FromBounds(offendingSymbol.StartIndex, offendingSymbol.StopIndex + 1), new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine))), msg));
            }
        }

    }
}
