using MetaDslx.GraphViz;
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
        public MainWindow()
        {
            InitializeComponent();

            var g = new GraphLayout("dot");
            var n1 = g.AddNode("n1");
            var n2 = g.AddNode("n2");
            var n3 = g.AddSubGraph(10);
            var n4 = n3.AddNode("n4");
            n1.PreferredSize = new Point2D(50, 50);
            n2.PreferredSize = new Point2D(50, 50);
            n4.PreferredSize = new Point2D(50, 50);
            var e1 = g.AddEdge(n1.NodeObject, n2.NodeObject, "e1");
            var e2 = g.AddEdge(n1.NodeObject, n4.NodeObject, "e2");
            var e3 = g.AddEdge(n2.NodeObject, n4.NodeObject, 5);
            g.NodeSeparation = 10;
            g.RankSeparation = 50;
            g.EdgeLength = 30;
            g.NodeMargin = 20;
            g.ComputeLayout();
            DiagramView.GraphLayout = g;
        }

        private void DiagramView_DrawNode(object sender, DrawNodeEventArgs args)
        {
            var dc = args.DrawingContext;
            var node = args.NodeLayout;
            var myPen = new Pen
            {
                Thickness = 0.05,
                Brush = Brushes.Black
            };
            myPen.Freeze();
            // Create a rectangle and draw it in the DrawingContext.
            Rect rect = new Rect(new Point(node.Position.X - node.Size.X / 2, node.Position.Y - node.Size.Y / 2), new Size(node.Size.X, node.Size.Y));
            dc.DrawRectangle(Brushes.LightGray, node.IsSubGraph ? myPen : null, rect);
        }
    }
}
