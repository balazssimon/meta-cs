using Microsoft.VisualStudio.Shell.TableManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    /// <summary>
    /// Every consumer of data from an <see cref="ITableDataSource"/> provides an <see cref="ITableDataSink"/> to record the changes. We give the consumer
    /// an IDisposable (this object) that they hang on to as long as they are interested in our data (and they Dispose() of it when they are done).
    /// </summary>
    internal class SinkManager : IDisposable
    {
        private readonly CompilationTaggerProvider _compilationTaggerProvider;
        private readonly ITableDataSink _sink;

        internal SinkManager(CompilationTaggerProvider compilationTaggerProvider, ITableDataSink sink)
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

        internal void AddCompilationErrorsFactory(CompilationErrorsFactory factory)
        {
            _sink.AddFactory(factory);
        }

        internal void RemoveCompilationErrorsFactory(CompilationErrorsFactory factory)
        {
            _sink.RemoveFactory(factory);
        }

        internal void UpdateSink()
        {
            _sink.FactorySnapshotChanged(null);
        }
    }
}
