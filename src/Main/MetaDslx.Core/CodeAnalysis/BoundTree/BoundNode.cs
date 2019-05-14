using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.BoundTree
{
    public class BoundNode
    {
        public LanguageSyntaxNode Syntax { get; }

        public Symbol Symbol { get; }

        public Language Language => this.Syntax.Language;

        public int RawKind { get; }

        public bool WasCompilerGenerated { get; }

        public virtual BoundNode Accept(BoundTreeVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
