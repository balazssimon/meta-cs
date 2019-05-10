// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceNamespaceSymbol : NamespaceSymbol
    {
        private readonly SourceModuleSymbol _module;
        private readonly Symbol _container;
        private readonly MergedDeclaration _mergedDeclaration;

        private SymbolCompletionState _state;
        private ImmutableArray<Location> _locations;
        private Dictionary<string, ImmutableArray<NamespaceOrTypeSymbol>> _nameToMembersMap;
        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> _nameToTypeMembersMap;
        private ImmutableArray<Symbol> _lazyAllMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembersUnordered;

        private const int LazyAllMembersIsSorted = 0x1;   // Set if "lazyAllMembers" is sorted.
        private int _flags;

        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

        public SourceNamespaceSymbol(
            SourceModuleSymbol module, 
            Symbol container,
            MergedDeclaration mergedDeclaration,
            DiagnosticBag diagnostics)
        {
            Debug.Assert(mergedDeclaration != null);
            _module = module;
            _container = container;
            _mergedDeclaration = mergedDeclaration;

            foreach (var singleDeclaration in mergedDeclaration.Declarations)
            {
                diagnostics.AddRange(singleDeclaration.Diagnostics);
            }
        }

        public override ModelSymbolInfo ModelSymbolInfo => _mergedDeclaration.Kind;

        public MergedDeclaration MergedDeclaration => _mergedDeclaration;

        public override Symbol ContainingSymbol => _container;

        public override AssemblySymbol ContainingAssembly => _module.ContainingAssembly;

        internal IEnumerable<Imports> GetBoundImportsMerged()
        {
            var compilation = this.DeclaringCompilation;
            foreach (var declaration in _mergedDeclaration.Declarations)
            {
                if (declaration.HasUsings || declaration.HasExternAliases)
                {
                    yield return compilation.GetImports(declaration);
                }
            }
        }

        public override string Name => _mergedDeclaration.Name;

        public override LexicalSortKey GetLexicalSortKey()
        {
            if (!_lazyLexicalSortKey.IsInitialized)
            {
                _lazyLexicalSortKey.SetFrom(_mergedDeclaration.GetLexicalSortKey(this.DeclaringCompilation));
            }
            return _lazyLexicalSortKey;
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                if (_locations.IsDefault)
                {
                    ImmutableInterlocked.InterlockedCompareExchange(ref _locations,
                        _mergedDeclaration.NameLocations,
                        default);
                }

                return _locations;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _mergedDeclaration.SyntaxReferences;

        internal override ImmutableArray<Symbol> GetMembersUnordered()
        {
            var result = _lazyAllMembers;

            if (result.IsDefault)
            {
                var members = StaticCast<Symbol>.From(this.GetNameToMembersMap().Flatten(null));  // don't sort.
                ImmutableInterlocked.InterlockedInitialize(ref _lazyAllMembers, members);
                result = _lazyAllMembers;
            }

            return result.ConditionallyDeOrder();
        }

        public override ImmutableArray<Symbol> GetMembers()
        {
            if ((_flags & LazyAllMembersIsSorted) != 0)
            {
                return _lazyAllMembers;
            }
            else
            {
                var allMembers = this.GetMembersUnordered();

                if (allMembers.Length >= 2)
                {
                    // The array isn't sorted. Sort it and remember that we sorted it.
                    allMembers = allMembers.Sort(LexicalOrderSymbolComparer.Instance);
                    ImmutableInterlocked.InterlockedExchange(ref _lazyAllMembers, allMembers);
                }

                ThreadSafeFlagOperations.Set(ref _flags, LazyAllMembersIsSorted);
                return allMembers;
            }
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            ImmutableArray<NamespaceOrTypeSymbol> members;
            return this.GetNameToMembersMap().TryGetValue(name, out members)
                ? members.Cast<NamespaceOrTypeSymbol, Symbol>()
                : ImmutableArray<Symbol>.Empty;
        }

        internal override ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            if (_lazyTypeMembersUnordered.IsDefault)
            {
                var members = this.GetNameToTypeMembersMap().Flatten();
                ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeMembersUnordered, members);
            }

            return _lazyTypeMembersUnordered;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return this.GetNameToTypeMembersMap().Flatten(LexicalOrderSymbolComparer.Instance);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            ImmutableArray<NamedTypeSymbol> members;
            return this.GetNameToTypeMembersMap().TryGetValue(name, out members)
                ? members
                : ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return GetTypeMembers(name).WhereAsArray(s => s.MetadataName == metadataName);
        }

        public override ModuleSymbol ContainingModule => _module;

        public override NamespaceExtent Extent => new NamespaceExtent(_module);

        private Dictionary<string, ImmutableArray<NamespaceOrTypeSymbol>> GetNameToMembersMap()
        {
            if (_nameToMembersMap == null)
            {
                var diagnostics = DiagnosticBag.GetInstance();
                if (Interlocked.CompareExchange(ref _nameToMembersMap, MakeNameToMembersMap(diagnostics), null) == null)
                {
                    // NOTE: the following is not cancellable.  Once we've set the
                    // members, we *must* do the following to make sure we're in a consistent state.
                    this.DeclaringCompilation.DeclarationDiagnostics.AddRange(diagnostics);
                    RegisterDeclaredCorTypes();

                    // We may produce a SymbolDeclaredEvent for the enclosing namespace before events for its contained members
                    DeclaringCompilation.SymbolDeclaredEvent(this);
                    var wasSetThisThread = _state.NotePartComplete(CompletionPart.NameToMembersMap);
                    Debug.Assert(wasSetThisThread);
                }

                diagnostics.Free();
            }

            return _nameToMembersMap;
        }

        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> GetNameToTypeMembersMap()
        {
            if (_nameToTypeMembersMap == null)
            {
                // NOTE: This method depends on MakeNameToMembersMap() on creating a proper 
                // NOTE: type of the array, see comments in MakeNameToMembersMap() for details
                Interlocked.CompareExchange(ref _nameToTypeMembersMap, GetTypesFromMemberMap(GetNameToMembersMap()), null);
            }
            return _nameToTypeMembersMap;
        }

        private static Dictionary<string, ImmutableArray<NamedTypeSymbol>> GetTypesFromMemberMap(Dictionary<string, ImmutableArray<NamespaceOrTypeSymbol>> map)
        {
            var dictionary = new Dictionary<string, ImmutableArray<NamedTypeSymbol>>(StringOrdinalComparer.Instance);

            foreach (var kvp in map)
            {
                ImmutableArray<NamespaceOrTypeSymbol> members = kvp.Value;

                bool hasType = false;
                bool hasNamespace = false;

                foreach (var symbol in members)
                {
                    if (symbol.Kind == SymbolKind.NamedType)
                    {
                        hasType = true;
                        if (hasNamespace)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Debug.Assert(symbol.Kind == SymbolKind.Namespace);
                        hasNamespace = true;
                        if (hasType)
                        {
                            break;
                        }
                    }
                }

                if (hasType)
                {
                    if (hasNamespace)
                    {
                        dictionary.Add(kvp.Key, members.OfType<NamedTypeSymbol>().AsImmutable());
                    }
                    else
                    {
                        dictionary.Add(kvp.Key, members.As<NamedTypeSymbol>());
                    }
                }
            }

            return dictionary;
        }

        private Dictionary<string, ImmutableArray<NamespaceOrTypeSymbol>> MakeNameToMembersMap(DiagnosticBag diagnostics)
        {
            // NOTE: Even though the resulting map stores ImmutableArray<NamespaceOrTypeSymbol> as 
            // NOTE: values if the name is mapped into an array of named types, which is frequently 
            // NOTE: the case, we actually create an array of NamedTypeSymbol[] and wrap it in 
            // NOTE: ImmutableArray<NamespaceOrTypeSymbol>
            // NOTE: 
            // NOTE: This way we can save time and memory in GetNameToTypeMembersMap() -- when we see that
            // NOTE: a name maps into values collection containing types only instead of allocating another 
            // NOTE: array of NamedTypeSymbol[] we downcast the array to ImmutableArray<NamedTypeSymbol>

            var builder = new NameToSymbolMapBuilder(_mergedDeclaration.Children.Length);
            foreach (var declaration in _mergedDeclaration.Children)
            {
                builder.Add(BuildSymbol(declaration, diagnostics));
            }

            var result = builder.CreateMap();

            CheckMembers(this, result, diagnostics);

            return result;
        }

        private static void CheckMembers(NamespaceSymbol @namespace, Dictionary<string, ImmutableArray<NamespaceOrTypeSymbol>> result, DiagnosticBag diagnostics)
        {
            var memberOfMetadataName = new Dictionary<string, Symbol>();
            MergedNamespaceSymbol mergedAssemblyNamespace = null;

            if (@namespace.ContainingAssembly.Modules.Length > 1)
            {
                mergedAssemblyNamespace = @namespace.ContainingAssembly.GetAssemblyNamespace(@namespace) as MergedNamespaceSymbol;
            }

            foreach (var name in result.Keys)
            {
                memberOfMetadataName.Clear();
                foreach (var symbol in result[name])
                {
                    var nts = symbol as NamedTypeSymbol;
                    var metadataName = ((object)nts != null) ? nts.MetadataName : null;

                    if (memberOfMetadataName.TryGetValue(metadataName, out Symbol other))
                    {
                        if ((nts as SourceNamedTypeSymbol)?.IsPartial == true && (other as SourceNamedTypeSymbol)?.IsPartial == true)
                        {
                            diagnostics.Add(InternalErrorCode.ERR_PartialTypeKindConflict, symbol.Locations.FirstOrNone(), symbol);
                        }
                        else
                        {
                            diagnostics.Add(InternalErrorCode.ERR_DuplicateNameInNS, symbol.Locations.FirstOrNone(), name, @namespace);
                        }
                        memberOfMetadataName[metadataName] = symbol;
                    }
                    else if ((object)mergedAssemblyNamespace != null)
                    {
                        // Check for collision with declarations from added modules.
                        foreach (NamespaceSymbol constituent in mergedAssemblyNamespace.ConstituentNamespaces)
                        {
                            if ((object)constituent != (object)@namespace)
                            {
                                // For whatever reason native compiler only detects conflicts against types.
                                // It doesn't complain when source declares a type with the same name as 
                                // a namespace in added module, but complains when source declares a namespace 
                                // with the same name as a type in added module.
                                var types = constituent.GetTypeMembers(symbol.Name, metadataName);

                                if (types.Length > 0)
                                {
                                    other = types[0];
                                    // Since the error doesn't specify what added module this type belongs to, we can stop searching
                                    // at the first match.
                                    break;
                                }
                            }
                        }
                        memberOfMetadataName.Add(metadataName, symbol);
                    }
                    else
                    {
                        memberOfMetadataName.Add(metadataName, symbol);
                    }
                }
            }
        }

        protected virtual NamespaceOrTypeSymbol BuildSymbol(MergedDeclaration declaration, DiagnosticBag diagnostics)
        {
            if (declaration.IsNamespace)
            {
                return new SourceNamespaceSymbol(_module, this, declaration, diagnostics);
            }
            else if (declaration.IsType)
            {
                // TODO:MetaDslx
                /*if (declaration.IsImplicit) return new ImplicitNamedTypeSymbol(this, (MergedTypeDeclaration)declaration, diagnostics);
                else*/ return new SourceNamedTypeSymbol(this, declaration, diagnostics);
            }
            else if (declaration.IsName)
            {
                // TODO:MetaDslx - allow names in a namespace
                //return new SourceMemberSymbol(this, declaration, diagnostics);
            }
            throw ExceptionUtilities.UnexpectedValue(declaration.Kind);
        }

        /// <summary>
        /// Register COR types declared in this namespace, if any, in the COR types cache.
        /// </summary>
        private void RegisterDeclaredCorTypes()
        {
            AssemblySymbol containingAssembly = ContainingAssembly;

            if (containingAssembly.KeepLookingForDeclaredSpecialTypes)
            {
                // Register newly declared COR types
                foreach (var array in _nameToMembersMap.Values)
                {
                    foreach (var member in array)
                    {
                        var type = member as NamedTypeSymbol;

                        if ((object)type != null && type.SpecialType != SpecialType.None)
                        {
                            containingAssembly.RegisterDeclaredSpecialType(type);

                            if (!containingAssembly.KeepLookingForDeclaredSpecialTypes)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }

        public override bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.IsGlobalNamespace)
            {
                return true;
            }

            // Check if any namespace declaration block intersects with the given tree/span.
            foreach (var declaration in _mergedDeclaration.Declarations)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var declarationSyntaxRef = declaration.SyntaxReference;
                if (declarationSyntaxRef.SyntaxTree != tree)
                {
                    continue;
                }

                if (!definedWithinSpan.HasValue)
                {
                    return true;
                }

                var syntax = declarationSyntaxRef.GetSyntax(cancellationToken);
                if (syntax.FullSpan.IntersectsWith(definedWithinSpan.Value))
                {
                    return true;
                }
            }

            return false;
        }

        private struct NameToSymbolMapBuilder
        {
            private readonly Dictionary<string, object> _dictionary;

            public NameToSymbolMapBuilder(int capacity)
            {
                _dictionary = new Dictionary<string, object>(capacity, StringOrdinalComparer.Instance);
            }

            public void Add(NamespaceOrTypeSymbol symbol)
            {
                string name = symbol.Name;
                object item;
                if (_dictionary.TryGetValue(name, out item))
                {
                    var builder = item as ArrayBuilder<NamespaceOrTypeSymbol>;
                    if (builder == null)
                    {
                        builder = ArrayBuilder<NamespaceOrTypeSymbol>.GetInstance();
                        builder.Add((NamespaceOrTypeSymbol)item);
                        _dictionary[name] = builder;
                    }
                    builder.Add(symbol);
                }
                else
                {
                    _dictionary[name] = symbol;
                }
            }

            public Dictionary<String, ImmutableArray<NamespaceOrTypeSymbol>> CreateMap()
            {
                var result = new Dictionary<String, ImmutableArray<NamespaceOrTypeSymbol>>(_dictionary.Count, StringOrdinalComparer.Instance);

                foreach (var kvp in _dictionary)
                {
                    object value = kvp.Value;
                    ImmutableArray<NamespaceOrTypeSymbol> members;

                    var builder = value as ArrayBuilder<NamespaceOrTypeSymbol>;
                    if (builder != null)
                    {
                        Debug.Assert(builder.Count > 1);
                        bool hasNamespaces = false;
                        for (int i = 0; (i < builder.Count) && !hasNamespaces; i++)
                        {
                            hasNamespaces |= (builder[i].Kind == SymbolKind.Namespace);
                        }

                        members = hasNamespaces
                            ? builder.ToImmutable()
                            : StaticCast<NamespaceOrTypeSymbol>.From(builder.ToDowncastedImmutable<NamedTypeSymbol>());

                        builder.Free();
                    }
                    else
                    {
                        NamespaceOrTypeSymbol symbol = (NamespaceOrTypeSymbol)value;
                        members = symbol.Kind == SymbolKind.Namespace
                            ? ImmutableArray.Create<NamespaceOrTypeSymbol>(symbol)
                            : StaticCast<NamespaceOrTypeSymbol>.From(ImmutableArray.Create<NamedTypeSymbol>((NamedTypeSymbol)symbol));
                    }

                    result.Add(kvp.Key, members);
                }

                return result;
            }
        }

        #region completion

        public sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        public override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionPart.NameToMembersMap)
                {
                    GetNameToMembersMap();
                }
                else if (incompletePart == CompletionPart.MembersCompleted)
                {
                    // ensure relevant imports are complete.
                    foreach (var declaration in _mergedDeclaration.Declarations)
                    {
                        if (locationOpt == null || locationOpt.SourceTree == declaration.SyntaxReference.SyntaxTree)
                        {
                            if (declaration.HasUsings || declaration.HasExternAliases)
                            {
                                this.DeclaringCompilation.GetImports(declaration).Complete(cancellationToken);
                            }
                        }
                    }

                    var members = this.GetMembers();

                    bool allCompleted = true;

                    if (this.DeclaringCompilation.Options.ConcurrentBuild)
                    {
                        var po = cancellationToken.CanBeCanceled
                            ? new ParallelOptions() { CancellationToken = cancellationToken }
                            : LanguageCompilation.DefaultParallelOptions;

                        Parallel.For(0, members.Length, po, UICultureUtilities.WithCurrentUICulture<int>(i =>
                        {
                            var member = members[i];
                            ForceCompleteMemberByLocation(locationOpt, member, cancellationToken);
                        }));

                        foreach (var member in members)
                        {
                            if (!member.HasComplete(CompletionPart.All))
                            {
                                allCompleted = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var member in members)
                        {
                            ForceCompleteMemberByLocation(locationOpt, member, cancellationToken);
                            allCompleted = allCompleted && member.HasComplete(CompletionPart.All);
                        }
                    }

                    if (allCompleted)
                    {
                        _state.NotePartComplete(CompletionPart.MembersCompleted);
                    }
                    else
                    {
                        // NOTE: we're going to kick out of the completion part loop after this,
                        // so not making progress isn't a problem.
                        goto done;
                    }
                }
                else if (incompletePart == null)
                {
                    return;
                }
                else
                {
                    // This assert will trigger if we forgot to handle any of the completion parts
                    Debug.Assert(!CompletionPart.NamespaceSymbolAll.Contains(incompletePart));
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }

        done:
            // Don't return until we've seen all of the CompletionParts. This ensures all
            // diagnostics have been reported (not necessarily on this thread).
            var allParts = (locationOpt == null) ? CompletionPart.NamespaceSymbolAll : CompletionPart.NamespaceSymbolWithLocationAll;
            _state.SpinWaitComplete(allParts, cancellationToken);
        }

        public override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        #endregion
    }
}
