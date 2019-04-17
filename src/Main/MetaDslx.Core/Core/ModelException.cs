using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public class ModelException : Exception
    {
        private Location location;
        private LanguageDiagnosticInfo diagnosticInfo;

        public ModelException(Location location, LanguageDiagnosticInfo diagnosticInfo)
            : this(location, diagnosticInfo, null)
        {
        }

        public ModelException(Location location, LanguageDiagnosticInfo diagnosticInfo, Exception innerException)
            : base(string.Format(diagnosticInfo.GetMessage()), innerException)
        {
            this.location = location;
            this.diagnosticInfo = diagnosticInfo;
        }

        public Location Location
        {
            get { return this.location; }
        }

        public LanguageDiagnosticInfo LanguageDiagnosticInfo
        {
            get { return this.diagnosticInfo; }
        }
    }

    public sealed class LazyEvaluationException : ModelException
    {
        internal LazyEvaluationException(Location location, LazyEvaluationDiagnosticInfo diagnosticInfo)
            : base(location, diagnosticInfo)
        {
        }

        internal LazyEvaluationException(Location location, LazyEvaluationDiagnosticInfo diagnosticInfo, Exception innerException)
            : base(location, diagnosticInfo, innerException)
        {
        }

        public ImmutableArray<LazyEvalEntry> EvaluationStack
        {
            get { return ((LazyEvaluationDiagnosticInfo)this.LanguageDiagnosticInfo).EvaluationStack; }
        }
    }


}
