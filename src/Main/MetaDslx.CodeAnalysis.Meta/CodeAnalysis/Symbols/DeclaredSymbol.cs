using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis.Symbols;
using Microsoft.Cci;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis.Collections;
using System.Linq;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract partial class DeclaredSymbol : Symbol, ISymbolInternal
    {
        private static MemberLookupCache EmptyMemberCache = new MemberLookupCache(null);
        private static ConditionalWeakTable<DeclaredSymbol, MemberLookupCache> s_memberLookup = new ConditionalWeakTable<DeclaredSymbol, MemberLookupCache>();

        /// <summary>
        /// The original definition of this symbol. If this symbol is constructed from another
        /// symbol by type substitution then OriginalDefinition gets the original symbol as it was defined in
        /// source or metadata.
        /// </summary>
        /// <summary>
        /// The original definition of this symbol. If this symbol is constructed from another
        /// symbol by type substitution then OriginalDefinition gets the original symbol as it was defined in
        /// source or metadata.
        /// </summary>
        public DeclaredSymbol OriginalDefinition => OriginalSymbolDefinition;

        protected virtual DeclaredSymbol OriginalSymbolDefinition => this;

        /// <summary>
        /// Returns true if this is the original definition of this symbol.
        /// </summary>
        public bool IsDefinition => (object)this == (object)OriginalDefinition;

        /// <summary>
        /// Returns true if this symbol can be referenced by its name in code. Examples of symbols
        /// that cannot be referenced by name are:
        ///    constructors, destructors, operators, explicit interface implementations,
        ///    accessor methods for properties and events, array types.
        /// </summary>
        public virtual bool CanBeReferencedByName
        {
            get
            {
                return !string.IsNullOrEmpty(Name);
            }
        }

        /// <summary>
        /// Get this accessibility that was declared on this symbol. For symbols that do not have
        /// accessibility declared on them, returns <see cref="Accessibility.NotApplicable"/>.
        /// </summary>
        public virtual Accessibility DeclaredAccessibility => Accessibility.Public;

        /// <summary>
        /// Returns true if this symbol is "static"; i.e., declared with the <c>static</c> modifier or
        /// implicitly static.
        /// </summary>
        public abstract bool IsStatic { get; }

        /// <summary>
        /// Returns true if this symbol is "virtual", has an implementation, and does not override a
        /// base class member; i.e., declared with the <c>virtual</c> modifier. Does not return true for
        /// members declared as abstract or override.
        /// </summary>
        public virtual bool IsVirtual => false;

        /// <summary>
        /// Returns true if this symbol was declared to override a base class member; i.e., declared
        /// with the <c>override</c> modifier. Still returns true if member was declared to override
        /// something, but (erroneously) no member to override exists.
        /// </summary>
        /// <remarks>
        /// Even for metadata symbols, <see cref="IsOverride"/> = true does not imply that <see cref="IMethodSymbol.OverriddenMethod"/> will
        /// be non-null.
        /// </remarks>
        public virtual bool IsOverride => false;

        /// <summary>
        /// Returns true if this symbol was declared as requiring an override; i.e., declared with
        /// the <c>abstract</c> modifier. Also returns true on a type declared as "abstract", all
        /// interface types, and members of interface types.
        /// </summary>
        public virtual bool IsAbstract => false;

        /// <summary>
        /// Returns true if this symbol was declared to override a base class member and was also
        /// sealed from further overriding; i.e., declared with the <c>sealed</c> modifier. Also set for
        /// types that do not allow a derived class (declared with <c>sealed</c> or <c>static</c> or <c>struct</c>
        /// or <c>enum</c> or <c>delegate</c>).
        /// </summary>
        public virtual bool IsSealed => false;

        /// <summary>
        /// Returns true if this symbol has external implementation; i.e., declared with the 
        /// <c>extern</c> modifier. 
        /// </summary>
        public virtual bool IsExtern => false;

        /// <summary>
        /// Returns true if this symbol was automatically created by the compiler, and does not
        /// have an explicit corresponding source code declaration.  
        /// 
        /// This is intended for symbols that are ordinary symbols in the language sense,
        /// and may be used by code, but that are simply declared implicitly rather than
        /// with explicit language syntax.
        /// 
        /// Examples include (this list is not exhaustive):
        ///   the default constructor for a class or struct that is created if one is not provided,
        ///   the BeginInvoke/Invoke/EndInvoke methods for a delegate,
        ///   the generated backing field for an auto property or a field-like event,
        ///   the "this" parameter for non-static methods,
        ///   the "value" parameter for a property setter,
        ///   the parameters on indexer accessor methods (not on the indexer itself),
        ///   methods in anonymous types,
        ///   anonymous functions
        /// </summary>
        public virtual bool IsImplicitlyDeclared => false;

        [SymbolProperty]
        public virtual ImmutableArray<DeclaredSymbol> Members => ImmutableArray<DeclaredSymbol>.Empty;

        /// <summary>
        /// Get all the members of this symbol.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol. If this symbol has no members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public ImmutableArray<DeclaredSymbol> GetMembers() 
        {
            return GetMemberLookupCache().GetMembers();
        }

        /// <summary>
        /// Get all the members of this symbol. The members may not be in a particular order, and the order
        /// may not be stable from call-to-call.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol. If this symbol has no members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        internal ImmutableArray<DeclaredSymbol> GetMembersUnordered()
        {
            // Default implementation is to use ordered version. When performance indicates, we specialize to have
            // separate implementation.

            return GetMembers().ConditionallyDeOrder();
        }

        /// <summary>
        /// Get all the members of this symbol that have a particular name.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol with the given name. If there are
        /// no members with this name, returns an empty ImmutableArray. Never returns null.</returns>
        public ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return GetMemberLookupCache().GetMembers(name);
        }

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name and metadata name
        /// </summary>
        /// <returns>An IEnumerable containing all the types that are members of this symbol with the given name and metadata name.
        /// If this symbol has no type members with this name and metadata name,
        /// returns an empty IEnumerable. Never returns null.</returns>
        public ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            return GetMemberLookupCache().GetMembers(name, metadataName);
        }

        /// <summary>
        /// Get all the members of this symbol that are types. The members may not be in a particular order, and the order
        /// may not be stable from call-to-call.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol. If this symbol has no type members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        internal virtual ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            // Default implementation is to use ordered version. When performance indicates, we specialize to have
            // separate implementation.
            return GetTypeMembers().ConditionallyDeOrder();
        }

        /// <summary>
        /// Get all the members of this symbol that are types.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol. If this symbol has no type members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return GetMemberLookupCache().GetTypeMembers();
        }

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name, of any metadata name.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol with the given name.
        /// If this symbol has no type members with this name,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return GetMemberLookupCache().GetTypeMembers(name);
        }

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name and metadata name
        /// </summary>
        /// <returns>An IEnumerable containing all the types that are members of this symbol with the given name and metadata name.
        /// If this symbol has no type members with this name and metadata name,
        /// returns an empty IEnumerable. Never returns null.</returns>
        public ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return GetMemberLookupCache().GetTypeMembers(name, metadataName);
        }

        public virtual void CheckMembers(Dictionary<string, ImmutableArray<DeclaredSymbol>> result, DiagnosticBag diagnostics)
        {

        }

        /// <summary>
        /// Get a source symbol for the given declaration syntax.
        /// </summary>
        /// <returns>Null if there is no matching declaration.</returns>
        public DeclaredSymbol GetSourceMember(SyntaxNodeOrToken syntax)
        {
            foreach (var member in GetMembers())
            {
                if (syntax != null)
                {
                    var locations = member.Locations;
                    if (locations.Length == 0)
                    {
                        foreach (var syntaxRef in member.DeclaringSyntaxReferences)
                        {
                            var loc = syntaxRef.GetLocation();
                            if (loc.IsInSource && loc.SourceTree == syntax.SyntaxTree && syntax.Span.Equals(loc.SourceSpan))
                            {
                                return member;
                            }
                        }
                    }
                    foreach (var loc in locations)
                    {
                        if (loc.IsInSource && loc.SourceTree == syntax.SyntaxTree && syntax.Span.Equals(loc.SourceSpan))
                        {
                            return member;
                        }
                    }
                }
                else
                {
                    return member;
                }
            }

            // None found.
            return null;
        }

        /// <summary>
        /// Returns the Documentation Comment ID for the symbol, or null if the symbol doesn't
        /// support documentation comments.
        /// </summary>
        public virtual string GetDocumentationCommentId()
        {
            // NOTE: we're using a try-finally here because there's a test that specifically
            // triggers an exception here to confirm that some symbols don't have documentation
            // comment IDs.  We don't care about "leaks" in such cases, but we don't want spew
            // in the test output.
            var pool = PooledStringBuilder.GetInstance();
            try
            {
                StringBuilder builder = pool.Builder;
                // TODO:MetaDslx
                // DocumentationCommentIDVisitor.Instance.Visit(this, builder);
                return builder.Length == 0 ? null : builder.ToString();
            }
            finally
            {
                pool.Free();
            }
        }

        /// <summary>
        /// Fetches the documentation comment for this element with a cancellation token.
        /// </summary>
        /// <param name="preferredCulture">Optionally, retrieve the comments formatted for a particular culture. No impact on source documentation comments.</param>
        /// <param name="expandIncludes">Optionally, expand <![CDATA[<include>]]> elements. No impact on non-source documentation comments.</param>
        /// <param name="cancellationToken">Optionally, allow cancellation of documentation comment retrieval.</param>
        /// <returns>The XML that would be written to the documentation file for the symbol.</returns>
        public virtual string GetDocumentationCommentXml(
            CultureInfo preferredCulture = null,
            bool expandIncludes = false,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return string.Empty;
        }


        /// <summary>
        /// Returns true and a <see cref="string"/> from the first <see cref="GuidAttribute"/> on the symbol, 
        /// the string might be null or an invalid guid representation. False, 
        /// if there is no <see cref="GuidAttribute"/> with string argument.
        /// </summary>
        public virtual bool GetGuidStringDefaultImplementation(out string guidString)
        {
            // TODO:MetaDslx
            guidString = null;
            return false;
        }

        internal DiagnosticInfo GetUseSiteDiagnosticForSymbolOrContainingType()
        {
            var info = this.GetUseSiteDiagnostic();
            if (info != null && info.Severity == DiagnosticSeverity.Error)
            {
                return info;
            }
            return this.ContainingType.GetUseSiteDiagnostic() ?? info;
        }

        /// <summary>
        /// Derive error info from a type symbol.
        /// </summary>
        internal bool DeriveUseSiteDiagnosticFromType(ref DiagnosticInfo result, TypeSymbol type)
        {
            DiagnosticInfo info = type.GetUseSiteDiagnostic();
            if (info != null)
            {
                if (info.HasErrorCode(InternalErrorCode.ERR_BogusType))
                {
                    switch (this.Kind.Switch())
                    {
                        case SymbolKind.Member:
                            info = new LanguageDiagnosticInfo(InternalErrorCode.ERR_BindToBogus, this);
                            break;
                    }
                }
            }

            return MergeUseSiteDiagnostics(ref result, info);
        }

        internal bool DeriveUseSiteDiagnosticFromCustomModifiers(ref DiagnosticInfo result, ImmutableArray<CustomModifier> customModifiers)
        {
            foreach (CustomModifier modifier in customModifiers)
            {
                var modifierType = (NamedTypeSymbol)modifier.Modifier;
                if (DeriveUseSiteDiagnosticFromType(ref result, modifierType))
                {
                    return true;
                }
            }
            return false;
        }

        internal DeclaredSymbol AsMember(NamedTypeSymbol newOwner)
        {
            Debug.Assert(this.IsDefinition);
            Debug.Assert(ReferenceEquals(newOwner.OriginalDefinition, (this.ContainingSymbol as DeclaredSymbol)?.OriginalDefinition));
            return this; // TODO:MetaDslx
            //return newOwner.IsDefinition ? this : new SubstitutedPropertySymbol(newOwner as SubstitutedNamedTypeSymbol, this);
        }


        public virtual DeclaredSymbol ConstructedFrom => this;

        Microsoft.CodeAnalysis.SymbolKind ISymbolInternal.Kind => this.Kind.ToCSharp();

        Compilation ISymbolInternal.DeclaringCompilation => this.DeclaringCompilation;

        ISymbolInternal ISymbolInternal.ContainingSymbol => this.ContainingDeclaration;

        IAssemblySymbolInternal ISymbolInternal.ContainingAssembly => throw new NotImplementedException();

        IModuleSymbolInternal ISymbolInternal.ContainingModule => throw new NotImplementedException();

        INamedTypeSymbolInternal ISymbolInternal.ContainingType => throw new NotImplementedException();

        INamespaceSymbolInternal ISymbolInternal.ContainingNamespace => throw new NotImplementedException();

        /// <summary>
        /// Returns the original virtual or abstract method which a given method symbol overrides,
        /// ignoring any other overriding methods in base classes.
        /// </summary>
        /// <param name="accessingTypeOpt">The search must respect accessibility from this type.</param>
        public virtual DeclaredSymbol GetLeastOverriddenMember(NamedTypeSymbol accessingTypeOpt)
        {
            return null;
        }

        /// <summary>
        /// Returns the original virtual or abstract method which a given method symbol overrides,
        /// ignoring any other overriding methods in base classes.
        /// Also, if the given method symbol is generic then the resulting virtual or abstract method is constructed with the
        /// same type arguments as the given method.
        /// </summary>
        public virtual DeclaredSymbol GetConstructedLeastOverriddenMember(NamedTypeSymbol accessingTypeOpt)
        {
            var m = this.ConstructedFrom.GetLeastOverriddenMember(accessingTypeOpt);
            return m; // TODO:MetaDslx
            //return m.IsGenericMethod ? m.Construct(this.TypeArgumentsWithAnnotations) : m;
        }

        /// <summary>
        /// Checks if 'symbol' is accessible from within named type 'within'.  If 'symbol' is accessed off
        /// of an expression then 'throughTypeOpt' is the type of that expression. This is needed to
        /// properly do protected access checks.
        /// </summary>
        public bool IsSymbolAccessibleWithin(NamedTypeSymbol within, NamedTypeSymbol throughTypeOpt = null)
        {
            if ((object)within == null)
            {
                throw new ArgumentNullException(nameof(within));
            }

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            return this.DeclaringCompilation.AccessCheck.IsSymbolAccessible(
                this,
                within,
                ref useSiteDiagnostics,
                throughTypeOpt);
        }

        /// <summary>
        /// Checks if 'symbol' is accessible from within assembly 'within'.  
        /// </summary>
        public bool IsSymbolAccessibleWithin(AssemblySymbol within)
        {
            if ((object)within == null)
            {
                throw new ArgumentNullException(nameof(within));
            }

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            return this.DeclaringCompilation.AccessCheck.IsSymbolAccessible(this, within, ref useSiteDiagnostics);
        }

        bool ISymbolInternal.Equals(ISymbolInternal? other, TypeCompareKind compareKind)
        {
            return this.Equals(other as DeclaredSymbol, compareKind);
        }

        ISymbol ISymbolInternal.GetISymbol()
        {
            return this.ISymbol;
        }

        IReference ISymbolInternal.GetCciAdapter()
        {
            throw new NotImplementedException();
        }


        private MemberLookupCache GetMemberLookupCache()
        {
            return s_memberLookup.GetValue(this, key => key.Members.IsDefaultOrEmpty ? EmptyMemberCache : new MemberLookupCache(key));
        }

        private class MemberLookupCache
        {
            private DeclaredSymbol? _symbol;
            private ImmutableArray<DeclaredSymbol> _members;
            private ImmutableArray<NamedTypeSymbol> _typeMembers;
            private CachingDictionary<string, DeclaredSymbol> _membersByName;
            private CachingDictionary<string, NamedTypeSymbol> _typeMembersByName;
            private CachingDictionary<string, DeclaredSymbol> _membersByMetadataName;
            private CachingDictionary<string, NamedTypeSymbol> _typeMembersByMetadataName;

            public MemberLookupCache(DeclaredSymbol? symbol)
            {
                _symbol = symbol;
                if (symbol is null)
                {
                    _members = ImmutableArray<DeclaredSymbol>.Empty;
                    _typeMembers = ImmutableArray<NamedTypeSymbol>.Empty;
                }
            }

            public ImmutableArray<DeclaredSymbol> GetMembers()
            {
                if (_members.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _members, _symbol.Members);
                }
                return _members;
            }

            public ImmutableArray<DeclaredSymbol> GetMembers(string name)
            {
                var members = this.GetMembers();
                if (members.IsEmpty) return ImmutableArray<DeclaredSymbol>.Empty;
                if (_membersByName is null)
                {
                    Interlocked.CompareExchange(ref _membersByName, new CachingDictionary<string, DeclaredSymbol>(cachedName => this.GetMembers().WhereAsArray(m => m.Name == cachedName), SlowGetMemberNames, EqualityComparer<string>.Default), null);
                }
                return _membersByName[name];
            }

            public ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
            {
                var members = this.GetMembers();
                if (members.IsEmpty) return ImmutableArray<DeclaredSymbol>.Empty;
                if (_membersByMetadataName is null)
                {
                    Interlocked.CompareExchange(ref _membersByMetadataName, new CachingDictionary<string, DeclaredSymbol>(cachedName => this.GetMembers().WhereAsArray(m => m.MetadataName == cachedName), SlowGetMemberMetadataNames, EqualityComparer<string>.Default), null);
                }
                return _membersByMetadataName[metadataName];
            }

            public ImmutableArray<NamedTypeSymbol> GetTypeMembers()
            {
                if (_typeMembers.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _typeMembers, this.GetMembers().OfType<NamedTypeSymbol>().ToImmutableArray());
                }
                return _typeMembers;
            }

            public ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
            {
                var members = this.GetTypeMembers();
                if (members.IsEmpty) return ImmutableArray<NamedTypeSymbol>.Empty;
                if (_typeMembersByName is null)
                {
                    Interlocked.CompareExchange(ref _typeMembersByName, new CachingDictionary<string, NamedTypeSymbol>(cachedName => this.GetTypeMembers().WhereAsArray(m => m.Name == cachedName), SlowGetTypeMemberNames, EqualityComparer<string>.Default), null);
                }
                return _typeMembersByName[name];
            }

            public ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
            {
                var members = this.GetTypeMembers();
                if (members.IsEmpty) return ImmutableArray<NamedTypeSymbol>.Empty;
                if (_typeMembersByMetadataName is null)
                {
                    Interlocked.CompareExchange(ref _typeMembersByMetadataName, new CachingDictionary<string, NamedTypeSymbol>(cachedName => this.GetTypeMembers().WhereAsArray(m => m.MetadataName == cachedName), SlowGetTypeMemberMetadataNames, EqualityComparer<string>.Default), null);
                }
                return _typeMembersByMetadataName[metadataName];
            }

            private HashSet<string> SlowGetMemberNames(IEqualityComparer<string> comparer)
            {
                var names = new HashSet<string>(comparer);
                names.UnionWith(this.GetMembers().Select(m => m.Name));
                return names;
            }

            private HashSet<string> SlowGetTypeMemberNames(IEqualityComparer<string> comparer)
            {
                var names = new HashSet<string>(comparer);
                names.UnionWith(this.GetTypeMembers().Select(m => m.Name));
                return names;
            }

            private HashSet<string> SlowGetMemberMetadataNames(IEqualityComparer<string> comparer)
            {
                var names = new HashSet<string>(comparer);
                names.UnionWith(this.GetMembers().Select(m => m.MetadataName));
                return names;
            }

            private HashSet<string> SlowGetTypeMemberMetadataNames(IEqualityComparer<string> comparer)
            {
                var names = new HashSet<string>(comparer);
                names.UnionWith(this.GetTypeMembers().Select(m => m.MetadataName));
                return names;
            }
        }
    }
}
