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
    public sealed class ImplicitNamedTypeSymbol : SourceNamedTypeSymbol
    {
        internal ImplicitNamedTypeSymbol(NamespaceOrTypeSymbol containingSymbol, object modelObject, MergedDeclaration declaration)
            : base(containingSymbol, modelObject, declaration)
        {
            Debug.Assert(declaration.IsImplicit || declaration.IsSubmission || declaration.IsScript);
        }
        
        /// <summary>
        /// Returns null for a submission class.
        /// This ensures that a submission class does not inherit methods such as ToString or GetHashCode.
        /// </summary>
        public override ImmutableArray<NamedTypeSymbol> BaseTypes
        {
            get
            {
                if (this.IsScript) return ImmutableArray<NamedTypeSymbol>.Empty;
                else return ImmutableArray.Create(this.DeclaringCompilation.GetSpecialType(Microsoft.CodeAnalysis.SpecialType.System_Object));
            }
        }
            
    }
}
