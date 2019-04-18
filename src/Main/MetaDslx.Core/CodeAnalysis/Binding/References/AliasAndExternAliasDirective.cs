// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal struct AliasAndExternAliasDirective
    {
        public readonly IAliasSymbol Alias;
        public readonly SyntaxNode ExternAliasDirective;

        public AliasAndExternAliasDirective(IAliasSymbol alias, SyntaxNode externAliasDirective)
        {
            this.Alias = alias;
            this.ExternAliasDirective = externAliasDirective;
        }
    }
}
