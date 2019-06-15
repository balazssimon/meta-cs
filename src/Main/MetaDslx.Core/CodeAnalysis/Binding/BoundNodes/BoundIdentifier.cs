using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundIdentifier : BoundNode
    {
        private string _lazyName;
        private string _lazyMetadataName;

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

        protected override void AddIdentifiers(ArrayBuilder<Identifier> identifiers)
        {
            identifiers.Add(new Identifier(this.Syntax, this.Name, this.MetadataName));
        }

        protected override void AddQualifiers(ArrayBuilder<Qualifier> qualifiers)
        {
            qualifiers.Add(new Qualifier(ImmutableArray.Create(new Identifier(this.Syntax, this.Name, this.MetadataName))));
        }

        protected override void AddNames(ArrayBuilder<Qualifier> names)
        {
        }
    }

}
