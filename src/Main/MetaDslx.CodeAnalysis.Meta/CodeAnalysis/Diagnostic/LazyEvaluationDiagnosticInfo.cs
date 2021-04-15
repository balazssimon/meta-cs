using MetaDslx.Modeling;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;

namespace MetaDslx.Modeling
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

    public sealed class LazyEvalEntry : IEquatable<LazyEvalEntry>
    {
        private IModelObject symbol;
        private ModelProperty property;

        public LazyEvalEntry(IModelObject symbol, ModelProperty property)
        {
            this.symbol = symbol;
            this.property = property;
        }

        public IModelObject Symbol { get { return this.symbol; } }
        public ModelProperty Property { get { return this.property; } }

        public bool Equals(LazyEvalEntry other)
        {
            if (other == null) return false;
            return this.symbol == other.symbol && this.property == other.property;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as LazyEvalEntry);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.symbol.GetHashCode(), this.property.GetHashCode());
        }
    }

}
