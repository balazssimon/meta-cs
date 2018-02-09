using MetaDslx.Compiler;
using MetaDslx.Core;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Generator;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Meta.Syntax;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Meta.CodeGeneration
{
    [ComVisible(true)]
    [Guid(MetaDefinition.GeneratorServiceGuid)]
    [CodeGeneratorRegistration(typeof(MetaGenerator), MetaDefinition.GeneratorServiceName, "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    [CodeGeneratorRegistration(typeof(MetaGenerator), MetaDefinition.GeneratorServiceName, "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}", GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(MetaGenerator))]
    public class MetaGenerator : SingleFileGenerator
    {
        public const string DefaultExtension = ".cs";

        public MetaGenerator()
            : base()
        {
        }

        public override string GenerateStringContent()
        {
            var metaModelReference = MetadataReference.CreateFromModel(MetaInstance.Model);
            var tree = MetaSyntaxTree.ParseText(this.InputFileContents);
            var compilation = MetaCompilation.Create("Meta").AddReferences(metaModelReference).AddSyntaxTrees(tree);
            ImmutableModel immutableModel = compilation.Model;
            ImmutableMetaModelGenerator generator = new ImmutableMetaModelGenerator(immutableModel.Symbols);
            string code = generator.Generate();
            return code;
        }

        protected override string GetDefaultExtension()
        {
            return DefaultExtension;
        }
    }
}
