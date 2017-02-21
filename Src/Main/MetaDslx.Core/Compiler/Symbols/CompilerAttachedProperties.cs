using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Diagnostics;
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
    public static class CompilerAttachedProperties
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

        public static readonly ModelProperty PropertiesToMembersMapProperty =
            ModelProperty.Register(typeof(CompilerAttachedProperties), "PropertiesToMembersMap",
                new ModelPropertyTypeInfo(typeof(Dictionary<string, ImmutableArray<IMetaSymbol>>), null),
                new ModelPropertyTypeInfo(typeof(Dictionary<string, ImmutableArray<IMetaSymbol>>), null));

        public static readonly ModelProperty IsScriptClassProperty =
            ModelProperty.Register(typeof(CompilerAttachedProperties), "IsScriptClass",
                new ModelPropertyTypeInfo(typeof(bool), null),
                new ModelPropertyTypeInfo(typeof(bool), null));

        public static readonly ModelProperty UseSiteDiagnosticProperty =
            ModelProperty.Register(typeof(CompilerAttachedProperties), "UseSiteDiagnostic",
                new ModelPropertyTypeInfo(typeof(DiagnosticInfo), null),
                new ModelPropertyTypeInfo(typeof(DiagnosticInfo), null));

        public static readonly ModelProperty DiagnosticBagProperty =
            ModelProperty.Register(typeof(CompilerAttachedProperties), "DiagnosticBag",
                new ModelPropertyTypeInfo(typeof(DiagnosticBag), null),
                new ModelPropertyTypeInfo(typeof(DiagnosticBag), null));
    }
}
