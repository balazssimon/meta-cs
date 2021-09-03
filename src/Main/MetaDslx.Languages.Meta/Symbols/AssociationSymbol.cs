using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Meta.Symbols
{
    [Symbol(ModelObjectOption = ParameterOption.Disabled)]
    public abstract partial class AssociationSymbol : Symbol
    {
        [SymbolProperty]
        public abstract Symbol Left { get; }
        [SymbolProperty]
        public abstract Symbol Right { get; }

        [SymbolCompletionPart]
        protected virtual void CompleteAssociation(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (Left is IModelSymbol left && Right is IModelSymbol right && left.ModelObject is MetaPropertyBuilder leftProp && right.ModelObject is MetaPropertyBuilder rightProp)
            {
                leftProp.OppositeProperties.Add(rightProp);
            }
        }
    }
}
