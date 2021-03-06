﻿using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class IncrementalToken : CommonToken
    {
        private InternalSyntaxToken _greenToken;

        public IncrementalToken(int type, string text) : base(type, text)
        {
        }

        public IncrementalToken(Tuple<ITokenSource, ICharStream> source, int type, int channel, int start, int stop) 
            : base(source, type, channel, start, stop)
        {
        }

        public InternalSyntaxToken GreenToken => _greenToken;

        internal void SetGreenToken(InternalSyntaxToken greenToken)
        {
            _greenToken = greenToken;
        }
    }

    public class IncrementalTokenFactory : ITokenFactory
    {
        [return: NotNull]
        public IToken Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
        {
            return new IncrementalToken(source, type, channel, start, stop) { Line = line, Column = charPositionInLine };
        }

        [return: NotNull]
        public IToken Create(int type, string text)
        {
            return new IncrementalToken(type, text);
        }
    }
}
