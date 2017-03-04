// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Languages.Calculator.Syntax;
using MetaDslx.Languages.Calculator.Binding;

namespace MetaDslx.Languages.Calculator
{
    internal class CalculatorCompilationFactory : CompilationFactory
    {
        internal static readonly CalculatorCompilationFactory Instance = new CalculatorCompilationFactory();

        private CalculatorCompilationFactory()
        {
        }

        public override RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return CalculatorDeclarationTreeBuilderVisitor.ForTree((CalculatorSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new CalculatorBinderFactoryVisitor(binderFactory);
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new CalculatorScriptCompilationInfo((CalculatorCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new CalculatorSymbolBuilder((CalculatorCompilation)compilation);
        }
    }
}

