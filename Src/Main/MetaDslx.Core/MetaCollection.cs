using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MetaDslx.Core
{
    public abstract class MetaCollection 
    {
        public MetaObject Owner { get; private set; }
        public MetaProperty OwnerProperty { get; private set; }

        public MetaCollection(MetaObject owner, MetaProperty ownerProperty)
        {
            this.Owner = owner;
            this.OwnerProperty = ownerProperty;
        }

        internal abstract bool MetaAdd(object value);
        internal abstract bool MetaRemove(object value);
    }
}
