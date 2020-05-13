using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class TypeTest : IncrementalCompilationTestBase
    {
        public TypeTest()
        {
            TestId = "TypeTest";
        }

        [Fact]
        public void File01()
        {
            string source = @"namespace A { metamodel M; class B { string S; multi_list<object> O; C C; } class C { B B; } association B.C with C.B; }";
            for (int i = 0; i < source.Length; i++)
            {
                string currentSource = source.Substring(0, i);
                try
                {
                    Parse(SourceText.From(currentSource), false);
                }
                catch (Exception ex)
                {
                    throw new WrappedXunitException($"Typing failed at:\r\n----\r\n{currentSource}\r\n----", ex);
                }
            }
        }
    }
}
