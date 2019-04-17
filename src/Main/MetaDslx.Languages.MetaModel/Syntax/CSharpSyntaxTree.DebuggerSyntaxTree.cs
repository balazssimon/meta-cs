// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.MetaModel.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.MetaModel
{
    public partial class MetaModelSyntaxTree
    {
        private class DebuggerSyntaxTree : ParsedSyntaxTree
        {
            public DebuggerSyntaxTree(MetaModelSyntaxNode root, SourceText text, MetaModelParseOptions options)
                : base(
                    text,
                    text.Encoding,
                    text.ChecksumAlgorithm,
                    path: "",
                    options: options,
                    root: root,
                    directives: DirectiveStack.Empty)
            {
            }

            public override bool SupportsLocations
            {
                get { return true; }
            }
        }
    }
}
