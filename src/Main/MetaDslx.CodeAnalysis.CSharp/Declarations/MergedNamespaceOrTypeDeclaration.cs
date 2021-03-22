// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp
{
    internal abstract class MergedNamespaceOrTypeDeclaration : Declaration
    {
        protected MergedNamespaceOrTypeDeclaration(string name)
            : base(name)
        {
        }
    }
}
