using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDiagramDesigner
{
    /// <summary>
    /// Interaction logic for DiagramView.xaml
    /// </summary>
    public partial class DiagramView : UserControl
    {
        private DiagramVisualHost _host;

        private bool _waitForDrag;
        private bool _dragging;
        private Point _dragStart;
        private Point _scrollOrigin;

        public DiagramView()
        {
            InitializeComponent();

            Loaded += DiagramView_Loaded;
            PreviewMouseDown += DiagramView_PreviewMouseDown;
            MouseMove += DiagramView_MouseMove;
            MouseUp += DiagramView_MouseUp;
            LostMouseCapture += DiagramView_LostMouseCapture;
            PreviewMouseWheel += DiagramView_PreviewMouseWheel;

            _host = new DiagramVisualHost();
            _scrollViewer.Content = _host;
            _scrollViewer.Background = Brushes.LightYellow;
        }

        private void DiagramView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _host.ZoomTo(RenderSize);
            UpdateLayout();
            _scrollViewer.ScrollToHorizontalOffset((_host.RenderSize.Width - _scrollViewer.ViewportWidth) / 2);
            _scrollViewer.ScrollToVerticalOffset((_host.RenderSize.Height - _scrollViewer.ViewportHeight) / 2);
        }

        private void DiagramView_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Middle)
            {
                e.Handled = true;
                Point pt = e.GetPosition(_scrollViewer);
                if (pt.X < _scrollViewer.ViewportWidth && pt.Y < _scrollViewer.ViewportHeight)
                {
                    _waitForDrag = true;
                    _dragStart = e.GetPosition(this);
                    _scrollOrigin = new Point(_scrollViewer.HorizontalOffset, _scrollViewer.VerticalOffset);
                }
            }
        }

        private void DiagramView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;

            // Scales and scrolls so, that the visual center keeps in the center
            double zoom = _host.Zoom;
            double centerX = _scrollViewer.ViewportWidth / 2;
            double centerY = _scrollViewer.ViewportHeight / 2;
            double offsetX = (_scrollViewer.HorizontalOffset + centerX) / _host.Zoom;
            double offsetY = (_scrollViewer.VerticalOffset + centerY) / _host.Zoom;

            // zoom the content of the graph element
            zoom = zoom * (1 + e.Delta / 1200.0);
            _host.Zoom = zoom;

            // Wait until the ScrollViewer has updated its layout because of the Graph's size changings
            UpdateLayout();

            _scrollViewer.ScrollToHorizontalOffset(offsetX * zoom - centerX);
            _scrollViewer.ScrollToVerticalOffset(offsetY * zoom - centerY);
        }

        private void DiagramView_MouseMove(object sender, MouseEventArgs e)
        {
            var pt = e.GetPosition(this);
            if (_waitForDrag && (pt - _dragStart).Length > 10)
            {
                _waitForDrag = false;
                _dragging = CaptureMouse();
            }
            if (_dragging)
            {
                e.Handled = true;
                Point offset = _scrollOrigin - (pt - _dragStart);
                _scrollViewer.ScrollToHorizontalOffset(offset.X);
                _scrollViewer.ScrollToVerticalOffset(offset.Y);
            }
        }

        private void DiagramView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle)
            {
                _waitForDrag = false;
                if (_dragging)
                {
                    e.Handled = true;
                    _dragging = false;
                    ReleaseMouseCapture();
                }
            }
        }

        private void DiagramView_LostMouseCapture(object sender, MouseEventArgs e)
        {
            _dragging = false;
            base.OnLostMouseCapture(e);
        }

    }
}
