using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = System.IServiceProvider;

namespace MetaDslx.VisualStudio.Commands
{
    internal class MetaDslxTextViewCommandFilter : IOleCommandTarget
    {
        private readonly MetaDslxMefServices _mefServices;
        private readonly IVsTextView _vsTextView;
        private readonly IWpfTextView _textView;
        private readonly IEditorOperations _editorOps;
        private readonly IOleCommandTarget _nextCommandHandler;

        private readonly GoToDefinitionCommand _goToDefinitionCommand;
        private readonly FindAllReferencesCommand _findAllReferencesCommand;

        private MetaDslxTextViewCommandFilter(IVsTextView vsTextView, IWpfTextView textView, IEditorOperations editorOps, MetaDslxMefServices mefServices)
        {
            _mefServices = mefServices;
            _vsTextView = vsTextView;
            _textView = textView;
            _editorOps = editorOps;

            _goToDefinitionCommand = new GoToDefinitionCommand(_textView, _vsTextView, mefServices);
            _findAllReferencesCommand = new FindAllReferencesCommand(_textView, _vsTextView, mefServices);

            ErrorHandler.ThrowOnFailure(vsTextView.AddCommandFilter(this, out _nextCommandHandler));
        }

        public GoToDefinitionCommand GoToDefinitionCommand => _goToDefinitionCommand;
        public FindAllReferencesCommand FindAllReferencesCommand => _findAllReferencesCommand;

        public static MetaDslxTextViewCommandFilter GetOrCreate(MetaDslxMefServices mefServices, IWpfTextView textView)
        {
            var editorFactory = mefServices.ComponentModel.GetService<IVsEditorAdaptersFactoryService>();
            var opsFactory = mefServices.ComponentModel.GetService<IEditorOperationsFactoryService>();
            var vsTextView = editorFactory.GetViewAdapter(textView);
            return textView.Properties.GetOrCreateSingletonProperty(() => new MetaDslxTextViewCommandFilter(
                vsTextView,
                textView,
                opsFactory.GetEditorOperations(textView),
                mefServices
            ));
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            if (pguidCmdGroup == VSConstants.GUID_VSStandardCommandSet97)
            {
                for (int i = 0; i < cCmds; i++)
                {
                    switch ((VSConstants.VSStd97CmdID)prgCmds[i].cmdID)
                    {
                        case VSConstants.VSStd97CmdID.GotoDefn:
                            prgCmds[i].cmdf = (uint)(OLECMDF.OLECMDF_ENABLED | OLECMDF.OLECMDF_SUPPORTED);
                            return VSConstants.S_OK;
                        case VSConstants.VSStd97CmdID.FindReferences:
                            prgCmds[i].cmdf = (uint)(OLECMDF.OLECMDF_ENABLED | OLECMDF.OLECMDF_SUPPORTED);
                            return VSConstants.S_OK;
                    }
                }
            }
            return _nextCommandHandler.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            try
            {
                return DoExec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
            }
            catch (Exception ex)
            {
                //ex.ReportUnhandledException(_serviceProvider, GetType());
                return VSConstants.E_FAIL;
            }
        }

        private int DoExec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            if (pguidCmdGroup == VSConstants.GUID_VSStandardCommandSet97)
            {
                switch ((VSConstants.VSStd97CmdID)nCmdID)
                {
                    case VSConstants.VSStd97CmdID.GotoDefn: _goToDefinitionCommand.Execute(); return VSConstants.S_OK;
                    case VSConstants.VSStd97CmdID.FindReferences: _findAllReferencesCommand.Execute(); return VSConstants.S_OK;
                }
            }
            return _nextCommandHandler.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }
    }
}
