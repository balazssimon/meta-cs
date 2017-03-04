using MetaDslx.Compiler;
using MetaDslx.Core;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Generator;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Meta.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio
{
    public class MetaGenerator : SingleFileGenerator
    {
        public const string DefaultExtension = ".cs";

        private MetaCompilation compilation;
        private ImmutableModel immutableModel;

        public MetaGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
            : base(inputFilePath, inputFileContents, defaultNamespace)
        {
            var source = this.InputFileContents;
            if (source != null)
            {
                var metaModelReference = MetadataReference.CreateFromModel(MetaInstance.Model);
                var tree = MetaSyntaxTree.ParseText(source);
                this.compilation = MetaCompilation.Create("Meta").AddReferences(metaModelReference).AddSyntaxTrees(tree);
                this.immutableModel = compilation.Model;
            }
        }

        public override string GenerateStringContent()
        {
            if (this.compilation == null)
            {
                return string.Empty;
            }
            else
            {
                ImmutableMetaModelGenerator generator = new ImmutableMetaModelGenerator(this.immutableModel.Symbols);
                return generator.Generate();
            }
        }
    }
    
}
