// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using MetaDslx.Compiler.CodeGen;
using MetaDslx.Compiler.Collections;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Emit;
using MetaDslx.Compiler.Operations;
using MetaDslx.Compiler.PooledObjects;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// The compilation object is an immutable representation of a single invocation of the
    /// compiler. Although immutable, a compilation is also on-demand, and will realize and cache
    /// data as necessary. A compilation can produce a new compilation from existing compilation
    /// with the application of small deltas. In many cases, it is more efficient than creating a
    /// new compilation from scratch, as the new compilation can reuse information from the old
    /// compilation.
    /// </summary>
    public abstract partial class Compilation
    {
        /// <summary>
        /// Returns true if this is a case sensitive compilation, false otherwise.  Case sensitivity
        /// affects compilation features such as name lookup as well as choosing what names to emit
        /// when there are multiple different choices (for example between a virtual method and an
        /// override).
        /// </summary>
        public abstract bool IsCaseSensitive { get; }

        /// <summary>
        /// Used for test purposes only to emulate missing members.
        /// </summary>
        private SmallDictionary<int, bool> _lazyMakeWellKnownTypeMissingMap;

        /// <summary>
        /// Used for test purposes only to emulate missing members.
        /// </summary>
        private SmallDictionary<int, bool> _lazyMakeMemberMissingMap;

        private readonly IReadOnlyDictionary<string, string> _features;

        public ScriptCompilationInfo ScriptCompilationInfo => CommonScriptCompilationInfo;
        internal abstract ScriptCompilationInfo CommonScriptCompilationInfo { get; }

        internal Compilation(
            string name,
            ImmutableArray<MetadataReference> references,
            IReadOnlyDictionary<string, string> features,
            bool isSubmission,
            AsyncQueue<CompilationEvent> eventQueue)
        {
            Debug.Assert(!references.IsDefault);
            Debug.Assert(features != null);

            this.AssemblyName = name;
            this.ExternalReferences = references;
            this.EventQueue = eventQueue;

            _lazySubmissionSlotIndex = isSubmission ? SubmissionSlotIndexToBeAllocated : SubmissionSlotIndexNotApplicable;
            _features = features;
        }

        protected static IReadOnlyDictionary<string, string> SyntaxTreeCommonFeatures(IEnumerable<SyntaxTree> trees)
        {
            IReadOnlyDictionary<string, string> set = null;

            foreach (var tree in trees)
            {
                var treeFeatures = tree.Options.Features;
                if (set == null)
                {
                    set = treeFeatures;
                }
                else
                {
                    if ((object)set != treeFeatures && !set.SetEquals(treeFeatures))
                    {
                        throw new ArgumentException(CompilerResources.InconsistentSyntaxTreeFeature, nameof(trees));
                    }
                }
            }

            if (set == null)
            {
                // Edge case where there are no syntax trees
                set = ImmutableDictionary<string, string>.Empty;
            }

            return set;
        }

        internal abstract AnalyzerDriver AnalyzerForLanguage(ImmutableArray<DiagnosticAnalyzer> analyzers, AnalyzerManager analyzerManager);

        /// <summary>
        /// Gets the source language ("C#" or "Visual Basic").
        /// </summary>
        public abstract Language Language { get; }

        internal static void ValidateScriptCompilationParameters(Compilation previousScriptCompilation, Type returnType, ref Type globalsType)
        {
            if (globalsType != null && !IsValidHostObjectType(globalsType))
            {
                throw new ArgumentException(CompilerResources.ReturnTypeCannotBeValuePointerbyRefOrOpen, nameof(globalsType));
            }

            if (returnType != null && !IsValidSubmissionReturnType(returnType))
            {
                throw new ArgumentException(CompilerResources.ReturnTypeCannotBeVoidByRefOrOpen, nameof(returnType));
            }

            if (previousScriptCompilation != null)
            {
                if (globalsType == null)
                {
                    globalsType = previousScriptCompilation.HostObjectType;
                }
                else if (globalsType != previousScriptCompilation.HostObjectType)
                {
                    throw new ArgumentException(CompilerResources.TypeMustBeSameAsHostObjectTypeOfPreviousSubmission, nameof(globalsType));
                }

                // Force the previous submission to be analyzed. This is required for anonymous types unification.
                if (previousScriptCompilation.GetDiagnostics().Any(d => d.Severity == DiagnosticSeverity.Error))
                {
                    throw new InvalidOperationException(CompilerResources.PreviousSubmissionHasErrors);
                }
            }
        }

        /// <summary>
        /// Checks options passed to submission compilation constructor.
        /// Throws an exception if the options are not applicable to submissions.
        /// </summary>
        protected virtual void CheckSubmissionOptions(CompilationOptions options)
        {
            if (options == null)
            {
                return;
            }
        }

        /// <summary>
        /// Creates a new compilation equivalent to this one with different symbol instances.
        /// </summary>
        public Compilation Clone()
        {
            return CommonClone();
        }

        protected abstract Compilation CommonClone();

        /// <summary>
        /// Returns a new compilation with a given event queue.
        /// </summary>
        internal abstract Compilation WithEventQueue(AsyncQueue<CompilationEvent> eventQueue);

        /// <summary>
        /// Gets a new <see cref="SemanticModel"/> for the specified syntax tree.
        /// </summary>
        /// <param name="syntaxTree">The specified syntax tree.</param>
        /// <param name="ignoreAccessibility">
        /// True if the SemanticModel should ignore accessibility rules when answering semantic questions.
        /// </param>
        public SemanticModel GetSemanticModel(SyntaxTree syntaxTree, bool ignoreAccessibility = false)
        {
            return CommonGetSemanticModel(syntaxTree, ignoreAccessibility);
        }

        protected abstract SemanticModel CommonGetSemanticModel(SyntaxTree syntaxTree, bool ignoreAccessibility);

        /// <summary>
        /// Returns a new INamedTypeSymbol representing an error type with the given name and arity
        /// in the given optional container.
        /// </summary>
        public INamedTypeSymbol CreateErrorTypeSymbol(INamespaceOrTypeSymbol container, string name, int arity)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (arity < 0)
            {
                throw new ArgumentException($"{nameof(arity)} must be >= 0", nameof(arity));
            }

            return CommonCreateErrorTypeSymbol(container, name, arity);
        }

        protected abstract INamedTypeSymbol CommonCreateErrorTypeSymbol(INamespaceOrTypeSymbol container, string name, int arity);

        /// <summary>
        /// Returns a new INamespaceSymbol representing an error (missing) namespace with the given name.
        /// </summary>
        public INamespaceSymbol CreateErrorNamespaceSymbol(INamespaceSymbol container, string name)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return CommonCreateErrorNamespaceSymbol(container, name);
        }

        protected abstract INamespaceSymbol CommonCreateErrorNamespaceSymbol(INamespaceSymbol container, string name);

        #region Name

        internal const string UnspecifiedModuleAssemblyName = "?";

        /// <summary>
        /// Simple assembly name, or null if not specified.
        /// </summary>
        /// <remarks>
        /// The name is used for determining internals-visible-to relationship with referenced assemblies.
        ///
        /// If the compilation represents an assembly the value of <see cref="AssemblyName"/> is its simple name.
        ///
        /// Unless <see cref="CompilationOptions.ModuleName"/> specifies otherwise the module name
        /// written to metadata is <see cref="AssemblyName"/> with an extension based upon <see cref="CompilationOptions.OutputKind"/>.
        /// </remarks>
        public string AssemblyName { get; }

        internal void CheckAssemblyName(DiagnosticBag diagnostics)
        {
            // We could only allow name == null if OutputKind is Module.
            // However, it does no harm that we allow name == null for assemblies as well, so we don't enforce it.

            if (this.AssemblyName != null)
            {
                MetadataHelpers.CheckAssemblyOrModuleName(this.AssemblyName, MessageProvider, MessageProvider.ERR_BadAssemblyName, diagnostics);
            }
        }

        internal string MakeSourceAssemblySimpleName()
        {
            return AssemblyName ?? UnspecifiedModuleAssemblyName;
        }

        internal string MakeSourceModuleName()
        {
            return Options.ModuleName ??
                   (AssemblyName != null ? AssemblyName + Options.OutputKind.GetDefaultExtension() : UnspecifiedModuleAssemblyName);
        }

        /// <summary>
        /// Creates a compilation with the specified assembly name.
        /// </summary>
        /// <param name="assemblyName">The new assembly name.</param>
        /// <returns>A new compilation.</returns>
        public Compilation WithAssemblyName(string assemblyName)
        {
            return CommonWithAssemblyName(assemblyName);
        }

        protected abstract Compilation CommonWithAssemblyName(string outputName);

        #endregion

        #region Options

        /// <summary>
        /// Gets the options the compilation was created with.
        /// </summary>
        public CompilationOptions Options { get { return CommonOptions; } }

        protected abstract CompilationOptions CommonOptions { get; }

        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        /// <param name="options">The new options.</param>
        /// <returns>A new compilation.</returns>
        public Compilation WithOptions(CompilationOptions options)
        {
            return CommonWithOptions(options);
        }

        protected abstract Compilation CommonWithOptions(CompilationOptions options);

        #endregion

        #region Submissions

        // An index in the submission slot array. Allocated lazily in compilation phase based upon the slot index of the previous submission.
        // Special values:
        // -1 ... neither this nor previous submissions in the chain allocated a slot (the submissions don't contain code)
        // -2 ... the slot of this submission hasn't been determined yet
        // -3 ... this is not a submission compilation
        private int _lazySubmissionSlotIndex;
        private const int SubmissionSlotIndexNotApplicable = -3;
        private const int SubmissionSlotIndexToBeAllocated = -2;

        /// <summary>
        /// True if the compilation represents an interactive submission.
        /// </summary>
        internal bool IsSubmission
        {
            get
            {
                return _lazySubmissionSlotIndex != SubmissionSlotIndexNotApplicable;
            }
        }

        /// <summary>
        /// The previous submission, if any, or null.
        /// </summary>
        private Compilation PreviousSubmission
        {
            get
            {
                return ScriptCompilationInfo?.PreviousScriptCompilation;
            }
        }

        /// <summary>
        /// Gets or allocates a runtime submission slot index for this compilation.
        /// </summary>
        /// <returns>Non-negative integer if this is a submission and it or a previous submission contains code, negative integer otherwise.</returns>
        internal int GetSubmissionSlotIndex()
        {
            if (_lazySubmissionSlotIndex == SubmissionSlotIndexToBeAllocated)
            {
                // TODO (tomat): remove recursion
                int lastSlotIndex = ScriptCompilationInfo.PreviousScriptCompilation?.GetSubmissionSlotIndex() ?? 0;
                _lazySubmissionSlotIndex = HasCodeToEmit() ? lastSlotIndex + 1 : lastSlotIndex;
            }

            return _lazySubmissionSlotIndex;
        }

        // The type of interactive submission result requested by the host, or null if this compilation doesn't represent a submission.
        //
        // The type is resolved to a symbol when the Script's instance ctor symbol is constructed. The symbol needs to be resolved against
        // the references of this compilation.
        //
        // Consider (tomat): As an alternative to Reflection Type we could hold onto any piece of information that lets us
        // resolve the type symbol when needed.

        /// <summary>
        /// The type object that represents the type of submission result the host requested.
        /// </summary>
        internal Type SubmissionReturnType => ScriptCompilationInfo?.ReturnTypeOpt;

        internal static bool IsValidSubmissionReturnType(Type type)
        {
            return !(type == typeof(void) || type.IsByRef || type.GetTypeInfo().ContainsGenericParameters);
        }

        /// <summary>
        /// The type of the globals object or null if not specified for this compilation.
        /// </summary>
        internal Type HostObjectType => ScriptCompilationInfo?.GlobalsType;

        internal static bool IsValidHostObjectType(Type type)
        {
            var info = type.GetTypeInfo();
            return !(info.IsValueType || info.IsPointer || info.IsByRef || info.ContainsGenericParameters);
        }

        internal abstract bool HasSubmissionResult();

        public Compilation WithScriptCompilationInfo(ScriptCompilationInfo info) => CommonWithScriptCompilationInfo(info);
        protected abstract Compilation CommonWithScriptCompilationInfo(ScriptCompilationInfo info);

        #endregion

        #region Syntax Trees

        /// <summary>
        /// Gets the syntax trees (parsed from source code) that this compilation was created with.
        /// </summary>
        public IEnumerable<SyntaxTree> SyntaxTrees { get { return CommonSyntaxTrees; } }
        protected abstract IEnumerable<SyntaxTree> CommonSyntaxTrees { get; }

        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        /// <param name="trees">The new syntax trees.</param>
        /// <returns>A new compilation.</returns>
        public Compilation AddSyntaxTrees(params SyntaxTree[] trees)
        {
            return CommonAddSyntaxTrees(trees);
        }

        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        /// <param name="trees">The new syntax trees.</param>
        /// <returns>A new compilation.</returns>
        public Compilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            return CommonAddSyntaxTrees(trees);
        }

        protected abstract Compilation CommonAddSyntaxTrees(IEnumerable<SyntaxTree> trees);

        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        /// <param name="trees">The new syntax trees.</param>
        /// <returns>A new compilation.</returns>
        public Compilation RemoveSyntaxTrees(params SyntaxTree[] trees)
        {
            return CommonRemoveSyntaxTrees(trees);
        }

        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        /// <param name="trees">The new syntax trees.</param>
        /// <returns>A new compilation.</returns>
        public Compilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            return CommonRemoveSyntaxTrees(trees);
        }

        protected abstract Compilation CommonRemoveSyntaxTrees(IEnumerable<SyntaxTree> trees);

        /// <summary>
        /// Creates a new compilation without any syntax trees. Preserves metadata info for use with
        /// trees added later.
        /// </summary>
        public Compilation RemoveAllSyntaxTrees()
        {
            return CommonRemoveAllSyntaxTrees();
        }

        protected abstract Compilation CommonRemoveAllSyntaxTrees();

        /// <summary>
        /// Creates a new compilation with an old syntax tree replaced with a new syntax tree.
        /// Reuses metadata from old compilation object.
        /// </summary>
        /// <param name="newTree">The new tree.</param>
        /// <param name="oldTree">The old tree.</param>
        /// <returns>A new compilation.</returns>
        public Compilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree)
        {
            return CommonReplaceSyntaxTree(oldTree, newTree);
        }

        protected abstract Compilation CommonReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree);

        /// <summary>
        /// Returns true if this compilation contains the specified tree. False otherwise.
        /// </summary>
        /// <param name="syntaxTree">A syntax tree.</param>
        public bool ContainsSyntaxTree(SyntaxTree syntaxTree)
        {
            return CommonContainsSyntaxTree(syntaxTree);
        }

        protected abstract bool CommonContainsSyntaxTree(SyntaxTree syntaxTree);

        /// <summary>
        /// The event queue that this compilation was created with.
        /// </summary>
        internal readonly AsyncQueue<CompilationEvent> EventQueue;

        #endregion

        #region References

        internal static ImmutableArray<MetadataReference> ValidateReferences<T>(IEnumerable<MetadataReference> references)
            where T : CompilationReference
        {
            var result = references.AsImmutableOrEmpty();
            for (int i = 0; i < result.Length; i++)
            {
                var reference = result[i];
                if (reference == null)
                {
                    throw new ArgumentNullException($"{nameof(references)}[{i}]");
                }

                var peReference = reference as PortableExecutableReference;
                if (peReference == null && !(reference is T))
                {
                    Debug.Assert(reference is UnresolvedMetadataReference || reference is CompilationReference);
                    throw new ArgumentException(string.Format(CompilerResources.ReferenceOfTypeIsInvalid1, reference.GetType()),
                                    $"{nameof(references)}[{i}]");
                }
            }

            return result;
        }

        internal CommonReferenceManager GetBoundReferenceManager()
        {
            return CommonGetBoundReferenceManager();
        }

        internal abstract CommonReferenceManager CommonGetBoundReferenceManager();

        /// <summary>
        /// Metadata references passed to the compilation constructor.
        /// </summary>
        public ImmutableArray<MetadataReference> ExternalReferences { get; }

        /// <summary>
        /// Unique metadata references specified via #r directive in the source code of this compilation.
        /// </summary>
        public abstract ImmutableArray<MetadataReference> DirectiveReferences { get; }

        /// <summary>
        /// All reference directives used in this compilation.
        /// </summary>
        internal abstract IEnumerable<ReferenceDirective> ReferenceDirectives { get; }

        /// <summary>
        /// Maps values of #r references to resolved metadata references.
        /// </summary>
        internal abstract IDictionary<(string path, string content), MetadataReference> ReferenceDirectiveMap { get; }

        /// <summary>
        /// All metadata references -- references passed to the compilation
        /// constructor as well as references specified via #r directives.
        /// </summary>
        public IEnumerable<MetadataReference> References
        {
            get
            {
                foreach (var reference in ExternalReferences)
                {
                    yield return reference;
                }

                foreach (var reference in DirectiveReferences)
                {
                    yield return reference;
                }
            }
        }

        /// <summary>
        /// Creates a metadata reference for this compilation.
        /// </summary>
        /// <param name="aliases">
        /// Optional aliases that can be used to refer to the compilation root namespace via extern alias directive.
        /// </param>
        /// <param name="embedInteropTypes">
        /// Embed the COM types from the reference so that the compiled
        /// application no longer requires a primary interop assembly (PIA).
        /// </param>
        public abstract CompilationReference ToMetadataReference(ImmutableArray<string> aliases = default(ImmutableArray<string>), bool embedInteropTypes = false);

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <param name="newReferences">
        /// The new references.
        /// </param>
        /// <returns>A new compilation.</returns>
        public Compilation WithReferences(IEnumerable<MetadataReference> newReferences)
        {
            return this.CommonWithReferences(newReferences);
        }

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <param name="newReferences">The new references.</param>
        /// <returns>A new compilation.</returns>
        public Compilation WithReferences(params MetadataReference[] newReferences)
        {
            return this.WithReferences((IEnumerable<MetadataReference>)newReferences);
        }

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        protected abstract Compilation CommonWithReferences(IEnumerable<MetadataReference> newReferences);

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public Compilation AddReferences(params MetadataReference[] references)
        {
            return AddReferences((IEnumerable<MetadataReference>)references);
        }

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public Compilation AddReferences(IEnumerable<MetadataReference> references)
        {
            if (references == null)
            {
                throw new ArgumentNullException(nameof(references));
            }

            if (references.IsEmpty())
            {
                return this;
            }

            return CommonWithReferences(this.ExternalReferences.Union(references));
        }

        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public Compilation RemoveReferences(params MetadataReference[] references)
        {
            return RemoveReferences((IEnumerable<MetadataReference>)references);
        }

        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public Compilation RemoveReferences(IEnumerable<MetadataReference> references)
        {
            if (references == null)
            {
                throw new ArgumentNullException(nameof(references));
            }

            if (references.IsEmpty())
            {
                return this;
            }

            var refSet = new HashSet<MetadataReference>(this.ExternalReferences);

            //EDMAURER if AddingReferences accepts duplicates, then a consumer supplying a list with
            //duplicates to add will not know exactly which to remove. Let them supply a list with
            //duplicates here.
            foreach (var r in references.Distinct())
            {
                if (!refSet.Remove(r))
                {
                    throw new ArgumentException(string.Format(CompilerResources.MetadataRefNotFoundToRemove1, r),
                                nameof(references));
                }
            }

            return CommonWithReferences(refSet);
        }

        /// <summary>
        /// Creates a new compilation without any metadata references.
        /// </summary>
        public Compilation RemoveAllReferences()
        {
            return CommonWithReferences(SpecializedCollections.EmptyEnumerable<MetadataReference>());
        }

        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata
        /// reference.
        /// </summary>
        /// <param name="newReference">The new reference.</param>
        /// <param name="oldReference">The old reference.</param>
        /// <returns>A new compilation.</returns>
        public Compilation ReplaceReference(MetadataReference oldReference, MetadataReference newReference)
        {
            if (oldReference == null)
            {
                throw new ArgumentNullException(nameof(oldReference));
            }

            if (newReference == null)
            {
                return this.RemoveReferences(oldReference);
            }

            return this.RemoveReferences(oldReference).AddReferences(newReference);
        }

        /// <summary>
        /// Gets the <see cref="IAssemblySymbol"/> or <see cref="IModuleSymbol"/> for a metadata reference used to create this
        /// compilation.
        /// </summary>
        /// <param name="reference">The target reference.</param>
        /// <returns>
        /// Assembly or module symbol corresponding to the given reference or null if there is none.
        /// </returns>
        public ISymbol0 GetAssemblyOrModuleSymbol(MetadataReference reference)
        {
            return CommonGetAssemblyOrModuleSymbol(reference);
        }

        protected abstract ISymbol0 CommonGetAssemblyOrModuleSymbol(MetadataReference reference);

        /// <summary>
        /// Gets the <see cref="MetadataReference"/> that corresponds to the assembly symbol.
        /// </summary>
        /// <param name="assemblySymbol">The target symbol.</param>
        public MetadataReference GetMetadataReference(IAssemblySymbol assemblySymbol)
        {
            return GetBoundReferenceManager().GetMetadataReference(assemblySymbol);
        }

        /// <summary>
        /// Assembly identities of all assemblies directly referenced by this compilation.
        /// </summary>
        /// <remarks>
        /// Includes identities of references passed in the compilation constructor
        /// as well as those specified via directives in source code.
        /// </remarks>
        public abstract IEnumerable<AssemblyIdentity> ReferencedAssemblyNames { get; }

        #endregion

        #region Symbols

        /// <summary>
        /// The <see cref="IAssemblySymbol"/> that represents the assembly being created.
        /// </summary>
        public IAssemblySymbol Assembly { get { return CommonAssembly; } }
        protected abstract IAssemblySymbol CommonAssembly { get; }

        /// <summary>
        /// Gets the <see cref="IModuleSymbol"/> for the module being created by compiling all of
        /// the source code.
        /// </summary>
        public IModuleSymbol SourceModule { get { return CommonSourceModule; } }
        protected abstract IModuleSymbol CommonSourceModule { get; }

        /// <summary>
        /// The root namespace that contains all namespaces and types defined in source code or in
        /// referenced metadata, merged into a single namespace hierarchy.
        /// </summary>
        public INamespaceSymbol GlobalNamespace { get { return CommonGlobalNamespace; } }
        protected abstract INamespaceSymbol CommonGlobalNamespace { get; }

        /// <summary>
        /// Gets the corresponding compilation namespace for the specified module or assembly namespace.
        /// </summary>
        public INamespaceSymbol GetCompilationNamespace(INamespaceSymbol namespaceSymbol)
        {
            return CommonGetCompilationNamespace(namespaceSymbol);
        }

        protected abstract INamespaceSymbol CommonGetCompilationNamespace(INamespaceSymbol namespaceSymbol);

        internal abstract CommonAnonymousTypeManager CommonAnonymousTypeManager { get; }

        /// <summary>
        /// Returns the Main method that will serves as the entry point of the assembly, if it is
        /// executable (and not a script).
        /// </summary>
        public IMethodSymbol GetEntryPoint(CancellationToken cancellationToken)
        {
            return CommonGetEntryPoint(cancellationToken);
        }

        protected abstract IMethodSymbol CommonGetEntryPoint(CancellationToken cancellationToken);

        /// <summary>
        /// Get the symbol for the predefined type from the Cor Library referenced by this
        /// compilation.
        /// </summary>
        public INamedTypeSymbol GetSpecialType(SpecialType specialType)
        {
            return CommonGetSpecialType(specialType);
        }

        /// <summary>
        /// Get the symbol for the predefined type member from the COR Library referenced by this compilation.
        /// </summary>
        internal abstract ISymbol0 CommonGetSpecialTypeMember(SpecialMember specialMember);

        /// <summary>
        /// Returns true if the type is System.Type.
        /// </summary>
        internal abstract bool IsSystemTypeReference(ITypeSymbol type);

        protected abstract INamedTypeSymbol CommonGetSpecialType(SpecialType specialType);

        /// <summary>
        /// Lookup member declaration in well known type used by this Compilation.
        /// </summary>
        internal abstract ISymbol0 CommonGetWellKnownTypeMember(WellKnownMember member);

        /// <summary>
        /// Returns true if the specified type is equal to or derives from System.Attribute well-known type.
        /// </summary>
        internal abstract bool IsAttributeType(ITypeSymbol type);

        /// <summary>
        /// The INamedTypeSymbol for the .NET System.Object type, which could have a TypeKind of
        /// Error if there was no COR Library in this Compilation.
        /// </summary>
        public INamedTypeSymbol ObjectType { get { return CommonObjectType; } }
        protected abstract INamedTypeSymbol CommonObjectType { get; }

        /// <summary>
        /// The TypeSymbol for the type 'dynamic' in this Compilation.
        /// </summary>
        public ITypeSymbol DynamicType { get { return CommonDynamicType; } }
        protected abstract ITypeSymbol CommonDynamicType { get; }

        /// <summary>
        /// A symbol representing the implicit Script class. This is null if the class is not
        /// defined in the compilation.
        /// </summary>
        public INamedTypeSymbol ScriptClass { get { return CommonScriptClass; } }
        protected abstract INamedTypeSymbol CommonScriptClass { get; }

        /// <summary>
        /// Resolves a symbol that represents script container (Script class). Uses the
        /// full name of the container class stored in <see cref="CompilationOptions.ScriptClassName"/> to find the symbol.
        /// </summary>
        /// <returns>The Script class symbol or null if it is not defined.</returns>
        protected INamedTypeSymbol CommonBindScriptClass()
        {
            string scriptClassName = this.Options.ScriptClassName ?? "";

            string[] parts = scriptClassName.Split('.');
            INamespaceSymbol container = this.SourceModule.GlobalNamespace;

            for (int i = 0; i < parts.Length - 1; i++)
            {
                INamespaceSymbol next = container.GetNestedNamespace(parts[i]);
                if (next == null)
                {
                    AssertNoScriptTrees();
                    return null;
                }

                container = next;
            }

            foreach (INamedTypeSymbol candidate in container.GetTypeMembers(parts[parts.Length - 1]))
            {
                if (candidate.IsScriptClass)
                {
                    return candidate;
                }
            }

            AssertNoScriptTrees();
            return null;
        }

        [Conditional("DEBUG")]
        private void AssertNoScriptTrees()
        {
            foreach (var tree in this.SyntaxTrees)
            {
                Debug.Assert(tree.Options.Kind != SourceCodeKind.Script);
            }
        }

        /// <summary>
        /// Returns a new ArrayTypeSymbol representing an array type tied to the base types of the
        /// COR Library in this Compilation.
        /// </summary>
        public IArrayTypeSymbol CreateArrayTypeSymbol(ITypeSymbol elementType, int rank = 1)
        {
            return CommonCreateArrayTypeSymbol(elementType, rank);
        }

        protected abstract IArrayTypeSymbol CommonCreateArrayTypeSymbol(ITypeSymbol elementType, int rank);

        /// <summary>
        /// Returns a new PointerTypeSymbol representing a pointer type tied to a type in this
        /// Compilation.
        /// </summary>
        public IPointerTypeSymbol CreatePointerTypeSymbol(ITypeSymbol pointedAtType)
        {
            return CommonCreatePointerTypeSymbol(pointedAtType);
        }

        protected abstract IPointerTypeSymbol CommonCreatePointerTypeSymbol(ITypeSymbol elementType);

        // PERF: ETW Traces show that analyzers may use this method frequently, often requesting
        // the same symbol over and over again. XUnit analyzers, in particular, were consuming almost
        // 1% of CPU time when building Roslyn itself. This is an extremely simple cache that evicts on
        // hash code conflicts, but seems to do the trick. The size is mostly arbitrary. My guess
        // is that there are maybe a couple dozen analyzers in the solution and each one has
        // ~0-2 unique well-known types, and the chance of hash collision is very low.
        private ConcurrentCache<string, INamedTypeSymbol> _getTypeCache =
            new ConcurrentCache<string, INamedTypeSymbol>(50, ReferenceEqualityComparer.Instance);

        /// <summary>
        /// Gets the type within the compilation's assembly and all referenced assemblies (other than
        /// those that can only be referenced via an extern alias) using its canonical CLR metadata name.
        /// </summary>
        /// <returns>Null if the type can't be found.</returns>
        /// <remarks>
        /// Since VB does not have the concept of extern aliases, it considers all referenced assemblies.
        /// </remarks>
        public INamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            if (!_getTypeCache.TryGetValue(fullyQualifiedMetadataName, out var val))
            {
                val = CommonGetTypeByMetadataName(fullyQualifiedMetadataName);
                // Ignore if someone added the same value before us
                _ = _getTypeCache.TryAdd(fullyQualifiedMetadataName, val);
            }
            return val;
        }

        protected abstract INamedTypeSymbol CommonGetTypeByMetadataName(string metadataName);

#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters
        /// <summary>
        /// Returns a new INamedTypeSymbol with the given element types and (optional) element names.
        /// </summary>
        public INamedTypeSymbol CreateTupleTypeSymbol(
            ImmutableArray<ITypeSymbol> elementTypes,
            ImmutableArray<string> elementNames = default(ImmutableArray<string>),
            ImmutableArray<Location> elementLocations = default(ImmutableArray<Location>))
        {
            if (elementTypes.IsDefault)
            {
                throw new ArgumentNullException(nameof(elementTypes));
            }

            if (elementTypes.Length <= 1)
            {
                throw new ArgumentException(CompilerResources.TuplesNeedAtLeastTwoElements, nameof(elementNames));
            }

            elementNames = CheckTupleElementNames(elementTypes.Length, elementNames);
            CheckTupleElementLocations(elementTypes.Length, elementLocations);

            for (int i = 0, n = elementTypes.Length; i < n; i++)
            {
                if (elementTypes[i] == null)
                {
                    throw new ArgumentNullException($"{nameof(elementTypes)}[{i}]");
                }

                if (!elementLocations.IsDefault && elementLocations[i] == null)
                {
                    throw new ArgumentNullException($"{nameof(elementLocations)}[{i}]");
                }
            }

            return CommonCreateTupleTypeSymbol(elementTypes, elementNames, elementLocations);
        }
#pragma warning restore RS0026 // Do not add multiple public overloads with optional parameters

        /// <summary>
        /// Check that if any names are provided, and their number matches the expected cardinality.
        /// Returns a normalized version of the element names (empty array if all the names are null).
        /// </summary>
        protected static ImmutableArray<string> CheckTupleElementNames(int cardinality, ImmutableArray<string> elementNames)
        {
            if (!elementNames.IsDefault)
            {
                if (elementNames.Length != cardinality)
                {
                    throw new ArgumentException(CompilerResources.TupleElementNameCountMismatch, nameof(elementNames));
                }

                for (int i = 0; i < elementNames.Length; i++)
                {
                    if (elementNames[i] == "")
                    {
                        throw new ArgumentException(CompilerResources.TupleElementNameEmpty, $"{nameof(elementNames)}[{i}]");
                    }
                }

                if (elementNames.All(n => n == null))
                {
                    return default(ImmutableArray<string>);
                }
            }

            return elementNames;
        }

        protected static void CheckTupleElementLocations(
            int cardinality,
            ImmutableArray<Location> elementLocations)
        {
            if (!elementLocations.IsDefault)
            {
                if (elementLocations.Length != cardinality)
                {
                    throw new ArgumentException(CompilerResources.TupleElementLocationCountMismatch, nameof(elementLocations));
                }
            }
        }

        protected abstract INamedTypeSymbol CommonCreateTupleTypeSymbol(
            ImmutableArray<ITypeSymbol> elementTypes,
            ImmutableArray<string> elementNames,
            ImmutableArray<Location> elementLocations);

#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters
        /// <summary>
        /// Returns a new INamedTypeSymbol with the given underlying type and (optional) element names.
        /// </summary>
        /// <remarks>
        /// Since VB doesn't support tuples yet, this call will fail in a VB compilation.
        /// Also, the underlying type needs to be tuple-compatible.
        /// </remarks>
        public INamedTypeSymbol CreateTupleTypeSymbol(
            INamedTypeSymbol underlyingType,
            ImmutableArray<string> elementNames = default(ImmutableArray<string>),
            ImmutableArray<Location> elementLocations = default(ImmutableArray<Location>))
        {
            if ((object)underlyingType == null)
            {
                throw new ArgumentNullException(nameof(underlyingType));
            }

            return CommonCreateTupleTypeSymbol(
                underlyingType, elementNames, elementLocations);
        }
#pragma warning restore RS0026 // Do not add multiple public overloads with optional parameters

        protected abstract INamedTypeSymbol CommonCreateTupleTypeSymbol(
            INamedTypeSymbol underlyingType,
            ImmutableArray<string> elementNames,
            ImmutableArray<Location> elementLocations);

        /// <summary>
        /// Returns a new anonymous type symbol with the given member types member names.
        /// Anonymous type members will be readonly by default.  Writable properties are
        /// supported in VB and can be created by passing in <see langword="false"/> in the
        /// appropriate locations in <paramref name="memberIsReadOnly"/>.
        ///
        /// Source locations can also be provided through <paramref name="memberLocations"/>
        /// </summary>
        public INamedTypeSymbol CreateAnonymousTypeSymbol(
            ImmutableArray<ITypeSymbol> memberTypes,
            ImmutableArray<string> memberNames,
            ImmutableArray<bool> memberIsReadOnly = default(ImmutableArray<bool>),
            ImmutableArray<Location> memberLocations = default(ImmutableArray<Location>))
        {
            if (memberTypes.IsDefault)
            {
                throw new ArgumentNullException(nameof(memberTypes));
            }

            if (memberNames.IsDefault)
            {
                throw new ArgumentNullException(nameof(memberNames));
            }

            if (memberTypes.Length != memberNames.Length)
            {
                throw new ArgumentException(string.Format(CompilerResources.AnonymousTypeMemberAndNamesCountMismatch2,
                                                    nameof(memberTypes), nameof(memberNames)));
            }

            if (!memberLocations.IsDefault && memberLocations.Length != memberTypes.Length)
            {
                throw new ArgumentException(string.Format(CompilerResources.AnonymousTypeArgumentCountMismatch2,
                                                    nameof(memberLocations), nameof(memberNames)));
            }

            if (!memberIsReadOnly.IsDefault && memberIsReadOnly.Length != memberTypes.Length)
            {
                throw new ArgumentException(string.Format(CompilerResources.AnonymousTypeArgumentCountMismatch2,
                                                    nameof(memberIsReadOnly), nameof(memberNames)));
            }

            for (int i = 0, n = memberTypes.Length; i < n; i++)
            {
                if (memberTypes[i] == null)
                {
                    throw new ArgumentNullException($"{nameof(memberTypes)}[{i}]");
                }

                if (memberNames[i] == null)
                {
                    throw new ArgumentNullException($"{nameof(memberNames)}[{i}]");
                }

                if (!memberLocations.IsDefault && memberLocations[i] == null)
                {
                    throw new ArgumentNullException($"{nameof(memberLocations)}[{i}]");
                }
            }

            return CommonCreateAnonymousTypeSymbol(memberTypes, memberNames, memberLocations, memberIsReadOnly);
        }

        protected abstract INamedTypeSymbol CommonCreateAnonymousTypeSymbol(
            ImmutableArray<ITypeSymbol> memberTypes,
            ImmutableArray<string> memberNames,
            ImmutableArray<Location> memberLocations,
            ImmutableArray<bool> memberIsReadOnly);

        /// <summary>
        /// Classifies a conversion from <paramref name="source"/> to <paramref name="destination"/> according
        /// to this compilation's programming language.
        /// </summary>
        /// <param name="source">Source type of value to be converted</param>
        /// <param name="destination">Destination type of value to be converted</param>
        /// <returns>A <see cref="CommonConversion"/> that classifies the conversion from the
        /// <paramref name="source"/> type to the <paramref name="destination"/> type.</returns>
        public abstract CommonConversion ClassifyCommonConversion(ITypeSymbol source, ITypeSymbol destination);

        /// <summary>
        /// Returns true if there is an implicit (C#) or widening (VB) conversion from
        /// <paramref name="fromType"/> to <paramref name="toType"/>. Returns false if
        /// either <paramref name="fromType"/> or <paramref name="toType"/> is null, or
        /// if no such conversion exists.
        /// </summary>
        public bool HasImplicitConversion(ITypeSymbol fromType, ITypeSymbol toType)
            => fromType != null && toType != null && this.ClassifyCommonConversion(fromType, toType).IsImplicit;

        /// <summary>
        /// Checks if <paramref name="symbol"/> is accessible from within <paramref name="within"/>. An optional qualifier of type
        /// <paramref name="throughType"/> is used to resolve protected access for instance members. All symbols are
        /// required to be from this compilation or some assembly referenced (<see cref="References"/>) by this
        /// compilation. <paramref name="within"/> is required to be an <see cref="INamedTypeSymbol"/> or <see cref="IAssemblySymbol"/>.
        /// </summary>
        /// <remarks>
        /// <para>Submissions can reference symbols from previous submissions and their referenced assemblies, even
        /// though those references are missing from <see cref="References"/>.
        /// See https://github.com/dotnet/roslyn/issues/27356.
        /// This implementation works around that by permitting symbols from previous submissions as well.</para>
        /// <para>It is advised to avoid the use of this API within the compilers, as the compilers have additional
        /// requirements for access checking that are not satisfied by this implementation, including the
        /// avoidance of infinite recursion that could result from the use of the ISymbol0 APIs here, the detection
        /// of use-site diagnostics, and additional returned details (from the compiler's internal APIs) that are
        /// helpful for more precisely diagnosing reasons for accessibility failure.</para>
        /// </remarks>
        public bool IsSymbolAccessibleWithin(
            ISymbol0 symbol,
            ISymbol0 within,
            ITypeSymbol throughType = null)
        {
            if (symbol is null)
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            if (within is null)
            {
                throw new ArgumentNullException(nameof(within));
            }

            if (!(within is INamedTypeSymbol || within is IAssemblySymbol))
            {
                throw new ArgumentException(string.Format(CompilerResources.IsSymbolAccessibleBadWithin, nameof(within)), nameof(within));
            }

            checkInCompilationReferences(symbol, nameof(symbol));
            checkInCompilationReferences(within, nameof(within));
            if (!(throughType is null))
            {
                checkInCompilationReferences(throughType, nameof(throughType));
            }

            return IsSymbolAccessibleWithinCore(symbol, within, throughType);

            void checkInCompilationReferences(ISymbol0 s, string parameterName)
            {
                var containingAssembly = computeContainingAssembly(s);
                if (!assemblyIsInReferences(containingAssembly))
                {
                    throw new ArgumentException(string.Format(CompilerResources.IsSymbolAccessibleWrongAssembly, parameterName), parameterName);
                }
            }

            bool assemblyIsInReferences(IAssemblySymbol a)
            {
                if (assemblyIsInCompilationReferences(a, this))
                {
                    return true;
                }

                if (this.IsSubmission)
                {
                    // Submissions can reference symbols from previous submissions and their referenced assemblies, even
                    // though those references are missing from this.References. We work around that by digging in
                    // to find references of previous submissions. See https://github.com/dotnet/roslyn/issues/27356
                    for (Compilation c = this.PreviousSubmission; c != null; c = c.PreviousSubmission)
                    {
                        if (assemblyIsInCompilationReferences(a, c))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            bool assemblyIsInCompilationReferences(IAssemblySymbol a, Compilation compilation)
            {
                if (a.Equals(compilation.Assembly))
                {
                    return true;
                }

                foreach (var reference in compilation.References)
                {
                    if (a.Equals(compilation.GetAssemblyOrModuleSymbol(reference)))
                    {
                        return true;
                    }
                }

                return false;
            }

            IAssemblySymbol computeContainingAssembly(ISymbol0 s)
            {
                while (true)
                {
                    switch (s.Kind)
                    {
                        case SymbolKind.Assembly:
                            return (IAssemblySymbol)s;
                        case SymbolKind.PointerType:
                            s = ((IPointerTypeSymbol)s).PointedAtType;
                            continue;
                        case SymbolKind.ArrayType:
                            s = ((IArrayTypeSymbol)s).ElementType;
                            continue;
                        case SymbolKind.Alias:
                            s = ((IAliasSymbol)s).Target;
                            continue;
                        case SymbolKind.Discard:
                            s = ((IDiscardSymbol)s).Type;
                            continue;
                        case SymbolKind.DynamicType:
                        case SymbolKind.ErrorType:
                        case SymbolKind.Preprocessing:
                        case SymbolKind.Namespace:
                            // these symbols are not restricted in where they can be accessed, so unless they report
                            // a containing assembly, we treat them as in the current assembly for access purposes
                            return s.ContainingAssembly ?? this.Assembly;
                        default:
                            return s.ContainingAssembly;
                    }
                }
            }
        }

        private protected abstract bool IsSymbolAccessibleWithinCore(
            ISymbol0 symbol,
            ISymbol0 within,
            ITypeSymbol throughType);

        internal abstract IConvertibleConversion ClassifyConvertibleConversion(IOperation source, ITypeSymbol destination, out Optional<object> constantValue);

        #endregion

        #region Diagnostics

        internal const CompilationStage DefaultDiagnosticsStage = CompilationStage.Compile;

        /// <summary>
        /// Gets the diagnostics produced during the parsing stage.
        /// </summary>
        public abstract ImmutableArray<Diagnostic> GetParseDiagnostics(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the diagnostics produced during symbol declaration.
        /// </summary>
        public abstract ImmutableArray<Diagnostic> GetDeclarationDiagnostics(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the diagnostics produced during the analysis of method bodies and field initializers.
        /// </summary>
        public abstract ImmutableArray<Diagnostic> GetMethodBodyDiagnostics(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all the diagnostics for the compilation, including syntax, declaration, and
        /// binding. Does not include any diagnostics that might be produced during emit, see
        /// <see cref="EmitResult"/>.
        /// </summary>
        public abstract ImmutableArray<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default(CancellationToken));

        internal abstract void GetDiagnostics(CompilationStage stage, bool includeEarlierStages, DiagnosticBag diagnostics, CancellationToken cancellationToken = default);

        internal void EnsureCompilationEventQueueCompleted()
        {
            Debug.Assert(EventQueue != null);

            lock (EventQueue)
            {
                if (!EventQueue.IsCompleted)
                {
                    CompleteCompilationEventQueue_NoLock();
                }
            }
        }

        internal void CompleteCompilationEventQueue_NoLock()
        {
            Debug.Assert(EventQueue != null);

            // Signal the end of compilation.
            EventQueue.TryEnqueue(new CompilationCompletedEvent(this));
            EventQueue.PromiseNotToEnqueue();
            EventQueue.TryComplete();
        }

        internal abstract CommonMessageProvider MessageProvider { get; }

        /// <summary>
        /// Filter out warnings based on the compiler options (/nowarn, /warn and /warnaserror) and the pragma warning directives.
        /// 'incoming' is freed.
        /// </summary>
        /// <param name="accumulator">Bag to which filtered diagnostics will be added.</param>
        /// <param name="incoming">Diagnostics to be filtered.</param>
        /// <returns>True if there were no errors or warnings-as-errors.</returns>
        internal bool FilterAndAppendAndFreeDiagnostics(DiagnosticBag accumulator, ref DiagnosticBag incoming)
        {
            bool result = FilterAndAppendDiagnostics(accumulator, incoming.AsEnumerableWithoutResolution(), exclude: null);
            incoming.Free();
            incoming = null;
            return result;
        }

        /// <summary>
        /// Filter out warnings based on the compiler options (/nowarn, /warn and /warnaserror) and the pragma warning directives.
        /// </summary>
        /// <returns>True if there are no unsuppressed errors (i.e., no errors which fail compilation).</returns>
        internal bool FilterAndAppendDiagnostics(DiagnosticBag accumulator, IEnumerable<Diagnostic> incoming, HashSet<int> exclude)
        {
            bool hasError = false;
            bool reportSuppressedDiagnostics = Options.ReportSuppressedDiagnostics;

            foreach (Diagnostic d in incoming)
            {
                if (exclude?.Contains(d.Code) == true)
                {
                    continue;
                }

                var filtered = Options.FilterDiagnostic(d);
                if (filtered == null ||
                    (!reportSuppressedDiagnostics && filtered.IsSuppressed))
                {
                    continue;
                }
                else if (filtered.Severity == DiagnosticSeverity.Error &&
                         !filtered.IsSuppressed)
                {
                    hasError = true;
                }

                accumulator.Add(filtered);
            }

            return !hasError;
        }

        #endregion

        #region Emit

        /// <summary>
        /// Return true if the compilation contains any code or types.
        /// </summary>
        internal abstract bool HasCodeToEmit();

        /// <summary>
        /// Signals the event queue, if any, that we are done compiling.
        /// There should not be more compiling actions after this step.
        /// NOTE: once we signal about completion to analyzers they will cancel and thus in some cases we
        ///       may be effectively cutting off some diagnostics.
        ///       It is not clear if behavior is desirable.
        ///       See: https://github.com/dotnet/roslyn/issues/11470
        /// </summary>
        /// <param name="filterTree">What tree to complete. null means complete all trees. </param>
        internal abstract void CompleteTrees(SyntaxTree filterTree);

        internal bool Compile(
            CommonPEModuleBuilder moduleBuilder,
            bool emittingPdb,
            DiagnosticBag diagnostics,
            Predicate<ISymbol0> filterOpt,
            CancellationToken cancellationToken)
        {
            try
            {
                return CompileMethods(
                    moduleBuilder,
                    emittingPdb,
                    emitMetadataOnly: false,
                    emitTestCoverageData: false,
                    diagnostics: diagnostics,
                    filterOpt: filterOpt,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                moduleBuilder.CompilationFinished();
            }
        }

        internal void EnsureAnonymousTypeTemplates(CancellationToken cancellationToken)
        {
            Debug.Assert(IsSubmission);

            if (this.GetSubmissionSlotIndex() >= 0 && HasCodeToEmit())
            {
                if (!this.CommonAnonymousTypeManager.AreTemplatesSealed)
                {
                    var discardedDiagnostics = DiagnosticBag.GetInstance();

                    var moduleBeingBuilt = this.CreateModuleBuilder(
                        emitOptions: EmitOptions.Default,
                        debugEntryPoint: null,
                        manifestResources: null,
                        sourceLinkStream: null,
                        embeddedTexts: null,
                        testData: null,
                        diagnostics: discardedDiagnostics,
                        cancellationToken: cancellationToken);

                    if (moduleBeingBuilt != null)
                    {
                        Compile(
                            moduleBeingBuilt,
                            diagnostics: discardedDiagnostics,
                            emittingPdb: false,
                            filterOpt: null,
                            cancellationToken: cancellationToken);
                    }

                    discardedDiagnostics.Free();
                }

                Debug.Assert(this.CommonAnonymousTypeManager.AreTemplatesSealed);
            }
            else
            {
                this.ScriptCompilationInfo.PreviousScriptCompilation?.EnsureAnonymousTypeTemplates(cancellationToken);
            }
        }

        internal string Feature(string p)
        {
            string v;
            return _features.TryGetValue(p, out v) ? v : null;
        }

        #endregion

        private ConcurrentDictionary<SyntaxTree, SmallConcurrentSetOfInts> _lazyTreeToUsedImportDirectivesMap;
        private static readonly Func<SyntaxTree, SmallConcurrentSetOfInts> s_createSetCallback = t => new SmallConcurrentSetOfInts();

        private ConcurrentDictionary<SyntaxTree, SmallConcurrentSetOfInts> TreeToUsedImportDirectivesMap
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref _lazyTreeToUsedImportDirectivesMap);
            }
        }

        internal void MarkImportDirectiveAsUsed(SyntaxNode node)
        {
            MarkImportDirectiveAsUsed(node.SyntaxTree, node.Span.Start);
        }

        internal void MarkImportDirectiveAsUsed(SyntaxTree syntaxTree, int position)
        {
            // Optimization: Don't initialize TreeToUsedImportDirectivesMap in submissions.
            if (!IsSubmission && syntaxTree != null)
            {
                var set = TreeToUsedImportDirectivesMap.GetOrAdd(syntaxTree, s_createSetCallback);
                set.Add(position);
            }
        }

        internal bool IsImportDirectiveUsed(SyntaxTree syntaxTree, int position)
        {
            if (IsSubmission)
            {
                // Since usings apply to subsequent submissions, we have to assume they are used.
                return true;
            }

            SmallConcurrentSetOfInts usedImports;
            return syntaxTree != null &&
                TreeToUsedImportDirectivesMap.TryGetValue(syntaxTree, out usedImports) &&
                usedImports.Contains(position);
        }

        /// <summary>
        /// The compiler needs to define an ordering among different partial class in different syntax trees
        /// in some cases, because emit order for fields in structures, for example, is semantically important.
        /// This function defines an ordering among syntax trees in this compilation.
        /// </summary>
        internal int CompareSyntaxTreeOrdering(SyntaxTree tree1, SyntaxTree tree2)
        {
            if (tree1 == tree2)
            {
                return 0;
            }

            Debug.Assert(this.ContainsSyntaxTree(tree1));
            Debug.Assert(this.ContainsSyntaxTree(tree2));

            return this.GetSyntaxTreeOrdinal(tree1) - this.GetSyntaxTreeOrdinal(tree2);
        }

        internal abstract int GetSyntaxTreeOrdinal(SyntaxTree tree);

        /// <summary>
        /// Compare two source locations, using their containing trees, and then by Span.First within a tree.
        /// Can be used to get a total ordering on declarations, for example.
        /// </summary>
        internal abstract int CompareSourceLocations(Location loc1, Location loc2);

        /// <summary>
        /// Compare two source locations, using their containing trees, and then by Span.First within a tree.
        /// Can be used to get a total ordering on declarations, for example.
        /// </summary>
        internal abstract int CompareSourceLocations(SyntaxReference loc1, SyntaxReference loc2);

        /// <summary>
        /// Return the lexically first of two locations.
        /// </summary>
        internal TLocation FirstSourceLocation<TLocation>(TLocation first, TLocation second)
            where TLocation : Location
        {
            if (CompareSourceLocations(first, second) <= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        /// <summary>
        /// Return the lexically first of multiple locations.
        /// </summary>
        internal TLocation FirstSourceLocation<TLocation>(ImmutableArray<TLocation> locations)
            where TLocation : Location
        {
            if (locations.IsEmpty)
            {
                return null;
            }

            var result = locations[0];

            for (int i = 1; i < locations.Length; i++)
            {
                result = FirstSourceLocation(result, locations[i]);
            }

            return result;
        }

        #region Logging Helpers

        // Following helpers are used when logging ETW events. These helpers are invoked only if we are running
        // under an ETW listener that has requested 'verbose' logging. In other words, these helpers will never
        // be invoked in the 'normal' case (i.e. when the code is running on user's machine and no ETW listener
        // is involved).

        // Note: Most of the below helpers are unused at the moment - but we would like to keep them around in
        // case we decide we need more verbose logging in certain cases for debugging.
        internal string GetMessage(CompilationStage stage)
        {
            return string.Format("{0} ({1})", this.AssemblyName, stage.ToString());
        }

        internal string GetMessage(ITypeSymbol source, ITypeSymbol destination)
        {
            if (source == null || destination == null) return this.AssemblyName;
            return string.Format("{0}: {1} {2} -> {3} {4}", this.AssemblyName, source.TypeKind.ToString(), source.Name, destination.TypeKind.ToString(), destination.Name);
        }

        #endregion

        #region Declaration Name Queries

        /// <summary>
        /// Return true if there is a source declaration symbol name that meets given predicate.
        /// </summary>
        public abstract bool ContainsSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Return source declaration symbols whose name meets given predicate.
        /// </summary>
        public abstract IEnumerable<ISymbol0> GetSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken));

#pragma warning disable RS0026 // Do not add multiple public overloads with optional parameters
        /// <summary>
        /// Return true if there is a source declaration symbol name that matches the provided name.
        /// This may be faster than <see cref="ContainsSymbolsWithName(Func{string, bool},
        /// SymbolFilter, CancellationToken)"/> when predicate is just a simple string check.
        /// <paramref name="name"/> is case sensitive or not depending on the target language.
        /// </summary>
        public abstract bool ContainsSymbolsWithName(string name, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Return source declaration symbols whose name matches the provided name.  This may be
        /// faster than <see cref="GetSymbolsWithName(Func{string, bool}, SymbolFilter,
        /// CancellationToken)"/> when predicate is just a simple string check.  <paramref
        /// name="name"/> is case sensitive or not depending on the target language.
        /// </summary>
        public abstract IEnumerable<ISymbol0> GetSymbolsWithName(string name, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken));
#pragma warning restore RS0026 // Do not add multiple public overloads with optional parameters

        #endregion

        /// <summary>
        /// Given a <see cref="Diagnostic"/> reporting unreferenced <see cref="AssemblyIdentity"/>s, returns
        /// the actual <see cref="AssemblyIdentity"/> instances that were not referenced.
        /// </summary>
        public ImmutableArray<AssemblyIdentity> GetUnreferencedAssemblyIdentities(Diagnostic diagnostic)
        {
            if (diagnostic == null)
            {
                throw new ArgumentNullException(nameof(diagnostic));
            }

            if (!IsUnreferencedAssemblyIdentityDiagnosticCode(diagnostic.Code))
            {
                return ImmutableArray<AssemblyIdentity>.Empty;
            }

            var builder = ArrayBuilder<AssemblyIdentity>.GetInstance();

            foreach (var argument in diagnostic.Arguments)
            {
                if (argument is AssemblyIdentity id)
                {
                    builder.Add(id);
                }
            }

            return builder.ToImmutableAndFree();
        }

        internal abstract bool IsUnreferencedAssemblyIdentityDiagnosticCode(int code);

        /// <summary>
        /// Returns the required language version found in a <see cref="Diagnostic"/>, if any is found.
        /// Returns null if none is found.
        /// </summary>
        public static string GetRequiredLanguageVersion(Diagnostic diagnostic)
        {
            if (diagnostic == null)
            {
                throw new ArgumentNullException(nameof(diagnostic));
            }

            bool found = false;
            string foundVersion = null;
            if (diagnostic.Arguments != null)
            {
                foreach (var argument in diagnostic.Arguments)
                {
                    if (argument is RequiredLanguageVersion versionDiagnostic)
                    {
                        Debug.Assert(!found); // only one required language version in a given diagnostic
                        found = true;
                        foundVersion = versionDiagnostic.ToString();
                    }
                }
            }

            return foundVersion;
        }
    }
}
