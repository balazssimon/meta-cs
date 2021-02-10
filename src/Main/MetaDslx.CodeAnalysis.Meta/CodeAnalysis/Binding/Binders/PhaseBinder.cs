using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public abstract class PhaseBinder : Binder
    {
        private CompletionPart _startPhase;
        private CompletionPart _finishPhase;

        public PhaseBinder(Binder next, SyntaxNodeOrToken syntax, CompletionPart startPhase, CompletionPart finishPhase)
            : base(next, syntax)
        {
            _startPhase = startPhase;
            _finishPhase = finishPhase;
        }

        public CompletionPart StartPhase => _startPhase;
        public CompletionPart FinishPhase => _finishPhase;
    }
}
