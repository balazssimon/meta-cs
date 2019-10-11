using MetaDslx.Modeling.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.Modeling
{
    public abstract class ImmutableModelList<T> : IImmutableModelCollection<T>, IReadOnlyList<T>
    {
        public static readonly ImmutableModelList<T> Empty = new ImmutableModelListFromEnumerable<T>();

        public abstract T this[int index] { get; }

        public abstract int Count { get; }

        public abstract bool Contains(T item);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public static ImmutableModelList<T> CreateUnique(IEnumerable<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, true);
        }

        public static ImmutableModelList<T> CreateNonUnique(IEnumerable<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, false);
        }

        public static ImmutableModelList<T> CreateUnique(ISet<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, true);
        }

        public static ImmutableModelList<T> CreateUnique(ImmutableHashSet<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, true);
        }

        public static ImmutableModelList<T> CreateNonUnique(ImmutableList<T> items)
        {
            return new ImmutableModelListFromEnumerable<T>(items, false);
        }

        internal static ImmutableModelList<T> FromGreenList(GreenList green, ImmutableModel model)
        {
            return new ImmutableModelListFromGreenListImmutable<T>(green, model);
        }

        internal static ImmutableModelList<T> FromGreenList(GreenList green, MutableModel model)
        {
            return new ImmutableModelListFromGreenListMutable<T>(green, model);
        }

        internal static ImmutableModelList<T> FromObjectIdList(ImmutableList<ObjectId> green, ImmutableModel model)
        {
            return new ImmutableModelListFromObjectIdListImmutable<T>(green, model);
        }

        internal static ImmutableModelList<T> FromObjectIdList(ImmutableList<ObjectId> green, MutableModel model)
        {
            return new ImmutableModelListFromObjectIdListMutable<T>(green, model);
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromEnumerable<T> : ImmutableModelList<T>
    {
        private ImmutableList<T> items;

        internal ImmutableModelListFromEnumerable()
        {
            this.items = ImmutableList<T>.Empty;
        }

        internal ImmutableModelListFromEnumerable(IEnumerable<T> items, bool unique)
        {
            if (unique) this.items = items.Distinct().ToImmutableList();
            else this.items = items.ToImmutableList();
        }

        internal ImmutableModelListFromEnumerable(ISet<T> items, bool unique)
        {
            this.items = items.ToImmutableList();
        }

        internal ImmutableModelListFromEnumerable(ImmutableHashSet<T> items, bool unique)
        {
            this.items = items.ToImmutableList();
        }

        public override T this[int index]
        {
            get { return this.items[index]; }
        }

        public override int Count { get { return this.items.Count; } }

        public override bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.items.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromGreenListImmutable<T> : ImmutableModelList<T>
    {
        private GreenList green;
        private ImmutableModel model;

        internal ImmutableModelListFromGreenListImmutable(GreenList green, ImmutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override T this[int index]
        {
            get { return (T)this.model.ToRedValue(this.green[index]); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.green.Count, this.green.LazyItems.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromGreenListMutable<T> : ImmutableModelList<T>
    {
        private GreenList green;
        private MutableModel model;

        internal ImmutableModelListFromGreenListMutable(GreenList green, MutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override T this[int index]
        {
            get { return (T)this.model.ToRedValue(this.green[index]); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.green.Count, this.green.LazyItems.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromObjectIdListImmutable<T> : ImmutableModelList<T>
    {
        private ImmutableList<ObjectId> green;
        private ImmutableModel model;

        internal ImmutableModelListFromObjectIdListImmutable(ImmutableList<ObjectId> green, ImmutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override T this[int index]
        {
            get { return (T)(object)this.model.ResolveObject(this.green[index]); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveObject(sid);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.green.Count); }
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromObjectIdListMutable<T> : ImmutableModelList<T>
    {
        private ImmutableList<ObjectId> green;
        private MutableModel model;

        internal ImmutableModelListFromObjectIdListMutable(ImmutableList<ObjectId> green, MutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override T this[int index]
        {
            get { return (T)(object)this.model.ResolveObject(this.green[index]); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(this.model.ToGreenValue(item));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var sid in this.green)
            {
                yield return (T)(object)this.model.ResolveObject(sid);
            }
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}", this.green.Count); }
        }
    }


}
