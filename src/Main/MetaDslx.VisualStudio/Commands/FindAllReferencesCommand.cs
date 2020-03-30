using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Commands
{
    internal class FindAllReferencesCommand : MetaDslxVsCommand
    {
        public FindAllReferencesCommand(ITextView textView, IServiceProvider serviceProvider) 
            : base(textView, serviceProvider)
        {
        }

        public void Execute()
        {

        }
    }
}
