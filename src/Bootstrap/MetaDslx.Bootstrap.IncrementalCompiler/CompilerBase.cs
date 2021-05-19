using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Bootstrap.IncrementalCompiler
{
    public class CompilerBase
    {

        private static bool CheckDiagnostics(ImmutableArray<Diagnostic> antlr4Diagnostics, ImmutableArray<Diagnostic> diagnostics)
        {
            var formatter = new DiagnosticFormatter();
            var diagnosticsList = diagnostics.Select(d => formatter.Format(d)).OrderBy(d => d).ToList();
            var antlr4DiagnosticsList = antlr4Diagnostics.Select(d => formatter.Format(d)).OrderBy(d => d).ToList();
            var lastIndex = Math.Min(antlr4Diagnostics.Length, diagnostics.Length);
            for (int i = 0; i < lastIndex; i++)
            {
                var expected = antlr4DiagnosticsList[i];
                var actual = diagnosticsList[i];
                //expected = expected.Substring(expected.IndexOf(':'));
                //actual = actual.Substring(actual.IndexOf(':'));
                if (expected != actual) return false;
            }
            if (lastIndex < antlr4Diagnostics.Length)
            {
                return false;
            }
            return antlr4Diagnostics.Length == diagnostics.Length;
        }

        public static void PrintResults(SourceText source, SyntaxTree syntaxTree, ImmutableArray<Diagnostic> antlr4Diags, bool onlyIfMismatch = false, string title = null)
        {
            var diags = syntaxTree.GetDiagnostics().ToImmutableArray();
            var diagsOk = CheckDiagnostics(antlr4Diags, diags);
            var sourceOk = source.ToString() == syntaxTree.GetRoot().ToFullString();
            if (onlyIfMismatch && diagsOk && sourceOk) return;
            if (title != null) Console.WriteLine(title);
            Console.WriteLine("==== diagnostics ====");
            var formatter = new DiagnosticFormatter();
            foreach (var diag in antlr4Diags)
            {
                Console.WriteLine(formatter.Format(diag));
            }
            Console.WriteLine("------ actual -------");
            foreach (var diag in diags)
            {
                Console.WriteLine(formatter.Format(diag));
            }
            Console.WriteLine("====== source =======");
            Console.WriteLine(source.ToString());
            Console.WriteLine("------ actual -------");
            Console.WriteLine(syntaxTree.GetRoot().ToFullString());
            Console.WriteLine("====== result =======");
            Console.WriteLine("Diagnostics: " + (diagsOk ? "OK" : "mismatch"));
            Console.WriteLine("Source: " + (sourceOk ? "OK" : "mismatch"));
            Console.WriteLine("=====================");
            if (onlyIfMismatch) Console.ReadLine();
        }
    }
}
