using Microsoft.VisualStudio.Text.Editor;
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
        private readonly IServiceProvider _serviceProvider;

        public MetaDslxVsCommand(ITextView textView, IServiceProvider serviceProvider)
        {
            _textView = textView;
            _serviceProvider = serviceProvider;
        }

        public ITextView TextView => _textView;
        public IServiceProvider ServiceProvider => _serviceProvider;
    }
}
