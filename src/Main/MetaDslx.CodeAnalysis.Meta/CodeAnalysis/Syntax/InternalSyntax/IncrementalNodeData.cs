using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public sealed class IncrementalNodeData : IEquatable<IncrementalNodeData>
    {
        public readonly LexerState? StartLexerState;
        public readonly LexerState? EndLexerState;
        public readonly ParserState? StartParserState;
        public readonly ParserState? EndParserState;
        public readonly int LookaheadTokensBefore;
        public readonly int LookaheadTokensAfter;
        public readonly int LookaheadBefore;
        public readonly int LookaheadAfter;
#if DEBUG
        public readonly int Version;
#endif

#if DEBUG
        public IncrementalNodeData(LexerState? startLexerState, LexerState? endLexerState, ParserState? startParserState, ParserState? endParserState, int lookaheadTokensBefore, int lookaheadTokensAfter, int lookaheadBefore, int lookaheadAfter, int version)
#else
        public IncrementalNodeData(LexerState? startLexerState, LexerState? endLexerState, ParserState? startParserState, ParserState? endParserState, int lookaheadTokensBefore, int lookaheadTokensAfter, int lookaheadBefore, int lookaheadAfter)
#endif
        {
            StartLexerState = startLexerState;
            EndLexerState = endLexerState;
            StartParserState = startParserState;
            EndParserState = endParserState;
            LookaheadTokensBefore = lookaheadTokensBefore;
            LookaheadTokensAfter = lookaheadTokensAfter;
            LookaheadBefore = lookaheadBefore;
            LookaheadAfter = lookaheadAfter;
#if DEBUG
            Version = version;
#endif
        }

        public bool Equals(LexerState? startLexerState, LexerState? endLexerState, ParserState? startParserState, ParserState? endParserState, int lookaheadTokensBefore, int lookaheadTokensAfter, int lookaheadBefore, int lookaheadAfter)
        {
            return startLexerState == this.StartLexerState &&
                endLexerState == this.EndLexerState &&
                startParserState == this.StartParserState &&
                endParserState == this.EndParserState &&
                lookaheadTokensBefore == this.LookaheadTokensBefore &&
                lookaheadTokensAfter == this.LookaheadTokensAfter &&
                lookaheadBefore == this.LookaheadBefore &&
                lookaheadAfter == this.LookaheadAfter;
        }

        public bool Equals(IncrementalNodeData other)
        {
            return Equals(other.StartLexerState, other.EndLexerState, other.StartParserState, other.EndParserState, other.LookaheadTokensBefore, other.LookaheadTokensAfter, other.LookaheadBefore, other.LookaheadAfter);
        }

        public override bool Equals(object obj)
        {
            if (obj is IncrementalNodeData other) return this.Equals(other);
            else return false;
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.StartLexerState?.GetHashCode() ?? 0, Hash.Combine(this.EndLexerState?.GetHashCode() ?? 0,
                Hash.Combine(this.StartParserState?.GetHashCode() ?? 0, Hash.Combine(this.EndParserState?.GetHashCode() ?? 0,
                Hash.Combine(this.LookaheadTokensBefore, Hash.Combine(this.LookaheadTokensAfter,
                Hash.Combine(this.LookaheadBefore, this.LookaheadAfter)))))));
        }
    }
}
