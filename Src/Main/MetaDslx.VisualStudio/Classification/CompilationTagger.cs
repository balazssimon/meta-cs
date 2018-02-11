using MetaDslx.Compiler;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal abstract class CompilationTagger : IDisposable
    {
        private CompilationTaggerProvider taggerProvider;
        private BackgroundCompilation backgroundCompilation;

        public CompilationTagger(CompilationTaggerProvider taggerProvider, BackgroundCompilation backgroundCompilation)
        {
            this.taggerProvider = taggerProvider;
            this.backgroundCompilation = backgroundCompilation;
            this.backgroundCompilation.CompilationChanged += CompilationChanged;
        }

        protected virtual void CompilationChanged(object sender, CompilationChangedEventArgs e)
        {
            ITextSnapshot textSnapshot = e.NewCompilation.Text;
            this.TagsChanged?.Invoke(this, new SnapshotSpanEventArgs(new SnapshotSpan(textSnapshot, Span.FromBounds(0, textSnapshot.Length))));
        }

        public virtual void Dispose()
        {
        }

        public CompilationTaggerProvider TaggerProvider
        {
            get { return this.taggerProvider; }
        }

        public BackgroundCompilation BackgroundCompilation
        {
            get { return this.backgroundCompilation; }
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

    }
}
