using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDiagramDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool waitForDrag;
        private bool dragging;
        private Point dragStart;
        private Point scrollOrigin;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Graph.ZoomTo(RenderSize);
            UpdateLayout();
            ScrollViewer.ScrollToHorizontalOffset((Graph.RenderSize.Width - ScrollViewer.ViewportWidth) / 2);
            ScrollViewer.ScrollToVerticalOffset((Graph.RenderSize.Height - ScrollViewer.ViewportHeight) / 2);
        }

        private void Window_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition(ScrollViewer);
            if (pt.X < ScrollViewer.ViewportWidth && pt.Y < ScrollViewer.ViewportHeight)
            {
                waitForDrag = true;
                dragStart = pt;
                scrollOrigin = new Point(ScrollViewer.HorizontalOffset, ScrollViewer.VerticalOffset);
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (waitForDrag && (e.GetPosition(this) - dragStart).Length > 1)
            {
                waitForDrag = false;
                dragging = CaptureMouse();
            }
            if (dragging)
            {
                e.Handled = true;
                Point offset = scrollOrigin - (e.GetPosition(this) - dragStart);
                ScrollViewer.ScrollToHorizontalOffset(offset.X);
                ScrollViewer.ScrollToVerticalOffset(offset.Y);
            }
        }

        private void Window_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            waitForDrag = false;
            if (dragging)
            {
                e.Handled = true;
                dragging = false;
                ReleaseMouseCapture();
            }
        }

        private void Window_LostMouseCapture(object sender, MouseEventArgs e)
        {
            dragging = false;
            base.OnLostMouseCapture(e);
        }

        private void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;

            // Scales and scrolls so, that the visual center keeps in the center
            double zoom = Graph.Zoom;
            double centerX = ScrollViewer.ViewportWidth / 2;
            double centerY = ScrollViewer.ViewportHeight / 2;
            double offsetX = (ScrollViewer.HorizontalOffset + centerX) / Graph.Zoom;
            double offsetY = (ScrollViewer.VerticalOffset + centerY) / Graph.Zoom;

            // zoom the content of the graph element
            zoom = zoom * (1 + e.Delta / 1200.0);
            /*if (zoom < 0.07) zoom = 0.07;
            else if (zoom > 7) zoom = 7;*/
            Graph.Zoom = zoom;

            // Wait until the ScrollViewer has updated its layout because of the Graph's size changings
            UpdateLayout();

            ScrollViewer.ScrollToHorizontalOffset(offsetX * zoom - centerX);
            ScrollViewer.ScrollToVerticalOffset(offsetY * zoom - centerY);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Scales and scrolls so, that the visual center keeps in the center
            double zoom = Graph.Zoom;
            double centerX = ScrollViewer.ViewportWidth / 2;
            double centerY = ScrollViewer.ViewportHeight / 2;
            double offsetX = (ScrollViewer.HorizontalOffset + centerX) / Graph.Zoom;
            double offsetY = (ScrollViewer.VerticalOffset + centerY) / Graph.Zoom;

            // Wait until the ScrollViewer has updated its layout because of the Graph's size changings
            UpdateLayout();

            ScrollViewer.ScrollToHorizontalOffset(offsetX * zoom - centerX);
            ScrollViewer.ScrollToVerticalOffset(offsetY * zoom - centerY);
        }
    }
}
