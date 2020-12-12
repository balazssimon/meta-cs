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

namespace MetaDslx.Languages.MetaCompiler.Syntax
{
    public abstract class MetaCompilerSyntaxNode : LanguageSyntaxNode
    {
        protected MetaCompilerSyntaxNode(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected MetaCompilerSyntaxNode(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new MetaCompilerLanguage Language => MetaCompilerLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new MetaCompilerSyntaxKind Kind => (MetaCompilerSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

        protected override SyntaxTree CreateSyntaxTreeForRoot()
        {
            return MetaCompilerSyntaxTree.CreateWithoutClone(this);
        }

        public override TResult Accept<TArg, TResult>(SyntaxVisitor<TArg, TResult> visitor, TArg argument)
        {
            if (visitor is IMetaCompilerSyntaxVisitor<TArg, TResult> typedVisitor) return this.Accept(typedVisitor, argument);
            else return visitor.DefaultVisit(this, argument);
        }

        public abstract TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument);

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            if (visitor is IMetaCompilerSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            if (visitor is IMetaCompilerSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }
        public abstract void Accept(IMetaCompilerSyntaxVisitor visitor);
    }

    /// <summary>
    /// It's a non terminal Trivia MetaCompilerSyntaxNode that has a tree underneath it.
    /// </summary>
    public abstract partial class MetaCompilerStructuredTriviaSyntax : MetaCompilerSyntaxNode, IStructuredTriviaSyntax
    {
        private SyntaxTrivia _parent;
        internal MetaCompilerStructuredTriviaSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
            : base(green, parent == null ? null : (MetaCompilerSyntaxTree)parent.SyntaxTree, position)
        {
            System.Diagnostics.Debug.Assert(parent == null || position >= 0);
        }
		internal static MetaCompilerStructuredTriviaSyntax Create(SyntaxTrivia trivia)
		{
			var red = (MetaCompilerStructuredTriviaSyntax)MetaCompilerLanguage.Instance.SyntaxFactory.CreateStructure(trivia);
			red._parent = trivia;
			return red;
		}
        /// <summary>
        /// Get parent trivia.
        /// </summary>
        public override SyntaxTrivia ParentTrivia => _parent;
    }

    public sealed partial class MetaCompilerSkippedTokensTriviaSyntax : MetaCompilerStructuredTriviaSyntax
    {
        internal MetaCompilerSkippedTokensTriviaSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public SyntaxTokenList Tokens 
        {
            get
            {
				var slot = ((global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.GreenSkippedTokensTriviaSyntax)this.Green).Tokens;
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

		public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
		{
			return visitor.VisitSkippedTokensTrivia(this, argument);
		}

		public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
        {
            return visitor.VisitSkippedTokensTrivia(this);
        }

        public override void Accept(IMetaCompilerSyntaxVisitor visitor)
        {
            visitor.VisitSkippedTokensTrivia(this);
        }

        public MetaCompilerSkippedTokensTriviaSyntax Update(SyntaxTokenList tokens)
        {
            if (tokens != this.Tokens)
            {
                var newNode = (MetaCompilerSkippedTokensTriviaSyntax)Language.SyntaxFactory.SkippedTokensTrivia(tokens);
                var annotations = this.GetAnnotations();
                if (annotations != null && annotations.Length > 0)
                    return newNode.WithAnnotations(annotations);
                return newNode;
            }
            return this;
        }

        public MetaCompilerSkippedTokensTriviaSyntax WithTokens(SyntaxTokenList tokens)
        {
            return this.Update(tokens);
        }

        public MetaCompilerSkippedTokensTriviaSyntax AddTokens(params SyntaxToken[] items)
        {
            return this.WithTokens(this.Tokens.AddRange(items));
        }
    }

	
	public sealed class MainSyntax : MetaCompilerSyntaxNode, ICompilationUnitSyntax
	{
	    private NamespaceDeclarationSyntax namespaceDeclaration;
	
	    public MainSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NamespaceDeclarationSyntax NamespaceDeclaration 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration, 0); } 
		}
	    public SyntaxToken EndOfFileToken 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.MainGreen)this.Green;
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
	
	    public MainSyntax WithNamespaceDeclaration(NamespaceDeclarationSyntax namespaceDeclaration)
		{
			return this.Update(NamespaceDeclaration, this.EndOfFileToken);
		}
	
	    public MainSyntax WithEndOfFileToken(SyntaxToken eOF)
		{
			return this.Update(this.NamespaceDeclaration, EndOfFileToken);
		}
	
	    public MainSyntax Update(NamespaceDeclarationSyntax namespaceDeclaration, SyntaxToken eOF)
	    {
	        if (this.NamespaceDeclaration != namespaceDeclaration ||
				this.EndOfFileToken != eOF)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Main(namespaceDeclaration, eOF);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class NameSyntax : MetaCompilerSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class QualifiedNameSyntax : MetaCompilerSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.QualifiedName(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifiedName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifiedName(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifiedName(this);
	    }
	}
	
	public sealed class QualifierSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public QualifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Qualifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifier(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifier(this);
	    }
	}
	
	public sealed class AttributeSyntax : MetaCompilerSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public AttributeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AttributeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.AttributeGreen)this.Green;
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
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.AttributeGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Attribute(tOpenBracket, qualifier, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AttributeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAttribute(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAttribute(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitAttribute(this);
	    }
	}
	
	public sealed class NamespaceDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBodySyntax namespaceBody;
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
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
	
	    public NamespaceDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
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
	
	    public NamespaceDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
	    {
	        if (this.Attribute != attribute ||
				this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody != namespaceBody)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.NamespaceDeclaration(attribute, kNamespace, qualifiedName, namespaceBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration(this);
	    }
	}
	
	public sealed class NamespaceBodySyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode declaration;
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
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
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.NamespaceBodyGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.NamespaceBody(tOpenBrace, declaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody(this);
	    }
	}
	
	public sealed class DeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private CompilerDeclarationSyntax compilerDeclaration;
	    private PhaseDeclarationSyntax phaseDeclaration;
	    private EnumDeclarationSyntax enumDeclaration;
	    private ClassDeclarationSyntax classDeclaration;
	    private TypedefDeclarationSyntax typedefDeclaration;
	
	    public DeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public CompilerDeclarationSyntax CompilerDeclaration 
		{ 
			get { return this.GetRed(ref this.compilerDeclaration, 0); } 
		}
	    public PhaseDeclarationSyntax PhaseDeclaration 
		{ 
			get { return this.GetRed(ref this.phaseDeclaration, 1); } 
		}
	    public EnumDeclarationSyntax EnumDeclaration 
		{ 
			get { return this.GetRed(ref this.enumDeclaration, 2); } 
		}
	    public ClassDeclarationSyntax ClassDeclaration 
		{ 
			get { return this.GetRed(ref this.classDeclaration, 3); } 
		}
	    public TypedefDeclarationSyntax TypedefDeclaration 
		{ 
			get { return this.GetRed(ref this.typedefDeclaration, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.compilerDeclaration, 0);
				case 1: return this.GetRed(ref this.phaseDeclaration, 1);
				case 2: return this.GetRed(ref this.enumDeclaration, 2);
				case 3: return this.GetRed(ref this.classDeclaration, 3);
				case 4: return this.GetRed(ref this.typedefDeclaration, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.compilerDeclaration;
				case 1: return this.phaseDeclaration;
				case 2: return this.enumDeclaration;
				case 3: return this.classDeclaration;
				case 4: return this.typedefDeclaration;
				default: return null;
	        }
	    }
	
	    public DeclarationSyntax WithCompilerDeclaration(CompilerDeclarationSyntax compilerDeclaration)
		{
			return this.Update(compilerDeclaration);
		}
	
	    public DeclarationSyntax WithPhaseDeclaration(PhaseDeclarationSyntax phaseDeclaration)
		{
			return this.Update(phaseDeclaration);
		}
	
	    public DeclarationSyntax WithEnumDeclaration(EnumDeclarationSyntax enumDeclaration)
		{
			return this.Update(enumDeclaration);
		}
	
	    public DeclarationSyntax WithClassDeclaration(ClassDeclarationSyntax classDeclaration)
		{
			return this.Update(classDeclaration);
		}
	
	    public DeclarationSyntax WithTypedefDeclaration(TypedefDeclarationSyntax typedefDeclaration)
		{
			return this.Update(typedefDeclaration);
		}
	
	    public DeclarationSyntax Update(CompilerDeclarationSyntax compilerDeclaration)
	    {
	        if (this.CompilerDeclaration != compilerDeclaration)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Declaration(compilerDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(PhaseDeclarationSyntax phaseDeclaration)
	    {
	        if (this.PhaseDeclaration != phaseDeclaration)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Declaration(phaseDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(EnumDeclarationSyntax enumDeclaration)
	    {
	        if (this.EnumDeclaration != enumDeclaration)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Declaration(enumDeclaration);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Declaration(classDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(TypedefDeclarationSyntax typedefDeclaration)
	    {
	        if (this.TypedefDeclaration != typedefDeclaration)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Declaration(typedefDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration(this);
	    }
	}
	
	public sealed class CompilerDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private NameSyntax name;
	
	    public CompilerDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CompilerDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KCompiler 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.CompilerDeclarationGreen)this.Green;
				var greenToken = green.KCompiler;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.CompilerDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 2: return this.GetRed(ref this.name, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 2: return this.name;
				default: return null;
	        }
	    }
	
	    public CompilerDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.KCompiler, this.Name, this.TSemicolon);
		}
	
	    public CompilerDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public CompilerDeclarationSyntax WithKCompiler(SyntaxToken kCompiler)
		{
			return this.Update(this.Attribute, KCompiler, this.Name, this.TSemicolon);
		}
	
	    public CompilerDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.KCompiler, Name, this.TSemicolon);
		}
	
	    public CompilerDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.KCompiler, this.Name, TSemicolon);
		}
	
	    public CompilerDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, SyntaxToken kCompiler, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.KCompiler != kCompiler ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.CompilerDeclaration(attribute, kCompiler, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CompilerDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCompilerDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCompilerDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitCompilerDeclaration(this);
	    }
	}
	
	public sealed class PhaseDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private NameSyntax name;
	    private PhaseJoinSyntax phaseJoin;
	    private AfterPhasesSyntax afterPhases;
	    private BeforePhasesSyntax beforePhases;
	
	    public PhaseDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PhaseDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KLocked 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.PhaseDeclarationGreen)this.Green;
				var greenToken = green.KLocked;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken KPhase 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.PhaseDeclarationGreen)this.Green;
				var greenToken = green.KPhase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 3); } 
		}
	    public PhaseJoinSyntax PhaseJoin 
		{ 
			get { return this.GetRed(ref this.phaseJoin, 4); } 
		}
	    public AfterPhasesSyntax AfterPhases 
		{ 
			get { return this.GetRed(ref this.afterPhases, 5); } 
		}
	    public BeforePhasesSyntax BeforePhases 
		{ 
			get { return this.GetRed(ref this.beforePhases, 6); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.PhaseDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(7), this.GetChildIndex(7));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 3: return this.GetRed(ref this.name, 3);
				case 4: return this.GetRed(ref this.phaseJoin, 4);
				case 5: return this.GetRed(ref this.afterPhases, 5);
				case 6: return this.GetRed(ref this.beforePhases, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 3: return this.name;
				case 4: return this.phaseJoin;
				case 5: return this.afterPhases;
				case 6: return this.beforePhases;
				default: return null;
	        }
	    }
	
	    public PhaseDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.KLocked, this.KPhase, this.Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public PhaseDeclarationSyntax WithKLocked(SyntaxToken kLocked)
		{
			return this.Update(this.Attribute, KLocked, this.KPhase, this.Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithKPhase(SyntaxToken kPhase)
		{
			return this.Update(this.Attribute, this.KLocked, KPhase, this.Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.KLocked, this.KPhase, Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithPhaseJoin(PhaseJoinSyntax phaseJoin)
		{
			return this.Update(this.Attribute, this.KLocked, this.KPhase, this.Name, PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithAfterPhases(AfterPhasesSyntax afterPhases)
		{
			return this.Update(this.Attribute, this.KLocked, this.KPhase, this.Name, this.PhaseJoin, AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithBeforePhases(BeforePhasesSyntax beforePhases)
		{
			return this.Update(this.Attribute, this.KLocked, this.KPhase, this.Name, this.PhaseJoin, this.AfterPhases, BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.KLocked, this.KPhase, this.Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, TSemicolon);
		}
	
	    public PhaseDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, SyntaxToken kLocked, SyntaxToken kPhase, NameSyntax name, PhaseJoinSyntax phaseJoin, AfterPhasesSyntax afterPhases, BeforePhasesSyntax beforePhases, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.KLocked != kLocked ||
				this.KPhase != kPhase ||
				this.Name != name ||
				this.PhaseJoin != phaseJoin ||
				this.AfterPhases != afterPhases ||
				this.BeforePhases != beforePhases ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.PhaseDeclaration(attribute, kLocked, kPhase, name, phaseJoin, afterPhases, beforePhases, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PhaseDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPhaseDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPhaseDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitPhaseDeclaration(this);
	    }
	}
	
	public sealed class PhaseJoinSyntax : MetaCompilerSyntaxNode
	{
	    private PhaseRefSyntax phaseRef;
	
	    public PhaseJoinSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PhaseJoinSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KJoins 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.PhaseJoinGreen)this.Green;
				var greenToken = green.KJoins;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public PhaseRefSyntax PhaseRef 
		{ 
			get { return this.GetRed(ref this.phaseRef, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.phaseRef, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.phaseRef;
				default: return null;
	        }
	    }
	
	    public PhaseJoinSyntax WithKJoins(SyntaxToken kJoins)
		{
			return this.Update(KJoins, this.PhaseRef);
		}
	
	    public PhaseJoinSyntax WithPhaseRef(PhaseRefSyntax phaseRef)
		{
			return this.Update(this.KJoins, PhaseRef);
		}
	
	    public PhaseJoinSyntax Update(SyntaxToken kJoins, PhaseRefSyntax phaseRef)
	    {
	        if (this.KJoins != kJoins ||
				this.PhaseRef != phaseRef)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.PhaseJoin(kJoins, phaseRef);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PhaseJoinSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPhaseJoin(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPhaseJoin(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitPhaseJoin(this);
	    }
	}
	
	public sealed class AfterPhasesSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode phaseRef;
	
	    public AfterPhasesSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AfterPhasesSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KAfter 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.AfterPhasesGreen)this.Green;
				var greenToken = green.KAfter;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SeparatedSyntaxList<PhaseRefSyntax> PhaseRef 
		{ 
			get
			{
				var red = this.GetRed(ref this.phaseRef, 1);
				if (red != null)
				{
					return new SeparatedSyntaxList<PhaseRefSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.phaseRef, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.phaseRef;
				default: return null;
	        }
	    }
	
	    public AfterPhasesSyntax WithKAfter(SyntaxToken kAfter)
		{
			return this.Update(KAfter, this.PhaseRef);
		}
	
	    public AfterPhasesSyntax WithPhaseRef(SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
		{
			return this.Update(this.KAfter, PhaseRef);
		}
	
	    public AfterPhasesSyntax AddPhaseRef(params PhaseRefSyntax[] phaseRef)
		{
			return this.WithPhaseRef(this.PhaseRef.AddRange(phaseRef));
		}
	
	    public AfterPhasesSyntax Update(SyntaxToken kAfter, SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
	    {
	        if (this.KAfter != kAfter ||
				this.PhaseRef != phaseRef)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.AfterPhases(kAfter, phaseRef);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AfterPhasesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAfterPhases(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAfterPhases(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitAfterPhases(this);
	    }
	}
	
	public sealed class BeforePhasesSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode phaseRef;
	
	    public BeforePhasesSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BeforePhasesSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KBefore 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.BeforePhasesGreen)this.Green;
				var greenToken = green.KBefore;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SeparatedSyntaxList<PhaseRefSyntax> PhaseRef 
		{ 
			get
			{
				var red = this.GetRed(ref this.phaseRef, 1);
				if (red != null)
				{
					return new SeparatedSyntaxList<PhaseRefSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.phaseRef, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.phaseRef;
				default: return null;
	        }
	    }
	
	    public BeforePhasesSyntax WithKBefore(SyntaxToken kBefore)
		{
			return this.Update(KBefore, this.PhaseRef);
		}
	
	    public BeforePhasesSyntax WithPhaseRef(SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
		{
			return this.Update(this.KBefore, PhaseRef);
		}
	
	    public BeforePhasesSyntax AddPhaseRef(params PhaseRefSyntax[] phaseRef)
		{
			return this.WithPhaseRef(this.PhaseRef.AddRange(phaseRef));
		}
	
	    public BeforePhasesSyntax Update(SyntaxToken kBefore, SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
	    {
	        if (this.KBefore != kBefore ||
				this.PhaseRef != phaseRef)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.BeforePhases(kBefore, phaseRef);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BeforePhasesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBeforePhases(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBeforePhases(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitBeforePhases(this);
	    }
	}
	
	public sealed class PhaseRefSyntax : MetaCompilerSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public PhaseRefSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PhaseRefSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	
	    public PhaseRefSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public PhaseRefSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.PhaseRef(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PhaseRefSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPhaseRef(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPhaseRef(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitPhaseRef(this);
	    }
	}
	
	public sealed class EnumDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private NameSyntax name;
	    private EnumBodySyntax enumBody;
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KEnum 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.EnumDeclarationGreen)this.Green;
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
	
	    public EnumDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
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
	
	    public EnumDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, SyntaxToken kEnum, NameSyntax name, EnumBodySyntax enumBody)
	    {
	        if (this.Attribute != attribute ||
				this.KEnum != kEnum ||
				this.Name != name ||
				this.EnumBody != enumBody)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.EnumDeclaration(attribute, kEnum, name, enumBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumDeclaration(this);
	    }
	}
	
	public sealed class EnumBodySyntax : MetaCompilerSyntaxNode
	{
	    private EnumValuesSyntax enumValues;
	    private SyntaxNode enumMemberDeclaration;
	
	    public EnumBodySyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumBodySyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
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
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public SyntaxList<EnumMemberDeclarationSyntax> EnumMemberDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.enumMemberDeclaration, 3);
				if (red != null) return new SyntaxList<EnumMemberDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.EnumBodyGreen)this.Green;
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
	
	    public EnumBodySyntax WithEnumMemberDeclaration(SyntaxList<EnumMemberDeclarationSyntax> enumMemberDeclaration)
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
	
	    public EnumBodySyntax Update(SyntaxToken tOpenBrace, EnumValuesSyntax enumValues, SyntaxToken tSemicolon, SyntaxList<EnumMemberDeclarationSyntax> enumMemberDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.EnumValues != enumValues ||
				this.TSemicolon != tSemicolon ||
				this.EnumMemberDeclaration != enumMemberDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumBody(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumBody(this);
	    }
	}
	
	public sealed class EnumValuesSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode enumValue;
	
	    public EnumValuesSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumValuesSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<EnumValueSyntax> EnumValue 
		{ 
			get
			{
				var red = this.GetRed(ref this.enumValue, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<EnumValueSyntax>(red, this.GetChildIndex(0));
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
	
	    public EnumValuesSyntax WithEnumValue(SeparatedSyntaxList<EnumValueSyntax> enumValue)
		{
			return this.Update(EnumValue);
		}
	
	    public EnumValuesSyntax AddEnumValue(params EnumValueSyntax[] enumValue)
		{
			return this.WithEnumValue(this.EnumValue.AddRange(enumValue));
		}
	
	    public EnumValuesSyntax Update(SeparatedSyntaxList<EnumValueSyntax> enumValue)
	    {
	        if (this.EnumValue != enumValue)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.EnumValues(enumValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumValuesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumValues(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumValues(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumValues(this);
	    }
	}
	
	public sealed class EnumValueSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private NameSyntax name;
	
	    public EnumValueSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumValueSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new SyntaxList<AttributeSyntax>(red);
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
	
	    public EnumValueSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
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
	
	    public EnumValueSyntax Update(SyntaxList<AttributeSyntax> attribute, NameSyntax name)
	    {
	        if (this.Attribute != attribute ||
				this.Name != name)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.EnumValue(attribute, name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumValue(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumValue(this);
	    }
	}
	
	public sealed class EnumMemberDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private OperationDeclarationSyntax operationDeclaration;
	
	    public EnumMemberDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumMemberDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.EnumMemberDeclaration(operationDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumMemberDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumMemberDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumMemberDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumMemberDeclaration(this);
	    }
	}
	
	public sealed class ClassDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private ClassKindSyntax classKind;
	    private NameSyntax name;
	    private ClassAncestorsSyntax classAncestors;
	    private ClassBodySyntax classBody;
	
	    public ClassDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KAbstract 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ClassDeclarationGreen)this.Green;
				var greenToken = green.KAbstract;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ClassKindSyntax ClassKind 
		{ 
			get { return this.GetRed(ref this.classKind, 2); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 3); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ClassDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
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
				case 0: return this.GetRed(ref this.attribute, 0);
				case 2: return this.GetRed(ref this.classKind, 2);
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
				case 0: return this.attribute;
				case 2: return this.classKind;
				case 3: return this.name;
				case 5: return this.classAncestors;
				case 6: return this.classBody;
				default: return null;
	        }
	    }
	
	    public ClassDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.KAbstract, this.ClassKind, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public ClassDeclarationSyntax WithKAbstract(SyntaxToken kAbstract)
		{
			return this.Update(this.Attribute, KAbstract, this.ClassKind, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassKind(ClassKindSyntax classKind)
		{
			return this.Update(this.Attribute, this.KAbstract, ClassKind, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.KAbstract, this.ClassKind, Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Attribute, this.KAbstract, this.ClassKind, this.Name, TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassAncestors(ClassAncestorsSyntax classAncestors)
		{
			return this.Update(this.Attribute, this.KAbstract, this.ClassKind, this.Name, this.TColon, ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassBody(ClassBodySyntax classBody)
		{
			return this.Update(this.Attribute, this.KAbstract, this.ClassKind, this.Name, this.TColon, this.ClassAncestors, ClassBody);
		}
	
	    public ClassDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, SyntaxToken kAbstract, ClassKindSyntax classKind, NameSyntax name, SyntaxToken tColon, ClassAncestorsSyntax classAncestors, ClassBodySyntax classBody)
	    {
	        if (this.Attribute != attribute ||
				this.KAbstract != kAbstract ||
				this.ClassKind != classKind ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ClassAncestors != classAncestors ||
				this.ClassBody != classBody)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassDeclaration(attribute, kAbstract, classKind, name, tColon, classAncestors, classBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitClassDeclaration(this);
	    }
	}
	
	public sealed class ClassAncestorsSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode classAncestor;
	
	    public ClassAncestorsSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassAncestorsSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<ClassAncestorSyntax> ClassAncestor 
		{ 
			get
			{
				var red = this.GetRed(ref this.classAncestor, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<ClassAncestorSyntax>(red, this.GetChildIndex(0));
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
	
	    public ClassAncestorsSyntax WithClassAncestor(SeparatedSyntaxList<ClassAncestorSyntax> classAncestor)
		{
			return this.Update(ClassAncestor);
		}
	
	    public ClassAncestorsSyntax AddClassAncestor(params ClassAncestorSyntax[] classAncestor)
		{
			return this.WithClassAncestor(this.ClassAncestor.AddRange(classAncestor));
		}
	
	    public ClassAncestorsSyntax Update(SeparatedSyntaxList<ClassAncestorSyntax> classAncestor)
	    {
	        if (this.ClassAncestor != classAncestor)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassAncestors(classAncestor);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassAncestorsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassAncestors(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassAncestors(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitClassAncestors(this);
	    }
	}
	
	public sealed class ClassAncestorSyntax : MetaCompilerSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public ClassAncestorSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassAncestorSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassAncestor(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassAncestorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassAncestor(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassAncestor(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitClassAncestor(this);
	    }
	}
	
	public sealed class ClassBodySyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode classMemberDeclaration;
	
	    public ClassBodySyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassBodySyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ClassBodyGreen)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<ClassMemberDeclarationSyntax> ClassMemberDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.classMemberDeclaration, 1);
				if (red != null) return new SyntaxList<ClassMemberDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ClassBodyGreen)this.Green;
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
	
	    public ClassBodySyntax WithClassMemberDeclaration(SyntaxList<ClassMemberDeclarationSyntax> classMemberDeclaration)
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
	
	    public ClassBodySyntax Update(SyntaxToken tOpenBrace, SyntaxList<ClassMemberDeclarationSyntax> classMemberDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ClassMemberDeclaration != classMemberDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassBody(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitClassBody(this);
	    }
	}
	
	public sealed class ClassMemberDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private FieldDeclarationSyntax fieldDeclaration;
	    private OperationDeclarationSyntax operationDeclaration;
	
	    public ClassMemberDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassMemberDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassMemberDeclaration(fieldDeclaration);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassMemberDeclaration(operationDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassMemberDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassMemberDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassMemberDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitClassMemberDeclaration(this);
	    }
	}
	
	public sealed class ClassKindSyntax : MetaCompilerSyntaxNode
	{
	
	    public ClassKindSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassKindSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ClassKind 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ClassKindGreen)this.Green;
				var greenToken = green.ClassKind;
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
	
	    public ClassKindSyntax WithClassKind(SyntaxToken classKind)
		{
			return this.Update(ClassKind);
		}
	
	    public ClassKindSyntax Update(SyntaxToken classKind)
	    {
	        if (this.ClassKind != classKind)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassKind(classKind);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassKindSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassKind(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassKind(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitClassKind(this);
	    }
	}
	
	public sealed class FieldDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private FieldContainmentSyntax fieldContainment;
	    private FieldModifierSyntax fieldModifier;
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	    private DefaultValueSyntax defaultValue;
	    private PhaseSyntax phase;
	
	    public FieldDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public FieldContainmentSyntax FieldContainment 
		{ 
			get { return this.GetRed(ref this.fieldContainment, 1); } 
		}
	    public FieldModifierSyntax FieldModifier 
		{ 
			get { return this.GetRed(ref this.fieldModifier, 2); } 
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 3); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 4); } 
		}
	    public DefaultValueSyntax DefaultValue 
		{ 
			get { return this.GetRed(ref this.defaultValue, 5); } 
		}
	    public PhaseSyntax Phase 
		{ 
			get { return this.GetRed(ref this.phase, 6); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.FieldDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(7), this.GetChildIndex(7));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.fieldContainment, 1);
				case 2: return this.GetRed(ref this.fieldModifier, 2);
				case 3: return this.GetRed(ref this.typeReference, 3);
				case 4: return this.GetRed(ref this.name, 4);
				case 5: return this.GetRed(ref this.defaultValue, 5);
				case 6: return this.GetRed(ref this.phase, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 1: return this.fieldContainment;
				case 2: return this.fieldModifier;
				case 3: return this.typeReference;
				case 4: return this.name;
				case 5: return this.defaultValue;
				case 6: return this.phase;
				default: return null;
	        }
	    }
	
	    public FieldDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.FieldContainment, this.FieldModifier, this.TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public FieldDeclarationSyntax WithFieldContainment(FieldContainmentSyntax fieldContainment)
		{
			return this.Update(this.Attribute, FieldContainment, this.FieldModifier, this.TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithFieldModifier(FieldModifierSyntax fieldModifier)
		{
			return this.Update(this.Attribute, this.FieldContainment, FieldModifier, this.TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Attribute, this.FieldContainment, this.FieldModifier, TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.FieldContainment, this.FieldModifier, this.TypeReference, Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithDefaultValue(DefaultValueSyntax defaultValue)
		{
			return this.Update(this.Attribute, this.FieldContainment, this.FieldModifier, this.TypeReference, this.Name, DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithPhase(PhaseSyntax phase)
		{
			return this.Update(this.Attribute, this.FieldContainment, this.FieldModifier, this.TypeReference, this.Name, this.DefaultValue, Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.FieldContainment, this.FieldModifier, this.TypeReference, this.Name, this.DefaultValue, this.Phase, TSemicolon);
		}
	
	    public FieldDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, FieldContainmentSyntax fieldContainment, FieldModifierSyntax fieldModifier, TypeReferenceSyntax typeReference, NameSyntax name, DefaultValueSyntax defaultValue, PhaseSyntax phase, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.FieldContainment != fieldContainment ||
				this.FieldModifier != fieldModifier ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.DefaultValue != defaultValue ||
				this.Phase != phase ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.FieldDeclaration(attribute, fieldContainment, fieldModifier, typeReference, name, defaultValue, phase, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldDeclaration(this);
	    }
	}
	
	public sealed class FieldContainmentSyntax : MetaCompilerSyntaxNode
	{
	
	    public FieldContainmentSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldContainmentSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KContainment 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.FieldContainmentGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.FieldContainment(kContainment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldContainmentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldContainment(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldContainment(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldContainment(this);
	    }
	}
	
	public sealed class FieldModifierSyntax : MetaCompilerSyntaxNode
	{
	
	    public FieldModifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldModifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken FieldModifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.FieldModifierGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.FieldModifier(fieldModifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldModifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldModifier(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldModifier(this);
	    }
	}
	
	public sealed class DefaultValueSyntax : MetaCompilerSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public DefaultValueSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DefaultValueSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.DefaultValueGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.DefaultValue(tAssign, stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefaultValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDefaultValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDefaultValue(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitDefaultValue(this);
	    }
	}
	
	public sealed class PhaseSyntax : MetaCompilerSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public PhaseSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PhaseSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KPhase 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.PhaseGreen)this.Green;
				var greenToken = green.KPhase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 1); } 
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
	
	    public PhaseSyntax WithKPhase(SyntaxToken kPhase)
		{
			return this.Update(KPhase, this.Qualifier);
		}
	
	    public PhaseSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KPhase, Qualifier);
		}
	
	    public PhaseSyntax Update(SyntaxToken kPhase, QualifierSyntax qualifier)
	    {
	        if (this.KPhase != kPhase ||
				this.Qualifier != qualifier)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Phase(kPhase, qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PhaseSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPhase(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPhase(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitPhase(this);
	    }
	}
	
	public sealed class NameUseListSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode qualifier;
	
	    public NameUseListSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameUseListSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	
	    public NameUseListSyntax WithQualifier(SeparatedSyntaxList<QualifierSyntax> qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public NameUseListSyntax AddQualifier(params QualifierSyntax[] qualifier)
		{
			return this.WithQualifier(this.Qualifier.AddRange(qualifier));
		}
	
	    public NameUseListSyntax Update(SeparatedSyntaxList<QualifierSyntax> qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.NameUseList(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameUseListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNameUseList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNameUseList(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitNameUseList(this);
	    }
	}
	
	public sealed class TypedefDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private NameSyntax name;
	    private TypedefValueSyntax typedefValue;
	
	    public TypedefDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypedefDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTypeDef 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.TypedefDeclarationGreen)this.Green;
				var greenToken = green.KTypeDef;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public TypedefValueSyntax TypedefValue 
		{ 
			get { return this.GetRed(ref this.typedefValue, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.TypedefDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 2: return this.GetRed(ref this.typedefValue, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 2: return this.typedefValue;
				default: return null;
	        }
	    }
	
	    public TypedefDeclarationSyntax WithKTypeDef(SyntaxToken kTypeDef)
		{
			return this.Update(KTypeDef, this.Name, this.TypedefValue, this.TSemicolon);
		}
	
	    public TypedefDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KTypeDef, Name, this.TypedefValue, this.TSemicolon);
		}
	
	    public TypedefDeclarationSyntax WithTypedefValue(TypedefValueSyntax typedefValue)
		{
			return this.Update(this.KTypeDef, this.Name, TypedefValue, this.TSemicolon);
		}
	
	    public TypedefDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KTypeDef, this.Name, this.TypedefValue, TSemicolon);
		}
	
	    public TypedefDeclarationSyntax Update(SyntaxToken kTypeDef, NameSyntax name, TypedefValueSyntax typedefValue, SyntaxToken tSemicolon)
	    {
	        if (this.KTypeDef != kTypeDef ||
				this.Name != name ||
				this.TypedefValue != typedefValue ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.TypedefDeclaration(kTypeDef, name, typedefValue, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypedefDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypedefDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypedefDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitTypedefDeclaration(this);
	    }
	}
	
	public sealed class TypedefValueSyntax : MetaCompilerSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public TypedefValueSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypedefValueSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.TypedefValueGreen)this.Green;
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
	
	    public TypedefValueSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(TAssign, this.StringLiteral);
		}
	
	    public TypedefValueSyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(this.TAssign, StringLiteral);
		}
	
	    public TypedefValueSyntax Update(SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
	    {
	        if (this.TAssign != tAssign ||
				this.StringLiteral != stringLiteral)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.TypedefValue(tAssign, stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypedefValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypedefValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypedefValue(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitTypedefValue(this);
	    }
	}
	
	public sealed class ReturnTypeSyntax : MetaCompilerSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private VoidTypeSyntax voidType;
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ReturnType(typeReference);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ReturnType(voidType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitReturnType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReturnType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitReturnType(this);
	    }
	}
	
	public sealed class TypeOfReferenceSyntax : MetaCompilerSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	
	    public TypeOfReferenceSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeOfReferenceSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.TypeOfReference(typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeOfReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeOfReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeOfReference(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeOfReference(this);
	    }
	}
	
	public sealed class TypeReferenceSyntax : MetaCompilerSyntaxNode
	{
	    private GenericTypeSyntax genericType;
	    private SimpleTypeSyntax simpleType;
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public GenericTypeSyntax GenericType 
		{ 
			get { return this.GetRed(ref this.genericType, 0); } 
		}
	    public SimpleTypeSyntax SimpleType 
		{ 
			get { return this.GetRed(ref this.simpleType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.genericType, 0);
				case 1: return this.GetRed(ref this.simpleType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.genericType;
				case 1: return this.simpleType;
				default: return null;
	        }
	    }
	
	    public TypeReferenceSyntax WithGenericType(GenericTypeSyntax genericType)
		{
			return this.Update(genericType);
		}
	
	    public TypeReferenceSyntax WithSimpleType(SimpleTypeSyntax simpleType)
		{
			return this.Update(simpleType);
		}
	
	    public TypeReferenceSyntax Update(GenericTypeSyntax genericType)
	    {
	        if (this.GenericType != genericType)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.TypeReference(genericType);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.TypeReference(simpleType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeReference(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeReference(this);
	    }
	}
	
	public sealed class SimpleTypeSyntax : MetaCompilerSyntaxNode
	{
	    private PrimitiveTypeSyntax primitiveType;
	    private ObjectTypeSyntax objectType;
	    private NullableTypeSyntax nullableType;
	    private ClassTypeSyntax classType;
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleType(primitiveType);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleType(objectType);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleType(nullableType);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleType(classType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleType(this);
	    }
	}
	
	public sealed class ClassTypeSyntax : MetaCompilerSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public ClassTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassType(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitClassType(this);
	    }
	}
	
	public sealed class ObjectTypeSyntax : MetaCompilerSyntaxNode
	{
	
	    public ObjectTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ObjectTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ObjectType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ObjectTypeGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ObjectType(objectType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitObjectType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitObjectType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitObjectType(this);
	    }
	}
	
	public sealed class PrimitiveTypeSyntax : MetaCompilerSyntaxNode
	{
	
	    public PrimitiveTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PrimitiveTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken PrimitiveType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.PrimitiveTypeGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.PrimitiveType(primitiveType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PrimitiveTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPrimitiveType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPrimitiveType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitPrimitiveType(this);
	    }
	}
	
	public sealed class VoidTypeSyntax : MetaCompilerSyntaxNode
	{
	
	    public VoidTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VoidTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVoid 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.VoidTypeGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.VoidType(kVoid);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VoidTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVoidType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVoidType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitVoidType(this);
	    }
	}
	
	public sealed class NullableTypeSyntax : MetaCompilerSyntaxNode
	{
	    private PrimitiveTypeSyntax primitiveType;
	
	    public NullableTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullableTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.NullableTypeGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.NullableType(primitiveType, tQuestion);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullableType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullableType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitNullableType(this);
	    }
	}
	
	public sealed class GenericTypeSyntax : MetaCompilerSyntaxNode
	{
	    private GenericTypeNameSyntax genericTypeName;
	    private TypeArgumentsSyntax typeArguments;
	
	    public GenericTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GenericTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public GenericTypeNameSyntax GenericTypeName 
		{ 
			get { return this.GetRed(ref this.genericTypeName, 0); } 
		}
	    public SyntaxToken TLessThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.GenericTypeGreen)this.Green;
				var greenToken = green.TLessThan;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeArgumentsSyntax TypeArguments 
		{ 
			get { return this.GetRed(ref this.typeArguments, 2); } 
		}
	    public SyntaxToken TGreaterThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.GenericTypeGreen)this.Green;
				var greenToken = green.TGreaterThan;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.genericTypeName, 0);
				case 2: return this.GetRed(ref this.typeArguments, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.genericTypeName;
				case 2: return this.typeArguments;
				default: return null;
	        }
	    }
	
	    public GenericTypeSyntax WithGenericTypeName(GenericTypeNameSyntax genericTypeName)
		{
			return this.Update(GenericTypeName, this.TLessThan, this.TypeArguments, this.TGreaterThan);
		}
	
	    public GenericTypeSyntax WithTLessThan(SyntaxToken tLessThan)
		{
			return this.Update(this.GenericTypeName, TLessThan, this.TypeArguments, this.TGreaterThan);
		}
	
	    public GenericTypeSyntax WithTypeArguments(TypeArgumentsSyntax typeArguments)
		{
			return this.Update(this.GenericTypeName, this.TLessThan, TypeArguments, this.TGreaterThan);
		}
	
	    public GenericTypeSyntax WithTGreaterThan(SyntaxToken tGreaterThan)
		{
			return this.Update(this.GenericTypeName, this.TLessThan, this.TypeArguments, TGreaterThan);
		}
	
	    public GenericTypeSyntax Update(GenericTypeNameSyntax genericTypeName, SyntaxToken tLessThan, TypeArgumentsSyntax typeArguments, SyntaxToken tGreaterThan)
	    {
	        if (this.GenericTypeName != genericTypeName ||
				this.TLessThan != tLessThan ||
				this.TypeArguments != typeArguments ||
				this.TGreaterThan != tGreaterThan)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.GenericType(genericTypeName, tLessThan, typeArguments, tGreaterThan);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGenericType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGenericType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitGenericType(this);
	    }
	}
	
	public sealed class GenericTypeNameSyntax : MetaCompilerSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public GenericTypeNameSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GenericTypeNameSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	
	    public GenericTypeNameSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public GenericTypeNameSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.GenericTypeName(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGenericTypeName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGenericTypeName(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitGenericTypeName(this);
	    }
	}
	
	public sealed class TypeArgumentsSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode typeArgument;
	
	    public TypeArgumentsSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeArgumentsSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<TypeArgumentSyntax> TypeArgument 
		{ 
			get
			{
				var red = this.GetRed(ref this.typeArgument, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<TypeArgumentSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeArgument, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeArgument;
				default: return null;
	        }
	    }
	
	    public TypeArgumentsSyntax WithTypeArgument(SeparatedSyntaxList<TypeArgumentSyntax> typeArgument)
		{
			return this.Update(TypeArgument);
		}
	
	    public TypeArgumentsSyntax AddTypeArgument(params TypeArgumentSyntax[] typeArgument)
		{
			return this.WithTypeArgument(this.TypeArgument.AddRange(typeArgument));
		}
	
	    public TypeArgumentsSyntax Update(SeparatedSyntaxList<TypeArgumentSyntax> typeArgument)
	    {
	        if (this.TypeArgument != typeArgument)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.TypeArguments(typeArgument);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeArgumentsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeArguments(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeArguments(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeArguments(this);
	    }
	}
	
	public sealed class TypeArgumentSyntax : MetaCompilerSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public TypeArgumentSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeArgumentSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	
	    public TypeArgumentSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public TypeArgumentSyntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.TypeArgument(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeArgumentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeArgument(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeArgument(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeArgument(this);
	    }
	}
	
	public sealed class OperationDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private ReturnTypeSyntax returnType;
	    private NameSyntax name;
	    private ParameterListSyntax parameterList;
	
	    public OperationDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OperationDeclarationSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new SyntaxList<AttributeSyntax>(red);
				return default;
			} 
		}
	    public ReturnTypeSyntax ReturnType 
		{ 
			get { return this.GetRed(ref this.returnType, 1); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 2); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
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
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.returnType, 1);
				case 2: return this.GetRed(ref this.name, 2);
				case 4: return this.GetRed(ref this.parameterList, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 1: return this.returnType;
				case 2: return this.name;
				case 4: return this.parameterList;
				default: return null;
	        }
	    }
	
	    public OperationDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public OperationDeclarationSyntax WithReturnType(ReturnTypeSyntax returnType)
		{
			return this.Update(this.Attribute, ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.ReturnType, Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Attribute, this.ReturnType, this.Name, TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithParameterList(ParameterListSyntax parameterList)
		{
			return this.Update(this.Attribute, this.ReturnType, this.Name, this.TOpenParen, ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Attribute, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, TSemicolon);
		}
	
	    public OperationDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, ReturnTypeSyntax returnType, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.ReturnType != returnType ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.ParameterList != parameterList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.OperationDeclaration(attribute, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OperationDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOperationDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOperationDeclaration(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitOperationDeclaration(this);
	    }
	}
	
	public sealed class ParameterListSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode parameter;
	
	    public ParameterListSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParameterListSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ParameterList(parameter);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParameterList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParameterList(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParameterList(this);
	    }
	}
	
	public sealed class ParameterSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private TypeReferenceSyntax typeReference;
	    private NameSyntax name;
	
	    public ParameterSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParameterSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<AttributeSyntax> Attribute 
		{ 
			get
			{
				var red = this.GetRed(ref this.attribute, 0);
				if (red != null) return new SyntaxList<AttributeSyntax>(red);
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
	
	    public ParameterSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
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
	
	    public ParameterSyntax Update(SyntaxList<AttributeSyntax> attribute, TypeReferenceSyntax typeReference, NameSyntax name)
	    {
	        if (this.Attribute != attribute ||
				this.TypeReference != typeReference ||
				this.Name != name)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Parameter(attribute, typeReference, name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParameter(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParameter(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParameter(this);
	    }
	}
	
	public sealed class IdentifierSyntax : MetaCompilerSyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Identifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.IdentifierGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Identifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class LiteralSyntax : MetaCompilerSyntaxNode
	{
	    private NullLiteralSyntax nullLiteral;
	    private BooleanLiteralSyntax booleanLiteral;
	    private IntegerLiteralSyntax integerLiteral;
	    private DecimalLiteralSyntax decimalLiteral;
	    private ScientificLiteralSyntax scientificLiteral;
	    private StringLiteralSyntax stringLiteral;
	
	    public LiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Literal(nullLiteral);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Literal(booleanLiteral);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Literal(integerLiteral);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Literal(decimalLiteral);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Literal(scientificLiteral);
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Literal(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteral(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteral(this);
	    }
	}
	
	public sealed class NullLiteralSyntax : MetaCompilerSyntaxNode
	{
	
	    public NullLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNull 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.NullLiteralGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.NullLiteral(kNull);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullLiteral(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitNullLiteral(this);
	    }
	}
	
	public sealed class BooleanLiteralSyntax : MetaCompilerSyntaxNode
	{
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BooleanLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.BooleanLiteralGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.BooleanLiteral(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BooleanLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBooleanLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBooleanLiteral(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitBooleanLiteral(this);
	    }
	}
	
	public sealed class IntegerLiteralSyntax : MetaCompilerSyntaxNode
	{
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LInteger 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.IntegerLiteralGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.IntegerLiteral(lInteger);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIntegerLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIntegerLiteral(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitIntegerLiteral(this);
	    }
	}
	
	public sealed class DecimalLiteralSyntax : MetaCompilerSyntaxNode
	{
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LDecimal 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.DecimalLiteralGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.DecimalLiteral(lDecimal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DecimalLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDecimalLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDecimalLiteral(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitDecimalLiteral(this);
	    }
	}
	
	public sealed class ScientificLiteralSyntax : MetaCompilerSyntaxNode
	{
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LScientific 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ScientificLiteralGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ScientificLiteral(lScientific);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ScientificLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitScientificLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitScientificLiteral(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitScientificLiteral(this);
	    }
	}
	
	public sealed class StringLiteralSyntax : MetaCompilerSyntaxNode
	{
	
	    public StringLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringLiteralSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LRegularString 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.StringLiteralGreen)this.Green;
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
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.StringLiteral(lRegularString);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStringLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStringLiteral(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitStringLiteral(this);
	    }
	}
}

namespace MetaDslx.Languages.MetaCompiler
{
    using System.Threading;
    using Microsoft.CodeAnalysis.Text;
	using MetaDslx.Languages.MetaCompiler.Syntax;
    using MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax;

	public interface IMetaCompilerSyntaxVisitor
	{
	    void VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node);
		
		void VisitMain(MainSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitAttribute(AttributeSyntax node);
		
		void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		void VisitNamespaceBody(NamespaceBodySyntax node);
		
		void VisitDeclaration(DeclarationSyntax node);
		
		void VisitCompilerDeclaration(CompilerDeclarationSyntax node);
		
		void VisitPhaseDeclaration(PhaseDeclarationSyntax node);
		
		void VisitPhaseJoin(PhaseJoinSyntax node);
		
		void VisitAfterPhases(AfterPhasesSyntax node);
		
		void VisitBeforePhases(BeforePhasesSyntax node);
		
		void VisitPhaseRef(PhaseRefSyntax node);
		
		void VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		void VisitEnumBody(EnumBodySyntax node);
		
		void VisitEnumValues(EnumValuesSyntax node);
		
		void VisitEnumValue(EnumValueSyntax node);
		
		void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node);
		
		void VisitClassDeclaration(ClassDeclarationSyntax node);
		
		void VisitClassAncestors(ClassAncestorsSyntax node);
		
		void VisitClassAncestor(ClassAncestorSyntax node);
		
		void VisitClassBody(ClassBodySyntax node);
		
		void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node);
		
		void VisitClassKind(ClassKindSyntax node);
		
		void VisitFieldDeclaration(FieldDeclarationSyntax node);
		
		void VisitFieldContainment(FieldContainmentSyntax node);
		
		void VisitFieldModifier(FieldModifierSyntax node);
		
		void VisitDefaultValue(DefaultValueSyntax node);
		
		void VisitPhase(PhaseSyntax node);
		
		void VisitNameUseList(NameUseListSyntax node);
		
		void VisitTypedefDeclaration(TypedefDeclarationSyntax node);
		
		void VisitTypedefValue(TypedefValueSyntax node);
		
		void VisitReturnType(ReturnTypeSyntax node);
		
		void VisitTypeOfReference(TypeOfReferenceSyntax node);
		
		void VisitTypeReference(TypeReferenceSyntax node);
		
		void VisitSimpleType(SimpleTypeSyntax node);
		
		void VisitClassType(ClassTypeSyntax node);
		
		void VisitObjectType(ObjectTypeSyntax node);
		
		void VisitPrimitiveType(PrimitiveTypeSyntax node);
		
		void VisitVoidType(VoidTypeSyntax node);
		
		void VisitNullableType(NullableTypeSyntax node);
		
		void VisitGenericType(GenericTypeSyntax node);
		
		void VisitGenericTypeName(GenericTypeNameSyntax node);
		
		void VisitTypeArguments(TypeArgumentsSyntax node);
		
		void VisitTypeArgument(TypeArgumentSyntax node);
		
		void VisitOperationDeclaration(OperationDeclarationSyntax node);
		
		void VisitParameterList(ParameterListSyntax node);
		
		void VisitParameter(ParameterSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitLiteral(LiteralSyntax node);
		
		void VisitNullLiteral(NullLiteralSyntax node);
		
		void VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		void VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		void VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		void VisitScientificLiteral(ScientificLiteralSyntax node);
		
		void VisitStringLiteral(StringLiteralSyntax node);
	}
	
	public class MetaCompilerSyntaxVisitor : SyntaxVisitor, IMetaCompilerSyntaxVisitor
	{
	    public virtual void VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node)
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
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
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
		
		public virtual void VisitCompilerDeclaration(CompilerDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPhaseDeclaration(PhaseDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPhaseJoin(PhaseJoinSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAfterPhases(AfterPhasesSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBeforePhases(BeforePhasesSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPhaseRef(PhaseRefSyntax node)
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
		
		public virtual void VisitClassAncestors(ClassAncestorsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassAncestor(ClassAncestorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassBody(ClassBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassKind(ClassKindSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFieldDeclaration(FieldDeclarationSyntax node)
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
		
		public virtual void VisitPhase(PhaseSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNameUseList(NameUseListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypedefDeclaration(TypedefDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypedefValue(TypedefValueSyntax node)
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
		
		public virtual void VisitGenericType(GenericTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitGenericTypeName(GenericTypeNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeArguments(TypeArgumentsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeArgument(TypeArgumentSyntax node)
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

	public interface IMetaCompilerSyntaxVisitor<TArg, TResult> 
	{
	    TResult VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node, TArg argument);
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitName(NameSyntax node, TArg argument);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument);
		
		TResult VisitQualifier(QualifierSyntax node, TArg argument);
		
		TResult VisitAttribute(AttributeSyntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node, TArg argument);
		
		TResult VisitDeclaration(DeclarationSyntax node, TArg argument);
		
		TResult VisitCompilerDeclaration(CompilerDeclarationSyntax node, TArg argument);
		
		TResult VisitPhaseDeclaration(PhaseDeclarationSyntax node, TArg argument);
		
		TResult VisitPhaseJoin(PhaseJoinSyntax node, TArg argument);
		
		TResult VisitAfterPhases(AfterPhasesSyntax node, TArg argument);
		
		TResult VisitBeforePhases(BeforePhasesSyntax node, TArg argument);
		
		TResult VisitPhaseRef(PhaseRefSyntax node, TArg argument);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node, TArg argument);
		
		TResult VisitEnumBody(EnumBodySyntax node, TArg argument);
		
		TResult VisitEnumValues(EnumValuesSyntax node, TArg argument);
		
		TResult VisitEnumValue(EnumValueSyntax node, TArg argument);
		
		TResult VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node, TArg argument);
		
		TResult VisitClassDeclaration(ClassDeclarationSyntax node, TArg argument);
		
		TResult VisitClassAncestors(ClassAncestorsSyntax node, TArg argument);
		
		TResult VisitClassAncestor(ClassAncestorSyntax node, TArg argument);
		
		TResult VisitClassBody(ClassBodySyntax node, TArg argument);
		
		TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node, TArg argument);
		
		TResult VisitClassKind(ClassKindSyntax node, TArg argument);
		
		TResult VisitFieldDeclaration(FieldDeclarationSyntax node, TArg argument);
		
		TResult VisitFieldContainment(FieldContainmentSyntax node, TArg argument);
		
		TResult VisitFieldModifier(FieldModifierSyntax node, TArg argument);
		
		TResult VisitDefaultValue(DefaultValueSyntax node, TArg argument);
		
		TResult VisitPhase(PhaseSyntax node, TArg argument);
		
		TResult VisitNameUseList(NameUseListSyntax node, TArg argument);
		
		TResult VisitTypedefDeclaration(TypedefDeclarationSyntax node, TArg argument);
		
		TResult VisitTypedefValue(TypedefValueSyntax node, TArg argument);
		
		TResult VisitReturnType(ReturnTypeSyntax node, TArg argument);
		
		TResult VisitTypeOfReference(TypeOfReferenceSyntax node, TArg argument);
		
		TResult VisitTypeReference(TypeReferenceSyntax node, TArg argument);
		
		TResult VisitSimpleType(SimpleTypeSyntax node, TArg argument);
		
		TResult VisitClassType(ClassTypeSyntax node, TArg argument);
		
		TResult VisitObjectType(ObjectTypeSyntax node, TArg argument);
		
		TResult VisitPrimitiveType(PrimitiveTypeSyntax node, TArg argument);
		
		TResult VisitVoidType(VoidTypeSyntax node, TArg argument);
		
		TResult VisitNullableType(NullableTypeSyntax node, TArg argument);
		
		TResult VisitGenericType(GenericTypeSyntax node, TArg argument);
		
		TResult VisitGenericTypeName(GenericTypeNameSyntax node, TArg argument);
		
		TResult VisitTypeArguments(TypeArgumentsSyntax node, TArg argument);
		
		TResult VisitTypeArgument(TypeArgumentSyntax node, TArg argument);
		
		TResult VisitOperationDeclaration(OperationDeclarationSyntax node, TArg argument);
		
		TResult VisitParameterList(ParameterListSyntax node, TArg argument);
		
		TResult VisitParameter(ParameterSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
		TResult VisitLiteral(LiteralSyntax node, TArg argument);
		
		TResult VisitNullLiteral(NullLiteralSyntax node, TArg argument);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node, TArg argument);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node, TArg argument);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node, TArg argument);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node, TArg argument);
		
		TResult VisitStringLiteral(StringLiteralSyntax node, TArg argument);
	}
	
	public class MetaCompilerSyntaxVisitor<TArg, TResult> : SyntaxVisitor<TArg, TResult>, IMetaCompilerSyntaxVisitor<TArg, TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node, TArg argument)
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
		
		public virtual TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument)
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
		
		public virtual TResult VisitCompilerDeclaration(CompilerDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPhaseDeclaration(PhaseDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPhaseJoin(PhaseJoinSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAfterPhases(AfterPhasesSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBeforePhases(BeforePhasesSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPhaseRef(PhaseRefSyntax node, TArg argument)
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
		
		public virtual TResult VisitClassAncestors(ClassAncestorsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassAncestor(ClassAncestorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassBody(ClassBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassKind(ClassKindSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFieldDeclaration(FieldDeclarationSyntax node, TArg argument)
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
		
		public virtual TResult VisitPhase(PhaseSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNameUseList(NameUseListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypedefDeclaration(TypedefDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypedefValue(TypedefValueSyntax node, TArg argument)
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
		
		public virtual TResult VisitGenericType(GenericTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitGenericTypeName(GenericTypeNameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeArguments(TypeArgumentsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeArgument(TypeArgumentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOperationDeclaration(OperationDeclarationSyntax node, TArg argument)
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

	public interface IMetaCompilerSyntaxVisitor<TResult> 
	{
	    TResult VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node);
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitAttribute(AttributeSyntax node);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node);
		
		TResult VisitDeclaration(DeclarationSyntax node);
		
		TResult VisitCompilerDeclaration(CompilerDeclarationSyntax node);
		
		TResult VisitPhaseDeclaration(PhaseDeclarationSyntax node);
		
		TResult VisitPhaseJoin(PhaseJoinSyntax node);
		
		TResult VisitAfterPhases(AfterPhasesSyntax node);
		
		TResult VisitBeforePhases(BeforePhasesSyntax node);
		
		TResult VisitPhaseRef(PhaseRefSyntax node);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		TResult VisitEnumBody(EnumBodySyntax node);
		
		TResult VisitEnumValues(EnumValuesSyntax node);
		
		TResult VisitEnumValue(EnumValueSyntax node);
		
		TResult VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node);
		
		TResult VisitClassDeclaration(ClassDeclarationSyntax node);
		
		TResult VisitClassAncestors(ClassAncestorsSyntax node);
		
		TResult VisitClassAncestor(ClassAncestorSyntax node);
		
		TResult VisitClassBody(ClassBodySyntax node);
		
		TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node);
		
		TResult VisitClassKind(ClassKindSyntax node);
		
		TResult VisitFieldDeclaration(FieldDeclarationSyntax node);
		
		TResult VisitFieldContainment(FieldContainmentSyntax node);
		
		TResult VisitFieldModifier(FieldModifierSyntax node);
		
		TResult VisitDefaultValue(DefaultValueSyntax node);
		
		TResult VisitPhase(PhaseSyntax node);
		
		TResult VisitNameUseList(NameUseListSyntax node);
		
		TResult VisitTypedefDeclaration(TypedefDeclarationSyntax node);
		
		TResult VisitTypedefValue(TypedefValueSyntax node);
		
		TResult VisitReturnType(ReturnTypeSyntax node);
		
		TResult VisitTypeOfReference(TypeOfReferenceSyntax node);
		
		TResult VisitTypeReference(TypeReferenceSyntax node);
		
		TResult VisitSimpleType(SimpleTypeSyntax node);
		
		TResult VisitClassType(ClassTypeSyntax node);
		
		TResult VisitObjectType(ObjectTypeSyntax node);
		
		TResult VisitPrimitiveType(PrimitiveTypeSyntax node);
		
		TResult VisitVoidType(VoidTypeSyntax node);
		
		TResult VisitNullableType(NullableTypeSyntax node);
		
		TResult VisitGenericType(GenericTypeSyntax node);
		
		TResult VisitGenericTypeName(GenericTypeNameSyntax node);
		
		TResult VisitTypeArguments(TypeArgumentsSyntax node);
		
		TResult VisitTypeArgument(TypeArgumentSyntax node);
		
		TResult VisitOperationDeclaration(OperationDeclarationSyntax node);
		
		TResult VisitParameterList(ParameterListSyntax node);
		
		TResult VisitParameter(ParameterSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitLiteral(LiteralSyntax node);
		
		TResult VisitNullLiteral(NullLiteralSyntax node);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node);
		
		TResult VisitStringLiteral(StringLiteralSyntax node);
	}
	
	public class MetaCompilerSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, IMetaCompilerSyntaxVisitor<TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node)
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
		
		public virtual TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
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
		
		public virtual TResult VisitCompilerDeclaration(CompilerDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPhaseDeclaration(PhaseDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPhaseJoin(PhaseJoinSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAfterPhases(AfterPhasesSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBeforePhases(BeforePhasesSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPhaseRef(PhaseRefSyntax node)
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
		
		public virtual TResult VisitClassAncestors(ClassAncestorsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassAncestor(ClassAncestorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassBody(ClassBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassKind(ClassKindSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFieldDeclaration(FieldDeclarationSyntax node)
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
		
		public virtual TResult VisitPhase(PhaseSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNameUseList(NameUseListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypedefDeclaration(TypedefDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypedefValue(TypedefValueSyntax node)
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
		
		public virtual TResult VisitGenericType(GenericTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitGenericTypeName(GenericTypeNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeArguments(TypeArgumentsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeArgument(TypeArgumentSyntax node)
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

	public class MetaCompilerSyntaxRewriter : SyntaxRewriter, IMetaCompilerSyntaxVisitor<SyntaxNode>
	{
	    public MetaCompilerSyntaxRewriter(bool visitIntoStructuredTrivia = false)
			: base(MetaCompilerLanguage.Instance, visitIntoStructuredTrivia)
	    {
	    }
	
	    public virtual SyntaxNode VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node)
	    {
	      var tokens = this.VisitList(node.Tokens);
	      return node.Update(tokens);
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var namespaceDeclaration = (NamespaceDeclarationSyntax)this.Visit(node.NamespaceDeclaration);
		    var eOF = this.VisitToken(node.EndOfFileToken);
			return node.Update(namespaceDeclaration, eOF);
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
		    var declaration = this.VisitList(node.Declaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration(DeclarationSyntax node)
		{
			var oldCompilerDeclaration = node.CompilerDeclaration;
			if (oldCompilerDeclaration != null)
			{
			    var newCompilerDeclaration = (CompilerDeclarationSyntax)this.Visit(oldCompilerDeclaration);
				return node.Update(newCompilerDeclaration);
			}
			var oldPhaseDeclaration = node.PhaseDeclaration;
			if (oldPhaseDeclaration != null)
			{
			    var newPhaseDeclaration = (PhaseDeclarationSyntax)this.Visit(oldPhaseDeclaration);
				return node.Update(newPhaseDeclaration);
			}
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
			var oldTypedefDeclaration = node.TypedefDeclaration;
			if (oldTypedefDeclaration != null)
			{
			    var newTypedefDeclaration = (TypedefDeclarationSyntax)this.Visit(oldTypedefDeclaration);
				return node.Update(newTypedefDeclaration);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitCompilerDeclaration(CompilerDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var kCompiler = this.VisitToken(node.KCompiler);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, kCompiler, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitPhaseDeclaration(PhaseDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var kLocked = this.VisitToken(node.KLocked);
		    var kPhase = this.VisitToken(node.KPhase);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var phaseJoin = (PhaseJoinSyntax)this.Visit(node.PhaseJoin);
		    var afterPhases = (AfterPhasesSyntax)this.Visit(node.AfterPhases);
		    var beforePhases = (BeforePhasesSyntax)this.Visit(node.BeforePhases);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, kLocked, kPhase, name, phaseJoin, afterPhases, beforePhases, tSemicolon);
		}
		
		public virtual SyntaxNode VisitPhaseJoin(PhaseJoinSyntax node)
		{
		    var kJoins = this.VisitToken(node.KJoins);
		    var phaseRef = (PhaseRefSyntax)this.Visit(node.PhaseRef);
			return node.Update(kJoins, phaseRef);
		}
		
		public virtual SyntaxNode VisitAfterPhases(AfterPhasesSyntax node)
		{
		    var kAfter = this.VisitToken(node.KAfter);
		    var phaseRef = this.VisitList(node.PhaseRef);
			return node.Update(kAfter, phaseRef);
		}
		
		public virtual SyntaxNode VisitBeforePhases(BeforePhasesSyntax node)
		{
		    var kBefore = this.VisitToken(node.KBefore);
		    var phaseRef = this.VisitList(node.PhaseRef);
			return node.Update(kBefore, phaseRef);
		}
		
		public virtual SyntaxNode VisitPhaseRef(PhaseRefSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
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
		    var kAbstract = this.VisitToken(node.KAbstract);
		    var classKind = (ClassKindSyntax)this.Visit(node.ClassKind);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var classAncestors = (ClassAncestorsSyntax)this.Visit(node.ClassAncestors);
		    var classBody = (ClassBodySyntax)this.Visit(node.ClassBody);
			return node.Update(attribute, kAbstract, classKind, name, tColon, classAncestors, classBody);
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
		
		public virtual SyntaxNode VisitClassBody(ClassBodySyntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var classMemberDeclaration = this.VisitList(node.ClassMemberDeclaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, classMemberDeclaration, tCloseBrace);
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
		
		public virtual SyntaxNode VisitClassKind(ClassKindSyntax node)
		{
		    var classKind = this.VisitToken(node.ClassKind);
			return node.Update(classKind);
		}
		
		public virtual SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var fieldContainment = (FieldContainmentSyntax)this.Visit(node.FieldContainment);
		    var fieldModifier = (FieldModifierSyntax)this.Visit(node.FieldModifier);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var defaultValue = (DefaultValueSyntax)this.Visit(node.DefaultValue);
		    var phase = (PhaseSyntax)this.Visit(node.Phase);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, fieldContainment, fieldModifier, typeReference, name, defaultValue, phase, tSemicolon);
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
		
		public virtual SyntaxNode VisitPhase(PhaseSyntax node)
		{
		    var kPhase = this.VisitToken(node.KPhase);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(kPhase, qualifier);
		}
		
		public virtual SyntaxNode VisitNameUseList(NameUseListSyntax node)
		{
		    var qualifier = this.VisitList(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitTypedefDeclaration(TypedefDeclarationSyntax node)
		{
		    var kTypeDef = this.VisitToken(node.KTypeDef);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var typedefValue = (TypedefValueSyntax)this.Visit(node.TypedefValue);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kTypeDef, name, typedefValue, tSemicolon);
		}
		
		public virtual SyntaxNode VisitTypedefValue(TypedefValueSyntax node)
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
			var oldGenericType = node.GenericType;
			if (oldGenericType != null)
			{
			    var newGenericType = (GenericTypeSyntax)this.Visit(oldGenericType);
				return node.Update(newGenericType);
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
		
		public virtual SyntaxNode VisitGenericType(GenericTypeSyntax node)
		{
		    var genericTypeName = (GenericTypeNameSyntax)this.Visit(node.GenericTypeName);
		    var tLessThan = this.VisitToken(node.TLessThan);
		    var typeArguments = (TypeArgumentsSyntax)this.Visit(node.TypeArguments);
		    var tGreaterThan = this.VisitToken(node.TGreaterThan);
			return node.Update(genericTypeName, tLessThan, typeArguments, tGreaterThan);
		}
		
		public virtual SyntaxNode VisitGenericTypeName(GenericTypeNameSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitTypeArguments(TypeArgumentsSyntax node)
		{
		    var typeArgument = this.VisitList(node.TypeArgument);
			return node.Update(typeArgument);
		}
		
		public virtual SyntaxNode VisitTypeArgument(TypeArgumentSyntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var returnType = (ReturnTypeSyntax)this.Visit(node.ReturnType);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var parameterList = (ParameterListSyntax)this.Visit(node.ParameterList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
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

	public class MetaCompilerSyntaxFactory : SyntaxFactory
	{
		internal MetaCompilerSyntaxFactory(MetaCompilerInternalSyntaxFactory internalSyntaxFactory) 
			: base(internalSyntaxFactory)
		{
		}
	    public new MetaCompilerLanguage Language => MetaCompilerLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public override LanguageParseOptions DefaultParseOptions => MetaCompilerParseOptions.Default;
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public MetaCompilerSyntaxTree SyntaxTree(SyntaxNode root, MetaCompilerParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return MetaCompilerSyntaxTree.Create((MetaCompilerSyntaxNode)root, (MetaCompilerParseOptions)options, path, null, encoding);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public MetaCompilerSyntaxTree ParseSyntaxTree(
			string text,
			MetaCompilerParseOptions options = null,
			string path = "",
			Encoding encoding = null,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (MetaCompilerSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public MetaCompilerSyntaxTree ParseSyntaxTree(
			SourceText text,
			MetaCompilerParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (MetaCompilerSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
		protected override LanguageSyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return MetaCompilerSyntaxTree.ParseText(text, (MetaCompilerParseOptions)options, path, cancellationToken);
		}
	
		public override LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return MetaCompilerSyntaxTree.Create((MetaCompilerSyntaxNode)root, (MetaCompilerParseOptions)options, path, null, encoding);
		}
	
	
	    public SyntaxToken TAsterisk(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.TAsterisk(text));
	    }
	
	    public SyntaxToken TAsterisk(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.TAsterisk(text, value));
	    }
	
	    public SyntaxToken IdentifierNormal(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text));
	    }
	
	    public SyntaxToken IdentifierNormal(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text, value));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text, value));
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LInteger(text));
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LInteger(text, value));
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LDecimal(text));
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LDecimal(text, value));
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LScientific(text));
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LScientific(text, value));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text, value));
	    }
	
	    public SyntaxToken LDateTime(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LDateTime(text));
	    }
	
	    public SyntaxToken LDateTime(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LDateTime(text, value));
	    }
	
	    public SyntaxToken LDate(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LDate(text));
	    }
	
	    public SyntaxToken LDate(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LDate(text, value));
	    }
	
	    public SyntaxToken LTime(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LTime(text));
	    }
	
	    public SyntaxToken LTime(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LTime(text, value));
	    }
	
	    public SyntaxToken LRegularString(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LRegularString(text));
	    }
	
	    public SyntaxToken LRegularString(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LRegularString(text, value));
	    }
	
	    public SyntaxToken LGuid(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LGuid(text));
	    }
	
	    public SyntaxToken LGuid(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LGuid(text, value));
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text));
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value));
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text));
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value));
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LCrLf(text));
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value));
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LLineEnd(text));
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value));
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text));
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value));
	    }
	
	    public SyntaxToken LComment(string text)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LComment(text));
	    }
	
	    public SyntaxToken LComment(string text, object value)
	    {
	        return new SyntaxToken(MetaCompilerLanguage.Instance.InternalSyntaxFactory.LComment(text, value));
	    }
		
		public MainSyntax Main(NamespaceDeclarationSyntax namespaceDeclaration, SyntaxToken eOF)
		{
		    if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
		    if (eOF == null) throw new ArgumentNullException(nameof(eOF));
		    if (eOF.GetKind() != MetaCompilerSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
		    return (MainSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Main((Syntax.InternalSyntax.NamespaceDeclarationGreen)namespaceDeclaration.Green, (InternalSyntaxToken)eOF.Node).CreateRed();
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public QualifiedNameSyntax QualifiedName(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifiedNameSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.QualifiedName((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public QualifierSyntax Qualifier(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Qualifier(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public AttributeSyntax Attribute(SyntaxToken tOpenBracket, QualifierSyntax qualifier, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != MetaCompilerSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != MetaCompilerSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (AttributeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Attribute((InternalSyntaxToken)tOpenBracket.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public AttributeSyntax Attribute(QualifierSyntax qualifier)
		{
			return this.Attribute(this.Token(MetaCompilerSyntaxKind.TOpenBracket), qualifier, this.Token(MetaCompilerSyntaxKind.TCloseBracket));
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(SyntaxList<AttributeSyntax> attribute, SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != MetaCompilerSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
		    return (NamespaceDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBodyGreen)namespaceBody.Green).CreateRed();
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
		{
			return this.NamespaceDeclaration(default, this.Token(MetaCompilerSyntaxKind.KNamespace), qualifiedName, namespaceBody);
		}
		
		public NamespaceBodySyntax NamespaceBody(SyntaxToken tOpenBrace, SyntaxList<DeclarationSyntax> declaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != MetaCompilerSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != MetaCompilerSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBodySyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.NamespaceBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<DeclarationGreen>(declaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBodySyntax NamespaceBody()
		{
			return this.NamespaceBody(this.Token(MetaCompilerSyntaxKind.TOpenBrace), default, this.Token(MetaCompilerSyntaxKind.TCloseBrace));
		}
		
		public DeclarationSyntax Declaration(CompilerDeclarationSyntax compilerDeclaration)
		{
		    if (compilerDeclaration == null) throw new ArgumentNullException(nameof(compilerDeclaration));
		    return (DeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.CompilerDeclarationGreen)compilerDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(PhaseDeclarationSyntax phaseDeclaration)
		{
		    if (phaseDeclaration == null) throw new ArgumentNullException(nameof(phaseDeclaration));
		    return (DeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.PhaseDeclarationGreen)phaseDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(EnumDeclarationSyntax enumDeclaration)
		{
		    if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
		    return (DeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.EnumDeclarationGreen)enumDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(ClassDeclarationSyntax classDeclaration)
		{
		    if (classDeclaration == null) throw new ArgumentNullException(nameof(classDeclaration));
		    return (DeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.ClassDeclarationGreen)classDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(TypedefDeclarationSyntax typedefDeclaration)
		{
		    if (typedefDeclaration == null) throw new ArgumentNullException(nameof(typedefDeclaration));
		    return (DeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.TypedefDeclarationGreen)typedefDeclaration.Green).CreateRed();
		}
		
		public CompilerDeclarationSyntax CompilerDeclaration(SyntaxList<AttributeSyntax> attribute, SyntaxToken kCompiler, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kCompiler == null) throw new ArgumentNullException(nameof(kCompiler));
		    if (kCompiler.GetKind() != MetaCompilerSyntaxKind.KCompiler) throw new ArgumentException(nameof(kCompiler));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (CompilerDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.CompilerDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (InternalSyntaxToken)kCompiler.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public CompilerDeclarationSyntax CompilerDeclaration(NameSyntax name)
		{
			return this.CompilerDeclaration(default, this.Token(MetaCompilerSyntaxKind.KCompiler), name, this.Token(MetaCompilerSyntaxKind.TSemicolon));
		}
		
		public PhaseDeclarationSyntax PhaseDeclaration(SyntaxList<AttributeSyntax> attribute, SyntaxToken kLocked, SyntaxToken kPhase, NameSyntax name, PhaseJoinSyntax phaseJoin, AfterPhasesSyntax afterPhases, BeforePhasesSyntax beforePhases, SyntaxToken tSemicolon)
		{
		    if (kLocked != null && kLocked.GetKind() != MetaCompilerSyntaxKind.KLocked) throw new ArgumentException(nameof(kLocked));
		    if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
		    if (kPhase.GetKind() != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (PhaseDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.PhaseDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (InternalSyntaxToken)kLocked.Node, (InternalSyntaxToken)kPhase.Node, (Syntax.InternalSyntax.NameGreen)name.Green, phaseJoin == null ? null : (Syntax.InternalSyntax.PhaseJoinGreen)phaseJoin.Green, afterPhases == null ? null : (Syntax.InternalSyntax.AfterPhasesGreen)afterPhases.Green, beforePhases == null ? null : (Syntax.InternalSyntax.BeforePhasesGreen)beforePhases.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public PhaseDeclarationSyntax PhaseDeclaration(NameSyntax name)
		{
			return this.PhaseDeclaration(default, default, this.Token(MetaCompilerSyntaxKind.KPhase), name, default, default, default, this.Token(MetaCompilerSyntaxKind.TSemicolon));
		}
		
		public PhaseJoinSyntax PhaseJoin(SyntaxToken kJoins, PhaseRefSyntax phaseRef)
		{
		    if (kJoins == null) throw new ArgumentNullException(nameof(kJoins));
		    if (kJoins.GetKind() != MetaCompilerSyntaxKind.KJoins) throw new ArgumentException(nameof(kJoins));
		    if (phaseRef == null) throw new ArgumentNullException(nameof(phaseRef));
		    return (PhaseJoinSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.PhaseJoin((InternalSyntaxToken)kJoins.Node, (Syntax.InternalSyntax.PhaseRefGreen)phaseRef.Green).CreateRed();
		}
		
		public PhaseJoinSyntax PhaseJoin(PhaseRefSyntax phaseRef)
		{
			return this.PhaseJoin(this.Token(MetaCompilerSyntaxKind.KJoins), phaseRef);
		}
		
		public AfterPhasesSyntax AfterPhases(SyntaxToken kAfter, SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
		{
		    if (kAfter == null) throw new ArgumentNullException(nameof(kAfter));
		    if (kAfter.GetKind() != MetaCompilerSyntaxKind.KAfter) throw new ArgumentException(nameof(kAfter));
		    if (phaseRef == null) throw new ArgumentNullException(nameof(phaseRef));
		    return (AfterPhasesSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.AfterPhases((InternalSyntaxToken)kAfter.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<PhaseRefGreen>(phaseRef.Node)).CreateRed();
		}
		
		public AfterPhasesSyntax AfterPhases(SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
		{
			return this.AfterPhases(this.Token(MetaCompilerSyntaxKind.KAfter), phaseRef);
		}
		
		public BeforePhasesSyntax BeforePhases(SyntaxToken kBefore, SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
		{
		    if (kBefore == null) throw new ArgumentNullException(nameof(kBefore));
		    if (kBefore.GetKind() != MetaCompilerSyntaxKind.KBefore) throw new ArgumentException(nameof(kBefore));
		    if (phaseRef == null) throw new ArgumentNullException(nameof(phaseRef));
		    return (BeforePhasesSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.BeforePhases((InternalSyntaxToken)kBefore.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<PhaseRefGreen>(phaseRef.Node)).CreateRed();
		}
		
		public BeforePhasesSyntax BeforePhases(SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
		{
			return this.BeforePhases(this.Token(MetaCompilerSyntaxKind.KBefore), phaseRef);
		}
		
		public PhaseRefSyntax PhaseRef(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (PhaseRefSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.PhaseRef((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public EnumDeclarationSyntax EnumDeclaration(SyntaxList<AttributeSyntax> attribute, SyntaxToken kEnum, NameSyntax name, EnumBodySyntax enumBody)
		{
		    if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
		    if (kEnum.GetKind() != MetaCompilerSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (enumBody == null) throw new ArgumentNullException(nameof(enumBody));
		    return (EnumDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (InternalSyntaxToken)kEnum.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.EnumBodyGreen)enumBody.Green).CreateRed();
		}
		
		public EnumDeclarationSyntax EnumDeclaration(NameSyntax name, EnumBodySyntax enumBody)
		{
			return this.EnumDeclaration(default, this.Token(MetaCompilerSyntaxKind.KEnum), name, enumBody);
		}
		
		public EnumBodySyntax EnumBody(SyntaxToken tOpenBrace, EnumValuesSyntax enumValues, SyntaxToken tSemicolon, SyntaxList<EnumMemberDeclarationSyntax> enumMemberDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != MetaCompilerSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (enumValues == null) throw new ArgumentNullException(nameof(enumValues));
		    if (tSemicolon != null && tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != MetaCompilerSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (EnumBodySyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumBody((InternalSyntaxToken)tOpenBrace.Node, (Syntax.InternalSyntax.EnumValuesGreen)enumValues.Green, (InternalSyntaxToken)tSemicolon.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<EnumMemberDeclarationGreen>(enumMemberDeclaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public EnumBodySyntax EnumBody(EnumValuesSyntax enumValues)
		{
			return this.EnumBody(this.Token(MetaCompilerSyntaxKind.TOpenBrace), enumValues, default, default, this.Token(MetaCompilerSyntaxKind.TCloseBrace));
		}
		
		public EnumValuesSyntax EnumValues(SeparatedSyntaxList<EnumValueSyntax> enumValue)
		{
		    if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));
		    return (EnumValuesSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumValues(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<EnumValueGreen>(enumValue.Node)).CreateRed();
		}
		
		public EnumValueSyntax EnumValue(SyntaxList<AttributeSyntax> attribute, NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (EnumValueSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumValue(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public EnumValueSyntax EnumValue(NameSyntax name)
		{
			return this.EnumValue(default, name);
		}
		
		public EnumMemberDeclarationSyntax EnumMemberDeclaration(OperationDeclarationSyntax operationDeclaration)
		{
		    if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
		    return (EnumMemberDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.EnumMemberDeclaration((Syntax.InternalSyntax.OperationDeclarationGreen)operationDeclaration.Green).CreateRed();
		}
		
		public ClassDeclarationSyntax ClassDeclaration(SyntaxList<AttributeSyntax> attribute, SyntaxToken kAbstract, ClassKindSyntax classKind, NameSyntax name, SyntaxToken tColon, ClassAncestorsSyntax classAncestors, ClassBodySyntax classBody)
		{
		    if (kAbstract != null && kAbstract.GetKind() != MetaCompilerSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
		    if (classKind == null) throw new ArgumentNullException(nameof(classKind));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon != null && tColon.GetKind() != MetaCompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (classBody == null) throw new ArgumentNullException(nameof(classBody));
		    return (ClassDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (InternalSyntaxToken)kAbstract.Node, (Syntax.InternalSyntax.ClassKindGreen)classKind.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, classAncestors == null ? null : (Syntax.InternalSyntax.ClassAncestorsGreen)classAncestors.Green, (Syntax.InternalSyntax.ClassBodyGreen)classBody.Green).CreateRed();
		}
		
		public ClassDeclarationSyntax ClassDeclaration(ClassKindSyntax classKind, NameSyntax name, ClassBodySyntax classBody)
		{
			return this.ClassDeclaration(default, default, classKind, name, default, default, classBody);
		}
		
		public ClassAncestorsSyntax ClassAncestors(SeparatedSyntaxList<ClassAncestorSyntax> classAncestor)
		{
		    if (classAncestor == null) throw new ArgumentNullException(nameof(classAncestor));
		    return (ClassAncestorsSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassAncestors(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ClassAncestorGreen>(classAncestor.Node)).CreateRed();
		}
		
		public ClassAncestorSyntax ClassAncestor(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (ClassAncestorSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassAncestor((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ClassBodySyntax ClassBody(SyntaxToken tOpenBrace, SyntaxList<ClassMemberDeclarationSyntax> classMemberDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != MetaCompilerSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != MetaCompilerSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (ClassBodySyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassBody((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ClassMemberDeclarationGreen>(classMemberDeclaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public ClassBodySyntax ClassBody()
		{
			return this.ClassBody(this.Token(MetaCompilerSyntaxKind.TOpenBrace), default, this.Token(MetaCompilerSyntaxKind.TCloseBrace));
		}
		
		public ClassMemberDeclarationSyntax ClassMemberDeclaration(FieldDeclarationSyntax fieldDeclaration)
		{
		    if (fieldDeclaration == null) throw new ArgumentNullException(nameof(fieldDeclaration));
		    return (ClassMemberDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration((Syntax.InternalSyntax.FieldDeclarationGreen)fieldDeclaration.Green).CreateRed();
		}
		
		public ClassMemberDeclarationSyntax ClassMemberDeclaration(OperationDeclarationSyntax operationDeclaration)
		{
		    if (operationDeclaration == null) throw new ArgumentNullException(nameof(operationDeclaration));
		    return (ClassMemberDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassMemberDeclaration((Syntax.InternalSyntax.OperationDeclarationGreen)operationDeclaration.Green).CreateRed();
		}
		
		public ClassKindSyntax ClassKind(SyntaxToken classKind)
		{
		    if (classKind == null) throw new ArgumentNullException(nameof(classKind));
		    return (ClassKindSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassKind((InternalSyntaxToken)classKind.Node).CreateRed();
		}
		
		public FieldDeclarationSyntax FieldDeclaration(SyntaxList<AttributeSyntax> attribute, FieldContainmentSyntax fieldContainment, FieldModifierSyntax fieldModifier, TypeReferenceSyntax typeReference, NameSyntax name, DefaultValueSyntax defaultValue, PhaseSyntax phase, SyntaxToken tSemicolon)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (FieldDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), fieldContainment == null ? null : (Syntax.InternalSyntax.FieldContainmentGreen)fieldContainment.Green, fieldModifier == null ? null : (Syntax.InternalSyntax.FieldModifierGreen)fieldModifier.Green, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green, defaultValue == null ? null : (Syntax.InternalSyntax.DefaultValueGreen)defaultValue.Green, phase == null ? null : (Syntax.InternalSyntax.PhaseGreen)phase.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public FieldDeclarationSyntax FieldDeclaration(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.FieldDeclaration(default, default, default, typeReference, name, default, default, this.Token(MetaCompilerSyntaxKind.TSemicolon));
		}
		
		public FieldContainmentSyntax FieldContainment(SyntaxToken kContainment)
		{
		    if (kContainment == null) throw new ArgumentNullException(nameof(kContainment));
		    if (kContainment.GetKind() != MetaCompilerSyntaxKind.KContainment) throw new ArgumentException(nameof(kContainment));
		    return (FieldContainmentSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldContainment((InternalSyntaxToken)kContainment.Node).CreateRed();
		}
		
		public FieldContainmentSyntax FieldContainment()
		{
			return this.FieldContainment(this.Token(MetaCompilerSyntaxKind.KContainment));
		}
		
		public FieldModifierSyntax FieldModifier(SyntaxToken fieldModifier)
		{
		    if (fieldModifier == null) throw new ArgumentNullException(nameof(fieldModifier));
		    return (FieldModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldModifier((InternalSyntaxToken)fieldModifier.Node).CreateRed();
		}
		
		public DefaultValueSyntax DefaultValue(SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
		{
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != MetaCompilerSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (DefaultValueSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.DefaultValue((InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public DefaultValueSyntax DefaultValue(StringLiteralSyntax stringLiteral)
		{
			return this.DefaultValue(this.Token(MetaCompilerSyntaxKind.TAssign), stringLiteral);
		}
		
		public PhaseSyntax Phase(SyntaxToken kPhase, QualifierSyntax qualifier)
		{
		    if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
		    if (kPhase.GetKind() != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (PhaseSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Phase((InternalSyntaxToken)kPhase.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public PhaseSyntax Phase(QualifierSyntax qualifier)
		{
			return this.Phase(this.Token(MetaCompilerSyntaxKind.KPhase), qualifier);
		}
		
		public NameUseListSyntax NameUseList(SeparatedSyntaxList<QualifierSyntax> qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (NameUseListSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.NameUseList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<QualifierGreen>(qualifier.Node)).CreateRed();
		}
		
		public TypedefDeclarationSyntax TypedefDeclaration(SyntaxToken kTypeDef, NameSyntax name, TypedefValueSyntax typedefValue, SyntaxToken tSemicolon)
		{
		    if (kTypeDef == null) throw new ArgumentNullException(nameof(kTypeDef));
		    if (kTypeDef.GetKind() != MetaCompilerSyntaxKind.KTypeDef) throw new ArgumentException(nameof(kTypeDef));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (typedefValue == null) throw new ArgumentNullException(nameof(typedefValue));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (TypedefDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypedefDeclaration((InternalSyntaxToken)kTypeDef.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (Syntax.InternalSyntax.TypedefValueGreen)typedefValue.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public TypedefDeclarationSyntax TypedefDeclaration(NameSyntax name, TypedefValueSyntax typedefValue)
		{
			return this.TypedefDeclaration(this.Token(MetaCompilerSyntaxKind.KTypeDef), name, typedefValue, this.Token(MetaCompilerSyntaxKind.TSemicolon));
		}
		
		public TypedefValueSyntax TypedefValue(SyntaxToken tAssign, StringLiteralSyntax stringLiteral)
		{
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != MetaCompilerSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (TypedefValueSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypedefValue((InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public TypedefValueSyntax TypedefValue(StringLiteralSyntax stringLiteral)
		{
			return this.TypedefValue(this.Token(MetaCompilerSyntaxKind.TAssign), stringLiteral);
		}
		
		public ReturnTypeSyntax ReturnType(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (ReturnTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public ReturnTypeSyntax ReturnType(VoidTypeSyntax voidType)
		{
		    if (voidType == null) throw new ArgumentNullException(nameof(voidType));
		    return (ReturnTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.VoidTypeGreen)voidType.Green).CreateRed();
		}
		
		public TypeOfReferenceSyntax TypeOfReference(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (TypeOfReferenceSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeOfReference((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(GenericTypeSyntax genericType)
		{
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
		    return (TypeReferenceSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.GenericTypeGreen)genericType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(SimpleTypeSyntax simpleType)
		{
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    return (TypeReferenceSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(PrimitiveTypeSyntax primitiveType)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    return (SimpleTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.PrimitiveTypeGreen)primitiveType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(ObjectTypeSyntax objectType)
		{
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
		    return (SimpleTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.ObjectTypeGreen)objectType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(NullableTypeSyntax nullableType)
		{
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
		    return (SimpleTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.NullableTypeGreen)nullableType.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(ClassTypeSyntax classType)
		{
		    if (classType == null) throw new ArgumentNullException(nameof(classType));
		    return (SimpleTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.ClassTypeGreen)classType.Green).CreateRed();
		}
		
		public ClassTypeSyntax ClassType(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (ClassTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassType((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public ObjectTypeSyntax ObjectType(SyntaxToken objectType)
		{
		    if (objectType == null) throw new ArgumentNullException(nameof(objectType));
		    return (ObjectTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ObjectType((InternalSyntaxToken)objectType.Node).CreateRed();
		}
		
		public PrimitiveTypeSyntax PrimitiveType(SyntaxToken primitiveType)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    return (PrimitiveTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.PrimitiveType((InternalSyntaxToken)primitiveType.Node).CreateRed();
		}
		
		public VoidTypeSyntax VoidType(SyntaxToken kVoid)
		{
		    if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
		    if (kVoid.GetKind() != MetaCompilerSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
		    return (VoidTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.VoidType((InternalSyntaxToken)kVoid.Node).CreateRed();
		}
		
		public VoidTypeSyntax VoidType()
		{
			return this.VoidType(this.Token(MetaCompilerSyntaxKind.KVoid));
		}
		
		public NullableTypeSyntax NullableType(PrimitiveTypeSyntax primitiveType, SyntaxToken tQuestion)
		{
		    if (primitiveType == null) throw new ArgumentNullException(nameof(primitiveType));
		    if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
		    if (tQuestion.GetKind() != MetaCompilerSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
		    return (NullableTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.NullableType((Syntax.InternalSyntax.PrimitiveTypeGreen)primitiveType.Green, (InternalSyntaxToken)tQuestion.Node).CreateRed();
		}
		
		public NullableTypeSyntax NullableType(PrimitiveTypeSyntax primitiveType)
		{
			return this.NullableType(primitiveType, this.Token(MetaCompilerSyntaxKind.TQuestion));
		}
		
		public GenericTypeSyntax GenericType(GenericTypeNameSyntax genericTypeName, SyntaxToken tLessThan, TypeArgumentsSyntax typeArguments, SyntaxToken tGreaterThan)
		{
		    if (genericTypeName == null) throw new ArgumentNullException(nameof(genericTypeName));
		    if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
		    if (tLessThan.GetKind() != MetaCompilerSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
		    if (typeArguments == null) throw new ArgumentNullException(nameof(typeArguments));
		    if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
		    if (tGreaterThan.GetKind() != MetaCompilerSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
		    return (GenericTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.GenericType((Syntax.InternalSyntax.GenericTypeNameGreen)genericTypeName.Green, (InternalSyntaxToken)tLessThan.Node, (Syntax.InternalSyntax.TypeArgumentsGreen)typeArguments.Green, (InternalSyntaxToken)tGreaterThan.Node).CreateRed();
		}
		
		public GenericTypeSyntax GenericType(GenericTypeNameSyntax genericTypeName, TypeArgumentsSyntax typeArguments)
		{
			return this.GenericType(genericTypeName, this.Token(MetaCompilerSyntaxKind.TLessThan), typeArguments, this.Token(MetaCompilerSyntaxKind.TGreaterThan));
		}
		
		public GenericTypeNameSyntax GenericTypeName(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (GenericTypeNameSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.GenericTypeName((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public TypeArgumentsSyntax TypeArguments(SeparatedSyntaxList<TypeArgumentSyntax> typeArgument)
		{
		    if (typeArgument == null) throw new ArgumentNullException(nameof(typeArgument));
		    return (TypeArgumentsSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeArguments(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<TypeArgumentGreen>(typeArgument.Node)).CreateRed();
		}
		
		public TypeArgumentSyntax TypeArgument(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (TypeArgumentSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeArgument((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public OperationDeclarationSyntax OperationDeclaration(SyntaxList<AttributeSyntax> attribute, ReturnTypeSyntax returnType, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
		{
		    if (returnType == null) throw new ArgumentNullException(nameof(returnType));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != MetaCompilerSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != MetaCompilerSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (OperationDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (Syntax.InternalSyntax.ReturnTypeGreen)returnType.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Node, parameterList == null ? null : (Syntax.InternalSyntax.ParameterListGreen)parameterList.Green, (InternalSyntaxToken)tCloseParen.Node, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public OperationDeclarationSyntax OperationDeclaration(ReturnTypeSyntax returnType, NameSyntax name)
		{
			return this.OperationDeclaration(default, returnType, name, this.Token(MetaCompilerSyntaxKind.TOpenParen), default, this.Token(MetaCompilerSyntaxKind.TCloseParen), this.Token(MetaCompilerSyntaxKind.TSemicolon));
		}
		
		public ParameterListSyntax ParameterList(SeparatedSyntaxList<ParameterSyntax> parameter)
		{
		    if (parameter == null) throw new ArgumentNullException(nameof(parameter));
		    return (ParameterListSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ParameterList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParameterGreen>(parameter.Node)).CreateRed();
		}
		
		public ParameterSyntax Parameter(SyntaxList<AttributeSyntax> attribute, TypeReferenceSyntax typeReference, NameSyntax name)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (ParameterSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Parameter(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public ParameterSyntax Parameter(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.Parameter(default, typeReference, name);
		}
		
		public IdentifierSyntax Identifier(SyntaxToken identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)identifier.Node).CreateRed();
		}
		
		public LiteralSyntax Literal(NullLiteralSyntax nullLiteral)
		{
		    if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
		    return (LiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.NullLiteralGreen)nullLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(BooleanLiteralSyntax booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (LiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(IntegerLiteralSyntax integerLiteral)
		{
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    return (LiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.IntegerLiteralGreen)integerLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(DecimalLiteralSyntax decimalLiteral)
		{
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
		    return (LiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.DecimalLiteralGreen)decimalLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(ScientificLiteralSyntax scientificLiteral)
		{
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
		    return (LiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.ScientificLiteralGreen)scientificLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (LiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral(SyntaxToken kNull)
		{
		    if (kNull == null) throw new ArgumentNullException(nameof(kNull));
		    if (kNull.GetKind() != MetaCompilerSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
		    return (NullLiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.NullLiteral((InternalSyntaxToken)kNull.Node).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral()
		{
			return this.NullLiteral(this.Token(MetaCompilerSyntaxKind.KNull));
		}
		
		public BooleanLiteralSyntax BooleanLiteral(SyntaxToken booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (BooleanLiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.BooleanLiteral((InternalSyntaxToken)booleanLiteral.Node).CreateRed();
		}
		
		public IntegerLiteralSyntax IntegerLiteral(SyntaxToken lInteger)
		{
		    if (lInteger == null) throw new ArgumentNullException(nameof(lInteger));
		    if (lInteger.GetKind() != MetaCompilerSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
		    return (IntegerLiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.IntegerLiteral((InternalSyntaxToken)lInteger.Node).CreateRed();
		}
		
		public DecimalLiteralSyntax DecimalLiteral(SyntaxToken lDecimal)
		{
		    if (lDecimal == null) throw new ArgumentNullException(nameof(lDecimal));
		    if (lDecimal.GetKind() != MetaCompilerSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
		    return (DecimalLiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.DecimalLiteral((InternalSyntaxToken)lDecimal.Node).CreateRed();
		}
		
		public ScientificLiteralSyntax ScientificLiteral(SyntaxToken lScientific)
		{
		    if (lScientific == null) throw new ArgumentNullException(nameof(lScientific));
		    if (lScientific.GetKind() != MetaCompilerSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
		    return (ScientificLiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ScientificLiteral((InternalSyntaxToken)lScientific.Node).CreateRed();
		}
		
		public StringLiteralSyntax StringLiteral(SyntaxToken lRegularString)
		{
		    if (lRegularString == null) throw new ArgumentNullException(nameof(lRegularString));
		    if (lRegularString.GetKind() != MetaCompilerSyntaxKind.LRegularString) throw new ArgumentException(nameof(lRegularString));
		    return (StringLiteralSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.StringLiteral((InternalSyntaxToken)lRegularString.Node).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(NameSyntax),
				typeof(QualifiedNameSyntax),
				typeof(QualifierSyntax),
				typeof(AttributeSyntax),
				typeof(NamespaceDeclarationSyntax),
				typeof(NamespaceBodySyntax),
				typeof(DeclarationSyntax),
				typeof(CompilerDeclarationSyntax),
				typeof(PhaseDeclarationSyntax),
				typeof(PhaseJoinSyntax),
				typeof(AfterPhasesSyntax),
				typeof(BeforePhasesSyntax),
				typeof(PhaseRefSyntax),
				typeof(EnumDeclarationSyntax),
				typeof(EnumBodySyntax),
				typeof(EnumValuesSyntax),
				typeof(EnumValueSyntax),
				typeof(EnumMemberDeclarationSyntax),
				typeof(ClassDeclarationSyntax),
				typeof(ClassAncestorsSyntax),
				typeof(ClassAncestorSyntax),
				typeof(ClassBodySyntax),
				typeof(ClassMemberDeclarationSyntax),
				typeof(ClassKindSyntax),
				typeof(FieldDeclarationSyntax),
				typeof(FieldContainmentSyntax),
				typeof(FieldModifierSyntax),
				typeof(DefaultValueSyntax),
				typeof(PhaseSyntax),
				typeof(NameUseListSyntax),
				typeof(TypedefDeclarationSyntax),
				typeof(TypedefValueSyntax),
				typeof(ReturnTypeSyntax),
				typeof(TypeOfReferenceSyntax),
				typeof(TypeReferenceSyntax),
				typeof(SimpleTypeSyntax),
				typeof(ClassTypeSyntax),
				typeof(ObjectTypeSyntax),
				typeof(PrimitiveTypeSyntax),
				typeof(VoidTypeSyntax),
				typeof(NullableTypeSyntax),
				typeof(GenericTypeSyntax),
				typeof(GenericTypeNameSyntax),
				typeof(TypeArgumentsSyntax),
				typeof(TypeArgumentSyntax),
				typeof(OperationDeclarationSyntax),
				typeof(ParameterListSyntax),
				typeof(ParameterSyntax),
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

