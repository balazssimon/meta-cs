using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
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
        private CompilationErrorsSnapshot currentSnapshot;

        public CompilationErrorsFactory(CompilationErrorTagger errorTagger)
        {
            this.currentSnapshot = CompilationErrorsSnapshot.Default;
        }

        internal void UpdateErrors(string filePath, CompilationSnapshot compilationSnapshot)
        {
            Interlocked.Exchange(ref this.currentSnapshot, this.currentSnapshot.Update(filePath, compilationSnapshot));
        }

        public CompilationErrorsSnapshot CurrentSnapshot
        {
            get { return this.currentSnapshot; }
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
