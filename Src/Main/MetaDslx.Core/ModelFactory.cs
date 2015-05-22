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
    }
}
