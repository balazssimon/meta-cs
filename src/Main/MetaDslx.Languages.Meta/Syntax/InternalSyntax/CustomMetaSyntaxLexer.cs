using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax
{
    public class CustomMetaSyntaxLexer : MetaSyntaxLexer
    {
        public CustomMetaSyntaxLexer(SourceText text, MetaParseOptions options) 
            : base(text, options)
        {
        }

        protected override LexerStateManager? CreateStateManager()
        {
            return new MetaLexerStateManager(this);
        }

        private class MetaLexerStateManager : Antlr4LexerStateManager
        {
            public MetaLexerStateManager(CustomMetaSyntaxLexer lexer) 
                : base(lexer)
            {
            }

            public new CustomMetaSyntaxLexer Lexer => (CustomMetaSyntaxLexer)base.Lexer;
            public MetaLexer MetaLexer => (MetaLexer)Lexer.Antlr4Lexer;

            protected override int ComputeStateHash()
            {
                return Hash.Combine(MetaLexer._brackets.GetHashCode(), base.ComputeStateHash());
            }

            protected override bool IsInState(LexerState? state)
            {
                if (!base.IsInState(state)) return false;
                var antlr4Lexer = MetaLexer;
                var customState = state as MetaLexerState;
                if (customState == null) return antlr4Lexer._brackets == 0;
                if (customState.Brackets != antlr4Lexer._brackets) return false;
                return true;
            }

            protected override LexerState? SaveState(int hashCode)
            {
                var antlr4Lexer = MetaLexer;
                return new MetaLexerState(hashCode, antlr4Lexer.CurrentMode, antlr4Lexer.ModeStack.Count == 0 ? null : antlr4Lexer.ModeStack.ToArray(), antlr4Lexer._brackets);
            }

            protected override void RestoreState(LexerState? state)
            {
                base.RestoreState(state);
                var antlr4Lexer = MetaLexer;
                var customState = state as MetaLexerState;
                if (customState == null)
                {
                    antlr4Lexer._brackets = 0;
                }
                else
                {
                    antlr4Lexer._brackets = customState.Brackets;
                }
            }
        }


        private class MetaLexerState : Antlr4LexerState
        {
            private int _brackets = 0;

            public MetaLexerState(int hashCode, int mode, int[]? modeStackReversed, int brackets)
                : base(hashCode, mode, modeStackReversed)
            {
                _brackets = brackets;
            }

            public int Brackets => _brackets;

            public override string ToString()
            {
                return $"[{base.ToString()}, b={_brackets}]";
            }
        }
    }
}
