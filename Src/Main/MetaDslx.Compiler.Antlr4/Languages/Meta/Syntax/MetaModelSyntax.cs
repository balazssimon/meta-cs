// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Meta.Syntax
{
	public enum MetaModelSyntaxKind : int
	{
        None                          = SyntaxKind.None,
        List                          = SyntaxKind.List,
        BadToken                      = SyntaxKind.BadToken,
        Eof                           = SyntaxKind.Eof,

		// Tokens:
		KNamespace = 1,
		KUsing,
		KMetamodel,
		KExtern,
		KTypeDef,
		KAbstract,
		KClass,
		KEnum,
		KAssociation,
		KContainment,
		KWith,
		KNew,
		KNull,
		KTrue,
		KFalse,
		KVoid,
		KObject,
		KSymbol,
		KString,
		KInt,
		KLong,
		KFloat,
		KDouble,
		KByte,
		KBool,
		KList,
		KAny,
		KNone,
		KError,
		KSet,
		KMultiList,
		KMultiSet,
		KThis,
		KTypeof,
		KAs,
		KIs,
		KBase,
		KConst,
		KRedefines,
		KSubsets,
		KReadonly,
		KLazy,
		KSynthetized,
		KInherited,
		KDerived,
		KStatic,
		TSemicolon,
		TColon,
		TDot,
		TComma,
		TAssign,
		TOpenParen,
		TCloseParen,
		TOpenBracket,
		TCloseBracket,
		TOpenBrace,
		TCloseBrace,
		TLessThan,
		TGreaterThan,
		TQuestion,
		TQuestionQuestion,
		TAmpersand,
		THat,
		TBar,
		TAndAlso,
		TOrElse,
		TPlusPlus,
		TMinusMinus,
		TPlus,
		TMinus,
		TTilde,
		TExclamation,
		TSlash,
		TAsterisk,
		TPercent,
		TLessThanOrEqual,
		TGreaterThanOrEqual,
		TEqual,
		TNotEqual,
		TAsteriskAssign,
		TSlashAssign,
		TPercentAssign,
		TPlusAssign,
		TMinusAssign,
		TLeftShiftAssign,
		TRightShiftAssign,
		TAmpersandAssign,
		THatAssign,
		TBarAssign,
		IUri,
		IdentifierNormal,
		IdentifierVerbatim,
		LInteger,
		LDecimal,
		LScientific,
		LDateTimeOffset,
		LDateTime,
		LDate,
		LTime,
		LRegularString,
		LGuid,
		LUtf8Bom,
		LWhiteSpace,
		LCrLf,
		LLineEnd,
		LSingleLineComment,
		LComment,
		LDoubleQuoteVerbatimString,
		LSingleQuoteVerbatimString,
		DoubleQuoteVerbatimStringLiteralStart,
		SingleQuoteVerbatimStringLiteralStart,

		// Rules:
		Main,
		Name,
		QualifiedName,
		Qualifier,
		Annotation,
		NamespaceDeclaration,
		NamespaceBody,
		MetamodelDeclaration,
		MetamodelPropertyList,
		MetamodelProperty,
		MetamodelUriProperty,
		Declaration,
		EnumDeclaration,
		EnumBody,
		EnumValues,
		EnumValue,
		EnumMemberDeclaration,
		ClassDeclaration,
		ClassBody,
		ClassAncestors,
		ClassAncestor,
		ClassMemberDeclaration,
		FieldDeclaration,
		FieldModifier,
		RedefinitionsOrSubsettings,
		Redefinitions,
		Subsettings,
		NameUseList,
		ConstDeclaration,
		ReturnType,
		TypeOfReference,
		TypeReference,
		SimpleType,
		ClassType,
		ObjectType,
		PrimitiveType,
		VoidType,
		NullableType,
		CollectionType,
		CollectionKind,
		OperationDeclaration,
		ParameterList,
		Parameter,
		AssociationDeclaration,
		Identifier,
		Literal,
		NullLiteral,
		BooleanLiteral,
		IntegerLiteral,
		DecimalLiteral,
		ScientificLiteral,
		StringLiteral,
	}

    public abstract class MetaModelSyntaxNode : SyntaxNode
    {
        protected MetaModelSyntaxNode(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected MetaModelSyntaxNode(InternalSyntaxNode green, SyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public MetaModelSyntaxKind Kind
        {
            get { return (MetaModelSyntaxKind)base.RawKind; }
        }

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            IMetaModelSyntaxVisitor<TResult> typedVisitor = visitor as IMetaModelSyntaxVisitor<TResult>;
            if (typedVisitor != null)
            {
                return this.Accept(typedVisitor);
            }
            return default(TResult);
        }

        public abstract TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            IMetaModelSyntaxVisitor typedVisitor = visitor as IMetaModelSyntaxVisitor;
            if (typedVisitor != null)
            {
                this.Accept(typedVisitor);
            }
        }
        public abstract void Accept(IMetaModelSyntaxVisitor visitor);
    }

    public class MetaModelSyntaxTrivia : SyntaxTrivia
    {
        public MetaModelSyntaxTrivia(InternalSyntaxTrivia green, SyntaxToken token, int position, int index)
            : base(green, token, position, index)
        {
        }

        public MetaModelSyntaxKind Kind
        {
            get { return (MetaModelSyntaxKind)base.RawKind; }
        }
    }

    public class MetaModelSyntaxToken : SyntaxToken
    {
        public MetaModelSyntaxToken(InternalSyntaxToken green, SyntaxNode parent, int position, int index)
            : base(green, parent, position, index)
        {
        }

        public MetaModelSyntaxKind Kind
        {
            get { return (MetaModelSyntaxKind)base.RawKind; }
        }

        protected override SyntaxToken WithLeadingTriviaCore(InternalSyntaxTrivia[] leading)
        {
            return new MetaModelSyntaxToken(this.GreenToken.WithLeadingTrivia(new InternalSyntaxTriviaList(leading, null, null)), null, 0, 0);
        }

        protected override SyntaxToken WithTrailingTriviaCore(InternalSyntaxTrivia[] trailing)
        {
            return new MetaModelSyntaxToken(this.GreenToken.WithTrailingTrivia(new InternalSyntaxTriviaList(trailing, null, null)), null, 0, 0);
        }
    }
	
	public sealed class MainSyntax : MetaModelSyntaxNode
	{
	    private NamespaceDeclarationSyntax namespaceDeclaration;
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NamespaceDeclarationSyntax NamespaceDeclaration 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.namespaceDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.namespaceDeclaration;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithNamespaceDeclaration(NamespaceDeclarationSyntax namespaceDeclaration)
		{
			return this.Update(NamespaceDeclaration);
		}
	
	    public MainSyntax Update(NamespaceDeclarationSyntax namespaceDeclaration)
	    {
	        if (this.NamespaceDeclaration != namespaceDeclaration)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Main(namespaceDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class NameSyntax : MetaModelSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				default: return null;
	        }
	    }
	
	    public NameSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public NameSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class QualifiedNameSyntax : MetaModelSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public QualifiedNameSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public QualifiedNameSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.QualifiedName(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifiedName(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifiedName(this);
	    }
	}
	
	public sealed class QualifierSyntax : MetaModelSyntaxNode
	{
	    private SeparatedSyntaxNodeList identifier;
	
	    public QualifierSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<IdentifierSyntax> Identifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.identifier, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<IdentifierSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				default: return null;
	        }
	    }
	
	    public QualifierSyntax WithIdentifier(SeparatedSyntaxNodeList<IdentifierSyntax> identifier)
		{
			return this.Update(Identifier);
		}
	
	    public QualifierSyntax AddIdentifier(params IdentifierSyntax[] identifier)
		{
			return this.WithIdentifier(this.Identifier.AddRange(identifier));
		}
	
	    public QualifierSyntax Update(SeparatedSyntaxNodeList<IdentifierSyntax> identifier)
	    {
	        if (this.Identifier.Node != identifier.Node)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Qualifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifier(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifier(this);
	    }
	}
	
	public sealed class AnnotationSyntax : MetaModelSyntaxNode
	{
	    private NameSyntax name;
	
	    public AnnotationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AnnotationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.AnnotationGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.AnnotationGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				default: return null;
	        }
	    }
	
	    public AnnotationSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.Name, this.TCloseBracket);
		}
	
	    public AnnotationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.TOpenBracket, Name, this.TCloseBracket);
		}
	
	    public AnnotationSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.Name, TCloseBracket);
		}
	
	    public AnnotationSyntax Update(SyntaxToken tOpenBracket, NameSyntax name, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.Name != name ||
				this.TCloseBracket != tCloseBracket)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Annotation(tOpenBracket, name, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAnnotation(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitAnnotation(this);
	    }
	}
	
	public sealed class NamespaceDeclarationSyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList annotation;
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBodySyntax namespaceBody;
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null)
				{
					return new SyntaxNodeList<AnnotationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
				var greenToken = green.KNamespace;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 2); } 
		}
	    public NamespaceBodySyntax NamespaceBody 
		{ 
			get { return this.GetRed(ref this.namespaceBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 2: return this.GetRed(ref this.qualifiedName, 2);
				case 3: return this.GetRed(ref this.namespaceBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 2: return this.qualifiedName;
				case 3: return this.namespaceBody;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclarationSyntax WithAnnotation(SyntaxNodeList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.KNamespace, this.QualifiedName, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public NamespaceDeclarationSyntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(this.Annotation, KNamespace, this.QualifiedName, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.Annotation, this.KNamespace, QualifiedName, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithNamespaceBody(NamespaceBodySyntax namespaceBody)
		{
			return this.Update(this.Annotation, this.KNamespace, this.QualifiedName, NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax Update(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
	    {
	        if (this.Annotation.Node != annotation.Node ||
				this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody != namespaceBody)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.NamespaceDeclaration(annotation, kNamespace, qualifiedName, namespaceBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration(this);
	    }
	}
	
	public sealed class NamespaceBodySyntax : MetaModelSyntaxNode
	{
	    private MetamodelDeclarationSyntax metamodelDeclaration;
	    private SyntaxNodeList declaration;
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public MetamodelDeclarationSyntax MetamodelDeclaration 
		{ 
			get { return this.GetRed(ref this.metamodelDeclaration, 1); } 
		}
	    public SyntaxNodeList<DeclarationSyntax> Declaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration, 2);
				if (red != null)
				{
					return new SyntaxNodeList<DeclarationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.metamodelDeclaration, 1);
				case 2: return this.GetRed(ref this.declaration, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.metamodelDeclaration;
				case 2: return this.declaration;
				default: return null;
	        }
	    }
	
	    public NamespaceBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.MetamodelDeclaration, this.Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax WithMetamodelDeclaration(MetamodelDeclarationSyntax metamodelDeclaration)
		{
			return this.Update(this.TOpenBrace, MetamodelDeclaration, this.Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax WithDeclaration(SyntaxNodeList<DeclarationSyntax> declaration)
		{
			return this.Update(this.TOpenBrace, this.MetamodelDeclaration, Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax AddDeclaration(params DeclarationSyntax[] declaration)
		{
			return this.WithDeclaration(this.Declaration.AddRange(declaration));
		}
	
	    public NamespaceBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.MetamodelDeclaration, this.Declaration, TCloseBrace);
		}
	
	    public NamespaceBodySyntax Update(SyntaxToken tOpenBrace, MetamodelDeclarationSyntax metamodelDeclaration, SyntaxNodeList<DeclarationSyntax> declaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.MetamodelDeclaration != metamodelDeclaration ||
				this.Declaration.Node != declaration.Node ||
				this.TCloseBrace != tCloseBrace)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.NamespaceBody(tOpenBrace, metamodelDeclaration, declaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody(this);
	    }
	}
	
	public sealed class MetamodelDeclarationSyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList annotation;
	    private NameSyntax name;
	    private MetamodelPropertyListSyntax metamodelPropertyList;
	
	    public MetamodelDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MetamodelDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null)
				{
					return new SyntaxNodeList<AnnotationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken KMetamodel 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelDeclarationGreen)this.Green;
				var greenToken = green.KMetamodel;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelDeclarationGreen)this.Green;
				var greenToken = green.TOpenParen;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	    public MetamodelPropertyListSyntax MetamodelPropertyList 
		{ 
			get { return this.GetRed(ref this.metamodelPropertyList, 4); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelDeclarationGreen)this.Green;
				var greenToken = green.TCloseParen;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(5), this.GetChildIndex(5)); 
			}
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(6), this.GetChildIndex(6)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 2: return this.GetRed(ref this.name, 2);
				case 4: return this.GetRed(ref this.metamodelPropertyList, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 2: return this.name;
				case 4: return this.metamodelPropertyList;
				default: return null;
	        }
	    }
	
	    public MetamodelDeclarationSyntax WithAnnotation(SyntaxNodeList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.KMetamodel, this.Name, this.TOpenParen, this.MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public MetamodelDeclarationSyntax WithKMetamodel(SyntaxToken kMetamodel)
		{
			return this.Update(this.Annotation, KMetamodel, this.Name, this.TOpenParen, this.MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Annotation, this.KMetamodel, Name, this.TOpenParen, this.MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Annotation, this.KMetamodel, this.Name, TOpenParen, this.MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithMetamodelPropertyList(MetamodelPropertyListSyntax metamodelPropertyList)
		{
			return this.Update(this.Annotation, this.KMetamodel, this.Name, this.TOpenParen, MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Annotation, this.KMetamodel, this.Name, this.TOpenParen, this.MetamodelPropertyList, TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Annotation, this.KMetamodel, this.Name, this.TOpenParen, this.MetamodelPropertyList, this.TCloseParen, TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax Update(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kMetamodel, NameSyntax name, SyntaxToken tOpenParen, MetamodelPropertyListSyntax metamodelPropertyList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
	    {
	        if (this.Annotation.Node != annotation.Node ||
				this.KMetamodel != kMetamodel ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.MetamodelPropertyList != metamodelPropertyList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.MetamodelDeclaration(annotation, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMetamodelDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitMetamodelDeclaration(this);
	    }
	}
	
	public sealed class MetamodelPropertyListSyntax : MetaModelSyntaxNode
	{
	    private SeparatedSyntaxNodeList metamodelProperty;
	
	    public MetamodelPropertyListSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MetamodelPropertyListSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<MetamodelPropertySyntax> MetamodelProperty 
		{ 
			get
			{
				var red = this.GetRed(ref this.metamodelProperty, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<MetamodelPropertySyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.metamodelProperty, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.metamodelProperty;
				default: return null;
	        }
	    }
	
	    public MetamodelPropertyListSyntax WithMetamodelProperty(SeparatedSyntaxNodeList<MetamodelPropertySyntax> metamodelProperty)
		{
			return this.Update(MetamodelProperty);
		}
	
	    public MetamodelPropertyListSyntax AddMetamodelProperty(params MetamodelPropertySyntax[] metamodelProperty)
		{
			return this.WithMetamodelProperty(this.MetamodelProperty.AddRange(metamodelProperty));
		}
	
	    public MetamodelPropertyListSyntax Update(SeparatedSyntaxNodeList<MetamodelPropertySyntax> metamodelProperty)
	    {
	        if (this.MetamodelProperty.Node != metamodelProperty.Node)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.MetamodelPropertyList(metamodelProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertyListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMetamodelPropertyList(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitMetamodelPropertyList(this);
	    }
	}
	
	public sealed class MetamodelPropertySyntax : MetaModelSyntaxNode
	{
	    private MetamodelUriPropertySyntax metamodelUriProperty;
	
	    public MetamodelPropertySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MetamodelPropertySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public MetamodelUriPropertySyntax MetamodelUriProperty 
		{ 
			get { return this.GetRed(ref this.metamodelUriProperty, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.metamodelUriProperty, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.metamodelUriProperty;
				default: return null;
	        }
	    }
	
	    public MetamodelPropertySyntax WithMetamodelUriProperty(MetamodelUriPropertySyntax metamodelUriProperty)
		{
			return this.Update(MetamodelUriProperty);
		}
	
	    public MetamodelPropertySyntax Update(MetamodelUriPropertySyntax metamodelUriProperty)
	    {
	        if (this.MetamodelUriProperty != metamodelUriProperty)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.MetamodelProperty(metamodelUriProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMetamodelProperty(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitMetamodelProperty(this);
	    }
	}
	
	public sealed class MetamodelUriPropertySyntax : MetaModelSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public MetamodelUriPropertySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MetamodelUriPropertySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IUri 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelUriPropertyGreen)this.Green;
				var greenToken = green.IUri;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelUriPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	    public StringLiteralSyntax StringLiteral 
		{ 
			get { return this.GetRed(ref this.stringLiteral, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.stringLiteral, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.stringLiteral;
				default: return null;
	        }
	    }
	
	    public MetamodelUriPropertySyntax WithIUri(SyntaxToken iUri)
		{
			return this.Update(IUri, this.TAssign, this.StringLiteral);
		}
	
	    public MetamodelUriPropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.IUri, TAssign, this.StringLiteral);
		}
	
	    public MetamodelUriPropertySyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(this.IUri, this.TAssign, StringLiteral);
		}
	
	    public MetamodelUriPropertySyntax Update(SyntaxToken iUri, SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
	    {
	        if (this.IUri != iUri ||
				this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.MetamodelUriProperty(iUri, tAssign, stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelUriPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMetamodelUriProperty(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitMetamodelUriProperty(this);
	    }
	}
	
	public sealed class DeclarationSyntax : MetaModelSyntaxNode
	{
	    private EnumDeclarationSyntax enumDeclaration;
	    private ClassDeclarationSyntax classDeclaration;
	    private AssociationDeclarationSyntax associationDeclaration;
	    private ConstDeclarationSyntax constDeclaration;
	
	    public DeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public EnumDeclarationSyntax EnumDeclaration 
		{ 
			get { return this.GetRed(ref this.enumDeclaration, 0); } 
		}
	    public ClassDeclarationSyntax ClassDeclaration 
		{ 
			get { return this.GetRed(ref this.classDeclaration, 1); } 
		}
	    public AssociationDeclarationSyntax AssociationDeclaration 
		{ 
			get { return this.GetRed(ref this.associationDeclaration, 2); } 
		}
	    public ConstDeclarationSyntax ConstDeclaration 
		{ 
			get { return this.GetRed(ref this.constDeclaration, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.enumDeclaration, 0);
				case 1: return this.GetRed(ref this.classDeclaration, 1);
				case 2: return this.GetRed(ref this.associationDeclaration, 2);
				case 3: return this.GetRed(ref this.constDeclaration, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.enumDeclaration;
				case 1: return this.classDeclaration;
				case 2: return this.associationDeclaration;
				case 3: return this.constDeclaration;
				default: return null;
	        }
	    }
	
	    public DeclarationSyntax WithEnumDeclaration(EnumDeclarationSyntax enumDeclaration)
		{
			return this.Update(enumDeclaration);
		}
	
	    public DeclarationSyntax WithClassDeclaration(ClassDeclarationSyntax classDeclaration)
		{
			return this.Update(classDeclaration);
		}
	
	    public DeclarationSyntax WithAssociationDeclaration(AssociationDeclarationSyntax associationDeclaration)
		{
			return this.Update(associationDeclaration);
		}
	
	    public DeclarationSyntax WithConstDeclaration(ConstDeclarationSyntax constDeclaration)
		{
			return this.Update(constDeclaration);
		}
	
	    public DeclarationSyntax Update(EnumDeclarationSyntax enumDeclaration)
	    {
	        if (this.EnumDeclaration != enumDeclaration)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Declaration(enumDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(ClassDeclarationSyntax classDeclaration)
	    {
	        if (this.ClassDeclaration != classDeclaration)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Declaration(classDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(AssociationDeclarationSyntax associationDeclaration)
	    {
	        if (this.AssociationDeclaration != associationDeclaration)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Declaration(associationDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(ConstDeclarationSyntax constDeclaration)
	    {
	        if (this.ConstDeclaration != constDeclaration)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Declaration(constDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration(this);
	    }
	}
	
	public sealed class EnumDeclarationSyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList annotation;
	    private NameSyntax name;
	    private EnumBodySyntax enumBody;
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null)
				{
					return new SyntaxNodeList<AnnotationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken KEnum 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.EnumDeclarationGreen)this.Green;
				var greenToken = green.KEnum;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public EnumBodySyntax EnumBody 
		{ 
			get { return this.GetRed(ref this.enumBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 2: return this.GetRed(ref this.name, 2);
				case 3: return this.GetRed(ref this.enumBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 2: return this.name;
				case 3: return this.enumBody;
				default: return null;
	        }
	    }
	
	    public EnumDeclarationSyntax WithAnnotation(SyntaxNodeList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.KEnum, this.Name, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public EnumDeclarationSyntax WithKEnum(SyntaxToken kEnum)
		{
			return this.Update(this.Annotation, KEnum, this.Name, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Annotation, this.KEnum, Name, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax WithEnumBody(EnumBodySyntax enumBody)
		{
			return this.Update(this.Annotation, this.KEnum, this.Name, EnumBody);
		}
	
	    public EnumDeclarationSyntax Update(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kEnum, NameSyntax name, EnumBodySyntax enumBody)
	    {
	        if (this.Annotation.Node != annotation.Node ||
				this.KEnum != kEnum ||
				this.Name != name ||
				this.EnumBody != enumBody)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.EnumDeclaration(annotation, kEnum, name, enumBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumDeclaration(this);
	    }
	}
	
	public sealed class EnumBodySyntax : MetaModelSyntaxNode
	{
	    private EnumValuesSyntax enumValues;
	    private SyntaxNodeList enumMemberDeclaration;
	
	    public EnumBodySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumBodySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public EnumValuesSyntax EnumValues 
		{ 
			get { return this.GetRed(ref this.enumValues, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public SyntaxNodeList<EnumMemberDeclarationSyntax> EnumMemberDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.enumMemberDeclaration, 3);
				if (red != null)
				{
					return new SyntaxNodeList<EnumMemberDeclarationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(4), this.GetChildIndex(4)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.enumValues, 1);
				case 3: return this.GetRed(ref this.enumMemberDeclaration, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.enumValues;
				case 3: return this.enumMemberDeclaration;
				default: return null;
	        }
	    }
	
	    public EnumBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.EnumValues, this.TSemicolon, this.EnumMemberDeclaration, this.TCloseBrace);
		}
	
	    public EnumBodySyntax WithEnumValues(EnumValuesSyntax enumValues)
		{
			return this.Update(this.TOpenBrace, EnumValues, this.TSemicolon, this.EnumMemberDeclaration, this.TCloseBrace);
		}
	
	    public EnumBodySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.TOpenBrace, this.EnumValues, TSemicolon, this.EnumMemberDeclaration, this.TCloseBrace);
		}
	
	    public EnumBodySyntax WithEnumMemberDeclaration(SyntaxNodeList<EnumMemberDeclarationSyntax> enumMemberDeclaration)
		{
			return this.Update(this.TOpenBrace, this.EnumValues, this.TSemicolon, EnumMemberDeclaration, this.TCloseBrace);
		}
	
	    public EnumBodySyntax AddEnumMemberDeclaration(params EnumMemberDeclarationSyntax[] enumMemberDeclaration)
		{
			return this.WithEnumMemberDeclaration(this.EnumMemberDeclaration.AddRange(enumMemberDeclaration));
		}
	
	    public EnumBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.EnumValues, this.TSemicolon, this.EnumMemberDeclaration, TCloseBrace);
		}
	
	    public EnumBodySyntax Update(SyntaxToken tOpenBrace, EnumValuesSyntax enumValues, SyntaxToken tSemicolon, SyntaxNodeList<EnumMemberDeclarationSyntax> enumMemberDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EnumValues != enumValues ||
				this.TSemicolon != tSemicolon ||
				this.EnumMemberDeclaration.Node != enumMemberDeclaration.Node ||
				this.TCloseBrace != tCloseBrace)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumBody(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumBody(this);
	    }
	}
	
	public sealed class EnumValuesSyntax : MetaModelSyntaxNode
	{
	    private SeparatedSyntaxNodeList enumValue;
	
	    public EnumValuesSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumValuesSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<EnumValueSyntax> EnumValue 
		{ 
			get
			{
				var red = this.GetRed(ref this.enumValue, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<EnumValueSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.enumValue, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.enumValue;
				default: return null;
	        }
	    }
	
	    public EnumValuesSyntax WithEnumValue(SeparatedSyntaxNodeList<EnumValueSyntax> enumValue)
		{
			return this.Update(EnumValue);
		}
	
	    public EnumValuesSyntax AddEnumValue(params EnumValueSyntax[] enumValue)
		{
			return this.WithEnumValue(this.EnumValue.AddRange(enumValue));
		}
	
	    public EnumValuesSyntax Update(SeparatedSyntaxNodeList<EnumValueSyntax> enumValue)
	    {
	        if (this.EnumValue.Node != enumValue.Node)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.EnumValues(enumValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumValuesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumValues(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumValues(this);
	    }
	}
	
	public sealed class EnumValueSyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList annotation;
	    private NameSyntax name;
	
	    public EnumValueSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumValueSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null)
				{
					return new SyntaxNodeList<AnnotationSyntax>(red);
				}
				return null;
			} 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 1: return this.GetRed(ref this.name, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 1: return this.name;
				default: return null;
	        }
	    }
	
	    public EnumValueSyntax WithAnnotation(SyntaxNodeList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.Name);
		}
	
	    public EnumValueSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public EnumValueSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Annotation, Name);
		}
	
	    public EnumValueSyntax Update(SyntaxNodeList<AnnotationSyntax> annotation, NameSyntax name)
	    {
	        if (this.Annotation.Node != annotation.Node ||
				this.Name != name)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.EnumValue(annotation, name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumValue(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumValue(this);
	    }
	}
	
	public sealed class EnumMemberDeclarationSyntax : MetaModelSyntaxNode
	{
	    private OperationDeclarationSyntax operationDeclaration;
	
	    public EnumMemberDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumMemberDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public OperationDeclarationSyntax OperationDeclaration 
		{ 
			get { return this.GetRed(ref this.operationDeclaration, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.operationDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.operationDeclaration;
				default: return null;
	        }
	    }
	
	    public EnumMemberDeclarationSyntax WithOperationDeclaration(OperationDeclarationSyntax operationDeclaration)
		{
			return this.Update(OperationDeclaration);
		}
	
	    public EnumMemberDeclarationSyntax Update(OperationDeclarationSyntax operationDeclaration)
	    {
	        if (this.OperationDeclaration != operationDeclaration)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.EnumMemberDeclaration(operationDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumMemberDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumMemberDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumMemberDeclaration(this);
	    }
	}
	
	public sealed class ClassDeclarationSyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList annotation;
	    private NameSyntax name;
	    private ClassAncestorsSyntax classAncestors;
	    private ClassBodySyntax classBody;
	
	    public ClassDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null)
				{
					return new SyntaxNodeList<AnnotationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken KAbstract 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassDeclarationGreen)this.Green;
				var greenToken = green.KAbstract;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	    public SyntaxToken KClass 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassDeclarationGreen)this.Green;
				var greenToken = green.KClass;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 3); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(4), this.GetChildIndex(4)); 
			}
		}
	    public ClassAncestorsSyntax ClassAncestors 
		{ 
			get { return this.GetRed(ref this.classAncestors, 5); } 
		}
	    public ClassBodySyntax ClassBody 
		{ 
			get { return this.GetRed(ref this.classBody, 6); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 3: return this.GetRed(ref this.name, 3);
				case 5: return this.GetRed(ref this.classAncestors, 5);
				case 6: return this.GetRed(ref this.classBody, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 3: return this.name;
				case 5: return this.classAncestors;
				case 6: return this.classBody;
				default: return null;
	        }
	    }
	
	    public ClassDeclarationSyntax WithAnnotation(SyntaxNodeList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.KAbstract, this.KClass, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public ClassDeclarationSyntax WithKAbstract(SyntaxToken kAbstract)
		{
			return this.Update(this.Annotation, KAbstract, this.KClass, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithKClass(SyntaxToken kClass)
		{
			return this.Update(this.Annotation, this.KAbstract, KClass, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Annotation, this.KAbstract, this.KClass, Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Annotation, this.KAbstract, this.KClass, this.Name, TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassAncestors(ClassAncestorsSyntax classAncestors)
		{
			return this.Update(this.Annotation, this.KAbstract, this.KClass, this.Name, this.TColon, ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassBody(ClassBodySyntax classBody)
		{
			return this.Update(this.Annotation, this.KAbstract, this.KClass, this.Name, this.TColon, this.ClassAncestors, ClassBody);
		}
	
	    public ClassDeclarationSyntax Update(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kAbstract, SyntaxToken kClass, NameSyntax name, SyntaxToken tColon, ClassAncestorsSyntax classAncestors, ClassBodySyntax classBody)
	    {
	        if (this.Annotation.Node != annotation.Node ||
				this.KAbstract != kAbstract ||
				this.KClass != kClass ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ClassAncestors != classAncestors ||
				this.ClassBody != classBody)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ClassDeclaration(annotation, kAbstract, kClass, name, tColon, classAncestors, classBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitClassDeclaration(this);
	    }
	}
	
	public sealed class ClassBodySyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList classMemberDeclaration;
	
	    public ClassBodySyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassBodySyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public SyntaxNodeList<ClassMemberDeclarationSyntax> ClassMemberDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.classMemberDeclaration, 1);
				if (red != null)
				{
					return new SyntaxNodeList<ClassMemberDeclarationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(2), this.GetChildIndex(2)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.classMemberDeclaration, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.classMemberDeclaration;
				default: return null;
	        }
	    }
	
	    public ClassBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.ClassMemberDeclaration, this.TCloseBrace);
		}
	
	    public ClassBodySyntax WithClassMemberDeclaration(SyntaxNodeList<ClassMemberDeclarationSyntax> classMemberDeclaration)
		{
			return this.Update(this.TOpenBrace, ClassMemberDeclaration, this.TCloseBrace);
		}
	
	    public ClassBodySyntax AddClassMemberDeclaration(params ClassMemberDeclarationSyntax[] classMemberDeclaration)
		{
			return this.WithClassMemberDeclaration(this.ClassMemberDeclaration.AddRange(classMemberDeclaration));
		}
	
	    public ClassBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.ClassMemberDeclaration, TCloseBrace);
		}
	
	    public ClassBodySyntax Update(SyntaxToken tOpenBrace, SyntaxNodeList<ClassMemberDeclarationSyntax> classMemberDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ClassMemberDeclaration.Node != classMemberDeclaration.Node ||
				this.TCloseBrace != tCloseBrace)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassBody(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitClassBody(this);
	    }
	}
	
	public sealed class ClassAncestorsSyntax : MetaModelSyntaxNode
	{
	    private SeparatedSyntaxNodeList classAncestor;
	
	    public ClassAncestorsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassAncestorsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<ClassAncestorSyntax> ClassAncestor 
		{ 
			get
			{
				var red = this.GetRed(ref this.classAncestor, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<ClassAncestorSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.classAncestor, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.classAncestor;
				default: return null;
	        }
	    }
	
	    public ClassAncestorsSyntax WithClassAncestor(SeparatedSyntaxNodeList<ClassAncestorSyntax> classAncestor)
		{
			return this.Update(ClassAncestor);
		}
	
	    public ClassAncestorsSyntax AddClassAncestor(params ClassAncestorSyntax[] classAncestor)
		{
			return this.WithClassAncestor(this.ClassAncestor.AddRange(classAncestor));
		}
	
	    public ClassAncestorsSyntax Update(SeparatedSyntaxNodeList<ClassAncestorSyntax> classAncestor)
	    {
	        if (this.ClassAncestor.Node != classAncestor.Node)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ClassAncestors(classAncestor);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassAncestorsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassAncestors(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitClassAncestors(this);
	    }
	}
	
	public sealed class ClassAncestorSyntax : MetaModelSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public ClassAncestorSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassAncestorSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public ClassAncestorSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public ClassAncestorSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ClassAncestor(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassAncestorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassAncestor(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitClassAncestor(this);
	    }
	}
	
	public sealed class ClassMemberDeclarationSyntax : MetaModelSyntaxNode
	{
	    private FieldDeclarationSyntax fieldDeclaration;
	    private OperationDeclarationSyntax operationDeclaration;
	
	    public ClassMemberDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassMemberDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public FieldDeclarationSyntax FieldDeclaration 
		{ 
			get { return this.GetRed(ref this.fieldDeclaration, 0); } 
		}
	    public OperationDeclarationSyntax OperationDeclaration 
		{ 
			get { return this.GetRed(ref this.operationDeclaration, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.fieldDeclaration, 0);
				case 1: return this.GetRed(ref this.operationDeclaration, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.fieldDeclaration;
				case 1: return this.operationDeclaration;
				default: return null;
	        }
	    }
	
	    public ClassMemberDeclarationSyntax WithFieldDeclaration(FieldDeclarationSyntax fieldDeclaration)
		{
			return this.Update(fieldDeclaration);
		}
	
	    public ClassMemberDeclarationSyntax WithOperationDeclaration(OperationDeclarationSyntax operationDeclaration)
		{
			return this.Update(operationDeclaration);
		}
	
	    public ClassMemberDeclarationSyntax Update(FieldDeclarationSyntax fieldDeclaration)
	    {
	        if (this.FieldDeclaration != fieldDeclaration)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ClassMemberDeclaration(fieldDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassMemberDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ClassMemberDeclarationSyntax Update(OperationDeclarationSyntax operationDeclaration)
	    {
	        if (this.OperationDeclaration != operationDeclaration)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ClassMemberDeclaration(operationDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassMemberDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassMemberDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitClassMemberDeclaration(this);
	    }
	}
	
	public sealed class FieldDeclarationSyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList annotation;
	    private FieldModifierSyntax fieldModifier;
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	    private RedefinitionsOrSubsettingsSyntax redefinitionsOrSubsettings;
	
	    public FieldDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null)
				{
					return new SyntaxNodeList<AnnotationSyntax>(red);
				}
				return null;
			} 
		}
	    public FieldModifierSyntax FieldModifier 
		{ 
			get { return this.GetRed(ref this.fieldModifier, 1); } 
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 3); } 
		}
	    public RedefinitionsOrSubsettingsSyntax RedefinitionsOrSubsettings 
		{ 
			get { return this.GetRed(ref this.redefinitionsOrSubsettings, 4); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.FieldDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(5), this.GetChildIndex(5)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 1: return this.GetRed(ref this.fieldModifier, 1);
				case 2: return this.GetRed(ref this.typeReference, 2);
				case 3: return this.GetRed(ref this.name, 3);
				case 4: return this.GetRed(ref this.redefinitionsOrSubsettings, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 1: return this.fieldModifier;
				case 2: return this.typeReference;
				case 3: return this.name;
				case 4: return this.redefinitionsOrSubsettings;
				default: return null;
	        }
	    }
	
	    public FieldDeclarationSyntax WithAnnotation(SyntaxNodeList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.FieldModifier, this.TypeReference, this.Name, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public FieldDeclarationSyntax WithFieldModifier(FieldModifierSyntax fieldModifier)
		{
			return this.Update(this.Annotation, FieldModifier, this.TypeReference, this.Name, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Annotation, this.FieldModifier, TypeReference, this.Name, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Annotation, this.FieldModifier, this.TypeReference, Name, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax redefinitionsOrSubsettings)
		{
			return this.Update(this.Annotation, this.FieldModifier, this.TypeReference, this.Name, RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Annotation, this.FieldModifier, this.TypeReference, this.Name, this.RedefinitionsOrSubsettings, TSemicolon);
		}
	
	    public FieldDeclarationSyntax Update(SyntaxNodeList<AnnotationSyntax> annotation, FieldModifierSyntax fieldModifier, TypeReferenceSyntax typeReference, NameSyntax name, RedefinitionsOrSubsettingsSyntax redefinitionsOrSubsettings, SyntaxToken tSemicolon)
	    {
	        if (this.Annotation.Node != annotation.Node ||
				this.FieldModifier != fieldModifier ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.RedefinitionsOrSubsettings != redefinitionsOrSubsettings ||
				this.TSemicolon != tSemicolon)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.FieldDeclaration(annotation, fieldModifier, typeReference, name, redefinitionsOrSubsettings, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldDeclaration(this);
	    }
	}
	
	public sealed class FieldModifierSyntax : MetaModelSyntaxNode
	{
	
	    public FieldModifierSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldModifierSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken FieldModifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.FieldModifierGreen)this.Green;
				var greenToken = green.FieldModifier;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public FieldModifierSyntax WithFieldModifier(SyntaxToken fieldModifier)
		{
			return this.Update(FieldModifier);
		}
	
	    public FieldModifierSyntax Update(SyntaxToken fieldModifier)
	    {
	        if (this.FieldModifier != fieldModifier)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.FieldModifier(fieldModifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldModifier(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldModifier(this);
	    }
	}
	
	public sealed class RedefinitionsOrSubsettingsSyntax : MetaModelSyntaxNode
	{
	    private RedefinitionsSyntax redefinitions;
	    private SubsettingsSyntax subsettings;
	
	    public RedefinitionsOrSubsettingsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RedefinitionsOrSubsettingsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public RedefinitionsSyntax Redefinitions 
		{ 
			get { return this.GetRed(ref this.redefinitions, 0); } 
		}
	    public SubsettingsSyntax Subsettings 
		{ 
			get { return this.GetRed(ref this.subsettings, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.redefinitions, 0);
				case 1: return this.GetRed(ref this.subsettings, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.redefinitions;
				case 1: return this.subsettings;
				default: return null;
	        }
	    }
	
	    public RedefinitionsOrSubsettingsSyntax WithRedefinitions(RedefinitionsSyntax redefinitions)
		{
			return this.Update(redefinitions);
		}
	
	    public RedefinitionsOrSubsettingsSyntax WithSubsettings(SubsettingsSyntax subsettings)
		{
			return this.Update(subsettings);
		}
	
	    public RedefinitionsOrSubsettingsSyntax Update(RedefinitionsSyntax redefinitions)
	    {
	        if (this.Redefinitions != redefinitions)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.RedefinitionsOrSubsettings(redefinitions);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RedefinitionsOrSubsettingsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public RedefinitionsOrSubsettingsSyntax Update(SubsettingsSyntax subsettings)
	    {
	        if (this.Subsettings != subsettings)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.RedefinitionsOrSubsettings(subsettings);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RedefinitionsOrSubsettingsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRedefinitionsOrSubsettings(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitRedefinitionsOrSubsettings(this);
	    }
	}
	
	public sealed class RedefinitionsSyntax : MetaModelSyntaxNode
	{
	    private NameUseListSyntax nameUseList;
	
	    public RedefinitionsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RedefinitionsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KRedefines 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.RedefinitionsGreen)this.Green;
				var greenToken = green.KRedefines;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public NameUseListSyntax NameUseList 
		{ 
			get { return this.GetRed(ref this.nameUseList, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.nameUseList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.nameUseList;
				default: return null;
	        }
	    }
	
	    public RedefinitionsSyntax WithKRedefines(SyntaxToken kRedefines)
		{
			return this.Update(KRedefines, this.NameUseList);
		}
	
	    public RedefinitionsSyntax WithNameUseList(NameUseListSyntax nameUseList)
		{
			return this.Update(this.KRedefines, NameUseList);
		}
	
	    public RedefinitionsSyntax Update(SyntaxToken kRedefines, NameUseListSyntax nameUseList)
	    {
	        if (this.KRedefines != kRedefines ||
				this.NameUseList != nameUseList)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Redefinitions(kRedefines, nameUseList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RedefinitionsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRedefinitions(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitRedefinitions(this);
	    }
	}
	
	public sealed class SubsettingsSyntax : MetaModelSyntaxNode
	{
	    private NameUseListSyntax nameUseList;
	
	    public SubsettingsSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SubsettingsSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KSubsets 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.SubsettingsGreen)this.Green;
				var greenToken = green.KSubsets;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public NameUseListSyntax NameUseList 
		{ 
			get { return this.GetRed(ref this.nameUseList, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.nameUseList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.nameUseList;
				default: return null;
	        }
	    }
	
	    public SubsettingsSyntax WithKSubsets(SyntaxToken kSubsets)
		{
			return this.Update(KSubsets, this.NameUseList);
		}
	
	    public SubsettingsSyntax WithNameUseList(NameUseListSyntax nameUseList)
		{
			return this.Update(this.KSubsets, NameUseList);
		}
	
	    public SubsettingsSyntax Update(SyntaxToken kSubsets, NameUseListSyntax nameUseList)
	    {
	        if (this.KSubsets != kSubsets ||
				this.NameUseList != nameUseList)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Subsettings(kSubsets, nameUseList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SubsettingsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSubsettings(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitSubsettings(this);
	    }
	}
	
	public sealed class NameUseListSyntax : MetaModelSyntaxNode
	{
	    private SeparatedSyntaxNodeList qualifier;
	
	    public NameUseListSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameUseListSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<QualifierSyntax> Qualifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.qualifier, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<QualifierSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public NameUseListSyntax WithQualifier(SeparatedSyntaxNodeList<QualifierSyntax> qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public NameUseListSyntax AddQualifier(params QualifierSyntax[] qualifier)
		{
			return this.WithQualifier(this.Qualifier.AddRange(qualifier));
		}
	
	    public NameUseListSyntax Update(SeparatedSyntaxNodeList<QualifierSyntax> qualifier)
	    {
	        if (this.Qualifier.Node != qualifier.Node)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.NameUseList(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameUseListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNameUseList(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitNameUseList(this);
	    }
	}
	
	public sealed class ConstDeclarationSyntax : MetaModelSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	
	    public ConstDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ConstDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KConst 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ConstDeclarationGreen)this.Green;
				var greenToken = green.KConst;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 1); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ConstDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 2: return this.GetRed(ref this.name, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.typeReference;
				case 2: return this.name;
				default: return null;
	        }
	    }
	
	    public ConstDeclarationSyntax WithKConst(SyntaxToken kConst)
		{
			return this.Update(KConst, this.TypeReference, this.Name, this.TSemicolon);
		}
	
	    public ConstDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KConst, TypeReference, this.Name, this.TSemicolon);
		}
	
	    public ConstDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KConst, this.TypeReference, Name, this.TSemicolon);
		}
	
	    public ConstDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KConst, this.TypeReference, this.Name, TSemicolon);
		}
	
	    public ConstDeclarationSyntax Update(SyntaxToken kConst, TypeReferenceSyntax typeReference, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KConst != kConst ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ConstDeclaration(kConst, typeReference, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConstDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitConstDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitConstDeclaration(this);
	    }
	}
	
	public sealed class ReturnTypeSyntax : MetaModelSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private VoidTypeSyntax voidType;
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public VoidTypeSyntax VoidType 
		{ 
			get { return this.GetRed(ref this.voidType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				case 1: return this.GetRed(ref this.voidType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				case 1: return this.voidType;
				default: return null;
	        }
	    }
	
	    public ReturnTypeSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(typeReference);
		}
	
	    public ReturnTypeSyntax WithVoidType(VoidTypeSyntax voidType)
		{
			return this.Update(voidType);
		}
	
	    public ReturnTypeSyntax Update(TypeReferenceSyntax typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ReturnType(typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ReturnTypeSyntax Update(VoidTypeSyntax voidType)
	    {
	        if (this.VoidType != voidType)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ReturnType(voidType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReturnType(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitReturnType(this);
	    }
	}
	
	public sealed class TypeOfReferenceSyntax : MetaModelSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	
	    public TypeOfReferenceSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeOfReferenceSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public TypeOfReferenceSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference);
		}
	
	    public TypeOfReferenceSyntax Update(TypeReferenceSyntax typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.TypeOfReference(typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeOfReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeOfReference(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeOfReference(this);
	    }
	}
	
	public sealed class TypeReferenceSyntax : MetaModelSyntaxNode
	{
	    private CollectionTypeSyntax collectionType;
	    private SimpleTypeSyntax simpleType;
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public CollectionTypeSyntax CollectionType 
		{ 
			get { return this.GetRed(ref this.collectionType, 0); } 
		}
	    public SimpleTypeSyntax SimpleType 
		{ 
			get { return this.GetRed(ref this.simpleType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.collectionType, 0);
				case 1: return this.GetRed(ref this.simpleType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.collectionType;
				case 1: return this.simpleType;
				default: return null;
	        }
	    }
	
	    public TypeReferenceSyntax WithCollectionType(CollectionTypeSyntax collectionType)
		{
			return this.Update(collectionType);
		}
	
	    public TypeReferenceSyntax WithSimpleType(SimpleTypeSyntax simpleType)
		{
			return this.Update(simpleType);
		}
	
	    public TypeReferenceSyntax Update(CollectionTypeSyntax collectionType)
	    {
	        if (this.CollectionType != collectionType)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.TypeReference(collectionType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TypeReferenceSyntax Update(SimpleTypeSyntax simpleType)
	    {
	        if (this.SimpleType != simpleType)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.TypeReference(simpleType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeReference(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeReference(this);
	    }
	}
	
	public sealed class SimpleTypeSyntax : MetaModelSyntaxNode
	{
	    private PrimitiveTypeSyntax primitiveType;
	    private ObjectTypeSyntax objectType;
	    private NullableTypeSyntax nullableType;
	    private QualifierSyntax qualifier;
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public PrimitiveTypeSyntax PrimitiveType 
		{ 
			get { return this.GetRed(ref this.primitiveType, 0); } 
		}
	    public ObjectTypeSyntax ObjectType 
		{ 
			get { return this.GetRed(ref this.objectType, 1); } 
		}
	    public NullableTypeSyntax NullableType 
		{ 
			get { return this.GetRed(ref this.nullableType, 2); } 
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.primitiveType, 0);
				case 1: return this.GetRed(ref this.objectType, 1);
				case 2: return this.GetRed(ref this.nullableType, 2);
				case 3: return this.GetRed(ref this.qualifier, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.primitiveType;
				case 1: return this.objectType;
				case 2: return this.nullableType;
				case 3: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public SimpleTypeSyntax WithPrimitiveType(PrimitiveTypeSyntax primitiveType)
		{
			return this.Update(primitiveType);
		}
	
	    public SimpleTypeSyntax WithObjectType(ObjectTypeSyntax objectType)
		{
			return this.Update(objectType);
		}
	
	    public SimpleTypeSyntax WithNullableType(NullableTypeSyntax nullableType)
		{
			return this.Update(nullableType);
		}
	
	    public SimpleTypeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(qualifier);
		}
	
	    public SimpleTypeSyntax Update(PrimitiveTypeSyntax primitiveType)
	    {
	        if (this.PrimitiveType != primitiveType)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.SimpleType(primitiveType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SimpleTypeSyntax Update(ObjectTypeSyntax objectType)
	    {
	        if (this.ObjectType != objectType)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.SimpleType(objectType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SimpleTypeSyntax Update(NullableTypeSyntax nullableType)
	    {
	        if (this.NullableType != nullableType)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.SimpleType(nullableType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SimpleTypeSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.SimpleType(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleType(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleType(this);
	    }
	}
	
	public sealed class ClassTypeSyntax : MetaModelSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public ClassTypeSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassTypeSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public ClassTypeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public ClassTypeSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ClassType(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassType(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitClassType(this);
	    }
	}
	
	public sealed class ObjectTypeSyntax : MetaModelSyntaxNode
	{
	
	    public ObjectTypeSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ObjectTypeSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ObjectType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ObjectTypeGreen)this.Green;
				var greenToken = green.ObjectType;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public ObjectTypeSyntax WithObjectType(SyntaxToken objectType)
		{
			return this.Update(ObjectType);
		}
	
	    public ObjectTypeSyntax Update(SyntaxToken objectType)
	    {
	        if (this.ObjectType != objectType)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ObjectType(objectType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitObjectType(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitObjectType(this);
	    }
	}
	
	public sealed class PrimitiveTypeSyntax : MetaModelSyntaxNode
	{
	
	    public PrimitiveTypeSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PrimitiveTypeSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken PrimitiveType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.PrimitiveTypeGreen)this.Green;
				var greenToken = green.PrimitiveType;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public PrimitiveTypeSyntax WithPrimitiveType(SyntaxToken primitiveType)
		{
			return this.Update(PrimitiveType);
		}
	
	    public PrimitiveTypeSyntax Update(SyntaxToken primitiveType)
	    {
	        if (this.PrimitiveType != primitiveType)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.PrimitiveType(primitiveType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PrimitiveTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPrimitiveType(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitPrimitiveType(this);
	    }
	}
	
	public sealed class VoidTypeSyntax : MetaModelSyntaxNode
	{
	
	    public VoidTypeSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VoidTypeSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVoid 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.VoidTypeGreen)this.Green;
				var greenToken = green.KVoid;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public VoidTypeSyntax WithKVoid(SyntaxToken kVoid)
		{
			return this.Update(KVoid);
		}
	
	    public VoidTypeSyntax Update(SyntaxToken kVoid)
	    {
	        if (this.KVoid != kVoid)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.VoidType(kVoid);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VoidTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVoidType(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitVoidType(this);
	    }
	}
	
	public sealed class NullableTypeSyntax : MetaModelSyntaxNode
	{
	    private PrimitiveTypeSyntax primitiveType;
	
	    public NullableTypeSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullableTypeSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public PrimitiveTypeSyntax PrimitiveType 
		{ 
			get { return this.GetRed(ref this.primitiveType, 0); } 
		}
	    public SyntaxToken TQuestion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.NullableTypeGreen)this.Green;
				var greenToken = green.TQuestion;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.primitiveType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.primitiveType;
				default: return null;
	        }
	    }
	
	    public NullableTypeSyntax WithPrimitiveType(PrimitiveTypeSyntax primitiveType)
		{
			return this.Update(PrimitiveType, this.TQuestion);
		}
	
	    public NullableTypeSyntax WithTQuestion(SyntaxToken tQuestion)
		{
			return this.Update(this.PrimitiveType, TQuestion);
		}
	
	    public NullableTypeSyntax Update(PrimitiveTypeSyntax primitiveType, SyntaxToken tQuestion)
	    {
	        if (this.PrimitiveType != primitiveType ||
				this.TQuestion != tQuestion)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.NullableType(primitiveType, tQuestion);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullableType(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitNullableType(this);
	    }
	}
	
	public sealed class CollectionTypeSyntax : MetaModelSyntaxNode
	{
	    private CollectionKindSyntax collectionKind;
	    private SimpleTypeSyntax simpleType;
	
	    public CollectionTypeSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CollectionTypeSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public CollectionKindSyntax CollectionKind 
		{ 
			get { return this.GetRed(ref this.collectionKind, 0); } 
		}
	    public SyntaxToken TLessThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.CollectionTypeGreen)this.Green;
				var greenToken = green.TLessThan;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	    public SimpleTypeSyntax SimpleType 
		{ 
			get { return this.GetRed(ref this.simpleType, 2); } 
		}
	    public SyntaxToken TGreaterThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.CollectionTypeGreen)this.Green;
				var greenToken = green.TGreaterThan;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.collectionKind, 0);
				case 2: return this.GetRed(ref this.simpleType, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.collectionKind;
				case 2: return this.simpleType;
				default: return null;
	        }
	    }
	
	    public CollectionTypeSyntax WithCollectionKind(CollectionKindSyntax collectionKind)
		{
			return this.Update(CollectionKind, this.TLessThan, this.SimpleType, this.TGreaterThan);
		}
	
	    public CollectionTypeSyntax WithTLessThan(SyntaxToken tLessThan)
		{
			return this.Update(this.CollectionKind, TLessThan, this.SimpleType, this.TGreaterThan);
		}
	
	    public CollectionTypeSyntax WithSimpleType(SimpleTypeSyntax simpleType)
		{
			return this.Update(this.CollectionKind, this.TLessThan, SimpleType, this.TGreaterThan);
		}
	
	    public CollectionTypeSyntax WithTGreaterThan(SyntaxToken tGreaterThan)
		{
			return this.Update(this.CollectionKind, this.TLessThan, this.SimpleType, TGreaterThan);
		}
	
	    public CollectionTypeSyntax Update(CollectionKindSyntax collectionKind, SyntaxToken tLessThan, SimpleTypeSyntax simpleType, SyntaxToken tGreaterThan)
	    {
	        if (this.CollectionKind != collectionKind ||
				this.TLessThan != tLessThan ||
				this.SimpleType != simpleType ||
				this.TGreaterThan != tGreaterThan)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.CollectionType(collectionKind, tLessThan, simpleType, tGreaterThan);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CollectionTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCollectionType(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitCollectionType(this);
	    }
	}
	
	public sealed class CollectionKindSyntax : MetaModelSyntaxNode
	{
	
	    public CollectionKindSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CollectionKindSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken CollectionKind 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.CollectionKindGreen)this.Green;
				var greenToken = green.CollectionKind;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public CollectionKindSyntax WithCollectionKind(SyntaxToken collectionKind)
		{
			return this.Update(CollectionKind);
		}
	
	    public CollectionKindSyntax Update(SyntaxToken collectionKind)
	    {
	        if (this.CollectionKind != collectionKind)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.CollectionKind(collectionKind);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CollectionKindSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCollectionKind(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitCollectionKind(this);
	    }
	}
	
	public sealed class OperationDeclarationSyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList annotation;
	    private ReturnTypeSyntax returnType;
	    private NameSyntax name;
	    private ParameterListSyntax parameterList;
	
	    public OperationDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null)
				{
					return new SyntaxNodeList<AnnotationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken KStatic 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.KStatic;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	    public ReturnTypeSyntax ReturnType 
		{ 
			get { return this.GetRed(ref this.returnType, 2); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 3); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TOpenParen;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(4), this.GetChildIndex(4)); 
			}
		}
	    public ParameterListSyntax ParameterList 
		{ 
			get { return this.GetRed(ref this.parameterList, 5); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TCloseParen;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(6), this.GetChildIndex(6)); 
			}
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(7), this.GetChildIndex(7)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 2: return this.GetRed(ref this.returnType, 2);
				case 3: return this.GetRed(ref this.name, 3);
				case 5: return this.GetRed(ref this.parameterList, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 2: return this.returnType;
				case 3: return this.name;
				case 5: return this.parameterList;
				default: return null;
	        }
	    }
	
	    public OperationDeclarationSyntax WithAnnotation(SyntaxNodeList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.KStatic, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public OperationDeclarationSyntax WithKStatic(SyntaxToken kStatic)
		{
			return this.Update(this.Annotation, KStatic, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithReturnType(ReturnTypeSyntax returnType)
		{
			return this.Update(this.Annotation, this.KStatic, ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Annotation, this.KStatic, this.ReturnType, Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Annotation, this.KStatic, this.ReturnType, this.Name, TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithParameterList(ParameterListSyntax parameterList)
		{
			return this.Update(this.Annotation, this.KStatic, this.ReturnType, this.Name, this.TOpenParen, ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Annotation, this.KStatic, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Annotation, this.KStatic, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, TSemicolon);
		}
	
	    public OperationDeclarationSyntax Update(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kStatic, ReturnTypeSyntax returnType, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
	    {
	        if (this.Annotation.Node != annotation.Node ||
				this.KStatic != kStatic ||
				this.ReturnType != returnType ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.ParameterList != parameterList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.OperationDeclaration(annotation, kStatic, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationDeclaration(this);
	    }
	}
	
	public sealed class ParameterListSyntax : MetaModelSyntaxNode
	{
	    private SeparatedSyntaxNodeList parameter;
	
	    public ParameterListSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParameterListSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxNodeList<ParameterSyntax> Parameter 
		{ 
			get
			{
				var red = this.GetRed(ref this.parameter, 0);
				if (red != null)
				{
					return new SeparatedSyntaxNodeList<ParameterSyntax>(red);
				}
				return null;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.parameter, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.parameter;
				default: return null;
	        }
	    }
	
	    public ParameterListSyntax WithParameter(SeparatedSyntaxNodeList<ParameterSyntax> parameter)
		{
			return this.Update(Parameter);
		}
	
	    public ParameterListSyntax AddParameter(params ParameterSyntax[] parameter)
		{
			return this.WithParameter(this.Parameter.AddRange(parameter));
		}
	
	    public ParameterListSyntax Update(SeparatedSyntaxNodeList<ParameterSyntax> parameter)
	    {
	        if (this.Parameter.Node != parameter.Node)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ParameterList(parameter);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParameterList(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitParameterList(this);
	    }
	}
	
	public sealed class ParameterSyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList annotation;
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	
	    public ParameterSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParameterSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null)
				{
					return new SyntaxNodeList<AnnotationSyntax>(red);
				}
				return null;
			} 
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 1); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 2: return this.GetRed(ref this.name, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 1: return this.typeReference;
				case 2: return this.name;
				default: return null;
	        }
	    }
	
	    public ParameterSyntax WithAnnotation(SyntaxNodeList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.TypeReference, this.Name);
		}
	
	    public ParameterSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public ParameterSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Annotation, TypeReference, this.Name);
		}
	
	    public ParameterSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Annotation, this.TypeReference, Name);
		}
	
	    public ParameterSyntax Update(SyntaxNodeList<AnnotationSyntax> annotation, TypeReferenceSyntax typeReference, NameSyntax name)
	    {
	        if (this.Annotation.Node != annotation.Node ||
				this.TypeReference != typeReference ||
				this.Name != name)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Parameter(annotation, typeReference, name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParameter(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitParameter(this);
	    }
	}
	
	public sealed class AssociationDeclarationSyntax : MetaModelSyntaxNode
	{
	    private SyntaxNodeList annotation;
	    private QualifierSyntax source;
	    private QualifierSyntax target;
	
	    public AssociationDeclarationSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssociationDeclarationSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxNodeList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null)
				{
					return new SyntaxNodeList<AnnotationSyntax>(red);
				}
				return null;
			} 
		}
	    public SyntaxToken KAssociation 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.AssociationDeclarationGreen)this.Green;
				var greenToken = green.KAssociation;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(1), this.GetChildIndex(1)); 
			}
		}
	    public QualifierSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 2); } 
		}
	    public SyntaxToken KWith 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.AssociationDeclarationGreen)this.Green;
				var greenToken = green.KWith;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(3), this.GetChildIndex(3)); 
			}
		}
	    public QualifierSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 4); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.AssociationDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(5), this.GetChildIndex(5)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 2: return this.GetRed(ref this.source, 2);
				case 4: return this.GetRed(ref this.target, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 2: return this.source;
				case 4: return this.target;
				default: return null;
	        }
	    }
	
	    public AssociationDeclarationSyntax WithAnnotation(SyntaxNodeList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.KAssociation, this.Source, this.KWith, this.Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public AssociationDeclarationSyntax WithKAssociation(SyntaxToken kAssociation)
		{
			return this.Update(this.Annotation, KAssociation, this.Source, this.KWith, this.Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax WithSource(QualifierSyntax source)
		{
			return this.Update(this.Annotation, this.KAssociation, Source, this.KWith, this.Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax WithKWith(SyntaxToken kWith)
		{
			return this.Update(this.Annotation, this.KAssociation, this.Source, KWith, this.Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax WithTarget(QualifierSyntax target)
		{
			return this.Update(this.Annotation, this.KAssociation, this.Source, this.KWith, Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Annotation, this.KAssociation, this.Source, this.KWith, this.Target, TSemicolon);
		}
	
	    public AssociationDeclarationSyntax Update(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kAssociation, QualifierSyntax source, SyntaxToken kWith, QualifierSyntax target, SyntaxToken tSemicolon)
	    {
	        if (this.Annotation.Node != annotation.Node ||
				this.KAssociation != kAssociation ||
				this.Source != source ||
				this.KWith != kWith ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.AssociationDeclaration(annotation, kAssociation, source, kWith, target, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssociationDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssociationDeclaration(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitAssociationDeclaration(this);
	    }
	}
	
	public sealed class IdentifierSyntax : MetaModelSyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Identifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.IdentifierGreen)this.Green;
				var greenToken = green.Identifier;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public IdentifierSyntax WithIdentifier(SyntaxToken identifier)
		{
			return this.Update(Identifier);
		}
	
	    public IdentifierSyntax Update(SyntaxToken identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Identifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class LiteralSyntax : MetaModelSyntaxNode
	{
	    private NullLiteralSyntax nullLiteral;
	    private BooleanLiteralSyntax booleanLiteral;
	    private IntegerLiteralSyntax integerLiteral;
	    private DecimalLiteralSyntax decimalLiteral;
	    private ScientificLiteralSyntax scientificLiteral;
	    private StringLiteralSyntax stringLiteral;
	
	    public LiteralSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NullLiteralSyntax NullLiteral 
		{ 
			get { return this.GetRed(ref this.nullLiteral, 0); } 
		}
	    public BooleanLiteralSyntax BooleanLiteral 
		{ 
			get { return this.GetRed(ref this.booleanLiteral, 1); } 
		}
	    public IntegerLiteralSyntax IntegerLiteral 
		{ 
			get { return this.GetRed(ref this.integerLiteral, 2); } 
		}
	    public DecimalLiteralSyntax DecimalLiteral 
		{ 
			get { return this.GetRed(ref this.decimalLiteral, 3); } 
		}
	    public ScientificLiteralSyntax ScientificLiteral 
		{ 
			get { return this.GetRed(ref this.scientificLiteral, 4); } 
		}
	    public StringLiteralSyntax StringLiteral 
		{ 
			get { return this.GetRed(ref this.stringLiteral, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.nullLiteral, 0);
				case 1: return this.GetRed(ref this.booleanLiteral, 1);
				case 2: return this.GetRed(ref this.integerLiteral, 2);
				case 3: return this.GetRed(ref this.decimalLiteral, 3);
				case 4: return this.GetRed(ref this.scientificLiteral, 4);
				case 5: return this.GetRed(ref this.stringLiteral, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.nullLiteral;
				case 1: return this.booleanLiteral;
				case 2: return this.integerLiteral;
				case 3: return this.decimalLiteral;
				case 4: return this.scientificLiteral;
				case 5: return this.stringLiteral;
				default: return null;
	        }
	    }
	
	    public LiteralSyntax WithNullLiteral(NullLiteralSyntax nullLiteral)
		{
			return this.Update(nullLiteral);
		}
	
	    public LiteralSyntax WithBooleanLiteral(BooleanLiteralSyntax booleanLiteral)
		{
			return this.Update(booleanLiteral);
		}
	
	    public LiteralSyntax WithIntegerLiteral(IntegerLiteralSyntax integerLiteral)
		{
			return this.Update(integerLiteral);
		}
	
	    public LiteralSyntax WithDecimalLiteral(DecimalLiteralSyntax decimalLiteral)
		{
			return this.Update(decimalLiteral);
		}
	
	    public LiteralSyntax WithScientificLiteral(ScientificLiteralSyntax scientificLiteral)
		{
			return this.Update(scientificLiteral);
		}
	
	    public LiteralSyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(stringLiteral);
		}
	
	    public LiteralSyntax Update(NullLiteralSyntax nullLiteral)
	    {
	        if (this.NullLiteral != nullLiteral)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Literal(nullLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(BooleanLiteralSyntax booleanLiteral)
	    {
	        if (this.BooleanLiteral != booleanLiteral)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Literal(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(IntegerLiteralSyntax integerLiteral)
	    {
	        if (this.IntegerLiteral != integerLiteral)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Literal(integerLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(DecimalLiteralSyntax decimalLiteral)
	    {
	        if (this.DecimalLiteral != decimalLiteral)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Literal(decimalLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(ScientificLiteralSyntax scientificLiteral)
	    {
	        if (this.ScientificLiteral != scientificLiteral)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Literal(scientificLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(StringLiteralSyntax stringLiteral)
	    {
	        if (this.StringLiteral != stringLiteral)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.Literal(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteral(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteral(this);
	    }
	}
	
	public sealed class NullLiteralSyntax : MetaModelSyntaxNode
	{
	
	    public NullLiteralSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullLiteralSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNull 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.NullLiteralGreen)this.Green;
				var greenToken = green.KNull;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public NullLiteralSyntax WithKNull(SyntaxToken kNull)
		{
			return this.Update(KNull);
		}
	
	    public NullLiteralSyntax Update(SyntaxToken kNull)
	    {
	        if (this.KNull != kNull)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.NullLiteral(kNull);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullLiteral(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitNullLiteral(this);
	    }
	}
	
	public sealed class BooleanLiteralSyntax : MetaModelSyntaxNode
	{
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BooleanLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.BooleanLiteralGreen)this.Green;
				var greenToken = green.BooleanLiteral;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public BooleanLiteralSyntax WithBooleanLiteral(SyntaxToken booleanLiteral)
		{
			return this.Update(BooleanLiteral);
		}
	
	    public BooleanLiteralSyntax Update(SyntaxToken booleanLiteral)
	    {
	        if (this.BooleanLiteral != booleanLiteral)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.BooleanLiteral(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BooleanLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBooleanLiteral(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitBooleanLiteral(this);
	    }
	}
	
	public sealed class IntegerLiteralSyntax : MetaModelSyntaxNode
	{
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LInteger 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.IntegerLiteralGreen)this.Green;
				var greenToken = green.LInteger;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public IntegerLiteralSyntax WithLInteger(SyntaxToken lInteger)
		{
			return this.Update(LInteger);
		}
	
	    public IntegerLiteralSyntax Update(SyntaxToken lInteger)
	    {
	        if (this.LInteger != lInteger)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.IntegerLiteral(lInteger);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIntegerLiteral(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitIntegerLiteral(this);
	    }
	}
	
	public sealed class DecimalLiteralSyntax : MetaModelSyntaxNode
	{
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LDecimal 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.DecimalLiteralGreen)this.Green;
				var greenToken = green.LDecimal;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public DecimalLiteralSyntax WithLDecimal(SyntaxToken lDecimal)
		{
			return this.Update(LDecimal);
		}
	
	    public DecimalLiteralSyntax Update(SyntaxToken lDecimal)
	    {
	        if (this.LDecimal != lDecimal)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.DecimalLiteral(lDecimal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DecimalLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDecimalLiteral(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitDecimalLiteral(this);
	    }
	}
	
	public sealed class ScientificLiteralSyntax : MetaModelSyntaxNode
	{
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LScientific 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ScientificLiteralGreen)this.Green;
				var greenToken = green.LScientific;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public ScientificLiteralSyntax WithLScientific(SyntaxToken lScientific)
		{
			return this.Update(LScientific);
		}
	
	    public ScientificLiteralSyntax Update(SyntaxToken lScientific)
	    {
	        if (this.LScientific != lScientific)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.ScientificLiteral(lScientific);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ScientificLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitScientificLiteral(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitScientificLiteral(this);
	    }
	}
	
	public sealed class StringLiteralSyntax : MetaModelSyntaxNode
	{
	
	    public StringLiteralSyntax(InternalSyntaxNode green, SyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringLiteralSyntax(InternalSyntaxNode green, SyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken StringLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.StringLiteralGreen)this.Green;
				var greenToken = green.StringLiteral;
				return greenToken == null ? null : new MetaModelSyntaxToken(greenToken, this, this.GetChildPosition(0), this.GetChildIndex(0)); 
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				default: return null;
	        }
	    }
	
	    public StringLiteralSyntax WithStringLiteral(SyntaxToken stringLiteral)
		{
			return this.Update(StringLiteral);
		}
	
	    public StringLiteralSyntax Update(SyntaxToken stringLiteral)
	    {
	        if (this.StringLiteral != stringLiteral)
	        {
	            SyntaxNode newNode = MetaModelLanguage.Instance.SyntaxFactory.StringLiteral(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TResult>(IMetaModelSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStringLiteral(this);
	    }
	
	    public override void Accept(IMetaModelSyntaxVisitor visitor)
	    {
	        visitor.VisitStringLiteral(this);
	    }
	}
}

namespace MetaDslx.Languages.Meta
{
    using System.Threading;
    using MetaDslx.Compiler;
    using MetaDslx.Compiler.Text;
	using MetaDslx.Languages.Meta.Syntax;
    using MetaDslx.Languages.Meta.Syntax.InternalSyntax;

	public interface IMetaModelSyntaxVisitor
	{
		
		void VisitMain(MainSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitAnnotation(AnnotationSyntax node);
		
		void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		void VisitNamespaceBody(NamespaceBodySyntax node);
		
		void VisitMetamodelDeclaration(MetamodelDeclarationSyntax node);
		
		void VisitMetamodelPropertyList(MetamodelPropertyListSyntax node);
		
		void VisitMetamodelProperty(MetamodelPropertySyntax node);
		
		void VisitMetamodelUriProperty(MetamodelUriPropertySyntax node);
		
		void VisitDeclaration(DeclarationSyntax node);
		
		void VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		void VisitEnumBody(EnumBodySyntax node);
		
		void VisitEnumValues(EnumValuesSyntax node);
		
		void VisitEnumValue(EnumValueSyntax node);
		
		void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node);
		
		void VisitClassDeclaration(ClassDeclarationSyntax node);
		
		void VisitClassBody(ClassBodySyntax node);
		
		void VisitClassAncestors(ClassAncestorsSyntax node);
		
		void VisitClassAncestor(ClassAncestorSyntax node);
		
		void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node);
		
		void VisitFieldDeclaration(FieldDeclarationSyntax node);
		
		void VisitFieldModifier(FieldModifierSyntax node);
		
		void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node);
		
		void VisitRedefinitions(RedefinitionsSyntax node);
		
		void VisitSubsettings(SubsettingsSyntax node);
		
		void VisitNameUseList(NameUseListSyntax node);
		
		void VisitConstDeclaration(ConstDeclarationSyntax node);
		
		void VisitReturnType(ReturnTypeSyntax node);
		
		void VisitTypeOfReference(TypeOfReferenceSyntax node);
		
		void VisitTypeReference(TypeReferenceSyntax node);
		
		void VisitSimpleType(SimpleTypeSyntax node);
		
		void VisitClassType(ClassTypeSyntax node);
		
		void VisitObjectType(ObjectTypeSyntax node);
		
		void VisitPrimitiveType(PrimitiveTypeSyntax node);
		
		void VisitVoidType(VoidTypeSyntax node);
		
		void VisitNullableType(NullableTypeSyntax node);
		
		void VisitCollectionType(CollectionTypeSyntax node);
		
		void VisitCollectionKind(CollectionKindSyntax node);
		
		void VisitOperationDeclaration(OperationDeclarationSyntax node);
		
		void VisitParameterList(ParameterListSyntax node);
		
		void VisitParameter(ParameterSyntax node);
		
		void VisitAssociationDeclaration(AssociationDeclarationSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitLiteral(LiteralSyntax node);
		
		void VisitNullLiteral(NullLiteralSyntax node);
		
		void VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		void VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		void VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		void VisitScientificLiteral(ScientificLiteralSyntax node);
		
		void VisitStringLiteral(StringLiteralSyntax node);
	}
	
	public class MetaModelSyntaxVisitor : SyntaxVisitor, IMetaModelSyntaxVisitor
	{
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAnnotation(AnnotationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMetamodelProperty(MetamodelPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnumValues(EnumValuesSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnumValue(EnumValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassDeclaration(ClassDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassBody(ClassBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassAncestors(ClassAncestorsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassAncestor(ClassAncestorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFieldModifier(FieldModifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRedefinitions(RedefinitionsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSubsettings(SubsettingsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNameUseList(NameUseListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitConstDeclaration(ConstDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassType(ClassTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCollectionType(CollectionTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCollectionKind(CollectionKindSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParameterList(ParameterListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParameter(ParameterSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	public class MetaModelDetailedSyntaxVisitor : DetailedSyntaxVisitor, IMetaModelSyntaxVisitor
	{
	    public MetaModelDetailedSyntaxVisitor(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.Visit(node.NamespaceDeclaration);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.Visit(node.Identifier);
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.Visit(node.Qualifier);
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
			this.VisitList(node.Identifier);
		}
		
		public virtual void VisitAnnotation(AnnotationSyntax node)
		{
			this.VisitToken(node.TOpenBracket);
			this.Visit(node.Name);
			this.VisitToken(node.TCloseBracket);
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.VisitList(node.Annotation);
			this.VisitToken(node.KNamespace);
			this.Visit(node.QualifiedName);
			this.Visit(node.NamespaceBody);
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.MetamodelDeclaration);
			this.VisitList(node.Declaration);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
			this.VisitList(node.Annotation);
			this.VisitToken(node.KMetamodel);
			this.Visit(node.Name);
			this.VisitToken(node.TOpenParen);
			this.Visit(node.MetamodelPropertyList);
			this.VisitToken(node.TCloseParen);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
			this.VisitList(node.MetamodelProperty);
		}
		
		public virtual void VisitMetamodelProperty(MetamodelPropertySyntax node)
		{
			this.Visit(node.MetamodelUriProperty);
		}
		
		public virtual void VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
			this.VisitToken(node.IUri);
			this.VisitToken(node.TAssign);
			this.Visit(node.StringLiteral);
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.Visit(node.EnumDeclaration);
			this.Visit(node.ClassDeclaration);
			this.Visit(node.AssociationDeclaration);
			this.Visit(node.ConstDeclaration);
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.VisitList(node.Annotation);
			this.VisitToken(node.KEnum);
			this.Visit(node.Name);
			this.Visit(node.EnumBody);
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.Visit(node.EnumValues);
			this.VisitToken(node.TSemicolon);
			this.VisitList(node.EnumMemberDeclaration);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitEnumValues(EnumValuesSyntax node)
		{
			this.VisitList(node.EnumValue);
		}
		
		public virtual void VisitEnumValue(EnumValueSyntax node)
		{
			this.VisitList(node.Annotation);
			this.Visit(node.Name);
		}
		
		public virtual void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			this.Visit(node.OperationDeclaration);
		}
		
		public virtual void VisitClassDeclaration(ClassDeclarationSyntax node)
		{
			this.VisitList(node.Annotation);
			this.VisitToken(node.KAbstract);
			this.VisitToken(node.KClass);
			this.Visit(node.Name);
			this.VisitToken(node.TColon);
			this.Visit(node.ClassAncestors);
			this.Visit(node.ClassBody);
		}
		
		public virtual void VisitClassBody(ClassBodySyntax node)
		{
			this.VisitToken(node.TOpenBrace);
			this.VisitList(node.ClassMemberDeclaration);
			this.VisitToken(node.TCloseBrace);
		}
		
		public virtual void VisitClassAncestors(ClassAncestorsSyntax node)
		{
			this.VisitList(node.ClassAncestor);
		}
		
		public virtual void VisitClassAncestor(ClassAncestorSyntax node)
		{
			this.Visit(node.Qualifier);
		}
		
		public virtual void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			this.Visit(node.FieldDeclaration);
			this.Visit(node.OperationDeclaration);
		}
		
		public virtual void VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
			this.VisitList(node.Annotation);
			this.Visit(node.FieldModifier);
			this.Visit(node.TypeReference);
			this.Visit(node.Name);
			this.Visit(node.RedefinitionsOrSubsettings);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitFieldModifier(FieldModifierSyntax node)
		{
			this.VisitToken(node.FieldModifier);
		}
		
		public virtual void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
			this.Visit(node.Redefinitions);
			this.Visit(node.Subsettings);
		}
		
		public virtual void VisitRedefinitions(RedefinitionsSyntax node)
		{
			this.VisitToken(node.KRedefines);
			this.Visit(node.NameUseList);
		}
		
		public virtual void VisitSubsettings(SubsettingsSyntax node)
		{
			this.VisitToken(node.KSubsets);
			this.Visit(node.NameUseList);
		}
		
		public virtual void VisitNameUseList(NameUseListSyntax node)
		{
			this.VisitList(node.Qualifier);
		}
		
		public virtual void VisitConstDeclaration(ConstDeclarationSyntax node)
		{
			this.VisitToken(node.KConst);
			this.Visit(node.TypeReference);
			this.Visit(node.Name);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
			this.Visit(node.TypeReference);
			this.Visit(node.VoidType);
		}
		
		public virtual void VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
			this.Visit(node.TypeReference);
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
			this.Visit(node.CollectionType);
			this.Visit(node.SimpleType);
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
			this.Visit(node.PrimitiveType);
			this.Visit(node.ObjectType);
			this.Visit(node.NullableType);
			this.Visit(node.Qualifier);
		}
		
		public virtual void VisitClassType(ClassTypeSyntax node)
		{
			this.Visit(node.Qualifier);
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
			this.VisitToken(node.ObjectType);
		}
		
		public virtual void VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
			this.VisitToken(node.PrimitiveType);
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
			this.VisitToken(node.KVoid);
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
			this.Visit(node.PrimitiveType);
			this.VisitToken(node.TQuestion);
		}
		
		public virtual void VisitCollectionType(CollectionTypeSyntax node)
		{
			this.Visit(node.CollectionKind);
			this.VisitToken(node.TLessThan);
			this.Visit(node.SimpleType);
			this.VisitToken(node.TGreaterThan);
		}
		
		public virtual void VisitCollectionKind(CollectionKindSyntax node)
		{
			this.VisitToken(node.CollectionKind);
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.VisitList(node.Annotation);
			this.VisitToken(node.KStatic);
			this.Visit(node.ReturnType);
			this.Visit(node.Name);
			this.VisitToken(node.TOpenParen);
			this.Visit(node.ParameterList);
			this.VisitToken(node.TCloseParen);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitParameterList(ParameterListSyntax node)
		{
			this.VisitList(node.Parameter);
		}
		
		public virtual void VisitParameter(ParameterSyntax node)
		{
			this.VisitList(node.Annotation);
			this.Visit(node.TypeReference);
			this.Visit(node.Name);
		}
		
		public virtual void VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
			this.VisitList(node.Annotation);
			this.VisitToken(node.KAssociation);
			this.Visit(node.Source);
			this.VisitToken(node.KWith);
			this.Visit(node.Target);
			this.VisitToken(node.TSemicolon);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			this.VisitToken(node.Identifier);
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
			this.Visit(node.NullLiteral);
			this.Visit(node.BooleanLiteral);
			this.Visit(node.IntegerLiteral);
			this.Visit(node.DecimalLiteral);
			this.Visit(node.ScientificLiteral);
			this.Visit(node.StringLiteral);
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
			this.VisitToken(node.KNull);
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			this.VisitToken(node.BooleanLiteral);
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			this.VisitToken(node.LInteger);
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			this.VisitToken(node.LDecimal);
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			this.VisitToken(node.LScientific);
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
			this.VisitToken(node.StringLiteral);
		}
	}

	public interface IMetaModelSyntaxVisitor<TResult> 
	{
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitAnnotation(AnnotationSyntax node);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node);
		
		TResult VisitMetamodelDeclaration(MetamodelDeclarationSyntax node);
		
		TResult VisitMetamodelPropertyList(MetamodelPropertyListSyntax node);
		
		TResult VisitMetamodelProperty(MetamodelPropertySyntax node);
		
		TResult VisitMetamodelUriProperty(MetamodelUriPropertySyntax node);
		
		TResult VisitDeclaration(DeclarationSyntax node);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		TResult VisitEnumBody(EnumBodySyntax node);
		
		TResult VisitEnumValues(EnumValuesSyntax node);
		
		TResult VisitEnumValue(EnumValueSyntax node);
		
		TResult VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node);
		
		TResult VisitClassDeclaration(ClassDeclarationSyntax node);
		
		TResult VisitClassBody(ClassBodySyntax node);
		
		TResult VisitClassAncestors(ClassAncestorsSyntax node);
		
		TResult VisitClassAncestor(ClassAncestorSyntax node);
		
		TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node);
		
		TResult VisitFieldDeclaration(FieldDeclarationSyntax node);
		
		TResult VisitFieldModifier(FieldModifierSyntax node);
		
		TResult VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node);
		
		TResult VisitRedefinitions(RedefinitionsSyntax node);
		
		TResult VisitSubsettings(SubsettingsSyntax node);
		
		TResult VisitNameUseList(NameUseListSyntax node);
		
		TResult VisitConstDeclaration(ConstDeclarationSyntax node);
		
		TResult VisitReturnType(ReturnTypeSyntax node);
		
		TResult VisitTypeOfReference(TypeOfReferenceSyntax node);
		
		TResult VisitTypeReference(TypeReferenceSyntax node);
		
		TResult VisitSimpleType(SimpleTypeSyntax node);
		
		TResult VisitClassType(ClassTypeSyntax node);
		
		TResult VisitObjectType(ObjectTypeSyntax node);
		
		TResult VisitPrimitiveType(PrimitiveTypeSyntax node);
		
		TResult VisitVoidType(VoidTypeSyntax node);
		
		TResult VisitNullableType(NullableTypeSyntax node);
		
		TResult VisitCollectionType(CollectionTypeSyntax node);
		
		TResult VisitCollectionKind(CollectionKindSyntax node);
		
		TResult VisitOperationDeclaration(OperationDeclarationSyntax node);
		
		TResult VisitParameterList(ParameterListSyntax node);
		
		TResult VisitParameter(ParameterSyntax node);
		
		TResult VisitAssociationDeclaration(AssociationDeclarationSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitLiteral(LiteralSyntax node);
		
		TResult VisitNullLiteral(NullLiteralSyntax node);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node);
		
		TResult VisitStringLiteral(StringLiteralSyntax node);
	}
	
	public class MetaModelSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, IMetaModelSyntaxVisitor<TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitName(NameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifiedName(QualifiedNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifier(QualifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAnnotation(AnnotationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMetamodelProperty(MetamodelPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration(DeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnumBody(EnumBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnumValues(EnumValuesSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnumValue(EnumValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassDeclaration(ClassDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassBody(ClassBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassAncestors(ClassAncestorsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassAncestor(ClassAncestorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFieldModifier(FieldModifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRedefinitions(RedefinitionsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSubsettings(SubsettingsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNameUseList(NameUseListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitConstDeclaration(ConstDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitReturnType(ReturnTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeReference(TypeReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleType(SimpleTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassType(ClassTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitObjectType(ObjectTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVoidType(VoidTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNullableType(NullableTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCollectionType(CollectionTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCollectionKind(CollectionKindSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParameterList(ParameterListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParameter(ParameterSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLiteral(LiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNullLiteral(NullLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStringLiteral(StringLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class MetaModelSyntaxRewriter : SyntaxRewriter, IMetaModelSyntaxVisitor<SyntaxNode>
	{
	    public MetaModelSyntaxRewriter(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
			: base(visitIntoStructuredToken, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var namespaceDeclaration = (NamespaceDeclarationSyntax)this.Visit(node.NamespaceDeclaration);
			return node.Update(namespaceDeclaration);
		}
		
		public virtual SyntaxNode VisitName(NameSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitQualifiedName(QualifiedNameSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitQualifier(QualifierSyntax node)
		{
		    var identifier = this.VisitList(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitAnnotation(AnnotationSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, name, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody = (NamespaceBodySyntax)this.Visit(node.NamespaceBody);
			return node.Update(annotation, kNamespace, qualifiedName, namespaceBody);
		}
		
		public virtual SyntaxNode VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var metamodelDeclaration = (MetamodelDeclarationSyntax)this.Visit(node.MetamodelDeclaration);
		    var declaration = this.VisitList(node.Declaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, metamodelDeclaration, declaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var kMetamodel = this.VisitToken(node.KMetamodel);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var metamodelPropertyList = (MetamodelPropertyListSyntax)this.Visit(node.MetamodelPropertyList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(annotation, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
		}
		
		public virtual SyntaxNode VisitMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
		    var metamodelProperty = this.VisitList(node.MetamodelProperty);
			return node.Update(metamodelProperty);
		}
		
		public virtual SyntaxNode VisitMetamodelProperty(MetamodelPropertySyntax node)
		{
		    var metamodelUriProperty = (MetamodelUriPropertySyntax)this.Visit(node.MetamodelUriProperty);
			return node.Update(metamodelUriProperty);
		}
		
		public virtual SyntaxNode VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
		    var iUri = this.VisitToken(node.IUri);
		    var tAssign = this.VisitToken(node.TAssign);
		    var stringLiteral = (StringLiteralSyntax)this.Visit(node.StringLiteral);
			return node.Update(iUri, tAssign, stringLiteral);
		}
		
		public virtual SyntaxNode VisitDeclaration(DeclarationSyntax node)
		{
			var oldEnumDeclaration = node.EnumDeclaration;
			if (oldEnumDeclaration != null)
			{
			    var newEnumDeclaration = (EnumDeclarationSyntax)this.Visit(oldEnumDeclaration);
				return node.Update(newEnumDeclaration);
			}
			var oldClassDeclaration = node.ClassDeclaration;
			if (oldClassDeclaration != null)
			{
			    var newClassDeclaration = (ClassDeclarationSyntax)this.Visit(oldClassDeclaration);
				return node.Update(newClassDeclaration);
			}
			var oldAssociationDeclaration = node.AssociationDeclaration;
			if (oldAssociationDeclaration != null)
			{
			    var newAssociationDeclaration = (AssociationDeclarationSyntax)this.Visit(oldAssociationDeclaration);
				return node.Update(newAssociationDeclaration);
			}
			var oldConstDeclaration = node.ConstDeclaration;
			if (oldConstDeclaration != null)
			{
			    var newConstDeclaration = (ConstDeclarationSyntax)this.Visit(oldConstDeclaration);
				return node.Update(newConstDeclaration);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var kEnum = this.VisitToken(node.KEnum);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var enumBody = (EnumBodySyntax)this.Visit(node.EnumBody);
			return node.Update(annotation, kEnum, name, enumBody);
		}
		
		public virtual SyntaxNode VisitEnumBody(EnumBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var enumValues = (EnumValuesSyntax)this.Visit(node.EnumValues);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var enumMemberDeclaration = this.VisitList(node.EnumMemberDeclaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitEnumValues(EnumValuesSyntax node)
		{
		    var enumValue = this.VisitList(node.EnumValue);
			return node.Update(enumValue);
		}
		
		public virtual SyntaxNode VisitEnumValue(EnumValueSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(annotation, name);
		}
		
		public virtual SyntaxNode VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
		    var operationDeclaration = (OperationDeclarationSyntax)this.Visit(node.OperationDeclaration);
			return node.Update(operationDeclaration);
		}
		
		public virtual SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var kAbstract = this.VisitToken(node.KAbstract);
		    var kClass = this.VisitToken(node.KClass);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var classAncestors = (ClassAncestorsSyntax)this.Visit(node.ClassAncestors);
		    var classBody = (ClassBodySyntax)this.Visit(node.ClassBody);
			return node.Update(annotation, kAbstract, kClass, name, tColon, classAncestors, classBody);
		}
		
		public virtual SyntaxNode VisitClassBody(ClassBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var classMemberDeclaration = this.VisitList(node.ClassMemberDeclaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, classMemberDeclaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitClassAncestors(ClassAncestorsSyntax node)
		{
		    var classAncestor = this.VisitList(node.ClassAncestor);
			return node.Update(classAncestor);
		}
		
		public virtual SyntaxNode VisitClassAncestor(ClassAncestorSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			var oldFieldDeclaration = node.FieldDeclaration;
			if (oldFieldDeclaration != null)
			{
			    var newFieldDeclaration = (FieldDeclarationSyntax)this.Visit(oldFieldDeclaration);
				return node.Update(newFieldDeclaration);
			}
			var oldOperationDeclaration = node.OperationDeclaration;
			if (oldOperationDeclaration != null)
			{
			    var newOperationDeclaration = (OperationDeclarationSyntax)this.Visit(oldOperationDeclaration);
				return node.Update(newOperationDeclaration);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var fieldModifier = (FieldModifierSyntax)this.Visit(node.FieldModifier);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var redefinitionsOrSubsettings = (RedefinitionsOrSubsettingsSyntax)this.Visit(node.RedefinitionsOrSubsettings);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(annotation, fieldModifier, typeReference, name, redefinitionsOrSubsettings, tSemicolon);
		}
		
		public virtual SyntaxNode VisitFieldModifier(FieldModifierSyntax node)
		{
		    var fieldModifier = this.VisitToken(node.FieldModifier);
			return node.Update(fieldModifier);
		}
		
		public virtual SyntaxNode VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
			var oldRedefinitions = node.Redefinitions;
			if (oldRedefinitions != null)
			{
			    var newRedefinitions = (RedefinitionsSyntax)this.Visit(oldRedefinitions);
				return node.Update(newRedefinitions);
			}
			var oldSubsettings = node.Subsettings;
			if (oldSubsettings != null)
			{
			    var newSubsettings = (SubsettingsSyntax)this.Visit(oldSubsettings);
				return node.Update(newSubsettings);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitRedefinitions(RedefinitionsSyntax node)
		{
		    var kRedefines = this.VisitToken(node.KRedefines);
		    var nameUseList = (NameUseListSyntax)this.Visit(node.NameUseList);
			return node.Update(kRedefines, nameUseList);
		}
		
		public virtual SyntaxNode VisitSubsettings(SubsettingsSyntax node)
		{
		    var kSubsets = this.VisitToken(node.KSubsets);
		    var nameUseList = (NameUseListSyntax)this.Visit(node.NameUseList);
			return node.Update(kSubsets, nameUseList);
		}
		
		public virtual SyntaxNode VisitNameUseList(NameUseListSyntax node)
		{
		    var qualifier = this.VisitList(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitConstDeclaration(ConstDeclarationSyntax node)
		{
		    var kConst = this.VisitToken(node.KConst);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kConst, typeReference, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitReturnType(ReturnTypeSyntax node)
		{
			var oldTypeReference = node.TypeReference;
			if (oldTypeReference != null)
			{
			    var newTypeReference = (TypeReferenceSyntax)this.Visit(oldTypeReference);
				return node.Update(newTypeReference);
			}
			var oldVoidType = node.VoidType;
			if (oldVoidType != null)
			{
			    var newVoidType = (VoidTypeSyntax)this.Visit(oldVoidType);
				return node.Update(newVoidType);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
			return node.Update(typeReference);
		}
		
		public virtual SyntaxNode VisitTypeReference(TypeReferenceSyntax node)
		{
			var oldCollectionType = node.CollectionType;
			if (oldCollectionType != null)
			{
			    var newCollectionType = (CollectionTypeSyntax)this.Visit(oldCollectionType);
				return node.Update(newCollectionType);
			}
			var oldSimpleType = node.SimpleType;
			if (oldSimpleType != null)
			{
			    var newSimpleType = (SimpleTypeSyntax)this.Visit(oldSimpleType);
				return node.Update(newSimpleType);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSimpleType(SimpleTypeSyntax node)
		{
			var oldPrimitiveType = node.PrimitiveType;
			if (oldPrimitiveType != null)
			{
			    var newPrimitiveType = (PrimitiveTypeSyntax)this.Visit(oldPrimitiveType);
				return node.Update(newPrimitiveType);
			}
			var oldObjectType = node.ObjectType;
			if (oldObjectType != null)
			{
			    var newObjectType = (ObjectTypeSyntax)this.Visit(oldObjectType);
				return node.Update(newObjectType);
			}
			var oldNullableType = node.NullableType;
			if (oldNullableType != null)
			{
			    var newNullableType = (NullableTypeSyntax)this.Visit(oldNullableType);
				return node.Update(newNullableType);
			}
			var oldQualifier = node.Qualifier;
			if (oldQualifier != null)
			{
			    var newQualifier = (QualifierSyntax)this.Visit(oldQualifier);
				return node.Update(newQualifier);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitClassType(ClassTypeSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitObjectType(ObjectTypeSyntax node)
		{
		    var objectType = this.VisitToken(node.ObjectType);
			return node.Update(objectType);
		}
		
		public virtual SyntaxNode VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
		    var primitiveType = this.VisitToken(node.PrimitiveType);
			return node.Update(primitiveType);
		}
		
		public virtual SyntaxNode VisitVoidType(VoidTypeSyntax node)
		{
		    var kVoid = this.VisitToken(node.KVoid);
			return node.Update(kVoid);
		}
		
		public virtual SyntaxNode VisitNullableType(NullableTypeSyntax node)
		{
		    var primitiveType = (PrimitiveTypeSyntax)this.Visit(node.PrimitiveType);
		    var tQuestion = this.VisitToken(node.TQuestion);
			return node.Update(primitiveType, tQuestion);
		}
		
		public virtual SyntaxNode VisitCollectionType(CollectionTypeSyntax node)
		{
		    var collectionKind = (CollectionKindSyntax)this.Visit(node.CollectionKind);
		    var tLessThan = this.VisitToken(node.TLessThan);
		    var simpleType = (SimpleTypeSyntax)this.Visit(node.SimpleType);
		    var tGreaterThan = this.VisitToken(node.TGreaterThan);
			return node.Update(collectionKind, tLessThan, simpleType, tGreaterThan);
		}
		
		public virtual SyntaxNode VisitCollectionKind(CollectionKindSyntax node)
		{
		    var collectionKind = this.VisitToken(node.CollectionKind);
			return node.Update(collectionKind);
		}
		
		public virtual SyntaxNode VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var kStatic = this.VisitToken(node.KStatic);
		    var returnType = (ReturnTypeSyntax)this.Visit(node.ReturnType);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var parameterList = (ParameterListSyntax)this.Visit(node.ParameterList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(annotation, kStatic, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
		}
		
		public virtual SyntaxNode VisitParameterList(ParameterListSyntax node)
		{
		    var parameter = this.VisitList(node.Parameter);
			return node.Update(parameter);
		}
		
		public virtual SyntaxNode VisitParameter(ParameterSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(annotation, typeReference, name);
		}
		
		public virtual SyntaxNode VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var kAssociation = this.VisitToken(node.KAssociation);
		    var source = (QualifierSyntax)this.Visit(node.Source);
		    var kWith = this.VisitToken(node.KWith);
		    var target = (QualifierSyntax)this.Visit(node.Target);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(annotation, kAssociation, source, kWith, target, tSemicolon);
		}
		
		public virtual SyntaxNode VisitIdentifier(IdentifierSyntax node)
		{
		    var identifier = this.VisitToken(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitLiteral(LiteralSyntax node)
		{
			var oldNullLiteral = node.NullLiteral;
			if (oldNullLiteral != null)
			{
			    var newNullLiteral = (NullLiteralSyntax)this.Visit(oldNullLiteral);
				return node.Update(newNullLiteral);
			}
			var oldBooleanLiteral = node.BooleanLiteral;
			if (oldBooleanLiteral != null)
			{
			    var newBooleanLiteral = (BooleanLiteralSyntax)this.Visit(oldBooleanLiteral);
				return node.Update(newBooleanLiteral);
			}
			var oldIntegerLiteral = node.IntegerLiteral;
			if (oldIntegerLiteral != null)
			{
			    var newIntegerLiteral = (IntegerLiteralSyntax)this.Visit(oldIntegerLiteral);
				return node.Update(newIntegerLiteral);
			}
			var oldDecimalLiteral = node.DecimalLiteral;
			if (oldDecimalLiteral != null)
			{
			    var newDecimalLiteral = (DecimalLiteralSyntax)this.Visit(oldDecimalLiteral);
				return node.Update(newDecimalLiteral);
			}
			var oldScientificLiteral = node.ScientificLiteral;
			if (oldScientificLiteral != null)
			{
			    var newScientificLiteral = (ScientificLiteralSyntax)this.Visit(oldScientificLiteral);
				return node.Update(newScientificLiteral);
			}
			var oldStringLiteral = node.StringLiteral;
			if (oldStringLiteral != null)
			{
			    var newStringLiteral = (StringLiteralSyntax)this.Visit(oldStringLiteral);
				return node.Update(newStringLiteral);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitNullLiteral(NullLiteralSyntax node)
		{
		    var kNull = this.VisitToken(node.KNull);
			return node.Update(kNull);
		}
		
		public virtual SyntaxNode VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		    var booleanLiteral = this.VisitToken(node.BooleanLiteral);
			return node.Update(booleanLiteral);
		}
		
		public virtual SyntaxNode VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		    var lInteger = this.VisitToken(node.LInteger);
			return node.Update(lInteger);
		}
		
		public virtual SyntaxNode VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		    var lDecimal = this.VisitToken(node.LDecimal);
			return node.Update(lDecimal);
		}
		
		public virtual SyntaxNode VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		    var lScientific = this.VisitToken(node.LScientific);
			return node.Update(lScientific);
		}
		
		public virtual SyntaxNode VisitStringLiteral(StringLiteralSyntax node)
		{
		    var stringLiteral = this.VisitToken(node.StringLiteral);
			return node.Update(stringLiteral);
		}
	}

	public class MetaModelSyntaxFactory : SyntaxFactory
	{
	    internal static readonly MetaModelSyntaxFactory Instance = new MetaModelSyntaxFactory();
	
		public MetaModelSyntaxFactory() 
		{
			this.CarriageReturnLineFeed = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.CarriageReturnLineFeed.CreateRed();
			this.LineFeed = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.LineFeed.CreateRed();
			this.CarriageReturn = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.CarriageReturn.CreateRed();
			this.Space = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.Space.CreateRed();
			this.Tab = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.Tab.CreateRed();
			this.ElasticCarriageReturnLineFeed = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.ElasticCarriageReturnLineFeed.CreateRed();
			this.ElasticLineFeed = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.ElasticLineFeed.CreateRed();
			this.ElasticCarriageReturn = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.ElasticCarriageReturn.CreateRed();
			this.ElasticSpace = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.ElasticSpace.CreateRed();
			this.ElasticTab = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.ElasticTab.CreateRed();
			this.ElasticZeroSpace = (MetaModelSyntaxTrivia)MetaModelGreenFactory.Instance.ElasticZeroSpace.CreateRed();
		}
	
		public new MetaModelLanguage Language
		{
			get { return MetaModelLanguage.Instance; }
		}
	
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
	
	    public MetaModelSyntaxTrivia CarriageReturnLineFeed { get; }
	    public MetaModelSyntaxTrivia LineFeed { get; }
	    public MetaModelSyntaxTrivia CarriageReturn { get; }
	    public MetaModelSyntaxTrivia Space { get; }
	    public MetaModelSyntaxTrivia Tab { get; }
	    public MetaModelSyntaxTrivia ElasticCarriageReturnLineFeed { get; }
	    public MetaModelSyntaxTrivia ElasticLineFeed { get; }
	    public MetaModelSyntaxTrivia ElasticCarriageReturn { get; }
	    public MetaModelSyntaxTrivia ElasticSpace { get; }
	    public MetaModelSyntaxTrivia ElasticTab { get; }
	    public MetaModelSyntaxTrivia ElasticZeroSpace { get; }
	
		private SyntaxToken defaultToken = null;
	    protected override SyntaxToken DefaultToken
	    {
	        get 
			{
				if (defaultToken != null) return defaultToken;
			    Interlocked.CompareExchange(ref defaultToken, this.Token(MetaModelSyntaxKind.None), null);
				return defaultToken;
			}
	    }
	
		private SyntaxTrivia defaultTrivia = null;
	    protected override SyntaxTrivia DefaultTrivia
	    {
	        get 
			{
				if (defaultTrivia != null) return defaultTrivia;
			    Interlocked.CompareExchange(ref defaultTrivia, this.Trivia(MetaModelSyntaxKind.None, string.Empty), null);
				return defaultTrivia;
			}
	    }
	
		private SyntaxToken defaultSeparator = null;
	    protected override SyntaxToken DefaultSeparator
	    {
	        get 
			{
				if (defaultSeparator != null) return defaultSeparator;
			    Interlocked.CompareExchange(ref defaultSeparator, this.Token(MetaModelSyntaxKind.TComma), null);
				return defaultSeparator;
			}
	    }
	
	    protected override SyntaxNode StructuredToken(SyntaxToken token)
	    {
	        throw new NotImplementedException();
	    }
	
	    protected override SyntaxNode StructuredTrivia(SyntaxTrivia trivia)
	    {
	        throw new NotImplementedException();
	    }
	
	    protected override SyntaxToken Token(SyntaxNode tokenStructure)
	    {
	        throw new NotImplementedException();
	    }
	
	    protected override SyntaxTrivia Trivia(SyntaxNode triviaStructure)
	    {
	        throw new NotImplementedException();
	    }
	
		/// <summary>
		/// Creates a token corresponding to a syntax kind. This method can be used for token syntax kinds whose text
		/// can be inferred by the kind alone.
		/// </summary>
		/// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
		/// <returns></returns>
		public SyntaxToken Token(MetaModelSyntaxKind kind)
		{
			return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.Token(kind).CreateRed();
		}
	
		public SyntaxTrivia Trivia(MetaModelSyntaxKind kind, string text)
		{
			return (SyntaxTrivia)MetaModelLanguage.Instance.InternalSyntaxFactory.Trivia(kind, text).CreateRed();
		}
	
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public MetaModelSyntaxTree SyntaxTree(SyntaxNode root, MetaModelParseOptions options = null, string path = "", Encoding encoding = null)
		{
		    return MetaModelSyntaxTree.Create((MetaModelSyntaxNode)root, (MetaModelParseOptions)options, path, encoding);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public MetaModelSyntaxTree ParseSyntaxTree(
		    string text,
		    MetaModelParseOptions options = null,
		    string path = "",
		    Encoding encoding = null,
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (MetaModelSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
	
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public MetaModelSyntaxTree ParseSyntaxTree(
		    SourceText text,
		    MetaModelParseOptions options = null,
		    string path = "",
		    CancellationToken cancellationToken = default(CancellationToken))
		{
		    return (MetaModelSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
	
		protected override SyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return MetaModelSyntaxTree.ParseText(text, (MetaModelParseOptions)options, path, cancellationToken);
		}
	
	    public MainSyntax ParseMain(string text)
	    {
	        // note that we do not need a "consumeFullText" parameter, because parsing a compilation unit always must
	        // consume input until the end-of-file
	        using (var parser = MakeParser(text))
	        {
	            var node = parser.Parse();
	            if (node == null) return null;
	            // if (consumeFullText) node = parser.ConsumeUnexpectedTokens(node);
	            return (MainSyntax)node.CreateRed();
	        }
	    }
	
		public override SyntaxParser MakeParser(SourceText text, ParseOptions options, SyntaxNode oldTree, IReadOnlyList<TextChangeRange> changes)
		{
		    return new MetaModelSyntaxParser(text, (MetaModelParseOptions)options, oldTree, changes);
		}
	
		public override SyntaxParser MakeParser(string text)
		{
		    return new MetaModelSyntaxParser(SourceText.From(text, Encoding.UTF8), MetaModelParseOptions.Default, null, null);
		}
	
	    public SyntaxToken TAsterisk(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.TAsterisk(text).CreateRed();
	    }
	
	    public SyntaxToken TAsterisk(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.TAsterisk(text, value).CreateRed();
	    }
	
	    public SyntaxToken IdentifierNormal(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text).CreateRed();
	    }
	
	    public SyntaxToken IdentifierNormal(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text, value).CreateRed();
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text).CreateRed();
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text, value).CreateRed();
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LInteger(text).CreateRed();
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LInteger(text, value).CreateRed();
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LDecimal(text).CreateRed();
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LDecimal(text, value).CreateRed();
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LScientific(text).CreateRed();
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LScientific(text, value).CreateRed();
	    }
	
	    public SyntaxToken LDateTimeOffset(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text).CreateRed();
	    }
	
	    public SyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text, value).CreateRed();
	    }
	
	    public SyntaxToken LDateTime(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LDateTime(text).CreateRed();
	    }
	
	    public SyntaxToken LDateTime(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LDateTime(text, value).CreateRed();
	    }
	
	    public SyntaxToken LDate(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LDate(text).CreateRed();
	    }
	
	    public SyntaxToken LDate(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LDate(text, value).CreateRed();
	    }
	
	    public SyntaxToken LTime(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LTime(text).CreateRed();
	    }
	
	    public SyntaxToken LTime(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LTime(text, value).CreateRed();
	    }
	
	    public SyntaxToken LRegularString(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LRegularString(text).CreateRed();
	    }
	
	    public SyntaxToken LRegularString(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LRegularString(text, value).CreateRed();
	    }
	
	    public SyntaxToken LGuid(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LGuid(text).CreateRed();
	    }
	
	    public SyntaxToken LGuid(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LGuid(text, value).CreateRed();
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text).CreateRed();
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value).CreateRed();
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text).CreateRed();
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value).CreateRed();
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LCrLf(text).CreateRed();
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value).CreateRed();
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LLineEnd(text).CreateRed();
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value).CreateRed();
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text).CreateRed();
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value).CreateRed();
	    }
	
	    public SyntaxToken LComment(string text)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LComment(text).CreateRed();
	    }
	
	    public SyntaxToken LComment(string text, object value)
	    {
	        return (SyntaxToken)MetaModelLanguage.Instance.InternalSyntaxFactory.LComment(text, value).CreateRed();
	    }
		
		public MainSyntax Main(NamespaceDeclarationSyntax namespaceDeclaration)
		{
		    if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
		    return (MainSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Main((Syntax.InternalSyntax.NamespaceDeclarationGreen)namespaceDeclaration.Green).CreateRed();
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public QualifiedNameSyntax QualifiedName(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifiedNameSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.QualifiedName((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public QualifierSyntax Qualifier(SeparatedSyntaxNodeList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Qualifier(identifier.Green).CreateRed();
		}
		
		public AnnotationSyntax Annotation(SyntaxToken tOpenBracket, NameSyntax name, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.RawKind != (int)MetaModelSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.RawKind != (int)MetaModelSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (AnnotationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Annotation((InternalSyntaxToken)tOpenBracket.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tCloseBracket.Green).CreateRed();
		}
		
		public AnnotationSyntax Annotation(NameSyntax name)
		{
			return this.Annotation(this.Token(MetaModelSyntaxKind.TOpenBracket), name, this.Token(MetaModelSyntaxKind.TCloseBracket));
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.RawKind != (int)MetaModelSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
		    return (NamespaceDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(annotation == null ? null : annotation.Green, (InternalSyntaxToken)kNamespace.Green, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBodyGreen)namespaceBody.Green).CreateRed();
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
		{
			return this.NamespaceDeclaration(null, this.Token(MetaModelSyntaxKind.KNamespace), qualifiedName, namespaceBody);
		}
		
		public NamespaceBodySyntax NamespaceBody(SyntaxToken tOpenBrace, MetamodelDeclarationSyntax metamodelDeclaration, SyntaxNodeList<DeclarationSyntax> declaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.RawKind != (int)MetaModelSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (metamodelDeclaration == null) throw new ArgumentNullException(nameof(metamodelDeclaration));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.RawKind != (int)MetaModelSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBodySyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.NamespaceBody((InternalSyntaxToken)tOpenBrace.Green, (Syntax.InternalSyntax.MetamodelDeclarationGreen)metamodelDeclaration.Green, declaration == null ? null : declaration.Green, (InternalSyntaxToken)tCloseBrace.Green).CreateRed();
		}
		
		public NamespaceBodySyntax NamespaceBody(MetamodelDeclarationSyntax metamodelDeclaration)
		{
			return this.NamespaceBody(this.Token(MetaModelSyntaxKind.TOpenBrace), metamodelDeclaration, null, this.Token(MetaModelSyntaxKind.TCloseBrace));
		}
		
		public MetamodelDeclarationSyntax MetamodelDeclaration(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kMetamodel, NameSyntax name, SyntaxToken tOpenParen, MetamodelPropertyListSyntax metamodelPropertyList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
		{
		    if (kMetamodel == null) throw new ArgumentNullException(nameof(kMetamodel));
		    if (kMetamodel.RawKind != (int)MetaModelSyntaxKind.KMetamodel) throw new ArgumentException(nameof(kMetamodel));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.RawKind != (int)MetaModelSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.RawKind != (int)MetaModelSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.RawKind != (int)MetaModelSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (MetamodelDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.MetamodelDeclaration(annotation == null ? null : annotation.Green, (InternalSyntaxToken)kMetamodel.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Green, metamodelPropertyList == null ? null : (Syntax.InternalSyntax.MetamodelPropertyListGreen)metamodelPropertyList.Green, (InternalSyntaxToken)tCloseParen.Green, (InternalSyntaxToken)tSemicolon.Green).CreateRed();
		}
		
		public MetamodelDeclarationSyntax MetamodelDeclaration(NameSyntax name)
		{
			return this.MetamodelDeclaration(null, this.Token(MetaModelSyntaxKind.KMetamodel), name, this.Token(MetaModelSyntaxKind.TOpenParen), null, this.Token(MetaModelSyntaxKind.TCloseParen), this.Token(MetaModelSyntaxKind.TSemicolon));
		}
		
		public MetamodelPropertyListSyntax MetamodelPropertyList(SeparatedSyntaxNodeList<MetamodelPropertySyntax> metamodelProperty)
		{
		    if (metamodelProperty == null) throw new ArgumentNullException(nameof(metamodelProperty));
		    return (MetamodelPropertyListSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.MetamodelPropertyList(metamodelProperty.Green).CreateRed();
		}
		
		public MetamodelPropertySyntax MetamodelProperty(MetamodelUriPropertySyntax metamodelUriProperty)
		{
		    if (metamodelUriProperty == null) throw new ArgumentNullException(nameof(metamodelUriProperty));
		    return (MetamodelPropertySyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.MetamodelProperty((Syntax.InternalSyntax.MetamodelUriPropertyGreen)metamodelUriProperty.Green).CreateRed();
		}
		
		public MetamodelUriPropertySyntax MetamodelUriProperty(SyntaxToken iUri, SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
		{
		    if (iUri == null) throw new ArgumentNullException(nameof(iUri));
		    if (iUri.RawKind != (int)MetaModelSyntaxKind.IUri) throw new ArgumentException(nameof(iUri));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.RawKind != (int)MetaModelSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (MetamodelUriPropertySyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.MetamodelUriProperty((InternalSyntaxToken)iUri.Green, (InternalSyntaxToken)tAssign.Green, (Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public MetamodelUriPropertySyntax MetamodelUriProperty(StringLiteralSyntax stringLiteral)
		{
			return this.MetamodelUriProperty(this.Token(MetaModelSyntaxKind.IUri), this.Token(MetaModelSyntaxKind.TAssign), stringLiteral);
		}
		
		public DeclarationSyntax Declaration(EnumDeclarationSyntax enumDeclaration)
		{
		    if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
		    return (DeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.EnumDeclarationGreen)enumDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(ClassDeclarationSyntax classDeclaration)
		{
		    if (classDeclaration == null) throw new ArgumentNullException(nameof(classDeclaration));
		    return (DeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.ClassDeclarationGreen)classDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(AssociationDeclarationSyntax associationDeclaration)
		{
		    if (associationDeclaration == null) throw new ArgumentNullException(nameof(associationDeclaration));
		    return (DeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.AssociationDeclarationGreen)associationDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(ConstDeclarationSyntax constDeclaration)
		{
		    if (constDeclaration == null) throw new ArgumentNullException(nameof(constDeclaration));
		    return (DeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.ConstDeclarationGreen)constDeclaration.Green).CreateRed();
		}
		
		public EnumDeclarationSyntax EnumDeclaration(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kEnum, NameSyntax name, EnumBodySyntax enumBody)
		{
		    if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
		    if (kEnum.RawKind != (int)MetaModelSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
		    return (EnumDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(annotation == null ? null : annotation.Green, (InternalSyntaxToken)kEnum.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.EnumBodyGreen)enumBody.Green).CreateRed();
		}
		
		public EnumDeclarationSyntax EnumDeclaration(NameSyntax name, EnumBodySyntax enumBody)
		{
			return this.EnumDeclaration(null, this.Token(MetaModelSyntaxKind.KEnum), name, enumBody);
		}
		
		public EnumBodySyntax EnumBody(SyntaxToken tOpenBrace, EnumValuesSyntax enumValues, SyntaxToken tSemicolon, SyntaxNodeList<EnumMemberDeclarationSyntax> enumMemberDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.RawKind != (int)MetaModelSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (enumValues == null) throw new ArgumentNullException(nameof(enumValues));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.RawKind != (int)MetaModelSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.RawKind != (int)MetaModelSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (EnumBodySyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.EnumBody((InternalSyntaxToken)tOpenBrace.Green, (Syntax.InternalSyntax.EnumValuesGreen)enumValues.Green, (InternalSyntaxToken)tSemicolon.Green, enumMemberDeclaration == null ? null : enumMemberDeclaration.Green, (InternalSyntaxToken)tCloseBrace.Green).CreateRed();
		}
		
		public EnumBodySyntax EnumBody(EnumValuesSyntax enumValues)
		{
			return this.EnumBody(this.Token(MetaModelSyntaxKind.TOpenBrace), enumValues, this.Token(MetaModelSyntaxKind.TSemicolon), null, this.Token(MetaModelSyntaxKind.TCloseBrace));
		}
		
		public EnumValuesSyntax EnumValues(SeparatedSyntaxNodeList<EnumValueSyntax> enumValue)
		{
		    if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));
		    return (EnumValuesSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.EnumValues(enumValue.Green).CreateRed();
		}
		
		public EnumValueSyntax EnumValue(SyntaxNodeList<AnnotationSyntax> annotation, NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (EnumValueSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.EnumValue(annotation == null ? null : annotation.Green, (Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public EnumValueSyntax EnumValue(NameSyntax name)
		{
			return this.EnumValue(null, name);
		}
		
		public EnumMemberDeclarationSyntax EnumMemberDeclaration(OperationDeclarationSyntax operationDeclaration)
		{
		    if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
		    return (EnumMemberDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.EnumMemberDeclaration((Syntax.InternalSyntax.OperationDeclarationGreen)operationDeclaration.Green).CreateRed();
		}
		
		public ClassDeclarationSyntax ClassDeclaration(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kAbstract, SyntaxToken kClass, NameSyntax name, SyntaxToken tColon, ClassAncestorsSyntax classAncestors, ClassBodySyntax classBody)
		{
		    if (kAbstract != null && kAbstract.RawKind != (int)MetaModelSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
		    if (kClass == null) throw new ArgumentNullException(nameof(kClass));
		    if (kClass.RawKind != (int)MetaModelSyntaxKind.KClass) throw new ArgumentException(nameof(kClass));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.RawKind != (int)MetaModelSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (classAncestors == null) throw new ArgumentNullException(nameof(classAncestors));
		    if (classBody == null) throw new ArgumentNullException(nameof(classBody));
		    return (ClassDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ClassDeclaration(annotation == null ? null : annotation.Green, kAbstract == null ? null : (InternalSyntaxToken)kAbstract.Green, (InternalSyntaxToken)kClass.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Green, (Syntax.InternalSyntax.ClassAncestorsGreen)classAncestors.Green, (Syntax.InternalSyntax.ClassBodyGreen)classBody.Green).CreateRed();
		}
		
		public ClassDeclarationSyntax ClassDeclaration(NameSyntax name, ClassAncestorsSyntax classAncestors, ClassBodySyntax classBody)
		{
			return this.ClassDeclaration(null, null, this.Token(MetaModelSyntaxKind.KClass), name, this.Token(MetaModelSyntaxKind.TColon), classAncestors, classBody);
		}
		
		public ClassBodySyntax ClassBody(SyntaxToken tOpenBrace, SyntaxNodeList<ClassMemberDeclarationSyntax> classMemberDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.RawKind != (int)MetaModelSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.RawKind != (int)MetaModelSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (ClassBodySyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ClassBody((InternalSyntaxToken)tOpenBrace.Green, classMemberDeclaration == null ? null : classMemberDeclaration.Green, (InternalSyntaxToken)tCloseBrace.Green).CreateRed();
		}
		
		public ClassBodySyntax ClassBody()
		{
			return this.ClassBody(this.Token(MetaModelSyntaxKind.TOpenBrace), null, this.Token(MetaModelSyntaxKind.TCloseBrace));
		}
		
		public ClassAncestorsSyntax ClassAncestors(SeparatedSyntaxNodeList<ClassAncestorSyntax> classAncestor)
		{
		    if (classAncestor == null) throw new ArgumentNullException(nameof(classAncestor));
		    return (ClassAncestorsSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ClassAncestors(classAncestor.Green).CreateRed();
		}
		
		public ClassAncestorSyntax ClassAncestor(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (ClassAncestorSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ClassAncestor((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ClassMemberDeclarationSyntax ClassMemberDeclaration(FieldDeclarationSyntax fieldDeclaration)
		{
		    if (fieldDeclaration == null) throw new ArgumentNullException(nameof(fieldDeclaration));
		    return (ClassMemberDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration((Syntax.InternalSyntax.FieldDeclarationGreen)fieldDeclaration.Green).CreateRed();
		}
		
		public ClassMemberDeclarationSyntax ClassMemberDeclaration(OperationDeclarationSyntax operationDeclaration)
		{
		    if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
		    return (ClassMemberDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration((Syntax.InternalSyntax.OperationDeclarationGreen)operationDeclaration.Green).CreateRed();
		}
		
		public FieldDeclarationSyntax FieldDeclaration(SyntaxNodeList<AnnotationSyntax> annotation, FieldModifierSyntax fieldModifier, TypeReferenceSyntax typeReference, NameSyntax name, RedefinitionsOrSubsettingsSyntax redefinitionsOrSubsettings, SyntaxToken tSemicolon)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.RawKind != (int)MetaModelSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (FieldDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.FieldDeclaration(annotation == null ? null : annotation.Green, fieldModifier == null ? null : (Syntax.InternalSyntax.FieldModifierGreen)fieldModifier.Green, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green, redefinitionsOrSubsettings == null ? null : (Syntax.InternalSyntax.RedefinitionsOrSubsettingsGreen)redefinitionsOrSubsettings.Green, (InternalSyntaxToken)tSemicolon.Green).CreateRed();
		}
		
		public FieldDeclarationSyntax FieldDeclaration(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.FieldDeclaration(null, null, typeReference, name, null, this.Token(MetaModelSyntaxKind.TSemicolon));
		}
		
		public FieldModifierSyntax FieldModifier(SyntaxToken fieldModifier)
		{
		    if (fieldModifier == null) throw new ArgumentNullException(nameof(fieldModifier));
		    return (FieldModifierSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.FieldModifier((InternalSyntaxToken)fieldModifier.Green).CreateRed();
		}
		
		public RedefinitionsOrSubsettingsSyntax RedefinitionsOrSubsettings(RedefinitionsSyntax redefinitions)
		{
		    if (redefinitions == null) throw new ArgumentNullException(nameof(redefinitions));
		    return (RedefinitionsOrSubsettingsSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.RedefinitionsOrSubsettings((Syntax.InternalSyntax.RedefinitionsGreen)redefinitions.Green).CreateRed();
		}
		
		public RedefinitionsOrSubsettingsSyntax RedefinitionsOrSubsettings(SubsettingsSyntax subsettings)
		{
		    if (subsettings == null) throw new ArgumentNullException(nameof(subsettings));
		    return (RedefinitionsOrSubsettingsSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.RedefinitionsOrSubsettings((Syntax.InternalSyntax.SubsettingsGreen)subsettings.Green).CreateRed();
		}
		
		public RedefinitionsSyntax Redefinitions(SyntaxToken kRedefines, NameUseListSyntax nameUseList)
		{
		    if (kRedefines == null) throw new ArgumentNullException(nameof(kRedefines));
		    if (kRedefines.RawKind != (int)MetaModelSyntaxKind.KRedefines) throw new ArgumentException(nameof(kRedefines));
		    return (RedefinitionsSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Redefinitions((InternalSyntaxToken)kRedefines.Green, nameUseList == null ? null : (Syntax.InternalSyntax.NameUseListGreen)nameUseList.Green).CreateRed();
		}
		
		public RedefinitionsSyntax Redefinitions()
		{
			return this.Redefinitions(this.Token(MetaModelSyntaxKind.KRedefines), null);
		}
		
		public SubsettingsSyntax Subsettings(SyntaxToken kSubsets, NameUseListSyntax nameUseList)
		{
		    if (kSubsets == null) throw new ArgumentNullException(nameof(kSubsets));
		    if (kSubsets.RawKind != (int)MetaModelSyntaxKind.KSubsets) throw new ArgumentException(nameof(kSubsets));
		    return (SubsettingsSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Subsettings((InternalSyntaxToken)kSubsets.Green, nameUseList == null ? null : (Syntax.InternalSyntax.NameUseListGreen)nameUseList.Green).CreateRed();
		}
		
		public SubsettingsSyntax Subsettings()
		{
			return this.Subsettings(this.Token(MetaModelSyntaxKind.KSubsets), null);
		}
		
		public NameUseListSyntax NameUseList(SeparatedSyntaxNodeList<QualifierSyntax> qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (NameUseListSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.NameUseList(qualifier.Green).CreateRed();
		}
		
		public ConstDeclarationSyntax ConstDeclaration(SyntaxToken kConst, TypeReferenceSyntax typeReference, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kConst == null) throw new ArgumentNullException(nameof(kConst));
		    if (kConst.RawKind != (int)MetaModelSyntaxKind.KConst) throw new ArgumentException(nameof(kConst));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.RawKind != (int)MetaModelSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ConstDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ConstDeclaration((InternalSyntaxToken)kConst.Green, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Green).CreateRed();
		}
		
		public ConstDeclarationSyntax ConstDeclaration(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.ConstDeclaration(this.Token(MetaModelSyntaxKind.KConst), typeReference, name, this.Token(MetaModelSyntaxKind.TSemicolon));
		}
		
		public ReturnTypeSyntax ReturnType(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (ReturnTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public ReturnTypeSyntax ReturnType(VoidTypeSyntax voidType)
		{
		    if (voidType == null) throw new ArgumentNullException(nameof(voidType));
		    return (ReturnTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.VoidTypeGreen)voidType.Green).CreateRed();
		}
		
		public TypeOfReferenceSyntax TypeOfReference(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (TypeOfReferenceSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.TypeOfReference((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(CollectionTypeSyntax collectionType)
		{
		    if (collectionType == null) throw new ArgumentNullException(nameof(collectionType));
		    return (TypeReferenceSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.CollectionTypeGreen)collectionType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(SimpleTypeSyntax simpleType)
		{
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    return (TypeReferenceSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(PrimitiveTypeSyntax primitiveType)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    return (SimpleTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.PrimitiveTypeGreen)primitiveType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(ObjectTypeSyntax objectType)
		{
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
		    return (SimpleTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.ObjectTypeGreen)objectType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(NullableTypeSyntax nullableType)
		{
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
		    return (SimpleTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.NullableTypeGreen)nullableType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (SimpleTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ClassTypeSyntax ClassType(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (ClassTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ClassType((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ObjectTypeSyntax ObjectType(SyntaxToken objectType)
		{
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
		    return (ObjectTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ObjectType((InternalSyntaxToken)objectType.Green).CreateRed();
		}
		
		public PrimitiveTypeSyntax PrimitiveType(SyntaxToken primitiveType)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    return (PrimitiveTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.PrimitiveType((InternalSyntaxToken)primitiveType.Green).CreateRed();
		}
		
		public VoidTypeSyntax VoidType(SyntaxToken kVoid)
		{
		    if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
		    if (kVoid.RawKind != (int)MetaModelSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
		    return (VoidTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.VoidType((InternalSyntaxToken)kVoid.Green).CreateRed();
		}
		
		public VoidTypeSyntax VoidType()
		{
			return this.VoidType(this.Token(MetaModelSyntaxKind.KVoid));
		}
		
		public NullableTypeSyntax NullableType(PrimitiveTypeSyntax primitiveType, SyntaxToken tQuestion)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
		    if (tQuestion.RawKind != (int)MetaModelSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
		    return (NullableTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.NullableType((Syntax.InternalSyntax.PrimitiveTypeGreen)primitiveType.Green, (InternalSyntaxToken)tQuestion.Green).CreateRed();
		}
		
		public NullableTypeSyntax NullableType(PrimitiveTypeSyntax primitiveType)
		{
			return this.NullableType(primitiveType, this.Token(MetaModelSyntaxKind.TQuestion));
		}
		
		public CollectionTypeSyntax CollectionType(CollectionKindSyntax collectionKind, SyntaxToken tLessThan, SimpleTypeSyntax simpleType, SyntaxToken tGreaterThan)
		{
		    if (collectionKind == null) throw new ArgumentNullException(nameof(collectionKind));
		    if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
		    if (tLessThan.RawKind != (int)MetaModelSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
		    if (tGreaterThan.RawKind != (int)MetaModelSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
		    return (CollectionTypeSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.CollectionType((Syntax.InternalSyntax.CollectionKindGreen)collectionKind.Green, (InternalSyntaxToken)tLessThan.Green, (Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green, (InternalSyntaxToken)tGreaterThan.Green).CreateRed();
		}
		
		public CollectionTypeSyntax CollectionType(CollectionKindSyntax collectionKind, SimpleTypeSyntax simpleType)
		{
			return this.CollectionType(collectionKind, this.Token(MetaModelSyntaxKind.TLessThan), simpleType, this.Token(MetaModelSyntaxKind.TGreaterThan));
		}
		
		public CollectionKindSyntax CollectionKind(SyntaxToken collectionKind)
		{
		    if (collectionKind == null) throw new ArgumentNullException(nameof(collectionKind));
		    return (CollectionKindSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.CollectionKind((InternalSyntaxToken)collectionKind.Green).CreateRed();
		}
		
		public OperationDeclarationSyntax OperationDeclaration(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kStatic, ReturnTypeSyntax returnType, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
		{
		    if (kStatic != null && kStatic.RawKind != (int)MetaModelSyntaxKind.KStatic) throw new ArgumentException(nameof(kStatic));
		    if (returnType == null) throw new ArgumentNullException(nameof(returnType));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.RawKind != (int)MetaModelSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.RawKind != (int)MetaModelSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.RawKind != (int)MetaModelSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (OperationDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(annotation == null ? null : annotation.Green, kStatic == null ? null : (InternalSyntaxToken)kStatic.Green, (Syntax.InternalSyntax.ReturnTypeGreen)returnType.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Green, parameterList == null ? null : (Syntax.InternalSyntax.ParameterListGreen)parameterList.Green, (InternalSyntaxToken)tCloseParen.Green, (InternalSyntaxToken)tSemicolon.Green).CreateRed();
		}
		
		public OperationDeclarationSyntax OperationDeclaration(ReturnTypeSyntax returnType, NameSyntax name)
		{
			return this.OperationDeclaration(null, null, returnType, name, this.Token(MetaModelSyntaxKind.TOpenParen), null, this.Token(MetaModelSyntaxKind.TCloseParen), this.Token(MetaModelSyntaxKind.TSemicolon));
		}
		
		public ParameterListSyntax ParameterList(SeparatedSyntaxNodeList<ParameterSyntax> parameter)
		{
		    if (parameter == null) throw new ArgumentNullException(nameof(parameter));
		    return (ParameterListSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ParameterList(parameter.Green).CreateRed();
		}
		
		public ParameterSyntax Parameter(SyntaxNodeList<AnnotationSyntax> annotation, TypeReferenceSyntax typeReference, NameSyntax name)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (ParameterSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Parameter(annotation == null ? null : annotation.Green, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public ParameterSyntax Parameter(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.Parameter(null, typeReference, name);
		}
		
		public AssociationDeclarationSyntax AssociationDeclaration(SyntaxNodeList<AnnotationSyntax> annotation, SyntaxToken kAssociation, QualifierSyntax source, SyntaxToken kWith, QualifierSyntax target, SyntaxToken tSemicolon)
		{
		    if (kAssociation == null) throw new ArgumentNullException(nameof(kAssociation));
		    if (kAssociation.RawKind != (int)MetaModelSyntaxKind.KAssociation) throw new ArgumentException(nameof(kAssociation));
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (kWith == null) throw new ArgumentNullException(nameof(kWith));
		    if (kWith.RawKind != (int)MetaModelSyntaxKind.KWith) throw new ArgumentException(nameof(kWith));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.RawKind != (int)MetaModelSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (AssociationDeclarationSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.AssociationDeclaration(annotation == null ? null : annotation.Green, (InternalSyntaxToken)kAssociation.Green, (Syntax.InternalSyntax.QualifierGreen)source.Green, (InternalSyntaxToken)kWith.Green, (Syntax.InternalSyntax.QualifierGreen)target.Green, (InternalSyntaxToken)tSemicolon.Green).CreateRed();
		}
		
		public AssociationDeclarationSyntax AssociationDeclaration(QualifierSyntax source, QualifierSyntax target)
		{
			return this.AssociationDeclaration(null, this.Token(MetaModelSyntaxKind.KAssociation), source, this.Token(MetaModelSyntaxKind.KWith), target, this.Token(MetaModelSyntaxKind.TSemicolon));
		}
		
		public IdentifierSyntax Identifier(SyntaxToken identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)identifier.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(NullLiteralSyntax nullLiteral)
		{
		    if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
		    return (LiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.NullLiteralGreen)nullLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(BooleanLiteralSyntax booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (LiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(IntegerLiteralSyntax integerLiteral)
		{
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    return (LiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.IntegerLiteralGreen)integerLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(DecimalLiteralSyntax decimalLiteral)
		{
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
		    return (LiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.DecimalLiteralGreen)decimalLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(ScientificLiteralSyntax scientificLiteral)
		{
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
		    return (LiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.ScientificLiteralGreen)scientificLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (LiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral(SyntaxToken kNull)
		{
		    if (kNull == null) throw new ArgumentNullException(nameof(kNull));
		    if (kNull.RawKind != (int)MetaModelSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
		    return (NullLiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.NullLiteral((InternalSyntaxToken)kNull.Green).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral()
		{
			return this.NullLiteral(this.Token(MetaModelSyntaxKind.KNull));
		}
		
		public BooleanLiteralSyntax BooleanLiteral(SyntaxToken booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (BooleanLiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.BooleanLiteral((InternalSyntaxToken)booleanLiteral.Green).CreateRed();
		}
		
		public IntegerLiteralSyntax IntegerLiteral(SyntaxToken lInteger)
		{
		    if (lInteger == null) throw new ArgumentNullException(nameof(lInteger));
		    if (lInteger.RawKind != (int)MetaModelSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
		    return (IntegerLiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.IntegerLiteral((InternalSyntaxToken)lInteger.Green).CreateRed();
		}
		
		public DecimalLiteralSyntax DecimalLiteral(SyntaxToken lDecimal)
		{
		    if (lDecimal == null) throw new ArgumentNullException(nameof(lDecimal));
		    if (lDecimal.RawKind != (int)MetaModelSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
		    return (DecimalLiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.DecimalLiteral((InternalSyntaxToken)lDecimal.Green).CreateRed();
		}
		
		public ScientificLiteralSyntax ScientificLiteral(SyntaxToken lScientific)
		{
		    if (lScientific == null) throw new ArgumentNullException(nameof(lScientific));
		    if (lScientific.RawKind != (int)MetaModelSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
		    return (ScientificLiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.ScientificLiteral((InternalSyntaxToken)lScientific.Green).CreateRed();
		}
		
		public StringLiteralSyntax StringLiteral(SyntaxToken stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (StringLiteralSyntax)MetaModelLanguage.Instance.InternalSyntaxFactory.StringLiteral((InternalSyntaxToken)stringLiteral.Green).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(NameSyntax),
				typeof(QualifiedNameSyntax),
				typeof(QualifierSyntax),
				typeof(AnnotationSyntax),
				typeof(NamespaceDeclarationSyntax),
				typeof(NamespaceBodySyntax),
				typeof(MetamodelDeclarationSyntax),
				typeof(MetamodelPropertyListSyntax),
				typeof(MetamodelPropertySyntax),
				typeof(MetamodelUriPropertySyntax),
				typeof(DeclarationSyntax),
				typeof(EnumDeclarationSyntax),
				typeof(EnumBodySyntax),
				typeof(EnumValuesSyntax),
				typeof(EnumValueSyntax),
				typeof(EnumMemberDeclarationSyntax),
				typeof(ClassDeclarationSyntax),
				typeof(ClassBodySyntax),
				typeof(ClassAncestorsSyntax),
				typeof(ClassAncestorSyntax),
				typeof(ClassMemberDeclarationSyntax),
				typeof(FieldDeclarationSyntax),
				typeof(FieldModifierSyntax),
				typeof(RedefinitionsOrSubsettingsSyntax),
				typeof(RedefinitionsSyntax),
				typeof(SubsettingsSyntax),
				typeof(NameUseListSyntax),
				typeof(ConstDeclarationSyntax),
				typeof(ReturnTypeSyntax),
				typeof(TypeOfReferenceSyntax),
				typeof(TypeReferenceSyntax),
				typeof(SimpleTypeSyntax),
				typeof(ClassTypeSyntax),
				typeof(ObjectTypeSyntax),
				typeof(PrimitiveTypeSyntax),
				typeof(VoidTypeSyntax),
				typeof(NullableTypeSyntax),
				typeof(CollectionTypeSyntax),
				typeof(CollectionKindSyntax),
				typeof(OperationDeclarationSyntax),
				typeof(ParameterListSyntax),
				typeof(ParameterSyntax),
				typeof(AssociationDeclarationSyntax),
				typeof(IdentifierSyntax),
				typeof(LiteralSyntax),
				typeof(NullLiteralSyntax),
				typeof(BooleanLiteralSyntax),
				typeof(IntegerLiteralSyntax),
				typeof(DecimalLiteralSyntax),
				typeof(ScientificLiteralSyntax),
				typeof(StringLiteralSyntax),
			};
		}
	}
}

