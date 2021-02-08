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

        public BoundIdentifier(SyntaxNodeOrToken syntax, BoundNode parent)
            : base(syntax, parent)
        {
        }

        public BoundIdentifier(SyntaxNodeOrToken syntax, BoundNode parent, DeclaredSymbol symbol)
            : base(syntax, parent)
        {
            _symbol = symbol;
            _diagnostics = ImmutableArray<Diagnostic>.Empty;
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
            if (_symbol == null)
            {
                var binder = this.GetBinder();
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
                    Interlocked.CompareExchange(ref _symbol, symbol, null);
                    ImmutableInterlocked.InterlockedInitialize(ref _diagnostics, diagnostics.ToReadOnlyAndFree());
                }
            }
        }
    }
}
