using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.GraphViz
{
    public class NodeLayout
    {
        private GraphLayout _graph;
        private NodeLayout _parentNode;
        private bool _isSubGraph;
        private object _nodeObject;
        private IntPtr _graphVizNode;
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
                _graph = parent.Graph;
                if (_isSubGraph) _graphVizNode = CGraphLib.agsubg(parent.GraphVizNode, null, true);
                else _graphVizNode = CGraphLib.agnode(parent.GraphVizNode, null, true);
            }
            else
            {
                _graph = (GraphLayout)this;
            }
        }

        public GraphLayout Graph => _graph;
        public NodeLayout ParentNode => _parentNode;
        public bool IsSubGraph => _isSubGraph;
        public object NodeObject => _nodeObject;
        internal virtual IntPtr GraphVizNode => _graphVizNode;
        public IEnumerable<NodeLayout> Nodes => _nodes;

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
