using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
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

        protected void Type(string source, int delta = 1)
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
                    //throw;
                    throw new WrappedXunitException($"Typing failed at position {i}:\r\n----\r\n{currentSource}\r\n----\r\nOriginal source is:\r\n----\r\n{source}\r\n----\r\n", ex);
                }
                if (i == source.Length) reachedEnd = true;
            }
        }



    }
}
