﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceMemberSymbol : MemberSymbol, ISourceDeclarationSymbol
    {
        private readonly Symbol _container;
        protected readonly MergedDeclaration _declaration;

        private SymbolCompletionState _state;
        private ImmutableArray<Location> _locations;
        private Dictionary<string, ImmutableArray<Symbol>> _nameToMembersMap;
        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> _nameToTypeMembersMap;
        private ImmutableArray<Symbol> _lazyAllMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembersUnordered;

        private const int LazyAllMembersIsSorted = 0x1;   // Set if "lazyAllMembers" is sorted.
        private int _flags;

        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

        private MutableSymbolBase _modelObject;

        public SourceMemberSymbol(
            Symbol container,
            MergedDeclaration declaration,
            DiagnosticBag diagnostics)
        {
            Debug.Assert(declaration != null);
            _container = container;
            _declaration = declaration;

            if (declaration.Kind != null)
            {
                _modelObject = declaration.Kind.CreateMutable(container.ModelBuilder);
                Debug.Assert(_modelObject != null);
                if (_modelObject != null)
                {
                    _modelObject.MName = declaration.Name;
                    var parentObject = container?.ModelObject;
                    if (parentObject != null && !string.IsNullOrEmpty(declaration.ParentPropertyToAddTo))
                    {
                        var property = parentObject.MGetProperty(declaration.ParentPropertyToAddTo);
                        if (property != null)
                        {
                            parentObject.MAdd(property, _modelObject);
                        }
                    }
                }
            }

            foreach (var singleDeclaration in declaration.Declarations)
            {
                diagnostics.AddRange(singleDeclaration.Diagnostics);
            }
            _state = SymbolCompletionState.Create(container.ContainingModule.Language);
        }

        public override Language Language => _container.Language;

        internal protected override MutableModel ModelBuilder => _container.ModelBuilder;

        internal protected override MutableSymbolBase ModelObject => _modelObject;

        public override ModelSymbolInfo ModelSymbolInfo => _declaration.Kind;

        public MergedDeclaration MergedDeclaration => _declaration;

        public override Symbol ContainingSymbol => _container;

        public override AssemblySymbol ContainingAssembly => _container.ContainingAssembly;

        public override string Name => _declaration.Name;

        public override bool IsStatic => false;

        public override LexicalSortKey GetLexicalSortKey()
        {
            if (!_lazyLexicalSortKey.IsInitialized)
            {
                _lazyLexicalSortKey.SetFrom(_declaration.GetLexicalSortKey(this.DeclaringCompilation));
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
                        _declaration.NameLocations,
                        default);
                }

                return _locations;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;

        public virtual ImmutableArray<Symbol> GetDeclaredChildren()
        {
            return GetMembers();
        }

        /// <summary>
        /// Get a source symbol for the given declaration syntax.
        /// </summary>
        /// <returns>Null if there is no matching declaration.</returns>
        public Symbol GetSourceMember(SyntaxNodeOrToken syntax)
        {
            foreach (var member in GetMembers())
            {
                var memberT = member as Symbol;
                if ((object)memberT != null)
                {
                    if (syntax != null)
                    {
                        foreach (var loc in memberT.Locations)
                        {
                            if (loc.IsInSource && loc.SourceTree == syntax.SyntaxTree && syntax.Span.Equals(loc.SourceSpan))
                            {
                                return memberT;
                            }
                        }
                    }
                    else
                    {
                        return memberT;
                    }
                }
            }

            // None found.
            return null;
        }

        internal virtual ImmutableArray<Symbol> GetMembersUnordered()
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

        public virtual ImmutableArray<Symbol> GetMembers()
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

        public virtual ImmutableArray<Symbol> GetMembers(string name)
        {
            ImmutableArray<Symbol> members;
            return this.GetNameToMembersMap().TryGetValue(name, out members)
                ? members
                : ImmutableArray<Symbol>.Empty;
        }

        internal virtual ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            if (_lazyTypeMembersUnordered.IsDefault)
            {
                var members = this.GetNameToTypeMembersMap().Flatten();
                ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeMembersUnordered, members);
            }

            return _lazyTypeMembersUnordered;
        }

        public virtual ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return this.GetNameToTypeMembersMap().Flatten(LexicalOrderSymbolComparer.Instance);
        }

        public virtual ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            ImmutableArray<NamedTypeSymbol> members;
            return this.GetNameToTypeMembersMap().TryGetValue(name, out members)
                ? members
                : ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public virtual ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return GetTypeMembers(name).WhereAsArray(s => s.MetadataName == metadataName);
        }

        public override ModuleSymbol ContainingModule => _container.ContainingModule;

        private Dictionary<string, ImmutableArray<Symbol>> GetNameToMembersMap()
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

        private static Dictionary<string, ImmutableArray<NamedTypeSymbol>> GetTypesFromMemberMap(Dictionary<string, ImmutableArray<Symbol>> map)
        {
            var dictionary = new Dictionary<string, ImmutableArray<NamedTypeSymbol>>(StringOrdinalComparer.Instance);

            foreach (var kvp in map)
            {
                ImmutableArray<Symbol> members = kvp.Value;

                bool hasType = false;
                bool hasNamespace = false;

                foreach (var symbol in members)
                {
                    if (symbol.Kind == LanguageSymbolKind.NamedType)
                    {
                        hasType = true;
                        if (hasNamespace)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Debug.Assert(symbol.Kind == LanguageSymbolKind.Namespace);
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

        private Dictionary<string, ImmutableArray<Symbol>> MakeNameToMembersMap(DiagnosticBag diagnostics)
        {
            // NOTE: Even though the resulting map stores ImmutableArray<NamespaceOrTypeSymbol> as 
            // NOTE: values if the name is mapped into an array of named types, which is frequently 
            // NOTE: the case, we actually create an array of NamedTypeSymbol[] and wrap it in 
            // NOTE: ImmutableArray<NamespaceOrTypeSymbol>
            // NOTE: 
            // NOTE: This way we can save time and memory in GetNameToTypeMembersMap() -- when we see that
            // NOTE: a name maps into values collection containing types only instead of allocating another 
            // NOTE: array of NamedTypeSymbol[] we downcast the array to ImmutableArray<NamedTypeSymbol>

            var builder = new NameToSymbolMapBuilder(_declaration.Children.Length);
            foreach (var declaration in _declaration.Children)
            {
                //if (declaration.IsNamespace || declaration.IsType)
                {
                    builder.Add(BuildSymbol(declaration, diagnostics));
                }
            }

            var result = builder.CreateMap();

            CheckMembers(this, result, diagnostics);

            return result;
        }

        private static void CheckMembers(MemberSymbol @namespace, Dictionary<string, ImmutableArray<Symbol>> result, DiagnosticBag diagnostics)
        {
            var memberOfMetadataName = new Dictionary<string, Symbol>();
            MergedNamespaceSymbol mergedAssemblyNamespace = null;

            foreach (var name in result.Keys)
            {
                memberOfMetadataName.Clear();
                foreach (var symbol in result[name])
                {
                    var nts = symbol as NamedTypeSymbol;
                    var metadataName = ((object)nts != null) ? nts.MetadataName : string.Empty;

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

        protected virtual Symbol BuildSymbol(MergedDeclaration declaration, DiagnosticBag diagnostics)
        {
            if (declaration.IsName)
            {
                // TODO:MetaDslx - allow names in a namespace
                return new SourceMemberSymbol(this, declaration, diagnostics);
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
            // Check if any namespace declaration block intersects with the given tree/span.
            foreach (var declaration in _declaration.Declarations)
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

            public void Add(Symbol symbol)
            {
                string name = symbol.Name;
                object item;
                if (_dictionary.TryGetValue(name, out item))
                {
                    var builder = item as ArrayBuilder<Symbol>;
                    if (builder == null)
                    {
                        builder = ArrayBuilder<Symbol>.GetInstance();
                        builder.Add((Symbol)item);
                        _dictionary[name] = builder;
                    }
                    builder.Add(symbol);
                }
                else
                {
                    _dictionary[name] = symbol;
                }
            }

            public Dictionary<String, ImmutableArray<Symbol>> CreateMap()
            {
                var result = new Dictionary<String, ImmutableArray<Symbol>>(_dictionary.Count, StringOrdinalComparer.Instance);

                foreach (var kvp in _dictionary)
                {
                    object value = kvp.Value;
                    ImmutableArray<Symbol> members;

                    var builder = value as ArrayBuilder<Symbol>;
                    if (builder != null)
                    {
                        Debug.Assert(builder.Count > 1);
                        bool hasNamespaces = false;
                        for (int i = 0; (i < builder.Count) && !hasNamespaces; i++)
                        {
                            hasNamespaces |= (builder[i].Kind == LanguageSymbolKind.Namespace);
                        }

                        members = builder.ToImmutable();

                        builder.Free();
                    }
                    else
                    {
                        var symbol = (Symbol)value;
                        members = ImmutableArray.Create<Symbol>(symbol);
                    }

                    result.Add(kvp.Key, members);
                }

                return result;
            }
        }

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            // TODO:MetaDslx
            _state.NotePartComplete(CompletionPart.Attributes);
            return ImmutableArray<AttributeData>.Empty;
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
                if (incompletePart == CompletionPart.Attributes)
                {
                    GetAttributes();
                }
                else if (incompletePart == CompletionPart.NameToMembersMap)
                {
                    GetNameToMembersMap();
                }
                else if (incompletePart == CompletionPart.MembersCompleted)
                {
                    // ensure relevant imports are complete.
                    foreach (var declaration in _declaration.Declarations)
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
