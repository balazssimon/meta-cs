// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract class ParserState : State
    {
        public ParserState(int hashCode)
            : base(hashCode)
        {
        }

    }
}
