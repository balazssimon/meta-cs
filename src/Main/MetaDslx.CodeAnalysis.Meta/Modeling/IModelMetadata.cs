using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public interface IModelMetadata
    {
        public IModel Model { get; }
        public string Name { get; }
        public ModelVersion Version { get; }
        public string Uri { get; }
        public string Prefix { get; }
    }
}
