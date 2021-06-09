using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;

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
                var semanticModel = (LanguageSemanticModel)languageCompilation.GetSemanticModel(syntaxTree);
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

        private Symbol GetSymbol(SyntaxToken token, LanguageSemanticModel semanticModel, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested) return null;
                var si = semanticModel.GetSymbolInfo(token, cancellationToken);
                return si.Symbol;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        private IClassificationType GetSymbolClassificationType(Symbol symbol, SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken)
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

        public Symbol GetSymbol(SyntaxToken token)
        {
            if (_symbols.TryGetValue(token, out var result)) return result.Symbol;
            else return null;
        }

        internal struct SymbolData
        {
            public SymbolData(Symbol symbol, IClassificationType classificationType)
            {
                Symbol = symbol;
                ClassificationType = classificationType;
            }

            public Symbol Symbol { get; }
            public IClassificationType ClassificationType { get; }
        }
    }

}
