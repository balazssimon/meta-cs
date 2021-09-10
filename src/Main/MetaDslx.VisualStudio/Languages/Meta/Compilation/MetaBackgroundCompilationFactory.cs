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

namespace MetaDslx.VisualStudio.Languages.Meta.Compilation
{
    [Export(typeof(IBackgroundCompilationFactory))]
    [ContentType(MetaDefinition.ContentType)]
    internal sealed class MetaBackgroundCompilationFactory : IBackgroundCompilationFactory
    {
        public Language Language => MetaLanguage.Instance;

        public ICompilation CreateCompilation(BackgroundCompilation backgroundCompilation, ICompilation oldCompilation, IEnumerable<LanguageSyntaxTree> syntaxTrees, CancellationToken cancellationToken)
        {
            if (oldCompilation != null)
            {
                var compilation = (MetaCompilation)oldCompilation;
                compilation = compilation.RemoveAllSyntaxTrees().AddSyntaxTrees(syntaxTrees);
                return compilation;
            }
            else
            {
                var metaModelReference = ModelReference.CreateFromModel(MetaInstance.MModel);
                var symbolsReference = MetadataReference.CreateFromFile(typeof(Symbol).Assembly.Location);
                BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
                BinderFlags allowMetaConstants = BinderFlags.AllowMetaConstants;
                binderFlags = binderFlags.UnionWith(allowMetaConstants);
                //BinderFlags ignoreDuplicates = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
                //binderFlags = binderFlags.UnionWith(ignoreDuplicates);
                MetaCompilationOptions options = new MetaCompilationOptions(OutputKind.NetModule,
                    deterministic: true, concurrentBuild: false).WithTopLevelBinderFlags(binderFlags);
                var compilation = MetaCompilation.Create("MetaBackgroundCompilation").AddReferences(symbolsReference, metaModelReference).AddSyntaxTrees(syntaxTrees).WithOptions(options);
                return compilation;
            }
        }

        public IEnumerable<IBackgroundCompilationStep> CreateCompilationSteps(BackgroundCompilation backgroundCompilation)
        {
            yield return new CollectSymbolsStep(backgroundCompilation);
            yield return new SymbolReferencesStep(backgroundCompilation);
        }

    }
}
