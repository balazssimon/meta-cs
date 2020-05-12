using MetaDslx.CodeAnalysis;
using MetaDslx.VisualStudio.Classification;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.Build.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Operations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MetaDslx.VisualStudio.Intellisense
{
    public class CompletionSource : ICompletionSource
    {
        private readonly MetaDslxMefServices _mefServices;
        private readonly MetaDslxCompletionSourceProvider _provider;
        private readonly ITextBuffer _textBuffer;
        private readonly BackgroundCompilation _backgroundCompilation;
        private List<Completion> _compList;

        public CompletionSource(MetaDslxMefServices mefServices, MetaDslxCompletionSourceProvider provider, ITextBuffer textBuffer)
        {
            _mefServices = mefServices;
            _provider = provider;
            _textBuffer = textBuffer;
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, textBuffer);
        }

        public static CompletionSource GetOrCreate(MetaDslxMefServices mefServices, MetaDslxCompletionSourceProvider provider, ITextBuffer textBuffer)
        {
            textBuffer.Properties.TryGetProperty<Antlr4LexerClassifier>(typeof(IClassifier), out var classifier);
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new CompletionSource(
                mefServices,
                provider,
                textBuffer
            ));
        }

        public void AugmentCompletionSession(ICompletionSession session, IList<CompletionSet> completionSets)
        {
            if (_isDisposed) throw new ObjectDisposedException("CompletionSource");

            ITextSnapshot snapshot = _textBuffer.CurrentSnapshot;
            var triggerPoint = (SnapshotPoint)session.GetTriggerPoint(snapshot);
            if (triggerPoint == null) return;

            var compilation = (LanguageCompilation)_backgroundCompilation.CompilationSnapshot.Compilation;
            if (compilation == null) return;

            var syntaxTree = (LanguageSyntaxTree)compilation.SyntaxTrees.FirstOrDefault();
            if (syntaxTree == null) return;

            SyntaxNode root;
            if (syntaxTree.TryGetRoot(out root))
            {
                var completionTexts = new HashSet<string>();
                var tokenSuggestions = syntaxTree.LookupTokens(triggerPoint.Position);
                var syntaxFacts = compilation.Language.SyntaxFacts;
                var hasIdentifier = tokenSuggestions.Any(kind => syntaxFacts.IsIdentifier(kind));
                var fixedTokens = tokenSuggestions.Where(kind => syntaxFacts.IsFixedToken(kind)).Select(kind => syntaxFacts.GetText(kind));
                completionTexts.UnionWith(fixedTokens);

                if (hasIdentifier)
                {
                    SemanticModel semanticModel = compilation.GetSemanticModel(syntaxTree);
                    INamespaceOrTypeSymbol container = null;
                    var characterAtCaret = this.GetCharacterAtCaret(triggerPoint);
                    if (characterAtCaret.GetChar() == '.')
                    {
                        var wordBeforeDot = GetWordAtPosition(characterAtCaret - 1);
                        if (wordBeforeDot.Span.Length > 0)
                        {
                            var tokenBeforeDot = root.FindToken(wordBeforeDot.Span.Start.Position);
                            if (tokenBeforeDot != null)
                            {
                                var typeInfo = semanticModel.GetTypeInfo(tokenBeforeDot.Parent);
                                if (typeInfo.Type != null && !(typeInfo.Type is IErrorTypeSymbol))
                                {
                                    container = typeInfo.Type;
                                }
                                else
                                {
                                    var symbolInfo = semanticModel.GetSymbolInfo(tokenBeforeDot.Parent);
                                    if (symbolInfo.Symbol != null)
                                    {
                                        container = symbolInfo.Symbol as INamespaceOrTypeSymbol;
                                    }
                                }
                            }
                        }
                    }
                    var symbols = semanticModel.LookupSymbols(triggerPoint.Position, container);
                    completionTexts.UnionWith(symbols.Where(symbol => !string.IsNullOrWhiteSpace(symbol.Name)).Select(symbol => symbol.Name));
                }
                SnapshotPoint start = triggerPoint;
                var applicableTo = FindTokenSpanAtPosition(triggerPoint, session);
                var completions = completionTexts.OrderBy(name => name).Select(name => new Completion(name, name, null, null, null));
                completionSets.Add(new CompletionSet("All", "All", applicableTo, completions, Enumerable.Empty<Completion>()));
            }
        }

        private ITrackingSpan FindTokenSpanAtPosition(SnapshotPoint triggerPoint, ICompletionSession session)
        {
            var bufferPosition = session.TextView.Caret.Position.BufferPosition;
            SnapshotPoint currentPoint = bufferPosition.Position > 0 ? bufferPosition - 1 : bufferPosition;
            var wordAtCaret = GetWordAtPosition(currentPoint);
            var word = wordAtCaret.Span.GetText();
            if (word.Length > 0 && char.IsLetterOrDigit(word[word.Length - 1]))
            {
                return triggerPoint.Snapshot.CreateTrackingSpan(wordAtCaret.Span, SpanTrackingMode.EdgeInclusive);
            }
            else
            {
                return triggerPoint.Snapshot.CreateTrackingSpan(new SnapshotSpan(triggerPoint, triggerPoint), SpanTrackingMode.EdgeInclusive);
            }
        }

        private TextExtent GetWordAtPosition(SnapshotPoint position)
        {
            ITextStructureNavigator navigator = _provider.NavigatorService.GetTextStructureNavigator(_textBuffer);
            TextExtent extent = navigator.GetExtentOfWord(position);
            return extent;
        }

        private SnapshotPoint GetCharacterAtCaret(SnapshotPoint triggerPoint)
        {
            SnapshotPoint start = triggerPoint;
            while (start >= 0 && char.IsWhiteSpace(start.GetChar()))
            {
                start -= 1;
            }
            return start;
        }

        #region IDisposable Support
        private bool _isDisposed;
        public void Dispose()
        {
            if (!_isDisposed)
            {
                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
        }
        #endregion
    }
}
