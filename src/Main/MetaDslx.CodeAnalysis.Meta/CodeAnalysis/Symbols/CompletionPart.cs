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

        public static readonly CompletionPart StartCreated = new CompletionPart(nameof(StartCreated));
        public static readonly CompletionPart FinishCreated = new CompletionPart(nameof(FinishCreated));
        public static readonly CompletionPart StartChildrenCreated = new CompletionPart(nameof(StartChildrenCreated));
        public static readonly CompletionPart FinishChildrenCreated = new CompletionPart(nameof(FinishChildrenCreated));

        //*/
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

        public static readonly CompletionPart StartValidatingImports = new CompletionPart(nameof(StartValidatingImports));
        public static readonly CompletionPart FinishValidatingImports = new CompletionPart(nameof(FinishValidatingImports));

        public static readonly CompletionPart StartProperties = new CompletionPart(nameof(StartProperties));
        public static readonly CompletionPart FinishProperties = new CompletionPart(nameof(FinishProperties));

        //public static readonly CompletionPart ChildrenCompleted = new CompletionPart(nameof(ChildrenCompleted));

        public static readonly CompletionPart StartCustomBinders = new CompletionPart(nameof(StartCustomBinders));
        public static readonly CompletionPart FinishCustomBinders = new CompletionPart(nameof(FinishCustomBinders));

        public static readonly CompletionPart AliasTarget = new CompletionPart(nameof(AliasTarget));

        public static readonly ImmutableHashSet<CompletionPart> AssemblySymbolAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartAttributeChecks, FinishAttributeChecks, Module, StartValidatingAddedModules, FinishValidatingAddedModules);
        public static readonly ImmutableHashSet<CompletionPart> ModuleSymbolAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartValidatingReferencedAssemblies, FinishValidatingReferencedAssemblies, ChildrenCompleted);

        public static readonly ImmutableHashSet<CompletionPart> NamedTypeSymbolWithLocationAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartBaseTypes, FinishBaseTypes, StartChildrenCreated, FinishChildrenCreated, Members, TypeMembers, StartProperties, FinishProperties);
        public static readonly ImmutableHashSet<CompletionPart> NamedTypeSymbolAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartBaseTypes, FinishBaseTypes, StartChildrenCreated, FinishChildrenCreated, Members, TypeMembers, StartProperties, FinishProperties, ChildrenCompleted);

        public static readonly ImmutableHashSet<CompletionPart> ImportsAll =
            CompletionPart.Combine(StartValidatingImports, FinishValidatingImports);

        public static readonly ImmutableHashSet<CompletionPart> NamespaceSymbolWithLocationAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartChildrenCreated, FinishChildrenCreated, Members, StartProperties, FinishProperties);
        public static readonly ImmutableHashSet<CompletionPart> NamespaceSymbolAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartChildrenCreated, FinishChildrenCreated, Members, StartProperties, FinishProperties, ChildrenCompleted);

        public static readonly ImmutableHashSet<CompletionPart> MemberSymbolWithLocationAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartChildrenCreated, FinishChildrenCreated, Members, StartProperties, FinishProperties);
        public static readonly ImmutableHashSet<CompletionPart> MemberSymbolAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartChildrenCreated, FinishChildrenCreated, Members, StartProperties, FinishProperties, ChildrenCompleted);

        public static readonly ImmutableHashSet<CompletionPart> LocalSymbolWithLocationAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartChildrenCreated, FinishChildrenCreated, StartProperties, FinishProperties);
        public static readonly ImmutableHashSet<CompletionPart> LocalSymbolAll =
            CompletionPart.Combine(StartCreated, FinishCreated, Attributes, StartChildrenCreated, FinishChildrenCreated, StartProperties, FinishProperties, ChildrenCompleted);

    }

    public sealed partial class CompletionGraphBuilder
    {
        public static CompletionGraphBuilder BuildDefaultGraph()
        {
            CompletionGraphBuilder builder = new CompletionGraphBuilder();
            builder.AddLast(CompletionGraph.StartCreated);
            builder.AddLast(CompletionGraph.FinishCreated);
            builder.AddLast(CompletionGraph.Attributes);
            builder.AddLast(CompletionGraph.StartAttributeChecks);
            builder.AddLast(CompletionGraph.FinishAttributeChecks);
            builder.AddLast(CompletionGraph.StartBaseTypes);
            builder.AddLast(CompletionGraph.FinishBaseTypes);
            builder.AddLast(CompletionGraph.StartChildrenCreated);
            builder.AddLast(CompletionGraph.FinishChildrenCreated);
            builder.AddLast(CompletionGraph.Members);
            builder.AddLast(CompletionGraph.TypeMembers);
            builder.AddLast(CompletionGraph.StartValidatingImports);
            builder.AddLast(CompletionGraph.FinishValidatingImports);
            builder.AddLast(CompletionGraph.AliasTarget);
            builder.AddLast(CompletionGraph.StartProperties);
            builder.AddLast(CompletionGraph.FinishProperties);
            builder.AddLast(CompletionGraph.ChildrenCompleted);
            builder.AddLast(CompletionGraph.StartCustomBinders);
            builder.AddLast(CompletionGraph.FinishCustomBinders);
            builder.AddLast(CompletionGraph.Module);
            builder.AddLast(CompletionGraph.StartValidatingAddedModules);
            builder.AddLast(CompletionGraph.FinishValidatingAddedModules);
            builder.AddLast(CompletionGraph.StartValidatingReferencedAssemblies);
            builder.AddLast(CompletionGraph.FinishValidatingReferencedAssemblies);
            return builder;
        }
        //*/
    }
}
