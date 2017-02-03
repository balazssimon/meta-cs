using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Symbols
{
    [ModelSymbolDescriptor]
    internal static class CompilerAttachedProperties
    {
        public static readonly ModelProperty DeclaringSyntaxReferencesProperty =
            ModelProperty.Register(typeof(CompilerAttachedProperties), "DeclaringSyntaxReferences",
                new ModelPropertyTypeInfo(typeof(ImmutableArray<SyntaxReference>), null),
                new ModelPropertyTypeInfo(typeof(ImmutableArray<SyntaxReference>), null));

    }
}
