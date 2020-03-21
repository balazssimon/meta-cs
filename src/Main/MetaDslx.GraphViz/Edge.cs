using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.GraphViz
{
    public class Edge
    {
        public Edge(Node source, Node target, string name = null)
        {
            this.Name = name;
            this.Source = source;
            this.Target = target;
            this.Attributes = new Dictionary<string, string>();
        }

        public string Name { get; }
        public Node Source { get; }
        public Node Target { get; }
        public Dictionary<string, string> Attributes { get; }
    }
}
