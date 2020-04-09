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
using MetaDslx.VisualStudio.Utilities;

namespace MetaDslx.VisualStudio.Languages.MetaGenerator.Classification
{
    [Export(typeof(IClassifierProvider))]
    [ContentType(MetaGeneratorDefinition.ContentType)]
    internal class MetaGeneratorClassificationProvider : IClassifierProvider
    {
        [Import]
        private MetaDslxMefServices _mefServices;

        IClassifier IClassifierProvider.GetClassifier(ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new MetaGeneratorClassifier(textBuffer, _mefServices));
        }

    }
}
