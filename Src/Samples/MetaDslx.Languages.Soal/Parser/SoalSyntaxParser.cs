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
				if (namespaceDeclaration != null)
				{
				}
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
				GreenNode greenNode = this.factory.Name(identifier, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.QualifiedName(qualifier, true);
				return greenNode;
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
				if (identifier != null)
				{
				}
				GreenNode greenNode = this.factory.Qualifier(identifier, true);
				return greenNode;
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
				if (identifier != null)
				{
				}
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
				if (qualifier != null)
				{
				}
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
				if (annotation != null)
				{
				}
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
				if (returnAnnotation != null)
				{
				}
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
				GreenNode greenNode = this.factory.Annotation(tOpenBracket, annotationHead, tCloseBracket, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.ReturnAnnotation(tOpenBracket, kReturn, tColon, annotationHead, tCloseBracket, true);
				return greenNode;
			}
			
			public override GreenNode VisitAnnotationHead(SoalParser.AnnotationHeadContext context)
			{
				if (context == null) return null;
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				SoalParser.AnnotationBodyContext annotationBodyContext = context.annotationBody();
				AnnotationBodyGreen annotationBody = null;
				if (annotationBodyContext != null)
				{
					annotationBody = (AnnotationBodyGreen)this.Visit(annotationBodyContext);
				}
				return this.factory.AnnotationHead(identifier, annotationBody, true);
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
				if (annotationProperty != null)
				{
				}
				return this.factory.AnnotationPropertyList(annotationProperty, true);
			}
			
			public override GreenNode VisitAnnotationProperty(SoalParser.AnnotationPropertyContext context)
			{
				if (context == null) return null;
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				SoalParser.AnnotationPropertyValueContext annotationPropertyValueContext = context.annotationPropertyValue();
				AnnotationPropertyValueGreen annotationPropertyValue = null;
				if (annotationPropertyValueContext != null)
				{
					annotationPropertyValue = (AnnotationPropertyValueGreen)this.Visit(annotationPropertyValueContext);
				}
				GreenNode greenNode = this.factory.AnnotationProperty(identifier, tAssign, annotationPropertyValue, true);
				return greenNode;
			}
			
			public override GreenNode VisitAnnotationPropertyValue(SoalParser.AnnotationPropertyValueContext context)
			{
				if (context == null) return null;
				SoalParser.ConstantValueContext constantValueContext = context.constantValue();
				if (constantValueContext != null) 
				{
					GreenNode constantValue = this.factory.AnnotationPropertyValue((ConstantValueGreen)this.Visit(constantValueContext), true);
					return constantValue;
				}
				SoalParser.TypeofValueContext typeofValueContext = context.typeofValue();
				if (typeofValueContext != null) 
				{
					GreenNode typeofValue = this.factory.AnnotationPropertyValue((TypeofValueGreen)this.Visit(typeofValueContext), true);
					return typeofValue;
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
				GreenNode greenNode = this.factory.NamespaceDeclaration(annotationList, kNamespace, qualifiedName, tAssign, identifier, tColon, stringLiteral, namespaceBody, true);
				return greenNode;
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
				if (declaration != null)
				{
				}
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.NamespaceBody(tOpenBrace, declaration, tCloseBrace, true);
			}
			
			public override GreenNode VisitDeclaration(SoalParser.DeclarationContext context)
			{
				if (context == null) return null;
				SoalParser.EnumDeclarationContext enumDeclarationContext = context.enumDeclaration();
				if (enumDeclarationContext != null) 
				{
					GreenNode enumDeclaration = this.factory.Declaration((EnumDeclarationGreen)this.Visit(enumDeclarationContext), true);
					return enumDeclaration;
				}
				SoalParser.StructDeclarationContext structDeclarationContext = context.structDeclaration();
				if (structDeclarationContext != null) 
				{
					GreenNode structDeclaration = this.factory.Declaration((StructDeclarationGreen)this.Visit(structDeclarationContext), true);
					return structDeclaration;
				}
				SoalParser.DatabaseDeclarationContext databaseDeclarationContext = context.databaseDeclaration();
				if (databaseDeclarationContext != null) 
				{
					GreenNode databaseDeclaration = this.factory.Declaration((DatabaseDeclarationGreen)this.Visit(databaseDeclarationContext), true);
					return databaseDeclaration;
				}
				SoalParser.InterfaceDeclarationContext interfaceDeclarationContext = context.interfaceDeclaration();
				if (interfaceDeclarationContext != null) 
				{
					GreenNode interfaceDeclaration = this.factory.Declaration((InterfaceDeclarationGreen)this.Visit(interfaceDeclarationContext), true);
					return interfaceDeclaration;
				}
				SoalParser.ComponentDeclarationContext componentDeclarationContext = context.componentDeclaration();
				if (componentDeclarationContext != null) 
				{
					GreenNode componentDeclaration = this.factory.Declaration((ComponentDeclarationGreen)this.Visit(componentDeclarationContext), true);
					return componentDeclaration;
				}
				SoalParser.CompositeDeclarationContext compositeDeclarationContext = context.compositeDeclaration();
				if (compositeDeclarationContext != null) 
				{
					GreenNode compositeDeclaration = this.factory.Declaration((CompositeDeclarationGreen)this.Visit(compositeDeclarationContext), true);
					return compositeDeclaration;
				}
				SoalParser.AssemblyDeclarationContext assemblyDeclarationContext = context.assemblyDeclaration();
				if (assemblyDeclarationContext != null) 
				{
					GreenNode assemblyDeclaration = this.factory.Declaration((AssemblyDeclarationGreen)this.Visit(assemblyDeclarationContext), true);
					return assemblyDeclaration;
				}
				SoalParser.BindingDeclarationContext bindingDeclarationContext = context.bindingDeclaration();
				if (bindingDeclarationContext != null) 
				{
					GreenNode bindingDeclaration = this.factory.Declaration((BindingDeclarationGreen)this.Visit(bindingDeclarationContext), true);
					return bindingDeclaration;
				}
				SoalParser.EndpointDeclarationContext endpointDeclarationContext = context.endpointDeclaration();
				if (endpointDeclarationContext != null) 
				{
					GreenNode endpointDeclaration = this.factory.Declaration((EndpointDeclarationGreen)this.Visit(endpointDeclarationContext), true);
					return endpointDeclaration;
				}
				SoalParser.DeploymentDeclarationContext deploymentDeclarationContext = context.deploymentDeclaration();
				if (deploymentDeclarationContext != null) 
				{
					GreenNode deploymentDeclaration = this.factory.Declaration((DeploymentDeclarationGreen)this.Visit(deploymentDeclarationContext), true);
					return deploymentDeclaration;
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
				GreenNode greenNode = this.factory.EnumDeclaration(annotationList, kEnum, name, tColon, qualifier, enumBody, true);
				return greenNode;
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
				if (enumLiteral != null)
				{
				}
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
				GreenNode greenNode = this.factory.EnumLiteral(annotationList, name, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.StructDeclaration(annotationList, kStruct, name, tColon, qualifier, structBody, true);
				return greenNode;
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
				if (propertyDeclaration != null)
				{
				}
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
				GreenNode greenNode = this.factory.PropertyDeclaration(annotationList, typeReference, name, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.DatabaseDeclaration(annotationList, kDatabase, name, databaseBody, true);
				return greenNode;
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
				if (entityReference != null)
				{
				}
			    SoalParser.OperationDeclarationContext[] operationDeclarationContext = context.operationDeclaration();
			    ArrayBuilder<OperationDeclarationGreen> operationDeclarationBuilder = ArrayBuilder<OperationDeclarationGreen>.GetInstance(operationDeclarationContext.Length);
			    for (int i = 0; i < operationDeclarationContext.Length; i++)
			    {
			        operationDeclarationBuilder.Add((OperationDeclarationGreen)this.Visit(operationDeclarationContext[i]));
			    }
				InternalSyntaxNodeList operationDeclaration = InternalSyntaxNodeList.Create(operationDeclarationBuilder.ToArrayAndFree());
				if (operationDeclaration != null)
				{
				}
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
				GreenNode greenNode = this.factory.EntityReference(kEntity, qualifier, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.InterfaceDeclaration(annotationList, kInterface, name, interfaceBody, true);
				return greenNode;
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
				if (operationDeclaration != null)
				{
				}
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
				GreenNode greenNode = this.factory.OperationDeclaration(operationHead, tSemicolon, true);
				return greenNode;
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
				if (parameter != null)
				{
				}
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
				GreenNode greenNode = this.factory.Parameter(annotationList, typeReference, name, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.OperationResult(returnAnnotationList, operationReturnType, true);
				return greenNode;
			}
			
			public override GreenNode VisitComponentDeclaration(SoalParser.ComponentDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kAbstract = (InternalSyntaxToken)this.VisitTerminal(context.KAbstract());
				if (kAbstract != null)
				{
				}
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
				GreenNode greenNode = this.factory.ComponentDeclaration(kAbstract, kComponent, name, tColon, qualifier, componentBody, true);
				return greenNode;
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
				if (componentElement != null)
				{
				}
				return this.factory.ComponentElements(componentElement, true);
			}
			
			public override GreenNode VisitComponentElement(SoalParser.ComponentElementContext context)
			{
				if (context == null) return null;
				SoalParser.ComponentServiceContext componentServiceContext = context.componentService();
				if (componentServiceContext != null) 
				{
					GreenNode componentService = this.factory.ComponentElement((ComponentServiceGreen)this.Visit(componentServiceContext), true);
					return componentService;
				}
				SoalParser.ComponentReferenceContext componentReferenceContext = context.componentReference();
				if (componentReferenceContext != null) 
				{
					GreenNode componentReference = this.factory.ComponentElement((ComponentReferenceGreen)this.Visit(componentReferenceContext), true);
					return componentReference;
				}
				SoalParser.ComponentPropertyContext componentPropertyContext = context.componentProperty();
				if (componentPropertyContext != null) 
				{
					GreenNode componentProperty = this.factory.ComponentElement((ComponentPropertyGreen)this.Visit(componentPropertyContext), true);
					return componentProperty;
				}
				SoalParser.ComponentImplementationContext componentImplementationContext = context.componentImplementation();
				if (componentImplementationContext != null) 
				{
					GreenNode componentImplementation = this.factory.ComponentElement((ComponentImplementationGreen)this.Visit(componentImplementationContext), true);
					return componentImplementation;
				}
				SoalParser.ComponentLanguageContext componentLanguageContext = context.componentLanguage();
				if (componentLanguageContext != null) 
				{
					GreenNode componentLanguage = this.factory.ComponentElement((ComponentLanguageGreen)this.Visit(componentLanguageContext), true);
					return componentLanguage;
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
				GreenNode greenNode = this.factory.ComponentService(kService, qualifier, name, componentServiceOrReferenceBody, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.ComponentReference(kReference, qualifier, name, componentServiceOrReferenceBody, true);
				return greenNode;
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
				if (componentServiceOrReferenceElement != null)
				{
				}
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
				GreenNode greenNode = this.factory.ComponentProperty(typeReference, name, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.ComponentImplementation(kImplementation, name, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.ComponentLanguage(kLanguage, name, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.CompositeDeclaration(kComposite, name, tColon, qualifier, compositeBody, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.AssemblyDeclaration(kAssembly, name, tColon, qualifier, compositeBody, true);
				return greenNode;
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
				if (compositeElement != null)
				{
				}
				return this.factory.CompositeElements(compositeElement, true);
			}
			
			public override GreenNode VisitCompositeElement(SoalParser.CompositeElementContext context)
			{
				if (context == null) return null;
				SoalParser.ComponentServiceContext componentServiceContext = context.componentService();
				if (componentServiceContext != null) 
				{
					GreenNode componentService = this.factory.CompositeElement((ComponentServiceGreen)this.Visit(componentServiceContext), true);
					return componentService;
				}
				SoalParser.ComponentReferenceContext componentReferenceContext = context.componentReference();
				if (componentReferenceContext != null) 
				{
					GreenNode componentReference = this.factory.CompositeElement((ComponentReferenceGreen)this.Visit(componentReferenceContext), true);
					return componentReference;
				}
				SoalParser.ComponentPropertyContext componentPropertyContext = context.componentProperty();
				if (componentPropertyContext != null) 
				{
					GreenNode componentProperty = this.factory.CompositeElement((ComponentPropertyGreen)this.Visit(componentPropertyContext), true);
					return componentProperty;
				}
				SoalParser.ComponentImplementationContext componentImplementationContext = context.componentImplementation();
				if (componentImplementationContext != null) 
				{
					GreenNode componentImplementation = this.factory.CompositeElement((ComponentImplementationGreen)this.Visit(componentImplementationContext), true);
					return componentImplementation;
				}
				SoalParser.ComponentLanguageContext componentLanguageContext = context.componentLanguage();
				if (componentLanguageContext != null) 
				{
					GreenNode componentLanguage = this.factory.CompositeElement((ComponentLanguageGreen)this.Visit(componentLanguageContext), true);
					return componentLanguage;
				}
				SoalParser.CompositeComponentContext compositeComponentContext = context.compositeComponent();
				if (compositeComponentContext != null) 
				{
					GreenNode compositeComponent = this.factory.CompositeElement((CompositeComponentGreen)this.Visit(compositeComponentContext), true);
					return compositeComponent;
				}
				SoalParser.CompositeWireContext compositeWireContext = context.compositeWire();
				if (compositeWireContext != null) 
				{
					GreenNode compositeWire = this.factory.CompositeElement((CompositeWireGreen)this.Visit(compositeWireContext), true);
					return compositeWire;
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
				GreenNode greenNode = this.factory.CompositeComponent(kComponent, qualifier, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.CompositeWire(kWire, wireSource, kTo, wireTarget, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.DeploymentDeclaration(kDeployment, name, deploymentBody, true);
				return greenNode;
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
				if (deploymentElement != null)
				{
				}
				return this.factory.DeploymentElements(deploymentElement, true);
			}
			
			public override GreenNode VisitDeploymentElement(SoalParser.DeploymentElementContext context)
			{
				if (context == null) return null;
				SoalParser.EnvironmentDeclarationContext environmentDeclarationContext = context.environmentDeclaration();
				if (environmentDeclarationContext != null) 
				{
					GreenNode environmentDeclaration = this.factory.DeploymentElement((EnvironmentDeclarationGreen)this.Visit(environmentDeclarationContext), true);
					return environmentDeclaration;
				}
				SoalParser.CompositeWireContext compositeWireContext = context.compositeWire();
				if (compositeWireContext != null) 
				{
					GreenNode compositeWire = this.factory.DeploymentElement((CompositeWireGreen)this.Visit(compositeWireContext), true);
					return compositeWire;
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
				GreenNode greenNode = this.factory.EnvironmentDeclaration(kEnvironment, name, environmentBody, true);
				return greenNode;
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
				if (runtimeReference != null)
				{
				}
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
				GreenNode greenNode = this.factory.RuntimeDeclaration(kRuntime, name, tSemicolon, true);
				return greenNode;
			}
			
			public override GreenNode VisitRuntimeReference(SoalParser.RuntimeReferenceContext context)
			{
				if (context == null) return null;
				SoalParser.AssemblyReferenceContext assemblyReferenceContext = context.assemblyReference();
				if (assemblyReferenceContext != null) 
				{
					GreenNode assemblyReference = this.factory.RuntimeReference((AssemblyReferenceGreen)this.Visit(assemblyReferenceContext), true);
					return assemblyReference;
				}
				SoalParser.DatabaseReferenceContext databaseReferenceContext = context.databaseReference();
				if (databaseReferenceContext != null) 
				{
					GreenNode databaseReference = this.factory.RuntimeReference((DatabaseReferenceGreen)this.Visit(databaseReferenceContext), true);
					return databaseReference;
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
				GreenNode greenNode = this.factory.AssemblyReference(kAssembly, qualifier, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.DatabaseReference(kDatabase, qualifier, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.BindingDeclaration(kBinding, name, bindingBody, true);
				return greenNode;
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
				if (encodingLayer != null)
				{
				}
			    SoalParser.ProtocolLayerContext[] protocolLayerContext = context.protocolLayer();
			    ArrayBuilder<ProtocolLayerGreen> protocolLayerBuilder = ArrayBuilder<ProtocolLayerGreen>.GetInstance(protocolLayerContext.Length);
			    for (int i = 0; i < protocolLayerContext.Length; i++)
			    {
			        protocolLayerBuilder.Add((ProtocolLayerGreen)this.Visit(protocolLayerContext[i]));
			    }
				InternalSyntaxNodeList protocolLayer = InternalSyntaxNodeList.Create(protocolLayerBuilder.ToArrayAndFree());
				if (protocolLayer != null)
				{
				}
				return this.factory.BindingLayers(transportLayer, encodingLayer, protocolLayer, true);
			}
			
			public override GreenNode VisitTransportLayer(SoalParser.TransportLayerContext context)
			{
				if (context == null) return null;
				SoalParser.HttpTransportLayerContext httpTransportLayerContext = context.httpTransportLayer();
				if (httpTransportLayerContext != null) 
				{
					GreenNode httpTransportLayer = this.factory.TransportLayer((HttpTransportLayerGreen)this.Visit(httpTransportLayerContext), true);
					return httpTransportLayer;
				}
				SoalParser.RestTransportLayerContext restTransportLayerContext = context.restTransportLayer();
				if (restTransportLayerContext != null) 
				{
					GreenNode restTransportLayer = this.factory.TransportLayer((RestTransportLayerGreen)this.Visit(restTransportLayerContext), true);
					return restTransportLayer;
				}
				SoalParser.WebSocketTransportLayerContext webSocketTransportLayerContext = context.webSocketTransportLayer();
				if (webSocketTransportLayerContext != null) 
				{
					GreenNode webSocketTransportLayer = this.factory.TransportLayer((WebSocketTransportLayerGreen)this.Visit(webSocketTransportLayerContext), true);
					return webSocketTransportLayer;
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
				GreenNode greenNode = this.factory.HttpTransportLayer(kTransport, ihttp, httpTransportLayerBody, true);
				return greenNode;
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
				if (httpTransportLayerProperties != null)
				{
				}
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
				GreenNode greenNode = this.factory.RestTransportLayer(kTransport, irest, restTransportLayerBody, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.WebSocketTransportLayer(kTransport, iWebSocket, webSocketTransportLayerBody, true);
				return greenNode;
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
					GreenNode httpSslProperty = this.factory.HttpTransportLayerProperties((HttpSslPropertyGreen)this.Visit(httpSslPropertyContext), true);
					return httpSslProperty;
				}
				SoalParser.HttpClientAuthenticationPropertyContext httpClientAuthenticationPropertyContext = context.httpClientAuthenticationProperty();
				if (httpClientAuthenticationPropertyContext != null) 
				{
					GreenNode httpClientAuthenticationProperty = this.factory.HttpTransportLayerProperties((HttpClientAuthenticationPropertyGreen)this.Visit(httpClientAuthenticationPropertyContext), true);
					return httpClientAuthenticationProperty;
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
				GreenNode greenNode = this.factory.HttpSslProperty(issl, tAssign, booleanLiteral, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.HttpClientAuthenticationProperty(iClientAuthentication, tAssign, booleanLiteral, tSemicolon, true);
				return greenNode;
			}
			
			public override GreenNode VisitEncodingLayer(SoalParser.EncodingLayerContext context)
			{
				if (context == null) return null;
				SoalParser.SoapEncodingLayerContext soapEncodingLayerContext = context.soapEncodingLayer();
				if (soapEncodingLayerContext != null) 
				{
					GreenNode soapEncodingLayer = this.factory.EncodingLayer((SoapEncodingLayerGreen)this.Visit(soapEncodingLayerContext), true);
					return soapEncodingLayer;
				}
				SoalParser.XmlEncodingLayerContext xmlEncodingLayerContext = context.xmlEncodingLayer();
				if (xmlEncodingLayerContext != null) 
				{
					GreenNode xmlEncodingLayer = this.factory.EncodingLayer((XmlEncodingLayerGreen)this.Visit(xmlEncodingLayerContext), true);
					return xmlEncodingLayer;
				}
				SoalParser.JsonEncodingLayerContext jsonEncodingLayerContext = context.jsonEncodingLayer();
				if (jsonEncodingLayerContext != null) 
				{
					GreenNode jsonEncodingLayer = this.factory.EncodingLayer((JsonEncodingLayerGreen)this.Visit(jsonEncodingLayerContext), true);
					return jsonEncodingLayer;
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
				GreenNode greenNode = this.factory.SoapEncodingLayer(kEncoding, isoap, soapEncodingLayerBody, true);
				return greenNode;
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
				if (soapEncodingProperties != null)
				{
				}
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
				GreenNode greenNode = this.factory.XmlEncodingLayer(kEncoding, ixml, xmlEncodingLayerBody, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.JsonEncodingLayer(kEncoding, ijson, jsonEncodingLayerBody, true);
				return greenNode;
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
					GreenNode soapVersionProperty = this.factory.SoapEncodingProperties((SoapVersionPropertyGreen)this.Visit(soapVersionPropertyContext), true);
					return soapVersionProperty;
				}
				SoalParser.SoapMtomPropertyContext soapMtomPropertyContext = context.soapMtomProperty();
				if (soapMtomPropertyContext != null) 
				{
					GreenNode soapMtomProperty = this.factory.SoapEncodingProperties((SoapMtomPropertyGreen)this.Visit(soapMtomPropertyContext), true);
					return soapMtomProperty;
				}
				SoalParser.SoapStylePropertyContext soapStylePropertyContext = context.soapStyleProperty();
				if (soapStylePropertyContext != null) 
				{
					GreenNode soapStyleProperty = this.factory.SoapEncodingProperties((SoapStylePropertyGreen)this.Visit(soapStylePropertyContext), true);
					return soapStyleProperty;
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
				GreenNode greenNode = this.factory.SoapVersionProperty(iVersion, tAssign, identifier, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.SoapMtomProperty(imtom, tAssign, booleanLiteral, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.SoapStyleProperty(iStyle, tAssign, identifier, tSemicolon, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.ProtocolLayer(kProtocol, protocolLayerKind, tSemicolon, true);
				return greenNode;
			}
			
			public override GreenNode VisitProtocolLayerKind(SoalParser.ProtocolLayerKindContext context)
			{
				if (context == null) return null;
				SoalParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				return this.factory.ProtocolLayerKind(identifier, true);
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
				GreenNode greenNode = this.factory.EndpointDeclaration(kEndpoint, name, tColon, qualifier, endpointBody, true);
				return greenNode;
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
				if (endpointProperty != null)
				{
				}
				return this.factory.EndpointProperties(endpointProperty, true);
			}
			
			public override GreenNode VisitEndpointProperty(SoalParser.EndpointPropertyContext context)
			{
				if (context == null) return null;
				SoalParser.EndpointBindingPropertyContext endpointBindingPropertyContext = context.endpointBindingProperty();
				if (endpointBindingPropertyContext != null) 
				{
					GreenNode endpointBindingProperty = this.factory.EndpointProperty((EndpointBindingPropertyGreen)this.Visit(endpointBindingPropertyContext), true);
					return endpointBindingProperty;
				}
				SoalParser.EndpointAddressPropertyContext endpointAddressPropertyContext = context.endpointAddressProperty();
				if (endpointAddressPropertyContext != null) 
				{
					GreenNode endpointAddressProperty = this.factory.EndpointProperty((EndpointAddressPropertyGreen)this.Visit(endpointAddressPropertyContext), true);
					return endpointAddressProperty;
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
				SoalParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					GreenNode typeReference = this.factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext), true);
					return typeReference;
				}
				SoalParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					GreenNode voidType = this.factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext), true);
					return voidType;
				}
				return null;
			}
			
			public override GreenNode VisitTypeReference(SoalParser.TypeReferenceContext context)
			{
				if (context == null) return null;
				SoalParser.NonNullableArrayTypeContext nonNullableArrayTypeContext = context.nonNullableArrayType();
				if (nonNullableArrayTypeContext != null) 
				{
					GreenNode nonNullableArrayType = this.factory.TypeReference((NonNullableArrayTypeGreen)this.Visit(nonNullableArrayTypeContext), true);
					return nonNullableArrayType;
				}
				SoalParser.ArrayTypeContext arrayTypeContext = context.arrayType();
				if (arrayTypeContext != null) 
				{
					GreenNode arrayType = this.factory.TypeReference((ArrayTypeGreen)this.Visit(arrayTypeContext), true);
					return arrayType;
				}
				SoalParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					GreenNode simpleType = this.factory.TypeReference((SimpleTypeGreen)this.Visit(simpleTypeContext), true);
					return simpleType;
				}
				SoalParser.NulledTypeContext nulledTypeContext = context.nulledType();
				if (nulledTypeContext != null) 
				{
					GreenNode nulledType = this.factory.TypeReference((NulledTypeGreen)this.Visit(nulledTypeContext), true);
					return nulledType;
				}
				return null;
			}
			
			public override GreenNode VisitSimpleType(SoalParser.SimpleTypeContext context)
			{
				if (context == null) return null;
				SoalParser.ValueTypeContext valueTypeContext = context.valueType();
				if (valueTypeContext != null) 
				{
					GreenNode valueType = this.factory.SimpleType((ValueTypeGreen)this.Visit(valueTypeContext), true);
					return valueType;
				}
				SoalParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					GreenNode objectType = this.factory.SimpleType((ObjectTypeGreen)this.Visit(objectTypeContext), true);
					return objectType;
				}
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				if (qualifierContext != null) 
				{
					GreenNode qualifier = this.factory.SimpleType((QualifierGreen)this.Visit(qualifierContext), true);
					return qualifier;
				}
				return null;
			}
			
			public override GreenNode VisitNulledType(SoalParser.NulledTypeContext context)
			{
				if (context == null) return null;
				SoalParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					GreenNode nullableType = this.factory.NulledType((NullableTypeGreen)this.Visit(nullableTypeContext), true);
					return nullableType;
				}
				SoalParser.NonNullableTypeContext nonNullableTypeContext = context.nonNullableType();
				if (nonNullableTypeContext != null) 
				{
					GreenNode nonNullableType = this.factory.NulledType((NonNullableTypeGreen)this.Visit(nonNullableTypeContext), true);
					return nonNullableType;
				}
				return null;
			}
			
			public override GreenNode VisitReferenceType(SoalParser.ReferenceTypeContext context)
			{
				if (context == null) return null;
				SoalParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					GreenNode objectType = this.factory.ReferenceType((ObjectTypeGreen)this.Visit(objectTypeContext), true);
					return objectType;
				}
				SoalParser.QualifierContext qualifierContext = context.qualifier();
				if (qualifierContext != null) 
				{
					GreenNode qualifier = this.factory.ReferenceType((QualifierGreen)this.Visit(qualifierContext), true);
					return qualifier;
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
				GreenNode greenNode = this.factory.ObjectType(objectType, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.ValueType(valueType, true);
				return greenNode;
			}
			
			public override GreenNode VisitVoidType(SoalParser.VoidTypeContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid());
				GreenNode greenNode = this.factory.VoidType(kVoid, true);
				return greenNode;
			}
			
			public override GreenNode VisitOnewayType(SoalParser.OnewayTypeContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kOneway = (InternalSyntaxToken)this.VisitTerminal(context.KOneway());
				GreenNode greenNode = this.factory.OnewayType(kOneway, true);
				return greenNode;
			}
			
			public override GreenNode VisitOperationReturnType(SoalParser.OperationReturnTypeContext context)
			{
				if (context == null) return null;
				SoalParser.ReturnTypeContext returnTypeContext = context.returnType();
				if (returnTypeContext != null) 
				{
					GreenNode returnType = this.factory.OperationReturnType((ReturnTypeGreen)this.Visit(returnTypeContext), true);
					return returnType;
				}
				SoalParser.OnewayTypeContext onewayTypeContext = context.onewayType();
				if (onewayTypeContext != null) 
				{
					GreenNode onewayType = this.factory.OperationReturnType((OnewayTypeGreen)this.Visit(onewayTypeContext), true);
					return onewayType;
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
				GreenNode greenNode = this.factory.NullableType(valueType, tQuestion, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.NonNullableType(referenceType, tExclamation, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.NonNullableArrayType(arrayType, tExclamation, true);
				return greenNode;
			}
			
			public override GreenNode VisitArrayType(SoalParser.ArrayTypeContext context)
			{
				if (context == null) return null;
				SoalParser.SimpleArrayTypeContext simpleArrayTypeContext = context.simpleArrayType();
				if (simpleArrayTypeContext != null) 
				{
					GreenNode simpleArrayType = this.factory.ArrayType((SimpleArrayTypeGreen)this.Visit(simpleArrayTypeContext), true);
					return simpleArrayType;
				}
				SoalParser.NulledArrayTypeContext nulledArrayTypeContext = context.nulledArrayType();
				if (nulledArrayTypeContext != null) 
				{
					GreenNode nulledArrayType = this.factory.ArrayType((NulledArrayTypeGreen)this.Visit(nulledArrayTypeContext), true);
					return nulledArrayType;
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
				GreenNode greenNode = this.factory.SimpleArrayType(simpleType, tOpenBracket, tCloseBracket, true);
				return greenNode;
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
				GreenNode greenNode = this.factory.NulledArrayType(nulledType, tOpenBracket, tCloseBracket, true);
				return greenNode;
			}
			
			public override GreenNode VisitConstantValue(SoalParser.ConstantValueContext context)
			{
				if (context == null) return null;
				SoalParser.LiteralContext literalContext = context.literal();
				if (literalContext != null) 
				{
					GreenNode literal = this.factory.ConstantValue((LiteralGreen)this.Visit(literalContext), true);
					return literal;
				}
				SoalParser.IdentifierContext identifierContext = context.identifier();
				if (identifierContext != null) 
				{
					GreenNode identifier = this.factory.ConstantValue((IdentifierGreen)this.Visit(identifierContext), true);
					return identifier;
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
					GreenNode identifiers = this.factory.Identifier((IdentifiersGreen)this.Visit(identifiersContext), true);
					return identifiers;
				}
				SoalParser.ContextualKeywordsContext contextualKeywordsContext = context.contextualKeywords();
				if (contextualKeywordsContext != null) 
				{
					GreenNode contextualKeywords = this.factory.Identifier((ContextualKeywordsGreen)this.Visit(contextualKeywordsContext), true);
					return contextualKeywords;
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
					GreenNode nullLiteral = this.factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext), true);
					return nullLiteral;
				}
				SoalParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					GreenNode booleanLiteral = this.factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext), true);
					return booleanLiteral;
				}
				SoalParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					GreenNode integerLiteral = this.factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext), true);
					return integerLiteral;
				}
				SoalParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					GreenNode decimalLiteral = this.factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext), true);
					return decimalLiteral;
				}
				SoalParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					GreenNode scientificLiteral = this.factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext), true);
					return scientificLiteral;
				}
				SoalParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					GreenNode stringLiteral = this.factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext), true);
					return stringLiteral;
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

