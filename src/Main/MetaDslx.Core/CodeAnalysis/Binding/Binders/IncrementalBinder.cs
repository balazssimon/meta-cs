using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
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
        private readonly BoundTree _boundTree;

        public IncrementalBinder(BoundTree boundTree, Binder next)
            : base(next, null)
        {
            _boundTree = boundTree;
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
                return new IncrementalBinder(_boundTree, binder.WithAdditionalFlags(BinderFlags.SemanticModel));
            }

            return null;
        }

        public override BoundNode Bind(LanguageSyntaxNode node)
        {
            // Check the bound node cache to see if the statement was already bound.
            BoundNode synthesizedNode = _boundTree.GuardedGetSynthesizedNodeFromMap(node);

            if (synthesizedNode != null)
            {
                return synthesizedNode;
            }

            BoundNode boundNode = TryGetBoundNodeFromMap(node);

            if (boundNode == null)
            {
                // Not bound yet. Bind it. It will get added to the cache later by a BoundNodeMapBuilder.
                boundNode = base.Bind(node);

                // Synthesized statements are not added to the _guardedNodeMap, we cache them explicitly here in  
                // _lazyGuardedSynthesizedStatementsMap
                if (boundNode.WasCompilerGenerated)
                {
                    _boundTree.GuardedAddSynthesizedNodeToMap(node, boundNode);
                }
            }

            return boundNode;
        }

        private BoundNode TryGetBoundNodeFromMap(LanguageSyntaxNode node)
        {
            ImmutableArray<BoundNode> boundNodes = _boundTree.GuardedGetBoundNodesFromMap(node);

            if (!boundNodes.IsDefaultOrEmpty)
            {
                // Already bound. Return the top-most bound node associated with the statement. 
                return boundNodes[0];
            }

            return null;
        }
    }

}
