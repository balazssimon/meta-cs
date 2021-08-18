// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

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
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using SymbolDisplay = Microsoft.CodeAnalysis.CSharp.SymbolDisplay;
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;

    /// <summary>
    /// The base class for all symbols (namespaces, classes, method, parameters, etc.) that are 
    /// exposed by the compiler.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    [Symbol(SymbolParts = SymbolParts.None)]
    public abstract partial class Symbol : IFormattable
    {
        private static ConditionalWeakTable<Symbol, DiagnosticBag> s_diagnostics = new ConditionalWeakTable<Symbol, DiagnosticBag>();

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Changes to the public interface of this class should remain synchronized with the VB version of Symbol.
        // Do not make any changes to the public interface without making the corresponding change
        // to the VB version.
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Prevent anyone else from deriving from this class.
        public Symbol()
        {
        }

        public virtual Language Language => ContainingModule?.Language ?? Language.None;


        /// <summary>
        /// Gets the name of this symbol. Symbols without a name return the empty string; null is
        /// never returned.
        /// </summary>
        [SymbolProperty]
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
        /// Should the name returned by Name property be mangled with any suffix in order to get metadata name.
        /// </summary>
        public virtual bool MangleName => this.Name != this.MetadataName;

        public virtual bool IsError => false;

        /// <summary>
        /// True if this Symbol should be completed by calling ForceComplete.
        /// Intuitively, true for source entities (from any compilation).
        /// </summary>
        public virtual bool RequiresCompletion => false;

        public virtual void ForceComplete(CompletionPart completionPart, SourceLocation? locationOpt, CancellationToken cancellationToken)
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
        /// Get the symbol that logically contains this symbol. 
        /// </summary>
        public abstract Symbol ContainingSymbol { get; }

        /// <summary>
        /// Get the symbols that are directly contained by this symbol. 
        /// </summary>
        public abstract ImmutableArray<Symbol> ChildSymbols { get; }

        /// <summary>
        /// Returns the assembly containing this symbol. If this symbol is shared across multiple
        /// assemblies, or doesn't belong to an assembly, returns null.
        /// </summary>
        public virtual AssemblySymbol? ContainingAssembly
        {
            get
            {
                // Default implementation gets the containers assembly.

                var container = this.ContainingSymbol;
                return container?.ContainingAssembly;
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
        public virtual LanguageCompilation? DeclaringCompilation
        {
            get
            {
                if (this.IsError) return null;
                if (this is AssemblySymbol)
                {
                    Debug.Assert(!(this is SourceAssemblySymbol), "SourceAssemblySymbol must override DeclaringCompilation");
                }
                if (this is ModuleSymbol)
                {
                    Debug.Assert(!(this is SourceModuleSymbol), "SourceModuleSymbol must override DeclaringCompilation");
                }
                var sourceModuleSymbol = this.ContainingModule as SourceModuleSymbol;
                return sourceModuleSymbol?.DeclaringCompilation;
            }
        }

        /// <summary>
        /// Returns the module containing this symbol. If this symbol is shared across multiple
        /// modules, or doesn't belong to a module, returns null.
        /// </summary>
        public virtual ModuleSymbol? ContainingModule
        {
            get
            {
                // Default implementation gets the containers module.
                var container = this.ContainingSymbol;
                if (container is ModuleSymbol moduleSymbol) return moduleSymbol;
                return container?.ContainingModule;
            }
        }

        /// <summary>
        /// Returns the nearest lexically enclosing declaration, or null if there is none.
        /// </summary>
        public virtual DeclaredSymbol? ContainingDeclaration
        {
            get
            {
                Symbol container = this.ContainingSymbol;
                while (container is not null)
                {
                    if (container is DeclaredSymbol result)
                    {
                        return result;
                    }
                    container = container.ContainingSymbol;
                }
                return null;
            }
        }

        /// <summary>
        /// Returns the nearest lexically enclosing type, or null if there is none.
        /// </summary>
        public virtual NamedTypeSymbol? ContainingType
        {
            get
            {
                Symbol container = this.ContainingSymbol;
                while (container is not null)
                {
                    if (container is NamedTypeSymbol result)
                    {
                        return result;
                    }
                    container = container.ContainingSymbol;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the nearest enclosing namespace for this namespace or type. For a nested type,
        /// returns the namespace that contains its container.
        /// </summary>
        public virtual NamespaceSymbol? ContainingNamespace
        {
            get
            {
                Symbol container = this.ContainingSymbol;
                while (container is not null)
                {
                    if (container is NamespaceSymbol result)
                    {
                        return result;
                    }
                    container = container.ContainingSymbol;
                }
                return null;
            }
        }

        public ImmutableArray<Diagnostic> Diagnostics
        {
            get
            {
                if (s_diagnostics.TryGetValue(this, out var diagnostics)) return diagnostics.ToReadOnly();
                else return ImmutableArray<Diagnostic>.Empty;
            }
        }

        public bool HasAnyErrors
        {
            get
            {
                if (s_diagnostics.TryGetValue(this, out var diagnostics)) return diagnostics.HasAnyErrors();
                else return false;
            }
        }

        protected void AddSymbolDiagnostics(DiagnosticBag diagnostics)
        {
            if (!diagnostics.IsEmptyWithoutResolution)
            {
                //LanguageCompilation compilation = this.DeclaringCompilation;
                //Debug.Assert(compilation != null);
                var symbolDiagnostics = s_diagnostics.GetOrCreateValue(this);
                symbolDiagnostics.AddRange(diagnostics);
            }
        }


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

        [SymbolProperty]
        public virtual ImmutableArray<Symbol> Attributes => ImmutableArray<Symbol>.Empty;

        public virtual ImmutableArray<AttributeData> GetAttributes()
        {
            return ImmutableArray<AttributeData>.Empty;
        }

        public virtual bool IsSpecialSymbol(object specialSymbolId, Language? language = null)
        {
            if (specialSymbolId is null) throw new ArgumentNullException(nameof(specialSymbolId));
            if (language is null) language = this.Language;
            var metadataName = language.SymbolFacts.GetMetadataNameOfSpecialSymbol(specialSymbolId);
            if (!string.IsNullOrEmpty(metadataName) && (this.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat) == metadataName || this.MetadataName == metadataName)) return true;
            else return false;
        }

        public virtual object? GetSpecialSymbol(Language? language = null)
        {
            if (language is null) language = this.Language;
            var metadataName = this.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat);
            var specialSymbolId = language.SymbolFacts.GetSpecialSymbolOfMetadataName(metadataName);
            if (specialSymbolId is not null) return specialSymbolId;
            specialSymbolId = language.SymbolFacts.GetSpecialSymbolOfMetadataName(this.MetadataName);
            return specialSymbolId;
        }

        public virtual bool IsSpecialModelObject(object specialModelObject, Language? language = null)
        {
            if (specialModelObject is null) throw new ArgumentNullException(nameof(specialModelObject));
            if (language is null) language = this.Language;
            var specialSymbolId = language.SymbolFacts.GetSpecialSymbolOfModelObject(specialModelObject);
            if (specialSymbolId is not null)
            {
                var metadataName = language.SymbolFacts.GetMetadataNameOfSpecialSymbol(specialSymbolId);
                if (!string.IsNullOrEmpty(metadataName) && (this.ToDisplayString(SymbolDisplayFormat.QualifiedNameOnlyFormat) == metadataName || this.MetadataName == metadataName)) return true;
                else return false;
            }
            return false;
        }

        public virtual object? GetSpecialModelObject(Language? language = null)
        {
            if (language is null) language = this.Language;
            if (this is IModelSymbol modelSymbol && modelSymbol.ModelObject is not null)
            {
                var specialSymbolId = language.SymbolFacts.GetSpecialSymbolOfModelObject(modelSymbol.ModelObject);
                if (specialSymbolId is not null) return modelSymbol.ModelObject;
            }
            return null;
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
            if (format == SymbolDisplayFormat.QualifiedNameOnlyFormat)
            {
                var container = this.ContainingDeclaration;
                if (container is not null) return MetadataHelpers.BuildQualifiedName(container.ToDisplayString(format), this.MetadataName);
                else return this.MetadataName;
            }
            if (format == SymbolDisplayFormat.FullyQualifiedFormat)
            {
                var container = this.ContainingDeclaration;
                if (container is not null) return MetadataHelpers.BuildQualifiedName(container.ToDisplayString(format), this.MetadataName);
                else return "global::" + this.MetadataName;
            }
            return this.MetadataName + " (" + GetKindText() + ")";
        }

        public string GetKindText()
        {
            var typeName = this.GetType().Name;
            if (typeName.StartsWith("Source")) typeName = typeName.Substring(6);
            if (typeName.StartsWith("Metadata")) typeName = typeName.Substring(8);
            return typeName;
        }

        private string GetDebuggerDisplay()
        {
            return this.MetadataName + " (" + this.GetType().Name + ")";
        }

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
        /// This property returns <see cref="MetaDslx.CodeAnalysis.ObsoleteAttributeData.Uninitialized"/> if attribute arguments haven't been decoded yet.
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

        internal virtual void AddDeclarationDiagnostics(DiagnosticBag diagnostics)
        {
            if (!diagnostics.IsEmptyWithoutResolution)
            {
                LanguageCompilation compilation = this.DeclaringCompilation;
                Debug.Assert(compilation != null);
                compilation.DeclarationDiagnostics.AddRange(diagnostics);
            }
        }

        public virtual bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken = default(CancellationToken))
        {
            var declaringReferences = this.DeclaringSyntaxReferences;
            var container = this.ContainingSymbol;
            if (declaringReferences.Length == 0 && container != null)
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

        public static void ForceCompleteChildByLocation(SourceLocation locationOpt, Symbol member, CancellationToken cancellationToken)
        {
            if (locationOpt == null || member.IsDefinedInSourceTree(locationOpt.SourceTree, locationOpt.SourceSpan, cancellationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();
                member.ForceComplete(null, locationOpt, cancellationToken);
            }
        }

        /// <summary>
        /// Returns the Documentation Comment ID for the symbol, or null if the symbol doesn't
        /// support documentation comments.
        /// </summary>
        public virtual string GetDocumentationCommentId()
        {
            return "";
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
            return "";
        }

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
            if (right is null)
            {
                return left is null;
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
            if (right is null)
            {
                return left is object;
            }

            // this part is expected to disappear when inlining "someSymbol != null"
            return (object)left != (object)right && !right.Equals(left);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Symbol, SymbolEqualityComparer.Default.CompareKind);
        }

        // By default we don't consider the compareKind, and do reference equality. This can be overridden.
        public virtual bool Equals(Symbol? other, TypeCompareKind compareKind)
        {
            return (object)this == other;
        }

        // By default, we do reference equality. This can be overridden.
        public override int GetHashCode()
        {
            return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(this);
        }

        public static bool Equals(Symbol first, Symbol second, TypeCompareKind compareKind)
        {
            if (first is null)
            {
                return second is null;
            }

            return first.Equals(second, compareKind);
        }

    }
}
