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

        public ModelList(ModelObject owner, ModelProperty ownerProperty, IEnumerable<T> values)
            : base(owner, ownerProperty)
        {
            this.items = new List<T>();
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        public ModelList(ModelObject owner, ModelProperty ownerProperty, IEnumerable<Lazy<object>> values)
            : base(owner, ownerProperty)
        {
            this.items = new List<T>();
            foreach (var value in values)
            {
                this.MLazyAdd(value);
            }
        }

        #region IList<T> Members

        public int IndexOf(T item)
        {
            this.MFlushLazyItems();
            return this.items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.MFlushLazyItems();
            this.items.Insert(index, item);
            this.Owner.MOnAddValue(this.OwnerProperty, item, true);
        }

        public void RemoveAt(int index)
        {
            this.MFlushLazyItems();
            object item = this.items[index];
            this.items.RemoveAt(index);
            this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
        }

        public T this[int index]
        {
            get
            {
                this.MFlushLazyItems();
                return this.items[index];
            }
            set
            {
                this.MFlushLazyItems();
                object item = this.items[index];
                this.items[index] = null;
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
                if (this.items.Contains(value))
                {
                    this.items.RemoveAt(index);
                }
                else
                {
                    item = value;
                    this.items[index] = value;
                    this.Owner.MOnAddValue(this.OwnerProperty, item, true);
                }
            }
        }

        #endregion

        #region ICollection<T> Members

        public void Add(T item)
        {
            this.MFlushLazyItems();
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
            this.MFlushLazyItems();
            return this.items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.MFlushLazyItems();
            this.items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                this.MFlushLazyItems();
                return this.items.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            this.MFlushLazyItems();
            if (this.items.Remove(item))
            {
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
                return true;
            }
            return false;
        }

        public void RemoveAll(T item)
        {
            this.MFlushLazyItems();
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

        public new IEnumerator<T> GetEnumerator()
        {
            this.MFlushLazyItems();
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
            this.MFlushLazyItems();
            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        public override bool MAdd(object item, bool firstCall)
        {
            this.MFlushLazyItems();
            if (!this.items.Contains(item))
            {
                this.items.Add((T)item);
                this.Owner.MOnAddValue(this.OwnerProperty, item, firstCall);
                return true;
            }
            return false;
        }

        public override bool MRemove(object item, bool firstCall)
        {
            this.MFlushLazyItems();
            if (this.items.Remove((T)item))
            {
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, firstCall);
                return true;
            }
            return false;
        }

        public override IEnumerator<object> MGetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class ModelMultiList<T> : ModelCollection, IList<T>
        where T : class
    {
        private List<T> items;

        public ModelMultiList(ModelObject owner, ModelProperty ownerProperty)
            : base(owner, ownerProperty)
        {
            if (ownerProperty.OppositeProperties.Count() > 0)
            {
                throw new InvalidOperationException("Multi lists cannot have opposite properties.");
            }
            this.items = new List<T>();
        }

        public ModelMultiList(ModelObject owner, ModelProperty ownerProperty, IEnumerable<T> values)
            : base(owner, ownerProperty)
        {
            if (ownerProperty.OppositeProperties.Count() > 0)
            {
                throw new InvalidOperationException("Multi lists cannot have opposite properties.");
            }
            this.items = new List<T>();
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        public ModelMultiList(ModelObject owner, ModelProperty ownerProperty, IEnumerable<Lazy<object>> values)
            : base(owner, ownerProperty)
        {
            if (ownerProperty.OppositeProperties.Count() > 0)
            {
                throw new InvalidOperationException("Multi lists cannot have opposite properties.");
            }
            this.items = new List<T>();
            foreach (var value in values)
            {
                this.MLazyAdd(value);
            }
        }

        #region IList<T> Members

        public int IndexOf(T item)
        {
            this.MFlushLazyItems();
            return this.items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.MFlushLazyItems();
            this.items.Insert(index, item);
            this.Owner.MOnAddValue(this.OwnerProperty, item, true);
        }

        public void RemoveAt(int index)
        {
            this.MFlushLazyItems();
            object item = this.items[index];
            this.items.RemoveAt(index);
            this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
        }

        public T this[int index]
        {
            get
            {
                this.MFlushLazyItems();
                return this.items[index];
            }
            set
            {
                this.MFlushLazyItems();
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
            this.MFlushLazyItems();
            this.items.Add(item);
            this.Owner.MOnAddValue(this.OwnerProperty, item, true);
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
            this.MFlushLazyItems();
            return this.items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.MFlushLazyItems();
            this.items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                this.MFlushLazyItems();
                return this.items.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            this.MFlushLazyItems();
            if (this.items.Remove(item))
            {
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
                return true;
            }
            return false;
        }

        public void RemoveAll(T item)
        {
            this.MFlushLazyItems();
            while (this.items.Remove(item))
            {
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
            }
        }

        #endregion

        #region IEnumerable<T> Members

        public new IEnumerator<T> GetEnumerator()
        {
            this.MFlushLazyItems();
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
            this.MFlushLazyItems();
            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        public override bool MAdd(object item, bool firstCall)
        {
            this.MFlushLazyItems();
            if (firstCall)
            {
                this.items.Add((T)item);
                this.Owner.MOnAddValue(this.OwnerProperty, item, firstCall);
                return true;
            }
            return false;
        }

        public override bool MRemove(object item, bool firstCall)
        {
            this.MFlushLazyItems();
            if (firstCall)
            {
                if (this.items.Remove((T)item))
                {
                    this.Owner.MOnRemoveValue(this.OwnerProperty, item, firstCall);
                    return true;
                }
            }
            return false;
        }

        public override IEnumerator<object> MGetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
