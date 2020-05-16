using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation
{
    public class IncrementalRandomTest : IncrementalTypeTest
    {
        private const int TestCount = 100;
        private const int SourceLength = 10;

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
        public void File01()
        {
            string source = @"namespace A { metamodel M; class B { string S; multi_list<object> O; C C; } class C { B B; } association B.C with C.B; }";
            Type(source);
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
            var source = @"    [   
     ++
    108107     _118 
     	  		116118	  
     
    *=   /*116111*/ //104103
     ";
            Type(source);
        }


        [Fact]
        public void File05()
        {
            string source = @"    m7     cE  	//x2
     //h_
       
      \_ 
    
       	 @' lazy       | 	 pS";
            Type(source);
        }

    }
}
