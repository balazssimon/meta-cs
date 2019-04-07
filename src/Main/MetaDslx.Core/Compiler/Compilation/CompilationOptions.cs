// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Represents compilation options common to C# and VB.
    /// </summary>
    public abstract class CompilationOptions
    {
        internal Diagnostic FilterDiagnostic(Diagnostic diagnostic)
        {
            return diagnostic;
        }
    }
}
