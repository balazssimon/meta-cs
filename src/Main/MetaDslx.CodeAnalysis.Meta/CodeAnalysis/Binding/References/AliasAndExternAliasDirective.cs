// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    public struct AliasAndExternAliasDirective
    {
        public readonly AliasSymbol Alias;
        public readonly ExternAliasDirective ExternAliasDirective;

        public AliasAndExternAliasDirective(AliasSymbol alias, ExternAliasDirective externAliasDirective)
        {
            this.Alias = alias;
            this.ExternAliasDirective = externAliasDirective;
        }
    }
}
