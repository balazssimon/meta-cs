using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace MetaDslx.CodeAnalysis.Antlr4Test.TestLexerMode
{
    public class FileTest : TypeTest
    {
        [Fact]
        public void MGenTest()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MGenTest.txt");
            Type(source);
        }

        [Fact]
        public void PropertyTest()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\PropertyTest.txt");
            Type(source);
            //Parse(SourceText.From(source), false);
        }

        [Fact]
        public void MetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MetaModelGenerator.txt");
            Type(source);
        }

        [Fact]
        public void MofModelToMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\MofModelToMetaModelGenerator.txt");
            Type(source);
        }

        [Fact]
        public void UmlModelToMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\UmlModelToMetaModelGenerator.txt");
            Type(source);
        }

        [Fact]
        public void ImmutableMetaModelGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\ImmutableMetaModelGenerator.txt");
            Type(source);
        }

        [Fact]
        public void CompilerGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\CompilerGenerator.txt");
            Type(source);
        }

        [Fact]
        public void SoalPrinter()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\SoalPrinter.txt");
            Type(source);
        }

        [Fact]
        public void XsdGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\XsdGenerator.txt");
            Type(source);
        }

        [Fact]
        public void WsdlGenerator()
        {
            string source = File.ReadAllText($@"..\..\..\InputFiles\LexerMode\WsdlGenerator.txt");
            Type(source);
        }

    }
}
