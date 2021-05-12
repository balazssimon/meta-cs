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
        private List<IToken> _tokenBuffer;

        protected Antlr4Lexer(ICharStream input, TextWriter output, TextWriter errorOutput)
            : base(input, output, errorOutput)
        {
            _tokenBuffer = new List<IToken>();
        }

        public override void Reset()
        {
            _tokenBuffer.Clear();
            base.Reset();
        }

        /*public override int CharIndex
        {
            get
            {
                if (_tokenBuffer.Count > 0) return base.TokenStartCharIndex + _tokenBuffer[0].StopIndex - _tokenBuffer[0].StartIndex + 1;
                else return base.CharIndex;
            }
        }*/

        public override IToken NextToken()
        {
            if (_tokenBuffer.Count == 0) _tokenBuffer.Add(base.NextToken());
            var token = _tokenBuffer[0];
            _tokenBuffer.RemoveAt(0);
            return token;
            /*if (token.Type == TokenConstants.EOF)
            {
                if (this.InputStream is Antlr4InputStream charStream && charStream.LexemeStartPosition < charStream.Size)
                {
                    this.HitEOF = false;
                    IToken t = this.TokenFactory.Create(Tuple.Create((ITokenSource)this, (ICharStream)this.InputStream), TokenConstants.InvalidType, this.Text, TokenConstants.HiddenChannel, this.TokenStartCharIndex, this.CharIndex - 1, this.TokenStartLine, this.TokenStartColumn);
                    this.Emit(t);
                    return t;
                }
            }*/
        }

        public override void Recover(LexerNoViableAltException e)
        {
            var token = this.TokenFactory.Create(Tuple.Create((ITokenSource)this, (ICharStream)this.InputStream), TokenConstants.InvalidType, this.Text, TokenConstants.HiddenChannel, this.TokenStartCharIndex, this.CharIndex - 1, this.TokenStartLine, this.TokenStartColumn);
            _tokenBuffer.Add(token);
            base.Recover(e);
        }

        /*public override void Recover(RecognitionException re)
        {
            base.Recover(re);
        }*/
    }

}
