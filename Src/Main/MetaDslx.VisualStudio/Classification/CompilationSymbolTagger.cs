using MetaDslx.Compiler;
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
    public class CompilationSymbolTagger : CompilationTagger, ITagger<IClassificationTag>
    {
        public CompilationSymbolTagger(CompilationTaggerProvider taggerProvider, ITextView textView, ITextBuffer buffer)
            : base(taggerProvider, textView, buffer)
        {

        }

        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            this.CheckCompilationVersion();
            return ImmutableArray<ITagSpan<IClassificationTag>>.Empty;
        }

        protected override void CompilationUpdated(ITextSnapshot newTextSnapshot, Compilation newCompilation, ITextSnapshot oldTextSnapshot, Compilation oldCompilation)
        {
            
        }
    }
}
