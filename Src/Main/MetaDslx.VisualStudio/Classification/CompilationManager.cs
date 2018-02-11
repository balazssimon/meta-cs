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
    internal class BackgroundCompiler 
    {
        private CompilationTaggerProvider provider;
        private WeakReference<ITextBuffer> textBuffer;
        private CompilationSymbolTagger symbolTagger;
        private CompilationErrorTagger errorTagger;
        private CancellationToken cancellationToken;

        public BackgroundCompiler(CompilationTaggerProvider provider, 
            ITextBuffer textBuffer, CompilationSymbolTagger symbolTagger,
            CompilationErrorTagger errorTagger, CancellationToken cancellationToken)
        {
            this.provider = provider;
            this.textBuffer = new WeakReference<ITextBuffer>(textBuffer);
            this.symbolTagger = symbolTagger;
            this.errorTagger = errorTagger;
            this.cancellationToken = cancellationToken;
        }

        public ITextBuffer TextBuffer
        {
            get
            {
                ITextBuffer result;
                if (this.textBuffer.TryGetTarget(out result))
                {
                    return result;
                }
                return null;
            }
        }

        public ITextDocument TextDocument
        {
            get
            {
                ITextBuffer textBuffer = TextBuffer;
                if (textBuffer == null)
                    return null;

                ITextDocument textDocument;
                if (!this.provider.TextDocumentFactoryService.TryGetTextDocument(textBuffer, out textDocument))
                    return null;

                return textDocument;
            }
        }

        public string FilePath
        {
            get
            {
                ITextDocument textDocument = this.TextDocument;
                if (textDocument != null)
                {
                    return textDocument.FilePath;
                }
                return null;
            }
        }

        public void Compile()
        {
            string filePath = this.FilePath;
            ITextBuffer textBuffer = this.TextBuffer;
            if (textBuffer == null) return;
            ITextSnapshot textSnapshot = textBuffer.CurrentSnapshot;
            ITextVersion versionBefore = textSnapshot.Version;
            string sourceText = textSnapshot.GetText();
            textBuffer = null;

            var compilation = this.provider.Compile(filePath, sourceText, cancellationToken);

            textBuffer = this.TextBuffer;
            if (compilation != null && textBuffer != null)
            {
                textSnapshot = textBuffer.CurrentSnapshot;
                var versionAfter = textSnapshot.Version;
                if (versionAfter == versionBefore)
                {
                    this.symbolTagger.UpdateCompilation(textSnapshot, compilation);
                    this.errorTagger.UpdateCompilation(textSnapshot, compilation);
                    this.provider.UpdateAllSinks();
                }
            }
        }
    }

    internal class CompilationManager
    {
        private static CompilationManager instance = new CompilationManager();

        public static CompilationManager Instance
        {
            get
            {
                return CompilationManager.instance;
            }
        }

        public void Compile(CompilationTaggerProvider provider, ITextView textView,
            ITextBuffer textBuffer, CompilationSymbolTagger symbolTagger,
            CompilationErrorTagger errorTagger, CancellationToken cancellationToken)
        {
            BackgroundCompiler compilationTask = 
                new BackgroundCompiler(provider, textBuffer, symbolTagger, errorTagger, cancellationToken);
            //Task.Run(() => compilationTask.Compile());
            compilationTask.Compile();
        }
    }
}
