using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class EnumValueBinder : ValueBinder
    {
        private readonly Type _enumType;

        public EnumValueBinder(Binder next, SyntaxNodeOrToken syntax, Type enumType)
            : base(next, syntax)
        {
            _enumType = enumType;
        }

        public Type EnumType
        {
            get { return _enumType; }
        }

        protected override object CalculateValue()
        {
            string valueText = Language.SyntaxFacts.ExtractName(this.Syntax);
            if (typeof(EnumObject).IsAssignableFrom(_enumType))
            {
                return EnumObject.FromString(_enumType, valueText);
            }
            else
            {
                return Enum.Parse(_enumType, valueText);
            }
        }

    }
}
