// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.FlowAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Binding.Binders;

namespace MetaDslx.CodeAnalysis
{
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;

    /// <summary>
    /// Allows asking semantic questions about any node in a SyntaxTree within a Compilation.
    /// </summary>
    internal partial class SyntaxTreeSemanticModel : LanguageSemanticModel
    {
        private readonly LanguageCompilation _compilation;
        private readonly BoundTree _boundTree;

        /// <summary>
        /// Note, the name of this field could be somewhat confusing because it is also 
        /// used to store models for attributes and default parameter values, which are
        /// not members.
        /// </summary>
        private ImmutableDictionary<LanguageSyntaxNode, MemberSemanticModel> _memberModels = ImmutableDictionary<LanguageSyntaxNode, MemberSemanticModel>.Empty;

        private readonly BinderFactory _binderFactory;
        private Func<LanguageSyntaxNode, MemberSemanticModel> _createMemberModelFunction;
        private readonly bool _ignoresAccessibility;

        internal SyntaxTreeSemanticModel(LanguageCompilation compilation, LanguageSyntaxTree syntaxTree, bool ignoreAccessibility = false)
        {
            _compilation = compilation;
            _ignoresAccessibility = ignoreAccessibility;

            if (!this.Compilation.SyntaxTrees.Contains(syntaxTree))
            {
                throw new ArgumentOutOfRangeException(nameof(syntaxTree), CSharpResources.TreeNotPartOfCompilation);
            }

            var rootNode = syntaxTree.GetRootNode();
            _boundTree = new BoundTree(compilation, rootNode, compilation.GetBinder(rootNode));

            _binderFactory = compilation.GetBinderFactory(SyntaxTree);
        }

        internal SyntaxTreeSemanticModel(LanguageCompilation parentCompilation, LanguageSyntaxTree parentSyntaxTree, LanguageSyntaxTree speculatedSyntaxTree)
        {
            _compilation = parentCompilation;
            var rootNode = speculatedSyntaxTree.GetRootNode();
            _boundTree = new BoundTree(parentCompilation, rootNode, parentCompilation.GetBinder(rootNode));
            _binderFactory = _compilation.GetBinderFactory(parentSyntaxTree);
        }

        /// <summary>
        /// The compilation this object was obtained from.
        /// </summary>
        public override LanguageCompilation Compilation
        {
            get
            {
                return _compilation;
            }
        }

        public override BoundTree BoundTree => _boundTree;

        /// <summary>
        /// The root node of the syntax tree that this object is associated with.
        /// </summary>
        public override SyntaxNodeOrToken Root
        {
            get
            {
                return _boundTree.RootSyntax;
            }
        }

        /// <summary>
        /// The SyntaxTree that this object is associated with.
        /// </summary>
        public override SyntaxTree SyntaxTree
        {
            get
            {
                return _boundTree.SyntaxTree;
            }
        }

        /// <summary>
        /// Returns true if this is a SemanticModel that ignores accessibility rules when answering semantic questions.
        /// </summary>
        public override bool IgnoresAccessibility
        {
            get { return _ignoresAccessibility; }
        }

        private void VerifySpanForGetDiagnostics(TextSpan? span)
        {
            if (span.HasValue && !this.Root.FullSpan.Contains(span.Value))
            {
                throw new ArgumentException("span");
            }
        }

        public override ImmutableArray<Diagnostic> GetSyntaxDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
            CompilationStage.Parse, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
            CompilationStage.Declare, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public override ImmutableArray<Diagnostic> GetSymbolDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
            CompilationStage.Compile, this.SyntaxTree, span, includeEarlierStages: false, cancellationToken: cancellationToken);
        }

        public override ImmutableArray<Diagnostic> GetDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            VerifySpanForGetDiagnostics(span);
            return Compilation.GetDiagnosticsForSyntaxTree(
            CompilationStage.Compile, this.SyntaxTree, span, includeEarlierStages: true, cancellationToken: cancellationToken);
        }

        protected override Binder GetEnclosingBinderCore(int position)
        {
            var token = this.Root.IsToken ? this.Root.AsToken() : this.Root.AsNode().FindToken(position);
            return Compilation.GetBinder(token);
        }

        public override bool IsSpeculativeSemanticModel
        {
            get { return false; }
        }

        public override int OriginalPositionForSpeculation
        {
            get { return 0; }
        }

        public override LanguageSemanticModel ParentModel
        {
            get { return null; }
        }

        internal override SemanticModel ContainingModelOrSelf
        {
            get { return this; }
        }

        internal sealed override bool TryGetSpeculativeSemanticModelCore(SyntaxTreeSemanticModel parentModel, int position, LanguageSyntaxNode node, SpeculativeBindingOption bindingOption, out SemanticModel speculativeModel)
        {
            position = CheckAndAdjustPosition(position);

            var model = this.GetMemberModel(position);
            if (model != null)
            {
                return model.TryGetSpeculativeSemanticModelCore(parentModel, position, node, bindingOption, out speculativeModel);
            }

            Binder binder = GetSpeculativeBinder(position, node, bindingOption);
            if (binder != null)
            {
                speculativeModel = SpeculativeSyntaxTreeSemanticModel.Create(parentModel, node, binder, position, bindingOption);
                return true;
            }

            speculativeModel = null;
            return false;
        }


        // Try to get a member semantic model that encloses "node". If there is not an enclosing
        // member semantic model, return null.
        internal MemberSemanticModel GetMemberModel(int position)
        {
            throw new NotImplementedException();
        }

        // Try to get a member semantic model that encloses "node". If there is not an enclosing
        // member semantic model, return null.
        internal override MemberSemanticModel GetMemberModel(SyntaxNode node)
        {
            throw new NotImplementedException();
        }

        private bool IsRegularCode
        {
            get
            {
                return this.SyntaxTree.Options.Kind == SourceCodeKind.Regular;
            }
        }

        #region "GetDeclaredSymbol overloads for MemberDeclarationSyntax and its subtypes"

        /// <summary>
        /// Given a member declaration syntax, get the corresponding symbol.
        /// </summary>
        /// <param name="declarationSyntax">The syntax node that declares a member.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The symbol that was declared.</returns>
        /// <remarks>
        /// NOTE:   We have no GetDeclaredSymbol overloads for following subtypes of MemberDeclarationSyntax:
        /// NOTE:   (1) GlobalStatementSyntax as they don't declare any symbols.
        /// NOTE:   (2) IncompleteMemberSyntax as there are no symbols for incomplete members.
        /// NOTE:   (3) BaseFieldDeclarationSyntax or its subtypes as these declarations can contain multiple variable declarators.
        /// NOTE:       GetDeclaredSymbol should be called on the variable declarators directly.
        /// </remarks>
        public override DeclaredSymbol GetDeclaredSymbol(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(declarationSyntax);

            return GetDeclaredNamespace(declarationSyntax);
        }

        private NamespaceSymbol GetDeclaredNamespace(LanguageSyntaxNode declarationSyntax)
        {
            Debug.Assert(declarationSyntax != null);
            throw new NotImplementedException("TODO:MetaDslx");
            /*NamespaceOrTypeSymbol container;
            if (declarationSyntax.Parent.RawKind == SyntaxKind.CompilationUnit)
            {
                container = _compilation.Assembly.GlobalNamespace;
            }
            else
            {
                container = GetDeclaredNamespaceOrType(declarationSyntax.Parent);
            }

            Debug.Assert((object)container != null);

            // We should get a namespace symbol since we match the symbol location with a namespace declaration syntax location.
            var symbol = (NamespaceSymbol)GetDeclaredMember(container, declarationSyntax.Span, declarationSyntax.Name);
            Debug.Assert((object)symbol != null);

            // Map to compilation-scoped namespace (Roslyn bug 9538)
            symbol = _compilation.GetCompilationNamespace(symbol);
            Debug.Assert((object)symbol != null);

            return symbol;*/
        }

        #endregion

        /// <summary>
        /// Given a base field declaration syntax, get the corresponding symbols.
        /// </summary>
        /// <param name="declarationSyntax">The syntax node that declares one or more fields or events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The field symbols that were declared.</returns>
        public override ImmutableArray<DeclaredSymbol> GetDeclaredSymbols(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            CheckSyntaxNode(declarationSyntax);

            /* 
            var builder = new ArrayBuilder<ISymbol>();

            foreach (var declarator in declarationSyntax.Declaration.Variables)
            {
                var field = this.GetDeclaredSymbol(declarator, cancellationToken) as ISymbol;
                if (field != null)
                {
                    builder.Add(field);
                }
            }

            return builder.ToImmutableAndFree();*/
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public override ControlFlowAnalysis AnalyzeControlFlow(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            ValidateStatementRange(firstStatement, lastStatement);
            var context = RegionAnalysisContext(firstStatement, lastStatement);
            var result = new LanguageControlFlowAnalysis(context);
            return result;
        }

        private void ValidateStatementRange(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            if (firstStatement == null)
            {
                throw new ArgumentNullException(nameof(firstStatement));
            }

            if (lastStatement == null)
            {
                throw new ArgumentNullException(nameof(lastStatement));
            }

            if (!IsInTree(firstStatement))
            {
                throw new ArgumentException("statements not within tree");
            }

            if (firstStatement.Parent == null || firstStatement.Parent != lastStatement.Parent)
            {
                throw new ArgumentException("statements not within the same statement list");
            }

            if (firstStatement.SpanStart > lastStatement.SpanStart)
            {
                throw new ArgumentException("first statement does not precede last statement");
            }
        }

        public override DataFlowAnalysis AnalyzeDataFlow(LanguageSyntaxNode expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (!IsInTree(expression))
            {
                throw new ArgumentException("expression not within tree");
            }

            var context = RegionAnalysisContext(expression);
            var result = new LanguageDataFlowAnalysis(context);
            return result;
        }

        public override DataFlowAnalysis AnalyzeDataFlow(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            ValidateStatementRange(firstStatement, lastStatement);
            var context = RegionAnalysisContext(firstStatement, lastStatement);
            var result = new LanguageDataFlowAnalysis(context);
            return result;
        }

        private static BoundNode GetBoundRoot(MemberSemanticModel memberModel, out Symbol member)
        {
            member = memberModel.MemberSymbol;
            return memberModel.GetBoundRoot();
        }

        private RegionAnalysisContext RegionAnalysisContext(LanguageSyntaxNode expression)
        {
            var memberModel = GetMemberModel(expression);
            if (memberModel == null)
            {
                // Recover from error cases
                // TODO:MetaDslx
                //var node = new BoundBadStatement(BoundTree, ImmutableArray<object>.Empty, expression, hasErrors: true);
                BoundNode node = null;
                return new RegionAnalysisContext(Compilation, null, node, node, node);
            }

            Symbol member;
            BoundNode boundNode = GetBoundRoot(memberModel, out member);
            var first = memberModel.GetUpperBoundNode(expression, promoteToBindable: true);
            var last = first;
            return new RegionAnalysisContext(this.Compilation, member, boundNode, first, last);
        }

        private RegionAnalysisContext RegionAnalysisContext(LanguageSyntaxNode firstStatement, LanguageSyntaxNode lastStatement)
        {
            var memberModel = GetMemberModel(firstStatement);
            if (memberModel == null)
            {
                // Recover from error cases
                // TODO:MetaDslx
                // var node = new BoundBadStatement(BoundTree, ImmutableArray<object>.Empty, firstStatement, hasErrors: true);
                BoundNode node = null;
                return new RegionAnalysisContext(Compilation, null, node, node, node);
            }

            Symbol member;
            BoundNode boundNode = GetBoundRoot(memberModel, out member);
            var first = memberModel.GetUpperBoundNode(firstStatement, promoteToBindable: true);
            var last = memberModel.GetUpperBoundNode(lastStatement, promoteToBindable: true);
            return new RegionAnalysisContext(Compilation, member, boundNode, first, last);
        }
    }
}
