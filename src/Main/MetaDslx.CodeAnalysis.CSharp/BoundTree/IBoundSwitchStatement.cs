// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis.CSharp
{
    internal interface IBoundSwitchStatement
    {
        BoundNode Value { get; }
        ImmutableArray<BoundStatementList> Cases { get; }
    }
}
