using MetaDslx.Modeling.Internal;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

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
        new MutableObject MType { get; set; }


        // TODO:MetaDslx - provide initialization, e.g. MInit, MTrySet, etc.
        void MSet(ModelProperty property, object value);
        void MSetLazy(ModelProperty property, LazyValue value);
        void MAdd(ModelProperty property, object value);
        void MAddLazy(ModelProperty property, LazyValue value);
        void MAddRange(ModelProperty property, IEnumerable<object> value);
        void MAddRangeLazy(ModelProperty property, LazyValue value);
        void MAddRangeLazy(ModelProperty property, IEnumerable<LazyValue> value);
        void MSetOrAdd(ModelProperty property, object value);
        void MSetOrAddLazy(ModelProperty property, LazyValue value);
        void MMakeCreated();

        void MValidate(DiagnosticBag diagnostics);

        ImmutableObject ToImmutable();
        ImmutableObject ToImmutable(ImmutableModel immutableModel);
    }

}
