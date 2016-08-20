﻿using MetaDslx.Compiler;
using MetaDslx.Core;
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
            try
            {
                /*
                CompileAG4(@"..\..\..\..\Samples\MetaDslx.Soal", @"SoalLexer");
                CompileAG4(@"..\..\..\..\Samples\MetaDslx.Soal", @"SoalParser");
                Console.WriteLine("----");
                //*/
                /*
                Console.WriteLine("----");
                CompileMeta(
                    @"..\..\..\..\Samples\MetaDslx.Soal\Soal.mm",
                    @"..\..\..\..\Samples\MetaDslx.Soal\Soal.cs"
                    );
                //*/
                /*
                string source = "";
                string fileName = @"SoalTest1.soal";
                using (StreamReader reader = new StreamReader(@"..\..\" + fileName))
                {
                    source = reader.ReadToEnd();
                }
                SoalCompiler compiler = new SoalCompiler(source, ".", fileName);
                compiler.Compile();
                foreach (var msg in compiler.Diagnostics.GetMessages(true))
                {
                    Console.WriteLine(msg);
                }
                Console.WriteLine("----");
                foreach (var symbol in compiler.Data.GetSymbols())
                {
                    Declaration decl = symbol as Declaration;
                    if (decl != null)
                    {
                        Console.WriteLine(decl.Name);
                    }
                    Property prop = symbol as Property;
                    if (prop != null)
                    {
                        Console.WriteLine("{0}: {1}", prop.Name, prop.Type);
                    }
                    Wire wire = symbol as Wire;
                    if (wire != null)
                    {
                        Console.WriteLine(wire.Source);
                        Console.WriteLine(wire.Target);
                    }
                }
                //*/
                /*
                CompileAG4(@"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4", @"AnnotatedAntlr4Lexer");
                CompileAG4(@"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4", @"AnnotatedAntlr4Parser");
                Console.WriteLine("----");
                //*/
                /*
                CompileAG4(@"..\..\..\..\Main\MetaDslx.Compiler\MetaGenerator", @"MetaGeneratorLexer");
                CompileAG4(@"..\..\..\..\Main\MetaDslx.Compiler\MetaGenerator", @"MetaGeneratorParser");
                Console.WriteLine("----");
                //*/
                /*
                CompileAG4(@"..\..\..\..\Main\MetaDslx.Compiler\MetaModel", @"MetaModelLexer");
                CompileAG4(@"..\..\..\..\Main\MetaDslx.Compiler\MetaModel", @"MetaModelParser");
                Console.WriteLine("----");
                //*/
                /*
                CompileAG4(@"c:\Temp\Meta", @"MetaModelLexer");
                Console.WriteLine("----");
                CompileAG4(@"c:\Temp\Meta", @"MetaModelParser");
                //*/
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelCSharpGenerator.mgen",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelCSharpGenerator.cs"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelJavaGenerator.mgen",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelJavaGenerator.cs"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileMeta(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel.mm",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel1.cs"
                    );
                //*/
                /*
                CompileMeta(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel.mm",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel.java",
                    true
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileMeta(
                    @"k:\VersionControl\soal-java\src\metadslx.soal.runtime\src\main\resources\Soal.mm",
                    @"Soal.java",
                    true);
                //*/
                /*
                using (ModelContextScope scope = new ModelContextScope(MetaInstance.Model))
                {
                    MetaModelGenerator generator = new MetaModelGenerator(ModelContext.Current.Model.Instances);
                    using (StreamWriter writer = new StreamWriter(@"..\..\..\..\Main\MetaDslx.Core\MetaModel00.cs"))
                    {
                        writer.WriteLine(generator.Generate());
                    }
                }
                //*/
                /*
                using (ModelContextScope scope = new ModelContextScope(MetaInstance.Model))
                {
                    ImmutableMetaModelGenerator generator = new ImmutableMetaModelGenerator(ModelContext.Current.Instances);
                    using (StreamWriter writer = new StreamWriter(@"..\..\..\..\Main\MetaDslx.Core\ImmutableMetaModel.cs"))
                    {
                        writer.WriteLine(generator.Generate());
                    }
                }
                //*/
                //PrintScope("", (MutableSymbol)MetaDescriptor.MetaModel.GetMetaClass().Namespace.Parent);
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\Main\MetaDslx.Compiler\LanguageService\MetaLanguageServiceGenerator.mgen",
                    @"..\..\..\..\Main\MetaDslx.Compiler\LanguageService\MetaLanguageServiceGenerator.cs"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\..\..\soal-cs\src\Main\MetaDslx.Soal\SoalPrinter.mgen",
                    @"..\..\..\..\..\..\soal-cs\src\Main\MetaDslx.Soal\SoalPrinter.cs"
                    );
                //*/
                /*
                Console.WriteLine("----");
                GenerateLanguageService(
                    "AnnotatedAntlr4",
                    @"..\..\..\..\Main\MetaDslx.VisualStudio\AnnotatedAntlr4LanguageService.cs",
                    true);
                GenerateLanguageService(
                    "MetaGenerator",
                    @"..\..\..\..\Main\MetaDslx.VisualStudio\MetaGeneratorLanguageService.cs",
                    false);
                GenerateLanguageService(
                    "MetaModel",
                    @"..\..\..\..\Main\MetaDslx.VisualStudio\MetaModelLanguageService.cs",
                    false);
                //*/
                //Console.WriteLine(MetaDslx.Core.Immutable.MetaInstance.String);
                /*
                List<string> items = new List<string>();
                items.Add("a");
                items.Add("x");
                MetaDslx.Core.Immutable.ImmutableModel imodel = MetaDslx.Core.Immutable.MetaInstance.Model;
                foreach (var symbol in imodel.Symbols)
                {
                    Console.WriteLine(symbol);
                    if (symbol is MetaDslx.Core.Immutable.MetaClass)
                    {
                        MetaDslx.Core.Immutable.MetaClass cls = (MetaDslx.Core.Immutable.MetaClass)symbol;
                        Console.WriteLine(cls.Name);
                        Console.WriteLine(cls.Constructor);
                    }
                }
                //*/
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\Main\MetaDslx.Core\Mutable\ImmutableMetaModelGeneratorOld.mgen",
                    @"..\..\..\..\Main\MetaDslx.Core\Mutable\ImmutableMetaModelGeneratorOld.cs"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\Main\MetaDslx.Core\ImmutableMetaModelGenerator.mgen",
                    @"..\..\..\..\Main\MetaDslx.Core\ImmutableMetaModelGenerator.cs"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileImmutableMeta(
                    @"..\..\..\..\Main\MetaDslx.Core\ImmutableMetaModel.mm",
                    @"..\..\..\..\Main\MetaDslx.Core\ImmutableMetaModel1.cs"
                    );
                //*/
                /*
                GenerateImmutableMeta(@"..\..\..\..\Main\MetaDslx.Core\ImmutableMetaModel3.cs");
                //*/
                /*
                Console.WriteLine("----");
                CompileMeta(
                    @"..\..\..\..\Main\MetaDslx.Core\ImmutableMetaModel.mm",
                    @"..\..\..\..\Main\MetaDslx.Core\ImmutableMetaModel1.cs"
                    );
                //*/
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void CompileAG4(string outputDirectory, string antlr4FileName)
        {
            string source;
            string fileName = Path.Combine(outputDirectory, antlr4FileName + ".ag4");
            using (StreamReader reader = new StreamReader(fileName))
            {
                source = reader.ReadToEnd();
            }
            AnnotatedAntlr4Compiler compiler = new AnnotatedAntlr4Compiler(source, outputDirectory, fileName);
            compiler.DefaultNamespace = "MetaDslx.Compiler";
            //compiler.DefaultNamespace = "MetaDslx.Soal";
            compiler.Compile();
            string outputFileName = Path.Combine(outputDirectory, antlr4FileName + "Annotator.cs");
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.WriteLine(compiler.GeneratedSource);
            }
            string g4outputFileName = Path.Combine(outputDirectory, antlr4FileName + ".g4");
            using (StreamWriter writer = new StreamWriter(g4outputFileName))
            {
                writer.WriteLine(compiler.Antlr4Source);
            }
            using (StreamWriter writer = new StreamWriter("messages_a4.txt"))
            {
                foreach (var msg in compiler.Diagnostics.GetMessages(true))
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
            Console.WriteLine(MetaInstance.Bool);
            MetaModelCompiler compiler = new MetaModelCompiler(source, fileName);
            compiler.Compile();
            MutableModel model = compiler.Model;
            ImmutableModel immutableModel = model.ToImmutable();
            if (!compiler.Diagnostics.HasErrors())
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    ImmutableMetaModelGenerator generator = new ImmutableMetaModelGenerator(immutableModel.Symbols);
                    writer.WriteLine(generator.Generate());
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
                        string leading = compiler.TriviaProvider.GetLeadingTrivia(mo);
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
                        }
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
                foreach (var msg in compiler.Diagnostics.GetMessages(true))
                {
                    writer.WriteLine(msg);
                    Console.WriteLine(msg);
                }
            }
        }


        private static void CompileGenerator(string fileName, string outputFileName)
        {
            string source;
            using (StreamReader reader = new StreamReader(fileName))
            {
                source = reader.ReadToEnd();
            }
            MetaGeneratorCompiler compiler = new MetaGeneratorCompiler(source, fileName);
            compiler.Compile();
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                MetaGeneratorGenerator generator = new MetaGeneratorGenerator(compiler.ParseTree);
                writer.WriteLine(generator.GeneratedSource);
            }
            using (StreamWriter writer = new StreamWriter("messages_gen.txt"))
            {
                foreach (var msg in compiler.Diagnostics.GetMessages(true))
                {
                    writer.WriteLine(msg);
                    Console.WriteLine(msg);
                }
            }
        }

        private static void GenerateLanguageService(string language, string outputFileName, bool generateMultipleFiles)
        {
            MetaLanguageServiceGenerator generator = new MetaLanguageServiceGenerator(null);
            generator.Properties.LanguageServiceNamespace = "MetaDslx.VisualStudio";
            generator.Properties.LanguageClassName = language;
            generator.Properties.LanguageFullName = "MetaDslx.Compiler." + language;
            generator.Properties.GenerateMultipleFiles = generateMultipleFiles;
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.WriteLine(generator.Generate());
            }
        }

        private static void LazyPropertyTest()
        {

        }

        private static void GenerateImmutableMeta(string outputFileName)
        {
            MetaDslx.Core.ImmutableModel model = MetaDslx.Core.MetaInstance.Model;
            MetaDslx.Core.ImmutableMetaModelGenerator generator = new MetaDslx.Core.ImmutableMetaModelGenerator(model.Symbols);
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

    }
}
