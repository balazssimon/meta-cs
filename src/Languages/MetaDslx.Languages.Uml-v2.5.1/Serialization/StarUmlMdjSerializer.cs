using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.Languages.Uml.Serialization
{
    public class StarUmlMdjSerializer
    {
        private static readonly Dictionary<string, string> UmlTypeMap = new Dictionary<string, string>()
        {
            { "A", "B" }
        };

        public ImmutableModel ReadModel(string mdjCode, out ImmutableArray<Diagnostic> diagnostics)
        {
            return null;
        }
    }
}
