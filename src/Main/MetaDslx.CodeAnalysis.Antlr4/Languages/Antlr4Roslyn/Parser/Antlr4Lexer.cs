using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class Antlr4Lexer : Lexer
    {
        protected Antlr4Lexer(ICharStream input, TextWriter output, TextWriter errorOutput)
            : base(input, output, errorOutput)
        {
        }

        public override IToken NextToken()
        {
            var token = base.NextToken();
            if (token.Type == TokenConstants.EOF)
            {
                if (this.InputStream is Antlr4InputStream charStream && charStream.LexemeStartPosition < charStream.Size)
                {
                    this.HitEOF = false;
                    IToken t = this.TokenFactory.Create(Tuple.Create((ITokenSource)this, (ICharStream)this.InputStream), TokenConstants.InvalidType, this.Text, TokenConstants.HiddenChannel, this.TokenStartCharIndex, this.CharIndex - 1, this.TokenStartLine, this.TokenStartColumn);
                    this.Emit(t);
                    return t;
                }
            }
            return token;
        }

        public override void Recover(LexerNoViableAltException e)
        {
            base.Recover(e);
        }

        /*public override void Recover(RecognitionException re)
        {
            base.Recover(re);
        }*/
    }

}
