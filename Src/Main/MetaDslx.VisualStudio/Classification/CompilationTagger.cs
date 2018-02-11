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
    public abstract class CompilationTagger : IDisposable
    {
        protected readonly CompilationTaggerProvider TaggerProvider;
        protected readonly ITextBuffer TextBuffer;
        protected readonly ITextView TextView;
        private CancellationTokenSource cancellationTokenSource;
        private ITextSnapshot textSnapshot;
        private Compilation compilation;

        public CompilationTagger(CompilationTaggerProvider taggerProvider, ITextView textView, ITextBuffer buffer)
        {
            this.TaggerProvider = taggerProvider;
            this.TextBuffer = buffer;
            this.TextView = textView;
            this.cancellationTokenSource = new CancellationTokenSource();
        }

        public virtual void Dispose()
        {
            this.cancellationTokenSource.Dispose();
        }

        public ITextSnapshot TextSnapshot
        {
            get { return this.textSnapshot; }
        }

        public Compilation Compilation
        {
            get { return this.compilation; }
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        protected void CheckCompilationVersion()
        {
            ITextVersion oldVersion = this.TextSnapshot?.Version;
            ITextVersion newVersion = this.TextBuffer.CurrentSnapshot.Version;
            if (oldVersion != newVersion)
            {
                this.cancellationTokenSource.Cancel();
                this.cancellationTokenSource.Dispose();
                this.cancellationTokenSource = new CancellationTokenSource();
                var errorTagger = this.TextBuffer.Properties.GetOrCreateSingletonProperty(typeof(CompilationErrorTagger), () => new CompilationErrorTagger(this.TaggerProvider, this.TextView, this.TextBuffer));
                var symbolTagger = this.TextBuffer.Properties.GetOrCreateSingletonProperty(typeof(CompilationSymbolTagger), () => new CompilationSymbolTagger(this.TaggerProvider, this.TextView, this.TextBuffer));
                CompilationManager.Instance.Compile(this.TaggerProvider, this.TextView, this.TextBuffer,
                    symbolTagger, errorTagger, this.cancellationTokenSource.Token);
            }
        }

        public void UpdateCompilation(ITextSnapshot textSnapshot, Compilation compilation)
        {
            ITextSnapshot oldTextSnapshot = Interlocked.Exchange(ref this.textSnapshot, textSnapshot);
            Compilation oldCompilation = Interlocked.Exchange(ref this.compilation, compilation);
            this.CompilationUpdated(textSnapshot, compilation, oldTextSnapshot, oldCompilation);
        }

        protected abstract void CompilationUpdated(ITextSnapshot newTextSnapshot, Compilation newCompilation, ITextSnapshot oldTextSnapshot, Compilation oldCompilation);
    }
}
