using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLexerMode
{
    public class IncrementalFileTest_MGenTest : EditTest
    {
        public IncrementalFileTest_MGenTest()
            : base("MGenTest.txt")
        {
        }
    }
    public class IncrementalFileTest_PropertyTest : EditTest
    {
        public IncrementalFileTest_PropertyTest()
            : base("PropertyTest.txt")
        {
        }
    }
    public class IncrementalFileTest_MetaModelGenerator : EditTest
    {
        public IncrementalFileTest_MetaModelGenerator()
            : base("MetaModelGenerator.txt")
        {
        }
    }
    public class IncrementalFileTest_MofModelToMetaModelGenerator : EditTest
    {
        public IncrementalFileTest_MofModelToMetaModelGenerator()
            : base("MofModelToMetaModelGenerator.txt")
        {
        }
    }
    public class IncrementalFileTest_UmlModelToMetaModelGenerator : EditTest
    {
        public IncrementalFileTest_UmlModelToMetaModelGenerator()
            : base("UmlModelToMetaModelGenerator.txt")
        {
        }
    }
    public class IncrementalFileTest_ImmutableMetaModelGenerator : EditTest
    {
        public IncrementalFileTest_ImmutableMetaModelGenerator()
            : base("ImmutableMetaModelGenerator.txt")
        {
        }
    }
    public class IncrementalFileTest_CompilerGenerator : EditTest
    {
        public IncrementalFileTest_CompilerGenerator()
            : base("CompilerGenerator.txt")
        {
        }
    }
    public class IncrementalFileTest_SoalPrinter : EditTest
    {
        public IncrementalFileTest_SoalPrinter()
            : base("SoalPrinter.txt")
        {
        }
    }
    public class IncrementalFileTest_XsdGenerator : EditTest
    {
        public IncrementalFileTest_XsdGenerator()
            : base("XsdGenerator.txt")
        {
        }
    }
    public class IncrementalFileTest_WsdlGenerator : EditTest
    {
        public IncrementalFileTest_WsdlGenerator()
            : base("WsdlGenerator.txt")
        {
        }
    }
}
