// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Compiler.Antlr4Roslyn;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.MetaModel;
using MetaDslx.Compiler.Utilities;
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
            private SoalLanguage language;
			private SoalGreenFactory factory;
            private SoalSyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastToken;
            public Antlr4ToRoslynVisitor(SoalSyntaxParser syntaxParser)
            {
                this.language = SoalLanguage.Instance;
				this.factory = language.InternalSyntaxFactory;
                this.syntaxParser = syntaxParser;
				this.tokens = this.syntaxParser.CommonTokenStream.GetTokens();
                this.lastToken = null;
            }
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                GreenNode result = this.syntaxParser.VisitTerminal(node, this.lastToken);
                if (result != null && !result.IsMissing)
                {
                    this.lastToken = node.Symbol;
                }
                return result;
            }
			
			public override GreenNode VisitMain(SoalParser.MainContext context)
			{
				if (context == null) return null;
			    SoalParser.NamespaceDeclarationContext[] namespaceDeclarationContext = context.namespaceDeclaration();
			    ArrayBuilder<NamespaceDeclarationGreen> namespaceDeclarationBuilder = ArrayBuilder<NamespaceDeclarationGreen>.GetInstance(namespaceDeclarationContext.Length);
			    for (int i = 0; i < namespaceDeclarationContext.Length; i++)
			    {
			        namespaceDeclarationBuilder.Add((NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext[i]));
			    }
				InternalSyntaxNodeList namespaceDeclaration = InternalSyntaxNodeList.Create(namespaceDeclarationBuilder.ToArrayAndFree());
				InternalSyntaxToken eof = (InternalSyntaxToken)this.VisitTerminal(context.Eof());
				return this.factory.Main(namespaceDeclaration, eof, true);
			}
			
			public override GreenNode VisitName(SoalParser.NameContext context)
			{
				if (context == null) return null;
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				return this.factory.Name(identifier, true);
			}
			
			public override GreenNode VisitQualifiedName(SoalParser.QualifiedNameContext context)
			{
				if (context == null) return null;
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.QualifiedName(qualifier, true);
			}
			
			public override GreenNode VisitQualifier(SoalParser.QualifierContext context)
			{
				if (context == null) return null;
			    SoalParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    ArrayBuilder<GreenNode> identifierBuilder = ArrayBuilder<GreenNode>.GetInstance(identifierContext.Length+tDotContext.Length);
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tDotContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList identifier = InternalSeparatedSyntaxNodeList.Create(identifierBuilder.ToArrayAndFree());
				return this.factory.Qualifier(identifier, true);
			}
			
			public override GreenNode VisitIdentifierList(SoalParser.IdentifierListContext context)
			{
				if (context == null) return null;
			    SoalParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    ArrayBuilder<GreenNode> identifierBuilder = ArrayBuilder<GreenNode>.GetInstance(identifierContext.Length+tCommaContext.Length);
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            identifierBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList identifier = InternalSeparatedSyntaxNodeList.Create(identifierBuilder.ToArrayAndFree());
				return this.factory.IdentifierList(identifier, true);
			}
			
			public override GreenNode VisitQualifierList(SoalParser.QualifierListContext context)
			{
				if (context == null) return null;
			    SoalParser.QualifierContext[] qualifierContext = context.qualifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    ArrayBuilder<GreenNode> qualifierBuilder = ArrayBuilder<GreenNode>.GetInstance(qualifierContext.Length+tCommaContext.Length);
			    for (int i = 0; i < qualifierContext.Length; i++)
			    {
			        qualifierBuilder.Add((QualifierGreen)this.Visit(qualifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            qualifierBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList qualifier = InternalSeparatedSyntaxNodeList.Create(qualifierBuilder.ToArrayAndFree());
				return this.factory.QualifierList(qualifier, true);
			}
			
			public override GreenNode VisitAnnotationList(SoalParser.AnnotationListContext context)
			{
				if (context == null) return null;
			    SoalParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				return this.factory.AnnotationList(annotation, true);
			}
			
			public override GreenNode VisitReturnAnnotationList(SoalParser.ReturnAnnotationListContext context)
			{
				if (context == null) return null;
			    SoalParser.ReturnAnnotationContext[] returnAnnotationContext = context.returnAnnotation();
			    ArrayBuilder<ReturnAnnotationGreen> returnAnnotationBuilder = ArrayBuilder<ReturnAnnotationGreen>.GetInstance(returnAnnotationContext.Length);
			    for (int i = 0; i < returnAnnotationContext.Length; i++)
			    {
			        returnAnnotationBuilder.Add((ReturnAnnotationGreen)this.Visit(returnAnnotationContext[i]));
			    }
				InternalSyntaxNodeList returnAnnotation = InternalSyntaxNodeList.Create(returnAnnotationBuilder.ToArrayAndFree());
				return this.factory.ReturnAnnotationList(returnAnnotation, true);
			}
			
			public override GreenNode VisitAnnotation(SoalParser.AnnotationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket());
				SoalParser.AnnotationHeadContext annotationHeadContext = context.annotationHead();
				AnnotationHeadGreen annotationHead = null;
				if (annotationHeadContext != null)
				{
					annotationHead = (AnnotationHeadGreen)this.Visit(annotationHeadContext);
				}
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket());
				return this.factory.Annotation(tOpenBracket, annotationHead, tCloseBracket, true);
			}
			
			public override GreenNode VisitReturnAnnotation(SoalParser.ReturnAnnotationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket());
				InternalSyntaxToken kReturn = (InternalSyntaxToken)this.VisitTerminal(context.KReturn());
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.AnnotationHeadContext annotationHeadContext = context.annotationHead();
				AnnotationHeadGreen annotationHead = null;
				if (annotationHeadContext != null)
				{
					annotationHead = (AnnotationHeadGreen)this.Visit(annotationHeadContext);
				}
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket());
				return this.factory.ReturnAnnotation(tOpenBracket, kReturn, tColon, annotationHead, tCloseBracket, true);
			}
			
			public override GreenNode VisitAnnotationHead(SoalParser.AnnotationHeadContext context)
			{
				if (context == null) return null;
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SoalParser.AnnotationBodyContext annotationBodyContext = context.annotationBody();
				AnnotationBodyGreen annotationBody = null;
				if (annotationBodyContext != null)
				{
					annotationBody = (AnnotationBodyGreen)this.Visit(annotationBodyContext);
				}
				return this.factory.AnnotationHead(name, annotationBody, true);
			}
			
			public override GreenNode VisitAnnotationBody(SoalParser.AnnotationBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				SoalParser.AnnotationPropertyListContext annotationPropertyListContext = context.annotationPropertyList();
				AnnotationPropertyListGreen annotationPropertyList = null;
				if (annotationPropertyListContext != null)
				{
					annotationPropertyList = (AnnotationPropertyListGreen)this.Visit(annotationPropertyListContext);
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				return this.factory.AnnotationBody(tOpenParen, annotationPropertyList, tCloseParen, true);
			}
			
			public override GreenNode VisitAnnotationPropertyList(SoalParser.AnnotationPropertyListContext context)
			{
				if (context == null) return null;
			    SoalParser.AnnotationPropertyContext[] annotationPropertyContext = context.annotationProperty();
			    ITerminalNode[] tCommaContext = context.TComma();
			    ArrayBuilder<GreenNode> annotationPropertyBuilder = ArrayBuilder<GreenNode>.GetInstance(annotationPropertyContext.Length+tCommaContext.Length);
			    for (int i = 0; i < annotationPropertyContext.Length; i++)
			    {
			        annotationPropertyBuilder.Add((AnnotationPropertyGreen)this.Visit(annotationPropertyContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            annotationPropertyBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList annotationProperty = InternalSeparatedSyntaxNodeList.Create(annotationPropertyBuilder.ToArrayAndFree());
				return this.factory.AnnotationPropertyList(annotationProperty, true);
			}
			
			public override GreenNode VisitAnnotationProperty(SoalParser.AnnotationPropertyContext context)
			{
				if (context == null) return null;
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				SoalParser.AnnotationPropertyValueContext annotationPropertyValueContext = context.annotationPropertyValue();
				AnnotationPropertyValueGreen annotationPropertyValue = null;
				if (annotationPropertyValueContext != null)
				{
					annotationPropertyValue = (AnnotationPropertyValueGreen)this.Visit(annotationPropertyValueContext);
				}
				return this.factory.AnnotationProperty(name, tAssign, annotationPropertyValue, true);
			}
			
			public override GreenNode VisitAnnotationPropertyValue(SoalParser.AnnotationPropertyValueContext context)
			{
				if (context == null) return null;
				SoalParser.ConstantValueContext constantValueContext = context.constantValue();
				if (constantValueContext != null) 
				{
					return this.factory.AnnotationPropertyValue((ConstantValueGreen)this.Visit(constantValueContext), true);
				}
				SoalParser.TypeofValueContext typeofValueContext = context.typeofValue();
				if (typeofValueContext != null) 
				{
					return this.factory.AnnotationPropertyValue((TypeofValueGreen)this.Visit(typeofValueContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitNamespaceDeclaration(SoalParser.NamespaceDeclarationContext context)
			{
				if (context == null) return null;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace());
				SoalParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null)
				{
					stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				}
				SoalParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null)
				{
					namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				}
				return this.factory.NamespaceDeclaration(annotationList, kNamespace, qualifiedName, tAssign, identifier, tColon, stringLiteral, namespaceBody, true);
			}
			
			public override GreenNode VisitNamespaceBody(SoalParser.NamespaceBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    SoalParser.DeclarationContext[] declarationContext = context.declaration();
			    ArrayBuilder<DeclarationGreen> declarationBuilder = ArrayBuilder<DeclarationGreen>.GetInstance(declarationContext.Length);
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				InternalSyntaxNodeList declaration = InternalSyntaxNodeList.Create(declarationBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.NamespaceBody(tOpenBrace, declaration, tCloseBrace, true);
			}
			
			public override GreenNode VisitDeclaration(SoalParser.DeclarationContext context)
			{
				if (context == null) return null;
				SoalParser.EnumDeclarationContext enumDeclarationContext = context.enumDeclaration();
				if (enumDeclarationContext != null) 
				{
					return this.factory.Declaration((EnumDeclarationGreen)this.Visit(enumDeclarationContext), true);
				}
				SoalParser.StructDeclarationContext structDeclarationContext = context.structDeclaration();
				if (structDeclarationContext != null) 
				{
					return this.factory.Declaration((StructDeclarationGreen)this.Visit(structDeclarationContext), true);
				}
				SoalParser.DatabaseDeclarationContext databaseDeclarationContext = context.databaseDeclaration();
				if (databaseDeclarationContext != null) 
				{
					return this.factory.Declaration((DatabaseDeclarationGreen)this.Visit(databaseDeclarationContext), true);
				}
				SoalParser.InterfaceDeclarationContext interfaceDeclarationContext = context.interfaceDeclaration();
				if (interfaceDeclarationContext != null) 
				{
					return this.factory.Declaration((InterfaceDeclarationGreen)this.Visit(interfaceDeclarationContext), true);
				}
				SoalParser.ComponentDeclarationContext componentDeclarationContext = context.componentDeclaration();
				if (componentDeclarationContext != null) 
				{
					return this.factory.Declaration((ComponentDeclarationGreen)this.Visit(componentDeclarationContext), true);
				}
				SoalParser.CompositeDeclarationContext compositeDeclarationContext = context.compositeDeclaration();
				if (compositeDeclarationContext != null) 
				{
					return this.factory.Declaration((CompositeDeclarationGreen)this.Visit(compositeDeclarationContext), true);
				}
				SoalParser.AssemblyDeclarationContext assemblyDeclarationContext = context.assemblyDeclaration();
				if (assemblyDeclarationContext != null) 
				{
					return this.factory.Declaration((AssemblyDeclarationGreen)this.Visit(assemblyDeclarationContext), true);
				}
				SoalParser.BindingDeclarationContext bindingDeclarationContext = context.bindingDeclaration();
				if (bindingDeclarationContext != null) 
				{
					return this.factory.Declaration((BindingDeclarationGreen)this.Visit(bindingDeclarationContext), true);
				}
				SoalParser.EndpointDeclarationContext endpointDeclarationContext = context.endpointDeclaration();
				if (endpointDeclarationContext != null) 
				{
					return this.factory.Declaration((EndpointDeclarationGreen)this.Visit(endpointDeclarationContext), true);
				}
				SoalParser.DeploymentDeclarationContext deploymentDeclarationContext = context.deploymentDeclaration();
				if (deploymentDeclarationContext != null) 
				{
					return this.factory.Declaration((DeploymentDeclarationGreen)this.Visit(deploymentDeclarationContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitEnumDeclaration(SoalParser.EnumDeclarationContext context)
			{
				if (context == null) return null;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				InternalSyntaxToken kEnum = (InternalSyntaxToken)this.VisitTerminal(context.KEnum());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				SoalParser.EnumBodyContext enumBodyContext = context.enumBody();
				EnumBodyGreen enumBody = null;
				if (enumBodyContext != null)
				{
					enumBody = (EnumBodyGreen)this.Visit(enumBodyContext);
				}
				return this.factory.EnumDeclaration(annotationList, kEnum, name, tColon, qualifier, enumBody, true);
			}
			
			public override GreenNode VisitEnumBody(SoalParser.EnumBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				SoalParser.EnumLiteralsContext enumLiteralsContext = context.enumLiterals();
				EnumLiteralsGreen enumLiterals = null;
				if (enumLiteralsContext != null)
				{
					enumLiterals = (EnumLiteralsGreen)this.Visit(enumLiteralsContext);
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.EnumBody(tOpenBrace, enumLiterals, tCloseBrace, true);
			}
			
			public override GreenNode VisitEnumLiterals(SoalParser.EnumLiteralsContext context)
			{
				if (context == null) return null;
			    SoalParser.EnumLiteralContext[] enumLiteralContext = context.enumLiteral();
			    ITerminalNode[] tCommaContext = context.TComma();
			    ArrayBuilder<GreenNode> enumLiteralBuilder = ArrayBuilder<GreenNode>.GetInstance(enumLiteralContext.Length+tCommaContext.Length);
			    for (int i = 0; i < enumLiteralContext.Length; i++)
			    {
			        enumLiteralBuilder.Add((EnumLiteralGreen)this.Visit(enumLiteralContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            enumLiteralBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList enumLiteral = InternalSeparatedSyntaxNodeList.Create(enumLiteralBuilder.ToArrayAndFree());
				return this.factory.EnumLiterals(enumLiteral, true);
			}
			
			public override GreenNode VisitEnumLiteral(SoalParser.EnumLiteralContext context)
			{
				if (context == null) return null;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				return this.factory.EnumLiteral(annotationList, name, true);
			}
			
			public override GreenNode VisitStructDeclaration(SoalParser.StructDeclarationContext context)
			{
				if (context == null) return null;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				InternalSyntaxToken kStruct = (InternalSyntaxToken)this.VisitTerminal(context.KStruct());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				SoalParser.StructBodyContext structBodyContext = context.structBody();
				StructBodyGreen structBody = null;
				if (structBodyContext != null)
				{
					structBody = (StructBodyGreen)this.Visit(structBodyContext);
				}
				return this.factory.StructDeclaration(annotationList, kStruct, name, tColon, qualifier, structBody, true);
			}
			
			public override GreenNode VisitStructBody(SoalParser.StructBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    SoalParser.PropertyDeclarationContext[] propertyDeclarationContext = context.propertyDeclaration();
			    ArrayBuilder<PropertyDeclarationGreen> propertyDeclarationBuilder = ArrayBuilder<PropertyDeclarationGreen>.GetInstance(propertyDeclarationContext.Length);
			    for (int i = 0; i < propertyDeclarationContext.Length; i++)
			    {
			        propertyDeclarationBuilder.Add((PropertyDeclarationGreen)this.Visit(propertyDeclarationContext[i]));
			    }
				InternalSyntaxNodeList propertyDeclaration = InternalSyntaxNodeList.Create(propertyDeclarationBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.StructBody(tOpenBrace, propertyDeclaration, tCloseBrace, true);
			}
			
			public override GreenNode VisitPropertyDeclaration(SoalParser.PropertyDeclarationContext context)
			{
				if (context == null) return null;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.PropertyDeclaration(annotationList, typeReference, name, tSemicolon, true);
			}
			
			public override GreenNode VisitDatabaseDeclaration(SoalParser.DatabaseDeclarationContext context)
			{
				if (context == null) return null;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				InternalSyntaxToken kDatabase = (InternalSyntaxToken)this.VisitTerminal(context.KDatabase());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SoalParser.DatabaseBodyContext databaseBodyContext = context.databaseBody();
				DatabaseBodyGreen databaseBody = null;
				if (databaseBodyContext != null)
				{
					databaseBody = (DatabaseBodyGreen)this.Visit(databaseBodyContext);
				}
				return this.factory.DatabaseDeclaration(annotationList, kDatabase, name, databaseBody, true);
			}
			
			public override GreenNode VisitDatabaseBody(SoalParser.DatabaseBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    SoalParser.EntityReferenceContext[] entityReferenceContext = context.entityReference();
			    ArrayBuilder<EntityReferenceGreen> entityReferenceBuilder = ArrayBuilder<EntityReferenceGreen>.GetInstance(entityReferenceContext.Length);
			    for (int i = 0; i < entityReferenceContext.Length; i++)
			    {
			        entityReferenceBuilder.Add((EntityReferenceGreen)this.Visit(entityReferenceContext[i]));
			    }
				InternalSyntaxNodeList entityReference = InternalSyntaxNodeList.Create(entityReferenceBuilder.ToArrayAndFree());
			    SoalParser.OperationDeclarationContext[] operationDeclarationContext = context.operationDeclaration();
			    ArrayBuilder<OperationDeclarationGreen> operationDeclarationBuilder = ArrayBuilder<OperationDeclarationGreen>.GetInstance(operationDeclarationContext.Length);
			    for (int i = 0; i < operationDeclarationContext.Length; i++)
			    {
			        operationDeclarationBuilder.Add((OperationDeclarationGreen)this.Visit(operationDeclarationContext[i]));
			    }
				InternalSyntaxNodeList operationDeclaration = InternalSyntaxNodeList.Create(operationDeclarationBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.DatabaseBody(tOpenBrace, entityReference, operationDeclaration, tCloseBrace, true);
			}
			
			public override GreenNode VisitEntityReference(SoalParser.EntityReferenceContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kEntity = (InternalSyntaxToken)this.VisitTerminal(context.KEntity());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.EntityReference(kEntity, qualifier, tSemicolon, true);
			}
			
			public override GreenNode VisitInterfaceDeclaration(SoalParser.InterfaceDeclarationContext context)
			{
				if (context == null) return null;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				InternalSyntaxToken kInterface = (InternalSyntaxToken)this.VisitTerminal(context.KInterface());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SoalParser.InterfaceBodyContext interfaceBodyContext = context.interfaceBody();
				InterfaceBodyGreen interfaceBody = null;
				if (interfaceBodyContext != null)
				{
					interfaceBody = (InterfaceBodyGreen)this.Visit(interfaceBodyContext);
				}
				return this.factory.InterfaceDeclaration(annotationList, kInterface, name, interfaceBody, true);
			}
			
			public override GreenNode VisitInterfaceBody(SoalParser.InterfaceBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    SoalParser.OperationDeclarationContext[] operationDeclarationContext = context.operationDeclaration();
			    ArrayBuilder<OperationDeclarationGreen> operationDeclarationBuilder = ArrayBuilder<OperationDeclarationGreen>.GetInstance(operationDeclarationContext.Length);
			    for (int i = 0; i < operationDeclarationContext.Length; i++)
			    {
			        operationDeclarationBuilder.Add((OperationDeclarationGreen)this.Visit(operationDeclarationContext[i]));
			    }
				InternalSyntaxNodeList operationDeclaration = InternalSyntaxNodeList.Create(operationDeclarationBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.InterfaceBody(tOpenBrace, operationDeclaration, tCloseBrace, true);
			}
			
			public override GreenNode VisitOperationDeclaration(SoalParser.OperationDeclarationContext context)
			{
				if (context == null) return null;
				SoalParser.OperationHeadContext operationHeadContext = context.operationHead();
				OperationHeadGreen operationHead = null;
				if (operationHeadContext != null)
				{
					operationHead = (OperationHeadGreen)this.Visit(operationHeadContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.OperationDeclaration(operationHead, tSemicolon, true);
			}
			
			public override GreenNode VisitOperationHead(SoalParser.OperationHeadContext context)
			{
				if (context == null) return null;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				SoalParser.OperationResultContext operationResultContext = context.operationResult();
				OperationResultGreen operationResult = null;
				if (operationResultContext != null)
				{
					operationResult = (OperationResultGreen)this.Visit(operationResultContext);
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				SoalParser.ParameterListContext parameterListContext = context.parameterList();
				ParameterListGreen parameterList = null;
				if (parameterListContext != null)
				{
					parameterList = (ParameterListGreen)this.Visit(parameterListContext);
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				InternalSyntaxToken kThrows = (InternalSyntaxToken)this.VisitTerminal(context.KThrows());
				SoalParser.QualifierListContext qualifierListContext = context.qualifierList();
				QualifierListGreen qualifierList = null;
				if (qualifierListContext != null)
				{
					qualifierList = (QualifierListGreen)this.Visit(qualifierListContext);
				}
				return this.factory.OperationHead(annotationList, operationResult, name, tOpenParen, parameterList, tCloseParen, kThrows, qualifierList, true);
			}
			
			public override GreenNode VisitParameterList(SoalParser.ParameterListContext context)
			{
				if (context == null) return null;
			    SoalParser.ParameterContext[] parameterContext = context.parameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    ArrayBuilder<GreenNode> parameterBuilder = ArrayBuilder<GreenNode>.GetInstance(parameterContext.Length+tCommaContext.Length);
			    for (int i = 0; i < parameterContext.Length; i++)
			    {
			        parameterBuilder.Add((ParameterGreen)this.Visit(parameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            parameterBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList parameter = InternalSeparatedSyntaxNodeList.Create(parameterBuilder.ToArrayAndFree());
				return this.factory.ParameterList(parameter, true);
			}
			
			public override GreenNode VisitParameter(SoalParser.ParameterContext context)
			{
				if (context == null) return null;
				SoalParser.AnnotationListContext annotationListContext = context.annotationList();
				AnnotationListGreen annotationList = null;
				if (annotationListContext != null)
				{
					annotationList = (AnnotationListGreen)this.Visit(annotationListContext);
				}
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				return this.factory.Parameter(annotationList, typeReference, name, true);
			}
			
			public override GreenNode VisitOperationResult(SoalParser.OperationResultContext context)
			{
				if (context == null) return null;
				SoalParser.ReturnAnnotationListContext returnAnnotationListContext = context.returnAnnotationList();
				ReturnAnnotationListGreen returnAnnotationList = null;
				if (returnAnnotationListContext != null)
				{
					returnAnnotationList = (ReturnAnnotationListGreen)this.Visit(returnAnnotationListContext);
				}
				SoalParser.OperationReturnTypeContext operationReturnTypeContext = context.operationReturnType();
				OperationReturnTypeGreen operationReturnType = null;
				if (operationReturnTypeContext != null)
				{
					operationReturnType = (OperationReturnTypeGreen)this.Visit(operationReturnTypeContext);
				}
				return this.factory.OperationResult(returnAnnotationList, operationReturnType, true);
			}
			
			public override GreenNode VisitComponentDeclaration(SoalParser.ComponentDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kAbstract = (InternalSyntaxToken)this.VisitTerminal(context.KAbstract());
				InternalSyntaxToken kComponent = (InternalSyntaxToken)this.VisitTerminal(context.KComponent());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				SoalParser.ComponentBodyContext componentBodyContext = context.componentBody();
				ComponentBodyGreen componentBody = null;
				if (componentBodyContext != null)
				{
					componentBody = (ComponentBodyGreen)this.Visit(componentBodyContext);
				}
				return this.factory.ComponentDeclaration(kAbstract, kComponent, name, tColon, qualifier, componentBody, true);
			}
			
			public override GreenNode VisitComponentBody(SoalParser.ComponentBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				SoalParser.ComponentElementsContext componentElementsContext = context.componentElements();
				ComponentElementsGreen componentElements = null;
				if (componentElementsContext != null)
				{
					componentElements = (ComponentElementsGreen)this.Visit(componentElementsContext);
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.ComponentBody(tOpenBrace, componentElements, tCloseBrace, true);
			}
			
			public override GreenNode VisitComponentElements(SoalParser.ComponentElementsContext context)
			{
				if (context == null) return null;
			    SoalParser.ComponentElementContext[] componentElementContext = context.componentElement();
			    ArrayBuilder<ComponentElementGreen> componentElementBuilder = ArrayBuilder<ComponentElementGreen>.GetInstance(componentElementContext.Length);
			    for (int i = 0; i < componentElementContext.Length; i++)
			    {
			        componentElementBuilder.Add((ComponentElementGreen)this.Visit(componentElementContext[i]));
			    }
				InternalSyntaxNodeList componentElement = InternalSyntaxNodeList.Create(componentElementBuilder.ToArrayAndFree());
				return this.factory.ComponentElements(componentElement, true);
			}
			
			public override GreenNode VisitComponentElement(SoalParser.ComponentElementContext context)
			{
				if (context == null) return null;
				SoalParser.ComponentServiceContext componentServiceContext = context.componentService();
				if (componentServiceContext != null) 
				{
					return this.factory.ComponentElement((ComponentServiceGreen)this.Visit(componentServiceContext), true);
				}
				SoalParser.ComponentReferenceContext componentReferenceContext = context.componentReference();
				if (componentReferenceContext != null) 
				{
					return this.factory.ComponentElement((ComponentReferenceGreen)this.Visit(componentReferenceContext), true);
				}
				SoalParser.ComponentPropertyContext componentPropertyContext = context.componentProperty();
				if (componentPropertyContext != null) 
				{
					return this.factory.ComponentElement((ComponentPropertyGreen)this.Visit(componentPropertyContext), true);
				}
				SoalParser.ComponentImplementationContext componentImplementationContext = context.componentImplementation();
				if (componentImplementationContext != null) 
				{
					return this.factory.ComponentElement((ComponentImplementationGreen)this.Visit(componentImplementationContext), true);
				}
				SoalParser.ComponentLanguageContext componentLanguageContext = context.componentLanguage();
				if (componentLanguageContext != null) 
				{
					return this.factory.ComponentElement((ComponentLanguageGreen)this.Visit(componentLanguageContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitComponentService(SoalParser.ComponentServiceContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kService = (InternalSyntaxToken)this.VisitTerminal(context.KService());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SoalParser.ComponentServiceOrReferenceBodyContext componentServiceOrReferenceBodyContext = context.componentServiceOrReferenceBody();
				ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody = null;
				if (componentServiceOrReferenceBodyContext != null)
				{
					componentServiceOrReferenceBody = (ComponentServiceOrReferenceBodyGreen)this.Visit(componentServiceOrReferenceBodyContext);
				}
				return this.factory.ComponentService(kService, qualifier, name, componentServiceOrReferenceBody, true);
			}
			
			public override GreenNode VisitComponentReference(SoalParser.ComponentReferenceContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kReference = (InternalSyntaxToken)this.VisitTerminal(context.KReference());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SoalParser.ComponentServiceOrReferenceBodyContext componentServiceOrReferenceBodyContext = context.componentServiceOrReferenceBody();
				ComponentServiceOrReferenceBodyGreen componentServiceOrReferenceBody = null;
				if (componentServiceOrReferenceBodyContext != null)
				{
					componentServiceOrReferenceBody = (ComponentServiceOrReferenceBodyGreen)this.Visit(componentServiceOrReferenceBodyContext);
				}
				return this.factory.ComponentReference(kReference, qualifier, name, componentServiceOrReferenceBody, true);
			}
			
			public override GreenNode VisitComponentServiceOrReferenceEmptyBody(SoalParser.ComponentServiceOrReferenceEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ComponentServiceOrReferenceEmptyBody(tSemicolon, true);
			}
			
			public override GreenNode VisitComponentServiceOrReferenceNonEmptyBody(SoalParser.ComponentServiceOrReferenceNonEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    SoalParser.ComponentServiceOrReferenceElementContext[] componentServiceOrReferenceElementContext = context.componentServiceOrReferenceElement();
			    ArrayBuilder<ComponentServiceOrReferenceElementGreen> componentServiceOrReferenceElementBuilder = ArrayBuilder<ComponentServiceOrReferenceElementGreen>.GetInstance(componentServiceOrReferenceElementContext.Length);
			    for (int i = 0; i < componentServiceOrReferenceElementContext.Length; i++)
			    {
			        componentServiceOrReferenceElementBuilder.Add((ComponentServiceOrReferenceElementGreen)this.Visit(componentServiceOrReferenceElementContext[i]));
			    }
				InternalSyntaxNodeList componentServiceOrReferenceElement = InternalSyntaxNodeList.Create(componentServiceOrReferenceElementBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.ComponentServiceOrReferenceNonEmptyBody(tOpenBrace, componentServiceOrReferenceElement, tCloseBrace, true);
			}
			
			public override GreenNode VisitComponentServiceOrReferenceElement(SoalParser.ComponentServiceOrReferenceElementContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kBinding = (InternalSyntaxToken)this.VisitTerminal(context.KBinding());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ComponentServiceOrReferenceElement(kBinding, qualifier, tSemicolon, true);
			}
			
			public override GreenNode VisitComponentProperty(SoalParser.ComponentPropertyContext context)
			{
				if (context == null) return null;
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ComponentProperty(typeReference, name, tSemicolon, true);
			}
			
			public override GreenNode VisitComponentImplementation(SoalParser.ComponentImplementationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kImplementation = (InternalSyntaxToken)this.VisitTerminal(context.KImplementation());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ComponentImplementation(kImplementation, name, tSemicolon, true);
			}
			
			public override GreenNode VisitComponentLanguage(SoalParser.ComponentLanguageContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kLanguage = (InternalSyntaxToken)this.VisitTerminal(context.KLanguage());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ComponentLanguage(kLanguage, name, tSemicolon, true);
			}
			
			public override GreenNode VisitCompositeDeclaration(SoalParser.CompositeDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kComposite = (InternalSyntaxToken)this.VisitTerminal(context.KComposite());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				SoalParser.CompositeBodyContext compositeBodyContext = context.compositeBody();
				CompositeBodyGreen compositeBody = null;
				if (compositeBodyContext != null)
				{
					compositeBody = (CompositeBodyGreen)this.Visit(compositeBodyContext);
				}
				return this.factory.CompositeDeclaration(kComposite, name, tColon, qualifier, compositeBody, true);
			}
			
			public override GreenNode VisitCompositeBody(SoalParser.CompositeBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				SoalParser.CompositeElementsContext compositeElementsContext = context.compositeElements();
				CompositeElementsGreen compositeElements = null;
				if (compositeElementsContext != null)
				{
					compositeElements = (CompositeElementsGreen)this.Visit(compositeElementsContext);
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.CompositeBody(tOpenBrace, compositeElements, tCloseBrace, true);
			}
			
			public override GreenNode VisitAssemblyDeclaration(SoalParser.AssemblyDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kAssembly = (InternalSyntaxToken)this.VisitTerminal(context.KAssembly());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				SoalParser.CompositeBodyContext compositeBodyContext = context.compositeBody();
				CompositeBodyGreen compositeBody = null;
				if (compositeBodyContext != null)
				{
					compositeBody = (CompositeBodyGreen)this.Visit(compositeBodyContext);
				}
				return this.factory.AssemblyDeclaration(kAssembly, name, tColon, qualifier, compositeBody, true);
			}
			
			public override GreenNode VisitCompositeElements(SoalParser.CompositeElementsContext context)
			{
				if (context == null) return null;
			    SoalParser.CompositeElementContext[] compositeElementContext = context.compositeElement();
			    ArrayBuilder<CompositeElementGreen> compositeElementBuilder = ArrayBuilder<CompositeElementGreen>.GetInstance(compositeElementContext.Length);
			    for (int i = 0; i < compositeElementContext.Length; i++)
			    {
			        compositeElementBuilder.Add((CompositeElementGreen)this.Visit(compositeElementContext[i]));
			    }
				InternalSyntaxNodeList compositeElement = InternalSyntaxNodeList.Create(compositeElementBuilder.ToArrayAndFree());
				return this.factory.CompositeElements(compositeElement, true);
			}
			
			public override GreenNode VisitCompositeElement(SoalParser.CompositeElementContext context)
			{
				if (context == null) return null;
				SoalParser.ComponentServiceContext componentServiceContext = context.componentService();
				if (componentServiceContext != null) 
				{
					return this.factory.CompositeElement((ComponentServiceGreen)this.Visit(componentServiceContext), true);
				}
				SoalParser.ComponentReferenceContext componentReferenceContext = context.componentReference();
				if (componentReferenceContext != null) 
				{
					return this.factory.CompositeElement((ComponentReferenceGreen)this.Visit(componentReferenceContext), true);
				}
				SoalParser.ComponentPropertyContext componentPropertyContext = context.componentProperty();
				if (componentPropertyContext != null) 
				{
					return this.factory.CompositeElement((ComponentPropertyGreen)this.Visit(componentPropertyContext), true);
				}
				SoalParser.ComponentImplementationContext componentImplementationContext = context.componentImplementation();
				if (componentImplementationContext != null) 
				{
					return this.factory.CompositeElement((ComponentImplementationGreen)this.Visit(componentImplementationContext), true);
				}
				SoalParser.ComponentLanguageContext componentLanguageContext = context.componentLanguage();
				if (componentLanguageContext != null) 
				{
					return this.factory.CompositeElement((ComponentLanguageGreen)this.Visit(componentLanguageContext), true);
				}
				SoalParser.CompositeComponentContext compositeComponentContext = context.compositeComponent();
				if (compositeComponentContext != null) 
				{
					return this.factory.CompositeElement((CompositeComponentGreen)this.Visit(compositeComponentContext), true);
				}
				SoalParser.CompositeWireContext compositeWireContext = context.compositeWire();
				if (compositeWireContext != null) 
				{
					return this.factory.CompositeElement((CompositeWireGreen)this.Visit(compositeWireContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitCompositeComponent(SoalParser.CompositeComponentContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kComponent = (InternalSyntaxToken)this.VisitTerminal(context.KComponent());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.CompositeComponent(kComponent, qualifier, tSemicolon, true);
			}
			
			public override GreenNode VisitCompositeWire(SoalParser.CompositeWireContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kWire = (InternalSyntaxToken)this.VisitTerminal(context.KWire());
				SoalParser.WireSourceContext wireSourceContext = context.wireSource();
				WireSourceGreen wireSource = null;
				if (wireSourceContext != null)
				{
					wireSource = (WireSourceGreen)this.Visit(wireSourceContext);
				}
				InternalSyntaxToken kTo = (InternalSyntaxToken)this.VisitTerminal(context.KTo());
				SoalParser.WireTargetContext wireTargetContext = context.wireTarget();
				WireTargetGreen wireTarget = null;
				if (wireTargetContext != null)
				{
					wireTarget = (WireTargetGreen)this.Visit(wireTargetContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.CompositeWire(kWire, wireSource, kTo, wireTarget, tSemicolon, true);
			}
			
			public override GreenNode VisitWireSource(SoalParser.WireSourceContext context)
			{
				if (context == null) return null;
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.WireSource(qualifier, true);
			}
			
			public override GreenNode VisitWireTarget(SoalParser.WireTargetContext context)
			{
				if (context == null) return null;
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.WireTarget(qualifier, true);
			}
			
			public override GreenNode VisitDeploymentDeclaration(SoalParser.DeploymentDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kDeployment = (InternalSyntaxToken)this.VisitTerminal(context.KDeployment());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SoalParser.DeploymentBodyContext deploymentBodyContext = context.deploymentBody();
				DeploymentBodyGreen deploymentBody = null;
				if (deploymentBodyContext != null)
				{
					deploymentBody = (DeploymentBodyGreen)this.Visit(deploymentBodyContext);
				}
				return this.factory.DeploymentDeclaration(kDeployment, name, deploymentBody, true);
			}
			
			public override GreenNode VisitDeploymentBody(SoalParser.DeploymentBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				SoalParser.DeploymentElementsContext deploymentElementsContext = context.deploymentElements();
				DeploymentElementsGreen deploymentElements = null;
				if (deploymentElementsContext != null)
				{
					deploymentElements = (DeploymentElementsGreen)this.Visit(deploymentElementsContext);
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.DeploymentBody(tOpenBrace, deploymentElements, tCloseBrace, true);
			}
			
			public override GreenNode VisitDeploymentElements(SoalParser.DeploymentElementsContext context)
			{
				if (context == null) return null;
			    SoalParser.DeploymentElementContext[] deploymentElementContext = context.deploymentElement();
			    ArrayBuilder<DeploymentElementGreen> deploymentElementBuilder = ArrayBuilder<DeploymentElementGreen>.GetInstance(deploymentElementContext.Length);
			    for (int i = 0; i < deploymentElementContext.Length; i++)
			    {
			        deploymentElementBuilder.Add((DeploymentElementGreen)this.Visit(deploymentElementContext[i]));
			    }
				InternalSyntaxNodeList deploymentElement = InternalSyntaxNodeList.Create(deploymentElementBuilder.ToArrayAndFree());
				return this.factory.DeploymentElements(deploymentElement, true);
			}
			
			public override GreenNode VisitDeploymentElement(SoalParser.DeploymentElementContext context)
			{
				if (context == null) return null;
				SoalParser.EnvironmentDeclarationContext environmentDeclarationContext = context.environmentDeclaration();
				if (environmentDeclarationContext != null) 
				{
					return this.factory.DeploymentElement((EnvironmentDeclarationGreen)this.Visit(environmentDeclarationContext), true);
				}
				SoalParser.CompositeWireContext compositeWireContext = context.compositeWire();
				if (compositeWireContext != null) 
				{
					return this.factory.DeploymentElement((CompositeWireGreen)this.Visit(compositeWireContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitEnvironmentDeclaration(SoalParser.EnvironmentDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kEnvironment = (InternalSyntaxToken)this.VisitTerminal(context.KEnvironment());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SoalParser.EnvironmentBodyContext environmentBodyContext = context.environmentBody();
				EnvironmentBodyGreen environmentBody = null;
				if (environmentBodyContext != null)
				{
					environmentBody = (EnvironmentBodyGreen)this.Visit(environmentBodyContext);
				}
				return this.factory.EnvironmentDeclaration(kEnvironment, name, environmentBody, true);
			}
			
			public override GreenNode VisitEnvironmentBody(SoalParser.EnvironmentBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				SoalParser.RuntimeDeclarationContext runtimeDeclarationContext = context.runtimeDeclaration();
				RuntimeDeclarationGreen runtimeDeclaration = null;
				if (runtimeDeclarationContext != null)
				{
					runtimeDeclaration = (RuntimeDeclarationGreen)this.Visit(runtimeDeclarationContext);
				}
			    SoalParser.RuntimeReferenceContext[] runtimeReferenceContext = context.runtimeReference();
			    ArrayBuilder<RuntimeReferenceGreen> runtimeReferenceBuilder = ArrayBuilder<RuntimeReferenceGreen>.GetInstance(runtimeReferenceContext.Length);
			    for (int i = 0; i < runtimeReferenceContext.Length; i++)
			    {
			        runtimeReferenceBuilder.Add((RuntimeReferenceGreen)this.Visit(runtimeReferenceContext[i]));
			    }
				InternalSyntaxNodeList runtimeReference = InternalSyntaxNodeList.Create(runtimeReferenceBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.EnvironmentBody(tOpenBrace, runtimeDeclaration, runtimeReference, tCloseBrace, true);
			}
			
			public override GreenNode VisitRuntimeDeclaration(SoalParser.RuntimeDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kRuntime = (InternalSyntaxToken)this.VisitTerminal(context.KRuntime());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.RuntimeDeclaration(kRuntime, name, tSemicolon, true);
			}
			
			public override GreenNode VisitRuntimeReference(SoalParser.RuntimeReferenceContext context)
			{
				if (context == null) return null;
				SoalParser.AssemblyReferenceContext assemblyReferenceContext = context.assemblyReference();
				if (assemblyReferenceContext != null) 
				{
					return this.factory.RuntimeReference((AssemblyReferenceGreen)this.Visit(assemblyReferenceContext), true);
				}
				SoalParser.DatabaseReferenceContext databaseReferenceContext = context.databaseReference();
				if (databaseReferenceContext != null) 
				{
					return this.factory.RuntimeReference((DatabaseReferenceGreen)this.Visit(databaseReferenceContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitAssemblyReference(SoalParser.AssemblyReferenceContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kAssembly = (InternalSyntaxToken)this.VisitTerminal(context.KAssembly());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.AssemblyReference(kAssembly, qualifier, tSemicolon, true);
			}
			
			public override GreenNode VisitDatabaseReference(SoalParser.DatabaseReferenceContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kDatabase = (InternalSyntaxToken)this.VisitTerminal(context.KDatabase());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.DatabaseReference(kDatabase, qualifier, tSemicolon, true);
			}
			
			public override GreenNode VisitBindingDeclaration(SoalParser.BindingDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kBinding = (InternalSyntaxToken)this.VisitTerminal(context.KBinding());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				SoalParser.BindingBodyContext bindingBodyContext = context.bindingBody();
				BindingBodyGreen bindingBody = null;
				if (bindingBodyContext != null)
				{
					bindingBody = (BindingBodyGreen)this.Visit(bindingBodyContext);
				}
				return this.factory.BindingDeclaration(kBinding, name, bindingBody, true);
			}
			
			public override GreenNode VisitBindingBody(SoalParser.BindingBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				SoalParser.BindingLayersContext bindingLayersContext = context.bindingLayers();
				BindingLayersGreen bindingLayers = null;
				if (bindingLayersContext != null)
				{
					bindingLayers = (BindingLayersGreen)this.Visit(bindingLayersContext);
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.BindingBody(tOpenBrace, bindingLayers, tCloseBrace, true);
			}
			
			public override GreenNode VisitBindingLayers(SoalParser.BindingLayersContext context)
			{
				if (context == null) return null;
				SoalParser.TransportLayerContext transportLayerContext = context.transportLayer();
				TransportLayerGreen transportLayer = null;
				if (transportLayerContext != null)
				{
					transportLayer = (TransportLayerGreen)this.Visit(transportLayerContext);
				}
			    SoalParser.EncodingLayerContext[] encodingLayerContext = context.encodingLayer();
			    ArrayBuilder<EncodingLayerGreen> encodingLayerBuilder = ArrayBuilder<EncodingLayerGreen>.GetInstance(encodingLayerContext.Length);
			    for (int i = 0; i < encodingLayerContext.Length; i++)
			    {
			        encodingLayerBuilder.Add((EncodingLayerGreen)this.Visit(encodingLayerContext[i]));
			    }
				InternalSyntaxNodeList encodingLayer = InternalSyntaxNodeList.Create(encodingLayerBuilder.ToArrayAndFree());
			    SoalParser.ProtocolLayerContext[] protocolLayerContext = context.protocolLayer();
			    ArrayBuilder<ProtocolLayerGreen> protocolLayerBuilder = ArrayBuilder<ProtocolLayerGreen>.GetInstance(protocolLayerContext.Length);
			    for (int i = 0; i < protocolLayerContext.Length; i++)
			    {
			        protocolLayerBuilder.Add((ProtocolLayerGreen)this.Visit(protocolLayerContext[i]));
			    }
				InternalSyntaxNodeList protocolLayer = InternalSyntaxNodeList.Create(protocolLayerBuilder.ToArrayAndFree());
				return this.factory.BindingLayers(transportLayer, encodingLayer, protocolLayer, true);
			}
			
			public override GreenNode VisitTransportLayer(SoalParser.TransportLayerContext context)
			{
				if (context == null) return null;
				SoalParser.HttpTransportLayerContext httpTransportLayerContext = context.httpTransportLayer();
				if (httpTransportLayerContext != null) 
				{
					return this.factory.TransportLayer((HttpTransportLayerGreen)this.Visit(httpTransportLayerContext), true);
				}
				SoalParser.RestTransportLayerContext restTransportLayerContext = context.restTransportLayer();
				if (restTransportLayerContext != null) 
				{
					return this.factory.TransportLayer((RestTransportLayerGreen)this.Visit(restTransportLayerContext), true);
				}
				SoalParser.WebSocketTransportLayerContext webSocketTransportLayerContext = context.webSocketTransportLayer();
				if (webSocketTransportLayerContext != null) 
				{
					return this.factory.TransportLayer((WebSocketTransportLayerGreen)this.Visit(webSocketTransportLayerContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitHttpTransportLayer(SoalParser.HttpTransportLayerContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kTransport = (InternalSyntaxToken)this.VisitTerminal(context.KTransport());
				InternalSyntaxToken ihttp = (InternalSyntaxToken)this.VisitTerminal(context.IHTTP());
				SoalParser.HttpTransportLayerBodyContext httpTransportLayerBodyContext = context.httpTransportLayerBody();
				HttpTransportLayerBodyGreen httpTransportLayerBody = null;
				if (httpTransportLayerBodyContext != null)
				{
					httpTransportLayerBody = (HttpTransportLayerBodyGreen)this.Visit(httpTransportLayerBodyContext);
				}
				return this.factory.HttpTransportLayer(kTransport, ihttp, httpTransportLayerBody, true);
			}
			
			public override GreenNode VisitHttpTransportLayerEmptyBody(SoalParser.HttpTransportLayerEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.HttpTransportLayerEmptyBody(tSemicolon, true);
			}
			
			public override GreenNode VisitHttpTransportLayerNonEmptyBody(SoalParser.HttpTransportLayerNonEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    SoalParser.HttpTransportLayerPropertiesContext[] httpTransportLayerPropertiesContext = context.httpTransportLayerProperties();
			    ArrayBuilder<HttpTransportLayerPropertiesGreen> httpTransportLayerPropertiesBuilder = ArrayBuilder<HttpTransportLayerPropertiesGreen>.GetInstance(httpTransportLayerPropertiesContext.Length);
			    for (int i = 0; i < httpTransportLayerPropertiesContext.Length; i++)
			    {
			        httpTransportLayerPropertiesBuilder.Add((HttpTransportLayerPropertiesGreen)this.Visit(httpTransportLayerPropertiesContext[i]));
			    }
				InternalSyntaxNodeList httpTransportLayerProperties = InternalSyntaxNodeList.Create(httpTransportLayerPropertiesBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.HttpTransportLayerNonEmptyBody(tOpenBrace, httpTransportLayerProperties, tCloseBrace, true);
			}
			
			public override GreenNode VisitRestTransportLayer(SoalParser.RestTransportLayerContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kTransport = (InternalSyntaxToken)this.VisitTerminal(context.KTransport());
				InternalSyntaxToken irest = (InternalSyntaxToken)this.VisitTerminal(context.IREST());
				SoalParser.RestTransportLayerBodyContext restTransportLayerBodyContext = context.restTransportLayerBody();
				RestTransportLayerBodyGreen restTransportLayerBody = null;
				if (restTransportLayerBodyContext != null)
				{
					restTransportLayerBody = (RestTransportLayerBodyGreen)this.Visit(restTransportLayerBodyContext);
				}
				return this.factory.RestTransportLayer(kTransport, irest, restTransportLayerBody, true);
			}
			
			public override GreenNode VisitRestTransportLayerEmptyBody(SoalParser.RestTransportLayerEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.RestTransportLayerEmptyBody(tSemicolon, true);
			}
			
			public override GreenNode VisitRestTransportLayerNonEmptyBody(SoalParser.RestTransportLayerNonEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.RestTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace, true);
			}
			
			public override GreenNode VisitWebSocketTransportLayer(SoalParser.WebSocketTransportLayerContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kTransport = (InternalSyntaxToken)this.VisitTerminal(context.KTransport());
				InternalSyntaxToken iWebSocket = (InternalSyntaxToken)this.VisitTerminal(context.IWebSocket());
				SoalParser.WebSocketTransportLayerBodyContext webSocketTransportLayerBodyContext = context.webSocketTransportLayerBody();
				WebSocketTransportLayerBodyGreen webSocketTransportLayerBody = null;
				if (webSocketTransportLayerBodyContext != null)
				{
					webSocketTransportLayerBody = (WebSocketTransportLayerBodyGreen)this.Visit(webSocketTransportLayerBodyContext);
				}
				return this.factory.WebSocketTransportLayer(kTransport, iWebSocket, webSocketTransportLayerBody, true);
			}
			
			public override GreenNode VisitWebSocketTransportLayerEmptyBody(SoalParser.WebSocketTransportLayerEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.WebSocketTransportLayerEmptyBody(tSemicolon, true);
			}
			
			public override GreenNode VisitWebSocketTransportLayerNonEmptyBody(SoalParser.WebSocketTransportLayerNonEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.WebSocketTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace, true);
			}
			
			public override GreenNode VisitHttpTransportLayerProperties(SoalParser.HttpTransportLayerPropertiesContext context)
			{
				if (context == null) return null;
				SoalParser.HttpSslPropertyContext httpSslPropertyContext = context.httpSslProperty();
				if (httpSslPropertyContext != null) 
				{
					return this.factory.HttpTransportLayerProperties((HttpSslPropertyGreen)this.Visit(httpSslPropertyContext), true);
				}
				SoalParser.HttpClientAuthenticationPropertyContext httpClientAuthenticationPropertyContext = context.httpClientAuthenticationProperty();
				if (httpClientAuthenticationPropertyContext != null) 
				{
					return this.factory.HttpTransportLayerProperties((HttpClientAuthenticationPropertyGreen)this.Visit(httpClientAuthenticationPropertyContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitHttpSslProperty(SoalParser.HttpSslPropertyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken issl = (InternalSyntaxToken)this.VisitTerminal(context.ISSL());
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				SoalParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				BooleanLiteralGreen booleanLiteral = null;
				if (booleanLiteralContext != null)
				{
					booleanLiteral = (BooleanLiteralGreen)this.Visit(booleanLiteralContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.HttpSslProperty(issl, tAssign, booleanLiteral, tSemicolon, true);
			}
			
			public override GreenNode VisitHttpClientAuthenticationProperty(SoalParser.HttpClientAuthenticationPropertyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken iClientAuthentication = (InternalSyntaxToken)this.VisitTerminal(context.IClientAuthentication());
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				SoalParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				BooleanLiteralGreen booleanLiteral = null;
				if (booleanLiteralContext != null)
				{
					booleanLiteral = (BooleanLiteralGreen)this.Visit(booleanLiteralContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.HttpClientAuthenticationProperty(iClientAuthentication, tAssign, booleanLiteral, tSemicolon, true);
			}
			
			public override GreenNode VisitEncodingLayer(SoalParser.EncodingLayerContext context)
			{
				if (context == null) return null;
				SoalParser.SoapEncodingLayerContext soapEncodingLayerContext = context.soapEncodingLayer();
				if (soapEncodingLayerContext != null) 
				{
					return this.factory.EncodingLayer((SoapEncodingLayerGreen)this.Visit(soapEncodingLayerContext), true);
				}
				SoalParser.XmlEncodingLayerContext xmlEncodingLayerContext = context.xmlEncodingLayer();
				if (xmlEncodingLayerContext != null) 
				{
					return this.factory.EncodingLayer((XmlEncodingLayerGreen)this.Visit(xmlEncodingLayerContext), true);
				}
				SoalParser.JsonEncodingLayerContext jsonEncodingLayerContext = context.jsonEncodingLayer();
				if (jsonEncodingLayerContext != null) 
				{
					return this.factory.EncodingLayer((JsonEncodingLayerGreen)this.Visit(jsonEncodingLayerContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitSoapEncodingLayer(SoalParser.SoapEncodingLayerContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kEncoding = (InternalSyntaxToken)this.VisitTerminal(context.KEncoding());
				InternalSyntaxToken isoap = (InternalSyntaxToken)this.VisitTerminal(context.ISOAP());
				SoalParser.SoapEncodingLayerBodyContext soapEncodingLayerBodyContext = context.soapEncodingLayerBody();
				SoapEncodingLayerBodyGreen soapEncodingLayerBody = null;
				if (soapEncodingLayerBodyContext != null)
				{
					soapEncodingLayerBody = (SoapEncodingLayerBodyGreen)this.Visit(soapEncodingLayerBodyContext);
				}
				return this.factory.SoapEncodingLayer(kEncoding, isoap, soapEncodingLayerBody, true);
			}
			
			public override GreenNode VisitSoapEncodingLayerEmptyBody(SoalParser.SoapEncodingLayerEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.SoapEncodingLayerEmptyBody(tSemicolon, true);
			}
			
			public override GreenNode VisitSoapEncodingLayerNonEmptyBody(SoalParser.SoapEncodingLayerNonEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    SoalParser.SoapEncodingPropertiesContext[] soapEncodingPropertiesContext = context.soapEncodingProperties();
			    ArrayBuilder<SoapEncodingPropertiesGreen> soapEncodingPropertiesBuilder = ArrayBuilder<SoapEncodingPropertiesGreen>.GetInstance(soapEncodingPropertiesContext.Length);
			    for (int i = 0; i < soapEncodingPropertiesContext.Length; i++)
			    {
			        soapEncodingPropertiesBuilder.Add((SoapEncodingPropertiesGreen)this.Visit(soapEncodingPropertiesContext[i]));
			    }
				InternalSyntaxNodeList soapEncodingProperties = InternalSyntaxNodeList.Create(soapEncodingPropertiesBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.SoapEncodingLayerNonEmptyBody(tOpenBrace, soapEncodingProperties, tCloseBrace, true);
			}
			
			public override GreenNode VisitXmlEncodingLayer(SoalParser.XmlEncodingLayerContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kEncoding = (InternalSyntaxToken)this.VisitTerminal(context.KEncoding());
				InternalSyntaxToken ixml = (InternalSyntaxToken)this.VisitTerminal(context.IXML());
				SoalParser.XmlEncodingLayerBodyContext xmlEncodingLayerBodyContext = context.xmlEncodingLayerBody();
				XmlEncodingLayerBodyGreen xmlEncodingLayerBody = null;
				if (xmlEncodingLayerBodyContext != null)
				{
					xmlEncodingLayerBody = (XmlEncodingLayerBodyGreen)this.Visit(xmlEncodingLayerBodyContext);
				}
				return this.factory.XmlEncodingLayer(kEncoding, ixml, xmlEncodingLayerBody, true);
			}
			
			public override GreenNode VisitXmlEncodingLayerEmptyBody(SoalParser.XmlEncodingLayerEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.XmlEncodingLayerEmptyBody(tSemicolon, true);
			}
			
			public override GreenNode VisitXmlEncodingLayerNonEmptyBody(SoalParser.XmlEncodingLayerNonEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.XmlEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace, true);
			}
			
			public override GreenNode VisitJsonEncodingLayer(SoalParser.JsonEncodingLayerContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kEncoding = (InternalSyntaxToken)this.VisitTerminal(context.KEncoding());
				InternalSyntaxToken ijson = (InternalSyntaxToken)this.VisitTerminal(context.IJSON());
				SoalParser.JsonEncodingLayerBodyContext jsonEncodingLayerBodyContext = context.jsonEncodingLayerBody();
				JsonEncodingLayerBodyGreen jsonEncodingLayerBody = null;
				if (jsonEncodingLayerBodyContext != null)
				{
					jsonEncodingLayerBody = (JsonEncodingLayerBodyGreen)this.Visit(jsonEncodingLayerBodyContext);
				}
				return this.factory.JsonEncodingLayer(kEncoding, ijson, jsonEncodingLayerBody, true);
			}
			
			public override GreenNode VisitJsonEncodingLayerEmptyBody(SoalParser.JsonEncodingLayerEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.JsonEncodingLayerEmptyBody(tSemicolon, true);
			}
			
			public override GreenNode VisitJsonEncodingLayerNonEmptyBody(SoalParser.JsonEncodingLayerNonEmptyBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.JsonEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace, true);
			}
			
			public override GreenNode VisitSoapEncodingProperties(SoalParser.SoapEncodingPropertiesContext context)
			{
				if (context == null) return null;
				SoalParser.SoapVersionPropertyContext soapVersionPropertyContext = context.soapVersionProperty();
				if (soapVersionPropertyContext != null) 
				{
					return this.factory.SoapEncodingProperties((SoapVersionPropertyGreen)this.Visit(soapVersionPropertyContext), true);
				}
				SoalParser.SoapMtomPropertyContext soapMtomPropertyContext = context.soapMtomProperty();
				if (soapMtomPropertyContext != null) 
				{
					return this.factory.SoapEncodingProperties((SoapMtomPropertyGreen)this.Visit(soapMtomPropertyContext), true);
				}
				SoalParser.SoapStylePropertyContext soapStylePropertyContext = context.soapStyleProperty();
				if (soapStylePropertyContext != null) 
				{
					return this.factory.SoapEncodingProperties((SoapStylePropertyGreen)this.Visit(soapStylePropertyContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitSoapVersionProperty(SoalParser.SoapVersionPropertyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken iVersion = (InternalSyntaxToken)this.VisitTerminal(context.IVersion());
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.SoapVersionProperty(iVersion, tAssign, identifier, tSemicolon, true);
			}
			
			public override GreenNode VisitSoapMtomProperty(SoalParser.SoapMtomPropertyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken imtom = (InternalSyntaxToken)this.VisitTerminal(context.IMTOM());
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				SoalParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				BooleanLiteralGreen booleanLiteral = null;
				if (booleanLiteralContext != null)
				{
					booleanLiteral = (BooleanLiteralGreen)this.Visit(booleanLiteralContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.SoapMtomProperty(imtom, tAssign, booleanLiteral, tSemicolon, true);
			}
			
			public override GreenNode VisitSoapStyleProperty(SoalParser.SoapStylePropertyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken iStyle = (InternalSyntaxToken)this.VisitTerminal(context.IStyle());
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.SoapStyleProperty(iStyle, tAssign, identifier, tSemicolon, true);
			}
			
			public override GreenNode VisitProtocolLayer(SoalParser.ProtocolLayerContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kProtocol = (InternalSyntaxToken)this.VisitTerminal(context.KProtocol());
				SoalParser.ProtocolLayerKindContext protocolLayerKindContext = context.protocolLayerKind();
				ProtocolLayerKindGreen protocolLayerKind = null;
				if (protocolLayerKindContext != null)
				{
					protocolLayerKind = (ProtocolLayerKindGreen)this.Visit(protocolLayerKindContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ProtocolLayer(kProtocol, protocolLayerKind, tSemicolon, true);
			}
			
			public override GreenNode VisitProtocolLayerKind(SoalParser.ProtocolLayerKindContext context)
			{
				if (context == null) return null;
				SoalParser.WsAddressingContext wsAddressingContext = context.wsAddressing();
				WsAddressingGreen wsAddressing = null;
				if (wsAddressingContext != null)
				{
					wsAddressing = (WsAddressingGreen)this.Visit(wsAddressingContext);
				}
				return this.factory.ProtocolLayerKind(wsAddressing, true);
			}
			
			public override GreenNode VisitWsAddressing(SoalParser.WsAddressingContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken iWsAddressing = (InternalSyntaxToken)this.VisitTerminal(context.IWsAddressing());
				return this.factory.WsAddressing(iWsAddressing, true);
			}
			
			public override GreenNode VisitEndpointDeclaration(SoalParser.EndpointDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kEndpoint = (InternalSyntaxToken)this.VisitTerminal(context.KEndpoint());
				SoalParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				SoalParser.EndpointBodyContext endpointBodyContext = context.endpointBody();
				EndpointBodyGreen endpointBody = null;
				if (endpointBodyContext != null)
				{
					endpointBody = (EndpointBodyGreen)this.Visit(endpointBodyContext);
				}
				return this.factory.EndpointDeclaration(kEndpoint, name, tColon, qualifier, endpointBody, true);
			}
			
			public override GreenNode VisitEndpointBody(SoalParser.EndpointBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				SoalParser.EndpointPropertiesContext endpointPropertiesContext = context.endpointProperties();
				EndpointPropertiesGreen endpointProperties = null;
				if (endpointPropertiesContext != null)
				{
					endpointProperties = (EndpointPropertiesGreen)this.Visit(endpointPropertiesContext);
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.EndpointBody(tOpenBrace, endpointProperties, tCloseBrace, true);
			}
			
			public override GreenNode VisitEndpointProperties(SoalParser.EndpointPropertiesContext context)
			{
				if (context == null) return null;
			    SoalParser.EndpointPropertyContext[] endpointPropertyContext = context.endpointProperty();
			    ArrayBuilder<EndpointPropertyGreen> endpointPropertyBuilder = ArrayBuilder<EndpointPropertyGreen>.GetInstance(endpointPropertyContext.Length);
			    for (int i = 0; i < endpointPropertyContext.Length; i++)
			    {
			        endpointPropertyBuilder.Add((EndpointPropertyGreen)this.Visit(endpointPropertyContext[i]));
			    }
				InternalSyntaxNodeList endpointProperty = InternalSyntaxNodeList.Create(endpointPropertyBuilder.ToArrayAndFree());
				return this.factory.EndpointProperties(endpointProperty, true);
			}
			
			public override GreenNode VisitEndpointProperty(SoalParser.EndpointPropertyContext context)
			{
				if (context == null) return null;
				SoalParser.EndpointBindingPropertyContext endpointBindingPropertyContext = context.endpointBindingProperty();
				if (endpointBindingPropertyContext != null) 
				{
					return this.factory.EndpointProperty((EndpointBindingPropertyGreen)this.Visit(endpointBindingPropertyContext), true);
				}
				SoalParser.EndpointAddressPropertyContext endpointAddressPropertyContext = context.endpointAddressProperty();
				if (endpointAddressPropertyContext != null) 
				{
					return this.factory.EndpointProperty((EndpointAddressPropertyGreen)this.Visit(endpointAddressPropertyContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitEndpointBindingProperty(SoalParser.EndpointBindingPropertyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kBinding = (InternalSyntaxToken)this.VisitTerminal(context.KBinding());
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.EndpointBindingProperty(kBinding, qualifier, tSemicolon, true);
			}
			
			public override GreenNode VisitEndpointAddressProperty(SoalParser.EndpointAddressPropertyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kAddress = (InternalSyntaxToken)this.VisitTerminal(context.KAddress());
				SoalParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null)
				{
					stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.EndpointAddressProperty(kAddress, stringLiteral, tSemicolon, true);
			}
			
			public override GreenNode VisitReturnType(SoalParser.ReturnTypeContext context)
			{
				if (context == null) return null;
				SoalParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return this.factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext), true);
				}
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return this.factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitTypeReference(SoalParser.TypeReferenceContext context)
			{
				if (context == null) return null;
				SoalParser.NonNullableArrayTypeContext nonNullableArrayTypeContext = context.nonNullableArrayType();
				if (nonNullableArrayTypeContext != null) 
				{
					return this.factory.TypeReference((NonNullableArrayTypeGreen)this.Visit(nonNullableArrayTypeContext), true);
				}
				SoalParser.ArrayTypeContext arrayTypeContext = context.arrayType();
				if (arrayTypeContext != null) 
				{
					return this.factory.TypeReference((ArrayTypeGreen)this.Visit(arrayTypeContext), true);
				}
				SoalParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return this.factory.TypeReference((SimpleTypeGreen)this.Visit(simpleTypeContext), true);
				}
				SoalParser.NulledTypeContext nulledTypeContext = context.nulledType();
				if (nulledTypeContext != null) 
				{
					return this.factory.TypeReference((NulledTypeGreen)this.Visit(nulledTypeContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitSimpleType(SoalParser.SimpleTypeContext context)
			{
				if (context == null) return null;
				SoalParser.ValueTypeContext valueTypeContext = context.valueType();
				if (valueTypeContext != null) 
				{
					return this.factory.SimpleType((ValueTypeGreen)this.Visit(valueTypeContext), true);
				}
				SoalParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					return this.factory.SimpleType((ObjectTypeGreen)this.Visit(objectTypeContext), true);
				}
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				if (qualifierContext != null) 
				{
					return this.factory.SimpleType((QualifierGreen)this.Visit(qualifierContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitNulledType(SoalParser.NulledTypeContext context)
			{
				if (context == null) return null;
				SoalParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					return this.factory.NulledType((NullableTypeGreen)this.Visit(nullableTypeContext), true);
				}
				SoalParser.NonNullableTypeContext nonNullableTypeContext = context.nonNullableType();
				if (nonNullableTypeContext != null) 
				{
					return this.factory.NulledType((NonNullableTypeGreen)this.Visit(nonNullableTypeContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitReferenceType(SoalParser.ReferenceTypeContext context)
			{
				if (context == null) return null;
				SoalParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					return this.factory.ReferenceType((ObjectTypeGreen)this.Visit(objectTypeContext), true);
				}
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				if (qualifierContext != null) 
				{
					return this.factory.ReferenceType((QualifierGreen)this.Visit(qualifierContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitObjectType(SoalParser.ObjectTypeContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken objectType = null;
				if (context.KObject() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KObject());
				}
				else 	if (context.KString() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KString());
				}
				return this.factory.ObjectType(objectType, true);
			}
			
			public override GreenNode VisitValueType(SoalParser.ValueTypeContext context)
			{
				if (context == null) return null;
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
				return this.factory.ValueType(valueType, true);
			}
			
			public override GreenNode VisitVoidType(SoalParser.VoidTypeContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid());
				return this.factory.VoidType(kVoid, true);
			}
			
			public override GreenNode VisitOnewayType(SoalParser.OnewayTypeContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kOneway = (InternalSyntaxToken)this.VisitTerminal(context.KOneway());
				return this.factory.OnewayType(kOneway, true);
			}
			
			public override GreenNode VisitOperationReturnType(SoalParser.OperationReturnTypeContext context)
			{
				if (context == null) return null;
				SoalParser.OnewayTypeContext onewayTypeContext = context.onewayType();
				if (onewayTypeContext != null) 
				{
					return this.factory.OperationReturnType((OnewayTypeGreen)this.Visit(onewayTypeContext), true);
				}
				SoalParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return this.factory.OperationReturnType((VoidTypeGreen)this.Visit(voidTypeContext), true);
				}
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return this.factory.OperationReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitNullableType(SoalParser.NullableTypeContext context)
			{
				if (context == null) return null;
				SoalParser.ValueTypeContext valueTypeContext = context.valueType();
				ValueTypeGreen valueType = null;
				if (valueTypeContext != null)
				{
					valueType = (ValueTypeGreen)this.Visit(valueTypeContext);
				}
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion());
				return this.factory.NullableType(valueType, tQuestion, true);
			}
			
			public override GreenNode VisitNonNullableType(SoalParser.NonNullableTypeContext context)
			{
				if (context == null) return null;
				SoalParser.ReferenceTypeContext referenceTypeContext = context.referenceType();
				ReferenceTypeGreen referenceType = null;
				if (referenceTypeContext != null)
				{
					referenceType = (ReferenceTypeGreen)this.Visit(referenceTypeContext);
				}
				InternalSyntaxToken tExclamation = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				return this.factory.NonNullableType(referenceType, tExclamation, true);
			}
			
			public override GreenNode VisitNonNullableArrayType(SoalParser.NonNullableArrayTypeContext context)
			{
				if (context == null) return null;
				SoalParser.ArrayTypeContext arrayTypeContext = context.arrayType();
				ArrayTypeGreen arrayType = null;
				if (arrayTypeContext != null)
				{
					arrayType = (ArrayTypeGreen)this.Visit(arrayTypeContext);
				}
				InternalSyntaxToken tExclamation = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				return this.factory.NonNullableArrayType(arrayType, tExclamation, true);
			}
			
			public override GreenNode VisitArrayType(SoalParser.ArrayTypeContext context)
			{
				if (context == null) return null;
				SoalParser.SimpleArrayTypeContext simpleArrayTypeContext = context.simpleArrayType();
				if (simpleArrayTypeContext != null) 
				{
					return this.factory.ArrayType((SimpleArrayTypeGreen)this.Visit(simpleArrayTypeContext), true);
				}
				SoalParser.NulledArrayTypeContext nulledArrayTypeContext = context.nulledArrayType();
				if (nulledArrayTypeContext != null) 
				{
					return this.factory.ArrayType((NulledArrayTypeGreen)this.Visit(nulledArrayTypeContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitSimpleArrayType(SoalParser.SimpleArrayTypeContext context)
			{
				if (context == null) return null;
				SoalParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				SimpleTypeGreen simpleType = null;
				if (simpleTypeContext != null)
				{
					simpleType = (SimpleTypeGreen)this.Visit(simpleTypeContext);
				}
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket());
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket());
				return this.factory.SimpleArrayType(simpleType, tOpenBracket, tCloseBracket, true);
			}
			
			public override GreenNode VisitNulledArrayType(SoalParser.NulledArrayTypeContext context)
			{
				if (context == null) return null;
				SoalParser.NulledTypeContext nulledTypeContext = context.nulledType();
				NulledTypeGreen nulledType = null;
				if (nulledTypeContext != null)
				{
					nulledType = (NulledTypeGreen)this.Visit(nulledTypeContext);
				}
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket());
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket());
				return this.factory.NulledArrayType(nulledType, tOpenBracket, tCloseBracket, true);
			}
			
			public override GreenNode VisitConstantValue(SoalParser.ConstantValueContext context)
			{
				if (context == null) return null;
				SoalParser.LiteralContext literalContext = context.literal();
				if (literalContext != null) 
				{
					return this.factory.ConstantValue((LiteralGreen)this.Visit(literalContext), true);
				}
				SoalParser.IdentifierContext identifierContext = context.identifier();
				if (identifierContext != null) 
				{
					return this.factory.ConstantValue((IdentifierGreen)this.Visit(identifierContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitTypeofValue(SoalParser.TypeofValueContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kTypeof = (InternalSyntaxToken)this.VisitTerminal(context.KTypeof());
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				SoalParser.ReturnTypeContext returnTypeContext = context.returnType();
				ReturnTypeGreen returnType = null;
				if (returnTypeContext != null)
				{
					returnType = (ReturnTypeGreen)this.Visit(returnTypeContext);
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				return this.factory.TypeofValue(kTypeof, tOpenParen, returnType, tCloseParen, true);
			}
			
			public override GreenNode VisitIdentifier(SoalParser.IdentifierContext context)
			{
				if (context == null) return null;
				SoalParser.IdentifiersContext identifiersContext = context.identifiers();
				if (identifiersContext != null) 
				{
					return this.factory.Identifier((IdentifiersGreen)this.Visit(identifiersContext), true);
				}
				SoalParser.ContextualKeywordsContext contextualKeywordsContext = context.contextualKeywords();
				if (contextualKeywordsContext != null) 
				{
					return this.factory.Identifier((ContextualKeywordsGreen)this.Visit(contextualKeywordsContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitIdentifiers(SoalParser.IdentifiersContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken identifiers = null;
				if (context.IdentifierNormal() != null)
				{
					identifiers = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierNormal());
				}
				else 	if (context.IdentifierVerbatim() != null)
				{
					identifiers = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierVerbatim());
				}
				return this.factory.Identifiers(identifiers, true);
			}
			
			public override GreenNode VisitLiteral(SoalParser.LiteralContext context)
			{
				if (context == null) return null;
				SoalParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return this.factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext), true);
				}
				SoalParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return this.factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext), true);
				}
				SoalParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return this.factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext), true);
				}
				SoalParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return this.factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext), true);
				}
				SoalParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return this.factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext), true);
				}
				SoalParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return this.factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitNullLiteral(SoalParser.NullLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull());
				return this.factory.NullLiteral(kNull, true);
			}
			
			public override GreenNode VisitBooleanLiteral(SoalParser.BooleanLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken booleanLiteral = null;
				if (context.KTrue() != null)
				{
					booleanLiteral = (InternalSyntaxToken)this.VisitTerminal(context.KTrue());
				}
				else 	if (context.KFalse() != null)
				{
					booleanLiteral = (InternalSyntaxToken)this.VisitTerminal(context.KFalse());
				}
				return this.factory.BooleanLiteral(booleanLiteral, true);
			}
			
			public override GreenNode VisitIntegerLiteral(SoalParser.IntegerLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger());
				return this.factory.IntegerLiteral(lInteger, true);
			}
			
			public override GreenNode VisitDecimalLiteral(SoalParser.DecimalLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal());
				return this.factory.DecimalLiteral(lDecimal, true);
			}
			
			public override GreenNode VisitScientificLiteral(SoalParser.ScientificLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific());
				return this.factory.ScientificLiteral(lScientific, true);
			}
			
			public override GreenNode VisitStringLiteral(SoalParser.StringLiteralContext context)
			{
				if (context == null) return null;
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
				return this.factory.StringLiteral(stringLiteral, true);
			}
			
			public override GreenNode VisitContextualKeywords(SoalParser.ContextualKeywordsContext context)
			{
				if (context == null) return null;
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
				return this.factory.ContextualKeywords(contextualKeywords, true);
			}
        }
    }
}

