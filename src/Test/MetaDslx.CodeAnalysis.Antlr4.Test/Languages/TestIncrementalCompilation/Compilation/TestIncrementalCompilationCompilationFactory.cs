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
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Binding;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation
{
    public class TestIncrementalCompilationCompilationFactory : CompilationFactory
    {
        internal TestIncrementalCompilationCompilationFactory()
        {
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new TestIncrementalCompilationBinderFactoryVisitor(binderFactory);
        }

        public override BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree)
        {
            return new TestIncrementalCompilationBoundNodeFactoryVisitor(boundTree);
        }

		public override IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree)
        {
            return new TestIncrementalCompilationIsBindableNodeVisitor(boundTree);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return TestIncrementalCompilationDeclarationTreeBuilderVisitor.ForTree((TestIncrementalCompilationSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        /*public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new TestIncrementalCompilationScriptCompilationInfo((TestIncrementalCompilationCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new TestIncrementalCompilationSymbolBuilder((TestIncrementalCompilationCompilation)compilation);
        }*/
    }
}

