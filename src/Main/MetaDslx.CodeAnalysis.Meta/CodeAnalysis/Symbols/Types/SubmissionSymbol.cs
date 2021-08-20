using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public sealed class SubmissionSymbol : SourceNamedTypeSymbol
    {
        public SubmissionSymbol(NamespaceOrTypeSymbol containingSymbol, MergedDeclaration declaration, object modelObject) 
            : base(containingSymbol, declaration, modelObject)
        {
        }

        public override bool IsImplicitlyDeclared => true;

        /// <summary>
        /// Returns null for a submission class.
        /// This ensures that a submission class does not inherit methods such as ToString or GetHashCode.
        /// </summary>
        public override ImmutableArray<NamedTypeSymbol> BaseTypes
        {
            get
            {
                return ImmutableArray<NamedTypeSymbol>.Empty;
            }
        }
    }
}
