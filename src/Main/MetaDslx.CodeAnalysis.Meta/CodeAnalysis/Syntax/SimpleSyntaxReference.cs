// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// this is a basic do-nothing implementation of a syntax reference
    /// </summary>
    public class SimpleSyntaxReference : SyntaxReference
    {
        private readonly SyntaxNodeOrToken _nodeOrToken;

        public SimpleSyntaxReference(SyntaxNodeOrToken node)
        {
            _nodeOrToken = node;
        }

        public override SyntaxTree SyntaxTree
        {
            get
            {
                return _nodeOrToken.SyntaxTree;
            }
        }

        public override TextSpan Span
        {
            get
            {
                return _nodeOrToken.Span;
            }
        }

        public override SyntaxNode GetSyntax(CancellationToken cancellationToken)
        {
            return _nodeOrToken.NodeOrParent;
        }
    }
}
