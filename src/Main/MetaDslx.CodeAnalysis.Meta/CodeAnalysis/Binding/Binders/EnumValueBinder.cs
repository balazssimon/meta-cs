using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class EnumValueBinder : ValueBinder
    {
        private readonly Type _enumType;
        private readonly string _enumLiteral;

        public EnumValueBinder(Binder next, SyntaxNodeOrToken syntax, string enumLiteral, Type enumType, bool forCompletion)
            : base(next, syntax, forCompletion)
        {
            _enumType = enumType;
            _enumLiteral = enumLiteral;
        }

        public Type EnumType
        {
            get { return _enumType; }
        }

        protected override object ComputeValue()
        {
            if (typeof(EnumObject).IsAssignableFrom(_enumType))
            {
                return EnumObject.FromString(_enumType, _enumLiteral);
            }
            else
            {
                return Enum.Parse(_enumType, _enumLiteral);
            }
        }

    }
}
