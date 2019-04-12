// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    public abstract class CompilationUnitSyntax : CSharpSyntaxNode, ICompilationUnitSyntax
    {
        public SyntaxToken EndOfFileToken => throw new NotImplementedException();

        internal CompilationUnitSyntax(GreenNode green, SyntaxNode parent, int position) : base(green, parent, position)
        {
        }

        internal CompilationUnitSyntax(GreenNode green, int position, SyntaxTree syntaxTree) : base(green, position, syntaxTree)
        {
        }

    }
}
