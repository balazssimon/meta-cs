using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;
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
    public class MetaCompiler : CompilerBase
    {
        public static void Compile(string fileName)
        {
            var source = SourceText.From(File.ReadAllText(@"..\..\..\" + fileName));

            var lexer = new MetaSyntaxLexer(source, MetaParseOptions.Default);
            //var tokens = lexer.GetAllTokens();
            //Console.WriteLine("Number of tokens: " + tokens.Count);

            var syntaxTree = MetaLanguage.Instance.ParseSyntaxTree(source);
            var antlr4Diags = Antlr4Parse(source);
            PrintResults(source, syntaxTree, antlr4Diags);
        }

        public static void Type(string fileName)
        {
            var options = MetaLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(string.Empty);
            var syntaxTree1 = MetaLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4Parse(source1);
            Console.WriteLine("Empty");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < code.Length; ++i)
            {
                Console.WriteLine("Length=" + i);
                var source2 = source1.WithChanges(new TextChange(new TextSpan(i, 0), code[i].ToString()));
                var syntaxTree2 = (MetaSyntaxTree)syntaxTree1.WithChangedText(source2);
                var antlr4Diags2 = Antlr4Parse(source2);
                PrintResults(source2, syntaxTree2, antlr4Diags2, true);
                source1 = source2;
                syntaxTree1 = syntaxTree2;
            }
        }

        public static void SerialEdit(string fileName)
        {
            var options = MetaLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(code);
            var syntaxTree1 = MetaLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4Parse(source1);
            Console.WriteLine("Original");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < code.Length; ++i)
            {
                Console.WriteLine("Position=" + i);
                var source2 = source1.WithChanges(new TextChange(new TextSpan(i, 1), string.Empty));
                var syntaxTree2 = (MetaSyntaxTree)syntaxTree1.WithChangedText(source2);
                var antlr4Diags2 = Antlr4Parse(source2);
                PrintResults(source2, syntaxTree2, antlr4Diags2, true);
                source1 = source2;
                syntaxTree1 = syntaxTree2;
            }
        }

        public static void RandomEdit(string fileName)
        {
            var compilation = 
                MetaCompilation.Create("test")
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddReferences(ModelReference.CreateFromModel(MetaInstance.MModel));
            var rnd = new Random(13);
            var count = 10000;
            var options = MetaLanguage.Instance.DefaultParseOptions.WithIncremental(true);
            var code = File.ReadAllText(@"..\..\..\" + fileName);
            var source1 = SourceText.From(code);
            var syntaxTree1 = MetaLanguage.Instance.ParseSyntaxTree(source1, options: options);
            var antlr4Diags1 = Antlr4Parse(source1);
            Console.WriteLine("Original");
            PrintResults(source1, syntaxTree1, antlr4Diags1, true);
            for (int i = 0; i < count; ++i)
            {
                var start = rnd.Next(code.Length);
                var length = rnd.Next(code.Length - start + 1);
                Console.WriteLine($"DELETE: i={i}, Start={start}, Length={length}");
                var source2 = source1.WithChanges(new TextChange(new TextSpan(start, length), string.Empty));
                var syntaxTree2 = (MetaSyntaxTree)syntaxTree1.WithChangedText(source2);
                var antlr4Diags2 = Antlr4Parse(source2);
                PrintResults(source2, syntaxTree2, antlr4Diags2, true);
                source1 = source2;
                syntaxTree1 = syntaxTree2;
                compilation.RemoveAllSyntaxTrees().AddSyntaxTrees(syntaxTree1);
                compilation.ForceComplete();
                Console.WriteLine($"INSERT: i={i}, Start={start}, Length={length}");
                source2 = source1.WithChanges(new TextChange(new TextSpan(start, 0), code.Substring(start, length)));
                syntaxTree2 = (MetaSyntaxTree)syntaxTree1.WithChangedText(source2);
                antlr4Diags2 = Antlr4Parse(source2);
                PrintResults(source2, syntaxTree2, antlr4Diags2, true);
                source1 = source2;
                syntaxTree1 = syntaxTree2;
                compilation.RemoveAllSyntaxTrees().AddSyntaxTrees(syntaxTree1);
                compilation.ForceComplete();
            }
        }

        public static ImmutableArray<Diagnostic> Antlr4Parse(SourceText text)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var errors = new Antlr4ErrorListener("", diagnostics);
            var lexer = new MetaLexer(new AntlrInputStream(text.ToString()));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(errors);
            var parser = new MetaParser(new CommonTokenStream(lexer));
            parser.ErrorHandler = new MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.DefaultErrorStrategy();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errors);
            parser.main();
            var result = diagnostics.ToReadOnlyAndFree();
            return result;
        }


    }
}
