using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public abstract class CompilationFactory
    {
        internal static readonly CompilationFactory Default = new DefaultCompilationFactory();

        public abstract IMetaSymbol CreateMergedRootNamespace(Compilation compilation, IEnumerable<IMetaSymbol> rootNamespaces); 
        public abstract RootSingleDeclaration CreateDeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission);
        public abstract IEnumerable<SyntaxNode> GetLoadDirectives(SyntaxTree syntaxTree);
        public abstract string GetLoadDirectiveFileName(SyntaxNode loadDirective);
        public abstract bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree);
    }

    internal sealed class DefaultCompilationFactory : CompilationFactory
    {
        public override RootSingleDeclaration CreateDeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override IMetaSymbol CreateMergedRootNamespace(Compilation compilation, IEnumerable<IMetaSymbol> rootNamespaces)
        {
            throw new NotImplementedException();
        }

        public override string GetLoadDirectiveFileName(SyntaxNode loadDirective)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override IEnumerable<SyntaxNode> GetLoadDirectives(SyntaxTree syntaxTree)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree)
        {
            throw new NotImplementedException();
        }
    }
}
