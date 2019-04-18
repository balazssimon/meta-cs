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
	// TODO:MetaDslx
    internal sealed partial class OverloadResolution
    {
        private readonly Binder _binder;

        public OverloadResolution(Binder binder)
        {
            _binder = binder;
        }

        private LanguageCompilation Compilation
        {
            get { return _binder.Compilation; }
        }

        private Conversions Conversions
        {
            get { return _binder.Conversions; }
        }

    }
}
