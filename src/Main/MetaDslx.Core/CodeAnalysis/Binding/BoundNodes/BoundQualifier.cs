using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundQualifier : BoundQualifierOrIdentifier
    {
        private ImmutableArray<BoundIdentifier> _lazyIdentifiers;
        private Symbol _lazySymbol;

        public BoundQualifier(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }


        public override Symbol Symbol
        {
            get
            {
                if (_lazySymbol == null)
                {
                    var identifiers = this.Identifiers;
                    if (identifiers.Length > 0)
                    {
                        Interlocked.CompareExchange(ref _lazySymbol, identifiers[identifiers.Length - 1].Symbol, null);
                    }
                }
                return _lazySymbol;
            }
        }

        public override ImmutableArray<BoundIdentifier> Identifiers
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

        public override void AddQualifiers(ArrayBuilder<BoundQualifierOrIdentifier> qualifiers)
        {
            qualifiers.Add(this);
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
