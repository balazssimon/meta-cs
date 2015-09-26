using MetaDslx.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    public class MetaModelGenerator : SingleFileGenerator
    {
        private MetaModelCompiler compiler;

        public MetaModelGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
            if (this.InputFileContents != null)
            {
                compiler = new MetaModelCompiler(this.InputFileContents);
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
