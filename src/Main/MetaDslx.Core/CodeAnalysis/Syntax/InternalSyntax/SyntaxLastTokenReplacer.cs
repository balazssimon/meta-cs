// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    internal class SyntaxLastTokenReplacer : InternalSyntaxRewriter
    {
        private readonly InternalSyntaxToken _oldToken;
        private readonly InternalSyntaxToken _newToken;
        private int _count = 1;
        private bool _found;

        private SyntaxLastTokenReplacer(InternalSyntaxToken oldToken, InternalSyntaxToken newToken)
        {
            _oldToken = oldToken;
            _newToken = newToken;
        }

        internal static TRoot Replace<TRoot>(TRoot root, InternalSyntaxToken newToken)
            where TRoot : InternalSyntaxNode
        {
            var oldToken = root.GetLastToken();
            var replacer = new SyntaxLastTokenReplacer(oldToken, newToken);
            var newRoot = (TRoot)replacer.Visit(root);
            Debug.Assert(replacer._found);
            return newRoot;
        }

        private static int CountNonNullSlots(InternalSyntaxNode node)
        {
            return node.ChildNodesAndTokens().Count;
        }

        public override InternalSyntaxNode Visit(InternalSyntaxNode node)
        {
            if (node != null && !_found)
            {
                _count--;
                if (_count == 0)
                {
                    var token = node as InternalSyntaxToken;
                    if (token != null)
                    {
                        Debug.Assert(token == _oldToken);
                        _found = true;
                        return _newToken;
                    }

                    _count += CountNonNullSlots(node);
                    return base.Visit(node);
                }
            }

            return node;
        }
    }
}
