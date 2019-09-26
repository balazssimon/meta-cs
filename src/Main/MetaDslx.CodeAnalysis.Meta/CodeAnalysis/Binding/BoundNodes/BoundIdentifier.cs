using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundIdentifier : BoundQualifier
    {
        private string _lazyName;
        private string _lazyMetadataName;

        public BoundIdentifier(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
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

        public override ImmutableArray<BoundIdentifier> Identifiers => ImmutableArray.Create(this);

        public override void AddIdentifiers(ArrayBuilder<BoundIdentifier> identifiers, CancellationToken cancellationToken = default)
        {
            identifiers.Add(this);
        }

        public override string ToString()
        {
            return this.Name + " = " + this.Value;
        }
    }

}
