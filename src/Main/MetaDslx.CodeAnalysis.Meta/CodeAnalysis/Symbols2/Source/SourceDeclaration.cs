using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceDeclaration
    {
        private readonly DeclaredSymbol _symbol;
        private readonly MergedDeclaration _declaration;
        private readonly CompletionState _state;
        private Members _lazyMembers;

        private Dictionary<string, ImmutableArray<DeclaredSymbol>> _lazyMembersDictionary;
        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> _lazyTypeMembers;
        private int _flattenedMembersIsSorted = 0;
        private ImmutableArray<DeclaredSymbol> _lazyMembersFlattened;

        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

        private static readonly Dictionary<string, ImmutableArray<NamedTypeSymbol>> s_emptyTypeMembers = new Dictionary<string, ImmutableArray<NamedTypeSymbol>>(EmptyComparer.Instance);

        public SourceDeclaration(DeclaredSymbol symbol, MergedDeclaration declaration, CompletionState state)
        {
            _symbol = symbol;
            _state = state;
            _declaration = declaration;
        }

        public MergedDeclaration Declaration => _declaration;

        public LexicalSortKey GetLexicalSortKey()
        {
            if (!_lazyLexicalSortKey.IsInitialized)
            {
                _lazyLexicalSortKey.SetFrom(this.Declaration.GetLexicalSortKey(_symbol.DeclaringCompilation));
            }
            return _lazyLexicalSortKey;
        }

        // NOTE: this method should do as little work as possible
        //       we often need to get members just to do a lookup.
        //       All additional checks and diagnostics may be not
        //       needed yet or at all.
        public Members GetMembersForLookup()
        {
            if (_lazyMembers != null)
            {
                return _lazyMembers;
            }

            var diagnostics = DiagnosticBag.GetInstance();
            var members = BuildMembers(diagnostics);

            var alreadyKnown = Interlocked.CompareExchange(ref _lazyMembers, members, null);
            if (alreadyKnown != null)
            {
                diagnostics.Free();
                return alreadyKnown;
            }

            _symbol.AddDeclarationDiagnostics(diagnostics);
            diagnostics.Free();

            return _lazyMembers;
        }

        public string Name => _symbol.Name;

        public string MetadataName => _symbol.MetadataName;

        public IModelSourceSymbol SourceSymbol => (IModelSourceSymbol)_symbol;

        public bool IsImplicitlyDeclared => _symbol.IsImplicitlyDeclared;

        public Symbol ContainingSymbol => _symbol.ContainingSymbol;

        public DeclaredSymbol ContainingDeclaration => _symbol.ContainingDeclaration;

        public IEnumerable<string> MemberNames
        {
            get { return this.Declaration.ChildNames; }
        }

        public ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            return GetTypeMembersDictionary().Flatten();
        }

        public ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return GetTypeMembersDictionary().Flatten(LexicalOrderSymbolComparer.Instance);
        }

        public ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            ImmutableArray<NamedTypeSymbol> members;
            if (GetTypeMembersDictionary().TryGetValue(name, out members))
            {
                return members;
            }

            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
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
                    _symbol.AddDeclarationDiagnostics(diagnostics);

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
                foreach (var childDeclaration in this.Declaration.Children)
                {
                    if (childDeclaration.IsType && childDeclaration.Name != null)
                    {
                        var t = _symbol.ChildSymbols.OfType<SourceNamedTypeSymbol>().FirstOrDefault(nts => nts.MergedDeclaration == childDeclaration);
                        this.CheckMemberNameDistinctFromType(t, diagnostics);

                        var key = (t.Name, t.MetadataName);
                        SourceNamedTypeSymbol other;
                        if (conflictDict.TryGetValue(key, out other))
                        {
                            if (this.Declaration.NameLocations.Length == 1 || this.Declaration.Merge)
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

        public ImmutableArray<DeclaredSymbol> GetMembersUnordered()
        {
            var result = _lazyMembersFlattened;

            if (result.IsDefault)
            {
                GetMembersByName();
                ImmutableInterlocked.InterlockedInitialize(ref _lazyMembersFlattened, _lazyMembers.AllMembers);
                result = _lazyMembersFlattened;
            }

            return result.ConditionallyDeOrder();
        }

        public ImmutableArray<DeclaredSymbol> GetMembers()
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

        public ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            ImmutableArray<DeclaredSymbol> members;
            if (GetMembersByName().TryGetValue(name, out members))
            {
                return members;
            }

            return ImmutableArray<DeclaredSymbol>.Empty;
        }

        public ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            return this.GetMembers(name).WhereAsArray(m => m.MetadataName == metadataName);
        }

        public ImmutableArray<DeclaredSymbol> GetNonTypeMembers(string name)
        {
            if (_lazyMembers != null || this.Declaration.ChildNames.Contains(name))
            {
                return GetMembers(name);
            }

            return ImmutableArray<DeclaredSymbol>.Empty;
        }

        public Dictionary<string, ImmutableArray<DeclaredSymbol>> GetMembersByName()
        {
            if (_state.HasComplete(CompletionPart.Members))
            {
                return _lazyMembersDictionary;
            }

            return GetMembersByNameSlow();
        }

        private Dictionary<string, ImmutableArray<DeclaredSymbol>> GetMembersByNameSlow()
        {
            if (_lazyMembers == null)
            {
                var diagnostics = DiagnosticBag.GetInstance();
                var membersDictionary = MakeNamedMembers(diagnostics);
                if (Interlocked.CompareExchange(ref _lazyMembersDictionary, membersDictionary, null) == null)
                {
                    var memberNames = ArrayBuilder<string>.GetInstance(membersDictionary.Count);
                    memberNames.AddRange(membersDictionary.Keys);
                    MergePartialSymbols(memberNames, membersDictionary, diagnostics);
                    memberNames.Free();
                    _symbol.CheckMembers(membersDictionary, diagnostics);
                    _symbol.AddDeclarationDiagnostics(diagnostics);
                    _symbol.DeclaringCompilation.SymbolDeclaredEvent(_symbol);
                    var wasSetThisThread = _state.NotePartComplete(CompletionPart.Members);
                    Debug.Assert(wasSetThisThread);
                }

                diagnostics.Free();
            }

            _state.SpinWaitComplete(CompletionPart.Members, default);
            return _lazyMembersDictionary;
        }

        private Dictionary<string, ImmutableArray<DeclaredSymbol>> MakeNamedMembers(DiagnosticBag diagnostics)
        {
            var members = GetMembersForLookup(); //NOTE: separately cached
            ArrayBuilder<DeclaredSymbol> membersByName = ArrayBuilder<DeclaredSymbol>.GetInstance();
            foreach (var member in members.NamedNonTypeMembers)
            {
                membersByName.Add(member);
            }
            foreach (var member in members.NamedTypeMembers)
            {
                membersByName.Add(member);
            }
            return membersByName.ToImmutableAndFree().ToDictionaryWithImmutableArray(m => m.Name);
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

        private Members BuildMembers(DiagnosticBag diagnostics)
        {
            var builder = new MembersBuilder(_symbol, _state);
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

        private void AddTypeMembers(ArrayBuilder<NamedTypeSymbol> builder, DiagnosticBag diagnostics)
        {
            var symbolFactory = SourceSymbol.SymbolFactory;
            var objectFactory = _symbol.DeclaringCompilation.ObjectFactory;
            Debug.Assert(_symbol.ChildSymbols.Length >= this.Declaration.Children.Length);
            foreach (var decl in this.Declaration.Children)
            {
                if (_lazyMembers != null)
                {
                    // membersAndInitializers is already computed. no point to continue.
                    return;
                }

                if (decl.IsType)
                {
                    var symbol = _symbol.ChildSymbols.OfType<SourceNamedTypeSymbol>().FirstOrDefault(nts => nts.MergedDeclaration == decl);
                    Debug.Assert(symbol != null);
                    if (symbol != null) builder.Add(symbol);
                }
            }
        }

        private void AddNonTypeMembers(ArrayBuilder<DeclaredSymbol> builder, DiagnosticBag diagnostics)
        {
            var symbolFactory = SourceSymbol.SymbolFactory;
            var objectFactory = _symbol.DeclaringCompilation.ObjectFactory;
            Debug.Assert(_symbol.ChildSymbols.Length >= this.Declaration.Children.Length);
            foreach (var decl in this.Declaration.Children)
            {
                if (_lazyMembers != null)
                {
                    // membersAndInitializers is already computed. no point to continue.
                    return;
                }

                if (decl.IsType) continue;

                var symbol = _symbol.ChildSymbols.OfType<DeclaredSymbol>().FirstOrDefault(ds => ds.MergedDeclaration == decl);
                Debug.Assert(symbol != null);
                if (symbol != null) builder.Add(symbol);
            }
        }

        protected virtual void MergePartialSymbols(
            ArrayBuilder<string> memberNames,
            Dictionary<string, ImmutableArray<DeclaredSymbol>> membersByName,
            DiagnosticBag diagnostics)
        {
            var symbolFacts = _symbol.Language.SymbolFacts;
            //key and value will be the same object
            var symbolMap = new Dictionary<Symbol, Symbol>();

            foreach (var name in memberNames)
            {
                symbolMap.Clear();
                foreach (var symbol in membersByName[name])
                {
                    var modelSymbol = symbol as IModelSourceSymbol;
                    var symbolType = symbolFacts.GetModelObjectType(modelSymbol.ModelObject);
                    Symbol prev;
                    if (symbolMap.TryGetValue(symbol, out prev))
                    {
                        var modelPrevSymbol = prev as IModelSourceSymbol;
                        var prevType = symbolFacts.GetModelObjectType(modelPrevSymbol.ModelObject);
                        if (prevType == symbolType)
                        {
                            diagnostics.Add(InternalErrorCode.ERR_DuplicateNameInClass, symbol.Locations[0], this, symbol.Name);
                        }
                        /* TODO:MetaDslx
                        if (prevPart.GetMergedDeclaration().IsPartial && symbolPart.IsPartial)
                        {
                            diagnostics.Add(InternalErrorCode.ERR_PartialTypeKindConflict, t.Locations[0], t);
                        }
                        else
                        {
                            diagnostics.Add(InternalErrorCode.ERR_DuplicateNameInClass, t.Locations[0], this, t.Name);
                        }

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
                        }*/
                    }
                    else
                    {
                        symbolMap.Add(symbol, symbol);
                    }
                }
                /* TODO:MetaDslx
                foreach (Symbol symbol in symbolMap.Values)
                {
                    var symbolPart = (IPartialMemberSymbol)symbol;
                    // partial implementations not paired with a definition
                    if (symbolPart.IsPartialImplementation && (object)symbolPart.OtherPartOfPartial == null)
                    {
                        diagnostics.Add(InternalErrorCode.ERR_PartialMethodMustHaveLatent, symbol.Locations[0], symbolPart);
                    }
                }*/
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


    }
}
