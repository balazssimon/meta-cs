using Antlr4.Runtime;
using MetaDslx.Languages.MetaGenerator.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using System.IO;
using MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax;
using System.Runtime.InteropServices.ComTypes;

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
        public string GeneratedExtensions { get; private set; }

        public MetaGeneratorCompiler(string manualOutputDirectory, string automaticOutputDirectory, string inputFilePath, string defaultNamespace = null)
            : base(manualOutputDirectory, automaticOutputDirectory, inputFilePath, defaultNamespace)
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
            (this.GeneratedSource, this.GeneratedExtensions) = this.generator.Generate();

            if (this.GenerateOutput)
            {
                var bareFilePath = Path.ChangeExtension(this.InputFilePath, null);
                this.WriteOutputFile(bareFilePath + ".cs", this.GeneratedSource);
                if (this.GeneratedExtensions != null)
                {
                    this.WriteOutputFile(bareFilePath + "Extensions.cs", this.GeneratedExtensions, automatic: false);
                }
            }
        }
    }

}
