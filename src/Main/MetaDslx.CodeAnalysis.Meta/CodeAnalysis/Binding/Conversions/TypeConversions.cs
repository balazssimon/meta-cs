// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Binding
{
    public sealed class TypeConversions : ConversionsBase
    {
        public TypeConversions(AssemblySymbol corLibrary)
            : this(corLibrary, currentRecursionDepth: 0)
        {
        }

        private TypeConversions(AssemblySymbol corLibrary, int currentRecursionDepth)
            : base(corLibrary, currentRecursionDepth)
        {
        }

        protected override ConversionsBase CreateInstance(int currentRecursionDepth)
        {
            return new TypeConversions(this.corLibrary, currentRecursionDepth);
        }
    }
}
