using MetaDslx.Compiler.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public class LazyEvaluationDiagnosticInfo : DiagnosticInfo
    {
        public ImmutableArray<LazyEvalEntry> EvaluationStack { get; }
        public DiagnosticInfo InnerDiagnosticInfo { get; }

        public LazyEvaluationDiagnosticInfo(ImmutableArray<LazyEvalEntry> evaluationStack, DiagnosticInfo innerDiagnosticInfo, ErrorCode code, params object[] args)
            : base(code, args)
        {
            this.EvaluationStack = evaluationStack;
            this.InnerDiagnosticInfo = innerDiagnosticInfo;
        }

        private LazyEvaluationDiagnosticInfo(LazyEvaluationDiagnosticInfo original, DiagnosticSeverity overriddenSeverity)
            : base(original, overriddenSeverity)
        {
            this.EvaluationStack = original.EvaluationStack;
            this.InnerDiagnosticInfo = original.InnerDiagnosticInfo;
        }

        public override DiagnosticInfo WithSeverity(DiagnosticSeverity overriddenSeverity)
        {
            if (this.Severity != overriddenSeverity) return new LazyEvaluationDiagnosticInfo(this, overriddenSeverity);
            else return this;
        }
    }
}
