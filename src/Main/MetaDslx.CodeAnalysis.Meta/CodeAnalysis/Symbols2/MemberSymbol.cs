using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class MemberSymbol : DeclaredSymbol, IMetaMemberSymbol
    {
        public virtual bool IsImplementableMember => !this.IsStatic;

        /// <summary>
        /// Returns true if this method hides base methods by name. This cannot be specified directly
        /// in the C# language, but can be true for methods defined in other languages imported from
        /// metadata. The equivalent of the "hidebyname" flag in metadata.
        /// </summary>
        public virtual bool HidesBaseMembersByName => false;

        public virtual MemberSymbol OverridenMember => null;

        /// <summary>
        /// Returns the original virtual or abstract method which a given method symbol overrides,
        /// ignoring any other overriding methods in base classes.
        /// </summary>
        /// <param name="accessingTypeOpt">The search must respect accessibility from this type.</param>
        public override DeclaredSymbol GetLeastOverriddenMember(NamedTypeSymbol accessingTypeOpt)
        {
            var accessingType = ((object)accessingTypeOpt == null ? this.ContainingType : accessingTypeOpt).OriginalDefinition;

            MemberSymbol m = this;
            while (m.IsOverride && !m.HidesBaseMembersByName)
            {
                // We might not be able to access the overridden method. For example,
                //
                //   .assembly A
                //   {
                //      InternalsVisibleTo("B")
                //      public class A { internal virtual void M() { } }
                //   }
                //
                //   .assembly B
                //   {
                //      InternalsVisibleTo("C")
                //      public class B : A { internal override void M() { } }
                //   }
                //
                //   .assembly C
                //   {
                //      public class C : B { ... new B().M ... }       // A.M is not accessible from here
                //   }
                //
                // See InternalsVisibleToAndStrongNameTests: IvtVirtualCall1, IvtVirtualCall2, IvtVirtual_ParamsAndDynamic.
                MemberSymbol overridden = m.OverriddenMember;
                HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                if ((object)overridden == null || !AccessCheck.IsSymbolAccessible(overridden, accessingType, ref useSiteDiagnostics))
                {
                    break;
                }

                m = overridden;
            }

            return m;
        }

        /// <summary>
        /// If this method overrides another method (because it both had the override modifier
        /// and there correctly was a method to override), returns the overridden method.
        /// Note that if an overriding method D.M overrides C.M, which in turn overrides
        /// virtual method A.M, the "overridden method" of D.M is C.M, not the original virtual
        /// method A.M. Note also that constructed generic methods are not considered to
        /// override anything.
        /// </summary>
        public MemberSymbol OverriddenMember
        {
            get
            {
                if (this.IsOverride && ReferenceEquals(this.ConstructedFrom, this))
                {
                    if (IsDefinition)
                    {
                        return (MemberSymbol)OverriddenOrHiddenMembers.GetOverriddenMember();
                    }

                    return (MemberSymbol)OverriddenOrHiddenMembersResult.GetOverriddenMember(this, ((MemberSymbol)OriginalDefinition).OverriddenMember);
                }

                return null;
            }
        }

        internal virtual OverriddenOrHiddenMembersResult OverriddenOrHiddenMembers
        {
            get
            {
                // To save space, the default implementation does not cache its result.  We expect there to
                // be a very large number of MethodSymbols and we expect that a large percentage of them will
                // obviously not override anything (e.g. static methods, constructors, destructors, etc).
                return this.MakeOverriddenOrHiddenMembers();
            }
        }

        public virtual bool CanOverrideOrHide(MemberSymbol other)
        {
            if ((object)other == null) return false;
            return this.Kind == other.Kind && this.ModelSymbolInfo == other.ModelSymbolInfo;
        }

        /// <summary>
        /// Walk up the type hierarchy from ContainingType and list members that this
        /// member either overrides (accessible members with the same signature, if this
        /// member is declared "override") or hides (accessible members with the same name
        /// but different kinds, plus members that would be in the overrides list if
        /// this member were not declared "override").
        /// 
        /// Members in the overridden list may be non-virtual or may have different
        /// accessibilities, types, accessors, etc.  They are really candidates to be
        /// overridden.
        /// 
        /// Members in the hidden list are definitely hidden.
        /// 
        /// Members in the runtime overridden list are indistinguishable from the members
        /// in the overridden list from the point of view of the runtime (see
        /// FindOtherOverriddenMethodsInContainingType for details).
        /// </summary>
        /// <remarks>
        /// In the presence of non-C# types, the meaning of "same signature" is rather
        /// complicated.  If this member isn't from source, then it refers to the runtime's
        /// notion of signature (i.e. including return type, custom modifiers, etc).
        /// If this member is from source, then the process is (conceptually) as follows.
        /// 
        /// 1) Walk up the type hierarchy, recording all matching members with the same
        ///    signature, ignoring custom modifiers and return type.  Stop if a hidden
        ///    member is encountered.
        /// 2) Apply the following "tie-breaker" rules until you have at most one member,
        ///    a) Prefer members in more derived types.
        ///    b) Prefer an exact custom modifier match (i.e. none, for a source member).
        ///    c) Prefer fewer custom modifiers (values/positions don't matter, just count).
        ///    d) Prefer earlier in GetMembers order (within the same type).
        /// 3) If a member remains, search its containing type for other members that
        ///    have the same C# signature (overridden members) or runtime signature
        ///    (runtime overridden members).
        /// 
        /// In metadata, properties participate in overriding only through their accessors.
        /// That is, property/event accessors may implicitly or explicitly override other methods
        /// and a property/event can be considered to override another property/event if its accessors
        /// override those of the other property/event.
        /// This implementation (like Dev10) will not follow that approach.  Instead, it is
        /// based on spec section 10.7.5, which treats properties as entities in their own
        /// right.  If all property/event accessors have conventional names in metadata and nothing
        /// "unusual" is done with explicit overriding, this approach should produce the same
        /// results as an implementation based on accessor overriding.
        /// </remarks>
        protected OverriddenOrHiddenMembersResult MakeOverriddenOrHiddenMembers()
        {
            NamedTypeSymbol containingType = this.ContainingType;

            // NOTE: In other areas of the compiler, we check whether the member is from a specific compilation.
            // We could do the same thing here, but that would mean that callers of the public API would have
            // to pass in a Compilation object when asking about overriding or hiding.  This extra cost eliminates
            // the small benefit of getting identical answers from "imported" symbols, regardless of whether they
            // are imported as source or metadata symbols.
            //
            // ACASEY: As of 2013/01/24, we are not aware of any cases where the source and metadata behaviors
            // disagree *in code that can be emitted*.  (If there are any, they are likely to involved ambiguous
            // overrides, which typically arise through combinations of ref/out and generics.)  In incorrect code,
            // the source behavior is somewhat more generous (e.g. accepting a method with the wrong return type),
            // but we do not guarantee that incorrect source will be treated in the same way as incorrect metadata.
            bool isFromSomeCompilation = this.Dangerous_IsFromSomeCompilation;

            /*if (containingType.IsInterface)
            {
                return MakeInterfaceOverriddenOrHiddenMembers(member, isFromSomeCompilation);
            }*/

            DeclaredSymbol bestMatch = null;
            ArrayBuilder<DeclaredSymbol> hiddenBuilder = null;

            foreach (var currType in containingType.AllBaseTypesNoUseSiteDiagnostics)
            {
                bool unused;
                FindOverriddenOrHiddenMembersInType(
                    this,
                    isFromSomeCompilation,
                    containingType,
                    currType,
                    out bestMatch,
                    out unused,
                    out hiddenBuilder);
                if ((object)currType != null && (object)bestMatch == null && hiddenBuilder == null) break;
            }

            // Based on bestMatch, find other methods that will be overridden, hidden, or runtime overridden
            // (in bestMatch.ContainingType).
            ImmutableArray<DeclaredSymbol> overriddenMembers;
            ImmutableArray<DeclaredSymbol> runtimeOverriddenMembers;
            FindRelatedMembers(this.IsOverride, isFromSomeCompilation, this.Kind, bestMatch, out overriddenMembers, out runtimeOverriddenMembers, ref hiddenBuilder);

            ImmutableArray<DeclaredSymbol> hiddenMembers = hiddenBuilder == null ? ImmutableArray<DeclaredSymbol>.Empty : hiddenBuilder.ToImmutableAndFree();
            return OverriddenOrHiddenMembersResult.Create(overriddenMembers, hiddenMembers, runtimeOverriddenMembers);
        }

        /// <summary>
        /// Look for overridden or hidden members in a specific type.
        /// </summary>
        /// <param name="member">Member that is hiding or overriding.</param>
        /// <param name="memberIsFromSomeCompilation">True if member is from the current compilation.</param>
        /// <param name="memberContainingType">The type that contains member (member.ContainingType).</param>
        /// <param name="currType">The type to search.</param>
        /// <param name="currTypeBestMatch">
        /// A member with the same signature if currTypeHasExactMatch is true,
        /// a member with (a minimal number of) different custom modifiers if there is one,
        /// and null otherwise.</param>
        /// <param name="currTypeHasSameKindNonMatch">True if there's a member with the same name and kind that is not a match.</param>
        /// <param name="hiddenBuilder">Hidden members (same name, different kind) will be added to this builder.</param>
        /// <remarks>
        /// There is some similarity between this member and TypeSymbol.FindPotentialImplicitImplementationMemberDeclaredInType.
        /// When making changes to this member, think about whether or not they should also be applied in TypeSymbol.
        /// 
        /// In incorrect or imported code, it is possible that both currTypeBestMatch and hiddenBuilder will be populated.
        /// </remarks>
        private static void FindOverriddenOrHiddenMembersInType(
            DeclaredSymbol member,
            bool memberIsFromSomeCompilation,
            NamedTypeSymbol memberContainingType,
            NamedTypeSymbol currType,
            out DeclaredSymbol currTypeBestMatch,
            out bool currTypeHasSameKindNonMatch,
            out ArrayBuilder<DeclaredSymbol> hiddenBuilder)
        {
            currTypeBestMatch = null;
            currTypeHasSameKindNonMatch = false;
            hiddenBuilder = null;

            bool currTypeHasExactMatch = false;
            LanguageSymbolKind memberKind = member.Kind;

            foreach (DeclaredSymbol otherMember in currType.GetMembers(member.Name))
            {
                if (!IsOverriddenSymbolAccessible(otherMember, memberContainingType))
                {
                    //do nothing
                }
                else if (otherMember.Kind != memberKind)
                {
                    //do nothing
                }
                else if (!currTypeHasExactMatch)
                {
                    if (MatchesOverride(member, otherMember))
                    {
                        currTypeHasExactMatch = true;
                        currTypeBestMatch = otherMember;
                    }
                    else
                    {
                        currTypeHasSameKindNonMatch = true;
                    }
                }
            }
        }

        /// <summary>
        /// If representative member is non-null and is contained in a constructed type, then find
        /// other members in the same type with the same signature.  If this is an override member,
        /// add them to the overridden and runtime overridden lists.  Otherwise, add them to the
        /// hidden list.
        /// </summary>
        private static void FindRelatedMembers(
            bool isOverride,
            bool overridingMemberIsFromSomeCompilation,
            LanguageSymbolKind overridingMemberKind,
            DeclaredSymbol representativeMember,
            out ImmutableArray<DeclaredSymbol> overriddenMembers,
            out ImmutableArray<DeclaredSymbol> runtimeOverriddenMembers,
            ref ArrayBuilder<DeclaredSymbol> hiddenBuilder)
        {
            overriddenMembers = ImmutableArray<DeclaredSymbol>.Empty;
            runtimeOverriddenMembers = ImmutableArray<DeclaredSymbol>.Empty;

            if ((object)representativeMember != null)
            {
                bool needToSearchForRelated = !representativeMember.ContainingType.IsDefinition;

                if (isOverride)
                {
                    if (needToSearchForRelated)
                    {
                        ArrayBuilder<DeclaredSymbol> overriddenBuilder = ArrayBuilder<DeclaredSymbol>.GetInstance();
                        ArrayBuilder<DeclaredSymbol> runtimeOverriddenBuilder = ArrayBuilder<DeclaredSymbol>.GetInstance();

                        overriddenBuilder.Add(representativeMember);
                        runtimeOverriddenBuilder.Add(representativeMember);

                        FindOtherOverriddenMethodsInContainingType(representativeMember, overridingMemberIsFromSomeCompilation, overriddenBuilder, runtimeOverriddenBuilder);

                        overriddenMembers = overriddenBuilder.ToImmutableAndFree();
                        runtimeOverriddenMembers = runtimeOverriddenBuilder.ToImmutableAndFree();
                    }
                    else
                    {
                        overriddenMembers = ImmutableArray.Create<DeclaredSymbol>(representativeMember);
                        runtimeOverriddenMembers = overriddenMembers;
                    }
                }
                else
                {
                    AddHiddenMemberIfApplicable(ref hiddenBuilder, overridingMemberKind, representativeMember);

                    if (needToSearchForRelated)
                    {
                        FindOtherHiddenMembersInContainingType(overridingMemberKind, representativeMember, ref hiddenBuilder);
                    }
                }
            }
        }

        /// <summary>
        /// Some kinds of methods are not considered to be hideable by certain kinds of members.
        /// Specifically, methods, properties, and types cannot hide constructors, destructors,
        /// operators, conversions, or accessors.
        /// </summary>
        private static void AddHiddenMemberIfApplicable(ref ArrayBuilder<DeclaredSymbol> hiddenBuilder, LanguageSymbolKind hidingMemberKind, DeclaredSymbol hiddenMember)
        {
            Debug.Assert((object)hiddenMember != null);
            AccessOrGetInstance(ref hiddenBuilder).Add(hiddenMember);
        }

        private static ArrayBuilder<T> AccessOrGetInstance<T>(ref ArrayBuilder<T> builder)
        {
            if (builder == null)
            {
                builder = ArrayBuilder<T>.GetInstance();
            }

            return builder;
        }

        /// <summary>
        /// Having found the best member to override, we want to find members with the same signature on the
        /// best member's containing type.
        /// </summary>
        /// <param name="representativeMember">
        /// The member that we consider to be overridden (may have different custom modifiers from the overriding member).
        /// Assumed to already be in the overridden and runtime overridden lists.
        /// </param>
        /// <param name="overridingMemberIsFromSomeCompilation">
        /// If the best match was based on the custom modifier count, rather than the custom modifiers themselves 
        /// (because the overriding member is in the current compilation), then we should use the count when determining
        /// whether the override is ambiguous.
        /// </param>
        /// <param name="overriddenBuilder">
        /// If the declaring type is constructed, it's possible that two (or more) members have the same signature
        /// (including custom modifiers).  Return a list of such members so that we can report the ambiguity.
        /// </param>
        /// <param name="runtimeOverriddenBuilder">
        /// If the declaring type is constructed, it's possible that two (or more) members have the same signature
        /// (including custom modifiers) in metadata (no ref/out distinction).  Return a list of such members so
        /// that we can report the ambiguity.
        /// 
        /// Even in a non-generic type, it's possible for two indexers to have the same signature.  For example,
        /// this would be the case if the default member of a type is "get_Item" and indexers "A" and "B", 
        /// with the same signature, both have an indexer called "get_Item".
        /// 
        /// From: SymbolPreparer.cpp
        /// DevDiv Bugs 115384: Both out and ref parameters are implemented as references. In addition, out parameters are 
        /// decorated with OutAttribute. In CLR when a signature is looked up in virtual dispatch, CLR does not distinguish
        /// between these to parameter types. The choice is the last method in the vtable. Therefore we check and warn if 
        /// there would potentially be a mismatch in CLRs and C#s choice of the overridden method. Unfortunately we have no 
        /// way of communicating to CLR which method is the overridden one. We only run into this problem when the 
        /// parameters are generic.
        /// </param>
        private static void FindOtherOverriddenMethodsInContainingType(DeclaredSymbol representativeMember, bool overridingMemberIsFromSomeCompilation, ArrayBuilder<DeclaredSymbol> overriddenBuilder, ArrayBuilder<DeclaredSymbol> runtimeOverriddenBuilder)
        {
            Debug.Assert((object)representativeMember != null);
        }

        /// <summary>
        /// Having found that we are hiding a method with exactly the same signature
        /// (including custom modifiers), we want to find methods with the same signature
        /// on the declaring type because they will also be hidden.
        /// (If the declaring type is constructed, it's possible that two or more
        /// methods have the same signature (including custom modifiers).)
        /// (If the representative member is an indexer, it's possible that two or more
        /// properties have the same signature (including custom modifiers, even in a
        /// non-generic type).
        /// </summary>
        /// <param name="hidingMemberKind">
        /// This kind of the hiding member.
        /// </param>
        /// <param name="representativeMember">
        /// The member that we consider to be hidden (must have exactly the same custom modifiers as the hiding member).
        /// Assumed to already be in hiddenBuilder.
        /// </param>
        /// <param name="hiddenBuilder">
        /// Will have all other members with the same signature (including custom modifiers) as 
        /// representativeMember added.
        /// </param>
        private static void FindOtherHiddenMembersInContainingType(LanguageSymbolKind hidingMemberKind, DeclaredSymbol representativeMember, ref ArrayBuilder<DeclaredSymbol> hiddenBuilder)
        {
            Debug.Assert((object)representativeMember != null);
        }

        private static bool MatchesOverride(DeclaredSymbol member, DeclaredSymbol otherMember)
        {
            return member.Kind == otherMember.Kind && member.ModelSymbolInfo == otherMember.ModelSymbolInfo && member.Name == otherMember.Name;
        }

        /// <remarks>
        /// Note that the access check is done using the original definitions.  This is because we want to avoid
        /// reductions in accessibility that result from type argument substitution (e.g. if an inaccessible type
        /// has been passed as a type argument).
        /// See DevDiv #11967 for an example.
        /// </remarks>
        private static bool IsOverriddenSymbolAccessible(DeclaredSymbol overridden, NamedTypeSymbol overridingContainingType)
        {
            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            return AccessCheck.IsSymbolAccessible(overridden.OriginalDefinition, overridingContainingType.OriginalDefinition, ref useSiteDiagnostics);
        }

        internal DiagnosticInfo CalculateUseSiteDiagnostic()
        {
            // TODO:MetaDslx
            return null;
        }

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitMember(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitMember(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitMember(this, argument);
        }

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            
        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return default;
        }
    }
}
