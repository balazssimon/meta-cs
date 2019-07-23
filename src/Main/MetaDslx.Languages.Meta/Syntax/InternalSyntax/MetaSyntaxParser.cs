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
            private GreenNode VisitTerminal(ITerminalNode node, MetaSyntaxKind kind)
            {
                return this.syntaxParser.VisitTerminal(node, kind, ref this.lastTokenOrTrivia);
            }
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                return this.VisitTerminal(node, null);
            }
			
			public override GreenNode VisitMain(MetaParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
				MetaParser.NamespaceDeclarationContext namespaceDeclarationContext = context.namespaceDeclaration();
				NamespaceDeclarationGreen namespaceDeclaration = null;
				if (namespaceDeclarationContext != null)
				{
					namespaceDeclaration = (NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext);
				}
				else
				{
					namespaceDeclaration = NamespaceDeclarationGreen.__Missing;
				}
				InternalSyntaxToken eof = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), MetaSyntaxKind.Eof);
				return this.factory.Main(namespaceDeclaration, eof);
			}
			
			public override GreenNode VisitName(MetaParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				MetaParser.IdentifierContext identifierContext = context.identifier();
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
			
			public override GreenNode VisitQualifiedName(MetaParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
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
			
			public override GreenNode VisitQualifier(MetaParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    MetaParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], MetaSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return this.factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitAttribute(MetaParser.AttributeContext context)
			{
				if (context == null) return AttributeGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), MetaSyntaxKind.TOpenBracket);
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), MetaSyntaxKind.TCloseBracket);
				return this.factory.Attribute(tOpenBracket, qualifier, tCloseBracket);
			}
			
			public override GreenNode VisitNamespaceDeclaration(MetaParser.NamespaceDeclarationContext context)
			{
				if (context == null) return NamespaceDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), MetaSyntaxKind.KNamespace);
				MetaParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				MetaParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null)
				{
					namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				}
				else
				{
					namespaceBody = NamespaceBodyGreen.__Missing;
				}
				return this.factory.NamespaceDeclaration(attribute, kNamespace, qualifiedName, namespaceBody);
			}
			
			public override GreenNode VisitNamespaceBody(MetaParser.NamespaceBodyContext context)
			{
				if (context == null) return NamespaceBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), MetaSyntaxKind.TOpenBrace);
				MetaParser.MetamodelDeclarationContext metamodelDeclarationContext = context.metamodelDeclaration();
				MetamodelDeclarationGreen metamodelDeclaration = null;
				if (metamodelDeclarationContext != null)
				{
					metamodelDeclaration = (MetamodelDeclarationGreen)this.Visit(metamodelDeclarationContext);
				}
				else
				{
					metamodelDeclaration = MetamodelDeclarationGreen.__Missing;
				}
			    MetaParser.DeclarationContext[] declarationContext = context.declaration();
			    var declarationBuilder = _pool.Allocate<DeclarationGreen>();
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				var declaration = declarationBuilder.ToList();
				_pool.Free(declarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), MetaSyntaxKind.TCloseBrace);
				return this.factory.NamespaceBody(tOpenBrace, metamodelDeclaration, declaration, tCloseBrace);
			}
			
			public override GreenNode VisitMetamodelDeclaration(MetaParser.MetamodelDeclarationContext context)
			{
				if (context == null) return MetamodelDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kMetamodel = (InternalSyntaxToken)this.VisitTerminal(context.KMetamodel(), MetaSyntaxKind.KMetamodel);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				MetaParser.MetamodelPropertyListContext metamodelPropertyListContext = context.metamodelPropertyList();
				MetamodelPropertyListGreen metamodelPropertyList = null;
				if (metamodelPropertyListContext != null)
				{
					metamodelPropertyList = (MetamodelPropertyListGreen)this.Visit(metamodelPropertyListContext);
				}
				else
				{
					metamodelPropertyList = MetamodelPropertyListGreen.__Missing;
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return this.factory.MetamodelDeclaration(attribute, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
			}
			
			public override GreenNode VisitMetamodelPropertyList(MetaParser.MetamodelPropertyListContext context)
			{
				if (context == null) return MetamodelPropertyListGreen.__Missing;
			    MetaParser.MetamodelPropertyContext[] metamodelPropertyContext = context.metamodelProperty();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var metamodelPropertyBuilder = _pool.AllocateSeparated<MetamodelPropertyGreen>();
			    for (int i = 0; i < metamodelPropertyContext.Length; i++)
			    {
			        metamodelPropertyBuilder.Add((MetamodelPropertyGreen)this.Visit(metamodelPropertyContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            metamodelPropertyBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var metamodelProperty = metamodelPropertyBuilder.ToList();
				_pool.Free(metamodelPropertyBuilder);
				return this.factory.MetamodelPropertyList(metamodelProperty);
			}
			
			public override GreenNode VisitMetamodelProperty(MetaParser.MetamodelPropertyContext context)
			{
				if (context == null) return MetamodelPropertyGreen.__Missing;
				MetaParser.MetamodelUriPropertyContext metamodelUriPropertyContext = context.metamodelUriProperty();
				MetamodelUriPropertyGreen metamodelUriProperty = null;
				if (metamodelUriPropertyContext != null)
				{
					metamodelUriProperty = (MetamodelUriPropertyGreen)this.Visit(metamodelUriPropertyContext);
				}
				else
				{
					metamodelUriProperty = MetamodelUriPropertyGreen.__Missing;
				}
				return this.factory.MetamodelProperty(metamodelUriProperty);
			}
			
			public override GreenNode VisitMetamodelUriProperty(MetaParser.MetamodelUriPropertyContext context)
			{
				if (context == null) return MetamodelUriPropertyGreen.__Missing;
				InternalSyntaxToken iUri = (InternalSyntaxToken)this.VisitTerminal(context.IUri(), MetaSyntaxKind.IUri);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), MetaSyntaxKind.TAssign);
				MetaParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null)
				{
					stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				}
				else
				{
					stringLiteral = StringLiteralGreen.__Missing;
				}
				return this.factory.MetamodelUriProperty(iUri, tAssign, stringLiteral);
			}
			
			public override GreenNode VisitDeclaration(MetaParser.DeclarationContext context)
			{
				if (context == null) return DeclarationGreen.__Missing;
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
				return DeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitEnumDeclaration(MetaParser.EnumDeclarationContext context)
			{
				if (context == null) return EnumDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kEnum = (InternalSyntaxToken)this.VisitTerminal(context.KEnum(), MetaSyntaxKind.KEnum);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				MetaParser.EnumBodyContext enumBodyContext = context.enumBody();
				EnumBodyGreen enumBody = null;
				if (enumBodyContext != null)
				{
					enumBody = (EnumBodyGreen)this.Visit(enumBodyContext);
				}
				else
				{
					enumBody = EnumBodyGreen.__Missing;
				}
				return this.factory.EnumDeclaration(attribute, kEnum, name, enumBody);
			}
			
			public override GreenNode VisitEnumBody(MetaParser.EnumBodyContext context)
			{
				if (context == null) return EnumBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), MetaSyntaxKind.TOpenBrace);
				MetaParser.EnumValuesContext enumValuesContext = context.enumValues();
				EnumValuesGreen enumValues = null;
				if (enumValuesContext != null)
				{
					enumValues = (EnumValuesGreen)this.Visit(enumValuesContext);
				}
				else
				{
					enumValues = EnumValuesGreen.__Missing;
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
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), MetaSyntaxKind.TCloseBrace);
				return this.factory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitEnumValues(MetaParser.EnumValuesContext context)
			{
				if (context == null) return EnumValuesGreen.__Missing;
			    MetaParser.EnumValueContext[] enumValueContext = context.enumValue();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var enumValueBuilder = _pool.AllocateSeparated<EnumValueGreen>();
			    for (int i = 0; i < enumValueContext.Length; i++)
			    {
			        enumValueBuilder.Add((EnumValueGreen)this.Visit(enumValueContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            enumValueBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var enumValue = enumValueBuilder.ToList();
				_pool.Free(enumValueBuilder);
				return this.factory.EnumValues(enumValue);
			}
			
			public override GreenNode VisitEnumValue(MetaParser.EnumValueContext context)
			{
				if (context == null) return EnumValueGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return this.factory.EnumValue(attribute, name);
			}
			
			public override GreenNode VisitEnumMemberDeclaration(MetaParser.EnumMemberDeclarationContext context)
			{
				if (context == null) return EnumMemberDeclarationGreen.__Missing;
				MetaParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				OperationDeclarationGreen operationDeclaration = null;
				if (operationDeclarationContext != null)
				{
					operationDeclaration = (OperationDeclarationGreen)this.Visit(operationDeclarationContext);
				}
				else
				{
					operationDeclaration = OperationDeclarationGreen.__Missing;
				}
				return this.factory.EnumMemberDeclaration(operationDeclaration);
			}
			
			public override GreenNode VisitClassDeclaration(MetaParser.ClassDeclarationContext context)
			{
				if (context == null) return ClassDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kAbstract = (InternalSyntaxToken)this.VisitTerminal(context.KAbstract());
				InternalSyntaxToken kClass = (InternalSyntaxToken)this.VisitTerminal(context.KClass(), MetaSyntaxKind.KClass);
				MetaParser.NameContext nameContext = context.name();
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
				MetaParser.ClassAncestorsContext classAncestorsContext = context.classAncestors();
				ClassAncestorsGreen classAncestors = null;
				if (classAncestorsContext != null)
				{
					classAncestors = (ClassAncestorsGreen)this.Visit(classAncestorsContext);
				}
				else
				{
					classAncestors = ClassAncestorsGreen.__Missing;
				}
				MetaParser.ClassBodyContext classBodyContext = context.classBody();
				ClassBodyGreen classBody = null;
				if (classBodyContext != null)
				{
					classBody = (ClassBodyGreen)this.Visit(classBodyContext);
				}
				else
				{
					classBody = ClassBodyGreen.__Missing;
				}
				return this.factory.ClassDeclaration(attribute, kAbstract, kClass, name, tColon, classAncestors, classBody);
			}
			
			public override GreenNode VisitClassBody(MetaParser.ClassBodyContext context)
			{
				if (context == null) return ClassBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), MetaSyntaxKind.TOpenBrace);
			    MetaParser.ClassMemberDeclarationContext[] classMemberDeclarationContext = context.classMemberDeclaration();
			    var classMemberDeclarationBuilder = _pool.Allocate<ClassMemberDeclarationGreen>();
			    for (int i = 0; i < classMemberDeclarationContext.Length; i++)
			    {
			        classMemberDeclarationBuilder.Add((ClassMemberDeclarationGreen)this.Visit(classMemberDeclarationContext[i]));
			    }
				var classMemberDeclaration = classMemberDeclarationBuilder.ToList();
				_pool.Free(classMemberDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), MetaSyntaxKind.TCloseBrace);
				return this.factory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitClassAncestors(MetaParser.ClassAncestorsContext context)
			{
				if (context == null) return ClassAncestorsGreen.__Missing;
			    MetaParser.ClassAncestorContext[] classAncestorContext = context.classAncestor();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var classAncestorBuilder = _pool.AllocateSeparated<ClassAncestorGreen>();
			    for (int i = 0; i < classAncestorContext.Length; i++)
			    {
			        classAncestorBuilder.Add((ClassAncestorGreen)this.Visit(classAncestorContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            classAncestorBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var classAncestor = classAncestorBuilder.ToList();
				_pool.Free(classAncestorBuilder);
				return this.factory.ClassAncestors(classAncestor);
			}
			
			public override GreenNode VisitClassAncestor(MetaParser.ClassAncestorContext context)
			{
				if (context == null) return ClassAncestorGreen.__Missing;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return this.factory.ClassAncestor(qualifier);
			}
			
			public override GreenNode VisitClassMemberDeclaration(MetaParser.ClassMemberDeclarationContext context)
			{
				if (context == null) return ClassMemberDeclarationGreen.__Missing;
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
				return ClassMemberDeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitFieldDeclaration(MetaParser.FieldDeclarationContext context)
			{
				if (context == null) return FieldDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaParser.FieldModifierContext fieldModifierContext = context.fieldModifier();
				FieldModifierGreen fieldModifier = null;
				if (fieldModifierContext != null)
				{
					fieldModifier = (FieldModifierGreen)this.Visit(fieldModifierContext);
				}
				else
				{
					fieldModifier = FieldModifierGreen.__Missing;
				}
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				else
				{
					typeReference = TypeReferenceGreen.__Missing;
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				MetaParser.RedefinitionsOrSubsettingsContext redefinitionsOrSubsettingsContext = context.redefinitionsOrSubsettings();
				RedefinitionsOrSubsettingsGreen redefinitionsOrSubsettings = null;
				if (redefinitionsOrSubsettingsContext != null)
				{
					redefinitionsOrSubsettings = (RedefinitionsOrSubsettingsGreen)this.Visit(redefinitionsOrSubsettingsContext);
				}
				else
				{
					redefinitionsOrSubsettings = RedefinitionsOrSubsettingsGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return this.factory.FieldDeclaration(attribute, fieldModifier, typeReference, name, redefinitionsOrSubsettings, tSemicolon);
			}
			
			public override GreenNode VisitFieldModifier(MetaParser.FieldModifierContext context)
			{
				if (context == null) return FieldModifierGreen.__Missing;
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
				else
				{
					fieldModifier = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.FieldModifier(fieldModifier);
			}
			
			public override GreenNode VisitRedefinitionsOrSubsettings(MetaParser.RedefinitionsOrSubsettingsContext context)
			{
				if (context == null) return RedefinitionsOrSubsettingsGreen.__Missing;
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
				return RedefinitionsOrSubsettingsGreen.__Missing;
			}
			
			public override GreenNode VisitRedefinitions(MetaParser.RedefinitionsContext context)
			{
				if (context == null) return RedefinitionsGreen.__Missing;
				InternalSyntaxToken kRedefines = (InternalSyntaxToken)this.VisitTerminal(context.KRedefines(), MetaSyntaxKind.KRedefines);
				MetaParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null)
				{
					nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				}
				else
				{
					nameUseList = NameUseListGreen.__Missing;
				}
				return this.factory.Redefinitions(kRedefines, nameUseList);
			}
			
			public override GreenNode VisitSubsettings(MetaParser.SubsettingsContext context)
			{
				if (context == null) return SubsettingsGreen.__Missing;
				InternalSyntaxToken kSubsets = (InternalSyntaxToken)this.VisitTerminal(context.KSubsets(), MetaSyntaxKind.KSubsets);
				MetaParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null)
				{
					nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				}
				else
				{
					nameUseList = NameUseListGreen.__Missing;
				}
				return this.factory.Subsettings(kSubsets, nameUseList);
			}
			
			public override GreenNode VisitNameUseList(MetaParser.NameUseListContext context)
			{
				if (context == null) return NameUseListGreen.__Missing;
			    MetaParser.QualifierContext[] qualifierContext = context.qualifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var qualifierBuilder = _pool.AllocateSeparated<QualifierGreen>();
			    for (int i = 0; i < qualifierContext.Length; i++)
			    {
			        qualifierBuilder.Add((QualifierGreen)this.Visit(qualifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            qualifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var qualifier = qualifierBuilder.ToList();
				_pool.Free(qualifierBuilder);
				return this.factory.NameUseList(qualifier);
			}
			
			public override GreenNode VisitConstDeclaration(MetaParser.ConstDeclarationContext context)
			{
				if (context == null) return ConstDeclarationGreen.__Missing;
				InternalSyntaxToken kConst = (InternalSyntaxToken)this.VisitTerminal(context.KConst(), MetaSyntaxKind.KConst);
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				else
				{
					typeReference = TypeReferenceGreen.__Missing;
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return this.factory.ConstDeclaration(kConst, typeReference, name, tSemicolon);
			}
			
			public override GreenNode VisitReturnType(MetaParser.ReturnTypeContext context)
			{
				if (context == null) return ReturnTypeGreen.__Missing;
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
				return ReturnTypeGreen.__Missing;
			}
			
			public override GreenNode VisitTypeOfReference(MetaParser.TypeOfReferenceContext context)
			{
				if (context == null) return TypeOfReferenceGreen.__Missing;
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				else
				{
					typeReference = TypeReferenceGreen.__Missing;
				}
				return this.factory.TypeOfReference(typeReference);
			}
			
			public override GreenNode VisitTypeReference(MetaParser.TypeReferenceContext context)
			{
				if (context == null) return TypeReferenceGreen.__Missing;
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
				return TypeReferenceGreen.__Missing;
			}
			
			public override GreenNode VisitSimpleType(MetaParser.SimpleTypeContext context)
			{
				if (context == null) return SimpleTypeGreen.__Missing;
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
				return SimpleTypeGreen.__Missing;
			}
			
			public override GreenNode VisitClassType(MetaParser.ClassTypeContext context)
			{
				if (context == null) return ClassTypeGreen.__Missing;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return this.factory.ClassType(qualifier);
			}
			
			public override GreenNode VisitObjectType(MetaParser.ObjectTypeContext context)
			{
				if (context == null) return ObjectTypeGreen.__Missing;
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
				else
				{
					objectType = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.ObjectType(objectType);
			}
			
			public override GreenNode VisitPrimitiveType(MetaParser.PrimitiveTypeContext context)
			{
				if (context == null) return PrimitiveTypeGreen.__Missing;
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
				else
				{
					primitiveType = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.PrimitiveType(primitiveType);
			}
			
			public override GreenNode VisitVoidType(MetaParser.VoidTypeContext context)
			{
				if (context == null) return VoidTypeGreen.__Missing;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid(), MetaSyntaxKind.KVoid);
				return this.factory.VoidType(kVoid);
			}
			
			public override GreenNode VisitNullableType(MetaParser.NullableTypeContext context)
			{
				if (context == null) return NullableTypeGreen.__Missing;
				MetaParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				PrimitiveTypeGreen primitiveType = null;
				if (primitiveTypeContext != null)
				{
					primitiveType = (PrimitiveTypeGreen)this.Visit(primitiveTypeContext);
				}
				else
				{
					primitiveType = PrimitiveTypeGreen.__Missing;
				}
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion(), MetaSyntaxKind.TQuestion);
				return this.factory.NullableType(primitiveType, tQuestion);
			}
			
			public override GreenNode VisitCollectionType(MetaParser.CollectionTypeContext context)
			{
				if (context == null) return CollectionTypeGreen.__Missing;
				MetaParser.CollectionKindContext collectionKindContext = context.collectionKind();
				CollectionKindGreen collectionKind = null;
				if (collectionKindContext != null)
				{
					collectionKind = (CollectionKindGreen)this.Visit(collectionKindContext);
				}
				else
				{
					collectionKind = CollectionKindGreen.__Missing;
				}
				InternalSyntaxToken tLessThan = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan(), MetaSyntaxKind.TLessThan);
				MetaParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				SimpleTypeGreen simpleType = null;
				if (simpleTypeContext != null)
				{
					simpleType = (SimpleTypeGreen)this.Visit(simpleTypeContext);
				}
				else
				{
					simpleType = SimpleTypeGreen.__Missing;
				}
				InternalSyntaxToken tGreaterThan = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan(), MetaSyntaxKind.TGreaterThan);
				return this.factory.CollectionType(collectionKind, tLessThan, simpleType, tGreaterThan);
			}
			
			public override GreenNode VisitCollectionKind(MetaParser.CollectionKindContext context)
			{
				if (context == null) return CollectionKindGreen.__Missing;
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
				else
				{
					collectionKind = this.factory.MissingToken(SyntaxKind.MissingToken);
				}
				return this.factory.CollectionKind(collectionKind);
			}
			
			public override GreenNode VisitOperationDeclaration(MetaParser.OperationDeclarationContext context)
			{
				if (context == null) return OperationDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kStatic = (InternalSyntaxToken)this.VisitTerminal(context.KStatic());
				MetaParser.ReturnTypeContext returnTypeContext = context.returnType();
				ReturnTypeGreen returnType = null;
				if (returnTypeContext != null)
				{
					returnType = (ReturnTypeGreen)this.Visit(returnTypeContext);
				}
				else
				{
					returnType = ReturnTypeGreen.__Missing;
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), MetaSyntaxKind.TOpenParen);
				MetaParser.ParameterListContext parameterListContext = context.parameterList();
				ParameterListGreen parameterList = null;
				if (parameterListContext != null)
				{
					parameterList = (ParameterListGreen)this.Visit(parameterListContext);
				}
				else
				{
					parameterList = ParameterListGreen.__Missing;
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), MetaSyntaxKind.TCloseParen);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return this.factory.OperationDeclaration(attribute, kStatic, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
			}
			
			public override GreenNode VisitParameterList(MetaParser.ParameterListContext context)
			{
				if (context == null) return ParameterListGreen.__Missing;
			    MetaParser.ParameterContext[] parameterContext = context.parameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var parameterBuilder = _pool.AllocateSeparated<ParameterGreen>();
			    for (int i = 0; i < parameterContext.Length; i++)
			    {
			        parameterBuilder.Add((ParameterGreen)this.Visit(parameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            parameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var parameter = parameterBuilder.ToList();
				_pool.Free(parameterBuilder);
				return this.factory.ParameterList(parameter);
			}
			
			public override GreenNode VisitParameter(MetaParser.ParameterContext context)
			{
				if (context == null) return ParameterGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null)
				{
					typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				}
				else
				{
					typeReference = TypeReferenceGreen.__Missing;
				}
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return this.factory.Parameter(attribute, typeReference, name);
			}
			
			public override GreenNode VisitAssociationDeclaration(MetaParser.AssociationDeclarationContext context)
			{
				if (context == null) return AssociationDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kAssociation = (InternalSyntaxToken)this.VisitTerminal(context.KAssociation(), MetaSyntaxKind.KAssociation);
				MetaParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifierGreen)this.Visit(sourceContext);
				}
				else
				{
					source = QualifierGreen.__Missing;
				}
				InternalSyntaxToken kWith = (InternalSyntaxToken)this.VisitTerminal(context.KWith(), MetaSyntaxKind.KWith);
				MetaParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null)
				{
					target = (QualifierGreen)this.Visit(targetContext);
				}
				else
				{
					target = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return this.factory.AssociationDeclaration(attribute, kAssociation, source, kWith, target, tSemicolon);
			}
			
			public override GreenNode VisitIdentifier(MetaParser.IdentifierContext context)
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
			
			public override GreenNode VisitLiteral(MetaParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
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
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(MetaParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), MetaSyntaxKind.KNull);
				return this.factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(MetaParser.BooleanLiteralContext context)
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
			
			public override GreenNode VisitIntegerLiteral(MetaParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), MetaSyntaxKind.LInteger);
				return this.factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(MetaParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), MetaSyntaxKind.LDecimal);
				return this.factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(MetaParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), MetaSyntaxKind.LScientific);
				return this.factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(MetaParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken lRegularString = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString(), MetaSyntaxKind.LRegularString);
				return this.factory.StringLiteral(lRegularString);
			}
        }
    }
}

