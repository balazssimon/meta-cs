using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Utilities;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Text;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    public abstract class TokenClassifier : IClassifier
    {
        private readonly ITextBuffer _textBuffer;
        private readonly BackgroundCompilation _backgroundCompilation;
        private readonly IClassificationTypeRegistryService _classificationRegistryService;
        private readonly IStandardClassificationService _standardClassificationService;

        public TokenClassifier(ITextBuffer textBuffer, MetaDslxMefServices mefServices)
        {
            _textBuffer = textBuffer;
            _classificationRegistryService = mefServices.GetService<IClassificationTypeRegistryService>();
            _standardClassificationService = mefServices.GetService<IStandardClassificationService>();
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, _textBuffer);
        }

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

        public IClassificationTypeRegistryService ClassificationTypeRegistryService => _classificationRegistryService;
        public IStandardClassificationService StandardClassificationService => _standardClassificationService;
        public ITextBuffer TextBuffer => _textBuffer;
        public BackgroundCompilation BackgroundCompilation => _backgroundCompilation;

        //public static TokenClassifier GetOrCreate(MetaDslxMefServices mefServices, MetaDslxTaggerProvider taggerProvider, ITextBuffer textBuffer)
        //{
        //    return textBuffer.Properties.GetOrCreateSingletonProperty(() => new TokenClassifier(textBuffer, mefServices));
        //}

        //Invoke ClassificationChanged that cause editor to re-classify specified span 
        internal protected void Invalidate(SnapshotSpan span)
        {
            if (ClassificationChanged != null) ClassificationChanged(this, new ClassificationChangedEventArgs(span));
        }

        protected abstract IClassificationType GetClassificationType(SyntaxKind tokenKind);

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            List<ClassificationSpan> result = new List<ClassificationSpan>();
            var compilationSnapshot = this.BackgroundCompilation.CompilationSnapshot;
            var syntaxTree = compilationSnapshot.SyntaxTree;
            if (syntaxTree == null) return result;
            var root = (LanguageSyntaxNode)syntaxTree.GetRoot();
            var startPosition = span.Span.Start;
            var endPosition = span.Span.End;
            if (startPosition < 0) startPosition = 0;
            if (endPosition > root.FullSpan.End) endPosition = root.FullSpan.End;
            if (endPosition <= startPosition) return result;
            foreach (var token in GetTokens(root.Green, new TextSpan(startPosition, endPosition)))
            {
                if (token.Span.Length > 0)
                {
                    var classificationType = GetClassificationType(token.Token.GetKind());
                    result.Add(new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(token.Span.Start, token.Span.Length)), classificationType));
                }
            }
            return result;
        }

        private IEnumerable<(GreenNode Token, TextSpan Span)> GetTokens(GreenNode node, TextSpan span)
        {
            if (node == null) yield break;
            var stack = new Stack<(GreenNode green, TextSpan span)>();
            stack.Push((node, new TextSpan(0, node.FullWidth)));
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (top.green.IsToken)
                {
                    yield return top;
                }
                else
                {
                    var end = top.span.End;
                    for (int i = top.green.SlotCount - 1; i >= 0; --i)
                    {
                        var slot = top.green.GetSlot(i);
                        var start = end - slot.FullWidth;
                        var childSpan = new TextSpan(start, end);
                        if (span.IntersectsWith(childSpan)) stack.Push((slot, childSpan));
                        end = start;
                    }
                }
            }
        }
    }
}
