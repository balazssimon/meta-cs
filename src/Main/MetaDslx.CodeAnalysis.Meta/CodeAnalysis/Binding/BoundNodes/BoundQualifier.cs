using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
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

        public BoundQualifier(SyntaxNodeOrToken syntax, BoundNode parent, ImmutableArray<SyntaxNodeOrToken> identifiers)
            : base(syntax, parent)
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
            if (_identifierSymbols.IsDefault)
            {
                var binder = this.GetBinder();
                var diagnostics = DiagnosticBag.GetInstance();
                var symbols = binder.BindDeclaredSymbol(_identifiers, diagnostics);
                ImmutableInterlocked.InterlockedInitialize(ref _identifierSymbols, symbols);
                ImmutableInterlocked.InterlockedInitialize(ref _diagnostics, diagnostics.ToReadOnlyAndFree());
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

        /*
        internal BoundIdentifier GetBoundIdentifierContextOf(SyntaxNodeOrToken identifier)
        {
            Debug.Assert(identifier != null);
            var index = _identifiers.IndexOf(identifier);
            Debug.Assert(index >= 0);
            var prevIndex = index - 1;
            if (prevIndex < 0) return null;
            return GetBoundIdentifier(prevIndex, _identifiers[prevIndex]);
        }

        internal BoundIdentifier GetBoundIdentifier(SyntaxNodeOrToken identifier)
        {
            Debug.Assert(identifier != null);
            var index = _identifiers.IndexOf(identifier);
            return GetBoundIdentifier(index, identifier);
        }

        protected BoundIdentifier GetBoundIdentifier(int index, SyntaxNodeOrToken identifier)
        {
            Debug.Assert(identifier != null);
            Debug.Assert(index >= 0);
            if (index < 0) return null;
            if (_boundIdentifiers[index] != null) return _boundIdentifiers[index];
            var boundIdentifierNode = this.GetBinder()?.GetBinder(identifier)?.B
            Debug.Assert(boundIdentifierNode != null);
            while (boundIdentifierNode != null && !(boundIdentifierNode is BoundIdentifier)) boundIdentifierNode = boundIdentifierNode.ParentBoundNode;
            var boundSymbol = boundIdentifierNode as BoundIdentifier;
            Debug.Assert(boundSymbol != null);
            Interlocked.CompareExchange(ref _boundIdentifiers[index], boundSymbol, null);
            return boundSymbol;
        }
        */
    }
}
