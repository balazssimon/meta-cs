using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MetaDslx.Core
{
    public class MetaList<T> : MetaCollection, IList<T>
        where T: class
    {
        private List<T> items;

        public MetaList(MetaObject owner, MetaProperty ownerProperty)
            : base(owner, ownerProperty)
        {
            this.items = new List<T>();
        }

        #region IList<T> Members

        public int IndexOf(T item)
        {
            return this.items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.items.Insert(index, item);
            this.Owner.MetaOnAddValue(this.OwnerProperty, item, true);
        }

        public void RemoveAt(int index)
        {
            object item = this.items[index];
            this.items.RemoveAt(index);
            this.Owner.MetaOnRemoveValue(this.OwnerProperty, item, true);
        }

        public T this[int index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                object item = this.items[index];
                this.items[index] = null;
                this.Owner.MetaOnRemoveValue(this.OwnerProperty, item, true);
                item = value;
                this.items[index] = value;
                this.Owner.MetaOnAddValue(this.OwnerProperty, item, true);
            }
        }

        #endregion

        #region ICollection<T> Members

        public void Add(T item)
        {
            if (!this.items.Contains(item))
            {
                this.items.Add(item);
                this.Owner.MetaOnAddValue(this.OwnerProperty, item, true);
            }
        }

        public void Clear()
        {
            List<T> oldItems = this.items;
            this.items = new List<T>();
            foreach (var item in oldItems)
            {
                this.Owner.MetaOnRemoveValue(this.OwnerProperty, item, true);
            }
        }

        public bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            if (this.items.Remove(item))
            {
                this.Owner.MetaOnRemoveValue(this.OwnerProperty, item, true);
                return true;
            }
            return false;
        }

        public void RemoveAll(T item)
        {
            bool removed = false;
            while (this.items.Remove(item))
            {
                removed = true;
            }
            if (removed)
            {
                this.Owner.MetaOnRemoveValue(this.OwnerProperty, item, true);
            }
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        internal override bool MetaAdd(object item)
        {
            if (!this.Contains((T)item))
            {
                this.Add((T)item);
                return true;
            }
            return false;
        }

        internal override bool MetaRemove(object item)
        {
            if (this.Contains((T)item))
            {
                this.RemoveAll((T)item);
                return true;
            }
            return false;
        }
    }
}
