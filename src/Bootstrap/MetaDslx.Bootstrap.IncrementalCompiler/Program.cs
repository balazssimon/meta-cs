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
using System.Linq;

namespace MetaDslx.Bootstrap.IncrementalCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            CompileMGen("mgen01.txt");
        }

        private static void CompileMeta(string fileName)
        {
            var source = SourceText.From(File.ReadAllText(@"..\..\..\"+ fileName));
            var syntaxTree = MetaLanguage.Instance.ParseSyntaxTree(source);
            var antlr4Diags = Antlr4ParseMeta(source);
            PrintResults(source, syntaxTree, antlr4Diags);
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
            var antlr4Diags = Antlr4ParseMGen(source);
            PrintResults(source, syntaxTree, antlr4Diags);
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

        private static bool CheckDiagnostics(ImmutableArray<Diagnostic> antlr4Diagnostics, ImmutableArray<Diagnostic> diagnostics)
        {
            var formatter = new DiagnosticFormatter();
            var diagnosticsList = diagnostics.Select(d => formatter.Format(d)).OrderBy(d => d).ToList();
            var antlr4DiagnosticsList = antlr4Diagnostics.Select(d => formatter.Format(d)).OrderBy(d => d).ToList();
            var lastIndex = Math.Min(antlr4Diagnostics.Length, diagnostics.Length);
            for (int i = 0; i < lastIndex; i++)
            {
                if (antlr4DiagnosticsList[i] != diagnosticsList[i]) return false;
            }
            if (lastIndex < antlr4Diagnostics.Length)
            {
                return false;
            }
            return antlr4Diagnostics.Length == diagnostics.Length;
        }

        private static void PrintResults(SourceText source, SyntaxTree syntaxTree, ImmutableArray<Diagnostic> antlr4Diags)
        {
            Console.WriteLine("==== diagnostics ====");
            var formatter = new DiagnosticFormatter();
            var diags = syntaxTree.GetDiagnostics().ToImmutableArray();
            foreach (var diag in diags)
            {
                Console.WriteLine(formatter.Format(diag));
            }
            Console.WriteLine("---------------------");
            foreach (var diag in antlr4Diags)
            {
                Console.WriteLine(formatter.Format(diag));
            }
            Console.WriteLine("====== source =======");
            Console.WriteLine(source.ToString());
            Console.WriteLine("---------------------");
            Console.WriteLine(syntaxTree.GetRoot().ToFullString());
            Console.WriteLine("====== result =======");
            var diagsOk = CheckDiagnostics(antlr4Diags, diags);
            Console.WriteLine("Diagnostics: " + (diagsOk ? "OK" : "mismatch"));
            var sourceOk = source.ToString() == syntaxTree.GetRoot().ToFullString();
            Console.WriteLine("Source: " + (diagsOk ? "OK" : "mismatch"));
            Console.WriteLine("=====================");
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
