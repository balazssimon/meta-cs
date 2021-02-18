using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    public class CSharpCompilationFactory : CompilationFactory
    {
        public override LanguageCompilationOptions DefaultCompilationOptions => throw new NotImplementedException();

        public override LanguageCompilationOptions DefaultSubmissionOptions => throw new NotImplementedException();

        protected override Language LanguageCore => CSharpLanguage.Instance;

        public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderFactory binderFactory)
        {
            throw new NotImplementedException();
        }

        public override LanguageCompilation CreateCompilation(string assemblyName, IEnumerable<SyntaxTree> syntaxTrees = null, IEnumerable<MetadataReference> references = null, LanguageCompilationOptions options = null)
        {
            throw new NotImplementedException();
        }

        public override RootSingleDeclaration CreateDeclarationTree(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            throw new NotImplementedException();
        }

        public override LanguageCompilation CreateScriptCompilation(string assemblyName, SyntaxTree syntaxTree = null, IEnumerable<MetadataReference> references = null, LanguageCompilationOptions options = null, LanguageCompilation previousScriptCompilation = null, Type returnType = null, Type globalsType = null)
        {
            throw new NotImplementedException();
        }
    }
}
