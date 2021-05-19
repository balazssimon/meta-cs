﻿using Antlr4.Runtime;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Bootstrap.IncrementalCompiler
{
    public class TestMGenCompiler : CompilerBase
    {
        public static void Compile(string fileName)
        {
            var source = SourceText.From(File.ReadAllText(@"..\..\..\" + fileName));

            var lexer = new TestLexerModeSyntaxLexer(source, TestLexerModeParseOptions.Default);
            var tokens = lexer.GetAllTokens();
            Console.WriteLine("Number of tokens: " + tokens.Count);

            var syntaxTree = TestLexerModeLanguage.Instance.ParseSyntaxTree(source);
            var antlr4Diags = Antlr4Parse(source);
            PrintResults(source, syntaxTree, antlr4Diags);
        }

        public static void Type(string fileName)
        {
            var options = TestLexerModeLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(string.Empty);
            var syntaxTree1 = TestLexerModeLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4Parse(source1);
            Console.WriteLine("Empty");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < code.Length; ++i)
            {
                Console.WriteLine("Length=" + i);
                var source2 = source1.WithChanges(new TextChange(new TextSpan(i, 0), code[i].ToString()));
                var syntaxTree2 = (TestLexerModeSyntaxTree)syntaxTree1.WithChangedText(source2);
                var antlr4Diags2 = Antlr4Parse(source2);
                if (code[i] != '\r') PrintResults(source2, syntaxTree2, antlr4Diags2, true);
                source1 = source2;
                syntaxTree1 = syntaxTree2;
            }
        }

        public static void SerialEdit(string fileName)
        {
            var options = TestLexerModeLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(code);
            var syntaxTree1 = (TestLexerModeSyntaxTree)TestLexerModeLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4Parse(source1);
            Console.WriteLine("Original");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < code.Length; ++i)
            {
                Console.WriteLine("Position=" + i);
                var start = i;
                var length = 1;
                (source1, syntaxTree1) = SingleEdit(source1, syntaxTree1, start, length, code);
            }
        }

        public static void RandomEdit(string fileName)
        {
            var rnd = new Random(13);
            var count = 1000;
            var options = TestLexerModeLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(code);
            var syntaxTree1 = (TestLexerModeSyntaxTree)TestLexerModeLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4Parse(source1);
            Console.WriteLine("Original");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < count; ++i)
            {
                var start = rnd.Next(code.Length);
                var length = rnd.Next(code.Length - start + 1);
                Console.WriteLine($"i={i}, Start={start}, Length={length}");
                if (start > 0 && code[start - 1] == '\r') continue;
                (source1, syntaxTree1) = SingleEdit(source1, syntaxTree1, start, length, code);
            }
        }

        private static (SourceText source2, TestLexerModeSyntaxTree syntaxTree2) SingleEdit(SourceText source1, TestLexerModeSyntaxTree syntaxTree1, int start, int length, string code)
        {
            var source2 = source1.WithChanges(new TextChange(new TextSpan(start, length), string.Empty));
            var syntaxTree2 = (TestLexerModeSyntaxTree)syntaxTree1.WithChangedText(source2);
            var antlr4Diags2 = Antlr4Parse(source2);
            PrintResults(source2, syntaxTree2, antlr4Diags2, true, "  DELETE:");
            source1 = source2;
            syntaxTree1 = syntaxTree2;
            source2 = source1.WithChanges(new TextChange(new TextSpan(start, 0), code.Substring(start, length)));
            syntaxTree2 = (TestLexerModeSyntaxTree)syntaxTree1.WithChangedText(source2);
            antlr4Diags2 = Antlr4Parse(source2);
            PrintResults(source2, syntaxTree2, antlr4Diags2, true, "  INSERT:");
            return (source2, syntaxTree2);
        }

        public static ImmutableArray<Diagnostic> Antlr4Parse(SourceText text)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var errors = new Antlr4ErrorListener("", diagnostics);
            var lexer = new TestLexerModeLexer(new AntlrInputStream(text.ToString()));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errors);
            var parser = new TestLexerModeParser(new CommonTokenStream(lexer));
            parser.ErrorHandler = new MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.DefaultErrorStrategy();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errors);
            parser.main();
            var result = diagnostics.ToReadOnlyAndFree();
            return result;
        }

    }
}