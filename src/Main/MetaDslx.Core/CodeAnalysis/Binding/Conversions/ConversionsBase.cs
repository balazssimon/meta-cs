// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal abstract partial class ConversionsBase
    {
        private const int MaximumRecursionDepth = 50;

        protected readonly AssemblySymbol corLibrary;
        protected readonly int currentRecursionDepth;

        protected ConversionsBase(AssemblySymbol corLibrary, int currentRecursionDepth)
        {
            Debug.Assert((object)corLibrary != null);
            this.corLibrary = corLibrary;
            this.currentRecursionDepth = currentRecursionDepth;
        }

        internal AssemblySymbol CorLibrary { get { return corLibrary; } }

        protected abstract ConversionsBase CreateInstance(int currentRecursionDepth);
    }
}
