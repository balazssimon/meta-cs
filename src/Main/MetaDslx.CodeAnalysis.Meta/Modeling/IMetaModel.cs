using MetaDslx.Languages.Meta.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface IMetaModel : IModel
    {
        string Uri { get; }
        string Namespace { get; }
    }
}
