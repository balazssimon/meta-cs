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

namespace PilV2.Syntax
{
    public abstract class PilSyntaxNode : LanguageSyntaxNode
    {
        protected PilSyntaxNode(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected PilSyntaxNode(InternalSyntaxNode green, PilSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new PilLanguage Language => PilLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new PilSyntaxKind Kind => (PilSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

        protected override SyntaxTree CreateSyntaxTreeForRoot()
        {
            return PilSyntaxTree.CreateWithoutClone(this);
        }

        public override TResult Accept<TArg, TResult>(SyntaxVisitor<TArg, TResult> visitor, TArg argument)
        {
            if (visitor is IPilSyntaxVisitor<TArg, TResult> typedVisitor) return this.Accept(typedVisitor, argument);
            else return visitor.DefaultVisit(this, argument);
        }

        public abstract TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument);

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            if (visitor is IPilSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            if (visitor is IPilSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }
        public abstract void Accept(IPilSyntaxVisitor visitor);
    }

    /// <summary>
    /// It's a non terminal Trivia PilSyntaxNode that has a tree underneath it.
    /// </summary>
    public abstract partial class PilStructuredTriviaSyntax : PilSyntaxNode, IStructuredTriviaSyntax
    {
        private SyntaxTrivia _parent;
        internal PilStructuredTriviaSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
            : base(green, parent == null ? null : (PilSyntaxTree)parent.SyntaxTree, position)
        {
            System.Diagnostics.Debug.Assert(parent == null || position >= 0);
        }
		internal static PilStructuredTriviaSyntax Create(SyntaxTrivia trivia)
		{
			var red = (PilStructuredTriviaSyntax)PilLanguage.Instance.SyntaxFactory.CreateStructure(trivia);
			red._parent = trivia;
			return red;
		}
        /// <summary>
        /// Get parent trivia.
        /// </summary>
        public override SyntaxTrivia ParentTrivia => _parent;
    }

    public sealed partial class PilSkippedTokensTriviaSyntax : PilStructuredTriviaSyntax
    {
        internal PilSkippedTokensTriviaSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public SyntaxTokenList Tokens 
        {
            get
            {
				var slot = ((global::PilV2.Syntax.InternalSyntax.GreenSkippedTokensTriviaSyntax)this.Green).Tokens;
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

		public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
		{
			return visitor.VisitSkippedTokensTrivia(this, argument);
		}

		public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
        {
            return visitor.VisitSkippedTokensTrivia(this);
        }

        public override void Accept(IPilSyntaxVisitor visitor)
        {
            visitor.VisitSkippedTokensTrivia(this);
        }

        public PilSkippedTokensTriviaSyntax Update(SyntaxTokenList tokens)
        {
            if (tokens != this.Tokens)
            {
                var newNode = (PilSkippedTokensTriviaSyntax)Language.SyntaxFactory.SkippedTokensTrivia(tokens);
                var annotations = this.GetAnnotations();
                if (annotations != null && annotations.Length > 0)
                    return newNode.WithAnnotations(annotations);
                return newNode;
            }
            return this;
        }

        public PilSkippedTokensTriviaSyntax WithTokens(SyntaxTokenList tokens)
        {
            return this.Update(tokens);
        }

        public PilSkippedTokensTriviaSyntax AddTokens(params SyntaxToken[] items)
        {
            return this.WithTokens(this.Tokens.AddRange(items));
        }
    }

	
	public sealed class MainSyntax : PilSyntaxNode, ICompilationUnitSyntax
	{
	    private SyntaxNode declaration;
	
	    public MainSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<DeclarationSyntax> Declaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration, 0);
				if (red != null) return new SyntaxList<DeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken EndOfFileToken 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.EndOfFileToken;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.declaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.declaration;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithDeclaration(SyntaxList<DeclarationSyntax> declaration)
		{
			return this.Update(Declaration, this.EndOfFileToken);
		}
	
	    public MainSyntax AddDeclaration(params DeclarationSyntax[] declaration)
		{
			return this.WithDeclaration(this.Declaration.AddRange(declaration));
		}
	
	    public MainSyntax WithEndOfFileToken(SyntaxToken eOF)
		{
			return this.Update(this.Declaration, EndOfFileToken);
		}
	
	    public MainSyntax Update(SyntaxList<DeclarationSyntax> declaration, SyntaxToken eOF)
	    {
	        if (this.Declaration != declaration ||
				this.EndOfFileToken != eOF)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Main(declaration, eOF);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class DeclarationSyntax : PilSyntaxNode
	{
	    private TypeDefDeclarationSyntax typeDefDeclaration;
	    private ExternalParameterDeclarationSyntax externalParameterDeclaration;
	    private EnumDeclarationSyntax enumDeclaration;
	    private ObjectDeclarationSyntax objectDeclaration;
	    private FunctionDeclarationSyntax functionDeclaration;
	    private QueryDeclarationSyntax queryDeclaration;
	
	    public DeclarationSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DeclarationSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeDefDeclarationSyntax TypeDefDeclaration 
		{ 
			get { return this.GetRed(ref this.typeDefDeclaration, 0); } 
		}
	    public ExternalParameterDeclarationSyntax ExternalParameterDeclaration 
		{ 
			get { return this.GetRed(ref this.externalParameterDeclaration, 1); } 
		}
	    public EnumDeclarationSyntax EnumDeclaration 
		{ 
			get { return this.GetRed(ref this.enumDeclaration, 2); } 
		}
	    public ObjectDeclarationSyntax ObjectDeclaration 
		{ 
			get { return this.GetRed(ref this.objectDeclaration, 3); } 
		}
	    public FunctionDeclarationSyntax FunctionDeclaration 
		{ 
			get { return this.GetRed(ref this.functionDeclaration, 4); } 
		}
	    public QueryDeclarationSyntax QueryDeclaration 
		{ 
			get { return this.GetRed(ref this.queryDeclaration, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeDefDeclaration, 0);
				case 1: return this.GetRed(ref this.externalParameterDeclaration, 1);
				case 2: return this.GetRed(ref this.enumDeclaration, 2);
				case 3: return this.GetRed(ref this.objectDeclaration, 3);
				case 4: return this.GetRed(ref this.functionDeclaration, 4);
				case 5: return this.GetRed(ref this.queryDeclaration, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeDefDeclaration;
				case 1: return this.externalParameterDeclaration;
				case 2: return this.enumDeclaration;
				case 3: return this.objectDeclaration;
				case 4: return this.functionDeclaration;
				case 5: return this.queryDeclaration;
				default: return null;
	        }
	    }
	
	    public DeclarationSyntax WithTypeDefDeclaration(TypeDefDeclarationSyntax typeDefDeclaration)
		{
			return this.Update(typeDefDeclaration);
		}
	
	    public DeclarationSyntax WithExternalParameterDeclaration(ExternalParameterDeclarationSyntax externalParameterDeclaration)
		{
			return this.Update(externalParameterDeclaration);
		}
	
	    public DeclarationSyntax WithEnumDeclaration(EnumDeclarationSyntax enumDeclaration)
		{
			return this.Update(enumDeclaration);
		}
	
	    public DeclarationSyntax WithObjectDeclaration(ObjectDeclarationSyntax objectDeclaration)
		{
			return this.Update(objectDeclaration);
		}
	
	    public DeclarationSyntax WithFunctionDeclaration(FunctionDeclarationSyntax functionDeclaration)
		{
			return this.Update(functionDeclaration);
		}
	
	    public DeclarationSyntax WithQueryDeclaration(QueryDeclarationSyntax queryDeclaration)
		{
			return this.Update(queryDeclaration);
		}
	
	    public DeclarationSyntax Update(TypeDefDeclarationSyntax typeDefDeclaration)
	    {
	        if (this.TypeDefDeclaration != typeDefDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Declaration(typeDefDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(ExternalParameterDeclarationSyntax externalParameterDeclaration)
	    {
	        if (this.ExternalParameterDeclaration != externalParameterDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Declaration(externalParameterDeclaration);
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
	            var newNode = PilLanguage.Instance.SyntaxFactory.Declaration(enumDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(ObjectDeclarationSyntax objectDeclaration)
	    {
	        if (this.ObjectDeclaration != objectDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Declaration(objectDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(FunctionDeclarationSyntax functionDeclaration)
	    {
	        if (this.FunctionDeclaration != functionDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Declaration(functionDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DeclarationSyntax Update(QueryDeclarationSyntax queryDeclaration)
	    {
	        if (this.QueryDeclaration != queryDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Declaration(queryDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration(this);
	    }
	}
	
	public sealed class TypeDefDeclarationSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	    private TypeReferenceSyntax typeReference;
	
	    public TypeDefDeclarationSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeDefDeclarationSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTypeDef 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.TypeDefDeclarationGreen)this.Green;
				var greenToken = green.KTypeDef;
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
				var green = (global::PilV2.Syntax.InternalSyntax.TypeDefDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.TypeDefDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.typeReference, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public TypeDefDeclarationSyntax WithKTypeDef(SyntaxToken kTypeDef)
		{
			return this.Update(KTypeDef, this.Name, this.TColon, this.TypeReference, this.TSemicolon);
		}
	
	    public TypeDefDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KTypeDef, Name, this.TColon, this.TypeReference, this.TSemicolon);
		}
	
	    public TypeDefDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KTypeDef, this.Name, TColon, this.TypeReference, this.TSemicolon);
		}
	
	    public TypeDefDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KTypeDef, this.Name, this.TColon, TypeReference, this.TSemicolon);
		}
	
	    public TypeDefDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KTypeDef, this.Name, this.TColon, this.TypeReference, TSemicolon);
		}
	
	    public TypeDefDeclarationSyntax Update(SyntaxToken kTypeDef, NameSyntax name, SyntaxToken tColon, TypeReferenceSyntax typeReference, SyntaxToken tSemicolon)
	    {
	        if (this.KTypeDef != kTypeDef ||
				this.Name != name ||
				this.TColon != tColon ||
				this.TypeReference != typeReference ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TypeDefDeclaration(kTypeDef, name, tColon, typeReference, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeDefDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeDefDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeDefDeclaration(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeDefDeclaration(this);
	    }
	}
	
	public sealed class ExternalParameterDeclarationSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	    private TypeReferenceSyntax typeReference;
	    private ExpressionSyntax expression;
	
	    public ExternalParameterDeclarationSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ExternalParameterDeclarationSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KParam 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ExternalParameterDeclarationGreen)this.Green;
				var greenToken = green.KParam;
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
				var green = (global::PilV2.Syntax.InternalSyntax.ExternalParameterDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 3); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ExternalParameterDeclarationGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 5); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ExternalParameterDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.typeReference, 3);
				case 5: return this.GetRed(ref this.expression, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.typeReference;
				case 5: return this.expression;
				default: return null;
	        }
	    }
	
	    public ExternalParameterDeclarationSyntax WithKParam(SyntaxToken kParam)
		{
			return this.Update(KParam, this.Name, this.TColon, this.TypeReference, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public ExternalParameterDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KParam, Name, this.TColon, this.TypeReference, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public ExternalParameterDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KParam, this.Name, TColon, this.TypeReference, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public ExternalParameterDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KParam, this.Name, this.TColon, TypeReference, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public ExternalParameterDeclarationSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.KParam, this.Name, this.TColon, this.TypeReference, TAssign, this.Expression, this.TSemicolon);
		}
	
	    public ExternalParameterDeclarationSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KParam, this.Name, this.TColon, this.TypeReference, this.TAssign, Expression, this.TSemicolon);
		}
	
	    public ExternalParameterDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KParam, this.Name, this.TColon, this.TypeReference, this.TAssign, this.Expression, TSemicolon);
		}
	
	    public ExternalParameterDeclarationSyntax Update(SyntaxToken kParam, NameSyntax name, SyntaxToken tColon, TypeReferenceSyntax typeReference, SyntaxToken tAssign, ExpressionSyntax expression, SyntaxToken tSemicolon)
	    {
	        if (this.KParam != kParam ||
				this.Name != name ||
				this.TColon != tColon ||
				this.TypeReference != typeReference ||
				this.TAssign != tAssign ||
				this.Expression != expression ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ExternalParameterDeclaration(kParam, name, tColon, typeReference, tAssign, expression, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExternalParameterDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitExternalParameterDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitExternalParameterDeclaration(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitExternalParameterDeclaration(this);
	    }
	}
	
	public sealed class EnumDeclarationSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	    private EnumLiteralsSyntax enumLiterals;
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumDeclarationSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEnum 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.EnumDeclarationGreen)this.Green;
				var greenToken = green.KEnum;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.EnumDeclarationGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public EnumLiteralsSyntax EnumLiterals 
		{ 
			get { return this.GetRed(ref this.enumLiterals, 3); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.EnumDeclarationGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.EnumDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.enumLiterals, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.enumLiterals;
				default: return null;
	        }
	    }
	
	    public EnumDeclarationSyntax WithKEnum(SyntaxToken kEnum)
		{
			return this.Update(KEnum, this.Name, this.TOpenBracket, this.EnumLiterals, this.TCloseBracket, this.TSemicolon);
		}
	
	    public EnumDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KEnum, Name, this.TOpenBracket, this.EnumLiterals, this.TCloseBracket, this.TSemicolon);
		}
	
	    public EnumDeclarationSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(this.KEnum, this.Name, TOpenBracket, this.EnumLiterals, this.TCloseBracket, this.TSemicolon);
		}
	
	    public EnumDeclarationSyntax WithEnumLiterals(EnumLiteralsSyntax enumLiterals)
		{
			return this.Update(this.KEnum, this.Name, this.TOpenBracket, EnumLiterals, this.TCloseBracket, this.TSemicolon);
		}
	
	    public EnumDeclarationSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.KEnum, this.Name, this.TOpenBracket, this.EnumLiterals, TCloseBracket, this.TSemicolon);
		}
	
	    public EnumDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KEnum, this.Name, this.TOpenBracket, this.EnumLiterals, this.TCloseBracket, TSemicolon);
		}
	
	    public EnumDeclarationSyntax Update(SyntaxToken kEnum, NameSyntax name, SyntaxToken tOpenBracket, EnumLiteralsSyntax enumLiterals, SyntaxToken tCloseBracket, SyntaxToken tSemicolon)
	    {
	        if (this.KEnum != kEnum ||
				this.Name != name ||
				this.TOpenBracket != tOpenBracket ||
				this.EnumLiterals != enumLiterals ||
				this.TCloseBracket != tCloseBracket ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.EnumDeclaration(kEnum, name, tOpenBracket, enumLiterals, tCloseBracket, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumDeclaration(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumDeclaration(this);
	    }
	}
	
	public sealed class EnumLiteralsSyntax : PilSyntaxNode
	{
	    private SyntaxNode enumLiteral;
	
	    public EnumLiteralsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumLiteralsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
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
	            var newNode = PilLanguage.Instance.SyntaxFactory.EnumLiterals(enumLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumLiteralsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumLiterals(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumLiterals(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumLiterals(this);
	    }
	}
	
	public sealed class EnumLiteralSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	
	    public EnumLiteralSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EnumLiteralSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				default: return null;
	        }
	    }
	
	    public EnumLiteralSyntax WithName(NameSyntax name)
		{
			return this.Update(Name);
		}
	
	    public EnumLiteralSyntax Update(NameSyntax name)
	    {
	        if (this.Name != name)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.EnumLiteral(name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EnumLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEnumLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEnumLiteral(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitEnumLiteral(this);
	    }
	}
	
	public sealed class ObjectDeclarationSyntax : PilSyntaxNode
	{
	    private ObjectHeaderSyntax objectHeader;
	    private ObjectExternalParametersSyntax objectExternalParameters;
	    private ObjectFieldsSyntax objectFields;
	    private ObjectFunctionsSyntax objectFunctions;
	
	    public ObjectDeclarationSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ObjectDeclarationSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KObject 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ObjectDeclarationGreen)this.Green;
				var greenToken = green.KObject;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ObjectHeaderSyntax ObjectHeader 
		{ 
			get { return this.GetRed(ref this.objectHeader, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ObjectDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ObjectExternalParametersSyntax ObjectExternalParameters 
		{ 
			get { return this.GetRed(ref this.objectExternalParameters, 3); } 
		}
	    public ObjectFieldsSyntax ObjectFields 
		{ 
			get { return this.GetRed(ref this.objectFields, 4); } 
		}
	    public ObjectFunctionsSyntax ObjectFunctions 
		{ 
			get { return this.GetRed(ref this.objectFunctions, 5); } 
		}
	    public SyntaxToken KEndObject 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ObjectDeclarationGreen)this.Green;
				var greenToken = green.KEndObject;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.objectHeader, 1);
				case 3: return this.GetRed(ref this.objectExternalParameters, 3);
				case 4: return this.GetRed(ref this.objectFields, 4);
				case 5: return this.GetRed(ref this.objectFunctions, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.objectHeader;
				case 3: return this.objectExternalParameters;
				case 4: return this.objectFields;
				case 5: return this.objectFunctions;
				default: return null;
	        }
	    }
	
	    public ObjectDeclarationSyntax WithKObject(SyntaxToken kObject)
		{
			return this.Update(KObject, this.ObjectHeader, this.TSemicolon, this.ObjectExternalParameters, this.ObjectFields, this.ObjectFunctions, this.KEndObject);
		}
	
	    public ObjectDeclarationSyntax WithObjectHeader(ObjectHeaderSyntax objectHeader)
		{
			return this.Update(this.KObject, ObjectHeader, this.TSemicolon, this.ObjectExternalParameters, this.ObjectFields, this.ObjectFunctions, this.KEndObject);
		}
	
	    public ObjectDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KObject, this.ObjectHeader, TSemicolon, this.ObjectExternalParameters, this.ObjectFields, this.ObjectFunctions, this.KEndObject);
		}
	
	    public ObjectDeclarationSyntax WithObjectExternalParameters(ObjectExternalParametersSyntax objectExternalParameters)
		{
			return this.Update(this.KObject, this.ObjectHeader, this.TSemicolon, ObjectExternalParameters, this.ObjectFields, this.ObjectFunctions, this.KEndObject);
		}
	
	    public ObjectDeclarationSyntax WithObjectFields(ObjectFieldsSyntax objectFields)
		{
			return this.Update(this.KObject, this.ObjectHeader, this.TSemicolon, this.ObjectExternalParameters, ObjectFields, this.ObjectFunctions, this.KEndObject);
		}
	
	    public ObjectDeclarationSyntax WithObjectFunctions(ObjectFunctionsSyntax objectFunctions)
		{
			return this.Update(this.KObject, this.ObjectHeader, this.TSemicolon, this.ObjectExternalParameters, this.ObjectFields, ObjectFunctions, this.KEndObject);
		}
	
	    public ObjectDeclarationSyntax WithKEndObject(SyntaxToken kEndObject)
		{
			return this.Update(this.KObject, this.ObjectHeader, this.TSemicolon, this.ObjectExternalParameters, this.ObjectFields, this.ObjectFunctions, KEndObject);
		}
	
	    public ObjectDeclarationSyntax Update(SyntaxToken kObject, ObjectHeaderSyntax objectHeader, SyntaxToken tSemicolon, ObjectExternalParametersSyntax objectExternalParameters, ObjectFieldsSyntax objectFields, ObjectFunctionsSyntax objectFunctions, SyntaxToken kEndObject)
	    {
	        if (this.KObject != kObject ||
				this.ObjectHeader != objectHeader ||
				this.TSemicolon != tSemicolon ||
				this.ObjectExternalParameters != objectExternalParameters ||
				this.ObjectFields != objectFields ||
				this.ObjectFunctions != objectFunctions ||
				this.KEndObject != kEndObject)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ObjectDeclaration(kObject, objectHeader, tSemicolon, objectExternalParameters, objectFields, objectFunctions, kEndObject);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitObjectDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitObjectDeclaration(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitObjectDeclaration(this);
	    }
	}
	
	public sealed class ObjectHeaderSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	    private PortsSyntax ports;
	
	    public ObjectHeaderSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ObjectHeaderSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ObjectHeaderGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public PortsSyntax Ports 
		{ 
			get { return this.GetRed(ref this.ports, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ObjectHeaderGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				case 2: return this.GetRed(ref this.ports, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				case 2: return this.ports;
				default: return null;
	        }
	    }
	
	    public ObjectHeaderSyntax WithName(NameSyntax name)
		{
			return this.Update(Name, this.TOpenParen, this.Ports, this.TCloseParen);
		}
	
	    public ObjectHeaderSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Name, TOpenParen, this.Ports, this.TCloseParen);
		}
	
	    public ObjectHeaderSyntax WithPorts(PortsSyntax ports)
		{
			return this.Update(this.Name, this.TOpenParen, Ports, this.TCloseParen);
		}
	
	    public ObjectHeaderSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Name, this.TOpenParen, this.Ports, TCloseParen);
		}
	
	    public ObjectHeaderSyntax Update(NameSyntax name, SyntaxToken tOpenParen, PortsSyntax ports, SyntaxToken tCloseParen)
	    {
	        if (this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.Ports != ports ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ObjectHeader(name, tOpenParen, ports, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectHeaderSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitObjectHeader(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitObjectHeader(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitObjectHeader(this);
	    }
	}
	
	public sealed class PortsSyntax : PilSyntaxNode
	{
	    private SyntaxNode port;
	
	    public PortsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PortsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<PortSyntax> Port 
		{ 
			get
			{
				var red = this.GetRed(ref this.port, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<PortSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.port, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.port;
				default: return null;
	        }
	    }
	
	    public PortsSyntax WithPort(SeparatedSyntaxList<PortSyntax> port)
		{
			return this.Update(Port);
		}
	
	    public PortsSyntax AddPort(params PortSyntax[] port)
		{
			return this.WithPort(this.Port.AddRange(port));
		}
	
	    public PortsSyntax Update(SeparatedSyntaxList<PortSyntax> port)
	    {
	        if (this.Port != port)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Ports(port);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PortsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPorts(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPorts(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitPorts(this);
	    }
	}
	
	public sealed class PortSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	
	    public PortSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PortSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				default: return null;
	        }
	    }
	
	    public PortSyntax WithName(NameSyntax name)
		{
			return this.Update(Name);
		}
	
	    public PortSyntax Update(NameSyntax name)
	    {
	        if (this.Name != name)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Port(name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PortSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPort(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPort(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitPort(this);
	    }
	}
	
	public sealed class ObjectExternalParametersSyntax : PilSyntaxNode
	{
	    private SyntaxNode externalParameterDeclaration;
	
	    public ObjectExternalParametersSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ObjectExternalParametersSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<ExternalParameterDeclarationSyntax> ExternalParameterDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.externalParameterDeclaration, 0);
				if (red != null) return new SyntaxList<ExternalParameterDeclarationSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.externalParameterDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.externalParameterDeclaration;
				default: return null;
	        }
	    }
	
	    public ObjectExternalParametersSyntax WithExternalParameterDeclaration(SyntaxList<ExternalParameterDeclarationSyntax> externalParameterDeclaration)
		{
			return this.Update(ExternalParameterDeclaration);
		}
	
	    public ObjectExternalParametersSyntax AddExternalParameterDeclaration(params ExternalParameterDeclarationSyntax[] externalParameterDeclaration)
		{
			return this.WithExternalParameterDeclaration(this.ExternalParameterDeclaration.AddRange(externalParameterDeclaration));
		}
	
	    public ObjectExternalParametersSyntax Update(SyntaxList<ExternalParameterDeclarationSyntax> externalParameterDeclaration)
	    {
	        if (this.ExternalParameterDeclaration != externalParameterDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ObjectExternalParameters(externalParameterDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectExternalParametersSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitObjectExternalParameters(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitObjectExternalParameters(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitObjectExternalParameters(this);
	    }
	}
	
	public sealed class ObjectFieldsSyntax : PilSyntaxNode
	{
	    private SyntaxNode variableDeclaration;
	
	    public ObjectFieldsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ObjectFieldsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<VariableDeclarationSyntax> VariableDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.variableDeclaration, 0);
				if (red != null) return new SyntaxList<VariableDeclarationSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableDeclaration;
				default: return null;
	        }
	    }
	
	    public ObjectFieldsSyntax WithVariableDeclaration(SyntaxList<VariableDeclarationSyntax> variableDeclaration)
		{
			return this.Update(VariableDeclaration);
		}
	
	    public ObjectFieldsSyntax AddVariableDeclaration(params VariableDeclarationSyntax[] variableDeclaration)
		{
			return this.WithVariableDeclaration(this.VariableDeclaration.AddRange(variableDeclaration));
		}
	
	    public ObjectFieldsSyntax Update(SyntaxList<VariableDeclarationSyntax> variableDeclaration)
	    {
	        if (this.VariableDeclaration != variableDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ObjectFields(variableDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectFieldsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitObjectFields(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitObjectFields(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitObjectFields(this);
	    }
	}
	
	public sealed class ObjectFunctionsSyntax : PilSyntaxNode
	{
	    private SyntaxNode functionDeclaration;
	
	    public ObjectFunctionsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ObjectFunctionsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<FunctionDeclarationSyntax> FunctionDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.functionDeclaration, 0);
				if (red != null) return new SyntaxList<FunctionDeclarationSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.functionDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.functionDeclaration;
				default: return null;
	        }
	    }
	
	    public ObjectFunctionsSyntax WithFunctionDeclaration(SyntaxList<FunctionDeclarationSyntax> functionDeclaration)
		{
			return this.Update(FunctionDeclaration);
		}
	
	    public ObjectFunctionsSyntax AddFunctionDeclaration(params FunctionDeclarationSyntax[] functionDeclaration)
		{
			return this.WithFunctionDeclaration(this.FunctionDeclaration.AddRange(functionDeclaration));
		}
	
	    public ObjectFunctionsSyntax Update(SyntaxList<FunctionDeclarationSyntax> functionDeclaration)
	    {
	        if (this.FunctionDeclaration != functionDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ObjectFunctions(functionDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ObjectFunctionsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitObjectFunctions(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitObjectFunctions(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitObjectFunctions(this);
	    }
	}
	
	public sealed class FunctionDeclarationSyntax : PilSyntaxNode
	{
	    private FunctionHeaderSyntax functionHeader;
	    private CommentSyntax comment;
	    private StatementsSyntax statements;
	
	    public FunctionDeclarationSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FunctionDeclarationSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KFunction 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.FunctionDeclarationGreen)this.Green;
				var greenToken = green.KFunction;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public FunctionHeaderSyntax FunctionHeader 
		{ 
			get { return this.GetRed(ref this.functionHeader, 1); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.FunctionDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public StatementsSyntax Statements 
		{ 
			get { return this.GetRed(ref this.statements, 4); } 
		}
	    public SyntaxToken KEndFunction 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.FunctionDeclarationGreen)this.Green;
				var greenToken = green.KEndFunction;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.functionHeader, 1);
				case 2: return this.GetRed(ref this.comment, 2);
				case 4: return this.GetRed(ref this.statements, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.functionHeader;
				case 2: return this.comment;
				case 4: return this.statements;
				default: return null;
	        }
	    }
	
	    public FunctionDeclarationSyntax WithKFunction(SyntaxToken kFunction)
		{
			return this.Update(KFunction, this.FunctionHeader, this.Comment, this.TSemicolon, this.Statements, this.KEndFunction);
		}
	
	    public FunctionDeclarationSyntax WithFunctionHeader(FunctionHeaderSyntax functionHeader)
		{
			return this.Update(this.KFunction, FunctionHeader, this.Comment, this.TSemicolon, this.Statements, this.KEndFunction);
		}
	
	    public FunctionDeclarationSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KFunction, this.FunctionHeader, Comment, this.TSemicolon, this.Statements, this.KEndFunction);
		}
	
	    public FunctionDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KFunction, this.FunctionHeader, this.Comment, TSemicolon, this.Statements, this.KEndFunction);
		}
	
	    public FunctionDeclarationSyntax WithStatements(StatementsSyntax statements)
		{
			return this.Update(this.KFunction, this.FunctionHeader, this.Comment, this.TSemicolon, Statements, this.KEndFunction);
		}
	
	    public FunctionDeclarationSyntax WithKEndFunction(SyntaxToken kEndFunction)
		{
			return this.Update(this.KFunction, this.FunctionHeader, this.Comment, this.TSemicolon, this.Statements, KEndFunction);
		}
	
	    public FunctionDeclarationSyntax Update(SyntaxToken kFunction, FunctionHeaderSyntax functionHeader, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements, SyntaxToken kEndFunction)
	    {
	        if (this.KFunction != kFunction ||
				this.FunctionHeader != functionHeader ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements ||
				this.KEndFunction != kEndFunction)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.FunctionDeclaration(kFunction, functionHeader, comment, tSemicolon, statements, kEndFunction);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFunctionDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFunctionDeclaration(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitFunctionDeclaration(this);
	    }
	}
	
	public sealed class FunctionHeaderSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	    private FunctionParamsSyntax functionParams;
	    private TypeReferenceSyntax typeReference;
	
	    public FunctionHeaderSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FunctionHeaderSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.FunctionHeaderGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public FunctionParamsSyntax FunctionParams 
		{ 
			get { return this.GetRed(ref this.functionParams, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.FunctionHeaderGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.FunctionHeaderGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				case 2: return this.GetRed(ref this.functionParams, 2);
				case 5: return this.GetRed(ref this.typeReference, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				case 2: return this.functionParams;
				case 5: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public FunctionHeaderSyntax WithName(NameSyntax name)
		{
			return this.Update(Name, this.TOpenParen, this.FunctionParams, this.TCloseParen, this.TColon, this.TypeReference);
		}
	
	    public FunctionHeaderSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Name, TOpenParen, this.FunctionParams, this.TCloseParen, this.TColon, this.TypeReference);
		}
	
	    public FunctionHeaderSyntax WithFunctionParams(FunctionParamsSyntax functionParams)
		{
			return this.Update(this.Name, this.TOpenParen, FunctionParams, this.TCloseParen, this.TColon, this.TypeReference);
		}
	
	    public FunctionHeaderSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Name, this.TOpenParen, this.FunctionParams, TCloseParen, this.TColon, this.TypeReference);
		}
	
	    public FunctionHeaderSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Name, this.TOpenParen, this.FunctionParams, this.TCloseParen, TColon, this.TypeReference);
		}
	
	    public FunctionHeaderSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Name, this.TOpenParen, this.FunctionParams, this.TCloseParen, this.TColon, TypeReference);
		}
	
	    public FunctionHeaderSyntax Update(NameSyntax name, SyntaxToken tOpenParen, FunctionParamsSyntax functionParams, SyntaxToken tCloseParen, SyntaxToken tColon, TypeReferenceSyntax typeReference)
	    {
	        if (this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.FunctionParams != functionParams ||
				this.TCloseParen != tCloseParen ||
				this.TColon != tColon ||
				this.TypeReference != typeReference)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.FunctionHeader(name, tOpenParen, functionParams, tCloseParen, tColon, typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionHeaderSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFunctionHeader(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFunctionHeader(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitFunctionHeader(this);
	    }
	}
	
	public sealed class FunctionParamsSyntax : PilSyntaxNode
	{
	    private SyntaxNode param;
	
	    public FunctionParamsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FunctionParamsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<ParamSyntax> Param 
		{ 
			get
			{
				var red = this.GetRed(ref this.param, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<ParamSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.param, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.param;
				default: return null;
	        }
	    }
	
	    public FunctionParamsSyntax WithParam(SeparatedSyntaxList<ParamSyntax> param)
		{
			return this.Update(Param);
		}
	
	    public FunctionParamsSyntax AddParam(params ParamSyntax[] param)
		{
			return this.WithParam(this.Param.AddRange(param));
		}
	
	    public FunctionParamsSyntax Update(SeparatedSyntaxList<ParamSyntax> param)
	    {
	        if (this.Param != param)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.FunctionParams(param);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionParamsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFunctionParams(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFunctionParams(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitFunctionParams(this);
	    }
	}
	
	public sealed class ParamSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	    private TypeReferenceSyntax typeReference;
	
	    public ParamSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParamSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ParamGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public ParamSyntax WithName(NameSyntax name)
		{
			return this.Update(Name, this.TColon, this.TypeReference);
		}
	
	    public ParamSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Name, TColon, this.TypeReference);
		}
	
	    public ParamSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Name, this.TColon, TypeReference);
		}
	
	    public ParamSyntax Update(NameSyntax name, SyntaxToken tColon, TypeReferenceSyntax typeReference)
	    {
	        if (this.Name != name ||
				this.TColon != tColon ||
				this.TypeReference != typeReference)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Param(name, tColon, typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParamSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParam(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParam(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitParam(this);
	    }
	}
	
	public sealed class QueryDeclarationSyntax : PilSyntaxNode
	{
	    private QueryHeaderSyntax queryHeader;
	    private CommentSyntax comment;
	    private SyntaxNode queryExternalParameters;
	    private SyntaxNode queryField;
	    private SyntaxNode functionDeclaration;
	    private SyntaxNode queryObject;
	    private IdentifierSyntax endName;
	
	    public QueryDeclarationSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryDeclarationSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KQuery 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryDeclarationGreen)this.Green;
				var greenToken = green.KQuery;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QueryHeaderSyntax QueryHeader 
		{ 
			get { return this.GetRed(ref this.queryHeader, 1); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 2); } 
		}
	    public SyntaxToken StartQuerySemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryDeclarationGreen)this.Green;
				var greenToken = green.StartQuerySemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public SyntaxList<QueryExternalParametersSyntax> QueryExternalParameters 
		{ 
			get
			{
				var red = this.GetRed(ref this.queryExternalParameters, 4);
				if (red != null) return new SyntaxList<QueryExternalParametersSyntax>(red);
				return default;
			} 
		}
	    public SyntaxList<QueryFieldSyntax> QueryField 
		{ 
			get
			{
				var red = this.GetRed(ref this.queryField, 5);
				if (red != null) return new SyntaxList<QueryFieldSyntax>(red);
				return default;
			} 
		}
	    public SyntaxList<FunctionDeclarationSyntax> FunctionDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.functionDeclaration, 6);
				if (red != null) return new SyntaxList<FunctionDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxList<QueryObjectSyntax> QueryObject 
		{ 
			get
			{
				var red = this.GetRed(ref this.queryObject, 7);
				if (red != null) return new SyntaxList<QueryObjectSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KEndQuery 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryDeclarationGreen)this.Green;
				var greenToken = green.KEndQuery;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(8), this.GetChildIndex(8));
			}
		}
	    public IdentifierSyntax EndName 
		{ 
			get { return this.GetRed(ref this.endName, 9); } 
		}
	    public SyntaxToken EndQuerySemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryDeclarationGreen)this.Green;
				var greenToken = green.EndQuerySemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(10), this.GetChildIndex(10));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.queryHeader, 1);
				case 2: return this.GetRed(ref this.comment, 2);
				case 4: return this.GetRed(ref this.queryExternalParameters, 4);
				case 5: return this.GetRed(ref this.queryField, 5);
				case 6: return this.GetRed(ref this.functionDeclaration, 6);
				case 7: return this.GetRed(ref this.queryObject, 7);
				case 9: return this.GetRed(ref this.endName, 9);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.queryHeader;
				case 2: return this.comment;
				case 4: return this.queryExternalParameters;
				case 5: return this.queryField;
				case 6: return this.functionDeclaration;
				case 7: return this.queryObject;
				case 9: return this.endName;
				default: return null;
	        }
	    }
	
	    public QueryDeclarationSyntax WithKQuery(SyntaxToken kQuery)
		{
			return this.Update(KQuery, this.QueryHeader, this.Comment, this.StartQuerySemicolon, this.QueryExternalParameters, this.QueryField, this.FunctionDeclaration, this.QueryObject, this.KEndQuery, this.EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax WithQueryHeader(QueryHeaderSyntax queryHeader)
		{
			return this.Update(this.KQuery, QueryHeader, this.Comment, this.StartQuerySemicolon, this.QueryExternalParameters, this.QueryField, this.FunctionDeclaration, this.QueryObject, this.KEndQuery, this.EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KQuery, this.QueryHeader, Comment, this.StartQuerySemicolon, this.QueryExternalParameters, this.QueryField, this.FunctionDeclaration, this.QueryObject, this.KEndQuery, this.EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax WithStartQuerySemicolon(SyntaxToken startQuerySemicolon)
		{
			return this.Update(this.KQuery, this.QueryHeader, this.Comment, StartQuerySemicolon, this.QueryExternalParameters, this.QueryField, this.FunctionDeclaration, this.QueryObject, this.KEndQuery, this.EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax WithQueryExternalParameters(SyntaxList<QueryExternalParametersSyntax> queryExternalParameters)
		{
			return this.Update(this.KQuery, this.QueryHeader, this.Comment, this.StartQuerySemicolon, QueryExternalParameters, this.QueryField, this.FunctionDeclaration, this.QueryObject, this.KEndQuery, this.EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax AddQueryExternalParameters(params QueryExternalParametersSyntax[] queryExternalParameters)
		{
			return this.WithQueryExternalParameters(this.QueryExternalParameters.AddRange(queryExternalParameters));
		}
	
	    public QueryDeclarationSyntax WithQueryField(SyntaxList<QueryFieldSyntax> queryField)
		{
			return this.Update(this.KQuery, this.QueryHeader, this.Comment, this.StartQuerySemicolon, this.QueryExternalParameters, QueryField, this.FunctionDeclaration, this.QueryObject, this.KEndQuery, this.EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax AddQueryField(params QueryFieldSyntax[] queryField)
		{
			return this.WithQueryField(this.QueryField.AddRange(queryField));
		}
	
	    public QueryDeclarationSyntax WithFunctionDeclaration(SyntaxList<FunctionDeclarationSyntax> functionDeclaration)
		{
			return this.Update(this.KQuery, this.QueryHeader, this.Comment, this.StartQuerySemicolon, this.QueryExternalParameters, this.QueryField, FunctionDeclaration, this.QueryObject, this.KEndQuery, this.EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax AddFunctionDeclaration(params FunctionDeclarationSyntax[] functionDeclaration)
		{
			return this.WithFunctionDeclaration(this.FunctionDeclaration.AddRange(functionDeclaration));
		}
	
	    public QueryDeclarationSyntax WithQueryObject(SyntaxList<QueryObjectSyntax> queryObject)
		{
			return this.Update(this.KQuery, this.QueryHeader, this.Comment, this.StartQuerySemicolon, this.QueryExternalParameters, this.QueryField, this.FunctionDeclaration, QueryObject, this.KEndQuery, this.EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax AddQueryObject(params QueryObjectSyntax[] queryObject)
		{
			return this.WithQueryObject(this.QueryObject.AddRange(queryObject));
		}
	
	    public QueryDeclarationSyntax WithKEndQuery(SyntaxToken kEndQuery)
		{
			return this.Update(this.KQuery, this.QueryHeader, this.Comment, this.StartQuerySemicolon, this.QueryExternalParameters, this.QueryField, this.FunctionDeclaration, this.QueryObject, KEndQuery, this.EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax WithEndName(IdentifierSyntax endName)
		{
			return this.Update(this.KQuery, this.QueryHeader, this.Comment, this.StartQuerySemicolon, this.QueryExternalParameters, this.QueryField, this.FunctionDeclaration, this.QueryObject, this.KEndQuery, EndName, this.EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax WithEndQuerySemicolon(SyntaxToken endQuerySemicolon)
		{
			return this.Update(this.KQuery, this.QueryHeader, this.Comment, this.StartQuerySemicolon, this.QueryExternalParameters, this.QueryField, this.FunctionDeclaration, this.QueryObject, this.KEndQuery, this.EndName, EndQuerySemicolon);
		}
	
	    public QueryDeclarationSyntax Update(SyntaxToken kQuery, QueryHeaderSyntax queryHeader, CommentSyntax comment, SyntaxToken startQuerySemicolon, SyntaxList<QueryExternalParametersSyntax> queryExternalParameters, SyntaxList<QueryFieldSyntax> queryField, SyntaxList<FunctionDeclarationSyntax> functionDeclaration, SyntaxList<QueryObjectSyntax> queryObject, SyntaxToken kEndQuery, IdentifierSyntax endName, SyntaxToken endQuerySemicolon)
	    {
	        if (this.KQuery != kQuery ||
				this.QueryHeader != queryHeader ||
				this.Comment != comment ||
				this.StartQuerySemicolon != startQuerySemicolon ||
				this.QueryExternalParameters != queryExternalParameters ||
				this.QueryField != queryField ||
				this.FunctionDeclaration != functionDeclaration ||
				this.QueryObject != queryObject ||
				this.KEndQuery != kEndQuery ||
				this.EndName != endName ||
				this.EndQuerySemicolon != endQuerySemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryDeclaration(kQuery, queryHeader, comment, startQuerySemicolon, queryExternalParameters, queryField, functionDeclaration, queryObject, kEndQuery, endName, endQuerySemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryDeclaration(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryDeclaration(this);
	    }
	}
	
	public sealed class QueryHeaderSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	    private QueryRequestParamsSyntax queryRequestParams;
	
	    public QueryHeaderSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryHeaderSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 0); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryHeaderGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public QueryRequestParamsSyntax QueryRequestParams 
		{ 
			get { return this.GetRed(ref this.queryRequestParams, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryHeaderGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.name, 0);
				case 2: return this.GetRed(ref this.queryRequestParams, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.name;
				case 2: return this.queryRequestParams;
				default: return null;
	        }
	    }
	
	    public QueryHeaderSyntax WithName(NameSyntax name)
		{
			return this.Update(Name, this.TOpenParen, this.QueryRequestParams, this.TCloseParen);
		}
	
	    public QueryHeaderSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Name, TOpenParen, this.QueryRequestParams, this.TCloseParen);
		}
	
	    public QueryHeaderSyntax WithQueryRequestParams(QueryRequestParamsSyntax queryRequestParams)
		{
			return this.Update(this.Name, this.TOpenParen, QueryRequestParams, this.TCloseParen);
		}
	
	    public QueryHeaderSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Name, this.TOpenParen, this.QueryRequestParams, TCloseParen);
		}
	
	    public QueryHeaderSyntax Update(NameSyntax name, SyntaxToken tOpenParen, QueryRequestParamsSyntax queryRequestParams, SyntaxToken tCloseParen)
	    {
	        if (this.Name != name ||
				this.TOpenParen != tOpenParen ||
				this.QueryRequestParams != queryRequestParams ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryHeader(name, tOpenParen, queryRequestParams, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryHeaderSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryHeader(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryHeader(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryHeader(this);
	    }
	}
	
	public sealed class QueryRequestParamsSyntax : PilSyntaxNode
	{
	    private SyntaxNode param;
	
	    public QueryRequestParamsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryRequestParamsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KRequest 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryRequestParamsGreen)this.Green;
				var greenToken = green.KRequest;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SeparatedSyntaxList<ParamSyntax> Param 
		{ 
			get
			{
				var red = this.GetRed(ref this.param, 1);
				if (red != null)
				{
					return new SeparatedSyntaxList<ParamSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryRequestParamsGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.param, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.param;
				default: return null;
	        }
	    }
	
	    public QueryRequestParamsSyntax WithKRequest(SyntaxToken kRequest)
		{
			return this.Update(KRequest, this.Param, this.TSemicolon);
		}
	
	    public QueryRequestParamsSyntax WithParam(SeparatedSyntaxList<ParamSyntax> param)
		{
			return this.Update(this.KRequest, Param, this.TSemicolon);
		}
	
	    public QueryRequestParamsSyntax AddParam(params ParamSyntax[] param)
		{
			return this.WithParam(this.Param.AddRange(param));
		}
	
	    public QueryRequestParamsSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KRequest, this.Param, TSemicolon);
		}
	
	    public QueryRequestParamsSyntax Update(SyntaxToken kRequest, SeparatedSyntaxList<ParamSyntax> param, SyntaxToken tSemicolon)
	    {
	        if (this.KRequest != kRequest ||
				this.Param != param ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryRequestParams(kRequest, param, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryRequestParamsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryRequestParams(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryRequestParams(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryRequestParams(this);
	    }
	}
	
	public sealed class QueryAcceptParamsSyntax : PilSyntaxNode
	{
	    private SyntaxNode param;
	
	    public QueryAcceptParamsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryAcceptParamsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KAccept 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryAcceptParamsGreen)this.Green;
				var greenToken = green.KAccept;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SeparatedSyntaxList<ParamSyntax> Param 
		{ 
			get
			{
				var red = this.GetRed(ref this.param, 1);
				if (red != null)
				{
					return new SeparatedSyntaxList<ParamSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryAcceptParamsGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.param, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.param;
				default: return null;
	        }
	    }
	
	    public QueryAcceptParamsSyntax WithKAccept(SyntaxToken kAccept)
		{
			return this.Update(KAccept, this.Param, this.TSemicolon);
		}
	
	    public QueryAcceptParamsSyntax WithParam(SeparatedSyntaxList<ParamSyntax> param)
		{
			return this.Update(this.KAccept, Param, this.TSemicolon);
		}
	
	    public QueryAcceptParamsSyntax AddParam(params ParamSyntax[] param)
		{
			return this.WithParam(this.Param.AddRange(param));
		}
	
	    public QueryAcceptParamsSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KAccept, this.Param, TSemicolon);
		}
	
	    public QueryAcceptParamsSyntax Update(SyntaxToken kAccept, SeparatedSyntaxList<ParamSyntax> param, SyntaxToken tSemicolon)
	    {
	        if (this.KAccept != kAccept ||
				this.Param != param ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryAcceptParams(kAccept, param, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryAcceptParamsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryAcceptParams(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryAcceptParams(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryAcceptParams(this);
	    }
	}
	
	public sealed class QueryRefuseParamsSyntax : PilSyntaxNode
	{
	    private SyntaxNode param;
	
	    public QueryRefuseParamsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryRefuseParamsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KRefuse 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryRefuseParamsGreen)this.Green;
				var greenToken = green.KRefuse;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SeparatedSyntaxList<ParamSyntax> Param 
		{ 
			get
			{
				var red = this.GetRed(ref this.param, 1);
				if (red != null)
				{
					return new SeparatedSyntaxList<ParamSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryRefuseParamsGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.param, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.param;
				default: return null;
	        }
	    }
	
	    public QueryRefuseParamsSyntax WithKRefuse(SyntaxToken kRefuse)
		{
			return this.Update(KRefuse, this.Param, this.TSemicolon);
		}
	
	    public QueryRefuseParamsSyntax WithParam(SeparatedSyntaxList<ParamSyntax> param)
		{
			return this.Update(this.KRefuse, Param, this.TSemicolon);
		}
	
	    public QueryRefuseParamsSyntax AddParam(params ParamSyntax[] param)
		{
			return this.WithParam(this.Param.AddRange(param));
		}
	
	    public QueryRefuseParamsSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KRefuse, this.Param, TSemicolon);
		}
	
	    public QueryRefuseParamsSyntax Update(SyntaxToken kRefuse, SeparatedSyntaxList<ParamSyntax> param, SyntaxToken tSemicolon)
	    {
	        if (this.KRefuse != kRefuse ||
				this.Param != param ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryRefuseParams(kRefuse, param, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryRefuseParamsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryRefuseParams(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryRefuseParams(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryRefuseParams(this);
	    }
	}
	
	public sealed class QueryCancelParamsSyntax : PilSyntaxNode
	{
	    private SyntaxNode param;
	
	    public QueryCancelParamsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryCancelParamsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KCancel 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryCancelParamsGreen)this.Green;
				var greenToken = green.KCancel;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SeparatedSyntaxList<ParamSyntax> Param 
		{ 
			get
			{
				var red = this.GetRed(ref this.param, 1);
				if (red != null)
				{
					return new SeparatedSyntaxList<ParamSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryCancelParamsGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.param, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.param;
				default: return null;
	        }
	    }
	
	    public QueryCancelParamsSyntax WithKCancel(SyntaxToken kCancel)
		{
			return this.Update(KCancel, this.Param, this.TSemicolon);
		}
	
	    public QueryCancelParamsSyntax WithParam(SeparatedSyntaxList<ParamSyntax> param)
		{
			return this.Update(this.KCancel, Param, this.TSemicolon);
		}
	
	    public QueryCancelParamsSyntax AddParam(params ParamSyntax[] param)
		{
			return this.WithParam(this.Param.AddRange(param));
		}
	
	    public QueryCancelParamsSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KCancel, this.Param, TSemicolon);
		}
	
	    public QueryCancelParamsSyntax Update(SyntaxToken kCancel, SeparatedSyntaxList<ParamSyntax> param, SyntaxToken tSemicolon)
	    {
	        if (this.KCancel != kCancel ||
				this.Param != param ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryCancelParams(kCancel, param, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryCancelParamsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryCancelParams(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryCancelParams(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryCancelParams(this);
	    }
	}
	
	public sealed class QueryExternalParametersSyntax : PilSyntaxNode
	{
	    private ExternalParameterDeclarationSyntax externalParameterDeclaration;
	
	    public QueryExternalParametersSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryExternalParametersSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExternalParameterDeclarationSyntax ExternalParameterDeclaration 
		{ 
			get { return this.GetRed(ref this.externalParameterDeclaration, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.externalParameterDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.externalParameterDeclaration;
				default: return null;
	        }
	    }
	
	    public QueryExternalParametersSyntax WithExternalParameterDeclaration(ExternalParameterDeclarationSyntax externalParameterDeclaration)
		{
			return this.Update(ExternalParameterDeclaration);
		}
	
	    public QueryExternalParametersSyntax Update(ExternalParameterDeclarationSyntax externalParameterDeclaration)
	    {
	        if (this.ExternalParameterDeclaration != externalParameterDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryExternalParameters(externalParameterDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryExternalParametersSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryExternalParameters(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryExternalParameters(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryExternalParameters(this);
	    }
	}
	
	public sealed class QueryFieldSyntax : PilSyntaxNode
	{
	    private VariableDeclarationSyntax variableDeclaration;
	
	    public QueryFieldSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryFieldSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VariableDeclarationSyntax VariableDeclaration 
		{ 
			get { return this.GetRed(ref this.variableDeclaration, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableDeclaration;
				default: return null;
	        }
	    }
	
	    public QueryFieldSyntax WithVariableDeclaration(VariableDeclarationSyntax variableDeclaration)
		{
			return this.Update(VariableDeclaration);
		}
	
	    public QueryFieldSyntax Update(VariableDeclarationSyntax variableDeclaration)
	    {
	        if (this.VariableDeclaration != variableDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryField(variableDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryFieldSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryField(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryField(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryField(this);
	    }
	}
	
	public sealed class QueryFunctionSyntax : PilSyntaxNode
	{
	    private FunctionDeclarationSyntax functionDeclaration;
	
	    public QueryFunctionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryFunctionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public FunctionDeclarationSyntax FunctionDeclaration 
		{ 
			get { return this.GetRed(ref this.functionDeclaration, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.functionDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.functionDeclaration;
				default: return null;
	        }
	    }
	
	    public QueryFunctionSyntax WithFunctionDeclaration(FunctionDeclarationSyntax functionDeclaration)
		{
			return this.Update(FunctionDeclaration);
		}
	
	    public QueryFunctionSyntax Update(FunctionDeclarationSyntax functionDeclaration)
	    {
	        if (this.FunctionDeclaration != functionDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryFunction(functionDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryFunctionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryFunction(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryFunction(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryFunction(this);
	    }
	}
	
	public sealed class QueryObjectSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	    private CommentSyntax comment;
	    private SyntaxNode queryObjectField;
	    private SyntaxNode queryObjectFunction;
	    private SyntaxNode queryObjectEvent;
	    private IdentifierSyntax endName;
	
	    public QueryObjectSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryObjectSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KObject 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryObjectGreen)this.Green;
				var greenToken = green.KObject;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Name 
		{ 
			get { return this.GetRed(ref this.name, 1); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 2); } 
		}
	    public SyntaxToken StartObjectSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryObjectGreen)this.Green;
				var greenToken = green.StartObjectSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public SyntaxList<QueryObjectFieldSyntax> QueryObjectField 
		{ 
			get
			{
				var red = this.GetRed(ref this.queryObjectField, 4);
				if (red != null) return new SyntaxList<QueryObjectFieldSyntax>(red);
				return default;
			} 
		}
	    public SyntaxList<QueryObjectFunctionSyntax> QueryObjectFunction 
		{ 
			get
			{
				var red = this.GetRed(ref this.queryObjectFunction, 5);
				if (red != null) return new SyntaxList<QueryObjectFunctionSyntax>(red);
				return default;
			} 
		}
	    public SyntaxList<QueryObjectEventSyntax> QueryObjectEvent 
		{ 
			get
			{
				var red = this.GetRed(ref this.queryObjectEvent, 6);
				if (red != null) return new SyntaxList<QueryObjectEventSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KEndObject 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryObjectGreen)this.Green;
				var greenToken = green.KEndObject;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(7), this.GetChildIndex(7));
			}
		}
	    public IdentifierSyntax EndName 
		{ 
			get { return this.GetRed(ref this.endName, 8); } 
		}
	    public SyntaxToken EndObjectSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.QueryObjectGreen)this.Green;
				var greenToken = green.EndObjectSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(9), this.GetChildIndex(9));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 2: return this.GetRed(ref this.comment, 2);
				case 4: return this.GetRed(ref this.queryObjectField, 4);
				case 5: return this.GetRed(ref this.queryObjectFunction, 5);
				case 6: return this.GetRed(ref this.queryObjectEvent, 6);
				case 8: return this.GetRed(ref this.endName, 8);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 2: return this.comment;
				case 4: return this.queryObjectField;
				case 5: return this.queryObjectFunction;
				case 6: return this.queryObjectEvent;
				case 8: return this.endName;
				default: return null;
	        }
	    }
	
	    public QueryObjectSyntax WithKObject(SyntaxToken kObject)
		{
			return this.Update(KObject, this.Name, this.Comment, this.StartObjectSemicolon, this.QueryObjectField, this.QueryObjectFunction, this.QueryObjectEvent, this.KEndObject, this.EndName, this.EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KObject, Name, this.Comment, this.StartObjectSemicolon, this.QueryObjectField, this.QueryObjectFunction, this.QueryObjectEvent, this.KEndObject, this.EndName, this.EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KObject, this.Name, Comment, this.StartObjectSemicolon, this.QueryObjectField, this.QueryObjectFunction, this.QueryObjectEvent, this.KEndObject, this.EndName, this.EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax WithStartObjectSemicolon(SyntaxToken startObjectSemicolon)
		{
			return this.Update(this.KObject, this.Name, this.Comment, StartObjectSemicolon, this.QueryObjectField, this.QueryObjectFunction, this.QueryObjectEvent, this.KEndObject, this.EndName, this.EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax WithQueryObjectField(SyntaxList<QueryObjectFieldSyntax> queryObjectField)
		{
			return this.Update(this.KObject, this.Name, this.Comment, this.StartObjectSemicolon, QueryObjectField, this.QueryObjectFunction, this.QueryObjectEvent, this.KEndObject, this.EndName, this.EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax AddQueryObjectField(params QueryObjectFieldSyntax[] queryObjectField)
		{
			return this.WithQueryObjectField(this.QueryObjectField.AddRange(queryObjectField));
		}
	
	    public QueryObjectSyntax WithQueryObjectFunction(SyntaxList<QueryObjectFunctionSyntax> queryObjectFunction)
		{
			return this.Update(this.KObject, this.Name, this.Comment, this.StartObjectSemicolon, this.QueryObjectField, QueryObjectFunction, this.QueryObjectEvent, this.KEndObject, this.EndName, this.EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax AddQueryObjectFunction(params QueryObjectFunctionSyntax[] queryObjectFunction)
		{
			return this.WithQueryObjectFunction(this.QueryObjectFunction.AddRange(queryObjectFunction));
		}
	
	    public QueryObjectSyntax WithQueryObjectEvent(SyntaxList<QueryObjectEventSyntax> queryObjectEvent)
		{
			return this.Update(this.KObject, this.Name, this.Comment, this.StartObjectSemicolon, this.QueryObjectField, this.QueryObjectFunction, QueryObjectEvent, this.KEndObject, this.EndName, this.EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax AddQueryObjectEvent(params QueryObjectEventSyntax[] queryObjectEvent)
		{
			return this.WithQueryObjectEvent(this.QueryObjectEvent.AddRange(queryObjectEvent));
		}
	
	    public QueryObjectSyntax WithKEndObject(SyntaxToken kEndObject)
		{
			return this.Update(this.KObject, this.Name, this.Comment, this.StartObjectSemicolon, this.QueryObjectField, this.QueryObjectFunction, this.QueryObjectEvent, KEndObject, this.EndName, this.EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax WithEndName(IdentifierSyntax endName)
		{
			return this.Update(this.KObject, this.Name, this.Comment, this.StartObjectSemicolon, this.QueryObjectField, this.QueryObjectFunction, this.QueryObjectEvent, this.KEndObject, EndName, this.EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax WithEndObjectSemicolon(SyntaxToken endObjectSemicolon)
		{
			return this.Update(this.KObject, this.Name, this.Comment, this.StartObjectSemicolon, this.QueryObjectField, this.QueryObjectFunction, this.QueryObjectEvent, this.KEndObject, this.EndName, EndObjectSemicolon);
		}
	
	    public QueryObjectSyntax Update(SyntaxToken kObject, NameSyntax name, CommentSyntax comment, SyntaxToken startObjectSemicolon, SyntaxList<QueryObjectFieldSyntax> queryObjectField, SyntaxList<QueryObjectFunctionSyntax> queryObjectFunction, SyntaxList<QueryObjectEventSyntax> queryObjectEvent, SyntaxToken kEndObject, IdentifierSyntax endName, SyntaxToken endObjectSemicolon)
	    {
	        if (this.KObject != kObject ||
				this.Name != name ||
				this.Comment != comment ||
				this.StartObjectSemicolon != startObjectSemicolon ||
				this.QueryObjectField != queryObjectField ||
				this.QueryObjectFunction != queryObjectFunction ||
				this.QueryObjectEvent != queryObjectEvent ||
				this.KEndObject != kEndObject ||
				this.EndName != endName ||
				this.EndObjectSemicolon != endObjectSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryObject(kObject, name, comment, startObjectSemicolon, queryObjectField, queryObjectFunction, queryObjectEvent, kEndObject, endName, endObjectSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryObject(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryObject(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryObject(this);
	    }
	}
	
	public sealed class QueryObjectFieldSyntax : PilSyntaxNode
	{
	    private VariableDeclarationSyntax variableDeclaration;
	
	    public QueryObjectFieldSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryObjectFieldSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VariableDeclarationSyntax VariableDeclaration 
		{ 
			get { return this.GetRed(ref this.variableDeclaration, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableDeclaration;
				default: return null;
	        }
	    }
	
	    public QueryObjectFieldSyntax WithVariableDeclaration(VariableDeclarationSyntax variableDeclaration)
		{
			return this.Update(VariableDeclaration);
		}
	
	    public QueryObjectFieldSyntax Update(VariableDeclarationSyntax variableDeclaration)
	    {
	        if (this.VariableDeclaration != variableDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryObjectField(variableDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectFieldSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryObjectField(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryObjectField(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryObjectField(this);
	    }
	}
	
	public sealed class QueryObjectFunctionSyntax : PilSyntaxNode
	{
	    private FunctionDeclarationSyntax functionDeclaration;
	
	    public QueryObjectFunctionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryObjectFunctionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public FunctionDeclarationSyntax FunctionDeclaration 
		{ 
			get { return this.GetRed(ref this.functionDeclaration, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.functionDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.functionDeclaration;
				default: return null;
	        }
	    }
	
	    public QueryObjectFunctionSyntax WithFunctionDeclaration(FunctionDeclarationSyntax functionDeclaration)
		{
			return this.Update(FunctionDeclaration);
		}
	
	    public QueryObjectFunctionSyntax Update(FunctionDeclarationSyntax functionDeclaration)
	    {
	        if (this.FunctionDeclaration != functionDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryObjectFunction(functionDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectFunctionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryObjectFunction(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryObjectFunction(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryObjectFunction(this);
	    }
	}
	
	public sealed class QueryObjectEventSyntax : PilSyntaxNode
	{
	    private InputSyntax input;
	    private TriggerSyntax trigger;
	
	    public QueryObjectEventSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QueryObjectEventSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public InputSyntax Input 
		{ 
			get { return this.GetRed(ref this.input, 0); } 
		}
	    public TriggerSyntax Trigger 
		{ 
			get { return this.GetRed(ref this.trigger, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.input, 0);
				case 1: return this.GetRed(ref this.trigger, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.input;
				case 1: return this.trigger;
				default: return null;
	        }
	    }
	
	    public QueryObjectEventSyntax WithInput(InputSyntax input)
		{
			return this.Update(input);
		}
	
	    public QueryObjectEventSyntax WithTrigger(TriggerSyntax trigger)
		{
			return this.Update(trigger);
		}
	
	    public QueryObjectEventSyntax Update(InputSyntax input)
	    {
	        if (this.Input != input)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryObjectEvent(input);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectEventSyntax)newNode;
	        }
	        return this;
	    }
	
	    public QueryObjectEventSyntax Update(TriggerSyntax trigger)
	    {
	        if (this.Trigger != trigger)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.QueryObjectEvent(trigger);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QueryObjectEventSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQueryObjectEvent(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQueryObjectEvent(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQueryObjectEvent(this);
	    }
	}
	
	public sealed class InputSyntax : PilSyntaxNode
	{
	    private InputPortListSyntax inputPortList;
	    private CommentSyntax comment;
	    private StatementsSyntax statements;
	
	    public InputSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InputSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KInput 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.InputGreen)this.Green;
				var greenToken = green.KInput;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public InputPortListSyntax InputPortList 
		{ 
			get { return this.GetRed(ref this.inputPortList, 1); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.InputGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public StatementsSyntax Statements 
		{ 
			get { return this.GetRed(ref this.statements, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.inputPortList, 1);
				case 2: return this.GetRed(ref this.comment, 2);
				case 4: return this.GetRed(ref this.statements, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.inputPortList;
				case 2: return this.comment;
				case 4: return this.statements;
				default: return null;
	        }
	    }
	
	    public InputSyntax WithKInput(SyntaxToken kInput)
		{
			return this.Update(KInput, this.InputPortList, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public InputSyntax WithInputPortList(InputPortListSyntax inputPortList)
		{
			return this.Update(this.KInput, InputPortList, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public InputSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KInput, this.InputPortList, Comment, this.TSemicolon, this.Statements);
		}
	
	    public InputSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KInput, this.InputPortList, this.Comment, TSemicolon, this.Statements);
		}
	
	    public InputSyntax WithStatements(StatementsSyntax statements)
		{
			return this.Update(this.KInput, this.InputPortList, this.Comment, this.TSemicolon, Statements);
		}
	
	    public InputSyntax Update(SyntaxToken kInput, InputPortListSyntax inputPortList, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
	    {
	        if (this.KInput != kInput ||
				this.InputPortList != inputPortList ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Input(kInput, inputPortList, comment, tSemicolon, statements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InputSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitInput(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInput(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitInput(this);
	    }
	}
	
	public sealed class InputPortListSyntax : PilSyntaxNode
	{
	    private SyntaxNode inputPort;
	
	    public InputPortListSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InputPortListSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<InputPortSyntax> InputPort 
		{ 
			get
			{
				var red = this.GetRed(ref this.inputPort, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<InputPortSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.inputPort, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.inputPort;
				default: return null;
	        }
	    }
	
	    public InputPortListSyntax WithInputPort(SeparatedSyntaxList<InputPortSyntax> inputPort)
		{
			return this.Update(InputPort);
		}
	
	    public InputPortListSyntax AddInputPort(params InputPortSyntax[] inputPort)
		{
			return this.WithInputPort(this.InputPort.AddRange(inputPort));
		}
	
	    public InputPortListSyntax Update(SeparatedSyntaxList<InputPortSyntax> inputPort)
	    {
	        if (this.InputPort != inputPort)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.InputPortList(inputPort);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InputPortListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitInputPortList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInputPortList(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitInputPortList(this);
	    }
	}
	
	public sealed class InputPortSyntax : PilSyntaxNode
	{
	    private IdentifierSyntax portName;
	    private IdentifierSyntax queryName;
	
	    public InputPortSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public InputPortSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax PortName 
		{ 
			get { return this.GetRed(ref this.portName, 0); } 
		}
	    public SyntaxToken TDot 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.InputPortGreen)this.Green;
				var greenToken = green.TDot;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IdentifierSyntax QueryName 
		{ 
			get { return this.GetRed(ref this.queryName, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.portName, 0);
				case 2: return this.GetRed(ref this.queryName, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.portName;
				case 2: return this.queryName;
				default: return null;
	        }
	    }
	
	    public InputPortSyntax WithPortName(IdentifierSyntax portName)
		{
			return this.Update(PortName, this.TDot, this.QueryName);
		}
	
	    public InputPortSyntax WithTDot(SyntaxToken tDot)
		{
			return this.Update(this.PortName, TDot, this.QueryName);
		}
	
	    public InputPortSyntax WithQueryName(IdentifierSyntax queryName)
		{
			return this.Update(this.PortName, this.TDot, QueryName);
		}
	
	    public InputPortSyntax Update(IdentifierSyntax portName, SyntaxToken tDot, IdentifierSyntax queryName)
	    {
	        if (this.PortName != portName ||
				this.TDot != tDot ||
				this.QueryName != queryName)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.InputPort(portName, tDot, queryName);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (InputPortSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitInputPort(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitInputPort(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitInputPort(this);
	    }
	}
	
	public sealed class TriggerSyntax : PilSyntaxNode
	{
	    private TriggerVarListSyntax triggerVarList;
	    private CommentSyntax comment;
	    private StatementsSyntax statements;
	
	    public TriggerSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TriggerSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTrigger 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.TriggerGreen)this.Green;
				var greenToken = green.KTrigger;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TriggerVarListSyntax TriggerVarList 
		{ 
			get { return this.GetRed(ref this.triggerVarList, 1); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.TriggerGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public StatementsSyntax Statements 
		{ 
			get { return this.GetRed(ref this.statements, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.triggerVarList, 1);
				case 2: return this.GetRed(ref this.comment, 2);
				case 4: return this.GetRed(ref this.statements, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.triggerVarList;
				case 2: return this.comment;
				case 4: return this.statements;
				default: return null;
	        }
	    }
	
	    public TriggerSyntax WithKTrigger(SyntaxToken kTrigger)
		{
			return this.Update(KTrigger, this.TriggerVarList, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public TriggerSyntax WithTriggerVarList(TriggerVarListSyntax triggerVarList)
		{
			return this.Update(this.KTrigger, TriggerVarList, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public TriggerSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KTrigger, this.TriggerVarList, Comment, this.TSemicolon, this.Statements);
		}
	
	    public TriggerSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KTrigger, this.TriggerVarList, this.Comment, TSemicolon, this.Statements);
		}
	
	    public TriggerSyntax WithStatements(StatementsSyntax statements)
		{
			return this.Update(this.KTrigger, this.TriggerVarList, this.Comment, this.TSemicolon, Statements);
		}
	
	    public TriggerSyntax Update(SyntaxToken kTrigger, TriggerVarListSyntax triggerVarList, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
	    {
	        if (this.KTrigger != kTrigger ||
				this.TriggerVarList != triggerVarList ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Trigger(kTrigger, triggerVarList, comment, tSemicolon, statements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TriggerSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTrigger(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTrigger(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitTrigger(this);
	    }
	}
	
	public sealed class TriggerVarListSyntax : PilSyntaxNode
	{
	    private SyntaxNode triggerVar;
	
	    public TriggerVarListSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TriggerVarListSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<TriggerVarSyntax> TriggerVar 
		{ 
			get
			{
				var red = this.GetRed(ref this.triggerVar, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<TriggerVarSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.triggerVar, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.triggerVar;
				default: return null;
	        }
	    }
	
	    public TriggerVarListSyntax WithTriggerVar(SeparatedSyntaxList<TriggerVarSyntax> triggerVar)
		{
			return this.Update(TriggerVar);
		}
	
	    public TriggerVarListSyntax AddTriggerVar(params TriggerVarSyntax[] triggerVar)
		{
			return this.WithTriggerVar(this.TriggerVar.AddRange(triggerVar));
		}
	
	    public TriggerVarListSyntax Update(SeparatedSyntaxList<TriggerVarSyntax> triggerVar)
	    {
	        if (this.TriggerVar != triggerVar)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TriggerVarList(triggerVar);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TriggerVarListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTriggerVarList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTriggerVarList(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitTriggerVarList(this);
	    }
	}
	
	public sealed class TriggerVarSyntax : PilSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public TriggerVarSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TriggerVarSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
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
	
	    public TriggerVarSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public TriggerVarSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TriggerVar(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TriggerVarSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTriggerVar(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTriggerVar(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitTriggerVar(this);
	    }
	}
	
	public sealed class StatementsSyntax : PilSyntaxNode
	{
	    private SyntaxNode statement;
	
	    public StatementsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StatementsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<StatementSyntax> Statement 
		{ 
			get
			{
				var red = this.GetRed(ref this.statement, 0);
				if (red != null) return new SyntaxList<StatementSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.statement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.statement;
				default: return null;
	        }
	    }
	
	    public StatementsSyntax WithStatement(SyntaxList<StatementSyntax> statement)
		{
			return this.Update(Statement);
		}
	
	    public StatementsSyntax AddStatement(params StatementSyntax[] statement)
		{
			return this.WithStatement(this.Statement.AddRange(statement));
		}
	
	    public StatementsSyntax Update(SyntaxList<StatementSyntax> statement)
	    {
	        if (this.Statement != statement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Statements(statement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStatements(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStatements(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitStatements(this);
	    }
	}
	
	public sealed class StatementSyntax : PilSyntaxNode
	{
	    private VariableDeclarationStatementSyntax variableDeclarationStatement;
	    private RequestStatementSyntax requestStatement;
	    private ForkStatementSyntax forkStatement;
	    private ForkRequestStatementSyntax forkRequestStatement;
	    private IfStatementSyntax ifStatement;
	    private ResponseStatementSyntax responseStatement;
	    private CancelStatementSyntax cancelStatement;
	    private AssignmentStatementSyntax assignmentStatement;
	
	    public StatementSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StatementSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VariableDeclarationStatementSyntax VariableDeclarationStatement 
		{ 
			get { return this.GetRed(ref this.variableDeclarationStatement, 0); } 
		}
	    public RequestStatementSyntax RequestStatement 
		{ 
			get { return this.GetRed(ref this.requestStatement, 1); } 
		}
	    public ForkStatementSyntax ForkStatement 
		{ 
			get { return this.GetRed(ref this.forkStatement, 2); } 
		}
	    public ForkRequestStatementSyntax ForkRequestStatement 
		{ 
			get { return this.GetRed(ref this.forkRequestStatement, 3); } 
		}
	    public IfStatementSyntax IfStatement 
		{ 
			get { return this.GetRed(ref this.ifStatement, 4); } 
		}
	    public ResponseStatementSyntax ResponseStatement 
		{ 
			get { return this.GetRed(ref this.responseStatement, 5); } 
		}
	    public CancelStatementSyntax CancelStatement 
		{ 
			get { return this.GetRed(ref this.cancelStatement, 6); } 
		}
	    public AssignmentStatementSyntax AssignmentStatement 
		{ 
			get { return this.GetRed(ref this.assignmentStatement, 7); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableDeclarationStatement, 0);
				case 1: return this.GetRed(ref this.requestStatement, 1);
				case 2: return this.GetRed(ref this.forkStatement, 2);
				case 3: return this.GetRed(ref this.forkRequestStatement, 3);
				case 4: return this.GetRed(ref this.ifStatement, 4);
				case 5: return this.GetRed(ref this.responseStatement, 5);
				case 6: return this.GetRed(ref this.cancelStatement, 6);
				case 7: return this.GetRed(ref this.assignmentStatement, 7);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableDeclarationStatement;
				case 1: return this.requestStatement;
				case 2: return this.forkStatement;
				case 3: return this.forkRequestStatement;
				case 4: return this.ifStatement;
				case 5: return this.responseStatement;
				case 6: return this.cancelStatement;
				case 7: return this.assignmentStatement;
				default: return null;
	        }
	    }
	
	    public StatementSyntax WithVariableDeclarationStatement(VariableDeclarationStatementSyntax variableDeclarationStatement)
		{
			return this.Update(variableDeclarationStatement);
		}
	
	    public StatementSyntax WithRequestStatement(RequestStatementSyntax requestStatement)
		{
			return this.Update(requestStatement);
		}
	
	    public StatementSyntax WithForkStatement(ForkStatementSyntax forkStatement)
		{
			return this.Update(forkStatement);
		}
	
	    public StatementSyntax WithForkRequestStatement(ForkRequestStatementSyntax forkRequestStatement)
		{
			return this.Update(forkRequestStatement);
		}
	
	    public StatementSyntax WithIfStatement(IfStatementSyntax ifStatement)
		{
			return this.Update(ifStatement);
		}
	
	    public StatementSyntax WithResponseStatement(ResponseStatementSyntax responseStatement)
		{
			return this.Update(responseStatement);
		}
	
	    public StatementSyntax WithCancelStatement(CancelStatementSyntax cancelStatement)
		{
			return this.Update(cancelStatement);
		}
	
	    public StatementSyntax WithAssignmentStatement(AssignmentStatementSyntax assignmentStatement)
		{
			return this.Update(assignmentStatement);
		}
	
	    public StatementSyntax Update(VariableDeclarationStatementSyntax variableDeclarationStatement)
	    {
	        if (this.VariableDeclarationStatement != variableDeclarationStatement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Statement(variableDeclarationStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(RequestStatementSyntax requestStatement)
	    {
	        if (this.RequestStatement != requestStatement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Statement(requestStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(ForkStatementSyntax forkStatement)
	    {
	        if (this.ForkStatement != forkStatement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Statement(forkStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(ForkRequestStatementSyntax forkRequestStatement)
	    {
	        if (this.ForkRequestStatement != forkRequestStatement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Statement(forkRequestStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(IfStatementSyntax ifStatement)
	    {
	        if (this.IfStatement != ifStatement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Statement(ifStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(ResponseStatementSyntax responseStatement)
	    {
	        if (this.ResponseStatement != responseStatement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Statement(responseStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(CancelStatementSyntax cancelStatement)
	    {
	        if (this.CancelStatement != cancelStatement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Statement(cancelStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(AssignmentStatementSyntax assignmentStatement)
	    {
	        if (this.AssignmentStatement != assignmentStatement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Statement(assignmentStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStatement(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitStatement(this);
	    }
	}
	
	public sealed class ForkStatementSyntax : PilSyntaxNode
	{
	    private ExpressionSyntax expression;
	    private SyntaxNode caseBranch;
	    private ElseBranchSyntax elseBranch;
	
	    public ForkStatementSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ForkStatementSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KFork 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ForkStatementGreen)this.Green;
				var greenToken = green.KFork;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	    public SyntaxList<CaseBranchSyntax> CaseBranch 
		{ 
			get
			{
				var red = this.GetRed(ref this.caseBranch, 2);
				if (red != null) return new SyntaxList<CaseBranchSyntax>(red);
				return default;
			} 
		}
	    public ElseBranchSyntax ElseBranch 
		{ 
			get { return this.GetRed(ref this.elseBranch, 3); } 
		}
	    public SyntaxToken KEndFork 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ForkStatementGreen)this.Green;
				var greenToken = green.KEndFork;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.expression, 1);
				case 2: return this.GetRed(ref this.caseBranch, 2);
				case 3: return this.GetRed(ref this.elseBranch, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.expression;
				case 2: return this.caseBranch;
				case 3: return this.elseBranch;
				default: return null;
	        }
	    }
	
	    public ForkStatementSyntax WithKFork(SyntaxToken kFork)
		{
			return this.Update(KFork, this.Expression, this.CaseBranch, this.ElseBranch, this.KEndFork);
		}
	
	    public ForkStatementSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KFork, Expression, this.CaseBranch, this.ElseBranch, this.KEndFork);
		}
	
	    public ForkStatementSyntax WithCaseBranch(SyntaxList<CaseBranchSyntax> caseBranch)
		{
			return this.Update(this.KFork, this.Expression, CaseBranch, this.ElseBranch, this.KEndFork);
		}
	
	    public ForkStatementSyntax AddCaseBranch(params CaseBranchSyntax[] caseBranch)
		{
			return this.WithCaseBranch(this.CaseBranch.AddRange(caseBranch));
		}
	
	    public ForkStatementSyntax WithElseBranch(ElseBranchSyntax elseBranch)
		{
			return this.Update(this.KFork, this.Expression, this.CaseBranch, ElseBranch, this.KEndFork);
		}
	
	    public ForkStatementSyntax WithKEndFork(SyntaxToken kEndFork)
		{
			return this.Update(this.KFork, this.Expression, this.CaseBranch, this.ElseBranch, KEndFork);
		}
	
	    public ForkStatementSyntax Update(SyntaxToken kFork, ExpressionSyntax expression, SyntaxList<CaseBranchSyntax> caseBranch, ElseBranchSyntax elseBranch, SyntaxToken kEndFork)
	    {
	        if (this.KFork != kFork ||
				this.Expression != expression ||
				this.CaseBranch != caseBranch ||
				this.ElseBranch != elseBranch ||
				this.KEndFork != kEndFork)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ForkStatement(kFork, expression, caseBranch, elseBranch, kEndFork);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitForkStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitForkStatement(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitForkStatement(this);
	    }
	}
	
	public sealed class CaseBranchSyntax : PilSyntaxNode
	{
	    private ExpressionSyntax condition;
	    private CommentSyntax comment;
	    private StatementsSyntax statements;
	
	    public CaseBranchSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CaseBranchSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KCase 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CaseBranchGreen)this.Green;
				var greenToken = green.KCase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 1); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CaseBranchGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public StatementsSyntax Statements 
		{ 
			get { return this.GetRed(ref this.statements, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.condition, 1);
				case 2: return this.GetRed(ref this.comment, 2);
				case 4: return this.GetRed(ref this.statements, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.condition;
				case 2: return this.comment;
				case 4: return this.statements;
				default: return null;
	        }
	    }
	
	    public CaseBranchSyntax WithKCase(SyntaxToken kCase)
		{
			return this.Update(KCase, this.Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public CaseBranchSyntax WithCondition(ExpressionSyntax condition)
		{
			return this.Update(this.KCase, Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public CaseBranchSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KCase, this.Condition, Comment, this.TSemicolon, this.Statements);
		}
	
	    public CaseBranchSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KCase, this.Condition, this.Comment, TSemicolon, this.Statements);
		}
	
	    public CaseBranchSyntax WithStatements(StatementsSyntax statements)
		{
			return this.Update(this.KCase, this.Condition, this.Comment, this.TSemicolon, Statements);
		}
	
	    public CaseBranchSyntax Update(SyntaxToken kCase, ExpressionSyntax condition, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
	    {
	        if (this.KCase != kCase ||
				this.Condition != condition ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.CaseBranch(kCase, condition, comment, tSemicolon, statements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CaseBranchSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCaseBranch(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCaseBranch(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitCaseBranch(this);
	    }
	}
	
	public sealed class ElseBranchSyntax : PilSyntaxNode
	{
	    private CommentSyntax comment;
	    private StatementsSyntax statements;
	
	    public ElseBranchSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElseBranchSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KElse 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ElseBranchGreen)this.Green;
				var greenToken = green.KElse;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 1); } 
		}
	    public StatementsSyntax Statements 
		{ 
			get { return this.GetRed(ref this.statements, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.comment, 1);
				case 2: return this.GetRed(ref this.statements, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.comment;
				case 2: return this.statements;
				default: return null;
	        }
	    }
	
	    public ElseBranchSyntax WithKElse(SyntaxToken kElse)
		{
			return this.Update(KElse, this.Comment, this.Statements);
		}
	
	    public ElseBranchSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KElse, Comment, this.Statements);
		}
	
	    public ElseBranchSyntax WithStatements(StatementsSyntax statements)
		{
			return this.Update(this.KElse, this.Comment, Statements);
		}
	
	    public ElseBranchSyntax Update(SyntaxToken kElse, CommentSyntax comment, StatementsSyntax statements)
	    {
	        if (this.KElse != kElse ||
				this.Comment != comment ||
				this.Statements != statements)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ElseBranch(kElse, comment, statements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseBranchSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElseBranch(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElseBranch(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitElseBranch(this);
	    }
	}
	
	public sealed class IfStatementSyntax : PilSyntaxNode
	{
	    private IfBranchSyntax ifBranch;
	    private SyntaxNode elseIfBranch;
	    private SyntaxNode elseBranch;
	
	    public IfStatementSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IfStatementSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KIf 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.IfStatementGreen)this.Green;
				var greenToken = green.KIf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public IfBranchSyntax IfBranch 
		{ 
			get { return this.GetRed(ref this.ifBranch, 1); } 
		}
	    public SyntaxList<ElseIfBranchSyntax> ElseIfBranch 
		{ 
			get
			{
				var red = this.GetRed(ref this.elseIfBranch, 2);
				if (red != null) return new SyntaxList<ElseIfBranchSyntax>(red);
				return default;
			} 
		}
	    public SyntaxList<ElseBranchSyntax> ElseBranch 
		{ 
			get
			{
				var red = this.GetRed(ref this.elseBranch, 3);
				if (red != null) return new SyntaxList<ElseBranchSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KEndIf 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.IfStatementGreen)this.Green;
				var greenToken = green.KEndIf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.ifBranch, 1);
				case 2: return this.GetRed(ref this.elseIfBranch, 2);
				case 3: return this.GetRed(ref this.elseBranch, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.ifBranch;
				case 2: return this.elseIfBranch;
				case 3: return this.elseBranch;
				default: return null;
	        }
	    }
	
	    public IfStatementSyntax WithKIf(SyntaxToken kIf)
		{
			return this.Update(KIf, this.IfBranch, this.ElseIfBranch, this.ElseBranch, this.KEndIf);
		}
	
	    public IfStatementSyntax WithIfBranch(IfBranchSyntax ifBranch)
		{
			return this.Update(this.KIf, IfBranch, this.ElseIfBranch, this.ElseBranch, this.KEndIf);
		}
	
	    public IfStatementSyntax WithElseIfBranch(SyntaxList<ElseIfBranchSyntax> elseIfBranch)
		{
			return this.Update(this.KIf, this.IfBranch, ElseIfBranch, this.ElseBranch, this.KEndIf);
		}
	
	    public IfStatementSyntax AddElseIfBranch(params ElseIfBranchSyntax[] elseIfBranch)
		{
			return this.WithElseIfBranch(this.ElseIfBranch.AddRange(elseIfBranch));
		}
	
	    public IfStatementSyntax WithElseBranch(SyntaxList<ElseBranchSyntax> elseBranch)
		{
			return this.Update(this.KIf, this.IfBranch, this.ElseIfBranch, ElseBranch, this.KEndIf);
		}
	
	    public IfStatementSyntax AddElseBranch(params ElseBranchSyntax[] elseBranch)
		{
			return this.WithElseBranch(this.ElseBranch.AddRange(elseBranch));
		}
	
	    public IfStatementSyntax WithKEndIf(SyntaxToken kEndIf)
		{
			return this.Update(this.KIf, this.IfBranch, this.ElseIfBranch, this.ElseBranch, KEndIf);
		}
	
	    public IfStatementSyntax Update(SyntaxToken kIf, IfBranchSyntax ifBranch, SyntaxList<ElseIfBranchSyntax> elseIfBranch, SyntaxList<ElseBranchSyntax> elseBranch, SyntaxToken kEndIf)
	    {
	        if (this.KIf != kIf ||
				this.IfBranch != ifBranch ||
				this.ElseIfBranch != elseIfBranch ||
				this.ElseBranch != elseBranch ||
				this.KEndIf != kEndIf)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.IfStatement(kIf, ifBranch, elseIfBranch, elseBranch, kEndIf);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIfStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIfStatement(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitIfStatement(this);
	    }
	}
	
	public sealed class IfBranchSyntax : PilSyntaxNode
	{
	    private ConditionalExpressionSyntax conditionalExpression;
	    private CommentSyntax comment;
	    private StatementsSyntax statements;
	
	    public IfBranchSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IfBranchSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ConditionalExpressionSyntax ConditionalExpression 
		{ 
			get { return this.GetRed(ref this.conditionalExpression, 0); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.IfBranchGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public StatementsSyntax Statements 
		{ 
			get { return this.GetRed(ref this.statements, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.conditionalExpression, 0);
				case 1: return this.GetRed(ref this.comment, 1);
				case 3: return this.GetRed(ref this.statements, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.conditionalExpression;
				case 1: return this.comment;
				case 3: return this.statements;
				default: return null;
	        }
	    }
	
	    public IfBranchSyntax WithConditionalExpression(ConditionalExpressionSyntax conditionalExpression)
		{
			return this.Update(ConditionalExpression, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public IfBranchSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.ConditionalExpression, Comment, this.TSemicolon, this.Statements);
		}
	
	    public IfBranchSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.ConditionalExpression, this.Comment, TSemicolon, this.Statements);
		}
	
	    public IfBranchSyntax WithStatements(StatementsSyntax statements)
		{
			return this.Update(this.ConditionalExpression, this.Comment, this.TSemicolon, Statements);
		}
	
	    public IfBranchSyntax Update(ConditionalExpressionSyntax conditionalExpression, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
	    {
	        if (this.ConditionalExpression != conditionalExpression ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.IfBranch(conditionalExpression, comment, tSemicolon, statements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfBranchSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIfBranch(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIfBranch(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitIfBranch(this);
	    }
	}
	
	public sealed class ElseIfBranchSyntax : PilSyntaxNode
	{
	    private IfBranchSyntax ifBranch;
	
	    public ElseIfBranchSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElseIfBranchSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KElse 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ElseIfBranchGreen)this.Green;
				var greenToken = green.KElse;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KIf 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ElseIfBranchGreen)this.Green;
				var greenToken = green.KIf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IfBranchSyntax IfBranch 
		{ 
			get { return this.GetRed(ref this.ifBranch, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.ifBranch, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.ifBranch;
				default: return null;
	        }
	    }
	
	    public ElseIfBranchSyntax WithKElse(SyntaxToken kElse)
		{
			return this.Update(KElse, this.KIf, this.IfBranch);
		}
	
	    public ElseIfBranchSyntax WithKIf(SyntaxToken kIf)
		{
			return this.Update(this.KElse, KIf, this.IfBranch);
		}
	
	    public ElseIfBranchSyntax WithIfBranch(IfBranchSyntax ifBranch)
		{
			return this.Update(this.KElse, this.KIf, IfBranch);
		}
	
	    public ElseIfBranchSyntax Update(SyntaxToken kElse, SyntaxToken kIf, IfBranchSyntax ifBranch)
	    {
	        if (this.KElse != kElse ||
				this.KIf != kIf ||
				this.IfBranch != ifBranch)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ElseIfBranch(kElse, kIf, ifBranch);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseIfBranchSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElseIfBranch(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElseIfBranch(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitElseIfBranch(this);
	    }
	}
	
	public sealed class RequestStatementSyntax : PilSyntaxNode
	{
	    private LeftSideSyntax leftSide;
	    private CallRequestSyntax callRequest;
	    private AssertionSyntax assertion;
	
	    public RequestStatementSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RequestStatementSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LeftSideSyntax LeftSide 
		{ 
			get { return this.GetRed(ref this.leftSide, 0); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.RequestStatementGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public CallRequestSyntax CallRequest 
		{ 
			get { return this.GetRed(ref this.callRequest, 2); } 
		}
	    public AssertionSyntax Assertion 
		{ 
			get { return this.GetRed(ref this.assertion, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.RequestStatementGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leftSide, 0);
				case 2: return this.GetRed(ref this.callRequest, 2);
				case 3: return this.GetRed(ref this.assertion, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leftSide;
				case 2: return this.callRequest;
				case 3: return this.assertion;
				default: return null;
	        }
	    }
	
	    public RequestStatementSyntax WithLeftSide(LeftSideSyntax leftSide)
		{
			return this.Update(LeftSide, this.TAssign, this.CallRequest, this.Assertion, this.TSemicolon);
		}
	
	    public RequestStatementSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.LeftSide, TAssign, this.CallRequest, this.Assertion, this.TSemicolon);
		}
	
	    public RequestStatementSyntax WithCallRequest(CallRequestSyntax callRequest)
		{
			return this.Update(this.LeftSide, this.TAssign, CallRequest, this.Assertion, this.TSemicolon);
		}
	
	    public RequestStatementSyntax WithAssertion(AssertionSyntax assertion)
		{
			return this.Update(this.LeftSide, this.TAssign, this.CallRequest, Assertion, this.TSemicolon);
		}
	
	    public RequestStatementSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.LeftSide, this.TAssign, this.CallRequest, this.Assertion, TSemicolon);
		}
	
	    public RequestStatementSyntax Update(LeftSideSyntax leftSide, SyntaxToken tAssign, CallRequestSyntax callRequest, AssertionSyntax assertion, SyntaxToken tSemicolon)
	    {
	        if (this.LeftSide != leftSide ||
				this.TAssign != tAssign ||
				this.CallRequest != callRequest ||
				this.Assertion != assertion ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.RequestStatement(leftSide, tAssign, callRequest, assertion, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RequestStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRequestStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRequestStatement(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitRequestStatement(this);
	    }
	}
	
	public sealed class CallRequestSyntax : PilSyntaxNode
	{
	    private IdentifierSyntax portName;
	    private IdentifierSyntax queryName;
	    private RequestArgumentsSyntax requestArguments;
	
	    public CallRequestSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CallRequestSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KRequest 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CallRequestGreen)this.Green;
				var greenToken = green.KRequest;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public IdentifierSyntax PortName 
		{ 
			get { return this.GetRed(ref this.portName, 1); } 
		}
	    public SyntaxToken TDot 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CallRequestGreen)this.Green;
				var greenToken = green.TDot;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public IdentifierSyntax QueryName 
		{ 
			get { return this.GetRed(ref this.queryName, 3); } 
		}
	    public RequestArgumentsSyntax RequestArguments 
		{ 
			get { return this.GetRed(ref this.requestArguments, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.portName, 1);
				case 3: return this.GetRed(ref this.queryName, 3);
				case 4: return this.GetRed(ref this.requestArguments, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.portName;
				case 3: return this.queryName;
				case 4: return this.requestArguments;
				default: return null;
	        }
	    }
	
	    public CallRequestSyntax WithKRequest(SyntaxToken kRequest)
		{
			return this.Update(KRequest, this.PortName, this.TDot, this.QueryName, this.RequestArguments);
		}
	
	    public CallRequestSyntax WithPortName(IdentifierSyntax portName)
		{
			return this.Update(this.KRequest, PortName, this.TDot, this.QueryName, this.RequestArguments);
		}
	
	    public CallRequestSyntax WithTDot(SyntaxToken tDot)
		{
			return this.Update(this.KRequest, this.PortName, TDot, this.QueryName, this.RequestArguments);
		}
	
	    public CallRequestSyntax WithQueryName(IdentifierSyntax queryName)
		{
			return this.Update(this.KRequest, this.PortName, this.TDot, QueryName, this.RequestArguments);
		}
	
	    public CallRequestSyntax WithRequestArguments(RequestArgumentsSyntax requestArguments)
		{
			return this.Update(this.KRequest, this.PortName, this.TDot, this.QueryName, RequestArguments);
		}
	
	    public CallRequestSyntax Update(SyntaxToken kRequest, IdentifierSyntax portName, SyntaxToken tDot, IdentifierSyntax queryName, RequestArgumentsSyntax requestArguments)
	    {
	        if (this.KRequest != kRequest ||
				this.PortName != portName ||
				this.TDot != tDot ||
				this.QueryName != queryName ||
				this.RequestArguments != requestArguments)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.CallRequest(kRequest, portName, tDot, queryName, requestArguments);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CallRequestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCallRequest(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCallRequest(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitCallRequest(this);
	    }
	}
	
	public sealed class RequestArgumentsSyntax : PilSyntaxNode
	{
	    private ExpressionListSyntax expressionList;
	
	    public RequestArgumentsSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RequestArgumentsSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.RequestArgumentsGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionListSyntax ExpressionList 
		{ 
			get { return this.GetRed(ref this.expressionList, 1); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.RequestArgumentsGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.expressionList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.expressionList;
				default: return null;
	        }
	    }
	
	    public RequestArgumentsSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.ExpressionList, this.TCloseParen);
		}
	
	    public RequestArgumentsSyntax WithExpressionList(ExpressionListSyntax expressionList)
		{
			return this.Update(this.TOpenParen, ExpressionList, this.TCloseParen);
		}
	
	    public RequestArgumentsSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.ExpressionList, TCloseParen);
		}
	
	    public RequestArgumentsSyntax Update(SyntaxToken tOpenParen, ExpressionListSyntax expressionList, SyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.ExpressionList != expressionList ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.RequestArguments(tOpenParen, expressionList, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RequestArgumentsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRequestArguments(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRequestArguments(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitRequestArguments(this);
	    }
	}
	
	public sealed class ResponseStatementSyntax : PilSyntaxNode
	{
	    private ResponseStatementKindSyntax responseStatementKind;
	    private AssertionSyntax assertion;
	
	    public ResponseStatementSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ResponseStatementSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ResponseStatementKindSyntax ResponseStatementKind 
		{ 
			get { return this.GetRed(ref this.responseStatementKind, 0); } 
		}
	    public AssertionSyntax Assertion 
		{ 
			get { return this.GetRed(ref this.assertion, 1); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ResponseStatementGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.responseStatementKind, 0);
				case 1: return this.GetRed(ref this.assertion, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.responseStatementKind;
				case 1: return this.assertion;
				default: return null;
	        }
	    }
	
	    public ResponseStatementSyntax WithResponseStatementKind(ResponseStatementKindSyntax responseStatementKind)
		{
			return this.Update(ResponseStatementKind, this.Assertion, this.TSemicolon);
		}
	
	    public ResponseStatementSyntax WithAssertion(AssertionSyntax assertion)
		{
			return this.Update(this.ResponseStatementKind, Assertion, this.TSemicolon);
		}
	
	    public ResponseStatementSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.ResponseStatementKind, this.Assertion, TSemicolon);
		}
	
	    public ResponseStatementSyntax Update(ResponseStatementKindSyntax responseStatementKind, AssertionSyntax assertion, SyntaxToken tSemicolon)
	    {
	        if (this.ResponseStatementKind != responseStatementKind ||
				this.Assertion != assertion ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ResponseStatement(responseStatementKind, assertion, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ResponseStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitResponseStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitResponseStatement(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitResponseStatement(this);
	    }
	}
	
	public sealed class CancelStatementSyntax : PilSyntaxNode
	{
	    private CancelStatementKindSyntax cancelStatementKind;
	    private IdentifierSyntax portName;
	    private AssertionSyntax assertion;
	
	    public CancelStatementSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CancelStatementSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public CancelStatementKindSyntax CancelStatementKind 
		{ 
			get { return this.GetRed(ref this.cancelStatementKind, 0); } 
		}
	    public IdentifierSyntax PortName 
		{ 
			get { return this.GetRed(ref this.portName, 1); } 
		}
	    public AssertionSyntax Assertion 
		{ 
			get { return this.GetRed(ref this.assertion, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CancelStatementGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.cancelStatementKind, 0);
				case 1: return this.GetRed(ref this.portName, 1);
				case 2: return this.GetRed(ref this.assertion, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.cancelStatementKind;
				case 1: return this.portName;
				case 2: return this.assertion;
				default: return null;
	        }
	    }
	
	    public CancelStatementSyntax WithCancelStatementKind(CancelStatementKindSyntax cancelStatementKind)
		{
			return this.Update(CancelStatementKind, this.PortName, this.Assertion, this.TSemicolon);
		}
	
	    public CancelStatementSyntax WithPortName(IdentifierSyntax portName)
		{
			return this.Update(this.CancelStatementKind, PortName, this.Assertion, this.TSemicolon);
		}
	
	    public CancelStatementSyntax WithAssertion(AssertionSyntax assertion)
		{
			return this.Update(this.CancelStatementKind, this.PortName, Assertion, this.TSemicolon);
		}
	
	    public CancelStatementSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.CancelStatementKind, this.PortName, this.Assertion, TSemicolon);
		}
	
	    public CancelStatementSyntax Update(CancelStatementKindSyntax cancelStatementKind, IdentifierSyntax portName, AssertionSyntax assertion, SyntaxToken tSemicolon)
	    {
	        if (this.CancelStatementKind != cancelStatementKind ||
				this.PortName != portName ||
				this.Assertion != assertion ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.CancelStatement(cancelStatementKind, portName, assertion, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CancelStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCancelStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCancelStatement(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitCancelStatement(this);
	    }
	}
	
	public sealed class AssertionSyntax : PilSyntaxNode
	{
	    private ExpressionSyntax expression;
	    private CommentSyntax comment;
	
	    public AssertionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssertionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.AssertionGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.expression, 1);
				case 2: return this.GetRed(ref this.comment, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.expression;
				case 2: return this.comment;
				default: return null;
	        }
	    }
	
	    public AssertionSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(TColon, this.Expression, this.Comment);
		}
	
	    public AssertionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.TColon, Expression, this.Comment);
		}
	
	    public AssertionSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.TColon, this.Expression, Comment);
		}
	
	    public AssertionSyntax Update(SyntaxToken tColon, ExpressionSyntax expression, CommentSyntax comment)
	    {
	        if (this.TColon != tColon ||
				this.Expression != expression ||
				this.Comment != comment)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Assertion(tColon, expression, comment);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssertionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAssertion(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssertion(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitAssertion(this);
	    }
	}
	
	public sealed class ResponseStatementKindSyntax : PilSyntaxNode
	{
	
	    public ResponseStatementKindSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ResponseStatementKindSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ResponseStatementKind 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ResponseStatementKindGreen)this.Green;
				var greenToken = green.ResponseStatementKind;
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
	
	    public ResponseStatementKindSyntax WithResponseStatementKind(SyntaxToken responseStatementKind)
		{
			return this.Update(ResponseStatementKind);
		}
	
	    public ResponseStatementKindSyntax Update(SyntaxToken responseStatementKind)
	    {
	        if (this.ResponseStatementKind != responseStatementKind)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ResponseStatementKind(responseStatementKind);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ResponseStatementKindSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitResponseStatementKind(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitResponseStatementKind(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitResponseStatementKind(this);
	    }
	}
	
	public sealed class CancelStatementKindSyntax : PilSyntaxNode
	{
	
	    public CancelStatementKindSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CancelStatementKindSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KCancel 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CancelStatementKindGreen)this.Green;
				var greenToken = green.KCancel;
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
	
	    public CancelStatementKindSyntax WithKCancel(SyntaxToken kCancel)
		{
			return this.Update(KCancel);
		}
	
	    public CancelStatementKindSyntax Update(SyntaxToken kCancel)
	    {
	        if (this.KCancel != kCancel)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.CancelStatementKind(kCancel);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CancelStatementKindSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCancelStatementKind(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCancelStatementKind(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitCancelStatementKind(this);
	    }
	}
	
	public sealed class ForkRequestStatementSyntax : PilSyntaxNode
	{
	    private ForkRequestVariableSyntax forkRequestVariable;
	    private AcceptBranchSyntax acceptBranch;
	    private RefuseBranchSyntax refuseBranch;
	    private CancelBranchSyntax cancelBranch;
	
	    public ForkRequestStatementSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ForkRequestStatementSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KFork 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ForkRequestStatementGreen)this.Green;
				var greenToken = green.KFork;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ForkRequestVariableSyntax ForkRequestVariable 
		{ 
			get { return this.GetRed(ref this.forkRequestVariable, 1); } 
		}
	    public AcceptBranchSyntax AcceptBranch 
		{ 
			get { return this.GetRed(ref this.acceptBranch, 2); } 
		}
	    public RefuseBranchSyntax RefuseBranch 
		{ 
			get { return this.GetRed(ref this.refuseBranch, 3); } 
		}
	    public CancelBranchSyntax CancelBranch 
		{ 
			get { return this.GetRed(ref this.cancelBranch, 4); } 
		}
	    public SyntaxToken KEndFork 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ForkRequestStatementGreen)this.Green;
				var greenToken = green.KEndFork;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.forkRequestVariable, 1);
				case 2: return this.GetRed(ref this.acceptBranch, 2);
				case 3: return this.GetRed(ref this.refuseBranch, 3);
				case 4: return this.GetRed(ref this.cancelBranch, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.forkRequestVariable;
				case 2: return this.acceptBranch;
				case 3: return this.refuseBranch;
				case 4: return this.cancelBranch;
				default: return null;
	        }
	    }
	
	    public ForkRequestStatementSyntax WithKFork(SyntaxToken kFork)
		{
			return this.Update(KFork, this.ForkRequestVariable, this.AcceptBranch, this.RefuseBranch, this.CancelBranch, this.KEndFork);
		}
	
	    public ForkRequestStatementSyntax WithForkRequestVariable(ForkRequestVariableSyntax forkRequestVariable)
		{
			return this.Update(this.KFork, ForkRequestVariable, this.AcceptBranch, this.RefuseBranch, this.CancelBranch, this.KEndFork);
		}
	
	    public ForkRequestStatementSyntax WithAcceptBranch(AcceptBranchSyntax acceptBranch)
		{
			return this.Update(this.KFork, this.ForkRequestVariable, AcceptBranch, this.RefuseBranch, this.CancelBranch, this.KEndFork);
		}
	
	    public ForkRequestStatementSyntax WithRefuseBranch(RefuseBranchSyntax refuseBranch)
		{
			return this.Update(this.KFork, this.ForkRequestVariable, this.AcceptBranch, RefuseBranch, this.CancelBranch, this.KEndFork);
		}
	
	    public ForkRequestStatementSyntax WithCancelBranch(CancelBranchSyntax cancelBranch)
		{
			return this.Update(this.KFork, this.ForkRequestVariable, this.AcceptBranch, this.RefuseBranch, CancelBranch, this.KEndFork);
		}
	
	    public ForkRequestStatementSyntax WithKEndFork(SyntaxToken kEndFork)
		{
			return this.Update(this.KFork, this.ForkRequestVariable, this.AcceptBranch, this.RefuseBranch, this.CancelBranch, KEndFork);
		}
	
	    public ForkRequestStatementSyntax Update(SyntaxToken kFork, ForkRequestVariableSyntax forkRequestVariable, AcceptBranchSyntax acceptBranch, RefuseBranchSyntax refuseBranch, CancelBranchSyntax cancelBranch, SyntaxToken kEndFork)
	    {
	        if (this.KFork != kFork ||
				this.ForkRequestVariable != forkRequestVariable ||
				this.AcceptBranch != acceptBranch ||
				this.RefuseBranch != refuseBranch ||
				this.CancelBranch != cancelBranch ||
				this.KEndFork != kEndFork)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ForkRequestStatement(kFork, forkRequestVariable, acceptBranch, refuseBranch, cancelBranch, kEndFork);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkRequestStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitForkRequestStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitForkRequestStatement(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitForkRequestStatement(this);
	    }
	}
	
	public sealed class ForkRequestVariableSyntax : PilSyntaxNode
	{
	    private ForkRequestIdentifierSyntax forkRequestIdentifier;
	    private RequestStatementSyntax requestStatement;
	
	    public ForkRequestVariableSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ForkRequestVariableSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ForkRequestIdentifierSyntax ForkRequestIdentifier 
		{ 
			get { return this.GetRed(ref this.forkRequestIdentifier, 0); } 
		}
	    public RequestStatementSyntax RequestStatement 
		{ 
			get { return this.GetRed(ref this.requestStatement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.forkRequestIdentifier, 0);
				case 1: return this.GetRed(ref this.requestStatement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.forkRequestIdentifier;
				case 1: return this.requestStatement;
				default: return null;
	        }
	    }
	
	    public ForkRequestVariableSyntax WithForkRequestIdentifier(ForkRequestIdentifierSyntax forkRequestIdentifier)
		{
			return this.Update(forkRequestIdentifier);
		}
	
	    public ForkRequestVariableSyntax WithRequestStatement(RequestStatementSyntax requestStatement)
		{
			return this.Update(requestStatement);
		}
	
	    public ForkRequestVariableSyntax Update(ForkRequestIdentifierSyntax forkRequestIdentifier)
	    {
	        if (this.ForkRequestIdentifier != forkRequestIdentifier)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ForkRequestVariable(forkRequestIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkRequestVariableSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ForkRequestVariableSyntax Update(RequestStatementSyntax requestStatement)
	    {
	        if (this.RequestStatement != requestStatement)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ForkRequestVariable(requestStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkRequestVariableSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitForkRequestVariable(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitForkRequestVariable(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitForkRequestVariable(this);
	    }
	}
	
	public sealed class ForkRequestIdentifierSyntax : PilSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public ForkRequestIdentifierSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ForkRequestIdentifierSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ForkRequestIdentifierGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	
	    public ForkRequestIdentifierSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier, this.TSemicolon);
		}
	
	    public ForkRequestIdentifierSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.Identifier, TSemicolon);
		}
	
	    public ForkRequestIdentifierSyntax Update(IdentifierSyntax identifier, SyntaxToken tSemicolon)
	    {
	        if (this.Identifier != identifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ForkRequestIdentifier(identifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForkRequestIdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitForkRequestIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitForkRequestIdentifier(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitForkRequestIdentifier(this);
	    }
	}
	
	public sealed class AcceptBranchSyntax : PilSyntaxNode
	{
	    private ExpressionSyntax condition;
	    private CommentSyntax comment;
	    private StatementsSyntax statements;
	
	    public AcceptBranchSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AcceptBranchSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KCase 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.AcceptBranchGreen)this.Green;
				var greenToken = green.KCase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KAccept 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.AcceptBranchGreen)this.Green;
				var greenToken = green.KAccept;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 2); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.AcceptBranchGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public StatementsSyntax Statements 
		{ 
			get { return this.GetRed(ref this.statements, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.condition, 2);
				case 3: return this.GetRed(ref this.comment, 3);
				case 5: return this.GetRed(ref this.statements, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.condition;
				case 3: return this.comment;
				case 5: return this.statements;
				default: return null;
	        }
	    }
	
	    public AcceptBranchSyntax WithKCase(SyntaxToken kCase)
		{
			return this.Update(KCase, this.KAccept, this.Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public AcceptBranchSyntax WithKAccept(SyntaxToken kAccept)
		{
			return this.Update(this.KCase, KAccept, this.Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public AcceptBranchSyntax WithCondition(ExpressionSyntax condition)
		{
			return this.Update(this.KCase, this.KAccept, Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public AcceptBranchSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KCase, this.KAccept, this.Condition, Comment, this.TSemicolon, this.Statements);
		}
	
	    public AcceptBranchSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KCase, this.KAccept, this.Condition, this.Comment, TSemicolon, this.Statements);
		}
	
	    public AcceptBranchSyntax WithStatements(StatementsSyntax statements)
		{
			return this.Update(this.KCase, this.KAccept, this.Condition, this.Comment, this.TSemicolon, Statements);
		}
	
	    public AcceptBranchSyntax Update(SyntaxToken kCase, SyntaxToken kAccept, ExpressionSyntax condition, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
	    {
	        if (this.KCase != kCase ||
				this.KAccept != kAccept ||
				this.Condition != condition ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.AcceptBranch(kCase, kAccept, condition, comment, tSemicolon, statements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AcceptBranchSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAcceptBranch(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAcceptBranch(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitAcceptBranch(this);
	    }
	}
	
	public sealed class RefuseBranchSyntax : PilSyntaxNode
	{
	    private ExpressionSyntax condition;
	    private CommentSyntax comment;
	    private StatementsSyntax statements;
	
	    public RefuseBranchSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RefuseBranchSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KCase 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.RefuseBranchGreen)this.Green;
				var greenToken = green.KCase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KRefuse 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.RefuseBranchGreen)this.Green;
				var greenToken = green.KRefuse;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 2); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.RefuseBranchGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public StatementsSyntax Statements 
		{ 
			get { return this.GetRed(ref this.statements, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.condition, 2);
				case 3: return this.GetRed(ref this.comment, 3);
				case 5: return this.GetRed(ref this.statements, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.condition;
				case 3: return this.comment;
				case 5: return this.statements;
				default: return null;
	        }
	    }
	
	    public RefuseBranchSyntax WithKCase(SyntaxToken kCase)
		{
			return this.Update(KCase, this.KRefuse, this.Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public RefuseBranchSyntax WithKRefuse(SyntaxToken kRefuse)
		{
			return this.Update(this.KCase, KRefuse, this.Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public RefuseBranchSyntax WithCondition(ExpressionSyntax condition)
		{
			return this.Update(this.KCase, this.KRefuse, Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public RefuseBranchSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KCase, this.KRefuse, this.Condition, Comment, this.TSemicolon, this.Statements);
		}
	
	    public RefuseBranchSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KCase, this.KRefuse, this.Condition, this.Comment, TSemicolon, this.Statements);
		}
	
	    public RefuseBranchSyntax WithStatements(StatementsSyntax statements)
		{
			return this.Update(this.KCase, this.KRefuse, this.Condition, this.Comment, this.TSemicolon, Statements);
		}
	
	    public RefuseBranchSyntax Update(SyntaxToken kCase, SyntaxToken kRefuse, ExpressionSyntax condition, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
	    {
	        if (this.KCase != kCase ||
				this.KRefuse != kRefuse ||
				this.Condition != condition ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.RefuseBranch(kCase, kRefuse, condition, comment, tSemicolon, statements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RefuseBranchSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRefuseBranch(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRefuseBranch(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitRefuseBranch(this);
	    }
	}
	
	public sealed class CancelBranchSyntax : PilSyntaxNode
	{
	    private ExpressionSyntax condition;
	    private CommentSyntax comment;
	    private StatementsSyntax statements;
	
	    public CancelBranchSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CancelBranchSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KCase 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CancelBranchGreen)this.Green;
				var greenToken = green.KCase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KCancel 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CancelBranchGreen)this.Green;
				var greenToken = green.KCancel;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 2); } 
		}
	    public CommentSyntax Comment 
		{ 
			get { return this.GetRed(ref this.comment, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CancelBranchGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public StatementsSyntax Statements 
		{ 
			get { return this.GetRed(ref this.statements, 5); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.condition, 2);
				case 3: return this.GetRed(ref this.comment, 3);
				case 5: return this.GetRed(ref this.statements, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.condition;
				case 3: return this.comment;
				case 5: return this.statements;
				default: return null;
	        }
	    }
	
	    public CancelBranchSyntax WithKCase(SyntaxToken kCase)
		{
			return this.Update(KCase, this.KCancel, this.Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public CancelBranchSyntax WithKCancel(SyntaxToken kCancel)
		{
			return this.Update(this.KCase, KCancel, this.Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public CancelBranchSyntax WithCondition(ExpressionSyntax condition)
		{
			return this.Update(this.KCase, this.KCancel, Condition, this.Comment, this.TSemicolon, this.Statements);
		}
	
	    public CancelBranchSyntax WithComment(CommentSyntax comment)
		{
			return this.Update(this.KCase, this.KCancel, this.Condition, Comment, this.TSemicolon, this.Statements);
		}
	
	    public CancelBranchSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KCase, this.KCancel, this.Condition, this.Comment, TSemicolon, this.Statements);
		}
	
	    public CancelBranchSyntax WithStatements(StatementsSyntax statements)
		{
			return this.Update(this.KCase, this.KCancel, this.Condition, this.Comment, this.TSemicolon, Statements);
		}
	
	    public CancelBranchSyntax Update(SyntaxToken kCase, SyntaxToken kCancel, ExpressionSyntax condition, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
	    {
	        if (this.KCase != kCase ||
				this.KCancel != kCancel ||
				this.Condition != condition ||
				this.Comment != comment ||
				this.TSemicolon != tSemicolon ||
				this.Statements != statements)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.CancelBranch(kCase, kCancel, condition, comment, tSemicolon, statements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CancelBranchSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCancelBranch(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCancelBranch(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitCancelBranch(this);
	    }
	}
	
	public sealed class VariableDeclarationStatementSyntax : PilSyntaxNode
	{
	    private VariableDeclarationSyntax variableDeclaration;
	
	    public VariableDeclarationStatementSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VariableDeclarationStatementSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VariableDeclarationSyntax VariableDeclaration 
		{ 
			get { return this.GetRed(ref this.variableDeclaration, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableDeclaration, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableDeclaration;
				default: return null;
	        }
	    }
	
	    public VariableDeclarationStatementSyntax WithVariableDeclaration(VariableDeclarationSyntax variableDeclaration)
		{
			return this.Update(VariableDeclaration);
		}
	
	    public VariableDeclarationStatementSyntax Update(VariableDeclarationSyntax variableDeclaration)
	    {
	        if (this.VariableDeclaration != variableDeclaration)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.VariableDeclarationStatement(variableDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableDeclarationStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVariableDeclarationStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVariableDeclarationStatement(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitVariableDeclarationStatement(this);
	    }
	}
	
	public sealed class VariableDeclarationSyntax : PilSyntaxNode
	{
	    private NameSyntax name;
	    private TypeReferenceSyntax typeReference;
	    private ExpressionSyntax expression;
	
	    public VariableDeclarationSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VariableDeclarationSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVar 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.VariableDeclarationGreen)this.Green;
				var greenToken = green.KVar;
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
				var green = (global::PilV2.Syntax.InternalSyntax.VariableDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 3); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.VariableDeclarationGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 5); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.VariableDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.name, 1);
				case 3: return this.GetRed(ref this.typeReference, 3);
				case 5: return this.GetRed(ref this.expression, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.name;
				case 3: return this.typeReference;
				case 5: return this.expression;
				default: return null;
	        }
	    }
	
	    public VariableDeclarationSyntax WithKVar(SyntaxToken kVar)
		{
			return this.Update(KVar, this.Name, this.TColon, this.TypeReference, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public VariableDeclarationSyntax WithName(NameSyntax name)
		{
			return this.Update(this.KVar, Name, this.TColon, this.TypeReference, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public VariableDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KVar, this.Name, TColon, this.TypeReference, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public VariableDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KVar, this.Name, this.TColon, TypeReference, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public VariableDeclarationSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.KVar, this.Name, this.TColon, this.TypeReference, TAssign, this.Expression, this.TSemicolon);
		}
	
	    public VariableDeclarationSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KVar, this.Name, this.TColon, this.TypeReference, this.TAssign, Expression, this.TSemicolon);
		}
	
	    public VariableDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVar, this.Name, this.TColon, this.TypeReference, this.TAssign, this.Expression, TSemicolon);
		}
	
	    public VariableDeclarationSyntax Update(SyntaxToken kVar, NameSyntax name, SyntaxToken tColon, TypeReferenceSyntax typeReference, SyntaxToken tAssign, ExpressionSyntax expression, SyntaxToken tSemicolon)
	    {
	        if (this.KVar != kVar ||
				this.Name != name ||
				this.TColon != tColon ||
				this.TypeReference != typeReference ||
				this.TAssign != tAssign ||
				this.Expression != expression ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.VariableDeclaration(kVar, name, tColon, typeReference, tAssign, expression, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVariableDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVariableDeclaration(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitVariableDeclaration(this);
	    }
	}
	
	public sealed class AssignmentStatementSyntax : PilSyntaxNode
	{
	    private LeftSideSyntax leftSide;
	    private ExpressionSyntax value;
	
	    public AssignmentStatementSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssignmentStatementSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LeftSideSyntax LeftSide 
		{ 
			get { return this.GetRed(ref this.leftSide, 0); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.AssignmentStatementGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Value 
		{ 
			get { return this.GetRed(ref this.value, 2); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.AssignmentStatementGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.leftSide, 0);
				case 2: return this.GetRed(ref this.value, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.leftSide;
				case 2: return this.value;
				default: return null;
	        }
	    }
	
	    public AssignmentStatementSyntax WithLeftSide(LeftSideSyntax leftSide)
		{
			return this.Update(LeftSide, this.TAssign, this.Value, this.TSemicolon);
		}
	
	    public AssignmentStatementSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.LeftSide, TAssign, this.Value, this.TSemicolon);
		}
	
	    public AssignmentStatementSyntax WithValue(ExpressionSyntax value)
		{
			return this.Update(this.LeftSide, this.TAssign, Value, this.TSemicolon);
		}
	
	    public AssignmentStatementSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.LeftSide, this.TAssign, this.Value, TSemicolon);
		}
	
	    public AssignmentStatementSyntax Update(LeftSideSyntax leftSide, SyntaxToken tAssign, ExpressionSyntax value, SyntaxToken tSemicolon)
	    {
	        if (this.LeftSide != leftSide ||
				this.TAssign != tAssign ||
				this.Value != value ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.AssignmentStatement(leftSide, tAssign, value, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignmentStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAssignmentStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssignmentStatement(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitAssignmentStatement(this);
	    }
	}
	
	public sealed class LeftSideSyntax : PilSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private ResultIdentifierSyntax resultIdentifier;
	
	    public LeftSideSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LeftSideSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public ResultIdentifierSyntax ResultIdentifier 
		{ 
			get { return this.GetRed(ref this.resultIdentifier, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				case 1: return this.GetRed(ref this.resultIdentifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				case 1: return this.resultIdentifier;
				default: return null;
	        }
	    }
	
	    public LeftSideSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(identifier);
		}
	
	    public LeftSideSyntax WithResultIdentifier(ResultIdentifierSyntax resultIdentifier)
		{
			return this.Update(resultIdentifier);
		}
	
	    public LeftSideSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.LeftSide(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LeftSideSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LeftSideSyntax Update(ResultIdentifierSyntax resultIdentifier)
	    {
	        if (this.ResultIdentifier != resultIdentifier)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.LeftSide(resultIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LeftSideSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLeftSide(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLeftSide(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitLeftSide(this);
	    }
	}
	
	public sealed class ExpressionListSyntax : PilSyntaxNode
	{
	    private SyntaxNode expression;
	
	    public ExpressionListSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ExpressionListSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<ExpressionSyntax> Expression 
		{ 
			get
			{
				var red = this.GetRed(ref this.expression, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<ExpressionSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				default: return null;
	        }
	    }
	
	    public ExpressionListSyntax WithExpression(SeparatedSyntaxList<ExpressionSyntax> expression)
		{
			return this.Update(Expression);
		}
	
	    public ExpressionListSyntax AddExpression(params ExpressionSyntax[] expression)
		{
			return this.WithExpression(this.Expression.AddRange(expression));
		}
	
	    public ExpressionListSyntax Update(SeparatedSyntaxList<ExpressionSyntax> expression)
	    {
	        if (this.Expression != expression)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ExpressionList(expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitExpressionList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitExpressionList(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitExpressionList(this);
	    }
	}
	
	public sealed class ExpressionSyntax : PilSyntaxNode
	{
	    private ArithmeticExpressionSyntax arithmeticExpression;
	    private ConditionalExpressionSyntax conditionalExpression;
	
	    public ExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ArithmeticExpressionSyntax ArithmeticExpression 
		{ 
			get { return this.GetRed(ref this.arithmeticExpression, 0); } 
		}
	    public ConditionalExpressionSyntax ConditionalExpression 
		{ 
			get { return this.GetRed(ref this.conditionalExpression, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.arithmeticExpression, 0);
				case 1: return this.GetRed(ref this.conditionalExpression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.arithmeticExpression;
				case 1: return this.conditionalExpression;
				default: return null;
	        }
	    }
	
	    public ExpressionSyntax WithArithmeticExpression(ArithmeticExpressionSyntax arithmeticExpression)
		{
			return this.Update(arithmeticExpression);
		}
	
	    public ExpressionSyntax WithConditionalExpression(ConditionalExpressionSyntax conditionalExpression)
		{
			return this.Update(conditionalExpression);
		}
	
	    public ExpressionSyntax Update(ArithmeticExpressionSyntax arithmeticExpression)
	    {
	        if (this.ArithmeticExpression != arithmeticExpression)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Expression(arithmeticExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ExpressionSyntax Update(ConditionalExpressionSyntax conditionalExpression)
	    {
	        if (this.ConditionalExpression != conditionalExpression)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Expression(conditionalExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitExpression(this);
	    }
	}
	
	public abstract class ArithmeticExpressionSyntax : PilSyntaxNode
	{
	    protected ArithmeticExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected ArithmeticExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class MulDivExpressionSyntax : ArithmeticExpressionSyntax
	{
	    private ArithmeticExpressionSyntax left;
	    private OpMulDivSyntax opMulDiv;
	    private ArithmeticExpressionSyntax right;
	
	    public MulDivExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MulDivExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ArithmeticExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public OpMulDivSyntax OpMulDiv 
		{ 
			get { return this.GetRed(ref this.opMulDiv, 1); } 
		}
	    public ArithmeticExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.opMulDiv, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.opMulDiv;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public MulDivExpressionSyntax WithLeft(ArithmeticExpressionSyntax left)
		{
			return this.Update(Left, this.OpMulDiv, this.Right);
		}
	
	    public MulDivExpressionSyntax WithOpMulDiv(OpMulDivSyntax opMulDiv)
		{
			return this.Update(this.Left, OpMulDiv, this.Right);
		}
	
	    public MulDivExpressionSyntax WithRight(ArithmeticExpressionSyntax right)
		{
			return this.Update(this.Left, this.OpMulDiv, Right);
		}
	
	    public MulDivExpressionSyntax Update(ArithmeticExpressionSyntax left, OpMulDivSyntax opMulDiv, ArithmeticExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.OpMulDiv != opMulDiv ||
				this.Right != right)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.MulDivExpression(left, opMulDiv, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MulDivExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMulDivExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMulDivExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitMulDivExpression(this);
	    }
	}
	
	public sealed class PlusMinusExpressionSyntax : ArithmeticExpressionSyntax
	{
	    private ArithmeticExpressionSyntax left;
	    private OpAddSubSyntax opAddSub;
	    private ArithmeticExpressionSyntax right;
	
	    public PlusMinusExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PlusMinusExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ArithmeticExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public OpAddSubSyntax OpAddSub 
		{ 
			get { return this.GetRed(ref this.opAddSub, 1); } 
		}
	    public ArithmeticExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.opAddSub, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.opAddSub;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public PlusMinusExpressionSyntax WithLeft(ArithmeticExpressionSyntax left)
		{
			return this.Update(Left, this.OpAddSub, this.Right);
		}
	
	    public PlusMinusExpressionSyntax WithOpAddSub(OpAddSubSyntax opAddSub)
		{
			return this.Update(this.Left, OpAddSub, this.Right);
		}
	
	    public PlusMinusExpressionSyntax WithRight(ArithmeticExpressionSyntax right)
		{
			return this.Update(this.Left, this.OpAddSub, Right);
		}
	
	    public PlusMinusExpressionSyntax Update(ArithmeticExpressionSyntax left, OpAddSubSyntax opAddSub, ArithmeticExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.OpAddSub != opAddSub ||
				this.Right != right)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.PlusMinusExpression(left, opAddSub, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PlusMinusExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPlusMinusExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPlusMinusExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitPlusMinusExpression(this);
	    }
	}
	
	public sealed class NegateExpressionSyntax : ArithmeticExpressionSyntax
	{
	    private OpMinusSyntax opMinus;
	    private ArithmeticExpressionTerminatorSyntax arithmeticExpressionTerminator;
	
	    public NegateExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NegateExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public OpMinusSyntax OpMinus 
		{ 
			get { return this.GetRed(ref this.opMinus, 0); } 
		}
	    public ArithmeticExpressionTerminatorSyntax ArithmeticExpressionTerminator 
		{ 
			get { return this.GetRed(ref this.arithmeticExpressionTerminator, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.opMinus, 0);
				case 1: return this.GetRed(ref this.arithmeticExpressionTerminator, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.opMinus;
				case 1: return this.arithmeticExpressionTerminator;
				default: return null;
	        }
	    }
	
	    public NegateExpressionSyntax WithOpMinus(OpMinusSyntax opMinus)
		{
			return this.Update(OpMinus, this.ArithmeticExpressionTerminator);
		}
	
	    public NegateExpressionSyntax WithArithmeticExpressionTerminator(ArithmeticExpressionTerminatorSyntax arithmeticExpressionTerminator)
		{
			return this.Update(this.OpMinus, ArithmeticExpressionTerminator);
		}
	
	    public NegateExpressionSyntax Update(OpMinusSyntax opMinus, ArithmeticExpressionTerminatorSyntax arithmeticExpressionTerminator)
	    {
	        if (this.OpMinus != opMinus ||
				this.ArithmeticExpressionTerminator != arithmeticExpressionTerminator)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.NegateExpression(opMinus, arithmeticExpressionTerminator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NegateExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNegateExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNegateExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitNegateExpression(this);
	    }
	}
	
	public sealed class SimpleArithmeticExpressionSyntax : ArithmeticExpressionSyntax
	{
	    private ArithmeticExpressionTerminatorSyntax arithmeticExpressionTerminator;
	
	    public SimpleArithmeticExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleArithmeticExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ArithmeticExpressionTerminatorSyntax ArithmeticExpressionTerminator 
		{ 
			get { return this.GetRed(ref this.arithmeticExpressionTerminator, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.arithmeticExpressionTerminator, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.arithmeticExpressionTerminator;
				default: return null;
	        }
	    }
	
	    public SimpleArithmeticExpressionSyntax WithArithmeticExpressionTerminator(ArithmeticExpressionTerminatorSyntax arithmeticExpressionTerminator)
		{
			return this.Update(ArithmeticExpressionTerminator);
		}
	
	    public SimpleArithmeticExpressionSyntax Update(ArithmeticExpressionTerminatorSyntax arithmeticExpressionTerminator)
	    {
	        if (this.ArithmeticExpressionTerminator != arithmeticExpressionTerminator)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.SimpleArithmeticExpression(arithmeticExpressionTerminator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleArithmeticExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleArithmeticExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleArithmeticExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleArithmeticExpression(this);
	    }
	}
	
	public sealed class OpMulDivSyntax : PilSyntaxNode
	{
	
	    public OpMulDivSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OpMulDivSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken OpMulDiv 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.OpMulDivGreen)this.Green;
				var greenToken = green.OpMulDiv;
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
	
	    public OpMulDivSyntax WithOpMulDiv(SyntaxToken opMulDiv)
		{
			return this.Update(OpMulDiv);
		}
	
	    public OpMulDivSyntax Update(SyntaxToken opMulDiv)
	    {
	        if (this.OpMulDiv != opMulDiv)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.OpMulDiv(opMulDiv);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OpMulDivSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOpMulDiv(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOpMulDiv(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitOpMulDiv(this);
	    }
	}
	
	public sealed class OpAddSubSyntax : PilSyntaxNode
	{
	
	    public OpAddSubSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OpAddSubSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken OpAddSub 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.OpAddSubGreen)this.Green;
				var greenToken = green.OpAddSub;
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
	
	    public OpAddSubSyntax WithOpAddSub(SyntaxToken opAddSub)
		{
			return this.Update(OpAddSub);
		}
	
	    public OpAddSubSyntax Update(SyntaxToken opAddSub)
	    {
	        if (this.OpAddSub != opAddSub)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.OpAddSub(opAddSub);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OpAddSubSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOpAddSub(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOpAddSub(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitOpAddSub(this);
	    }
	}
	
	public abstract class ArithmeticExpressionTerminatorSyntax : PilSyntaxNode
	{
	    protected ArithmeticExpressionTerminatorSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected ArithmeticExpressionTerminatorSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class ParenArithmeticExpressionSyntax : ArithmeticExpressionTerminatorSyntax
	{
	    private ArithmeticExpressionSyntax arithmeticExpression;
	
	    public ParenArithmeticExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParenArithmeticExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ParenArithmeticExpressionGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ArithmeticExpressionSyntax ArithmeticExpression 
		{ 
			get { return this.GetRed(ref this.arithmeticExpression, 1); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ParenArithmeticExpressionGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.arithmeticExpression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.arithmeticExpression;
				default: return null;
	        }
	    }
	
	    public ParenArithmeticExpressionSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.ArithmeticExpression, this.TCloseParen);
		}
	
	    public ParenArithmeticExpressionSyntax WithArithmeticExpression(ArithmeticExpressionSyntax arithmeticExpression)
		{
			return this.Update(this.TOpenParen, ArithmeticExpression, this.TCloseParen);
		}
	
	    public ParenArithmeticExpressionSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.ArithmeticExpression, TCloseParen);
		}
	
	    public ParenArithmeticExpressionSyntax Update(SyntaxToken tOpenParen, ArithmeticExpressionSyntax arithmeticExpression, SyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.ArithmeticExpression != arithmeticExpression ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ParenArithmeticExpression(tOpenParen, arithmeticExpression, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenArithmeticExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParenArithmeticExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParenArithmeticExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitParenArithmeticExpression(this);
	    }
	}
	
	public sealed class TerminalArithmeticExpressionSyntax : ArithmeticExpressionTerminatorSyntax
	{
	    private TerminalExpressionSyntax terminalExpression;
	
	    public TerminalArithmeticExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TerminalArithmeticExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TerminalExpressionSyntax TerminalExpression 
		{ 
			get { return this.GetRed(ref this.terminalExpression, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.terminalExpression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.terminalExpression;
				default: return null;
	        }
	    }
	
	    public TerminalArithmeticExpressionSyntax WithTerminalExpression(TerminalExpressionSyntax terminalExpression)
		{
			return this.Update(TerminalExpression);
		}
	
	    public TerminalArithmeticExpressionSyntax Update(TerminalExpressionSyntax terminalExpression)
	    {
	        if (this.TerminalExpression != terminalExpression)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TerminalArithmeticExpression(terminalExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalArithmeticExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTerminalArithmeticExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTerminalArithmeticExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitTerminalArithmeticExpression(this);
	    }
	}
	
	public sealed class OpMinusSyntax : PilSyntaxNode
	{
	
	    public OpMinusSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OpMinusSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TMinus 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.OpMinusGreen)this.Green;
				var greenToken = green.TMinus;
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
	
	    public OpMinusSyntax WithTMinus(SyntaxToken tMinus)
		{
			return this.Update(TMinus);
		}
	
	    public OpMinusSyntax Update(SyntaxToken tMinus)
	    {
	        if (this.TMinus != tMinus)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.OpMinus(tMinus);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OpMinusSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOpMinus(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOpMinus(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitOpMinus(this);
	    }
	}
	
	public abstract class ConditionalExpressionSyntax : PilSyntaxNode
	{
	    protected ConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected ConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class AndExpressionSyntax : ConditionalExpressionSyntax
	{
	    private ConditionalExpressionSyntax left;
	    private AndAlsoOpSyntax andAlsoOp;
	    private ConditionalExpressionSyntax right;
	
	    public AndExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AndExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ConditionalExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public AndAlsoOpSyntax AndAlsoOp 
		{ 
			get { return this.GetRed(ref this.andAlsoOp, 1); } 
		}
	    public ConditionalExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.andAlsoOp, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.andAlsoOp;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public AndExpressionSyntax WithLeft(ConditionalExpressionSyntax left)
		{
			return this.Update(Left, this.AndAlsoOp, this.Right);
		}
	
	    public AndExpressionSyntax WithAndAlsoOp(AndAlsoOpSyntax andAlsoOp)
		{
			return this.Update(this.Left, AndAlsoOp, this.Right);
		}
	
	    public AndExpressionSyntax WithRight(ConditionalExpressionSyntax right)
		{
			return this.Update(this.Left, this.AndAlsoOp, Right);
		}
	
	    public AndExpressionSyntax Update(ConditionalExpressionSyntax left, AndAlsoOpSyntax andAlsoOp, ConditionalExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.AndAlsoOp != andAlsoOp ||
				this.Right != right)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.AndExpression(left, andAlsoOp, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AndExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAndExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAndExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitAndExpression(this);
	    }
	}
	
	public sealed class OrExpressionSyntax : ConditionalExpressionSyntax
	{
	    private ConditionalExpressionSyntax left;
	    private OrElseOpSyntax orElseOp;
	    private ConditionalExpressionSyntax right;
	
	    public OrExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OrExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ConditionalExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public OrElseOpSyntax OrElseOp 
		{ 
			get { return this.GetRed(ref this.orElseOp, 1); } 
		}
	    public ConditionalExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.orElseOp, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.orElseOp;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public OrExpressionSyntax WithLeft(ConditionalExpressionSyntax left)
		{
			return this.Update(Left, this.OrElseOp, this.Right);
		}
	
	    public OrExpressionSyntax WithOrElseOp(OrElseOpSyntax orElseOp)
		{
			return this.Update(this.Left, OrElseOp, this.Right);
		}
	
	    public OrExpressionSyntax WithRight(ConditionalExpressionSyntax right)
		{
			return this.Update(this.Left, this.OrElseOp, Right);
		}
	
	    public OrExpressionSyntax Update(ConditionalExpressionSyntax left, OrElseOpSyntax orElseOp, ConditionalExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.OrElseOp != orElseOp ||
				this.Right != right)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.OrExpression(left, orElseOp, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OrExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOrExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOrExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitOrExpression(this);
	    }
	}
	
	public sealed class NotExpressionSyntax : ConditionalExpressionSyntax
	{
	    private OpExclSyntax opExcl;
	    private ConditionalExpressionTerminatorSyntax conditionalExpressionTerminator;
	
	    public NotExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NotExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public OpExclSyntax OpExcl 
		{ 
			get { return this.GetRed(ref this.opExcl, 0); } 
		}
	    public ConditionalExpressionTerminatorSyntax ConditionalExpressionTerminator 
		{ 
			get { return this.GetRed(ref this.conditionalExpressionTerminator, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.opExcl, 0);
				case 1: return this.GetRed(ref this.conditionalExpressionTerminator, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.opExcl;
				case 1: return this.conditionalExpressionTerminator;
				default: return null;
	        }
	    }
	
	    public NotExpressionSyntax WithOpExcl(OpExclSyntax opExcl)
		{
			return this.Update(OpExcl, this.ConditionalExpressionTerminator);
		}
	
	    public NotExpressionSyntax WithConditionalExpressionTerminator(ConditionalExpressionTerminatorSyntax conditionalExpressionTerminator)
		{
			return this.Update(this.OpExcl, ConditionalExpressionTerminator);
		}
	
	    public NotExpressionSyntax Update(OpExclSyntax opExcl, ConditionalExpressionTerminatorSyntax conditionalExpressionTerminator)
	    {
	        if (this.OpExcl != opExcl ||
				this.ConditionalExpressionTerminator != conditionalExpressionTerminator)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.NotExpression(opExcl, conditionalExpressionTerminator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NotExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNotExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNotExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitNotExpression(this);
	    }
	}
	
	public sealed class SimpleConditionalExpressionSyntax : ConditionalExpressionSyntax
	{
	    private ConditionalExpressionTerminatorSyntax conditionalExpressionTerminator;
	
	    public SimpleConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ConditionalExpressionTerminatorSyntax ConditionalExpressionTerminator 
		{ 
			get { return this.GetRed(ref this.conditionalExpressionTerminator, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.conditionalExpressionTerminator, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.conditionalExpressionTerminator;
				default: return null;
	        }
	    }
	
	    public SimpleConditionalExpressionSyntax WithConditionalExpressionTerminator(ConditionalExpressionTerminatorSyntax conditionalExpressionTerminator)
		{
			return this.Update(ConditionalExpressionTerminator);
		}
	
	    public SimpleConditionalExpressionSyntax Update(ConditionalExpressionTerminatorSyntax conditionalExpressionTerminator)
	    {
	        if (this.ConditionalExpressionTerminator != conditionalExpressionTerminator)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.SimpleConditionalExpression(conditionalExpressionTerminator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleConditionalExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleConditionalExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleConditionalExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleConditionalExpression(this);
	    }
	}
	
	public sealed class AndAlsoOpSyntax : PilSyntaxNode
	{
	
	    public AndAlsoOpSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AndAlsoOpSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TAndAlso 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.AndAlsoOpGreen)this.Green;
				var greenToken = green.TAndAlso;
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
	
	    public AndAlsoOpSyntax WithTAndAlso(SyntaxToken tAndAlso)
		{
			return this.Update(TAndAlso);
		}
	
	    public AndAlsoOpSyntax Update(SyntaxToken tAndAlso)
	    {
	        if (this.TAndAlso != tAndAlso)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.AndAlsoOp(tAndAlso);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AndAlsoOpSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAndAlsoOp(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAndAlsoOp(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitAndAlsoOp(this);
	    }
	}
	
	public sealed class OrElseOpSyntax : PilSyntaxNode
	{
	
	    public OrElseOpSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OrElseOpSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOrElse 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.OrElseOpGreen)this.Green;
				var greenToken = green.TOrElse;
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
	
	    public OrElseOpSyntax WithTOrElse(SyntaxToken tOrElse)
		{
			return this.Update(TOrElse);
		}
	
	    public OrElseOpSyntax Update(SyntaxToken tOrElse)
	    {
	        if (this.TOrElse != tOrElse)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.OrElseOp(tOrElse);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OrElseOpSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOrElseOp(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOrElseOp(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitOrElseOp(this);
	    }
	}
	
	public sealed class OpExclSyntax : PilSyntaxNode
	{
	
	    public OpExclSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public OpExclSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TExclamation 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.OpExclGreen)this.Green;
				var greenToken = green.TExclamation;
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
	
	    public OpExclSyntax WithTExclamation(SyntaxToken tExclamation)
		{
			return this.Update(TExclamation);
		}
	
	    public OpExclSyntax Update(SyntaxToken tExclamation)
	    {
	        if (this.TExclamation != tExclamation)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.OpExcl(tExclamation);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (OpExclSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitOpExcl(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitOpExcl(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitOpExcl(this);
	    }
	}
	
	public abstract class ConditionalExpressionTerminatorSyntax : PilSyntaxNode
	{
	    protected ConditionalExpressionTerminatorSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected ConditionalExpressionTerminatorSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class ParenConditionalExpressionSyntax : ConditionalExpressionTerminatorSyntax
	{
	    private ConditionalExpressionSyntax conditionalExpression;
	
	    public ParenConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParenConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ParenConditionalExpressionGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ConditionalExpressionSyntax ConditionalExpression 
		{ 
			get { return this.GetRed(ref this.conditionalExpression, 1); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ParenConditionalExpressionGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.conditionalExpression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.conditionalExpression;
				default: return null;
	        }
	    }
	
	    public ParenConditionalExpressionSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(TOpenParen, this.ConditionalExpression, this.TCloseParen);
		}
	
	    public ParenConditionalExpressionSyntax WithConditionalExpression(ConditionalExpressionSyntax conditionalExpression)
		{
			return this.Update(this.TOpenParen, ConditionalExpression, this.TCloseParen);
		}
	
	    public ParenConditionalExpressionSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.TOpenParen, this.ConditionalExpression, TCloseParen);
		}
	
	    public ParenConditionalExpressionSyntax Update(SyntaxToken tOpenParen, ConditionalExpressionSyntax conditionalExpression, SyntaxToken tCloseParen)
	    {
	        if (this.TOpenParen != tOpenParen ||
				this.ConditionalExpression != conditionalExpression ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ParenConditionalExpression(tOpenParen, conditionalExpression, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenConditionalExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParenConditionalExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParenConditionalExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitParenConditionalExpression(this);
	    }
	}
	
	public sealed class ElementOfConditionalExpressionSyntax : ConditionalExpressionTerminatorSyntax
	{
	    private ElementOfExpressionSyntax elementOfExpression;
	
	    public ElementOfConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElementOfConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ElementOfExpressionSyntax ElementOfExpression 
		{ 
			get { return this.GetRed(ref this.elementOfExpression, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.elementOfExpression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.elementOfExpression;
				default: return null;
	        }
	    }
	
	    public ElementOfConditionalExpressionSyntax WithElementOfExpression(ElementOfExpressionSyntax elementOfExpression)
		{
			return this.Update(ElementOfExpression);
		}
	
	    public ElementOfConditionalExpressionSyntax Update(ElementOfExpressionSyntax elementOfExpression)
	    {
	        if (this.ElementOfExpression != elementOfExpression)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ElementOfConditionalExpression(elementOfExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementOfConditionalExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElementOfConditionalExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElementOfConditionalExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitElementOfConditionalExpression(this);
	    }
	}
	
	public sealed class ComparisonConditionalExpressionSyntax : ConditionalExpressionTerminatorSyntax
	{
	    private ComparisonExpressionSyntax comparisonExpression;
	
	    public ComparisonConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComparisonConditionalExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ComparisonExpressionSyntax ComparisonExpression 
		{ 
			get { return this.GetRed(ref this.comparisonExpression, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.comparisonExpression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.comparisonExpression;
				default: return null;
	        }
	    }
	
	    public ComparisonConditionalExpressionSyntax WithComparisonExpression(ComparisonExpressionSyntax comparisonExpression)
		{
			return this.Update(ComparisonExpression);
		}
	
	    public ComparisonConditionalExpressionSyntax Update(ComparisonExpressionSyntax comparisonExpression)
	    {
	        if (this.ComparisonExpression != comparisonExpression)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ComparisonConditionalExpression(comparisonExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComparisonConditionalExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComparisonConditionalExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComparisonConditionalExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitComparisonConditionalExpression(this);
	    }
	}
	
	public sealed class TerminalComparisonExpressionSyntax : ConditionalExpressionTerminatorSyntax
	{
	    private TerminalExpressionSyntax terminalExpression;
	
	    public TerminalComparisonExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TerminalComparisonExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TerminalExpressionSyntax TerminalExpression 
		{ 
			get { return this.GetRed(ref this.terminalExpression, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.terminalExpression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.terminalExpression;
				default: return null;
	        }
	    }
	
	    public TerminalComparisonExpressionSyntax WithTerminalExpression(TerminalExpressionSyntax terminalExpression)
		{
			return this.Update(TerminalExpression);
		}
	
	    public TerminalComparisonExpressionSyntax Update(TerminalExpressionSyntax terminalExpression)
	    {
	        if (this.TerminalExpression != terminalExpression)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TerminalComparisonExpression(terminalExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalComparisonExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTerminalComparisonExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTerminalComparisonExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitTerminalComparisonExpression(this);
	    }
	}
	
	public sealed class ComparisonExpressionSyntax : PilSyntaxNode
	{
	    private ArithmeticExpressionSyntax left;
	    private ComparisonOperatorSyntax op;
	    private ArithmeticExpressionSyntax right;
	
	    public ComparisonExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComparisonExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ArithmeticExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public ComparisonOperatorSyntax Op 
		{ 
			get { return this.GetRed(ref this.op, 1); } 
		}
	    public ArithmeticExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 1: return this.GetRed(ref this.op, 1);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 1: return this.op;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public ComparisonExpressionSyntax WithLeft(ArithmeticExpressionSyntax left)
		{
			return this.Update(Left, this.Op, this.Right);
		}
	
	    public ComparisonExpressionSyntax WithOp(ComparisonOperatorSyntax op)
		{
			return this.Update(this.Left, Op, this.Right);
		}
	
	    public ComparisonExpressionSyntax WithRight(ArithmeticExpressionSyntax right)
		{
			return this.Update(this.Left, this.Op, Right);
		}
	
	    public ComparisonExpressionSyntax Update(ArithmeticExpressionSyntax left, ComparisonOperatorSyntax op, ArithmeticExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ComparisonExpression(left, op, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComparisonExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComparisonExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComparisonExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitComparisonExpression(this);
	    }
	}
	
	public sealed class ComparisonOperatorSyntax : PilSyntaxNode
	{
	
	    public ComparisonOperatorSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ComparisonOperatorSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ComparisonOperator 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ComparisonOperatorGreen)this.Green;
				var greenToken = green.ComparisonOperator;
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
	
	    public ComparisonOperatorSyntax WithComparisonOperator(SyntaxToken comparisonOperator)
		{
			return this.Update(ComparisonOperator);
		}
	
	    public ComparisonOperatorSyntax Update(SyntaxToken comparisonOperator)
	    {
	        if (this.ComparisonOperator != comparisonOperator)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ComparisonOperator(comparisonOperator);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ComparisonOperatorSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComparisonOperator(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComparisonOperator(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitComparisonOperator(this);
	    }
	}
	
	public sealed class ElementOfExpressionSyntax : PilSyntaxNode
	{
	    private TerminalExpressionSyntax terminalExpression;
	    private ElementOfValueListSyntax elementOfValueList;
	
	    public ElementOfExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElementOfExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TerminalExpressionSyntax TerminalExpression 
		{ 
			get { return this.GetRed(ref this.terminalExpression, 0); } 
		}
	    public SyntaxToken KIn 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ElementOfExpressionGreen)this.Green;
				var greenToken = green.KIn;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ElementOfExpressionGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ElementOfValueListSyntax ElementOfValueList 
		{ 
			get { return this.GetRed(ref this.elementOfValueList, 3); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ElementOfExpressionGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.terminalExpression, 0);
				case 3: return this.GetRed(ref this.elementOfValueList, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.terminalExpression;
				case 3: return this.elementOfValueList;
				default: return null;
	        }
	    }
	
	    public ElementOfExpressionSyntax WithTerminalExpression(TerminalExpressionSyntax terminalExpression)
		{
			return this.Update(TerminalExpression, this.KIn, this.TOpenBracket, this.ElementOfValueList, this.TCloseBracket);
		}
	
	    public ElementOfExpressionSyntax WithKIn(SyntaxToken kIn)
		{
			return this.Update(this.TerminalExpression, KIn, this.TOpenBracket, this.ElementOfValueList, this.TCloseBracket);
		}
	
	    public ElementOfExpressionSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(this.TerminalExpression, this.KIn, TOpenBracket, this.ElementOfValueList, this.TCloseBracket);
		}
	
	    public ElementOfExpressionSyntax WithElementOfValueList(ElementOfValueListSyntax elementOfValueList)
		{
			return this.Update(this.TerminalExpression, this.KIn, this.TOpenBracket, ElementOfValueList, this.TCloseBracket);
		}
	
	    public ElementOfExpressionSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TerminalExpression, this.KIn, this.TOpenBracket, this.ElementOfValueList, TCloseBracket);
		}
	
	    public ElementOfExpressionSyntax Update(TerminalExpressionSyntax terminalExpression, SyntaxToken kIn, SyntaxToken tOpenBracket, ElementOfValueListSyntax elementOfValueList, SyntaxToken tCloseBracket)
	    {
	        if (this.TerminalExpression != terminalExpression ||
				this.KIn != kIn ||
				this.TOpenBracket != tOpenBracket ||
				this.ElementOfValueList != elementOfValueList ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ElementOfExpression(terminalExpression, kIn, tOpenBracket, elementOfValueList, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementOfExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElementOfExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElementOfExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitElementOfExpression(this);
	    }
	}
	
	public sealed class ElementOfValueListSyntax : PilSyntaxNode
	{
	    private SyntaxNode elementOfValue;
	
	    public ElementOfValueListSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElementOfValueListSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<ElementOfValueSyntax> ElementOfValue 
		{ 
			get
			{
				var red = this.GetRed(ref this.elementOfValue, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<ElementOfValueSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.elementOfValue, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.elementOfValue;
				default: return null;
	        }
	    }
	
	    public ElementOfValueListSyntax WithElementOfValue(SeparatedSyntaxList<ElementOfValueSyntax> elementOfValue)
		{
			return this.Update(ElementOfValue);
		}
	
	    public ElementOfValueListSyntax AddElementOfValue(params ElementOfValueSyntax[] elementOfValue)
		{
			return this.WithElementOfValue(this.ElementOfValue.AddRange(elementOfValue));
		}
	
	    public ElementOfValueListSyntax Update(SeparatedSyntaxList<ElementOfValueSyntax> elementOfValue)
	    {
	        if (this.ElementOfValue != elementOfValue)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ElementOfValueList(elementOfValue);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementOfValueListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElementOfValueList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElementOfValueList(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitElementOfValueList(this);
	    }
	}
	
	public sealed class ElementOfValueSyntax : PilSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public ElementOfValueSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElementOfValueSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
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
	
	    public ElementOfValueSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public ElementOfValueSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ElementOfValue(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementOfValueSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElementOfValue(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElementOfValue(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitElementOfValue(this);
	    }
	}
	
	public sealed class TerminalExpressionSyntax : PilSyntaxNode
	{
	    private VariableReferenceSyntax variableReference;
	    private FunctionCallExpressionSyntax functionCallExpression;
	    private LiteralSyntax literal;
	
	    public TerminalExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TerminalExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VariableReferenceSyntax VariableReference 
		{ 
			get { return this.GetRed(ref this.variableReference, 0); } 
		}
	    public FunctionCallExpressionSyntax FunctionCallExpression 
		{ 
			get { return this.GetRed(ref this.functionCallExpression, 1); } 
		}
	    public LiteralSyntax Literal 
		{ 
			get { return this.GetRed(ref this.literal, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableReference, 0);
				case 1: return this.GetRed(ref this.functionCallExpression, 1);
				case 2: return this.GetRed(ref this.literal, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableReference;
				case 1: return this.functionCallExpression;
				case 2: return this.literal;
				default: return null;
	        }
	    }
	
	    public TerminalExpressionSyntax WithVariableReference(VariableReferenceSyntax variableReference)
		{
			return this.Update(variableReference);
		}
	
	    public TerminalExpressionSyntax WithFunctionCallExpression(FunctionCallExpressionSyntax functionCallExpression)
		{
			return this.Update(functionCallExpression);
		}
	
	    public TerminalExpressionSyntax WithLiteral(LiteralSyntax literal)
		{
			return this.Update(literal);
		}
	
	    public TerminalExpressionSyntax Update(VariableReferenceSyntax variableReference)
	    {
	        if (this.VariableReference != variableReference)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TerminalExpression(variableReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TerminalExpressionSyntax Update(FunctionCallExpressionSyntax functionCallExpression)
	    {
	        if (this.FunctionCallExpression != functionCallExpression)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TerminalExpression(functionCallExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TerminalExpressionSyntax Update(LiteralSyntax literal)
	    {
	        if (this.Literal != literal)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TerminalExpression(literal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TerminalExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTerminalExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTerminalExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitTerminalExpression(this);
	    }
	}
	
	public sealed class FunctionCallExpressionSyntax : PilSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private ExpressionListSyntax expressionList;
	
	    public FunctionCallExpressionSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FunctionCallExpressionSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public SyntaxToken TOpenParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.FunctionCallExpressionGreen)this.Green;
				var greenToken = green.TOpenParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionListSyntax ExpressionList 
		{ 
			get { return this.GetRed(ref this.expressionList, 2); } 
		}
	    public SyntaxToken TCloseParen 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.FunctionCallExpressionGreen)this.Green;
				var greenToken = green.TCloseParen;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				case 2: return this.GetRed(ref this.expressionList, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				case 2: return this.expressionList;
				default: return null;
	        }
	    }
	
	    public FunctionCallExpressionSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier, this.TOpenParen, this.ExpressionList, this.TCloseParen);
		}
	
	    public FunctionCallExpressionSyntax WithTOpenParen(SyntaxToken tOpenParen)
		{
			return this.Update(this.Identifier, TOpenParen, this.ExpressionList, this.TCloseParen);
		}
	
	    public FunctionCallExpressionSyntax WithExpressionList(ExpressionListSyntax expressionList)
		{
			return this.Update(this.Identifier, this.TOpenParen, ExpressionList, this.TCloseParen);
		}
	
	    public FunctionCallExpressionSyntax WithTCloseParen(SyntaxToken tCloseParen)
		{
			return this.Update(this.Identifier, this.TOpenParen, this.ExpressionList, TCloseParen);
		}
	
	    public FunctionCallExpressionSyntax Update(IdentifierSyntax identifier, SyntaxToken tOpenParen, ExpressionListSyntax expressionList, SyntaxToken tCloseParen)
	    {
	        if (this.Identifier != identifier ||
				this.TOpenParen != tOpenParen ||
				this.ExpressionList != expressionList ||
				this.TCloseParen != tCloseParen)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.FunctionCallExpression(identifier, tOpenParen, expressionList, tCloseParen);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionCallExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFunctionCallExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFunctionCallExpression(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitFunctionCallExpression(this);
	    }
	}
	
	public sealed class VariableReferenceSyntax : PilSyntaxNode
	{
	    private SyntaxNode variableReferenceIdentifier;
	
	    public VariableReferenceSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VariableReferenceSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<VariableReferenceIdentifierSyntax> VariableReferenceIdentifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.variableReferenceIdentifier, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<VariableReferenceIdentifierSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableReferenceIdentifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableReferenceIdentifier;
				default: return null;
	        }
	    }
	
	    public VariableReferenceSyntax WithVariableReferenceIdentifier(SeparatedSyntaxList<VariableReferenceIdentifierSyntax> variableReferenceIdentifier)
		{
			return this.Update(VariableReferenceIdentifier);
		}
	
	    public VariableReferenceSyntax AddVariableReferenceIdentifier(params VariableReferenceIdentifierSyntax[] variableReferenceIdentifier)
		{
			return this.WithVariableReferenceIdentifier(this.VariableReferenceIdentifier.AddRange(variableReferenceIdentifier));
		}
	
	    public VariableReferenceSyntax Update(SeparatedSyntaxList<VariableReferenceIdentifierSyntax> variableReferenceIdentifier)
	    {
	        if (this.VariableReferenceIdentifier != variableReferenceIdentifier)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.VariableReference(variableReferenceIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVariableReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVariableReference(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitVariableReference(this);
	    }
	}
	
	public sealed class VariableReferenceIdentifierSyntax : PilSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public VariableReferenceIdentifierSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VariableReferenceIdentifierSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
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
	
	    public VariableReferenceIdentifierSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public VariableReferenceIdentifierSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.VariableReferenceIdentifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableReferenceIdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVariableReferenceIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVariableReferenceIdentifier(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitVariableReferenceIdentifier(this);
	    }
	}
	
	public sealed class CommentSyntax : PilSyntaxNode
	{
	
	    public CommentSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CommentSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LString 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.CommentGreen)this.Green;
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
	
	    public CommentSyntax WithLString(SyntaxToken lString)
		{
			return this.Update(LString);
		}
	
	    public CommentSyntax Update(SyntaxToken lString)
	    {
	        if (this.LString != lString)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Comment(lString);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CommentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitComment(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitComment(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitComment(this);
	    }
	}
	
	public sealed class LiteralSyntax : PilSyntaxNode
	{
	
	    public LiteralSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Literal 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.LiteralGreen)this.Green;
				var greenToken = green.Literal;
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
	
	    public LiteralSyntax WithLiteral(SyntaxToken literal)
		{
			return this.Update(Literal);
		}
	
	    public LiteralSyntax Update(SyntaxToken literal)
	    {
	        if (this.Literal != literal)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Literal(literal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteral(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteral(this);
	    }
	}
	
	public sealed class TypeReferenceSyntax : PilSyntaxNode
	{
	    private BuiltInTypeSyntax builtInType;
	    private IdentifierSyntax identifier;
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public BuiltInTypeSyntax BuiltInType 
		{ 
			get { return this.GetRed(ref this.builtInType, 0); } 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.builtInType, 0);
				case 1: return this.GetRed(ref this.identifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.builtInType;
				case 1: return this.identifier;
				default: return null;
	        }
	    }
	
	    public TypeReferenceSyntax WithBuiltInType(BuiltInTypeSyntax builtInType)
		{
			return this.Update(builtInType);
		}
	
	    public TypeReferenceSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(identifier);
		}
	
	    public TypeReferenceSyntax Update(BuiltInTypeSyntax builtInType)
	    {
	        if (this.BuiltInType != builtInType)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TypeReference(builtInType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TypeReferenceSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.TypeReference(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeReference(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeReference(this);
	    }
	}
	
	public sealed class BuiltInTypeSyntax : PilSyntaxNode
	{
	
	    public BuiltInTypeSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BuiltInTypeSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BuiltInType 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.BuiltInTypeGreen)this.Green;
				var greenToken = green.BuiltInType;
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
	
	    public BuiltInTypeSyntax WithBuiltInType(SyntaxToken builtInType)
		{
			return this.Update(BuiltInType);
		}
	
	    public BuiltInTypeSyntax Update(SyntaxToken builtInType)
	    {
	        if (this.BuiltInType != builtInType)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.BuiltInType(builtInType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BuiltInTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBuiltInType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBuiltInType(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitBuiltInType(this);
	    }
	}
	
	public sealed class QualifierListSyntax : PilSyntaxNode
	{
	    private SyntaxNode qualifier;
	
	    public QualifierListSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierListSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
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
	            var newNode = PilLanguage.Instance.SyntaxFactory.QualifierList(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifierList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifierList(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifierList(this);
	    }
	}
	
	public sealed class QualifierSyntax : PilSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public QualifierSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
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
	            var newNode = PilLanguage.Instance.SyntaxFactory.Qualifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifier(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifier(this);
	    }
	}
	
	public sealed class NameSyntax : PilSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
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
	            var newNode = PilLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class IdentifierListSyntax : PilSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public IdentifierListSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierListSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
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
	            var newNode = PilLanguage.Instance.SyntaxFactory.IdentifierList(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifierList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifierList(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifierList(this);
	    }
	}
	
	public sealed class IdentifierSyntax : PilSyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LIdentifier 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.IdentifierGreen)this.Green;
				var greenToken = green.LIdentifier;
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
	
	    public IdentifierSyntax WithLIdentifier(SyntaxToken lIdentifier)
		{
			return this.Update(LIdentifier);
		}
	
	    public IdentifierSyntax Update(SyntaxToken lIdentifier)
	    {
	        if (this.LIdentifier != lIdentifier)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.Identifier(lIdentifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class ResultIdentifierSyntax : PilSyntaxNode
	{
	
	    public ResultIdentifierSyntax(InternalSyntaxNode green, PilSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ResultIdentifierSyntax(InternalSyntaxNode green, PilSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KResult 
		{ 
			get 
			{ 
				var green = (global::PilV2.Syntax.InternalSyntax.ResultIdentifierGreen)this.Green;
				var greenToken = green.KResult;
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
	
	    public ResultIdentifierSyntax WithKResult(SyntaxToken kResult)
		{
			return this.Update(KResult);
		}
	
	    public ResultIdentifierSyntax Update(SyntaxToken kResult)
	    {
	        if (this.KResult != kResult)
	        {
	            var newNode = PilLanguage.Instance.SyntaxFactory.ResultIdentifier(kResult);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ResultIdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(IPilSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitResultIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(IPilSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitResultIdentifier(this);
	    }
	
	    public override void Accept(IPilSyntaxVisitor visitor)
	    {
	        visitor.VisitResultIdentifier(this);
	    }
	}
}

namespace PilV2
{
    using System.Threading;
    using Microsoft.CodeAnalysis.Text;
	using PilV2.Syntax;
    using PilV2.Syntax.InternalSyntax;

	public interface IPilSyntaxVisitor
	{
	    void VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node);
		
		void VisitMain(MainSyntax node);
		
		void VisitDeclaration(DeclarationSyntax node);
		
		void VisitTypeDefDeclaration(TypeDefDeclarationSyntax node);
		
		void VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node);
		
		void VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		void VisitEnumLiterals(EnumLiteralsSyntax node);
		
		void VisitEnumLiteral(EnumLiteralSyntax node);
		
		void VisitObjectDeclaration(ObjectDeclarationSyntax node);
		
		void VisitObjectHeader(ObjectHeaderSyntax node);
		
		void VisitPorts(PortsSyntax node);
		
		void VisitPort(PortSyntax node);
		
		void VisitObjectExternalParameters(ObjectExternalParametersSyntax node);
		
		void VisitObjectFields(ObjectFieldsSyntax node);
		
		void VisitObjectFunctions(ObjectFunctionsSyntax node);
		
		void VisitFunctionDeclaration(FunctionDeclarationSyntax node);
		
		void VisitFunctionHeader(FunctionHeaderSyntax node);
		
		void VisitFunctionParams(FunctionParamsSyntax node);
		
		void VisitParam(ParamSyntax node);
		
		void VisitQueryDeclaration(QueryDeclarationSyntax node);
		
		void VisitQueryHeader(QueryHeaderSyntax node);
		
		void VisitQueryRequestParams(QueryRequestParamsSyntax node);
		
		void VisitQueryAcceptParams(QueryAcceptParamsSyntax node);
		
		void VisitQueryRefuseParams(QueryRefuseParamsSyntax node);
		
		void VisitQueryCancelParams(QueryCancelParamsSyntax node);
		
		void VisitQueryExternalParameters(QueryExternalParametersSyntax node);
		
		void VisitQueryField(QueryFieldSyntax node);
		
		void VisitQueryFunction(QueryFunctionSyntax node);
		
		void VisitQueryObject(QueryObjectSyntax node);
		
		void VisitQueryObjectField(QueryObjectFieldSyntax node);
		
		void VisitQueryObjectFunction(QueryObjectFunctionSyntax node);
		
		void VisitQueryObjectEvent(QueryObjectEventSyntax node);
		
		void VisitInput(InputSyntax node);
		
		void VisitInputPortList(InputPortListSyntax node);
		
		void VisitInputPort(InputPortSyntax node);
		
		void VisitTrigger(TriggerSyntax node);
		
		void VisitTriggerVarList(TriggerVarListSyntax node);
		
		void VisitTriggerVar(TriggerVarSyntax node);
		
		void VisitStatements(StatementsSyntax node);
		
		void VisitStatement(StatementSyntax node);
		
		void VisitForkStatement(ForkStatementSyntax node);
		
		void VisitCaseBranch(CaseBranchSyntax node);
		
		void VisitElseBranch(ElseBranchSyntax node);
		
		void VisitIfStatement(IfStatementSyntax node);
		
		void VisitIfBranch(IfBranchSyntax node);
		
		void VisitElseIfBranch(ElseIfBranchSyntax node);
		
		void VisitRequestStatement(RequestStatementSyntax node);
		
		void VisitCallRequest(CallRequestSyntax node);
		
		void VisitRequestArguments(RequestArgumentsSyntax node);
		
		void VisitResponseStatement(ResponseStatementSyntax node);
		
		void VisitCancelStatement(CancelStatementSyntax node);
		
		void VisitAssertion(AssertionSyntax node);
		
		void VisitResponseStatementKind(ResponseStatementKindSyntax node);
		
		void VisitCancelStatementKind(CancelStatementKindSyntax node);
		
		void VisitForkRequestStatement(ForkRequestStatementSyntax node);
		
		void VisitForkRequestVariable(ForkRequestVariableSyntax node);
		
		void VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node);
		
		void VisitAcceptBranch(AcceptBranchSyntax node);
		
		void VisitRefuseBranch(RefuseBranchSyntax node);
		
		void VisitCancelBranch(CancelBranchSyntax node);
		
		void VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node);
		
		void VisitVariableDeclaration(VariableDeclarationSyntax node);
		
		void VisitAssignmentStatement(AssignmentStatementSyntax node);
		
		void VisitLeftSide(LeftSideSyntax node);
		
		void VisitExpressionList(ExpressionListSyntax node);
		
		void VisitExpression(ExpressionSyntax node);
		
		void VisitMulDivExpression(MulDivExpressionSyntax node);
		
		void VisitPlusMinusExpression(PlusMinusExpressionSyntax node);
		
		void VisitNegateExpression(NegateExpressionSyntax node);
		
		void VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node);
		
		void VisitOpMulDiv(OpMulDivSyntax node);
		
		void VisitOpAddSub(OpAddSubSyntax node);
		
		void VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node);
		
		void VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node);
		
		void VisitOpMinus(OpMinusSyntax node);
		
		void VisitAndExpression(AndExpressionSyntax node);
		
		void VisitOrExpression(OrExpressionSyntax node);
		
		void VisitNotExpression(NotExpressionSyntax node);
		
		void VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node);
		
		void VisitAndAlsoOp(AndAlsoOpSyntax node);
		
		void VisitOrElseOp(OrElseOpSyntax node);
		
		void VisitOpExcl(OpExclSyntax node);
		
		void VisitParenConditionalExpression(ParenConditionalExpressionSyntax node);
		
		void VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node);
		
		void VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node);
		
		void VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node);
		
		void VisitComparisonExpression(ComparisonExpressionSyntax node);
		
		void VisitComparisonOperator(ComparisonOperatorSyntax node);
		
		void VisitElementOfExpression(ElementOfExpressionSyntax node);
		
		void VisitElementOfValueList(ElementOfValueListSyntax node);
		
		void VisitElementOfValue(ElementOfValueSyntax node);
		
		void VisitTerminalExpression(TerminalExpressionSyntax node);
		
		void VisitFunctionCallExpression(FunctionCallExpressionSyntax node);
		
		void VisitVariableReference(VariableReferenceSyntax node);
		
		void VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node);
		
		void VisitComment(CommentSyntax node);
		
		void VisitLiteral(LiteralSyntax node);
		
		void VisitTypeReference(TypeReferenceSyntax node);
		
		void VisitBuiltInType(BuiltInTypeSyntax node);
		
		void VisitQualifierList(QualifierListSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitIdentifierList(IdentifierListSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitResultIdentifier(ResultIdentifierSyntax node);
	}
	
	public class PilSyntaxVisitor : SyntaxVisitor, IPilSyntaxVisitor
	{
	    public virtual void VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node)
	    {
	        this.DefaultVisit(node);
	    }
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeDefDeclaration(TypeDefDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
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
		
		public virtual void VisitObjectDeclaration(ObjectDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitObjectHeader(ObjectHeaderSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPorts(PortsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPort(PortSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitObjectExternalParameters(ObjectExternalParametersSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitObjectFields(ObjectFieldsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitObjectFunctions(ObjectFunctionsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFunctionHeader(FunctionHeaderSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFunctionParams(FunctionParamsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParam(ParamSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryDeclaration(QueryDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryHeader(QueryHeaderSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryRequestParams(QueryRequestParamsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryAcceptParams(QueryAcceptParamsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryRefuseParams(QueryRefuseParamsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryCancelParams(QueryCancelParamsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryExternalParameters(QueryExternalParametersSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryField(QueryFieldSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryFunction(QueryFunctionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryObject(QueryObjectSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryObjectField(QueryObjectFieldSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryObjectFunction(QueryObjectFunctionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQueryObjectEvent(QueryObjectEventSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInput(InputSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInputPortList(InputPortListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitInputPort(InputPortSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTrigger(TriggerSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTriggerVarList(TriggerVarListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTriggerVar(TriggerVarSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStatements(StatementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStatement(StatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitForkStatement(ForkStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCaseBranch(CaseBranchSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElseBranch(ElseBranchSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIfStatement(IfStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIfBranch(IfBranchSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElseIfBranch(ElseIfBranchSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRequestStatement(RequestStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCallRequest(CallRequestSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRequestArguments(RequestArgumentsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitResponseStatement(ResponseStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCancelStatement(CancelStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAssertion(AssertionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitResponseStatementKind(ResponseStatementKindSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCancelStatementKind(CancelStatementKindSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitForkRequestStatement(ForkRequestStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitForkRequestVariable(ForkRequestVariableSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAcceptBranch(AcceptBranchSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRefuseBranch(RefuseBranchSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCancelBranch(CancelBranchSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVariableDeclaration(VariableDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAssignmentStatement(AssignmentStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLeftSide(LeftSideSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitExpressionList(ExpressionListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitExpression(ExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMulDivExpression(MulDivExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPlusMinusExpression(PlusMinusExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNegateExpression(NegateExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOpMulDiv(OpMulDivSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOpAddSub(OpAddSubSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOpMinus(OpMinusSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAndExpression(AndExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOrExpression(OrExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNotExpression(NotExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAndAlsoOp(AndAlsoOpSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOrElseOp(OrElseOpSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitOpExcl(OpExclSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParenConditionalExpression(ParenConditionalExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComparisonExpression(ComparisonExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComparisonOperator(ComparisonOperatorSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElementOfExpression(ElementOfExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElementOfValueList(ElementOfValueListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElementOfValue(ElementOfValueSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTerminalExpression(TerminalExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVariableReference(VariableReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitComment(CommentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBuiltInType(BuiltInTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifierList(QualifierListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitName(NameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifierList(IdentifierListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitResultIdentifier(ResultIdentifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	//GenerateDetailedSyntaxVisitor()

	public interface IPilSyntaxVisitor<TArg, TResult> 
	{
	    TResult VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node, TArg argument);
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitDeclaration(DeclarationSyntax node, TArg argument);
		
		TResult VisitTypeDefDeclaration(TypeDefDeclarationSyntax node, TArg argument);
		
		TResult VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node, TArg argument);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node, TArg argument);
		
		TResult VisitEnumLiterals(EnumLiteralsSyntax node, TArg argument);
		
		TResult VisitEnumLiteral(EnumLiteralSyntax node, TArg argument);
		
		TResult VisitObjectDeclaration(ObjectDeclarationSyntax node, TArg argument);
		
		TResult VisitObjectHeader(ObjectHeaderSyntax node, TArg argument);
		
		TResult VisitPorts(PortsSyntax node, TArg argument);
		
		TResult VisitPort(PortSyntax node, TArg argument);
		
		TResult VisitObjectExternalParameters(ObjectExternalParametersSyntax node, TArg argument);
		
		TResult VisitObjectFields(ObjectFieldsSyntax node, TArg argument);
		
		TResult VisitObjectFunctions(ObjectFunctionsSyntax node, TArg argument);
		
		TResult VisitFunctionDeclaration(FunctionDeclarationSyntax node, TArg argument);
		
		TResult VisitFunctionHeader(FunctionHeaderSyntax node, TArg argument);
		
		TResult VisitFunctionParams(FunctionParamsSyntax node, TArg argument);
		
		TResult VisitParam(ParamSyntax node, TArg argument);
		
		TResult VisitQueryDeclaration(QueryDeclarationSyntax node, TArg argument);
		
		TResult VisitQueryHeader(QueryHeaderSyntax node, TArg argument);
		
		TResult VisitQueryRequestParams(QueryRequestParamsSyntax node, TArg argument);
		
		TResult VisitQueryAcceptParams(QueryAcceptParamsSyntax node, TArg argument);
		
		TResult VisitQueryRefuseParams(QueryRefuseParamsSyntax node, TArg argument);
		
		TResult VisitQueryCancelParams(QueryCancelParamsSyntax node, TArg argument);
		
		TResult VisitQueryExternalParameters(QueryExternalParametersSyntax node, TArg argument);
		
		TResult VisitQueryField(QueryFieldSyntax node, TArg argument);
		
		TResult VisitQueryFunction(QueryFunctionSyntax node, TArg argument);
		
		TResult VisitQueryObject(QueryObjectSyntax node, TArg argument);
		
		TResult VisitQueryObjectField(QueryObjectFieldSyntax node, TArg argument);
		
		TResult VisitQueryObjectFunction(QueryObjectFunctionSyntax node, TArg argument);
		
		TResult VisitQueryObjectEvent(QueryObjectEventSyntax node, TArg argument);
		
		TResult VisitInput(InputSyntax node, TArg argument);
		
		TResult VisitInputPortList(InputPortListSyntax node, TArg argument);
		
		TResult VisitInputPort(InputPortSyntax node, TArg argument);
		
		TResult VisitTrigger(TriggerSyntax node, TArg argument);
		
		TResult VisitTriggerVarList(TriggerVarListSyntax node, TArg argument);
		
		TResult VisitTriggerVar(TriggerVarSyntax node, TArg argument);
		
		TResult VisitStatements(StatementsSyntax node, TArg argument);
		
		TResult VisitStatement(StatementSyntax node, TArg argument);
		
		TResult VisitForkStatement(ForkStatementSyntax node, TArg argument);
		
		TResult VisitCaseBranch(CaseBranchSyntax node, TArg argument);
		
		TResult VisitElseBranch(ElseBranchSyntax node, TArg argument);
		
		TResult VisitIfStatement(IfStatementSyntax node, TArg argument);
		
		TResult VisitIfBranch(IfBranchSyntax node, TArg argument);
		
		TResult VisitElseIfBranch(ElseIfBranchSyntax node, TArg argument);
		
		TResult VisitRequestStatement(RequestStatementSyntax node, TArg argument);
		
		TResult VisitCallRequest(CallRequestSyntax node, TArg argument);
		
		TResult VisitRequestArguments(RequestArgumentsSyntax node, TArg argument);
		
		TResult VisitResponseStatement(ResponseStatementSyntax node, TArg argument);
		
		TResult VisitCancelStatement(CancelStatementSyntax node, TArg argument);
		
		TResult VisitAssertion(AssertionSyntax node, TArg argument);
		
		TResult VisitResponseStatementKind(ResponseStatementKindSyntax node, TArg argument);
		
		TResult VisitCancelStatementKind(CancelStatementKindSyntax node, TArg argument);
		
		TResult VisitForkRequestStatement(ForkRequestStatementSyntax node, TArg argument);
		
		TResult VisitForkRequestVariable(ForkRequestVariableSyntax node, TArg argument);
		
		TResult VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node, TArg argument);
		
		TResult VisitAcceptBranch(AcceptBranchSyntax node, TArg argument);
		
		TResult VisitRefuseBranch(RefuseBranchSyntax node, TArg argument);
		
		TResult VisitCancelBranch(CancelBranchSyntax node, TArg argument);
		
		TResult VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node, TArg argument);
		
		TResult VisitVariableDeclaration(VariableDeclarationSyntax node, TArg argument);
		
		TResult VisitAssignmentStatement(AssignmentStatementSyntax node, TArg argument);
		
		TResult VisitLeftSide(LeftSideSyntax node, TArg argument);
		
		TResult VisitExpressionList(ExpressionListSyntax node, TArg argument);
		
		TResult VisitExpression(ExpressionSyntax node, TArg argument);
		
		TResult VisitMulDivExpression(MulDivExpressionSyntax node, TArg argument);
		
		TResult VisitPlusMinusExpression(PlusMinusExpressionSyntax node, TArg argument);
		
		TResult VisitNegateExpression(NegateExpressionSyntax node, TArg argument);
		
		TResult VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node, TArg argument);
		
		TResult VisitOpMulDiv(OpMulDivSyntax node, TArg argument);
		
		TResult VisitOpAddSub(OpAddSubSyntax node, TArg argument);
		
		TResult VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node, TArg argument);
		
		TResult VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node, TArg argument);
		
		TResult VisitOpMinus(OpMinusSyntax node, TArg argument);
		
		TResult VisitAndExpression(AndExpressionSyntax node, TArg argument);
		
		TResult VisitOrExpression(OrExpressionSyntax node, TArg argument);
		
		TResult VisitNotExpression(NotExpressionSyntax node, TArg argument);
		
		TResult VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node, TArg argument);
		
		TResult VisitAndAlsoOp(AndAlsoOpSyntax node, TArg argument);
		
		TResult VisitOrElseOp(OrElseOpSyntax node, TArg argument);
		
		TResult VisitOpExcl(OpExclSyntax node, TArg argument);
		
		TResult VisitParenConditionalExpression(ParenConditionalExpressionSyntax node, TArg argument);
		
		TResult VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node, TArg argument);
		
		TResult VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node, TArg argument);
		
		TResult VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node, TArg argument);
		
		TResult VisitComparisonExpression(ComparisonExpressionSyntax node, TArg argument);
		
		TResult VisitComparisonOperator(ComparisonOperatorSyntax node, TArg argument);
		
		TResult VisitElementOfExpression(ElementOfExpressionSyntax node, TArg argument);
		
		TResult VisitElementOfValueList(ElementOfValueListSyntax node, TArg argument);
		
		TResult VisitElementOfValue(ElementOfValueSyntax node, TArg argument);
		
		TResult VisitTerminalExpression(TerminalExpressionSyntax node, TArg argument);
		
		TResult VisitFunctionCallExpression(FunctionCallExpressionSyntax node, TArg argument);
		
		TResult VisitVariableReference(VariableReferenceSyntax node, TArg argument);
		
		TResult VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node, TArg argument);
		
		TResult VisitComment(CommentSyntax node, TArg argument);
		
		TResult VisitLiteral(LiteralSyntax node, TArg argument);
		
		TResult VisitTypeReference(TypeReferenceSyntax node, TArg argument);
		
		TResult VisitBuiltInType(BuiltInTypeSyntax node, TArg argument);
		
		TResult VisitQualifierList(QualifierListSyntax node, TArg argument);
		
		TResult VisitQualifier(QualifierSyntax node, TArg argument);
		
		TResult VisitName(NameSyntax node, TArg argument);
		
		TResult VisitIdentifierList(IdentifierListSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
		TResult VisitResultIdentifier(ResultIdentifierSyntax node, TArg argument);
	}
	
	public class PilSyntaxVisitor<TArg, TResult> : SyntaxVisitor<TArg, TResult>, IPilSyntaxVisitor<TArg, TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node, TArg argument)
	    {
	        return this.DefaultVisit(node, argument);
	    }
		
		public virtual TResult VisitMain(MainSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration(DeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeDefDeclaration(TypeDefDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEnumDeclaration(EnumDeclarationSyntax node, TArg argument)
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
		
		public virtual TResult VisitObjectDeclaration(ObjectDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitObjectHeader(ObjectHeaderSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPorts(PortsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPort(PortSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitObjectExternalParameters(ObjectExternalParametersSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitObjectFields(ObjectFieldsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitObjectFunctions(ObjectFunctionsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFunctionDeclaration(FunctionDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFunctionHeader(FunctionHeaderSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFunctionParams(FunctionParamsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParam(ParamSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryDeclaration(QueryDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryHeader(QueryHeaderSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryRequestParams(QueryRequestParamsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryAcceptParams(QueryAcceptParamsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryRefuseParams(QueryRefuseParamsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryCancelParams(QueryCancelParamsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryExternalParameters(QueryExternalParametersSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryField(QueryFieldSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryFunction(QueryFunctionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryObject(QueryObjectSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryObjectField(QueryObjectFieldSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryObjectFunction(QueryObjectFunctionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQueryObjectEvent(QueryObjectEventSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitInput(InputSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitInputPortList(InputPortListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitInputPort(InputPortSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTrigger(TriggerSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTriggerVarList(TriggerVarListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTriggerVar(TriggerVarSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStatements(StatementsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStatement(StatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitForkStatement(ForkStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCaseBranch(CaseBranchSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElseBranch(ElseBranchSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIfStatement(IfStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIfBranch(IfBranchSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElseIfBranch(ElseIfBranchSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRequestStatement(RequestStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCallRequest(CallRequestSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRequestArguments(RequestArgumentsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitResponseStatement(ResponseStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCancelStatement(CancelStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAssertion(AssertionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitResponseStatementKind(ResponseStatementKindSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCancelStatementKind(CancelStatementKindSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitForkRequestStatement(ForkRequestStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitForkRequestVariable(ForkRequestVariableSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAcceptBranch(AcceptBranchSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRefuseBranch(RefuseBranchSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCancelBranch(CancelBranchSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVariableDeclaration(VariableDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAssignmentStatement(AssignmentStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLeftSide(LeftSideSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitExpressionList(ExpressionListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitExpression(ExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMulDivExpression(MulDivExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPlusMinusExpression(PlusMinusExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNegateExpression(NegateExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOpMulDiv(OpMulDivSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOpAddSub(OpAddSubSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOpMinus(OpMinusSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAndExpression(AndExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOrExpression(OrExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNotExpression(NotExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAndAlsoOp(AndAlsoOpSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOrElseOp(OrElseOpSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitOpExcl(OpExclSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParenConditionalExpression(ParenConditionalExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComparisonExpression(ComparisonExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComparisonOperator(ComparisonOperatorSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElementOfExpression(ElementOfExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElementOfValueList(ElementOfValueListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElementOfValue(ElementOfValueSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTerminalExpression(TerminalExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFunctionCallExpression(FunctionCallExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVariableReference(VariableReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitComment(CommentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLiteral(LiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeReference(TypeReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBuiltInType(BuiltInTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQualifierList(QualifierListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQualifier(QualifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitName(NameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifierList(IdentifierListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitResultIdentifier(ResultIdentifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
	}

	public interface IPilSyntaxVisitor<TResult> 
	{
	    TResult VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node);
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitDeclaration(DeclarationSyntax node);
		
		TResult VisitTypeDefDeclaration(TypeDefDeclarationSyntax node);
		
		TResult VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node);
		
		TResult VisitEnumDeclaration(EnumDeclarationSyntax node);
		
		TResult VisitEnumLiterals(EnumLiteralsSyntax node);
		
		TResult VisitEnumLiteral(EnumLiteralSyntax node);
		
		TResult VisitObjectDeclaration(ObjectDeclarationSyntax node);
		
		TResult VisitObjectHeader(ObjectHeaderSyntax node);
		
		TResult VisitPorts(PortsSyntax node);
		
		TResult VisitPort(PortSyntax node);
		
		TResult VisitObjectExternalParameters(ObjectExternalParametersSyntax node);
		
		TResult VisitObjectFields(ObjectFieldsSyntax node);
		
		TResult VisitObjectFunctions(ObjectFunctionsSyntax node);
		
		TResult VisitFunctionDeclaration(FunctionDeclarationSyntax node);
		
		TResult VisitFunctionHeader(FunctionHeaderSyntax node);
		
		TResult VisitFunctionParams(FunctionParamsSyntax node);
		
		TResult VisitParam(ParamSyntax node);
		
		TResult VisitQueryDeclaration(QueryDeclarationSyntax node);
		
		TResult VisitQueryHeader(QueryHeaderSyntax node);
		
		TResult VisitQueryRequestParams(QueryRequestParamsSyntax node);
		
		TResult VisitQueryAcceptParams(QueryAcceptParamsSyntax node);
		
		TResult VisitQueryRefuseParams(QueryRefuseParamsSyntax node);
		
		TResult VisitQueryCancelParams(QueryCancelParamsSyntax node);
		
		TResult VisitQueryExternalParameters(QueryExternalParametersSyntax node);
		
		TResult VisitQueryField(QueryFieldSyntax node);
		
		TResult VisitQueryFunction(QueryFunctionSyntax node);
		
		TResult VisitQueryObject(QueryObjectSyntax node);
		
		TResult VisitQueryObjectField(QueryObjectFieldSyntax node);
		
		TResult VisitQueryObjectFunction(QueryObjectFunctionSyntax node);
		
		TResult VisitQueryObjectEvent(QueryObjectEventSyntax node);
		
		TResult VisitInput(InputSyntax node);
		
		TResult VisitInputPortList(InputPortListSyntax node);
		
		TResult VisitInputPort(InputPortSyntax node);
		
		TResult VisitTrigger(TriggerSyntax node);
		
		TResult VisitTriggerVarList(TriggerVarListSyntax node);
		
		TResult VisitTriggerVar(TriggerVarSyntax node);
		
		TResult VisitStatements(StatementsSyntax node);
		
		TResult VisitStatement(StatementSyntax node);
		
		TResult VisitForkStatement(ForkStatementSyntax node);
		
		TResult VisitCaseBranch(CaseBranchSyntax node);
		
		TResult VisitElseBranch(ElseBranchSyntax node);
		
		TResult VisitIfStatement(IfStatementSyntax node);
		
		TResult VisitIfBranch(IfBranchSyntax node);
		
		TResult VisitElseIfBranch(ElseIfBranchSyntax node);
		
		TResult VisitRequestStatement(RequestStatementSyntax node);
		
		TResult VisitCallRequest(CallRequestSyntax node);
		
		TResult VisitRequestArguments(RequestArgumentsSyntax node);
		
		TResult VisitResponseStatement(ResponseStatementSyntax node);
		
		TResult VisitCancelStatement(CancelStatementSyntax node);
		
		TResult VisitAssertion(AssertionSyntax node);
		
		TResult VisitResponseStatementKind(ResponseStatementKindSyntax node);
		
		TResult VisitCancelStatementKind(CancelStatementKindSyntax node);
		
		TResult VisitForkRequestStatement(ForkRequestStatementSyntax node);
		
		TResult VisitForkRequestVariable(ForkRequestVariableSyntax node);
		
		TResult VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node);
		
		TResult VisitAcceptBranch(AcceptBranchSyntax node);
		
		TResult VisitRefuseBranch(RefuseBranchSyntax node);
		
		TResult VisitCancelBranch(CancelBranchSyntax node);
		
		TResult VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node);
		
		TResult VisitVariableDeclaration(VariableDeclarationSyntax node);
		
		TResult VisitAssignmentStatement(AssignmentStatementSyntax node);
		
		TResult VisitLeftSide(LeftSideSyntax node);
		
		TResult VisitExpressionList(ExpressionListSyntax node);
		
		TResult VisitExpression(ExpressionSyntax node);
		
		TResult VisitMulDivExpression(MulDivExpressionSyntax node);
		
		TResult VisitPlusMinusExpression(PlusMinusExpressionSyntax node);
		
		TResult VisitNegateExpression(NegateExpressionSyntax node);
		
		TResult VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node);
		
		TResult VisitOpMulDiv(OpMulDivSyntax node);
		
		TResult VisitOpAddSub(OpAddSubSyntax node);
		
		TResult VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node);
		
		TResult VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node);
		
		TResult VisitOpMinus(OpMinusSyntax node);
		
		TResult VisitAndExpression(AndExpressionSyntax node);
		
		TResult VisitOrExpression(OrExpressionSyntax node);
		
		TResult VisitNotExpression(NotExpressionSyntax node);
		
		TResult VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node);
		
		TResult VisitAndAlsoOp(AndAlsoOpSyntax node);
		
		TResult VisitOrElseOp(OrElseOpSyntax node);
		
		TResult VisitOpExcl(OpExclSyntax node);
		
		TResult VisitParenConditionalExpression(ParenConditionalExpressionSyntax node);
		
		TResult VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node);
		
		TResult VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node);
		
		TResult VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node);
		
		TResult VisitComparisonExpression(ComparisonExpressionSyntax node);
		
		TResult VisitComparisonOperator(ComparisonOperatorSyntax node);
		
		TResult VisitElementOfExpression(ElementOfExpressionSyntax node);
		
		TResult VisitElementOfValueList(ElementOfValueListSyntax node);
		
		TResult VisitElementOfValue(ElementOfValueSyntax node);
		
		TResult VisitTerminalExpression(TerminalExpressionSyntax node);
		
		TResult VisitFunctionCallExpression(FunctionCallExpressionSyntax node);
		
		TResult VisitVariableReference(VariableReferenceSyntax node);
		
		TResult VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node);
		
		TResult VisitComment(CommentSyntax node);
		
		TResult VisitLiteral(LiteralSyntax node);
		
		TResult VisitTypeReference(TypeReferenceSyntax node);
		
		TResult VisitBuiltInType(BuiltInTypeSyntax node);
		
		TResult VisitQualifierList(QualifierListSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitIdentifierList(IdentifierListSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitResultIdentifier(ResultIdentifierSyntax node);
	}
	
	public class PilSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, IPilSyntaxVisitor<TResult>
	{
	    public virtual TResult VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node)
	    {
	        return this.DefaultVisit(node);
	    }
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration(DeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeDefDeclaration(TypeDefDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEnumDeclaration(EnumDeclarationSyntax node)
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
		
		public virtual TResult VisitObjectDeclaration(ObjectDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitObjectHeader(ObjectHeaderSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPorts(PortsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPort(PortSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitObjectExternalParameters(ObjectExternalParametersSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitObjectFields(ObjectFieldsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitObjectFunctions(ObjectFunctionsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFunctionDeclaration(FunctionDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFunctionHeader(FunctionHeaderSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFunctionParams(FunctionParamsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParam(ParamSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryDeclaration(QueryDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryHeader(QueryHeaderSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryRequestParams(QueryRequestParamsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryAcceptParams(QueryAcceptParamsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryRefuseParams(QueryRefuseParamsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryCancelParams(QueryCancelParamsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryExternalParameters(QueryExternalParametersSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryField(QueryFieldSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryFunction(QueryFunctionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryObject(QueryObjectSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryObjectField(QueryObjectFieldSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryObjectFunction(QueryObjectFunctionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQueryObjectEvent(QueryObjectEventSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInput(InputSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInputPortList(InputPortListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitInputPort(InputPortSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTrigger(TriggerSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTriggerVarList(TriggerVarListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTriggerVar(TriggerVarSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStatements(StatementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStatement(StatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitForkStatement(ForkStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCaseBranch(CaseBranchSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElseBranch(ElseBranchSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIfStatement(IfStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIfBranch(IfBranchSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElseIfBranch(ElseIfBranchSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRequestStatement(RequestStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCallRequest(CallRequestSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRequestArguments(RequestArgumentsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitResponseStatement(ResponseStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCancelStatement(CancelStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAssertion(AssertionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitResponseStatementKind(ResponseStatementKindSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCancelStatementKind(CancelStatementKindSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitForkRequestStatement(ForkRequestStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitForkRequestVariable(ForkRequestVariableSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAcceptBranch(AcceptBranchSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRefuseBranch(RefuseBranchSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCancelBranch(CancelBranchSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVariableDeclaration(VariableDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAssignmentStatement(AssignmentStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLeftSide(LeftSideSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitExpressionList(ExpressionListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitExpression(ExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMulDivExpression(MulDivExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPlusMinusExpression(PlusMinusExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNegateExpression(NegateExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOpMulDiv(OpMulDivSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOpAddSub(OpAddSubSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOpMinus(OpMinusSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAndExpression(AndExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOrExpression(OrExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNotExpression(NotExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAndAlsoOp(AndAlsoOpSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOrElseOp(OrElseOpSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitOpExcl(OpExclSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParenConditionalExpression(ParenConditionalExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComparisonExpression(ComparisonExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComparisonOperator(ComparisonOperatorSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElementOfExpression(ElementOfExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElementOfValueList(ElementOfValueListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElementOfValue(ElementOfValueSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTerminalExpression(TerminalExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVariableReference(VariableReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitComment(CommentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLiteral(LiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeReference(TypeReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBuiltInType(BuiltInTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifierList(QualifierListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifier(QualifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitName(NameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifierList(IdentifierListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifier(IdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitResultIdentifier(ResultIdentifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class PilSyntaxRewriter : SyntaxRewriter, IPilSyntaxVisitor<SyntaxNode>
	{
	    public PilSyntaxRewriter(bool visitIntoStructuredTrivia = false)
			: base(PilLanguage.Instance, visitIntoStructuredTrivia)
	    {
	    }
	
	    public virtual SyntaxNode VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node)
	    {
	      var tokens = this.VisitList(node.Tokens);
	      return node.Update(tokens);
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var declaration = this.VisitList(node.Declaration);
		    var eOF = this.VisitToken(node.EndOfFileToken);
			return node.Update(declaration, eOF);
		}
		
		public virtual SyntaxNode VisitDeclaration(DeclarationSyntax node)
		{
			var oldTypeDefDeclaration = node.TypeDefDeclaration;
			if (oldTypeDefDeclaration != null)
			{
			    var newTypeDefDeclaration = (TypeDefDeclarationSyntax)this.Visit(oldTypeDefDeclaration);
				return node.Update(newTypeDefDeclaration);
			}
			var oldExternalParameterDeclaration = node.ExternalParameterDeclaration;
			if (oldExternalParameterDeclaration != null)
			{
			    var newExternalParameterDeclaration = (ExternalParameterDeclarationSyntax)this.Visit(oldExternalParameterDeclaration);
				return node.Update(newExternalParameterDeclaration);
			}
			var oldEnumDeclaration = node.EnumDeclaration;
			if (oldEnumDeclaration != null)
			{
			    var newEnumDeclaration = (EnumDeclarationSyntax)this.Visit(oldEnumDeclaration);
				return node.Update(newEnumDeclaration);
			}
			var oldObjectDeclaration = node.ObjectDeclaration;
			if (oldObjectDeclaration != null)
			{
			    var newObjectDeclaration = (ObjectDeclarationSyntax)this.Visit(oldObjectDeclaration);
				return node.Update(newObjectDeclaration);
			}
			var oldFunctionDeclaration = node.FunctionDeclaration;
			if (oldFunctionDeclaration != null)
			{
			    var newFunctionDeclaration = (FunctionDeclarationSyntax)this.Visit(oldFunctionDeclaration);
				return node.Update(newFunctionDeclaration);
			}
			var oldQueryDeclaration = node.QueryDeclaration;
			if (oldQueryDeclaration != null)
			{
			    var newQueryDeclaration = (QueryDeclarationSyntax)this.Visit(oldQueryDeclaration);
				return node.Update(newQueryDeclaration);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTypeDefDeclaration(TypeDefDeclarationSyntax node)
		{
		    var kTypeDef = this.VisitToken(node.KTypeDef);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kTypeDef, name, tColon, typeReference, tSemicolon);
		}
		
		public virtual SyntaxNode VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node)
		{
		    var kParam = this.VisitToken(node.KParam);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tAssign = this.VisitToken(node.TAssign);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kParam, name, tColon, typeReference, tAssign, expression, tSemicolon);
		}
		
		public virtual SyntaxNode VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
		    var kEnum = this.VisitToken(node.KEnum);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var enumLiterals = (EnumLiteralsSyntax)this.Visit(node.EnumLiterals);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kEnum, name, tOpenBracket, enumLiterals, tCloseBracket, tSemicolon);
		}
		
		public virtual SyntaxNode VisitEnumLiterals(EnumLiteralsSyntax node)
		{
		    var enumLiteral = this.VisitList(node.EnumLiteral);
			return node.Update(enumLiteral);
		}
		
		public virtual SyntaxNode VisitEnumLiteral(EnumLiteralSyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(name);
		}
		
		public virtual SyntaxNode VisitObjectDeclaration(ObjectDeclarationSyntax node)
		{
		    var kObject = this.VisitToken(node.KObject);
		    var objectHeader = (ObjectHeaderSyntax)this.Visit(node.ObjectHeader);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var objectExternalParameters = (ObjectExternalParametersSyntax)this.Visit(node.ObjectExternalParameters);
		    var objectFields = (ObjectFieldsSyntax)this.Visit(node.ObjectFields);
		    var objectFunctions = (ObjectFunctionsSyntax)this.Visit(node.ObjectFunctions);
		    var kEndObject = this.VisitToken(node.KEndObject);
			return node.Update(kObject, objectHeader, tSemicolon, objectExternalParameters, objectFields, objectFunctions, kEndObject);
		}
		
		public virtual SyntaxNode VisitObjectHeader(ObjectHeaderSyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var ports = (PortsSyntax)this.Visit(node.Ports);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(name, tOpenParen, ports, tCloseParen);
		}
		
		public virtual SyntaxNode VisitPorts(PortsSyntax node)
		{
		    var port = this.VisitList(node.Port);
			return node.Update(port);
		}
		
		public virtual SyntaxNode VisitPort(PortSyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(name);
		}
		
		public virtual SyntaxNode VisitObjectExternalParameters(ObjectExternalParametersSyntax node)
		{
		    var externalParameterDeclaration = this.VisitList(node.ExternalParameterDeclaration);
			return node.Update(externalParameterDeclaration);
		}
		
		public virtual SyntaxNode VisitObjectFields(ObjectFieldsSyntax node)
		{
		    var variableDeclaration = this.VisitList(node.VariableDeclaration);
			return node.Update(variableDeclaration);
		}
		
		public virtual SyntaxNode VisitObjectFunctions(ObjectFunctionsSyntax node)
		{
		    var functionDeclaration = this.VisitList(node.FunctionDeclaration);
			return node.Update(functionDeclaration);
		}
		
		public virtual SyntaxNode VisitFunctionDeclaration(FunctionDeclarationSyntax node)
		{
		    var kFunction = this.VisitToken(node.KFunction);
		    var functionHeader = (FunctionHeaderSyntax)this.Visit(node.FunctionHeader);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var statements = (StatementsSyntax)this.Visit(node.Statements);
		    var kEndFunction = this.VisitToken(node.KEndFunction);
			return node.Update(kFunction, functionHeader, comment, tSemicolon, statements, kEndFunction);
		}
		
		public virtual SyntaxNode VisitFunctionHeader(FunctionHeaderSyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var functionParams = (FunctionParamsSyntax)this.Visit(node.FunctionParams);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
		    var tColon = this.VisitToken(node.TColon);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
			return node.Update(name, tOpenParen, functionParams, tCloseParen, tColon, typeReference);
		}
		
		public virtual SyntaxNode VisitFunctionParams(FunctionParamsSyntax node)
		{
		    var param = this.VisitList(node.Param);
			return node.Update(param);
		}
		
		public virtual SyntaxNode VisitParam(ParamSyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
			return node.Update(name, tColon, typeReference);
		}
		
		public virtual SyntaxNode VisitQueryDeclaration(QueryDeclarationSyntax node)
		{
		    var kQuery = this.VisitToken(node.KQuery);
		    var queryHeader = (QueryHeaderSyntax)this.Visit(node.QueryHeader);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var startQuerySemicolon = this.VisitToken(node.StartQuerySemicolon);
		    var queryExternalParameters = this.VisitList(node.QueryExternalParameters);
		    var queryField = this.VisitList(node.QueryField);
		    var functionDeclaration = this.VisitList(node.FunctionDeclaration);
		    var queryObject = this.VisitList(node.QueryObject);
		    var kEndQuery = this.VisitToken(node.KEndQuery);
		    var endName = (IdentifierSyntax)this.Visit(node.EndName);
		    var endQuerySemicolon = this.VisitToken(node.EndQuerySemicolon);
			return node.Update(kQuery, queryHeader, comment, startQuerySemicolon, queryExternalParameters, queryField, functionDeclaration, queryObject, kEndQuery, endName, endQuerySemicolon);
		}
		
		public virtual SyntaxNode VisitQueryHeader(QueryHeaderSyntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var queryRequestParams = (QueryRequestParamsSyntax)this.Visit(node.QueryRequestParams);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(name, tOpenParen, queryRequestParams, tCloseParen);
		}
		
		public virtual SyntaxNode VisitQueryRequestParams(QueryRequestParamsSyntax node)
		{
		    var kRequest = this.VisitToken(node.KRequest);
		    var param = this.VisitList(node.Param);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kRequest, param, tSemicolon);
		}
		
		public virtual SyntaxNode VisitQueryAcceptParams(QueryAcceptParamsSyntax node)
		{
		    var kAccept = this.VisitToken(node.KAccept);
		    var param = this.VisitList(node.Param);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kAccept, param, tSemicolon);
		}
		
		public virtual SyntaxNode VisitQueryRefuseParams(QueryRefuseParamsSyntax node)
		{
		    var kRefuse = this.VisitToken(node.KRefuse);
		    var param = this.VisitList(node.Param);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kRefuse, param, tSemicolon);
		}
		
		public virtual SyntaxNode VisitQueryCancelParams(QueryCancelParamsSyntax node)
		{
		    var kCancel = this.VisitToken(node.KCancel);
		    var param = this.VisitList(node.Param);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kCancel, param, tSemicolon);
		}
		
		public virtual SyntaxNode VisitQueryExternalParameters(QueryExternalParametersSyntax node)
		{
		    var externalParameterDeclaration = (ExternalParameterDeclarationSyntax)this.Visit(node.ExternalParameterDeclaration);
			return node.Update(externalParameterDeclaration);
		}
		
		public virtual SyntaxNode VisitQueryField(QueryFieldSyntax node)
		{
		    var variableDeclaration = (VariableDeclarationSyntax)this.Visit(node.VariableDeclaration);
			return node.Update(variableDeclaration);
		}
		
		public virtual SyntaxNode VisitQueryFunction(QueryFunctionSyntax node)
		{
		    var functionDeclaration = (FunctionDeclarationSyntax)this.Visit(node.FunctionDeclaration);
			return node.Update(functionDeclaration);
		}
		
		public virtual SyntaxNode VisitQueryObject(QueryObjectSyntax node)
		{
		    var kObject = this.VisitToken(node.KObject);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var startObjectSemicolon = this.VisitToken(node.StartObjectSemicolon);
		    var queryObjectField = this.VisitList(node.QueryObjectField);
		    var queryObjectFunction = this.VisitList(node.QueryObjectFunction);
		    var queryObjectEvent = this.VisitList(node.QueryObjectEvent);
		    var kEndObject = this.VisitToken(node.KEndObject);
		    var endName = (IdentifierSyntax)this.Visit(node.EndName);
		    var endObjectSemicolon = this.VisitToken(node.EndObjectSemicolon);
			return node.Update(kObject, name, comment, startObjectSemicolon, queryObjectField, queryObjectFunction, queryObjectEvent, kEndObject, endName, endObjectSemicolon);
		}
		
		public virtual SyntaxNode VisitQueryObjectField(QueryObjectFieldSyntax node)
		{
		    var variableDeclaration = (VariableDeclarationSyntax)this.Visit(node.VariableDeclaration);
			return node.Update(variableDeclaration);
		}
		
		public virtual SyntaxNode VisitQueryObjectFunction(QueryObjectFunctionSyntax node)
		{
		    var functionDeclaration = (FunctionDeclarationSyntax)this.Visit(node.FunctionDeclaration);
			return node.Update(functionDeclaration);
		}
		
		public virtual SyntaxNode VisitQueryObjectEvent(QueryObjectEventSyntax node)
		{
			var oldInput = node.Input;
			if (oldInput != null)
			{
			    var newInput = (InputSyntax)this.Visit(oldInput);
				return node.Update(newInput);
			}
			var oldTrigger = node.Trigger;
			if (oldTrigger != null)
			{
			    var newTrigger = (TriggerSyntax)this.Visit(oldTrigger);
				return node.Update(newTrigger);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitInput(InputSyntax node)
		{
		    var kInput = this.VisitToken(node.KInput);
		    var inputPortList = (InputPortListSyntax)this.Visit(node.InputPortList);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var statements = (StatementsSyntax)this.Visit(node.Statements);
			return node.Update(kInput, inputPortList, comment, tSemicolon, statements);
		}
		
		public virtual SyntaxNode VisitInputPortList(InputPortListSyntax node)
		{
		    var inputPort = this.VisitList(node.InputPort);
			return node.Update(inputPort);
		}
		
		public virtual SyntaxNode VisitInputPort(InputPortSyntax node)
		{
		    var portName = (IdentifierSyntax)this.Visit(node.PortName);
		    var tDot = this.VisitToken(node.TDot);
		    var queryName = (IdentifierSyntax)this.Visit(node.QueryName);
			return node.Update(portName, tDot, queryName);
		}
		
		public virtual SyntaxNode VisitTrigger(TriggerSyntax node)
		{
		    var kTrigger = this.VisitToken(node.KTrigger);
		    var triggerVarList = (TriggerVarListSyntax)this.Visit(node.TriggerVarList);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var statements = (StatementsSyntax)this.Visit(node.Statements);
			return node.Update(kTrigger, triggerVarList, comment, tSemicolon, statements);
		}
		
		public virtual SyntaxNode VisitTriggerVarList(TriggerVarListSyntax node)
		{
		    var triggerVar = this.VisitList(node.TriggerVar);
			return node.Update(triggerVar);
		}
		
		public virtual SyntaxNode VisitTriggerVar(TriggerVarSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitStatements(StatementsSyntax node)
		{
		    var statement = this.VisitList(node.Statement);
			return node.Update(statement);
		}
		
		public virtual SyntaxNode VisitStatement(StatementSyntax node)
		{
			var oldVariableDeclarationStatement = node.VariableDeclarationStatement;
			if (oldVariableDeclarationStatement != null)
			{
			    var newVariableDeclarationStatement = (VariableDeclarationStatementSyntax)this.Visit(oldVariableDeclarationStatement);
				return node.Update(newVariableDeclarationStatement);
			}
			var oldRequestStatement = node.RequestStatement;
			if (oldRequestStatement != null)
			{
			    var newRequestStatement = (RequestStatementSyntax)this.Visit(oldRequestStatement);
				return node.Update(newRequestStatement);
			}
			var oldForkStatement = node.ForkStatement;
			if (oldForkStatement != null)
			{
			    var newForkStatement = (ForkStatementSyntax)this.Visit(oldForkStatement);
				return node.Update(newForkStatement);
			}
			var oldForkRequestStatement = node.ForkRequestStatement;
			if (oldForkRequestStatement != null)
			{
			    var newForkRequestStatement = (ForkRequestStatementSyntax)this.Visit(oldForkRequestStatement);
				return node.Update(newForkRequestStatement);
			}
			var oldIfStatement = node.IfStatement;
			if (oldIfStatement != null)
			{
			    var newIfStatement = (IfStatementSyntax)this.Visit(oldIfStatement);
				return node.Update(newIfStatement);
			}
			var oldResponseStatement = node.ResponseStatement;
			if (oldResponseStatement != null)
			{
			    var newResponseStatement = (ResponseStatementSyntax)this.Visit(oldResponseStatement);
				return node.Update(newResponseStatement);
			}
			var oldCancelStatement = node.CancelStatement;
			if (oldCancelStatement != null)
			{
			    var newCancelStatement = (CancelStatementSyntax)this.Visit(oldCancelStatement);
				return node.Update(newCancelStatement);
			}
			var oldAssignmentStatement = node.AssignmentStatement;
			if (oldAssignmentStatement != null)
			{
			    var newAssignmentStatement = (AssignmentStatementSyntax)this.Visit(oldAssignmentStatement);
				return node.Update(newAssignmentStatement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitForkStatement(ForkStatementSyntax node)
		{
		    var kFork = this.VisitToken(node.KFork);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var caseBranch = this.VisitList(node.CaseBranch);
		    var elseBranch = (ElseBranchSyntax)this.Visit(node.ElseBranch);
		    var kEndFork = this.VisitToken(node.KEndFork);
			return node.Update(kFork, expression, caseBranch, elseBranch, kEndFork);
		}
		
		public virtual SyntaxNode VisitCaseBranch(CaseBranchSyntax node)
		{
		    var kCase = this.VisitToken(node.KCase);
		    var condition = (ExpressionSyntax)this.Visit(node.Condition);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var statements = (StatementsSyntax)this.Visit(node.Statements);
			return node.Update(kCase, condition, comment, tSemicolon, statements);
		}
		
		public virtual SyntaxNode VisitElseBranch(ElseBranchSyntax node)
		{
		    var kElse = this.VisitToken(node.KElse);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var statements = (StatementsSyntax)this.Visit(node.Statements);
			return node.Update(kElse, comment, statements);
		}
		
		public virtual SyntaxNode VisitIfStatement(IfStatementSyntax node)
		{
		    var kIf = this.VisitToken(node.KIf);
		    var ifBranch = (IfBranchSyntax)this.Visit(node.IfBranch);
		    var elseIfBranch = this.VisitList(node.ElseIfBranch);
		    var elseBranch = this.VisitList(node.ElseBranch);
		    var kEndIf = this.VisitToken(node.KEndIf);
			return node.Update(kIf, ifBranch, elseIfBranch, elseBranch, kEndIf);
		}
		
		public virtual SyntaxNode VisitIfBranch(IfBranchSyntax node)
		{
		    var conditionalExpression = (ConditionalExpressionSyntax)this.Visit(node.ConditionalExpression);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var statements = (StatementsSyntax)this.Visit(node.Statements);
			return node.Update(conditionalExpression, comment, tSemicolon, statements);
		}
		
		public virtual SyntaxNode VisitElseIfBranch(ElseIfBranchSyntax node)
		{
		    var kElse = this.VisitToken(node.KElse);
		    var kIf = this.VisitToken(node.KIf);
		    var ifBranch = (IfBranchSyntax)this.Visit(node.IfBranch);
			return node.Update(kElse, kIf, ifBranch);
		}
		
		public virtual SyntaxNode VisitRequestStatement(RequestStatementSyntax node)
		{
		    var leftSide = (LeftSideSyntax)this.Visit(node.LeftSide);
		    var tAssign = this.VisitToken(node.TAssign);
		    var callRequest = (CallRequestSyntax)this.Visit(node.CallRequest);
		    var assertion = (AssertionSyntax)this.Visit(node.Assertion);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(leftSide, tAssign, callRequest, assertion, tSemicolon);
		}
		
		public virtual SyntaxNode VisitCallRequest(CallRequestSyntax node)
		{
		    var kRequest = this.VisitToken(node.KRequest);
		    var portName = (IdentifierSyntax)this.Visit(node.PortName);
		    var tDot = this.VisitToken(node.TDot);
		    var queryName = (IdentifierSyntax)this.Visit(node.QueryName);
		    var requestArguments = (RequestArgumentsSyntax)this.Visit(node.RequestArguments);
			return node.Update(kRequest, portName, tDot, queryName, requestArguments);
		}
		
		public virtual SyntaxNode VisitRequestArguments(RequestArgumentsSyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var expressionList = (ExpressionListSyntax)this.Visit(node.ExpressionList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(tOpenParen, expressionList, tCloseParen);
		}
		
		public virtual SyntaxNode VisitResponseStatement(ResponseStatementSyntax node)
		{
		    var responseStatementKind = (ResponseStatementKindSyntax)this.Visit(node.ResponseStatementKind);
		    var assertion = (AssertionSyntax)this.Visit(node.Assertion);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(responseStatementKind, assertion, tSemicolon);
		}
		
		public virtual SyntaxNode VisitCancelStatement(CancelStatementSyntax node)
		{
		    var cancelStatementKind = (CancelStatementKindSyntax)this.Visit(node.CancelStatementKind);
		    var portName = (IdentifierSyntax)this.Visit(node.PortName);
		    var assertion = (AssertionSyntax)this.Visit(node.Assertion);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(cancelStatementKind, portName, assertion, tSemicolon);
		}
		
		public virtual SyntaxNode VisitAssertion(AssertionSyntax node)
		{
		    var tColon = this.VisitToken(node.TColon);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
			return node.Update(tColon, expression, comment);
		}
		
		public virtual SyntaxNode VisitResponseStatementKind(ResponseStatementKindSyntax node)
		{
		    var responseStatementKind = this.VisitToken(node.ResponseStatementKind);
			return node.Update(responseStatementKind);
		}
		
		public virtual SyntaxNode VisitCancelStatementKind(CancelStatementKindSyntax node)
		{
		    var kCancel = this.VisitToken(node.KCancel);
			return node.Update(kCancel);
		}
		
		public virtual SyntaxNode VisitForkRequestStatement(ForkRequestStatementSyntax node)
		{
		    var kFork = this.VisitToken(node.KFork);
		    var forkRequestVariable = (ForkRequestVariableSyntax)this.Visit(node.ForkRequestVariable);
		    var acceptBranch = (AcceptBranchSyntax)this.Visit(node.AcceptBranch);
		    var refuseBranch = (RefuseBranchSyntax)this.Visit(node.RefuseBranch);
		    var cancelBranch = (CancelBranchSyntax)this.Visit(node.CancelBranch);
		    var kEndFork = this.VisitToken(node.KEndFork);
			return node.Update(kFork, forkRequestVariable, acceptBranch, refuseBranch, cancelBranch, kEndFork);
		}
		
		public virtual SyntaxNode VisitForkRequestVariable(ForkRequestVariableSyntax node)
		{
			var oldForkRequestIdentifier = node.ForkRequestIdentifier;
			if (oldForkRequestIdentifier != null)
			{
			    var newForkRequestIdentifier = (ForkRequestIdentifierSyntax)this.Visit(oldForkRequestIdentifier);
				return node.Update(newForkRequestIdentifier);
			}
			var oldRequestStatement = node.RequestStatement;
			if (oldRequestStatement != null)
			{
			    var newRequestStatement = (RequestStatementSyntax)this.Visit(oldRequestStatement);
				return node.Update(newRequestStatement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(identifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitAcceptBranch(AcceptBranchSyntax node)
		{
		    var kCase = this.VisitToken(node.KCase);
		    var kAccept = this.VisitToken(node.KAccept);
		    var condition = (ExpressionSyntax)this.Visit(node.Condition);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var statements = (StatementsSyntax)this.Visit(node.Statements);
			return node.Update(kCase, kAccept, condition, comment, tSemicolon, statements);
		}
		
		public virtual SyntaxNode VisitRefuseBranch(RefuseBranchSyntax node)
		{
		    var kCase = this.VisitToken(node.KCase);
		    var kRefuse = this.VisitToken(node.KRefuse);
		    var condition = (ExpressionSyntax)this.Visit(node.Condition);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var statements = (StatementsSyntax)this.Visit(node.Statements);
			return node.Update(kCase, kRefuse, condition, comment, tSemicolon, statements);
		}
		
		public virtual SyntaxNode VisitCancelBranch(CancelBranchSyntax node)
		{
		    var kCase = this.VisitToken(node.KCase);
		    var kCancel = this.VisitToken(node.KCancel);
		    var condition = (ExpressionSyntax)this.Visit(node.Condition);
		    var comment = (CommentSyntax)this.Visit(node.Comment);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var statements = (StatementsSyntax)this.Visit(node.Statements);
			return node.Update(kCase, kCancel, condition, comment, tSemicolon, statements);
		}
		
		public virtual SyntaxNode VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
		{
		    var variableDeclaration = (VariableDeclarationSyntax)this.Visit(node.VariableDeclaration);
			return node.Update(variableDeclaration);
		}
		
		public virtual SyntaxNode VisitVariableDeclaration(VariableDeclarationSyntax node)
		{
		    var kVar = this.VisitToken(node.KVar);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tColon = this.VisitToken(node.TColon);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tAssign = this.VisitToken(node.TAssign);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVar, name, tColon, typeReference, tAssign, expression, tSemicolon);
		}
		
		public virtual SyntaxNode VisitAssignmentStatement(AssignmentStatementSyntax node)
		{
		    var leftSide = (LeftSideSyntax)this.Visit(node.LeftSide);
		    var tAssign = this.VisitToken(node.TAssign);
		    var value = (ExpressionSyntax)this.Visit(node.Value);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(leftSide, tAssign, value, tSemicolon);
		}
		
		public virtual SyntaxNode VisitLeftSide(LeftSideSyntax node)
		{
			var oldIdentifier = node.Identifier;
			if (oldIdentifier != null)
			{
			    var newIdentifier = (IdentifierSyntax)this.Visit(oldIdentifier);
				return node.Update(newIdentifier);
			}
			var oldResultIdentifier = node.ResultIdentifier;
			if (oldResultIdentifier != null)
			{
			    var newResultIdentifier = (ResultIdentifierSyntax)this.Visit(oldResultIdentifier);
				return node.Update(newResultIdentifier);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitExpressionList(ExpressionListSyntax node)
		{
		    var expression = this.VisitList(node.Expression);
			return node.Update(expression);
		}
		
		public virtual SyntaxNode VisitExpression(ExpressionSyntax node)
		{
			var oldArithmeticExpression = node.ArithmeticExpression;
			if (oldArithmeticExpression != null)
			{
			    var newArithmeticExpression = (ArithmeticExpressionSyntax)this.Visit(oldArithmeticExpression);
				return node.Update(newArithmeticExpression);
			}
			var oldConditionalExpression = node.ConditionalExpression;
			if (oldConditionalExpression != null)
			{
			    var newConditionalExpression = (ConditionalExpressionSyntax)this.Visit(oldConditionalExpression);
				return node.Update(newConditionalExpression);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitMulDivExpression(MulDivExpressionSyntax node)
		{
		    var left = (ArithmeticExpressionSyntax)this.Visit(node.Left);
		    var opMulDiv = (OpMulDivSyntax)this.Visit(node.OpMulDiv);
		    var right = (ArithmeticExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, opMulDiv, right);
		}
		
		public virtual SyntaxNode VisitPlusMinusExpression(PlusMinusExpressionSyntax node)
		{
		    var left = (ArithmeticExpressionSyntax)this.Visit(node.Left);
		    var opAddSub = (OpAddSubSyntax)this.Visit(node.OpAddSub);
		    var right = (ArithmeticExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, opAddSub, right);
		}
		
		public virtual SyntaxNode VisitNegateExpression(NegateExpressionSyntax node)
		{
		    var opMinus = (OpMinusSyntax)this.Visit(node.OpMinus);
		    var arithmeticExpressionTerminator = (ArithmeticExpressionTerminatorSyntax)this.Visit(node.ArithmeticExpressionTerminator);
			return node.Update(opMinus, arithmeticExpressionTerminator);
		}
		
		public virtual SyntaxNode VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node)
		{
		    var arithmeticExpressionTerminator = (ArithmeticExpressionTerminatorSyntax)this.Visit(node.ArithmeticExpressionTerminator);
			return node.Update(arithmeticExpressionTerminator);
		}
		
		public virtual SyntaxNode VisitOpMulDiv(OpMulDivSyntax node)
		{
		    var opMulDiv = this.VisitToken(node.OpMulDiv);
			return node.Update(opMulDiv);
		}
		
		public virtual SyntaxNode VisitOpAddSub(OpAddSubSyntax node)
		{
		    var opAddSub = this.VisitToken(node.OpAddSub);
			return node.Update(opAddSub);
		}
		
		public virtual SyntaxNode VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var arithmeticExpression = (ArithmeticExpressionSyntax)this.Visit(node.ArithmeticExpression);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(tOpenParen, arithmeticExpression, tCloseParen);
		}
		
		public virtual SyntaxNode VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node)
		{
		    var terminalExpression = (TerminalExpressionSyntax)this.Visit(node.TerminalExpression);
			return node.Update(terminalExpression);
		}
		
		public virtual SyntaxNode VisitOpMinus(OpMinusSyntax node)
		{
		    var tMinus = this.VisitToken(node.TMinus);
			return node.Update(tMinus);
		}
		
		public virtual SyntaxNode VisitAndExpression(AndExpressionSyntax node)
		{
		    var left = (ConditionalExpressionSyntax)this.Visit(node.Left);
		    var andAlsoOp = (AndAlsoOpSyntax)this.Visit(node.AndAlsoOp);
		    var right = (ConditionalExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, andAlsoOp, right);
		}
		
		public virtual SyntaxNode VisitOrExpression(OrExpressionSyntax node)
		{
		    var left = (ConditionalExpressionSyntax)this.Visit(node.Left);
		    var orElseOp = (OrElseOpSyntax)this.Visit(node.OrElseOp);
		    var right = (ConditionalExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, orElseOp, right);
		}
		
		public virtual SyntaxNode VisitNotExpression(NotExpressionSyntax node)
		{
		    var opExcl = (OpExclSyntax)this.Visit(node.OpExcl);
		    var conditionalExpressionTerminator = (ConditionalExpressionTerminatorSyntax)this.Visit(node.ConditionalExpressionTerminator);
			return node.Update(opExcl, conditionalExpressionTerminator);
		}
		
		public virtual SyntaxNode VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node)
		{
		    var conditionalExpressionTerminator = (ConditionalExpressionTerminatorSyntax)this.Visit(node.ConditionalExpressionTerminator);
			return node.Update(conditionalExpressionTerminator);
		}
		
		public virtual SyntaxNode VisitAndAlsoOp(AndAlsoOpSyntax node)
		{
		    var tAndAlso = this.VisitToken(node.TAndAlso);
			return node.Update(tAndAlso);
		}
		
		public virtual SyntaxNode VisitOrElseOp(OrElseOpSyntax node)
		{
		    var tOrElse = this.VisitToken(node.TOrElse);
			return node.Update(tOrElse);
		}
		
		public virtual SyntaxNode VisitOpExcl(OpExclSyntax node)
		{
		    var tExclamation = this.VisitToken(node.TExclamation);
			return node.Update(tExclamation);
		}
		
		public virtual SyntaxNode VisitParenConditionalExpression(ParenConditionalExpressionSyntax node)
		{
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var conditionalExpression = (ConditionalExpressionSyntax)this.Visit(node.ConditionalExpression);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(tOpenParen, conditionalExpression, tCloseParen);
		}
		
		public virtual SyntaxNode VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node)
		{
		    var elementOfExpression = (ElementOfExpressionSyntax)this.Visit(node.ElementOfExpression);
			return node.Update(elementOfExpression);
		}
		
		public virtual SyntaxNode VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node)
		{
		    var comparisonExpression = (ComparisonExpressionSyntax)this.Visit(node.ComparisonExpression);
			return node.Update(comparisonExpression);
		}
		
		public virtual SyntaxNode VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node)
		{
		    var terminalExpression = (TerminalExpressionSyntax)this.Visit(node.TerminalExpression);
			return node.Update(terminalExpression);
		}
		
		public virtual SyntaxNode VisitComparisonExpression(ComparisonExpressionSyntax node)
		{
		    var left = (ArithmeticExpressionSyntax)this.Visit(node.Left);
		    var op = (ComparisonOperatorSyntax)this.Visit(node.Op);
		    var right = (ArithmeticExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, op, right);
		}
		
		public virtual SyntaxNode VisitComparisonOperator(ComparisonOperatorSyntax node)
		{
		    var comparisonOperator = this.VisitToken(node.ComparisonOperator);
			return node.Update(comparisonOperator);
		}
		
		public virtual SyntaxNode VisitElementOfExpression(ElementOfExpressionSyntax node)
		{
		    var terminalExpression = (TerminalExpressionSyntax)this.Visit(node.TerminalExpression);
		    var kIn = this.VisitToken(node.KIn);
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var elementOfValueList = (ElementOfValueListSyntax)this.Visit(node.ElementOfValueList);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(terminalExpression, kIn, tOpenBracket, elementOfValueList, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitElementOfValueList(ElementOfValueListSyntax node)
		{
		    var elementOfValue = this.VisitList(node.ElementOfValue);
			return node.Update(elementOfValue);
		}
		
		public virtual SyntaxNode VisitElementOfValue(ElementOfValueSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitTerminalExpression(TerminalExpressionSyntax node)
		{
			var oldVariableReference = node.VariableReference;
			if (oldVariableReference != null)
			{
			    var newVariableReference = (VariableReferenceSyntax)this.Visit(oldVariableReference);
				return node.Update(newVariableReference);
			}
			var oldFunctionCallExpression = node.FunctionCallExpression;
			if (oldFunctionCallExpression != null)
			{
			    var newFunctionCallExpression = (FunctionCallExpressionSyntax)this.Visit(oldFunctionCallExpression);
				return node.Update(newFunctionCallExpression);
			}
			var oldLiteral = node.Literal;
			if (oldLiteral != null)
			{
			    var newLiteral = (LiteralSyntax)this.Visit(oldLiteral);
				return node.Update(newLiteral);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tOpenParen = this.VisitToken(node.TOpenParen);
		    var expressionList = (ExpressionListSyntax)this.Visit(node.ExpressionList);
		    var tCloseParen = this.VisitToken(node.TCloseParen);
			return node.Update(identifier, tOpenParen, expressionList, tCloseParen);
		}
		
		public virtual SyntaxNode VisitVariableReference(VariableReferenceSyntax node)
		{
		    var variableReferenceIdentifier = this.VisitList(node.VariableReferenceIdentifier);
			return node.Update(variableReferenceIdentifier);
		}
		
		public virtual SyntaxNode VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitComment(CommentSyntax node)
		{
		    var lString = this.VisitToken(node.LString);
			return node.Update(lString);
		}
		
		public virtual SyntaxNode VisitLiteral(LiteralSyntax node)
		{
		    var literal = this.VisitToken(node.Literal);
			return node.Update(literal);
		}
		
		public virtual SyntaxNode VisitTypeReference(TypeReferenceSyntax node)
		{
			var oldBuiltInType = node.BuiltInType;
			if (oldBuiltInType != null)
			{
			    var newBuiltInType = (BuiltInTypeSyntax)this.Visit(oldBuiltInType);
				return node.Update(newBuiltInType);
			}
			var oldIdentifier = node.Identifier;
			if (oldIdentifier != null)
			{
			    var newIdentifier = (IdentifierSyntax)this.Visit(oldIdentifier);
				return node.Update(newIdentifier);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitBuiltInType(BuiltInTypeSyntax node)
		{
		    var builtInType = this.VisitToken(node.BuiltInType);
			return node.Update(builtInType);
		}
		
		public virtual SyntaxNode VisitQualifierList(QualifierListSyntax node)
		{
		    var qualifier = this.VisitList(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitQualifier(QualifierSyntax node)
		{
		    var identifier = this.VisitList(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitName(NameSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitIdentifierList(IdentifierListSyntax node)
		{
		    var identifier = this.VisitList(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitIdentifier(IdentifierSyntax node)
		{
		    var lIdentifier = this.VisitToken(node.LIdentifier);
			return node.Update(lIdentifier);
		}
		
		public virtual SyntaxNode VisitResultIdentifier(ResultIdentifierSyntax node)
		{
		    var kResult = this.VisitToken(node.KResult);
			return node.Update(kResult);
		}
	}

	public class PilSyntaxFactory : SyntaxFactory
	{
		internal PilSyntaxFactory(PilInternalSyntaxFactory internalSyntaxFactory) 
			: base(internalSyntaxFactory)
		{
		}
		public new PilLanguage Language => PilLanguage.Instance;
		protected override Language LanguageCore => this.Language;
	    public override LanguageParseOptions DefaultParseOptions => PilParseOptions.Default;
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public PilSyntaxTree SyntaxTree(SyntaxNode root, PilParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return PilSyntaxTree.Create((PilSyntaxNode)root, (PilParseOptions)options, path, null, encoding);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public PilSyntaxTree ParseSyntaxTree(
			string text,
			PilParseOptions options = null,
			string path = "",
			Encoding encoding = null,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (PilSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public PilSyntaxTree ParseSyntaxTree(
			SourceText text,
			PilParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (PilSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
		protected override LanguageSyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return PilSyntaxTree.ParseText(text, (PilParseOptions)options, path, cancellationToken);
		}
	
		public override LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return PilSyntaxTree.Create((PilSyntaxNode)root, (PilParseOptions)options, path, null, encoding);
		}
	
	
	    public SyntaxToken LIdentifier(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LIdentifier(text));
	    }
	
	    public SyntaxToken LIdentifier(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LIdentifier(text, value));
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LInteger(text));
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LInteger(text, value));
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LDecimal(text));
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LDecimal(text, value));
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LScientific(text));
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LScientific(text, value));
	    }
	
	    public SyntaxToken LString(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LString(text));
	    }
	
	    public SyntaxToken LString(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LString(text, value));
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text));
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value));
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text));
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value));
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LCrLf(text));
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value));
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LLineEnd(text));
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value));
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text));
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value));
	    }
	
	    public SyntaxToken LMultiLineComment(string text)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LMultiLineComment(text));
	    }
	
	    public SyntaxToken LMultiLineComment(string text, object value)
	    {
	        return new SyntaxToken(PilLanguage.Instance.InternalSyntaxFactory.LMultiLineComment(text, value));
	    }
		
		public MainSyntax Main(SyntaxList<DeclarationSyntax> declaration, SyntaxToken eOF)
		{
		    if (eOF == null) throw new ArgumentNullException(nameof(eOF));
		    if (eOF.GetKind() != PilSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
		    return (MainSyntax)PilLanguage.Instance.InternalSyntaxFactory.Main(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<DeclarationGreen>(declaration.Node), (InternalSyntaxToken)eOF.Node).CreateRed();
		}
		
		public MainSyntax Main(SyntaxToken eOF)
		{
			return this.Main(default, eOF);
		}
		
		public DeclarationSyntax Declaration(TypeDefDeclarationSyntax typeDefDeclaration)
		{
		    if (typeDefDeclaration == null) throw new ArgumentNullException(nameof(typeDefDeclaration));
		    return (DeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.TypeDefDeclarationGreen)typeDefDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(ExternalParameterDeclarationSyntax externalParameterDeclaration)
		{
		    if (externalParameterDeclaration == null) throw new ArgumentNullException(nameof(externalParameterDeclaration));
		    return (DeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.ExternalParameterDeclarationGreen)externalParameterDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(EnumDeclarationSyntax enumDeclaration)
		{
		    if (enumDeclaration == null) throw new ArgumentNullException(nameof(enumDeclaration));
		    return (DeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.EnumDeclarationGreen)enumDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(ObjectDeclarationSyntax objectDeclaration)
		{
		    if (objectDeclaration == null) throw new ArgumentNullException(nameof(objectDeclaration));
		    return (DeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.ObjectDeclarationGreen)objectDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(FunctionDeclarationSyntax functionDeclaration)
		{
		    if (functionDeclaration == null) throw new ArgumentNullException(nameof(functionDeclaration));
		    return (DeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.FunctionDeclarationGreen)functionDeclaration.Green).CreateRed();
		}
		
		public DeclarationSyntax Declaration(QueryDeclarationSyntax queryDeclaration)
		{
		    if (queryDeclaration == null) throw new ArgumentNullException(nameof(queryDeclaration));
		    return (DeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.Declaration((Syntax.InternalSyntax.QueryDeclarationGreen)queryDeclaration.Green).CreateRed();
		}
		
		public TypeDefDeclarationSyntax TypeDefDeclaration(SyntaxToken kTypeDef, NameSyntax name, SyntaxToken tColon, TypeReferenceSyntax typeReference, SyntaxToken tSemicolon)
		{
		    if (kTypeDef == null) throw new ArgumentNullException(nameof(kTypeDef));
		    if (kTypeDef.GetKind() != PilSyntaxKind.KTypeDef) throw new ArgumentException(nameof(kTypeDef));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (TypeDefDeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.TypeDefDeclaration((InternalSyntaxToken)kTypeDef.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public TypeDefDeclarationSyntax TypeDefDeclaration(NameSyntax name, TypeReferenceSyntax typeReference)
		{
			return this.TypeDefDeclaration(this.Token(PilSyntaxKind.KTypeDef), name, this.Token(PilSyntaxKind.TColon), typeReference, this.Token(PilSyntaxKind.TSemicolon));
		}
		
		public ExternalParameterDeclarationSyntax ExternalParameterDeclaration(SyntaxToken kParam, NameSyntax name, SyntaxToken tColon, TypeReferenceSyntax typeReference, SyntaxToken tAssign, ExpressionSyntax expression, SyntaxToken tSemicolon)
		{
		    if (kParam == null) throw new ArgumentNullException(nameof(kParam));
		    if (kParam.GetKind() != PilSyntaxKind.KParam) throw new ArgumentException(nameof(kParam));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tAssign != null && tAssign.GetKind() != PilSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ExternalParameterDeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.ExternalParameterDeclaration((InternalSyntaxToken)kParam.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tAssign.Node, expression == null ? null : (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ExternalParameterDeclarationSyntax ExternalParameterDeclaration(NameSyntax name, TypeReferenceSyntax typeReference)
		{
			return this.ExternalParameterDeclaration(this.Token(PilSyntaxKind.KParam), name, this.Token(PilSyntaxKind.TColon), typeReference, default, default, this.Token(PilSyntaxKind.TSemicolon));
		}
		
		public EnumDeclarationSyntax EnumDeclaration(SyntaxToken kEnum, NameSyntax name, SyntaxToken tOpenBracket, EnumLiteralsSyntax enumLiterals, SyntaxToken tCloseBracket, SyntaxToken tSemicolon)
		{
		    if (kEnum == null) throw new ArgumentNullException(nameof(kEnum));
		    if (kEnum.GetKind() != PilSyntaxKind.KEnum) throw new ArgumentException(nameof(kEnum));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != PilSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (enumLiterals == null) throw new ArgumentNullException(nameof(enumLiterals));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != PilSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (EnumDeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.EnumDeclaration((InternalSyntaxToken)kEnum.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenBracket.Node, (Syntax.InternalSyntax.EnumLiteralsGreen)enumLiterals.Green, (InternalSyntaxToken)tCloseBracket.Node, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public EnumDeclarationSyntax EnumDeclaration(NameSyntax name, EnumLiteralsSyntax enumLiterals)
		{
			return this.EnumDeclaration(this.Token(PilSyntaxKind.KEnum), name, this.Token(PilSyntaxKind.TOpenBracket), enumLiterals, this.Token(PilSyntaxKind.TCloseBracket), this.Token(PilSyntaxKind.TSemicolon));
		}
		
		public EnumLiteralsSyntax EnumLiterals(SeparatedSyntaxList<EnumLiteralSyntax> enumLiteral)
		{
		    if (enumLiteral == null) throw new ArgumentNullException(nameof(enumLiteral));
		    return (EnumLiteralsSyntax)PilLanguage.Instance.InternalSyntaxFactory.EnumLiterals(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<EnumLiteralGreen>(enumLiteral.Node)).CreateRed();
		}
		
		public EnumLiteralSyntax EnumLiteral(NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (EnumLiteralSyntax)PilLanguage.Instance.InternalSyntaxFactory.EnumLiteral((Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public ObjectDeclarationSyntax ObjectDeclaration(SyntaxToken kObject, ObjectHeaderSyntax objectHeader, SyntaxToken tSemicolon, ObjectExternalParametersSyntax objectExternalParameters, ObjectFieldsSyntax objectFields, ObjectFunctionsSyntax objectFunctions, SyntaxToken kEndObject)
		{
		    if (kObject == null) throw new ArgumentNullException(nameof(kObject));
		    if (kObject.GetKind() != PilSyntaxKind.KObject) throw new ArgumentException(nameof(kObject));
		    if (objectHeader == null) throw new ArgumentNullException(nameof(objectHeader));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    if (objectExternalParameters == null) throw new ArgumentNullException(nameof(objectExternalParameters));
		    if (objectFields == null) throw new ArgumentNullException(nameof(objectFields));
		    if (objectFunctions == null) throw new ArgumentNullException(nameof(objectFunctions));
		    if (kEndObject == null) throw new ArgumentNullException(nameof(kEndObject));
		    if (kEndObject.GetKind() != PilSyntaxKind.KEndObject) throw new ArgumentException(nameof(kEndObject));
		    return (ObjectDeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.ObjectDeclaration((InternalSyntaxToken)kObject.Node, (Syntax.InternalSyntax.ObjectHeaderGreen)objectHeader.Green, (InternalSyntaxToken)tSemicolon.Node, (Syntax.InternalSyntax.ObjectExternalParametersGreen)objectExternalParameters.Green, (Syntax.InternalSyntax.ObjectFieldsGreen)objectFields.Green, (Syntax.InternalSyntax.ObjectFunctionsGreen)objectFunctions.Green, (InternalSyntaxToken)kEndObject.Node).CreateRed();
		}
		
		public ObjectDeclarationSyntax ObjectDeclaration(ObjectHeaderSyntax objectHeader, ObjectExternalParametersSyntax objectExternalParameters, ObjectFieldsSyntax objectFields, ObjectFunctionsSyntax objectFunctions)
		{
			return this.ObjectDeclaration(this.Token(PilSyntaxKind.KObject), objectHeader, this.Token(PilSyntaxKind.TSemicolon), objectExternalParameters, objectFields, objectFunctions, this.Token(PilSyntaxKind.KEndObject));
		}
		
		public ObjectHeaderSyntax ObjectHeader(NameSyntax name, SyntaxToken tOpenParen, PortsSyntax ports, SyntaxToken tCloseParen)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (ObjectHeaderSyntax)PilLanguage.Instance.InternalSyntaxFactory.ObjectHeader((Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Node, ports == null ? null : (Syntax.InternalSyntax.PortsGreen)ports.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public ObjectHeaderSyntax ObjectHeader(NameSyntax name)
		{
			return this.ObjectHeader(name, this.Token(PilSyntaxKind.TOpenParen), default, this.Token(PilSyntaxKind.TCloseParen));
		}
		
		public PortsSyntax Ports(SeparatedSyntaxList<PortSyntax> port)
		{
		    if (port == null) throw new ArgumentNullException(nameof(port));
		    return (PortsSyntax)PilLanguage.Instance.InternalSyntaxFactory.Ports(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<PortGreen>(port.Node)).CreateRed();
		}
		
		public PortSyntax Port(NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (PortSyntax)PilLanguage.Instance.InternalSyntaxFactory.Port((Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public ObjectExternalParametersSyntax ObjectExternalParameters(SyntaxList<ExternalParameterDeclarationSyntax> externalParameterDeclaration)
		{
		    return (ObjectExternalParametersSyntax)PilLanguage.Instance.InternalSyntaxFactory.ObjectExternalParameters(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ExternalParameterDeclarationGreen>(externalParameterDeclaration.Node)).CreateRed();
		}
		
		public ObjectExternalParametersSyntax ObjectExternalParameters()
		{
			return this.ObjectExternalParameters(default);
		}
		
		public ObjectFieldsSyntax ObjectFields(SyntaxList<VariableDeclarationSyntax> variableDeclaration)
		{
		    return (ObjectFieldsSyntax)PilLanguage.Instance.InternalSyntaxFactory.ObjectFields(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<VariableDeclarationGreen>(variableDeclaration.Node)).CreateRed();
		}
		
		public ObjectFieldsSyntax ObjectFields()
		{
			return this.ObjectFields(default);
		}
		
		public ObjectFunctionsSyntax ObjectFunctions(SyntaxList<FunctionDeclarationSyntax> functionDeclaration)
		{
		    return (ObjectFunctionsSyntax)PilLanguage.Instance.InternalSyntaxFactory.ObjectFunctions(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<FunctionDeclarationGreen>(functionDeclaration.Node)).CreateRed();
		}
		
		public ObjectFunctionsSyntax ObjectFunctions()
		{
			return this.ObjectFunctions(default);
		}
		
		public FunctionDeclarationSyntax FunctionDeclaration(SyntaxToken kFunction, FunctionHeaderSyntax functionHeader, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements, SyntaxToken kEndFunction)
		{
		    if (kFunction == null) throw new ArgumentNullException(nameof(kFunction));
		    if (kFunction.GetKind() != PilSyntaxKind.KFunction) throw new ArgumentException(nameof(kFunction));
		    if (functionHeader == null) throw new ArgumentNullException(nameof(functionHeader));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    if (kEndFunction == null) throw new ArgumentNullException(nameof(kEndFunction));
		    if (kEndFunction.GetKind() != PilSyntaxKind.KEndFunction) throw new ArgumentException(nameof(kEndFunction));
		    return (FunctionDeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.FunctionDeclaration((InternalSyntaxToken)kFunction.Node, (Syntax.InternalSyntax.FunctionHeaderGreen)functionHeader.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)tSemicolon.Node, statements == null ? null : (Syntax.InternalSyntax.StatementsGreen)statements.Green, (InternalSyntaxToken)kEndFunction.Node).CreateRed();
		}
		
		public FunctionDeclarationSyntax FunctionDeclaration(FunctionHeaderSyntax functionHeader)
		{
			return this.FunctionDeclaration(this.Token(PilSyntaxKind.KFunction), functionHeader, default, this.Token(PilSyntaxKind.TSemicolon), default, this.Token(PilSyntaxKind.KEndFunction));
		}
		
		public FunctionHeaderSyntax FunctionHeader(NameSyntax name, SyntaxToken tOpenParen, FunctionParamsSyntax functionParams, SyntaxToken tCloseParen, SyntaxToken tColon, TypeReferenceSyntax typeReference)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (FunctionHeaderSyntax)PilLanguage.Instance.InternalSyntaxFactory.FunctionHeader((Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Node, functionParams == null ? null : (Syntax.InternalSyntax.FunctionParamsGreen)functionParams.Green, (InternalSyntaxToken)tCloseParen.Node, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public FunctionHeaderSyntax FunctionHeader(NameSyntax name, TypeReferenceSyntax typeReference)
		{
			return this.FunctionHeader(name, this.Token(PilSyntaxKind.TOpenParen), default, this.Token(PilSyntaxKind.TCloseParen), this.Token(PilSyntaxKind.TColon), typeReference);
		}
		
		public FunctionParamsSyntax FunctionParams(SeparatedSyntaxList<ParamSyntax> param)
		{
		    if (param == null) throw new ArgumentNullException(nameof(param));
		    return (FunctionParamsSyntax)PilLanguage.Instance.InternalSyntaxFactory.FunctionParams(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParamGreen>(param.Node)).CreateRed();
		}
		
		public ParamSyntax Param(NameSyntax name, SyntaxToken tColon, TypeReferenceSyntax typeReference)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (ParamSyntax)PilLanguage.Instance.InternalSyntaxFactory.Param((Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public ParamSyntax Param(NameSyntax name, TypeReferenceSyntax typeReference)
		{
			return this.Param(name, this.Token(PilSyntaxKind.TColon), typeReference);
		}
		
		public QueryDeclarationSyntax QueryDeclaration(SyntaxToken kQuery, QueryHeaderSyntax queryHeader, CommentSyntax comment, SyntaxToken startQuerySemicolon, SyntaxList<QueryExternalParametersSyntax> queryExternalParameters, SyntaxList<QueryFieldSyntax> queryField, SyntaxList<FunctionDeclarationSyntax> functionDeclaration, SyntaxList<QueryObjectSyntax> queryObject, SyntaxToken kEndQuery, IdentifierSyntax endName, SyntaxToken endQuerySemicolon)
		{
		    if (kQuery == null) throw new ArgumentNullException(nameof(kQuery));
		    if (kQuery.GetKind() != PilSyntaxKind.KQuery) throw new ArgumentException(nameof(kQuery));
		    if (queryHeader == null) throw new ArgumentNullException(nameof(queryHeader));
		    if (startQuerySemicolon == null) throw new ArgumentNullException(nameof(startQuerySemicolon));
		    if (startQuerySemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(startQuerySemicolon));
		    if (kEndQuery == null) throw new ArgumentNullException(nameof(kEndQuery));
		    if (kEndQuery.GetKind() != PilSyntaxKind.KEndQuery) throw new ArgumentException(nameof(kEndQuery));
		    if (endQuerySemicolon == null) throw new ArgumentNullException(nameof(endQuerySemicolon));
		    if (endQuerySemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(endQuerySemicolon));
		    return (QueryDeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryDeclaration((InternalSyntaxToken)kQuery.Node, (Syntax.InternalSyntax.QueryHeaderGreen)queryHeader.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)startQuerySemicolon.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<QueryExternalParametersGreen>(queryExternalParameters.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<QueryFieldGreen>(queryField.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<FunctionDeclarationGreen>(functionDeclaration.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<QueryObjectGreen>(queryObject.Node), (InternalSyntaxToken)kEndQuery.Node, endName == null ? null : (Syntax.InternalSyntax.IdentifierGreen)endName.Green, (InternalSyntaxToken)endQuerySemicolon.Node).CreateRed();
		}
		
		public QueryDeclarationSyntax QueryDeclaration(QueryHeaderSyntax queryHeader, SyntaxToken startQuerySemicolon, SyntaxToken endQuerySemicolon)
		{
			return this.QueryDeclaration(this.Token(PilSyntaxKind.KQuery), queryHeader, default, startQuerySemicolon, default, default, default, default, this.Token(PilSyntaxKind.KEndQuery), default, endQuerySemicolon);
		}
		
		public QueryHeaderSyntax QueryHeader(NameSyntax name, SyntaxToken tOpenParen, QueryRequestParamsSyntax queryRequestParams, SyntaxToken tCloseParen)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (QueryHeaderSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryHeader((Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tOpenParen.Node, queryRequestParams == null ? null : (Syntax.InternalSyntax.QueryRequestParamsGreen)queryRequestParams.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public QueryHeaderSyntax QueryHeader(NameSyntax name)
		{
			return this.QueryHeader(name, this.Token(PilSyntaxKind.TOpenParen), default, this.Token(PilSyntaxKind.TCloseParen));
		}
		
		public QueryRequestParamsSyntax QueryRequestParams(SyntaxToken kRequest, SeparatedSyntaxList<ParamSyntax> param, SyntaxToken tSemicolon)
		{
		    if (kRequest != null && kRequest.GetKind() != PilSyntaxKind.KRequest) throw new ArgumentException(nameof(kRequest));
		    if (param == null) throw new ArgumentNullException(nameof(param));
		    if (tSemicolon != null && tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (QueryRequestParamsSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryRequestParams((InternalSyntaxToken)kRequest.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParamGreen>(param.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public QueryRequestParamsSyntax QueryRequestParams(SeparatedSyntaxList<ParamSyntax> param)
		{
			return this.QueryRequestParams(default, param, default);
		}
		
		public QueryAcceptParamsSyntax QueryAcceptParams(SyntaxToken kAccept, SeparatedSyntaxList<ParamSyntax> param, SyntaxToken tSemicolon)
		{
		    if (kAccept == null) throw new ArgumentNullException(nameof(kAccept));
		    if (kAccept.GetKind() != PilSyntaxKind.KAccept) throw new ArgumentException(nameof(kAccept));
		    if (param == null) throw new ArgumentNullException(nameof(param));
		    if (tSemicolon != null && tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (QueryAcceptParamsSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryAcceptParams((InternalSyntaxToken)kAccept.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParamGreen>(param.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public QueryAcceptParamsSyntax QueryAcceptParams(SeparatedSyntaxList<ParamSyntax> param)
		{
			return this.QueryAcceptParams(this.Token(PilSyntaxKind.KAccept), param, default);
		}
		
		public QueryRefuseParamsSyntax QueryRefuseParams(SyntaxToken kRefuse, SeparatedSyntaxList<ParamSyntax> param, SyntaxToken tSemicolon)
		{
		    if (kRefuse == null) throw new ArgumentNullException(nameof(kRefuse));
		    if (kRefuse.GetKind() != PilSyntaxKind.KRefuse) throw new ArgumentException(nameof(kRefuse));
		    if (param == null) throw new ArgumentNullException(nameof(param));
		    if (tSemicolon != null && tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (QueryRefuseParamsSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryRefuseParams((InternalSyntaxToken)kRefuse.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParamGreen>(param.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public QueryRefuseParamsSyntax QueryRefuseParams(SeparatedSyntaxList<ParamSyntax> param)
		{
			return this.QueryRefuseParams(this.Token(PilSyntaxKind.KRefuse), param, default);
		}
		
		public QueryCancelParamsSyntax QueryCancelParams(SyntaxToken kCancel, SeparatedSyntaxList<ParamSyntax> param, SyntaxToken tSemicolon)
		{
		    if (kCancel == null) throw new ArgumentNullException(nameof(kCancel));
		    if (kCancel.GetKind() != PilSyntaxKind.KCancel) throw new ArgumentException(nameof(kCancel));
		    if (param == null) throw new ArgumentNullException(nameof(param));
		    if (tSemicolon != null && tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (QueryCancelParamsSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryCancelParams((InternalSyntaxToken)kCancel.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParamGreen>(param.Node), (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public QueryCancelParamsSyntax QueryCancelParams(SeparatedSyntaxList<ParamSyntax> param)
		{
			return this.QueryCancelParams(this.Token(PilSyntaxKind.KCancel), param, default);
		}
		
		public QueryExternalParametersSyntax QueryExternalParameters(ExternalParameterDeclarationSyntax externalParameterDeclaration)
		{
		    if (externalParameterDeclaration == null) throw new ArgumentNullException(nameof(externalParameterDeclaration));
		    return (QueryExternalParametersSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryExternalParameters((Syntax.InternalSyntax.ExternalParameterDeclarationGreen)externalParameterDeclaration.Green).CreateRed();
		}
		
		public QueryFieldSyntax QueryField(VariableDeclarationSyntax variableDeclaration)
		{
		    if (variableDeclaration == null) throw new ArgumentNullException(nameof(variableDeclaration));
		    return (QueryFieldSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryField((Syntax.InternalSyntax.VariableDeclarationGreen)variableDeclaration.Green).CreateRed();
		}
		
		public QueryFunctionSyntax QueryFunction(FunctionDeclarationSyntax functionDeclaration)
		{
		    if (functionDeclaration == null) throw new ArgumentNullException(nameof(functionDeclaration));
		    return (QueryFunctionSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryFunction((Syntax.InternalSyntax.FunctionDeclarationGreen)functionDeclaration.Green).CreateRed();
		}
		
		public QueryObjectSyntax QueryObject(SyntaxToken kObject, NameSyntax name, CommentSyntax comment, SyntaxToken startObjectSemicolon, SyntaxList<QueryObjectFieldSyntax> queryObjectField, SyntaxList<QueryObjectFunctionSyntax> queryObjectFunction, SyntaxList<QueryObjectEventSyntax> queryObjectEvent, SyntaxToken kEndObject, IdentifierSyntax endName, SyntaxToken endObjectSemicolon)
		{
		    if (kObject == null) throw new ArgumentNullException(nameof(kObject));
		    if (kObject.GetKind() != PilSyntaxKind.KObject) throw new ArgumentException(nameof(kObject));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (startObjectSemicolon == null) throw new ArgumentNullException(nameof(startObjectSemicolon));
		    if (startObjectSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(startObjectSemicolon));
		    if (kEndObject == null) throw new ArgumentNullException(nameof(kEndObject));
		    if (kEndObject.GetKind() != PilSyntaxKind.KEndObject) throw new ArgumentException(nameof(kEndObject));
		    if (endObjectSemicolon == null) throw new ArgumentNullException(nameof(endObjectSemicolon));
		    if (endObjectSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(endObjectSemicolon));
		    return (QueryObjectSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryObject((InternalSyntaxToken)kObject.Node, (Syntax.InternalSyntax.NameGreen)name.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)startObjectSemicolon.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<QueryObjectFieldGreen>(queryObjectField.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<QueryObjectFunctionGreen>(queryObjectFunction.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<QueryObjectEventGreen>(queryObjectEvent.Node), (InternalSyntaxToken)kEndObject.Node, endName == null ? null : (Syntax.InternalSyntax.IdentifierGreen)endName.Green, (InternalSyntaxToken)endObjectSemicolon.Node).CreateRed();
		}
		
		public QueryObjectSyntax QueryObject(NameSyntax name, SyntaxToken startObjectSemicolon, SyntaxToken endObjectSemicolon)
		{
			return this.QueryObject(this.Token(PilSyntaxKind.KObject), name, default, startObjectSemicolon, default, default, default, this.Token(PilSyntaxKind.KEndObject), default, endObjectSemicolon);
		}
		
		public QueryObjectFieldSyntax QueryObjectField(VariableDeclarationSyntax variableDeclaration)
		{
		    if (variableDeclaration == null) throw new ArgumentNullException(nameof(variableDeclaration));
		    return (QueryObjectFieldSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryObjectField((Syntax.InternalSyntax.VariableDeclarationGreen)variableDeclaration.Green).CreateRed();
		}
		
		public QueryObjectFunctionSyntax QueryObjectFunction(FunctionDeclarationSyntax functionDeclaration)
		{
		    if (functionDeclaration == null) throw new ArgumentNullException(nameof(functionDeclaration));
		    return (QueryObjectFunctionSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryObjectFunction((Syntax.InternalSyntax.FunctionDeclarationGreen)functionDeclaration.Green).CreateRed();
		}
		
		public QueryObjectEventSyntax QueryObjectEvent(InputSyntax input)
		{
		    if (input == null) throw new ArgumentNullException(nameof(input));
		    return (QueryObjectEventSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryObjectEvent((Syntax.InternalSyntax.InputGreen)input.Green).CreateRed();
		}
		
		public QueryObjectEventSyntax QueryObjectEvent(TriggerSyntax trigger)
		{
		    if (trigger == null) throw new ArgumentNullException(nameof(trigger));
		    return (QueryObjectEventSyntax)PilLanguage.Instance.InternalSyntaxFactory.QueryObjectEvent((Syntax.InternalSyntax.TriggerGreen)trigger.Green).CreateRed();
		}
		
		public InputSyntax Input(SyntaxToken kInput, InputPortListSyntax inputPortList, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
		{
		    if (kInput == null) throw new ArgumentNullException(nameof(kInput));
		    if (kInput.GetKind() != PilSyntaxKind.KInput) throw new ArgumentException(nameof(kInput));
		    if (inputPortList == null) throw new ArgumentNullException(nameof(inputPortList));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (InputSyntax)PilLanguage.Instance.InternalSyntaxFactory.Input((InternalSyntaxToken)kInput.Node, (Syntax.InternalSyntax.InputPortListGreen)inputPortList.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)tSemicolon.Node, statements == null ? null : (Syntax.InternalSyntax.StatementsGreen)statements.Green).CreateRed();
		}
		
		public InputSyntax Input(InputPortListSyntax inputPortList)
		{
			return this.Input(this.Token(PilSyntaxKind.KInput), inputPortList, default, this.Token(PilSyntaxKind.TSemicolon), default);
		}
		
		public InputPortListSyntax InputPortList(SeparatedSyntaxList<InputPortSyntax> inputPort)
		{
		    if (inputPort == null) throw new ArgumentNullException(nameof(inputPort));
		    return (InputPortListSyntax)PilLanguage.Instance.InternalSyntaxFactory.InputPortList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<InputPortGreen>(inputPort.Node)).CreateRed();
		}
		
		public InputPortSyntax InputPort(IdentifierSyntax portName, SyntaxToken tDot, IdentifierSyntax queryName)
		{
		    if (portName == null) throw new ArgumentNullException(nameof(portName));
		    if (tDot != null && tDot.GetKind() != PilSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
		    return (InputPortSyntax)PilLanguage.Instance.InternalSyntaxFactory.InputPort((Syntax.InternalSyntax.IdentifierGreen)portName.Green, (InternalSyntaxToken)tDot.Node, queryName == null ? null : (Syntax.InternalSyntax.IdentifierGreen)queryName.Green).CreateRed();
		}
		
		public InputPortSyntax InputPort(IdentifierSyntax portName)
		{
			return this.InputPort(portName, default, default);
		}
		
		public TriggerSyntax Trigger(SyntaxToken kTrigger, TriggerVarListSyntax triggerVarList, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
		{
		    if (kTrigger == null) throw new ArgumentNullException(nameof(kTrigger));
		    if (kTrigger.GetKind() != PilSyntaxKind.KTrigger) throw new ArgumentException(nameof(kTrigger));
		    if (triggerVarList == null) throw new ArgumentNullException(nameof(triggerVarList));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (TriggerSyntax)PilLanguage.Instance.InternalSyntaxFactory.Trigger((InternalSyntaxToken)kTrigger.Node, (Syntax.InternalSyntax.TriggerVarListGreen)triggerVarList.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)tSemicolon.Node, statements == null ? null : (Syntax.InternalSyntax.StatementsGreen)statements.Green).CreateRed();
		}
		
		public TriggerSyntax Trigger(TriggerVarListSyntax triggerVarList)
		{
			return this.Trigger(this.Token(PilSyntaxKind.KTrigger), triggerVarList, default, this.Token(PilSyntaxKind.TSemicolon), default);
		}
		
		public TriggerVarListSyntax TriggerVarList(SeparatedSyntaxList<TriggerVarSyntax> triggerVar)
		{
		    if (triggerVar == null) throw new ArgumentNullException(nameof(triggerVar));
		    return (TriggerVarListSyntax)PilLanguage.Instance.InternalSyntaxFactory.TriggerVarList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<TriggerVarGreen>(triggerVar.Node)).CreateRed();
		}
		
		public TriggerVarSyntax TriggerVar(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (TriggerVarSyntax)PilLanguage.Instance.InternalSyntaxFactory.TriggerVar((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public StatementsSyntax Statements(SyntaxList<StatementSyntax> statement)
		{
		    return (StatementsSyntax)PilLanguage.Instance.InternalSyntaxFactory.Statements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<StatementGreen>(statement.Node)).CreateRed();
		}
		
		public StatementsSyntax Statements()
		{
			return this.Statements(default);
		}
		
		public StatementSyntax Statement(VariableDeclarationStatementSyntax variableDeclarationStatement)
		{
		    if (variableDeclarationStatement == null) throw new ArgumentNullException(nameof(variableDeclarationStatement));
		    return (StatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.VariableDeclarationStatementGreen)variableDeclarationStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(RequestStatementSyntax requestStatement)
		{
		    if (requestStatement == null) throw new ArgumentNullException(nameof(requestStatement));
		    return (StatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.RequestStatementGreen)requestStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(ForkStatementSyntax forkStatement)
		{
		    if (forkStatement == null) throw new ArgumentNullException(nameof(forkStatement));
		    return (StatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.ForkStatementGreen)forkStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(ForkRequestStatementSyntax forkRequestStatement)
		{
		    if (forkRequestStatement == null) throw new ArgumentNullException(nameof(forkRequestStatement));
		    return (StatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.ForkRequestStatementGreen)forkRequestStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(IfStatementSyntax ifStatement)
		{
		    if (ifStatement == null) throw new ArgumentNullException(nameof(ifStatement));
		    return (StatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.IfStatementGreen)ifStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(ResponseStatementSyntax responseStatement)
		{
		    if (responseStatement == null) throw new ArgumentNullException(nameof(responseStatement));
		    return (StatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.ResponseStatementGreen)responseStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(CancelStatementSyntax cancelStatement)
		{
		    if (cancelStatement == null) throw new ArgumentNullException(nameof(cancelStatement));
		    return (StatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.CancelStatementGreen)cancelStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(AssignmentStatementSyntax assignmentStatement)
		{
		    if (assignmentStatement == null) throw new ArgumentNullException(nameof(assignmentStatement));
		    return (StatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.AssignmentStatementGreen)assignmentStatement.Green).CreateRed();
		}
		
		public ForkStatementSyntax ForkStatement(SyntaxToken kFork, ExpressionSyntax expression, SyntaxList<CaseBranchSyntax> caseBranch, ElseBranchSyntax elseBranch, SyntaxToken kEndFork)
		{
		    if (kFork == null) throw new ArgumentNullException(nameof(kFork));
		    if (kFork.GetKind() != PilSyntaxKind.KFork) throw new ArgumentException(nameof(kFork));
		    if (kEndFork == null) throw new ArgumentNullException(nameof(kEndFork));
		    if (kEndFork.GetKind() != PilSyntaxKind.KEndFork) throw new ArgumentException(nameof(kEndFork));
		    return (ForkStatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.ForkStatement((InternalSyntaxToken)kFork.Node, expression == null ? null : (Syntax.InternalSyntax.ExpressionGreen)expression.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<CaseBranchGreen>(caseBranch.Node), elseBranch == null ? null : (Syntax.InternalSyntax.ElseBranchGreen)elseBranch.Green, (InternalSyntaxToken)kEndFork.Node).CreateRed();
		}
		
		public ForkStatementSyntax ForkStatement()
		{
			return this.ForkStatement(this.Token(PilSyntaxKind.KFork), default, default, default, this.Token(PilSyntaxKind.KEndFork));
		}
		
		public CaseBranchSyntax CaseBranch(SyntaxToken kCase, ExpressionSyntax condition, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
		{
		    if (kCase == null) throw new ArgumentNullException(nameof(kCase));
		    if (kCase.GetKind() != PilSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
		    if (condition == null) throw new ArgumentNullException(nameof(condition));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (CaseBranchSyntax)PilLanguage.Instance.InternalSyntaxFactory.CaseBranch((InternalSyntaxToken)kCase.Node, (Syntax.InternalSyntax.ExpressionGreen)condition.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)tSemicolon.Node, statements == null ? null : (Syntax.InternalSyntax.StatementsGreen)statements.Green).CreateRed();
		}
		
		public CaseBranchSyntax CaseBranch(ExpressionSyntax condition)
		{
			return this.CaseBranch(this.Token(PilSyntaxKind.KCase), condition, default, this.Token(PilSyntaxKind.TSemicolon), default);
		}
		
		public ElseBranchSyntax ElseBranch(SyntaxToken kElse, CommentSyntax comment, StatementsSyntax statements)
		{
		    if (kElse == null) throw new ArgumentNullException(nameof(kElse));
		    if (kElse.GetKind() != PilSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
		    return (ElseBranchSyntax)PilLanguage.Instance.InternalSyntaxFactory.ElseBranch((InternalSyntaxToken)kElse.Node, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, statements == null ? null : (Syntax.InternalSyntax.StatementsGreen)statements.Green).CreateRed();
		}
		
		public ElseBranchSyntax ElseBranch()
		{
			return this.ElseBranch(this.Token(PilSyntaxKind.KElse), default, default);
		}
		
		public IfStatementSyntax IfStatement(SyntaxToken kIf, IfBranchSyntax ifBranch, SyntaxList<ElseIfBranchSyntax> elseIfBranch, SyntaxList<ElseBranchSyntax> elseBranch, SyntaxToken kEndIf)
		{
		    if (kIf == null) throw new ArgumentNullException(nameof(kIf));
		    if (kIf.GetKind() != PilSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
		    if (ifBranch == null) throw new ArgumentNullException(nameof(ifBranch));
		    if (kEndIf == null) throw new ArgumentNullException(nameof(kEndIf));
		    if (kEndIf.GetKind() != PilSyntaxKind.KEndIf) throw new ArgumentException(nameof(kEndIf));
		    return (IfStatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.IfStatement((InternalSyntaxToken)kIf.Node, (Syntax.InternalSyntax.IfBranchGreen)ifBranch.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ElseIfBranchGreen>(elseIfBranch.Node), Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ElseBranchGreen>(elseBranch.Node), (InternalSyntaxToken)kEndIf.Node).CreateRed();
		}
		
		public IfStatementSyntax IfStatement(IfBranchSyntax ifBranch)
		{
			return this.IfStatement(this.Token(PilSyntaxKind.KIf), ifBranch, default, default, this.Token(PilSyntaxKind.KEndIf));
		}
		
		public IfBranchSyntax IfBranch(ConditionalExpressionSyntax conditionalExpression, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
		{
		    if (conditionalExpression == null) throw new ArgumentNullException(nameof(conditionalExpression));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (IfBranchSyntax)PilLanguage.Instance.InternalSyntaxFactory.IfBranch((Syntax.InternalSyntax.ConditionalExpressionGreen)conditionalExpression.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)tSemicolon.Node, statements == null ? null : (Syntax.InternalSyntax.StatementsGreen)statements.Green).CreateRed();
		}
		
		public IfBranchSyntax IfBranch(ConditionalExpressionSyntax conditionalExpression)
		{
			return this.IfBranch(conditionalExpression, default, this.Token(PilSyntaxKind.TSemicolon), default);
		}
		
		public ElseIfBranchSyntax ElseIfBranch(SyntaxToken kElse, SyntaxToken kIf, IfBranchSyntax ifBranch)
		{
		    if (kElse == null) throw new ArgumentNullException(nameof(kElse));
		    if (kElse.GetKind() != PilSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
		    if (kIf == null) throw new ArgumentNullException(nameof(kIf));
		    if (kIf.GetKind() != PilSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
		    if (ifBranch == null) throw new ArgumentNullException(nameof(ifBranch));
		    return (ElseIfBranchSyntax)PilLanguage.Instance.InternalSyntaxFactory.ElseIfBranch((InternalSyntaxToken)kElse.Node, (InternalSyntaxToken)kIf.Node, (Syntax.InternalSyntax.IfBranchGreen)ifBranch.Green).CreateRed();
		}
		
		public ElseIfBranchSyntax ElseIfBranch(IfBranchSyntax ifBranch)
		{
			return this.ElseIfBranch(this.Token(PilSyntaxKind.KElse), this.Token(PilSyntaxKind.KIf), ifBranch);
		}
		
		public RequestStatementSyntax RequestStatement(LeftSideSyntax leftSide, SyntaxToken tAssign, CallRequestSyntax callRequest, AssertionSyntax assertion, SyntaxToken tSemicolon)
		{
		    if (tAssign != null && tAssign.GetKind() != PilSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (callRequest == null) throw new ArgumentNullException(nameof(callRequest));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (RequestStatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.RequestStatement(leftSide == null ? null : (Syntax.InternalSyntax.LeftSideGreen)leftSide.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.CallRequestGreen)callRequest.Green, assertion == null ? null : (Syntax.InternalSyntax.AssertionGreen)assertion.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public RequestStatementSyntax RequestStatement(CallRequestSyntax callRequest)
		{
			return this.RequestStatement(default, default, callRequest, default, this.Token(PilSyntaxKind.TSemicolon));
		}
		
		public CallRequestSyntax CallRequest(SyntaxToken kRequest, IdentifierSyntax portName, SyntaxToken tDot, IdentifierSyntax queryName, RequestArgumentsSyntax requestArguments)
		{
		    if (kRequest == null) throw new ArgumentNullException(nameof(kRequest));
		    if (kRequest.GetKind() != PilSyntaxKind.KRequest) throw new ArgumentException(nameof(kRequest));
		    if (portName == null) throw new ArgumentNullException(nameof(portName));
		    if (tDot != null && tDot.GetKind() != PilSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
		    return (CallRequestSyntax)PilLanguage.Instance.InternalSyntaxFactory.CallRequest((InternalSyntaxToken)kRequest.Node, (Syntax.InternalSyntax.IdentifierGreen)portName.Green, (InternalSyntaxToken)tDot.Node, queryName == null ? null : (Syntax.InternalSyntax.IdentifierGreen)queryName.Green, requestArguments == null ? null : (Syntax.InternalSyntax.RequestArgumentsGreen)requestArguments.Green).CreateRed();
		}
		
		public CallRequestSyntax CallRequest(IdentifierSyntax portName)
		{
			return this.CallRequest(this.Token(PilSyntaxKind.KRequest), portName, default, default, default);
		}
		
		public RequestArgumentsSyntax RequestArguments(SyntaxToken tOpenParen, ExpressionListSyntax expressionList, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (RequestArgumentsSyntax)PilLanguage.Instance.InternalSyntaxFactory.RequestArguments((InternalSyntaxToken)tOpenParen.Node, expressionList == null ? null : (Syntax.InternalSyntax.ExpressionListGreen)expressionList.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public RequestArgumentsSyntax RequestArguments()
		{
			return this.RequestArguments(this.Token(PilSyntaxKind.TOpenParen), default, this.Token(PilSyntaxKind.TCloseParen));
		}
		
		public ResponseStatementSyntax ResponseStatement(ResponseStatementKindSyntax responseStatementKind, AssertionSyntax assertion, SyntaxToken tSemicolon)
		{
		    if (responseStatementKind == null) throw new ArgumentNullException(nameof(responseStatementKind));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ResponseStatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.ResponseStatement((Syntax.InternalSyntax.ResponseStatementKindGreen)responseStatementKind.Green, assertion == null ? null : (Syntax.InternalSyntax.AssertionGreen)assertion.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ResponseStatementSyntax ResponseStatement(ResponseStatementKindSyntax responseStatementKind)
		{
			return this.ResponseStatement(responseStatementKind, default, this.Token(PilSyntaxKind.TSemicolon));
		}
		
		public CancelStatementSyntax CancelStatement(CancelStatementKindSyntax cancelStatementKind, IdentifierSyntax portName, AssertionSyntax assertion, SyntaxToken tSemicolon)
		{
		    if (cancelStatementKind == null) throw new ArgumentNullException(nameof(cancelStatementKind));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (CancelStatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.CancelStatement((Syntax.InternalSyntax.CancelStatementKindGreen)cancelStatementKind.Green, portName == null ? null : (Syntax.InternalSyntax.IdentifierGreen)portName.Green, assertion == null ? null : (Syntax.InternalSyntax.AssertionGreen)assertion.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public CancelStatementSyntax CancelStatement(CancelStatementKindSyntax cancelStatementKind)
		{
			return this.CancelStatement(cancelStatementKind, default, default, this.Token(PilSyntaxKind.TSemicolon));
		}
		
		public AssertionSyntax Assertion(SyntaxToken tColon, ExpressionSyntax expression, CommentSyntax comment)
		{
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    return (AssertionSyntax)PilLanguage.Instance.InternalSyntaxFactory.Assertion((InternalSyntaxToken)tColon.Node, expression == null ? null : (Syntax.InternalSyntax.ExpressionGreen)expression.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green).CreateRed();
		}
		
		public AssertionSyntax Assertion()
		{
			return this.Assertion(this.Token(PilSyntaxKind.TColon), default, default);
		}
		
		public ResponseStatementKindSyntax ResponseStatementKind(SyntaxToken responseStatementKind)
		{
		    if (responseStatementKind == null) throw new ArgumentNullException(nameof(responseStatementKind));
		    return (ResponseStatementKindSyntax)PilLanguage.Instance.InternalSyntaxFactory.ResponseStatementKind((InternalSyntaxToken)responseStatementKind.Node).CreateRed();
		}
		
		public CancelStatementKindSyntax CancelStatementKind(SyntaxToken kCancel)
		{
		    if (kCancel == null) throw new ArgumentNullException(nameof(kCancel));
		    if (kCancel.GetKind() != PilSyntaxKind.KCancel) throw new ArgumentException(nameof(kCancel));
		    return (CancelStatementKindSyntax)PilLanguage.Instance.InternalSyntaxFactory.CancelStatementKind((InternalSyntaxToken)kCancel.Node).CreateRed();
		}
		
		public CancelStatementKindSyntax CancelStatementKind()
		{
			return this.CancelStatementKind(this.Token(PilSyntaxKind.KCancel));
		}
		
		public ForkRequestStatementSyntax ForkRequestStatement(SyntaxToken kFork, ForkRequestVariableSyntax forkRequestVariable, AcceptBranchSyntax acceptBranch, RefuseBranchSyntax refuseBranch, CancelBranchSyntax cancelBranch, SyntaxToken kEndFork)
		{
		    if (kFork == null) throw new ArgumentNullException(nameof(kFork));
		    if (kFork.GetKind() != PilSyntaxKind.KFork) throw new ArgumentException(nameof(kFork));
		    if (forkRequestVariable == null) throw new ArgumentNullException(nameof(forkRequestVariable));
		    if (kEndFork == null) throw new ArgumentNullException(nameof(kEndFork));
		    if (kEndFork.GetKind() != PilSyntaxKind.KEndFork) throw new ArgumentException(nameof(kEndFork));
		    return (ForkRequestStatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.ForkRequestStatement((InternalSyntaxToken)kFork.Node, (Syntax.InternalSyntax.ForkRequestVariableGreen)forkRequestVariable.Green, acceptBranch == null ? null : (Syntax.InternalSyntax.AcceptBranchGreen)acceptBranch.Green, refuseBranch == null ? null : (Syntax.InternalSyntax.RefuseBranchGreen)refuseBranch.Green, cancelBranch == null ? null : (Syntax.InternalSyntax.CancelBranchGreen)cancelBranch.Green, (InternalSyntaxToken)kEndFork.Node).CreateRed();
		}
		
		public ForkRequestStatementSyntax ForkRequestStatement(ForkRequestVariableSyntax forkRequestVariable)
		{
			return this.ForkRequestStatement(this.Token(PilSyntaxKind.KFork), forkRequestVariable, default, default, default, this.Token(PilSyntaxKind.KEndFork));
		}
		
		public ForkRequestVariableSyntax ForkRequestVariable(ForkRequestIdentifierSyntax forkRequestIdentifier)
		{
		    if (forkRequestIdentifier == null) throw new ArgumentNullException(nameof(forkRequestIdentifier));
		    return (ForkRequestVariableSyntax)PilLanguage.Instance.InternalSyntaxFactory.ForkRequestVariable((Syntax.InternalSyntax.ForkRequestIdentifierGreen)forkRequestIdentifier.Green).CreateRed();
		}
		
		public ForkRequestVariableSyntax ForkRequestVariable(RequestStatementSyntax requestStatement)
		{
		    if (requestStatement == null) throw new ArgumentNullException(nameof(requestStatement));
		    return (ForkRequestVariableSyntax)PilLanguage.Instance.InternalSyntaxFactory.ForkRequestVariable((Syntax.InternalSyntax.RequestStatementGreen)requestStatement.Green).CreateRed();
		}
		
		public ForkRequestIdentifierSyntax ForkRequestIdentifier(IdentifierSyntax identifier, SyntaxToken tSemicolon)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ForkRequestIdentifierSyntax)PilLanguage.Instance.InternalSyntaxFactory.ForkRequestIdentifier((Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ForkRequestIdentifierSyntax ForkRequestIdentifier(IdentifierSyntax identifier)
		{
			return this.ForkRequestIdentifier(identifier, this.Token(PilSyntaxKind.TSemicolon));
		}
		
		public AcceptBranchSyntax AcceptBranch(SyntaxToken kCase, SyntaxToken kAccept, ExpressionSyntax condition, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
		{
		    if (kCase == null) throw new ArgumentNullException(nameof(kCase));
		    if (kCase.GetKind() != PilSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
		    if (kAccept == null) throw new ArgumentNullException(nameof(kAccept));
		    if (kAccept.GetKind() != PilSyntaxKind.KAccept) throw new ArgumentException(nameof(kAccept));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (AcceptBranchSyntax)PilLanguage.Instance.InternalSyntaxFactory.AcceptBranch((InternalSyntaxToken)kCase.Node, (InternalSyntaxToken)kAccept.Node, condition == null ? null : (Syntax.InternalSyntax.ExpressionGreen)condition.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)tSemicolon.Node, statements == null ? null : (Syntax.InternalSyntax.StatementsGreen)statements.Green).CreateRed();
		}
		
		public AcceptBranchSyntax AcceptBranch()
		{
			return this.AcceptBranch(this.Token(PilSyntaxKind.KCase), this.Token(PilSyntaxKind.KAccept), default, default, this.Token(PilSyntaxKind.TSemicolon), default);
		}
		
		public RefuseBranchSyntax RefuseBranch(SyntaxToken kCase, SyntaxToken kRefuse, ExpressionSyntax condition, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
		{
		    if (kCase == null) throw new ArgumentNullException(nameof(kCase));
		    if (kCase.GetKind() != PilSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
		    if (kRefuse == null) throw new ArgumentNullException(nameof(kRefuse));
		    if (kRefuse.GetKind() != PilSyntaxKind.KRefuse) throw new ArgumentException(nameof(kRefuse));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (RefuseBranchSyntax)PilLanguage.Instance.InternalSyntaxFactory.RefuseBranch((InternalSyntaxToken)kCase.Node, (InternalSyntaxToken)kRefuse.Node, condition == null ? null : (Syntax.InternalSyntax.ExpressionGreen)condition.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)tSemicolon.Node, statements == null ? null : (Syntax.InternalSyntax.StatementsGreen)statements.Green).CreateRed();
		}
		
		public RefuseBranchSyntax RefuseBranch()
		{
			return this.RefuseBranch(this.Token(PilSyntaxKind.KCase), this.Token(PilSyntaxKind.KRefuse), default, default, this.Token(PilSyntaxKind.TSemicolon), default);
		}
		
		public CancelBranchSyntax CancelBranch(SyntaxToken kCase, SyntaxToken kCancel, ExpressionSyntax condition, CommentSyntax comment, SyntaxToken tSemicolon, StatementsSyntax statements)
		{
		    if (kCase == null) throw new ArgumentNullException(nameof(kCase));
		    if (kCase.GetKind() != PilSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
		    if (kCancel == null) throw new ArgumentNullException(nameof(kCancel));
		    if (kCancel.GetKind() != PilSyntaxKind.KCancel) throw new ArgumentException(nameof(kCancel));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (CancelBranchSyntax)PilLanguage.Instance.InternalSyntaxFactory.CancelBranch((InternalSyntaxToken)kCase.Node, (InternalSyntaxToken)kCancel.Node, condition == null ? null : (Syntax.InternalSyntax.ExpressionGreen)condition.Green, comment == null ? null : (Syntax.InternalSyntax.CommentGreen)comment.Green, (InternalSyntaxToken)tSemicolon.Node, statements == null ? null : (Syntax.InternalSyntax.StatementsGreen)statements.Green).CreateRed();
		}
		
		public CancelBranchSyntax CancelBranch()
		{
			return this.CancelBranch(this.Token(PilSyntaxKind.KCase), this.Token(PilSyntaxKind.KCancel), default, default, this.Token(PilSyntaxKind.TSemicolon), default);
		}
		
		public VariableDeclarationStatementSyntax VariableDeclarationStatement(VariableDeclarationSyntax variableDeclaration)
		{
		    if (variableDeclaration == null) throw new ArgumentNullException(nameof(variableDeclaration));
		    return (VariableDeclarationStatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.VariableDeclarationStatement((Syntax.InternalSyntax.VariableDeclarationGreen)variableDeclaration.Green).CreateRed();
		}
		
		public VariableDeclarationSyntax VariableDeclaration(SyntaxToken kVar, NameSyntax name, SyntaxToken tColon, TypeReferenceSyntax typeReference, SyntaxToken tAssign, ExpressionSyntax expression, SyntaxToken tSemicolon)
		{
		    if (kVar == null) throw new ArgumentNullException(nameof(kVar));
		    if (kVar.GetKind() != PilSyntaxKind.KVar) throw new ArgumentException(nameof(kVar));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != PilSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tAssign != null && tAssign.GetKind() != PilSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (VariableDeclarationSyntax)PilLanguage.Instance.InternalSyntaxFactory.VariableDeclaration((InternalSyntaxToken)kVar.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tAssign.Node, expression == null ? null : (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public VariableDeclarationSyntax VariableDeclaration(NameSyntax name, TypeReferenceSyntax typeReference)
		{
			return this.VariableDeclaration(this.Token(PilSyntaxKind.KVar), name, this.Token(PilSyntaxKind.TColon), typeReference, default, default, this.Token(PilSyntaxKind.TSemicolon));
		}
		
		public AssignmentStatementSyntax AssignmentStatement(LeftSideSyntax leftSide, SyntaxToken tAssign, ExpressionSyntax value, SyntaxToken tSemicolon)
		{
		    if (leftSide == null) throw new ArgumentNullException(nameof(leftSide));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != PilSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (value == null) throw new ArgumentNullException(nameof(value));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != PilSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (AssignmentStatementSyntax)PilLanguage.Instance.InternalSyntaxFactory.AssignmentStatement((Syntax.InternalSyntax.LeftSideGreen)leftSide.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.ExpressionGreen)value.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public AssignmentStatementSyntax AssignmentStatement(LeftSideSyntax leftSide, ExpressionSyntax value)
		{
			return this.AssignmentStatement(leftSide, this.Token(PilSyntaxKind.TAssign), value, this.Token(PilSyntaxKind.TSemicolon));
		}
		
		public LeftSideSyntax LeftSide(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (LeftSideSyntax)PilLanguage.Instance.InternalSyntaxFactory.LeftSide((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public LeftSideSyntax LeftSide(ResultIdentifierSyntax resultIdentifier)
		{
		    if (resultIdentifier == null) throw new ArgumentNullException(nameof(resultIdentifier));
		    return (LeftSideSyntax)PilLanguage.Instance.InternalSyntaxFactory.LeftSide((Syntax.InternalSyntax.ResultIdentifierGreen)resultIdentifier.Green).CreateRed();
		}
		
		public ExpressionListSyntax ExpressionList(SeparatedSyntaxList<ExpressionSyntax> expression)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (ExpressionListSyntax)PilLanguage.Instance.InternalSyntaxFactory.ExpressionList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ExpressionGreen>(expression.Node)).CreateRed();
		}
		
		public ExpressionSyntax Expression(ArithmeticExpressionSyntax arithmeticExpression)
		{
		    if (arithmeticExpression == null) throw new ArgumentNullException(nameof(arithmeticExpression));
		    return (ExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.Expression((Syntax.InternalSyntax.ArithmeticExpressionGreen)arithmeticExpression.Green).CreateRed();
		}
		
		public ExpressionSyntax Expression(ConditionalExpressionSyntax conditionalExpression)
		{
		    if (conditionalExpression == null) throw new ArgumentNullException(nameof(conditionalExpression));
		    return (ExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.Expression((Syntax.InternalSyntax.ConditionalExpressionGreen)conditionalExpression.Green).CreateRed();
		}
		
		public MulDivExpressionSyntax MulDivExpression(ArithmeticExpressionSyntax left, OpMulDivSyntax opMulDiv, ArithmeticExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (opMulDiv == null) throw new ArgumentNullException(nameof(opMulDiv));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (MulDivExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.MulDivExpression((Syntax.InternalSyntax.ArithmeticExpressionGreen)left.Green, (Syntax.InternalSyntax.OpMulDivGreen)opMulDiv.Green, (Syntax.InternalSyntax.ArithmeticExpressionGreen)right.Green).CreateRed();
		}
		
		public PlusMinusExpressionSyntax PlusMinusExpression(ArithmeticExpressionSyntax left, OpAddSubSyntax opAddSub, ArithmeticExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (opAddSub == null) throw new ArgumentNullException(nameof(opAddSub));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (PlusMinusExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.PlusMinusExpression((Syntax.InternalSyntax.ArithmeticExpressionGreen)left.Green, (Syntax.InternalSyntax.OpAddSubGreen)opAddSub.Green, (Syntax.InternalSyntax.ArithmeticExpressionGreen)right.Green).CreateRed();
		}
		
		public NegateExpressionSyntax NegateExpression(OpMinusSyntax opMinus, ArithmeticExpressionTerminatorSyntax arithmeticExpressionTerminator)
		{
		    if (opMinus == null) throw new ArgumentNullException(nameof(opMinus));
		    if (arithmeticExpressionTerminator == null) throw new ArgumentNullException(nameof(arithmeticExpressionTerminator));
		    return (NegateExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.NegateExpression((Syntax.InternalSyntax.OpMinusGreen)opMinus.Green, (Syntax.InternalSyntax.ArithmeticExpressionTerminatorGreen)arithmeticExpressionTerminator.Green).CreateRed();
		}
		
		public SimpleArithmeticExpressionSyntax SimpleArithmeticExpression(ArithmeticExpressionTerminatorSyntax arithmeticExpressionTerminator)
		{
		    if (arithmeticExpressionTerminator == null) throw new ArgumentNullException(nameof(arithmeticExpressionTerminator));
		    return (SimpleArithmeticExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.SimpleArithmeticExpression((Syntax.InternalSyntax.ArithmeticExpressionTerminatorGreen)arithmeticExpressionTerminator.Green).CreateRed();
		}
		
		public OpMulDivSyntax OpMulDiv(SyntaxToken opMulDiv)
		{
		    if (opMulDiv == null) throw new ArgumentNullException(nameof(opMulDiv));
		    return (OpMulDivSyntax)PilLanguage.Instance.InternalSyntaxFactory.OpMulDiv((InternalSyntaxToken)opMulDiv.Node).CreateRed();
		}
		
		public OpAddSubSyntax OpAddSub(SyntaxToken opAddSub)
		{
		    if (opAddSub == null) throw new ArgumentNullException(nameof(opAddSub));
		    return (OpAddSubSyntax)PilLanguage.Instance.InternalSyntaxFactory.OpAddSub((InternalSyntaxToken)opAddSub.Node).CreateRed();
		}
		
		public ParenArithmeticExpressionSyntax ParenArithmeticExpression(SyntaxToken tOpenParen, ArithmeticExpressionSyntax arithmeticExpression, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (arithmeticExpression == null) throw new ArgumentNullException(nameof(arithmeticExpression));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (ParenArithmeticExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.ParenArithmeticExpression((InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.ArithmeticExpressionGreen)arithmeticExpression.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public ParenArithmeticExpressionSyntax ParenArithmeticExpression(ArithmeticExpressionSyntax arithmeticExpression)
		{
			return this.ParenArithmeticExpression(this.Token(PilSyntaxKind.TOpenParen), arithmeticExpression, this.Token(PilSyntaxKind.TCloseParen));
		}
		
		public TerminalArithmeticExpressionSyntax TerminalArithmeticExpression(TerminalExpressionSyntax terminalExpression)
		{
		    if (terminalExpression == null) throw new ArgumentNullException(nameof(terminalExpression));
		    return (TerminalArithmeticExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.TerminalArithmeticExpression((Syntax.InternalSyntax.TerminalExpressionGreen)terminalExpression.Green).CreateRed();
		}
		
		public OpMinusSyntax OpMinus(SyntaxToken tMinus)
		{
		    if (tMinus == null) throw new ArgumentNullException(nameof(tMinus));
		    if (tMinus.GetKind() != PilSyntaxKind.TMinus) throw new ArgumentException(nameof(tMinus));
		    return (OpMinusSyntax)PilLanguage.Instance.InternalSyntaxFactory.OpMinus((InternalSyntaxToken)tMinus.Node).CreateRed();
		}
		
		public OpMinusSyntax OpMinus()
		{
			return this.OpMinus(this.Token(PilSyntaxKind.TMinus));
		}
		
		public AndExpressionSyntax AndExpression(ConditionalExpressionSyntax left, AndAlsoOpSyntax andAlsoOp, ConditionalExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (andAlsoOp == null) throw new ArgumentNullException(nameof(andAlsoOp));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (AndExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.AndExpression((Syntax.InternalSyntax.ConditionalExpressionGreen)left.Green, (Syntax.InternalSyntax.AndAlsoOpGreen)andAlsoOp.Green, (Syntax.InternalSyntax.ConditionalExpressionGreen)right.Green).CreateRed();
		}
		
		public OrExpressionSyntax OrExpression(ConditionalExpressionSyntax left, OrElseOpSyntax orElseOp, ConditionalExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (orElseOp == null) throw new ArgumentNullException(nameof(orElseOp));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (OrExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.OrExpression((Syntax.InternalSyntax.ConditionalExpressionGreen)left.Green, (Syntax.InternalSyntax.OrElseOpGreen)orElseOp.Green, (Syntax.InternalSyntax.ConditionalExpressionGreen)right.Green).CreateRed();
		}
		
		public NotExpressionSyntax NotExpression(OpExclSyntax opExcl, ConditionalExpressionTerminatorSyntax conditionalExpressionTerminator)
		{
		    if (opExcl == null) throw new ArgumentNullException(nameof(opExcl));
		    if (conditionalExpressionTerminator == null) throw new ArgumentNullException(nameof(conditionalExpressionTerminator));
		    return (NotExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.NotExpression((Syntax.InternalSyntax.OpExclGreen)opExcl.Green, (Syntax.InternalSyntax.ConditionalExpressionTerminatorGreen)conditionalExpressionTerminator.Green).CreateRed();
		}
		
		public SimpleConditionalExpressionSyntax SimpleConditionalExpression(ConditionalExpressionTerminatorSyntax conditionalExpressionTerminator)
		{
		    if (conditionalExpressionTerminator == null) throw new ArgumentNullException(nameof(conditionalExpressionTerminator));
		    return (SimpleConditionalExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.SimpleConditionalExpression((Syntax.InternalSyntax.ConditionalExpressionTerminatorGreen)conditionalExpressionTerminator.Green).CreateRed();
		}
		
		public AndAlsoOpSyntax AndAlsoOp(SyntaxToken tAndAlso)
		{
		    if (tAndAlso == null) throw new ArgumentNullException(nameof(tAndAlso));
		    if (tAndAlso.GetKind() != PilSyntaxKind.TAndAlso) throw new ArgumentException(nameof(tAndAlso));
		    return (AndAlsoOpSyntax)PilLanguage.Instance.InternalSyntaxFactory.AndAlsoOp((InternalSyntaxToken)tAndAlso.Node).CreateRed();
		}
		
		public AndAlsoOpSyntax AndAlsoOp()
		{
			return this.AndAlsoOp(this.Token(PilSyntaxKind.TAndAlso));
		}
		
		public OrElseOpSyntax OrElseOp(SyntaxToken tOrElse)
		{
		    if (tOrElse == null) throw new ArgumentNullException(nameof(tOrElse));
		    if (tOrElse.GetKind() != PilSyntaxKind.TOrElse) throw new ArgumentException(nameof(tOrElse));
		    return (OrElseOpSyntax)PilLanguage.Instance.InternalSyntaxFactory.OrElseOp((InternalSyntaxToken)tOrElse.Node).CreateRed();
		}
		
		public OrElseOpSyntax OrElseOp()
		{
			return this.OrElseOp(this.Token(PilSyntaxKind.TOrElse));
		}
		
		public OpExclSyntax OpExcl(SyntaxToken tExclamation)
		{
		    if (tExclamation == null) throw new ArgumentNullException(nameof(tExclamation));
		    if (tExclamation.GetKind() != PilSyntaxKind.TExclamation) throw new ArgumentException(nameof(tExclamation));
		    return (OpExclSyntax)PilLanguage.Instance.InternalSyntaxFactory.OpExcl((InternalSyntaxToken)tExclamation.Node).CreateRed();
		}
		
		public OpExclSyntax OpExcl()
		{
			return this.OpExcl(this.Token(PilSyntaxKind.TExclamation));
		}
		
		public ParenConditionalExpressionSyntax ParenConditionalExpression(SyntaxToken tOpenParen, ConditionalExpressionSyntax conditionalExpression, SyntaxToken tCloseParen)
		{
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (conditionalExpression == null) throw new ArgumentNullException(nameof(conditionalExpression));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (ParenConditionalExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.ParenConditionalExpression((InternalSyntaxToken)tOpenParen.Node, (Syntax.InternalSyntax.ConditionalExpressionGreen)conditionalExpression.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public ParenConditionalExpressionSyntax ParenConditionalExpression(ConditionalExpressionSyntax conditionalExpression)
		{
			return this.ParenConditionalExpression(this.Token(PilSyntaxKind.TOpenParen), conditionalExpression, this.Token(PilSyntaxKind.TCloseParen));
		}
		
		public ElementOfConditionalExpressionSyntax ElementOfConditionalExpression(ElementOfExpressionSyntax elementOfExpression)
		{
		    if (elementOfExpression == null) throw new ArgumentNullException(nameof(elementOfExpression));
		    return (ElementOfConditionalExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.ElementOfConditionalExpression((Syntax.InternalSyntax.ElementOfExpressionGreen)elementOfExpression.Green).CreateRed();
		}
		
		public ComparisonConditionalExpressionSyntax ComparisonConditionalExpression(ComparisonExpressionSyntax comparisonExpression)
		{
		    if (comparisonExpression == null) throw new ArgumentNullException(nameof(comparisonExpression));
		    return (ComparisonConditionalExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.ComparisonConditionalExpression((Syntax.InternalSyntax.ComparisonExpressionGreen)comparisonExpression.Green).CreateRed();
		}
		
		public TerminalComparisonExpressionSyntax TerminalComparisonExpression(TerminalExpressionSyntax terminalExpression)
		{
		    if (terminalExpression == null) throw new ArgumentNullException(nameof(terminalExpression));
		    return (TerminalComparisonExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.TerminalComparisonExpression((Syntax.InternalSyntax.TerminalExpressionGreen)terminalExpression.Green).CreateRed();
		}
		
		public ComparisonExpressionSyntax ComparisonExpression(ArithmeticExpressionSyntax left, ComparisonOperatorSyntax op, ArithmeticExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (op == null) throw new ArgumentNullException(nameof(op));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (ComparisonExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.ComparisonExpression((Syntax.InternalSyntax.ArithmeticExpressionGreen)left.Green, (Syntax.InternalSyntax.ComparisonOperatorGreen)op.Green, (Syntax.InternalSyntax.ArithmeticExpressionGreen)right.Green).CreateRed();
		}
		
		public ComparisonOperatorSyntax ComparisonOperator(SyntaxToken comparisonOperator)
		{
		    if (comparisonOperator == null) throw new ArgumentNullException(nameof(comparisonOperator));
		    return (ComparisonOperatorSyntax)PilLanguage.Instance.InternalSyntaxFactory.ComparisonOperator((InternalSyntaxToken)comparisonOperator.Node).CreateRed();
		}
		
		public ElementOfExpressionSyntax ElementOfExpression(TerminalExpressionSyntax terminalExpression, SyntaxToken kIn, SyntaxToken tOpenBracket, ElementOfValueListSyntax elementOfValueList, SyntaxToken tCloseBracket)
		{
		    if (terminalExpression == null) throw new ArgumentNullException(nameof(terminalExpression));
		    if (kIn == null) throw new ArgumentNullException(nameof(kIn));
		    if (kIn.GetKind() != PilSyntaxKind.KIn) throw new ArgumentException(nameof(kIn));
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != PilSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != PilSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (ElementOfExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.ElementOfExpression((Syntax.InternalSyntax.TerminalExpressionGreen)terminalExpression.Green, (InternalSyntaxToken)kIn.Node, (InternalSyntaxToken)tOpenBracket.Node, elementOfValueList == null ? null : (Syntax.InternalSyntax.ElementOfValueListGreen)elementOfValueList.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public ElementOfExpressionSyntax ElementOfExpression(TerminalExpressionSyntax terminalExpression)
		{
			return this.ElementOfExpression(terminalExpression, this.Token(PilSyntaxKind.KIn), this.Token(PilSyntaxKind.TOpenBracket), default, this.Token(PilSyntaxKind.TCloseBracket));
		}
		
		public ElementOfValueListSyntax ElementOfValueList(SeparatedSyntaxList<ElementOfValueSyntax> elementOfValue)
		{
		    if (elementOfValue == null) throw new ArgumentNullException(nameof(elementOfValue));
		    return (ElementOfValueListSyntax)PilLanguage.Instance.InternalSyntaxFactory.ElementOfValueList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ElementOfValueGreen>(elementOfValue.Node)).CreateRed();
		}
		
		public ElementOfValueSyntax ElementOfValue(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (ElementOfValueSyntax)PilLanguage.Instance.InternalSyntaxFactory.ElementOfValue((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public TerminalExpressionSyntax TerminalExpression(VariableReferenceSyntax variableReference)
		{
		    if (variableReference == null) throw new ArgumentNullException(nameof(variableReference));
		    return (TerminalExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.TerminalExpression((Syntax.InternalSyntax.VariableReferenceGreen)variableReference.Green).CreateRed();
		}
		
		public TerminalExpressionSyntax TerminalExpression(FunctionCallExpressionSyntax functionCallExpression)
		{
		    if (functionCallExpression == null) throw new ArgumentNullException(nameof(functionCallExpression));
		    return (TerminalExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.TerminalExpression((Syntax.InternalSyntax.FunctionCallExpressionGreen)functionCallExpression.Green).CreateRed();
		}
		
		public TerminalExpressionSyntax TerminalExpression(LiteralSyntax literal)
		{
		    if (literal == null) throw new ArgumentNullException(nameof(literal));
		    return (TerminalExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.TerminalExpression((Syntax.InternalSyntax.LiteralGreen)literal.Green).CreateRed();
		}
		
		public FunctionCallExpressionSyntax FunctionCallExpression(IdentifierSyntax identifier, SyntaxToken tOpenParen, ExpressionListSyntax expressionList, SyntaxToken tCloseParen)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tOpenParen == null) throw new ArgumentNullException(nameof(tOpenParen));
		    if (tOpenParen.GetKind() != PilSyntaxKind.TOpenParen) throw new ArgumentException(nameof(tOpenParen));
		    if (tCloseParen == null) throw new ArgumentNullException(nameof(tCloseParen));
		    if (tCloseParen.GetKind() != PilSyntaxKind.TCloseParen) throw new ArgumentException(nameof(tCloseParen));
		    return (FunctionCallExpressionSyntax)PilLanguage.Instance.InternalSyntaxFactory.FunctionCallExpression((Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tOpenParen.Node, expressionList == null ? null : (Syntax.InternalSyntax.ExpressionListGreen)expressionList.Green, (InternalSyntaxToken)tCloseParen.Node).CreateRed();
		}
		
		public FunctionCallExpressionSyntax FunctionCallExpression(IdentifierSyntax identifier)
		{
			return this.FunctionCallExpression(identifier, this.Token(PilSyntaxKind.TOpenParen), default, this.Token(PilSyntaxKind.TCloseParen));
		}
		
		public VariableReferenceSyntax VariableReference(SeparatedSyntaxList<VariableReferenceIdentifierSyntax> variableReferenceIdentifier)
		{
		    if (variableReferenceIdentifier == null) throw new ArgumentNullException(nameof(variableReferenceIdentifier));
		    return (VariableReferenceSyntax)PilLanguage.Instance.InternalSyntaxFactory.VariableReference(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<VariableReferenceIdentifierGreen>(variableReferenceIdentifier.Node)).CreateRed();
		}
		
		public VariableReferenceIdentifierSyntax VariableReferenceIdentifier(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (VariableReferenceIdentifierSyntax)PilLanguage.Instance.InternalSyntaxFactory.VariableReferenceIdentifier((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public CommentSyntax Comment(SyntaxToken lString)
		{
		    if (lString == null) throw new ArgumentNullException(nameof(lString));
		    if (lString.GetKind() != PilSyntaxKind.LString) throw new ArgumentException(nameof(lString));
		    return (CommentSyntax)PilLanguage.Instance.InternalSyntaxFactory.Comment((InternalSyntaxToken)lString.Node).CreateRed();
		}
		
		public LiteralSyntax Literal(SyntaxToken literal)
		{
		    if (literal == null) throw new ArgumentNullException(nameof(literal));
		    return (LiteralSyntax)PilLanguage.Instance.InternalSyntaxFactory.Literal((InternalSyntaxToken)literal.Node).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(BuiltInTypeSyntax builtInType)
		{
		    if (builtInType == null) throw new ArgumentNullException(nameof(builtInType));
		    return (TypeReferenceSyntax)PilLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.BuiltInTypeGreen)builtInType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (TypeReferenceSyntax)PilLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public BuiltInTypeSyntax BuiltInType(SyntaxToken builtInType)
		{
		    if (builtInType == null) throw new ArgumentNullException(nameof(builtInType));
		    return (BuiltInTypeSyntax)PilLanguage.Instance.InternalSyntaxFactory.BuiltInType((InternalSyntaxToken)builtInType.Node).CreateRed();
		}
		
		public QualifierListSyntax QualifierList(SeparatedSyntaxList<QualifierSyntax> qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifierListSyntax)PilLanguage.Instance.InternalSyntaxFactory.QualifierList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<QualifierGreen>(qualifier.Node)).CreateRed();
		}
		
		public QualifierSyntax Qualifier(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierSyntax)PilLanguage.Instance.InternalSyntaxFactory.Qualifier(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)PilLanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public IdentifierListSyntax IdentifierList(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierListSyntax)PilLanguage.Instance.InternalSyntaxFactory.IdentifierList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public IdentifierSyntax Identifier(SyntaxToken lIdentifier)
		{
		    if (lIdentifier == null) throw new ArgumentNullException(nameof(lIdentifier));
		    if (lIdentifier.GetKind() != PilSyntaxKind.LIdentifier) throw new ArgumentException(nameof(lIdentifier));
		    return (IdentifierSyntax)PilLanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)lIdentifier.Node).CreateRed();
		}
		
		public ResultIdentifierSyntax ResultIdentifier(SyntaxToken kResult)
		{
		    if (kResult == null) throw new ArgumentNullException(nameof(kResult));
		    if (kResult.GetKind() != PilSyntaxKind.KResult) throw new ArgumentException(nameof(kResult));
		    return (ResultIdentifierSyntax)PilLanguage.Instance.InternalSyntaxFactory.ResultIdentifier((InternalSyntaxToken)kResult.Node).CreateRed();
		}
		
		public ResultIdentifierSyntax ResultIdentifier()
		{
			return this.ResultIdentifier(this.Token(PilSyntaxKind.KResult));
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(DeclarationSyntax),
				typeof(TypeDefDeclarationSyntax),
				typeof(ExternalParameterDeclarationSyntax),
				typeof(EnumDeclarationSyntax),
				typeof(EnumLiteralsSyntax),
				typeof(EnumLiteralSyntax),
				typeof(ObjectDeclarationSyntax),
				typeof(ObjectHeaderSyntax),
				typeof(PortsSyntax),
				typeof(PortSyntax),
				typeof(ObjectExternalParametersSyntax),
				typeof(ObjectFieldsSyntax),
				typeof(ObjectFunctionsSyntax),
				typeof(FunctionDeclarationSyntax),
				typeof(FunctionHeaderSyntax),
				typeof(FunctionParamsSyntax),
				typeof(ParamSyntax),
				typeof(QueryDeclarationSyntax),
				typeof(QueryHeaderSyntax),
				typeof(QueryRequestParamsSyntax),
				typeof(QueryAcceptParamsSyntax),
				typeof(QueryRefuseParamsSyntax),
				typeof(QueryCancelParamsSyntax),
				typeof(QueryExternalParametersSyntax),
				typeof(QueryFieldSyntax),
				typeof(QueryFunctionSyntax),
				typeof(QueryObjectSyntax),
				typeof(QueryObjectFieldSyntax),
				typeof(QueryObjectFunctionSyntax),
				typeof(QueryObjectEventSyntax),
				typeof(InputSyntax),
				typeof(InputPortListSyntax),
				typeof(InputPortSyntax),
				typeof(TriggerSyntax),
				typeof(TriggerVarListSyntax),
				typeof(TriggerVarSyntax),
				typeof(StatementsSyntax),
				typeof(StatementSyntax),
				typeof(ForkStatementSyntax),
				typeof(CaseBranchSyntax),
				typeof(ElseBranchSyntax),
				typeof(IfStatementSyntax),
				typeof(IfBranchSyntax),
				typeof(ElseIfBranchSyntax),
				typeof(RequestStatementSyntax),
				typeof(CallRequestSyntax),
				typeof(RequestArgumentsSyntax),
				typeof(ResponseStatementSyntax),
				typeof(CancelStatementSyntax),
				typeof(AssertionSyntax),
				typeof(ResponseStatementKindSyntax),
				typeof(CancelStatementKindSyntax),
				typeof(ForkRequestStatementSyntax),
				typeof(ForkRequestVariableSyntax),
				typeof(ForkRequestIdentifierSyntax),
				typeof(AcceptBranchSyntax),
				typeof(RefuseBranchSyntax),
				typeof(CancelBranchSyntax),
				typeof(VariableDeclarationStatementSyntax),
				typeof(VariableDeclarationSyntax),
				typeof(AssignmentStatementSyntax),
				typeof(LeftSideSyntax),
				typeof(ExpressionListSyntax),
				typeof(ExpressionSyntax),
				typeof(MulDivExpressionSyntax),
				typeof(PlusMinusExpressionSyntax),
				typeof(NegateExpressionSyntax),
				typeof(SimpleArithmeticExpressionSyntax),
				typeof(OpMulDivSyntax),
				typeof(OpAddSubSyntax),
				typeof(ParenArithmeticExpressionSyntax),
				typeof(TerminalArithmeticExpressionSyntax),
				typeof(OpMinusSyntax),
				typeof(AndExpressionSyntax),
				typeof(OrExpressionSyntax),
				typeof(NotExpressionSyntax),
				typeof(SimpleConditionalExpressionSyntax),
				typeof(AndAlsoOpSyntax),
				typeof(OrElseOpSyntax),
				typeof(OpExclSyntax),
				typeof(ParenConditionalExpressionSyntax),
				typeof(ElementOfConditionalExpressionSyntax),
				typeof(ComparisonConditionalExpressionSyntax),
				typeof(TerminalComparisonExpressionSyntax),
				typeof(ComparisonExpressionSyntax),
				typeof(ComparisonOperatorSyntax),
				typeof(ElementOfExpressionSyntax),
				typeof(ElementOfValueListSyntax),
				typeof(ElementOfValueSyntax),
				typeof(TerminalExpressionSyntax),
				typeof(FunctionCallExpressionSyntax),
				typeof(VariableReferenceSyntax),
				typeof(VariableReferenceIdentifierSyntax),
				typeof(CommentSyntax),
				typeof(LiteralSyntax),
				typeof(TypeReferenceSyntax),
				typeof(BuiltInTypeSyntax),
				typeof(QualifierListSyntax),
				typeof(QualifierSyntax),
				typeof(NameSyntax),
				typeof(IdentifierListSyntax),
				typeof(IdentifierSyntax),
				typeof(ResultIdentifierSyntax),
			};
		}
	}
}

