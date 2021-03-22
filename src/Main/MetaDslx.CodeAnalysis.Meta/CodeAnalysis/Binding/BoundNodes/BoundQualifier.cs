using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundQualifier : BoundSymbol
    {
        private ImmutableArray<SyntaxNodeOrToken> _identifiers;
        private ImmutableArray<DeclaredSymbol> _identifierSymbols;
        private ImmutableArray<Diagnostic> _diagnostics;

        public BoundQualifier(BoundNode parent, SyntaxNodeOrToken syntax, ImmutableArray<SyntaxNodeOrToken> identifiers)
            : base(parent, syntax)
        {
            _identifiers = identifiers;
        }

        public ImmutableArray<DeclaredSymbol> IdentifierSymbols
        {
            get
            {
                ComputeSymbols();
                return _identifierSymbols;
            }
        }

        public override ImmutableArray<Diagnostic> Diagnostics
        {
            get
            {
                ComputeSymbols();
                return _diagnostics;
            }
        }

        public override ImmutableArray<Symbol> Symbols
        {
            get
            {
                ComputeSymbols();
                if (_identifiers.Length == _identifierSymbols.Length && _identifierSymbols.Length > 0) return ImmutableArray.Create((Symbol)_identifierSymbols[_identifierSymbols.Length - 1]);
                else return ImmutableArray<Symbol>.Empty;
            }
        }


        private void ComputeSymbols()
        {
            if (_diagnostics.IsDefault)
            {
                var binder = this.GetBinder();
                if (binder != null)
                {
                    var diagnostics = DiagnosticBag.GetInstance();
                    var symbols = binder.BindDeclaredSymbol(_identifiers, diagnostics);
                    ImmutableInterlocked.InterlockedInitialize(ref _identifierSymbols, symbols);
                    ImmutableInterlocked.InterlockedInitialize(ref _diagnostics, diagnostics.ToReadOnlyAndFree());
                }
                else
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _identifierSymbols, ImmutableArray<DeclaredSymbol>.Empty);
                    ImmutableInterlocked.InterlockedInitialize(ref _diagnostics, ImmutableArray<Diagnostic>.Empty);
                }
            }
        }
        
        internal bool IsLastIdentifier(SyntaxNodeOrToken identifier)
        {
            return _identifiers.Length > 0 && _identifiers[_identifiers.Length - 1] == identifier;
        }

        public DeclaredSymbol GetSymbol(SyntaxNodeOrToken identifier)
        {
            Debug.Assert(identifier != null);
            var index = _identifiers.IndexOf(identifier);
            Debug.Assert(index >= 0);
            ComputeSymbols();
            return _identifierSymbols[index];
        }

    }
}
