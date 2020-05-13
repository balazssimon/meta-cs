using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class IncrementalTypeTest : IncrementalCompilationTestBase
    {
        public IncrementalTypeTest()
        {
            TestId = "IncrementalTypeTest";
        }

        [Fact]
        public void File01()
        {
            string source = @"namespace A { metamodel M; class B { string S; multi_list<object> O; C C; } class C { B B; } association B.C with C.B; }";
            SourceText oldText = null;
            TestIncrementalCompilationSyntaxTree oldTree = null;
            for (int i = 0; i < source.Length; i++)
            {
                string currentSource = source.Substring(0, i);
                try
                {
                    if (i == 0)
                    {
                        oldText = SourceText.From(currentSource);
                        oldTree = IncrementalParse(oldText, assertEmptyDiagnostics: false);
                    }
                    else
                    {
                        (oldText, oldTree) = IncrementalParseWithInsertedText((oldText, oldTree), i - 1, source.Substring(i - 1, 1), false);
                    }
                }
                catch (Exception ex)
                {
                    throw new WrappedXunitException($"Typing failed at:\r\n----\r\n{currentSource}\r\n----", ex);
                }
            }
        }
    }
}
