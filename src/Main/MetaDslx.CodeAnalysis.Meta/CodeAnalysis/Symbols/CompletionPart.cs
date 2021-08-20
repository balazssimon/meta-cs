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
    public sealed partial class CompletionPart
    {
        private string _name;

        public CompletionPart(string name)
        {
            _name = name;
        }

        public string Name => _name;

        public static ImmutableHashSet<CompletionPart> Combine(params CompletionPart[] parts)
        {
            return ImmutableHashSet.CreateRange<CompletionPart>(parts);
        }

        public override string ToString()
        {
            return _name;
        }
    }

    public sealed partial class CompletionGraph
    {
        public static readonly CompletionPart None = new CompletionPart(nameof(None));
        public static readonly CompletionPart All = new CompletionPart(nameof(All));

        public static readonly CompletionPart StartInitializing = new CompletionPart(nameof(StartInitializing));
        public static readonly CompletionPart FinishInitializing = new CompletionPart(nameof(FinishInitializing));
        public static readonly CompletionPart StartCreatingChildren = new CompletionPart(nameof(StartCreatingChildren));
        public static readonly CompletionPart FinishCreatingChildren = new CompletionPart(nameof(FinishCreatingChildren));
        public static readonly CompletionPart ChildrenCompleted = new CompletionPart(nameof(ChildrenCompleted));
        public static readonly CompletionPart StartComputingNonSymbolProperties = new CompletionPart(nameof(StartComputingNonSymbolProperties));
        public static readonly CompletionPart FinishComputingNonSymbolProperties = new CompletionPart(nameof(FinishComputingNonSymbolProperties));
        public static readonly CompletionPart StartValidatingSymbol = new CompletionPart(nameof(StartValidatingSymbol));
        public static readonly CompletionPart FinishValidatingSymbol = new CompletionPart(nameof(FinishValidatingSymbol));

        public static readonly CompletionPart StartCustomBinders = new CompletionPart(nameof(StartCustomBinders));
        public static readonly CompletionPart FinishCustomBinders = new CompletionPart(nameof(FinishCustomBinders));
    }
}
