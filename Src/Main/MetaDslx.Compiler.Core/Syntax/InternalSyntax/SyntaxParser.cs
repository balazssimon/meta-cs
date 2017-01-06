using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    public class SyntaxParser
    {
        public SyntaxParser(string text, Language language, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.Text = text;
            this.Language = language;
            this.CancellationToken = cancellationToken;
        }

        public string Text { get; private set; }

        public Language Language { get; private set; }

        public CancellationToken CancellationToken { get; private set; }
    }
}
