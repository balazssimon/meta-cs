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
    public abstract class NamedTypeSymbol : TypeSymbol
    {
        public override SymbolKind Kind => SymbolKind.NamedType;


        /// <summary>
        /// Collection of names of members declared within this type.
        /// </summary>
        public abstract IEnumerable<string> MemberNames { get; }

        /// <summary>
        /// Get all the members of this symbol.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol. If this symbol has no members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract override ImmutableArray<DeclaredSymbol> GetMembers();

        public virtual ImmutableArray<DeclaredSymbol> GetNonTypeMembers(string name)
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
        public ImmutableArray<MethodSymbol> GetOperators(string name)
        {
            ImmutableArray<DeclaredSymbol> candidates = GetNonTypeMembers(name);
            if (candidates.IsEmpty)
            {
                return ImmutableArray<MethodSymbol>.Empty;
            }

            ArrayBuilder<MethodSymbol> operators = ArrayBuilder<MethodSymbol>.GetInstance();
            foreach (MethodSymbol candidate in candidates.OfType<MethodSymbol>())
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
        public ImmutableArray<MethodSymbol> InstanceConstructors => GetConstructors<MethodSymbol>(includeInstance: true, includeStatic: false);

        /// <summary>
        /// Get the static constructors for this type.
        /// </summary>
        public ImmutableArray<MethodSymbol> StaticConstructors => GetConstructors<MethodSymbol>(includeInstance: false, includeStatic: true);

        /// <summary>
        /// Get the instance and static constructors for this type.
        /// </summary>
        public ImmutableArray<MethodSymbol> Constructors => GetConstructors<MethodSymbol>(includeInstance: true, includeStatic: true);

        private ImmutableArray<TMethodSymbol> GetConstructors<TMethodSymbol>(bool includeInstance, bool includeStatic) where TMethodSymbol : MethodSymbol
        {
            Debug.Assert(includeInstance || includeStatic);

            ImmutableArray<DeclaredSymbol> instanceCandidates = includeInstance
                ? GetMembers(WellKnownMemberNames.InstanceConstructorName)
                : ImmutableArray<DeclaredSymbol>.Empty;
            ImmutableArray<DeclaredSymbol> staticCandidates = includeStatic
                ? GetMembers(WellKnownMemberNames.StaticConstructorName)
                : ImmutableArray<DeclaredSymbol>.Empty;

            if (instanceCandidates.IsEmpty && staticCandidates.IsEmpty)
            {
                return ImmutableArray<TMethodSymbol>.Empty;
            }

            ArrayBuilder<TMethodSymbol> constructors = ArrayBuilder<TMethodSymbol>.GetInstance();
            foreach (Symbol candidate in instanceCandidates)
            {
                if (candidate.Kind == SymbolKind.Member && ((MemberSymbol)candidate).MemberKind == MemberKind.Method)
                {
                    TMethodSymbol method = candidate as TMethodSymbol;
                    Debug.Assert((object)method != null);
                    Debug.Assert(method.MethodKind == MethodKind.Constructor);
                    constructors.Add(method);
                }
            }
            foreach (Symbol candidate in staticCandidates)
            {
                if (candidate.Kind == SymbolKind.Member && ((MemberSymbol)candidate).MemberKind == MemberKind.Method)
                {
                    TMethodSymbol method = candidate as TMethodSymbol;
                    Debug.Assert((object)method != null);
                    Debug.Assert(method.MethodKind == MethodKind.StaticConstructor);
                    constructors.Add(method);
                }
            }
            return constructors.ToImmutableAndFree();
        }

        public ImmutableArray<NamedTypeSymbol> DeclaredBaseTypes => GetDeclaredBaseTypes(null);

        public abstract ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved);

        public virtual int Arity => 0;

        /// <summary>
        /// The original definition of this symbol. If this symbol is constructed from another
        /// symbol by type substitution then OriginalDefinition gets the original symbol as it was defined in
        /// source or metadata.
        /// </summary>
        public new virtual NamedTypeSymbol OriginalDefinition => this;

        protected override sealed TypeSymbol OriginalTypeSymbolDefinition => this.OriginalDefinition;

        public virtual bool IsExplicitDefinitionOfNoPiaLocalType => false;

        /// <summary>
        /// For enum types, gets the underlying type. Returns null on all other
        /// kinds of types.
        /// </summary>
        public virtual NamedTypeSymbol EnumUnderlyingType => null;

        /// <summary>
        /// If this is a tuple type symbol, returns the symbol for its underlying type.
        /// Otherwise, returns null.
        /// </summary>
        public virtual NamedTypeSymbol TupleUnderlyingType => null;

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
            Debug.Assert(!this.IsTupleType);

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

        internal DiagnosticInfo CalculateUseSiteDiagnostic()
        {
            // TODO:MetaDslx
            return null;
        }


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
            foreach (var @base in this.BaseTypesNoUseSiteDiagnostics)
            {
                if (@base.GetUnificationUseSiteDiagnosticRecursive(ref result, owner, ref checkedTypes))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        public override bool IsStatic => false;

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
                return kind != TypeKind.Enum && kind != TypeKind.Value && kind != TypeKind.Error;
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
                return kind == TypeKind.Value || kind == TypeKind.Enum;
            }
        }

        /// <summary>
        /// Should the name returned by Name property be mangled with any suffix in order to get metadata name.
        /// </summary>
        public virtual bool MangleName => false;

        public virtual bool IsScript => false;

        public virtual bool IsSubmission => TypeKind == TypeKind.Submission;

        public virtual bool IsImplicit => false;

        public virtual bool IsInterface => false;

        public virtual bool MightContainExtensionMethods => false;

        public virtual bool IsGenericType => false;

        /// <summary>
        /// Returns the type parameters that this type has. If this is a non-generic type,
        /// returns an empty ImmutableArray.  
        /// </summary>
        public virtual ImmutableArray<TypeParameterSymbol> TypeParameters => ImmutableArray<TypeParameterSymbol>.Empty;

        /// <summary>
        /// Returns the type arguments that have been substituted for the type parameters. 
        /// If nothing has been substituted for a give type parameters,
        /// then the type parameter itself is consider the type argument.
        /// </summary>
        internal virtual ImmutableArray<TypeWithAnnotations> TypeArgumentsWithAnnotationsNoUseSiteDiagnostics => ImmutableArray<TypeWithAnnotations>.Empty;

        internal ImmutableArray<TypeWithAnnotations> TypeArgumentsWithDefinitionUseSiteDiagnostics(ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var result = TypeArgumentsWithAnnotationsNoUseSiteDiagnostics;

            foreach (var typeArgument in result)
            {
                typeArgument.Type.OriginalDefinition.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            }

            return result;
        }

        internal TypeWithAnnotations TypeArgumentWithDefinitionUseSiteDiagnostics(int index, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            var result = TypeArgumentsWithAnnotationsNoUseSiteDiagnostics[index];
            result.Type.OriginalDefinition.AddUseSiteDiagnostics(ref useSiteDiagnostics);
            return result;
        }

        /// <summary>
        /// Returns the type symbol that this type was constructed from. This type symbol
        /// has the same containing type (if any), but has type arguments that are the same
        /// as the type parameters (although its containing type might not).
        /// </summary>
        public virtual NamedTypeSymbol ConstructedFrom { get; }
        public bool IsUnboundGenericType { get; internal set; }
        public bool IsScriptClass { get; internal set; }
        public bool IsImplicitClass { get; internal set; }
        public bool IsSerializable { get; internal set; }
        public NamedTypeSymbol NativeIntegerUnderlyingType { get; internal set; }
        public ImmutableArray<FieldSymbol> TupleElements { get; internal set; }
        public MethodSymbol DelegateInvokeMethod { get; internal set; }

        /// <summary>
        /// Returns a constructed type given its type arguments.
        /// </summary>
        /// <param name="typeArguments">The immediate type arguments to be replaced for type
        /// parameters in the type.</param>
        internal NamedTypeSymbol Construct(params TypeWithAnnotations[] typeArguments)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Returns a constructed type given its type arguments.
        /// </summary>
        /// <param name="typeArguments">The immediate type arguments to be replaced for type
        /// parameters in the type.</param>
        internal NamedTypeSymbol Construct(ImmutableArray<TypeWithAnnotations> typeArguments)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Returns a constructed type given its type arguments.
        /// </summary>
        /// <param name="typeArguments"></param>
        internal NamedTypeSymbol Construct(IEnumerable<TypeWithAnnotations> typeArguments)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Returns an unbound generic type of this named type.
        /// </summary>
        public NamedTypeSymbol ConstructUnboundGenericType()
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        internal NamedTypeSymbol GetUnboundGenericTypeOrSelf()
        {
            if (!this.IsGenericType)
            {
                return this;
            }

            return this.ConstructUnboundGenericType();
        }


        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitNamedType(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitNamedType(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitNamedType(this, argument);
        }

        protected override ISymbol CreateISymbol()
        {
            return new PublicModel.NonErrorNamedTypeSymbol(this, DefaultNullableAnnotation);
        }

        protected override ITypeSymbol CreateITypeSymbol(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
        {
            Debug.Assert(nullableAnnotation != DefaultNullableAnnotation);
            return new PublicModel.NonErrorNamedTypeSymbol(this, nullableAnnotation);
        }
    }
}
