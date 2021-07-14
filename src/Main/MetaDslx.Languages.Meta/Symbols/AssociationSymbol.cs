using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using SymbolKind = MetaDslx.CodeAnalysis.Symbols.SymbolKind;

namespace MetaDslx.Languages.Meta.Symbols
{
    [Symbol(ModelObjectOption = ParameterOption.Disabled)]
    public abstract partial class AssociationSymbol : Symbol
    {
        [SymbolProperty]
        public abstract Symbol Left { get; }
        [SymbolProperty]
        public abstract Symbol Right { get; }

        protected virtual void CompleteAssociation(CancellationToken cancellationToken)
        {
            var assoc = this.DeclaringSyntaxReferences[0].GetSyntax() as AssociationDeclarationSyntax;
            var compilation = this.DeclaringCompilation;
            var sourceBinder = compilation.GetBinder(assoc.Source);
            var targetBinder = compilation.GetBinder(assoc.Target);
            var diagnostics = DiagnosticBag.GetInstance();
            var source = (BoundSymbol)sourceBinder.Bind(diagnostics, cancellationToken);
            var target = (BoundSymbol)targetBinder.Bind(diagnostics, cancellationToken);
            AddSymbolDiagnostics(diagnostics);
            if (!diagnostics.HasAnyErrors())
            {
                var sourceProp = (MetaPropertyBuilder)(source.Symbols[0] as IModelSymbol).ModelObject;
                var targetProp = (MetaPropertyBuilder)(target.Symbols[0] as IModelSymbol).ModelObject;
                sourceProp.OppositeProperties.Add(targetProp);
            }
            diagnostics.Free();
        }
    }
}
