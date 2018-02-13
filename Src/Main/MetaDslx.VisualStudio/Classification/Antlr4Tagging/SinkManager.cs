using Microsoft.VisualStudio.Shell.TableManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification.Antlr4Tagging
{
    /// <summary>
    /// Every consumer of data from an <see cref="ITableDataSource"/> provides an <see cref="ITableDataSink"/> to record the changes. We give the consumer
    /// an IDisposable (this object) that they hang on to as long as they are interested in our data (and they Dispose() of it when they are done).
    /// </summary>
    internal class SinkManager<TLexer, TParser> : IDisposable
        where TLexer : Antlr4.Runtime.Lexer
        where TParser : Antlr4.Runtime.Parser
    {
        private readonly CompilationTaggerProvider<TLexer, TParser> _compilationTaggerProvider;
        private readonly ITableDataSink _sink;

        internal SinkManager(CompilationTaggerProvider<TLexer, TParser> compilationTaggerProvider, ITableDataSink sink)
        {
            _compilationTaggerProvider = compilationTaggerProvider;
            _sink = sink;

            _compilationTaggerProvider.AddSinkManager(this);
        }

        public void Dispose()
        {
            // Called when the person who subscribed to the data source disposes of the cookie (== this object) they were given.
            _compilationTaggerProvider.RemoveSinkManager(this);
        }

        internal void AddCompilationErrorsFactory(CompilationErrorsFactory<TLexer, TParser> factory)
        {
            _sink.AddFactory(factory);
        }

        internal void RemoveCompilationErrorsFactory(CompilationErrorsFactory<TLexer, TParser> factory)
        {
            _sink.RemoveFactory(factory);
        }

        internal void UpdateSink()
        {
            _sink.FactorySnapshotChanged(null);
        }
    }
}
