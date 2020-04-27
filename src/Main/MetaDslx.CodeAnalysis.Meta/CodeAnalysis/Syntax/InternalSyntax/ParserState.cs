// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public class ParserState
    {
        public readonly LexerMode Mode;
        public readonly int Position;
        public readonly GreenNode PrevTokenTrailingTrivia;

        public ParserState(LexerMode mode, int position, GreenNode prevTokenTrailingTrivia)
        {
            this.Mode = mode;
            this.Position = position;
            this.PrevTokenTrailingTrivia = prevTokenTrailingTrivia;
        }
    }
}
