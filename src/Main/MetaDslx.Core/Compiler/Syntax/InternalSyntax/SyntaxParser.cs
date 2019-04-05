// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.PooledObjects;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    internal abstract partial class SyntaxParser : IDisposable
    {
        protected readonly SourceText text;
        protected readonly Language language;
        protected readonly ParseOptions options;
        protected readonly CancellationToken cancellationToken;
        protected readonly InternalSyntaxFactory factory;

        protected SyntaxParser(
            SourceText text,
            Language language,
            ParseOptions options,
            SyntaxNode oldTree,
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            this.text = text;
            this.language = language;
            this.factory = this.language.InternalSyntaxFactory;
            this.options = options;
            this.cancellationToken = cancellationToken;
        }

        public abstract GreenNode Parse();

        public void Dispose()
        {
        }

        public Language Language
        {
            get { return this.language; }
        }

        public ParseOptions Options
        {
            get { return this.options; }
        }

        public bool IsScript
        {
            get { return Options.Kind == SourceCodeKind.Script; }
        }

        public abstract DirectiveStack Directives { get; }

        protected SyntaxDiagnosticInfo MakeError(int offset, int width, DiagnosticDescriptor descriptor)
        {
            return new SyntaxDiagnosticInfo(offset, width, descriptor);
        }

        protected SyntaxDiagnosticInfo MakeError(int offset, int width, DiagnosticDescriptor descriptor, params object[] args)
        {
            return new SyntaxDiagnosticInfo(offset, width, descriptor, args);
        }

        protected SyntaxDiagnosticInfo MakeError(GreenNode node, DiagnosticDescriptor descriptor, params object[] args)
        {
            return new SyntaxDiagnosticInfo(node.GetLeadingTriviaWidth(), node.Width, descriptor, args);
        }

        protected SyntaxDiagnosticInfo MakeError(DiagnosticDescriptor descriptor, params object[] args)
        {
            return new SyntaxDiagnosticInfo(descriptor, args);
        }
    }
}
