using Microsoft.CodeAnalysis.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferenceDirective = MetaDslx.CodeAnalysis.Syntax.ReferenceDirective;

namespace MetaDslx.CodeAnalysis.Declarations
{
    public sealed class RootSingleDeclaration : SingleDeclaration
    {
        private readonly ImmutableArray<Syntax.ReferenceDirective> _referenceDirectives;

        public RootSingleDeclaration(
            Type symbolType,
            Type modelObjectType,
            SyntaxReference treeNode, 
            ImmutableArray<SingleDeclaration> children, 
            ImmutableArray<Syntax.ReferenceDirective> referenceDirectives,
            ImmutableArray<Diagnostic> diagnostics) 
            : base(string.Empty, symbolType, modelObjectType, treeNode, new SourceLocation(treeNode), true, false, false, null, children, ImmutableArray<DeclarationTreeInfo.Property>.Empty, diagnostics)
        {
            _referenceDirectives = referenceDirectives;
        }

        public ImmutableArray<Syntax.ReferenceDirective> ReferenceDirectives
        {
            get
            {
                return _referenceDirectives;
            }
        }


    }
}
