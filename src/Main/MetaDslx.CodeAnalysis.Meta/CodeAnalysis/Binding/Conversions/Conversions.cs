// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Operations;

namespace MetaDslx.CodeAnalysis.Binding
{
    // TODO:MetaDslx
    public sealed class Conversions : ConversionsBase
    {
        private readonly Binder _binder;

        public Conversions(Binder binder)
            : this(binder, currentRecursionDepth: 0)
        {
        }

        private Conversions(Binder binder, int currentRecursionDepth)
            : base(binder.Compilation.Assembly.CorLibrary, currentRecursionDepth)
        {
            _binder = binder;
        }

        protected override ConversionsBase CreateInstance(int currentRecursionDepth)
        {
            return new Conversions(_binder, currentRecursionDepth);
        }

        private LanguageCompilation Compilation { get { return _binder.Compilation; } }

        public Conversion ClassifyConversionFromType(ITypeSymbol source, ITypeSymbol destination, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new NotImplementedException();
        }

        public Conversion ClassifyConversionFromExpression(object bnode, TypeSymbol destination, ref HashSet<DiagnosticInfo> useSiteDiagnostics, bool forCast)
        {
            throw new NotImplementedException();
        }

        public Conversion ClassifyConversionFromExpression(object bnode, TypeSymbol cdestination, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new NotImplementedException();
        }
    }
}
