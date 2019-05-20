using Antlr4.Runtime;
using MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax;
using MetaDslx.Languages.MetaGenerator.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using System.IO;

namespace MetaDslx.Languages.MetaGenerator.Compilation
{
    public class MetaGeneratorSyntaxKind
    {
        public const int TemplateOutput = 13;
        public const int TemplateControl = 14;
    }

    public class MetaGeneratorCompiler : Antlr4Compiler<MetaGeneratorLexer, MetaGeneratorParser>
    {
        private MetaGeneratorGenerator generator;
        public string GeneratedSource { get; private set; }

        public MetaGeneratorCompiler(string inputFilePath, string outputDirectory, string defaultNamespace = null)
            : base(inputFilePath, outputDirectory, defaultNamespace)
        {
        }

        protected override MetaGeneratorLexer CreateLexer(AntlrInputStream stream)
        {
            return new MetaGeneratorLexer(stream);
        }

        protected override MetaGeneratorParser CreateParser(CommonTokenStream stream)
        {
            return new MetaGeneratorParser(stream);
        }

        protected override ParserRuleContext DoCreateTree()
        {
            return this.Parser.main();
        }

        protected override void DoCompile()
        {
            this.generator = new MetaGeneratorGenerator(this.ParseTree);
        }

        protected override void DoGenerate()
        {
            this.GeneratedSource = this.generator.GeneratedSource;

            if (this.GenerateOutput && this.OutputDirectory != null)
            {
                string fileName = Path.Combine(this.OutputDirectory, Path.ChangeExtension(this.FileName, ".cs"));
                this.RegisterGeneratedFile(fileName);
                File.WriteAllText(fileName, this.GeneratedSource);
            }
        }
    }

}
