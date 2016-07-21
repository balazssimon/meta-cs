using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
    public class ModelFactory
    {
        private string namespaceName;

        public ModelFactory()
        {
            this.namespaceName = this.GetType().Namespace;
        }

        public ModelObject Create(string name)
        {
            if (name == null) return null;
            string typeName = this.GetType().Namespace + "." + name;
            Type type = this.GetType().Assembly.GetType(typeName);
            return this.Create(type);
        }

        public ModelObject Create(Type type)
        {
            if (type == null) return null;
            ModelObject result = null;
            string typeName = type.FullName + "Impl";
            Type implType = type.Assembly.GetType(typeName);
            if (implType != null && implType.IsClass)
            {
                object obj = Activator.CreateInstance(implType);
                if (obj is ModelObject)
                {
                    result = (ModelObject)obj;
                }
                else
                {
                    throw new ModelException("Class type '" + typeName + "' is not a descendant of '" + typeof(ModelObject).FullName + "'.");
                }
            }
            else
            {
                throw new ModelException("Class type '" + typeName + "' not found.");
            }
            return result;
        }

        public T Create<T>()
            where T : class
        {
            ModelObject result = this.Create(typeof(T));
            if (result == null)
            {
                throw new ModelException("Implementation of '" + typeof(T) + "' is not found.");
            }
            T typedResult = result as T;
            if (typedResult == null)
            {
                throw new ModelException("Implementation is not a descendant of '" + typeof(T) + "'.");
            }
            return typedResult;
        }

        public void Init(ModelObject mobject, IEnumerable<ModelPropertyInitializer> initializers)
        {
            foreach (var init in initializers)
            {
                if (!init.Property.IsCollection)
                {
                    mobject.MUnSet(init.Property);
                }
                else
                {
                    ModelCollection mc = mobject.MGet(init.Property) as ModelCollection;
                    if (mc != null)
                    {
                        mc.Clear();
                    }
                }
            }
            foreach (var init in initializers)
            {
                if (init.Values != null)
                {
                    foreach (var value in init.Values)
                    {
                        mobject.MLazyAdd(init.Property, value);
                    }
                }
                else
                {
                    mobject.MLazyAdd(init.Property, init.Value);
                }
            }
        }
    }

    public class ModelPropertyInitializer
    {
        public ModelProperty Property { get; private set; }
        public Lazy<object> Value { get; private set; }
        public IEnumerable<Lazy<object>> Values { get; private set; }

        public ModelPropertyInitializer(ModelProperty property, Lazy<object> value)
        {
            this.Property = property;
            this.Value = value;
        }
        public ModelPropertyInitializer(ModelProperty property, IEnumerable<Lazy<object>> values)
        {
            this.Property = property;
            this.Values = values;
        }
    }
}
