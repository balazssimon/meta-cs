using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MetaDslx.VisualStudio.Commands
{
    public class CtrlKeyChangedEventArgs
    {
        public CtrlKeyChangedEventArgs(bool isDown)
        {
            this.IsDown = isDown;
        }

        public bool IsDown { get; }
    }

    public class MetaDslxKeyProcessor : KeyProcessor
    {
        private IWpfTextView _wpfTextView;
        private BackgroundCompilation _backgroundCompilation;

        private bool _ctrlDown;

        public MetaDslxKeyProcessor(IWpfTextView wpfTextView, MetaDslxMefServices mefServices)
        {
            _wpfTextView = wpfTextView;
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, wpfTextView.TextBuffer);
        }

        public static MetaDslxKeyProcessor GetOrCreate(MetaDslxMefServices mefServices, IWpfTextView wpfTextView)
        {
            return wpfTextView.Properties.GetOrCreateSingletonProperty(() => new MetaDslxKeyProcessor(
                wpfTextView,
                mefServices
            ));
        }

        public event EventHandler<CtrlKeyChangedEventArgs> CtrlKeyChanged;

        public override void KeyDown(KeyEventArgs args)
        {
            base.KeyDown(args);
            if (args.Key == Key.LeftCtrl || args.Key == Key.RightCtrl)
            {
                var oldValue = _ctrlDown;
                if (!oldValue)
                {
                    _ctrlDown = true;
                    var tempEvent = CtrlKeyChanged;
                    tempEvent?.Invoke(this, new CtrlKeyChangedEventArgs(_ctrlDown));
                }
            }
        }

        public override void KeyUp(KeyEventArgs args)
        {
            base.KeyUp(args);
            if (args.Key == Key.LeftCtrl || args.Key == Key.RightCtrl)
            {
                var oldValue = _ctrlDown;
                if (oldValue)
                {
                    _ctrlDown = false;
                    var tempEvent = CtrlKeyChanged;
                    tempEvent?.Invoke(this, new CtrlKeyChangedEventArgs(_ctrlDown));
                }
            }
        }
    }
}
