﻿using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IGeneratedSymbolFactory
    {
        Symbol? CreateMetadataSymbol(Symbol container, object? modelObject);
        Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, object? modelObject, DiagnosticInfo? errorInfo);
        Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject);
        Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo? errorInfo);
    }
}
