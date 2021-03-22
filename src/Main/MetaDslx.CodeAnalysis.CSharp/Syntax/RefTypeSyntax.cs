// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Collections;
using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp.Syntax
{
    public partial class RefTypeSyntax
    {
        public RefTypeSyntax Update(SyntaxToken refKeyword, TypeSyntax type)
        {
            return Update(refKeyword, default(SyntaxToken), type);
        }
    }
}

namespace MetaDslx.CodeAnalysis.CSharp
{
    public partial class SyntaxFactory
    {
        /// <summary>Creates a new RefTypeSyntax instance.</summary>
        public static RefTypeSyntax RefType(SyntaxToken refKeyword, TypeSyntax type)
        {
            return RefType(refKeyword, default(SyntaxToken), type);
        }
    }
}
