using MetaDslx.Tests;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLexerMode
{
    public class IncrementalFileTest_MGenTest : LexerModeTestBase
    {
        [Fact]
        public void MGenTest()
        {
            //int pos = 83;
            //string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MGenTest.txt").Substring(0, pos);
            //IncrementalType(source, pos - 1);
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MGenTest.txt");
            IncrementalType(source);
            //IncrementalParse(SourceText.From(source));
        }
    }
    public class IncrementalFileTest_PropertyTest : LexerModeTestBase
    {
        [Fact]
        public void PropertyTest()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\PropertyTest.txt");;
            IncrementalType(source);
        }
    }
    public class IncrementalFileTest_MetaModelGenerator : LexerModeTestBase
    {
        [Fact]
        public void MetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MetaModelGenerator.txt");
            IncrementalType(source, 50);
        }
    }
    public class IncrementalFileTest_MofModelToMetaModelGenerator : LexerModeTestBase
    {
        [Fact]
        public void MofModelToMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MofModelToMetaModelGenerator.txt");
            IncrementalType(source, 64);
        }
    }
    public class IncrementalFileTest_UmlModelToMetaModelGenerator : LexerModeTestBase
    {
        [Fact]
        public void UmlModelToMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\UmlModelToMetaModelGenerator.txt");
            IncrementalType(source, 64);
        }
    }
    public class IncrementalFileTest_ImmutableMetaModelGenerator : LexerModeTestBase
    {
        [Fact]
        public void ImmutableMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\ImmutableMetaModelGenerator.txt");
            IncrementalType(source, 560);
        }
    }
    public class IncrementalFileTest_CompilerGenerator : LexerModeTestBase
    {
        [Fact]
        public void CompilerGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\CompilerGenerator.txt");
            IncrementalType(source, 20000);
        }
    }
    public class IncrementalFileTest_SoalPrinter : LexerModeTestBase
    {
        [Fact]
        public void SoalPrinter()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\SoalPrinter.txt");
            IncrementalType(source, 70);
        }
    }
    public class IncrementalFileTest_XsdGenerator : LexerModeTestBase
    {
        [Fact]
        public void XsdGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\XsdGenerator.txt");
            IncrementalType(source, 120);
        }
    }
    public class IncrementalFileTest_WsdlGenerator : LexerModeTestBase
    {
        [Fact]
        public void WsdlGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\WsdlGenerator.txt");
            IncrementalType(source, 100);
        }
    }
}
