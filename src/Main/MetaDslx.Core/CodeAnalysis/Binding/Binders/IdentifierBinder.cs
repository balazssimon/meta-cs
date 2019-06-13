using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class IdentifierBinder : Binder
    {
        private readonly Identifier _identifier;

        public IdentifierBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next)
        {
            string name = Language.SyntaxFacts.ExtractName(syntax);
            string metadataName = Language.SyntaxFacts.ExtractMetadataName(syntax);
            _identifier = new Identifier(syntax, name, metadataName);
        }

    }
}
