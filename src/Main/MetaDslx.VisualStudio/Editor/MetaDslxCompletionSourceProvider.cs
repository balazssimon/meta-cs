using MetaDslx.VisualStudio.Intellisense;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Editor
{
    [Export(typeof(ICompletionSourceProvider))]
    [Name("MetaDslx Intellisense")]
    [ContentType(MetaDslxDefinition.ContentType)]
    [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
    [TextViewRole(PredefinedTextViewRoles.EmbeddedPeekTextView)]
    public class MetaDslxCompletionSourceProvider : ICompletionSourceProvider
    {
        [Import]
        private MetaDslxMefServices _mefServices = null;

        [Import]
        internal ITextStructureNavigatorSelectorService NavigatorService { get; set; }

        public ICompletionSource TryCreateCompletionSource(ITextBuffer textBuffer)
        {
            return CompletionSource.GetOrCreate(_mefServices, this, textBuffer);
        }
    }
}
