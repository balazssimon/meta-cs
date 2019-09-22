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

namespace WebSequenceDiagramsModel.Binding
{
    public class SequenceBoundKind : BoundKind
    {

        protected SequenceBoundKind(string name)
            : base(name)
        {
        }

        protected SequenceBoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static SequenceBoundKind()
        {
            EnumObject.AutoInit<SequenceBoundKind>();
        }

        public static implicit operator SequenceBoundKind(string name)
        {
            return FromString<SequenceBoundKind>(name);
        }

        public static explicit operator SequenceBoundKind(int value)
        {
            return FromIntUnsafe<SequenceBoundKind>(value);
        }
    }
}

