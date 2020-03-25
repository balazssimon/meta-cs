using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.GraphViz
{
    public class NodeLayout
    {
        private static int SubGraphCounter = 0;

        private GraphLayout _graph;
        private NodeLayout _parentNode;
        private bool _isSubGraph;
        private object _nodeObject;
        private IntPtr _graphVizNode;
        private IntPtr _graphVizSubGraph;
        private Point2D? _preferredPosition;
        private Point2D? _preferredSize;
        private List<NodeLayout> _nodes;

        internal NodeLayout(NodeLayout parent, object nodeObject, bool isSubGraph = false)
        {
            _nodeObject = nodeObject;
            _isSubGraph = isSubGraph;
            _parentNode = parent;
            if (parent != null)
            {
                Debug.Assert(parent.IsSubGraph);
                _graph = parent.Graph;
                if (_isSubGraph) _graphVizSubGraph = CGraphLib.agsubg(parent.GraphVizSubGraph, "cluster"+(++SubGraphCounter), true);
                else _graphVizSubGraph = parent.GraphVizSubGraph;
                if (!_isSubGraph) _graphVizNode = CGraphLib.agnode(_graphVizSubGraph, null, true);
                //else _graphVizNode = _graphVizSubGraph;
                /*if (_isSubGraph)
                {
                    CGraphLib.agxset(_graphVizNode, _graph._nodeWidthAttribute, "0");
                    CGraphLib.agxset(_graphVizNode, _graph._nodeHeightAttribute, "0");
                    CGraphLib.agxset(_graphVizNode, _graph._nodeStyleAttribute, "invis");
                }*/
            }
            else
            {
                _graph = (GraphLayout)this;
                _graphVizSubGraph = CGraphLib.agopen(null, Agdesc_t.none, IntPtr.Zero);
                _graphVizNode = CGraphLib.agnode(_graphVizSubGraph, null, true);
            }
        }

        public GraphLayout Graph => _graph;
        public NodeLayout ParentNode => _parentNode;
        public bool IsSubGraph => _isSubGraph;
        public object NodeObject => _nodeObject;
        internal virtual IntPtr GraphVizNode => _graphVizNode;
        internal virtual IntPtr GraphVizSubGraph => _graphVizSubGraph;
        public IEnumerable<NodeLayout> Nodes => (IEnumerable<NodeLayout>)_nodes ?? ImmutableArray<NodeLayout>.Empty;

        public Point2D? PreferredPosition
        {
            get { return _preferredPosition; }
            set
            {
                if (value != _preferredPosition)
                {
                    _graph.SetDirty();
                    _preferredPosition = value;
                }
            }
        }

        public Point2D? PreferredSize
        {
            get { return _preferredSize; }
            set
            {
                if (value != _preferredSize)
                {
                    _graph.SetDirty();
                    _preferredSize = value;
                }
            }
        }

        public Point2D Position { get; internal set; }
        public Point2D Size { get; internal set; }
        public double Left => this.Position.X - this.Size.X / 2;
        public double Top => this.Position.Y - this.Size.Y / 2;
        public double Width => this.Size.X;
        public double Height => this.Size.Y;

        public NodeLayout AddNode(object nodeObject)
        {
            if (nodeObject == null) throw new ArgumentNullException(nameof(nodeObject));
            if (!_isSubGraph) throw new InvalidOperationException("The containing node is not a subgraph.");
            if (_graph.FindNodeLayout(nodeObject) != null) throw new InvalidOperationException("The graph already contains this node.");
            var result = _graph.CreateNode(this, nodeObject);
            if (_nodes == null) _nodes = new List<NodeLayout>();
            _nodes.Add(result);
            return result;
        }

        public EdgeLayout AddEdge(object sourceNodeObject, object targetNodeObject, object edgeObject = null, bool autoAddNodes = false)
        {
            if (sourceNodeObject == null) throw new ArgumentNullException(nameof(sourceNodeObject));
            if (targetNodeObject == null) throw new ArgumentNullException(nameof(targetNodeObject));
            var source = _graph.FindNodeLayout(sourceNodeObject);
            if (source == null)
            {
                if (autoAddNodes) source = _graph.CreateNode(_graph, sourceNodeObject);
                else throw new InvalidOperationException("The graph does not contain the source node.");
            }
            var target = _graph.FindNodeLayout(targetNodeObject);
            if (target == null)
            {
                if (autoAddNodes) target = _graph.CreateNode(_graph, targetNodeObject);
                else throw new InvalidOperationException("The graph does not contain the target node.");
            }
            if (source.IsSubGraph) throw new ArgumentException("The source of the edge must be a simple node, it cannot be a subgraph.", nameof(sourceNodeObject));
            if (target.IsSubGraph) throw new ArgumentException("The target of the edge must be a simple node, it cannot be a subgraph.", nameof(targetNodeObject));
            return _graph.CreateEdge(source, target, edgeObject);
        }

        public NodeLayout AddSubGraph(object nodeObject)
        {
            if (nodeObject == null) throw new ArgumentNullException(nameof(nodeObject));
            if (!_isSubGraph) throw new InvalidOperationException("The containing node is not a subgraph.");
            if (_graph.FindNodeLayout(nodeObject) != null) throw new InvalidOperationException("The graph already contains this node.");
            var result = _graph.CreateSubGraph(this, nodeObject);
            if (_nodes == null) _nodes = new List<NodeLayout>();
            _nodes.Add(result);
            return result;
        }

    }
}
