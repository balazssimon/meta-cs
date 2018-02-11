using MetaDslx.Compiler;
using Microsoft.VisualStudio.Shell.TableControl;
using Microsoft.VisualStudio.Shell.TableManager;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    /// <summary>
    /// Factory for the <see cref="ITagger{T}"/>. There will be one instance of this class/VS session.
    /// 
    /// It is also the <see cref="ITableDataSource"/> that reports errors in comments.
    /// </summary>
    public abstract class CompilationTaggerProvider : IViewTaggerProvider, ITableDataSource
    {
        public readonly ITableManager ErrorTableManager;
        public readonly ITextDocumentFactoryService TextDocumentFactoryService;

        private readonly List<SinkManager> _managers = new List<SinkManager>();      // Also used for locks
        private readonly List<CompilationErrorsFactory> _factories = new List<CompilationErrorsFactory>();

        protected CompilationTaggerProvider(ITableManagerProvider provider, ITextDocumentFactoryService textDocumentFactoryService)
        {
            this.ErrorTableManager = provider.GetTableManager(StandardTables.ErrorsTable);
            this.TextDocumentFactoryService = textDocumentFactoryService;

            this.ErrorTableManager.AddSource(this, StandardTableColumnDefinitions.DetailsExpander,
                                                   StandardTableColumnDefinitions.ErrorSeverity, StandardTableColumnDefinitions.ErrorCode,
                                                   StandardTableColumnDefinitions.ErrorSource, StandardTableColumnDefinitions.BuildTool,
                                                   StandardTableColumnDefinitions.ErrorSource, StandardTableColumnDefinitions.ErrorCategory,
                                                   StandardTableColumnDefinitions.Text, StandardTableColumnDefinitions.DocumentName, StandardTableColumnDefinitions.Line, StandardTableColumnDefinitions.Column);
        }

        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
        {
            if (textView == null) throw new ArgumentNullException("textView");
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (buffer != textView.TextBuffer) return null;
            ITagger<T> tagger = null;
            if (typeof(T) == typeof(IErrorTag))
            {
                tagger = (ITagger<T>)buffer.Properties.GetOrCreateSingletonProperty(typeof(CompilationErrorTagger), () => new CompilationErrorTagger(this, textView, buffer));
            }
            else if (typeof(T) == typeof(IClassificationTag))
            {
                tagger = (ITagger<T>)buffer.Properties.GetOrCreateSingletonProperty(typeof(CompilationSymbolTagger), () => new CompilationSymbolTagger(this, textView, buffer));
            }
            return tagger;
        }

        internal Compilation Compile(string filePath, string sourceText, CancellationToken cancellationToken)
        {
            Compilation compilation = this.CreateCompilation(filePath, sourceText, cancellationToken);
            compilation.Execute(cancellationToken);
            if (!cancellationToken.IsCancellationRequested)
            {
                return compilation;
            }
            else
            {
                return null;
            }
        }

        protected abstract Compilation CreateCompilation(string filePath, string sourceText, CancellationToken cancellationToken);
        

        #region ITableDataSource members
        public abstract string DisplayName
        {
            get;
        }

        public string Identifier
        {
            get
            {
                return this.GetType().FullName;
            }
        }

        public string SourceTypeIdentifier
        {
            get
            {
                return StandardTableDataSources.ErrorTableDataSource;
            }
        }

        public IDisposable Subscribe(ITableDataSink sink)
        {
            // This method is called to each consumer interested in errors. In general, there will be only a single consumer (the error list tool window)
            // but it is always possible for 3rd parties to write code that will want to subscribe.
            return new SinkManager(this, sink);
        }
        #endregion

        internal void AddSinkManager(SinkManager manager)
        {
            // This call can, in theory, happen from any thread so be appropriately thread safe.
            // In practice, it will probably be called only once from the UI thread (by the error list tool window).
            lock (_managers)
            {
                _managers.Add(manager);
            }
        }

        internal void RemoveSinkManager(SinkManager manager)
        {
            // This call can, in theory, happen from any thread so be appropriately thread safe.
            // In practice, it will probably be called only once from the UI thread (by the error list tool window).
            lock (_managers)
            {
                _managers.Remove(manager);

                // Add the pre-existing spell checkers to the manager.
                foreach (var factory in _factories)
                {
                    manager.AddCompilationErrorsFactory(factory);
                }
            }
        }

        internal void AddCompilationErrorsFactory(CompilationErrorsFactory factory)
        {
            // This call will always happen on the UI thread (it is a side-effect of adding or removing the 1st/last tagger).
            lock (_managers)
            {
                _factories.Add(factory);

                // Tell the preexisting managers about the new spell checker
                foreach (var manager in _managers)
                {
                    manager.AddCompilationErrorsFactory(factory);
                }
            }
        }

        internal void RemoveCompilationErrorsFactory(CompilationErrorsFactory factory)
        {
            // This call will always happen on the UI thread (it is a side-effect of adding or removing the 1st/last tagger).
            lock (_managers)
            {
                _factories.Remove(factory);

                foreach (var manager in _managers)
                {
                    manager.RemoveCompilationErrorsFactory(factory);
                }
            }
        }

        public void UpdateAllSinks()
        {
            lock (_managers)
            {
                foreach (var manager in _managers)
                {
                    manager.UpdateSink();
                }
            }
        }

    }
}
