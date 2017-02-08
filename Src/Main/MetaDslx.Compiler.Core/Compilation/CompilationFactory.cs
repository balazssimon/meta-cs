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
        internal abstract IMetaSymbol CreateGlobalNamespaceAlias(IMetaSymbol globalNamespace, InContainerBinder inContainerBinder);
        internal abstract AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilationBase);
        internal abstract ScriptCompilationInfo CreateScriptCompilationInfo(Compilation previousSubmission, Type submissionReturnType, Type hostObjectType);
        internal abstract ImmutableArray<IMetaSymbol> TranslateImports(ImmutableModel model, DiagnosticBag diagnostics);

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
        public override RootSingleDeclaration CreateDeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override IMetaSymbol CreateMergedNamespace(Compilation compilation, IEnumerable<IMetaSymbol> namespaces)
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
