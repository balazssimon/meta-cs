using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundIdentifier : BoundQualifierOrIdentifier
    {
        private string _lazyName;
        private string _lazyMetadataName;
        private Symbol _lazySymbol;

        public BoundIdentifier(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public string Name
        {
            get
            {
                if (_lazyName == null)
                {
                    Interlocked.CompareExchange(ref _lazyName, Language.SyntaxFacts.ExtractName(this.Syntax), null);
                }
                return _lazyName;
            }
        }

        public string MetadataName
        {
            get
            {
                if (_lazyMetadataName == null)
                {
                    Interlocked.CompareExchange(ref _lazyMetadataName, Language.SyntaxFacts.ExtractMetadataName(this.Syntax), null);
                }
                return _lazyMetadataName;
            }
        }

        public override Symbol Symbol
        {
            get
            {
                if (_lazySymbol == null)
                {
                    var binder = this.GetBinder();
                    var symbol = binder.GetIdentifierDeclaredSymbol(this.Syntax);
                    if (symbol == null)
                    {
                        symbol = binder.GetIdentifierReferencedSymbol(this.Syntax, this.Name, this.MetadataName, this.DiagnosticBag);
                    }
                    Interlocked.CompareExchange(ref _lazySymbol, symbol, null);
                }
                return _lazySymbol;
            }
        }

        public override ImmutableArray<BoundIdentifier> Identifiers => ImmutableArray.Create(this);

        public override void AddIdentifiers(ArrayBuilder<BoundIdentifier> identifiers)
        {
            identifiers.Add(this);
        }

        public override void AddQualifiers(ArrayBuilder<BoundQualifierOrIdentifier> qualifiers)
        {
            qualifiers.Add(this);
        }

        public override string ToString()
        {
            return this.Name + " = " + this.Symbol;
        }
    }

}
