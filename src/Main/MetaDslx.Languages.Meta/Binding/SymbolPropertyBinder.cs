using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using Roslyn.Utilities;
using Microsoft.CodeAnalysis;
using System.Linq;
using MetaDslx.CodeAnalysis.Symbols;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols.CSharp;

namespace MetaDslx.Languages.Meta.Binding
{
    public class SymbolPropertyBinder : UseBinder
    {
        private DeclaredSymbol _symbolType;

        public SymbolPropertyBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion) 
            : base(next, syntax, ImmutableArray.Create(typeof(CSharpMemberSymbol)), false, null, null, forCompletion)
        {
        }

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return base.BindNode(diagnostics, cancellationToken);
        }

        public DeclaredSymbol SymbolType
        {
            get
            {
                if (_symbolType == null)
                {
                    var type = this.ContainingType;
                    var symbolType = this.GetSymbolTypeSymbol(type);
                    if (symbolType == null)
                    {
                        foreach (var baseType in type.AllBaseTypesNoUseSiteDiagnostics)
                        {
                            var baseSymbolType = this.GetSymbolTypeSymbol(baseType);
                            /*if (baseSymbolType != null && baseSymbolType != symbolType && !symbolType.AllBaseTypesNoUseSiteDiagnostics.Contains(baseSymbolType))
                            {
                                
                            }*/
                            if (baseSymbolType != null)
                            {
                                symbolType = baseSymbolType;
                                break;
                            }
                        }
                    }
                    Interlocked.CompareExchange(ref _symbolType, symbolType, null);
                }
                return _symbolType;
            }
        }

        private NamedTypeSymbol GetSymbolTypeSymbol(DeclaredSymbol symbol)
        {
            symbol.ForceComplete(CompletionGraph.FinishComputingNonSymbolProperties, null, default);
            var mclass = (symbol as IModelSymbol)?.ModelObject as MetaClassBuilder;
            if (mclass != null)
            {
                var symbolType = mclass.MId.Descriptor.SymbolType;
                if (symbolType != null)
                {
                    var symbolTypeProperty = mclass.MGetProperty("SymbolType");
                    var location = mclass.MGetTag(symbolTypeProperty) as SourceLocation;
                    if (location != null)
                    {
                        var syntaxTree = location.SourceTree;
                        var root = syntaxTree.GetRoot();
                        var node = root.FindNode(location.SourceSpan);
                        var symbolTypeBoundNode = this.Compilation.GetBinder(node).Bind();
                        var msymbol = (symbolTypeBoundNode as BoundValue).Values.FirstOrDefault() as NamedTypeSymbol;
                        return msymbol;
                    }
                }
                else
                {
                    Debug.Assert(false);
                }
            }
            return null;
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            var symbolType = this.SymbolType;
            return base.AdjustConstraints(constraints).WithQualifier(symbolType).WithAdditionalValidators(LookupValidators.MustBeInstance);
        }

        protected override bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            var csProp = (symbol as CSharpMemberSymbol)?.CSharpSymbol;
            if (csProp is not null && csProp.Kind == SymbolKind.Property)
            {
                foreach (var attr in csProp.GetAttributes())
                {
                    if (attr.AttributeClass is not null && "global::MetaDslx.CodeAnalysis.Symbols.SymbolPropertyAttribute".Equals(attr.AttributeClass.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
