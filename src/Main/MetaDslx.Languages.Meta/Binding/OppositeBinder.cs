using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Meta.Binding
{
    public class OppositeBinder : CustomBinder, IValueBoundary, ISymbolBoundary
    {
        public OppositeBinder(Binder next, SyntaxNodeOrToken syntax) 
            : base(next, syntax)
        {
        }

        public override void Execute(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var assoc = this.Syntax.AsNode() as AssociationDeclarationSyntax;
            var sourceBinder = GetBinder(assoc.Source);
            var targetBinder = GetBinder(assoc.Target);
            var source = (BoundSymbol)sourceBinder.Bind(cancellationToken);
            var target = (BoundSymbol)targetBinder.Bind(cancellationToken);
            if (!source.Diagnostics.IsEmpty || !target.Diagnostics.IsEmpty)
            {
                diagnostics.AddRange(source.Diagnostics);
                diagnostics.AddRange(target.Diagnostics);
            }
            else
            {
                var sourceProp = (MetaPropertyBuilder)(source.Symbols[0] as IModelSymbol).ModelObject;
                var targetProp = (MetaPropertyBuilder)(target.Symbols[0] as IModelSymbol).ModelObject;
                sourceProp.OppositeProperties.Add(targetProp);
            }
        }
    }
}
