using MetaDslx.GraphViz;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class DrawNodeEventArgs
    {
        public DrawNodeEventArgs(NodeLayout nodeLayout, DrawingContext drawingContext)
        {
            NodeLayout = nodeLayout;
            DrawingContext = drawingContext;
        }
        public NodeLayout NodeLayout { get; }
        public DrawingContext DrawingContext { get; }
    }

    public class DrawEdgeEventArgs
    {
        public DrawEdgeEventArgs(EdgeLayout edgeLayout, DrawingContext drawingContext)
        {
            EdgeLayout = edgeLayout;
            DrawingContext = drawingContext;
        }
        public EdgeLayout EdgeLayout { get; }
        public DrawingContext DrawingContext { get; }
    }

    public delegate void DrawNodeEventHandler(object sender, DrawNodeEventArgs args);
    public delegate void DrawEdgeEventHandler(object sender, DrawEdgeEventArgs args);

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
            SetValue(NodeTemplateProperty, new ObservableCollection<DataTemplate>());
            SetValue(EdgeTemplateProperty, new ObservableCollection<EdgeTemplate>());

            InitializeComponent();

            Loaded += DiagramView_Loaded;
            PreviewMouseDown += DiagramView_PreviewMouseDown;
            MouseMove += DiagramView_MouseMove;
            MouseUp += DiagramView_MouseUp;
            LostMouseCapture += DiagramView_LostMouseCapture;
            PreviewMouseWheel += DiagramView_PreviewMouseWheel;

            _host = new DiagramVisualHost(this);
            _hostCanvas.Children.Add(_host);
        }

        public event DrawNodeEventHandler DrawNode;
        public event DrawEdgeEventHandler DrawEdge;

        public static DependencyProperty GraphLayoutProperty =
            DependencyProperty.Register("GraphLayout", typeof(GraphLayout), typeof(DiagramView), new PropertyMetadata(GraphLayoutChanged));
        public GraphLayout GraphLayout
        {
            get { return (GraphLayout)GetValue(GraphLayoutProperty); }
            set { SetValue(GraphLayoutProperty, value); }
        }

        private static void GraphLayoutChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DiagramView dv = sender as DiagramView;
            if (dv == null)
                return;
            dv.OnItemsSourceChanged(e);
        }

        protected virtual void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                BindItems((GraphLayout)e.NewValue);
            }
        }

        public static readonly DependencyProperty NodeTemplateProperty =
            DependencyProperty.Register("NodeTemplate", typeof(ObservableCollection<DataTemplate>), typeof(DiagramView), new UIPropertyMetadata(null));
        public ObservableCollection<DataTemplate> NodeTemplate
        {
            get { return (ObservableCollection<DataTemplate>)GetValue(NodeTemplateProperty); }
        }

        public static readonly DependencyProperty EdgeTemplateProperty =
            DependencyProperty.Register("EdgeTemplate", typeof(ObservableCollection<EdgeTemplate>), typeof(DiagramView), new UIPropertyMetadata(null));
        public ObservableCollection<EdgeTemplate> EdgeTemplate
        {
            get { return (ObservableCollection<EdgeTemplate>)GetValue(EdgeTemplateProperty); }
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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (GraphLayout != null) BindItems(GraphLayout);
        }

        private void BindItems(GraphLayout graphLayout)
        {
            _host.BindGraphLayout(graphLayout);
        }

        internal bool OnDrawNode(NodeLayout nodeLayout, DrawingContext drawingContext)
        {
            if (DrawNode != null)
            {
                DrawNode(this, new DrawNodeEventArgs(nodeLayout, drawingContext));
                return true;
            }
            return false;
        }

        internal bool OnDrawEdge(EdgeLayout edgeLayout, DrawingContext drawingContext)
        {
            if (DrawEdge != null)
            {
                DrawEdge(this, new DrawEdgeEventArgs(edgeLayout, drawingContext));
                return true;
            }
            return false;
        }
    }
}
