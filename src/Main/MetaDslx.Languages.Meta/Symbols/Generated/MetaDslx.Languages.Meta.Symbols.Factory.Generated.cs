using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Declarations;

namespace MetaDslx.Languages.Meta.Symbols.Factory
{
	public class AssociationSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorAssociationSymbol(container, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataAssociationSymbol(container);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceAssociationSymbol(container, declaration);
        }
	}
}
