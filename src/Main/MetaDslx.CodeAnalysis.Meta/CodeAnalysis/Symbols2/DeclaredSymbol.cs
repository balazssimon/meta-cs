using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Syntax;
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

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract partial class DeclaredSymbol : Symbol, IDeclaredSymbol
    {
        /// <summary>
        /// Returns the nearest lexically enclosing declaration, or null if there is none.
        /// </summary>
        public virtual DeclaredSymbol ContainingDeclaration
        {
            get
            {
                Symbol container = this.ContainingSymbol;

                while (container != null)
                {
                    DeclaredSymbol containerAsDeclaration = container as DeclaredSymbol;

                    // NOTE: container could be null, so we do not check 
                    //       whether containerAsType is not null, but 
                    //       instead check if it did not change after 
                    //       the cast.
                    if ((object)containerAsDeclaration == (object)container)
                    {
                        // this should be relatively uncommon
                        // most symbols that may be contained in a type
                        // know their containing type and can override ContainingType
                        // with a more precise implementation
                        return containerAsDeclaration;
                    }

                    container = container.ContainingSymbol;
                }

                return null;
            }
        }

        /// <summary>
        /// Returns the nearest lexically enclosing type, or null if there is none.
        /// </summary>
        public virtual NamedTypeSymbol ContainingType
        {
            get
            {
                DeclaredSymbol container = this.ContainingDeclaration;

                NamedTypeSymbol containerAsType = container as NamedTypeSymbol;

                // NOTE: container could be null, so we do not check 
                //       whether containerAsType is not null, but 
                //       instead check if it did not change after 
                //       the cast.
                if ((object)containerAsType == (object)container)
                {
                    // this should be relatively uncommon
                    // most symbols that may be contained in a type
                    // know their containing type and can override ContainingType
                    // with a more precise implementation
                    return containerAsType;
                }

                // this is recursive, but recursion should be very short 
                // before we reach symbol that definitely knows its containing type.
                return container.ContainingType;
            }
        }

        /// <summary>
        /// Gets the nearest enclosing namespace for this namespace or type. For a nested type,
        /// returns the namespace that contains its container.
        /// </summary>
        public virtual NamespaceSymbol ContainingNamespace
        {
            get
            {
                for (var container = this.ContainingDeclaration; (object)container != null; container = container.ContainingDeclaration)
                {
                    var ns = container as NamespaceSymbol;
                    if ((object)ns != null)
                    {
                        return ns;
                    }
                }

                return null;
            }
        }

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
                return ModelSymbolInfo?.HasName ?? false;
            }
        }

        /// <summary>
        /// <para>
        /// Get the syntax node(s) where this symbol was declared in source. Some symbols (for
        /// example, partial classes) may be defined in more than one location. This property should
        /// return one or more syntax nodes only if the symbol was declared in source code and also
        /// was not implicitly declared (see the <see cref="IsImplicitlyDeclared"/> property). 
        /// </para>
        /// <para>
        /// Note that for namespace symbol, the declaring syntax might be declaring a nested
        /// namespace. For example, the declaring syntax node for N1 in "namespace N1.N2 {...}" is
        /// the entire <see cref="NamespaceDeclarationSyntax"/> for N1.N2. For the global namespace, the declaring
        /// syntax will be the <see cref="CompilationUnitSyntax"/>.
        /// </para>
        /// </summary>
        /// <returns>
        /// The syntax node(s) that declared the symbol. If the symbol was declared in metadata or
        /// was implicitly declared, returns an empty read-only array.
        /// </returns>
        /// <remarks>
        /// To go the opposite direction (from syntax node to symbol), see <see
        /// cref="CSharpSemanticModel.GetDeclaredSymbol(MemberDeclarationSyntax, CancellationToken)"/>.
        /// </remarks>
        public abstract ImmutableArray<SyntaxReference> DeclaringSyntaxReferences { get; }

        /// <summary>
        /// Helper for implementing <see cref="DeclaringSyntaxReferences"/> for derived classes that store a location but not a 
        /// <see cref="CSharpSyntaxNode"/> or <see cref="SyntaxReference"/>.
        /// </summary>
        internal static ImmutableArray<SyntaxReference> GetDeclaringSyntaxReferenceHelper<TNode>(ImmutableArray<Location> locations)
            where TNode : LanguageSyntaxNode
        {
            if (locations.IsEmpty)
            {
                return ImmutableArray<SyntaxReference>.Empty;
            }

            ArrayBuilder<SyntaxReference> builder = ArrayBuilder<SyntaxReference>.GetInstance();
            foreach (Location location in locations)
            {
                // Location may be null. See https://github.com/dotnet/roslyn/issues/28862.
                if (location == null)
                {
                    continue;
                }
                if (location.IsInSource)
                {
                    SyntaxToken token = (SyntaxToken)location.SourceTree.GetRoot().FindToken(location.SourceSpan.Start);
                    if (token.GetKind() != SyntaxKind.None)
                    {
                        LanguageSyntaxNode node = token.Parent.FirstAncestorOrSelf<TNode>();
                        if (node != null)
                            builder.Add(node.GetReference());
                    }
                }
            }

            return builder.ToImmutableAndFree();
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

        /// <summary>
        /// Get all the members of this symbol.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol. If this symbol has no members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract ImmutableArray<DeclaredSymbol> GetMembers();

        /// <summary>
        /// Get all the members of this symbol. The members may not be in a particular order, and the order
        /// may not be stable from call-to-call.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol. If this symbol has no members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        internal virtual ImmutableArray<DeclaredSymbol> GetMembersUnordered()
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
        public abstract ImmutableArray<DeclaredSymbol> GetMembers(string name);

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name and arity
        /// </summary>
        /// <returns>An IEnumerable containing all the types that are members of this symbol with the given name and arity.
        /// If this symbol has no type members with this name and arity,
        /// returns an empty IEnumerable. Never returns null.</returns>
        public virtual ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            // default implementation does a post-filter. We can override this if its a performance burden, but 
            // experience is that it won't be.
            return GetMembers(name).WhereAsArray(m => m.MetadataName == metadataName);
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
        public abstract ImmutableArray<NamedTypeSymbol> GetTypeMembers();

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name, of any arity.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol with the given name.
        /// If this symbol has no type members with this name,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name);

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name and arity
        /// </summary>
        /// <returns>An IEnumerable containing all the types that are members of this symbol with the given name and arity.
        /// If this symbol has no type members with this name and arity,
        /// returns an empty IEnumerable. Never returns null.</returns>
        public virtual ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            // default implementation does a post-filter. We can override this if its a performance burden, but 
            // experience is that it won't be.
            return GetTypeMembers(name).WhereAsArray(t => t.MetadataName == metadataName);
        }

        public virtual MergedDeclaration MergedDeclaration => null;

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

        public virtual bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken = default(CancellationToken))
        {
            var declaringReferences = this.DeclaringSyntaxReferences;
            var container = this.ContainingSymbol as DeclaredSymbol;
            if (this.IsImplicitlyDeclared && declaringReferences.Length == 0 && container != null)
            {
                return container.IsDefinedInSourceTree(tree, definedWithinSpan, cancellationToken);
            }

            foreach (var syntaxRef in declaringReferences)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (syntaxRef.SyntaxTree == tree &&
                    (!definedWithinSpan.HasValue || syntaxRef.Span.IntersectsWith(definedWithinSpan.Value)))
                {
                    return true;
                }
            }

            return false;
        }

        internal static void ForceCompleteMemberByLocation(SourceLocation locationOpt, DeclaredSymbol member, CancellationToken cancellationToken)
        {
            if (locationOpt == null || member.IsDefinedInSourceTree(locationOpt.SourceTree, locationOpt.SourceSpan, cancellationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();
                member.ForceComplete(locationOpt, cancellationToken);
            }
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
                        case LanguageSymbolKind.Name:
                        case LanguageSymbolKind.Operation:
                        case LanguageSymbolKind.Property:
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


        bool IDeclaredSymbol.IsImplicitlyDeclared => this.IsImplicitlyDeclared;

        INamedTypeSymbol IDeclaredSymbol.ContainingType => this.ContainingType;

        INamespaceSymbol IDeclaredSymbol.ContainingNamespace => this.ContainingNamespace;

        bool IDeclaredSymbol.IsDefinition => this.IsDefinition;

        bool IDeclaredSymbol.IsStatic => this.IsStatic;

        bool IDeclaredSymbol.IsVirtual => this.IsVirtual;

        bool IDeclaredSymbol.IsOverride => this.IsOverride;

        bool IDeclaredSymbol.IsAbstract => this.IsAbstract;

        bool IDeclaredSymbol.IsSealed => this.IsSealed;

        ImmutableArray<SyntaxReference> IDeclaredSymbol.DeclaringSyntaxReferences => this.DeclaringSyntaxReferences;

        Accessibility IDeclaredSymbol.DeclaredAccessibility => this.DeclaredAccessibility;

        IDeclaredSymbol IDeclaredSymbol.OriginalDefinition => this.OriginalDefinition;


    }
}
