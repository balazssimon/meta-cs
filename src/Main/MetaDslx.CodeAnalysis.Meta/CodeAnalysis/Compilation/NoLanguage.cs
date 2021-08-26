using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    internal class NoLanguage : Language
    {
        public static readonly NoLanguage Instance = new NoLanguage();

        private NoLanguage()
        {
        }

        public override string Name => string.Empty;

        protected override LanguageServices CreateLanguageServices()
        {
            return new NoLanguageServices();
        }

        private class NoLanguageServices : LanguageServices
        {
            public override CompilationFactory CreateCompilationFactory()
            {
                return new NoCompilationFactory();
            }

            public override InternalSyntaxFactory CreateInternalSyntaxFactory(SyntaxFacts syntaxFacts)
            {
                return new NoInternalSyntaxFactory(syntaxFacts);
            }

            public override SymbolFacts CreateSymbolFacts()
            {
                return new NoSymbolFacts();
            }

            public override SyntaxFactory CreateSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
            {
                return new NoSyntaxFactory(internalSyntaxFactory);
            }

            public override SyntaxFacts CreateSyntaxFacts()
            {
                return new NoSyntaxFacts();
            }

            public override void RegisterServices(ServiceCollection services)
            {
                
            }
        }

        private class NoSyntaxFacts : SyntaxFacts
        {
            public NoSyntaxFacts() : base(typeof(SyntaxKind))
            {
            }

            public override SyntaxKind DefaultWhitespaceKind => SyntaxKind.SkippedTokensTrivia;

            public override SyntaxKind DefaultEndOfLineKind => SyntaxKind.SkippedTokensTrivia;

            public override SyntaxKind DefaultSeparatorKind => SyntaxKind.SkippedTokensTrivia;

            public override SyntaxKind DefaultIdentifierKind => SyntaxKind.SkippedTokensTrivia;

            public override SyntaxKind GetContextualKeywordKind(string text)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<SyntaxKind> GetContextualKeywordKinds()
            {
                throw new NotImplementedException();
            }

            public override SyntaxKind GetFixedTokenKind(string text)
            {
                throw new NotImplementedException();
            }

            public override SyntaxKind GetReservedKeywordKind(string text)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
            {
                throw new NotImplementedException();
            }

            public override string GetText(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override bool IsContextualKeyword(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override bool IsDocumentationCommentTrivia(SyntaxKind rawKind)
            {
                throw new NotImplementedException();
            }

            public override bool IsFixedToken(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override bool IsGeneralCommentTrivia(SyntaxKind rawKind)
            {
                throw new NotImplementedException();
            }

            public override bool IsIdentifier(SyntaxKind rawKind)
            {
                throw new NotImplementedException();
            }

            public override bool IsPreprocessorContextualKeyword(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override bool IsPreprocessorDirective(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override bool IsPreprocessorKeyword(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override bool IsReservedKeyword(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override bool IsToken(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override bool IsTrivia(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }
        }

        private class NoInternalSyntaxFactory : InternalSyntaxFactory
        {
            public NoInternalSyntaxFactory(SyntaxFacts syntaxFacts)
                : base(syntaxFacts)
            {
            }

            public override InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxTrivia ConflictMarker(string text)
            {
                throw new NotImplementedException();
            }

            public override SyntaxLexer CreateLexer(SourceText text, LanguageParseOptions? options)
            {
                throw new NotImplementedException();
            }

            public override SyntaxParser CreateParser(SourceText text, LanguageParseOptions? options, LanguageSyntaxNode? oldTree, ParseData? oldParseData, IEnumerable<TextChangeRange>? changes, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxTrivia DisabledText(string text)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<InternalSyntaxToken> GetWellKnownTokens()
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxToken MissingToken(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxToken MissingToken(GreenNode leading, SyntaxKind kind, GreenNode trailing)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxNode SkippedTokensTrivia(GreenNode token)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxToken Token(SyntaxKind kind)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, GreenNode trailing)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, GreenNode trailing)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, string valueText, GreenNode trailing)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxToken Token(GreenNode leading, SyntaxKind kind, string text, object value, GreenNode trailing)
            {
                throw new NotImplementedException();
            }

            public override InternalSyntaxTrivia Trivia(SyntaxKind kind, string text, bool elastic = false)
            {
                return new CSharpInternalSyntaxTrivia(kind, text);
            }

            private class CSharpInternalSyntaxTrivia : InternalSyntaxTrivia
            {
                public CSharpInternalSyntaxTrivia(SyntaxKind kind, string text, DiagnosticInfo[] diagnostics = null, SyntaxAnnotation[] annotations = null)
                    : base(kind, text, diagnostics, annotations)
                {
                }

                public override GreenNode Clone()
                {
                    return new CSharpInternalSyntaxTrivia(this.Kind, this.Text, this.GetDiagnostics(), this.GetAnnotations());
                }

                public override InternalSyntaxNode WithAnnotations(SyntaxAnnotation[] annotations)
                {
                    return this;
                }

                public override InternalSyntaxNode WithDiagnostics(DiagnosticInfo[] diagnostics)
                {
                    throw new NotImplementedException();
                }
            }
        }

        public class NoSyntaxFactory : SyntaxFactory
        {
            public NoSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
                : base(internalSyntaxFactory)
            {
            }

            public override LanguageParseOptions DefaultParseOptions => throw new NotImplementedException();

            protected override Language LanguageCore => NoLanguage.Instance;

            public override LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
            {
                throw new NotImplementedException();
            }

            protected override LanguageSyntaxTree ParseSyntaxTreeCore(SourceText text, ParseOptions options = null, string path = "", CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
        }

        public class NoSymbolFacts : SymbolFacts
        {
            public override bool ContainsObject(object model, object modelObject)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<object> GetChildren(object modelObject)
            {
                throw new NotImplementedException();
            }

            public override object GetModel(object modelObject)
            {
                throw new NotImplementedException();
            }

            public override Type GetModelObjectType(object modelObject)
            {
                throw new NotImplementedException();
            }

            public override string GetName(object modelObject)
            {
                throw new NotImplementedException();
            }

            public override string GetMetadataName(object modelObject)
            {
                throw new NotImplementedException();
            }

            public override object GetParent(object modelObject)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<object> GetProperties(Type modelObjectType)
            {
                throw new NotImplementedException();
            }

            public override object GetProperty(Type modelObjectType, string propertyName)
            {
                throw new NotImplementedException();
            }

            public override object GetProperty(object modelObject, string propertyName)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<object> GetPropertyValues(object modelObject, object property)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<object> GetRootObjects(object model)
            {
                throw new NotImplementedException();
            }

            public override string GetSymbolProperty(Type modelObjectType, object property)
            {
                throw new NotImplementedException();
            }

            public override Type GetSymbolType(Type modelObjectType)
            {
                throw new NotImplementedException();
            }

            public override bool IsContainmentProperty(object property)
            {
                throw new NotImplementedException();
            }

            public override void SetOrAddPropertyValue(object modelObject, object property, object value, Location location, DiagnosticBag diagnostics, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

        }

        public class NoCompilationFactory : CompilationFactory
        {
            public override LanguageCompilationOptions DefaultCompilationOptions => throw new NotImplementedException();

            public override LanguageCompilationOptions DefaultSubmissionOptions => throw new NotImplementedException();

            protected override Language LanguageCore => NoLanguage.Instance;

            public override BinderFactoryVisitor CreateBinderFactoryVisitor(BinderCache binderFactory)
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
}
