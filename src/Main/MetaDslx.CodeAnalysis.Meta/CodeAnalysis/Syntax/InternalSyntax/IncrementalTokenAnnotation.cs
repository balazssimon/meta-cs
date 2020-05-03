using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public sealed class IncrementalTokenAnnotation
    {
        public readonly LexerMode Mode;

        public IncrementalTokenAnnotation(LexerMode mode)
        {
            Mode = mode;
        }
    }
}
