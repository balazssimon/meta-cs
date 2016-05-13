using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MetaDslx.Core
{
    public abstract class ModelCollection : IEnumerable<object>
    {
        private List<Lazy<object>> lazyItems;

        public ModelObject Owner { get; private set; }
        public ModelProperty OwnerProperty { get; private set; }

        public ModelCollection(ModelObject owner, ModelProperty ownerProperty)
        {
            this.lazyItems = null;
            this.Owner = owner;
            this.OwnerProperty = ownerProperty;
        }

        public bool MHasLazyItems()
        {
            return this.lazyItems != null && this.lazyItems.Count > 0;
        }

        public void MFlushLazyItems()
        {
            if (this.lazyItems == null) return;
            List<Lazy<object>> lazyCopy = this.lazyItems;
            this.lazyItems = null;
            foreach (var item in lazyCopy)
            {
                if (item.Value != null)
                {
                    this.MAdd(item.Value, true);
                }
            }
        }

        protected void ClearLazyItems()
        {
            if (this.lazyItems == null) return;
            this.lazyItems = null;
        }

        public bool MLazyAdd(Lazy<object> value)
        {
            if (value == null) return false;
            if (this.lazyItems == null)
            {
                this.lazyItems = new List<Lazy<object>>();
            }
            this.lazyItems.Add(value);
            return true;
        }

        public bool MLazyAdd(IEnumerable<Lazy<object>> values)
        {
            if (values == null) return false;
            if (this.lazyItems == null)
            {
                this.lazyItems = new List<Lazy<object>>();
            }
            foreach (var value in values)
            {
                this.MLazyAdd(value);
            }
            return true;
        }
        public abstract void Clear();
        public abstract bool MAdd(object value, bool firstCall);
        public abstract bool MRemove(object value, bool firstCall);

        public abstract IEnumerator<object> MGetEnumerator();

        public IEnumerator<object> GetEnumerator()
        {
            return this.MGetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
