using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using Microsoft.VisualStudio.Editor;
using System.IO;
using System.ComponentModel.Composition;
using MetaDslx.VisualStudio.Antlr4Roslyn.Classification;

namespace MetaDslx.VisualStudio.OriginalAntlr4.Classification
{
    [Export(typeof(IClassifierProvider))]
    [ContentType(OriginalAntlr4ContentTypeDefinition.ContentType)]
    internal class OriginalAntlr4ClassificationProvider : IClassifierProvider
    {
        [Import]
        IClassificationTypeRegistryService classificationRegistryService { get; set; }

        IClassifier IClassifierProvider.GetClassifier(ITextBuffer textBuffer)
        {
            // Creates the OriginalAntlr4 classifier
            return new Antlr4RoslynClassifier(textBuffer, classificationRegistryService);
        }

    }
}
