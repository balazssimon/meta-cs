// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    /// <summary>
    /// Represents implicit, script and submission classes.
    /// </summary>
    public abstract class ImplicitNamedTypeSymbol : SourceNamedTypeSymbol
    {
        protected ImplicitNamedTypeSymbol(NamespaceOrTypeSymbol containingSymbol, MergedDeclaration declaration, object modelObject)
            : base(containingSymbol, declaration, modelObject)
        {
            Debug.Assert(declaration.IsImplicit || declaration.IsSubmission || declaration.IsScript);
        }

        public override bool IsImplicitlyDeclared => true;
    }
}
