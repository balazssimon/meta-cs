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
                //*
                CompileAG4(
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelLexer.ag4",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelLexerAnnotator0.cs",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelLexer.g4"
                    );
                Console.WriteLine("----");
                CompileAG4(
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelParser.ag4",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelParserAnnotator0.cs",
                    @"..\..\..\..\Main\MetaDslx.Compiler\MetaModel\MetaModelParser.g4"
                    );
                //*/
                /*
                Console.WriteLine("----");
                CompileMeta(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel.mm",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel0.cs"
                    );
                //*/
                /*Console.WriteLine("----");
                CompileGenerator(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelGenerator.mgen",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModelGenerator.cs"
                    );*/
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
            foreach (var msg in compiler.Diagnostics.GetMessages(true))
            {
                Console.WriteLine(msg);
            }
        }

        private static void PrintScope(string indent, Scope scope)
        {
            foreach (var entry in scope.Entries)
            {
                Console.WriteLine(indent + entry);
                Scope childScope = entry as Scope;
                if (childScope != null)
                {
                    PrintScope(indent+"  ", childScope);
                }
                else
                {
                    TypeDef typeDef = entry as TypeDef;
                    if (typeDef != null && typeDef.Scope != null)
                    {
                        PrintScope(indent + "  ", typeDef.Scope);
                    }
                    NameDef nameDef = entry as NameDef;
                    if (nameDef != null && nameDef.Scope != null)
                    {
                        PrintScope(indent + "  ", nameDef.Scope);
                    }
                }
            }
        }
        
        private static void CompileMeta(string fileName, string outputFileName)
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
            foreach (var msg in compiler.Diagnostics.GetMessages(true))
            {
                Console.WriteLine(msg);
            }
            PrintScope("", compiler.GlobalScope);
            Console.WriteLine("=");
            
            foreach (var symbol in compiler.Data.SymbolToEntry.Keys)
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
                        Console.WriteLine("  Name=" + mo.MGetValue(mp));
                    }
                    mp = mo.MFindProperty("Uri");
                    if (mp != null)
                    {
                        Console.WriteLine("  Uri=" + mo.MGetValue(mp));
                    }
                    mp = mo.MFindProperty("Type");
                    if (mp != null)
                    {
                        Console.WriteLine("  Type=" + mo.MGetValue(mp));
                    }
                    mp = mo.MFindProperty("ReturnType");
                    if (mp != null)
                    {
                        Console.WriteLine("  ReturnType=" + mo.MGetValue(mp));
                    }
                    mp = mo.MFindProperty("EnumLiterals");
                    if (mp != null)
                    {
                        Console.WriteLine("  EnumLiterals:");
                        foreach (var el in (IList<MetaEnumLiteral>)mo.MGetValue(mp))
                        {
                            Console.WriteLine("    " + el);
                        }
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
            foreach (var msg in compiler.Diagnostics.GetMessages(true))
            {
                Console.WriteLine(msg);
            }
        }

        private static void LazyPropertyTest()
        {

        }

    }
}
