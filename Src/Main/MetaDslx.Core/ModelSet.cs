using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MetaDslx.Core
{
    public class ModelSet<T> : ModelCollection, ICollection<T>
        where T: class
    {
        private HashSet<T> items;

        public ModelSet(ModelObject owner, ModelProperty ownerProperty)
            : base(owner, ownerProperty)
        {
            this.items = new HashSet<T>();
        }

        public ModelSet(ModelObject owner, ModelProperty ownerProperty, IEnumerable<T> values)
            : base(owner, ownerProperty)
        {
            this.items = new HashSet<T>();
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        public ModelSet(ModelObject owner, ModelProperty ownerProperty, IEnumerable<Lazy<object>> values)
            : base(owner, ownerProperty)
        {
            this.items = new HashSet<T>();
            foreach (var value in values)
            {
                this.MLazyAdd(value);
            }
        }

        #region ICollection<T> Members

        public void Add(T item)
        {
            this.MFlushLazyItems();
            if (this.items.Add(item))
            {
                this.Owner.MOnAddValue(this.OwnerProperty, item, true);
            }
        }

        public override void Clear()
        {
            this.ClearLazyItems();
            HashSet<T> oldItems = this.items;
            this.items = new HashSet<T>();
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


        #region IModelCollection Members

        public override bool MAdd(object item, bool firstCall)
        {
            this.MFlushLazyItems();
            if (this.items.Add((T)item))
            {
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

        #endregion

        public override IEnumerator<object> MGetEnumerator()
        {
            return this.GetEnumerator();
        }
    }


    public class ModelMultiSet<T> : ModelCollection, ICollection<T>
        where T : class
    {
        private List<T> items;

        public ModelMultiSet(ModelObject owner, ModelProperty ownerProperty)
            : base(owner, ownerProperty)
        {
            if (ownerProperty.OppositeProperties.Count() > 0)
            {
                throw new ModelException("Multi sets cannot have opposite properties.");
            }
            this.items = new List<T>();
        }

        public ModelMultiSet(ModelObject owner, ModelProperty ownerProperty, IEnumerable<T> values)
            : base(owner, ownerProperty)
        {
            if (ownerProperty.OppositeProperties.Count() > 0)
            {
                throw new ModelException("Multi sets cannot have opposite properties.");
            }
            this.items = new List<T>();
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        public ModelMultiSet(ModelObject owner, ModelProperty ownerProperty, IEnumerable<Lazy<object>> values)
            : base(owner, ownerProperty)
        {
            if (ownerProperty.OppositeProperties.Count() > 0)
            {
                throw new InvalidOperationException("Multi sets cannot have opposite properties.");
            }
            this.items = new List<T>();
            foreach (var value in values)
            {
                this.MLazyAdd(value);
            }
        }

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


        #region IModelCollection Members


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

        #endregion

        public override IEnumerator<object> MGetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

}
