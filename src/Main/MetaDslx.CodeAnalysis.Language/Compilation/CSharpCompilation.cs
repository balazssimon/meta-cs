// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeGen;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp
{
    /// <summary>
    /// The compilation object is an immutable representation of a single invocation of the
    /// compiler. Although immutable, a compilation is also on-demand, and will realize and cache
    /// data as necessary. A compilation can produce a new compilation from existing compilation
    /// with the application of small deltas. In many cases, it is more efficient than creating a
    /// new compilation from scratch, as the new compilation can reuse information from the old
    /// compilation.
    /// </summary>
    public sealed partial class CSharpCompilation : Compilation
    {
        public DiagnosticBag DeclarationDiagnostics { get; internal set; }
        internal MergedNamespaceDeclaration MergedRootDeclaration { get; set; }
        internal new AssemblySymbol Assembly { get; }
        internal AnonymousTypeManager AnonymousTypeManager { get; }
        internal new NamedTypeSymbol GetSpecialType(SpecialType specialType) { return null; }

        public override bool IsCaseSensitive => throw new NotImplementedException();

        public override string Language => throw new NotImplementedException();

        public override ImmutableArray<MetadataReference> DirectiveReferences => throw new NotImplementedException();

        public override IEnumerable<AssemblyIdentity> ReferencedAssemblyNames => throw new NotImplementedException();

        protected override CompilationOptions CommonOptions => throw new NotImplementedException();

        protected override IEnumerable<SyntaxTree> CommonSyntaxTrees => throw new NotImplementedException();

        protected override IAssemblySymbol CommonAssembly => throw new NotImplementedException();

        protected override IModuleSymbol CommonSourceModule => throw new NotImplementedException();

        protected override INamespaceSymbol CommonGlobalNamespace => throw new NotImplementedException();

        protected override INamedTypeSymbol CommonObjectType => throw new NotImplementedException();

        protected override ITypeSymbol CommonDynamicType => throw new NotImplementedException();

        protected override INamedTypeSymbol CommonScriptClass => throw new NotImplementedException();

        internal override ScriptCompilationInfo CommonScriptCompilationInfo => throw new NotImplementedException();

        internal override IEnumerable<ReferenceDirective> ReferenceDirectives => throw new NotImplementedException();

        internal override IDictionary<(string path, string content), MetadataReference> ReferenceDirectiveMap => throw new NotImplementedException();

        internal override CommonAnonymousTypeManager CommonAnonymousTypeManager => throw new NotImplementedException();

        internal override CommonMessageProvider MessageProvider => throw new NotImplementedException();

        internal override byte LinkerMajorVersion => throw new NotImplementedException();

        internal override bool IsDelaySigned => throw new NotImplementedException();

        internal override StrongNameKeys StrongNameKeys => throw new NotImplementedException();

        internal override Guid DebugSourceDocumentLanguageId => throw new NotImplementedException();

        public override CommonConversion ClassifyCommonConversion(ITypeSymbol source, ITypeSymbol destination)
        {
            throw new NotImplementedException();
        }

        public override bool ContainsSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override bool ContainsSymbolsWithName(string name, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetMethodBodyDiagnostics(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetParseDiagnostics(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ISymbol> GetSymbolsWithName(Func<string, bool> predicate, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ISymbol> GetSymbolsWithName(string name, SymbolFilter filter = SymbolFilter.TypeAndMember, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override CompilationReference ToMetadataReference(ImmutableArray<string> aliases = default, bool embedInteropTypes = false)
        {
            throw new NotImplementedException();
        }

        protected override void AppendDefaultVersionResource(Stream resourceStream)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonAddSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonClone()
        {
            throw new NotImplementedException();
        }

        protected override bool CommonContainsSyntaxTree(SyntaxTree syntaxTree)
        {
            throw new NotImplementedException();
        }

        protected override INamedTypeSymbol CommonCreateAnonymousTypeSymbol(ImmutableArray<ITypeSymbol> memberTypes, ImmutableArray<string> memberNames, ImmutableArray<Location> memberLocations, ImmutableArray<bool> memberIsReadOnly)
        {
            throw new NotImplementedException();
        }

        protected override IArrayTypeSymbol CommonCreateArrayTypeSymbol(ITypeSymbol elementType, int rank)
        {
            throw new NotImplementedException();
        }

        protected override INamespaceSymbol CommonCreateErrorNamespaceSymbol(INamespaceSymbol container, string name)
        {
            throw new NotImplementedException();
        }

        protected override INamedTypeSymbol CommonCreateErrorTypeSymbol(INamespaceOrTypeSymbol container, string name, int arity)
        {
            throw new NotImplementedException();
        }

        protected override IPointerTypeSymbol CommonCreatePointerTypeSymbol(ITypeSymbol elementType)
        {
            throw new NotImplementedException();
        }

        protected override INamedTypeSymbol CommonCreateTupleTypeSymbol(ImmutableArray<ITypeSymbol> elementTypes, ImmutableArray<string> elementNames, ImmutableArray<Location> elementLocations)
        {
            throw new NotImplementedException();
        }

        protected override INamedTypeSymbol CommonCreateTupleTypeSymbol(INamedTypeSymbol underlyingType, ImmutableArray<string> elementNames, ImmutableArray<Location> elementLocations)
        {
            throw new NotImplementedException();
        }

        protected override ISymbol CommonGetAssemblyOrModuleSymbol(MetadataReference reference)
        {
            throw new NotImplementedException();
        }

        protected override INamespaceSymbol CommonGetCompilationNamespace(INamespaceSymbol namespaceSymbol)
        {
            throw new NotImplementedException();
        }

        protected override IMethodSymbol CommonGetEntryPoint(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override SemanticModel CommonGetSemanticModel(SyntaxTree syntaxTree, bool ignoreAccessibility)
        {
            throw new NotImplementedException();
        }

        protected override INamedTypeSymbol CommonGetSpecialType(SpecialType specialType)
        {
            throw new NotImplementedException();
        }

        protected override INamedTypeSymbol CommonGetTypeByMetadataName(string metadataName)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonRemoveAllSyntaxTrees()
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonRemoveSyntaxTrees(IEnumerable<SyntaxTree> trees)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonReplaceSyntaxTree(SyntaxTree oldTree, SyntaxTree newTree)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonWithAssemblyName(string outputName)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonWithOptions(CompilationOptions options)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonWithReferences(IEnumerable<MetadataReference> newReferences)
        {
            throw new NotImplementedException();
        }

        protected override Compilation CommonWithScriptCompilationInfo(ScriptCompilationInfo info)
        {
            throw new NotImplementedException();
        }

        internal override void AddDebugSourceDocumentsForChecksumDirectives(DebugDocumentsBuilder documentsBuilder, SyntaxTree tree, DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }

        internal override AnalyzerDriver AnalyzerForLanguage(ImmutableArray<DiagnosticAnalyzer> analyzers, AnalyzerManager analyzerManager)
        {
            throw new NotImplementedException();
        }

        internal override IConvertibleConversion ClassifyConvertibleConversion(IOperation source, ITypeSymbol destination, out Optional<object> constantValue)
        {
            throw new NotImplementedException();
        }

        internal override CommonReferenceManager CommonGetBoundReferenceManager()
        {
            throw new NotImplementedException();
        }

        internal override ISymbol CommonGetSpecialTypeMember(SpecialMember specialMember)
        {
            throw new NotImplementedException();
        }

        internal override int CompareSourceLocations(Location loc1, Location loc2)
        {
            throw new NotImplementedException();
        }

        internal override int CompareSourceLocations(SyntaxReference loc1, SyntaxReference loc2)
        {
            throw new NotImplementedException();
        }

        internal override bool CompileMethods(CommonPEModuleBuilder moduleBuilder, bool emittingPdb, bool emitMetadataOnly, bool emitTestCoverageData, DiagnosticBag diagnostics, Predicate<ISymbol> filterOpt, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal override void CompleteTrees(SyntaxTree filterTree)
        {
            throw new NotImplementedException();
        }

        internal override CommonPEModuleBuilder CreateModuleBuilder(EmitOptions emitOptions, IMethodSymbol debugEntryPoint, Stream sourceLinkStream, IEnumerable<EmbeddedText> embeddedTexts, IEnumerable<ResourceDescription> manifestResources, CompilationTestData testData, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal override EmitDifferenceResult EmitDifference(EmitBaseline baseline, IEnumerable<SemanticEdit> edits, Func<ISymbol, bool> isAddedSymbol, Stream metadataStream, Stream ilStream, Stream pdbStream, ICollection<MethodDefinitionHandle> updatedMethodHandles, CompilationTestData testData, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal override bool GenerateResourcesAndDocumentationComments(CommonPEModuleBuilder moduleBeingBuilt, Stream xmlDocumentationStream, Stream win32ResourcesStream, string outputNameOverride, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal override void GetDiagnostics(CompilationStage stage, bool includeEarlierStages, DiagnosticBag diagnostics, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        internal override int GetSyntaxTreeOrdinal(SyntaxTree tree)
        {
            throw new NotImplementedException();
        }

        internal override bool HasCodeToEmit()
        {
            throw new NotImplementedException();
        }

        internal override bool HasSubmissionResult()
        {
            throw new NotImplementedException();
        }

        internal override bool IsUnreferencedAssemblyIdentityDiagnosticCode(int code)
        {
            throw new NotImplementedException();
        }

        internal override void ReportUnusedImports(SyntaxTree filterTree, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        internal override void ValidateDebugEntryPoint(IMethodSymbol debugEntryPoint, DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }

        internal override Compilation WithEventQueue(AsyncQueue<CompilationEvent> eventQueue)
        {
            throw new NotImplementedException();
        }

        private protected override bool IsSymbolAccessibleWithinCore(ISymbol symbol, ISymbol within, ITypeSymbol throughType)
        {
            throw new NotImplementedException();
        }
    }
}
