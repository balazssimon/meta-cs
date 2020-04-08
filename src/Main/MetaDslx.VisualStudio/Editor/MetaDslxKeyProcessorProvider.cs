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
    [Export(typeof(IKeyProcessorProvider))]
    [ContentType(MetaDslxDefinition.ContentType)]
    [Name("MetaDslxKeyProcessor")]
    [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
    [TextViewRole(PredefinedTextViewRoles.EmbeddedPeekTextView)]
    public class MetaDslxKeyProcessorProvider : IKeyProcessorProvider
    {
        [Import]
        private MetaDslxMefServices _mefServices = null;

        public KeyProcessor GetAssociatedProcessor(IWpfTextView wpfTextView)
        {
            return MetaDslxKeyProcessor.GetOrCreate(_mefServices, wpfTextView);
        }
    }
}
