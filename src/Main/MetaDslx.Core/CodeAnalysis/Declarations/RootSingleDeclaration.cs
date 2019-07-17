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
            ModelSymbolInfo kind,
            SyntaxReference treeNode, 
            ImmutableArray<SingleDeclaration> children, 
            ImmutableArray<ReferenceDirective> referenceDirectives) 
            : base(string.Empty, kind, treeNode, new SourceLocation(treeNode), true, true, null, children, ImmutableArray<Diagnostic>.Empty)
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
