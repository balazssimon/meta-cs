// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal sealed class UnsupportedMetadataTypeSymbol : ErrorTypeSymbol
    {
        private readonly BadImageFormatException _mrEx;

        internal UnsupportedMetadataTypeSymbol(BadImageFormatException mrEx = null)
        {
            _mrEx = mrEx;
        }

        internal override DiagnosticInfo ErrorInfo
        {
            get
            {
                return new LanguageDiagnosticInfo(InternalErrorCode.ERR_BogusType, string.Empty);
            }
        }

        internal override bool MangleName
        {
            get
            {
                return false;
            }
        }
    }
}
