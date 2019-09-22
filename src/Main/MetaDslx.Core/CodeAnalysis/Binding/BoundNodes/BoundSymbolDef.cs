using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolDef : BoundSymbols
    {
        private Type _symbolType;
        private ImmutableArray<Symbol> _lazySymbols;

        public BoundSymbolDef(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors = false) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolType = symbolType;
        }

        public override ImmutableArray<Symbol> Symbols
        {
            get
            {
                if (_lazySymbols.IsDefault)
                {
                    var boundNames = this.GetChildNames();
                    if (boundNames.Length == 0)
                    {
                        var binder = this.GetBinder<SymbolDefBinder>();
                        var containerSymbol = binder?.ContainingSymbol as NamespaceOrTypeSymbol;
                        var symbol = containerSymbol?.GetSourceMember(this.Syntax);
                        Debug.Assert(symbol != null);
                        if (symbol != null)
                        {
                            ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, ImmutableArray.Create<Symbol>(symbol));
                        }
                        else
                        {
                            ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, ImmutableArray<Symbol>.Empty);
                        }
                    }
                    else
                    {
                        var symbols = ArrayBuilder<Symbol>.GetInstance();
                        foreach (var boundName in boundNames)
                        {
                            foreach (var qualifier in boundName.GetChildQualifiers())
                            {
                                var symbol = qualifier.Value as DeclaredSymbol;
                                Debug.Assert(symbol != null);
                                if (symbol != null)
                                {
                                    symbols.Add(symbol);
                                }
                            }
                        }
                        ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, symbols.ToImmutableAndFree());
                    }
                }
                return _lazySymbols;
            }
        }

        protected override void ForceCompleteNode(CancellationToken cancellationToken)
        {
            foreach (var symbol in this.Symbols)
            {
                this.SetPropertyValues((MutableSymbolBase)symbol.ModelObject, this.DiagnosticBag, cancellationToken);
            }
        }
    }
}
