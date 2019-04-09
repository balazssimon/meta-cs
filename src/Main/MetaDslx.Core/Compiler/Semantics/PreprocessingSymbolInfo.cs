﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;

namespace MetaDslx.Compiler
{
    public struct PreprocessingSymbolInfo : IEquatable<PreprocessingSymbolInfo>
    {
        internal static readonly PreprocessingSymbolInfo None = new PreprocessingSymbolInfo(null, false);

        /// <summary>
        /// The symbol that was referred to by the identifier, if any. 
        /// </summary>
        public ISymbol Symbol { get; }

        /// <summary>
        /// Returns true if this preprocessing symbol is defined at the identifier position.
        /// </summary>
        public bool IsDefined { get; }

        internal PreprocessingSymbolInfo(ISymbol symbol, bool isDefined)
            : this()
        {
            this.Symbol = symbol;
            this.IsDefined = isDefined;
        }

        public bool Equals(PreprocessingSymbolInfo other)
        {
            return object.Equals(this.Symbol, other.Symbol)
                && object.Equals(this.IsDefined, other.IsDefined);
        }

        public override bool Equals(object obj)
        {
            return obj is PreprocessingSymbolInfo && this.Equals((PreprocessingSymbolInfo)obj);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.IsDefined, Hash.Combine(this.Symbol, 0));
        }
    }
}
