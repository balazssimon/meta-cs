using MetaDslx.Compiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    public class MetaGeneratorGenerator : SingleFileGenerator
    {
        public const string DefaultExtension = ".cs";

        private MetaGeneratorCompiler compiler;

        public MetaGeneratorGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
            if (this.InputFileContents != null)
            {
                compiler = new MetaGeneratorCompiler(this.InputFileContents, this.InputFileName);
                compiler.Compile();
            }
        }

        public override string GenerateStringContent()
        {
            if (compiler == null)
            {
                return string.Empty;
            }
            else
            {
                MetaDslx.Compiler.MetaGeneratorGenerator generator = new Compiler.MetaGeneratorGenerator(compiler.ParseTree);
                return generator.Generate();
            }
        }
    }
}
