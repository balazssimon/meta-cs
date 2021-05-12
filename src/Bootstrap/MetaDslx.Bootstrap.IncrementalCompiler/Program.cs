using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
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
            //CompileMGen("mgen01.txt");
            //CompileMGen("mgen02.txt");
            //CompileMGen("mgen03.txt");
            //CompileMGen("mgen04.txt");
            //IncrementalCompileMGen("mgen03.txt");
            //CompileMeta("meta01.txt");
            //CompileMeta("meta02.txt");
            EditAndCompileMeta("meta01.txt");
            //CompileMeta("meta03.txt");
            //EditAndCompileMeta("meta03.txt");
            //CompileMeta("meta04.txt");
            //EditAndCompileMeta("meta04.txt");
        }

        private static void CompileMeta(string fileName)
        {
            var source = SourceText.From(File.ReadAllText(@"..\..\..\"+ fileName));
            var syntaxTree = MetaLanguage.Instance.ParseSyntaxTree(source);
            var antlr4Diags = Antlr4ParseMeta(source);
            PrintResults(source, syntaxTree, antlr4Diags);
        }

        private static void IncrementalCompileMeta(string fileName)
        {
            var options = MetaLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(code.Substring(0, 1));
            var syntaxTree1 = MetaLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4ParseMeta(source1);
            Console.WriteLine("Length=1");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 2; i <= code.Length; ++i)
            {
                Console.WriteLine("Length=" + i);
                var source2 = source1.WithChanges(new TextChange(new TextSpan(i - 1, 0), code[i - 1].ToString()));
                var syntaxTree2 = (LanguageSyntaxTree)syntaxTree1.WithChangedText(source2);
                if (source2[source2.Length - 1] != '\r')
                {
                    var antlr4Diags2 = Antlr4ParseMeta(source2);
                    PrintResults(source2, syntaxTree2, antlr4Diags2, true);
                }
                source1 = source2;
                syntaxTree1 = syntaxTree2;
            }
        }

        private static void EditAndCompileMeta(string fileName)
        {
            var options = MetaLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(code);
            var syntaxTree1 = MetaLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4ParseMeta(source1);
            Console.WriteLine("Original");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < code.Length-1; ++i)
            {
                Console.WriteLine("Position=" + i);
                if (i > 0 && code[i - 1] == '\r') continue;
                var source2 = source1.WithChanges(new TextChange(new TextSpan(i, 1), string.Empty));
                var syntaxTree2 = (LanguageSyntaxTree)syntaxTree1.WithChangedText(source2);
                //if (i < source2.Length && source2[i] != '\r')
                {
                    var antlr4Diags2 = Antlr4ParseMeta(source2);
                    PrintResults(source2, syntaxTree2, antlr4Diags2, true);
                }
            }
        }

        public static ImmutableArray<Diagnostic> Antlr4ParseMeta(SourceText text)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var errors = new Antlr4ErrorListener("", diagnostics);
            var lexer = new MetaLexer(new AntlrInputStream(text.ToString()));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errors);
            var parser = new MetaParser(new CommonTokenStream(lexer));
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

        private static void IncrementalCompileMGen(string fileName)
        {
            var options = TestLexerModeLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(code.Substring(0, 1));
            var syntaxTree1 = TestLexerModeLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4ParseMGen(source1);
            Console.WriteLine("Length=1");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 2; i <= code.Length; ++i)
            {
                Console.WriteLine("Length="+i);
                var source2 = source1.WithChanges(new TextChange(new TextSpan(i - 1, 0), code[i - 1].ToString()));
                var syntaxTree2 = (LanguageSyntaxTree)syntaxTree1.WithChangedText(source2);
                if (source2[source2.Length - 1] != '\r')
                {
                    var antlr4Diags2 = Antlr4ParseMGen(source2);
                    PrintResults(source2, syntaxTree2, antlr4Diags2, true);
                }
                source1 = source2;
                syntaxTree1 = syntaxTree2;
            }
        }

        public static ImmutableArray<Diagnostic> Antlr4ParseMGen(SourceText text)
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

        private static void PrintResults(SourceText source, SyntaxTree syntaxTree, ImmutableArray<Diagnostic> antlr4Diags, bool onlyIfMismatch = false)
        {
            var diags = syntaxTree.GetDiagnostics().ToImmutableArray();
            var diagsOk = CheckDiagnostics(antlr4Diags, diags);
            var sourceOk = source.ToString() == syntaxTree.GetRoot().ToFullString();
            if (onlyIfMismatch && diagsOk && sourceOk) return;
            Console.WriteLine("==== diagnostics ====");
            var formatter = new DiagnosticFormatter();
            foreach (var diag in antlr4Diags)
            {
                Console.WriteLine(formatter.Format(diag));
            }
            Console.WriteLine("---------------------");
            foreach (var diag in diags)
            {
                Console.WriteLine(formatter.Format(diag));
            }
            Console.WriteLine("====== source =======");
            Console.WriteLine(source.ToString());
            Console.WriteLine("---------------------");
            Console.WriteLine(syntaxTree.GetRoot().ToFullString());
            Console.WriteLine("====== result =======");
            Console.WriteLine("Diagnostics: " + (diagsOk ? "OK" : "mismatch"));
            Console.WriteLine("Source: " + (sourceOk ? "OK" : "mismatch"));
            Console.WriteLine("=====================");
            if (onlyIfMismatch) Console.ReadLine();
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
