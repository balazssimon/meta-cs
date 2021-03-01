﻿using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Languages.Meta.Model;
using Microsoft.CodeAnalysis;
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
                            symbolType = this.GetSymbolTypeSymbol(baseType);
                            if (symbolType != null) break;
                        }
                    }
                    Interlocked.CompareExchange(ref _symbolType, symbolType, null);
                }
                return _symbolType;
            }
        }

        private NamedTypeSymbol GetSymbolTypeSymbol(NamedTypeSymbol symbol)
        {
            var mclass = (symbol as IModelSymbol)?.ModelObject as MetaClassBuilder;
            var symbolType = mclass?.SymbolType;
            if (symbolType != null)
            {
                var symbolTypeProperty = mclass.MGetProperty("SymbolType");
                var location = mclass.MGetTag(symbolTypeProperty) as SourceLocation;
                if (location != null)
                {
                    var syntaxTree = location.SourceTree;
                    var root = syntaxTree.GetRoot();
                    var node = root.FindNode(location.SourceSpan);
                    var symbolTypeBoundNode = this.Compilation.GetBinder(node).Bind(node, default);
                    var msymbol = (symbolTypeBoundNode as BoundValue).Values.FirstOrDefault() as NamedTypeSymbol;
                    return msymbol;
                }
            }
            return null;
        }

        protected override LookupConstraints AdjustConstraintsFor(SyntaxNodeOrToken lookupSyntax, LookupConstraints constraints)
        {
            return constraints.WithQualifier(this.SymbolType).WithOptions(LookupOptions.MustBeInstance);
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            return this.AdjustConstraintsFor(this.Syntax, constraints);
        }

    }
}
