using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolUse : BoundSymbols
    {
        private ImmutableArray<Type> _types;
        private ImmutableArray<Type> _nestingTypes;
        private ImmutableArray<DeclaredSymbol> _lazySymbols;

        public BoundSymbolUse(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, ImmutableArray<Type> types, ImmutableArray<Type> nestingTypes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _types = types;
            _nestingTypes = nestingTypes;
        }

        public override ImmutableArray<DeclaredSymbol> Symbols
        {
            get
            {
                if (_lazySymbols == null)
                {
                    ArrayBuilder<DeclaredSymbol> symbols = ArrayBuilder<DeclaredSymbol>.GetInstance();
                    if (!this.Syntax.IsMissing)
                    {
                        ImmutableArray<BoundValues> boundValues = this.GetChildValues();
                        foreach (var boundValue in boundValues)
                        {
                            foreach (var value in boundValue.Values)
                            {
                                if (value is DeclaredSymbol symbol)
                                {
                                    symbols.Add(symbol);
                                }
                                else 
                                {
                                    var specialSymbol = this.Compilation.GetSpecialSymbol(value) as DeclaredSymbol;
                                    if (specialSymbol == null || specialSymbol.Kind == LanguageSymbolKind.ErrorType || specialSymbol.DeclaredAccessibility != Accessibility.Public)
                                    {
                                        this.BoundTree.DiagnosticBag.Add(ModelErrorCode.ERR_ValueIsNotSymbol, this.Syntax.Location, value);
                                    }
                                    else
                                    {
                                        symbols.Add(specialSymbol);
                                    }
                                }
                            }
                        }
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, symbols.ToImmutableAndFree());
                }
                return _lazySymbols;
            }
        }
    }
}
