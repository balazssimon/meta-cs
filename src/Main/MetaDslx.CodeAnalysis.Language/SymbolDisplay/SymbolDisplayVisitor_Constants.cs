﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Reflection;

namespace Microsoft.CodeAnalysis.CSharp
{
    public partial class SymbolDisplayVisitor
    {
        private void AddConstantValue(ITypeSymbol type, object constantValue, bool preferNumericValueOrExpandedFlagsForEnum = false)
        {
            if (constantValue != null)
            {
                AddNonNullConstantValue(type, constantValue, preferNumericValueOrExpandedFlagsForEnum);
            }
        }

        protected override void AddExplicitlyCastedLiteralValue(INamedTypeSymbol namedType, SpecialType type, object value)
        {
            AddLiteralValue(type, value);
        }

        protected override void AddLiteralValue(SpecialType type, object value)
        {
            Debug.Assert(value.GetType().GetTypeInfo().IsPrimitive || value is string || value is decimal);
            var valueString = SymbolDisplay.FormatPrimitive(value, quoteStrings: true, useHexadecimalNumbers: false);
            Debug.Assert(valueString != null);

            var kind = SymbolDisplayPartKind.NumericLiteral;
            switch (type)
            {
                case SpecialType.System_Boolean:
                    kind = SymbolDisplayPartKind.Keyword;
                    break;

                case SpecialType.System_String:
                case SpecialType.System_Char:
                    kind = SymbolDisplayPartKind.StringLiteral;
                    break;
            }

            this.builder.Add(CreatePart(kind, null, valueString));
        }

        protected override void AddBitwiseOr()
        {
        }

        protected override void AddSpace()
        {
        }

        protected override bool ShouldRestrictMinimallyQualifyLookupToNamespacesAndTypes()
        {
            return true;
        }
    }
}
