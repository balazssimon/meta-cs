using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis
{
    public class LanguageCompilation
    {
        public Language Language { get; }

        internal DeclarationTable Declarations { get; set; }

        internal int GetSyntaxTreeOrdinal(LanguageSyntaxTree tree)
        {
            throw new NotImplementedException();
        }

        internal int CompareSourceLocations(SyntaxReference syntaxReference1, SyntaxReference syntaxReference2)
        {
            throw new NotImplementedException();
        }
    }
}
