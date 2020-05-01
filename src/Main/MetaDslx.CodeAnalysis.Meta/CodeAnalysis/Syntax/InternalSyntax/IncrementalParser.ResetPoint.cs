// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public partial class IncrementalParser
    {
        protected struct ResetPoint
        {
            internal readonly int ResetCount;
            internal readonly ParserState State;
            internal readonly int Position;
            internal readonly GreenNode PrevTokenTrailingTrivia;

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
