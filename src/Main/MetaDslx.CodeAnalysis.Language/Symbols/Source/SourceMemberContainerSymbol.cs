// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// Represents a named type symbol whose members are declared in source.
    /// </summary>
    internal abstract partial class SourceMemberContainerTypeSymbol : NamedTypeSymbol
    {
        // The flags type is used to compact many different bits of information efficiently.
        private struct Flags
        {
            // We current pack everything into two 32-bit ints; layouts for each are given below.

            // First int:
            //
            // | |d|yy|xxxxxxxxxxxxxxxxxxxxxxx|wwwwww|
            //
            // w = special type.  6 bits.
            // x = modifiers.  23 bits.
            // y = IsManagedType.  2 bits.
            // d = FieldDefinitionsNoted. 1 bit
            private const int SpecialTypeOffset = 0;
            private const int SpecialTypeSize = 6;

            private const int DeclarationModifiersOffset = SpecialTypeSize;
            private const int DeclarationModifiersSize = 23;

            private const int ManagedKindOffset = DeclarationModifiersOffset + DeclarationModifiersSize;
            private const int ManagedKindSize = 2;

            private const int FieldDefinitionsNotedOffset = ManagedKindOffset + ManagedKindSize;
            private const int FieldDefinitionsNotedSize = 1;

            private const int SpecialTypeMask = (1 << SpecialTypeSize) - 1;
            private const int DeclarationModifiersMask = (1 << DeclarationModifiersSize) - 1;
            private const int ManagedKindMask = (1 << ManagedKindSize) - 1;

            private const int FieldDefinitionsNotedBit = 1 << FieldDefinitionsNotedOffset;

            private int _flags;

            // More flags.
            //
            // |                           |zzzz|f|
            //
            // f = FlattenedMembersIsSorted.  1 bit.
            // z = TypeKind. 4 bits.
            private const int TypeKindOffset = 1;

            private const int TypeKindMask = 0xF;

            private const int FlattenedMembersIsSortedBit = 1 << 0;

            private int _flags2;

            public SpecialType SpecialType
            {
                get { return (SpecialType)((_flags >> SpecialTypeOffset) & SpecialTypeMask); }
            }

            public DeclarationModifiers DeclarationModifiers
            {
                get { return (DeclarationModifiers)((_flags >> DeclarationModifiersOffset) & DeclarationModifiersMask); }
            }

            public ManagedKind ManagedKind
            {
                get { return (ManagedKind)((_flags >> ManagedKindOffset) & ManagedKindMask); }
            }

            public bool FieldDefinitionsNoted
            {
                get { return (_flags & FieldDefinitionsNotedBit) != 0; }
            }

            // True if "lazyMembersFlattened" is sorted.
            public bool FlattenedMembersIsSorted
            {
                get { return (_flags2 & FlattenedMembersIsSortedBit) != 0; }
            }

            public TypeKind TypeKind
            {
                get { return (TypeKind)((_flags2 >> TypeKindOffset) & TypeKindMask); }
            }


#if DEBUG
            static Flags()
            {
                // Verify a few things about the values we combine into flags.  This way, if they ever
                // change, this will get hit and you will know you have to update this type as well.

                // 1) Verify that the range of special types doesn't fall outside the bounds of the
                // special type mask.
                var specialTypes = EnumUtilities.GetValues<SpecialType>();
                var maxSpecialType = (int)specialTypes.Aggregate((s1, s2) => s1 | s2);
                Debug.Assert((maxSpecialType & SpecialTypeMask) == maxSpecialType);

                // 2) Verify that the range of declaration modifiers doesn't fall outside the bounds of
                // the declaration modifier mask.
                var declarationModifiers = EnumUtilities.GetValues<DeclarationModifiers>();
                var maxDeclarationModifier = (int)declarationModifiers.Aggregate((d1, d2) => d1 | d2);
                Debug.Assert((maxDeclarationModifier & DeclarationModifiersMask) == maxDeclarationModifier);
            }
#endif

            public Flags(SpecialType specialType, DeclarationModifiers declarationModifiers, TypeKind typeKind)
            {
                int specialTypeInt = ((int)specialType & SpecialTypeMask) << SpecialTypeOffset;
                int declarationModifiersInt = ((int)declarationModifiers & DeclarationModifiersMask) << DeclarationModifiersOffset;
                int typeKindInt = ((int)typeKind & TypeKindMask) << TypeKindOffset;

                _flags = specialTypeInt | declarationModifiersInt;
                _flags2 = typeKindInt;
            }

            public void SetFieldDefinitionsNoted()
            {
                ThreadSafeFlagOperations.Set(ref _flags, FieldDefinitionsNotedBit);
            }

            public void SetFlattenedMembersIsSorted()
            {
                ThreadSafeFlagOperations.Set(ref _flags2, (FlattenedMembersIsSortedBit));
            }

            private static bool BitsAreUnsetOrSame(int bits, int mask)
            {
                return (bits & mask) == 0 || (bits & mask) == mask;
            }

            public void SetManagedKind(ManagedKind managedKind)
            {
                int bitsToSet = ((int)managedKind & ManagedKindMask) << ManagedKindOffset;
                Debug.Assert(BitsAreUnsetOrSame(_flags, bitsToSet));
                ThreadSafeFlagOperations.Set(ref _flags, bitsToSet);
            }
        }

        protected SymbolCompletionState state;

        private Flags _flags;

        private readonly NamespaceOrTypeSymbol _containingSymbol;
        protected readonly MergedTypeDeclaration declaration;

        private MembersAndInitializers _lazyMembersAndInitializers;
        private Dictionary<string, ImmutableArray<Symbol>> _lazyMembersDictionary;
        private Dictionary<string, ImmutableArray<Symbol>> _lazyEarlyAttributeDecodingMembersDictionary;

        private static readonly Dictionary<string, ImmutableArray<NamedTypeSymbol>> s_emptyTypeMembers = new Dictionary<string, ImmutableArray<NamedTypeSymbol>>(EmptyComparer.Instance);
        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> _lazyTypeMembers;
        private ImmutableArray<Symbol> _lazyMembersFlattened;
        private ImmutableArray<SynthesizedExplicitImplementationForwardingMethod> _lazySynthesizedExplicitImplementations;
        private int _lazyKnownCircularStruct;
        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

        private ThreeState _lazyContainsExtensionMethods;
        private ThreeState _lazyAnyMemberHasAttributes;

        #region Construction

        internal SourceMemberContainerTypeSymbol(
            NamespaceOrTypeSymbol containingSymbol,
            MergedTypeDeclaration declaration,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private SpecialType MakeSpecialType()
        {
            // check if this is one of the COR library types
            if (ContainingSymbol.Kind == SymbolKind.Namespace &&
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

        #endregion

        #region Completion

        internal sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        internal sealed override bool HasComplete(CompletionPart part)
        {
            return state.HasComplete(part);
        }

        protected abstract void CheckBase(DiagnosticBag diagnostics);
        protected abstract void CheckInterfaces(DiagnosticBag diagnostics);

        internal override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal void EnsureFieldDefinitionsNoted()
        {
            if (_flags.FieldDefinitionsNoted)
            {
                return;
            }

            NoteFieldDefinitions();
        }

        private void NoteFieldDefinitions()
        {
            // we must note all fields once therefore we need to lock
            lock (this.GetMembersAndInitializers())
            {
                if (!_flags.FieldDefinitionsNoted)
                {
                    var assembly = (SourceAssemblySymbol)ContainingAssembly;

                    Accessibility containerEffectiveAccessibility = EffectiveAccessibility();

                    foreach (var member in _lazyMembersAndInitializers.NonTypeNonIndexerMembers)
                    {
                        FieldSymbol field;
                        if (!member.IsFieldOrFieldLikeEvent(out field) || field.IsConst || field.IsFixedSizeBuffer)
                        {
                            continue;
                        }

                        Accessibility fieldDeclaredAccessibility = field.DeclaredAccessibility;
                        if (fieldDeclaredAccessibility == Accessibility.Private)
                        {
                            // mark private fields as tentatively unassigned and unread unless we discover otherwise.
                            assembly.NoteFieldDefinition(field, isInternal: false, isUnread: true);
                        }
                        else if (containerEffectiveAccessibility == Accessibility.Private)
                        {
                            // mark effectively private fields as tentatively unassigned unless we discover otherwise.
                            assembly.NoteFieldDefinition(field, isInternal: false, isUnread: false);
                        }
                        else if (fieldDeclaredAccessibility == Accessibility.Internal || containerEffectiveAccessibility == Accessibility.Internal)
                        {
                            // mark effectively internal fields as tentatively unassigned unless we discover otherwise.
                            // NOTE: These fields will be reported as unassigned only if internals are not visible from this assembly.
                            // See property SourceAssemblySymbol.UnusedFieldWarnings.
                            assembly.NoteFieldDefinition(field, isInternal: true, isUnread: false);
                        }
                    }
                    _flags.SetFieldDefinitionsNoted();
                }
            }
        }

        #endregion

        #region Containers

        public sealed override NamedTypeSymbol ContainingType
        {
            get
            {
                return _containingSymbol as NamedTypeSymbol;
            }
        }

        public sealed override Symbol ContainingSymbol
        {
            get
            {
                return _containingSymbol;
            }
        }

        #endregion

        #region Flags Encoded Properties

        public override SpecialType SpecialType
        {
            get
            {
                return _flags.SpecialType;
            }
        }

        public override TypeKind TypeKind
        {
            get
            {
                return _flags.TypeKind;
            }
        }

        internal MergedTypeDeclaration MergedDeclaration
        {
            get
            {
                return this.declaration;
            }
        }

        internal sealed override bool IsInterface
        {
            get
            {
                // TypeKind is computed eagerly, so this is cheap.
                return this.TypeKind == TypeKind.Interface;
            }
        }

        internal override ManagedKind ManagedKind
        {
            get
            {
                var managedKind = _flags.ManagedKind;
                if (managedKind == ManagedKind.Unknown)
                {
                    var baseKind = base.ManagedKind;
                    _flags.SetManagedKind(baseKind);
                    return baseKind;
                }
                return managedKind;
            }
        }

        public override bool IsStatic
        {
            get
            {
                return (_flags.DeclarationModifiers & DeclarationModifiers.Static) != 0;
            }
        }

        public sealed override bool IsRefLikeType
        {
            get
            {
                return (_flags.DeclarationModifiers & DeclarationModifiers.Ref) != 0;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return (_flags.DeclarationModifiers & DeclarationModifiers.ReadOnly) != 0;
            }
        }

        public override bool IsSealed
        {
            get
            {
                return (_flags.DeclarationModifiers & DeclarationModifiers.Sealed) != 0;
            }
        }

        public override bool IsAbstract
        {
            get
            {
                return (_flags.DeclarationModifiers & DeclarationModifiers.Abstract) != 0;
            }
        }

        internal bool IsPartial
        {
            get
            {
                return (_flags.DeclarationModifiers & DeclarationModifiers.Partial) != 0;
            }
        }

        internal bool IsNew
        {
            get
            {
                return (_flags.DeclarationModifiers & DeclarationModifiers.New) != 0;
            }
        }

        public override Accessibility DeclaredAccessibility
        {
            get
            {
                return ModifierUtils.EffectiveAccessibility(_flags.DeclarationModifiers);
            }
        }

        /// <summary>
        /// Compute the "effective accessibility" of the current class for the purpose of warnings about unused fields.
        /// </summary>
        private Accessibility EffectiveAccessibility()
        {
            var result = DeclaredAccessibility;
            if (result == Accessibility.Private) return Accessibility.Private;
            for (Symbol container = this.ContainingType; (object)container != null; container = container.ContainingType)
            {
                switch (container.DeclaredAccessibility)
                {
                    case Accessibility.Private:
                        return Accessibility.Private;
                    case Accessibility.Internal:
                        result = Accessibility.Internal;
                        continue;
                }
            }

            return result;
        }

        #endregion

        #region Syntax

        public override bool IsScriptClass
        {
            get
            {
                var kind = this.declaration.Declarations[0].Kind;
                return kind == DeclarationKind.Script || kind == DeclarationKind.Submission;
            }
        }

        public override bool IsImplicitClass
        {
            get
            {
                return this.declaration.Declarations[0].Kind == DeclarationKind.ImplicitClass;
            }
        }

        public override bool IsImplicitlyDeclared
        {
            get
            {
                return IsImplicitClass || IsScriptClass;
            }
        }

        public override int Arity
        {
            get
            {
                return declaration.Arity;
            }
        }

        public override string Name
        {
            get
            {
                return declaration.Name;
            }
        }

        internal override bool MangleName
        {
            get
            {
                return Arity > 0;
            }
        }

        internal override LexicalSortKey GetLexicalSortKey()
        {
            if (!_lazyLexicalSortKey.IsInitialized)
            {
                _lazyLexicalSortKey.SetFrom(declaration.GetLexicalSortKey(this.DeclaringCompilation));
            }
            return _lazyLexicalSortKey;
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return declaration.NameLocations.Cast<SourceLocation, Location>();
            }
        }

        public ImmutableArray<SyntaxReference> SyntaxReferences
        {
            get
            {
                return this.declaration.SyntaxReferences;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                return SyntaxReferences;
            }
        }

        // This method behaves the same was as the base class, but avoids allocations associated with DeclaringSyntaxReferences
        internal override bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken)
        {
            var declarations = declaration.Declarations;
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
        private sealed class MembersAndInitializers
        {
            internal readonly ImmutableArray<Symbol> NonTypeNonIndexerMembers;
            internal readonly ImmutableArray<ImmutableArray<FieldOrPropertyInitializer>> StaticInitializers;
            internal readonly ImmutableArray<ImmutableArray<FieldOrPropertyInitializer>> InstanceInitializers;
            internal readonly ImmutableArray<SyntaxReference> IndexerDeclarations;
            internal readonly int StaticInitializersSyntaxLength;
            internal readonly int InstanceInitializersSyntaxLength;

            public MembersAndInitializers(
                ImmutableArray<Symbol> nonTypeNonIndexerMembers,
                ImmutableArray<ImmutableArray<FieldOrPropertyInitializer>> staticInitializers,
                ImmutableArray<ImmutableArray<FieldOrPropertyInitializer>> instanceInitializers,
                ImmutableArray<SyntaxReference> indexerDeclarations,
                int staticInitializersSyntaxLength,
                int instanceInitializersSyntaxLength)
            {
                Debug.Assert(!nonTypeNonIndexerMembers.IsDefault);
                Debug.Assert(!staticInitializers.IsDefault);
                Debug.Assert(!instanceInitializers.IsDefault);
                Debug.Assert(!indexerDeclarations.IsDefault);

                Debug.Assert(!nonTypeNonIndexerMembers.Any(s => s is TypeSymbol));
                Debug.Assert(!nonTypeNonIndexerMembers.Any(s => s.IsIndexer()));
                Debug.Assert(!nonTypeNonIndexerMembers.Any(s => s.IsAccessor() && ((MethodSymbol)s).AssociatedSymbol.IsIndexer()));

                Debug.Assert(staticInitializersSyntaxLength == staticInitializers.Sum(s => s.Sum(i => (i.FieldOpt == null || !i.FieldOpt.IsMetadataConstant) ? i.Syntax.Span.Length : 0)));
                Debug.Assert(instanceInitializersSyntaxLength == instanceInitializers.Sum(s => s.Sum(i => i.Syntax.Span.Length)));

                this.NonTypeNonIndexerMembers = nonTypeNonIndexerMembers;
                this.StaticInitializers = staticInitializers;
                this.InstanceInitializers = instanceInitializers;
                this.IndexerDeclarations = indexerDeclarations;
                this.StaticInitializersSyntaxLength = staticInitializersSyntaxLength;
                this.InstanceInitializersSyntaxLength = instanceInitializersSyntaxLength;
            }
        }

        internal ImmutableArray<ImmutableArray<FieldOrPropertyInitializer>> StaticInitializers
        {
            get { return GetMembersAndInitializers().StaticInitializers; }
        }

        internal ImmutableArray<ImmutableArray<FieldOrPropertyInitializer>> InstanceInitializers
        {
            get { return GetMembersAndInitializers().InstanceInitializers; }
        }

        internal int CalculateSyntaxOffsetInSynthesizedConstructor(int position, SyntaxTree tree, bool isStatic)
        {
            if (IsScriptClass && !isStatic)
            {
                int aggregateLength = 0;

                foreach (var declaration in this.declaration.Declarations)
                {
                    var syntaxRef = declaration.SyntaxReference;
                    if (tree == syntaxRef.SyntaxTree)
                    {
                        return aggregateLength + position;
                    }

                    aggregateLength += syntaxRef.Span.Length;
                }

                throw ExceptionUtilities.Unreachable;
            }

            int syntaxOffset;
            if (TryCalculateSyntaxOffsetOfPositionInInitializer(position, tree, isStatic, ctorInitializerLength: 0, syntaxOffset: out syntaxOffset))
            {
                return syntaxOffset;
            }

            if (declaration.Declarations.Length >= 1 && position == declaration.Declarations[0].Location.SourceSpan.Start)
            {
                // With dynamic analysis instrumentation, the introducing declaration of a type can provide
                // the syntax associated with both the analysis payload local of a synthesized constructor
                // and with the constructor itself. If the synthesized constructor includes an initializer with a lambda,
                // that lambda needs a closure that captures the analysis payload of the constructor,
                // and the offset of the syntax for the local within the constructor is by definition zero.
                return 0;
            }

            // an implicit constructor has no body and no initializer, so the variable has to be declared in a member initializer
            throw ExceptionUtilities.Unreachable;
        }

        /// <summary>
        /// Calculates a syntax offset of a syntax position that is contained in a property or field initializer (if it is in fact contained in one).
        /// </summary>
        internal bool TryCalculateSyntaxOffsetOfPositionInInitializer(int position, SyntaxTree tree, bool isStatic, int ctorInitializerLength, out int syntaxOffset)
        {
            Debug.Assert(ctorInitializerLength >= 0);

            var membersAndInitializers = GetMembersAndInitializers();
            var allInitializers = isStatic ? membersAndInitializers.StaticInitializers : membersAndInitializers.InstanceInitializers;

            var siblingInitializers = GetInitializersInSourceTree(tree, allInitializers);
            int index = IndexOfInitializerContainingPosition(siblingInitializers, position);
            if (index < 0)
            {
                syntaxOffset = 0;
                return false;
            }

            //                                 |<-----------distanceFromCtorBody----------->|
            // [      initializer 0    ][ initializer 1 ][ initializer 2 ][ctor initializer][ctor body]
            // |<--preceding init len-->|      ^
            //                             position 

            int initializersLength = isStatic ? membersAndInitializers.StaticInitializersSyntaxLength : membersAndInitializers.InstanceInitializersSyntaxLength;
            int distanceFromInitializerStart = position - siblingInitializers[index].Syntax.Span.Start;

            int distanceFromCtorBody =
                initializersLength + ctorInitializerLength -
                (siblingInitializers[index].PrecedingInitializersLength + distanceFromInitializerStart);

            Debug.Assert(distanceFromCtorBody > 0);

            // syntax offset 0 is at the start of the ctor body:
            syntaxOffset = -distanceFromCtorBody;
            return true;
        }

        private static ImmutableArray<FieldOrPropertyInitializer> GetInitializersInSourceTree(SyntaxTree tree, ImmutableArray<ImmutableArray<FieldOrPropertyInitializer>> initializers)
        {
            var builder = ArrayBuilder<FieldOrPropertyInitializer>.GetInstance();
            foreach (var siblingInitializers in initializers)
            {
                Debug.Assert(!siblingInitializers.IsEmpty);

                if (siblingInitializers[0].Syntax.SyntaxTree == tree)
                {
                    builder.AddRange(siblingInitializers);
                }
            }

            return builder.ToImmutableAndFree();
        }

        private static int IndexOfInitializerContainingPosition(ImmutableArray<FieldOrPropertyInitializer> initializers, int position)
        {
            // Search for the start of the span (the spans are non-overlapping and sorted)
            int index = initializers.BinarySearch(position, (initializer, pos) => initializer.Syntax.Span.Start.CompareTo(pos));

            // Binary search returns non-negative result if the position is exactly the start of some span.
            if (index >= 0)
            {
                return index;
            }

            // Otherwise, ~index is the closest span whose start is greater than the position.
            // => Check if the preceding initializer span contains the position.
            int precedingInitializerIndex = ~index - 1;
            if (precedingInitializerIndex >= 0 && initializers[precedingInitializerIndex].Syntax.Span.Contains(position))
            {
                return precedingInitializerIndex;
            }

            return -1;
        }

        public override IEnumerable<string> MemberNames
        {
            get { return this.declaration.MemberNames; }
        }

        internal override ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            return GetTypeMembersDictionary().Flatten();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
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

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, int arity)
        {
            return GetTypeMembers(name).WhereAsArray(t => t.Arity == arity);
        }

        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> GetTypeMembersDictionary()
        {
            if (_lazyTypeMembers == null)
            {
                var diagnostics = DiagnosticBag.GetInstance();
                if (Interlocked.CompareExchange(ref _lazyTypeMembers, MakeTypeMembers(diagnostics), null) == null)
                {
                    AddDeclarationDiagnostics(diagnostics);

                    state.NotePartComplete(CompletionPart.TypeMembers);
                }

                diagnostics.Free();
            }

            return _lazyTypeMembers;
        }

        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> MakeTypeMembers(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void CheckMemberNameDistinctFromType(Symbol member, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
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

        public override ImmutableArray<Symbol> GetMembers()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
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

        internal override ImmutableArray<Symbol> GetSimpleNonTypeMembers(string name)
        {
            if (_lazyMembersDictionary != null || declaration.MemberNames.Contains(name))
            {
                return GetMembers(name);
            }

            return ImmutableArray<Symbol>.Empty;
        }

        internal override IEnumerable<FieldSymbol> GetFieldsToEmit()
        {
            if (this.TypeKind == TypeKind.Enum)
            {
                // For consistency with Dev10, emit value__ field first.
                var valueField = ((SourceNamedTypeSymbol)this).EnumValueField;
                Debug.Assert((object)valueField != null);
                yield return valueField;
            }

            foreach (var m in this.GetMembers())
            {
                switch (m.Kind)
                {
                    case SymbolKind.Field:
                        yield return (FieldSymbol)m;
                        break;
                    case SymbolKind.Event:
                        FieldSymbol associatedField = ((EventSymbol)m).AssociatedField;
                        if ((object)associatedField != null)
                        {
                            yield return associatedField;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// During early attribute decoding, we consider a safe subset of all members that will not
        /// cause cyclic dependencies.  Get all such members for this symbol.
        /// 
        /// In particular, this method will return nested types and fields (other than auto-property
        /// backing fields).
        /// </summary>
        internal override ImmutableArray<Symbol> GetEarlyAttributeDecodingMembers()
        {
            return GetEarlyAttributeDecodingMembersDictionary().Flatten();
        }

        /// <summary>
        /// During early attribute decoding, we consider a safe subset of all members that will not
        /// cause cyclic dependencies.  Get all such members for this symbol that have a particular name.
        /// 
        /// In particular, this method will return nested types and fields (other than auto-property
        /// backing fields).
        /// </summary>
        internal override ImmutableArray<Symbol> GetEarlyAttributeDecodingMembers(string name)
        {
            ImmutableArray<Symbol> result;
            return GetEarlyAttributeDecodingMembersDictionary().TryGetValue(name, out result) ? result : ImmutableArray<Symbol>.Empty;
        }

        private Dictionary<string, ImmutableArray<Symbol>> GetEarlyAttributeDecodingMembersDictionary()
        {
            if (_lazyEarlyAttributeDecodingMembersDictionary == null)
            {
                var membersAndInitializers = GetMembersAndInitializers(); //NOTE: separately cached

                // NOTE: members were added in a single pass over the syntax, so they're already
                // in lexical order.

                var membersByName = membersAndInitializers.NonTypeNonIndexerMembers.ToDictionary(s => s.Name);
                AddNestedTypesToDictionary(membersByName, GetTypeMembersDictionary());

                Interlocked.CompareExchange(ref _lazyEarlyAttributeDecodingMembersDictionary, membersByName, null);
            }

            return _lazyEarlyAttributeDecodingMembersDictionary;
        }

        // NOTE: this method should do as little work as possible
        //       we often need to get members just to do a lookup.
        //       All additional checks and diagnostics may be not
        //       needed yet or at all.
        private MembersAndInitializers GetMembersAndInitializers()
        {
            var membersAndInitializers = _lazyMembersAndInitializers;
            if (membersAndInitializers != null)
            {
                return membersAndInitializers;
            }

            var diagnostics = DiagnosticBag.GetInstance();
            membersAndInitializers = BuildMembersAndInitializers(diagnostics);

            var alreadyKnown = Interlocked.CompareExchange(ref _lazyMembersAndInitializers, membersAndInitializers, null);
            if (alreadyKnown != null)
            {
                diagnostics.Free();
                return alreadyKnown;
            }

            AddDeclarationDiagnostics(diagnostics);
            diagnostics.Free();

            return membersAndInitializers;
        }

        protected Dictionary<string, ImmutableArray<Symbol>> GetMembersByName()
        {
            if (this.state.HasComplete(CompletionPart.Members))
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
                    state.NotePartComplete(CompletionPart.Members);
                }

                diagnostics.Free();
            }

            state.SpinWaitComplete(CompletionPart.Members, default(CancellationToken));
            return _lazyMembersDictionary;
        }

        internal override IEnumerable<Symbol> GetInstanceFieldsAndEvents()
        {
            var membersAndInitializers = this.GetMembersAndInitializers();
            return membersAndInitializers.NonTypeNonIndexerMembers.Where(IsInstanceFieldOrEvent);
        }

        protected void AfterMembersChecks(DiagnosticBag diagnostics)
        {
            if (IsInterface)
            {
                CheckInterfaceMembers(this.GetMembersAndInitializers().NonTypeNonIndexerMembers, diagnostics);
            }

            CheckMemberNamesDistinctFromType(diagnostics);
            CheckMemberNameConflicts(diagnostics);
            CheckSpecialMemberErrors(diagnostics);
            CheckTypeParameterNameConflicts(diagnostics);
            CheckAccessorNameConflicts(diagnostics);

            bool unused = KnownCircularStruct;

            CheckSequentialOnPartialType(diagnostics);
            CheckForProtectedInStaticClass(diagnostics);
            CheckForUnmatchedOperators(diagnostics);

            var location = Locations[0];
            if (this.IsRefLikeType)
            {
                this.DeclaringCompilation.EnsureIsByRefLikeAttributeExists(diagnostics, location, modifyCompilation: true);
            }

            if (this.IsReadOnly)
            {
                this.DeclaringCompilation.EnsureIsReadOnlyAttributeExists(diagnostics, location, modifyCompilation: true);
            }

            // https://github.com/dotnet/roslyn/issues/30080: Report diagnostics for base type and interfaces at more specific locations.
            var baseType = BaseTypeNoUseSiteDiagnostics;
            var interfaces = InterfacesNoUseSiteDiagnostics();
            if (baseType?.NeedsNullableAttribute() == true ||
                interfaces.Any(t => t.NeedsNullableAttribute()))
            {
                this.DeclaringCompilation.EnsureNullableAttributeExists(diagnostics, location, modifyCompilation: true);
            }
        }

        private void CheckMemberNamesDistinctFromType(DiagnosticBag diagnostics)
        {
            foreach (var member in GetMembersAndInitializers().NonTypeNonIndexerMembers)
            {
                CheckMemberNameDistinctFromType(member, diagnostics);
            }
        }

        private void CheckMemberNameConflicts(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void CheckSpecialMemberErrors(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void CheckTypeParameterNameConflicts(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void CheckAccessorNameConflicts(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override bool KnownCircularStruct
        {
            get
            {
                if (_lazyKnownCircularStruct == (int)ThreeState.Unknown)
                {
                    if (TypeKind != TypeKind.Struct)
                    {
                        Interlocked.CompareExchange(ref _lazyKnownCircularStruct, (int)ThreeState.False, (int)ThreeState.Unknown);
                    }
                    else
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        var value = (int)CheckStructCircularity(diagnostics).ToThreeState();

                        if (Interlocked.CompareExchange(ref _lazyKnownCircularStruct, value, (int)ThreeState.Unknown) == (int)ThreeState.Unknown)
                        {
                            AddDeclarationDiagnostics(diagnostics);
                        }

                        Debug.Assert(value == _lazyKnownCircularStruct);
                        diagnostics.Free();
                    }
                }

                return _lazyKnownCircularStruct == (int)ThreeState.True;
            }
        }

        private bool CheckStructCircularity(DiagnosticBag diagnostics)
        {
            Debug.Assert(TypeKind == TypeKind.Struct);

            CheckFiniteFlatteningGraph(diagnostics);
            return HasStructCircularity(diagnostics);
        }

        private bool HasStructCircularity(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void CheckForProtectedInStaticClass(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void CheckForUnmatchedOperators(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void CheckForUnmatchedOperator(DiagnosticBag diagnostics, string operatorName1, string operatorName2)
        {
            var ops1 = this.GetOperators(operatorName1);
            var ops2 = this.GetOperators(operatorName2);
            CheckForUnmatchedOperator(diagnostics, ops1, ops2, operatorName2);
            CheckForUnmatchedOperator(diagnostics, ops2, ops1, operatorName1);
        }

        private static void CheckForUnmatchedOperator(
            DiagnosticBag diagnostics,
            ImmutableArray<MethodSymbol> ops1,
            ImmutableArray<MethodSymbol> ops2,
            string operatorName2)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static bool DoOperatorsPair(MethodSymbol op1, MethodSymbol op2)
        {
            if (op1.ParameterCount != op2.ParameterCount)
            {
                return false;
            }

            for (int p = 0; p < op1.ParameterCount; ++p)
            {
                if (!op1.ParameterTypesWithAnnotations[p].Equals(op2.ParameterTypesWithAnnotations[p], TypeCompareKind.AllIgnoreOptions))
                {
                    return false;
                }
            }

            if (!op1.ReturnType.Equals(op2.ReturnType, TypeCompareKind.AllIgnoreOptions))
            {
                return false;
            }

            return true;
        }

        private void CheckFiniteFlatteningGraph(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static bool InfiniteFlatteningGraph(SourceMemberContainerTypeSymbol top, NamedTypeSymbol t, Dictionary<NamedTypeSymbol, NamedTypeSymbol> instanceMap)
        {
            if (!t.ContainsTypeParameter()) return false;
            NamedTypeSymbol oldInstance;
            var tOriginal = t.OriginalDefinition;
            if (instanceMap.TryGetValue(tOriginal, out oldInstance))
            {
                // short circuit when we find a cycle, but only return true when the cycle contains the top struct
                return (!TypeSymbol.Equals(oldInstance, t, TypeCompareKind.AllNullableIgnoreOptions)) && ReferenceEquals(tOriginal, top);
            }
            else
            {
                instanceMap.Add(tOriginal, t);
                try
                {
                    foreach (var m in t.GetMembersUnordered())
                    {
                        var f = m as FieldSymbol;
                        if ((object)f == null || !f.IsStatic || f.Type.TypeKind != TypeKind.Struct) continue;
                        var type = (NamedTypeSymbol)f.Type;
                        if (InfiniteFlatteningGraph(top, type, instanceMap)) return true;
                    }
                    return false;
                }
                finally
                {
                    instanceMap.Remove(tOriginal);
                }
            }
        }

        private void CheckSequentialOnPartialType(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private Dictionary<string, ImmutableArray<Symbol>> MakeAllMembers(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
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

        private class MembersAndInitializersBuilder
        {
            public readonly ArrayBuilder<Symbol> NonTypeNonIndexerMembers = ArrayBuilder<Symbol>.GetInstance();
            public readonly ArrayBuilder<ImmutableArray<FieldOrPropertyInitializer>> StaticInitializers = ArrayBuilder<ImmutableArray<FieldOrPropertyInitializer>>.GetInstance();
            public readonly ArrayBuilder<ImmutableArray<FieldOrPropertyInitializer>> InstanceInitializers = ArrayBuilder<ImmutableArray<FieldOrPropertyInitializer>>.GetInstance();
            public readonly ArrayBuilder<SyntaxReference> IndexerDeclarations = ArrayBuilder<SyntaxReference>.GetInstance();

            public int StaticSyntaxLength;
            public int InstanceSyntaxLength;

            public MembersAndInitializers ToReadOnlyAndFree()
            {
                return new MembersAndInitializers(
                    NonTypeNonIndexerMembers.ToImmutableAndFree(),
                    StaticInitializers.ToImmutableAndFree(),
                    InstanceInitializers.ToImmutableAndFree(),
                    IndexerDeclarations.ToImmutableAndFree(),
                    StaticSyntaxLength,
                    InstanceSyntaxLength);
            }

            public void Free()
            {
                NonTypeNonIndexerMembers.Free();
                StaticInitializers.Free();
                InstanceInitializers.Free();
                IndexerDeclarations.Free();
            }
        }

        private MembersAndInitializers BuildMembersAndInitializers(DiagnosticBag diagnostics)
        {
            var builder = new MembersAndInitializersBuilder();
            AddDeclaredNontypeMembers(builder, diagnostics);

            switch (TypeKind)
            {
                case TypeKind.Struct:
                    CheckForStructBadInitializers(builder, diagnostics);
                    CheckForStructDefaultConstructors(builder.NonTypeNonIndexerMembers, isEnum: false, diagnostics: diagnostics);
                    AddSynthesizedConstructorsIfNecessary(builder.NonTypeNonIndexerMembers, builder.StaticInitializers, diagnostics);
                    break;

                case TypeKind.Enum:
                    CheckForStructDefaultConstructors(builder.NonTypeNonIndexerMembers, isEnum: true, diagnostics: diagnostics);
                    AddSynthesizedConstructorsIfNecessary(builder.NonTypeNonIndexerMembers, builder.StaticInitializers, diagnostics);
                    break;

                case TypeKind.Class:
                case TypeKind.Interface:
                case TypeKind.Submission:
                    // No additional checking required.
                    AddSynthesizedConstructorsIfNecessary(builder.NonTypeNonIndexerMembers, builder.StaticInitializers, diagnostics);
                    break;

                default:
                    break;
            }

            // We already built the members and initializers on another thread, we might have detected that condition
            // during member building on this thread and bailed, which results in incomplete data in the builder.
            // In such case we have to avoid creating the instance of MemberAndInitializers since it checks the consistency
            // of the data in the builder and would fail in an assertion if we tried to construct it from incomplete builder.
            if (_lazyMembersAndInitializers != null)
            {
                builder.Free();
                return null;
            }

            return builder.ToReadOnlyAndFree();
        }

        private void AddDeclaredNontypeMembers(MembersAndInitializersBuilder builder, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal Binder GetBinder(CSharpSyntaxNode syntaxNode)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
            //return this.DeclaringCompilation.GetBinder(syntaxNode);
        }

        private static void MergePartialMembers(
            ArrayBuilder<string> memberNames,
            Dictionary<string, ImmutableArray<Symbol>> membersByName,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static void CheckInterfaceMembers(ImmutableArray<Symbol> nonTypeMembers, DiagnosticBag diagnostics)
        {
            foreach (var member in nonTypeMembers)
            {
                CheckInterfaceMember(member, diagnostics);
            }
        }

        private static void CheckInterfaceMember(Symbol member, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static void CheckForStructDefaultConstructors(
            ArrayBuilder<Symbol> members,
            bool isEnum,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void CheckForStructBadInitializers(MembersAndInitializersBuilder builder, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void AddSynthesizedConstructorsIfNecessary(ArrayBuilder<Symbol> members, ArrayBuilder<ImmutableArray<FieldOrPropertyInitializer>> staticInitializers, DiagnosticBag diagnostics)
        {
            //we're not calling the helpers on NamedTypeSymbol base, because those call
            //GetMembers and we're inside a GetMembers call ourselves (i.e. stack overflow)
            var hasInstanceConstructor = false;
            var hasParameterlessInstanceConstructor = false;
            var hasStaticConstructor = false;

            // CONSIDER: if this traversal becomes a bottleneck, the flags could be made outputs of the
            // dictionary construction process.  For now, this is more encapsulated.
            foreach (var member in members)
            {
                if (member.Kind == SymbolKind.Method)
                {
                    var method = (MethodSymbol)member;
                    switch (method.MethodKind)
                    {
                        case MethodKind.Constructor:
                            hasInstanceConstructor = true;
                            hasParameterlessInstanceConstructor = hasParameterlessInstanceConstructor || method.ParameterCount == 0;
                            break;

                        case MethodKind.StaticConstructor:
                            hasStaticConstructor = true;
                            break;
                    }
                }

                //kick out early if we've seen everything we're looking for
                if (hasInstanceConstructor && hasStaticConstructor)
                {
                    break;
                }
            }

            // NOTE: Per section 11.3.8 of the spec, "every struct implicitly has a parameterless instance constructor".
            // We won't insert a parameterless constructor for a struct if there already is one.
            // We don't expect anything to be emitted, but it should be in the symbol table.
            if ((!hasParameterlessInstanceConstructor && this.IsStructType()) || (!hasInstanceConstructor && !this.IsStatic && !this.IsInterface))
            {
                members.Add((this.TypeKind == TypeKind.Submission) ?
                    new SynthesizedSubmissionConstructor(this, diagnostics) :
                    new SynthesizedInstanceConstructor(this));
            }

            // constants don't count, since they do not exist as fields at runtime
            // NOTE: even for decimal constants (which require field initializers), 
            // we do not create .cctor here since a static constructor implicitly created for a decimal 
            // should not appear in the list returned by public API like GetMembers().
            if (!hasStaticConstructor && HasNonConstantInitializer(staticInitializers))
            {
                // Note: we don't have to put anything in the method - the binder will
                // do that when processing field initializers.
                members.Add(new SynthesizedStaticConstructor(this));
            }

            if (this.IsScriptClass)
            {
                var scriptInitializer = new SynthesizedInteractiveInitializerMethod(this, diagnostics);
                members.Add(scriptInitializer);
                var scriptEntryPoint = SynthesizedEntryPointSymbol.Create(scriptInitializer, diagnostics);
                members.Add(scriptEntryPoint);
            }
        }

        private static bool HasNonConstantInitializer(ArrayBuilder<ImmutableArray<FieldOrPropertyInitializer>> initializers)
        {
            return initializers.Any(siblings => siblings.Any(initializer => !initializer.FieldOpt.IsConst));
        }

        private void AddNonTypeMembers(
            MembersAndInitializersBuilder builder,
            SyntaxList<CSharpSyntaxNode> members,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void AddAccessorIfAvailable(ArrayBuilder<Symbol> symbols, MethodSymbol accessorOpt, DiagnosticBag diagnostics, bool checkName = false)
        {
            if ((object)accessorOpt != null)
            {
                symbols.Add(accessorOpt);
                if (checkName)
                {
                    CheckMemberNameDistinctFromType(accessorOpt, diagnostics);
                }
            }
        }

        #endregion

        #region Extension Methods

        internal bool ContainsExtensionMethods
        {
            get
            {
                if (!_lazyContainsExtensionMethods.HasValue())
                {
                    bool containsExtensionMethods = ((this.IsStatic && !this.IsGenericType) || this.IsScriptClass) && this.declaration.ContainsExtensionMethods;
                    _lazyContainsExtensionMethods = containsExtensionMethods.ToThreeState();
                }

                return _lazyContainsExtensionMethods.Value();
            }
        }

        internal bool AnyMemberHasAttributes
        {
            get
            {
                if (!_lazyAnyMemberHasAttributes.HasValue())
                {
                    bool anyMemberHasAttributes = this.declaration.AnyMemberHasAttributes;
                    _lazyAnyMemberHasAttributes = anyMemberHasAttributes.ToThreeState();
                }

                return _lazyAnyMemberHasAttributes.Value();
            }
        }

        public override bool MightContainExtensionMethods
        {
            get
            {
                return this.ContainsExtensionMethods;
            }
        }

        #endregion

        public sealed override NamedTypeSymbol ConstructedFrom
        {
            get { return this; }
        }
    }
}
