using Antlr4.Runtime;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class Antlr4LexerMode : LexerMode
    {
        public Antlr4LexerMode(IAntlr4Lexer lexer)
        {
            this.Mode = lexer.Antlr4Lexer._mode;
            this.ModeStack = lexer.Antlr4Lexer._modeStack.ToImmutableArray();
        }

        public int Mode { get; private set; }
        public ImmutableArray<int> ModeStack { get; private set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Antlr4LexerMode);
        }

        public virtual bool Equals(Antlr4LexerMode other)
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

        public virtual bool HasChanged(IAntlr4Lexer lexer)
        {
            var antlr4Lexer = lexer?.Antlr4Lexer;
            if (antlr4Lexer == null)
            {
                return this.Mode != 0 || this.ModeStack.Length != 0;
            }
            if (this.Mode != antlr4Lexer._mode) return true;
            if (this.ModeStack.Length != antlr4Lexer._modeStack.Count) return true;
            for (int i = 0; i < this.ModeStack.Length; i++)
            {
                if (this.ModeStack[i] != antlr4Lexer._modeStack[i]) return true;
            }
            return false;
        }
    }
}
