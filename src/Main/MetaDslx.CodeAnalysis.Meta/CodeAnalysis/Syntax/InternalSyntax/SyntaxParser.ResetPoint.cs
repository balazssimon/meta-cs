// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public partial class SyntaxParser
    {
        protected struct ResetPoint
        {
            public readonly int ResetCount;
            public readonly ParserState State;
            public readonly int Index;
            public readonly int LastNonSkippedTokenIndex;
            public readonly int LastErrorIndex;
            public readonly GreenNode PrevTokenTrailingTrivia;

            internal ResetPoint(int resetCount, ParserState state, int index, int lastNonSkippedTokenIndex, int lastErrorIndex, GreenNode prevTokenTrailingTrivia)
            {
                this.ResetCount = resetCount;
                this.State = state;
                this.Index = index;
                this.LastNonSkippedTokenIndex = lastNonSkippedTokenIndex;
                this.LastErrorIndex = lastErrorIndex;
                this.PrevTokenTrailingTrivia = prevTokenTrailingTrivia;
            }
        }
    }
}
