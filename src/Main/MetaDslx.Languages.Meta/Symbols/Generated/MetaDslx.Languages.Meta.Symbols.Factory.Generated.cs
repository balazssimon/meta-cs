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
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataAssociationSymbol(container);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataAssociationSymbol.Error(container, name, metadataName, errorInfo);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceAssociationSymbol(container, declaration);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceAssociationSymbol.Error(container, declaration, errorInfo);
        }
	}
}
