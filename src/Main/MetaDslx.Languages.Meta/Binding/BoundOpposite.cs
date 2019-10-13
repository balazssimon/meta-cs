using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Meta.Binding
{
    public class BoundOpposite : BoundNode
    {
        public BoundOpposite(MetaBoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        protected override void ForceCompleteNode(CancellationToken cancellationToken)
        {
            var values = this.GetChildValues();
            Debug.Assert(values.Length == 2);
            if (values.Length == 2)
            {
                var first = (values[0].Values.FirstOrDefault() as Symbol)?.ModelObject as MetaPropertyBuilder;
                var second = (values[1].Values.FirstOrDefault() as Symbol)?.ModelObject as MetaPropertyBuilder;
                if (first != null && second != null)
                {
                    first.OppositeProperties.Add(second);
                    return;
                }
                this.DiagnosticBag.Add(LanguageDiagnostic.Create(ModelErrorCode.ERR_CannotSetOppositeProperty, this.Syntax.GetLocation(), values[0], values[1]));
                return;
            }
            this.DiagnosticBag.Add(LanguageDiagnostic.Create(ModelErrorCode.ERR_CannotSetOppositeProperty, this.Syntax.GetLocation(), (object)null, (object)null));
        }
    }
}
