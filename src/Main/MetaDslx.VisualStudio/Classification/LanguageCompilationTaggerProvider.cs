using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Shell.TableManager;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    public abstract class LanguageCompilationTaggerProvider : CompilationTaggerProvider
    {
        private SyntaxFacts _syntaxFacts;

        protected LanguageCompilationTaggerProvider(ITableManagerProvider provider, ITextDocumentFactoryService textDocumentFactoryService, IClassificationTypeRegistryService classificationRegistryService, Language language)
            : base(provider, textDocumentFactoryService, classificationRegistryService)
        {
            _syntaxFacts = language.SyntaxFacts;
        }

        public override Dictionary<SyntaxToken, IClassificationTag> GetSymbolTokens(ICompilation compilation, CancellationToken cancellationToken)
        {
            var languageCompilation = (LanguageCompilation)compilation;
            Dictionary<SyntaxToken, IClassificationTag> result = new Dictionary<SyntaxToken, IClassificationTag>();
            SyntaxTree syntaxTree = languageCompilation.SyntaxTrees.FirstOrDefault();
            if (syntaxTree == null) return result;
            SyntaxNode root;
            if (syntaxTree.TryGetRoot(out root))
            {
                SemanticModel semanticModel = languageCompilation.GetSemanticModel(syntaxTree);
                foreach (var token in root.DescendantTokens())
                {
                    if (cancellationToken.IsCancellationRequested) return null;
                    var tag = this.GetTokenClassificationTag(token, syntaxTree, languageCompilation, semanticModel, cancellationToken);
                    if (tag != null)
                    {
                        result.Add(token, tag);
                    }
                }
                return result;
            }
            return result;
        }

        protected virtual IClassificationTag GetTokenClassificationTag(SyntaxToken token, SyntaxTree syntaxTree, LanguageCompilation compilation, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            if (_syntaxFacts.IsIdentifier(token.GetKind()))
            {
                return this.GetSymbolClassificationTag(token, semanticModel, cancellationToken);
            }
            return null;
        }

        protected virtual IClassificationTag GetSymbolClassificationTag(SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken)
        {
            SyntaxNode node = token.Parent;
            while (node != null && node.SlotCount == 1)
            {
                if (cancellationToken.IsCancellationRequested) return null;
                var tag = this.GetSymbolClassificationTag(node, semanticModel, cancellationToken);
                if (tag != null) return tag;
                node = node.Parent;
            }
            return null;
        }

        protected abstract IClassificationTag GetSymbolClassificationTag(SyntaxNode node, SemanticModel semanticModel, CancellationToken cancellationToken);
    }
}
