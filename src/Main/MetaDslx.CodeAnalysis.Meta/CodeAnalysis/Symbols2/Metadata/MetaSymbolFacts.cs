using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public override void SetOrAddPropertyValue(object modelObject, object property, object value, DiagnosticBag diagnostics)
        {
            var mobj = (MutableObject)modelObject;
            var mprop = (ModelProperty)property;
            if (mprop.IsCollection) mobj.MAdd(mprop, value);
            else mobj.MSet(mprop, value);
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

        public override IEnumerable<object> GetProperties(Type modelObjectType, string symbolProperty)
        {
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return GetProperties(mdesc, symbolProperty);
        }

        public override IEnumerable<object> GetProperties(object modelObject, string symbolProperty)
        {
            var mobj = (IModelObject)modelObject;
            return GetProperties(mobj.MId.Descriptor, symbolProperty);
        }

        protected IEnumerable<object> GetProperties(ModelObjectDescriptor descriptor, string symbolProperty)
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
