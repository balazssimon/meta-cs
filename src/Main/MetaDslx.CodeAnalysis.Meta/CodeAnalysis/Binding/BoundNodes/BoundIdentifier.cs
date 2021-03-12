using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundIdentifier : BoundSymbol
    {
        private DeclaredSymbol _symbol;
        private ImmutableArray<Diagnostic> _diagnostics;

        public BoundIdentifier(BoundNode parent, SyntaxNodeOrToken syntax)
            : base(parent, syntax)
        {
        }

        public BoundIdentifier(BoundNode parent, SyntaxNodeOrToken syntax, DeclaredSymbol symbol)
            : base(parent, syntax)
        {
            _symbol = symbol;
            _diagnostics = default;
        }

        public DeclaredSymbol Symbol
        {
            get
            {
                ComputeSymbol();
                return _symbol;
            }
        }

        public override ImmutableArray<Diagnostic> Diagnostics
        {
            get
            {
                ComputeSymbol();
                return _diagnostics;
            }
        }

        public override ImmutableArray<Symbol> Symbols
        {
            get
            {
                ComputeSymbol();
                if (_symbol != null) return ImmutableArray.Create((Symbol)_symbol);
                else return ImmutableArray<Symbol>.Empty;
            }
        }


        private void ComputeSymbol()
        {
            if (_diagnostics.IsDefault)
            {
                var binder = this.GetBinder();
                if (binder != null)
                {
                    var boundQualifier = binder.GetBoundQualifier();
                    DeclaredSymbol symbol = null;
                    if (boundQualifier != null)
                    {
                        symbol = boundQualifier.GetSymbol(this.Syntax);
                        ImmutableInterlocked.InterlockedInitialize(ref _diagnostics, ImmutableArray<Diagnostic>.Empty);
                    }
                    else
                    {
                        var diagnostics = DiagnosticBag.GetInstance();
                        symbol = binder.BindDeclaredSymbol(this.Syntax, diagnostics);
                        ImmutableInterlocked.InterlockedInitialize(ref _diagnostics, diagnostics.ToReadOnlyAndFree());
                    }
                    Interlocked.CompareExchange(ref _symbol, symbol, null);
                }
                else
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _diagnostics, ImmutableArray<Diagnostic>.Empty);
                }
            }
        }
    }
}
