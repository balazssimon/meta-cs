// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Operations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Operations;
using MetaDslx.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    using CSharpResources = MetaDslx.CodeAnalysis.CSharp.CSharpResources;

    /// <summary>
    /// Binding info for expressions and statements that are part of a member declaration.
    /// </summary>
    internal abstract partial class MemberSemanticModel : LanguageSemanticModel
    {
        private readonly Symbol _memberSymbol;
        private readonly BoundTree _boundTree;
        private readonly DiagnosticBag _ignoredDiagnostics = new DiagnosticBag();

        internal readonly Binder RootBinder;

        /// <summary>
        /// Field specific to a non-speculative MemberSemanticModel that must have a containing semantic model.
        /// </summary>
        private readonly SyntaxTreeSemanticModel _containingSemanticModelOpt;

        // Fields specific to a speculative MemberSemanticModel.
        private readonly SyntaxTreeSemanticModel _parentSemanticModelOpt;
        private readonly int _speculatedPosition;

        private readonly Lazy<LanguageOperationFactory> _operationFactory;

        protected MemberSemanticModel(
            LanguageSyntaxNode root,
            Symbol memberSymbol,
            Binder rootBinder,
            SyntaxTreeSemanticModel containingSemanticModelOpt,
            SyntaxTreeSemanticModel parentSemanticModelOpt,
            int speculatedPosition)
        {
            Debug.Assert(root != null);
            Debug.Assert((object)memberSymbol != null);
            Debug.Assert(parentSemanticModelOpt == null ^ containingSemanticModelOpt == null);
            Debug.Assert(containingSemanticModelOpt == null || !containingSemanticModelOpt.IsSpeculativeSemanticModel);
            Debug.Assert(parentSemanticModelOpt == null || !parentSemanticModelOpt.IsSpeculativeSemanticModel, CSharpResources.ChainingSpeculativeModelIsNotSupported);

            _memberSymbol = memberSymbol;

            this.RootBinder = rootBinder.WithAdditionalFlags(GetSemanticModelBinderFlags());
            _containingSemanticModelOpt = containingSemanticModelOpt;
            _parentSemanticModelOpt = parentSemanticModelOpt;
            _speculatedPosition = speculatedPosition;

            _boundTree = new BoundTree(this.Compilation, root, rootBinder);

            _operationFactory = new Lazy<LanguageOperationFactory>(() => new LanguageOperationFactory(this));
        }

        public override LanguageCompilation Compilation
        {
            get
            {
                return (_containingSemanticModelOpt ?? _parentSemanticModelOpt).Compilation;
            }
        }

        public override LanguageSyntaxNode Root
        {
            get
            {
                return (LanguageSyntaxNode)_boundTree.RootSyntax.NodeOrParent;
            }
        }

        public override BoundTree BoundTree => _boundTree;

        /// <summary>
        /// The member symbol 
        /// </summary>
        public Symbol MemberSymbol
        {
            get
            {
                return _memberSymbol;
            }
        }

        public sealed override bool IsSpeculativeSemanticModel
        {
            get
            {
                return _parentSemanticModelOpt != null;
            }
        }

        public sealed override int OriginalPositionForSpeculation
        {
            get
            {
                return _speculatedPosition;
            }
        }

        public sealed override LanguageSemanticModel ParentModel
        {
            get
            {
                return _parentSemanticModelOpt;
            }
        }

        internal sealed override SemanticModel ContainingModelOrSelf
        {
            get
            {
                return _containingSemanticModelOpt ?? (SemanticModel)this;
            }
        }

        internal override MemberSemanticModel GetMemberModel(SyntaxNode node)
        {
            // We do have to override this method, but should never call it because it might not do the right thing. 
            Debug.Assert(false);
            return IsInTree(node) ? this : null;
        }

        internal sealed override bool TryGetSpeculativeSemanticModelCore(SyntaxTreeSemanticModel parentModel, int position, LanguageSyntaxNode type, SpeculativeBindingOption bindingOption, out SemanticModel speculativeModel)
        {
            var expression = SyntaxFactory.GetStandaloneNode(type);

            var binder = this.GetSpeculativeBinder(position, expression, bindingOption);
            if (binder != null)
            {
                speculativeModel = new SpeculativeMemberSemanticModel(parentModel, _memberSymbol, type, binder, position);
                return true;
            }

            speculativeModel = null;
            return false;
        }

        private Binder GetEnclosingBinderInternalWithinRoot(SyntaxNode node, int position)
        {
            AssertPositionAdjusted(position);
            return BoundTree.GetEnclosingBinderInternalWithinRoot(node, position, RootBinder, _boundTree.RootSyntax).WithAdditionalFlags(GetSemanticModelBinderFlags());
        }

        public override Conversion ClassifyConversion(
            LanguageSyntaxNode expression,
            ITypeSymbol destination,
            bool isExplicitInSource = false)
        {
            if ((object)destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var csdestination = destination.EnsureLanguageSymbolOrNull<ITypeSymbol, TypeSymbol>(nameof(destination));

            if (isExplicitInSource)
            {
                return ClassifyConversionForCast(expression, csdestination);
            }

            // Note that it is possible for an expression to be convertible to a type
            // via both an implicit user-defined conversion and an explicit built-in conversion.
            // In that case, this method chooses the implicit conversion.

            CheckSyntaxNode(expression);

            var binder = this.GetEnclosingBinderInternal(expression, GetAdjustedNodePosition(expression));
            LanguageSyntaxNode bindableNode = this.GetBindableSyntaxNode(expression);
            var boundExpression = this.GetLowerBoundNode(bindableNode);
            if (binder == null || boundExpression == null)
            {
                return Conversion.NoConversion;
            }

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            return binder.Conversions.ClassifyConversionFromExpression(boundExpression, csdestination, ref useSiteDiagnostics);
        }

        internal override Conversion ClassifyConversionForCast(
            LanguageSyntaxNode expression,
            TypeSymbol destination)
        {
            CheckSyntaxNode(expression);

            if ((object)destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var binder = this.GetEnclosingBinderInternal(expression, GetAdjustedNodePosition(expression));
            LanguageSyntaxNode bindableNode = this.GetBindableSyntaxNode(expression);
            var boundExpression = this.GetLowerBoundNode(bindableNode);
            if (binder == null || boundExpression == null)
            {
                return Conversion.NoConversion;
            }

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            return binder.Conversions.ClassifyConversionFromExpression(boundExpression, destination, ref useSiteDiagnostics, forCast: true);
        }

        /// <summary>
        /// Get the bound node corresponding to the root.
        /// </summary> 
        internal virtual BoundNode GetBoundRoot()
        {
            return _boundTree.GetBoundRoot();
        }

        /// <summary>
        /// Get the highest bound node in the tree associated with a particular syntax node.
        /// </summary>
        internal BoundNode GetUpperBoundNode(LanguageSyntaxNode node, bool promoteToBindable = false)
        {
            var boundNodes = _boundTree.GetBoundNodes(node);
            return boundNodes[0];
        }

        /// <summary>
        /// Get the lowest bound node in the tree associated with a particular syntax node. Lowest is defined as last
        /// in a pre-order traversal of the bound tree.
        /// </summary>
        internal BoundNode GetLowerBoundNode(LanguageSyntaxNode node)
        {
            var boundNodes = _boundTree.GetBoundNodes(node);
            return boundNodes[boundNodes.Length-1];
        }

        public override ImmutableArray<Diagnostic> GetSyntaxDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public override ImmutableArray<Diagnostic> GetDeclarationDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public override ImmutableArray<Diagnostic> GetMethodBodyDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public override ImmutableArray<Diagnostic> GetDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotSupportedException();
        }

        public override IDeclaredSymbol GetDeclaredSymbol(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Can't define namespace inside a member.
            return null;
        }

        public override ImmutableArray<IDeclaredSymbol> GetDeclaredSymbols(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Can't define field inside member.
            return ImmutableArray.Create<IDeclaredSymbol>();
        }

        public override SyntaxTree SyntaxTree
        {
            get
            {
                return _boundTree.SyntaxTree;
            }
        }

        internal override IOperation GetOperationWorker(LanguageSyntaxNode node, CancellationToken cancellationToken)
        {
            LanguageSyntaxNode bindingRoot = GetBindingRoot(node);

            IOperation statementOrRootOperation = GetStatementOrRootOperation(bindingRoot, cancellationToken);
            if (statementOrRootOperation == null)
            {
                return null;
            }

            // we might optimize it later
            // https://github.com/dotnet/roslyn/issues/22180
            return statementOrRootOperation.DescendantsAndSelf().FirstOrDefault(o => !o.IsImplicit && o.Syntax == node);
        }

        private IOperation GetStatementOrRootOperation(LanguageSyntaxNode node, CancellationToken cancellationToken)
        {
            Debug.Assert(node == GetBindingRoot(node));

            ImmutableArray<BoundNode> boundNodes;
            GetBoundNodes(node, out _, out boundNodes, out _);

            // decide whether we should use highest or lowest bound node here 
            // https://github.com/dotnet/roslyn/issues/22179
            BoundNode result = boundNodes[0];
            return _operationFactory.Value.Create(result);
        }

        internal override SymbolInfo GetSymbolInfoWorker(LanguageSyntaxNode node, SymbolInfoOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            ValidateSymbolInfoOptions(options);

            SyntaxNodeOrToken bindableNode;
            ImmutableArray<BoundNode> boundNodes;
            BoundNode boundParent;
            GetBoundNodes(node, out bindableNode, out boundNodes, out boundParent);

            Debug.Assert(IsInTree(node), "Since the node is in the tree, we can always recompute the binder later");
            return base.GetSymbolInfoForNode(options, boundNodes, boundParent, binderOpt: null);
        }

        internal override LanguageTypeInfo GetTypeInfoWorker(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            SyntaxNodeOrToken bindableNode;
            ImmutableArray<BoundNode> boundNodes;
            BoundNode boundParent;
            GetBoundNodes(node, out bindableNode, out boundNodes, out boundParent);

            return GetTypeInfoForNode(boundNodes, boundParent);
        }

        internal override ImmutableArray<Symbol> GetMemberGroupWorker(LanguageSyntaxNode node, SymbolInfoOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            SyntaxNodeOrToken bindableNode;
            ImmutableArray<BoundNode> boundNodes;
            BoundNode boundParent;
            GetBoundNodes(node, out bindableNode, out boundNodes, out boundParent);

            Debug.Assert(IsInTree(node), "Since the node is in the tree, we can always recompute the binder later");
            return base.GetMemberGroupForNode(options, boundNodes[boundNodes.Length-1], boundParent, binderOpt: null);
        }

        internal override Optional<object> GetConstantValueWorker(LanguageSyntaxNode node, CancellationToken cancellationToken)
        {
            LanguageSyntaxNode bindableNode = this.GetBindableSyntaxNode(node);
            BoundNode boundExpr = this.GetLowerBoundNode(bindableNode);
            // TODO:MetaDslx
            return default(Optional<object>);
        }

        private void GetBoundNodes(SyntaxNodeOrToken node, out SyntaxNodeOrToken bindableNode, out ImmutableArray<BoundNode> boundNodes, out BoundNode boundParent)
        {
            _boundTree.GetBoundNodes(node, out bindableNode, out boundNodes, out boundParent);
        }

        // We might not have actually been given a bindable expression or statement; the caller can
        // give us variable declaration nodes, for example. If we're not at an expression or
        // statement, back up until we find one.
        private LanguageSyntaxNode GetBindingRoot(LanguageSyntaxNode node)
        {
            return (LanguageSyntaxNode)_boundTree.GetBindingRoot(node).NodeOrParent;
        }

        // We want the binder in which this syntax node is going to be bound, NOT the binder which
        // this syntax node *produces*. That is, suppose we have
        //
        // void M() { int x; { int y; { int z; } } } 
        //
        // We want the enclosing binder of the syntax node for { int z; }.  We do not want the binder
        // that has local z, but rather the binder that has local y. The inner block is going to be
        // bound in the context of its enclosing binder; it's contents are going to be bound in the
        // context of its binder.
        internal override Binder GetEnclosingBinderInternal(int position)
        {
            AssertPositionAdjusted(position);

            // If we have a root binder with no tokens in it, position can be outside the span event
            // after position is adjusted. If this happens, there can't be any 
            if (!this.Root.FullSpan.Contains(position))
                return this.RootBinder;

            SyntaxToken token = this.Root.FindToken(position);
            LanguageSyntaxNode node = (LanguageSyntaxNode)token.Parent;

            return GetEnclosingBinderInternal(node, position);
        }

        /// <summary>
        /// This overload exists for callers who already have a node in hand 
        /// and don't want to search through the tree.
        /// </summary>
        private Binder GetEnclosingBinderInternal(LanguageSyntaxNode node, int position)
        {
            AssertPositionAdjusted(position);
            return GetEnclosingBinderInternalWithinRoot(node, position);
        }

        /// <summary>
        /// Get all bounds nodes associated with a node, ordered from highest to lowest in the bound tree.
        /// Strictly speaking, the order is that of a pre-order traversal of the bound tree.
        /// </summary>
        internal ImmutableArray<BoundNode> GetBoundNodes(LanguageSyntaxNode node)
        {
            return _boundTree.GetBoundNodes(node);
        }

        // some nodes don't have direct semantic meaning by themselves and so we need to bind a different node that does
        internal protected virtual LanguageSyntaxNode GetBindableSyntaxNode(LanguageSyntaxNode node)
        {
            return (LanguageSyntaxNode)_boundTree.GetBindableSyntaxNode(node).NodeOrParent;
        }

        /// <summary>
        /// If the node is an expression, return the nearest parent node
        /// with semantic meaning. Otherwise return null.
        /// </summary>
        protected LanguageSyntaxNode GetBindableParentNode(LanguageSyntaxNode node)
        {
            return (LanguageSyntaxNode)_boundTree.GetBindableParentNode(node, this.IsSpeculativeSemanticModel).NodeOrParent;
        }

    }
}
