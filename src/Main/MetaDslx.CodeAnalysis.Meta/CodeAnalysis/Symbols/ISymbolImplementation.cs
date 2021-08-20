using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface ISymbolImplementation
    {
        void CompleteImports(Symbol symbol, Location locationOpt, DiagnosticBag diagnostics, CancellationToken cancellationToken);

        ImmutableArray<Symbol> MakeGlobalSymbols(Symbol rootSymbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken);

        ImmutableArray<Symbol> MakeChildSymbols(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken);

        bool AssignSymbolPropertyValue<T>(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken, out T? value);

        bool AssignSymbolPropertyValues<T>(Symbol symbol, string symbolPropertyName, DiagnosticBag diagnostics, CancellationToken cancellationToken, out ImmutableArray<T> value);

        string AssignNameProperty(Symbol symbol, DiagnosticBag diagnostics);

        string AssignMetadataNameProperty(Symbol symbol, DiagnosticBag diagnostics);

        void AssignNonSymbolProperties(Symbol symbol, DiagnosticBag diagnostics, CancellationToken cancellationToken);

    }
}
