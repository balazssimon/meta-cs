// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a named type symbol whose members are declared in source.
    /// </summary>
    public abstract partial class SourceMemberContainerTypeSymbol : NamedTypeSymbol
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
        protected readonly MergedDeclaration declaration;

        private Members _lazyMembers;
        private Dictionary<string, ImmutableArray<Symbol>> _lazyMembersDictionary;

        private static readonly Dictionary<string, ImmutableArray<NamedTypeSymbol>> s_emptyTypeMembers = new Dictionary<string, ImmutableArray<NamedTypeSymbol>>(EmptyComparer.Instance);
        private Dictionary<string, ImmutableArray<NamedTypeSymbol>> _lazyTypeMembers;
        private ImmutableArray<Symbol> _lazyMembersFlattened;
        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

        #region Construction

        internal SourceMemberContainerTypeSymbol(
            NamespaceOrTypeSymbol containingSymbol,
            MergedDeclaration declaration,
            DiagnosticBag diagnostics)
        {
            _containingSymbol = containingSymbol;
            this.declaration = declaration;

            TypeKind typeKind = TypeKind.Class; // TODO:MetaDslx declaration.Kind.ToTypeKind();
            var modifiers = MakeModifiers(typeKind, diagnostics);

            foreach (var singleDeclaration in declaration.Declarations)
            {
                diagnostics.AddRange(singleDeclaration.Diagnostics);
            }

            int access = (int)(modifiers & DeclarationModifiers.AccessibilityMask);
            if ((access & (access - 1)) != 0)
            {   // more than one access modifier
                if ((modifiers & DeclarationModifiers.Partial) != 0)
                    diagnostics.Add(InternalErrorCode.ERR_PartialModifierConflict, Locations[0], this);
                access = access & ~(access - 1); // narrow down to one access modifier
                modifiers &= ~DeclarationModifiers.AccessibilityMask; // remove them all
                modifiers |= (DeclarationModifiers)access; // except the one
            }

            var specialType = access == (int)DeclarationModifiers.Public
                ? MakeSpecialType()
                : SpecialType.None;

            _flags = new Flags(specialType, modifiers, typeKind);

            /* TODO:MetaDslx
            var containingType = this.ContainingType;
            if ((object)containingType != null && containingType.IsSealed && this.DeclaredAccessibility.HasProtected())
            {
                diagnostics.Add(AccessCheck.GetProtectedMemberInSealedTypeError(ContainingType), Locations[0], this);
            }*/

            state.NotePartComplete(CompletionPart.TypeArguments); // type arguments need not be computed separately
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

        private DeclarationModifiers MakeModifiers(TypeKind typeKind, DiagnosticBag diagnostics)
        {
            Symbol containingSymbol = this.ContainingSymbol;
            DeclarationModifiers defaultAccess;
            var allowedModifiers = DeclarationModifiers.AccessibilityMask;

            if (containingSymbol.Kind == SymbolKind.Namespace)
            {
                defaultAccess = DeclarationModifiers.Internal;
            }
            else
            {
                allowedModifiers |= DeclarationModifiers.New;

                if (((NamedTypeSymbol)containingSymbol).IsInterface)
                {
                    defaultAccess = DeclarationModifiers.Public;
                }
                else
                {
                    defaultAccess = DeclarationModifiers.Private;
                }
            }

            switch (typeKind)
            {
                case TypeKind.Class:
                case TypeKind.Submission:
                    allowedModifiers |= DeclarationModifiers.Partial | DeclarationModifiers.Static | DeclarationModifiers.Sealed | DeclarationModifiers.Abstract | DeclarationModifiers.Unsafe;
                    break;
                case TypeKind.Struct:
                    allowedModifiers |= DeclarationModifiers.Partial | DeclarationModifiers.Ref | DeclarationModifiers.ReadOnly | DeclarationModifiers.Unsafe;
                    break;
                case TypeKind.Interface:
                    allowedModifiers |= DeclarationModifiers.Partial | DeclarationModifiers.Unsafe;
                    break;
                case TypeKind.Delegate:
                    allowedModifiers |= DeclarationModifiers.Unsafe;
                    break;
            }

            bool modifierErrors;
            var mods = MakeAndCheckTypeModifiers(
                defaultAccess,
                allowedModifiers,
                this,
                diagnostics,
                out modifierErrors);

            if (!modifierErrors &&
                (mods & DeclarationModifiers.Abstract) != 0 &&
                (mods & (DeclarationModifiers.Sealed | DeclarationModifiers.Static)) != 0)
            {
                diagnostics.Add(InternalErrorCode.ERR_AbstractSealedStatic, Locations[0], this);
            }

            if (!modifierErrors &&
                (mods & (DeclarationModifiers.Sealed | DeclarationModifiers.Static)) == (DeclarationModifiers.Sealed | DeclarationModifiers.Static))
            {
                diagnostics.Add(InternalErrorCode.ERR_SealedStaticClass, Locations[0], this);
            }

            switch (typeKind)
            {
                case TypeKind.Interface:
                    mods |= DeclarationModifiers.Abstract;
                    break;
                case TypeKind.Struct:
                case TypeKind.Enum:
                    mods |= DeclarationModifiers.Sealed;
                    break;
                case TypeKind.Delegate:
                    mods |= DeclarationModifiers.Sealed;
                    break;
            }

            return mods;
        }

        private DeclarationModifiers MakeAndCheckTypeModifiers(
            DeclarationModifiers defaultAccess,
            DeclarationModifiers allowedModifiers,
            SourceMemberContainerTypeSymbol self,
            DiagnosticBag diagnostics,
            out bool modifierErrors)
        {
            modifierErrors = false;
            var result = DeclarationModifiers.Unset;
            /* TODO:MetaDslx
            var partCount = declaration.Declarations.Length;
            var missingPartial = false;

            for (var i = 0; i < partCount; i++)
            {
                var decl = declaration.Declarations[i];
                var mods = decl.Modifiers;

                if (partCount > 1 && (mods & DeclarationModifiers.Partial) == 0)
                {
                    missingPartial = true;
                }

                if (!modifierErrors)
                {
                    mods = ModifierUtils.CheckModifiers(
                        mods, allowedModifiers, declaration.Declarations[i].NameLocation, diagnostics,
                        modifierTokens: null, modifierErrors: out modifierErrors);

                    // It is an error for the same modifier to appear multiple times.
                    if (!modifierErrors)
                    {
                        var info = ModifierUtils.CheckAccessibility(mods, this, isExplicitInterfaceImplementation: false);
                        if (info != null)
                        {
                            diagnostics.Add(info, self.Locations[0]);
                            modifierErrors = true;
                        }
                    }
                }

                if (result == DeclarationModifiers.Unset)
                {
                    result = mods;
                }
                else
                {
                    result |= mods;
                }

            }

            if ((result & DeclarationModifiers.AccessibilityMask) == 0)
            {
                result |= defaultAccess;
            }

            if (missingPartial)
            {
                if ((result & DeclarationModifiers.Partial) == 0)
                {
                    // duplicate definitions
                    switch (self.ContainingSymbol.Kind)
                    {
                        case SymbolKind.Namespace:
                            for (var i = 1; i < partCount; i++)
                            {
                                diagnostics.Add(ErrorCode.ERR_DuplicateNameInNS, declaration.Declarations[i].NameLocation, self.Name, self.ContainingSymbol);
                                modifierErrors = true;
                            }
                            break;

                        case SymbolKind.NamedType:
                            for (var i = 1; i < partCount; i++)
                            {
                                if (ContainingType.Locations.Length == 1 || ContainingType.IsPartial())
                                    diagnostics.Add(ErrorCode.ERR_DuplicateNameInClass, declaration.Declarations[i].NameLocation, self.ContainingSymbol, self.Name);
                                modifierErrors = true;
                            }
                            break;
                    }
                }
                else
                {
                    for (var i = 0; i < partCount; i++)
                    {
                        var singleDeclaration = declaration.Declarations[i];
                        var mods = singleDeclaration.Modifiers;
                        if ((mods & DeclarationModifiers.Partial) == 0)
                        {
                            diagnostics.Add(ErrorCode.ERR_MissingPartial, singleDeclaration.NameLocation, self.Name);
                            modifierErrors = true;
                        }
                    }
                }
            }
            */
            return result;
        }

        #endregion

        #region Completion

        public sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        public sealed override bool HasComplete(CompletionPart part)
        {
            return state.HasComplete(part);
        }

        protected abstract void CheckBase(DiagnosticBag diagnostics);
        protected abstract void CheckInterfaces(DiagnosticBag diagnostics);

        public override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("TODO:MetaDslx");
            /*
            while (true)
            {
                // NOTE: cases that depend on GetMembers[ByName] should call RequireCompletionPartMembers.
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = state.NextIncompletePart;
                switch (incompletePart)
                {
                    case CompletionPart.Attributes:
                        GetAttributes();
                        break;

                    case CompletionPart.StartBaseType:
                    case CompletionPart.FinishBaseType:
                        if (state.NotePartComplete(CompletionPart.StartBaseType))
                        {
                            var diagnostics = DiagnosticBag.GetInstance();
                            CheckBase(diagnostics);
                            AddDeclarationDiagnostics(diagnostics);
                            state.NotePartComplete(CompletionPart.FinishBaseType);
                            diagnostics.Free();
                        }
                        break;

                    case CompletionPart.StartInterfaces:
                    case CompletionPart.FinishInterfaces:
                        if (state.NotePartComplete(CompletionPart.StartInterfaces))
                        {
                            var diagnostics = DiagnosticBag.GetInstance();
                            CheckInterfaces(diagnostics);
                            AddDeclarationDiagnostics(diagnostics);
                            state.NotePartComplete(CompletionPart.FinishInterfaces);
                            diagnostics.Free();
                        }
                        break;

                    case CompletionPart.EnumUnderlyingType:
                        var discarded = this.EnumUnderlyingType;
                        break;

                    case CompletionPart.TypeArguments:
                        {
                            var tmp = this.TypeArgumentsWithAnnotationsNoUseSiteDiagnostics; // force type arguments
                        }
                        break;

                    case CompletionPart.TypeParameters:
                        // force type parameters
                        foreach (var typeParameter in this.TypeParameters)
                        {
                            typeParameter.ForceComplete(locationOpt, cancellationToken);
                        }

                        state.NotePartComplete(CompletionPart.TypeParameters);
                        break;

                    case CompletionPart.Members:
                        this.GetMembersByName();
                        break;

                    case CompletionPart.TypeMembers:
                        this.GetTypeMembersUnordered();
                        break;

                    case CompletionPart.SynthesizedExplicitImplementations:
                        this.GetSynthesizedExplicitImplementations(cancellationToken); //force interface and base class errors to be checked
                        break;

                    case CompletionPart.StartMemberChecks:
                    case CompletionPart.FinishMemberChecks:
                        if (state.NotePartComplete(CompletionPart.StartMemberChecks))
                        {
                            var diagnostics = DiagnosticBag.GetInstance();
                            AfterMembersChecks(diagnostics);
                            AddDeclarationDiagnostics(diagnostics);

                            // We may produce a SymbolDeclaredEvent for the enclosing type before events for its contained members
                            DeclaringCompilation.SymbolDeclaredEvent(this);
                            var thisThreadCompleted = state.NotePartComplete(CompletionPart.FinishMemberChecks);
                            Debug.Assert(thisThreadCompleted);
                            diagnostics.Free();
                        }
                        break;

                    case CompletionPart.MembersCompleted:
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
                                state.SpinWaitComplete(allParts, cancellationToken);
                                return;
                            }

                            EnsureFieldDefinitionsNoted();

                            // We've completed all members, so we're ready for the PointedAtManagedTypeChecks;
                            // proceed to the next iteration.
                            state.NotePartComplete(CompletionPart.MembersCompleted);
                            break;
                        }

                    case CompletionPart.None:
                        return;

                    default:
                        // This assert will trigger if we forgot to handle any of the completion parts
                        Debug.Assert((incompletePart & CompletionPart.NamedTypeSymbolAll) == 0);
                        // any other values are completion parts intended for other kinds of symbols
                        state.NotePartComplete(CompletionPart.All & ~CompletionPart.NamedTypeSymbolAll);
                        break;
                }

                state.SpinWaitComplete(incompletePart, cancellationToken);
            }

            throw ExceptionUtilities.Unreachable;*/
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

        public override ModelSymbolInfo ModelSymbolInfo
        {
            get
            {
                return this.declaration.Kind;
            }
        }

        internal MergedDeclaration MergedDeclaration
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

        public override bool IsPartial
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
                return Accessibility.Public;
                // TODO:MetaDslx return ModifierUtils.EffectiveAccessibility(_flags.DeclarationModifiers);
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
                return false; // TODO:MetaDslx
                /*var kind = this.declaration.Declarations[0].Kind;
                return kind == DeclarationKind.Script || kind == DeclarationKind.Submission;*/
            }
        }

        public override bool IsImplicitClass
        {
            get
            {
                return false; // TODO:MetaDslx
                //return this.declaration.Declarations[0].Kind == DeclarationKind.ImplicitClass;
            }
        }

        public override bool IsImplicitlyDeclared
        {
            get
            {
                return IsImplicitClass || IsScriptClass;
            }
        }

        public override string MetadataName
        {
            get
            {
                return declaration.MetadataName;
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
                return this.MetadataName != this.Name;
            }
        }

        public override LexicalSortKey GetLexicalSortKey()
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
                return declaration.NameLocations;
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
        public override bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken)
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
            get { return this.declaration.ChildNames; }
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

                    state.NotePartComplete(CompletionPart.TypeMembers);
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
                foreach (var childDeclaration in declaration.Children)
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

        public override ImmutableArray<Symbol> GetMembers()
        {
            if (_flags.FlattenedMembersIsSorted)
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

                _flags.SetFlattenedMembersIsSorted();
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

        internal override ImmutableArray<Symbol> GetSimpleNonTypeMembers(string name)
        {
            if (_lazyMembersDictionary != null || declaration.ChildNames.Contains(name))
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

        internal override IEnumerable<Symbol> GetInstanceMembers()
        {
            var members = this.GetMembersForLookup();
            return members.NonTypeMembers.Where(IsInstanceMember); 
        }

        internal override IEnumerable<Symbol> GetStaticMembers()
        {
            var members = this.GetMembersForLookup();
            return members.NonTypeMembers.Where(IsStaticMember);
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
            return new SourceMemberSymbol(this, declaration, diagnostics);
        }

        private void AddDeclaredTypeMembers(ArrayBuilder<NamedTypeSymbol> builder, DiagnosticBag diagnostics)
        {
            foreach (var decl in this.declaration.Children)
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
            foreach (var decl in this.declaration.Children)
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
                    if (!symbol.IsPartial)
                    {
                        continue; // only partial methods need to be merged
                    }

                    Symbol prev;
                    if (symbolMap.TryGetValue(symbol, out prev))
                    {
                        var prevPart = (IPartialSymbol)prev;
                        var symbolPart = (IPartialSymbol)symbol;

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
                    var symbolPart = (IPartialSymbol)symbol;
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
        private ImmutableArray<Symbol> FixPartialMember(ImmutableArray<Symbol> symbols, IPartialSymbol part1, IPartialSymbol part2)
        {
            IPartialSymbol definition;
            IPartialSymbol implementation;
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

        protected virtual void InitializePartialSymbolParts(IPartialSymbol definition, IPartialSymbol implementation)
        {
            // TODO:MetaDslx:
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

        public sealed override NamedTypeSymbol ConstructedFrom
        {
            get { return this; }
        }
    }
}
