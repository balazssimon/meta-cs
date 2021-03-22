// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;

namespace MetaDslx.CodeAnalysis.Syntax
{
    internal partial class SyntaxList
    {
        internal class WithThreeChildren : SyntaxList
        {
            private SyntaxNode _child0;
            private SyntaxNode _child1;
            private SyntaxNode _child2;

            internal WithThreeChildren(InternalSyntax.SyntaxList green, SyntaxNode parent, int position)
                : base(green, parent, position)
            {
            }

            internal override SyntaxNode GetNodeSlot(int index)
            {
                switch (index)
                {
                    case 0:
                        return this.GetRedElement(ref _child0, 0);
                    case 1:
                        return this.GetRedElementIfNotToken(ref _child1);
                    case 2:
                        return this.GetRedElement(ref _child2, 2);
                    default:
                        return null;
                }
            }

            internal override SyntaxNode GetCachedSlot(int index)
            {
                switch (index)
                {
                    case 0:
                        return _child0;
                    case 1:
                        return _child1;
                    case 2:
                        return _child2;
                    default:
                        return null;
                }
            }
        }
    }
}
