using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundEnumValue : BoundValues
    {
        private string _name;
        private Type _enumType;
        private ImmutableArray<object> _lazyValues;

        public BoundEnumValue(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, string name, Type enumType, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _name = name;
            _enumType = enumType;
        }

        public override ImmutableArray<object> Values
        {
            get
            {
                if (_lazyValues == null)
                {
                    object value = null;
                    if (typeof(EnumObject).IsAssignableFrom(_enumType))
                    {
                        value = EnumObject.FromString(_enumType, _name);
                    }
                    else
                    {
                        value = Enum.Parse(_enumType, _name);
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyValues, ImmutableArray.Create(value));
                }
                return _lazyValues;
            }
        }
    }
}
