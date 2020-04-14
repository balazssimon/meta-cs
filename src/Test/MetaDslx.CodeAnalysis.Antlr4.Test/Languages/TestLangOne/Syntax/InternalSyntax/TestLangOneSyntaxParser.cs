// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Syntax.InternalSyntax
{
    public class TestLangOneSyntaxParser : Antlr4SyntaxParser<TestLangOneLexer, TestLangOneParser>
    {
        public TestLangOneSyntaxParser(
            SourceText text,
            TestLangOneParseOptions options,
            SyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
            : base(text, TestLangOneLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }
        public override DirectiveStack Directives
        {
            get
            {
                return DirectiveStack.Empty;
            }
        }
        protected override TestLangOneLexer CreateLexer(AntlrInputStream inputStream)
        {
            return new TestLangOneLexer(inputStream);
        }
        protected override TestLangOneParser CreateParser(CommonTokenStream tokenStream)
        {
            return new TestLangOneParser(tokenStream);
        }
        public override GreenNode Parse()
        {
            return this.ParseMain();
        }
        internal MainGreen ParseMain()
        {
            Antlr4ToRoslynVisitor visitor = new Antlr4ToRoslynVisitor(this);
            var tree = this.Parser.main();
            return (MainGreen)visitor.Visit(tree);
        }
        private class Antlr4ToRoslynVisitor : TestLangOneParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.            private TestLangOneLanguage language;
			private TestLangOneInternalSyntaxFactory factory;
            private TestLangOneSyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastTokenOrTrivia;
            public Antlr4ToRoslynVisitor(TestLangOneSyntaxParser syntaxParser)
            {
				this.factory = (TestLangOneInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                this.syntaxParser = syntaxParser;
				this.tokens = this.syntaxParser.CommonTokenStream.GetTokens();
                this.lastTokenOrTrivia = null;
            }
            private GreenNode VisitTerminal(IToken token, TestLangOneSyntaxKind kind)
            {
                return this.syntaxParser.VisitTerminal(token, kind, ref this.lastTokenOrTrivia);
            }
            public GreenNode VisitTerminal(IToken token)
            {
                return this.VisitTerminal(token, null);
            }
            private GreenNode VisitTerminal(ITerminalNode node, TestLangOneSyntaxKind kind)
            {
                return this.syntaxParser.VisitTerminal(node, kind, ref this.lastTokenOrTrivia);
            }
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                return this.VisitTerminal(node, null);
            }
			
			public override GreenNode VisitMain(TestLangOneParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
			    TestLangOneParser.TestContext[] testContext = context.test();
			    var testBuilder = _pool.Allocate<TestGreen>();
			    for (int i = 0; i < testContext.Length; i++)
			    {
			        testBuilder.Add((TestGreen)this.Visit(testContext[i]));
			    }
				var test = testBuilder.ToList();
				_pool.Free(testBuilder);
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), TestLangOneSyntaxKind.Eof);
				return this.factory.Main(test, eOF);
			}
			
			public override GreenNode VisitTest(TestLangOneParser.TestContext context)
			{
				if (context == null) return TestGreen.__Missing;
				TestLangOneParser.Test01Context test01Context = context.test01();
				if (test01Context != null) 
				{
					return this.factory.Test((Test01Green)this.Visit(test01Context));
				}
				TestLangOneParser.Test02Context test02Context = context.test02();
				if (test02Context != null) 
				{
					return this.factory.Test((Test02Green)this.Visit(test02Context));
				}
				TestLangOneParser.Test03Context test03Context = context.test03();
				if (test03Context != null) 
				{
					return this.factory.Test((Test03Green)this.Visit(test03Context));
				}
				TestLangOneParser.Test04Context test04Context = context.test04();
				if (test04Context != null) 
				{
					return this.factory.Test((Test04Green)this.Visit(test04Context));
				}
				TestLangOneParser.Test05Context test05Context = context.test05();
				if (test05Context != null) 
				{
					return this.factory.Test((Test05Green)this.Visit(test05Context));
				}
				TestLangOneParser.Test06Context test06Context = context.test06();
				if (test06Context != null) 
				{
					return this.factory.Test((Test06Green)this.Visit(test06Context));
				}
				TestLangOneParser.Test07Context test07Context = context.test07();
				if (test07Context != null) 
				{
					return this.factory.Test((Test07Green)this.Visit(test07Context));
				}
				TestLangOneParser.Test08Context test08Context = context.test08();
				if (test08Context != null) 
				{
					return this.factory.Test((Test08Green)this.Visit(test08Context));
				}
				TestLangOneParser.Test09Context test09Context = context.test09();
				if (test09Context != null) 
				{
					return this.factory.Test((Test09Green)this.Visit(test09Context));
				}
				TestLangOneParser.Test10Context test10Context = context.test10();
				if (test10Context != null) 
				{
					return this.factory.Test((Test10Green)this.Visit(test10Context));
				}
				TestLangOneParser.Test11Context test11Context = context.test11();
				if (test11Context != null) 
				{
					return this.factory.Test((Test11Green)this.Visit(test11Context));
				}
				return TestGreen.__Missing;
			}
			
			public override GreenNode VisitTest01(TestLangOneParser.Test01Context context)
			{
				if (context == null) return Test01Green.__Missing;
				InternalSyntaxToken kTest01 = (InternalSyntaxToken)this.VisitTerminal(context.KTest01(), TestLangOneSyntaxKind.KTest01);
				TestLangOneParser.NamespaceDeclaration01Context namespaceDeclaration01Context = context.namespaceDeclaration01();
				NamespaceDeclaration01Green namespaceDeclaration01 = null;
				if (namespaceDeclaration01Context != null)
				{
					namespaceDeclaration01 = (NamespaceDeclaration01Green)this.Visit(namespaceDeclaration01Context);
				}
				else
				{
					namespaceDeclaration01 = NamespaceDeclaration01Green.__Missing;
				}
				return this.factory.Test01(kTest01, namespaceDeclaration01);
			}
			
			public override GreenNode VisitNamespaceDeclaration01(TestLangOneParser.NamespaceDeclaration01Context context)
			{
				if (context == null) return NamespaceDeclaration01Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody01Context namespaceBody01Context = context.namespaceBody01();
				NamespaceBody01Green namespaceBody01 = null;
				if (namespaceBody01Context != null)
				{
					namespaceBody01 = (NamespaceBody01Green)this.Visit(namespaceBody01Context);
				}
				else
				{
					namespaceBody01 = NamespaceBody01Green.__Missing;
				}
				return this.factory.NamespaceDeclaration01(kNamespace, qualifiedName, namespaceBody01);
			}
			
			public override GreenNode VisitNamespaceBody01(TestLangOneParser.NamespaceBody01Context context)
			{
				if (context == null) return NamespaceBody01Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration01Context[] declaration01Context = context.declaration01();
			    var declaration01Builder = _pool.Allocate<Declaration01Green>();
			    for (int i = 0; i < declaration01Context.Length; i++)
			    {
			        declaration01Builder.Add((Declaration01Green)this.Visit(declaration01Context[i]));
			    }
				var declaration01 = declaration01Builder.ToList();
				_pool.Free(declaration01Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody01(tOpenBrace, declaration01, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration01(TestLangOneParser.Declaration01Context context)
			{
				if (context == null) return Declaration01Green.__Missing;
				TestLangOneParser.Vertex01Context vertex01Context = context.vertex01();
				if (vertex01Context != null) 
				{
					return this.factory.Declaration01((Vertex01Green)this.Visit(vertex01Context));
				}
				TestLangOneParser.Arrow01Context arrow01Context = context.arrow01();
				if (arrow01Context != null) 
				{
					return this.factory.Declaration01((Arrow01Green)this.Visit(arrow01Context));
				}
				return Declaration01Green.__Missing;
			}
			
			public override GreenNode VisitVertex01(TestLangOneParser.Vertex01Context context)
			{
				if (context == null) return Vertex01Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex01(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow01(TestLangOneParser.Arrow01Context context)
			{
				if (context == null) return Arrow01Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifierGreen)this.Visit(sourceContext);
				}
				else
				{
					source = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null)
				{
					target = (QualifierGreen)this.Visit(targetContext);
				}
				else
				{
					target = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow01(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest02(TestLangOneParser.Test02Context context)
			{
				if (context == null) return Test02Green.__Missing;
				InternalSyntaxToken kTest02 = (InternalSyntaxToken)this.VisitTerminal(context.KTest02(), TestLangOneSyntaxKind.KTest02);
				TestLangOneParser.NamespaceDeclaration02Context namespaceDeclaration02Context = context.namespaceDeclaration02();
				NamespaceDeclaration02Green namespaceDeclaration02 = null;
				if (namespaceDeclaration02Context != null)
				{
					namespaceDeclaration02 = (NamespaceDeclaration02Green)this.Visit(namespaceDeclaration02Context);
				}
				else
				{
					namespaceDeclaration02 = NamespaceDeclaration02Green.__Missing;
				}
				return this.factory.Test02(kTest02, namespaceDeclaration02);
			}
			
			public override GreenNode VisitNamespaceDeclaration02(TestLangOneParser.NamespaceDeclaration02Context context)
			{
				if (context == null) return NamespaceDeclaration02Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody02Context namespaceBody02Context = context.namespaceBody02();
				NamespaceBody02Green namespaceBody02 = null;
				if (namespaceBody02Context != null)
				{
					namespaceBody02 = (NamespaceBody02Green)this.Visit(namespaceBody02Context);
				}
				else
				{
					namespaceBody02 = NamespaceBody02Green.__Missing;
				}
				return this.factory.NamespaceDeclaration02(kNamespace, qualifiedName, namespaceBody02);
			}
			
			public override GreenNode VisitNamespaceBody02(TestLangOneParser.NamespaceBody02Context context)
			{
				if (context == null) return NamespaceBody02Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration02Context[] declaration02Context = context.declaration02();
			    var declaration02Builder = _pool.Allocate<Declaration02Green>();
			    for (int i = 0; i < declaration02Context.Length; i++)
			    {
			        declaration02Builder.Add((Declaration02Green)this.Visit(declaration02Context[i]));
			    }
				var declaration02 = declaration02Builder.ToList();
				_pool.Free(declaration02Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody02(tOpenBrace, declaration02, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration02(TestLangOneParser.Declaration02Context context)
			{
				if (context == null) return Declaration02Green.__Missing;
				TestLangOneParser.Vertex02Context vertex02Context = context.vertex02();
				if (vertex02Context != null) 
				{
					return this.factory.Declaration02((Vertex02Green)this.Visit(vertex02Context));
				}
				TestLangOneParser.Arrow02Context arrow02Context = context.arrow02();
				if (arrow02Context != null) 
				{
					return this.factory.Declaration02((Arrow02Green)this.Visit(arrow02Context));
				}
				return Declaration02Green.__Missing;
			}
			
			public override GreenNode VisitVertex02(TestLangOneParser.Vertex02Context context)
			{
				if (context == null) return Vertex02Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex02(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow02(TestLangOneParser.Arrow02Context context)
			{
				if (context == null) return Arrow02Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.Source02Context source02Context = context.source02();
				Source02Green source02 = null;
				if (source02Context != null)
				{
					source02 = (Source02Green)this.Visit(source02Context);
				}
				else
				{
					source02 = Source02Green.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.Target02Context target02Context = context.target02();
				Target02Green target02 = null;
				if (target02Context != null)
				{
					target02 = (Target02Green)this.Visit(target02Context);
				}
				else
				{
					target02 = Target02Green.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow02(kArrow, source02, tArrow, target02, tSemicolon);
			}
			
			public override GreenNode VisitSource02(TestLangOneParser.Source02Context context)
			{
				if (context == null) return Source02Green.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return this.factory.Source02(qualifier);
			}
			
			public override GreenNode VisitTarget02(TestLangOneParser.Target02Context context)
			{
				if (context == null) return Target02Green.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return this.factory.Target02(qualifier);
			}
			
			public override GreenNode VisitTest03(TestLangOneParser.Test03Context context)
			{
				if (context == null) return Test03Green.__Missing;
				InternalSyntaxToken kTest03 = (InternalSyntaxToken)this.VisitTerminal(context.KTest03(), TestLangOneSyntaxKind.KTest03);
				TestLangOneParser.NamespaceDeclaration03Context namespaceDeclaration03Context = context.namespaceDeclaration03();
				NamespaceDeclaration03Green namespaceDeclaration03 = null;
				if (namespaceDeclaration03Context != null)
				{
					namespaceDeclaration03 = (NamespaceDeclaration03Green)this.Visit(namespaceDeclaration03Context);
				}
				else
				{
					namespaceDeclaration03 = NamespaceDeclaration03Green.__Missing;
				}
				return this.factory.Test03(kTest03, namespaceDeclaration03);
			}
			
			public override GreenNode VisitNamespaceDeclaration03(TestLangOneParser.NamespaceDeclaration03Context context)
			{
				if (context == null) return NamespaceDeclaration03Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody03Context namespaceBody03Context = context.namespaceBody03();
				NamespaceBody03Green namespaceBody03 = null;
				if (namespaceBody03Context != null)
				{
					namespaceBody03 = (NamespaceBody03Green)this.Visit(namespaceBody03Context);
				}
				else
				{
					namespaceBody03 = NamespaceBody03Green.__Missing;
				}
				return this.factory.NamespaceDeclaration03(kNamespace, qualifiedName, namespaceBody03);
			}
			
			public override GreenNode VisitNamespaceBody03(TestLangOneParser.NamespaceBody03Context context)
			{
				if (context == null) return NamespaceBody03Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration03Context[] declaration03Context = context.declaration03();
			    var declaration03Builder = _pool.Allocate<Declaration03Green>();
			    for (int i = 0; i < declaration03Context.Length; i++)
			    {
			        declaration03Builder.Add((Declaration03Green)this.Visit(declaration03Context[i]));
			    }
				var declaration03 = declaration03Builder.ToList();
				_pool.Free(declaration03Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody03(tOpenBrace, declaration03, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration03(TestLangOneParser.Declaration03Context context)
			{
				if (context == null) return Declaration03Green.__Missing;
				TestLangOneParser.Vertex03Context vertex03Context = context.vertex03();
				if (vertex03Context != null) 
				{
					return this.factory.Declaration03((Vertex03Green)this.Visit(vertex03Context));
				}
				TestLangOneParser.Arrow03Context arrow03Context = context.arrow03();
				if (arrow03Context != null) 
				{
					return this.factory.Declaration03((Arrow03Green)this.Visit(arrow03Context));
				}
				return Declaration03Green.__Missing;
			}
			
			public override GreenNode VisitVertex03(TestLangOneParser.Vertex03Context context)
			{
				if (context == null) return Vertex03Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex03(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow03(TestLangOneParser.Arrow03Context context)
			{
				if (context == null) return Arrow03Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.Source03Context source03Context = context.source03();
				Source03Green source03 = null;
				if (source03Context != null)
				{
					source03 = (Source03Green)this.Visit(source03Context);
				}
				else
				{
					source03 = Source03Green.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.Target03Context target03Context = context.target03();
				Target03Green target03 = null;
				if (target03Context != null)
				{
					target03 = (Target03Green)this.Visit(target03Context);
				}
				else
				{
					target03 = Target03Green.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow03(kArrow, source03, tArrow, target03, tSemicolon);
			}
			
			public override GreenNode VisitSource03(TestLangOneParser.Source03Context context)
			{
				if (context == null) return Source03Green.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return this.factory.Source03(qualifier);
			}
			
			public override GreenNode VisitTarget03(TestLangOneParser.Target03Context context)
			{
				if (context == null) return Target03Green.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return this.factory.Target03(qualifier);
			}
			
			public override GreenNode VisitTest04(TestLangOneParser.Test04Context context)
			{
				if (context == null) return Test04Green.__Missing;
				InternalSyntaxToken kTest04 = (InternalSyntaxToken)this.VisitTerminal(context.KTest04(), TestLangOneSyntaxKind.KTest04);
				TestLangOneParser.NamespaceDeclaration04Context namespaceDeclaration04Context = context.namespaceDeclaration04();
				NamespaceDeclaration04Green namespaceDeclaration04 = null;
				if (namespaceDeclaration04Context != null)
				{
					namespaceDeclaration04 = (NamespaceDeclaration04Green)this.Visit(namespaceDeclaration04Context);
				}
				else
				{
					namespaceDeclaration04 = NamespaceDeclaration04Green.__Missing;
				}
				return this.factory.Test04(kTest04, namespaceDeclaration04);
			}
			
			public override GreenNode VisitNamespaceDeclaration04(TestLangOneParser.NamespaceDeclaration04Context context)
			{
				if (context == null) return NamespaceDeclaration04Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody04Context namespaceBody04Context = context.namespaceBody04();
				NamespaceBody04Green namespaceBody04 = null;
				if (namespaceBody04Context != null)
				{
					namespaceBody04 = (NamespaceBody04Green)this.Visit(namespaceBody04Context);
				}
				else
				{
					namespaceBody04 = NamespaceBody04Green.__Missing;
				}
				return this.factory.NamespaceDeclaration04(kNamespace, qualifiedName, namespaceBody04);
			}
			
			public override GreenNode VisitNamespaceBody04(TestLangOneParser.NamespaceBody04Context context)
			{
				if (context == null) return NamespaceBody04Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration04Context[] declaration04Context = context.declaration04();
			    var declaration04Builder = _pool.Allocate<Declaration04Green>();
			    for (int i = 0; i < declaration04Context.Length; i++)
			    {
			        declaration04Builder.Add((Declaration04Green)this.Visit(declaration04Context[i]));
			    }
				var declaration04 = declaration04Builder.ToList();
				_pool.Free(declaration04Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody04(tOpenBrace, declaration04, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration04(TestLangOneParser.Declaration04Context context)
			{
				if (context == null) return Declaration04Green.__Missing;
				TestLangOneParser.Vertex04Context vertex04Context = context.vertex04();
				if (vertex04Context != null) 
				{
					return this.factory.Declaration04((Vertex04Green)this.Visit(vertex04Context));
				}
				TestLangOneParser.Arrow04Context arrow04Context = context.arrow04();
				if (arrow04Context != null) 
				{
					return this.factory.Declaration04((Arrow04Green)this.Visit(arrow04Context));
				}
				return Declaration04Green.__Missing;
			}
			
			public override GreenNode VisitVertex04(TestLangOneParser.Vertex04Context context)
			{
				if (context == null) return Vertex04Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex04(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow04(TestLangOneParser.Arrow04Context context)
			{
				if (context == null) return Arrow04Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifierGreen)this.Visit(sourceContext);
				}
				else
				{
					source = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null)
				{
					target = (QualifierGreen)this.Visit(targetContext);
				}
				else
				{
					target = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow04(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest05(TestLangOneParser.Test05Context context)
			{
				if (context == null) return Test05Green.__Missing;
				InternalSyntaxToken kTest05 = (InternalSyntaxToken)this.VisitTerminal(context.KTest05(), TestLangOneSyntaxKind.KTest05);
				TestLangOneParser.NamespaceDeclaration05Context namespaceDeclaration05Context = context.namespaceDeclaration05();
				NamespaceDeclaration05Green namespaceDeclaration05 = null;
				if (namespaceDeclaration05Context != null)
				{
					namespaceDeclaration05 = (NamespaceDeclaration05Green)this.Visit(namespaceDeclaration05Context);
				}
				else
				{
					namespaceDeclaration05 = NamespaceDeclaration05Green.__Missing;
				}
				return this.factory.Test05(kTest05, namespaceDeclaration05);
			}
			
			public override GreenNode VisitNamespaceDeclaration05(TestLangOneParser.NamespaceDeclaration05Context context)
			{
				if (context == null) return NamespaceDeclaration05Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody05Context namespaceBody05Context = context.namespaceBody05();
				NamespaceBody05Green namespaceBody05 = null;
				if (namespaceBody05Context != null)
				{
					namespaceBody05 = (NamespaceBody05Green)this.Visit(namespaceBody05Context);
				}
				else
				{
					namespaceBody05 = NamespaceBody05Green.__Missing;
				}
				return this.factory.NamespaceDeclaration05(kNamespace, qualifiedName, namespaceBody05);
			}
			
			public override GreenNode VisitNamespaceBody05(TestLangOneParser.NamespaceBody05Context context)
			{
				if (context == null) return NamespaceBody05Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration05Context[] declaration05Context = context.declaration05();
			    var declaration05Builder = _pool.Allocate<Declaration05Green>();
			    for (int i = 0; i < declaration05Context.Length; i++)
			    {
			        declaration05Builder.Add((Declaration05Green)this.Visit(declaration05Context[i]));
			    }
				var declaration05 = declaration05Builder.ToList();
				_pool.Free(declaration05Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody05(tOpenBrace, declaration05, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration05(TestLangOneParser.Declaration05Context context)
			{
				if (context == null) return Declaration05Green.__Missing;
				TestLangOneParser.Vertex05Context vertex05Context = context.vertex05();
				if (vertex05Context != null) 
				{
					return this.factory.Declaration05((Vertex05Green)this.Visit(vertex05Context));
				}
				TestLangOneParser.Arrow05Context arrow05Context = context.arrow05();
				if (arrow05Context != null) 
				{
					return this.factory.Declaration05((Arrow05Green)this.Visit(arrow05Context));
				}
				return Declaration05Green.__Missing;
			}
			
			public override GreenNode VisitVertex05(TestLangOneParser.Vertex05Context context)
			{
				if (context == null) return Vertex05Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex05(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow05(TestLangOneParser.Arrow05Context context)
			{
				if (context == null) return Arrow05Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifierGreen)this.Visit(sourceContext);
				}
				else
				{
					source = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null)
				{
					target = (QualifierGreen)this.Visit(targetContext);
				}
				else
				{
					target = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow05(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest06(TestLangOneParser.Test06Context context)
			{
				if (context == null) return Test06Green.__Missing;
				InternalSyntaxToken kTest06 = (InternalSyntaxToken)this.VisitTerminal(context.KTest06(), TestLangOneSyntaxKind.KTest06);
				TestLangOneParser.NamespaceDeclaration06Context namespaceDeclaration06Context = context.namespaceDeclaration06();
				NamespaceDeclaration06Green namespaceDeclaration06 = null;
				if (namespaceDeclaration06Context != null)
				{
					namespaceDeclaration06 = (NamespaceDeclaration06Green)this.Visit(namespaceDeclaration06Context);
				}
				else
				{
					namespaceDeclaration06 = NamespaceDeclaration06Green.__Missing;
				}
				return this.factory.Test06(kTest06, namespaceDeclaration06);
			}
			
			public override GreenNode VisitNamespaceDeclaration06(TestLangOneParser.NamespaceDeclaration06Context context)
			{
				if (context == null) return NamespaceDeclaration06Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody06Context namespaceBody06Context = context.namespaceBody06();
				NamespaceBody06Green namespaceBody06 = null;
				if (namespaceBody06Context != null)
				{
					namespaceBody06 = (NamespaceBody06Green)this.Visit(namespaceBody06Context);
				}
				else
				{
					namespaceBody06 = NamespaceBody06Green.__Missing;
				}
				return this.factory.NamespaceDeclaration06(kNamespace, qualifiedName, namespaceBody06);
			}
			
			public override GreenNode VisitNamespaceBody06(TestLangOneParser.NamespaceBody06Context context)
			{
				if (context == null) return NamespaceBody06Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration06Context[] declaration06Context = context.declaration06();
			    var declaration06Builder = _pool.Allocate<Declaration06Green>();
			    for (int i = 0; i < declaration06Context.Length; i++)
			    {
			        declaration06Builder.Add((Declaration06Green)this.Visit(declaration06Context[i]));
			    }
				var declaration06 = declaration06Builder.ToList();
				_pool.Free(declaration06Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody06(tOpenBrace, declaration06, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration06(TestLangOneParser.Declaration06Context context)
			{
				if (context == null) return Declaration06Green.__Missing;
				TestLangOneParser.Vertex06Context vertex06Context = context.vertex06();
				if (vertex06Context != null) 
				{
					return this.factory.Declaration06((Vertex06Green)this.Visit(vertex06Context));
				}
				TestLangOneParser.Arrow06Context arrow06Context = context.arrow06();
				if (arrow06Context != null) 
				{
					return this.factory.Declaration06((Arrow06Green)this.Visit(arrow06Context));
				}
				return Declaration06Green.__Missing;
			}
			
			public override GreenNode VisitVertex06(TestLangOneParser.Vertex06Context context)
			{
				if (context == null) return Vertex06Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex06(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow06(TestLangOneParser.Arrow06Context context)
			{
				if (context == null) return Arrow06Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.NameContext sourceContext = context.source;
				NameGreen source = null;
				if (sourceContext != null)
				{
					source = (NameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = NameGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.NameContext targetContext = context.target;
				NameGreen target = null;
				if (targetContext != null)
				{
					target = (NameGreen)this.Visit(targetContext);
				}
				else
				{
					target = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow06(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest07(TestLangOneParser.Test07Context context)
			{
				if (context == null) return Test07Green.__Missing;
				InternalSyntaxToken kTest07 = (InternalSyntaxToken)this.VisitTerminal(context.KTest07(), TestLangOneSyntaxKind.KTest07);
				TestLangOneParser.NamespaceDeclaration07Context namespaceDeclaration07Context = context.namespaceDeclaration07();
				NamespaceDeclaration07Green namespaceDeclaration07 = null;
				if (namespaceDeclaration07Context != null)
				{
					namespaceDeclaration07 = (NamespaceDeclaration07Green)this.Visit(namespaceDeclaration07Context);
				}
				else
				{
					namespaceDeclaration07 = NamespaceDeclaration07Green.__Missing;
				}
				return this.factory.Test07(kTest07, namespaceDeclaration07);
			}
			
			public override GreenNode VisitNamespaceDeclaration07(TestLangOneParser.NamespaceDeclaration07Context context)
			{
				if (context == null) return NamespaceDeclaration07Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody07Context namespaceBody07Context = context.namespaceBody07();
				NamespaceBody07Green namespaceBody07 = null;
				if (namespaceBody07Context != null)
				{
					namespaceBody07 = (NamespaceBody07Green)this.Visit(namespaceBody07Context);
				}
				else
				{
					namespaceBody07 = NamespaceBody07Green.__Missing;
				}
				return this.factory.NamespaceDeclaration07(kNamespace, qualifiedName, namespaceBody07);
			}
			
			public override GreenNode VisitNamespaceBody07(TestLangOneParser.NamespaceBody07Context context)
			{
				if (context == null) return NamespaceBody07Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration07Context[] declaration07Context = context.declaration07();
			    var declaration07Builder = _pool.Allocate<Declaration07Green>();
			    for (int i = 0; i < declaration07Context.Length; i++)
			    {
			        declaration07Builder.Add((Declaration07Green)this.Visit(declaration07Context[i]));
			    }
				var declaration07 = declaration07Builder.ToList();
				_pool.Free(declaration07Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody07(tOpenBrace, declaration07, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration07(TestLangOneParser.Declaration07Context context)
			{
				if (context == null) return Declaration07Green.__Missing;
				TestLangOneParser.Vertex07Context vertex07Context = context.vertex07();
				if (vertex07Context != null) 
				{
					return this.factory.Declaration07((Vertex07Green)this.Visit(vertex07Context));
				}
				TestLangOneParser.Arrow07Context arrow07Context = context.arrow07();
				if (arrow07Context != null) 
				{
					return this.factory.Declaration07((Arrow07Green)this.Visit(arrow07Context));
				}
				return Declaration07Green.__Missing;
			}
			
			public override GreenNode VisitVertex07(TestLangOneParser.Vertex07Context context)
			{
				if (context == null) return Vertex07Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex07(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow07(TestLangOneParser.Arrow07Context context)
			{
				if (context == null) return Arrow07Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.Source07Context source07Context = context.source07();
				Source07Green source07 = null;
				if (source07Context != null)
				{
					source07 = (Source07Green)this.Visit(source07Context);
				}
				else
				{
					source07 = Source07Green.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.Target07Context target07Context = context.target07();
				Target07Green target07 = null;
				if (target07Context != null)
				{
					target07 = (Target07Green)this.Visit(target07Context);
				}
				else
				{
					target07 = Target07Green.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow07(kArrow, source07, tArrow, target07, tSemicolon);
			}
			
			public override GreenNode VisitSource07(TestLangOneParser.Source07Context context)
			{
				if (context == null) return Source07Green.__Missing;
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return this.factory.Source07(name);
			}
			
			public override GreenNode VisitTarget07(TestLangOneParser.Target07Context context)
			{
				if (context == null) return Target07Green.__Missing;
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return this.factory.Target07(name);
			}
			
			public override GreenNode VisitTest08(TestLangOneParser.Test08Context context)
			{
				if (context == null) return Test08Green.__Missing;
				InternalSyntaxToken kTest08 = (InternalSyntaxToken)this.VisitTerminal(context.KTest08(), TestLangOneSyntaxKind.KTest08);
				TestLangOneParser.NamespaceDeclaration08Context namespaceDeclaration08Context = context.namespaceDeclaration08();
				NamespaceDeclaration08Green namespaceDeclaration08 = null;
				if (namespaceDeclaration08Context != null)
				{
					namespaceDeclaration08 = (NamespaceDeclaration08Green)this.Visit(namespaceDeclaration08Context);
				}
				else
				{
					namespaceDeclaration08 = NamespaceDeclaration08Green.__Missing;
				}
				return this.factory.Test08(kTest08, namespaceDeclaration08);
			}
			
			public override GreenNode VisitNamespaceDeclaration08(TestLangOneParser.NamespaceDeclaration08Context context)
			{
				if (context == null) return NamespaceDeclaration08Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody08Context namespaceBody08Context = context.namespaceBody08();
				NamespaceBody08Green namespaceBody08 = null;
				if (namespaceBody08Context != null)
				{
					namespaceBody08 = (NamespaceBody08Green)this.Visit(namespaceBody08Context);
				}
				else
				{
					namespaceBody08 = NamespaceBody08Green.__Missing;
				}
				return this.factory.NamespaceDeclaration08(kNamespace, qualifiedName, namespaceBody08);
			}
			
			public override GreenNode VisitNamespaceBody08(TestLangOneParser.NamespaceBody08Context context)
			{
				if (context == null) return NamespaceBody08Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration08Context[] declaration08Context = context.declaration08();
			    var declaration08Builder = _pool.Allocate<Declaration08Green>();
			    for (int i = 0; i < declaration08Context.Length; i++)
			    {
			        declaration08Builder.Add((Declaration08Green)this.Visit(declaration08Context[i]));
			    }
				var declaration08 = declaration08Builder.ToList();
				_pool.Free(declaration08Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody08(tOpenBrace, declaration08, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration08(TestLangOneParser.Declaration08Context context)
			{
				if (context == null) return Declaration08Green.__Missing;
				TestLangOneParser.Vertex08Context vertex08Context = context.vertex08();
				if (vertex08Context != null) 
				{
					return this.factory.Declaration08((Vertex08Green)this.Visit(vertex08Context));
				}
				TestLangOneParser.Arrow08Context arrow08Context = context.arrow08();
				if (arrow08Context != null) 
				{
					return this.factory.Declaration08((Arrow08Green)this.Visit(arrow08Context));
				}
				return Declaration08Green.__Missing;
			}
			
			public override GreenNode VisitVertex08(TestLangOneParser.Vertex08Context context)
			{
				if (context == null) return Vertex08Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex08(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow08(TestLangOneParser.Arrow08Context context)
			{
				if (context == null) return Arrow08Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.Source08Context source08Context = context.source08();
				Source08Green source08 = null;
				if (source08Context != null)
				{
					source08 = (Source08Green)this.Visit(source08Context);
				}
				else
				{
					source08 = Source08Green.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.Target08Context target08Context = context.target08();
				Target08Green target08 = null;
				if (target08Context != null)
				{
					target08 = (Target08Green)this.Visit(target08Context);
				}
				else
				{
					target08 = Target08Green.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow08(kArrow, source08, tArrow, target08, tSemicolon);
			}
			
			public override GreenNode VisitSource08(TestLangOneParser.Source08Context context)
			{
				if (context == null) return Source08Green.__Missing;
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return this.factory.Source08(name);
			}
			
			public override GreenNode VisitTarget08(TestLangOneParser.Target08Context context)
			{
				if (context == null) return Target08Green.__Missing;
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return this.factory.Target08(name);
			}
			
			public override GreenNode VisitTest09(TestLangOneParser.Test09Context context)
			{
				if (context == null) return Test09Green.__Missing;
				InternalSyntaxToken kTest09 = (InternalSyntaxToken)this.VisitTerminal(context.KTest09(), TestLangOneSyntaxKind.KTest09);
				TestLangOneParser.NamespaceDeclaration09Context namespaceDeclaration09Context = context.namespaceDeclaration09();
				NamespaceDeclaration09Green namespaceDeclaration09 = null;
				if (namespaceDeclaration09Context != null)
				{
					namespaceDeclaration09 = (NamespaceDeclaration09Green)this.Visit(namespaceDeclaration09Context);
				}
				else
				{
					namespaceDeclaration09 = NamespaceDeclaration09Green.__Missing;
				}
				return this.factory.Test09(kTest09, namespaceDeclaration09);
			}
			
			public override GreenNode VisitNamespaceDeclaration09(TestLangOneParser.NamespaceDeclaration09Context context)
			{
				if (context == null) return NamespaceDeclaration09Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody09Context namespaceBody09Context = context.namespaceBody09();
				NamespaceBody09Green namespaceBody09 = null;
				if (namespaceBody09Context != null)
				{
					namespaceBody09 = (NamespaceBody09Green)this.Visit(namespaceBody09Context);
				}
				else
				{
					namespaceBody09 = NamespaceBody09Green.__Missing;
				}
				return this.factory.NamespaceDeclaration09(kNamespace, qualifiedName, namespaceBody09);
			}
			
			public override GreenNode VisitNamespaceBody09(TestLangOneParser.NamespaceBody09Context context)
			{
				if (context == null) return NamespaceBody09Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration09Context[] declaration09Context = context.declaration09();
			    var declaration09Builder = _pool.Allocate<Declaration09Green>();
			    for (int i = 0; i < declaration09Context.Length; i++)
			    {
			        declaration09Builder.Add((Declaration09Green)this.Visit(declaration09Context[i]));
			    }
				var declaration09 = declaration09Builder.ToList();
				_pool.Free(declaration09Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody09(tOpenBrace, declaration09, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration09(TestLangOneParser.Declaration09Context context)
			{
				if (context == null) return Declaration09Green.__Missing;
				TestLangOneParser.Vertex09Context vertex09Context = context.vertex09();
				if (vertex09Context != null) 
				{
					return this.factory.Declaration09((Vertex09Green)this.Visit(vertex09Context));
				}
				TestLangOneParser.Arrow09Context arrow09Context = context.arrow09();
				if (arrow09Context != null) 
				{
					return this.factory.Declaration09((Arrow09Green)this.Visit(arrow09Context));
				}
				return Declaration09Green.__Missing;
			}
			
			public override GreenNode VisitVertex09(TestLangOneParser.Vertex09Context context)
			{
				if (context == null) return Vertex09Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex09(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow09(TestLangOneParser.Arrow09Context context)
			{
				if (context == null) return Arrow09Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.NameContext sourceContext = context.source;
				NameGreen source = null;
				if (sourceContext != null)
				{
					source = (NameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = NameGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.NameContext targetContext = context.target;
				NameGreen target = null;
				if (targetContext != null)
				{
					target = (NameGreen)this.Visit(targetContext);
				}
				else
				{
					target = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow09(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest10(TestLangOneParser.Test10Context context)
			{
				if (context == null) return Test10Green.__Missing;
				InternalSyntaxToken kTest10 = (InternalSyntaxToken)this.VisitTerminal(context.KTest10(), TestLangOneSyntaxKind.KTest10);
				TestLangOneParser.NamespaceDeclaration10Context namespaceDeclaration10Context = context.namespaceDeclaration10();
				NamespaceDeclaration10Green namespaceDeclaration10 = null;
				if (namespaceDeclaration10Context != null)
				{
					namespaceDeclaration10 = (NamespaceDeclaration10Green)this.Visit(namespaceDeclaration10Context);
				}
				else
				{
					namespaceDeclaration10 = NamespaceDeclaration10Green.__Missing;
				}
				return this.factory.Test10(kTest10, namespaceDeclaration10);
			}
			
			public override GreenNode VisitNamespaceDeclaration10(TestLangOneParser.NamespaceDeclaration10Context context)
			{
				if (context == null) return NamespaceDeclaration10Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody10Context namespaceBody10Context = context.namespaceBody10();
				NamespaceBody10Green namespaceBody10 = null;
				if (namespaceBody10Context != null)
				{
					namespaceBody10 = (NamespaceBody10Green)this.Visit(namespaceBody10Context);
				}
				else
				{
					namespaceBody10 = NamespaceBody10Green.__Missing;
				}
				return this.factory.NamespaceDeclaration10(kNamespace, qualifiedName, namespaceBody10);
			}
			
			public override GreenNode VisitNamespaceBody10(TestLangOneParser.NamespaceBody10Context context)
			{
				if (context == null) return NamespaceBody10Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration10Context[] declaration10Context = context.declaration10();
			    var declaration10Builder = _pool.Allocate<Declaration10Green>();
			    for (int i = 0; i < declaration10Context.Length; i++)
			    {
			        declaration10Builder.Add((Declaration10Green)this.Visit(declaration10Context[i]));
			    }
				var declaration10 = declaration10Builder.ToList();
				_pool.Free(declaration10Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody10(tOpenBrace, declaration10, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration10(TestLangOneParser.Declaration10Context context)
			{
				if (context == null) return Declaration10Green.__Missing;
				TestLangOneParser.Vertex10Context vertex10Context = context.vertex10();
				if (vertex10Context != null) 
				{
					return this.factory.Declaration10((Vertex10Green)this.Visit(vertex10Context));
				}
				TestLangOneParser.Arrow10Context arrow10Context = context.arrow10();
				if (arrow10Context != null) 
				{
					return this.factory.Declaration10((Arrow10Green)this.Visit(arrow10Context));
				}
				return Declaration10Green.__Missing;
			}
			
			public override GreenNode VisitVertex10(TestLangOneParser.Vertex10Context context)
			{
				if (context == null) return Vertex10Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex10(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow10(TestLangOneParser.Arrow10Context context)
			{
				if (context == null) return Arrow10Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.NameContext sourceContext = context.source;
				NameGreen source = null;
				if (sourceContext != null)
				{
					source = (NameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = NameGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.NameContext targetContext = context.target;
				NameGreen target = null;
				if (targetContext != null)
				{
					target = (NameGreen)this.Visit(targetContext);
				}
				else
				{
					target = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow10(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest11(TestLangOneParser.Test11Context context)
			{
				if (context == null) return Test11Green.__Missing;
				InternalSyntaxToken kTest11 = (InternalSyntaxToken)this.VisitTerminal(context.KTest11(), TestLangOneSyntaxKind.KTest11);
			    TestLangOneParser.NamespaceDeclaration11Context[] namespaceDeclaration11Context = context.namespaceDeclaration11();
			    var namespaceDeclaration11Builder = _pool.Allocate<NamespaceDeclaration11Green>();
			    for (int i = 0; i < namespaceDeclaration11Context.Length; i++)
			    {
			        namespaceDeclaration11Builder.Add((NamespaceDeclaration11Green)this.Visit(namespaceDeclaration11Context[i]));
			    }
				var namespaceDeclaration11 = namespaceDeclaration11Builder.ToList();
				_pool.Free(namespaceDeclaration11Builder);
				return this.factory.Test11(kTest11, namespaceDeclaration11);
			}
			
			public override GreenNode VisitNamespaceDeclaration11(TestLangOneParser.NamespaceDeclaration11Context context)
			{
				if (context == null) return NamespaceDeclaration11Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody11Context namespaceBody11Context = context.namespaceBody11();
				NamespaceBody11Green namespaceBody11 = null;
				if (namespaceBody11Context != null)
				{
					namespaceBody11 = (NamespaceBody11Green)this.Visit(namespaceBody11Context);
				}
				else
				{
					namespaceBody11 = NamespaceBody11Green.__Missing;
				}
				return this.factory.NamespaceDeclaration11(kNamespace, qualifiedName, namespaceBody11);
			}
			
			public override GreenNode VisitNamespaceBody11(TestLangOneParser.NamespaceBody11Context context)
			{
				if (context == null) return NamespaceBody11Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration11Context[] declaration11Context = context.declaration11();
			    var declaration11Builder = _pool.Allocate<Declaration11Green>();
			    for (int i = 0; i < declaration11Context.Length; i++)
			    {
			        declaration11Builder.Add((Declaration11Green)this.Visit(declaration11Context[i]));
			    }
				var declaration11 = declaration11Builder.ToList();
				_pool.Free(declaration11Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody11(tOpenBrace, declaration11, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration11(TestLangOneParser.Declaration11Context context)
			{
				if (context == null) return Declaration11Green.__Missing;
				TestLangOneParser.Vertex11Context vertex11Context = context.vertex11();
				if (vertex11Context != null) 
				{
					return this.factory.Declaration11((Vertex11Green)this.Visit(vertex11Context));
				}
				TestLangOneParser.Arrow11Context arrow11Context = context.arrow11();
				if (arrow11Context != null) 
				{
					return this.factory.Declaration11((Arrow11Green)this.Visit(arrow11Context));
				}
				return Declaration11Green.__Missing;
			}
			
			public override GreenNode VisitVertex11(TestLangOneParser.Vertex11Context context)
			{
				if (context == null) return Vertex11Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Vertex11(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow11(TestLangOneParser.Arrow11Context context)
			{
				if (context == null) return Arrow11Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.QualifiedNameContext sourceContext = context.source;
				QualifiedNameGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifiedNameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = QualifiedNameGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.QualifiedNameContext targetContext = context.target;
				QualifiedNameGreen target = null;
				if (targetContext != null)
				{
					target = (QualifiedNameGreen)this.Visit(targetContext);
				}
				else
				{
					target = QualifiedNameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return this.factory.Arrow11(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitName(TestLangOneParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				TestLangOneParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				else
				{
					identifier = IdentifierGreen.__Missing;
				}
				return this.factory.Name(identifier);
			}
			
			public override GreenNode VisitQualifiedName(TestLangOneParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return this.factory.QualifiedName(qualifier);
			}
			
			public override GreenNode VisitQualifier(TestLangOneParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    TestLangOneParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], TestLangOneSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return this.factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitIdentifier(TestLangOneParser.IdentifierContext context)
			{
				if (context == null) return IdentifierGreen.__Missing;
				InternalSyntaxToken identifier = null;
				if (context.IdentifierNormal() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierNormal());
				}
				else 	if (context.IdentifierVerbatim() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierVerbatim());
				}
				else 	if (context.IUri() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IUri());
				}
				else
				{
					identifier = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.Identifier(identifier);
			}
			
			public override GreenNode VisitLiteral(TestLangOneParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				TestLangOneParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return this.factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				TestLangOneParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return this.factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				TestLangOneParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return this.factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				TestLangOneParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return this.factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				TestLangOneParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return this.factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				TestLangOneParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return this.factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(TestLangOneParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), TestLangOneSyntaxKind.KNull);
				return this.factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(TestLangOneParser.BooleanLiteralContext context)
			{
				if (context == null) return BooleanLiteralGreen.__Missing;
				InternalSyntaxToken booleanLiteral = null;
				if (context.KTrue() != null)
				{
					booleanLiteral = (InternalSyntaxToken)this.VisitTerminal(context.KTrue());
				}
				else 	if (context.KFalse() != null)
				{
					booleanLiteral = (InternalSyntaxToken)this.VisitTerminal(context.KFalse());
				}
				else
				{
					booleanLiteral = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.BooleanLiteral(booleanLiteral);
			}
			
			public override GreenNode VisitIntegerLiteral(TestLangOneParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), TestLangOneSyntaxKind.LInteger);
				return this.factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(TestLangOneParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), TestLangOneSyntaxKind.LDecimal);
				return this.factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(TestLangOneParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), TestLangOneSyntaxKind.LScientific);
				return this.factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(TestLangOneParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken lRegularString = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString(), TestLangOneSyntaxKind.LRegularString);
				return this.factory.StringLiteral(lRegularString);
			}
        }
    }
}

