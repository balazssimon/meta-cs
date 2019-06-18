using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbol : BoundValues
    {
        public BoundSymbol(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public virtual Symbol Symbol { get; }

        public override ImmutableArray<object> Values => ImmutableArray.Create<object>(this.Symbol);

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
