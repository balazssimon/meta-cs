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
using MetaDslx.CodeAnalysis.Antlr4Test;
using MetaDslx.CodeAnalysis.Antlr4Test.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Binding;
using MetaDslx.CodeAnalysis.Antlr4Test.Symbols;

namespace MetaDslx.CodeAnalysis.Antlr4Test
{
    public class TestLexerModeCompilationFactory : CompilationFactory
    {
        internal TestLexerModeCompilationFactory()
        {
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new TestLexerModeBinderFactoryVisitor(binderFactory);
        }

        public override BoundNodeFactoryVisitor CreateBoundNodeFactoryVisitor(BoundTree boundTree)
        {
            return new TestLexerModeBoundNodeFactoryVisitor(boundTree);
        }

		public override IsBindableNodeVisitor CreateIsBindableNodeVisitor(BoundTree boundTree)
        {
            return new TestLexerModeIsBindableNodeVisitor(boundTree);
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return TestLexerModeDeclarationTreeBuilderVisitor.ForTree((TestLexerModeSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        /*public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new TestLexerModeScriptCompilationInfo((TestLexerModeCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new TestLexerModeSymbolBuilder((TestLexerModeCompilation)compilation);
        }*/
    }
}

