// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// A binder that knows no symbols and will not delegate further.
    /// </summary>
    internal class BuckStopsHereBinder : Binder
    {
        internal BuckStopsHereBinder(LanguageCompilation compilation)
            : base(compilation)
        {
        }

        internal override ImportChain ImportChain
        {
            get
            {
                return null;
            }
        }

        internal override Imports GetImports(ConsList<ITypeSymbol> basesBeingResolved)
        {
            return Imports.Empty;
        }

        internal override bool IsAccessibleHelper(ISymbol symbol, ITypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ITypeSymbol> basesBeingResolved)
        {
            failedThroughTypeCheck = false;
            throw new NotImplementedException("TODO:MetaDslx");
            //return IsSymbolAccessibleConditional(symbol, Compilation.Assembly, ref useSiteDiagnostics);
        }

        internal override Symbol ContainingSymbol
        {
            get
            {
                return null;
            }
        }

        internal override Binder GetBinder(SyntaxNode node)
        {
            return null;
        }

    }
}
