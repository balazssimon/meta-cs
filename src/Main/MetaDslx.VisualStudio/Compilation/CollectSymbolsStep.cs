using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Text.Classification;
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
        private BackgroundCompilation _backgroundCompilation;
        private List<MetaDslxTaggerProvider> _taggers;

        public CollectSymbolsStep(BackgroundCompilation backgroundCompilation) 
        {
            _backgroundCompilation = backgroundCompilation;
            _taggers = _backgroundCompilation.MefServices.GetExtensions<IViewTaggerProvider>(_backgroundCompilation.TextBuffer.ContentType).OfType<MetaDslxTaggerProvider>().ToList();
        }

        public object ResultKey => typeof(CollectSymbolsResult);

        public object Execute(ICompilation compilation, CancellationToken cancellationToken)
        {
            var result = new CollectSymbolsResult();
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
                        var symbol = this.GetSymbol(token, semanticModel, cancellationToken);
                        if (symbol != null)
                        {
                            var tagType = this.GetSymbolClassificationType(symbol, token, semanticModel, cancellationToken);
                            result.Add(token, new CollectSymbolsResult.SymbolData(symbol, tagType));
                        }
                    }
                }
            }
            return result;
        }

        private ISymbol GetSymbol(SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            SyntaxNode node = token.Parent;
            while (node != null && node.SlotCount == 1)
            {
                if (cancellationToken.IsCancellationRequested) return null;
                var ti = semanticModel.GetTypeInfo(node, cancellationToken);
                if (ti.Type != null) return ti.Type;
                var si = semanticModel.GetSymbolInfo(node, cancellationToken);
                if (si.Symbol != null) return si.Symbol;
                node = node.Parent;
            }
            return null;
        }

        private IClassificationType GetSymbolClassificationType(ISymbol symbol, SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            foreach (var tagger in _taggers)
            {
                if (cancellationToken.IsCancellationRequested) return null;
                var tagType = tagger.GetSymbolClassificationType(symbol, token, semanticModel, cancellationToken);
                if (tagType != null) return tagType;
            }
            return null;
        }
    }

    public class CollectSymbolsResult
    {
        private Dictionary<SyntaxToken, SymbolData> _symbols;

        public CollectSymbolsResult()
        {
            _symbols = new Dictionary<SyntaxToken, SymbolData>();
        }

        internal void Add(SyntaxToken token, SymbolData data)
        {
            _symbols.Add(token, data);
        }

        public IEnumerable<SyntaxToken> TokensWithSymbols => _symbols.Keys;

        public IClassificationType GetClassificationType(SyntaxToken token)
        {
            if (_symbols.TryGetValue(token, out var result)) return result.ClassificationType;
            else return null;
        }

        public ISymbol GetSymbol(SyntaxToken token)
        {
            if (_symbols.TryGetValue(token, out var result)) return result.Symbol;
            else return null;
        }

        internal struct SymbolData
        {
            public SymbolData(ISymbol symbol, IClassificationType classificationType)
            {
                Symbol = symbol;
                ClassificationType = classificationType;
            }

            public ISymbol Symbol { get; }
            public IClassificationType ClassificationType { get; }
        }
    }

}
