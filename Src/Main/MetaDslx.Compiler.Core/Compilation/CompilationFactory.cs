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

namespace MetaDslx.Compiler
{
    public abstract class CompilationFactory
    {
        internal static readonly CompilationFactory Default = new DefaultCompilationFactory();

        public abstract IMetaSymbol CreateMergedNamespace(Compilation compilation, IMetaSymbol containingNamespace, IEnumerable<IMetaSymbol> namespacesToMerge);
        public abstract IMetaSymbol CreateNamespace(Compilation compilation, IMetaSymbol containingNamespace, string name);
        public abstract RootSingleDeclaration CreateDeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission);
        public abstract IEnumerable<SyntaxNode> GetLoadDirectives(SyntaxTree syntaxTree);
        public abstract string GetLoadDirectiveFileName(SyntaxNode loadDirective);
        public abstract bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree);
        public abstract IBinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory);
        public abstract IMetaSymbol CreateGlobalNamespaceAlias(IMetaSymbol globalNamespace, InContainerBinder inContainerBinder);
        public abstract AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilationBase);
        public abstract ScriptCompilationInfo CreateScriptCompilationInfo(Compilation previousSubmission, Type submissionReturnType, Type hostObjectType);
        public abstract ImmutableArray<IMetaSymbol> TranslateImports(ImmutableModel model, DiagnosticBag diagnostics);
        public abstract SemanticModel CreateSyntaxTreeSemanticModel(CompilationBase compilationBase, SyntaxTree syntaxTree, bool ignoreAccessibility);

        public virtual IMetaSymbol GetNestedNamespace(IMetaSymbol namespaceSymbol)
        {
            if (namespaceSymbol == null) return null;
            foreach (var nested in namespaceSymbol.MChildren)
            {
                if (nested.MName == namespaceSymbol.MName) return nested;
            }
            return null;
        }

    }

    internal sealed class DefaultCompilationFactory : CompilationFactory
    {
        public override AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilationBase)
        {
            throw new NotImplementedException();
        }

        public override IBinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            throw new NotImplementedException();
        }

        public override RootSingleDeclaration CreateDeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            throw ExceptionUtilities.Unreachable;
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
            throw new NotImplementedException();
        }

        public override SemanticModel CreateSyntaxTreeSemanticModel(CompilationBase compilationBase, SyntaxTree syntaxTree, bool ignoreAccessibility)
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

        public override ImmutableArray<IMetaSymbol> TranslateImports(ImmutableModel model, DiagnosticBag diagnostics)
        {
            throw new NotImplementedException();
        }
    }
}
