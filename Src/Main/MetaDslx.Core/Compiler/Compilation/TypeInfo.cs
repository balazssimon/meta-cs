﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;

namespace MetaDslx.Compiler
{
    public sealed class TypeInfo : IEquatable<TypeInfo>
    {
        public static readonly TypeInfo None = new TypeInfo(null, null);

        /// <summary>
        /// The type of the expression represented by the syntax node. For expressions that do not
        /// have a type, null is returned. If the type could not be determined due to an error, then
        /// an IErrorTypeSymbol is returned.
        /// </summary>
        public ISymbol Type { get; }

        /// <summary>
        /// The type of the expression after it has undergone an implicit conversion. If the type
        /// did not undergo an implicit conversion, returns the same as Type.
        /// </summary>
        public ISymbol ConvertedType { get; }

        public TypeInfo(ISymbol type, ISymbol convertedType)
        {
            this.Type = type;
            this.ConvertedType = convertedType;
        }

        public bool Equals(TypeInfo other)
        {
            return object.Equals(this.Type, other.Type)
                && object.Equals(this.ConvertedType, other.ConvertedType);
        }

        public override bool Equals(object obj)
        {
            return obj is TypeInfo && this.Equals((TypeInfo)obj);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.ConvertedType, Hash.Combine(this.Type, 0));
        }
    }
}