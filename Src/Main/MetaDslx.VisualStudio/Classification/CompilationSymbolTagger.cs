using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using Microsoft.VisualStudio.Text;
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
    internal class CompilationSymbolTagger : CompilationTagger, ITagger<IClassificationTag>
    {
        public CompilationSymbolTagger(CompilationTaggerProvider taggerProvider, BackgroundCompilation backgroundCompilation)
            : base(taggerProvider, backgroundCompilation)
        {

        }

        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            this.BackgroundCompilation.CheckCompilationVersion();
            var compilationSnapshot = this.BackgroundCompilation.CompilationSnapshot;
            var compilation = compilationSnapshot.Compilation;
            if (compilation == null) return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
            SyntaxTree syntaxTree = compilationSnapshot.Compilation.SyntaxTrees.FirstOrDefault();
            if (syntaxTree == null) return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
            ITextSnapshot textSnapshot = compilationSnapshot.Text;
            if (textSnapshot == null || spans.Count == 0 || spans.First().Snapshot.Version != textSnapshot.Version) return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
            SyntaxNode root;
            if (syntaxTree.TryGetRoot(out root))
            {
                SnapshotSpan firstSpan = spans.First();
                SnapshotSpan lastSpan = spans.Last();
                int firstPos = firstSpan.Start.Position;
                int lastPos = lastSpan.End.Position;
                if (lastPos > root.FullSpan.End) lastPos = root.FullSpan.End;
                SyntaxNode node = root.FindNode(Compiler.Text.TextSpan.FromBounds(firstPos, lastPos), getInnermostNodeForTie: true);
                if (node != null)
                {
                    var symbolTokens = compilationSnapshot.SymbolTokens;
                    SemanticModel semanticModel = compilation.GetSemanticModel(syntaxTree);
                    var tokens = node.DescendantTokens().Where(t => symbolTokens.ContainsKey(t));
                    return tokens.Select(t => new TagSpan<IClassificationTag>(new SnapshotSpan(textSnapshot, new Span(t.Span.Start, t.Span.Length)), symbolTokens[t]));
                }
            }
            return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
        }


    }
}
