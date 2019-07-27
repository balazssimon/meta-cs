// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Soal.Syntax
{
    public abstract class SoalSyntaxNode : LanguageSyntaxNode
    {
        protected SoalSyntaxNode(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected SoalSyntaxNode(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new SoalLanguage Language => SoalLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new SoalSyntaxKind Kind => (SoalSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

        protected override SyntaxTree CreateSyntaxTreeForRoot()
        {
            return SoalSyntaxTree.CreateWithoutClone(this);
        }

        public override TResult Accept<TArg, TResult>(SyntaxVisitor<TArg, TResult> visitor, TArg argument)
        {
            if (visitor is ISoalSyntaxVisitor<TArg, TResult> typedVisitor) return this.Accept(typedVisitor, argument);
            else return visitor.DefaultVisit(this, argument);
        }

        public abstract TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument);

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            if (visitor is ISoalSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            if (visitor is ISoalSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }
        public abstract void Accept(ISoalSyntaxVisitor visitor);
    }

	
	public sealed class MainSyntax : SoalSyntaxNode, ICompilationUnitSyntax
	{
	    private SyntaxNode namespaceDeclaration;
	
	    public MainSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<NamespaceDeclarationSyntax> NamespaceDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.namespaceDeclaration, 0);
				if (red != null) return new SyntaxList<NamespaceDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken EndOfFileToken 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.EndOfFileToken;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
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
	
	    public MainSyntax WithNamespaceDeclaration(SyntaxList<NamespaceDeclarationSyntax> namespaceDeclaration)
		{
			return this.Update(NamespaceDeclaration, this.EndOfFileToken);
		}
	
	    public MainSyntax AddNamespaceDeclaration(params NamespaceDeclarationSyntax[] namespaceDeclaration)
		{
			return this.WithNamespaceDeclaration(this.NamespaceDeclaration.AddRange(namespaceDeclaration));
		}
	
	    public MainSyntax WithEndOfFileToken(SyntaxToken eof)
		{
			return this.Update(this.NamespaceDeclaration, EndOfFileToken);
		}
	
	    public MainSyntax Update(SyntaxList<NamespaceDeclarationSyntax> namespaceDeclaration, SyntaxToken eof)
	    {
	        if (this.NamespaceDeclaration != namespaceDeclaration ||
				this.EndOfFileToken != eof)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Main(namespaceDeclaration, eof);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class NameSyntax : SoalSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class QualifiedNameSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.QualifiedName(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifiedName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifiedName(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifiedName(this);
	    }
	}
	
	public sealed class QualifierSyntax : SoalSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public QualifierSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<IdentifierSyntax> Identifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.identifier, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<IdentifierSyntax>(red, this.GetChildIndex(0));
				}
				return default;
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
	
	    public QualifierSyntax WithIdentifier(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
			return this.Update(Identifier);
		}
	
	    public QualifierSyntax AddIdentifier(params IdentifierSyntax[] identifier)
		{
			return this.WithIdentifier(this.Identifier.AddRange(identifier));
		}
	
	    public QualifierSyntax Update(SeparatedSyntaxList<IdentifierSyntax> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Qualifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifier(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifier(this);
	    }
	}
	
	public sealed class IdentifierListSyntax : SoalSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public IdentifierListSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierListSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<IdentifierSyntax> Identifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.identifier, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<IdentifierSyntax>(red, this.GetChildIndex(0));
				}
				return default;
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
	
	    public IdentifierListSyntax WithIdentifier(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
			return this.Update(Identifier);
		}
	
	    public IdentifierListSyntax AddIdentifier(params IdentifierSyntax[] identifier)
		{
			return this.WithIdentifier(this.Identifier.AddRange(identifier));
		}
	
	    public IdentifierListSyntax Update(SeparatedSyntaxList<IdentifierSyntax> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.IdentifierList(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifierList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifierList(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifierList(this);
	    }
	}
	
	public sealed class QualifierListSyntax : SoalSyntaxNode
	{
	    private SyntaxNode qualifier;
	
	    public QualifierListSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierListSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<QualifierSyntax> Qualifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.qualifier, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<QualifierSyntax>(red, this.GetChildIndex(0));
				}
				return default;
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
	
	    public QualifierListSyntax WithQualifier(SeparatedSyntaxList<QualifierSyntax> qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public QualifierListSyntax AddQualifier(params QualifierSyntax[] qualifier)
		{
			return this.WithQualifier(this.Qualifier.AddRange(qualifier));
		}
	
	    public QualifierListSyntax Update(SeparatedSyntaxList<QualifierSyntax> qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.QualifierList(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifierList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifierList(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifierList(this);
	    }
	}
	
	public sealed class AnnotationListSyntax : SoalSyntaxNode
	{
	    private SyntaxNode annotation;
	
	    public AnnotationListSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AnnotationListSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new SyntaxList<AnnotationSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				default: return null;
	        }
	    }
	
	    public AnnotationListSyntax WithAnnotation(SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation);
		}
	
	    public AnnotationListSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public AnnotationListSyntax Update(SyntaxList<AnnotationSyntax> annotation)
	    {
	        if (this.Annotation != annotation)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.AnnotationList(annotation);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAnnotationList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAnnotationList(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitAnnotationList(this);
	    }
	}
	
	public sealed class ReturnAnnotationListSyntax : SoalSyntaxNode
	{
	    private SyntaxNode returnAnnotation;
	
	    public ReturnAnnotationListSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReturnAnnotationListSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<ReturnAnnotationSyntax> ReturnAnnotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.returnAnnotation, 0);
				if (red != null) return new SyntaxList<ReturnAnnotationSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.returnAnnotation, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.returnAnnotation;
				default: return null;
	        }
	    }
	
	    public ReturnAnnotationListSyntax WithReturnAnnotation(SyntaxList<ReturnAnnotationSyntax> returnAnnotation)
		{
			return this.Update(ReturnAnnotation);
		}
	
	    public ReturnAnnotationListSyntax AddReturnAnnotation(params ReturnAnnotationSyntax[] returnAnnotation)
		{
			return this.WithReturnAnnotation(this.ReturnAnnotation.AddRange(returnAnnotation));
		}
	
	    public ReturnAnnotationListSyntax Update(SyntaxList<ReturnAnnotationSyntax> returnAnnotation)
	    {
	        if (this.ReturnAnnotation != returnAnnotation)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ReturnAnnotationList(returnAnnotation);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnAnnotationListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitReturnAnnotationList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReturnAnnotationList(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitReturnAnnotationList(this);
	    }
	}
	
	public sealed class AnnotationSyntax : SoalSyntaxNode
	{
	    private AnnotationHeadSyntax annotationHead;
	
	    public AnnotationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AnnotationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.AnnotationGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public AnnotationHeadSyntax AnnotationHead 
		{ 
			get { return this.GetRed(ref this.annotationHead, 1); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.AnnotationGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.annotationHead, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.annotationHead;
				default: return null;
	        }
	    }
	
	    public AnnotationSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.AnnotationHead, this.TCloseBracket);
		}
	
	    public AnnotationSyntax WithAnnotationHead(AnnotationHeadSyntax annotationHead)
		{
			return this.Update(this.TOpenBracket, AnnotationHead, this.TCloseBracket);
		}
	
	    public AnnotationSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.AnnotationHead, TCloseBracket);
		}
	
	    public AnnotationSyntax Update(SyntaxToken tOpenBracket, AnnotationHeadSyntax annotationHead, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.AnnotationHead != annotationHead ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Annotation(tOpenBracket, annotationHead, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAnnotation(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAnnotation(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitAnnotation(this);
	    }
	}
	
	public sealed class ReturnAnnotationSyntax : SoalSyntaxNode
	{
	    private AnnotationHeadSyntax annotationHead;
	
	    public ReturnAnnotationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReturnAnnotationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ReturnAnnotationGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KReturn 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ReturnAnnotationGreen)this.Green;
				var greenToken = green.KReturn;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ReturnAnnotationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public AnnotationHeadSyntax AnnotationHead 
		{ 
			get { return this.GetRed(ref this.annotationHead, 3); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ReturnAnnotationGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.GetRed(ref this.annotationHead, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.annotationHead;
				default: return null;
	        }
	    }
	
	    public ReturnAnnotationSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.KReturn, this.TColon, this.AnnotationHead, this.TCloseBracket);
		}
	
	    public ReturnAnnotationSyntax WithKReturn(SyntaxToken kReturn)
		{
			return this.Update(this.TOpenBracket, KReturn, this.TColon, this.AnnotationHead, this.TCloseBracket);
		}
	
	    public ReturnAnnotationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.TOpenBracket, this.KReturn, TColon, this.AnnotationHead, this.TCloseBracket);
		}
	
	    public ReturnAnnotationSyntax WithAnnotationHead(AnnotationHeadSyntax annotationHead)
		{
			return this.Update(this.TOpenBracket, this.KReturn, this.TColon, AnnotationHead, this.TCloseBracket);
		}
	
	    public ReturnAnnotationSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.KReturn, this.TColon, this.AnnotationHead, TCloseBracket);
		}
	
	    public ReturnAnnotationSyntax Update(SyntaxToken tOpenBracket, SyntaxToken kReturn, SyntaxToken tColon, AnnotationHeadSyntax annotationHead, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.KReturn != kReturn ||
				this.TColon != tColon ||
				this.AnnotationHead != annotationHead ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ReturnAnnotation(tOpenBracket, kReturn, tColon, annotationHead, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnAnnotationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitReturnAnnotation(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReturnAnnotation(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitReturnAnnotation(this);
	    }
	}
	
	public sealed class AnnotationHeadSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	    private AnnotationBodySyntax annotationBody;
	
	    public AnnotationHeadSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AnnotationHeadSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	    public AnnotationBodySyntax AnnotationBody 
		{ 
			get { return this.GetRed(ref this.annotationBody, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				case 1: return this.GetRed(ref this.annotationBody, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				case 1: return this.annotationBody;
				default: return null;
	        }
	    }
	
	    public AnnotationHeadSyntax WithName(NameSyntax name)
		{
			return this.Update(Name, this.AnnotationBody);
		}
	
	    public AnnotationHeadSyntax WithAnnotationBody(AnnotationBodySyntax annotationBody)
		{
			return this.Update(this.Name, AnnotationBody);
		}
	
	    public AnnotationHeadSyntax Update(NameSyntax name, AnnotationBodySyntax annotationBody)
	    {
	        if (this.Name != name ||
				this.AnnotationBody != annotationBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.AnnotationHead(name, annotationBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationHeadSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAnnotationHead(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAnnotationHead(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitAnnotationHead(this);
	    }
	}
	
	public sealed class AnnotationBodySyntax : SoalSyntaxNode
	{
	    private AnnotationPropertyListSyntax annotationPropertyList;
	
	    public AnnotationBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AnnotationBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.AnnotationBodyGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public AnnotationPropertyListSyntax AnnotationPropertyList 
		{ 
			get { return this.GetRed(ref this.annotationPropertyList, 1); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.AnnotationBodyGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.annotationPropertyList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.annotationPropertyList;
				default: return null;
	        }
	    }
	
	    public AnnotationBodySyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.AnnotationPropertyList, this.TCloseParen);
		}
	
	    public AnnotationBodySyntax WithAnnotationPropertyList(AnnotationPropertyListSyntax annotationPropertyList)
		{
			return this.Update(this.TOpenParen, AnnotationPropertyList, this.TCloseParen);
		}
	
	    public AnnotationBodySyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.AnnotationPropertyList, TCloseParen);
		}
	
	    public AnnotationBodySyntax Update(SyntaxToken tOpenParen, AnnotationPropertyListSyntax annotationPropertyList, SyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.AnnotationPropertyList != annotationPropertyList ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.AnnotationBody(tOpenParen, annotationPropertyList, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAnnotationBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAnnotationBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitAnnotationBody(this);
	    }
	}
	
	public sealed class AnnotationPropertyListSyntax : SoalSyntaxNode
	{
	    private SyntaxNode annotationProperty;
	
	    public AnnotationPropertyListSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AnnotationPropertyListSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<AnnotationPropertySyntax> AnnotationProperty 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotationProperty, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<AnnotationPropertySyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotationProperty, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationProperty;
				default: return null;
	        }
	    }
	
	    public AnnotationPropertyListSyntax WithAnnotationProperty(SeparatedSyntaxList<AnnotationPropertySyntax> annotationProperty)
		{
			return this.Update(AnnotationProperty);
		}
	
	    public AnnotationPropertyListSyntax AddAnnotationProperty(params AnnotationPropertySyntax[] annotationProperty)
		{
			return this.WithAnnotationProperty(this.AnnotationProperty.AddRange(annotationProperty));
		}
	
	    public AnnotationPropertyListSyntax Update(SeparatedSyntaxList<AnnotationPropertySyntax> annotationProperty)
	    {
	        if (this.AnnotationProperty != annotationProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.AnnotationPropertyList(annotationProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationPropertyListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAnnotationPropertyList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAnnotationPropertyList(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitAnnotationPropertyList(this);
	    }
	}
	
	public sealed class AnnotationPropertySyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	    private AnnotationPropertyValueSyntax annotationPropertyValue;
	
	    public AnnotationPropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AnnotationPropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.AnnotationPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public AnnotationPropertyValueSyntax AnnotationPropertyValue 
		{ 
			get { return this.GetRed(ref this.annotationPropertyValue, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				case 2: return this.GetRed(ref this.annotationPropertyValue, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				case 2: return this.annotationPropertyValue;
				default: return null;
	        }
	    }
	
	    public AnnotationPropertySyntax WithName(NameSyntax name)
		{
			return this.Update(Name, this.TAssign, this.AnnotationPropertyValue);
		}
	
	    public AnnotationPropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.Name, TAssign, this.AnnotationPropertyValue);
		}
	
	    public AnnotationPropertySyntax WithAnnotationPropertyValue(AnnotationPropertyValueSyntax annotationPropertyValue)
		{
			return this.Update(this.Name, this.TAssign, AnnotationPropertyValue);
		}
	
	    public AnnotationPropertySyntax Update(NameSyntax name, SyntaxToken tAssign, AnnotationPropertyValueSyntax annotationPropertyValue)
	    {
	        if (this.Name != name ||
				this.TAssign != tAssign ||
				this.AnnotationPropertyValue != annotationPropertyValue)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.AnnotationProperty(name, tAssign, annotationPropertyValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAnnotationProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAnnotationProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitAnnotationProperty(this);
	    }
	}
	
	public sealed class AnnotationPropertyValueSyntax : SoalSyntaxNode
	{
	    private ConstantValueSyntax constantValue;
	    private TypeofValueSyntax typeofValue;
	
	    public AnnotationPropertyValueSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AnnotationPropertyValueSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ConstantValueSyntax ConstantValue 
		{ 
			get { return this.GetRed(ref this.constantValue, 0); } 
		}
	    public TypeofValueSyntax TypeofValue 
		{ 
			get { return this.GetRed(ref this.typeofValue, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.constantValue, 0);
				case 1: return this.GetRed(ref this.typeofValue, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.constantValue;
				case 1: return this.typeofValue;
				default: return null;
	        }
	    }
	
	    public AnnotationPropertyValueSyntax WithConstantValue(ConstantValueSyntax constantValue)
		{
			return this.Update(constantValue);
		}
	
	    public AnnotationPropertyValueSyntax WithTypeofValue(TypeofValueSyntax typeofValue)
		{
			return this.Update(typeofValue);
		}
	
	    public AnnotationPropertyValueSyntax Update(ConstantValueSyntax constantValue)
	    {
	        if (this.ConstantValue != constantValue)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.AnnotationPropertyValue(constantValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationPropertyValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public AnnotationPropertyValueSyntax Update(TypeofValueSyntax typeofValue)
	    {
	        if (this.TypeofValue != typeofValue)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.AnnotationPropertyValue(typeofValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationPropertyValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAnnotationPropertyValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAnnotationPropertyValue(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitAnnotationPropertyValue(this);
	    }
	}
	
	public sealed class NamespaceDeclarationSyntax : SoalSyntaxNode
	{
	    private AnnotationListSyntax annotationList;
	    private QualifiedNameSyntax qualifiedName;
	    private NamespacePrefixSyntax namespacePrefix;
	    private NamespaceUriSyntax namespaceUri;
	    private NamespaceBodySyntax namespaceBody;
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnnotationListSyntax AnnotationList 
		{ 
			get { return this.GetRed(ref this.annotationList, 0); } 
		}
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 2); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public NamespacePrefixSyntax NamespacePrefix 
		{ 
			get { return this.GetRed(ref this.namespacePrefix, 4); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	    public NamespaceUriSyntax NamespaceUri 
		{ 
			get { return this.GetRed(ref this.namespaceUri, 6); } 
		}
	    public NamespaceBodySyntax NamespaceBody 
		{ 
			get { return this.GetRed(ref this.namespaceBody, 7); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotationList, 0);
				case 2: return this.GetRed(ref this.qualifiedName, 2);
				case 4: return this.GetRed(ref this.namespacePrefix, 4);
				case 6: return this.GetRed(ref this.namespaceUri, 6);
				case 7: return this.GetRed(ref this.namespaceBody, 7);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationList;
				case 2: return this.qualifiedName;
				case 4: return this.namespacePrefix;
				case 6: return this.namespaceUri;
				case 7: return this.namespaceBody;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclarationSyntax WithAnnotationList(AnnotationListSyntax annotationList)
		{
			return this.Update(AnnotationList, this.KNamespace, this.QualifiedName, this.TAssign, this.NamespacePrefix, this.TColon, this.NamespaceUri, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(this.AnnotationList, KNamespace, this.QualifiedName, this.TAssign, this.NamespacePrefix, this.TColon, this.NamespaceUri, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.AnnotationList, this.KNamespace, QualifiedName, this.TAssign, this.NamespacePrefix, this.TColon, this.NamespaceUri, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.AnnotationList, this.KNamespace, this.QualifiedName, TAssign, this.NamespacePrefix, this.TColon, this.NamespaceUri, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithNamespacePrefix(NamespacePrefixSyntax namespacePrefix)
		{
			return this.Update(this.AnnotationList, this.KNamespace, this.QualifiedName, this.TAssign, NamespacePrefix, this.TColon, this.NamespaceUri, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.AnnotationList, this.KNamespace, this.QualifiedName, this.TAssign, this.NamespacePrefix, TColon, this.NamespaceUri, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithNamespaceUri(NamespaceUriSyntax namespaceUri)
		{
			return this.Update(this.AnnotationList, this.KNamespace, this.QualifiedName, this.TAssign, this.NamespacePrefix, this.TColon, NamespaceUri, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithNamespaceBody(NamespaceBodySyntax namespaceBody)
		{
			return this.Update(this.AnnotationList, this.KNamespace, this.QualifiedName, this.TAssign, this.NamespacePrefix, this.TColon, this.NamespaceUri, NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax Update(AnnotationListSyntax annotationList, SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, SyntaxToken tAssign, NamespacePrefixSyntax namespacePrefix, SyntaxToken tColon, NamespaceUriSyntax namespaceUri, NamespaceBodySyntax namespaceBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.TAssign != tAssign ||
				this.NamespacePrefix != namespacePrefix ||
				this.TColon != tColon ||
				this.NamespaceUri != namespaceUri ||
				this.NamespaceBody != namespaceBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NamespaceDeclaration(annotationList, kNamespace, qualifiedName, tAssign, namespacePrefix, tColon, namespaceUri, namespaceBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration(this);
	    }
	}
	
	public sealed class NamespacePrefixSyntax : SoalSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NamespacePrefixSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespacePrefixSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
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
	
	    public NamespacePrefixSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public NamespacePrefixSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NamespacePrefix(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespacePrefixSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespacePrefix(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespacePrefix(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespacePrefix(this);
	    }
	}
	
	public sealed class NamespaceUriSyntax : SoalSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public NamespaceUriSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceUriSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public StringLiteralSyntax StringLiteral 
		{ 
			get { return this.GetRed(ref this.stringLiteral, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.stringLiteral, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.stringLiteral;
				default: return null;
	        }
	    }
	
	    public NamespaceUriSyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(StringLiteral);
		}
	
	    public NamespaceUriSyntax Update(StringLiteralSyntax stringLiteral)
	    {
	        if (this.StringLiteral != stringLiteral)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NamespaceUri(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceUriSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceUri(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceUri(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceUri(this);
	    }
	}
	
	public sealed class NamespaceBodySyntax : SoalSyntaxNode
	{
	    private SyntaxNode declaration;
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<DeclarationSyntax> Declaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration, 1);
				if (red != null) return new SyntaxList<DeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration;
				default: return null;
	        }
	    }
	
	    public NamespaceBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax WithDeclaration(SyntaxList<DeclarationSyntax> declaration)
		{
			return this.Update(this.TOpenBrace, Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax AddDeclaration(params DeclarationSyntax[] declaration)
		{
			return this.WithDeclaration(this.Declaration.AddRange(declaration));
		}
	
	    public NamespaceBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration, TCloseBrace);
		}
	
	    public NamespaceBodySyntax Update(SyntaxToken tOpenBrace, SyntaxList<DeclarationSyntax> declaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration != declaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NamespaceBody(tOpenBrace, declaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody(this);
	    }
	}
	
	public sealed class DeclarationSyntax : SoalSyntaxNode
	{
	    private EnumDeclarationSyntax enumDeclaration;
	    private StructDeclarationSyntax structDeclaration;
	    private DatabaseDeclarationSyntax databaseDeclaration;
	    private InterfaceDeclarationSyntax interfaceDeclaration;
	    private ComponentDeclarationSyntax componentDeclaration;
	    private CompositeDeclarationSyntax compositeDeclaration;
	    private AssemblyDeclarationSyntax assemblyDeclaration;
	    private BindingDeclarationSyntax bindingDeclaration;
	    private EndpointDeclarationSyntax endpointDeclaration;
	    private DeploymentDeclarationSyntax deploymentDeclaration;
	
	    public DeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public EnumDeclarationSyntax EnumDeclaration 
		{ 
			get { return this.GetRed(ref this.enumDeclaration, 0); } 
		}
	    public StructDeclarationSyntax StructDeclaration 
		{ 
			get { return this.GetRed(ref this.structDeclaration, 1); } 
		}
	    public DatabaseDeclarationSyntax DatabaseDeclaration 
		{ 
			get { return this.GetRed(ref this.databaseDeclaration, 2); } 
		}
	    public InterfaceDeclarationSyntax InterfaceDeclaration 
		{ 
			get { return this.GetRed(ref this.interfaceDeclaration, 3); } 
		}
	    public ComponentDeclarationSyntax ComponentDeclaration 
		{ 
			get { return this.GetRed(ref this.componentDeclaration, 4); } 
		}
	    public CompositeDeclarationSyntax CompositeDeclaration 
		{ 
			get { return this.GetRed(ref this.compositeDeclaration, 5); } 
		}
	    public AssemblyDeclarationSyntax AssemblyDeclaration 
		{ 
			get { return this.GetRed(ref this.assemblyDeclaration, 6); } 
		}
	    public BindingDeclarationSyntax BindingDeclaration 
		{ 
			get { return this.GetRed(ref this.bindingDeclaration, 7); } 
		}
	    public EndpointDeclarationSyntax EndpointDeclaration 
		{ 
			get { return this.GetRed(ref this.endpointDeclaration, 8); } 
		}
	    public DeploymentDeclarationSyntax DeploymentDeclaration 
		{ 
			get { return this.GetRed(ref this.deploymentDeclaration, 9); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.enumDeclaration, 0);
				case 1: return this.GetRed(ref this.structDeclaration, 1);
				case 2: return this.GetRed(ref this.databaseDeclaration, 2);
				case 3: return this.GetRed(ref this.interfaceDeclaration, 3);
				case 4: return this.GetRed(ref this.componentDeclaration, 4);
				case 5: return this.GetRed(ref this.compositeDeclaration, 5);
				case 6: return this.GetRed(ref this.assemblyDeclaration, 6);
				case 7: return this.GetRed(ref this.bindingDeclaration, 7);
				case 8: return this.GetRed(ref this.endpointDeclaration, 8);
				case 9: return this.GetRed(ref this.deploymentDeclaration, 9);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.enumDeclaration;
				case 1: return this.structDeclaration;
				case 2: return this.databaseDeclaration;
				case 3: return this.interfaceDeclaration;
				case 4: return this.componentDeclaration;
				case 5: return this.compositeDeclaration;
				case 6: return this.assemblyDeclaration;
				case 7: return this.bindingDeclaration;
				case 8: return this.endpointDeclaration;
				case 9: return this.deploymentDeclaration;
				default: return null;
	        }
	    }
	
	    public DeclarationSyntax WithEnumDeclaration(EnumDeclarationSyntax enumDeclaration)
		{
			return this.Update(enumDeclaration);
		}
	
	    public DeclarationSyntax WithStructDeclaration(StructDeclarationSyntax structDeclaration)
		{
			return this.Update(structDeclaration);
		}
	
	    public DeclarationSyntax WithDatabaseDeclaration(DatabaseDeclarationSyntax databaseDeclaration)
		{
			return this.Update(databaseDeclaration);
		}
	
	    public DeclarationSyntax WithInterfaceDeclaration(InterfaceDeclarationSyntax interfaceDeclaration)
		{
			return this.Update(interfaceDeclaration);
		}
	
	    public DeclarationSyntax WithComponentDeclaration(ComponentDeclarationSyntax componentDeclaration)
		{
			return this.Update(componentDeclaration);
		}
	
	    public DeclarationSyntax WithCompositeDeclaration(CompositeDeclarationSyntax compositeDeclaration)
		{
			return this.Update(compositeDeclaration);
		}
	
	    public DeclarationSyntax WithAssemblyDeclaration(AssemblyDeclarationSyntax assemblyDeclaration)
		{
			return this.Update(assemblyDeclaration);
		}
	
	    public DeclarationSyntax WithBindingDeclaration(BindingDeclarationSyntax bindingDeclaration)
		{
			return this.Update(bindingDeclaration);
		}
	
	    public DeclarationSyntax WithEndpointDeclaration(EndpointDeclarationSyntax endpointDeclaration)
		{
			return this.Update(endpointDeclaration);
		}
	
	    public DeclarationSyntax WithDeploymentDeclaration(DeploymentDeclarationSyntax deploymentDeclaration)
		{
			return this.Update(deploymentDeclaration);
		}
	
	    public DeclarationSyntax Update(EnumDeclarationSyntax enumDeclaration)
	    {
	        if (this.EnumDeclaration != enumDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(enumDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(StructDeclarationSyntax structDeclaration)
	    {
	        if (this.StructDeclaration != structDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(structDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(DatabaseDeclarationSyntax databaseDeclaration)
	    {
	        if (this.DatabaseDeclaration != databaseDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(databaseDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(InterfaceDeclarationSyntax interfaceDeclaration)
	    {
	        if (this.InterfaceDeclaration != interfaceDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(interfaceDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(ComponentDeclarationSyntax componentDeclaration)
	    {
	        if (this.ComponentDeclaration != componentDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(componentDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(CompositeDeclarationSyntax compositeDeclaration)
	    {
	        if (this.CompositeDeclaration != compositeDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(compositeDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(AssemblyDeclarationSyntax assemblyDeclaration)
	    {
	        if (this.AssemblyDeclaration != assemblyDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(assemblyDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(BindingDeclarationSyntax bindingDeclaration)
	    {
	        if (this.BindingDeclaration != bindingDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(bindingDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(EndpointDeclarationSyntax endpointDeclaration)
	    {
	        if (this.EndpointDeclaration != endpointDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(endpointDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(DeploymentDeclarationSyntax deploymentDeclaration)
	    {
	        if (this.DeploymentDeclaration != deploymentDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Declaration(deploymentDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration(this);
	    }
	}
	
	public sealed class EnumDeclarationSyntax : SoalSyntaxNode
	{
	    private AnnotationListSyntax annotationList;
	    private NameSyntax name;
	    private EnumBaseSyntax enumBase;
	    private EnumBodySyntax enumBody;
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnnotationListSyntax AnnotationList 
		{ 
			get { return this.GetRed(ref this.annotationList, 0); } 
		}
	    public SyntaxToken KEnum 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EnumDeclarationGreen)this.Green;
				var greenToken = green.KEnum;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EnumDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public EnumBaseSyntax EnumBase 
		{ 
			get { return this.GetRed(ref this.enumBase, 4); } 
		}
	    public EnumBodySyntax EnumBody 
		{ 
			get { return this.GetRed(ref this.enumBody, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotationList, 0);
				case 2: return this.GetRed(ref this.name, 2);
				case 4: return this.GetRed(ref this.enumBase, 4);
				case 5: return this.GetRed(ref this.enumBody, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationList;
				case 2: return this.name;
				case 4: return this.enumBase;
				case 5: return this.enumBody;
				default: return null;
	        }
	    }
	
	    public EnumDeclarationSyntax WithAnnotationList(AnnotationListSyntax annotationList)
		{
			return this.Update(AnnotationList, this.KEnum, this.Name, this.TColon, this.EnumBase, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax WithKEnum(SyntaxToken kEnum)
		{
			return this.Update(this.AnnotationList, KEnum, this.Name, this.TColon, this.EnumBase, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.AnnotationList, this.KEnum, Name, this.TColon, this.EnumBase, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.AnnotationList, this.KEnum, this.Name, TColon, this.EnumBase, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax WithEnumBase(EnumBaseSyntax enumBase)
		{
			return this.Update(this.AnnotationList, this.KEnum, this.Name, this.TColon, EnumBase, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax WithEnumBody(EnumBodySyntax enumBody)
		{
			return this.Update(this.AnnotationList, this.KEnum, this.Name, this.TColon, this.EnumBase, EnumBody);
		}
	
	    public EnumDeclarationSyntax Update(AnnotationListSyntax annotationList, SyntaxToken kEnum, NameSyntax name, SyntaxToken tColon, EnumBaseSyntax enumBase, EnumBodySyntax enumBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KEnum != kEnum ||
				this.Name != name ||
				this.TColon != tColon ||
				this.EnumBase != enumBase ||
				this.EnumBody != enumBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EnumDeclaration(annotationList, kEnum, name, tColon, enumBase, enumBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumDeclaration(this);
	    }
	}
	
	public sealed class EnumBaseSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public EnumBaseSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumBaseSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
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
	
	    public EnumBaseSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public EnumBaseSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EnumBase(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumBaseSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumBase(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumBase(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumBase(this);
	    }
	}
	
	public sealed class EnumBodySyntax : SoalSyntaxNode
	{
	    private EnumLiteralsSyntax enumLiterals;
	
	    public EnumBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public EnumLiteralsSyntax EnumLiterals 
		{ 
			get { return this.GetRed(ref this.enumLiterals, 1); } 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.enumLiterals, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.enumLiterals;
				default: return null;
	        }
	    }
	
	    public EnumBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.EnumLiterals, this.TCloseBrace);
		}
	
	    public EnumBodySyntax WithEnumLiterals(EnumLiteralsSyntax enumLiterals)
		{
			return this.Update(this.TOpenBrace, EnumLiterals, this.TCloseBrace);
		}
	
	    public EnumBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.EnumLiterals, TCloseBrace);
		}
	
	    public EnumBodySyntax Update(SyntaxToken tOpenBrace, EnumLiteralsSyntax enumLiterals, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EnumLiterals != enumLiterals ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EnumBody(tOpenBrace, enumLiterals, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumBody(this);
	    }
	}
	
	public sealed class EnumLiteralsSyntax : SoalSyntaxNode
	{
	    private SyntaxNode enumLiteral;
	
	    public EnumLiteralsSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumLiteralsSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<EnumLiteralSyntax> EnumLiteral 
		{ 
			get
			{
				var red = this.GetRed(ref this.enumLiteral, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<EnumLiteralSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.enumLiteral, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.enumLiteral;
				default: return null;
	        }
	    }
	
	    public EnumLiteralsSyntax WithEnumLiteral(SeparatedSyntaxList<EnumLiteralSyntax> enumLiteral)
		{
			return this.Update(EnumLiteral);
		}
	
	    public EnumLiteralsSyntax AddEnumLiteral(params EnumLiteralSyntax[] enumLiteral)
		{
			return this.WithEnumLiteral(this.EnumLiteral.AddRange(enumLiteral));
		}
	
	    public EnumLiteralsSyntax Update(SeparatedSyntaxList<EnumLiteralSyntax> enumLiteral)
	    {
	        if (this.EnumLiteral != enumLiteral)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EnumLiterals(enumLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumLiteralsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumLiterals(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumLiterals(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumLiterals(this);
	    }
	}
	
	public sealed class EnumLiteralSyntax : SoalSyntaxNode
	{
	    private AnnotationListSyntax annotationList;
	    private NameSyntax name;
	
	    public EnumLiteralSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumLiteralSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnnotationListSyntax AnnotationList 
		{ 
			get { return this.GetRed(ref this.annotationList, 0); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotationList, 0);
				case 1: return this.GetRed(ref this.name, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationList;
				case 1: return this.name;
				default: return null;
	        }
	    }
	
	    public EnumLiteralSyntax WithAnnotationList(AnnotationListSyntax annotationList)
		{
			return this.Update(AnnotationList, this.Name);
		}
	
	    public EnumLiteralSyntax WithName(NameSyntax name)
		{
			return this.Update(this.AnnotationList, Name);
		}
	
	    public EnumLiteralSyntax Update(AnnotationListSyntax annotationList, NameSyntax name)
	    {
	        if (this.AnnotationList != annotationList ||
				this.Name != name)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EnumLiteral(annotationList, name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumLiteral(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumLiteral(this);
	    }
	}
	
	public sealed class StructDeclarationSyntax : SoalSyntaxNode
	{
	    private AnnotationListSyntax annotationList;
	    private NameSyntax name;
	    private QualifierSyntax qualifier;
	    private StructBodySyntax structBody;
	
	    public StructDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StructDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnnotationListSyntax AnnotationList 
		{ 
			get { return this.GetRed(ref this.annotationList, 0); } 
		}
	    public SyntaxToken KStruct 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.StructDeclarationGreen)this.Green;
				var greenToken = green.KStruct;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.StructDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 4); } 
		}
	    public StructBodySyntax StructBody 
		{ 
			get { return this.GetRed(ref this.structBody, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotationList, 0);
				case 2: return this.GetRed(ref this.name, 2);
				case 4: return this.GetRed(ref this.qualifier, 4);
				case 5: return this.GetRed(ref this.structBody, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationList;
				case 2: return this.name;
				case 4: return this.qualifier;
				case 5: return this.structBody;
				default: return null;
	        }
	    }
	
	    public StructDeclarationSyntax WithAnnotationList(AnnotationListSyntax annotationList)
		{
			return this.Update(AnnotationList, this.KStruct, this.Name, this.TColon, this.Qualifier, this.StructBody);
		}
	
	    public StructDeclarationSyntax WithKStruct(SyntaxToken kStruct)
		{
			return this.Update(this.AnnotationList, KStruct, this.Name, this.TColon, this.Qualifier, this.StructBody);
		}
	
	    public StructDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.AnnotationList, this.KStruct, Name, this.TColon, this.Qualifier, this.StructBody);
		}
	
	    public StructDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.AnnotationList, this.KStruct, this.Name, TColon, this.Qualifier, this.StructBody);
		}
	
	    public StructDeclarationSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.AnnotationList, this.KStruct, this.Name, this.TColon, Qualifier, this.StructBody);
		}
	
	    public StructDeclarationSyntax WithStructBody(StructBodySyntax structBody)
		{
			return this.Update(this.AnnotationList, this.KStruct, this.Name, this.TColon, this.Qualifier, StructBody);
		}
	
	    public StructDeclarationSyntax Update(AnnotationListSyntax annotationList, SyntaxToken kStruct, NameSyntax name, SyntaxToken tColon, QualifierSyntax qualifier, StructBodySyntax structBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KStruct != kStruct ||
				this.Name != name ||
				this.TColon != tColon ||
				this.Qualifier != qualifier ||
				this.StructBody != structBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.StructDeclaration(annotationList, kStruct, name, tColon, qualifier, structBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StructDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStructDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStructDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitStructDeclaration(this);
	    }
	}
	
	public sealed class StructBodySyntax : SoalSyntaxNode
	{
	    private SyntaxNode propertyDeclaration;
	
	    public StructBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StructBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.StructBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<PropertyDeclarationSyntax> PropertyDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.propertyDeclaration, 1);
				if (red != null) return new SyntaxList<PropertyDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.StructBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.propertyDeclaration, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.propertyDeclaration;
				default: return null;
	        }
	    }
	
	    public StructBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.PropertyDeclaration, this.TCloseBrace);
		}
	
	    public StructBodySyntax WithPropertyDeclaration(SyntaxList<PropertyDeclarationSyntax> propertyDeclaration)
		{
			return this.Update(this.TOpenBrace, PropertyDeclaration, this.TCloseBrace);
		}
	
	    public StructBodySyntax AddPropertyDeclaration(params PropertyDeclarationSyntax[] propertyDeclaration)
		{
			return this.WithPropertyDeclaration(this.PropertyDeclaration.AddRange(propertyDeclaration));
		}
	
	    public StructBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.PropertyDeclaration, TCloseBrace);
		}
	
	    public StructBodySyntax Update(SyntaxToken tOpenBrace, SyntaxList<PropertyDeclarationSyntax> propertyDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.PropertyDeclaration != propertyDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.StructBody(tOpenBrace, propertyDeclaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StructBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStructBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStructBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitStructBody(this);
	    }
	}
	
	public sealed class PropertyDeclarationSyntax : SoalSyntaxNode
	{
	    private AnnotationListSyntax annotationList;
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	
	    public PropertyDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PropertyDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnnotationListSyntax AnnotationList 
		{ 
			get { return this.GetRed(ref this.annotationList, 0); } 
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
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.PropertyDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotationList, 0);
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 2: return this.GetRed(ref this.name, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationList;
				case 1: return this.typeReference;
				case 2: return this.name;
				default: return null;
	        }
	    }
	
	    public PropertyDeclarationSyntax WithAnnotationList(AnnotationListSyntax annotationList)
		{
			return this.Update(AnnotationList, this.TypeReference, this.Name, this.TSemicolon);
		}
	
	    public PropertyDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.AnnotationList, TypeReference, this.Name, this.TSemicolon);
		}
	
	    public PropertyDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.AnnotationList, this.TypeReference, Name, this.TSemicolon);
		}
	
	    public PropertyDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.AnnotationList, this.TypeReference, this.Name, TSemicolon);
		}
	
	    public PropertyDeclarationSyntax Update(AnnotationListSyntax annotationList, TypeReferenceSyntax typeReference, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.AnnotationList != annotationList ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.PropertyDeclaration(annotationList, typeReference, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PropertyDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPropertyDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPropertyDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitPropertyDeclaration(this);
	    }
	}
	
	public sealed class DatabaseDeclarationSyntax : SoalSyntaxNode
	{
	    private AnnotationListSyntax annotationList;
	    private NameSyntax name;
	    private DatabaseBodySyntax databaseBody;
	
	    public DatabaseDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DatabaseDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnnotationListSyntax AnnotationList 
		{ 
			get { return this.GetRed(ref this.annotationList, 0); } 
		}
	    public SyntaxToken KDatabase 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.DatabaseDeclarationGreen)this.Green;
				var greenToken = green.KDatabase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public DatabaseBodySyntax DatabaseBody 
		{ 
			get { return this.GetRed(ref this.databaseBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotationList, 0);
				case 2: return this.GetRed(ref this.name, 2);
				case 3: return this.GetRed(ref this.databaseBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationList;
				case 2: return this.name;
				case 3: return this.databaseBody;
				default: return null;
	        }
	    }
	
	    public DatabaseDeclarationSyntax WithAnnotationList(AnnotationListSyntax annotationList)
		{
			return this.Update(AnnotationList, this.KDatabase, this.Name, this.DatabaseBody);
		}
	
	    public DatabaseDeclarationSyntax WithKDatabase(SyntaxToken kDatabase)
		{
			return this.Update(this.AnnotationList, KDatabase, this.Name, this.DatabaseBody);
		}
	
	    public DatabaseDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.AnnotationList, this.KDatabase, Name, this.DatabaseBody);
		}
	
	    public DatabaseDeclarationSyntax WithDatabaseBody(DatabaseBodySyntax databaseBody)
		{
			return this.Update(this.AnnotationList, this.KDatabase, this.Name, DatabaseBody);
		}
	
	    public DatabaseDeclarationSyntax Update(AnnotationListSyntax annotationList, SyntaxToken kDatabase, NameSyntax name, DatabaseBodySyntax databaseBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KDatabase != kDatabase ||
				this.Name != name ||
				this.DatabaseBody != databaseBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.DatabaseDeclaration(annotationList, kDatabase, name, databaseBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DatabaseDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDatabaseDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDatabaseDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitDatabaseDeclaration(this);
	    }
	}
	
	public sealed class DatabaseBodySyntax : SoalSyntaxNode
	{
	    private SyntaxNode entityReference;
	    private SyntaxNode operationDeclaration;
	
	    public DatabaseBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DatabaseBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.DatabaseBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<EntityReferenceSyntax> EntityReference 
		{ 
			get
			{
				var red = this.GetRed(ref this.entityReference, 1);
				if (red != null) return new SyntaxList<EntityReferenceSyntax>(red);
				return default;
			} 
		}
	    public SyntaxList<OperationDeclarationSyntax> OperationDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.operationDeclaration, 2);
				if (red != null) return new SyntaxList<OperationDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.DatabaseBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.entityReference, 1);
				case 2: return this.GetRed(ref this.operationDeclaration, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.entityReference;
				case 2: return this.operationDeclaration;
				default: return null;
	        }
	    }
	
	    public DatabaseBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.EntityReference, this.OperationDeclaration, this.TCloseBrace);
		}
	
	    public DatabaseBodySyntax WithEntityReference(SyntaxList<EntityReferenceSyntax> entityReference)
		{
			return this.Update(this.TOpenBrace, EntityReference, this.OperationDeclaration, this.TCloseBrace);
		}
	
	    public DatabaseBodySyntax AddEntityReference(params EntityReferenceSyntax[] entityReference)
		{
			return this.WithEntityReference(this.EntityReference.AddRange(entityReference));
		}
	
	    public DatabaseBodySyntax WithOperationDeclaration(SyntaxList<OperationDeclarationSyntax> operationDeclaration)
		{
			return this.Update(this.TOpenBrace, this.EntityReference, OperationDeclaration, this.TCloseBrace);
		}
	
	    public DatabaseBodySyntax AddOperationDeclaration(params OperationDeclarationSyntax[] operationDeclaration)
		{
			return this.WithOperationDeclaration(this.OperationDeclaration.AddRange(operationDeclaration));
		}
	
	    public DatabaseBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.EntityReference, this.OperationDeclaration, TCloseBrace);
		}
	
	    public DatabaseBodySyntax Update(SyntaxToken tOpenBrace, SyntaxList<EntityReferenceSyntax> entityReference, SyntaxList<OperationDeclarationSyntax> operationDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EntityReference != entityReference ||
				this.OperationDeclaration != operationDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.DatabaseBody(tOpenBrace, entityReference, operationDeclaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DatabaseBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDatabaseBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDatabaseBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitDatabaseBody(this);
	    }
	}
	
	public sealed class EntityReferenceSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public EntityReferenceSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EntityReferenceSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEntity 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EntityReferenceGreen)this.Green;
				var greenToken = green.KEntity;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EntityReferenceGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public EntityReferenceSyntax WithKEntity(SyntaxToken kEntity)
		{
			return this.Update(KEntity, this.Qualifier, this.TSemicolon);
		}
	
	    public EntityReferenceSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KEntity, Qualifier, this.TSemicolon);
		}
	
	    public EntityReferenceSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KEntity, this.Qualifier, TSemicolon);
		}
	
	    public EntityReferenceSyntax Update(SyntaxToken kEntity, QualifierSyntax qualifier, SyntaxToken tSemicolon)
	    {
	        if (this.KEntity != kEntity ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EntityReference(kEntity, qualifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EntityReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEntityReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEntityReference(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEntityReference(this);
	    }
	}
	
	public sealed class InterfaceDeclarationSyntax : SoalSyntaxNode
	{
	    private AnnotationListSyntax annotationList;
	    private NameSyntax name;
	    private InterfaceBodySyntax interfaceBody;
	
	    public InterfaceDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InterfaceDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnnotationListSyntax AnnotationList 
		{ 
			get { return this.GetRed(ref this.annotationList, 0); } 
		}
	    public SyntaxToken KInterface 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.InterfaceDeclarationGreen)this.Green;
				var greenToken = green.KInterface;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public InterfaceBodySyntax InterfaceBody 
		{ 
			get { return this.GetRed(ref this.interfaceBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotationList, 0);
				case 2: return this.GetRed(ref this.name, 2);
				case 3: return this.GetRed(ref this.interfaceBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationList;
				case 2: return this.name;
				case 3: return this.interfaceBody;
				default: return null;
	        }
	    }
	
	    public InterfaceDeclarationSyntax WithAnnotationList(AnnotationListSyntax annotationList)
		{
			return this.Update(AnnotationList, this.KInterface, this.Name, this.InterfaceBody);
		}
	
	    public InterfaceDeclarationSyntax WithKInterface(SyntaxToken kInterface)
		{
			return this.Update(this.AnnotationList, KInterface, this.Name, this.InterfaceBody);
		}
	
	    public InterfaceDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.AnnotationList, this.KInterface, Name, this.InterfaceBody);
		}
	
	    public InterfaceDeclarationSyntax WithInterfaceBody(InterfaceBodySyntax interfaceBody)
		{
			return this.Update(this.AnnotationList, this.KInterface, this.Name, InterfaceBody);
		}
	
	    public InterfaceDeclarationSyntax Update(AnnotationListSyntax annotationList, SyntaxToken kInterface, NameSyntax name, InterfaceBodySyntax interfaceBody)
	    {
	        if (this.AnnotationList != annotationList ||
				this.KInterface != kInterface ||
				this.Name != name ||
				this.InterfaceBody != interfaceBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.InterfaceDeclaration(annotationList, kInterface, name, interfaceBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InterfaceDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitInterfaceDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInterfaceDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitInterfaceDeclaration(this);
	    }
	}
	
	public sealed class InterfaceBodySyntax : SoalSyntaxNode
	{
	    private SyntaxNode operationDeclaration;
	
	    public InterfaceBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InterfaceBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.InterfaceBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<OperationDeclarationSyntax> OperationDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.operationDeclaration, 1);
				if (red != null) return new SyntaxList<OperationDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.InterfaceBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.operationDeclaration, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.operationDeclaration;
				default: return null;
	        }
	    }
	
	    public InterfaceBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.OperationDeclaration, this.TCloseBrace);
		}
	
	    public InterfaceBodySyntax WithOperationDeclaration(SyntaxList<OperationDeclarationSyntax> operationDeclaration)
		{
			return this.Update(this.TOpenBrace, OperationDeclaration, this.TCloseBrace);
		}
	
	    public InterfaceBodySyntax AddOperationDeclaration(params OperationDeclarationSyntax[] operationDeclaration)
		{
			return this.WithOperationDeclaration(this.OperationDeclaration.AddRange(operationDeclaration));
		}
	
	    public InterfaceBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.OperationDeclaration, TCloseBrace);
		}
	
	    public InterfaceBodySyntax Update(SyntaxToken tOpenBrace, SyntaxList<OperationDeclarationSyntax> operationDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.OperationDeclaration != operationDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.InterfaceBody(tOpenBrace, operationDeclaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InterfaceBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitInterfaceBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInterfaceBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitInterfaceBody(this);
	    }
	}
	
	public sealed class OperationDeclarationSyntax : SoalSyntaxNode
	{
	    private OperationHeadSyntax operationHead;
	
	    public OperationDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public OperationHeadSyntax OperationHead 
		{ 
			get { return this.GetRed(ref this.operationHead, 0); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.operationHead, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.operationHead;
				default: return null;
	        }
	    }
	
	    public OperationDeclarationSyntax WithOperationHead(OperationHeadSyntax operationHead)
		{
			return this.Update(OperationHead, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.OperationHead, TSemicolon);
		}
	
	    public OperationDeclarationSyntax Update(OperationHeadSyntax operationHead, SyntaxToken tSemicolon)
	    {
	        if (this.OperationHead != operationHead ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.OperationDeclaration(operationHead, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOperationDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationDeclaration(this);
	    }
	}
	
	public sealed class OperationHeadSyntax : SoalSyntaxNode
	{
	    private AnnotationListSyntax annotationList;
	    private OperationResultSyntax operationResult;
	    private NameSyntax name;
	    private ParameterListSyntax parameterList;
	    private ThrowsListSyntax throwsList;
	
	    public OperationHeadSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationHeadSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnnotationListSyntax AnnotationList 
		{ 
			get { return this.GetRed(ref this.annotationList, 0); } 
		}
	    public OperationResultSyntax OperationResult 
		{ 
			get { return this.GetRed(ref this.operationResult, 1); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.OperationHeadGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public ParameterListSyntax ParameterList 
		{ 
			get { return this.GetRed(ref this.parameterList, 4); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.OperationHeadGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	    public ThrowsListSyntax ThrowsList 
		{ 
			get { return this.GetRed(ref this.throwsList, 6); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotationList, 0);
				case 1: return this.GetRed(ref this.operationResult, 1);
				case 2: return this.GetRed(ref this.name, 2);
				case 4: return this.GetRed(ref this.parameterList, 4);
				case 6: return this.GetRed(ref this.throwsList, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationList;
				case 1: return this.operationResult;
				case 2: return this.name;
				case 4: return this.parameterList;
				case 6: return this.throwsList;
				default: return null;
	        }
	    }
	
	    public OperationHeadSyntax WithAnnotationList(AnnotationListSyntax annotationList)
		{
			return this.Update(AnnotationList, this.OperationResult, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.ThrowsList);
		}
	
	    public OperationHeadSyntax WithOperationResult(OperationResultSyntax operationResult)
		{
			return this.Update(this.AnnotationList, OperationResult, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.ThrowsList);
		}
	
	    public OperationHeadSyntax WithName(NameSyntax name)
		{
			return this.Update(this.AnnotationList, this.OperationResult, Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.ThrowsList);
		}
	
	    public OperationHeadSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.AnnotationList, this.OperationResult, this.Name, TOpenParen, this.ParameterList, this.TCloseParen, this.ThrowsList);
		}
	
	    public OperationHeadSyntax WithParameterList(ParameterListSyntax parameterList)
		{
			return this.Update(this.AnnotationList, this.OperationResult, this.Name, this.TOpenParen, ParameterList, this.TCloseParen, this.ThrowsList);
		}
	
	    public OperationHeadSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.AnnotationList, this.OperationResult, this.Name, this.TOpenParen, this.ParameterList, TCloseParen, this.ThrowsList);
		}
	
	    public OperationHeadSyntax WithThrowsList(ThrowsListSyntax throwsList)
		{
			return this.Update(this.AnnotationList, this.OperationResult, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, ThrowsList);
		}
	
	    public OperationHeadSyntax Update(AnnotationListSyntax annotationList, OperationResultSyntax operationResult, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, ThrowsListSyntax throwsList)
	    {
	        if (this.AnnotationList != annotationList ||
				this.OperationResult != operationResult ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.ParameterList != parameterList ||
				this.TCloseParen != tCloseParen ||
				this.ThrowsList != throwsList)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.OperationHead(annotationList, operationResult, name, tOpenParen, parameterList, tCloseParen, throwsList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationHeadSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOperationHead(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationHead(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationHead(this);
	    }
	}
	
	public sealed class ParameterListSyntax : SoalSyntaxNode
	{
	    private SyntaxNode parameter;
	
	    public ParameterListSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParameterListSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<ParameterSyntax> Parameter 
		{ 
			get
			{
				var red = this.GetRed(ref this.parameter, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<ParameterSyntax>(red, this.GetChildIndex(0));
				}
				return default;
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
	
	    public ParameterListSyntax WithParameter(SeparatedSyntaxList<ParameterSyntax> parameter)
		{
			return this.Update(Parameter);
		}
	
	    public ParameterListSyntax AddParameter(params ParameterSyntax[] parameter)
		{
			return this.WithParameter(this.Parameter.AddRange(parameter));
		}
	
	    public ParameterListSyntax Update(SeparatedSyntaxList<ParameterSyntax> parameter)
	    {
	        if (this.Parameter != parameter)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ParameterList(parameter);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParameterList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParameterList(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitParameterList(this);
	    }
	}
	
	public sealed class ParameterSyntax : SoalSyntaxNode
	{
	    private AnnotationListSyntax annotationList;
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	
	    public ParameterSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParameterSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnnotationListSyntax AnnotationList 
		{ 
			get { return this.GetRed(ref this.annotationList, 0); } 
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
				case 0: return this.GetRed(ref this.annotationList, 0);
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 2: return this.GetRed(ref this.name, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotationList;
				case 1: return this.typeReference;
				case 2: return this.name;
				default: return null;
	        }
	    }
	
	    public ParameterSyntax WithAnnotationList(AnnotationListSyntax annotationList)
		{
			return this.Update(AnnotationList, this.TypeReference, this.Name);
		}
	
	    public ParameterSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.AnnotationList, TypeReference, this.Name);
		}
	
	    public ParameterSyntax WithName(NameSyntax name)
		{
			return this.Update(this.AnnotationList, this.TypeReference, Name);
		}
	
	    public ParameterSyntax Update(AnnotationListSyntax annotationList, TypeReferenceSyntax typeReference, NameSyntax name)
	    {
	        if (this.AnnotationList != annotationList ||
				this.TypeReference != typeReference ||
				this.Name != name)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Parameter(annotationList, typeReference, name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParameter(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParameter(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitParameter(this);
	    }
	}
	
	public sealed class OperationResultSyntax : SoalSyntaxNode
	{
	    private ReturnAnnotationListSyntax returnAnnotationList;
	    private OperationReturnTypeSyntax operationReturnType;
	
	    public OperationResultSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationResultSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ReturnAnnotationListSyntax ReturnAnnotationList 
		{ 
			get { return this.GetRed(ref this.returnAnnotationList, 0); } 
		}
	    public OperationReturnTypeSyntax OperationReturnType 
		{ 
			get { return this.GetRed(ref this.operationReturnType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.returnAnnotationList, 0);
				case 1: return this.GetRed(ref this.operationReturnType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.returnAnnotationList;
				case 1: return this.operationReturnType;
				default: return null;
	        }
	    }
	
	    public OperationResultSyntax WithReturnAnnotationList(ReturnAnnotationListSyntax returnAnnotationList)
		{
			return this.Update(ReturnAnnotationList, this.OperationReturnType);
		}
	
	    public OperationResultSyntax WithOperationReturnType(OperationReturnTypeSyntax operationReturnType)
		{
			return this.Update(this.ReturnAnnotationList, OperationReturnType);
		}
	
	    public OperationResultSyntax Update(ReturnAnnotationListSyntax returnAnnotationList, OperationReturnTypeSyntax operationReturnType)
	    {
	        if (this.ReturnAnnotationList != returnAnnotationList ||
				this.OperationReturnType != operationReturnType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.OperationResult(returnAnnotationList, operationReturnType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationResultSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOperationResult(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationResult(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationResult(this);
	    }
	}
	
	public sealed class ThrowsListSyntax : SoalSyntaxNode
	{
	    private QualifierListSyntax qualifierList;
	
	    public ThrowsListSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ThrowsListSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KThrows 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ThrowsListGreen)this.Green;
				var greenToken = green.KThrows;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierListSyntax QualifierList 
		{ 
			get { return this.GetRed(ref this.qualifierList, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifierList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifierList;
				default: return null;
	        }
	    }
	
	    public ThrowsListSyntax WithKThrows(SyntaxToken kThrows)
		{
			return this.Update(KThrows, this.QualifierList);
		}
	
	    public ThrowsListSyntax WithQualifierList(QualifierListSyntax qualifierList)
		{
			return this.Update(this.KThrows, QualifierList);
		}
	
	    public ThrowsListSyntax Update(SyntaxToken kThrows, QualifierListSyntax qualifierList)
	    {
	        if (this.KThrows != kThrows ||
				this.QualifierList != qualifierList)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ThrowsList(kThrows, qualifierList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ThrowsListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitThrowsList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitThrowsList(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitThrowsList(this);
	    }
	}
	
	public sealed class ComponentDeclarationSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	    private ComponentBaseSyntax componentBase;
	    private ComponentBodySyntax componentBody;
	
	    public ComponentDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KAbstract 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentDeclarationGreen)this.Green;
				var greenToken = green.KAbstract;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KComponent 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentDeclarationGreen)this.Green;
				var greenToken = green.KComponent;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public ComponentBaseSyntax ComponentBase 
		{ 
			get { return this.GetRed(ref this.componentBase, 4); } 
		}
	    public ComponentBodySyntax ComponentBody 
		{ 
			get { return this.GetRed(ref this.componentBody, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.name, 2);
				case 4: return this.GetRed(ref this.componentBase, 4);
				case 5: return this.GetRed(ref this.componentBody, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.name;
				case 4: return this.componentBase;
				case 5: return this.componentBody;
				default: return null;
	        }
	    }
	
	    public ComponentDeclarationSyntax WithKAbstract(SyntaxToken kAbstract)
		{
			return this.Update(KAbstract, this.KComponent, this.Name, this.TColon, this.ComponentBase, this.ComponentBody);
		}
	
	    public ComponentDeclarationSyntax WithKComponent(SyntaxToken kComponent)
		{
			return this.Update(this.KAbstract, KComponent, this.Name, this.TColon, this.ComponentBase, this.ComponentBody);
		}
	
	    public ComponentDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KAbstract, this.KComponent, Name, this.TColon, this.ComponentBase, this.ComponentBody);
		}
	
	    public ComponentDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KAbstract, this.KComponent, this.Name, TColon, this.ComponentBase, this.ComponentBody);
		}
	
	    public ComponentDeclarationSyntax WithComponentBase(ComponentBaseSyntax componentBase)
		{
			return this.Update(this.KAbstract, this.KComponent, this.Name, this.TColon, ComponentBase, this.ComponentBody);
		}
	
	    public ComponentDeclarationSyntax WithComponentBody(ComponentBodySyntax componentBody)
		{
			return this.Update(this.KAbstract, this.KComponent, this.Name, this.TColon, this.ComponentBase, ComponentBody);
		}
	
	    public ComponentDeclarationSyntax Update(SyntaxToken kAbstract, SyntaxToken kComponent, NameSyntax name, SyntaxToken tColon, ComponentBaseSyntax componentBase, ComponentBodySyntax componentBody)
	    {
	        if (this.KAbstract != kAbstract ||
				this.KComponent != kComponent ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ComponentBase != componentBase ||
				this.ComponentBody != componentBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentDeclaration(kAbstract, kComponent, name, tColon, componentBase, componentBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentDeclaration(this);
	    }
	}
	
	public sealed class ComponentBaseSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public ComponentBaseSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentBaseSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
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
	
	    public ComponentBaseSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public ComponentBaseSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentBase(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentBaseSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentBase(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentBase(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentBase(this);
	    }
	}
	
	public sealed class ComponentBodySyntax : SoalSyntaxNode
	{
	    private ComponentElementsSyntax componentElements;
	
	    public ComponentBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ComponentElementsSyntax ComponentElements 
		{ 
			get { return this.GetRed(ref this.componentElements, 1); } 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.componentElements, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.componentElements;
				default: return null;
	        }
	    }
	
	    public ComponentBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.ComponentElements, this.TCloseBrace);
		}
	
	    public ComponentBodySyntax WithComponentElements(ComponentElementsSyntax componentElements)
		{
			return this.Update(this.TOpenBrace, ComponentElements, this.TCloseBrace);
		}
	
	    public ComponentBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.ComponentElements, TCloseBrace);
		}
	
	    public ComponentBodySyntax Update(SyntaxToken tOpenBrace, ComponentElementsSyntax componentElements, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ComponentElements != componentElements ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentBody(tOpenBrace, componentElements, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentBody(this);
	    }
	}
	
	public sealed class ComponentElementsSyntax : SoalSyntaxNode
	{
	    private SyntaxNode componentElement;
	
	    public ComponentElementsSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentElementsSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<ComponentElementSyntax> ComponentElement 
		{ 
			get
			{
				var red = this.GetRed(ref this.componentElement, 0);
				if (red != null) return new SyntaxList<ComponentElementSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.componentElement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.componentElement;
				default: return null;
	        }
	    }
	
	    public ComponentElementsSyntax WithComponentElement(SyntaxList<ComponentElementSyntax> componentElement)
		{
			return this.Update(ComponentElement);
		}
	
	    public ComponentElementsSyntax AddComponentElement(params ComponentElementSyntax[] componentElement)
		{
			return this.WithComponentElement(this.ComponentElement.AddRange(componentElement));
		}
	
	    public ComponentElementsSyntax Update(SyntaxList<ComponentElementSyntax> componentElement)
	    {
	        if (this.ComponentElement != componentElement)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentElements(componentElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentElements(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentElements(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentElements(this);
	    }
	}
	
	public sealed class ComponentElementSyntax : SoalSyntaxNode
	{
	    private ComponentServiceSyntax componentService;
	    private ComponentReferenceSyntax componentReference;
	    private ComponentPropertySyntax componentProperty;
	    private ComponentImplementationSyntax componentImplementation;
	    private ComponentLanguageSyntax componentLanguage;
	
	    public ComponentElementSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentElementSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ComponentServiceSyntax ComponentService 
		{ 
			get { return this.GetRed(ref this.componentService, 0); } 
		}
	    public ComponentReferenceSyntax ComponentReference 
		{ 
			get { return this.GetRed(ref this.componentReference, 1); } 
		}
	    public ComponentPropertySyntax ComponentProperty 
		{ 
			get { return this.GetRed(ref this.componentProperty, 2); } 
		}
	    public ComponentImplementationSyntax ComponentImplementation 
		{ 
			get { return this.GetRed(ref this.componentImplementation, 3); } 
		}
	    public ComponentLanguageSyntax ComponentLanguage 
		{ 
			get { return this.GetRed(ref this.componentLanguage, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.componentService, 0);
				case 1: return this.GetRed(ref this.componentReference, 1);
				case 2: return this.GetRed(ref this.componentProperty, 2);
				case 3: return this.GetRed(ref this.componentImplementation, 3);
				case 4: return this.GetRed(ref this.componentLanguage, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.componentService;
				case 1: return this.componentReference;
				case 2: return this.componentProperty;
				case 3: return this.componentImplementation;
				case 4: return this.componentLanguage;
				default: return null;
	        }
	    }
	
	    public ComponentElementSyntax WithComponentService(ComponentServiceSyntax componentService)
		{
			return this.Update(componentService);
		}
	
	    public ComponentElementSyntax WithComponentReference(ComponentReferenceSyntax componentReference)
		{
			return this.Update(componentReference);
		}
	
	    public ComponentElementSyntax WithComponentProperty(ComponentPropertySyntax componentProperty)
		{
			return this.Update(componentProperty);
		}
	
	    public ComponentElementSyntax WithComponentImplementation(ComponentImplementationSyntax componentImplementation)
		{
			return this.Update(componentImplementation);
		}
	
	    public ComponentElementSyntax WithComponentLanguage(ComponentLanguageSyntax componentLanguage)
		{
			return this.Update(componentLanguage);
		}
	
	    public ComponentElementSyntax Update(ComponentServiceSyntax componentService)
	    {
	        if (this.ComponentService != componentService)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentElement(componentService);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ComponentElementSyntax Update(ComponentReferenceSyntax componentReference)
	    {
	        if (this.ComponentReference != componentReference)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentElement(componentReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ComponentElementSyntax Update(ComponentPropertySyntax componentProperty)
	    {
	        if (this.ComponentProperty != componentProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentElement(componentProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ComponentElementSyntax Update(ComponentImplementationSyntax componentImplementation)
	    {
	        if (this.ComponentImplementation != componentImplementation)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentElement(componentImplementation);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ComponentElementSyntax Update(ComponentLanguageSyntax componentLanguage)
	    {
	        if (this.ComponentLanguage != componentLanguage)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentElement(componentLanguage);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentElement(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentElement(this);
	    }
	}
	
	public sealed class ComponentServiceSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	    private NameSyntax name;
	    private ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody;
	
	    public ComponentServiceSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentServiceSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KService 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentServiceGreen)this.Green;
				var greenToken = green.KService;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public ComponentServiceOrReferenceBodySyntax ComponentServiceOrReferenceBody 
		{ 
			get { return this.GetRed(ref this.componentServiceOrReferenceBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				case 2: return this.GetRed(ref this.name, 2);
				case 3: return this.GetRed(ref this.componentServiceOrReferenceBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				case 2: return this.name;
				case 3: return this.componentServiceOrReferenceBody;
				default: return null;
	        }
	    }
	
	    public ComponentServiceSyntax WithKService(SyntaxToken kService)
		{
			return this.Update(KService, this.Qualifier, this.Name, this.ComponentServiceOrReferenceBody);
		}
	
	    public ComponentServiceSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KService, Qualifier, this.Name, this.ComponentServiceOrReferenceBody);
		}
	
	    public ComponentServiceSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KService, this.Qualifier, Name, this.ComponentServiceOrReferenceBody);
		}
	
	    public ComponentServiceSyntax WithComponentServiceOrReferenceBody(ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody)
		{
			return this.Update(this.KService, this.Qualifier, this.Name, ComponentServiceOrReferenceBody);
		}
	
	    public ComponentServiceSyntax Update(SyntaxToken kService, QualifierSyntax qualifier, NameSyntax name, ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody)
	    {
	        if (this.KService != kService ||
				this.Qualifier != qualifier ||
				this.Name != name ||
				this.ComponentServiceOrReferenceBody != componentServiceOrReferenceBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentService(kService, qualifier, name, componentServiceOrReferenceBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentServiceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentService(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentService(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentService(this);
	    }
	}
	
	public sealed class ComponentReferenceSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	    private NameSyntax name;
	    private ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody;
	
	    public ComponentReferenceSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentReferenceSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KReference 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentReferenceGreen)this.Green;
				var greenToken = green.KReference;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public ComponentServiceOrReferenceBodySyntax ComponentServiceOrReferenceBody 
		{ 
			get { return this.GetRed(ref this.componentServiceOrReferenceBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				case 2: return this.GetRed(ref this.name, 2);
				case 3: return this.GetRed(ref this.componentServiceOrReferenceBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				case 2: return this.name;
				case 3: return this.componentServiceOrReferenceBody;
				default: return null;
	        }
	    }
	
	    public ComponentReferenceSyntax WithKReference(SyntaxToken kReference)
		{
			return this.Update(KReference, this.Qualifier, this.Name, this.ComponentServiceOrReferenceBody);
		}
	
	    public ComponentReferenceSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KReference, Qualifier, this.Name, this.ComponentServiceOrReferenceBody);
		}
	
	    public ComponentReferenceSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KReference, this.Qualifier, Name, this.ComponentServiceOrReferenceBody);
		}
	
	    public ComponentReferenceSyntax WithComponentServiceOrReferenceBody(ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody)
		{
			return this.Update(this.KReference, this.Qualifier, this.Name, ComponentServiceOrReferenceBody);
		}
	
	    public ComponentReferenceSyntax Update(SyntaxToken kReference, QualifierSyntax qualifier, NameSyntax name, ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody)
	    {
	        if (this.KReference != kReference ||
				this.Qualifier != qualifier ||
				this.Name != name ||
				this.ComponentServiceOrReferenceBody != componentServiceOrReferenceBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentReference(kReference, qualifier, name, componentServiceOrReferenceBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentReference(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentReference(this);
	    }
	}
	
	public abstract class ComponentServiceOrReferenceBodySyntax : SoalSyntaxNode
	{
	    protected ComponentServiceOrReferenceBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected ComponentServiceOrReferenceBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class ComponentServiceOrReferenceEmptyBodySyntax : ComponentServiceOrReferenceBodySyntax
	{
	
	    public ComponentServiceOrReferenceEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentServiceOrReferenceEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentServiceOrReferenceEmptyBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public ComponentServiceOrReferenceEmptyBodySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(TSemicolon);
		}
	
	    public ComponentServiceOrReferenceEmptyBodySyntax Update(SyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentServiceOrReferenceEmptyBody(tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentServiceOrReferenceEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentServiceOrReferenceEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentServiceOrReferenceEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentServiceOrReferenceEmptyBody(this);
	    }
	}
	
	public sealed class ComponentServiceOrReferenceNonEmptyBodySyntax : ComponentServiceOrReferenceBodySyntax
	{
	    private SyntaxNode componentServiceOrReferenceElement;
	
	    public ComponentServiceOrReferenceNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentServiceOrReferenceNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentServiceOrReferenceNonEmptyBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<ComponentServiceOrReferenceElementSyntax> ComponentServiceOrReferenceElement 
		{ 
			get
			{
				var red = this.GetRed(ref this.componentServiceOrReferenceElement, 1);
				if (red != null) return new SyntaxList<ComponentServiceOrReferenceElementSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentServiceOrReferenceNonEmptyBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.componentServiceOrReferenceElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.componentServiceOrReferenceElement;
				default: return null;
	        }
	    }
	
	    public ComponentServiceOrReferenceNonEmptyBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.ComponentServiceOrReferenceElement, this.TCloseBrace);
		}
	
	    public ComponentServiceOrReferenceNonEmptyBodySyntax WithComponentServiceOrReferenceElement(SyntaxList<ComponentServiceOrReferenceElementSyntax> componentServiceOrReferenceElement)
		{
			return this.Update(this.TOpenBrace, ComponentServiceOrReferenceElement, this.TCloseBrace);
		}
	
	    public ComponentServiceOrReferenceNonEmptyBodySyntax AddComponentServiceOrReferenceElement(params ComponentServiceOrReferenceElementSyntax[] componentServiceOrReferenceElement)
		{
			return this.WithComponentServiceOrReferenceElement(this.ComponentServiceOrReferenceElement.AddRange(componentServiceOrReferenceElement));
		}
	
	    public ComponentServiceOrReferenceNonEmptyBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.ComponentServiceOrReferenceElement, TCloseBrace);
		}
	
	    public ComponentServiceOrReferenceNonEmptyBodySyntax Update(SyntaxToken tOpenBrace, SyntaxList<ComponentServiceOrReferenceElementSyntax> componentServiceOrReferenceElement, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ComponentServiceOrReferenceElement != componentServiceOrReferenceElement ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentServiceOrReferenceNonEmptyBody(tOpenBrace, componentServiceOrReferenceElement, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentServiceOrReferenceNonEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentServiceOrReferenceNonEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentServiceOrReferenceNonEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentServiceOrReferenceNonEmptyBody(this);
	    }
	}
	
	public sealed class ComponentServiceOrReferenceElementSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public ComponentServiceOrReferenceElementSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentServiceOrReferenceElementSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KBinding 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentServiceOrReferenceElementGreen)this.Green;
				var greenToken = green.KBinding;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentServiceOrReferenceElementGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public ComponentServiceOrReferenceElementSyntax WithKBinding(SyntaxToken kBinding)
		{
			return this.Update(KBinding, this.Qualifier, this.TSemicolon);
		}
	
	    public ComponentServiceOrReferenceElementSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KBinding, Qualifier, this.TSemicolon);
		}
	
	    public ComponentServiceOrReferenceElementSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KBinding, this.Qualifier, TSemicolon);
		}
	
	    public ComponentServiceOrReferenceElementSyntax Update(SyntaxToken kBinding, QualifierSyntax qualifier, SyntaxToken tSemicolon)
	    {
	        if (this.KBinding != kBinding ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentServiceOrReferenceElement(kBinding, qualifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentServiceOrReferenceElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentServiceOrReferenceElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentServiceOrReferenceElement(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentServiceOrReferenceElement(this);
	    }
	}
	
	public sealed class ComponentPropertySyntax : SoalSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	
	    public ComponentPropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentPropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentPropertyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				case 1: return this.GetRed(ref this.name, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				case 1: return this.name;
				default: return null;
	        }
	    }
	
	    public ComponentPropertySyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference, this.Name, this.TSemicolon);
		}
	
	    public ComponentPropertySyntax WithName(NameSyntax name)
		{
			return this.Update(this.TypeReference, Name, this.TSemicolon);
		}
	
	    public ComponentPropertySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.TypeReference, this.Name, TSemicolon);
		}
	
	    public ComponentPropertySyntax Update(TypeReferenceSyntax typeReference, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.TypeReference != typeReference ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentProperty(typeReference, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentProperty(this);
	    }
	}
	
	public sealed class ComponentImplementationSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	
	    public ComponentImplementationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentImplementationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KImplementation 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentImplementationGreen)this.Green;
				var greenToken = green.KImplementation;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentImplementationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
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
	
	    public ComponentImplementationSyntax WithKImplementation(SyntaxToken kImplementation)
		{
			return this.Update(KImplementation, this.Name, this.TSemicolon);
		}
	
	    public ComponentImplementationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KImplementation, Name, this.TSemicolon);
		}
	
	    public ComponentImplementationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KImplementation, this.Name, TSemicolon);
		}
	
	    public ComponentImplementationSyntax Update(SyntaxToken kImplementation, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KImplementation != kImplementation ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentImplementation(kImplementation, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentImplementationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentImplementation(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentImplementation(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentImplementation(this);
	    }
	}
	
	public sealed class ComponentLanguageSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	
	    public ComponentLanguageSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComponentLanguageSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KLanguage 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentLanguageGreen)this.Green;
				var greenToken = green.KLanguage;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ComponentLanguageGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
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
	
	    public ComponentLanguageSyntax WithKLanguage(SyntaxToken kLanguage)
		{
			return this.Update(KLanguage, this.Name, this.TSemicolon);
		}
	
	    public ComponentLanguageSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KLanguage, Name, this.TSemicolon);
		}
	
	    public ComponentLanguageSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KLanguage, this.Name, TSemicolon);
		}
	
	    public ComponentLanguageSyntax Update(SyntaxToken kLanguage, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KLanguage != kLanguage ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ComponentLanguage(kLanguage, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComponentLanguageSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComponentLanguage(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComponentLanguage(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitComponentLanguage(this);
	    }
	}
	
	public sealed class CompositeDeclarationSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	    private ComponentBaseSyntax componentBase;
	    private CompositeBodySyntax compositeBody;
	
	    public CompositeDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CompositeDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KComposite 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.CompositeDeclarationGreen)this.Green;
				var greenToken = green.KComposite;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.CompositeDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ComponentBaseSyntax ComponentBase 
		{ 
			get { return this.GetRed(ref this.componentBase, 3); } 
		}
	    public CompositeBodySyntax CompositeBody 
		{ 
			get { return this.GetRed(ref this.compositeBody, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.componentBase, 3);
				case 4: return this.GetRed(ref this.compositeBody, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.componentBase;
				case 4: return this.compositeBody;
				default: return null;
	        }
	    }
	
	    public CompositeDeclarationSyntax WithKComposite(SyntaxToken kComposite)
		{
			return this.Update(KComposite, this.Name, this.TColon, this.ComponentBase, this.CompositeBody);
		}
	
	    public CompositeDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KComposite, Name, this.TColon, this.ComponentBase, this.CompositeBody);
		}
	
	    public CompositeDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KComposite, this.Name, TColon, this.ComponentBase, this.CompositeBody);
		}
	
	    public CompositeDeclarationSyntax WithComponentBase(ComponentBaseSyntax componentBase)
		{
			return this.Update(this.KComposite, this.Name, this.TColon, ComponentBase, this.CompositeBody);
		}
	
	    public CompositeDeclarationSyntax WithCompositeBody(CompositeBodySyntax compositeBody)
		{
			return this.Update(this.KComposite, this.Name, this.TColon, this.ComponentBase, CompositeBody);
		}
	
	    public CompositeDeclarationSyntax Update(SyntaxToken kComposite, NameSyntax name, SyntaxToken tColon, ComponentBaseSyntax componentBase, CompositeBodySyntax compositeBody)
	    {
	        if (this.KComposite != kComposite ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ComponentBase != componentBase ||
				this.CompositeBody != compositeBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeDeclaration(kComposite, name, tColon, componentBase, compositeBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCompositeDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCompositeDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitCompositeDeclaration(this);
	    }
	}
	
	public sealed class CompositeBodySyntax : SoalSyntaxNode
	{
	    private CompositeElementsSyntax compositeElements;
	
	    public CompositeBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CompositeBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.CompositeBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public CompositeElementsSyntax CompositeElements 
		{ 
			get { return this.GetRed(ref this.compositeElements, 1); } 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.CompositeBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.compositeElements, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.compositeElements;
				default: return null;
	        }
	    }
	
	    public CompositeBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.CompositeElements, this.TCloseBrace);
		}
	
	    public CompositeBodySyntax WithCompositeElements(CompositeElementsSyntax compositeElements)
		{
			return this.Update(this.TOpenBrace, CompositeElements, this.TCloseBrace);
		}
	
	    public CompositeBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.CompositeElements, TCloseBrace);
		}
	
	    public CompositeBodySyntax Update(SyntaxToken tOpenBrace, CompositeElementsSyntax compositeElements, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.CompositeElements != compositeElements ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeBody(tOpenBrace, compositeElements, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCompositeBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCompositeBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitCompositeBody(this);
	    }
	}
	
	public sealed class AssemblyDeclarationSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	    private ComponentBaseSyntax componentBase;
	    private CompositeBodySyntax compositeBody;
	
	    public AssemblyDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssemblyDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KAssembly 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.AssemblyDeclarationGreen)this.Green;
				var greenToken = green.KAssembly;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.AssemblyDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ComponentBaseSyntax ComponentBase 
		{ 
			get { return this.GetRed(ref this.componentBase, 3); } 
		}
	    public CompositeBodySyntax CompositeBody 
		{ 
			get { return this.GetRed(ref this.compositeBody, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.componentBase, 3);
				case 4: return this.GetRed(ref this.compositeBody, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.componentBase;
				case 4: return this.compositeBody;
				default: return null;
	        }
	    }
	
	    public AssemblyDeclarationSyntax WithKAssembly(SyntaxToken kAssembly)
		{
			return this.Update(KAssembly, this.Name, this.TColon, this.ComponentBase, this.CompositeBody);
		}
	
	    public AssemblyDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KAssembly, Name, this.TColon, this.ComponentBase, this.CompositeBody);
		}
	
	    public AssemblyDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KAssembly, this.Name, TColon, this.ComponentBase, this.CompositeBody);
		}
	
	    public AssemblyDeclarationSyntax WithComponentBase(ComponentBaseSyntax componentBase)
		{
			return this.Update(this.KAssembly, this.Name, this.TColon, ComponentBase, this.CompositeBody);
		}
	
	    public AssemblyDeclarationSyntax WithCompositeBody(CompositeBodySyntax compositeBody)
		{
			return this.Update(this.KAssembly, this.Name, this.TColon, this.ComponentBase, CompositeBody);
		}
	
	    public AssemblyDeclarationSyntax Update(SyntaxToken kAssembly, NameSyntax name, SyntaxToken tColon, ComponentBaseSyntax componentBase, CompositeBodySyntax compositeBody)
	    {
	        if (this.KAssembly != kAssembly ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ComponentBase != componentBase ||
				this.CompositeBody != compositeBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.AssemblyDeclaration(kAssembly, name, tColon, componentBase, compositeBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssemblyDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAssemblyDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssemblyDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitAssemblyDeclaration(this);
	    }
	}
	
	public sealed class CompositeElementsSyntax : SoalSyntaxNode
	{
	    private SyntaxNode compositeElement;
	
	    public CompositeElementsSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CompositeElementsSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<CompositeElementSyntax> CompositeElement 
		{ 
			get
			{
				var red = this.GetRed(ref this.compositeElement, 0);
				if (red != null) return new SyntaxList<CompositeElementSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.compositeElement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.compositeElement;
				default: return null;
	        }
	    }
	
	    public CompositeElementsSyntax WithCompositeElement(SyntaxList<CompositeElementSyntax> compositeElement)
		{
			return this.Update(CompositeElement);
		}
	
	    public CompositeElementsSyntax AddCompositeElement(params CompositeElementSyntax[] compositeElement)
		{
			return this.WithCompositeElement(this.CompositeElement.AddRange(compositeElement));
		}
	
	    public CompositeElementsSyntax Update(SyntaxList<CompositeElementSyntax> compositeElement)
	    {
	        if (this.CompositeElement != compositeElement)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeElements(compositeElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCompositeElements(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCompositeElements(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitCompositeElements(this);
	    }
	}
	
	public sealed class CompositeElementSyntax : SoalSyntaxNode
	{
	    private ComponentServiceSyntax componentService;
	    private ComponentReferenceSyntax componentReference;
	    private ComponentPropertySyntax componentProperty;
	    private ComponentImplementationSyntax componentImplementation;
	    private ComponentLanguageSyntax componentLanguage;
	    private CompositeComponentSyntax compositeComponent;
	    private CompositeWireSyntax compositeWire;
	
	    public CompositeElementSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CompositeElementSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ComponentServiceSyntax ComponentService 
		{ 
			get { return this.GetRed(ref this.componentService, 0); } 
		}
	    public ComponentReferenceSyntax ComponentReference 
		{ 
			get { return this.GetRed(ref this.componentReference, 1); } 
		}
	    public ComponentPropertySyntax ComponentProperty 
		{ 
			get { return this.GetRed(ref this.componentProperty, 2); } 
		}
	    public ComponentImplementationSyntax ComponentImplementation 
		{ 
			get { return this.GetRed(ref this.componentImplementation, 3); } 
		}
	    public ComponentLanguageSyntax ComponentLanguage 
		{ 
			get { return this.GetRed(ref this.componentLanguage, 4); } 
		}
	    public CompositeComponentSyntax CompositeComponent 
		{ 
			get { return this.GetRed(ref this.compositeComponent, 5); } 
		}
	    public CompositeWireSyntax CompositeWire 
		{ 
			get { return this.GetRed(ref this.compositeWire, 6); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.componentService, 0);
				case 1: return this.GetRed(ref this.componentReference, 1);
				case 2: return this.GetRed(ref this.componentProperty, 2);
				case 3: return this.GetRed(ref this.componentImplementation, 3);
				case 4: return this.GetRed(ref this.componentLanguage, 4);
				case 5: return this.GetRed(ref this.compositeComponent, 5);
				case 6: return this.GetRed(ref this.compositeWire, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.componentService;
				case 1: return this.componentReference;
				case 2: return this.componentProperty;
				case 3: return this.componentImplementation;
				case 4: return this.componentLanguage;
				case 5: return this.compositeComponent;
				case 6: return this.compositeWire;
				default: return null;
	        }
	    }
	
	    public CompositeElementSyntax WithComponentService(ComponentServiceSyntax componentService)
		{
			return this.Update(componentService);
		}
	
	    public CompositeElementSyntax WithComponentReference(ComponentReferenceSyntax componentReference)
		{
			return this.Update(componentReference);
		}
	
	    public CompositeElementSyntax WithComponentProperty(ComponentPropertySyntax componentProperty)
		{
			return this.Update(componentProperty);
		}
	
	    public CompositeElementSyntax WithComponentImplementation(ComponentImplementationSyntax componentImplementation)
		{
			return this.Update(componentImplementation);
		}
	
	    public CompositeElementSyntax WithComponentLanguage(ComponentLanguageSyntax componentLanguage)
		{
			return this.Update(componentLanguage);
		}
	
	    public CompositeElementSyntax WithCompositeComponent(CompositeComponentSyntax compositeComponent)
		{
			return this.Update(compositeComponent);
		}
	
	    public CompositeElementSyntax WithCompositeWire(CompositeWireSyntax compositeWire)
		{
			return this.Update(compositeWire);
		}
	
	    public CompositeElementSyntax Update(ComponentServiceSyntax componentService)
	    {
	        if (this.ComponentService != componentService)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeElement(componentService);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementSyntax Update(ComponentReferenceSyntax componentReference)
	    {
	        if (this.ComponentReference != componentReference)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeElement(componentReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementSyntax Update(ComponentPropertySyntax componentProperty)
	    {
	        if (this.ComponentProperty != componentProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeElement(componentProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementSyntax Update(ComponentImplementationSyntax componentImplementation)
	    {
	        if (this.ComponentImplementation != componentImplementation)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeElement(componentImplementation);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementSyntax Update(ComponentLanguageSyntax componentLanguage)
	    {
	        if (this.ComponentLanguage != componentLanguage)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeElement(componentLanguage);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementSyntax Update(CompositeComponentSyntax compositeComponent)
	    {
	        if (this.CompositeComponent != compositeComponent)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeElement(compositeComponent);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public CompositeElementSyntax Update(CompositeWireSyntax compositeWire)
	    {
	        if (this.CompositeWire != compositeWire)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeElement(compositeWire);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCompositeElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCompositeElement(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitCompositeElement(this);
	    }
	}
	
	public sealed class CompositeComponentSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public CompositeComponentSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CompositeComponentSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KComponent 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.CompositeComponentGreen)this.Green;
				var greenToken = green.KComponent;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.CompositeComponentGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public CompositeComponentSyntax WithKComponent(SyntaxToken kComponent)
		{
			return this.Update(KComponent, this.Qualifier, this.TSemicolon);
		}
	
	    public CompositeComponentSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KComponent, Qualifier, this.TSemicolon);
		}
	
	    public CompositeComponentSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KComponent, this.Qualifier, TSemicolon);
		}
	
	    public CompositeComponentSyntax Update(SyntaxToken kComponent, QualifierSyntax qualifier, SyntaxToken tSemicolon)
	    {
	        if (this.KComponent != kComponent ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeComponent(kComponent, qualifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeComponentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCompositeComponent(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCompositeComponent(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitCompositeComponent(this);
	    }
	}
	
	public sealed class CompositeWireSyntax : SoalSyntaxNode
	{
	    private WireSourceSyntax wireSource;
	    private WireTargetSyntax wireTarget;
	
	    public CompositeWireSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CompositeWireSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KWire 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.CompositeWireGreen)this.Green;
				var greenToken = green.KWire;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public WireSourceSyntax WireSource 
		{ 
			get { return this.GetRed(ref this.wireSource, 1); } 
		}
	    public SyntaxToken KTo 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.CompositeWireGreen)this.Green;
				var greenToken = green.KTo;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public WireTargetSyntax WireTarget 
		{ 
			get { return this.GetRed(ref this.wireTarget, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.CompositeWireGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.wireSource, 1);
				case 3: return this.GetRed(ref this.wireTarget, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.wireSource;
				case 3: return this.wireTarget;
				default: return null;
	        }
	    }
	
	    public CompositeWireSyntax WithKWire(SyntaxToken kWire)
		{
			return this.Update(KWire, this.WireSource, this.KTo, this.WireTarget, this.TSemicolon);
		}
	
	    public CompositeWireSyntax WithWireSource(WireSourceSyntax wireSource)
		{
			return this.Update(this.KWire, WireSource, this.KTo, this.WireTarget, this.TSemicolon);
		}
	
	    public CompositeWireSyntax WithKTo(SyntaxToken kTo)
		{
			return this.Update(this.KWire, this.WireSource, KTo, this.WireTarget, this.TSemicolon);
		}
	
	    public CompositeWireSyntax WithWireTarget(WireTargetSyntax wireTarget)
		{
			return this.Update(this.KWire, this.WireSource, this.KTo, WireTarget, this.TSemicolon);
		}
	
	    public CompositeWireSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KWire, this.WireSource, this.KTo, this.WireTarget, TSemicolon);
		}
	
	    public CompositeWireSyntax Update(SyntaxToken kWire, WireSourceSyntax wireSource, SyntaxToken kTo, WireTargetSyntax wireTarget, SyntaxToken tSemicolon)
	    {
	        if (this.KWire != kWire ||
				this.WireSource != wireSource ||
				this.KTo != kTo ||
				this.WireTarget != wireTarget ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.CompositeWire(kWire, wireSource, kTo, wireTarget, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompositeWireSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCompositeWire(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCompositeWire(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitCompositeWire(this);
	    }
	}
	
	public sealed class WireSourceSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public WireSourceSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WireSourceSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
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
	
	    public WireSourceSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public WireSourceSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.WireSource(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WireSourceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWireSource(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWireSource(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitWireSource(this);
	    }
	}
	
	public sealed class WireTargetSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public WireTargetSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WireTargetSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
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
	
	    public WireTargetSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public WireTargetSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.WireTarget(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WireTargetSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWireTarget(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWireTarget(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitWireTarget(this);
	    }
	}
	
	public sealed class DeploymentDeclarationSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	    private DeploymentBodySyntax deploymentBody;
	
	    public DeploymentDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeploymentDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KDeployment 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.DeploymentDeclarationGreen)this.Green;
				var greenToken = green.KDeployment;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public DeploymentBodySyntax DeploymentBody 
		{ 
			get { return this.GetRed(ref this.deploymentBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 2: return this.GetRed(ref this.deploymentBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 2: return this.deploymentBody;
				default: return null;
	        }
	    }
	
	    public DeploymentDeclarationSyntax WithKDeployment(SyntaxToken kDeployment)
		{
			return this.Update(KDeployment, this.Name, this.DeploymentBody);
		}
	
	    public DeploymentDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KDeployment, Name, this.DeploymentBody);
		}
	
	    public DeploymentDeclarationSyntax WithDeploymentBody(DeploymentBodySyntax deploymentBody)
		{
			return this.Update(this.KDeployment, this.Name, DeploymentBody);
		}
	
	    public DeploymentDeclarationSyntax Update(SyntaxToken kDeployment, NameSyntax name, DeploymentBodySyntax deploymentBody)
	    {
	        if (this.KDeployment != kDeployment ||
				this.Name != name ||
				this.DeploymentBody != deploymentBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.DeploymentDeclaration(kDeployment, name, deploymentBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeploymentDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeploymentDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitDeploymentDeclaration(this);
	    }
	}
	
	public sealed class DeploymentBodySyntax : SoalSyntaxNode
	{
	    private DeploymentElementsSyntax deploymentElements;
	
	    public DeploymentBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeploymentBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.DeploymentBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public DeploymentElementsSyntax DeploymentElements 
		{ 
			get { return this.GetRed(ref this.deploymentElements, 1); } 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.DeploymentBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.deploymentElements, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.deploymentElements;
				default: return null;
	        }
	    }
	
	    public DeploymentBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.DeploymentElements, this.TCloseBrace);
		}
	
	    public DeploymentBodySyntax WithDeploymentElements(DeploymentElementsSyntax deploymentElements)
		{
			return this.Update(this.TOpenBrace, DeploymentElements, this.TCloseBrace);
		}
	
	    public DeploymentBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.DeploymentElements, TCloseBrace);
		}
	
	    public DeploymentBodySyntax Update(SyntaxToken tOpenBrace, DeploymentElementsSyntax deploymentElements, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.DeploymentElements != deploymentElements ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.DeploymentBody(tOpenBrace, deploymentElements, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeploymentBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeploymentBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitDeploymentBody(this);
	    }
	}
	
	public sealed class DeploymentElementsSyntax : SoalSyntaxNode
	{
	    private SyntaxNode deploymentElement;
	
	    public DeploymentElementsSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeploymentElementsSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<DeploymentElementSyntax> DeploymentElement 
		{ 
			get
			{
				var red = this.GetRed(ref this.deploymentElement, 0);
				if (red != null) return new SyntaxList<DeploymentElementSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.deploymentElement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.deploymentElement;
				default: return null;
	        }
	    }
	
	    public DeploymentElementsSyntax WithDeploymentElement(SyntaxList<DeploymentElementSyntax> deploymentElement)
		{
			return this.Update(DeploymentElement);
		}
	
	    public DeploymentElementsSyntax AddDeploymentElement(params DeploymentElementSyntax[] deploymentElement)
		{
			return this.WithDeploymentElement(this.DeploymentElement.AddRange(deploymentElement));
		}
	
	    public DeploymentElementsSyntax Update(SyntaxList<DeploymentElementSyntax> deploymentElement)
	    {
	        if (this.DeploymentElement != deploymentElement)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.DeploymentElements(deploymentElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentElementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeploymentElements(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeploymentElements(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitDeploymentElements(this);
	    }
	}
	
	public sealed class DeploymentElementSyntax : SoalSyntaxNode
	{
	    private EnvironmentDeclarationSyntax environmentDeclaration;
	    private CompositeWireSyntax compositeWire;
	
	    public DeploymentElementSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeploymentElementSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public EnvironmentDeclarationSyntax EnvironmentDeclaration 
		{ 
			get { return this.GetRed(ref this.environmentDeclaration, 0); } 
		}
	    public CompositeWireSyntax CompositeWire 
		{ 
			get { return this.GetRed(ref this.compositeWire, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.environmentDeclaration, 0);
				case 1: return this.GetRed(ref this.compositeWire, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.environmentDeclaration;
				case 1: return this.compositeWire;
				default: return null;
	        }
	    }
	
	    public DeploymentElementSyntax WithEnvironmentDeclaration(EnvironmentDeclarationSyntax environmentDeclaration)
		{
			return this.Update(environmentDeclaration);
		}
	
	    public DeploymentElementSyntax WithCompositeWire(CompositeWireSyntax compositeWire)
		{
			return this.Update(compositeWire);
		}
	
	    public DeploymentElementSyntax Update(EnvironmentDeclarationSyntax environmentDeclaration)
	    {
	        if (this.EnvironmentDeclaration != environmentDeclaration)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.DeploymentElement(environmentDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeploymentElementSyntax Update(CompositeWireSyntax compositeWire)
	    {
	        if (this.CompositeWire != compositeWire)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.DeploymentElement(compositeWire);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeploymentElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeploymentElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeploymentElement(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitDeploymentElement(this);
	    }
	}
	
	public sealed class EnvironmentDeclarationSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	    private EnvironmentBodySyntax environmentBody;
	
	    public EnvironmentDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnvironmentDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEnvironment 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EnvironmentDeclarationGreen)this.Green;
				var greenToken = green.KEnvironment;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public EnvironmentBodySyntax EnvironmentBody 
		{ 
			get { return this.GetRed(ref this.environmentBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 2: return this.GetRed(ref this.environmentBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 2: return this.environmentBody;
				default: return null;
	        }
	    }
	
	    public EnvironmentDeclarationSyntax WithKEnvironment(SyntaxToken kEnvironment)
		{
			return this.Update(KEnvironment, this.Name, this.EnvironmentBody);
		}
	
	    public EnvironmentDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KEnvironment, Name, this.EnvironmentBody);
		}
	
	    public EnvironmentDeclarationSyntax WithEnvironmentBody(EnvironmentBodySyntax environmentBody)
		{
			return this.Update(this.KEnvironment, this.Name, EnvironmentBody);
		}
	
	    public EnvironmentDeclarationSyntax Update(SyntaxToken kEnvironment, NameSyntax name, EnvironmentBodySyntax environmentBody)
	    {
	        if (this.KEnvironment != kEnvironment ||
				this.Name != name ||
				this.EnvironmentBody != environmentBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EnvironmentDeclaration(kEnvironment, name, environmentBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnvironmentDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnvironmentDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnvironmentDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEnvironmentDeclaration(this);
	    }
	}
	
	public sealed class EnvironmentBodySyntax : SoalSyntaxNode
	{
	    private RuntimeDeclarationSyntax runtimeDeclaration;
	    private SyntaxNode runtimeReference;
	
	    public EnvironmentBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnvironmentBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EnvironmentBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public RuntimeDeclarationSyntax RuntimeDeclaration 
		{ 
			get { return this.GetRed(ref this.runtimeDeclaration, 1); } 
		}
	    public SyntaxList<RuntimeReferenceSyntax> RuntimeReference 
		{ 
			get
			{
				var red = this.GetRed(ref this.runtimeReference, 2);
				if (red != null) return new SyntaxList<RuntimeReferenceSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EnvironmentBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.runtimeDeclaration, 1);
				case 2: return this.GetRed(ref this.runtimeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.runtimeDeclaration;
				case 2: return this.runtimeReference;
				default: return null;
	        }
	    }
	
	    public EnvironmentBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.RuntimeDeclaration, this.RuntimeReference, this.TCloseBrace);
		}
	
	    public EnvironmentBodySyntax WithRuntimeDeclaration(RuntimeDeclarationSyntax runtimeDeclaration)
		{
			return this.Update(this.TOpenBrace, RuntimeDeclaration, this.RuntimeReference, this.TCloseBrace);
		}
	
	    public EnvironmentBodySyntax WithRuntimeReference(SyntaxList<RuntimeReferenceSyntax> runtimeReference)
		{
			return this.Update(this.TOpenBrace, this.RuntimeDeclaration, RuntimeReference, this.TCloseBrace);
		}
	
	    public EnvironmentBodySyntax AddRuntimeReference(params RuntimeReferenceSyntax[] runtimeReference)
		{
			return this.WithRuntimeReference(this.RuntimeReference.AddRange(runtimeReference));
		}
	
	    public EnvironmentBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.RuntimeDeclaration, this.RuntimeReference, TCloseBrace);
		}
	
	    public EnvironmentBodySyntax Update(SyntaxToken tOpenBrace, RuntimeDeclarationSyntax runtimeDeclaration, SyntaxList<RuntimeReferenceSyntax> runtimeReference, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.RuntimeDeclaration != runtimeDeclaration ||
				this.RuntimeReference != runtimeReference ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EnvironmentBody(tOpenBrace, runtimeDeclaration, runtimeReference, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnvironmentBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnvironmentBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnvironmentBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEnvironmentBody(this);
	    }
	}
	
	public sealed class RuntimeDeclarationSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	
	    public RuntimeDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RuntimeDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KRuntime 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.RuntimeDeclarationGreen)this.Green;
				var greenToken = green.KRuntime;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.RuntimeDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
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
	
	    public RuntimeDeclarationSyntax WithKRuntime(SyntaxToken kRuntime)
		{
			return this.Update(KRuntime, this.Name, this.TSemicolon);
		}
	
	    public RuntimeDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KRuntime, Name, this.TSemicolon);
		}
	
	    public RuntimeDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KRuntime, this.Name, TSemicolon);
		}
	
	    public RuntimeDeclarationSyntax Update(SyntaxToken kRuntime, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KRuntime != kRuntime ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.RuntimeDeclaration(kRuntime, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuntimeDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRuntimeDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRuntimeDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitRuntimeDeclaration(this);
	    }
	}
	
	public sealed class RuntimeReferenceSyntax : SoalSyntaxNode
	{
	    private AssemblyReferenceSyntax assemblyReference;
	    private DatabaseReferenceSyntax databaseReference;
	
	    public RuntimeReferenceSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RuntimeReferenceSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AssemblyReferenceSyntax AssemblyReference 
		{ 
			get { return this.GetRed(ref this.assemblyReference, 0); } 
		}
	    public DatabaseReferenceSyntax DatabaseReference 
		{ 
			get { return this.GetRed(ref this.databaseReference, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.assemblyReference, 0);
				case 1: return this.GetRed(ref this.databaseReference, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.assemblyReference;
				case 1: return this.databaseReference;
				default: return null;
	        }
	    }
	
	    public RuntimeReferenceSyntax WithAssemblyReference(AssemblyReferenceSyntax assemblyReference)
		{
			return this.Update(assemblyReference);
		}
	
	    public RuntimeReferenceSyntax WithDatabaseReference(DatabaseReferenceSyntax databaseReference)
		{
			return this.Update(databaseReference);
		}
	
	    public RuntimeReferenceSyntax Update(AssemblyReferenceSyntax assemblyReference)
	    {
	        if (this.AssemblyReference != assemblyReference)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.RuntimeReference(assemblyReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuntimeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public RuntimeReferenceSyntax Update(DatabaseReferenceSyntax databaseReference)
	    {
	        if (this.DatabaseReference != databaseReference)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.RuntimeReference(databaseReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuntimeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRuntimeReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRuntimeReference(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitRuntimeReference(this);
	    }
	}
	
	public sealed class AssemblyReferenceSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public AssemblyReferenceSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssemblyReferenceSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KAssembly 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.AssemblyReferenceGreen)this.Green;
				var greenToken = green.KAssembly;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.AssemblyReferenceGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public AssemblyReferenceSyntax WithKAssembly(SyntaxToken kAssembly)
		{
			return this.Update(KAssembly, this.Qualifier, this.TSemicolon);
		}
	
	    public AssemblyReferenceSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KAssembly, Qualifier, this.TSemicolon);
		}
	
	    public AssemblyReferenceSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KAssembly, this.Qualifier, TSemicolon);
		}
	
	    public AssemblyReferenceSyntax Update(SyntaxToken kAssembly, QualifierSyntax qualifier, SyntaxToken tSemicolon)
	    {
	        if (this.KAssembly != kAssembly ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.AssemblyReference(kAssembly, qualifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssemblyReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAssemblyReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssemblyReference(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitAssemblyReference(this);
	    }
	}
	
	public sealed class DatabaseReferenceSyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public DatabaseReferenceSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DatabaseReferenceSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KDatabase 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.DatabaseReferenceGreen)this.Green;
				var greenToken = green.KDatabase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.DatabaseReferenceGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public DatabaseReferenceSyntax WithKDatabase(SyntaxToken kDatabase)
		{
			return this.Update(KDatabase, this.Qualifier, this.TSemicolon);
		}
	
	    public DatabaseReferenceSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KDatabase, Qualifier, this.TSemicolon);
		}
	
	    public DatabaseReferenceSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KDatabase, this.Qualifier, TSemicolon);
		}
	
	    public DatabaseReferenceSyntax Update(SyntaxToken kDatabase, QualifierSyntax qualifier, SyntaxToken tSemicolon)
	    {
	        if (this.KDatabase != kDatabase ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.DatabaseReference(kDatabase, qualifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DatabaseReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDatabaseReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDatabaseReference(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitDatabaseReference(this);
	    }
	}
	
	public sealed class BindingDeclarationSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	    private BindingBodySyntax bindingBody;
	
	    public BindingDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BindingDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KBinding 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.BindingDeclarationGreen)this.Green;
				var greenToken = green.KBinding;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public BindingBodySyntax BindingBody 
		{ 
			get { return this.GetRed(ref this.bindingBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 2: return this.GetRed(ref this.bindingBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 2: return this.bindingBody;
				default: return null;
	        }
	    }
	
	    public BindingDeclarationSyntax WithKBinding(SyntaxToken kBinding)
		{
			return this.Update(KBinding, this.Name, this.BindingBody);
		}
	
	    public BindingDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KBinding, Name, this.BindingBody);
		}
	
	    public BindingDeclarationSyntax WithBindingBody(BindingBodySyntax bindingBody)
		{
			return this.Update(this.KBinding, this.Name, BindingBody);
		}
	
	    public BindingDeclarationSyntax Update(SyntaxToken kBinding, NameSyntax name, BindingBodySyntax bindingBody)
	    {
	        if (this.KBinding != kBinding ||
				this.Name != name ||
				this.BindingBody != bindingBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.BindingDeclaration(kBinding, name, bindingBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BindingDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBindingDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBindingDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitBindingDeclaration(this);
	    }
	}
	
	public sealed class BindingBodySyntax : SoalSyntaxNode
	{
	    private BindingLayersSyntax bindingLayers;
	
	    public BindingBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BindingBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.BindingBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public BindingLayersSyntax BindingLayers 
		{ 
			get { return this.GetRed(ref this.bindingLayers, 1); } 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.BindingBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.bindingLayers, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.bindingLayers;
				default: return null;
	        }
	    }
	
	    public BindingBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.BindingLayers, this.TCloseBrace);
		}
	
	    public BindingBodySyntax WithBindingLayers(BindingLayersSyntax bindingLayers)
		{
			return this.Update(this.TOpenBrace, BindingLayers, this.TCloseBrace);
		}
	
	    public BindingBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.BindingLayers, TCloseBrace);
		}
	
	    public BindingBodySyntax Update(SyntaxToken tOpenBrace, BindingLayersSyntax bindingLayers, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.BindingLayers != bindingLayers ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.BindingBody(tOpenBrace, bindingLayers, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BindingBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBindingBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBindingBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitBindingBody(this);
	    }
	}
	
	public sealed class BindingLayersSyntax : SoalSyntaxNode
	{
	    private TransportLayerSyntax transportLayer;
	    private SyntaxNode encodingLayer;
	    private SyntaxNode protocolLayer;
	
	    public BindingLayersSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BindingLayersSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TransportLayerSyntax TransportLayer 
		{ 
			get { return this.GetRed(ref this.transportLayer, 0); } 
		}
	    public SyntaxList<EncodingLayerSyntax> EncodingLayer 
		{ 
			get
			{
				var red = this.GetRed(ref this.encodingLayer, 1);
				if (red != null) return new SyntaxList<EncodingLayerSyntax>(red);
				return default;
			} 
		}
	    public SyntaxList<ProtocolLayerSyntax> ProtocolLayer 
		{ 
			get
			{
				var red = this.GetRed(ref this.protocolLayer, 2);
				if (red != null) return new SyntaxList<ProtocolLayerSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.transportLayer, 0);
				case 1: return this.GetRed(ref this.encodingLayer, 1);
				case 2: return this.GetRed(ref this.protocolLayer, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.transportLayer;
				case 1: return this.encodingLayer;
				case 2: return this.protocolLayer;
				default: return null;
	        }
	    }
	
	    public BindingLayersSyntax WithTransportLayer(TransportLayerSyntax transportLayer)
		{
			return this.Update(TransportLayer, this.EncodingLayer, this.ProtocolLayer);
		}
	
	    public BindingLayersSyntax WithEncodingLayer(SyntaxList<EncodingLayerSyntax> encodingLayer)
		{
			return this.Update(this.TransportLayer, EncodingLayer, this.ProtocolLayer);
		}
	
	    public BindingLayersSyntax AddEncodingLayer(params EncodingLayerSyntax[] encodingLayer)
		{
			return this.WithEncodingLayer(this.EncodingLayer.AddRange(encodingLayer));
		}
	
	    public BindingLayersSyntax WithProtocolLayer(SyntaxList<ProtocolLayerSyntax> protocolLayer)
		{
			return this.Update(this.TransportLayer, this.EncodingLayer, ProtocolLayer);
		}
	
	    public BindingLayersSyntax AddProtocolLayer(params ProtocolLayerSyntax[] protocolLayer)
		{
			return this.WithProtocolLayer(this.ProtocolLayer.AddRange(protocolLayer));
		}
	
	    public BindingLayersSyntax Update(TransportLayerSyntax transportLayer, SyntaxList<EncodingLayerSyntax> encodingLayer, SyntaxList<ProtocolLayerSyntax> protocolLayer)
	    {
	        if (this.TransportLayer != transportLayer ||
				this.EncodingLayer != encodingLayer ||
				this.ProtocolLayer != protocolLayer)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.BindingLayers(transportLayer, encodingLayer, protocolLayer);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BindingLayersSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBindingLayers(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBindingLayers(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitBindingLayers(this);
	    }
	}
	
	public sealed class TransportLayerSyntax : SoalSyntaxNode
	{
	    private HttpTransportLayerSyntax httpTransportLayer;
	    private RestTransportLayerSyntax restTransportLayer;
	    private WebSocketTransportLayerSyntax webSocketTransportLayer;
	
	    public TransportLayerSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TransportLayerSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HttpTransportLayerSyntax HttpTransportLayer 
		{ 
			get { return this.GetRed(ref this.httpTransportLayer, 0); } 
		}
	    public RestTransportLayerSyntax RestTransportLayer 
		{ 
			get { return this.GetRed(ref this.restTransportLayer, 1); } 
		}
	    public WebSocketTransportLayerSyntax WebSocketTransportLayer 
		{ 
			get { return this.GetRed(ref this.webSocketTransportLayer, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.httpTransportLayer, 0);
				case 1: return this.GetRed(ref this.restTransportLayer, 1);
				case 2: return this.GetRed(ref this.webSocketTransportLayer, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.httpTransportLayer;
				case 1: return this.restTransportLayer;
				case 2: return this.webSocketTransportLayer;
				default: return null;
	        }
	    }
	
	    public TransportLayerSyntax WithHttpTransportLayer(HttpTransportLayerSyntax httpTransportLayer)
		{
			return this.Update(httpTransportLayer);
		}
	
	    public TransportLayerSyntax WithRestTransportLayer(RestTransportLayerSyntax restTransportLayer)
		{
			return this.Update(restTransportLayer);
		}
	
	    public TransportLayerSyntax WithWebSocketTransportLayer(WebSocketTransportLayerSyntax webSocketTransportLayer)
		{
			return this.Update(webSocketTransportLayer);
		}
	
	    public TransportLayerSyntax Update(HttpTransportLayerSyntax httpTransportLayer)
	    {
	        if (this.HttpTransportLayer != httpTransportLayer)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.TransportLayer(httpTransportLayer);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TransportLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TransportLayerSyntax Update(RestTransportLayerSyntax restTransportLayer)
	    {
	        if (this.RestTransportLayer != restTransportLayer)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.TransportLayer(restTransportLayer);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TransportLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TransportLayerSyntax Update(WebSocketTransportLayerSyntax webSocketTransportLayer)
	    {
	        if (this.WebSocketTransportLayer != webSocketTransportLayer)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.TransportLayer(webSocketTransportLayer);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TransportLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTransportLayer(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTransportLayer(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitTransportLayer(this);
	    }
	}
	
	public sealed class HttpTransportLayerSyntax : SoalSyntaxNode
	{
	    private HttpTransportLayerBodySyntax httpTransportLayerBody;
	
	    public HttpTransportLayerSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HttpTransportLayerSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTransport 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpTransportLayerGreen)this.Green;
				var greenToken = green.KTransport;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken IHTTP 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpTransportLayerGreen)this.Green;
				var greenToken = green.IHTTP;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public HttpTransportLayerBodySyntax HttpTransportLayerBody 
		{ 
			get { return this.GetRed(ref this.httpTransportLayerBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.httpTransportLayerBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.httpTransportLayerBody;
				default: return null;
	        }
	    }
	
	    public HttpTransportLayerSyntax WithKTransport(SyntaxToken kTransport)
		{
			return this.Update(KTransport, this.IHTTP, this.HttpTransportLayerBody);
		}
	
	    public HttpTransportLayerSyntax WithIHTTP(SyntaxToken ihttp)
		{
			return this.Update(this.KTransport, IHTTP, this.HttpTransportLayerBody);
		}
	
	    public HttpTransportLayerSyntax WithHttpTransportLayerBody(HttpTransportLayerBodySyntax httpTransportLayerBody)
		{
			return this.Update(this.KTransport, this.IHTTP, HttpTransportLayerBody);
		}
	
	    public HttpTransportLayerSyntax Update(SyntaxToken kTransport, SyntaxToken ihttp, HttpTransportLayerBodySyntax httpTransportLayerBody)
	    {
	        if (this.KTransport != kTransport ||
				this.IHTTP != ihttp ||
				this.HttpTransportLayerBody != httpTransportLayerBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.HttpTransportLayer(kTransport, ihttp, httpTransportLayerBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitHttpTransportLayer(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHttpTransportLayer(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitHttpTransportLayer(this);
	    }
	}
	
	public abstract class HttpTransportLayerBodySyntax : SoalSyntaxNode
	{
	    protected HttpTransportLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected HttpTransportLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class HttpTransportLayerEmptyBodySyntax : HttpTransportLayerBodySyntax
	{
	
	    public HttpTransportLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HttpTransportLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpTransportLayerEmptyBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public HttpTransportLayerEmptyBodySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(TSemicolon);
		}
	
	    public HttpTransportLayerEmptyBodySyntax Update(SyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.HttpTransportLayerEmptyBody(tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitHttpTransportLayerEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHttpTransportLayerEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitHttpTransportLayerEmptyBody(this);
	    }
	}
	
	public sealed class HttpTransportLayerNonEmptyBodySyntax : HttpTransportLayerBodySyntax
	{
	    private SyntaxNode httpTransportLayerProperties;
	
	    public HttpTransportLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HttpTransportLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpTransportLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<HttpTransportLayerPropertiesSyntax> HttpTransportLayerProperties 
		{ 
			get
			{
				var red = this.GetRed(ref this.httpTransportLayerProperties, 1);
				if (red != null) return new SyntaxList<HttpTransportLayerPropertiesSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpTransportLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.httpTransportLayerProperties, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.httpTransportLayerProperties;
				default: return null;
	        }
	    }
	
	    public HttpTransportLayerNonEmptyBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.HttpTransportLayerProperties, this.TCloseBrace);
		}
	
	    public HttpTransportLayerNonEmptyBodySyntax WithHttpTransportLayerProperties(SyntaxList<HttpTransportLayerPropertiesSyntax> httpTransportLayerProperties)
		{
			return this.Update(this.TOpenBrace, HttpTransportLayerProperties, this.TCloseBrace);
		}
	
	    public HttpTransportLayerNonEmptyBodySyntax AddHttpTransportLayerProperties(params HttpTransportLayerPropertiesSyntax[] httpTransportLayerProperties)
		{
			return this.WithHttpTransportLayerProperties(this.HttpTransportLayerProperties.AddRange(httpTransportLayerProperties));
		}
	
	    public HttpTransportLayerNonEmptyBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.HttpTransportLayerProperties, TCloseBrace);
		}
	
	    public HttpTransportLayerNonEmptyBodySyntax Update(SyntaxToken tOpenBrace, SyntaxList<HttpTransportLayerPropertiesSyntax> httpTransportLayerProperties, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.HttpTransportLayerProperties != httpTransportLayerProperties ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.HttpTransportLayerNonEmptyBody(tOpenBrace, httpTransportLayerProperties, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerNonEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitHttpTransportLayerNonEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHttpTransportLayerNonEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitHttpTransportLayerNonEmptyBody(this);
	    }
	}
	
	public sealed class RestTransportLayerSyntax : SoalSyntaxNode
	{
	    private RestTransportLayerBodySyntax restTransportLayerBody;
	
	    public RestTransportLayerSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RestTransportLayerSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTransport 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.RestTransportLayerGreen)this.Green;
				var greenToken = green.KTransport;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken IREST 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.RestTransportLayerGreen)this.Green;
				var greenToken = green.IREST;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public RestTransportLayerBodySyntax RestTransportLayerBody 
		{ 
			get { return this.GetRed(ref this.restTransportLayerBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.restTransportLayerBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.restTransportLayerBody;
				default: return null;
	        }
	    }
	
	    public RestTransportLayerSyntax WithKTransport(SyntaxToken kTransport)
		{
			return this.Update(KTransport, this.IREST, this.RestTransportLayerBody);
		}
	
	    public RestTransportLayerSyntax WithIREST(SyntaxToken irest)
		{
			return this.Update(this.KTransport, IREST, this.RestTransportLayerBody);
		}
	
	    public RestTransportLayerSyntax WithRestTransportLayerBody(RestTransportLayerBodySyntax restTransportLayerBody)
		{
			return this.Update(this.KTransport, this.IREST, RestTransportLayerBody);
		}
	
	    public RestTransportLayerSyntax Update(SyntaxToken kTransport, SyntaxToken irest, RestTransportLayerBodySyntax restTransportLayerBody)
	    {
	        if (this.KTransport != kTransport ||
				this.IREST != irest ||
				this.RestTransportLayerBody != restTransportLayerBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.RestTransportLayer(kTransport, irest, restTransportLayerBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RestTransportLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRestTransportLayer(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRestTransportLayer(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitRestTransportLayer(this);
	    }
	}
	
	public abstract class RestTransportLayerBodySyntax : SoalSyntaxNode
	{
	    protected RestTransportLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected RestTransportLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class RestTransportLayerEmptyBodySyntax : RestTransportLayerBodySyntax
	{
	
	    public RestTransportLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RestTransportLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.RestTransportLayerEmptyBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public RestTransportLayerEmptyBodySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(TSemicolon);
		}
	
	    public RestTransportLayerEmptyBodySyntax Update(SyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.RestTransportLayerEmptyBody(tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RestTransportLayerEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRestTransportLayerEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRestTransportLayerEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitRestTransportLayerEmptyBody(this);
	    }
	}
	
	public sealed class RestTransportLayerNonEmptyBodySyntax : RestTransportLayerBodySyntax
	{
	
	    public RestTransportLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RestTransportLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.RestTransportLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.RestTransportLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	
	    public RestTransportLayerNonEmptyBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.TCloseBrace);
		}
	
	    public RestTransportLayerNonEmptyBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, TCloseBrace);
		}
	
	    public RestTransportLayerNonEmptyBodySyntax Update(SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.RestTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RestTransportLayerNonEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRestTransportLayerNonEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRestTransportLayerNonEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitRestTransportLayerNonEmptyBody(this);
	    }
	}
	
	public sealed class WebSocketTransportLayerSyntax : SoalSyntaxNode
	{
	    private WebSocketTransportLayerBodySyntax webSocketTransportLayerBody;
	
	    public WebSocketTransportLayerSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WebSocketTransportLayerSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTransport 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.WebSocketTransportLayerGreen)this.Green;
				var greenToken = green.KTransport;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken IWebSocket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.WebSocketTransportLayerGreen)this.Green;
				var greenToken = green.IWebSocket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public WebSocketTransportLayerBodySyntax WebSocketTransportLayerBody 
		{ 
			get { return this.GetRed(ref this.webSocketTransportLayerBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.webSocketTransportLayerBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.webSocketTransportLayerBody;
				default: return null;
	        }
	    }
	
	    public WebSocketTransportLayerSyntax WithKTransport(SyntaxToken kTransport)
		{
			return this.Update(KTransport, this.IWebSocket, this.WebSocketTransportLayerBody);
		}
	
	    public WebSocketTransportLayerSyntax WithIWebSocket(SyntaxToken iWebSocket)
		{
			return this.Update(this.KTransport, IWebSocket, this.WebSocketTransportLayerBody);
		}
	
	    public WebSocketTransportLayerSyntax WithWebSocketTransportLayerBody(WebSocketTransportLayerBodySyntax webSocketTransportLayerBody)
		{
			return this.Update(this.KTransport, this.IWebSocket, WebSocketTransportLayerBody);
		}
	
	    public WebSocketTransportLayerSyntax Update(SyntaxToken kTransport, SyntaxToken iWebSocket, WebSocketTransportLayerBodySyntax webSocketTransportLayerBody)
	    {
	        if (this.KTransport != kTransport ||
				this.IWebSocket != iWebSocket ||
				this.WebSocketTransportLayerBody != webSocketTransportLayerBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.WebSocketTransportLayer(kTransport, iWebSocket, webSocketTransportLayerBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WebSocketTransportLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWebSocketTransportLayer(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWebSocketTransportLayer(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitWebSocketTransportLayer(this);
	    }
	}
	
	public abstract class WebSocketTransportLayerBodySyntax : SoalSyntaxNode
	{
	    protected WebSocketTransportLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected WebSocketTransportLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class WebSocketTransportLayerEmptyBodySyntax : WebSocketTransportLayerBodySyntax
	{
	
	    public WebSocketTransportLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WebSocketTransportLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.WebSocketTransportLayerEmptyBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public WebSocketTransportLayerEmptyBodySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(TSemicolon);
		}
	
	    public WebSocketTransportLayerEmptyBodySyntax Update(SyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.WebSocketTransportLayerEmptyBody(tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WebSocketTransportLayerEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWebSocketTransportLayerEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWebSocketTransportLayerEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitWebSocketTransportLayerEmptyBody(this);
	    }
	}
	
	public sealed class WebSocketTransportLayerNonEmptyBodySyntax : WebSocketTransportLayerBodySyntax
	{
	
	    public WebSocketTransportLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WebSocketTransportLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.WebSocketTransportLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.WebSocketTransportLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	
	    public WebSocketTransportLayerNonEmptyBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.TCloseBrace);
		}
	
	    public WebSocketTransportLayerNonEmptyBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, TCloseBrace);
		}
	
	    public WebSocketTransportLayerNonEmptyBodySyntax Update(SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.WebSocketTransportLayerNonEmptyBody(tOpenBrace, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WebSocketTransportLayerNonEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWebSocketTransportLayerNonEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWebSocketTransportLayerNonEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitWebSocketTransportLayerNonEmptyBody(this);
	    }
	}
	
	public sealed class HttpTransportLayerPropertiesSyntax : SoalSyntaxNode
	{
	    private HttpSslPropertySyntax httpSslProperty;
	    private HttpClientAuthenticationPropertySyntax httpClientAuthenticationProperty;
	
	    public HttpTransportLayerPropertiesSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HttpTransportLayerPropertiesSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public HttpSslPropertySyntax HttpSslProperty 
		{ 
			get { return this.GetRed(ref this.httpSslProperty, 0); } 
		}
	    public HttpClientAuthenticationPropertySyntax HttpClientAuthenticationProperty 
		{ 
			get { return this.GetRed(ref this.httpClientAuthenticationProperty, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.httpSslProperty, 0);
				case 1: return this.GetRed(ref this.httpClientAuthenticationProperty, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.httpSslProperty;
				case 1: return this.httpClientAuthenticationProperty;
				default: return null;
	        }
	    }
	
	    public HttpTransportLayerPropertiesSyntax WithHttpSslProperty(HttpSslPropertySyntax httpSslProperty)
		{
			return this.Update(httpSslProperty);
		}
	
	    public HttpTransportLayerPropertiesSyntax WithHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax httpClientAuthenticationProperty)
		{
			return this.Update(httpClientAuthenticationProperty);
		}
	
	    public HttpTransportLayerPropertiesSyntax Update(HttpSslPropertySyntax httpSslProperty)
	    {
	        if (this.HttpSslProperty != httpSslProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.HttpTransportLayerProperties(httpSslProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerPropertiesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public HttpTransportLayerPropertiesSyntax Update(HttpClientAuthenticationPropertySyntax httpClientAuthenticationProperty)
	    {
	        if (this.HttpClientAuthenticationProperty != httpClientAuthenticationProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.HttpTransportLayerProperties(httpClientAuthenticationProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpTransportLayerPropertiesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitHttpTransportLayerProperties(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHttpTransportLayerProperties(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitHttpTransportLayerProperties(this);
	    }
	}
	
	public sealed class HttpSslPropertySyntax : SoalSyntaxNode
	{
	    private BooleanLiteralSyntax booleanLiteral;
	
	    public HttpSslPropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HttpSslPropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ISSL 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpSslPropertyGreen)this.Green;
				var greenToken = green.ISSL;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpSslPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public BooleanLiteralSyntax BooleanLiteral 
		{ 
			get { return this.GetRed(ref this.booleanLiteral, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpSslPropertyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.booleanLiteral, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.booleanLiteral;
				default: return null;
	        }
	    }
	
	    public HttpSslPropertySyntax WithISSL(SyntaxToken issl)
		{
			return this.Update(ISSL, this.TAssign, this.BooleanLiteral, this.TSemicolon);
		}
	
	    public HttpSslPropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.ISSL, TAssign, this.BooleanLiteral, this.TSemicolon);
		}
	
	    public HttpSslPropertySyntax WithBooleanLiteral(BooleanLiteralSyntax booleanLiteral)
		{
			return this.Update(this.ISSL, this.TAssign, BooleanLiteral, this.TSemicolon);
		}
	
	    public HttpSslPropertySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.ISSL, this.TAssign, this.BooleanLiteral, TSemicolon);
		}
	
	    public HttpSslPropertySyntax Update(SyntaxToken issl, SyntaxToken tAssign, BooleanLiteralSyntax booleanLiteral, SyntaxToken tSemicolon)
	    {
	        if (this.ISSL != issl ||
				this.TAssign != tAssign ||
				this.BooleanLiteral != booleanLiteral ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.HttpSslProperty(issl, tAssign, booleanLiteral, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpSslPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitHttpSslProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHttpSslProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitHttpSslProperty(this);
	    }
	}
	
	public sealed class HttpClientAuthenticationPropertySyntax : SoalSyntaxNode
	{
	    private BooleanLiteralSyntax booleanLiteral;
	
	    public HttpClientAuthenticationPropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HttpClientAuthenticationPropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IClientAuthentication 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpClientAuthenticationPropertyGreen)this.Green;
				var greenToken = green.IClientAuthentication;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpClientAuthenticationPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public BooleanLiteralSyntax BooleanLiteral 
		{ 
			get { return this.GetRed(ref this.booleanLiteral, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.HttpClientAuthenticationPropertyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.booleanLiteral, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.booleanLiteral;
				default: return null;
	        }
	    }
	
	    public HttpClientAuthenticationPropertySyntax WithIClientAuthentication(SyntaxToken iClientAuthentication)
		{
			return this.Update(IClientAuthentication, this.TAssign, this.BooleanLiteral, this.TSemicolon);
		}
	
	    public HttpClientAuthenticationPropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.IClientAuthentication, TAssign, this.BooleanLiteral, this.TSemicolon);
		}
	
	    public HttpClientAuthenticationPropertySyntax WithBooleanLiteral(BooleanLiteralSyntax booleanLiteral)
		{
			return this.Update(this.IClientAuthentication, this.TAssign, BooleanLiteral, this.TSemicolon);
		}
	
	    public HttpClientAuthenticationPropertySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.IClientAuthentication, this.TAssign, this.BooleanLiteral, TSemicolon);
		}
	
	    public HttpClientAuthenticationPropertySyntax Update(SyntaxToken iClientAuthentication, SyntaxToken tAssign, BooleanLiteralSyntax booleanLiteral, SyntaxToken tSemicolon)
	    {
	        if (this.IClientAuthentication != iClientAuthentication ||
				this.TAssign != tAssign ||
				this.BooleanLiteral != booleanLiteral ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.HttpClientAuthenticationProperty(iClientAuthentication, tAssign, booleanLiteral, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HttpClientAuthenticationPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitHttpClientAuthenticationProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHttpClientAuthenticationProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitHttpClientAuthenticationProperty(this);
	    }
	}
	
	public sealed class EncodingLayerSyntax : SoalSyntaxNode
	{
	    private SoapEncodingLayerSyntax soapEncodingLayer;
	    private XmlEncodingLayerSyntax xmlEncodingLayer;
	    private JsonEncodingLayerSyntax jsonEncodingLayer;
	
	    public EncodingLayerSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EncodingLayerSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SoapEncodingLayerSyntax SoapEncodingLayer 
		{ 
			get { return this.GetRed(ref this.soapEncodingLayer, 0); } 
		}
	    public XmlEncodingLayerSyntax XmlEncodingLayer 
		{ 
			get { return this.GetRed(ref this.xmlEncodingLayer, 1); } 
		}
	    public JsonEncodingLayerSyntax JsonEncodingLayer 
		{ 
			get { return this.GetRed(ref this.jsonEncodingLayer, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.soapEncodingLayer, 0);
				case 1: return this.GetRed(ref this.xmlEncodingLayer, 1);
				case 2: return this.GetRed(ref this.jsonEncodingLayer, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.soapEncodingLayer;
				case 1: return this.xmlEncodingLayer;
				case 2: return this.jsonEncodingLayer;
				default: return null;
	        }
	    }
	
	    public EncodingLayerSyntax WithSoapEncodingLayer(SoapEncodingLayerSyntax soapEncodingLayer)
		{
			return this.Update(soapEncodingLayer);
		}
	
	    public EncodingLayerSyntax WithXmlEncodingLayer(XmlEncodingLayerSyntax xmlEncodingLayer)
		{
			return this.Update(xmlEncodingLayer);
		}
	
	    public EncodingLayerSyntax WithJsonEncodingLayer(JsonEncodingLayerSyntax jsonEncodingLayer)
		{
			return this.Update(jsonEncodingLayer);
		}
	
	    public EncodingLayerSyntax Update(SoapEncodingLayerSyntax soapEncodingLayer)
	    {
	        if (this.SoapEncodingLayer != soapEncodingLayer)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EncodingLayer(soapEncodingLayer);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EncodingLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public EncodingLayerSyntax Update(XmlEncodingLayerSyntax xmlEncodingLayer)
	    {
	        if (this.XmlEncodingLayer != xmlEncodingLayer)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EncodingLayer(xmlEncodingLayer);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EncodingLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public EncodingLayerSyntax Update(JsonEncodingLayerSyntax jsonEncodingLayer)
	    {
	        if (this.JsonEncodingLayer != jsonEncodingLayer)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EncodingLayer(jsonEncodingLayer);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EncodingLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEncodingLayer(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEncodingLayer(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEncodingLayer(this);
	    }
	}
	
	public sealed class SoapEncodingLayerSyntax : SoalSyntaxNode
	{
	    private SoapEncodingLayerBodySyntax soapEncodingLayerBody;
	
	    public SoapEncodingLayerSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SoapEncodingLayerSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEncoding 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapEncodingLayerGreen)this.Green;
				var greenToken = green.KEncoding;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken ISOAP 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapEncodingLayerGreen)this.Green;
				var greenToken = green.ISOAP;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SoapEncodingLayerBodySyntax SoapEncodingLayerBody 
		{ 
			get { return this.GetRed(ref this.soapEncodingLayerBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.soapEncodingLayerBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.soapEncodingLayerBody;
				default: return null;
	        }
	    }
	
	    public SoapEncodingLayerSyntax WithKEncoding(SyntaxToken kEncoding)
		{
			return this.Update(KEncoding, this.ISOAP, this.SoapEncodingLayerBody);
		}
	
	    public SoapEncodingLayerSyntax WithISOAP(SyntaxToken isoap)
		{
			return this.Update(this.KEncoding, ISOAP, this.SoapEncodingLayerBody);
		}
	
	    public SoapEncodingLayerSyntax WithSoapEncodingLayerBody(SoapEncodingLayerBodySyntax soapEncodingLayerBody)
		{
			return this.Update(this.KEncoding, this.ISOAP, SoapEncodingLayerBody);
		}
	
	    public SoapEncodingLayerSyntax Update(SyntaxToken kEncoding, SyntaxToken isoap, SoapEncodingLayerBodySyntax soapEncodingLayerBody)
	    {
	        if (this.KEncoding != kEncoding ||
				this.ISOAP != isoap ||
				this.SoapEncodingLayerBody != soapEncodingLayerBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SoapEncodingLayer(kEncoding, isoap, soapEncodingLayerBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSoapEncodingLayer(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSoapEncodingLayer(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitSoapEncodingLayer(this);
	    }
	}
	
	public abstract class SoapEncodingLayerBodySyntax : SoalSyntaxNode
	{
	    protected SoapEncodingLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected SoapEncodingLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class SoapEncodingLayerEmptyBodySyntax : SoapEncodingLayerBodySyntax
	{
	
	    public SoapEncodingLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SoapEncodingLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapEncodingLayerEmptyBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public SoapEncodingLayerEmptyBodySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(TSemicolon);
		}
	
	    public SoapEncodingLayerEmptyBodySyntax Update(SyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SoapEncodingLayerEmptyBody(tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingLayerEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSoapEncodingLayerEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSoapEncodingLayerEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitSoapEncodingLayerEmptyBody(this);
	    }
	}
	
	public sealed class SoapEncodingLayerNonEmptyBodySyntax : SoapEncodingLayerBodySyntax
	{
	    private SyntaxNode soapEncodingProperties;
	
	    public SoapEncodingLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SoapEncodingLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapEncodingLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<SoapEncodingPropertiesSyntax> SoapEncodingProperties 
		{ 
			get
			{
				var red = this.GetRed(ref this.soapEncodingProperties, 1);
				if (red != null) return new SyntaxList<SoapEncodingPropertiesSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapEncodingLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.soapEncodingProperties, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.soapEncodingProperties;
				default: return null;
	        }
	    }
	
	    public SoapEncodingLayerNonEmptyBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.SoapEncodingProperties, this.TCloseBrace);
		}
	
	    public SoapEncodingLayerNonEmptyBodySyntax WithSoapEncodingProperties(SyntaxList<SoapEncodingPropertiesSyntax> soapEncodingProperties)
		{
			return this.Update(this.TOpenBrace, SoapEncodingProperties, this.TCloseBrace);
		}
	
	    public SoapEncodingLayerNonEmptyBodySyntax AddSoapEncodingProperties(params SoapEncodingPropertiesSyntax[] soapEncodingProperties)
		{
			return this.WithSoapEncodingProperties(this.SoapEncodingProperties.AddRange(soapEncodingProperties));
		}
	
	    public SoapEncodingLayerNonEmptyBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.SoapEncodingProperties, TCloseBrace);
		}
	
	    public SoapEncodingLayerNonEmptyBodySyntax Update(SyntaxToken tOpenBrace, SyntaxList<SoapEncodingPropertiesSyntax> soapEncodingProperties, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.SoapEncodingProperties != soapEncodingProperties ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SoapEncodingLayerNonEmptyBody(tOpenBrace, soapEncodingProperties, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingLayerNonEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSoapEncodingLayerNonEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSoapEncodingLayerNonEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitSoapEncodingLayerNonEmptyBody(this);
	    }
	}
	
	public sealed class XmlEncodingLayerSyntax : SoalSyntaxNode
	{
	    private XmlEncodingLayerBodySyntax xmlEncodingLayerBody;
	
	    public XmlEncodingLayerSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public XmlEncodingLayerSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEncoding 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.XmlEncodingLayerGreen)this.Green;
				var greenToken = green.KEncoding;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken IXML 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.XmlEncodingLayerGreen)this.Green;
				var greenToken = green.IXML;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public XmlEncodingLayerBodySyntax XmlEncodingLayerBody 
		{ 
			get { return this.GetRed(ref this.xmlEncodingLayerBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.xmlEncodingLayerBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.xmlEncodingLayerBody;
				default: return null;
	        }
	    }
	
	    public XmlEncodingLayerSyntax WithKEncoding(SyntaxToken kEncoding)
		{
			return this.Update(KEncoding, this.IXML, this.XmlEncodingLayerBody);
		}
	
	    public XmlEncodingLayerSyntax WithIXML(SyntaxToken ixml)
		{
			return this.Update(this.KEncoding, IXML, this.XmlEncodingLayerBody);
		}
	
	    public XmlEncodingLayerSyntax WithXmlEncodingLayerBody(XmlEncodingLayerBodySyntax xmlEncodingLayerBody)
		{
			return this.Update(this.KEncoding, this.IXML, XmlEncodingLayerBody);
		}
	
	    public XmlEncodingLayerSyntax Update(SyntaxToken kEncoding, SyntaxToken ixml, XmlEncodingLayerBodySyntax xmlEncodingLayerBody)
	    {
	        if (this.KEncoding != kEncoding ||
				this.IXML != ixml ||
				this.XmlEncodingLayerBody != xmlEncodingLayerBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.XmlEncodingLayer(kEncoding, ixml, xmlEncodingLayerBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (XmlEncodingLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitXmlEncodingLayer(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitXmlEncodingLayer(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitXmlEncodingLayer(this);
	    }
	}
	
	public abstract class XmlEncodingLayerBodySyntax : SoalSyntaxNode
	{
	    protected XmlEncodingLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected XmlEncodingLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class XmlEncodingLayerEmptyBodySyntax : XmlEncodingLayerBodySyntax
	{
	
	    public XmlEncodingLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public XmlEncodingLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.XmlEncodingLayerEmptyBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public XmlEncodingLayerEmptyBodySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(TSemicolon);
		}
	
	    public XmlEncodingLayerEmptyBodySyntax Update(SyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.XmlEncodingLayerEmptyBody(tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (XmlEncodingLayerEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitXmlEncodingLayerEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitXmlEncodingLayerEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitXmlEncodingLayerEmptyBody(this);
	    }
	}
	
	public sealed class XmlEncodingLayerNonEmptyBodySyntax : XmlEncodingLayerBodySyntax
	{
	
	    public XmlEncodingLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public XmlEncodingLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.XmlEncodingLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.XmlEncodingLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	
	    public XmlEncodingLayerNonEmptyBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.TCloseBrace);
		}
	
	    public XmlEncodingLayerNonEmptyBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, TCloseBrace);
		}
	
	    public XmlEncodingLayerNonEmptyBodySyntax Update(SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.XmlEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (XmlEncodingLayerNonEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitXmlEncodingLayerNonEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitXmlEncodingLayerNonEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitXmlEncodingLayerNonEmptyBody(this);
	    }
	}
	
	public sealed class JsonEncodingLayerSyntax : SoalSyntaxNode
	{
	    private JsonEncodingLayerBodySyntax jsonEncodingLayerBody;
	
	    public JsonEncodingLayerSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public JsonEncodingLayerSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEncoding 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.JsonEncodingLayerGreen)this.Green;
				var greenToken = green.KEncoding;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken IJSON 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.JsonEncodingLayerGreen)this.Green;
				var greenToken = green.IJSON;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public JsonEncodingLayerBodySyntax JsonEncodingLayerBody 
		{ 
			get { return this.GetRed(ref this.jsonEncodingLayerBody, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.jsonEncodingLayerBody, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.jsonEncodingLayerBody;
				default: return null;
	        }
	    }
	
	    public JsonEncodingLayerSyntax WithKEncoding(SyntaxToken kEncoding)
		{
			return this.Update(KEncoding, this.IJSON, this.JsonEncodingLayerBody);
		}
	
	    public JsonEncodingLayerSyntax WithIJSON(SyntaxToken ijson)
		{
			return this.Update(this.KEncoding, IJSON, this.JsonEncodingLayerBody);
		}
	
	    public JsonEncodingLayerSyntax WithJsonEncodingLayerBody(JsonEncodingLayerBodySyntax jsonEncodingLayerBody)
		{
			return this.Update(this.KEncoding, this.IJSON, JsonEncodingLayerBody);
		}
	
	    public JsonEncodingLayerSyntax Update(SyntaxToken kEncoding, SyntaxToken ijson, JsonEncodingLayerBodySyntax jsonEncodingLayerBody)
	    {
	        if (this.KEncoding != kEncoding ||
				this.IJSON != ijson ||
				this.JsonEncodingLayerBody != jsonEncodingLayerBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.JsonEncodingLayer(kEncoding, ijson, jsonEncodingLayerBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (JsonEncodingLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitJsonEncodingLayer(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitJsonEncodingLayer(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitJsonEncodingLayer(this);
	    }
	}
	
	public abstract class JsonEncodingLayerBodySyntax : SoalSyntaxNode
	{
	    protected JsonEncodingLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected JsonEncodingLayerBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class JsonEncodingLayerEmptyBodySyntax : JsonEncodingLayerBodySyntax
	{
	
	    public JsonEncodingLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public JsonEncodingLayerEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.JsonEncodingLayerEmptyBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public JsonEncodingLayerEmptyBodySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(TSemicolon);
		}
	
	    public JsonEncodingLayerEmptyBodySyntax Update(SyntaxToken tSemicolon)
	    {
	        if (this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.JsonEncodingLayerEmptyBody(tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (JsonEncodingLayerEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitJsonEncodingLayerEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitJsonEncodingLayerEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitJsonEncodingLayerEmptyBody(this);
	    }
	}
	
	public sealed class JsonEncodingLayerNonEmptyBodySyntax : JsonEncodingLayerBodySyntax
	{
	
	    public JsonEncodingLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public JsonEncodingLayerNonEmptyBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.JsonEncodingLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.JsonEncodingLayerNonEmptyBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	
	    public JsonEncodingLayerNonEmptyBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.TCloseBrace);
		}
	
	    public JsonEncodingLayerNonEmptyBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, TCloseBrace);
		}
	
	    public JsonEncodingLayerNonEmptyBodySyntax Update(SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.JsonEncodingLayerNonEmptyBody(tOpenBrace, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (JsonEncodingLayerNonEmptyBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitJsonEncodingLayerNonEmptyBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitJsonEncodingLayerNonEmptyBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitJsonEncodingLayerNonEmptyBody(this);
	    }
	}
	
	public sealed class SoapEncodingPropertiesSyntax : SoalSyntaxNode
	{
	    private SoapVersionPropertySyntax soapVersionProperty;
	    private SoapMtomPropertySyntax soapMtomProperty;
	    private SoapStylePropertySyntax soapStyleProperty;
	
	    public SoapEncodingPropertiesSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SoapEncodingPropertiesSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SoapVersionPropertySyntax SoapVersionProperty 
		{ 
			get { return this.GetRed(ref this.soapVersionProperty, 0); } 
		}
	    public SoapMtomPropertySyntax SoapMtomProperty 
		{ 
			get { return this.GetRed(ref this.soapMtomProperty, 1); } 
		}
	    public SoapStylePropertySyntax SoapStyleProperty 
		{ 
			get { return this.GetRed(ref this.soapStyleProperty, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.soapVersionProperty, 0);
				case 1: return this.GetRed(ref this.soapMtomProperty, 1);
				case 2: return this.GetRed(ref this.soapStyleProperty, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.soapVersionProperty;
				case 1: return this.soapMtomProperty;
				case 2: return this.soapStyleProperty;
				default: return null;
	        }
	    }
	
	    public SoapEncodingPropertiesSyntax WithSoapVersionProperty(SoapVersionPropertySyntax soapVersionProperty)
		{
			return this.Update(soapVersionProperty);
		}
	
	    public SoapEncodingPropertiesSyntax WithSoapMtomProperty(SoapMtomPropertySyntax soapMtomProperty)
		{
			return this.Update(soapMtomProperty);
		}
	
	    public SoapEncodingPropertiesSyntax WithSoapStyleProperty(SoapStylePropertySyntax soapStyleProperty)
		{
			return this.Update(soapStyleProperty);
		}
	
	    public SoapEncodingPropertiesSyntax Update(SoapVersionPropertySyntax soapVersionProperty)
	    {
	        if (this.SoapVersionProperty != soapVersionProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SoapEncodingProperties(soapVersionProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingPropertiesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SoapEncodingPropertiesSyntax Update(SoapMtomPropertySyntax soapMtomProperty)
	    {
	        if (this.SoapMtomProperty != soapMtomProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SoapEncodingProperties(soapMtomProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingPropertiesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SoapEncodingPropertiesSyntax Update(SoapStylePropertySyntax soapStyleProperty)
	    {
	        if (this.SoapStyleProperty != soapStyleProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SoapEncodingProperties(soapStyleProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapEncodingPropertiesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSoapEncodingProperties(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSoapEncodingProperties(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitSoapEncodingProperties(this);
	    }
	}
	
	public sealed class SoapVersionPropertySyntax : SoalSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public SoapVersionPropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SoapVersionPropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IVersion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapVersionPropertyGreen)this.Green;
				var greenToken = green.IVersion;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapVersionPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapVersionPropertyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.identifier, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.identifier;
				default: return null;
	        }
	    }
	
	    public SoapVersionPropertySyntax WithIVersion(SyntaxToken iVersion)
		{
			return this.Update(IVersion, this.TAssign, this.Identifier, this.TSemicolon);
		}
	
	    public SoapVersionPropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.IVersion, TAssign, this.Identifier, this.TSemicolon);
		}
	
	    public SoapVersionPropertySyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.IVersion, this.TAssign, Identifier, this.TSemicolon);
		}
	
	    public SoapVersionPropertySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.IVersion, this.TAssign, this.Identifier, TSemicolon);
		}
	
	    public SoapVersionPropertySyntax Update(SyntaxToken iVersion, SyntaxToken tAssign, IdentifierSyntax identifier, SyntaxToken tSemicolon)
	    {
	        if (this.IVersion != iVersion ||
				this.TAssign != tAssign ||
				this.Identifier != identifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SoapVersionProperty(iVersion, tAssign, identifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapVersionPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSoapVersionProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSoapVersionProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitSoapVersionProperty(this);
	    }
	}
	
	public sealed class SoapMtomPropertySyntax : SoalSyntaxNode
	{
	    private BooleanLiteralSyntax booleanLiteral;
	
	    public SoapMtomPropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SoapMtomPropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IMTOM 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapMtomPropertyGreen)this.Green;
				var greenToken = green.IMTOM;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapMtomPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public BooleanLiteralSyntax BooleanLiteral 
		{ 
			get { return this.GetRed(ref this.booleanLiteral, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapMtomPropertyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.booleanLiteral, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.booleanLiteral;
				default: return null;
	        }
	    }
	
	    public SoapMtomPropertySyntax WithIMTOM(SyntaxToken imtom)
		{
			return this.Update(IMTOM, this.TAssign, this.BooleanLiteral, this.TSemicolon);
		}
	
	    public SoapMtomPropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.IMTOM, TAssign, this.BooleanLiteral, this.TSemicolon);
		}
	
	    public SoapMtomPropertySyntax WithBooleanLiteral(BooleanLiteralSyntax booleanLiteral)
		{
			return this.Update(this.IMTOM, this.TAssign, BooleanLiteral, this.TSemicolon);
		}
	
	    public SoapMtomPropertySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.IMTOM, this.TAssign, this.BooleanLiteral, TSemicolon);
		}
	
	    public SoapMtomPropertySyntax Update(SyntaxToken imtom, SyntaxToken tAssign, BooleanLiteralSyntax booleanLiteral, SyntaxToken tSemicolon)
	    {
	        if (this.IMTOM != imtom ||
				this.TAssign != tAssign ||
				this.BooleanLiteral != booleanLiteral ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SoapMtomProperty(imtom, tAssign, booleanLiteral, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapMtomPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSoapMtomProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSoapMtomProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitSoapMtomProperty(this);
	    }
	}
	
	public sealed class SoapStylePropertySyntax : SoalSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public SoapStylePropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SoapStylePropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IStyle 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapStylePropertyGreen)this.Green;
				var greenToken = green.IStyle;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapStylePropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoapStylePropertyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.identifier, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.identifier;
				default: return null;
	        }
	    }
	
	    public SoapStylePropertySyntax WithIStyle(SyntaxToken iStyle)
		{
			return this.Update(IStyle, this.TAssign, this.Identifier, this.TSemicolon);
		}
	
	    public SoapStylePropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.IStyle, TAssign, this.Identifier, this.TSemicolon);
		}
	
	    public SoapStylePropertySyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.IStyle, this.TAssign, Identifier, this.TSemicolon);
		}
	
	    public SoapStylePropertySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.IStyle, this.TAssign, this.Identifier, TSemicolon);
		}
	
	    public SoapStylePropertySyntax Update(SyntaxToken iStyle, SyntaxToken tAssign, IdentifierSyntax identifier, SyntaxToken tSemicolon)
	    {
	        if (this.IStyle != iStyle ||
				this.TAssign != tAssign ||
				this.Identifier != identifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SoapStyleProperty(iStyle, tAssign, identifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SoapStylePropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSoapStyleProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSoapStyleProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitSoapStyleProperty(this);
	    }
	}
	
	public sealed class ProtocolLayerSyntax : SoalSyntaxNode
	{
	    private ProtocolLayerKindSyntax protocolLayerKind;
	
	    public ProtocolLayerSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ProtocolLayerSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KProtocol 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ProtocolLayerGreen)this.Green;
				var greenToken = green.KProtocol;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ProtocolLayerKindSyntax ProtocolLayerKind 
		{ 
			get { return this.GetRed(ref this.protocolLayerKind, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ProtocolLayerGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.protocolLayerKind, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.protocolLayerKind;
				default: return null;
	        }
	    }
	
	    public ProtocolLayerSyntax WithKProtocol(SyntaxToken kProtocol)
		{
			return this.Update(KProtocol, this.ProtocolLayerKind, this.TSemicolon);
		}
	
	    public ProtocolLayerSyntax WithProtocolLayerKind(ProtocolLayerKindSyntax protocolLayerKind)
		{
			return this.Update(this.KProtocol, ProtocolLayerKind, this.TSemicolon);
		}
	
	    public ProtocolLayerSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KProtocol, this.ProtocolLayerKind, TSemicolon);
		}
	
	    public ProtocolLayerSyntax Update(SyntaxToken kProtocol, ProtocolLayerKindSyntax protocolLayerKind, SyntaxToken tSemicolon)
	    {
	        if (this.KProtocol != kProtocol ||
				this.ProtocolLayerKind != protocolLayerKind ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ProtocolLayer(kProtocol, protocolLayerKind, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ProtocolLayerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitProtocolLayer(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitProtocolLayer(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitProtocolLayer(this);
	    }
	}
	
	public sealed class ProtocolLayerKindSyntax : SoalSyntaxNode
	{
	    private WsAddressingSyntax wsAddressing;
	
	    public ProtocolLayerKindSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ProtocolLayerKindSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public WsAddressingSyntax WsAddressing 
		{ 
			get { return this.GetRed(ref this.wsAddressing, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.wsAddressing, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.wsAddressing;
				default: return null;
	        }
	    }
	
	    public ProtocolLayerKindSyntax WithWsAddressing(WsAddressingSyntax wsAddressing)
		{
			return this.Update(WsAddressing);
		}
	
	    public ProtocolLayerKindSyntax Update(WsAddressingSyntax wsAddressing)
	    {
	        if (this.WsAddressing != wsAddressing)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ProtocolLayerKind(wsAddressing);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ProtocolLayerKindSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitProtocolLayerKind(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitProtocolLayerKind(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitProtocolLayerKind(this);
	    }
	}
	
	public sealed class WsAddressingSyntax : SoalSyntaxNode
	{
	
	    public WsAddressingSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WsAddressingSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IWsAddressing 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.WsAddressingGreen)this.Green;
				var greenToken = green.IWsAddressing;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public WsAddressingSyntax WithIWsAddressing(SyntaxToken iWsAddressing)
		{
			return this.Update(IWsAddressing);
		}
	
	    public WsAddressingSyntax Update(SyntaxToken iWsAddressing)
	    {
	        if (this.IWsAddressing != iWsAddressing)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.WsAddressing(iWsAddressing);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WsAddressingSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWsAddressing(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWsAddressing(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitWsAddressing(this);
	    }
	}
	
	public sealed class EndpointDeclarationSyntax : SoalSyntaxNode
	{
	    private NameSyntax name;
	    private QualifierSyntax qualifier;
	    private EndpointBodySyntax endpointBody;
	
	    public EndpointDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EndpointDeclarationSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEndpoint 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EndpointDeclarationGreen)this.Green;
				var greenToken = green.KEndpoint;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EndpointDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	    public EndpointBodySyntax EndpointBody 
		{ 
			get { return this.GetRed(ref this.endpointBody, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.qualifier, 3);
				case 4: return this.GetRed(ref this.endpointBody, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.qualifier;
				case 4: return this.endpointBody;
				default: return null;
	        }
	    }
	
	    public EndpointDeclarationSyntax WithKEndpoint(SyntaxToken kEndpoint)
		{
			return this.Update(KEndpoint, this.Name, this.TColon, this.Qualifier, this.EndpointBody);
		}
	
	    public EndpointDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KEndpoint, Name, this.TColon, this.Qualifier, this.EndpointBody);
		}
	
	    public EndpointDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KEndpoint, this.Name, TColon, this.Qualifier, this.EndpointBody);
		}
	
	    public EndpointDeclarationSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KEndpoint, this.Name, this.TColon, Qualifier, this.EndpointBody);
		}
	
	    public EndpointDeclarationSyntax WithEndpointBody(EndpointBodySyntax endpointBody)
		{
			return this.Update(this.KEndpoint, this.Name, this.TColon, this.Qualifier, EndpointBody);
		}
	
	    public EndpointDeclarationSyntax Update(SyntaxToken kEndpoint, NameSyntax name, SyntaxToken tColon, QualifierSyntax qualifier, EndpointBodySyntax endpointBody)
	    {
	        if (this.KEndpoint != kEndpoint ||
				this.Name != name ||
				this.TColon != tColon ||
				this.Qualifier != qualifier ||
				this.EndpointBody != endpointBody)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EndpointDeclaration(kEndpoint, name, tColon, qualifier, endpointBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEndpointDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEndpointDeclaration(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEndpointDeclaration(this);
	    }
	}
	
	public sealed class EndpointBodySyntax : SoalSyntaxNode
	{
	    private EndpointPropertiesSyntax endpointProperties;
	
	    public EndpointBodySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EndpointBodySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EndpointBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public EndpointPropertiesSyntax EndpointProperties 
		{ 
			get { return this.GetRed(ref this.endpointProperties, 1); } 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EndpointBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.endpointProperties, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.endpointProperties;
				default: return null;
	        }
	    }
	
	    public EndpointBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.EndpointProperties, this.TCloseBrace);
		}
	
	    public EndpointBodySyntax WithEndpointProperties(EndpointPropertiesSyntax endpointProperties)
		{
			return this.Update(this.TOpenBrace, EndpointProperties, this.TCloseBrace);
		}
	
	    public EndpointBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.EndpointProperties, TCloseBrace);
		}
	
	    public EndpointBodySyntax Update(SyntaxToken tOpenBrace, EndpointPropertiesSyntax endpointProperties, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EndpointProperties != endpointProperties ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EndpointBody(tOpenBrace, endpointProperties, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEndpointBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEndpointBody(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEndpointBody(this);
	    }
	}
	
	public sealed class EndpointPropertiesSyntax : SoalSyntaxNode
	{
	    private SyntaxNode endpointProperty;
	
	    public EndpointPropertiesSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EndpointPropertiesSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<EndpointPropertySyntax> EndpointProperty 
		{ 
			get
			{
				var red = this.GetRed(ref this.endpointProperty, 0);
				if (red != null) return new SyntaxList<EndpointPropertySyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.endpointProperty, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.endpointProperty;
				default: return null;
	        }
	    }
	
	    public EndpointPropertiesSyntax WithEndpointProperty(SyntaxList<EndpointPropertySyntax> endpointProperty)
		{
			return this.Update(EndpointProperty);
		}
	
	    public EndpointPropertiesSyntax AddEndpointProperty(params EndpointPropertySyntax[] endpointProperty)
		{
			return this.WithEndpointProperty(this.EndpointProperty.AddRange(endpointProperty));
		}
	
	    public EndpointPropertiesSyntax Update(SyntaxList<EndpointPropertySyntax> endpointProperty)
	    {
	        if (this.EndpointProperty != endpointProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EndpointProperties(endpointProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointPropertiesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEndpointProperties(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEndpointProperties(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEndpointProperties(this);
	    }
	}
	
	public sealed class EndpointPropertySyntax : SoalSyntaxNode
	{
	    private EndpointBindingPropertySyntax endpointBindingProperty;
	    private EndpointAddressPropertySyntax endpointAddressProperty;
	
	    public EndpointPropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EndpointPropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public EndpointBindingPropertySyntax EndpointBindingProperty 
		{ 
			get { return this.GetRed(ref this.endpointBindingProperty, 0); } 
		}
	    public EndpointAddressPropertySyntax EndpointAddressProperty 
		{ 
			get { return this.GetRed(ref this.endpointAddressProperty, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.endpointBindingProperty, 0);
				case 1: return this.GetRed(ref this.endpointAddressProperty, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.endpointBindingProperty;
				case 1: return this.endpointAddressProperty;
				default: return null;
	        }
	    }
	
	    public EndpointPropertySyntax WithEndpointBindingProperty(EndpointBindingPropertySyntax endpointBindingProperty)
		{
			return this.Update(endpointBindingProperty);
		}
	
	    public EndpointPropertySyntax WithEndpointAddressProperty(EndpointAddressPropertySyntax endpointAddressProperty)
		{
			return this.Update(endpointAddressProperty);
		}
	
	    public EndpointPropertySyntax Update(EndpointBindingPropertySyntax endpointBindingProperty)
	    {
	        if (this.EndpointBindingProperty != endpointBindingProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EndpointProperty(endpointBindingProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public EndpointPropertySyntax Update(EndpointAddressPropertySyntax endpointAddressProperty)
	    {
	        if (this.EndpointAddressProperty != endpointAddressProperty)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EndpointProperty(endpointAddressProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEndpointProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEndpointProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEndpointProperty(this);
	    }
	}
	
	public sealed class EndpointBindingPropertySyntax : SoalSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public EndpointBindingPropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EndpointBindingPropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KBinding 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EndpointBindingPropertyGreen)this.Green;
				var greenToken = green.KBinding;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EndpointBindingPropertyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public EndpointBindingPropertySyntax WithKBinding(SyntaxToken kBinding)
		{
			return this.Update(KBinding, this.Qualifier, this.TSemicolon);
		}
	
	    public EndpointBindingPropertySyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KBinding, Qualifier, this.TSemicolon);
		}
	
	    public EndpointBindingPropertySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KBinding, this.Qualifier, TSemicolon);
		}
	
	    public EndpointBindingPropertySyntax Update(SyntaxToken kBinding, QualifierSyntax qualifier, SyntaxToken tSemicolon)
	    {
	        if (this.KBinding != kBinding ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EndpointBindingProperty(kBinding, qualifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointBindingPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEndpointBindingProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEndpointBindingProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEndpointBindingProperty(this);
	    }
	}
	
	public sealed class EndpointAddressPropertySyntax : SoalSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public EndpointAddressPropertySyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EndpointAddressPropertySyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KAddress 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EndpointAddressPropertyGreen)this.Green;
				var greenToken = green.KAddress;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public StringLiteralSyntax StringLiteral 
		{ 
			get { return this.GetRed(ref this.stringLiteral, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.EndpointAddressPropertyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.stringLiteral, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.stringLiteral;
				default: return null;
	        }
	    }
	
	    public EndpointAddressPropertySyntax WithKAddress(SyntaxToken kAddress)
		{
			return this.Update(KAddress, this.StringLiteral, this.TSemicolon);
		}
	
	    public EndpointAddressPropertySyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(this.KAddress, StringLiteral, this.TSemicolon);
		}
	
	    public EndpointAddressPropertySyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KAddress, this.StringLiteral, TSemicolon);
		}
	
	    public EndpointAddressPropertySyntax Update(SyntaxToken kAddress, StringLiteralSyntax stringLiteral, SyntaxToken tSemicolon)
	    {
	        if (this.KAddress != kAddress ||
				this.StringLiteral != stringLiteral ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.EndpointAddressProperty(kAddress, stringLiteral, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EndpointAddressPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEndpointAddressProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEndpointAddressProperty(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitEndpointAddressProperty(this);
	    }
	}
	
	public sealed class ReturnTypeSyntax : SoalSyntaxNode
	{
	    private VoidTypeSyntax voidType;
	    private TypeReferenceSyntax typeReference;
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VoidTypeSyntax VoidType 
		{ 
			get { return this.GetRed(ref this.voidType, 0); } 
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.voidType, 0);
				case 1: return this.GetRed(ref this.typeReference, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.voidType;
				case 1: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public ReturnTypeSyntax WithVoidType(VoidTypeSyntax voidType)
		{
			return this.Update(voidType);
		}
	
	    public ReturnTypeSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(typeReference);
		}
	
	    public ReturnTypeSyntax Update(VoidTypeSyntax voidType)
	    {
	        if (this.VoidType != voidType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ReturnType(voidType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ReturnTypeSyntax Update(TypeReferenceSyntax typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ReturnType(typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitReturnType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReturnType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitReturnType(this);
	    }
	}
	
	public sealed class TypeReferenceSyntax : SoalSyntaxNode
	{
	    private NonNullableArrayTypeSyntax nonNullableArrayType;
	    private ArrayTypeSyntax arrayType;
	    private SimpleTypeSyntax simpleType;
	    private NulledTypeSyntax nulledType;
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NonNullableArrayTypeSyntax NonNullableArrayType 
		{ 
			get { return this.GetRed(ref this.nonNullableArrayType, 0); } 
		}
	    public ArrayTypeSyntax ArrayType 
		{ 
			get { return this.GetRed(ref this.arrayType, 1); } 
		}
	    public SimpleTypeSyntax SimpleType 
		{ 
			get { return this.GetRed(ref this.simpleType, 2); } 
		}
	    public NulledTypeSyntax NulledType 
		{ 
			get { return this.GetRed(ref this.nulledType, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.nonNullableArrayType, 0);
				case 1: return this.GetRed(ref this.arrayType, 1);
				case 2: return this.GetRed(ref this.simpleType, 2);
				case 3: return this.GetRed(ref this.nulledType, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.nonNullableArrayType;
				case 1: return this.arrayType;
				case 2: return this.simpleType;
				case 3: return this.nulledType;
				default: return null;
	        }
	    }
	
	    public TypeReferenceSyntax WithNonNullableArrayType(NonNullableArrayTypeSyntax nonNullableArrayType)
		{
			return this.Update(nonNullableArrayType);
		}
	
	    public TypeReferenceSyntax WithArrayType(ArrayTypeSyntax arrayType)
		{
			return this.Update(arrayType);
		}
	
	    public TypeReferenceSyntax WithSimpleType(SimpleTypeSyntax simpleType)
		{
			return this.Update(simpleType);
		}
	
	    public TypeReferenceSyntax WithNulledType(NulledTypeSyntax nulledType)
		{
			return this.Update(nulledType);
		}
	
	    public TypeReferenceSyntax Update(NonNullableArrayTypeSyntax nonNullableArrayType)
	    {
	        if (this.NonNullableArrayType != nonNullableArrayType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.TypeReference(nonNullableArrayType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TypeReferenceSyntax Update(ArrayTypeSyntax arrayType)
	    {
	        if (this.ArrayType != arrayType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.TypeReference(arrayType);
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.TypeReference(simpleType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TypeReferenceSyntax Update(NulledTypeSyntax nulledType)
	    {
	        if (this.NulledType != nulledType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.TypeReference(nulledType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeReference(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeReference(this);
	    }
	}
	
	public sealed class SimpleTypeSyntax : SoalSyntaxNode
	{
	    private ValueTypeSyntax valueType;
	    private ObjectTypeSyntax objectType;
	    private QualifierSyntax qualifier;
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ValueTypeSyntax ValueType 
		{ 
			get { return this.GetRed(ref this.valueType, 0); } 
		}
	    public ObjectTypeSyntax ObjectType 
		{ 
			get { return this.GetRed(ref this.objectType, 1); } 
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.valueType, 0);
				case 1: return this.GetRed(ref this.objectType, 1);
				case 2: return this.GetRed(ref this.qualifier, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.valueType;
				case 1: return this.objectType;
				case 2: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public SimpleTypeSyntax WithValueType(ValueTypeSyntax valueType)
		{
			return this.Update(valueType);
		}
	
	    public SimpleTypeSyntax WithObjectType(ObjectTypeSyntax objectType)
		{
			return this.Update(objectType);
		}
	
	    public SimpleTypeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(qualifier);
		}
	
	    public SimpleTypeSyntax Update(ValueTypeSyntax valueType)
	    {
	        if (this.ValueType != valueType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SimpleType(valueType);
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SimpleType(objectType);
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SimpleType(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleType(this);
	    }
	}
	
	public sealed class NulledTypeSyntax : SoalSyntaxNode
	{
	    private NullableTypeSyntax nullableType;
	    private NonNullableTypeSyntax nonNullableType;
	
	    public NulledTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NulledTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NullableTypeSyntax NullableType 
		{ 
			get { return this.GetRed(ref this.nullableType, 0); } 
		}
	    public NonNullableTypeSyntax NonNullableType 
		{ 
			get { return this.GetRed(ref this.nonNullableType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.nullableType, 0);
				case 1: return this.GetRed(ref this.nonNullableType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.nullableType;
				case 1: return this.nonNullableType;
				default: return null;
	        }
	    }
	
	    public NulledTypeSyntax WithNullableType(NullableTypeSyntax nullableType)
		{
			return this.Update(nullableType);
		}
	
	    public NulledTypeSyntax WithNonNullableType(NonNullableTypeSyntax nonNullableType)
		{
			return this.Update(nonNullableType);
		}
	
	    public NulledTypeSyntax Update(NullableTypeSyntax nullableType)
	    {
	        if (this.NullableType != nullableType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NulledType(nullableType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NulledTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public NulledTypeSyntax Update(NonNullableTypeSyntax nonNullableType)
	    {
	        if (this.NonNullableType != nonNullableType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NulledType(nonNullableType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NulledTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNulledType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNulledType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNulledType(this);
	    }
	}
	
	public sealed class ReferenceTypeSyntax : SoalSyntaxNode
	{
	    private ObjectTypeSyntax objectType;
	    private QualifierSyntax qualifier;
	
	    public ReferenceTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReferenceTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ObjectTypeSyntax ObjectType 
		{ 
			get { return this.GetRed(ref this.objectType, 0); } 
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.objectType, 0);
				case 1: return this.GetRed(ref this.qualifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.objectType;
				case 1: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public ReferenceTypeSyntax WithObjectType(ObjectTypeSyntax objectType)
		{
			return this.Update(objectType);
		}
	
	    public ReferenceTypeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(qualifier);
		}
	
	    public ReferenceTypeSyntax Update(ObjectTypeSyntax objectType)
	    {
	        if (this.ObjectType != objectType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ReferenceType(objectType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReferenceTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ReferenceTypeSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ReferenceType(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReferenceTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitReferenceType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReferenceType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitReferenceType(this);
	    }
	}
	
	public sealed class ObjectTypeSyntax : SoalSyntaxNode
	{
	
	    public ObjectTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ObjectTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ObjectType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ObjectTypeGreen)this.Green;
				var greenToken = green.ObjectType;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ObjectType(objectType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitObjectType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitObjectType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitObjectType(this);
	    }
	}
	
	public sealed class ValueTypeSyntax : SoalSyntaxNode
	{
	
	    public ValueTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ValueTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ValueType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ValueTypeGreen)this.Green;
				var greenToken = green.ValueType;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public ValueTypeSyntax WithValueType(SyntaxToken valueType)
		{
			return this.Update(ValueType);
		}
	
	    public ValueTypeSyntax Update(SyntaxToken valueType)
	    {
	        if (this.ValueType != valueType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ValueType(valueType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ValueTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitValueType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitValueType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitValueType(this);
	    }
	}
	
	public sealed class VoidTypeSyntax : SoalSyntaxNode
	{
	
	    public VoidTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VoidTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVoid 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.VoidTypeGreen)this.Green;
				var greenToken = green.KVoid;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.VoidType(kVoid);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VoidTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVoidType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVoidType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitVoidType(this);
	    }
	}
	
	public sealed class OnewayTypeSyntax : SoalSyntaxNode
	{
	
	    public OnewayTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OnewayTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KOneway 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.OnewayTypeGreen)this.Green;
				var greenToken = green.KOneway;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public OnewayTypeSyntax WithKOneway(SyntaxToken kOneway)
		{
			return this.Update(KOneway);
		}
	
	    public OnewayTypeSyntax Update(SyntaxToken kOneway)
	    {
	        if (this.KOneway != kOneway)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.OnewayType(kOneway);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OnewayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOnewayType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOnewayType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitOnewayType(this);
	    }
	}
	
	public sealed class OperationReturnTypeSyntax : SoalSyntaxNode
	{
	    private OnewayTypeSyntax onewayType;
	    private VoidTypeSyntax voidType;
	    private TypeReferenceSyntax typeReference;
	
	    public OperationReturnTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationReturnTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public OnewayTypeSyntax OnewayType 
		{ 
			get { return this.GetRed(ref this.onewayType, 0); } 
		}
	    public VoidTypeSyntax VoidType 
		{ 
			get { return this.GetRed(ref this.voidType, 1); } 
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.onewayType, 0);
				case 1: return this.GetRed(ref this.voidType, 1);
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.onewayType;
				case 1: return this.voidType;
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public OperationReturnTypeSyntax WithOnewayType(OnewayTypeSyntax onewayType)
		{
			return this.Update(onewayType);
		}
	
	    public OperationReturnTypeSyntax WithVoidType(VoidTypeSyntax voidType)
		{
			return this.Update(voidType);
		}
	
	    public OperationReturnTypeSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(typeReference);
		}
	
	    public OperationReturnTypeSyntax Update(OnewayTypeSyntax onewayType)
	    {
	        if (this.OnewayType != onewayType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.OperationReturnType(onewayType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public OperationReturnTypeSyntax Update(VoidTypeSyntax voidType)
	    {
	        if (this.VoidType != voidType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.OperationReturnType(voidType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public OperationReturnTypeSyntax Update(TypeReferenceSyntax typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.OperationReturnType(typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOperationReturnType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationReturnType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationReturnType(this);
	    }
	}
	
	public sealed class NullableTypeSyntax : SoalSyntaxNode
	{
	    private ValueTypeSyntax valueType;
	
	    public NullableTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullableTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ValueTypeSyntax ValueType 
		{ 
			get { return this.GetRed(ref this.valueType, 0); } 
		}
	    public SyntaxToken TQuestion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NullableTypeGreen)this.Green;
				var greenToken = green.TQuestion;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.valueType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.valueType;
				default: return null;
	        }
	    }
	
	    public NullableTypeSyntax WithValueType(ValueTypeSyntax valueType)
		{
			return this.Update(ValueType, this.TQuestion);
		}
	
	    public NullableTypeSyntax WithTQuestion(SyntaxToken tQuestion)
		{
			return this.Update(this.ValueType, TQuestion);
		}
	
	    public NullableTypeSyntax Update(ValueTypeSyntax valueType, SyntaxToken tQuestion)
	    {
	        if (this.ValueType != valueType ||
				this.TQuestion != tQuestion)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NullableType(valueType, tQuestion);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullableType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullableType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNullableType(this);
	    }
	}
	
	public sealed class NonNullableTypeSyntax : SoalSyntaxNode
	{
	    private ReferenceTypeSyntax referenceType;
	
	    public NonNullableTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NonNullableTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ReferenceTypeSyntax ReferenceType 
		{ 
			get { return this.GetRed(ref this.referenceType, 0); } 
		}
	    public SyntaxToken TExclamation 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NonNullableTypeGreen)this.Green;
				var greenToken = green.TExclamation;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.referenceType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.referenceType;
				default: return null;
	        }
	    }
	
	    public NonNullableTypeSyntax WithReferenceType(ReferenceTypeSyntax referenceType)
		{
			return this.Update(ReferenceType, this.TExclamation);
		}
	
	    public NonNullableTypeSyntax WithTExclamation(SyntaxToken tExclamation)
		{
			return this.Update(this.ReferenceType, TExclamation);
		}
	
	    public NonNullableTypeSyntax Update(ReferenceTypeSyntax referenceType, SyntaxToken tExclamation)
	    {
	        if (this.ReferenceType != referenceType ||
				this.TExclamation != tExclamation)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NonNullableType(referenceType, tExclamation);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NonNullableTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNonNullableType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNonNullableType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNonNullableType(this);
	    }
	}
	
	public sealed class NonNullableArrayTypeSyntax : SoalSyntaxNode
	{
	    private ArrayTypeSyntax arrayType;
	
	    public NonNullableArrayTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NonNullableArrayTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ArrayTypeSyntax ArrayType 
		{ 
			get { return this.GetRed(ref this.arrayType, 0); } 
		}
	    public SyntaxToken TExclamation 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NonNullableArrayTypeGreen)this.Green;
				var greenToken = green.TExclamation;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.arrayType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.arrayType;
				default: return null;
	        }
	    }
	
	    public NonNullableArrayTypeSyntax WithArrayType(ArrayTypeSyntax arrayType)
		{
			return this.Update(ArrayType, this.TExclamation);
		}
	
	    public NonNullableArrayTypeSyntax WithTExclamation(SyntaxToken tExclamation)
		{
			return this.Update(this.ArrayType, TExclamation);
		}
	
	    public NonNullableArrayTypeSyntax Update(ArrayTypeSyntax arrayType, SyntaxToken tExclamation)
	    {
	        if (this.ArrayType != arrayType ||
				this.TExclamation != tExclamation)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NonNullableArrayType(arrayType, tExclamation);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NonNullableArrayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNonNullableArrayType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNonNullableArrayType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNonNullableArrayType(this);
	    }
	}
	
	public sealed class ArrayTypeSyntax : SoalSyntaxNode
	{
	    private SimpleArrayTypeSyntax simpleArrayType;
	    private NulledArrayTypeSyntax nulledArrayType;
	
	    public ArrayTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArrayTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SimpleArrayTypeSyntax SimpleArrayType 
		{ 
			get { return this.GetRed(ref this.simpleArrayType, 0); } 
		}
	    public NulledArrayTypeSyntax NulledArrayType 
		{ 
			get { return this.GetRed(ref this.nulledArrayType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.simpleArrayType, 0);
				case 1: return this.GetRed(ref this.nulledArrayType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.simpleArrayType;
				case 1: return this.nulledArrayType;
				default: return null;
	        }
	    }
	
	    public ArrayTypeSyntax WithSimpleArrayType(SimpleArrayTypeSyntax simpleArrayType)
		{
			return this.Update(simpleArrayType);
		}
	
	    public ArrayTypeSyntax WithNulledArrayType(NulledArrayTypeSyntax nulledArrayType)
		{
			return this.Update(nulledArrayType);
		}
	
	    public ArrayTypeSyntax Update(SimpleArrayTypeSyntax simpleArrayType)
	    {
	        if (this.SimpleArrayType != simpleArrayType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ArrayType(simpleArrayType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ArrayTypeSyntax Update(NulledArrayTypeSyntax nulledArrayType)
	    {
	        if (this.NulledArrayType != nulledArrayType)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ArrayType(nulledArrayType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrayType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrayType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitArrayType(this);
	    }
	}
	
	public sealed class SimpleArrayTypeSyntax : SoalSyntaxNode
	{
	    private SimpleTypeSyntax simpleType;
	
	    public SimpleArrayTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleArrayTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SimpleTypeSyntax SimpleType 
		{ 
			get { return this.GetRed(ref this.simpleType, 0); } 
		}
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SimpleArrayTypeGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.SimpleArrayTypeGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.simpleType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.simpleType;
				default: return null;
	        }
	    }
	
	    public SimpleArrayTypeSyntax WithSimpleType(SimpleTypeSyntax simpleType)
		{
			return this.Update(SimpleType, this.TOpenBracket, this.TCloseBracket);
		}
	
	    public SimpleArrayTypeSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(this.SimpleType, TOpenBracket, this.TCloseBracket);
		}
	
	    public SimpleArrayTypeSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.SimpleType, this.TOpenBracket, TCloseBracket);
		}
	
	    public SimpleArrayTypeSyntax Update(SimpleTypeSyntax simpleType, SyntaxToken tOpenBracket, SyntaxToken tCloseBracket)
	    {
	        if (this.SimpleType != simpleType ||
				this.TOpenBracket != tOpenBracket ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.SimpleArrayType(simpleType, tOpenBracket, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleArrayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleArrayType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleArrayType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleArrayType(this);
	    }
	}
	
	public sealed class NulledArrayTypeSyntax : SoalSyntaxNode
	{
	    private NulledTypeSyntax nulledType;
	
	    public NulledArrayTypeSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NulledArrayTypeSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NulledTypeSyntax NulledType 
		{ 
			get { return this.GetRed(ref this.nulledType, 0); } 
		}
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NulledArrayTypeGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NulledArrayTypeGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.nulledType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.nulledType;
				default: return null;
	        }
	    }
	
	    public NulledArrayTypeSyntax WithNulledType(NulledTypeSyntax nulledType)
		{
			return this.Update(NulledType, this.TOpenBracket, this.TCloseBracket);
		}
	
	    public NulledArrayTypeSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(this.NulledType, TOpenBracket, this.TCloseBracket);
		}
	
	    public NulledArrayTypeSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.NulledType, this.TOpenBracket, TCloseBracket);
		}
	
	    public NulledArrayTypeSyntax Update(NulledTypeSyntax nulledType, SyntaxToken tOpenBracket, SyntaxToken tCloseBracket)
	    {
	        if (this.NulledType != nulledType ||
				this.TOpenBracket != tOpenBracket ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NulledArrayType(nulledType, tOpenBracket, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NulledArrayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNulledArrayType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNulledArrayType(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNulledArrayType(this);
	    }
	}
	
	public sealed class ConstantValueSyntax : SoalSyntaxNode
	{
	    private LiteralSyntax literal;
	    private IdentifierSyntax identifier;
	
	    public ConstantValueSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ConstantValueSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LiteralSyntax Literal 
		{ 
			get { return this.GetRed(ref this.literal, 0); } 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.literal, 0);
				case 1: return this.GetRed(ref this.identifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.literal;
				case 1: return this.identifier;
				default: return null;
	        }
	    }
	
	    public ConstantValueSyntax WithLiteral(LiteralSyntax literal)
		{
			return this.Update(literal);
		}
	
	    public ConstantValueSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(identifier);
		}
	
	    public ConstantValueSyntax Update(LiteralSyntax literal)
	    {
	        if (this.Literal != literal)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ConstantValue(literal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConstantValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ConstantValueSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ConstantValue(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConstantValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitConstantValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitConstantValue(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitConstantValue(this);
	    }
	}
	
	public sealed class TypeofValueSyntax : SoalSyntaxNode
	{
	    private ReturnTypeSyntax returnType;
	
	    public TypeofValueSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeofValueSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTypeof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.TypeofValueGreen)this.Green;
				var greenToken = green.KTypeof;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.TypeofValueGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ReturnTypeSyntax ReturnType 
		{ 
			get { return this.GetRed(ref this.returnType, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.TypeofValueGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.returnType, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.returnType;
				default: return null;
	        }
	    }
	
	    public TypeofValueSyntax WithKTypeof(SyntaxToken kTypeof)
		{
			return this.Update(KTypeof, this.TOpenParen, this.ReturnType, this.TCloseParen);
		}
	
	    public TypeofValueSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.KTypeof, TOpenParen, this.ReturnType, this.TCloseParen);
		}
	
	    public TypeofValueSyntax WithReturnType(ReturnTypeSyntax returnType)
		{
			return this.Update(this.KTypeof, this.TOpenParen, ReturnType, this.TCloseParen);
		}
	
	    public TypeofValueSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.KTypeof, this.TOpenParen, this.ReturnType, TCloseParen);
		}
	
	    public TypeofValueSyntax Update(SyntaxToken kTypeof, SyntaxToken tOpenParen, ReturnTypeSyntax returnType, SyntaxToken tCloseParen)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParen != tOpenParen ||
				this.ReturnType != returnType ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.TypeofValue(kTypeof, tOpenParen, returnType, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeofValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeofValue(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeofValue(this);
	    }
	}
	
	public sealed class IdentifierSyntax : SoalSyntaxNode
	{
	    private IdentifiersSyntax identifiers;
	    private ContextualKeywordsSyntax contextualKeywords;
	
	    public IdentifierSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifiersSyntax Identifiers 
		{ 
			get { return this.GetRed(ref this.identifiers, 0); } 
		}
	    public ContextualKeywordsSyntax ContextualKeywords 
		{ 
			get { return this.GetRed(ref this.contextualKeywords, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifiers, 0);
				case 1: return this.GetRed(ref this.contextualKeywords, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifiers;
				case 1: return this.contextualKeywords;
				default: return null;
	        }
	    }
	
	    public IdentifierSyntax WithIdentifiers(IdentifiersSyntax identifiers)
		{
			return this.Update(identifiers);
		}
	
	    public IdentifierSyntax WithContextualKeywords(ContextualKeywordsSyntax contextualKeywords)
		{
			return this.Update(contextualKeywords);
		}
	
	    public IdentifierSyntax Update(IdentifiersSyntax identifiers)
	    {
	        if (this.Identifiers != identifiers)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Identifier(identifiers);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public IdentifierSyntax Update(ContextualKeywordsSyntax contextualKeywords)
	    {
	        if (this.ContextualKeywords != contextualKeywords)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Identifier(contextualKeywords);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class IdentifiersSyntax : SoalSyntaxNode
	{
	
	    public IdentifiersSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifiersSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Identifiers 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.IdentifiersGreen)this.Green;
				var greenToken = green.Identifiers;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public IdentifiersSyntax WithIdentifiers(SyntaxToken identifiers)
		{
			return this.Update(Identifiers);
		}
	
	    public IdentifiersSyntax Update(SyntaxToken identifiers)
	    {
	        if (this.Identifiers != identifiers)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Identifiers(identifiers);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifiersSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifiers(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifiers(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifiers(this);
	    }
	}
	
	public sealed class LiteralSyntax : SoalSyntaxNode
	{
	    private NullLiteralSyntax nullLiteral;
	    private BooleanLiteralSyntax booleanLiteral;
	    private IntegerLiteralSyntax integerLiteral;
	    private DecimalLiteralSyntax decimalLiteral;
	    private ScientificLiteralSyntax scientificLiteral;
	    private StringLiteralSyntax stringLiteral;
	
	    public LiteralSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Literal(nullLiteral);
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Literal(booleanLiteral);
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Literal(integerLiteral);
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Literal(decimalLiteral);
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Literal(scientificLiteral);
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.Literal(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteral(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteral(this);
	    }
	}
	
	public sealed class NullLiteralSyntax : SoalSyntaxNode
	{
	
	    public NullLiteralSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullLiteralSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNull 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.NullLiteralGreen)this.Green;
				var greenToken = green.KNull;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.NullLiteral(kNull);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullLiteral(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitNullLiteral(this);
	    }
	}
	
	public sealed class BooleanLiteralSyntax : SoalSyntaxNode
	{
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BooleanLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.BooleanLiteralGreen)this.Green;
				var greenToken = green.BooleanLiteral;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.BooleanLiteral(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BooleanLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBooleanLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBooleanLiteral(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitBooleanLiteral(this);
	    }
	}
	
	public sealed class IntegerLiteralSyntax : SoalSyntaxNode
	{
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LInteger 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.IntegerLiteralGreen)this.Green;
				var greenToken = green.LInteger;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.IntegerLiteral(lInteger);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIntegerLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIntegerLiteral(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitIntegerLiteral(this);
	    }
	}
	
	public sealed class DecimalLiteralSyntax : SoalSyntaxNode
	{
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LDecimal 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.DecimalLiteralGreen)this.Green;
				var greenToken = green.LDecimal;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.DecimalLiteral(lDecimal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DecimalLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDecimalLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDecimalLiteral(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitDecimalLiteral(this);
	    }
	}
	
	public sealed class ScientificLiteralSyntax : SoalSyntaxNode
	{
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LScientific 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ScientificLiteralGreen)this.Green;
				var greenToken = green.LScientific;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ScientificLiteral(lScientific);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ScientificLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitScientificLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitScientificLiteral(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitScientificLiteral(this);
	    }
	}
	
	public sealed class StringLiteralSyntax : SoalSyntaxNode
	{
	
	    public StringLiteralSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringLiteralSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken StringLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.StringLiteralGreen)this.Green;
				var greenToken = green.StringLiteral;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = SoalLanguage.Instance.SyntaxFactory.StringLiteral(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStringLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStringLiteral(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitStringLiteral(this);
	    }
	}
	
	public sealed class ContextualKeywordsSyntax : SoalSyntaxNode
	{
	
	    public ContextualKeywordsSyntax(InternalSyntaxNode green, SoalSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ContextualKeywordsSyntax(InternalSyntaxNode green, SoalSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ContextualKeywords 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Soal.Syntax.InternalSyntax.ContextualKeywordsGreen)this.Green;
				var greenToken = green.ContextualKeywords;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	
	    public ContextualKeywordsSyntax WithContextualKeywords(SyntaxToken contextualKeywords)
		{
			return this.Update(ContextualKeywords);
		}
	
	    public ContextualKeywordsSyntax Update(SyntaxToken contextualKeywords)
	    {
	        if (this.ContextualKeywords != contextualKeywords)
	        {
	            var newNode = SoalLanguage.Instance.SyntaxFactory.ContextualKeywords(contextualKeywords);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ContextualKeywordsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ISoalSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitContextualKeywords(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ISoalSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitContextualKeywords(this);
	    }
	
	    public override void Accept(ISoalSyntaxVisitor visitor)
	    {
	        visitor.VisitContextualKeywords(this);
	    }
	}
}

namespace MetaDslx.Languages.Soal
{
    using System.Threading;
    using Microsoft.CodeAnalysis.Text;
	using MetaDslx.Languages.Soal.Syntax;
    using MetaDslx.Languages.Soal.Syntax.InternalSyntax;

	public interface ISoalSyntaxVisitor
	{
		
		void VisitMain(MainSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitIdentifierList(IdentifierListSyntax node);
		
		void VisitQualifierList(QualifierListSyntax node);
		
		void VisitAnnotationList(AnnotationListSyntax node);
		
		void VisitReturnAnnotationList(ReturnAnnotationListSyntax node);
		
		void VisitAnnotation(AnnotationSyntax node);
		
		void VisitReturnAnnotation(ReturnAnnotationSyntax node);
		
		void VisitAnnotationHead(AnnotationHeadSyntax node);
		
		void VisitAnnotationBody(AnnotationBodySyntax node);
		
		void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node);
		
		void VisitAnnotationProperty(AnnotationPropertySyntax node);
		
		void VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node);
		
		void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		void VisitNamespacePrefix(NamespacePrefixSyntax node);
		
		void VisitNamespaceUri(NamespaceUriSyntax node);
		
		void VisitNamespaceBody(NamespaceBodySyntax node);
		
		void VisitDeclaration(DeclarationSyntax node);
		
		void VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		void VisitEnumBase(EnumBaseSyntax node);
		
		void VisitEnumBody(EnumBodySyntax node);
		
		void VisitEnumLiterals(EnumLiteralsSyntax node);
		
		void VisitEnumLiteral(EnumLiteralSyntax node);
		
		void VisitStructDeclaration(StructDeclarationSyntax node);
		
		void VisitStructBody(StructBodySyntax node);
		
		void VisitPropertyDeclaration(PropertyDeclarationSyntax node);
		
		void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node);
		
		void VisitDatabaseBody(DatabaseBodySyntax node);
		
		void VisitEntityReference(EntityReferenceSyntax node);
		
		void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node);
		
		void VisitInterfaceBody(InterfaceBodySyntax node);
		
		void VisitOperationDeclaration(OperationDeclarationSyntax node);
		
		void VisitOperationHead(OperationHeadSyntax node);
		
		void VisitParameterList(ParameterListSyntax node);
		
		void VisitParameter(ParameterSyntax node);
		
		void VisitOperationResult(OperationResultSyntax node);
		
		void VisitThrowsList(ThrowsListSyntax node);
		
		void VisitComponentDeclaration(ComponentDeclarationSyntax node);
		
		void VisitComponentBase(ComponentBaseSyntax node);
		
		void VisitComponentBody(ComponentBodySyntax node);
		
		void VisitComponentElements(ComponentElementsSyntax node);
		
		void VisitComponentElement(ComponentElementSyntax node);
		
		void VisitComponentService(ComponentServiceSyntax node);
		
		void VisitComponentReference(ComponentReferenceSyntax node);
		
		void VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node);
		
		void VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node);
		
		void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node);
		
		void VisitComponentProperty(ComponentPropertySyntax node);
		
		void VisitComponentImplementation(ComponentImplementationSyntax node);
		
		void VisitComponentLanguage(ComponentLanguageSyntax node);
		
		void VisitCompositeDeclaration(CompositeDeclarationSyntax node);
		
		void VisitCompositeBody(CompositeBodySyntax node);
		
		void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node);
		
		void VisitCompositeElements(CompositeElementsSyntax node);
		
		void VisitCompositeElement(CompositeElementSyntax node);
		
		void VisitCompositeComponent(CompositeComponentSyntax node);
		
		void VisitCompositeWire(CompositeWireSyntax node);
		
		void VisitWireSource(WireSourceSyntax node);
		
		void VisitWireTarget(WireTargetSyntax node);
		
		void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node);
		
		void VisitDeploymentBody(DeploymentBodySyntax node);
		
		void VisitDeploymentElements(DeploymentElementsSyntax node);
		
		void VisitDeploymentElement(DeploymentElementSyntax node);
		
		void VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node);
		
		void VisitEnvironmentBody(EnvironmentBodySyntax node);
		
		void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node);
		
		void VisitRuntimeReference(RuntimeReferenceSyntax node);
		
		void VisitAssemblyReference(AssemblyReferenceSyntax node);
		
		void VisitDatabaseReference(DatabaseReferenceSyntax node);
		
		void VisitBindingDeclaration(BindingDeclarationSyntax node);
		
		void VisitBindingBody(BindingBodySyntax node);
		
		void VisitBindingLayers(BindingLayersSyntax node);
		
		void VisitTransportLayer(TransportLayerSyntax node);
		
		void VisitHttpTransportLayer(HttpTransportLayerSyntax node);
		
		void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node);
		
		void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node);
		
		void VisitRestTransportLayer(RestTransportLayerSyntax node);
		
		void VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node);
		
		void VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node);
		
		void VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node);
		
		void VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node);
		
		void VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node);
		
		void VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node);
		
		void VisitHttpSslProperty(HttpSslPropertySyntax node);
		
		void VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node);
		
		void VisitEncodingLayer(EncodingLayerSyntax node);
		
		void VisitSoapEncodingLayer(SoapEncodingLayerSyntax node);
		
		void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node);
		
		void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node);
		
		void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node);
		
		void VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node);
		
		void VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node);
		
		void VisitJsonEncodingLayer(JsonEncodingLayerSyntax node);
		
		void VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node);
		
		void VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node);
		
		void VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node);
		
		void VisitSoapVersionProperty(SoapVersionPropertySyntax node);
		
		void VisitSoapMtomProperty(SoapMtomPropertySyntax node);
		
		void VisitSoapStyleProperty(SoapStylePropertySyntax node);
		
		void VisitProtocolLayer(ProtocolLayerSyntax node);
		
		void VisitProtocolLayerKind(ProtocolLayerKindSyntax node);
		
		void VisitWsAddressing(WsAddressingSyntax node);
		
		void VisitEndpointDeclaration(EndpointDeclarationSyntax node);
		
		void VisitEndpointBody(EndpointBodySyntax node);
		
		void VisitEndpointProperties(EndpointPropertiesSyntax node);
		
		void VisitEndpointProperty(EndpointPropertySyntax node);
		
		void VisitEndpointBindingProperty(EndpointBindingPropertySyntax node);
		
		void VisitEndpointAddressProperty(EndpointAddressPropertySyntax node);
		
		void VisitReturnType(ReturnTypeSyntax node);
		
		void VisitTypeReference(TypeReferenceSyntax node);
		
		void VisitSimpleType(SimpleTypeSyntax node);
		
		void VisitNulledType(NulledTypeSyntax node);
		
		void VisitReferenceType(ReferenceTypeSyntax node);
		
		void VisitObjectType(ObjectTypeSyntax node);
		
		void VisitValueType(ValueTypeSyntax node);
		
		void VisitVoidType(VoidTypeSyntax node);
		
		void VisitOnewayType(OnewayTypeSyntax node);
		
		void VisitOperationReturnType(OperationReturnTypeSyntax node);
		
		void VisitNullableType(NullableTypeSyntax node);
		
		void VisitNonNullableType(NonNullableTypeSyntax node);
		
		void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node);
		
		void VisitArrayType(ArrayTypeSyntax node);
		
		void VisitSimpleArrayType(SimpleArrayTypeSyntax node);
		
		void VisitNulledArrayType(NulledArrayTypeSyntax node);
		
		void VisitConstantValue(ConstantValueSyntax node);
		
		void VisitTypeofValue(TypeofValueSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitIdentifiers(IdentifiersSyntax node);
		
		void VisitLiteral(LiteralSyntax node);
		
		void VisitNullLiteral(NullLiteralSyntax node);
		
		void VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		void VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		void VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		void VisitScientificLiteral(ScientificLiteralSyntax node);
		
		void VisitStringLiteral(StringLiteralSyntax node);
		
		void VisitContextualKeywords(ContextualKeywordsSyntax node);
	}
	
	public class SoalSyntaxVisitor : SyntaxVisitor, ISoalSyntaxVisitor
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
		
		public virtual void VisitIdentifierList(IdentifierListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifierList(QualifierListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAnnotationList(AnnotationListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAnnotation(AnnotationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAnnotationHead(AnnotationHeadSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAnnotationBody(AnnotationBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespacePrefix(NamespacePrefixSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceUri(NamespaceUriSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
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
		
		public virtual void VisitEnumBase(EnumBaseSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnumLiteral(EnumLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStructDeclaration(StructDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStructBody(StructBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDatabaseBody(DatabaseBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEntityReference(EntityReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInterfaceBody(InterfaceBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOperationHead(OperationHeadSyntax node)
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
		
		public virtual void VisitOperationResult(OperationResultSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitThrowsList(ThrowsListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentBase(ComponentBaseSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentBody(ComponentBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentElements(ComponentElementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentElement(ComponentElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentService(ComponentServiceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentReference(ComponentReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentProperty(ComponentPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentImplementation(ComponentImplementationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComponentLanguage(ComponentLanguageSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCompositeBody(CompositeBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCompositeElements(CompositeElementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCompositeElement(CompositeElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCompositeComponent(CompositeComponentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCompositeWire(CompositeWireSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWireSource(WireSourceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWireTarget(WireTargetSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeploymentBody(DeploymentBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeploymentElements(DeploymentElementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeploymentElement(DeploymentElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBindingBody(BindingBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBindingLayers(BindingLayersSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTransportLayer(TransportLayerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEncodingLayer(EncodingLayerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitProtocolLayer(ProtocolLayerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWsAddressing(WsAddressingSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEndpointBody(EndpointBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEndpointProperty(EndpointPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
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
		
		public virtual void VisitNulledType(NulledTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitReferenceType(ReferenceTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitValueType(ValueTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOnewayType(OnewayTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNonNullableType(NonNullableTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrayType(ArrayTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitConstantValue(ConstantValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeofValue(TypeofValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifiers(IdentifiersSyntax node)
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
		
		public virtual void VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	//GenerateDetailedSyntaxVisitor()

	public interface ISoalSyntaxVisitor<TArg, TResult> 
	{
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitName(NameSyntax node, TArg argument);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument);
		
		TResult VisitQualifier(QualifierSyntax node, TArg argument);
		
		TResult VisitIdentifierList(IdentifierListSyntax node, TArg argument);
		
		TResult VisitQualifierList(QualifierListSyntax node, TArg argument);
		
		TResult VisitAnnotationList(AnnotationListSyntax node, TArg argument);
		
		TResult VisitReturnAnnotationList(ReturnAnnotationListSyntax node, TArg argument);
		
		TResult VisitAnnotation(AnnotationSyntax node, TArg argument);
		
		TResult VisitReturnAnnotation(ReturnAnnotationSyntax node, TArg argument);
		
		TResult VisitAnnotationHead(AnnotationHeadSyntax node, TArg argument);
		
		TResult VisitAnnotationBody(AnnotationBodySyntax node, TArg argument);
		
		TResult VisitAnnotationPropertyList(AnnotationPropertyListSyntax node, TArg argument);
		
		TResult VisitAnnotationProperty(AnnotationPropertySyntax node, TArg argument);
		
		TResult VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument);
		
		TResult VisitNamespacePrefix(NamespacePrefixSyntax node, TArg argument);
		
		TResult VisitNamespaceUri(NamespaceUriSyntax node, TArg argument);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node, TArg argument);
		
		TResult VisitDeclaration(DeclarationSyntax node, TArg argument);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node, TArg argument);
		
		TResult VisitEnumBase(EnumBaseSyntax node, TArg argument);
		
		TResult VisitEnumBody(EnumBodySyntax node, TArg argument);
		
		TResult VisitEnumLiterals(EnumLiteralsSyntax node, TArg argument);
		
		TResult VisitEnumLiteral(EnumLiteralSyntax node, TArg argument);
		
		TResult VisitStructDeclaration(StructDeclarationSyntax node, TArg argument);
		
		TResult VisitStructBody(StructBodySyntax node, TArg argument);
		
		TResult VisitPropertyDeclaration(PropertyDeclarationSyntax node, TArg argument);
		
		TResult VisitDatabaseDeclaration(DatabaseDeclarationSyntax node, TArg argument);
		
		TResult VisitDatabaseBody(DatabaseBodySyntax node, TArg argument);
		
		TResult VisitEntityReference(EntityReferenceSyntax node, TArg argument);
		
		TResult VisitInterfaceDeclaration(InterfaceDeclarationSyntax node, TArg argument);
		
		TResult VisitInterfaceBody(InterfaceBodySyntax node, TArg argument);
		
		TResult VisitOperationDeclaration(OperationDeclarationSyntax node, TArg argument);
		
		TResult VisitOperationHead(OperationHeadSyntax node, TArg argument);
		
		TResult VisitParameterList(ParameterListSyntax node, TArg argument);
		
		TResult VisitParameter(ParameterSyntax node, TArg argument);
		
		TResult VisitOperationResult(OperationResultSyntax node, TArg argument);
		
		TResult VisitThrowsList(ThrowsListSyntax node, TArg argument);
		
		TResult VisitComponentDeclaration(ComponentDeclarationSyntax node, TArg argument);
		
		TResult VisitComponentBase(ComponentBaseSyntax node, TArg argument);
		
		TResult VisitComponentBody(ComponentBodySyntax node, TArg argument);
		
		TResult VisitComponentElements(ComponentElementsSyntax node, TArg argument);
		
		TResult VisitComponentElement(ComponentElementSyntax node, TArg argument);
		
		TResult VisitComponentService(ComponentServiceSyntax node, TArg argument);
		
		TResult VisitComponentReference(ComponentReferenceSyntax node, TArg argument);
		
		TResult VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node, TArg argument);
		
		TResult VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node, TArg argument);
		
		TResult VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node, TArg argument);
		
		TResult VisitComponentProperty(ComponentPropertySyntax node, TArg argument);
		
		TResult VisitComponentImplementation(ComponentImplementationSyntax node, TArg argument);
		
		TResult VisitComponentLanguage(ComponentLanguageSyntax node, TArg argument);
		
		TResult VisitCompositeDeclaration(CompositeDeclarationSyntax node, TArg argument);
		
		TResult VisitCompositeBody(CompositeBodySyntax node, TArg argument);
		
		TResult VisitAssemblyDeclaration(AssemblyDeclarationSyntax node, TArg argument);
		
		TResult VisitCompositeElements(CompositeElementsSyntax node, TArg argument);
		
		TResult VisitCompositeElement(CompositeElementSyntax node, TArg argument);
		
		TResult VisitCompositeComponent(CompositeComponentSyntax node, TArg argument);
		
		TResult VisitCompositeWire(CompositeWireSyntax node, TArg argument);
		
		TResult VisitWireSource(WireSourceSyntax node, TArg argument);
		
		TResult VisitWireTarget(WireTargetSyntax node, TArg argument);
		
		TResult VisitDeploymentDeclaration(DeploymentDeclarationSyntax node, TArg argument);
		
		TResult VisitDeploymentBody(DeploymentBodySyntax node, TArg argument);
		
		TResult VisitDeploymentElements(DeploymentElementsSyntax node, TArg argument);
		
		TResult VisitDeploymentElement(DeploymentElementSyntax node, TArg argument);
		
		TResult VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node, TArg argument);
		
		TResult VisitEnvironmentBody(EnvironmentBodySyntax node, TArg argument);
		
		TResult VisitRuntimeDeclaration(RuntimeDeclarationSyntax node, TArg argument);
		
		TResult VisitRuntimeReference(RuntimeReferenceSyntax node, TArg argument);
		
		TResult VisitAssemblyReference(AssemblyReferenceSyntax node, TArg argument);
		
		TResult VisitDatabaseReference(DatabaseReferenceSyntax node, TArg argument);
		
		TResult VisitBindingDeclaration(BindingDeclarationSyntax node, TArg argument);
		
		TResult VisitBindingBody(BindingBodySyntax node, TArg argument);
		
		TResult VisitBindingLayers(BindingLayersSyntax node, TArg argument);
		
		TResult VisitTransportLayer(TransportLayerSyntax node, TArg argument);
		
		TResult VisitHttpTransportLayer(HttpTransportLayerSyntax node, TArg argument);
		
		TResult VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node, TArg argument);
		
		TResult VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node, TArg argument);
		
		TResult VisitRestTransportLayer(RestTransportLayerSyntax node, TArg argument);
		
		TResult VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node, TArg argument);
		
		TResult VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node, TArg argument);
		
		TResult VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node, TArg argument);
		
		TResult VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node, TArg argument);
		
		TResult VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node, TArg argument);
		
		TResult VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node, TArg argument);
		
		TResult VisitHttpSslProperty(HttpSslPropertySyntax node, TArg argument);
		
		TResult VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node, TArg argument);
		
		TResult VisitEncodingLayer(EncodingLayerSyntax node, TArg argument);
		
		TResult VisitSoapEncodingLayer(SoapEncodingLayerSyntax node, TArg argument);
		
		TResult VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node, TArg argument);
		
		TResult VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node, TArg argument);
		
		TResult VisitXmlEncodingLayer(XmlEncodingLayerSyntax node, TArg argument);
		
		TResult VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node, TArg argument);
		
		TResult VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node, TArg argument);
		
		TResult VisitJsonEncodingLayer(JsonEncodingLayerSyntax node, TArg argument);
		
		TResult VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node, TArg argument);
		
		TResult VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node, TArg argument);
		
		TResult VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node, TArg argument);
		
		TResult VisitSoapVersionProperty(SoapVersionPropertySyntax node, TArg argument);
		
		TResult VisitSoapMtomProperty(SoapMtomPropertySyntax node, TArg argument);
		
		TResult VisitSoapStyleProperty(SoapStylePropertySyntax node, TArg argument);
		
		TResult VisitProtocolLayer(ProtocolLayerSyntax node, TArg argument);
		
		TResult VisitProtocolLayerKind(ProtocolLayerKindSyntax node, TArg argument);
		
		TResult VisitWsAddressing(WsAddressingSyntax node, TArg argument);
		
		TResult VisitEndpointDeclaration(EndpointDeclarationSyntax node, TArg argument);
		
		TResult VisitEndpointBody(EndpointBodySyntax node, TArg argument);
		
		TResult VisitEndpointProperties(EndpointPropertiesSyntax node, TArg argument);
		
		TResult VisitEndpointProperty(EndpointPropertySyntax node, TArg argument);
		
		TResult VisitEndpointBindingProperty(EndpointBindingPropertySyntax node, TArg argument);
		
		TResult VisitEndpointAddressProperty(EndpointAddressPropertySyntax node, TArg argument);
		
		TResult VisitReturnType(ReturnTypeSyntax node, TArg argument);
		
		TResult VisitTypeReference(TypeReferenceSyntax node, TArg argument);
		
		TResult VisitSimpleType(SimpleTypeSyntax node, TArg argument);
		
		TResult VisitNulledType(NulledTypeSyntax node, TArg argument);
		
		TResult VisitReferenceType(ReferenceTypeSyntax node, TArg argument);
		
		TResult VisitObjectType(ObjectTypeSyntax node, TArg argument);
		
		TResult VisitValueType(ValueTypeSyntax node, TArg argument);
		
		TResult VisitVoidType(VoidTypeSyntax node, TArg argument);
		
		TResult VisitOnewayType(OnewayTypeSyntax node, TArg argument);
		
		TResult VisitOperationReturnType(OperationReturnTypeSyntax node, TArg argument);
		
		TResult VisitNullableType(NullableTypeSyntax node, TArg argument);
		
		TResult VisitNonNullableType(NonNullableTypeSyntax node, TArg argument);
		
		TResult VisitNonNullableArrayType(NonNullableArrayTypeSyntax node, TArg argument);
		
		TResult VisitArrayType(ArrayTypeSyntax node, TArg argument);
		
		TResult VisitSimpleArrayType(SimpleArrayTypeSyntax node, TArg argument);
		
		TResult VisitNulledArrayType(NulledArrayTypeSyntax node, TArg argument);
		
		TResult VisitConstantValue(ConstantValueSyntax node, TArg argument);
		
		TResult VisitTypeofValue(TypeofValueSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
		TResult VisitIdentifiers(IdentifiersSyntax node, TArg argument);
		
		TResult VisitLiteral(LiteralSyntax node, TArg argument);
		
		TResult VisitNullLiteral(NullLiteralSyntax node, TArg argument);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node, TArg argument);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node, TArg argument);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node, TArg argument);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node, TArg argument);
		
		TResult VisitStringLiteral(StringLiteralSyntax node, TArg argument);
		
		TResult VisitContextualKeywords(ContextualKeywordsSyntax node, TArg argument);
	}
	
	public class SoalSyntaxVisitor<TArg, TResult> : SyntaxVisitor<TArg, TResult>, ISoalSyntaxVisitor<TArg, TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitName(NameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQualifier(QualifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifierList(IdentifierListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQualifierList(QualifierListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAnnotationList(AnnotationListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitReturnAnnotationList(ReturnAnnotationListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAnnotation(AnnotationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitReturnAnnotation(ReturnAnnotationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAnnotationHead(AnnotationHeadSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAnnotationBody(AnnotationBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAnnotationPropertyList(AnnotationPropertyListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAnnotationProperty(AnnotationPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespacePrefix(NamespacePrefixSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceUri(NamespaceUriSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody(NamespaceBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration(DeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnumDeclaration(EnumDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnumBase(EnumBaseSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnumBody(EnumBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnumLiterals(EnumLiteralsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnumLiteral(EnumLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStructDeclaration(StructDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStructBody(StructBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPropertyDeclaration(PropertyDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDatabaseDeclaration(DatabaseDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDatabaseBody(DatabaseBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEntityReference(EntityReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitInterfaceDeclaration(InterfaceDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitInterfaceBody(InterfaceBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOperationDeclaration(OperationDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOperationHead(OperationHeadSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParameterList(ParameterListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParameter(ParameterSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOperationResult(OperationResultSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitThrowsList(ThrowsListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentDeclaration(ComponentDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentBase(ComponentBaseSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentBody(ComponentBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentElements(ComponentElementsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentElement(ComponentElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentService(ComponentServiceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentReference(ComponentReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentProperty(ComponentPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentImplementation(ComponentImplementationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComponentLanguage(ComponentLanguageSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCompositeDeclaration(CompositeDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCompositeBody(CompositeBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAssemblyDeclaration(AssemblyDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCompositeElements(CompositeElementsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCompositeElement(CompositeElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCompositeComponent(CompositeComponentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCompositeWire(CompositeWireSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWireSource(WireSourceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWireTarget(WireTargetSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeploymentDeclaration(DeploymentDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeploymentBody(DeploymentBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeploymentElements(DeploymentElementsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeploymentElement(DeploymentElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnvironmentBody(EnvironmentBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRuntimeDeclaration(RuntimeDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRuntimeReference(RuntimeReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAssemblyReference(AssemblyReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDatabaseReference(DatabaseReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBindingDeclaration(BindingDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBindingBody(BindingBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBindingLayers(BindingLayersSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTransportLayer(TransportLayerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitHttpTransportLayer(HttpTransportLayerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRestTransportLayer(RestTransportLayerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitHttpSslProperty(HttpSslPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEncodingLayer(EncodingLayerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSoapEncodingLayer(SoapEncodingLayerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitXmlEncodingLayer(XmlEncodingLayerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitJsonEncodingLayer(JsonEncodingLayerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSoapVersionProperty(SoapVersionPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSoapMtomProperty(SoapMtomPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSoapStyleProperty(SoapStylePropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitProtocolLayer(ProtocolLayerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitProtocolLayerKind(ProtocolLayerKindSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWsAddressing(WsAddressingSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEndpointDeclaration(EndpointDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEndpointBody(EndpointBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEndpointProperties(EndpointPropertiesSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEndpointProperty(EndpointPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEndpointBindingProperty(EndpointBindingPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEndpointAddressProperty(EndpointAddressPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitReturnType(ReturnTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeReference(TypeReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleType(SimpleTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNulledType(NulledTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitReferenceType(ReferenceTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitObjectType(ObjectTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitValueType(ValueTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVoidType(VoidTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOnewayType(OnewayTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOperationReturnType(OperationReturnTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNullableType(NullableTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNonNullableType(NonNullableTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNonNullableArrayType(NonNullableArrayTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrayType(ArrayTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleArrayType(SimpleArrayTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNulledArrayType(NulledArrayTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitConstantValue(ConstantValueSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeofValue(TypeofValueSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifiers(IdentifiersSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLiteral(LiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNullLiteral(NullLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBooleanLiteral(BooleanLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIntegerLiteral(IntegerLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDecimalLiteral(DecimalLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitScientificLiteral(ScientificLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStringLiteral(StringLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitContextualKeywords(ContextualKeywordsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
	}

	public interface ISoalSyntaxVisitor<TResult> 
	{
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitIdentifierList(IdentifierListSyntax node);
		
		TResult VisitQualifierList(QualifierListSyntax node);
		
		TResult VisitAnnotationList(AnnotationListSyntax node);
		
		TResult VisitReturnAnnotationList(ReturnAnnotationListSyntax node);
		
		TResult VisitAnnotation(AnnotationSyntax node);
		
		TResult VisitReturnAnnotation(ReturnAnnotationSyntax node);
		
		TResult VisitAnnotationHead(AnnotationHeadSyntax node);
		
		TResult VisitAnnotationBody(AnnotationBodySyntax node);
		
		TResult VisitAnnotationPropertyList(AnnotationPropertyListSyntax node);
		
		TResult VisitAnnotationProperty(AnnotationPropertySyntax node);
		
		TResult VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		TResult VisitNamespacePrefix(NamespacePrefixSyntax node);
		
		TResult VisitNamespaceUri(NamespaceUriSyntax node);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node);
		
		TResult VisitDeclaration(DeclarationSyntax node);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		TResult VisitEnumBase(EnumBaseSyntax node);
		
		TResult VisitEnumBody(EnumBodySyntax node);
		
		TResult VisitEnumLiterals(EnumLiteralsSyntax node);
		
		TResult VisitEnumLiteral(EnumLiteralSyntax node);
		
		TResult VisitStructDeclaration(StructDeclarationSyntax node);
		
		TResult VisitStructBody(StructBodySyntax node);
		
		TResult VisitPropertyDeclaration(PropertyDeclarationSyntax node);
		
		TResult VisitDatabaseDeclaration(DatabaseDeclarationSyntax node);
		
		TResult VisitDatabaseBody(DatabaseBodySyntax node);
		
		TResult VisitEntityReference(EntityReferenceSyntax node);
		
		TResult VisitInterfaceDeclaration(InterfaceDeclarationSyntax node);
		
		TResult VisitInterfaceBody(InterfaceBodySyntax node);
		
		TResult VisitOperationDeclaration(OperationDeclarationSyntax node);
		
		TResult VisitOperationHead(OperationHeadSyntax node);
		
		TResult VisitParameterList(ParameterListSyntax node);
		
		TResult VisitParameter(ParameterSyntax node);
		
		TResult VisitOperationResult(OperationResultSyntax node);
		
		TResult VisitThrowsList(ThrowsListSyntax node);
		
		TResult VisitComponentDeclaration(ComponentDeclarationSyntax node);
		
		TResult VisitComponentBase(ComponentBaseSyntax node);
		
		TResult VisitComponentBody(ComponentBodySyntax node);
		
		TResult VisitComponentElements(ComponentElementsSyntax node);
		
		TResult VisitComponentElement(ComponentElementSyntax node);
		
		TResult VisitComponentService(ComponentServiceSyntax node);
		
		TResult VisitComponentReference(ComponentReferenceSyntax node);
		
		TResult VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node);
		
		TResult VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node);
		
		TResult VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node);
		
		TResult VisitComponentProperty(ComponentPropertySyntax node);
		
		TResult VisitComponentImplementation(ComponentImplementationSyntax node);
		
		TResult VisitComponentLanguage(ComponentLanguageSyntax node);
		
		TResult VisitCompositeDeclaration(CompositeDeclarationSyntax node);
		
		TResult VisitCompositeBody(CompositeBodySyntax node);
		
		TResult VisitAssemblyDeclaration(AssemblyDeclarationSyntax node);
		
		TResult VisitCompositeElements(CompositeElementsSyntax node);
		
		TResult VisitCompositeElement(CompositeElementSyntax node);
		
		TResult VisitCompositeComponent(CompositeComponentSyntax node);
		
		TResult VisitCompositeWire(CompositeWireSyntax node);
		
		TResult VisitWireSource(WireSourceSyntax node);
		
		TResult VisitWireTarget(WireTargetSyntax node);
		
		TResult VisitDeploymentDeclaration(DeploymentDeclarationSyntax node);
		
		TResult VisitDeploymentBody(DeploymentBodySyntax node);
		
		TResult VisitDeploymentElements(DeploymentElementsSyntax node);
		
		TResult VisitDeploymentElement(DeploymentElementSyntax node);
		
		TResult VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node);
		
		TResult VisitEnvironmentBody(EnvironmentBodySyntax node);
		
		TResult VisitRuntimeDeclaration(RuntimeDeclarationSyntax node);
		
		TResult VisitRuntimeReference(RuntimeReferenceSyntax node);
		
		TResult VisitAssemblyReference(AssemblyReferenceSyntax node);
		
		TResult VisitDatabaseReference(DatabaseReferenceSyntax node);
		
		TResult VisitBindingDeclaration(BindingDeclarationSyntax node);
		
		TResult VisitBindingBody(BindingBodySyntax node);
		
		TResult VisitBindingLayers(BindingLayersSyntax node);
		
		TResult VisitTransportLayer(TransportLayerSyntax node);
		
		TResult VisitHttpTransportLayer(HttpTransportLayerSyntax node);
		
		TResult VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node);
		
		TResult VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node);
		
		TResult VisitRestTransportLayer(RestTransportLayerSyntax node);
		
		TResult VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node);
		
		TResult VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node);
		
		TResult VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node);
		
		TResult VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node);
		
		TResult VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node);
		
		TResult VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node);
		
		TResult VisitHttpSslProperty(HttpSslPropertySyntax node);
		
		TResult VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node);
		
		TResult VisitEncodingLayer(EncodingLayerSyntax node);
		
		TResult VisitSoapEncodingLayer(SoapEncodingLayerSyntax node);
		
		TResult VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node);
		
		TResult VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node);
		
		TResult VisitXmlEncodingLayer(XmlEncodingLayerSyntax node);
		
		TResult VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node);
		
		TResult VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node);
		
		TResult VisitJsonEncodingLayer(JsonEncodingLayerSyntax node);
		
		TResult VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node);
		
		TResult VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node);
		
		TResult VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node);
		
		TResult VisitSoapVersionProperty(SoapVersionPropertySyntax node);
		
		TResult VisitSoapMtomProperty(SoapMtomPropertySyntax node);
		
		TResult VisitSoapStyleProperty(SoapStylePropertySyntax node);
		
		TResult VisitProtocolLayer(ProtocolLayerSyntax node);
		
		TResult VisitProtocolLayerKind(ProtocolLayerKindSyntax node);
		
		TResult VisitWsAddressing(WsAddressingSyntax node);
		
		TResult VisitEndpointDeclaration(EndpointDeclarationSyntax node);
		
		TResult VisitEndpointBody(EndpointBodySyntax node);
		
		TResult VisitEndpointProperties(EndpointPropertiesSyntax node);
		
		TResult VisitEndpointProperty(EndpointPropertySyntax node);
		
		TResult VisitEndpointBindingProperty(EndpointBindingPropertySyntax node);
		
		TResult VisitEndpointAddressProperty(EndpointAddressPropertySyntax node);
		
		TResult VisitReturnType(ReturnTypeSyntax node);
		
		TResult VisitTypeReference(TypeReferenceSyntax node);
		
		TResult VisitSimpleType(SimpleTypeSyntax node);
		
		TResult VisitNulledType(NulledTypeSyntax node);
		
		TResult VisitReferenceType(ReferenceTypeSyntax node);
		
		TResult VisitObjectType(ObjectTypeSyntax node);
		
		TResult VisitValueType(ValueTypeSyntax node);
		
		TResult VisitVoidType(VoidTypeSyntax node);
		
		TResult VisitOnewayType(OnewayTypeSyntax node);
		
		TResult VisitOperationReturnType(OperationReturnTypeSyntax node);
		
		TResult VisitNullableType(NullableTypeSyntax node);
		
		TResult VisitNonNullableType(NonNullableTypeSyntax node);
		
		TResult VisitNonNullableArrayType(NonNullableArrayTypeSyntax node);
		
		TResult VisitArrayType(ArrayTypeSyntax node);
		
		TResult VisitSimpleArrayType(SimpleArrayTypeSyntax node);
		
		TResult VisitNulledArrayType(NulledArrayTypeSyntax node);
		
		TResult VisitConstantValue(ConstantValueSyntax node);
		
		TResult VisitTypeofValue(TypeofValueSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitIdentifiers(IdentifiersSyntax node);
		
		TResult VisitLiteral(LiteralSyntax node);
		
		TResult VisitNullLiteral(NullLiteralSyntax node);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node);
		
		TResult VisitStringLiteral(StringLiteralSyntax node);
		
		TResult VisitContextualKeywords(ContextualKeywordsSyntax node);
	}
	
	public class SoalSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, ISoalSyntaxVisitor<TResult>
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
		
		public virtual TResult VisitIdentifierList(IdentifierListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifierList(QualifierListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAnnotationList(AnnotationListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAnnotation(AnnotationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAnnotationHead(AnnotationHeadSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAnnotationBody(AnnotationBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespacePrefix(NamespacePrefixSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceUri(NamespaceUriSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody(NamespaceBodySyntax node)
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
		
		public virtual TResult VisitEnumBase(EnumBaseSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnumBody(EnumBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnumLiterals(EnumLiteralsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnumLiteral(EnumLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStructDeclaration(StructDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStructBody(StructBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDatabaseBody(DatabaseBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEntityReference(EntityReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInterfaceBody(InterfaceBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOperationHead(OperationHeadSyntax node)
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
		
		public virtual TResult VisitOperationResult(OperationResultSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitThrowsList(ThrowsListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentBase(ComponentBaseSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentBody(ComponentBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentElements(ComponentElementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentElement(ComponentElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentService(ComponentServiceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentReference(ComponentReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentProperty(ComponentPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentImplementation(ComponentImplementationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComponentLanguage(ComponentLanguageSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCompositeBody(CompositeBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCompositeElements(CompositeElementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCompositeElement(CompositeElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCompositeComponent(CompositeComponentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCompositeWire(CompositeWireSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWireSource(WireSourceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWireTarget(WireTargetSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeploymentBody(DeploymentBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeploymentElements(DeploymentElementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeploymentElement(DeploymentElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBindingBody(BindingBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBindingLayers(BindingLayersSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTransportLayer(TransportLayerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEncodingLayer(EncodingLayerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitProtocolLayer(ProtocolLayerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWsAddressing(WsAddressingSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEndpointBody(EndpointBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEndpointProperty(EndpointPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitReturnType(ReturnTypeSyntax node)
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
		
		public virtual TResult VisitNulledType(NulledTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitReferenceType(ReferenceTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitObjectType(ObjectTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitValueType(ValueTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVoidType(VoidTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOnewayType(OnewayTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNullableType(NullableTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNonNullableType(NonNullableTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrayType(ArrayTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitConstantValue(ConstantValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeofValue(TypeofValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifiers(IdentifiersSyntax node)
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
		
		public virtual TResult VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class SoalSyntaxRewriter : SyntaxRewriter, ISoalSyntaxVisitor<SyntaxNode>
	{
	    public SoalSyntaxRewriter(bool visitIntoStructuredTrivia = false)
			: base(SoalLanguage.Instance, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var namespaceDeclaration = this.VisitList(node.NamespaceDeclaration);
		    var eof = this.VisitToken(node.EndOfFileToken);
			return node.Update(namespaceDeclaration, eof);
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
		
		public virtual SyntaxNode VisitIdentifierList(IdentifierListSyntax node)
		{
		    var identifier = this.VisitList(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitQualifierList(QualifierListSyntax node)
		{
		    var qualifier = this.VisitList(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitAnnotationList(AnnotationListSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
			return node.Update(annotation);
		}
		
		public virtual SyntaxNode VisitReturnAnnotationList(ReturnAnnotationListSyntax node)
		{
		    var returnAnnotation = this.VisitList(node.ReturnAnnotation);
			return node.Update(returnAnnotation);
		}
		
		public virtual SyntaxNode VisitAnnotation(AnnotationSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var annotationHead = (AnnotationHeadSyntax)this.Visit(node.AnnotationHead);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, annotationHead, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitReturnAnnotation(ReturnAnnotationSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var kReturn = this.VisitToken(node.KReturn);
		    var tColon = this.VisitToken(node.TColon);
		    var annotationHead = (AnnotationHeadSyntax)this.Visit(node.AnnotationHead);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, kReturn, tColon, annotationHead, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitAnnotationHead(AnnotationHeadSyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
		    var annotationBody = (AnnotationBodySyntax)this.Visit(node.AnnotationBody);
			return node.Update(name, annotationBody);
		}
		
		public virtual SyntaxNode VisitAnnotationBody(AnnotationBodySyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var annotationPropertyList = (AnnotationPropertyListSyntax)this.Visit(node.AnnotationPropertyList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(tOpenParen, annotationPropertyList, tCloseParen);
		}
		
		public virtual SyntaxNode VisitAnnotationPropertyList(AnnotationPropertyListSyntax node)
		{
		    var annotationProperty = this.VisitList(node.AnnotationProperty);
			return node.Update(annotationProperty);
		}
		
		public virtual SyntaxNode VisitAnnotationProperty(AnnotationPropertySyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tAssign = this.VisitToken(node.TAssign);
		    var annotationPropertyValue = (AnnotationPropertyValueSyntax)this.Visit(node.AnnotationPropertyValue);
			return node.Update(name, tAssign, annotationPropertyValue);
		}
		
		public virtual SyntaxNode VisitAnnotationPropertyValue(AnnotationPropertyValueSyntax node)
		{
			var oldConstantValue = node.ConstantValue;
			if (oldConstantValue != null)
			{
			    var newConstantValue = (ConstantValueSyntax)this.Visit(oldConstantValue);
				return node.Update(newConstantValue);
			}
			var oldTypeofValue = node.TypeofValue;
			if (oldTypeofValue != null)
			{
			    var newTypeofValue = (TypeofValueSyntax)this.Visit(oldTypeofValue);
				return node.Update(newTypeofValue);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    var annotationList = (AnnotationListSyntax)this.Visit(node.AnnotationList);
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var tAssign = this.VisitToken(node.TAssign);
		    var namespacePrefix = (NamespacePrefixSyntax)this.Visit(node.NamespacePrefix);
		    var tColon = this.VisitToken(node.TColon);
		    var namespaceUri = (NamespaceUriSyntax)this.Visit(node.NamespaceUri);
		    var namespaceBody = (NamespaceBodySyntax)this.Visit(node.NamespaceBody);
			return node.Update(annotationList, kNamespace, qualifiedName, tAssign, namespacePrefix, tColon, namespaceUri, namespaceBody);
		}
		
		public virtual SyntaxNode VisitNamespacePrefix(NamespacePrefixSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitNamespaceUri(NamespaceUriSyntax node)
		{
		    var stringLiteral = (StringLiteralSyntax)this.Visit(node.StringLiteral);
			return node.Update(stringLiteral);
		}
		
		public virtual SyntaxNode VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration = this.VisitList(node.Declaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration(DeclarationSyntax node)
		{
			var oldEnumDeclaration = node.EnumDeclaration;
			if (oldEnumDeclaration != null)
			{
			    var newEnumDeclaration = (EnumDeclarationSyntax)this.Visit(oldEnumDeclaration);
				return node.Update(newEnumDeclaration);
			}
			var oldStructDeclaration = node.StructDeclaration;
			if (oldStructDeclaration != null)
			{
			    var newStructDeclaration = (StructDeclarationSyntax)this.Visit(oldStructDeclaration);
				return node.Update(newStructDeclaration);
			}
			var oldDatabaseDeclaration = node.DatabaseDeclaration;
			if (oldDatabaseDeclaration != null)
			{
			    var newDatabaseDeclaration = (DatabaseDeclarationSyntax)this.Visit(oldDatabaseDeclaration);
				return node.Update(newDatabaseDeclaration);
			}
			var oldInterfaceDeclaration = node.InterfaceDeclaration;
			if (oldInterfaceDeclaration != null)
			{
			    var newInterfaceDeclaration = (InterfaceDeclarationSyntax)this.Visit(oldInterfaceDeclaration);
				return node.Update(newInterfaceDeclaration);
			}
			var oldComponentDeclaration = node.ComponentDeclaration;
			if (oldComponentDeclaration != null)
			{
			    var newComponentDeclaration = (ComponentDeclarationSyntax)this.Visit(oldComponentDeclaration);
				return node.Update(newComponentDeclaration);
			}
			var oldCompositeDeclaration = node.CompositeDeclaration;
			if (oldCompositeDeclaration != null)
			{
			    var newCompositeDeclaration = (CompositeDeclarationSyntax)this.Visit(oldCompositeDeclaration);
				return node.Update(newCompositeDeclaration);
			}
			var oldAssemblyDeclaration = node.AssemblyDeclaration;
			if (oldAssemblyDeclaration != null)
			{
			    var newAssemblyDeclaration = (AssemblyDeclarationSyntax)this.Visit(oldAssemblyDeclaration);
				return node.Update(newAssemblyDeclaration);
			}
			var oldBindingDeclaration = node.BindingDeclaration;
			if (oldBindingDeclaration != null)
			{
			    var newBindingDeclaration = (BindingDeclarationSyntax)this.Visit(oldBindingDeclaration);
				return node.Update(newBindingDeclaration);
			}
			var oldEndpointDeclaration = node.EndpointDeclaration;
			if (oldEndpointDeclaration != null)
			{
			    var newEndpointDeclaration = (EndpointDeclarationSyntax)this.Visit(oldEndpointDeclaration);
				return node.Update(newEndpointDeclaration);
			}
			var oldDeploymentDeclaration = node.DeploymentDeclaration;
			if (oldDeploymentDeclaration != null)
			{
			    var newDeploymentDeclaration = (DeploymentDeclarationSyntax)this.Visit(oldDeploymentDeclaration);
				return node.Update(newDeploymentDeclaration);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
		    var annotationList = (AnnotationListSyntax)this.Visit(node.AnnotationList);
		    var kEnum = this.VisitToken(node.KEnum);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var enumBase = (EnumBaseSyntax)this.Visit(node.EnumBase);
		    var enumBody = (EnumBodySyntax)this.Visit(node.EnumBody);
			return node.Update(annotationList, kEnum, name, tColon, enumBase, enumBody);
		}
		
		public virtual SyntaxNode VisitEnumBase(EnumBaseSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitEnumBody(EnumBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var enumLiterals = (EnumLiteralsSyntax)this.Visit(node.EnumLiterals);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, enumLiterals, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitEnumLiterals(EnumLiteralsSyntax node)
		{
		    var enumLiteral = this.VisitList(node.EnumLiteral);
			return node.Update(enumLiteral);
		}
		
		public virtual SyntaxNode VisitEnumLiteral(EnumLiteralSyntax node)
		{
		    var annotationList = (AnnotationListSyntax)this.Visit(node.AnnotationList);
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(annotationList, name);
		}
		
		public virtual SyntaxNode VisitStructDeclaration(StructDeclarationSyntax node)
		{
		    var annotationList = (AnnotationListSyntax)this.Visit(node.AnnotationList);
		    var kStruct = this.VisitToken(node.KStruct);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var structBody = (StructBodySyntax)this.Visit(node.StructBody);
			return node.Update(annotationList, kStruct, name, tColon, qualifier, structBody);
		}
		
		public virtual SyntaxNode VisitStructBody(StructBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var propertyDeclaration = this.VisitList(node.PropertyDeclaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, propertyDeclaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
		{
		    var annotationList = (AnnotationListSyntax)this.Visit(node.AnnotationList);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(annotationList, typeReference, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitDatabaseDeclaration(DatabaseDeclarationSyntax node)
		{
		    var annotationList = (AnnotationListSyntax)this.Visit(node.AnnotationList);
		    var kDatabase = this.VisitToken(node.KDatabase);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var databaseBody = (DatabaseBodySyntax)this.Visit(node.DatabaseBody);
			return node.Update(annotationList, kDatabase, name, databaseBody);
		}
		
		public virtual SyntaxNode VisitDatabaseBody(DatabaseBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var entityReference = this.VisitList(node.EntityReference);
		    var operationDeclaration = this.VisitList(node.OperationDeclaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, entityReference, operationDeclaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitEntityReference(EntityReferenceSyntax node)
		{
		    var kEntity = this.VisitToken(node.KEntity);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kEntity, qualifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
		{
		    var annotationList = (AnnotationListSyntax)this.Visit(node.AnnotationList);
		    var kInterface = this.VisitToken(node.KInterface);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var interfaceBody = (InterfaceBodySyntax)this.Visit(node.InterfaceBody);
			return node.Update(annotationList, kInterface, name, interfaceBody);
		}
		
		public virtual SyntaxNode VisitInterfaceBody(InterfaceBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var operationDeclaration = this.VisitList(node.OperationDeclaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, operationDeclaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    var operationHead = (OperationHeadSyntax)this.Visit(node.OperationHead);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(operationHead, tSemicolon);
		}
		
		public virtual SyntaxNode VisitOperationHead(OperationHeadSyntax node)
		{
		    var annotationList = (AnnotationListSyntax)this.Visit(node.AnnotationList);
		    var operationResult = (OperationResultSyntax)this.Visit(node.OperationResult);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var parameterList = (ParameterListSyntax)this.Visit(node.ParameterList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var throwsList = (ThrowsListSyntax)this.Visit(node.ThrowsList);
			return node.Update(annotationList, operationResult, name, tOpenParen, parameterList, tCloseParen, throwsList);
		}
		
		public virtual SyntaxNode VisitParameterList(ParameterListSyntax node)
		{
		    var parameter = this.VisitList(node.Parameter);
			return node.Update(parameter);
		}
		
		public virtual SyntaxNode VisitParameter(ParameterSyntax node)
		{
		    var annotationList = (AnnotationListSyntax)this.Visit(node.AnnotationList);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(annotationList, typeReference, name);
		}
		
		public virtual SyntaxNode VisitOperationResult(OperationResultSyntax node)
		{
		    var returnAnnotationList = (ReturnAnnotationListSyntax)this.Visit(node.ReturnAnnotationList);
		    var operationReturnType = (OperationReturnTypeSyntax)this.Visit(node.OperationReturnType);
			return node.Update(returnAnnotationList, operationReturnType);
		}
		
		public virtual SyntaxNode VisitThrowsList(ThrowsListSyntax node)
		{
		    var kThrows = this.VisitToken(node.KThrows);
		    var qualifierList = (QualifierListSyntax)this.Visit(node.QualifierList);
			return node.Update(kThrows, qualifierList);
		}
		
		public virtual SyntaxNode VisitComponentDeclaration(ComponentDeclarationSyntax node)
		{
		    var kAbstract = this.VisitToken(node.KAbstract);
		    var kComponent = this.VisitToken(node.KComponent);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var componentBase = (ComponentBaseSyntax)this.Visit(node.ComponentBase);
		    var componentBody = (ComponentBodySyntax)this.Visit(node.ComponentBody);
			return node.Update(kAbstract, kComponent, name, tColon, componentBase, componentBody);
		}
		
		public virtual SyntaxNode VisitComponentBase(ComponentBaseSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitComponentBody(ComponentBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var componentElements = (ComponentElementsSyntax)this.Visit(node.ComponentElements);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, componentElements, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitComponentElements(ComponentElementsSyntax node)
		{
		    var componentElement = this.VisitList(node.ComponentElement);
			return node.Update(componentElement);
		}
		
		public virtual SyntaxNode VisitComponentElement(ComponentElementSyntax node)
		{
			var oldComponentService = node.ComponentService;
			if (oldComponentService != null)
			{
			    var newComponentService = (ComponentServiceSyntax)this.Visit(oldComponentService);
				return node.Update(newComponentService);
			}
			var oldComponentReference = node.ComponentReference;
			if (oldComponentReference != null)
			{
			    var newComponentReference = (ComponentReferenceSyntax)this.Visit(oldComponentReference);
				return node.Update(newComponentReference);
			}
			var oldComponentProperty = node.ComponentProperty;
			if (oldComponentProperty != null)
			{
			    var newComponentProperty = (ComponentPropertySyntax)this.Visit(oldComponentProperty);
				return node.Update(newComponentProperty);
			}
			var oldComponentImplementation = node.ComponentImplementation;
			if (oldComponentImplementation != null)
			{
			    var newComponentImplementation = (ComponentImplementationSyntax)this.Visit(oldComponentImplementation);
				return node.Update(newComponentImplementation);
			}
			var oldComponentLanguage = node.ComponentLanguage;
			if (oldComponentLanguage != null)
			{
			    var newComponentLanguage = (ComponentLanguageSyntax)this.Visit(oldComponentLanguage);
				return node.Update(newComponentLanguage);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitComponentService(ComponentServiceSyntax node)
		{
		    var kService = this.VisitToken(node.KService);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var componentServiceOrReferenceBody = (ComponentServiceOrReferenceBodySyntax)this.Visit(node.ComponentServiceOrReferenceBody);
			return node.Update(kService, qualifier, name, componentServiceOrReferenceBody);
		}
		
		public virtual SyntaxNode VisitComponentReference(ComponentReferenceSyntax node)
		{
		    var kReference = this.VisitToken(node.KReference);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var componentServiceOrReferenceBody = (ComponentServiceOrReferenceBodySyntax)this.Visit(node.ComponentServiceOrReferenceBody);
			return node.Update(kReference, qualifier, name, componentServiceOrReferenceBody);
		}
		
		public virtual SyntaxNode VisitComponentServiceOrReferenceEmptyBody(ComponentServiceOrReferenceEmptyBodySyntax node)
		{
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(tSemicolon);
		}
		
		public virtual SyntaxNode VisitComponentServiceOrReferenceNonEmptyBody(ComponentServiceOrReferenceNonEmptyBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var componentServiceOrReferenceElement = this.VisitList(node.ComponentServiceOrReferenceElement);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, componentServiceOrReferenceElement, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitComponentServiceOrReferenceElement(ComponentServiceOrReferenceElementSyntax node)
		{
		    var kBinding = this.VisitToken(node.KBinding);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kBinding, qualifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitComponentProperty(ComponentPropertySyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(typeReference, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitComponentImplementation(ComponentImplementationSyntax node)
		{
		    var kImplementation = this.VisitToken(node.KImplementation);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kImplementation, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitComponentLanguage(ComponentLanguageSyntax node)
		{
		    var kLanguage = this.VisitToken(node.KLanguage);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kLanguage, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitCompositeDeclaration(CompositeDeclarationSyntax node)
		{
		    var kComposite = this.VisitToken(node.KComposite);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var componentBase = (ComponentBaseSyntax)this.Visit(node.ComponentBase);
		    var compositeBody = (CompositeBodySyntax)this.Visit(node.CompositeBody);
			return node.Update(kComposite, name, tColon, componentBase, compositeBody);
		}
		
		public virtual SyntaxNode VisitCompositeBody(CompositeBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var compositeElements = (CompositeElementsSyntax)this.Visit(node.CompositeElements);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, compositeElements, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitAssemblyDeclaration(AssemblyDeclarationSyntax node)
		{
		    var kAssembly = this.VisitToken(node.KAssembly);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var componentBase = (ComponentBaseSyntax)this.Visit(node.ComponentBase);
		    var compositeBody = (CompositeBodySyntax)this.Visit(node.CompositeBody);
			return node.Update(kAssembly, name, tColon, componentBase, compositeBody);
		}
		
		public virtual SyntaxNode VisitCompositeElements(CompositeElementsSyntax node)
		{
		    var compositeElement = this.VisitList(node.CompositeElement);
			return node.Update(compositeElement);
		}
		
		public virtual SyntaxNode VisitCompositeElement(CompositeElementSyntax node)
		{
			var oldComponentService = node.ComponentService;
			if (oldComponentService != null)
			{
			    var newComponentService = (ComponentServiceSyntax)this.Visit(oldComponentService);
				return node.Update(newComponentService);
			}
			var oldComponentReference = node.ComponentReference;
			if (oldComponentReference != null)
			{
			    var newComponentReference = (ComponentReferenceSyntax)this.Visit(oldComponentReference);
				return node.Update(newComponentReference);
			}
			var oldComponentProperty = node.ComponentProperty;
			if (oldComponentProperty != null)
			{
			    var newComponentProperty = (ComponentPropertySyntax)this.Visit(oldComponentProperty);
				return node.Update(newComponentProperty);
			}
			var oldComponentImplementation = node.ComponentImplementation;
			if (oldComponentImplementation != null)
			{
			    var newComponentImplementation = (ComponentImplementationSyntax)this.Visit(oldComponentImplementation);
				return node.Update(newComponentImplementation);
			}
			var oldComponentLanguage = node.ComponentLanguage;
			if (oldComponentLanguage != null)
			{
			    var newComponentLanguage = (ComponentLanguageSyntax)this.Visit(oldComponentLanguage);
				return node.Update(newComponentLanguage);
			}
			var oldCompositeComponent = node.CompositeComponent;
			if (oldCompositeComponent != null)
			{
			    var newCompositeComponent = (CompositeComponentSyntax)this.Visit(oldCompositeComponent);
				return node.Update(newCompositeComponent);
			}
			var oldCompositeWire = node.CompositeWire;
			if (oldCompositeWire != null)
			{
			    var newCompositeWire = (CompositeWireSyntax)this.Visit(oldCompositeWire);
				return node.Update(newCompositeWire);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitCompositeComponent(CompositeComponentSyntax node)
		{
		    var kComponent = this.VisitToken(node.KComponent);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kComponent, qualifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitCompositeWire(CompositeWireSyntax node)
		{
		    var kWire = this.VisitToken(node.KWire);
		    var wireSource = (WireSourceSyntax)this.Visit(node.WireSource);
		    var kTo = this.VisitToken(node.KTo);
		    var wireTarget = (WireTargetSyntax)this.Visit(node.WireTarget);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kWire, wireSource, kTo, wireTarget, tSemicolon);
		}
		
		public virtual SyntaxNode VisitWireSource(WireSourceSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitWireTarget(WireTargetSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitDeploymentDeclaration(DeploymentDeclarationSyntax node)
		{
		    var kDeployment = this.VisitToken(node.KDeployment);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var deploymentBody = (DeploymentBodySyntax)this.Visit(node.DeploymentBody);
			return node.Update(kDeployment, name, deploymentBody);
		}
		
		public virtual SyntaxNode VisitDeploymentBody(DeploymentBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var deploymentElements = (DeploymentElementsSyntax)this.Visit(node.DeploymentElements);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, deploymentElements, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeploymentElements(DeploymentElementsSyntax node)
		{
		    var deploymentElement = this.VisitList(node.DeploymentElement);
			return node.Update(deploymentElement);
		}
		
		public virtual SyntaxNode VisitDeploymentElement(DeploymentElementSyntax node)
		{
			var oldEnvironmentDeclaration = node.EnvironmentDeclaration;
			if (oldEnvironmentDeclaration != null)
			{
			    var newEnvironmentDeclaration = (EnvironmentDeclarationSyntax)this.Visit(oldEnvironmentDeclaration);
				return node.Update(newEnvironmentDeclaration);
			}
			var oldCompositeWire = node.CompositeWire;
			if (oldCompositeWire != null)
			{
			    var newCompositeWire = (CompositeWireSyntax)this.Visit(oldCompositeWire);
				return node.Update(newCompositeWire);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitEnvironmentDeclaration(EnvironmentDeclarationSyntax node)
		{
		    var kEnvironment = this.VisitToken(node.KEnvironment);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var environmentBody = (EnvironmentBodySyntax)this.Visit(node.EnvironmentBody);
			return node.Update(kEnvironment, name, environmentBody);
		}
		
		public virtual SyntaxNode VisitEnvironmentBody(EnvironmentBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var runtimeDeclaration = (RuntimeDeclarationSyntax)this.Visit(node.RuntimeDeclaration);
		    var runtimeReference = this.VisitList(node.RuntimeReference);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, runtimeDeclaration, runtimeReference, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitRuntimeDeclaration(RuntimeDeclarationSyntax node)
		{
		    var kRuntime = this.VisitToken(node.KRuntime);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kRuntime, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitRuntimeReference(RuntimeReferenceSyntax node)
		{
			var oldAssemblyReference = node.AssemblyReference;
			if (oldAssemblyReference != null)
			{
			    var newAssemblyReference = (AssemblyReferenceSyntax)this.Visit(oldAssemblyReference);
				return node.Update(newAssemblyReference);
			}
			var oldDatabaseReference = node.DatabaseReference;
			if (oldDatabaseReference != null)
			{
			    var newDatabaseReference = (DatabaseReferenceSyntax)this.Visit(oldDatabaseReference);
				return node.Update(newDatabaseReference);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitAssemblyReference(AssemblyReferenceSyntax node)
		{
		    var kAssembly = this.VisitToken(node.KAssembly);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kAssembly, qualifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitDatabaseReference(DatabaseReferenceSyntax node)
		{
		    var kDatabase = this.VisitToken(node.KDatabase);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kDatabase, qualifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitBindingDeclaration(BindingDeclarationSyntax node)
		{
		    var kBinding = this.VisitToken(node.KBinding);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var bindingBody = (BindingBodySyntax)this.Visit(node.BindingBody);
			return node.Update(kBinding, name, bindingBody);
		}
		
		public virtual SyntaxNode VisitBindingBody(BindingBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var bindingLayers = (BindingLayersSyntax)this.Visit(node.BindingLayers);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, bindingLayers, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitBindingLayers(BindingLayersSyntax node)
		{
		    var transportLayer = (TransportLayerSyntax)this.Visit(node.TransportLayer);
		    var encodingLayer = this.VisitList(node.EncodingLayer);
		    var protocolLayer = this.VisitList(node.ProtocolLayer);
			return node.Update(transportLayer, encodingLayer, protocolLayer);
		}
		
		public virtual SyntaxNode VisitTransportLayer(TransportLayerSyntax node)
		{
			var oldHttpTransportLayer = node.HttpTransportLayer;
			if (oldHttpTransportLayer != null)
			{
			    var newHttpTransportLayer = (HttpTransportLayerSyntax)this.Visit(oldHttpTransportLayer);
				return node.Update(newHttpTransportLayer);
			}
			var oldRestTransportLayer = node.RestTransportLayer;
			if (oldRestTransportLayer != null)
			{
			    var newRestTransportLayer = (RestTransportLayerSyntax)this.Visit(oldRestTransportLayer);
				return node.Update(newRestTransportLayer);
			}
			var oldWebSocketTransportLayer = node.WebSocketTransportLayer;
			if (oldWebSocketTransportLayer != null)
			{
			    var newWebSocketTransportLayer = (WebSocketTransportLayerSyntax)this.Visit(oldWebSocketTransportLayer);
				return node.Update(newWebSocketTransportLayer);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitHttpTransportLayer(HttpTransportLayerSyntax node)
		{
		    var kTransport = this.VisitToken(node.KTransport);
		    var ihttp = this.VisitToken(node.IHTTP);
		    var httpTransportLayerBody = (HttpTransportLayerBodySyntax)this.Visit(node.HttpTransportLayerBody);
			return node.Update(kTransport, ihttp, httpTransportLayerBody);
		}
		
		public virtual SyntaxNode VisitHttpTransportLayerEmptyBody(HttpTransportLayerEmptyBodySyntax node)
		{
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(tSemicolon);
		}
		
		public virtual SyntaxNode VisitHttpTransportLayerNonEmptyBody(HttpTransportLayerNonEmptyBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var httpTransportLayerProperties = this.VisitList(node.HttpTransportLayerProperties);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, httpTransportLayerProperties, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitRestTransportLayer(RestTransportLayerSyntax node)
		{
		    var kTransport = this.VisitToken(node.KTransport);
		    var irest = this.VisitToken(node.IREST);
		    var restTransportLayerBody = (RestTransportLayerBodySyntax)this.Visit(node.RestTransportLayerBody);
			return node.Update(kTransport, irest, restTransportLayerBody);
		}
		
		public virtual SyntaxNode VisitRestTransportLayerEmptyBody(RestTransportLayerEmptyBodySyntax node)
		{
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(tSemicolon);
		}
		
		public virtual SyntaxNode VisitRestTransportLayerNonEmptyBody(RestTransportLayerNonEmptyBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitWebSocketTransportLayer(WebSocketTransportLayerSyntax node)
		{
		    var kTransport = this.VisitToken(node.KTransport);
		    var iWebSocket = this.VisitToken(node.IWebSocket);
		    var webSocketTransportLayerBody = (WebSocketTransportLayerBodySyntax)this.Visit(node.WebSocketTransportLayerBody);
			return node.Update(kTransport, iWebSocket, webSocketTransportLayerBody);
		}
		
		public virtual SyntaxNode VisitWebSocketTransportLayerEmptyBody(WebSocketTransportLayerEmptyBodySyntax node)
		{
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(tSemicolon);
		}
		
		public virtual SyntaxNode VisitWebSocketTransportLayerNonEmptyBody(WebSocketTransportLayerNonEmptyBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitHttpTransportLayerProperties(HttpTransportLayerPropertiesSyntax node)
		{
			var oldHttpSslProperty = node.HttpSslProperty;
			if (oldHttpSslProperty != null)
			{
			    var newHttpSslProperty = (HttpSslPropertySyntax)this.Visit(oldHttpSslProperty);
				return node.Update(newHttpSslProperty);
			}
			var oldHttpClientAuthenticationProperty = node.HttpClientAuthenticationProperty;
			if (oldHttpClientAuthenticationProperty != null)
			{
			    var newHttpClientAuthenticationProperty = (HttpClientAuthenticationPropertySyntax)this.Visit(oldHttpClientAuthenticationProperty);
				return node.Update(newHttpClientAuthenticationProperty);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitHttpSslProperty(HttpSslPropertySyntax node)
		{
		    var issl = this.VisitToken(node.ISSL);
		    var tAssign = this.VisitToken(node.TAssign);
		    var booleanLiteral = (BooleanLiteralSyntax)this.Visit(node.BooleanLiteral);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(issl, tAssign, booleanLiteral, tSemicolon);
		}
		
		public virtual SyntaxNode VisitHttpClientAuthenticationProperty(HttpClientAuthenticationPropertySyntax node)
		{
		    var iClientAuthentication = this.VisitToken(node.IClientAuthentication);
		    var tAssign = this.VisitToken(node.TAssign);
		    var booleanLiteral = (BooleanLiteralSyntax)this.Visit(node.BooleanLiteral);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(iClientAuthentication, tAssign, booleanLiteral, tSemicolon);
		}
		
		public virtual SyntaxNode VisitEncodingLayer(EncodingLayerSyntax node)
		{
			var oldSoapEncodingLayer = node.SoapEncodingLayer;
			if (oldSoapEncodingLayer != null)
			{
			    var newSoapEncodingLayer = (SoapEncodingLayerSyntax)this.Visit(oldSoapEncodingLayer);
				return node.Update(newSoapEncodingLayer);
			}
			var oldXmlEncodingLayer = node.XmlEncodingLayer;
			if (oldXmlEncodingLayer != null)
			{
			    var newXmlEncodingLayer = (XmlEncodingLayerSyntax)this.Visit(oldXmlEncodingLayer);
				return node.Update(newXmlEncodingLayer);
			}
			var oldJsonEncodingLayer = node.JsonEncodingLayer;
			if (oldJsonEncodingLayer != null)
			{
			    var newJsonEncodingLayer = (JsonEncodingLayerSyntax)this.Visit(oldJsonEncodingLayer);
				return node.Update(newJsonEncodingLayer);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSoapEncodingLayer(SoapEncodingLayerSyntax node)
		{
		    var kEncoding = this.VisitToken(node.KEncoding);
		    var isoap = this.VisitToken(node.ISOAP);
		    var soapEncodingLayerBody = (SoapEncodingLayerBodySyntax)this.Visit(node.SoapEncodingLayerBody);
			return node.Update(kEncoding, isoap, soapEncodingLayerBody);
		}
		
		public virtual SyntaxNode VisitSoapEncodingLayerEmptyBody(SoapEncodingLayerEmptyBodySyntax node)
		{
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(tSemicolon);
		}
		
		public virtual SyntaxNode VisitSoapEncodingLayerNonEmptyBody(SoapEncodingLayerNonEmptyBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var soapEncodingProperties = this.VisitList(node.SoapEncodingProperties);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, soapEncodingProperties, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitXmlEncodingLayer(XmlEncodingLayerSyntax node)
		{
		    var kEncoding = this.VisitToken(node.KEncoding);
		    var ixml = this.VisitToken(node.IXML);
		    var xmlEncodingLayerBody = (XmlEncodingLayerBodySyntax)this.Visit(node.XmlEncodingLayerBody);
			return node.Update(kEncoding, ixml, xmlEncodingLayerBody);
		}
		
		public virtual SyntaxNode VisitXmlEncodingLayerEmptyBody(XmlEncodingLayerEmptyBodySyntax node)
		{
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(tSemicolon);
		}
		
		public virtual SyntaxNode VisitXmlEncodingLayerNonEmptyBody(XmlEncodingLayerNonEmptyBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitJsonEncodingLayer(JsonEncodingLayerSyntax node)
		{
		    var kEncoding = this.VisitToken(node.KEncoding);
		    var ijson = this.VisitToken(node.IJSON);
		    var jsonEncodingLayerBody = (JsonEncodingLayerBodySyntax)this.Visit(node.JsonEncodingLayerBody);
			return node.Update(kEncoding, ijson, jsonEncodingLayerBody);
		}
		
		public virtual SyntaxNode VisitJsonEncodingLayerEmptyBody(JsonEncodingLayerEmptyBodySyntax node)
		{
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(tSemicolon);
		}
		
		public virtual SyntaxNode VisitJsonEncodingLayerNonEmptyBody(JsonEncodingLayerNonEmptyBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitSoapEncodingProperties(SoapEncodingPropertiesSyntax node)
		{
			var oldSoapVersionProperty = node.SoapVersionProperty;
			if (oldSoapVersionProperty != null)
			{
			    var newSoapVersionProperty = (SoapVersionPropertySyntax)this.Visit(oldSoapVersionProperty);
				return node.Update(newSoapVersionProperty);
			}
			var oldSoapMtomProperty = node.SoapMtomProperty;
			if (oldSoapMtomProperty != null)
			{
			    var newSoapMtomProperty = (SoapMtomPropertySyntax)this.Visit(oldSoapMtomProperty);
				return node.Update(newSoapMtomProperty);
			}
			var oldSoapStyleProperty = node.SoapStyleProperty;
			if (oldSoapStyleProperty != null)
			{
			    var newSoapStyleProperty = (SoapStylePropertySyntax)this.Visit(oldSoapStyleProperty);
				return node.Update(newSoapStyleProperty);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSoapVersionProperty(SoapVersionPropertySyntax node)
		{
		    var iVersion = this.VisitToken(node.IVersion);
		    var tAssign = this.VisitToken(node.TAssign);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(iVersion, tAssign, identifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitSoapMtomProperty(SoapMtomPropertySyntax node)
		{
		    var imtom = this.VisitToken(node.IMTOM);
		    var tAssign = this.VisitToken(node.TAssign);
		    var booleanLiteral = (BooleanLiteralSyntax)this.Visit(node.BooleanLiteral);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(imtom, tAssign, booleanLiteral, tSemicolon);
		}
		
		public virtual SyntaxNode VisitSoapStyleProperty(SoapStylePropertySyntax node)
		{
		    var iStyle = this.VisitToken(node.IStyle);
		    var tAssign = this.VisitToken(node.TAssign);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(iStyle, tAssign, identifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitProtocolLayer(ProtocolLayerSyntax node)
		{
		    var kProtocol = this.VisitToken(node.KProtocol);
		    var protocolLayerKind = (ProtocolLayerKindSyntax)this.Visit(node.ProtocolLayerKind);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kProtocol, protocolLayerKind, tSemicolon);
		}
		
		public virtual SyntaxNode VisitProtocolLayerKind(ProtocolLayerKindSyntax node)
		{
		    var wsAddressing = (WsAddressingSyntax)this.Visit(node.WsAddressing);
			return node.Update(wsAddressing);
		}
		
		public virtual SyntaxNode VisitWsAddressing(WsAddressingSyntax node)
		{
		    var iWsAddressing = this.VisitToken(node.IWsAddressing);
			return node.Update(iWsAddressing);
		}
		
		public virtual SyntaxNode VisitEndpointDeclaration(EndpointDeclarationSyntax node)
		{
		    var kEndpoint = this.VisitToken(node.KEndpoint);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var endpointBody = (EndpointBodySyntax)this.Visit(node.EndpointBody);
			return node.Update(kEndpoint, name, tColon, qualifier, endpointBody);
		}
		
		public virtual SyntaxNode VisitEndpointBody(EndpointBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var endpointProperties = (EndpointPropertiesSyntax)this.Visit(node.EndpointProperties);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, endpointProperties, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitEndpointProperties(EndpointPropertiesSyntax node)
		{
		    var endpointProperty = this.VisitList(node.EndpointProperty);
			return node.Update(endpointProperty);
		}
		
		public virtual SyntaxNode VisitEndpointProperty(EndpointPropertySyntax node)
		{
			var oldEndpointBindingProperty = node.EndpointBindingProperty;
			if (oldEndpointBindingProperty != null)
			{
			    var newEndpointBindingProperty = (EndpointBindingPropertySyntax)this.Visit(oldEndpointBindingProperty);
				return node.Update(newEndpointBindingProperty);
			}
			var oldEndpointAddressProperty = node.EndpointAddressProperty;
			if (oldEndpointAddressProperty != null)
			{
			    var newEndpointAddressProperty = (EndpointAddressPropertySyntax)this.Visit(oldEndpointAddressProperty);
				return node.Update(newEndpointAddressProperty);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitEndpointBindingProperty(EndpointBindingPropertySyntax node)
		{
		    var kBinding = this.VisitToken(node.KBinding);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kBinding, qualifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitEndpointAddressProperty(EndpointAddressPropertySyntax node)
		{
		    var kAddress = this.VisitToken(node.KAddress);
		    var stringLiteral = (StringLiteralSyntax)this.Visit(node.StringLiteral);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kAddress, stringLiteral, tSemicolon);
		}
		
		public virtual SyntaxNode VisitReturnType(ReturnTypeSyntax node)
		{
			var oldVoidType = node.VoidType;
			if (oldVoidType != null)
			{
			    var newVoidType = (VoidTypeSyntax)this.Visit(oldVoidType);
				return node.Update(newVoidType);
			}
			var oldTypeReference = node.TypeReference;
			if (oldTypeReference != null)
			{
			    var newTypeReference = (TypeReferenceSyntax)this.Visit(oldTypeReference);
				return node.Update(newTypeReference);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTypeReference(TypeReferenceSyntax node)
		{
			var oldNonNullableArrayType = node.NonNullableArrayType;
			if (oldNonNullableArrayType != null)
			{
			    var newNonNullableArrayType = (NonNullableArrayTypeSyntax)this.Visit(oldNonNullableArrayType);
				return node.Update(newNonNullableArrayType);
			}
			var oldArrayType = node.ArrayType;
			if (oldArrayType != null)
			{
			    var newArrayType = (ArrayTypeSyntax)this.Visit(oldArrayType);
				return node.Update(newArrayType);
			}
			var oldSimpleType = node.SimpleType;
			if (oldSimpleType != null)
			{
			    var newSimpleType = (SimpleTypeSyntax)this.Visit(oldSimpleType);
				return node.Update(newSimpleType);
			}
			var oldNulledType = node.NulledType;
			if (oldNulledType != null)
			{
			    var newNulledType = (NulledTypeSyntax)this.Visit(oldNulledType);
				return node.Update(newNulledType);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSimpleType(SimpleTypeSyntax node)
		{
			var oldValueType = node.ValueType;
			if (oldValueType != null)
			{
			    var newValueType = (ValueTypeSyntax)this.Visit(oldValueType);
				return node.Update(newValueType);
			}
			var oldObjectType = node.ObjectType;
			if (oldObjectType != null)
			{
			    var newObjectType = (ObjectTypeSyntax)this.Visit(oldObjectType);
				return node.Update(newObjectType);
			}
			var oldQualifier = node.Qualifier;
			if (oldQualifier != null)
			{
			    var newQualifier = (QualifierSyntax)this.Visit(oldQualifier);
				return node.Update(newQualifier);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitNulledType(NulledTypeSyntax node)
		{
			var oldNullableType = node.NullableType;
			if (oldNullableType != null)
			{
			    var newNullableType = (NullableTypeSyntax)this.Visit(oldNullableType);
				return node.Update(newNullableType);
			}
			var oldNonNullableType = node.NonNullableType;
			if (oldNonNullableType != null)
			{
			    var newNonNullableType = (NonNullableTypeSyntax)this.Visit(oldNonNullableType);
				return node.Update(newNonNullableType);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitReferenceType(ReferenceTypeSyntax node)
		{
			var oldObjectType = node.ObjectType;
			if (oldObjectType != null)
			{
			    var newObjectType = (ObjectTypeSyntax)this.Visit(oldObjectType);
				return node.Update(newObjectType);
			}
			var oldQualifier = node.Qualifier;
			if (oldQualifier != null)
			{
			    var newQualifier = (QualifierSyntax)this.Visit(oldQualifier);
				return node.Update(newQualifier);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitObjectType(ObjectTypeSyntax node)
		{
		    var objectType = this.VisitToken(node.ObjectType);
			return node.Update(objectType);
		}
		
		public virtual SyntaxNode VisitValueType(ValueTypeSyntax node)
		{
		    var valueType = this.VisitToken(node.ValueType);
			return node.Update(valueType);
		}
		
		public virtual SyntaxNode VisitVoidType(VoidTypeSyntax node)
		{
		    var kVoid = this.VisitToken(node.KVoid);
			return node.Update(kVoid);
		}
		
		public virtual SyntaxNode VisitOnewayType(OnewayTypeSyntax node)
		{
		    var kOneway = this.VisitToken(node.KOneway);
			return node.Update(kOneway);
		}
		
		public virtual SyntaxNode VisitOperationReturnType(OperationReturnTypeSyntax node)
		{
			var oldOnewayType = node.OnewayType;
			if (oldOnewayType != null)
			{
			    var newOnewayType = (OnewayTypeSyntax)this.Visit(oldOnewayType);
				return node.Update(newOnewayType);
			}
			var oldVoidType = node.VoidType;
			if (oldVoidType != null)
			{
			    var newVoidType = (VoidTypeSyntax)this.Visit(oldVoidType);
				return node.Update(newVoidType);
			}
			var oldTypeReference = node.TypeReference;
			if (oldTypeReference != null)
			{
			    var newTypeReference = (TypeReferenceSyntax)this.Visit(oldTypeReference);
				return node.Update(newTypeReference);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitNullableType(NullableTypeSyntax node)
		{
		    var valueType = (ValueTypeSyntax)this.Visit(node.ValueType);
		    var tQuestion = this.VisitToken(node.TQuestion);
			return node.Update(valueType, tQuestion);
		}
		
		public virtual SyntaxNode VisitNonNullableType(NonNullableTypeSyntax node)
		{
		    var referenceType = (ReferenceTypeSyntax)this.Visit(node.ReferenceType);
		    var tExclamation = this.VisitToken(node.TExclamation);
			return node.Update(referenceType, tExclamation);
		}
		
		public virtual SyntaxNode VisitNonNullableArrayType(NonNullableArrayTypeSyntax node)
		{
		    var arrayType = (ArrayTypeSyntax)this.Visit(node.ArrayType);
		    var tExclamation = this.VisitToken(node.TExclamation);
			return node.Update(arrayType, tExclamation);
		}
		
		public virtual SyntaxNode VisitArrayType(ArrayTypeSyntax node)
		{
			var oldSimpleArrayType = node.SimpleArrayType;
			if (oldSimpleArrayType != null)
			{
			    var newSimpleArrayType = (SimpleArrayTypeSyntax)this.Visit(oldSimpleArrayType);
				return node.Update(newSimpleArrayType);
			}
			var oldNulledArrayType = node.NulledArrayType;
			if (oldNulledArrayType != null)
			{
			    var newNulledArrayType = (NulledArrayTypeSyntax)this.Visit(oldNulledArrayType);
				return node.Update(newNulledArrayType);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSimpleArrayType(SimpleArrayTypeSyntax node)
		{
		    var simpleType = (SimpleTypeSyntax)this.Visit(node.SimpleType);
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(simpleType, tOpenBracket, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitNulledArrayType(NulledArrayTypeSyntax node)
		{
		    var nulledType = (NulledTypeSyntax)this.Visit(node.NulledType);
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(nulledType, tOpenBracket, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitConstantValue(ConstantValueSyntax node)
		{
			var oldLiteral = node.Literal;
			if (oldLiteral != null)
			{
			    var newLiteral = (LiteralSyntax)this.Visit(oldLiteral);
				return node.Update(newLiteral);
			}
			var oldIdentifier = node.Identifier;
			if (oldIdentifier != null)
			{
			    var newIdentifier = (IdentifierSyntax)this.Visit(oldIdentifier);
				return node.Update(newIdentifier);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTypeofValue(TypeofValueSyntax node)
		{
		    var kTypeof = this.VisitToken(node.KTypeof);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var returnType = (ReturnTypeSyntax)this.Visit(node.ReturnType);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(kTypeof, tOpenParen, returnType, tCloseParen);
		}
		
		public virtual SyntaxNode VisitIdentifier(IdentifierSyntax node)
		{
			var oldIdentifiers = node.Identifiers;
			if (oldIdentifiers != null)
			{
			    var newIdentifiers = (IdentifiersSyntax)this.Visit(oldIdentifiers);
				return node.Update(newIdentifiers);
			}
			var oldContextualKeywords = node.ContextualKeywords;
			if (oldContextualKeywords != null)
			{
			    var newContextualKeywords = (ContextualKeywordsSyntax)this.Visit(oldContextualKeywords);
				return node.Update(newContextualKeywords);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitIdentifiers(IdentifiersSyntax node)
		{
		    var identifiers = this.VisitToken(node.Identifiers);
			return node.Update(identifiers);
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
		
		public virtual SyntaxNode VisitContextualKeywords(ContextualKeywordsSyntax node)
		{
		    var contextualKeywords = this.VisitToken(node.ContextualKeywords);
			return node.Update(contextualKeywords);
		}
	}

	public class SoalSyntaxFactory : SyntaxFactory
	{
		internal SoalSyntaxFactory(SoalInternalSyntaxFactory internalSyntaxFactory) 
			: base(internalSyntaxFactory)
		{
		}
		public new SoalLanguage Language
		{
			get { return SoalLanguage.Instance; }
		}
		protected override Language LanguageCore
		{
			get { return this.Language; }
		}
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public SoalSyntaxTree SyntaxTree(SyntaxNode root, SoalParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return SoalSyntaxTree.Create((SoalSyntaxNode)root, (SoalParseOptions)options, path, encoding);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public SoalSyntaxTree ParseSyntaxTree(
			string text,
			SoalParseOptions options = null,
			string path = "",
			Encoding encoding = null,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (SoalSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public SoalSyntaxTree ParseSyntaxTree(
			SourceText text,
			SoalParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (SoalSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
		protected override LanguageSyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return SoalSyntaxTree.ParseText(text, (SoalParseOptions)options, path, cancellationToken);
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
		    return new SoalSyntaxParser(text, (SoalParseOptions)options, oldTree, changes);
		}
	
		public override SyntaxParser MakeParser(string text)
		{
		    return new SoalSyntaxParser(SourceText.From(text, Encoding.UTF8), SoalParseOptions.Default, null, null);
		}
	
	    public override SyntaxNode CreateStructure(SyntaxTrivia trivia)
	    {
	        throw new NotImplementedException();
	    }
	
	
	    public SyntaxToken TAsterisk(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.TAsterisk(text));
	    }
	
	    public SyntaxToken TAsterisk(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.TAsterisk(text, value));
	    }
	
	    public SyntaxToken IdentifierNormal(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text));
	    }
	
	    public SyntaxToken IdentifierNormal(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text, value));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text, value));
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LInteger(text));
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LInteger(text, value));
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LDecimal(text));
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LDecimal(text, value));
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LScientific(text));
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LScientific(text, value));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text, value));
	    }
	
	    public SyntaxToken LDateTime(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LDateTime(text));
	    }
	
	    public SyntaxToken LDateTime(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LDateTime(text, value));
	    }
	
	    public SyntaxToken LDate(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LDate(text));
	    }
	
	    public SyntaxToken LDate(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LDate(text, value));
	    }
	
	    public SyntaxToken LTime(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LTime(text));
	    }
	
	    public SyntaxToken LTime(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LTime(text, value));
	    }
	
	    public SyntaxToken LRegularString(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LRegularString(text));
	    }
	
	    public SyntaxToken LRegularString(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LRegularString(text, value));
	    }
	
	    public SyntaxToken LGuid(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LGuid(text));
	    }
	
	    public SyntaxToken LGuid(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LGuid(text, value));
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text));
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value));
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text));
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value));
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LCrLf(text));
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value));
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LLineEnd(text));
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value));
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text));
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value));
	    }
	
	    public SyntaxToken LMultiLineComment(string text)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LMultiLineComment(text));
	    }
	
	    public SyntaxToken LMultiLineComment(string text, object value)
	    {
	        return new SyntaxToken(SoalLanguage.Instance.InternalSyntaxFactory.LMultiLineComment(text, value));
	    }
		
		public MainSyntax Main(SyntaxList<NamespaceDeclarationSyntax> namespaceDeclaration, SyntaxToken eof)
		{
		    if (eof == null) throw new ArgumentNullException(nameof(eof));
		    if (eof.GetKind() != SoalSyntaxKind.Eof) throw new ArgumentException(nameof(eof));
		    return (MainSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Main(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<NamespaceDeclarationGreen>(namespaceDeclaration.Node), (InternalSyntaxToken)eof.Node).CreateRed();
		}
		
		public MainSyntax Main(SyntaxToken eof)
		{
			return this.Main(default, eof);
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public QualifiedNameSyntax QualifiedName(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifiedNameSyntax)SoalLanguage.Instance.InternalSyntaxFactory.QualifiedName((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public QualifierSyntax Qualifier(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Qualifier(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public IdentifierListSyntax IdentifierList(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierListSyntax)SoalLanguage.Instance.InternalSyntaxFactory.IdentifierList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public QualifierListSyntax QualifierList(SeparatedSyntaxList<QualifierSyntax> qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifierListSyntax)SoalLanguage.Instance.InternalSyntaxFactory.QualifierList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<QualifierGreen>(qualifier.Node)).CreateRed();
		}
		
		public AnnotationListSyntax AnnotationList(SyntaxList<AnnotationSyntax> annotation)
		{
		    if (annotation == null) throw new ArgumentNullException(nameof(annotation));
		    return (AnnotationListSyntax)SoalLanguage.Instance.InternalSyntaxFactory.AnnotationList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node)).CreateRed();
		}
		
		public ReturnAnnotationListSyntax ReturnAnnotationList(SyntaxList<ReturnAnnotationSyntax> returnAnnotation)
		{
		    if (returnAnnotation == null) throw new ArgumentNullException(nameof(returnAnnotation));
		    return (ReturnAnnotationListSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ReturnAnnotationList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ReturnAnnotationGreen>(returnAnnotation.Node)).CreateRed();
		}
		
		public AnnotationSyntax Annotation(SyntaxToken tOpenBracket, AnnotationHeadSyntax annotationHead, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (annotationHead == null) throw new ArgumentNullException(nameof(annotationHead));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (AnnotationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Annotation((InternalSyntaxToken)tOpenBracket.Node, (Syntax.InternalSyntax.AnnotationHeadGreen)annotationHead.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public AnnotationSyntax Annotation(AnnotationHeadSyntax annotationHead)
		{
			return this.Annotation(this.Token(SoalSyntaxKind.TOpenBracket), annotationHead, this.Token(SoalSyntaxKind.TCloseBracket));
		}
		
		public ReturnAnnotationSyntax ReturnAnnotation(SyntaxToken tOpenBracket, SyntaxToken kReturn, SyntaxToken tColon, AnnotationHeadSyntax annotationHead, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (kReturn == null) throw new ArgumentNullException(nameof(kReturn));
		    if (kReturn.GetKind() != SoalSyntaxKind.KReturn) throw new ArgumentException(nameof(kReturn));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (annotationHead == null) throw new ArgumentNullException(nameof(annotationHead));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (ReturnAnnotationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ReturnAnnotation((InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)kReturn.Node, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.AnnotationHeadGreen)annotationHead.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public ReturnAnnotationSyntax ReturnAnnotation(AnnotationHeadSyntax annotationHead)
		{
			return this.ReturnAnnotation(this.Token(SoalSyntaxKind.TOpenBracket), this.Token(SoalSyntaxKind.KReturn), this.Token(SoalSyntaxKind.TColon), annotationHead, this.Token(SoalSyntaxKind.TCloseBracket));
		}
		
		public AnnotationHeadSyntax AnnotationHead(NameSyntax name, AnnotationBodySyntax annotationBody)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (AnnotationHeadSyntax)SoalLanguage.Instance.InternalSyntaxFactory.AnnotationHead((Syntax.InternalSyntax.NameGreen)name.Green, annotationBody == null ? null : (Syntax.InternalSyntax.AnnotationBodyGreen)annotationBody.Green).CreateRed();
		}
		
		public AnnotationHeadSyntax AnnotationHead(NameSyntax name)
		{
			return this.AnnotationHead(name, default);
		}
		
		public AnnotationBodySyntax AnnotationBody(SyntaxToken tOpenParen, AnnotationPropertyListSyntax annotationPropertyList, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != SoalSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != SoalSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (AnnotationBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.AnnotationBody((InternalSyntaxToken)tOpenParen.Node, annotationPropertyList == null ? null : (Syntax.InternalSyntax.AnnotationPropertyListGreen)annotationPropertyList.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public AnnotationBodySyntax AnnotationBody()
		{
			return this.AnnotationBody(this.Token(SoalSyntaxKind.TOpenParen), default, this.Token(SoalSyntaxKind.TCloseParen));
		}
		
		public AnnotationPropertyListSyntax AnnotationPropertyList(SeparatedSyntaxList<AnnotationPropertySyntax> annotationProperty)
		{
		    if (annotationProperty == null) throw new ArgumentNullException(nameof(annotationProperty));
		    return (AnnotationPropertyListSyntax)SoalLanguage.Instance.InternalSyntaxFactory.AnnotationPropertyList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<AnnotationPropertyGreen>(annotationProperty.Node)).CreateRed();
		}
		
		public AnnotationPropertySyntax AnnotationProperty(NameSyntax name, SyntaxToken tAssign, AnnotationPropertyValueSyntax annotationPropertyValue)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (annotationPropertyValue == null) throw new ArgumentNullException(nameof(annotationPropertyValue));
		    return (AnnotationPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.AnnotationProperty((Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.AnnotationPropertyValueGreen)annotationPropertyValue.Green).CreateRed();
		}
		
		public AnnotationPropertySyntax AnnotationProperty(NameSyntax name, AnnotationPropertyValueSyntax annotationPropertyValue)
		{
			return this.AnnotationProperty(name, this.Token(SoalSyntaxKind.TAssign), annotationPropertyValue);
		}
		
		public AnnotationPropertyValueSyntax AnnotationPropertyValue(ConstantValueSyntax constantValue)
		{
		    if (constantValue == null) throw new ArgumentNullException(nameof(constantValue));
		    return (AnnotationPropertyValueSyntax)SoalLanguage.Instance.InternalSyntaxFactory.AnnotationPropertyValue((Syntax.InternalSyntax.ConstantValueGreen)constantValue.Green).CreateRed();
		}
		
		public AnnotationPropertyValueSyntax AnnotationPropertyValue(TypeofValueSyntax typeofValue)
		{
		    if (typeofValue == null) throw new ArgumentNullException(nameof(typeofValue));
		    return (AnnotationPropertyValueSyntax)SoalLanguage.Instance.InternalSyntaxFactory.AnnotationPropertyValue((Syntax.InternalSyntax.TypeofValueGreen)typeofValue.Green).CreateRed();
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(AnnotationListSyntax annotationList, SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, SyntaxToken tAssign, NamespacePrefixSyntax namespacePrefix, SyntaxToken tColon, NamespaceUriSyntax namespaceUri, NamespaceBodySyntax namespaceBody)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != SoalSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (tColon != null && tColon.GetKind() != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (namespaceUri == null) throw new ArgumentNullException(nameof(namespaceUri));
		    if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
		    return (NamespaceDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(annotationList == null ? null : (Syntax.InternalSyntax.AnnotationListGreen)annotationList.Green, (InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (InternalSyntaxToken)tAssign.Node, namespacePrefix == null ? null : (Syntax.InternalSyntax.NamespacePrefixGreen)namespacePrefix.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.NamespaceUriGreen)namespaceUri.Green, (Syntax.InternalSyntax.NamespaceBodyGreen)namespaceBody.Green).CreateRed();
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(QualifiedNameSyntax qualifiedName, NamespaceUriSyntax namespaceUri, NamespaceBodySyntax namespaceBody)
		{
			return this.NamespaceDeclaration(default, this.Token(SoalSyntaxKind.KNamespace), qualifiedName, this.Token(SoalSyntaxKind.TAssign), default, default, namespaceUri, namespaceBody);
		}
		
		public NamespacePrefixSyntax NamespacePrefix(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NamespacePrefixSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NamespacePrefix((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public NamespaceUriSyntax NamespaceUri(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (NamespaceUriSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NamespaceUri((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public NamespaceBodySyntax NamespaceBody(SyntaxToken tOpenBrace, SyntaxList<DeclarationSyntax> declaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.NamespaceBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<DeclarationGreen>(declaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBodySyntax NamespaceBody()
		{
			return this.NamespaceBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public DeclarationSyntax Declaration(EnumDeclarationSyntax enumDeclaration)
		{
		    if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.EnumDeclarationGreen)enumDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(StructDeclarationSyntax structDeclaration)
		{
		    if (structDeclaration == null) throw new ArgumentNullException(nameof(structDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.StructDeclarationGreen)structDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(DatabaseDeclarationSyntax databaseDeclaration)
		{
		    if (databaseDeclaration == null) throw new ArgumentNullException(nameof(databaseDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.DatabaseDeclarationGreen)databaseDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(InterfaceDeclarationSyntax interfaceDeclaration)
		{
		    if (interfaceDeclaration == null) throw new ArgumentNullException(nameof(interfaceDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.InterfaceDeclarationGreen)interfaceDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(ComponentDeclarationSyntax componentDeclaration)
		{
		    if (componentDeclaration == null) throw new ArgumentNullException(nameof(componentDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.ComponentDeclarationGreen)componentDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(CompositeDeclarationSyntax compositeDeclaration)
		{
		    if (compositeDeclaration == null) throw new ArgumentNullException(nameof(compositeDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.CompositeDeclarationGreen)compositeDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(AssemblyDeclarationSyntax assemblyDeclaration)
		{
		    if (assemblyDeclaration == null) throw new ArgumentNullException(nameof(assemblyDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.AssemblyDeclarationGreen)assemblyDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(BindingDeclarationSyntax bindingDeclaration)
		{
		    if (bindingDeclaration == null) throw new ArgumentNullException(nameof(bindingDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.BindingDeclarationGreen)bindingDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(EndpointDeclarationSyntax endpointDeclaration)
		{
		    if (endpointDeclaration == null) throw new ArgumentNullException(nameof(endpointDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.EndpointDeclarationGreen)endpointDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(DeploymentDeclarationSyntax deploymentDeclaration)
		{
		    if (deploymentDeclaration == null) throw new ArgumentNullException(nameof(deploymentDeclaration));
		    return (DeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.DeploymentDeclarationGreen)deploymentDeclaration.Green).CreateRed();
		}
		
		public EnumDeclarationSyntax EnumDeclaration(AnnotationListSyntax annotationList, SyntaxToken kEnum, NameSyntax name, SyntaxToken tColon, EnumBaseSyntax enumBase, EnumBodySyntax enumBody)
		{
		    if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
		    if (kEnum.GetKind() != SoalSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon != null && tColon.GetKind() != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
		    return (EnumDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(annotationList == null ? null : (Syntax.InternalSyntax.AnnotationListGreen)annotationList.Green, (InternalSyntaxToken)kEnum.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, enumBase == null ? null : (Syntax.InternalSyntax.EnumBaseGreen)enumBase.Green, (Syntax.InternalSyntax.EnumBodyGreen)enumBody.Green).CreateRed();
		}
		
		public EnumDeclarationSyntax EnumDeclaration(NameSyntax name, EnumBodySyntax enumBody)
		{
			return this.EnumDeclaration(default, this.Token(SoalSyntaxKind.KEnum), name, default, default, enumBody);
		}
		
		public EnumBaseSyntax EnumBase(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (EnumBaseSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EnumBase((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public EnumBodySyntax EnumBody(SyntaxToken tOpenBrace, EnumLiteralsSyntax enumLiterals, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (EnumBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.EnumBody((InternalSyntaxToken)tOpenBrace.Node, enumLiterals == null ? null : (Syntax.InternalSyntax.EnumLiteralsGreen)enumLiterals.Green, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public EnumBodySyntax EnumBody()
		{
			return this.EnumBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public EnumLiteralsSyntax EnumLiterals(SeparatedSyntaxList<EnumLiteralSyntax> enumLiteral)
		{
		    if (enumLiteral == null) throw new ArgumentNullException(nameof(enumLiteral));
		    return (EnumLiteralsSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EnumLiterals(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<EnumLiteralGreen>(enumLiteral.Node)).CreateRed();
		}
		
		public EnumLiteralSyntax EnumLiteral(AnnotationListSyntax annotationList, NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (EnumLiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EnumLiteral(annotationList == null ? null : (Syntax.InternalSyntax.AnnotationListGreen)annotationList.Green, (Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public EnumLiteralSyntax EnumLiteral(NameSyntax name)
		{
			return this.EnumLiteral(default, name);
		}
		
		public StructDeclarationSyntax StructDeclaration(AnnotationListSyntax annotationList, SyntaxToken kStruct, NameSyntax name, SyntaxToken tColon, QualifierSyntax qualifier, StructBodySyntax structBody)
		{
		    if (kStruct == null) throw new ArgumentNullException(nameof(kStruct));
		    if (kStruct.GetKind() != SoalSyntaxKind.KStruct) throw new ArgumentException(nameof(kStruct));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon != null && tColon.GetKind() != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (structBody == null) throw new ArgumentNullException(nameof(structBody));
		    return (StructDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.StructDeclaration(annotationList == null ? null : (Syntax.InternalSyntax.AnnotationListGreen)annotationList.Green, (InternalSyntaxToken)kStruct.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, qualifier == null ? null : (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (Syntax.InternalSyntax.StructBodyGreen)structBody.Green).CreateRed();
		}
		
		public StructDeclarationSyntax StructDeclaration(NameSyntax name, StructBodySyntax structBody)
		{
			return this.StructDeclaration(default, this.Token(SoalSyntaxKind.KStruct), name, default, default, structBody);
		}
		
		public StructBodySyntax StructBody(SyntaxToken tOpenBrace, SyntaxList<PropertyDeclarationSyntax> propertyDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (StructBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.StructBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<PropertyDeclarationGreen>(propertyDeclaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public StructBodySyntax StructBody()
		{
			return this.StructBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public PropertyDeclarationSyntax PropertyDeclaration(AnnotationListSyntax annotationList, TypeReferenceSyntax typeReference, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (PropertyDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.PropertyDeclaration(annotationList == null ? null : (Syntax.InternalSyntax.AnnotationListGreen)annotationList.Green, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public PropertyDeclarationSyntax PropertyDeclaration(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.PropertyDeclaration(default, typeReference, name, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public DatabaseDeclarationSyntax DatabaseDeclaration(AnnotationListSyntax annotationList, SyntaxToken kDatabase, NameSyntax name, DatabaseBodySyntax databaseBody)
		{
		    if (kDatabase == null) throw new ArgumentNullException(nameof(kDatabase));
		    if (kDatabase.GetKind() != SoalSyntaxKind.KDatabase) throw new ArgumentException(nameof(kDatabase));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (databaseBody == null) throw new ArgumentNullException(nameof(databaseBody));
		    return (DatabaseDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.DatabaseDeclaration(annotationList == null ? null : (Syntax.InternalSyntax.AnnotationListGreen)annotationList.Green, (InternalSyntaxToken)kDatabase.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.DatabaseBodyGreen)databaseBody.Green).CreateRed();
		}
		
		public DatabaseDeclarationSyntax DatabaseDeclaration(NameSyntax name, DatabaseBodySyntax databaseBody)
		{
			return this.DatabaseDeclaration(default, this.Token(SoalSyntaxKind.KDatabase), name, databaseBody);
		}
		
		public DatabaseBodySyntax DatabaseBody(SyntaxToken tOpenBrace, SyntaxList<EntityReferenceSyntax> entityReference, SyntaxList<OperationDeclarationSyntax> operationDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (DatabaseBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.DatabaseBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<EntityReferenceGreen>(entityReference.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<OperationDeclarationGreen>(operationDeclaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public DatabaseBodySyntax DatabaseBody()
		{
			return this.DatabaseBody(this.Token(SoalSyntaxKind.TOpenBrace), default, default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public EntityReferenceSyntax EntityReference(SyntaxToken kEntity, QualifierSyntax qualifier, SyntaxToken tSemicolon)
		{
		    if (kEntity == null) throw new ArgumentNullException(nameof(kEntity));
		    if (kEntity.GetKind() != SoalSyntaxKind.KEntity) throw new ArgumentException(nameof(kEntity));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (EntityReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EntityReference((InternalSyntaxToken)kEntity.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public EntityReferenceSyntax EntityReference(QualifierSyntax qualifier)
		{
			return this.EntityReference(this.Token(SoalSyntaxKind.KEntity), qualifier, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public InterfaceDeclarationSyntax InterfaceDeclaration(AnnotationListSyntax annotationList, SyntaxToken kInterface, NameSyntax name, InterfaceBodySyntax interfaceBody)
		{
		    if (kInterface == null) throw new ArgumentNullException(nameof(kInterface));
		    if (kInterface.GetKind() != SoalSyntaxKind.KInterface) throw new ArgumentException(nameof(kInterface));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (interfaceBody == null) throw new ArgumentNullException(nameof(interfaceBody));
		    return (InterfaceDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.InterfaceDeclaration(annotationList == null ? null : (Syntax.InternalSyntax.AnnotationListGreen)annotationList.Green, (InternalSyntaxToken)kInterface.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.InterfaceBodyGreen)interfaceBody.Green).CreateRed();
		}
		
		public InterfaceDeclarationSyntax InterfaceDeclaration(NameSyntax name, InterfaceBodySyntax interfaceBody)
		{
			return this.InterfaceDeclaration(default, this.Token(SoalSyntaxKind.KInterface), name, interfaceBody);
		}
		
		public InterfaceBodySyntax InterfaceBody(SyntaxToken tOpenBrace, SyntaxList<OperationDeclarationSyntax> operationDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (InterfaceBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.InterfaceBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<OperationDeclarationGreen>(operationDeclaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public InterfaceBodySyntax InterfaceBody()
		{
			return this.InterfaceBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public OperationDeclarationSyntax OperationDeclaration(OperationHeadSyntax operationHead, SyntaxToken tSemicolon)
		{
		    if (operationHead == null) throw new ArgumentNullException(nameof(operationHead));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (OperationDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.OperationDeclaration((Syntax.InternalSyntax.OperationHeadGreen)operationHead.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public OperationDeclarationSyntax OperationDeclaration(OperationHeadSyntax operationHead)
		{
			return this.OperationDeclaration(operationHead, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public OperationHeadSyntax OperationHead(AnnotationListSyntax annotationList, OperationResultSyntax operationResult, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, ThrowsListSyntax throwsList)
		{
		    if (operationResult == null) throw new ArgumentNullException(nameof(operationResult));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != SoalSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != SoalSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (OperationHeadSyntax)SoalLanguage.Instance.InternalSyntaxFactory.OperationHead(annotationList == null ? null : (Syntax.InternalSyntax.AnnotationListGreen)annotationList.Green, (Syntax.InternalSyntax.OperationResultGreen)operationResult.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Node, parameterList == null ? null : (Syntax.InternalSyntax.ParameterListGreen)parameterList.Green, (InternalSyntaxToken)tCloseParen.Node, throwsList == null ? null : (Syntax.InternalSyntax.ThrowsListGreen)throwsList.Green).CreateRed();
		}
		
		public OperationHeadSyntax OperationHead(OperationResultSyntax operationResult, NameSyntax name)
		{
			return this.OperationHead(default, operationResult, name, this.Token(SoalSyntaxKind.TOpenParen), default, this.Token(SoalSyntaxKind.TCloseParen), default);
		}
		
		public ParameterListSyntax ParameterList(SeparatedSyntaxList<ParameterSyntax> parameter)
		{
		    if (parameter == null) throw new ArgumentNullException(nameof(parameter));
		    return (ParameterListSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ParameterList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParameterGreen>(parameter.Node)).CreateRed();
		}
		
		public ParameterSyntax Parameter(AnnotationListSyntax annotationList, TypeReferenceSyntax typeReference, NameSyntax name)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (ParameterSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Parameter(annotationList == null ? null : (Syntax.InternalSyntax.AnnotationListGreen)annotationList.Green, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public ParameterSyntax Parameter(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.Parameter(default, typeReference, name);
		}
		
		public OperationResultSyntax OperationResult(ReturnAnnotationListSyntax returnAnnotationList, OperationReturnTypeSyntax operationReturnType)
		{
		    if (operationReturnType == null) throw new ArgumentNullException(nameof(operationReturnType));
		    return (OperationResultSyntax)SoalLanguage.Instance.InternalSyntaxFactory.OperationResult(returnAnnotationList == null ? null : (Syntax.InternalSyntax.ReturnAnnotationListGreen)returnAnnotationList.Green, (Syntax.InternalSyntax.OperationReturnTypeGreen)operationReturnType.Green).CreateRed();
		}
		
		public OperationResultSyntax OperationResult(OperationReturnTypeSyntax operationReturnType)
		{
			return this.OperationResult(default, operationReturnType);
		}
		
		public ThrowsListSyntax ThrowsList(SyntaxToken kThrows, QualifierListSyntax qualifierList)
		{
		    if (kThrows == null) throw new ArgumentNullException(nameof(kThrows));
		    if (kThrows.GetKind() != SoalSyntaxKind.KThrows) throw new ArgumentException(nameof(kThrows));
		    if (qualifierList == null) throw new ArgumentNullException(nameof(qualifierList));
		    return (ThrowsListSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ThrowsList((InternalSyntaxToken)kThrows.Node, (Syntax.InternalSyntax.QualifierListGreen)qualifierList.Green).CreateRed();
		}
		
		public ThrowsListSyntax ThrowsList(QualifierListSyntax qualifierList)
		{
			return this.ThrowsList(this.Token(SoalSyntaxKind.KThrows), qualifierList);
		}
		
		public ComponentDeclarationSyntax ComponentDeclaration(SyntaxToken kAbstract, SyntaxToken kComponent, NameSyntax name, SyntaxToken tColon, ComponentBaseSyntax componentBase, ComponentBodySyntax componentBody)
		{
		    if (kAbstract != null && kAbstract.GetKind() != SoalSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
		    if (kComponent == null) throw new ArgumentNullException(nameof(kComponent));
		    if (kComponent.GetKind() != SoalSyntaxKind.KComponent) throw new ArgumentException(nameof(kComponent));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon != null && tColon.GetKind() != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (componentBody == null) throw new ArgumentNullException(nameof(componentBody));
		    return (ComponentDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentDeclaration((InternalSyntaxToken)kAbstract.Node, (InternalSyntaxToken)kComponent.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, componentBase == null ? null : (Syntax.InternalSyntax.ComponentBaseGreen)componentBase.Green, (Syntax.InternalSyntax.ComponentBodyGreen)componentBody.Green).CreateRed();
		}
		
		public ComponentDeclarationSyntax ComponentDeclaration(NameSyntax name, ComponentBodySyntax componentBody)
		{
			return this.ComponentDeclaration(default, this.Token(SoalSyntaxKind.KComponent), name, default, default, componentBody);
		}
		
		public ComponentBaseSyntax ComponentBase(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (ComponentBaseSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentBase((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ComponentBodySyntax ComponentBody(SyntaxToken tOpenBrace, ComponentElementsSyntax componentElements, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (ComponentBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentBody((InternalSyntaxToken)tOpenBrace.Node, componentElements == null ? null : (Syntax.InternalSyntax.ComponentElementsGreen)componentElements.Green, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public ComponentBodySyntax ComponentBody()
		{
			return this.ComponentBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public ComponentElementsSyntax ComponentElements(SyntaxList<ComponentElementSyntax> componentElement)
		{
		    if (componentElement == null) throw new ArgumentNullException(nameof(componentElement));
		    return (ComponentElementsSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentElements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ComponentElementGreen>(componentElement.Node)).CreateRed();
		}
		
		public ComponentElementSyntax ComponentElement(ComponentServiceSyntax componentService)
		{
		    if (componentService == null) throw new ArgumentNullException(nameof(componentService));
		    return (ComponentElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement((Syntax.InternalSyntax.ComponentServiceGreen)componentService.Green).CreateRed();
		}
		
		public ComponentElementSyntax ComponentElement(ComponentReferenceSyntax componentReference)
		{
		    if (componentReference == null) throw new ArgumentNullException(nameof(componentReference));
		    return (ComponentElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement((Syntax.InternalSyntax.ComponentReferenceGreen)componentReference.Green).CreateRed();
		}
		
		public ComponentElementSyntax ComponentElement(ComponentPropertySyntax componentProperty)
		{
		    if (componentProperty == null) throw new ArgumentNullException(nameof(componentProperty));
		    return (ComponentElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement((Syntax.InternalSyntax.ComponentPropertyGreen)componentProperty.Green).CreateRed();
		}
		
		public ComponentElementSyntax ComponentElement(ComponentImplementationSyntax componentImplementation)
		{
		    if (componentImplementation == null) throw new ArgumentNullException(nameof(componentImplementation));
		    return (ComponentElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement((Syntax.InternalSyntax.ComponentImplementationGreen)componentImplementation.Green).CreateRed();
		}
		
		public ComponentElementSyntax ComponentElement(ComponentLanguageSyntax componentLanguage)
		{
		    if (componentLanguage == null) throw new ArgumentNullException(nameof(componentLanguage));
		    return (ComponentElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentElement((Syntax.InternalSyntax.ComponentLanguageGreen)componentLanguage.Green).CreateRed();
		}
		
		public ComponentServiceSyntax ComponentService(SyntaxToken kService, QualifierSyntax qualifier, NameSyntax name, ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody)
		{
		    if (kService == null) throw new ArgumentNullException(nameof(kService));
		    if (kService.GetKind() != SoalSyntaxKind.KService) throw new ArgumentException(nameof(kService));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (componentServiceOrReferenceBody == null) throw new ArgumentNullException(nameof(componentServiceOrReferenceBody));
		    return (ComponentServiceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentService((InternalSyntaxToken)kService.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, name == null ? null : (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.ComponentServiceOrReferenceBodyGreen)componentServiceOrReferenceBody.Green).CreateRed();
		}
		
		public ComponentServiceSyntax ComponentService(QualifierSyntax qualifier, ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody)
		{
			return this.ComponentService(this.Token(SoalSyntaxKind.KService), qualifier, default, componentServiceOrReferenceBody);
		}
		
		public ComponentReferenceSyntax ComponentReference(SyntaxToken kReference, QualifierSyntax qualifier, NameSyntax name, ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody)
		{
		    if (kReference == null) throw new ArgumentNullException(nameof(kReference));
		    if (kReference.GetKind() != SoalSyntaxKind.KReference) throw new ArgumentException(nameof(kReference));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (componentServiceOrReferenceBody == null) throw new ArgumentNullException(nameof(componentServiceOrReferenceBody));
		    return (ComponentReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentReference((InternalSyntaxToken)kReference.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, name == null ? null : (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.ComponentServiceOrReferenceBodyGreen)componentServiceOrReferenceBody.Green).CreateRed();
		}
		
		public ComponentReferenceSyntax ComponentReference(QualifierSyntax qualifier, ComponentServiceOrReferenceBodySyntax componentServiceOrReferenceBody)
		{
			return this.ComponentReference(this.Token(SoalSyntaxKind.KReference), qualifier, default, componentServiceOrReferenceBody);
		}
		
		public ComponentServiceOrReferenceEmptyBodySyntax ComponentServiceOrReferenceEmptyBody(SyntaxToken tSemicolon)
		{
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ComponentServiceOrReferenceEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentServiceOrReferenceEmptyBody((InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ComponentServiceOrReferenceEmptyBodySyntax ComponentServiceOrReferenceEmptyBody()
		{
			return this.ComponentServiceOrReferenceEmptyBody(this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public ComponentServiceOrReferenceNonEmptyBodySyntax ComponentServiceOrReferenceNonEmptyBody(SyntaxToken tOpenBrace, SyntaxList<ComponentServiceOrReferenceElementSyntax> componentServiceOrReferenceElement, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (ComponentServiceOrReferenceNonEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentServiceOrReferenceNonEmptyBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ComponentServiceOrReferenceElementGreen>(componentServiceOrReferenceElement.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public ComponentServiceOrReferenceNonEmptyBodySyntax ComponentServiceOrReferenceNonEmptyBody()
		{
			return this.ComponentServiceOrReferenceNonEmptyBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public ComponentServiceOrReferenceElementSyntax ComponentServiceOrReferenceElement(SyntaxToken kBinding, QualifierSyntax qualifier, SyntaxToken tSemicolon)
		{
		    if (kBinding == null) throw new ArgumentNullException(nameof(kBinding));
		    if (kBinding.GetKind() != SoalSyntaxKind.KBinding) throw new ArgumentException(nameof(kBinding));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ComponentServiceOrReferenceElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentServiceOrReferenceElement((InternalSyntaxToken)kBinding.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ComponentServiceOrReferenceElementSyntax ComponentServiceOrReferenceElement(QualifierSyntax qualifier)
		{
			return this.ComponentServiceOrReferenceElement(this.Token(SoalSyntaxKind.KBinding), qualifier, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public ComponentPropertySyntax ComponentProperty(TypeReferenceSyntax typeReference, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ComponentPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentProperty((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ComponentPropertySyntax ComponentProperty(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.ComponentProperty(typeReference, name, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public ComponentImplementationSyntax ComponentImplementation(SyntaxToken kImplementation, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kImplementation == null) throw new ArgumentNullException(nameof(kImplementation));
		    if (kImplementation.GetKind() != SoalSyntaxKind.KImplementation) throw new ArgumentException(nameof(kImplementation));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ComponentImplementationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentImplementation((InternalSyntaxToken)kImplementation.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ComponentImplementationSyntax ComponentImplementation(NameSyntax name)
		{
			return this.ComponentImplementation(this.Token(SoalSyntaxKind.KImplementation), name, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public ComponentLanguageSyntax ComponentLanguage(SyntaxToken kLanguage, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kLanguage == null) throw new ArgumentNullException(nameof(kLanguage));
		    if (kLanguage.GetKind() != SoalSyntaxKind.KLanguage) throw new ArgumentException(nameof(kLanguage));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ComponentLanguageSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ComponentLanguage((InternalSyntaxToken)kLanguage.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ComponentLanguageSyntax ComponentLanguage(NameSyntax name)
		{
			return this.ComponentLanguage(this.Token(SoalSyntaxKind.KLanguage), name, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public CompositeDeclarationSyntax CompositeDeclaration(SyntaxToken kComposite, NameSyntax name, SyntaxToken tColon, ComponentBaseSyntax componentBase, CompositeBodySyntax compositeBody)
		{
		    if (kComposite == null) throw new ArgumentNullException(nameof(kComposite));
		    if (kComposite.GetKind() != SoalSyntaxKind.KComposite) throw new ArgumentException(nameof(kComposite));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon != null && tColon.GetKind() != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (compositeBody == null) throw new ArgumentNullException(nameof(compositeBody));
		    return (CompositeDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeDeclaration((InternalSyntaxToken)kComposite.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, componentBase == null ? null : (Syntax.InternalSyntax.ComponentBaseGreen)componentBase.Green, (Syntax.InternalSyntax.CompositeBodyGreen)compositeBody.Green).CreateRed();
		}
		
		public CompositeDeclarationSyntax CompositeDeclaration(NameSyntax name, CompositeBodySyntax compositeBody)
		{
			return this.CompositeDeclaration(this.Token(SoalSyntaxKind.KComposite), name, default, default, compositeBody);
		}
		
		public CompositeBodySyntax CompositeBody(SyntaxToken tOpenBrace, CompositeElementsSyntax compositeElements, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (CompositeBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeBody((InternalSyntaxToken)tOpenBrace.Node, compositeElements == null ? null : (Syntax.InternalSyntax.CompositeElementsGreen)compositeElements.Green, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public CompositeBodySyntax CompositeBody()
		{
			return this.CompositeBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public AssemblyDeclarationSyntax AssemblyDeclaration(SyntaxToken kAssembly, NameSyntax name, SyntaxToken tColon, ComponentBaseSyntax componentBase, CompositeBodySyntax compositeBody)
		{
		    if (kAssembly == null) throw new ArgumentNullException(nameof(kAssembly));
		    if (kAssembly.GetKind() != SoalSyntaxKind.KAssembly) throw new ArgumentException(nameof(kAssembly));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon != null && tColon.GetKind() != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (compositeBody == null) throw new ArgumentNullException(nameof(compositeBody));
		    return (AssemblyDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.AssemblyDeclaration((InternalSyntaxToken)kAssembly.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, componentBase == null ? null : (Syntax.InternalSyntax.ComponentBaseGreen)componentBase.Green, (Syntax.InternalSyntax.CompositeBodyGreen)compositeBody.Green).CreateRed();
		}
		
		public AssemblyDeclarationSyntax AssemblyDeclaration(NameSyntax name, CompositeBodySyntax compositeBody)
		{
			return this.AssemblyDeclaration(this.Token(SoalSyntaxKind.KAssembly), name, default, default, compositeBody);
		}
		
		public CompositeElementsSyntax CompositeElements(SyntaxList<CompositeElementSyntax> compositeElement)
		{
		    if (compositeElement == null) throw new ArgumentNullException(nameof(compositeElement));
		    return (CompositeElementsSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeElements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<CompositeElementGreen>(compositeElement.Node)).CreateRed();
		}
		
		public CompositeElementSyntax CompositeElement(ComponentServiceSyntax componentService)
		{
		    if (componentService == null) throw new ArgumentNullException(nameof(componentService));
		    return (CompositeElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement((Syntax.InternalSyntax.ComponentServiceGreen)componentService.Green).CreateRed();
		}
		
		public CompositeElementSyntax CompositeElement(ComponentReferenceSyntax componentReference)
		{
		    if (componentReference == null) throw new ArgumentNullException(nameof(componentReference));
		    return (CompositeElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement((Syntax.InternalSyntax.ComponentReferenceGreen)componentReference.Green).CreateRed();
		}
		
		public CompositeElementSyntax CompositeElement(ComponentPropertySyntax componentProperty)
		{
		    if (componentProperty == null) throw new ArgumentNullException(nameof(componentProperty));
		    return (CompositeElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement((Syntax.InternalSyntax.ComponentPropertyGreen)componentProperty.Green).CreateRed();
		}
		
		public CompositeElementSyntax CompositeElement(ComponentImplementationSyntax componentImplementation)
		{
		    if (componentImplementation == null) throw new ArgumentNullException(nameof(componentImplementation));
		    return (CompositeElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement((Syntax.InternalSyntax.ComponentImplementationGreen)componentImplementation.Green).CreateRed();
		}
		
		public CompositeElementSyntax CompositeElement(ComponentLanguageSyntax componentLanguage)
		{
		    if (componentLanguage == null) throw new ArgumentNullException(nameof(componentLanguage));
		    return (CompositeElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement((Syntax.InternalSyntax.ComponentLanguageGreen)componentLanguage.Green).CreateRed();
		}
		
		public CompositeElementSyntax CompositeElement(CompositeComponentSyntax compositeComponent)
		{
		    if (compositeComponent == null) throw new ArgumentNullException(nameof(compositeComponent));
		    return (CompositeElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement((Syntax.InternalSyntax.CompositeComponentGreen)compositeComponent.Green).CreateRed();
		}
		
		public CompositeElementSyntax CompositeElement(CompositeWireSyntax compositeWire)
		{
		    if (compositeWire == null) throw new ArgumentNullException(nameof(compositeWire));
		    return (CompositeElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeElement((Syntax.InternalSyntax.CompositeWireGreen)compositeWire.Green).CreateRed();
		}
		
		public CompositeComponentSyntax CompositeComponent(SyntaxToken kComponent, QualifierSyntax qualifier, SyntaxToken tSemicolon)
		{
		    if (kComponent == null) throw new ArgumentNullException(nameof(kComponent));
		    if (kComponent.GetKind() != SoalSyntaxKind.KComponent) throw new ArgumentException(nameof(kComponent));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (CompositeComponentSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeComponent((InternalSyntaxToken)kComponent.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public CompositeComponentSyntax CompositeComponent(QualifierSyntax qualifier)
		{
			return this.CompositeComponent(this.Token(SoalSyntaxKind.KComponent), qualifier, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public CompositeWireSyntax CompositeWire(SyntaxToken kWire, WireSourceSyntax wireSource, SyntaxToken kTo, WireTargetSyntax wireTarget, SyntaxToken tSemicolon)
		{
		    if (kWire == null) throw new ArgumentNullException(nameof(kWire));
		    if (kWire.GetKind() != SoalSyntaxKind.KWire) throw new ArgumentException(nameof(kWire));
		    if (wireSource == null) throw new ArgumentNullException(nameof(wireSource));
		    if (kTo == null) throw new ArgumentNullException(nameof(kTo));
		    if (kTo.GetKind() != SoalSyntaxKind.KTo) throw new ArgumentException(nameof(kTo));
		    if (wireTarget == null) throw new ArgumentNullException(nameof(wireTarget));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (CompositeWireSyntax)SoalLanguage.Instance.InternalSyntaxFactory.CompositeWire((InternalSyntaxToken)kWire.Node, (Syntax.InternalSyntax.WireSourceGreen)wireSource.Green, (InternalSyntaxToken)kTo.Node, (Syntax.InternalSyntax.WireTargetGreen)wireTarget.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public CompositeWireSyntax CompositeWire(WireSourceSyntax wireSource, WireTargetSyntax wireTarget)
		{
			return this.CompositeWire(this.Token(SoalSyntaxKind.KWire), wireSource, this.Token(SoalSyntaxKind.KTo), wireTarget, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public WireSourceSyntax WireSource(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (WireSourceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.WireSource((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public WireTargetSyntax WireTarget(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (WireTargetSyntax)SoalLanguage.Instance.InternalSyntaxFactory.WireTarget((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public DeploymentDeclarationSyntax DeploymentDeclaration(SyntaxToken kDeployment, NameSyntax name, DeploymentBodySyntax deploymentBody)
		{
		    if (kDeployment == null) throw new ArgumentNullException(nameof(kDeployment));
		    if (kDeployment.GetKind() != SoalSyntaxKind.KDeployment) throw new ArgumentException(nameof(kDeployment));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (deploymentBody == null) throw new ArgumentNullException(nameof(deploymentBody));
		    return (DeploymentDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.DeploymentDeclaration((InternalSyntaxToken)kDeployment.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.DeploymentBodyGreen)deploymentBody.Green).CreateRed();
		}
		
		public DeploymentDeclarationSyntax DeploymentDeclaration(NameSyntax name, DeploymentBodySyntax deploymentBody)
		{
			return this.DeploymentDeclaration(this.Token(SoalSyntaxKind.KDeployment), name, deploymentBody);
		}
		
		public DeploymentBodySyntax DeploymentBody(SyntaxToken tOpenBrace, DeploymentElementsSyntax deploymentElements, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (DeploymentBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.DeploymentBody((InternalSyntaxToken)tOpenBrace.Node, deploymentElements == null ? null : (Syntax.InternalSyntax.DeploymentElementsGreen)deploymentElements.Green, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public DeploymentBodySyntax DeploymentBody()
		{
			return this.DeploymentBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public DeploymentElementsSyntax DeploymentElements(SyntaxList<DeploymentElementSyntax> deploymentElement)
		{
		    if (deploymentElement == null) throw new ArgumentNullException(nameof(deploymentElement));
		    return (DeploymentElementsSyntax)SoalLanguage.Instance.InternalSyntaxFactory.DeploymentElements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<DeploymentElementGreen>(deploymentElement.Node)).CreateRed();
		}
		
		public DeploymentElementSyntax DeploymentElement(EnvironmentDeclarationSyntax environmentDeclaration)
		{
		    if (environmentDeclaration == null) throw new ArgumentNullException(nameof(environmentDeclaration));
		    return (DeploymentElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.DeploymentElement((Syntax.InternalSyntax.EnvironmentDeclarationGreen)environmentDeclaration.Green).CreateRed();
		}
		
		public DeploymentElementSyntax DeploymentElement(CompositeWireSyntax compositeWire)
		{
		    if (compositeWire == null) throw new ArgumentNullException(nameof(compositeWire));
		    return (DeploymentElementSyntax)SoalLanguage.Instance.InternalSyntaxFactory.DeploymentElement((Syntax.InternalSyntax.CompositeWireGreen)compositeWire.Green).CreateRed();
		}
		
		public EnvironmentDeclarationSyntax EnvironmentDeclaration(SyntaxToken kEnvironment, NameSyntax name, EnvironmentBodySyntax environmentBody)
		{
		    if (kEnvironment == null) throw new ArgumentNullException(nameof(kEnvironment));
		    if (kEnvironment.GetKind() != SoalSyntaxKind.KEnvironment) throw new ArgumentException(nameof(kEnvironment));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (environmentBody == null) throw new ArgumentNullException(nameof(environmentBody));
		    return (EnvironmentDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EnvironmentDeclaration((InternalSyntaxToken)kEnvironment.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.EnvironmentBodyGreen)environmentBody.Green).CreateRed();
		}
		
		public EnvironmentDeclarationSyntax EnvironmentDeclaration(NameSyntax name, EnvironmentBodySyntax environmentBody)
		{
			return this.EnvironmentDeclaration(this.Token(SoalSyntaxKind.KEnvironment), name, environmentBody);
		}
		
		public EnvironmentBodySyntax EnvironmentBody(SyntaxToken tOpenBrace, RuntimeDeclarationSyntax runtimeDeclaration, SyntaxList<RuntimeReferenceSyntax> runtimeReference, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (runtimeDeclaration == null) throw new ArgumentNullException(nameof(runtimeDeclaration));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (EnvironmentBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.EnvironmentBody((InternalSyntaxToken)tOpenBrace.Node, (Syntax.InternalSyntax.RuntimeDeclarationGreen)runtimeDeclaration.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<RuntimeReferenceGreen>(runtimeReference.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public EnvironmentBodySyntax EnvironmentBody(RuntimeDeclarationSyntax runtimeDeclaration)
		{
			return this.EnvironmentBody(this.Token(SoalSyntaxKind.TOpenBrace), runtimeDeclaration, default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public RuntimeDeclarationSyntax RuntimeDeclaration(SyntaxToken kRuntime, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kRuntime == null) throw new ArgumentNullException(nameof(kRuntime));
		    if (kRuntime.GetKind() != SoalSyntaxKind.KRuntime) throw new ArgumentException(nameof(kRuntime));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (RuntimeDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.RuntimeDeclaration((InternalSyntaxToken)kRuntime.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public RuntimeDeclarationSyntax RuntimeDeclaration(NameSyntax name)
		{
			return this.RuntimeDeclaration(this.Token(SoalSyntaxKind.KRuntime), name, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public RuntimeReferenceSyntax RuntimeReference(AssemblyReferenceSyntax assemblyReference)
		{
		    if (assemblyReference == null) throw new ArgumentNullException(nameof(assemblyReference));
		    return (RuntimeReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.RuntimeReference((Syntax.InternalSyntax.AssemblyReferenceGreen)assemblyReference.Green).CreateRed();
		}
		
		public RuntimeReferenceSyntax RuntimeReference(DatabaseReferenceSyntax databaseReference)
		{
		    if (databaseReference == null) throw new ArgumentNullException(nameof(databaseReference));
		    return (RuntimeReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.RuntimeReference((Syntax.InternalSyntax.DatabaseReferenceGreen)databaseReference.Green).CreateRed();
		}
		
		public AssemblyReferenceSyntax AssemblyReference(SyntaxToken kAssembly, QualifierSyntax qualifier, SyntaxToken tSemicolon)
		{
		    if (kAssembly == null) throw new ArgumentNullException(nameof(kAssembly));
		    if (kAssembly.GetKind() != SoalSyntaxKind.KAssembly) throw new ArgumentException(nameof(kAssembly));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (AssemblyReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.AssemblyReference((InternalSyntaxToken)kAssembly.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public AssemblyReferenceSyntax AssemblyReference(QualifierSyntax qualifier)
		{
			return this.AssemblyReference(this.Token(SoalSyntaxKind.KAssembly), qualifier, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public DatabaseReferenceSyntax DatabaseReference(SyntaxToken kDatabase, QualifierSyntax qualifier, SyntaxToken tSemicolon)
		{
		    if (kDatabase == null) throw new ArgumentNullException(nameof(kDatabase));
		    if (kDatabase.GetKind() != SoalSyntaxKind.KDatabase) throw new ArgumentException(nameof(kDatabase));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (DatabaseReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.DatabaseReference((InternalSyntaxToken)kDatabase.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public DatabaseReferenceSyntax DatabaseReference(QualifierSyntax qualifier)
		{
			return this.DatabaseReference(this.Token(SoalSyntaxKind.KDatabase), qualifier, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public BindingDeclarationSyntax BindingDeclaration(SyntaxToken kBinding, NameSyntax name, BindingBodySyntax bindingBody)
		{
		    if (kBinding == null) throw new ArgumentNullException(nameof(kBinding));
		    if (kBinding.GetKind() != SoalSyntaxKind.KBinding) throw new ArgumentException(nameof(kBinding));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (bindingBody == null) throw new ArgumentNullException(nameof(bindingBody));
		    return (BindingDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.BindingDeclaration((InternalSyntaxToken)kBinding.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.BindingBodyGreen)bindingBody.Green).CreateRed();
		}
		
		public BindingDeclarationSyntax BindingDeclaration(NameSyntax name, BindingBodySyntax bindingBody)
		{
			return this.BindingDeclaration(this.Token(SoalSyntaxKind.KBinding), name, bindingBody);
		}
		
		public BindingBodySyntax BindingBody(SyntaxToken tOpenBrace, BindingLayersSyntax bindingLayers, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (BindingBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.BindingBody((InternalSyntaxToken)tOpenBrace.Node, bindingLayers == null ? null : (Syntax.InternalSyntax.BindingLayersGreen)bindingLayers.Green, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public BindingBodySyntax BindingBody()
		{
			return this.BindingBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public BindingLayersSyntax BindingLayers(TransportLayerSyntax transportLayer, SyntaxList<EncodingLayerSyntax> encodingLayer, SyntaxList<ProtocolLayerSyntax> protocolLayer)
		{
		    if (transportLayer == null) throw new ArgumentNullException(nameof(transportLayer));
		    if (encodingLayer == null) throw new ArgumentNullException(nameof(encodingLayer));
		    return (BindingLayersSyntax)SoalLanguage.Instance.InternalSyntaxFactory.BindingLayers((Syntax.InternalSyntax.TransportLayerGreen)transportLayer.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<EncodingLayerGreen>(encodingLayer.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ProtocolLayerGreen>(protocolLayer.Node)).CreateRed();
		}
		
		public BindingLayersSyntax BindingLayers(TransportLayerSyntax transportLayer, SyntaxList<EncodingLayerSyntax> encodingLayer)
		{
			return this.BindingLayers(transportLayer, encodingLayer, default);
		}
		
		public TransportLayerSyntax TransportLayer(HttpTransportLayerSyntax httpTransportLayer)
		{
		    if (httpTransportLayer == null) throw new ArgumentNullException(nameof(httpTransportLayer));
		    return (TransportLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.TransportLayer((Syntax.InternalSyntax.HttpTransportLayerGreen)httpTransportLayer.Green).CreateRed();
		}
		
		public TransportLayerSyntax TransportLayer(RestTransportLayerSyntax restTransportLayer)
		{
		    if (restTransportLayer == null) throw new ArgumentNullException(nameof(restTransportLayer));
		    return (TransportLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.TransportLayer((Syntax.InternalSyntax.RestTransportLayerGreen)restTransportLayer.Green).CreateRed();
		}
		
		public TransportLayerSyntax TransportLayer(WebSocketTransportLayerSyntax webSocketTransportLayer)
		{
		    if (webSocketTransportLayer == null) throw new ArgumentNullException(nameof(webSocketTransportLayer));
		    return (TransportLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.TransportLayer((Syntax.InternalSyntax.WebSocketTransportLayerGreen)webSocketTransportLayer.Green).CreateRed();
		}
		
		public HttpTransportLayerSyntax HttpTransportLayer(SyntaxToken kTransport, SyntaxToken ihttp, HttpTransportLayerBodySyntax httpTransportLayerBody)
		{
		    if (kTransport == null) throw new ArgumentNullException(nameof(kTransport));
		    if (kTransport.GetKind() != SoalSyntaxKind.KTransport) throw new ArgumentException(nameof(kTransport));
		    if (ihttp == null) throw new ArgumentNullException(nameof(ihttp));
		    if (ihttp.GetKind() != SoalSyntaxKind.IHTTP) throw new ArgumentException(nameof(ihttp));
		    if (httpTransportLayerBody == null) throw new ArgumentNullException(nameof(httpTransportLayerBody));
		    return (HttpTransportLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayer((InternalSyntaxToken)kTransport.Node, (InternalSyntaxToken)ihttp.Node, (Syntax.InternalSyntax.HttpTransportLayerBodyGreen)httpTransportLayerBody.Green).CreateRed();
		}
		
		public HttpTransportLayerSyntax HttpTransportLayer(HttpTransportLayerBodySyntax httpTransportLayerBody)
		{
			return this.HttpTransportLayer(this.Token(SoalSyntaxKind.KTransport), this.Token(SoalSyntaxKind.IHTTP), httpTransportLayerBody);
		}
		
		public HttpTransportLayerEmptyBodySyntax HttpTransportLayerEmptyBody(SyntaxToken tSemicolon)
		{
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (HttpTransportLayerEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerEmptyBody((InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public HttpTransportLayerEmptyBodySyntax HttpTransportLayerEmptyBody()
		{
			return this.HttpTransportLayerEmptyBody(this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public HttpTransportLayerNonEmptyBodySyntax HttpTransportLayerNonEmptyBody(SyntaxToken tOpenBrace, SyntaxList<HttpTransportLayerPropertiesSyntax> httpTransportLayerProperties, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (HttpTransportLayerNonEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerNonEmptyBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<HttpTransportLayerPropertiesGreen>(httpTransportLayerProperties.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public HttpTransportLayerNonEmptyBodySyntax HttpTransportLayerNonEmptyBody()
		{
			return this.HttpTransportLayerNonEmptyBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public RestTransportLayerSyntax RestTransportLayer(SyntaxToken kTransport, SyntaxToken irest, RestTransportLayerBodySyntax restTransportLayerBody)
		{
		    if (kTransport == null) throw new ArgumentNullException(nameof(kTransport));
		    if (kTransport.GetKind() != SoalSyntaxKind.KTransport) throw new ArgumentException(nameof(kTransport));
		    if (irest == null) throw new ArgumentNullException(nameof(irest));
		    if (irest.GetKind() != SoalSyntaxKind.IREST) throw new ArgumentException(nameof(irest));
		    if (restTransportLayerBody == null) throw new ArgumentNullException(nameof(restTransportLayerBody));
		    return (RestTransportLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.RestTransportLayer((InternalSyntaxToken)kTransport.Node, (InternalSyntaxToken)irest.Node, (Syntax.InternalSyntax.RestTransportLayerBodyGreen)restTransportLayerBody.Green).CreateRed();
		}
		
		public RestTransportLayerSyntax RestTransportLayer(RestTransportLayerBodySyntax restTransportLayerBody)
		{
			return this.RestTransportLayer(this.Token(SoalSyntaxKind.KTransport), this.Token(SoalSyntaxKind.IREST), restTransportLayerBody);
		}
		
		public RestTransportLayerEmptyBodySyntax RestTransportLayerEmptyBody(SyntaxToken tSemicolon)
		{
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (RestTransportLayerEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.RestTransportLayerEmptyBody((InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public RestTransportLayerEmptyBodySyntax RestTransportLayerEmptyBody()
		{
			return this.RestTransportLayerEmptyBody(this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public RestTransportLayerNonEmptyBodySyntax RestTransportLayerNonEmptyBody(SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (RestTransportLayerNonEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.RestTransportLayerNonEmptyBody((InternalSyntaxToken)tOpenBrace.Node, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public RestTransportLayerNonEmptyBodySyntax RestTransportLayerNonEmptyBody()
		{
			return this.RestTransportLayerNonEmptyBody(this.Token(SoalSyntaxKind.TOpenBrace), this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public WebSocketTransportLayerSyntax WebSocketTransportLayer(SyntaxToken kTransport, SyntaxToken iWebSocket, WebSocketTransportLayerBodySyntax webSocketTransportLayerBody)
		{
		    if (kTransport == null) throw new ArgumentNullException(nameof(kTransport));
		    if (kTransport.GetKind() != SoalSyntaxKind.KTransport) throw new ArgumentException(nameof(kTransport));
		    if (iWebSocket == null) throw new ArgumentNullException(nameof(iWebSocket));
		    if (iWebSocket.GetKind() != SoalSyntaxKind.IWebSocket) throw new ArgumentException(nameof(iWebSocket));
		    if (webSocketTransportLayerBody == null) throw new ArgumentNullException(nameof(webSocketTransportLayerBody));
		    return (WebSocketTransportLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.WebSocketTransportLayer((InternalSyntaxToken)kTransport.Node, (InternalSyntaxToken)iWebSocket.Node, (Syntax.InternalSyntax.WebSocketTransportLayerBodyGreen)webSocketTransportLayerBody.Green).CreateRed();
		}
		
		public WebSocketTransportLayerSyntax WebSocketTransportLayer(WebSocketTransportLayerBodySyntax webSocketTransportLayerBody)
		{
			return this.WebSocketTransportLayer(this.Token(SoalSyntaxKind.KTransport), this.Token(SoalSyntaxKind.IWebSocket), webSocketTransportLayerBody);
		}
		
		public WebSocketTransportLayerEmptyBodySyntax WebSocketTransportLayerEmptyBody(SyntaxToken tSemicolon)
		{
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (WebSocketTransportLayerEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.WebSocketTransportLayerEmptyBody((InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public WebSocketTransportLayerEmptyBodySyntax WebSocketTransportLayerEmptyBody()
		{
			return this.WebSocketTransportLayerEmptyBody(this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public WebSocketTransportLayerNonEmptyBodySyntax WebSocketTransportLayerNonEmptyBody(SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (WebSocketTransportLayerNonEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.WebSocketTransportLayerNonEmptyBody((InternalSyntaxToken)tOpenBrace.Node, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public WebSocketTransportLayerNonEmptyBodySyntax WebSocketTransportLayerNonEmptyBody()
		{
			return this.WebSocketTransportLayerNonEmptyBody(this.Token(SoalSyntaxKind.TOpenBrace), this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public HttpTransportLayerPropertiesSyntax HttpTransportLayerProperties(HttpSslPropertySyntax httpSslProperty)
		{
		    if (httpSslProperty == null) throw new ArgumentNullException(nameof(httpSslProperty));
		    return (HttpTransportLayerPropertiesSyntax)SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerProperties((Syntax.InternalSyntax.HttpSslPropertyGreen)httpSslProperty.Green).CreateRed();
		}
		
		public HttpTransportLayerPropertiesSyntax HttpTransportLayerProperties(HttpClientAuthenticationPropertySyntax httpClientAuthenticationProperty)
		{
		    if (httpClientAuthenticationProperty == null) throw new ArgumentNullException(nameof(httpClientAuthenticationProperty));
		    return (HttpTransportLayerPropertiesSyntax)SoalLanguage.Instance.InternalSyntaxFactory.HttpTransportLayerProperties((Syntax.InternalSyntax.HttpClientAuthenticationPropertyGreen)httpClientAuthenticationProperty.Green).CreateRed();
		}
		
		public HttpSslPropertySyntax HttpSslProperty(SyntaxToken issl, SyntaxToken tAssign, BooleanLiteralSyntax booleanLiteral, SyntaxToken tSemicolon)
		{
		    if (issl == null) throw new ArgumentNullException(nameof(issl));
		    if (issl.GetKind() != SoalSyntaxKind.ISSL) throw new ArgumentException(nameof(issl));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (HttpSslPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.HttpSslProperty((InternalSyntaxToken)issl.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public HttpSslPropertySyntax HttpSslProperty(BooleanLiteralSyntax booleanLiteral)
		{
			return this.HttpSslProperty(this.Token(SoalSyntaxKind.ISSL), this.Token(SoalSyntaxKind.TAssign), booleanLiteral, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public HttpClientAuthenticationPropertySyntax HttpClientAuthenticationProperty(SyntaxToken iClientAuthentication, SyntaxToken tAssign, BooleanLiteralSyntax booleanLiteral, SyntaxToken tSemicolon)
		{
		    if (iClientAuthentication == null) throw new ArgumentNullException(nameof(iClientAuthentication));
		    if (iClientAuthentication.GetKind() != SoalSyntaxKind.IClientAuthentication) throw new ArgumentException(nameof(iClientAuthentication));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (HttpClientAuthenticationPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.HttpClientAuthenticationProperty((InternalSyntaxToken)iClientAuthentication.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public HttpClientAuthenticationPropertySyntax HttpClientAuthenticationProperty(BooleanLiteralSyntax booleanLiteral)
		{
			return this.HttpClientAuthenticationProperty(this.Token(SoalSyntaxKind.IClientAuthentication), this.Token(SoalSyntaxKind.TAssign), booleanLiteral, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public EncodingLayerSyntax EncodingLayer(SoapEncodingLayerSyntax soapEncodingLayer)
		{
		    if (soapEncodingLayer == null) throw new ArgumentNullException(nameof(soapEncodingLayer));
		    return (EncodingLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EncodingLayer((Syntax.InternalSyntax.SoapEncodingLayerGreen)soapEncodingLayer.Green).CreateRed();
		}
		
		public EncodingLayerSyntax EncodingLayer(XmlEncodingLayerSyntax xmlEncodingLayer)
		{
		    if (xmlEncodingLayer == null) throw new ArgumentNullException(nameof(xmlEncodingLayer));
		    return (EncodingLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EncodingLayer((Syntax.InternalSyntax.XmlEncodingLayerGreen)xmlEncodingLayer.Green).CreateRed();
		}
		
		public EncodingLayerSyntax EncodingLayer(JsonEncodingLayerSyntax jsonEncodingLayer)
		{
		    if (jsonEncodingLayer == null) throw new ArgumentNullException(nameof(jsonEncodingLayer));
		    return (EncodingLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EncodingLayer((Syntax.InternalSyntax.JsonEncodingLayerGreen)jsonEncodingLayer.Green).CreateRed();
		}
		
		public SoapEncodingLayerSyntax SoapEncodingLayer(SyntaxToken kEncoding, SyntaxToken isoap, SoapEncodingLayerBodySyntax soapEncodingLayerBody)
		{
		    if (kEncoding == null) throw new ArgumentNullException(nameof(kEncoding));
		    if (kEncoding.GetKind() != SoalSyntaxKind.KEncoding) throw new ArgumentException(nameof(kEncoding));
		    if (isoap == null) throw new ArgumentNullException(nameof(isoap));
		    if (isoap.GetKind() != SoalSyntaxKind.ISOAP) throw new ArgumentException(nameof(isoap));
		    if (soapEncodingLayerBody == null) throw new ArgumentNullException(nameof(soapEncodingLayerBody));
		    return (SoapEncodingLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingLayer((InternalSyntaxToken)kEncoding.Node, (InternalSyntaxToken)isoap.Node, (Syntax.InternalSyntax.SoapEncodingLayerBodyGreen)soapEncodingLayerBody.Green).CreateRed();
		}
		
		public SoapEncodingLayerSyntax SoapEncodingLayer(SoapEncodingLayerBodySyntax soapEncodingLayerBody)
		{
			return this.SoapEncodingLayer(this.Token(SoalSyntaxKind.KEncoding), this.Token(SoalSyntaxKind.ISOAP), soapEncodingLayerBody);
		}
		
		public SoapEncodingLayerEmptyBodySyntax SoapEncodingLayerEmptyBody(SyntaxToken tSemicolon)
		{
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (SoapEncodingLayerEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingLayerEmptyBody((InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public SoapEncodingLayerEmptyBodySyntax SoapEncodingLayerEmptyBody()
		{
			return this.SoapEncodingLayerEmptyBody(this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public SoapEncodingLayerNonEmptyBodySyntax SoapEncodingLayerNonEmptyBody(SyntaxToken tOpenBrace, SyntaxList<SoapEncodingPropertiesSyntax> soapEncodingProperties, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (SoapEncodingLayerNonEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingLayerNonEmptyBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<SoapEncodingPropertiesGreen>(soapEncodingProperties.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public SoapEncodingLayerNonEmptyBodySyntax SoapEncodingLayerNonEmptyBody()
		{
			return this.SoapEncodingLayerNonEmptyBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public XmlEncodingLayerSyntax XmlEncodingLayer(SyntaxToken kEncoding, SyntaxToken ixml, XmlEncodingLayerBodySyntax xmlEncodingLayerBody)
		{
		    if (kEncoding == null) throw new ArgumentNullException(nameof(kEncoding));
		    if (kEncoding.GetKind() != SoalSyntaxKind.KEncoding) throw new ArgumentException(nameof(kEncoding));
		    if (ixml == null) throw new ArgumentNullException(nameof(ixml));
		    if (ixml.GetKind() != SoalSyntaxKind.IXML) throw new ArgumentException(nameof(ixml));
		    if (xmlEncodingLayerBody == null) throw new ArgumentNullException(nameof(xmlEncodingLayerBody));
		    return (XmlEncodingLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.XmlEncodingLayer((InternalSyntaxToken)kEncoding.Node, (InternalSyntaxToken)ixml.Node, (Syntax.InternalSyntax.XmlEncodingLayerBodyGreen)xmlEncodingLayerBody.Green).CreateRed();
		}
		
		public XmlEncodingLayerSyntax XmlEncodingLayer(XmlEncodingLayerBodySyntax xmlEncodingLayerBody)
		{
			return this.XmlEncodingLayer(this.Token(SoalSyntaxKind.KEncoding), this.Token(SoalSyntaxKind.IXML), xmlEncodingLayerBody);
		}
		
		public XmlEncodingLayerEmptyBodySyntax XmlEncodingLayerEmptyBody(SyntaxToken tSemicolon)
		{
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (XmlEncodingLayerEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.XmlEncodingLayerEmptyBody((InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public XmlEncodingLayerEmptyBodySyntax XmlEncodingLayerEmptyBody()
		{
			return this.XmlEncodingLayerEmptyBody(this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public XmlEncodingLayerNonEmptyBodySyntax XmlEncodingLayerNonEmptyBody(SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (XmlEncodingLayerNonEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.XmlEncodingLayerNonEmptyBody((InternalSyntaxToken)tOpenBrace.Node, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public XmlEncodingLayerNonEmptyBodySyntax XmlEncodingLayerNonEmptyBody()
		{
			return this.XmlEncodingLayerNonEmptyBody(this.Token(SoalSyntaxKind.TOpenBrace), this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public JsonEncodingLayerSyntax JsonEncodingLayer(SyntaxToken kEncoding, SyntaxToken ijson, JsonEncodingLayerBodySyntax jsonEncodingLayerBody)
		{
		    if (kEncoding == null) throw new ArgumentNullException(nameof(kEncoding));
		    if (kEncoding.GetKind() != SoalSyntaxKind.KEncoding) throw new ArgumentException(nameof(kEncoding));
		    if (ijson == null) throw new ArgumentNullException(nameof(ijson));
		    if (ijson.GetKind() != SoalSyntaxKind.IJSON) throw new ArgumentException(nameof(ijson));
		    if (jsonEncodingLayerBody == null) throw new ArgumentNullException(nameof(jsonEncodingLayerBody));
		    return (JsonEncodingLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.JsonEncodingLayer((InternalSyntaxToken)kEncoding.Node, (InternalSyntaxToken)ijson.Node, (Syntax.InternalSyntax.JsonEncodingLayerBodyGreen)jsonEncodingLayerBody.Green).CreateRed();
		}
		
		public JsonEncodingLayerSyntax JsonEncodingLayer(JsonEncodingLayerBodySyntax jsonEncodingLayerBody)
		{
			return this.JsonEncodingLayer(this.Token(SoalSyntaxKind.KEncoding), this.Token(SoalSyntaxKind.IJSON), jsonEncodingLayerBody);
		}
		
		public JsonEncodingLayerEmptyBodySyntax JsonEncodingLayerEmptyBody(SyntaxToken tSemicolon)
		{
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (JsonEncodingLayerEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.JsonEncodingLayerEmptyBody((InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public JsonEncodingLayerEmptyBodySyntax JsonEncodingLayerEmptyBody()
		{
			return this.JsonEncodingLayerEmptyBody(this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public JsonEncodingLayerNonEmptyBodySyntax JsonEncodingLayerNonEmptyBody(SyntaxToken tOpenBrace, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (JsonEncodingLayerNonEmptyBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.JsonEncodingLayerNonEmptyBody((InternalSyntaxToken)tOpenBrace.Node, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public JsonEncodingLayerNonEmptyBodySyntax JsonEncodingLayerNonEmptyBody()
		{
			return this.JsonEncodingLayerNonEmptyBody(this.Token(SoalSyntaxKind.TOpenBrace), this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public SoapEncodingPropertiesSyntax SoapEncodingProperties(SoapVersionPropertySyntax soapVersionProperty)
		{
		    if (soapVersionProperty == null) throw new ArgumentNullException(nameof(soapVersionProperty));
		    return (SoapEncodingPropertiesSyntax)SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingProperties((Syntax.InternalSyntax.SoapVersionPropertyGreen)soapVersionProperty.Green).CreateRed();
		}
		
		public SoapEncodingPropertiesSyntax SoapEncodingProperties(SoapMtomPropertySyntax soapMtomProperty)
		{
		    if (soapMtomProperty == null) throw new ArgumentNullException(nameof(soapMtomProperty));
		    return (SoapEncodingPropertiesSyntax)SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingProperties((Syntax.InternalSyntax.SoapMtomPropertyGreen)soapMtomProperty.Green).CreateRed();
		}
		
		public SoapEncodingPropertiesSyntax SoapEncodingProperties(SoapStylePropertySyntax soapStyleProperty)
		{
		    if (soapStyleProperty == null) throw new ArgumentNullException(nameof(soapStyleProperty));
		    return (SoapEncodingPropertiesSyntax)SoalLanguage.Instance.InternalSyntaxFactory.SoapEncodingProperties((Syntax.InternalSyntax.SoapStylePropertyGreen)soapStyleProperty.Green).CreateRed();
		}
		
		public SoapVersionPropertySyntax SoapVersionProperty(SyntaxToken iVersion, SyntaxToken tAssign, IdentifierSyntax identifier, SyntaxToken tSemicolon)
		{
		    if (iVersion == null) throw new ArgumentNullException(nameof(iVersion));
		    if (iVersion.GetKind() != SoalSyntaxKind.IVersion) throw new ArgumentException(nameof(iVersion));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (SoapVersionPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.SoapVersionProperty((InternalSyntaxToken)iVersion.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public SoapVersionPropertySyntax SoapVersionProperty(IdentifierSyntax identifier)
		{
			return this.SoapVersionProperty(this.Token(SoalSyntaxKind.IVersion), this.Token(SoalSyntaxKind.TAssign), identifier, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public SoapMtomPropertySyntax SoapMtomProperty(SyntaxToken imtom, SyntaxToken tAssign, BooleanLiteralSyntax booleanLiteral, SyntaxToken tSemicolon)
		{
		    if (imtom == null) throw new ArgumentNullException(nameof(imtom));
		    if (imtom.GetKind() != SoalSyntaxKind.IMTOM) throw new ArgumentException(nameof(imtom));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (SoapMtomPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.SoapMtomProperty((InternalSyntaxToken)imtom.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public SoapMtomPropertySyntax SoapMtomProperty(BooleanLiteralSyntax booleanLiteral)
		{
			return this.SoapMtomProperty(this.Token(SoalSyntaxKind.IMTOM), this.Token(SoalSyntaxKind.TAssign), booleanLiteral, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public SoapStylePropertySyntax SoapStyleProperty(SyntaxToken iStyle, SyntaxToken tAssign, IdentifierSyntax identifier, SyntaxToken tSemicolon)
		{
		    if (iStyle == null) throw new ArgumentNullException(nameof(iStyle));
		    if (iStyle.GetKind() != SoalSyntaxKind.IStyle) throw new ArgumentException(nameof(iStyle));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != SoalSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (SoapStylePropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.SoapStyleProperty((InternalSyntaxToken)iStyle.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public SoapStylePropertySyntax SoapStyleProperty(IdentifierSyntax identifier)
		{
			return this.SoapStyleProperty(this.Token(SoalSyntaxKind.IStyle), this.Token(SoalSyntaxKind.TAssign), identifier, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public ProtocolLayerSyntax ProtocolLayer(SyntaxToken kProtocol, ProtocolLayerKindSyntax protocolLayerKind, SyntaxToken tSemicolon)
		{
		    if (kProtocol == null) throw new ArgumentNullException(nameof(kProtocol));
		    if (kProtocol.GetKind() != SoalSyntaxKind.KProtocol) throw new ArgumentException(nameof(kProtocol));
		    if (protocolLayerKind == null) throw new ArgumentNullException(nameof(protocolLayerKind));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ProtocolLayerSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ProtocolLayer((InternalSyntaxToken)kProtocol.Node, (Syntax.InternalSyntax.ProtocolLayerKindGreen)protocolLayerKind.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ProtocolLayerSyntax ProtocolLayer(ProtocolLayerKindSyntax protocolLayerKind)
		{
			return this.ProtocolLayer(this.Token(SoalSyntaxKind.KProtocol), protocolLayerKind, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public ProtocolLayerKindSyntax ProtocolLayerKind(WsAddressingSyntax wsAddressing)
		{
		    if (wsAddressing == null) throw new ArgumentNullException(nameof(wsAddressing));
		    return (ProtocolLayerKindSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ProtocolLayerKind((Syntax.InternalSyntax.WsAddressingGreen)wsAddressing.Green).CreateRed();
		}
		
		public WsAddressingSyntax WsAddressing(SyntaxToken iWsAddressing)
		{
		    if (iWsAddressing == null) throw new ArgumentNullException(nameof(iWsAddressing));
		    if (iWsAddressing.GetKind() != SoalSyntaxKind.IWsAddressing) throw new ArgumentException(nameof(iWsAddressing));
		    return (WsAddressingSyntax)SoalLanguage.Instance.InternalSyntaxFactory.WsAddressing((InternalSyntaxToken)iWsAddressing.Node).CreateRed();
		}
		
		public WsAddressingSyntax WsAddressing()
		{
			return this.WsAddressing(this.Token(SoalSyntaxKind.IWsAddressing));
		}
		
		public EndpointDeclarationSyntax EndpointDeclaration(SyntaxToken kEndpoint, NameSyntax name, SyntaxToken tColon, QualifierSyntax qualifier, EndpointBodySyntax endpointBody)
		{
		    if (kEndpoint == null) throw new ArgumentNullException(nameof(kEndpoint));
		    if (kEndpoint.GetKind() != SoalSyntaxKind.KEndpoint) throw new ArgumentException(nameof(kEndpoint));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != SoalSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (endpointBody == null) throw new ArgumentNullException(nameof(endpointBody));
		    return (EndpointDeclarationSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EndpointDeclaration((InternalSyntaxToken)kEndpoint.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (Syntax.InternalSyntax.EndpointBodyGreen)endpointBody.Green).CreateRed();
		}
		
		public EndpointDeclarationSyntax EndpointDeclaration(NameSyntax name, QualifierSyntax qualifier, EndpointBodySyntax endpointBody)
		{
			return this.EndpointDeclaration(this.Token(SoalSyntaxKind.KEndpoint), name, this.Token(SoalSyntaxKind.TColon), qualifier, endpointBody);
		}
		
		public EndpointBodySyntax EndpointBody(SyntaxToken tOpenBrace, EndpointPropertiesSyntax endpointProperties, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != SoalSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != SoalSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (EndpointBodySyntax)SoalLanguage.Instance.InternalSyntaxFactory.EndpointBody((InternalSyntaxToken)tOpenBrace.Node, endpointProperties == null ? null : (Syntax.InternalSyntax.EndpointPropertiesGreen)endpointProperties.Green, (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public EndpointBodySyntax EndpointBody()
		{
			return this.EndpointBody(this.Token(SoalSyntaxKind.TOpenBrace), default, this.Token(SoalSyntaxKind.TCloseBrace));
		}
		
		public EndpointPropertiesSyntax EndpointProperties(SyntaxList<EndpointPropertySyntax> endpointProperty)
		{
		    if (endpointProperty == null) throw new ArgumentNullException(nameof(endpointProperty));
		    return (EndpointPropertiesSyntax)SoalLanguage.Instance.InternalSyntaxFactory.EndpointProperties(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<EndpointPropertyGreen>(endpointProperty.Node)).CreateRed();
		}
		
		public EndpointPropertySyntax EndpointProperty(EndpointBindingPropertySyntax endpointBindingProperty)
		{
		    if (endpointBindingProperty == null) throw new ArgumentNullException(nameof(endpointBindingProperty));
		    return (EndpointPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.EndpointProperty((Syntax.InternalSyntax.EndpointBindingPropertyGreen)endpointBindingProperty.Green).CreateRed();
		}
		
		public EndpointPropertySyntax EndpointProperty(EndpointAddressPropertySyntax endpointAddressProperty)
		{
		    if (endpointAddressProperty == null) throw new ArgumentNullException(nameof(endpointAddressProperty));
		    return (EndpointPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.EndpointProperty((Syntax.InternalSyntax.EndpointAddressPropertyGreen)endpointAddressProperty.Green).CreateRed();
		}
		
		public EndpointBindingPropertySyntax EndpointBindingProperty(SyntaxToken kBinding, QualifierSyntax qualifier, SyntaxToken tSemicolon)
		{
		    if (kBinding == null) throw new ArgumentNullException(nameof(kBinding));
		    if (kBinding.GetKind() != SoalSyntaxKind.KBinding) throw new ArgumentException(nameof(kBinding));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (EndpointBindingPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.EndpointBindingProperty((InternalSyntaxToken)kBinding.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public EndpointBindingPropertySyntax EndpointBindingProperty(QualifierSyntax qualifier)
		{
			return this.EndpointBindingProperty(this.Token(SoalSyntaxKind.KBinding), qualifier, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public EndpointAddressPropertySyntax EndpointAddressProperty(SyntaxToken kAddress, StringLiteralSyntax stringLiteral, SyntaxToken tSemicolon)
		{
		    if (kAddress == null) throw new ArgumentNullException(nameof(kAddress));
		    if (kAddress.GetKind() != SoalSyntaxKind.KAddress) throw new ArgumentException(nameof(kAddress));
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != SoalSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (EndpointAddressPropertySyntax)SoalLanguage.Instance.InternalSyntaxFactory.EndpointAddressProperty((InternalSyntaxToken)kAddress.Node, (Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public EndpointAddressPropertySyntax EndpointAddressProperty(StringLiteralSyntax stringLiteral)
		{
			return this.EndpointAddressProperty(this.Token(SoalSyntaxKind.KAddress), stringLiteral, this.Token(SoalSyntaxKind.TSemicolon));
		}
		
		public ReturnTypeSyntax ReturnType(VoidTypeSyntax voidType)
		{
		    if (voidType == null) throw new ArgumentNullException(nameof(voidType));
		    return (ReturnTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.VoidTypeGreen)voidType.Green).CreateRed();
		}
		
		public ReturnTypeSyntax ReturnType(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (ReturnTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(NonNullableArrayTypeSyntax nonNullableArrayType)
		{
		    if (nonNullableArrayType == null) throw new ArgumentNullException(nameof(nonNullableArrayType));
		    return (TypeReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.NonNullableArrayTypeGreen)nonNullableArrayType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(ArrayTypeSyntax arrayType)
		{
		    if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
		    return (TypeReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.ArrayTypeGreen)arrayType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(SimpleTypeSyntax simpleType)
		{
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    return (TypeReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(NulledTypeSyntax nulledType)
		{
		    if (nulledType == null) throw new ArgumentNullException(nameof(nulledType));
		    return (TypeReferenceSyntax)SoalLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.NulledTypeGreen)nulledType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(ValueTypeSyntax valueType)
		{
		    if (valueType == null) throw new ArgumentNullException(nameof(valueType));
		    return (SimpleTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.ValueTypeGreen)valueType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(ObjectTypeSyntax objectType)
		{
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
		    return (SimpleTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.ObjectTypeGreen)objectType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (SimpleTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public NulledTypeSyntax NulledType(NullableTypeSyntax nullableType)
		{
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
		    return (NulledTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NulledType((Syntax.InternalSyntax.NullableTypeGreen)nullableType.Green).CreateRed();
		}
		
		public NulledTypeSyntax NulledType(NonNullableTypeSyntax nonNullableType)
		{
		    if (nonNullableType == null) throw new ArgumentNullException(nameof(nonNullableType));
		    return (NulledTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NulledType((Syntax.InternalSyntax.NonNullableTypeGreen)nonNullableType.Green).CreateRed();
		}
		
		public ReferenceTypeSyntax ReferenceType(ObjectTypeSyntax objectType)
		{
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
		    return (ReferenceTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ReferenceType((Syntax.InternalSyntax.ObjectTypeGreen)objectType.Green).CreateRed();
		}
		
		public ReferenceTypeSyntax ReferenceType(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (ReferenceTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ReferenceType((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ObjectTypeSyntax ObjectType(SyntaxToken objectType)
		{
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
		    return (ObjectTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ObjectType((InternalSyntaxToken)objectType.Node).CreateRed();
		}
		
		public ValueTypeSyntax ValueType(SyntaxToken valueType)
		{
		    if (valueType == null) throw new ArgumentNullException(nameof(valueType));
		    return (ValueTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ValueType((InternalSyntaxToken)valueType.Node).CreateRed();
		}
		
		public VoidTypeSyntax VoidType(SyntaxToken kVoid)
		{
		    if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
		    if (kVoid.GetKind() != SoalSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
		    return (VoidTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.VoidType((InternalSyntaxToken)kVoid.Node).CreateRed();
		}
		
		public VoidTypeSyntax VoidType()
		{
			return this.VoidType(this.Token(SoalSyntaxKind.KVoid));
		}
		
		public OnewayTypeSyntax OnewayType(SyntaxToken kOneway)
		{
		    if (kOneway == null) throw new ArgumentNullException(nameof(kOneway));
		    if (kOneway.GetKind() != SoalSyntaxKind.KOneway) throw new ArgumentException(nameof(kOneway));
		    return (OnewayTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.OnewayType((InternalSyntaxToken)kOneway.Node).CreateRed();
		}
		
		public OnewayTypeSyntax OnewayType()
		{
			return this.OnewayType(this.Token(SoalSyntaxKind.KOneway));
		}
		
		public OperationReturnTypeSyntax OperationReturnType(OnewayTypeSyntax onewayType)
		{
		    if (onewayType == null) throw new ArgumentNullException(nameof(onewayType));
		    return (OperationReturnTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.OperationReturnType((Syntax.InternalSyntax.OnewayTypeGreen)onewayType.Green).CreateRed();
		}
		
		public OperationReturnTypeSyntax OperationReturnType(VoidTypeSyntax voidType)
		{
		    if (voidType == null) throw new ArgumentNullException(nameof(voidType));
		    return (OperationReturnTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.OperationReturnType((Syntax.InternalSyntax.VoidTypeGreen)voidType.Green).CreateRed();
		}
		
		public OperationReturnTypeSyntax OperationReturnType(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (OperationReturnTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.OperationReturnType((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public NullableTypeSyntax NullableType(ValueTypeSyntax valueType, SyntaxToken tQuestion)
		{
		    if (valueType == null) throw new ArgumentNullException(nameof(valueType));
		    if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
		    if (tQuestion.GetKind() != SoalSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
		    return (NullableTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NullableType((Syntax.InternalSyntax.ValueTypeGreen)valueType.Green, (InternalSyntaxToken)tQuestion.Node).CreateRed();
		}
		
		public NullableTypeSyntax NullableType(ValueTypeSyntax valueType)
		{
			return this.NullableType(valueType, this.Token(SoalSyntaxKind.TQuestion));
		}
		
		public NonNullableTypeSyntax NonNullableType(ReferenceTypeSyntax referenceType, SyntaxToken tExclamation)
		{
		    if (referenceType == null) throw new ArgumentNullException(nameof(referenceType));
		    if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
		    if (tExclamation.GetKind() != SoalSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
		    return (NonNullableTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NonNullableType((Syntax.InternalSyntax.ReferenceTypeGreen)referenceType.Green, (InternalSyntaxToken)tExclamation.Node).CreateRed();
		}
		
		public NonNullableTypeSyntax NonNullableType(ReferenceTypeSyntax referenceType)
		{
			return this.NonNullableType(referenceType, this.Token(SoalSyntaxKind.TExclamation));
		}
		
		public NonNullableArrayTypeSyntax NonNullableArrayType(ArrayTypeSyntax arrayType, SyntaxToken tExclamation)
		{
		    if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
		    if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
		    if (tExclamation.GetKind() != SoalSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
		    return (NonNullableArrayTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NonNullableArrayType((Syntax.InternalSyntax.ArrayTypeGreen)arrayType.Green, (InternalSyntaxToken)tExclamation.Node).CreateRed();
		}
		
		public NonNullableArrayTypeSyntax NonNullableArrayType(ArrayTypeSyntax arrayType)
		{
			return this.NonNullableArrayType(arrayType, this.Token(SoalSyntaxKind.TExclamation));
		}
		
		public ArrayTypeSyntax ArrayType(SimpleArrayTypeSyntax simpleArrayType)
		{
		    if (simpleArrayType == null) throw new ArgumentNullException(nameof(simpleArrayType));
		    return (ArrayTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ArrayType((Syntax.InternalSyntax.SimpleArrayTypeGreen)simpleArrayType.Green).CreateRed();
		}
		
		public ArrayTypeSyntax ArrayType(NulledArrayTypeSyntax nulledArrayType)
		{
		    if (nulledArrayType == null) throw new ArgumentNullException(nameof(nulledArrayType));
		    return (ArrayTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ArrayType((Syntax.InternalSyntax.NulledArrayTypeGreen)nulledArrayType.Green).CreateRed();
		}
		
		public SimpleArrayTypeSyntax SimpleArrayType(SimpleTypeSyntax simpleType, SyntaxToken tOpenBracket, SyntaxToken tCloseBracket)
		{
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (SimpleArrayTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.SimpleArrayType((Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green, (InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public SimpleArrayTypeSyntax SimpleArrayType(SimpleTypeSyntax simpleType)
		{
			return this.SimpleArrayType(simpleType, this.Token(SoalSyntaxKind.TOpenBracket), this.Token(SoalSyntaxKind.TCloseBracket));
		}
		
		public NulledArrayTypeSyntax NulledArrayType(NulledTypeSyntax nulledType, SyntaxToken tOpenBracket, SyntaxToken tCloseBracket)
		{
		    if (nulledType == null) throw new ArgumentNullException(nameof(nulledType));
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != SoalSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != SoalSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (NulledArrayTypeSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NulledArrayType((Syntax.InternalSyntax.NulledTypeGreen)nulledType.Green, (InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public NulledArrayTypeSyntax NulledArrayType(NulledTypeSyntax nulledType)
		{
			return this.NulledArrayType(nulledType, this.Token(SoalSyntaxKind.TOpenBracket), this.Token(SoalSyntaxKind.TCloseBracket));
		}
		
		public ConstantValueSyntax ConstantValue(LiteralSyntax literal)
		{
		    if (literal == null) throw new ArgumentNullException(nameof(literal));
		    return (ConstantValueSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ConstantValue((Syntax.InternalSyntax.LiteralGreen)literal.Green).CreateRed();
		}
		
		public ConstantValueSyntax ConstantValue(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (ConstantValueSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ConstantValue((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public TypeofValueSyntax TypeofValue(SyntaxToken kTypeof, SyntaxToken tOpenParen, ReturnTypeSyntax returnType, SyntaxToken tCloseParen)
		{
		    if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
		    if (kTypeof.GetKind() != SoalSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != SoalSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (returnType == null) throw new ArgumentNullException(nameof(returnType));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != SoalSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (TypeofValueSyntax)SoalLanguage.Instance.InternalSyntaxFactory.TypeofValue((InternalSyntaxToken)kTypeof.Node, (InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.ReturnTypeGreen)returnType.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public TypeofValueSyntax TypeofValue(ReturnTypeSyntax returnType)
		{
			return this.TypeofValue(this.Token(SoalSyntaxKind.KTypeof), this.Token(SoalSyntaxKind.TOpenParen), returnType, this.Token(SoalSyntaxKind.TCloseParen));
		}
		
		public IdentifierSyntax Identifier(IdentifiersSyntax identifiers)
		{
		    if (identifiers == null) throw new ArgumentNullException(nameof(identifiers));
		    return (IdentifierSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Identifier((Syntax.InternalSyntax.IdentifiersGreen)identifiers.Green).CreateRed();
		}
		
		public IdentifierSyntax Identifier(ContextualKeywordsSyntax contextualKeywords)
		{
		    if (contextualKeywords == null) throw new ArgumentNullException(nameof(contextualKeywords));
		    return (IdentifierSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Identifier((Syntax.InternalSyntax.ContextualKeywordsGreen)contextualKeywords.Green).CreateRed();
		}
		
		public IdentifiersSyntax Identifiers(SyntaxToken identifiers)
		{
		    if (identifiers == null) throw new ArgumentNullException(nameof(identifiers));
		    return (IdentifiersSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Identifiers((InternalSyntaxToken)identifiers.Node).CreateRed();
		}
		
		public LiteralSyntax Literal(NullLiteralSyntax nullLiteral)
		{
		    if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
		    return (LiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.NullLiteralGreen)nullLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(BooleanLiteralSyntax booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (LiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(IntegerLiteralSyntax integerLiteral)
		{
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    return (LiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.IntegerLiteralGreen)integerLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(DecimalLiteralSyntax decimalLiteral)
		{
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
		    return (LiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.DecimalLiteralGreen)decimalLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(ScientificLiteralSyntax scientificLiteral)
		{
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
		    return (LiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.ScientificLiteralGreen)scientificLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (LiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral(SyntaxToken kNull)
		{
		    if (kNull == null) throw new ArgumentNullException(nameof(kNull));
		    if (kNull.GetKind() != SoalSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
		    return (NullLiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.NullLiteral((InternalSyntaxToken)kNull.Node).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral()
		{
			return this.NullLiteral(this.Token(SoalSyntaxKind.KNull));
		}
		
		public BooleanLiteralSyntax BooleanLiteral(SyntaxToken booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (BooleanLiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.BooleanLiteral((InternalSyntaxToken)booleanLiteral.Node).CreateRed();
		}
		
		public IntegerLiteralSyntax IntegerLiteral(SyntaxToken lInteger)
		{
		    if (lInteger == null) throw new ArgumentNullException(nameof(lInteger));
		    if (lInteger.GetKind() != SoalSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
		    return (IntegerLiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.IntegerLiteral((InternalSyntaxToken)lInteger.Node).CreateRed();
		}
		
		public DecimalLiteralSyntax DecimalLiteral(SyntaxToken lDecimal)
		{
		    if (lDecimal == null) throw new ArgumentNullException(nameof(lDecimal));
		    if (lDecimal.GetKind() != SoalSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
		    return (DecimalLiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.DecimalLiteral((InternalSyntaxToken)lDecimal.Node).CreateRed();
		}
		
		public ScientificLiteralSyntax ScientificLiteral(SyntaxToken lScientific)
		{
		    if (lScientific == null) throw new ArgumentNullException(nameof(lScientific));
		    if (lScientific.GetKind() != SoalSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
		    return (ScientificLiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ScientificLiteral((InternalSyntaxToken)lScientific.Node).CreateRed();
		}
		
		public StringLiteralSyntax StringLiteral(SyntaxToken stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (StringLiteralSyntax)SoalLanguage.Instance.InternalSyntaxFactory.StringLiteral((InternalSyntaxToken)stringLiteral.Node).CreateRed();
		}
		
		public ContextualKeywordsSyntax ContextualKeywords(SyntaxToken contextualKeywords)
		{
		    if (contextualKeywords == null) throw new ArgumentNullException(nameof(contextualKeywords));
		    return (ContextualKeywordsSyntax)SoalLanguage.Instance.InternalSyntaxFactory.ContextualKeywords((InternalSyntaxToken)contextualKeywords.Node).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(NameSyntax),
				typeof(QualifiedNameSyntax),
				typeof(QualifierSyntax),
				typeof(IdentifierListSyntax),
				typeof(QualifierListSyntax),
				typeof(AnnotationListSyntax),
				typeof(ReturnAnnotationListSyntax),
				typeof(AnnotationSyntax),
				typeof(ReturnAnnotationSyntax),
				typeof(AnnotationHeadSyntax),
				typeof(AnnotationBodySyntax),
				typeof(AnnotationPropertyListSyntax),
				typeof(AnnotationPropertySyntax),
				typeof(AnnotationPropertyValueSyntax),
				typeof(NamespaceDeclarationSyntax),
				typeof(NamespacePrefixSyntax),
				typeof(NamespaceUriSyntax),
				typeof(NamespaceBodySyntax),
				typeof(DeclarationSyntax),
				typeof(EnumDeclarationSyntax),
				typeof(EnumBaseSyntax),
				typeof(EnumBodySyntax),
				typeof(EnumLiteralsSyntax),
				typeof(EnumLiteralSyntax),
				typeof(StructDeclarationSyntax),
				typeof(StructBodySyntax),
				typeof(PropertyDeclarationSyntax),
				typeof(DatabaseDeclarationSyntax),
				typeof(DatabaseBodySyntax),
				typeof(EntityReferenceSyntax),
				typeof(InterfaceDeclarationSyntax),
				typeof(InterfaceBodySyntax),
				typeof(OperationDeclarationSyntax),
				typeof(OperationHeadSyntax),
				typeof(ParameterListSyntax),
				typeof(ParameterSyntax),
				typeof(OperationResultSyntax),
				typeof(ThrowsListSyntax),
				typeof(ComponentDeclarationSyntax),
				typeof(ComponentBaseSyntax),
				typeof(ComponentBodySyntax),
				typeof(ComponentElementsSyntax),
				typeof(ComponentElementSyntax),
				typeof(ComponentServiceSyntax),
				typeof(ComponentReferenceSyntax),
				typeof(ComponentServiceOrReferenceEmptyBodySyntax),
				typeof(ComponentServiceOrReferenceNonEmptyBodySyntax),
				typeof(ComponentServiceOrReferenceElementSyntax),
				typeof(ComponentPropertySyntax),
				typeof(ComponentImplementationSyntax),
				typeof(ComponentLanguageSyntax),
				typeof(CompositeDeclarationSyntax),
				typeof(CompositeBodySyntax),
				typeof(AssemblyDeclarationSyntax),
				typeof(CompositeElementsSyntax),
				typeof(CompositeElementSyntax),
				typeof(CompositeComponentSyntax),
				typeof(CompositeWireSyntax),
				typeof(WireSourceSyntax),
				typeof(WireTargetSyntax),
				typeof(DeploymentDeclarationSyntax),
				typeof(DeploymentBodySyntax),
				typeof(DeploymentElementsSyntax),
				typeof(DeploymentElementSyntax),
				typeof(EnvironmentDeclarationSyntax),
				typeof(EnvironmentBodySyntax),
				typeof(RuntimeDeclarationSyntax),
				typeof(RuntimeReferenceSyntax),
				typeof(AssemblyReferenceSyntax),
				typeof(DatabaseReferenceSyntax),
				typeof(BindingDeclarationSyntax),
				typeof(BindingBodySyntax),
				typeof(BindingLayersSyntax),
				typeof(TransportLayerSyntax),
				typeof(HttpTransportLayerSyntax),
				typeof(HttpTransportLayerEmptyBodySyntax),
				typeof(HttpTransportLayerNonEmptyBodySyntax),
				typeof(RestTransportLayerSyntax),
				typeof(RestTransportLayerEmptyBodySyntax),
				typeof(RestTransportLayerNonEmptyBodySyntax),
				typeof(WebSocketTransportLayerSyntax),
				typeof(WebSocketTransportLayerEmptyBodySyntax),
				typeof(WebSocketTransportLayerNonEmptyBodySyntax),
				typeof(HttpTransportLayerPropertiesSyntax),
				typeof(HttpSslPropertySyntax),
				typeof(HttpClientAuthenticationPropertySyntax),
				typeof(EncodingLayerSyntax),
				typeof(SoapEncodingLayerSyntax),
				typeof(SoapEncodingLayerEmptyBodySyntax),
				typeof(SoapEncodingLayerNonEmptyBodySyntax),
				typeof(XmlEncodingLayerSyntax),
				typeof(XmlEncodingLayerEmptyBodySyntax),
				typeof(XmlEncodingLayerNonEmptyBodySyntax),
				typeof(JsonEncodingLayerSyntax),
				typeof(JsonEncodingLayerEmptyBodySyntax),
				typeof(JsonEncodingLayerNonEmptyBodySyntax),
				typeof(SoapEncodingPropertiesSyntax),
				typeof(SoapVersionPropertySyntax),
				typeof(SoapMtomPropertySyntax),
				typeof(SoapStylePropertySyntax),
				typeof(ProtocolLayerSyntax),
				typeof(ProtocolLayerKindSyntax),
				typeof(WsAddressingSyntax),
				typeof(EndpointDeclarationSyntax),
				typeof(EndpointBodySyntax),
				typeof(EndpointPropertiesSyntax),
				typeof(EndpointPropertySyntax),
				typeof(EndpointBindingPropertySyntax),
				typeof(EndpointAddressPropertySyntax),
				typeof(ReturnTypeSyntax),
				typeof(TypeReferenceSyntax),
				typeof(SimpleTypeSyntax),
				typeof(NulledTypeSyntax),
				typeof(ReferenceTypeSyntax),
				typeof(ObjectTypeSyntax),
				typeof(ValueTypeSyntax),
				typeof(VoidTypeSyntax),
				typeof(OnewayTypeSyntax),
				typeof(OperationReturnTypeSyntax),
				typeof(NullableTypeSyntax),
				typeof(NonNullableTypeSyntax),
				typeof(NonNullableArrayTypeSyntax),
				typeof(ArrayTypeSyntax),
				typeof(SimpleArrayTypeSyntax),
				typeof(NulledArrayTypeSyntax),
				typeof(ConstantValueSyntax),
				typeof(TypeofValueSyntax),
				typeof(IdentifierSyntax),
				typeof(IdentifiersSyntax),
				typeof(LiteralSyntax),
				typeof(NullLiteralSyntax),
				typeof(BooleanLiteralSyntax),
				typeof(IntegerLiteralSyntax),
				typeof(DecimalLiteralSyntax),
				typeof(ScientificLiteralSyntax),
				typeof(StringLiteralSyntax),
				typeof(ContextualKeywordsSyntax),
			};
		}
	}
}

