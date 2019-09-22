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
using WebSequenceDiagramsModel.Syntax;
using WebSequenceDiagramsModel.Binding;
using WebSequenceDiagramsModel.Symbols;

namespace WebSequenceDiagramsModel
{
    public class SequenceCompilationFactory : CompilationFactory
    {
        internal SequenceCompilationFactory()
        {
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new SequenceBinderFactoryVisitor(binderFactory);
        }

        public override BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree)
        {
            return new SequenceBoundNodeFactoryVisitor(boundTree);
        }

		public override IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree)
        {
            return new SequenceIsBindableNodeVisitor(boundTree);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return SequenceDeclarationTreeBuilderVisitor.ForTree((SequenceSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        /*public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new SequenceScriptCompilationInfo((SequenceCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new SequenceSymbolBuilder((SequenceCompilation)compilation);
        }*/
    }
}

