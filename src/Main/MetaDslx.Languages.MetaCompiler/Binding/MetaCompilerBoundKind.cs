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

namespace MetaDslx.Languages.MetaCompiler.Binding
{
    public class MetaCompilerBoundKind : BoundKind
    {

        protected MetaCompilerBoundKind(string name)
            : base(name)
        {
        }

        protected MetaCompilerBoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MetaCompilerBoundKind()
        {
            EnumObject.AutoInit<MetaCompilerBoundKind>();
        }

        public static implicit operator MetaCompilerBoundKind(string name)
        {
            return FromString<MetaCompilerBoundKind>(name);
        }

        public static explicit operator MetaCompilerBoundKind(int value)
        {
            return FromIntUnsafe<MetaCompilerBoundKind>(value);
        }
    }
}

