using Microsoft.CodeAnalysis.PooledObjects;
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
        private string _name;

        public CompletionPart(string name)
        {
            _name = name;
        }

        public string Name => _name;

        public static readonly CompletionPart None = new CompletionPart(nameof(None));
        public static readonly CompletionPart All = new CompletionPart(nameof(All));
        public static readonly CompletionPart Attributes = new CompletionPart(nameof(Attributes));
        public static readonly CompletionPart Module = new CompletionPart(nameof(Module));

        public static readonly CompletionPart StartValidatingReferencedAssemblies = new CompletionPart(nameof(StartValidatingReferencedAssemblies));
        public static readonly CompletionPart FinishValidatingReferencedAssemblies = new CompletionPart(nameof(FinishValidatingReferencedAssemblies));
        
        public static readonly CompletionPart StartValidatingAddedModules = new CompletionPart(nameof(StartValidatingAddedModules));
        public static readonly CompletionPart FinishValidatingAddedModules = new CompletionPart(nameof(FinishValidatingAddedModules));

        public static readonly CompletionPart StartAttributeChecks = new CompletionPart(nameof(StartAttributeChecks));
        public static readonly CompletionPart FinishAttributeChecks = new CompletionPart(nameof(FinishAttributeChecks));

        public static readonly CompletionPart StartBaseTypes = new CompletionPart(nameof(StartBaseTypes));
        public static readonly CompletionPart FinishBaseTypes = new CompletionPart(nameof(FinishBaseTypes));

        public static readonly CompletionPart Members = new CompletionPart(nameof(Members));
        public static readonly CompletionPart TypeMembers = new CompletionPart(nameof(TypeMembers));

        public static readonly CompletionPart StartMemberChecks = new CompletionPart(nameof(StartMemberChecks));
        public static readonly CompletionPart FinishMemberChecks = new CompletionPart(nameof(FinishMemberChecks));

        public static readonly CompletionPart StartValidatingImports = new CompletionPart(nameof(StartValidatingImports));
        public static readonly CompletionPart FinishValidatingImports = new CompletionPart(nameof(FinishValidatingImports));

        public static readonly CompletionPart NameToMembersMap = new CompletionPart(nameof(NameToMembersMap));
        public static readonly CompletionPart MembersCompleted = new CompletionPart(nameof(MembersCompleted));

        //public static readonly CompletionPart StartProperties = new CompletionPart(nameof(StartProperties));
        //public static readonly CompletionPart FinishProperties = new CompletionPart(nameof(FinishProperties));

        public static readonly CompletionPart StartBoundNode = new CompletionPart(nameof(StartBoundNode));
        public static readonly CompletionPart FinishBoundNode = new CompletionPart(nameof(FinishBoundNode));

        public static readonly CompletionPart AliasTarget = new CompletionPart(nameof(AliasTarget));

        public static readonly ImmutableHashSet<CompletionPart> AssemblySymbolAll =
            Combine(Attributes, StartAttributeChecks, FinishAttributeChecks, Module, StartValidatingAddedModules, FinishValidatingAddedModules);
        public static readonly ImmutableHashSet<CompletionPart> ModuleSymbolAll =
            Combine(Attributes, StartValidatingReferencedAssemblies, FinishValidatingReferencedAssemblies, MembersCompleted);

        public static readonly ImmutableHashSet<CompletionPart> NamedTypeSymbolWithLocationAll =
            Combine(Attributes, StartBaseTypes, FinishBaseTypes, Members, TypeMembers, StartMemberChecks, FinishMemberChecks/*, StartProperties, FinishProperties*/);
        public static readonly ImmutableHashSet<CompletionPart> NamedTypeSymbolAll = 
            Combine(Attributes, StartBaseTypes, FinishBaseTypes, Members, TypeMembers, StartMemberChecks, FinishMemberChecks/*, StartProperties, FinishProperties*/, StartBoundNode, FinishBoundNode, MembersCompleted);

        public static readonly ImmutableHashSet<CompletionPart> ImportsAll =
            Combine(StartValidatingImports, FinishValidatingImports);

        public static readonly ImmutableHashSet<CompletionPart> NamespaceSymbolWithLocationAll =
            Combine(Attributes, NameToMembersMap/*, StartProperties, FinishProperties*/);
        public static readonly ImmutableHashSet<CompletionPart> NamespaceSymbolAll =
            Combine(Attributes, NameToMembersMap, MembersCompleted/*, StartProperties, FinishProperties*/, StartBoundNode, FinishBoundNode);

        public static ImmutableHashSet<CompletionPart> Combine(params CompletionPart[] parts)
        {
            return ImmutableHashSet.CreateRange<CompletionPart>(parts);
        }

        public override string ToString()
        {
            return _name;
        }

        internal static CompletionGraphBuilder ConstructDefaultCompletionGraph()
        {
            CompletionGraphBuilder builder = new CompletionGraphBuilder();
            builder.AddLast(CompletionPart.Attributes);
            builder.AddLast(CompletionPart.StartAttributeChecks);
            builder.AddLast(CompletionPart.FinishAttributeChecks);
            builder.AddLast(CompletionPart.StartBaseTypes);
            builder.AddLast(CompletionPart.FinishBaseTypes);
            builder.AddLast(CompletionPart.Members);
            builder.AddLast(CompletionPart.TypeMembers);
            builder.AddLast(CompletionPart.StartMemberChecks);
            builder.AddLast(CompletionPart.FinishMemberChecks);
            builder.AddLast(CompletionPart.StartValidatingImports);
            builder.AddLast(CompletionPart.FinishValidatingImports);
            builder.AddLast(CompletionPart.NameToMembersMap);
            builder.AddLast(CompletionPart.AliasTarget);
            builder.AddLast(CompletionPart.StartBoundNode);
            builder.AddLast(CompletionPart.FinishBoundNode);
            //builder.AddLast(CompletionPart.StartProperties);
            //builder.AddLast(CompletionPart.FinishProperties);
            builder.AddLast(CompletionPart.MembersCompleted);
            builder.AddLast(CompletionPart.Module);
            builder.AddLast(CompletionPart.StartValidatingAddedModules);
            builder.AddLast(CompletionPart.FinishValidatingAddedModules);
            builder.AddLast(CompletionPart.StartValidatingReferencedAssemblies);
            builder.AddLast(CompletionPart.FinishValidatingReferencedAssemblies);
            return builder;
        }
    }

    public sealed class SymbolCompletionState
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

        internal SymbolCompletionState(CompletionGraph graph)
        {
            _completeParts = -1;
            _graph = graph;
        }

        public static SymbolCompletionState Create(Language language)
        {
            return language.CompilationFactory.CompletionGraph.CreateState();
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

    public sealed class CompletionGraph
    {
        private ImmutableArray<CompletionPart> _parts;

        internal CompletionGraph(ImmutableArray<CompletionPart> parts)
        {
            _parts = parts;
        }

        public SymbolCompletionState CreateState()
        {
            return new SymbolCompletionState(this);
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

    public sealed class CompletionGraphBuilder
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
            if (source == CompletionPart.None) throw new ArgumentException("Part cannot depend on CompletionPart.None", nameof(source));
            if (source == CompletionPart.All) throw new ArgumentException("Part cannot depend on CompletionPart.All", nameof(source));
            if (target == CompletionPart.None) throw new ArgumentException("None cannot depend on another part.", nameof(target));
            if (target == CompletionPart.All) throw new ArgumentException("All cannot depend on another part.", nameof(target));
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
                result.Add(CompletionPart.All);
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
