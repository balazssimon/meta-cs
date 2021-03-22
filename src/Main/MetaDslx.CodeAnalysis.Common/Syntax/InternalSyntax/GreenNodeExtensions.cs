// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public static class GreenNodeExtensions
    {
        public static SyntaxList<T> ToGreenList<T>(this SyntaxNode node) where T : GreenNode
        {
            return node != null ?
                ToGreenList<T>(node.Green) :
                default(SyntaxList<T>);
        }

        public static SeparatedSyntaxList<T> ToGreenSeparatedList<T>(this SyntaxNode node) where T : GreenNode
        {
            return node != null ?
                new SeparatedSyntaxList<T>(ToGreenList<T>(node.Green)) :
                default(SeparatedSyntaxList<T>);
        }

        public static SyntaxList<T> ToGreenList<T>(this GreenNode node) where T : GreenNode
        {
            return new SyntaxList<T>(node);
        }
    }
}
