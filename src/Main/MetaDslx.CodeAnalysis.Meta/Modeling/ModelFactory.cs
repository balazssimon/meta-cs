using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public abstract class ModelFactory
    {
        private MutableModel model;
        private ModelFactoryFlags flags;

        public ModelFactory(MutableModel model, ModelFactoryFlags flags)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            this.model = model;
            this.flags = flags;
        }

        public MutableModel Model { get { return this.model; } }

        protected MutableSymbol CreateSymbol(SymbolId id)
        {
            MutableSymbolBase symbol = this.model.CreateSymbol(id, this.flags.HasFlag(ModelFactoryFlags.CreateWeakSymbols));
            symbol.MCallInit();
            if (!this.flags.HasFlag(ModelFactoryFlags.DontMakeSymbolsCreated)) symbol.MMakeCreated();
            return symbol;
        }

        public MutableSymbol Create(Type type)
        {
            // TODO: instantiate any type from any model
            return this.Create(type.Name);
        }
        public abstract MutableSymbol Create(string type);
    }


}
