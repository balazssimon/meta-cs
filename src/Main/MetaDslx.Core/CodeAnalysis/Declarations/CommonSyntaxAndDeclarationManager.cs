// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis.Declarations
{
    internal abstract class CommonSyntaxAndDeclarationManager
    {
        internal readonly ImmutableArray<LanguageSyntaxTree> ExternalSyntaxTrees;
        internal readonly string ScriptClassName;
        internal readonly SourceReferenceResolver Resolver;
        internal readonly LanguageCompilation Compilation;
        internal readonly bool IsSubmission;

        public CommonSyntaxAndDeclarationManager(
            ImmutableArray<LanguageSyntaxTree> externalSyntaxTrees,
            string scriptClassName,
            SourceReferenceResolver resolver,
            LanguageCompilation compilation,
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
