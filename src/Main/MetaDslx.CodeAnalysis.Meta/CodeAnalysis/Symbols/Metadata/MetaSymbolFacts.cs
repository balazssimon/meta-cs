using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaSymbolFacts : SymbolFacts
    {
        public override object GetModel(object modelObject)
        {
            if (modelObject is not IModelObject mobj) return null;
            return mobj.MModel;
        }

        public override Type GetModelObjectType(object modelObject)
        {
            if (modelObject is not IModelObject mobj) return null;
            return mobj.MId.Descriptor.ImmutableType;
        }

        public override string GetName(object modelObject)
        {
            if (modelObject is not IModelObject mobj) return null;
            return mobj.MName;
        }

        public override string GetMetadataName(object modelObject)
        {
            if (modelObject is MetaPrimitiveType mpt) return mpt.DotNetName;
            if (modelObject is MetaPrimitiveTypeBuilder mptb) return mptb.DotNetName;
            if (modelObject is not IModelObject mobj) return null;
            return mobj.MName;
        }

        public override object GetParent(object modelObject)
        {
            if (modelObject is not IModelObject mobj) return null;
            return mobj.MParent;
        }

        public override IEnumerable<object> GetChildren(object modelObject)
        {
            if (modelObject is not IModelObject mobj) return ImmutableArray<object>.Empty;
            return mobj.MChildren;
        }

        public override IEnumerable<object> GetProperties(Type modelObjectType)
        {
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return GetProperties(mdesc);
        }

        public override IEnumerable<object> GetProperties(object modelObject)
        {
            if (modelObject is not IModelObject mobj) return ImmutableArray<object>.Empty;
            return GetProperties(mobj.MId.Descriptor);
        }

        protected IEnumerable<object> GetProperties(ModelObjectDescriptor descriptor)
        {
            if (descriptor != null) return descriptor.Properties;
            else return ImmutableArray<object>.Empty;
        }

        public override IEnumerable<object> GetPropertyValues(object modelObject, object property)
        {
            if (modelObject is not IModelObject mobj) return ImmutableArray<object>.Empty;
            var mprop = (ModelProperty)property;
            var value = mobj.MGet(mprop);
            if (mprop.IsCollection) return (IEnumerable<object>)value;
            else return ImmutableArray.Create(value);
        }

        public override void SetOrAddPropertyValue(object modelObject, object property, object symbolValue, Location location, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            try
            {
                var mobj = (MutableObject)modelObject;
                var mprop = (ModelProperty)property;
                var mvalue = symbolValue;
                if (symbolValue is Symbol symbol && !mprop.MutableType.IsAssignableFrom(symbol.GetType()))
                {
                    mvalue = this.GetSymbolValue(symbol, mprop.MutableType);
                    if (mvalue == null) return;
                }
                if (mprop.IsCollection) mobj.MAdd(mprop, mvalue, location);
                else mobj.MSet(mprop, mvalue, location);
            }
            catch(ModelException ex)
            {
                diagnostics.Add(ModelErrorCode.ERR_Exception.ToDiagnostic(location, ex.Message));
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

        public override Type GetSymbolType(Type modelObjectType)
        {
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return GetSymbolType(mdesc);
        }

        public override Type GetSymbolType(object modelObject)
        {
            var mobj = modelObject as IModelObject;
            if (mobj is null) return null;
            return GetSymbolType(mobj.MId.Descriptor);
        }

        protected Type GetSymbolType(ModelObjectDescriptor descriptor)
        {
            return descriptor?.SymbolType;
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
            if (mprop != null) return mprop.SymbolProperty;
            else return null;
        }

        public virtual object GetSymbolValue(Symbol symbol, Type expectedType)
        {
            if (symbol.IsError)
            {
                return null;
            }
            if (!expectedType.IsAssignableFrom(symbol.GetType()))
            {
                if (expectedType == typeof(Type) && symbol is CSharpNamedTypeSymbol cnts) return Type.GetType(GetFullMetadataName(cnts));
                else if (expectedType == typeof(string)) return symbol.Name;
                else if (symbol is IModelSymbol ms) return ms.ModelObject;
                //Debug.Assert(false);
                else return null;
            }
            return symbol;
        }

        private string GetFullMetadataName(CSharpNamedTypeSymbol symbol)
        {
            var result = symbol.MetadataName;
            var ns = symbol.ContainingDeclaration;
            while (ns is not null)
            {
                result = ns.MetadataName + "." + result;
                ns = ns.ContainingDeclaration;
            }
            return result;
        }

    }
}
