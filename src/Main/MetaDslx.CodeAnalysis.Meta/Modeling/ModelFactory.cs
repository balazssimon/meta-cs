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

        protected MutableObject CreateObject(ObjectId id)
        {
            MutableObjectBase obj = this.model.CreateObject(id, this.flags.HasFlag(ModelFactoryFlags.CreateWeakObjects));
            obj.MCallInit();
            if (!this.flags.HasFlag(ModelFactoryFlags.DontMakeObjectsCreated)) obj.MMakeCreated();
            return obj;
        }

        public MutableObject Create(Type type)
        {
            // TODO: instantiate any type from any model
            return this.Create(type.Name);
        }

        public abstract MutableObject Create(string type);
    }


}
