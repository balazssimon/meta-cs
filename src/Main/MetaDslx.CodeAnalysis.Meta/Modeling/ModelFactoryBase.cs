using MetaDslx.Languages.Meta.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public abstract class ModelFactoryBase : IModelFactory
    {
        private MutableModel model;
        private ModelFactoryFlags flags;

        public ModelFactoryBase(MutableModel model, ModelFactoryFlags flags = ModelFactoryFlags.None)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            this.model = model;
            this.flags = flags;
        }

        public abstract ModelMetadata MMetadata { get; }
        public MutableModel MModel { get { return this.model; } }

        protected MutableObject CreateObject(ObjectId id)
        {
            MutableObjectBase obj = this.model.CreateObject(id, this.flags.HasFlag(ModelFactoryFlags.CreateWeakObjects));
            obj.MCallInit();
            if (!this.flags.HasFlag(ModelFactoryFlags.DontMakeObjectsCreated)) obj.MMakeCreated();
            return obj;
        }

        public virtual MutableObject Create(Type type)
        {
            // TODO: instantiate any type from any model
            return this.Create(type.Name);
        }

        public abstract MutableObject Create(string type);
    }
}
