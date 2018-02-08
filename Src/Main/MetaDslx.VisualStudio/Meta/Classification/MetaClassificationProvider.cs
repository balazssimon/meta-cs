using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;
using System.IO;
using System.ComponentModel.Composition;

namespace MetaDslx.VisualStudio.Meta.Classification
{
    [Export(typeof(IClassifierProvider))]
    [ContentType(MetaContentTypeDefinition.ContentType)]
    internal class MetaClassificationProvider : IClassifierProvider
    {
        [Import]
        IClassificationTypeRegistryService classificationRegistryService { get; set; }

        IClassifier IClassifierProvider.GetClassifier(ITextBuffer textBuffer)
        {
            // Creates the Meta classifier
            return new MetaClassifier(textBuffer, classificationRegistryService);
        }

    }
}
