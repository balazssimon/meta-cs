using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Editor
{
    /*[Export(typeof(IWpfTextViewCreationListener))]
    [ContentType(MetaDslxDefinition.ContentType)]
    [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
    [TextViewRole(PredefinedTextViewRoles.EmbeddedPeekTextView)]
    public abstract class MetaDslxTextViewConnectionListener : IWpfTextViewConnectionListener
    {
        [Import]
        internal IContentTypeRegistryService ContentTypeRegistryService = null;

        public void SubjectBuffersConnected(IWpfTextView textView, ConnectionReason reason, Collection<ITextBuffer> subjectBuffers)
        {
            //throw new NotImplementedException();
        }

        public void SubjectBuffersDisconnected(IWpfTextView textView, ConnectionReason reason, Collection<ITextBuffer> subjectBuffers)
        {
            //throw new NotImplementedException();
        }
    }*/
}
