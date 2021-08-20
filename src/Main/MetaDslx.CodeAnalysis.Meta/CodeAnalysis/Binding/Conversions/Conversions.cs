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
        public static readonly Conversion ImplicitValue = new StandardConversion(nameof(ImplicitValue), isImplicit: true);
        public static readonly Conversion ImplicitReference = new StandardConversion(nameof(ImplicitReference), isImplicit: true);
        public static readonly Conversion ImplicitDynamic = new StandardConversion(nameof(ImplicitDynamic), isImplicit: true);
        public static readonly Conversion ImplicitNullable = new StandardConversion(nameof(ImplicitNullable), isImplicit: true);
        public static readonly Conversion NullLiteral = new StandardConversion(nameof(NullLiteral), isImplicit: true);
        public static readonly Conversion DefaultLiteral = new StandardConversion(nameof(DefaultLiteral), isImplicit: true);
        public static readonly Conversion Boxing = new StandardConversion(nameof(Boxing), isImplicit: true);
        public static readonly Conversion ConditionalExpression = new StandardConversion(nameof(ConditionalExpression), isImplicit: true);

        public static readonly Conversion ExplicitNumeric = new StandardConversion(nameof(ExplicitNumeric), isImplicit: false);
        public static readonly Conversion ExplicitValue = new StandardConversion(nameof(ExplicitValue), isImplicit: false);
        public static readonly Conversion ExplicitReference = new StandardConversion(nameof(ExplicitReference), isImplicit: false);
        public static readonly Conversion ExplicitDynamic = new StandardConversion(nameof(ExplicitDynamic), isImplicit: false);
        public static readonly Conversion ExplicitNullable = new StandardConversion(nameof(ExplicitNullable), isImplicit: false);
        public static readonly Conversion Unboxing = new StandardConversion(nameof(Unboxing), isImplicit: false);

        private readonly LanguageCompilation _compilation;

        public Conversions(LanguageCompilation compilation)
        {
            _compilation = compilation;
        }

        public LanguageCompilation Compilation => _compilation;

        public abstract Conversion ClassifyConversionFromType(TypeSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo>? useSiteDiagnostics);

        public virtual Conversion ClassifyImplicitConversionFromType(TypeSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo>? useSiteDiagnostics)
        {
            var kind = ClassifyConversionFromType(source, target, ref useSiteDiagnostics);
            if (kind.IsImplicit) return kind;
            else return NoConversion;
        }

        public virtual bool HasIdentityConversion(TypeSymbol source, TypeSymbol target)
        {
            HashSet<DiagnosticInfo>? useSiteDiagnostics = null;
            var kind = ClassifyConversionFromType(source, target, ref useSiteDiagnostics);
            return kind == Identity;
        }

        public abstract Conversion ClassifyConversionFromExpression(ExpressionSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo>? useSiteDiagnostics);

        public virtual Conversion ClassifyImplicitConversionFromExpression(ExpressionSymbol source, TypeSymbol target, ref HashSet<DiagnosticInfo>? useSiteDiagnostics)
        {
            var kind = ClassifyConversionFromExpression(source, target, ref useSiteDiagnostics);
            if (kind.IsImplicit) return kind;
            else return NoConversion;
        }

        // Spec 7.6.5.2: "An extension method ... is eligible if ... [an] implicit identity, reference,
        // or boxing conversion exists from expr to the type of the first parameter"
        public Conversion ClassifyImplicitExtensionMethodThisArgConversion(ExpressionSymbol sourceExpressionOpt, TypeSymbol sourceType, TypeSymbol destination, ref HashSet<DiagnosticInfo>? useSiteDiagnostics)
        {
            Debug.Assert(sourceExpressionOpt == null || (object)sourceExpressionOpt.Type == sourceType);
            Debug.Assert((object)destination != null);

            if ((object)sourceType != null)
            {
                var kind = ClassifyConversionFromType(sourceType, destination, ref useSiteDiagnostics);
                if (kind == Identity || kind == Boxing || kind == ImplicitReference) return kind;
            }
            return NoConversion;
        }

        // It should be possible to remove IsValidExtensionMethodThisArgConversion
        // since ClassifyImplicitExtensionMethodThisArgConversion should only
        // return valid conversions. https://github.com/dotnet/roslyn/issues/19622

        // Spec 7.6.5.2: "An extension method ... is eligible if ... [an] implicit identity, reference,
        // or boxing conversion exists from expr to the type of the first parameter"
        public static bool IsValidExtensionMethodThisArgConversion(Conversion conversion)
        {
            if (conversion == Identity || conversion == Boxing || conversion == ImplicitReference) return true;
            // Caller should have not have calculated another conversion.
            Debug.Assert(conversion == NoConversion);
            return false;
        }
    }
}
