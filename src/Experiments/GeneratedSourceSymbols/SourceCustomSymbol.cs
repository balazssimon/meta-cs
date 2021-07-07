using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GeneratedSourceSymbols.Source
{
    public partial class SourceCustomSymbol
    {
        [Phase(Locked = false)]
        protected virtual void CompleteFirst(CancellationToken cancellationToken)
        {
            var syntax = this.DeclaringSyntaxReferences[0].GetSyntax();
            var compilation = this.DeclaringCompilation;
            var binder = compilation.GetBinder(syntax);
            var diagnostics = DiagnosticBag.GetInstance();
            binder.Bind(diagnostics, cancellationToken);
            AddSymbolDiagnostics(diagnostics);
            diagnostics.Free();
        }

        [Phase(Locked = true)]
        protected virtual void CompleteSecond(CancellationToken cancellationToken)
        {
            var syntax = this.DeclaringSyntaxReferences[0].GetSyntax();
            var compilation = this.DeclaringCompilation;
            var binder = compilation.GetBinder(syntax);
            var diagnostics = DiagnosticBag.GetInstance();
            binder.Bind(diagnostics, cancellationToken);
            AddSymbolDiagnostics(diagnostics);
            diagnostics.Free();
        }
    }
}
