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
    internal class GreenModelException : Exception
    {
        private ModelErrorCode errorCode;
        private ImmutableArray<object> args;

        public GreenModelException(ModelErrorCode errorCode, params object[] args)
            : base(string.Format(errorCode.DefaultMessage, args))
        {
            this.errorCode = errorCode;
            this.args = args == null ? ImmutableArray<object>.Empty : args.ToImmutableArray();
        }

        public ModelErrorCode ErrorCode
        {
            get { return this.errorCode; }
        }

        public ImmutableArray<object> Args
        {
            get { return this.args; }
        }

        public virtual ModelException ToRed(MutableModel model)
        {
            return new ModelException(new DiagnosticInfo(this.errorCode, this.ArgsToSymbols(model)), this);
        }

        protected object[] ArgsToSymbols(MutableModel model)
        {
            object[] result;
            ArrayBuilder <object> resultBuilder = ArrayBuilder<object>.GetInstance();
            try
            {
                foreach (var arg in this.args)
                {
                    SymbolId sid = arg as SymbolId;
                    if (sid != null)
                    {
                        resultBuilder.Add((object)model.ResolveSymbol(sid) ?? (object)sid);
                    }
                    else 
                    {
                        resultBuilder.Add(arg);
                    }
                }
            }
            finally
            {
                result = resultBuilder.ToArrayAndFree();
            }
            return result;
        }
    }

    internal class GreenModelSymbolException : GreenModelException
    {
        private ImmutableArray<SymbolId> symbols;

        public GreenModelSymbolException(ImmutableArray<SymbolId> symbols, ModelErrorCode errorCode, params object[] args)
            : base(errorCode, args)
        {
            this.symbols = symbols;
        }

        public ImmutableArray<SymbolId> Symbols
        {
            get { return this.symbols; }
        }

        public override ModelException ToRed(MutableModel model)
        {
            return new ModelSymbolException(new SymbolDiagnosticInfo(this.SymbolIdsToSymbols(model), this.ErrorCode, this.ArgsToSymbols(model)), this);
        }

        protected ImmutableArray<IMetaSymbol> SymbolIdsToSymbols(MutableModel model)
        {
            ImmutableArray<IMetaSymbol> result;
            ArrayBuilder<IMetaSymbol> resultBuilder = ArrayBuilder<IMetaSymbol>.GetInstance();
            try
            {
                foreach (var sid in this.symbols)
                {
                    resultBuilder.Add(model.ResolveSymbol(sid));
                }
            }
            finally
            {
                result = resultBuilder.ToImmutableAndFree();
            }
            return result;
        }
    }

    internal class GreenLazyEvaluationException : GreenModelException
    {
        private ImmutableArray<GreenLazyEvalEntry> evaluationStack;

        public GreenLazyEvaluationException(ImmutableArray<GreenLazyEvalEntry> evaluationStack, ModelErrorCode errorCode, params object[] args)
            : base(errorCode, args)
        {
            this.evaluationStack = evaluationStack;
        }

        public ImmutableArray<GreenLazyEvalEntry> EvaluationStack
        {
            get { return this.evaluationStack; }
        }

        public override ModelException ToRed(MutableModel model)
        {
            DiagnosticInfo innerInfo = this.InnerException is GreenModelException ? ((GreenModelException)this.InnerException).ToRed(model).DiagnosticInfo : null;
            return new LazyEvaluationException(new LazyEvaluationDiagnosticInfo(this.EvaluationStackToSymbols(model), innerInfo, this.ErrorCode, this.ArgsToSymbols(model)), this);
        }

        protected ImmutableArray<LazyEvalEntry> EvaluationStackToSymbols(MutableModel model)
        {
            ImmutableArray<LazyEvalEntry> result;
            ArrayBuilder<LazyEvalEntry> resultBuilder = ArrayBuilder<LazyEvalEntry>.GetInstance();
            try
            {
                foreach (var entry in this.evaluationStack)
                {
                    resultBuilder.Add(new LazyEvalEntry(model.ResolveSymbol(entry.Symbol), entry.Property));
                }
            }
            finally
            {
                result = resultBuilder.ToImmutableAndFree();
            }
            return result;
        }
    }
}
