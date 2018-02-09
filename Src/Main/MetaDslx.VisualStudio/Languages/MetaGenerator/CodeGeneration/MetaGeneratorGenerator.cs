using MetaDslx.Languages.MetaGenerator.Compilation;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.MetaGenerator.CodeGeneration
{
    [ComVisible(true)]
    [Guid(MetaGeneratorDefinition.GeneratorServiceGuid)]
    [CodeGeneratorRegistration(typeof(MetaGeneratorGenerator), MetaGeneratorDefinition.GeneratorServiceName, "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    [CodeGeneratorRegistration(typeof(MetaGeneratorGenerator), MetaGeneratorDefinition.GeneratorServiceName, "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}", GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(MetaGeneratorGenerator))]
    public class MetaGeneratorGenerator : SingleFileGenerator
    {
        public const string DefaultExtension = ".cs";

        public MetaGeneratorGenerator()
            : base()
        {
        }

        public override string GenerateStringContent()
        {
            MetaGeneratorCompiler compiler = new MetaGeneratorCompiler(this.InputFileContents, this.DefaultNamespace, this.InputFileDirectory, this.InputFileDirectory, this.InputFileName);
            compiler.Generate();
            return compiler.GeneratedSource;
        }

        protected override string GetDefaultExtension()
        {
            return DefaultExtension;
        }
    }
}
