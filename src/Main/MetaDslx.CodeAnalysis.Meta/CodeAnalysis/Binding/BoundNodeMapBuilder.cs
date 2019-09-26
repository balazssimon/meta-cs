using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public sealed class BoundNodeMapBuilder
    {
        /// <summary>
        /// Walks the bound tree and adds all non compiler generated bound nodes whose syntax matches the given one
        /// to the cache.
        /// </summary>
        /// <param name="root">The root of the bound tree.</param>
        /// <param name="map">The cache.</param>
        /// <param name="node">The syntax node where to add bound nodes for.</param>
        public static void AddToMap(BoundNode root, ConcurrentDictionary<SyntaxNode, ImmutableArray<BoundNode>> map, SyntaxNode node = null)
        {
            //Debug.Assert(node == null || root == null);

            if (root == null || map.ContainsKey(root.Syntax))
            {
                // root node is already in the map, children must be in the map too.
                return;
            }

            var additionMap = OrderPreservingMultiDictionary<SyntaxNode, BoundNode>.GetInstance();
            CacheSubTree(additionMap, node, root);

            foreach (LanguageSyntaxNode key in additionMap.Keys)
            {
                if (map.ContainsKey(key))
                {
#if DEBUG
                    // It's possible that AddToMap was previously called with a subtree of root.  If this is the case,
                    // then we'll see an entry in the map.  Since the incremental binder should also have seen the
                    // pre-existing map entry, the entry in addition map should be identical.
                    // Another, more unfortunate, possibility is that we've had to re-bind the syntax and the new bound
                    // nodes are equivalent, but not identical, to the existing ones.  In such cases, we prefer the
                    // existing nodes so that the cache will always return the same bound node for a given syntax node.

                    // EXAMPLE: Suppose we have the statement P.M(1);
                    // First, we ask for semantic info about "P".  We'll walk up to the statement level and bind that.
                    // We'll end up with map entries for "1", "P", "P.M(1)", and "P.M(1);".
                    // Next, we ask for semantic info about "P.M".  That isn't in our map, so we walk up to the statement
                    // level - again - and bind that - again.
                    // Once again, we'll end up with map entries for "1", "P", "P.M(1)", and "P.M(1);".  They will
                    // have the same structure as the original map entries, but will not be ReferenceEquals.

                    var existing = map[key];
                    var added = additionMap[key];
                    Debug.Assert(existing.Length == added.Length, "existing.Length == added.Length");
                    /*for (int i = 0; i < existing.Length; i++)
                    {
                        Debug.Assert((object)existing[i] == added[i], string.Format("(object)existing[{0}] == added[{0}]", i));
                    }*/
#endif
                }
                else
                {
                    map[key] = additionMap[key];
                }
            }

            additionMap.Free();
        }

        private static void CacheSubTree(OrderPreservingMultiDictionary<SyntaxNode, BoundNode> map, SyntaxNode thisSyntaxNodeOnly, BoundNode node)
        {
            if (node == null) return;
            Stack<BoundNode> nodeStack = new Stack<BoundNode>();
            nodeStack.Push(node);
            while (nodeStack.Count > 0)
            {
                BoundNode current = nodeStack.Pop();
                AddNode(map, thisSyntaxNodeOnly, current);
                var currentChildren = current.GetChildBoundNodes(thisSyntaxNodeOnly);
                for (int i = currentChildren.Length - 1; i >= 0; --i)
                {
                    nodeStack.Push(currentChildren[i]);
                }
            }
        }

        private static void AddNode(OrderPreservingMultiDictionary<SyntaxNode, BoundNode> map, SyntaxNode thisSyntaxNodeOnly, BoundNode node)
        {
            if (node == null) return;

            // It is possible for there to be multiple bound nodes with the same syntax tree,
            // and that is by design. For example, in
            //
            // byte b = 3;
            //
            // there is a bound node for the implicit conversion to byte and a bound node for the 
            // literal, an int. Sometimes we want the inner one (to state the type of the expression)
            // and sometimes we want the "parent's" view of things (for extract method, for instance.)
            //
            // We want to add all bound nodes associated with the same syntax node to the cache, so we first add the 
            // bound node, then we dive deeper into the bound tree.
            if (ShouldAddNode(node, thisSyntaxNodeOnly))
            {
                map.Add(node.Syntax, node);
            }
        }

        /// <summary>
        /// Decides whether to the add the bound node to the cache or not.
        /// </summary>
        /// <param name="currentBoundNode">The bound node.</param>
        private static bool ShouldAddNode(BoundNode currentBoundNode, SyntaxNode thisSyntaxNodeOnly)
        {
            // Do not add compiler generated nodes.
            /* TODO:MetaDslx - enable this condition?
            if (currentBoundNode.WasCompilerGenerated)
            {
                return false;
            }*/

            // Do not add if only a specific syntax node should be added.
            if (thisSyntaxNodeOnly != null && currentBoundNode.Syntax != thisSyntaxNodeOnly)
            {
                return false;
            }

            return true;
        }

    }

}
