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
    public class BoundSymbolUse : BoundValues
    {
        private ImmutableArray<Type> _symbolTypes;
        private ImmutableArray<Type> _nestingSymbolTypes;
        private ImmutableArray<Symbol> _lazySymbols;

        public BoundSymbolUse(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolTypes = symbolTypes;
            _nestingSymbolTypes = nestingSymbolTypes;
        }

        public ImmutableArray<Symbol> Symbols
        {
            get
            {
                if (_lazySymbols == null)
                {
                    ArrayBuilder<Symbol> symbols = ArrayBuilder<Symbol>.GetInstance();
                    ImmutableArray<object> values = this.GetChildValues();
                    foreach (var value in values)
                    {
                        if (value is Symbol symbol)
                        {
                            symbols.Add(symbol);
                        }
                        else 
                        {
                            this.BoundTree.DiagnosticBag.Add(ModelErrorCode.ERR_ValueIsNotSymbol, this.Syntax.Location, value);
                        }
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, symbols.ToImmutableAndFree());
                }
                return _lazySymbols;
            }
        }

        public override ImmutableArray<object> Values => StaticCast<object>.From(this.Symbols);
    }
}
