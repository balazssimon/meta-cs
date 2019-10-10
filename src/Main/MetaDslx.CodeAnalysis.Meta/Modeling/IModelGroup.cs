using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface IModelGroup
    {
        IEnumerable<IModel> Models { get; }
    }
}
