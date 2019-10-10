using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public class ModelId
    {
        private readonly string guid;

        public ModelId()
        {
            this.guid = System.Guid.NewGuid().ToString();
        }

        public string Guid { get { return this.guid; } }
    }
}
