using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Utilities;
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
        private DiagnosticInfo diagnosticInfo;

        public ModelException(Location location, DiagnosticInfo diagnosticInfo)
            : this(location, diagnosticInfo, null)
        {
        }

        public ModelException(Location location, DiagnosticInfo diagnosticInfo, Exception innerException)
            : base(string.Format(diagnosticInfo.GetMessage()), innerException)
        {
            this.location = location;
            this.diagnosticInfo = diagnosticInfo;
        }

        public Location Location
        {
            get { return this.location; }
        }

        public DiagnosticInfo DiagnosticInfo
        {
            get { return this.diagnosticInfo; }
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
            get { return ((LazyEvaluationDiagnosticInfo)this.DiagnosticInfo).EvaluationStack; }
        }
    }


}
