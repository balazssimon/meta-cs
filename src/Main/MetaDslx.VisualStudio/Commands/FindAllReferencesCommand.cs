using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Commands
{
    internal class FindAllReferencesCommand : MetaDslxVsCommand
    {
        public FindAllReferencesCommand(IWpfTextView textView, IVsTextView vsTextView, MetaDslxMefServices mefServices) 
            : base(textView, vsTextView, mefServices)
        {
        }

        public void Execute()
        {

        }
    }
}
