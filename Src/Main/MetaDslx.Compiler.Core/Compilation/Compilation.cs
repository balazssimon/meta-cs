using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
    public abstract class Compilation
    {
        /// <summary>
        /// Returns true if this is a case sensitive compilation, false otherwise.  Case sensitivity
        /// affects compilation features such as name lookup as well as choosing what names to emit
        /// when there are multiple different choices (for example between a virtual method and an
        /// override).
        /// </summary>
        public abstract bool IsCaseSensitive { get; }

        public ScriptCompilationInfo ScriptCompilationInfo => CommonScriptCompilationInfo;
        protected abstract ScriptCompilationInfo CommonScriptCompilationInfo { get; }

        protected Compilation(
            string name,
            ImmutableArray<ImmutableModel> references,
            bool isSubmission,
            AsyncQueue<CompilationEvent> eventQueue)
        {
            Debug.Assert(!references.IsDefault);

            this.CompilationName = name;
            this.ExternalReferences = references;
            this.EventQueue = eventQueue;
        }

        /// <summary>
        /// Gets the source language ("C#" or "Visual Basic").
        /// </summary>
        public abstract Language Language { get; }

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
        public Compilation WithEventQueue(AsyncQueue<CompilationEvent> eventQueue)
        {
            return CommonWithEventQueue(eventQueue);
        }

        protected abstract Compilation CommonWithEventQueue(AsyncQueue<CompilationEvent> eventQueue);
        
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
        public abstract IMetaSymbol CreateErrorTypeSymbol(IMetaSymbol container, string name, int arity);


        #region Name

        /// <summary>
        /// Simple compilation name, or null if not specified.
        /// </summary>
        public string CompilationName { get; }

        /// <summary>
        /// Creates a compilation with the specified compilation name.
        /// </summary>
        /// <param name="compilationName">The new compilation name.</param>
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
        public AsyncQueue<CompilationEvent> EventQueue { get; protected set; }

        #endregion

        #region References

        protected static ImmutableArray<ImmutableModel> ValidateReferences<T>(IEnumerable<ImmutableModel> references)
        {
            if (references == null) return ImmutableArray<ImmutableModel>.Empty;
            var result = references.ToImmutableArray();
            for (int i = 0; i < result.Length; i++)
            {
                var reference = result[i];
                if (reference == null)
                {
                    throw new ArgumentNullException("references[" + i + "]");
                }
            }
            return result;
        }

        /// <summary>
        /// Metadata references passed to the compilation constructor.
        /// </summary>
        public ImmutableArray<ImmutableModel> ExternalReferences { get; }

        /// <summary>
        /// All metadata references -- references passed to the compilation
        /// constructor as well as references specified via #r directives.
        /// </summary>
        public IEnumerable<ImmutableModel> References
        {
            get
            {
                return this.ExternalReferences;
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
        public abstract ImmutableModelGroup ToMetadataReference(ImmutableArray<string> aliases = default(ImmutableArray<string>));

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <param name="newReferences">
        /// The new references.
        /// </param>
        /// <returns>A new compilation.</returns>
        public Compilation WithReferences(IEnumerable<ImmutableModel> newReferences)
        {
            return this.CommonWithReferences(newReferences);
        }

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <param name="newReferences">The new references.</param>
        /// <returns>A new compilation.</returns>
        public Compilation WithReferences(params ImmutableModel[] newReferences)
        {
            return this.WithReferences((IEnumerable<ImmutableModel>)newReferences);
        }

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        protected abstract Compilation CommonWithReferences(IEnumerable<ImmutableModel> newReferences);

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public Compilation AddReferences(params ImmutableModel[] references)
        {
            return AddReferences((IEnumerable<ImmutableModel>)references);
        }

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public Compilation AddReferences(IEnumerable<ImmutableModel> references)
        {
            if (references == null)
            {
                throw new ArgumentNullException(nameof(references));
            }

            if (!references.Any())
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
        public Compilation RemoveReferences(params ImmutableModel[] references)
        {
            return RemoveReferences((IEnumerable<ImmutableModel>)references);
        }

        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public Compilation RemoveReferences(IEnumerable<ImmutableModel> references)
        {
            if (references == null)
            {
                throw new ArgumentNullException(nameof(references));
            }

            if (!references.Any())
            {
                return this;
            }

            var refSet = new HashSet<ImmutableModel>(this.ExternalReferences);

            //EDMAURER if AddingReferences accepts duplicates, then a consumer supplying a list with
            //duplicates to add will not know exactly which to remove. Let them supply a list with
            //duplicates here.
            foreach (var r in references.Distinct())
            {
                if (!refSet.Remove(r))
                {
                    throw new ArgumentException($"MetadataReference '{r}' not found to remove", nameof(references));
                }
            }

            return CommonWithReferences(refSet);
        }

        /// <summary>
        /// Creates a new compilation without any metadata references.
        /// </summary>
        public Compilation RemoveAllReferences()
        {
            return CommonWithReferences(EmptyCollections.Enumerable<ImmutableModel>());
        }

        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata
        /// reference.
        /// </summary>
        /// <param name="newReference">The new reference.</param>
        /// <param name="oldReference">The old reference.</param>
        /// <returns>A new compilation.</returns>
        public Compilation ReplaceReference(ImmutableModel oldReference, ImmutableModel newReference)
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

        #endregion

        #region Symbols

        /// <summary>
        /// Gets the <see cref="ImmutableModelGroup"/> for the model being created by compiling all of
        /// the source code.
        /// </summary>
        public ImmutableModelGroup SourceModel { get { return CommonSourceModel; } }
        protected abstract ImmutableModelGroup CommonSourceModel { get; }

        /// <summary>
        /// The root namespace that contains all namespaces and types defined in source code or in 
        /// referenced metadata, merged into a single namespace hierarchy.
        /// </summary>
        public IMetaSymbol GlobalNamespace { get { return CommonGlobalNamespace; } }
        protected abstract IMetaSymbol CommonGlobalNamespace { get; }

        /// <summary>
        /// Gets the type within the compilation's assembly and all referenced assemblies (other than
        /// those that can only be referenced via an extern alias) using its canonical CLR metadata name.
        /// </summary>
        /// <returns>Null if the type can't be found.</returns>
        /// <remarks>
        /// Since VB does not have the concept of extern aliases, it considers all referenced assemblies.
        /// </remarks>
        public IMetaSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            return CommonGetTypeByMetadataName(fullyQualifiedMetadataName);
        }

        protected abstract IMetaSymbol CommonGetTypeByMetadataName(string metadataName);

        #endregion

        #region Diagnostics

        public static readonly CompilationStage DefaultDiagnosticsStage = CompilationStage.Compile;

        /// <summary>
        /// Gets the diagnostics produced during the parsing stage.
        /// </summary>
        public abstract ImmutableArray<Diagnostic> GetParseDiagnostics(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the diagnostics produced during symbol declaration.
        /// </summary>
        public abstract ImmutableArray<Diagnostic> GetDeclarationDiagnostics(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets all the diagnostics for the compilation, including syntax, declaration, and
        /// binding. Does not include any diagnostics that might be produced during emit, see
        /// <see cref="EmitResult"/>.
        /// </summary>
        public abstract ImmutableArray<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default(CancellationToken));

        public abstract MessageProvider MessageProvider { get; }

        /// <param name="accumulator">Bag to which filtered diagnostics will be added.</param>
        /// <param name="incoming">Diagnostics to be filtered.</param>
        /// <returns>True if there were no errors or warnings-as-errors.</returns>
        public abstract bool FilterAndAppendAndFreeDiagnostics(DiagnosticBag accumulator, ref DiagnosticBag incoming);

        #endregion

        /// <summary>
        /// The compiler needs to define an ordering among different partial class in different syntax trees
        /// in some cases, because emit order for fields in structures, for example, is semantically important.
        /// This function defines an ordering among syntax trees in this compilation.
        /// </summary>
        public int CompareSyntaxTreeOrdering(SyntaxTree tree1, SyntaxTree tree2)
        {
            if (tree1 == tree2)
            {
                return 0;
            }

            Debug.Assert(this.ContainsSyntaxTree(tree1));
            Debug.Assert(this.ContainsSyntaxTree(tree2));

            return this.GetSyntaxTreeOrdinal(tree1) - this.GetSyntaxTreeOrdinal(tree2);
        }

        public abstract int GetSyntaxTreeOrdinal(SyntaxTree tree);

        /// <summary>
        /// Compare two source locations, using their containing trees, and then by Span.First within a tree. 
        /// Can be used to get a total ordering on declarations, for example.
        /// </summary>
        public abstract int CompareSourceLocations(Location loc1, Location loc2);

        /// <summary>
        /// Return the lexically first of two locations.
        /// </summary>
        public TLocation FirstSourceLocation<TLocation>(TLocation first, TLocation second)
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
        public TLocation FirstSourceLocation<TLocation>(ImmutableArray<TLocation> locations)
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
        public string GetMessage(CompilationStage stage)
        {
            return string.Format("{0} ({1})", this.CompilationName, stage.ToString());
        }

        public string GetMessage(IMetaSymbol source, IMetaSymbol destination)
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
        public abstract IEnumerable<IMetaSymbol> GetSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default(CancellationToken));

        #endregion
    }

}
