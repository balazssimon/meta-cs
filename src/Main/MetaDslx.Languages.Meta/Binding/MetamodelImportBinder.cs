using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Languages.Meta.Binding
{
    public class MetamodelImportBinder : ImportBinder
    {
        public MetamodelImportBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion) 
            : base(next, syntax, false, false, forCompletion)
        {
        }
        
        public override DeclaredSymbol BindImportedSymbol(Binder usingsBinder, UsingDirective usingDirective, LookupConstraints constraints, DiagnosticBag diagnostics)
        {
            if (usingDirective.TargetQualifiedName.Length > 0)
            {
                constraints = constraints.WithAutomaticName(null, "Instance");
                return base.BindImportedSymbol(usingsBinder, usingDirective, constraints, diagnostics);
            }
            else
            {
                var uri = Language.SyntaxFacts.ExtractValue(usingDirective.TargetName);
                if (uri is string uriStr)
                {
                    foreach (var module in this.Compilation.Assembly.Modules)
                    {
                        if (module is IModelModuleSymbol modelModule && modelModule.Model is IModel model)
                        {
                            if (model.Metadata.Uri == uriStr)
                            {
                                var namespaceSegments = model.Metadata.NamespaceName.Split('.').ToImmutableArray();
                                NamespaceSymbol scope = module.GlobalNamespace.LookupNestedNamespace(namespaceSegments);
                                if (scope != null)
                                {
                                    return scope;
                                }
                            }
                        }
                    }
                }
                diagnostics.Add(ModelErrorCode.ERR_CannotResolveModelByUri.ToDiagnostic(usingDirective.TargetName.GetLocation(), uri));
            }
            return null;
        }

    }
}
