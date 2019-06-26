using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

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

        internal void SetPropertyValues(MutableSymbolBase modelObject, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var boundProperties = this.GetChildProperties();
            foreach (var boundProp in boundProperties)
            {
                var prop = modelObject.MGetProperty(boundProp.Name);
                if (prop == null)
                {
                    diagnostics.Add(ModelErrorCode.ERR_PropertyDoesNotExist, modelObject, boundProp.Name);
                    continue;
                }
                //if (prop.IsBaseScope) continue;
                foreach (var boundValue in boundProp.BoundValues)
                {
                    if (boundValue is BoundSymbolDef) continue;
                    if (prop.IsCollection)
                    {
                        var values = boundValue.Values.Select(v => v is Symbol symbol ? symbol.ModelObject : v).ToArray();
                        modelObject.MAddRange(prop, values);
                    }
                    else
                    {
                        if (boundValue.Values.Length == 1)
                        {
                            var value = boundValue.Values[0];
                            if (value is Symbol symbol) value = symbol.ModelObject;
                            modelObject.MSet(prop, value);
                        }
                        else if(boundValue.Values.Length > 1)
                        {
                            diagnostics.Add(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty, prop, modelObject);
                        }
                    }
                }
            }
        }

    }
}
