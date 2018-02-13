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

namespace MetaDslx.VisualStudio.Classification.Antlr4Tagging
{
    internal class CompilationErrorsFactory<TLexer, TParser> : TableEntriesSnapshotFactoryBase
        where TLexer : Antlr4.Runtime.Lexer
        where TParser : Antlr4.Runtime.Parser
    {
        private CompilationErrorsSnapshot<TLexer, TParser> currentSnapshot;

        public CompilationErrorsFactory(CompilationErrorTagger<TLexer, TParser> errorTagger, CompilationErrorsSnapshot<TLexer, TParser> compilationErrors)
        {
            this.currentSnapshot = compilationErrors;
        }

        internal void UpdateErrors(string filePath, CompilationSnapshot<TLexer, TParser> compilationSnapshot)
        {
            Interlocked.Exchange(ref this.currentSnapshot, this.currentSnapshot.Update(filePath, compilationSnapshot));
        }

        public CompilationErrorsSnapshot<TLexer, TParser> CurrentSnapshot
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
