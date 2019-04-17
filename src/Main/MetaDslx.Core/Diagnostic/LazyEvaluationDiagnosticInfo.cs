using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Roslyn.Utilities;
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

    public sealed class LazyEvalEntry : IEquatable<LazyEvalEntry>
    {
        private IMetaSymbol symbol;
        private ModelProperty property;

        public LazyEvalEntry(IMetaSymbol symbol, ModelProperty property)
        {
            this.symbol = symbol;
            this.property = property;
        }

        public IMetaSymbol Symbol { get { return this.symbol; } }
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
