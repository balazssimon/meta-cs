// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;

namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    public interface ICompilationUnitRootSyntax : ICompilationUnitSyntax
    {
        IList<IDirectiveTriviaSyntax> GetReferenceDirectives();
        IList<IDirectiveTriviaSyntax> GetReferenceDirectives(Func<IDirectiveTriviaSyntax, bool> filter);
        IList<IDirectiveTriviaSyntax> GetLoadDirectives();
        DirectiveStack GetConditionalDirectivesStack();
    }

    public interface IDirectiveTriviaSyntax
    {
        Directive Directive { get; }

        SyntaxTrivia ParentTrivia { get; }
        SyntaxToken EndOfDirectiveToken { get; }
        IEnumerable<IDirectiveTriviaSyntax> GetRelatedDirectives();
    }
}
