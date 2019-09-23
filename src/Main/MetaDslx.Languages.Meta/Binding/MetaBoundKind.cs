// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Binding;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetaBoundKind : BoundKind
    {
        public const string Opposite = nameof(Opposite);

        protected MetaBoundKind(string name)
            : base(name)
        {
        }

        protected MetaBoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MetaBoundKind()
        {
            EnumObject.AutoInit<MetaBoundKind>();
        }

        public static implicit operator MetaBoundKind(string name)
        {
            return FromString<MetaBoundKind>(name);
        }

        public static explicit operator MetaBoundKind(int value)
        {
            return FromIntUnsafe<MetaBoundKind>(value);
        }
    }
}

