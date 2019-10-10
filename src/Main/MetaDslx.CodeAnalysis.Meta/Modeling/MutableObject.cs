using MetaDslx.Modeling.Internal;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface MutableSymbol : IMetaSymbol
    {
        bool MIsReadOnly { get; }
        new MutableModel MModel { get; }
        new MutableSymbol MParent { get; }
        new ImmutableModelList<MutableSymbol> MChildren { get; }

        void MAttachProperty(ModelProperty property);

        new string MName { get; set; }
        new MutableSymbol MType { get; set; }


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

        ImmutableSymbol ToImmutable();
        ImmutableSymbol ToImmutable(ImmutableModel immutableModel);
    }

}
