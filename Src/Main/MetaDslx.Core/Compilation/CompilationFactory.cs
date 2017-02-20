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

namespace MetaDslx.Compiler
{
    public abstract class CompilationFactory
    {
        internal static readonly CompilationFactory Default = new DefaultCompilationFactory();

        public abstract RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission);
        public abstract ModelFactory CreateModelFactory(MutableModel modelBuilder, bool weak);

        public abstract BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory);

        public abstract IMetaSymbol CreateGlobalNamespace(Compilation compilation, MutableModel modelBuilder, IEnumerable<IMetaSymbol> namespacesToMerge);
        public abstract bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree);
        public abstract IMetaSymbol CreateGlobalNamespaceAlias(IMetaSymbol globalNamespace, Binder rootBinder);
        public abstract AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilation);
        public abstract ScriptCompilationInfo CreateScriptCompilationInfo(Compilation previousSubmission, Type submissionReturnType, Type hostObjectType);

        public abstract IMetaSymbol GetWellKnownSymbol(string name);

        public virtual SemanticModel CreateSyntaxTreeSemanticModel(CompilationBase compilation, SyntaxTree syntaxTree, bool ignoreAccessibility)
        {
            return new SyntaxTreeSemanticModel(compilation, syntaxTree, ignoreAccessibility);
        }

        public virtual IMetaSymbol GetNestedNamespace(IMetaSymbol namespaceSymbol)
        {
            if (namespaceSymbol == null) return null;
            foreach (var nested in namespaceSymbol.MChildren)
            {
                if (nested.MName == namespaceSymbol.MName) return nested;
            }
            return null;
        }

        public abstract IMetaSymbol CreateErrorSymbol(CompilationBase compilation, MutableModel modelBuilder);
    }

    internal sealed class DefaultCompilationFactory : CompilationFactory
    {
        public override AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilationBase)
        {
            throw new NotImplementedException();
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            throw new NotImplementedException();
        }

        public override RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override IMetaSymbol CreateGlobalNamespaceAlias(IMetaSymbol globalNamespace, Binder rootBinder)
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol CreateGlobalNamespace(Compilation compilation, MutableModel modelBuilder, IEnumerable<IMetaSymbol> namespacesToMerge)
        {
            throw new NotImplementedException();
        }

        public override ModelFactory CreateModelFactory(MutableModel modelBuilder, bool weak)
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

        public override bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree)
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol CreateErrorSymbol(CompilationBase compilation, MutableModel modelBuilder)
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol GetWellKnownSymbol(string name)
        {
            throw new NotImplementedException();
        }
    }
}
