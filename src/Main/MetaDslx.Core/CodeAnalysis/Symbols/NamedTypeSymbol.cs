// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a type other than an array, a pointer, a type parameter, and dynamic.
    /// </summary>
    public abstract partial class NamedTypeSymbol : TypeSymbol, INamedTypeSymbol
    {
        private bool _hasNoBaseCycles;

        // Only the compiler can create NamedTypeSymbols.
        protected NamedTypeSymbol()
        {
        }

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Changes to the public interface of this class should remain synchronized with the VB version.
        // Do not make any changes to the public interface without making the corresponding change
        // to the VB version.
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        // TODO: How should anonymous types be represented? One possible options: have an
        // IsAnonymous on this type. The Name would then return a unique compiler-generated
        // type that matches the metadata name.

        /// <summary>
        /// Returns the type symbol that this type was constructed from. This type symbol
        /// has the same containing type (if any), but has type arguments that are the same
        /// as the type parameters (although its containing type might not).
        /// </summary>
        public abstract NamedTypeSymbol ConstructedFrom { get; }

        public override NamedTypeSymbol ContainingType
        {
            get
            {
                // we can do this since if a type does not live directly in a type
                // there is no containing type at all
                // NOTE: many derived types will override this with even better implementation
                //       since most know their containing types/symbols directly
                return this.ContainingSymbol as NamedTypeSymbol;
            }
        }

        /// <summary>
        /// Returns true for a struct type containing a cycle.
        /// This property is intended for flow analysis only
        /// since it is only implemented for source types.
        /// </summary>
        internal virtual bool KnownCircularStruct
        {
            get
            {
                return false;
            }
        }

        internal bool KnownToHaveNoDeclaredBaseCycles
        {
            get
            {
                return _hasNoBaseCycles;
            }
        }

        internal void SetKnownToHaveNoDeclaredBaseCycles()
        {
            _hasNoBaseCycles = true;
        }

        /// <summary>
        /// Get the operators for this type by their metadata name
        /// </summary>
        internal ImmutableArray<IMethodSymbol> GetOperators(string name)
        {
            ImmutableArray<Symbol> candidates = GetSimpleNonTypeMembers(name);
            if (candidates.IsEmpty)
            {
                return ImmutableArray<IMethodSymbol>.Empty;
            }

            ArrayBuilder<IMethodSymbol> operators = ArrayBuilder<IMethodSymbol>.GetInstance();
            foreach (IMethodSymbol candidate in candidates.OfType<IMethodSymbol>())
            {
                if (candidate.MethodKind == MethodKind.UserDefinedOperator || candidate.MethodKind == MethodKind.Conversion)
                {
                    operators.Add(candidate);
                }
            }

            return operators.ToImmutableAndFree();
        }

        /// <summary>
        /// Get the instance constructors for this type.
        /// </summary>
        public ImmutableArray<IMethodSymbol> InstanceConstructors
        {
            get
            {
                return GetConstructors<IMethodSymbol>(includeInstance: true, includeStatic: false);
            }
        }

        /// <summary>
        /// Get the static constructors for this type.
        /// </summary>
        public ImmutableArray<IMethodSymbol> StaticConstructors
        {
            get
            {
                return GetConstructors<IMethodSymbol>(includeInstance: false, includeStatic: true);
            }
        }

        /// <summary>
        /// Get the instance and static constructors for this type.
        /// </summary>
        public ImmutableArray<IMethodSymbol> Constructors
        {
            get
            {
                return GetConstructors<IMethodSymbol>(includeInstance: true, includeStatic: true);
            }
        }

        private ImmutableArray<TMethodSymbol> GetConstructors<TMethodSymbol>(bool includeInstance, bool includeStatic) where TMethodSymbol : class, IMethodSymbol
        {
            Debug.Assert(includeInstance || includeStatic);

            ImmutableArray<Symbol> instanceCandidates = includeInstance
                ? GetMembers(WellKnownMemberNames.InstanceConstructorName)
                : ImmutableArray<Symbol>.Empty;
            ImmutableArray<Symbol> staticCandidates = includeStatic
                ? GetMembers(WellKnownMemberNames.StaticConstructorName)
                : ImmutableArray<Symbol>.Empty;

            if (instanceCandidates.IsEmpty && staticCandidates.IsEmpty)
            {
                return ImmutableArray<TMethodSymbol>.Empty;
            }

            ArrayBuilder<TMethodSymbol> constructors = ArrayBuilder<TMethodSymbol>.GetInstance();
            foreach (Symbol candidate in instanceCandidates)
            {
                if (candidate.Kind == SymbolKind.Method)
                {
                    TMethodSymbol method = candidate as TMethodSymbol;
                    Debug.Assert((object)method != null);
                    Debug.Assert(method.MethodKind == MethodKind.Constructor);
                    constructors.Add(method);
                }
            }
            foreach (Symbol candidate in staticCandidates)
            {
                if (candidate.Kind == SymbolKind.Method)
                {
                    TMethodSymbol method = candidate as TMethodSymbol;
                    Debug.Assert((object)method != null);
                    Debug.Assert(method.MethodKind == MethodKind.StaticConstructor);
                    constructors.Add(method);
                }
            }
            return constructors.ToImmutableAndFree();
        }

        /// <summary>
        /// Returns true if this type is known to be a reference type. It is never the case that
        /// IsReferenceType and IsValueType both return true. However, for an unconstrained type
        /// parameter, IsReferenceType and IsValueType will both return false.
        /// </summary>
        public override bool IsReferenceType
        {
            get
            {
                var kind = TypeKind;
                return kind != TypeKind.Enum && kind != TypeKind.Struct && kind != TypeKind.Error;
            }
        }

        /// <summary>
        /// Returns true if this type is known to be a value type. It is never the case that
        /// IsReferenceType and IsValueType both return true. However, for an unconstrained type
        /// parameter, IsReferenceType and IsValueType will both return false.
        /// </summary>
        public override bool IsValueType
        {
            get
            {
                var kind = TypeKind;
                return kind == TypeKind.Struct || kind == TypeKind.Enum;
            }
        }

        internal override ManagedKind ManagedKind
        {
            get
            {
                // CONSIDER: we could cache this, but it's only expensive for non-special struct types
                // that are pointed to.  For now, only cache on SourceMemberContainerSymbol since it fits
                // nicely into the flags variable.
                return BaseTypeAnalysis.GetManagedKind(this);
            }
        }

        /// <summary>
        /// Gets the associated attribute usage info for an attribute type.
        /// </summary>
        internal abstract AttributeUsageInfo GetAttributeUsageInfo();

        /// <summary>
        /// Returns true if the type is a Script class. 
        /// It might be an interactive submission class or a Script class in a csx file.
        /// </summary>
        public virtual bool IsScriptClass
        {
            get
            {
                return false;
            }
        }

        internal bool IsSubmissionClass
        {
            get
            {
                return TypeKind == TypeKind.Submission;
            }
        }

        /* TODO:MetaDslx implementing IScriptSymbol
        internal SynthesizedInstanceConstructor GetScriptConstructor()
        {
            Debug.Assert(IsScriptClass);
            return (SynthesizedInstanceConstructor)InstanceConstructors.Single();
        }

        internal SynthesizedInteractiveInitializerMethod GetScriptInitializer()
        {
            Debug.Assert(IsScriptClass);
            return (SynthesizedInteractiveInitializerMethod)GetMembers(SynthesizedInteractiveInitializerMethod.InitializerName).Single();
        }

        internal SynthesizedEntryPointSymbol GetScriptEntryPoint()
        {
            Debug.Assert(IsScriptClass);
            var name = (TypeKind == TypeKind.Submission) ? SynthesizedEntryPointSymbol.FactoryName : SynthesizedEntryPointSymbol.MainName;
            return (SynthesizedEntryPointSymbol)GetMembers(name).Single();
        }*/

        /// <summary>
        /// Returns true if the type is the implicit class that holds onto invalid global members (like methods or
        /// statements in a non script file).
        /// </summary>
        public virtual bool IsImplicitClass
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the name of this symbol. Symbols without a name return the empty string; null is
        /// never returned.
        /// </summary>
        public abstract override string Name { get; }

        /// <summary>
        /// Should the name returned by Name property be mangled with [`arity] suffix in order to get metadata name.
        /// Must return False for a type with Arity == 0.
        /// </summary>
        internal abstract bool MangleName
        {
            // Intentionally no default implementation to force consideration of appropriate implementation for each new subclass
            get;
        }

        /// <summary>
        /// Collection of names of members declared within this type.
        /// </summary>
        public abstract IEnumerable<string> MemberNames { get; }

        /// <summary>
        /// Get all the members of this symbol.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol. If this symbol has no members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract override ImmutableArray<Symbol> GetMembers();

        /// <summary>
        /// Get all the members of this symbol that have a particular name.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol with the given name. If there are
        /// no members with this name, returns an empty ImmutableArray. Never returns null.</returns>
        public abstract override ImmutableArray<Symbol> GetMembers(string name);

        /// <summary>
        /// Get all the members of this symbol that have a particular name.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol with the given name. If there are
        /// no members with this name, returns an empty ImmutableArray. Never returns null.</returns>
        public abstract override ImmutableArray<Symbol> GetMembers(string name, string metadataName);

        internal virtual ImmutableArray<Symbol> GetSimpleNonTypeMembers(string name)
        {
            return GetMembers(name);
        }

        /// <summary>
        /// Get all the members of this symbol that are types.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol. If this symbol has no type members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract override ImmutableArray<NamedTypeSymbol> GetTypeMembers();

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name, of any arity.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol with the given name.
        /// If this symbol has no type members with this name,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name);

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name and arity
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol with the given name and arity.
        /// If this symbol has no type members with this name and arity,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName);

        /// <summary>
        /// Get all instance members.
        /// </summary>
        /// <remarks>
        /// For source symbols may be called while calculating
        /// <see cref="NamespaceOrTypeSymbol.GetMembersUnordered"/>.
        /// </remarks>
        internal virtual IEnumerable<Symbol> GetInstanceMembers()
        {
            return GetMembersUnordered().Where(IsInstanceMember);
        }

        /// <summary>
        /// Get all static members.
        /// </summary>
        /// <remarks>
        /// For source symbols may be called while calculating
        /// <see cref="NamespaceOrTypeSymbol.GetMembersUnordered"/>.
        /// </remarks>
        internal virtual IEnumerable<Symbol> GetStaticMembers()
        {
            return GetMembersUnordered().Where(IsStaticMember);
        }

        protected static Func<Symbol, bool> IsInstanceMember = symbol => !symbol.IsStatic;
        protected static Func<Symbol, bool> IsStaticMember = symbol => symbol.IsStatic;

        /// <summary>
        /// Get this accessibility that was declared on this symbol. For symbols that do not have
        /// accessibility declared on them, returns NotApplicable.
        /// </summary>
        public abstract override Accessibility DeclaredAccessibility { get; }

        /// <summary>
        /// Gets the kind of this symbol.
        /// </summary>
        public override SymbolKind Kind // Cannot seal this method because of the ErrorSymbol.
        {
            get
            {
                return SymbolKind.NamedType;
            }
        }

        internal abstract NamedTypeSymbol GetDeclaredBaseType(ConsList<TypeSymbol> basesBeingResolved);

        internal abstract ImmutableArray<NamedTypeSymbol> GetDeclaredInterfaces(ConsList<TypeSymbol> basesBeingResolved);

        public override int GetHashCode()
        {
            // return a distinguished value for 'object' so we can return the same value for 'dynamic'.
            // That's because the hash code ignores the distinction between dynamic and object.  It also
            // ignores custom modifiers.
            if (this.SpecialType == SpecialType.System_Object)
            {
                return (int)SpecialType.System_Object;
            }

            // OriginalDefinition must be object-equivalent.
            return RuntimeHelpers.GetHashCode(OriginalDefinition);
        }

        /// <summary>
        /// Compares this type to another type.
        /// </summary>
        internal override bool Equals(TypeSymbol t2, TypeCompareKind comparison)
        {
            if ((object)t2 == this) return true;
            if ((object)t2 == null) return false;

            if ((comparison & TypeCompareKind.IgnoreDynamic) != 0)
            {
                if (t2.TypeKind == TypeKind.Dynamic)
                {
                    // if ignoring dynamic, then treat dynamic the same as the type 'object'
                    if (this.SpecialType == SpecialType.System_Object)
                    {
                        return true;
                    }
                }
            }

            NamedTypeSymbol other = t2 as NamedTypeSymbol;
            if ((object)other == null) return false;

            // Compare OriginalDefinitions.
            var thisOriginalDefinition = this.OriginalDefinition;
            var otherOriginalDefinition = other.OriginalDefinition;

            bool thisIsOriginalDefinition = ((object)this == (object)thisOriginalDefinition);
            bool otherIsOriginalDefinition = ((object)other == (object)otherOriginalDefinition);

            if (thisIsOriginalDefinition && otherIsOriginalDefinition)
            {
                // If we continue, we either return false, or get into a cycle.
                return false;
            }

            if ((thisIsOriginalDefinition || otherIsOriginalDefinition) &&
                (comparison & (TypeCompareKind.IgnoreCustomModifiersAndArraySizesAndLowerBounds | TypeCompareKind.AllNullableIgnoreOptions)) == 0)
            {
                return false;
            }

            // CONSIDER: original definitions are not unique for missing metadata type
            // symbols.  Therefore this code may not behave correctly if 'this' is List<int>
            // where List`1 is a missing metadata type symbol, and other is similarly List<int>
            // but for a reference-distinct List`1.
            if (!TypeSymbol.Equals(thisOriginalDefinition, otherOriginalDefinition, TypeCompareKind.ConsiderEverything2))
            {
                return false;
            }

            // The checks above are supposed to handle the vast majority of cases.
            // More complicated cases are handled in a special helper to make the common case scenario simple/fast (fewer locals and smaller stack frame)
            return false; // TODO:MetaDslx: EqualsComplicatedCases(other, comparison);
        }

        /// <summary>
        /// The original definition of this symbol. If this symbol is constructed from another
        /// symbol by type substitution then OriginalDefinition gets the original symbol as it was defined in
        /// source or metadata.
        /// </summary>
        public new virtual NamedTypeSymbol OriginalDefinition
        {
            get
            {
                return this;
            }
        }

        protected override sealed TypeSymbol OriginalTypeSymbolDefinition
        {
            get
            {
                return this.OriginalDefinition;
            }
        }

        #region Use-Site Diagnostics

        internal override DiagnosticInfo GetUseSiteDiagnostic()
        {
            if (this.IsDefinition)
            {
                return base.GetUseSiteDiagnostic();
            }

            DiagnosticInfo result = null;

            // Check definition, type arguments 
            if (DeriveUseSiteDiagnosticFromType(ref result, this.OriginalDefinition))
            {
                return result;
            }

            return result;
        }

        internal DiagnosticInfo CalculateUseSiteDiagnostic()
        {
            DiagnosticInfo result = null;

            // Check base type.
            if (MergeUseSiteDiagnostics(ref result, DeriveUseSiteDiagnosticFromBase()))
            {
                return result;
            }

            // If we reach a type (Me) that is in an assembly with unified references, 
            // we check if that type definition depends on a type from a unified reference.
            if (this.ContainingModule.HasUnifiedReferences)
            {
                HashSet<TypeSymbol> unificationCheckedTypes = null;
                if (GetUnificationUseSiteDiagnosticRecursive(ref result, this, ref unificationCheckedTypes))
                {
                    return result;
                }
            }

            return result;
        }

        private DiagnosticInfo DeriveUseSiteDiagnosticFromBase()
        {
            NamedTypeSymbol @base = this.BaseTypeNoUseSiteDiagnostics;

            while ((object)@base != null)
            {
                if (@base.IsErrorType())
                {
                    return @base.GetUseSiteDiagnostic();
                }

                @base = @base.BaseTypeNoUseSiteDiagnostics;
            }

            return null;
        }

        internal override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            if (!this.MarkCheckedIfNecessary(ref checkedTypes))
            {
                return false;
            }

            Debug.Assert(owner.ContainingModule.HasUnifiedReferences);
            if (owner.ContainingModule.GetUnificationUseSiteDiagnostic(ref result, this))
            {
                return true;
            }

            // We recurse into base types, interfaces and type *parameters* to check for
            // problems with constraints. We recurse into type *arguments* in the overload
            // in ConstructedNamedTypeSymbol.
            //
            // When we are binding a name with a nested type, Goo.Bar, then we ask for
            // use-site errors to be reported on both Goo and Goo.Bar. Therefore we should
            // not recurse into the containing type here; doing so will result in errors
            // being reported twice if Goo is bad.

            var @base = this.BaseTypeNoUseSiteDiagnostics;
            if ((object)@base != null && @base.GetUnificationUseSiteDiagnosticRecursive(ref result, owner, ref checkedTypes))
            {
                return true;
            }

            return GetUnificationUseSiteDiagnosticRecursive(ref result, this.InterfacesNoUseSiteDiagnostics(), owner, ref checkedTypes);
        }

        #endregion

        /// <summary>
        /// Requires less computation than <see cref="TypeSymbol.TypeKind"/> == <see cref="TypeKind.Interface"/>.
        /// </summary>
        /// <remarks>
        /// Metadata types need to compute their base types in order to know their TypeKinds, and that can lead
        /// to cycles if base types are already being computed.
        /// </remarks>
        /// <returns>True if this is an interface type.</returns>
        internal abstract bool IsInterface { get; }

        #region INamedTypeSymbol Members

        int INamedTypeSymbol.Arity
        {
            get
            {
                return 0; // TODO:MetaDslx
            }
        }

        ImmutableArray<IMethodSymbol> INamedTypeSymbol.InstanceConstructors
        {
            get
            {
                return this.GetConstructors<IMethodSymbol>(includeInstance: true, includeStatic: false);
            }
        }

        ImmutableArray<IMethodSymbol> INamedTypeSymbol.StaticConstructors
        {
            get
            {
                return this.GetConstructors<IMethodSymbol>(includeInstance: false, includeStatic: true);
            }
        }

        ImmutableArray<IMethodSymbol> INamedTypeSymbol.Constructors
        {
            get
            {
                return this.GetConstructors<IMethodSymbol>(includeInstance: true, includeStatic: true);
            }
        }

        IEnumerable<string> INamedTypeSymbol.MemberNames
        {
            get
            {
                return this.MemberNames;
            }
        }

        ImmutableArray<ITypeParameterSymbol> INamedTypeSymbol.TypeParameters
        {
            get
            {
                return ImmutableArray<ITypeParameterSymbol>.Empty;
            }
        }

        ImmutableArray<ITypeSymbol> INamedTypeSymbol.TypeArguments
        {
            get
            {
                return ImmutableArray<ITypeSymbol>.Empty;
            }
        }

        ImmutableArray<CustomModifier> INamedTypeSymbol.GetTypeArgumentCustomModifiers(int ordinal)
        {
            return ImmutableArray<CustomModifier>.Empty;
        }

        INamedTypeSymbol INamedTypeSymbol.OriginalDefinition
        {
            get { return this.OriginalDefinition; }
        }

        IMethodSymbol INamedTypeSymbol.DelegateInvokeMethod
        {
            get
            {
                return null;
            }
        }

        INamedTypeSymbol INamedTypeSymbol.EnumUnderlyingType
        {
            get
            {
                return null;
            }
        }

        INamedTypeSymbol INamedTypeSymbol.ConstructedFrom
        {
            get
            {
                return this.ConstructedFrom;
            }
        }

        INamedTypeSymbol INamedTypeSymbol.Construct(params ITypeSymbol[] arguments)
        {
            return this;
        }

        INamedTypeSymbol INamedTypeSymbol.ConstructUnboundGenericType()
        {
            return this;
        }

        ISymbol INamedTypeSymbol.AssociatedSymbol
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Returns fields that represent tuple elements for types that are tuples.
        ///
        /// If this type is not a tuple, then returns default.
        /// </summary>
        ImmutableArray<IFieldSymbol> INamedTypeSymbol.TupleElements => ImmutableArray<IFieldSymbol>.Empty;

        /// <summary>
        /// If this is a tuple type symbol, returns the symbol for its underlying type.
        /// Otherwise, returns null.
        /// </summary>
        INamedTypeSymbol INamedTypeSymbol.TupleUnderlyingType => this;

        bool INamedTypeSymbol.IsComImport => false;

        bool INamedTypeSymbol.IsGenericType => false;

        bool INamedTypeSymbol.IsUnboundGenericType => false;

        bool INamedTypeSymbol.IsScriptClass => false;

        bool INamedTypeSymbol.IsImplicitClass => false;

        public virtual bool MightContainExtensionMethods => false;

        public virtual bool IsSerializable => false;

        #endregion

        #region ISymbol Members

        /// <summary>
        /// Returns data decoded from Obsolete attribute or null if there is no Obsolete attribute.
        /// This property returns ObsoleteAttributeData.Uninitialized if attribute arguments haven't been decoded yet.
        /// </summary>
        public override ObsoleteAttributeData ObsoleteAttributeData
        {
            get { return null; }
        }

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitNamedType(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitNamedType(this);
        }

        #endregion
    }
}
