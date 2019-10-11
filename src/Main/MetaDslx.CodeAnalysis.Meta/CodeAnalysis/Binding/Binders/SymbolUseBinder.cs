using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Symbols;
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

        public override void InitializeQualifierSymbol(BoundQualifier qualifier)
        {
            if (qualifier.IsInitialized()) return;
            var boundNode = this.Compilation.GetBoundNode<BoundSymbolUse>(qualifier.Syntax);
            if (boundNode == null) return;
            var qualifiers = boundNode.GetChildQualifiers();
            foreach (var child in qualifiers)
            {
                if (child.Syntax.Span.Contains(qualifier.Syntax.Span))
                {
                    this.InitializeFullQualifierSymbol(child);
                    return;
                }
            }
            qualifier.BoundTree.DiagnosticBag.Add(ModelErrorCode.WRN_QualifierNotFound, qualifier.Syntax.Location, qualifier.Syntax.ToString(), qualifier.Syntax.GetType().FullName, boundNode.Syntax.GetType().FullName);
            this.InitializeFullQualifierSymbol(qualifier);
        }

        private void InitializeFullQualifierSymbol(BoundQualifier qualifier)
        {
            if (qualifier.IsInitialized()) return;
            var result = ArrayBuilder<object>.GetInstance();
            var identifiers = qualifier.Identifiers;
            NamespaceOrTypeSymbol qualifierOpt = null;
            for (int i = 0; i < identifiers.Length; i++)
            {
                bool last = i == identifiers.Length - 1;
                var types = last ? _types : _nestingTypes;
                var identifier = identifiers[i];
                LookupResult lookupResult = LookupResult.GetInstance();
                this.LookupSymbolsSimpleName(lookupResult, new LookupConstraints(identifier.Name, identifier.MetadataName, types, qualifierOpt));
                var symbol = this.ResultSymbol(lookupResult, identifier.Name, identifier.MetadataName, identifier.Syntax, identifier.BoundTree.DiagnosticBag, false, out bool wasError, qualifierOpt, LookupOptions.Default);
                Debug.Assert(symbol != null);
                result.Add(symbol);
                lookupResult.Free();
                qualifierOpt = symbol as NamespaceOrTypeSymbol;
            }
            qualifier.InitializeValues(identifiers, result.ToImmutableAndFree());
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
