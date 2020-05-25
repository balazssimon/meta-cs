using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class RandomTest : IncrementalCompilationTestBase
    {
        private const int TestCount = 10;
        private const int SourceLength = 1000;

        private RandomSourceGenerator _sourceGenerator = new RandomSourceGenerator();
        private static Random s_random = new Random();

        [Fact]
        public void TypeRandomSources()
        {
            int count = TestCount;
            int length = SourceLength;
            for (int i = 0; i < count; i++)
            {
                var source = _sourceGenerator.NextSource(s_random.Next(length));
                Type(source);
            }
        }

        [Fact]
        public void ParseLongSource()
        {
            int length = 100000;
            var source = _sourceGenerator.NextSource(length);
            Parse(SourceText.From(source), false);
        }


        [Fact]
        public void ParseVeryLongSource()
        {
            int length = 1000000;
            var source = _sourceGenerator.NextSource(length);
            Parse(SourceText.From(source), false);
        }

        [Fact]
        public void File01()
        {
            var pos = 39;
            string source = @"namespace A { metamodel M; class B { string S; multi_list<object> O; C C; } class C { B B; } association B.C with C.B; }".Substring(0, pos);
            Type(source, pos-1);
        }

        [Fact]
        public void File02()
        {
            string source = @"namespace A { metamodel M; class B { string S; multi_list<object> O; C C; } association B.C with C.B; class C { B B; } }";
            Type(source);
        }

        [Fact]
        public void File03()
        {
            string source = @"namespace A { metamodel M; association B.C with C.B; class B { string S; multi_list<object> O; C C; } class C { B B; } }";
            Type(source);
        }

        [Fact]
        public void File04()
        {
            string source = @"    [   91103     91109  
    subsets   
     bool     +    //9799
    
     byte";
            Type(source);
        }

        [Fact]
        public void File05()
        {
            string source = @" >>=  	 sd ]          `5 <   	 +   ia";
            Type(source);
        }

    }
}
