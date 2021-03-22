// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;
using System.Threading;
using MetaDslx.CodeAnalysis.CSharp.Symbols;

namespace MetaDslx.CodeAnalysis.CSharp
{
    internal sealed class LazyArrayElementCantBeRefAnyDiagnosticInfo : LazyDiagnosticInfo
    {
        private readonly TypeWithAnnotations _possiblyRestrictedTypeSymbol;

        internal LazyArrayElementCantBeRefAnyDiagnosticInfo(TypeWithAnnotations possiblyRestrictedTypeSymbol)
        {
            _possiblyRestrictedTypeSymbol = possiblyRestrictedTypeSymbol;
        }

        protected override DiagnosticInfo ResolveInfo()
        {
            if (_possiblyRestrictedTypeSymbol.IsRestrictedType())
            {
                return new CSDiagnosticInfo(ErrorCode.ERR_ArrayElementCantBeRefAny, _possiblyRestrictedTypeSymbol.Type);
            }

            return null;
        }
    }
}
