using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.InternalUtilities;
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
                try
                {
                    CallLogger.Instance.Log("===========================================");
                    CallLogger.Instance.Log($"Source (length={i}):");
                    CallLogger.Instance.Log(currentSource);
                    CallLogger.Instance.Log("===========================================");
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
                catch (Exception ex)
                {
                    Console.WriteLine($"Typing failed at position {i}:\r\n----\r\n{currentSource}\r\n----\r\nOriginal source is:\r\n----\r\n{source}\r\n----\r\n", ex);
                    throw;
                }
                if (i == source.Length) reachedEnd = true;
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

            Console.WriteLine("Text length: "+text.Length);
            var formatter = new DiagnosticFormatter();
            Console.WriteLine("Antlr4 diagnostics:");
            foreach (var diag in antlr4Diagnostics)
            {
                Console.WriteLine("  "+formatter.Format(diag));
            }
            Console.WriteLine("MetaDslx diagnostics:");
            foreach (var diag in diagnostics)
            {
                Console.WriteLine("  " + formatter.Format(diag));
            }
            Console.WriteLine();

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
