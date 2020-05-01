// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public partial class IncrementalParser
    {
        protected struct ResetPoint
        {
            public readonly int ResetCount;
            public readonly ParserState State;
            public readonly int Position;
            public readonly GreenNode PrevTokenTrailingTrivia;

            internal ResetPoint(int resetCount, ParserState state, int position, GreenNode prevTokenTrailingTrivia)
            {
                this.ResetCount = resetCount;
                this.State = state;
                this.Position = position;
                this.PrevTokenTrailingTrivia = prevTokenTrailingTrivia;
            }
        }
    }
}
