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

namespace MetaDslx.Languages.Soal.Binding
{
    public class SoalBoundKind : BoundKind
    {

        protected SoalBoundKind(string name)
            : base(name)
        {
        }

        protected SoalBoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static SoalBoundKind()
        {
            EnumObject.AutoInit<SoalBoundKind>();
        }

        public static implicit operator SoalBoundKind(string name)
        {
            return FromString<SoalBoundKind>(name);
        }

        public static explicit operator SoalBoundKind(int value)
        {
            return FromIntUnsafe<SoalBoundKind>(value);
        }
    }
}

