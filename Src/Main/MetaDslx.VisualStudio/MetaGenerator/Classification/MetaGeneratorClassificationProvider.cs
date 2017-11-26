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

namespace MetaDslx.VisualStudio.MetaGenerator.Classification
{
    [Export(typeof(IClassifierProvider))]
    [ContentType(MetaGeneratorContentTypeDefinition.ContentType)]
    internal class MetaGeneratorClassificationProvider : IClassifierProvider
    {
        [Import]
        IClassificationTypeRegistryService classificationRegistryService { get; set; }

        IClassifier IClassifierProvider.GetClassifier(ITextBuffer textBuffer)
        {
            // Creates the MetaGenerator classifier
            return new MetaGeneratorClassifier(textBuffer, classificationRegistryService);
        }

    }
}
