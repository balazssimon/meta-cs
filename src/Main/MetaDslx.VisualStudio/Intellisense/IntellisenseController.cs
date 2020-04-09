using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Intellisense
{
    public class IntellisenseController : IIntellisenseController
    {
        private IWpfTextView _textView;
        private readonly IList<ITextBuffer> _subjectBuffers; 
        private readonly MetaDslxIntellisenseControllerProvider _provider;

        internal IntellisenseController(MetaDslxMefServices mefServices, IWpfTextView textView, IList<ITextBuffer> subjectBuffers, MetaDslxIntellisenseControllerProvider provider)
        {
            _textView = textView;
            _subjectBuffers = subjectBuffers;
            _provider = provider;
        }

        public static IntellisenseController GetOrCreate(MetaDslxMefServices mefServices, IWpfTextView textView, IList<ITextBuffer> subjectBuffers, MetaDslxIntellisenseControllerProvider provider)
        {
            return textView.Properties.GetOrCreateSingletonProperty(() => new IntellisenseController(
                mefServices,
                textView,
                subjectBuffers,
                provider
            ));
        }

        public void Detach(ITextView textView)
        {
            if (_textView == textView)
            {
                _textView = null;
            }
        }

        public void ConnectSubjectBuffer(ITextBuffer subjectBuffer)
        {
        }

        public void DisconnectSubjectBuffer(ITextBuffer subjectBuffer)
        {
        }
    }
}
