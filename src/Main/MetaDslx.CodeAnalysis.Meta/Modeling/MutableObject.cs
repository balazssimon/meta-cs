using MetaDslx.Modeling.Internal;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling
{
    public interface MutableObject : IModelObject
    {
        bool MIsReadOnly { get; }
        new MutableModel MModel { get; }
        new MutableObject MParent { get; }
        new ImmutableModelList<MutableObject> MChildren { get; }

        void MAttachProperty(ModelProperty property);

        new string MName { get; set; }


        // TODO:MetaDslx - provide initialization, e.g. MInit, MTrySet, etc.
        object MGetTag(ModelProperty property);
        object MGetTag(ModelProperty property, object value);
        void MSet(ModelProperty property, object value, object tag = null);
        void MSetLazy(ModelProperty property, LazyValue value);
        void MAdd(ModelProperty property, object value, object tag = null);
        void MAddLazy(ModelProperty property, LazyValue value);
        void MAddRange(ModelProperty property, IEnumerable<object> value, object tag = null);
        void MAddRangeLazy(ModelProperty property, IEnumerable<LazyValue> value);
        void MMakeCreated();

        ImmutableObject ToImmutable();
        ImmutableObject ToImmutable(ImmutableModel immutableModel);
    }

}
