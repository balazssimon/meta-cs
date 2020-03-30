using MetaDslx.CodeAnalysis;
using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Compilation
{
    public interface IBackgroundCompilationStep
    {
        object ResultKey { get; }
        object Execute(ICompilation compilation, CancellationToken cancellationToken);
    }
}
