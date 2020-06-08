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

namespace PilV2.Binding
{
    public class PilBoundKind : BoundKind
    {

        protected PilBoundKind(string name)
            : base(name)
        {
        }

        protected PilBoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static PilBoundKind()
        {
            EnumObject.AutoInit<PilBoundKind>();
        }

        public static implicit operator PilBoundKind(string name)
        {
            return FromString<PilBoundKind>(name);
        }

        public static explicit operator PilBoundKind(int value)
        {
            return FromIntUnsafe<PilBoundKind>(value);
        }
    }
}

