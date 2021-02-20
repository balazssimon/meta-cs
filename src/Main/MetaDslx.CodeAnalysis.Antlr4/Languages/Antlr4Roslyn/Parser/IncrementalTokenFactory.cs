using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class IncrementalTokenFactory : ITokenFactory
    {
        public IncrementalTokenFactory()
        {
        }

        public IToken Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
        {
            return new IncrementalToken(source, type, channel, start, stop) { Line = line, Column = charPositionInLine };
        }

        public IToken Create(int type, string text)
        {
            return new IncrementalToken(type, text);
        }

        IToken ITokenFactory.Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
        {
            return this.Create(source, type, text, channel, start, stop, line, charPositionInLine);
        }

        IToken ITokenFactory.Create(int type, string text)
        {
            return this.Create(type, text);
        }
    }
}
