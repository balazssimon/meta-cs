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

        public override bool Equals(object obj)
        {
            if (obj is ModelId other)
            {
                return this.guid == other.guid;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.guid.GetHashCode();
        }
    }
}
