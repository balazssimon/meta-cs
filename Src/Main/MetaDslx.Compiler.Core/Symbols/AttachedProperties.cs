using MetaDslx.Compiler.Declarations;
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

        public static readonly ModelProperty ContainingCompilationProperty =
            ModelProperty.Register(typeof(CompilerAttachedProperties), "ContainingCompilation",
                new ModelPropertyTypeInfo(typeof(Compilation), null),
                new ModelPropertyTypeInfo(typeof(Compilation), null));

        public static readonly ModelProperty MergedDeclarationProperty =
            ModelProperty.Register(typeof(CompilerAttachedProperties), "MergedDeclaration",
                new ModelPropertyTypeInfo(typeof(MergedDeclaration), null),
                new ModelPropertyTypeInfo(typeof(MergedDeclaration), null));

        public static readonly ModelProperty IsScriptClassProperty =
            ModelProperty.Register(typeof(CompilerAttachedProperties), "IsScriptClass",
                new ModelPropertyTypeInfo(typeof(bool), null),
                new ModelPropertyTypeInfo(typeof(bool), null));
    }
}
