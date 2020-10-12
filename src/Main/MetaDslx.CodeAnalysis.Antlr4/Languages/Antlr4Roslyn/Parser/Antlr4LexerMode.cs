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
            this.Mode = lexer.Antlr4Lexer.CurrentMode;
            this.ModeStackReversed = lexer.Antlr4Lexer.ModeStack.ToImmutableArray();
        }

        public int Mode { get; private set; }
        public ImmutableArray<int> ModeStackReversed { get; private set; }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;
            return this.Equals((Antlr4LexerMode)obj);
        }

        public virtual bool Equals(Antlr4LexerMode other)
        {
            if (other == null)
            {
                return this.Mode == 0 && this.ModeStackReversed.Length == 0;
            }
            if (this.Mode != other.Mode) return false;
            if (this.ModeStackReversed.Length != other.ModeStackReversed.Length) return false;
            for (int i = 0; i < this.ModeStackReversed.Length; i++)
            {
                if (this.ModeStackReversed[i] != other.ModeStackReversed[i]) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.Mode, this.ModeStackReversed.GetHashCode());
        }

        public override string ToString()
        {
            string modeStack = string.Empty;
            if (ModeStackReversed.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = ModeStackReversed.Length - 1; i >= 0; i--)
                {
                    if (i < ModeStackReversed.Length - 1) sb.Append(",");
                    sb.Append(ModeStackReversed[i]);
                }
                modeStack = sb.ToString();
            }
            return $"mode={Mode}, modeStack={modeStack}";
        }
    }
}
