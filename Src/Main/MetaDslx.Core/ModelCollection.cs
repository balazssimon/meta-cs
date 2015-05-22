using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MetaDslx.Core
{
    public abstract class ModelCollection 
    {
        public ModelObject Owner { get; private set; }
        public ModelProperty OwnerProperty { get; private set; }

        public ModelCollection(ModelObject owner, ModelProperty ownerProperty)
        {
            this.Owner = owner;
            this.OwnerProperty = ownerProperty;
        }

        public abstract bool MAdd(object value);
        public abstract bool MRemove(object value);
    }
}
