using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaSymbolFacts : SymbolFacts
    {
        public override object GetModel(object modelObject)
        {
            var mobj = (IModelObject)modelObject;
            return mobj.MModel;
        }

        public override Type GetModelObjectType(object modelObject)
        {
            var mobj = (IModelObject)modelObject;
            return mobj.MId.Descriptor.ImmutableType;
        }

        public override string GetName(object modelObject)
        {
            var mobj = (IModelObject)modelObject;
            return mobj.MName;
        }

        public override object GetParent(object modelObject)
        {
            var mobj = (IModelObject)modelObject;
            return mobj.MParent;
        }

        public override IEnumerable<object> GetChildren(object modelObject)
        {
            var mobj = (IModelObject)modelObject;
            return mobj.MChildren;
        }

        public override IEnumerable<object> GetProperties(Type modelObjectType)
        {
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return GetProperties(mdesc);
        }

        public override IEnumerable<object> GetProperties(object modelObject)
        {
            var mobj = (IModelObject)modelObject;
            return GetProperties(mobj.MId.Descriptor);
        }

        protected IEnumerable<object> GetProperties(ModelObjectDescriptor descriptor)
        {
            if (descriptor != null) return descriptor.Properties;
            else return ImmutableArray<object>.Empty;
        }

        public override IEnumerable<object> GetPropertyValues(object modelObject, object property)
        {
            var mobj = (IModelObject)modelObject;
            var mprop = (ModelProperty)property;
            var value = mobj.MGet(mprop);
            if (mprop.IsCollection) return (IEnumerable<object>)value;
            else return ImmutableArray.Create(value);
        }

        public override void SetOrAddPropertyValue(object modelObject, object property, object value, Location location, DiagnosticBag diagnostics)
        {
            try
            {
                var mobj = (MutableObject)modelObject;
                var mprop = (ModelProperty)property;
                if (mprop.IsCollection) mobj.MAdd(mprop, value);
                else mobj.MSet(mprop, value);
            }
            catch(ModelException ex)
            {
                diagnostics.Add(ModelErrorCode.ERR_Exception.ToDiagnostic(location, ex.ToString()));
            }
        }

        public override bool ContainsObject(object model, object modelObject)
        {
            var mobj = modelObject as IModelObject;
            if (mobj == null) return false;
            var id = mobj.MId;
            if (model is ImmutableModel im) return im.ContainsObject(id);
            else if (model is MutableModel mm) return mm.ContainsObject(id);
            else if (model is ImmutableModelGroup img) return img.ContainsObject(id);
            else if (model is MutableModelGroup mmg) return mmg.ContainsObject(id);
            return false;
        }

        public override IEnumerable<object> GetRootObjects(object model)
        {
            IEnumerable<IModelObject> objects = null;
            if (model is ImmutableModel im) objects = im.Objects;
            else if (model is MutableModel mm) objects = mm.Objects;
            else if (model is ImmutableModelGroup img) objects = img.Objects;
            else if (model is MutableModelGroup mmg) objects = mmg.Objects;
            if (objects != null)
            {
                var builder = ArrayBuilder<IModelObject>.GetInstance();
                foreach (var mobj in objects)
                {
                    if (mobj.MParent == null) builder.Add(mobj);
                }
                return builder.ToImmutableAndFree();
            }
            return ImmutableArray<object>.Empty;
        }

        public override LanguageSymbolKind GetSymbolKind(Type modelObjectType)
        {
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return GetSymbolKind(mdesc);
        }

        public override LanguageSymbolKind GetSymbolKind(object modelObject)
        {
            var mobj = (IModelObject)modelObject;
            return GetSymbolKind(mobj.MId.Descriptor);
        }

        protected LanguageSymbolKind GetSymbolKind(ModelObjectDescriptor descriptor)
        {
            if (descriptor != null)
            {
                if (descriptor.IsNamespace) return LanguageSymbolKind.Namespace;
                else if (descriptor.IsNamedType) return LanguageSymbolKind.NamedType;
                else if (descriptor.IsName) return LanguageSymbolKind.Name;
            }
            return LanguageSymbolKind.None;
        }

        public override IEnumerable<object> GetPropertiesForSymbol(Type modelObjectType, string symbolProperty)
        {
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return GetPropertiesForSymbol(mdesc, symbolProperty);
        }

        public override IEnumerable<object> GetPropertiesForSymbol(object modelObject, string symbolProperty)
        {
            var mobj = (IModelObject)modelObject;
            return GetPropertiesForSymbol(mobj.MId.Descriptor, symbolProperty);
        }

        protected IEnumerable<object> GetPropertiesForSymbol(ModelObjectDescriptor descriptor, string symbolProperty)
        {
            if (descriptor != null)
            {
                foreach (var prop in descriptor.Properties)
                {
                    var sprop = GetSymbolProperty(descriptor.ImmutableType, prop);
                    if (sprop == symbolProperty) yield return prop;
                }
            }
        }

        public override object GetProperty(Type modelObjectType, string modelObjectPropertyName)
        {
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return GetProperty(mdesc, modelObjectPropertyName);
        }

        public override object GetProperty(object modelObject, string modelObjectPropertyName)
        {
            var mobj = (IModelObject)modelObject;
            return GetProperty(mobj.MId.Descriptor, modelObjectPropertyName);
        }

        protected object GetProperty(ModelObjectDescriptor descriptor, string modelObjectPropertyName)
        {
            if (descriptor != null)
            {
                return descriptor.Properties.FirstOrDefault(p => p.Name == modelObjectPropertyName);
            }
            return null;
        }

        public override bool IsContainmentProperty(object property)
        {
            var prop = (ModelProperty)property;
            return prop.IsContainment;
        }

        public override string GetSymbolProperty(Type modelObjectType, object property)
        {
            var mprop = (ModelProperty)property;
            if (mprop.IsName) return "Name";
            else if (mprop.IsBaseScope) return "DeclaredBaseTypes";
            else if (mprop.IsContainment) return "Members";
            else return null;
        }

    }
}
