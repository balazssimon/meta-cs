using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.MetaModel
{
    public class MetaModelCompilationFactory : CompilationFactory
    {
        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree tree, string scriptClassName, bool isSubmission)
        {
            throw new NotImplementedException();
        }
    }
}
