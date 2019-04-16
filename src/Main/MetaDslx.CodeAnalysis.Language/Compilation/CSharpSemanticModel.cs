// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp
{
    /// <summary>
    /// Allows asking semantic questions about a tree of syntax nodes in a Compilation. Typically,
    /// an instance is obtained by a call to <see cref="Compilation"/>.<see
    /// cref="Compilation.GetSemanticModel"/>. 
    /// </summary>
    /// <remarks>
    /// <para>An instance of <see cref="CSharpSemanticModel"/> caches local symbols and semantic
    /// information. Thus, it is much more efficient to use a single instance of <see
    /// cref="CSharpSemanticModel"/> when asking multiple questions about a syntax tree, because
    /// information from the first question may be reused. This also means that holding onto an
    /// instance of SemanticModel for a long time may keep a significant amount of memory from being
    /// garbage collected.
    /// </para>
    /// <para>
    /// When an answer is a named symbol that is reachable by traversing from the root of the symbol
    /// table, (that is, from an <see cref="AssemblySymbol"/> of the <see cref="Compilation"/>),
    /// that symbol will be returned (i.e. the returned value will be reference-equal to one
    /// reachable from the root of the symbol table). Symbols representing entities without names
    /// (e.g. array-of-int) may or may not exhibit reference equality. However, some named symbols
    /// (such as local variables) are not reachable from the root. These symbols are visible as
    /// answers to semantic questions. When the same SemanticModel object is used, the answers
    /// exhibit reference-equality.  
    /// </para>
    /// </remarks>
    internal class CSharpSemanticModel : SemanticModel
    {
        public override string Language => throw new NotImplementedException();

        public override bool IsSpeculativeSemanticModel => throw new NotImplementedException();

        public override int OriginalPositionForSpeculation => throw new NotImplementedException();

        protected override Compilation CompilationCore => throw new NotImplementedException();

        protected override SyntaxTree SyntaxTreeCore => throw new NotImplementedException();

        protected override SemanticModel ParentModelCore => throw new NotImplementedException();

        protected override SyntaxNode RootCore => throw new NotImplementedException();

        internal override SemanticModel ContainingModelOrSelf => throw new NotImplementedException();

        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetMethodBodyDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Diagnostic> GetSyntaxDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override ControlFlowAnalysis AnalyzeControlFlowCore(SyntaxNode firstStatement, SyntaxNode lastStatement)
        {
            throw new NotImplementedException();
        }

        protected override ControlFlowAnalysis AnalyzeControlFlowCore(SyntaxNode statement)
        {
            throw new NotImplementedException();
        }

        protected override DataFlowAnalysis AnalyzeDataFlowCore(SyntaxNode firstStatement, SyntaxNode lastStatement)
        {
            throw new NotImplementedException();
        }

        protected override DataFlowAnalysis AnalyzeDataFlowCore(SyntaxNode statementOrExpression)
        {
            throw new NotImplementedException();
        }

        protected override IAliasSymbol GetAliasInfoCore(SyntaxNode nameSyntax, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override Optional<object> GetConstantValueCore(SyntaxNode node, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override ISymbol GetDeclaredSymbolCore(SyntaxNode declaration, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<ISymbol> GetDeclaredSymbolsCore(SyntaxNode declaration, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override ISymbol GetEnclosingSymbolCore(int position, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<ISymbol> GetMemberGroupCore(SyntaxNode node, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override IOperation GetOperationCore(SyntaxNode node, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override PreprocessingSymbolInfo GetPreprocessingSymbolInfoCore(SyntaxNode nameSyntax)
        {
            throw new NotImplementedException();
        }

        protected override IAliasSymbol GetSpeculativeAliasInfoCore(int position, SyntaxNode nameSyntax, SpeculativeBindingOption bindingOption)
        {
            throw new NotImplementedException();
        }

        protected override SymbolInfo GetSpeculativeSymbolInfoCore(int position, SyntaxNode expression, SpeculativeBindingOption bindingOption)
        {
            throw new NotImplementedException();
        }

        protected override TypeInfo GetSpeculativeTypeInfoCore(int position, SyntaxNode expression, SpeculativeBindingOption bindingOption)
        {
            throw new NotImplementedException();
        }

        protected override SymbolInfo GetSymbolInfoCore(SyntaxNode node, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override TypeInfo GetTypeInfoCore(SyntaxNode node, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override bool IsAccessibleCore(int position, ISymbol symbol)
        {
            throw new NotImplementedException();
        }

        protected override bool IsEventUsableAsFieldCore(int position, IEventSymbol eventSymbol)
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<ISymbol> LookupBaseMembersCore(int position, string name)
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<ISymbol> LookupLabelsCore(int position, string name)
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<ISymbol> LookupNamespacesAndTypesCore(int position, INamespaceOrTypeSymbol container, string name)
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<ISymbol> LookupStaticMembersCore(int position, INamespaceOrTypeSymbol container, string name)
        {
            throw new NotImplementedException();
        }

        protected override ImmutableArray<ISymbol> LookupSymbolsCore(int position, INamespaceOrTypeSymbol container, string name, bool includeReducedExtensionMethods)
        {
            throw new NotImplementedException();
        }

        internal override void ComputeDeclarationsInNode(SyntaxNode node, bool getSymbol, ArrayBuilder<DeclarationInfo> builder, CancellationToken cancellationToken, int? levelsToCompute = null)
        {
            throw new NotImplementedException();
        }

        internal override void ComputeDeclarationsInSpan(TextSpan span, bool getSymbol, ArrayBuilder<DeclarationInfo> builder, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
