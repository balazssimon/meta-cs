using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using System.Threading;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.CodeGen;
using System.IO;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace MetaDslx.CodeAnalysis
{
    public abstract class CompilationAdapter : Microsoft.CodeAnalysis.Compilation
    {
        internal CompilationAdapter(string name, ImmutableArray<Microsoft.CodeAnalysis.MetadataReference> references, IReadOnlyDictionary<string, string> features, bool isSubmission, AsyncQueue<CompilationEvent> eventQueue) 
            : base(name, references, features, isSubmission, eventQueue)
        {
        }

        public override string Language => LanguageCore.Name;

        protected abstract Language LanguageCore { get; }

        public abstract DeclarationTable Declarations { get; }

        internal abstract Microsoft.CodeAnalysis.CSharp.CSharpCompilation CSharpCompilationForReferencedModules { get; }

        internal Microsoft.CodeAnalysis.CSharp.Symbols.SourceAssemblySymbol CSharpAssemblySymbolForReferencedModules => CSharpCompilationForReferencedModules.SourceAssembly;

        internal override IEnumerable<Microsoft.CodeAnalysis.ReferenceDirective> ReferenceDirectives
        {
            get { return this.ReferenceDirectivesCore.Select(d => d.ToMicrosoft()); }
        }

        protected abstract IEnumerable<MetaDslx.CodeAnalysis.Syntax.ReferenceDirective> ReferenceDirectivesCore { get; }

        internal override CommonMessageProvider MessageProvider
        {
            get { return Microsoft.CodeAnalysis.CSharp.MessageProvider.Instance; }
        }

        /// <summary>
        /// Gets the diagnostics produced during the analysis of method bodies and field initializers.
        /// </summary>
        public sealed override ImmutableArray<Diagnostic> GetMethodBodyDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetSymbolDiagnostics(cancellationToken);
        }

        public abstract ImmutableArray<Diagnostic> GetSymbolDiagnostics(CancellationToken cancellationToken = default(CancellationToken));

        #region emit
        internal override byte LinkerMajorVersion => 0x30;

        internal override bool IsDelaySigned => false;

        internal override StrongNameKeys StrongNameKeys => StrongNameKeys.None;

        internal override CommonPEModuleBuilder CreateModuleBuilder(
            EmitOptions emitOptions,
            IMethodSymbol debugEntryPoint,
            Stream sourceLinkStream,
            IEnumerable<EmbeddedText> embeddedTexts,
            IEnumerable<ResourceDescription> manifestResources,
            CompilationTestData testData,
            DiagnosticBag diagnostics,
            CancellationToken cancellationToken)
        {
            Debug.Assert(!IsSubmission || HasCodeToEmit());
            throw new NotImplementedException();
        }

        internal override bool CompileMethods(
            CommonPEModuleBuilder moduleBuilder,
            bool emittingPdb,
            bool emitMetadataOnly,
            bool emitTestCoverageData,
            DiagnosticBag diagnostics,
            Predicate<ISymbol> filterOpt,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal override bool GenerateResourcesAndDocumentationComments(
            CommonPEModuleBuilder moduleBuilder,
            Stream xmlDocStream,
            Stream win32Resources,
            string outputNameOverride,
            DiagnosticBag diagnostics,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal override EmitDifferenceResult EmitDifference(
            EmitBaseline baseline,
            IEnumerable<SemanticEdit> edits,
            Func<ISymbol, bool> isAddedSymbol,
            Stream metadataStream,
            Stream ilStream,
            Stream pdbStream,
            ICollection<MethodDefinitionHandle> updatedMethods,
            CompilationTestData testData,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal override void AddDebugSourceDocumentsForChecksumDirectives(
            DebugDocumentsBuilder documentsBuilder,
            SyntaxTree tree,
            DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }

        internal override Guid DebugSourceDocumentLanguageId => Guid.Empty;

        #endregion

        protected override IArrayTypeSymbol CommonCreateArrayTypeSymbol(ITypeSymbol elementType, int rank)
        {
            throw new NotImplementedException();
        }

        protected override IPointerTypeSymbol CommonCreatePointerTypeSymbol(ITypeSymbol elementType)
        {
            throw new NotImplementedException();
        }

        protected override INamedTypeSymbol CommonCreateTupleTypeSymbol(
            ImmutableArray<ITypeSymbol> elementTypes,
            ImmutableArray<string> elementNames,
            ImmutableArray<Location> elementLocations)
        {
            throw new NotImplementedException();
        }

        protected override INamedTypeSymbol CommonCreateTupleTypeSymbol(
            INamedTypeSymbol underlyingType,
            ImmutableArray<string> elementNames,
            ImmutableArray<Location> elementLocations)
        {
            throw new NotImplementedException();
        }

        protected override INamedTypeSymbol CommonCreateAnonymousTypeSymbol(
            ImmutableArray<ITypeSymbol> memberTypes,
            ImmutableArray<string> memberNames,
            ImmutableArray<Location> memberLocations,
            ImmutableArray<bool> memberIsReadOnly)
        {
            throw new NotImplementedException();
        }

        internal override ISymbol CommonGetWellKnownTypeMember(WellKnownMember member)
        {
            throw new NotImplementedException();
        }

        internal override bool IsAttributeType(ITypeSymbol type)
        {
            throw new NotImplementedException();
        }

        internal override bool IsSystemTypeReference(ITypeSymbol type)
        {
            throw new NotImplementedException();
        }
    }
}
