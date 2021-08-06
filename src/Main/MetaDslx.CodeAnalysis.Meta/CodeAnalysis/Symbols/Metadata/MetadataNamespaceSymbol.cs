using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public partial class MetadataNamespaceSymbol
    {
        public partial class Error
        {
            public override NamespaceExtent Extent
            {
                get
                {
                    if (this.ContainingSymbol is ModuleSymbol moduleSymbol)
                    {
                        return new NamespaceExtent(moduleSymbol);
                    }
                    if (this.ContainingSymbol is NamespaceSymbol namespaceSymbol)
                    {
                        return namespaceSymbol.Extent;
                    }
                    return default;
                }
            }
        }

        public class Missing : Error
        {
            public Missing(Symbol container, string name, string metadataName, DiagnosticInfo? errorInfo, object? modelObject)
                : base(container, name, metadataName, errorInfo, modelObject)
            {
            }
        }

    }
}
