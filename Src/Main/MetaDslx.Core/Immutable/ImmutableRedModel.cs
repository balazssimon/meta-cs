using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public sealed class ImmutableRedModel : RedModel
    {
        private GreenModel green;
        private Dictionary<GreenSymbol, ImmutableRedSymbol> symbols;
        private Dictionary<GreenLazyValue, object> lazyItems;

        internal ImmutableRedModel(GreenModel green)
        {
            this.green = green;
            this.symbols = new Dictionary<GreenSymbol, ImmutableRedSymbol>();
            this.lazyItems = new Dictionary<GreenLazyValue, object>();
        }
    }

    public sealed class MutableRedModel : RedModel
    {
        private GreenModelTransaction rootTransaction;
        private GreenModelTransaction currentTransaction;
        private ImmutableRedModel originalImmutableModel;

        public MutableRedModel()
            : this(new GreenModel(), null)
        {
        }

        internal MutableRedModel(GreenModel green)
            : this(green, null)
        {
        }

        internal MutableRedModel(GreenModel green, ImmutableRedModel originalImmutableModel)
        {
            this.originalImmutableModel = originalImmutableModel;
            this.currentTransaction = green.BeginTransaction(this);
            this.rootTransaction = this.currentTransaction;
        }

        internal GreenModelTransaction Transaction { get { return this.currentTransaction; } }
    }

    public sealed class RedModelTransaction : IDisposable
    {
        private bool commited;
        private GreenModelTransaction green;
        private MutableRedModel model;

        internal RedModelTransaction(MutableRedModel model, GreenModelTransaction green)
        {
            this.model = model;
            this.green = green;
            this.commited = false;
        }

        internal GreenModelTransaction Green { get { return this.green; } }
        internal MutableRedModel Model { get { return this.model; } }

        public void Commit()
        {
            this.commited = true;
        }

        public void Rollback()
        {
            this.commited = false;
        }

        public void Dispose()
        {
            if (this.commited) model.CommitTransaction(this);
            else model.RollbackTransaction(this);
        }
    }
}
