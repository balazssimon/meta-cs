using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
	public partial class MetadataAliasSymbol
	{

        public partial class Error : MetadataAliasSymbol
        {
            public Error(Binder binder, string aliasName, SyntaxNodeOrToken aliasTargetName, Location location, bool isExtern = false) 
                : base(binder, aliasName, aliasTargetName, location, isExtern)
            {
            }

            public override bool IsError => true;
        }
    }
}
