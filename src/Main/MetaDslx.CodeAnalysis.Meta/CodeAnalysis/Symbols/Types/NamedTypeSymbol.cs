using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class NamedTypeSymbol : TypeSymbol
    {
        /// <summary>
        /// Returns true a type declared as "abstract", all interface types, and members of interface types.
        /// </summary>
        [SymbolProperty]
        public virtual bool IsAbstract => false;

        /// <summary>
        /// Returns true for types that do not allow a derived type (declared with <c>sealed</c> or <c>static</c> or <c>struct</c>
        /// or <c>enum</c> or <c>delegate</c>).
        /// </summary>
        [SymbolProperty]
        public virtual bool IsSealed => false;

        public override bool IsStatic => false;

        public virtual ImmutableArray<DeclaredSymbol> GetNonTypeMembers(string name)
        {
            // TODO:MetaDslx: cache this and other member lookups
            return GetMembers(name).WhereAsArray(member => !(member is NamedTypeSymbol));
        }

        /// <summary>
        /// Get all instance members.
        /// </summary>
        /// <remarks>
        /// For source symbols may be called while calculating
        /// <see cref="NamespaceOrTypeSymbol.GetMembersUnordered"/>.
        /// </remarks>
        public virtual ImmutableArray<DeclaredSymbol> GetInstanceMembers()
        {
            return GetMembersUnordered().WhereAsArray(IsInstanceMember);
        }

        /// <summary>
        /// Get all static members.
        /// </summary>
        /// <remarks>
        /// For source symbols may be called while calculating
        /// <see cref="NamespaceOrTypeSymbol.GetMembersUnordered"/>.
        /// </remarks>
        public virtual ImmutableArray<DeclaredSymbol> GetStaticMembers()
        {
            return GetMembersUnordered().WhereAsArray(IsStaticMember);
        }

        internal static Func<DeclaredSymbol, bool> IsInstanceMember = symbol => !symbol.IsStatic;
        internal static Func<DeclaredSymbol, bool> IsStaticMember = symbol => symbol.IsStatic;

        public virtual MethodSymbol GetScriptInitializer()
        {
            return null;
        }

        public virtual MethodSymbol GetScriptEntryPoint()
        {
            return null;
        }

        /// <summary>
        /// Get the operators for this type by their metadata name
        /// </summary>
        public ImmutableArray<OperatorSymbol> GetOperators(string name)
        {
            ImmutableArray<DeclaredSymbol> candidates = GetNonTypeMembers(name);
            if (candidates.IsEmpty)
            {
                return ImmutableArray<OperatorSymbol>.Empty;
            }

            ArrayBuilder<OperatorSymbol> operators = ArrayBuilder<OperatorSymbol>.GetInstance();
            foreach (OperatorSymbol candidate in candidates.OfType<OperatorSymbol>())
            {
                if (candidate is OperatorSymbol)
                {
                    operators.Add(candidate);
                }
            }

            return operators.ToImmutableAndFree();
        }

        /// <summary>
        /// Get the instance constructors for this type.
        /// </summary>
        public ImmutableArray<ConstructorSymbol> InstanceConstructors => GetConstructors(includeInstance: true, includeStatic: false);

        /// <summary>
        /// Get the static constructors for this type.
        /// </summary>
        public ImmutableArray<ConstructorSymbol> StaticConstructors => GetConstructors(includeInstance: false, includeStatic: true);

        /// <summary>
        /// Get the instance and static constructors for this type.
        /// </summary>
        public ImmutableArray<ConstructorSymbol> Constructors => GetConstructors(includeInstance: true, includeStatic: true);

        private ImmutableArray<ConstructorSymbol> GetConstructors(bool includeInstance, bool includeStatic) 
        {
            Debug.Assert(includeInstance || includeStatic);
            ArrayBuilder<ConstructorSymbol> constructors = ArrayBuilder<ConstructorSymbol>.GetInstance();
            if (includeInstance)
            {
                constructors.AddRange(GetMembers(WellKnownMemberNames.InstanceConstructorName).OfType<ConstructorSymbol>());
            }
            if (includeStatic)
            {
                constructors.AddRange(GetMembers(WellKnownMemberNames.StaticConstructorName).OfType<ConstructorSymbol>());
            }
            return constructors.ToImmutableAndFree();
        }

        /// <summary>
        /// The original definition of this symbol. If this symbol is constructed from another
        /// symbol by type substitution then OriginalDefinition gets the original symbol as it was defined in
        /// source or metadata.
        /// </summary>
        public new virtual NamedTypeSymbol OriginalDefinition => this;

        protected override sealed TypeSymbol OriginalTypeSymbolDefinition => this.OriginalDefinition;

        /// <summary>
        /// Returns the type symbol that this type was constructed from. This type symbol
        /// has the same containing type (if any), but has type arguments that are the same
        /// as the type parameters (although its containing type might not).
        /// </summary>
        public new virtual NamedTypeSymbol ConstructedFrom => this;

        public virtual bool MightContainExtensionMethods => false;

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
        public override bool Equals(TypeSymbol t2, TypeCompareKind comparison)
        {
            Debug.Assert(this is not TupleTypeSymbol);

            if ((object)t2 == this) return true;
            if ((object)t2 == null) return false;
            
            if ((comparison & TypeCompareKind.IgnoreDynamic) != 0)
            {
                if (t2 is DynamicTypeSymbol)
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
            if (!TypeSymbol.Equals(thisOriginalDefinition, otherOriginalDefinition, TypeCompareKind.ConsiderEverything))
            {
                return false;
            }

            // The checks above are supposed to handle the vast majority of cases.
            // More complicated cases are handled in a special helper to make the common case scenario simple/fast (fewer locals and smaller stack frame)
            return EqualsComplicatedCases(other, comparison);
        }

        /// <summary>
        /// Helper for more complicated cases of Equals like when we have generic instantiations or types nested within them.
        /// </summary>
        protected virtual bool EqualsComplicatedCases(NamedTypeSymbol other, TypeCompareKind comparison)
        {
            return true;
        }

        #region Use-Site Diagnostics

        public override DiagnosticInfo GetUseSiteDiagnostic()
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

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
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
            foreach (var @base in this.BaseTypes)
            {
                if (@base.GetUnificationUseSiteDiagnosticRecursive(ref result, owner, ref checkedTypes))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        public virtual bool IsGenericType => this.Arity > 0;

    }
}
