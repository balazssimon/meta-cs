// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.BoundTree;
using MetaDslx.CodeAnalysis.Operations;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;

    /// <summary>
    /// Binding info for expressions and statements that are part of a member declaration.
    /// </summary>
    internal abstract partial class MemberSemanticModel : LanguageSemanticModel
    {
        private readonly Symbol _memberSymbol;
        private readonly LanguageSyntaxNode _root;
        private readonly DiagnosticBag _ignoredDiagnostics = new DiagnosticBag();
        private readonly ReaderWriterLockSlim _nodeMapLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        // The bound nodes associated with a syntax node, from highest in the tree to lowest.
        private readonly Dictionary<SyntaxNode, ImmutableArray<BoundNode>> _guardedNodeMap = new Dictionary<SyntaxNode, ImmutableArray<BoundNode>>();
        private Dictionary<SyntaxNode, BoundStatement> _lazyGuardedSynthesizedStatementsMap;

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

            _root = root;
            _memberSymbol = memberSymbol;

            this.RootBinder = rootBinder.WithAdditionalFlags(GetSemanticModelBinderFlags());
            _containingSemanticModelOpt = containingSemanticModelOpt;
            _parentSemanticModelOpt = parentSemanticModelOpt;
            _speculatedPosition = speculatedPosition;

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
                return _root;
            }
        }

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
            return GetEnclosingBinderInternalWithinRoot(node, position, RootBinder, _root).WithAdditionalFlags(GetSemanticModelBinderFlags());
        }

        private static Binder GetEnclosingBinderInternalWithinRoot(SyntaxNode node, int position, Binder rootBinder, SyntaxNode root)
        {
            if (node == root)
            {
                return rootBinder.GetBinder(node) ?? rootBinder;
            }

            Debug.Assert(root.Contains(node));

            Binder binder = null;
            for (var current = node; binder == null; current = current.ParentOrStructuredTriviaParent)
            {
                Debug.Assert(current != null); // Why were we asked for an enclosing binder for a node outside our root?
                binder = rootBinder.GetBinder(current);
                if (current == root)
                {
                    break;
                }
            }

            binder = binder ?? rootBinder.GetBinder(root) ?? rootBinder;
            Debug.Assert(binder != null);

            return binder;
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
            var boundExpression = this.GetLowerBoundNode(bindableNode) as BoundExpression;
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
            var boundExpression = this.GetLowerBoundNode(bindableNode) as BoundExpression;
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
            return GetUpperBoundNode(GetBindableSyntaxNode(this.Root));
        }

        /// <summary>
        /// Get the highest bound node in the tree associated with a particular syntax node.
        /// </summary>
        internal BoundNode GetUpperBoundNode(LanguageSyntaxNode node, bool promoteToBindable = false)
        {
            if (promoteToBindable)
            {
                node = GetBindableSyntaxNode(node);
            }
            else
            {
                Debug.Assert(node == GetBindableSyntaxNode(node));
            }

            // The bound nodes are stored in the map from highest to lowest, so the first bound node is the highest.
            var boundNodes = GetBoundNodes(node);

            if (boundNodes.Length == 0)
            {
                return null;
            }
            else
            {
                return boundNodes[0];
            }
        }

        /// <summary>
        /// Get the lowest bound node in the tree associated with a particular syntax node. Lowest is defined as last
        /// in a pre-order traversal of the bound tree.
        /// </summary>
        internal BoundNode GetLowerBoundNode(LanguageSyntaxNode node)
        {
            Debug.Assert(node == GetBindableSyntaxNode(node));

            // The bound nodes are stored in the map from highest to lowest, so the last bound node is the lowest.
            var boundNodes = GetBoundNodes(node);

            if (boundNodes.Length == 0)
            {
                return null;
            }
            else
            {
                return GetLowerBoundNode(boundNodes);
            }
        }

        private static BoundNode GetLowerBoundNode(ImmutableArray<BoundNode> boundNodes)
        {
            return boundNodes[boundNodes.Length - 1];
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

        public override ISymbol GetDeclaredSymbol(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Can't defined namespace inside a member.
            return null;
        }

        public override ImmutableArray<ISymbol> GetDeclaredSymbols(LanguageSyntaxNode declarationSyntax, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Can't define field inside member.
            return ImmutableArray.Create<ISymbol>();
        }

        public override SyntaxTree SyntaxTree
        {
            get
            {
                return _root.SyntaxTree;
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

            BoundNode highestBoundNode;
            GetBoundNodes(node, out _, out _, out highestBoundNode, out _);

            // decide whether we should use highest or lowest bound node here 
            // https://github.com/dotnet/roslyn/issues/22179
            BoundNode result = highestBoundNode;
            return _operationFactory.Value.Create(result);
        }

        internal override SymbolInfo GetSymbolInfoWorker(LanguageSyntaxNode node, SymbolInfoOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            ValidateSymbolInfoOptions(options);

            LanguageSyntaxNode bindableNode;
            BoundNode lowestBoundNode;
            BoundNode highestBoundNode;
            BoundNode boundParent;
            GetBoundNodes(node, out bindableNode, out lowestBoundNode, out highestBoundNode, out boundParent);

            Debug.Assert(IsInTree(node), "Since the node is in the tree, we can always recompute the binder later");
            return base.GetSymbolInfoForNode(options, lowestBoundNode, highestBoundNode, boundParent, binderOpt: null);
        }

        internal override LanguageTypeInfo GetTypeInfoWorker(LanguageSyntaxNode node, CancellationToken cancellationToken = default(CancellationToken))
        {
            LanguageSyntaxNode bindableNode;
            BoundNode lowestBoundNode;
            BoundNode highestBoundNode;
            BoundNode boundParent;
            GetBoundNodes(node, out bindableNode, out lowestBoundNode, out highestBoundNode, out boundParent);

            return GetTypeInfoForNode(lowestBoundNode, highestBoundNode, boundParent);
        }

        internal override ImmutableArray<Symbol> GetMemberGroupWorker(LanguageSyntaxNode node, SymbolInfoOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            LanguageSyntaxNode bindableNode;
            BoundNode lowestBoundNode;
            BoundNode highestBoundNode;
            BoundNode boundParent;
            GetBoundNodes(node, out bindableNode, out lowestBoundNode, out highestBoundNode, out boundParent);

            Debug.Assert(IsInTree(node), "Since the node is in the tree, we can always recompute the binder later");
            return base.GetMemberGroupForNode(options, lowestBoundNode, boundParent, binderOpt: null);
        }

        internal override Optional<object> GetConstantValueWorker(LanguageSyntaxNode node, CancellationToken cancellationToken)
        {
            LanguageSyntaxNode bindableNode = this.GetBindableSyntaxNode(node);
            BoundExpression boundExpr = this.GetLowerBoundNode(bindableNode) as BoundExpression;

            if (boundExpr == null) return default(Optional<object>);

            ConstantValue constantValue = boundExpr.ConstantValue;
            return constantValue == null || constantValue.IsBad
                ? default(Optional<object>)
                : new Optional<object>(constantValue.Value);
        }

        private void GetBoundNodes(LanguageSyntaxNode node, out LanguageSyntaxNode bindableNode, out BoundNode lowestBoundNode, out BoundNode highestBoundNode, out BoundNode boundParent)
        {
            bindableNode = this.GetBindableSyntaxNode(node);

            LanguageSyntaxNode bindableParent = this.GetBindableParentNode(bindableNode);

            // Special handling for the Color Color case.
            //
            // Suppose we have:
            // public class Color {
            //   public void M(int x) {}
            //   public static void M(params int[] x) {}
            // }
            // public class C {
            //   public void Test() {
            //     Color Color = new Color();
            //     System.Action<int> d = Color.M;
            //   }
            // }
            //
            // We actually don't know how to interpret the "Color" in "Color.M" until we
            // perform overload resolution on the method group.  Now, if we were getting
            // the semantic info for the method group, then bindableParent would be the
            // variable declarator "d = Color.M" and so we would be able to pull the result
            // of overload resolution out of the bound (method group) conversion.  However,
            // if we are getting the semantic info for just the "Color" part, then
            // bindableParent will be the member access, which doesn't have enough information
            // to determine which "Color" to use (since no overload resolution has been
            // performed).  We resolve this problem by detecting the case where we're looking
            // up the LHS of a member access and calling GetBindableParentNode one more time.
            // This gets us up to the level where the method group conversion occurs.
            /* TODO:MetaDslx
            if (bindableParent != null && bindableParent.Kind() == SyntaxKind.SimpleMemberAccessExpression && ((MemberAccessExpressionSyntax)bindableParent).Expression == bindableNode)
            {
                bindableParent = this.GetBindableParentNode(bindableParent);
            }*/

            boundParent = bindableParent == null ? null : this.GetLowerBoundNode(bindableParent);

            lowestBoundNode = this.GetLowerBoundNode(bindableNode);
            highestBoundNode = this.GetUpperBoundNode(bindableNode);
        }

        private void GuardedAddSynthesizedStatementToMap(LanguageSyntaxNode node, BoundStatement statement)
        {
            if (_lazyGuardedSynthesizedStatementsMap == null)
            {
                _lazyGuardedSynthesizedStatementsMap = new Dictionary<SyntaxNode, BoundStatement>();
            }

            _lazyGuardedSynthesizedStatementsMap.Add(node, statement);
        }

        private BoundStatement GuardedGetSynthesizedStatementFromMap(LanguageSyntaxNode node)
        {
            if (_lazyGuardedSynthesizedStatementsMap != null &&
                _lazyGuardedSynthesizedStatementsMap.TryGetValue(node, out BoundStatement result))
            {
                return result;
            }

            return null;
        }

        private ImmutableArray<BoundNode> GuardedGetBoundNodesFromMap(LanguageSyntaxNode node)
        {
            Debug.Assert(_nodeMapLock.IsWriteLockHeld || _nodeMapLock.IsReadLockHeld);
            ImmutableArray<BoundNode> result;
            return _guardedNodeMap.TryGetValue(node, out result) ? result : default(ImmutableArray<BoundNode>);
        }

        /// <summary>
        /// Internal for test purposes only
        /// </summary>
        internal ImmutableArray<BoundNode> TestOnlyTryGetBoundNodesFromMap(LanguageSyntaxNode node)
        {
            ImmutableArray<BoundNode> result;
            return _guardedNodeMap.TryGetValue(node, out result) ? result : default(ImmutableArray<BoundNode>);
        }

        // Adds every syntax/bound pair in a tree rooted at the given bound node to the map, and the
        // performs a lookup of the given syntax node in the map. 
        private ImmutableArray<BoundNode> GuardedAddBoundTreeAndGetBoundNodeFromMap(LanguageSyntaxNode syntax, BoundNode bound)
        {
            Debug.Assert(_nodeMapLock.IsWriteLockHeld);

            bool alreadyInTree = false;

            if (bound != null)
            {
                alreadyInTree = _guardedNodeMap.ContainsKey(bound.Syntax);
            }

            // check if we already have node in the cache.
            // this may happen if we have races and in such case we are no longer interested in adding
            if (!alreadyInTree)
            {
                NodeMapBuilder.AddToMap(bound, _guardedNodeMap);
            }

            ImmutableArray<BoundNode> result;
            return _guardedNodeMap.TryGetValue(syntax, out result) ? result : default(ImmutableArray<BoundNode>);
        }

        protected void UnguardedAddBoundTreeForStandaloneSyntax(SyntaxNode syntax, BoundNode bound)
        {
            using (_nodeMapLock.DisposableWrite())
            {
                GuardedAddBoundTreeForStandaloneSyntax(syntax, bound);
            }
        }

        protected void GuardedAddBoundTreeForStandaloneSyntax(SyntaxNode syntax, BoundNode bound)
        {
            Debug.Assert(_nodeMapLock.IsWriteLockHeld);
            bool alreadyInTree = false;

            // check if we already have node in the cache.
            // this may happen if we have races and in such case we are no longer interested in adding
            if (bound != null)
            {
                alreadyInTree = _guardedNodeMap.ContainsKey(bound.Syntax);
            }

            if (!alreadyInTree)
            {
                if (syntax == _root || SyntaxFacts.IsStatement(syntax))
                {
                    // Note: For speculative model we want to always cache the entire bound tree.
                    // If syntax is a statement, we need to add all its children.
                    // Node cache assumes that if statement is cached, then all 
                    // its children are cached too.
                    NodeMapBuilder.AddToMap(bound, _guardedNodeMap);
                }
                else
                {
                    // expressions can be added individually.
                    NodeMapBuilder.AddToMap(bound, _guardedNodeMap, syntax);
                }
            }
        }

        // We might not have actually been given a bindable expression or statement; the caller can
        // give us variable declaration nodes, for example. If we're not at an expression or
        // statement, back up until we find one.
        private LanguageSyntaxNode GetBindingRoot(LanguageSyntaxNode node)
        {
            Debug.Assert(node != null);

#if DEBUG
            for (LanguageSyntaxNode current = node; current != this.Root; current = current.ParentOrStructuredTriviaParent)
            {
                // make sure we never go out of Root
                Debug.Assert(current != null, "How did we get outside the root?");
            }
#endif

            for (LanguageSyntaxNode current = node; current != this.Root; current = current.ParentOrStructuredTriviaParent)
            {
                if (SyntaxFacts.IsStatement(current))
                {
                    return current;
                }
            }

            return this.Root;
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
            // If this method is called with a null parameter, that implies that the Root should be
            // bound, but make sure that the Root is bindable.
            if (node == null)
            {
                node = GetBindableSyntaxNode(Root);
            }
            Debug.Assert(node == GetBindableSyntaxNode(node));

            // We have one SemanticModel for each method.
            //
            // The SemanticModel contains a lazily-built immutable map from scope-introducing 
            // syntactic statements (such as blocks) to binders, but not from lambdas to binders.
            //
            // The SemanticModel also contains a mutable map from syntax to bound nodes; that is 
            // declared here. Since the map is not thread-safe we ensure that it is guarded with a
            // reader-writer lock.
            //
            // Have we already got the desired bound node in the mutable map? If so, return it.
            ImmutableArray<BoundNode> results;

            using (_nodeMapLock.DisposableRead())
            {
                results = GuardedGetBoundNodesFromMap(node);
            }

            if (!results.IsDefaultOrEmpty)
            {
                return results;
            }

            // We might not actually have been given an expression or statement even though we were
            // allegedly given something that is "bindable".

            // If we didn't find in the cached bound nodes, find a binding root and bind it.
            // This will cache bound nodes under the binding root.
            LanguageSyntaxNode nodeToBind = GetBindingRoot(node);
            var statementBinder = GetEnclosingBinder(GetAdjustedNodePosition(nodeToBind));
            Binder incrementalBinder = new IncrementalBinder(this, statementBinder);

            using (_nodeMapLock.DisposableWrite())
            {
                BoundNode boundStatement = this.Bind(incrementalBinder, nodeToBind, _ignoredDiagnostics);
                results = GuardedAddBoundTreeAndGetBoundNodeFromMap(node, boundStatement);
            }

            if (!results.IsDefaultOrEmpty)
            {
                return results;
            }

            // If we still didn't find it, its still possible we could bind it directly.
            // For example, types are usually not represented by bound nodes, and some error conditions and
            // not yet implemented features do not create bound nodes for everything underneath them.
            //
            // In this case, however, we only add the single bound node we found to the map, not any child bound nodes,
            // to avoid duplicates in the map if a parent of this node comes through this code path also.

            var binder = GetEnclosingBinder(GetAdjustedNodePosition(node));

            using (_nodeMapLock.DisposableRead())
            {
                results = GuardedGetBoundNodesFromMap(node);
            }

            if (results.IsDefaultOrEmpty)
            {
                using (_nodeMapLock.DisposableWrite())
                {
                    var boundNode = this.Bind(binder, node, _ignoredDiagnostics);
                    GuardedAddBoundTreeForStandaloneSyntax(node, boundNode);
                    results = GuardedGetBoundNodesFromMap(node);
                }

                if (!results.IsDefaultOrEmpty)
                {
                    return results;
                }
            }
            else
            {
                return results;
            }

            return ImmutableArray<BoundNode>.Empty;
        }

        // some nodes don't have direct semantic meaning by themselves and so we need to bind a different node that does
        internal protected virtual LanguageSyntaxNode GetBindableSyntaxNode(LanguageSyntaxNode node)
        {
            return node;
        }

        /// <summary>
        /// If the node is an expression, return the nearest parent node
        /// with semantic meaning. Otherwise return null.
        /// </summary>
        protected LanguageSyntaxNode GetBindableParentNode(LanguageSyntaxNode node)
        {
            if (!SyntaxFacts.IsExpression(node))
            {
                return null;
            }

            // The node is an expression, but its parent is null
            LanguageSyntaxNode parent = node.Parent;
            if (parent == null)
            {
                // For speculative model, expression might be the root of the syntax tree, in which case it can have a null parent.
                if (this.IsSpeculativeSemanticModel && this.Root == node)
                {
                    return null;
                }

                throw new ArgumentException($"The parent of {nameof(node)} must not be null unless this is a speculative semantic model.", nameof(node));
            }

            var bindableParent = this.GetBindableSyntaxNode(parent);
            Debug.Assert(bindableParent != null);
            return bindableParent;
        }

        /// <summary>
        /// The incremental binder is used when binding statements. Whenever a statement
        /// is bound, it checks the bound node cache to see if that statement was bound, 
        /// and returns it instead of rebinding it. 
        /// 
        /// For example, we might have:
        ///    while (x > goo())
        ///    {
        ///      y = y * x;
        ///      z = z + y;
        ///    }
        /// 
        /// We might first get semantic info about "z", and thus bind just the statement
        /// "z = z + y". Later, we might bind the entire While block. While binding the while
        /// block, we can reuse the binding we did of "z = z + y".
        /// </summary>
        /// <remarks>
        /// NOTE: any member overridden by this binder should follow the BuckStopsHereBinder pattern.
        /// Otherwise, a subsequent binder in the chain could suppress the caching behavior.
        /// </remarks>
        public class IncrementalBinder : Binder
        {
            private readonly MemberSemanticModel _semanticModel;

            public IncrementalBinder(MemberSemanticModel semanticModel, Binder next)
                : base(next)
            {
                _semanticModel = semanticModel;
            }

            /// <summary>
            /// We override GetBinder so that the BindStatement override is still
            /// in effect on nested binders.
            /// </summary>
            public override Binder GetBinder(SyntaxNode node)
            {
                Binder binder = this.Next.GetBinder(node);

                if (binder != null)
                {
                    Debug.Assert(!(binder is IncrementalBinder));
                    return new IncrementalBinder(_semanticModel, binder.WithAdditionalFlags(BinderFlags.SemanticModel));
                }

                return null;
            }

            public override BoundStatement BindStatement(LanguageSyntaxNode node, DiagnosticBag diagnostics)
            {
                // Check the bound node cache to see if the statement was already bound.
                BoundStatement synthesizedStatement = _semanticModel.GuardedGetSynthesizedStatementFromMap(node);

                if (synthesizedStatement != null)
                {
                    return synthesizedStatement;
                }

                BoundNode boundNode = TryGetBoundNodeFromMap(node);

                if (boundNode == null)
                {
                    // Not bound already. Bind it. It will get added to the cache later by a MemberSemanticModel.NodeMapBuilder.
                    var statement = base.BindStatement(node, diagnostics);

                    // Synthesized statements are not added to the _guardedNodeMap, we cache them explicitly here in  
                    // _lazyGuardedSynthesizedStatementsMap
                    if (statement.WasCompilerGenerated)
                    {
                        _semanticModel.GuardedAddSynthesizedStatementToMap(node, statement);
                    }

                    return statement;
                }

                return (BoundStatement)boundNode;
            }

            private BoundNode TryGetBoundNodeFromMap(LanguageSyntaxNode node)
            {
                ImmutableArray<BoundNode> boundNodes = _semanticModel.GuardedGetBoundNodesFromMap(node);

                if (!boundNodes.IsDefaultOrEmpty)
                {
                    // Already bound. Return the top-most bound node associated with the statement. 
                    return boundNodes[0];
                }

                return null;
            }

            public override BoundNode Bind(LanguageSyntaxNode node, DiagnosticBag diagnostics)
            {
                return TryGetBoundNodeFromMap(node) ?? base.Bind(node, diagnostics);
            }
        }
    }
}
