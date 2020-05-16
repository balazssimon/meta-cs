using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLexerMode
{
    public class IncrementalTypeTest : IncrementalCompilationTestBase
    {
        public IncrementalTypeTest()
        {
            TestId = "IncrementalTypeTest";
        }

        protected void Type(string source)
        {
            SourceText oldText = null;
            TestLexerModeSyntaxTree oldTree = null;
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
                        (oldText, oldTree) = IncrementalParseWithInsertedText((oldText, oldTree), i - 1, source.Substring(i - 1, 1), assertEmptyDiagnostics: false);
                    }
                }
                catch (Exception ex)
                {
                    throw new WrappedXunitException($"Typing failed at position {i}:\r\n----\r\n{currentSource}\r\n----\r\nOriginal source is:\r\n----\r\n{source}\r\n----\r\n", ex);
                }
            }
        }



    }
}
