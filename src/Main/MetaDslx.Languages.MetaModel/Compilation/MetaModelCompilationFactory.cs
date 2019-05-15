using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.MetaModel
{
    public class MetaModelCompilationFactory : CompilationFactory
    {
        public override BinderFactory CreateBinderFactory(LanguageCompilation compilation, SyntaxTree syntaxTree)
        {
            throw new NotImplementedException();
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree tree, string scriptClassName, bool isSubmission)
        {
            throw new NotImplementedException();
        }
    }
}
