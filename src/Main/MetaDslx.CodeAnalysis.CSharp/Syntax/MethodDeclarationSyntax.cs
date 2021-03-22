// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp.Syntax
{
    public partial class MethodDeclarationSyntax
    {
        public int Arity
        {
            get
            {
                return this.TypeParameterList == null ? 0 : this.TypeParameterList.Parameters.Count;
            }
        }
    }
}

namespace MetaDslx.CodeAnalysis.CSharp
{
    public partial class SyntaxFactory
    {
        public static MethodDeclarationSyntax MethodDeclaration(
            SyntaxList<AttributeListSyntax> attributeLists,
            SyntaxTokenList modifiers,
            TypeSyntax returnType,
            ExplicitInterfaceSpecifierSyntax explicitInterfaceSpecifier,
            SyntaxToken identifier,
            TypeParameterListSyntax typeParameterList,
            ParameterListSyntax parameterList,
            SyntaxList<TypeParameterConstraintClauseSyntax> constraintClauses,
            BlockSyntax body,
            SyntaxToken semicolonToken)
        {
            return SyntaxFactory.MethodDeclaration(attributeLists, modifiers, returnType, explicitInterfaceSpecifier, identifier, typeParameterList, parameterList, constraintClauses, body, null, default(SyntaxToken));
        }
    }
}
