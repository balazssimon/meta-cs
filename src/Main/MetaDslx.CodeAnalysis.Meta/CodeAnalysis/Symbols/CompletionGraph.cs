using MetaDslx.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public sealed partial class CompletionGraph
    {
        private ImmutableArray<CompletionPart> _parts;

        internal CompletionGraph(ImmutableArray<CompletionPart> parts)
        {
            _parts = parts;
        }

        public CompletionState CreateState()
        {
            return new CompletionState(this);
        }

        public ImmutableArray<CompletionPart> Parts => _parts;

        public int IndexOf(CompletionPart part)
        {
            int index = _parts.IndexOf(part);
            Debug.Assert(index >= 0);
            return index;
        }

        public bool HasComplete(CompletionPart part, int completeParts)
        {
            int index = _parts.IndexOf(part);
            Debug.Assert(index >= 0);
            if (index < 0) return false;
            return index <= completeParts;
        }

        public IEnumerable<CompletionPart> IncompleteParts(int completeParts)
        {
            return _parts.Skip(completeParts);
        }

        public CompletionPart NextIncompletePart(int completeParts)
        {
            if (completeParts + 1 < _parts.Length) return _parts[completeParts + 1];
            else return null;
        }
    }

    public sealed partial class CompletionGraphBuilder
    {
        private List<CompletionPart> _parts;
        private Dictionary<CompletionPart, HashSet<CompletionPart>> _edges;

        public CompletionGraphBuilder()
        {
            _parts = new List<CompletionPart>();
            _edges = new Dictionary<CompletionPart, HashSet<CompletionPart>>();
        }

        public CompletionGraphBuilder Add(CompletionPart part)
        {
            _parts.Add(part);
            return this;
        }

        public CompletionGraphBuilder AddLast(CompletionPart part)
        {
            _parts.Add(part);
            if (_parts.Count >= 2)
            {
                int index = _parts.Count - 1;
                this.Precedes(_parts[index - 1], _parts[index]);
            }
            return this;
        }

        public CompletionGraphBuilder Precedes(CompletionPart source, CompletionPart target)
        {
            if (!_parts.Contains(source)) throw new ArgumentException("Part is not in the completion graph.", nameof(source));
            if (!_parts.Contains(target)) throw new ArgumentException("Part is not in the completion graph.", nameof(target));
            if (source == CompletionGraph.None) throw new ArgumentException("Part cannot depend on None", nameof(source));
            if (source == CompletionGraph.All) throw new ArgumentException("Part cannot depend on All", nameof(source));
            if (target == CompletionGraph.None) throw new ArgumentException("None cannot depend on another part.", nameof(target));
            if (target == CompletionGraph.All) throw new ArgumentException("All cannot depend on another part.", nameof(target));
            HashSet<CompletionPart> sources;
            if (!_edges.TryGetValue(target, out sources))
            {
                sources = new HashSet<CompletionPart>();
                _edges.Add(target, sources);
            }
            sources.Add(source);
            return this;
        }

        public CompletionGraph Build()
        {
            ArrayBuilder<CompletionPart> result = ArrayBuilder<CompletionPart>.GetInstance();
            try
            {
                HashSet<CompletionPart> visited = new HashSet<CompletionPart>();
                Stack<CompletionPart> stack = new Stack<CompletionPart>();
                int rootIndex = 0;
                while (rootIndex < _parts.Count)
                {
                    while (rootIndex < _parts.Count && visited.Contains(_parts[rootIndex])) ++rootIndex;
                    if (rootIndex >= _parts.Count) break;
                    VisitNode(_parts[rootIndex], stack, visited, result);
                    ++rootIndex;
                }
                result.Add(CompletionGraph.All);
                return new CompletionGraph(result.ToImmutableArray());
            }
            finally
            {
                result.Free();
            }
        }

        private void VisitNode(CompletionPart node, Stack<CompletionPart> stack, HashSet<CompletionPart> visited, ArrayBuilder<CompletionPart> result)
        {
            if (stack.Contains(node))
            {
                var items = stack.ToList();
                var startIndex = items.IndexOf(node);
                StringBuilder sb = new StringBuilder();
                for (int i = startIndex; i < items.Count; i++)
                {
                    sb.Append(" -> ");
                    sb.Append(items[i].Name);
                }
                sb.Append(node.Name);
                throw new InvalidOperationException("Circular dependency in the completion graph: " + sb.ToString());
            }
            if (!visited.Add(node)) return;
            if (!_edges.TryGetValue(node, out var sources))
            {
                result.Add(node);
                return;
            }
            stack.Push(node);
            try
            {
                foreach (var source in sources)
                {
                    VisitNode(source, stack, visited, result);
                }
                result.Add(node);
            }
            finally
            {
                stack.Pop();
            }
        }
    }

}
