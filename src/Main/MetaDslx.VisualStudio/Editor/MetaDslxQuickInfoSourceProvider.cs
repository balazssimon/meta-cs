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
    [Export(typeof(IAsyncQuickInfoSourceProvider))]
    [Name("MetaDslx QuickInfo Source")]
    [ContentType(MetaDslxDefinition.ContentType)]
    [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
    [TextViewRole(PredefinedTextViewRoles.EmbeddedPeekTextView)]
    public class MetaDslxQuickInfoSourceProvider : IAsyncQuickInfoSourceProvider
    {
        [Import]
        private MetaDslxMefServices _mefServices = null;

        public IAsyncQuickInfoSource TryCreateQuickInfoSource(ITextBuffer textBuffer)
        {
            return SymbolQuickInfoSource.GetOrCreate(_mefServices, this, textBuffer);
        }
    }
}
