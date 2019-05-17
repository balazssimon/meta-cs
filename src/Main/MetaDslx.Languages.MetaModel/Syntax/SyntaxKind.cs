using System;
using System.Collections.Generic;
using System.Text;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaModel.Syntax
{
    public class MetaModelSyntaxKind : MetaDslx.CodeAnalysis.Syntax.SyntaxKind
    {
        public const string FirstTokenWithWellKnownText = nameof(FirstTokenWithWellKnownText);
        public const string LastTokenWithWellKnownText = nameof(LastTokenWithWellKnownText);


        protected MetaModelSyntaxKind(string name) : base(name)
        {
        }

        protected MetaModelSyntaxKind(EnumObject retargetedValue) : base(retargetedValue)
        {
        }

        static MetaModelSyntaxKind()
        {
            EnumObject.AutoInit<MetaModelSyntaxKind>();
        }

        public static implicit operator MetaModelSyntaxKind(string name)
        {
            return FromString<MetaModelSyntaxKind>(name);
        }

        public new static IEnumerable<EnumObject> EnumValues => EnumObject.EnumValues(typeof(MetaModelSyntaxKind));
    }
}
