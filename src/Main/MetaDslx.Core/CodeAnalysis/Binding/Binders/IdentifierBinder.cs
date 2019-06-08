using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class IdentifierBinder : Binder
    {
        private readonly string _name;
        private readonly string _metadataName;

        public IdentifierBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
            _name = Language.SyntaxFacts.ExtractName(syntax);
            _metadataName = Language.SyntaxFacts.ExtractMetadataName(syntax);
        }
    }
}
