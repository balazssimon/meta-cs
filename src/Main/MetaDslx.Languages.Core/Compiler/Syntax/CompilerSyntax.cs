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

namespace MetaDslx.Languages.Compiler.Syntax
{
    public abstract class CompilerSyntaxNode : LanguageSyntaxNode
    {
        protected CompilerSyntaxNode(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected CompilerSyntaxNode(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new CompilerLanguage Language => CompilerLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new CompilerSyntaxKind Kind => (CompilerSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

        protected override SyntaxTree CreateSyntaxTreeForRoot()
        {
            return CompilerSyntaxTree.CreateWithoutClone(this, ParseData.Empty);
        }

        public override TResult Accept<TArg, TResult>(SyntaxVisitor<TArg, TResult> visitor, TArg argument)
        {
            if (visitor is ICompilerSyntaxVisitor<TArg, TResult> typedVisitor) return this.Accept(typedVisitor, argument);
            else return visitor.DefaultVisit(this, argument);
        }

        public abstract TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument);

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            if (visitor is ICompilerSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            if (visitor is ICompilerSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }
        public abstract void Accept(ICompilerSyntaxVisitor visitor);
    }

    /// <summary>
    /// It's a non terminal Trivia CompilerSyntaxNode that has a tree underneath it.
    /// </summary>
    public abstract partial class CompilerStructuredTriviaSyntax : CompilerSyntaxNode, IStructuredTriviaSyntax
    {
        private SyntaxTrivia _parent;
        internal CompilerStructuredTriviaSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
            : base(green, parent == null ? null : (CompilerSyntaxTree)parent.SyntaxTree, position)
        {
            System.Diagnostics.Debug.Assert(parent == null || position >= 0);
        }
		internal static CompilerStructuredTriviaSyntax Create(SyntaxTrivia trivia)
		{
			var red = (CompilerStructuredTriviaSyntax)CompilerLanguage.Instance.SyntaxFactory.CreateStructure(trivia);
			red._parent = trivia;
			return red;
		}
        /// <summary>
        /// Get parent trivia.
        /// </summary>
        public override SyntaxTrivia ParentTrivia => _parent;
    }

    public sealed partial class CompilerSkippedTokensTriviaSyntax : CompilerStructuredTriviaSyntax
    {
        internal CompilerSkippedTokensTriviaSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public SyntaxTokenList Tokens 
        {
            get
            {
				var slot = ((global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.GreenSkippedTokensTriviaSyntax)this.Green).Tokens;
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

		public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
		{
			return visitor.VisitSkippedTokensTrivia(this, argument);
		}

		public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
        {
            return visitor.VisitSkippedTokensTrivia(this);
        }

        public override void Accept(ICompilerSyntaxVisitor visitor)
        {
            visitor.VisitSkippedTokensTrivia(this);
        }

        public CompilerSkippedTokensTriviaSyntax Update(SyntaxTokenList tokens)
        {
            if (tokens != this.Tokens)
            {
                var newNode = (CompilerSkippedTokensTriviaSyntax)Language.SyntaxFactory.SkippedTokensTrivia(tokens);
                var annotations = this.GetAnnotations();
                if (annotations != null && annotations.Length > 0)
                    return newNode.WithAnnotations(annotations);
                return newNode;
            }
            return this;
        }

        public CompilerSkippedTokensTriviaSyntax WithTokens(SyntaxTokenList tokens)
        {
            return this.Update(tokens);
        }

        public CompilerSkippedTokensTriviaSyntax AddTokens(params SyntaxToken[] items)
        {
            return this.WithTokens(this.Tokens.AddRange(items));
        }
    }

	
	public sealed class MainSyntax : CompilerSyntaxNode, ICompilationUnitSyntax
	{
	    private NamespaceDeclarationSyntax namespaceDeclaration;
	
	    public MainSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
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
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.MainGreen)this.Green;
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Main(namespaceDeclaration, eOF);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class AnnotationSyntax : CompilerSyntaxNode
	{
	    private NameSyntax name;
	
	    public AnnotationSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AnnotationSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.AnnotationGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
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
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.AnnotationGreen)this.Green;
				var greenToken = green.TCloseBracket;
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Annotation(tOpenBracket, name, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AnnotationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAnnotation(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAnnotation(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitAnnotation(this);
	    }
	}
	
	public sealed class NamespaceDeclarationSyntax : CompilerSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBodySyntax namespaceBody;
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public NamespaceBodySyntax NamespaceBody 
		{ 
			get { return this.GetRed(ref this.namespaceBody, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 3: return this.GetRed(ref this.namespaceBody, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 3: return this.namespaceBody;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclarationSyntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.TSemicolon, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.TSemicolon, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KNamespace, this.QualifiedName, TSemicolon, this.NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax WithNamespaceBody(NamespaceBodySyntax namespaceBody)
		{
			return this.Update(this.KNamespace, this.QualifiedName, this.TSemicolon, NamespaceBody);
		}
	
	    public NamespaceDeclarationSyntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, SyntaxToken tSemicolon, NamespaceBodySyntax namespaceBody)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.TSemicolon != tSemicolon ||
				this.NamespaceBody != namespaceBody)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.NamespaceDeclaration(kNamespace, qualifiedName, tSemicolon, namespaceBody);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration(this);
	    }
	}
	
	public sealed class NamespaceBodySyntax : CompilerSyntaxNode
	{
	    private SyntaxNode usingDeclaration;
	    private GrammarDeclarationSyntax grammarDeclaration;
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBodySyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<UsingDeclarationSyntax> UsingDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.usingDeclaration, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<UsingDeclarationSyntax>(red);
				return default;
			} 
		}
	    public GrammarDeclarationSyntax GrammarDeclaration 
		{ 
			get { return this.GetRed(ref this.grammarDeclaration, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.usingDeclaration, 0);
				case 1: return this.GetRed(ref this.grammarDeclaration, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.usingDeclaration;
				case 1: return this.grammarDeclaration;
				default: return null;
	        }
	    }
	
	    public NamespaceBodySyntax WithUsingDeclaration(Microsoft.CodeAnalysis.SyntaxList<UsingDeclarationSyntax> usingDeclaration)
		{
			return this.Update(UsingDeclaration, this.GrammarDeclaration);
		}
	
	    public NamespaceBodySyntax AddUsingDeclaration(params UsingDeclarationSyntax[] usingDeclaration)
		{
			return this.WithUsingDeclaration(this.UsingDeclaration.AddRange(usingDeclaration));
		}
	
	    public NamespaceBodySyntax WithGrammarDeclaration(GrammarDeclarationSyntax grammarDeclaration)
		{
			return this.Update(this.UsingDeclaration, GrammarDeclaration);
		}
	
	    public NamespaceBodySyntax Update(Microsoft.CodeAnalysis.SyntaxList<UsingDeclarationSyntax> usingDeclaration, GrammarDeclarationSyntax grammarDeclaration)
	    {
	        if (this.UsingDeclaration != usingDeclaration ||
				this.GrammarDeclaration != grammarDeclaration)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.NamespaceBody(usingDeclaration, grammarDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody(this);
	    }
	}
	
	public sealed class GrammarDeclarationSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode annotation;
	    private NameSyntax name;
	    private RuleDeclarationsSyntax ruleDeclarations;
	
	    public GrammarDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GrammarDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KGrammar 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.GrammarDeclarationGreen)this.Green;
				var greenToken = green.KGrammar;
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
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.GrammarDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public RuleDeclarationsSyntax RuleDeclarations 
		{ 
			get { return this.GetRed(ref this.ruleDeclarations, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 2: return this.GetRed(ref this.name, 2);
				case 4: return this.GetRed(ref this.ruleDeclarations, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 2: return this.name;
				case 4: return this.ruleDeclarations;
				default: return null;
	        }
	    }
	
	    public GrammarDeclarationSyntax WithAnnotation(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.KGrammar, this.Name, this.TSemicolon, this.RuleDeclarations);
		}
	
	    public GrammarDeclarationSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public GrammarDeclarationSyntax WithKGrammar(SyntaxToken kGrammar)
		{
			return this.Update(this.Annotation, KGrammar, this.Name, this.TSemicolon, this.RuleDeclarations);
		}
	
	    public GrammarDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.Annotation, this.KGrammar, Name, this.TSemicolon, this.RuleDeclarations);
		}
	
	    public GrammarDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Annotation, this.KGrammar, this.Name, TSemicolon, this.RuleDeclarations);
		}
	
	    public GrammarDeclarationSyntax WithRuleDeclarations(RuleDeclarationsSyntax ruleDeclarations)
		{
			return this.Update(this.Annotation, this.KGrammar, this.Name, this.TSemicolon, RuleDeclarations);
		}
	
	    public GrammarDeclarationSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, SyntaxToken kGrammar, NameSyntax name, SyntaxToken tSemicolon, RuleDeclarationsSyntax ruleDeclarations)
	    {
	        if (this.Annotation != annotation ||
				this.KGrammar != kGrammar ||
				this.Name != name ||
				this.TSemicolon != tSemicolon ||
				this.RuleDeclarations != ruleDeclarations)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.GrammarDeclaration(annotation, kGrammar, name, tSemicolon, ruleDeclarations);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GrammarDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGrammarDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGrammarDeclaration(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitGrammarDeclaration(this);
	    }
	}
	
	public sealed class UsingDeclarationSyntax : CompilerSyntaxNode
	{
	    private NameSyntax name;
	    private QualifierSyntax qualifier;
	
	    public UsingDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UsingDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KUsing 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.UsingDeclarationGreen)this.Green;
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
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.UsingDeclarationGreen)this.Green;
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
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.UsingDeclarationGreen)this.Green;
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
	
	    public UsingDeclarationSyntax WithKUsing(SyntaxToken kUsing)
		{
			return this.Update(KUsing, this.Name, this.TAssign, this.Qualifier, this.TSemicolon);
		}
	
	    public UsingDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KUsing, Name, this.TAssign, this.Qualifier, this.TSemicolon);
		}
	
	    public UsingDeclarationSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.KUsing, this.Name, TAssign, this.Qualifier, this.TSemicolon);
		}
	
	    public UsingDeclarationSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.KUsing, this.Name, this.TAssign, Qualifier, this.TSemicolon);
		}
	
	    public UsingDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KUsing, this.Name, this.TAssign, this.Qualifier, TSemicolon);
		}
	
	    public UsingDeclarationSyntax Update(SyntaxToken kUsing, NameSyntax name, SyntaxToken tAssign, QualifierSyntax qualifier, SyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.Name != name ||
				this.TAssign != tAssign ||
				this.Qualifier != qualifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.UsingDeclaration(kUsing, name, tAssign, qualifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUsingDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUsingDeclaration(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitUsingDeclaration(this);
	    }
	}
	
	public sealed class RuleDeclarationsSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode ruleDeclaration;
	
	    public RuleDeclarationsSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RuleDeclarationsSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<RuleDeclarationSyntax> RuleDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.ruleDeclaration, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<RuleDeclarationSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.ruleDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.ruleDeclaration;
				default: return null;
	        }
	    }
	
	    public RuleDeclarationsSyntax WithRuleDeclaration(Microsoft.CodeAnalysis.SyntaxList<RuleDeclarationSyntax> ruleDeclaration)
		{
			return this.Update(RuleDeclaration);
		}
	
	    public RuleDeclarationsSyntax AddRuleDeclaration(params RuleDeclarationSyntax[] ruleDeclaration)
		{
			return this.WithRuleDeclaration(this.RuleDeclaration.AddRange(ruleDeclaration));
		}
	
	    public RuleDeclarationsSyntax Update(Microsoft.CodeAnalysis.SyntaxList<RuleDeclarationSyntax> ruleDeclaration)
	    {
	        if (this.RuleDeclaration != ruleDeclaration)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.RuleDeclarations(ruleDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuleDeclarationsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRuleDeclarations(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRuleDeclarations(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitRuleDeclarations(this);
	    }
	}
	
	public sealed class RuleDeclarationSyntax : CompilerSyntaxNode
	{
	    private ParserRuleDeclarationSyntax parserRuleDeclaration;
	    private LexerRuleDeclarationSyntax lexerRuleDeclaration;
	
	    public RuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ParserRuleDeclarationSyntax ParserRuleDeclaration 
		{ 
			get { return this.GetRed(ref this.parserRuleDeclaration, 0); } 
		}
	    public LexerRuleDeclarationSyntax LexerRuleDeclaration 
		{ 
			get { return this.GetRed(ref this.lexerRuleDeclaration, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.parserRuleDeclaration, 0);
				case 1: return this.GetRed(ref this.lexerRuleDeclaration, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.parserRuleDeclaration;
				case 1: return this.lexerRuleDeclaration;
				default: return null;
	        }
	    }
	
	    public RuleDeclarationSyntax WithParserRuleDeclaration(ParserRuleDeclarationSyntax parserRuleDeclaration)
		{
			return this.Update(parserRuleDeclaration);
		}
	
	    public RuleDeclarationSyntax WithLexerRuleDeclaration(LexerRuleDeclarationSyntax lexerRuleDeclaration)
		{
			return this.Update(lexerRuleDeclaration);
		}
	
	    public RuleDeclarationSyntax Update(ParserRuleDeclarationSyntax parserRuleDeclaration)
	    {
	        if (this.ParserRuleDeclaration != parserRuleDeclaration)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.RuleDeclaration(parserRuleDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuleDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public RuleDeclarationSyntax Update(LexerRuleDeclarationSyntax lexerRuleDeclaration)
	    {
	        if (this.LexerRuleDeclaration != lexerRuleDeclaration)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.RuleDeclaration(lexerRuleDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RuleDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRuleDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRuleDeclaration(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitRuleDeclaration(this);
	    }
	}
	
	public sealed class ParserRuleDeclarationSyntax : CompilerSyntaxNode
	{
	    private ParserRuleAltSyntax parserRuleAlt;
	    private ParserRuleSimpleSyntax parserRuleSimple;
	
	    public ParserRuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ParserRuleAltSyntax ParserRuleAlt 
		{ 
			get { return this.GetRed(ref this.parserRuleAlt, 0); } 
		}
	    public ParserRuleSimpleSyntax ParserRuleSimple 
		{ 
			get { return this.GetRed(ref this.parserRuleSimple, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.parserRuleAlt, 0);
				case 1: return this.GetRed(ref this.parserRuleSimple, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.parserRuleAlt;
				case 1: return this.parserRuleSimple;
				default: return null;
	        }
	    }
	
	    public ParserRuleDeclarationSyntax WithParserRuleAlt(ParserRuleAltSyntax parserRuleAlt)
		{
			return this.Update(parserRuleAlt);
		}
	
	    public ParserRuleDeclarationSyntax WithParserRuleSimple(ParserRuleSimpleSyntax parserRuleSimple)
		{
			return this.Update(parserRuleSimple);
		}
	
	    public ParserRuleDeclarationSyntax Update(ParserRuleAltSyntax parserRuleAlt)
	    {
	        if (this.ParserRuleAlt != parserRuleAlt)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleDeclaration(parserRuleAlt);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ParserRuleDeclarationSyntax Update(ParserRuleSimpleSyntax parserRuleSimple)
	    {
	        if (this.ParserRuleSimple != parserRuleSimple)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleDeclaration(parserRuleSimple);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleDeclaration(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleDeclaration(this);
	    }
	}
	
	public sealed class ParserRuleAltSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode annotation;
	    private ParserRuleNameSyntax parserRuleName;
	    private QualifierSyntax qualifier;
	    private SyntaxNode parserRuleAltRef;
	
	    public ParserRuleAltSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleAltSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax>(red);
				return default;
			} 
		}
	    public ParserRuleNameSyntax ParserRuleName 
		{ 
			get { return this.GetRed(ref this.parserRuleName, 1); } 
		}
	    public SyntaxToken KDefines 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleAltGreen)this.Green;
				var greenToken = green.KDefines;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleAltGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAltRefSyntax> ParserRuleAltRef 
		{ 
			get
			{
				var red = this.GetRed(ref this.parserRuleAltRef, 5);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAltRefSyntax>(red, this.GetChildIndex(5));
				}
				return default;
			} 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleAltGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 1: return this.GetRed(ref this.parserRuleName, 1);
				case 3: return this.GetRed(ref this.qualifier, 3);
				case 5: return this.GetRed(ref this.parserRuleAltRef, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 1: return this.parserRuleName;
				case 3: return this.qualifier;
				case 5: return this.parserRuleAltRef;
				default: return null;
	        }
	    }
	
	    public ParserRuleAltSyntax WithAnnotation(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.ParserRuleName, this.KDefines, this.Qualifier, this.TColon, this.ParserRuleAltRef, this.TSemicolon);
		}
	
	    public ParserRuleAltSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public ParserRuleAltSyntax WithParserRuleName(ParserRuleNameSyntax parserRuleName)
		{
			return this.Update(this.Annotation, ParserRuleName, this.KDefines, this.Qualifier, this.TColon, this.ParserRuleAltRef, this.TSemicolon);
		}
	
	    public ParserRuleAltSyntax WithKDefines(SyntaxToken kDefines)
		{
			return this.Update(this.Annotation, this.ParserRuleName, KDefines, this.Qualifier, this.TColon, this.ParserRuleAltRef, this.TSemicolon);
		}
	
	    public ParserRuleAltSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.Annotation, this.ParserRuleName, this.KDefines, Qualifier, this.TColon, this.ParserRuleAltRef, this.TSemicolon);
		}
	
	    public ParserRuleAltSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Annotation, this.ParserRuleName, this.KDefines, this.Qualifier, TColon, this.ParserRuleAltRef, this.TSemicolon);
		}
	
	    public ParserRuleAltSyntax WithParserRuleAltRef(Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAltRefSyntax> parserRuleAltRef)
		{
			return this.Update(this.Annotation, this.ParserRuleName, this.KDefines, this.Qualifier, this.TColon, ParserRuleAltRef, this.TSemicolon);
		}
	
	    public ParserRuleAltSyntax AddParserRuleAltRef(params ParserRuleAltRefSyntax[] parserRuleAltRef)
		{
			return this.WithParserRuleAltRef(this.ParserRuleAltRef.AddRange(parserRuleAltRef));
		}
	
	    public ParserRuleAltSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Annotation, this.ParserRuleName, this.KDefines, this.Qualifier, this.TColon, this.ParserRuleAltRef, TSemicolon);
		}
	
	    public ParserRuleAltSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, ParserRuleNameSyntax parserRuleName, SyntaxToken kDefines, QualifierSyntax qualifier, SyntaxToken tColon, Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAltRefSyntax> parserRuleAltRef, SyntaxToken tSemicolon)
	    {
	        if (this.Annotation != annotation ||
				this.ParserRuleName != parserRuleName ||
				this.KDefines != kDefines ||
				this.Qualifier != qualifier ||
				this.TColon != tColon ||
				this.ParserRuleAltRef != parserRuleAltRef ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleAlt(annotation, parserRuleName, kDefines, qualifier, tColon, parserRuleAltRef, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleAltSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleAlt(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleAlt(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleAlt(this);
	    }
	}
	
	public sealed class ParserRuleAltRefSyntax : CompilerSyntaxNode
	{
	    private ParserRuleIdentifierSyntax parserRuleIdentifier;
	
	    public ParserRuleAltRefSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleAltRefSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ParserRuleIdentifierSyntax ParserRuleIdentifier 
		{ 
			get { return this.GetRed(ref this.parserRuleIdentifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.parserRuleIdentifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.parserRuleIdentifier;
				default: return null;
	        }
	    }
	
	    public ParserRuleAltRefSyntax WithParserRuleIdentifier(ParserRuleIdentifierSyntax parserRuleIdentifier)
		{
			return this.Update(ParserRuleIdentifier);
		}
	
	    public ParserRuleAltRefSyntax Update(ParserRuleIdentifierSyntax parserRuleIdentifier)
	    {
	        if (this.ParserRuleIdentifier != parserRuleIdentifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleAltRef(parserRuleIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleAltRefSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleAltRef(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleAltRef(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleAltRef(this);
	    }
	}
	
	public sealed class ParserRuleSimpleSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode annotation;
	    private ParserRuleNameSyntax parserRuleName;
	    private QualifierSyntax qualifier;
	    private SyntaxNode parserRuleNamedElement;
	    private EofElementSyntax eofElement;
	
	    public ParserRuleSimpleSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleSimpleSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax>(red);
				return default;
			} 
		}
	    public ParserRuleNameSyntax ParserRuleName 
		{ 
			get { return this.GetRed(ref this.parserRuleName, 1); } 
		}
	    public SyntaxToken KDefines 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleSimpleGreen)this.Green;
				var greenToken = green.KDefines;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 3); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleSimpleGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> ParserRuleNamedElement 
		{ 
			get
			{
				var red = this.GetRed(ref this.parserRuleNamedElement, 5);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax>(red);
				return default;
			} 
		}
	    public EofElementSyntax EofElement 
		{ 
			get { return this.GetRed(ref this.eofElement, 6); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleSimpleGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(7), this.GetChildIndex(7));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 1: return this.GetRed(ref this.parserRuleName, 1);
				case 3: return this.GetRed(ref this.qualifier, 3);
				case 5: return this.GetRed(ref this.parserRuleNamedElement, 5);
				case 6: return this.GetRed(ref this.eofElement, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 1: return this.parserRuleName;
				case 3: return this.qualifier;
				case 5: return this.parserRuleNamedElement;
				case 6: return this.eofElement;
				default: return null;
	        }
	    }
	
	    public ParserRuleSimpleSyntax WithAnnotation(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.ParserRuleName, this.KDefines, this.Qualifier, this.TColon, this.ParserRuleNamedElement, this.EofElement, this.TSemicolon);
		}
	
	    public ParserRuleSimpleSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public ParserRuleSimpleSyntax WithParserRuleName(ParserRuleNameSyntax parserRuleName)
		{
			return this.Update(this.Annotation, ParserRuleName, this.KDefines, this.Qualifier, this.TColon, this.ParserRuleNamedElement, this.EofElement, this.TSemicolon);
		}
	
	    public ParserRuleSimpleSyntax WithKDefines(SyntaxToken kDefines)
		{
			return this.Update(this.Annotation, this.ParserRuleName, KDefines, this.Qualifier, this.TColon, this.ParserRuleNamedElement, this.EofElement, this.TSemicolon);
		}
	
	    public ParserRuleSimpleSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.Annotation, this.ParserRuleName, this.KDefines, Qualifier, this.TColon, this.ParserRuleNamedElement, this.EofElement, this.TSemicolon);
		}
	
	    public ParserRuleSimpleSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Annotation, this.ParserRuleName, this.KDefines, this.Qualifier, TColon, this.ParserRuleNamedElement, this.EofElement, this.TSemicolon);
		}
	
	    public ParserRuleSimpleSyntax WithParserRuleNamedElement(Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> parserRuleNamedElement)
		{
			return this.Update(this.Annotation, this.ParserRuleName, this.KDefines, this.Qualifier, this.TColon, ParserRuleNamedElement, this.EofElement, this.TSemicolon);
		}
	
	    public ParserRuleSimpleSyntax AddParserRuleNamedElement(params ParserRuleNamedElementSyntax[] parserRuleNamedElement)
		{
			return this.WithParserRuleNamedElement(this.ParserRuleNamedElement.AddRange(parserRuleNamedElement));
		}
	
	    public ParserRuleSimpleSyntax WithEofElement(EofElementSyntax eofElement)
		{
			return this.Update(this.Annotation, this.ParserRuleName, this.KDefines, this.Qualifier, this.TColon, this.ParserRuleNamedElement, EofElement, this.TSemicolon);
		}
	
	    public ParserRuleSimpleSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Annotation, this.ParserRuleName, this.KDefines, this.Qualifier, this.TColon, this.ParserRuleNamedElement, this.EofElement, TSemicolon);
		}
	
	    public ParserRuleSimpleSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, ParserRuleNameSyntax parserRuleName, SyntaxToken kDefines, QualifierSyntax qualifier, SyntaxToken tColon, Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> parserRuleNamedElement, EofElementSyntax eofElement, SyntaxToken tSemicolon)
	    {
	        if (this.Annotation != annotation ||
				this.ParserRuleName != parserRuleName ||
				this.KDefines != kDefines ||
				this.Qualifier != qualifier ||
				this.TColon != tColon ||
				this.ParserRuleNamedElement != parserRuleNamedElement ||
				this.EofElement != eofElement ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleSimple(annotation, parserRuleName, kDefines, qualifier, tColon, parserRuleNamedElement, eofElement, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleSimpleSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleSimple(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleSimple(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleSimple(this);
	    }
	}
	
	public sealed class EofElementSyntax : CompilerSyntaxNode
	{
	
	    public EofElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EofElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.EofElementGreen)this.Green;
				var greenToken = green.KEof;
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
	
	    public EofElementSyntax WithKEof(SyntaxToken kEof)
		{
			return this.Update(KEof);
		}
	
	    public EofElementSyntax Update(SyntaxToken kEof)
	    {
	        if (this.KEof != kEof)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.EofElement(kEof);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EofElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEofElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEofElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitEofElement(this);
	    }
	}
	
	public sealed class ParserRuleNamedElementSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode annotation;
	    private ElementNameSyntax elementName;
	    private AssignSyntax assign;
	    private ParserNegatedElementSyntax parserNegatedElement;
	    private MultiplicitySyntax multiplicity;
	
	    public ParserRuleNamedElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleNamedElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax>(red);
				return default;
			} 
		}
	    public ElementNameSyntax ElementName 
		{ 
			get { return this.GetRed(ref this.elementName, 1); } 
		}
	    public AssignSyntax Assign 
		{ 
			get { return this.GetRed(ref this.assign, 2); } 
		}
	    public ParserNegatedElementSyntax ParserNegatedElement 
		{ 
			get { return this.GetRed(ref this.parserNegatedElement, 3); } 
		}
	    public MultiplicitySyntax Multiplicity 
		{ 
			get { return this.GetRed(ref this.multiplicity, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 1: return this.GetRed(ref this.elementName, 1);
				case 2: return this.GetRed(ref this.assign, 2);
				case 3: return this.GetRed(ref this.parserNegatedElement, 3);
				case 4: return this.GetRed(ref this.multiplicity, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 1: return this.elementName;
				case 2: return this.assign;
				case 3: return this.parserNegatedElement;
				case 4: return this.multiplicity;
				default: return null;
	        }
	    }
	
	    public ParserRuleNamedElementSyntax WithAnnotation(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.ElementName, this.Assign, this.ParserNegatedElement, this.Multiplicity);
		}
	
	    public ParserRuleNamedElementSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public ParserRuleNamedElementSyntax WithElementName(ElementNameSyntax elementName)
		{
			return this.Update(this.Annotation, ElementName, this.Assign, this.ParserNegatedElement, this.Multiplicity);
		}
	
	    public ParserRuleNamedElementSyntax WithAssign(AssignSyntax assign)
		{
			return this.Update(this.Annotation, this.ElementName, Assign, this.ParserNegatedElement, this.Multiplicity);
		}
	
	    public ParserRuleNamedElementSyntax WithParserNegatedElement(ParserNegatedElementSyntax parserNegatedElement)
		{
			return this.Update(this.Annotation, this.ElementName, this.Assign, ParserNegatedElement, this.Multiplicity);
		}
	
	    public ParserRuleNamedElementSyntax WithMultiplicity(MultiplicitySyntax multiplicity)
		{
			return this.Update(this.Annotation, this.ElementName, this.Assign, this.ParserNegatedElement, Multiplicity);
		}
	
	    public ParserRuleNamedElementSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, ElementNameSyntax elementName, AssignSyntax assign, ParserNegatedElementSyntax parserNegatedElement, MultiplicitySyntax multiplicity)
	    {
	        if (this.Annotation != annotation ||
				this.ElementName != elementName ||
				this.Assign != assign ||
				this.ParserNegatedElement != parserNegatedElement ||
				this.Multiplicity != multiplicity)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleNamedElement(annotation, elementName, assign, parserNegatedElement, multiplicity);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleNamedElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleNamedElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleNamedElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleNamedElement(this);
	    }
	}
	
	public sealed class AssignSyntax : CompilerSyntaxNode
	{
	
	    public AssignSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssignSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Assign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.AssignGreen)this.Green;
				var greenToken = green.Assign;
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
	
	    public AssignSyntax WithAssign(SyntaxToken assign)
		{
			return this.Update(Assign);
		}
	
	    public AssignSyntax Update(SyntaxToken assign)
	    {
	        if (this.Assign != assign)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Assign(assign);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAssign(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssign(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitAssign(this);
	    }
	}
	
	public sealed class MultiplicitySyntax : CompilerSyntaxNode
	{
	
	    public MultiplicitySyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MultiplicitySyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Multiplicity 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.MultiplicityGreen)this.Green;
				var greenToken = green.Multiplicity;
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
	
	    public MultiplicitySyntax WithMultiplicity(SyntaxToken multiplicity)
		{
			return this.Update(Multiplicity);
		}
	
	    public MultiplicitySyntax Update(SyntaxToken multiplicity)
	    {
	        if (this.Multiplicity != multiplicity)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Multiplicity(multiplicity);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultiplicitySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMultiplicity(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMultiplicity(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitMultiplicity(this);
	    }
	}
	
	public sealed class ParserNegatedElementSyntax : CompilerSyntaxNode
	{
	    private ParserRuleElementSyntax parserRuleElement;
	
	    public ParserNegatedElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserNegatedElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TNegate 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserNegatedElementGreen)this.Green;
				var greenToken = green.TNegate;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ParserRuleElementSyntax ParserRuleElement 
		{ 
			get { return this.GetRed(ref this.parserRuleElement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.parserRuleElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.parserRuleElement;
				default: return null;
	        }
	    }
	
	    public ParserNegatedElementSyntax WithTNegate(SyntaxToken tNegate)
		{
			return this.Update(TNegate, this.ParserRuleElement);
		}
	
	    public ParserNegatedElementSyntax WithParserRuleElement(ParserRuleElementSyntax parserRuleElement)
		{
			return this.Update(this.TNegate, ParserRuleElement);
		}
	
	    public ParserNegatedElementSyntax Update(SyntaxToken tNegate, ParserRuleElementSyntax parserRuleElement)
	    {
	        if (this.TNegate != tNegate ||
				this.ParserRuleElement != parserRuleElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserNegatedElement(tNegate, parserRuleElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserNegatedElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserNegatedElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserNegatedElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserNegatedElement(this);
	    }
	}
	
	public sealed class ParserRuleElementSyntax : CompilerSyntaxNode
	{
	    private ParserRuleFixedElementSyntax parserRuleFixedElement;
	    private ParserRuleReferenceSyntax parserRuleReference;
	    private ParserRuleWildcardElementSyntax parserRuleWildcardElement;
	    private ParserRuleBlockElementSyntax parserRuleBlockElement;
	
	    public ParserRuleElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ParserRuleFixedElementSyntax ParserRuleFixedElement 
		{ 
			get { return this.GetRed(ref this.parserRuleFixedElement, 0); } 
		}
	    public ParserRuleReferenceSyntax ParserRuleReference 
		{ 
			get { return this.GetRed(ref this.parserRuleReference, 1); } 
		}
	    public ParserRuleWildcardElementSyntax ParserRuleWildcardElement 
		{ 
			get { return this.GetRed(ref this.parserRuleWildcardElement, 2); } 
		}
	    public ParserRuleBlockElementSyntax ParserRuleBlockElement 
		{ 
			get { return this.GetRed(ref this.parserRuleBlockElement, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.parserRuleFixedElement, 0);
				case 1: return this.GetRed(ref this.parserRuleReference, 1);
				case 2: return this.GetRed(ref this.parserRuleWildcardElement, 2);
				case 3: return this.GetRed(ref this.parserRuleBlockElement, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.parserRuleFixedElement;
				case 1: return this.parserRuleReference;
				case 2: return this.parserRuleWildcardElement;
				case 3: return this.parserRuleBlockElement;
				default: return null;
	        }
	    }
	
	    public ParserRuleElementSyntax WithParserRuleFixedElement(ParserRuleFixedElementSyntax parserRuleFixedElement)
		{
			return this.Update(parserRuleFixedElement);
		}
	
	    public ParserRuleElementSyntax WithParserRuleReference(ParserRuleReferenceSyntax parserRuleReference)
		{
			return this.Update(parserRuleReference);
		}
	
	    public ParserRuleElementSyntax WithParserRuleWildcardElement(ParserRuleWildcardElementSyntax parserRuleWildcardElement)
		{
			return this.Update(parserRuleWildcardElement);
		}
	
	    public ParserRuleElementSyntax WithParserRuleBlockElement(ParserRuleBlockElementSyntax parserRuleBlockElement)
		{
			return this.Update(parserRuleBlockElement);
		}
	
	    public ParserRuleElementSyntax Update(ParserRuleFixedElementSyntax parserRuleFixedElement)
	    {
	        if (this.ParserRuleFixedElement != parserRuleFixedElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleElement(parserRuleFixedElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ParserRuleElementSyntax Update(ParserRuleReferenceSyntax parserRuleReference)
	    {
	        if (this.ParserRuleReference != parserRuleReference)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleElement(parserRuleReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ParserRuleElementSyntax Update(ParserRuleWildcardElementSyntax parserRuleWildcardElement)
	    {
	        if (this.ParserRuleWildcardElement != parserRuleWildcardElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleElement(parserRuleWildcardElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ParserRuleElementSyntax Update(ParserRuleBlockElementSyntax parserRuleBlockElement)
	    {
	        if (this.ParserRuleBlockElement != parserRuleBlockElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleElement(parserRuleBlockElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleElement(this);
	    }
	}
	
	public sealed class ParserRuleFixedElementSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode annotation;
	    private StringLiteralSyntax stringLiteral;
	
	    public ParserRuleFixedElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleFixedElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax>(red);
				return default;
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
				case 0: return this.GetRed(ref this.annotation, 0);
				case 1: return this.GetRed(ref this.stringLiteral, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 1: return this.stringLiteral;
				default: return null;
	        }
	    }
	
	    public ParserRuleFixedElementSyntax WithAnnotation(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.StringLiteral);
		}
	
	    public ParserRuleFixedElementSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public ParserRuleFixedElementSyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(this.Annotation, StringLiteral);
		}
	
	    public ParserRuleFixedElementSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, StringLiteralSyntax stringLiteral)
	    {
	        if (this.Annotation != annotation ||
				this.StringLiteral != stringLiteral)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleFixedElement(annotation, stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleFixedElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleFixedElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleFixedElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleFixedElement(this);
	    }
	}
	
	public sealed class ParserRuleWildcardElementSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode annotation;
	
	    public ParserRuleWildcardElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleWildcardElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TDot 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleWildcardElementGreen)this.Green;
				var greenToken = green.TDot;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	
	    public ParserRuleWildcardElementSyntax WithAnnotation(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.TDot);
		}
	
	    public ParserRuleWildcardElementSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public ParserRuleWildcardElementSyntax WithTDot(SyntaxToken tDot)
		{
			return this.Update(this.Annotation, TDot);
		}
	
	    public ParserRuleWildcardElementSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, SyntaxToken tDot)
	    {
	        if (this.Annotation != annotation ||
				this.TDot != tDot)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleWildcardElement(annotation, tDot);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleWildcardElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleWildcardElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleWildcardElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleWildcardElement(this);
	    }
	}
	
	public sealed class ParserRuleReferenceSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode annotation;
	    private IdentifierSyntax identifier;
	
	    public ParserRuleReferenceSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleReferenceSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax>(red);
				return default;
			} 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 1: return this.GetRed(ref this.identifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 1: return this.identifier;
				default: return null;
	        }
	    }
	
	    public ParserRuleReferenceSyntax WithAnnotation(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.Identifier);
		}
	
	    public ParserRuleReferenceSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public ParserRuleReferenceSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.Annotation, Identifier);
		}
	
	    public ParserRuleReferenceSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, IdentifierSyntax identifier)
	    {
	        if (this.Annotation != annotation ||
				this.Identifier != identifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleReference(annotation, identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleReference(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleReference(this);
	    }
	}
	
	public sealed class ParserRuleBlockElementSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode annotation;
	    private SyntaxNode parserRuleNamedElement;
	
	    public ParserRuleBlockElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleBlockElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleBlockElementGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> ParserRuleNamedElement 
		{ 
			get
			{
				var red = this.GetRed(ref this.parserRuleNamedElement, 2);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleBlockElementGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 2: return this.GetRed(ref this.parserRuleNamedElement, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 2: return this.parserRuleNamedElement;
				default: return null;
	        }
	    }
	
	    public ParserRuleBlockElementSyntax WithAnnotation(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.TOpenParen, this.ParserRuleNamedElement, this.TCloseParen);
		}
	
	    public ParserRuleBlockElementSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public ParserRuleBlockElementSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Annotation, TOpenParen, this.ParserRuleNamedElement, this.TCloseParen);
		}
	
	    public ParserRuleBlockElementSyntax WithParserRuleNamedElement(Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> parserRuleNamedElement)
		{
			return this.Update(this.Annotation, this.TOpenParen, ParserRuleNamedElement, this.TCloseParen);
		}
	
	    public ParserRuleBlockElementSyntax AddParserRuleNamedElement(params ParserRuleNamedElementSyntax[] parserRuleNamedElement)
		{
			return this.WithParserRuleNamedElement(this.ParserRuleNamedElement.AddRange(parserRuleNamedElement));
		}
	
	    public ParserRuleBlockElementSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Annotation, this.TOpenParen, this.ParserRuleNamedElement, TCloseParen);
		}
	
	    public ParserRuleBlockElementSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, SyntaxToken tOpenParen, Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> parserRuleNamedElement, SyntaxToken tCloseParen)
	    {
	        if (this.Annotation != annotation ||
				this.TOpenParen != tOpenParen ||
				this.ParserRuleNamedElement != parserRuleNamedElement ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleBlockElement(annotation, tOpenParen, parserRuleNamedElement, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleBlockElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleBlockElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleBlockElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleBlockElement(this);
	    }
	}
	
	public sealed class LexerRuleDeclarationSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode annotation;
	    private LexerRuleNameSyntax lexerRuleName;
	    private QualifierSyntax qualifier;
	    private SyntaxNode lexerRuleAlternative;
	
	    public LexerRuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> Annotation 
		{ 
			get
			{
				var red = this.GetRed(ref this.annotation, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken Modifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleDeclarationGreen)this.Green;
				var greenToken = green.Modifier;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public LexerRuleNameSyntax LexerRuleName 
		{ 
			get { return this.GetRed(ref this.lexerRuleName, 2); } 
		}
	    public SyntaxToken KReturns 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleDeclarationGreen)this.Green;
				var greenToken = green.KReturns;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 4); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> LexerRuleAlternative 
		{ 
			get
			{
				var red = this.GetRed(ref this.lexerRuleAlternative, 6);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax>(red, this.GetChildIndex(6));
				}
				return default;
			} 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(7), this.GetChildIndex(7));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.annotation, 0);
				case 2: return this.GetRed(ref this.lexerRuleName, 2);
				case 4: return this.GetRed(ref this.qualifier, 4);
				case 6: return this.GetRed(ref this.lexerRuleAlternative, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.annotation;
				case 2: return this.lexerRuleName;
				case 4: return this.qualifier;
				case 6: return this.lexerRuleAlternative;
				default: return null;
	        }
	    }
	
	    public LexerRuleDeclarationSyntax WithAnnotation(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation)
		{
			return this.Update(Annotation, this.Modifier, this.LexerRuleName, this.KReturns, this.Qualifier, this.TColon, this.LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax AddAnnotation(params AnnotationSyntax[] annotation)
		{
			return this.WithAnnotation(this.Annotation.AddRange(annotation));
		}
	
	    public LexerRuleDeclarationSyntax WithModifier(SyntaxToken modifier)
		{
			return this.Update(this.Annotation, Modifier, this.LexerRuleName, this.KReturns, this.Qualifier, this.TColon, this.LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax WithLexerRuleName(LexerRuleNameSyntax lexerRuleName)
		{
			return this.Update(this.Annotation, this.Modifier, LexerRuleName, this.KReturns, this.Qualifier, this.TColon, this.LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax WithKReturns(SyntaxToken kReturns)
		{
			return this.Update(this.Annotation, this.Modifier, this.LexerRuleName, KReturns, this.Qualifier, this.TColon, this.LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.Annotation, this.Modifier, this.LexerRuleName, this.KReturns, Qualifier, this.TColon, this.LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Annotation, this.Modifier, this.LexerRuleName, this.KReturns, this.Qualifier, TColon, this.LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax WithLexerRuleAlternative(Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative)
		{
			return this.Update(this.Annotation, this.Modifier, this.LexerRuleName, this.KReturns, this.Qualifier, this.TColon, LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax AddLexerRuleAlternative(params LexerRuleAlternativeSyntax[] lexerRuleAlternative)
		{
			return this.WithLexerRuleAlternative(this.LexerRuleAlternative.AddRange(lexerRuleAlternative));
		}
	
	    public LexerRuleDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Annotation, this.Modifier, this.LexerRuleName, this.KReturns, this.Qualifier, this.TColon, this.LexerRuleAlternative, TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax Update(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, SyntaxToken modifier, LexerRuleNameSyntax lexerRuleName, SyntaxToken kReturns, QualifierSyntax qualifier, SyntaxToken tColon, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative, SyntaxToken tSemicolon)
	    {
	        if (this.Annotation != annotation ||
				this.Modifier != modifier ||
				this.LexerRuleName != lexerRuleName ||
				this.KReturns != kReturns ||
				this.Qualifier != qualifier ||
				this.TColon != tColon ||
				this.LexerRuleAlternative != lexerRuleAlternative ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleDeclaration(annotation, modifier, lexerRuleName, kReturns, qualifier, tColon, lexerRuleAlternative, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleDeclaration(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleDeclaration(this);
	    }
	}
	
	public sealed class LexerRuleAlternativeSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode lexerRuleAlternativeElement;
	
	    public LexerRuleAlternativeSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleAlternativeSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<LexerRuleAlternativeElementSyntax> LexerRuleAlternativeElement 
		{ 
			get
			{
				var red = this.GetRed(ref this.lexerRuleAlternativeElement, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<LexerRuleAlternativeElementSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.lexerRuleAlternativeElement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.lexerRuleAlternativeElement;
				default: return null;
	        }
	    }
	
	    public LexerRuleAlternativeSyntax WithLexerRuleAlternativeElement(Microsoft.CodeAnalysis.SyntaxList<LexerRuleAlternativeElementSyntax> lexerRuleAlternativeElement)
		{
			return this.Update(LexerRuleAlternativeElement);
		}
	
	    public LexerRuleAlternativeSyntax AddLexerRuleAlternativeElement(params LexerRuleAlternativeElementSyntax[] lexerRuleAlternativeElement)
		{
			return this.WithLexerRuleAlternativeElement(this.LexerRuleAlternativeElement.AddRange(lexerRuleAlternativeElement));
		}
	
	    public LexerRuleAlternativeSyntax Update(Microsoft.CodeAnalysis.SyntaxList<LexerRuleAlternativeElementSyntax> lexerRuleAlternativeElement)
	    {
	        if (this.LexerRuleAlternativeElement != lexerRuleAlternativeElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleAlternative(lexerRuleAlternativeElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleAlternativeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleAlternative(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleAlternative(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleAlternative(this);
	    }
	}
	
	public sealed class LexerRuleAlternativeElementSyntax : CompilerSyntaxNode
	{
	    private LexerRuleElementSyntax lexerRuleElement;
	    private MultiplicitySyntax multiplicity;
	
	    public LexerRuleAlternativeElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleAlternativeElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TNegate 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleAlternativeElementGreen)this.Green;
				var greenToken = green.TNegate;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public LexerRuleElementSyntax LexerRuleElement 
		{ 
			get { return this.GetRed(ref this.lexerRuleElement, 1); } 
		}
	    public MultiplicitySyntax Multiplicity 
		{ 
			get { return this.GetRed(ref this.multiplicity, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.lexerRuleElement, 1);
				case 2: return this.GetRed(ref this.multiplicity, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.lexerRuleElement;
				case 2: return this.multiplicity;
				default: return null;
	        }
	    }
	
	    public LexerRuleAlternativeElementSyntax WithTNegate(SyntaxToken tNegate)
		{
			return this.Update(TNegate, this.LexerRuleElement, this.Multiplicity);
		}
	
	    public LexerRuleAlternativeElementSyntax WithLexerRuleElement(LexerRuleElementSyntax lexerRuleElement)
		{
			return this.Update(this.TNegate, LexerRuleElement, this.Multiplicity);
		}
	
	    public LexerRuleAlternativeElementSyntax WithMultiplicity(MultiplicitySyntax multiplicity)
		{
			return this.Update(this.TNegate, this.LexerRuleElement, Multiplicity);
		}
	
	    public LexerRuleAlternativeElementSyntax Update(SyntaxToken tNegate, LexerRuleElementSyntax lexerRuleElement, MultiplicitySyntax multiplicity)
	    {
	        if (this.TNegate != tNegate ||
				this.LexerRuleElement != lexerRuleElement ||
				this.Multiplicity != multiplicity)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleAlternativeElement(tNegate, lexerRuleElement, multiplicity);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleAlternativeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleAlternativeElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleAlternativeElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleAlternativeElement(this);
	    }
	}
	
	public sealed class LexerRuleElementSyntax : CompilerSyntaxNode
	{
	    private LexerRuleReferenceElementSyntax lexerRuleReferenceElement;
	    private LexerRuleFixedStringElementSyntax lexerRuleFixedStringElement;
	    private LexerRuleFixedCharElementSyntax lexerRuleFixedCharElement;
	    private LexerRuleWildcardElementSyntax lexerRuleWildcardElement;
	    private LexerRuleBlockElementSyntax lexerRuleBlockElement;
	    private LexerRuleRangeElementSyntax lexerRuleRangeElement;
	
	    public LexerRuleElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LexerRuleReferenceElementSyntax LexerRuleReferenceElement 
		{ 
			get { return this.GetRed(ref this.lexerRuleReferenceElement, 0); } 
		}
	    public LexerRuleFixedStringElementSyntax LexerRuleFixedStringElement 
		{ 
			get { return this.GetRed(ref this.lexerRuleFixedStringElement, 1); } 
		}
	    public LexerRuleFixedCharElementSyntax LexerRuleFixedCharElement 
		{ 
			get { return this.GetRed(ref this.lexerRuleFixedCharElement, 2); } 
		}
	    public LexerRuleWildcardElementSyntax LexerRuleWildcardElement 
		{ 
			get { return this.GetRed(ref this.lexerRuleWildcardElement, 3); } 
		}
	    public LexerRuleBlockElementSyntax LexerRuleBlockElement 
		{ 
			get { return this.GetRed(ref this.lexerRuleBlockElement, 4); } 
		}
	    public LexerRuleRangeElementSyntax LexerRuleRangeElement 
		{ 
			get { return this.GetRed(ref this.lexerRuleRangeElement, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.lexerRuleReferenceElement, 0);
				case 1: return this.GetRed(ref this.lexerRuleFixedStringElement, 1);
				case 2: return this.GetRed(ref this.lexerRuleFixedCharElement, 2);
				case 3: return this.GetRed(ref this.lexerRuleWildcardElement, 3);
				case 4: return this.GetRed(ref this.lexerRuleBlockElement, 4);
				case 5: return this.GetRed(ref this.lexerRuleRangeElement, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.lexerRuleReferenceElement;
				case 1: return this.lexerRuleFixedStringElement;
				case 2: return this.lexerRuleFixedCharElement;
				case 3: return this.lexerRuleWildcardElement;
				case 4: return this.lexerRuleBlockElement;
				case 5: return this.lexerRuleRangeElement;
				default: return null;
	        }
	    }
	
	    public LexerRuleElementSyntax WithLexerRuleReferenceElement(LexerRuleReferenceElementSyntax lexerRuleReferenceElement)
		{
			return this.Update(lexerRuleReferenceElement);
		}
	
	    public LexerRuleElementSyntax WithLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax lexerRuleFixedStringElement)
		{
			return this.Update(lexerRuleFixedStringElement);
		}
	
	    public LexerRuleElementSyntax WithLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax lexerRuleFixedCharElement)
		{
			return this.Update(lexerRuleFixedCharElement);
		}
	
	    public LexerRuleElementSyntax WithLexerRuleWildcardElement(LexerRuleWildcardElementSyntax lexerRuleWildcardElement)
		{
			return this.Update(lexerRuleWildcardElement);
		}
	
	    public LexerRuleElementSyntax WithLexerRuleBlockElement(LexerRuleBlockElementSyntax lexerRuleBlockElement)
		{
			return this.Update(lexerRuleBlockElement);
		}
	
	    public LexerRuleElementSyntax WithLexerRuleRangeElement(LexerRuleRangeElementSyntax lexerRuleRangeElement)
		{
			return this.Update(lexerRuleRangeElement);
		}
	
	    public LexerRuleElementSyntax Update(LexerRuleReferenceElementSyntax lexerRuleReferenceElement)
	    {
	        if (this.LexerRuleReferenceElement != lexerRuleReferenceElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(lexerRuleReferenceElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementSyntax Update(LexerRuleFixedStringElementSyntax lexerRuleFixedStringElement)
	    {
	        if (this.LexerRuleFixedStringElement != lexerRuleFixedStringElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(lexerRuleFixedStringElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementSyntax Update(LexerRuleFixedCharElementSyntax lexerRuleFixedCharElement)
	    {
	        if (this.LexerRuleFixedCharElement != lexerRuleFixedCharElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(lexerRuleFixedCharElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementSyntax Update(LexerRuleWildcardElementSyntax lexerRuleWildcardElement)
	    {
	        if (this.LexerRuleWildcardElement != lexerRuleWildcardElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(lexerRuleWildcardElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementSyntax Update(LexerRuleBlockElementSyntax lexerRuleBlockElement)
	    {
	        if (this.LexerRuleBlockElement != lexerRuleBlockElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(lexerRuleBlockElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementSyntax Update(LexerRuleRangeElementSyntax lexerRuleRangeElement)
	    {
	        if (this.LexerRuleRangeElement != lexerRuleRangeElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(lexerRuleRangeElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleElement(this);
	    }
	}
	
	public sealed class LexerRuleReferenceElementSyntax : CompilerSyntaxNode
	{
	    private LexerRuleIdentifierSyntax lexerRuleIdentifier;
	
	    public LexerRuleReferenceElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleReferenceElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LexerRuleIdentifierSyntax LexerRuleIdentifier 
		{ 
			get { return this.GetRed(ref this.lexerRuleIdentifier, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.lexerRuleIdentifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.lexerRuleIdentifier;
				default: return null;
	        }
	    }
	
	    public LexerRuleReferenceElementSyntax WithLexerRuleIdentifier(LexerRuleIdentifierSyntax lexerRuleIdentifier)
		{
			return this.Update(LexerRuleIdentifier);
		}
	
	    public LexerRuleReferenceElementSyntax Update(LexerRuleIdentifierSyntax lexerRuleIdentifier)
	    {
	        if (this.LexerRuleIdentifier != lexerRuleIdentifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleReferenceElement(lexerRuleIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleReferenceElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleReferenceElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleReferenceElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleReferenceElement(this);
	    }
	}
	
	public sealed class LexerRuleWildcardElementSyntax : CompilerSyntaxNode
	{
	
	    public LexerRuleWildcardElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleWildcardElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TDot 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleWildcardElementGreen)this.Green;
				var greenToken = green.TDot;
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
	
	    public LexerRuleWildcardElementSyntax WithTDot(SyntaxToken tDot)
		{
			return this.Update(TDot);
		}
	
	    public LexerRuleWildcardElementSyntax Update(SyntaxToken tDot)
	    {
	        if (this.TDot != tDot)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleWildcardElement(tDot);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleWildcardElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleWildcardElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleWildcardElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleWildcardElement(this);
	    }
	}
	
	public sealed class LexerRuleFixedStringElementSyntax : CompilerSyntaxNode
	{
	
	    public LexerRuleFixedStringElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleFixedStringElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LString 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleFixedStringElementGreen)this.Green;
				var greenToken = green.LString;
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
	
	    public LexerRuleFixedStringElementSyntax WithLString(SyntaxToken lString)
		{
			return this.Update(LString);
		}
	
	    public LexerRuleFixedStringElementSyntax Update(SyntaxToken lString)
	    {
	        if (this.LString != lString)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleFixedStringElement(lString);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleFixedStringElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleFixedStringElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleFixedStringElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleFixedStringElement(this);
	    }
	}
	
	public sealed class LexerRuleFixedCharElementSyntax : CompilerSyntaxNode
	{
	
	    public LexerRuleFixedCharElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleFixedCharElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LCharacter 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleFixedCharElementGreen)this.Green;
				var greenToken = green.LCharacter;
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
	
	    public LexerRuleFixedCharElementSyntax WithLCharacter(SyntaxToken lCharacter)
		{
			return this.Update(LCharacter);
		}
	
	    public LexerRuleFixedCharElementSyntax Update(SyntaxToken lCharacter)
	    {
	        if (this.LCharacter != lCharacter)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleFixedCharElement(lCharacter);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleFixedCharElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleFixedCharElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleFixedCharElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleFixedCharElement(this);
	    }
	}
	
	public sealed class LexerRuleBlockElementSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode lexerRuleAlternative;
	
	    public LexerRuleBlockElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleBlockElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleBlockElementGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> LexerRuleAlternative 
		{ 
			get
			{
				var red = this.GetRed(ref this.lexerRuleAlternative, 1);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleBlockElementGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.lexerRuleAlternative, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.lexerRuleAlternative;
				default: return null;
	        }
	    }
	
	    public LexerRuleBlockElementSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.LexerRuleAlternative, this.TCloseParen);
		}
	
	    public LexerRuleBlockElementSyntax WithLexerRuleAlternative(Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative)
		{
			return this.Update(this.TOpenParen, LexerRuleAlternative, this.TCloseParen);
		}
	
	    public LexerRuleBlockElementSyntax AddLexerRuleAlternative(params LexerRuleAlternativeSyntax[] lexerRuleAlternative)
		{
			return this.WithLexerRuleAlternative(this.LexerRuleAlternative.AddRange(lexerRuleAlternative));
		}
	
	    public LexerRuleBlockElementSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.LexerRuleAlternative, TCloseParen);
		}
	
	    public LexerRuleBlockElementSyntax Update(SyntaxToken tOpenParen, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative, SyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.LexerRuleAlternative != lexerRuleAlternative ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleBlockElement(tOpenParen, lexerRuleAlternative, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleBlockElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleBlockElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleBlockElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleBlockElement(this);
	    }
	}
	
	public sealed class LexerRuleRangeElementSyntax : CompilerSyntaxNode
	{
	    private LexerRuleFixedCharElementSyntax start;
	    private LexerRuleFixedCharElementSyntax end;
	
	    public LexerRuleRangeElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleRangeElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LexerRuleFixedCharElementSyntax Start 
		{ 
			get { return this.GetRed(ref this.start, 0); } 
		}
	    public SyntaxToken TDotDot 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleRangeElementGreen)this.Green;
				var greenToken = green.TDotDot;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public LexerRuleFixedCharElementSyntax End 
		{ 
			get { return this.GetRed(ref this.end, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.start, 0);
				case 2: return this.GetRed(ref this.end, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.start;
				case 2: return this.end;
				default: return null;
	        }
	    }
	
	    public LexerRuleRangeElementSyntax WithStart(LexerRuleFixedCharElementSyntax start)
		{
			return this.Update(Start, this.TDotDot, this.End);
		}
	
	    public LexerRuleRangeElementSyntax WithTDotDot(SyntaxToken tDotDot)
		{
			return this.Update(this.Start, TDotDot, this.End);
		}
	
	    public LexerRuleRangeElementSyntax WithEnd(LexerRuleFixedCharElementSyntax end)
		{
			return this.Update(this.Start, this.TDotDot, End);
		}
	
	    public LexerRuleRangeElementSyntax Update(LexerRuleFixedCharElementSyntax start, SyntaxToken tDotDot, LexerRuleFixedCharElementSyntax end)
	    {
	        if (this.Start != start ||
				this.TDotDot != tDotDot ||
				this.End != end)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleRangeElement(start, tDotDot, end);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleRangeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleRangeElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleRangeElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleRangeElement(this);
	    }
	}
	
	public sealed class NameSyntax : CompilerSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class QualifiedNameSyntax : CompilerSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.QualifiedName(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifiedName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifiedName(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifiedName(this);
	    }
	}
	
	public sealed class QualifierSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public QualifierSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Qualifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifier(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifier(this);
	    }
	}
	
	public sealed class IdentifierSyntax : CompilerSyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Identifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.IdentifierGreen)this.Green;
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Identifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class LexerRuleIdentifierSyntax : CompilerSyntaxNode
	{
	
	    public LexerRuleIdentifierSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleIdentifierSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LexerIdentifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleIdentifierGreen)this.Green;
				var greenToken = green.LexerIdentifier;
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
	
	    public LexerRuleIdentifierSyntax WithLexerIdentifier(SyntaxToken lexerIdentifier)
		{
			return this.Update(LexerIdentifier);
		}
	
	    public LexerRuleIdentifierSyntax Update(SyntaxToken lexerIdentifier)
	    {
	        if (this.LexerIdentifier != lexerIdentifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleIdentifier(lexerIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleIdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleIdentifier(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleIdentifier(this);
	    }
	}
	
	public sealed class ParserRuleIdentifierSyntax : CompilerSyntaxNode
	{
	
	    public ParserRuleIdentifierSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleIdentifierSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ParserIdentifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleIdentifierGreen)this.Green;
				var greenToken = green.ParserIdentifier;
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
	
	    public ParserRuleIdentifierSyntax WithParserIdentifier(SyntaxToken parserIdentifier)
		{
			return this.Update(ParserIdentifier);
		}
	
	    public ParserRuleIdentifierSyntax Update(SyntaxToken parserIdentifier)
	    {
	        if (this.ParserIdentifier != parserIdentifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleIdentifier(parserIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleIdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleIdentifier(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleIdentifier(this);
	    }
	}
	
	public sealed class LexerRuleNameSyntax : CompilerSyntaxNode
	{
	
	    public LexerRuleNameSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleNameSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LexerIdentifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleNameGreen)this.Green;
				var greenToken = green.LexerIdentifier;
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
	
	    public LexerRuleNameSyntax WithLexerIdentifier(SyntaxToken lexerIdentifier)
		{
			return this.Update(LexerIdentifier);
		}
	
	    public LexerRuleNameSyntax Update(SyntaxToken lexerIdentifier)
	    {
	        if (this.LexerIdentifier != lexerIdentifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleName(lexerIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleName(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleName(this);
	    }
	}
	
	public sealed class ParserRuleNameSyntax : CompilerSyntaxNode
	{
	
	    public ParserRuleNameSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleNameSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ParserIdentifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleNameGreen)this.Green;
				var greenToken = green.ParserIdentifier;
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
	
	    public ParserRuleNameSyntax WithParserIdentifier(SyntaxToken parserIdentifier)
		{
			return this.Update(ParserIdentifier);
		}
	
	    public ParserRuleNameSyntax Update(SyntaxToken parserIdentifier)
	    {
	        if (this.ParserIdentifier != parserIdentifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleName(parserIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleName(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleName(this);
	    }
	}
	
	public sealed class ElementNameSyntax : CompilerSyntaxNode
	{
	
	    public ElementNameSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElementNameSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ElementName 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ElementNameGreen)this.Green;
				var greenToken = green.ElementName;
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
	
	    public ElementNameSyntax WithElementName(SyntaxToken elementName)
		{
			return this.Update(ElementName);
		}
	
	    public ElementNameSyntax Update(SyntaxToken elementName)
	    {
	        if (this.ElementName != elementName)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ElementName(elementName);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElementName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElementName(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitElementName(this);
	    }
	}
	
	public sealed class LiteralSyntax : CompilerSyntaxNode
	{
	    private NullLiteralSyntax nullLiteral;
	    private BooleanLiteralSyntax booleanLiteral;
	    private IntegerLiteralSyntax integerLiteral;
	    private DecimalLiteralSyntax decimalLiteral;
	    private ScientificLiteralSyntax scientificLiteral;
	    private StringLiteralSyntax stringLiteral;
	
	    public LiteralSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Literal(nullLiteral);
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Literal(booleanLiteral);
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Literal(integerLiteral);
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Literal(decimalLiteral);
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Literal(scientificLiteral);
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.Literal(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteral(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteral(this);
	    }
	}
	
	public sealed class NullLiteralSyntax : CompilerSyntaxNode
	{
	
	    public NullLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNull 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.NullLiteralGreen)this.Green;
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.NullLiteral(kNull);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullLiteral(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitNullLiteral(this);
	    }
	}
	
	public sealed class BooleanLiteralSyntax : CompilerSyntaxNode
	{
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BooleanLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.BooleanLiteralGreen)this.Green;
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.BooleanLiteral(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BooleanLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBooleanLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBooleanLiteral(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitBooleanLiteral(this);
	    }
	}
	
	public sealed class IntegerLiteralSyntax : CompilerSyntaxNode
	{
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LInteger 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.IntegerLiteralGreen)this.Green;
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.IntegerLiteral(lInteger);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIntegerLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIntegerLiteral(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitIntegerLiteral(this);
	    }
	}
	
	public sealed class DecimalLiteralSyntax : CompilerSyntaxNode
	{
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LDecimal 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.DecimalLiteralGreen)this.Green;
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.DecimalLiteral(lDecimal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DecimalLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDecimalLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDecimalLiteral(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitDecimalLiteral(this);
	    }
	}
	
	public sealed class ScientificLiteralSyntax : CompilerSyntaxNode
	{
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LScientific 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ScientificLiteralGreen)this.Green;
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
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ScientificLiteral(lScientific);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ScientificLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitScientificLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitScientificLiteral(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitScientificLiteral(this);
	    }
	}
	
	public sealed class StringLiteralSyntax : CompilerSyntaxNode
	{
	
	    public StringLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LString 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.StringLiteralGreen)this.Green;
				var greenToken = green.LString;
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
	
	    public StringLiteralSyntax WithLString(SyntaxToken lString)
		{
			return this.Update(LString);
		}
	
	    public StringLiteralSyntax Update(SyntaxToken lString)
	    {
	        if (this.LString != lString)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.StringLiteral(lString);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStringLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStringLiteral(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitStringLiteral(this);
	    }
	}
	
	public sealed class CharLiteralSyntax : CompilerSyntaxNode
	{
	
	    public CharLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CharLiteralSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LCharacter 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.CharLiteralGreen)this.Green;
				var greenToken = green.LCharacter;
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
	
	    public CharLiteralSyntax WithLCharacter(SyntaxToken lCharacter)
		{
			return this.Update(LCharacter);
		}
	
	    public CharLiteralSyntax Update(SyntaxToken lCharacter)
	    {
	        if (this.LCharacter != lCharacter)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.CharLiteral(lCharacter);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CharLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCharLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCharLiteral(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitCharLiteral(this);
	    }
	}
}

namespace MetaDslx.Languages.Compiler
{
    using System.Threading;
    using Microsoft.CodeAnalysis.Text;
	using MetaDslx.Languages.Compiler.Syntax;
    using MetaDslx.Languages.Compiler.Syntax.InternalSyntax;

	public interface ICompilerSyntaxVisitor
	{
	    void VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node);
		
		void VisitMain(MainSyntax node);
		
		void VisitAnnotation(AnnotationSyntax node);
		
		void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		void VisitNamespaceBody(NamespaceBodySyntax node);
		
		void VisitGrammarDeclaration(GrammarDeclarationSyntax node);
		
		void VisitUsingDeclaration(UsingDeclarationSyntax node);
		
		void VisitRuleDeclarations(RuleDeclarationsSyntax node);
		
		void VisitRuleDeclaration(RuleDeclarationSyntax node);
		
		void VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node);
		
		void VisitParserRuleAlt(ParserRuleAltSyntax node);
		
		void VisitParserRuleAltRef(ParserRuleAltRefSyntax node);
		
		void VisitParserRuleSimple(ParserRuleSimpleSyntax node);
		
		void VisitEofElement(EofElementSyntax node);
		
		void VisitParserRuleNamedElement(ParserRuleNamedElementSyntax node);
		
		void VisitAssign(AssignSyntax node);
		
		void VisitMultiplicity(MultiplicitySyntax node);
		
		void VisitParserNegatedElement(ParserNegatedElementSyntax node);
		
		void VisitParserRuleElement(ParserRuleElementSyntax node);
		
		void VisitParserRuleFixedElement(ParserRuleFixedElementSyntax node);
		
		void VisitParserRuleWildcardElement(ParserRuleWildcardElementSyntax node);
		
		void VisitParserRuleReference(ParserRuleReferenceSyntax node);
		
		void VisitParserRuleBlockElement(ParserRuleBlockElementSyntax node);
		
		void VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node);
		
		void VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node);
		
		void VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node);
		
		void VisitLexerRuleElement(LexerRuleElementSyntax node);
		
		void VisitLexerRuleReferenceElement(LexerRuleReferenceElementSyntax node);
		
		void VisitLexerRuleWildcardElement(LexerRuleWildcardElementSyntax node);
		
		void VisitLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax node);
		
		void VisitLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax node);
		
		void VisitLexerRuleBlockElement(LexerRuleBlockElementSyntax node);
		
		void VisitLexerRuleRangeElement(LexerRuleRangeElementSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitLexerRuleIdentifier(LexerRuleIdentifierSyntax node);
		
		void VisitParserRuleIdentifier(ParserRuleIdentifierSyntax node);
		
		void VisitLexerRuleName(LexerRuleNameSyntax node);
		
		void VisitParserRuleName(ParserRuleNameSyntax node);
		
		void VisitElementName(ElementNameSyntax node);
		
		void VisitLiteral(LiteralSyntax node);
		
		void VisitNullLiteral(NullLiteralSyntax node);
		
		void VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		void VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		void VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		void VisitScientificLiteral(ScientificLiteralSyntax node);
		
		void VisitStringLiteral(StringLiteralSyntax node);
		
		void VisitCharLiteral(CharLiteralSyntax node);
	}
	
	public class CompilerSyntaxVisitor : SyntaxVisitor, ICompilerSyntaxVisitor
	{
	    public virtual void VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node)
	    {
	        this.DefaultVisit(node);
	    }
		
		public virtual void VisitMain(MainSyntax node)
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
		
		public virtual void VisitGrammarDeclaration(GrammarDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUsingDeclaration(UsingDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRuleDeclarations(RuleDeclarationsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRuleDeclaration(RuleDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleAlt(ParserRuleAltSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleAltRef(ParserRuleAltRefSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleSimple(ParserRuleSimpleSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEofElement(EofElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleNamedElement(ParserRuleNamedElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAssign(AssignSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMultiplicity(MultiplicitySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserNegatedElement(ParserNegatedElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleElement(ParserRuleElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleFixedElement(ParserRuleFixedElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleWildcardElement(ParserRuleWildcardElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleReference(ParserRuleReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleBlockElement(ParserRuleBlockElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleElement(LexerRuleElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleReferenceElement(LexerRuleReferenceElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleWildcardElement(LexerRuleWildcardElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleBlockElement(LexerRuleBlockElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleRangeElement(LexerRuleRangeElementSyntax node)
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
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleIdentifier(LexerRuleIdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleIdentifier(ParserRuleIdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleName(LexerRuleNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleName(ParserRuleNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElementName(ElementNameSyntax node)
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
		
		public virtual void VisitCharLiteral(CharLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	//GenerateDetailedSyntaxVisitor()

	public interface ICompilerSyntaxVisitor<TArg, TResult> 
	{
	    TResult VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node, TArg argument);
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitAnnotation(AnnotationSyntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node, TArg argument);
		
		TResult VisitGrammarDeclaration(GrammarDeclarationSyntax node, TArg argument);
		
		TResult VisitUsingDeclaration(UsingDeclarationSyntax node, TArg argument);
		
		TResult VisitRuleDeclarations(RuleDeclarationsSyntax node, TArg argument);
		
		TResult VisitRuleDeclaration(RuleDeclarationSyntax node, TArg argument);
		
		TResult VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node, TArg argument);
		
		TResult VisitParserRuleAlt(ParserRuleAltSyntax node, TArg argument);
		
		TResult VisitParserRuleAltRef(ParserRuleAltRefSyntax node, TArg argument);
		
		TResult VisitParserRuleSimple(ParserRuleSimpleSyntax node, TArg argument);
		
		TResult VisitEofElement(EofElementSyntax node, TArg argument);
		
		TResult VisitParserRuleNamedElement(ParserRuleNamedElementSyntax node, TArg argument);
		
		TResult VisitAssign(AssignSyntax node, TArg argument);
		
		TResult VisitMultiplicity(MultiplicitySyntax node, TArg argument);
		
		TResult VisitParserNegatedElement(ParserNegatedElementSyntax node, TArg argument);
		
		TResult VisitParserRuleElement(ParserRuleElementSyntax node, TArg argument);
		
		TResult VisitParserRuleFixedElement(ParserRuleFixedElementSyntax node, TArg argument);
		
		TResult VisitParserRuleWildcardElement(ParserRuleWildcardElementSyntax node, TArg argument);
		
		TResult VisitParserRuleReference(ParserRuleReferenceSyntax node, TArg argument);
		
		TResult VisitParserRuleBlockElement(ParserRuleBlockElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node, TArg argument);
		
		TResult VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node, TArg argument);
		
		TResult VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleElement(LexerRuleElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleReferenceElement(LexerRuleReferenceElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleWildcardElement(LexerRuleWildcardElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleBlockElement(LexerRuleBlockElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleRangeElement(LexerRuleRangeElementSyntax node, TArg argument);
		
		TResult VisitName(NameSyntax node, TArg argument);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument);
		
		TResult VisitQualifier(QualifierSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
		TResult VisitLexerRuleIdentifier(LexerRuleIdentifierSyntax node, TArg argument);
		
		TResult VisitParserRuleIdentifier(ParserRuleIdentifierSyntax node, TArg argument);
		
		TResult VisitLexerRuleName(LexerRuleNameSyntax node, TArg argument);
		
		TResult VisitParserRuleName(ParserRuleNameSyntax node, TArg argument);
		
		TResult VisitElementName(ElementNameSyntax node, TArg argument);
		
		TResult VisitLiteral(LiteralSyntax node, TArg argument);
		
		TResult VisitNullLiteral(NullLiteralSyntax node, TArg argument);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node, TArg argument);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node, TArg argument);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node, TArg argument);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node, TArg argument);
		
		TResult VisitStringLiteral(StringLiteralSyntax node, TArg argument);
		
		TResult VisitCharLiteral(CharLiteralSyntax node, TArg argument);
	}
	
	public class CompilerSyntaxVisitor<TArg, TResult> : SyntaxVisitor<TArg, TResult>, ICompilerSyntaxVisitor<TArg, TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node, TArg argument)
	    {
	        return this.DefaultVisit(node, argument);
	    }
		
		public virtual TResult VisitMain(MainSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAnnotation(AnnotationSyntax node, TArg argument)
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
		
		public virtual TResult VisitGrammarDeclaration(GrammarDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUsingDeclaration(UsingDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRuleDeclarations(RuleDeclarationsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRuleDeclaration(RuleDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleAlt(ParserRuleAltSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleAltRef(ParserRuleAltRefSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleSimple(ParserRuleSimpleSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEofElement(EofElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleNamedElement(ParserRuleNamedElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAssign(AssignSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMultiplicity(MultiplicitySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserNegatedElement(ParserNegatedElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleElement(ParserRuleElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleFixedElement(ParserRuleFixedElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleWildcardElement(ParserRuleWildcardElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleReference(ParserRuleReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleBlockElement(ParserRuleBlockElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleElement(LexerRuleElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleReferenceElement(LexerRuleReferenceElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleWildcardElement(LexerRuleWildcardElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleBlockElement(LexerRuleBlockElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleRangeElement(LexerRuleRangeElementSyntax node, TArg argument)
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
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleIdentifier(LexerRuleIdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleIdentifier(ParserRuleIdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleName(LexerRuleNameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleName(ParserRuleNameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElementName(ElementNameSyntax node, TArg argument)
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
		
		public virtual TResult VisitCharLiteral(CharLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
	}

	public interface ICompilerSyntaxVisitor<TResult> 
	{
	    TResult VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node);
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitAnnotation(AnnotationSyntax node);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node);
		
		TResult VisitGrammarDeclaration(GrammarDeclarationSyntax node);
		
		TResult VisitUsingDeclaration(UsingDeclarationSyntax node);
		
		TResult VisitRuleDeclarations(RuleDeclarationsSyntax node);
		
		TResult VisitRuleDeclaration(RuleDeclarationSyntax node);
		
		TResult VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node);
		
		TResult VisitParserRuleAlt(ParserRuleAltSyntax node);
		
		TResult VisitParserRuleAltRef(ParserRuleAltRefSyntax node);
		
		TResult VisitParserRuleSimple(ParserRuleSimpleSyntax node);
		
		TResult VisitEofElement(EofElementSyntax node);
		
		TResult VisitParserRuleNamedElement(ParserRuleNamedElementSyntax node);
		
		TResult VisitAssign(AssignSyntax node);
		
		TResult VisitMultiplicity(MultiplicitySyntax node);
		
		TResult VisitParserNegatedElement(ParserNegatedElementSyntax node);
		
		TResult VisitParserRuleElement(ParserRuleElementSyntax node);
		
		TResult VisitParserRuleFixedElement(ParserRuleFixedElementSyntax node);
		
		TResult VisitParserRuleWildcardElement(ParserRuleWildcardElementSyntax node);
		
		TResult VisitParserRuleReference(ParserRuleReferenceSyntax node);
		
		TResult VisitParserRuleBlockElement(ParserRuleBlockElementSyntax node);
		
		TResult VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node);
		
		TResult VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node);
		
		TResult VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node);
		
		TResult VisitLexerRuleElement(LexerRuleElementSyntax node);
		
		TResult VisitLexerRuleReferenceElement(LexerRuleReferenceElementSyntax node);
		
		TResult VisitLexerRuleWildcardElement(LexerRuleWildcardElementSyntax node);
		
		TResult VisitLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax node);
		
		TResult VisitLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax node);
		
		TResult VisitLexerRuleBlockElement(LexerRuleBlockElementSyntax node);
		
		TResult VisitLexerRuleRangeElement(LexerRuleRangeElementSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitLexerRuleIdentifier(LexerRuleIdentifierSyntax node);
		
		TResult VisitParserRuleIdentifier(ParserRuleIdentifierSyntax node);
		
		TResult VisitLexerRuleName(LexerRuleNameSyntax node);
		
		TResult VisitParserRuleName(ParserRuleNameSyntax node);
		
		TResult VisitElementName(ElementNameSyntax node);
		
		TResult VisitLiteral(LiteralSyntax node);
		
		TResult VisitNullLiteral(NullLiteralSyntax node);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node);
		
		TResult VisitStringLiteral(StringLiteralSyntax node);
		
		TResult VisitCharLiteral(CharLiteralSyntax node);
	}
	
	public class CompilerSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, ICompilerSyntaxVisitor<TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node)
	    {
	        return this.DefaultVisit(node);
	    }
		
		public virtual TResult VisitMain(MainSyntax node)
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
		
		public virtual TResult VisitGrammarDeclaration(GrammarDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUsingDeclaration(UsingDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRuleDeclarations(RuleDeclarationsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRuleDeclaration(RuleDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleAlt(ParserRuleAltSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleAltRef(ParserRuleAltRefSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleSimple(ParserRuleSimpleSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEofElement(EofElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleNamedElement(ParserRuleNamedElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAssign(AssignSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMultiplicity(MultiplicitySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserNegatedElement(ParserNegatedElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleElement(ParserRuleElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleFixedElement(ParserRuleFixedElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleWildcardElement(ParserRuleWildcardElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleReference(ParserRuleReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleBlockElement(ParserRuleBlockElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleElement(LexerRuleElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleReferenceElement(LexerRuleReferenceElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleWildcardElement(LexerRuleWildcardElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleBlockElement(LexerRuleBlockElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleRangeElement(LexerRuleRangeElementSyntax node)
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
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleIdentifier(LexerRuleIdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleIdentifier(ParserRuleIdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleName(LexerRuleNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleName(ParserRuleNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElementName(ElementNameSyntax node)
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
		
		public virtual TResult VisitCharLiteral(CharLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class CompilerSyntaxRewriter : SyntaxRewriter, ICompilerSyntaxVisitor<SyntaxNode>
	{
	    public CompilerSyntaxRewriter(bool visitIntoStructuredTrivia = false)
			: base(CompilerLanguage.Instance, visitIntoStructuredTrivia)
	    {
	    }
	
	    public virtual SyntaxNode VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node)
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
		
		public virtual SyntaxNode VisitAnnotation(AnnotationSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, name, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var namespaceBody = (NamespaceBodySyntax)this.Visit(node.NamespaceBody);
			return node.Update(kNamespace, qualifiedName, tSemicolon, namespaceBody);
		}
		
		public virtual SyntaxNode VisitNamespaceBody(NamespaceBodySyntax node)
		{
		    var usingDeclaration = this.VisitList(node.UsingDeclaration);
		    var grammarDeclaration = (GrammarDeclarationSyntax)this.Visit(node.GrammarDeclaration);
			return node.Update(usingDeclaration, grammarDeclaration);
		}
		
		public virtual SyntaxNode VisitGrammarDeclaration(GrammarDeclarationSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var kGrammar = this.VisitToken(node.KGrammar);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var ruleDeclarations = (RuleDeclarationsSyntax)this.Visit(node.RuleDeclarations);
			return node.Update(annotation, kGrammar, name, tSemicolon, ruleDeclarations);
		}
		
		public virtual SyntaxNode VisitUsingDeclaration(UsingDeclarationSyntax node)
		{
		    var kUsing = this.VisitToken(node.KUsing);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tAssign = this.VisitToken(node.TAssign);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kUsing, name, tAssign, qualifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitRuleDeclarations(RuleDeclarationsSyntax node)
		{
		    var ruleDeclaration = this.VisitList(node.RuleDeclaration);
			return node.Update(ruleDeclaration);
		}
		
		public virtual SyntaxNode VisitRuleDeclaration(RuleDeclarationSyntax node)
		{
			var oldParserRuleDeclaration = node.ParserRuleDeclaration;
			if (oldParserRuleDeclaration != null)
			{
			    var newParserRuleDeclaration = (ParserRuleDeclarationSyntax)this.Visit(oldParserRuleDeclaration);
				return node.Update(newParserRuleDeclaration);
			}
			var oldLexerRuleDeclaration = node.LexerRuleDeclaration;
			if (oldLexerRuleDeclaration != null)
			{
			    var newLexerRuleDeclaration = (LexerRuleDeclarationSyntax)this.Visit(oldLexerRuleDeclaration);
				return node.Update(newLexerRuleDeclaration);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node)
		{
			var oldParserRuleAlt = node.ParserRuleAlt;
			if (oldParserRuleAlt != null)
			{
			    var newParserRuleAlt = (ParserRuleAltSyntax)this.Visit(oldParserRuleAlt);
				return node.Update(newParserRuleAlt);
			}
			var oldParserRuleSimple = node.ParserRuleSimple;
			if (oldParserRuleSimple != null)
			{
			    var newParserRuleSimple = (ParserRuleSimpleSyntax)this.Visit(oldParserRuleSimple);
				return node.Update(newParserRuleSimple);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitParserRuleAlt(ParserRuleAltSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var parserRuleName = (ParserRuleNameSyntax)this.Visit(node.ParserRuleName);
		    var kDefines = this.VisitToken(node.KDefines);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tColon = this.VisitToken(node.TColon);
		    var parserRuleAltRef = this.VisitList(node.ParserRuleAltRef);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(annotation, parserRuleName, kDefines, qualifier, tColon, parserRuleAltRef, tSemicolon);
		}
		
		public virtual SyntaxNode VisitParserRuleAltRef(ParserRuleAltRefSyntax node)
		{
		    var parserRuleIdentifier = (ParserRuleIdentifierSyntax)this.Visit(node.ParserRuleIdentifier);
			return node.Update(parserRuleIdentifier);
		}
		
		public virtual SyntaxNode VisitParserRuleSimple(ParserRuleSimpleSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var parserRuleName = (ParserRuleNameSyntax)this.Visit(node.ParserRuleName);
		    var kDefines = this.VisitToken(node.KDefines);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tColon = this.VisitToken(node.TColon);
		    var parserRuleNamedElement = this.VisitList(node.ParserRuleNamedElement);
		    var eofElement = (EofElementSyntax)this.Visit(node.EofElement);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(annotation, parserRuleName, kDefines, qualifier, tColon, parserRuleNamedElement, eofElement, tSemicolon);
		}
		
		public virtual SyntaxNode VisitEofElement(EofElementSyntax node)
		{
		    var kEof = this.VisitToken(node.KEof);
			return node.Update(kEof);
		}
		
		public virtual SyntaxNode VisitParserRuleNamedElement(ParserRuleNamedElementSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var elementName = (ElementNameSyntax)this.Visit(node.ElementName);
		    var assign = (AssignSyntax)this.Visit(node.Assign);
		    var parserNegatedElement = (ParserNegatedElementSyntax)this.Visit(node.ParserNegatedElement);
		    var multiplicity = (MultiplicitySyntax)this.Visit(node.Multiplicity);
			return node.Update(annotation, elementName, assign, parserNegatedElement, multiplicity);
		}
		
		public virtual SyntaxNode VisitAssign(AssignSyntax node)
		{
		    var assign = this.VisitToken(node.Assign);
			return node.Update(assign);
		}
		
		public virtual SyntaxNode VisitMultiplicity(MultiplicitySyntax node)
		{
		    var multiplicity = this.VisitToken(node.Multiplicity);
			return node.Update(multiplicity);
		}
		
		public virtual SyntaxNode VisitParserNegatedElement(ParserNegatedElementSyntax node)
		{
		    var tNegate = this.VisitToken(node.TNegate);
		    var parserRuleElement = (ParserRuleElementSyntax)this.Visit(node.ParserRuleElement);
			return node.Update(tNegate, parserRuleElement);
		}
		
		public virtual SyntaxNode VisitParserRuleElement(ParserRuleElementSyntax node)
		{
			var oldParserRuleFixedElement = node.ParserRuleFixedElement;
			if (oldParserRuleFixedElement != null)
			{
			    var newParserRuleFixedElement = (ParserRuleFixedElementSyntax)this.Visit(oldParserRuleFixedElement);
				return node.Update(newParserRuleFixedElement);
			}
			var oldParserRuleReference = node.ParserRuleReference;
			if (oldParserRuleReference != null)
			{
			    var newParserRuleReference = (ParserRuleReferenceSyntax)this.Visit(oldParserRuleReference);
				return node.Update(newParserRuleReference);
			}
			var oldParserRuleWildcardElement = node.ParserRuleWildcardElement;
			if (oldParserRuleWildcardElement != null)
			{
			    var newParserRuleWildcardElement = (ParserRuleWildcardElementSyntax)this.Visit(oldParserRuleWildcardElement);
				return node.Update(newParserRuleWildcardElement);
			}
			var oldParserRuleBlockElement = node.ParserRuleBlockElement;
			if (oldParserRuleBlockElement != null)
			{
			    var newParserRuleBlockElement = (ParserRuleBlockElementSyntax)this.Visit(oldParserRuleBlockElement);
				return node.Update(newParserRuleBlockElement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitParserRuleFixedElement(ParserRuleFixedElementSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var stringLiteral = (StringLiteralSyntax)this.Visit(node.StringLiteral);
			return node.Update(annotation, stringLiteral);
		}
		
		public virtual SyntaxNode VisitParserRuleWildcardElement(ParserRuleWildcardElementSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var tDot = this.VisitToken(node.TDot);
			return node.Update(annotation, tDot);
		}
		
		public virtual SyntaxNode VisitParserRuleReference(ParserRuleReferenceSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(annotation, identifier);
		}
		
		public virtual SyntaxNode VisitParserRuleBlockElement(ParserRuleBlockElementSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var parserRuleNamedElement = this.VisitList(node.ParserRuleNamedElement);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(annotation, tOpenParen, parserRuleNamedElement, tCloseParen);
		}
		
		public virtual SyntaxNode VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node)
		{
		    var annotation = this.VisitList(node.Annotation);
		    var modifier = this.VisitToken(node.Modifier);
		    var lexerRuleName = (LexerRuleNameSyntax)this.Visit(node.LexerRuleName);
		    var kReturns = this.VisitToken(node.KReturns);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tColon = this.VisitToken(node.TColon);
		    var lexerRuleAlternative = this.VisitList(node.LexerRuleAlternative);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(annotation, modifier, lexerRuleName, kReturns, qualifier, tColon, lexerRuleAlternative, tSemicolon);
		}
		
		public virtual SyntaxNode VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node)
		{
		    var lexerRuleAlternativeElement = this.VisitList(node.LexerRuleAlternativeElement);
			return node.Update(lexerRuleAlternativeElement);
		}
		
		public virtual SyntaxNode VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node)
		{
		    var tNegate = this.VisitToken(node.TNegate);
		    var lexerRuleElement = (LexerRuleElementSyntax)this.Visit(node.LexerRuleElement);
		    var multiplicity = (MultiplicitySyntax)this.Visit(node.Multiplicity);
			return node.Update(tNegate, lexerRuleElement, multiplicity);
		}
		
		public virtual SyntaxNode VisitLexerRuleElement(LexerRuleElementSyntax node)
		{
			var oldLexerRuleReferenceElement = node.LexerRuleReferenceElement;
			if (oldLexerRuleReferenceElement != null)
			{
			    var newLexerRuleReferenceElement = (LexerRuleReferenceElementSyntax)this.Visit(oldLexerRuleReferenceElement);
				return node.Update(newLexerRuleReferenceElement);
			}
			var oldLexerRuleFixedStringElement = node.LexerRuleFixedStringElement;
			if (oldLexerRuleFixedStringElement != null)
			{
			    var newLexerRuleFixedStringElement = (LexerRuleFixedStringElementSyntax)this.Visit(oldLexerRuleFixedStringElement);
				return node.Update(newLexerRuleFixedStringElement);
			}
			var oldLexerRuleFixedCharElement = node.LexerRuleFixedCharElement;
			if (oldLexerRuleFixedCharElement != null)
			{
			    var newLexerRuleFixedCharElement = (LexerRuleFixedCharElementSyntax)this.Visit(oldLexerRuleFixedCharElement);
				return node.Update(newLexerRuleFixedCharElement);
			}
			var oldLexerRuleWildcardElement = node.LexerRuleWildcardElement;
			if (oldLexerRuleWildcardElement != null)
			{
			    var newLexerRuleWildcardElement = (LexerRuleWildcardElementSyntax)this.Visit(oldLexerRuleWildcardElement);
				return node.Update(newLexerRuleWildcardElement);
			}
			var oldLexerRuleBlockElement = node.LexerRuleBlockElement;
			if (oldLexerRuleBlockElement != null)
			{
			    var newLexerRuleBlockElement = (LexerRuleBlockElementSyntax)this.Visit(oldLexerRuleBlockElement);
				return node.Update(newLexerRuleBlockElement);
			}
			var oldLexerRuleRangeElement = node.LexerRuleRangeElement;
			if (oldLexerRuleRangeElement != null)
			{
			    var newLexerRuleRangeElement = (LexerRuleRangeElementSyntax)this.Visit(oldLexerRuleRangeElement);
				return node.Update(newLexerRuleRangeElement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitLexerRuleReferenceElement(LexerRuleReferenceElementSyntax node)
		{
		    var lexerRuleIdentifier = (LexerRuleIdentifierSyntax)this.Visit(node.LexerRuleIdentifier);
			return node.Update(lexerRuleIdentifier);
		}
		
		public virtual SyntaxNode VisitLexerRuleWildcardElement(LexerRuleWildcardElementSyntax node)
		{
		    var tDot = this.VisitToken(node.TDot);
			return node.Update(tDot);
		}
		
		public virtual SyntaxNode VisitLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax node)
		{
		    var lString = this.VisitToken(node.LString);
			return node.Update(lString);
		}
		
		public virtual SyntaxNode VisitLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax node)
		{
		    var lCharacter = this.VisitToken(node.LCharacter);
			return node.Update(lCharacter);
		}
		
		public virtual SyntaxNode VisitLexerRuleBlockElement(LexerRuleBlockElementSyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var lexerRuleAlternative = this.VisitList(node.LexerRuleAlternative);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(tOpenParen, lexerRuleAlternative, tCloseParen);
		}
		
		public virtual SyntaxNode VisitLexerRuleRangeElement(LexerRuleRangeElementSyntax node)
		{
		    var start = (LexerRuleFixedCharElementSyntax)this.Visit(node.Start);
		    var tDotDot = this.VisitToken(node.TDotDot);
		    var end = (LexerRuleFixedCharElementSyntax)this.Visit(node.End);
			return node.Update(start, tDotDot, end);
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
		
		public virtual SyntaxNode VisitIdentifier(IdentifierSyntax node)
		{
		    var identifier = this.VisitToken(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitLexerRuleIdentifier(LexerRuleIdentifierSyntax node)
		{
		    var lexerIdentifier = this.VisitToken(node.LexerIdentifier);
			return node.Update(lexerIdentifier);
		}
		
		public virtual SyntaxNode VisitParserRuleIdentifier(ParserRuleIdentifierSyntax node)
		{
		    var parserIdentifier = this.VisitToken(node.ParserIdentifier);
			return node.Update(parserIdentifier);
		}
		
		public virtual SyntaxNode VisitLexerRuleName(LexerRuleNameSyntax node)
		{
		    var lexerIdentifier = this.VisitToken(node.LexerIdentifier);
			return node.Update(lexerIdentifier);
		}
		
		public virtual SyntaxNode VisitParserRuleName(ParserRuleNameSyntax node)
		{
		    var parserIdentifier = this.VisitToken(node.ParserIdentifier);
			return node.Update(parserIdentifier);
		}
		
		public virtual SyntaxNode VisitElementName(ElementNameSyntax node)
		{
		    var elementName = this.VisitToken(node.ElementName);
			return node.Update(elementName);
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
		    var lString = this.VisitToken(node.LString);
			return node.Update(lString);
		}
		
		public virtual SyntaxNode VisitCharLiteral(CharLiteralSyntax node)
		{
		    var lCharacter = this.VisitToken(node.LCharacter);
			return node.Update(lCharacter);
		}
	}

	public class CompilerSyntaxFactory : SyntaxFactory
	{
		internal CompilerSyntaxFactory(CompilerInternalSyntaxFactory internalSyntaxFactory) 
			: base(internalSyntaxFactory)
		{
		}
	    public new CompilerLanguage Language => CompilerLanguage.Instance;
	    protected override Language LanguageCore => this.Language;
	    public override LanguageParseOptions DefaultParseOptions => CompilerParseOptions.Default;
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public CompilerSyntaxTree SyntaxTree(SyntaxNode root, CompilerParseOptions? options = null, string? path = "", Encoding? encoding = null)
		{
			return CompilerSyntaxTree.Create((CompilerSyntaxNode)root, ParseData.Empty, options, path, null, encoding);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public CompilerSyntaxTree ParseSyntaxTree(
			string text,
			CompilerParseOptions options = null,
			string path = "",
			Encoding encoding = null,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (CompilerSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public CompilerSyntaxTree ParseSyntaxTree(
			SourceText text,
			CompilerParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (CompilerSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
		protected override LanguageSyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return CompilerSyntaxTree.ParseText(text, (CompilerParseOptions)options, path, cancellationToken);
		}
	
		public override LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return CompilerSyntaxTree.Create((CompilerSyntaxNode)root, ParseData.Empty, (CompilerParseOptions)options, path, null, encoding);
		}
	
	
	    public SyntaxToken LexerIdentifier(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LexerIdentifier(text));
	    }
	
	    public SyntaxToken LexerIdentifier(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LexerIdentifier(text, value));
	    }
	
	    public SyntaxToken ParserIdentifier(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.ParserIdentifier(text));
	    }
	
	    public SyntaxToken ParserIdentifier(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.ParserIdentifier(text, value));
	    }
	
	    public SyntaxToken IgnoredIdentifier(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.IgnoredIdentifier(text));
	    }
	
	    public SyntaxToken IgnoredIdentifier(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.IgnoredIdentifier(text, value));
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LInteger(text));
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LInteger(text, value));
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LDecimal(text));
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LDecimal(text, value));
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LScientific(text));
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LScientific(text, value));
	    }
	
	    public SyntaxToken LString(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LString(text));
	    }
	
	    public SyntaxToken LString(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LString(text, value));
	    }
	
	    public SyntaxToken LCharacter(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LCharacter(text));
	    }
	
	    public SyntaxToken LCharacter(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LCharacter(text, value));
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text));
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value));
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text));
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value));
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LCrLf(text));
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value));
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LLineEnd(text));
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value));
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text));
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value));
	    }
	
	    public SyntaxToken LMultilineComment(string text)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LMultilineComment(text));
	    }
	
	    public SyntaxToken LMultilineComment(string text, object value)
	    {
	        return new SyntaxToken(CompilerLanguage.Instance.InternalSyntaxFactory.LMultilineComment(text, value));
	    }
		
		public MainSyntax Main(NamespaceDeclarationSyntax namespaceDeclaration, SyntaxToken eOF)
		{
		    if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
		    if (eOF == null) throw new ArgumentNullException(nameof(eOF));
		    if (eOF.GetKind() != CompilerSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
		    return (MainSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Main((Syntax.InternalSyntax.NamespaceDeclarationGreen)namespaceDeclaration.Green, (InternalSyntaxToken)eOF.Node).CreateRed();
		}
		
		public AnnotationSyntax Annotation(SyntaxToken tOpenBracket, NameSyntax name, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != CompilerSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != CompilerSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (AnnotationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Annotation((InternalSyntaxToken)tOpenBracket.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public AnnotationSyntax Annotation(NameSyntax name)
		{
			return this.Annotation(this.Token(CompilerSyntaxKind.TOpenBracket), name, this.Token(CompilerSyntaxKind.TCloseBracket));
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, SyntaxToken tSemicolon, NamespaceBodySyntax namespaceBody)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != CompilerSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    if (namespaceBody == null) throw new ArgumentNullException(nameof(namespaceBody));
		    return (NamespaceDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (InternalSyntaxToken)tSemicolon.Node, (Syntax.InternalSyntax.NamespaceBodyGreen)namespaceBody.Green).CreateRed();
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(QualifiedNameSyntax qualifiedName, NamespaceBodySyntax namespaceBody)
		{
			return this.NamespaceDeclaration(this.Token(CompilerSyntaxKind.KNamespace), qualifiedName, this.Token(CompilerSyntaxKind.TSemicolon), namespaceBody);
		}
		
		public NamespaceBodySyntax NamespaceBody(Microsoft.CodeAnalysis.SyntaxList<UsingDeclarationSyntax> usingDeclaration, GrammarDeclarationSyntax grammarDeclaration)
		{
		    if (grammarDeclaration == null) throw new ArgumentNullException(nameof(grammarDeclaration));
		    return (NamespaceBodySyntax)CompilerLanguage.Instance.InternalSyntaxFactory.NamespaceBody(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<UsingDeclarationGreen>(usingDeclaration.Node), (Syntax.InternalSyntax.GrammarDeclarationGreen)grammarDeclaration.Green).CreateRed();
		}
		
		public NamespaceBodySyntax NamespaceBody(GrammarDeclarationSyntax grammarDeclaration)
		{
			return this.NamespaceBody(default, grammarDeclaration);
		}
		
		public GrammarDeclarationSyntax GrammarDeclaration(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, SyntaxToken kGrammar, NameSyntax name, SyntaxToken tSemicolon, RuleDeclarationsSyntax ruleDeclarations)
		{
		    if (kGrammar == null) throw new ArgumentNullException(nameof(kGrammar));
		    if (kGrammar.GetKind() != CompilerSyntaxKind.KGrammar) throw new ArgumentException(nameof(kGrammar));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    if (ruleDeclarations == null) throw new ArgumentNullException(nameof(ruleDeclarations));
		    return (GrammarDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.GrammarDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node), (InternalSyntaxToken)kGrammar.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node, (Syntax.InternalSyntax.RuleDeclarationsGreen)ruleDeclarations.Green).CreateRed();
		}
		
		public GrammarDeclarationSyntax GrammarDeclaration(NameSyntax name, RuleDeclarationsSyntax ruleDeclarations)
		{
			return this.GrammarDeclaration(default, this.Token(CompilerSyntaxKind.KGrammar), name, this.Token(CompilerSyntaxKind.TSemicolon), ruleDeclarations);
		}
		
		public UsingDeclarationSyntax UsingDeclaration(SyntaxToken kUsing, NameSyntax name, SyntaxToken tAssign, QualifierSyntax qualifier, SyntaxToken tSemicolon)
		{
		    if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
		    if (kUsing.GetKind() != CompilerSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
		    if (tAssign != null && tAssign.GetKind() != CompilerSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (UsingDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.UsingDeclaration((InternalSyntaxToken)kUsing.Node, name == null ? null : (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public UsingDeclarationSyntax UsingDeclaration(QualifierSyntax qualifier)
		{
			return this.UsingDeclaration(this.Token(CompilerSyntaxKind.KUsing), default, default, qualifier, this.Token(CompilerSyntaxKind.TSemicolon));
		}
		
		public RuleDeclarationsSyntax RuleDeclarations(Microsoft.CodeAnalysis.SyntaxList<RuleDeclarationSyntax> ruleDeclaration)
		{
		    return (RuleDeclarationsSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.RuleDeclarations(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<RuleDeclarationGreen>(ruleDeclaration.Node)).CreateRed();
		}
		
		public RuleDeclarationsSyntax RuleDeclarations()
		{
			return this.RuleDeclarations(default);
		}
		
		public RuleDeclarationSyntax RuleDeclaration(ParserRuleDeclarationSyntax parserRuleDeclaration)
		{
		    if (parserRuleDeclaration == null) throw new ArgumentNullException(nameof(parserRuleDeclaration));
		    return (RuleDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.RuleDeclaration((Syntax.InternalSyntax.ParserRuleDeclarationGreen)parserRuleDeclaration.Green).CreateRed();
		}
		
		public RuleDeclarationSyntax RuleDeclaration(LexerRuleDeclarationSyntax lexerRuleDeclaration)
		{
		    if (lexerRuleDeclaration == null) throw new ArgumentNullException(nameof(lexerRuleDeclaration));
		    return (RuleDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.RuleDeclaration((Syntax.InternalSyntax.LexerRuleDeclarationGreen)lexerRuleDeclaration.Green).CreateRed();
		}
		
		public ParserRuleDeclarationSyntax ParserRuleDeclaration(ParserRuleAltSyntax parserRuleAlt)
		{
		    if (parserRuleAlt == null) throw new ArgumentNullException(nameof(parserRuleAlt));
		    return (ParserRuleDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleDeclaration((Syntax.InternalSyntax.ParserRuleAltGreen)parserRuleAlt.Green).CreateRed();
		}
		
		public ParserRuleDeclarationSyntax ParserRuleDeclaration(ParserRuleSimpleSyntax parserRuleSimple)
		{
		    if (parserRuleSimple == null) throw new ArgumentNullException(nameof(parserRuleSimple));
		    return (ParserRuleDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleDeclaration((Syntax.InternalSyntax.ParserRuleSimpleGreen)parserRuleSimple.Green).CreateRed();
		}
		
		public ParserRuleAltSyntax ParserRuleAlt(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, ParserRuleNameSyntax parserRuleName, SyntaxToken kDefines, QualifierSyntax qualifier, SyntaxToken tColon, Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAltRefSyntax> parserRuleAltRef, SyntaxToken tSemicolon)
		{
		    if (parserRuleName == null) throw new ArgumentNullException(nameof(parserRuleName));
		    if (kDefines != null && kDefines.GetKind() != CompilerSyntaxKind.KDefines) throw new ArgumentException(nameof(kDefines));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != CompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (parserRuleAltRef == null) throw new ArgumentNullException(nameof(parserRuleAltRef));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ParserRuleAltSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleAlt(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node), (Syntax.InternalSyntax.ParserRuleNameGreen)parserRuleName.Green, (InternalSyntaxToken)kDefines.Node, qualifier == null ? null : (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tColon.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParserRuleAltRefGreen>(parserRuleAltRef.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ParserRuleAltSyntax ParserRuleAlt(ParserRuleNameSyntax parserRuleName, Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAltRefSyntax> parserRuleAltRef)
		{
			return this.ParserRuleAlt(default, parserRuleName, default, default, this.Token(CompilerSyntaxKind.TColon), parserRuleAltRef, this.Token(CompilerSyntaxKind.TSemicolon));
		}
		
		public ParserRuleAltRefSyntax ParserRuleAltRef(ParserRuleIdentifierSyntax parserRuleIdentifier)
		{
		    if (parserRuleIdentifier == null) throw new ArgumentNullException(nameof(parserRuleIdentifier));
		    return (ParserRuleAltRefSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleAltRef((Syntax.InternalSyntax.ParserRuleIdentifierGreen)parserRuleIdentifier.Green).CreateRed();
		}
		
		public ParserRuleSimpleSyntax ParserRuleSimple(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, ParserRuleNameSyntax parserRuleName, SyntaxToken kDefines, QualifierSyntax qualifier, SyntaxToken tColon, Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> parserRuleNamedElement, EofElementSyntax eofElement, SyntaxToken tSemicolon)
		{
		    if (parserRuleName == null) throw new ArgumentNullException(nameof(parserRuleName));
		    if (kDefines != null && kDefines.GetKind() != CompilerSyntaxKind.KDefines) throw new ArgumentException(nameof(kDefines));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != CompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (parserRuleNamedElement == null) throw new ArgumentNullException(nameof(parserRuleNamedElement));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ParserRuleSimpleSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleSimple(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node), (Syntax.InternalSyntax.ParserRuleNameGreen)parserRuleName.Green, (InternalSyntaxToken)kDefines.Node, qualifier == null ? null : (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tColon.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ParserRuleNamedElementGreen>(parserRuleNamedElement.Node), eofElement == null ? null : (Syntax.InternalSyntax.EofElementGreen)eofElement.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ParserRuleSimpleSyntax ParserRuleSimple(ParserRuleNameSyntax parserRuleName, Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> parserRuleNamedElement)
		{
			return this.ParserRuleSimple(default, parserRuleName, default, default, this.Token(CompilerSyntaxKind.TColon), parserRuleNamedElement, default, this.Token(CompilerSyntaxKind.TSemicolon));
		}
		
		public EofElementSyntax EofElement(SyntaxToken kEof)
		{
		    if (kEof == null) throw new ArgumentNullException(nameof(kEof));
		    if (kEof.GetKind() != CompilerSyntaxKind.KEof) throw new ArgumentException(nameof(kEof));
		    return (EofElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.EofElement((InternalSyntaxToken)kEof.Node).CreateRed();
		}
		
		public EofElementSyntax EofElement()
		{
			return this.EofElement(this.Token(CompilerSyntaxKind.KEof));
		}
		
		public ParserRuleNamedElementSyntax ParserRuleNamedElement(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, ElementNameSyntax elementName, AssignSyntax assign, ParserNegatedElementSyntax parserNegatedElement, MultiplicitySyntax multiplicity)
		{
		    if (parserNegatedElement == null) throw new ArgumentNullException(nameof(parserNegatedElement));
		    return (ParserRuleNamedElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleNamedElement(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node), elementName == null ? null : (Syntax.InternalSyntax.ElementNameGreen)elementName.Green, assign == null ? null : (Syntax.InternalSyntax.AssignGreen)assign.Green, (Syntax.InternalSyntax.ParserNegatedElementGreen)parserNegatedElement.Green, multiplicity == null ? null : (Syntax.InternalSyntax.MultiplicityGreen)multiplicity.Green).CreateRed();
		}
		
		public ParserRuleNamedElementSyntax ParserRuleNamedElement(ParserNegatedElementSyntax parserNegatedElement)
		{
			return this.ParserRuleNamedElement(default, default, default, parserNegatedElement, default);
		}
		
		public AssignSyntax Assign(SyntaxToken assign)
		{
		    if (assign == null) throw new ArgumentNullException(nameof(assign));
		    return (AssignSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Assign((InternalSyntaxToken)assign.Node).CreateRed();
		}
		
		public MultiplicitySyntax Multiplicity(SyntaxToken multiplicity)
		{
		    if (multiplicity == null) throw new ArgumentNullException(nameof(multiplicity));
		    return (MultiplicitySyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Multiplicity((InternalSyntaxToken)multiplicity.Node).CreateRed();
		}
		
		public ParserNegatedElementSyntax ParserNegatedElement(SyntaxToken tNegate, ParserRuleElementSyntax parserRuleElement)
		{
		    if (tNegate != null && tNegate.GetKind() != CompilerSyntaxKind.TNegate) throw new ArgumentException(nameof(tNegate));
		    if (parserRuleElement == null) throw new ArgumentNullException(nameof(parserRuleElement));
		    return (ParserNegatedElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserNegatedElement((InternalSyntaxToken)tNegate.Node, (Syntax.InternalSyntax.ParserRuleElementGreen)parserRuleElement.Green).CreateRed();
		}
		
		public ParserNegatedElementSyntax ParserNegatedElement(ParserRuleElementSyntax parserRuleElement)
		{
			return this.ParserNegatedElement(default, parserRuleElement);
		}
		
		public ParserRuleElementSyntax ParserRuleElement(ParserRuleFixedElementSyntax parserRuleFixedElement)
		{
		    if (parserRuleFixedElement == null) throw new ArgumentNullException(nameof(parserRuleFixedElement));
		    return (ParserRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement((Syntax.InternalSyntax.ParserRuleFixedElementGreen)parserRuleFixedElement.Green).CreateRed();
		}
		
		public ParserRuleElementSyntax ParserRuleElement(ParserRuleReferenceSyntax parserRuleReference)
		{
		    if (parserRuleReference == null) throw new ArgumentNullException(nameof(parserRuleReference));
		    return (ParserRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement((Syntax.InternalSyntax.ParserRuleReferenceGreen)parserRuleReference.Green).CreateRed();
		}
		
		public ParserRuleElementSyntax ParserRuleElement(ParserRuleWildcardElementSyntax parserRuleWildcardElement)
		{
		    if (parserRuleWildcardElement == null) throw new ArgumentNullException(nameof(parserRuleWildcardElement));
		    return (ParserRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement((Syntax.InternalSyntax.ParserRuleWildcardElementGreen)parserRuleWildcardElement.Green).CreateRed();
		}
		
		public ParserRuleElementSyntax ParserRuleElement(ParserRuleBlockElementSyntax parserRuleBlockElement)
		{
		    if (parserRuleBlockElement == null) throw new ArgumentNullException(nameof(parserRuleBlockElement));
		    return (ParserRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement((Syntax.InternalSyntax.ParserRuleBlockElementGreen)parserRuleBlockElement.Green).CreateRed();
		}
		
		public ParserRuleFixedElementSyntax ParserRuleFixedElement(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (ParserRuleFixedElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleFixedElement(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node), (Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public ParserRuleFixedElementSyntax ParserRuleFixedElement(StringLiteralSyntax stringLiteral)
		{
			return this.ParserRuleFixedElement(default, stringLiteral);
		}
		
		public ParserRuleWildcardElementSyntax ParserRuleWildcardElement(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, SyntaxToken tDot)
		{
		    if (tDot == null) throw new ArgumentNullException(nameof(tDot));
		    if (tDot.GetKind() != CompilerSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
		    return (ParserRuleWildcardElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleWildcardElement(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node), (InternalSyntaxToken)tDot.Node).CreateRed();
		}
		
		public ParserRuleWildcardElementSyntax ParserRuleWildcardElement()
		{
			return this.ParserRuleWildcardElement(default, this.Token(CompilerSyntaxKind.TDot));
		}
		
		public ParserRuleReferenceSyntax ParserRuleReference(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (ParserRuleReferenceSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleReference(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node), (Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public ParserRuleReferenceSyntax ParserRuleReference(IdentifierSyntax identifier)
		{
			return this.ParserRuleReference(default, identifier);
		}
		
		public ParserRuleBlockElementSyntax ParserRuleBlockElement(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, SyntaxToken tOpenParen, Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> parserRuleNamedElement, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CompilerSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (parserRuleNamedElement == null) throw new ArgumentNullException(nameof(parserRuleNamedElement));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CompilerSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (ParserRuleBlockElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleBlockElement(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node), (InternalSyntaxToken)tOpenParen.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ParserRuleNamedElementGreen>(parserRuleNamedElement.Node), (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public ParserRuleBlockElementSyntax ParserRuleBlockElement(Microsoft.CodeAnalysis.SyntaxList<ParserRuleNamedElementSyntax> parserRuleNamedElement)
		{
			return this.ParserRuleBlockElement(default, this.Token(CompilerSyntaxKind.TOpenParen), parserRuleNamedElement, this.Token(CompilerSyntaxKind.TCloseParen));
		}
		
		public LexerRuleDeclarationSyntax LexerRuleDeclaration(Microsoft.CodeAnalysis.SyntaxList<AnnotationSyntax> annotation, SyntaxToken modifier, LexerRuleNameSyntax lexerRuleName, SyntaxToken kReturns, QualifierSyntax qualifier, SyntaxToken tColon, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative, SyntaxToken tSemicolon)
		{
		    if (lexerRuleName == null) throw new ArgumentNullException(nameof(lexerRuleName));
		    if (kReturns != null && kReturns.GetKind() != CompilerSyntaxKind.KReturns) throw new ArgumentException(nameof(kReturns));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != CompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (lexerRuleAlternative == null) throw new ArgumentNullException(nameof(lexerRuleAlternative));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (LexerRuleDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleDeclaration(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<AnnotationGreen>(annotation.Node), modifier == null ? null : (InternalSyntaxToken)modifier.Node, (Syntax.InternalSyntax.LexerRuleNameGreen)lexerRuleName.Green, (InternalSyntaxToken)kReturns.Node, qualifier == null ? null : (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tColon.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<LexerRuleAlternativeGreen>(lexerRuleAlternative.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public LexerRuleDeclarationSyntax LexerRuleDeclaration(LexerRuleNameSyntax lexerRuleName, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative)
		{
			return this.LexerRuleDeclaration(default, default, lexerRuleName, default, default, this.Token(CompilerSyntaxKind.TColon), lexerRuleAlternative, this.Token(CompilerSyntaxKind.TSemicolon));
		}
		
		public LexerRuleAlternativeSyntax LexerRuleAlternative(Microsoft.CodeAnalysis.SyntaxList<LexerRuleAlternativeElementSyntax> lexerRuleAlternativeElement)
		{
		    if (lexerRuleAlternativeElement == null) throw new ArgumentNullException(nameof(lexerRuleAlternativeElement));
		    return (LexerRuleAlternativeSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleAlternative(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<LexerRuleAlternativeElementGreen>(lexerRuleAlternativeElement.Node)).CreateRed();
		}
		
		public LexerRuleAlternativeElementSyntax LexerRuleAlternativeElement(SyntaxToken tNegate, LexerRuleElementSyntax lexerRuleElement, MultiplicitySyntax multiplicity)
		{
		    if (tNegate != null && tNegate.GetKind() != CompilerSyntaxKind.TNegate) throw new ArgumentException(nameof(tNegate));
		    if (lexerRuleElement == null) throw new ArgumentNullException(nameof(lexerRuleElement));
		    return (LexerRuleAlternativeElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleAlternativeElement((InternalSyntaxToken)tNegate.Node, (Syntax.InternalSyntax.LexerRuleElementGreen)lexerRuleElement.Green, multiplicity == null ? null : (Syntax.InternalSyntax.MultiplicityGreen)multiplicity.Green).CreateRed();
		}
		
		public LexerRuleAlternativeElementSyntax LexerRuleAlternativeElement(LexerRuleElementSyntax lexerRuleElement)
		{
			return this.LexerRuleAlternativeElement(default, lexerRuleElement, default);
		}
		
		public LexerRuleElementSyntax LexerRuleElement(LexerRuleReferenceElementSyntax lexerRuleReferenceElement)
		{
		    if (lexerRuleReferenceElement == null) throw new ArgumentNullException(nameof(lexerRuleReferenceElement));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.LexerRuleReferenceElementGreen)lexerRuleReferenceElement.Green).CreateRed();
		}
		
		public LexerRuleElementSyntax LexerRuleElement(LexerRuleFixedStringElementSyntax lexerRuleFixedStringElement)
		{
		    if (lexerRuleFixedStringElement == null) throw new ArgumentNullException(nameof(lexerRuleFixedStringElement));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.LexerRuleFixedStringElementGreen)lexerRuleFixedStringElement.Green).CreateRed();
		}
		
		public LexerRuleElementSyntax LexerRuleElement(LexerRuleFixedCharElementSyntax lexerRuleFixedCharElement)
		{
		    if (lexerRuleFixedCharElement == null) throw new ArgumentNullException(nameof(lexerRuleFixedCharElement));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.LexerRuleFixedCharElementGreen)lexerRuleFixedCharElement.Green).CreateRed();
		}
		
		public LexerRuleElementSyntax LexerRuleElement(LexerRuleWildcardElementSyntax lexerRuleWildcardElement)
		{
		    if (lexerRuleWildcardElement == null) throw new ArgumentNullException(nameof(lexerRuleWildcardElement));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.LexerRuleWildcardElementGreen)lexerRuleWildcardElement.Green).CreateRed();
		}
		
		public LexerRuleElementSyntax LexerRuleElement(LexerRuleBlockElementSyntax lexerRuleBlockElement)
		{
		    if (lexerRuleBlockElement == null) throw new ArgumentNullException(nameof(lexerRuleBlockElement));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.LexerRuleBlockElementGreen)lexerRuleBlockElement.Green).CreateRed();
		}
		
		public LexerRuleElementSyntax LexerRuleElement(LexerRuleRangeElementSyntax lexerRuleRangeElement)
		{
		    if (lexerRuleRangeElement == null) throw new ArgumentNullException(nameof(lexerRuleRangeElement));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.LexerRuleRangeElementGreen)lexerRuleRangeElement.Green).CreateRed();
		}
		
		public LexerRuleReferenceElementSyntax LexerRuleReferenceElement(LexerRuleIdentifierSyntax lexerRuleIdentifier)
		{
		    if (lexerRuleIdentifier == null) throw new ArgumentNullException(nameof(lexerRuleIdentifier));
		    return (LexerRuleReferenceElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleReferenceElement((Syntax.InternalSyntax.LexerRuleIdentifierGreen)lexerRuleIdentifier.Green).CreateRed();
		}
		
		public LexerRuleWildcardElementSyntax LexerRuleWildcardElement(SyntaxToken tDot)
		{
		    if (tDot == null) throw new ArgumentNullException(nameof(tDot));
		    if (tDot.GetKind() != CompilerSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
		    return (LexerRuleWildcardElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleWildcardElement((InternalSyntaxToken)tDot.Node).CreateRed();
		}
		
		public LexerRuleWildcardElementSyntax LexerRuleWildcardElement()
		{
			return this.LexerRuleWildcardElement(this.Token(CompilerSyntaxKind.TDot));
		}
		
		public LexerRuleFixedStringElementSyntax LexerRuleFixedStringElement(SyntaxToken lString)
		{
		    if (lString == null) throw new ArgumentNullException(nameof(lString));
		    if (lString.GetKind() != CompilerSyntaxKind.LString) throw new ArgumentException(nameof(lString));
		    return (LexerRuleFixedStringElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleFixedStringElement((InternalSyntaxToken)lString.Node).CreateRed();
		}
		
		public LexerRuleFixedCharElementSyntax LexerRuleFixedCharElement(SyntaxToken lCharacter)
		{
		    if (lCharacter == null) throw new ArgumentNullException(nameof(lCharacter));
		    if (lCharacter.GetKind() != CompilerSyntaxKind.LCharacter) throw new ArgumentException(nameof(lCharacter));
		    return (LexerRuleFixedCharElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleFixedCharElement((InternalSyntaxToken)lCharacter.Node).CreateRed();
		}
		
		public LexerRuleBlockElementSyntax LexerRuleBlockElement(SyntaxToken tOpenParen, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CompilerSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (lexerRuleAlternative == null) throw new ArgumentNullException(nameof(lexerRuleAlternative));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CompilerSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (LexerRuleBlockElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleBlockElement((InternalSyntaxToken)tOpenParen.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<LexerRuleAlternativeGreen>(lexerRuleAlternative.Node), (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public LexerRuleBlockElementSyntax LexerRuleBlockElement(Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative)
		{
			return this.LexerRuleBlockElement(this.Token(CompilerSyntaxKind.TOpenParen), lexerRuleAlternative, this.Token(CompilerSyntaxKind.TCloseParen));
		}
		
		public LexerRuleRangeElementSyntax LexerRuleRangeElement(LexerRuleFixedCharElementSyntax start, SyntaxToken tDotDot, LexerRuleFixedCharElementSyntax end)
		{
		    if (start == null) throw new ArgumentNullException(nameof(start));
		    if (tDotDot == null) throw new ArgumentNullException(nameof(tDotDot));
		    if (tDotDot.GetKind() != CompilerSyntaxKind.TDotDot) throw new ArgumentException(nameof(tDotDot));
		    if (end == null) throw new ArgumentNullException(nameof(end));
		    return (LexerRuleRangeElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleRangeElement((Syntax.InternalSyntax.LexerRuleFixedCharElementGreen)start.Green, (InternalSyntaxToken)tDotDot.Node, (Syntax.InternalSyntax.LexerRuleFixedCharElementGreen)end.Green).CreateRed();
		}
		
		public LexerRuleRangeElementSyntax LexerRuleRangeElement(LexerRuleFixedCharElementSyntax start, LexerRuleFixedCharElementSyntax end)
		{
			return this.LexerRuleRangeElement(start, this.Token(CompilerSyntaxKind.TDotDot), end);
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public QualifiedNameSyntax QualifiedName(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifiedNameSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.QualifiedName((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public QualifierSyntax Qualifier(Microsoft.CodeAnalysis.SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Qualifier(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public IdentifierSyntax Identifier(SyntaxToken identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)identifier.Node).CreateRed();
		}
		
		public LexerRuleIdentifierSyntax LexerRuleIdentifier(SyntaxToken lexerIdentifier)
		{
		    if (lexerIdentifier == null) throw new ArgumentNullException(nameof(lexerIdentifier));
		    if (lexerIdentifier.GetKind() != CompilerSyntaxKind.LexerIdentifier) throw new ArgumentException(nameof(lexerIdentifier));
		    return (LexerRuleIdentifierSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleIdentifier((InternalSyntaxToken)lexerIdentifier.Node).CreateRed();
		}
		
		public ParserRuleIdentifierSyntax ParserRuleIdentifier(SyntaxToken parserIdentifier)
		{
		    if (parserIdentifier == null) throw new ArgumentNullException(nameof(parserIdentifier));
		    if (parserIdentifier.GetKind() != CompilerSyntaxKind.ParserIdentifier) throw new ArgumentException(nameof(parserIdentifier));
		    return (ParserRuleIdentifierSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleIdentifier((InternalSyntaxToken)parserIdentifier.Node).CreateRed();
		}
		
		public LexerRuleNameSyntax LexerRuleName(SyntaxToken lexerIdentifier)
		{
		    if (lexerIdentifier == null) throw new ArgumentNullException(nameof(lexerIdentifier));
		    if (lexerIdentifier.GetKind() != CompilerSyntaxKind.LexerIdentifier) throw new ArgumentException(nameof(lexerIdentifier));
		    return (LexerRuleNameSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleName((InternalSyntaxToken)lexerIdentifier.Node).CreateRed();
		}
		
		public ParserRuleNameSyntax ParserRuleName(SyntaxToken parserIdentifier)
		{
		    if (parserIdentifier == null) throw new ArgumentNullException(nameof(parserIdentifier));
		    if (parserIdentifier.GetKind() != CompilerSyntaxKind.ParserIdentifier) throw new ArgumentException(nameof(parserIdentifier));
		    return (ParserRuleNameSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleName((InternalSyntaxToken)parserIdentifier.Node).CreateRed();
		}
		
		public ElementNameSyntax ElementName(SyntaxToken elementName)
		{
		    if (elementName == null) throw new ArgumentNullException(nameof(elementName));
		    return (ElementNameSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ElementName((InternalSyntaxToken)elementName.Node).CreateRed();
		}
		
		public LiteralSyntax Literal(NullLiteralSyntax nullLiteral)
		{
		    if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
		    return (LiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.NullLiteralGreen)nullLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(BooleanLiteralSyntax booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (LiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(IntegerLiteralSyntax integerLiteral)
		{
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    return (LiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.IntegerLiteralGreen)integerLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(DecimalLiteralSyntax decimalLiteral)
		{
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
		    return (LiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.DecimalLiteralGreen)decimalLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(ScientificLiteralSyntax scientificLiteral)
		{
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
		    return (LiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.ScientificLiteralGreen)scientificLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (LiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral(SyntaxToken kNull)
		{
		    if (kNull == null) throw new ArgumentNullException(nameof(kNull));
		    if (kNull.GetKind() != CompilerSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
		    return (NullLiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.NullLiteral((InternalSyntaxToken)kNull.Node).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral()
		{
			return this.NullLiteral(this.Token(CompilerSyntaxKind.KNull));
		}
		
		public BooleanLiteralSyntax BooleanLiteral(SyntaxToken booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (BooleanLiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.BooleanLiteral((InternalSyntaxToken)booleanLiteral.Node).CreateRed();
		}
		
		public IntegerLiteralSyntax IntegerLiteral(SyntaxToken lInteger)
		{
		    if (lInteger == null) throw new ArgumentNullException(nameof(lInteger));
		    if (lInteger.GetKind() != CompilerSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
		    return (IntegerLiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.IntegerLiteral((InternalSyntaxToken)lInteger.Node).CreateRed();
		}
		
		public DecimalLiteralSyntax DecimalLiteral(SyntaxToken lDecimal)
		{
		    if (lDecimal == null) throw new ArgumentNullException(nameof(lDecimal));
		    if (lDecimal.GetKind() != CompilerSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
		    return (DecimalLiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.DecimalLiteral((InternalSyntaxToken)lDecimal.Node).CreateRed();
		}
		
		public ScientificLiteralSyntax ScientificLiteral(SyntaxToken lScientific)
		{
		    if (lScientific == null) throw new ArgumentNullException(nameof(lScientific));
		    if (lScientific.GetKind() != CompilerSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
		    return (ScientificLiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ScientificLiteral((InternalSyntaxToken)lScientific.Node).CreateRed();
		}
		
		public StringLiteralSyntax StringLiteral(SyntaxToken lString)
		{
		    if (lString == null) throw new ArgumentNullException(nameof(lString));
		    if (lString.GetKind() != CompilerSyntaxKind.LString) throw new ArgumentException(nameof(lString));
		    return (StringLiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.StringLiteral((InternalSyntaxToken)lString.Node).CreateRed();
		}
		
		public CharLiteralSyntax CharLiteral(SyntaxToken lCharacter)
		{
		    if (lCharacter == null) throw new ArgumentNullException(nameof(lCharacter));
		    if (lCharacter.GetKind() != CompilerSyntaxKind.LCharacter) throw new ArgumentException(nameof(lCharacter));
		    return (CharLiteralSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.CharLiteral((InternalSyntaxToken)lCharacter.Node).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(AnnotationSyntax),
				typeof(NamespaceDeclarationSyntax),
				typeof(NamespaceBodySyntax),
				typeof(GrammarDeclarationSyntax),
				typeof(UsingDeclarationSyntax),
				typeof(RuleDeclarationsSyntax),
				typeof(RuleDeclarationSyntax),
				typeof(ParserRuleDeclarationSyntax),
				typeof(ParserRuleAltSyntax),
				typeof(ParserRuleAltRefSyntax),
				typeof(ParserRuleSimpleSyntax),
				typeof(EofElementSyntax),
				typeof(ParserRuleNamedElementSyntax),
				typeof(AssignSyntax),
				typeof(MultiplicitySyntax),
				typeof(ParserNegatedElementSyntax),
				typeof(ParserRuleElementSyntax),
				typeof(ParserRuleFixedElementSyntax),
				typeof(ParserRuleWildcardElementSyntax),
				typeof(ParserRuleReferenceSyntax),
				typeof(ParserRuleBlockElementSyntax),
				typeof(LexerRuleDeclarationSyntax),
				typeof(LexerRuleAlternativeSyntax),
				typeof(LexerRuleAlternativeElementSyntax),
				typeof(LexerRuleElementSyntax),
				typeof(LexerRuleReferenceElementSyntax),
				typeof(LexerRuleWildcardElementSyntax),
				typeof(LexerRuleFixedStringElementSyntax),
				typeof(LexerRuleFixedCharElementSyntax),
				typeof(LexerRuleBlockElementSyntax),
				typeof(LexerRuleRangeElementSyntax),
				typeof(NameSyntax),
				typeof(QualifiedNameSyntax),
				typeof(QualifierSyntax),
				typeof(IdentifierSyntax),
				typeof(LexerRuleIdentifierSyntax),
				typeof(ParserRuleIdentifierSyntax),
				typeof(LexerRuleNameSyntax),
				typeof(ParserRuleNameSyntax),
				typeof(ElementNameSyntax),
				typeof(LiteralSyntax),
				typeof(NullLiteralSyntax),
				typeof(BooleanLiteralSyntax),
				typeof(IntegerLiteralSyntax),
				typeof(DecimalLiteralSyntax),
				typeof(ScientificLiteralSyntax),
				typeof(StringLiteralSyntax),
				typeof(CharLiteralSyntax),
			};
		}
	}
}

