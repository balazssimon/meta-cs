using MetaDslx.Languages.Meta.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Core
{
    public interface IMetaSymbol
    {
        MetaModel MMetaModel { get; }
        MetaClass MMetaClass { get; }
        SymbolId MId { get; }
        IModel MModel { get; }

        string MName { get; }
        IMetaSymbol MType { get; }

        IMetaSymbol MParent { get; }
        IReadOnlyList<IMetaSymbol> MChildren { get; }

        IReadOnlyList<ModelProperty> MProperties { get; }
        IReadOnlyList<ModelProperty> MAllProperties { get; }
        ModelProperty MGetProperty(string name);
        IReadOnlyList<ModelProperty> MGetProperties(string name);

        object MGet(ModelProperty property);
        T MGetValue<T>(ModelProperty property) where T : struct;
        T MGetReference<T>(ModelProperty property) where T : class;
        bool MHasConcreteValue(ModelProperty property);
        bool MIsSet(ModelProperty property);

        IReadOnlyList<IMetaSymbol> MGetImports();
        IReadOnlyList<IMetaSymbol> MGetBases();
        IReadOnlyList<IMetaSymbol> MGetAllBases();
        IReadOnlyList<IMetaSymbol> MGetMembers();
    }
}
