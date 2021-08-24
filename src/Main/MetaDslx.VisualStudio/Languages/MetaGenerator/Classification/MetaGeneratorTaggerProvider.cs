using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.VisualStudio.Classification;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.MetaGenerator.Classification
{
    /*
    //[Export(typeof(ITaggerProvider))]
    [Export(typeof(IViewTaggerProvider))]
    [TagType(typeof(IErrorTag))]
    [TagType(typeof(IClassificationTag))]
    [TagType(typeof(ITextMarkerTag))]
    //[TagType(typeof(ReferencesTag))]
    //[TagType(typeof(IntraTextAdornmentTag))]
    [ContentType(MetaGeneratorDefinition.ContentType)]
    public class MetaGeneratorTaggerProvider : MetaDslxTaggerProvider
    {
        internal MetaGeneratorTaggerProvider()
        {
        }

        public override string DisplayName => "MetaGenerator";

        public override IClassificationType GetSymbolClassificationType(Symbol symbol, SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            return null;
        }
    }
    */
}
