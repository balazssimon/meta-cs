using Antlr4.Runtime;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class Antlr4LexerState
    {
        public Antlr4LexerState(IAntlr4Lexer lexer)
        {
            this.Mode = lexer.Lexer._mode;
            this.ModeStack = lexer.Lexer._modeStack.ToImmutableArray();
        }
        public int Mode { get; private set; }
        public ImmutableArray<int> ModeStack { get; private set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Antlr4LexerState);
        }

        public virtual bool Equals(Antlr4LexerState other)
        {
            if (other == null)
            {
                return this.Mode == 0 && this.ModeStack.Length == 0;
            }
            if (this.Mode != other.Mode) return false;
            if (this.ModeStack.Length != other.ModeStack.Length) return false;
            for (int i = 0; i < this.ModeStack.Length; i++)
            {
                if (this.ModeStack[i] != other.ModeStack[i]) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.Mode, this.ModeStack.GetHashCode());
        }

        public virtual void Restore(IAntlr4Lexer lexer)
        {
            lexer.Lexer._mode = this.Mode;
            lexer.Lexer._modeStack.Clear();
            lexer.Lexer._modeStack.AddRange(this.ModeStack);
        }

    }
}
