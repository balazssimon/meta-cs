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
using MetaDslx.Compiler.Binding.Binders;

namespace MetaDslx.Languages.Soal
{
    public class SoalCompilationFactory : CompilationFactory
    {
        public static readonly SoalCompilationFactory Instance = new SoalCompilationFactory();

        public override RootSingleDeclaration CreateDeclarationTree(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            return SoalDeclarationTreeBuilderVisitor.ForTree((SoalSyntaxTree)syntaxTree, scriptClassName, isSubmission);
        }

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            return new SoalBinderFactoryVisitor(binderFactory);
        }

        public override ScriptCompilationInfo CreateScriptCompilationInfo(CompilationBase previousSubmission, Type submissionReturnType, Type hostObjectType)
        {
            return new SoalScriptCompilationInfo((SoalCompilation)previousSubmission, submissionReturnType, hostObjectType);
        }

        public override SymbolBuilder CreateSymbolBuilder(CompilationBase compilation)
        {
            return new SoalSymbolBuilder((SoalCompilation)compilation);
        }

        public override SymbolResolution CreateSymbolResolution(CompilationBase compilation)
        {
            return new SoalSymbolResolution((SoalCompilation)compilation);
        }
    }
}
