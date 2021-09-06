using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetamodelImportBinder : ImportBinder
    {
        public MetamodelImportBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion) 
            : base(next, syntax, false, false, forCompletion)
        {
        }

        /*public override DeclaredSymbol BindImportedSymbol(Binder usingsBinder, UsingDirective usingDirective, LookupConstraints constraints, DiagnosticBag diagnostics)
        {
            if (usingDirective.TargetQualifiedName.Length > 0)
            {
                constraints = constraints.WithAutomaticName(null, "Instance");
                return base.BindImportedSymbol(usingsBinder, usingDirective, constraints, diagnostics);
            }
            else
            {
                var refModels = this.Compilation.ObjectFactory.ReferencedModels;
                foreach (var refModel in refModels)
                {
                    if (refModel is IModel model)
                    {
                        model.M
                    }
                }
            }
        }*/
    }
}
