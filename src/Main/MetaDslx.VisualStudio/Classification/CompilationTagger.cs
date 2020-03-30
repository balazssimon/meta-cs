using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal abstract class CompilationTagger : IDisposable
    {
        private ITextView textView;
        private CompilationTaggerProvider taggerProvider;
        private BackgroundCompilation backgroundCompilation;

        public CompilationTagger(CompilationTaggerProvider taggerProvider, ITextView textView)
        {
            this.taggerProvider = taggerProvider;
            this.textView = textView;
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
            get 
            {
                if (this.backgroundCompilation == null)
                {
                    this.backgroundCompilation = BackgroundCompilation.GetOrCreate(taggerProvider.MefServices, textView);
                    this.backgroundCompilation.CompilationChanged += CompilationChanged;
                }
                return this.backgroundCompilation; 
            }
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

    }
}
