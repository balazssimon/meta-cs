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
    public class MetaTaggerProvider : CompilationTaggerProvider
    {
        public readonly IClassificationTag TypeClassificationTag;

        [ImportingConstructor]
        internal MetaTaggerProvider([Import] ITableManagerProvider provider, [Import] ITextDocumentFactoryService textDocumentFactoryService, [Import] IClassificationTypeRegistryService classificationRegistryService) 
            : base(provider, textDocumentFactoryService, classificationRegistryService)
        {
            this.TypeClassificationTag = new ClassificationTag(this.ClassificationRegistryService.GetClassificationType(MetaClassificationTypes.Type)); 
        }

        public override string DisplayName => "MetaModel";

        protected override LanguageCompilation CreateCompilation(string filePath, string sourceText, CancellationToken cancellationToken)
        {
            var metaModelReference = ModelReference.CreateFromModel(MetaInstance.Model);
            var tree = MetaSyntaxTree.ParseText(sourceText, path: filePath, cancellationToken: cancellationToken);
            var compilation = MetaCompilation.Create("Tagger").AddReferences(metaModelReference).AddSyntaxTrees(tree);
            return compilation;
        }

        public override IClassificationTag GetTokenClassificationTag(SyntaxToken token, SyntaxTree syntaxTree, Compilation compilation, SemanticModel semanticModel)
        {
            MetaTokenKind kind = (MetaTokenKind)token.GetKind().ToAntlr4();
            if (kind == MetaTokenKind.None || kind == MetaTokenKind.Identifier)
            {
                if (this.IsTypeSymbolToken(token, semanticModel))
                {
                    return this.TypeClassificationTag;
                }
                else if (this.IsAnnotationSymbolToken(token, semanticModel))
                {
                    return this.TypeClassificationTag;
                }
            }
            return null;
        }


        protected bool IsTypeSymbolToken(SyntaxToken token, SemanticModel semanticModel)
        {
            SyntaxNode node = token.Parent;
            while (node != null && node.SlotCount == 1)
            {
                var si = semanticModel.GetTypeInfo(node);
                if (si.Type != null) return !(si.Type is IErrorTypeSymbol);
                node = node.Parent;
            }
            return false;
        }

        protected bool IsAnnotationSymbolToken(SyntaxToken token, SemanticModel semanticModel)
        {
            SyntaxNode node = token.Parent;
            while (node != null && node.SlotCount == 1)
            {
                var si = semanticModel.GetSymbolInfo(node);
                if (si.Symbol != null) return si.Symbol is MetaAttribute;
                node = node.Parent;
            }
            return false;
        }

    }
}
