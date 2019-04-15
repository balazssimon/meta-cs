// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.MetaModel.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.MetaModel
{
    public partial class MetaModelSyntaxTree
    {
        internal sealed class DummySyntaxTree : MetaModelSyntaxTree
        {
            private readonly MetaModelSyntaxNode _node;

            public DummySyntaxTree()
            {
                _node = this.CloneNodeAsRoot(MetaModelLanguage.Instance.SyntaxFactory.ParseCompilationUnit(string.Empty));
            }

            public override string ToString()
            {
                return string.Empty;
            }

            public override SourceText GetText(CancellationToken cancellationToken)
            {
                return SourceText.From(string.Empty, Encoding.UTF8);
            }

            public override bool TryGetText(out SourceText text)
            {
                text = SourceText.From(string.Empty, Encoding.UTF8);
                return true;
            }

            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }

            public override int Length
            {
                get { return 0; }
            }

            public override MetaModelParseOptions Options
            {
                get { return MetaModelParseOptions.Default; }
            }

            public override string FilePath
            {
                get { return string.Empty; }
            }

            public override SyntaxReference GetReference(SyntaxNode node)
            {
                return new SimpleSyntaxReference(node);
            }

            public override MetaModelSyntaxNode GetRoot(CancellationToken cancellationToken)
            {
                return _node;
            }

            public override bool TryGetRoot(out MetaModelSyntaxNode root)
            {
                root = _node;
                return true;
            }

            public override bool HasCompilationUnitRoot
            {
                get { return true; }
            }

            public override FileLinePositionSpan GetLineSpan(TextSpan span, CancellationToken cancellationToken = default(CancellationToken))
            {
                return default(FileLinePositionSpan);
            }

            public override SyntaxTree WithRootAndOptions(SyntaxNode root, ParseOptions options)
            {
                return MetaModelLanguage.Instance.SyntaxFactory.SyntaxTree(root, options: options, path: FilePath, encoding: null);
            }

            public override SyntaxTree WithFilePath(string path)
            {
                return MetaModelLanguage.Instance.SyntaxFactory.SyntaxTree(_node, options: this.Options, path: path, encoding: null);
            }
        }
    }
}
