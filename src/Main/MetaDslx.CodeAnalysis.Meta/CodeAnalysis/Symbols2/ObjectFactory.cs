using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class ObjectFactory
    {
        private ModelModuleSymbol _module;
        private ObjectFactory _sourceObjectFactory;

        public ObjectFactory(ModelModuleSymbol module, ObjectFactory sourceObjectFactory)
        {
            _module = module;
            _sourceObjectFactory = sourceObjectFactory;
        }

        public LanguageCompilation Compilation => _module.DeclaringCompilation;
        public Language Language => _module.Language;
        public ModelModuleSymbol Module => _module;
        public object Model => _module.Model;
        public ObjectFactory SourceObjectFactory => _sourceObjectFactory;

        public virtual ObjectFactory GetObjectFactory(object modelObject)
        {
            if (this.ContainsObject(modelObject)) return this;
            foreach (var module in _sourceObjectFactory.Module.ContainingAssembly.Modules)
            {
                if (module is ModelModuleSymbol mms)
                {
                    var of = mms.ObjectFactory;
                    if (of != this && of.ContainsObject(modelObject)) return of;
                }
            }
            return null;
        }

        public abstract object CreateModel();
        public abstract object CreateObject(Type type);
        public abstract bool ContainsObject(object modelObject);
        public abstract object GetModel(object modelObject);
        public abstract string GetName(object modelObject);
        public abstract object GetParent(object modelObject);
        public abstract IEnumerable<object> GetChildren(object modelObject);
        public abstract IEnumerable<object> GetProperties(Type modelObjectType);
        public virtual IEnumerable<object> GetProperties(object modelObject)
        {
            return GetProperties(modelObject.GetType());
        }
        public abstract IEnumerable<object> GetPropertyValues(object modelObject, object property);
        public abstract void SetOrAddPropertyValue(object modelObject, object property, object value, DiagnosticBag diagnostics);

    }
}
