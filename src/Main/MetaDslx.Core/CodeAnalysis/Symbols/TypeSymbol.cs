// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// A TypeSymbol is a base class for all the symbols that represent a type
    /// in C#.
    /// </summary>
    public abstract partial class TypeSymbol : NamespaceOrTypeSymbol, ITypeSymbol
    {
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Changes to the public interface of this class should remain synchronized with the VB version.
        // Do not make any changes to the public interface without making the corresponding change
        // to the VB version.
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        // TODO (tomat): Consider changing this to an empty name. This name shouldn't ever leak to the user in error messages.
        internal const string ImplicitTypeName = "<invalid-global-code>";

        // InterfaceInfo for a common case of a type not implementing anything directly or indirectly.
        private static readonly InterfaceInfo s_noInterfaces = new InterfaceInfo();

        private ImmutableHashSet<Symbol> _lazyAbstractMembers;
        private InterfaceInfo _lazyInterfaceInfo;

        private class InterfaceInfo
        {
            // all directly implemented interfaces, their bases and all interfaces to the bases of the type recursively
            internal ImmutableArray<NamedTypeSymbol> allInterfaces;

            /// <summary>
            /// <see cref="TypeSymbol.InterfacesAndTheirBaseInterfacesNoUseSiteDiagnostics"/>
            /// </summary>
            internal MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> interfacesAndTheirBaseInterfaces;

            internal readonly static MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> EmptyInterfacesAndTheirBaseInterfaces =
                                                new MultiDictionary<NamedTypeSymbol, NamedTypeSymbol>(0, EqualsCLRSignatureComparer);

            // Key is implemented member (method, property, or event), value is implementing member (from the 
            // perspective of this type).  Don't allocate until someone needs it.
            private ConcurrentDictionary<Symbol, SymbolAndDiagnostics> _implementationForInterfaceMemberMap;

            public ConcurrentDictionary<Symbol, SymbolAndDiagnostics> ImplementationForInterfaceMemberMap
            {
                get
                {
                    var map = _implementationForInterfaceMemberMap;
                    if (map != null)
                    {
                        return map;
                    }

                    // PERF: Avoid over-allocation. In many cases, there's only 1 entry and we don't expect concurrent updates.
                    map = new ConcurrentDictionary<Symbol, SymbolAndDiagnostics>(concurrencyLevel: 1, capacity: 1);
                    return Interlocked.CompareExchange(ref _implementationForInterfaceMemberMap, map, null) ?? map;
                }
            }

            /// <summary>
            /// key = interface method/property/event compared using <see cref="ExplicitInterfaceImplementationTargetMemberEqualityComparer"/>,
            /// value = explicitly implementing methods/properties/events declared on this type (normally a single value, multiple in case of
            /// an error).
            /// </summary>
            internal MultiDictionary<Symbol, Symbol> explicitInterfaceImplementationMap;

            internal bool IsDefaultValue()
            {
                return allInterfaces.IsDefault &&
                    interfacesAndTheirBaseInterfaces == null &&
                    _implementationForInterfaceMemberMap == null &&
                    explicitInterfaceImplementationMap == null;
            }
        }

        private InterfaceInfo GetInterfaceInfo()
        {
            var info = _lazyInterfaceInfo;
            if (info != null)
            {
                Debug.Assert(info != s_noInterfaces || info.IsDefaultValue(), "default value was modified");
                return info;
            }

            for (var baseType = this; !ReferenceEquals(baseType, null); baseType = baseType.BaseTypeNoUseSiteDiagnostics)
            {
                var interfaces = baseType.InterfacesNoUseSiteDiagnostics();
                if (!interfaces.IsEmpty)
                {
                    // it looks like we or one of our bases implements something.
                    info = new InterfaceInfo();

                    // NOTE: we are assigning lazyInterfaceInfo via interlocked not for correctness, 
                    // we just do not want to override an existing info that could be partially filled.
                    return Interlocked.CompareExchange(ref _lazyInterfaceInfo, info, null) ?? info;
                }
            }

            // if we have got here it means neither we nor our bases implement anything
            _lazyInterfaceInfo = info = s_noInterfaces;
            return info;
        }

        internal static readonly EqualityComparer<TypeSymbol> EqualsConsiderEverything = new TypeSymbolComparer(TypeCompareKind.ConsiderEverything);

        internal static readonly EqualityComparer<TypeSymbol> EqualsIgnoringTupleNamesAndNullability = new TypeSymbolComparer(TypeCompareKind.IgnoreTupleNames | TypeCompareKind.IgnoreNullableModifiersForReferenceTypes);

        /// <summary>
        /// A comparer that treats dynamic and object as "the same" types, and also ignores tuple element names differences.
        /// </summary>
        internal static readonly EqualityComparer<TypeSymbol> EqualsIgnoringDynamicTupleNamesAndNullabilityComparer = new TypeSymbolComparer(TypeCompareKind.IgnoreDynamicAndTupleNames | TypeCompareKind.IgnoreNullableModifiersForReferenceTypes);

        internal static readonly EqualityComparer<TypeSymbol> EqualsIgnoringNullableComparer = new TypeSymbolComparer(TypeCompareKind.IgnoreNullableModifiersForReferenceTypes);

        internal static readonly EqualityComparer<TypeSymbol> EqualsAllIgnoreOptionsPlusNullableWithUnknownMatchesAnyComparer =
                                                                  new TypeSymbolComparer(TypeCompareKind.AllIgnoreOptions & ~(TypeCompareKind.IgnoreNullableModifiersForReferenceTypes));

        internal static readonly EqualityComparer<TypeSymbol> EqualsCLRSignatureComparer = new TypeSymbolComparer(TypeCompareKind.CLRSignatureCompareOptions);
        /// <summary>
        /// The original definition of this symbol. If this symbol is constructed from another
        /// symbol by type substitution then OriginalDefinition gets the original symbol as it was defined in
        /// source or metadata.
        /// </summary>
        public new TypeSymbol OriginalDefinition
        {
            get
            {
                return OriginalTypeSymbolDefinition;
            }
        }

        protected virtual TypeSymbol OriginalTypeSymbolDefinition
        {
            get
            {
                return this;
            }
        }

        protected override sealed Symbol OriginalSymbolDefinition
        {
            get
            {
                return this.OriginalTypeSymbolDefinition;
            }
        }

        /// <summary>
        /// Gets the BaseType of this type. If the base type could not be determined, then 
        /// an instance of ErrorType is returned. If this kind of type does not have a base type
        /// (for example, interfaces), null is returned. Also the special class System.Object
        /// always has a BaseType of null.
        /// </summary>
        internal abstract NamedTypeSymbol BaseTypeNoUseSiteDiagnostics { get; }

        internal NamedTypeSymbol BaseTypeWithDefinitionUseSiteDiagnostics(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var result = BaseTypeNoUseSiteDiagnostics;

            if ((object)result != null)
            {
                result.OriginalDefinition.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            }

            return result;
        }

        internal NamedTypeSymbol BaseTypeOriginalDefinition(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var result = BaseTypeNoUseSiteDiagnostics;

            if ((object)result != null)
            {
                result = result.OriginalDefinition;
                result.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            }

            return result;
        }

        /// <summary>
        /// Gets the set of interfaces that this type directly implements. This set does not include
        /// interfaces that are base interfaces of directly implemented interfaces.
        /// </summary>
        internal abstract ImmutableArray<NamedTypeSymbol> InterfacesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null);

        /// <summary>
        /// The list of all interfaces of which this type is a declared subtype, excluding this type
        /// itself. This includes all declared base interfaces, all declared base interfaces of base
        /// types, and all declared base interfaces of those results (recursively).  Each result
        /// appears exactly once in the list. This list is topologically sorted by the inheritance
        /// relationship: if interface type A extends interface type B, then A precedes B in the
        /// list. This is not quite the same as "all interfaces of which this type is a proper
        /// subtype" because it does not take into account variance: AllInterfaces for
        /// IEnumerable&lt;string&gt; will not include IEnumerable&lt;object&gt;
        /// </summary>
        internal ImmutableArray<NamedTypeSymbol> AllInterfacesNoUseSiteDiagnostics
        {
            get
            {
                return GetAllInterfaces();
            }
        }

        internal ImmutableArray<NamedTypeSymbol> AllInterfacesWithDefinitionUseSiteDiagnostics(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var result = AllInterfacesNoUseSiteDiagnostics;

            // Since bases affect content of AllInterfaces set, we need to make sure they all are good.
            var current = this;

            do
            {
                current = current.BaseTypeWithDefinitionUseSiteDiagnostics(ref useSiteDiagnostics);
            }
            while ((object)current != null);

            foreach (var iface in result)
            {
                iface.OriginalDefinition.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            }

            return result;
        }

        /// <summary>
        /// If this is a type parameter returns its effective base class, otherwise returns this type.
        /// </summary>
        internal TypeSymbol EffectiveTypeNoUseSiteDiagnostics
        {
            get
            {
                return this;
            }
        }

        internal TypeSymbol EffectiveType(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return this;
        }

        /// <summary>
        /// Returns true if this type derives from a given type.
        /// </summary>
        internal bool IsDerivedFrom(TypeSymbol type, TypeCompareKind comparison, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert((object)type != null);

            if ((object)this == (object)type)
            {
                return false;
            }

            var t = this.BaseTypeWithDefinitionUseSiteDiagnostics(ref useSiteDiagnostics);
            while ((object)t != null)
            {
                if (type.Equals(t, comparison))
                {
                    return true;
                }

                t = t.BaseTypeWithDefinitionUseSiteDiagnostics(ref useSiteDiagnostics);
            }

            return false;
        }

        /// <summary>
        /// Returns true if this type is equal or derives from a given type.
        /// </summary>
        internal bool IsEqualToOrDerivedFrom(TypeSymbol type, TypeCompareKind comparison, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return this.Equals(type, comparison) || this.IsDerivedFrom(type, comparison, ref useSiteDiagnostics);
        }

        /// <summary>
        /// Determines if this type symbol represent the same type as another, according to the language
        /// semantics.
        /// </summary>
        /// <param name="t2">The other type.</param>
        /// <param name="compareKind">
        /// What kind of comparison to use? 
        /// You can ignore custom modifiers, ignore the distinction between object and dynamic, or ignore tuple element names differences.
        /// </param>
        /// <returns>True if the types are equivalent.</returns>
        internal virtual bool Equals(TypeSymbol t2, TypeCompareKind compareKind = TypeCompareKind.ConsiderEverything)
        {
            return ReferenceEquals(this, t2);
        }

        public sealed override bool Equals(object obj)
        {
            var t2 = obj as TypeSymbol;
            if ((object)t2 == null) return false;
            return this.Equals(t2, TypeCompareKind.ConsiderEverything);
        }

        /// <summary>
        /// We ignore custom modifiers, and the distinction between dynamic and object, when computing a type's hash code.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }

        internal sealed class TypeSymbolComparer : EqualityComparer<TypeSymbol>
        {
            private readonly TypeCompareKind _comparison;

            public TypeSymbolComparer(TypeCompareKind comparison)
            {
                _comparison = comparison;
            }

            public override int GetHashCode(TypeSymbol obj)
            {
                return (object)obj == null ? 0 : obj.GetHashCode();
            }

            public override bool Equals(TypeSymbol x, TypeSymbol y)
            {
                return
                    (object)x == null ? (object)y == null :
                    x.Equals(y, _comparison);
            }
        }

        protected virtual ImmutableArray<NamedTypeSymbol> GetAllInterfaces()
        {
            var info = this.GetInterfaceInfo();
            if (info == s_noInterfaces)
            {
                return ImmutableArray<NamedTypeSymbol>.Empty;
            }

            if (info.allInterfaces.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref info.allInterfaces, MakeAllInterfaces());
            }

            return info.allInterfaces;
        }

        /// Produce all implemented interfaces in topologically sorted order. We use
        /// TypeSymbol.Interfaces as the source of edge data, which has had cycles and infinitely
        /// long dependency cycles removed. Consequently, it is possible (and we do) use the
        /// simplest version of Tarjan's topological sorting algorithm.
        protected virtual ImmutableArray<NamedTypeSymbol> MakeAllInterfaces()
        {
            var result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            var visited = new HashSet<NamedTypeSymbol>();

            for (var baseType = this; !ReferenceEquals(baseType, null); baseType = baseType.BaseTypeNoUseSiteDiagnostics)
            {
                var interfaces = baseType.InterfacesNoUseSiteDiagnostics();
                for (int i = interfaces.Length - 1; i >= 0; i--)
                {
                    AddAllInterfaces(interfaces[i], visited, result);
                }
            }

            result.ReverseContents();
            return result.ToImmutableAndFree();
        }

        private static void AddAllInterfaces(NamedTypeSymbol @interface, HashSet<NamedTypeSymbol> visited, ArrayBuilder<NamedTypeSymbol> result)
        {
            if (visited.Add(@interface))
            {
                ImmutableArray<NamedTypeSymbol> baseInterfaces = @interface.InterfacesNoUseSiteDiagnostics();
                for (int i = baseInterfaces.Length - 1; i >= 0; i--)
                {
                    var baseInterface = baseInterfaces[i];
                    AddAllInterfaces(baseInterface, visited, result);
                }

                result.Add(@interface);
            }
        }

        /// <summary>
        /// Gets the set of interfaces that this type directly implements, plus the base interfaces
        /// of all such types. Keys are compared using <see cref="EqualsCLRSignatureComparer"/>,
        /// values are distinct interfaces corresponding to the key, according to <see cref="TypeCompareKind.ConsiderEverything"/> rules.
        /// </summary>
        /// <remarks>
        /// CONSIDER: it probably isn't truly necessary to cache this.  If space gets tight, consider
        /// alternative approaches (recompute every time, cache on the side, only store on some types,
        /// etc).
        /// </remarks>
        internal MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> InterfacesAndTheirBaseInterfacesNoUseSiteDiagnostics
        {
            get
            {
                var info = this.GetInterfaceInfo();
                if (info == s_noInterfaces)
                {
                    Debug.Assert(InterfaceInfo.EmptyInterfacesAndTheirBaseInterfaces.IsEmpty);
                    return InterfaceInfo.EmptyInterfacesAndTheirBaseInterfaces;
                }

                if (info.interfacesAndTheirBaseInterfaces == null)
                {
                    Interlocked.CompareExchange(ref info.interfacesAndTheirBaseInterfaces, MakeInterfacesAndTheirBaseInterfaces(this.InterfacesNoUseSiteDiagnostics()), null);
                }

                return info.interfacesAndTheirBaseInterfaces;
            }
        }

        internal MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> InterfacesAndTheirBaseInterfacesWithDefinitionUseSiteDiagnostics(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var result = InterfacesAndTheirBaseInterfacesNoUseSiteDiagnostics;

            foreach (var iface in result.Keys)
            {
                iface.OriginalDefinition.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            }

            return result;
        }

        // Note: Unlike MakeAllInterfaces, this doesn't need to be virtual. It depends on
        // AllInterfaces for its implementation, so it will pick up all changes to MakeAllInterfaces
        // indirectly.
        private static MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> MakeInterfacesAndTheirBaseInterfaces(ImmutableArray<NamedTypeSymbol> declaredInterfaces)
        {
            var resultBuilder = new MultiDictionary<NamedTypeSymbol, NamedTypeSymbol>(declaredInterfaces.Length, EqualsCLRSignatureComparer);
            foreach (var @interface in declaredInterfaces)
            {
                if (resultBuilder.Add(@interface, @interface))
                {
                    foreach (var baseInterface in @interface.AllInterfacesNoUseSiteDiagnostics)
                    {
                        resultBuilder.Add(baseInterface, baseInterface);
                    }
                }
            }

            return resultBuilder;
        }

        /// <summary>
        /// Returns the corresponding symbol in this type or a base type that implements 
        /// interfaceMember (either implicitly or explicitly), or null if no such symbol exists
        /// (which might be either because this type doesn't implement the container of
        /// interfaceMember, or this type doesn't supply a member that successfully implements
        /// interfaceMember).
        /// </summary>
        /// <param name="interfaceMember">
        /// Must be a non-null interface property, method, or event.
        /// </param>
        public Symbol FindImplementationForInterfaceMember(Symbol interfaceMember)
        {
            if ((object)interfaceMember == null)
            {
                throw new ArgumentNullException(nameof(interfaceMember));
            }

            throw new NotImplementedException("TODO:MetaDslx");
            /* 
            if (!interfaceMember.IsImplementableInterfaceMember())
            {
                return null;
            }

            if (this.IsInterfaceType())
            {
                return FindMostSpecificImplementation(interfaceMember, (NamedTypeSymbol)this);
            }

            return FindImplementationForInterfaceMemberInNonInterfaceWithDiagnostics(interfaceMember).Symbol;*/
        }

        /// <summary>
        /// Returns true if this type is known to be a reference type. It is never the case that
        /// IsReferenceType and IsValueType both return true. However, for an unconstrained type
        /// parameter, IsReferenceType and IsValueType will both return false.
        /// </summary>
        public abstract bool IsReferenceType { get; }

        /// <summary>
        /// Returns true if this type is known to be a value type. It is never the case that
        /// IsReferenceType and IsValueType both return true. However, for an unconstrained type
        /// parameter, IsReferenceType and IsValueType will both return false.
        /// </summary>
        public abstract bool IsValueType { get; }

        // Only the compiler can create TypeSymbols.
        internal TypeSymbol()
        {
        }

        /// <summary>
        /// Gets the kind of this type.
        /// </summary>
        public abstract TypeKind TypeKind { get; }

        /// <summary>
        /// Gets corresponding special TypeId of this type.
        /// </summary>
        /// <remarks>
        /// Not preserved in types constructed from this one.
        /// </remarks>
        public virtual SpecialType SpecialType
        {
            get
            {
                return SpecialType.None;
            }
        }

        /// <summary>
        /// Gets corresponding primitive type code for this type declaration.
        /// </summary>
        internal Microsoft.Cci.PrimitiveTypeCode PrimitiveTypeCode
        {
            get
            {
                return SpecialTypes.GetTypeCode(SpecialType);
            }
        }

        #region Use-Site Diagnostics

        /// <summary>
        /// Return error code that has highest priority while calculating use site error for this symbol. 
        /// </summary>
        protected override ErrorCode HighestPriorityUseSiteError
        {
            get
            {
                return InternalErrorCode.ERR_BogusType;
            }
        }


        public sealed override bool HasUnsupportedMetadata
        {
            get
            {
                DiagnosticInfo info = GetUseSiteDiagnostic();
                return (object)info != null && info.GetErrorCode() == InternalErrorCode.ERR_BogusType;
            }
        }

        internal abstract bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes);

        #endregion

        /// <summary>
        /// Is this a symbol for an anonymous type (including delegate).
        /// </summary>
        public virtual bool IsAnonymousType
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Is this a symbol for a Tuple.
        /// </summary>
        public virtual bool IsTupleType => false;

        /// <summary>
        /// Verify if the given type can be used to back a tuple type 
        /// and return cardinality of that tuple type in <paramref name="tupleCardinality"/>. 
        /// </summary>
        /// <param name="tupleCardinality">If method returns true, contains cardinality of the compatible tuple type.</param>
        /// <returns></returns>
        public virtual bool IsTupleCompatible(out int tupleCardinality)
        {
            tupleCardinality = 0;
            return false;
        }

        /// <summary>
        /// Verify if the given type can be used to back a tuple type. 
        /// </summary>
        public bool IsTupleCompatible()
        {
            int countOfItems;
            return IsTupleCompatible(out countOfItems);
        }
        
        /// <summary>
        /// If this is a tuple type symbol, returns the symbol for its underlying type.
        /// Otherwise, returns null.
        /// The type argument corresponding to the type of the extension field (VT[8].Rest),
        /// which is at the 8th (one based) position is always a symbol for another tuple, 
        /// rather than its underlying type.
        /// </summary>
        public virtual NamedTypeSymbol TupleUnderlyingType
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// If this symbol represents a tuple type, get the names of the tuple's elements.
        /// </summary>
        public virtual ImmutableArray<string> TupleElementNames => default(ImmutableArray<string>);

        /// <summary>
        /// Is this type a managed type (false for everything but enum, pointer, and
        /// some struct types).
        /// </summary>
        /// <remarks>
        /// See Type::computeManagedType.
        /// </remarks>
        internal bool IsManagedType => ManagedKind == ManagedKind.Managed;

        /// <summary>
        /// Indicates whether a type is managed or not (i.e. you can take a pointer to it).
        /// Contains additional cases to help implement FeatureNotAvailable diagnostics.
        /// </summary>
        internal abstract ManagedKind ManagedKind { get; }

        bool ITypeSymbol.IsUnmanagedType => !IsManagedType;

        /// <summary>
        /// Returns true if the type may contain embedded references
        /// </summary>
        public abstract bool IsRefLikeType { get; }

        /// <summary>
        /// Returns true if the type is a readonly struct
        /// </summary>
        public abstract bool IsReadOnly { get; }

        #region ITypeSymbol Members

        INamedTypeSymbol ITypeSymbol.BaseType
        {
            get
            {
                return this.BaseTypeNoUseSiteDiagnostics;
            }
        }

        ImmutableArray<INamedTypeSymbol> ITypeSymbol.Interfaces
        {
            get
            {
                return StaticCast<INamedTypeSymbol>.From(this.InterfacesNoUseSiteDiagnostics());
            }
        }

        ImmutableArray<INamedTypeSymbol> ITypeSymbol.AllInterfaces
        {
            get
            {
                return StaticCast<INamedTypeSymbol>.From(this.AllInterfacesNoUseSiteDiagnostics);
            }
        }

        bool ITypeSymbol.IsReferenceType
        {
            get
            {
                return this.IsReferenceType;
            }
        }

        bool ITypeSymbol.IsValueType
        {
            get
            {
                return this.IsValueType;
            }
        }

        ITypeSymbol ITypeSymbol.OriginalDefinition
        {
            get
            {
                return this.OriginalDefinition;
            }
        }

        TypeKind ITypeSymbol.TypeKind
        {
            get
            {
                return TypeKind;
            }
        }

        ISymbol ITypeSymbol.FindImplementationForInterfaceMember(ISymbol interfaceMember)
        {
            return null;
        }

        /// <summary>
        /// Is this a symbol for a Tuple.
        /// </summary>
        bool ITypeSymbol.IsTupleType => this.IsTupleType;

        #endregion

        public static bool Equals(TypeSymbol left, TypeSymbol right, TypeCompareKind comparison)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right, comparison);
        }

    }
}
