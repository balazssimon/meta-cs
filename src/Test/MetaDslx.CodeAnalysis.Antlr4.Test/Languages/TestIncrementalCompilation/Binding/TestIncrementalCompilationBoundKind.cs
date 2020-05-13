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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Binding
{
    public class TestIncrementalCompilationBoundKind : BoundKind
    {
        public const string Documentation = nameof(Documentation);
        public const string Opposite = nameof(Opposite);

        protected TestIncrementalCompilationBoundKind(string name)
            : base(name)
        {
        }

        protected TestIncrementalCompilationBoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static TestIncrementalCompilationBoundKind()
        {
            EnumObject.AutoInit<TestIncrementalCompilationBoundKind>();
        }

        public static implicit operator TestIncrementalCompilationBoundKind(string name)
        {
            return FromString<TestIncrementalCompilationBoundKind>(name);
        }

        public static explicit operator TestIncrementalCompilationBoundKind(int value)
        {
            return FromIntUnsafe<TestIncrementalCompilationBoundKind>(value);
        }
    }
}

