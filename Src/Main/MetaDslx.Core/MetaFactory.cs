using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
    public class MetaFactory
    {
        private string namespaceName;

        public MetaFactory()
        {
            this.namespaceName = this.GetType().Namespace;
        }

        protected MetaObject Create(string name)
        {
            MetaObject result = null;
            string typeName = this.namespaceName + "." + name + "Impl";
            Type type = this.GetType().Assembly.GetType(typeName);
            //Type type = Type.GetType(typeName);
            if (type != null && type.IsClass)
            {
                object obj = Activator.CreateInstance(type);
                if (obj is MetaObject)
                {
                    result = (MetaObject)obj;
                }
                else
                {
                    throw new MetaException("Class type '" + typeName + "' is not a descendant of '" + typeof(MetaObject).FullName + "'.");
                }
            }
            else
            {
                throw new MetaException("Class type '" + typeName + "' not found.");
            }
            return result;
        }
    }
}
