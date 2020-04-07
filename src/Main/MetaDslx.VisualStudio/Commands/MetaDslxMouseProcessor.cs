using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MetaDslx.VisualStudio.Commands
{
    public class MetaDslxMouseProcessor : IMouseProcessor
    {
        private IWpfTextView _wpfTextView;
        private BackgroundCompilation _backgroundCompilation;

        private int _mousePositionInText;

        public MetaDslxMouseProcessor(IWpfTextView wpfTextView, MetaDslxMefServices mefServices)
        {
            _wpfTextView = wpfTextView;
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, wpfTextView);
        }

        public static MetaDslxMouseProcessor GetOrCreate(MetaDslxMefServices mefServices, IWpfTextView wpfTextView)
        {
            return wpfTextView.Properties.GetOrCreateSingletonProperty(() => new MetaDslxMouseProcessor(
                wpfTextView,
                mefServices
            ));
        }

        public int MousePositionInText => _mousePositionInText;

        public void PreprocessDragEnter(DragEventArgs e)
        {
        }

        public void PreprocessDragLeave(DragEventArgs e)
        {
        }

        public void PreprocessDragOver(DragEventArgs e)
        {
        }

        public void PreprocessDrop(DragEventArgs e)
        {
        }

        public void PreprocessGiveFeedback(GiveFeedbackEventArgs e)
        {
        }

        public void PreprocessMouseDown(MouseButtonEventArgs e)
        {
        }

        public void PreprocessMouseEnter(MouseEventArgs e)
        {
        }

        public void PreprocessMouseLeave(MouseEventArgs e)
        {
        }

        public void PreprocessMouseLeftButtonDown(MouseButtonEventArgs e)
        {
        }

        public void PreprocessMouseLeftButtonUp(MouseButtonEventArgs e)
        {
        }

        public void PreprocessMouseMove(MouseEventArgs e)
        {
        }

        public void PreprocessMouseRightButtonDown(MouseButtonEventArgs e)
        {
        }

        public void PreprocessMouseRightButtonUp(MouseButtonEventArgs e)
        {
        }

        public void PreprocessMouseUp(MouseButtonEventArgs e)
        {
        }

        public void PreprocessMouseWheel(MouseWheelEventArgs e)
        {
        }

        public void PreprocessQueryContinueDrag(QueryContinueDragEventArgs e)
        {
        }

        public void PostprocessDragEnter(DragEventArgs e)
        {
        }

        public void PostprocessDragLeave(DragEventArgs e)
        {
        }

        public void PostprocessDragOver(DragEventArgs e)
        {
        }

        public void PostprocessDrop(DragEventArgs e)
        {
        }

        public void PostprocessGiveFeedback(GiveFeedbackEventArgs e)
        {
        }

        public void PostprocessMouseDown(MouseButtonEventArgs e)
        {
        }

        public void PostprocessMouseEnter(MouseEventArgs e)
        {
        }

        public void PostprocessMouseLeave(MouseEventArgs e)
        {
        }

        public void PostprocessMouseLeftButtonDown(MouseButtonEventArgs e)
        {
        }

        public void PostprocessMouseLeftButtonUp(MouseButtonEventArgs e)
        {
        }

        public void PostprocessMouseMove(MouseEventArgs e)
        {
            var mousePosition = e.GetPosition(_wpfTextView as UIElement);
            var line = _wpfTextView.TextViewLines.GetTextViewLineContainingYCoordinate(mousePosition.Y);
            if (line != null)
            {
                var element = line.GetBufferPositionFromXCoordinate(mousePosition.X);
                if (element != null)
                {
                    _mousePositionInText = element.Value.Position;
                }
            }
        }

        public void PostprocessMouseRightButtonDown(MouseButtonEventArgs e)
        {
        }

        public void PostprocessMouseRightButtonUp(MouseButtonEventArgs e)
        {
        }

        public void PostprocessMouseUp(MouseButtonEventArgs e)
        {
        }

        public void PostprocessMouseWheel(MouseWheelEventArgs e)
        {
        }

        public void PostprocessQueryContinueDrag(QueryContinueDragEventArgs e)
        {
        }

    }
}
