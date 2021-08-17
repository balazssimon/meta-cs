﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

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
    public abstract class Conversion : IEquatable<Conversion>
    {
        protected Conversion()
        {
        }

        public abstract bool IsImplicit { get; }

        public abstract ConversionOperatorSymbol? Method { get; }

        public virtual bool Equals(Conversion? other)
        {
            return object.ReferenceEquals(this, other);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Conversion);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
