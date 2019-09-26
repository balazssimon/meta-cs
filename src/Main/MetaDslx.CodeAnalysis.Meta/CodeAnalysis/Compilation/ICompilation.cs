using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    public interface ICompilation
    {
        void ForceComplete(CancellationToken cancellationToken = default);
        ImmutableArray<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default);
    }
}
