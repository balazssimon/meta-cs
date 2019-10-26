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
        public abstract bool IsUnique { get; }

        public abstract int Count { get; }

        public abstract bool Contains(T item);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal static ImmutableModelSet<T> FromGreenList(GreenList green, ImmutableModel model, ObjectId context)
        {
            return new ImmutableModelSetFromGreenListImmutable<T>(green, model, context);
        }

        internal static ImmutableModelSet<T> FromGreenSingleValue(object value, ImmutableModel model, ObjectId context)
        {
            return new ImmutableModelSetFromGreenSingle<T>(value, model, context);
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
    internal class ImmutableModelSetFromGreenSingle<T> : ImmutableModelSet<T>
    {
        private object greenValue;
        private ImmutableModel model;
        private ObjectId context;

        internal ImmutableModelSetFromGreenSingle(object greenValue, ImmutableModel model, ObjectId context)
        {
            this.greenValue = greenValue;
            this.model = model;
            this.context = context;
        }

        public override bool IsUnique => true;

        public override int Count => this.greenValue == GreenObject.Unassigned ? 0 : 1;

        private int LazyCount => this.greenValue is LazyValue ? 1 : 0;

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
