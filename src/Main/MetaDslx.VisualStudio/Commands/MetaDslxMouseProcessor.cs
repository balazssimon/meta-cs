using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
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
    public class MousePositionChangedEventArgs
    {
        public MousePositionChangedEventArgs(int oldPosition, int newPosition)
        {
            this.OldPosition = oldPosition;
            this.NewPosition = newPosition;
        }

        public int OldPosition { get; }
        public int NewPosition { get; }
    }

    public class MetaDslxMouseProcessor : IMouseProcessor
    {
        private IWpfTextView _wpfTextView;

        private int _mousePositionInText;
        private SyntaxToken? _goToDefinitionTokenMouseDown;

        public MetaDslxMouseProcessor(IWpfTextView wpfTextView, MetaDslxMefServices mefServices)
        {
            _wpfTextView = wpfTextView;
        }

        public static MetaDslxMouseProcessor GetOrCreate(MetaDslxMefServices mefServices, IWpfTextView wpfTextView)
        {
            return wpfTextView.Properties.GetOrCreateSingletonProperty(() => new MetaDslxMouseProcessor(
                wpfTextView,
                mefServices
            ));
        }

        public int MousePositionInText => _mousePositionInText;

        public event EventHandler<MousePositionChangedEventArgs> MousePositionInTextChanged;

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
            if (_wpfTextView.Properties.TryGetProperty<SymbolTagger>(typeof(SymbolTagger), out var compilationSymbolTagger))
            {
                _goToDefinitionTokenMouseDown = compilationSymbolTagger.GoToDefinitionToken;
            }
            else
            {
                _goToDefinitionTokenMouseDown = null;
            }
        }

        public void PreprocessMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (_wpfTextView.Properties.TryGetProperty<SymbolTagger>(typeof(SymbolTagger), out var symbolTagger) &&
                _wpfTextView.Properties.TryGetProperty<MetaDslxTextViewCommandFilter>(typeof(MetaDslxTextViewCommandFilter), out var commandFilter))
            {
                var goToDefinitionToken = symbolTagger.GoToDefinitionToken;
                var goToDefinitionCommand = commandFilter.GoToDefinitionCommand;
                if (goToDefinitionToken != null && goToDefinitionToken == _goToDefinitionTokenMouseDown && goToDefinitionCommand != null)
                {
                    _goToDefinitionTokenMouseDown = null;
                    e.Handled = true;
                    goToDefinitionCommand.GoToDefinition(goToDefinitionToken.Value);
                }
            }
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
            var mousePosition = RelativeToView(e.GetPosition(_wpfTextView.VisualElement));
            var oldPosition = _mousePositionInText;
            var newPosition = -1;
            var line = _wpfTextView.TextViewLines.GetTextViewLineContainingYCoordinate(mousePosition.Y);
            if (line != null)
            {
                var element = line.GetBufferPositionFromXCoordinate(mousePosition.X);
                if (element != null) newPosition = element.Value.Position;
            }
            if (newPosition != oldPosition)
            {
                _mousePositionInText = newPosition;
                var tempEvent = this.MousePositionInTextChanged;
                tempEvent?.Invoke(this, new MousePositionChangedEventArgs(oldPosition, newPosition));
            }
        }

        private Point RelativeToView(Point position)
        {
            return new Point(position.X + _wpfTextView.ViewportLeft, position.Y + _wpfTextView.ViewportTop);
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
