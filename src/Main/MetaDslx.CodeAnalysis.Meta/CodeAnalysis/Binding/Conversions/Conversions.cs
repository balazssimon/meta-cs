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
    public abstract class Conversions 
    {
        public static readonly Conversion UnsetConversion = new StandardConversion(nameof(UnsetConversion), isImplicit: true);
        public static readonly Conversion NoConversion = new StandardConversion(nameof(NoConversion), isImplicit: true);
        public static readonly Conversion Identity = new StandardConversion(nameof(Identity), isImplicit: true);

        public static readonly Conversion ImplicitNumeric = new StandardConversion(nameof(ImplicitNumeric), isImplicit: true);
        public static readonly Conversion ImplicitNullable = new StandardConversion(nameof(ImplicitNullable), isImplicit: true);
        public static readonly Conversion ImplicitReference = new StandardConversion(nameof(ImplicitReference), isImplicit: true);
        public static readonly Conversion NullLiteral = new StandardConversion(nameof(NullLiteral), isImplicit: true);
        public static readonly Conversion DefaultLiteral = new StandardConversion(nameof(DefaultLiteral), isImplicit: true);
        public static readonly Conversion Boxing = new StandardConversion(nameof(Boxing), isImplicit: true);

        public static readonly Conversion ExplicitNumeric = new StandardConversion(nameof(ExplicitNumeric), isImplicit: false);
        public static readonly Conversion ExplicitNullable = new StandardConversion(nameof(ExplicitNullable), isImplicit: false);
        public static readonly Conversion ExplicitReference = new StandardConversion(nameof(ExplicitReference), isImplicit: false);
        public static readonly Conversion Unboxing = new StandardConversion(nameof(Unboxing), isImplicit: false);

        private readonly LanguageCompilation _compilation;

        public Conversions(LanguageCompilation compilation)
        {
            _compilation = compilation;
        }

        public LanguageCompilation Compilation => _compilation;

        public abstract Conversion ClassifyConversionFromType(TypeSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo> useSiteDiagnostics);

    }
}
