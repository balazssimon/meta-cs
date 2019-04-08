using MetaDslx.Compiler.Declarations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler
{
    public abstract class CompilationFactory
    {
        public abstract RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission);
    }
}
