using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    // GREEN:

    internal abstract class GreenList
    {
        private GreenSymbol parent;
        private ModelProperty property;
        private bool allowMultipleItems;

        internal GreenList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
        {
            this.parent = parent;
            this.property = property;
            this.allowMultipleItems = allowMultipleItems;
        }

        internal GreenSymbol Parent { get { return this.parent; } }
        internal ModelProperty Property { get { return this.property; } }
        internal bool AllowMultipleItems { get { return this.allowMultipleItems; } }

        public abstract int Count { get; }
        internal abstract bool Contains(object item);
        internal abstract bool Insert(int index, object item);
        internal abstract bool Remove(object item);
        internal abstract bool RemoveAt(int index, object item);
        internal abstract bool RemoveAll(object item);
    }

    internal class GreenValueList : GreenList, IReadOnlyList<object>
    {
        private List<object> items;

        internal GreenValueList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
            : base(parent, property, allowMultipleItems)
        {
            this.items = new List<object>();
        }

        internal GreenValueList(GreenValueList other)
            : base(other.Parent, other.Property, other.AllowMultipleItems)
        {
            this.items = new List<object>(other.items);
        }

        public override int Count { get { return this.items.Count; } }
        public object this[int index] { get { return this.items[index]; } }

        public IEnumerator<object> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal bool Add(object item)
        {
            if (this.AllowMultipleItems || !this.items.Contains(item))
            {
                this.items.Add(item);
                return true;
            }
            return false;
        }

        internal override bool Remove(object item)
        {
            return this.items.Remove(item);
        }

        internal override bool Contains(object item)
        {
            return this.items.Contains(item);
        }

        internal override bool Insert(int index, object item)
        {
            if (this.AllowMultipleItems || !this.items.Contains(item))
            {
                this.items.Insert(index, item);
                return true;
            }
            return false;
        }

        internal override bool RemoveAt(int index, object item)
        {
            if (this.items[index] == item)
            {
                this.items.RemoveAt(index);
                return true;
            }
            return false;
        }

        internal override bool RemoveAll(object item)
        {
            return this.items.RemoveAll(i => i == item) > 0;
        }
    }

    internal class GreenSymbolList : GreenList, IReadOnlyList<GreenSymbol>
    {
        private List<GreenSymbol> items;

        internal GreenSymbolList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
            : base(parent, property, allowMultipleItems)
        {
            this.items = new List<GreenSymbol>();
        }

        internal GreenSymbolList(GreenSymbolList other)
            : base(other.Parent, other.Property, other.AllowMultipleItems)
        {
            this.items = new List<GreenSymbol>(other.items);
        }

        public override int Count { get { return this.items.Count; } }
        public GreenSymbol this[int index] { get { return this.items[index]; } }

        public IEnumerator<GreenSymbol> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal bool Add(GreenSymbol item)
        {
            if (this.AllowMultipleItems || !this.items.Contains(item))
            {
                this.items.Add(item);
                return true;
            }
            return false;
        }

        internal bool Remove(GreenSymbol item)
        {
            return this.items.Remove(item);
        }

        internal override bool Remove(object item)
        {
            return this.items.Remove(item as GreenSymbol);
        }

        internal override bool Contains(object item)
        {
            return this.items.Contains(item);
        }

        internal override bool Insert(int index, object item)
        {
            if (!(item is GreenSymbol)) return false;
            if (this.AllowMultipleItems || !this.items.Contains(item))
            {
                if (index < 0) index = 0;
                if (index > this.items.Count) index = this.items.Count;
                this.items.Insert(index, (GreenSymbol)item);
                return true;
            }
            return false;
        }

        internal override bool RemoveAt(int index, object item)
        {
            if (this.items[index] == item)
            {
                this.items.RemoveAt(index);
                return true;
            }
            return false;
        }

        internal override bool RemoveAll(object item)
        {
            return this.items.RemoveAll(i => i == item) > 0;
        }
    }

}
