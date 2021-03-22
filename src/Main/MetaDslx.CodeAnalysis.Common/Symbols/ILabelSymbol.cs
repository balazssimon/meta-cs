// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents a label in method body
    /// </summary>
    /// <remarks>
    /// This interface is reserved for implementation by its associated APIs. We reserve the right to
    /// change it in the future.
    /// </remarks>
    public interface ILabelSymbol : IDeclaredSymbol
    {
        /// <summary>
        /// Gets the immediately containing <see cref="IMethodSymbol"/> of this <see cref="ILocalSymbol"/>.
        /// </summary>
        IMethodSymbol ContainingMethod { get; }
    }
}
