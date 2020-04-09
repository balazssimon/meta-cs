using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MetaDslx.VisualStudio.Commands
{
    public class MetaDslxCompletionCommandHandler : MetaDslxVsCommand, IOleCommandTarget
    {
        private IOleCommandTarget _nextCommandHandler;
        private ICompletionSession _session;
        private ICompletionBroker _completionBroker;

        public MetaDslxCompletionCommandHandler(IWpfTextView textView, IVsTextView vsTextView, MetaDslxMefServices mefServices) 
            : base(textView, vsTextView, mefServices)
        {
            _completionBroker = mefServices.GetService<ICompletionBroker>();

            ErrorHandler.ThrowOnFailure(vsTextView.AddCommandFilter(this, out _nextCommandHandler));
        }

        public static MetaDslxCompletionCommandHandler GetOrCreate(MetaDslxMefServices mefServices, IWpfTextView textView)
        {
            var editorFactory = mefServices.ComponentModel.GetService<IVsEditorAdaptersFactoryService>();
            var opsFactory = mefServices.ComponentModel.GetService<IEditorOperationsFactoryService>();
            var vsTextView = editorFactory.GetViewAdapter(textView);
            return textView.Properties.GetOrCreateSingletonProperty(() => new MetaDslxCompletionCommandHandler(
                textView,
                vsTextView,
                mefServices
            ));
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            if (pguidCmdGroup == VSConstants.VSStd2K)
            {
                switch ((VSConstants.VSStd2KCmdID)prgCmds[0].cmdID)
                {
                    case VSConstants.VSStd2KCmdID.AUTOCOMPLETE:
                    case VSConstants.VSStd2KCmdID.COMPLETEWORD:
                        prgCmds[0].cmdf = (uint)OLECMDF.OLECMDF_ENABLED | (uint)OLECMDF.OLECMDF_SUPPORTED;
                        return VSConstants.S_OK;
                }
            }
            return _nextCommandHandler.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        private char GetTypeChar(IntPtr pvaIn)
        {
            return (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
        }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            bool handled = false;
            int hresult = VSConstants.S_OK;

            // 1. Pre-process
            if (pguidCmdGroup == VSConstants.VSStd2K)
            {
                switch ((VSConstants.VSStd2KCmdID)nCmdID)
                {
                    case VSConstants.VSStd2KCmdID.AUTOCOMPLETE:
                    case VSConstants.VSStd2KCmdID.COMPLETEWORD:
                        handled = StartSession();
                        break;
                    case VSConstants.VSStd2KCmdID.RETURN:
                        handled = Complete(false);
                        break;
                    case VSConstants.VSStd2KCmdID.TAB:
                        handled = Complete(true);
                        break;
                    case VSConstants.VSStd2KCmdID.CANCEL:
                        handled = Cancel();
                        break;
                    case VSConstants.VSStd2KCmdID.TYPECHAR:
                        char ch = GetTypeChar(pvaIn);
                        if (!ch.Equals(char.MinValue) && !char.IsLetterOrDigit(ch) && _session != null)
                        {
                            Complete(false);
                        }
                        break;
                }
            }

            if (!handled)
                hresult = _nextCommandHandler.Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);

            if (ErrorHandler.Succeeded(hresult))
            {
                if (pguidCmdGroup == VSConstants.VSStd2K)
                {
                    switch ((VSConstants.VSStd2KCmdID)nCmdID)
                    {
                        case VSConstants.VSStd2KCmdID.TYPECHAR:
                            char ch = GetTypeChar(pvaIn);
                            if (!ch.Equals(char.MinValue) && char.IsLetterOrDigit(ch))
                            {
                                if (_session == null) StartSession();
                                Filter();
                            }
                            else
                            {
                                if (_session != null) Complete(false);
                                StartSession();
                            }
                            break;
                        case VSConstants.VSStd2KCmdID.BACKSPACE:
                            Filter();
                            break;
                    }
                }
            }

            return hresult;
        }

        /// <summary>
        /// Narrow down the list of options as the user types input
        /// </summary>
        private void Filter()
        {
            if (_session == null)
                return;

            _session.SelectedCompletionSet.SelectBestMatch();
            _session.SelectedCompletionSet.Recalculate();
        }

        /// <summary>
        /// Cancel the auto-complete session, and leave the text unmodified
        /// </summary>
        private bool Cancel()
        {
            if (_session == null)
                return false;

            _session.Dismiss();

            return true;
        }

        /// <summary>
        /// Auto-complete text using the specified token
        /// </summary>
        private bool Complete(bool force)
        {
            if (_session == null)
                return false;

            if (!_session.SelectedCompletionSet.SelectionStatus.IsSelected && !force)
            {
                _session.Dismiss();
                return false;
            }
            else
            {
                _session.Commit();
                return true;
            }
        }

        /// <summary>
        /// Display list of potential tokens
        /// </summary>
        private bool StartSession()
        {
            if (_session != null)
                return false;

            SnapshotPoint caret = TextView.Caret.Position.BufferPosition;
            ITextSnapshot snapshot = caret.Snapshot;

            if (!_completionBroker.IsCompletionActive(TextView))
            {
                _session = _completionBroker.CreateCompletionSession(TextView, snapshot.CreateTrackingPoint(caret, PointTrackingMode.Positive), true);
            }
            else
            {
                _session = _completionBroker.GetSessions(TextView)[0];
            }
            _session.Dismissed += SessionDismissed;

            _session.Start();

            return true;
        }

        private void SessionDismissed(object sender, EventArgs e)
        {
            _session.Dismissed -= SessionDismissed;
            _session = null;
        }
    }
}
