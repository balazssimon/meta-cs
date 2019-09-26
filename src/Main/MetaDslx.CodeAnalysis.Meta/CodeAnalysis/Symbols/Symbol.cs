﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using SymbolDisplay = Microsoft.CodeAnalysis.CSharp.SymbolDisplay;
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;

    /// <summary>
    /// The base class for all symbols (namespaces, classes, method, parameters, etc.) that are 
    /// exposed by the compiler.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public abstract partial class Symbol : ISymbol, IFormattable
    {
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Changes to the public interface of this class should remain synchronized with the VB version of Symbol.
        // Do not make any changes to the public interface without making the corresponding change
        // to the VB version.
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        public virtual ModelSymbolInfo ModelSymbolInfo => null;

        public virtual Language Language => Language.None;

        internal protected virtual MutableModel ModelBuilder => null;

        public virtual IMetaSymbol ModelObject => null;

        /// <summary>
        /// True if this Symbol should be completed by calling ForceComplete.
        /// Intuitively, true for source entities (from any compilation).
        /// </summary>
        public virtual bool RequiresCompletion => false;

        public virtual void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            // must be overridden by source symbols, no-op for other symbols
            Debug.Assert(!this.RequiresCompletion);
        }

        public virtual bool HasComplete(CompletionPart part)
        {
            // must be overridden by source symbols, no-op for other symbols
            Debug.Assert(!this.RequiresCompletion);
            return true;
        }

        /// <summary>
        /// Gets the name of this symbol. Symbols without a name return the empty string; null is
        /// never returned.
        /// </summary>
        public virtual string Name => string.Empty;

        /// <summary>
        /// Gets the name of a symbol as it appears in metadata. Most of the time, this
        /// is the same as the Name property, with the following exceptions:
        /// 1) The metadata name of generic types includes the "`1", "`2" etc. suffix that
        /// indicates the number of type parameters (it does not include, however, names of
        /// containing types or namespaces).
        /// 2) The metadata name of explicit interface names have spaces removed, compared to
        /// the name property.
        /// </summary>
        public virtual string MetadataName => this.Name;

        /// <summary>
        /// Gets the kind of this symbol.
        /// </summary>
        public virtual LanguageSymbolKind Kind => LanguageSymbolKind.None;

        /// <summary>
        /// Get the symbol that logically contains this symbol. 
        /// </summary>
        public abstract Symbol ContainingSymbol { get; }

        /// <summary>
        /// Returns the nearest lexically enclosing type, or null if there is none.
        /// </summary>
        public virtual NamedTypeSymbol ContainingType
        {
            get
            {
                Symbol container = this.ContainingSymbol;

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
                for (var container = this.ContainingSymbol; (object)container != null; container = container.ContainingSymbol)
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
        /// Returns the assembly containing this symbol. If this symbol is shared across multiple
        /// assemblies, or doesn't belong to an assembly, returns null.
        /// </summary>
        public virtual AssemblySymbol ContainingAssembly
        {
            get
            {
                // Default implementation gets the containers assembly.

                var container = this.ContainingSymbol;
                return (object)container != null ? container.ContainingAssembly : null;
            }
        }

        /// <summary>
        /// For a source assembly, the associated compilation.
        /// For any other assembly, null.
        /// For a source module, the DeclaringCompilation of the associated source assembly.
        /// For any other module, null.
        /// For any other symbol, the DeclaringCompilation of the associated module.
        /// </summary>
        /// <remarks>
        /// We're going through the containing module, rather than the containing assembly,
        /// because of /addmodule (symbols in such modules should return null).
        /// 
        /// Remarks, not "ContainingCompilation" because it isn't transitive.
        /// </remarks>
        internal virtual LanguageCompilation DeclaringCompilation
        {
            get
            {
                switch (this.Kind.Switch())
                {
                    case LanguageSymbolKind.ErrorType:
                        return null;
                    case LanguageSymbolKind.Assembly:
                        Debug.Assert(!(this is SourceAssemblySymbol), "SourceAssemblySymbol must override DeclaringCompilation");
                        return null;
                    case LanguageSymbolKind.NetModule:
                        Debug.Assert(!(this is SourceModuleSymbol), "SourceModuleSymbol must override DeclaringCompilation");
                        return null;
                }

                var sourceModuleSymbol = this.ContainingModule as SourceModuleSymbol;
                return (object)sourceModuleSymbol == null ? null : sourceModuleSymbol.DeclaringCompilation;
            }
        }

        /// <summary>
        /// Returns the module containing this symbol. If this symbol is shared across multiple
        /// modules, or doesn't belong to a module, returns null.
        /// </summary>
        public virtual ModuleSymbol ContainingModule
        {
            get
            {
                // Default implementation gets the containers module.
                var container = this.ContainingSymbol;
                if (container is ModuleSymbol moduleSymbol) return moduleSymbol;
                return (object)container != null ? container.ContainingModule : null;
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
        public Symbol OriginalDefinition => OriginalSymbolDefinition;

        protected virtual Symbol OriginalSymbolDefinition => this;

        /// <summary>
        /// Returns true if this is the original definition of this symbol.
        /// </summary>
        public bool IsDefinition => (object)this == (object)OriginalDefinition;

        /// <summary>
        /// <para>
        /// Get a source location key for sorting. For performance, it's important that this
        /// be able to be returned from a symbol without doing any additional allocations (even
        /// if nothing is cached yet.)
        /// </para>
        /// <para>
        /// Only (original) source symbols and namespaces that can be merged
        /// need implement this function if they want to do so for efficiency.
        /// </para>
        /// </summary>
        public virtual LexicalSortKey GetLexicalSortKey()
        {
            var locations = this.Locations;
            var declaringCompilation = this.DeclaringCompilation;
            Debug.Assert(declaringCompilation != null); // require that it is a source symbol
            return (locations.Length > 0) ? new LexicalSortKey(locations[0], declaringCompilation) : LexicalSortKey.NotInSource;
        }

        /// <summary>
        /// Gets the locations where this symbol was originally defined, either in source or
        /// metadata. Some symbols (for example, partial classes) may be defined in more than one
        /// location.
        /// </summary>
        public abstract ImmutableArray<Location> Locations { get; }

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
        public virtual Accessibility DeclaredAccessibility => Accessibility.NotApplicable;

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

        public virtual ImmutableArray<AttributeData> GetAttributes()
        {
            return ImmutableArray<AttributeData>.Empty;
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

        // Note: This is no public "IsNew". This is intentional, because new has no syntactic meaning.
        // It serves only to remove a warning. Furthermore, it can not be inferred from 
        // metadata. For symbols defined in source, the modifiers in the syntax tree
        // can be examined.

        /// <summary>
        /// Compare two symbol objects to see if they refer to the same symbol. You should always
        /// use <see cref="operator =="/> and <see cref="operator !="/>, or the <see cref="Equals(object)"/> method, to compare two symbols for equality.
        /// </summary>
        public static bool operator ==(Symbol left, Symbol right)
        {
            //PERF: this function is often called with
            //      1) left referencing same object as the right 
            //      2) right being null
            //      The code attempts to check for these conditions before 
            //      resorting to .Equals

            // the condition is expected to be folded when inlining "someSymbol == null"
            if (((object)right == null))
            {
                return (object)left == (object)null;
            }

            // this part is expected to disappear when inlining "someSymbol == null"
            return (object)left == (object)right || right.Equals(left);
        }

        /// <summary>
        /// Compare two symbol objects to see if they refer to the same symbol. You should always
        /// use == and !=, or the Equals method, to compare two symbols for equality.
        /// </summary>
        public static bool operator !=(Symbol left, Symbol right)
        {
            //PERF: this function is often called with
            //      1) left referencing same object as the right 
            //      2) right being null
            //      The code attempts to check for these conditions before 
            //      resorting to .Equals
            //
            //NOTE: we do not implement this as !(left == right) 
            //      since that sometimes results in a worse code

            // the condition is expected to be folded when inlining "someSymbol != null"
            if (((object)right == null))
            {
                return (object)left != (object)null;
            }

            // this part is expected to disappear when inlining "someSymbol != null"
            return (object)left != (object)right && !right.Equals(left);
        }

        // By default, we do reference equality. This can be overridden.
        public override bool Equals(object obj)
        {
            return (object)this == obj;
        }

        public bool Equals(ISymbol other)
        {
            return this.Equals((object)other);
        }

        // By default, we do reference equality. This can be overridden.
        public override int GetHashCode()
        {
            return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(this);
        }

        /// <summary>
        /// Returns a string representation of this symbol, suitable for debugging purposes, or
        /// for placing in an error message.
        /// </summary>
        /// <remarks>
        /// This will provide a useful representation, but it would be clearer to call <see cref="ToDisplayString"/>
        /// directly and provide an explicit format.
        /// Sealed so that <see cref="ToString"/> and <see cref="ToDisplayString"/> can't get out of sync.
        /// </remarks>
        public sealed override string ToString()
        {
            return this.ToDisplayString();
        }

        // ---- End of Public Definition ---
        // Below here can be various useful virtual methods that are useful to the compiler, but we don't
        // want to expose publicly.
        // ---- End of Public Definition ---

        // Prevent anyone else from deriving from this class.
        internal Symbol()
        {
        }

        internal bool IsFromCompilation(LanguageCompilation compilation)
        {
            Debug.Assert(compilation != null);
            return compilation == this.DeclaringCompilation;
        }

        /// <summary>
        /// Always prefer <see cref="IsFromCompilation"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Unfortunately, when determining overriding/hiding/implementation relationships, we don't 
        /// have the "current" compilation available.  We could, but that would clutter up the API 
        /// without providing much benefit.  As a compromise, we consider all compilations "current".
        /// </para>
        /// <para>
        /// Unlike in VB, we are not allowing retargeting symbols.  This method is used as an approximation
        /// for <see cref="IsFromCompilation"/> when a compilation is not available and that method will never return
        /// true for retargeting symbols.
        /// </para>
        /// </remarks>
        internal bool Dangerous_IsFromSomeCompilation
        {
            get { return this.DeclaringCompilation != null; }
        }

        public virtual bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken = default(CancellationToken))
        {
            var declaringReferences = this.DeclaringSyntaxReferences;
            if (this.IsImplicitlyDeclared && declaringReferences.Length == 0)
            {
                return this.ContainingSymbol.IsDefinedInSourceTree(tree, definedWithinSpan, cancellationToken);
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

        internal static void ForceCompleteMemberByLocation(SourceLocation locationOpt, Symbol member, CancellationToken cancellationToken)
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

        private static readonly SymbolDisplayFormat s_debuggerDisplayFormat =
            SymbolDisplayFormat.TestFormat.WithCompilerInternalOptions(SymbolDisplayCompilerInternalOptions.IncludeNonNullableTypeModifier)
                .AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier);

        internal virtual string GetDebuggerDisplay()
        {
            return $"{this.Kind} {this.ToDisplayString(s_debuggerDisplayFormat)}";
        }

        internal virtual void AddDeclarationDiagnostics(DiagnosticBag diagnostics)
        {
            if (!diagnostics.IsEmptyWithoutResolution)
            {
                LanguageCompilation compilation = this.DeclaringCompilation;
                Debug.Assert(compilation != null);
                compilation.DeclarationDiagnostics.AddRange(diagnostics);
            }
        }

        #region Use-Site Diagnostics

        /// <summary>
        /// True if the symbol has a use-site diagnostic with error severity.
        /// </summary>
        internal bool HasUseSiteError
        {
            get
            {
                var diagnostic = GetUseSiteDiagnostic();
                return diagnostic != null && diagnostic.Severity == DiagnosticSeverity.Error;
            }
        }

        /// <summary>
        /// Returns diagnostic info that should be reported at the use site of the symbol, or null if there is none.
        /// </summary>
        public virtual DiagnosticInfo GetUseSiteDiagnostic()
        {
            return null;
        }

        /// <summary>
        /// Return error code that has highest priority while calculating use site error for this symbol. 
        /// </summary>
        protected virtual ErrorCode HighestPriorityUseSiteError => null;

        /// <summary>
        /// Indicates that this symbol uses metadata that cannot be supported by the language.
        /// 
        /// Examples include:
        ///    - Pointer types in VB
        ///    - ByRef return type
        ///    - Required custom modifiers
        ///    
        /// This is distinguished from, for example, references to metadata symbols defined in assemblies that weren't referenced.
        /// Symbols where this returns true can never be used successfully, and thus should never appear in any IDE feature.
        /// 
        /// This is set for metadata symbols, as follows:
        /// Type - if a type is unsupported (e.g., a pointer type, etc.)
        /// Method - parameter or return type is unsupported
        /// Field - type is unsupported
        /// Event - type is unsupported
        /// Property - type is unsupported
        /// Parameter - type is unsupported
        /// </summary>
        public virtual bool HasUnsupportedMetadata => false;

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
        /// Merges given diagnostic to the existing result diagnostic.
        /// </summary>
        internal bool MergeUseSiteDiagnostics(ref DiagnosticInfo result, DiagnosticInfo info)
        {
            if (info == null)
            {
                return false;
            }

            if (info.Severity == DiagnosticSeverity.Error && (info.HasErrorCode(HighestPriorityUseSiteError) || HighestPriorityUseSiteError == null))
            {
                // this error is final, no other error can override it:
                result = info;
                return true;
            }

            if (result == null || result.Severity == DiagnosticSeverity.Warning && info.Severity == DiagnosticSeverity.Error)
            {
                // there could be an error of higher-priority
                result = info;
                return false;
            }

            // we have a second low-pri error, continue looking for a higher priority one
            return false;
        }

        /// <summary>
        /// Reports specified use-site diagnostic to given diagnostic bag. 
        /// </summary>
        /// <remarks>
        /// This method should be the only method adding use-site diagnostics to a diagnostic bag. 
        /// It performs additional adjustments of the location for unification related diagnostics and 
        /// may be the place where to add more use-site location post-processing.
        /// </remarks>
        /// <returns>True if the diagnostic has error severity.</returns>
        internal static bool ReportUseSiteDiagnostic(DiagnosticInfo info, DiagnosticBag diagnostics, Location location)
        {
            var languageInfo = info as LanguageDiagnosticInfo;
            // Unlike VB the C# Dev11 compiler reports only a single unification error/warning.
            // By dropping the location we effectively merge all unification use-site errors that have the same error code into a single error.
            // The error message clearly explains how to fix the problem and reporting the error for each location wouldn't add much value. 
            if (languageInfo != null &&
                (languageInfo.ErrorCode == InternalErrorCode.WRN_UnifyReferenceBldRev ||
                languageInfo.ErrorCode == InternalErrorCode.WRN_UnifyReferenceMajMin ||
                languageInfo.ErrorCode == InternalErrorCode.ERR_AssemblyMatchBadVersion))
            {
                location = NoLocation.Singleton;
            }

            diagnostics.Add(info, location);
            return info.Severity == DiagnosticSeverity.Error;
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

        internal static bool GetUnificationUseSiteDiagnosticRecursive<T>(ref DiagnosticInfo result, ImmutableArray<T> types, Symbol owner, ref HashSet<TypeSymbol> checkedTypes) 
            where T : TypeSymbol
        {
            foreach (var t in types)
            {
                if (t.GetUnificationUseSiteDiagnosticRecursive(ref result, owner, ref checkedTypes))
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, ImmutableArray<CustomModifier> modifiers, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            foreach (var modifier in modifiers)
            {
                if (((TypeSymbol)modifier.Modifier).GetUnificationUseSiteDiagnosticRecursive(ref result, owner, ref checkedTypes))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        public string ToDisplayString(SymbolDisplayFormat format = null)
        {
            // TODO:MetaDslx
            //return SymbolDisplay.ToDisplayString(this, format);
            return this.MetadataName + " (" + this.Kind.ToString() + ")";
        }

        public ImmutableArray<SymbolDisplayPart> ToDisplayParts(SymbolDisplayFormat format = null)
        {
            return SymbolDisplay.ToDisplayParts(this, format);
        }

        public string ToMinimalDisplayString(
            SemanticModel semanticModel,
            int position,
            SymbolDisplayFormat format = null)
        {
            return SymbolDisplay.ToMinimalDisplayString(this, semanticModel, position, format);
        }

        public ImmutableArray<SymbolDisplayPart> ToMinimalDisplayParts(
            SemanticModel semanticModel,
            int position,
            SymbolDisplayFormat format = null)
        {
            return SymbolDisplay.ToMinimalDisplayParts(this, semanticModel, position, format);
        }

        #region ISymbol Members

        string ISymbol.Language => this.Language.Name;

        string ISymbol.Name => this.Name;

        string ISymbol.ToDisplayString(SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToDisplayString(this, format);
        }

        ImmutableArray<SymbolDisplayPart> ISymbol.ToDisplayParts(SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToDisplayParts(this, format);
        }

        string ISymbol.ToMinimalDisplayString(
            SemanticModel semanticModel,
            int position,
            SymbolDisplayFormat format)
        {
            var csharpModel = semanticModel as LanguageSemanticModel;
            if (csharpModel == null)
            {
                throw new ArgumentException(CSharpResources.WrongSemanticModelType, this.Language.Name);
            }

            return SymbolDisplay.ToMinimalDisplayString(this, csharpModel, position, format);
        }

        ImmutableArray<SymbolDisplayPart> ISymbol.ToMinimalDisplayParts(
            SemanticModel semanticModel,
            int position,
            SymbolDisplayFormat format)
        {
            var csharpModel = semanticModel as LanguageSemanticModel;
            if (csharpModel == null)
            {
                throw new ArgumentException(CSharpResources.WrongSemanticModelType, this.Language.Name);
            }

            return SymbolDisplay.ToMinimalDisplayParts(this, csharpModel, position, format);
        }

        bool ISymbol.IsImplicitlyDeclared => this.IsImplicitlyDeclared;

        ISymbol ISymbol.ContainingSymbol => this.ContainingSymbol;

        Microsoft.CodeAnalysis.SymbolKind ISymbol.Kind => Language.SymbolFacts.ToCSharpKind(this.Kind);

        IAssemblySymbol ISymbol.ContainingAssembly => this.ContainingAssembly;

        IModuleSymbol ISymbol.ContainingModule => this.ContainingModule;

        INamedTypeSymbol ISymbol.ContainingType => this.ContainingType;

        INamespaceSymbol ISymbol.ContainingNamespace => this.ContainingNamespace;

        bool ISymbol.IsDefinition => this.IsDefinition;

        bool ISymbol.IsStatic => this.IsStatic;

        bool ISymbol.IsVirtual => this.IsVirtual;

        bool ISymbol.IsOverride => this.IsOverride;

        bool ISymbol.IsAbstract => this.IsAbstract;

        bool ISymbol.IsSealed => this.IsSealed;

        ImmutableArray<Location> ISymbol.Locations => this.Locations;

        ImmutableArray<SyntaxReference> ISymbol.DeclaringSyntaxReferences => this.DeclaringSyntaxReferences;

        ImmutableArray<AttributeData> ISymbol.GetAttributes()
        {
            return this.GetAttributes();
        }

        Accessibility ISymbol.DeclaredAccessibility => this.DeclaredAccessibility;

        ISymbol ISymbol.OriginalDefinition => this.OriginalDefinition;

        public abstract void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor);

        public abstract TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor);

        public abstract void Accept(SymbolVisitor visitor);

        public abstract TResult Accept<TResult>(SymbolVisitor<TResult> visitor);

        public abstract TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument);

        #endregion

        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            return ToString();
        }

        #region Obsolete checks

        /// <summary>
        /// True if this symbol has been marked with the <see cref="ObsoleteAttribute"/> attribute. 
        /// This property returns <see cref="ThreeState.Unknown"/> if the <see cref="ObsoleteAttribute"/> attribute hasn't been cracked yet.
        /// </summary>
        public ThreeState ObsoleteState
        {
            get
            {
                switch (ObsoleteKind)
                {
                    case ObsoleteAttributeKind.None:
                    case ObsoleteAttributeKind.Experimental:
                        return ThreeState.False;
                    case ObsoleteAttributeKind.Uninitialized:
                        return ThreeState.Unknown;
                    default:
                        return ThreeState.True;
                }
            }
        }

        public ObsoleteAttributeKind ObsoleteKind
        {
            get
            {
                var data = this.ObsoleteAttributeData;
                return (data == null) ? ObsoleteAttributeKind.None : data.Kind;
            }
        }


        /// <summary>
        /// Returns data decoded from <see cref="ObsoleteAttribute"/> attribute or null if there is no <see cref="ObsoleteAttribute"/> attribute.
        /// This property returns <see cref="Microsoft.CodeAnalysis.ObsoleteAttributeData.Uninitialized"/> if attribute arguments haven't been decoded yet.
        /// </summary>
        public virtual ObsoleteAttributeData ObsoleteAttributeData => null; // TODO:MetaDslx

        /// <summary>
        /// Ensure that attributes are bound and the ObsoleteState of this symbol is known.
        /// </summary>
        public void ForceCompleteObsoleteAttribute()
        {
            if (this.ObsoleteState == ThreeState.Unknown)
            {
                this.GetAttributes();
            }
            Debug.Assert(this.ObsoleteState != ThreeState.Unknown, "ObsoleteState should be true or false now.");
        }

        #endregion

        public virtual Symbol ConstructedFrom => this;

        public virtual Symbol AsMember(NamedTypeSymbol newOwner)
        {
            Debug.Assert(this.IsDefinition);
            Debug.Assert(ReferenceEquals(newOwner.OriginalDefinition, this.ContainingSymbol.OriginalDefinition));
            return this; // TODO:MetaDslx
            //return newOwner.IsDefinition ? this : new SubstitutedNestedTypeSymbol((SubstitutedNamedTypeSymbol)newOwner, this);
        }

        /// <summary>
        /// Returns the original virtual or abstract method which a given method symbol overrides,
        /// ignoring any other overriding methods in base classes.
        /// </summary>
        /// <param name="accessingTypeOpt">The search must respect accessibility from this type.</param>
        public virtual Symbol GetLeastOverriddenMember(NamedTypeSymbol accessingTypeOpt)
        {
            return null;
        }

        /// <summary>
        /// Returns the original virtual or abstract method which a given method symbol overrides,
        /// ignoring any other overriding methods in base classes.
        /// Also, if the given method symbol is generic then the resulting virtual or abstract method is constructed with the
        /// same type arguments as the given method.
        /// </summary>
        public virtual Symbol GetConstructedLeastOverriddenMember(NamedTypeSymbol accessingTypeOpt)
        {
            var m = this.ConstructedFrom.GetLeastOverriddenMember(accessingTypeOpt);
            return m; // TODO:MetaDslx
            //return m.IsGenericMethod ? m.Construct(this.TypeArgumentsWithAnnotations) : m;
        }
    }
}
