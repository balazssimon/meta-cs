// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Languages.Soal.Syntax;
using MetaDslx.Languages.Soal.Binding;
using MetaDslx.Languages.Soal.Symbols;

namespace MetaDslx.Languages.Soal
{
    public class SoalCompilationFactory : CompilationFactory
    {
        internal SoalCompilationFactory()
        {
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new SoalBinderFactoryVisitor(binderFactory);
        }

        public override BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree)
        {
            return new SoalBoundNodeFactoryVisitor(boundTree);
        }

		public override IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree)
        {
            return new SoalIsBindableNodeVisitor(boundTree);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return SoalDeclarationTreeBuilderVisitor.ForTree((SoalSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override Symbol CreateSpecialSymbol(ModuleSymbol module, object key)
        {
            if (module is MetaModuleSymbol metaModule && metaModule.Models.Contains(SoalInstance.Model))
            {
                if (key.Equals("oneway"))
                {
                    return new MetaNamedTypeSymbol(SoalInstance.Void, module);
                }
            }
            return null;
        }

        /*public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new SoalScriptCompilationInfo((SoalCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new SoalSymbolBuilder((SoalCompilation)compilation);
        }*/
    }
}

