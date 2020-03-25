using MetaDslx.GraphViz;
using System;
using System.Runtime.InteropServices;

namespace GraphVizExample
{
    class Program
    {

        static void Main(string[] args)
        {
            var g = new GraphLayout("dot");
            var n1 = g.AddNode("n1");
            var n2 = g.AddNode("n2");
            var n3 = g.AddSubGraph("n3");
            var n4 = n3.AddNode("n4");
            n1.PreferredSize = new Point2D(50, 50);
            n2.PreferredSize = new Point2D(50, 50);
            n4.PreferredSize = new Point2D(50, 50);
            var e1 = g.AddEdge(n1.NodeObject, n2.NodeObject, "e1");
            var e2 = g.AddEdge(n1.NodeObject, n4.NodeObject, "e2");
            var e3 = g.AddEdge(n2.NodeObject, n4.NodeObject, "e3");
            g.NodeSeparation = 10;
            g.RankSeparation = 50;
            g.EdgeLength = 30;
            g.ComputeLayout();
            Console.WriteLine(g.Position+" "+g.Size);
            Console.WriteLine(n1.NodeObject + " " + n1.Position + " " + n1.Size);
            Console.WriteLine(n2.NodeObject + " " + n2.Position + " " + n2.Size);
            Console.WriteLine(n3.NodeObject + " " + n3.Position + " " + n3.Size);
            Console.WriteLine(n4.NodeObject + " " + n4.Position + " " + n4.Size);
            Console.WriteLine(e1.EdgeObject + " " + e1.Splines.Length);
            Console.WriteLine(e2.EdgeObject + " " + e2.Splines.Length);
            Console.WriteLine(e3.EdgeObject + " " + e3.Splines.Length);
            Console.WriteLine("----");
            Console.WriteLine(g.ToDot());
        }
    }
}
