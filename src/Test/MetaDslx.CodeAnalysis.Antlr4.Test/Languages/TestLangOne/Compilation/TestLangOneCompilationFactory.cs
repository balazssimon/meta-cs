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
using MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne;
using MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Syntax;
using MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Binding;
using MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Symbols;

using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Model;

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne
{
    public class TestLangOneCompilationFactory : CompilationFactory
    {
        internal TestLangOneCompilationFactory()
        {
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new TestLangOneBinderFactoryVisitor(binderFactory);
        }

        public override BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree)
        {
            return new TestLangOneBoundNodeFactoryVisitor(boundTree);
        }

		public override IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree)
        {
            return new TestLangOneIsBindableNodeVisitor(boundTree);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return TestLangOneDeclarationTreeBuilderVisitor.ForTree((TestLangOneSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        /*public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new TestLangOneScriptCompilationInfo((TestLangOneCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new TestLangOneSymbolBuilder((TestLangOneCompilation)compilation);
        }*/
    }
}

