// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.CSharp
{
    internal static class SourceDocumentationCommentUtils
    {
        internal static string GetAndCacheDocumentationComment(Symbol symbol, bool expandIncludes, ref string lazyXmlText)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal static ImmutableArray<CSharpSyntaxNode> GetDocumentationCommentTriviaFromSyntaxNode(CSharpSyntaxNode syntaxNode, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }
    }
}
