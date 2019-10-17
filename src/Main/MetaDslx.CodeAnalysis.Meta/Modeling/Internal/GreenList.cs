using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class GreenList : IEnumerable<object>
    {
        internal static readonly GreenList EmptyUnique = new GreenList(true);
        internal static readonly GreenList EmptyNonUnique = new GreenList(false);

        private bool unique;
        private ImmutableList<object> items;
        private ImmutableList<LazyValue> lazyItems;

        private GreenList(bool unique)
        {
            this.unique = unique;
            this.items = ImmutableList<object>.Empty;
            this.lazyItems = ImmutableList<LazyValue>.Empty;
        }

        private GreenList(bool unique, ImmutableList<object> items, ImmutableList<LazyValue> lazyItems)
        {
            this.unique = unique;
            this.items = items;
            this.lazyItems = lazyItems;
        }

        private GreenList Update(ImmutableList<object> items, ImmutableList<LazyValue> lazyItems)
        {
            if (this.items != items || this.lazyItems != lazyItems)
            {
                return new GreenList(this.unique, items, lazyItems);
            }
            return this;
        }

        internal bool IsUnique => this.unique;

        internal int Count
        {
            get { return this.items.Count; }
        }

        internal object this[int index]
        {
            get { return this.items[index]; }
        }

        internal bool HasLazyItems
        {
            get { return this.lazyItems.Count > 0; }
        }

        internal ImmutableList<LazyValue> LazyItems
        {
            get { return this.lazyItems; }
        }

        internal GreenList Clear()
        {
            return this.Update(this.items.Clear(), this.lazyItems);
        }

        internal GreenList ClearLazy()
        {
            return this.Update(this.items, this.lazyItems.Clear());
        }

        internal bool Contains(object value)
        {
            return this.items.Contains(value);
        }

        internal int IndexOf(object value)
        {
            return this.items.IndexOf(value);
        }

        internal GreenList Add(object value)
        {
            if (value == null) return this;
            if (this.unique && this.items.Contains(value)) return this;
            return this.Update(this.items.Add(value), this.lazyItems);
        }

        internal GreenList AddLazy(LazyValue value)
        {
            if (value == null) return this;
            return this.Update(this.items, this.lazyItems.Add(value));
        }

        internal GreenList AddRange(IEnumerable<object> items)
        {
            GreenList result = this;
            foreach (var item in items)
            {
                if (item == null) continue;
                if (!this.unique || !result.Contains(item))
                {
                    result = result.Update(result.items.Add(item), this.lazyItems);
                }
            }
            return result;
        }

        internal GreenList AddRange(GreenList items)
        {
            GreenList result = this;
            foreach (var item in items)
            {
                if (item == null) continue;
                if (!this.unique || !result.Contains(item))
                {
                    result = result.Update(result.items.Add(item), this.lazyItems);
                }
            }
            return result;
        }

        internal GreenList Insert(int index, object element)
        {
            if (element == null) return this;
            if (this.unique && this.items.Contains(element))
            {
                ImmutableList<object> newItems = this.items.Remove(element);
                if (index < 0) index = 0;
                if (index > newItems.Count) index = newItems.Count;
                return this.Update(newItems.Insert(index, element), this.lazyItems);
            }
            else
            {
                if (index < 0) index = 0;
                if (index > this.items.Count) index = this.items.Count;
                return this.Update(this.items.Insert(index, element), this.lazyItems);
            }
        }

        internal GreenList Replace(object oldValue, object newValue)
        {
            if (newValue == null) return this.Update(this.items.Remove(oldValue), this.lazyItems);
            else return this.Update(this.items.Replace(oldValue, newValue), this.lazyItems);
        }

        internal GreenList Remove(object value)
        {
            if (value == null) return this;
            return this.Update(this.items.Remove(value), this.lazyItems);
        }

        internal GreenList RemoveAll(object value)
        {
            if (value == null) return this;
            return this.Update(this.items.RemoveAll(v => v == value), this.lazyItems);
        }

        internal GreenList RemoveAt(int index)
        {
            return this.Update(this.items.RemoveAt(index), this.lazyItems);
        }

        internal GreenList SetItem(int index, object value)
        {
            if (value == null) return this;
            return this.Update(this.items.SetItem(index, value), this.lazyItems);
        }

        public IEnumerator<object> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count={0}, LazyCount={1}", this.items.Count, this.lazyItems.Count); }
        }
    }


}
