using MetaDslx.CodeAnalysis.Declarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public abstract class CompilationFactory
    {
        public abstract RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree tree, string scriptClassName, bool isSubmission);
    }
}
