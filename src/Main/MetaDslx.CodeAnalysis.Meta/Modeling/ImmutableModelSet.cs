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
    public abstract class ImmutableModelSet<T> : IImmutableModelCollection<T>
    {
        public static readonly ImmutableModelSet<T> Empty = new ImmutableModelSetFromEnumerableSet<T>();

        /*public MutableModelSet<TMutable> ToMutable<TMutable>()
        {
            var mutableItems = this.Select(item => item is ImmutableObject immObj ? (TMutable)immObj.ToMutable() : (TMutable)(object)item);
            if (this.IsUnique) return MutableModelSet<TMutable>.CreateUnique(mutableItems);
            else return MutableModelSet<TMutable>.CreateNonUnique(mutableItems);
        }

        public MutableModelSet<TMutable> ToMutable<TMutable>(MutableModel model)
        {
            var mutableItems = this.Select(item => item is ImmutableObject immObj ? (TMutable)immObj.ToMutable(model) : (TMutable)(object)item);
            if (this.IsUnique) return MutableModelSet<TMutable>.CreateUnique(mutableItems);
            else return MutableModelSet<TMutable>.CreateNonUnique(mutableItems);
        }*/

        public abstract bool IsUnique { get; }

        public abstract int Count { get; }

        public abstract bool Contains(T item);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /*
        public static ImmutableModelSet<T> CreateUnique(IEnumerable<T> items)
        {
            return new ImmutableModelSetFromEnumerableSet<T>(items);
        }

        public static ImmutableModelSet<T> CreateNonUnique(IEnumerable<T> items)
        {
            return new ImmutableModelSetFromEnumerableList<T>(items);
        }

        public static ImmutableModelSet<T> CreateUnique(ImmutableHashSet<T> items)
        {
            return new ImmutableModelSetFromEnumerableSet<T>(items);
        }

        public static ImmutableModelSet<T> CreateNonUnique(ImmutableList<T> items)
        {
            return new ImmutableModelSetFromEnumerableList<T>(items);
        }*/

        internal static ImmutableModelSet<T> FromGreenList(GreenList green, ImmutableModel model, ObjectId context)
        {
            return new ImmutableModelSetFromGreenListImmutable<T>(green, model, context);
        }

        internal static ImmutableModelSet<T> FromGreenList(GreenList green, MutableModel model, ObjectId context)
        {
            return new ImmutableModelSetFromGreenListMutable<T>(green, model, context);
        }

        internal static ImmutableModelSet<T> FromObjectIdList(ImmutableList<ObjectId> green, ImmutableModel model)
        {
            return new ImmutableModelSetFromObjectIdListImmutable<T>(green, model);
        }

        internal static ImmutableModelSet<T> FromObjectIdList(ImmutableList<ObjectId> green, MutableModel model)
        {
            return new ImmutableModelSetFromObjectIdListMutable<T>(green, model);
        }
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal class ImmutableModelSetFromEnumerableSet<T> : ImmutableModelSet<T>
    {
        private ImmutableHashSet<T> items;

        internal ImmutableModelSetFromEnumerableSet()
        {
            this.items = ImmutableHashSet<T>.Empty;
        }

        internal ImmutableModelSetFromEnumerableSet(IEnumerable<T> items)
        {
            this.items = items.ToImmutableHashSet();
        }

        internal ImmutableModelSetFromEnumerableSet(ImmutableHashSet<T> items)
        {
            this.items = items;
        }

        public override bool IsUnique => true;

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
    internal class ImmutableModelSetFromEnumerableList<T> : ImmutableModelSet<T>
    {
        private ImmutableList<T> items;

        internal ImmutableModelSetFromEnumerableList()
        {
            this.items = ImmutableList<T>.Empty;
        }

        internal ImmutableModelSetFromEnumerableList(IEnumerable<T> items)
        {
            this.items = items.ToImmutableList();
        }

        internal ImmutableModelSetFromEnumerableList(ImmutableList<T> items)
        {
            this.items = items;
        }

        public override bool IsUnique => false;

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
    internal class ImmutableModelSetFromGreenListImmutable<T> : ImmutableModelSet<T>
    {
        private GreenList green;
        private ImmutableModel model;
        private ObjectId context;

        internal ImmutableModelSetFromGreenListImmutable(GreenList green, ImmutableModel model, ObjectId context)
        {
            this.green = green;
            this.model = model;
            this.context = context;
        }

        public override bool IsUnique => this.green.IsUnique;

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
    internal class ImmutableModelSetFromGreenListMutable<T> : ImmutableModelSet<T>
    {
        private GreenList green;
        private MutableModel model;
        private ObjectId context;

        internal ImmutableModelSetFromGreenListMutable(GreenList green, MutableModel model, ObjectId context)
        {
            this.green = green;
            this.model = model;
        }

        public override bool IsUnique => this.green.IsUnique;

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
    internal class ImmutableModelSetFromObjectIdListImmutable<T> : ImmutableModelSet<T>
    {
        private ImmutableList<ObjectId> green;
        private ImmutableModel model;

        internal ImmutableModelSetFromObjectIdListImmutable(ImmutableList<ObjectId> green, ImmutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override bool IsUnique => false;

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
    internal class ImmutableModelSetFromObjectIdListMutable<T> : ImmutableModelSet<T>
    {
        private ImmutableList<ObjectId> green;
        private MutableModel model;

        internal ImmutableModelSetFromObjectIdListMutable(ImmutableList<ObjectId> green, MutableModel model)
        {
            this.green = green;
            this.model = model;
        }

        public override bool IsUnique => false;

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
