using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaObjectFactory : ObjectFactory
    {
        private MutableModelGroup _modelGroup;
        private MutableModel _model;

        public MetaObjectFactory(ModelModuleSymbol module, MetaObjectFactory sourceObjectFactory)
            : base(module, sourceObjectFactory)
        {
            if (sourceObjectFactory != null)
            {
                _modelGroup = sourceObjectFactory._modelGroup;
            }
            else
            {
                _modelGroup = new MutableModelGroup();
                var modules = module.ContainingAssembly.Modules;
                for (int i = 0; i < modules.Length; i++)
                {
                    if (i == 0)
                    {
                        _model = (MutableModel)CreateModel();
                        ((SourceModuleSymbol)module).SetModelByObjectFactory(_model);
                    }
                    else if (modules[i] is ModelModuleSymbol mms)
                    {
                        if (mms.Model is ImmutableModel im) _modelGroup.AddReference(im);
                        else if (mms.Model is MutableModel mm) _modelGroup.AddReference(mm);
                        else if (mms.Model is ImmutableModelGroup img) _modelGroup.AddReference(img);
                        else if (mms.Model is MutableModelGroup mmg) _modelGroup.AddReference(mmg);
                    }
                }
            }
        }

        public override object CreateModel()
        {
            return _modelGroup.CreateModel(this.Module.Name);
        }

        public override object CreateObject(Type modelObjectType)
        {
            if (_model == null) return null;
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return _model.CreateObject(mdesc.CreateObjectId(), false);
        }

        public override object GetModel(object modelObject)
        {
            var mobj = (IModelObject)modelObject;
            return mobj.MModel;
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

        public override bool ContainsObject(object modelObject)
        {
            var mobj = modelObject as IModelObject;
            if (mobj == null) return false;
            var id = mobj.MId;
            if (_model != null) return _model.ContainsObject(id);
            var module = Module;
            if (module.Model is ImmutableModel im) return im.ContainsObject(id);
            else if (module.Model is MutableModel mm) return mm.ContainsObject(id);
            else if (module.Model is ImmutableModelGroup img) return img.ContainsObject(id);
            else if (module.Model is MutableModelGroup mmg) return mmg.ContainsObject(id);
            return false;
        }
    }
}
