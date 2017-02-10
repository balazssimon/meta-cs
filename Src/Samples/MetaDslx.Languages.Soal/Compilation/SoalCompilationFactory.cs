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

        public override IMetaSymbol CreateMergedNamespace(Compilation compilation, MutableModel modelBuilder, IMetaSymbol containingNamespace, IEnumerable<IMetaSymbol> namespacesToMerge)
        {
            var nsList = namespacesToMerge.ToList();
            return this.CreateNamespace(compilation, modelBuilder, containingNamespace, nsList.Count > 0 ? nsList[0].MName : string.Empty);
        }

        public override IMetaSymbol CreateNamespace(Compilation compilation, MutableModel modelBuilder, IMetaSymbol containingNamespace, string name)
        {
            SoalFactory f = new SoalFactory(modelBuilder);
            var result = f.Namespace();
            result.Name = name;
            if (containingNamespace != null)
            {
                ((NamespaceBuilder)containingNamespace).Declarations.Add(result);
            }
            else if (compilation != null)
            {
                result.MAttachProperty(CompilerAttachedProperties.ContainingCompilationProperty);
                result.MSet(CompilerAttachedProperties.ContainingCompilationProperty, compilation);
            }
            return result;
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(Compilation previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new SoalScriptCompilationInfo((SoalCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override bool HasReferenceOrLoadDirectives(SyntaxTree syntaxTree)
        {
            return false;
        }
    }
}
