using MetaDslx.Compiler;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Core;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using MetaDslx.Languages.Antlr4Roslyn.Generator;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Generator;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.MetaGenerator.Compilation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.TempConsole
{

    /*
    public class A
    {
        public partial class B
        {

        }
    }

    public class C : A
    {
    }

    public class D
    {
        C X;
        A U;
        A.B Z;
        C.B E;
    }

    public class E : A.B
    {

    }

    public class F : C.B
    {

    }
    */

    class Program
    {
        static void Main(string[] args)
        {
            //try
            {
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\Main\MetaDslx.Core\Languages\Meta\Generator\ImmutableMetaModelGenerator.mgen",
                    @"..\..\Main\MetaDslx.Core\Languages\Meta\Generator\ImmutableMetaModelGenerator.cs"
                    );
                //*/
                /*
                Program.CompileAntlr4Roslyn(@"Expression", @"Expression", "expressionLexer.ag4", "MetaDslx.Languages.Antlr4Roslyn");
                Program.CompileAntlr4Roslyn(@"Expression", @"Expression", "expressionParser.ag4", "MetaDslx.Languages.Antlr4Roslyn");
                */
                /*
                CompileMeta(
                    @"Expression\Expression.mm",
                    @"Expression\Expression.cs"
                    );
                */
                /*
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Antlr4Roslyn", "Antlr4RoslynLexer.ag4", "MetaDslx.Languages.Antlr4Roslyn");
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Antlr4Roslyn", "Antlr4RoslynParser.ag4", "MetaDslx.Languages.Antlr4Roslyn");
                //*/
                /*/
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\MetaGenerator\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\MetaGenerator", "MetaGeneratorLexer.ag4", "MetaDslx.Languages.MetaGenerator");
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\MetaGenerator\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\MetaGenerator", "MetaGeneratorParser.ag4", "MetaDslx.Languages.MetaGenerator");
                //*/
                //*/
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta", "MetaLexer.ag4", "MetaDslx.Languages.Meta");
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta", "MetaParser.ag4", "MetaDslx.Languages.Meta");
                //*/
                /*
                Console.WriteLine("----");
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Antlr4Roslyn", "Antlr4RoslynLexer.ag4", "MetaDslx.Languages.Antlr4Roslyn");
                GenerateLanguageService(
                    "Antlr4Roslyn",
                    "MetaDslx.Languages.Antlr4Roslyn",
                    @"..\..\Main\MetaDslx.VisualStudio\Antlr4Roslyn",
                    "Antlr4RoslynLanguageService.cs",
                    false,
                    true);
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\MetaGenerator\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\MetaGenerator", "MetaGeneratorLexer.ag4", "MetaDslx.Languages.MetaGenerator");
                GenerateLanguageService(
                    "MetaGenerator",
                    "MetaDslx.Languages.MetaGenerator",
                    @"..\..\Main\MetaDslx.VisualStudio\MetaGenerator",
                    "MetaGeneratorLanguageService.cs",
                    false,
                    false);
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta", "MetaLexer.ag4", "MetaDslx.Languages.Meta");
                GenerateLanguageService(
                    "Meta",
                    "MetaDslx.Languages.Meta",
                    @"..\..\Main\MetaDslx.VisualStudio\Meta",
                    "MetaLanguageService.cs",
                    true,
                    false);
                //*/
                /*
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.VisualStudio\Soal\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.VisualStudio\Soal", "SoalLexer.ag4", "MetaDslx.Languages.Soal");
                //*/
                /*
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Antlr4\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Antlr4", "Antlr4Lexer.ag4", "MetaDslx.Languages.Antlr4");
                GenerateLanguageService(
                    "Antlr4",
                    "MetaDslx.Languages.Antlr4",
                    @"..\..\Main\MetaDslx.VisualStudio\Antlr4Roslyn",
                    "Antlr4RoslynLanguageService.cs",
                    false,
                    true);
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta", "MetaLexer.ag4", "MetaDslx.Languages.Meta");
                GenerateLanguageService(
                    "Meta",
                    "MetaDslx.Languages.Meta",
                    @"..\..\Main\MetaDslx.VisualStudio\Meta",
                    "MetaLanguageService.cs",
                    true,
                    false);
                //*/
                //Console.WriteLine(MetaDslx.Core.Immutable.MetaInstance.String);
                /*
                var factory = CalculatorLanguage.Instance.SyntaxFactory;
                var node0 = factory.ParseSyntaxTree("hello = 5");
                var node1 = factory.ID("hello").WithTrailingTrivia(factory.Space);
                var node2 = factory.Identifier(node1);
                var node3 = factory.Value(factory.Integer(factory.INT("5", 5).WithLeadingTrivia(factory.Space)));
                var node4 = factory.ValueExpression(node3);
                var node5 = factory.Assignment(node2, node4);
                Console.WriteLine(node5.ToString());
                Console.WriteLine(node1);
                Console.WriteLine(node2);
                Console.WriteLine(node0);
                //*/
                /*
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta", "MetaLexer.ag4", "MetaDslx.Languages.Meta");
                Program.CompileAntlr4Roslyn(@"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta\Syntax\InternalSyntax", @"..\..\Main\MetaDslx.Compiler.Antlr4\Languages\Meta", "MetaParser.ag4", "MetaDslx.Languages.Meta");
                //*/
                /*
                Program.CompileAntlr4Roslyn("../../Samples/MetaDslx.Languages.Soal/Syntax/InternalSyntax", "../../Samples/MetaDslx.Languages.Soal", "SoalLexer.ag4", "MetaDslx.Languages.Soal");
                Program.CompileAntlr4Roslyn("../../Samples/MetaDslx.Languages.Soal/Syntax/InternalSyntax", "../../Samples/MetaDslx.Languages.Soal", "SoalParser.ag4", "MetaDslx.Languages.Soal");
                //*/
                /*
                Program.CompileAntlr4Roslyn("../../Samples/MetaDslx.Languages.Calculator/Syntax/InternalSyntax", "../../Samples/MetaDslx.Languages.Calculator", "CalculatorLexer.ag4", "MetaDslx.Languages.Calculator");
                Program.CompileAntlr4Roslyn("../../Samples/MetaDslx.Languages.Calculator/Syntax/InternalSyntax", "../../Samples/MetaDslx.Languages.Calculator", "CalculatorParser.ag4", "MetaDslx.Languages.Calculator");
                //*/
                /*
                Console.WriteLine("----");
                CompileMeta(
                    @"../../Samples/MetaDslx.Languages.Soal\Soal.mm",
                    @"../../Samples/MetaDslx.Languages.Soal\Soal.cs"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileMeta(
                    @"..\..\Main\MetaDslx.Core\Languages\Meta\Symbols\ImmutableMetaModel.mm",
                    @"..\..\Main\MetaDslx.Core\Languages\Meta\Symbols\ImmutableMetaModel1.cs"
                    );
                //*/
                /*
                ImmutableMetaModelGenerator generator = new ImmutableMetaModelGenerator(MetaInstance.Model.Symbols);
                using (StreamWriter writer = new StreamWriter(@"..\..\Main\MetaDslx.Core\Languages\Meta\Symbols\ImmutableMetaModel3.cs"))
                {
                    writer.WriteLine(generator.Generate());
                }
                //*/
                /*
                Console.WriteLine("----");
                CompileMeta(
                    @"../../Samples/MetaDslx.Languages.Soal\Soal.mm",
                    @"../../Samples/MetaDslx.Languages.Soal\Soal.cs"
                    );
                //*/
                /*
                string fileName = "Calc1.txt";
                string source = null;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    source = reader.ReadToEnd();
                }
                CalculatorSyntaxTree tree = CalculatorSyntaxTree.ParseText(source);
                MainSyntax main = (MainSyntax)tree.GetRoot();
                Console.WriteLine(main);
                foreach (var diag in tree.GetDiagnostics())
                {
                    Console.WriteLine(DiagnosticFormatter.Instance.Format(diag));
                }
                //*/
                //*/
                //CompileSoal(@"HelloWorld.soal");
                //*/
            }
            /*catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }*/
        }

        private static void CompileAntlr4Roslyn(string inputDirectory, string outputDirectory, string antlr4FileName, string defaultNamespace)
        {
            string source;
            string fileName = Path.Combine(inputDirectory, antlr4FileName);
            using (StreamReader reader = new StreamReader(fileName))
            {
                source = reader.ReadToEnd();
            }
            Antlr4RoslynCompiler compiler = new Antlr4RoslynCompiler(source, defaultNamespace, inputDirectory, outputDirectory, fileName);
            compiler.Generate();
            using (StreamWriter writer = new StreamWriter("messages_a4.txt"))
            {
                foreach (var msg in compiler.GetDiagnostics())
                {
                    writer.WriteLine(msg);
                    Console.WriteLine(msg);
                }
            }
        }

        private static void PrintScope(string indent, MutableSymbol scope)
        {
            foreach (var entry in scope.MChildren)
            {
                Console.WriteLine(indent + entry);
                if (entry.MIsScope)
                {
                    PrintScope(indent + "  ", entry);
                }
            }
        }

        private static void SaveToFile(string fileName, string source)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(source);
            }
        }

        private static void CompileMeta(string fileName, string outputFileName)
        {
            string source;
            using (StreamReader reader = new StreamReader(fileName))
            {
                source = reader.ReadToEnd();
            }
            var metaModelReference = MetadataReference.CreateFromModel(MetaInstance.Model);
            var tree = MetaSyntaxTree.ParseText(source);
            var compilation = MetaCompilation.Create("Meta").AddReferences(metaModelReference).AddSyntaxTrees(tree);
            ImmutableModel immutableModel = compilation.Model;
            if (compilation.GetDiagnostics().Length == 0)
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    ImmutableMetaModelGenerator generator = new ImmutableMetaModelGenerator(immutableModel.Symbols);
                    string code = generator.Generate();
                    writer.WriteLine(code);
                }
            }
            //PrintScope("", compiler.GlobalScope);
            Console.WriteLine("=");

            using (StreamWriter writer = new StreamWriter("symbols.txt"))
            {
                foreach (var symbol in immutableModel.Symbols)
                {
                    ImmutableSymbol mo = symbol;
                    if (mo != null)
                    {
                        writer.WriteLine(mo);
                        Console.WriteLine(mo);
                        /*string leading = compiler.TriviaProvider.GetLeadingTrivia(mo);
                        string trailing = compiler.TriviaProvider.GetTrailingTrivia(mo);
                        if (!string.IsNullOrWhiteSpace(leading))
                        {
                            writer.WriteLine("  Leading trivia: "+leading);
                            Console.WriteLine("  Leading trivia: "+ leading);
                        }
                        if (!string.IsNullOrWhiteSpace(trailing))
                        {
                            writer.WriteLine("  Trailing trivia: "+ trailing);
                            Console.WriteLine("  Trailing trivia: "+trailing);
                        }*/
                        writer.WriteLine("  Parent=" + mo.MParent);
                        Console.WriteLine("  Parent=" + mo.MParent);
                        ModelProperty mp;
                        mp = mo.MGetProperty("Documentation");
                        if (mp != null)
                        {
                            writer.WriteLine("  Documentation=" + mo.MGet(mp));
                            Console.WriteLine("  Documentation=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("Name");
                        if (mp != null)
                        {
                            writer.WriteLine("  Name=" + mo.MGet(mp));
                            Console.WriteLine("  Name=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("Uri");
                        if (mp != null)
                        {
                            writer.WriteLine("  Uri=" + mo.MGet(mp));
                            Console.WriteLine("  Uri=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("IsAbstract");
                        if (mp != null)
                        {
                            writer.WriteLine("  IsAbstract=" + mo.MGet(mp));
                            Console.WriteLine("  IsAbstract=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("Type");
                        if (mp != null)
                        {
                            writer.WriteLine("  Type=" + mo.MGet(mp));
                            Console.WriteLine("  Type=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("InnerType");
                        if (mp != null)
                        {
                            writer.WriteLine("  InnerType=" + mo.MGet(mp));
                            Console.WriteLine("  InnerType=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("ReturnType");
                        if (mp != null)
                        {
                            writer.WriteLine("  ReturnType=" + mo.MGet(mp));
                            Console.WriteLine("  ReturnType=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("EnumLiterals");
                        if (mp != null)
                        {
                            writer.WriteLine("  EnumLiterals:");
                            Console.WriteLine("  EnumLiterals:");
                            foreach (var elo in (IEnumerable<object>)mo.MGet(mp))
                            {
                                MetaEnumLiteral el = elo as MetaEnumLiteral;
                                if (el != null)
                                {
                                    writer.WriteLine("    " + el);
                                    Console.WriteLine("    " + el);
                                }
                            }
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("messages_meta.txt"))
            {
                foreach (var diag in compilation.GetDiagnostics())
                {
                    string msg = DiagnosticFormatter.Instance.Format(diag);
                    writer.WriteLine(msg);
                    Console.WriteLine(msg);
                }
            }
        }


        private static void CompileGenerator(string inputFileName, string outputFileName)
        {
            string source;
            using (StreamReader reader = new StreamReader(inputFileName))
            {
                source = reader.ReadToEnd();
            }
            string directory = Path.GetDirectoryName(inputFileName);
            string fileName = Path.GetFileName(inputFileName);
            CompileGenerator(directory, directory, fileName);
        }

        private static void CompileGenerator(string inputDirectory, string outputDirectory, string fileName)
        {
            string source;
            using (StreamReader reader = new StreamReader(Path.Combine(inputDirectory, fileName)))
            {
                source = reader.ReadToEnd();
            }
            MetaGeneratorCompiler compiler = new MetaGeneratorCompiler(source, null, inputDirectory, outputDirectory, fileName);
            compiler.Generate();
            using (StreamWriter writer = new StreamWriter("messages_gen.txt"))
            {
                foreach (var msg in compiler.GetDiagnostics())
                {
                    writer.WriteLine(msg);
                    Console.WriteLine(msg);
                }
            }
        }

        private static void GenerateLanguageService(string language, string languageNamespace, string outputDirectory, string outputFileName, bool roslynCompiler, bool generateMultipleFiles)
        {
            LanguageServiceGenerator generator = new LanguageServiceGenerator(null);
            generator.Properties.LanguageServiceNamespace = "MetaDslx.VisualStudio";
            generator.Properties.LanguageClassName = language;
            generator.Properties.LanguageNamespace = languageNamespace;
            generator.Properties.LanguageName = language;
            generator.Properties.RoslynCompiler = roslynCompiler;
            generator.Properties.GenerateMultipleFiles = generateMultipleFiles;
            using (StreamWriter writer = new StreamWriter(Path.Combine(outputDirectory, outputFileName)))
            {
                writer.WriteLine(generator.Generate());
            }
        }

        private static void LazyPropertyTest()
        {

        }

        private static void GenerateImmutableMeta(string outputFileName)
        {
            ImmutableModel model = MetaInstance.Model;
            ImmutableMetaModelGenerator generator = new ImmutableMetaModelGenerator(model.Symbols);
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.WriteLine(generator.Generate());
            }
            //PrintScope("", compiler.GlobalScope);
            Console.WriteLine("=");

            using (StreamWriter writer = new StreamWriter("symbols.txt"))
            {
                foreach (var symbol in model.Symbols)
                {
                    var mo = symbol;
                    if (mo != null)
                    {
                        writer.WriteLine(mo);
                        Console.WriteLine(mo);
                        writer.WriteLine("  Parent=" + mo.MParent);
                        Console.WriteLine("  Parent=" + mo.MParent);
                        ModelProperty mp;
                        mp = mo.MGetProperty("Documentation");
                        if (mp != null)
                        {
                            writer.WriteLine("  Documentation=" + mo.MGet(mp));
                            Console.WriteLine("  Documentation=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("Name");
                        if (mp != null)
                        {
                            writer.WriteLine("  Name=" + mo.MGet(mp));
                            Console.WriteLine("  Name=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("Uri");
                        if (mp != null)
                        {
                            writer.WriteLine("  Uri=" + mo.MGet(mp));
                            Console.WriteLine("  Uri=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("IsAbstract");
                        if (mp != null)
                        {
                            writer.WriteLine("  IsAbstract=" + mo.MGet(mp));
                            Console.WriteLine("  IsAbstract=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("Type");
                        if (mp != null)
                        {
                            writer.WriteLine("  Type=" + mo.MGet(mp));
                            Console.WriteLine("  Type=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("InnerType");
                        if (mp != null)
                        {
                            writer.WriteLine("  InnerType=" + mo.MGet(mp));
                            Console.WriteLine("  InnerType=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("ReturnType");
                        if (mp != null)
                        {
                            writer.WriteLine("  ReturnType=" + mo.MGet(mp));
                            Console.WriteLine("  ReturnType=" + mo.MGet(mp));
                        }
                        mp = mo.MGetProperty("EnumLiterals");
                        if (mp != null)
                        {
                            writer.WriteLine("  EnumLiterals:");
                            Console.WriteLine("  EnumLiterals:");
                            foreach (var elo in (IEnumerable<object>)mo.MGet(mp))
                            {
                                MetaEnumLiteral el = elo as MetaEnumLiteral;
                                if (el != null)
                                {
                                    writer.WriteLine("    " + el);
                                    Console.WriteLine("    " + el);
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
        private static void CompileSoal(string fileName)
        {
            string source;
            using (StreamReader reader = new StreamReader(fileName))
            {
                source = reader.ReadToEnd();
            }
            var metaModelReference = MetadataReference.CreateFromModel(MetaInstance.Model);
            var soalModelReference = MetadataReference.CreateFromModel(SoalInstance.Model);
            var tree = SoalSyntaxTree.ParseText(source);
            var compilation = SoalCompilation.Create("SoalFile").AddReferences(metaModelReference, soalModelReference).AddSyntaxTrees(tree);
            ImmutableModel immutableModel = compilation.Model;
            if (compilation.GetDiagnostics().Length == 0)
            {
                
            }

            using (StreamWriter writer = new StreamWriter("messages_soal.txt"))
            {
                foreach (var diag in compilation.GetDiagnostics())
                {
                    string msg = DiagnosticFormatter.Instance.Format(diag);
                    writer.WriteLine(msg);
                    Console.WriteLine(msg);
                }
            }
        }*/
    }
}
