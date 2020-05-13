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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Binding
{
    public class TestLanguageAnnotationsBoundKind : BoundKind
    {

        protected TestLanguageAnnotationsBoundKind(string name)
            : base(name)
        {
        }

        protected TestLanguageAnnotationsBoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static TestLanguageAnnotationsBoundKind()
        {
            EnumObject.AutoInit<TestLanguageAnnotationsBoundKind>();
        }

        public static implicit operator TestLanguageAnnotationsBoundKind(string name)
        {
            return FromString<TestLanguageAnnotationsBoundKind>(name);
        }

        public static explicit operator TestLanguageAnnotationsBoundKind(int value)
        {
            return FromIntUnsafe<TestLanguageAnnotationsBoundKind>(value);
        }
    }
}

