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
using MetaDslx.Languages.Soal.Symbols;
using System.Collections.Immutable;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Languages.Soal
{
    public class SoalCompilationFactory : CompilationFactory
    {
        public static readonly SoalCompilationFactory Instance = new SoalCompilationFactory();

        public override AnonymousTypeManager CreateAnonymousTypeManager(CompilationBase compilationBase)
        {
            return new SoalAnonymousTypeManager();
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new SoalBinderFactoryVisitor(binderFactory);
        }

        public override RootSingleDeclaration CreateDeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return SoalDeclarationTreeBuilder.ForTree((SoalSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override IMetaSymbol CreateGlobalNamespaceAlias(IMetaSymbol globalNamespace, InContainerBinder inContainerBinder)
        {
            throw new NotImplementedException();
        }

        public override IMetaSymbol CreateGlobalNamespace(Compilation compilation, MutableModel modelBuilder, IEnumerable<IMetaSymbol> namespacesToMerge)
        {
            var nsList = namespacesToMerge.ToList();
            string name = nsList.Count > 0 ? nsList[0].MName : string.Empty;
            SoalFactory f = new SoalFactory(modelBuilder);
            var result = f.Namespace();
            result.Name = name;
            if (compilation != null)
            {
                result.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
                result.MSet(CompilerAttachedProperties.ContainingCompilationProperty, compilation);
            }
            return result;
        }

        public override ModelFactory CreateModelFactory(MutableModel modelBuilder)
        {
            return new SoalFactory(modelBuilder);
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(Compilation previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new SoalScriptCompilationInfo((SoalCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilderVisitor CreateSymbolBuilderVisitor(SymbolBuilder symbolBuilder)
        {
            return new SoalSymbolBuilderVisitor(symbolBuilder);
        }

        public override bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree)
        {
            return false;
        }
    }
}
