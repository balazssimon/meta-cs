using MetaDslx.GraphViz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfDiagramDesigner
{
    public class DiagramVisualHost : FrameworkElement
    {
        private DiagramView _view;
        private DrawingVisual _visuals;
        private GraphLayout _layout;
        private DrawingVisual _mouseOverVisual;
        private FrameworkElement _mouseOverContent;
        private Dictionary<NodeLayout, FrameworkElement> _nodeContents;

        private const double paddingX = 1;
        private const double paddingY = 1;

        private double _zoom = 1;

        public DiagramVisualHost(DiagramView view)
        {
            _view = view;
            _nodeContents = new Dictionary<NodeLayout, FrameworkElement>();

            ClipToBounds = true;

            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;

            MouseMove += DiagramVisualHost_MouseMove;
            MouseLeave += DiagramVisualHost_MouseLeave;
        }

        private void DiagramVisualHost_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_mouseOverVisual != null) _mouseOverVisual.Opacity = 1.0;
            _mouseOverVisual = null;
        }

        private void DiagramVisualHost_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition((UIElement)sender);
            var visual = VisualTreeHelper.HitTest(this, pt).VisualHit as DrawingVisual;
            if (!object.ReferenceEquals(visual, _mouseOverVisual))
            {
                if (_mouseOverVisual != null) _mouseOverVisual.Opacity = 1.0;
                _mouseOverVisual = visual;
                if (_mouseOverVisual != null) _mouseOverVisual.Opacity = 0.4;
            }
        }

        private void DiagramVisualHost_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle)
            {
                e.Handled = true;
                var parentEvent = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice);
                parentEvent.Source = sender;
                parentEvent.RoutedEvent = Control.PreviewMouseDownEvent;
                _view.RaiseEvent(parentEvent);
            }
        }

        public double Zoom
        {
            set
            {
                _zoom = value;
                InvalidateMeasure();
            }

            get { return _zoom; }
        }

        // Create a DrawingVisual that contains the graph.
        internal void BindGraphLayout(GraphLayout layout)
        {
            if (_layout == layout) return;
            if (_visuals != null) RemoveVisualChild(_visuals);
            foreach (var content in _nodeContents.Values)
            {
                content.MouseMove -= NodeContent_MouseMove;
                content.MouseLeave -= NodeContent_MouseLeave;
            }
            _nodeContents.Clear();
            _layout = layout;
            if (_layout == null) return;

            _visuals = new DrawingVisual();
            if (_view.NodeTemplate.Count > 0)
            {
                foreach (var node in _layout.AllNodes)
                {
                    foreach (var nodeTemplate in _view.NodeTemplate)
                    {
                        if (nodeTemplate.DataType == null || nodeTemplate.DataType is Type type && type.IsAssignableFrom(node.NodeObject.GetType()))
                        {
                            FrameworkElement nodeContent = nodeTemplate.LoadContent() as FrameworkElement;
                            _nodeContents.Add(node, nodeContent);
                            nodeContent.DataContext = node.NodeObject;
                            if (!node.IsSubGraph)
                            {
                                nodeContent.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                                nodeContent.Arrange(new Rect(nodeContent.DesiredSize));
                            }
                            node.PreferredSize = new Point2D(nodeContent.DesiredSize.Width, nodeContent.DesiredSize.Height);
                            break;
                        }
                    }
                }
            }
            layout.ComputeLayout();
            brushCounter = 0;
            foreach (var node in _layout.Nodes)
            {
                this.DrawNode(node);
            }
            foreach (var edge in _layout.AllEdges)
            {
                this.DrawEdge(edge);
            }

            AddVisualChild(_visuals);
        }

        private readonly Brush[] brushes = new Brush[] { Brushes.LightBlue, Brushes.LightCoral, Brushes.LightCyan, Brushes.LightGreen, Brushes.LightPink, Brushes.LightYellow };
        private int brushCounter = 0;

        private void DrawNode(NodeLayout node)
        {
            if (_nodeContents.TryGetValue(node, out var nodeContent))
            {
                if (node.IsSubGraph)
                {
                    nodeContent.Arrange(new Rect(node.Left, node.Top, node.Width, node.Height));
                    nodeContent.Width = node.Width;
                    nodeContent.Height = node.Height;
                }
                nodeContent.SetValue(FrameworkElement.TagProperty, node);
                _view._hostCanvas.Children.Add(nodeContent);
                nodeContent.MouseMove += NodeContent_MouseMove;
                nodeContent.MouseLeave += NodeContent_MouseLeave;
            }
            else
            {
                var visual = new DrawingVisual();
                DrawingContext drawingContext = visual.RenderOpen();
                if (!_view.OnDrawNode(node, drawingContext))
                {
                    Rect rect = new Rect(new Point(node.Position.X - node.Size.X / 2, node.Position.Y - node.Size.Y / 2), new Size(node.Size.X, node.Size.Y));
                    drawingContext.DrawRectangle(brushes[brushCounter], node.IsSubGraph ? EdgeTemplate.DefaultPen : null, rect);
                    ++brushCounter;
                    if (brushCounter >= brushes.Length) brushCounter = 0;
                }
                drawingContext.Close();
                visual.SetValue(FrameworkElement.TagProperty, node);
                _visuals.Children.Add(visual);
            }

            if (node.IsSubGraph)
            {
                foreach (var childNode in node.Nodes)
                {
                    this.DrawNode(childNode);
                }
            }
        }

        private void NodeContent_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_mouseOverContent != null) _mouseOverContent.Opacity = 1.0;
            _mouseOverContent = null;
        }

        private void NodeContent_MouseMove(object sender, MouseEventArgs e)
        {
            var content = sender as FrameworkElement;
            if (!object.ReferenceEquals(content, _mouseOverContent))
            {
                if (_mouseOverContent != null) _mouseOverContent.Opacity = 1.0;
                _mouseOverContent = content;
                if (_mouseOverContent != null) _mouseOverContent.Opacity = 0.4;
            }
        }

        private void DrawEdge(EdgeLayout edge)
        {
            Pen pen = EdgeTemplate.DefaultPen;
            if (_view.EdgeTemplate.Count > 0)
            {
                foreach (var edgeTemplate in _view.EdgeTemplate)
                {
                    if (edgeTemplate.EdgeType == null || edgeTemplate.EdgeType is Type type && type.IsAssignableFrom(edge.EdgeObject.GetType()))
                    {
                        pen = edgeTemplate.Pen;
                        break;
                    }
                }
            }
            var visual = new DrawingVisual();
            DrawingContext drawingContext = visual.RenderOpen();
            if (!_view.OnDrawEdge(edge, drawingContext))
            {
                var path = new PathGeometry();
                foreach (var spline in edge.Splines)
                {
                    var pathFigure = new PathFigure();
                    pathFigure.IsClosed = false;
                    pathFigure.StartPoint = new Point(spline[0].X, spline[0].Y);
                    for (int i = 1; i < spline.Length; i += 3)
                    {
                        var segment = new BezierSegment(new Point(spline[i].X, spline[i].Y), new Point(spline[i + 1].X, spline[i + 1].Y), new Point(spline[i + 2].X, spline[i + 2].Y), true);
                        pathFigure.Segments.Add(segment);
                    }
                    path.Figures.Add(pathFigure);
                }
                drawingContext.DrawGeometry(null, pen, path);
            }
            drawingContext.Close();
            visual.SetValue(FrameworkElement.TagProperty, edge);
            _visuals.Children.Add(visual);
        }

        // Provide a required override for the VisualChildCount property.
        protected override int VisualChildrenCount
        {
            get { return _visuals != null ? 1 : 0; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            return _visuals;
        }

        internal void ZoomTo(Size size)
        {
            Size gs = GraphSize;
            double scaleY = size.Height / gs.Height;
            double scaleX = size.Width / gs.Width;
            Zoom = Math.Min(scaleX, scaleY);
        }

        private Size GraphSize
        {
            get
            {
                return new Size(_layout.Size.X + 2 * paddingX, _layout.Size.Y + 2 * paddingY);
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (_layout == null || _visuals == null || _layout.Size.X == 0 || _layout.Size.Y == 0) return new Size(8, 8); 
            Rect bounds = new Rect(_layout.Position.X - _layout.Size.X / 2, _layout.Position.Y - _layout.Size.Y / 2, _layout.Size.X, _layout.Size.Y);
            Matrix m = new Matrix();
            m.Translate(-bounds.Left + paddingX, -bounds.Top + paddingY);
            m.Scale(_zoom, _zoom);
            _visuals.Transform = new MatrixTransform(m);
            var size = new Size(GraphSize.Width * _zoom, GraphSize.Height * _zoom);
            _view._hostCanvas.Width = size.Width;
            _view._hostCanvas.Height = size.Height;
            foreach (var nc in _nodeContents)
            {
                var node = nc.Key;
                var nodeContent = nc.Value;
                m = new Matrix();
                m.Translate(node.Left + paddingX, node.Top + paddingY);
                m.Scale(_zoom, _zoom);
                nodeContent.RenderTransform = new MatrixTransform(m);
            }
            //_view._hostCanvas.RenderTransform = new MatrixTransform(m);
            return size;
        }

    }
}
