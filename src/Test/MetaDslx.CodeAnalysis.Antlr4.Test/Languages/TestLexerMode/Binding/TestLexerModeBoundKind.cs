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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Binding
{
    public class TestLexerModeBoundKind : BoundKind
    {

        protected TestLexerModeBoundKind(string name)
            : base(name)
        {
        }

        protected TestLexerModeBoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static TestLexerModeBoundKind()
        {
            EnumObject.AutoInit<TestLexerModeBoundKind>();
        }

        public static implicit operator TestLexerModeBoundKind(string name)
        {
            return FromString<TestLexerModeBoundKind>(name);
        }

        public static explicit operator TestLexerModeBoundKind(int value)
        {
            return FromIntUnsafe<TestLexerModeBoundKind>(value);
        }
    }
}

