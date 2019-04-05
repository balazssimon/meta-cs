using MetaDslx.Compiler;
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

        public LazyEvaluationDiagnosticInfo(ImmutableArray<LazyEvalEntry> evaluationStack, DiagnosticDescriptor descriptor, params object[] args)
            : base(descriptor, args)
        {
            this.EvaluationStack = evaluationStack;
        }

    }
}
