using Antlr4.Runtime;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
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
        Language Language { get; }
        ICompilation CreateCompilation(BackgroundCompilation backgroundCompilation, IEnumerable<LanguageSyntaxTree> syntaxTrees, CancellationToken cancellationToken);
        IEnumerable<IBackgroundCompilationStep> CreateCompilationSteps(BackgroundCompilation backgroundCompilation);
    }
}
