// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Syntax;

namespace MetaDslx.CodeAnalysis.CSharp.Syntax
{
    public partial class UsingStatementSyntax
    {
        public UsingStatementSyntax Update(SyntaxToken usingKeyword, SyntaxToken openParenToken, VariableDeclarationSyntax declaration, ExpressionSyntax expression, SyntaxToken closeParenToken, StatementSyntax statement)
        {
            return Update(awaitKeyword: default, usingKeyword, openParenToken, declaration, expression, closeParenToken, statement);
        }

    }
}

namespace MetaDslx.CodeAnalysis.CSharp
{
    public partial class SyntaxFactory
    {
        public static UsingStatementSyntax UsingStatement(SyntaxToken usingKeyword, SyntaxToken openParenToken, VariableDeclarationSyntax declaration, ExpressionSyntax expression, SyntaxToken closeParenToken, StatementSyntax statement)
        {
            return UsingStatement(awaitKeyword: default, usingKeyword, openParenToken, declaration, expression, closeParenToken, statement);
        }
    }
}
