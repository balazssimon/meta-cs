using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;
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
        private DiagnosticInfo diagnosticInfo;

        public ModelException(DiagnosticInfo diagnosticInfo)
            : this(diagnosticInfo, null)
        {
            this.diagnosticInfo = diagnosticInfo;
        }

        public ModelException(DiagnosticInfo diagnosticInfo, Exception innerException)
            : base(string.Format(diagnosticInfo.GetMessage()), innerException)
        {

        }

        public DiagnosticInfo DiagnosticInfo
        {
            get { return this.diagnosticInfo; }
        }
    }

    public class ModelSymbolException : ModelException
    {
        internal ModelSymbolException(SymbolDiagnosticInfo diagnosticInfo)
            : base(diagnosticInfo)
        {
        }

        internal ModelSymbolException(SymbolDiagnosticInfo diagnosticInfo, Exception innerException)
            : base(diagnosticInfo, innerException)
        {
        }

        public ImmutableArray<IMetaSymbol> Symbols
        {
            get { return ((SymbolDiagnosticInfo)this.DiagnosticInfo).Symbols; }
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
        internal LazyEvaluationException(LazyEvaluationDiagnosticInfo diagnosticInfo)
            : base(diagnosticInfo)
        {
        }

        internal LazyEvaluationException(LazyEvaluationDiagnosticInfo diagnosticInfo, Exception innerException)
            : base(diagnosticInfo, innerException)
        {
        }

        public ImmutableArray<LazyEvalEntry> EvaluationStack
        {
            get { return ((LazyEvaluationDiagnosticInfo)this.DiagnosticInfo).EvaluationStack; }
        }
    }


}
