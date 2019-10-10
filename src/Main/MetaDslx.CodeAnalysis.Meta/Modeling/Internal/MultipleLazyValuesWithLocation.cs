using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class MultipleLazyValuesWithLocation : MultipleLazyValues
    {
        private DiagnosticBag diagnostics;
        private Location location;

        internal MultipleLazyValuesWithLocation(Func<IEnumerable<object>> lazy, Location location, DiagnosticBag diagnostics)
            : base(lazy)
        {
            this.diagnostics = diagnostics;
            this.location = location;
        }

        internal override DiagnosticBag Diagnostics
        {
            get { return this.diagnostics; }
        }

        internal override Location Location
        {
            get { return this.location; }
        }
    }

}
