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
    public interface IBackgroundCompilationFactory
    {
        ICompilation CreateCompilation(BackgroundCompilation backgroundCompilation, string filePath, string sourceText, CancellationToken cancellationToken);
        IEnumerable<IBackgroundCompilationStep> CreateCompilationSteps(BackgroundCompilation backgroundCompilation);
    }
}
