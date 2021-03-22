// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public class ParserState
    {
        public ParserState()
        {
        }

        public static bool SameState(ParserState first, ParserState second)
        {
            if (first == null && second == null) return true;
            if (first != null) return first.Equals(second);
            else return second.Equals(first);
        }
    }
}
