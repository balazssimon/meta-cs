using MetaDslx.Tests;
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

        protected void Type(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                string currentSource = source.Substring(0, i);
                try
                {
                    Parse(SourceText.From(currentSource), false);
                }
                catch (Exception ex)
                {
                    throw new WrappedXunitException($"Typing failed at position {i}:\r\n----\r\n{currentSource}\r\n----\r\nOriginal source is:\r\n----\r\n{source}\r\n----\r\n", ex);
                }
            }
        }

    }
}
