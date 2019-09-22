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
        public BoundSymbols(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public virtual ImmutableArray<Symbol> Symbols { get; }

        public override ImmutableArray<object> Values => StaticCast<object>.From(this.Symbols);

        internal void SetPropertyValues(MutableSymbolBase modelObject, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (modelObject == null) return;
            var boundProperties = this.GetChildProperties();
            var propertyNames = boundProperties.Select(p => p.Name).Distinct().ToArray();
            foreach (var boundProp in propertyNames)
            {
                var prop = modelObject.MGetProperty(boundProp);
                if (prop == null)
                {
                    diagnostics.Add(ModelErrorCode.ERR_PropertyDoesNotExist, modelObject, boundProp);
                    continue;
                }
                //if (prop.IsBaseScope) continue;
                var propValues = this.GetChildValues(null, boundProp);
                foreach (var boundValue in propValues)
                {
                    if (boundValue is BoundSymbolDef)
                    {
                        bool alreadySet = false;
                        foreach (var value in boundValue.Values)
                        {
                            var symbol = value as Symbol;
                            if (symbol != null && symbol.ModelObject.MParent == modelObject)
                            {
                                alreadySet = true;
                                break;
                            }
                        }
                        if (alreadySet) continue;
                    }
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
