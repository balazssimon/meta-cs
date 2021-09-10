using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Shell.TableManager;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
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
    //[Export(typeof(ITaggerProvider))]
    [Export(typeof(IViewTaggerProvider))]
    [TagType(typeof(IErrorTag))]
    [TagType(typeof(IClassificationTag))]
    [TagType(typeof(ITextMarkerTag))]
    //[TagType(typeof(ReferencesTag))]
    //[TagType(typeof(IntraTextAdornmentTag))]
    [ContentType(MetaDefinition.ContentType)]
    public class MetaTaggerProvider : MetaDslxTaggerProvider
    {
        private MetaSyntaxFacts _syntaxFacts;

        internal MetaTaggerProvider() 
        {
            _syntaxFacts = MetaLanguage.Instance.SyntaxFacts;
        }

        public override string DisplayName => "MetaModel";

        public override IClassificationType GetSymbolClassificationType(Symbol symbol, SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (symbol is VariableSymbol varSymbol && !symbol.IsError && varSymbol is IModelSymbol msymbol && msymbol.ModelObject is MetaConstantBuilder mconst && mconst?.Type?.MMetaClass is MetaType)
            {
                if (!symbol.Locations.Any(loc => loc.SourceSpan == token.Span)) return this.StandardClassificationService.SymbolDefinition; // this.StandardClassificationService.SymbolReference
                //else return this.StandardClassificationService.SymbolDefinition; // this.StandardClassificationService.SymbolReference
            }
            if (symbol is TypeSymbol typeSymbol && !symbol.IsError)
            {
                if (symbol.Locations.Any(loc => loc.SourceSpan == token.Span)) return this.StandardClassificationService.SymbolDefinition;
                else return this.StandardClassificationService.SymbolDefinition; // this.StandardClassificationService.SymbolReference
            }
            if (symbol is MetaAttribute) return this.StandardClassificationService.SymbolDefinition; // this.StandardClassificationService.SymbolReference
            return null;
        }
    }
}
