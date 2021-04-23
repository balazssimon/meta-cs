using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class IncrementalParseTest : IncrementalCompilationTestBase
    {
        public IncrementalParseTest()
        {
            TestId = "IncrementalParseTest";
        }

        [Fact]
        public (SourceText, LanguageSyntaxTree) File01()
        {
            var source = @"namespace A { metamodel M; }";
            var text = SourceText.From(source);
            var tree = IncrementalParse(text);
            return (text, tree);
        }

        [Fact]
        public (SourceText, LanguageSyntaxTree) File02()
        {
            return IncrementalParseWithInsertedText(File01(), 27, @"class B {} ");
        }

        [Fact]
        public (SourceText, LanguageSyntaxTree) File03()
        {
            return IncrementalParseWithInsertedText(File02(), 36, @" string S; ");
        }

        [Fact]
        public (SourceText, LanguageSyntaxTree) File04()
        {
            return IncrementalParseWithDeletedText(File03(), 36, 11);
        }

        [Fact]
        public (SourceText, LanguageSyntaxTree) File05()
        {
            return IncrementalParseWithDeletedText(File04(), 27, 11);
        }
    }
}
