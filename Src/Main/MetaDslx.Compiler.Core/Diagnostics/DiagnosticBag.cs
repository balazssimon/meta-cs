using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    /// <summary>
    /// Represents a mutable bag of diagnostics. You can add diagnostics to the bag,
    /// and also get all the diagnostics out of the bag (the bag implements
    /// IEnumerable&lt;Diagnostics&gt;. Once added, diagnostics cannot be removed, and no ordering
    /// is guaranteed.
    /// 
    /// It is ok to Add diagnostics to the same bag concurrently on multiple threads.
    /// It is NOT ok to Add concurrently with Clear or Free operations.
    /// </summary>
    /// <remarks>The bag is optimized to be efficient when containing zero errors.</remarks>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
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
        /// Returns true if the bag has any non-lazy diagnostics with Severity=Error.
        /// </summary>
        /// <remarks>
        /// Does not resolve any lazy diagnostics in the bag.
        /// 
        /// Generally, this should only be called by the creator (modulo pooling) of the bag (i.e. don't use bags to communicate -
        /// if you need more info, pass more info).
        /// </remarks>
        internal bool HasAnyResolvedErrors()
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
        /// Add another DiagnosticBag to the bag and free the argument.
        /// </summary>
        public void AddRangeAndFree(DiagnosticBag bag)
        {
            AddRange(bag);
            bag.Free();
        }

        /// <summary>
        /// Seal the bag so no further errors can be added, while clearing it and returning the old set of errors.
        /// Return the bag to the pool.
        /// </summary>
        public ImmutableArray<Diagnostic> ToReadOnlyAndFree()
        {
            ConcurrentQueue<Diagnostic> oldBag = _lazyBag;
            Free();

            return ToReadOnlyCore(oldBag);
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

            ArrayBuilder<Diagnostic> builder = ArrayBuilder<Diagnostic>.GetInstance();

            foreach (Diagnostic diagnostic in oldBag) // Cast should be safe since all diagnostics should be from same language.
            {
                builder.Add(diagnostic);
            }

            return builder.ToImmutableAndFree();
        }


        /// <remarks>
        /// Generally, this should only be called by the creator (modulo pooling) of the bag (i.e. don't use bags to communicate -
        /// if you need more info, pass more info).
        /// </remarks>
        public IEnumerable<Diagnostic> AsEnumerable()
        {
            return this.Bag;
        }

        internal IEnumerable<Diagnostic> AsEnumerableWithoutResolution()
        {
            // PERF: don't make a defensive copy - callers are internal and won't modify the bag.
            return _lazyBag ?? EmptyCollections.Enumerable<Diagnostic>();
        }

        public override string ToString()
        {
            if (this.IsEmptyWithoutResolution)
            {
                // TODO(cyrusn): do we need to localize this?
                return "<no errors>";
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                foreach (Diagnostic diag in Bag) // NOTE: don't force resolution
                {
                    builder.AppendLine(diag.ToString());
                }
                return builder.ToString();
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

        // clears the bag.
        /// NOTE: Concurrent Adding to the bag is supported, but concurrent Clearing is not.
        ///       If one thread adds to the bug while another clears it, the scenario is 
        ///       broken and we cannot do anything about it here.
        internal void Clear()
        {
            ConcurrentQueue<Diagnostic> bag = _lazyBag;
            if (bag != null)
            {
                _lazyBag = null;
            }
        }

        #region "Poolable"

        internal static DiagnosticBag GetInstance()
        {
            DiagnosticBag bag = s_poolInstance.Allocate();
            return bag;
        }

        internal void Free()
        {
            Clear();
            s_poolInstance.Free(this);
        }

        private static readonly ObjectPool<DiagnosticBag> s_poolInstance = CreatePool(128);
        private static ObjectPool<DiagnosticBag> CreatePool(int size)
        {
            return new ObjectPool<DiagnosticBag>(() => new DiagnosticBag(), size);
        }

        #endregion

        #region Debugger View

        internal sealed class DebuggerProxy
        {
            private readonly DiagnosticBag _bag;

            public DebuggerProxy(DiagnosticBag bag)
            {
                _bag = bag;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public object[] Diagnostics
            {
                get
                {
                    ConcurrentQueue<Diagnostic> lazyBag = _bag._lazyBag;
                    if (lazyBag != null)
                    {
                        return lazyBag.ToArray();
                    }
                    else
                    {
                        return EmptyCollections.ObjectArray;
                    }
                }
            }
        }

        private string GetDebuggerDisplay()
        {
            return "Count = " + (_lazyBag?.Count ?? 0);
        }
        #endregion

        /// <summary>
        /// Add a diagnostic to the bag.
        /// </summary>
        /// <param name="diagnostics"></param>
        /// <param name="code"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public DiagnosticInfo Add(MessageProvider messageProvider, Location location, int code)
        {
            var diag = Diagnostic.Create(messageProvider, location, code);
            this.Add(diag);
            return diag.Info;
        }

        /// <summary>
        /// Add a diagnostic to the bag.
        /// </summary>
        /// <param name="diagnostics"></param>
        /// <param name="code"></param>
        /// <param name="location"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DiagnosticInfo Add(MessageProvider messageProvider, Location location, int code, params object[] args)
        {
            var diag = Diagnostic.Create(messageProvider, location, code, args);
            this.Add(diag);
            return diag.Info;
        }

        public DiagnosticInfo Add(MessageProvider messageProvider, Location location, int code, ImmutableArray<IMetaSymbol> symbols, params object[] args)
        {
            var info = new SymbolDiagnosticInfo(messageProvider, symbols, code, args);
            var diag = Diagnostic.Create(info, location);
            this.Add(diag);
            return info;
        }

        public void Add(DiagnosticInfo info, Location location)
        {
            var diag = Diagnostic.Create(info, location);
            this.Add(diag);
        }

        /// <summary>
        /// Adds diagnostics from useSiteDiagnostics into diagnostics and returns True if there were any errors.
        /// </summary>
        public bool Add(SyntaxNode node, HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return this.Add(node.GetLocation(), useSiteDiagnostics);
        }

        public bool Add(Location location, HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            if (useSiteDiagnostics == null || !useSiteDiagnostics.Any())
            {
                return false;
            }

            bool haveErrors = false;

            foreach (var info in useSiteDiagnostics)
            {
                if (info.Severity == DiagnosticSeverity.Error)
                {
                    haveErrors = true;
                }

                this.Add(Diagnostic.Create(info, location));
            }

            return haveErrors;
        }
    }
}
