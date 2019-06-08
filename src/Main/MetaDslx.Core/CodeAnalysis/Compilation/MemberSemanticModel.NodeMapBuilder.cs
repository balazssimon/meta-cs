// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.BoundTree;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis
{
    internal partial class MemberSemanticModel
    {
        protected sealed class NodeMapBuilder : BoundTreeWalkerWithStackGuard
        {
            private NodeMapBuilder(OrderPreservingMultiDictionary<SyntaxNode, BoundNode> map, SyntaxNode thisSyntaxNodeOnly)
            {
                _map = map;
                _thisSyntaxNodeOnly = thisSyntaxNodeOnly;
            }

            private readonly OrderPreservingMultiDictionary<SyntaxNode, BoundNode> _map;
            private readonly SyntaxNode _thisSyntaxNodeOnly;

            /// <summary>
            /// Walks the bound tree and adds all non compiler generated bound nodes whose syntax matches the given one
            /// to the cache.
            /// </summary>
            /// <param name="root">The root of the bound tree.</param>
            /// <param name="map">The cache.</param>
            /// <param name="node">The syntax node where to add bound nodes for.</param>
            public static void AddToMap(BoundNode root, Dictionary<SyntaxNode, ImmutableArray<BoundNode>> map, SyntaxNode node = null)
            {
                Debug.Assert(node == null || root == null || !root.Syntax.IsStatement(), "individually added nodes are not supposed to be statements.");

                if (root == null || map.ContainsKey(root.Syntax))
                {
                    // root node is already in the map, children must be in the map too.
                    return;
                }

                var additionMap = OrderPreservingMultiDictionary<SyntaxNode, BoundNode>.GetInstance();
                var builder = new NodeMapBuilder(additionMap, node);
                builder.Visit(root);

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
                        for (int i = 0; i < existing.Length; i++)
                        {
                            // TODO: it would be great if we could check !ReferenceEquals(existing[i], added[i]) (DevDiv #11584).
                            // Known impediments include:
                            //   1) Field initializers aren't cached because they're not in statements.
                            //   2) Single local declarations (e.g. "int x = 1;" vs "int x = 1, y = 2;") aren't found in the cache
                            //      since nothing is cached for the statement syntax.
                            if (existing[i].Kind != added[i].Kind)
                            {
                                Debug.Assert(!key.IsStatement(), "!key.IsStatement()");
                                Debug.Assert(false, "New bound node does not match existing bound node");
                            }
                            else
                            {
                                Debug.Assert(
                                    (object)existing[i] == added[i] || !key.IsStatement(),
                                    string.Format(
                                        System.Globalization.CultureInfo.InvariantCulture,
                                        "(object)existing[{0}] == added[{0}] || !key.IsStatement()", i));
                            }
                        }
#endif
                    }
                    else
                    {
                        map[key] = additionMap[key];
                    }
                }

                additionMap.Free();
            }

            public override BoundNode Visit(BoundNode node)
            {
                if (node == null)
                {
                    return null;
                }

                BoundNode current = node;

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
                if (ShouldAddNode(current))
                {
                    _map.Add(current.Syntax, current);
                }

                base.Visit(current);

                return null;
            }

            /// <summary>
            /// Decides whether to the add the bound node to the cache or not.
            /// </summary>
            /// <param name="currentBoundNode">The bound node.</param>
            private bool ShouldAddNode(BoundNode currentBoundNode)
            {
                // Do not add compiler generated nodes.
                if (currentBoundNode.WasCompilerGenerated)
                {
                    return false;
                }

                // Do not add if only a specific syntax node should be added.
                if (_thisSyntaxNodeOnly != null && currentBoundNode.Syntax != _thisSyntaxNodeOnly)
                {
                    return false;
                }

                return true;
            }

            protected override bool ConvertInsufficientExecutionStackExceptionToCancelledByStackGuardException()
            {
                return false;
            }
        }
    }
}
