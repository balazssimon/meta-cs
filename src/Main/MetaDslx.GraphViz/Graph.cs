using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MetaDslx.GraphViz
{
    public class Graph : Node
    {
        private List<Node> _nodes;
        private List<Edge> _edges;

        public Graph(string name = null) 
            : base(name)
        {
            _nodes = new List<Node>();
            _edges = new List<Edge>();
        }

        public List<Node> Nodes => _nodes;
        public List<Edge> Edges => _edges;

        public Node AddNode(string name = null)
        {
            var result = new Node(name);
            _nodes.Add(result);
            return result;
        }

        public Edge AddEdge(Node source, Node target, string name = null)
        {
            var result = new Edge(source, target, name);
            _edges.Add(result);
            return result;
        }

        public Graph AddSubGraph(string name)
        {
            var result = new Graph(name);
            _nodes.Add(result);
            return result;
        }

        public GraphLayout Layout(string engine)
        {
            var builder = new GraphBuilder();
            builder.CreateGraph(this);
            builder.Layout(engine);
            builder.FreeGraph();
            return null;
        }

        private class GraphBuilder
        {
            private IntPtr _graph;
            private Dictionary<Node, IntPtr> _nodeMap;
            private Dictionary<Edge, IntPtr> _edgeMap;

            private IntPtr _widthAttribute;
            private IntPtr _heightAttribute;
            private IntPtr _shapeAttribute;
            private IntPtr _posAttribute;
            private IntPtr _bbAttribute;
            private IntPtr _splinesAttribute;
            private IntPtr _lpAttribute;

            public IntPtr Graph => _graph;

            public void CreateGraph(Graph graph)
            {
                _graph = CGraphLib.agopen(graph.Name, Agdesc_t.directed, IntPtr.Zero);
                _nodeMap = new Dictionary<Node, IntPtr>();
                _edgeMap = new Dictionary<Edge, IntPtr>();
                _widthAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "width", "1");
                _heightAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "height", "1");
                _shapeAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "shape", "rectangle");
                _posAttribute = CGraphLib.agattr(_graph, CGraphLib.AGNODE, "pos", "");
                _bbAttribute = CGraphLib.agattr(_graph, CGraphLib.AGRAPH, "bb", "");
                _splinesAttribute = CGraphLib.agattr(_graph, CGraphLib.AGEDGE, "pos", "");
                _lpAttribute = CGraphLib.agattr(_graph, CGraphLib.AGEDGE, "lp", "");
                CreateNodes(_graph, graph);
                CreateEdges(_graph, graph);
            }

            public void Layout(string engine)
            {
                GraphVizLib.Instance.Layout(_graph, engine);
                Console.WriteLine("bb: " + Marshal.PtrToStringAnsi(CGraphLib.agxget(_graph, _bbAttribute)));
                foreach (var node in _nodeMap)
                {
                    Console.WriteLine(node.Key.Name+ " pos: " + Marshal.PtrToStringAnsi(CGraphLib.agxget(node.Value, _posAttribute)));
                }
                foreach (var edge in _edgeMap)
                {
                    Console.WriteLine(edge.Key.Name+ " splines: " + Marshal.PtrToStringAnsi(CGraphLib.agxget(edge.Value, _splinesAttribute)));
                    Console.WriteLine(edge.Key.Name + " lp: " + Marshal.PtrToStringAnsi(CGraphLib.agxget(edge.Value, _lpAttribute)));
                }
            }

            public void FreeGraph()
            {
                CGraphLib.agclose(_graph);
            }

            private void CreateNodes(IntPtr g, Graph graph)
            {
                foreach (var node in graph.Nodes)
                {
                    if (node is Graph subGraph)
                    {
                        var sg = CGraphLib.agsubg(g, subGraph.Name, true);
                        _nodeMap.Add(subGraph, sg);
                        CreateNodes(sg, subGraph);
                        CreateEdges(sg, subGraph);
                    }
                    else
                    {
                        var n = CGraphLib.agnode(g, node.Name, true);
                        CGraphLib.agxset(n, _widthAttribute, node.Width.ToString());
                        CGraphLib.agxset(n, _heightAttribute, node.Height.ToString());
                        CGraphLib.agxset(n, _shapeAttribute, "rectangle");
                        _nodeMap.Add(node, n);
                    }
                }
            }

            private void CreateEdges(IntPtr g, Graph graph)
            {
                foreach (var edge in graph.Edges)
                {
                    if (_nodeMap.TryGetValue(edge.Source, out var source) && _nodeMap.TryGetValue(edge.Target, out var target))
                    {
                        var e = CGraphLib.agedge(g, source, target, edge.Name, true);
                        _edgeMap.Add(edge, e);
                    }
                }
            }
        }
    }
}
