using MetaDslx.Compiler;
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
                CompileAG4(
                    @"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4\AnnotatedAntlr4Lexer.ag4",
                    @"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4\AnnotatedAntlr4LexerAnnotator.cs",
                    @"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4\AnnotatedAntlr4Lexer.g4"
                    );
                Console.WriteLine("----");
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
                Console.WriteLine("----");
                CompileMeta(
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel.mm",
                    @"..\..\..\..\Main\MetaDslx.Core\MetaModel0.cs"
                    );
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
            foreach (var msg in compiler.Diagnostics.GetMessages())
            {
                Console.WriteLine(msg);
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
            //compiler.CSharpNamespace = "MetaDslx.Core";
            compiler.Compile();
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.WriteLine(compiler.GeneratedSource);
            }
            foreach (var msg in compiler.Diagnostics.GetMessages())
            {
                Console.WriteLine(msg);
            }
            foreach (var entry in compiler.GlobalScope.Children)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
