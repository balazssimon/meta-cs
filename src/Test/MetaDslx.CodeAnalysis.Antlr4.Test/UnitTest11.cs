using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Symbols;
using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test
{
    public class UnitTest11 : TestLangOneTestBase
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
