﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.
// Changed for MetaDslx.

using MetaDslx.Core;
using System;
using System.Diagnostics;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// A program location in metadata.
    /// </summary>
    internal sealed class MetadataLocation : Location, IEquatable<MetadataLocation>
    {
        private readonly ISymbol _module;

        internal MetadataLocation(ISymbol module)
        {
            Debug.Assert(module != null);
            _module = module;
        }

        public override LocationKind Kind
        {
            get { return LocationKind.MetadataFile; }
        }

        public override ISymbol MetadataModule
        {
            get { return _module; }
        }

        public override int GetHashCode()
        {
            return _module.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MetadataLocation);
        }

        public bool Equals(MetadataLocation other)
        {
            return other != null && other._module == _module;
        }
    }
}
