using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class IncrementalCompilationTestBase : DebugAssertUnitTest
    {
        protected string TestId = string.Empty;

        protected ImmutableArray<Diagnostic> Antlr4Parse(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var errors = new Antlr4ErrorListener(TestId, diagnostics);
            var lexer = new TestIncrementalCompilationLexer(new AntlrInputStream(text.ToString()));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errors);
            var parser = new TestIncrementalCompilationParser(new CommonTokenStream(lexer));
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errors);
            parser.main();
            var result = diagnostics.ToReadOnlyAndFree();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(result);
            return result;
        }

        protected TestIncrementalCompilationSyntaxTree Parse(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var options = TestIncrementalCompilationParseOptions.Default.WithIncremental(false);
            var tree = TestIncrementalCompilationSyntaxTree.ParseText(text, options);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(diagnostics);
            var antlr4Diagnostics = Antlr4Parse(text, assertEmptyDiagnostics);
            Assert.Equal(diagnostics.Length, antlr4Diagnostics.Length);
            return tree;
        }

        protected TestIncrementalCompilationSyntaxTree IncrementalParse(SourceText text, TestIncrementalCompilationSyntaxTree oldTree = null, bool assertEmptyDiagnostics = true)
        {
            var options = TestIncrementalCompilationParseOptions.Default.WithIncremental(true);
            var tree = oldTree != null ? (TestIncrementalCompilationSyntaxTree)oldTree.WithChangedText(text) : TestIncrementalCompilationSyntaxTree.ParseText(text, options);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(diagnostics);
            var antlr4Diagnostics = Antlr4Parse(text, assertEmptyDiagnostics);
            Assert.Equal(diagnostics.Length, antlr4Diagnostics.Length);
            return tree;
        }

        protected (SourceText, TestIncrementalCompilationSyntaxTree) IncrementalParseWithInsertedText((SourceText oldText, TestIncrementalCompilationSyntaxTree oldTree) old, int position, string insertedText, bool assertEmptyDiagnostics = true)
        {
            var text = old.oldText.WithChanges(new TextChange(TextSpan.FromBounds(position, position), insertedText));
            var tree = IncrementalParse(text, old.oldTree);
            return (text, tree);
        }

        protected (SourceText, TestIncrementalCompilationSyntaxTree) IncrementalParseWithDeletedText((SourceText oldText, TestIncrementalCompilationSyntaxTree oldTree) old, int position, int length, bool assertEmptyDiagnostics = true)
        {
            var text = old.oldText.WithChanges(new TextChange(TextSpan.FromBounds(position, position + length), string.Empty));
            var tree = IncrementalParse(text, old.oldTree);
            return (text, tree);
        }

        protected TestIncrementalCompilationCompilation Compile(SourceText text, bool assertEmptyDiagnostics = true)
        {
            var st = Parse(text, assertEmptyDiagnostics);
            var options = new TestIncrementalCompilationCompilationOptions(TestIncrementalCompilationLanguage.Instance, Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility/*, concurrentBuild: false*/);
            var comp = TestIncrementalCompilationCompilation.Create("Test").WithOptions(options).AddSyntaxTrees(st);
            comp.ForceComplete();
            if (assertEmptyDiagnostics) AssertEmptyDiagnostics(comp.GetDiagnostics());
            return comp;
        }

        protected TestIncrementalCompilationCompilation IncrementalCompile(SourceText text, TestIncrementalCompilationSyntaxTree oldTree = null, bool assertEmptyDiagnostics = true)
        {
            var st = IncrementalParse(text, oldTree, assertEmptyDiagnostics);
            var options = new TestIncrementalCompilationCompilationOptions(TestIncrementalCompilationLanguage.Instance, Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary, topLevelBinderFlags: (BinderFlags)BinderFlags.IgnoreAccessibility/*, concurrentBuild: false*/);
            var comp = TestIncrementalCompilationCompilation.Create("Test").WithOptions(options).AddSyntaxTrees(st);
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
                _diagnostics.Add(TestIncrementalCompilationErrorCode.ERR_GeneralError.ToDiagnostic(Location.Create(_filePath, TextSpan.FromBounds(recognizer.InputStream.Index, recognizer.InputStream.Index+1), new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine))), msg));
            }

            public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
            {
                _diagnostics.Add(TestIncrementalCompilationErrorCode.ERR_GeneralError.ToDiagnostic(Location.Create(_filePath, TextSpan.FromBounds(offendingSymbol.StartIndex, offendingSymbol.StopIndex+1), new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine))), msg));
            }
        }
    }
}
