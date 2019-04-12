// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using MetaDslx.Compiler.Utilities;
using System;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Symbols;

namespace MetaDslx.Compiler.Errors
{
    internal sealed class DefaultDiagnosticInfo : DiagnosticInfoWithSymbols
    {
        public static readonly DiagnosticDescriptor EmptyErrorDescriptor = new DiagnosticDescriptor("MC0000", "Unresolved DiagnosticInfo", "Unresolved DiagnosticInfo", Diagnostic.CompilerDiagnosticCategory, DiagnosticSeverity.Error, true);
        public static readonly DiagnosticDescriptor VoidDiagnosticDescriptor = new DiagnosticDescriptor("MC0001", "Void DiagnosticInfo", "Void DiagnosticInfo", Diagnostic.CompilerDiagnosticCategory, DiagnosticSeverity.Error, true);

        public static readonly DiagnosticInfo EmptyErrorInfo = new DefaultDiagnosticInfo(EmptyErrorDescriptor);
        public static readonly DiagnosticInfo VoidDiagnosticInfo = new DefaultDiagnosticInfo(VoidDiagnosticDescriptor);

        private readonly ImmutableArray<Location> _additionalLocations;

        internal DefaultDiagnosticInfo(DiagnosticDescriptor descriptor)
            : this(descriptor, Array.Empty<object>(), ImmutableArray<ISymbol0>.Empty, ImmutableArray<Location>.Empty)
        {
        }

        internal DefaultDiagnosticInfo(DiagnosticDescriptor descriptor, params object[] args)
            : this(descriptor, args, ImmutableArray<ISymbol0>.Empty, ImmutableArray<Location>.Empty)
        {
        }

        internal DefaultDiagnosticInfo(DiagnosticDescriptor descriptor, ImmutableArray<ISymbol0> symbols, object[] args)
            : this(descriptor, args, symbols, ImmutableArray<Location>.Empty)
        {
        }

        internal DefaultDiagnosticInfo(DiagnosticDescriptor descriptor, object[] args, ImmutableArray<ISymbol0> symbols, ImmutableArray<Location> additionalLocations)
            : base(descriptor, args, symbols)
        {
            _additionalLocations = additionalLocations;
        }

        public override IReadOnlyList<Location> AdditionalLocations => _additionalLocations;

        internal static bool IsEmpty(DiagnosticInfo info) => (object)info == EmptyErrorInfo;
    }
}
