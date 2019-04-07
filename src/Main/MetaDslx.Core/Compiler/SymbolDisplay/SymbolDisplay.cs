// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.Compiler.PooledObjects;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Diagnostics
{
    // TODO:MetaDslx

#pragma warning disable CA1200 // Avoid using cref tags with a prefix
    /// <summary>
    /// Displays a symbol in the C# style.
    /// </summary>
    /// <seealso cref="T:MetaDslx.Compiler.VisualBasic.Symbols.SymbolDisplay"/>
#pragma warning restore CA1200 // Avoid using cref tags with a prefix
    public static class SymbolDisplay
    {
        /// <summary>
        /// Displays a symbol in the C# style, based on a <see cref="SymbolDisplayFormat"/>.
        /// </summary>
        /// <param name="symbol">The symbol to be displayed.</param>
        /// <param name="format">The formatting options to apply.  If null is passed, <see cref="SymbolDisplayFormat.CSharpErrorMessageFormat"/> will be used.</param>
        /// <returns>A formatted string that can be displayed to the user.</returns>
        /// <remarks>
        /// The return value is not expected to be syntactically valid C#.
        /// </remarks>
        public static string ToDisplayString(
            ISymbol symbol,
            SymbolDisplayFormat format = null)
        {
            return symbol.MName ?? string.Empty;
        }

    }

    public class SymbolDisplayFormat { }
}
