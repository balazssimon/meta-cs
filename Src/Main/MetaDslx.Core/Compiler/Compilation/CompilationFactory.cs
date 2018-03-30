using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Diagnostics;
using System.Collections.Immutable;
using MetaDslx.Compiler.References;
using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Binding.MetaBinders;

namespace MetaDslx.Compiler
{
    public abstract class CompilationFactory<TSyntaxTree, TCompilation, TBinder>
        where TSyntaxTree: SyntaxTree
        where TCompilation: CompilationBase
        where TBinder: Binder<TBinder>
    {
        internal static readonly CompilationFactory<SyntaxTree, CompilationBase, MetaBinder> Default = new DefaultCompilationFactory();

        public abstract ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType);

        public abstract RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission);
        public abstract BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory<TBinder> binderFactory);
        public abstract SymbolBuilder CreateSymbolBuilder(CompilationBase compilation);

        public virtual SymbolResolution CreateSymbolResolution(CompilationBase compilation)
        {
            return new SymbolResolution(compilation);
        }

        public virtual AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilation)
        {
            return new AnonymousTypeManager(compilation);
        }

        public virtual SemanticModel CreateSyntaxTreeSemanticModel(CompilationBase compilation, SyntaxTree syntaxTree, bool ignoreAccessibility)
        {
            return new SyntaxTreeSemanticModel(compilation, syntaxTree, ignoreAccessibility);
        }
    }

    internal sealed class DefaultCompilationFactory : CompilationFactory<SyntaxTree, CompilationBase, MetaBinder>
    {
        public override AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilationBase)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory<MetaBinder> binderFactory)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override SymbolResolution CreateSymbolResolution(CompilationBase compilation)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override SemanticModel CreateSyntaxTreeSemanticModel(CompilationBase compilationBase, SyntaxTree syntaxTree, bool ignoreAccessibility)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }

}
