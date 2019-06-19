using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbols : BoundValues
    {
        public BoundSymbols(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public virtual ImmutableArray<Symbol> Symbols { get; }

        public override ImmutableArray<object> Values => StaticCast<object>.From(this.Symbols);

        public ImmutableDictionary<string, ImmutableArray<object>> GetPropertyValues()
        {
            var result = ImmutableDictionary.CreateBuilder<string, ImmutableArray<object>>();
            foreach (var property in this.GetChildProperties())
            {
                result.Add(property, this.GetChildValues(property));
            }
            return result.ToImmutable();
        }
    }
}
