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

        public PhaseBinder(SyntaxNodeOrToken syntax, Binder next, CompletionPart startPhase, CompletionPart finishPhase)
            : base(syntax, next)
        {
            _startPhase = startPhase;
            _finishPhase = finishPhase;
        }

        public CompletionPart StartPhase => _startPhase;
        public CompletionPart FinishPhase => _finishPhase;
    }
}
