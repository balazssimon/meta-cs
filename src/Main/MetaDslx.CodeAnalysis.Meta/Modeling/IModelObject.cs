using MetaDslx.Languages.Meta.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface IModelObject
    {
        IMetaModel MMetaModel { get; }
        MetaClass MMetaClass { get; }
        ObjectId MId { get; }
        IModel MModel { get; }

        string MName { get; }
        IModelObject MType { get; }

        IModelObject MParent { get; }
        IReadOnlyList<IModelObject> MChildren { get; }

        IReadOnlyList<ModelProperty> MProperties { get; }
        IReadOnlyList<ModelProperty> MAllProperties { get; }
        ModelProperty MGetProperty(string name);
        IReadOnlyList<ModelProperty> MGetProperties(string name);

        object MGet(ModelProperty property);
        T MGetValue<T>(ModelProperty property) where T : struct;
        T MGetReference<T>(ModelProperty property) where T : class;
        bool MHasDefaultValue(ModelProperty property);
        bool MHasConcreteValue(ModelProperty property);
        bool MIsSet(ModelProperty property);
    }
}
