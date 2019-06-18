using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public struct Identifier
    {
        public readonly string Name;
        public readonly string MetadataName;
        public readonly SyntaxNodeOrToken Syntax;

        public Identifier(SyntaxNodeOrToken syntax, string name, string metadataName)
        {
            Syntax = syntax;
            Name = name;
            MetadataName = metadataName;
        }

        public bool IsDefault => Syntax == null;

        public override string ToString()
        {
            return this.MetadataName;
        }
    }
}
