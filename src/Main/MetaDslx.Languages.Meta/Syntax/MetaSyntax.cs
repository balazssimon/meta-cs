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

namespace MetaDslx.Languages.Meta.Syntax
{
    public abstract class MetaSyntaxNode : LanguageSyntaxNode
    {
        protected MetaSyntaxNode(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected MetaSyntaxNode(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new MetaLanguage Language => MetaLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new MetaSyntaxKind Kind => (MetaSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

        protected override SyntaxTree CreateSyntaxTreeForRoot()
        {
            return MetaSyntaxTree.CreateWithoutClone(this, ParseData.Empty);
        }

        public override TResult Accept<TArg, TResult>(SyntaxVisitor<TArg, TResult> visitor, TArg argument)
        {
            if (visitor is IMetaSyntaxVisitor<TArg, TResult> typedVisitor) return this.Accept(typedVisitor, argument);
            else return visitor.DefaultVisit(this, argument);
        }

        public abstract TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument);

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            if (visitor is IMetaSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            if (visitor is IMetaSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }
        public abstract void Accept(IMetaSyntaxVisitor visitor);
    }

    /// <summary>
    /// It's a non terminal Trivia MetaSyntaxNode that has a tree underneath it.
    /// </summary>
    public abstract partial class MetaStructuredTriviaSyntax : MetaSyntaxNode, IStructuredTriviaSyntax
    {
        private SyntaxTrivia _parent;
        internal MetaStructuredTriviaSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
            : base(green, parent == null ? null : (MetaSyntaxTree)parent.SyntaxTree, position)
        {
            System.Diagnostics.Debug.Assert(parent == null || position >= 0);
        }
		internal static MetaStructuredTriviaSyntax Create(SyntaxTrivia trivia)
		{
			var red = (MetaStructuredTriviaSyntax)MetaLanguage.Instance.SyntaxFactory.CreateStructure(trivia);
			red._parent = trivia;
			return red;
		}
        /// <summary>
        /// Get parent trivia.
        /// </summary>
        public override SyntaxTrivia ParentTrivia => _parent;
    }

    public sealed partial class MetaSkippedTokensTriviaSyntax : MetaStructuredTriviaSyntax
    {
        internal MetaSkippedTokensTriviaSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public SyntaxTokenList Tokens 
        {
            get
            {
				var slot = ((global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.GreenSkippedTokensTriviaSyntax)this.Green).Tokens;
				if (slot != null)
				{
					return new SyntaxTokenList(this, slot.Node, this.GetChildPosition(0), this.GetChildIndex(0));
				}
                return default;
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

		public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
		{
			return visitor.VisitSkippedTokensTrivia(this, argument);
		}

		public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
        {
            return visitor.VisitSkippedTokensTrivia(this);
        }

        public override void Accept(IMetaSyntaxVisitor visitor)
        {
            visitor.VisitSkippedTokensTrivia(this);
        }

        public MetaSkippedTokensTriviaSyntax Update(SyntaxTokenList tokens)
        {
            if (tokens != this.Tokens)
            {
                var newNode = (MetaSkippedTokensTriviaSyntax)Language.SyntaxFactory.SkippedTokensTrivia(tokens);
                var annotations = this.GetAnnotations();
                if (annotations != null && annotations.Length > 0)
                    return newNode.WithAnnotations(annotations);
                return newNode;
            }
            return this;
        }

        public MetaSkippedTokensTriviaSyntax WithTokens(SyntaxTokenList tokens)
        {
            return this.Update(tokens);
        }

        public MetaSkippedTokensTriviaSyntax AddTokens(params SyntaxToken[] items)
        {
            return this.WithTokens(this.Tokens.AddRange(items));
        }
    }

	
	public sealed class MainSyntax : MetaSyntaxNode, ICompilationUnitSyntax
	{
	    private SyntaxNode usingNamespaceOrMetamodel;
	    private NamespaceDeclarationSyntax namespaceDeclaration;
	
	    public MainSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax> UsingNamespaceOrMetamodel 
		{ 
			get
			{
				var red = this.GetRed(ref this.usingNamespaceOrMetamodel, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax>(red);
				return default;
			} 
		}
	    public NamespaceDeclarationSyntax NamespaceDeclaration 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration, 1); } 
		}
	    public SyntaxToken EndOfFileToken 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.EndOfFileToken;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.usingNamespaceOrMetamodel, 0);
				case 1: return this.GetRed(ref this.namespaceDeclaration, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.usingNamespaceOrMetamodel;
				case 1: return this.namespaceDeclaration;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithUsingNamespaceOrMetamodel(Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax> usingNamespaceOrMetamodel)
		{
			return this.Update(UsingNamespaceOrMetamodel, this.NamespaceDeclaration, this.EndOfFileToken);
		}
	
	    public MainSyntax AddUsingNamespaceOrMetamodel(params UsingNamespaceOrMetamodelSyntax[] usingNamespaceOrMetamodel)
		{
			return this.WithUsingNamespaceOrMetamodel(this.UsingNamespaceOrMetamodel.AddRange(usingNamespaceOrMetamodel));
		}
	
	    public MainSyntax WithNamespaceDeclaration(NamespaceDeclarationSyntax namespaceDeclaration)
		{
			return this.Update(this.UsingNamespaceOrMetamodel, NamespaceDeclaration, this.EndOfFileToken);
		}
	
	    public MainSyntax WithEndOfFileToken(SyntaxToken eOF)
		{
			return this.Update(this.UsingNamespaceOrMetamodel, this.NamespaceDeclaration, EndOfFileToken);
		}
	
	    public MainSyntax Update(Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax> usingNamespaceOrMetamodel, NamespaceDeclarationSyntax namespaceDeclaration, SyntaxToken eOF)
	    {
	        if (this.UsingNamespaceOrMetamodel != usingNamespaceOrMetamodel ||
				this.NamespaceDeclaration != namespaceDeclaration ||
				this.EndOfFileToken != eOF)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Main(usingNamespaceOrMetamodel, namespaceDeclaration, eOF);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class NameSyntax : MetaSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class QualifiedNameSyntax : MetaSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.QualifiedName(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifiedName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifiedName(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifiedName(this);
	    }
	}
	
	public sealed class QualifierSyntax : MetaSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public QualifierSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax> Identifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.identifier, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax>(red, this.GetChildIndex(0));
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
	
	    public QualifierSyntax WithIdentifier(Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
			return this.Update(Identifier);
		}
	
	    public QualifierSyntax AddIdentifier(params IdentifierSyntax[] identifier)
		{
			return this.WithIdentifier(this.Identifier.AddRange(identifier));
		}
	
	    public QualifierSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Qualifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifier(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifier(this);
	    }
	}
	
	public sealed class AttributeSyntax : MetaSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public AttributeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AttributeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.AttributeGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.AttributeGreen)this.Green;
				var greenToken = green.TCloseBracket;
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
	
	    public AttributeSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.Qualifier, this.TCloseBracket);
		}
	
	    public AttributeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.TOpenBracket, Qualifier, this.TCloseBracket);
		}
	
	    public AttributeSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.Qualifier, TCloseBracket);
		}
	
	    public AttributeSyntax Update(SyntaxToken tOpenBracket, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.Qualifier != qualifier ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Attribute(tOpenBracket, qualifier, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAttribute(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAttribute(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitAttribute(this);
	    }
	}
	
	public sealed class UsingNamespaceOrMetamodelSyntax : MetaSyntaxNode
	{
	    private UsingNamespaceSyntax usingNamespace;
	    private UsingMetamodelSyntax usingMetamodel;
	
	    public UsingNamespaceOrMetamodelSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UsingNamespaceOrMetamodelSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public UsingNamespaceSyntax UsingNamespace 
		{ 
			get { return this.GetRed(ref this.usingNamespace, 0); } 
		}
	    public UsingMetamodelSyntax UsingMetamodel 
		{ 
			get { return this.GetRed(ref this.usingMetamodel, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.usingNamespace, 0);
				case 1: return this.GetRed(ref this.usingMetamodel, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.usingNamespace;
				case 1: return this.usingMetamodel;
				default: return null;
	        }
	    }
	
	    public UsingNamespaceOrMetamodelSyntax WithUsingNamespace(UsingNamespaceSyntax usingNamespace)
		{
			return this.Update(usingNamespace);
		}
	
	    public UsingNamespaceOrMetamodelSyntax WithUsingMetamodel(UsingMetamodelSyntax usingMetamodel)
		{
			return this.Update(usingMetamodel);
		}
	
	    public UsingNamespaceOrMetamodelSyntax Update(UsingNamespaceSyntax usingNamespace)
	    {
	        if (this.UsingNamespace != usingNamespace)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.UsingNamespaceOrMetamodel(usingNamespace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingNamespaceOrMetamodelSyntax)newNode;
	        }
	        return this;
	    }
	
	    public UsingNamespaceOrMetamodelSyntax Update(UsingMetamodelSyntax usingMetamodel)
	    {
	        if (this.UsingMetamodel != usingMetamodel)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.UsingNamespaceOrMetamodel(usingMetamodel);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingNamespaceOrMetamodelSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUsingNamespaceOrMetamodel(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUsingNamespaceOrMetamodel(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitUsingNamespaceOrMetamodel(this);
	    }
	}
	
	public sealed class UsingNamespaceSyntax : MetaSyntaxNode
	{
	    private NameSyntax name;
	    private QualifierSyntax qualifier;
	
	    public UsingNamespaceSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UsingNamespaceSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KUsing 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.UsingNamespaceGreen)this.Green;
				var greenToken = green.KUsing;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.UsingNamespaceGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.UsingNamespaceGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.qualifier, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public UsingNamespaceSyntax WithKUsing(SyntaxToken kUsing)
		{
			return this.Update(KUsing, this.Name, this.TAssign, this.Qualifier, this.TSemicolon);
		}
	
	    public UsingNamespaceSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KUsing, Name, this.TAssign, this.Qualifier, this.TSemicolon);
		}
	
	    public UsingNamespaceSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.KUsing, this.Name, TAssign, this.Qualifier, this.TSemicolon);
		}
	
	    public UsingNamespaceSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KUsing, this.Name, this.TAssign, Qualifier, this.TSemicolon);
		}
	
	    public UsingNamespaceSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KUsing, this.Name, this.TAssign, this.Qualifier, TSemicolon);
		}
	
	    public UsingNamespaceSyntax Update(SyntaxToken kUsing, NameSyntax name, SyntaxToken tAssign, QualifierSyntax qualifier, SyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.Name != name ||
				this.TAssign != tAssign ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.UsingNamespace(kUsing, name, tAssign, qualifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingNamespaceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUsingNamespace(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUsingNamespace(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitUsingNamespace(this);
	    }
	}
	
	public sealed class UsingMetamodelSyntax : MetaSyntaxNode
	{
	    private NameSyntax name;
	    private UsingMetamodelReferenceSyntax usingMetamodelReference;
	
	    public UsingMetamodelSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UsingMetamodelSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KUsing 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.UsingMetamodelGreen)this.Green;
				var greenToken = green.KUsing;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KMetamodel 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.UsingMetamodelGreen)this.Green;
				var greenToken = green.KMetamodel;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.UsingMetamodelGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public UsingMetamodelReferenceSyntax UsingMetamodelReference 
		{ 
			get { return this.GetRed(ref this.usingMetamodelReference, 4); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.UsingMetamodelGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.name, 2);
				case 4: return this.GetRed(ref this.usingMetamodelReference, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.name;
				case 4: return this.usingMetamodelReference;
				default: return null;
	        }
	    }
	
	    public UsingMetamodelSyntax WithKUsing(SyntaxToken kUsing)
		{
			return this.Update(KUsing, this.KMetamodel, this.Name, this.TAssign, this.UsingMetamodelReference, this.TSemicolon);
		}
	
	    public UsingMetamodelSyntax WithKMetamodel(SyntaxToken kMetamodel)
		{
			return this.Update(this.KUsing, KMetamodel, this.Name, this.TAssign, this.UsingMetamodelReference, this.TSemicolon);
		}
	
	    public UsingMetamodelSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KUsing, this.KMetamodel, Name, this.TAssign, this.UsingMetamodelReference, this.TSemicolon);
		}
	
	    public UsingMetamodelSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.KUsing, this.KMetamodel, this.Name, TAssign, this.UsingMetamodelReference, this.TSemicolon);
		}
	
	    public UsingMetamodelSyntax WithUsingMetamodelReference(UsingMetamodelReferenceSyntax usingMetamodelReference)
		{
			return this.Update(this.KUsing, this.KMetamodel, this.Name, this.TAssign, UsingMetamodelReference, this.TSemicolon);
		}
	
	    public UsingMetamodelSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KUsing, this.KMetamodel, this.Name, this.TAssign, this.UsingMetamodelReference, TSemicolon);
		}
	
	    public UsingMetamodelSyntax Update(SyntaxToken kUsing, SyntaxToken kMetamodel, NameSyntax name, SyntaxToken tAssign, UsingMetamodelReferenceSyntax usingMetamodelReference, SyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.KMetamodel != kMetamodel ||
				this.Name != name ||
				this.TAssign != tAssign ||
				this.UsingMetamodelReference != usingMetamodelReference ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.UsingMetamodel(kUsing, kMetamodel, name, tAssign, usingMetamodelReference, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingMetamodelSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUsingMetamodel(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUsingMetamodel(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitUsingMetamodel(this);
	    }
	}
	
	public sealed class UsingMetamodelReferenceSyntax : MetaSyntaxNode
	{
	    private QualifierSyntax qualifier;
	    private StringLiteralSyntax stringLiteral;
	
	    public UsingMetamodelReferenceSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UsingMetamodelReferenceSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 0); } 
		}
	    public StringLiteralSyntax StringLiteral 
		{ 
			get { return this.GetRed(ref this.stringLiteral, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifier, 0);
				case 1: return this.GetRed(ref this.stringLiteral, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifier;
				case 1: return this.stringLiteral;
				default: return null;
	        }
	    }
	
	    public UsingMetamodelReferenceSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(qualifier);
		}
	
	    public UsingMetamodelReferenceSyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(stringLiteral);
		}
	
	    public UsingMetamodelReferenceSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.UsingMetamodelReference(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingMetamodelReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public UsingMetamodelReferenceSyntax Update(StringLiteralSyntax stringLiteral)
	    {
	        if (this.StringLiteral != stringLiteral)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.UsingMetamodelReference(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingMetamodelReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUsingMetamodelReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUsingMetamodelReference(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitUsingMetamodelReference(this);
	    }
	}
	
	public sealed class NamespaceDeclarationSyntax : MetaSyntaxNode
	{
	    private SyntaxNode attribute;
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBodySyntax namespaceBody;
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
				case 0: return this.GetRed(ref this.attribute, 0);
				case 2: return this.GetRed(ref this.qualifiedName, 2);
				case 3: return this.GetRed(ref this.namespaceBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 2: return this.qualifiedName;
				case 3: return this.namespaceBody;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclarationSyntax WithAttribute(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.KNamespace, this.QualifiedName, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public NamespaceDeclarationSyntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(this.Attribute, KNamespace, this.QualifiedName, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.Attribute, this.KNamespace, QualifiedName, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithNamespaceBody(NamespaceBodySyntax namespaceBody)
		{
			return this.Update(this.Attribute, this.KNamespace, this.QualifiedName, NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
	    {
	        if (this.Attribute != attribute ||
				this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody != namespaceBody)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.NamespaceDeclaration(attribute, kNamespace, qualifiedName, namespaceBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration(this);
	    }
	}
	
	public sealed class NamespaceBodySyntax : MetaSyntaxNode
	{
	    private SyntaxNode usingNamespaceOrMetamodel;
	    private MetamodelDeclarationSyntax metamodelDeclaration;
	    private SyntaxNode declaration;
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax> UsingNamespaceOrMetamodel 
		{ 
			get
			{
				var red = this.GetRed(ref this.usingNamespaceOrMetamodel, 1);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax>(red);
				return default;
			} 
		}
	    public MetamodelDeclarationSyntax MetamodelDeclaration 
		{ 
			get { return this.GetRed(ref this.metamodelDeclaration, 2); } 
		}
	    public Microsoft.CodeAnalysis.SyntaxList<DeclarationSyntax> Declaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration, 3);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<DeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.usingNamespaceOrMetamodel, 1);
				case 2: return this.GetRed(ref this.metamodelDeclaration, 2);
				case 3: return this.GetRed(ref this.declaration, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.usingNamespaceOrMetamodel;
				case 2: return this.metamodelDeclaration;
				case 3: return this.declaration;
				default: return null;
	        }
	    }
	
	    public NamespaceBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.UsingNamespaceOrMetamodel, this.MetamodelDeclaration, this.Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax WithUsingNamespaceOrMetamodel(Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax> usingNamespaceOrMetamodel)
		{
			return this.Update(this.TOpenBrace, UsingNamespaceOrMetamodel, this.MetamodelDeclaration, this.Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax AddUsingNamespaceOrMetamodel(params UsingNamespaceOrMetamodelSyntax[] usingNamespaceOrMetamodel)
		{
			return this.WithUsingNamespaceOrMetamodel(this.UsingNamespaceOrMetamodel.AddRange(usingNamespaceOrMetamodel));
		}
	
	    public NamespaceBodySyntax WithMetamodelDeclaration(MetamodelDeclarationSyntax metamodelDeclaration)
		{
			return this.Update(this.TOpenBrace, this.UsingNamespaceOrMetamodel, MetamodelDeclaration, this.Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax WithDeclaration(Microsoft.CodeAnalysis.SyntaxList<DeclarationSyntax> declaration)
		{
			return this.Update(this.TOpenBrace, this.UsingNamespaceOrMetamodel, this.MetamodelDeclaration, Declaration, this.TCloseBrace);
		}
	
	    public NamespaceBodySyntax AddDeclaration(params DeclarationSyntax[] declaration)
		{
			return this.WithDeclaration(this.Declaration.AddRange(declaration));
		}
	
	    public NamespaceBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.UsingNamespaceOrMetamodel, this.MetamodelDeclaration, this.Declaration, TCloseBrace);
		}
	
	    public NamespaceBodySyntax Update(SyntaxToken tOpenBrace, Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax> usingNamespaceOrMetamodel, MetamodelDeclarationSyntax metamodelDeclaration, Microsoft.CodeAnalysis.SyntaxList<DeclarationSyntax> declaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.UsingNamespaceOrMetamodel != usingNamespaceOrMetamodel ||
				this.MetamodelDeclaration != metamodelDeclaration ||
				this.Declaration != declaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.NamespaceBody(tOpenBrace, usingNamespaceOrMetamodel, metamodelDeclaration, declaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody(this);
	    }
	}
	
	public sealed class MetamodelDeclarationSyntax : MetaSyntaxNode
	{
	    private SyntaxNode attribute;
	    private NameSyntax name;
	    private MetamodelPropertyListSyntax metamodelPropertyList;
	
	    public MetamodelDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MetamodelDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KMetamodel 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelDeclarationGreen)this.Green;
				var greenToken = green.KMetamodel;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 2: return this.GetRed(ref this.name, 2);
				case 4: return this.GetRed(ref this.metamodelPropertyList, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 2: return this.name;
				case 4: return this.metamodelPropertyList;
				default: return null;
	        }
	    }
	
	    public MetamodelDeclarationSyntax WithAttribute(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.KMetamodel, this.Name, this.TOpenParen, this.MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public MetamodelDeclarationSyntax WithKMetamodel(SyntaxToken kMetamodel)
		{
			return this.Update(this.Attribute, KMetamodel, this.Name, this.TOpenParen, this.MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.KMetamodel, Name, this.TOpenParen, this.MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Attribute, this.KMetamodel, this.Name, TOpenParen, this.MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithMetamodelPropertyList(MetamodelPropertyListSyntax metamodelPropertyList)
		{
			return this.Update(this.Attribute, this.KMetamodel, this.Name, this.TOpenParen, MetamodelPropertyList, this.TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Attribute, this.KMetamodel, this.Name, this.TOpenParen, this.MetamodelPropertyList, TCloseParen, this.TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.KMetamodel, this.Name, this.TOpenParen, this.MetamodelPropertyList, this.TCloseParen, TSemicolon);
		}
	
	    public MetamodelDeclarationSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SyntaxToken kMetamodel, NameSyntax name, SyntaxToken tOpenParen, MetamodelPropertyListSyntax metamodelPropertyList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.KMetamodel != kMetamodel ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.MetamodelPropertyList != metamodelPropertyList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MetamodelDeclaration(attribute, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMetamodelDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMetamodelDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitMetamodelDeclaration(this);
	    }
	}
	
	public sealed class MetamodelPropertyListSyntax : MetaSyntaxNode
	{
	    private SyntaxNode metamodelProperty;
	
	    public MetamodelPropertyListSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MetamodelPropertyListSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<MetamodelPropertySyntax> MetamodelProperty 
		{ 
			get
			{
				var red = this.GetRed(ref this.metamodelProperty, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<MetamodelPropertySyntax>(red, this.GetChildIndex(0));
				}
				return default;
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
	
	    public MetamodelPropertyListSyntax WithMetamodelProperty(Microsoft.CodeAnalysis.SeparatedSyntaxList<MetamodelPropertySyntax> metamodelProperty)
		{
			return this.Update(MetamodelProperty);
		}
	
	    public MetamodelPropertyListSyntax AddMetamodelProperty(params MetamodelPropertySyntax[] metamodelProperty)
		{
			return this.WithMetamodelProperty(this.MetamodelProperty.AddRange(metamodelProperty));
		}
	
	    public MetamodelPropertyListSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<MetamodelPropertySyntax> metamodelProperty)
	    {
	        if (this.MetamodelProperty != metamodelProperty)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MetamodelPropertyList(metamodelProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertyListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMetamodelPropertyList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMetamodelPropertyList(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitMetamodelPropertyList(this);
	    }
	}
	
	public sealed class MetamodelPropertySyntax : MetaSyntaxNode
	{
	    private MetamodelUriPropertySyntax metamodelUriProperty;
	    private MetamodelPrefixPropertySyntax metamodelPrefixProperty;
	    private MajorVersionPropertySyntax majorVersionProperty;
	    private MinorVersionPropertySyntax minorVersionProperty;
	
	    public MetamodelPropertySyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MetamodelPropertySyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public MetamodelUriPropertySyntax MetamodelUriProperty 
		{ 
			get { return this.GetRed(ref this.metamodelUriProperty, 0); } 
		}
	    public MetamodelPrefixPropertySyntax MetamodelPrefixProperty 
		{ 
			get { return this.GetRed(ref this.metamodelPrefixProperty, 1); } 
		}
	    public MajorVersionPropertySyntax MajorVersionProperty 
		{ 
			get { return this.GetRed(ref this.majorVersionProperty, 2); } 
		}
	    public MinorVersionPropertySyntax MinorVersionProperty 
		{ 
			get { return this.GetRed(ref this.minorVersionProperty, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.metamodelUriProperty, 0);
				case 1: return this.GetRed(ref this.metamodelPrefixProperty, 1);
				case 2: return this.GetRed(ref this.majorVersionProperty, 2);
				case 3: return this.GetRed(ref this.minorVersionProperty, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.metamodelUriProperty;
				case 1: return this.metamodelPrefixProperty;
				case 2: return this.majorVersionProperty;
				case 3: return this.minorVersionProperty;
				default: return null;
	        }
	    }
	
	    public MetamodelPropertySyntax WithMetamodelUriProperty(MetamodelUriPropertySyntax metamodelUriProperty)
		{
			return this.Update(metamodelUriProperty);
		}
	
	    public MetamodelPropertySyntax WithMetamodelPrefixProperty(MetamodelPrefixPropertySyntax metamodelPrefixProperty)
		{
			return this.Update(metamodelPrefixProperty);
		}
	
	    public MetamodelPropertySyntax WithMajorVersionProperty(MajorVersionPropertySyntax majorVersionProperty)
		{
			return this.Update(majorVersionProperty);
		}
	
	    public MetamodelPropertySyntax WithMinorVersionProperty(MinorVersionPropertySyntax minorVersionProperty)
		{
			return this.Update(minorVersionProperty);
		}
	
	    public MetamodelPropertySyntax Update(MetamodelUriPropertySyntax metamodelUriProperty)
	    {
	        if (this.MetamodelUriProperty != metamodelUriProperty)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MetamodelProperty(metamodelUriProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public MetamodelPropertySyntax Update(MetamodelPrefixPropertySyntax metamodelPrefixProperty)
	    {
	        if (this.MetamodelPrefixProperty != metamodelPrefixProperty)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MetamodelProperty(metamodelPrefixProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public MetamodelPropertySyntax Update(MajorVersionPropertySyntax majorVersionProperty)
	    {
	        if (this.MajorVersionProperty != majorVersionProperty)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MetamodelProperty(majorVersionProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public MetamodelPropertySyntax Update(MinorVersionPropertySyntax minorVersionProperty)
	    {
	        if (this.MinorVersionProperty != minorVersionProperty)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MetamodelProperty(minorVersionProperty);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMetamodelProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMetamodelProperty(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitMetamodelProperty(this);
	    }
	}
	
	public sealed class MetamodelUriPropertySyntax : MetaSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public MetamodelUriPropertySyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MetamodelUriPropertySyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IUri 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelUriPropertyGreen)this.Green;
				var greenToken = green.IUri;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelUriPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MetamodelUriProperty(iUri, tAssign, stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelUriPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMetamodelUriProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMetamodelUriProperty(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitMetamodelUriProperty(this);
	    }
	}
	
	public sealed class MetamodelPrefixPropertySyntax : MetaSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public MetamodelPrefixPropertySyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MetamodelPrefixPropertySyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IPrefix 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelPrefixPropertyGreen)this.Green;
				var greenToken = green.IPrefix;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MetamodelPrefixPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	
	    public MetamodelPrefixPropertySyntax WithIPrefix(SyntaxToken iPrefix)
		{
			return this.Update(IPrefix, this.TAssign, this.StringLiteral);
		}
	
	    public MetamodelPrefixPropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.IPrefix, TAssign, this.StringLiteral);
		}
	
	    public MetamodelPrefixPropertySyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(this.IPrefix, this.TAssign, StringLiteral);
		}
	
	    public MetamodelPrefixPropertySyntax Update(SyntaxToken iPrefix, SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
	    {
	        if (this.IPrefix != iPrefix ||
				this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MetamodelPrefixProperty(iPrefix, tAssign, stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MetamodelPrefixPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMetamodelPrefixProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMetamodelPrefixProperty(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitMetamodelPrefixProperty(this);
	    }
	}
	
	public sealed class MajorVersionPropertySyntax : MetaSyntaxNode
	{
	    private IntegerLiteralSyntax integerLiteral;
	
	    public MajorVersionPropertySyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MajorVersionPropertySyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IMajorVersion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MajorVersionPropertyGreen)this.Green;
				var greenToken = green.IMajorVersion;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MajorVersionPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IntegerLiteralSyntax IntegerLiteral 
		{ 
			get { return this.GetRed(ref this.integerLiteral, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.integerLiteral, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.integerLiteral;
				default: return null;
	        }
	    }
	
	    public MajorVersionPropertySyntax WithIMajorVersion(SyntaxToken iMajorVersion)
		{
			return this.Update(IMajorVersion, this.TAssign, this.IntegerLiteral);
		}
	
	    public MajorVersionPropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.IMajorVersion, TAssign, this.IntegerLiteral);
		}
	
	    public MajorVersionPropertySyntax WithIntegerLiteral(IntegerLiteralSyntax integerLiteral)
		{
			return this.Update(this.IMajorVersion, this.TAssign, IntegerLiteral);
		}
	
	    public MajorVersionPropertySyntax Update(SyntaxToken iMajorVersion, SyntaxToken tAssign, IntegerLiteralSyntax integerLiteral)
	    {
	        if (this.IMajorVersion != iMajorVersion ||
				this.TAssign != tAssign ||
				this.IntegerLiteral != integerLiteral)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MajorVersionProperty(iMajorVersion, tAssign, integerLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MajorVersionPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMajorVersionProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMajorVersionProperty(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitMajorVersionProperty(this);
	    }
	}
	
	public sealed class MinorVersionPropertySyntax : MetaSyntaxNode
	{
	    private IntegerLiteralSyntax integerLiteral;
	
	    public MinorVersionPropertySyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MinorVersionPropertySyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IMinorVersion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MinorVersionPropertyGreen)this.Green;
				var greenToken = green.IMinorVersion;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.MinorVersionPropertyGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IntegerLiteralSyntax IntegerLiteral 
		{ 
			get { return this.GetRed(ref this.integerLiteral, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.integerLiteral, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.integerLiteral;
				default: return null;
	        }
	    }
	
	    public MinorVersionPropertySyntax WithIMinorVersion(SyntaxToken iMinorVersion)
		{
			return this.Update(IMinorVersion, this.TAssign, this.IntegerLiteral);
		}
	
	    public MinorVersionPropertySyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.IMinorVersion, TAssign, this.IntegerLiteral);
		}
	
	    public MinorVersionPropertySyntax WithIntegerLiteral(IntegerLiteralSyntax integerLiteral)
		{
			return this.Update(this.IMinorVersion, this.TAssign, IntegerLiteral);
		}
	
	    public MinorVersionPropertySyntax Update(SyntaxToken iMinorVersion, SyntaxToken tAssign, IntegerLiteralSyntax integerLiteral)
	    {
	        if (this.IMinorVersion != iMinorVersion ||
				this.TAssign != tAssign ||
				this.IntegerLiteral != integerLiteral)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.MinorVersionProperty(iMinorVersion, tAssign, integerLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MinorVersionPropertySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMinorVersionProperty(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMinorVersionProperty(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitMinorVersionProperty(this);
	    }
	}
	
	public sealed class DeclarationSyntax : MetaSyntaxNode
	{
	    private EnumDeclarationSyntax enumDeclaration;
	    private ClassDeclarationSyntax classDeclaration;
	    private AssociationDeclarationSyntax associationDeclaration;
	    private ConstDeclarationSyntax constDeclaration;
	
	    public DeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Declaration(enumDeclaration);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Declaration(classDeclaration);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Declaration(associationDeclaration);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Declaration(constDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration(this);
	    }
	}
	
	public sealed class EnumDeclarationSyntax : MetaSyntaxNode
	{
	    private SyntaxNode attribute;
	    private NameSyntax name;
	    private EnumBodySyntax enumBody;
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KEnum 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.EnumDeclarationGreen)this.Green;
				var greenToken = green.KEnum;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
				case 0: return this.GetRed(ref this.attribute, 0);
				case 2: return this.GetRed(ref this.name, 2);
				case 3: return this.GetRed(ref this.enumBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 2: return this.name;
				case 3: return this.enumBody;
				default: return null;
	        }
	    }
	
	    public EnumDeclarationSyntax WithAttribute(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.KEnum, this.Name, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public EnumDeclarationSyntax WithKEnum(SyntaxToken kEnum)
		{
			return this.Update(this.Attribute, KEnum, this.Name, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.KEnum, Name, this.EnumBody);
		}
	
	    public EnumDeclarationSyntax WithEnumBody(EnumBodySyntax enumBody)
		{
			return this.Update(this.Attribute, this.KEnum, this.Name, EnumBody);
		}
	
	    public EnumDeclarationSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SyntaxToken kEnum, NameSyntax name, EnumBodySyntax enumBody)
	    {
	        if (this.Attribute != attribute ||
				this.KEnum != kEnum ||
				this.Name != name ||
				this.EnumBody != enumBody)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.EnumDeclaration(attribute, kEnum, name, enumBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumDeclaration(this);
	    }
	}
	
	public sealed class EnumBodySyntax : MetaSyntaxNode
	{
	    private EnumValuesSyntax enumValues;
	    private SyntaxNode enumMemberDeclaration;
	
	    public EnumBodySyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumBodySyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public Microsoft.CodeAnalysis.SyntaxList<EnumMemberDeclarationSyntax> EnumMemberDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.enumMemberDeclaration, 3);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<EnumMemberDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
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
	
	    public EnumBodySyntax WithEnumMemberDeclaration(Microsoft.CodeAnalysis.SyntaxList<EnumMemberDeclarationSyntax> enumMemberDeclaration)
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
	
	    public EnumBodySyntax Update(SyntaxToken tOpenBrace, EnumValuesSyntax enumValues, SyntaxToken tSemicolon, Microsoft.CodeAnalysis.SyntaxList<EnumMemberDeclarationSyntax> enumMemberDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EnumValues != enumValues ||
				this.TSemicolon != tSemicolon ||
				this.EnumMemberDeclaration != enumMemberDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumBody(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumBody(this);
	    }
	}
	
	public sealed class EnumValuesSyntax : MetaSyntaxNode
	{
	    private SyntaxNode enumValue;
	
	    public EnumValuesSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumValuesSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<EnumValueSyntax> EnumValue 
		{ 
			get
			{
				var red = this.GetRed(ref this.enumValue, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<EnumValueSyntax>(red, this.GetChildIndex(0));
				}
				return default;
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
	
	    public EnumValuesSyntax WithEnumValue(Microsoft.CodeAnalysis.SeparatedSyntaxList<EnumValueSyntax> enumValue)
		{
			return this.Update(EnumValue);
		}
	
	    public EnumValuesSyntax AddEnumValue(params EnumValueSyntax[] enumValue)
		{
			return this.WithEnumValue(this.EnumValue.AddRange(enumValue));
		}
	
	    public EnumValuesSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<EnumValueSyntax> enumValue)
	    {
	        if (this.EnumValue != enumValue)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.EnumValues(enumValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumValuesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumValues(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumValues(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumValues(this);
	    }
	}
	
	public sealed class EnumValueSyntax : MetaSyntaxNode
	{
	    private SyntaxNode attribute;
	    private NameSyntax name;
	
	    public EnumValueSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumValueSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax>(red);
				return default;
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
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.name, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 1: return this.name;
				default: return null;
	        }
	    }
	
	    public EnumValueSyntax WithAttribute(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.Name);
		}
	
	    public EnumValueSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public EnumValueSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, Name);
		}
	
	    public EnumValueSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, NameSyntax name)
	    {
	        if (this.Attribute != attribute ||
				this.Name != name)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.EnumValue(attribute, name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumValue(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumValue(this);
	    }
	}
	
	public sealed class EnumMemberDeclarationSyntax : MetaSyntaxNode
	{
	    private OperationDeclarationSyntax operationDeclaration;
	
	    public EnumMemberDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumMemberDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.EnumMemberDeclaration(operationDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumMemberDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumMemberDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumMemberDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumMemberDeclaration(this);
	    }
	}
	
	public sealed class ClassDeclarationSyntax : MetaSyntaxNode
	{
	    private SyntaxNode attribute;
	    private SymbolAttributeSyntax symbolAttribute;
	    private NameSyntax name;
	    private ClassAncestorsSyntax classAncestors;
	    private ClassBodySyntax classBody;
	
	    public ClassDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SymbolAttributeSyntax SymbolAttribute 
		{ 
			get { return this.GetRed(ref this.symbolAttribute, 1); } 
		}
	    public SyntaxToken KAbstract 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassDeclarationGreen)this.Green;
				var greenToken = green.KAbstract;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public SyntaxToken KClass 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassDeclarationGreen)this.Green;
				var greenToken = green.KClass;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 4); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	    public ClassAncestorsSyntax ClassAncestors 
		{ 
			get { return this.GetRed(ref this.classAncestors, 6); } 
		}
	    public ClassBodySyntax ClassBody 
		{ 
			get { return this.GetRed(ref this.classBody, 7); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.symbolAttribute, 1);
				case 4: return this.GetRed(ref this.name, 4);
				case 6: return this.GetRed(ref this.classAncestors, 6);
				case 7: return this.GetRed(ref this.classBody, 7);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 1: return this.symbolAttribute;
				case 4: return this.name;
				case 6: return this.classAncestors;
				case 7: return this.classBody;
				default: return null;
	        }
	    }
	
	    public ClassDeclarationSyntax WithAttribute(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.SymbolAttribute, this.KAbstract, this.KClass, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public ClassDeclarationSyntax WithSymbolAttribute(SymbolAttributeSyntax symbolAttribute)
		{
			return this.Update(this.Attribute, SymbolAttribute, this.KAbstract, this.KClass, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithKAbstract(SyntaxToken kAbstract)
		{
			return this.Update(this.Attribute, this.SymbolAttribute, KAbstract, this.KClass, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithKClass(SyntaxToken kClass)
		{
			return this.Update(this.Attribute, this.SymbolAttribute, this.KAbstract, KClass, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.SymbolAttribute, this.KAbstract, this.KClass, Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Attribute, this.SymbolAttribute, this.KAbstract, this.KClass, this.Name, TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassAncestors(ClassAncestorsSyntax classAncestors)
		{
			return this.Update(this.Attribute, this.SymbolAttribute, this.KAbstract, this.KClass, this.Name, this.TColon, ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassBody(ClassBodySyntax classBody)
		{
			return this.Update(this.Attribute, this.SymbolAttribute, this.KAbstract, this.KClass, this.Name, this.TColon, this.ClassAncestors, ClassBody);
		}
	
	    public ClassDeclarationSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SymbolAttributeSyntax symbolAttribute, SyntaxToken kAbstract, SyntaxToken kClass, NameSyntax name, SyntaxToken tColon, ClassAncestorsSyntax classAncestors, ClassBodySyntax classBody)
	    {
	        if (this.Attribute != attribute ||
				this.SymbolAttribute != symbolAttribute ||
				this.KAbstract != kAbstract ||
				this.KClass != kClass ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ClassAncestors != classAncestors ||
				this.ClassBody != classBody)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ClassDeclaration(attribute, symbolAttribute, kAbstract, kClass, name, tColon, classAncestors, classBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitClassDeclaration(this);
	    }
	}
	
	public sealed class SymbolAttributeSyntax : MetaSyntaxNode
	{
	    private SymbolSymbolAttributeSyntax symbolSymbolAttribute;
	    private ExpressionSymbolAttributeSyntax expressionSymbolAttribute;
	    private StatementSymbolTypeAttributeSyntax statementSymbolTypeAttribute;
	    private TypeSymbolTypeAttributeSyntax typeSymbolTypeAttribute;
	
	    public SymbolAttributeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SymbolAttributeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SymbolSymbolAttributeSyntax SymbolSymbolAttribute 
		{ 
			get { return this.GetRed(ref this.symbolSymbolAttribute, 0); } 
		}
	    public ExpressionSymbolAttributeSyntax ExpressionSymbolAttribute 
		{ 
			get { return this.GetRed(ref this.expressionSymbolAttribute, 1); } 
		}
	    public StatementSymbolTypeAttributeSyntax StatementSymbolTypeAttribute 
		{ 
			get { return this.GetRed(ref this.statementSymbolTypeAttribute, 2); } 
		}
	    public TypeSymbolTypeAttributeSyntax TypeSymbolTypeAttribute 
		{ 
			get { return this.GetRed(ref this.typeSymbolTypeAttribute, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.symbolSymbolAttribute, 0);
				case 1: return this.GetRed(ref this.expressionSymbolAttribute, 1);
				case 2: return this.GetRed(ref this.statementSymbolTypeAttribute, 2);
				case 3: return this.GetRed(ref this.typeSymbolTypeAttribute, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.symbolSymbolAttribute;
				case 1: return this.expressionSymbolAttribute;
				case 2: return this.statementSymbolTypeAttribute;
				case 3: return this.typeSymbolTypeAttribute;
				default: return null;
	        }
	    }
	
	    public SymbolAttributeSyntax WithSymbolSymbolAttribute(SymbolSymbolAttributeSyntax symbolSymbolAttribute)
		{
			return this.Update(symbolSymbolAttribute);
		}
	
	    public SymbolAttributeSyntax WithExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax expressionSymbolAttribute)
		{
			return this.Update(expressionSymbolAttribute);
		}
	
	    public SymbolAttributeSyntax WithStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax statementSymbolTypeAttribute)
		{
			return this.Update(statementSymbolTypeAttribute);
		}
	
	    public SymbolAttributeSyntax WithTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax typeSymbolTypeAttribute)
		{
			return this.Update(typeSymbolTypeAttribute);
		}
	
	    public SymbolAttributeSyntax Update(SymbolSymbolAttributeSyntax symbolSymbolAttribute)
	    {
	        if (this.SymbolSymbolAttribute != symbolSymbolAttribute)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.SymbolAttribute(symbolSymbolAttribute);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SymbolAttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SymbolAttributeSyntax Update(ExpressionSymbolAttributeSyntax expressionSymbolAttribute)
	    {
	        if (this.ExpressionSymbolAttribute != expressionSymbolAttribute)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.SymbolAttribute(expressionSymbolAttribute);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SymbolAttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SymbolAttributeSyntax Update(StatementSymbolTypeAttributeSyntax statementSymbolTypeAttribute)
	    {
	        if (this.StatementSymbolTypeAttribute != statementSymbolTypeAttribute)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.SymbolAttribute(statementSymbolTypeAttribute);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SymbolAttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SymbolAttributeSyntax Update(TypeSymbolTypeAttributeSyntax typeSymbolTypeAttribute)
	    {
	        if (this.TypeSymbolTypeAttribute != typeSymbolTypeAttribute)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.SymbolAttribute(typeSymbolTypeAttribute);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SymbolAttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSymbolAttribute(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSymbolAttribute(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitSymbolAttribute(this);
	    }
	}
	
	public sealed class SymbolSymbolAttributeSyntax : MetaSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public SymbolSymbolAttributeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SymbolSymbolAttributeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.SymbolSymbolAttributeGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KSymbol 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.SymbolSymbolAttributeGreen)this.Green;
				var greenToken = green.KSymbol;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.SymbolSymbolAttributeGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.SymbolSymbolAttributeGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.GetRed(ref this.qualifier, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public SymbolSymbolAttributeSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.KSymbol, this.TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public SymbolSymbolAttributeSyntax WithKSymbol(SyntaxToken kSymbol)
		{
			return this.Update(this.TOpenBracket, KSymbol, this.TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public SymbolSymbolAttributeSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.TOpenBracket, this.KSymbol, TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public SymbolSymbolAttributeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.TOpenBracket, this.KSymbol, this.TColon, Qualifier, this.TCloseBracket);
		}
	
	    public SymbolSymbolAttributeSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.KSymbol, this.TColon, this.Qualifier, TCloseBracket);
		}
	
	    public SymbolSymbolAttributeSyntax Update(SyntaxToken tOpenBracket, SyntaxToken kSymbol, SyntaxToken tColon, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.KSymbol != kSymbol ||
				this.TColon != tColon ||
				this.Qualifier != qualifier ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.SymbolSymbolAttribute(tOpenBracket, kSymbol, tColon, qualifier, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SymbolSymbolAttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSymbolSymbolAttribute(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSymbolSymbolAttribute(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitSymbolSymbolAttribute(this);
	    }
	}
	
	public sealed class ExpressionSymbolAttributeSyntax : MetaSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public ExpressionSymbolAttributeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ExpressionSymbolAttributeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ExpressionSymbolAttributeGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KExpression 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ExpressionSymbolAttributeGreen)this.Green;
				var greenToken = green.KExpression;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ExpressionSymbolAttributeGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ExpressionSymbolAttributeGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.GetRed(ref this.qualifier, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public ExpressionSymbolAttributeSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.KExpression, this.TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public ExpressionSymbolAttributeSyntax WithKExpression(SyntaxToken kExpression)
		{
			return this.Update(this.TOpenBracket, KExpression, this.TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public ExpressionSymbolAttributeSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.TOpenBracket, this.KExpression, TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public ExpressionSymbolAttributeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.TOpenBracket, this.KExpression, this.TColon, Qualifier, this.TCloseBracket);
		}
	
	    public ExpressionSymbolAttributeSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.KExpression, this.TColon, this.Qualifier, TCloseBracket);
		}
	
	    public ExpressionSymbolAttributeSyntax Update(SyntaxToken tOpenBracket, SyntaxToken kExpression, SyntaxToken tColon, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.KExpression != kExpression ||
				this.TColon != tColon ||
				this.Qualifier != qualifier ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ExpressionSymbolAttribute(tOpenBracket, kExpression, tColon, qualifier, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionSymbolAttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitExpressionSymbolAttribute(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitExpressionSymbolAttribute(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitExpressionSymbolAttribute(this);
	    }
	}
	
	public sealed class StatementSymbolTypeAttributeSyntax : MetaSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public StatementSymbolTypeAttributeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StatementSymbolTypeAttributeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.StatementSymbolTypeAttributeGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KStatement 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.StatementSymbolTypeAttributeGreen)this.Green;
				var greenToken = green.KStatement;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.StatementSymbolTypeAttributeGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.StatementSymbolTypeAttributeGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.GetRed(ref this.qualifier, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public StatementSymbolTypeAttributeSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.KStatement, this.TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public StatementSymbolTypeAttributeSyntax WithKStatement(SyntaxToken kStatement)
		{
			return this.Update(this.TOpenBracket, KStatement, this.TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public StatementSymbolTypeAttributeSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.TOpenBracket, this.KStatement, TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public StatementSymbolTypeAttributeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.TOpenBracket, this.KStatement, this.TColon, Qualifier, this.TCloseBracket);
		}
	
	    public StatementSymbolTypeAttributeSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.KStatement, this.TColon, this.Qualifier, TCloseBracket);
		}
	
	    public StatementSymbolTypeAttributeSyntax Update(SyntaxToken tOpenBracket, SyntaxToken kStatement, SyntaxToken tColon, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.KStatement != kStatement ||
				this.TColon != tColon ||
				this.Qualifier != qualifier ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.StatementSymbolTypeAttribute(tOpenBracket, kStatement, tColon, qualifier, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSymbolTypeAttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStatementSymbolTypeAttribute(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStatementSymbolTypeAttribute(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitStatementSymbolTypeAttribute(this);
	    }
	}
	
	public sealed class TypeSymbolTypeAttributeSyntax : MetaSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public TypeSymbolTypeAttributeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeSymbolTypeAttributeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.TypeSymbolTypeAttributeGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.TypeSymbolTypeAttributeGreen)this.Green;
				var greenToken = green.KType;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.TypeSymbolTypeAttributeGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.TypeSymbolTypeAttributeGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.GetRed(ref this.qualifier, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.qualifier;
				default: return null;
	        }
	    }
	
	    public TypeSymbolTypeAttributeSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.KType, this.TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public TypeSymbolTypeAttributeSyntax WithKType(SyntaxToken kType)
		{
			return this.Update(this.TOpenBracket, KType, this.TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public TypeSymbolTypeAttributeSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.TOpenBracket, this.KType, TColon, this.Qualifier, this.TCloseBracket);
		}
	
	    public TypeSymbolTypeAttributeSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.TOpenBracket, this.KType, this.TColon, Qualifier, this.TCloseBracket);
		}
	
	    public TypeSymbolTypeAttributeSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.KType, this.TColon, this.Qualifier, TCloseBracket);
		}
	
	    public TypeSymbolTypeAttributeSyntax Update(SyntaxToken tOpenBracket, SyntaxToken kType, SyntaxToken tColon, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.KType != kType ||
				this.TColon != tColon ||
				this.Qualifier != qualifier ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.TypeSymbolTypeAttribute(tOpenBracket, kType, tColon, qualifier, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeSymbolTypeAttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeSymbolTypeAttribute(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeSymbolTypeAttribute(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeSymbolTypeAttribute(this);
	    }
	}
	
	public sealed class ClassBodySyntax : MetaSyntaxNode
	{
	    private SyntaxNode classMemberDeclaration;
	
	    public ClassBodySyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassBodySyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public Microsoft.CodeAnalysis.SyntaxList<ClassMemberDeclarationSyntax> ClassMemberDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.classMemberDeclaration, 1);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<ClassMemberDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ClassBodyGreen)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
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
	
	    public ClassBodySyntax WithClassMemberDeclaration(Microsoft.CodeAnalysis.SyntaxList<ClassMemberDeclarationSyntax> classMemberDeclaration)
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
	
	    public ClassBodySyntax Update(SyntaxToken tOpenBrace, Microsoft.CodeAnalysis.SyntaxList<ClassMemberDeclarationSyntax> classMemberDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ClassMemberDeclaration != classMemberDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassBody(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitClassBody(this);
	    }
	}
	
	public sealed class ClassAncestorsSyntax : MetaSyntaxNode
	{
	    private SyntaxNode classAncestor;
	
	    public ClassAncestorsSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassAncestorsSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<ClassAncestorSyntax> ClassAncestor 
		{ 
			get
			{
				var red = this.GetRed(ref this.classAncestor, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<ClassAncestorSyntax>(red, this.GetChildIndex(0));
				}
				return default;
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
	
	    public ClassAncestorsSyntax WithClassAncestor(Microsoft.CodeAnalysis.SeparatedSyntaxList<ClassAncestorSyntax> classAncestor)
		{
			return this.Update(ClassAncestor);
		}
	
	    public ClassAncestorsSyntax AddClassAncestor(params ClassAncestorSyntax[] classAncestor)
		{
			return this.WithClassAncestor(this.ClassAncestor.AddRange(classAncestor));
		}
	
	    public ClassAncestorsSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<ClassAncestorSyntax> classAncestor)
	    {
	        if (this.ClassAncestor != classAncestor)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ClassAncestors(classAncestor);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassAncestorsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassAncestors(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassAncestors(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitClassAncestors(this);
	    }
	}
	
	public sealed class ClassAncestorSyntax : MetaSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public ClassAncestorSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassAncestorSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ClassAncestor(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassAncestorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassAncestor(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassAncestor(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitClassAncestor(this);
	    }
	}
	
	public sealed class ClassMemberDeclarationSyntax : MetaSyntaxNode
	{
	    private FieldDeclarationSyntax fieldDeclaration;
	    private OperationDeclarationSyntax operationDeclaration;
	
	    public ClassMemberDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassMemberDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ClassMemberDeclaration(fieldDeclaration);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ClassMemberDeclaration(operationDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassMemberDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassMemberDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassMemberDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitClassMemberDeclaration(this);
	    }
	}
	
	public sealed class FieldDeclarationSyntax : MetaSyntaxNode
	{
	    private SyntaxNode attribute;
	    private FieldSymbolPropertyAttributeSyntax fieldSymbolPropertyAttribute;
	    private FieldContainmentSyntax fieldContainment;
	    private FieldModifierSyntax fieldModifier;
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	    private DefaultValueSyntax defaultValue;
	    private SyntaxNode redefinitionsOrSubsettings;
	
	    public FieldDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public FieldSymbolPropertyAttributeSyntax FieldSymbolPropertyAttribute 
		{ 
			get { return this.GetRed(ref this.fieldSymbolPropertyAttribute, 1); } 
		}
	    public FieldContainmentSyntax FieldContainment 
		{ 
			get { return this.GetRed(ref this.fieldContainment, 2); } 
		}
	    public FieldModifierSyntax FieldModifier 
		{ 
			get { return this.GetRed(ref this.fieldModifier, 3); } 
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 4); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 5); } 
		}
	    public DefaultValueSyntax DefaultValue 
		{ 
			get { return this.GetRed(ref this.defaultValue, 6); } 
		}
	    public Microsoft.CodeAnalysis.SyntaxList<RedefinitionsOrSubsettingsSyntax> RedefinitionsOrSubsettings 
		{ 
			get
			{
				var red = this.GetRed(ref this.redefinitionsOrSubsettings, 7);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<RedefinitionsOrSubsettingsSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.FieldDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(8), this.GetChildIndex(8));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.fieldSymbolPropertyAttribute, 1);
				case 2: return this.GetRed(ref this.fieldContainment, 2);
				case 3: return this.GetRed(ref this.fieldModifier, 3);
				case 4: return this.GetRed(ref this.typeReference, 4);
				case 5: return this.GetRed(ref this.name, 5);
				case 6: return this.GetRed(ref this.defaultValue, 6);
				case 7: return this.GetRed(ref this.redefinitionsOrSubsettings, 7);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 1: return this.fieldSymbolPropertyAttribute;
				case 2: return this.fieldContainment;
				case 3: return this.fieldModifier;
				case 4: return this.typeReference;
				case 5: return this.name;
				case 6: return this.defaultValue;
				case 7: return this.redefinitionsOrSubsettings;
				default: return null;
	        }
	    }
	
	    public FieldDeclarationSyntax WithAttribute(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.FieldSymbolPropertyAttribute, this.FieldContainment, this.FieldModifier, this.TypeReference, this.Name, this.DefaultValue, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public FieldDeclarationSyntax WithFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax fieldSymbolPropertyAttribute)
		{
			return this.Update(this.Attribute, FieldSymbolPropertyAttribute, this.FieldContainment, this.FieldModifier, this.TypeReference, this.Name, this.DefaultValue, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithFieldContainment(FieldContainmentSyntax fieldContainment)
		{
			return this.Update(this.Attribute, this.FieldSymbolPropertyAttribute, FieldContainment, this.FieldModifier, this.TypeReference, this.Name, this.DefaultValue, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithFieldModifier(FieldModifierSyntax fieldModifier)
		{
			return this.Update(this.Attribute, this.FieldSymbolPropertyAttribute, this.FieldContainment, FieldModifier, this.TypeReference, this.Name, this.DefaultValue, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Attribute, this.FieldSymbolPropertyAttribute, this.FieldContainment, this.FieldModifier, TypeReference, this.Name, this.DefaultValue, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.FieldSymbolPropertyAttribute, this.FieldContainment, this.FieldModifier, this.TypeReference, Name, this.DefaultValue, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithDefaultValue(DefaultValueSyntax defaultValue)
		{
			return this.Update(this.Attribute, this.FieldSymbolPropertyAttribute, this.FieldContainment, this.FieldModifier, this.TypeReference, this.Name, DefaultValue, this.RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithRedefinitionsOrSubsettings(Microsoft.CodeAnalysis.SyntaxList<RedefinitionsOrSubsettingsSyntax> redefinitionsOrSubsettings)
		{
			return this.Update(this.Attribute, this.FieldSymbolPropertyAttribute, this.FieldContainment, this.FieldModifier, this.TypeReference, this.Name, this.DefaultValue, RedefinitionsOrSubsettings, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax AddRedefinitionsOrSubsettings(params RedefinitionsOrSubsettingsSyntax[] redefinitionsOrSubsettings)
		{
			return this.WithRedefinitionsOrSubsettings(this.RedefinitionsOrSubsettings.AddRange(redefinitionsOrSubsettings));
		}
	
	    public FieldDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.FieldSymbolPropertyAttribute, this.FieldContainment, this.FieldModifier, this.TypeReference, this.Name, this.DefaultValue, this.RedefinitionsOrSubsettings, TSemicolon);
		}
	
	    public FieldDeclarationSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, FieldSymbolPropertyAttributeSyntax fieldSymbolPropertyAttribute, FieldContainmentSyntax fieldContainment, FieldModifierSyntax fieldModifier, TypeReferenceSyntax typeReference, NameSyntax name, DefaultValueSyntax defaultValue, Microsoft.CodeAnalysis.SyntaxList<RedefinitionsOrSubsettingsSyntax> redefinitionsOrSubsettings, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.FieldSymbolPropertyAttribute != fieldSymbolPropertyAttribute ||
				this.FieldContainment != fieldContainment ||
				this.FieldModifier != fieldModifier ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.DefaultValue != defaultValue ||
				this.RedefinitionsOrSubsettings != redefinitionsOrSubsettings ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.FieldDeclaration(attribute, fieldSymbolPropertyAttribute, fieldContainment, fieldModifier, typeReference, name, defaultValue, redefinitionsOrSubsettings, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldDeclaration(this);
	    }
	}
	
	public sealed class FieldSymbolPropertyAttributeSyntax : MetaSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public FieldSymbolPropertyAttributeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldSymbolPropertyAttributeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.FieldSymbolPropertyAttributeGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KProperty 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.FieldSymbolPropertyAttributeGreen)this.Green;
				var greenToken = green.KProperty;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.FieldSymbolPropertyAttributeGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 3); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.FieldSymbolPropertyAttributeGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.GetRed(ref this.identifier, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.identifier;
				default: return null;
	        }
	    }
	
	    public FieldSymbolPropertyAttributeSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.KProperty, this.TColon, this.Identifier, this.TCloseBracket);
		}
	
	    public FieldSymbolPropertyAttributeSyntax WithKProperty(SyntaxToken kProperty)
		{
			return this.Update(this.TOpenBracket, KProperty, this.TColon, this.Identifier, this.TCloseBracket);
		}
	
	    public FieldSymbolPropertyAttributeSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.TOpenBracket, this.KProperty, TColon, this.Identifier, this.TCloseBracket);
		}
	
	    public FieldSymbolPropertyAttributeSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.TOpenBracket, this.KProperty, this.TColon, Identifier, this.TCloseBracket);
		}
	
	    public FieldSymbolPropertyAttributeSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.KProperty, this.TColon, this.Identifier, TCloseBracket);
		}
	
	    public FieldSymbolPropertyAttributeSyntax Update(SyntaxToken tOpenBracket, SyntaxToken kProperty, SyntaxToken tColon, IdentifierSyntax identifier, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.KProperty != kProperty ||
				this.TColon != tColon ||
				this.Identifier != identifier ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.FieldSymbolPropertyAttribute(tOpenBracket, kProperty, tColon, identifier, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldSymbolPropertyAttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldSymbolPropertyAttribute(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldSymbolPropertyAttribute(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldSymbolPropertyAttribute(this);
	    }
	}
	
	public sealed class FieldContainmentSyntax : MetaSyntaxNode
	{
	
	    public FieldContainmentSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldContainmentSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KContainment 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.FieldContainmentGreen)this.Green;
				var greenToken = green.KContainment;
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
	
	    public FieldContainmentSyntax WithKContainment(SyntaxToken kContainment)
		{
			return this.Update(KContainment);
		}
	
	    public FieldContainmentSyntax Update(SyntaxToken kContainment)
	    {
	        if (this.KContainment != kContainment)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.FieldContainment(kContainment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldContainmentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldContainment(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldContainment(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldContainment(this);
	    }
	}
	
	public sealed class FieldModifierSyntax : MetaSyntaxNode
	{
	
	    public FieldModifierSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldModifierSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken FieldModifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.FieldModifierGreen)this.Green;
				var greenToken = green.FieldModifier;
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
	
	    public FieldModifierSyntax WithFieldModifier(SyntaxToken fieldModifier)
		{
			return this.Update(FieldModifier);
		}
	
	    public FieldModifierSyntax Update(SyntaxToken fieldModifier)
	    {
	        if (this.FieldModifier != fieldModifier)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.FieldModifier(fieldModifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldModifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldModifier(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldModifier(this);
	    }
	}
	
	public sealed class DefaultValueSyntax : MetaSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public DefaultValueSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DefaultValueSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.DefaultValueGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public StringLiteralSyntax StringLiteral 
		{ 
			get { return this.GetRed(ref this.stringLiteral, 1); } 
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
	
	    public DefaultValueSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(TAssign, this.StringLiteral);
		}
	
	    public DefaultValueSyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(this.TAssign, StringLiteral);
		}
	
	    public DefaultValueSyntax Update(SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
	    {
	        if (this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.DefaultValue(tAssign, stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefaultValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDefaultValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDefaultValue(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitDefaultValue(this);
	    }
	}
	
	public sealed class RedefinitionsOrSubsettingsSyntax : MetaSyntaxNode
	{
	    private RedefinitionsSyntax redefinitions;
	    private SubsettingsSyntax subsettings;
	
	    public RedefinitionsOrSubsettingsSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RedefinitionsOrSubsettingsSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.RedefinitionsOrSubsettings(redefinitions);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.RedefinitionsOrSubsettings(subsettings);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RedefinitionsOrSubsettingsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRedefinitionsOrSubsettings(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRedefinitionsOrSubsettings(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitRedefinitionsOrSubsettings(this);
	    }
	}
	
	public sealed class RedefinitionsSyntax : MetaSyntaxNode
	{
	    private NameUseListSyntax nameUseList;
	
	    public RedefinitionsSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RedefinitionsSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KRedefines 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.RedefinitionsGreen)this.Green;
				var greenToken = green.KRedefines;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Redefinitions(kRedefines, nameUseList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RedefinitionsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRedefinitions(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRedefinitions(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitRedefinitions(this);
	    }
	}
	
	public sealed class SubsettingsSyntax : MetaSyntaxNode
	{
	    private NameUseListSyntax nameUseList;
	
	    public SubsettingsSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SubsettingsSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KSubsets 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.SubsettingsGreen)this.Green;
				var greenToken = green.KSubsets;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Subsettings(kSubsets, nameUseList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SubsettingsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSubsettings(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSubsettings(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitSubsettings(this);
	    }
	}
	
	public sealed class NameUseListSyntax : MetaSyntaxNode
	{
	    private SyntaxNode qualifier;
	
	    public NameUseListSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameUseListSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<QualifierSyntax> Qualifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.qualifier, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<QualifierSyntax>(red, this.GetChildIndex(0));
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
	
	    public NameUseListSyntax WithQualifier(Microsoft.CodeAnalysis.SeparatedSyntaxList<QualifierSyntax> qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public NameUseListSyntax AddQualifier(params QualifierSyntax[] qualifier)
		{
			return this.WithQualifier(this.Qualifier.AddRange(qualifier));
		}
	
	    public NameUseListSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<QualifierSyntax> qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.NameUseList(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameUseListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNameUseList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNameUseList(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitNameUseList(this);
	    }
	}
	
	public sealed class ConstDeclarationSyntax : MetaSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	    private ConstValueSyntax constValue;
	
	    public ConstDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ConstDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KConst 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ConstDeclarationGreen)this.Green;
				var greenToken = green.KConst;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
	    public ConstValueSyntax ConstValue 
		{ 
			get { return this.GetRed(ref this.constValue, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ConstDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 2: return this.GetRed(ref this.name, 2);
				case 3: return this.GetRed(ref this.constValue, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.typeReference;
				case 2: return this.name;
				case 3: return this.constValue;
				default: return null;
	        }
	    }
	
	    public ConstDeclarationSyntax WithKConst(SyntaxToken kConst)
		{
			return this.Update(KConst, this.TypeReference, this.Name, this.ConstValue, this.TSemicolon);
		}
	
	    public ConstDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KConst, TypeReference, this.Name, this.ConstValue, this.TSemicolon);
		}
	
	    public ConstDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KConst, this.TypeReference, Name, this.ConstValue, this.TSemicolon);
		}
	
	    public ConstDeclarationSyntax WithConstValue(ConstValueSyntax constValue)
		{
			return this.Update(this.KConst, this.TypeReference, this.Name, ConstValue, this.TSemicolon);
		}
	
	    public ConstDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KConst, this.TypeReference, this.Name, this.ConstValue, TSemicolon);
		}
	
	    public ConstDeclarationSyntax Update(SyntaxToken kConst, TypeReferenceSyntax typeReference, NameSyntax name, ConstValueSyntax constValue, SyntaxToken tSemicolon)
	    {
	        if (this.KConst != kConst ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.ConstValue != constValue ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ConstDeclaration(kConst, typeReference, name, constValue, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConstDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitConstDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitConstDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitConstDeclaration(this);
	    }
	}
	
	public sealed class ConstValueSyntax : MetaSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public ConstValueSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ConstValueSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ConstValueGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public StringLiteralSyntax StringLiteral 
		{ 
			get { return this.GetRed(ref this.stringLiteral, 1); } 
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
	
	    public ConstValueSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(TAssign, this.StringLiteral);
		}
	
	    public ConstValueSyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(this.TAssign, StringLiteral);
		}
	
	    public ConstValueSyntax Update(SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
	    {
	        if (this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ConstValue(tAssign, stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConstValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitConstValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitConstValue(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitConstValue(this);
	    }
	}
	
	public sealed class ReturnTypeSyntax : MetaSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private VoidTypeSyntax voidType;
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ReturnType(typeReference);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ReturnType(voidType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitReturnType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReturnType(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitReturnType(this);
	    }
	}
	
	public sealed class TypeOfReferenceSyntax : MetaSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	
	    public TypeOfReferenceSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeOfReferenceSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.TypeOfReference(typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeOfReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeOfReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeOfReference(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeOfReference(this);
	    }
	}
	
	public sealed class TypeReferenceSyntax : MetaSyntaxNode
	{
	    private CollectionTypeSyntax collectionType;
	    private SimpleTypeSyntax simpleType;
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.TypeReference(collectionType);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.TypeReference(simpleType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeReference(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeReference(this);
	    }
	}
	
	public sealed class SimpleTypeSyntax : MetaSyntaxNode
	{
	    private PrimitiveTypeSyntax primitiveType;
	    private ObjectTypeSyntax objectType;
	    private NullableTypeSyntax nullableType;
	    private ClassTypeSyntax classType;
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	    public ClassTypeSyntax ClassType 
		{ 
			get { return this.GetRed(ref this.classType, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.primitiveType, 0);
				case 1: return this.GetRed(ref this.objectType, 1);
				case 2: return this.GetRed(ref this.nullableType, 2);
				case 3: return this.GetRed(ref this.classType, 3);
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
				case 3: return this.classType;
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
	
	    public SimpleTypeSyntax WithClassType(ClassTypeSyntax classType)
		{
			return this.Update(classType);
		}
	
	    public SimpleTypeSyntax Update(PrimitiveTypeSyntax primitiveType)
	    {
	        if (this.PrimitiveType != primitiveType)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.SimpleType(primitiveType);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.SimpleType(objectType);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.SimpleType(nullableType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SimpleTypeSyntax Update(ClassTypeSyntax classType)
	    {
	        if (this.ClassType != classType)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.SimpleType(classType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleType(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleType(this);
	    }
	}
	
	public sealed class ClassTypeSyntax : MetaSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public ClassTypeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassTypeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ClassType(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassType(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitClassType(this);
	    }
	}
	
	public sealed class ObjectTypeSyntax : MetaSyntaxNode
	{
	
	    public ObjectTypeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ObjectTypeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ObjectType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ObjectTypeGreen)this.Green;
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ObjectType(objectType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitObjectType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitObjectType(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitObjectType(this);
	    }
	}
	
	public sealed class PrimitiveTypeSyntax : MetaSyntaxNode
	{
	
	    public PrimitiveTypeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PrimitiveTypeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken PrimitiveType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.PrimitiveTypeGreen)this.Green;
				var greenToken = green.PrimitiveType;
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
	
	    public PrimitiveTypeSyntax WithPrimitiveType(SyntaxToken primitiveType)
		{
			return this.Update(PrimitiveType);
		}
	
	    public PrimitiveTypeSyntax Update(SyntaxToken primitiveType)
	    {
	        if (this.PrimitiveType != primitiveType)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.PrimitiveType(primitiveType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PrimitiveTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPrimitiveType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPrimitiveType(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitPrimitiveType(this);
	    }
	}
	
	public sealed class VoidTypeSyntax : MetaSyntaxNode
	{
	
	    public VoidTypeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VoidTypeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVoid 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.VoidTypeGreen)this.Green;
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.VoidType(kVoid);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VoidTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVoidType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVoidType(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitVoidType(this);
	    }
	}
	
	public sealed class NullableTypeSyntax : MetaSyntaxNode
	{
	    private PrimitiveTypeSyntax primitiveType;
	
	    public NullableTypeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullableTypeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.NullableType(primitiveType, tQuestion);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullableType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullableType(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitNullableType(this);
	    }
	}
	
	public sealed class CollectionTypeSyntax : MetaSyntaxNode
	{
	    private CollectionKindSyntax collectionKind;
	    private SimpleTypeSyntax simpleType;
	
	    public CollectionTypeSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CollectionTypeSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.CollectionType(collectionKind, tLessThan, simpleType, tGreaterThan);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CollectionTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCollectionType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCollectionType(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitCollectionType(this);
	    }
	}
	
	public sealed class CollectionKindSyntax : MetaSyntaxNode
	{
	
	    public CollectionKindSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CollectionKindSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken CollectionKind 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.CollectionKindGreen)this.Green;
				var greenToken = green.CollectionKind;
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
	
	    public CollectionKindSyntax WithCollectionKind(SyntaxToken collectionKind)
		{
			return this.Update(CollectionKind);
		}
	
	    public CollectionKindSyntax Update(SyntaxToken collectionKind)
	    {
	        if (this.CollectionKind != collectionKind)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.CollectionKind(collectionKind);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CollectionKindSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCollectionKind(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCollectionKind(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitCollectionKind(this);
	    }
	}
	
	public sealed class OperationDeclarationSyntax : MetaSyntaxNode
	{
	    private SyntaxNode attribute;
	    private SyntaxNode operationModifier;
	    private ReturnTypeSyntax returnType;
	    private NameSyntax name;
	    private ParameterListSyntax parameterList;
	
	    public OperationDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public Microsoft.CodeAnalysis.SyntaxList<OperationModifierSyntax> OperationModifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.operationModifier, 1);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<OperationModifierSyntax>(red);
				return default;
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(7), this.GetChildIndex(7));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.operationModifier, 1);
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
				case 0: return this.attribute;
				case 1: return this.operationModifier;
				case 2: return this.returnType;
				case 3: return this.name;
				case 5: return this.parameterList;
				default: return null;
	        }
	    }
	
	    public OperationDeclarationSyntax WithAttribute(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.OperationModifier, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public OperationDeclarationSyntax WithOperationModifier(Microsoft.CodeAnalysis.SyntaxList<OperationModifierSyntax> operationModifier)
		{
			return this.Update(this.Attribute, OperationModifier, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax AddOperationModifier(params OperationModifierSyntax[] operationModifier)
		{
			return this.WithOperationModifier(this.OperationModifier.AddRange(operationModifier));
		}
	
	    public OperationDeclarationSyntax WithReturnType(ReturnTypeSyntax returnType)
		{
			return this.Update(this.Attribute, this.OperationModifier, ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.OperationModifier, this.ReturnType, Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Attribute, this.OperationModifier, this.ReturnType, this.Name, TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithParameterList(ParameterListSyntax parameterList)
		{
			return this.Update(this.Attribute, this.OperationModifier, this.ReturnType, this.Name, this.TOpenParen, ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Attribute, this.OperationModifier, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.OperationModifier, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, TSemicolon);
		}
	
	    public OperationDeclarationSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, Microsoft.CodeAnalysis.SyntaxList<OperationModifierSyntax> operationModifier, ReturnTypeSyntax returnType, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.OperationModifier != operationModifier ||
				this.ReturnType != returnType ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.ParameterList != parameterList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.OperationDeclaration(attribute, operationModifier, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOperationDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationDeclaration(this);
	    }
	}
	
	public sealed class OperationModifierSyntax : MetaSyntaxNode
	{
	    private OperationModifierBuilderSyntax operationModifierBuilder;
	    private OperationModifierReadonlySyntax operationModifierReadonly;
	
	    public OperationModifierSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationModifierSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public OperationModifierBuilderSyntax OperationModifierBuilder 
		{ 
			get { return this.GetRed(ref this.operationModifierBuilder, 0); } 
		}
	    public OperationModifierReadonlySyntax OperationModifierReadonly 
		{ 
			get { return this.GetRed(ref this.operationModifierReadonly, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.operationModifierBuilder, 0);
				case 1: return this.GetRed(ref this.operationModifierReadonly, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.operationModifierBuilder;
				case 1: return this.operationModifierReadonly;
				default: return null;
	        }
	    }
	
	    public OperationModifierSyntax WithOperationModifierBuilder(OperationModifierBuilderSyntax operationModifierBuilder)
		{
			return this.Update(operationModifierBuilder);
		}
	
	    public OperationModifierSyntax WithOperationModifierReadonly(OperationModifierReadonlySyntax operationModifierReadonly)
		{
			return this.Update(operationModifierReadonly);
		}
	
	    public OperationModifierSyntax Update(OperationModifierBuilderSyntax operationModifierBuilder)
	    {
	        if (this.OperationModifierBuilder != operationModifierBuilder)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.OperationModifier(operationModifierBuilder);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public OperationModifierSyntax Update(OperationModifierReadonlySyntax operationModifierReadonly)
	    {
	        if (this.OperationModifierReadonly != operationModifierReadonly)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.OperationModifier(operationModifierReadonly);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOperationModifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationModifier(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationModifier(this);
	    }
	}
	
	public sealed class OperationModifierBuilderSyntax : MetaSyntaxNode
	{
	
	    public OperationModifierBuilderSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationModifierBuilderSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KBuilder 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.OperationModifierBuilderGreen)this.Green;
				var greenToken = green.KBuilder;
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
	
	    public OperationModifierBuilderSyntax WithKBuilder(SyntaxToken kBuilder)
		{
			return this.Update(KBuilder);
		}
	
	    public OperationModifierBuilderSyntax Update(SyntaxToken kBuilder)
	    {
	        if (this.KBuilder != kBuilder)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.OperationModifierBuilder(kBuilder);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationModifierBuilderSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOperationModifierBuilder(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationModifierBuilder(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationModifierBuilder(this);
	    }
	}
	
	public sealed class OperationModifierReadonlySyntax : MetaSyntaxNode
	{
	
	    public OperationModifierReadonlySyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationModifierReadonlySyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KReadonly 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.OperationModifierReadonlyGreen)this.Green;
				var greenToken = green.KReadonly;
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
	
	    public OperationModifierReadonlySyntax WithKReadonly(SyntaxToken kReadonly)
		{
			return this.Update(KReadonly);
		}
	
	    public OperationModifierReadonlySyntax Update(SyntaxToken kReadonly)
	    {
	        if (this.KReadonly != kReadonly)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.OperationModifierReadonly(kReadonly);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationModifierReadonlySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOperationModifierReadonly(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationModifierReadonly(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationModifierReadonly(this);
	    }
	}
	
	public sealed class ParameterListSyntax : MetaSyntaxNode
	{
	    private SyntaxNode parameter;
	
	    public ParameterListSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParameterListSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<ParameterSyntax> Parameter 
		{ 
			get
			{
				var red = this.GetRed(ref this.parameter, 0);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<ParameterSyntax>(red, this.GetChildIndex(0));
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
	
	    public ParameterListSyntax WithParameter(Microsoft.CodeAnalysis.SeparatedSyntaxList<ParameterSyntax> parameter)
		{
			return this.Update(Parameter);
		}
	
	    public ParameterListSyntax AddParameter(params ParameterSyntax[] parameter)
		{
			return this.WithParameter(this.Parameter.AddRange(parameter));
		}
	
	    public ParameterListSyntax Update(Microsoft.CodeAnalysis.SeparatedSyntaxList<ParameterSyntax> parameter)
	    {
	        if (this.Parameter != parameter)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ParameterList(parameter);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParameterList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParameterList(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitParameterList(this);
	    }
	}
	
	public sealed class ParameterSyntax : MetaSyntaxNode
	{
	    private SyntaxNode attribute;
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	
	    public ParameterSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParameterSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax>(red);
				return default;
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
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 2: return this.GetRed(ref this.name, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 1: return this.typeReference;
				case 2: return this.name;
				default: return null;
	        }
	    }
	
	    public ParameterSyntax WithAttribute(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.TypeReference, this.Name);
		}
	
	    public ParameterSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public ParameterSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Attribute, TypeReference, this.Name);
		}
	
	    public ParameterSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.TypeReference, Name);
		}
	
	    public ParameterSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, TypeReferenceSyntax typeReference, NameSyntax name)
	    {
	        if (this.Attribute != attribute ||
				this.TypeReference != typeReference ||
				this.Name != name)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Parameter(attribute, typeReference, name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParameter(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParameter(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitParameter(this);
	    }
	}
	
	public sealed class AssociationDeclarationSyntax : MetaSyntaxNode
	{
	    private SyntaxNode attribute;
	    private QualifierSyntax source;
	    private QualifierSyntax target;
	
	    public AssociationDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssociationDeclarationSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KAssociation 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.AssociationDeclarationGreen)this.Green;
				var greenToken = green.KAssociation;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 2: return this.GetRed(ref this.source, 2);
				case 4: return this.GetRed(ref this.target, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 2: return this.source;
				case 4: return this.target;
				default: return null;
	        }
	    }
	
	    public AssociationDeclarationSyntax WithAttribute(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.KAssociation, this.Source, this.KWith, this.Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public AssociationDeclarationSyntax WithKAssociation(SyntaxToken kAssociation)
		{
			return this.Update(this.Attribute, KAssociation, this.Source, this.KWith, this.Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax WithSource(QualifierSyntax source)
		{
			return this.Update(this.Attribute, this.KAssociation, Source, this.KWith, this.Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax WithKWith(SyntaxToken kWith)
		{
			return this.Update(this.Attribute, this.KAssociation, this.Source, KWith, this.Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax WithTarget(QualifierSyntax target)
		{
			return this.Update(this.Attribute, this.KAssociation, this.Source, this.KWith, Target, this.TSemicolon);
		}
	
	    public AssociationDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.KAssociation, this.Source, this.KWith, this.Target, TSemicolon);
		}
	
	    public AssociationDeclarationSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SyntaxToken kAssociation, QualifierSyntax source, SyntaxToken kWith, QualifierSyntax target, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.KAssociation != kAssociation ||
				this.Source != source ||
				this.KWith != kWith ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.AssociationDeclaration(attribute, kAssociation, source, kWith, target, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssociationDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAssociationDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssociationDeclaration(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitAssociationDeclaration(this);
	    }
	}
	
	public sealed class IdentifierSyntax : MetaSyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Identifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.IdentifierGreen)this.Green;
				var greenToken = green.Identifier;
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
	
	    public IdentifierSyntax WithIdentifier(SyntaxToken identifier)
		{
			return this.Update(Identifier);
		}
	
	    public IdentifierSyntax Update(SyntaxToken identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Identifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class LiteralSyntax : MetaSyntaxNode
	{
	    private NullLiteralSyntax nullLiteral;
	    private BooleanLiteralSyntax booleanLiteral;
	    private IntegerLiteralSyntax integerLiteral;
	    private DecimalLiteralSyntax decimalLiteral;
	    private ScientificLiteralSyntax scientificLiteral;
	    private StringLiteralSyntax stringLiteral;
	
	    public LiteralSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Literal(nullLiteral);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Literal(booleanLiteral);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Literal(integerLiteral);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Literal(decimalLiteral);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Literal(scientificLiteral);
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.Literal(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteral(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteral(this);
	    }
	}
	
	public sealed class NullLiteralSyntax : MetaSyntaxNode
	{
	
	    public NullLiteralSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullLiteralSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNull 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.NullLiteralGreen)this.Green;
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.NullLiteral(kNull);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullLiteral(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitNullLiteral(this);
	    }
	}
	
	public sealed class BooleanLiteralSyntax : MetaSyntaxNode
	{
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BooleanLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.BooleanLiteralGreen)this.Green;
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.BooleanLiteral(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BooleanLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBooleanLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBooleanLiteral(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitBooleanLiteral(this);
	    }
	}
	
	public sealed class IntegerLiteralSyntax : MetaSyntaxNode
	{
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LInteger 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.IntegerLiteralGreen)this.Green;
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.IntegerLiteral(lInteger);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIntegerLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIntegerLiteral(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitIntegerLiteral(this);
	    }
	}
	
	public sealed class DecimalLiteralSyntax : MetaSyntaxNode
	{
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LDecimal 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.DecimalLiteralGreen)this.Green;
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.DecimalLiteral(lDecimal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DecimalLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDecimalLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDecimalLiteral(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitDecimalLiteral(this);
	    }
	}
	
	public sealed class ScientificLiteralSyntax : MetaSyntaxNode
	{
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LScientific 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.ScientificLiteralGreen)this.Green;
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
	            var newNode = MetaLanguage.Instance.SyntaxFactory.ScientificLiteral(lScientific);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ScientificLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitScientificLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitScientificLiteral(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitScientificLiteral(this);
	    }
	}
	
	public sealed class StringLiteralSyntax : MetaSyntaxNode
	{
	
	    public StringLiteralSyntax(InternalSyntaxNode green, MetaSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringLiteralSyntax(InternalSyntaxNode green, MetaSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LRegularString 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Meta.Syntax.InternalSyntax.StringLiteralGreen)this.Green;
				var greenToken = green.LRegularString;
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
	
	    public StringLiteralSyntax WithLRegularString(SyntaxToken lRegularString)
		{
			return this.Update(LRegularString);
		}
	
	    public StringLiteralSyntax Update(SyntaxToken lRegularString)
	    {
	        if (this.LRegularString != lRegularString)
	        {
	            var newNode = MetaLanguage.Instance.SyntaxFactory.StringLiteral(lRegularString);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStringLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStringLiteral(this);
	    }
	
	    public override void Accept(IMetaSyntaxVisitor visitor)
	    {
	        visitor.VisitStringLiteral(this);
	    }
	}
}

namespace MetaDslx.Languages.Meta
{
    using System.Threading;
    using Microsoft.CodeAnalysis.Text;
	using MetaDslx.Languages.Meta.Syntax;
    using MetaDslx.Languages.Meta.Syntax.InternalSyntax;

	public interface IMetaSyntaxVisitor
	{
	    void VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node);
		
		void VisitMain(MainSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitAttribute(AttributeSyntax node);
		
		void VisitUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax node);
		
		void VisitUsingNamespace(UsingNamespaceSyntax node);
		
		void VisitUsingMetamodel(UsingMetamodelSyntax node);
		
		void VisitUsingMetamodelReference(UsingMetamodelReferenceSyntax node);
		
		void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		void VisitNamespaceBody(NamespaceBodySyntax node);
		
		void VisitMetamodelDeclaration(MetamodelDeclarationSyntax node);
		
		void VisitMetamodelPropertyList(MetamodelPropertyListSyntax node);
		
		void VisitMetamodelProperty(MetamodelPropertySyntax node);
		
		void VisitMetamodelUriProperty(MetamodelUriPropertySyntax node);
		
		void VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node);
		
		void VisitMajorVersionProperty(MajorVersionPropertySyntax node);
		
		void VisitMinorVersionProperty(MinorVersionPropertySyntax node);
		
		void VisitDeclaration(DeclarationSyntax node);
		
		void VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		void VisitEnumBody(EnumBodySyntax node);
		
		void VisitEnumValues(EnumValuesSyntax node);
		
		void VisitEnumValue(EnumValueSyntax node);
		
		void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node);
		
		void VisitClassDeclaration(ClassDeclarationSyntax node);
		
		void VisitSymbolAttribute(SymbolAttributeSyntax node);
		
		void VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax node);
		
		void VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax node);
		
		void VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax node);
		
		void VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax node);
		
		void VisitClassBody(ClassBodySyntax node);
		
		void VisitClassAncestors(ClassAncestorsSyntax node);
		
		void VisitClassAncestor(ClassAncestorSyntax node);
		
		void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node);
		
		void VisitFieldDeclaration(FieldDeclarationSyntax node);
		
		void VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax node);
		
		void VisitFieldContainment(FieldContainmentSyntax node);
		
		void VisitFieldModifier(FieldModifierSyntax node);
		
		void VisitDefaultValue(DefaultValueSyntax node);
		
		void VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node);
		
		void VisitRedefinitions(RedefinitionsSyntax node);
		
		void VisitSubsettings(SubsettingsSyntax node);
		
		void VisitNameUseList(NameUseListSyntax node);
		
		void VisitConstDeclaration(ConstDeclarationSyntax node);
		
		void VisitConstValue(ConstValueSyntax node);
		
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
		
		void VisitOperationModifier(OperationModifierSyntax node);
		
		void VisitOperationModifierBuilder(OperationModifierBuilderSyntax node);
		
		void VisitOperationModifierReadonly(OperationModifierReadonlySyntax node);
		
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
	
	public class MetaSyntaxVisitor : SyntaxVisitor, IMetaSyntaxVisitor
	{
	    public virtual void VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node)
	    {
	        this.DefaultVisit(node);
	    }
		
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
		
		public virtual void VisitAttribute(AttributeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUsingNamespace(UsingNamespaceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUsingMetamodel(UsingMetamodelSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUsingMetamodelReference(UsingMetamodelReferenceSyntax node)
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
		
		public virtual void VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMajorVersionProperty(MajorVersionPropertySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMinorVersionProperty(MinorVersionPropertySyntax node)
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
		
		public virtual void VisitSymbolAttribute(SymbolAttributeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax node)
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
		
		public virtual void VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFieldContainment(FieldContainmentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFieldModifier(FieldModifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDefaultValue(DefaultValueSyntax node)
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
		
		public virtual void VisitConstValue(ConstValueSyntax node)
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
		
		public virtual void VisitOperationModifier(OperationModifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOperationModifierBuilder(OperationModifierBuilderSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOperationModifierReadonly(OperationModifierReadonlySyntax node)
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

	//GenerateDetailedSyntaxVisitor()

	public interface IMetaSyntaxVisitor<TArg, TResult> 
	{
	    TResult VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node, TArg argument);
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitName(NameSyntax node, TArg argument);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument);
		
		TResult VisitQualifier(QualifierSyntax node, TArg argument);
		
		TResult VisitAttribute(AttributeSyntax node, TArg argument);
		
		TResult VisitUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax node, TArg argument);
		
		TResult VisitUsingNamespace(UsingNamespaceSyntax node, TArg argument);
		
		TResult VisitUsingMetamodel(UsingMetamodelSyntax node, TArg argument);
		
		TResult VisitUsingMetamodelReference(UsingMetamodelReferenceSyntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node, TArg argument);
		
		TResult VisitMetamodelDeclaration(MetamodelDeclarationSyntax node, TArg argument);
		
		TResult VisitMetamodelPropertyList(MetamodelPropertyListSyntax node, TArg argument);
		
		TResult VisitMetamodelProperty(MetamodelPropertySyntax node, TArg argument);
		
		TResult VisitMetamodelUriProperty(MetamodelUriPropertySyntax node, TArg argument);
		
		TResult VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node, TArg argument);
		
		TResult VisitMajorVersionProperty(MajorVersionPropertySyntax node, TArg argument);
		
		TResult VisitMinorVersionProperty(MinorVersionPropertySyntax node, TArg argument);
		
		TResult VisitDeclaration(DeclarationSyntax node, TArg argument);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node, TArg argument);
		
		TResult VisitEnumBody(EnumBodySyntax node, TArg argument);
		
		TResult VisitEnumValues(EnumValuesSyntax node, TArg argument);
		
		TResult VisitEnumValue(EnumValueSyntax node, TArg argument);
		
		TResult VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node, TArg argument);
		
		TResult VisitClassDeclaration(ClassDeclarationSyntax node, TArg argument);
		
		TResult VisitSymbolAttribute(SymbolAttributeSyntax node, TArg argument);
		
		TResult VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax node, TArg argument);
		
		TResult VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax node, TArg argument);
		
		TResult VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax node, TArg argument);
		
		TResult VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax node, TArg argument);
		
		TResult VisitClassBody(ClassBodySyntax node, TArg argument);
		
		TResult VisitClassAncestors(ClassAncestorsSyntax node, TArg argument);
		
		TResult VisitClassAncestor(ClassAncestorSyntax node, TArg argument);
		
		TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node, TArg argument);
		
		TResult VisitFieldDeclaration(FieldDeclarationSyntax node, TArg argument);
		
		TResult VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax node, TArg argument);
		
		TResult VisitFieldContainment(FieldContainmentSyntax node, TArg argument);
		
		TResult VisitFieldModifier(FieldModifierSyntax node, TArg argument);
		
		TResult VisitDefaultValue(DefaultValueSyntax node, TArg argument);
		
		TResult VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node, TArg argument);
		
		TResult VisitRedefinitions(RedefinitionsSyntax node, TArg argument);
		
		TResult VisitSubsettings(SubsettingsSyntax node, TArg argument);
		
		TResult VisitNameUseList(NameUseListSyntax node, TArg argument);
		
		TResult VisitConstDeclaration(ConstDeclarationSyntax node, TArg argument);
		
		TResult VisitConstValue(ConstValueSyntax node, TArg argument);
		
		TResult VisitReturnType(ReturnTypeSyntax node, TArg argument);
		
		TResult VisitTypeOfReference(TypeOfReferenceSyntax node, TArg argument);
		
		TResult VisitTypeReference(TypeReferenceSyntax node, TArg argument);
		
		TResult VisitSimpleType(SimpleTypeSyntax node, TArg argument);
		
		TResult VisitClassType(ClassTypeSyntax node, TArg argument);
		
		TResult VisitObjectType(ObjectTypeSyntax node, TArg argument);
		
		TResult VisitPrimitiveType(PrimitiveTypeSyntax node, TArg argument);
		
		TResult VisitVoidType(VoidTypeSyntax node, TArg argument);
		
		TResult VisitNullableType(NullableTypeSyntax node, TArg argument);
		
		TResult VisitCollectionType(CollectionTypeSyntax node, TArg argument);
		
		TResult VisitCollectionKind(CollectionKindSyntax node, TArg argument);
		
		TResult VisitOperationDeclaration(OperationDeclarationSyntax node, TArg argument);
		
		TResult VisitOperationModifier(OperationModifierSyntax node, TArg argument);
		
		TResult VisitOperationModifierBuilder(OperationModifierBuilderSyntax node, TArg argument);
		
		TResult VisitOperationModifierReadonly(OperationModifierReadonlySyntax node, TArg argument);
		
		TResult VisitParameterList(ParameterListSyntax node, TArg argument);
		
		TResult VisitParameter(ParameterSyntax node, TArg argument);
		
		TResult VisitAssociationDeclaration(AssociationDeclarationSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
		TResult VisitLiteral(LiteralSyntax node, TArg argument);
		
		TResult VisitNullLiteral(NullLiteralSyntax node, TArg argument);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node, TArg argument);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node, TArg argument);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node, TArg argument);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node, TArg argument);
		
		TResult VisitStringLiteral(StringLiteralSyntax node, TArg argument);
	}
	
	public class MetaSyntaxVisitor<TArg, TResult> : SyntaxVisitor<TArg, TResult>, IMetaSyntaxVisitor<TArg, TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node, TArg argument)
	    {
	        return this.DefaultVisit(node, argument);
	    }
		
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
		
		public virtual TResult VisitAttribute(AttributeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUsingNamespace(UsingNamespaceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUsingMetamodel(UsingMetamodelSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUsingMetamodelReference(UsingMetamodelReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody(NamespaceBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMetamodelDeclaration(MetamodelDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMetamodelPropertyList(MetamodelPropertyListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMetamodelProperty(MetamodelPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMetamodelUriProperty(MetamodelUriPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMajorVersionProperty(MajorVersionPropertySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMinorVersionProperty(MinorVersionPropertySyntax node, TArg argument)
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
		
		public virtual TResult VisitEnumBody(EnumBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnumValues(EnumValuesSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnumValue(EnumValueSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassDeclaration(ClassDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSymbolAttribute(SymbolAttributeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassBody(ClassBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassAncestors(ClassAncestorsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassAncestor(ClassAncestorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFieldDeclaration(FieldDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFieldContainment(FieldContainmentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFieldModifier(FieldModifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDefaultValue(DefaultValueSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRedefinitions(RedefinitionsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSubsettings(SubsettingsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNameUseList(NameUseListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitConstDeclaration(ConstDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitConstValue(ConstValueSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitReturnType(ReturnTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeOfReference(TypeOfReferenceSyntax node, TArg argument)
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
		
		public virtual TResult VisitClassType(ClassTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitObjectType(ObjectTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPrimitiveType(PrimitiveTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVoidType(VoidTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNullableType(NullableTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCollectionType(CollectionTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCollectionKind(CollectionKindSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOperationDeclaration(OperationDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOperationModifier(OperationModifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOperationModifierBuilder(OperationModifierBuilderSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOperationModifierReadonly(OperationModifierReadonlySyntax node, TArg argument)
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
		
		public virtual TResult VisitAssociationDeclaration(AssociationDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node, TArg argument)
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
	}

	public interface IMetaSyntaxVisitor<TResult> 
	{
	    TResult VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node);
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitAttribute(AttributeSyntax node);
		
		TResult VisitUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax node);
		
		TResult VisitUsingNamespace(UsingNamespaceSyntax node);
		
		TResult VisitUsingMetamodel(UsingMetamodelSyntax node);
		
		TResult VisitUsingMetamodelReference(UsingMetamodelReferenceSyntax node);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node);
		
		TResult VisitMetamodelDeclaration(MetamodelDeclarationSyntax node);
		
		TResult VisitMetamodelPropertyList(MetamodelPropertyListSyntax node);
		
		TResult VisitMetamodelProperty(MetamodelPropertySyntax node);
		
		TResult VisitMetamodelUriProperty(MetamodelUriPropertySyntax node);
		
		TResult VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node);
		
		TResult VisitMajorVersionProperty(MajorVersionPropertySyntax node);
		
		TResult VisitMinorVersionProperty(MinorVersionPropertySyntax node);
		
		TResult VisitDeclaration(DeclarationSyntax node);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		TResult VisitEnumBody(EnumBodySyntax node);
		
		TResult VisitEnumValues(EnumValuesSyntax node);
		
		TResult VisitEnumValue(EnumValueSyntax node);
		
		TResult VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node);
		
		TResult VisitClassDeclaration(ClassDeclarationSyntax node);
		
		TResult VisitSymbolAttribute(SymbolAttributeSyntax node);
		
		TResult VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax node);
		
		TResult VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax node);
		
		TResult VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax node);
		
		TResult VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax node);
		
		TResult VisitClassBody(ClassBodySyntax node);
		
		TResult VisitClassAncestors(ClassAncestorsSyntax node);
		
		TResult VisitClassAncestor(ClassAncestorSyntax node);
		
		TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node);
		
		TResult VisitFieldDeclaration(FieldDeclarationSyntax node);
		
		TResult VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax node);
		
		TResult VisitFieldContainment(FieldContainmentSyntax node);
		
		TResult VisitFieldModifier(FieldModifierSyntax node);
		
		TResult VisitDefaultValue(DefaultValueSyntax node);
		
		TResult VisitRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node);
		
		TResult VisitRedefinitions(RedefinitionsSyntax node);
		
		TResult VisitSubsettings(SubsettingsSyntax node);
		
		TResult VisitNameUseList(NameUseListSyntax node);
		
		TResult VisitConstDeclaration(ConstDeclarationSyntax node);
		
		TResult VisitConstValue(ConstValueSyntax node);
		
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
		
		TResult VisitOperationModifier(OperationModifierSyntax node);
		
		TResult VisitOperationModifierBuilder(OperationModifierBuilderSyntax node);
		
		TResult VisitOperationModifierReadonly(OperationModifierReadonlySyntax node);
		
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
	
	public class MetaSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, IMetaSyntaxVisitor<TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node)
	    {
	        return this.DefaultVisit(node);
	    }
		
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
		
		public virtual TResult VisitAttribute(AttributeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUsingNamespace(UsingNamespaceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUsingMetamodel(UsingMetamodelSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUsingMetamodelReference(UsingMetamodelReferenceSyntax node)
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
		
		public virtual TResult VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMajorVersionProperty(MajorVersionPropertySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMinorVersionProperty(MinorVersionPropertySyntax node)
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
		
		public virtual TResult VisitSymbolAttribute(SymbolAttributeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax node)
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
		
		public virtual TResult VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFieldContainment(FieldContainmentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFieldModifier(FieldModifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDefaultValue(DefaultValueSyntax node)
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
		
		public virtual TResult VisitConstValue(ConstValueSyntax node)
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
		
		public virtual TResult VisitOperationModifier(OperationModifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOperationModifierBuilder(OperationModifierBuilderSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOperationModifierReadonly(OperationModifierReadonlySyntax node)
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

	public class MetaSyntaxRewriter : SyntaxRewriter, IMetaSyntaxVisitor<SyntaxNode>
	{
	    public MetaSyntaxRewriter(bool visitIntoStructuredTrivia = false)
			: base(MetaLanguage.Instance, visitIntoStructuredTrivia)
	    {
	    }
	
	    public virtual SyntaxNode VisitSkippedTokensTrivia(MetaSkippedTokensTriviaSyntax node)
	    {
	      var tokens = this.VisitList(node.Tokens);
	      return node.Update(tokens);
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var usingNamespaceOrMetamodel = this.VisitList(node.UsingNamespaceOrMetamodel);
		    var namespaceDeclaration = (NamespaceDeclarationSyntax)this.Visit(node.NamespaceDeclaration);
		    var eOF = this.VisitToken(node.EndOfFileToken);
			return node.Update(usingNamespaceOrMetamodel, namespaceDeclaration, eOF);
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
		
		public virtual SyntaxNode VisitAttribute(AttributeSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, qualifier, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax node)
		{
			var oldUsingNamespace = node.UsingNamespace;
			if (oldUsingNamespace != null)
			{
			    var newUsingNamespace = (UsingNamespaceSyntax)this.Visit(oldUsingNamespace);
				return node.Update(newUsingNamespace);
			}
			var oldUsingMetamodel = node.UsingMetamodel;
			if (oldUsingMetamodel != null)
			{
			    var newUsingMetamodel = (UsingMetamodelSyntax)this.Visit(oldUsingMetamodel);
				return node.Update(newUsingMetamodel);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitUsingNamespace(UsingNamespaceSyntax node)
		{
		    var kUsing = this.VisitToken(node.KUsing);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tAssign = this.VisitToken(node.TAssign);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kUsing, name, tAssign, qualifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitUsingMetamodel(UsingMetamodelSyntax node)
		{
		    var kUsing = this.VisitToken(node.KUsing);
		    var kMetamodel = this.VisitToken(node.KMetamodel);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tAssign = this.VisitToken(node.TAssign);
		    var usingMetamodelReference = (UsingMetamodelReferenceSyntax)this.Visit(node.UsingMetamodelReference);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kUsing, kMetamodel, name, tAssign, usingMetamodelReference, tSemicolon);
		}
		
		public virtual SyntaxNode VisitUsingMetamodelReference(UsingMetamodelReferenceSyntax node)
		{
			var oldQualifier = node.Qualifier;
			if (oldQualifier != null)
			{
			    var newQualifier = (QualifierSyntax)this.Visit(oldQualifier);
				return node.Update(newQualifier);
			}
			var oldStringLiteral = node.StringLiteral;
			if (oldStringLiteral != null)
			{
			    var newStringLiteral = (StringLiteralSyntax)this.Visit(oldStringLiteral);
				return node.Update(newStringLiteral);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody = (NamespaceBodySyntax)this.Visit(node.NamespaceBody);
			return node.Update(attribute, kNamespace, qualifiedName, namespaceBody);
		}
		
		public virtual SyntaxNode VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var usingNamespaceOrMetamodel = this.VisitList(node.UsingNamespaceOrMetamodel);
		    var metamodelDeclaration = (MetamodelDeclarationSyntax)this.Visit(node.MetamodelDeclaration);
		    var declaration = this.VisitList(node.Declaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, usingNamespaceOrMetamodel, metamodelDeclaration, declaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var kMetamodel = this.VisitToken(node.KMetamodel);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var metamodelPropertyList = (MetamodelPropertyListSyntax)this.Visit(node.MetamodelPropertyList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
		}
		
		public virtual SyntaxNode VisitMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
		    var metamodelProperty = this.VisitList(node.MetamodelProperty);
			return node.Update(metamodelProperty);
		}
		
		public virtual SyntaxNode VisitMetamodelProperty(MetamodelPropertySyntax node)
		{
			var oldMetamodelUriProperty = node.MetamodelUriProperty;
			if (oldMetamodelUriProperty != null)
			{
			    var newMetamodelUriProperty = (MetamodelUriPropertySyntax)this.Visit(oldMetamodelUriProperty);
				return node.Update(newMetamodelUriProperty);
			}
			var oldMetamodelPrefixProperty = node.MetamodelPrefixProperty;
			if (oldMetamodelPrefixProperty != null)
			{
			    var newMetamodelPrefixProperty = (MetamodelPrefixPropertySyntax)this.Visit(oldMetamodelPrefixProperty);
				return node.Update(newMetamodelPrefixProperty);
			}
			var oldMajorVersionProperty = node.MajorVersionProperty;
			if (oldMajorVersionProperty != null)
			{
			    var newMajorVersionProperty = (MajorVersionPropertySyntax)this.Visit(oldMajorVersionProperty);
				return node.Update(newMajorVersionProperty);
			}
			var oldMinorVersionProperty = node.MinorVersionProperty;
			if (oldMinorVersionProperty != null)
			{
			    var newMinorVersionProperty = (MinorVersionPropertySyntax)this.Visit(oldMinorVersionProperty);
				return node.Update(newMinorVersionProperty);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
		    var iUri = this.VisitToken(node.IUri);
		    var tAssign = this.VisitToken(node.TAssign);
		    var stringLiteral = (StringLiteralSyntax)this.Visit(node.StringLiteral);
			return node.Update(iUri, tAssign, stringLiteral);
		}
		
		public virtual SyntaxNode VisitMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node)
		{
		    var iPrefix = this.VisitToken(node.IPrefix);
		    var tAssign = this.VisitToken(node.TAssign);
		    var stringLiteral = (StringLiteralSyntax)this.Visit(node.StringLiteral);
			return node.Update(iPrefix, tAssign, stringLiteral);
		}
		
		public virtual SyntaxNode VisitMajorVersionProperty(MajorVersionPropertySyntax node)
		{
		    var iMajorVersion = this.VisitToken(node.IMajorVersion);
		    var tAssign = this.VisitToken(node.TAssign);
		    var integerLiteral = (IntegerLiteralSyntax)this.Visit(node.IntegerLiteral);
			return node.Update(iMajorVersion, tAssign, integerLiteral);
		}
		
		public virtual SyntaxNode VisitMinorVersionProperty(MinorVersionPropertySyntax node)
		{
		    var iMinorVersion = this.VisitToken(node.IMinorVersion);
		    var tAssign = this.VisitToken(node.TAssign);
		    var integerLiteral = (IntegerLiteralSyntax)this.Visit(node.IntegerLiteral);
			return node.Update(iMinorVersion, tAssign, integerLiteral);
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
		    var attribute = this.VisitList(node.Attribute);
		    var kEnum = this.VisitToken(node.KEnum);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var enumBody = (EnumBodySyntax)this.Visit(node.EnumBody);
			return node.Update(attribute, kEnum, name, enumBody);
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
		    var attribute = this.VisitList(node.Attribute);
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(attribute, name);
		}
		
		public virtual SyntaxNode VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
		    var operationDeclaration = (OperationDeclarationSyntax)this.Visit(node.OperationDeclaration);
			return node.Update(operationDeclaration);
		}
		
		public virtual SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var symbolAttribute = (SymbolAttributeSyntax)this.Visit(node.SymbolAttribute);
		    var kAbstract = this.VisitToken(node.KAbstract);
		    var kClass = this.VisitToken(node.KClass);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var classAncestors = (ClassAncestorsSyntax)this.Visit(node.ClassAncestors);
		    var classBody = (ClassBodySyntax)this.Visit(node.ClassBody);
			return node.Update(attribute, symbolAttribute, kAbstract, kClass, name, tColon, classAncestors, classBody);
		}
		
		public virtual SyntaxNode VisitSymbolAttribute(SymbolAttributeSyntax node)
		{
			var oldSymbolSymbolAttribute = node.SymbolSymbolAttribute;
			if (oldSymbolSymbolAttribute != null)
			{
			    var newSymbolSymbolAttribute = (SymbolSymbolAttributeSyntax)this.Visit(oldSymbolSymbolAttribute);
				return node.Update(newSymbolSymbolAttribute);
			}
			var oldExpressionSymbolAttribute = node.ExpressionSymbolAttribute;
			if (oldExpressionSymbolAttribute != null)
			{
			    var newExpressionSymbolAttribute = (ExpressionSymbolAttributeSyntax)this.Visit(oldExpressionSymbolAttribute);
				return node.Update(newExpressionSymbolAttribute);
			}
			var oldStatementSymbolTypeAttribute = node.StatementSymbolTypeAttribute;
			if (oldStatementSymbolTypeAttribute != null)
			{
			    var newStatementSymbolTypeAttribute = (StatementSymbolTypeAttributeSyntax)this.Visit(oldStatementSymbolTypeAttribute);
				return node.Update(newStatementSymbolTypeAttribute);
			}
			var oldTypeSymbolTypeAttribute = node.TypeSymbolTypeAttribute;
			if (oldTypeSymbolTypeAttribute != null)
			{
			    var newTypeSymbolTypeAttribute = (TypeSymbolTypeAttributeSyntax)this.Visit(oldTypeSymbolTypeAttribute);
				return node.Update(newTypeSymbolTypeAttribute);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSymbolSymbolAttribute(SymbolSymbolAttributeSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var kSymbol = this.VisitToken(node.KSymbol);
		    var tColon = this.VisitToken(node.TColon);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, kSymbol, tColon, qualifier, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var kExpression = this.VisitToken(node.KExpression);
		    var tColon = this.VisitToken(node.TColon);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, kExpression, tColon, qualifier, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var kStatement = this.VisitToken(node.KStatement);
		    var tColon = this.VisitToken(node.TColon);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, kStatement, tColon, qualifier, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var kType = this.VisitToken(node.KType);
		    var tColon = this.VisitToken(node.TColon);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, kType, tColon, qualifier, tCloseBracket);
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
		    var attribute = this.VisitList(node.Attribute);
		    var fieldSymbolPropertyAttribute = (FieldSymbolPropertyAttributeSyntax)this.Visit(node.FieldSymbolPropertyAttribute);
		    var fieldContainment = (FieldContainmentSyntax)this.Visit(node.FieldContainment);
		    var fieldModifier = (FieldModifierSyntax)this.Visit(node.FieldModifier);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var defaultValue = (DefaultValueSyntax)this.Visit(node.DefaultValue);
		    var redefinitionsOrSubsettings = this.VisitList(node.RedefinitionsOrSubsettings);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, fieldSymbolPropertyAttribute, fieldContainment, fieldModifier, typeReference, name, defaultValue, redefinitionsOrSubsettings, tSemicolon);
		}
		
		public virtual SyntaxNode VisitFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var kProperty = this.VisitToken(node.KProperty);
		    var tColon = this.VisitToken(node.TColon);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, kProperty, tColon, identifier, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitFieldContainment(FieldContainmentSyntax node)
		{
		    var kContainment = this.VisitToken(node.KContainment);
			return node.Update(kContainment);
		}
		
		public virtual SyntaxNode VisitFieldModifier(FieldModifierSyntax node)
		{
		    var fieldModifier = this.VisitToken(node.FieldModifier);
			return node.Update(fieldModifier);
		}
		
		public virtual SyntaxNode VisitDefaultValue(DefaultValueSyntax node)
		{
		    var tAssign = this.VisitToken(node.TAssign);
		    var stringLiteral = (StringLiteralSyntax)this.Visit(node.StringLiteral);
			return node.Update(tAssign, stringLiteral);
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
		    var constValue = (ConstValueSyntax)this.Visit(node.ConstValue);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kConst, typeReference, name, constValue, tSemicolon);
		}
		
		public virtual SyntaxNode VisitConstValue(ConstValueSyntax node)
		{
		    var tAssign = this.VisitToken(node.TAssign);
		    var stringLiteral = (StringLiteralSyntax)this.Visit(node.StringLiteral);
			return node.Update(tAssign, stringLiteral);
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
			var oldClassType = node.ClassType;
			if (oldClassType != null)
			{
			    var newClassType = (ClassTypeSyntax)this.Visit(oldClassType);
				return node.Update(newClassType);
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
		    var attribute = this.VisitList(node.Attribute);
		    var operationModifier = this.VisitList(node.OperationModifier);
		    var returnType = (ReturnTypeSyntax)this.Visit(node.ReturnType);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var parameterList = (ParameterListSyntax)this.Visit(node.ParameterList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, operationModifier, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
		}
		
		public virtual SyntaxNode VisitOperationModifier(OperationModifierSyntax node)
		{
			var oldOperationModifierBuilder = node.OperationModifierBuilder;
			if (oldOperationModifierBuilder != null)
			{
			    var newOperationModifierBuilder = (OperationModifierBuilderSyntax)this.Visit(oldOperationModifierBuilder);
				return node.Update(newOperationModifierBuilder);
			}
			var oldOperationModifierReadonly = node.OperationModifierReadonly;
			if (oldOperationModifierReadonly != null)
			{
			    var newOperationModifierReadonly = (OperationModifierReadonlySyntax)this.Visit(oldOperationModifierReadonly);
				return node.Update(newOperationModifierReadonly);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitOperationModifierBuilder(OperationModifierBuilderSyntax node)
		{
		    var kBuilder = this.VisitToken(node.KBuilder);
			return node.Update(kBuilder);
		}
		
		public virtual SyntaxNode VisitOperationModifierReadonly(OperationModifierReadonlySyntax node)
		{
		    var kReadonly = this.VisitToken(node.KReadonly);
			return node.Update(kReadonly);
		}
		
		public virtual SyntaxNode VisitParameterList(ParameterListSyntax node)
		{
		    var parameter = this.VisitList(node.Parameter);
			return node.Update(parameter);
		}
		
		public virtual SyntaxNode VisitParameter(ParameterSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(attribute, typeReference, name);
		}
		
		public virtual SyntaxNode VisitAssociationDeclaration(AssociationDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var kAssociation = this.VisitToken(node.KAssociation);
		    var source = (QualifierSyntax)this.Visit(node.Source);
		    var kWith = this.VisitToken(node.KWith);
		    var target = (QualifierSyntax)this.Visit(node.Target);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, kAssociation, source, kWith, target, tSemicolon);
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
		    var lRegularString = this.VisitToken(node.LRegularString);
			return node.Update(lRegularString);
		}
	}

	public class MetaSyntaxFactory : SyntaxFactory
	{
		internal MetaSyntaxFactory(MetaInternalSyntaxFactory internalSyntaxFactory) 
			: base(internalSyntaxFactory)
		{
		}
	    public new MetaLanguage Language => MetaLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public override LanguageParseOptions DefaultParseOptions => MetaParseOptions.Default;
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public MetaSyntaxTree SyntaxTree(SyntaxNode root, MetaParseOptions? options = null, string? path = "", Encoding? encoding = null)
		{
			return MetaSyntaxTree.Create((MetaSyntaxNode)root, ParseData.Empty, options, path, null, encoding);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public MetaSyntaxTree ParseSyntaxTree(
			string text,
			MetaParseOptions options = null,
			string path = "",
			Encoding encoding = null,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (MetaSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public MetaSyntaxTree ParseSyntaxTree(
			SourceText text,
			MetaParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (MetaSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
		protected override LanguageSyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return MetaSyntaxTree.ParseText(text, (MetaParseOptions)options, path, cancellationToken);
		}
	
		public override LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return MetaSyntaxTree.Create((MetaSyntaxNode)root, ParseData.Empty, (MetaParseOptions)options, path, null, encoding);
		}
	
	
	    public SyntaxToken TAsterisk(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.TAsterisk(text));
	    }
	
	    public SyntaxToken TAsterisk(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.TAsterisk(text, value));
	    }
	
	    public SyntaxToken IdentifierNormal(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text));
	    }
	
	    public SyntaxToken IdentifierNormal(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text, value));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text, value));
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LInteger(text));
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LInteger(text, value));
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LDecimal(text));
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LDecimal(text, value));
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LScientific(text));
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LScientific(text, value));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text, value));
	    }
	
	    public SyntaxToken LDateTime(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LDateTime(text));
	    }
	
	    public SyntaxToken LDateTime(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LDateTime(text, value));
	    }
	
	    public SyntaxToken LDate(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LDate(text));
	    }
	
	    public SyntaxToken LDate(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LDate(text, value));
	    }
	
	    public SyntaxToken LTime(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LTime(text));
	    }
	
	    public SyntaxToken LTime(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LTime(text, value));
	    }
	
	    public SyntaxToken LRegularString(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LRegularString(text));
	    }
	
	    public SyntaxToken LRegularString(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LRegularString(text, value));
	    }
	
	    public SyntaxToken LGuid(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LGuid(text));
	    }
	
	    public SyntaxToken LGuid(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LGuid(text, value));
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text));
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value));
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text));
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value));
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LCrLf(text));
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value));
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LLineEnd(text));
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value));
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text));
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value));
	    }
	
	    public SyntaxToken LComment(string text)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LComment(text));
	    }
	
	    public SyntaxToken LComment(string text, object value)
	    {
	        return new SyntaxToken(MetaLanguage.Instance.InternalSyntaxFactory.LComment(text, value));
	    }
		
		public MainSyntax Main(Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax> usingNamespaceOrMetamodel, NamespaceDeclarationSyntax namespaceDeclaration, SyntaxToken eOF)
		{
		    if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
		    if (eOF == null) throw new ArgumentNullException(nameof(eOF));
		    if (eOF.GetKind() != MetaSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
		    return (MainSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Main(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<UsingNamespaceOrMetamodelGreen>(usingNamespaceOrMetamodel.Node), (Syntax.InternalSyntax.NamespaceDeclarationGreen)namespaceDeclaration.Green, (InternalSyntaxToken)eOF.Node).CreateRed();
		}
		
		public MainSyntax Main(NamespaceDeclarationSyntax namespaceDeclaration, SyntaxToken eOF)
		{
			return this.Main(default, namespaceDeclaration, eOF);
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public QualifiedNameSyntax QualifiedName(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifiedNameSyntax)MetaLanguage.Instance.InternalSyntaxFactory.QualifiedName((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public QualifierSyntax Qualifier(Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Qualifier(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public AttributeSyntax Attribute(SyntaxToken tOpenBracket, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != MetaSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != MetaSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (AttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Attribute((InternalSyntaxToken)tOpenBracket.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public AttributeSyntax Attribute(QualifierSyntax qualifier)
		{
			return this.Attribute(this.Token(MetaSyntaxKind.TOpenBracket), qualifier, this.Token(MetaSyntaxKind.TCloseBracket));
		}
		
		public UsingNamespaceOrMetamodelSyntax UsingNamespaceOrMetamodel(UsingNamespaceSyntax usingNamespace)
		{
		    if (usingNamespace == null) throw new ArgumentNullException(nameof(usingNamespace));
		    return (UsingNamespaceOrMetamodelSyntax)MetaLanguage.Instance.InternalSyntaxFactory.UsingNamespaceOrMetamodel((Syntax.InternalSyntax.UsingNamespaceGreen)usingNamespace.Green).CreateRed();
		}
		
		public UsingNamespaceOrMetamodelSyntax UsingNamespaceOrMetamodel(UsingMetamodelSyntax usingMetamodel)
		{
		    if (usingMetamodel == null) throw new ArgumentNullException(nameof(usingMetamodel));
		    return (UsingNamespaceOrMetamodelSyntax)MetaLanguage.Instance.InternalSyntaxFactory.UsingNamespaceOrMetamodel((Syntax.InternalSyntax.UsingMetamodelGreen)usingMetamodel.Green).CreateRed();
		}
		
		public UsingNamespaceSyntax UsingNamespace(SyntaxToken kUsing, NameSyntax name, SyntaxToken tAssign, QualifierSyntax qualifier, SyntaxToken tSemicolon)
		{
		    if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
		    if (kUsing.GetKind() != MetaSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
		    if (tAssign != null && tAssign.GetKind() != MetaSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (UsingNamespaceSyntax)MetaLanguage.Instance.InternalSyntaxFactory.UsingNamespace((InternalSyntaxToken)kUsing.Node, name == null ? null : (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public UsingNamespaceSyntax UsingNamespace(QualifierSyntax qualifier)
		{
			return this.UsingNamespace(this.Token(MetaSyntaxKind.KUsing), default, default, qualifier, this.Token(MetaSyntaxKind.TSemicolon));
		}
		
		public UsingMetamodelSyntax UsingMetamodel(SyntaxToken kUsing, SyntaxToken kMetamodel, NameSyntax name, SyntaxToken tAssign, UsingMetamodelReferenceSyntax usingMetamodelReference, SyntaxToken tSemicolon)
		{
		    if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
		    if (kUsing.GetKind() != MetaSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
		    if (kMetamodel == null) throw new ArgumentNullException(nameof(kMetamodel));
		    if (kMetamodel.GetKind() != MetaSyntaxKind.KMetamodel) throw new ArgumentException(nameof(kMetamodel));
		    if (tAssign != null && tAssign.GetKind() != MetaSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (usingMetamodelReference == null) throw new ArgumentNullException(nameof(usingMetamodelReference));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (UsingMetamodelSyntax)MetaLanguage.Instance.InternalSyntaxFactory.UsingMetamodel((InternalSyntaxToken)kUsing.Node, (InternalSyntaxToken)kMetamodel.Node, name == null ? null : (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.UsingMetamodelReferenceGreen)usingMetamodelReference.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public UsingMetamodelSyntax UsingMetamodel(UsingMetamodelReferenceSyntax usingMetamodelReference)
		{
			return this.UsingMetamodel(this.Token(MetaSyntaxKind.KUsing), this.Token(MetaSyntaxKind.KMetamodel), default, default, usingMetamodelReference, this.Token(MetaSyntaxKind.TSemicolon));
		}
		
		public UsingMetamodelReferenceSyntax UsingMetamodelReference(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (UsingMetamodelReferenceSyntax)MetaLanguage.Instance.InternalSyntaxFactory.UsingMetamodelReference((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public UsingMetamodelReferenceSyntax UsingMetamodelReference(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (UsingMetamodelReferenceSyntax)MetaLanguage.Instance.InternalSyntaxFactory.UsingMetamodelReference((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != MetaSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
		    return (NamespaceDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBodyGreen)namespaceBody.Green).CreateRed();
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
		{
			return this.NamespaceDeclaration(default, this.Token(MetaSyntaxKind.KNamespace), qualifiedName, namespaceBody);
		}
		
		public NamespaceBodySyntax NamespaceBody(SyntaxToken tOpenBrace, Microsoft.CodeAnalysis.SyntaxList<UsingNamespaceOrMetamodelSyntax> usingNamespaceOrMetamodel, MetamodelDeclarationSyntax metamodelDeclaration, Microsoft.CodeAnalysis.SyntaxList<DeclarationSyntax> declaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != MetaSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (metamodelDeclaration == null) throw new ArgumentNullException(nameof(metamodelDeclaration));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != MetaSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBodySyntax)MetaLanguage.Instance.InternalSyntaxFactory.NamespaceBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<UsingNamespaceOrMetamodelGreen>(usingNamespaceOrMetamodel.Node), (Syntax.InternalSyntax.MetamodelDeclarationGreen)metamodelDeclaration.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<DeclarationGreen>(declaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBodySyntax NamespaceBody(MetamodelDeclarationSyntax metamodelDeclaration)
		{
			return this.NamespaceBody(this.Token(MetaSyntaxKind.TOpenBrace), default, metamodelDeclaration, default, this.Token(MetaSyntaxKind.TCloseBrace));
		}
		
		public MetamodelDeclarationSyntax MetamodelDeclaration(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SyntaxToken kMetamodel, NameSyntax name, SyntaxToken tOpenParen, MetamodelPropertyListSyntax metamodelPropertyList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
		{
		    if (kMetamodel == null) throw new ArgumentNullException(nameof(kMetamodel));
		    if (kMetamodel.GetKind() != MetaSyntaxKind.KMetamodel) throw new ArgumentException(nameof(kMetamodel));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen != null && tOpenParen.GetKind() != MetaSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen != null && tCloseParen.GetKind() != MetaSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (MetamodelDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.MetamodelDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (InternalSyntaxToken)kMetamodel.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Node, metamodelPropertyList == null ? null : (Syntax.InternalSyntax.MetamodelPropertyListGreen)metamodelPropertyList.Green, (InternalSyntaxToken)tCloseParen.Node, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public MetamodelDeclarationSyntax MetamodelDeclaration(NameSyntax name)
		{
			return this.MetamodelDeclaration(default, this.Token(MetaSyntaxKind.KMetamodel), name, default, default, default, this.Token(MetaSyntaxKind.TSemicolon));
		}
		
		public MetamodelPropertyListSyntax MetamodelPropertyList(Microsoft.CodeAnalysis.SeparatedSyntaxList<MetamodelPropertySyntax> metamodelProperty)
		{
		    if (metamodelProperty == null) throw new ArgumentNullException(nameof(metamodelProperty));
		    return (MetamodelPropertyListSyntax)MetaLanguage.Instance.InternalSyntaxFactory.MetamodelPropertyList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<MetamodelPropertyGreen>(metamodelProperty.Node)).CreateRed();
		}
		
		public MetamodelPropertySyntax MetamodelProperty(MetamodelUriPropertySyntax metamodelUriProperty)
		{
		    if (metamodelUriProperty == null) throw new ArgumentNullException(nameof(metamodelUriProperty));
		    return (MetamodelPropertySyntax)MetaLanguage.Instance.InternalSyntaxFactory.MetamodelProperty((Syntax.InternalSyntax.MetamodelUriPropertyGreen)metamodelUriProperty.Green).CreateRed();
		}
		
		public MetamodelPropertySyntax MetamodelProperty(MetamodelPrefixPropertySyntax metamodelPrefixProperty)
		{
		    if (metamodelPrefixProperty == null) throw new ArgumentNullException(nameof(metamodelPrefixProperty));
		    return (MetamodelPropertySyntax)MetaLanguage.Instance.InternalSyntaxFactory.MetamodelProperty((Syntax.InternalSyntax.MetamodelPrefixPropertyGreen)metamodelPrefixProperty.Green).CreateRed();
		}
		
		public MetamodelPropertySyntax MetamodelProperty(MajorVersionPropertySyntax majorVersionProperty)
		{
		    if (majorVersionProperty == null) throw new ArgumentNullException(nameof(majorVersionProperty));
		    return (MetamodelPropertySyntax)MetaLanguage.Instance.InternalSyntaxFactory.MetamodelProperty((Syntax.InternalSyntax.MajorVersionPropertyGreen)majorVersionProperty.Green).CreateRed();
		}
		
		public MetamodelPropertySyntax MetamodelProperty(MinorVersionPropertySyntax minorVersionProperty)
		{
		    if (minorVersionProperty == null) throw new ArgumentNullException(nameof(minorVersionProperty));
		    return (MetamodelPropertySyntax)MetaLanguage.Instance.InternalSyntaxFactory.MetamodelProperty((Syntax.InternalSyntax.MinorVersionPropertyGreen)minorVersionProperty.Green).CreateRed();
		}
		
		public MetamodelUriPropertySyntax MetamodelUriProperty(SyntaxToken iUri, SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
		{
		    if (iUri == null) throw new ArgumentNullException(nameof(iUri));
		    if (iUri.GetKind() != MetaSyntaxKind.IUri) throw new ArgumentException(nameof(iUri));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != MetaSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (MetamodelUriPropertySyntax)MetaLanguage.Instance.InternalSyntaxFactory.MetamodelUriProperty((InternalSyntaxToken)iUri.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public MetamodelUriPropertySyntax MetamodelUriProperty(StringLiteralSyntax stringLiteral)
		{
			return this.MetamodelUriProperty(this.Token(MetaSyntaxKind.IUri), this.Token(MetaSyntaxKind.TAssign), stringLiteral);
		}
		
		public MetamodelPrefixPropertySyntax MetamodelPrefixProperty(SyntaxToken iPrefix, SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
		{
		    if (iPrefix == null) throw new ArgumentNullException(nameof(iPrefix));
		    if (iPrefix.GetKind() != MetaSyntaxKind.IPrefix) throw new ArgumentException(nameof(iPrefix));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != MetaSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (MetamodelPrefixPropertySyntax)MetaLanguage.Instance.InternalSyntaxFactory.MetamodelPrefixProperty((InternalSyntaxToken)iPrefix.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public MetamodelPrefixPropertySyntax MetamodelPrefixProperty(StringLiteralSyntax stringLiteral)
		{
			return this.MetamodelPrefixProperty(this.Token(MetaSyntaxKind.IPrefix), this.Token(MetaSyntaxKind.TAssign), stringLiteral);
		}
		
		public MajorVersionPropertySyntax MajorVersionProperty(SyntaxToken iMajorVersion, SyntaxToken tAssign, IntegerLiteralSyntax integerLiteral)
		{
		    if (iMajorVersion == null) throw new ArgumentNullException(nameof(iMajorVersion));
		    if (iMajorVersion.GetKind() != MetaSyntaxKind.IMajorVersion) throw new ArgumentException(nameof(iMajorVersion));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != MetaSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    return (MajorVersionPropertySyntax)MetaLanguage.Instance.InternalSyntaxFactory.MajorVersionProperty((InternalSyntaxToken)iMajorVersion.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.IntegerLiteralGreen)integerLiteral.Green).CreateRed();
		}
		
		public MajorVersionPropertySyntax MajorVersionProperty(IntegerLiteralSyntax integerLiteral)
		{
			return this.MajorVersionProperty(this.Token(MetaSyntaxKind.IMajorVersion), this.Token(MetaSyntaxKind.TAssign), integerLiteral);
		}
		
		public MinorVersionPropertySyntax MinorVersionProperty(SyntaxToken iMinorVersion, SyntaxToken tAssign, IntegerLiteralSyntax integerLiteral)
		{
		    if (iMinorVersion == null) throw new ArgumentNullException(nameof(iMinorVersion));
		    if (iMinorVersion.GetKind() != MetaSyntaxKind.IMinorVersion) throw new ArgumentException(nameof(iMinorVersion));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != MetaSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    return (MinorVersionPropertySyntax)MetaLanguage.Instance.InternalSyntaxFactory.MinorVersionProperty((InternalSyntaxToken)iMinorVersion.Node, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.IntegerLiteralGreen)integerLiteral.Green).CreateRed();
		}
		
		public MinorVersionPropertySyntax MinorVersionProperty(IntegerLiteralSyntax integerLiteral)
		{
			return this.MinorVersionProperty(this.Token(MetaSyntaxKind.IMinorVersion), this.Token(MetaSyntaxKind.TAssign), integerLiteral);
		}
		
		public DeclarationSyntax Declaration(EnumDeclarationSyntax enumDeclaration)
		{
		    if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
		    return (DeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.EnumDeclarationGreen)enumDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(ClassDeclarationSyntax classDeclaration)
		{
		    if (classDeclaration == null) throw new ArgumentNullException(nameof(classDeclaration));
		    return (DeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.ClassDeclarationGreen)classDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(AssociationDeclarationSyntax associationDeclaration)
		{
		    if (associationDeclaration == null) throw new ArgumentNullException(nameof(associationDeclaration));
		    return (DeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.AssociationDeclarationGreen)associationDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(ConstDeclarationSyntax constDeclaration)
		{
		    if (constDeclaration == null) throw new ArgumentNullException(nameof(constDeclaration));
		    return (DeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.ConstDeclarationGreen)constDeclaration.Green).CreateRed();
		}
		
		public EnumDeclarationSyntax EnumDeclaration(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SyntaxToken kEnum, NameSyntax name, EnumBodySyntax enumBody)
		{
		    if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
		    if (kEnum.GetKind() != MetaSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
		    return (EnumDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (InternalSyntaxToken)kEnum.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.EnumBodyGreen)enumBody.Green).CreateRed();
		}
		
		public EnumDeclarationSyntax EnumDeclaration(NameSyntax name, EnumBodySyntax enumBody)
		{
			return this.EnumDeclaration(default, this.Token(MetaSyntaxKind.KEnum), name, enumBody);
		}
		
		public EnumBodySyntax EnumBody(SyntaxToken tOpenBrace, EnumValuesSyntax enumValues, SyntaxToken tSemicolon, Microsoft.CodeAnalysis.SyntaxList<EnumMemberDeclarationSyntax> enumMemberDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != MetaSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (enumValues == null) throw new ArgumentNullException(nameof(enumValues));
		    if (tSemicolon != null && tSemicolon.GetKind() != MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != MetaSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (EnumBodySyntax)MetaLanguage.Instance.InternalSyntaxFactory.EnumBody((InternalSyntaxToken)tOpenBrace.Node, (Syntax.InternalSyntax.EnumValuesGreen)enumValues.Green, (InternalSyntaxToken)tSemicolon.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<EnumMemberDeclarationGreen>(enumMemberDeclaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public EnumBodySyntax EnumBody(EnumValuesSyntax enumValues)
		{
			return this.EnumBody(this.Token(MetaSyntaxKind.TOpenBrace), enumValues, default, default, this.Token(MetaSyntaxKind.TCloseBrace));
		}
		
		public EnumValuesSyntax EnumValues(Microsoft.CodeAnalysis.SeparatedSyntaxList<EnumValueSyntax> enumValue)
		{
		    if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));
		    return (EnumValuesSyntax)MetaLanguage.Instance.InternalSyntaxFactory.EnumValues(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<EnumValueGreen>(enumValue.Node)).CreateRed();
		}
		
		public EnumValueSyntax EnumValue(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (EnumValueSyntax)MetaLanguage.Instance.InternalSyntaxFactory.EnumValue(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public EnumValueSyntax EnumValue(NameSyntax name)
		{
			return this.EnumValue(default, name);
		}
		
		public EnumMemberDeclarationSyntax EnumMemberDeclaration(OperationDeclarationSyntax operationDeclaration)
		{
		    if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
		    return (EnumMemberDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.EnumMemberDeclaration((Syntax.InternalSyntax.OperationDeclarationGreen)operationDeclaration.Green).CreateRed();
		}
		
		public ClassDeclarationSyntax ClassDeclaration(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SymbolAttributeSyntax symbolAttribute, SyntaxToken kAbstract, SyntaxToken kClass, NameSyntax name, SyntaxToken tColon, ClassAncestorsSyntax classAncestors, ClassBodySyntax classBody)
		{
		    if (kAbstract != null && kAbstract.GetKind() != MetaSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
		    if (kClass == null) throw new ArgumentNullException(nameof(kClass));
		    if (kClass.GetKind() != MetaSyntaxKind.KClass) throw new ArgumentException(nameof(kClass));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon != null && tColon.GetKind() != MetaSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (classBody == null) throw new ArgumentNullException(nameof(classBody));
		    return (ClassDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ClassDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), symbolAttribute == null ? null : (Syntax.InternalSyntax.SymbolAttributeGreen)symbolAttribute.Green, (InternalSyntaxToken)kAbstract.Node, (InternalSyntaxToken)kClass.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, classAncestors == null ? null : (Syntax.InternalSyntax.ClassAncestorsGreen)classAncestors.Green, (Syntax.InternalSyntax.ClassBodyGreen)classBody.Green).CreateRed();
		}
		
		public ClassDeclarationSyntax ClassDeclaration(NameSyntax name, ClassBodySyntax classBody)
		{
			return this.ClassDeclaration(default, default, default, this.Token(MetaSyntaxKind.KClass), name, default, default, classBody);
		}
		
		public SymbolAttributeSyntax SymbolAttribute(SymbolSymbolAttributeSyntax symbolSymbolAttribute)
		{
		    if (symbolSymbolAttribute == null) throw new ArgumentNullException(nameof(symbolSymbolAttribute));
		    return (SymbolAttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.SymbolAttribute((Syntax.InternalSyntax.SymbolSymbolAttributeGreen)symbolSymbolAttribute.Green).CreateRed();
		}
		
		public SymbolAttributeSyntax SymbolAttribute(ExpressionSymbolAttributeSyntax expressionSymbolAttribute)
		{
		    if (expressionSymbolAttribute == null) throw new ArgumentNullException(nameof(expressionSymbolAttribute));
		    return (SymbolAttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.SymbolAttribute((Syntax.InternalSyntax.ExpressionSymbolAttributeGreen)expressionSymbolAttribute.Green).CreateRed();
		}
		
		public SymbolAttributeSyntax SymbolAttribute(StatementSymbolTypeAttributeSyntax statementSymbolTypeAttribute)
		{
		    if (statementSymbolTypeAttribute == null) throw new ArgumentNullException(nameof(statementSymbolTypeAttribute));
		    return (SymbolAttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.SymbolAttribute((Syntax.InternalSyntax.StatementSymbolTypeAttributeGreen)statementSymbolTypeAttribute.Green).CreateRed();
		}
		
		public SymbolAttributeSyntax SymbolAttribute(TypeSymbolTypeAttributeSyntax typeSymbolTypeAttribute)
		{
		    if (typeSymbolTypeAttribute == null) throw new ArgumentNullException(nameof(typeSymbolTypeAttribute));
		    return (SymbolAttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.SymbolAttribute((Syntax.InternalSyntax.TypeSymbolTypeAttributeGreen)typeSymbolTypeAttribute.Green).CreateRed();
		}
		
		public SymbolSymbolAttributeSyntax SymbolSymbolAttribute(SyntaxToken tOpenBracket, SyntaxToken kSymbol, SyntaxToken tColon, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != MetaSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (kSymbol == null) throw new ArgumentNullException(nameof(kSymbol));
		    if (kSymbol.GetKind() != MetaSyntaxKind.KSymbol) throw new ArgumentException(nameof(kSymbol));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != MetaSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != MetaSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (SymbolSymbolAttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.SymbolSymbolAttribute((InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)kSymbol.Node, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public SymbolSymbolAttributeSyntax SymbolSymbolAttribute(QualifierSyntax qualifier)
		{
			return this.SymbolSymbolAttribute(this.Token(MetaSyntaxKind.TOpenBracket), this.Token(MetaSyntaxKind.KSymbol), this.Token(MetaSyntaxKind.TColon), qualifier, this.Token(MetaSyntaxKind.TCloseBracket));
		}
		
		public ExpressionSymbolAttributeSyntax ExpressionSymbolAttribute(SyntaxToken tOpenBracket, SyntaxToken kExpression, SyntaxToken tColon, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != MetaSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (kExpression == null) throw new ArgumentNullException(nameof(kExpression));
		    if (kExpression.GetKind() != MetaSyntaxKind.KExpression) throw new ArgumentException(nameof(kExpression));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != MetaSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != MetaSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (ExpressionSymbolAttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ExpressionSymbolAttribute((InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)kExpression.Node, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public ExpressionSymbolAttributeSyntax ExpressionSymbolAttribute(QualifierSyntax qualifier)
		{
			return this.ExpressionSymbolAttribute(this.Token(MetaSyntaxKind.TOpenBracket), this.Token(MetaSyntaxKind.KExpression), this.Token(MetaSyntaxKind.TColon), qualifier, this.Token(MetaSyntaxKind.TCloseBracket));
		}
		
		public StatementSymbolTypeAttributeSyntax StatementSymbolTypeAttribute(SyntaxToken tOpenBracket, SyntaxToken kStatement, SyntaxToken tColon, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != MetaSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (kStatement == null) throw new ArgumentNullException(nameof(kStatement));
		    if (kStatement.GetKind() != MetaSyntaxKind.KStatement) throw new ArgumentException(nameof(kStatement));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != MetaSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != MetaSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (StatementSymbolTypeAttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.StatementSymbolTypeAttribute((InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)kStatement.Node, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public StatementSymbolTypeAttributeSyntax StatementSymbolTypeAttribute(QualifierSyntax qualifier)
		{
			return this.StatementSymbolTypeAttribute(this.Token(MetaSyntaxKind.TOpenBracket), this.Token(MetaSyntaxKind.KStatement), this.Token(MetaSyntaxKind.TColon), qualifier, this.Token(MetaSyntaxKind.TCloseBracket));
		}
		
		public TypeSymbolTypeAttributeSyntax TypeSymbolTypeAttribute(SyntaxToken tOpenBracket, SyntaxToken kType, SyntaxToken tColon, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != MetaSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (kType == null) throw new ArgumentNullException(nameof(kType));
		    if (kType.GetKind() != MetaSyntaxKind.KType) throw new ArgumentException(nameof(kType));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != MetaSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != MetaSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (TypeSymbolTypeAttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.TypeSymbolTypeAttribute((InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)kType.Node, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public TypeSymbolTypeAttributeSyntax TypeSymbolTypeAttribute(QualifierSyntax qualifier)
		{
			return this.TypeSymbolTypeAttribute(this.Token(MetaSyntaxKind.TOpenBracket), this.Token(MetaSyntaxKind.KType), this.Token(MetaSyntaxKind.TColon), qualifier, this.Token(MetaSyntaxKind.TCloseBracket));
		}
		
		public ClassBodySyntax ClassBody(SyntaxToken tOpenBrace, Microsoft.CodeAnalysis.SyntaxList<ClassMemberDeclarationSyntax> classMemberDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != MetaSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != MetaSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (ClassBodySyntax)MetaLanguage.Instance.InternalSyntaxFactory.ClassBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ClassMemberDeclarationGreen>(classMemberDeclaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public ClassBodySyntax ClassBody()
		{
			return this.ClassBody(this.Token(MetaSyntaxKind.TOpenBrace), default, this.Token(MetaSyntaxKind.TCloseBrace));
		}
		
		public ClassAncestorsSyntax ClassAncestors(Microsoft.CodeAnalysis.SeparatedSyntaxList<ClassAncestorSyntax> classAncestor)
		{
		    if (classAncestor == null) throw new ArgumentNullException(nameof(classAncestor));
		    return (ClassAncestorsSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ClassAncestors(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ClassAncestorGreen>(classAncestor.Node)).CreateRed();
		}
		
		public ClassAncestorSyntax ClassAncestor(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (ClassAncestorSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ClassAncestor((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ClassMemberDeclarationSyntax ClassMemberDeclaration(FieldDeclarationSyntax fieldDeclaration)
		{
		    if (fieldDeclaration == null) throw new ArgumentNullException(nameof(fieldDeclaration));
		    return (ClassMemberDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration((Syntax.InternalSyntax.FieldDeclarationGreen)fieldDeclaration.Green).CreateRed();
		}
		
		public ClassMemberDeclarationSyntax ClassMemberDeclaration(OperationDeclarationSyntax operationDeclaration)
		{
		    if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
		    return (ClassMemberDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration((Syntax.InternalSyntax.OperationDeclarationGreen)operationDeclaration.Green).CreateRed();
		}
		
		public FieldDeclarationSyntax FieldDeclaration(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, FieldSymbolPropertyAttributeSyntax fieldSymbolPropertyAttribute, FieldContainmentSyntax fieldContainment, FieldModifierSyntax fieldModifier, TypeReferenceSyntax typeReference, NameSyntax name, DefaultValueSyntax defaultValue, Microsoft.CodeAnalysis.SyntaxList<RedefinitionsOrSubsettingsSyntax> redefinitionsOrSubsettings, SyntaxToken tSemicolon)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (FieldDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.FieldDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), fieldSymbolPropertyAttribute == null ? null : (Syntax.InternalSyntax.FieldSymbolPropertyAttributeGreen)fieldSymbolPropertyAttribute.Green, fieldContainment == null ? null : (Syntax.InternalSyntax.FieldContainmentGreen)fieldContainment.Green, fieldModifier == null ? null : (Syntax.InternalSyntax.FieldModifierGreen)fieldModifier.Green, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green, defaultValue == null ? null : (Syntax.InternalSyntax.DefaultValueGreen)defaultValue.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<RedefinitionsOrSubsettingsGreen>(redefinitionsOrSubsettings.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public FieldDeclarationSyntax FieldDeclaration(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.FieldDeclaration(default, default, default, default, typeReference, name, default, default, this.Token(MetaSyntaxKind.TSemicolon));
		}
		
		public FieldSymbolPropertyAttributeSyntax FieldSymbolPropertyAttribute(SyntaxToken tOpenBracket, SyntaxToken kProperty, SyntaxToken tColon, IdentifierSyntax identifier, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != MetaSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (kProperty == null) throw new ArgumentNullException(nameof(kProperty));
		    if (kProperty.GetKind() != MetaSyntaxKind.KProperty) throw new ArgumentException(nameof(kProperty));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != MetaSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != MetaSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (FieldSymbolPropertyAttributeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.FieldSymbolPropertyAttribute((InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)kProperty.Node, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public FieldSymbolPropertyAttributeSyntax FieldSymbolPropertyAttribute(IdentifierSyntax identifier)
		{
			return this.FieldSymbolPropertyAttribute(this.Token(MetaSyntaxKind.TOpenBracket), this.Token(MetaSyntaxKind.KProperty), this.Token(MetaSyntaxKind.TColon), identifier, this.Token(MetaSyntaxKind.TCloseBracket));
		}
		
		public FieldContainmentSyntax FieldContainment(SyntaxToken kContainment)
		{
		    if (kContainment == null) throw new ArgumentNullException(nameof(kContainment));
		    if (kContainment.GetKind() != MetaSyntaxKind.KContainment) throw new ArgumentException(nameof(kContainment));
		    return (FieldContainmentSyntax)MetaLanguage.Instance.InternalSyntaxFactory.FieldContainment((InternalSyntaxToken)kContainment.Node).CreateRed();
		}
		
		public FieldContainmentSyntax FieldContainment()
		{
			return this.FieldContainment(this.Token(MetaSyntaxKind.KContainment));
		}
		
		public FieldModifierSyntax FieldModifier(SyntaxToken fieldModifier)
		{
		    if (fieldModifier == null) throw new ArgumentNullException(nameof(fieldModifier));
		    return (FieldModifierSyntax)MetaLanguage.Instance.InternalSyntaxFactory.FieldModifier((InternalSyntaxToken)fieldModifier.Node).CreateRed();
		}
		
		public DefaultValueSyntax DefaultValue(SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
		{
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != MetaSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (DefaultValueSyntax)MetaLanguage.Instance.InternalSyntaxFactory.DefaultValue((InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public DefaultValueSyntax DefaultValue(StringLiteralSyntax stringLiteral)
		{
			return this.DefaultValue(this.Token(MetaSyntaxKind.TAssign), stringLiteral);
		}
		
		public RedefinitionsOrSubsettingsSyntax RedefinitionsOrSubsettings(RedefinitionsSyntax redefinitions)
		{
		    if (redefinitions == null) throw new ArgumentNullException(nameof(redefinitions));
		    return (RedefinitionsOrSubsettingsSyntax)MetaLanguage.Instance.InternalSyntaxFactory.RedefinitionsOrSubsettings((Syntax.InternalSyntax.RedefinitionsGreen)redefinitions.Green).CreateRed();
		}
		
		public RedefinitionsOrSubsettingsSyntax RedefinitionsOrSubsettings(SubsettingsSyntax subsettings)
		{
		    if (subsettings == null) throw new ArgumentNullException(nameof(subsettings));
		    return (RedefinitionsOrSubsettingsSyntax)MetaLanguage.Instance.InternalSyntaxFactory.RedefinitionsOrSubsettings((Syntax.InternalSyntax.SubsettingsGreen)subsettings.Green).CreateRed();
		}
		
		public RedefinitionsSyntax Redefinitions(SyntaxToken kRedefines, NameUseListSyntax nameUseList)
		{
		    if (kRedefines == null) throw new ArgumentNullException(nameof(kRedefines));
		    if (kRedefines.GetKind() != MetaSyntaxKind.KRedefines) throw new ArgumentException(nameof(kRedefines));
		    return (RedefinitionsSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Redefinitions((InternalSyntaxToken)kRedefines.Node, nameUseList == null ? null : (Syntax.InternalSyntax.NameUseListGreen)nameUseList.Green).CreateRed();
		}
		
		public RedefinitionsSyntax Redefinitions()
		{
			return this.Redefinitions(this.Token(MetaSyntaxKind.KRedefines), default);
		}
		
		public SubsettingsSyntax Subsettings(SyntaxToken kSubsets, NameUseListSyntax nameUseList)
		{
		    if (kSubsets == null) throw new ArgumentNullException(nameof(kSubsets));
		    if (kSubsets.GetKind() != MetaSyntaxKind.KSubsets) throw new ArgumentException(nameof(kSubsets));
		    return (SubsettingsSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Subsettings((InternalSyntaxToken)kSubsets.Node, nameUseList == null ? null : (Syntax.InternalSyntax.NameUseListGreen)nameUseList.Green).CreateRed();
		}
		
		public SubsettingsSyntax Subsettings()
		{
			return this.Subsettings(this.Token(MetaSyntaxKind.KSubsets), default);
		}
		
		public NameUseListSyntax NameUseList(Microsoft.CodeAnalysis.SeparatedSyntaxList<QualifierSyntax> qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (NameUseListSyntax)MetaLanguage.Instance.InternalSyntaxFactory.NameUseList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<QualifierGreen>(qualifier.Node)).CreateRed();
		}
		
		public ConstDeclarationSyntax ConstDeclaration(SyntaxToken kConst, TypeReferenceSyntax typeReference, NameSyntax name, ConstValueSyntax constValue, SyntaxToken tSemicolon)
		{
		    if (kConst == null) throw new ArgumentNullException(nameof(kConst));
		    if (kConst.GetKind() != MetaSyntaxKind.KConst) throw new ArgumentException(nameof(kConst));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ConstDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ConstDeclaration((InternalSyntaxToken)kConst.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green, constValue == null ? null : (Syntax.InternalSyntax.ConstValueGreen)constValue.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ConstDeclarationSyntax ConstDeclaration(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.ConstDeclaration(this.Token(MetaSyntaxKind.KConst), typeReference, name, default, this.Token(MetaSyntaxKind.TSemicolon));
		}
		
		public ConstValueSyntax ConstValue(SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
		{
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != MetaSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (ConstValueSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ConstValue((InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public ConstValueSyntax ConstValue(StringLiteralSyntax stringLiteral)
		{
			return this.ConstValue(this.Token(MetaSyntaxKind.TAssign), stringLiteral);
		}
		
		public ReturnTypeSyntax ReturnType(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (ReturnTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public ReturnTypeSyntax ReturnType(VoidTypeSyntax voidType)
		{
		    if (voidType == null) throw new ArgumentNullException(nameof(voidType));
		    return (ReturnTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.VoidTypeGreen)voidType.Green).CreateRed();
		}
		
		public TypeOfReferenceSyntax TypeOfReference(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (TypeOfReferenceSyntax)MetaLanguage.Instance.InternalSyntaxFactory.TypeOfReference((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(CollectionTypeSyntax collectionType)
		{
		    if (collectionType == null) throw new ArgumentNullException(nameof(collectionType));
		    return (TypeReferenceSyntax)MetaLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.CollectionTypeGreen)collectionType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(SimpleTypeSyntax simpleType)
		{
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    return (TypeReferenceSyntax)MetaLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(PrimitiveTypeSyntax primitiveType)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    return (SimpleTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.PrimitiveTypeGreen)primitiveType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(ObjectTypeSyntax objectType)
		{
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
		    return (SimpleTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.ObjectTypeGreen)objectType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(NullableTypeSyntax nullableType)
		{
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
		    return (SimpleTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.NullableTypeGreen)nullableType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(ClassTypeSyntax classType)
		{
		    if (classType == null) throw new ArgumentNullException(nameof(classType));
		    return (SimpleTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.ClassTypeGreen)classType.Green).CreateRed();
		}
		
		public ClassTypeSyntax ClassType(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (ClassTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ClassType((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ObjectTypeSyntax ObjectType(SyntaxToken objectType)
		{
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
		    return (ObjectTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ObjectType((InternalSyntaxToken)objectType.Node).CreateRed();
		}
		
		public PrimitiveTypeSyntax PrimitiveType(SyntaxToken primitiveType)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    return (PrimitiveTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.PrimitiveType((InternalSyntaxToken)primitiveType.Node).CreateRed();
		}
		
		public VoidTypeSyntax VoidType(SyntaxToken kVoid)
		{
		    if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
		    if (kVoid.GetKind() != MetaSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
		    return (VoidTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.VoidType((InternalSyntaxToken)kVoid.Node).CreateRed();
		}
		
		public VoidTypeSyntax VoidType()
		{
			return this.VoidType(this.Token(MetaSyntaxKind.KVoid));
		}
		
		public NullableTypeSyntax NullableType(PrimitiveTypeSyntax primitiveType, SyntaxToken tQuestion)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
		    if (tQuestion.GetKind() != MetaSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
		    return (NullableTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.NullableType((Syntax.InternalSyntax.PrimitiveTypeGreen)primitiveType.Green, (InternalSyntaxToken)tQuestion.Node).CreateRed();
		}
		
		public NullableTypeSyntax NullableType(PrimitiveTypeSyntax primitiveType)
		{
			return this.NullableType(primitiveType, this.Token(MetaSyntaxKind.TQuestion));
		}
		
		public CollectionTypeSyntax CollectionType(CollectionKindSyntax collectionKind, SyntaxToken tLessThan, SimpleTypeSyntax simpleType, SyntaxToken tGreaterThan)
		{
		    if (collectionKind == null) throw new ArgumentNullException(nameof(collectionKind));
		    if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
		    if (tLessThan.GetKind() != MetaSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
		    if (tGreaterThan.GetKind() != MetaSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
		    return (CollectionTypeSyntax)MetaLanguage.Instance.InternalSyntaxFactory.CollectionType((Syntax.InternalSyntax.CollectionKindGreen)collectionKind.Green, (InternalSyntaxToken)tLessThan.Node, (Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green, (InternalSyntaxToken)tGreaterThan.Node).CreateRed();
		}
		
		public CollectionTypeSyntax CollectionType(CollectionKindSyntax collectionKind, SimpleTypeSyntax simpleType)
		{
			return this.CollectionType(collectionKind, this.Token(MetaSyntaxKind.TLessThan), simpleType, this.Token(MetaSyntaxKind.TGreaterThan));
		}
		
		public CollectionKindSyntax CollectionKind(SyntaxToken collectionKind)
		{
		    if (collectionKind == null) throw new ArgumentNullException(nameof(collectionKind));
		    return (CollectionKindSyntax)MetaLanguage.Instance.InternalSyntaxFactory.CollectionKind((InternalSyntaxToken)collectionKind.Node).CreateRed();
		}
		
		public OperationDeclarationSyntax OperationDeclaration(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, Microsoft.CodeAnalysis.SyntaxList<OperationModifierSyntax> operationModifier, ReturnTypeSyntax returnType, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
		{
		    if (returnType == null) throw new ArgumentNullException(nameof(returnType));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != MetaSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != MetaSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (OperationDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<OperationModifierGreen>(operationModifier.Node), (Syntax.InternalSyntax.ReturnTypeGreen)returnType.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Node, parameterList == null ? null : (Syntax.InternalSyntax.ParameterListGreen)parameterList.Green, (InternalSyntaxToken)tCloseParen.Node, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public OperationDeclarationSyntax OperationDeclaration(ReturnTypeSyntax returnType, NameSyntax name)
		{
			return this.OperationDeclaration(default, default, returnType, name, this.Token(MetaSyntaxKind.TOpenParen), default, this.Token(MetaSyntaxKind.TCloseParen), this.Token(MetaSyntaxKind.TSemicolon));
		}
		
		public OperationModifierSyntax OperationModifier(OperationModifierBuilderSyntax operationModifierBuilder)
		{
		    if (operationModifierBuilder == null) throw new ArgumentNullException(nameof(operationModifierBuilder));
		    return (OperationModifierSyntax)MetaLanguage.Instance.InternalSyntaxFactory.OperationModifier((Syntax.InternalSyntax.OperationModifierBuilderGreen)operationModifierBuilder.Green).CreateRed();
		}
		
		public OperationModifierSyntax OperationModifier(OperationModifierReadonlySyntax operationModifierReadonly)
		{
		    if (operationModifierReadonly == null) throw new ArgumentNullException(nameof(operationModifierReadonly));
		    return (OperationModifierSyntax)MetaLanguage.Instance.InternalSyntaxFactory.OperationModifier((Syntax.InternalSyntax.OperationModifierReadonlyGreen)operationModifierReadonly.Green).CreateRed();
		}
		
		public OperationModifierBuilderSyntax OperationModifierBuilder(SyntaxToken kBuilder)
		{
		    if (kBuilder == null) throw new ArgumentNullException(nameof(kBuilder));
		    if (kBuilder.GetKind() != MetaSyntaxKind.KBuilder) throw new ArgumentException(nameof(kBuilder));
		    return (OperationModifierBuilderSyntax)MetaLanguage.Instance.InternalSyntaxFactory.OperationModifierBuilder((InternalSyntaxToken)kBuilder.Node).CreateRed();
		}
		
		public OperationModifierBuilderSyntax OperationModifierBuilder()
		{
			return this.OperationModifierBuilder(this.Token(MetaSyntaxKind.KBuilder));
		}
		
		public OperationModifierReadonlySyntax OperationModifierReadonly(SyntaxToken kReadonly)
		{
		    if (kReadonly == null) throw new ArgumentNullException(nameof(kReadonly));
		    if (kReadonly.GetKind() != MetaSyntaxKind.KReadonly) throw new ArgumentException(nameof(kReadonly));
		    return (OperationModifierReadonlySyntax)MetaLanguage.Instance.InternalSyntaxFactory.OperationModifierReadonly((InternalSyntaxToken)kReadonly.Node).CreateRed();
		}
		
		public OperationModifierReadonlySyntax OperationModifierReadonly()
		{
			return this.OperationModifierReadonly(this.Token(MetaSyntaxKind.KReadonly));
		}
		
		public ParameterListSyntax ParameterList(Microsoft.CodeAnalysis.SeparatedSyntaxList<ParameterSyntax> parameter)
		{
		    if (parameter == null) throw new ArgumentNullException(nameof(parameter));
		    return (ParameterListSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ParameterList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParameterGreen>(parameter.Node)).CreateRed();
		}
		
		public ParameterSyntax Parameter(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, TypeReferenceSyntax typeReference, NameSyntax name)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (ParameterSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Parameter(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public ParameterSyntax Parameter(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.Parameter(default, typeReference, name);
		}
		
		public AssociationDeclarationSyntax AssociationDeclaration(Microsoft.CodeAnalysis.SyntaxList<AttributeSyntax> attribute, SyntaxToken kAssociation, QualifierSyntax source, SyntaxToken kWith, QualifierSyntax target, SyntaxToken tSemicolon)
		{
		    if (kAssociation == null) throw new ArgumentNullException(nameof(kAssociation));
		    if (kAssociation.GetKind() != MetaSyntaxKind.KAssociation) throw new ArgumentException(nameof(kAssociation));
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (kWith == null) throw new ArgumentNullException(nameof(kWith));
		    if (kWith.GetKind() != MetaSyntaxKind.KWith) throw new ArgumentException(nameof(kWith));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (AssociationDeclarationSyntax)MetaLanguage.Instance.InternalSyntaxFactory.AssociationDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (InternalSyntaxToken)kAssociation.Node, (Syntax.InternalSyntax.QualifierGreen)source.Green, (InternalSyntaxToken)kWith.Node, (Syntax.InternalSyntax.QualifierGreen)target.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public AssociationDeclarationSyntax AssociationDeclaration(QualifierSyntax source, QualifierSyntax target)
		{
			return this.AssociationDeclaration(default, this.Token(MetaSyntaxKind.KAssociation), source, this.Token(MetaSyntaxKind.KWith), target, this.Token(MetaSyntaxKind.TSemicolon));
		}
		
		public IdentifierSyntax Identifier(SyntaxToken identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)identifier.Node).CreateRed();
		}
		
		public LiteralSyntax Literal(NullLiteralSyntax nullLiteral)
		{
		    if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
		    return (LiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.NullLiteralGreen)nullLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(BooleanLiteralSyntax booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (LiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(IntegerLiteralSyntax integerLiteral)
		{
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    return (LiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.IntegerLiteralGreen)integerLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(DecimalLiteralSyntax decimalLiteral)
		{
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
		    return (LiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.DecimalLiteralGreen)decimalLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(ScientificLiteralSyntax scientificLiteral)
		{
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
		    return (LiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.ScientificLiteralGreen)scientificLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (LiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral(SyntaxToken kNull)
		{
		    if (kNull == null) throw new ArgumentNullException(nameof(kNull));
		    if (kNull.GetKind() != MetaSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
		    return (NullLiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.NullLiteral((InternalSyntaxToken)kNull.Node).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral()
		{
			return this.NullLiteral(this.Token(MetaSyntaxKind.KNull));
		}
		
		public BooleanLiteralSyntax BooleanLiteral(SyntaxToken booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (BooleanLiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.BooleanLiteral((InternalSyntaxToken)booleanLiteral.Node).CreateRed();
		}
		
		public IntegerLiteralSyntax IntegerLiteral(SyntaxToken lInteger)
		{
		    if (lInteger == null) throw new ArgumentNullException(nameof(lInteger));
		    if (lInteger.GetKind() != MetaSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
		    return (IntegerLiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.IntegerLiteral((InternalSyntaxToken)lInteger.Node).CreateRed();
		}
		
		public DecimalLiteralSyntax DecimalLiteral(SyntaxToken lDecimal)
		{
		    if (lDecimal == null) throw new ArgumentNullException(nameof(lDecimal));
		    if (lDecimal.GetKind() != MetaSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
		    return (DecimalLiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.DecimalLiteral((InternalSyntaxToken)lDecimal.Node).CreateRed();
		}
		
		public ScientificLiteralSyntax ScientificLiteral(SyntaxToken lScientific)
		{
		    if (lScientific == null) throw new ArgumentNullException(nameof(lScientific));
		    if (lScientific.GetKind() != MetaSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
		    return (ScientificLiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.ScientificLiteral((InternalSyntaxToken)lScientific.Node).CreateRed();
		}
		
		public StringLiteralSyntax StringLiteral(SyntaxToken lRegularString)
		{
		    if (lRegularString == null) throw new ArgumentNullException(nameof(lRegularString));
		    if (lRegularString.GetKind() != MetaSyntaxKind.LRegularString) throw new ArgumentException(nameof(lRegularString));
		    return (StringLiteralSyntax)MetaLanguage.Instance.InternalSyntaxFactory.StringLiteral((InternalSyntaxToken)lRegularString.Node).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(NameSyntax),
				typeof(QualifiedNameSyntax),
				typeof(QualifierSyntax),
				typeof(AttributeSyntax),
				typeof(UsingNamespaceOrMetamodelSyntax),
				typeof(UsingNamespaceSyntax),
				typeof(UsingMetamodelSyntax),
				typeof(UsingMetamodelReferenceSyntax),
				typeof(NamespaceDeclarationSyntax),
				typeof(NamespaceBodySyntax),
				typeof(MetamodelDeclarationSyntax),
				typeof(MetamodelPropertyListSyntax),
				typeof(MetamodelPropertySyntax),
				typeof(MetamodelUriPropertySyntax),
				typeof(MetamodelPrefixPropertySyntax),
				typeof(MajorVersionPropertySyntax),
				typeof(MinorVersionPropertySyntax),
				typeof(DeclarationSyntax),
				typeof(EnumDeclarationSyntax),
				typeof(EnumBodySyntax),
				typeof(EnumValuesSyntax),
				typeof(EnumValueSyntax),
				typeof(EnumMemberDeclarationSyntax),
				typeof(ClassDeclarationSyntax),
				typeof(SymbolAttributeSyntax),
				typeof(SymbolSymbolAttributeSyntax),
				typeof(ExpressionSymbolAttributeSyntax),
				typeof(StatementSymbolTypeAttributeSyntax),
				typeof(TypeSymbolTypeAttributeSyntax),
				typeof(ClassBodySyntax),
				typeof(ClassAncestorsSyntax),
				typeof(ClassAncestorSyntax),
				typeof(ClassMemberDeclarationSyntax),
				typeof(FieldDeclarationSyntax),
				typeof(FieldSymbolPropertyAttributeSyntax),
				typeof(FieldContainmentSyntax),
				typeof(FieldModifierSyntax),
				typeof(DefaultValueSyntax),
				typeof(RedefinitionsOrSubsettingsSyntax),
				typeof(RedefinitionsSyntax),
				typeof(SubsettingsSyntax),
				typeof(NameUseListSyntax),
				typeof(ConstDeclarationSyntax),
				typeof(ConstValueSyntax),
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
				typeof(OperationModifierSyntax),
				typeof(OperationModifierBuilderSyntax),
				typeof(OperationModifierReadonlySyntax),
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

