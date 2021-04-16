// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// Summarizes whether a conversion is allowed, and if so, which kind of conversion (and in some cases, the
    /// associated symbol).
    /// </summary>
    public struct Conversion : IEquatable<Conversion>, IConvertibleConversion
    {
        private readonly ConversionKind _kind;

        private Conversion(ConversionKind kind)
        {
            _kind = kind;
        }

        internal static Conversion UnsetConversion => new Conversion(ConversionKind.UnsetConversionKind);
        internal static Conversion NoConversion => new Conversion(ConversionKind.NoConversion);
        internal static Conversion NullLiteral => new Conversion(ConversionKind.NullLiteral);
        internal static Conversion Identity => new Conversion(ConversionKind.Identity);

        public bool Equals(Conversion other)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }


        /// <summary>
        /// Creates a <seealso cref="CommonConversion"/> from this C# conversion.
        /// </summary>
        /// <returns>The <see cref="CommonConversion"/> that represents this conversion.</returns>
        /// <remarks>
        /// This is a lossy conversion; it is not possible to recover the original <see cref="Conversion"/>
        /// from the <see cref="CommonConversion"/> struct.
        /// </remarks>
        public CommonConversion ToCommonConversion()
        {
            // The MethodSymbol of CommonConversion only refers to UserDefined conversions, not method groups
            /* TODO:MetaDslx
            var methodSymbol = IsUserDefined ? MethodSymbol : null;
            return new CommonConversion(Exists, IsIdentity, IsNumeric, IsReference, IsImplicit, methodSymbol);
            */
            throw new NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Returns true if the conversion is an implicit reference conversion or explicit reference conversion.
        /// </summary>
        /// <remarks>
        /// Implicit and explicit reference conversions are described in sections 6.1.6 and 6.2.4 of the C# language specification.
        /// </remarks>
        public bool IsReference
        {
            get
            {
                throw new NotImplementedException("TODO:MetaDslx");
            }
        }

        public MethodSymbol Method => throw new NotImplementedException("TODO:MetaDslx");
        public bool IsValid => throw new NotImplementedException("TODO:MetaDslx");
    }
}
