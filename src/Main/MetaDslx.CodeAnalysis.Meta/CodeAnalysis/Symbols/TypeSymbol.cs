using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Symbols;
using Roslyn.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SubSymbolKindType = "TypeKind")]
    public abstract partial class TypeSymbol : NamespaceOrTypeSymbol
    {
        // TODO (tomat): Consider changing this to an empty name. This name shouldn't ever leak to the user in error messages.
        internal const string ImplicitTypeName = "<invalid-global-code>";


        // InterfaceInfo for a common case of a type not implementing anything directly or indirectly.
        private static readonly BaseTypeInfo s_noBaseTypes = new BaseTypeInfo();

        private ImmutableHashSet<Symbol> _lazyAbstractMembers;
        private BaseTypeInfo _lazyBaseTypeInfo;

        private class BaseTypeInfo
        {
            // all directly implemented interfaces, their bases and all interfaces to the bases of the type recursively
            internal ImmutableArray<NamedTypeSymbol> allBaseTypes;

            /// <summary>
            /// <see cref="TypeSymbol.BaseTypesAndTheirBaseTypesNoUseSiteDiagnostics"/>
            /// </summary>
            internal MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> baseTypesAndTheirBaseTypes;

            internal readonly static MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> EmptyBaseTypesAndTheirBaseTypes =
                new MultiDictionary<NamedTypeSymbol, NamedTypeSymbol>(0, EqualsCLRSignatureComparer);

            // Key is implemented member (method, property, or event), value is implementing member (from the 
            // perspective of this type).  Don't allocate until someone needs it.
            private ConcurrentDictionary<Symbol, SymbolAndDiagnostics> _implementationForBaseMemberMap;

            public ConcurrentDictionary<Symbol, SymbolAndDiagnostics> ImplementationForBaseMemberMap
            {
                get
                {
                    var map = _implementationForBaseMemberMap;
                    if (map != null)
                    {
                        return map;
                    }

                    // PERF: Avoid over-allocation. In many cases, there's only 1 entry and we don't expect concurrent updates.
                    map = new ConcurrentDictionary<Symbol, SymbolAndDiagnostics>(concurrencyLevel: 1, capacity: 1);
                    return Interlocked.CompareExchange(ref _implementationForBaseMemberMap, map, null) ?? map;
                }
            }

            /// <summary>
            /// key = interface method/property/event compared using <see cref="ExplicitBaseTypeImplementationTargetMemberEqualityComparer"/>,
            /// value = explicitly implementing methods/properties/events declared on this type (normally a single value, multiple in case of
            /// an error).
            /// </summary>
            internal MultiDictionary<Symbol, Symbol> explicitBaseTypeImplementationMap;

            internal bool IsDefaultValue()
            {
                return allBaseTypes.IsDefault &&
                    baseTypesAndTheirBaseTypes == null &&
                    _implementationForBaseMemberMap == null &&
                    explicitBaseTypeImplementationMap == null;
            }
        }

        private BaseTypeInfo GetBaseTypeInfo()
        {
            var info = _lazyBaseTypeInfo;
            if (info != null)
            {
                Debug.Assert(info != s_noBaseTypes || info.IsDefaultValue(), "default value was modified");
                return info;
            }

            if (this.BaseTypesNoUseSiteDiagnostics.Length > 0)
            {
                // it looks like we have at least one base type
                info = new BaseTypeInfo();

                // NOTE: we are assigning lazyBaseTypeInfo via interlocked not for correctness, 
                // we just do not want to override an existing info that could be partially filled.
                return Interlocked.CompareExchange(ref _lazyBaseTypeInfo, info, null) ?? info;
            }

            // if we have got here it means neither we nor our bases implement anything
            _lazyBaseTypeInfo = info = s_noBaseTypes;
            return info;
        }

        public ImmutableArray<NamedTypeSymbol> BaseTypesWithDefinitionUseSiteDiagnostics(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var result = BaseTypesNoUseSiteDiagnostics;
            foreach (var baseType in result)
            {
                baseType.OriginalDefinition.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            }
            return result;
        }

        public ImmutableArray<NamedTypeSymbol> BaseTypesOriginalDefinition(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            ArrayBuilder<NamedTypeSymbol> result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            foreach (var baseType in this.BaseTypesNoUseSiteDiagnostics)
            {
                var originalBaseType = (NamedTypeSymbol)baseType.OriginalDefinition;
                result.Add(originalBaseType);
                originalBaseType.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            }
            return result.ToImmutableAndFree();
        }

        /// <summary>
        /// Gets the set of base types that this type directly inherits from. This set does not include
        /// base types that are base types of directly implemented base types.
        /// If a base type could not be determined, then 
        /// an instance of ErrorType is returned. If this kind of type does not have a base type
        /// (for example, interfaces), null is returned. Also the special class System.Object
        /// always has a BaseType of null.
        /// </summary>
        public virtual ImmutableArray<NamedTypeSymbol> BaseTypesNoUseSiteDiagnostics => this.GetBaseTypesNoUseSiteDiagnostics();

        public abstract ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null);

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
        public ImmutableArray<NamedTypeSymbol> AllBaseTypesNoUseSiteDiagnostics => this.GetAllBaseTypes();

        public ImmutableArray<NamedTypeSymbol> AllBaseTypesWithDefinitionUseSiteDiagnostics(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var result = AllBaseTypesNoUseSiteDiagnostics;
            foreach (var baseType in result)
            {
                baseType.OriginalDefinition.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            }
            return result;
        }

        /// <summary>
        /// If this is a type parameter returns its effective base class, otherwise returns this type.
        /// </summary>
        public TypeSymbol EffectiveTypeNoUseSiteDiagnostics => this;

        public TypeSymbol EffectiveType(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return this;
        }

        /// <summary>
        /// Returns true if this type derives from a given type.
        /// </summary>
        public bool IsDerivedFrom(TypeSymbol type, TypeCompareKind comparison, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert((object)type != null);
            if ((object)this == (object)type)
            {
                return false;
            }
            var allBaseTypes = this.AllBaseTypesWithDefinitionUseSiteDiagnostics(ref useSiteDiagnostics);
            return allBaseTypes.Any(t => type.Equals(t, comparison));
        }

        /// Returns true if this type is equal or derives from a given type.
        /// </summary>
        public bool IsEqualToOrDerivedFrom(TypeSymbol type, TypeCompareKind comparison, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return this.Equals(type, comparison) || this.IsDerivedFrom(type, comparison, ref useSiteDiagnostics);
        }


        public static bool Equals(TypeSymbol left, TypeSymbol right, TypeCompareKind comparison)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right, comparison);
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
        public virtual bool Equals(TypeSymbol t2, TypeCompareKind compareKind = TypeCompareKind.ConsiderEverything)
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

        protected virtual ImmutableArray<NamedTypeSymbol> GetAllBaseTypes()
        {
            var info = this.GetBaseTypeInfo();
            if (info == s_noBaseTypes)
            {
                return ImmutableArray<NamedTypeSymbol>.Empty;
            }
            if (info.allBaseTypes.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref info.allBaseTypes, MakeAllBaseTypes());
            }
            return info.allBaseTypes;
        }

        /// Produce all implemented interfaces in topologically sorted order. We use
        /// TypeSymbol.Interfaces as the source of edge data, which has had cycles and infinitely
        /// long dependency cycles removed. Consequently, it is possible (and we do) use the
        /// simplest version of Tarjan's topological sorting algorithm.
        protected virtual ImmutableArray<NamedTypeSymbol> MakeAllBaseTypes()
        {
            var result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            var visited = new HashSet<NamedTypeSymbol>();
            var baseTypes = this.BaseTypesNoUseSiteDiagnostics;
            for (int i = baseTypes.Length - 1; i >= 0; i--)
            {
                AddAllBaseTypes(baseTypes[i], visited, result);
            }
            result.ReverseContents();
            return result.ToImmutableAndFree();
        }

        private static void AddAllBaseTypes(NamedTypeSymbol baseType, HashSet<NamedTypeSymbol> visited, ArrayBuilder<NamedTypeSymbol> result)
        {
            if (visited.Add(baseType))
            {
                ImmutableArray<NamedTypeSymbol> baseTypes = baseType.BaseTypesNoUseSiteDiagnostics;
                for (int i = baseTypes.Length - 1; i >= 0; i--)
                {
                    var nextBaseType = baseTypes[i];
                    AddAllBaseTypes(nextBaseType, visited, result);
                }
                result.Add(baseType);
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
        internal MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> BaseTypesAndTheirBaseTypesNoUseSiteDiagnostics
        {
            get
            {
                var info = this.GetBaseTypeInfo();
                if (info == s_noBaseTypes)
                {
                    Debug.Assert(BaseTypeInfo.EmptyBaseTypesAndTheirBaseTypes.IsEmpty);
                    return BaseTypeInfo.EmptyBaseTypesAndTheirBaseTypes;
                }

                if (info.baseTypesAndTheirBaseTypes == null)
                {
                    Interlocked.CompareExchange(ref info.baseTypesAndTheirBaseTypes, MakeBaseTypesAndTheirBaseTypes(this.BaseTypesNoUseSiteDiagnostics), null);
                }

                return info.baseTypesAndTheirBaseTypes;
            }
        }

        internal MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> BaseTypesAndTheirBaseTypesWithDefinitionUseSiteDiagnostics(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var result = BaseTypesAndTheirBaseTypesNoUseSiteDiagnostics;
            foreach (var baseType in result.Keys)
            {
                baseType.OriginalDefinition.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            }
            return result;
        }

        // Note: Unlike MakeAllBaseTypes, this doesn't need to be virtual. It depends on
        // AllBaseTypes for its implementation, so it will pick up all changes to MakeAllBaseTypes
        // indirectly.
        private static MultiDictionary<NamedTypeSymbol, NamedTypeSymbol> MakeBaseTypesAndTheirBaseTypes(ImmutableArray<NamedTypeSymbol> declaredBaseTypes)
        {
            var resultBuilder = new MultiDictionary<NamedTypeSymbol, NamedTypeSymbol>(declaredBaseTypes.Length, EqualsCLRSignatureComparer);
            foreach (var baseType in declaredBaseTypes)
            {
                if (resultBuilder.Add(baseType, baseType))
                {
                    foreach (var nextBaseType in baseType.AllBaseTypesNoUseSiteDiagnostics)
                    {
                        resultBuilder.Add(nextBaseType, nextBaseType);
                    }
                }
            }
            return resultBuilder;
        }

        /// <summary>
        /// Returns the corresponding symbol in this type or a base type that implements 
        /// baseTypeMember (either implicitly or explicitly), or null if no such symbol exists
        /// (which might be either because this type doesn't implement the container of
        /// baseTypeMember, or this type doesn't supply a member that successfully implements
        /// baseTypeMember).
        /// </summary>
        /// <param name="baseTypeMember">
        /// Must be a non-null interface property, method, or event.
        /// </param>
        public Symbol FindImplementationForBaseTypeMember(Symbol baseTypeMember)
        {
            if ((object)baseTypeMember == null)
            {
                throw new ArgumentNullException(nameof(baseTypeMember));
            }
            if (baseTypeMember is MemberSymbol member && member.IsImplementableMember)
            {
                return null;
            }
            return FindMostSpecificImplementationWithDiagnostics(baseTypeMember, (NamedTypeSymbol)this).Symbol;
        }

        /// <summary>
        /// Gets the kind of this type.
        /// </summary>
        public virtual TypeKind TypeKind => TypeKind.None;

        /// <summary>
        /// Gets corresponding special TypeId of this type.
        /// </summary>
        /// <remarks>
        /// Not preserved in types constructed from this one.
        /// </remarks>
        public virtual SpecialType SpecialType => SpecialType.None;
        /// <summary>
        /// Gets corresponding primitive type code for this type declaration.
        /// </summary>
        internal Microsoft.Cci.PrimitiveTypeCode PrimitiveTypeCode => SpecialTypes.GetTypeCode(SpecialType);

        #region Use-Site Diagnostics

        /// <summary>
        /// Return error code that has highest priority while calculating use site error for this symbol. 
        /// </summary>
        protected override ErrorCode HighestPriorityUseSiteError => InternalErrorCode.ERR_BogusType;

        public sealed override bool HasUnsupportedMetadata
        {
            get
            {
                DiagnosticInfo info = GetUseSiteDiagnostic();
                return (object)info != null && info.HasErrorCode(InternalErrorCode.ERR_BogusType);
            }
        }

        public abstract bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes);

        /// <summary>
        /// The original definition of this symbol. If this symbol is constructed from another
        /// symbol by type substitution then OriginalDefinition gets the original symbol as it was defined in
        /// source or metadata.
        /// </summary>
        public new TypeSymbol OriginalDefinition => OriginalTypeSymbolDefinition;

        protected virtual TypeSymbol OriginalTypeSymbolDefinition => this;

        protected override sealed DeclaredSymbol OriginalSymbolDefinition => this.OriginalTypeSymbolDefinition;

        #endregion
        public virtual bool IsReferenceType => false;

        public virtual bool IsValueType => false;

        public virtual bool IsAnonymousType => false;

        public virtual bool IsTupleType => false;

        public virtual bool IsRefLikeType => false;

        public virtual bool IsUnmanagedType => false;

        public virtual bool IsReadOnly => false;

        #region Interface member checks

        protected virtual SymbolAndDiagnostics FindMostSpecificImplementationWithDiagnostics(Symbol baseTypeMember, NamedTypeSymbol implementingBaseType)
        {
            Debug.Assert((object)baseTypeMember != null);
            throw new NotImplementedException("TODO:MetaDslx");
        }

        #endregion

        internal static readonly EqualityComparer<TypeSymbol> EqualsConsiderEverything = new TypeSymbolComparer(TypeCompareKind.ConsiderEverything);

        internal static readonly EqualityComparer<TypeSymbol> EqualsCLRSignatureComparer = new TypeSymbolComparer(TypeCompareKind.CLRSignatureCompareOptions);

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

        #region Check generic constraints


        /// <summary>
        /// Check all generic constraints on the given type and any containing types
        /// (such as A&lt;T&gt; in A&lt;T&gt;.B&lt;U&gt;). This includes checking constraints
        /// on generic types within the type (such as B&lt;T&gt; in A&lt;B&lt;T&gt;[]&gt;).
        /// </summary>
        public virtual void CheckAllConstraints(
            LanguageCompilation compilation,
            ConversionsBase conversions,
            Location location,
            DiagnosticBag diagnostics)
        {
            // TODO:MetaDslx
        }

        public bool CheckAllConstraints(
            LanguageCompilation compilation,
            ConversionsBase conversions)
        {
            var diagnostics = DiagnosticBag.GetInstance();

            // Nullability checks can only add warnings here so skip them for this check as we are only
            // concerned with errors.
            CheckAllConstraints(compilation, conversions, NoLocation.Singleton, diagnostics);
            bool ok = !diagnostics.HasAnyErrors();
            diagnostics.Free();
            return ok;
        }


        #endregion

        internal ITypeSymbol GetITypeSymbol(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
        {
            if (nullableAnnotation == DefaultNullableAnnotation)
            {
                return (ITypeSymbol)this.ISymbol;
            }

            return CreateITypeSymbol(nullableAnnotation);
        }

        protected abstract ITypeSymbol CreateITypeSymbol(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation);

    }
}
