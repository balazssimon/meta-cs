using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.VisualStudio.Classification;
using Microsoft.CodeAnalysis;
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
    public class MetaTaggerProvider : LanguageCompilationTaggerProvider
    {
        public readonly IClassificationTag TypeClassificationTag;

        private MetaSyntaxFacts _syntaxFacts;

        [ImportingConstructor]
        internal MetaTaggerProvider([Import] ITableManagerProvider provider, [Import] ITextDocumentFactoryService textDocumentFactoryService, [Import] IClassificationTypeRegistryService classificationRegistryService) 
            : base(provider, textDocumentFactoryService, classificationRegistryService, MetaLanguage.Instance)
        {
            this.TypeClassificationTag = new ClassificationTag(this.ClassificationRegistryService.GetClassificationType(MetaClassificationTypes.Type));
            _syntaxFacts = MetaLanguage.Instance.SyntaxFacts;
        }

        public override string DisplayName => "MetaModel";

        protected override ICompilation CreateCompilation(string filePath, string sourceText, CancellationToken cancellationToken)
        {
            var metaModelReference = ModelReference.CreateFromModel(MetaInstance.Model);
            var tree = MetaSyntaxTree.ParseText(sourceText, path: filePath, cancellationToken: cancellationToken);
            var compilation = MetaCompilation.Create("Tagger").AddReferences(metaModelReference).AddSyntaxTrees(tree);
            return compilation;
        }

        protected override IClassificationTag GetSymbolClassificationTag(SyntaxNode node, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            var ti = semanticModel.GetTypeInfo(node, cancellationToken);
            if (ti.Type != null && !(ti.Type is IErrorTypeSymbol)) return TypeClassificationTag;
            var si = semanticModel.GetSymbolInfo(node, cancellationToken);
            if (si.Symbol is MetaAttribute) return TypeClassificationTag;
            return null;
        }

    }
}
