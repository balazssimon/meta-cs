using MetaDslx.Compiler;
using MetaDslx.Languages.MetaGenerator.Compilation;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.MetaGenerator.Generator
{
    [ComVisible(true)]
    [Guid(MetaGeneratorDefinition.MetaGeneratorGeneratorServiceGuid)]
    [CodeGeneratorRegistration(typeof(MetaGeneratorGenerator), MetaGeneratorDefinition.GeneratorServiceName, "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    [CodeGeneratorRegistration(typeof(MetaGeneratorGenerator), MetaGeneratorDefinition.GeneratorServiceName, "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}", GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(MetaGeneratorGenerator))]
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
