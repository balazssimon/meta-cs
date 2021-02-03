using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolUseBinder : Binder
    {
        private readonly ImmutableArray<ModelObjectDescriptor> _types;
        private readonly ImmutableArray<ModelObjectDescriptor> _nestingTypes;
        private readonly LanguageSyntaxNode _syntax;
        private readonly bool _attributeTypeOnly;

        public SymbolUseBinder(Binder next, LanguageSyntaxNode syntax, ImmutableArray<Type> types, ImmutableArray<Type> nestingTypes)
            : base(next)
        {
            _syntax = syntax;
            _types = types.Select(type => ModelObjectDescriptor.GetDescriptor(type)).ToImmutableArray();
            _nestingTypes = nestingTypes.Select(type => ModelObjectDescriptor.GetDescriptor(type)).ToImmutableArray();
            if (types.Length > 0)
            {
                _attributeTypeOnly = true;
                foreach (var type in types)
                {
                    if (!typeof(MetaAttribute).IsAssignableFrom(type))
                    {
                        _attributeTypeOnly = false;
                        break;
                    }
                }
            }
        }


        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            LookupConstraints result = base.AdjustConstraints(constraints);
            if (!result.IsMemberLookup && _attributeTypeOnly)
            {
                result = result.WithOptions(result.Options | LookupOptions.AttributeTypeOnly);
            }
            return result;
        }
    }
}
