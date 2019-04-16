// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using CoreInternalSyntax = Microsoft.CodeAnalysis.Syntax.InternalSyntax;

namespace Microsoft.CodeAnalysis.CSharp
{
    internal sealed class DeclarationTreeBuilder : CSharpSyntaxVisitor<SingleNamespaceOrTypeDeclaration>
    {
        private readonly SyntaxTree _syntaxTree;
        private readonly string _scriptClassName;
        private readonly bool _isSubmission;

        private DeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            _syntaxTree = syntaxTree;
            _scriptClassName = scriptClassName;
            _isSubmission = isSubmission;
        }

        public static RootSingleNamespaceDeclaration ForTree(
            SyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new DeclarationTreeBuilder(syntaxTree, scriptClassName, isSubmission);
            return (RootSingleNamespaceDeclaration)builder.Visit(syntaxTree.GetRoot());
        }

    }
}
