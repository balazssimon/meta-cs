using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class ErrorTest : IncrementalCompilationTestBase
    {
        public ErrorTest()
        {
            TestId = "ErrorTest";
        }

        [Fact]
        public void File01()
        {
            var text = @"namespace A {}";
            var tree = Parse(SourceText.From(text), false);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            Assert.Equal(1, diagnostics.Length);
        }

        [Fact]
        public void File02()
        {
            var text = @"namespace A {";
            var tree = Parse(SourceText.From(text), false);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            Assert.Equal(1, diagnostics.Length);
        }

        [Fact]
        public void File03()
        {
            var text = @"namespace A";
            var tree = Parse(SourceText.From(text), false);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            Assert.Equal(1, diagnostics.Length);
        }

        [Fact]
        public void File04()
        {
            var text = @"namespace";
            var tree = Parse(SourceText.From(text), false);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            Assert.Equal(1, diagnostics.Length);
        }

        [Fact]
        public void File05()
        {
            var text = @"namespacex A {}";
            var tree = Parse(SourceText.From(text), false);
            var diagnostics = tree.GetDiagnostics().ToImmutableArray();
            Assert.Equal(1, diagnostics.Length);
        }
    }
}
