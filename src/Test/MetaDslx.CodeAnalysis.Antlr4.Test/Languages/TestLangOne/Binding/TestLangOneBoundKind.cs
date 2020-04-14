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

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Binding
{
    public class TestLangOneBoundKind : BoundKind
    {

        protected TestLangOneBoundKind(string name)
            : base(name)
        {
        }

        protected TestLangOneBoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static TestLangOneBoundKind()
        {
            EnumObject.AutoInit<TestLangOneBoundKind>();
        }

        public static implicit operator TestLangOneBoundKind(string name)
        {
            return FromString<TestLangOneBoundKind>(name);
        }

        public static explicit operator TestLangOneBoundKind(int value)
        {
            return FromIntUnsafe<TestLangOneBoundKind>(value);
        }
    }
}

