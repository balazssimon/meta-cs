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

namespace MetaDslx.VisualStudio.Languages.Antlr4Roslyn.Classification
{
    /*
    //[Export(typeof(ITaggerProvider))]
    [Export(typeof(IViewTaggerProvider))]
    [TagType(typeof(IErrorTag))]
    [TagType(typeof(IClassificationTag))]
    [TagType(typeof(ITextMarkerTag))]
    //[TagType(typeof(ReferencesTag))]
    //[TagType(typeof(IntraTextAdornmentTag))]
    [ContentType(Antlr4RoslynDefinition.ContentType)]
    public class Antlr4RoslynTaggerProvider : MetaDslxTaggerProvider
    {
        internal Antlr4RoslynTaggerProvider()
        {
        }

        public override string DisplayName => "Antlr4Roslyn";

        public override IClassificationType GetSymbolClassificationType(Symbol symbol, SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            return null;
        }
    }*/
}
