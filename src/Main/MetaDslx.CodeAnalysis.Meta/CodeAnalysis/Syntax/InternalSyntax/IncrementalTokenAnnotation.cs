using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public sealed class IncrementalTokenAnnotation
    {
        public readonly LexerMode StartMode;
        public readonly LexerMode EndMode;

        public IncrementalTokenAnnotation(LexerMode startMode, LexerMode endMode)
        {
            StartMode = startMode;
            EndMode = endMode;
        }
    }
}
