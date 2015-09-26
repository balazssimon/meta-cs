using MetaDslx.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    public class MetaGeneratorGenerator : SingleFileGenerator
    {
        private MetaGeneratorCompiler compiler;

        public MetaGeneratorGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
            if (this.InputFileContents != null)
            {
                compiler = new MetaGeneratorCompiler(this.InputFileContents);
                compiler.Compile();
            }
        }

        public override string GetFileExtension()
        {
            return ".cs";
        }

        public override string GenerateStringContent()
        {
            if (compiler == null) return string.Empty;
            else return compiler.GeneratedSource;
        }
    }
}
