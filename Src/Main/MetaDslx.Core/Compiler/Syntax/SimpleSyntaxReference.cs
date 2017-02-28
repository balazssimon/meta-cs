// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    /// <summary>
    /// this is a basic do-nothing implementation of a syntax reference
    /// </summary>
    public class SimpleSyntaxReference : SyntaxReference
    {
        private readonly RedNode _node;

        public SimpleSyntaxReference(RedNode node)
        {
            _node = node;
        }

        public override SyntaxTree SyntaxTree
        {
            get
            {
                return _node.SyntaxTree;
            }
        }

        public override TextSpan Span
        {
            get
            {
                return _node.Span;
            }
        }

        public override RedNode GetSyntax(CancellationToken cancellationToken)
        {
            return _node;
        }
    }

}
