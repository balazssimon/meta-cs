// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.CodeGen
{
    internal sealed class DynamicAnalysisMethodBodyData
    {
        public readonly ImmutableArray<SourceSpan> Spans;

        public DynamicAnalysisMethodBodyData(ImmutableArray<SourceSpan> spans)
        {
            Debug.Assert(!spans.IsDefault);
            Spans = spans;
        }
    }
}
