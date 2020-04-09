using MetaDslx.VisualStudio.Commands;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class SymbolTagger : CompilationTagger, ITagger<IClassificationTag>
    {
        private readonly MetaDslxMouseProcessor _mouseProcessor;
        private readonly MetaDslxKeyProcessor _keyProcessor;
        private readonly IClassificationTag _goToDefinitionLinkTag;
        private readonly Dictionary<IClassificationType, IClassificationTag> _tagsByType;
        private int _mousePosition;
        private bool _ctrlDown;
        private SnapshotSpan? _goToDefinitionLinkSpan;
        private SyntaxToken? _goToDefinitionToken;

        public SymbolTagger(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, IWpfTextView wpfTextView)
            : base(mefServices, taggerProvider, wpfTextView)
        {
            _mouseProcessor = MetaDslxMouseProcessor.GetOrCreate(mefServices, wpfTextView);
            _mouseProcessor.MousePositionInTextChanged += MousePositionInTextChanged;
            _keyProcessor = MetaDslxKeyProcessor.GetOrCreate(mefServices, wpfTextView);
            _keyProcessor.CtrlKeyChanged += CtrlKeyChanged;
            var classificationRegistry = mefServices.ComponentModel.GetService<IClassificationTypeRegistryService>();
            if (classificationRegistry != null)
            {
                _goToDefinitionLinkTag = new ClassificationTag(classificationRegistry.GetClassificationType(StandardClassificationTypeNames.UrlHyperlink));
            }
            _tagsByType = new Dictionary<IClassificationType, IClassificationTag>();
        }

        public static SymbolTagger GetOrCreate(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, IWpfTextView wpfTextView)
        {
            return wpfTextView.Properties.GetOrCreateSingletonProperty(() => new SymbolTagger(
                mefServices,
                taggerProvider,
                wpfTextView
            ));
        }

        public SyntaxToken? GoToDefinitionToken => _goToDefinitionToken;

        private void CtrlKeyChanged(object sender, CtrlKeyChangedEventArgs e)
        {
            if (e.IsDown != _ctrlDown)
            {
                _ctrlDown = e.IsDown;
                this.UpdateGoToDefinitionLink();
            }
        }

        private void MousePositionInTextChanged(object sender, MousePositionChangedEventArgs e)
        {
            if (e.NewPosition != _mousePosition)
            {
                _mousePosition = e.NewPosition;
                this.UpdateGoToDefinitionLink();
            }
        }

        private void UpdateGoToDefinitionLink()
        {
            if (!_ctrlDown && _mousePosition < 0 && _goToDefinitionLinkSpan == null) return;
            var updatedSpans = ArrayBuilder<SnapshotSpan>.GetInstance();
            if (_goToDefinitionLinkSpan != null) updatedSpans.Add(_goToDefinitionLinkSpan.Value);
            var foundNew = false;
            if (_ctrlDown && _mousePosition >= 0)
            {
                this.BackgroundCompilation.CheckCompilationVersion();
                var compilationSnapshot = this.BackgroundCompilation.CompilationSnapshot;
                var symbols = compilationSnapshot?.GetCompilationStepResult<CollectSymbolsResult>();
                ITextSnapshot textSnapshot = compilationSnapshot.Text;
                if (symbols != null && textSnapshot != null)
                {
                    foreach (var token in symbols.TokensWithSymbols)
                    {
                        if (token.Span.Contains(_mousePosition))
                        {
                            var tokenSpan = new SnapshotSpan(textSnapshot, new Span(token.Span.Start, token.Span.Length));
                            if (tokenSpan == _goToDefinitionLinkSpan)
                            {
                                updatedSpans.Free();
                                return;
                            }
                            updatedSpans.Add(tokenSpan);
                            _goToDefinitionLinkSpan = tokenSpan;
                            _goToDefinitionToken = token;
                            foundNew = true;
                            break;
                        }
                    }
                }
            }
            if (!foundNew)
            {
                _goToDefinitionLinkSpan = null;
                _goToDefinitionToken = null;
            }
            this.OnTagsChanged(updatedSpans.ToArrayAndFree());
        }


        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            this.BackgroundCompilation.CheckCompilationVersion();
            var compilationSnapshot = this.BackgroundCompilation.CompilationSnapshot;
            var symbols = compilationSnapshot?.GetCompilationStepResult<CollectSymbolsResult>();
            if (symbols == null) yield break;
            ITextSnapshot textSnapshot = compilationSnapshot.Text;
            if (textSnapshot == null || spans.Count == 0 || spans.First().Snapshot.Version != textSnapshot.Version) yield break;
            foreach (var token in symbols.TokensWithSymbols)
            {
                var tokenSpan = new SnapshotSpan(textSnapshot, new Span(token.Span.Start, token.Span.Length));
                if (spans.IntersectsWith(tokenSpan))
                {
                    if (tokenSpan == _goToDefinitionLinkSpan)
                    {
                        yield return new TagSpan<IClassificationTag>(tokenSpan, _goToDefinitionLinkTag);
                    }
                    else
                    {
                        var tagType = symbols.GetClassificationType(token);
                        if (tagType != null) yield return new TagSpan<IClassificationTag>(tokenSpan, this.GetTag(tagType));
                    }
                }
            }
        }

        private IClassificationTag GetTag(IClassificationType tagType)
        {
            if (tagType == null) throw new ArgumentNullException(nameof(tagType));
            if (!_tagsByType.TryGetValue(tagType, out var tag))
            {
                tag = new ClassificationTag(tagType);
                _tagsByType.Add(tagType, tag);
            }
            return tag;
        }
    }
}
