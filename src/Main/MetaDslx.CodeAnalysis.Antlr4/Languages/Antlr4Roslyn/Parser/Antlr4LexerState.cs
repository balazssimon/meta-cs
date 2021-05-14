using Antlr4.Runtime;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class Antlr4LexerState : LexerState
    {
        public Antlr4LexerState(int hashCode, int mode, int[]? modeStackReversed)
            : base(hashCode)
        {
            this.Mode = mode;
            this.ModeStackReversed = modeStackReversed;
        }

        public int Mode { get; }
        public int[]? ModeStackReversed { get; }

        public override string ToString()
        {
            string modeStack = string.Empty;
            if (ModeStackReversed != null && ModeStackReversed.Length > 0)
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
