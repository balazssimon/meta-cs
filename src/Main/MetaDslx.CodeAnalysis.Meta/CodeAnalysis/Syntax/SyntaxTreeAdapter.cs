using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax
{
    public abstract class SyntaxTreeAdapter : SyntaxTree
    {
        internal override bool SupportsLocations => this.SupportsLocationsCore;

        internal virtual bool SupportsLocationsCore => base.SupportsLocations;
    }
}
