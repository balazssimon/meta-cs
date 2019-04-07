using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler
{
    public abstract class Language
    {
        public static readonly Language Default = null;

        public abstract string Name { get; }
        public abstract InternalSyntaxFactory InternalSyntaxFactory { get; }
        public abstract SyntaxFacts SyntaxFacts { get; }
    }
}
