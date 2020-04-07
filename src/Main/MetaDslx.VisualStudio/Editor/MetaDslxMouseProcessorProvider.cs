using MetaDslx.VisualStudio.Commands;
using MetaDslx.VisualStudio.Utilities;
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
    [Export(typeof(IMouseProcessorProvider))]
    [ContentType(MetaDslxDefinition.ContentType)]
    [Name("MetaDslxMouseProcessor")]
    [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
    [TextViewRole(PredefinedTextViewRoles.EmbeddedPeekTextView)]
    public class MetaDslxMouseProcessorProvider : IMouseProcessorProvider
    {
        [Import]
        private MetaDslxMefServices _mefServices = null;

        public IMouseProcessor GetAssociatedProcessor(IWpfTextView wpfTextView)
        {
            return MetaDslxMouseProcessor.GetOrCreate(_mefServices, wpfTextView);
        }
    }
}
