using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.References;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
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
    // TODO: common base class with Roslyn Compilation.
    public abstract class SimpleCompilation
    {
        internal static readonly CompilationStage DefaultDiagnosticsStage = CompilationStage.Compile;
        internal static readonly ParallelOptions DefaultParallelOptions = new ParallelOptions();

        private MutableModelGroup _lazyModelGroupBuilder;
        private MutableModel _lazyModelBuilder;
        private ModelId _lazyModelId;
        private ImmutableModelGroup _lazyModelGroup;
        private ImmutableModel _lazyModel;

        private bool compiling = false;
        private bool compiled = false;
        private DiagnosticBag diagnosticBag = null;
        private ImmutableArray<Diagnostic> _lazyDiagnostics = ImmutableArray<Diagnostic>.Empty;

        protected SimpleCompilation(string compilationName, CompilationOptions options, IEnumerable<SyntaxTree> syntaxTrees, ImmutableArray<MetadataReference> references)
        {
            Debug.Assert(!references.IsDefault);
            this.CompilationName = compilationName;
            this.Options = options;
            this.SyntaxTrees = syntaxTrees?.ToImmutableArray() ?? ImmutableArray<SyntaxTree>.Empty;
            this.ExternalReferences = references;
        }

        /// <summary>
        /// Gets the syntax trees (parsed from source code) that this compilation was created with.
        /// </summary>
        public ImmutableArray<SyntaxTree> SyntaxTrees { get; }

        /// <summary>
        /// Metadata references passed to the compilation constructor.
        /// </summary>
        public ImmutableArray<MetadataReference> ExternalReferences { get; }

        /// <summary>
        /// All metadata references -- references passed to the compilation
        /// constructor as well as references specified via #r directives.
        /// </summary>
        public IEnumerable<MetadataReference> References
        {
            get
            {
                return this.ExternalReferences;
            }
        }

        /// <summary>
        /// Simple compilation name, or null if not specified.
        /// </summary>
        public string CompilationName { get; }

        /// <summary>
        /// Gets the source language ("C#" or "Visual Basic").
        /// </summary>
        public abstract Language Language { get; }

        protected abstract SimpleCompilation Update(string compilationName, CompilationOptions options, IEnumerable<SyntaxTree> syntaxTrees, ImmutableArray<MetadataReference> references);

        /// <summary>
        /// Creates a compilation with the specified assembly name.
        /// </summary>
        /// <param name="assemblyName">The new assembly name.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation WithCompilationName(string compilationName)
        {
            return this.Update(compilationName, this.Options, this.SyntaxTrees, this.ExternalReferences);
        }

        /// <summary>
        /// Gets the options the compilation was created with.
        /// </summary>
        public CompilationOptions Options { get; }

        /// <summary>
        /// Creates a new compilation with the specified compilation options.
        /// </summary>
        /// <param name="options">The new options.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation WithOptions(CompilationOptions options)
        {
            return this.Update(this.CompilationName, options, this.SyntaxTrees, this.ExternalReferences);
        }

        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        /// <param name="trees">The new syntax trees.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation AddSyntaxTrees(params SyntaxTree[] trees)
        {
            return this.Update(this.CompilationName, this.Options, this.SyntaxTrees.AddRange(trees), this.ExternalReferences);
        }

        /// <summary>
        /// Creates a new compilation with additional syntax trees.
        /// </summary>
        /// <param name="trees">The new syntax trees.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation AddSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            return this.Update(this.CompilationName, this.Options, this.SyntaxTrees.AddRange(trees), this.ExternalReferences);
        }

        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        /// <param name="trees">The new syntax trees.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation RemoveSyntaxTrees(params SyntaxTree[] trees)
        {
            return this.Update(this.CompilationName, this.Options, this.SyntaxTrees.RemoveRange(trees), this.ExternalReferences);
        }

        /// <summary>
        /// Creates a new compilation without the specified syntax trees. Preserves metadata info for use with trees
        /// added later.
        /// </summary>
        /// <param name="trees">The new syntax trees.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation RemoveSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            return this.Update(this.CompilationName, this.Options, this.SyntaxTrees.RemoveRange(trees), this.ExternalReferences);
        }

        /// <summary>
        /// Creates a new compilation without any syntax trees. Preserves metadata info for use with
        /// trees added later.
        /// </summary>
        public SimpleCompilation RemoveAllSyntaxTrees()
        {
            return this.Update(this.CompilationName, this.Options, ImmutableArray<SyntaxTree>.Empty, this.ExternalReferences);
        }

        /// <summary>
        /// Creates a new compilation with an old syntax tree replaced with a new syntax tree.
        /// Reuses metadata from old compilation object.
        /// </summary>
        /// <param name="newTree">The new tree.</param>
        /// <param name="oldTree">The old tree.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation ReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree)
        {
            return this.Update(this.CompilationName, this.Options, this.SyntaxTrees.Replace(oldTree, newTree), this.ExternalReferences);
        }

        /// <summary>
        /// Returns true if this compilation contains the specified tree. False otherwise.
        /// </summary>
        /// <param name="syntaxTree">A syntax tree.</param>
        public bool ContainsSyntaxTree(SyntaxTree syntaxTree)
        {
            return this.SyntaxTrees.Contains(syntaxTree);
        }

        protected static ImmutableArray<MetadataReference> ValidateReferences<T>(IEnumerable<MetadataReference> references)
            where T : CompilationReference
        {
            if (references == null) return ImmutableArray<MetadataReference>.Empty;
            var result = references.ToImmutableArray();
            for (int i = 0; i < result.Length; i++)
            {
                var reference = result[i];
                if (reference == null)
                {
                    throw new ArgumentNullException("references[" + i + "]");
                }

                bool referenceOK = reference is ModelReference || reference is ModelGroupReference;
                if (!referenceOK && !(reference is T))
                {
                    Debug.Assert(reference is UnresolvedMetadataReference || reference is CompilationReference);
                    throw new ArgumentException(String.Format("Reference of type '{0}' is not valid for this compilation.", reference.GetType()), "references[" + i + "]");
                }
            }

            return result;
        }

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <param name="newReferences">
        /// The new references.
        /// </param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation WithReferences(IEnumerable<MetadataReference> newReferences)
        {
            return this.Update(this.CompilationName, this.Options, this.SyntaxTrees, newReferences != null ? newReferences.ToImmutableArray() : ImmutableArray<MetadataReference>.Empty);
        }

        /// <summary>
        /// Creates a new compilation with the specified references.
        /// </summary>
        /// <param name="newReferences">The new references.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation WithReferences(params MetadataReference[] newReferences)
        {
            return this.Update(this.CompilationName, this.Options, this.SyntaxTrees, newReferences.ToImmutableArray());
        }

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation AddReferences(params MetadataReference[] references)
        {
            return AddReferences((IEnumerable<MetadataReference>)references);
        }

        /// <summary>
        /// Creates a new compilation with additional metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation AddReferences(IEnumerable<MetadataReference> references)
        {
            if (references == null)
            {
                throw new ArgumentNullException(nameof(references));
            }

            if (!references.Any())
            {
                return this;
            }

            return this.WithReferences(this.ExternalReferences.Union(references));
        }

        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation RemoveReferences(params MetadataReference[] references)
        {
            return RemoveReferences((IEnumerable<MetadataReference>)references);
        }

        /// <summary>
        /// Creates a new compilation without the specified metadata references.
        /// </summary>
        /// <param name="references">The new references.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation RemoveReferences(IEnumerable<MetadataReference> references)
        {
            if (references == null)
            {
                throw new ArgumentNullException(nameof(references));
            }

            if (!references.Any())
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
                    throw new ArgumentException($"MetadataReference '{r}' not found to remove", nameof(references));
                }
            }

            return this.WithReferences(refSet);
        }

        /// <summary>
        /// Creates a new compilation without any metadata references.
        /// </summary>
        public SimpleCompilation RemoveAllReferences()
        {
            return this.WithReferences(ImmutableArray<MetadataReference>.Empty);
        }

        /// <summary>
        /// Creates a new compilation with an old metadata reference replaced with a new metadata
        /// reference.
        /// </summary>
        /// <param name="newReference">The new reference.</param>
        /// <param name="oldReference">The old reference.</param>
        /// <returns>A new compilation.</returns>
        public SimpleCompilation ReplaceReference(MetadataReference oldReference, MetadataReference newReference)
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



        private void EnsureModelBuilderIsCreated()
        {
            if (Interlocked.CompareExchange(ref _lazyModelGroupBuilder, this.CreateModelGroupBuilder(), null) == null)
            {
                Interlocked.Exchange(ref _lazyModelBuilder, this.CreateModelBuilder());
                Interlocked.Exchange(ref _lazyModelId, _lazyModelBuilder.Id);
            }
        }

        protected virtual MutableModelGroup CreateModelGroupBuilder()
        {
            return new MutableModelGroup();
        }

        protected virtual MutableModel CreateModelBuilder()
        {
            return this.ModelGroupBuilder.CreateModel();
        }

        protected ModelId ModelId
        {
            get
            {
                this.EnsureModelBuilderIsCreated();
                return _lazyModelId;
            }
        }
        /// <summary>
        /// The <see cref="ImmutableModelGroup"/> that represents the model group being created 
        /// with the compilation model and all model references.
        /// </summary>
        public ImmutableModelGroup ModelGroup
        {
            get
            {
                this.ForceCompleteModel();
                return _lazyModelGroup;
            }
        }

        protected MutableModelGroup ModelGroupBuilder
        {
            get
            {
                this.EnsureModelBuilderIsCreated();
                return _lazyModelGroupBuilder;
            }
        }

        /// <summary>
        /// Gets the <see cref="ImmutableModel"/> for the model being created by compiling all of
        /// the source code.
        /// </summary>
        public ImmutableModel Model
        {
            get
            {
                if (_lazyModel == null)
                {
                    Interlocked.CompareExchange(ref _lazyModel, this.ModelGroup.GetModel(this.ModelId), null);
                }
                return _lazyModel;
            }
        }

        protected MutableModel ModelBuilder
        {
            get
            {
                this.EnsureModelBuilderIsCreated();
                return _lazyModelBuilder;
            }
        }

        /// <summary>
        /// Diagnostic bag available only during compilation. Do not use it externally!
        /// </summary>
        protected DiagnosticBag DiagnosticBag
        {
            get { return this.diagnosticBag; }
        }

        private void CompleteModel(CancellationToken cancellationToken)
        {
            if (!this.compiling && !this.compiled)
            {
                if (Interlocked.CompareExchange(ref this.diagnosticBag, new DiagnosticBag(), null) == null)
                {
                    this.compiling = true;
                    this.Compile(cancellationToken);
                    this.ModelGroupBuilder.GetModel(this.ModelId)?.EvaluateLazyValues(cancellationToken);
                    this.compiled = true;
                    this.compiling = false;
                }
            }
        }

        protected void ForceCompleteModel(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_lazyModelGroup == null)
            {
                if (Interlocked.CompareExchange(ref _lazyModelGroup, this.ModelGroupBuilder.ToImmutable(), null) == null)
                {
                    this.CompleteModel(cancellationToken);
                    Interlocked.Exchange(ref _lazyModelGroup, this.ModelGroupBuilder.ToImmutable());
                }
            }
        }

        public void Execute(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ForceCompleteModel(cancellationToken);
        }

        /// <summary>
        /// Gets the diagnostics produced during the parsing stage of a compilation. There are no diagnostics for declarations or accessor or
        /// method bodies, for example.
        /// </summary>
        public ImmutableArray<Diagnostic> GetSyntaxDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(CompilationStage.Parse, false, cancellationToken);
        }

        /// <summary>
        /// Gets the diagnostics produced during symbol declaration headers.  There are no diagnostics for semantic analysis.
        /// </summary>
        public ImmutableArray<Diagnostic> GetDeclarationDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(CompilationStage.Declare, false, cancellationToken);
        }

        /// <summary>
        /// Gets the diagnostics produced during the semantic analysis.
        /// </summary>
        public ImmutableArray<Diagnostic> GetSemanticDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(CompilationStage.Compile, false, cancellationToken);
        }

        /// <summary>
        /// Gets the all the diagnostics for the compilation, including syntax, declaration, and binding. Does not
        /// include any diagnostics that might be produced during emit.
        /// </summary>
        public ImmutableArray<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDiagnostics(DefaultDiagnosticsStage, true, cancellationToken);
        }

        internal ImmutableArray<Diagnostic> GetDiagnostics(CompilationStage stage, bool includeEarlierStages, CancellationToken cancellationToken)
        {
            var builder = DiagnosticBag.GetInstance();

            if (stage == CompilationStage.Parse || (stage > CompilationStage.Parse && includeEarlierStages))
            {
                var syntaxTrees = this.SyntaxTrees;
                if (this.Options.ConcurrentBuild)
                {
                    var parallelOptions = cancellationToken.CanBeCanceled
                                        ? new ParallelOptions() { CancellationToken = cancellationToken }
                                        : DefaultParallelOptions;

                    Parallel.For(0, syntaxTrees.Length, parallelOptions,
                        i =>
                        {
                            var syntaxTree = syntaxTrees[i];
                            builder.AddRange(syntaxTree.GetDiagnostics(cancellationToken));
                        });
                }
                else
                {
                    foreach (var syntaxTree in syntaxTrees)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        builder.AddRange(syntaxTree.GetDiagnostics(cancellationToken));
                    }
                }
            }

            cancellationToken.ThrowIfCancellationRequested();

            if (stage == CompilationStage.Compile || stage > CompilationStage.Compile && includeEarlierStages)
            {
                var symbolDiagnostics = DiagnosticBag.GetInstance();
                GetDiagnosticsForAllSymbols(symbolDiagnostics, cancellationToken);
                builder.AddRangeAndFree(symbolDiagnostics);
                builder.AddRange(this.diagnosticBag);
            }

            return builder.ToReadOnlyAndFree();
        }

        // Do the steps in compilation to get the symbol diagnostics, but don't actually generate
        // IL or emit an assembly.
        private void GetDiagnosticsForAllSymbols(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            this.CompleteModel(cancellationToken);
            foreach (var symbol in this.ModelBuilder.Symbols)
            {
                DiagnosticBag symbolDiagnostics = (DiagnosticBag)symbol.MGet(CompilerAttachedProperties.DiagnosticBagProperty);
                if (symbolDiagnostics != null)
                {
                    diagnostics.AddRange(symbolDiagnostics);
                }
            }
        }

        protected abstract void Compile(CancellationToken cancellationToken = default(CancellationToken));
    }
}
