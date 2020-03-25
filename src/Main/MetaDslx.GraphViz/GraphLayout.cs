using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Text;

namespace MetaDslx.GraphViz
{
    public class GraphLayout : NodeLayout, IDisposable
    {
        public const double DefaultDpi = 72;

        private string _engine;
        private object _graphObject;
        private Dictionary<object, NodeLayout> _objectToNodeMap;
        private Dictionary<object, EdgeLayout> _objectToEdgeMap;

        private IntPtr _graph;

        //private IntPtr _graphDpiAttribute;
        internal IntPtr _graphBbAttribute;
        internal IntPtr _graphRankSepAttribute;
        internal IntPtr _graphNodeSepAttribute;
        internal IntPtr _graphLenAttribute;
        internal IntPtr _graphMarginAttribute;

        internal IntPtr _nodeWidthAttribute;
        internal IntPtr _nodeHeightAttribute;
        internal IntPtr _nodeShapeAttribute;
        internal IntPtr _nodePosAttribute;
        internal IntPtr _nodeStyleAttribute;
        internal IntPtr _nodeMarginAttribute;

        internal IntPtr _edgePosAttribute;
        internal IntPtr _edgeDirAttribute;

        private bool _dirty;

        private string _dot;

        public GraphLayout(string engine, object graphObject = null) 
            : base(null, graphObject, true)
        {
            _graph = this.GraphVizSubGraph;
            _dirty = true;
            _engine = engine;
            _graphObject = graphObject;
            _objectToNodeMap = new Dictionary<object, NodeLayout>();
            _objectToEdgeMap = new Dictionary<object, EdgeLayout>();

            //_graphDpiAttribute = CGraphLib.agattr(_graph, CGraphLib.AGRAPH, "dpi", "72");
            _graphBbAttribute = CGraphLib.agattr(_graph, CGraphLib.AGRAPH, "bb", "");
            _graphRankSepAttribute = CGraphLib.agattr(_graph, CGraphLib.AGRAPH, "ranksep", "2");
            _graphNodeSepAttribute = CGraphLib.agattr(_graph, CGraphLib.AGRAPH, "nodesep", "1");
            _graphLenAttribute = CGraphLib.agattr(_graph, CGraphLib.AGRAPH, "len", "3");
            _graphMarginAttribute = CGraphLib.agattr(_graph, CGraphLib.AGRAPH, "margin", "10");

            _nodeWidthAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "width", "0");
            _nodeHeightAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "height", "0");
            _nodeShapeAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "shape", "rectangle");
            _nodePosAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "pos", "");
            _nodeStyleAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "style", "");
            _nodeMarginAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "margin", "0");

            _edgePosAttribute = CGraphLib.agattr(_graph, CGraphLib.AGEDGE, "pos", "");
            _edgeDirAttribute = CGraphLib.agattr(_graph, CGraphLib.AGEDGE, "dir", "none");
        }

        internal IntPtr GraphVizGraph => _graph;
        public object GraphObject => _graphObject;

        public IEnumerable<NodeLayout> AllNodes => _objectToNodeMap.Values;
        public IEnumerable<EdgeLayout> AllEdges => _objectToEdgeMap.Values;

        public double NodeSeparation { get; set; }
        public double RankSeparation { get; set; }
        public double EdgeLength { get; set; }
        public double NodeMargin { get; set; }

        internal void SetDirty()
        {
            _dirty = true;
        }

        public NodeLayout FindNodeLayout(object nodeObject)
        {
            if (_objectToNodeMap.TryGetValue(nodeObject, out var result)) return result;
            else return null;
        }

        public EdgeLayout FindEdgeLayout(object edgeObject)
        {
            if (_objectToEdgeMap.TryGetValue(edgeObject, out var result)) return result;
            else return null;
        }

        internal NodeLayout CreateNode(NodeLayout parent, object nodeObject)
        {
            _dirty = true;
            var n = new NodeLayout(parent, nodeObject);
            _objectToNodeMap.Add(nodeObject, n);
            return n;
        }

        internal EdgeLayout CreateEdge(NodeLayout source, NodeLayout target, object edgeObject)
        {
            _dirty = true;
            var e = new EdgeLayout(this, source, target, edgeObject);
            CGraphLib.agxset(e.GraphVizEdge, _edgeDirAttribute, "none");
            _objectToEdgeMap.Add(edgeObject, e);
            return e;
        }

        internal NodeLayout CreateSubGraph(NodeLayout parent, object nodeObject)
        {
            _dirty = true;
            var n = new NodeLayout(parent, nodeObject, true);
            _objectToNodeMap.Add(nodeObject, n);
            return n;
        }

        public void ComputeLayout()
        {
            if (!_dirty) return;
            foreach (var node in _objectToNodeMap.Values)
            {
                if (!node.IsSubGraph)
                {
                    if (node.PreferredPosition != null)
                    {
                        CGraphLib.agxset(node.GraphVizNode, _nodePosAttribute, node.PreferredPosition.ToString());
                    }
                    else
                    {
                        CGraphLib.agxset(node.GraphVizNode, _nodePosAttribute, "");
                    }
                    if (node.PreferredSize != null)
                    {
                        CGraphLib.agxset(node.GraphVizNode, _nodeWidthAttribute, node.PreferredSize?.X.ToString());
                        CGraphLib.agxset(node.GraphVizNode, _nodeHeightAttribute, node.PreferredSize?.Y.ToString());
                    }
                    else
                    {
                        CGraphLib.agxset(node.GraphVizNode, _nodeWidthAttribute, "");
                        CGraphLib.agxset(node.GraphVizNode, _nodeHeightAttribute, "");
                    }
                }
                else
                {
                    //CGraphLib.agxset(node.GraphVizSubGraph, _nodePosAttribute, "");
                    //CGraphLib.agxset(node.GraphVizSubGraph, _nodeWidthAttribute, "");
                    //CGraphLib.agxset(node.GraphVizSubGraph, _nodeHeightAttribute, "");
                    CGraphLib.agxset(node.GraphVizSubGraph, _graphMarginAttribute, (this.NodeMargin*DefaultDpi).ToString());
                }
            }
            CGraphLib.agxset(_graph, _graphNodeSepAttribute, this.NodeSeparation.ToString());
            CGraphLib.agxset(_graph, _graphRankSepAttribute, this.RankSeparation.ToString());
            CGraphLib.agxset(_graph, _graphLenAttribute, this.EdgeLength.ToString());
            //CGraphLib.agxset(_graph, _graphMarginAttribute, this.NodeMargin.ToString());
            _dot = GraphVizLib.Instance.Layout(_graph, _engine);
            var graphBb = Marshal.PtrToStringAnsi(CGraphLib.agxget(_graph, _graphBbAttribute));
            if (!string.IsNullOrEmpty(graphBb))
            {
                var parts = graphBb.Trim().Split(',');
                if (parts.Length == 4)
                {
                    double x1, y1, x2, y2;
                    if (double.TryParse(parts[0], out x1) && double.TryParse(parts[1], out y1) &&
                        double.TryParse(parts[2], out x2) && double.TryParse(parts[3], out y2))
                    {
                        x1 /= DefaultDpi;
                        y1 /= DefaultDpi;
                        x2 /= DefaultDpi;
                        y2 /= DefaultDpi;
                        this.Position = new Point2D((x1 + x2) / 2, (y1 + y2) / 2);
                        this.Size = new Point2D(x2 - x1, y2 - y1);
                    }
                }
                CGraphLib.agxset(_graph, _graphBbAttribute, "");
            }
            foreach (var node in _objectToNodeMap.Values)
            {
                if (node.IsSubGraph)
                {
                    var gvBb = Marshal.PtrToStringAnsi(CGraphLib.agxget(node.GraphVizSubGraph, _graphBbAttribute));
                    if (!string.IsNullOrEmpty(gvBb))
                    {
                        var parts = gvBb.Trim().Split(',');
                        if (parts.Length == 4)
                        {
                            double x1, y1, x2, y2;
                            if (double.TryParse(parts[0], out x1) && double.TryParse(parts[1], out y1) &&
                                double.TryParse(parts[2], out x2) && double.TryParse(parts[3], out y2))
                            {
                                x1 /= DefaultDpi;
                                y1 /= DefaultDpi;
                                x2 /= DefaultDpi;
                                y2 /= DefaultDpi;
                                node.Position = new Point2D((x1 + x2) / 2, (y1 + y2) / 2);
                                node.Size = new Point2D(x2 - x1, y2 - y1);
                            }
                        }
                        CGraphLib.agxset(node.GraphVizSubGraph, _graphBbAttribute, "");
                    }
                    else
                    {
                        if (node.PreferredSize != null) node.Size = node.PreferredSize.Value;
                    }
                }
                else
                {
                    var gvPos = Marshal.PtrToStringAnsi(CGraphLib.agxget(node.GraphVizNode, _nodePosAttribute));
                    if (!string.IsNullOrEmpty(gvPos))
                    {
                        node.Position = new Point2D(gvPos, GraphLayout.DefaultDpi);
                        CGraphLib.agxset(node.GraphVizNode, _nodePosAttribute, "");
                    }
                    var gvWidth = Marshal.PtrToStringAnsi(CGraphLib.agxget(node.GraphVizNode, _nodeWidthAttribute));
                    var gvHeight = Marshal.PtrToStringAnsi(CGraphLib.agxget(node.GraphVizNode, _nodeHeightAttribute));
                    if (!string.IsNullOrEmpty(gvWidth) && !string.IsNullOrEmpty(gvHeight))
                    {
                        if (double.TryParse(gvWidth, out var width) && double.TryParse(gvHeight, out var height))
                        {
                            node.Size = new Point2D(width, height);
                        }
                    }
                    else
                    {
                        if (node.PreferredSize != null) node.Size = node.PreferredSize.Value;
                    }
                }
            }
            foreach (var edge in _objectToEdgeMap.Values)
            {
                var gvPos = Marshal.PtrToStringAnsi(CGraphLib.agxget(edge.GraphVizEdge, _edgePosAttribute));
                if (!string.IsNullOrEmpty(gvPos))
                {
                    edge.SetControlPoints(gvPos);
                    CGraphLib.agxset(edge.GraphVizEdge, _edgePosAttribute, "");
                }
            }
            _dirty = false;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                CGraphLib.agclose(_graph);

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if GraphLayout(bool disposing) above has code to free unmanaged resources.
        ~GraphLayout()
        {
          // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
          Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

        public string ToDot()
        {
            return _dot;
        }
    }
}
