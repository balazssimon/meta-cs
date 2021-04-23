using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class EditTest : IncrementalCompilationTestBase
    {
        private SourceText source;
        private Random rnd;

        public EditTest()
        {
            source = SourceText.From(File.ReadAllText(Path.Combine(InputFileDirectory, "Entities.txt")));
            rnd = new Random();
        }

        [Fact]
        public void SerialEdits()
        {
            var src = (source, (LanguageSyntaxTree)null);
            for (int i = 0; i < source.Length; i++)
            {
                var start = i;
                var length = 1;
                src = SingleEdit(src, start, length);
            }
        }

        [Fact]
        public void RandomEdits()
        {
            var src = (source, (LanguageSyntaxTree)null);
            for (int i = 0; i < 10000; i++)
            {
                var start = rnd.Next(src.source.Length);
                var length = rnd.Next(src.source.Length - start);
                src = SingleEdit(src, start, length);
            }
        }

        [Fact]
        public void Test01()
        {
            var src1 = SingleEdit(source, 36, 1);
            var src2 = SingleEdit(src1, 37, 1);
        }

        [Fact]
        public void Test02()
        {
            SingleEdit(source, 823, 10);
        }

        [Fact]
        public void Test03()
        {
            SingleEdit(source, 418, 27);
        }
    }
}
