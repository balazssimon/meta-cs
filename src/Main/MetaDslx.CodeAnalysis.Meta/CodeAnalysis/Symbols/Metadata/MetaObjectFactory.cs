using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaObjectFactory : ObjectFactory
    {
        public MetaObjectFactory(LanguageCompilation compilation)
            : base(compilation)
        {
        }

        public override object CreateModel()
        {
            var modelGroup = new MutableModelGroup();
            object model = modelGroup.CreateModel(Compilation.AssemblyName);
            foreach (var reference in ReferencedModels)
            {
                if (reference is ImmutableModel im) modelGroup.AddReference(im);
                else if (reference is MutableModel mm) modelGroup.AddReference(mm);
                else if (reference is ImmutableModelGroup img) modelGroup.AddReference(img);
                else if (reference is MutableModelGroup mmg) modelGroup.AddReference(mmg);
            }
            return model;
        }

        public override object CreateObject(Type modelObjectType)
        {
            var mmodel = (MutableModel)Model;
            var mdesc = ModelObjectDescriptor.GetDescriptor(modelObjectType);
            return mmodel.CreateObject(mdesc.CreateObjectId(), false);
        }

    }
}
