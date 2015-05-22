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


        #region ICollection<T> Members

        public void Add(T item)
        {
            if (this.items.Add(item))
            {
                this.Owner.MOnAddValue(this.OwnerProperty, item, true);
            }
        }

        public void Clear()
        {
            HashSet<T> oldItems = this.items;
            this.items = new HashSet<T>();
            foreach (var item in oldItems)
            {
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
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
                this.Owner.MOnRemoveValue(this.OwnerProperty, item, true);
                return true;
            }
            return false;
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
            return this.items.GetEnumerator();
        }

        #endregion


        #region IModelCollection Members

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
                this.Remove((T)item);
                return true;
            }
            return false;
        }

        #endregion

    }
}
