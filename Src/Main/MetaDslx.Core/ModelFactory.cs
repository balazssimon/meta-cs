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

        protected ModelObject Create(string name)
        {
            ModelObject result = null;
            string typeName = this.namespaceName + "." + name + "Impl";
            Type type = this.GetType().Assembly.GetType(typeName);
            //Type type = Type.GetType(typeName);
            if (type != null && type.IsClass)
            {
                object obj = Activator.CreateInstance(type);
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
    }
}
