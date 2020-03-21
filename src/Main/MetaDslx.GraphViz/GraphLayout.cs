using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.GraphViz
{
    public class GraphLayout
    {
        private ImmutableArray<NodeLayout> _nodes;
        private ImmutableArray<EdgeLayout> _edges;

        internal GraphLayout(ImmutableArray<NodeLayout> nodes, ImmutableArray<EdgeLayout> edges)
        {
            _nodes = nodes;
            _edges = edges;
        }

        public ImmutableArray<NodeLayout> Nodes => _nodes;
        public ImmutableArray<EdgeLayout> Edges => _edges;
    }
}
