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
using MetaDslx.Languages.Antlr4Roslyn.Parser;
namespace MetaDslx.Languages.Soal.Syntax.InternalSyntax
{
    public class SoalSyntaxParser : Antlr4SyntaxParser<SoalLexer, SoalParser>
    {
        public SoalSyntaxParser(
            SourceText text,
            SoalParseOptions options,
            SyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
            : base(text, SoalLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }
        public override DirectiveStack Directives
        {
            get
            {
                return DirectiveStack.Empty;
            }
        }
        protected override SoalLexer CreateLexer(AntlrInputStream inputStream)
        {
            return new SoalLexer(inputStream);
        }
        protected override SoalParser CreateParser(CommonTokenStream tokenStream)
        {
            return new SoalParser(tokenStream);
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
        private class Antlr4ToRoslynVisitor : SoalParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.            private SoalLanguage language;
			private SoalInternalSyntaxFactory factory;
            private SoalSyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastTokenOrTrivia;
            public Antlr4ToRoslynVisitor(SoalSyntaxParser syntaxParser)
            {
				this.factory = (SoalInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                this.syntaxParser = syntaxParser;
				this.tokens = this.syntaxParser.CommonTokenStream.GetTokens();
                this.lastTokenOrTrivia = null;
            }
            private GreenNode VisitTerminal(ITerminalNode node, SoalSyntaxKind kind)
            {
                return this.syntaxParser.VisitTerminal(node, kind, ref this.lastTokenOrTrivia);
            }
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                return this.VisitTerminal(node, null);
            }
			
			public override GreenNode VisitMain(SoalParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
			    SoalParser.NamespaceDeclarationContext[] namespaceDeclarationContext = context.namespaceDeclaration();
			    var namespaceDeclarationBuilder = _pool.Allocate<NamespaceDeclarationGreen>();
			    for (int i = 0; i < namespaceDeclarationContext.Length; i++)
			    {
			        namespaceDeclarationBuilder.Add((NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext[i]));
			    }
				var namespaceDeclaration = namespaceDeclarationBuilder.ToList();
				_pool.Free(namespaceDeclarationBuilder);
				InternalSyntaxToken eof = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), SoalSyntaxKind.Eof);
				return this.factory.Main(namespaceDeclaration, eof);
			}
			
			public override GreenNode VisitName(SoalParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				SoalParser.IdentifierContext identifierContext = context.identifier();
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
			
			public override GreenNode VisitQualifiedName(SoalParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
				SoalParser.QualifierContext qualifierContext = context.qualifier();
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
			
			public override GreenNode VisitQualifier(SoalParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    SoalParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], SoalSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return this.factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitIdentifierList(SoalParser.IdentifierListContext context)
			{
				if (context == null) return IdentifierListGreen.__Missing;
			    SoalParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], SoalSyntaxKind.TComma));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return this.factory.IdentifierList(identifier);
			}
			
			public override GreenNode VisitQualifierList(SoalParser.QualifierListContext context)
			{
				if (context == null) return QualifierListGreen.__Missing;
			    SoalParser.QualifierContext[] qualifierContext = context.qualifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var qualifierBuilder = _pool.AllocateSeparated<QualifierGreen>();
			    for (int i = 0; i < qualifierContext.Length; i++)
			    {
			        qualifierBuilder.Add((QualifierGreen)this.Visit(qualifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            qualifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], SoalSyntaxKind.TComma));
			        }
			    }
				var qualifier = qualifierBuilder.ToList();
				_pool.Free(qualifierBuilder);
				return this.factory.QualifierList(qualifier);
			}
			
			public override GreenNode VisitAnnotationList(SoalParser.AnnotationListContext context)
			{
				if (context == null) return AnnotationListGreen.__Missing;
			    SoalParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				return this.factory.AnnotationList(annotation);
			}
			
			public override GreenNode VisitReturnAnnotationList(SoalParser.ReturnAnnotationListContext context)
			{
				if (context == null) return ReturnAnnotationListGreen.__Missing;
			    SoalParser.ReturnAnnotationContext[] returnAnnotationContext = context.returnAnnotation();
			    var returnAnnotationBuilder = _pool.Allocate<ReturnAnnotationGreen>();
			    for (int i = 0; i < returnAnnotationContext.Length; i++)
			    {
			        returnAnnotationBuilder.Add((ReturnAnnotationGreen)this.Visit(returnAnnotationContext[i]));
			    }
				var returnAnnotation = returnAnnotationBuilder.ToList();
				_pool.Free(returnAnnotationBuilder);
				return this.factory.ReturnAnnotationList(returnAnnotation);
			}
			
			public override GreenNode VisitAnnotation(SoalParser.AnnotationContext context)
			{
				if (context == null) return AnnotationGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), SoalSyntaxKind.TOpenBracket);
				SoalParser.AnnotationHeadContext annotationHeadContext = context.annotationHead();
				AnnotationHeadGreen annotationHead = null;
				if (annotationHeadContext != null)
				{
					annotationHead = (AnnotationHeadGreen)this.Visit(annotationHeadContext);
				}
				else
				{
					annotationHead = AnnotationHeadGreen.__Missing;
				}
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), SoalSyntaxKind.TCloseBracket);
				return this.factory.Annotation(tOpenBracket, annotationHead, tCloseBracket);
			}
			
			public override GreenNode VisitReturnAnnotation(SoalParser.ReturnAnnotationContext context)
			{
				if (context == null) return ReturnAnnotationGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), SoalSyntaxKind.TOpenBracket);
				InternalSyntaxToken kReturn = (InternalSyntaxToken)this.VisitTerminal(context.KReturn(), SoalSyntaxKind.KReturn);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), SoalSyntaxKind.TColon);
				SoalParser.AnnotationHeadContext annotationHeadContext = context.annotationHead();
				AnnotationHeadGreen annotationHead = null;
				if (annotationHeadContext != null)
				{
					annotationHead = (AnnotationHeadGreen)this.Visit(annotationHeadContext);
				}
				else
				{
					annotationHead = AnnotationHeadGreen.__Missing;
				}
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), SoalSyntaxKind.TCloseBracket);
				return this.factory.ReturnAnnotation(tOpenBracket, kReturn, tColon, annotationHead, tCloseBracket);
			}
			
			public override GreenNode VisitAnnotationHead(SoalParser.AnnotationHeadContext context)
			{
				if (context == null) return AnnotationHeadGreen.__Missing;
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				SoalParser.AnnotationBodyContext annotationBodyContext = context.annotationBody();
				AnnotationBodyGreen annotationBody = null;
				if (annotationBodyContext != null)
				{
					annotationBody = (AnnotationBodyGreen)this.Visit(annotationBodyContext);
				}
				else
				{
					annotationBody = AnnotationBodyGreen.__Missing;
				}
				return this.factory.AnnotationHead(name, annotationBody);
			}
			
			public override GreenNode VisitAnnotationBody(SoalParser.AnnotationBodyContext context)
			{
				if (context == null) return AnnotationBodyGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), SoalSyntaxKind.TOpenParen);
				SoalParser.AnnotationPropertyListContext annotationPropertyListContext = context.annotationPropertyList();
				AnnotationPropertyListGreen annotationPropertyList = null;
				if (annotationPropertyListContext != null)
				{
					annotationPropertyList = (AnnotationPropertyListGreen)this.Visit(annotationPropertyListContext);
				}
				else
				{
					annotationPropertyList = AnnotationPropertyListGreen.__Missing;
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), SoalSyntaxKind.TCloseParen);
				return this.factory.AnnotationBody(tOpenParen, annotationPropertyList, tCloseParen);
			}
			
			public override GreenNode VisitAnnotationPropertyList(SoalParser.AnnotationPropertyListContext context)
			{
				if (context == null) return AnnotationPropertyListGreen.__Missing;
			    SoalParser.AnnotationPropertyContext[] annotationPropertyContext = context.annotationProperty();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var annotationPropertyBuilder = _pool.AllocateSeparated<AnnotationPropertyGreen>();
			    for (int i = 0; i < annotationPropertyContext.Length; i++)
			    {
			        annotationPropertyBuilder.Add((AnnotationPropertyGreen)this.Visit(annotationPropertyContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            annotationPropertyBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], SoalSyntaxKind.TComma));
			        }
			    }
				var annotationProperty = annotationPropertyBuilder.ToList();
				_pool.Free(annotationPropertyBuilder);
				return this.factory.AnnotationPropertyList(annotationProperty);
			}
			
			public override GreenNode VisitAnnotationProperty(SoalParser.AnnotationPropertyContext context)
			{
				if (context == null) return AnnotationPropertyGreen.__Missing;
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), SoalSyntaxKind.TAssign);
				SoalParser.AnnotationPropertyValueContext annotationPropertyValueContext = context.annotationPropertyValue();
				AnnotationPropertyValueGreen annotationPropertyValue = null;
				if (annotationPropertyValueContext != null)
				{
					annotationPropertyValue = (AnnotationPropertyValueGreen)this.Visit(annotationPropertyValueContext);
				}
				else
				{
					annotationPropertyValue = AnnotationPropertyValueGreen.__Missing;
				}
				return this.factory.AnnotationProperty(name, tAssign, annotationPropertyValue);
			}
			
			public override GreenNode VisitAnnotationPropertyValue(SoalParser.AnnotationPropertyValueContext context)
			{
				if (context == null) return AnnotationPropertyValueGreen.__Missing;
				SoalParser.ConstantValueContext constantValueContext = context.constantValue();
				if (constantValueContext != null) 
				{
					return this.factory.AnnotationPropertyValue((ConstantValueGreen)this.Visit(constantValueContext));
				}
				SoalParser.TypeofValueContext typeofValueContext = context.typeofValue();
				if (typeofValueContext != null) 
				{
					return this.factory.AnnotationPropertyValue((TypeofValueGreen)this.Visit(typeofValueContext));
				}
				return AnnotationPropertyValueGreen.__Missing;
			}
			
			public override GreenNode VisitNamespaceDeclaration(SoalParser.NamespaceDeclarationContext context)
			{
				if (context == null) return NamespaceDeclarationGreen.__Missing;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				else
				{
					annotationList = AnnotationListGreen.__Missing;
				}
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), SoalSyntaxKind.KNamespace);
				SoalParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), SoalSyntaxKind.TAssign);
				SoalParser.NamespacePrefixContext namespacePrefixContext = context.namespacePrefix();
				NamespacePrefixGreen namespacePrefix = null;
				if (namespacePrefixContext != null)
				{
					namespacePrefix = (NamespacePrefixGreen)this.Visit(namespacePrefixContext);
				}
				else
				{
					namespacePrefix = NamespacePrefixGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.NamespaceUriContext namespaceUriContext = context.namespaceUri();
				NamespaceUriGreen namespaceUri = null;
				if (namespaceUriContext != null)
				{
					namespaceUri = (NamespaceUriGreen)this.Visit(namespaceUriContext);
				}
				else
				{
					namespaceUri = NamespaceUriGreen.__Missing;
				}
				SoalParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null)
				{
					namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				}
				else
				{
					namespaceBody = NamespaceBodyGreen.__Missing;
				}
				return this.factory.NamespaceDeclaration(annotationList, kNamespace, qualifiedName, tAssign, namespacePrefix, tColon, namespaceUri, namespaceBody);
			}
			
			public override GreenNode VisitNamespacePrefix(SoalParser.NamespacePrefixContext context)
			{
				if (context == null) return NamespacePrefixGreen.__Missing;
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				else
				{
					identifier = IdentifierGreen.__Missing;
				}
				return this.factory.NamespacePrefix(identifier);
			}
			
			public override GreenNode VisitNamespaceUri(SoalParser.NamespaceUriContext context)
			{
				if (context == null) return NamespaceUriGreen.__Missing;
				SoalParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null)
				{
					stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				}
				else
				{
					stringLiteral = StringLiteralGreen.__Missing;
				}
				return this.factory.NamespaceUri(stringLiteral);
			}
			
			public override GreenNode VisitNamespaceBody(SoalParser.NamespaceBodyContext context)
			{
				if (context == null) return NamespaceBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
			    SoalParser.DeclarationContext[] declarationContext = context.declaration();
			    var declarationBuilder = _pool.Allocate<DeclarationGreen>();
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				var declaration = declarationBuilder.ToList();
				_pool.Free(declarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody(tOpenBrace, declaration, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration(SoalParser.DeclarationContext context)
			{
				if (context == null) return DeclarationGreen.__Missing;
				SoalParser.EnumDeclarationContext enumDeclarationContext = context.enumDeclaration();
				if (enumDeclarationContext != null) 
				{
					return this.factory.Declaration((EnumDeclarationGreen)this.Visit(enumDeclarationContext));
				}
				SoalParser.StructDeclarationContext structDeclarationContext = context.structDeclaration();
				if (structDeclarationContext != null) 
				{
					return this.factory.Declaration((StructDeclarationGreen)this.Visit(structDeclarationContext));
				}
				SoalParser.DatabaseDeclarationContext databaseDeclarationContext = context.databaseDeclaration();
				if (databaseDeclarationContext != null) 
				{
					return this.factory.Declaration((DatabaseDeclarationGreen)this.Visit(databaseDeclarationContext));
				}
				SoalParser.InterfaceDeclarationContext interfaceDeclarationContext = context.interfaceDeclaration();
				if (interfaceDeclarationContext != null) 
				{
					return this.factory.Declaration((InterfaceDeclarationGreen)this.Visit(interfaceDeclarationContext));
				}
				SoalParser.ComponentDeclarationContext componentDeclarationContext = context.componentDeclaration();
				if (componentDeclarationContext != null) 
				{
					return this.factory.Declaration((ComponentDeclarationGreen)this.Visit(componentDeclarationContext));
				}
				SoalParser.CompositeDeclarationContext compositeDeclarationContext = context.compositeDeclaration();
				if (compositeDeclarationContext != null) 
				{
					return this.factory.Declaration((CompositeDeclarationGreen)this.Visit(compositeDeclarationContext));
				}
				SoalParser.AssemblyDeclarationContext assemblyDeclarationContext = context.assemblyDeclaration();
				if (assemblyDeclarationContext != null) 
				{
					return this.factory.Declaration((AssemblyDeclarationGreen)this.Visit(assemblyDeclarationContext));
				}
				SoalParser.BindingDeclarationContext bindingDeclarationContext = context.bindingDeclaration();
				if (bindingDeclarationContext != null) 
				{
					return this.factory.Declaration((BindingDeclarationGreen)this.Visit(bindingDeclarationContext));
				}
				SoalParser.EndpointDeclarationContext endpointDeclarationContext = context.endpointDeclaration();
				if (endpointDeclarationContext != null) 
				{
					return this.factory.Declaration((EndpointDeclarationGreen)this.Visit(endpointDeclarationContext));
				}
				SoalParser.DeploymentDeclarationContext deploymentDeclarationContext = context.deploymentDeclaration();
				if (deploymentDeclarationContext != null) 
				{
					return this.factory.Declaration((DeploymentDeclarationGreen)this.Visit(deploymentDeclarationContext));
				}
				return DeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitEnumDeclaration(SoalParser.EnumDeclarationContext context)
			{
				if (context == null) return EnumDeclarationGreen.__Missing;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				else
				{
					annotationList = AnnotationListGreen.__Missing;
				}
				InternalSyntaxToken kEnum = (InternalSyntaxToken)this.VisitTerminal(context.KEnum(), SoalSyntaxKind.KEnum);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				SoalParser.EnumBodyContext enumBodyContext = context.enumBody();
				EnumBodyGreen enumBody = null;
				if (enumBodyContext != null)
				{
					enumBody = (EnumBodyGreen)this.Visit(enumBodyContext);
				}
				else
				{
					enumBody = EnumBodyGreen.__Missing;
				}
				return this.factory.EnumDeclaration(annotationList, kEnum, name, tColon, qualifier, enumBody);
			}
			
			public override GreenNode VisitEnumBody(SoalParser.EnumBodyContext context)
			{
				if (context == null) return EnumBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				SoalParser.EnumLiteralsContext enumLiteralsContext = context.enumLiterals();
				EnumLiteralsGreen enumLiterals = null;
				if (enumLiteralsContext != null)
				{
					enumLiterals = (EnumLiteralsGreen)this.Visit(enumLiteralsContext);
				}
				else
				{
					enumLiterals = EnumLiteralsGreen.__Missing;
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.EnumBody(tOpenBrace, enumLiterals, tCloseBrace);
			}
			
			public override GreenNode VisitEnumLiterals(SoalParser.EnumLiteralsContext context)
			{
				if (context == null) return EnumLiteralsGreen.__Missing;
			    SoalParser.EnumLiteralContext[] enumLiteralContext = context.enumLiteral();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var enumLiteralBuilder = _pool.AllocateSeparated<EnumLiteralGreen>();
			    for (int i = 0; i < enumLiteralContext.Length; i++)
			    {
			        enumLiteralBuilder.Add((EnumLiteralGreen)this.Visit(enumLiteralContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            enumLiteralBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], SoalSyntaxKind.TComma));
			        }
			    }
				var enumLiteral = enumLiteralBuilder.ToList();
				_pool.Free(enumLiteralBuilder);
				return this.factory.EnumLiterals(enumLiteral);
			}
			
			public override GreenNode VisitEnumLiteral(SoalParser.EnumLiteralContext context)
			{
				if (context == null) return EnumLiteralGreen.__Missing;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				else
				{
					annotationList = AnnotationListGreen.__Missing;
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return this.factory.EnumLiteral(annotationList, name);
			}
			
			public override GreenNode VisitStructDeclaration(SoalParser.StructDeclarationContext context)
			{
				if (context == null) return StructDeclarationGreen.__Missing;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				else
				{
					annotationList = AnnotationListGreen.__Missing;
				}
				InternalSyntaxToken kStruct = (InternalSyntaxToken)this.VisitTerminal(context.KStruct(), SoalSyntaxKind.KStruct);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				SoalParser.StructBodyContext structBodyContext = context.structBody();
				StructBodyGreen structBody = null;
				if (structBodyContext != null)
				{
					structBody = (StructBodyGreen)this.Visit(structBodyContext);
				}
				else
				{
					structBody = StructBodyGreen.__Missing;
				}
				return this.factory.StructDeclaration(annotationList, kStruct, name, tColon, qualifier, structBody);
			}
			
			public override GreenNode VisitStructBody(SoalParser.StructBodyContext context)
			{
				if (context == null) return StructBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
			    SoalParser.PropertyDeclarationContext[] propertyDeclarationContext = context.propertyDeclaration();
			    var propertyDeclarationBuilder = _pool.Allocate<PropertyDeclarationGreen>();
			    for (int i = 0; i < propertyDeclarationContext.Length; i++)
			    {
			        propertyDeclarationBuilder.Add((PropertyDeclarationGreen)this.Visit(propertyDeclarationContext[i]));
			    }
				var propertyDeclaration = propertyDeclarationBuilder.ToList();
				_pool.Free(propertyDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.StructBody(tOpenBrace, propertyDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitPropertyDeclaration(SoalParser.PropertyDeclarationContext context)
			{
				if (context == null) return PropertyDeclarationGreen.__Missing;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				else
				{
					annotationList = AnnotationListGreen.__Missing;
				}
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				else
				{
					typeReference = TypeReferenceGreen.__Missing;
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.PropertyDeclaration(annotationList, typeReference, name, tSemicolon);
			}
			
			public override GreenNode VisitDatabaseDeclaration(SoalParser.DatabaseDeclarationContext context)
			{
				if (context == null) return DatabaseDeclarationGreen.__Missing;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				else
				{
					annotationList = AnnotationListGreen.__Missing;
				}
				InternalSyntaxToken kDatabase = (InternalSyntaxToken)this.VisitTerminal(context.KDatabase(), SoalSyntaxKind.KDatabase);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				SoalParser.DatabaseBodyContext databaseBodyContext = context.databaseBody();
				DatabaseBodyGreen databaseBody = null;
				if (databaseBodyContext != null)
				{
					databaseBody = (DatabaseBodyGreen)this.Visit(databaseBodyContext);
				}
				else
				{
					databaseBody = DatabaseBodyGreen.__Missing;
				}
				return this.factory.DatabaseDeclaration(annotationList, kDatabase, name, databaseBody);
			}
			
			public override GreenNode VisitDatabaseBody(SoalParser.DatabaseBodyContext context)
			{
				if (context == null) return DatabaseBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
			    SoalParser.EntityReferenceContext[] entityReferenceContext = context.entityReference();
			    var entityReferenceBuilder = _pool.Allocate<EntityReferenceGreen>();
			    for (int i = 0; i < entityReferenceContext.Length; i++)
			    {
			        entityReferenceBuilder.Add((EntityReferenceGreen)this.Visit(entityReferenceContext[i]));
			    }
				var entityReference = entityReferenceBuilder.ToList();
				_pool.Free(entityReferenceBuilder);
			    SoalParser.OperationDeclarationContext[] operationDeclarationContext = context.operationDeclaration();
			    var operationDeclarationBuilder = _pool.Allocate<OperationDeclarationGreen>();
			    for (int i = 0; i < operationDeclarationContext.Length; i++)
			    {
			        operationDeclarationBuilder.Add((OperationDeclarationGreen)this.Visit(operationDeclarationContext[i]));
			    }
				var operationDeclaration = operationDeclarationBuilder.ToList();
				_pool.Free(operationDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.DatabaseBody(tOpenBrace, entityReference, operationDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitEntityReference(SoalParser.EntityReferenceContext context)
			{
				if (context == null) return EntityReferenceGreen.__Missing;
				InternalSyntaxToken kEntity = (InternalSyntaxToken)this.VisitTerminal(context.KEntity(), SoalSyntaxKind.KEntity);
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.EntityReference(kEntity, qualifier, tSemicolon);
			}
			
			public override GreenNode VisitInterfaceDeclaration(SoalParser.InterfaceDeclarationContext context)
			{
				if (context == null) return InterfaceDeclarationGreen.__Missing;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				else
				{
					annotationList = AnnotationListGreen.__Missing;
				}
				InternalSyntaxToken kInterface = (InternalSyntaxToken)this.VisitTerminal(context.KInterface(), SoalSyntaxKind.KInterface);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				SoalParser.InterfaceBodyContext interfaceBodyContext = context.interfaceBody();
				InterfaceBodyGreen interfaceBody = null;
				if (interfaceBodyContext != null)
				{
					interfaceBody = (InterfaceBodyGreen)this.Visit(interfaceBodyContext);
				}
				else
				{
					interfaceBody = InterfaceBodyGreen.__Missing;
				}
				return this.factory.InterfaceDeclaration(annotationList, kInterface, name, interfaceBody);
			}
			
			public override GreenNode VisitInterfaceBody(SoalParser.InterfaceBodyContext context)
			{
				if (context == null) return InterfaceBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
			    SoalParser.OperationDeclarationContext[] operationDeclarationContext = context.operationDeclaration();
			    var operationDeclarationBuilder = _pool.Allocate<OperationDeclarationGreen>();
			    for (int i = 0; i < operationDeclarationContext.Length; i++)
			    {
			        operationDeclarationBuilder.Add((OperationDeclarationGreen)this.Visit(operationDeclarationContext[i]));
			    }
				var operationDeclaration = operationDeclarationBuilder.ToList();
				_pool.Free(operationDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.InterfaceBody(tOpenBrace, operationDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitOperationDeclaration(SoalParser.OperationDeclarationContext context)
			{
				if (context == null) return OperationDeclarationGreen.__Missing;
				SoalParser.OperationHeadContext operationHeadContext = context.operationHead();
				OperationHeadGreen operationHead = null;
				if (operationHeadContext != null)
				{
					operationHead = (OperationHeadGreen)this.Visit(operationHeadContext);
				}
				else
				{
					operationHead = OperationHeadGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.OperationDeclaration(operationHead, tSemicolon);
			}
			
			public override GreenNode VisitOperationHead(SoalParser.OperationHeadContext context)
			{
				if (context == null) return OperationHeadGreen.__Missing;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				else
				{
					annotationList = AnnotationListGreen.__Missing;
				}
				SoalParser.OperationResultContext operationResultContext = context.operationResult();
				OperationResultGreen operationResult = null;
				if (operationResultContext != null)
				{
					operationResult = (OperationResultGreen)this.Visit(operationResultContext);
				}
				else
				{
					operationResult = OperationResultGreen.__Missing;
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), SoalSyntaxKind.TOpenParen);
				SoalParser.ParameterListContext parameterListContext = context.parameterList();
				ParameterListGreen parameterList = null;
				if (parameterListContext != null)
				{
					parameterList = (ParameterListGreen)this.Visit(parameterListContext);
				}
				else
				{
					parameterList = ParameterListGreen.__Missing;
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), SoalSyntaxKind.TCloseParen);
				SoalParser.ThrowsListContext throwsListContext = context.throwsList();
				ThrowsListGreen throwsList = null;
				if (throwsListContext != null)
				{
					throwsList = (ThrowsListGreen)this.Visit(throwsListContext);
				}
				else
				{
					throwsList = ThrowsListGreen.__Missing;
				}
				return this.factory.OperationHead(annotationList, operationResult, name, tOpenParen, parameterList, tCloseParen, throwsList);
			}
			
			public override GreenNode VisitParameterList(SoalParser.ParameterListContext context)
			{
				if (context == null) return ParameterListGreen.__Missing;
			    SoalParser.ParameterContext[] parameterContext = context.parameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var parameterBuilder = _pool.AllocateSeparated<ParameterGreen>();
			    for (int i = 0; i < parameterContext.Length; i++)
			    {
			        parameterBuilder.Add((ParameterGreen)this.Visit(parameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            parameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], SoalSyntaxKind.TComma));
			        }
			    }
				var parameter = parameterBuilder.ToList();
				_pool.Free(parameterBuilder);
				return this.factory.ParameterList(parameter);
			}
			
			public override GreenNode VisitParameter(SoalParser.ParameterContext context)
			{
				if (context == null) return ParameterGreen.__Missing;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				else
				{
					annotationList = AnnotationListGreen.__Missing;
				}
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				else
				{
					typeReference = TypeReferenceGreen.__Missing;
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return this.factory.Parameter(annotationList, typeReference, name);
			}
			
			public override GreenNode VisitOperationResult(SoalParser.OperationResultContext context)
			{
				if (context == null) return OperationResultGreen.__Missing;
				SoalParser.ReturnAnnotationListContext returnAnnotationListContext = context.returnAnnotationList();
				ReturnAnnotationListGreen returnAnnotationList = null;
				if (returnAnnotationListContext != null)
				{
					returnAnnotationList = (ReturnAnnotationListGreen)this.Visit(returnAnnotationListContext);
				}
				else
				{
					returnAnnotationList = ReturnAnnotationListGreen.__Missing;
				}
				SoalParser.OperationReturnTypeContext operationReturnTypeContext = context.operationReturnType();
				OperationReturnTypeGreen operationReturnType = null;
				if (operationReturnTypeContext != null)
				{
					operationReturnType = (OperationReturnTypeGreen)this.Visit(operationReturnTypeContext);
				}
				else
				{
					operationReturnType = OperationReturnTypeGreen.__Missing;
				}
				return this.factory.OperationResult(returnAnnotationList, operationReturnType);
			}
			
			public override GreenNode VisitThrowsList(SoalParser.ThrowsListContext context)
			{
				if (context == null) return ThrowsListGreen.__Missing;
				InternalSyntaxToken kThrows = (InternalSyntaxToken)this.VisitTerminal(context.KThrows(), SoalSyntaxKind.KThrows);
				SoalParser.QualifierListContext qualifierListContext = context.qualifierList();
				QualifierListGreen qualifierList = null;
				if (qualifierListContext != null)
				{
					qualifierList = (QualifierListGreen)this.Visit(qualifierListContext);
				}
				else
				{
					qualifierList = QualifierListGreen.__Missing;
				}
				return this.factory.ThrowsList(kThrows, qualifierList);
			}
			
			public override GreenNode VisitComponentDeclaration(SoalParser.ComponentDeclarationContext context)
			{
				if (context == null) return ComponentDeclarationGreen.__Missing;
				InternalSyntaxToken kAbstract = (InternalSyntaxToken)this.VisitTerminal(context.KAbstract());
				InternalSyntaxToken kComponent = (InternalSyntaxToken)this.VisitTerminal(context.KComponent(), SoalSyntaxKind.KComponent);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				SoalParser.ComponentBodyContext componentBodyContext = context.componentBody();
				ComponentBodyGreen componentBody = null;
				if (componentBodyContext != null)
				{
					componentBody = (ComponentBodyGreen)this.Visit(componentBodyContext);
				}
				else
				{
					componentBody = ComponentBodyGreen.__Missing;
				}
				return this.factory.ComponentDeclaration(kAbstract, kComponent, name, tColon, qualifier, componentBody);
			}
			
			public override GreenNode VisitComponentBody(SoalParser.ComponentBodyContext context)
			{
				if (context == null) return ComponentBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				SoalParser.ComponentElementsContext componentElementsContext = context.componentElements();
				ComponentElementsGreen componentElements = null;
				if (componentElementsContext != null)
				{
					componentElements = (ComponentElementsGreen)this.Visit(componentElementsContext);
				}
				else
				{
					componentElements = ComponentElementsGreen.__Missing;
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.ComponentBody(tOpenBrace, componentElements, tCloseBrace);
			}
			
			public override GreenNode VisitComponentElements(SoalParser.ComponentElementsContext context)
			{
				if (context == null) return ComponentElementsGreen.__Missing;
			    SoalParser.ComponentElementContext[] componentElementContext = context.componentElement();
			    var componentElementBuilder = _pool.Allocate<ComponentElementGreen>();
			    for (int i = 0; i < componentElementContext.Length; i++)
			    {
			        componentElementBuilder.Add((ComponentElementGreen)this.Visit(componentElementContext[i]));
			    }
				var componentElement = componentElementBuilder.ToList();
				_pool.Free(componentElementBuilder);
				return this.factory.ComponentElements(componentElement);
			}
			
			public override GreenNode VisitComponentElement(SoalParser.ComponentElementContext context)
			{
				if (context == null) return ComponentElementGreen.__Missing;
				SoalParser.ComponentServiceContext componentServiceContext = context.componentService();
				if (componentServiceContext != null) 
				{
					return this.factory.ComponentElement((ComponentServiceGreen)this.Visit(componentServiceContext));
				}
				SoalParser.ComponentReferenceContext componentReferenceContext = context.componentReference();
				if (componentReferenceContext != null) 
				{
					return this.factory.ComponentElement((ComponentReferenceGreen)this.Visit(componentReferenceContext));
				}
				SoalParser.ComponentPropertyContext componentPropertyContext = context.componentProperty();
				if (componentPropertyContext != null) 
				{
					return this.factory.ComponentElement((ComponentPropertyGreen)this.Visit(componentPropertyContext));
				}
				SoalParser.ComponentImplementationContext componentImplementationContext = context.componentImplementation();
				if (componentImplementationContext != null) 
				{
					return this.factory.ComponentElement((ComponentImplementationGreen)this.Visit(componentImplementationContext));
				}
				SoalParser.ComponentLanguageContext componentLanguageContext = context.componentLanguage();
				if (componentLanguageContext != null) 
				{
					return this.factory.ComponentElement((ComponentLanguageGreen)this.Visit(componentLanguageContext));
				}
				return ComponentElementGreen.__Missing;
			}
			
			public override GreenNode VisitComponentService(SoalParser.ComponentServiceContext context)
			{
				if (context == null) return ComponentServiceGreen.__Missing;
				InternalSyntaxToken kService = (InternalSyntaxToken)this.VisitTerminal(context.KService(), SoalSyntaxKind.KService);
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				SoalParser.ComponentServiceOrReferenceBodyContext componentServiceOrReferenceBodyContext = context.componentServiceOrReferenceBody();
				ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody = null;
				if (componentServiceOrReferenceBodyContext != null)
				{
					componentServiceOrReferenceBody = (ComponentServiceOrReferenceBodyGreen)this.Visit(componentServiceOrReferenceBodyContext);
				}
				else
				{
					componentServiceOrReferenceBody = ComponentServiceOrReferenceBodyGreen.__Missing;
				}
				return this.factory.ComponentService(kService, qualifier, name, componentServiceOrReferenceBody);
			}
			
			public override GreenNode VisitComponentReference(SoalParser.ComponentReferenceContext context)
			{
				if (context == null) return ComponentReferenceGreen.__Missing;
				InternalSyntaxToken kReference = (InternalSyntaxToken)this.VisitTerminal(context.KReference(), SoalSyntaxKind.KReference);
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				SoalParser.ComponentServiceOrReferenceBodyContext componentServiceOrReferenceBodyContext = context.componentServiceOrReferenceBody();
				ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody = null;
				if (componentServiceOrReferenceBodyContext != null)
				{
					componentServiceOrReferenceBody = (ComponentServiceOrReferenceBodyGreen)this.Visit(componentServiceOrReferenceBodyContext);
				}
				else
				{
					componentServiceOrReferenceBody = ComponentServiceOrReferenceBodyGreen.__Missing;
				}
				return this.factory.ComponentReference(kReference, qualifier, name, componentServiceOrReferenceBody);
			}
			
			public override GreenNode VisitComponentServiceOrReferenceEmptyBody(SoalParser.ComponentServiceOrReferenceEmptyBodyContext context)
			{
				if (context == null) return ComponentServiceOrReferenceEmptyBodyGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.ComponentServiceOrReferenceEmptyBody(tSemicolon);
			}
			
			public override GreenNode VisitComponentServiceOrReferenceNonEmptyBody(SoalParser.ComponentServiceOrReferenceNonEmptyBodyContext context)
			{
				if (context == null) return ComponentServiceOrReferenceNonEmptyBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
			    SoalParser.ComponentServiceOrReferenceElementContext[] componentServiceOrReferenceElementContext = context.componentServiceOrReferenceElement();
			    var componentServiceOrReferenceElementBuilder = _pool.Allocate<ComponentServiceOrReferenceElementGreen>();
			    for (int i = 0; i < componentServiceOrReferenceElementContext.Length; i++)
			    {
			        componentServiceOrReferenceElementBuilder.Add((ComponentServiceOrReferenceElementGreen)this.Visit(componentServiceOrReferenceElementContext[i]));
			    }
				var componentServiceOrReferenceElement = componentServiceOrReferenceElementBuilder.ToList();
				_pool.Free(componentServiceOrReferenceElementBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.ComponentServiceOrReferenceNonEmptyBody(tOpenBrace, componentServiceOrReferenceElement, tCloseBrace);
			}
			
			public override GreenNode VisitComponentServiceOrReferenceElement(SoalParser.ComponentServiceOrReferenceElementContext context)
			{
				if (context == null) return ComponentServiceOrReferenceElementGreen.__Missing;
				InternalSyntaxToken kBinding = (InternalSyntaxToken)this.VisitTerminal(context.KBinding(), SoalSyntaxKind.KBinding);
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.ComponentServiceOrReferenceElement(kBinding, qualifier, tSemicolon);
			}
			
			public override GreenNode VisitComponentProperty(SoalParser.ComponentPropertyContext context)
			{
				if (context == null) return ComponentPropertyGreen.__Missing;
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				else
				{
					typeReference = TypeReferenceGreen.__Missing;
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.ComponentProperty(typeReference, name, tSemicolon);
			}
			
			public override GreenNode VisitComponentImplementation(SoalParser.ComponentImplementationContext context)
			{
				if (context == null) return ComponentImplementationGreen.__Missing;
				InternalSyntaxToken kImplementation = (InternalSyntaxToken)this.VisitTerminal(context.KImplementation(), SoalSyntaxKind.KImplementation);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.ComponentImplementation(kImplementation, name, tSemicolon);
			}
			
			public override GreenNode VisitComponentLanguage(SoalParser.ComponentLanguageContext context)
			{
				if (context == null) return ComponentLanguageGreen.__Missing;
				InternalSyntaxToken kLanguage = (InternalSyntaxToken)this.VisitTerminal(context.KLanguage(), SoalSyntaxKind.KLanguage);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.ComponentLanguage(kLanguage, name, tSemicolon);
			}
			
			public override GreenNode VisitCompositeDeclaration(SoalParser.CompositeDeclarationContext context)
			{
				if (context == null) return CompositeDeclarationGreen.__Missing;
				InternalSyntaxToken kComposite = (InternalSyntaxToken)this.VisitTerminal(context.KComposite(), SoalSyntaxKind.KComposite);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				SoalParser.CompositeBodyContext compositeBodyContext = context.compositeBody();
				CompositeBodyGreen compositeBody = null;
				if (compositeBodyContext != null)
				{
					compositeBody = (CompositeBodyGreen)this.Visit(compositeBodyContext);
				}
				else
				{
					compositeBody = CompositeBodyGreen.__Missing;
				}
				return this.factory.CompositeDeclaration(kComposite, name, tColon, qualifier, compositeBody);
			}
			
			public override GreenNode VisitCompositeBody(SoalParser.CompositeBodyContext context)
			{
				if (context == null) return CompositeBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				SoalParser.CompositeElementsContext compositeElementsContext = context.compositeElements();
				CompositeElementsGreen compositeElements = null;
				if (compositeElementsContext != null)
				{
					compositeElements = (CompositeElementsGreen)this.Visit(compositeElementsContext);
				}
				else
				{
					compositeElements = CompositeElementsGreen.__Missing;
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.CompositeBody(tOpenBrace, compositeElements, tCloseBrace);
			}
			
			public override GreenNode VisitAssemblyDeclaration(SoalParser.AssemblyDeclarationContext context)
			{
				if (context == null) return AssemblyDeclarationGreen.__Missing;
				InternalSyntaxToken kAssembly = (InternalSyntaxToken)this.VisitTerminal(context.KAssembly(), SoalSyntaxKind.KAssembly);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				SoalParser.CompositeBodyContext compositeBodyContext = context.compositeBody();
				CompositeBodyGreen compositeBody = null;
				if (compositeBodyContext != null)
				{
					compositeBody = (CompositeBodyGreen)this.Visit(compositeBodyContext);
				}
				else
				{
					compositeBody = CompositeBodyGreen.__Missing;
				}
				return this.factory.AssemblyDeclaration(kAssembly, name, tColon, qualifier, compositeBody);
			}
			
			public override GreenNode VisitCompositeElements(SoalParser.CompositeElementsContext context)
			{
				if (context == null) return CompositeElementsGreen.__Missing;
			    SoalParser.CompositeElementContext[] compositeElementContext = context.compositeElement();
			    var compositeElementBuilder = _pool.Allocate<CompositeElementGreen>();
			    for (int i = 0; i < compositeElementContext.Length; i++)
			    {
			        compositeElementBuilder.Add((CompositeElementGreen)this.Visit(compositeElementContext[i]));
			    }
				var compositeElement = compositeElementBuilder.ToList();
				_pool.Free(compositeElementBuilder);
				return this.factory.CompositeElements(compositeElement);
			}
			
			public override GreenNode VisitCompositeElement(SoalParser.CompositeElementContext context)
			{
				if (context == null) return CompositeElementGreen.__Missing;
				SoalParser.ComponentServiceContext componentServiceContext = context.componentService();
				if (componentServiceContext != null) 
				{
					return this.factory.CompositeElement((ComponentServiceGreen)this.Visit(componentServiceContext));
				}
				SoalParser.ComponentReferenceContext componentReferenceContext = context.componentReference();
				if (componentReferenceContext != null) 
				{
					return this.factory.CompositeElement((ComponentReferenceGreen)this.Visit(componentReferenceContext));
				}
				SoalParser.ComponentPropertyContext componentPropertyContext = context.componentProperty();
				if (componentPropertyContext != null) 
				{
					return this.factory.CompositeElement((ComponentPropertyGreen)this.Visit(componentPropertyContext));
				}
				SoalParser.ComponentImplementationContext componentImplementationContext = context.componentImplementation();
				if (componentImplementationContext != null) 
				{
					return this.factory.CompositeElement((ComponentImplementationGreen)this.Visit(componentImplementationContext));
				}
				SoalParser.ComponentLanguageContext componentLanguageContext = context.componentLanguage();
				if (componentLanguageContext != null) 
				{
					return this.factory.CompositeElement((ComponentLanguageGreen)this.Visit(componentLanguageContext));
				}
				SoalParser.CompositeComponentContext compositeComponentContext = context.compositeComponent();
				if (compositeComponentContext != null) 
				{
					return this.factory.CompositeElement((CompositeComponentGreen)this.Visit(compositeComponentContext));
				}
				SoalParser.CompositeWireContext compositeWireContext = context.compositeWire();
				if (compositeWireContext != null) 
				{
					return this.factory.CompositeElement((CompositeWireGreen)this.Visit(compositeWireContext));
				}
				return CompositeElementGreen.__Missing;
			}
			
			public override GreenNode VisitCompositeComponent(SoalParser.CompositeComponentContext context)
			{
				if (context == null) return CompositeComponentGreen.__Missing;
				InternalSyntaxToken kComponent = (InternalSyntaxToken)this.VisitTerminal(context.KComponent(), SoalSyntaxKind.KComponent);
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.CompositeComponent(kComponent, qualifier, tSemicolon);
			}
			
			public override GreenNode VisitCompositeWire(SoalParser.CompositeWireContext context)
			{
				if (context == null) return CompositeWireGreen.__Missing;
				InternalSyntaxToken kWire = (InternalSyntaxToken)this.VisitTerminal(context.KWire(), SoalSyntaxKind.KWire);
				SoalParser.WireSourceContext wireSourceContext = context.wireSource();
				WireSourceGreen wireSource = null;
				if (wireSourceContext != null)
				{
					wireSource = (WireSourceGreen)this.Visit(wireSourceContext);
				}
				else
				{
					wireSource = WireSourceGreen.__Missing;
				}
				InternalSyntaxToken kTo = (InternalSyntaxToken)this.VisitTerminal(context.KTo(), SoalSyntaxKind.KTo);
				SoalParser.WireTargetContext wireTargetContext = context.wireTarget();
				WireTargetGreen wireTarget = null;
				if (wireTargetContext != null)
				{
					wireTarget = (WireTargetGreen)this.Visit(wireTargetContext);
				}
				else
				{
					wireTarget = WireTargetGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.CompositeWire(kWire, wireSource, kTo, wireTarget, tSemicolon);
			}
			
			public override GreenNode VisitWireSource(SoalParser.WireSourceContext context)
			{
				if (context == null) return WireSourceGreen.__Missing;
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return this.factory.WireSource(qualifier);
			}
			
			public override GreenNode VisitWireTarget(SoalParser.WireTargetContext context)
			{
				if (context == null) return WireTargetGreen.__Missing;
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return this.factory.WireTarget(qualifier);
			}
			
			public override GreenNode VisitDeploymentDeclaration(SoalParser.DeploymentDeclarationContext context)
			{
				if (context == null) return DeploymentDeclarationGreen.__Missing;
				InternalSyntaxToken kDeployment = (InternalSyntaxToken)this.VisitTerminal(context.KDeployment(), SoalSyntaxKind.KDeployment);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				SoalParser.DeploymentBodyContext deploymentBodyContext = context.deploymentBody();
				DeploymentBodyGreen deploymentBody = null;
				if (deploymentBodyContext != null)
				{
					deploymentBody = (DeploymentBodyGreen)this.Visit(deploymentBodyContext);
				}
				else
				{
					deploymentBody = DeploymentBodyGreen.__Missing;
				}
				return this.factory.DeploymentDeclaration(kDeployment, name, deploymentBody);
			}
			
			public override GreenNode VisitDeploymentBody(SoalParser.DeploymentBodyContext context)
			{
				if (context == null) return DeploymentBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				SoalParser.DeploymentElementsContext deploymentElementsContext = context.deploymentElements();
				DeploymentElementsGreen deploymentElements = null;
				if (deploymentElementsContext != null)
				{
					deploymentElements = (DeploymentElementsGreen)this.Visit(deploymentElementsContext);
				}
				else
				{
					deploymentElements = DeploymentElementsGreen.__Missing;
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.DeploymentBody(tOpenBrace, deploymentElements, tCloseBrace);
			}
			
			public override GreenNode VisitDeploymentElements(SoalParser.DeploymentElementsContext context)
			{
				if (context == null) return DeploymentElementsGreen.__Missing;
			    SoalParser.DeploymentElementContext[] deploymentElementContext = context.deploymentElement();
			    var deploymentElementBuilder = _pool.Allocate<DeploymentElementGreen>();
			    for (int i = 0; i < deploymentElementContext.Length; i++)
			    {
			        deploymentElementBuilder.Add((DeploymentElementGreen)this.Visit(deploymentElementContext[i]));
			    }
				var deploymentElement = deploymentElementBuilder.ToList();
				_pool.Free(deploymentElementBuilder);
				return this.factory.DeploymentElements(deploymentElement);
			}
			
			public override GreenNode VisitDeploymentElement(SoalParser.DeploymentElementContext context)
			{
				if (context == null) return DeploymentElementGreen.__Missing;
				SoalParser.EnvironmentDeclarationContext environmentDeclarationContext = context.environmentDeclaration();
				if (environmentDeclarationContext != null) 
				{
					return this.factory.DeploymentElement((EnvironmentDeclarationGreen)this.Visit(environmentDeclarationContext));
				}
				SoalParser.CompositeWireContext compositeWireContext = context.compositeWire();
				if (compositeWireContext != null) 
				{
					return this.factory.DeploymentElement((CompositeWireGreen)this.Visit(compositeWireContext));
				}
				return DeploymentElementGreen.__Missing;
			}
			
			public override GreenNode VisitEnvironmentDeclaration(SoalParser.EnvironmentDeclarationContext context)
			{
				if (context == null) return EnvironmentDeclarationGreen.__Missing;
				InternalSyntaxToken kEnvironment = (InternalSyntaxToken)this.VisitTerminal(context.KEnvironment(), SoalSyntaxKind.KEnvironment);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				SoalParser.EnvironmentBodyContext environmentBodyContext = context.environmentBody();
				EnvironmentBodyGreen environmentBody = null;
				if (environmentBodyContext != null)
				{
					environmentBody = (EnvironmentBodyGreen)this.Visit(environmentBodyContext);
				}
				else
				{
					environmentBody = EnvironmentBodyGreen.__Missing;
				}
				return this.factory.EnvironmentDeclaration(kEnvironment, name, environmentBody);
			}
			
			public override GreenNode VisitEnvironmentBody(SoalParser.EnvironmentBodyContext context)
			{
				if (context == null) return EnvironmentBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				SoalParser.RuntimeDeclarationContext runtimeDeclarationContext = context.runtimeDeclaration();
				RuntimeDeclarationGreen runtimeDeclaration = null;
				if (runtimeDeclarationContext != null)
				{
					runtimeDeclaration = (RuntimeDeclarationGreen)this.Visit(runtimeDeclarationContext);
				}
				else
				{
					runtimeDeclaration = RuntimeDeclarationGreen.__Missing;
				}
			    SoalParser.RuntimeReferenceContext[] runtimeReferenceContext = context.runtimeReference();
			    var runtimeReferenceBuilder = _pool.Allocate<RuntimeReferenceGreen>();
			    for (int i = 0; i < runtimeReferenceContext.Length; i++)
			    {
			        runtimeReferenceBuilder.Add((RuntimeReferenceGreen)this.Visit(runtimeReferenceContext[i]));
			    }
				var runtimeReference = runtimeReferenceBuilder.ToList();
				_pool.Free(runtimeReferenceBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.EnvironmentBody(tOpenBrace, runtimeDeclaration, runtimeReference, tCloseBrace);
			}
			
			public override GreenNode VisitRuntimeDeclaration(SoalParser.RuntimeDeclarationContext context)
			{
				if (context == null) return RuntimeDeclarationGreen.__Missing;
				InternalSyntaxToken kRuntime = (InternalSyntaxToken)this.VisitTerminal(context.KRuntime(), SoalSyntaxKind.KRuntime);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.RuntimeDeclaration(kRuntime, name, tSemicolon);
			}
			
			public override GreenNode VisitRuntimeReference(SoalParser.RuntimeReferenceContext context)
			{
				if (context == null) return RuntimeReferenceGreen.__Missing;
				SoalParser.AssemblyReferenceContext assemblyReferenceContext = context.assemblyReference();
				if (assemblyReferenceContext != null) 
				{
					return this.factory.RuntimeReference((AssemblyReferenceGreen)this.Visit(assemblyReferenceContext));
				}
				SoalParser.DatabaseReferenceContext databaseReferenceContext = context.databaseReference();
				if (databaseReferenceContext != null) 
				{
					return this.factory.RuntimeReference((DatabaseReferenceGreen)this.Visit(databaseReferenceContext));
				}
				return RuntimeReferenceGreen.__Missing;
			}
			
			public override GreenNode VisitAssemblyReference(SoalParser.AssemblyReferenceContext context)
			{
				if (context == null) return AssemblyReferenceGreen.__Missing;
				InternalSyntaxToken kAssembly = (InternalSyntaxToken)this.VisitTerminal(context.KAssembly(), SoalSyntaxKind.KAssembly);
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.AssemblyReference(kAssembly, qualifier, tSemicolon);
			}
			
			public override GreenNode VisitDatabaseReference(SoalParser.DatabaseReferenceContext context)
			{
				if (context == null) return DatabaseReferenceGreen.__Missing;
				InternalSyntaxToken kDatabase = (InternalSyntaxToken)this.VisitTerminal(context.KDatabase(), SoalSyntaxKind.KDatabase);
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.DatabaseReference(kDatabase, qualifier, tSemicolon);
			}
			
			public override GreenNode VisitBindingDeclaration(SoalParser.BindingDeclarationContext context)
			{
				if (context == null) return BindingDeclarationGreen.__Missing;
				InternalSyntaxToken kBinding = (InternalSyntaxToken)this.VisitTerminal(context.KBinding(), SoalSyntaxKind.KBinding);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				SoalParser.BindingBodyContext bindingBodyContext = context.bindingBody();
				BindingBodyGreen bindingBody = null;
				if (bindingBodyContext != null)
				{
					bindingBody = (BindingBodyGreen)this.Visit(bindingBodyContext);
				}
				else
				{
					bindingBody = BindingBodyGreen.__Missing;
				}
				return this.factory.BindingDeclaration(kBinding, name, bindingBody);
			}
			
			public override GreenNode VisitBindingBody(SoalParser.BindingBodyContext context)
			{
				if (context == null) return BindingBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				SoalParser.BindingLayersContext bindingLayersContext = context.bindingLayers();
				BindingLayersGreen bindingLayers = null;
				if (bindingLayersContext != null)
				{
					bindingLayers = (BindingLayersGreen)this.Visit(bindingLayersContext);
				}
				else
				{
					bindingLayers = BindingLayersGreen.__Missing;
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.BindingBody(tOpenBrace, bindingLayers, tCloseBrace);
			}
			
			public override GreenNode VisitBindingLayers(SoalParser.BindingLayersContext context)
			{
				if (context == null) return BindingLayersGreen.__Missing;
				SoalParser.TransportLayerContext transportLayerContext = context.transportLayer();
				TransportLayerGreen transportLayer = null;
				if (transportLayerContext != null)
				{
					transportLayer = (TransportLayerGreen)this.Visit(transportLayerContext);
				}
				else
				{
					transportLayer = TransportLayerGreen.__Missing;
				}
			    SoalParser.EncodingLayerContext[] encodingLayerContext = context.encodingLayer();
			    var encodingLayerBuilder = _pool.Allocate<EncodingLayerGreen>();
			    for (int i = 0; i < encodingLayerContext.Length; i++)
			    {
			        encodingLayerBuilder.Add((EncodingLayerGreen)this.Visit(encodingLayerContext[i]));
			    }
				var encodingLayer = encodingLayerBuilder.ToList();
				_pool.Free(encodingLayerBuilder);
			    SoalParser.ProtocolLayerContext[] protocolLayerContext = context.protocolLayer();
			    var protocolLayerBuilder = _pool.Allocate<ProtocolLayerGreen>();
			    for (int i = 0; i < protocolLayerContext.Length; i++)
			    {
			        protocolLayerBuilder.Add((ProtocolLayerGreen)this.Visit(protocolLayerContext[i]));
			    }
				var protocolLayer = protocolLayerBuilder.ToList();
				_pool.Free(protocolLayerBuilder);
				return this.factory.BindingLayers(transportLayer, encodingLayer, protocolLayer);
			}
			
			public override GreenNode VisitTransportLayer(SoalParser.TransportLayerContext context)
			{
				if (context == null) return TransportLayerGreen.__Missing;
				SoalParser.HttpTransportLayerContext httpTransportLayerContext = context.httpTransportLayer();
				if (httpTransportLayerContext != null) 
				{
					return this.factory.TransportLayer((HttpTransportLayerGreen)this.Visit(httpTransportLayerContext));
				}
				SoalParser.RestTransportLayerContext restTransportLayerContext = context.restTransportLayer();
				if (restTransportLayerContext != null) 
				{
					return this.factory.TransportLayer((RestTransportLayerGreen)this.Visit(restTransportLayerContext));
				}
				SoalParser.WebSocketTransportLayerContext webSocketTransportLayerContext = context.webSocketTransportLayer();
				if (webSocketTransportLayerContext != null) 
				{
					return this.factory.TransportLayer((WebSocketTransportLayerGreen)this.Visit(webSocketTransportLayerContext));
				}
				return TransportLayerGreen.__Missing;
			}
			
			public override GreenNode VisitHttpTransportLayer(SoalParser.HttpTransportLayerContext context)
			{
				if (context == null) return HttpTransportLayerGreen.__Missing;
				InternalSyntaxToken kTransport = (InternalSyntaxToken)this.VisitTerminal(context.KTransport(), SoalSyntaxKind.KTransport);
				InternalSyntaxToken ihttp = (InternalSyntaxToken)this.VisitTerminal(context.IHTTP(), SoalSyntaxKind.IHTTP);
				SoalParser.HttpTransportLayerBodyContext httpTransportLayerBodyContext = context.httpTransportLayerBody();
				HttpTransportLayerBodyGreen httpTransportLayerBody = null;
				if (httpTransportLayerBodyContext != null)
				{
					httpTransportLayerBody = (HttpTransportLayerBodyGreen)this.Visit(httpTransportLayerBodyContext);
				}
				else
				{
					httpTransportLayerBody = HttpTransportLayerBodyGreen.__Missing;
				}
				return this.factory.HttpTransportLayer(kTransport, ihttp, httpTransportLayerBody);
			}
			
			public override GreenNode VisitHttpTransportLayerEmptyBody(SoalParser.HttpTransportLayerEmptyBodyContext context)
			{
				if (context == null) return HttpTransportLayerEmptyBodyGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.HttpTransportLayerEmptyBody(tSemicolon);
			}
			
			public override GreenNode VisitHttpTransportLayerNonEmptyBody(SoalParser.HttpTransportLayerNonEmptyBodyContext context)
			{
				if (context == null) return HttpTransportLayerNonEmptyBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
			    SoalParser.HttpTransportLayerPropertiesContext[] httpTransportLayerPropertiesContext = context.httpTransportLayerProperties();
			    var httpTransportLayerPropertiesBuilder = _pool.Allocate<HttpTransportLayerPropertiesGreen>();
			    for (int i = 0; i < httpTransportLayerPropertiesContext.Length; i++)
			    {
			        httpTransportLayerPropertiesBuilder.Add((HttpTransportLayerPropertiesGreen)this.Visit(httpTransportLayerPropertiesContext[i]));
			    }
				var httpTransportLayerProperties = httpTransportLayerPropertiesBuilder.ToList();
				_pool.Free(httpTransportLayerPropertiesBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.HttpTransportLayerNonEmptyBody(tOpenBrace, httpTransportLayerProperties, tCloseBrace);
			}
			
			public override GreenNode VisitRestTransportLayer(SoalParser.RestTransportLayerContext context)
			{
				if (context == null) return RestTransportLayerGreen.__Missing;
				InternalSyntaxToken kTransport = (InternalSyntaxToken)this.VisitTerminal(context.KTransport(), SoalSyntaxKind.KTransport);
				InternalSyntaxToken irest = (InternalSyntaxToken)this.VisitTerminal(context.IREST(), SoalSyntaxKind.IREST);
				SoalParser.RestTransportLayerBodyContext restTransportLayerBodyContext = context.restTransportLayerBody();
				RestTransportLayerBodyGreen restTransportLayerBody = null;
				if (restTransportLayerBodyContext != null)
				{
					restTransportLayerBody = (RestTransportLayerBodyGreen)this.Visit(restTransportLayerBodyContext);
				}
				else
				{
					restTransportLayerBody = RestTransportLayerBodyGreen.__Missing;
				}
				return this.factory.RestTransportLayer(kTransport, irest, restTransportLayerBody);
			}
			
			public override GreenNode VisitRestTransportLayerEmptyBody(SoalParser.RestTransportLayerEmptyBodyContext context)
			{
				if (context == null) return RestTransportLayerEmptyBodyGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.RestTransportLayerEmptyBody(tSemicolon);
			}
			
			public override GreenNode VisitRestTransportLayerNonEmptyBody(SoalParser.RestTransportLayerNonEmptyBodyContext context)
			{
				if (context == null) return RestTransportLayerNonEmptyBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.RestTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace);
			}
			
			public override GreenNode VisitWebSocketTransportLayer(SoalParser.WebSocketTransportLayerContext context)
			{
				if (context == null) return WebSocketTransportLayerGreen.__Missing;
				InternalSyntaxToken kTransport = (InternalSyntaxToken)this.VisitTerminal(context.KTransport(), SoalSyntaxKind.KTransport);
				InternalSyntaxToken iWebSocket = (InternalSyntaxToken)this.VisitTerminal(context.IWebSocket(), SoalSyntaxKind.IWebSocket);
				SoalParser.WebSocketTransportLayerBodyContext webSocketTransportLayerBodyContext = context.webSocketTransportLayerBody();
				WebSocketTransportLayerBodyGreen webSocketTransportLayerBody = null;
				if (webSocketTransportLayerBodyContext != null)
				{
					webSocketTransportLayerBody = (WebSocketTransportLayerBodyGreen)this.Visit(webSocketTransportLayerBodyContext);
				}
				else
				{
					webSocketTransportLayerBody = WebSocketTransportLayerBodyGreen.__Missing;
				}
				return this.factory.WebSocketTransportLayer(kTransport, iWebSocket, webSocketTransportLayerBody);
			}
			
			public override GreenNode VisitWebSocketTransportLayerEmptyBody(SoalParser.WebSocketTransportLayerEmptyBodyContext context)
			{
				if (context == null) return WebSocketTransportLayerEmptyBodyGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.WebSocketTransportLayerEmptyBody(tSemicolon);
			}
			
			public override GreenNode VisitWebSocketTransportLayerNonEmptyBody(SoalParser.WebSocketTransportLayerNonEmptyBodyContext context)
			{
				if (context == null) return WebSocketTransportLayerNonEmptyBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.WebSocketTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace);
			}
			
			public override GreenNode VisitHttpTransportLayerProperties(SoalParser.HttpTransportLayerPropertiesContext context)
			{
				if (context == null) return HttpTransportLayerPropertiesGreen.__Missing;
				SoalParser.HttpSslPropertyContext httpSslPropertyContext = context.httpSslProperty();
				if (httpSslPropertyContext != null) 
				{
					return this.factory.HttpTransportLayerProperties((HttpSslPropertyGreen)this.Visit(httpSslPropertyContext));
				}
				SoalParser.HttpClientAuthenticationPropertyContext httpClientAuthenticationPropertyContext = context.httpClientAuthenticationProperty();
				if (httpClientAuthenticationPropertyContext != null) 
				{
					return this.factory.HttpTransportLayerProperties((HttpClientAuthenticationPropertyGreen)this.Visit(httpClientAuthenticationPropertyContext));
				}
				return HttpTransportLayerPropertiesGreen.__Missing;
			}
			
			public override GreenNode VisitHttpSslProperty(SoalParser.HttpSslPropertyContext context)
			{
				if (context == null) return HttpSslPropertyGreen.__Missing;
				InternalSyntaxToken issl = (InternalSyntaxToken)this.VisitTerminal(context.ISSL(), SoalSyntaxKind.ISSL);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), SoalSyntaxKind.TAssign);
				SoalParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				BooleanLiteralGreen booleanLiteral = null;
				if (booleanLiteralContext != null)
				{
					booleanLiteral = (BooleanLiteralGreen)this.Visit(booleanLiteralContext);
				}
				else
				{
					booleanLiteral = BooleanLiteralGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.HttpSslProperty(issl, tAssign, booleanLiteral, tSemicolon);
			}
			
			public override GreenNode VisitHttpClientAuthenticationProperty(SoalParser.HttpClientAuthenticationPropertyContext context)
			{
				if (context == null) return HttpClientAuthenticationPropertyGreen.__Missing;
				InternalSyntaxToken iClientAuthentication = (InternalSyntaxToken)this.VisitTerminal(context.IClientAuthentication(), SoalSyntaxKind.IClientAuthentication);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), SoalSyntaxKind.TAssign);
				SoalParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				BooleanLiteralGreen booleanLiteral = null;
				if (booleanLiteralContext != null)
				{
					booleanLiteral = (BooleanLiteralGreen)this.Visit(booleanLiteralContext);
				}
				else
				{
					booleanLiteral = BooleanLiteralGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.HttpClientAuthenticationProperty(iClientAuthentication, tAssign, booleanLiteral, tSemicolon);
			}
			
			public override GreenNode VisitEncodingLayer(SoalParser.EncodingLayerContext context)
			{
				if (context == null) return EncodingLayerGreen.__Missing;
				SoalParser.SoapEncodingLayerContext soapEncodingLayerContext = context.soapEncodingLayer();
				if (soapEncodingLayerContext != null) 
				{
					return this.factory.EncodingLayer((SoapEncodingLayerGreen)this.Visit(soapEncodingLayerContext));
				}
				SoalParser.XmlEncodingLayerContext xmlEncodingLayerContext = context.xmlEncodingLayer();
				if (xmlEncodingLayerContext != null) 
				{
					return this.factory.EncodingLayer((XmlEncodingLayerGreen)this.Visit(xmlEncodingLayerContext));
				}
				SoalParser.JsonEncodingLayerContext jsonEncodingLayerContext = context.jsonEncodingLayer();
				if (jsonEncodingLayerContext != null) 
				{
					return this.factory.EncodingLayer((JsonEncodingLayerGreen)this.Visit(jsonEncodingLayerContext));
				}
				return EncodingLayerGreen.__Missing;
			}
			
			public override GreenNode VisitSoapEncodingLayer(SoalParser.SoapEncodingLayerContext context)
			{
				if (context == null) return SoapEncodingLayerGreen.__Missing;
				InternalSyntaxToken kEncoding = (InternalSyntaxToken)this.VisitTerminal(context.KEncoding(), SoalSyntaxKind.KEncoding);
				InternalSyntaxToken isoap = (InternalSyntaxToken)this.VisitTerminal(context.ISOAP(), SoalSyntaxKind.ISOAP);
				SoalParser.SoapEncodingLayerBodyContext soapEncodingLayerBodyContext = context.soapEncodingLayerBody();
				SoapEncodingLayerBodyGreen soapEncodingLayerBody = null;
				if (soapEncodingLayerBodyContext != null)
				{
					soapEncodingLayerBody = (SoapEncodingLayerBodyGreen)this.Visit(soapEncodingLayerBodyContext);
				}
				else
				{
					soapEncodingLayerBody = SoapEncodingLayerBodyGreen.__Missing;
				}
				return this.factory.SoapEncodingLayer(kEncoding, isoap, soapEncodingLayerBody);
			}
			
			public override GreenNode VisitSoapEncodingLayerEmptyBody(SoalParser.SoapEncodingLayerEmptyBodyContext context)
			{
				if (context == null) return SoapEncodingLayerEmptyBodyGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.SoapEncodingLayerEmptyBody(tSemicolon);
			}
			
			public override GreenNode VisitSoapEncodingLayerNonEmptyBody(SoalParser.SoapEncodingLayerNonEmptyBodyContext context)
			{
				if (context == null) return SoapEncodingLayerNonEmptyBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
			    SoalParser.SoapEncodingPropertiesContext[] soapEncodingPropertiesContext = context.soapEncodingProperties();
			    var soapEncodingPropertiesBuilder = _pool.Allocate<SoapEncodingPropertiesGreen>();
			    for (int i = 0; i < soapEncodingPropertiesContext.Length; i++)
			    {
			        soapEncodingPropertiesBuilder.Add((SoapEncodingPropertiesGreen)this.Visit(soapEncodingPropertiesContext[i]));
			    }
				var soapEncodingProperties = soapEncodingPropertiesBuilder.ToList();
				_pool.Free(soapEncodingPropertiesBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.SoapEncodingLayerNonEmptyBody(tOpenBrace, soapEncodingProperties, tCloseBrace);
			}
			
			public override GreenNode VisitXmlEncodingLayer(SoalParser.XmlEncodingLayerContext context)
			{
				if (context == null) return XmlEncodingLayerGreen.__Missing;
				InternalSyntaxToken kEncoding = (InternalSyntaxToken)this.VisitTerminal(context.KEncoding(), SoalSyntaxKind.KEncoding);
				InternalSyntaxToken ixml = (InternalSyntaxToken)this.VisitTerminal(context.IXML(), SoalSyntaxKind.IXML);
				SoalParser.XmlEncodingLayerBodyContext xmlEncodingLayerBodyContext = context.xmlEncodingLayerBody();
				XmlEncodingLayerBodyGreen xmlEncodingLayerBody = null;
				if (xmlEncodingLayerBodyContext != null)
				{
					xmlEncodingLayerBody = (XmlEncodingLayerBodyGreen)this.Visit(xmlEncodingLayerBodyContext);
				}
				else
				{
					xmlEncodingLayerBody = XmlEncodingLayerBodyGreen.__Missing;
				}
				return this.factory.XmlEncodingLayer(kEncoding, ixml, xmlEncodingLayerBody);
			}
			
			public override GreenNode VisitXmlEncodingLayerEmptyBody(SoalParser.XmlEncodingLayerEmptyBodyContext context)
			{
				if (context == null) return XmlEncodingLayerEmptyBodyGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.XmlEncodingLayerEmptyBody(tSemicolon);
			}
			
			public override GreenNode VisitXmlEncodingLayerNonEmptyBody(SoalParser.XmlEncodingLayerNonEmptyBodyContext context)
			{
				if (context == null) return XmlEncodingLayerNonEmptyBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.XmlEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace);
			}
			
			public override GreenNode VisitJsonEncodingLayer(SoalParser.JsonEncodingLayerContext context)
			{
				if (context == null) return JsonEncodingLayerGreen.__Missing;
				InternalSyntaxToken kEncoding = (InternalSyntaxToken)this.VisitTerminal(context.KEncoding(), SoalSyntaxKind.KEncoding);
				InternalSyntaxToken ijson = (InternalSyntaxToken)this.VisitTerminal(context.IJSON(), SoalSyntaxKind.IJSON);
				SoalParser.JsonEncodingLayerBodyContext jsonEncodingLayerBodyContext = context.jsonEncodingLayerBody();
				JsonEncodingLayerBodyGreen jsonEncodingLayerBody = null;
				if (jsonEncodingLayerBodyContext != null)
				{
					jsonEncodingLayerBody = (JsonEncodingLayerBodyGreen)this.Visit(jsonEncodingLayerBodyContext);
				}
				else
				{
					jsonEncodingLayerBody = JsonEncodingLayerBodyGreen.__Missing;
				}
				return this.factory.JsonEncodingLayer(kEncoding, ijson, jsonEncodingLayerBody);
			}
			
			public override GreenNode VisitJsonEncodingLayerEmptyBody(SoalParser.JsonEncodingLayerEmptyBodyContext context)
			{
				if (context == null) return JsonEncodingLayerEmptyBodyGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.JsonEncodingLayerEmptyBody(tSemicolon);
			}
			
			public override GreenNode VisitJsonEncodingLayerNonEmptyBody(SoalParser.JsonEncodingLayerNonEmptyBodyContext context)
			{
				if (context == null) return JsonEncodingLayerNonEmptyBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.JsonEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace);
			}
			
			public override GreenNode VisitSoapEncodingProperties(SoalParser.SoapEncodingPropertiesContext context)
			{
				if (context == null) return SoapEncodingPropertiesGreen.__Missing;
				SoalParser.SoapVersionPropertyContext soapVersionPropertyContext = context.soapVersionProperty();
				if (soapVersionPropertyContext != null) 
				{
					return this.factory.SoapEncodingProperties((SoapVersionPropertyGreen)this.Visit(soapVersionPropertyContext));
				}
				SoalParser.SoapMtomPropertyContext soapMtomPropertyContext = context.soapMtomProperty();
				if (soapMtomPropertyContext != null) 
				{
					return this.factory.SoapEncodingProperties((SoapMtomPropertyGreen)this.Visit(soapMtomPropertyContext));
				}
				SoalParser.SoapStylePropertyContext soapStylePropertyContext = context.soapStyleProperty();
				if (soapStylePropertyContext != null) 
				{
					return this.factory.SoapEncodingProperties((SoapStylePropertyGreen)this.Visit(soapStylePropertyContext));
				}
				return SoapEncodingPropertiesGreen.__Missing;
			}
			
			public override GreenNode VisitSoapVersionProperty(SoalParser.SoapVersionPropertyContext context)
			{
				if (context == null) return SoapVersionPropertyGreen.__Missing;
				InternalSyntaxToken iVersion = (InternalSyntaxToken)this.VisitTerminal(context.IVersion(), SoalSyntaxKind.IVersion);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), SoalSyntaxKind.TAssign);
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				else
				{
					identifier = IdentifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.SoapVersionProperty(iVersion, tAssign, identifier, tSemicolon);
			}
			
			public override GreenNode VisitSoapMtomProperty(SoalParser.SoapMtomPropertyContext context)
			{
				if (context == null) return SoapMtomPropertyGreen.__Missing;
				InternalSyntaxToken imtom = (InternalSyntaxToken)this.VisitTerminal(context.IMTOM(), SoalSyntaxKind.IMTOM);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), SoalSyntaxKind.TAssign);
				SoalParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				BooleanLiteralGreen booleanLiteral = null;
				if (booleanLiteralContext != null)
				{
					booleanLiteral = (BooleanLiteralGreen)this.Visit(booleanLiteralContext);
				}
				else
				{
					booleanLiteral = BooleanLiteralGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.SoapMtomProperty(imtom, tAssign, booleanLiteral, tSemicolon);
			}
			
			public override GreenNode VisitSoapStyleProperty(SoalParser.SoapStylePropertyContext context)
			{
				if (context == null) return SoapStylePropertyGreen.__Missing;
				InternalSyntaxToken iStyle = (InternalSyntaxToken)this.VisitTerminal(context.IStyle(), SoalSyntaxKind.IStyle);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), SoalSyntaxKind.TAssign);
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				else
				{
					identifier = IdentifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.SoapStyleProperty(iStyle, tAssign, identifier, tSemicolon);
			}
			
			public override GreenNode VisitProtocolLayer(SoalParser.ProtocolLayerContext context)
			{
				if (context == null) return ProtocolLayerGreen.__Missing;
				InternalSyntaxToken kProtocol = (InternalSyntaxToken)this.VisitTerminal(context.KProtocol(), SoalSyntaxKind.KProtocol);
				SoalParser.ProtocolLayerKindContext protocolLayerKindContext = context.protocolLayerKind();
				ProtocolLayerKindGreen protocolLayerKind = null;
				if (protocolLayerKindContext != null)
				{
					protocolLayerKind = (ProtocolLayerKindGreen)this.Visit(protocolLayerKindContext);
				}
				else
				{
					protocolLayerKind = ProtocolLayerKindGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.ProtocolLayer(kProtocol, protocolLayerKind, tSemicolon);
			}
			
			public override GreenNode VisitProtocolLayerKind(SoalParser.ProtocolLayerKindContext context)
			{
				if (context == null) return ProtocolLayerKindGreen.__Missing;
				SoalParser.WsAddressingContext wsAddressingContext = context.wsAddressing();
				WsAddressingGreen wsAddressing = null;
				if (wsAddressingContext != null)
				{
					wsAddressing = (WsAddressingGreen)this.Visit(wsAddressingContext);
				}
				else
				{
					wsAddressing = WsAddressingGreen.__Missing;
				}
				return this.factory.ProtocolLayerKind(wsAddressing);
			}
			
			public override GreenNode VisitWsAddressing(SoalParser.WsAddressingContext context)
			{
				if (context == null) return WsAddressingGreen.__Missing;
				InternalSyntaxToken iWsAddressing = (InternalSyntaxToken)this.VisitTerminal(context.IWsAddressing(), SoalSyntaxKind.IWsAddressing);
				return this.factory.WsAddressing(iWsAddressing);
			}
			
			public override GreenNode VisitEndpointDeclaration(SoalParser.EndpointDeclarationContext context)
			{
				if (context == null) return EndpointDeclarationGreen.__Missing;
				InternalSyntaxToken kEndpoint = (InternalSyntaxToken)this.VisitTerminal(context.KEndpoint(), SoalSyntaxKind.KEndpoint);
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), SoalSyntaxKind.TColon);
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				SoalParser.EndpointBodyContext endpointBodyContext = context.endpointBody();
				EndpointBodyGreen endpointBody = null;
				if (endpointBodyContext != null)
				{
					endpointBody = (EndpointBodyGreen)this.Visit(endpointBodyContext);
				}
				else
				{
					endpointBody = EndpointBodyGreen.__Missing;
				}
				return this.factory.EndpointDeclaration(kEndpoint, name, tColon, qualifier, endpointBody);
			}
			
			public override GreenNode VisitEndpointBody(SoalParser.EndpointBodyContext context)
			{
				if (context == null) return EndpointBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), SoalSyntaxKind.TOpenBrace);
				SoalParser.EndpointPropertiesContext endpointPropertiesContext = context.endpointProperties();
				EndpointPropertiesGreen endpointProperties = null;
				if (endpointPropertiesContext != null)
				{
					endpointProperties = (EndpointPropertiesGreen)this.Visit(endpointPropertiesContext);
				}
				else
				{
					endpointProperties = EndpointPropertiesGreen.__Missing;
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), SoalSyntaxKind.TCloseBrace);
				return this.factory.EndpointBody(tOpenBrace, endpointProperties, tCloseBrace);
			}
			
			public override GreenNode VisitEndpointProperties(SoalParser.EndpointPropertiesContext context)
			{
				if (context == null) return EndpointPropertiesGreen.__Missing;
			    SoalParser.EndpointPropertyContext[] endpointPropertyContext = context.endpointProperty();
			    var endpointPropertyBuilder = _pool.Allocate<EndpointPropertyGreen>();
			    for (int i = 0; i < endpointPropertyContext.Length; i++)
			    {
			        endpointPropertyBuilder.Add((EndpointPropertyGreen)this.Visit(endpointPropertyContext[i]));
			    }
				var endpointProperty = endpointPropertyBuilder.ToList();
				_pool.Free(endpointPropertyBuilder);
				return this.factory.EndpointProperties(endpointProperty);
			}
			
			public override GreenNode VisitEndpointProperty(SoalParser.EndpointPropertyContext context)
			{
				if (context == null) return EndpointPropertyGreen.__Missing;
				SoalParser.EndpointBindingPropertyContext endpointBindingPropertyContext = context.endpointBindingProperty();
				if (endpointBindingPropertyContext != null) 
				{
					return this.factory.EndpointProperty((EndpointBindingPropertyGreen)this.Visit(endpointBindingPropertyContext));
				}
				SoalParser.EndpointAddressPropertyContext endpointAddressPropertyContext = context.endpointAddressProperty();
				if (endpointAddressPropertyContext != null) 
				{
					return this.factory.EndpointProperty((EndpointAddressPropertyGreen)this.Visit(endpointAddressPropertyContext));
				}
				return EndpointPropertyGreen.__Missing;
			}
			
			public override GreenNode VisitEndpointBindingProperty(SoalParser.EndpointBindingPropertyContext context)
			{
				if (context == null) return EndpointBindingPropertyGreen.__Missing;
				InternalSyntaxToken kBinding = (InternalSyntaxToken)this.VisitTerminal(context.KBinding(), SoalSyntaxKind.KBinding);
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.EndpointBindingProperty(kBinding, qualifier, tSemicolon);
			}
			
			public override GreenNode VisitEndpointAddressProperty(SoalParser.EndpointAddressPropertyContext context)
			{
				if (context == null) return EndpointAddressPropertyGreen.__Missing;
				InternalSyntaxToken kAddress = (InternalSyntaxToken)this.VisitTerminal(context.KAddress(), SoalSyntaxKind.KAddress);
				SoalParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null)
				{
					stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				}
				else
				{
					stringLiteral = StringLiteralGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), SoalSyntaxKind.TSemicolon);
				return this.factory.EndpointAddressProperty(kAddress, stringLiteral, tSemicolon);
			}
			
			public override GreenNode VisitReturnType(SoalParser.ReturnTypeContext context)
			{
				if (context == null) return ReturnTypeGreen.__Missing;
				SoalParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return this.factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext));
				}
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return this.factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext));
				}
				return ReturnTypeGreen.__Missing;
			}
			
			public override GreenNode VisitTypeReference(SoalParser.TypeReferenceContext context)
			{
				if (context == null) return TypeReferenceGreen.__Missing;
				SoalParser.NonNullableArrayTypeContext nonNullableArrayTypeContext = context.nonNullableArrayType();
				if (nonNullableArrayTypeContext != null) 
				{
					return this.factory.TypeReference((NonNullableArrayTypeGreen)this.Visit(nonNullableArrayTypeContext));
				}
				SoalParser.ArrayTypeContext arrayTypeContext = context.arrayType();
				if (arrayTypeContext != null) 
				{
					return this.factory.TypeReference((ArrayTypeGreen)this.Visit(arrayTypeContext));
				}
				SoalParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return this.factory.TypeReference((SimpleTypeGreen)this.Visit(simpleTypeContext));
				}
				SoalParser.NulledTypeContext nulledTypeContext = context.nulledType();
				if (nulledTypeContext != null) 
				{
					return this.factory.TypeReference((NulledTypeGreen)this.Visit(nulledTypeContext));
				}
				return TypeReferenceGreen.__Missing;
			}
			
			public override GreenNode VisitSimpleType(SoalParser.SimpleTypeContext context)
			{
				if (context == null) return SimpleTypeGreen.__Missing;
				SoalParser.ValueTypeContext valueTypeContext = context.valueType();
				if (valueTypeContext != null) 
				{
					return this.factory.SimpleType((ValueTypeGreen)this.Visit(valueTypeContext));
				}
				SoalParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					return this.factory.SimpleType((ObjectTypeGreen)this.Visit(objectTypeContext));
				}
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				if (qualifierContext != null) 
				{
					return this.factory.SimpleType((QualifierGreen)this.Visit(qualifierContext));
				}
				return SimpleTypeGreen.__Missing;
			}
			
			public override GreenNode VisitNulledType(SoalParser.NulledTypeContext context)
			{
				if (context == null) return NulledTypeGreen.__Missing;
				SoalParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					return this.factory.NulledType((NullableTypeGreen)this.Visit(nullableTypeContext));
				}
				SoalParser.NonNullableTypeContext nonNullableTypeContext = context.nonNullableType();
				if (nonNullableTypeContext != null) 
				{
					return this.factory.NulledType((NonNullableTypeGreen)this.Visit(nonNullableTypeContext));
				}
				return NulledTypeGreen.__Missing;
			}
			
			public override GreenNode VisitReferenceType(SoalParser.ReferenceTypeContext context)
			{
				if (context == null) return ReferenceTypeGreen.__Missing;
				SoalParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					return this.factory.ReferenceType((ObjectTypeGreen)this.Visit(objectTypeContext));
				}
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				if (qualifierContext != null) 
				{
					return this.factory.ReferenceType((QualifierGreen)this.Visit(qualifierContext));
				}
				return ReferenceTypeGreen.__Missing;
			}
			
			public override GreenNode VisitObjectType(SoalParser.ObjectTypeContext context)
			{
				if (context == null) return ObjectTypeGreen.__Missing;
				InternalSyntaxToken objectType = null;
				if (context.KObject() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KObject());
				}
				else 	if (context.KString() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KString());
				}
				else
				{
					objectType = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.ObjectType(objectType);
			}
			
			public override GreenNode VisitValueType(SoalParser.ValueTypeContext context)
			{
				if (context == null) return ValueTypeGreen.__Missing;
				InternalSyntaxToken valueType = null;
				if (context.KInt() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.KInt());
				}
				else 	if (context.KLong() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.KLong());
				}
				else 	if (context.KFloat() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.KFloat());
				}
				else 	if (context.KDouble() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.KDouble());
				}
				else 	if (context.KByte() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.KByte());
				}
				else 	if (context.KBool() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.KBool());
				}
				else 	if (context.IDate() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.IDate());
				}
				else 	if (context.ITime() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.ITime());
				}
				else 	if (context.IDateTime() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.IDateTime());
				}
				else 	if (context.ITimeSpan() != null)
				{
					valueType = (InternalSyntaxToken)this.VisitTerminal(context.ITimeSpan());
				}
				else
				{
					valueType = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.ValueType(valueType);
			}
			
			public override GreenNode VisitVoidType(SoalParser.VoidTypeContext context)
			{
				if (context == null) return VoidTypeGreen.__Missing;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid(), SoalSyntaxKind.KVoid);
				return this.factory.VoidType(kVoid);
			}
			
			public override GreenNode VisitOnewayType(SoalParser.OnewayTypeContext context)
			{
				if (context == null) return OnewayTypeGreen.__Missing;
				InternalSyntaxToken kOneway = (InternalSyntaxToken)this.VisitTerminal(context.KOneway(), SoalSyntaxKind.KOneway);
				return this.factory.OnewayType(kOneway);
			}
			
			public override GreenNode VisitOperationReturnType(SoalParser.OperationReturnTypeContext context)
			{
				if (context == null) return OperationReturnTypeGreen.__Missing;
				SoalParser.OnewayTypeContext onewayTypeContext = context.onewayType();
				if (onewayTypeContext != null) 
				{
					return this.factory.OperationReturnType((OnewayTypeGreen)this.Visit(onewayTypeContext));
				}
				SoalParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return this.factory.OperationReturnType((VoidTypeGreen)this.Visit(voidTypeContext));
				}
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return this.factory.OperationReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext));
				}
				return OperationReturnTypeGreen.__Missing;
			}
			
			public override GreenNode VisitNullableType(SoalParser.NullableTypeContext context)
			{
				if (context == null) return NullableTypeGreen.__Missing;
				SoalParser.ValueTypeContext valueTypeContext = context.valueType();
				ValueTypeGreen valueType = null;
				if (valueTypeContext != null)
				{
					valueType = (ValueTypeGreen)this.Visit(valueTypeContext);
				}
				else
				{
					valueType = ValueTypeGreen.__Missing;
				}
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion(), SoalSyntaxKind.TQuestion);
				return this.factory.NullableType(valueType, tQuestion);
			}
			
			public override GreenNode VisitNonNullableType(SoalParser.NonNullableTypeContext context)
			{
				if (context == null) return NonNullableTypeGreen.__Missing;
				SoalParser.ReferenceTypeContext referenceTypeContext = context.referenceType();
				ReferenceTypeGreen referenceType = null;
				if (referenceTypeContext != null)
				{
					referenceType = (ReferenceTypeGreen)this.Visit(referenceTypeContext);
				}
				else
				{
					referenceType = ReferenceTypeGreen.__Missing;
				}
				InternalSyntaxToken tExclamation = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation(), SoalSyntaxKind.TExclamation);
				return this.factory.NonNullableType(referenceType, tExclamation);
			}
			
			public override GreenNode VisitNonNullableArrayType(SoalParser.NonNullableArrayTypeContext context)
			{
				if (context == null) return NonNullableArrayTypeGreen.__Missing;
				SoalParser.ArrayTypeContext arrayTypeContext = context.arrayType();
				ArrayTypeGreen arrayType = null;
				if (arrayTypeContext != null)
				{
					arrayType = (ArrayTypeGreen)this.Visit(arrayTypeContext);
				}
				else
				{
					arrayType = ArrayTypeGreen.__Missing;
				}
				InternalSyntaxToken tExclamation = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation(), SoalSyntaxKind.TExclamation);
				return this.factory.NonNullableArrayType(arrayType, tExclamation);
			}
			
			public override GreenNode VisitArrayType(SoalParser.ArrayTypeContext context)
			{
				if (context == null) return ArrayTypeGreen.__Missing;
				SoalParser.SimpleArrayTypeContext simpleArrayTypeContext = context.simpleArrayType();
				if (simpleArrayTypeContext != null) 
				{
					return this.factory.ArrayType((SimpleArrayTypeGreen)this.Visit(simpleArrayTypeContext));
				}
				SoalParser.NulledArrayTypeContext nulledArrayTypeContext = context.nulledArrayType();
				if (nulledArrayTypeContext != null) 
				{
					return this.factory.ArrayType((NulledArrayTypeGreen)this.Visit(nulledArrayTypeContext));
				}
				return ArrayTypeGreen.__Missing;
			}
			
			public override GreenNode VisitSimpleArrayType(SoalParser.SimpleArrayTypeContext context)
			{
				if (context == null) return SimpleArrayTypeGreen.__Missing;
				SoalParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				SimpleTypeGreen simpleType = null;
				if (simpleTypeContext != null)
				{
					simpleType = (SimpleTypeGreen)this.Visit(simpleTypeContext);
				}
				else
				{
					simpleType = SimpleTypeGreen.__Missing;
				}
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), SoalSyntaxKind.TOpenBracket);
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), SoalSyntaxKind.TCloseBracket);
				return this.factory.SimpleArrayType(simpleType, tOpenBracket, tCloseBracket);
			}
			
			public override GreenNode VisitNulledArrayType(SoalParser.NulledArrayTypeContext context)
			{
				if (context == null) return NulledArrayTypeGreen.__Missing;
				SoalParser.NulledTypeContext nulledTypeContext = context.nulledType();
				NulledTypeGreen nulledType = null;
				if (nulledTypeContext != null)
				{
					nulledType = (NulledTypeGreen)this.Visit(nulledTypeContext);
				}
				else
				{
					nulledType = NulledTypeGreen.__Missing;
				}
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), SoalSyntaxKind.TOpenBracket);
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), SoalSyntaxKind.TCloseBracket);
				return this.factory.NulledArrayType(nulledType, tOpenBracket, tCloseBracket);
			}
			
			public override GreenNode VisitConstantValue(SoalParser.ConstantValueContext context)
			{
				if (context == null) return ConstantValueGreen.__Missing;
				SoalParser.LiteralContext literalContext = context.literal();
				if (literalContext != null) 
				{
					return this.factory.ConstantValue((LiteralGreen)this.Visit(literalContext));
				}
				SoalParser.IdentifierContext identifierContext = context.identifier();
				if (identifierContext != null) 
				{
					return this.factory.ConstantValue((IdentifierGreen)this.Visit(identifierContext));
				}
				return ConstantValueGreen.__Missing;
			}
			
			public override GreenNode VisitTypeofValue(SoalParser.TypeofValueContext context)
			{
				if (context == null) return TypeofValueGreen.__Missing;
				InternalSyntaxToken kTypeof = (InternalSyntaxToken)this.VisitTerminal(context.KTypeof(), SoalSyntaxKind.KTypeof);
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), SoalSyntaxKind.TOpenParen);
				SoalParser.ReturnTypeContext returnTypeContext = context.returnType();
				ReturnTypeGreen returnType = null;
				if (returnTypeContext != null)
				{
					returnType = (ReturnTypeGreen)this.Visit(returnTypeContext);
				}
				else
				{
					returnType = ReturnTypeGreen.__Missing;
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), SoalSyntaxKind.TCloseParen);
				return this.factory.TypeofValue(kTypeof, tOpenParen, returnType, tCloseParen);
			}
			
			public override GreenNode VisitIdentifier(SoalParser.IdentifierContext context)
			{
				if (context == null) return IdentifierGreen.__Missing;
				SoalParser.IdentifiersContext identifiersContext = context.identifiers();
				if (identifiersContext != null) 
				{
					return this.factory.Identifier((IdentifiersGreen)this.Visit(identifiersContext));
				}
				SoalParser.ContextualKeywordsContext contextualKeywordsContext = context.contextualKeywords();
				if (contextualKeywordsContext != null) 
				{
					return this.factory.Identifier((ContextualKeywordsGreen)this.Visit(contextualKeywordsContext));
				}
				return IdentifierGreen.__Missing;
			}
			
			public override GreenNode VisitIdentifiers(SoalParser.IdentifiersContext context)
			{
				if (context == null) return IdentifiersGreen.__Missing;
				InternalSyntaxToken identifiers = null;
				if (context.IdentifierNormal() != null)
				{
					identifiers = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierNormal());
				}
				else 	if (context.IdentifierVerbatim() != null)
				{
					identifiers = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierVerbatim());
				}
				else
				{
					identifiers = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.Identifiers(identifiers);
			}
			
			public override GreenNode VisitLiteral(SoalParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				SoalParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return this.factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				SoalParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return this.factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				SoalParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return this.factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				SoalParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return this.factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				SoalParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return this.factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				SoalParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return this.factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(SoalParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), SoalSyntaxKind.KNull);
				return this.factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(SoalParser.BooleanLiteralContext context)
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
			
			public override GreenNode VisitIntegerLiteral(SoalParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), SoalSyntaxKind.LInteger);
				return this.factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(SoalParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), SoalSyntaxKind.LDecimal);
				return this.factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(SoalParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), SoalSyntaxKind.LScientific);
				return this.factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(SoalParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken stringLiteral = null;
				if (context.LRegularString() != null)
				{
					stringLiteral = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString());
				}
				else 	if (context.LSingleQuoteVerbatimString() != null)
				{
					stringLiteral = (InternalSyntaxToken)this.VisitTerminal(context.LSingleQuoteVerbatimString());
				}
				else 	if (context.LDoubleQuoteVerbatimString() != null)
				{
					stringLiteral = (InternalSyntaxToken)this.VisitTerminal(context.LDoubleQuoteVerbatimString());
				}
				else
				{
					stringLiteral = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.StringLiteral(stringLiteral);
			}
			
			public override GreenNode VisitContextualKeywords(SoalParser.ContextualKeywordsContext context)
			{
				if (context == null) return ContextualKeywordsGreen.__Missing;
				InternalSyntaxToken contextualKeywords = null;
				if (context.IDate() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IDate());
				}
				else 	if (context.ITime() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.ITime());
				}
				else 	if (context.IDateTime() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IDateTime());
				}
				else 	if (context.ITimeSpan() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.ITimeSpan());
				}
				else 	if (context.IVersion() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IVersion());
				}
				else 	if (context.IStyle() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IStyle());
				}
				else 	if (context.IMTOM() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IMTOM());
				}
				else 	if (context.ISSL() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.ISSL());
				}
				else 	if (context.IHTTP() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IHTTP());
				}
				else 	if (context.IREST() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IREST());
				}
				else 	if (context.IWebSocket() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IWebSocket());
				}
				else 	if (context.ISOAP() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.ISOAP());
				}
				else 	if (context.IXML() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IXML());
				}
				else 	if (context.IJSON() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IJSON());
				}
				else 	if (context.IClientAuthentication() != null)
				{
					contextualKeywords = (InternalSyntaxToken)this.VisitTerminal(context.IClientAuthentication());
				}
				else
				{
					contextualKeywords = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.ContextualKeywords(contextualKeywords);
			}
        }
    }
}

