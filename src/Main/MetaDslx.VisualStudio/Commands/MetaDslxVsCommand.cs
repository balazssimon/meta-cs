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
    internal class MetaDslxVsCommand
    {
        private readonly ITextView _textView;
        private readonly IVsTextView _vsTextView;
        private readonly MetaDslxMefServices _mefServices;

        public MetaDslxVsCommand(ITextView textView, IVsTextView vsTextView, MetaDslxMefServices mefServices)
        {
            _textView = textView;
            _vsTextView = vsTextView;
            _mefServices = mefServices;
        }

        public ITextView TextView => _textView;
        public IVsTextView VsTextView => _vsTextView;
        public MetaDslxMefServices MefServices => _mefServices;
    }
}
