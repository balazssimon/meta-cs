using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
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
    public class TestMetaCompiler : CompilerBase
    {
        public static void NoEdit(string fileName, bool semanticCheck = true)
        {
            var source = SourceText.From(File.ReadAllText(@"..\..\..\" + fileName));

            var lexer = new TestIncrementalCompilationSyntaxLexer(source, TestIncrementalCompilationParseOptions.Default);
            //var tokens = lexer.GetAllTokens();
            //Console.WriteLine("Number of tokens: " + tokens.Count);

            var syntaxTree = TestIncrementalCompilationLanguage.Instance.ParseSyntaxTree(source);
            var antlr4Diags = Antlr4Parse(source);
            PrintResults(source, syntaxTree, antlr4Diags, !semanticCheck);

            if (semanticCheck) Compile(null, syntaxTree);
        }

        public static void Type(string fileName, bool semanticCheck = true)
        {
            var options = TestIncrementalCompilationLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(string.Empty);
            var syntaxTree1 = TestIncrementalCompilationLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4Parse(source1);
            TestIncrementalCompilationCompilation? compilation1 = null;
            Console.WriteLine("Empty");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < code.Length; ++i)
            {
                Console.WriteLine("Length=" + i);
                var source2 = source1.WithChanges(new TextChange(new TextSpan(i, 0), code[i].ToString()));
                var syntaxTree2 = (TestIncrementalCompilationSyntaxTree)syntaxTree1.WithChangedText(source2);
                var antlr4Diags2 = Antlr4Parse(source2);
                if (code[i] != '\r') PrintResults(source2, syntaxTree2, antlr4Diags2, !semanticCheck);
                source1 = source2;
                syntaxTree1 = syntaxTree2;

                if (semanticCheck) compilation1 = Compile(compilation1, syntaxTree2);
            }
        }

        public static void SerialEdit(string fileName, bool semanticCheck = true)
        {
            var options = TestIncrementalCompilationLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(code);
            var syntaxTree1 = (TestIncrementalCompilationSyntaxTree)TestIncrementalCompilationLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4Parse(source1);
            TestIncrementalCompilationCompilation? compilation1 = null;
            Console.WriteLine("Original");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < code.Length; ++i)
            {
                Console.WriteLine("Position=" + i);
                var start = i;
                var length = 1;
                if (i > 0 && code[i - 1] == '\r') continue;
                (source1, syntaxTree1, compilation1) = SingleEdit(source1, syntaxTree1, start, length, code, semanticCheck, compilation1);
            }
        }

        public static void RandomEdit(string fileName, bool semanticCheck = true)
        {
            var rnd = new Random(13);
            var count = 1000;
            var options = TestIncrementalCompilationLanguage.Instance.DefaultParseOptions.WithIncremental(false);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(code);
            var syntaxTree1 = (TestIncrementalCompilationSyntaxTree)TestIncrementalCompilationLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4Parse(source1);
            TestIncrementalCompilationCompilation? compilation1 = null;
            Console.WriteLine("Original");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < count; ++i)
            {
                var start = rnd.Next(code.Length);
                var length = rnd.Next(code.Length - start + 1);
                if (start > 0 && code[start - 1] == '\r') continue;
                Console.WriteLine($"i={i}, Start={start}, Length={length}");
                (source1, syntaxTree1, compilation1) = SingleEdit(source1, syntaxTree1, start, length, code, semanticCheck, compilation1);
            }
        }

        private static (SourceText source2, TestIncrementalCompilationSyntaxTree syntaxTree2, TestIncrementalCompilationCompilation? compilation) SingleEdit(SourceText source1, TestIncrementalCompilationSyntaxTree syntaxTree1, int start, int length, string code, bool semanticCheck, TestIncrementalCompilationCompilation? oldCompilation)
        {
            TestIncrementalCompilationCompilation? compilation = oldCompilation;
            var source2 = source1.WithChanges(new TextChange(new TextSpan(start, length), string.Empty));
            var syntaxTree2 = (TestIncrementalCompilationSyntaxTree)syntaxTree1.WithChangedText(source2);
            var antlr4Diags2 = Antlr4Parse(source2);
            PrintResults(source2, syntaxTree2, antlr4Diags2, !semanticCheck, "  DELETE:");
            if (semanticCheck) compilation = Compile(compilation, syntaxTree2);
            source1 = source2;
            syntaxTree1 = syntaxTree2;
            source2 = source1.WithChanges(new TextChange(new TextSpan(start, 0), code.Substring(start, length)));
            syntaxTree2 = (TestIncrementalCompilationSyntaxTree)syntaxTree1.WithChangedText(source2);
            antlr4Diags2 = Antlr4Parse(source2);
            PrintResults(source2, syntaxTree2, antlr4Diags2, !semanticCheck, "  INSERT:");
            if (semanticCheck) compilation = Compile(compilation, syntaxTree2);
            return (source2, syntaxTree2, compilation);
        }

        public static ImmutableArray<Diagnostic> Antlr4Parse(SourceText text)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var errors = new Antlr4ErrorListener("", diagnostics);
            var lexer = new TestIncrementalCompilationLexer(new AntlrInputStream(text.ToString()));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errors);
            var parser = new TestIncrementalCompilationParser(new CommonTokenStream(lexer));
            parser.ErrorHandler = new MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.DefaultErrorStrategy();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errors);
            parser.main();
            var result = diagnostics.ToReadOnlyAndFree();
            return result;
        }

        private static TestIncrementalCompilationCompilation Compile(TestIncrementalCompilationCompilation? oldCompilation, SyntaxTree syntaxTree)
        {
            if (oldCompilation is not null)
            {
                var compilation = oldCompilation.RemoveAllSyntaxTrees().AddSyntaxTrees(syntaxTree);
                var compiledModel = compilation.Model as MutableModel;
                Console.WriteLine(compiledModel);
                return compilation;
            }
            else
            {
                ImmutableModel coreModel = MetaInstance.MModel;
                var coreAssembly = typeof(object).Assembly.Location;
                var assemblyPath = Path.GetDirectoryName(coreAssembly);
                var coreRef = MetadataReference.CreateFromFile(Path.Combine(assemblyPath, "mscorlib.dll"));
                BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
                BinderFlags binderFlags2 = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
                binderFlags = binderFlags.UnionWith(binderFlags2);
                TestIncrementalCompilationCompilationOptions options = new TestIncrementalCompilationCompilationOptions(OutputKind.NetModule, deterministic: true, concurrentBuild: false).WithTopLevelBinderFlags(binderFlags);
                //MetaCompilationOptions options = new MetaCompilationOptions(OutputKind.NetModule, deterministic: false, concurrentBuild: true).WithTopLevelBinderFlags(binderFlags);
                var compilation = TestIncrementalCompilationCompilation.
                    Create("MetaTest").
                    AddSyntaxTrees(syntaxTree).
                    AddReferences(coreRef).
                    AddReferences(ModelReference.CreateFromModel(coreModel)).
                    AddReferences(MetadataReference.CreateFromFile(typeof(Symbol).Assembly.Location)).
                    WithOptions(options);
                var compiledModel = compilation.Model as MutableModel;
                Console.WriteLine(compiledModel);
                return compilation;
            }
        }
    }
}
