using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class CompletionPart
    {
        public static readonly CompletionPart None = new CompletionPart();
        public static readonly CompletionPart All = new CompletionPart();
        public static readonly CompletionPart Attributes = new CompletionPart();

        public static readonly CompletionPart TypeMembers = new CompletionPart();
        public static readonly CompletionPart Members = new CompletionPart();
    }

    public class SymbolCompletionState
    {
        /// <summary>
        /// This field keeps track of the <see cref="CompletionPart"/>s for which we already retrieved
        /// diagnostics. We shouldn't return from ForceComplete (i.e. indicate that diagnostics are
        /// available) until this is equal to <see cref="CompletionPart.All"/>, except that when completing
        /// with a given position, we might not complete <see cref="CompletionPart"/>.Member*.
        /// 
        /// Since completeParts is used as a flag indicating completion of other assignments 
        /// it must be volatile to ensure the read is not reordered/optimized to happen 
        /// before the writes.
        /// </summary>
        private volatile int _completeParts;
        private CompletionGraph _graph;

        public IEnumerable<CompletionPart> IncompleteParts
        {
            get
            {
                return _graph.IncompleteParts(_completeParts);
            }
        }

        /// <summary>
        /// Used to force (source) symbols to a given state of completion when the only potential remaining 
        /// part is attributes. This does force the invariant on the caller that the implementation of 
        /// of <see cref="Symbol.GetAttributes"/> will set the part <see cref="CompletionPart.Attributes"/> on
        /// the thread that actually completes the loading of attributes. Failure to do so will potentially
        /// result in a deadlock.
        /// </summary>
        /// <param name="symbol">The owning source symbol.</param>
        public void DefaultForceComplete(Symbol symbol, CancellationToken cancellationToken)
        {
            Debug.Assert(symbol.RequiresCompletion);
            if (!HasComplete(CompletionPart.Attributes))
            {
                _ = symbol.GetAttributes();

                // Consider the following items:
                //  1. It is possible for parallel calls to GetAttributes to exist
                //  2. GetAttributes implementation can validly return when the attributes are available but before the 
                //     CompletionParts.Attributes value is set.
                //  3. GetAttributes implementation typically have the invariant that the thread which completes the 
                //     loading of attributes is the one which sets CompletionParts.Attributes.
                //  4. This call cannot correctly return until CompletionParts.Attributes is set.
                //
                // Note: #2 above is common practice amongst all of the symbols. 
                //
                // Note: #3 above is an invariant that has existed in the code base for some time. It's not 100% clear
                // whether this invariant is tied to correctness or not. The most compelling example though is 
                // SourceEventSymbol which raises SymbolDeclaredEvent before CompletionPart.Attributes is noted as completed. 
                // Many other implementations have this pattern but no apparent code which could depend on it.
                SpinWaitComplete(CompletionPart.Attributes, cancellationToken);
            }

            // any other values are completion parts intended for other kinds of symbols
            NotePartComplete(CompletionPart.All);
        }

        public bool HasComplete(CompletionPart part)
        {
            // completeParts is used as a flag indicating completion of other assignments 
            // Volatile.Read is used to ensure the read is not reordered/optimized to happen 
            // before the writes.
            return _graph.HasComplete(part, _completeParts);
        }

        public bool NotePartComplete(CompletionPart part)
        {
            // passing volatile completeParts byref is ok here.
            // ThreadSafeFlagOperations.Set performs interlocked assignments
            int index = _graph.IndexOf(part);
            if (index <= _completeParts) return false;
            Debug.Assert(index == _completeParts + 1, "TODO:MetaDslx");
            Interlocked.Exchange(ref _completeParts, index);
            return true;
        }

        /// <summary>
        /// Produce the next (i.e. lowest) CompletionPart (bit) that is not set.
        /// </summary>
        internal CompletionPart NextIncompletePart
        {
            get
            {
                // NOTE: It's very important to store this value in a local.
                // If we were to inline the field access, the value of the
                // field could change between the two accesses and the formula
                // might not produce a result with a single 1-bit.
                return _graph.NextIncompletePart(_completeParts);
            }
        }

        internal void SpinWaitComplete(CompletionPart part, CancellationToken cancellationToken)
        {
            if (HasComplete(part))
            {
                return;
            }

            // Don't return until we've seen all of the requested CompletionParts. This ensures all
            // diagnostics have been reported (not necessarily on this thread).
            var spinWait = new SpinWait();
            while (!HasComplete(part))
            {
                cancellationToken.ThrowIfCancellationRequested();
                spinWait.SpinOnce();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("CompletionParts(");
            bool any = false;
            for (int i = 0; i <= _completeParts; i++)
            {
                if (any) result.Append(", ");
                result.Append(i);
                any = true;
            }
            result.Append(")");
            return result.ToString();
        }
    }

    public class CompletionGraph
    {
        private ImmutableArray<CompletionPart> _parts;

        public CompletionGraph(ImmutableArray<CompletionPart> parts)
        {
            _parts = parts;
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
            else return CompletionPart.All;
        }
    }

    public class CompletionGraphBuilder
    {
        private HashSet<CompletionPart> _parts;
        private Dictionary<CompletionPart, HashSet<CompletionPart>> _edges;

        public CompletionGraphBuilder()
        {
            _parts = new HashSet<CompletionPart>();
            _edges = new Dictionary<CompletionPart, HashSet<CompletionPart>>();
        }

        public CompletionGraphBuilder AddPart(CompletionPart part)
        {
            _parts.Add(part);
            return this;
        }

        public CompletionGraphBuilder DependsOn(CompletionPart depends, CompletionPart on)
        {
            if (!_parts.Contains(depends)) throw new ArgumentException("Part is not in the completion graph.", nameof(depends));
            if (!_parts.Contains(on)) throw new ArgumentException("Part is not in the completion graph.", nameof(on));
            if (on == CompletionPart.All) throw new ArgumentException("Part cannot depend on CompletionPart.All", nameof(on));
            if (depends == CompletionPart.None) throw new ArgumentException("None cannot depend on another part.", nameof(on));
            HashSet<CompletionPart> pre;
            if (!_edges.TryGetValue(depends, out pre))
            {
                pre = new HashSet<CompletionPart>();
                _edges.Add(depends, pre);
            }
            pre.Add(on);
            return this;
        }

        public CompletionGraph Build()
        {
            // TODO:MetaDslx - sort parts in topological order
            return new CompletionGraph(_parts.ToImmutableArray());
        }
    }
}
