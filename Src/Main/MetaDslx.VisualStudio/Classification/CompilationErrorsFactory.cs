using MetaDslx.Compiler.Diagnostics;
using Microsoft.VisualStudio.Shell.TableManager;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class CompilationErrorsFactory : TableEntriesSnapshotFactoryBase
    {
        private CompilationErrorsSnapshot CurrentSnapshot;

        public CompilationErrorsFactory(CompilationErrorTagger errorTagger, CompilationErrorsSnapshot compilationErrors)
        {
            this.CurrentSnapshot = compilationErrors;
        }

        internal void UpdateErrors(CompilationErrorsSnapshot compilationErrors)
        {
            Interlocked.Exchange(ref this.CurrentSnapshot.NextSnapshot, compilationErrors);
            Interlocked.Exchange(ref this.CurrentSnapshot, compilationErrors);
        }

        #region ITableEntriesSnapshotFactory members
        public override int CurrentVersionNumber
        {
            get
            {
                return this.CurrentSnapshot.VersionNumber;
            }
        }

        public override void Dispose()
        {
        }

        public override ITableEntriesSnapshot GetCurrentSnapshot()
        {
            return this.CurrentSnapshot;
        }

        public override ITableEntriesSnapshot GetSnapshot(int versionNumber)
        {
            // In theory the snapshot could change in the middle of the return statement so snap the snapshot just to be safe.
            var snapshot = this.CurrentSnapshot;
            return (versionNumber == snapshot.VersionNumber) ? snapshot : null;
        }
        #endregion
    }
}
