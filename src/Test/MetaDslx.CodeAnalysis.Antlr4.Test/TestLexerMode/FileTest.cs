using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLexerMode
{
    public class FileTest_MGenTest : TypeTest
    {
        [Fact]
        public void MGenTest()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MGenTest.txt");
            Parse(SourceText.From(source));
            //Type(source);
        }
    }
    public class FileTest_PropertyTest : TypeTest
    {
        [Fact]
        public void PropertyTest()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\PropertyTest.txt");
            Type(source);
        }
    }
    public class FileTest_MetaModelGenerator : TypeTest
    {
        [Fact]
        public void MetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MetaModelGenerator.txt");
            Type(source, 50);
        }
    }
    public class FileTest_MofModelToMetaModelGenerator : TypeTest
    {
        [Fact]
        public void MofModelToMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MofModelToMetaModelGenerator.txt");
            Type(source, 64);
        }
    }
    public class FileTest_UmlModelToMetaModelGenerator : TypeTest
    {
        [Fact]
        public void UmlModelToMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\UmlModelToMetaModelGenerator.txt");
            Type(source, 64);
        }
    }
    public class FileTest_ImmutableMetaModelGenerator : TypeTest
    {
        [Fact]
        public void ImmutableMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\ImmutableMetaModelGenerator.txt");
            Type(source, 560);
        }
    }
    public class FileTest_CompilerGenerator : TypeTest
    {
        [Fact]
        public void CompilerGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\CompilerGenerator.txt");
            Type(source, 20000);
        }
    }
    public class FileTest_SoalPrinter : TypeTest
    {
        [Fact]
        public void SoalPrinter()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\SoalPrinter.txt");
            Type(source, 70);
        }
    }
    public class FileTest_XsdGenerator : TypeTest
    {
        [Fact]
        public void XsdGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\XsdGenerator.txt");
            Type(source, 120);
        }
    }
    public class FileTest_WsdlGenerator : TypeTest
    {
        [Fact]
        public void WsdlGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\WsdlGenerator.txt");
            Type(source, 100);
        }
    }
}
