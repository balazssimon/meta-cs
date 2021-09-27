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
	
	    public SyntaxToken KGrammar 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.GrammarDeclarationGreen)this.Green;
				var greenToken = green.KGrammar;
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
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.GrammarDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public RuleDeclarationsSyntax RuleDeclarations 
		{ 
			get { return this.GetRed(ref this.ruleDeclarations, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.ruleDeclarations, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.ruleDeclarations;
				default: return null;
	        }
	    }
	
	    public GrammarDeclarationSyntax WithKGrammar(SyntaxToken kGrammar)
		{
			return this.Update(KGrammar, this.Name, this.TSemicolon, this.RuleDeclarations);
		}
	
	    public GrammarDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KGrammar, Name, this.TSemicolon, this.RuleDeclarations);
		}
	
	    public GrammarDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KGrammar, this.Name, TSemicolon, this.RuleDeclarations);
		}
	
	    public GrammarDeclarationSyntax WithRuleDeclarations(RuleDeclarationsSyntax ruleDeclarations)
		{
			return this.Update(this.KGrammar, this.Name, this.TSemicolon, RuleDeclarations);
		}
	
	    public GrammarDeclarationSyntax Update(SyntaxToken kGrammar, NameSyntax name, SyntaxToken tSemicolon, RuleDeclarationsSyntax ruleDeclarations)
	    {
	        if (this.KGrammar != kGrammar ||
				this.Name != name ||
				this.TSemicolon != tSemicolon ||
				this.RuleDeclarations != ruleDeclarations)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.GrammarDeclaration(kGrammar, name, tSemicolon, ruleDeclarations);
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
	    private ParserRuleNameSyntax parserRuleName;
	    private QualifierSyntax qualifier;
	    private SyntaxNode parserRuleAlternative;
	
	    public ParserRuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ParserRuleNameSyntax ParserRuleName 
		{ 
			get { return this.GetRed(ref this.parserRuleName, 0); } 
		}
	    public SyntaxToken KDefines 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleDeclarationGreen)this.Green;
				var greenToken = green.KDefines;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public QualifierSyntax Qualifier 
		{ 
			get { return this.GetRed(ref this.qualifier, 2); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> ParserRuleAlternative 
		{ 
			get
			{
				var red = this.GetRed(ref this.parserRuleAlternative, 4);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax>(red, this.GetChildIndex(4));
				}
				return default;
			} 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.parserRuleName, 0);
				case 2: return this.GetRed(ref this.qualifier, 2);
				case 4: return this.GetRed(ref this.parserRuleAlternative, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.parserRuleName;
				case 2: return this.qualifier;
				case 4: return this.parserRuleAlternative;
				default: return null;
	        }
	    }
	
	    public ParserRuleDeclarationSyntax WithParserRuleName(ParserRuleNameSyntax parserRuleName)
		{
			return this.Update(ParserRuleName, this.KDefines, this.Qualifier, this.TColon, this.ParserRuleAlternative, this.TSemicolon);
		}
	
	    public ParserRuleDeclarationSyntax WithKDefines(SyntaxToken kDefines)
		{
			return this.Update(this.ParserRuleName, KDefines, this.Qualifier, this.TColon, this.ParserRuleAlternative, this.TSemicolon);
		}
	
	    public ParserRuleDeclarationSyntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(this.ParserRuleName, this.KDefines, Qualifier, this.TColon, this.ParserRuleAlternative, this.TSemicolon);
		}
	
	    public ParserRuleDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.ParserRuleName, this.KDefines, this.Qualifier, TColon, this.ParserRuleAlternative, this.TSemicolon);
		}
	
	    public ParserRuleDeclarationSyntax WithParserRuleAlternative(Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> parserRuleAlternative)
		{
			return this.Update(this.ParserRuleName, this.KDefines, this.Qualifier, this.TColon, ParserRuleAlternative, this.TSemicolon);
		}
	
	    public ParserRuleDeclarationSyntax AddParserRuleAlternative(params ParserRuleAlternativeSyntax[] parserRuleAlternative)
		{
			return this.WithParserRuleAlternative(this.ParserRuleAlternative.AddRange(parserRuleAlternative));
		}
	
	    public ParserRuleDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.ParserRuleName, this.KDefines, this.Qualifier, this.TColon, this.ParserRuleAlternative, TSemicolon);
		}
	
	    public ParserRuleDeclarationSyntax Update(ParserRuleNameSyntax parserRuleName, SyntaxToken kDefines, QualifierSyntax qualifier, SyntaxToken tColon, Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> parserRuleAlternative, SyntaxToken tSemicolon)
	    {
	        if (this.ParserRuleName != parserRuleName ||
				this.KDefines != kDefines ||
				this.Qualifier != qualifier ||
				this.TColon != tColon ||
				this.ParserRuleAlternative != parserRuleAlternative ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleDeclaration(parserRuleName, kDefines, qualifier, tColon, parserRuleAlternative, tSemicolon);
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
	
	public sealed class ParserRuleAlternativeSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode parserRuleAlternativeElement;
	    private EofElementSyntax eofElement;
	
	    public ParserRuleAlternativeSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleAlternativeSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Microsoft.CodeAnalysis.SyntaxList<ParserRuleAlternativeElementSyntax> ParserRuleAlternativeElement 
		{ 
			get
			{
				var red = this.GetRed(ref this.parserRuleAlternativeElement, 0);
				if (red != null) return new Microsoft.CodeAnalysis.SyntaxList<ParserRuleAlternativeElementSyntax>(red);
				return default;
			} 
		}
	    public EofElementSyntax EofElement 
		{ 
			get { return this.GetRed(ref this.eofElement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.parserRuleAlternativeElement, 0);
				case 1: return this.GetRed(ref this.eofElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.parserRuleAlternativeElement;
				case 1: return this.eofElement;
				default: return null;
	        }
	    }
	
	    public ParserRuleAlternativeSyntax WithParserRuleAlternativeElement(Microsoft.CodeAnalysis.SyntaxList<ParserRuleAlternativeElementSyntax> parserRuleAlternativeElement)
		{
			return this.Update(ParserRuleAlternativeElement, this.EofElement);
		}
	
	    public ParserRuleAlternativeSyntax AddParserRuleAlternativeElement(params ParserRuleAlternativeElementSyntax[] parserRuleAlternativeElement)
		{
			return this.WithParserRuleAlternativeElement(this.ParserRuleAlternativeElement.AddRange(parserRuleAlternativeElement));
		}
	
	    public ParserRuleAlternativeSyntax WithEofElement(EofElementSyntax eofElement)
		{
			return this.Update(this.ParserRuleAlternativeElement, EofElement);
		}
	
	    public ParserRuleAlternativeSyntax Update(Microsoft.CodeAnalysis.SyntaxList<ParserRuleAlternativeElementSyntax> parserRuleAlternativeElement, EofElementSyntax eofElement)
	    {
	        if (this.ParserRuleAlternativeElement != parserRuleAlternativeElement ||
				this.EofElement != eofElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleAlternative(parserRuleAlternativeElement, eofElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleAlternativeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleAlternative(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleAlternative(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleAlternative(this);
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
	
	public sealed class ParserRuleAlternativeElementSyntax : CompilerSyntaxNode
	{
	    private ParserMultiElementSyntax parserMultiElement;
	    private ParserNegatedElementSyntax parserNegatedElement;
	
	    public ParserRuleAlternativeElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleAlternativeElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ParserMultiElementSyntax ParserMultiElement 
		{ 
			get { return this.GetRed(ref this.parserMultiElement, 0); } 
		}
	    public ParserNegatedElementSyntax ParserNegatedElement 
		{ 
			get { return this.GetRed(ref this.parserNegatedElement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.parserMultiElement, 0);
				case 1: return this.GetRed(ref this.parserNegatedElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.parserMultiElement;
				case 1: return this.parserNegatedElement;
				default: return null;
	        }
	    }
	
	    public ParserRuleAlternativeElementSyntax WithParserMultiElement(ParserMultiElementSyntax parserMultiElement)
		{
			return this.Update(parserMultiElement);
		}
	
	    public ParserRuleAlternativeElementSyntax WithParserNegatedElement(ParserNegatedElementSyntax parserNegatedElement)
		{
			return this.Update(parserNegatedElement);
		}
	
	    public ParserRuleAlternativeElementSyntax Update(ParserMultiElementSyntax parserMultiElement)
	    {
	        if (this.ParserMultiElement != parserMultiElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleAlternativeElement(parserMultiElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleAlternativeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ParserRuleAlternativeElementSyntax Update(ParserNegatedElementSyntax parserNegatedElement)
	    {
	        if (this.ParserNegatedElement != parserNegatedElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleAlternativeElement(parserNegatedElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleAlternativeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleAlternativeElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleAlternativeElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleAlternativeElement(this);
	    }
	}
	
	public sealed class ParserMultiElementSyntax : CompilerSyntaxNode
	{
	    private ElementNameSyntax elementName;
	    private AssignSyntax assign;
	    private ParserRuleElementSyntax parserRuleElement;
	    private MultiplicitySyntax multiplicity;
	
	    public ParserMultiElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserMultiElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ElementNameSyntax ElementName 
		{ 
			get { return this.GetRed(ref this.elementName, 0); } 
		}
	    public AssignSyntax Assign 
		{ 
			get { return this.GetRed(ref this.assign, 1); } 
		}
	    public ParserRuleElementSyntax ParserRuleElement 
		{ 
			get { return this.GetRed(ref this.parserRuleElement, 2); } 
		}
	    public MultiplicitySyntax Multiplicity 
		{ 
			get { return this.GetRed(ref this.multiplicity, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.elementName, 0);
				case 1: return this.GetRed(ref this.assign, 1);
				case 2: return this.GetRed(ref this.parserRuleElement, 2);
				case 3: return this.GetRed(ref this.multiplicity, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.elementName;
				case 1: return this.assign;
				case 2: return this.parserRuleElement;
				case 3: return this.multiplicity;
				default: return null;
	        }
	    }
	
	    public ParserMultiElementSyntax WithElementName(ElementNameSyntax elementName)
		{
			return this.Update(ElementName, this.Assign, this.ParserRuleElement, this.Multiplicity);
		}
	
	    public ParserMultiElementSyntax WithAssign(AssignSyntax assign)
		{
			return this.Update(this.ElementName, Assign, this.ParserRuleElement, this.Multiplicity);
		}
	
	    public ParserMultiElementSyntax WithParserRuleElement(ParserRuleElementSyntax parserRuleElement)
		{
			return this.Update(this.ElementName, this.Assign, ParserRuleElement, this.Multiplicity);
		}
	
	    public ParserMultiElementSyntax WithMultiplicity(MultiplicitySyntax multiplicity)
		{
			return this.Update(this.ElementName, this.Assign, this.ParserRuleElement, Multiplicity);
		}
	
	    public ParserMultiElementSyntax Update(ElementNameSyntax elementName, AssignSyntax assign, ParserRuleElementSyntax parserRuleElement, MultiplicitySyntax multiplicity)
	    {
	        if (this.ElementName != elementName ||
				this.Assign != assign ||
				this.ParserRuleElement != parserRuleElement ||
				this.Multiplicity != multiplicity)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserMultiElement(elementName, assign, parserRuleElement, multiplicity);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserMultiElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserMultiElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserMultiElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserMultiElement(this);
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
	    private FixedElementSyntax fixedElement;
	    private ParserRuleReferenceSyntax parserRuleReference;
	    private ParserRuleBlockSyntax parserRuleBlock;
	
	    public ParserRuleElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public FixedElementSyntax FixedElement 
		{ 
			get { return this.GetRed(ref this.fixedElement, 0); } 
		}
	    public ParserRuleReferenceSyntax ParserRuleReference 
		{ 
			get { return this.GetRed(ref this.parserRuleReference, 1); } 
		}
	    public ParserRuleBlockSyntax ParserRuleBlock 
		{ 
			get { return this.GetRed(ref this.parserRuleBlock, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.fixedElement, 0);
				case 1: return this.GetRed(ref this.parserRuleReference, 1);
				case 2: return this.GetRed(ref this.parserRuleBlock, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.fixedElement;
				case 1: return this.parserRuleReference;
				case 2: return this.parserRuleBlock;
				default: return null;
	        }
	    }
	
	    public ParserRuleElementSyntax WithFixedElement(FixedElementSyntax fixedElement)
		{
			return this.Update(fixedElement);
		}
	
	    public ParserRuleElementSyntax WithParserRuleReference(ParserRuleReferenceSyntax parserRuleReference)
		{
			return this.Update(parserRuleReference);
		}
	
	    public ParserRuleElementSyntax WithParserRuleBlock(ParserRuleBlockSyntax parserRuleBlock)
		{
			return this.Update(parserRuleBlock);
		}
	
	    public ParserRuleElementSyntax Update(FixedElementSyntax fixedElement)
	    {
	        if (this.FixedElement != fixedElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleElement(fixedElement);
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
	
	    public ParserRuleElementSyntax Update(ParserRuleBlockSyntax parserRuleBlock)
	    {
	        if (this.ParserRuleBlock != parserRuleBlock)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleElement(parserRuleBlock);
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
	
	public sealed class FixedElementSyntax : CompilerSyntaxNode
	{
	    private StringLiteralSyntax stringLiteral;
	
	    public FixedElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FixedElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
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
	
	    public FixedElementSyntax WithStringLiteral(StringLiteralSyntax stringLiteral)
		{
			return this.Update(StringLiteral);
		}
	
	    public FixedElementSyntax Update(StringLiteralSyntax stringLiteral)
	    {
	        if (this.StringLiteral != stringLiteral)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.FixedElement(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FixedElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFixedElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFixedElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitFixedElement(this);
	    }
	}
	
	public sealed class ParserRuleReferenceSyntax : CompilerSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public ParserRuleReferenceSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleReferenceSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
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
	
	    public ParserRuleReferenceSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public ParserRuleReferenceSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleReference(identifier);
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
	
	public sealed class ParserRuleBlockSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode parserRuleAlternative;
	
	    public ParserRuleBlockSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParserRuleBlockSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleBlockGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> ParserRuleAlternative 
		{ 
			get
			{
				var red = this.GetRed(ref this.parserRuleAlternative, 1);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ParserRuleBlockGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.parserRuleAlternative, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.parserRuleAlternative;
				default: return null;
	        }
	    }
	
	    public ParserRuleBlockSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.ParserRuleAlternative, this.TCloseParen);
		}
	
	    public ParserRuleBlockSyntax WithParserRuleAlternative(Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> parserRuleAlternative)
		{
			return this.Update(this.TOpenParen, ParserRuleAlternative, this.TCloseParen);
		}
	
	    public ParserRuleBlockSyntax AddParserRuleAlternative(params ParserRuleAlternativeSyntax[] parserRuleAlternative)
		{
			return this.WithParserRuleAlternative(this.ParserRuleAlternative.AddRange(parserRuleAlternative));
		}
	
	    public ParserRuleBlockSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.ParserRuleAlternative, TCloseParen);
		}
	
	    public ParserRuleBlockSyntax Update(SyntaxToken tOpenParen, Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> parserRuleAlternative, SyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.ParserRuleAlternative != parserRuleAlternative ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ParserRuleBlock(tOpenParen, parserRuleAlternative, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParserRuleBlockSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParserRuleBlock(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParserRuleBlock(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitParserRuleBlock(this);
	    }
	}
	
	public sealed class LexerRuleDeclarationSyntax : CompilerSyntaxNode
	{
	    private LexerRuleNameSyntax lexerRuleName;
	    private SyntaxNode lexerRuleAlternative;
	
	    public LexerRuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleDeclarationSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Modifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleDeclarationGreen)this.Green;
				var greenToken = green.Modifier;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public LexerRuleNameSyntax LexerRuleName 
		{ 
			get { return this.GetRed(ref this.lexerRuleName, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> LexerRuleAlternative 
		{ 
			get
			{
				var red = this.GetRed(ref this.lexerRuleAlternative, 3);
				if (red != null)
				{
					return new Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax>(red, this.GetChildIndex(3));
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
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.lexerRuleName, 1);
				case 3: return this.GetRed(ref this.lexerRuleAlternative, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.lexerRuleName;
				case 3: return this.lexerRuleAlternative;
				default: return null;
	        }
	    }
	
	    public LexerRuleDeclarationSyntax WithModifier(SyntaxToken modifier)
		{
			return this.Update(Modifier, this.LexerRuleName, this.TColon, this.LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax WithLexerRuleName(LexerRuleNameSyntax lexerRuleName)
		{
			return this.Update(this.Modifier, LexerRuleName, this.TColon, this.LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Modifier, this.LexerRuleName, TColon, this.LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax WithLexerRuleAlternative(Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative)
		{
			return this.Update(this.Modifier, this.LexerRuleName, this.TColon, LexerRuleAlternative, this.TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax AddLexerRuleAlternative(params LexerRuleAlternativeSyntax[] lexerRuleAlternative)
		{
			return this.WithLexerRuleAlternative(this.LexerRuleAlternative.AddRange(lexerRuleAlternative));
		}
	
	    public LexerRuleDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Modifier, this.LexerRuleName, this.TColon, this.LexerRuleAlternative, TSemicolon);
		}
	
	    public LexerRuleDeclarationSyntax Update(SyntaxToken modifier, LexerRuleNameSyntax lexerRuleName, SyntaxToken tColon, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative, SyntaxToken tSemicolon)
	    {
	        if (this.Modifier != modifier ||
				this.LexerRuleName != lexerRuleName ||
				this.TColon != tColon ||
				this.LexerRuleAlternative != lexerRuleAlternative ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleDeclaration(modifier, lexerRuleName, tColon, lexerRuleAlternative, tSemicolon);
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
	    private LexerMultiElementSyntax lexerMultiElement;
	    private LexerNegatedElementSyntax lexerNegatedElement;
	    private LexerRangeElementSyntax lexerRangeElement;
	
	    public LexerRuleAlternativeElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleAlternativeElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LexerMultiElementSyntax LexerMultiElement 
		{ 
			get { return this.GetRed(ref this.lexerMultiElement, 0); } 
		}
	    public LexerNegatedElementSyntax LexerNegatedElement 
		{ 
			get { return this.GetRed(ref this.lexerNegatedElement, 1); } 
		}
	    public LexerRangeElementSyntax LexerRangeElement 
		{ 
			get { return this.GetRed(ref this.lexerRangeElement, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.lexerMultiElement, 0);
				case 1: return this.GetRed(ref this.lexerNegatedElement, 1);
				case 2: return this.GetRed(ref this.lexerRangeElement, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.lexerMultiElement;
				case 1: return this.lexerNegatedElement;
				case 2: return this.lexerRangeElement;
				default: return null;
	        }
	    }
	
	    public LexerRuleAlternativeElementSyntax WithLexerMultiElement(LexerMultiElementSyntax lexerMultiElement)
		{
			return this.Update(lexerMultiElement);
		}
	
	    public LexerRuleAlternativeElementSyntax WithLexerNegatedElement(LexerNegatedElementSyntax lexerNegatedElement)
		{
			return this.Update(lexerNegatedElement);
		}
	
	    public LexerRuleAlternativeElementSyntax WithLexerRangeElement(LexerRangeElementSyntax lexerRangeElement)
		{
			return this.Update(lexerRangeElement);
		}
	
	    public LexerRuleAlternativeElementSyntax Update(LexerMultiElementSyntax lexerMultiElement)
	    {
	        if (this.LexerMultiElement != lexerMultiElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleAlternativeElement(lexerMultiElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleAlternativeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleAlternativeElementSyntax Update(LexerNegatedElementSyntax lexerNegatedElement)
	    {
	        if (this.LexerNegatedElement != lexerNegatedElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleAlternativeElement(lexerNegatedElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleAlternativeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleAlternativeElementSyntax Update(LexerRangeElementSyntax lexerRangeElement)
	    {
	        if (this.LexerRangeElement != lexerRangeElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleAlternativeElement(lexerRangeElement);
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
	
	public sealed class LexerMultiElementSyntax : CompilerSyntaxNode
	{
	    private LexerRuleElementSyntax lexerRuleElement;
	    private MultiplicitySyntax multiplicity;
	
	    public LexerMultiElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerMultiElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LexerRuleElementSyntax LexerRuleElement 
		{ 
			get { return this.GetRed(ref this.lexerRuleElement, 0); } 
		}
	    public MultiplicitySyntax Multiplicity 
		{ 
			get { return this.GetRed(ref this.multiplicity, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.lexerRuleElement, 0);
				case 1: return this.GetRed(ref this.multiplicity, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.lexerRuleElement;
				case 1: return this.multiplicity;
				default: return null;
	        }
	    }
	
	    public LexerMultiElementSyntax WithLexerRuleElement(LexerRuleElementSyntax lexerRuleElement)
		{
			return this.Update(LexerRuleElement, this.Multiplicity);
		}
	
	    public LexerMultiElementSyntax WithMultiplicity(MultiplicitySyntax multiplicity)
		{
			return this.Update(this.LexerRuleElement, Multiplicity);
		}
	
	    public LexerMultiElementSyntax Update(LexerRuleElementSyntax lexerRuleElement, MultiplicitySyntax multiplicity)
	    {
	        if (this.LexerRuleElement != lexerRuleElement ||
				this.Multiplicity != multiplicity)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerMultiElement(lexerRuleElement, multiplicity);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerMultiElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerMultiElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerMultiElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerMultiElement(this);
	    }
	}
	
	public sealed class LexerNegatedElementSyntax : CompilerSyntaxNode
	{
	    private LexerRuleElementSyntax lexerRuleElement;
	
	    public LexerNegatedElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerNegatedElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TNegate 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerNegatedElementGreen)this.Green;
				var greenToken = green.TNegate;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public LexerRuleElementSyntax LexerRuleElement 
		{ 
			get { return this.GetRed(ref this.lexerRuleElement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.lexerRuleElement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.lexerRuleElement;
				default: return null;
	        }
	    }
	
	    public LexerNegatedElementSyntax WithTNegate(SyntaxToken tNegate)
		{
			return this.Update(TNegate, this.LexerRuleElement);
		}
	
	    public LexerNegatedElementSyntax WithLexerRuleElement(LexerRuleElementSyntax lexerRuleElement)
		{
			return this.Update(this.TNegate, LexerRuleElement);
		}
	
	    public LexerNegatedElementSyntax Update(SyntaxToken tNegate, LexerRuleElementSyntax lexerRuleElement)
	    {
	        if (this.TNegate != tNegate ||
				this.LexerRuleElement != lexerRuleElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerNegatedElement(tNegate, lexerRuleElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerNegatedElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerNegatedElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerNegatedElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerNegatedElement(this);
	    }
	}
	
	public sealed class LexerRangeElementSyntax : CompilerSyntaxNode
	{
	    private FixedElementSyntax start;
	    private FixedElementSyntax end;
	
	    public LexerRangeElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRangeElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public FixedElementSyntax Start 
		{ 
			get { return this.GetRed(ref this.start, 0); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRangeElementGreen)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public FixedElementSyntax End 
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
	
	    public LexerRangeElementSyntax WithStart(FixedElementSyntax start)
		{
			return this.Update(Start, this.TArrow, this.End);
		}
	
	    public LexerRangeElementSyntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.Start, TArrow, this.End);
		}
	
	    public LexerRangeElementSyntax WithEnd(FixedElementSyntax end)
		{
			return this.Update(this.Start, this.TArrow, End);
		}
	
	    public LexerRangeElementSyntax Update(FixedElementSyntax start, SyntaxToken tArrow, FixedElementSyntax end)
	    {
	        if (this.Start != start ||
				this.TArrow != tArrow ||
				this.End != end)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRangeElement(start, tArrow, end);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRangeElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRangeElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRangeElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRangeElement(this);
	    }
	}
	
	public sealed class LexerRuleElementSyntax : CompilerSyntaxNode
	{
	    private FixedElementSyntax fixedElement;
	    private WildcardElementSyntax wildcardElement;
	    private LexerRuleReferenceSyntax lexerRuleReference;
	    private LexerRuleBlockSyntax lexerRuleBlock;
	
	    public LexerRuleElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public FixedElementSyntax FixedElement 
		{ 
			get { return this.GetRed(ref this.fixedElement, 0); } 
		}
	    public WildcardElementSyntax WildcardElement 
		{ 
			get { return this.GetRed(ref this.wildcardElement, 1); } 
		}
	    public LexerRuleReferenceSyntax LexerRuleReference 
		{ 
			get { return this.GetRed(ref this.lexerRuleReference, 2); } 
		}
	    public LexerRuleBlockSyntax LexerRuleBlock 
		{ 
			get { return this.GetRed(ref this.lexerRuleBlock, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.fixedElement, 0);
				case 1: return this.GetRed(ref this.wildcardElement, 1);
				case 2: return this.GetRed(ref this.lexerRuleReference, 2);
				case 3: return this.GetRed(ref this.lexerRuleBlock, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.fixedElement;
				case 1: return this.wildcardElement;
				case 2: return this.lexerRuleReference;
				case 3: return this.lexerRuleBlock;
				default: return null;
	        }
	    }
	
	    public LexerRuleElementSyntax WithFixedElement(FixedElementSyntax fixedElement)
		{
			return this.Update(fixedElement);
		}
	
	    public LexerRuleElementSyntax WithWildcardElement(WildcardElementSyntax wildcardElement)
		{
			return this.Update(wildcardElement);
		}
	
	    public LexerRuleElementSyntax WithLexerRuleReference(LexerRuleReferenceSyntax lexerRuleReference)
		{
			return this.Update(lexerRuleReference);
		}
	
	    public LexerRuleElementSyntax WithLexerRuleBlock(LexerRuleBlockSyntax lexerRuleBlock)
		{
			return this.Update(lexerRuleBlock);
		}
	
	    public LexerRuleElementSyntax Update(FixedElementSyntax fixedElement)
	    {
	        if (this.FixedElement != fixedElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(fixedElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementSyntax Update(WildcardElementSyntax wildcardElement)
	    {
	        if (this.WildcardElement != wildcardElement)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(wildcardElement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementSyntax Update(LexerRuleReferenceSyntax lexerRuleReference)
	    {
	        if (this.LexerRuleReference != lexerRuleReference)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(lexerRuleReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LexerRuleElementSyntax Update(LexerRuleBlockSyntax lexerRuleBlock)
	    {
	        if (this.LexerRuleBlock != lexerRuleBlock)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleElement(lexerRuleBlock);
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
	
	public sealed class WildcardElementSyntax : CompilerSyntaxNode
	{
	
	    public WildcardElementSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WildcardElementSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TDot 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.WildcardElementGreen)this.Green;
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
	
	    public WildcardElementSyntax WithTDot(SyntaxToken tDot)
		{
			return this.Update(TDot);
		}
	
	    public WildcardElementSyntax Update(SyntaxToken tDot)
	    {
	        if (this.TDot != tDot)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.WildcardElement(tDot);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WildcardElementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWildcardElement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWildcardElement(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitWildcardElement(this);
	    }
	}
	
	public sealed class LexerRuleReferenceSyntax : CompilerSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public LexerRuleReferenceSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleReferenceSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
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
	
	    public LexerRuleReferenceSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public LexerRuleReferenceSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleReference(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleReference(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleReference(this);
	    }
	}
	
	public sealed class LexerRuleBlockSyntax : CompilerSyntaxNode
	{
	    private SyntaxNode lexerRuleAlternative;
	
	    public LexerRuleBlockSyntax(InternalSyntaxNode green, CompilerSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LexerRuleBlockSyntax(InternalSyntaxNode green, CompilerSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleBlockGreen)this.Green;
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
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.LexerRuleBlockGreen)this.Green;
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
	
	    public LexerRuleBlockSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.LexerRuleAlternative, this.TCloseParen);
		}
	
	    public LexerRuleBlockSyntax WithLexerRuleAlternative(Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative)
		{
			return this.Update(this.TOpenParen, LexerRuleAlternative, this.TCloseParen);
		}
	
	    public LexerRuleBlockSyntax AddLexerRuleAlternative(params LexerRuleAlternativeSyntax[] lexerRuleAlternative)
		{
			return this.WithLexerRuleAlternative(this.LexerRuleAlternative.AddRange(lexerRuleAlternative));
		}
	
	    public LexerRuleBlockSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.LexerRuleAlternative, TCloseParen);
		}
	
	    public LexerRuleBlockSyntax Update(SyntaxToken tOpenParen, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative, SyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.LexerRuleAlternative != lexerRuleAlternative ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.LexerRuleBlock(tOpenParen, lexerRuleAlternative, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LexerRuleBlockSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ICompilerSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLexerRuleBlock(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ICompilerSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLexerRuleBlock(this);
	    }
	
	    public override void Accept(ICompilerSyntaxVisitor visitor)
	    {
	        visitor.VisitLexerRuleBlock(this);
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
	
	    public SyntaxToken LexerIdentifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.Languages.Compiler.Syntax.InternalSyntax.ElementNameGreen)this.Green;
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
	
	    public ElementNameSyntax WithLexerIdentifier(SyntaxToken lexerIdentifier)
		{
			return this.Update(LexerIdentifier);
		}
	
	    public ElementNameSyntax Update(SyntaxToken lexerIdentifier)
	    {
	        if (this.LexerIdentifier != lexerIdentifier)
	        {
	            var newNode = CompilerLanguage.Instance.SyntaxFactory.ElementName(lexerIdentifier);
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
		
		void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		void VisitNamespaceBody(NamespaceBodySyntax node);
		
		void VisitGrammarDeclaration(GrammarDeclarationSyntax node);
		
		void VisitUsingDeclaration(UsingDeclarationSyntax node);
		
		void VisitRuleDeclarations(RuleDeclarationsSyntax node);
		
		void VisitRuleDeclaration(RuleDeclarationSyntax node);
		
		void VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node);
		
		void VisitParserRuleAlternative(ParserRuleAlternativeSyntax node);
		
		void VisitEofElement(EofElementSyntax node);
		
		void VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax node);
		
		void VisitParserMultiElement(ParserMultiElementSyntax node);
		
		void VisitAssign(AssignSyntax node);
		
		void VisitMultiplicity(MultiplicitySyntax node);
		
		void VisitParserNegatedElement(ParserNegatedElementSyntax node);
		
		void VisitParserRuleElement(ParserRuleElementSyntax node);
		
		void VisitFixedElement(FixedElementSyntax node);
		
		void VisitParserRuleReference(ParserRuleReferenceSyntax node);
		
		void VisitParserRuleBlock(ParserRuleBlockSyntax node);
		
		void VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node);
		
		void VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node);
		
		void VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node);
		
		void VisitLexerMultiElement(LexerMultiElementSyntax node);
		
		void VisitLexerNegatedElement(LexerNegatedElementSyntax node);
		
		void VisitLexerRangeElement(LexerRangeElementSyntax node);
		
		void VisitLexerRuleElement(LexerRuleElementSyntax node);
		
		void VisitWildcardElement(WildcardElementSyntax node);
		
		void VisitLexerRuleReference(LexerRuleReferenceSyntax node);
		
		void VisitLexerRuleBlock(LexerRuleBlockSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
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
		
		public virtual void VisitParserRuleAlternative(ParserRuleAlternativeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEofElement(EofElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserMultiElement(ParserMultiElementSyntax node)
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
		
		public virtual void VisitFixedElement(FixedElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleReference(ParserRuleReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParserRuleBlock(ParserRuleBlockSyntax node)
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
		
		public virtual void VisitLexerMultiElement(LexerMultiElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerNegatedElement(LexerNegatedElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRangeElement(LexerRangeElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleElement(LexerRuleElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWildcardElement(WildcardElementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleReference(LexerRuleReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLexerRuleBlock(LexerRuleBlockSyntax node)
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
	}

	//GenerateDetailedSyntaxVisitor()

	public interface ICompilerSyntaxVisitor<TArg, TResult> 
	{
	    TResult VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node, TArg argument);
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node, TArg argument);
		
		TResult VisitGrammarDeclaration(GrammarDeclarationSyntax node, TArg argument);
		
		TResult VisitUsingDeclaration(UsingDeclarationSyntax node, TArg argument);
		
		TResult VisitRuleDeclarations(RuleDeclarationsSyntax node, TArg argument);
		
		TResult VisitRuleDeclaration(RuleDeclarationSyntax node, TArg argument);
		
		TResult VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node, TArg argument);
		
		TResult VisitParserRuleAlternative(ParserRuleAlternativeSyntax node, TArg argument);
		
		TResult VisitEofElement(EofElementSyntax node, TArg argument);
		
		TResult VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax node, TArg argument);
		
		TResult VisitParserMultiElement(ParserMultiElementSyntax node, TArg argument);
		
		TResult VisitAssign(AssignSyntax node, TArg argument);
		
		TResult VisitMultiplicity(MultiplicitySyntax node, TArg argument);
		
		TResult VisitParserNegatedElement(ParserNegatedElementSyntax node, TArg argument);
		
		TResult VisitParserRuleElement(ParserRuleElementSyntax node, TArg argument);
		
		TResult VisitFixedElement(FixedElementSyntax node, TArg argument);
		
		TResult VisitParserRuleReference(ParserRuleReferenceSyntax node, TArg argument);
		
		TResult VisitParserRuleBlock(ParserRuleBlockSyntax node, TArg argument);
		
		TResult VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node, TArg argument);
		
		TResult VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node, TArg argument);
		
		TResult VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node, TArg argument);
		
		TResult VisitLexerMultiElement(LexerMultiElementSyntax node, TArg argument);
		
		TResult VisitLexerNegatedElement(LexerNegatedElementSyntax node, TArg argument);
		
		TResult VisitLexerRangeElement(LexerRangeElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleElement(LexerRuleElementSyntax node, TArg argument);
		
		TResult VisitWildcardElement(WildcardElementSyntax node, TArg argument);
		
		TResult VisitLexerRuleReference(LexerRuleReferenceSyntax node, TArg argument);
		
		TResult VisitLexerRuleBlock(LexerRuleBlockSyntax node, TArg argument);
		
		TResult VisitName(NameSyntax node, TArg argument);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument);
		
		TResult VisitQualifier(QualifierSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
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
		
		public virtual TResult VisitParserRuleAlternative(ParserRuleAlternativeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEofElement(EofElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserMultiElement(ParserMultiElementSyntax node, TArg argument)
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
		
		public virtual TResult VisitFixedElement(FixedElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleReference(ParserRuleReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParserRuleBlock(ParserRuleBlockSyntax node, TArg argument)
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
		
		public virtual TResult VisitLexerMultiElement(LexerMultiElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerNegatedElement(LexerNegatedElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRangeElement(LexerRangeElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleElement(LexerRuleElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWildcardElement(WildcardElementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleReference(LexerRuleReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLexerRuleBlock(LexerRuleBlockSyntax node, TArg argument)
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
	}

	public interface ICompilerSyntaxVisitor<TResult> 
	{
	    TResult VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node);
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		TResult VisitNamespaceBody(NamespaceBodySyntax node);
		
		TResult VisitGrammarDeclaration(GrammarDeclarationSyntax node);
		
		TResult VisitUsingDeclaration(UsingDeclarationSyntax node);
		
		TResult VisitRuleDeclarations(RuleDeclarationsSyntax node);
		
		TResult VisitRuleDeclaration(RuleDeclarationSyntax node);
		
		TResult VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node);
		
		TResult VisitParserRuleAlternative(ParserRuleAlternativeSyntax node);
		
		TResult VisitEofElement(EofElementSyntax node);
		
		TResult VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax node);
		
		TResult VisitParserMultiElement(ParserMultiElementSyntax node);
		
		TResult VisitAssign(AssignSyntax node);
		
		TResult VisitMultiplicity(MultiplicitySyntax node);
		
		TResult VisitParserNegatedElement(ParserNegatedElementSyntax node);
		
		TResult VisitParserRuleElement(ParserRuleElementSyntax node);
		
		TResult VisitFixedElement(FixedElementSyntax node);
		
		TResult VisitParserRuleReference(ParserRuleReferenceSyntax node);
		
		TResult VisitParserRuleBlock(ParserRuleBlockSyntax node);
		
		TResult VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node);
		
		TResult VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node);
		
		TResult VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node);
		
		TResult VisitLexerMultiElement(LexerMultiElementSyntax node);
		
		TResult VisitLexerNegatedElement(LexerNegatedElementSyntax node);
		
		TResult VisitLexerRangeElement(LexerRangeElementSyntax node);
		
		TResult VisitLexerRuleElement(LexerRuleElementSyntax node);
		
		TResult VisitWildcardElement(WildcardElementSyntax node);
		
		TResult VisitLexerRuleReference(LexerRuleReferenceSyntax node);
		
		TResult VisitLexerRuleBlock(LexerRuleBlockSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
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
		
		public virtual TResult VisitParserRuleAlternative(ParserRuleAlternativeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEofElement(EofElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserMultiElement(ParserMultiElementSyntax node)
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
		
		public virtual TResult VisitFixedElement(FixedElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleReference(ParserRuleReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParserRuleBlock(ParserRuleBlockSyntax node)
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
		
		public virtual TResult VisitLexerMultiElement(LexerMultiElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerNegatedElement(LexerNegatedElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRangeElement(LexerRangeElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleElement(LexerRuleElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWildcardElement(WildcardElementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleReference(LexerRuleReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLexerRuleBlock(LexerRuleBlockSyntax node)
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
		    var kGrammar = this.VisitToken(node.KGrammar);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var ruleDeclarations = (RuleDeclarationsSyntax)this.Visit(node.RuleDeclarations);
			return node.Update(kGrammar, name, tSemicolon, ruleDeclarations);
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
		    var parserRuleName = (ParserRuleNameSyntax)this.Visit(node.ParserRuleName);
		    var kDefines = this.VisitToken(node.KDefines);
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
		    var tColon = this.VisitToken(node.TColon);
		    var parserRuleAlternative = this.VisitList(node.ParserRuleAlternative);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(parserRuleName, kDefines, qualifier, tColon, parserRuleAlternative, tSemicolon);
		}
		
		public virtual SyntaxNode VisitParserRuleAlternative(ParserRuleAlternativeSyntax node)
		{
		    var parserRuleAlternativeElement = this.VisitList(node.ParserRuleAlternativeElement);
		    var eofElement = (EofElementSyntax)this.Visit(node.EofElement);
			return node.Update(parserRuleAlternativeElement, eofElement);
		}
		
		public virtual SyntaxNode VisitEofElement(EofElementSyntax node)
		{
		    var kEof = this.VisitToken(node.KEof);
			return node.Update(kEof);
		}
		
		public virtual SyntaxNode VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax node)
		{
			var oldParserMultiElement = node.ParserMultiElement;
			if (oldParserMultiElement != null)
			{
			    var newParserMultiElement = (ParserMultiElementSyntax)this.Visit(oldParserMultiElement);
				return node.Update(newParserMultiElement);
			}
			var oldParserNegatedElement = node.ParserNegatedElement;
			if (oldParserNegatedElement != null)
			{
			    var newParserNegatedElement = (ParserNegatedElementSyntax)this.Visit(oldParserNegatedElement);
				return node.Update(newParserNegatedElement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitParserMultiElement(ParserMultiElementSyntax node)
		{
		    var elementName = (ElementNameSyntax)this.Visit(node.ElementName);
		    var assign = (AssignSyntax)this.Visit(node.Assign);
		    var parserRuleElement = (ParserRuleElementSyntax)this.Visit(node.ParserRuleElement);
		    var multiplicity = (MultiplicitySyntax)this.Visit(node.Multiplicity);
			return node.Update(elementName, assign, parserRuleElement, multiplicity);
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
			var oldFixedElement = node.FixedElement;
			if (oldFixedElement != null)
			{
			    var newFixedElement = (FixedElementSyntax)this.Visit(oldFixedElement);
				return node.Update(newFixedElement);
			}
			var oldParserRuleReference = node.ParserRuleReference;
			if (oldParserRuleReference != null)
			{
			    var newParserRuleReference = (ParserRuleReferenceSyntax)this.Visit(oldParserRuleReference);
				return node.Update(newParserRuleReference);
			}
			var oldParserRuleBlock = node.ParserRuleBlock;
			if (oldParserRuleBlock != null)
			{
			    var newParserRuleBlock = (ParserRuleBlockSyntax)this.Visit(oldParserRuleBlock);
				return node.Update(newParserRuleBlock);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitFixedElement(FixedElementSyntax node)
		{
		    var stringLiteral = (StringLiteralSyntax)this.Visit(node.StringLiteral);
			return node.Update(stringLiteral);
		}
		
		public virtual SyntaxNode VisitParserRuleReference(ParserRuleReferenceSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitParserRuleBlock(ParserRuleBlockSyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var parserRuleAlternative = this.VisitList(node.ParserRuleAlternative);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(tOpenParen, parserRuleAlternative, tCloseParen);
		}
		
		public virtual SyntaxNode VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node)
		{
		    var modifier = this.VisitToken(node.Modifier);
		    var lexerRuleName = (LexerRuleNameSyntax)this.Visit(node.LexerRuleName);
		    var tColon = this.VisitToken(node.TColon);
		    var lexerRuleAlternative = this.VisitList(node.LexerRuleAlternative);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(modifier, lexerRuleName, tColon, lexerRuleAlternative, tSemicolon);
		}
		
		public virtual SyntaxNode VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node)
		{
		    var lexerRuleAlternativeElement = this.VisitList(node.LexerRuleAlternativeElement);
			return node.Update(lexerRuleAlternativeElement);
		}
		
		public virtual SyntaxNode VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node)
		{
			var oldLexerMultiElement = node.LexerMultiElement;
			if (oldLexerMultiElement != null)
			{
			    var newLexerMultiElement = (LexerMultiElementSyntax)this.Visit(oldLexerMultiElement);
				return node.Update(newLexerMultiElement);
			}
			var oldLexerNegatedElement = node.LexerNegatedElement;
			if (oldLexerNegatedElement != null)
			{
			    var newLexerNegatedElement = (LexerNegatedElementSyntax)this.Visit(oldLexerNegatedElement);
				return node.Update(newLexerNegatedElement);
			}
			var oldLexerRangeElement = node.LexerRangeElement;
			if (oldLexerRangeElement != null)
			{
			    var newLexerRangeElement = (LexerRangeElementSyntax)this.Visit(oldLexerRangeElement);
				return node.Update(newLexerRangeElement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitLexerMultiElement(LexerMultiElementSyntax node)
		{
		    var lexerRuleElement = (LexerRuleElementSyntax)this.Visit(node.LexerRuleElement);
		    var multiplicity = (MultiplicitySyntax)this.Visit(node.Multiplicity);
			return node.Update(lexerRuleElement, multiplicity);
		}
		
		public virtual SyntaxNode VisitLexerNegatedElement(LexerNegatedElementSyntax node)
		{
		    var tNegate = this.VisitToken(node.TNegate);
		    var lexerRuleElement = (LexerRuleElementSyntax)this.Visit(node.LexerRuleElement);
			return node.Update(tNegate, lexerRuleElement);
		}
		
		public virtual SyntaxNode VisitLexerRangeElement(LexerRangeElementSyntax node)
		{
		    var start = (FixedElementSyntax)this.Visit(node.Start);
		    var tArrow = this.VisitToken(node.TArrow);
		    var end = (FixedElementSyntax)this.Visit(node.End);
			return node.Update(start, tArrow, end);
		}
		
		public virtual SyntaxNode VisitLexerRuleElement(LexerRuleElementSyntax node)
		{
			var oldFixedElement = node.FixedElement;
			if (oldFixedElement != null)
			{
			    var newFixedElement = (FixedElementSyntax)this.Visit(oldFixedElement);
				return node.Update(newFixedElement);
			}
			var oldWildcardElement = node.WildcardElement;
			if (oldWildcardElement != null)
			{
			    var newWildcardElement = (WildcardElementSyntax)this.Visit(oldWildcardElement);
				return node.Update(newWildcardElement);
			}
			var oldLexerRuleReference = node.LexerRuleReference;
			if (oldLexerRuleReference != null)
			{
			    var newLexerRuleReference = (LexerRuleReferenceSyntax)this.Visit(oldLexerRuleReference);
				return node.Update(newLexerRuleReference);
			}
			var oldLexerRuleBlock = node.LexerRuleBlock;
			if (oldLexerRuleBlock != null)
			{
			    var newLexerRuleBlock = (LexerRuleBlockSyntax)this.Visit(oldLexerRuleBlock);
				return node.Update(newLexerRuleBlock);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitWildcardElement(WildcardElementSyntax node)
		{
		    var tDot = this.VisitToken(node.TDot);
			return node.Update(tDot);
		}
		
		public virtual SyntaxNode VisitLexerRuleReference(LexerRuleReferenceSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitLexerRuleBlock(LexerRuleBlockSyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var lexerRuleAlternative = this.VisitList(node.LexerRuleAlternative);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(tOpenParen, lexerRuleAlternative, tCloseParen);
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
		    var lexerIdentifier = this.VisitToken(node.LexerIdentifier);
			return node.Update(lexerIdentifier);
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
		
		public GrammarDeclarationSyntax GrammarDeclaration(SyntaxToken kGrammar, NameSyntax name, SyntaxToken tSemicolon, RuleDeclarationsSyntax ruleDeclarations)
		{
		    if (kGrammar == null) throw new ArgumentNullException(nameof(kGrammar));
		    if (kGrammar.GetKind() != CompilerSyntaxKind.KGrammar) throw new ArgumentException(nameof(kGrammar));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    if (ruleDeclarations == null) throw new ArgumentNullException(nameof(ruleDeclarations));
		    return (GrammarDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.GrammarDeclaration((InternalSyntaxToken)kGrammar.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node, (Syntax.InternalSyntax.RuleDeclarationsGreen)ruleDeclarations.Green).CreateRed();
		}
		
		public GrammarDeclarationSyntax GrammarDeclaration(NameSyntax name, RuleDeclarationsSyntax ruleDeclarations)
		{
			return this.GrammarDeclaration(this.Token(CompilerSyntaxKind.KGrammar), name, this.Token(CompilerSyntaxKind.TSemicolon), ruleDeclarations);
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
		
		public ParserRuleDeclarationSyntax ParserRuleDeclaration(ParserRuleNameSyntax parserRuleName, SyntaxToken kDefines, QualifierSyntax qualifier, SyntaxToken tColon, Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> parserRuleAlternative, SyntaxToken tSemicolon)
		{
		    if (parserRuleName == null) throw new ArgumentNullException(nameof(parserRuleName));
		    if (kDefines != null && kDefines.GetKind() != CompilerSyntaxKind.KDefines) throw new ArgumentException(nameof(kDefines));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != CompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (parserRuleAlternative == null) throw new ArgumentNullException(nameof(parserRuleAlternative));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ParserRuleDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleDeclaration((Syntax.InternalSyntax.ParserRuleNameGreen)parserRuleName.Green, (InternalSyntaxToken)kDefines.Node, qualifier == null ? null : (Syntax.InternalSyntax.QualifierGreen)qualifier.Green, (InternalSyntaxToken)tColon.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParserRuleAlternativeGreen>(parserRuleAlternative.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ParserRuleDeclarationSyntax ParserRuleDeclaration(ParserRuleNameSyntax parserRuleName, Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> parserRuleAlternative)
		{
			return this.ParserRuleDeclaration(parserRuleName, default, default, this.Token(CompilerSyntaxKind.TColon), parserRuleAlternative, this.Token(CompilerSyntaxKind.TSemicolon));
		}
		
		public ParserRuleAlternativeSyntax ParserRuleAlternative(Microsoft.CodeAnalysis.SyntaxList<ParserRuleAlternativeElementSyntax> parserRuleAlternativeElement, EofElementSyntax eofElement)
		{
		    if (parserRuleAlternativeElement == null) throw new ArgumentNullException(nameof(parserRuleAlternativeElement));
		    return (ParserRuleAlternativeSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleAlternative(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ParserRuleAlternativeElementGreen>(parserRuleAlternativeElement.Node), eofElement == null ? null : (Syntax.InternalSyntax.EofElementGreen)eofElement.Green).CreateRed();
		}
		
		public ParserRuleAlternativeSyntax ParserRuleAlternative(Microsoft.CodeAnalysis.SyntaxList<ParserRuleAlternativeElementSyntax> parserRuleAlternativeElement)
		{
			return this.ParserRuleAlternative(parserRuleAlternativeElement, default);
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
		
		public ParserRuleAlternativeElementSyntax ParserRuleAlternativeElement(ParserMultiElementSyntax parserMultiElement)
		{
		    if (parserMultiElement == null) throw new ArgumentNullException(nameof(parserMultiElement));
		    return (ParserRuleAlternativeElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleAlternativeElement((Syntax.InternalSyntax.ParserMultiElementGreen)parserMultiElement.Green).CreateRed();
		}
		
		public ParserRuleAlternativeElementSyntax ParserRuleAlternativeElement(ParserNegatedElementSyntax parserNegatedElement)
		{
		    if (parserNegatedElement == null) throw new ArgumentNullException(nameof(parserNegatedElement));
		    return (ParserRuleAlternativeElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleAlternativeElement((Syntax.InternalSyntax.ParserNegatedElementGreen)parserNegatedElement.Green).CreateRed();
		}
		
		public ParserMultiElementSyntax ParserMultiElement(ElementNameSyntax elementName, AssignSyntax assign, ParserRuleElementSyntax parserRuleElement, MultiplicitySyntax multiplicity)
		{
		    if (parserRuleElement == null) throw new ArgumentNullException(nameof(parserRuleElement));
		    return (ParserMultiElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserMultiElement(elementName == null ? null : (Syntax.InternalSyntax.ElementNameGreen)elementName.Green, assign == null ? null : (Syntax.InternalSyntax.AssignGreen)assign.Green, (Syntax.InternalSyntax.ParserRuleElementGreen)parserRuleElement.Green, multiplicity == null ? null : (Syntax.InternalSyntax.MultiplicityGreen)multiplicity.Green).CreateRed();
		}
		
		public ParserMultiElementSyntax ParserMultiElement(ParserRuleElementSyntax parserRuleElement)
		{
			return this.ParserMultiElement(default, default, parserRuleElement, default);
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
		    if (tNegate == null) throw new ArgumentNullException(nameof(tNegate));
		    if (tNegate.GetKind() != CompilerSyntaxKind.TNegate) throw new ArgumentException(nameof(tNegate));
		    if (parserRuleElement == null) throw new ArgumentNullException(nameof(parserRuleElement));
		    return (ParserNegatedElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserNegatedElement((InternalSyntaxToken)tNegate.Node, (Syntax.InternalSyntax.ParserRuleElementGreen)parserRuleElement.Green).CreateRed();
		}
		
		public ParserNegatedElementSyntax ParserNegatedElement(ParserRuleElementSyntax parserRuleElement)
		{
			return this.ParserNegatedElement(this.Token(CompilerSyntaxKind.TNegate), parserRuleElement);
		}
		
		public ParserRuleElementSyntax ParserRuleElement(FixedElementSyntax fixedElement)
		{
		    if (fixedElement == null) throw new ArgumentNullException(nameof(fixedElement));
		    return (ParserRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement((Syntax.InternalSyntax.FixedElementGreen)fixedElement.Green).CreateRed();
		}
		
		public ParserRuleElementSyntax ParserRuleElement(ParserRuleReferenceSyntax parserRuleReference)
		{
		    if (parserRuleReference == null) throw new ArgumentNullException(nameof(parserRuleReference));
		    return (ParserRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement((Syntax.InternalSyntax.ParserRuleReferenceGreen)parserRuleReference.Green).CreateRed();
		}
		
		public ParserRuleElementSyntax ParserRuleElement(ParserRuleBlockSyntax parserRuleBlock)
		{
		    if (parserRuleBlock == null) throw new ArgumentNullException(nameof(parserRuleBlock));
		    return (ParserRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleElement((Syntax.InternalSyntax.ParserRuleBlockGreen)parserRuleBlock.Green).CreateRed();
		}
		
		public FixedElementSyntax FixedElement(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (FixedElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.FixedElement((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public ParserRuleReferenceSyntax ParserRuleReference(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (ParserRuleReferenceSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleReference((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public ParserRuleBlockSyntax ParserRuleBlock(SyntaxToken tOpenParen, Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> parserRuleAlternative, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CompilerSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (parserRuleAlternative == null) throw new ArgumentNullException(nameof(parserRuleAlternative));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CompilerSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (ParserRuleBlockSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ParserRuleBlock((InternalSyntaxToken)tOpenParen.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParserRuleAlternativeGreen>(parserRuleAlternative.Node), (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public ParserRuleBlockSyntax ParserRuleBlock(Microsoft.CodeAnalysis.SeparatedSyntaxList<ParserRuleAlternativeSyntax> parserRuleAlternative)
		{
			return this.ParserRuleBlock(this.Token(CompilerSyntaxKind.TOpenParen), parserRuleAlternative, this.Token(CompilerSyntaxKind.TCloseParen));
		}
		
		public LexerRuleDeclarationSyntax LexerRuleDeclaration(SyntaxToken modifier, LexerRuleNameSyntax lexerRuleName, SyntaxToken tColon, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative, SyntaxToken tSemicolon)
		{
		    if (lexerRuleName == null) throw new ArgumentNullException(nameof(lexerRuleName));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != CompilerSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (lexerRuleAlternative == null) throw new ArgumentNullException(nameof(lexerRuleAlternative));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != CompilerSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (LexerRuleDeclarationSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleDeclaration(modifier == null ? null : (InternalSyntaxToken)modifier.Node, (Syntax.InternalSyntax.LexerRuleNameGreen)lexerRuleName.Green, (InternalSyntaxToken)tColon.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<LexerRuleAlternativeGreen>(lexerRuleAlternative.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public LexerRuleDeclarationSyntax LexerRuleDeclaration(LexerRuleNameSyntax lexerRuleName, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative)
		{
			return this.LexerRuleDeclaration(default, lexerRuleName, this.Token(CompilerSyntaxKind.TColon), lexerRuleAlternative, this.Token(CompilerSyntaxKind.TSemicolon));
		}
		
		public LexerRuleAlternativeSyntax LexerRuleAlternative(Microsoft.CodeAnalysis.SyntaxList<LexerRuleAlternativeElementSyntax> lexerRuleAlternativeElement)
		{
		    if (lexerRuleAlternativeElement == null) throw new ArgumentNullException(nameof(lexerRuleAlternativeElement));
		    return (LexerRuleAlternativeSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleAlternative(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<LexerRuleAlternativeElementGreen>(lexerRuleAlternativeElement.Node)).CreateRed();
		}
		
		public LexerRuleAlternativeElementSyntax LexerRuleAlternativeElement(LexerMultiElementSyntax lexerMultiElement)
		{
		    if (lexerMultiElement == null) throw new ArgumentNullException(nameof(lexerMultiElement));
		    return (LexerRuleAlternativeElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleAlternativeElement((Syntax.InternalSyntax.LexerMultiElementGreen)lexerMultiElement.Green).CreateRed();
		}
		
		public LexerRuleAlternativeElementSyntax LexerRuleAlternativeElement(LexerNegatedElementSyntax lexerNegatedElement)
		{
		    if (lexerNegatedElement == null) throw new ArgumentNullException(nameof(lexerNegatedElement));
		    return (LexerRuleAlternativeElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleAlternativeElement((Syntax.InternalSyntax.LexerNegatedElementGreen)lexerNegatedElement.Green).CreateRed();
		}
		
		public LexerRuleAlternativeElementSyntax LexerRuleAlternativeElement(LexerRangeElementSyntax lexerRangeElement)
		{
		    if (lexerRangeElement == null) throw new ArgumentNullException(nameof(lexerRangeElement));
		    return (LexerRuleAlternativeElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleAlternativeElement((Syntax.InternalSyntax.LexerRangeElementGreen)lexerRangeElement.Green).CreateRed();
		}
		
		public LexerMultiElementSyntax LexerMultiElement(LexerRuleElementSyntax lexerRuleElement, MultiplicitySyntax multiplicity)
		{
		    if (lexerRuleElement == null) throw new ArgumentNullException(nameof(lexerRuleElement));
		    return (LexerMultiElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerMultiElement((Syntax.InternalSyntax.LexerRuleElementGreen)lexerRuleElement.Green, multiplicity == null ? null : (Syntax.InternalSyntax.MultiplicityGreen)multiplicity.Green).CreateRed();
		}
		
		public LexerMultiElementSyntax LexerMultiElement(LexerRuleElementSyntax lexerRuleElement)
		{
			return this.LexerMultiElement(lexerRuleElement, default);
		}
		
		public LexerNegatedElementSyntax LexerNegatedElement(SyntaxToken tNegate, LexerRuleElementSyntax lexerRuleElement)
		{
		    if (tNegate == null) throw new ArgumentNullException(nameof(tNegate));
		    if (tNegate.GetKind() != CompilerSyntaxKind.TNegate) throw new ArgumentException(nameof(tNegate));
		    if (lexerRuleElement == null) throw new ArgumentNullException(nameof(lexerRuleElement));
		    return (LexerNegatedElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerNegatedElement((InternalSyntaxToken)tNegate.Node, (Syntax.InternalSyntax.LexerRuleElementGreen)lexerRuleElement.Green).CreateRed();
		}
		
		public LexerNegatedElementSyntax LexerNegatedElement(LexerRuleElementSyntax lexerRuleElement)
		{
			return this.LexerNegatedElement(this.Token(CompilerSyntaxKind.TNegate), lexerRuleElement);
		}
		
		public LexerRangeElementSyntax LexerRangeElement(FixedElementSyntax start, SyntaxToken tArrow, FixedElementSyntax end)
		{
		    if (start == null) throw new ArgumentNullException(nameof(start));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != CompilerSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (end == null) throw new ArgumentNullException(nameof(end));
		    return (LexerRangeElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRangeElement((Syntax.InternalSyntax.FixedElementGreen)start.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.FixedElementGreen)end.Green).CreateRed();
		}
		
		public LexerRangeElementSyntax LexerRangeElement(FixedElementSyntax start, FixedElementSyntax end)
		{
			return this.LexerRangeElement(start, this.Token(CompilerSyntaxKind.TArrow), end);
		}
		
		public LexerRuleElementSyntax LexerRuleElement(FixedElementSyntax fixedElement)
		{
		    if (fixedElement == null) throw new ArgumentNullException(nameof(fixedElement));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.FixedElementGreen)fixedElement.Green).CreateRed();
		}
		
		public LexerRuleElementSyntax LexerRuleElement(WildcardElementSyntax wildcardElement)
		{
		    if (wildcardElement == null) throw new ArgumentNullException(nameof(wildcardElement));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.WildcardElementGreen)wildcardElement.Green).CreateRed();
		}
		
		public LexerRuleElementSyntax LexerRuleElement(LexerRuleReferenceSyntax lexerRuleReference)
		{
		    if (lexerRuleReference == null) throw new ArgumentNullException(nameof(lexerRuleReference));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.LexerRuleReferenceGreen)lexerRuleReference.Green).CreateRed();
		}
		
		public LexerRuleElementSyntax LexerRuleElement(LexerRuleBlockSyntax lexerRuleBlock)
		{
		    if (lexerRuleBlock == null) throw new ArgumentNullException(nameof(lexerRuleBlock));
		    return (LexerRuleElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleElement((Syntax.InternalSyntax.LexerRuleBlockGreen)lexerRuleBlock.Green).CreateRed();
		}
		
		public WildcardElementSyntax WildcardElement(SyntaxToken tDot)
		{
		    if (tDot == null) throw new ArgumentNullException(nameof(tDot));
		    if (tDot.GetKind() != CompilerSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
		    return (WildcardElementSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.WildcardElement((InternalSyntaxToken)tDot.Node).CreateRed();
		}
		
		public WildcardElementSyntax WildcardElement()
		{
			return this.WildcardElement(this.Token(CompilerSyntaxKind.TDot));
		}
		
		public LexerRuleReferenceSyntax LexerRuleReference(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (LexerRuleReferenceSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleReference((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public LexerRuleBlockSyntax LexerRuleBlock(SyntaxToken tOpenParen, Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != CompilerSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (lexerRuleAlternative == null) throw new ArgumentNullException(nameof(lexerRuleAlternative));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != CompilerSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (LexerRuleBlockSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.LexerRuleBlock((InternalSyntaxToken)tOpenParen.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<LexerRuleAlternativeGreen>(lexerRuleAlternative.Node), (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public LexerRuleBlockSyntax LexerRuleBlock(Microsoft.CodeAnalysis.SeparatedSyntaxList<LexerRuleAlternativeSyntax> lexerRuleAlternative)
		{
			return this.LexerRuleBlock(this.Token(CompilerSyntaxKind.TOpenParen), lexerRuleAlternative, this.Token(CompilerSyntaxKind.TCloseParen));
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
		
		public ElementNameSyntax ElementName(SyntaxToken lexerIdentifier)
		{
		    if (lexerIdentifier == null) throw new ArgumentNullException(nameof(lexerIdentifier));
		    if (lexerIdentifier.GetKind() != CompilerSyntaxKind.LexerIdentifier) throw new ArgumentException(nameof(lexerIdentifier));
		    return (ElementNameSyntax)CompilerLanguage.Instance.InternalSyntaxFactory.ElementName((InternalSyntaxToken)lexerIdentifier.Node).CreateRed();
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
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(NamespaceDeclarationSyntax),
				typeof(NamespaceBodySyntax),
				typeof(GrammarDeclarationSyntax),
				typeof(UsingDeclarationSyntax),
				typeof(RuleDeclarationsSyntax),
				typeof(RuleDeclarationSyntax),
				typeof(ParserRuleDeclarationSyntax),
				typeof(ParserRuleAlternativeSyntax),
				typeof(EofElementSyntax),
				typeof(ParserRuleAlternativeElementSyntax),
				typeof(ParserMultiElementSyntax),
				typeof(AssignSyntax),
				typeof(MultiplicitySyntax),
				typeof(ParserNegatedElementSyntax),
				typeof(ParserRuleElementSyntax),
				typeof(FixedElementSyntax),
				typeof(ParserRuleReferenceSyntax),
				typeof(ParserRuleBlockSyntax),
				typeof(LexerRuleDeclarationSyntax),
				typeof(LexerRuleAlternativeSyntax),
				typeof(LexerRuleAlternativeElementSyntax),
				typeof(LexerMultiElementSyntax),
				typeof(LexerNegatedElementSyntax),
				typeof(LexerRangeElementSyntax),
				typeof(LexerRuleElementSyntax),
				typeof(WildcardElementSyntax),
				typeof(LexerRuleReferenceSyntax),
				typeof(LexerRuleBlockSyntax),
				typeof(NameSyntax),
				typeof(QualifiedNameSyntax),
				typeof(QualifierSyntax),
				typeof(IdentifierSyntax),
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
			};
		}
	}
}

