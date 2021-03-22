// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{

    public partial class DeclaredSymbol
    {
        /// <summary>
        /// Checks if 'symbol' is accessible from within named type 'within'.  If 'symbol' is accessed off
        /// of an expression then 'throughTypeOpt' is the type of that expression. This is needed to
        /// properly do protected access checks.
        /// </summary>
        public static bool IsSymbolAccessible(
            DeclaredSymbol symbol,
            NamedTypeSymbol within,
            NamedTypeSymbol throughTypeOpt = null)
        {
            if ((object)symbol == null)
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            if ((object)within == null)
            {
                throw new ArgumentNullException(nameof(within));
            }

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            return AccessCheck.IsSymbolAccessible(
                symbol,
                within,
                ref useSiteDiagnostics,
                throughTypeOpt);
        }

        /// <summary>
        /// Checks if 'symbol' is accessible from within assembly 'within'.  
        /// </summary>
        public static bool IsSymbolAccessible(
            DeclaredSymbol symbol,
            AssemblySymbol within)
        {
            if ((object)symbol == null)
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            if ((object)within == null)
            {
                throw new ArgumentNullException(nameof(within));
            }

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            return AccessCheck.IsSymbolAccessible(symbol, within, ref useSiteDiagnostics);
        }

    }
}
