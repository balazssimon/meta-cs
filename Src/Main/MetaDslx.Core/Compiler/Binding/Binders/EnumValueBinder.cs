using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.Binders
{
    public class EnumValueBinder : ValueBinder
    {
        private readonly Type _enumType;

        public EnumValueBinder(Binder next, RedNode node, Type enumType, object value) 
            : base(next, node, value)
        {
            _enumType = enumType;
        }

        public Type EnumType
        {
            get { return _enumType; }
        }

    }
}
