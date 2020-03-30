using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.VisualStudio.Compilation;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Languages.Meta.Compilation
{
    [Export(typeof(IBackgroundCompilationFactory))]
    [ContentType(MetaDefinition.ContentType)]
    internal sealed class MetaBackgroundCompilationFactory : IBackgroundCompilationFactory
    {
        public ICompilation CreateCompilation(BackgroundCompilation backgroundCompilation, string filePath, string sourceText, CancellationToken cancellationToken)
        {
            var metaModelReference = ModelReference.CreateFromModel(MetaInstance.MModel);
            var tree = MetaSyntaxTree.ParseText(sourceText, path: filePath, cancellationToken: cancellationToken);
            BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
            BinderFlags binderFlags2 = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
            binderFlags = binderFlags.UnionWith(binderFlags2);
            MetaCompilationOptions options = new MetaCompilationOptions(MetaLanguage.Instance, OutputKind.NetModule,
                deterministic: true, concurrentBuild: true,
                topLevelBinderFlags: binderFlags);
            var compilation = MetaCompilation.Create("MetaBackgroundCompilation").AddReferences(metaModelReference).AddSyntaxTrees(tree).WithOptions(options);
            return compilation;
        }

        public IEnumerable<IBackgroundCompilationStep> CreateCompilationSteps(BackgroundCompilation backgroundCompilation)
        {
            yield return new CollectSymbolsStep(backgroundCompilation);
        }
    }
}
