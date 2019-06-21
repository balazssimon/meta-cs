using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundQualifier : BoundValues
    {
        private ImmutableArray<BoundIdentifier> _lazyIdentifiers;
        private Symbol _lazySymbol;

        public BoundQualifier(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public override ImmutableArray<object> Values => ImmutableArray.Create<object>(this.Symbol);

        public Symbol Symbol
        {
            get
            {
                if (_lazySymbol == null)
                {
                    this.GetBinder().InitializeQualifierSymbol(this);
                    Debug.Assert(_lazySymbol != null);
                }
                return _lazySymbol;
            }
        }

        public virtual ImmutableArray<BoundIdentifier> Identifiers
        {
            get
            {
                if (_lazyIdentifiers.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyIdentifiers, this.GetChildIdentifiers());
                }
                return _lazyIdentifiers;
            }
        }

        public override void AddQualifiers(ArrayBuilder<BoundQualifier> qualifiers)
        {
            qualifiers.Add(this);
        }

        internal void InitializeSymbols(ImmutableArray<BoundIdentifier> identifiers, ImmutableArray<Symbol> symbols)
        {
            Debug.Assert(identifiers.Length == symbols.Length);
            for (int i = 0; i < identifiers.Length; i++)
            {
                identifiers[i].InitializeSymbol(symbols[i]);
            }
            this.InitializeSymbol(symbols[symbols.Length - 1]);
        }

        internal bool IsInitialized()
        {
            return _lazySymbol != null;
        }

        protected void InitializeSymbol(Symbol symbol)
        {
            Debug.Assert(symbol != null);
            if (_lazySymbol != null)
            {
                Debug.Assert(_lazySymbol == symbol);
                return;
            }
            Interlocked.CompareExchange(ref _lazySymbol, symbol, null);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var values = this.Identifiers;
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) sb.Append(".");
                sb.Append(values[i].MetadataName);
            }
            sb.Append(" = ");
            sb.Append(this.Symbol);
            return sb.ToString();
        }

    }

}
