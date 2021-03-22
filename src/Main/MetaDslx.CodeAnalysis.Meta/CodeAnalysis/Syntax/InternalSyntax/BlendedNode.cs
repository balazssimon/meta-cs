// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public readonly struct BlendedNode
    {
        public readonly LanguageSyntaxNode Node;
        public readonly InternalSyntaxToken Token;
        public readonly object CustomToken;
        internal readonly Blender Blender;

        internal BlendedNode(LanguageSyntaxNode node, InternalSyntaxToken token, object customToken, Blender blender)
        {
            this.Node = node;
            this.Token = token;
            this.CustomToken = customToken;
            this.Blender = blender;
        }
    }
}
