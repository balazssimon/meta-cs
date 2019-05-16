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
            EnumObject.AutoInit<SyntaxKind>();
        }

        public static implicit operator SyntaxKind(string name)
        {
            return FromString<SyntaxKind>(name);
        }

        public new static IEnumerable<EnumObject> EnumValues => EnumObject.EnumValues(typeof(SyntaxKind));

    }
}
