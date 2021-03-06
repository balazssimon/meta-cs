﻿using MetaDslx.CodeAnalysis.Syntax;
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
        private readonly ImmutableArray<ReferenceDirective> _referenceDirectives;

        public RootSingleDeclaration(
            ModelObjectDescriptor kind,
            SyntaxReference treeNode, 
            ImmutableArray<SingleDeclaration> children, 
            ImmutableArray<ReferenceDirective> referenceDirectives,
            ImmutableArray<Diagnostic> diagnostics) 
            : base(string.Empty, kind, treeNode, new SourceLocation(treeNode), true, null, children, ImmutableArray<DeclarationTreeInfo.Property>.Empty, diagnostics)
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
