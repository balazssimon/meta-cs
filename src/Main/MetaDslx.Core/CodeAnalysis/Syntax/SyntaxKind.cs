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
        public const string Eof = nameof(Eof);
        public const string List = nameof(List);
        public const string BadToken = nameof(BadToken);
        public const string SkippedTokensTrivia = nameof(SkippedTokensTrivia);
        public const string DisabledTextTrivia = nameof(DisabledTextTrivia);
        public const string ConflictMarkerTrivia = nameof(ConflictMarkerTrivia);
        public const string DefaultWhitespace = nameof(DefaultWhitespace);
        public const string DefaultEndOfLine = nameof(DefaultEndOfLine);
        public const string DefaultSeparator = nameof(DefaultSeparator);
        public const string DefaultIdentifier = nameof(DefaultIdentifier);
        public const string EndOfDirectiveToken = nameof(EndOfDirectiveToken);
        public const string CompilationUnit = nameof(CompilationUnit);
        public const string ExternAliasDirective = nameof(ExternAliasDirective);

        public const string __LastPredefinedSyntaxKind = ExternAliasDirective;
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
