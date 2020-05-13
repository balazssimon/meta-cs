using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Symbols;
using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLanguageAnnotations
{
    public class UnitTest11 : LanguageAnnotationsTestBase
    {
        private const string TestId = "11";

        [Fact]
        public void File01()
        {
            var comp = Compile(TestId, "01", false);
            var diagnostics = comp.GetDiagnostics();
            Assert.NotEmpty(diagnostics);
            Assert.Equal("MM0039", diagnostics[0].Id);
        }
    }
}
