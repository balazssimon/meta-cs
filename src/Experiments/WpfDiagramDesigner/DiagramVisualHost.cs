using MetaDslx.GraphViz;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfDiagramDesigner
{
    public class DiagramVisualHost : FrameworkElement
    {
        private DrawingVisual _visual = new DrawingVisual();
        private GraphLayout _layout;
        private double _zoom = 1;

        public DiagramVisualHost()
        {
            var g = new GraphLayout("dot");
            var n1 = g.AddNode("n1");
            var n2 = g.AddNode("n2");
            var n3 = g.AddSubGraph("n3");
            var n4 = n3.AddNode("n4");
            n1.PreferredSize = new Point2D(5, 5);
            n2.PreferredSize = new Point2D(5, 5);
            n4.PreferredSize = new Point2D(5, 5);
            var e1 = g.AddEdge(n1.NodeObject, n2.NodeObject, "e1");
            var e2 = g.AddEdge(n1.NodeObject, n4.NodeObject, "e2");
            var e3 = g.AddEdge(n2.NodeObject, n4.NodeObject, "e3");
            g.ComputeLayout();
            _layout = g;

            _visual = CreateDrawingVisual();

            // Add the event handler for MouseLeftButtonUp.
            MouseLeftButtonUp += MyVisualHost_MouseLeftButtonUp;

            ClipToBounds = true;

            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
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

        // Capture the mouse event and hit test the coordinate point value against
        // the child visual objects.
        private void MyVisualHost_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Retreive the coordinates of the mouse button event.
            Point pt = e.GetPosition((UIElement)sender);

            // Initiate the hit test by setting up a hit test result callback method.
            VisualTreeHelper.HitTest(this, null, MyCallback, new PointHitTestParameters(pt));
        }

        // If a child visual object is hit, toggle its opacity to visually indicate a hit.
        public HitTestResultBehavior MyCallback(HitTestResult result)
        {
            if (result.VisualHit.GetType() == typeof(System.Windows.Media.DrawingVisual))
            {
                ((System.Windows.Media.DrawingVisual)result.VisualHit).Opacity =
                    ((System.Windows.Media.DrawingVisual)result.VisualHit).Opacity == 1.0 ? 0.4 : 1.0;
            }

            // Stop the hit test enumeration of objects in the visual tree.
            return HitTestResultBehavior.Stop;
        }

        // Create a DrawingVisual that contains the graph.
        private System.Windows.Media.DrawingVisual CreateDrawingVisual()
        {
            System.Windows.Media.DrawingVisual drawingVisual = new System.Windows.Media.DrawingVisual();
            if (_layout == null) return drawingVisual;

            // Retrieve the DrawingContext in order to create new drawing content.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            foreach (var edge in _layout.AllEdges)
            {
                this.DrawEdge(drawingContext, edge);
            }
            foreach (var node in _layout.Nodes)
            {
                this.DrawNode(drawingContext, node);
            }

            // Persist the drawing content.
            drawingContext.Close();

            return drawingVisual;
        }

        private void DrawNode(DrawingContext drawingContext, NodeLayout node)
        {
            if (node.IsSubGraph)
            {
                foreach (var childNode in node.Nodes)
                {
                    this.DrawNode(drawingContext, childNode);
                }
            }
            else
            {
                // Create a rectangle and draw it in the DrawingContext.
                Rect rect = new Rect(new Point(node.Position.X - node.Size.X / 2, node.Position.Y - node.Size.Y / 2), new Size(node.Size.X, node.Size.Y));
                drawingContext.DrawRectangle(Brushes.LightBlue, null, rect);
            }
        }

        private void DrawEdge(DrawingContext drawingContext, EdgeLayout edge)
        {
            var myPen = new Pen
            {
                Thickness = 1,
                Brush = Brushes.Black
            };
            myPen.Freeze();

            var path = new PathGeometry();
            
            var pathFigure = new PathFigure();
            pathFigure.IsClosed = false;
            pathFigure.StartPoint = new Point(edge.Source.Position.X, edge.Source.Position.Y);
            var ls = new LineSegment();
            ls.Point = new Point(edge.Splines[0][0].X, edge.Splines[0][0].Y);
            pathFigure.Segments.Add(ls);
            path.Figures.Add(pathFigure);

            foreach (var spline in edge.Splines)
            {
                //pathFigure = new PathFigure();
                //pathFigure.IsClosed = false;
                //pathFigure.StartPoint = new Point(spline[0].X, spline[0].Y);
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
            ls = new LineSegment();
            ls.Point = new Point(edge.Target.Position.X, edge.Target.Position.Y); 
            pathFigure.Segments.Add(ls);
            path.Figures.Add(pathFigure);

            drawingContext.DrawGeometry(null, myPen, path);
        }

        // Provide a required override for the VisualChildCount property.
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            return _visual;
        }

        internal void ZoomTo(Size size)
        {
            Size gs = GraphSize;
            double scaleY = size.Height / gs.Height;
            double scaleX = size.Width / gs.Width;
            Zoom = Math.Min(1, Math.Min(scaleX, scaleY));
        }

        private Size GraphSize
        {
            get
            {
                Rect bounds = new Rect(_layout.Position.X - _layout.Size.X / 2, _layout.Position.Y - _layout.Size.Y / 2, _layout.Size.X, _layout.Size.Y);
                return new Size((bounds.Width + 2 * paddingX) * 64, (bounds.Height + 2 * paddingY) * 64);
            }
        }

        const double paddingX = 1; // availableSize.Width / _zoom / 64;
        const double paddingY = 1; // availableSize.Height / _zoom / 64;

        protected override Size MeasureOverride(Size availableSize)
        {
            Rect bounds = new Rect(_layout.Position.X - _layout.Size.X / 2, _layout.Position.Y - _layout.Size.Y / 2, _layout.Size.X, _layout.Size.Y);
            if (bounds.IsEmpty) return new Size(8, 8); // if the graph is empty

            Matrix m = new Matrix();
            m.Translate(-bounds.Left + paddingX, -bounds.Top + paddingY);
            m.Scale(_zoom * 64, _zoom * 64);
            _visual.Transform = new MatrixTransform(m);

            return new Size((bounds.Width + 2 * paddingY) * _zoom * 64, (bounds.Height + 2 * paddingY) * _zoom * 64);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            return base.ArrangeOverride(finalSize);
        }

    }
}
