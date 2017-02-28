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
namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax
{
    public class MetaModelSyntaxParser : Antlr4SyntaxParser<MetaModelLexer, MetaModelParser>
    {
        public MetaModelSyntaxParser(
            SourceText text,
            MetaModelParseOptions options,
            SyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
            : base(text, MetaModelLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }
        public override DirectiveStack Directives
        {
            get
            {
                return DirectiveStack.Empty;
            }
        }
        protected override MetaModelLexer CreateLexer(AntlrInputStream inputStream)
        {
            return new MetaModelLexer(inputStream);
        }
        protected override MetaModelParser CreateParser(CommonTokenStream tokenStream)
        {
            return new MetaModelParser(tokenStream);
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
        private class Antlr4ToRoslynVisitor : MetaModelParserBaseVisitor<GreenNode>
        {
            private MetaModelLanguage language;
			private MetaModelGreenFactory factory;
            private MetaModelSyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastToken;
            public Antlr4ToRoslynVisitor(MetaModelSyntaxParser syntaxParser)
            {
                this.language = MetaModelLanguage.Instance;
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
			
			public override GreenNode VisitMain(MetaModelParser.MainContext context)
			{
				if (context == null) return null;
				MetaModelParser.NamespaceDeclarationContext namespaceDeclarationContext = context.namespaceDeclaration();
				NamespaceDeclarationGreen namespaceDeclaration = null;
				if (namespaceDeclarationContext != null)
				{
					namespaceDeclaration = (NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext);
				}
				return this.factory.Main(namespaceDeclaration, true);
			}
			
			public override GreenNode VisitName(MetaModelParser.NameContext context)
			{
				if (context == null) return null;
				MetaModelParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				return this.factory.Name(identifier, true);
			}
			
			public override GreenNode VisitQualifiedName(MetaModelParser.QualifiedNameContext context)
			{
				if (context == null) return null;
				MetaModelParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.QualifiedName(qualifier, true);
			}
			
			public override GreenNode VisitQualifier(MetaModelParser.QualifierContext context)
			{
				if (context == null) return null;
			    MetaModelParser.IdentifierContext[] identifierContext = context.identifier();
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
			
			public override GreenNode VisitAnnotation(MetaModelParser.AnnotationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket());
				MetaModelParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket());
				return this.factory.Annotation(tOpenBracket, name, tCloseBracket, true);
			}
			
			public override GreenNode VisitNamespaceDeclaration(MetaModelParser.NamespaceDeclarationContext context)
			{
				if (context == null) return null;
			    MetaModelParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace());
				MetaModelParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				MetaModelParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null)
				{
					namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				}
				return this.factory.NamespaceDeclaration(annotation, kNamespace, qualifiedName, namespaceBody, true);
			}
			
			public override GreenNode VisitNamespaceBody(MetaModelParser.NamespaceBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				MetaModelParser.MetamodelDeclarationContext metamodelDeclarationContext = context.metamodelDeclaration();
				MetamodelDeclarationGreen metamodelDeclaration = null;
				if (metamodelDeclarationContext != null)
				{
					metamodelDeclaration = (MetamodelDeclarationGreen)this.Visit(metamodelDeclarationContext);
				}
			    MetaModelParser.DeclarationContext[] declarationContext = context.declaration();
			    ArrayBuilder<DeclarationGreen> declarationBuilder = ArrayBuilder<DeclarationGreen>.GetInstance(declarationContext.Length);
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				InternalSyntaxNodeList declaration = InternalSyntaxNodeList.Create(declarationBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.NamespaceBody(tOpenBrace, metamodelDeclaration, declaration, tCloseBrace, true);
			}
			
			public override GreenNode VisitMetamodelDeclaration(MetaModelParser.MetamodelDeclarationContext context)
			{
				if (context == null) return null;
			    MetaModelParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				InternalSyntaxToken kMetamodel = (InternalSyntaxToken)this.VisitTerminal(context.KMetamodel());
				MetaModelParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				MetaModelParser.MetamodelPropertyListContext metamodelPropertyListContext = context.metamodelPropertyList();
				MetamodelPropertyListGreen metamodelPropertyList = null;
				if (metamodelPropertyListContext != null)
				{
					metamodelPropertyList = (MetamodelPropertyListGreen)this.Visit(metamodelPropertyListContext);
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.MetamodelDeclaration(annotation, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon, true);
			}
			
			public override GreenNode VisitMetamodelPropertyList(MetaModelParser.MetamodelPropertyListContext context)
			{
				if (context == null) return null;
			    MetaModelParser.MetamodelPropertyContext[] metamodelPropertyContext = context.metamodelProperty();
			    ITerminalNode[] tCommaContext = context.TComma();
			    ArrayBuilder<GreenNode> metamodelPropertyBuilder = ArrayBuilder<GreenNode>.GetInstance(metamodelPropertyContext.Length+tCommaContext.Length);
			    for (int i = 0; i < metamodelPropertyContext.Length; i++)
			    {
			        metamodelPropertyBuilder.Add((MetamodelPropertyGreen)this.Visit(metamodelPropertyContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            metamodelPropertyBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList metamodelProperty = InternalSeparatedSyntaxNodeList.Create(metamodelPropertyBuilder.ToArrayAndFree());
				return this.factory.MetamodelPropertyList(metamodelProperty, true);
			}
			
			public override GreenNode VisitMetamodelProperty(MetaModelParser.MetamodelPropertyContext context)
			{
				if (context == null) return null;
				MetaModelParser.MetamodelUriPropertyContext metamodelUriPropertyContext = context.metamodelUriProperty();
				MetamodelUriPropertyGreen metamodelUriProperty = null;
				if (metamodelUriPropertyContext != null)
				{
					metamodelUriProperty = (MetamodelUriPropertyGreen)this.Visit(metamodelUriPropertyContext);
				}
				return this.factory.MetamodelProperty(metamodelUriProperty, true);
			}
			
			public override GreenNode VisitMetamodelUriProperty(MetaModelParser.MetamodelUriPropertyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken iUri = (InternalSyntaxToken)this.VisitTerminal(context.IUri());
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				MetaModelParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null)
				{
					stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				}
				return this.factory.MetamodelUriProperty(iUri, tAssign, stringLiteral, true);
			}
			
			public override GreenNode VisitDeclaration(MetaModelParser.DeclarationContext context)
			{
				if (context == null) return null;
				MetaModelParser.EnumDeclarationContext enumDeclarationContext = context.enumDeclaration();
				if (enumDeclarationContext != null) 
				{
					return this.factory.Declaration((EnumDeclarationGreen)this.Visit(enumDeclarationContext), true);
				}
				MetaModelParser.ClassDeclarationContext classDeclarationContext = context.classDeclaration();
				if (classDeclarationContext != null) 
				{
					return this.factory.Declaration((ClassDeclarationGreen)this.Visit(classDeclarationContext), true);
				}
				MetaModelParser.AssociationDeclarationContext associationDeclarationContext = context.associationDeclaration();
				if (associationDeclarationContext != null) 
				{
					return this.factory.Declaration((AssociationDeclarationGreen)this.Visit(associationDeclarationContext), true);
				}
				MetaModelParser.ConstDeclarationContext constDeclarationContext = context.constDeclaration();
				if (constDeclarationContext != null) 
				{
					return this.factory.Declaration((ConstDeclarationGreen)this.Visit(constDeclarationContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitEnumDeclaration(MetaModelParser.EnumDeclarationContext context)
			{
				if (context == null) return null;
			    MetaModelParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				InternalSyntaxToken kEnum = (InternalSyntaxToken)this.VisitTerminal(context.KEnum());
				MetaModelParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				MetaModelParser.EnumBodyContext enumBodyContext = context.enumBody();
				EnumBodyGreen enumBody = null;
				if (enumBodyContext != null)
				{
					enumBody = (EnumBodyGreen)this.Visit(enumBodyContext);
				}
				return this.factory.EnumDeclaration(annotation, kEnum, name, enumBody, true);
			}
			
			public override GreenNode VisitEnumBody(MetaModelParser.EnumBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				MetaModelParser.EnumValuesContext enumValuesContext = context.enumValues();
				EnumValuesGreen enumValues = null;
				if (enumValuesContext != null)
				{
					enumValues = (EnumValuesGreen)this.Visit(enumValuesContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
			    MetaModelParser.EnumMemberDeclarationContext[] enumMemberDeclarationContext = context.enumMemberDeclaration();
			    ArrayBuilder<EnumMemberDeclarationGreen> enumMemberDeclarationBuilder = ArrayBuilder<EnumMemberDeclarationGreen>.GetInstance(enumMemberDeclarationContext.Length);
			    for (int i = 0; i < enumMemberDeclarationContext.Length; i++)
			    {
			        enumMemberDeclarationBuilder.Add((EnumMemberDeclarationGreen)this.Visit(enumMemberDeclarationContext[i]));
			    }
				InternalSyntaxNodeList enumMemberDeclaration = InternalSyntaxNodeList.Create(enumMemberDeclarationBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace, true);
			}
			
			public override GreenNode VisitEnumValues(MetaModelParser.EnumValuesContext context)
			{
				if (context == null) return null;
			    MetaModelParser.EnumValueContext[] enumValueContext = context.enumValue();
			    ITerminalNode[] tCommaContext = context.TComma();
			    ArrayBuilder<GreenNode> enumValueBuilder = ArrayBuilder<GreenNode>.GetInstance(enumValueContext.Length+tCommaContext.Length);
			    for (int i = 0; i < enumValueContext.Length; i++)
			    {
			        enumValueBuilder.Add((EnumValueGreen)this.Visit(enumValueContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            enumValueBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList enumValue = InternalSeparatedSyntaxNodeList.Create(enumValueBuilder.ToArrayAndFree());
				return this.factory.EnumValues(enumValue, true);
			}
			
			public override GreenNode VisitEnumValue(MetaModelParser.EnumValueContext context)
			{
				if (context == null) return null;
			    MetaModelParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				MetaModelParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				return this.factory.EnumValue(annotation, name, true);
			}
			
			public override GreenNode VisitEnumMemberDeclaration(MetaModelParser.EnumMemberDeclarationContext context)
			{
				if (context == null) return null;
				MetaModelParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				OperationDeclarationGreen operationDeclaration = null;
				if (operationDeclarationContext != null)
				{
					operationDeclaration = (OperationDeclarationGreen)this.Visit(operationDeclarationContext);
				}
				return this.factory.EnumMemberDeclaration(operationDeclaration, true);
			}
			
			public override GreenNode VisitClassDeclaration(MetaModelParser.ClassDeclarationContext context)
			{
				if (context == null) return null;
			    MetaModelParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				InternalSyntaxToken kAbstract = (InternalSyntaxToken)this.VisitTerminal(context.KAbstract());
				InternalSyntaxToken kClass = (InternalSyntaxToken)this.VisitTerminal(context.KClass());
				MetaModelParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				MetaModelParser.ClassAncestorsContext classAncestorsContext = context.classAncestors();
				ClassAncestorsGreen classAncestors = null;
				if (classAncestorsContext != null)
				{
					classAncestors = (ClassAncestorsGreen)this.Visit(classAncestorsContext);
				}
				MetaModelParser.ClassBodyContext classBodyContext = context.classBody();
				ClassBodyGreen classBody = null;
				if (classBodyContext != null)
				{
					classBody = (ClassBodyGreen)this.Visit(classBodyContext);
				}
				return this.factory.ClassDeclaration(annotation, kAbstract, kClass, name, tColon, classAncestors, classBody, true);
			}
			
			public override GreenNode VisitClassBody(MetaModelParser.ClassBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    MetaModelParser.ClassMemberDeclarationContext[] classMemberDeclarationContext = context.classMemberDeclaration();
			    ArrayBuilder<ClassMemberDeclarationGreen> classMemberDeclarationBuilder = ArrayBuilder<ClassMemberDeclarationGreen>.GetInstance(classMemberDeclarationContext.Length);
			    for (int i = 0; i < classMemberDeclarationContext.Length; i++)
			    {
			        classMemberDeclarationBuilder.Add((ClassMemberDeclarationGreen)this.Visit(classMemberDeclarationContext[i]));
			    }
				InternalSyntaxNodeList classMemberDeclaration = InternalSyntaxNodeList.Create(classMemberDeclarationBuilder.ToArrayAndFree());
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace, true);
			}
			
			public override GreenNode VisitClassAncestors(MetaModelParser.ClassAncestorsContext context)
			{
				if (context == null) return null;
			    MetaModelParser.ClassAncestorContext[] classAncestorContext = context.classAncestor();
			    ITerminalNode[] tCommaContext = context.TComma();
			    ArrayBuilder<GreenNode> classAncestorBuilder = ArrayBuilder<GreenNode>.GetInstance(classAncestorContext.Length+tCommaContext.Length);
			    for (int i = 0; i < classAncestorContext.Length; i++)
			    {
			        classAncestorBuilder.Add((ClassAncestorGreen)this.Visit(classAncestorContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            classAncestorBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList classAncestor = InternalSeparatedSyntaxNodeList.Create(classAncestorBuilder.ToArrayAndFree());
				return this.factory.ClassAncestors(classAncestor, true);
			}
			
			public override GreenNode VisitClassAncestor(MetaModelParser.ClassAncestorContext context)
			{
				if (context == null) return null;
				MetaModelParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.ClassAncestor(qualifier, true);
			}
			
			public override GreenNode VisitClassMemberDeclaration(MetaModelParser.ClassMemberDeclarationContext context)
			{
				if (context == null) return null;
				MetaModelParser.FieldDeclarationContext fieldDeclarationContext = context.fieldDeclaration();
				if (fieldDeclarationContext != null) 
				{
					return this.factory.ClassMemberDeclaration((FieldDeclarationGreen)this.Visit(fieldDeclarationContext), true);
				}
				MetaModelParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				if (operationDeclarationContext != null) 
				{
					return this.factory.ClassMemberDeclaration((OperationDeclarationGreen)this.Visit(operationDeclarationContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitFieldDeclaration(MetaModelParser.FieldDeclarationContext context)
			{
				if (context == null) return null;
			    MetaModelParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				MetaModelParser.FieldModifierContext fieldModifierContext = context.fieldModifier();
				FieldModifierGreen fieldModifier = null;
				if (fieldModifierContext != null)
				{
					fieldModifier = (FieldModifierGreen)this.Visit(fieldModifierContext);
				}
				MetaModelParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				MetaModelParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				MetaModelParser.RedefinitionsOrSubsettingsContext redefinitionsOrSubsettingsContext = context.redefinitionsOrSubsettings();
				RedefinitionsOrSubsettingsGreen redefinitionsOrSubsettings = null;
				if (redefinitionsOrSubsettingsContext != null)
				{
					redefinitionsOrSubsettings = (RedefinitionsOrSubsettingsGreen)this.Visit(redefinitionsOrSubsettingsContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.FieldDeclaration(annotation, fieldModifier, typeReference, name, redefinitionsOrSubsettings, tSemicolon, true);
			}
			
			public override GreenNode VisitFieldModifier(MetaModelParser.FieldModifierContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken fieldModifier = null;
				if (context.KContainment() != null)
				{
					fieldModifier = (InternalSyntaxToken)this.VisitTerminal(context.KContainment());
				}
				else 	if (context.KReadonly() != null)
				{
					fieldModifier = (InternalSyntaxToken)this.VisitTerminal(context.KReadonly());
				}
				else 	if (context.KLazy() != null)
				{
					fieldModifier = (InternalSyntaxToken)this.VisitTerminal(context.KLazy());
				}
				else 	if (context.KDerived() != null)
				{
					fieldModifier = (InternalSyntaxToken)this.VisitTerminal(context.KDerived());
				}
				return this.factory.FieldModifier(fieldModifier, true);
			}
			
			public override GreenNode VisitRedefinitionsOrSubsettings(MetaModelParser.RedefinitionsOrSubsettingsContext context)
			{
				if (context == null) return null;
				MetaModelParser.RedefinitionsContext redefinitionsContext = context.redefinitions();
				if (redefinitionsContext != null) 
				{
					return this.factory.RedefinitionsOrSubsettings((RedefinitionsGreen)this.Visit(redefinitionsContext), true);
				}
				MetaModelParser.SubsettingsContext subsettingsContext = context.subsettings();
				if (subsettingsContext != null) 
				{
					return this.factory.RedefinitionsOrSubsettings((SubsettingsGreen)this.Visit(subsettingsContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitRedefinitions(MetaModelParser.RedefinitionsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kRedefines = (InternalSyntaxToken)this.VisitTerminal(context.KRedefines());
				MetaModelParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null)
				{
					nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				}
				return this.factory.Redefinitions(kRedefines, nameUseList, true);
			}
			
			public override GreenNode VisitSubsettings(MetaModelParser.SubsettingsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kSubsets = (InternalSyntaxToken)this.VisitTerminal(context.KSubsets());
				MetaModelParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null)
				{
					nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				}
				return this.factory.Subsettings(kSubsets, nameUseList, true);
			}
			
			public override GreenNode VisitNameUseList(MetaModelParser.NameUseListContext context)
			{
				if (context == null) return null;
			    MetaModelParser.QualifierContext[] qualifierContext = context.qualifier();
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
				return this.factory.NameUseList(qualifier, true);
			}
			
			public override GreenNode VisitConstDeclaration(MetaModelParser.ConstDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kConst = (InternalSyntaxToken)this.VisitTerminal(context.KConst());
				MetaModelParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				MetaModelParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ConstDeclaration(kConst, typeReference, name, tSemicolon, true);
			}
			
			public override GreenNode VisitReturnType(MetaModelParser.ReturnTypeContext context)
			{
				if (context == null) return null;
				MetaModelParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return this.factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext), true);
				}
				MetaModelParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return this.factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitTypeOfReference(MetaModelParser.TypeOfReferenceContext context)
			{
				if (context == null) return null;
				MetaModelParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				return this.factory.TypeOfReference(typeReference, true);
			}
			
			public override GreenNode VisitTypeReference(MetaModelParser.TypeReferenceContext context)
			{
				if (context == null) return null;
				MetaModelParser.CollectionTypeContext collectionTypeContext = context.collectionType();
				if (collectionTypeContext != null) 
				{
					return this.factory.TypeReference((CollectionTypeGreen)this.Visit(collectionTypeContext), true);
				}
				MetaModelParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return this.factory.TypeReference((SimpleTypeGreen)this.Visit(simpleTypeContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitSimpleType(MetaModelParser.SimpleTypeContext context)
			{
				if (context == null) return null;
				MetaModelParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				if (primitiveTypeContext != null) 
				{
					return this.factory.SimpleType((PrimitiveTypeGreen)this.Visit(primitiveTypeContext), true);
				}
				MetaModelParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					return this.factory.SimpleType((ObjectTypeGreen)this.Visit(objectTypeContext), true);
				}
				MetaModelParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					return this.factory.SimpleType((NullableTypeGreen)this.Visit(nullableTypeContext), true);
				}
				MetaModelParser.QualifierContext qualifierContext = context.qualifier();
				if (qualifierContext != null) 
				{
					return this.factory.SimpleType((QualifierGreen)this.Visit(qualifierContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitClassType(MetaModelParser.ClassTypeContext context)
			{
				if (context == null) return null;
				MetaModelParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.ClassType(qualifier, true);
			}
			
			public override GreenNode VisitObjectType(MetaModelParser.ObjectTypeContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken objectType = null;
				if (context.KObject() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KObject());
				}
				else 	if (context.KSymbol() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KSymbol());
				}
				else 	if (context.KString() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KString());
				}
				return this.factory.ObjectType(objectType, true);
			}
			
			public override GreenNode VisitPrimitiveType(MetaModelParser.PrimitiveTypeContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken primitiveType = null;
				if (context.KInt() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KInt());
				}
				else 	if (context.KLong() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KLong());
				}
				else 	if (context.KFloat() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KFloat());
				}
				else 	if (context.KDouble() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KDouble());
				}
				else 	if (context.KByte() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KByte());
				}
				else 	if (context.KBool() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KBool());
				}
				return this.factory.PrimitiveType(primitiveType, true);
			}
			
			public override GreenNode VisitVoidType(MetaModelParser.VoidTypeContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid());
				return this.factory.VoidType(kVoid, true);
			}
			
			public override GreenNode VisitNullableType(MetaModelParser.NullableTypeContext context)
			{
				if (context == null) return null;
				MetaModelParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				PrimitiveTypeGreen primitiveType = null;
				if (primitiveTypeContext != null)
				{
					primitiveType = (PrimitiveTypeGreen)this.Visit(primitiveTypeContext);
				}
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion());
				return this.factory.NullableType(primitiveType, tQuestion, true);
			}
			
			public override GreenNode VisitCollectionType(MetaModelParser.CollectionTypeContext context)
			{
				if (context == null) return null;
				MetaModelParser.CollectionKindContext collectionKindContext = context.collectionKind();
				CollectionKindGreen collectionKind = null;
				if (collectionKindContext != null)
				{
					collectionKind = (CollectionKindGreen)this.Visit(collectionKindContext);
				}
				InternalSyntaxToken tLessThan = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan());
				MetaModelParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				SimpleTypeGreen simpleType = null;
				if (simpleTypeContext != null)
				{
					simpleType = (SimpleTypeGreen)this.Visit(simpleTypeContext);
				}
				InternalSyntaxToken tGreaterThan = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan());
				return this.factory.CollectionType(collectionKind, tLessThan, simpleType, tGreaterThan, true);
			}
			
			public override GreenNode VisitCollectionKind(MetaModelParser.CollectionKindContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken collectionKind = null;
				if (context.KSet() != null)
				{
					collectionKind = (InternalSyntaxToken)this.VisitTerminal(context.KSet());
				}
				else 	if (context.KList() != null)
				{
					collectionKind = (InternalSyntaxToken)this.VisitTerminal(context.KList());
				}
				else 	if (context.KMultiSet() != null)
				{
					collectionKind = (InternalSyntaxToken)this.VisitTerminal(context.KMultiSet());
				}
				else 	if (context.KMultiList() != null)
				{
					collectionKind = (InternalSyntaxToken)this.VisitTerminal(context.KMultiList());
				}
				return this.factory.CollectionKind(collectionKind, true);
			}
			
			public override GreenNode VisitOperationDeclaration(MetaModelParser.OperationDeclarationContext context)
			{
				if (context == null) return null;
			    MetaModelParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				InternalSyntaxToken kStatic = (InternalSyntaxToken)this.VisitTerminal(context.KStatic());
				MetaModelParser.ReturnTypeContext returnTypeContext = context.returnType();
				ReturnTypeGreen returnType = null;
				if (returnTypeContext != null)
				{
					returnType = (ReturnTypeGreen)this.Visit(returnTypeContext);
				}
				MetaModelParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				MetaModelParser.ParameterListContext parameterListContext = context.parameterList();
				ParameterListGreen parameterList = null;
				if (parameterListContext != null)
				{
					parameterList = (ParameterListGreen)this.Visit(parameterListContext);
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.OperationDeclaration(annotation, kStatic, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon, true);
			}
			
			public override GreenNode VisitParameterList(MetaModelParser.ParameterListContext context)
			{
				if (context == null) return null;
			    MetaModelParser.ParameterContext[] parameterContext = context.parameter();
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
			
			public override GreenNode VisitParameter(MetaModelParser.ParameterContext context)
			{
				if (context == null) return null;
			    MetaModelParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				MetaModelParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				MetaModelParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				return this.factory.Parameter(annotation, typeReference, name, true);
			}
			
			public override GreenNode VisitAssociationDeclaration(MetaModelParser.AssociationDeclarationContext context)
			{
				if (context == null) return null;
			    MetaModelParser.AnnotationContext[] annotationContext = context.annotation();
			    ArrayBuilder<AnnotationGreen> annotationBuilder = ArrayBuilder<AnnotationGreen>.GetInstance(annotationContext.Length);
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				InternalSyntaxNodeList annotation = InternalSyntaxNodeList.Create(annotationBuilder.ToArrayAndFree());
				InternalSyntaxToken kAssociation = (InternalSyntaxToken)this.VisitTerminal(context.KAssociation());
				MetaModelParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifierGreen)this.Visit(sourceContext);
				}
				InternalSyntaxToken kWith = (InternalSyntaxToken)this.VisitTerminal(context.KWith());
				MetaModelParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null)
				{
					target = (QualifierGreen)this.Visit(targetContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.AssociationDeclaration(annotation, kAssociation, source, kWith, target, tSemicolon, true);
			}
			
			public override GreenNode VisitIdentifier(MetaModelParser.IdentifierContext context)
			{
				if (context == null) return null;
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
				return this.factory.Identifier(identifier, true);
			}
			
			public override GreenNode VisitLiteral(MetaModelParser.LiteralContext context)
			{
				if (context == null) return null;
				MetaModelParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return this.factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext), true);
				}
				MetaModelParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return this.factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext), true);
				}
				MetaModelParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return this.factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext), true);
				}
				MetaModelParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return this.factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext), true);
				}
				MetaModelParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return this.factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext), true);
				}
				MetaModelParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return this.factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitNullLiteral(MetaModelParser.NullLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull());
				return this.factory.NullLiteral(kNull, true);
			}
			
			public override GreenNode VisitBooleanLiteral(MetaModelParser.BooleanLiteralContext context)
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
			
			public override GreenNode VisitIntegerLiteral(MetaModelParser.IntegerLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger());
				return this.factory.IntegerLiteral(lInteger, true);
			}
			
			public override GreenNode VisitDecimalLiteral(MetaModelParser.DecimalLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal());
				return this.factory.DecimalLiteral(lDecimal, true);
			}
			
			public override GreenNode VisitScientificLiteral(MetaModelParser.ScientificLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific());
				return this.factory.ScientificLiteral(lScientific, true);
			}
			
			public override GreenNode VisitStringLiteral(MetaModelParser.StringLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken stringLiteral = null;
				if (context.LRegularString() != null)
				{
					stringLiteral = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString());
				}
				else 	if (context.LDoubleQuoteVerbatimString() != null)
				{
					stringLiteral = (InternalSyntaxToken)this.VisitTerminal(context.LDoubleQuoteVerbatimString());
				}
				else 	if (context.LSingleQuoteVerbatimString() != null)
				{
					stringLiteral = (InternalSyntaxToken)this.VisitTerminal(context.LSingleQuoteVerbatimString());
				}
				return this.factory.StringLiteral(stringLiteral, true);
			}
        }
    }
}

