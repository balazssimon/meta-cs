using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public class LazyEvaluationDiagnosticInfo : LanguageDiagnosticInfo
    {
        // not serialized:
        public ImmutableArray<LazyEvalEntry> EvaluationStack { get; }

        public LazyEvaluationDiagnosticInfo(ImmutableArray<LazyEvalEntry> evaluationStack, ErrorCode errorCode, params object[] args)
            : base(errorCode, args)
        {
            this.EvaluationStack = evaluationStack;
        }

    }
}
