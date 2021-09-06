using MetaDslx.Languages.Meta.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface IModel
    {
        ModelId Id { get; }
        ModelMetadata Metadata { get; }
        IEnumerable<IModelObject> Objects { get; }
        IModelGroup ModelGroup { get; }
    }
}
