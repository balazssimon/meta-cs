using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using MetaDslx.Compiler.References;

namespace MetaDslx.Compiler.Declarations
{
    public sealed class RootSingleDeclaration : SingleDeclaration
    {
        private readonly ImmutableArray<ReferenceDirective> _referenceDirectives;

        public RootSingleDeclaration(
            ModelSymbolInfo kind,
            SyntaxReference treeNode, 
            ImmutableArray<SingleDeclaration> children, 
            ImmutableArray<ReferenceDirective> referenceDirectives) 
            : base(string.Empty, kind, treeNode, new SourceLocation(treeNode.SyntaxTree, treeNode.Span), children)
        {
            _referenceDirectives = referenceDirectives;
        }

        public ImmutableArray<ReferenceDirective> ReferenceDirectives
        {
            get
            {
                return _referenceDirectives;
            }
        }


    }
}
