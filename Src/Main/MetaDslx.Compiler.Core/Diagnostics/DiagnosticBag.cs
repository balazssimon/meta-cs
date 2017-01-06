using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    public class DiagnosticBag
    {
        // The lazyBag field is populated lazily -- the first time an error is added.
        private ConcurrentQueue<Diagnostic> _lazyBag;

        /// <summary>
        /// Return true if the bag is completely empty - not even containing void diagnostics.
        /// </summary>
        /// <remarks>
        /// This exists for short-circuiting purposes. Use <see cref="System.Linq.Enumerable.Any{T}(IEnumerable{T})"/>
        /// to get a resolved Tuple(Of NamedTypeSymbol, ImmutableArray(Of Diagnostic)) (i.e. empty after eliminating void diagnostics).
        /// </remarks>
        public bool IsEmptyWithoutResolution
        {
            get
            {
                // It should be safe to access this here, since we normally have a collect phase and
                // then a report phase, and we shouldn't be called during the "report" phase. We
                // also never remove diagnostics, so the worst that happens is that we don't return
                // an element that is added a split second after this is called.
                ConcurrentQueue<Diagnostic> bag = _lazyBag;
                return bag == null || bag.IsEmpty;
            }
        }

        /// <summary>
        /// Returns true if the bag has any diagnostics with Severity=Error. Does not consider warnings or informationals.
        /// </summary>
        /// <remarks>
        /// Resolves any lazy diagnostics in the bag.
        /// 
        /// Generally, this should only be called by the creator (modulo pooling) of the bag (i.e. don't use bags to communicate -
        /// if you need more info, pass more info).
        /// </remarks>
        public bool HasAnyErrors()
        {
            if (IsEmptyWithoutResolution)
            {
                return false;
            }

            foreach (Diagnostic diagnostic in Bag)
            {
                if (diagnostic.Severity == DiagnosticSeverity.Error)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Add a diagnostic to the bag.
        /// </summary>
        public void Add(Diagnostic diag)
        {
            ConcurrentQueue<Diagnostic> bag = this.Bag;
            bag.Enqueue(diag);
        }

        /// <summary>
        /// Add multiple diagnostics to the bag.
        /// </summary>
        public void AddRange(ImmutableArray<Diagnostic> diagnostics)
        {
            if (!diagnostics.IsDefaultOrEmpty)
            {
                ConcurrentQueue<Diagnostic> bag = this.Bag;
                for (int i = 0; i < diagnostics.Length; i++)
                {
                    bag.Enqueue(diagnostics[i]);
                }
            }
        }

        /// <summary>
        /// Add multiple diagnostics to the bag.
        /// </summary>
        public void AddRange(IEnumerable<Diagnostic> diagnostics)
        {
            foreach (Diagnostic diagnostic in diagnostics)
            {
                this.Bag.Enqueue(diagnostic);
            }
        }

        /// <summary>
        /// Add another DiagnosticBag to the bag.
        /// </summary>
        public void AddRange(DiagnosticBag bag)
        {
            if (!bag.IsEmptyWithoutResolution)
            {
                AddRange(bag.Bag);
            }
        }

        /// <summary>
        /// Get the underlying concurrent storage, creating it on demand if needed.
        /// NOTE: Concurrent Adding to the bag is supported, but concurrent Clearing is not.
        ///       If one thread adds to the bug while another clears it, the scenario is 
        ///       broken and we cannot do anything about it here.
        /// </summary>
        private ConcurrentQueue<Diagnostic> Bag
        {
            get
            {
                ConcurrentQueue<Diagnostic> bag = _lazyBag;
                if (bag != null)
                {
                    return bag;
                }

                ConcurrentQueue<Diagnostic> newBag = new ConcurrentQueue<Diagnostic>();
                return Interlocked.CompareExchange(ref _lazyBag, newBag, null) ?? newBag;
            }
        }

        public ImmutableArray<Diagnostic> ToReadOnly()
        {
            ConcurrentQueue<Diagnostic> oldBag = _lazyBag;
            return ToReadOnlyCore(oldBag);
        }

        private static ImmutableArray<Diagnostic> ToReadOnlyCore(ConcurrentQueue<Diagnostic> oldBag)
        {
            if (oldBag == null)
            {
                return ImmutableArray<Diagnostic>.Empty;
            }

            ImmutableArray<Diagnostic>.Builder builder = ImmutableArray.CreateBuilder<Diagnostic>();

            foreach (Diagnostic diagnostic in oldBag) // Cast should be safe since all diagnostics should be from same language.
            {
                builder.Add(diagnostic);
            }

            return builder.ToImmutable();
        }


        private string GetDebuggerDisplay()
        {
            return "Count = " + (_lazyBag?.Count ?? 0);
        }
    }
}
