// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class OverloadResolution
    {
        private readonly LanguageCompilation _compilation;

        public OverloadResolution(LanguageCompilation compilation)
        {
            _compilation = compilation;
        }

        public LanguageCompilation Compilation
        {
            get { return _compilation; }
        }

        public Conversions Conversions
        {
            get { return _compilation.Conversions; }
        }

    }
}
