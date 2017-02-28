using MetaDslx.Compiler;
using MetaDslx.Languages.MetaGenerator.Compilation;
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
                compiler = new MetaGeneratorCompiler(this.InputFileContents, defaultNamespace, this.InputDirectory, null, this.InputFileName);
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
                compiler.Generate();
                return compiler.GeneratedSource;
            }
        }
    }
}
