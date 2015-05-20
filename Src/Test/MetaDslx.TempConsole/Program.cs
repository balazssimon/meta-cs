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
                string fileName = @"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4Lexer.ag4";
                string outputFileName = @"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4LexerAnnotator.cs";
                string antlr4FileName = @"..\..\..\..\Main\MetaDslx.Compiler\AnnotatedAntlr4Lexer.g4";
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

                Console.WriteLine("----");
                fileName = @"..\..\..\..\Main\MetaDslx.Compiler\MetaLexer.ag4";
                outputFileName = @"..\..\..\..\Main\MetaDslx.Compiler\MetaLexerAnnotator.cs";
                antlr4FileName = @"..\..\..\..\Main\MetaDslx.Compiler\MetaLexer.g4";
                using (StreamReader reader = new StreamReader(fileName))
                {
                    source = reader.ReadToEnd();
                }
                compiler = new AnnotatedAntlr4Compiler(source, fileName);
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

                Console.WriteLine("----");

                fileName = @"..\..\..\..\Main\MetaDslx.Compiler\MetaParser.ag4";
                outputFileName = @"..\..\..\..\Main\MetaDslx.Compiler\MetaParserAnnotator.cs";
                antlr4FileName = @"..\..\..\..\Main\MetaDslx.Compiler\MetaParser.g4";
                using (StreamReader reader = new StreamReader(fileName))
                {
                    source = reader.ReadToEnd();
                }
                compiler = new AnnotatedAntlr4Compiler(source, fileName);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
