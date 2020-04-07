using MetaDslx.CodeAnalysis;
using MetaDslx.VisualStudio.Commands;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Editor
{
	[Export(typeof(IWpfTextViewCreationListener))]
	[ContentType(MetaDslxDefinition.ContentType)]
	[TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
	[TextViewRole(PredefinedTextViewRoles.EmbeddedPeekTextView)]
	public class MetaDslxTextViewCreationListener : IWpfTextViewCreationListener
	{
		[Import]
		private MetaDslxMefServices _mefServices = null;

		private IWpfTextView _textView;

		public void TextViewCreated(IWpfTextView textView)
		{
			_textView = textView;
			MetaDslxTextViewCommandFilter.GetOrCreate(_mefServices, textView);
			BackgroundCompilation.GetOrCreate(_mefServices, textView);
		}

		protected MetaDslxMefServices MefServices => _mefServices;

		protected IWpfTextView TextView => _textView;

	}
}
