using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class BoundKind : EnumObject
    {
        public const string Node = nameof(Node);

        public const string BadExpression = nameof(BadExpression);
        public const string BadStatement = nameof(BadStatement);

        public const string EnumValue = nameof(EnumValue);
        public const string Expression = nameof(Expression);
        public const string Identifier = nameof(Identifier);
        public const string LocalScope = nameof(LocalScope);
        public const string Name = nameof(Name);
        public const string Property = nameof(Property);
        public const string Qualifier = nameof(Qualifier);
        public const string Root = nameof(Root);
        public const string Scope = nameof(Scope);
        public const string Statement = nameof(Statement);
        public const string SymbolCtr = nameof(SymbolCtr);
        public const string SymbolDef = nameof(SymbolDef);
        public const string SymbolUse = nameof(SymbolUse);
        public const string Value = nameof(Value);

        protected BoundKind(string name)
            : base(name)
        {
        }

        protected BoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static BoundKind()
        {
            EnumObject.AutoInit<BoundKind>();
        }

        public static implicit operator BoundKind(string name)
        {
            return FromString<BoundKind>(name);
        }

        public static explicit operator BoundKind(int value)
        {
            return FromIntUnsafe<BoundKind>(value);
        }

    }

}
