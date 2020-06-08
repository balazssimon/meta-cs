using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax
{
    public class SyntaxKind : EnumObject
    {
        private int _value;

        public const string None = nameof(None);
        public const string List = nameof(List);
        public const string BadToken = nameof(BadToken);
        public const string MissingToken = nameof(MissingToken);
        public const string SkippedTokensTrivia = nameof(SkippedTokensTrivia);
        public const string DisabledTextTrivia = nameof(DisabledTextTrivia);
        public const string ConflictMarkerTrivia = nameof(ConflictMarkerTrivia);
        public const string Eof = nameof(Eof);

        public const string __LastPredefinedSyntaxKind = Eof;
        public static readonly int __LastPredefinedSyntaxKindValue;

        protected SyntaxKind(string name)
            : base(name)
        {
        }

        protected SyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static SyntaxKind()
        {
            EnumObject.RegisterDefault<SyntaxKind>(None);
            EnumObject.RegisterAlias<SyntaxKind>(__LastPredefinedSyntaxKind);
            EnumObject.AutoInit<SyntaxKind>();
            __LastPredefinedSyntaxKindValue = ((SyntaxKind)__LastPredefinedSyntaxKind).GetValue();
        }

        public static implicit operator SyntaxKind(string name)
        {
            return FromString<SyntaxKind>(name);
        }

        public static explicit operator SyntaxKind(int value)
        {
            return FromIntUnsafe<SyntaxKind>(value);
        }


    }
}
