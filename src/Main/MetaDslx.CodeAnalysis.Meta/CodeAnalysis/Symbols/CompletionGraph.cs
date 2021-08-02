using Microsoft.CodeAnalysis.PooledObjects;
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

        public static CompletionGraph FromCompletionParts(params CompletionPart[] parts)
        {
            return new CompletionGraph(parts.ToImmutableArray());
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

}
