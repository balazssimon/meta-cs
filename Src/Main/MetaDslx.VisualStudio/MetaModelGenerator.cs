using MetaDslx.Compiler;
using MetaDslx.Core.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    public class MetaModelGenerator : SingleFileGenerator
    {
        public const string DefaultExtension = ".cs";

        private MetaModelCompiler compiler;

        public MetaModelGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
            if (this.InputFileContents != null)
            {
                compiler = new MetaModelCompiler(this.InputFileContents, this.InputFileName);
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
                ImmutableMetaModelGenerator generator = new ImmutableMetaModelGenerator(compiler.Model.ToImmutable().Symbols);
                return generator.Generate();
            }
        }
    }
    
}
