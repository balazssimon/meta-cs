using Antlr4.Runtime;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Antlr4Test.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.InternalUtilities;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;
using MetaDslx.Languages.MetaGenerator.Compilation;
using MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax;
using MetaDslx.Tests;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Immutable;
using System.IO;

namespace MetaDslx.Bootstrap.IncrementalCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            //CompileMeta("file01.txt");
            //CompileMeta("file02.txt");
            //CompileMeta("file03.txt");
            //CompileMeta("file04.txt");
            CompileMGen("file05.txt");
            //RunTest();
        }

        private static void CompileMeta(string fileName)
        {
            var source = SourceText.From(File.ReadAllText(@"..\..\..\"+ fileName));
            var syntaxTree = MetaLanguage.Instance.ParseSyntaxTree(source);
            var formatter = new DiagnosticFormatter();
            foreach (var diag in syntaxTree.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
            Console.WriteLine("----");
            var antlr4Diag = Antlr4ParseMeta(source);
            foreach (var diag in antlr4Diag)
            {
                Console.WriteLine(formatter.Format(diag));
            }
        }

        public static ImmutableArray<Diagnostic> Antlr4ParseMeta(SourceText text)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var errors = new Antlr4ErrorListener("", diagnostics);
            var lexer = new TestLexerModeLexer(new AntlrInputStream(text.ToString()));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errors);
            var parser = new TestLexerModeParser(new CommonTokenStream(lexer));
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errors);
            parser.main();
            var result = diagnostics.ToReadOnlyAndFree();
            return result;
        }

        private static void CompileMGen(string fileName)
        {
            var source = SourceText.From(File.ReadAllText(@"..\..\..\" + fileName));
            var syntaxTree = TestLexerModeLanguage.Instance.ParseSyntaxTree(source);
            var formatter = new DiagnosticFormatter();
            foreach (var diag in syntaxTree.GetDiagnostics())
            {
                Console.WriteLine(formatter.Format(diag));
            }
            Console.WriteLine("----");
            var antlr4Diag = Antlr4ParseMGen(source);
            foreach (var diag in antlr4Diag)
            {
                Console.WriteLine(formatter.Format(diag));
            }
        }

        public static ImmutableArray<Diagnostic> Antlr4ParseMGen(SourceText text)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var errors = new Antlr4ErrorListener("", diagnostics);
            var lexer = new MetaGeneratorLexer(new AntlrInputStream(text.ToString()));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errors);
            var parser = new MetaGeneratorParser(new CommonTokenStream(lexer));
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errors);
            parser.main();
            var result = diagnostics.ToReadOnlyAndFree();
            return result;
        }

        private static void RunTest()
        {
            using (var assertions = new DebugAssertUnitTestTraceListener())
            {
                try
                {
                    CallLogger.Enabled = true;
                    EditTest.InputFileDirectory = @"c:\Users\Balazs\source\repos\meta-cs\src\Test\MetaDslx.CodeAnalysis.Antlr4.Test\InputFiles\IncrementalCompilation";
                    var test = new EditTest();
                    test.SerialEdits();
                    foreach (var assertion in assertions.AssertionFailures)
                    {
                        Console.WriteLine(assertion);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    File.WriteAllText(@"..\..\..\CallLog.txt", CallLogger.Instance.GetLog());
                }
            }
        }
    }
}
