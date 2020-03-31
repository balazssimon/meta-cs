using MetaDslx.CodeAnalysis;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell.TableControl;
using Microsoft.VisualStudio.Shell.TableManager;
using Microsoft.VisualStudio.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.VisualStudio.Classification
{
    internal class CompilationErrorsSnapshot : WpfTableEntriesSnapshotBase
    {
        public static readonly CompilationErrorsSnapshot Default = new CompilationErrorsSnapshot(null, 0, null);

        private readonly string filePath;
        private readonly int versionNumber;
        private readonly ICompilation compilation;

        internal CompilationErrorsSnapshot NextSnapshot;

        internal CompilationErrorsSnapshot(string filePath, int versionNumber, ICompilation compilation)
        {
            this.filePath = filePath;
            this.versionNumber = versionNumber;
            this.compilation = compilation;
        }

        private ICompilation Compilation
        {
            get { return this.compilation; }
        }

        private ImmutableArray<Diagnostic> Diagnostics
        {
            get { return this.Compilation?.GetDiagnostics() ?? ImmutableArray<Diagnostic>.Empty; }
        }

        public override int Count
        {
            get
            {
                return this.Diagnostics.Length;
            }
        }

        public override int VersionNumber
        {
            get
            {
                return this.versionNumber;
            }
        }

        public CompilationErrorsSnapshot Update(string filePath, ICompilation compilation)
        {
            Interlocked.CompareExchange(ref this.NextSnapshot, new CompilationErrorsSnapshot(filePath, this.versionNumber + 1, compilation), null);
            return this.NextSnapshot;
        }

        public override int IndexOf(int currentIndex, ITableEntriesSnapshot newerSnapshot)
        {
            // This and TranslateTo() are used to map errors from one snapshot to a different one (that way the error list can do things like maintain the selection on an error
            // even when the snapshot containing the error is replaced by a new one).
            //
            // You only need to implement Identity() or TranslateTo() and, of the two, TranslateTo() is more efficient for the error list to use.

            // Map currentIndex to the corresponding index in newerSnapshot (and keep doing it until either
            // we run out of snapshots, we reach newerSnapshot, or the index can no longer be mapped forward).
            /*var currentSnapshot = this;
            do
            {
                Debug.Assert(currentIndex >= 0);
                Debug.Assert(currentIndex < currentSnapshot.Count);

                currentIndex = currentSnapshot.Diagnostics[currentIndex].NextIndex;

                currentSnapshot = currentSnapshot.NextSnapshot;
            }
            while ((currentSnapshot != null) && (currentSnapshot != newerSnapshot) && (currentIndex >= 0));

            return currentIndex;*/
            return currentIndex;
        }

        public override bool TryGetValue(int index, string columnName, out object content)
        {
            var diagnostics = this.Diagnostics;
            if ((index >= 0) && (index < diagnostics.Length))
            {
                var diagnostic = diagnostics[index];
                if (columnName == StandardTableKeyNames.DocumentName)
                {
                    // We return the full file path here. The UI handles displaying only the Path.GetFileName().
                    content = this.filePath;
                    return true;
                }
                else if (columnName == StandardTableKeyNames.ErrorCategory)
                {
                    content = "Documentation";
                    return true;
                }
                else if (columnName == StandardTableKeyNames.ErrorSource)
                {
                    content = "Spelling";
                    return true;
                }
                else if (columnName == StandardTableKeyNames.Line)
                {
                    // Line and column numbers are 0-based (the UI that displays the line/column number will add one to the value returned here).
                    content = diagnostic.Location.GetMappedLineSpan().StartLinePosition.Line;
                    return true;
                }
                else if (columnName == StandardTableKeyNames.Column)
                {
                    content = diagnostic.Location.GetMappedLineSpan().StartLinePosition.Character;
                    return true;
                }
                else if (columnName == StandardTableKeyNames.Text)
                {
                    content = diagnostic.GetMessage();
                    return true;
                }
                else if (columnName == StandardTableKeyNames2.TextInlines)
                {
                    content = null;
                    return false;
                }
                else if (columnName == StandardTableKeyNames.ErrorSeverity)
                {
                    switch (diagnostic.Severity)
                    {
                        case DiagnosticSeverity.Hidden:
                            content = __VSERRORCATEGORY.EC_MESSAGE;
                            break;
                        case DiagnosticSeverity.Info:
                            content = __VSERRORCATEGORY.EC_MESSAGE;
                            break;
                        case DiagnosticSeverity.Warning:
                            content = __VSERRORCATEGORY.EC_WARNING;
                            break;
                        case DiagnosticSeverity.Error:
                            content = __VSERRORCATEGORY.EC_ERROR;
                            break;
                        default:
                            content = __VSERRORCATEGORY.EC_MESSAGE;
                            break;
                    }
                    return true;
                }
                else if (columnName == StandardTableKeyNames.ErrorSource)
                {
                    content = ErrorSource.Other;
                    return true;
                }
                else if (columnName == StandardTableKeyNames.BuildTool)
                {
                    content = "MetaDslx";
                    return true;
                }
                else if (columnName == StandardTableKeyNames.ErrorCode)
                {
                    content = diagnostic.Id.ToString();
                    return true;
                }
                else if ((columnName == StandardTableKeyNames.ErrorCodeToolTip) || (columnName == StandardTableKeyNames.HelpLink))
                {
                    content = null;
                    return false;
                }

                // We should also be providing values for StandardTableKeyNames.Project & StandardTableKeyNames.ProjectName but that is
                // beyond the scope of this sample.
            }

            content = null;
            return false;
        }

        public override bool CanCreateDetailsContent(int index)
        {
            return false;
        }

        public override bool TryCreateDetailsStringContent(int index, out string content)
        {
            content = null;
            return false;
        }

    }
}
