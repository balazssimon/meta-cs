// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.Operations;

namespace MetaDslx.CodeAnalysis.Binding
{
    public sealed class Conversions 
    {
        public static readonly Conversion UnsetConversion = new StandardConversion(true);
        public static readonly Conversion NoConversion = new StandardConversion(true);
        public static readonly Conversion Identity = new StandardConversion(true);

        private readonly LanguageCompilation _compilation;

        public Conversions(LanguageCompilation compilation)
        {
            _compilation = compilation;
        }

        public LanguageCompilation Compilation => _compilation;

        public Conversion ClassifyConversionFromType(TypeSymbol source, TypeSymbol destination, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            throw new NotImplementedException();
        }

    }
}
