using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.GraphViz
{
    public class Node
    {
        public Node(string name = null)
        {
            this.Name = name;
            this.Attributes = new Dictionary<string, string>();
            this.Width = 1;
            this.Height = 1;
        }

        public string Name { get; }
        public Dictionary<string,string> Attributes { get; }
        public double Height { get; }
        public double Width { get; }
    }
}
