using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public abstract class SymbolId
    {
        private readonly string id;
        public SymbolId()
        {
            this.id = Guid.NewGuid().ToString();
        }
        public string Id { get { return this.id; } }
        public abstract ModelSymbolInfo SymbolInfo { get; }
        public abstract ImmutableSymbolBase CreateImmutable(ImmutableModel model);
        public abstract MutableSymbolBase CreateMutable(MutableModel model, bool creating);
        public string DisplayTypeName => this.SymbolInfo?.ImmutableType?.Name;

        public static bool operator ==(SymbolId left, SymbolId right)
        {
            if ((object)left == null) return (object)right == null;
            else return left.Equals(right);
        }

        public static bool operator !=(SymbolId left, SymbolId right)
        {
            if ((object)left == null) return (object)right != null;
            else return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            if (obj is SymbolId other)
            {
                return this.id == other.id && object.ReferenceEquals(this.SymbolInfo, other.SymbolInfo);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.id.GetHashCode(), this.SymbolInfo.GetHashCode());
        }

        public override string ToString()
        {
            return $"{this.DisplayTypeName} {{{this.id}}}";
        }
    }
}
