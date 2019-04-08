// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;

namespace MetaDslx.Compiler
{
    internal abstract class CommonSyntaxAndDeclarationManager
    {
        internal readonly ImmutableArray<SyntaxTree> ExternalSyntaxTrees;
        internal readonly string ScriptClassName;
        internal readonly SourceReferenceResolver Resolver;
        internal readonly Compilation Compilation;
        internal readonly bool IsSubmission;

        public CommonSyntaxAndDeclarationManager(
            ImmutableArray<SyntaxTree> externalSyntaxTrees,
            string scriptClassName,
            SourceReferenceResolver resolver,
            Compilation compilation,
            bool isSubmission)
        {
            this.ExternalSyntaxTrees = externalSyntaxTrees;
            this.ScriptClassName = scriptClassName ?? "";
            this.Resolver = resolver;
            this.Compilation = compilation;
            this.IsSubmission = isSubmission;
        }
    }
}
