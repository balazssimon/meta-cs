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

        public static readonly CompletionPart None = new CompletionPart(nameof(None));
        public static readonly CompletionPart All = new CompletionPart(nameof(All));

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

        public static readonly CompletionPart MembersCompleted = new CompletionPart(nameof(MembersCompleted));

        //public static readonly CompletionPart StartProperties = new CompletionPart(nameof(StartProperties));
        //public static readonly CompletionPart FinishProperties = new CompletionPart(nameof(FinishProperties));

        //public static readonly CompletionPart StartBoundNode = new CompletionPart(nameof(StartBoundNode));
        //public static readonly CompletionPart FinishBoundNode = new CompletionPart(nameof(FinishBoundNode));

        public static readonly CompletionPart AliasTarget = new CompletionPart(nameof(AliasTarget));

        public static readonly ImmutableHashSet<CompletionPart> AssemblySymbolAll =
            Combine(StartCreated, FinishCreated, Attributes, StartAttributeChecks, FinishAttributeChecks, Module, StartValidatingAddedModules, FinishValidatingAddedModules);
        public static readonly ImmutableHashSet<CompletionPart> ModuleSymbolAll =
            Combine(StartCreated, FinishCreated, Attributes, StartValidatingReferencedAssemblies, FinishValidatingReferencedAssemblies, MembersCompleted);

        public static readonly ImmutableHashSet<CompletionPart> NamedTypeSymbolWithLocationAll =
            Combine(StartCreated, FinishCreated, Attributes, StartBaseTypes, FinishBaseTypes, StartChildrenCreated, FinishChildrenCreated, Members, TypeMembers, StartProperties, FinishProperties);
        public static readonly ImmutableHashSet<CompletionPart> NamedTypeSymbolAll = 
            Combine(StartCreated, FinishCreated, Attributes, StartBaseTypes, FinishBaseTypes, StartChildrenCreated, FinishChildrenCreated, Members, TypeMembers, StartProperties, FinishProperties, MembersCompleted);

        public static readonly ImmutableHashSet<CompletionPart> ImportsAll =
            Combine(StartValidatingImports, FinishValidatingImports);

        public static readonly ImmutableHashSet<CompletionPart> NamespaceSymbolWithLocationAll =
            Combine(StartCreated, FinishCreated, Attributes, StartChildrenCreated, FinishChildrenCreated, Members, StartProperties, FinishProperties);
        public static readonly ImmutableHashSet<CompletionPart> NamespaceSymbolAll =
            Combine(StartCreated, FinishCreated, Attributes, StartChildrenCreated, FinishChildrenCreated, Members, StartProperties, FinishProperties, MembersCompleted);


        internal static CompletionGraphBuilder ConstructDefaultCompletionGraph()
        {
            CompletionGraphBuilder builder = new CompletionGraphBuilder();
            builder.AddLast(CompletionPart.StartCreated);
            builder.AddLast(CompletionPart.FinishCreated);
            builder.AddLast(CompletionPart.Attributes);
            builder.AddLast(CompletionPart.StartAttributeChecks);
            builder.AddLast(CompletionPart.FinishAttributeChecks);
            builder.AddLast(CompletionPart.StartBaseTypes);
            builder.AddLast(CompletionPart.FinishBaseTypes);
            builder.AddLast(CompletionPart.StartChildrenCreated);
            builder.AddLast(CompletionPart.FinishChildrenCreated);
            builder.AddLast(CompletionPart.Members);
            builder.AddLast(CompletionPart.TypeMembers);
            builder.AddLast(CompletionPart.StartValidatingImports);
            builder.AddLast(CompletionPart.FinishValidatingImports);
            builder.AddLast(CompletionPart.AliasTarget);
            builder.AddLast(CompletionPart.StartProperties);
            builder.AddLast(CompletionPart.FinishProperties);
            builder.AddLast(CompletionPart.MembersCompleted);
            //builder.AddLast(CompletionPart.StartBoundNode);
            //builder.AddLast(CompletionPart.FinishBoundNode);
            //builder.AddLast(CompletionPart.StartProperties);
            //builder.AddLast(CompletionPart.FinishProperties);
            builder.AddLast(CompletionPart.Module);
            builder.AddLast(CompletionPart.StartValidatingAddedModules);
            builder.AddLast(CompletionPart.FinishValidatingAddedModules);
            builder.AddLast(CompletionPart.StartValidatingReferencedAssemblies);
            builder.AddLast(CompletionPart.FinishValidatingReferencedAssemblies);
            return builder;
        }
        //*/

    }

}
