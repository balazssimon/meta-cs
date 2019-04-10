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
using MetaDslx.Core;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Operations;
using MetaDslx.Compiler.PooledObjects;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Compiler.Emit;
using MetaDslx.Compiler.Collections;
using MetaDslx.Compiler.Declarations;

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

            this.CompilationName = name;
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
        public abstract string Language { get; }

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
        internal static void CheckSubmissionOptions(CompilationOptions options)
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
        public ISymbol CreateErrorTypeSymbol(ISymbol container, string name, int arity)
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

        protected abstract ISymbol CommonCreateErrorTypeSymbol(ISymbol container, string name, int arity);

        /// <summary>
        /// Returns a new INamespaceSymbol representing an error (missing) namespace with the given name.
        /// </summary>
        public ISymbol CreateErrorNamespaceSymbol(ISymbol container, string name)
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

        protected abstract ISymbol CommonCreateErrorNamespaceSymbol(ISymbol container, string name);

        #region Name

        /// <summary>
        /// Simple compilation name, or null if not specified.
        /// </summary>
        public string CompilationName { get; }

        /// <summary>
        /// Creates a compilation with the specified assembly name.
        /// </summary>
        /// <param name="assemblyName">The new assembly name.</param>
        /// <returns>A new compilation.</returns>
        public Compilation WithCompilationName(string compilationName)
        {
            return CommonWithCompilationName(compilationName);
        }

        protected abstract Compilation CommonWithCompilationName(string compilationName);

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


                bool referenceOK = reference is ModelReference || reference is ModelGroupReference;
                if (!referenceOK && !(reference is T))
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
        /// Gets the model for a metadata reference used to create this
        /// compilation.
        /// </summary>
        /// <param name="reference">The target reference.</param>
        /// <returns>
        /// Assembly or module symbol corresponding to the given reference or null if there is none.
        /// </returns>
        public ImmutableModel GetReferencedModel(MetadataReference reference)
        {
            return CommonGetReferencedModel(reference);
        }

        protected abstract ImmutableModel CommonGetReferencedModel(MetadataReference reference);

        /// <summary>
        /// Gets the <see cref="MetadataReference"/> that corresponds to the model.
        /// </summary>
        /// <param name="model">The target model.</param>
        public MetadataReference GetMetadataReference(ImmutableModel model)
        {
            return GetBoundReferenceManager().GetMetadataReference(model);
        }

        /// <summary>
        /// Model identities of all models directly referenced by this compilation.
        /// </summary>
        /// <remarks>
        /// Includes identities of references passed in the compilation constructor
        /// as well as those specified via directives in source code.
        /// </remarks>
        public abstract IEnumerable<ModelIdentity> ReferencedModelNames { get; }

        #endregion

        #region Symbols


        internal MutableModelGroup ModelGroupBuilder
        {
            get { return this.ModelGroupBuilderCore; }
        }

        protected abstract MutableModelGroup ModelGroupBuilderCore { get; }

        internal MutableModel ModelBuilder
        {
            get { return this.ModelBuilderCore; }
        }

        protected abstract MutableModel ModelBuilderCore { get; }


        /// <summary>
        /// The root namespace that contains all namespaces and types defined in source code or in
        /// referenced metadata, merged into a single namespace hierarchy.
        /// </summary>
        public ISymbol GlobalNamespace { get { return CommonGlobalNamespace; } }
        protected abstract ISymbol CommonGlobalNamespace { get; }

        /// <summary>
        /// Gets the corresponding compilation namespace for the specified module or assembly namespace.
        /// </summary>
        public ISymbol GetCompilationNamespace(ISymbol namespaceSymbol)
        {
            return CommonGetCompilationNamespace(namespaceSymbol);
        }

        protected abstract ISymbol CommonGetCompilationNamespace(ISymbol namespaceSymbol);

        internal abstract CommonAnonymousTypeManager CommonAnonymousTypeManager { get; }

        /// <summary>
        /// Returns the Main method that will serves as the entry point of the assembly, if it is
        /// executable (and not a script).
        /// </summary>
        public ISymbol GetEntryPoint(CancellationToken cancellationToken)
        {
            return CommonGetEntryPoint(cancellationToken);
        }

        protected abstract ISymbol CommonGetEntryPoint(CancellationToken cancellationToken);

        /// <summary>
        /// Get the symbol for the predefined type from the Cor Library referenced by this
        /// compilation.
        /// </summary>
        public ISymbol GetSpecialType(Type specialType)
        {
            return CommonGetSpecialType(specialType);
        }

        /// <summary>
        /// Returns true if the type is System.Type.
        /// </summary>
        internal abstract bool IsSystemTypeReference(ISymbol type);

        protected abstract ISymbol CommonGetSpecialType(Type specialType);

        /// <summary>
        /// Returns true if the specified type is equal to or derives from System.Attribute well-known type.
        /// </summary>
        internal abstract bool IsAttributeType(ISymbol type);

        /// <summary>
        /// The INamedTypeSymbol for the .NET System.Object type, which could have a TypeKind of
        /// Error if there was no COR Library in this Compilation.
        /// </summary>
        public ISymbol ObjectType { get { return CommonObjectType; } }
        protected abstract ISymbol CommonObjectType { get; }

        /// <summary>
        /// The TypeSymbol for the type 'dynamic' in this Compilation.
        /// </summary>
        public ISymbol DynamicType { get { return CommonDynamicType; } }
        protected abstract ISymbol CommonDynamicType { get; }

        /// <summary>
        /// A symbol representing the implicit Script class. This is null if the class is not
        /// defined in the compilation.
        /// </summary>
        public ISymbol ScriptClass { get { return CommonScriptClass; } }
        protected abstract ISymbol CommonScriptClass { get; }

        // PERF: ETW Traces show that analyzers may use this method frequently, often requesting
        // the same symbol over and over again. XUnit analyzers, in particular, were consuming almost
        // 1% of CPU time when building Roslyn itself. This is an extremely simple cache that evicts on
        // hash code conflicts, but seems to do the trick. The size is mostly arbitrary. My guess
        // is that there are maybe a couple dozen analyzers in the solution and each one has
        // ~0-2 unique well-known types, and the chance of hash collision is very low.
        private ConcurrentCache<string, ISymbol> _getTypeCache =
            new ConcurrentCache<string, ISymbol>(50, ReferenceEqualityComparer.Instance);

        /// <summary>
        /// Gets the type within the compilation's assembly and all referenced assemblies (other than
        /// those that can only be referenced via an extern alias) using its canonical CLR metadata name.
        /// </summary>
        /// <returns>Null if the type can't be found.</returns>
        /// <remarks>
        /// Since VB does not have the concept of extern aliases, it considers all referenced assemblies.
        /// </remarks>
        public ISymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            if (!_getTypeCache.TryGetValue(fullyQualifiedMetadataName, out var val))
            {
                val = CommonGetTypeByMetadataName(fullyQualifiedMetadataName);
                // Ignore if someone added the same value before us
                _ = _getTypeCache.TryAdd(fullyQualifiedMetadataName, val);
            }
            return val;
        }

        protected abstract ISymbol CommonGetTypeByMetadataName(string metadataName);

        /// <summary>
        /// Returns a new anonymous type symbol with the given member types member names.
        /// Anonymous type members will be readonly by default.  Writable properties are
        /// supported in VB and can be created by passing in <see langword="false"/> in the
        /// appropriate locations in <paramref name="memberIsReadOnly"/>.
        ///
        /// Source locations can also be provided through <paramref name="memberLocations"/>
        /// </summary>
        public ISymbol CreateAnonymousTypeSymbol(
            ImmutableArray<ISymbol> memberTypes,
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

        protected abstract ISymbol CommonCreateAnonymousTypeSymbol(
            ImmutableArray<ISymbol> memberTypes,
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
        public abstract CommonConversion ClassifyCommonConversion(ISymbol source, ISymbol destination);

        /// <summary>
        /// Returns true if there is an implicit (C#) or widening (VB) conversion from
        /// <paramref name="fromType"/> to <paramref name="toType"/>. Returns false if
        /// either <paramref name="fromType"/> or <paramref name="toType"/> is null, or
        /// if no such conversion exists.
        /// </summary>
        public bool HasImplicitConversion(ISymbol fromType, ISymbol toType)
            => fromType != null && toType != null && this.ClassifyCommonConversion(fromType, toType).IsImplicit;

        internal abstract IConvertibleConversion ClassifyConvertibleConversion(IOperation source, ISymbol destination, out Optional<object> constantValue);

        #endregion

        #region Diagnostics

        internal const CompilationStage DefaultDiagnosticsStage = CompilationStage.Compile;

        /// <summary>
        /// The bag in which semantic analysis should deposit its diagnostics.
        /// </summary>
        internal DiagnosticBag DeclarationDiagnostics
        {
            get
            {
                // We should only be placing diagnostics in this bag until
                // we are done gathering declaration diagnostics. Assert that is
                // the case. But since we have bugs (see https://github.com/dotnet/roslyn/issues/846)
                // we disable the assertion until they are fixed.
                Debug.Assert(!_declarationDiagnosticsFrozen || true);
                if (_lazyDeclarationDiagnostics == null)
                {
                    var diagnostics = new DiagnosticBag();
                    Interlocked.CompareExchange(ref _lazyDeclarationDiagnostics, diagnostics, null);
                }

                return _lazyDeclarationDiagnostics;
            }
        }

        private DiagnosticBag _lazyDeclarationDiagnostics;
        private bool _declarationDiagnosticsFrozen;

        /// <summary>
        /// A bag in which diagnostics that should be reported after code gen can be deposited.
        /// </summary>
        internal DiagnosticBag AdditionalCodegenWarnings
        {
            get
            {
                return _additionalCodegenWarnings;
            }
        }

        private readonly DiagnosticBag _additionalCodegenWarnings = new DiagnosticBag();

        private readonly SyntaxAndDeclarationManager _syntaxAndDeclarations;

        internal DeclarationTable Declarations
        {
            get
            {
                return _syntaxAndDeclarations.GetLazyState().DeclarationTable;
            }
        }

        internal MergedDeclaration MergedRootDeclaration
        {
            get
            {
                return Declarations.GetMergedRoot(this);
            }
        }

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
        /// Reports all unused imports/usings so far (and thus it must be called as a last step of Emit)
        /// </summary>
        internal abstract void ReportUnusedImports(
            SyntaxTree filterTree,
            DiagnosticBag diagnostics,
            CancellationToken cancellationToken);

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

        internal abstract CommonSymbolBuilder CreateSymbolBuilder(
            DiagnosticBag diagnostics,
            CancellationToken cancellationToken);

        /// <summary>
        /// Report declaration diagnostics and compile and synthesize method bodies.
        /// </summary>
        /// <returns>True if successful.</returns>
        internal abstract bool CompileSymbols(
            CommonSymbolBuilder moduleBuilder,
            DiagnosticBag diagnostics,
            Predicate<ISymbol> filterOpt,
            CancellationToken cancellationToken);

        internal bool Compile(
            CommonSymbolBuilder symbolBuilder,
            DiagnosticBag diagnostics,
            Predicate<ISymbol> filterOpt,
            CancellationToken cancellationToken)
        {
            try
            {
                return CompileSymbols(
                    symbolBuilder,
                    diagnostics: diagnostics,
                    filterOpt: filterOpt,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                symbolBuilder.CompilationFinished();
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

                    var moduleBeingBuilt = this.CreateSymbolBuilder(
                        diagnostics: discardedDiagnostics,
                        cancellationToken: cancellationToken);

                    if (moduleBeingBuilt != null)
                    {
                        Compile(
                            moduleBeingBuilt,
                            diagnostics: discardedDiagnostics,
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
            return string.Format("{0} ({1})", this.CompilationName, stage.ToString());
        }

        internal string GetMessage(ISymbol source, ISymbol destination)
        {
            if (source == null || destination == null) return this.CompilationName;
            return string.Format("{0}: {1} {2} -> {3} {4}", this.CompilationName, source.MMetaClass.MName, source.MName, destination.MMetaClass.MName, destination.MName);
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
        public abstract IEnumerable<ISymbol> GetSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken));

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
        public abstract IEnumerable<ISymbol> GetSymbolsWithName(string name, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken));
#pragma warning restore RS0026 // Do not add multiple public overloads with optional parameters

        #endregion

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
