﻿using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
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

        public ICompilation CreateCompilation(BackgroundCompilation backgroundCompilation, IEnumerable<LanguageSyntaxTree> syntaxTrees, CancellationToken cancellationToken)
        {
            var metaModelReference = ModelReference.CreateFromModel(MetaInstance.MModel);
            BinderFlags binderFlags = BinderFlags.IgnoreAccessibility;
            BinderFlags binderFlags2 = BinderFlags.IgnoreMetaLibraryDuplicatedTypes;
            binderFlags = binderFlags.UnionWith(binderFlags2);
            MetaCompilationOptions options = new MetaCompilationOptions(OutputKind.NetModule,
                deterministic: true, concurrentBuild: true,
                topLevelBinderFlags: binderFlags);
            var compilation = MetaCompilation.Create("MetaBackgroundCompilation").AddReferences(metaModelReference).AddSyntaxTrees(syntaxTrees).WithOptions(options);
            return compilation;
        }

        public IEnumerable<IBackgroundCompilationStep> CreateCompilationSteps(BackgroundCompilation backgroundCompilation)
        {
            yield return new CollectSymbolsStep(backgroundCompilation);
            yield return new SymbolReferencesStep(backgroundCompilation);
        }

    }
}
