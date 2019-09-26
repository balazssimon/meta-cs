using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundName : BoundValues
    {
        private ImmutableArray<Symbol> _lazySymbols;

        public BoundName(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public ImmutableArray<Symbol> Symbols
        {
            get
            {
                if (_lazySymbols.IsDefault)
                {
                    var qualifiers = this.GetChildQualifiers();
                    var symbols = qualifiers.Select(q => q.Value as Symbol).ToImmutableArray();
                    Debug.Assert(symbols.All(s => s != null));
                    ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, symbols);
                }
                return _lazySymbols;
            }
        }

        public override ImmutableArray<object> Values => StaticCast<object>.From(this.Symbols);

        public override void AddNames(ArrayBuilder<BoundName> names, CancellationToken cancellationToken = default)
        {
            names.AddRange(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            var values = this.Symbols;
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.Append(values[i]);
            }
            sb.Append("]");
            return sb.ToString();
        }
    }

}
