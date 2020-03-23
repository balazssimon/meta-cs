using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.GraphViz
{
    public class EdgeLayout
    {
        private GraphLayout _graph;
        private object _edgeObject;
        private IntPtr _graphVizEdge;
        private NodeLayout _source;
        private NodeLayout _target;

        internal EdgeLayout(GraphLayout graph, NodeLayout source, NodeLayout target, object edgeObject)
        {
            _graph = graph;
            _edgeObject = edgeObject;
            _source = source;
            _target = target;
            _graphVizEdge = CGraphLib.agedge(_graph.GraphVizGraph, source.GraphVizNode, target.GraphVizNode, null, true);
        }

        public GraphLayout Graph => _graph;
        public object EdgeObject => _edgeObject;
        public NodeLayout Source => _source;
        public NodeLayout Target => _target;
        internal IntPtr GraphVizEdge => _graphVizEdge;

        public ImmutableArray<ImmutableArray<Point2D>> Splines { get; private set; }

        internal void SetControlPoints(string positions)
        {
            var splinesBuilder = ImmutableArray.CreateBuilder<ImmutableArray<Point2D>>();
            var pointsBuilder = ImmutableArray.CreateBuilder<Point2D>();
            var splinesStr = positions.Trim().Split(';');
            foreach (var splineStr in splinesStr)
            {
                var pointsStr = splineStr.Trim().Split(' ');
                int index = 0;
                Point2D? startPoint = null;
                Point2D? endPoint = null;
                pointsBuilder.Clear();
                foreach (var pointStr in pointsStr)
                {
                    if (index == 0 && pointStr.StartsWith("s,"))
                    {
                        startPoint = new Point2D(pointStr.Substring(2), GraphLayout.DefaultDpi);
                    }
                    else if (index == 0 && pointStr.StartsWith("e,"))
                    {
                        endPoint = new Point2D(pointStr.Substring(2), GraphLayout.DefaultDpi);
                    }
                    else
                    {
                        pointsBuilder.Add(new Point2D(pointStr, GraphLayout.DefaultDpi));
                        ++index;
                    }
                }
                Debug.Assert(pointsBuilder.Count % 3 == 1);
                if (startPoint != null) pointsBuilder[0] = startPoint.Value;
                if (endPoint != null) pointsBuilder[pointsBuilder.Count - 1] = endPoint.Value;
                splinesBuilder.Add(pointsBuilder.ToImmutable());
            }
            this.Splines = splinesBuilder.ToImmutable();
        }
    }
}
