using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MetaDslx.Core
{
    public class ModelList<T> : ModelCollection, IList<T>
        where T: class
    {
        private List<T> items;

        public ModelList(ModelObject owner, ModelProperty ownerProperty)
            : base(owner, ownerProperty)
        {
            this.items = new List<T>();
        }


        #region IList<T> Members

        public int IndexOf(T item)
        {
            this.FlushLazyItems();
            return this.items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.FlushLazyItems();
            this.items.Insert(index, item);
            this.Owner.MOnAddValue(this.OwnerProperty, item, true);
        }

        public void RemoveAt(int index)
        {
            this.FlushLazyItems();
            object item = this.items[index];
            this.items.RemoveAt(index);
            this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
        }

        public T this[int index]
        {
            get
            {
                this.FlushLazyItems();
                return this.items[index];
            }
            set
            {
                this.FlushLazyItems();
                object item = this.items[index];
                this.items[index] = null;
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
                item = value;
                this.items[index] = value;
                this.Owner.MOnAddValue(this.OwnerProperty, item, true);
            }
        }

        #endregion

        #region ICollection<T> Members

        public void Add(T item)
        {
            this.FlushLazyItems();
            if (!this.items.Contains(item))
            {
                this.items.Add(item);
                this.Owner.MOnAddValue(this.OwnerProperty, item, true);
            }
        }

        public override void Clear()
        {
            this.ClearLazyItems();
            List<T> oldItems = this.items;
            this.items = new List<T>();
            foreach (var item in oldItems)
            {
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
            }
        }

        public bool Contains(T item)
        {
            this.FlushLazyItems();
            return this.items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.FlushLazyItems();
            this.items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                this.FlushLazyItems();
                return this.items.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            this.FlushLazyItems();
            if (this.items.Remove(item))
            {
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
                return true;
            }
            return false;
        }

        public void RemoveAll(T item)
        {
            this.FlushLazyItems();
            bool removed = false;
            while (this.items.Remove(item))
            {
                removed = true;
            }
            if (removed)
            {
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
            }
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            this.FlushLazyItems();
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
            this.FlushLazyItems();
            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        public override bool MAdd(object item)
        {
            if (!this.Contains((T)item))
            {
                this.Add((T)item);
                return true;
            }
            return false;
        }

        public override bool MRemove(object item)
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
