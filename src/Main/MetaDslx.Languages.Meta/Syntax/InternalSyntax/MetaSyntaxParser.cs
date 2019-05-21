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
namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax
{
    public class MetaSyntaxParser : Antlr4SyntaxParser<MetaLexer, MetaParser>
    {
        public MetaSyntaxParser(
            SourceText text,
            MetaParseOptions options,
            SyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
            : base(text, MetaLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }
        public override DirectiveStack Directives
        {
            get
            {
                return DirectiveStack.Empty;
            }
        }
        protected override MetaLexer CreateLexer(AntlrInputStream inputStream)
        {
            return new MetaLexer(inputStream);
        }
        protected override MetaParser CreateParser(CommonTokenStream tokenStream)
        {
            return new MetaParser(tokenStream);
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
        private class Antlr4ToRoslynVisitor : MetaParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.            private MetaLanguage language;
			private MetaInternalSyntaxFactory factory;
            private MetaSyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastTokenOrTrivia;
            public Antlr4ToRoslynVisitor(MetaSyntaxParser syntaxParser)
            {
				this.factory = (MetaInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                this.syntaxParser = syntaxParser;
				this.tokens = this.syntaxParser.CommonTokenStream.GetTokens();
                this.lastTokenOrTrivia = null;
            }
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                GreenNode result = this.syntaxParser.VisitTerminal(node, ref this.lastTokenOrTrivia);
                return result;
            }
			
			public override GreenNode VisitMain(MetaParser.MainContext context)
			{
				if (context == null) return null;
				MetaParser.NamespaceDeclarationContext namespaceDeclarationContext = context.namespaceDeclaration();
				NamespaceDeclarationGreen namespaceDeclaration = null;
				if (namespaceDeclarationContext != null)
				{
					namespaceDeclaration = (NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext);
				}
				InternalSyntaxToken eof = (InternalSyntaxToken)this.VisitTerminal(context.Eof());
				return this.factory.Main(namespaceDeclaration, eof);
			}
			
			public override GreenNode VisitName(MetaParser.NameContext context)
			{
				if (context == null) return null;
				MetaParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				return this.factory.Name(identifier);
			}
			
			public override GreenNode VisitQualifiedName(MetaParser.QualifiedNameContext context)
			{
				if (context == null) return null;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.QualifiedName(qualifier);
			}
			
			public override GreenNode VisitQualifier(MetaParser.QualifierContext context)
			{
				if (context == null) return null;
			    MetaParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i]));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return this.factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitAnnotation(MetaParser.AnnotationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket());
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket());
				return this.factory.Annotation(tOpenBracket, name, tCloseBracket);
			}
			
			public override GreenNode VisitNamespaceDeclaration(MetaParser.NamespaceDeclarationContext context)
			{
				if (context == null) return null;
			    MetaParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace());
				MetaParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				MetaParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null)
				{
					namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				}
				return this.factory.NamespaceDeclaration(annotation, kNamespace, qualifiedName, namespaceBody);
			}
			
			public override GreenNode VisitNamespaceBody(MetaParser.NamespaceBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				MetaParser.MetamodelDeclarationContext metamodelDeclarationContext = context.metamodelDeclaration();
				MetamodelDeclarationGreen metamodelDeclaration = null;
				if (metamodelDeclarationContext != null)
				{
					metamodelDeclaration = (MetamodelDeclarationGreen)this.Visit(metamodelDeclarationContext);
				}
			    MetaParser.DeclarationContext[] declarationContext = context.declaration();
			    var declarationBuilder = _pool.Allocate<DeclarationGreen>();
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				var declaration = declarationBuilder.ToList();
				_pool.Free(declarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.NamespaceBody(tOpenBrace, metamodelDeclaration, declaration, tCloseBrace);
			}
			
			public override GreenNode VisitMetamodelDeclaration(MetaParser.MetamodelDeclarationContext context)
			{
				if (context == null) return null;
			    MetaParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				InternalSyntaxToken kMetamodel = (InternalSyntaxToken)this.VisitTerminal(context.KMetamodel());
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				MetaParser.MetamodelPropertyListContext metamodelPropertyListContext = context.metamodelPropertyList();
				MetamodelPropertyListGreen metamodelPropertyList = null;
				if (metamodelPropertyListContext != null)
				{
					metamodelPropertyList = (MetamodelPropertyListGreen)this.Visit(metamodelPropertyListContext);
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.MetamodelDeclaration(annotation, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
			}
			
			public override GreenNode VisitMetamodelPropertyList(MetaParser.MetamodelPropertyListContext context)
			{
				if (context == null) return null;
			    MetaParser.MetamodelPropertyContext[] metamodelPropertyContext = context.metamodelProperty();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var metamodelPropertyBuilder = _pool.AllocateSeparated<MetamodelPropertyGreen>();
			    for (int i = 0; i < metamodelPropertyContext.Length; i++)
			    {
			        metamodelPropertyBuilder.Add((MetamodelPropertyGreen)this.Visit(metamodelPropertyContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            metamodelPropertyBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				var metamodelProperty = metamodelPropertyBuilder.ToList();
				_pool.Free(metamodelPropertyBuilder);
				return this.factory.MetamodelPropertyList(metamodelProperty);
			}
			
			public override GreenNode VisitMetamodelProperty(MetaParser.MetamodelPropertyContext context)
			{
				if (context == null) return null;
				MetaParser.MetamodelUriPropertyContext metamodelUriPropertyContext = context.metamodelUriProperty();
				MetamodelUriPropertyGreen metamodelUriProperty = null;
				if (metamodelUriPropertyContext != null)
				{
					metamodelUriProperty = (MetamodelUriPropertyGreen)this.Visit(metamodelUriPropertyContext);
				}
				return this.factory.MetamodelProperty(metamodelUriProperty);
			}
			
			public override GreenNode VisitMetamodelUriProperty(MetaParser.MetamodelUriPropertyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken iUri = (InternalSyntaxToken)this.VisitTerminal(context.IUri());
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				MetaParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null)
				{
					stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				}
				return this.factory.MetamodelUriProperty(iUri, tAssign, stringLiteral);
			}
			
			public override GreenNode VisitDeclaration(MetaParser.DeclarationContext context)
			{
				if (context == null) return null;
				MetaParser.EnumDeclarationContext enumDeclarationContext = context.enumDeclaration();
				if (enumDeclarationContext != null) 
				{
					return this.factory.Declaration((EnumDeclarationGreen)this.Visit(enumDeclarationContext));
				}
				MetaParser.ClassDeclarationContext classDeclarationContext = context.classDeclaration();
				if (classDeclarationContext != null) 
				{
					return this.factory.Declaration((ClassDeclarationGreen)this.Visit(classDeclarationContext));
				}
				MetaParser.AssociationDeclarationContext associationDeclarationContext = context.associationDeclaration();
				if (associationDeclarationContext != null) 
				{
					return this.factory.Declaration((AssociationDeclarationGreen)this.Visit(associationDeclarationContext));
				}
				MetaParser.ConstDeclarationContext constDeclarationContext = context.constDeclaration();
				if (constDeclarationContext != null) 
				{
					return this.factory.Declaration((ConstDeclarationGreen)this.Visit(constDeclarationContext));
				}
				MetaParser.ExternTypeDeclarationContext externTypeDeclarationContext = context.externTypeDeclaration();
				if (externTypeDeclarationContext != null) 
				{
					return this.factory.Declaration((ExternTypeDeclarationGreen)this.Visit(externTypeDeclarationContext));
				}
				return null;
			}
			
			public override GreenNode VisitEnumDeclaration(MetaParser.EnumDeclarationContext context)
			{
				if (context == null) return null;
			    MetaParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				InternalSyntaxToken kEnum = (InternalSyntaxToken)this.VisitTerminal(context.KEnum());
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				MetaParser.EnumBodyContext enumBodyContext = context.enumBody();
				EnumBodyGreen enumBody = null;
				if (enumBodyContext != null)
				{
					enumBody = (EnumBodyGreen)this.Visit(enumBodyContext);
				}
				return this.factory.EnumDeclaration(annotation, kEnum, name, enumBody);
			}
			
			public override GreenNode VisitEnumBody(MetaParser.EnumBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
				MetaParser.EnumValuesContext enumValuesContext = context.enumValues();
				EnumValuesGreen enumValues = null;
				if (enumValuesContext != null)
				{
					enumValues = (EnumValuesGreen)this.Visit(enumValuesContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
			    MetaParser.EnumMemberDeclarationContext[] enumMemberDeclarationContext = context.enumMemberDeclaration();
			    var enumMemberDeclarationBuilder = _pool.Allocate<EnumMemberDeclarationGreen>();
			    for (int i = 0; i < enumMemberDeclarationContext.Length; i++)
			    {
			        enumMemberDeclarationBuilder.Add((EnumMemberDeclarationGreen)this.Visit(enumMemberDeclarationContext[i]));
			    }
				var enumMemberDeclaration = enumMemberDeclarationBuilder.ToList();
				_pool.Free(enumMemberDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitEnumValues(MetaParser.EnumValuesContext context)
			{
				if (context == null) return null;
			    MetaParser.EnumValueContext[] enumValueContext = context.enumValue();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var enumValueBuilder = _pool.AllocateSeparated<EnumValueGreen>();
			    for (int i = 0; i < enumValueContext.Length; i++)
			    {
			        enumValueBuilder.Add((EnumValueGreen)this.Visit(enumValueContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            enumValueBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				var enumValue = enumValueBuilder.ToList();
				_pool.Free(enumValueBuilder);
				return this.factory.EnumValues(enumValue);
			}
			
			public override GreenNode VisitEnumValue(MetaParser.EnumValueContext context)
			{
				if (context == null) return null;
			    MetaParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				return this.factory.EnumValue(annotation, name);
			}
			
			public override GreenNode VisitEnumMemberDeclaration(MetaParser.EnumMemberDeclarationContext context)
			{
				if (context == null) return null;
				MetaParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				OperationDeclarationGreen operationDeclaration = null;
				if (operationDeclarationContext != null)
				{
					operationDeclaration = (OperationDeclarationGreen)this.Visit(operationDeclarationContext);
				}
				return this.factory.EnumMemberDeclaration(operationDeclaration);
			}
			
			public override GreenNode VisitClassDeclaration(MetaParser.ClassDeclarationContext context)
			{
				if (context == null) return null;
			    MetaParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				InternalSyntaxToken kAbstract = (InternalSyntaxToken)this.VisitTerminal(context.KAbstract());
				InternalSyntaxToken kClass = (InternalSyntaxToken)this.VisitTerminal(context.KClass());
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				MetaParser.ClassAncestorsContext classAncestorsContext = context.classAncestors();
				ClassAncestorsGreen classAncestors = null;
				if (classAncestorsContext != null)
				{
					classAncestors = (ClassAncestorsGreen)this.Visit(classAncestorsContext);
				}
				MetaParser.ClassBodyContext classBodyContext = context.classBody();
				ClassBodyGreen classBody = null;
				if (classBodyContext != null)
				{
					classBody = (ClassBodyGreen)this.Visit(classBodyContext);
				}
				return this.factory.ClassDeclaration(annotation, kAbstract, kClass, name, tColon, classAncestors, classBody);
			}
			
			public override GreenNode VisitClassBody(MetaParser.ClassBodyContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace());
			    MetaParser.ClassMemberDeclarationContext[] classMemberDeclarationContext = context.classMemberDeclaration();
			    var classMemberDeclarationBuilder = _pool.Allocate<ClassMemberDeclarationGreen>();
			    for (int i = 0; i < classMemberDeclarationContext.Length; i++)
			    {
			        classMemberDeclarationBuilder.Add((ClassMemberDeclarationGreen)this.Visit(classMemberDeclarationContext[i]));
			    }
				var classMemberDeclaration = classMemberDeclarationBuilder.ToList();
				_pool.Free(classMemberDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace());
				return this.factory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitClassAncestors(MetaParser.ClassAncestorsContext context)
			{
				if (context == null) return null;
			    MetaParser.ClassAncestorContext[] classAncestorContext = context.classAncestor();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var classAncestorBuilder = _pool.AllocateSeparated<ClassAncestorGreen>();
			    for (int i = 0; i < classAncestorContext.Length; i++)
			    {
			        classAncestorBuilder.Add((ClassAncestorGreen)this.Visit(classAncestorContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            classAncestorBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				var classAncestor = classAncestorBuilder.ToList();
				_pool.Free(classAncestorBuilder);
				return this.factory.ClassAncestors(classAncestor);
			}
			
			public override GreenNode VisitClassAncestor(MetaParser.ClassAncestorContext context)
			{
				if (context == null) return null;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.ClassAncestor(qualifier);
			}
			
			public override GreenNode VisitClassMemberDeclaration(MetaParser.ClassMemberDeclarationContext context)
			{
				if (context == null) return null;
				MetaParser.FieldDeclarationContext fieldDeclarationContext = context.fieldDeclaration();
				if (fieldDeclarationContext != null) 
				{
					return this.factory.ClassMemberDeclaration((FieldDeclarationGreen)this.Visit(fieldDeclarationContext));
				}
				MetaParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				if (operationDeclarationContext != null) 
				{
					return this.factory.ClassMemberDeclaration((OperationDeclarationGreen)this.Visit(operationDeclarationContext));
				}
				return null;
			}
			
			public override GreenNode VisitFieldDeclaration(MetaParser.FieldDeclarationContext context)
			{
				if (context == null) return null;
			    MetaParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				MetaParser.FieldModifierContext fieldModifierContext = context.fieldModifier();
				FieldModifierGreen fieldModifier = null;
				if (fieldModifierContext != null)
				{
					fieldModifier = (FieldModifierGreen)this.Visit(fieldModifierContext);
				}
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				MetaParser.RedefinitionsOrSubsettingsContext redefinitionsOrSubsettingsContext = context.redefinitionsOrSubsettings();
				RedefinitionsOrSubsettingsGreen redefinitionsOrSubsettings = null;
				if (redefinitionsOrSubsettingsContext != null)
				{
					redefinitionsOrSubsettings = (RedefinitionsOrSubsettingsGreen)this.Visit(redefinitionsOrSubsettingsContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.FieldDeclaration(annotation, fieldModifier, typeReference, name, redefinitionsOrSubsettings, tSemicolon);
			}
			
			public override GreenNode VisitFieldModifier(MetaParser.FieldModifierContext context)
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
				return this.factory.FieldModifier(fieldModifier);
			}
			
			public override GreenNode VisitRedefinitionsOrSubsettings(MetaParser.RedefinitionsOrSubsettingsContext context)
			{
				if (context == null) return null;
				MetaParser.RedefinitionsContext redefinitionsContext = context.redefinitions();
				if (redefinitionsContext != null) 
				{
					return this.factory.RedefinitionsOrSubsettings((RedefinitionsGreen)this.Visit(redefinitionsContext));
				}
				MetaParser.SubsettingsContext subsettingsContext = context.subsettings();
				if (subsettingsContext != null) 
				{
					return this.factory.RedefinitionsOrSubsettings((SubsettingsGreen)this.Visit(subsettingsContext));
				}
				return null;
			}
			
			public override GreenNode VisitRedefinitions(MetaParser.RedefinitionsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kRedefines = (InternalSyntaxToken)this.VisitTerminal(context.KRedefines());
				MetaParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null)
				{
					nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				}
				return this.factory.Redefinitions(kRedefines, nameUseList);
			}
			
			public override GreenNode VisitSubsettings(MetaParser.SubsettingsContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kSubsets = (InternalSyntaxToken)this.VisitTerminal(context.KSubsets());
				MetaParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null)
				{
					nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				}
				return this.factory.Subsettings(kSubsets, nameUseList);
			}
			
			public override GreenNode VisitNameUseList(MetaParser.NameUseListContext context)
			{
				if (context == null) return null;
			    MetaParser.QualifierContext[] qualifierContext = context.qualifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var qualifierBuilder = _pool.AllocateSeparated<QualifierGreen>();
			    for (int i = 0; i < qualifierContext.Length; i++)
			    {
			        qualifierBuilder.Add((QualifierGreen)this.Visit(qualifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            qualifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				var qualifier = qualifierBuilder.ToList();
				_pool.Free(qualifierBuilder);
				return this.factory.NameUseList(qualifier);
			}
			
			public override GreenNode VisitConstDeclaration(MetaParser.ConstDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kConst = (InternalSyntaxToken)this.VisitTerminal(context.KConst());
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ConstDeclaration(kConst, typeReference, name, tSemicolon);
			}
			
			public override GreenNode VisitExternTypeDeclaration(MetaParser.ExternTypeDeclarationContext context)
			{
				if (context == null) return null;
				MetaParser.ExternClassTypeDeclarationContext externClassTypeDeclarationContext = context.externClassTypeDeclaration();
				if (externClassTypeDeclarationContext != null) 
				{
					return this.factory.ExternTypeDeclaration((ExternClassTypeDeclarationGreen)this.Visit(externClassTypeDeclarationContext));
				}
				MetaParser.ExternStructTypeDeclarationContext externStructTypeDeclarationContext = context.externStructTypeDeclaration();
				if (externStructTypeDeclarationContext != null) 
				{
					return this.factory.ExternTypeDeclaration((ExternStructTypeDeclarationGreen)this.Visit(externStructTypeDeclarationContext));
				}
				return null;
			}
			
			public override GreenNode VisitExternClassTypeDeclaration(MetaParser.ExternClassTypeDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kExtern = (InternalSyntaxToken)this.VisitTerminal(context.KExtern());
				InternalSyntaxToken kClass = (InternalSyntaxToken)this.VisitTerminal(context.KClass());
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ExternClassTypeDeclaration(kExtern, kClass, qualifier, name, tSemicolon);
			}
			
			public override GreenNode VisitExternStructTypeDeclaration(MetaParser.ExternStructTypeDeclarationContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kExtern = (InternalSyntaxToken)this.VisitTerminal(context.KExtern());
				InternalSyntaxToken kStruct = (InternalSyntaxToken)this.VisitTerminal(context.KStruct());
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.ExternStructTypeDeclaration(kExtern, kStruct, qualifier, name, tSemicolon);
			}
			
			public override GreenNode VisitReturnType(MetaParser.ReturnTypeContext context)
			{
				if (context == null) return null;
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return this.factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext));
				}
				MetaParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return this.factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext));
				}
				return null;
			}
			
			public override GreenNode VisitTypeOfReference(MetaParser.TypeOfReferenceContext context)
			{
				if (context == null) return null;
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				return this.factory.TypeOfReference(typeReference);
			}
			
			public override GreenNode VisitTypeReference(MetaParser.TypeReferenceContext context)
			{
				if (context == null) return null;
				MetaParser.CollectionTypeContext collectionTypeContext = context.collectionType();
				if (collectionTypeContext != null) 
				{
					return this.factory.TypeReference((CollectionTypeGreen)this.Visit(collectionTypeContext));
				}
				MetaParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return this.factory.TypeReference((SimpleTypeGreen)this.Visit(simpleTypeContext));
				}
				return null;
			}
			
			public override GreenNode VisitSimpleType(MetaParser.SimpleTypeContext context)
			{
				if (context == null) return null;
				MetaParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				if (primitiveTypeContext != null) 
				{
					return this.factory.SimpleType((PrimitiveTypeGreen)this.Visit(primitiveTypeContext));
				}
				MetaParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					return this.factory.SimpleType((ObjectTypeGreen)this.Visit(objectTypeContext));
				}
				MetaParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					return this.factory.SimpleType((NullableTypeGreen)this.Visit(nullableTypeContext));
				}
				MetaParser.ClassTypeContext classTypeContext = context.classType();
				if (classTypeContext != null) 
				{
					return this.factory.SimpleType((ClassTypeGreen)this.Visit(classTypeContext));
				}
				return null;
			}
			
			public override GreenNode VisitClassType(MetaParser.ClassTypeContext context)
			{
				if (context == null) return null;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				return this.factory.ClassType(qualifier);
			}
			
			public override GreenNode VisitObjectType(MetaParser.ObjectTypeContext context)
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
				return this.factory.ObjectType(objectType);
			}
			
			public override GreenNode VisitPrimitiveType(MetaParser.PrimitiveTypeContext context)
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
				return this.factory.PrimitiveType(primitiveType);
			}
			
			public override GreenNode VisitVoidType(MetaParser.VoidTypeContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid());
				return this.factory.VoidType(kVoid);
			}
			
			public override GreenNode VisitNullableType(MetaParser.NullableTypeContext context)
			{
				if (context == null) return null;
				MetaParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				PrimitiveTypeGreen primitiveType = null;
				if (primitiveTypeContext != null)
				{
					primitiveType = (PrimitiveTypeGreen)this.Visit(primitiveTypeContext);
				}
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion());
				return this.factory.NullableType(primitiveType, tQuestion);
			}
			
			public override GreenNode VisitCollectionType(MetaParser.CollectionTypeContext context)
			{
				if (context == null) return null;
				MetaParser.CollectionKindContext collectionKindContext = context.collectionKind();
				CollectionKindGreen collectionKind = null;
				if (collectionKindContext != null)
				{
					collectionKind = (CollectionKindGreen)this.Visit(collectionKindContext);
				}
				InternalSyntaxToken tLessThan = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan());
				MetaParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				SimpleTypeGreen simpleType = null;
				if (simpleTypeContext != null)
				{
					simpleType = (SimpleTypeGreen)this.Visit(simpleTypeContext);
				}
				InternalSyntaxToken tGreaterThan = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan());
				return this.factory.CollectionType(collectionKind, tLessThan, simpleType, tGreaterThan);
			}
			
			public override GreenNode VisitCollectionKind(MetaParser.CollectionKindContext context)
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
				return this.factory.CollectionKind(collectionKind);
			}
			
			public override GreenNode VisitOperationDeclaration(MetaParser.OperationDeclarationContext context)
			{
				if (context == null) return null;
			    MetaParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				InternalSyntaxToken kStatic = (InternalSyntaxToken)this.VisitTerminal(context.KStatic());
				MetaParser.ReturnTypeContext returnTypeContext = context.returnType();
				ReturnTypeGreen returnType = null;
				if (returnTypeContext != null)
				{
					returnType = (ReturnTypeGreen)this.Visit(returnTypeContext);
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				MetaParser.ParameterListContext parameterListContext = context.parameterList();
				ParameterListGreen parameterList = null;
				if (parameterListContext != null)
				{
					parameterList = (ParameterListGreen)this.Visit(parameterListContext);
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.OperationDeclaration(annotation, kStatic, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
			}
			
			public override GreenNode VisitParameterList(MetaParser.ParameterListContext context)
			{
				if (context == null) return null;
			    MetaParser.ParameterContext[] parameterContext = context.parameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var parameterBuilder = _pool.AllocateSeparated<ParameterGreen>();
			    for (int i = 0; i < parameterContext.Length; i++)
			    {
			        parameterBuilder.Add((ParameterGreen)this.Visit(parameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            parameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				var parameter = parameterBuilder.ToList();
				_pool.Free(parameterBuilder);
				return this.factory.ParameterList(parameter);
			}
			
			public override GreenNode VisitParameter(MetaParser.ParameterContext context)
			{
				if (context == null) return null;
			    MetaParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				return this.factory.Parameter(annotation, typeReference, name);
			}
			
			public override GreenNode VisitAssociationDeclaration(MetaParser.AssociationDeclarationContext context)
			{
				if (context == null) return null;
			    MetaParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				InternalSyntaxToken kAssociation = (InternalSyntaxToken)this.VisitTerminal(context.KAssociation());
				MetaParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifierGreen)this.Visit(sourceContext);
				}
				InternalSyntaxToken kWith = (InternalSyntaxToken)this.VisitTerminal(context.KWith());
				MetaParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null)
				{
					target = (QualifierGreen)this.Visit(targetContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.AssociationDeclaration(annotation, kAssociation, source, kWith, target, tSemicolon);
			}
			
			public override GreenNode VisitIdentifier(MetaParser.IdentifierContext context)
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
				return this.factory.Identifier(identifier);
			}
			
			public override GreenNode VisitLiteral(MetaParser.LiteralContext context)
			{
				if (context == null) return null;
				MetaParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return this.factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				MetaParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return this.factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				MetaParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return this.factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				MetaParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return this.factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				MetaParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return this.factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				MetaParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return this.factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return null;
			}
			
			public override GreenNode VisitNullLiteral(MetaParser.NullLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull());
				return this.factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(MetaParser.BooleanLiteralContext context)
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
				return this.factory.BooleanLiteral(booleanLiteral);
			}
			
			public override GreenNode VisitIntegerLiteral(MetaParser.IntegerLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger());
				return this.factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(MetaParser.DecimalLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal());
				return this.factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(MetaParser.ScientificLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific());
				return this.factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(MetaParser.StringLiteralContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken lRegularString = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString());
				return this.factory.StringLiteral(lRegularString);
			}
        }
    }
}

