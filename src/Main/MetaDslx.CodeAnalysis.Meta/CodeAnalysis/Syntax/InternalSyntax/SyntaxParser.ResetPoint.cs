// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public partial class SyntaxParser
    {
        protected struct ResetPoint
        {
            public readonly int ResetCount;
            public readonly LexerState? LexerState;
            public readonly ParserState? ParserState;
            public readonly int Index;
            public readonly int Position;
            public readonly int ErrorIndex;
            public readonly GreenNode[] SkippedTokens;
            public readonly GreenNode PrevTokenTrailingTrivia;

            internal ResetPoint(int resetCount, LexerState? lexerState, ParserState? parserState, int index, int position, int errorIndex, GreenNode[] skippedTokens, GreenNode prevTokenTrailingTrivia)
            {
                this.ResetCount = resetCount;
                this.LexerState = lexerState;
                this.ParserState = parserState;
                this.Index = index;
                this.Position = position;
                this.ErrorIndex = errorIndex;
                this.SkippedTokens = skippedTokens;
                this.PrevTokenTrailingTrivia = prevTokenTrailingTrivia;
            }
        }
    }
}
