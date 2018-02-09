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

namespace MetaDslx.VisualStudio.Languages.Soal.Classification
{
    [Export(typeof(IClassifierProvider))]
    [ContentType(SoalDefinition.ContentType)]
    internal class SoalClassificationProvider : IClassifierProvider
    {
        [Import]
        IClassificationTypeRegistryService classificationRegistryService { get; set; }

        IClassifier IClassifierProvider.GetClassifier(ITextBuffer textBuffer)
        {
            // Creates the Soal classifier
            return new SoalClassifier(textBuffer, classificationRegistryService);
        }

    }
}
