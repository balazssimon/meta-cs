using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class GreenList : IEnumerable<object>
    {
        internal static readonly GreenList EmptyUnique = new GreenList(true);
        internal static readonly GreenList EmptyNonUnique = new GreenList(false);

        private bool unique;
        private int taggedValueCount;
        private ImmutableList<object> items;
        private ImmutableList<LazyValue> lazyItems;

        private GreenList(bool unique)
        {
            this.unique = unique;
            this.items = ImmutableList<object>.Empty;
            this.lazyItems = ImmutableList<LazyValue>.Empty;
        }

        private GreenList(bool unique, int taggedValueCount, ImmutableList<object> items, ImmutableList<LazyValue> lazyItems)
        {
            this.unique = unique;
            this.taggedValueCount = taggedValueCount;
            this.items = items;
            this.lazyItems = lazyItems;
        }

        private GreenList Update(int taggedValueCount, ImmutableList<object> items, ImmutableList<LazyValue> lazyItems)
        {
            if (this.items != items || this.lazyItems != lazyItems)
            {
                return new GreenList(this.unique, taggedValueCount >= 0 ? taggedValueCount : items.Count(it => it is GreenValueWithTag), items, lazyItems);
            }
            return this;
        }

        private int IsTagged(object value)
        {
            return value is GreenValueWithTag ? 1 : 0;
        }

        internal bool IsUnique => this.unique;

        internal int TaggedValueCount => this.taggedValueCount;

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
            return this.Update(0, this.items.Clear(), this.lazyItems);
        }

        internal GreenList ClearLazy()
        {
            return this.Update(this.taggedValueCount, this.items, this.lazyItems.Clear());
        }

        internal bool Contains(object value)
        {
            if (this.taggedValueCount == 0) return this.items.Contains(GreenObject.ExtractValue(value));
            else return this.items.Any(it => GreenObject.Equals(it, value));
        }

        internal int IndexOf(object value)
        {
            if (this.taggedValueCount == 0) return this.items.IndexOf(GreenObject.ExtractValue(value));
            else return this.items.FindIndex(it => GreenObject.Equals(it, value));
        }

        internal GreenList Add(object value)
        {
            if (value == null) return this;
            if (this.unique && this.Contains(value)) return this;
            return this.Update(this.taggedValueCount + IsTagged(value), this.items.Add(value), this.lazyItems);
        }

        internal GreenList AddLazy(LazyValue value)
        {
            if (value == null) return this;
            return this.Update(this.taggedValueCount, this.items, this.lazyItems.Add(value));
        }

        internal GreenList AddRange(IEnumerable<object> items)
        {
            GreenList result = this;
            foreach (var item in items)
            {
                if (item == null) continue;
                if (!this.unique || !result.Contains(item))
                {
                    result = result.Update(this.taggedValueCount + IsTagged(item), result.items.Add(item), this.lazyItems);
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
                    result = result.Update(this.taggedValueCount + IsTagged(item), result.items.Add(item), this.lazyItems);
                }
            }
            return result;
        }

        internal GreenList Insert(int index, object value)
        {
            if (value == null) return this;
            if (this.unique && this.Contains(value)) return this;
            return this.Update(this.taggedValueCount + IsTagged(value), this.items.Insert(index, value), this.lazyItems);
        }

        internal GreenList Replace(object oldValueWithTag, object newValueWithTag)
        {
            var oldValue = GreenObject.ExtractValue(oldValueWithTag);
            if (oldValue == null || object.Equals(oldValueWithTag, newValueWithTag)) return this;
            var newValue = GreenObject.ExtractValue(newValueWithTag);
            if (newValue == null) return this.Remove(oldValueWithTag);
            var newTag = IsTagged(newValueWithTag);
            if (this.unique && this.Contains(newValueWithTag)) return this.Remove(oldValueWithTag);
            if (this.taggedValueCount == 0 && newTag == 0) return this.Update(0, this.items.Replace(oldValue, newValue), this.lazyItems);
            var newTaggedValueCount = this.taggedValueCount;
            var newItems = this.items;
            var index = newItems.FindIndex(it => GreenObject.Equals(it, oldValue));
            if (this.unique)
            {
                return this.RemoveAt(index).Insert(index, newValueWithTag);
            }
            else
            {
                while (index >= 0)
                {
                    var oldItem = newItems[index];
                    newTaggedValueCount += newTag - IsTagged(oldItem);
                    newItems = newItems.SetItem(index, newValueWithTag);
                    index = newItems.FindIndex(index + 1, it => GreenObject.Equals(it, oldValue));
                }
                return this.Update(newTaggedValueCount, newItems, this.lazyItems);
            }
        }

        internal GreenList Remove(object value)
        {
            if (value == null) return this;
            if (this.taggedValueCount == 0) return this.Update(0, this.items.Remove(GreenObject.ExtractValue(value)), this.lazyItems);
            int index = this.IndexOf(value);
            if (index >= 0) return this.RemoveAt(index);
            else return this;
        }

        internal GreenList RemoveAll(object value)
        {
            if (value == null) return this;
            GreenList result = this;
            int index = result.IndexOf(value);
            while (index >= 0)
            {
                result = result.RemoveAt(index);
                index = result.IndexOf(value);
            }
            return result;
        }

        internal GreenList RemoveAt(int index)
        {
            var oldTag = IsTagged(this.items[index]);
            return this.Update(this.taggedValueCount - oldTag, this.items.RemoveAt(index), this.lazyItems);
        }

        internal GreenList SetItem(int index, object value)
        {
            if (value == null) return this;
            if (this.unique)
            {
                int oldIndex = this.IndexOf(value);
                if (oldIndex >= 0 && index != oldIndex)
                {
                    int newIndex = index;
                    if (oldIndex < newIndex) --newIndex;
                    return this.RemoveAt(oldIndex).Insert(newIndex, value);
                }
            }
            return this.RemoveAt(index).Insert(index, value);
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
            get { return string.Format("Count={0}, LazyCount={1}, TaggedCount={2}", this.items.Count, this.lazyItems.Count, this.taggedValueCount); }
        }
    }


}
