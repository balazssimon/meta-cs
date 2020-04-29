// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public class ParserState
    {
        public readonly LexerMode Mode;

        public ParserState(LexerMode mode)
        {
            this.Mode = mode;
        }
    }
}
