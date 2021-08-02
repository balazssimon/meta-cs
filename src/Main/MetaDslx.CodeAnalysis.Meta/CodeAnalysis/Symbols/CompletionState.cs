using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public sealed class CompletionState
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

        internal CompletionState(CompletionGraph graph)
        {
            _completeParts = -1;
            _graph = graph;
        }

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
            /* TODO:MetaDslx: if (!HasComplete(CompletionGraph.Attributes))
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
                SpinWaitComplete(CompletionGraph.Attributes, cancellationToken);
            }*/

            // any other values are completion parts intended for other kinds of symbols
            NotePartComplete(CompletionGraph.All);
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
            int oldIndex = _completeParts;
            return Interlocked.CompareExchange(ref _completeParts, index, oldIndex) == oldIndex;
        }

        /// <summary>
        /// Produce the next (i.e. lowest) CompletionPart (bit) that is not set.
        /// </summary>
        public CompletionPart NextIncompletePart
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

        public void SpinWaitComplete(CompletionPart part, CancellationToken cancellationToken)
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

        public void SpinWaitComplete(IEnumerable<CompletionPart> parts, CancellationToken cancellationToken)
        {
            if (!parts.Any()) return;
            int index = parts.Select(p => _graph.IndexOf(p)).Max();
            if (index < 0) return;
            CompletionPart part = _graph.Parts[index];
            this.SpinWaitComplete(part, cancellationToken);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("CompletionParts(");
            bool any = false;
            for (int i = 0; i <= _completeParts; i++)
            {
                if (any) result.Append(", ");
                result.Append(_graph.Parts[i].Name);
                any = true;
            }
            result.Append(")");
            return result.ToString();
        }
    }

}
