using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal class FindPhases : FindBinderDescendants<PhaseBinder>
    {
        private CompletionPart _startPhase;
        private CompletionPart _finishPhase;

        public FindPhases(BinderPosition origin, CompletionPart startPhase, CompletionPart finishPhase)
            : base(origin)
        {
            _startPhase = startPhase;
            _finishPhase = finishPhase;
        }

        public override bool IsValidBinder(PhaseBinder binder)
        {
            return (_startPhase == null || binder.StartPhase == _startPhase) && (_finishPhase == null || binder.FinishPhase == _finishPhase);
        }

        public override bool IsSearchBoundary(Binder binder)
        {
            return binder is ISymbolBoundary;
        }
    }
}
