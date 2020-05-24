using MetaDslx.Tests;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLexerMode
{
    public class TypeTest : IncrementalCompilationTestBase
    {
        public TypeTest()
        {
            TestId = "TypeTest";
        }

        protected void Type(string source, int delta = 1)
        {
            bool last = false;
            int i = 0;
            while (i <= source.Length && !last)
            {
                if (i >= source.Length)
                {
                    i = source.Length;
                    last = true;
                }
                string currentSource = source.Substring(0, i);
                try
                {
                    Parse(SourceText.From(currentSource), false);
                }
                catch (Exception ex)
                {
                    throw new WrappedXunitException($"Typing failed at position {i}:\r\n----\r\n{currentSource}\r\n----\r\nOriginal source is:\r\n----\r\n{source}\r\n----\r\n", ex);
                }
                i += delta;
            }
        }

    }
}
