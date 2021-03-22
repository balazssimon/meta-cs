// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;
using MetaDslx.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// Internal cache of built-in operators.
    /// Cache is compilation-specific because it uses compilation-specific SpecialTypes.
    /// </summary>
    internal class BuiltInOperators
    {
        private readonly LanguageCompilation _compilation;

        internal BuiltInOperators(LanguageCompilation compilation)
        {
            _compilation = compilation;
        }

    }
}
