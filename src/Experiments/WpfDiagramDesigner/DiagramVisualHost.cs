using MetaDslx.GraphViz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfDiagramDesigner
{
    public class DiagramVisualHost : FrameworkElement
    {
        private DrawingVisual _visuals;
        private GraphLayout _layout;
        private DrawingVisual _mouseOverVisual;

        private const double paddingX = 1;
        private const double paddingY = 1;

        private double _zoom = 1;

        public DiagramVisualHost()
        {
            var g = new GraphLayout("dot");
            var n1 = g.AddNode("n1");
            var n2 = g.AddNode("n2");
            var n3 = g.AddSubGraph("n3");
            var n4 = n3.AddNode("n4");
            n1.PreferredSize = new Point2D(0.5, 0.5);
            n2.PreferredSize = new Point2D(0.5, 0.5);
            n4.PreferredSize = new Point2D(0.5, 0.5);
            var e1 = g.AddEdge(n1.NodeObject, n2.NodeObject, "e1");
            var e2 = g.AddEdge(n1.NodeObject, n4.NodeObject, "e2");
            var e3 = g.AddEdge(n2.NodeObject, n4.NodeObject, "e3");
            g.ComputeLayout();
            _layout = g;

            _visuals = new DrawingVisual();
            CreateDrawingVisuals();
            AddVisualChild(_visuals);

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
            if (visual != _mouseOverVisual)
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
                var parent = (Control)VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(this));
                var parentEvent = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton, e.StylusDevice);
                parentEvent.Source = sender;
                parentEvent.RoutedEvent = Control.PreviewMouseDownEvent;
                parent.RaiseEvent(parentEvent);
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
        private void CreateDrawingVisuals()
        {
            /*var visual = new DrawingVisual();
            DrawingContext drawingContext = visual.RenderOpen();
            Rect rect = new Rect(GraphSize);
            drawingContext.DrawRectangle(Brushes.LightGray, null, rect);
            drawingContext.Close();
            _visuals.Children.Add(visual);*/

            brushCounter = 0;
            foreach (var node in _layout.Nodes)
            {
                this.DrawNode(node);
            }
            foreach (var edge in _layout.AllEdges)
            {
                this.DrawEdge(edge);
            }
        }

        private readonly Brush[] brushes = new Brush[] { Brushes.LightBlue, Brushes.LightCoral, Brushes.LightCyan, Brushes.LightGreen, Brushes.LightPink, Brushes.LightYellow };
        private int brushCounter = 0;

        private void DrawNode(NodeLayout node)
        {
            var myPen = new Pen
            {
                Thickness = 0.05,
                Brush = Brushes.Black
            };
            myPen.Freeze();

            var visual = new DrawingVisual();
            DrawingContext drawingContext = visual.RenderOpen();

            // Create a rectangle and draw it in the DrawingContext.
            Rect rect = new Rect(new Point(node.Position.X - node.Size.X / 2, node.Position.Y - node.Size.Y / 2), new Size(node.Size.X, node.Size.Y));
            drawingContext.DrawRectangle(brushes[brushCounter], node.IsSubGraph ? myPen : null, rect);
            ++brushCounter;
            if (brushCounter >= brushes.Length) brushCounter = 0;

            drawingContext.Close();
            visual.SetValue(FrameworkElement.TagProperty, node);
            _visuals.Children.Add(visual);

            if (node.IsSubGraph)
            {
                foreach (var childNode in node.Nodes)
                {
                    this.DrawNode(childNode);
                }
            }
        }

        private void DrawEdge(EdgeLayout edge)
        {
            var myPen = new Pen
            {
                Thickness = 0.05,
                Brush = Brushes.Black
            };
            myPen.Freeze();

            var visual = new DrawingVisual();
            DrawingContext drawingContext = visual.RenderOpen();

            var path = new PathGeometry();
            
            //var pathFigure = new PathFigure();
            //pathFigure.IsClosed = false;
            //pathFigure.StartPoint = new Point(edge.Source.Position.X, edge.Source.Position.Y);
            /*var ls = new LineSegment();
            ls.Point = new Point(edge.Splines[0][0].X, edge.Splines[0][0].Y);
            pathFigure.Segments.Add(ls);
            path.Figures.Add(pathFigure);*/

            foreach (var spline in edge.Splines)
            {
                var pathFigure = new PathFigure();
                pathFigure.IsClosed = false;
                pathFigure.StartPoint = new Point(spline[0].X, spline[0].Y);
                for (int i = 1; i < spline.Length; i += 3)
                {
                    var segment = new BezierSegment(new Point(spline[i].X, spline[i].Y), new Point(spline[i+1].X, spline[i + 1].Y), new Point(spline[i + 2].X, spline[i + 2].Y), true);
                    pathFigure.Segments.Add(segment);
                }
                path.Figures.Add(pathFigure);
            }

            //pathFigure = new PathFigure();
            //pathFigure.IsClosed = false;
            //pathFigure.StartPoint = new Point(edge.Splines[edge.Splines.Length - 1][edge.Splines[edge.Splines.Length - 1].Length - 1].X, edge.Splines[edge.Splines.Length - 1][edge.Splines[edge.Splines.Length - 1].Length - 1].Y);
            /*ls = new LineSegment();
            ls.Point = new Point(edge.Target.Position.X, edge.Target.Position.Y); 
            pathFigure.Segments.Add(ls);
            path.Figures.Add(pathFigure);*/

            drawingContext.DrawGeometry(null, myPen, path);

            drawingContext.Close();
            visual.SetValue(FrameworkElement.TagProperty, edge);
            _visuals.Children.Add(visual);
        }

        // Provide a required override for the VisualChildCount property.
        protected override int VisualChildrenCount
        {
            get { return 1; }
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
            Rect bounds = new Rect(_layout.Position.X - _layout.Size.X / 2, _layout.Position.Y - _layout.Size.Y / 2, _layout.Size.X, _layout.Size.Y);
            if (_layout.Size.X == 0 || _layout.Size.Y == 0) return new Size(8, 8); // if the graph is empty

            Matrix m = new Matrix();
            m.Translate(-bounds.Left + paddingX, -bounds.Top + paddingY);
            m.Scale(_zoom, _zoom);
            _visuals.Transform = new MatrixTransform(m);

            return new Size(GraphSize.Width * _zoom, GraphSize.Height * _zoom);
        }

    }
}
