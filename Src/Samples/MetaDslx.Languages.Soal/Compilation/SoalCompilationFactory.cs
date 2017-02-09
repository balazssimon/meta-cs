using MetaDslx.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;
using MetaDslx.Languages.Soal.Binding;
using MetaDslx.Languages.Soal.Syntax;

namespace MetaDslx.Languages.Soal
{
    public class SoalCompilationFactory : CompilationFactory
    {
        public static readonly SoalCompilationFactory Instance = new SoalCompilationFactory();

        public override AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilationBase)
        {
            return new SoalAnonymousTypeManager();
        }

        public override IBinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            throw new NotImplementedException();
        }

        public override RootSingleDeclaration CreateDeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return SoalDeclarationTreeBuilder.ForTree((SoalSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override IMetaSymbol CreateGlobalNamespaceAlias(IMetaSymbol globalNamespace, InContainerBinder inContainerBinder)
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol CreateMergedNamespace(Compilation compilation, IMetaSymbol containingNamespace, IEnumerable<IMetaSymbol> namespacesToMerge)
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol CreateNamespace(Compilation compilation, IMetaSymbol containingNamespace, string name)
        {
            throw new NotImplementedException();
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(Compilation previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new SoalScriptCompilationInfo((SoalCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SemanticModel CreateSyntaxTreeSemanticModel(CompilationBase compilationBase, SyntaxTree syntaxTree, bool ignoreAccessibility)
        {
            return new SoalSyntaxTreeSemanticModel((SoalCompilation)compilationBase, (SoalSyntaxTree)syntaxTree, ignoreAccessibility);
        }

        public override bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree)
        {
            return false;
        }
    }
}
