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
	    private LockedSyntax locked;
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
	    public LockedSyntax Locked 
		{ 
			get { return this.GetRed(ref this.locked, 1); } 
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
				case 1: return this.GetRed(ref this.locked, 1);
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
				case 1: return this.locked;
				case 3: return this.name;
				case 4: return this.phaseJoin;
				case 5: return this.afterPhases;
				case 6: return this.beforePhases;
				default: return null;
	        }
	    }
	
	    public PhaseDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.Locked, this.KPhase, this.Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public PhaseDeclarationSyntax WithLocked(LockedSyntax locked)
		{
			return this.Update(this.Attribute, Locked, this.KPhase, this.Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithKPhase(SyntaxToken kPhase)
		{
			return this.Update(this.Attribute, this.Locked, KPhase, this.Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.Locked, this.KPhase, Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithPhaseJoin(PhaseJoinSyntax phaseJoin)
		{
			return this.Update(this.Attribute, this.Locked, this.KPhase, this.Name, PhaseJoin, this.AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithAfterPhases(AfterPhasesSyntax afterPhases)
		{
			return this.Update(this.Attribute, this.Locked, this.KPhase, this.Name, this.PhaseJoin, AfterPhases, this.BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithBeforePhases(BeforePhasesSyntax beforePhases)
		{
			return this.Update(this.Attribute, this.Locked, this.KPhase, this.Name, this.PhaseJoin, this.AfterPhases, BeforePhases, this.TSemicolon);
		}
	
	    public PhaseDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.Locked, this.KPhase, this.Name, this.PhaseJoin, this.AfterPhases, this.BeforePhases, TSemicolon);
		}
	
	    public PhaseDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, LockedSyntax locked, SyntaxToken kPhase, NameSyntax name, PhaseJoinSyntax phaseJoin, AfterPhasesSyntax afterPhases, BeforePhasesSyntax beforePhases, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.Locked != locked ||
				this.KPhase != kPhase ||
				this.Name != name ||
				this.PhaseJoin != phaseJoin ||
				this.AfterPhases != afterPhases ||
				this.BeforePhases != beforePhases ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.PhaseDeclaration(attribute, locked, kPhase, name, phaseJoin, afterPhases, beforePhases, tSemicolon);
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
	
	public sealed class LockedSyntax : MetaCompilerSyntaxNode
	{
	
	    public LockedSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LockedSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KLocked 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.LockedGreen)this.Green;
				var greenToken = green.KLocked;
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
	
	    public LockedSyntax WithKLocked(SyntaxToken kLocked)
		{
			return this.Update(KLocked);
		}
	
	    public LockedSyntax Update(SyntaxToken kLocked)
	    {
	        if (this.KLocked != kLocked)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Locked(kLocked);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LockedSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLocked(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLocked(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLocked(this);
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
	
	public sealed class VisibilitySyntax : MetaCompilerSyntaxNode
	{
	
	    public VisibilitySyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VisibilitySyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Visibility 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.VisibilityGreen)this.Green;
				var greenToken = green.Visibility;
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
	
	    public VisibilitySyntax WithVisibility(SyntaxToken visibility)
		{
			return this.Update(Visibility);
		}
	
	    public VisibilitySyntax Update(SyntaxToken visibility)
	    {
	        if (this.Visibility != visibility)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Visibility(visibility);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VisibilitySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVisibility(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVisibility(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitVisibility(this);
	    }
	}
	
	public sealed class ClassDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private VisibilitySyntax visibility;
	    private SyntaxNode classModifier;
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
	    public VisibilitySyntax Visibility 
		{ 
			get { return this.GetRed(ref this.visibility, 1); } 
		}
	    public SyntaxList<ClassModifierSyntax> ClassModifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.classModifier, 2);
				if (red != null) return new SyntaxList<ClassModifierSyntax>(red);
				return default;
			} 
		}
	    public ClassKindSyntax ClassKind 
		{ 
			get { return this.GetRed(ref this.classKind, 3); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 4); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ClassDeclarationGreen)this.Green;
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
				case 1: return this.GetRed(ref this.visibility, 1);
				case 2: return this.GetRed(ref this.classModifier, 2);
				case 3: return this.GetRed(ref this.classKind, 3);
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
				case 1: return this.visibility;
				case 2: return this.classModifier;
				case 3: return this.classKind;
				case 4: return this.name;
				case 6: return this.classAncestors;
				case 7: return this.classBody;
				default: return null;
	        }
	    }
	
	    public ClassDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.Visibility, this.ClassModifier, this.ClassKind, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public ClassDeclarationSyntax WithVisibility(VisibilitySyntax visibility)
		{
			return this.Update(this.Attribute, Visibility, this.ClassModifier, this.ClassKind, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassModifier(SyntaxList<ClassModifierSyntax> classModifier)
		{
			return this.Update(this.Attribute, this.Visibility, ClassModifier, this.ClassKind, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax AddClassModifier(params ClassModifierSyntax[] classModifier)
		{
			return this.WithClassModifier(this.ClassModifier.AddRange(classModifier));
		}
	
	    public ClassDeclarationSyntax WithClassKind(ClassKindSyntax classKind)
		{
			return this.Update(this.Attribute, this.Visibility, this.ClassModifier, ClassKind, this.Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.Visibility, this.ClassModifier, this.ClassKind, Name, this.TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Attribute, this.Visibility, this.ClassModifier, this.ClassKind, this.Name, TColon, this.ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassAncestors(ClassAncestorsSyntax classAncestors)
		{
			return this.Update(this.Attribute, this.Visibility, this.ClassModifier, this.ClassKind, this.Name, this.TColon, ClassAncestors, this.ClassBody);
		}
	
	    public ClassDeclarationSyntax WithClassBody(ClassBodySyntax classBody)
		{
			return this.Update(this.Attribute, this.Visibility, this.ClassModifier, this.ClassKind, this.Name, this.TColon, this.ClassAncestors, ClassBody);
		}
	
	    public ClassDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, VisibilitySyntax visibility, SyntaxList<ClassModifierSyntax> classModifier, ClassKindSyntax classKind, NameSyntax name, SyntaxToken tColon, ClassAncestorsSyntax classAncestors, ClassBodySyntax classBody)
	    {
	        if (this.Attribute != attribute ||
				this.Visibility != visibility ||
				this.ClassModifier != classModifier ||
				this.ClassKind != classKind ||
				this.Name != name ||
				this.TColon != tColon ||
				this.ClassAncestors != classAncestors ||
				this.ClassBody != classBody)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassDeclaration(attribute, visibility, classModifier, classKind, name, tColon, classAncestors, classBody);
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
	
	public sealed class ClassModifierSyntax : MetaCompilerSyntaxNode
	{
	    private Abstract_Syntax abstract_;
	    private Sealed_Syntax sealed_;
	    private Fixed_Syntax fixed_;
	    private Partial_Syntax partial_;
	    private Static_Syntax static_;
	
	    public ClassModifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassModifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Abstract_Syntax Abstract_ 
		{ 
			get { return this.GetRed(ref this.abstract_, 0); } 
		}
	    public Sealed_Syntax Sealed_ 
		{ 
			get { return this.GetRed(ref this.sealed_, 1); } 
		}
	    public Fixed_Syntax Fixed_ 
		{ 
			get { return this.GetRed(ref this.fixed_, 2); } 
		}
	    public Partial_Syntax Partial_ 
		{ 
			get { return this.GetRed(ref this.partial_, 3); } 
		}
	    public Static_Syntax Static_ 
		{ 
			get { return this.GetRed(ref this.static_, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.abstract_, 0);
				case 1: return this.GetRed(ref this.sealed_, 1);
				case 2: return this.GetRed(ref this.fixed_, 2);
				case 3: return this.GetRed(ref this.partial_, 3);
				case 4: return this.GetRed(ref this.static_, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.abstract_;
				case 1: return this.sealed_;
				case 2: return this.fixed_;
				case 3: return this.partial_;
				case 4: return this.static_;
				default: return null;
	        }
	    }
	
	    public ClassModifierSyntax WithAbstract_(Abstract_Syntax abstract_)
		{
			return this.Update(abstract_);
		}
	
	    public ClassModifierSyntax WithSealed_(Sealed_Syntax sealed_)
		{
			return this.Update(sealed_);
		}
	
	    public ClassModifierSyntax WithFixed_(Fixed_Syntax fixed_)
		{
			return this.Update(fixed_);
		}
	
	    public ClassModifierSyntax WithPartial_(Partial_Syntax partial_)
		{
			return this.Update(partial_);
		}
	
	    public ClassModifierSyntax WithStatic_(Static_Syntax static_)
		{
			return this.Update(static_);
		}
	
	    public ClassModifierSyntax Update(Abstract_Syntax abstract_)
	    {
	        if (this.Abstract_ != abstract_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassModifier(abstract_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ClassModifierSyntax Update(Sealed_Syntax sealed_)
	    {
	        if (this.Sealed_ != sealed_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassModifier(sealed_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ClassModifierSyntax Update(Fixed_Syntax fixed_)
	    {
	        if (this.Fixed_ != fixed_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassModifier(fixed_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ClassModifierSyntax Update(Partial_Syntax partial_)
	    {
	        if (this.Partial_ != partial_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassModifier(partial_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ClassModifierSyntax Update(Static_Syntax static_)
	    {
	        if (this.Static_ != static_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassModifier(static_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassModifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassModifier(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitClassModifier(this);
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
	    private ClassPhasesSyntax classPhases;
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
	    public ClassPhasesSyntax ClassPhases 
		{ 
			get { return this.GetRed(ref this.classPhases, 1); } 
		}
	    public SyntaxList<ClassMemberDeclarationSyntax> ClassMemberDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.classMemberDeclaration, 2);
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.classPhases, 1);
				case 2: return this.GetRed(ref this.classMemberDeclaration, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.classPhases;
				case 2: return this.classMemberDeclaration;
				default: return null;
	        }
	    }
	
	    public ClassBodySyntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.ClassPhases, this.ClassMemberDeclaration, this.TCloseBrace);
		}
	
	    public ClassBodySyntax WithClassPhases(ClassPhasesSyntax classPhases)
		{
			return this.Update(this.TOpenBrace, ClassPhases, this.ClassMemberDeclaration, this.TCloseBrace);
		}
	
	    public ClassBodySyntax WithClassMemberDeclaration(SyntaxList<ClassMemberDeclarationSyntax> classMemberDeclaration)
		{
			return this.Update(this.TOpenBrace, this.ClassPhases, ClassMemberDeclaration, this.TCloseBrace);
		}
	
	    public ClassBodySyntax AddClassMemberDeclaration(params ClassMemberDeclarationSyntax[] classMemberDeclaration)
		{
			return this.WithClassMemberDeclaration(this.ClassMemberDeclaration.AddRange(classMemberDeclaration));
		}
	
	    public ClassBodySyntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.ClassPhases, this.ClassMemberDeclaration, TCloseBrace);
		}
	
	    public ClassBodySyntax Update(SyntaxToken tOpenBrace, ClassPhasesSyntax classPhases, SyntaxList<ClassMemberDeclarationSyntax> classMemberDeclaration, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.ClassPhases != classPhases ||
				this.ClassMemberDeclaration != classMemberDeclaration ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassBody(tOpenBrace, classPhases, classMemberDeclaration, tCloseBrace);
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
	
	public sealed class ClassPhasesSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode phaseRef;
	
	    public ClassPhasesSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ClassPhasesSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KPhase 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ClassPhasesGreen)this.Green;
				var greenToken = green.KPhase;
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
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ClassPhasesGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
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
	
	    public ClassPhasesSyntax WithKPhase(SyntaxToken kPhase)
		{
			return this.Update(KPhase, this.PhaseRef, this.TSemicolon);
		}
	
	    public ClassPhasesSyntax WithPhaseRef(SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
		{
			return this.Update(this.KPhase, PhaseRef, this.TSemicolon);
		}
	
	    public ClassPhasesSyntax AddPhaseRef(params PhaseRefSyntax[] phaseRef)
		{
			return this.WithPhaseRef(this.PhaseRef.AddRange(phaseRef));
		}
	
	    public ClassPhasesSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KPhase, this.PhaseRef, TSemicolon);
		}
	
	    public ClassPhasesSyntax Update(SyntaxToken kPhase, SeparatedSyntaxList<PhaseRefSyntax> phaseRef, SyntaxToken tSemicolon)
	    {
	        if (this.KPhase != kPhase ||
				this.PhaseRef != phaseRef ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ClassPhases(kPhase, phaseRef, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ClassPhasesSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitClassPhases(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitClassPhases(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitClassPhases(this);
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
	    private VisibilitySyntax visibility;
	    private SyntaxNode memberModifier;
	    private FieldContainmentSyntax fieldContainment;
	    private FieldKindSyntax fieldKind;
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
	    public VisibilitySyntax Visibility 
		{ 
			get { return this.GetRed(ref this.visibility, 1); } 
		}
	    public SyntaxList<MemberModifierSyntax> MemberModifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.memberModifier, 2);
				if (red != null) return new SyntaxList<MemberModifierSyntax>(red);
				return default;
			} 
		}
	    public FieldContainmentSyntax FieldContainment 
		{ 
			get { return this.GetRed(ref this.fieldContainment, 3); } 
		}
	    public FieldKindSyntax FieldKind 
		{ 
			get { return this.GetRed(ref this.fieldKind, 4); } 
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 5); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 6); } 
		}
	    public DefaultValueSyntax DefaultValue 
		{ 
			get { return this.GetRed(ref this.defaultValue, 7); } 
		}
	    public PhaseSyntax Phase 
		{ 
			get { return this.GetRed(ref this.phase, 8); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.FieldDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(9), this.GetChildIndex(9));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.visibility, 1);
				case 2: return this.GetRed(ref this.memberModifier, 2);
				case 3: return this.GetRed(ref this.fieldContainment, 3);
				case 4: return this.GetRed(ref this.fieldKind, 4);
				case 5: return this.GetRed(ref this.typeReference, 5);
				case 6: return this.GetRed(ref this.name, 6);
				case 7: return this.GetRed(ref this.defaultValue, 7);
				case 8: return this.GetRed(ref this.phase, 8);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 1: return this.visibility;
				case 2: return this.memberModifier;
				case 3: return this.fieldContainment;
				case 4: return this.fieldKind;
				case 5: return this.typeReference;
				case 6: return this.name;
				case 7: return this.defaultValue;
				case 8: return this.phase;
				default: return null;
	        }
	    }
	
	    public FieldDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.Visibility, this.MemberModifier, this.FieldContainment, this.FieldKind, this.TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public FieldDeclarationSyntax WithVisibility(VisibilitySyntax visibility)
		{
			return this.Update(this.Attribute, Visibility, this.MemberModifier, this.FieldContainment, this.FieldKind, this.TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithMemberModifier(SyntaxList<MemberModifierSyntax> memberModifier)
		{
			return this.Update(this.Attribute, this.Visibility, MemberModifier, this.FieldContainment, this.FieldKind, this.TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax AddMemberModifier(params MemberModifierSyntax[] memberModifier)
		{
			return this.WithMemberModifier(this.MemberModifier.AddRange(memberModifier));
		}
	
	    public FieldDeclarationSyntax WithFieldContainment(FieldContainmentSyntax fieldContainment)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, FieldContainment, this.FieldKind, this.TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithFieldKind(FieldKindSyntax fieldKind)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.FieldContainment, FieldKind, this.TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.FieldContainment, this.FieldKind, TypeReference, this.Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.FieldContainment, this.FieldKind, this.TypeReference, Name, this.DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithDefaultValue(DefaultValueSyntax defaultValue)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.FieldContainment, this.FieldKind, this.TypeReference, this.Name, DefaultValue, this.Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithPhase(PhaseSyntax phase)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.FieldContainment, this.FieldKind, this.TypeReference, this.Name, this.DefaultValue, Phase, this.TSemicolon);
		}
	
	    public FieldDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.FieldContainment, this.FieldKind, this.TypeReference, this.Name, this.DefaultValue, this.Phase, TSemicolon);
		}
	
	    public FieldDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, VisibilitySyntax visibility, SyntaxList<MemberModifierSyntax> memberModifier, FieldContainmentSyntax fieldContainment, FieldKindSyntax fieldKind, TypeReferenceSyntax typeReference, NameSyntax name, DefaultValueSyntax defaultValue, PhaseSyntax phase, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.Visibility != visibility ||
				this.MemberModifier != memberModifier ||
				this.FieldContainment != fieldContainment ||
				this.FieldKind != fieldKind ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.DefaultValue != defaultValue ||
				this.Phase != phase ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.FieldDeclaration(attribute, visibility, memberModifier, fieldContainment, fieldKind, typeReference, name, defaultValue, phase, tSemicolon);
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
	
	public sealed class FieldKindSyntax : MetaCompilerSyntaxNode
	{
	
	    public FieldKindSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FieldKindSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken FieldKind 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.FieldKindGreen)this.Green;
				var greenToken = green.FieldKind;
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
	
	    public FieldKindSyntax WithFieldKind(SyntaxToken fieldKind)
		{
			return this.Update(FieldKind);
		}
	
	    public FieldKindSyntax Update(SyntaxToken fieldKind)
	    {
	        if (this.FieldKind != fieldKind)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.FieldKind(fieldKind);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FieldKindSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFieldKind(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFieldKind(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitFieldKind(this);
	    }
	}
	
	public sealed class MemberModifierSyntax : MetaCompilerSyntaxNode
	{
	    private Partial_Syntax partial_;
	    private Static_Syntax static_;
	    private Virtual_Syntax virtual_;
	    private Abstract_Syntax abstract_;
	    private Sealed_Syntax sealed_;
	    private New_Syntax new_;
	    private Override_Syntax override_;
	
	    public MemberModifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MemberModifierSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Partial_Syntax Partial_ 
		{ 
			get { return this.GetRed(ref this.partial_, 0); } 
		}
	    public Static_Syntax Static_ 
		{ 
			get { return this.GetRed(ref this.static_, 1); } 
		}
	    public Virtual_Syntax Virtual_ 
		{ 
			get { return this.GetRed(ref this.virtual_, 2); } 
		}
	    public Abstract_Syntax Abstract_ 
		{ 
			get { return this.GetRed(ref this.abstract_, 3); } 
		}
	    public Sealed_Syntax Sealed_ 
		{ 
			get { return this.GetRed(ref this.sealed_, 4); } 
		}
	    public New_Syntax New_ 
		{ 
			get { return this.GetRed(ref this.new_, 5); } 
		}
	    public Override_Syntax Override_ 
		{ 
			get { return this.GetRed(ref this.override_, 6); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.partial_, 0);
				case 1: return this.GetRed(ref this.static_, 1);
				case 2: return this.GetRed(ref this.virtual_, 2);
				case 3: return this.GetRed(ref this.abstract_, 3);
				case 4: return this.GetRed(ref this.sealed_, 4);
				case 5: return this.GetRed(ref this.new_, 5);
				case 6: return this.GetRed(ref this.override_, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.partial_;
				case 1: return this.static_;
				case 2: return this.virtual_;
				case 3: return this.abstract_;
				case 4: return this.sealed_;
				case 5: return this.new_;
				case 6: return this.override_;
				default: return null;
	        }
	    }
	
	    public MemberModifierSyntax WithPartial_(Partial_Syntax partial_)
		{
			return this.Update(partial_);
		}
	
	    public MemberModifierSyntax WithStatic_(Static_Syntax static_)
		{
			return this.Update(static_);
		}
	
	    public MemberModifierSyntax WithVirtual_(Virtual_Syntax virtual_)
		{
			return this.Update(virtual_);
		}
	
	    public MemberModifierSyntax WithAbstract_(Abstract_Syntax abstract_)
		{
			return this.Update(abstract_);
		}
	
	    public MemberModifierSyntax WithSealed_(Sealed_Syntax sealed_)
		{
			return this.Update(sealed_);
		}
	
	    public MemberModifierSyntax WithNew_(New_Syntax new_)
		{
			return this.Update(new_);
		}
	
	    public MemberModifierSyntax WithOverride_(Override_Syntax override_)
		{
			return this.Update(override_);
		}
	
	    public MemberModifierSyntax Update(Partial_Syntax partial_)
	    {
	        if (this.Partial_ != partial_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.MemberModifier(partial_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierSyntax Update(Static_Syntax static_)
	    {
	        if (this.Static_ != static_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.MemberModifier(static_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierSyntax Update(Virtual_Syntax virtual_)
	    {
	        if (this.Virtual_ != virtual_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.MemberModifier(virtual_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierSyntax Update(Abstract_Syntax abstract_)
	    {
	        if (this.Abstract_ != abstract_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.MemberModifier(abstract_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierSyntax Update(Sealed_Syntax sealed_)
	    {
	        if (this.Sealed_ != sealed_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.MemberModifier(sealed_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierSyntax Update(New_Syntax new_)
	    {
	        if (this.New_ != new_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.MemberModifier(new_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public MemberModifierSyntax Update(Override_Syntax override_)
	    {
	        if (this.Override_ != override_)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.MemberModifier(override_);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberModifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMemberModifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMemberModifier(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitMemberModifier(this);
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
	    private PhaseRefSyntax phaseRef;
	
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
	
	    public PhaseSyntax WithKPhase(SyntaxToken kPhase)
		{
			return this.Update(KPhase, this.PhaseRef);
		}
	
	    public PhaseSyntax WithPhaseRef(PhaseRefSyntax phaseRef)
		{
			return this.Update(this.KPhase, PhaseRef);
		}
	
	    public PhaseSyntax Update(SyntaxToken kPhase, PhaseRefSyntax phaseRef)
	    {
	        if (this.KPhase != kPhase ||
				this.PhaseRef != phaseRef)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Phase(kPhase, phaseRef);
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
	    private SimpleOrDictionaryTypeSyntax simpleOrDictionaryType;
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SimpleOrDictionaryTypeSyntax SimpleOrDictionaryType 
		{ 
			get { return this.GetRed(ref this.simpleOrDictionaryType, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.simpleOrDictionaryType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.simpleOrDictionaryType;
				default: return null;
	        }
	    }
	
	    public TypeReferenceSyntax WithSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax simpleOrDictionaryType)
		{
			return this.Update(SimpleOrDictionaryType);
		}
	
	    public TypeReferenceSyntax Update(SimpleOrDictionaryTypeSyntax simpleOrDictionaryType)
	    {
	        if (this.SimpleOrDictionaryType != simpleOrDictionaryType)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.TypeReference(simpleOrDictionaryType);
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
	
	public sealed class SimpleOrDictionaryTypeSyntax : MetaCompilerSyntaxNode
	{
	    private SimpleOrArrayTypeSyntax simpleOrArrayType;
	    private DictionaryTypeSyntax dictionaryType;
	
	    public SimpleOrDictionaryTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleOrDictionaryTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SimpleOrArrayTypeSyntax SimpleOrArrayType 
		{ 
			get { return this.GetRed(ref this.simpleOrArrayType, 0); } 
		}
	    public DictionaryTypeSyntax DictionaryType 
		{ 
			get { return this.GetRed(ref this.dictionaryType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.simpleOrArrayType, 0);
				case 1: return this.GetRed(ref this.dictionaryType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.simpleOrArrayType;
				case 1: return this.dictionaryType;
				default: return null;
	        }
	    }
	
	    public SimpleOrDictionaryTypeSyntax WithSimpleOrArrayType(SimpleOrArrayTypeSyntax simpleOrArrayType)
		{
			return this.Update(simpleOrArrayType);
		}
	
	    public SimpleOrDictionaryTypeSyntax WithDictionaryType(DictionaryTypeSyntax dictionaryType)
		{
			return this.Update(dictionaryType);
		}
	
	    public SimpleOrDictionaryTypeSyntax Update(SimpleOrArrayTypeSyntax simpleOrArrayType)
	    {
	        if (this.SimpleOrArrayType != simpleOrArrayType)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleOrDictionaryType(simpleOrArrayType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrDictionaryTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SimpleOrDictionaryTypeSyntax Update(DictionaryTypeSyntax dictionaryType)
	    {
	        if (this.DictionaryType != dictionaryType)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleOrDictionaryType(dictionaryType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrDictionaryTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleOrDictionaryType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleOrDictionaryType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleOrDictionaryType(this);
	    }
	}
	
	public sealed class SimpleOrArrayTypeSyntax : MetaCompilerSyntaxNode
	{
	    private SimpleOrGenericTypeSyntax simpleOrGenericType;
	    private ArrayTypeSyntax arrayType;
	
	    public SimpleOrArrayTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleOrArrayTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SimpleOrGenericTypeSyntax SimpleOrGenericType 
		{ 
			get { return this.GetRed(ref this.simpleOrGenericType, 0); } 
		}
	    public ArrayTypeSyntax ArrayType 
		{ 
			get { return this.GetRed(ref this.arrayType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.simpleOrGenericType, 0);
				case 1: return this.GetRed(ref this.arrayType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.simpleOrGenericType;
				case 1: return this.arrayType;
				default: return null;
	        }
	    }
	
	    public SimpleOrArrayTypeSyntax WithSimpleOrGenericType(SimpleOrGenericTypeSyntax simpleOrGenericType)
		{
			return this.Update(simpleOrGenericType);
		}
	
	    public SimpleOrArrayTypeSyntax WithArrayType(ArrayTypeSyntax arrayType)
		{
			return this.Update(arrayType);
		}
	
	    public SimpleOrArrayTypeSyntax Update(SimpleOrGenericTypeSyntax simpleOrGenericType)
	    {
	        if (this.SimpleOrGenericType != simpleOrGenericType)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleOrArrayType(simpleOrGenericType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrArrayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SimpleOrArrayTypeSyntax Update(ArrayTypeSyntax arrayType)
	    {
	        if (this.ArrayType != arrayType)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleOrArrayType(arrayType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrArrayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleOrArrayType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleOrArrayType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleOrArrayType(this);
	    }
	}
	
	public sealed class SimpleOrGenericTypeSyntax : MetaCompilerSyntaxNode
	{
	    private SimpleTypeSyntax simpleType;
	    private GenericTypeSyntax genericType;
	
	    public SimpleOrGenericTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleOrGenericTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SimpleTypeSyntax SimpleType 
		{ 
			get { return this.GetRed(ref this.simpleType, 0); } 
		}
	    public GenericTypeSyntax GenericType 
		{ 
			get { return this.GetRed(ref this.genericType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.simpleType, 0);
				case 1: return this.GetRed(ref this.genericType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.simpleType;
				case 1: return this.genericType;
				default: return null;
	        }
	    }
	
	    public SimpleOrGenericTypeSyntax WithSimpleType(SimpleTypeSyntax simpleType)
		{
			return this.Update(simpleType);
		}
	
	    public SimpleOrGenericTypeSyntax WithGenericType(GenericTypeSyntax genericType)
		{
			return this.Update(genericType);
		}
	
	    public SimpleOrGenericTypeSyntax Update(SimpleTypeSyntax simpleType)
	    {
	        if (this.SimpleType != simpleType)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleOrGenericType(simpleType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrGenericTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SimpleOrGenericTypeSyntax Update(GenericTypeSyntax genericType)
	    {
	        if (this.GenericType != genericType)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.SimpleOrGenericType(genericType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleOrGenericTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleOrGenericType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleOrGenericType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleOrGenericType(this);
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
	    private ClassTypeSyntax classType;
	    private TypeArgumentsSyntax typeArguments;
	
	    public GenericTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GenericTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ClassTypeSyntax ClassType 
		{ 
			get { return this.GetRed(ref this.classType, 0); } 
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
				case 0: return this.GetRed(ref this.classType, 0);
				case 2: return this.GetRed(ref this.typeArguments, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.classType;
				case 2: return this.typeArguments;
				default: return null;
	        }
	    }
	
	    public GenericTypeSyntax WithClassType(ClassTypeSyntax classType)
		{
			return this.Update(ClassType, this.TLessThan, this.TypeArguments, this.TGreaterThan);
		}
	
	    public GenericTypeSyntax WithTLessThan(SyntaxToken tLessThan)
		{
			return this.Update(this.ClassType, TLessThan, this.TypeArguments, this.TGreaterThan);
		}
	
	    public GenericTypeSyntax WithTypeArguments(TypeArgumentsSyntax typeArguments)
		{
			return this.Update(this.ClassType, this.TLessThan, TypeArguments, this.TGreaterThan);
		}
	
	    public GenericTypeSyntax WithTGreaterThan(SyntaxToken tGreaterThan)
		{
			return this.Update(this.ClassType, this.TLessThan, this.TypeArguments, TGreaterThan);
		}
	
	    public GenericTypeSyntax Update(ClassTypeSyntax classType, SyntaxToken tLessThan, TypeArgumentsSyntax typeArguments, SyntaxToken tGreaterThan)
	    {
	        if (this.ClassType != classType ||
				this.TLessThan != tLessThan ||
				this.TypeArguments != typeArguments ||
				this.TGreaterThan != tGreaterThan)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.GenericType(classType, tLessThan, typeArguments, tGreaterThan);
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
	
	public sealed class TypeArgumentsSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode typeReference;
	
	    public TypeArgumentsSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeArgumentsSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<TypeReferenceSyntax> TypeReference 
		{ 
			get
			{
				var red = this.GetRed(ref this.typeReference, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<TypeReferenceSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
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
	
	    public TypeArgumentsSyntax WithTypeReference(SeparatedSyntaxList<TypeReferenceSyntax> typeReference)
		{
			return this.Update(TypeReference);
		}
	
	    public TypeArgumentsSyntax AddTypeReference(params TypeReferenceSyntax[] typeReference)
		{
			return this.WithTypeReference(this.TypeReference.AddRange(typeReference));
		}
	
	    public TypeArgumentsSyntax Update(SeparatedSyntaxList<TypeReferenceSyntax> typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.TypeArguments(typeReference);
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
	
	public sealed class ArrayTypeSyntax : MetaCompilerSyntaxNode
	{
	    private SimpleOrGenericTypeSyntax simpleOrGenericType;
	
	    public ArrayTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArrayTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SimpleOrGenericTypeSyntax SimpleOrGenericType 
		{ 
			get { return this.GetRed(ref this.simpleOrGenericType, 0); } 
		}
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ArrayTypeGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.ArrayTypeGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.simpleOrGenericType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.simpleOrGenericType;
				default: return null;
	        }
	    }
	
	    public ArrayTypeSyntax WithSimpleOrGenericType(SimpleOrGenericTypeSyntax simpleOrGenericType)
		{
			return this.Update(SimpleOrGenericType, this.TOpenBracket, this.TCloseBracket);
		}
	
	    public ArrayTypeSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(this.SimpleOrGenericType, TOpenBracket, this.TCloseBracket);
		}
	
	    public ArrayTypeSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.SimpleOrGenericType, this.TOpenBracket, TCloseBracket);
		}
	
	    public ArrayTypeSyntax Update(SimpleOrGenericTypeSyntax simpleOrGenericType, SyntaxToken tOpenBracket, SyntaxToken tCloseBracket)
	    {
	        if (this.SimpleOrGenericType != simpleOrGenericType ||
				this.TOpenBracket != tOpenBracket ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.ArrayType(simpleOrGenericType, tOpenBracket, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrayType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrayType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitArrayType(this);
	    }
	}
	
	public sealed class DictionaryTypeSyntax : MetaCompilerSyntaxNode
	{
	    private SimpleOrArrayTypeSyntax key;
	    private SimpleOrArrayTypeSyntax value;
	
	    public DictionaryTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DictionaryTypeSyntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SimpleOrArrayTypeSyntax Key 
		{ 
			get { return this.GetRed(ref this.key, 0); } 
		}
	    public SyntaxToken TRightArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.DictionaryTypeGreen)this.Green;
				var greenToken = green.TRightArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SimpleOrArrayTypeSyntax Value 
		{ 
			get { return this.GetRed(ref this.value, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.key, 0);
				case 2: return this.GetRed(ref this.value, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.key;
				case 2: return this.value;
				default: return null;
	        }
	    }
	
	    public DictionaryTypeSyntax WithKey(SimpleOrArrayTypeSyntax key)
		{
			return this.Update(Key, this.TRightArrow, this.Value);
		}
	
	    public DictionaryTypeSyntax WithTRightArrow(SyntaxToken tRightArrow)
		{
			return this.Update(this.Key, TRightArrow, this.Value);
		}
	
	    public DictionaryTypeSyntax WithValue(SimpleOrArrayTypeSyntax value)
		{
			return this.Update(this.Key, this.TRightArrow, Value);
		}
	
	    public DictionaryTypeSyntax Update(SimpleOrArrayTypeSyntax key, SyntaxToken tRightArrow, SimpleOrArrayTypeSyntax value)
	    {
	        if (this.Key != key ||
				this.TRightArrow != tRightArrow ||
				this.Value != value)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.DictionaryType(key, tRightArrow, value);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DictionaryTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDictionaryType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDictionaryType(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitDictionaryType(this);
	    }
	}
	
	public sealed class OperationDeclarationSyntax : MetaCompilerSyntaxNode
	{
	    private SyntaxNode attribute;
	    private VisibilitySyntax visibility;
	    private SyntaxNode memberModifier;
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
	    public VisibilitySyntax Visibility 
		{ 
			get { return this.GetRed(ref this.visibility, 1); } 
		}
	    public SyntaxList<MemberModifierSyntax> MemberModifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.memberModifier, 2);
				if (red != null) return new SyntaxList<MemberModifierSyntax>(red);
				return default;
			} 
		}
	    public ReturnTypeSyntax ReturnType 
		{ 
			get { return this.GetRed(ref this.returnType, 3); } 
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 4); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	    public ParameterListSyntax ParameterList 
		{ 
			get { return this.GetRed(ref this.parameterList, 6); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(7), this.GetChildIndex(7));
			}
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.OperationDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(8), this.GetChildIndex(8));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.visibility, 1);
				case 2: return this.GetRed(ref this.memberModifier, 2);
				case 3: return this.GetRed(ref this.returnType, 3);
				case 4: return this.GetRed(ref this.name, 4);
				case 6: return this.GetRed(ref this.parameterList, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.attribute;
				case 1: return this.visibility;
				case 2: return this.memberModifier;
				case 3: return this.returnType;
				case 4: return this.name;
				case 6: return this.parameterList;
				default: return null;
	        }
	    }
	
	    public OperationDeclarationSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.Visibility, this.MemberModifier, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public OperationDeclarationSyntax WithVisibility(VisibilitySyntax visibility)
		{
			return this.Update(this.Attribute, Visibility, this.MemberModifier, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithMemberModifier(SyntaxList<MemberModifierSyntax> memberModifier)
		{
			return this.Update(this.Attribute, this.Visibility, MemberModifier, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax AddMemberModifier(params MemberModifierSyntax[] memberModifier)
		{
			return this.WithMemberModifier(this.MemberModifier.AddRange(memberModifier));
		}
	
	    public OperationDeclarationSyntax WithReturnType(ReturnTypeSyntax returnType)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.ReturnType, Name, this.TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.ReturnType, this.Name, TOpenParen, this.ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithParameterList(ParameterListSyntax parameterList)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.ReturnType, this.Name, this.TOpenParen, ParameterList, this.TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, TCloseParen, this.TSemicolon);
		}
	
	    public OperationDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Attribute, this.Visibility, this.MemberModifier, this.ReturnType, this.Name, this.TOpenParen, this.ParameterList, this.TCloseParen, TSemicolon);
		}
	
	    public OperationDeclarationSyntax Update(SyntaxList<AttributeSyntax> attribute, VisibilitySyntax visibility, SyntaxList<MemberModifierSyntax> memberModifier, ReturnTypeSyntax returnType, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
	    {
	        if (this.Attribute != attribute ||
				this.Visibility != visibility ||
				this.MemberModifier != memberModifier ||
				this.ReturnType != returnType ||
				this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.ParameterList != parameterList ||
				this.TCloseParen != tCloseParen ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.OperationDeclaration(attribute, visibility, memberModifier, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
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
	    private DefaultValueSyntax defaultValue;
	
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
	    public DefaultValueSyntax DefaultValue 
		{ 
			get { return this.GetRed(ref this.defaultValue, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.attribute, 0);
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 2: return this.GetRed(ref this.name, 2);
				case 3: return this.GetRed(ref this.defaultValue, 3);
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
				case 3: return this.defaultValue;
				default: return null;
	        }
	    }
	
	    public ParameterSyntax WithAttribute(SyntaxList<AttributeSyntax> attribute)
		{
			return this.Update(Attribute, this.TypeReference, this.Name, this.DefaultValue);
		}
	
	    public ParameterSyntax AddAttribute(params AttributeSyntax[] attribute)
		{
			return this.WithAttribute(this.Attribute.AddRange(attribute));
		}
	
	    public ParameterSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Attribute, TypeReference, this.Name, this.DefaultValue);
		}
	
	    public ParameterSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Attribute, this.TypeReference, Name, this.DefaultValue);
		}
	
	    public ParameterSyntax WithDefaultValue(DefaultValueSyntax defaultValue)
		{
			return this.Update(this.Attribute, this.TypeReference, this.Name, DefaultValue);
		}
	
	    public ParameterSyntax Update(SyntaxList<AttributeSyntax> attribute, TypeReferenceSyntax typeReference, NameSyntax name, DefaultValueSyntax defaultValue)
	    {
	        if (this.Attribute != attribute ||
				this.TypeReference != typeReference ||
				this.Name != name ||
				this.DefaultValue != defaultValue)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Parameter(attribute, typeReference, name, defaultValue);
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
	
	public sealed class Static_Syntax : MetaCompilerSyntaxNode
	{
	
	    public Static_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Static_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KStatic 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.Static_Green)this.Green;
				var greenToken = green.KStatic;
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
	
	    public Static_Syntax WithKStatic(SyntaxToken kStatic)
		{
			return this.Update(KStatic);
		}
	
	    public Static_Syntax Update(SyntaxToken kStatic)
	    {
	        if (this.KStatic != kStatic)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Static_(kStatic);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Static_Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStatic_(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStatic_(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitStatic_(this);
	    }
	}
	
	public sealed class Fixed_Syntax : MetaCompilerSyntaxNode
	{
	
	    public Fixed_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Fixed_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KFixed 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.Fixed_Green)this.Green;
				var greenToken = green.KFixed;
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
	
	    public Fixed_Syntax WithKFixed(SyntaxToken kFixed)
		{
			return this.Update(KFixed);
		}
	
	    public Fixed_Syntax Update(SyntaxToken kFixed)
	    {
	        if (this.KFixed != kFixed)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Fixed_(kFixed);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Fixed_Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFixed_(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFixed_(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitFixed_(this);
	    }
	}
	
	public sealed class Partial_Syntax : MetaCompilerSyntaxNode
	{
	
	    public Partial_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Partial_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KPartial 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.Partial_Green)this.Green;
				var greenToken = green.KPartial;
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
	
	    public Partial_Syntax WithKPartial(SyntaxToken kPartial)
		{
			return this.Update(KPartial);
		}
	
	    public Partial_Syntax Update(SyntaxToken kPartial)
	    {
	        if (this.KPartial != kPartial)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Partial_(kPartial);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Partial_Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPartial_(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPartial_(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitPartial_(this);
	    }
	}
	
	public sealed class Abstract_Syntax : MetaCompilerSyntaxNode
	{
	
	    public Abstract_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Abstract_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KAbstract 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.Abstract_Green)this.Green;
				var greenToken = green.KAbstract;
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
	
	    public Abstract_Syntax WithKAbstract(SyntaxToken kAbstract)
		{
			return this.Update(KAbstract);
		}
	
	    public Abstract_Syntax Update(SyntaxToken kAbstract)
	    {
	        if (this.KAbstract != kAbstract)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Abstract_(kAbstract);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Abstract_Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAbstract_(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAbstract_(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitAbstract_(this);
	    }
	}
	
	public sealed class Virtual_Syntax : MetaCompilerSyntaxNode
	{
	
	    public Virtual_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Virtual_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVirtual 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.Virtual_Green)this.Green;
				var greenToken = green.KVirtual;
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
	
	    public Virtual_Syntax WithKVirtual(SyntaxToken kVirtual)
		{
			return this.Update(KVirtual);
		}
	
	    public Virtual_Syntax Update(SyntaxToken kVirtual)
	    {
	        if (this.KVirtual != kVirtual)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Virtual_(kVirtual);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Virtual_Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVirtual_(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVirtual_(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitVirtual_(this);
	    }
	}
	
	public sealed class Sealed_Syntax : MetaCompilerSyntaxNode
	{
	
	    public Sealed_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Sealed_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KSealed 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.Sealed_Green)this.Green;
				var greenToken = green.KSealed;
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
	
	    public Sealed_Syntax WithKSealed(SyntaxToken kSealed)
		{
			return this.Update(KSealed);
		}
	
	    public Sealed_Syntax Update(SyntaxToken kSealed)
	    {
	        if (this.KSealed != kSealed)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Sealed_(kSealed);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Sealed_Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSealed_(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSealed_(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitSealed_(this);
	    }
	}
	
	public sealed class Override_Syntax : MetaCompilerSyntaxNode
	{
	
	    public Override_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Override_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KOverride 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.Override_Green)this.Green;
				var greenToken = green.KOverride;
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
	
	    public Override_Syntax WithKOverride(SyntaxToken kOverride)
		{
			return this.Update(KOverride);
		}
	
	    public Override_Syntax Update(SyntaxToken kOverride)
	    {
	        if (this.KOverride != kOverride)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.Override_(kOverride);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Override_Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOverride_(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOverride_(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitOverride_(this);
	    }
	}
	
	public sealed class New_Syntax : MetaCompilerSyntaxNode
	{
	
	    public New_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public New_Syntax(InternalSyntaxNode green, MetaCompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNew 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax.New_Green)this.Green;
				var greenToken = green.KNew;
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
	
	    public New_Syntax WithKNew(SyntaxToken kNew)
		{
			return this.Update(KNew);
		}
	
	    public New_Syntax Update(SyntaxToken kNew)
	    {
	        if (this.KNew != kNew)
	        {
	            var newNode = MetaCompilerLanguage.Instance.SyntaxFactory.New_(kNew);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (New_Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IMetaCompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNew_(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IMetaCompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNew_(this);
	    }
	
	    public override void Accept(IMetaCompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitNew_(this);
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
		
		void VisitLocked(LockedSyntax node);
		
		void VisitPhaseJoin(PhaseJoinSyntax node);
		
		void VisitAfterPhases(AfterPhasesSyntax node);
		
		void VisitBeforePhases(BeforePhasesSyntax node);
		
		void VisitPhaseRef(PhaseRefSyntax node);
		
		void VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		void VisitEnumBody(EnumBodySyntax node);
		
		void VisitEnumValues(EnumValuesSyntax node);
		
		void VisitEnumValue(EnumValueSyntax node);
		
		void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node);
		
		void VisitVisibility(VisibilitySyntax node);
		
		void VisitClassDeclaration(ClassDeclarationSyntax node);
		
		void VisitClassModifier(ClassModifierSyntax node);
		
		void VisitClassAncestors(ClassAncestorsSyntax node);
		
		void VisitClassAncestor(ClassAncestorSyntax node);
		
		void VisitClassBody(ClassBodySyntax node);
		
		void VisitClassPhases(ClassPhasesSyntax node);
		
		void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node);
		
		void VisitClassKind(ClassKindSyntax node);
		
		void VisitFieldDeclaration(FieldDeclarationSyntax node);
		
		void VisitFieldContainment(FieldContainmentSyntax node);
		
		void VisitFieldKind(FieldKindSyntax node);
		
		void VisitMemberModifier(MemberModifierSyntax node);
		
		void VisitDefaultValue(DefaultValueSyntax node);
		
		void VisitPhase(PhaseSyntax node);
		
		void VisitNameUseList(NameUseListSyntax node);
		
		void VisitTypedefDeclaration(TypedefDeclarationSyntax node);
		
		void VisitTypedefValue(TypedefValueSyntax node);
		
		void VisitReturnType(ReturnTypeSyntax node);
		
		void VisitTypeOfReference(TypeOfReferenceSyntax node);
		
		void VisitTypeReference(TypeReferenceSyntax node);
		
		void VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node);
		
		void VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node);
		
		void VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node);
		
		void VisitSimpleType(SimpleTypeSyntax node);
		
		void VisitClassType(ClassTypeSyntax node);
		
		void VisitObjectType(ObjectTypeSyntax node);
		
		void VisitPrimitiveType(PrimitiveTypeSyntax node);
		
		void VisitVoidType(VoidTypeSyntax node);
		
		void VisitNullableType(NullableTypeSyntax node);
		
		void VisitGenericType(GenericTypeSyntax node);
		
		void VisitTypeArguments(TypeArgumentsSyntax node);
		
		void VisitArrayType(ArrayTypeSyntax node);
		
		void VisitDictionaryType(DictionaryTypeSyntax node);
		
		void VisitOperationDeclaration(OperationDeclarationSyntax node);
		
		void VisitParameterList(ParameterListSyntax node);
		
		void VisitParameter(ParameterSyntax node);
		
		void VisitStatic_(Static_Syntax node);
		
		void VisitFixed_(Fixed_Syntax node);
		
		void VisitPartial_(Partial_Syntax node);
		
		void VisitAbstract_(Abstract_Syntax node);
		
		void VisitVirtual_(Virtual_Syntax node);
		
		void VisitSealed_(Sealed_Syntax node);
		
		void VisitOverride_(Override_Syntax node);
		
		void VisitNew_(New_Syntax node);
		
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
		
		public virtual void VisitLocked(LockedSyntax node)
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
		
		public virtual void VisitVisibility(VisibilitySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassDeclaration(ClassDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitClassModifier(ClassModifierSyntax node)
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
		
		public virtual void VisitClassPhases(ClassPhasesSyntax node)
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
		
		public virtual void VisitFieldKind(FieldKindSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMemberModifier(MemberModifierSyntax node)
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
		
		public virtual void VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node)
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
		
		public virtual void VisitTypeArguments(TypeArgumentsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrayType(ArrayTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDictionaryType(DictionaryTypeSyntax node)
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
		
		public virtual void VisitStatic_(Static_Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFixed_(Fixed_Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPartial_(Partial_Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAbstract_(Abstract_Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVirtual_(Virtual_Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSealed_(Sealed_Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOverride_(Override_Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNew_(New_Syntax node)
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
		
		TResult VisitLocked(LockedSyntax node, TArg argument);
		
		TResult VisitPhaseJoin(PhaseJoinSyntax node, TArg argument);
		
		TResult VisitAfterPhases(AfterPhasesSyntax node, TArg argument);
		
		TResult VisitBeforePhases(BeforePhasesSyntax node, TArg argument);
		
		TResult VisitPhaseRef(PhaseRefSyntax node, TArg argument);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node, TArg argument);
		
		TResult VisitEnumBody(EnumBodySyntax node, TArg argument);
		
		TResult VisitEnumValues(EnumValuesSyntax node, TArg argument);
		
		TResult VisitEnumValue(EnumValueSyntax node, TArg argument);
		
		TResult VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node, TArg argument);
		
		TResult VisitVisibility(VisibilitySyntax node, TArg argument);
		
		TResult VisitClassDeclaration(ClassDeclarationSyntax node, TArg argument);
		
		TResult VisitClassModifier(ClassModifierSyntax node, TArg argument);
		
		TResult VisitClassAncestors(ClassAncestorsSyntax node, TArg argument);
		
		TResult VisitClassAncestor(ClassAncestorSyntax node, TArg argument);
		
		TResult VisitClassBody(ClassBodySyntax node, TArg argument);
		
		TResult VisitClassPhases(ClassPhasesSyntax node, TArg argument);
		
		TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node, TArg argument);
		
		TResult VisitClassKind(ClassKindSyntax node, TArg argument);
		
		TResult VisitFieldDeclaration(FieldDeclarationSyntax node, TArg argument);
		
		TResult VisitFieldContainment(FieldContainmentSyntax node, TArg argument);
		
		TResult VisitFieldKind(FieldKindSyntax node, TArg argument);
		
		TResult VisitMemberModifier(MemberModifierSyntax node, TArg argument);
		
		TResult VisitDefaultValue(DefaultValueSyntax node, TArg argument);
		
		TResult VisitPhase(PhaseSyntax node, TArg argument);
		
		TResult VisitNameUseList(NameUseListSyntax node, TArg argument);
		
		TResult VisitTypedefDeclaration(TypedefDeclarationSyntax node, TArg argument);
		
		TResult VisitTypedefValue(TypedefValueSyntax node, TArg argument);
		
		TResult VisitReturnType(ReturnTypeSyntax node, TArg argument);
		
		TResult VisitTypeOfReference(TypeOfReferenceSyntax node, TArg argument);
		
		TResult VisitTypeReference(TypeReferenceSyntax node, TArg argument);
		
		TResult VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node, TArg argument);
		
		TResult VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node, TArg argument);
		
		TResult VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node, TArg argument);
		
		TResult VisitSimpleType(SimpleTypeSyntax node, TArg argument);
		
		TResult VisitClassType(ClassTypeSyntax node, TArg argument);
		
		TResult VisitObjectType(ObjectTypeSyntax node, TArg argument);
		
		TResult VisitPrimitiveType(PrimitiveTypeSyntax node, TArg argument);
		
		TResult VisitVoidType(VoidTypeSyntax node, TArg argument);
		
		TResult VisitNullableType(NullableTypeSyntax node, TArg argument);
		
		TResult VisitGenericType(GenericTypeSyntax node, TArg argument);
		
		TResult VisitTypeArguments(TypeArgumentsSyntax node, TArg argument);
		
		TResult VisitArrayType(ArrayTypeSyntax node, TArg argument);
		
		TResult VisitDictionaryType(DictionaryTypeSyntax node, TArg argument);
		
		TResult VisitOperationDeclaration(OperationDeclarationSyntax node, TArg argument);
		
		TResult VisitParameterList(ParameterListSyntax node, TArg argument);
		
		TResult VisitParameter(ParameterSyntax node, TArg argument);
		
		TResult VisitStatic_(Static_Syntax node, TArg argument);
		
		TResult VisitFixed_(Fixed_Syntax node, TArg argument);
		
		TResult VisitPartial_(Partial_Syntax node, TArg argument);
		
		TResult VisitAbstract_(Abstract_Syntax node, TArg argument);
		
		TResult VisitVirtual_(Virtual_Syntax node, TArg argument);
		
		TResult VisitSealed_(Sealed_Syntax node, TArg argument);
		
		TResult VisitOverride_(Override_Syntax node, TArg argument);
		
		TResult VisitNew_(New_Syntax node, TArg argument);
		
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
		
		public virtual TResult VisitLocked(LockedSyntax node, TArg argument)
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
		
		public virtual TResult VisitVisibility(VisibilitySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassDeclaration(ClassDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitClassModifier(ClassModifierSyntax node, TArg argument)
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
		
		public virtual TResult VisitClassPhases(ClassPhasesSyntax node, TArg argument)
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
		
		public virtual TResult VisitFieldKind(FieldKindSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMemberModifier(MemberModifierSyntax node, TArg argument)
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
		
		public virtual TResult VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node, TArg argument)
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
		
		public virtual TResult VisitTypeArguments(TypeArgumentsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrayType(ArrayTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDictionaryType(DictionaryTypeSyntax node, TArg argument)
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
		
		public virtual TResult VisitStatic_(Static_Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFixed_(Fixed_Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPartial_(Partial_Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAbstract_(Abstract_Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVirtual_(Virtual_Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSealed_(Sealed_Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOverride_(Override_Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNew_(New_Syntax node, TArg argument)
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
		
		TResult VisitLocked(LockedSyntax node);
		
		TResult VisitPhaseJoin(PhaseJoinSyntax node);
		
		TResult VisitAfterPhases(AfterPhasesSyntax node);
		
		TResult VisitBeforePhases(BeforePhasesSyntax node);
		
		TResult VisitPhaseRef(PhaseRefSyntax node);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		TResult VisitEnumBody(EnumBodySyntax node);
		
		TResult VisitEnumValues(EnumValuesSyntax node);
		
		TResult VisitEnumValue(EnumValueSyntax node);
		
		TResult VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node);
		
		TResult VisitVisibility(VisibilitySyntax node);
		
		TResult VisitClassDeclaration(ClassDeclarationSyntax node);
		
		TResult VisitClassModifier(ClassModifierSyntax node);
		
		TResult VisitClassAncestors(ClassAncestorsSyntax node);
		
		TResult VisitClassAncestor(ClassAncestorSyntax node);
		
		TResult VisitClassBody(ClassBodySyntax node);
		
		TResult VisitClassPhases(ClassPhasesSyntax node);
		
		TResult VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node);
		
		TResult VisitClassKind(ClassKindSyntax node);
		
		TResult VisitFieldDeclaration(FieldDeclarationSyntax node);
		
		TResult VisitFieldContainment(FieldContainmentSyntax node);
		
		TResult VisitFieldKind(FieldKindSyntax node);
		
		TResult VisitMemberModifier(MemberModifierSyntax node);
		
		TResult VisitDefaultValue(DefaultValueSyntax node);
		
		TResult VisitPhase(PhaseSyntax node);
		
		TResult VisitNameUseList(NameUseListSyntax node);
		
		TResult VisitTypedefDeclaration(TypedefDeclarationSyntax node);
		
		TResult VisitTypedefValue(TypedefValueSyntax node);
		
		TResult VisitReturnType(ReturnTypeSyntax node);
		
		TResult VisitTypeOfReference(TypeOfReferenceSyntax node);
		
		TResult VisitTypeReference(TypeReferenceSyntax node);
		
		TResult VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node);
		
		TResult VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node);
		
		TResult VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node);
		
		TResult VisitSimpleType(SimpleTypeSyntax node);
		
		TResult VisitClassType(ClassTypeSyntax node);
		
		TResult VisitObjectType(ObjectTypeSyntax node);
		
		TResult VisitPrimitiveType(PrimitiveTypeSyntax node);
		
		TResult VisitVoidType(VoidTypeSyntax node);
		
		TResult VisitNullableType(NullableTypeSyntax node);
		
		TResult VisitGenericType(GenericTypeSyntax node);
		
		TResult VisitTypeArguments(TypeArgumentsSyntax node);
		
		TResult VisitArrayType(ArrayTypeSyntax node);
		
		TResult VisitDictionaryType(DictionaryTypeSyntax node);
		
		TResult VisitOperationDeclaration(OperationDeclarationSyntax node);
		
		TResult VisitParameterList(ParameterListSyntax node);
		
		TResult VisitParameter(ParameterSyntax node);
		
		TResult VisitStatic_(Static_Syntax node);
		
		TResult VisitFixed_(Fixed_Syntax node);
		
		TResult VisitPartial_(Partial_Syntax node);
		
		TResult VisitAbstract_(Abstract_Syntax node);
		
		TResult VisitVirtual_(Virtual_Syntax node);
		
		TResult VisitSealed_(Sealed_Syntax node);
		
		TResult VisitOverride_(Override_Syntax node);
		
		TResult VisitNew_(New_Syntax node);
		
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
		
		public virtual TResult VisitLocked(LockedSyntax node)
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
		
		public virtual TResult VisitVisibility(VisibilitySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassDeclaration(ClassDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitClassModifier(ClassModifierSyntax node)
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
		
		public virtual TResult VisitClassPhases(ClassPhasesSyntax node)
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
		
		public virtual TResult VisitFieldKind(FieldKindSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMemberModifier(MemberModifierSyntax node)
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
		
		public virtual TResult VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node)
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
		
		public virtual TResult VisitTypeArguments(TypeArgumentsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrayType(ArrayTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDictionaryType(DictionaryTypeSyntax node)
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
		
		public virtual TResult VisitStatic_(Static_Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFixed_(Fixed_Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPartial_(Partial_Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAbstract_(Abstract_Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVirtual_(Virtual_Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSealed_(Sealed_Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOverride_(Override_Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNew_(New_Syntax node)
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
		    var locked = (LockedSyntax)this.Visit(node.Locked);
		    var kPhase = this.VisitToken(node.KPhase);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var phaseJoin = (PhaseJoinSyntax)this.Visit(node.PhaseJoin);
		    var afterPhases = (AfterPhasesSyntax)this.Visit(node.AfterPhases);
		    var beforePhases = (BeforePhasesSyntax)this.Visit(node.BeforePhases);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, locked, kPhase, name, phaseJoin, afterPhases, beforePhases, tSemicolon);
		}
		
		public virtual SyntaxNode VisitLocked(LockedSyntax node)
		{
		    var kLocked = this.VisitToken(node.KLocked);
			return node.Update(kLocked);
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
		
		public virtual SyntaxNode VisitVisibility(VisibilitySyntax node)
		{
		    var visibility = this.VisitToken(node.Visibility);
			return node.Update(visibility);
		}
		
		public virtual SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var visibility = (VisibilitySyntax)this.Visit(node.Visibility);
		    var classModifier = this.VisitList(node.ClassModifier);
		    var classKind = (ClassKindSyntax)this.Visit(node.ClassKind);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var classAncestors = (ClassAncestorsSyntax)this.Visit(node.ClassAncestors);
		    var classBody = (ClassBodySyntax)this.Visit(node.ClassBody);
			return node.Update(attribute, visibility, classModifier, classKind, name, tColon, classAncestors, classBody);
		}
		
		public virtual SyntaxNode VisitClassModifier(ClassModifierSyntax node)
		{
			var oldAbstract_ = node.Abstract_;
			if (oldAbstract_ != null)
			{
			    var newAbstract_ = (Abstract_Syntax)this.Visit(oldAbstract_);
				return node.Update(newAbstract_);
			}
			var oldSealed_ = node.Sealed_;
			if (oldSealed_ != null)
			{
			    var newSealed_ = (Sealed_Syntax)this.Visit(oldSealed_);
				return node.Update(newSealed_);
			}
			var oldFixed_ = node.Fixed_;
			if (oldFixed_ != null)
			{
			    var newFixed_ = (Fixed_Syntax)this.Visit(oldFixed_);
				return node.Update(newFixed_);
			}
			var oldPartial_ = node.Partial_;
			if (oldPartial_ != null)
			{
			    var newPartial_ = (Partial_Syntax)this.Visit(oldPartial_);
				return node.Update(newPartial_);
			}
			var oldStatic_ = node.Static_;
			if (oldStatic_ != null)
			{
			    var newStatic_ = (Static_Syntax)this.Visit(oldStatic_);
				return node.Update(newStatic_);
			}
			return node;   
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
		    var classPhases = (ClassPhasesSyntax)this.Visit(node.ClassPhases);
		    var classMemberDeclaration = this.VisitList(node.ClassMemberDeclaration);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, classPhases, classMemberDeclaration, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitClassPhases(ClassPhasesSyntax node)
		{
		    var kPhase = this.VisitToken(node.KPhase);
		    var phaseRef = this.VisitList(node.PhaseRef);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kPhase, phaseRef, tSemicolon);
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
		    var visibility = (VisibilitySyntax)this.Visit(node.Visibility);
		    var memberModifier = this.VisitList(node.MemberModifier);
		    var fieldContainment = (FieldContainmentSyntax)this.Visit(node.FieldContainment);
		    var fieldKind = (FieldKindSyntax)this.Visit(node.FieldKind);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var defaultValue = (DefaultValueSyntax)this.Visit(node.DefaultValue);
		    var phase = (PhaseSyntax)this.Visit(node.Phase);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, visibility, memberModifier, fieldContainment, fieldKind, typeReference, name, defaultValue, phase, tSemicolon);
		}
		
		public virtual SyntaxNode VisitFieldContainment(FieldContainmentSyntax node)
		{
		    var kContainment = this.VisitToken(node.KContainment);
			return node.Update(kContainment);
		}
		
		public virtual SyntaxNode VisitFieldKind(FieldKindSyntax node)
		{
		    var fieldKind = this.VisitToken(node.FieldKind);
			return node.Update(fieldKind);
		}
		
		public virtual SyntaxNode VisitMemberModifier(MemberModifierSyntax node)
		{
			var oldPartial_ = node.Partial_;
			if (oldPartial_ != null)
			{
			    var newPartial_ = (Partial_Syntax)this.Visit(oldPartial_);
				return node.Update(newPartial_);
			}
			var oldStatic_ = node.Static_;
			if (oldStatic_ != null)
			{
			    var newStatic_ = (Static_Syntax)this.Visit(oldStatic_);
				return node.Update(newStatic_);
			}
			var oldVirtual_ = node.Virtual_;
			if (oldVirtual_ != null)
			{
			    var newVirtual_ = (Virtual_Syntax)this.Visit(oldVirtual_);
				return node.Update(newVirtual_);
			}
			var oldAbstract_ = node.Abstract_;
			if (oldAbstract_ != null)
			{
			    var newAbstract_ = (Abstract_Syntax)this.Visit(oldAbstract_);
				return node.Update(newAbstract_);
			}
			var oldSealed_ = node.Sealed_;
			if (oldSealed_ != null)
			{
			    var newSealed_ = (Sealed_Syntax)this.Visit(oldSealed_);
				return node.Update(newSealed_);
			}
			var oldNew_ = node.New_;
			if (oldNew_ != null)
			{
			    var newNew_ = (New_Syntax)this.Visit(oldNew_);
				return node.Update(newNew_);
			}
			var oldOverride_ = node.Override_;
			if (oldOverride_ != null)
			{
			    var newOverride_ = (Override_Syntax)this.Visit(oldOverride_);
				return node.Update(newOverride_);
			}
			return node;   
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
		    var phaseRef = (PhaseRefSyntax)this.Visit(node.PhaseRef);
			return node.Update(kPhase, phaseRef);
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
		    var simpleOrDictionaryType = (SimpleOrDictionaryTypeSyntax)this.Visit(node.SimpleOrDictionaryType);
			return node.Update(simpleOrDictionaryType);
		}
		
		public virtual SyntaxNode VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node)
		{
			var oldSimpleOrArrayType = node.SimpleOrArrayType;
			if (oldSimpleOrArrayType != null)
			{
			    var newSimpleOrArrayType = (SimpleOrArrayTypeSyntax)this.Visit(oldSimpleOrArrayType);
				return node.Update(newSimpleOrArrayType);
			}
			var oldDictionaryType = node.DictionaryType;
			if (oldDictionaryType != null)
			{
			    var newDictionaryType = (DictionaryTypeSyntax)this.Visit(oldDictionaryType);
				return node.Update(newDictionaryType);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node)
		{
			var oldSimpleOrGenericType = node.SimpleOrGenericType;
			if (oldSimpleOrGenericType != null)
			{
			    var newSimpleOrGenericType = (SimpleOrGenericTypeSyntax)this.Visit(oldSimpleOrGenericType);
				return node.Update(newSimpleOrGenericType);
			}
			var oldArrayType = node.ArrayType;
			if (oldArrayType != null)
			{
			    var newArrayType = (ArrayTypeSyntax)this.Visit(oldArrayType);
				return node.Update(newArrayType);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node)
		{
			var oldSimpleType = node.SimpleType;
			if (oldSimpleType != null)
			{
			    var newSimpleType = (SimpleTypeSyntax)this.Visit(oldSimpleType);
				return node.Update(newSimpleType);
			}
			var oldGenericType = node.GenericType;
			if (oldGenericType != null)
			{
			    var newGenericType = (GenericTypeSyntax)this.Visit(oldGenericType);
				return node.Update(newGenericType);
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
		    var classType = (ClassTypeSyntax)this.Visit(node.ClassType);
		    var tLessThan = this.VisitToken(node.TLessThan);
		    var typeArguments = (TypeArgumentsSyntax)this.Visit(node.TypeArguments);
		    var tGreaterThan = this.VisitToken(node.TGreaterThan);
			return node.Update(classType, tLessThan, typeArguments, tGreaterThan);
		}
		
		public virtual SyntaxNode VisitTypeArguments(TypeArgumentsSyntax node)
		{
		    var typeReference = this.VisitList(node.TypeReference);
			return node.Update(typeReference);
		}
		
		public virtual SyntaxNode VisitArrayType(ArrayTypeSyntax node)
		{
		    var simpleOrGenericType = (SimpleOrGenericTypeSyntax)this.Visit(node.SimpleOrGenericType);
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(simpleOrGenericType, tOpenBracket, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitDictionaryType(DictionaryTypeSyntax node)
		{
		    var key = (SimpleOrArrayTypeSyntax)this.Visit(node.Key);
		    var tRightArrow = this.VisitToken(node.TRightArrow);
		    var value = (SimpleOrArrayTypeSyntax)this.Visit(node.Value);
			return node.Update(key, tRightArrow, value);
		}
		
		public virtual SyntaxNode VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
		    var attribute = this.VisitList(node.Attribute);
		    var visibility = (VisibilitySyntax)this.Visit(node.Visibility);
		    var memberModifier = this.VisitList(node.MemberModifier);
		    var returnType = (ReturnTypeSyntax)this.Visit(node.ReturnType);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var parameterList = (ParameterListSyntax)this.Visit(node.ParameterList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(attribute, visibility, memberModifier, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
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
		    var defaultValue = (DefaultValueSyntax)this.Visit(node.DefaultValue);
			return node.Update(attribute, typeReference, name, defaultValue);
		}
		
		public virtual SyntaxNode VisitStatic_(Static_Syntax node)
		{
		    var kStatic = this.VisitToken(node.KStatic);
			return node.Update(kStatic);
		}
		
		public virtual SyntaxNode VisitFixed_(Fixed_Syntax node)
		{
		    var kFixed = this.VisitToken(node.KFixed);
			return node.Update(kFixed);
		}
		
		public virtual SyntaxNode VisitPartial_(Partial_Syntax node)
		{
		    var kPartial = this.VisitToken(node.KPartial);
			return node.Update(kPartial);
		}
		
		public virtual SyntaxNode VisitAbstract_(Abstract_Syntax node)
		{
		    var kAbstract = this.VisitToken(node.KAbstract);
			return node.Update(kAbstract);
		}
		
		public virtual SyntaxNode VisitVirtual_(Virtual_Syntax node)
		{
		    var kVirtual = this.VisitToken(node.KVirtual);
			return node.Update(kVirtual);
		}
		
		public virtual SyntaxNode VisitSealed_(Sealed_Syntax node)
		{
		    var kSealed = this.VisitToken(node.KSealed);
			return node.Update(kSealed);
		}
		
		public virtual SyntaxNode VisitOverride_(Override_Syntax node)
		{
		    var kOverride = this.VisitToken(node.KOverride);
			return node.Update(kOverride);
		}
		
		public virtual SyntaxNode VisitNew_(New_Syntax node)
		{
		    var kNew = this.VisitToken(node.KNew);
			return node.Update(kNew);
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
		
		public PhaseDeclarationSyntax PhaseDeclaration(SyntaxList<AttributeSyntax> attribute, LockedSyntax locked, SyntaxToken kPhase, NameSyntax name, PhaseJoinSyntax phaseJoin, AfterPhasesSyntax afterPhases, BeforePhasesSyntax beforePhases, SyntaxToken tSemicolon)
		{
		    if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
		    if (kPhase.GetKind() != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (PhaseDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.PhaseDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), locked == null ? null : (Syntax.InternalSyntax.LockedGreen)locked.Green, (InternalSyntaxToken)kPhase.Node, (Syntax.InternalSyntax.NameGreen)name.Green, phaseJoin == null ? null : (Syntax.InternalSyntax.PhaseJoinGreen)phaseJoin.Green, afterPhases == null ? null : (Syntax.InternalSyntax.AfterPhasesGreen)afterPhases.Green, beforePhases == null ? null : (Syntax.InternalSyntax.BeforePhasesGreen)beforePhases.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public PhaseDeclarationSyntax PhaseDeclaration(NameSyntax name)
		{
			return this.PhaseDeclaration(default, default, this.Token(MetaCompilerSyntaxKind.KPhase), name, default, default, default, this.Token(MetaCompilerSyntaxKind.TSemicolon));
		}
		
		public LockedSyntax Locked(SyntaxToken kLocked)
		{
		    if (kLocked == null) throw new ArgumentNullException(nameof(kLocked));
		    if (kLocked.GetKind() != MetaCompilerSyntaxKind.KLocked) throw new ArgumentException(nameof(kLocked));
		    return (LockedSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Locked((InternalSyntaxToken)kLocked.Node).CreateRed();
		}
		
		public LockedSyntax Locked()
		{
			return this.Locked(this.Token(MetaCompilerSyntaxKind.KLocked));
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
		
		public VisibilitySyntax Visibility(SyntaxToken visibility)
		{
		    if (visibility == null) throw new ArgumentNullException(nameof(visibility));
		    return (VisibilitySyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Visibility((InternalSyntaxToken)visibility.Node).CreateRed();
		}
		
		public ClassDeclarationSyntax ClassDeclaration(SyntaxList<AttributeSyntax> attribute, VisibilitySyntax visibility, SyntaxList<ClassModifierSyntax> classModifier, ClassKindSyntax classKind, NameSyntax name, SyntaxToken tColon, ClassAncestorsSyntax classAncestors, ClassBodySyntax classBody)
		{
		    if (classKind == null) throw new ArgumentNullException(nameof(classKind));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon != null && tColon.GetKind() != MetaCompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (classBody == null) throw new ArgumentNullException(nameof(classBody));
		    return (ClassDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), visibility == null ? null : (Syntax.InternalSyntax.VisibilityGreen)visibility.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ClassModifierGreen>(classModifier.Node), (Syntax.InternalSyntax.ClassKindGreen)classKind.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, classAncestors == null ? null : (Syntax.InternalSyntax.ClassAncestorsGreen)classAncestors.Green, (Syntax.InternalSyntax.ClassBodyGreen)classBody.Green).CreateRed();
		}
		
		public ClassDeclarationSyntax ClassDeclaration(ClassKindSyntax classKind, NameSyntax name, ClassBodySyntax classBody)
		{
			return this.ClassDeclaration(default, default, default, classKind, name, default, default, classBody);
		}
		
		public ClassModifierSyntax ClassModifier(Abstract_Syntax abstract_)
		{
		    if (abstract_ == null) throw new ArgumentNullException(nameof(abstract_));
		    return (ClassModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassModifier((Syntax.InternalSyntax.Abstract_Green)abstract_.Green).CreateRed();
		}
		
		public ClassModifierSyntax ClassModifier(Sealed_Syntax sealed_)
		{
		    if (sealed_ == null) throw new ArgumentNullException(nameof(sealed_));
		    return (ClassModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassModifier((Syntax.InternalSyntax.Sealed_Green)sealed_.Green).CreateRed();
		}
		
		public ClassModifierSyntax ClassModifier(Fixed_Syntax fixed_)
		{
		    if (fixed_ == null) throw new ArgumentNullException(nameof(fixed_));
		    return (ClassModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassModifier((Syntax.InternalSyntax.Fixed_Green)fixed_.Green).CreateRed();
		}
		
		public ClassModifierSyntax ClassModifier(Partial_Syntax partial_)
		{
		    if (partial_ == null) throw new ArgumentNullException(nameof(partial_));
		    return (ClassModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassModifier((Syntax.InternalSyntax.Partial_Green)partial_.Green).CreateRed();
		}
		
		public ClassModifierSyntax ClassModifier(Static_Syntax static_)
		{
		    if (static_ == null) throw new ArgumentNullException(nameof(static_));
		    return (ClassModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassModifier((Syntax.InternalSyntax.Static_Green)static_.Green).CreateRed();
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
		
		public ClassBodySyntax ClassBody(SyntaxToken tOpenBrace, ClassPhasesSyntax classPhases, SyntaxList<ClassMemberDeclarationSyntax> classMemberDeclaration, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != MetaCompilerSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != MetaCompilerSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (ClassBodySyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassBody((InternalSyntaxToken)tOpenBrace.Node, classPhases == null ? null : (Syntax.InternalSyntax.ClassPhasesGreen)classPhases.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ClassMemberDeclarationGreen>(classMemberDeclaration.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public ClassBodySyntax ClassBody()
		{
			return this.ClassBody(this.Token(MetaCompilerSyntaxKind.TOpenBrace), default, default, this.Token(MetaCompilerSyntaxKind.TCloseBrace));
		}
		
		public ClassPhasesSyntax ClassPhases(SyntaxToken kPhase, SeparatedSyntaxList<PhaseRefSyntax> phaseRef, SyntaxToken tSemicolon)
		{
		    if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
		    if (kPhase.GetKind() != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
		    if (phaseRef == null) throw new ArgumentNullException(nameof(phaseRef));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ClassPhasesSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ClassPhases((InternalSyntaxToken)kPhase.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<PhaseRefGreen>(phaseRef.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ClassPhasesSyntax ClassPhases(SeparatedSyntaxList<PhaseRefSyntax> phaseRef)
		{
			return this.ClassPhases(this.Token(MetaCompilerSyntaxKind.KPhase), phaseRef, this.Token(MetaCompilerSyntaxKind.TSemicolon));
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
		
		public FieldDeclarationSyntax FieldDeclaration(SyntaxList<AttributeSyntax> attribute, VisibilitySyntax visibility, SyntaxList<MemberModifierSyntax> memberModifier, FieldContainmentSyntax fieldContainment, FieldKindSyntax fieldKind, TypeReferenceSyntax typeReference, NameSyntax name, DefaultValueSyntax defaultValue, PhaseSyntax phase, SyntaxToken tSemicolon)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (FieldDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), visibility == null ? null : (Syntax.InternalSyntax.VisibilityGreen)visibility.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<MemberModifierGreen>(memberModifier.Node), fieldContainment == null ? null : (Syntax.InternalSyntax.FieldContainmentGreen)fieldContainment.Green, fieldKind == null ? null : (Syntax.InternalSyntax.FieldKindGreen)fieldKind.Green, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green, defaultValue == null ? null : (Syntax.InternalSyntax.DefaultValueGreen)defaultValue.Green, phase == null ? null : (Syntax.InternalSyntax.PhaseGreen)phase.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public FieldDeclarationSyntax FieldDeclaration(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.FieldDeclaration(default, default, default, default, default, typeReference, name, default, default, this.Token(MetaCompilerSyntaxKind.TSemicolon));
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
		
		public FieldKindSyntax FieldKind(SyntaxToken fieldKind)
		{
		    if (fieldKind == null) throw new ArgumentNullException(nameof(fieldKind));
		    return (FieldKindSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.FieldKind((InternalSyntaxToken)fieldKind.Node).CreateRed();
		}
		
		public MemberModifierSyntax MemberModifier(Partial_Syntax partial_)
		{
		    if (partial_ == null) throw new ArgumentNullException(nameof(partial_));
		    return (MemberModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier((Syntax.InternalSyntax.Partial_Green)partial_.Green).CreateRed();
		}
		
		public MemberModifierSyntax MemberModifier(Static_Syntax static_)
		{
		    if (static_ == null) throw new ArgumentNullException(nameof(static_));
		    return (MemberModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier((Syntax.InternalSyntax.Static_Green)static_.Green).CreateRed();
		}
		
		public MemberModifierSyntax MemberModifier(Virtual_Syntax virtual_)
		{
		    if (virtual_ == null) throw new ArgumentNullException(nameof(virtual_));
		    return (MemberModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier((Syntax.InternalSyntax.Virtual_Green)virtual_.Green).CreateRed();
		}
		
		public MemberModifierSyntax MemberModifier(Abstract_Syntax abstract_)
		{
		    if (abstract_ == null) throw new ArgumentNullException(nameof(abstract_));
		    return (MemberModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier((Syntax.InternalSyntax.Abstract_Green)abstract_.Green).CreateRed();
		}
		
		public MemberModifierSyntax MemberModifier(Sealed_Syntax sealed_)
		{
		    if (sealed_ == null) throw new ArgumentNullException(nameof(sealed_));
		    return (MemberModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier((Syntax.InternalSyntax.Sealed_Green)sealed_.Green).CreateRed();
		}
		
		public MemberModifierSyntax MemberModifier(New_Syntax new_)
		{
		    if (new_ == null) throw new ArgumentNullException(nameof(new_));
		    return (MemberModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier((Syntax.InternalSyntax.New_Green)new_.Green).CreateRed();
		}
		
		public MemberModifierSyntax MemberModifier(Override_Syntax override_)
		{
		    if (override_ == null) throw new ArgumentNullException(nameof(override_));
		    return (MemberModifierSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.MemberModifier((Syntax.InternalSyntax.Override_Green)override_.Green).CreateRed();
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
		
		public PhaseSyntax Phase(SyntaxToken kPhase, PhaseRefSyntax phaseRef)
		{
		    if (kPhase == null) throw new ArgumentNullException(nameof(kPhase));
		    if (kPhase.GetKind() != MetaCompilerSyntaxKind.KPhase) throw new ArgumentException(nameof(kPhase));
		    if (phaseRef == null) throw new ArgumentNullException(nameof(phaseRef));
		    return (PhaseSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Phase((InternalSyntaxToken)kPhase.Node, (Syntax.InternalSyntax.PhaseRefGreen)phaseRef.Green).CreateRed();
		}
		
		public PhaseSyntax Phase(PhaseRefSyntax phaseRef)
		{
			return this.Phase(this.Token(MetaCompilerSyntaxKind.KPhase), phaseRef);
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
		
		public TypeReferenceSyntax TypeReference(SimpleOrDictionaryTypeSyntax simpleOrDictionaryType)
		{
		    if (simpleOrDictionaryType == null) throw new ArgumentNullException(nameof(simpleOrDictionaryType));
		    return (TypeReferenceSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.SimpleOrDictionaryTypeGreen)simpleOrDictionaryType.Green).CreateRed();
		}
		
		public SimpleOrDictionaryTypeSyntax SimpleOrDictionaryType(SimpleOrArrayTypeSyntax simpleOrArrayType)
		{
		    if (simpleOrArrayType == null) throw new ArgumentNullException(nameof(simpleOrArrayType));
		    return (SimpleOrDictionaryTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrDictionaryType((Syntax.InternalSyntax.SimpleOrArrayTypeGreen)simpleOrArrayType.Green).CreateRed();
		}
		
		public SimpleOrDictionaryTypeSyntax SimpleOrDictionaryType(DictionaryTypeSyntax dictionaryType)
		{
		    if (dictionaryType == null) throw new ArgumentNullException(nameof(dictionaryType));
		    return (SimpleOrDictionaryTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrDictionaryType((Syntax.InternalSyntax.DictionaryTypeGreen)dictionaryType.Green).CreateRed();
		}
		
		public SimpleOrArrayTypeSyntax SimpleOrArrayType(SimpleOrGenericTypeSyntax simpleOrGenericType)
		{
		    if (simpleOrGenericType == null) throw new ArgumentNullException(nameof(simpleOrGenericType));
		    return (SimpleOrArrayTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrArrayType((Syntax.InternalSyntax.SimpleOrGenericTypeGreen)simpleOrGenericType.Green).CreateRed();
		}
		
		public SimpleOrArrayTypeSyntax SimpleOrArrayType(ArrayTypeSyntax arrayType)
		{
		    if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
		    return (SimpleOrArrayTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrArrayType((Syntax.InternalSyntax.ArrayTypeGreen)arrayType.Green).CreateRed();
		}
		
		public SimpleOrGenericTypeSyntax SimpleOrGenericType(SimpleTypeSyntax simpleType)
		{
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    return (SimpleOrGenericTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrGenericType((Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green).CreateRed();
		}
		
		public SimpleOrGenericTypeSyntax SimpleOrGenericType(GenericTypeSyntax genericType)
		{
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
		    return (SimpleOrGenericTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.SimpleOrGenericType((Syntax.InternalSyntax.GenericTypeGreen)genericType.Green).CreateRed();
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
		
		public GenericTypeSyntax GenericType(ClassTypeSyntax classType, SyntaxToken tLessThan, TypeArgumentsSyntax typeArguments, SyntaxToken tGreaterThan)
		{
		    if (classType == null) throw new ArgumentNullException(nameof(classType));
		    if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
		    if (tLessThan.GetKind() != MetaCompilerSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
		    if (typeArguments == null) throw new ArgumentNullException(nameof(typeArguments));
		    if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
		    if (tGreaterThan.GetKind() != MetaCompilerSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
		    return (GenericTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.GenericType((Syntax.InternalSyntax.ClassTypeGreen)classType.Green, (InternalSyntaxToken)tLessThan.Node, (Syntax.InternalSyntax.TypeArgumentsGreen)typeArguments.Green, (InternalSyntaxToken)tGreaterThan.Node).CreateRed();
		}
		
		public GenericTypeSyntax GenericType(ClassTypeSyntax classType, TypeArgumentsSyntax typeArguments)
		{
			return this.GenericType(classType, this.Token(MetaCompilerSyntaxKind.TLessThan), typeArguments, this.Token(MetaCompilerSyntaxKind.TGreaterThan));
		}
		
		public TypeArgumentsSyntax TypeArguments(SeparatedSyntaxList<TypeReferenceSyntax> typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (TypeArgumentsSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.TypeArguments(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<TypeReferenceGreen>(typeReference.Node)).CreateRed();
		}
		
		public ArrayTypeSyntax ArrayType(SimpleOrGenericTypeSyntax simpleOrGenericType, SyntaxToken tOpenBracket, SyntaxToken tCloseBracket)
		{
		    if (simpleOrGenericType == null) throw new ArgumentNullException(nameof(simpleOrGenericType));
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != MetaCompilerSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != MetaCompilerSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (ArrayTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ArrayType((Syntax.InternalSyntax.SimpleOrGenericTypeGreen)simpleOrGenericType.Green, (InternalSyntaxToken)tOpenBracket.Node, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public ArrayTypeSyntax ArrayType(SimpleOrGenericTypeSyntax simpleOrGenericType)
		{
			return this.ArrayType(simpleOrGenericType, this.Token(MetaCompilerSyntaxKind.TOpenBracket), this.Token(MetaCompilerSyntaxKind.TCloseBracket));
		}
		
		public DictionaryTypeSyntax DictionaryType(SimpleOrArrayTypeSyntax key, SyntaxToken tRightArrow, SimpleOrArrayTypeSyntax value)
		{
		    if (key == null) throw new ArgumentNullException(nameof(key));
		    if (tRightArrow == null) throw new ArgumentNullException(nameof(tRightArrow));
		    if (tRightArrow.GetKind() != MetaCompilerSyntaxKind.TRightArrow) throw new ArgumentException(nameof(tRightArrow));
		    if (value == null) throw new ArgumentNullException(nameof(value));
		    return (DictionaryTypeSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.DictionaryType((Syntax.InternalSyntax.SimpleOrArrayTypeGreen)key.Green, (InternalSyntaxToken)tRightArrow.Node, (Syntax.InternalSyntax.SimpleOrArrayTypeGreen)value.Green).CreateRed();
		}
		
		public DictionaryTypeSyntax DictionaryType(SimpleOrArrayTypeSyntax key, SimpleOrArrayTypeSyntax value)
		{
			return this.DictionaryType(key, this.Token(MetaCompilerSyntaxKind.TRightArrow), value);
		}
		
		public OperationDeclarationSyntax OperationDeclaration(SyntaxList<AttributeSyntax> attribute, VisibilitySyntax visibility, SyntaxList<MemberModifierSyntax> memberModifier, ReturnTypeSyntax returnType, NameSyntax name, SyntaxToken tOpenParen, ParameterListSyntax parameterList, SyntaxToken tCloseParen, SyntaxToken tSemicolon)
		{
		    if (returnType == null) throw new ArgumentNullException(nameof(returnType));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != MetaCompilerSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != MetaCompilerSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != MetaCompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (OperationDeclarationSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.OperationDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), visibility == null ? null : (Syntax.InternalSyntax.VisibilityGreen)visibility.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<MemberModifierGreen>(memberModifier.Node), (Syntax.InternalSyntax.ReturnTypeGreen)returnType.Green, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Node, parameterList == null ? null : (Syntax.InternalSyntax.ParameterListGreen)parameterList.Green, (InternalSyntaxToken)tCloseParen.Node, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public OperationDeclarationSyntax OperationDeclaration(ReturnTypeSyntax returnType, NameSyntax name)
		{
			return this.OperationDeclaration(default, default, default, returnType, name, this.Token(MetaCompilerSyntaxKind.TOpenParen), default, this.Token(MetaCompilerSyntaxKind.TCloseParen), this.Token(MetaCompilerSyntaxKind.TSemicolon));
		}
		
		public ParameterListSyntax ParameterList(SeparatedSyntaxList<ParameterSyntax> parameter)
		{
		    if (parameter == null) throw new ArgumentNullException(nameof(parameter));
		    return (ParameterListSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.ParameterList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParameterGreen>(parameter.Node)).CreateRed();
		}
		
		public ParameterSyntax Parameter(SyntaxList<AttributeSyntax> attribute, TypeReferenceSyntax typeReference, NameSyntax name, DefaultValueSyntax defaultValue)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (ParameterSyntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Parameter(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AttributeGreen>(attribute.Node), (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.NameGreen)name.Green, defaultValue == null ? null : (Syntax.InternalSyntax.DefaultValueGreen)defaultValue.Green).CreateRed();
		}
		
		public ParameterSyntax Parameter(TypeReferenceSyntax typeReference, NameSyntax name)
		{
			return this.Parameter(default, typeReference, name, default);
		}
		
		public Static_Syntax Static_(SyntaxToken kStatic)
		{
		    if (kStatic == null) throw new ArgumentNullException(nameof(kStatic));
		    if (kStatic.GetKind() != MetaCompilerSyntaxKind.KStatic) throw new ArgumentException(nameof(kStatic));
		    return (Static_Syntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Static_((InternalSyntaxToken)kStatic.Node).CreateRed();
		}
		
		public Static_Syntax Static_()
		{
			return this.Static_(this.Token(MetaCompilerSyntaxKind.KStatic));
		}
		
		public Fixed_Syntax Fixed_(SyntaxToken kFixed)
		{
		    if (kFixed == null) throw new ArgumentNullException(nameof(kFixed));
		    if (kFixed.GetKind() != MetaCompilerSyntaxKind.KFixed) throw new ArgumentException(nameof(kFixed));
		    return (Fixed_Syntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Fixed_((InternalSyntaxToken)kFixed.Node).CreateRed();
		}
		
		public Fixed_Syntax Fixed_()
		{
			return this.Fixed_(this.Token(MetaCompilerSyntaxKind.KFixed));
		}
		
		public Partial_Syntax Partial_(SyntaxToken kPartial)
		{
		    if (kPartial == null) throw new ArgumentNullException(nameof(kPartial));
		    if (kPartial.GetKind() != MetaCompilerSyntaxKind.KPartial) throw new ArgumentException(nameof(kPartial));
		    return (Partial_Syntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Partial_((InternalSyntaxToken)kPartial.Node).CreateRed();
		}
		
		public Partial_Syntax Partial_()
		{
			return this.Partial_(this.Token(MetaCompilerSyntaxKind.KPartial));
		}
		
		public Abstract_Syntax Abstract_(SyntaxToken kAbstract)
		{
		    if (kAbstract == null) throw new ArgumentNullException(nameof(kAbstract));
		    if (kAbstract.GetKind() != MetaCompilerSyntaxKind.KAbstract) throw new ArgumentException(nameof(kAbstract));
		    return (Abstract_Syntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Abstract_((InternalSyntaxToken)kAbstract.Node).CreateRed();
		}
		
		public Abstract_Syntax Abstract_()
		{
			return this.Abstract_(this.Token(MetaCompilerSyntaxKind.KAbstract));
		}
		
		public Virtual_Syntax Virtual_(SyntaxToken kVirtual)
		{
		    if (kVirtual == null) throw new ArgumentNullException(nameof(kVirtual));
		    if (kVirtual.GetKind() != MetaCompilerSyntaxKind.KVirtual) throw new ArgumentException(nameof(kVirtual));
		    return (Virtual_Syntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Virtual_((InternalSyntaxToken)kVirtual.Node).CreateRed();
		}
		
		public Virtual_Syntax Virtual_()
		{
			return this.Virtual_(this.Token(MetaCompilerSyntaxKind.KVirtual));
		}
		
		public Sealed_Syntax Sealed_(SyntaxToken kSealed)
		{
		    if (kSealed == null) throw new ArgumentNullException(nameof(kSealed));
		    if (kSealed.GetKind() != MetaCompilerSyntaxKind.KSealed) throw new ArgumentException(nameof(kSealed));
		    return (Sealed_Syntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Sealed_((InternalSyntaxToken)kSealed.Node).CreateRed();
		}
		
		public Sealed_Syntax Sealed_()
		{
			return this.Sealed_(this.Token(MetaCompilerSyntaxKind.KSealed));
		}
		
		public Override_Syntax Override_(SyntaxToken kOverride)
		{
		    if (kOverride == null) throw new ArgumentNullException(nameof(kOverride));
		    if (kOverride.GetKind() != MetaCompilerSyntaxKind.KOverride) throw new ArgumentException(nameof(kOverride));
		    return (Override_Syntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.Override_((InternalSyntaxToken)kOverride.Node).CreateRed();
		}
		
		public Override_Syntax Override_()
		{
			return this.Override_(this.Token(MetaCompilerSyntaxKind.KOverride));
		}
		
		public New_Syntax New_(SyntaxToken kNew)
		{
		    if (kNew == null) throw new ArgumentNullException(nameof(kNew));
		    if (kNew.GetKind() != MetaCompilerSyntaxKind.KNew) throw new ArgumentException(nameof(kNew));
		    return (New_Syntax)MetaCompilerLanguage.Instance.InternalSyntaxFactory.New_((InternalSyntaxToken)kNew.Node).CreateRed();
		}
		
		public New_Syntax New_()
		{
			return this.New_(this.Token(MetaCompilerSyntaxKind.KNew));
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
				typeof(LockedSyntax),
				typeof(PhaseJoinSyntax),
				typeof(AfterPhasesSyntax),
				typeof(BeforePhasesSyntax),
				typeof(PhaseRefSyntax),
				typeof(EnumDeclarationSyntax),
				typeof(EnumBodySyntax),
				typeof(EnumValuesSyntax),
				typeof(EnumValueSyntax),
				typeof(EnumMemberDeclarationSyntax),
				typeof(VisibilitySyntax),
				typeof(ClassDeclarationSyntax),
				typeof(ClassModifierSyntax),
				typeof(ClassAncestorsSyntax),
				typeof(ClassAncestorSyntax),
				typeof(ClassBodySyntax),
				typeof(ClassPhasesSyntax),
				typeof(ClassMemberDeclarationSyntax),
				typeof(ClassKindSyntax),
				typeof(FieldDeclarationSyntax),
				typeof(FieldContainmentSyntax),
				typeof(FieldKindSyntax),
				typeof(MemberModifierSyntax),
				typeof(DefaultValueSyntax),
				typeof(PhaseSyntax),
				typeof(NameUseListSyntax),
				typeof(TypedefDeclarationSyntax),
				typeof(TypedefValueSyntax),
				typeof(ReturnTypeSyntax),
				typeof(TypeOfReferenceSyntax),
				typeof(TypeReferenceSyntax),
				typeof(SimpleOrDictionaryTypeSyntax),
				typeof(SimpleOrArrayTypeSyntax),
				typeof(SimpleOrGenericTypeSyntax),
				typeof(SimpleTypeSyntax),
				typeof(ClassTypeSyntax),
				typeof(ObjectTypeSyntax),
				typeof(PrimitiveTypeSyntax),
				typeof(VoidTypeSyntax),
				typeof(NullableTypeSyntax),
				typeof(GenericTypeSyntax),
				typeof(TypeArgumentsSyntax),
				typeof(ArrayTypeSyntax),
				typeof(DictionaryTypeSyntax),
				typeof(OperationDeclarationSyntax),
				typeof(ParameterListSyntax),
				typeof(ParameterSyntax),
				typeof(Static_Syntax),
				typeof(Fixed_Syntax),
				typeof(Partial_Syntax),
				typeof(Abstract_Syntax),
				typeof(Virtual_Syntax),
				typeof(Sealed_Syntax),
				typeof(Override_Syntax),
				typeof(New_Syntax),
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

