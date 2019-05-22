using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Languages.Meta.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta
{
    public class MetaCompilationFactory : CompilationFactory
    {
        public override BinderFactory CreateBinderFactory(LanguageCompilation compilation, SyntaxTree syntaxTree)
        {
            throw new NotImplementedException();
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return MetaDeclarationTreeBuilderVisitor.ForTree((MetaSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }
    }
}
