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
        public static readonly ImmutableModelList<T> Empty = new ImmutableModelListFromEnumerable<T>(true);
        public static readonly ImmutableModelList<T> EmptyNonUnique = new ImmutableModelListFromEnumerable<T>(false);

        public abstract bool IsUnique { get; }

        public abstract T this[int index] { get; }

        public abstract int Count { get; }

        public abstract bool Contains(T item);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal static ImmutableModelList<T> FromGreenList(GreenList green, ImmutableModel model, ObjectId context)
        {
            return new ImmutableModelListFromGreenListImmutable<T>(green, model, context);
        }

        internal static ImmutableModelList<T> FromGreenList(GreenList green, MutableModel model, ObjectId context)
        {
            return new ImmutableModelListFromGreenListMutable<T>(green, model, context);
        }

        internal static ImmutableModelList<T> FromObjectIdList(ImmutableList<ObjectId> green, ImmutableModel model)
        {
            return new ImmutableModelListFromObjectIdListImmutable<T>(green, model);
        }

        internal static ImmutableModelList<T> FromObjectIdList(ImmutableList<ObjectId> green, MutableModel model)
        {
            return new ImmutableModelListFromObjectIdListMutable<T>(green, model);
        }

        internal static ImmutableModelList<T> FromGreenSingleValue(object value, ImmutableModel model, ObjectId context)
        {
            return new ImmutableModelListFromGreenSingle<T>(value, model, context);
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelListFromEnumerable<T> : ImmutableModelList<T>
    {
        private bool unique;
        private ImmutableList<T> items;

        internal ImmutableModelListFromEnumerable(bool unique)
        {
            this.unique = unique;
            this.items = ImmutableList<T>.Empty;
        }

        internal ImmutableModelListFromEnumerable(IEnumerable<T> items, bool unique)
        {
            this.unique = unique;
            if (unique) this.items = items.Distinct().ToImmutableList();
            else this.items = items.ToImmutableList();
        }

        internal ImmutableModelListFromEnumerable(ISet<T> items, bool unique)
        {
            this.unique = unique;
            this.items = items.ToImmutableList();
        }

        internal ImmutableModelListFromEnumerable(ImmutableHashSet<T> items, bool unique)
        {
            this.unique = unique;
            this.items = items.ToImmutableList();
        }

        public override bool IsUnique => this.unique;

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
        private ObjectId context;

        internal ImmutableModelListFromGreenListImmutable(GreenList green, ImmutableModel model, ObjectId context)
        {
            this.green = green;
            this.model = model;
            this.context = context;
        }

        public override bool IsUnique => this.green.IsUnique;

        public override T this[int index]
        {
            get { return (T)this.model.ToRedValue(this.green[index], context); }
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
                yield return (T)this.model.ToRedValue(value, context);
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
        private ObjectId context;

        internal ImmutableModelListFromGreenListMutable(GreenList green, MutableModel model, ObjectId context)
        {
            this.green = green;
            this.model = model;
            this.context = context;
        }

        public override bool IsUnique => this.green.IsUnique;

        public override T this[int index]
        {
            get { return (T)this.model.ToRedValue(this.green[index], context); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(MutableModel.ToGreenValue(item, null));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.green)
            {
                yield return (T)this.model.ToRedValue(value, context);
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

        public override bool IsUnique => false;

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

        public override bool IsUnique => false;

        public override T this[int index]
        {
            get { return (T)(object)this.model.ResolveObject(this.green[index]); }
        }

        public override int Count { get { return this.green.Count; } }

        public override bool Contains(T item)
        {
            return this.green.Contains(MutableModel.ToGreenValue(item, null));
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
    internal class ImmutableModelListFromGreenSingle<T> : ImmutableModelList<T>
    {
        private object greenValue;
        private ImmutableModel model;
        private ObjectId context;

        internal ImmutableModelListFromGreenSingle(object greenValue, ImmutableModel model, ObjectId context)
        {
            this.greenValue = greenValue;
            this.model = model;
            this.context = context;
        }

        public override bool IsUnique => true;

        public override int Count => this.greenValue == GreenObject.Unassigned ? 0 : 1;

        private int LazyCount => this.greenValue is LazyValue ? 1 : 0;

        public override T this[int index]
        {
            get 
            {
                if (index != 0) throw new IndexOutOfRangeException(string.Format("Invalid index: {0}", index));
                return (T)this.model.ToRedValue(this.greenValue, context);
            }
        }

        public override bool Contains(T item)
        {
            var itemGreen = this.model.ToGreenValue(item);
            return (this.greenValue == null && itemGreen == null) || (this.greenValue != null && this.greenValue.Equals(itemGreen));
        }

        public override IEnumerator<T> GetEnumerator()
        {
            if (this.greenValue == GreenObject.Unassigned) yield break;
            else yield return (T)this.model.ToRedValue(this.greenValue, context);
        }

        private string DebuggerDisplay
        {
            get { return string.Format("Count = {0}, LazyCount = {1}", this.Count, this.LazyCount); }
        }
    }

}
