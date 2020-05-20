using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLexerMode
{
    public class IncrementalFileTest_MGenTest : IncrementalTypeTest
    {
        [Fact]
        public void MGenTest()
        {
            //int pos = 83;
            //string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MGenTest.txt").Substring(0, pos);
            //Type(source, pos - 1);
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MGenTest.txt");
            Type(source);
            //Parse(SourceText.From(source));
        }
    }
    public class IncrementalFileTest_PropertyTest : IncrementalTypeTest
    {
        [Fact]
        public void PropertyTest()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\PropertyTest.txt");;
            Type(source);
        }
    }
    public class IncrementalFileTest_MetaModelGenerator : IncrementalTypeTest
    {
        [Fact]
        public void MetaModelGenerator()
        {
            var pos = 451;
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MetaModelGenerator.txt").Substring(0, pos);
            Type(source, pos - 1);
        }
    }
    public class IncrementalFileTest_MofModelToMetaModelGenerator : IncrementalTypeTest
    {
        [Fact]
        public void MofModelToMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MofModelToMetaModelGenerator.txt");
            Type(source, 64);
        }
    }
    public class IncrementalFileTest_UmlModelToMetaModelGenerator : IncrementalTypeTest
    {
        [Fact]
        public void UmlModelToMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\UmlModelToMetaModelGenerator.txt");
            Type(source, 64);
        }
    }
    public class IncrementalFileTest_ImmutableMetaModelGenerator : IncrementalTypeTest
    {
        [Fact]
        public void ImmutableMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\ImmutableMetaModelGenerator.txt");
            Type(source, 560);
        }
    }
    public class IncrementalFileTest_CompilerGenerator : IncrementalTypeTest
    {
        [Fact]
        public void CompilerGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\CompilerGenerator.txt");
            Type(source, 20000);
        }
    }
    public class IncrementalFileTest_SoalPrinter : IncrementalTypeTest
    {
        [Fact]
        public void SoalPrinter()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\SoalPrinter.txt");
            Type(source, 70);
        }
    }
    public class IncrementalFileTest_XsdGenerator : IncrementalTypeTest
    {
        [Fact]
        public void XsdGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\XsdGenerator.txt");
            Type(source, 120);
        }
    }
    public class IncrementalFileTest_WsdlGenerator : IncrementalTypeTest
    {
        [Fact]
        public void WsdlGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\WsdlGenerator.txt");
            Type(source, 100);
        }
    }
}
