using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using System.Linq;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using System.Threading;

namespace MetaDslx.Languages.Meta.Binding
{
    public class SymbolPropertyBinder : SymbolUseBinder
    {
        private DeclaredSymbol _symbolType;

        public SymbolPropertyBinder(Binder next, SyntaxNodeOrToken syntax) : base(next, syntax, ImmutableArray<Type>.Empty)
        {
        }

        protected override BoundNode BindNode(CancellationToken cancellationToken)
        {
            return base.BindNode(cancellationToken);
        }

        public DeclaredSymbol SymbolType
        {
            get
            {
                if (_symbolType == null)
                {
                    var type = this.ContainingType;
                    var symbolType = this.GetSymbolTypeSymbol(type);
                    if (symbolType != null)
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
            symbol.ForceComplete(CompletionPart.FinishProperties, null, default);
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
            return base.AdjustConstraints(constraints).WithQualifier(symbolType).WithOptions(LookupOptions.MustBeInstance);
        }

    }
}
