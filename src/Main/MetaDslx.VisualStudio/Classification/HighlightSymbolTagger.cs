using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class HighlightSymbolTagger : ITagger<ITextMarkerTag>
    {
        private object updateLock = new object();
        private readonly BackgroundCompilation _backgroundCompilation;
        private readonly TextMarkerTag _symbolDefinition;
        private readonly TextMarkerTag _symbolReference;

        public HighlightSymbolTagger(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, IWpfTextView wpfTextView, ITextBuffer sourceBuffer)
        {
            this.View = wpfTextView;
            this.SourceBuffer = sourceBuffer;
            this.SymbolDefinitionSpans = new NormalizedSnapshotSpanCollection();
            this.SymbolReferenceSpans = new NormalizedSnapshotSpanCollection();
            this.CurrentWord = null;
            this.View.Caret.PositionChanged += CaretPositionChanged;
            this.View.LayoutChanged += ViewLayoutChanged;
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, sourceBuffer);
            _symbolDefinition = new TextMarkerTag("MarkerFormatDefinition/HighlightedDefinition");
            _symbolReference = new TextMarkerTag("MarkerFormatDefinition/HighlightedReference");
        }

        public static HighlightSymbolTagger GetOrCreate(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, IWpfTextView wpfTextView)
        {
            return wpfTextView.Properties.GetOrCreateSingletonProperty(() => new HighlightSymbolTagger(
                mefServices,
                taggerProvider,
                wpfTextView,
                wpfTextView.TextBuffer
            ));
        }

        public IWpfTextView View { get; set; }
        public ITextBuffer SourceBuffer { get; set; }
        public ITextSearchService TextSearchService { get; set; }
        public ITextStructureNavigator TextStructureNavigator { get; set; }
        public NormalizedSnapshotSpanCollection SymbolDefinitionSpans { get; set; }
        public NormalizedSnapshotSpanCollection SymbolReferenceSpans { get; set; }
        public SnapshotSpan? CurrentWord { get; set; }
        public SnapshotPoint RequestedPoint { get; set; }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        private void ViewLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            // If a new snapshot wasn't generated, then skip this layout 
            if (e.NewSnapshot != e.OldSnapshot)
            {
                UpdateAtCaretPosition(View.Caret.Position);
            }
        }

        private void CaretPositionChanged(object sender, CaretPositionChangedEventArgs e)
        {
            UpdateAtCaretPosition(e.NewPosition);
        }

        private void UpdateAtCaretPosition(CaretPosition caretPosition)
        {
            SnapshotPoint? point = caretPosition.Point.GetPoint(SourceBuffer, caretPosition.Affinity);

            if (!point.HasValue)
                return;

            // If the new caret position is still within the current word (and on the same snapshot), we don't need to check it 
            if (CurrentWord.HasValue
                && CurrentWord.Value.Snapshot == View.TextSnapshot
                && point.Value >= CurrentWord.Value.Start
                && point.Value <= CurrentWord.Value.End)
            {
                return;
            }

            RequestedPoint = point.Value;
            UpdateWordAdornments();
        }

        private void UpdateWordAdornments()
        {
            SnapshotPoint currentRequest = RequestedPoint;
            List<SnapshotSpan> referenceSpans = new List<SnapshotSpan>();
            List<SnapshotSpan> definitionSpans = new List<SnapshotSpan>();
            SnapshotSpan? currentWord = null;
            ISymbol currentSymbol = null;

            _backgroundCompilation.CheckCompilationVersion();
            var compilationSnapshot = _backgroundCompilation.CompilationSnapshot;
            var symbols = compilationSnapshot?.GetCompilationStepResult<CollectSymbolsResult>();
            ITextSnapshot textSnapshot = compilationSnapshot.Text;
            if (symbols != null && textSnapshot != null)
            {
                foreach (var token in symbols.TokensWithSymbols)
                {
                    if (token.Span.Contains(currentRequest.Position))
                    {
                        currentWord = new SnapshotSpan(textSnapshot, new Span(token.Span.Start, token.Span.Length));
                        currentSymbol = symbols.GetSymbol(token);
                        break;
                    }
                }
            }

            if (currentWord == null || currentSymbol == null || currentSymbol is IErrorTypeSymbol)
            {
                //If we couldn't find a word, clear out the existing markers
                SynchronousUpdate(currentRequest, null, null, null);
                return;
            }

            //If this is the current word, and the caret moved within a word, we're done. 
            if (CurrentWord.HasValue && currentWord == CurrentWord)
                return;

            //Find the new spans
            foreach (var token in symbols.TokensWithSymbols)
            {
                var symbol = symbols.GetSymbol(token);
                if (object.Equals(symbol, currentSymbol))
                {
                    var span = new SnapshotSpan(textSnapshot, new Span(token.Span.Start, token.Span.Length));
                    if (symbol.Locations.Any(loc => loc.SourceSpan == token.Span))
                    {
                        definitionSpans.Add(span);
                    }
                    else
                    {
                        referenceSpans.Add(span);
                    }
                }
            }

            //If another change hasn't happened, do a real update 
            if (currentRequest == RequestedPoint)
                SynchronousUpdate(currentRequest, definitionSpans, referenceSpans, currentWord);
        }

        private static bool WordExtentIsValid(SnapshotPoint currentRequest, TextExtent word)
        {
            return word.IsSignificant
                && currentRequest.Snapshot.GetText(word.Span).Any(c => char.IsLetter(c));
        }

        private void SynchronousUpdate(SnapshotPoint currentRequest, List<SnapshotSpan> symbolDefinitionSpans, List<SnapshotSpan> symbolReferenceSpans, SnapshotSpan? newCurrentWord)
        {
            lock (updateLock)
            {
                if (currentRequest != RequestedPoint)
                    return;

                SymbolDefinitionSpans = symbolDefinitionSpans != null && symbolDefinitionSpans.Count > 0 ? new NormalizedSnapshotSpanCollection(symbolDefinitionSpans) : new NormalizedSnapshotSpanCollection();
                SymbolReferenceSpans = symbolReferenceSpans != null && symbolReferenceSpans.Count > 0 ? new NormalizedSnapshotSpanCollection(symbolReferenceSpans) : new NormalizedSnapshotSpanCollection(); 
                CurrentWord = newCurrentWord;

                var tempEvent = TagsChanged;
                if (tempEvent != null)
                {
                    tempEvent(this, new SnapshotSpanEventArgs(new SnapshotSpan(SourceBuffer.CurrentSnapshot, 0, SourceBuffer.CurrentSnapshot.Length)));
                }
            }
        }

        public IEnumerable<ITagSpan<ITextMarkerTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (CurrentWord == null)
                yield break;

            // Hold on to a "snapshot" of the word spans and current word, so that we maintain the same
            // collection throughout
            SnapshotSpan currentWord = CurrentWord.Value;
            NormalizedSnapshotSpanCollection definitionSpans = SymbolDefinitionSpans;
            NormalizedSnapshotSpanCollection referenceSpans = SymbolReferenceSpans;

            if (spans.Count == 0 || (definitionSpans.Count == 0 && referenceSpans.Count == 0))
                yield break;

            // If the requested snapshot isn't the same as the one our words are on, translate our spans to the expected snapshot 
            if (spans[0].Snapshot != currentWord.Snapshot)
            {
                definitionSpans = new NormalizedSnapshotSpanCollection(
                    definitionSpans.Select(span => span.TranslateTo(spans[0].Snapshot, SpanTrackingMode.EdgeExclusive)));
                referenceSpans = new NormalizedSnapshotSpanCollection(
                    referenceSpans.Select(span => span.TranslateTo(spans[0].Snapshot, SpanTrackingMode.EdgeExclusive)));
            }

            foreach (SnapshotSpan span in NormalizedSnapshotSpanCollection.Overlap(spans, definitionSpans))
            {
                yield return new TagSpan<ITextMarkerTag>(span, _symbolDefinition);
            }
            foreach (SnapshotSpan span in NormalizedSnapshotSpanCollection.Overlap(spans, referenceSpans))
            {
                yield return new TagSpan<ITextMarkerTag>(span, _symbolReference);
            }
        }
    }
}
