using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Roslyn.Utilities
{
    public struct ExtensibleFlags : IEquatable<ExtensibleFlags>
    {
        private ExtensibleFlagsId _id;
        private ExtensibleBitVector _flags;

        public ExtensibleFlags(ExtensibleFlagsId id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            _id = id;
            _flags = new ExtensibleBitVector();
            _flags[id.NextId()] = true;
        }

        private ExtensibleFlags(ExtensibleFlagsId id, ExtensibleBitVector flags)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            _id = id;
            _flags = flags;
        }

        public ExtensibleFlags(ExtensibleFlagsId id, params ExtensibleFlags[] flags)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            _id = id;
            _flags = new ExtensibleBitVector();
            foreach (var flag in flags)
            {
                Debug.Assert(_id.Equals(flag._id), "The flags are not of the same type.");
                _id = _id.MoreGeneral(flag._id);
                _flags.UnionWith(flag._flags);
            }
        }

        public ExtensibleFlags(params ExtensibleFlags[] flags)
        {
            if (flags.Length == 0) throw new ArgumentException("At least one flag must be specified.", nameof(flags));
            _id = null;
            _flags = new ExtensibleBitVector();
            foreach (var flag in flags)
            {
                Debug.Assert(_id.Equals(flag._id), "The flags are not of the same type.");
                _id = _id == null ? flag._id : _id.MoreGeneral(flag._id);
                _flags.UnionWith(flag._flags);
            }
            if (_id == null) throw new ArgumentException("No ExtensibleFlagsId could be determined.", nameof(flags));
        }

        public bool Equals(ExtensibleFlags other)
        {
            return _id.Equals(other._id) && _flags.Equals(other._flags);
        }

        public static bool operator ==(ExtensibleFlags left, ExtensibleFlags right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExtensibleFlags left, ExtensibleFlags right)
        {
            return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return this.Equals((ExtensibleFlags)obj);
        }

        public override int GetHashCode()
        {
            return _flags.GetHashCode();
        }

        public static ExtensibleFlags operator &(ExtensibleFlags left, ExtensibleFlags right)
        {
            Debug.Assert(left._id.Equals(right._id), "The flags are not of the same type.");
            return left.Intersect(right);
        }

        public static ExtensibleFlags operator |(ExtensibleFlags left, ExtensibleFlags right)
        {
            Debug.Assert(left._id.Equals(right._id), "The flags are not of the same type.");
            return left.Set(right);
        }

        public bool HasAnyFlags
        {
            get { return _flags.IsNonZero; }
        }

        public bool HasNoFlags
        {
            get { return _flags.IsZero; }
        }

        public bool HasFlags(params ExtensibleFlags[] flags)
        {
            if (flags.Length == 0) return true;
            ExtensibleBitVector union = _flags.Clone();
            foreach (var flag in flags)
            {
                Debug.Assert(this._id.Equals(flag._id), "The flags are not of the same type.");
                if (union.IntersectWith(flag._flags)) return false;
            }
            return true;
        }

        public ExtensibleFlags Set(params ExtensibleFlags[] flags)
        {
            if (flags.Length == 0) return this;
            ExtensibleBitVector union = _flags.Clone();
            bool changed = false;
            foreach (var flag in flags)
            {
                Debug.Assert(this._id.Equals(flag._id), "The flags are not of the same type.");
                changed = union.UnionWith(flag._flags) || changed;
            }
            if (changed) return new ExtensibleFlags(_id, union);
            else return this;

        }

        public ExtensibleFlags Intersect(params ExtensibleFlags[] flags)
        {
            if (flags.Length == 0) return this;
            ExtensibleBitVector union = _flags.Clone();
            bool changed = false;
            foreach (var flag in flags)
            {
                Debug.Assert(this._id.Equals(flag._id), "The flags are not of the same type.");
                changed = union.IntersectWith(flag._flags) || changed;
            }
            if (changed) return new ExtensibleFlags(_id, union);
            else return this;
        }

        public ExtensibleFlags Unset(params ExtensibleFlags[] flags)
        {
            if (flags.Length == 0) return this;
            ExtensibleBitVector union = _flags.Clone();
            bool changed = false;
            foreach (var flag in flags)
            {
                Debug.Assert(this._id.Equals(flag._id), "The flags are not of the same type.");
                changed = union.UnsetWith(flag._flags) || changed;
            }
            if (changed) return new ExtensibleFlags(_id, union); 
            else return this;
        }
    }

    public class ExtensibleFlagsId : IEquatable<ExtensibleFlagsId>
    {
        private ExtensibleFlagsId _base;
        private int _maxId;

        public ExtensibleFlagsId()
        {
            _base = null;
            _maxId = 0;
        }

        public ExtensibleFlagsId(ExtensibleFlagsId baseId)
        {
            _base = baseId;
            _maxId = baseId._maxId;
        }

        internal int NextId()
        {
            Interlocked.Increment(ref _maxId);
            return _maxId;
        }

        public ExtensibleFlagsId MoreGeneral(ExtensibleFlagsId other)
        {
            var current = other;
            while (current != null)
            {
                if (object.ReferenceEquals(this, current)) return this;
                current = current._base;
            }
            current = this;
            while (current != null)
            {
                if (object.ReferenceEquals(other, current)) return other;
                current = current._base;
            }
            return null;
        }

        public ExtensibleFlagsId MoreSpecific(ExtensibleFlagsId other)
        {
            var current = other;
            while (current != null)
            {
                if (object.ReferenceEquals(this, current)) return other;
                current = current._base;
            }
            current = this;
            while (current != null)
            {
                if (object.ReferenceEquals(other, current)) return this;
                current = current._base;
            }
            return null;
        }

        public bool Equals(ExtensibleFlagsId other)
        {
            var current = other;
            while (current != null)
            {
                if (object.ReferenceEquals(this, current)) return true;
                current = current._base;
            }
            current = this;
            while (current != null)
            {
                if (object.ReferenceEquals(other, current)) return true;
                current = current._base;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as ExtensibleFlagsId);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
