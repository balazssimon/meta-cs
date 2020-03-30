using MetaDslx.CodeAnalysis;
using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Compilation
{
    public sealed class CollectSymbolsStep : IBackgroundCompilationStep
    {
        public const string Key = "MetaDslx.CollectSymbols";

        private BackgroundCompilation _backgroundCompilation;
        private List<CompilationTaggerProvider> _taggers;

        public CollectSymbolsStep(BackgroundCompilation backgroundCompilation) 
        {
            _backgroundCompilation = backgroundCompilation;
            _taggers = _backgroundCompilation.MefServices.GetExtensions<IViewTaggerProvider>(_backgroundCompilation.TextBuffer.ContentType).OfType<CompilationTaggerProvider>().ToList();
        }

        public object ResultKey => Key;

        public object Execute(ICompilation compilation, CancellationToken cancellationToken)
        {
            var result = new Dictionary<SyntaxToken, IClassificationTag>();
            var languageCompilation = (LanguageCompilation)compilation;
            SyntaxTree syntaxTree = languageCompilation.SyntaxTrees.FirstOrDefault();
            if (syntaxTree == null || _taggers.Count == 0) return result;
            SyntaxNode root;
            if (syntaxTree.TryGetRoot(out root))
            {
                SemanticModel semanticModel = languageCompilation.GetSemanticModel(syntaxTree);
                foreach (var token in root.DescendantTokens())
                {
                    if (cancellationToken.IsCancellationRequested) return null;
                    if (languageCompilation.Language.SyntaxFacts.IsIdentifier(token.GetKind()))
                    {
                        var tag = this.GetSymbolClassificationTag(token, semanticModel, cancellationToken);
                        if (tag != null)
                        {
                            result.Add(token, tag);
                        }
                    }
                }
            }
            return result;
        }

        private IClassificationTag GetSymbolClassificationTag(SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            SyntaxNode node = token.Parent;
            while (node != null && node.SlotCount == 1)
            {
                if (cancellationToken.IsCancellationRequested) return null;
                foreach (var tagger in _taggers)
                {
                    var tag = tagger.GetSymbolClassificationTag(node, semanticModel, cancellationToken);
                    if (tag != null) return tag;
                }
                node = node.Parent;
            }
            return null;
        }

    }
}
