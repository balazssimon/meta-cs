using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;
using MetaDslx.VisualStudio.Compilation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.MetaGenerator.Compilation
{
    /*[Export(typeof(IBackgroundCompilationFactory))]
    [ContentType(MetaGeneratorDefinition.ContentType)]
    internal sealed class MetaGeneratorBackgroundCompilationFactory : IBackgroundCompilationFactory
    {
        public Language Language => MetaGeneratorLanguage.Instance;

        public ICompilation CreateCompilation(BackgroundCompilation backgroundCompilation, ICompilation oldCompilation, IEnumerable<LanguageSyntaxTree> syntaxTrees, CancellationToken cancellationToken)
        {
            return new MetaGeneratorCompilation(syntaxTrees);
        }

        public IEnumerable<IBackgroundCompilationStep> CreateCompilationSteps(BackgroundCompilation backgroundCompilation)
        {
            yield break;
        }

    }*/
}
