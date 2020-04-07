using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Model;
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
    [TagType(typeof(ITextMarkerTag))]
    [ContentType(MetaDefinition.ContentType)]
    public class MetaTaggerProvider : CompilationTaggerProvider
    {
        public readonly IClassificationTag TypeClassificationTag;

        private MetaSyntaxFacts _syntaxFacts;

        [ImportingConstructor]
        internal MetaTaggerProvider([Import] ITableManagerProvider provider, [Import] ITextDocumentFactoryService textDocumentFactoryService, [Import] IClassificationTypeRegistryService classificationRegistryService) 
            : base(provider, textDocumentFactoryService, classificationRegistryService)
        {
            this.TypeClassificationTag = new ClassificationTag(this.ClassificationRegistryService.GetClassificationType(MetaClassificationTypes.Type));
            _syntaxFacts = MetaLanguage.Instance.SyntaxFacts;
        }

        public override string DisplayName => "MetaModel";

        public override IClassificationTag GetSymbolClassificationTag(ISymbol symbol, SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (symbol is ITypeSymbol && !(symbol is IErrorTypeSymbol)) return TypeClassificationTag;
            if (symbol is MetaAttribute) return TypeClassificationTag;
            return null;
        }
    }
}
