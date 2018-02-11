using MetaDslx.Compiler;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.VisualStudio.Classification;
using Microsoft.VisualStudio.Shell.TableManager;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Meta.Classification
{
    [Export(typeof(IViewTaggerProvider))]
    [TagType(typeof(IErrorTag))]
    [TagType(typeof(IClassificationTag))]
    [ContentType(MetaDefinition.ContentType)]
    public class MetaTaggerProvider : CompilationTaggerProvider
    {
        [ImportingConstructor]
        internal MetaTaggerProvider([Import] ITableManagerProvider provider, [Import] ITextDocumentFactoryService textDocumentFactoryService) 
            : base(provider, textDocumentFactoryService)
        {
        }

        public override string DisplayName => "MetaModel";

        protected override Compilation CreateCompilation(string filePath, string sourceText, CancellationToken cancellationToken)
        {
            var metaModelReference = MetadataReference.CreateFromModel(MetaInstance.Model);
            var tree = MetaSyntaxTree.ParseText(sourceText, path: filePath, cancellationToken: cancellationToken);
            var compilation = MetaCompilation.Create(filePath).AddReferences(metaModelReference).AddSyntaxTrees(tree);
            return compilation;
        }
    }
}
