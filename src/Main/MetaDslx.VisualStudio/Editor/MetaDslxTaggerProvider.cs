using MetaDslx.CodeAnalysis;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Shell.TableControl;
using Microsoft.VisualStudio.Shell.TableManager;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
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
    public abstract class MetaDslxTaggerProvider : IViewTaggerProvider, ITaggerProvider, ITableDataSource
    {
#pragma warning disable 649 // "field never assigned to" -- field is set by MEF.
        [Import]
        private MetaDslxMefServices _mefServices;

        [Import]
        private IClassificationTypeRegistryService _classificationRegistryService;

        [Import]
        private IStandardClassificationService _standardClassificationService;

        [Import]
        private ITableManagerProvider _tableManagerProvider;

        [Import]
        private IBufferTagAggregatorFactoryService _bufferTagAggregatorFactoryService;
#pragma warning restore 649

        private readonly List<SinkManager> _managers = new List<SinkManager>();      // Also used for locks
        private readonly List<CompilationErrorsFactory> _factories = new List<CompilationErrorsFactory>();
        private ITableManager _errorTableManager;

        protected MetaDslxTaggerProvider()
        {
        }

        public MetaDslxMefServices MefServices => _mefServices;
        public ITableManager ErrorTableManager => _errorTableManager;
        public IClassificationTypeRegistryService ClassificationRegistryService => _classificationRegistryService;
        public IStandardClassificationService StandardClassificationService => _standardClassificationService;


        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            if (buffer == null) throw new ArgumentNullException("buffer");
            ITagger<T> tagger = null;
            if (typeof(T) == typeof(ReferencesTag))
            {
                tagger = (ITagger<T>)ReferencesTagger.GetOrCreate(_mefServices, this, buffer);
            }
            return tagger;
        }

        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer) where T : ITag
        {
            if (textView == null) throw new ArgumentNullException("textView");
            if (buffer == null) throw new ArgumentNullException("buffer");
            if (buffer != textView.TextBuffer) return null;
            if (_errorTableManager == null)
            {
                _errorTableManager = _tableManagerProvider.GetTableManager(StandardTables.ErrorsTable);
                _errorTableManager.AddSource(this, StandardTableColumnDefinitions.DetailsExpander,
                                                       StandardTableColumnDefinitions.ErrorSeverity, StandardTableColumnDefinitions.ErrorCode,
                                                       StandardTableColumnDefinitions.ErrorSource, StandardTableColumnDefinitions.BuildTool,
                                                       StandardTableColumnDefinitions.ErrorSource, StandardTableColumnDefinitions.ErrorCategory,
                                                       StandardTableColumnDefinitions.Text, StandardTableColumnDefinitions.DocumentName, StandardTableColumnDefinitions.Line, StandardTableColumnDefinitions.Column);

            }
            ITagger<T> tagger = null;
            var compilation = BackgroundCompilation.GetOrCreate(_mefServices, buffer);
            var wpfTextView = (IWpfTextView)textView;
            if (typeof(T) == typeof(IErrorTag))
            {
                tagger = (ITagger<T>)ErrorTagger.GetOrCreate(_mefServices, this, wpfTextView);
            }
            else if (typeof(T) == typeof(IClassificationTag))
            {
                tagger = (ITagger<T>)SymbolTagger.GetOrCreate(_mefServices, this, wpfTextView);
            }
            else if (typeof(T) == typeof(ITextMarkerTag))
            {
                tagger = (ITagger<T>)HighlightSymbolTagger.GetOrCreate(_mefServices, this, wpfTextView);
            }
            else if (typeof(T) == typeof(IntraTextAdornmentTag))
            {
                tagger = (ITagger<T>)ReferencesAdornmentTagger.GetOrCreate(_mefServices, this, wpfTextView, 
                    new Lazy<ITagAggregator<ReferencesTag>>(() => _bufferTagAggregatorFactoryService.CreateTagAggregator<ReferencesTag>(textView.TextBuffer)));
            }
            return tagger;
        }

        public abstract IClassificationType GetSymbolClassificationType(ISymbol symbol, SyntaxToken token, SemanticModel semanticModel, CancellationToken cancellationToken);

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
                foreach (var factory in _factories)
                {
                    manager.AddCompilationErrorsFactory(factory);
                }
            }
        }

        internal void RemoveSinkManager(SinkManager manager)
        {
            // This call can, in theory, happen from any thread so be appropriately thread safe.
            // In practice, it will probably be called only once from the UI thread (by the error list tool window).
            lock (_managers)
            {
                _managers.Remove(manager);
                foreach (var factory in _factories)
                {
                    manager.RemoveCompilationErrorsFactory(factory);
                }
            }
        }

        internal void AddCompilationErrorsFactory(CompilationErrorsFactory factory)
        {
            // This call will always happen on the UI thread (it is a side-effect of adding or removing the 1st/last tagger).
            lock (_managers)
            {
                _factories.Add(factory);
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
