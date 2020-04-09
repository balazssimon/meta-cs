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

namespace MetaDslx.VisualStudio.Languages.Antlr4Roslyn.Classification
{
    [Export(typeof(IClassifierProvider))]
    [ContentType(Antlr4RoslynDefinition.ContentType)]
    internal class Antlr4RoslynClassificationProvider : IClassifierProvider
    {
        [Import]
        private MetaDslxMefServices _mefServices;

        IClassifier IClassifierProvider.GetClassifier(ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new Antlr4RoslynClassifier(textBuffer, _mefServices));
        }

    }
}
