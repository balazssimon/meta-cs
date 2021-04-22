// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.CodeAnalysis.Syntax.InternalSyntax
{
    public static class GreenNodeExtensions
    {
        public static SyntaxList<T> ToGreenList<T>(this SyntaxNode? node) where T : GreenNode
        {
            return node != null ?
                ToGreenList<T>(node.Green) :
                default(SyntaxList<T>);
        }

        public static SeparatedSyntaxList<T> ToGreenSeparatedList<T>(this SyntaxNode? node) where T : GreenNode
        {
            return node != null ?
                new SeparatedSyntaxList<T>(ToGreenList<T>(node.Green)) :
                default(SeparatedSyntaxList<T>);
        }

        public static SyntaxList<T> ToGreenList<T>(this GreenNode? node) where T : GreenNode
        {
            return new SyntaxList<T>(node);
        }
    }
}
