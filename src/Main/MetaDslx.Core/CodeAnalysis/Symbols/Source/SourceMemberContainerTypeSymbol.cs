// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    /// <summary>
    /// Represents a named type symbol whose members are declared in source.
    /// </summary>
    public abstract class SourceMemberContainerTypeSymbol : NamedTypeSymbol, ISourceDeclarationSymbol
    {
        private readonly NamespaceOrTypeSymbol _containingSymbol;
        protected readonly MergedDeclaration _declaration;
        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

        private Members _lazyMembers;
        private Dictionary<string, ImmutableArray<Symbol>> _lazyMembersDictionary;
        private ImmutableArray<Symbol> _lazyMembersFlattened;
        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> _lazyTypeMembers;

        private static readonly Dictionary<string, ImmutableArray<NamedTypeSymbol>> s_emptyTypeMembers = new Dictionary<string, ImmutableArray<NamedTypeSymbol>>(EmptyComparer.Instance);

        private int _flattenedMembersIsSorted = 0;
        private SymbolCompletionState _state;

        private MutableSymbolBase _modelObject;

        public SourceMemberContainerTypeSymbol(
            NamespaceOrTypeSymbol containingSymbol,
            MergedDeclaration declaration,
            DiagnosticBag diagnostics)
        {
            _containingSymbol = containingSymbol;
            _declaration = declaration;
            _declaration.DangerousSetSourceSymbol(this);

            _modelObject = declaration.Kind.CreateMutable(this.ModelBuilder);
            Debug.Assert(_modelObject != null);
            if (_modelObject != null)
            {
                ((SourceModuleSymbol)containingSymbol.ContainingModule).MetaSymbolMap.RegisterSymbol(_modelObject, this);
                _modelObject.MName = declaration.Name;
                var parentObject = containingSymbol?.ModelObject as MutableSymbolBase;
                if (parentObject != null && !string.IsNullOrEmpty(declaration.ParentPropertyToAddTo))
                {
                    var property = parentObject.MGetProperty(declaration.ParentPropertyToAddTo);
                    parentObject.MAdd(property, _modelObject);
                }
            }

            foreach (var singleDeclaration in declaration.Declarations)
            {
                diagnostics.AddRange(singleDeclaration.Diagnostics);
            }
            _state = SymbolCompletionState.Create(containingSymbol.Language);
        }

        public override Language Language => _containingSymbol.Language;

        public override LanguageTypeKind TypeKind => LanguageTypeKind.NamedType;

        internal protected override MutableModel ModelBuilder => this.ContainingModule.ModelBuilder;

        public override IMetaSymbol ModelObject => _modelObject;

        public override ModelSymbolInfo ModelSymbolInfo => _declaration.Kind;

        public MergedDeclaration MergedDeclaration => _declaration;

        public virtual bool IsPartial => _declaration.CanMerge;

        private SpecialType MakeSpecialType()
        {
            // check if this is one of the COR library types
            if (ContainingSymbol.Kind == LanguageSymbolKind.Namespace &&
                ContainingSymbol.ContainingAssembly.KeepLookingForDeclaredSpecialTypes)
            {
                //for a namespace, the emitted name is a dot-separated list of containing namespaces
                var emittedName = ContainingSymbol.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat);
                emittedName = MetadataHelpers.BuildQualifiedName(emittedName, MetadataName);

                return SpecialTypes.GetTypeFromMetadataName(emittedName);
            }
            else
            {
                return SpecialType.None;
            }
        }

        #region Containers

        public sealed override NamedTypeSymbol ContainingType => _containingSymbol as NamedTypeSymbol;

        public sealed override Symbol ContainingSymbol => _containingSymbol;

        #endregion

        #region Syntax

        public override bool IsScript => _declaration.IsScript;

        public override bool IsSubmission => _declaration.IsSubmission;

        public override bool IsImplicit => _declaration.IsImplicit;

        public override bool IsImplicitlyDeclared
        {
            get
            {
                return IsImplicit || IsScript || IsSubmission;
            }
        }

        public override string MetadataName => _declaration.MetadataName;

        public override string Name => _declaration.Name;

        public override bool MangleName => _declaration.Name != _declaration.MetadataName;

        public override LexicalSortKey GetLexicalSortKey()
        {
            if (!_lazyLexicalSortKey.IsInitialized)
            {
                _lazyLexicalSortKey.SetFrom(_declaration.GetLexicalSortKey(this.DeclaringCompilation));
            }
            return _lazyLexicalSortKey;
        }

        public override ImmutableArray<Location> Locations => _declaration.NameLocations;

        public ImmutableArray<SyntaxReference> SyntaxReferences => _declaration.SyntaxReferences;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => SyntaxReferences;

        // This method behaves the same was as the base class, but avoids allocations associated with DeclaringSyntaxReferences
        public override bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken)
        {
            var declarations = _declaration.Declarations;
            if (IsImplicitlyDeclared && declarations.IsEmpty)
            {
                return ContainingSymbol.IsDefinedInSourceTree(tree, definedWithinSpan, cancellationToken);
            }

            foreach (var declaration in declarations)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var syntaxRef = declaration.SyntaxReference;
                if (syntaxRef.SyntaxTree == tree &&
                    (!definedWithinSpan.HasValue || syntaxRef.Span.IntersectsWith(definedWithinSpan.Value)))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Members

        /// <summary>
        /// Encapsulates information about the non-type members of a (i.e. this) type.
        ///   1) For non-initializers, symbols are created and stored in a list.
        ///   2) For fields and properties, the symbols are stored in (1) and their initializers are
        ///      stored with other initialized fields and properties from the same syntax tree with
        ///      the same static-ness.
        ///   3) For indexers, syntax (weak) references are stored for later binding.
        /// </summary>
        /// <remarks>
        /// CONSIDER: most types won't have indexers, so we could move the indexer list
        /// into a subclass to spare most instances the space required for the field.
        /// </remarks>
        private sealed class Members
        {
            internal readonly ImmutableArray<NamedTypeSymbol> TypeMembers;
            internal readonly ImmutableArray<Symbol> NonTypeMembers;

            public Members(ImmutableArray<NamedTypeSymbol> typeMembers, ImmutableArray<Symbol> nonTypeMembers)
            {
                Debug.Assert(!typeMembers.IsDefault);
                Debug.Assert(!nonTypeMembers.IsDefault);
                Debug.Assert(!nonTypeMembers.Any(s => s is ITypeSymbol));
                this.TypeMembers = typeMembers;
                this.NonTypeMembers = nonTypeMembers;
            }
        }

        public override IEnumerable<string> MemberNames
        {
            get { return _declaration.ChildNames; }
        }

        internal override ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            return GetTypeMembersDictionary().Flatten();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return GetTypeMembersDictionary().Flatten(LexicalOrderSymbolComparer.Instance);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            ImmutableArray<NamedTypeSymbol> members;
            if (GetTypeMembersDictionary().TryGetValue(name, out members))
            {
                return members;
            }

            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return GetTypeMembers(name).WhereAsArray(t => t.MetadataName == metadataName);
        }

        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> GetTypeMembersDictionary()
        {
            if (_lazyTypeMembers == null)
            {
                var diagnostics = DiagnosticBag.GetInstance();
                if (Interlocked.CompareExchange(ref _lazyTypeMembers, MakeTypeMembers(diagnostics), null) == null)
                {
                    AddDeclarationDiagnostics(diagnostics);

                    _state.NotePartComplete(CompletionPart.TypeMembers);
                }

                diagnostics.Free();
            }

            return _lazyTypeMembers;
        }

        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> MakeTypeMembers(DiagnosticBag diagnostics)
        {
            var symbols = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            var conflictDict = new Dictionary<(string, string), SourceNamedTypeSymbol>();
            try
            {
                foreach (var childDeclaration in _declaration.Children)
                {
                    if (childDeclaration.IsType)
                    {
                        var t = new SourceNamedTypeSymbol(this, childDeclaration, diagnostics);
                        this.CheckMemberNameDistinctFromType(t, diagnostics);

                        var key = (t.Name, t.MetadataName);
                        SourceNamedTypeSymbol other;
                        if (conflictDict.TryGetValue(key, out other))
                        {
                            if (Locations.Length == 1 || IsPartial)
                            {
                                if (t.IsPartial && other.IsPartial)
                                {
                                    diagnostics.Add(InternalErrorCode.ERR_PartialTypeKindConflict, t.Locations[0], t);
                                }
                                else
                                {
                                    diagnostics.Add(InternalErrorCode.ERR_DuplicateNameInClass, t.Locations[0], this, t.Name);
                                }
                            }
                        }
                        else
                        {
                            conflictDict.Add(key, t);
                        }

                        symbols.Add(t);
                    }
                }

                Debug.Assert(s_emptyTypeMembers.Count == 0);
                return symbols.Count > 0 ?
                    symbols.ToDictionary(s => s.Name, StringOrdinalComparer.Instance) :
                    s_emptyTypeMembers;
            }
            finally
            {
                symbols.Free();
            }
        }

        private void CheckMemberNameDistinctFromType(Symbol member, DiagnosticBag diagnostics)
        {
            if (member.Name == this.Name)
            {
                diagnostics.Add(InternalErrorCode.ERR_MemberNameSameAsType, member.Locations[0], this.Name);
            }
        }

        internal override ImmutableArray<Symbol> GetMembersUnordered()
        {
            var result = _lazyMembersFlattened;

            if (result.IsDefault)
            {
                result = GetMembersByName().Flatten(null);  // do not sort.
                ImmutableInterlocked.InterlockedInitialize(ref _lazyMembersFlattened, result);
                result = _lazyMembersFlattened;
            }

            return result.ConditionallyDeOrder();
        }

        public virtual ImmutableArray<Symbol> GetDeclaredChildren()
        {
            return GetMembers();
        }

        public override ImmutableArray<Symbol> GetMembers()
        {
            if (_flattenedMembersIsSorted != 0)
            {
                return _lazyMembersFlattened;
            }
            else
            {
                var allMembers = this.GetMembersUnordered();

                if (allMembers.Length > 1)
                {
                    // The array isn't sorted. Sort it and remember that we sorted it.
                    allMembers = allMembers.Sort(LexicalOrderSymbolComparer.Instance);
                    ImmutableInterlocked.InterlockedExchange(ref _lazyMembersFlattened, allMembers);
                }

                Interlocked.Exchange(ref _flattenedMembersIsSorted, 1);
                return allMembers;
            }
        }

        public sealed override ImmutableArray<Symbol> GetMembers(string name)
        {
            ImmutableArray<Symbol> members;
            if (GetMembersByName().TryGetValue(name, out members))
            {
                return members;
            }

            return ImmutableArray<Symbol>.Empty;
        }

        public override ImmutableArray<Symbol> GetMembers(string name, string metadataName)
        {
            return this.GetMembers(name).WhereAsArray(m => m.MetadataName == metadataName);
        }

        public override ImmutableArray<Symbol> GetNonTypeMembers(string name)
        {
            if (_lazyMembersDictionary != null || _declaration.ChildNames.Contains(name))
            {
                return GetMembers(name);
            }

            return ImmutableArray<Symbol>.Empty;
        }

        // NOTE: this method should do as little work as possible
        //       we often need to get members just to do a lookup.
        //       All additional checks and diagnostics may be not
        //       needed yet or at all.
        private Members GetMembersForLookup()
        {
            var membersAndInitializers = _lazyMembers;
            if (membersAndInitializers != null)
            {
                return membersAndInitializers;
            }

            var diagnostics = DiagnosticBag.GetInstance();
            var members = BuildMembersAndInitializers(diagnostics);

            var alreadyKnown = Interlocked.CompareExchange(ref _lazyMembers, members, null);
            if (alreadyKnown != null)
            {
                diagnostics.Free();
                return alreadyKnown;
            }

            AddDeclarationDiagnostics(diagnostics);
            diagnostics.Free();

            return _lazyMembers;
        }

        protected Dictionary<string, ImmutableArray<Symbol>> GetMembersByName()
        {
            if (_state.HasComplete(CompletionPart.Members))
            {
                return _lazyMembersDictionary;
            }

            return GetMembersByNameSlow();
        }

        private Dictionary<string, ImmutableArray<Symbol>> GetMembersByNameSlow()
        {
            if (_lazyMembersDictionary == null)
            {
                var diagnostics = DiagnosticBag.GetInstance();
                var membersDictionary = MakeAllMembers(diagnostics);
                if (Interlocked.CompareExchange(ref _lazyMembersDictionary, membersDictionary, null) == null)
                {
                    var memberNames = ArrayBuilder<string>.GetInstance(membersDictionary.Count);
                    memberNames.AddRange(membersDictionary.Keys);
                    MergePartialMembers(memberNames, membersDictionary, diagnostics);
                    memberNames.Free();
                    AddDeclarationDiagnostics(diagnostics);
                    _state.NotePartComplete(CompletionPart.Members);
                }

                diagnostics.Free();
            }

            _state.SpinWaitComplete(CompletionPart.Members, default(CancellationToken));
            return _lazyMembersDictionary;
        }

        public override ImmutableArray<Symbol> GetInstanceMembers()
        {
            var members = this.GetMembersForLookup();
            return members.NonTypeMembers.WhereAsArray(IsInstanceMember);
        }

        public override ImmutableArray<Symbol> GetStaticMembers()
        {
            var members = this.GetMembersForLookup();
            return members.NonTypeMembers.WhereAsArray(IsStaticMember);
        }

        protected virtual void AfterMembersChecks(DiagnosticBag diagnostics)
        {
            // TODO:MetaDslx - check declaration semantics
        }

        private Dictionary<string, ImmutableArray<Symbol>> MakeAllMembers(DiagnosticBag diagnostics)
        {
            var membersAndInitializers = GetMembersForLookup(); //NOTE: separately cached
            var membersByName = membersAndInitializers.NonTypeMembers.ToDictionaryWithImmutableArray(s => s.Name);
            AddNestedTypesToDictionary(membersByName, GetTypeMembersDictionary());
            return membersByName;
        }

        /// <summary>
        /// Merge (already ordered) members with other (already ordered) members.
        /// </summary>
        private static Dictionary<string, ImmutableArray<Symbol>> MergeMembers(ImmutableArray<Symbol> left, ArrayBuilder<Symbol> right)
        {
            int leftCount = left.Length;
            int rightCount = right.Count;

            var merged = ArrayBuilder<Symbol>.GetInstance(leftCount + rightCount);

            int leftPos = 0;
            int rightPos = 0;

            while (leftPos < leftCount && rightPos < rightCount)
            {
                var leftMember = left[leftPos];
                var rightMember = right[rightPos];
                if (LexicalOrderSymbolComparer.Instance.Compare(leftMember, rightMember) < 0)
                {
                    merged.Add(leftMember);
                    leftPos++;
                }
                else
                {
                    merged.Add(rightMember);
                    rightPos++;
                }
            }

            for (; leftPos < leftCount; leftPos++)
            {
                merged.Add(left[leftPos]);
            }

            for (; rightPos < rightCount; rightPos++)
            {
                merged.Add(right[rightPos]);
            }

            var membersByName = merged.ToDictionary(s => s.Name, StringOrdinalComparer.Instance);
            merged.Free();

            return membersByName;
        }

        private static void AddNestedTypesToDictionary(Dictionary<string, ImmutableArray<Symbol>> membersByName, Dictionary<string, ImmutableArray<NamedTypeSymbol>> typesByName)
        {
            foreach (var pair in typesByName)
            {
                string name = pair.Key;
                ImmutableArray<NamedTypeSymbol> types = pair.Value;
                ImmutableArray<Symbol> typesAsSymbols = StaticCast<Symbol>.From(types);

                ImmutableArray<Symbol> membersForName;
                if (membersByName.TryGetValue(name, out membersForName))
                {
                    membersByName[name] = membersForName.Concat(typesAsSymbols);
                }
                else
                {
                    membersByName.Add(name, typesAsSymbols);
                }
            }
        }

        private class MembersBuilder
        {
            public readonly ArrayBuilder<NamedTypeSymbol> TypeMembers = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            public readonly ArrayBuilder<Symbol> NonTypeMembers = ArrayBuilder<Symbol>.GetInstance();

            public Members ToReadOnlyAndFree()
            {
                return new Members(TypeMembers.ToImmutableAndFree(), NonTypeMembers.ToImmutableAndFree());
            }

            public void Free()
            {
                TypeMembers.Free();
                NonTypeMembers.Free();
            }
        }

        private Members BuildMembersAndInitializers(DiagnosticBag diagnostics)
        {
            var builder = new MembersBuilder();
            AddDeclaredTypeMembers(builder.TypeMembers, diagnostics);
            AddDeclaredNonTypeMembers(builder.NonTypeMembers, diagnostics);
            AddTypeMembers(builder.TypeMembers, diagnostics);
            AddNonTypeMembers(builder.NonTypeMembers, diagnostics);

            // We already built the members and initializers on another thread, we might have detected that condition
            // during member building on this thread and bailed, which results in incomplete data in the builder.
            // In such case we have to avoid creating the instance of MemberAndInitializers since it checks the consistency
            // of the data in the builder and would fail in an assertion if we tried to construct it from incomplete builder.
            if (_lazyMembers != null)
            {
                builder.Free();
                return null;
            }

            return builder.ToReadOnlyAndFree();
        }

        protected virtual NamedTypeSymbol BuildTypeSymbol(MergedDeclaration declaration, DiagnosticBag diagnostics)
        {
            Debug.Assert(declaration.IsType);
            return new SourceNamedTypeSymbol(this, declaration, diagnostics);
        }

        protected virtual NamespaceSymbol BuildNamespaceSymbol(MergedDeclaration declaration, DiagnosticBag diagnostics)
        {
            Debug.Assert(declaration.IsNamespace);
            return new SourceNamespaceSymbol((SourceModuleSymbol)this.ContainingModule, this, declaration, diagnostics);
        }

        protected virtual Symbol BuildSymbol(MergedDeclaration declaration, DiagnosticBag diagnostics)
        {
            Debug.Assert(!declaration.IsType, "Use BuildTypeSymbol to create type symbols.");
            Debug.Assert(!declaration.IsNamespace, "Use BuildNamespaceSymbol to create namespace symbols.");
            //return new SourceMemberSymbol(this, declaration, diagnostics);
            return new SourceNamespaceSymbol((SourceModuleSymbol)this.ContainingModule, this, declaration, diagnostics);
        }

        private void AddDeclaredTypeMembers(ArrayBuilder<NamedTypeSymbol> builder, DiagnosticBag diagnostics)
        {
            foreach (var decl in _declaration.Children)
            {
                if (_lazyMembers != null)
                {
                    // membersAndInitializers is already computed. no point to continue.
                    return;
                }

                if (decl.IsType)
                {
                    var symbol = BuildTypeSymbol(decl, diagnostics);
                    builder.Add(symbol);
                }
            }
        }

        private void AddDeclaredNonTypeMembers(ArrayBuilder<Symbol> builder, DiagnosticBag diagnostics)
        {
            foreach (var decl in _declaration.Children)
            {
                if (_lazyMembers != null)
                {
                    // membersAndInitializers is already computed. no point to continue.
                    return;
                }

                if (decl.IsNamespace)
                {
                    var symbol = BuildNamespaceSymbol(decl, diagnostics);
                    builder.Add(symbol);
                }
                else if (decl.IsName)
                {
                    var symbol = BuildSymbol(decl, diagnostics);
                    builder.Add(symbol);
                }
            }
        }

        protected virtual void AddTypeMembers(ArrayBuilder<NamedTypeSymbol> builder, DiagnosticBag diagnostics)
        {

        }

        protected virtual void AddNonTypeMembers(ArrayBuilder<Symbol> builder, DiagnosticBag diagnostics)
        {

        }

        internal Binder GetBinder(LanguageSyntaxNode syntaxNode)
        {
            return this.DeclaringCompilation.GetBinder(syntaxNode);
        }

        protected virtual void MergePartialMembers(
            ArrayBuilder<string> memberNames,
            Dictionary<string, ImmutableArray<Symbol>> membersByName,
            DiagnosticBag diagnostics)
        {
            //key and value will be the same object
            var symbolMap = new Dictionary<Symbol, Symbol>();

            foreach (var name in memberNames)
            {
                symbolMap.Clear();
                foreach (var symbol in membersByName[name])
                {
                    if (!(symbol is IPartialMemberSymbol))
                    {
                        continue; // only partial methods need to be merged
                    }

                    Symbol prev;
                    if (symbolMap.TryGetValue(symbol, out prev))
                    {
                        var prevPart = (IPartialMemberSymbol)prev;
                        var symbolPart = (IPartialMemberSymbol)symbol;

                        bool hasImplementation = (object)prevPart.OtherPartOfPartial != null || prevPart.IsPartialImplementation;
                        bool hasDefinition = (object)prevPart.OtherPartOfPartial != null || prevPart.IsPartialDefinition;

                        if (hasImplementation && symbolPart.IsPartialImplementation)
                        {
                            // A partial method may not have multiple implementing declarations
                            diagnostics.Add(InternalErrorCode.ERR_PartialMethodOnlyOneActual, symbol.Locations[0]);
                        }
                        else if (hasDefinition && symbolPart.IsPartialDefinition)
                        {
                            // A partial method may not have multiple defining declarations
                            diagnostics.Add(InternalErrorCode.ERR_PartialMethodOnlyOneLatent, symbol.Locations[0]);
                        }
                        else
                        {
                            membersByName[name] = FixPartialMember(membersByName[name], prevPart, symbolPart);
                        }
                    }
                    else
                    {
                        symbolMap.Add(symbol, symbol);
                    }
                }

                foreach (Symbol symbol in symbolMap.Values)
                {
                    var symbolPart = (IPartialMemberSymbol)symbol;
                    // partial implementations not paired with a definition
                    if (symbolPart.IsPartialImplementation && (object)symbolPart.OtherPartOfPartial == null)
                    {
                        diagnostics.Add(InternalErrorCode.ERR_PartialMethodMustHaveLatent, symbol.Locations[0], symbolPart);
                    }
                }
            }
        }

        /// <summary>
        /// Fix up a partial method by combining its defining and implementing declarations, updating the array of symbols (by name),
        /// and returning the combined symbol.
        /// </summary>
        /// <param name="symbols">The symbols array containing both the latent and implementing declaration</param>
        /// <param name="part1">One of the two declarations</param>
        /// <param name="part2">The other declaration</param>
        /// <returns>An updated symbols array containing only one method symbol representing the two parts</returns>
        private ImmutableArray<Symbol> FixPartialMember(ImmutableArray<Symbol> symbols, IPartialMemberSymbol part1, IPartialMemberSymbol part2)
        {
            IPartialMemberSymbol definition;
            IPartialMemberSymbol implementation;
            if (part1.IsPartialDefinition)
            {
                definition = part1;
                implementation = part2;
            }
            else
            {
                definition = part2;
                implementation = part1;
            }

            InitializePartialSymbolParts(definition, implementation);

            // a partial method is represented in the member list by its definition part:
            return Remove(symbols, (Symbol)implementation);
        }

        protected virtual void InitializePartialSymbolParts(IPartialMemberSymbol definition, IPartialMemberSymbol implementation)
        {
            throw new NotImplementedException("TODO:MetaDslx");
            //definition.OtherPartOfPartial = implementation;
            //implementation.OtherPartOfPartial = definition;
        }

        private static ImmutableArray<Symbol> Remove(ImmutableArray<Symbol> symbols, Symbol symbol)
        {
            var builder = ArrayBuilder<Symbol>.GetInstance();
            foreach (var s in symbols)
            {
                if (!ReferenceEquals(s, symbol))
                {
                    builder.Add(s);
                }
            }
            return builder.ToImmutableAndFree();
        }

        #endregion

        public override ImmutableArray<AttributeData> GetAttributes()
        {
            // TODO:MetaDslx
            _state.NotePartComplete(CompletionPart.Attributes);
            return ImmutableArray<AttributeData>.Empty;
        }

        #region Completion

        public sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        public sealed override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        protected virtual void CheckBaseTypes(DiagnosticBag diagnostics)
        {

        }

        public override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            while (true)
            {
                // NOTE: cases that depend on GetMembers[ByName] should call RequireCompletionPartMembers.
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (incompletePart == CompletionPart.Attributes)
                {
                    GetAttributes();
                }
                else if (incompletePart == CompletionPart.StartBaseTypes || incompletePart == CompletionPart.FinishBaseTypes)
                {
                    if (_state.NotePartComplete(CompletionPart.StartBaseTypes))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        CheckBaseTypes(diagnostics);
                        AddDeclarationDiagnostics(diagnostics);
                        _state.NotePartComplete(CompletionPart.FinishBaseTypes);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionPart.Members)
                {
                    this.GetMembersByName();
                }
                else if (incompletePart == CompletionPart.TypeMembers)
                {
                    this.GetTypeMembersUnordered();
                }
                else if (incompletePart == CompletionPart.StartMemberChecks || incompletePart == CompletionPart.FinishMemberChecks)
                {
                    if (_state.NotePartComplete(CompletionPart.StartMemberChecks))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        AfterMembersChecks(diagnostics);
                        AddDeclarationDiagnostics(diagnostics);

                        // We may produce a SymbolDeclaredEvent for the enclosing type before events for its contained members
                        DeclaringCompilation.SymbolDeclaredEvent(this);
                        var thisThreadCompleted = _state.NotePartComplete(CompletionPart.FinishMemberChecks);
                        Debug.Assert(thisThreadCompleted);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionPart.StartProperties || incompletePart == CompletionPart.FinishProperties)
                {
                    if (_state.NotePartComplete(CompletionPart.StartProperties))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        SetPropertyValues(diagnostics, cancellationToken);
                        var thisThreadCompleted = _state.NotePartComplete(CompletionPart.FinishProperties);
                        Debug.Assert(thisThreadCompleted);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == CompletionPart.MembersCompleted)
                {
                    ImmutableArray<Symbol> members = this.GetMembersUnordered();

                    bool allCompleted = true;

                    if (locationOpt == null)
                    {
                        foreach (var member in members)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            member.ForceComplete(locationOpt, cancellationToken);
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

                    if (!allCompleted)
                    {
                        // We did not complete all members so we won't have enough information for
                        // the PointedAtManagedTypeChecks, so just kick out now.
                        var allParts = CompletionPart.NamedTypeSymbolWithLocationAll;
                        _state.SpinWaitComplete(allParts, cancellationToken);
                        return;
                    }

                    // We've completed all members, so we're ready for the PointedAtManagedTypeChecks;
                    // proceed to the next iteration.
                    _state.NotePartComplete(CompletionPart.MembersCompleted);
                }
                else if (incompletePart == CompletionPart.StartBoundNode || incompletePart == CompletionPart.FinishBoundNode)
                {
                    if (_state.NotePartComplete(CompletionPart.StartBoundNode))
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        CompleteBoundNode(diagnostics, cancellationToken);
                        var thisThreadCompleted = _state.NotePartComplete(CompletionPart.FinishBoundNode);
                        Debug.Assert(thisThreadCompleted);
                        diagnostics.Free();
                    }
                }
                else if (incompletePart == null)
                {
                    return;
                }
                else
                {
                    // This assert will trigger if we forgot to handle any of the completion parts
                    Debug.Assert(!CompletionPart.NamedTypeSymbolAll.Contains(incompletePart));
                    // any other values are completion parts intended for other kinds of symbols
                    _state.NotePartComplete(incompletePart);
                }
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }

            throw ExceptionUtilities.Unreachable;
        }

        #endregion

        public virtual void EnsureSymbolDefinitionsNoted()
        {
            // TODO:MetaDslx
        }

        protected void SetPropertyValues(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            foreach (var syntaxRef in _declaration.SyntaxReferences)
            {
                if (cancellationToken.IsCancellationRequested) return;
                var boundNode = this.DeclaringCompilation.GetBoundNode<BoundSymbolDef>(syntaxRef.GetSyntax());
                boundNode?.SetPropertyValues(_modelObject, boundNode.BoundTree.DiagnosticBag, cancellationToken);
            }
        }

        protected void CompleteBoundNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            foreach (var syntaxRef in _declaration.SyntaxReferences)
            {
                if (cancellationToken.IsCancellationRequested) return;
                var boundNode = this.DeclaringCompilation.GetBoundNode<BoundSymbolDef>(syntaxRef.GetSyntax());
                boundNode?.ForceComplete(cancellationToken);
            }
        }
    }
}
