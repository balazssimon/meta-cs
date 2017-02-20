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

        public virtual ModelException ToRed(MutableModelGroup modelGroup)
        {
            return new ModelException(new DiagnosticInfo(this.errorCode, this.ArgsToSymbols(modelGroup)), this);
        }

        public virtual ModelException ToRed(ImmutableModel model)
        {
            return new ModelException(new DiagnosticInfo(this.errorCode, this.ArgsToSymbols(model)), this);
        }

        protected ImmutableArray<object> ArgsToSymbols(ImmutableModel model)
        {
            ImmutableArray<object> result;
            ArrayBuilder<object> resultBuilder = ArrayBuilder<object>.GetInstance();
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
                result = resultBuilder.ToImmutableAndFree();
            }
            return result;
        }

        protected ImmutableArray<object> ArgsToSymbols(MutableModel model)
        {
            ImmutableArray<object> result;
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
                result = resultBuilder.ToImmutableAndFree();
            }
            return result;
        }

        protected ImmutableArray<object> ArgsToSymbols(MutableModelGroup modelGroup)
        {
            ImmutableArray<object> result;
            ArrayBuilder<object> resultBuilder = ArrayBuilder<object>.GetInstance();
            try
            {
                foreach (var arg in this.args)
                {
                    SymbolId sid = arg as SymbolId;
                    if (sid != null)
                    {
                        resultBuilder.Add((object)modelGroup.ResolveSymbol(sid) ?? (object)sid);
                    }
                    else
                    {
                        resultBuilder.Add(arg);
                    }
                }
            }
            finally
            {
                result = resultBuilder.ToImmutableAndFree();
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

        public override ModelException ToRed(MutableModelGroup modelGroup)
        {
            return new ModelSymbolException(new SymbolDiagnosticInfo(this.SymbolIdsToSymbols(modelGroup), this.ErrorCode, this.ArgsToSymbols(modelGroup)), this);
        }

        public override ModelException ToRed(ImmutableModel model)
        {
            return new ModelSymbolException(new SymbolDiagnosticInfo(this.SymbolIdsToSymbols(model), this.ErrorCode, this.ArgsToSymbols(model)), this);
        }

        protected ImmutableArray<IMetaSymbol> SymbolIdsToSymbols(ImmutableModel model)
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

        protected ImmutableArray<IMetaSymbol> SymbolIdsToSymbols(MutableModelGroup modelGroup)
        {
            ImmutableArray<IMetaSymbol> result;
            ArrayBuilder<IMetaSymbol> resultBuilder = ArrayBuilder<IMetaSymbol>.GetInstance();
            try
            {
                foreach (var sid in this.symbols)
                {
                    resultBuilder.Add(modelGroup.ResolveSymbol(sid));
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

        public override ModelException ToRed(MutableModelGroup modelGroup)
        {
            DiagnosticInfo innerInfo = this.InnerException is GreenModelException ? ((GreenModelException)this.InnerException).ToRed(modelGroup).DiagnosticInfo : null;
            return new LazyEvaluationException(new LazyEvaluationDiagnosticInfo(this.EvaluationStackToSymbols(modelGroup), innerInfo, this.ErrorCode, this.ArgsToSymbols(modelGroup)), this);
        }

        public override ModelException ToRed(ImmutableModel model)
        {
            DiagnosticInfo innerInfo = this.InnerException is GreenModelException ? ((GreenModelException)this.InnerException).ToRed(model).DiagnosticInfo : null;
            return new LazyEvaluationException(new LazyEvaluationDiagnosticInfo(this.EvaluationStackToSymbols(model), innerInfo, this.ErrorCode, this.ArgsToSymbols(model)), this);
        }

        protected ImmutableArray<LazyEvalEntry> EvaluationStackToSymbols(ImmutableModel model)
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

        protected ImmutableArray<LazyEvalEntry> EvaluationStackToSymbols(MutableModelGroup modelGroup)
        {
            ImmutableArray<LazyEvalEntry> result;
            ArrayBuilder<LazyEvalEntry> resultBuilder = ArrayBuilder<LazyEvalEntry>.GetInstance();
            try
            {
                foreach (var entry in this.evaluationStack)
                {
                    resultBuilder.Add(new LazyEvalEntry(modelGroup.ResolveSymbol(entry.Symbol), entry.Property));
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
