using MetaDslx.VisualStudio.Intellisense;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Editor
{
    [Export(typeof(IIntellisenseControllerProvider))]
    [Name("MetaDslx Intellisence")]
    [ContentType(MetaDslxDefinition.ContentType)]
    [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
    [TextViewRole(PredefinedTextViewRoles.EmbeddedPeekTextView)]
    public class MetaDslxIntellisenseControllerProvider : IIntellisenseControllerProvider
    {
        [Import]
        private MetaDslxMefServices _mefServices = null;

        [Import]
        internal IAsyncQuickInfoBroker QuickInfoBroker { get; set; }

        public IIntellisenseController TryCreateIntellisenseController(ITextView textView, IList<ITextBuffer> subjectBuffers)
        {
            return IntellisenseController.GetOrCreate(_mefServices, (IWpfTextView)textView, subjectBuffers, this);
        }
    }
}
