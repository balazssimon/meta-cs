using MetaDslx.CodeAnalysis.Symbols.Metadata;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class ReflectionObjectFactory : ObjectFactory
    {
        public ReflectionObjectFactory(ModelModuleSymbol module, ReflectionObjectFactory sourceObjectFactory) 
            : base(module, sourceObjectFactory)
        {
        }

        public override bool ContainsObject(object modelObject)
        {
            throw new NotImplementedException();
        }

        public override object CreateModel()
        {
            throw new NotImplementedException();
        }

        public override object CreateObject(Type type)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetChildren(object modelObject)
        {
            throw new NotImplementedException();
        }

        public override object GetModel(object modelObject)
        {
            throw new NotImplementedException();
        }

        public override string GetName(object modelObject)
        {
            throw new NotImplementedException();
        }

        public override object GetParent(object modelObject)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetProperties(Type modelObjectType)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<object> GetPropertyValues(object modelObject, object property)
        {
            throw new NotImplementedException();
        }

        public override void SetOrAddPropertyValue(object modelObject, object property, object value, DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }
    }
}
