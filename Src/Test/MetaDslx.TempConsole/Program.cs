using MetaDslx.Compiler;
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
                CompileAG4(
                    @"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4\AnnotatedAntlr4Lexer.ag4",
                    @"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4\AnnotatedAntlr4LexerAnnotator.cs",
                    @"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4\AnnotatedAntlr4Lexer.g4"
                    );
                Console.WriteLine("----");
                //*/
                /*
                CompileAG4(
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaGenerator\MetaGeneratorLexer.ag4",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaGenerator\MetaGeneratorLexerAnnotator.cs",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaGenerator\MetaGeneratorLexer.g4"
                    );
                Console.WriteLine("----");
                //*/
                /*
                CompileAG4(
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelLexer.ag4",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelLexerAnnotator.cs",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelLexer.g4"
                    );
                Console.WriteLine("----");
                CompileAG4(
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelParser.ag4",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelParserAnnotator.cs",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelParser.g4"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelGenerator.mgen",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelGenerator.cs"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileMeta(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel.mm",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel0.cs"
                    );
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
                //PrintScope("", (ModelObject)MetaDescriptor.MetaModel.GetMetaClass().Namespace.Parent);
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\Main\MetaDslx.Compiler\LanguageService\MetaLanguageServiceGenerator.mgen",
                    @"..\..\..\..\Main\MetaDslx.Compiler\LanguageService\MetaLanguageServiceGenerator.cs"
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void CompileAG4(string fileName, string outputFileName, string antlr4FileName)
        {
            string source;
            using (StreamReader reader = new StreamReader(fileName))
            {
                source = reader.ReadToEnd();
            }
            AnnotatedAntlr4Compiler compiler = new AnnotatedAntlr4Compiler(source, fileName);
            compiler.CSharpNamespace = "MetaDslx.Compiler";
            compiler.Compile();
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.WriteLine(compiler.GeneratedSource);
            }
            using (StreamWriter writer = new StreamWriter(antlr4FileName))
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

        private static void PrintScope(string indent, ModelObject scope)
        {
            foreach (var entry in scope.MChildren)
            {
                Console.WriteLine(indent + entry);
                if (entry.IsMetaScope())
                {
                    PrintScope(indent + "  ", entry);
                }
            }
        }
        
        private static void CompileMeta(string fileName, string outputFileName)
        {
            //Meta.MetaTypedElement.StaticInit();
            //Console.WriteLine(Meta.MetaTypedElement.TypeProperty);
            //Meta.StaticInit();
            //Console.WriteLine(Meta.Model);
                        
            Model model = new Model();
            using (new ModelContextScope(model))
            {
                string source;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    source = reader.ReadToEnd();
                }
                MetaModelCompiler compiler = new MetaModelCompiler(source, fileName);
                compiler.Compile();
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(compiler.GeneratedSource);
                }
                //PrintScope("", compiler.GlobalScope);
                Console.WriteLine("=");

                using (StreamWriter writer = new StreamWriter("symbols.txt"))
                {
                    foreach (var symbol in ModelContext.Current.Model.Instances)
                    {
                        ModelObject mo = symbol as ModelObject;
                        if (mo != null)
                        {
                            writer.WriteLine(mo);
                            Console.WriteLine(mo);
                            writer.WriteLine("  Parent=" + mo.MParent);
                            Console.WriteLine("  Parent=" + mo.MParent);
                            ModelProperty mp;
                            mp = mo.MFindProperty("Name");
                            if (mp != null)
                            {
                                writer.WriteLine("  Name=" + mo.MGet(mp));
                                Console.WriteLine("  Name=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperty("Uri");
                            if (mp != null)
                            {
                                writer.WriteLine("  Uri=" + mo.MGet(mp));
                                Console.WriteLine("  Uri=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperty("IsAbstract");
                            if (mp != null)
                            {
                                writer.WriteLine("  IsAbstract=" + mo.MGet(mp));
                                Console.WriteLine("  IsAbstract=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperty("NoTypeError");
                            if (mp != null)
                            {
                                writer.WriteLine("  NoTypeError=" + mo.MGet(mp));
                                Console.WriteLine("  NoTypeError=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperties("ExpectedType").FirstOrDefault();
                            if (mp != null)
                            {
                                writer.WriteLine("  ExpectedType=" + mo.MGet(mp));
                                Console.WriteLine("  ExpectedType=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperties("Type").FirstOrDefault();
                            if (mp != null)
                            {
                                writer.WriteLine("  Type=" + mo.MGet(mp));
                                Console.WriteLine("  Type=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperties("InnerType").FirstOrDefault();
                            if (mp != null)
                            {
                                writer.WriteLine("  InnerType=" + mo.MGet(mp));
                                Console.WriteLine("  InnerType=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperties("ReturnType").FirstOrDefault();
                            if (mp != null)
                            {
                                writer.WriteLine("  ReturnType=" + mo.MGet(mp));
                                Console.WriteLine("  ReturnType=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperty("Object");
                            if (mp != null)
                            {
                                writer.WriteLine("  Object=" + mo.MGet(mp));
                                Console.WriteLine("  Object=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperty("Property");
                            if (mp != null)
                            {
                                writer.WriteLine("  Property=" + mo.MGet(mp));
                                Console.WriteLine("  Property=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperty("Value");
                            if (mp != null)
                            {
                                writer.WriteLine("  Value=" + mo.MGet(mp));
                                Console.WriteLine("  Value=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperty("Definition");
                            if (mp != null)
                            {
                                writer.WriteLine("  Definition=" + mo.MGet(mp));
                                Console.WriteLine("  Definition=" + mo.MGet(mp));
                            }
                            mp = mo.MFindProperty("EnumLiterals");
                            if (mp != null)
                            {
                                writer.WriteLine("  EnumLiterals:");
                                Console.WriteLine("  EnumLiterals:");
                                foreach (var el in (IList<MetaEnumLiteral>)mo.MGet(mp))
                                {
                                    writer.WriteLine("    " + el);
                                    Console.WriteLine("    " + el);
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
                writer.WriteLine(compiler.GeneratedSource);
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

    }
}
