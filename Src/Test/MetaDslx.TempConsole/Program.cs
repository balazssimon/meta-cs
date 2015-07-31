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
                //*
                Console.WriteLine("----");
                CompileMeta(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel.mm",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel0.cs"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelGenerator.mgen",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelGenerator.cs"
                    );
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
            using (StreamWriter writer = new StreamWriter("messages.txt"))
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
            /*
            foreach (var symbol in compiler.Data.GetSymbols())
            {
                ModelObject mo = symbol as ModelObject;
                if (mo != null)
                {
                    Console.WriteLine(mo);
                    Console.WriteLine("  Parent=" + mo.MParent);
                    ModelProperty mp;
                    mp = mo.MFindProperty("Name");
                    if (mp != null)
                    {
                        Console.WriteLine("  Name=" + mo.MGet(mp));
                    }
                    mp = mo.MFindProperty("Uri");
                    if (mp != null)
                    {
                        Console.WriteLine("  Uri=" + mo.MGet(mp));
                    }
                    mp = mo.MFindProperty("Type");
                    if (mp != null)
                    {
                        Console.WriteLine("  Type=" + mo.MGet(mp));
                    }
                    mp = mo.MFindProperty("ReturnType");
                    if (mp != null)
                    {
                        Console.WriteLine("  ReturnType=" + mo.MGet(mp));
                    }
                    mp = mo.MFindProperty("EnumLiterals");
                    if (mp != null)
                    {
                        Console.WriteLine("  EnumLiterals:");
                        foreach (var el in (IList<MetaEnumLiteral>)mo.MGet(mp))
                        {
                            Console.WriteLine("    " + el);
                        }
                    }
                }
            }
            */
            using (StreamWriter writer = new StreamWriter("messages.txt"))
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
                writer.WriteLine(compiler.GeneratedSource);
            }
            using (StreamWriter writer = new StreamWriter("messages.txt"))
            {
                foreach (var msg in compiler.Diagnostics.GetMessages(true))
                {
                    writer.WriteLine(msg);
                    Console.WriteLine(msg);
                }
            }
        }

        private static void LazyPropertyTest()
        {

        }

    }
}
