using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class IdentifierBinder : Binder
    {
        public IdentifierBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next)
        {
            string name = Language.SyntaxFacts.ExtractName(syntax);
            string metadataName = Language.SyntaxFacts.ExtractMetadataName(syntax);
        }

    }
}
