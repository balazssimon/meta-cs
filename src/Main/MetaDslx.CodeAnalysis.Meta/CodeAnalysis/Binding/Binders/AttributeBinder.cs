using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class AttributeBinder : SymbolUseBinder
    {
        public AttributeBinder(Binder next, LanguageSyntaxNode syntax, ImmutableArray<Type> types, ImmutableArray<Type> nestingTypes) 
            : base(next, syntax, types, nestingTypes)
        {
            
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            LookupConstraints result = base.AdjustConstraints(constraints);
            if (!result.IsMemberLookup)
            {
                result = result.WithOptions(result.Options | LookupOptions.AttributeTypeOnly);
            }
            return result;
        }
    }
}
