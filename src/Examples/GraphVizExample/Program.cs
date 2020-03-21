using MetaDslx.GraphViz;
using System;
using System.Runtime.InteropServices;

namespace GraphVizExample
{
    class Program
    {

        static void Main(string[] args)
        {
            
            var g = new Graph();
            var n1 = g.AddNode("n1");
            var n2 = g.AddNode("n2");
            var n3 = g.AddNode("n3");
            g.AddEdge(n1, n2, "e1");
            g.AddEdge(n1, n3, "e2");
            g.AddEdge(n2, n3, "e3");
            g.Layout("dot");
        }
    }
}
