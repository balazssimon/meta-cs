using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class ParseTest : IncrementalCompilationTestBase
    {
        public ParseTest()
        {
            TestId = "ParseTest";
        }

        [Fact]
        public void File01()
        {
            var text = @"namespace A { metamodel M; }";
            Parse(SourceText.From(text));
        }

        [Fact]
        public void File02()
        {
            var text = @"namespace A { metamodel M; class B {} }";
            Parse(SourceText.From(text));
        }

        [Fact]
        public void File03()
        {
            var text = @"namespace A { metamodel M; class B { string S; } }";
            Parse(SourceText.From(text));
        }
    }

}
