using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Bootstrap.SourceGenerators
{
    [SourceSymbol]
    public partial class CustomSymbol : Symbol, ISourceSymbol
    {
        [Phase(false)]
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

        [Phase(true)]
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
