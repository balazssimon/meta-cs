// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis
{
    internal struct DeclarationLoadDirective : IEquatable<DeclarationLoadDirective>
    {
        public readonly string ResolvedPath;
        public readonly ImmutableArray<Diagnostic> Diagnostics;

        public DeclarationLoadDirective(string resolvedPath, ImmutableArray<Diagnostic> diagnostics)
        {
            Debug.Assert((resolvedPath != null) || !diagnostics.IsEmpty);
            Debug.Assert(!diagnostics.IsDefault);
            Debug.Assert(diagnostics.IsEmpty || diagnostics.All(d => d.Severity == DiagnosticSeverity.Error));

            ResolvedPath = resolvedPath;
            Diagnostics = diagnostics;
        }

        public bool Equals(DeclarationLoadDirective other)
        {
            return this.ResolvedPath == other.ResolvedPath &&
                this.Diagnostics.SequenceEqual(other.Diagnostics);
        }

        public override bool Equals(object obj)
        {
            return obj is DeclarationLoadDirective && Equals((DeclarationLoadDirective)obj);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.Diagnostics.GetHashCode(), this.ResolvedPath.GetHashCode());
        }
    }
}
