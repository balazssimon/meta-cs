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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Syntax
{
    public abstract class TestLexerModeSyntaxNode : LanguageSyntaxNode
    {
        protected TestLexerModeSyntaxNode(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected TestLexerModeSyntaxNode(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new TestLexerModeLanguage Language => TestLexerModeLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new TestLexerModeSyntaxKind Kind => (TestLexerModeSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

        protected override SyntaxTree CreateSyntaxTreeForRoot()
        {
            return TestLexerModeSyntaxTree.CreateWithoutClone(this);
        }

        public override TResult Accept<TArg, TResult>(SyntaxVisitor<TArg, TResult> visitor, TArg argument)
        {
            if (visitor is ITestLexerModeSyntaxVisitor<TArg, TResult> typedVisitor) return this.Accept(typedVisitor, argument);
            else return visitor.DefaultVisit(this, argument);
        }

        public abstract TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument);

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            if (visitor is ITestLexerModeSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            if (visitor is ITestLexerModeSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }
        public abstract void Accept(ITestLexerModeSyntaxVisitor visitor);
    }

	
	public sealed class MainSyntax : TestLexerModeSyntaxNode, ICompilationUnitSyntax
	{
	    private NamespaceDeclarationSyntax namespaceDeclaration;
	    private GeneratorDeclarationSyntax generatorDeclaration;
	    private SyntaxNode usingDeclaration;
	    private ConfigDeclarationSyntax configDeclaration;
	    private SyntaxNode methodDeclaration;
	
	    public MainSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NamespaceDeclarationSyntax NamespaceDeclaration 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration, 0); } 
		}
	    public GeneratorDeclarationSyntax GeneratorDeclaration 
		{ 
			get { return this.GetRed(ref this.generatorDeclaration, 1); } 
		}
	    public SyntaxList<UsingDeclarationSyntax> UsingDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.usingDeclaration, 2);
				if (red != null) return new SyntaxList<UsingDeclarationSyntax>(red);
				return default;
			} 
		}
	    public ConfigDeclarationSyntax ConfigDeclaration 
		{ 
			get { return this.GetRed(ref this.configDeclaration, 3); } 
		}
	    public SyntaxList<MethodDeclarationSyntax> MethodDeclaration 
		{ 
			get
			{
				var red = this.GetRed(ref this.methodDeclaration, 4);
				if (red != null) return new SyntaxList<MethodDeclarationSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken EndOfFileToken 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.EndOfFileToken;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.namespaceDeclaration, 0);
				case 1: return this.GetRed(ref this.generatorDeclaration, 1);
				case 2: return this.GetRed(ref this.usingDeclaration, 2);
				case 3: return this.GetRed(ref this.configDeclaration, 3);
				case 4: return this.GetRed(ref this.methodDeclaration, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.namespaceDeclaration;
				case 1: return this.generatorDeclaration;
				case 2: return this.usingDeclaration;
				case 3: return this.configDeclaration;
				case 4: return this.methodDeclaration;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithNamespaceDeclaration(NamespaceDeclarationSyntax namespaceDeclaration)
		{
			return this.Update(NamespaceDeclaration, this.GeneratorDeclaration, this.UsingDeclaration, this.ConfigDeclaration, this.MethodDeclaration, this.EndOfFileToken);
		}
	
	    public MainSyntax WithGeneratorDeclaration(GeneratorDeclarationSyntax generatorDeclaration)
		{
			return this.Update(this.NamespaceDeclaration, GeneratorDeclaration, this.UsingDeclaration, this.ConfigDeclaration, this.MethodDeclaration, this.EndOfFileToken);
		}
	
	    public MainSyntax WithUsingDeclaration(SyntaxList<UsingDeclarationSyntax> usingDeclaration)
		{
			return this.Update(this.NamespaceDeclaration, this.GeneratorDeclaration, UsingDeclaration, this.ConfigDeclaration, this.MethodDeclaration, this.EndOfFileToken);
		}
	
	    public MainSyntax AddUsingDeclaration(params UsingDeclarationSyntax[] usingDeclaration)
		{
			return this.WithUsingDeclaration(this.UsingDeclaration.AddRange(usingDeclaration));
		}
	
	    public MainSyntax WithConfigDeclaration(ConfigDeclarationSyntax configDeclaration)
		{
			return this.Update(this.NamespaceDeclaration, this.GeneratorDeclaration, this.UsingDeclaration, ConfigDeclaration, this.MethodDeclaration, this.EndOfFileToken);
		}
	
	    public MainSyntax WithMethodDeclaration(SyntaxList<MethodDeclarationSyntax> methodDeclaration)
		{
			return this.Update(this.NamespaceDeclaration, this.GeneratorDeclaration, this.UsingDeclaration, this.ConfigDeclaration, MethodDeclaration, this.EndOfFileToken);
		}
	
	    public MainSyntax AddMethodDeclaration(params MethodDeclarationSyntax[] methodDeclaration)
		{
			return this.WithMethodDeclaration(this.MethodDeclaration.AddRange(methodDeclaration));
		}
	
	    public MainSyntax WithEndOfFileToken(SyntaxToken eOF)
		{
			return this.Update(this.NamespaceDeclaration, this.GeneratorDeclaration, this.UsingDeclaration, this.ConfigDeclaration, this.MethodDeclaration, EndOfFileToken);
		}
	
	    public MainSyntax Update(NamespaceDeclarationSyntax namespaceDeclaration, GeneratorDeclarationSyntax generatorDeclaration, SyntaxList<UsingDeclarationSyntax> usingDeclaration, ConfigDeclarationSyntax configDeclaration, SyntaxList<MethodDeclarationSyntax> methodDeclaration, SyntaxToken eOF)
	    {
	        if (this.NamespaceDeclaration != namespaceDeclaration ||
				this.GeneratorDeclaration != generatorDeclaration ||
				this.UsingDeclaration != usingDeclaration ||
				this.ConfigDeclaration != configDeclaration ||
				this.MethodDeclaration != methodDeclaration ||
				this.EndOfFileToken != eOF)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Main(namespaceDeclaration, generatorDeclaration, usingDeclaration, configDeclaration, methodDeclaration, eOF);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class NamespaceDeclarationSyntax : TestLexerModeSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.NamespaceDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclarationSyntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.TSemicolon);
		}
	
	    public NamespaceDeclarationSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.TSemicolon);
		}
	
	    public NamespaceDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KNamespace, this.QualifiedName, TSemicolon);
		}
	
	    public NamespaceDeclarationSyntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, SyntaxToken tSemicolon)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.NamespaceDeclaration(kNamespace, qualifiedName, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration(this);
	    }
	}
	
	public sealed class GeneratorDeclarationSyntax : TestLexerModeSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private QualifiedNameSyntax qualifiedName;
	    private TypeReferenceSyntax typeReference;
	
	    public GeneratorDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GeneratorDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KGenerator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.GeneratorDeclarationGreen)this.Green;
				var greenToken = green.KGenerator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.GeneratorDeclarationGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 3); } 
		}
	    public SyntaxToken KFor 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.GeneratorDeclarationGreen)this.Green;
				var greenToken = green.KFor;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 5); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.GeneratorDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.identifier, 1);
				case 3: return this.GetRed(ref this.qualifiedName, 3);
				case 5: return this.GetRed(ref this.typeReference, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.identifier;
				case 3: return this.qualifiedName;
				case 5: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public GeneratorDeclarationSyntax WithKGenerator(SyntaxToken kGenerator)
		{
			return this.Update(KGenerator, this.Identifier, this.TColon, this.QualifiedName, this.KFor, this.TypeReference, this.TSemicolon);
		}
	
	    public GeneratorDeclarationSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.KGenerator, Identifier, this.TColon, this.QualifiedName, this.KFor, this.TypeReference, this.TSemicolon);
		}
	
	    public GeneratorDeclarationSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KGenerator, this.Identifier, TColon, this.QualifiedName, this.KFor, this.TypeReference, this.TSemicolon);
		}
	
	    public GeneratorDeclarationSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KGenerator, this.Identifier, this.TColon, QualifiedName, this.KFor, this.TypeReference, this.TSemicolon);
		}
	
	    public GeneratorDeclarationSyntax WithKFor(SyntaxToken kFor)
		{
			return this.Update(this.KGenerator, this.Identifier, this.TColon, this.QualifiedName, KFor, this.TypeReference, this.TSemicolon);
		}
	
	    public GeneratorDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KGenerator, this.Identifier, this.TColon, this.QualifiedName, this.KFor, TypeReference, this.TSemicolon);
		}
	
	    public GeneratorDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KGenerator, this.Identifier, this.TColon, this.QualifiedName, this.KFor, this.TypeReference, TSemicolon);
		}
	
	    public GeneratorDeclarationSyntax Update(SyntaxToken kGenerator, IdentifierSyntax identifier, SyntaxToken tColon, QualifiedNameSyntax qualifiedName, SyntaxToken kFor, TypeReferenceSyntax typeReference, SyntaxToken tSemicolon)
	    {
	        if (this.KGenerator != kGenerator ||
				this.Identifier != identifier ||
				this.TColon != tColon ||
				this.QualifiedName != qualifiedName ||
				this.KFor != kFor ||
				this.TypeReference != typeReference ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.GeneratorDeclaration(kGenerator, identifier, tColon, qualifiedName, kFor, typeReference, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GeneratorDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGeneratorDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGeneratorDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitGeneratorDeclaration(this);
	    }
	}
	
	public abstract class UsingDeclarationSyntax : TestLexerModeSyntaxNode
	{
	    protected UsingDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected UsingDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class UsingNamespaceDeclarationSyntax : UsingDeclarationSyntax
	{
	    private QualifiedNameSyntax qualifiedName;
	
	    public UsingNamespaceDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UsingNamespaceDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KUsing 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.UsingNamespaceDeclarationGreen)this.Green;
				var greenToken = green.KUsing;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.UsingNamespaceDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				default: return null;
	        }
	    }
	
	    public UsingNamespaceDeclarationSyntax WithKUsing(SyntaxToken kUsing)
		{
			return this.Update(KUsing, this.QualifiedName, this.TSemicolon);
		}
	
	    public UsingNamespaceDeclarationSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KUsing, QualifiedName, this.TSemicolon);
		}
	
	    public UsingNamespaceDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KUsing, this.QualifiedName, TSemicolon);
		}
	
	    public UsingNamespaceDeclarationSyntax Update(SyntaxToken kUsing, QualifiedNameSyntax qualifiedName, SyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.QualifiedName != qualifiedName ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.UsingNamespaceDeclaration(kUsing, qualifiedName, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingNamespaceDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUsingNamespaceDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUsingNamespaceDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitUsingNamespaceDeclaration(this);
	    }
	}
	
	public sealed class UsingGeneratorDeclarationSyntax : UsingDeclarationSyntax
	{
	    private QualifiedNameSyntax qualifiedName;
	    private IdentifierSyntax identifier;
	
	    public UsingGeneratorDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UsingGeneratorDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KUsing 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.UsingGeneratorDeclarationGreen)this.Green;
				var greenToken = green.KUsing;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KGenerator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.UsingGeneratorDeclarationGreen)this.Green;
				var greenToken = green.KGenerator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 2); } 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.UsingGeneratorDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.qualifiedName, 2);
				case 3: return this.GetRed(ref this.identifier, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.qualifiedName;
				case 3: return this.identifier;
				default: return null;
	        }
	    }
	
	    public UsingGeneratorDeclarationSyntax WithKUsing(SyntaxToken kUsing)
		{
			return this.Update(KUsing, this.KGenerator, this.QualifiedName, this.Identifier, this.TSemicolon);
		}
	
	    public UsingGeneratorDeclarationSyntax WithKGenerator(SyntaxToken kGenerator)
		{
			return this.Update(this.KUsing, KGenerator, this.QualifiedName, this.Identifier, this.TSemicolon);
		}
	
	    public UsingGeneratorDeclarationSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KUsing, this.KGenerator, QualifiedName, this.Identifier, this.TSemicolon);
		}
	
	    public UsingGeneratorDeclarationSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.KUsing, this.KGenerator, this.QualifiedName, Identifier, this.TSemicolon);
		}
	
	    public UsingGeneratorDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KUsing, this.KGenerator, this.QualifiedName, this.Identifier, TSemicolon);
		}
	
	    public UsingGeneratorDeclarationSyntax Update(SyntaxToken kUsing, SyntaxToken kGenerator, QualifiedNameSyntax qualifiedName, IdentifierSyntax identifier, SyntaxToken tSemicolon)
	    {
	        if (this.KUsing != kUsing ||
				this.KGenerator != kGenerator ||
				this.QualifiedName != qualifiedName ||
				this.Identifier != identifier ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.UsingGeneratorDeclaration(kUsing, kGenerator, qualifiedName, identifier, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UsingGeneratorDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUsingGeneratorDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUsingGeneratorDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitUsingGeneratorDeclaration(this);
	    }
	}
	
	public sealed class ConfigDeclarationSyntax : TestLexerModeSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private SyntaxNode configProperty;
	
	    public ConfigDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ConfigDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken StartProperties 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConfigDeclarationGreen)this.Green;
				var greenToken = green.StartProperties;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	    public SyntaxList<ConfigPropertySyntax> ConfigProperty 
		{ 
			get
			{
				var red = this.GetRed(ref this.configProperty, 2);
				if (red != null) return new SyntaxList<ConfigPropertySyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConfigDeclarationGreen)this.Green;
				var greenToken = green.KEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public SyntaxToken EndProperties 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConfigDeclarationGreen)this.Green;
				var greenToken = green.EndProperties;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.identifier, 1);
				case 2: return this.GetRed(ref this.configProperty, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.identifier;
				case 2: return this.configProperty;
				default: return null;
	        }
	    }
	
	    public ConfigDeclarationSyntax WithStartProperties(SyntaxToken startProperties)
		{
			return this.Update(StartProperties, this.Identifier, this.ConfigProperty, this.KEnd, this.EndProperties);
		}
	
	    public ConfigDeclarationSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.StartProperties, Identifier, this.ConfigProperty, this.KEnd, this.EndProperties);
		}
	
	    public ConfigDeclarationSyntax WithConfigProperty(SyntaxList<ConfigPropertySyntax> configProperty)
		{
			return this.Update(this.StartProperties, this.Identifier, ConfigProperty, this.KEnd, this.EndProperties);
		}
	
	    public ConfigDeclarationSyntax AddConfigProperty(params ConfigPropertySyntax[] configProperty)
		{
			return this.WithConfigProperty(this.ConfigProperty.AddRange(configProperty));
		}
	
	    public ConfigDeclarationSyntax WithKEnd(SyntaxToken kEnd)
		{
			return this.Update(this.StartProperties, this.Identifier, this.ConfigProperty, KEnd, this.EndProperties);
		}
	
	    public ConfigDeclarationSyntax WithEndProperties(SyntaxToken endProperties)
		{
			return this.Update(this.StartProperties, this.Identifier, this.ConfigProperty, this.KEnd, EndProperties);
		}
	
	    public ConfigDeclarationSyntax Update(SyntaxToken startProperties, IdentifierSyntax identifier, SyntaxList<ConfigPropertySyntax> configProperty, SyntaxToken kEnd, SyntaxToken endProperties)
	    {
	        if (this.StartProperties != startProperties ||
				this.Identifier != identifier ||
				this.ConfigProperty != configProperty ||
				this.KEnd != kEnd ||
				this.EndProperties != endProperties)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ConfigDeclaration(startProperties, identifier, configProperty, kEnd, endProperties);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConfigDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitConfigDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitConfigDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitConfigDeclaration(this);
	    }
	}
	
	public abstract class ConfigPropertySyntax : TestLexerModeSyntaxNode
	{
	    protected ConfigPropertySyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected ConfigPropertySyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class ConfigPropertyDeclarationSyntax : ConfigPropertySyntax
	{
	    private TypeReferenceSyntax typeReference;
	    private IdentifierSyntax identifier;
	    private ExpressionSyntax expression;
	
	    public ConfigPropertyDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ConfigPropertyDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConfigPropertyDeclarationGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConfigPropertyDeclarationGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				case 1: return this.GetRed(ref this.identifier, 1);
				case 3: return this.GetRed(ref this.expression, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				case 1: return this.identifier;
				case 3: return this.expression;
				default: return null;
	        }
	    }
	
	    public ConfigPropertyDeclarationSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference, this.Identifier, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public ConfigPropertyDeclarationSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.TypeReference, Identifier, this.TAssign, this.Expression, this.TSemicolon);
		}
	
	    public ConfigPropertyDeclarationSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.TypeReference, this.Identifier, TAssign, this.Expression, this.TSemicolon);
		}
	
	    public ConfigPropertyDeclarationSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.TypeReference, this.Identifier, this.TAssign, Expression, this.TSemicolon);
		}
	
	    public ConfigPropertyDeclarationSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.TypeReference, this.Identifier, this.TAssign, this.Expression, TSemicolon);
		}
	
	    public ConfigPropertyDeclarationSyntax Update(TypeReferenceSyntax typeReference, IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression, SyntaxToken tSemicolon)
	    {
	        if (this.TypeReference != typeReference ||
				this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.Expression != expression ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ConfigPropertyDeclaration(typeReference, identifier, tAssign, expression, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConfigPropertyDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitConfigPropertyDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitConfigPropertyDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitConfigPropertyDeclaration(this);
	    }
	}
	
	public sealed class ConfigPropertyGroupDeclarationSyntax : ConfigPropertySyntax
	{
	    private IdentifierSyntax identifier;
	    private SyntaxNode configProperty;
	
	    public ConfigPropertyGroupDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ConfigPropertyGroupDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken StartProperties 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConfigPropertyGroupDeclarationGreen)this.Green;
				var greenToken = green.StartProperties;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	    public SyntaxList<ConfigPropertySyntax> ConfigProperty 
		{ 
			get
			{
				var red = this.GetRed(ref this.configProperty, 2);
				if (red != null) return new SyntaxList<ConfigPropertySyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken KEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConfigPropertyGroupDeclarationGreen)this.Green;
				var greenToken = green.KEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public SyntaxToken EndProperties 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConfigPropertyGroupDeclarationGreen)this.Green;
				var greenToken = green.EndProperties;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.identifier, 1);
				case 2: return this.GetRed(ref this.configProperty, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.identifier;
				case 2: return this.configProperty;
				default: return null;
	        }
	    }
	
	    public ConfigPropertyGroupDeclarationSyntax WithStartProperties(SyntaxToken startProperties)
		{
			return this.Update(StartProperties, this.Identifier, this.ConfigProperty, this.KEnd, this.EndProperties);
		}
	
	    public ConfigPropertyGroupDeclarationSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.StartProperties, Identifier, this.ConfigProperty, this.KEnd, this.EndProperties);
		}
	
	    public ConfigPropertyGroupDeclarationSyntax WithConfigProperty(SyntaxList<ConfigPropertySyntax> configProperty)
		{
			return this.Update(this.StartProperties, this.Identifier, ConfigProperty, this.KEnd, this.EndProperties);
		}
	
	    public ConfigPropertyGroupDeclarationSyntax AddConfigProperty(params ConfigPropertySyntax[] configProperty)
		{
			return this.WithConfigProperty(this.ConfigProperty.AddRange(configProperty));
		}
	
	    public ConfigPropertyGroupDeclarationSyntax WithKEnd(SyntaxToken kEnd)
		{
			return this.Update(this.StartProperties, this.Identifier, this.ConfigProperty, KEnd, this.EndProperties);
		}
	
	    public ConfigPropertyGroupDeclarationSyntax WithEndProperties(SyntaxToken endProperties)
		{
			return this.Update(this.StartProperties, this.Identifier, this.ConfigProperty, this.KEnd, EndProperties);
		}
	
	    public ConfigPropertyGroupDeclarationSyntax Update(SyntaxToken startProperties, IdentifierSyntax identifier, SyntaxList<ConfigPropertySyntax> configProperty, SyntaxToken kEnd, SyntaxToken endProperties)
	    {
	        if (this.StartProperties != startProperties ||
				this.Identifier != identifier ||
				this.ConfigProperty != configProperty ||
				this.KEnd != kEnd ||
				this.EndProperties != endProperties)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ConfigPropertyGroupDeclaration(startProperties, identifier, configProperty, kEnd, endProperties);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConfigPropertyGroupDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitConfigPropertyGroupDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitConfigPropertyGroupDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitConfigPropertyGroupDeclaration(this);
	    }
	}
	
	public sealed class MethodDeclarationSyntax : TestLexerModeSyntaxNode
	{
	    private FunctionDeclarationSyntax functionDeclaration;
	    private TemplateDeclarationSyntax templateDeclaration;
	    private ExternFunctionDeclarationSyntax externFunctionDeclaration;
	
	    public MethodDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MethodDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public FunctionDeclarationSyntax FunctionDeclaration 
		{ 
			get { return this.GetRed(ref this.functionDeclaration, 0); } 
		}
	    public TemplateDeclarationSyntax TemplateDeclaration 
		{ 
			get { return this.GetRed(ref this.templateDeclaration, 1); } 
		}
	    public ExternFunctionDeclarationSyntax ExternFunctionDeclaration 
		{ 
			get { return this.GetRed(ref this.externFunctionDeclaration, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.functionDeclaration, 0);
				case 1: return this.GetRed(ref this.templateDeclaration, 1);
				case 2: return this.GetRed(ref this.externFunctionDeclaration, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.functionDeclaration;
				case 1: return this.templateDeclaration;
				case 2: return this.externFunctionDeclaration;
				default: return null;
	        }
	    }
	
	    public MethodDeclarationSyntax WithFunctionDeclaration(FunctionDeclarationSyntax functionDeclaration)
		{
			return this.Update(functionDeclaration);
		}
	
	    public MethodDeclarationSyntax WithTemplateDeclaration(TemplateDeclarationSyntax templateDeclaration)
		{
			return this.Update(templateDeclaration);
		}
	
	    public MethodDeclarationSyntax WithExternFunctionDeclaration(ExternFunctionDeclarationSyntax externFunctionDeclaration)
		{
			return this.Update(externFunctionDeclaration);
		}
	
	    public MethodDeclarationSyntax Update(FunctionDeclarationSyntax functionDeclaration)
	    {
	        if (this.FunctionDeclaration != functionDeclaration)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.MethodDeclaration(functionDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MethodDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public MethodDeclarationSyntax Update(TemplateDeclarationSyntax templateDeclaration)
	    {
	        if (this.TemplateDeclaration != templateDeclaration)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.MethodDeclaration(templateDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MethodDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public MethodDeclarationSyntax Update(ExternFunctionDeclarationSyntax externFunctionDeclaration)
	    {
	        if (this.ExternFunctionDeclaration != externFunctionDeclaration)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.MethodDeclaration(externFunctionDeclaration);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MethodDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMethodDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMethodDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitMethodDeclaration(this);
	    }
	}
	
	public sealed class ExternFunctionDeclarationSyntax : TestLexerModeSyntaxNode
	{
	    private FunctionSignatureSyntax functionSignature;
	
	    public ExternFunctionDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ExternFunctionDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KExtern 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ExternFunctionDeclarationGreen)this.Green;
				var greenToken = green.KExtern;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public FunctionSignatureSyntax FunctionSignature 
		{ 
			get { return this.GetRed(ref this.functionSignature, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.functionSignature, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.functionSignature;
				default: return null;
	        }
	    }
	
	    public ExternFunctionDeclarationSyntax WithKExtern(SyntaxToken kExtern)
		{
			return this.Update(KExtern, this.FunctionSignature);
		}
	
	    public ExternFunctionDeclarationSyntax WithFunctionSignature(FunctionSignatureSyntax functionSignature)
		{
			return this.Update(this.KExtern, FunctionSignature);
		}
	
	    public ExternFunctionDeclarationSyntax Update(SyntaxToken kExtern, FunctionSignatureSyntax functionSignature)
	    {
	        if (this.KExtern != kExtern ||
				this.FunctionSignature != functionSignature)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ExternFunctionDeclaration(kExtern, functionSignature);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExternFunctionDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitExternFunctionDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitExternFunctionDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitExternFunctionDeclaration(this);
	    }
	}
	
	public sealed class FunctionDeclarationSyntax : TestLexerModeSyntaxNode
	{
	    private FunctionSignatureSyntax functionSignature;
	    private BodySyntax body;
	
	    public FunctionDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FunctionDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public FunctionSignatureSyntax FunctionSignature 
		{ 
			get { return this.GetRed(ref this.functionSignature, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	    public SyntaxToken KEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.FunctionDeclarationGreen)this.Green;
				var greenToken = green.KEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public SyntaxToken KFunction 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.FunctionDeclarationGreen)this.Green;
				var greenToken = green.KFunction;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.functionSignature, 0);
				case 1: return this.GetRed(ref this.body, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.functionSignature;
				case 1: return this.body;
				default: return null;
	        }
	    }
	
	    public FunctionDeclarationSyntax WithFunctionSignature(FunctionSignatureSyntax functionSignature)
		{
			return this.Update(FunctionSignature, this.Body, this.KEnd, this.KFunction);
		}
	
	    public FunctionDeclarationSyntax WithBody(BodySyntax body)
		{
			return this.Update(this.FunctionSignature, Body, this.KEnd, this.KFunction);
		}
	
	    public FunctionDeclarationSyntax WithKEnd(SyntaxToken kEnd)
		{
			return this.Update(this.FunctionSignature, this.Body, KEnd, this.KFunction);
		}
	
	    public FunctionDeclarationSyntax WithKFunction(SyntaxToken kFunction)
		{
			return this.Update(this.FunctionSignature, this.Body, this.KEnd, KFunction);
		}
	
	    public FunctionDeclarationSyntax Update(FunctionSignatureSyntax functionSignature, BodySyntax body, SyntaxToken kEnd, SyntaxToken kFunction)
	    {
	        if (this.FunctionSignature != functionSignature ||
				this.Body != body ||
				this.KEnd != kEnd ||
				this.KFunction != kFunction)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.FunctionDeclaration(functionSignature, body, kEnd, kFunction);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFunctionDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFunctionDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitFunctionDeclaration(this);
	    }
	}
	
	public sealed class FunctionSignatureSyntax : TestLexerModeSyntaxNode
	{
	    private ReturnTypeSyntax returnType;
	    private IdentifierSyntax identifier;
	    private TypeArgumentListSyntax typeArgumentList;
	    private ParamListSyntax paramList;
	
	    public FunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KFunction 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.FunctionSignatureGreen)this.Green;
				var greenToken = green.KFunction;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ReturnTypeSyntax ReturnType 
		{ 
			get { return this.GetRed(ref this.returnType, 1); } 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 2); } 
		}
	    public TypeArgumentListSyntax TypeArgumentList 
		{ 
			get { return this.GetRed(ref this.typeArgumentList, 3); } 
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.FunctionSignatureGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	    public ParamListSyntax ParamList 
		{ 
			get { return this.GetRed(ref this.paramList, 5); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.FunctionSignatureGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(6), this.GetChildIndex(6));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.returnType, 1);
				case 2: return this.GetRed(ref this.identifier, 2);
				case 3: return this.GetRed(ref this.typeArgumentList, 3);
				case 5: return this.GetRed(ref this.paramList, 5);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.returnType;
				case 2: return this.identifier;
				case 3: return this.typeArgumentList;
				case 5: return this.paramList;
				default: return null;
	        }
	    }
	
	    public FunctionSignatureSyntax WithKFunction(SyntaxToken kFunction)
		{
			return this.Update(KFunction, this.ReturnType, this.Identifier, this.TypeArgumentList, this.TOpenParenthesis, this.ParamList, this.TCloseParenthesis);
		}
	
	    public FunctionSignatureSyntax WithReturnType(ReturnTypeSyntax returnType)
		{
			return this.Update(this.KFunction, ReturnType, this.Identifier, this.TypeArgumentList, this.TOpenParenthesis, this.ParamList, this.TCloseParenthesis);
		}
	
	    public FunctionSignatureSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.KFunction, this.ReturnType, Identifier, this.TypeArgumentList, this.TOpenParenthesis, this.ParamList, this.TCloseParenthesis);
		}
	
	    public FunctionSignatureSyntax WithTypeArgumentList(TypeArgumentListSyntax typeArgumentList)
		{
			return this.Update(this.KFunction, this.ReturnType, this.Identifier, TypeArgumentList, this.TOpenParenthesis, this.ParamList, this.TCloseParenthesis);
		}
	
	    public FunctionSignatureSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KFunction, this.ReturnType, this.Identifier, this.TypeArgumentList, TOpenParenthesis, this.ParamList, this.TCloseParenthesis);
		}
	
	    public FunctionSignatureSyntax WithParamList(ParamListSyntax paramList)
		{
			return this.Update(this.KFunction, this.ReturnType, this.Identifier, this.TypeArgumentList, this.TOpenParenthesis, ParamList, this.TCloseParenthesis);
		}
	
	    public FunctionSignatureSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KFunction, this.ReturnType, this.Identifier, this.TypeArgumentList, this.TOpenParenthesis, this.ParamList, TCloseParenthesis);
		}
	
	    public FunctionSignatureSyntax Update(SyntaxToken kFunction, ReturnTypeSyntax returnType, IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList, SyntaxToken tOpenParenthesis, ParamListSyntax paramList, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KFunction != kFunction ||
				this.ReturnType != returnType ||
				this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ParamList != paramList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.FunctionSignature(kFunction, returnType, identifier, typeArgumentList, tOpenParenthesis, paramList, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionSignatureSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFunctionSignature(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFunctionSignature(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitFunctionSignature(this);
	    }
	}
	
	public sealed class ParamListSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode parameter;
	
	    public ParamListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParamListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	
	    public ParamListSyntax WithParameter(SeparatedSyntaxList<ParameterSyntax> parameter)
		{
			return this.Update(Parameter);
		}
	
	    public ParamListSyntax AddParameter(params ParameterSyntax[] parameter)
		{
			return this.WithParameter(this.Parameter.AddRange(parameter));
		}
	
	    public ParamListSyntax Update(SeparatedSyntaxList<ParameterSyntax> parameter)
	    {
	        if (this.Parameter != parameter)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ParamList(parameter);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParamListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParamList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParamList(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitParamList(this);
	    }
	}
	
	public sealed class ParameterSyntax : TestLexerModeSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private IdentifierSyntax identifier;
	    private ExpressionSyntax expression;
	
	    public ParameterSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParameterSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ParameterGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				case 1: return this.GetRed(ref this.identifier, 1);
				case 3: return this.GetRed(ref this.expression, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				case 1: return this.identifier;
				case 3: return this.expression;
				default: return null;
	        }
	    }
	
	    public ParameterSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference, this.Identifier, this.TAssign, this.Expression);
		}
	
	    public ParameterSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.TypeReference, Identifier, this.TAssign, this.Expression);
		}
	
	    public ParameterSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.TypeReference, this.Identifier, TAssign, this.Expression);
		}
	
	    public ParameterSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.TypeReference, this.Identifier, this.TAssign, Expression);
		}
	
	    public ParameterSyntax Update(TypeReferenceSyntax typeReference, IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression)
	    {
	        if (this.TypeReference != typeReference ||
				this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Parameter(typeReference, identifier, tAssign, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParameterSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParameter(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParameter(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitParameter(this);
	    }
	}
	
	public sealed class BodySyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode statement;
	
	    public BodySyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BodySyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	
	    public BodySyntax WithStatement(SyntaxList<StatementSyntax> statement)
		{
			return this.Update(Statement);
		}
	
	    public BodySyntax AddStatement(params StatementSyntax[] statement)
		{
			return this.WithStatement(this.Statement.AddRange(statement));
		}
	
	    public BodySyntax Update(SyntaxList<StatementSyntax> statement)
	    {
	        if (this.Statement != statement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Body(statement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBody(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitBody(this);
	    }
	}
	
	public sealed class StatementSyntax : TestLexerModeSyntaxNode
	{
	    private SingleStatementSemicolonSyntax singleStatementSemicolon;
	    private IfStatementSyntax ifStatement;
	    private ForStatementSyntax forStatement;
	    private WhileStatementSyntax whileStatement;
	    private RepeatStatementSyntax repeatStatement;
	    private LoopStatementSyntax loopStatement;
	    private SwitchStatementSyntax switchStatement;
	
	    public StatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SingleStatementSemicolonSyntax SingleStatementSemicolon 
		{ 
			get { return this.GetRed(ref this.singleStatementSemicolon, 0); } 
		}
	    public IfStatementSyntax IfStatement 
		{ 
			get { return this.GetRed(ref this.ifStatement, 1); } 
		}
	    public ForStatementSyntax ForStatement 
		{ 
			get { return this.GetRed(ref this.forStatement, 2); } 
		}
	    public WhileStatementSyntax WhileStatement 
		{ 
			get { return this.GetRed(ref this.whileStatement, 3); } 
		}
	    public RepeatStatementSyntax RepeatStatement 
		{ 
			get { return this.GetRed(ref this.repeatStatement, 4); } 
		}
	    public LoopStatementSyntax LoopStatement 
		{ 
			get { return this.GetRed(ref this.loopStatement, 5); } 
		}
	    public SwitchStatementSyntax SwitchStatement 
		{ 
			get { return this.GetRed(ref this.switchStatement, 6); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.singleStatementSemicolon, 0);
				case 1: return this.GetRed(ref this.ifStatement, 1);
				case 2: return this.GetRed(ref this.forStatement, 2);
				case 3: return this.GetRed(ref this.whileStatement, 3);
				case 4: return this.GetRed(ref this.repeatStatement, 4);
				case 5: return this.GetRed(ref this.loopStatement, 5);
				case 6: return this.GetRed(ref this.switchStatement, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.singleStatementSemicolon;
				case 1: return this.ifStatement;
				case 2: return this.forStatement;
				case 3: return this.whileStatement;
				case 4: return this.repeatStatement;
				case 5: return this.loopStatement;
				case 6: return this.switchStatement;
				default: return null;
	        }
	    }
	
	    public StatementSyntax WithSingleStatementSemicolon(SingleStatementSemicolonSyntax singleStatementSemicolon)
		{
			return this.Update(singleStatementSemicolon);
		}
	
	    public StatementSyntax WithIfStatement(IfStatementSyntax ifStatement)
		{
			return this.Update(ifStatement);
		}
	
	    public StatementSyntax WithForStatement(ForStatementSyntax forStatement)
		{
			return this.Update(forStatement);
		}
	
	    public StatementSyntax WithWhileStatement(WhileStatementSyntax whileStatement)
		{
			return this.Update(whileStatement);
		}
	
	    public StatementSyntax WithRepeatStatement(RepeatStatementSyntax repeatStatement)
		{
			return this.Update(repeatStatement);
		}
	
	    public StatementSyntax WithLoopStatement(LoopStatementSyntax loopStatement)
		{
			return this.Update(loopStatement);
		}
	
	    public StatementSyntax WithSwitchStatement(SwitchStatementSyntax switchStatement)
		{
			return this.Update(switchStatement);
		}
	
	    public StatementSyntax Update(SingleStatementSemicolonSyntax singleStatementSemicolon)
	    {
	        if (this.SingleStatementSemicolon != singleStatementSemicolon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Statement(singleStatementSemicolon);
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Statement(ifStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(ForStatementSyntax forStatement)
	    {
	        if (this.ForStatement != forStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Statement(forStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(WhileStatementSyntax whileStatement)
	    {
	        if (this.WhileStatement != whileStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Statement(whileStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(RepeatStatementSyntax repeatStatement)
	    {
	        if (this.RepeatStatement != repeatStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Statement(repeatStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(LoopStatementSyntax loopStatement)
	    {
	        if (this.LoopStatement != loopStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Statement(loopStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public StatementSyntax Update(SwitchStatementSyntax switchStatement)
	    {
	        if (this.SwitchStatement != switchStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Statement(switchStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitStatement(this);
	    }
	}
	
	public sealed class SingleStatementSyntax : TestLexerModeSyntaxNode
	{
	    private VariableDeclarationStatementSyntax variableDeclarationStatement;
	    private ReturnStatementSyntax returnStatement;
	    private ExpressionStatementSyntax expressionStatement;
	
	    public SingleStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SingleStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VariableDeclarationStatementSyntax VariableDeclarationStatement 
		{ 
			get { return this.GetRed(ref this.variableDeclarationStatement, 0); } 
		}
	    public ReturnStatementSyntax ReturnStatement 
		{ 
			get { return this.GetRed(ref this.returnStatement, 1); } 
		}
	    public ExpressionStatementSyntax ExpressionStatement 
		{ 
			get { return this.GetRed(ref this.expressionStatement, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableDeclarationStatement, 0);
				case 1: return this.GetRed(ref this.returnStatement, 1);
				case 2: return this.GetRed(ref this.expressionStatement, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableDeclarationStatement;
				case 1: return this.returnStatement;
				case 2: return this.expressionStatement;
				default: return null;
	        }
	    }
	
	    public SingleStatementSyntax WithVariableDeclarationStatement(VariableDeclarationStatementSyntax variableDeclarationStatement)
		{
			return this.Update(variableDeclarationStatement);
		}
	
	    public SingleStatementSyntax WithReturnStatement(ReturnStatementSyntax returnStatement)
		{
			return this.Update(returnStatement);
		}
	
	    public SingleStatementSyntax WithExpressionStatement(ExpressionStatementSyntax expressionStatement)
		{
			return this.Update(expressionStatement);
		}
	
	    public SingleStatementSyntax Update(VariableDeclarationStatementSyntax variableDeclarationStatement)
	    {
	        if (this.VariableDeclarationStatement != variableDeclarationStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SingleStatement(variableDeclarationStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SingleStatementSyntax Update(ReturnStatementSyntax returnStatement)
	    {
	        if (this.ReturnStatement != returnStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SingleStatement(returnStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SingleStatementSyntax Update(ExpressionStatementSyntax expressionStatement)
	    {
	        if (this.ExpressionStatement != expressionStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SingleStatement(expressionStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSingleStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSingleStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSingleStatement(this);
	    }
	}
	
	public sealed class SingleStatementSemicolonSyntax : TestLexerModeSyntaxNode
	{
	    private SingleStatementSyntax singleStatement;
	
	    public SingleStatementSemicolonSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SingleStatementSemicolonSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SingleStatementSyntax SingleStatement 
		{ 
			get { return this.GetRed(ref this.singleStatement, 0); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SingleStatementSemicolonGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.singleStatement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.singleStatement;
				default: return null;
	        }
	    }
	
	    public SingleStatementSemicolonSyntax WithSingleStatement(SingleStatementSyntax singleStatement)
		{
			return this.Update(SingleStatement, this.TSemicolon);
		}
	
	    public SingleStatementSemicolonSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.SingleStatement, TSemicolon);
		}
	
	    public SingleStatementSemicolonSyntax Update(SingleStatementSyntax singleStatement, SyntaxToken tSemicolon)
	    {
	        if (this.SingleStatement != singleStatement ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SingleStatementSemicolon(singleStatement, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleStatementSemicolonSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSingleStatementSemicolon(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSingleStatementSemicolon(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSingleStatementSemicolon(this);
	    }
	}
	
	public sealed class VariableDeclarationStatementSyntax : TestLexerModeSyntaxNode
	{
	    private VariableDeclarationExpressionSyntax variableDeclarationExpression;
	
	    public VariableDeclarationStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VariableDeclarationStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VariableDeclarationExpressionSyntax VariableDeclarationExpression 
		{ 
			get { return this.GetRed(ref this.variableDeclarationExpression, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableDeclarationExpression, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableDeclarationExpression;
				default: return null;
	        }
	    }
	
	    public VariableDeclarationStatementSyntax WithVariableDeclarationExpression(VariableDeclarationExpressionSyntax variableDeclarationExpression)
		{
			return this.Update(VariableDeclarationExpression);
		}
	
	    public VariableDeclarationStatementSyntax Update(VariableDeclarationExpressionSyntax variableDeclarationExpression)
	    {
	        if (this.VariableDeclarationExpression != variableDeclarationExpression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.VariableDeclarationStatement(variableDeclarationExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableDeclarationStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVariableDeclarationStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVariableDeclarationStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitVariableDeclarationStatement(this);
	    }
	}
	
	public sealed class VariableDeclarationExpressionSyntax : TestLexerModeSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private SyntaxNode variableDeclarationItem;
	
	    public VariableDeclarationExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VariableDeclarationExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public SeparatedSyntaxList<VariableDeclarationItemSyntax> VariableDeclarationItem 
		{ 
			get
			{
				var red = this.GetRed(ref this.variableDeclarationItem, 1);
				if (red != null)
				{
					return new SeparatedSyntaxList<VariableDeclarationItemSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				case 1: return this.GetRed(ref this.variableDeclarationItem, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				case 1: return this.variableDeclarationItem;
				default: return null;
	        }
	    }
	
	    public VariableDeclarationExpressionSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference, this.VariableDeclarationItem);
		}
	
	    public VariableDeclarationExpressionSyntax WithVariableDeclarationItem(SeparatedSyntaxList<VariableDeclarationItemSyntax> variableDeclarationItem)
		{
			return this.Update(this.TypeReference, VariableDeclarationItem);
		}
	
	    public VariableDeclarationExpressionSyntax AddVariableDeclarationItem(params VariableDeclarationItemSyntax[] variableDeclarationItem)
		{
			return this.WithVariableDeclarationItem(this.VariableDeclarationItem.AddRange(variableDeclarationItem));
		}
	
	    public VariableDeclarationExpressionSyntax Update(TypeReferenceSyntax typeReference, SeparatedSyntaxList<VariableDeclarationItemSyntax> variableDeclarationItem)
	    {
	        if (this.TypeReference != typeReference ||
				this.VariableDeclarationItem != variableDeclarationItem)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.VariableDeclarationExpression(typeReference, variableDeclarationItem);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableDeclarationExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVariableDeclarationExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVariableDeclarationExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitVariableDeclarationExpression(this);
	    }
	}
	
	public sealed class VariableDeclarationItemSyntax : TestLexerModeSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private ExpressionSyntax expression;
	
	    public VariableDeclarationItemSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VariableDeclarationItemSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.VariableDeclarationItemGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public VariableDeclarationItemSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier, this.TAssign, this.Expression);
		}
	
	    public VariableDeclarationItemSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.Identifier, TAssign, this.Expression);
		}
	
	    public VariableDeclarationItemSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.Identifier, this.TAssign, Expression);
		}
	
	    public VariableDeclarationItemSyntax Update(IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression)
	    {
	        if (this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.VariableDeclarationItem(identifier, tAssign, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableDeclarationItemSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVariableDeclarationItem(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVariableDeclarationItem(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitVariableDeclarationItem(this);
	    }
	}
	
	public sealed class VoidStatementSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public VoidStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VoidStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVoid 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.VoidStatementGreen)this.Green;
				var greenToken = green.KVoid;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.expression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.expression;
				default: return null;
	        }
	    }
	
	    public VoidStatementSyntax WithKVoid(SyntaxToken kVoid)
		{
			return this.Update(KVoid, this.Expression);
		}
	
	    public VoidStatementSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KVoid, Expression);
		}
	
	    public VoidStatementSyntax Update(SyntaxToken kVoid, ExpressionSyntax expression)
	    {
	        if (this.KVoid != kVoid ||
				this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.VoidStatement(kVoid, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VoidStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVoidStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVoidStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitVoidStatement(this);
	    }
	}
	
	public sealed class ReturnStatementSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public ReturnStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReturnStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KReturn 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ReturnStatementGreen)this.Green;
				var greenToken = green.KReturn;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.expression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.expression;
				default: return null;
	        }
	    }
	
	    public ReturnStatementSyntax WithKReturn(SyntaxToken kReturn)
		{
			return this.Update(KReturn, this.Expression);
		}
	
	    public ReturnStatementSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KReturn, Expression);
		}
	
	    public ReturnStatementSyntax Update(SyntaxToken kReturn, ExpressionSyntax expression)
	    {
	        if (this.KReturn != kReturn ||
				this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ReturnStatement(kReturn, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitReturnStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReturnStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitReturnStatement(this);
	    }
	}
	
	public sealed class ExpressionStatementSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public ExpressionStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ExpressionStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
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
	
	    public ExpressionStatementSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression);
		}
	
	    public ExpressionStatementSyntax Update(ExpressionSyntax expression)
	    {
	        if (this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ExpressionStatement(expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitExpressionStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitExpressionStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitExpressionStatement(this);
	    }
	}
	
	public sealed class IfStatementSyntax : TestLexerModeSyntaxNode
	{
	    private IfStatementBeginSyntax ifStatementBegin;
	    private BodySyntax body;
	    private SyntaxNode elseIfStatementBody;
	    private IfStatementElseBodySyntax ifStatementElseBody;
	    private IfStatementEndSyntax ifStatementEnd;
	
	    public IfStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IfStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IfStatementBeginSyntax IfStatementBegin 
		{ 
			get { return this.GetRed(ref this.ifStatementBegin, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	    public SyntaxList<ElseIfStatementBodySyntax> ElseIfStatementBody 
		{ 
			get
			{
				var red = this.GetRed(ref this.elseIfStatementBody, 2);
				if (red != null) return new SyntaxList<ElseIfStatementBodySyntax>(red);
				return default;
			} 
		}
	    public IfStatementElseBodySyntax IfStatementElseBody 
		{ 
			get { return this.GetRed(ref this.ifStatementElseBody, 3); } 
		}
	    public IfStatementEndSyntax IfStatementEnd 
		{ 
			get { return this.GetRed(ref this.ifStatementEnd, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.ifStatementBegin, 0);
				case 1: return this.GetRed(ref this.body, 1);
				case 2: return this.GetRed(ref this.elseIfStatementBody, 2);
				case 3: return this.GetRed(ref this.ifStatementElseBody, 3);
				case 4: return this.GetRed(ref this.ifStatementEnd, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.ifStatementBegin;
				case 1: return this.body;
				case 2: return this.elseIfStatementBody;
				case 3: return this.ifStatementElseBody;
				case 4: return this.ifStatementEnd;
				default: return null;
	        }
	    }
	
	    public IfStatementSyntax WithIfStatementBegin(IfStatementBeginSyntax ifStatementBegin)
		{
			return this.Update(IfStatementBegin, this.Body, this.ElseIfStatementBody, this.IfStatementElseBody, this.IfStatementEnd);
		}
	
	    public IfStatementSyntax WithBody(BodySyntax body)
		{
			return this.Update(this.IfStatementBegin, Body, this.ElseIfStatementBody, this.IfStatementElseBody, this.IfStatementEnd);
		}
	
	    public IfStatementSyntax WithElseIfStatementBody(SyntaxList<ElseIfStatementBodySyntax> elseIfStatementBody)
		{
			return this.Update(this.IfStatementBegin, this.Body, ElseIfStatementBody, this.IfStatementElseBody, this.IfStatementEnd);
		}
	
	    public IfStatementSyntax AddElseIfStatementBody(params ElseIfStatementBodySyntax[] elseIfStatementBody)
		{
			return this.WithElseIfStatementBody(this.ElseIfStatementBody.AddRange(elseIfStatementBody));
		}
	
	    public IfStatementSyntax WithIfStatementElseBody(IfStatementElseBodySyntax ifStatementElseBody)
		{
			return this.Update(this.IfStatementBegin, this.Body, this.ElseIfStatementBody, IfStatementElseBody, this.IfStatementEnd);
		}
	
	    public IfStatementSyntax WithIfStatementEnd(IfStatementEndSyntax ifStatementEnd)
		{
			return this.Update(this.IfStatementBegin, this.Body, this.ElseIfStatementBody, this.IfStatementElseBody, IfStatementEnd);
		}
	
	    public IfStatementSyntax Update(IfStatementBeginSyntax ifStatementBegin, BodySyntax body, SyntaxList<ElseIfStatementBodySyntax> elseIfStatementBody, IfStatementElseBodySyntax ifStatementElseBody, IfStatementEndSyntax ifStatementEnd)
	    {
	        if (this.IfStatementBegin != ifStatementBegin ||
				this.Body != body ||
				this.ElseIfStatementBody != elseIfStatementBody ||
				this.IfStatementElseBody != ifStatementElseBody ||
				this.IfStatementEnd != ifStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.IfStatement(ifStatementBegin, body, elseIfStatementBody, ifStatementElseBody, ifStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIfStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIfStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitIfStatement(this);
	    }
	}
	
	public sealed class ElseIfStatementBodySyntax : TestLexerModeSyntaxNode
	{
	    private ElseIfStatementSyntax elseIfStatement;
	    private BodySyntax body;
	
	    public ElseIfStatementBodySyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElseIfStatementBodySyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ElseIfStatementSyntax ElseIfStatement 
		{ 
			get { return this.GetRed(ref this.elseIfStatement, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.elseIfStatement, 0);
				case 1: return this.GetRed(ref this.body, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.elseIfStatement;
				case 1: return this.body;
				default: return null;
	        }
	    }
	
	    public ElseIfStatementBodySyntax WithElseIfStatement(ElseIfStatementSyntax elseIfStatement)
		{
			return this.Update(ElseIfStatement, this.Body);
		}
	
	    public ElseIfStatementBodySyntax WithBody(BodySyntax body)
		{
			return this.Update(this.ElseIfStatement, Body);
		}
	
	    public ElseIfStatementBodySyntax Update(ElseIfStatementSyntax elseIfStatement, BodySyntax body)
	    {
	        if (this.ElseIfStatement != elseIfStatement ||
				this.Body != body)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ElseIfStatementBody(elseIfStatement, body);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseIfStatementBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElseIfStatementBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElseIfStatementBody(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitElseIfStatementBody(this);
	    }
	}
	
	public sealed class IfStatementElseBodySyntax : TestLexerModeSyntaxNode
	{
	    private IfStatementElseSyntax ifStatementElse;
	    private BodySyntax body;
	
	    public IfStatementElseBodySyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IfStatementElseBodySyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IfStatementElseSyntax IfStatementElse 
		{ 
			get { return this.GetRed(ref this.ifStatementElse, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.ifStatementElse, 0);
				case 1: return this.GetRed(ref this.body, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.ifStatementElse;
				case 1: return this.body;
				default: return null;
	        }
	    }
	
	    public IfStatementElseBodySyntax WithIfStatementElse(IfStatementElseSyntax ifStatementElse)
		{
			return this.Update(IfStatementElse, this.Body);
		}
	
	    public IfStatementElseBodySyntax WithBody(BodySyntax body)
		{
			return this.Update(this.IfStatementElse, Body);
		}
	
	    public IfStatementElseBodySyntax Update(IfStatementElseSyntax ifStatementElse, BodySyntax body)
	    {
	        if (this.IfStatementElse != ifStatementElse ||
				this.Body != body)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.IfStatementElseBody(ifStatementElse, body);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementElseBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIfStatementElseBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIfStatementElseBody(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitIfStatementElseBody(this);
	    }
	}
	
	public sealed class IfStatementBeginSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public IfStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IfStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KIf 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.IfStatementBeginGreen)this.Green;
				var greenToken = green.KIf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.IfStatementBeginGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.IfStatementBeginGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public IfStatementBeginSyntax WithKIf(SyntaxToken kIf)
		{
			return this.Update(KIf, this.TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public IfStatementBeginSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KIf, TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public IfStatementBeginSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KIf, this.TOpenParenthesis, Expression, this.TCloseParenthesis);
		}
	
	    public IfStatementBeginSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KIf, this.TOpenParenthesis, this.Expression, TCloseParenthesis);
		}
	
	    public IfStatementBeginSyntax Update(SyntaxToken kIf, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KIf != kIf ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.IfStatementBegin(kIf, tOpenParenthesis, expression, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementBeginSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIfStatementBegin(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIfStatementBegin(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitIfStatementBegin(this);
	    }
	}
	
	public sealed class ElseIfStatementSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public ElseIfStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElseIfStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KElse 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ElseIfStatementGreen)this.Green;
				var greenToken = green.KElse;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KIf 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ElseIfStatementGreen)this.Green;
				var greenToken = green.KIf;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ElseIfStatementGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 3); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ElseIfStatementGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.GetRed(ref this.expression, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 3: return this.expression;
				default: return null;
	        }
	    }
	
	    public ElseIfStatementSyntax WithKElse(SyntaxToken kElse)
		{
			return this.Update(KElse, this.KIf, this.TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public ElseIfStatementSyntax WithKIf(SyntaxToken kIf)
		{
			return this.Update(this.KElse, KIf, this.TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public ElseIfStatementSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KElse, this.KIf, TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public ElseIfStatementSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KElse, this.KIf, this.TOpenParenthesis, Expression, this.TCloseParenthesis);
		}
	
	    public ElseIfStatementSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KElse, this.KIf, this.TOpenParenthesis, this.Expression, TCloseParenthesis);
		}
	
	    public ElseIfStatementSyntax Update(SyntaxToken kElse, SyntaxToken kIf, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KElse != kElse ||
				this.KIf != kIf ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ElseIfStatement(kElse, kIf, tOpenParenthesis, expression, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElseIfStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElseIfStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElseIfStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitElseIfStatement(this);
	    }
	}
	
	public sealed class IfStatementElseSyntax : TestLexerModeSyntaxNode
	{
	
	    public IfStatementElseSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IfStatementElseSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KElse 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.IfStatementElseGreen)this.Green;
				var greenToken = green.KElse;
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
	
	    public IfStatementElseSyntax WithKElse(SyntaxToken kElse)
		{
			return this.Update(KElse);
		}
	
	    public IfStatementElseSyntax Update(SyntaxToken kElse)
	    {
	        if (this.KElse != kElse)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.IfStatementElse(kElse);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementElseSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIfStatementElse(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIfStatementElse(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitIfStatementElse(this);
	    }
	}
	
	public sealed class IfStatementEndSyntax : TestLexerModeSyntaxNode
	{
	
	    public IfStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IfStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.IfStatementEndGreen)this.Green;
				var greenToken = green.KEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KIf 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.IfStatementEndGreen)this.Green;
				var greenToken = green.KIf;
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
	
	    public IfStatementEndSyntax WithKEnd(SyntaxToken kEnd)
		{
			return this.Update(KEnd, this.KIf);
		}
	
	    public IfStatementEndSyntax WithKIf(SyntaxToken kIf)
		{
			return this.Update(this.KEnd, KIf);
		}
	
	    public IfStatementEndSyntax Update(SyntaxToken kEnd, SyntaxToken kIf)
	    {
	        if (this.KEnd != kEnd ||
				this.KIf != kIf)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.IfStatementEnd(kEnd, kIf);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IfStatementEndSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIfStatementEnd(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIfStatementEnd(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitIfStatementEnd(this);
	    }
	}
	
	public sealed class ForStatementSyntax : TestLexerModeSyntaxNode
	{
	    private ForStatementBeginSyntax forStatementBegin;
	    private BodySyntax body;
	    private ForStatementEndSyntax forStatementEnd;
	
	    public ForStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ForStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ForStatementBeginSyntax ForStatementBegin 
		{ 
			get { return this.GetRed(ref this.forStatementBegin, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	    public ForStatementEndSyntax ForStatementEnd 
		{ 
			get { return this.GetRed(ref this.forStatementEnd, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.forStatementBegin, 0);
				case 1: return this.GetRed(ref this.body, 1);
				case 2: return this.GetRed(ref this.forStatementEnd, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.forStatementBegin;
				case 1: return this.body;
				case 2: return this.forStatementEnd;
				default: return null;
	        }
	    }
	
	    public ForStatementSyntax WithForStatementBegin(ForStatementBeginSyntax forStatementBegin)
		{
			return this.Update(ForStatementBegin, this.Body, this.ForStatementEnd);
		}
	
	    public ForStatementSyntax WithBody(BodySyntax body)
		{
			return this.Update(this.ForStatementBegin, Body, this.ForStatementEnd);
		}
	
	    public ForStatementSyntax WithForStatementEnd(ForStatementEndSyntax forStatementEnd)
		{
			return this.Update(this.ForStatementBegin, this.Body, ForStatementEnd);
		}
	
	    public ForStatementSyntax Update(ForStatementBeginSyntax forStatementBegin, BodySyntax body, ForStatementEndSyntax forStatementEnd)
	    {
	        if (this.ForStatementBegin != forStatementBegin ||
				this.Body != body ||
				this.ForStatementEnd != forStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ForStatement(forStatementBegin, body, forStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitForStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitForStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitForStatement(this);
	    }
	}
	
	public sealed class ForStatementBeginSyntax : TestLexerModeSyntaxNode
	{
	    private ForInitStatementSyntax forInitStatement;
	    private ExpressionListSyntax endExpression;
	    private ExpressionListSyntax stepExpression;
	
	    public ForStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ForStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KFor 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ForStatementBeginGreen)this.Green;
				var greenToken = green.KFor;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ForStatementBeginGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ForInitStatementSyntax ForInitStatement 
		{ 
			get { return this.GetRed(ref this.forInitStatement, 2); } 
		}
	    public SyntaxToken Semi1 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ForStatementBeginGreen)this.Green;
				var greenToken = green.Semi1;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public ExpressionListSyntax EndExpression 
		{ 
			get { return this.GetRed(ref this.endExpression, 4); } 
		}
	    public SyntaxToken Semi2 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ForStatementBeginGreen)this.Green;
				var greenToken = green.Semi2;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	    public ExpressionListSyntax StepExpression 
		{ 
			get { return this.GetRed(ref this.stepExpression, 6); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ForStatementBeginGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(7), this.GetChildIndex(7));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.forInitStatement, 2);
				case 4: return this.GetRed(ref this.endExpression, 4);
				case 6: return this.GetRed(ref this.stepExpression, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.forInitStatement;
				case 4: return this.endExpression;
				case 6: return this.stepExpression;
				default: return null;
	        }
	    }
	
	    public ForStatementBeginSyntax WithKFor(SyntaxToken kFor)
		{
			return this.Update(KFor, this.TOpenParenthesis, this.ForInitStatement, this.Semi1, this.EndExpression, this.Semi2, this.StepExpression, this.TCloseParenthesis);
		}
	
	    public ForStatementBeginSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KFor, TOpenParenthesis, this.ForInitStatement, this.Semi1, this.EndExpression, this.Semi2, this.StepExpression, this.TCloseParenthesis);
		}
	
	    public ForStatementBeginSyntax WithForInitStatement(ForInitStatementSyntax forInitStatement)
		{
			return this.Update(this.KFor, this.TOpenParenthesis, ForInitStatement, this.Semi1, this.EndExpression, this.Semi2, this.StepExpression, this.TCloseParenthesis);
		}
	
	    public ForStatementBeginSyntax WithSemi1(SyntaxToken semi1)
		{
			return this.Update(this.KFor, this.TOpenParenthesis, this.ForInitStatement, Semi1, this.EndExpression, this.Semi2, this.StepExpression, this.TCloseParenthesis);
		}
	
	    public ForStatementBeginSyntax WithEndExpression(ExpressionListSyntax endExpression)
		{
			return this.Update(this.KFor, this.TOpenParenthesis, this.ForInitStatement, this.Semi1, EndExpression, this.Semi2, this.StepExpression, this.TCloseParenthesis);
		}
	
	    public ForStatementBeginSyntax WithSemi2(SyntaxToken semi2)
		{
			return this.Update(this.KFor, this.TOpenParenthesis, this.ForInitStatement, this.Semi1, this.EndExpression, Semi2, this.StepExpression, this.TCloseParenthesis);
		}
	
	    public ForStatementBeginSyntax WithStepExpression(ExpressionListSyntax stepExpression)
		{
			return this.Update(this.KFor, this.TOpenParenthesis, this.ForInitStatement, this.Semi1, this.EndExpression, this.Semi2, StepExpression, this.TCloseParenthesis);
		}
	
	    public ForStatementBeginSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KFor, this.TOpenParenthesis, this.ForInitStatement, this.Semi1, this.EndExpression, this.Semi2, this.StepExpression, TCloseParenthesis);
		}
	
	    public ForStatementBeginSyntax Update(SyntaxToken kFor, SyntaxToken tOpenParenthesis, ForInitStatementSyntax forInitStatement, SyntaxToken semi1, ExpressionListSyntax endExpression, SyntaxToken semi2, ExpressionListSyntax stepExpression, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KFor != kFor ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ForInitStatement != forInitStatement ||
				this.Semi1 != semi1 ||
				this.EndExpression != endExpression ||
				this.Semi2 != semi2 ||
				this.StepExpression != stepExpression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ForStatementBegin(kFor, tOpenParenthesis, forInitStatement, semi1, endExpression, semi2, stepExpression, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForStatementBeginSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitForStatementBegin(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitForStatementBegin(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitForStatementBegin(this);
	    }
	}
	
	public sealed class ForStatementEndSyntax : TestLexerModeSyntaxNode
	{
	
	    public ForStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ForStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ForStatementEndGreen)this.Green;
				var greenToken = green.KEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KFor 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ForStatementEndGreen)this.Green;
				var greenToken = green.KFor;
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
	
	    public ForStatementEndSyntax WithKEnd(SyntaxToken kEnd)
		{
			return this.Update(KEnd, this.KFor);
		}
	
	    public ForStatementEndSyntax WithKFor(SyntaxToken kFor)
		{
			return this.Update(this.KEnd, KFor);
		}
	
	    public ForStatementEndSyntax Update(SyntaxToken kEnd, SyntaxToken kFor)
	    {
	        if (this.KEnd != kEnd ||
				this.KFor != kFor)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ForStatementEnd(kEnd, kFor);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForStatementEndSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitForStatementEnd(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitForStatementEnd(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitForStatementEnd(this);
	    }
	}
	
	public sealed class ForInitStatementSyntax : TestLexerModeSyntaxNode
	{
	    private VariableDeclarationExpressionSyntax variableDeclarationExpression;
	    private ExpressionListSyntax expressionList;
	
	    public ForInitStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ForInitStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VariableDeclarationExpressionSyntax VariableDeclarationExpression 
		{ 
			get { return this.GetRed(ref this.variableDeclarationExpression, 0); } 
		}
	    public ExpressionListSyntax ExpressionList 
		{ 
			get { return this.GetRed(ref this.expressionList, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.variableDeclarationExpression, 0);
				case 1: return this.GetRed(ref this.expressionList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.variableDeclarationExpression;
				case 1: return this.expressionList;
				default: return null;
	        }
	    }
	
	    public ForInitStatementSyntax WithVariableDeclarationExpression(VariableDeclarationExpressionSyntax variableDeclarationExpression)
		{
			return this.Update(variableDeclarationExpression);
		}
	
	    public ForInitStatementSyntax WithExpressionList(ExpressionListSyntax expressionList)
		{
			return this.Update(expressionList);
		}
	
	    public ForInitStatementSyntax Update(VariableDeclarationExpressionSyntax variableDeclarationExpression)
	    {
	        if (this.VariableDeclarationExpression != variableDeclarationExpression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ForInitStatement(variableDeclarationExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForInitStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ForInitStatementSyntax Update(ExpressionListSyntax expressionList)
	    {
	        if (this.ExpressionList != expressionList)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ForInitStatement(expressionList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ForInitStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitForInitStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitForInitStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitForInitStatement(this);
	    }
	}
	
	public sealed class WhileStatementSyntax : TestLexerModeSyntaxNode
	{
	    private WhileStatementBeginSyntax whileStatementBegin;
	    private BodySyntax body;
	    private WhileStatementEndSyntax whileStatementEnd;
	
	    public WhileStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WhileStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public WhileStatementBeginSyntax WhileStatementBegin 
		{ 
			get { return this.GetRed(ref this.whileStatementBegin, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	    public WhileStatementEndSyntax WhileStatementEnd 
		{ 
			get { return this.GetRed(ref this.whileStatementEnd, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.whileStatementBegin, 0);
				case 1: return this.GetRed(ref this.body, 1);
				case 2: return this.GetRed(ref this.whileStatementEnd, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.whileStatementBegin;
				case 1: return this.body;
				case 2: return this.whileStatementEnd;
				default: return null;
	        }
	    }
	
	    public WhileStatementSyntax WithWhileStatementBegin(WhileStatementBeginSyntax whileStatementBegin)
		{
			return this.Update(WhileStatementBegin, this.Body, this.WhileStatementEnd);
		}
	
	    public WhileStatementSyntax WithBody(BodySyntax body)
		{
			return this.Update(this.WhileStatementBegin, Body, this.WhileStatementEnd);
		}
	
	    public WhileStatementSyntax WithWhileStatementEnd(WhileStatementEndSyntax whileStatementEnd)
		{
			return this.Update(this.WhileStatementBegin, this.Body, WhileStatementEnd);
		}
	
	    public WhileStatementSyntax Update(WhileStatementBeginSyntax whileStatementBegin, BodySyntax body, WhileStatementEndSyntax whileStatementEnd)
	    {
	        if (this.WhileStatementBegin != whileStatementBegin ||
				this.Body != body ||
				this.WhileStatementEnd != whileStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.WhileStatement(whileStatementBegin, body, whileStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhileStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWhileStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWhileStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitWhileStatement(this);
	    }
	}
	
	public sealed class WhileStatementBeginSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public WhileStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WhileStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KWhile 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.WhileStatementBeginGreen)this.Green;
				var greenToken = green.KWhile;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.WhileStatementBeginGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.WhileStatementBeginGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public WhileStatementBeginSyntax WithKWhile(SyntaxToken kWhile)
		{
			return this.Update(KWhile, this.TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public WhileStatementBeginSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KWhile, TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public WhileStatementBeginSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KWhile, this.TOpenParenthesis, Expression, this.TCloseParenthesis);
		}
	
	    public WhileStatementBeginSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KWhile, this.TOpenParenthesis, this.Expression, TCloseParenthesis);
		}
	
	    public WhileStatementBeginSyntax Update(SyntaxToken kWhile, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KWhile != kWhile ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.WhileStatementBegin(kWhile, tOpenParenthesis, expression, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhileStatementBeginSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWhileStatementBegin(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWhileStatementBegin(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitWhileStatementBegin(this);
	    }
	}
	
	public sealed class WhileStatementEndSyntax : TestLexerModeSyntaxNode
	{
	
	    public WhileStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WhileStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.WhileStatementEndGreen)this.Green;
				var greenToken = green.KEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KWhile 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.WhileStatementEndGreen)this.Green;
				var greenToken = green.KWhile;
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
	
	    public WhileStatementEndSyntax WithKEnd(SyntaxToken kEnd)
		{
			return this.Update(KEnd, this.KWhile);
		}
	
	    public WhileStatementEndSyntax WithKWhile(SyntaxToken kWhile)
		{
			return this.Update(this.KEnd, KWhile);
		}
	
	    public WhileStatementEndSyntax Update(SyntaxToken kEnd, SyntaxToken kWhile)
	    {
	        if (this.KEnd != kEnd ||
				this.KWhile != kWhile)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.WhileStatementEnd(kEnd, kWhile);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhileStatementEndSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWhileStatementEnd(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWhileStatementEnd(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitWhileStatementEnd(this);
	    }
	}
	
	public sealed class WhileRunExpressionSyntax : TestLexerModeSyntaxNode
	{
	    private SeparatorStatementSyntax separatorStatement;
	
	    public WhileRunExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public WhileRunExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatorStatementSyntax SeparatorStatement 
		{ 
			get { return this.GetRed(ref this.separatorStatement, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.separatorStatement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.separatorStatement;
				default: return null;
	        }
	    }
	
	    public WhileRunExpressionSyntax WithSeparatorStatement(SeparatorStatementSyntax separatorStatement)
		{
			return this.Update(SeparatorStatement);
		}
	
	    public WhileRunExpressionSyntax Update(SeparatorStatementSyntax separatorStatement)
	    {
	        if (this.SeparatorStatement != separatorStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.WhileRunExpression(separatorStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (WhileRunExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitWhileRunExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitWhileRunExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitWhileRunExpression(this);
	    }
	}
	
	public sealed class RepeatStatementSyntax : TestLexerModeSyntaxNode
	{
	    private RepeatStatementBeginSyntax repeatStatementBegin;
	    private BodySyntax body;
	    private RepeatStatementEndSyntax repeatStatementEnd;
	
	    public RepeatStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RepeatStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public RepeatStatementBeginSyntax RepeatStatementBegin 
		{ 
			get { return this.GetRed(ref this.repeatStatementBegin, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	    public RepeatStatementEndSyntax RepeatStatementEnd 
		{ 
			get { return this.GetRed(ref this.repeatStatementEnd, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.repeatStatementBegin, 0);
				case 1: return this.GetRed(ref this.body, 1);
				case 2: return this.GetRed(ref this.repeatStatementEnd, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.repeatStatementBegin;
				case 1: return this.body;
				case 2: return this.repeatStatementEnd;
				default: return null;
	        }
	    }
	
	    public RepeatStatementSyntax WithRepeatStatementBegin(RepeatStatementBeginSyntax repeatStatementBegin)
		{
			return this.Update(RepeatStatementBegin, this.Body, this.RepeatStatementEnd);
		}
	
	    public RepeatStatementSyntax WithBody(BodySyntax body)
		{
			return this.Update(this.RepeatStatementBegin, Body, this.RepeatStatementEnd);
		}
	
	    public RepeatStatementSyntax WithRepeatStatementEnd(RepeatStatementEndSyntax repeatStatementEnd)
		{
			return this.Update(this.RepeatStatementBegin, this.Body, RepeatStatementEnd);
		}
	
	    public RepeatStatementSyntax Update(RepeatStatementBeginSyntax repeatStatementBegin, BodySyntax body, RepeatStatementEndSyntax repeatStatementEnd)
	    {
	        if (this.RepeatStatementBegin != repeatStatementBegin ||
				this.Body != body ||
				this.RepeatStatementEnd != repeatStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.RepeatStatement(repeatStatementBegin, body, repeatStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RepeatStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRepeatStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRepeatStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitRepeatStatement(this);
	    }
	}
	
	public sealed class RepeatStatementBeginSyntax : TestLexerModeSyntaxNode
	{
	
	    public RepeatStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RepeatStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KRepeat 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.RepeatStatementBeginGreen)this.Green;
				var greenToken = green.KRepeat;
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
	
	    public RepeatStatementBeginSyntax WithKRepeat(SyntaxToken kRepeat)
		{
			return this.Update(KRepeat);
		}
	
	    public RepeatStatementBeginSyntax Update(SyntaxToken kRepeat)
	    {
	        if (this.KRepeat != kRepeat)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.RepeatStatementBegin(kRepeat);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RepeatStatementBeginSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRepeatStatementBegin(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRepeatStatementBegin(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitRepeatStatementBegin(this);
	    }
	}
	
	public sealed class RepeatStatementEndSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public RepeatStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RepeatStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KUntil 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.RepeatStatementEndGreen)this.Green;
				var greenToken = green.KUntil;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.RepeatStatementEndGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.RepeatStatementEndGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public RepeatStatementEndSyntax WithKUntil(SyntaxToken kUntil)
		{
			return this.Update(KUntil, this.TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public RepeatStatementEndSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KUntil, TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public RepeatStatementEndSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KUntil, this.TOpenParenthesis, Expression, this.TCloseParenthesis);
		}
	
	    public RepeatStatementEndSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KUntil, this.TOpenParenthesis, this.Expression, TCloseParenthesis);
		}
	
	    public RepeatStatementEndSyntax Update(SyntaxToken kUntil, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KUntil != kUntil ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.RepeatStatementEnd(kUntil, tOpenParenthesis, expression, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RepeatStatementEndSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRepeatStatementEnd(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRepeatStatementEnd(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitRepeatStatementEnd(this);
	    }
	}
	
	public sealed class RepeatRunExpressionSyntax : TestLexerModeSyntaxNode
	{
	    private SeparatorStatementSyntax separatorStatement;
	
	    public RepeatRunExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RepeatRunExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatorStatementSyntax SeparatorStatement 
		{ 
			get { return this.GetRed(ref this.separatorStatement, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.separatorStatement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.separatorStatement;
				default: return null;
	        }
	    }
	
	    public RepeatRunExpressionSyntax WithSeparatorStatement(SeparatorStatementSyntax separatorStatement)
		{
			return this.Update(SeparatorStatement);
		}
	
	    public RepeatRunExpressionSyntax Update(SeparatorStatementSyntax separatorStatement)
	    {
	        if (this.SeparatorStatement != separatorStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.RepeatRunExpression(separatorStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RepeatRunExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRepeatRunExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRepeatRunExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitRepeatRunExpression(this);
	    }
	}
	
	public sealed class LoopStatementSyntax : TestLexerModeSyntaxNode
	{
	    private LoopStatementBeginSyntax loopStatementBegin;
	    private BodySyntax body;
	    private LoopStatementEndSyntax loopStatementEnd;
	
	    public LoopStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LoopStatementBeginSyntax LoopStatementBegin 
		{ 
			get { return this.GetRed(ref this.loopStatementBegin, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	    public LoopStatementEndSyntax LoopStatementEnd 
		{ 
			get { return this.GetRed(ref this.loopStatementEnd, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.loopStatementBegin, 0);
				case 1: return this.GetRed(ref this.body, 1);
				case 2: return this.GetRed(ref this.loopStatementEnd, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.loopStatementBegin;
				case 1: return this.body;
				case 2: return this.loopStatementEnd;
				default: return null;
	        }
	    }
	
	    public LoopStatementSyntax WithLoopStatementBegin(LoopStatementBeginSyntax loopStatementBegin)
		{
			return this.Update(LoopStatementBegin, this.Body, this.LoopStatementEnd);
		}
	
	    public LoopStatementSyntax WithBody(BodySyntax body)
		{
			return this.Update(this.LoopStatementBegin, Body, this.LoopStatementEnd);
		}
	
	    public LoopStatementSyntax WithLoopStatementEnd(LoopStatementEndSyntax loopStatementEnd)
		{
			return this.Update(this.LoopStatementBegin, this.Body, LoopStatementEnd);
		}
	
	    public LoopStatementSyntax Update(LoopStatementBeginSyntax loopStatementBegin, BodySyntax body, LoopStatementEndSyntax loopStatementEnd)
	    {
	        if (this.LoopStatementBegin != loopStatementBegin ||
				this.Body != body ||
				this.LoopStatementEnd != loopStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopStatement(loopStatementBegin, body, loopStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopStatement(this);
	    }
	}
	
	public sealed class LoopStatementBeginSyntax : TestLexerModeSyntaxNode
	{
	    private LoopChainSyntax loopChain;
	    private LoopWhereExpressionSyntax loopWhereExpression;
	    private LoopRunExpressionSyntax loopRunExpression;
	
	    public LoopStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KLoop 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopStatementBeginGreen)this.Green;
				var greenToken = green.KLoop;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopStatementBeginGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public LoopChainSyntax LoopChain 
		{ 
			get { return this.GetRed(ref this.loopChain, 2); } 
		}
	    public LoopWhereExpressionSyntax LoopWhereExpression 
		{ 
			get { return this.GetRed(ref this.loopWhereExpression, 3); } 
		}
	    public LoopRunExpressionSyntax LoopRunExpression 
		{ 
			get { return this.GetRed(ref this.loopRunExpression, 4); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopStatementBeginGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(5), this.GetChildIndex(5));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.loopChain, 2);
				case 3: return this.GetRed(ref this.loopWhereExpression, 3);
				case 4: return this.GetRed(ref this.loopRunExpression, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.loopChain;
				case 3: return this.loopWhereExpression;
				case 4: return this.loopRunExpression;
				default: return null;
	        }
	    }
	
	    public LoopStatementBeginSyntax WithKLoop(SyntaxToken kLoop)
		{
			return this.Update(KLoop, this.TOpenParenthesis, this.LoopChain, this.LoopWhereExpression, this.LoopRunExpression, this.TCloseParenthesis);
		}
	
	    public LoopStatementBeginSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KLoop, TOpenParenthesis, this.LoopChain, this.LoopWhereExpression, this.LoopRunExpression, this.TCloseParenthesis);
		}
	
	    public LoopStatementBeginSyntax WithLoopChain(LoopChainSyntax loopChain)
		{
			return this.Update(this.KLoop, this.TOpenParenthesis, LoopChain, this.LoopWhereExpression, this.LoopRunExpression, this.TCloseParenthesis);
		}
	
	    public LoopStatementBeginSyntax WithLoopWhereExpression(LoopWhereExpressionSyntax loopWhereExpression)
		{
			return this.Update(this.KLoop, this.TOpenParenthesis, this.LoopChain, LoopWhereExpression, this.LoopRunExpression, this.TCloseParenthesis);
		}
	
	    public LoopStatementBeginSyntax WithLoopRunExpression(LoopRunExpressionSyntax loopRunExpression)
		{
			return this.Update(this.KLoop, this.TOpenParenthesis, this.LoopChain, this.LoopWhereExpression, LoopRunExpression, this.TCloseParenthesis);
		}
	
	    public LoopStatementBeginSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KLoop, this.TOpenParenthesis, this.LoopChain, this.LoopWhereExpression, this.LoopRunExpression, TCloseParenthesis);
		}
	
	    public LoopStatementBeginSyntax Update(SyntaxToken kLoop, SyntaxToken tOpenParenthesis, LoopChainSyntax loopChain, LoopWhereExpressionSyntax loopWhereExpression, LoopRunExpressionSyntax loopRunExpression, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KLoop != kLoop ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.LoopChain != loopChain ||
				this.LoopWhereExpression != loopWhereExpression ||
				this.LoopRunExpression != loopRunExpression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopStatementBegin(kLoop, tOpenParenthesis, loopChain, loopWhereExpression, loopRunExpression, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopStatementBeginSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopStatementBegin(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopStatementBegin(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopStatementBegin(this);
	    }
	}
	
	public sealed class LoopStatementEndSyntax : TestLexerModeSyntaxNode
	{
	
	    public LoopStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopStatementEndGreen)this.Green;
				var greenToken = green.KEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KLoop 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopStatementEndGreen)this.Green;
				var greenToken = green.KLoop;
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
	
	    public LoopStatementEndSyntax WithKEnd(SyntaxToken kEnd)
		{
			return this.Update(KEnd, this.KLoop);
		}
	
	    public LoopStatementEndSyntax WithKLoop(SyntaxToken kLoop)
		{
			return this.Update(this.KEnd, KLoop);
		}
	
	    public LoopStatementEndSyntax Update(SyntaxToken kEnd, SyntaxToken kLoop)
	    {
	        if (this.KEnd != kEnd ||
				this.KLoop != kLoop)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopStatementEnd(kEnd, kLoop);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopStatementEndSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopStatementEnd(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopStatementEnd(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopStatementEnd(this);
	    }
	}
	
	public sealed class LoopChainSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode loopChainItem;
	
	    public LoopChainSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopChainSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<LoopChainItemSyntax> LoopChainItem 
		{ 
			get
			{
				var red = this.GetRed(ref this.loopChainItem, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<LoopChainItemSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.loopChainItem, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.loopChainItem;
				default: return null;
	        }
	    }
	
	    public LoopChainSyntax WithLoopChainItem(SeparatedSyntaxList<LoopChainItemSyntax> loopChainItem)
		{
			return this.Update(LoopChainItem);
		}
	
	    public LoopChainSyntax AddLoopChainItem(params LoopChainItemSyntax[] loopChainItem)
		{
			return this.WithLoopChainItem(this.LoopChainItem.AddRange(loopChainItem));
		}
	
	    public LoopChainSyntax Update(SeparatedSyntaxList<LoopChainItemSyntax> loopChainItem)
	    {
	        if (this.LoopChainItem != loopChainItem)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopChain(loopChainItem);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopChain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopChain(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopChain(this);
	    }
	}
	
	public sealed class LoopChainItemSyntax : TestLexerModeSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private IdentifierSyntax identifier;
	    private LoopChainExpressionSyntax loopChainExpression;
	
	    public LoopChainItemSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopChainItemSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopChainItemGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public LoopChainExpressionSyntax LoopChainExpression 
		{ 
			get { return this.GetRed(ref this.loopChainExpression, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				case 1: return this.GetRed(ref this.identifier, 1);
				case 3: return this.GetRed(ref this.loopChainExpression, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				case 1: return this.identifier;
				case 3: return this.loopChainExpression;
				default: return null;
	        }
	    }
	
	    public LoopChainItemSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference, this.Identifier, this.TColon, this.LoopChainExpression);
		}
	
	    public LoopChainItemSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.TypeReference, Identifier, this.TColon, this.LoopChainExpression);
		}
	
	    public LoopChainItemSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.TypeReference, this.Identifier, TColon, this.LoopChainExpression);
		}
	
	    public LoopChainItemSyntax WithLoopChainExpression(LoopChainExpressionSyntax loopChainExpression)
		{
			return this.Update(this.TypeReference, this.Identifier, this.TColon, LoopChainExpression);
		}
	
	    public LoopChainItemSyntax Update(TypeReferenceSyntax typeReference, IdentifierSyntax identifier, SyntaxToken tColon, LoopChainExpressionSyntax loopChainExpression)
	    {
	        if (this.TypeReference != typeReference ||
				this.Identifier != identifier ||
				this.TColon != tColon ||
				this.LoopChainExpression != loopChainExpression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopChainItem(typeReference, identifier, tColon, loopChainExpression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainItemSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopChainItem(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopChainItem(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopChainItem(this);
	    }
	}
	
	public abstract class LoopChainExpressionSyntax : TestLexerModeSyntaxNode
	{
	    protected LoopChainExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected LoopChainExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class LoopChainTypeofExpressionSyntax : LoopChainExpressionSyntax
	{
	    private TypeReferenceSyntax typeReference;
	
	    public LoopChainTypeofExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopChainTypeofExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTypeof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopChainTypeofExpressionGreen)this.Green;
				var greenToken = green.KTypeof;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopChainTypeofExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopChainTypeofExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public LoopChainTypeofExpressionSyntax WithKTypeof(SyntaxToken kTypeof)
		{
			return this.Update(KTypeof, this.TOpenParenthesis, this.TypeReference, this.TCloseParenthesis);
		}
	
	    public LoopChainTypeofExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KTypeof, TOpenParenthesis, this.TypeReference, this.TCloseParenthesis);
		}
	
	    public LoopChainTypeofExpressionSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KTypeof, this.TOpenParenthesis, TypeReference, this.TCloseParenthesis);
		}
	
	    public LoopChainTypeofExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KTypeof, this.TOpenParenthesis, this.TypeReference, TCloseParenthesis);
		}
	
	    public LoopChainTypeofExpressionSyntax Update(SyntaxToken kTypeof, SyntaxToken tOpenParenthesis, TypeReferenceSyntax typeReference, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.TypeReference != typeReference ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopChainTypeofExpression(kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainTypeofExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopChainTypeofExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopChainTypeofExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopChainTypeofExpression(this);
	    }
	}
	
	public sealed class LoopChainIdentifierExpressionSyntax : LoopChainExpressionSyntax
	{
	    private IdentifierSyntax identifier;
	    private TypeArgumentListSyntax typeArgumentList;
	
	    public LoopChainIdentifierExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopChainIdentifierExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public TypeArgumentListSyntax TypeArgumentList 
		{ 
			get { return this.GetRed(ref this.typeArgumentList, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				case 1: return this.GetRed(ref this.typeArgumentList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				case 1: return this.typeArgumentList;
				default: return null;
	        }
	    }
	
	    public LoopChainIdentifierExpressionSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier, this.TypeArgumentList);
		}
	
	    public LoopChainIdentifierExpressionSyntax WithTypeArgumentList(TypeArgumentListSyntax typeArgumentList)
		{
			return this.Update(this.Identifier, TypeArgumentList);
		}
	
	    public LoopChainIdentifierExpressionSyntax Update(IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
	    {
	        if (this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopChainIdentifierExpression(identifier, typeArgumentList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainIdentifierExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopChainIdentifierExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopChainIdentifierExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopChainIdentifierExpression(this);
	    }
	}
	
	public sealed class LoopChainMemberAccessExpressionSyntax : LoopChainExpressionSyntax
	{
	    private LoopChainExpressionSyntax loopChainExpression;
	    private IdentifierSyntax identifier;
	    private TypeArgumentListSyntax typeArgumentList;
	
	    public LoopChainMemberAccessExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopChainMemberAccessExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LoopChainExpressionSyntax LoopChainExpression 
		{ 
			get { return this.GetRed(ref this.loopChainExpression, 0); } 
		}
	    public SyntaxToken TDot 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopChainMemberAccessExpressionGreen)this.Green;
				var greenToken = green.TDot;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 2); } 
		}
	    public TypeArgumentListSyntax TypeArgumentList 
		{ 
			get { return this.GetRed(ref this.typeArgumentList, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.loopChainExpression, 0);
				case 2: return this.GetRed(ref this.identifier, 2);
				case 3: return this.GetRed(ref this.typeArgumentList, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.loopChainExpression;
				case 2: return this.identifier;
				case 3: return this.typeArgumentList;
				default: return null;
	        }
	    }
	
	    public LoopChainMemberAccessExpressionSyntax WithLoopChainExpression(LoopChainExpressionSyntax loopChainExpression)
		{
			return this.Update(LoopChainExpression, this.TDot, this.Identifier, this.TypeArgumentList);
		}
	
	    public LoopChainMemberAccessExpressionSyntax WithTDot(SyntaxToken tDot)
		{
			return this.Update(this.LoopChainExpression, TDot, this.Identifier, this.TypeArgumentList);
		}
	
	    public LoopChainMemberAccessExpressionSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.LoopChainExpression, this.TDot, Identifier, this.TypeArgumentList);
		}
	
	    public LoopChainMemberAccessExpressionSyntax WithTypeArgumentList(TypeArgumentListSyntax typeArgumentList)
		{
			return this.Update(this.LoopChainExpression, this.TDot, this.Identifier, TypeArgumentList);
		}
	
	    public LoopChainMemberAccessExpressionSyntax Update(LoopChainExpressionSyntax loopChainExpression, SyntaxToken tDot, IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
	    {
	        if (this.LoopChainExpression != loopChainExpression ||
				this.TDot != tDot ||
				this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopChainMemberAccessExpression(loopChainExpression, tDot, identifier, typeArgumentList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainMemberAccessExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopChainMemberAccessExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopChainMemberAccessExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopChainMemberAccessExpression(this);
	    }
	}
	
	public sealed class LoopChainMethodCallExpressionSyntax : LoopChainExpressionSyntax
	{
	    private LoopChainExpressionSyntax loopChainExpression;
	    private ExpressionListSyntax expressionList;
	
	    public LoopChainMethodCallExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopChainMethodCallExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LoopChainExpressionSyntax LoopChainExpression 
		{ 
			get { return this.GetRed(ref this.loopChainExpression, 0); } 
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopChainMethodCallExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionListSyntax ExpressionList 
		{ 
			get { return this.GetRed(ref this.expressionList, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopChainMethodCallExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.loopChainExpression, 0);
				case 2: return this.GetRed(ref this.expressionList, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.loopChainExpression;
				case 2: return this.expressionList;
				default: return null;
	        }
	    }
	
	    public LoopChainMethodCallExpressionSyntax WithLoopChainExpression(LoopChainExpressionSyntax loopChainExpression)
		{
			return this.Update(LoopChainExpression, this.TOpenParenthesis, this.ExpressionList, this.TCloseParenthesis);
		}
	
	    public LoopChainMethodCallExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.LoopChainExpression, TOpenParenthesis, this.ExpressionList, this.TCloseParenthesis);
		}
	
	    public LoopChainMethodCallExpressionSyntax WithExpressionList(ExpressionListSyntax expressionList)
		{
			return this.Update(this.LoopChainExpression, this.TOpenParenthesis, ExpressionList, this.TCloseParenthesis);
		}
	
	    public LoopChainMethodCallExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.LoopChainExpression, this.TOpenParenthesis, this.ExpressionList, TCloseParenthesis);
		}
	
	    public LoopChainMethodCallExpressionSyntax Update(LoopChainExpressionSyntax loopChainExpression, SyntaxToken tOpenParenthesis, ExpressionListSyntax expressionList, SyntaxToken tCloseParenthesis)
	    {
	        if (this.LoopChainExpression != loopChainExpression ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ExpressionList != expressionList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopChainMethodCallExpression(loopChainExpression, tOpenParenthesis, expressionList, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopChainMethodCallExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopChainMethodCallExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopChainMethodCallExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopChainMethodCallExpression(this);
	    }
	}
	
	public sealed class LoopWhereExpressionSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public LoopWhereExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopWhereExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KWhere 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LoopWhereExpressionGreen)this.Green;
				var greenToken = green.KWhere;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.expression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.expression;
				default: return null;
	        }
	    }
	
	    public LoopWhereExpressionSyntax WithKWhere(SyntaxToken kWhere)
		{
			return this.Update(KWhere, this.Expression);
		}
	
	    public LoopWhereExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KWhere, Expression);
		}
	
	    public LoopWhereExpressionSyntax Update(SyntaxToken kWhere, ExpressionSyntax expression)
	    {
	        if (this.KWhere != kWhere ||
				this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopWhereExpression(kWhere, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopWhereExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopWhereExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopWhereExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopWhereExpression(this);
	    }
	}
	
	public sealed class LoopRunExpressionSyntax : TestLexerModeSyntaxNode
	{
	    private SeparatorStatementSyntax separatorStatement;
	
	    public LoopRunExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LoopRunExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatorStatementSyntax SeparatorStatement 
		{ 
			get { return this.GetRed(ref this.separatorStatement, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.separatorStatement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.separatorStatement;
				default: return null;
	        }
	    }
	
	    public LoopRunExpressionSyntax WithSeparatorStatement(SeparatorStatementSyntax separatorStatement)
		{
			return this.Update(SeparatorStatement);
		}
	
	    public LoopRunExpressionSyntax Update(SeparatorStatementSyntax separatorStatement)
	    {
	        if (this.SeparatorStatement != separatorStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LoopRunExpression(separatorStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LoopRunExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLoopRunExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLoopRunExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLoopRunExpression(this);
	    }
	}
	
	public sealed class SeparatorStatementSyntax : TestLexerModeSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private StringLiteralxSyntax stringLiteralx;
	
	    public SeparatorStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SeparatorStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SeparatorStatementGreen)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KSeparator 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SeparatorStatementGreen)this.Green;
				var greenToken = green.KSeparator;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 2); } 
		}
	    public SyntaxToken TAssign 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SeparatorStatementGreen)this.Green;
				var greenToken = green.TAssign;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public StringLiteralxSyntax StringLiteralx 
		{ 
			get { return this.GetRed(ref this.stringLiteralx, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.identifier, 2);
				case 4: return this.GetRed(ref this.stringLiteralx, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.identifier;
				case 4: return this.stringLiteralx;
				default: return null;
	        }
	    }
	
	    public SeparatorStatementSyntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(TSemicolon, this.KSeparator, this.Identifier, this.TAssign, this.StringLiteralx);
		}
	
	    public SeparatorStatementSyntax WithKSeparator(SyntaxToken kSeparator)
		{
			return this.Update(this.TSemicolon, KSeparator, this.Identifier, this.TAssign, this.StringLiteralx);
		}
	
	    public SeparatorStatementSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.TSemicolon, this.KSeparator, Identifier, this.TAssign, this.StringLiteralx);
		}
	
	    public SeparatorStatementSyntax WithTAssign(SyntaxToken tAssign)
		{
			return this.Update(this.TSemicolon, this.KSeparator, this.Identifier, TAssign, this.StringLiteralx);
		}
	
	    public SeparatorStatementSyntax WithStringLiteralx(StringLiteralxSyntax stringLiteralx)
		{
			return this.Update(this.TSemicolon, this.KSeparator, this.Identifier, this.TAssign, StringLiteralx);
		}
	
	    public SeparatorStatementSyntax Update(SyntaxToken tSemicolon, SyntaxToken kSeparator, IdentifierSyntax identifier, SyntaxToken tAssign, StringLiteralxSyntax stringLiteralx)
	    {
	        if (this.TSemicolon != tSemicolon ||
				this.KSeparator != kSeparator ||
				this.Identifier != identifier ||
				this.TAssign != tAssign ||
				this.StringLiteralx != stringLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SeparatorStatement(tSemicolon, kSeparator, identifier, tAssign, stringLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SeparatorStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSeparatorStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSeparatorStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSeparatorStatement(this);
	    }
	}
	
	public sealed class SwitchStatementSyntax : TestLexerModeSyntaxNode
	{
	    private SwitchStatementBeginSyntax switchStatementBegin;
	    private SyntaxNode switchBranchStatement;
	    private SwitchDefaultStatementSyntax switchDefaultStatement;
	    private SwitchStatementEndSyntax switchStatementEnd;
	
	    public SwitchStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SwitchStatementBeginSyntax SwitchStatementBegin 
		{ 
			get { return this.GetRed(ref this.switchStatementBegin, 0); } 
		}
	    public SyntaxList<SwitchBranchStatementSyntax> SwitchBranchStatement 
		{ 
			get
			{
				var red = this.GetRed(ref this.switchBranchStatement, 1);
				if (red != null) return new SyntaxList<SwitchBranchStatementSyntax>(red);
				return default;
			} 
		}
	    public SwitchDefaultStatementSyntax SwitchDefaultStatement 
		{ 
			get { return this.GetRed(ref this.switchDefaultStatement, 2); } 
		}
	    public SwitchStatementEndSyntax SwitchStatementEnd 
		{ 
			get { return this.GetRed(ref this.switchStatementEnd, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.switchStatementBegin, 0);
				case 1: return this.GetRed(ref this.switchBranchStatement, 1);
				case 2: return this.GetRed(ref this.switchDefaultStatement, 2);
				case 3: return this.GetRed(ref this.switchStatementEnd, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.switchStatementBegin;
				case 1: return this.switchBranchStatement;
				case 2: return this.switchDefaultStatement;
				case 3: return this.switchStatementEnd;
				default: return null;
	        }
	    }
	
	    public SwitchStatementSyntax WithSwitchStatementBegin(SwitchStatementBeginSyntax switchStatementBegin)
		{
			return this.Update(SwitchStatementBegin, this.SwitchBranchStatement, this.SwitchDefaultStatement, this.SwitchStatementEnd);
		}
	
	    public SwitchStatementSyntax WithSwitchBranchStatement(SyntaxList<SwitchBranchStatementSyntax> switchBranchStatement)
		{
			return this.Update(this.SwitchStatementBegin, SwitchBranchStatement, this.SwitchDefaultStatement, this.SwitchStatementEnd);
		}
	
	    public SwitchStatementSyntax AddSwitchBranchStatement(params SwitchBranchStatementSyntax[] switchBranchStatement)
		{
			return this.WithSwitchBranchStatement(this.SwitchBranchStatement.AddRange(switchBranchStatement));
		}
	
	    public SwitchStatementSyntax WithSwitchDefaultStatement(SwitchDefaultStatementSyntax switchDefaultStatement)
		{
			return this.Update(this.SwitchStatementBegin, this.SwitchBranchStatement, SwitchDefaultStatement, this.SwitchStatementEnd);
		}
	
	    public SwitchStatementSyntax WithSwitchStatementEnd(SwitchStatementEndSyntax switchStatementEnd)
		{
			return this.Update(this.SwitchStatementBegin, this.SwitchBranchStatement, this.SwitchDefaultStatement, SwitchStatementEnd);
		}
	
	    public SwitchStatementSyntax Update(SwitchStatementBeginSyntax switchStatementBegin, SyntaxList<SwitchBranchStatementSyntax> switchBranchStatement, SwitchDefaultStatementSyntax switchDefaultStatement, SwitchStatementEndSyntax switchStatementEnd)
	    {
	        if (this.SwitchStatementBegin != switchStatementBegin ||
				this.SwitchBranchStatement != switchBranchStatement ||
				this.SwitchDefaultStatement != switchDefaultStatement ||
				this.SwitchStatementEnd != switchStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchStatement(switchStatementBegin, switchBranchStatement, switchDefaultStatement, switchStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchStatement(this);
	    }
	}
	
	public sealed class SwitchStatementBeginSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public SwitchStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchStatementBeginSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KSwitch 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchStatementBeginGreen)this.Green;
				var greenToken = green.KSwitch;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchStatementBeginGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchStatementBeginGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public SwitchStatementBeginSyntax WithKSwitch(SyntaxToken kSwitch)
		{
			return this.Update(KSwitch, this.TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public SwitchStatementBeginSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KSwitch, TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public SwitchStatementBeginSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.KSwitch, this.TOpenParenthesis, Expression, this.TCloseParenthesis);
		}
	
	    public SwitchStatementBeginSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KSwitch, this.TOpenParenthesis, this.Expression, TCloseParenthesis);
		}
	
	    public SwitchStatementBeginSyntax Update(SyntaxToken kSwitch, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KSwitch != kSwitch ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchStatementBegin(kSwitch, tOpenParenthesis, expression, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchStatementBeginSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchStatementBegin(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchStatementBegin(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchStatementBegin(this);
	    }
	}
	
	public sealed class SwitchStatementEndSyntax : TestLexerModeSyntaxNode
	{
	
	    public SwitchStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchStatementEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchStatementEndGreen)this.Green;
				var greenToken = green.KEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KSwitch 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchStatementEndGreen)this.Green;
				var greenToken = green.KSwitch;
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
	
	    public SwitchStatementEndSyntax WithKEnd(SyntaxToken kEnd)
		{
			return this.Update(KEnd, this.KSwitch);
		}
	
	    public SwitchStatementEndSyntax WithKSwitch(SyntaxToken kSwitch)
		{
			return this.Update(this.KEnd, KSwitch);
		}
	
	    public SwitchStatementEndSyntax Update(SyntaxToken kEnd, SyntaxToken kSwitch)
	    {
	        if (this.KEnd != kEnd ||
				this.KSwitch != kSwitch)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchStatementEnd(kEnd, kSwitch);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchStatementEndSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchStatementEnd(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchStatementEnd(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchStatementEnd(this);
	    }
	}
	
	public sealed class SwitchBranchStatementSyntax : TestLexerModeSyntaxNode
	{
	    private SwitchBranchHeadStatementSyntax switchBranchHeadStatement;
	    private BodySyntax body;
	
	    public SwitchBranchStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchBranchStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SwitchBranchHeadStatementSyntax SwitchBranchHeadStatement 
		{ 
			get { return this.GetRed(ref this.switchBranchHeadStatement, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.switchBranchHeadStatement, 0);
				case 1: return this.GetRed(ref this.body, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.switchBranchHeadStatement;
				case 1: return this.body;
				default: return null;
	        }
	    }
	
	    public SwitchBranchStatementSyntax WithSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax switchBranchHeadStatement)
		{
			return this.Update(SwitchBranchHeadStatement, this.Body);
		}
	
	    public SwitchBranchStatementSyntax WithBody(BodySyntax body)
		{
			return this.Update(this.SwitchBranchHeadStatement, Body);
		}
	
	    public SwitchBranchStatementSyntax Update(SwitchBranchHeadStatementSyntax switchBranchHeadStatement, BodySyntax body)
	    {
	        if (this.SwitchBranchHeadStatement != switchBranchHeadStatement ||
				this.Body != body)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchBranchStatement(switchBranchHeadStatement, body);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchBranchStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchBranchStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchBranchStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchBranchStatement(this);
	    }
	}
	
	public sealed class SwitchBranchHeadStatementSyntax : TestLexerModeSyntaxNode
	{
	    private SwitchCaseOrTypeIsHeadStatementsSyntax switchCaseOrTypeIsHeadStatements;
	    private SwitchTypeAsHeadStatementSyntax switchTypeAsHeadStatement;
	
	    public SwitchBranchHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchBranchHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementsSyntax SwitchCaseOrTypeIsHeadStatements 
		{ 
			get { return this.GetRed(ref this.switchCaseOrTypeIsHeadStatements, 0); } 
		}
	    public SwitchTypeAsHeadStatementSyntax SwitchTypeAsHeadStatement 
		{ 
			get { return this.GetRed(ref this.switchTypeAsHeadStatement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.switchCaseOrTypeIsHeadStatements, 0);
				case 1: return this.GetRed(ref this.switchTypeAsHeadStatement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.switchCaseOrTypeIsHeadStatements;
				case 1: return this.switchTypeAsHeadStatement;
				default: return null;
	        }
	    }
	
	    public SwitchBranchHeadStatementSyntax WithSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax switchCaseOrTypeIsHeadStatements)
		{
			return this.Update(switchCaseOrTypeIsHeadStatements);
		}
	
	    public SwitchBranchHeadStatementSyntax WithSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax switchTypeAsHeadStatement)
		{
			return this.Update(switchTypeAsHeadStatement);
		}
	
	    public SwitchBranchHeadStatementSyntax Update(SwitchCaseOrTypeIsHeadStatementsSyntax switchCaseOrTypeIsHeadStatements)
	    {
	        if (this.SwitchCaseOrTypeIsHeadStatements != switchCaseOrTypeIsHeadStatements)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchBranchHeadStatement(switchCaseOrTypeIsHeadStatements);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchBranchHeadStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SwitchBranchHeadStatementSyntax Update(SwitchTypeAsHeadStatementSyntax switchTypeAsHeadStatement)
	    {
	        if (this.SwitchTypeAsHeadStatement != switchTypeAsHeadStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchBranchHeadStatement(switchTypeAsHeadStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchBranchHeadStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchBranchHeadStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchBranchHeadStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchBranchHeadStatement(this);
	    }
	}
	
	public sealed class SwitchCaseOrTypeIsHeadStatementsSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode switchCaseOrTypeIsHeadStatement;
	
	    public SwitchCaseOrTypeIsHeadStatementsSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementsSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<SwitchCaseOrTypeIsHeadStatementSyntax> SwitchCaseOrTypeIsHeadStatement 
		{ 
			get
			{
				var red = this.GetRed(ref this.switchCaseOrTypeIsHeadStatement, 0);
				if (red != null) return new SyntaxList<SwitchCaseOrTypeIsHeadStatementSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.switchCaseOrTypeIsHeadStatement, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.switchCaseOrTypeIsHeadStatement;
				default: return null;
	        }
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementsSyntax WithSwitchCaseOrTypeIsHeadStatement(SyntaxList<SwitchCaseOrTypeIsHeadStatementSyntax> switchCaseOrTypeIsHeadStatement)
		{
			return this.Update(SwitchCaseOrTypeIsHeadStatement);
		}
	
	    public SwitchCaseOrTypeIsHeadStatementsSyntax AddSwitchCaseOrTypeIsHeadStatement(params SwitchCaseOrTypeIsHeadStatementSyntax[] switchCaseOrTypeIsHeadStatement)
		{
			return this.WithSwitchCaseOrTypeIsHeadStatement(this.SwitchCaseOrTypeIsHeadStatement.AddRange(switchCaseOrTypeIsHeadStatement));
		}
	
	    public SwitchCaseOrTypeIsHeadStatementsSyntax Update(SyntaxList<SwitchCaseOrTypeIsHeadStatementSyntax> switchCaseOrTypeIsHeadStatement)
	    {
	        if (this.SwitchCaseOrTypeIsHeadStatement != switchCaseOrTypeIsHeadStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchCaseOrTypeIsHeadStatements(switchCaseOrTypeIsHeadStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchCaseOrTypeIsHeadStatementsSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchCaseOrTypeIsHeadStatements(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchCaseOrTypeIsHeadStatements(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchCaseOrTypeIsHeadStatements(this);
	    }
	}
	
	public sealed class SwitchCaseOrTypeIsHeadStatementSyntax : TestLexerModeSyntaxNode
	{
	    private SwitchCaseHeadStatementSyntax switchCaseHeadStatement;
	    private SwitchTypeIsHeadStatementSyntax switchTypeIsHeadStatement;
	
	    public SwitchCaseOrTypeIsHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SwitchCaseHeadStatementSyntax SwitchCaseHeadStatement 
		{ 
			get { return this.GetRed(ref this.switchCaseHeadStatement, 0); } 
		}
	    public SwitchTypeIsHeadStatementSyntax SwitchTypeIsHeadStatement 
		{ 
			get { return this.GetRed(ref this.switchTypeIsHeadStatement, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.switchCaseHeadStatement, 0);
				case 1: return this.GetRed(ref this.switchTypeIsHeadStatement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.switchCaseHeadStatement;
				case 1: return this.switchTypeIsHeadStatement;
				default: return null;
	        }
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementSyntax WithSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax switchCaseHeadStatement)
		{
			return this.Update(switchCaseHeadStatement);
		}
	
	    public SwitchCaseOrTypeIsHeadStatementSyntax WithSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax switchTypeIsHeadStatement)
		{
			return this.Update(switchTypeIsHeadStatement);
		}
	
	    public SwitchCaseOrTypeIsHeadStatementSyntax Update(SwitchCaseHeadStatementSyntax switchCaseHeadStatement)
	    {
	        if (this.SwitchCaseHeadStatement != switchCaseHeadStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchCaseOrTypeIsHeadStatement(switchCaseHeadStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchCaseOrTypeIsHeadStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SwitchCaseOrTypeIsHeadStatementSyntax Update(SwitchTypeIsHeadStatementSyntax switchTypeIsHeadStatement)
	    {
	        if (this.SwitchTypeIsHeadStatement != switchTypeIsHeadStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchCaseOrTypeIsHeadStatement(switchTypeIsHeadStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchCaseOrTypeIsHeadStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchCaseOrTypeIsHeadStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchCaseOrTypeIsHeadStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchCaseOrTypeIsHeadStatement(this);
	    }
	}
	
	public sealed class SwitchCaseHeadStatementSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionListSyntax expressionList;
	
	    public SwitchCaseHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchCaseHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KCase 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchCaseHeadStatementGreen)this.Green;
				var greenToken = green.KCase;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionListSyntax ExpressionList 
		{ 
			get { return this.GetRed(ref this.expressionList, 1); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchCaseHeadStatementGreen)this.Green;
				var greenToken = green.TColon;
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
	
	    public SwitchCaseHeadStatementSyntax WithKCase(SyntaxToken kCase)
		{
			return this.Update(KCase, this.ExpressionList, this.TColon);
		}
	
	    public SwitchCaseHeadStatementSyntax WithExpressionList(ExpressionListSyntax expressionList)
		{
			return this.Update(this.KCase, ExpressionList, this.TColon);
		}
	
	    public SwitchCaseHeadStatementSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KCase, this.ExpressionList, TColon);
		}
	
	    public SwitchCaseHeadStatementSyntax Update(SyntaxToken kCase, ExpressionListSyntax expressionList, SyntaxToken tColon)
	    {
	        if (this.KCase != kCase ||
				this.ExpressionList != expressionList ||
				this.TColon != tColon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchCaseHeadStatement(kCase, expressionList, tColon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchCaseHeadStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchCaseHeadStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchCaseHeadStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchCaseHeadStatement(this);
	    }
	}
	
	public sealed class SwitchTypeIsHeadStatementSyntax : TestLexerModeSyntaxNode
	{
	    private TypeReferenceListSyntax typeReferenceList;
	
	    public SwitchTypeIsHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchTypeIsHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchTypeIsHeadStatementGreen)this.Green;
				var greenToken = green.KType;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KIs 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchTypeIsHeadStatementGreen)this.Green;
				var greenToken = green.KIs;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeReferenceListSyntax TypeReferenceList 
		{ 
			get { return this.GetRed(ref this.typeReferenceList, 2); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchTypeIsHeadStatementGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.typeReferenceList, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.typeReferenceList;
				default: return null;
	        }
	    }
	
	    public SwitchTypeIsHeadStatementSyntax WithKType(SyntaxToken kType)
		{
			return this.Update(KType, this.KIs, this.TypeReferenceList, this.TColon);
		}
	
	    public SwitchTypeIsHeadStatementSyntax WithKIs(SyntaxToken kIs)
		{
			return this.Update(this.KType, KIs, this.TypeReferenceList, this.TColon);
		}
	
	    public SwitchTypeIsHeadStatementSyntax WithTypeReferenceList(TypeReferenceListSyntax typeReferenceList)
		{
			return this.Update(this.KType, this.KIs, TypeReferenceList, this.TColon);
		}
	
	    public SwitchTypeIsHeadStatementSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KType, this.KIs, this.TypeReferenceList, TColon);
		}
	
	    public SwitchTypeIsHeadStatementSyntax Update(SyntaxToken kType, SyntaxToken kIs, TypeReferenceListSyntax typeReferenceList, SyntaxToken tColon)
	    {
	        if (this.KType != kType ||
				this.KIs != kIs ||
				this.TypeReferenceList != typeReferenceList ||
				this.TColon != tColon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchTypeIsHeadStatement(kType, kIs, typeReferenceList, tColon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchTypeIsHeadStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchTypeIsHeadStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchTypeIsHeadStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchTypeIsHeadStatement(this);
	    }
	}
	
	public sealed class SwitchTypeAsHeadStatementSyntax : TestLexerModeSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	
	    public SwitchTypeAsHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchTypeAsHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchTypeAsHeadStatementGreen)this.Green;
				var greenToken = green.KType;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken KAs 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchTypeAsHeadStatementGreen)this.Green;
				var greenToken = green.KAs;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchTypeAsHeadStatementGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public SwitchTypeAsHeadStatementSyntax WithKType(SyntaxToken kType)
		{
			return this.Update(KType, this.KAs, this.TypeReference, this.TColon);
		}
	
	    public SwitchTypeAsHeadStatementSyntax WithKAs(SyntaxToken kAs)
		{
			return this.Update(this.KType, KAs, this.TypeReference, this.TColon);
		}
	
	    public SwitchTypeAsHeadStatementSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KType, this.KAs, TypeReference, this.TColon);
		}
	
	    public SwitchTypeAsHeadStatementSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KType, this.KAs, this.TypeReference, TColon);
		}
	
	    public SwitchTypeAsHeadStatementSyntax Update(SyntaxToken kType, SyntaxToken kAs, TypeReferenceSyntax typeReference, SyntaxToken tColon)
	    {
	        if (this.KType != kType ||
				this.KAs != kAs ||
				this.TypeReference != typeReference ||
				this.TColon != tColon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchTypeAsHeadStatement(kType, kAs, typeReference, tColon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchTypeAsHeadStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchTypeAsHeadStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchTypeAsHeadStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchTypeAsHeadStatement(this);
	    }
	}
	
	public sealed class SwitchDefaultStatementSyntax : TestLexerModeSyntaxNode
	{
	    private SwitchDefaultHeadStatementSyntax switchDefaultHeadStatement;
	    private BodySyntax body;
	
	    public SwitchDefaultStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchDefaultStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SwitchDefaultHeadStatementSyntax SwitchDefaultHeadStatement 
		{ 
			get { return this.GetRed(ref this.switchDefaultHeadStatement, 0); } 
		}
	    public BodySyntax Body 
		{ 
			get { return this.GetRed(ref this.body, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.switchDefaultHeadStatement, 0);
				case 1: return this.GetRed(ref this.body, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.switchDefaultHeadStatement;
				case 1: return this.body;
				default: return null;
	        }
	    }
	
	    public SwitchDefaultStatementSyntax WithSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax switchDefaultHeadStatement)
		{
			return this.Update(SwitchDefaultHeadStatement, this.Body);
		}
	
	    public SwitchDefaultStatementSyntax WithBody(BodySyntax body)
		{
			return this.Update(this.SwitchDefaultHeadStatement, Body);
		}
	
	    public SwitchDefaultStatementSyntax Update(SwitchDefaultHeadStatementSyntax switchDefaultHeadStatement, BodySyntax body)
	    {
	        if (this.SwitchDefaultHeadStatement != switchDefaultHeadStatement ||
				this.Body != body)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchDefaultStatement(switchDefaultHeadStatement, body);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchDefaultStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchDefaultStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchDefaultStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchDefaultStatement(this);
	    }
	}
	
	public sealed class SwitchDefaultHeadStatementSyntax : TestLexerModeSyntaxNode
	{
	
	    public SwitchDefaultHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SwitchDefaultHeadStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KDefault 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchDefaultHeadStatementGreen)this.Green;
				var greenToken = green.KDefault;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.SwitchDefaultHeadStatementGreen)this.Green;
				var greenToken = green.TColon;
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
	
	    public SwitchDefaultHeadStatementSyntax WithKDefault(SyntaxToken kDefault)
		{
			return this.Update(KDefault, this.TColon);
		}
	
	    public SwitchDefaultHeadStatementSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.KDefault, TColon);
		}
	
	    public SwitchDefaultHeadStatementSyntax Update(SyntaxToken kDefault, SyntaxToken tColon)
	    {
	        if (this.KDefault != kDefault ||
				this.TColon != tColon)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SwitchDefaultHeadStatement(kDefault, tColon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SwitchDefaultHeadStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSwitchDefaultHeadStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSwitchDefaultHeadStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSwitchDefaultHeadStatement(this);
	    }
	}
	
	public sealed class TemplateDeclarationSyntax : TestLexerModeSyntaxNode
	{
	    private TemplateSignatureSyntax templateSignature;
	    private TemplateBodySyntax templateBody;
	
	    public TemplateDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TemplateDeclarationSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TemplateSignatureSyntax TemplateSignature 
		{ 
			get { return this.GetRed(ref this.templateSignature, 0); } 
		}
	    public TemplateBodySyntax TemplateBody 
		{ 
			get { return this.GetRed(ref this.templateBody, 1); } 
		}
	    public SyntaxToken KEndTemplate 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TemplateDeclarationGreen)this.Green;
				var greenToken = green.KEndTemplate;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.templateSignature, 0);
				case 1: return this.GetRed(ref this.templateBody, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.templateSignature;
				case 1: return this.templateBody;
				default: return null;
	        }
	    }
	
	    public TemplateDeclarationSyntax WithTemplateSignature(TemplateSignatureSyntax templateSignature)
		{
			return this.Update(TemplateSignature, this.TemplateBody, this.KEndTemplate);
		}
	
	    public TemplateDeclarationSyntax WithTemplateBody(TemplateBodySyntax templateBody)
		{
			return this.Update(this.TemplateSignature, TemplateBody, this.KEndTemplate);
		}
	
	    public TemplateDeclarationSyntax WithKEndTemplate(SyntaxToken kEndTemplate)
		{
			return this.Update(this.TemplateSignature, this.TemplateBody, KEndTemplate);
		}
	
	    public TemplateDeclarationSyntax Update(TemplateSignatureSyntax templateSignature, TemplateBodySyntax templateBody, SyntaxToken kEndTemplate)
	    {
	        if (this.TemplateSignature != templateSignature ||
				this.TemplateBody != templateBody ||
				this.KEndTemplate != kEndTemplate)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateDeclaration(templateSignature, templateBody, kEndTemplate);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateDeclarationSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTemplateDeclaration(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTemplateDeclaration(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTemplateDeclaration(this);
	    }
	}
	
	public sealed class TemplateSignatureSyntax : TestLexerModeSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private ParamListSyntax paramList;
	
	    public TemplateSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TemplateSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTemplate 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TemplateSignatureGreen)this.Green;
				var greenToken = green.KTemplate;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TemplateSignatureGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ParamListSyntax ParamList 
		{ 
			get { return this.GetRed(ref this.paramList, 3); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TemplateSignatureGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.identifier, 1);
				case 3: return this.GetRed(ref this.paramList, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.identifier;
				case 3: return this.paramList;
				default: return null;
	        }
	    }
	
	    public TemplateSignatureSyntax WithKTemplate(SyntaxToken kTemplate)
		{
			return this.Update(KTemplate, this.Identifier, this.TOpenParenthesis, this.ParamList, this.TCloseParenthesis);
		}
	
	    public TemplateSignatureSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.KTemplate, Identifier, this.TOpenParenthesis, this.ParamList, this.TCloseParenthesis);
		}
	
	    public TemplateSignatureSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KTemplate, this.Identifier, TOpenParenthesis, this.ParamList, this.TCloseParenthesis);
		}
	
	    public TemplateSignatureSyntax WithParamList(ParamListSyntax paramList)
		{
			return this.Update(this.KTemplate, this.Identifier, this.TOpenParenthesis, ParamList, this.TCloseParenthesis);
		}
	
	    public TemplateSignatureSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KTemplate, this.Identifier, this.TOpenParenthesis, this.ParamList, TCloseParenthesis);
		}
	
	    public TemplateSignatureSyntax Update(SyntaxToken kTemplate, IdentifierSyntax identifier, SyntaxToken tOpenParenthesis, ParamListSyntax paramList, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KTemplate != kTemplate ||
				this.Identifier != identifier ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ParamList != paramList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateSignature(kTemplate, identifier, tOpenParenthesis, paramList, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateSignatureSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTemplateSignature(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTemplateSignature(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTemplateSignature(this);
	    }
	}
	
	public sealed class TemplateBodySyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode templateContentLine;
	
	    public TemplateBodySyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TemplateBodySyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<TemplateContentLineSyntax> TemplateContentLine 
		{ 
			get
			{
				var red = this.GetRed(ref this.templateContentLine, 0);
				if (red != null) return new SyntaxList<TemplateContentLineSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.templateContentLine, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.templateContentLine;
				default: return null;
	        }
	    }
	
	    public TemplateBodySyntax WithTemplateContentLine(SyntaxList<TemplateContentLineSyntax> templateContentLine)
		{
			return this.Update(TemplateContentLine);
		}
	
	    public TemplateBodySyntax AddTemplateContentLine(params TemplateContentLineSyntax[] templateContentLine)
		{
			return this.WithTemplateContentLine(this.TemplateContentLine.AddRange(templateContentLine));
		}
	
	    public TemplateBodySyntax Update(SyntaxList<TemplateContentLineSyntax> templateContentLine)
	    {
	        if (this.TemplateContentLine != templateContentLine)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateBody(templateContentLine);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateBodySyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTemplateBody(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTemplateBody(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTemplateBody(this);
	    }
	}
	
	public sealed class TemplateContentLineSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode templateContent;
	    private TemplateLineEndSyntax templateLineEnd;
	
	    public TemplateContentLineSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TemplateContentLineSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<TemplateContentSyntax> TemplateContent 
		{ 
			get
			{
				var red = this.GetRed(ref this.templateContent, 0);
				if (red != null) return new SyntaxList<TemplateContentSyntax>(red);
				return default;
			} 
		}
	    public TemplateLineEndSyntax TemplateLineEnd 
		{ 
			get { return this.GetRed(ref this.templateLineEnd, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.templateContent, 0);
				case 1: return this.GetRed(ref this.templateLineEnd, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.templateContent;
				case 1: return this.templateLineEnd;
				default: return null;
	        }
	    }
	
	    public TemplateContentLineSyntax WithTemplateContent(SyntaxList<TemplateContentSyntax> templateContent)
		{
			return this.Update(TemplateContent, this.TemplateLineEnd);
		}
	
	    public TemplateContentLineSyntax AddTemplateContent(params TemplateContentSyntax[] templateContent)
		{
			return this.WithTemplateContent(this.TemplateContent.AddRange(templateContent));
		}
	
	    public TemplateContentLineSyntax WithTemplateLineEnd(TemplateLineEndSyntax templateLineEnd)
		{
			return this.Update(this.TemplateContent, TemplateLineEnd);
		}
	
	    public TemplateContentLineSyntax Update(SyntaxList<TemplateContentSyntax> templateContent, TemplateLineEndSyntax templateLineEnd)
	    {
	        if (this.TemplateContent != templateContent ||
				this.TemplateLineEnd != templateLineEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateContentLine(templateContent, templateLineEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateContentLineSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTemplateContentLine(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTemplateContentLine(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTemplateContentLine(this);
	    }
	}
	
	public sealed class TemplateContentSyntax : TestLexerModeSyntaxNode
	{
	    private TemplateOutputxSyntax templateOutputx;
	    private TemplateStatementStartEndSyntax templateStatementStartEnd;
	
	    public TemplateContentSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TemplateContentSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TemplateOutputxSyntax TemplateOutputx 
		{ 
			get { return this.GetRed(ref this.templateOutputx, 0); } 
		}
	    public TemplateStatementStartEndSyntax TemplateStatementStartEnd 
		{ 
			get { return this.GetRed(ref this.templateStatementStartEnd, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.templateOutputx, 0);
				case 1: return this.GetRed(ref this.templateStatementStartEnd, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.templateOutputx;
				case 1: return this.templateStatementStartEnd;
				default: return null;
	        }
	    }
	
	    public TemplateContentSyntax WithTemplateOutputx(TemplateOutputxSyntax templateOutputx)
		{
			return this.Update(templateOutputx);
		}
	
	    public TemplateContentSyntax WithTemplateStatementStartEnd(TemplateStatementStartEndSyntax templateStatementStartEnd)
		{
			return this.Update(templateStatementStartEnd);
		}
	
	    public TemplateContentSyntax Update(TemplateOutputxSyntax templateOutputx)
	    {
	        if (this.TemplateOutputx != templateOutputx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateContent(templateOutputx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateContentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateContentSyntax Update(TemplateStatementStartEndSyntax templateStatementStartEnd)
	    {
	        if (this.TemplateStatementStartEnd != templateStatementStartEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateContent(templateStatementStartEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateContentSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTemplateContent(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTemplateContent(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTemplateContent(this);
	    }
	}
	
	public sealed class TemplateOutputxSyntax : TestLexerModeSyntaxNode
	{
	
	    public TemplateOutputxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TemplateOutputxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TemplateOutput 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TemplateOutputxGreen)this.Green;
				var greenToken = green.TemplateOutput;
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
	
	    public TemplateOutputxSyntax WithTemplateOutput(SyntaxToken templateOutput)
		{
			return this.Update(TemplateOutput);
		}
	
	    public TemplateOutputxSyntax Update(SyntaxToken templateOutput)
	    {
	        if (this.TemplateOutput != templateOutput)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateOutputx(templateOutput);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateOutputxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTemplateOutputx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTemplateOutputx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTemplateOutputx(this);
	    }
	}
	
	public sealed class TemplateLineEndSyntax : TestLexerModeSyntaxNode
	{
	
	    public TemplateLineEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TemplateLineEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TemplateLineEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TemplateLineEndGreen)this.Green;
				var greenToken = green.TemplateLineEnd;
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
	
	    public TemplateLineEndSyntax WithTemplateLineEnd(SyntaxToken templateLineEnd)
		{
			return this.Update(TemplateLineEnd);
		}
	
	    public TemplateLineEndSyntax Update(SyntaxToken templateLineEnd)
	    {
	        if (this.TemplateLineEnd != templateLineEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateLineEnd(templateLineEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateLineEndSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTemplateLineEnd(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTemplateLineEnd(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTemplateLineEnd(this);
	    }
	}
	
	public sealed class TemplateStatementStartEndSyntax : TestLexerModeSyntaxNode
	{
	    private TemplateStatementSyntax templateStatement;
	
	    public TemplateStatementStartEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TemplateStatementStartEndSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TemplateStatementStart 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TemplateStatementStartEndGreen)this.Green;
				var greenToken = green.TemplateStatementStart;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TemplateStatementSyntax TemplateStatement 
		{ 
			get { return this.GetRed(ref this.templateStatement, 1); } 
		}
	    public SyntaxToken TemplateStatementEnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TemplateStatementStartEndGreen)this.Green;
				var greenToken = green.TemplateStatementEnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.templateStatement, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.templateStatement;
				default: return null;
	        }
	    }
	
	    public TemplateStatementStartEndSyntax WithTemplateStatementStart(SyntaxToken templateStatementStart)
		{
			return this.Update(TemplateStatementStart, this.TemplateStatement, this.TemplateStatementEnd);
		}
	
	    public TemplateStatementStartEndSyntax WithTemplateStatement(TemplateStatementSyntax templateStatement)
		{
			return this.Update(this.TemplateStatementStart, TemplateStatement, this.TemplateStatementEnd);
		}
	
	    public TemplateStatementStartEndSyntax WithTemplateStatementEnd(SyntaxToken templateStatementEnd)
		{
			return this.Update(this.TemplateStatementStart, this.TemplateStatement, TemplateStatementEnd);
		}
	
	    public TemplateStatementStartEndSyntax Update(SyntaxToken templateStatementStart, TemplateStatementSyntax templateStatement, SyntaxToken templateStatementEnd)
	    {
	        if (this.TemplateStatementStart != templateStatementStart ||
				this.TemplateStatement != templateStatement ||
				this.TemplateStatementEnd != templateStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatementStartEnd(templateStatementStart, templateStatement, templateStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementStartEndSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTemplateStatementStartEnd(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTemplateStatementStartEnd(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTemplateStatementStartEnd(this);
	    }
	}
	
	public sealed class TemplateStatementSyntax : TestLexerModeSyntaxNode
	{
	    private VoidStatementSyntax voidStatement;
	    private VariableDeclarationStatementSyntax variableDeclarationStatement;
	    private ExpressionStatementSyntax expressionStatement;
	    private IfStatementBeginSyntax ifStatementBegin;
	    private ElseIfStatementSyntax elseIfStatement;
	    private IfStatementElseSyntax ifStatementElse;
	    private IfStatementEndSyntax ifStatementEnd;
	    private ForStatementBeginSyntax forStatementBegin;
	    private ForStatementEndSyntax forStatementEnd;
	    private WhileStatementBeginSyntax whileStatementBegin;
	    private WhileStatementEndSyntax whileStatementEnd;
	    private RepeatStatementBeginSyntax repeatStatementBegin;
	    private RepeatStatementEndSyntax repeatStatementEnd;
	    private LoopStatementBeginSyntax loopStatementBegin;
	    private LoopStatementEndSyntax loopStatementEnd;
	    private SwitchStatementBeginSyntax switchStatementBegin;
	    private SwitchStatementEndSyntax switchStatementEnd;
	    private SwitchBranchHeadStatementSyntax switchBranchHeadStatement;
	    private SwitchDefaultHeadStatementSyntax switchDefaultHeadStatement;
	
	    public TemplateStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TemplateStatementSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public VoidStatementSyntax VoidStatement 
		{ 
			get { return this.GetRed(ref this.voidStatement, 0); } 
		}
	    public VariableDeclarationStatementSyntax VariableDeclarationStatement 
		{ 
			get { return this.GetRed(ref this.variableDeclarationStatement, 1); } 
		}
	    public ExpressionStatementSyntax ExpressionStatement 
		{ 
			get { return this.GetRed(ref this.expressionStatement, 2); } 
		}
	    public IfStatementBeginSyntax IfStatementBegin 
		{ 
			get { return this.GetRed(ref this.ifStatementBegin, 3); } 
		}
	    public ElseIfStatementSyntax ElseIfStatement 
		{ 
			get { return this.GetRed(ref this.elseIfStatement, 4); } 
		}
	    public IfStatementElseSyntax IfStatementElse 
		{ 
			get { return this.GetRed(ref this.ifStatementElse, 5); } 
		}
	    public IfStatementEndSyntax IfStatementEnd 
		{ 
			get { return this.GetRed(ref this.ifStatementEnd, 6); } 
		}
	    public ForStatementBeginSyntax ForStatementBegin 
		{ 
			get { return this.GetRed(ref this.forStatementBegin, 7); } 
		}
	    public ForStatementEndSyntax ForStatementEnd 
		{ 
			get { return this.GetRed(ref this.forStatementEnd, 8); } 
		}
	    public WhileStatementBeginSyntax WhileStatementBegin 
		{ 
			get { return this.GetRed(ref this.whileStatementBegin, 9); } 
		}
	    public WhileStatementEndSyntax WhileStatementEnd 
		{ 
			get { return this.GetRed(ref this.whileStatementEnd, 10); } 
		}
	    public RepeatStatementBeginSyntax RepeatStatementBegin 
		{ 
			get { return this.GetRed(ref this.repeatStatementBegin, 11); } 
		}
	    public RepeatStatementEndSyntax RepeatStatementEnd 
		{ 
			get { return this.GetRed(ref this.repeatStatementEnd, 12); } 
		}
	    public LoopStatementBeginSyntax LoopStatementBegin 
		{ 
			get { return this.GetRed(ref this.loopStatementBegin, 13); } 
		}
	    public LoopStatementEndSyntax LoopStatementEnd 
		{ 
			get { return this.GetRed(ref this.loopStatementEnd, 14); } 
		}
	    public SwitchStatementBeginSyntax SwitchStatementBegin 
		{ 
			get { return this.GetRed(ref this.switchStatementBegin, 15); } 
		}
	    public SwitchStatementEndSyntax SwitchStatementEnd 
		{ 
			get { return this.GetRed(ref this.switchStatementEnd, 16); } 
		}
	    public SwitchBranchHeadStatementSyntax SwitchBranchHeadStatement 
		{ 
			get { return this.GetRed(ref this.switchBranchHeadStatement, 17); } 
		}
	    public SwitchDefaultHeadStatementSyntax SwitchDefaultHeadStatement 
		{ 
			get { return this.GetRed(ref this.switchDefaultHeadStatement, 18); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.voidStatement, 0);
				case 1: return this.GetRed(ref this.variableDeclarationStatement, 1);
				case 2: return this.GetRed(ref this.expressionStatement, 2);
				case 3: return this.GetRed(ref this.ifStatementBegin, 3);
				case 4: return this.GetRed(ref this.elseIfStatement, 4);
				case 5: return this.GetRed(ref this.ifStatementElse, 5);
				case 6: return this.GetRed(ref this.ifStatementEnd, 6);
				case 7: return this.GetRed(ref this.forStatementBegin, 7);
				case 8: return this.GetRed(ref this.forStatementEnd, 8);
				case 9: return this.GetRed(ref this.whileStatementBegin, 9);
				case 10: return this.GetRed(ref this.whileStatementEnd, 10);
				case 11: return this.GetRed(ref this.repeatStatementBegin, 11);
				case 12: return this.GetRed(ref this.repeatStatementEnd, 12);
				case 13: return this.GetRed(ref this.loopStatementBegin, 13);
				case 14: return this.GetRed(ref this.loopStatementEnd, 14);
				case 15: return this.GetRed(ref this.switchStatementBegin, 15);
				case 16: return this.GetRed(ref this.switchStatementEnd, 16);
				case 17: return this.GetRed(ref this.switchBranchHeadStatement, 17);
				case 18: return this.GetRed(ref this.switchDefaultHeadStatement, 18);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.voidStatement;
				case 1: return this.variableDeclarationStatement;
				case 2: return this.expressionStatement;
				case 3: return this.ifStatementBegin;
				case 4: return this.elseIfStatement;
				case 5: return this.ifStatementElse;
				case 6: return this.ifStatementEnd;
				case 7: return this.forStatementBegin;
				case 8: return this.forStatementEnd;
				case 9: return this.whileStatementBegin;
				case 10: return this.whileStatementEnd;
				case 11: return this.repeatStatementBegin;
				case 12: return this.repeatStatementEnd;
				case 13: return this.loopStatementBegin;
				case 14: return this.loopStatementEnd;
				case 15: return this.switchStatementBegin;
				case 16: return this.switchStatementEnd;
				case 17: return this.switchBranchHeadStatement;
				case 18: return this.switchDefaultHeadStatement;
				default: return null;
	        }
	    }
	
	    public TemplateStatementSyntax WithVoidStatement(VoidStatementSyntax voidStatement)
		{
			return this.Update(voidStatement);
		}
	
	    public TemplateStatementSyntax WithVariableDeclarationStatement(VariableDeclarationStatementSyntax variableDeclarationStatement)
		{
			return this.Update(variableDeclarationStatement);
		}
	
	    public TemplateStatementSyntax WithExpressionStatement(ExpressionStatementSyntax expressionStatement)
		{
			return this.Update(expressionStatement);
		}
	
	    public TemplateStatementSyntax WithIfStatementBegin(IfStatementBeginSyntax ifStatementBegin)
		{
			return this.Update(ifStatementBegin);
		}
	
	    public TemplateStatementSyntax WithElseIfStatement(ElseIfStatementSyntax elseIfStatement)
		{
			return this.Update(elseIfStatement);
		}
	
	    public TemplateStatementSyntax WithIfStatementElse(IfStatementElseSyntax ifStatementElse)
		{
			return this.Update(ifStatementElse);
		}
	
	    public TemplateStatementSyntax WithIfStatementEnd(IfStatementEndSyntax ifStatementEnd)
		{
			return this.Update(ifStatementEnd);
		}
	
	    public TemplateStatementSyntax WithForStatementBegin(ForStatementBeginSyntax forStatementBegin)
		{
			return this.Update(forStatementBegin);
		}
	
	    public TemplateStatementSyntax WithForStatementEnd(ForStatementEndSyntax forStatementEnd)
		{
			return this.Update(forStatementEnd);
		}
	
	    public TemplateStatementSyntax WithWhileStatementBegin(WhileStatementBeginSyntax whileStatementBegin)
		{
			return this.Update(whileStatementBegin);
		}
	
	    public TemplateStatementSyntax WithWhileStatementEnd(WhileStatementEndSyntax whileStatementEnd)
		{
			return this.Update(whileStatementEnd);
		}
	
	    public TemplateStatementSyntax WithRepeatStatementBegin(RepeatStatementBeginSyntax repeatStatementBegin)
		{
			return this.Update(repeatStatementBegin);
		}
	
	    public TemplateStatementSyntax WithRepeatStatementEnd(RepeatStatementEndSyntax repeatStatementEnd)
		{
			return this.Update(repeatStatementEnd);
		}
	
	    public TemplateStatementSyntax WithLoopStatementBegin(LoopStatementBeginSyntax loopStatementBegin)
		{
			return this.Update(loopStatementBegin);
		}
	
	    public TemplateStatementSyntax WithLoopStatementEnd(LoopStatementEndSyntax loopStatementEnd)
		{
			return this.Update(loopStatementEnd);
		}
	
	    public TemplateStatementSyntax WithSwitchStatementBegin(SwitchStatementBeginSyntax switchStatementBegin)
		{
			return this.Update(switchStatementBegin);
		}
	
	    public TemplateStatementSyntax WithSwitchStatementEnd(SwitchStatementEndSyntax switchStatementEnd)
		{
			return this.Update(switchStatementEnd);
		}
	
	    public TemplateStatementSyntax WithSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax switchBranchHeadStatement)
		{
			return this.Update(switchBranchHeadStatement);
		}
	
	    public TemplateStatementSyntax WithSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax switchDefaultHeadStatement)
		{
			return this.Update(switchDefaultHeadStatement);
		}
	
	    public TemplateStatementSyntax Update(VoidStatementSyntax voidStatement)
	    {
	        if (this.VoidStatement != voidStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(voidStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(VariableDeclarationStatementSyntax variableDeclarationStatement)
	    {
	        if (this.VariableDeclarationStatement != variableDeclarationStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(variableDeclarationStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(ExpressionStatementSyntax expressionStatement)
	    {
	        if (this.ExpressionStatement != expressionStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(expressionStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(IfStatementBeginSyntax ifStatementBegin)
	    {
	        if (this.IfStatementBegin != ifStatementBegin)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(ifStatementBegin);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(ElseIfStatementSyntax elseIfStatement)
	    {
	        if (this.ElseIfStatement != elseIfStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(elseIfStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(IfStatementElseSyntax ifStatementElse)
	    {
	        if (this.IfStatementElse != ifStatementElse)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(ifStatementElse);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(IfStatementEndSyntax ifStatementEnd)
	    {
	        if (this.IfStatementEnd != ifStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(ifStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(ForStatementBeginSyntax forStatementBegin)
	    {
	        if (this.ForStatementBegin != forStatementBegin)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(forStatementBegin);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(ForStatementEndSyntax forStatementEnd)
	    {
	        if (this.ForStatementEnd != forStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(forStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(WhileStatementBeginSyntax whileStatementBegin)
	    {
	        if (this.WhileStatementBegin != whileStatementBegin)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(whileStatementBegin);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(WhileStatementEndSyntax whileStatementEnd)
	    {
	        if (this.WhileStatementEnd != whileStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(whileStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(RepeatStatementBeginSyntax repeatStatementBegin)
	    {
	        if (this.RepeatStatementBegin != repeatStatementBegin)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(repeatStatementBegin);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(RepeatStatementEndSyntax repeatStatementEnd)
	    {
	        if (this.RepeatStatementEnd != repeatStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(repeatStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(LoopStatementBeginSyntax loopStatementBegin)
	    {
	        if (this.LoopStatementBegin != loopStatementBegin)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(loopStatementBegin);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(LoopStatementEndSyntax loopStatementEnd)
	    {
	        if (this.LoopStatementEnd != loopStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(loopStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(SwitchStatementBeginSyntax switchStatementBegin)
	    {
	        if (this.SwitchStatementBegin != switchStatementBegin)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(switchStatementBegin);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(SwitchStatementEndSyntax switchStatementEnd)
	    {
	        if (this.SwitchStatementEnd != switchStatementEnd)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(switchStatementEnd);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(SwitchBranchHeadStatementSyntax switchBranchHeadStatement)
	    {
	        if (this.SwitchBranchHeadStatement != switchBranchHeadStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(switchBranchHeadStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TemplateStatementSyntax Update(SwitchDefaultHeadStatementSyntax switchDefaultHeadStatement)
	    {
	        if (this.SwitchDefaultHeadStatement != switchDefaultHeadStatement)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TemplateStatement(switchDefaultHeadStatement);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TemplateStatementSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTemplateStatement(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTemplateStatement(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTemplateStatement(this);
	    }
	}
	
	public sealed class TypeArgumentListSyntax : TestLexerModeSyntaxNode
	{
	    private TypeReferenceListSyntax typeReferenceList;
	
	    public TypeArgumentListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeArgumentListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TLessThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeArgumentListGreen)this.Green;
				var greenToken = green.TLessThan;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TypeReferenceListSyntax TypeReferenceList 
		{ 
			get { return this.GetRed(ref this.typeReferenceList, 1); } 
		}
	    public SyntaxToken TGreaterThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeArgumentListGreen)this.Green;
				var greenToken = green.TGreaterThan;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.typeReferenceList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.typeReferenceList;
				default: return null;
	        }
	    }
	
	    public TypeArgumentListSyntax WithTLessThan(SyntaxToken tLessThan)
		{
			return this.Update(TLessThan, this.TypeReferenceList, this.TGreaterThan);
		}
	
	    public TypeArgumentListSyntax WithTypeReferenceList(TypeReferenceListSyntax typeReferenceList)
		{
			return this.Update(this.TLessThan, TypeReferenceList, this.TGreaterThan);
		}
	
	    public TypeArgumentListSyntax WithTGreaterThan(SyntaxToken tGreaterThan)
		{
			return this.Update(this.TLessThan, this.TypeReferenceList, TGreaterThan);
		}
	
	    public TypeArgumentListSyntax Update(SyntaxToken tLessThan, TypeReferenceListSyntax typeReferenceList, SyntaxToken tGreaterThan)
	    {
	        if (this.TLessThan != tLessThan ||
				this.TypeReferenceList != typeReferenceList ||
				this.TGreaterThan != tGreaterThan)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypeArgumentList(tLessThan, typeReferenceList, tGreaterThan);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeArgumentListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeArgumentList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeArgumentList(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeArgumentList(this);
	    }
	}
	
	public sealed class PredefinedTypeSyntax : TestLexerModeSyntaxNode
	{
	
	    public PredefinedTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PredefinedTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken PredefinedType 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.PredefinedTypeGreen)this.Green;
				var greenToken = green.PredefinedType;
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
	
	    public PredefinedTypeSyntax WithPredefinedType(SyntaxToken predefinedType)
		{
			return this.Update(PredefinedType);
		}
	
	    public PredefinedTypeSyntax Update(SyntaxToken predefinedType)
	    {
	        if (this.PredefinedType != predefinedType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.PredefinedType(predefinedType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PredefinedTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPredefinedType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPredefinedType(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitPredefinedType(this);
	    }
	}
	
	public sealed class TypeReferenceListSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode typeReference;
	
	    public TypeReferenceListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeReferenceListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	
	    public TypeReferenceListSyntax WithTypeReference(SeparatedSyntaxList<TypeReferenceSyntax> typeReference)
		{
			return this.Update(TypeReference);
		}
	
	    public TypeReferenceListSyntax AddTypeReference(params TypeReferenceSyntax[] typeReference)
		{
			return this.WithTypeReference(this.TypeReference.AddRange(typeReference));
		}
	
	    public TypeReferenceListSyntax Update(SeparatedSyntaxList<TypeReferenceSyntax> typeReference)
	    {
	        if (this.TypeReference != typeReference)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypeReferenceList(typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeReferenceList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeReferenceList(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeReferenceList(this);
	    }
	}
	
	public sealed class TypeReferenceSyntax : TestLexerModeSyntaxNode
	{
	    private ArrayTypeSyntax arrayType;
	    private NullableTypeSyntax nullableType;
	    private GenericTypeSyntax genericType;
	    private SimpleTypeSyntax simpleType;
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeReferenceSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ArrayTypeSyntax ArrayType 
		{ 
			get { return this.GetRed(ref this.arrayType, 0); } 
		}
	    public NullableTypeSyntax NullableType 
		{ 
			get { return this.GetRed(ref this.nullableType, 1); } 
		}
	    public GenericTypeSyntax GenericType 
		{ 
			get { return this.GetRed(ref this.genericType, 2); } 
		}
	    public SimpleTypeSyntax SimpleType 
		{ 
			get { return this.GetRed(ref this.simpleType, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.arrayType, 0);
				case 1: return this.GetRed(ref this.nullableType, 1);
				case 2: return this.GetRed(ref this.genericType, 2);
				case 3: return this.GetRed(ref this.simpleType, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.arrayType;
				case 1: return this.nullableType;
				case 2: return this.genericType;
				case 3: return this.simpleType;
				default: return null;
	        }
	    }
	
	    public TypeReferenceSyntax WithArrayType(ArrayTypeSyntax arrayType)
		{
			return this.Update(arrayType);
		}
	
	    public TypeReferenceSyntax WithNullableType(NullableTypeSyntax nullableType)
		{
			return this.Update(nullableType);
		}
	
	    public TypeReferenceSyntax WithGenericType(GenericTypeSyntax genericType)
		{
			return this.Update(genericType);
		}
	
	    public TypeReferenceSyntax WithSimpleType(SimpleTypeSyntax simpleType)
		{
			return this.Update(simpleType);
		}
	
	    public TypeReferenceSyntax Update(ArrayTypeSyntax arrayType)
	    {
	        if (this.ArrayType != arrayType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypeReference(arrayType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TypeReferenceSyntax Update(NullableTypeSyntax nullableType)
	    {
	        if (this.NullableType != nullableType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypeReference(nullableType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TypeReferenceSyntax Update(GenericTypeSyntax genericType)
	    {
	        if (this.GenericType != genericType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypeReference(genericType);
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypeReference(simpleType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeReference(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeReference(this);
	    }
	}
	
	public sealed class ArrayTypeSyntax : TestLexerModeSyntaxNode
	{
	    private ArrayItemTypeSyntax arrayItemType;
	    private RankSpecifiersSyntax rankSpecifiers;
	
	    public ArrayTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArrayTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ArrayItemTypeSyntax ArrayItemType 
		{ 
			get { return this.GetRed(ref this.arrayItemType, 0); } 
		}
	    public RankSpecifiersSyntax RankSpecifiers 
		{ 
			get { return this.GetRed(ref this.rankSpecifiers, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.arrayItemType, 0);
				case 1: return this.GetRed(ref this.rankSpecifiers, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.arrayItemType;
				case 1: return this.rankSpecifiers;
				default: return null;
	        }
	    }
	
	    public ArrayTypeSyntax WithArrayItemType(ArrayItemTypeSyntax arrayItemType)
		{
			return this.Update(ArrayItemType, this.RankSpecifiers);
		}
	
	    public ArrayTypeSyntax WithRankSpecifiers(RankSpecifiersSyntax rankSpecifiers)
		{
			return this.Update(this.ArrayItemType, RankSpecifiers);
		}
	
	    public ArrayTypeSyntax Update(ArrayItemTypeSyntax arrayItemType, RankSpecifiersSyntax rankSpecifiers)
	    {
	        if (this.ArrayItemType != arrayItemType ||
				this.RankSpecifiers != rankSpecifiers)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ArrayType(arrayItemType, rankSpecifiers);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrayType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrayType(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitArrayType(this);
	    }
	}
	
	public sealed class ArrayItemTypeSyntax : TestLexerModeSyntaxNode
	{
	    private NullableTypeSyntax nullableType;
	    private GenericTypeSyntax genericType;
	    private SimpleTypeSyntax simpleType;
	
	    public ArrayItemTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ArrayItemTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NullableTypeSyntax NullableType 
		{ 
			get { return this.GetRed(ref this.nullableType, 0); } 
		}
	    public GenericTypeSyntax GenericType 
		{ 
			get { return this.GetRed(ref this.genericType, 1); } 
		}
	    public SimpleTypeSyntax SimpleType 
		{ 
			get { return this.GetRed(ref this.simpleType, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.nullableType, 0);
				case 1: return this.GetRed(ref this.genericType, 1);
				case 2: return this.GetRed(ref this.simpleType, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.nullableType;
				case 1: return this.genericType;
				case 2: return this.simpleType;
				default: return null;
	        }
	    }
	
	    public ArrayItemTypeSyntax WithNullableType(NullableTypeSyntax nullableType)
		{
			return this.Update(nullableType);
		}
	
	    public ArrayItemTypeSyntax WithGenericType(GenericTypeSyntax genericType)
		{
			return this.Update(genericType);
		}
	
	    public ArrayItemTypeSyntax WithSimpleType(SimpleTypeSyntax simpleType)
		{
			return this.Update(simpleType);
		}
	
	    public ArrayItemTypeSyntax Update(NullableTypeSyntax nullableType)
	    {
	        if (this.NullableType != nullableType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ArrayItemType(nullableType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayItemTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ArrayItemTypeSyntax Update(GenericTypeSyntax genericType)
	    {
	        if (this.GenericType != genericType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ArrayItemType(genericType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayItemTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public ArrayItemTypeSyntax Update(SimpleTypeSyntax simpleType)
	    {
	        if (this.SimpleType != simpleType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ArrayItemType(simpleType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ArrayItemTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrayItemType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrayItemType(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitArrayItemType(this);
	    }
	}
	
	public sealed class NullableTypeSyntax : TestLexerModeSyntaxNode
	{
	    private NullableItemTypeSyntax nullableItemType;
	
	    public NullableTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullableTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public NullableItemTypeSyntax NullableItemType 
		{ 
			get { return this.GetRed(ref this.nullableItemType, 0); } 
		}
	    public SyntaxToken TQuestion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.NullableTypeGreen)this.Green;
				var greenToken = green.TQuestion;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.nullableItemType, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.nullableItemType;
				default: return null;
	        }
	    }
	
	    public NullableTypeSyntax WithNullableItemType(NullableItemTypeSyntax nullableItemType)
		{
			return this.Update(NullableItemType, this.TQuestion);
		}
	
	    public NullableTypeSyntax WithTQuestion(SyntaxToken tQuestion)
		{
			return this.Update(this.NullableItemType, TQuestion);
		}
	
	    public NullableTypeSyntax Update(NullableItemTypeSyntax nullableItemType, SyntaxToken tQuestion)
	    {
	        if (this.NullableItemType != nullableItemType ||
				this.TQuestion != tQuestion)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.NullableType(nullableItemType, tQuestion);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullableType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullableType(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitNullableType(this);
	    }
	}
	
	public sealed class NullableItemTypeSyntax : TestLexerModeSyntaxNode
	{
	    private GenericTypeSyntax genericType;
	    private SimpleTypeSyntax simpleType;
	
	    public NullableItemTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullableItemTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	
	    public NullableItemTypeSyntax WithGenericType(GenericTypeSyntax genericType)
		{
			return this.Update(genericType);
		}
	
	    public NullableItemTypeSyntax WithSimpleType(SimpleTypeSyntax simpleType)
		{
			return this.Update(simpleType);
		}
	
	    public NullableItemTypeSyntax Update(GenericTypeSyntax genericType)
	    {
	        if (this.GenericType != genericType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.NullableItemType(genericType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableItemTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public NullableItemTypeSyntax Update(SimpleTypeSyntax simpleType)
	    {
	        if (this.SimpleType != simpleType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.NullableItemType(simpleType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullableItemTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullableItemType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullableItemType(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitNullableItemType(this);
	    }
	}
	
	public sealed class GenericTypeSyntax : TestLexerModeSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private TypeArgumentListSyntax typeArgumentList;
	
	    public GenericTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GenericTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 0); } 
		}
	    public TypeArgumentListSyntax TypeArgumentList 
		{ 
			get { return this.GetRed(ref this.typeArgumentList, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifiedName, 0);
				case 1: return this.GetRed(ref this.typeArgumentList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifiedName;
				case 1: return this.typeArgumentList;
				default: return null;
	        }
	    }
	
	    public GenericTypeSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(QualifiedName, this.TypeArgumentList);
		}
	
	    public GenericTypeSyntax WithTypeArgumentList(TypeArgumentListSyntax typeArgumentList)
		{
			return this.Update(this.QualifiedName, TypeArgumentList);
		}
	
	    public GenericTypeSyntax Update(QualifiedNameSyntax qualifiedName, TypeArgumentListSyntax typeArgumentList)
	    {
	        if (this.QualifiedName != qualifiedName ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.GenericType(qualifiedName, typeArgumentList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGenericType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGenericType(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitGenericType(this);
	    }
	}
	
	public sealed class SimpleTypeSyntax : TestLexerModeSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private PredefinedTypeSyntax predefinedType;
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SimpleTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 0); } 
		}
	    public PredefinedTypeSyntax PredefinedType 
		{ 
			get { return this.GetRed(ref this.predefinedType, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.qualifiedName, 0);
				case 1: return this.GetRed(ref this.predefinedType, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.qualifiedName;
				case 1: return this.predefinedType;
				default: return null;
	        }
	    }
	
	    public SimpleTypeSyntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(qualifiedName);
		}
	
	    public SimpleTypeSyntax WithPredefinedType(PredefinedTypeSyntax predefinedType)
		{
			return this.Update(predefinedType);
		}
	
	    public SimpleTypeSyntax Update(QualifiedNameSyntax qualifiedName)
	    {
	        if (this.QualifiedName != qualifiedName)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SimpleType(qualifiedName);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public SimpleTypeSyntax Update(PredefinedTypeSyntax predefinedType)
	    {
	        if (this.PredefinedType != predefinedType)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SimpleType(predefinedType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SimpleTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSimpleType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSimpleType(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSimpleType(this);
	    }
	}
	
	public sealed class VoidTypeSyntax : TestLexerModeSyntaxNode
	{
	
	    public VoidTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VoidTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVoid 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.VoidTypeGreen)this.Green;
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.VoidType(kVoid);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VoidTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVoidType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVoidType(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitVoidType(this);
	    }
	}
	
	public sealed class ReturnTypeSyntax : TestLexerModeSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private VoidTypeSyntax voidType;
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ReturnTypeSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ReturnType(typeReference);
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ReturnType(voidType);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ReturnTypeSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitReturnType(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitReturnType(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitReturnType(this);
	    }
	}
	
	public sealed class ExpressionListSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode expression;
	
	    public ExpressionListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ExpressionListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ExpressionList(expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExpressionListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitExpressionList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitExpressionList(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitExpressionList(this);
	    }
	}
	
	public sealed class VariableReferenceSyntax : TestLexerModeSyntaxNode
	{
	    private ExpressionSyntax expression;
	
	    public VariableReferenceSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public VariableReferenceSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
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
	
	    public VariableReferenceSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression);
		}
	
	    public VariableReferenceSyntax Update(ExpressionSyntax expression)
	    {
	        if (this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.VariableReference(expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (VariableReferenceSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVariableReference(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVariableReference(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitVariableReference(this);
	    }
	}
	
	public sealed class RankSpecifiersSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode rankSpecifier;
	
	    public RankSpecifiersSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RankSpecifiersSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<RankSpecifierSyntax> RankSpecifier 
		{ 
			get
			{
				var red = this.GetRed(ref this.rankSpecifier, 0);
				if (red != null) return new SyntaxList<RankSpecifierSyntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.rankSpecifier, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.rankSpecifier;
				default: return null;
	        }
	    }
	
	    public RankSpecifiersSyntax WithRankSpecifier(SyntaxList<RankSpecifierSyntax> rankSpecifier)
		{
			return this.Update(RankSpecifier);
		}
	
	    public RankSpecifiersSyntax AddRankSpecifier(params RankSpecifierSyntax[] rankSpecifier)
		{
			return this.WithRankSpecifier(this.RankSpecifier.AddRange(rankSpecifier));
		}
	
	    public RankSpecifiersSyntax Update(SyntaxList<RankSpecifierSyntax> rankSpecifier)
	    {
	        if (this.RankSpecifier != rankSpecifier)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.RankSpecifiers(rankSpecifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RankSpecifiersSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRankSpecifiers(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRankSpecifiers(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitRankSpecifiers(this);
	    }
	}
	
	public sealed class RankSpecifierSyntax : TestLexerModeSyntaxNode
	{
	
	    public RankSpecifierSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RankSpecifierSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.RankSpecifierGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxTokenList TComma 
		{ 
			get
			{
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.RankSpecifierGreen)this.Green;
				var greenTokens = green.TComma;
				if (greenTokens.Node != null)
				{
					return new SyntaxTokenList(this, greenTokens.Node, this.GetChildPosition(1), this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.RankSpecifierGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
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
	
	    public RankSpecifierSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(TOpenBracket, this.TComma, this.TCloseBracket);
		}
	
	    public RankSpecifierSyntax WithTComma(SyntaxTokenList tComma)
		{
			return this.Update(this.TOpenBracket, TComma, this.TCloseBracket);
		}
	
	    public RankSpecifierSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.TOpenBracket, this.TComma, TCloseBracket);
		}
	
	    public RankSpecifierSyntax Update(SyntaxToken tOpenBracket, SyntaxTokenList tComma, SyntaxToken tCloseBracket)
	    {
	        if (this.TOpenBracket != tOpenBracket ||
				this.TComma != tComma ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.RankSpecifier(tOpenBracket, tComma, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RankSpecifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRankSpecifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRankSpecifier(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitRankSpecifier(this);
	    }
	}
	
	public sealed class UnboundTypeNameSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode genericDimensionItem;
	
	    public UnboundTypeNameSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UnboundTypeNameSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SeparatedSyntaxList<GenericDimensionItemSyntax> GenericDimensionItem 
		{ 
			get
			{
				var red = this.GetRed(ref this.genericDimensionItem, 0);
				if (red != null)
				{
					return new SeparatedSyntaxList<GenericDimensionItemSyntax>(red, this.GetChildIndex(0));
				}
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.genericDimensionItem, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.genericDimensionItem;
				default: return null;
	        }
	    }
	
	    public UnboundTypeNameSyntax WithGenericDimensionItem(SeparatedSyntaxList<GenericDimensionItemSyntax> genericDimensionItem)
		{
			return this.Update(GenericDimensionItem);
		}
	
	    public UnboundTypeNameSyntax AddGenericDimensionItem(params GenericDimensionItemSyntax[] genericDimensionItem)
		{
			return this.WithGenericDimensionItem(this.GenericDimensionItem.AddRange(genericDimensionItem));
		}
	
	    public UnboundTypeNameSyntax Update(SeparatedSyntaxList<GenericDimensionItemSyntax> genericDimensionItem)
	    {
	        if (this.GenericDimensionItem != genericDimensionItem)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.UnboundTypeName(genericDimensionItem);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UnboundTypeNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUnboundTypeName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUnboundTypeName(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitUnboundTypeName(this);
	    }
	}
	
	public sealed class GenericDimensionItemSyntax : TestLexerModeSyntaxNode
	{
	    private IdentifierSyntax identifier;
	    private GenericDimensionSpecifierSyntax genericDimensionSpecifier;
	
	    public GenericDimensionItemSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GenericDimensionItemSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public GenericDimensionSpecifierSyntax GenericDimensionSpecifier 
		{ 
			get { return this.GetRed(ref this.genericDimensionSpecifier, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				case 1: return this.GetRed(ref this.genericDimensionSpecifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				case 1: return this.genericDimensionSpecifier;
				default: return null;
	        }
	    }
	
	    public GenericDimensionItemSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier, this.GenericDimensionSpecifier);
		}
	
	    public GenericDimensionItemSyntax WithGenericDimensionSpecifier(GenericDimensionSpecifierSyntax genericDimensionSpecifier)
		{
			return this.Update(this.Identifier, GenericDimensionSpecifier);
		}
	
	    public GenericDimensionItemSyntax Update(IdentifierSyntax identifier, GenericDimensionSpecifierSyntax genericDimensionSpecifier)
	    {
	        if (this.Identifier != identifier ||
				this.GenericDimensionSpecifier != genericDimensionSpecifier)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.GenericDimensionItem(identifier, genericDimensionSpecifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericDimensionItemSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGenericDimensionItem(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGenericDimensionItem(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitGenericDimensionItem(this);
	    }
	}
	
	public sealed class GenericDimensionSpecifierSyntax : TestLexerModeSyntaxNode
	{
	
	    public GenericDimensionSpecifierSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GenericDimensionSpecifierSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TLessThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.GenericDimensionSpecifierGreen)this.Green;
				var greenToken = green.TLessThan;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxTokenList TComma 
		{ 
			get
			{
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.GenericDimensionSpecifierGreen)this.Green;
				var greenTokens = green.TComma;
				if (greenTokens.Node != null)
				{
					return new SyntaxTokenList(this, greenTokens.Node, this.GetChildPosition(1), this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TGreaterThan 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.GenericDimensionSpecifierGreen)this.Green;
				var greenToken = green.TGreaterThan;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
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
	
	    public GenericDimensionSpecifierSyntax WithTLessThan(SyntaxToken tLessThan)
		{
			return this.Update(TLessThan, this.TComma, this.TGreaterThan);
		}
	
	    public GenericDimensionSpecifierSyntax WithTComma(SyntaxTokenList tComma)
		{
			return this.Update(this.TLessThan, TComma, this.TGreaterThan);
		}
	
	    public GenericDimensionSpecifierSyntax WithTGreaterThan(SyntaxToken tGreaterThan)
		{
			return this.Update(this.TLessThan, this.TComma, TGreaterThan);
		}
	
	    public GenericDimensionSpecifierSyntax Update(SyntaxToken tLessThan, SyntaxTokenList tComma, SyntaxToken tGreaterThan)
	    {
	        if (this.TLessThan != tLessThan ||
				this.TComma != tComma ||
				this.TGreaterThan != tGreaterThan)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.GenericDimensionSpecifier(tLessThan, tComma, tGreaterThan);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GenericDimensionSpecifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGenericDimensionSpecifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGenericDimensionSpecifier(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitGenericDimensionSpecifier(this);
	    }
	}
	
	public abstract class AnonymousFunctionSignatureSyntax : TestLexerModeSyntaxNode
	{
	    protected AnonymousFunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected AnonymousFunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class ExplicitAnonymousFunctionSignatureSyntax : AnonymousFunctionSignatureSyntax
	{
	    private SyntaxNode explicitParameter;
	
	    public ExplicitAnonymousFunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ExplicitAnonymousFunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ExplicitAnonymousFunctionSignatureGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SeparatedSyntaxList<ExplicitParameterSyntax> ExplicitParameter 
		{ 
			get
			{
				var red = this.GetRed(ref this.explicitParameter, 1);
				if (red != null)
				{
					return new SeparatedSyntaxList<ExplicitParameterSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ExplicitAnonymousFunctionSignatureGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.explicitParameter, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.explicitParameter;
				default: return null;
	        }
	    }
	
	    public ExplicitAnonymousFunctionSignatureSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(TOpenParenthesis, this.ExplicitParameter, this.TCloseParenthesis);
		}
	
	    public ExplicitAnonymousFunctionSignatureSyntax WithExplicitParameter(SeparatedSyntaxList<ExplicitParameterSyntax> explicitParameter)
		{
			return this.Update(this.TOpenParenthesis, ExplicitParameter, this.TCloseParenthesis);
		}
	
	    public ExplicitAnonymousFunctionSignatureSyntax AddExplicitParameter(params ExplicitParameterSyntax[] explicitParameter)
		{
			return this.WithExplicitParameter(this.ExplicitParameter.AddRange(explicitParameter));
		}
	
	    public ExplicitAnonymousFunctionSignatureSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.TOpenParenthesis, this.ExplicitParameter, TCloseParenthesis);
		}
	
	    public ExplicitAnonymousFunctionSignatureSyntax Update(SyntaxToken tOpenParenthesis, SeparatedSyntaxList<ExplicitParameterSyntax> explicitParameter, SyntaxToken tCloseParenthesis)
	    {
	        if (this.TOpenParenthesis != tOpenParenthesis ||
				this.ExplicitParameter != explicitParameter ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ExplicitAnonymousFunctionSignature(tOpenParenthesis, explicitParameter, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExplicitAnonymousFunctionSignatureSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitExplicitAnonymousFunctionSignature(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitExplicitAnonymousFunctionSignature(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitExplicitAnonymousFunctionSignature(this);
	    }
	}
	
	public sealed class ImplicitAnonymousFunctionSignatureSyntax : AnonymousFunctionSignatureSyntax
	{
	    private SyntaxNode implicitParameter;
	
	    public ImplicitAnonymousFunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ImplicitAnonymousFunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ImplicitAnonymousFunctionSignatureGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SeparatedSyntaxList<ImplicitParameterSyntax> ImplicitParameter 
		{ 
			get
			{
				var red = this.GetRed(ref this.implicitParameter, 1);
				if (red != null)
				{
					return new SeparatedSyntaxList<ImplicitParameterSyntax>(red, this.GetChildIndex(1));
				}
				return default;
			} 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ImplicitAnonymousFunctionSignatureGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.implicitParameter, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.implicitParameter;
				default: return null;
	        }
	    }
	
	    public ImplicitAnonymousFunctionSignatureSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(TOpenParenthesis, this.ImplicitParameter, this.TCloseParenthesis);
		}
	
	    public ImplicitAnonymousFunctionSignatureSyntax WithImplicitParameter(SeparatedSyntaxList<ImplicitParameterSyntax> implicitParameter)
		{
			return this.Update(this.TOpenParenthesis, ImplicitParameter, this.TCloseParenthesis);
		}
	
	    public ImplicitAnonymousFunctionSignatureSyntax AddImplicitParameter(params ImplicitParameterSyntax[] implicitParameter)
		{
			return this.WithImplicitParameter(this.ImplicitParameter.AddRange(implicitParameter));
		}
	
	    public ImplicitAnonymousFunctionSignatureSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.TOpenParenthesis, this.ImplicitParameter, TCloseParenthesis);
		}
	
	    public ImplicitAnonymousFunctionSignatureSyntax Update(SyntaxToken tOpenParenthesis, SeparatedSyntaxList<ImplicitParameterSyntax> implicitParameter, SyntaxToken tCloseParenthesis)
	    {
	        if (this.TOpenParenthesis != tOpenParenthesis ||
				this.ImplicitParameter != implicitParameter ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ImplicitAnonymousFunctionSignature(tOpenParenthesis, implicitParameter, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ImplicitAnonymousFunctionSignatureSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitImplicitAnonymousFunctionSignature(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitImplicitAnonymousFunctionSignature(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitImplicitAnonymousFunctionSignature(this);
	    }
	}
	
	public sealed class SingleParamAnonymousFunctionSignatureSyntax : AnonymousFunctionSignatureSyntax
	{
	    private ImplicitParameterSyntax implicitParameter;
	
	    public SingleParamAnonymousFunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public SingleParamAnonymousFunctionSignatureSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ImplicitParameterSyntax ImplicitParameter 
		{ 
			get { return this.GetRed(ref this.implicitParameter, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.implicitParameter, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.implicitParameter;
				default: return null;
	        }
	    }
	
	    public SingleParamAnonymousFunctionSignatureSyntax WithImplicitParameter(ImplicitParameterSyntax implicitParameter)
		{
			return this.Update(ImplicitParameter);
		}
	
	    public SingleParamAnonymousFunctionSignatureSyntax Update(ImplicitParameterSyntax implicitParameter)
	    {
	        if (this.ImplicitParameter != implicitParameter)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.SingleParamAnonymousFunctionSignature(implicitParameter);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (SingleParamAnonymousFunctionSignatureSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSingleParamAnonymousFunctionSignature(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSingleParamAnonymousFunctionSignature(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitSingleParamAnonymousFunctionSignature(this);
	    }
	}
	
	public sealed class ExplicitParameterSyntax : TestLexerModeSyntaxNode
	{
	    private TypeReferenceSyntax typeReference;
	    private IdentifierSyntax identifier;
	
	    public ExplicitParameterSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ExplicitParameterSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 0); } 
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.typeReference, 0);
				case 1: return this.GetRed(ref this.identifier, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.typeReference;
				case 1: return this.identifier;
				default: return null;
	        }
	    }
	
	    public ExplicitParameterSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(TypeReference, this.Identifier);
		}
	
	    public ExplicitParameterSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.TypeReference, Identifier);
		}
	
	    public ExplicitParameterSyntax Update(TypeReferenceSyntax typeReference, IdentifierSyntax identifier)
	    {
	        if (this.TypeReference != typeReference ||
				this.Identifier != identifier)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ExplicitParameter(typeReference, identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ExplicitParameterSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitExplicitParameter(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitExplicitParameter(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitExplicitParameter(this);
	    }
	}
	
	public sealed class ImplicitParameterSyntax : TestLexerModeSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public ImplicitParameterSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ImplicitParameterSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	
	    public ImplicitParameterSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier);
		}
	
	    public ImplicitParameterSyntax Update(IdentifierSyntax identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ImplicitParameter(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ImplicitParameterSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitImplicitParameter(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitImplicitParameter(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitImplicitParameter(this);
	    }
	}
	
	public abstract class ExpressionSyntax : TestLexerModeSyntaxNode
	{
	    protected ExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    protected ExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	}
	
	public sealed class ThisExpressionSyntax : ExpressionSyntax
	{
	
	    public ThisExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ThisExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KThis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ThisExpressionGreen)this.Green;
				var greenToken = green.KThis;
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
	
	    public ThisExpressionSyntax WithKThis(SyntaxToken kThis)
		{
			return this.Update(KThis);
		}
	
	    public ThisExpressionSyntax Update(SyntaxToken kThis)
	    {
	        if (this.KThis != kThis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ThisExpression(kThis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ThisExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitThisExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitThisExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitThisExpression(this);
	    }
	}
	
	public sealed class LiteralExpressionSyntax : ExpressionSyntax
	{
	    private LiteralSyntax literal;
	
	    public LiteralExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public LiteralSyntax Literal 
		{ 
			get { return this.GetRed(ref this.literal, 0); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.literal, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.literal;
				default: return null;
	        }
	    }
	
	    public LiteralExpressionSyntax WithLiteral(LiteralSyntax literal)
		{
			return this.Update(Literal);
		}
	
	    public LiteralExpressionSyntax Update(LiteralSyntax literal)
	    {
	        if (this.Literal != literal)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LiteralExpression(literal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteralExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteralExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteralExpression(this);
	    }
	}
	
	public sealed class TypeofVoidExpressionSyntax : ExpressionSyntax
	{
	
	    public TypeofVoidExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeofVoidExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTypeof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofVoidExpressionGreen)this.Green;
				var greenToken = green.KTypeof;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofVoidExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public SyntaxToken KVoid 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofVoidExpressionGreen)this.Green;
				var greenToken = green.KVoid;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofVoidExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
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
	
	    public TypeofVoidExpressionSyntax WithKTypeof(SyntaxToken kTypeof)
		{
			return this.Update(KTypeof, this.TOpenParenthesis, this.KVoid, this.TCloseParenthesis);
		}
	
	    public TypeofVoidExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KTypeof, TOpenParenthesis, this.KVoid, this.TCloseParenthesis);
		}
	
	    public TypeofVoidExpressionSyntax WithKVoid(SyntaxToken kVoid)
		{
			return this.Update(this.KTypeof, this.TOpenParenthesis, KVoid, this.TCloseParenthesis);
		}
	
	    public TypeofVoidExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KTypeof, this.TOpenParenthesis, this.KVoid, TCloseParenthesis);
		}
	
	    public TypeofVoidExpressionSyntax Update(SyntaxToken kTypeof, SyntaxToken tOpenParenthesis, SyntaxToken kVoid, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.KVoid != kVoid ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypeofVoidExpression(kTypeof, tOpenParenthesis, kVoid, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofVoidExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeofVoidExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeofVoidExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeofVoidExpression(this);
	    }
	}
	
	public sealed class TypeofUnboundTypeExpressionSyntax : ExpressionSyntax
	{
	    private UnboundTypeNameSyntax unboundTypeName;
	
	    public TypeofUnboundTypeExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeofUnboundTypeExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTypeof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofUnboundTypeExpressionGreen)this.Green;
				var greenToken = green.KTypeof;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofUnboundTypeExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public UnboundTypeNameSyntax UnboundTypeName 
		{ 
			get { return this.GetRed(ref this.unboundTypeName, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofUnboundTypeExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.unboundTypeName, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.unboundTypeName;
				default: return null;
	        }
	    }
	
	    public TypeofUnboundTypeExpressionSyntax WithKTypeof(SyntaxToken kTypeof)
		{
			return this.Update(KTypeof, this.TOpenParenthesis, this.UnboundTypeName, this.TCloseParenthesis);
		}
	
	    public TypeofUnboundTypeExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KTypeof, TOpenParenthesis, this.UnboundTypeName, this.TCloseParenthesis);
		}
	
	    public TypeofUnboundTypeExpressionSyntax WithUnboundTypeName(UnboundTypeNameSyntax unboundTypeName)
		{
			return this.Update(this.KTypeof, this.TOpenParenthesis, UnboundTypeName, this.TCloseParenthesis);
		}
	
	    public TypeofUnboundTypeExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KTypeof, this.TOpenParenthesis, this.UnboundTypeName, TCloseParenthesis);
		}
	
	    public TypeofUnboundTypeExpressionSyntax Update(SyntaxToken kTypeof, SyntaxToken tOpenParenthesis, UnboundTypeNameSyntax unboundTypeName, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.UnboundTypeName != unboundTypeName ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypeofUnboundTypeExpression(kTypeof, tOpenParenthesis, unboundTypeName, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofUnboundTypeExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeofUnboundTypeExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeofUnboundTypeExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeofUnboundTypeExpression(this);
	    }
	}
	
	public sealed class TypeofTypeExpressionSyntax : ExpressionSyntax
	{
	    private TypeReferenceSyntax typeReference;
	
	    public TypeofTypeExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypeofTypeExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTypeof 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofTypeExpressionGreen)this.Green;
				var greenToken = green.KTypeof;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofTypeExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypeofTypeExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public TypeofTypeExpressionSyntax WithKTypeof(SyntaxToken kTypeof)
		{
			return this.Update(KTypeof, this.TOpenParenthesis, this.TypeReference, this.TCloseParenthesis);
		}
	
	    public TypeofTypeExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KTypeof, TOpenParenthesis, this.TypeReference, this.TCloseParenthesis);
		}
	
	    public TypeofTypeExpressionSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KTypeof, this.TOpenParenthesis, TypeReference, this.TCloseParenthesis);
		}
	
	    public TypeofTypeExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KTypeof, this.TOpenParenthesis, this.TypeReference, TCloseParenthesis);
		}
	
	    public TypeofTypeExpressionSyntax Update(SyntaxToken kTypeof, SyntaxToken tOpenParenthesis, TypeReferenceSyntax typeReference, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KTypeof != kTypeof ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.TypeReference != typeReference ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypeofTypeExpression(kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypeofTypeExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypeofTypeExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypeofTypeExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTypeofTypeExpression(this);
	    }
	}
	
	public sealed class DefaultValueExpressionSyntax : ExpressionSyntax
	{
	    private TypeReferenceSyntax typeReference;
	
	    public DefaultValueExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DefaultValueExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KDefault 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.DefaultValueExpressionGreen)this.Green;
				var greenToken = green.KDefault;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.DefaultValueExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.DefaultValueExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public DefaultValueExpressionSyntax WithKDefault(SyntaxToken kDefault)
		{
			return this.Update(KDefault, this.TOpenParenthesis, this.TypeReference, this.TCloseParenthesis);
		}
	
	    public DefaultValueExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KDefault, TOpenParenthesis, this.TypeReference, this.TCloseParenthesis);
		}
	
	    public DefaultValueExpressionSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KDefault, this.TOpenParenthesis, TypeReference, this.TCloseParenthesis);
		}
	
	    public DefaultValueExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KDefault, this.TOpenParenthesis, this.TypeReference, TCloseParenthesis);
		}
	
	    public DefaultValueExpressionSyntax Update(SyntaxToken kDefault, SyntaxToken tOpenParenthesis, TypeReferenceSyntax typeReference, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KDefault != kDefault ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.TypeReference != typeReference ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.DefaultValueExpression(kDefault, tOpenParenthesis, typeReference, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DefaultValueExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDefaultValueExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDefaultValueExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitDefaultValueExpression(this);
	    }
	}
	
	public sealed class NewObjectOrCollectionWithConstructorExpressionSyntax : ExpressionSyntax
	{
	    private TypeReferenceSyntax typeReference;
	    private ExpressionListSyntax expressionList;
	
	    public NewObjectOrCollectionWithConstructorExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NewObjectOrCollectionWithConstructorExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNew 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.NewObjectOrCollectionWithConstructorExpressionGreen)this.Green;
				var greenToken = green.KNew;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 1); } 
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.NewObjectOrCollectionWithConstructorExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ExpressionListSyntax ExpressionList 
		{ 
			get { return this.GetRed(ref this.expressionList, 3); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.NewObjectOrCollectionWithConstructorExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 3: return this.GetRed(ref this.expressionList, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.typeReference;
				case 3: return this.expressionList;
				default: return null;
	        }
	    }
	
	    public NewObjectOrCollectionWithConstructorExpressionSyntax WithKNew(SyntaxToken kNew)
		{
			return this.Update(KNew, this.TypeReference, this.TOpenParenthesis, this.ExpressionList, this.TCloseParenthesis);
		}
	
	    public NewObjectOrCollectionWithConstructorExpressionSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.KNew, TypeReference, this.TOpenParenthesis, this.ExpressionList, this.TCloseParenthesis);
		}
	
	    public NewObjectOrCollectionWithConstructorExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KNew, this.TypeReference, TOpenParenthesis, this.ExpressionList, this.TCloseParenthesis);
		}
	
	    public NewObjectOrCollectionWithConstructorExpressionSyntax WithExpressionList(ExpressionListSyntax expressionList)
		{
			return this.Update(this.KNew, this.TypeReference, this.TOpenParenthesis, ExpressionList, this.TCloseParenthesis);
		}
	
	    public NewObjectOrCollectionWithConstructorExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KNew, this.TypeReference, this.TOpenParenthesis, this.ExpressionList, TCloseParenthesis);
		}
	
	    public NewObjectOrCollectionWithConstructorExpressionSyntax Update(SyntaxToken kNew, TypeReferenceSyntax typeReference, SyntaxToken tOpenParenthesis, ExpressionListSyntax expressionList, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KNew != kNew ||
				this.TypeReference != typeReference ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ExpressionList != expressionList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.NewObjectOrCollectionWithConstructorExpression(kNew, typeReference, tOpenParenthesis, expressionList, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NewObjectOrCollectionWithConstructorExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNewObjectOrCollectionWithConstructorExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNewObjectOrCollectionWithConstructorExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitNewObjectOrCollectionWithConstructorExpression(this);
	    }
	}
	
	public sealed class IdentifierExpressionSyntax : ExpressionSyntax
	{
	    private IdentifierSyntax identifier;
	    private TypeArgumentListSyntax typeArgumentList;
	
	    public IdentifierExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 0); } 
		}
	    public TypeArgumentListSyntax TypeArgumentList 
		{ 
			get { return this.GetRed(ref this.typeArgumentList, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.identifier, 0);
				case 1: return this.GetRed(ref this.typeArgumentList, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.identifier;
				case 1: return this.typeArgumentList;
				default: return null;
	        }
	    }
	
	    public IdentifierExpressionSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(Identifier, this.TypeArgumentList);
		}
	
	    public IdentifierExpressionSyntax WithTypeArgumentList(TypeArgumentListSyntax typeArgumentList)
		{
			return this.Update(this.Identifier, TypeArgumentList);
		}
	
	    public IdentifierExpressionSyntax Update(IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
	    {
	        if (this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.IdentifierExpression(identifier, typeArgumentList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifierExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifierExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifierExpression(this);
	    }
	}
	
	public sealed class HasLoopExpressionSyntax : ExpressionSyntax
	{
	    private LoopChainSyntax loopChain;
	    private LoopWhereExpressionSyntax loopWhereExpression;
	
	    public HasLoopExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public HasLoopExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KHasLoop 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.HasLoopExpressionGreen)this.Green;
				var greenToken = green.KHasLoop;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.HasLoopExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public LoopChainSyntax LoopChain 
		{ 
			get { return this.GetRed(ref this.loopChain, 2); } 
		}
	    public LoopWhereExpressionSyntax LoopWhereExpression 
		{ 
			get { return this.GetRed(ref this.loopWhereExpression, 3); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.HasLoopExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.GetRed(ref this.loopChain, 2);
				case 3: return this.GetRed(ref this.loopWhereExpression, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 2: return this.loopChain;
				case 3: return this.loopWhereExpression;
				default: return null;
	        }
	    }
	
	    public HasLoopExpressionSyntax WithKHasLoop(SyntaxToken kHasLoop)
		{
			return this.Update(KHasLoop, this.TOpenParenthesis, this.LoopChain, this.LoopWhereExpression, this.TCloseParenthesis);
		}
	
	    public HasLoopExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.KHasLoop, TOpenParenthesis, this.LoopChain, this.LoopWhereExpression, this.TCloseParenthesis);
		}
	
	    public HasLoopExpressionSyntax WithLoopChain(LoopChainSyntax loopChain)
		{
			return this.Update(this.KHasLoop, this.TOpenParenthesis, LoopChain, this.LoopWhereExpression, this.TCloseParenthesis);
		}
	
	    public HasLoopExpressionSyntax WithLoopWhereExpression(LoopWhereExpressionSyntax loopWhereExpression)
		{
			return this.Update(this.KHasLoop, this.TOpenParenthesis, this.LoopChain, LoopWhereExpression, this.TCloseParenthesis);
		}
	
	    public HasLoopExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.KHasLoop, this.TOpenParenthesis, this.LoopChain, this.LoopWhereExpression, TCloseParenthesis);
		}
	
	    public HasLoopExpressionSyntax Update(SyntaxToken kHasLoop, SyntaxToken tOpenParenthesis, LoopChainSyntax loopChain, LoopWhereExpressionSyntax loopWhereExpression, SyntaxToken tCloseParenthesis)
	    {
	        if (this.KHasLoop != kHasLoop ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.LoopChain != loopChain ||
				this.LoopWhereExpression != loopWhereExpression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.HasLoopExpression(kHasLoop, tOpenParenthesis, loopChain, loopWhereExpression, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (HasLoopExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitHasLoopExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitHasLoopExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitHasLoopExpression(this);
	    }
	}
	
	public sealed class ParenthesizedExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	
	    public ParenthesizedExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ParenthesizedExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ParenthesizedExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ParenthesizedExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.expression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.expression;
				default: return null;
	        }
	    }
	
	    public ParenthesizedExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(TOpenParenthesis, this.Expression, this.TCloseParenthesis);
		}
	
	    public ParenthesizedExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.TOpenParenthesis, Expression, this.TCloseParenthesis);
		}
	
	    public ParenthesizedExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.TOpenParenthesis, this.Expression, TCloseParenthesis);
		}
	
	    public ParenthesizedExpressionSyntax Update(SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
	    {
	        if (this.TOpenParenthesis != tOpenParenthesis ||
				this.Expression != expression ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ParenthesizedExpression(tOpenParenthesis, expression, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ParenthesizedExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitParenthesizedExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitParenthesizedExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitParenthesizedExpression(this);
	    }
	}
	
	public sealed class ElementAccessExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	    private ExpressionListSyntax expressionList;
	
	    public ElementAccessExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ElementAccessExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public SyntaxToken TOpenBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ElementAccessExpressionGreen)this.Green;
				var greenToken = green.TOpenBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionListSyntax ExpressionList 
		{ 
			get { return this.GetRed(ref this.expressionList, 2); } 
		}
	    public SyntaxToken TCloseBracket 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ElementAccessExpressionGreen)this.Green;
				var greenToken = green.TCloseBracket;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				case 2: return this.GetRed(ref this.expressionList, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				case 2: return this.expressionList;
				default: return null;
	        }
	    }
	
	    public ElementAccessExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.TOpenBracket, this.ExpressionList, this.TCloseBracket);
		}
	
	    public ElementAccessExpressionSyntax WithTOpenBracket(SyntaxToken tOpenBracket)
		{
			return this.Update(this.Expression, TOpenBracket, this.ExpressionList, this.TCloseBracket);
		}
	
	    public ElementAccessExpressionSyntax WithExpressionList(ExpressionListSyntax expressionList)
		{
			return this.Update(this.Expression, this.TOpenBracket, ExpressionList, this.TCloseBracket);
		}
	
	    public ElementAccessExpressionSyntax WithTCloseBracket(SyntaxToken tCloseBracket)
		{
			return this.Update(this.Expression, this.TOpenBracket, this.ExpressionList, TCloseBracket);
		}
	
	    public ElementAccessExpressionSyntax Update(ExpressionSyntax expression, SyntaxToken tOpenBracket, ExpressionListSyntax expressionList, SyntaxToken tCloseBracket)
	    {
	        if (this.Expression != expression ||
				this.TOpenBracket != tOpenBracket ||
				this.ExpressionList != expressionList ||
				this.TCloseBracket != tCloseBracket)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ElementAccessExpression(expression, tOpenBracket, expressionList, tCloseBracket);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ElementAccessExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitElementAccessExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitElementAccessExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitElementAccessExpression(this);
	    }
	}
	
	public sealed class FunctionCallExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	    private ExpressionListSyntax expressionList;
	
	    public FunctionCallExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public FunctionCallExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.FunctionCallExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionListSyntax ExpressionList 
		{ 
			get { return this.GetRed(ref this.expressionList, 2); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.FunctionCallExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				case 2: return this.GetRed(ref this.expressionList, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				case 2: return this.expressionList;
				default: return null;
	        }
	    }
	
	    public FunctionCallExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.TOpenParenthesis, this.ExpressionList, this.TCloseParenthesis);
		}
	
	    public FunctionCallExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(this.Expression, TOpenParenthesis, this.ExpressionList, this.TCloseParenthesis);
		}
	
	    public FunctionCallExpressionSyntax WithExpressionList(ExpressionListSyntax expressionList)
		{
			return this.Update(this.Expression, this.TOpenParenthesis, ExpressionList, this.TCloseParenthesis);
		}
	
	    public FunctionCallExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.Expression, this.TOpenParenthesis, this.ExpressionList, TCloseParenthesis);
		}
	
	    public FunctionCallExpressionSyntax Update(ExpressionSyntax expression, SyntaxToken tOpenParenthesis, ExpressionListSyntax expressionList, SyntaxToken tCloseParenthesis)
	    {
	        if (this.Expression != expression ||
				this.TOpenParenthesis != tOpenParenthesis ||
				this.ExpressionList != expressionList ||
				this.TCloseParenthesis != tCloseParenthesis)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.FunctionCallExpression(expression, tOpenParenthesis, expressionList, tCloseParenthesis);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (FunctionCallExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitFunctionCallExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitFunctionCallExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitFunctionCallExpression(this);
	    }
	}
	
	public sealed class PredefinedTypeMemberAccessExpressionSyntax : ExpressionSyntax
	{
	    private PredefinedTypeSyntax predefinedType;
	    private IdentifierSyntax identifier;
	    private TypeArgumentListSyntax typeArgumentList;
	
	    public PredefinedTypeMemberAccessExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PredefinedTypeMemberAccessExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public PredefinedTypeSyntax PredefinedType 
		{ 
			get { return this.GetRed(ref this.predefinedType, 0); } 
		}
	    public SyntaxToken TDot 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.PredefinedTypeMemberAccessExpressionGreen)this.Green;
				var greenToken = green.TDot;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 2); } 
		}
	    public TypeArgumentListSyntax TypeArgumentList 
		{ 
			get { return this.GetRed(ref this.typeArgumentList, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.predefinedType, 0);
				case 2: return this.GetRed(ref this.identifier, 2);
				case 3: return this.GetRed(ref this.typeArgumentList, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.predefinedType;
				case 2: return this.identifier;
				case 3: return this.typeArgumentList;
				default: return null;
	        }
	    }
	
	    public PredefinedTypeMemberAccessExpressionSyntax WithPredefinedType(PredefinedTypeSyntax predefinedType)
		{
			return this.Update(PredefinedType, this.TDot, this.Identifier, this.TypeArgumentList);
		}
	
	    public PredefinedTypeMemberAccessExpressionSyntax WithTDot(SyntaxToken tDot)
		{
			return this.Update(this.PredefinedType, TDot, this.Identifier, this.TypeArgumentList);
		}
	
	    public PredefinedTypeMemberAccessExpressionSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.PredefinedType, this.TDot, Identifier, this.TypeArgumentList);
		}
	
	    public PredefinedTypeMemberAccessExpressionSyntax WithTypeArgumentList(TypeArgumentListSyntax typeArgumentList)
		{
			return this.Update(this.PredefinedType, this.TDot, this.Identifier, TypeArgumentList);
		}
	
	    public PredefinedTypeMemberAccessExpressionSyntax Update(PredefinedTypeSyntax predefinedType, SyntaxToken tDot, IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
	    {
	        if (this.PredefinedType != predefinedType ||
				this.TDot != tDot ||
				this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.PredefinedTypeMemberAccessExpression(predefinedType, tDot, identifier, typeArgumentList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PredefinedTypeMemberAccessExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPredefinedTypeMemberAccessExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPredefinedTypeMemberAccessExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitPredefinedTypeMemberAccessExpression(this);
	    }
	}
	
	public sealed class MemberAccessExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	    private IdentifierSyntax identifier;
	    private TypeArgumentListSyntax typeArgumentList;
	
	    public MemberAccessExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MemberAccessExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public SyntaxToken TDot 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.MemberAccessExpressionGreen)this.Green;
				var greenToken = green.TDot;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public IdentifierSyntax Identifier 
		{ 
			get { return this.GetRed(ref this.identifier, 2); } 
		}
	    public TypeArgumentListSyntax TypeArgumentList 
		{ 
			get { return this.GetRed(ref this.typeArgumentList, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.expression, 0);
				case 2: return this.GetRed(ref this.identifier, 2);
				case 3: return this.GetRed(ref this.typeArgumentList, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.expression;
				case 2: return this.identifier;
				case 3: return this.typeArgumentList;
				default: return null;
	        }
	    }
	
	    public MemberAccessExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.TDot, this.Identifier, this.TypeArgumentList);
		}
	
	    public MemberAccessExpressionSyntax WithTDot(SyntaxToken tDot)
		{
			return this.Update(this.Expression, TDot, this.Identifier, this.TypeArgumentList);
		}
	
	    public MemberAccessExpressionSyntax WithIdentifier(IdentifierSyntax identifier)
		{
			return this.Update(this.Expression, this.TDot, Identifier, this.TypeArgumentList);
		}
	
	    public MemberAccessExpressionSyntax WithTypeArgumentList(TypeArgumentListSyntax typeArgumentList)
		{
			return this.Update(this.Expression, this.TDot, this.Identifier, TypeArgumentList);
		}
	
	    public MemberAccessExpressionSyntax Update(ExpressionSyntax expression, SyntaxToken tDot, IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
	    {
	        if (this.Expression != expression ||
				this.TDot != tDot ||
				this.Identifier != identifier ||
				this.TypeArgumentList != typeArgumentList)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.MemberAccessExpression(expression, tDot, identifier, typeArgumentList);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MemberAccessExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMemberAccessExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMemberAccessExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitMemberAccessExpression(this);
	    }
	}
	
	public sealed class TypecastExpressionSyntax : ExpressionSyntax
	{
	    private TypeReferenceSyntax typeReference;
	    private ExpressionSyntax expression;
	
	    public TypecastExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypecastExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypecastExpressionGreen)this.Green;
				var greenToken = green.TOpenParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public TypeReferenceSyntax TypeReference 
		{ 
			get { return this.GetRed(ref this.typeReference, 1); } 
		}
	    public SyntaxToken TCloseParenthesis 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypecastExpressionGreen)this.Green;
				var greenToken = green.TCloseParenthesis;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.typeReference, 1);
				case 3: return this.GetRed(ref this.expression, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.typeReference;
				case 3: return this.expression;
				default: return null;
	        }
	    }
	
	    public TypecastExpressionSyntax WithTOpenParenthesis(SyntaxToken tOpenParenthesis)
		{
			return this.Update(TOpenParenthesis, this.TypeReference, this.TCloseParenthesis, this.Expression);
		}
	
	    public TypecastExpressionSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.TOpenParenthesis, TypeReference, this.TCloseParenthesis, this.Expression);
		}
	
	    public TypecastExpressionSyntax WithTCloseParenthesis(SyntaxToken tCloseParenthesis)
		{
			return this.Update(this.TOpenParenthesis, this.TypeReference, TCloseParenthesis, this.Expression);
		}
	
	    public TypecastExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.TOpenParenthesis, this.TypeReference, this.TCloseParenthesis, Expression);
		}
	
	    public TypecastExpressionSyntax Update(SyntaxToken tOpenParenthesis, TypeReferenceSyntax typeReference, SyntaxToken tCloseParenthesis, ExpressionSyntax expression)
	    {
	        if (this.TOpenParenthesis != tOpenParenthesis ||
				this.TypeReference != typeReference ||
				this.TCloseParenthesis != tCloseParenthesis ||
				this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypecastExpression(tOpenParenthesis, typeReference, tCloseParenthesis, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypecastExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypecastExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypecastExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTypecastExpression(this);
	    }
	}
	
	public sealed class UnaryExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	
	    public UnaryExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public UnaryExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Op 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.UnaryExpressionGreen)this.Green;
				var greenToken = green.Op;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.expression, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.expression;
				default: return null;
	        }
	    }
	
	    public UnaryExpressionSyntax WithOp(SyntaxToken op)
		{
			return this.Update(Op, this.Expression);
		}
	
	    public UnaryExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.Op, Expression);
		}
	
	    public UnaryExpressionSyntax Update(SyntaxToken op, ExpressionSyntax expression)
	    {
	        if (this.Op != op ||
				this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.UnaryExpression(op, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (UnaryExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitUnaryExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitUnaryExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitUnaryExpression(this);
	    }
	}
	
	public sealed class PostExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax expression;
	
	    public PostExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public PostExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 0); } 
		}
	    public SyntaxToken Op 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.PostExpressionGreen)this.Green;
				var greenToken = green.Op;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
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
	
	    public PostExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(Expression, this.Op);
		}
	
	    public PostExpressionSyntax WithOp(SyntaxToken op)
		{
			return this.Update(this.Expression, Op);
		}
	
	    public PostExpressionSyntax Update(ExpressionSyntax expression, SyntaxToken op)
	    {
	        if (this.Expression != expression ||
				this.Op != op)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.PostExpression(expression, op);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (PostExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitPostExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitPostExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitPostExpression(this);
	    }
	}
	
	public sealed class MultiplicationExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public MultiplicationExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MultiplicationExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken Op 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.MultiplicationExpressionGreen)this.Green;
				var greenToken = green.Op;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public MultiplicationExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.Op, this.Right);
		}
	
	    public MultiplicationExpressionSyntax WithOp(SyntaxToken op)
		{
			return this.Update(this.Left, Op, this.Right);
		}
	
	    public MultiplicationExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.Op, Right);
		}
	
	    public MultiplicationExpressionSyntax Update(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.MultiplicationExpression(left, op, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MultiplicationExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMultiplicationExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMultiplicationExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitMultiplicationExpression(this);
	    }
	}
	
	public sealed class AdditionExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public AdditionExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AdditionExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken Op 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.AdditionExpressionGreen)this.Green;
				var greenToken = green.Op;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public AdditionExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.Op, this.Right);
		}
	
	    public AdditionExpressionSyntax WithOp(SyntaxToken op)
		{
			return this.Update(this.Left, Op, this.Right);
		}
	
	    public AdditionExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.Op, Right);
		}
	
	    public AdditionExpressionSyntax Update(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.AdditionExpression(left, op, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AdditionExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAdditionExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAdditionExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitAdditionExpression(this);
	    }
	}
	
	public sealed class RelationalExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public RelationalExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public RelationalExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken Op 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.RelationalExpressionGreen)this.Green;
				var greenToken = green.Op;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public RelationalExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.Op, this.Right);
		}
	
	    public RelationalExpressionSyntax WithOp(SyntaxToken op)
		{
			return this.Update(this.Left, Op, this.Right);
		}
	
	    public RelationalExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.Op, Right);
		}
	
	    public RelationalExpressionSyntax Update(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.RelationalExpression(left, op, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (RelationalExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitRelationalExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitRelationalExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitRelationalExpression(this);
	    }
	}
	
	public sealed class TypecheckExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private TypeReferenceSyntax typeReference;
	
	    public TypecheckExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TypecheckExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken Op 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TypecheckExpressionGreen)this.Green;
				var greenToken = green.Op;
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
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.typeReference, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.typeReference;
				default: return null;
	        }
	    }
	
	    public TypecheckExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.Op, this.TypeReference);
		}
	
	    public TypecheckExpressionSyntax WithOp(SyntaxToken op)
		{
			return this.Update(this.Left, Op, this.TypeReference);
		}
	
	    public TypecheckExpressionSyntax WithTypeReference(TypeReferenceSyntax typeReference)
		{
			return this.Update(this.Left, this.Op, TypeReference);
		}
	
	    public TypecheckExpressionSyntax Update(ExpressionSyntax left, SyntaxToken op, TypeReferenceSyntax typeReference)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.TypeReference != typeReference)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TypecheckExpression(left, op, typeReference);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TypecheckExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTypecheckExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTypecheckExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTypecheckExpression(this);
	    }
	}
	
	public sealed class EqualityExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public EqualityExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public EqualityExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken Op 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.EqualityExpressionGreen)this.Green;
				var greenToken = green.Op;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public EqualityExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.Op, this.Right);
		}
	
	    public EqualityExpressionSyntax WithOp(SyntaxToken op)
		{
			return this.Update(this.Left, Op, this.Right);
		}
	
	    public EqualityExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.Op, Right);
		}
	
	    public EqualityExpressionSyntax Update(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.EqualityExpression(left, op, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (EqualityExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitEqualityExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitEqualityExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitEqualityExpression(this);
	    }
	}
	
	public sealed class BitwiseAndExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public BitwiseAndExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BitwiseAndExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken TAmp 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.BitwiseAndExpressionGreen)this.Green;
				var greenToken = green.TAmp;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public BitwiseAndExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.TAmp, this.Right);
		}
	
	    public BitwiseAndExpressionSyntax WithTAmp(SyntaxToken tAmp)
		{
			return this.Update(this.Left, TAmp, this.Right);
		}
	
	    public BitwiseAndExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.TAmp, Right);
		}
	
	    public BitwiseAndExpressionSyntax Update(ExpressionSyntax left, SyntaxToken tAmp, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.TAmp != tAmp ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.BitwiseAndExpression(left, tAmp, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BitwiseAndExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBitwiseAndExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBitwiseAndExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitBitwiseAndExpression(this);
	    }
	}
	
	public sealed class BitwiseXorExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public BitwiseXorExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BitwiseXorExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken THat 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.BitwiseXorExpressionGreen)this.Green;
				var greenToken = green.THat;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public BitwiseXorExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.THat, this.Right);
		}
	
	    public BitwiseXorExpressionSyntax WithTHat(SyntaxToken tHat)
		{
			return this.Update(this.Left, THat, this.Right);
		}
	
	    public BitwiseXorExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.THat, Right);
		}
	
	    public BitwiseXorExpressionSyntax Update(ExpressionSyntax left, SyntaxToken tHat, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.THat != tHat ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.BitwiseXorExpression(left, tHat, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BitwiseXorExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBitwiseXorExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBitwiseXorExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitBitwiseXorExpression(this);
	    }
	}
	
	public sealed class BitwiseOrExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public BitwiseOrExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BitwiseOrExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken TPipe 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.BitwiseOrExpressionGreen)this.Green;
				var greenToken = green.TPipe;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public BitwiseOrExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.TPipe, this.Right);
		}
	
	    public BitwiseOrExpressionSyntax WithTPipe(SyntaxToken tPipe)
		{
			return this.Update(this.Left, TPipe, this.Right);
		}
	
	    public BitwiseOrExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.TPipe, Right);
		}
	
	    public BitwiseOrExpressionSyntax Update(ExpressionSyntax left, SyntaxToken tPipe, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.TPipe != tPipe ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.BitwiseOrExpression(left, tPipe, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BitwiseOrExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBitwiseOrExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBitwiseOrExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitBitwiseOrExpression(this);
	    }
	}
	
	public sealed class LogicalAndExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public LogicalAndExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LogicalAndExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken TAnd 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LogicalAndExpressionGreen)this.Green;
				var greenToken = green.TAnd;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public LogicalAndExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.TAnd, this.Right);
		}
	
	    public LogicalAndExpressionSyntax WithTAnd(SyntaxToken tAnd)
		{
			return this.Update(this.Left, TAnd, this.Right);
		}
	
	    public LogicalAndExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.TAnd, Right);
		}
	
	    public LogicalAndExpressionSyntax Update(ExpressionSyntax left, SyntaxToken tAnd, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.TAnd != tAnd ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LogicalAndExpression(left, tAnd, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LogicalAndExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLogicalAndExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLogicalAndExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLogicalAndExpression(this);
	    }
	}
	
	public sealed class LogicalXorExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public LogicalXorExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LogicalXorExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken TXor 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LogicalXorExpressionGreen)this.Green;
				var greenToken = green.TXor;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public LogicalXorExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.TXor, this.Right);
		}
	
	    public LogicalXorExpressionSyntax WithTXor(SyntaxToken tXor)
		{
			return this.Update(this.Left, TXor, this.Right);
		}
	
	    public LogicalXorExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.TXor, Right);
		}
	
	    public LogicalXorExpressionSyntax Update(ExpressionSyntax left, SyntaxToken tXor, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.TXor != tXor ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LogicalXorExpression(left, tXor, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LogicalXorExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLogicalXorExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLogicalXorExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLogicalXorExpression(this);
	    }
	}
	
	public sealed class LogicalOrExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public LogicalOrExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LogicalOrExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken TOr 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LogicalOrExpressionGreen)this.Green;
				var greenToken = green.TOr;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public LogicalOrExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.TOr, this.Right);
		}
	
	    public LogicalOrExpressionSyntax WithTOr(SyntaxToken tOr)
		{
			return this.Update(this.Left, TOr, this.Right);
		}
	
	    public LogicalOrExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.TOr, Right);
		}
	
	    public LogicalOrExpressionSyntax Update(ExpressionSyntax left, SyntaxToken tOr, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.TOr != tOr ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LogicalOrExpression(left, tOr, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LogicalOrExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLogicalOrExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLogicalOrExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLogicalOrExpression(this);
	    }
	}
	
	public sealed class ConditionalExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax condition;
	    private ExpressionSyntax thenBranch;
	    private ExpressionSyntax elseBranch;
	
	    public ConditionalExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ConditionalExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Condition 
		{ 
			get { return this.GetRed(ref this.condition, 0); } 
		}
	    public SyntaxToken TQuestion 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConditionalExpressionGreen)this.Green;
				var greenToken = green.TQuestion;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax ThenBranch 
		{ 
			get { return this.GetRed(ref this.thenBranch, 2); } 
		}
	    public SyntaxToken TColon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ConditionalExpressionGreen)this.Green;
				var greenToken = green.TColon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(3), this.GetChildIndex(3));
			}
		}
	    public ExpressionSyntax ElseBranch 
		{ 
			get { return this.GetRed(ref this.elseBranch, 4); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.condition, 0);
				case 2: return this.GetRed(ref this.thenBranch, 2);
				case 4: return this.GetRed(ref this.elseBranch, 4);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.condition;
				case 2: return this.thenBranch;
				case 4: return this.elseBranch;
				default: return null;
	        }
	    }
	
	    public ConditionalExpressionSyntax WithCondition(ExpressionSyntax condition)
		{
			return this.Update(Condition, this.TQuestion, this.ThenBranch, this.TColon, this.ElseBranch);
		}
	
	    public ConditionalExpressionSyntax WithTQuestion(SyntaxToken tQuestion)
		{
			return this.Update(this.Condition, TQuestion, this.ThenBranch, this.TColon, this.ElseBranch);
		}
	
	    public ConditionalExpressionSyntax WithThenBranch(ExpressionSyntax thenBranch)
		{
			return this.Update(this.Condition, this.TQuestion, ThenBranch, this.TColon, this.ElseBranch);
		}
	
	    public ConditionalExpressionSyntax WithTColon(SyntaxToken tColon)
		{
			return this.Update(this.Condition, this.TQuestion, this.ThenBranch, TColon, this.ElseBranch);
		}
	
	    public ConditionalExpressionSyntax WithElseBranch(ExpressionSyntax elseBranch)
		{
			return this.Update(this.Condition, this.TQuestion, this.ThenBranch, this.TColon, ElseBranch);
		}
	
	    public ConditionalExpressionSyntax Update(ExpressionSyntax condition, SyntaxToken tQuestion, ExpressionSyntax thenBranch, SyntaxToken tColon, ExpressionSyntax elseBranch)
	    {
	        if (this.Condition != condition ||
				this.TQuestion != tQuestion ||
				this.ThenBranch != thenBranch ||
				this.TColon != tColon ||
				this.ElseBranch != elseBranch)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ConditionalExpression(condition, tQuestion, thenBranch, tColon, elseBranch);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ConditionalExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitConditionalExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitConditionalExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitConditionalExpression(this);
	    }
	}
	
	public sealed class AssignmentExpressionSyntax : ExpressionSyntax
	{
	    private ExpressionSyntax left;
	    private ExpressionSyntax right;
	
	    public AssignmentExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public AssignmentExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public ExpressionSyntax Left 
		{ 
			get { return this.GetRed(ref this.left, 0); } 
		}
	    public SyntaxToken Op 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.AssignmentExpressionGreen)this.Green;
				var greenToken = green.Op;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Right 
		{ 
			get { return this.GetRed(ref this.right, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.left, 0);
				case 2: return this.GetRed(ref this.right, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.left;
				case 2: return this.right;
				default: return null;
	        }
	    }
	
	    public AssignmentExpressionSyntax WithLeft(ExpressionSyntax left)
		{
			return this.Update(Left, this.Op, this.Right);
		}
	
	    public AssignmentExpressionSyntax WithOp(SyntaxToken op)
		{
			return this.Update(this.Left, Op, this.Right);
		}
	
	    public AssignmentExpressionSyntax WithRight(ExpressionSyntax right)
		{
			return this.Update(this.Left, this.Op, Right);
		}
	
	    public AssignmentExpressionSyntax Update(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
	    {
	        if (this.Left != left ||
				this.Op != op ||
				this.Right != right)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.AssignmentExpression(left, op, right);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (AssignmentExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitAssignmentExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssignmentExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitAssignmentExpression(this);
	    }
	}
	
	public sealed class LambdaExpressionSyntax : ExpressionSyntax
	{
	    private AnonymousFunctionSignatureSyntax anonymousFunctionSignature;
	    private ExpressionSyntax expression;
	
	    public LambdaExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LambdaExpressionSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public AnonymousFunctionSignatureSyntax AnonymousFunctionSignature 
		{ 
			get { return this.GetRed(ref this.anonymousFunctionSignature, 0); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.LambdaExpressionGreen)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	    public ExpressionSyntax Expression 
		{ 
			get { return this.GetRed(ref this.expression, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.anonymousFunctionSignature, 0);
				case 2: return this.GetRed(ref this.expression, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.anonymousFunctionSignature;
				case 2: return this.expression;
				default: return null;
	        }
	    }
	
	    public LambdaExpressionSyntax WithAnonymousFunctionSignature(AnonymousFunctionSignatureSyntax anonymousFunctionSignature)
		{
			return this.Update(AnonymousFunctionSignature, this.TArrow, this.Expression);
		}
	
	    public LambdaExpressionSyntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.AnonymousFunctionSignature, TArrow, this.Expression);
		}
	
	    public LambdaExpressionSyntax WithExpression(ExpressionSyntax expression)
		{
			return this.Update(this.AnonymousFunctionSignature, this.TArrow, Expression);
		}
	
	    public LambdaExpressionSyntax Update(AnonymousFunctionSignatureSyntax anonymousFunctionSignature, SyntaxToken tArrow, ExpressionSyntax expression)
	    {
	        if (this.AnonymousFunctionSignature != anonymousFunctionSignature ||
				this.TArrow != tArrow ||
				this.Expression != expression)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.LambdaExpression(anonymousFunctionSignature, tArrow, expression);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LambdaExpressionSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLambdaExpression(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLambdaExpression(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLambdaExpression(this);
	    }
	}
	
	public sealed class QualifiedNameSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	
	    public QualifiedNameSyntax WithIdentifier(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
			return this.Update(Identifier);
		}
	
	    public QualifiedNameSyntax AddIdentifier(params IdentifierSyntax[] identifier)
		{
			return this.WithIdentifier(this.Identifier.AddRange(identifier));
		}
	
	    public QualifiedNameSyntax Update(SeparatedSyntaxList<IdentifierSyntax> identifier)
	    {
	        if (this.Identifier != identifier)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.QualifiedName(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifiedName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifiedName(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifiedName(this);
	    }
	}
	
	public sealed class IdentifierListSyntax : TestLexerModeSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public IdentifierListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierListSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.IdentifierList(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierListSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifierList(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifierList(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifierList(this);
	    }
	}
	
	public sealed class IdentifierSyntax : TestLexerModeSyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IdentifierNormal 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.IdentifierGreen)this.Green;
				var greenToken = green.IdentifierNormal;
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
	
	    public IdentifierSyntax WithIdentifierNormal(SyntaxToken identifierNormal)
		{
			return this.Update(IdentifierNormal);
		}
	
	    public IdentifierSyntax Update(SyntaxToken identifierNormal)
	    {
	        if (this.IdentifierNormal != identifierNormal)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Identifier(identifierNormal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class LiteralSyntax : TestLexerModeSyntaxNode
	{
	    private NullLiteralSyntax nullLiteral;
	    private BooleanLiteralSyntax booleanLiteral;
	    private NumberLiteralSyntax numberLiteral;
	    private DateOrTimeLiteralSyntax dateOrTimeLiteral;
	    private CharLiteralxSyntax charLiteralx;
	    private StringLiteralxSyntax stringLiteralx;
	    private GuidLiteralxSyntax guidLiteralx;
	
	    public LiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
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
	    public NumberLiteralSyntax NumberLiteral 
		{ 
			get { return this.GetRed(ref this.numberLiteral, 2); } 
		}
	    public DateOrTimeLiteralSyntax DateOrTimeLiteral 
		{ 
			get { return this.GetRed(ref this.dateOrTimeLiteral, 3); } 
		}
	    public CharLiteralxSyntax CharLiteralx 
		{ 
			get { return this.GetRed(ref this.charLiteralx, 4); } 
		}
	    public StringLiteralxSyntax StringLiteralx 
		{ 
			get { return this.GetRed(ref this.stringLiteralx, 5); } 
		}
	    public GuidLiteralxSyntax GuidLiteralx 
		{ 
			get { return this.GetRed(ref this.guidLiteralx, 6); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.nullLiteral, 0);
				case 1: return this.GetRed(ref this.booleanLiteral, 1);
				case 2: return this.GetRed(ref this.numberLiteral, 2);
				case 3: return this.GetRed(ref this.dateOrTimeLiteral, 3);
				case 4: return this.GetRed(ref this.charLiteralx, 4);
				case 5: return this.GetRed(ref this.stringLiteralx, 5);
				case 6: return this.GetRed(ref this.guidLiteralx, 6);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.nullLiteral;
				case 1: return this.booleanLiteral;
				case 2: return this.numberLiteral;
				case 3: return this.dateOrTimeLiteral;
				case 4: return this.charLiteralx;
				case 5: return this.stringLiteralx;
				case 6: return this.guidLiteralx;
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
	
	    public LiteralSyntax WithNumberLiteral(NumberLiteralSyntax numberLiteral)
		{
			return this.Update(numberLiteral);
		}
	
	    public LiteralSyntax WithDateOrTimeLiteral(DateOrTimeLiteralSyntax dateOrTimeLiteral)
		{
			return this.Update(dateOrTimeLiteral);
		}
	
	    public LiteralSyntax WithCharLiteralx(CharLiteralxSyntax charLiteralx)
		{
			return this.Update(charLiteralx);
		}
	
	    public LiteralSyntax WithStringLiteralx(StringLiteralxSyntax stringLiteralx)
		{
			return this.Update(stringLiteralx);
		}
	
	    public LiteralSyntax WithGuidLiteralx(GuidLiteralxSyntax guidLiteralx)
		{
			return this.Update(guidLiteralx);
		}
	
	    public LiteralSyntax Update(NullLiteralSyntax nullLiteral)
	    {
	        if (this.NullLiteral != nullLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Literal(nullLiteral);
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Literal(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(NumberLiteralSyntax numberLiteral)
	    {
	        if (this.NumberLiteral != numberLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Literal(numberLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(DateOrTimeLiteralSyntax dateOrTimeLiteral)
	    {
	        if (this.DateOrTimeLiteral != dateOrTimeLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Literal(dateOrTimeLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(CharLiteralxSyntax charLiteralx)
	    {
	        if (this.CharLiteralx != charLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Literal(charLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(StringLiteralxSyntax stringLiteralx)
	    {
	        if (this.StringLiteralx != stringLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Literal(stringLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public LiteralSyntax Update(GuidLiteralxSyntax guidLiteralx)
	    {
	        if (this.GuidLiteralx != guidLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.Literal(guidLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteral(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteral(this);
	    }
	}
	
	public sealed class NullLiteralSyntax : TestLexerModeSyntaxNode
	{
	
	    public NullLiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullLiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNull 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.NullLiteralGreen)this.Green;
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.NullLiteral(kNull);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullLiteral(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitNullLiteral(this);
	    }
	}
	
	public sealed class BooleanLiteralSyntax : TestLexerModeSyntaxNode
	{
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BooleanLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.BooleanLiteralGreen)this.Green;
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
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.BooleanLiteral(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BooleanLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBooleanLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBooleanLiteral(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitBooleanLiteral(this);
	    }
	}
	
	public sealed class NumberLiteralSyntax : TestLexerModeSyntaxNode
	{
	    private IntegerLiteralxSyntax integerLiteralx;
	    private DecimalLiteralxSyntax decimalLiteralx;
	    private ScientificLiteralxSyntax scientificLiteralx;
	
	    public NumberLiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NumberLiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public IntegerLiteralxSyntax IntegerLiteralx 
		{ 
			get { return this.GetRed(ref this.integerLiteralx, 0); } 
		}
	    public DecimalLiteralxSyntax DecimalLiteralx 
		{ 
			get { return this.GetRed(ref this.decimalLiteralx, 1); } 
		}
	    public ScientificLiteralxSyntax ScientificLiteralx 
		{ 
			get { return this.GetRed(ref this.scientificLiteralx, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.integerLiteralx, 0);
				case 1: return this.GetRed(ref this.decimalLiteralx, 1);
				case 2: return this.GetRed(ref this.scientificLiteralx, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.integerLiteralx;
				case 1: return this.decimalLiteralx;
				case 2: return this.scientificLiteralx;
				default: return null;
	        }
	    }
	
	    public NumberLiteralSyntax WithIntegerLiteralx(IntegerLiteralxSyntax integerLiteralx)
		{
			return this.Update(integerLiteralx);
		}
	
	    public NumberLiteralSyntax WithDecimalLiteralx(DecimalLiteralxSyntax decimalLiteralx)
		{
			return this.Update(decimalLiteralx);
		}
	
	    public NumberLiteralSyntax WithScientificLiteralx(ScientificLiteralxSyntax scientificLiteralx)
		{
			return this.Update(scientificLiteralx);
		}
	
	    public NumberLiteralSyntax Update(IntegerLiteralxSyntax integerLiteralx)
	    {
	        if (this.IntegerLiteralx != integerLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.NumberLiteral(integerLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NumberLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public NumberLiteralSyntax Update(DecimalLiteralxSyntax decimalLiteralx)
	    {
	        if (this.DecimalLiteralx != decimalLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.NumberLiteral(decimalLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NumberLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public NumberLiteralSyntax Update(ScientificLiteralxSyntax scientificLiteralx)
	    {
	        if (this.ScientificLiteralx != scientificLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.NumberLiteral(scientificLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NumberLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNumberLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNumberLiteral(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitNumberLiteral(this);
	    }
	}
	
	public sealed class IntegerLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public IntegerLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IntegerLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken IntegerLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.IntegerLiteralxGreen)this.Green;
				var greenToken = green.IntegerLiteral;
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
	
	    public IntegerLiteralxSyntax WithIntegerLiteral(SyntaxToken integerLiteral)
		{
			return this.Update(IntegerLiteral);
		}
	
	    public IntegerLiteralxSyntax Update(SyntaxToken integerLiteral)
	    {
	        if (this.IntegerLiteral != integerLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.IntegerLiteralx(integerLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIntegerLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIntegerLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitIntegerLiteralx(this);
	    }
	}
	
	public sealed class DecimalLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public DecimalLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DecimalLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken DecimalLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.DecimalLiteralxGreen)this.Green;
				var greenToken = green.DecimalLiteral;
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
	
	    public DecimalLiteralxSyntax WithDecimalLiteral(SyntaxToken decimalLiteral)
		{
			return this.Update(DecimalLiteral);
		}
	
	    public DecimalLiteralxSyntax Update(SyntaxToken decimalLiteral)
	    {
	        if (this.DecimalLiteral != decimalLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.DecimalLiteralx(decimalLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DecimalLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDecimalLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDecimalLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitDecimalLiteralx(this);
	    }
	}
	
	public sealed class ScientificLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public ScientificLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ScientificLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken ScientificLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.ScientificLiteralxGreen)this.Green;
				var greenToken = green.ScientificLiteral;
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
	
	    public ScientificLiteralxSyntax WithScientificLiteral(SyntaxToken scientificLiteral)
		{
			return this.Update(ScientificLiteral);
		}
	
	    public ScientificLiteralxSyntax Update(SyntaxToken scientificLiteral)
	    {
	        if (this.ScientificLiteral != scientificLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.ScientificLiteralx(scientificLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ScientificLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitScientificLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitScientificLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitScientificLiteralx(this);
	    }
	}
	
	public sealed class DateOrTimeLiteralSyntax : TestLexerModeSyntaxNode
	{
	    private DateTimeLiteralxSyntax dateTimeLiteralx;
	    private DateTimeOffsetLiteralxSyntax dateTimeOffsetLiteralx;
	    private DateLiteralxSyntax dateLiteralx;
	    private TimeLiteralxSyntax timeLiteralx;
	
	    public DateOrTimeLiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DateOrTimeLiteralSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public DateTimeLiteralxSyntax DateTimeLiteralx 
		{ 
			get { return this.GetRed(ref this.dateTimeLiteralx, 0); } 
		}
	    public DateTimeOffsetLiteralxSyntax DateTimeOffsetLiteralx 
		{ 
			get { return this.GetRed(ref this.dateTimeOffsetLiteralx, 1); } 
		}
	    public DateLiteralxSyntax DateLiteralx 
		{ 
			get { return this.GetRed(ref this.dateLiteralx, 2); } 
		}
	    public TimeLiteralxSyntax TimeLiteralx 
		{ 
			get { return this.GetRed(ref this.timeLiteralx, 3); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.dateTimeLiteralx, 0);
				case 1: return this.GetRed(ref this.dateTimeOffsetLiteralx, 1);
				case 2: return this.GetRed(ref this.dateLiteralx, 2);
				case 3: return this.GetRed(ref this.timeLiteralx, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.dateTimeLiteralx;
				case 1: return this.dateTimeOffsetLiteralx;
				case 2: return this.dateLiteralx;
				case 3: return this.timeLiteralx;
				default: return null;
	        }
	    }
	
	    public DateOrTimeLiteralSyntax WithDateTimeLiteralx(DateTimeLiteralxSyntax dateTimeLiteralx)
		{
			return this.Update(dateTimeLiteralx);
		}
	
	    public DateOrTimeLiteralSyntax WithDateTimeOffsetLiteralx(DateTimeOffsetLiteralxSyntax dateTimeOffsetLiteralx)
		{
			return this.Update(dateTimeOffsetLiteralx);
		}
	
	    public DateOrTimeLiteralSyntax WithDateLiteralx(DateLiteralxSyntax dateLiteralx)
		{
			return this.Update(dateLiteralx);
		}
	
	    public DateOrTimeLiteralSyntax WithTimeLiteralx(TimeLiteralxSyntax timeLiteralx)
		{
			return this.Update(timeLiteralx);
		}
	
	    public DateOrTimeLiteralSyntax Update(DateTimeLiteralxSyntax dateTimeLiteralx)
	    {
	        if (this.DateTimeLiteralx != dateTimeLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.DateOrTimeLiteral(dateTimeLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateOrTimeLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DateOrTimeLiteralSyntax Update(DateTimeOffsetLiteralxSyntax dateTimeOffsetLiteralx)
	    {
	        if (this.DateTimeOffsetLiteralx != dateTimeOffsetLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.DateOrTimeLiteral(dateTimeOffsetLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateOrTimeLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DateOrTimeLiteralSyntax Update(DateLiteralxSyntax dateLiteralx)
	    {
	        if (this.DateLiteralx != dateLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.DateOrTimeLiteral(dateLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateOrTimeLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public DateOrTimeLiteralSyntax Update(TimeLiteralxSyntax timeLiteralx)
	    {
	        if (this.TimeLiteralx != timeLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.DateOrTimeLiteral(timeLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateOrTimeLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDateOrTimeLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDateOrTimeLiteral(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitDateOrTimeLiteral(this);
	    }
	}
	
	public sealed class DateTimeOffsetLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public DateTimeOffsetLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DateTimeOffsetLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken DateTimeOffsetLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.DateTimeOffsetLiteralxGreen)this.Green;
				var greenToken = green.DateTimeOffsetLiteral;
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
	
	    public DateTimeOffsetLiteralxSyntax WithDateTimeOffsetLiteral(SyntaxToken dateTimeOffsetLiteral)
		{
			return this.Update(DateTimeOffsetLiteral);
		}
	
	    public DateTimeOffsetLiteralxSyntax Update(SyntaxToken dateTimeOffsetLiteral)
	    {
	        if (this.DateTimeOffsetLiteral != dateTimeOffsetLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.DateTimeOffsetLiteralx(dateTimeOffsetLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateTimeOffsetLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDateTimeOffsetLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDateTimeOffsetLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitDateTimeOffsetLiteralx(this);
	    }
	}
	
	public sealed class DateTimeLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public DateTimeLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DateTimeLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken DateTimeLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.DateTimeLiteralxGreen)this.Green;
				var greenToken = green.DateTimeLiteral;
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
	
	    public DateTimeLiteralxSyntax WithDateTimeLiteral(SyntaxToken dateTimeLiteral)
		{
			return this.Update(DateTimeLiteral);
		}
	
	    public DateTimeLiteralxSyntax Update(SyntaxToken dateTimeLiteral)
	    {
	        if (this.DateTimeLiteral != dateTimeLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.DateTimeLiteralx(dateTimeLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateTimeLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDateTimeLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDateTimeLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitDateTimeLiteralx(this);
	    }
	}
	
	public sealed class DateLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public DateLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DateLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken DateLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.DateLiteralxGreen)this.Green;
				var greenToken = green.DateLiteral;
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
	
	    public DateLiteralxSyntax WithDateLiteral(SyntaxToken dateLiteral)
		{
			return this.Update(DateLiteral);
		}
	
	    public DateLiteralxSyntax Update(SyntaxToken dateLiteral)
	    {
	        if (this.DateLiteral != dateLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.DateLiteralx(dateLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DateLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDateLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDateLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitDateLiteralx(this);
	    }
	}
	
	public sealed class TimeLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public TimeLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TimeLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TimeLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.TimeLiteralxGreen)this.Green;
				var greenToken = green.TimeLiteral;
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
	
	    public TimeLiteralxSyntax WithTimeLiteral(SyntaxToken timeLiteral)
		{
			return this.Update(TimeLiteral);
		}
	
	    public TimeLiteralxSyntax Update(SyntaxToken timeLiteral)
	    {
	        if (this.TimeLiteral != timeLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.TimeLiteralx(timeLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TimeLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTimeLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTimeLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitTimeLiteralx(this);
	    }
	}
	
	public sealed class CharLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public CharLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public CharLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken CharLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.CharLiteralxGreen)this.Green;
				var greenToken = green.CharLiteral;
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
	
	    public CharLiteralxSyntax WithCharLiteral(SyntaxToken charLiteral)
		{
			return this.Update(CharLiteral);
		}
	
	    public CharLiteralxSyntax Update(SyntaxToken charLiteral)
	    {
	        if (this.CharLiteral != charLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.CharLiteralx(charLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (CharLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitCharLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitCharLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitCharLiteralx(this);
	    }
	}
	
	public sealed class StringLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public StringLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken StringLiteralx 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.StringLiteralxGreen)this.Green;
				var greenToken = green.StringLiteralx;
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
	
	    public StringLiteralxSyntax WithStringLiteralx(SyntaxToken stringLiteralx)
		{
			return this.Update(StringLiteralx);
		}
	
	    public StringLiteralxSyntax Update(SyntaxToken stringLiteralx)
	    {
	        if (this.StringLiteralx != stringLiteralx)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.StringLiteralx(stringLiteralx);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStringLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStringLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitStringLiteralx(this);
	    }
	}
	
	public sealed class GuidLiteralxSyntax : TestLexerModeSyntaxNode
	{
	
	    public GuidLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public GuidLiteralxSyntax(InternalSyntaxNode green, TestLexerModeSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken GuidLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax.GuidLiteralxGreen)this.Green;
				var greenToken = green.GuidLiteral;
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
	
	    public GuidLiteralxSyntax WithGuidLiteral(SyntaxToken guidLiteral)
		{
			return this.Update(GuidLiteral);
		}
	
	    public GuidLiteralxSyntax Update(SyntaxToken guidLiteral)
	    {
	        if (this.GuidLiteral != guidLiteral)
	        {
	            var newNode = TestLexerModeLanguage.Instance.SyntaxFactory.GuidLiteralx(guidLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (GuidLiteralxSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLexerModeSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitGuidLiteralx(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLexerModeSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitGuidLiteralx(this);
	    }
	
	    public override void Accept(ITestLexerModeSyntaxVisitor visitor)
	    {
	        visitor.VisitGuidLiteralx(this);
	    }
	}
}

namespace MetaDslx.CodeAnalysis.Antlr4Test
{
    using System.Threading;
    using Microsoft.CodeAnalysis.Text;
	using MetaDslx.CodeAnalysis.Antlr4Test.Syntax;
    using MetaDslx.CodeAnalysis.Antlr4Test.Syntax.InternalSyntax;

	public interface ITestLexerModeSyntaxVisitor
	{
		
		void VisitMain(MainSyntax node);
		
		void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		void VisitGeneratorDeclaration(GeneratorDeclarationSyntax node);
		
		void VisitUsingNamespaceDeclaration(UsingNamespaceDeclarationSyntax node);
		
		void VisitUsingGeneratorDeclaration(UsingGeneratorDeclarationSyntax node);
		
		void VisitConfigDeclaration(ConfigDeclarationSyntax node);
		
		void VisitConfigPropertyDeclaration(ConfigPropertyDeclarationSyntax node);
		
		void VisitConfigPropertyGroupDeclaration(ConfigPropertyGroupDeclarationSyntax node);
		
		void VisitMethodDeclaration(MethodDeclarationSyntax node);
		
		void VisitExternFunctionDeclaration(ExternFunctionDeclarationSyntax node);
		
		void VisitFunctionDeclaration(FunctionDeclarationSyntax node);
		
		void VisitFunctionSignature(FunctionSignatureSyntax node);
		
		void VisitParamList(ParamListSyntax node);
		
		void VisitParameter(ParameterSyntax node);
		
		void VisitBody(BodySyntax node);
		
		void VisitStatement(StatementSyntax node);
		
		void VisitSingleStatement(SingleStatementSyntax node);
		
		void VisitSingleStatementSemicolon(SingleStatementSemicolonSyntax node);
		
		void VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node);
		
		void VisitVariableDeclarationExpression(VariableDeclarationExpressionSyntax node);
		
		void VisitVariableDeclarationItem(VariableDeclarationItemSyntax node);
		
		void VisitVoidStatement(VoidStatementSyntax node);
		
		void VisitReturnStatement(ReturnStatementSyntax node);
		
		void VisitExpressionStatement(ExpressionStatementSyntax node);
		
		void VisitIfStatement(IfStatementSyntax node);
		
		void VisitElseIfStatementBody(ElseIfStatementBodySyntax node);
		
		void VisitIfStatementElseBody(IfStatementElseBodySyntax node);
		
		void VisitIfStatementBegin(IfStatementBeginSyntax node);
		
		void VisitElseIfStatement(ElseIfStatementSyntax node);
		
		void VisitIfStatementElse(IfStatementElseSyntax node);
		
		void VisitIfStatementEnd(IfStatementEndSyntax node);
		
		void VisitForStatement(ForStatementSyntax node);
		
		void VisitForStatementBegin(ForStatementBeginSyntax node);
		
		void VisitForStatementEnd(ForStatementEndSyntax node);
		
		void VisitForInitStatement(ForInitStatementSyntax node);
		
		void VisitWhileStatement(WhileStatementSyntax node);
		
		void VisitWhileStatementBegin(WhileStatementBeginSyntax node);
		
		void VisitWhileStatementEnd(WhileStatementEndSyntax node);
		
		void VisitWhileRunExpression(WhileRunExpressionSyntax node);
		
		void VisitRepeatStatement(RepeatStatementSyntax node);
		
		void VisitRepeatStatementBegin(RepeatStatementBeginSyntax node);
		
		void VisitRepeatStatementEnd(RepeatStatementEndSyntax node);
		
		void VisitRepeatRunExpression(RepeatRunExpressionSyntax node);
		
		void VisitLoopStatement(LoopStatementSyntax node);
		
		void VisitLoopStatementBegin(LoopStatementBeginSyntax node);
		
		void VisitLoopStatementEnd(LoopStatementEndSyntax node);
		
		void VisitLoopChain(LoopChainSyntax node);
		
		void VisitLoopChainItem(LoopChainItemSyntax node);
		
		void VisitLoopChainTypeofExpression(LoopChainTypeofExpressionSyntax node);
		
		void VisitLoopChainIdentifierExpression(LoopChainIdentifierExpressionSyntax node);
		
		void VisitLoopChainMemberAccessExpression(LoopChainMemberAccessExpressionSyntax node);
		
		void VisitLoopChainMethodCallExpression(LoopChainMethodCallExpressionSyntax node);
		
		void VisitLoopWhereExpression(LoopWhereExpressionSyntax node);
		
		void VisitLoopRunExpression(LoopRunExpressionSyntax node);
		
		void VisitSeparatorStatement(SeparatorStatementSyntax node);
		
		void VisitSwitchStatement(SwitchStatementSyntax node);
		
		void VisitSwitchStatementBegin(SwitchStatementBeginSyntax node);
		
		void VisitSwitchStatementEnd(SwitchStatementEndSyntax node);
		
		void VisitSwitchBranchStatement(SwitchBranchStatementSyntax node);
		
		void VisitSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node);
		
		void VisitSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node);
		
		void VisitSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node);
		
		void VisitSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node);
		
		void VisitSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node);
		
		void VisitSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node);
		
		void VisitSwitchDefaultStatement(SwitchDefaultStatementSyntax node);
		
		void VisitSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node);
		
		void VisitTemplateDeclaration(TemplateDeclarationSyntax node);
		
		void VisitTemplateSignature(TemplateSignatureSyntax node);
		
		void VisitTemplateBody(TemplateBodySyntax node);
		
		void VisitTemplateContentLine(TemplateContentLineSyntax node);
		
		void VisitTemplateContent(TemplateContentSyntax node);
		
		void VisitTemplateOutputx(TemplateOutputxSyntax node);
		
		void VisitTemplateLineEnd(TemplateLineEndSyntax node);
		
		void VisitTemplateStatementStartEnd(TemplateStatementStartEndSyntax node);
		
		void VisitTemplateStatement(TemplateStatementSyntax node);
		
		void VisitTypeArgumentList(TypeArgumentListSyntax node);
		
		void VisitPredefinedType(PredefinedTypeSyntax node);
		
		void VisitTypeReferenceList(TypeReferenceListSyntax node);
		
		void VisitTypeReference(TypeReferenceSyntax node);
		
		void VisitArrayType(ArrayTypeSyntax node);
		
		void VisitArrayItemType(ArrayItemTypeSyntax node);
		
		void VisitNullableType(NullableTypeSyntax node);
		
		void VisitNullableItemType(NullableItemTypeSyntax node);
		
		void VisitGenericType(GenericTypeSyntax node);
		
		void VisitSimpleType(SimpleTypeSyntax node);
		
		void VisitVoidType(VoidTypeSyntax node);
		
		void VisitReturnType(ReturnTypeSyntax node);
		
		void VisitExpressionList(ExpressionListSyntax node);
		
		void VisitVariableReference(VariableReferenceSyntax node);
		
		void VisitRankSpecifiers(RankSpecifiersSyntax node);
		
		void VisitRankSpecifier(RankSpecifierSyntax node);
		
		void VisitUnboundTypeName(UnboundTypeNameSyntax node);
		
		void VisitGenericDimensionItem(GenericDimensionItemSyntax node);
		
		void VisitGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node);
		
		void VisitExplicitAnonymousFunctionSignature(ExplicitAnonymousFunctionSignatureSyntax node);
		
		void VisitImplicitAnonymousFunctionSignature(ImplicitAnonymousFunctionSignatureSyntax node);
		
		void VisitSingleParamAnonymousFunctionSignature(SingleParamAnonymousFunctionSignatureSyntax node);
		
		void VisitExplicitParameter(ExplicitParameterSyntax node);
		
		void VisitImplicitParameter(ImplicitParameterSyntax node);
		
		void VisitThisExpression(ThisExpressionSyntax node);
		
		void VisitLiteralExpression(LiteralExpressionSyntax node);
		
		void VisitTypeofVoidExpression(TypeofVoidExpressionSyntax node);
		
		void VisitTypeofUnboundTypeExpression(TypeofUnboundTypeExpressionSyntax node);
		
		void VisitTypeofTypeExpression(TypeofTypeExpressionSyntax node);
		
		void VisitDefaultValueExpression(DefaultValueExpressionSyntax node);
		
		void VisitNewObjectOrCollectionWithConstructorExpression(NewObjectOrCollectionWithConstructorExpressionSyntax node);
		
		void VisitIdentifierExpression(IdentifierExpressionSyntax node);
		
		void VisitHasLoopExpression(HasLoopExpressionSyntax node);
		
		void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node);
		
		void VisitElementAccessExpression(ElementAccessExpressionSyntax node);
		
		void VisitFunctionCallExpression(FunctionCallExpressionSyntax node);
		
		void VisitPredefinedTypeMemberAccessExpression(PredefinedTypeMemberAccessExpressionSyntax node);
		
		void VisitMemberAccessExpression(MemberAccessExpressionSyntax node);
		
		void VisitTypecastExpression(TypecastExpressionSyntax node);
		
		void VisitUnaryExpression(UnaryExpressionSyntax node);
		
		void VisitPostExpression(PostExpressionSyntax node);
		
		void VisitMultiplicationExpression(MultiplicationExpressionSyntax node);
		
		void VisitAdditionExpression(AdditionExpressionSyntax node);
		
		void VisitRelationalExpression(RelationalExpressionSyntax node);
		
		void VisitTypecheckExpression(TypecheckExpressionSyntax node);
		
		void VisitEqualityExpression(EqualityExpressionSyntax node);
		
		void VisitBitwiseAndExpression(BitwiseAndExpressionSyntax node);
		
		void VisitBitwiseXorExpression(BitwiseXorExpressionSyntax node);
		
		void VisitBitwiseOrExpression(BitwiseOrExpressionSyntax node);
		
		void VisitLogicalAndExpression(LogicalAndExpressionSyntax node);
		
		void VisitLogicalXorExpression(LogicalXorExpressionSyntax node);
		
		void VisitLogicalOrExpression(LogicalOrExpressionSyntax node);
		
		void VisitConditionalExpression(ConditionalExpressionSyntax node);
		
		void VisitAssignmentExpression(AssignmentExpressionSyntax node);
		
		void VisitLambdaExpression(LambdaExpressionSyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitIdentifierList(IdentifierListSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitLiteral(LiteralSyntax node);
		
		void VisitNullLiteral(NullLiteralSyntax node);
		
		void VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		void VisitNumberLiteral(NumberLiteralSyntax node);
		
		void VisitIntegerLiteralx(IntegerLiteralxSyntax node);
		
		void VisitDecimalLiteralx(DecimalLiteralxSyntax node);
		
		void VisitScientificLiteralx(ScientificLiteralxSyntax node);
		
		void VisitDateOrTimeLiteral(DateOrTimeLiteralSyntax node);
		
		void VisitDateTimeOffsetLiteralx(DateTimeOffsetLiteralxSyntax node);
		
		void VisitDateTimeLiteralx(DateTimeLiteralxSyntax node);
		
		void VisitDateLiteralx(DateLiteralxSyntax node);
		
		void VisitTimeLiteralx(TimeLiteralxSyntax node);
		
		void VisitCharLiteralx(CharLiteralxSyntax node);
		
		void VisitStringLiteralx(StringLiteralxSyntax node);
		
		void VisitGuidLiteralx(GuidLiteralxSyntax node);
	}
	
	public class TestLexerModeSyntaxVisitor : SyntaxVisitor, ITestLexerModeSyntaxVisitor
	{
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitGeneratorDeclaration(GeneratorDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUsingNamespaceDeclaration(UsingNamespaceDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUsingGeneratorDeclaration(UsingGeneratorDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitConfigDeclaration(ConfigDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitConfigPropertyDeclaration(ConfigPropertyDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitConfigPropertyGroupDeclaration(ConfigPropertyGroupDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMethodDeclaration(MethodDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitExternFunctionDeclaration(ExternFunctionDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFunctionSignature(FunctionSignatureSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParamList(ParamListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParameter(ParameterSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBody(BodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStatement(StatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSingleStatement(SingleStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSingleStatementSemicolon(SingleStatementSemicolonSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVariableDeclarationExpression(VariableDeclarationExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVariableDeclarationItem(VariableDeclarationItemSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVoidStatement(VoidStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitReturnStatement(ReturnStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitExpressionStatement(ExpressionStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIfStatement(IfStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElseIfStatementBody(ElseIfStatementBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIfStatementElseBody(IfStatementElseBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIfStatementBegin(IfStatementBeginSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElseIfStatement(ElseIfStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIfStatementElse(IfStatementElseSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIfStatementEnd(IfStatementEndSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitForStatement(ForStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitForStatementBegin(ForStatementBeginSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitForStatementEnd(ForStatementEndSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitForInitStatement(ForInitStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWhileStatement(WhileStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWhileStatementBegin(WhileStatementBeginSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWhileStatementEnd(WhileStatementEndSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitWhileRunExpression(WhileRunExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRepeatStatement(RepeatStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRepeatStatementBegin(RepeatStatementBeginSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRepeatStatementEnd(RepeatStatementEndSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRepeatRunExpression(RepeatRunExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopStatement(LoopStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopStatementBegin(LoopStatementBeginSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopStatementEnd(LoopStatementEndSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopChain(LoopChainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopChainItem(LoopChainItemSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopChainTypeofExpression(LoopChainTypeofExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopChainIdentifierExpression(LoopChainIdentifierExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopChainMemberAccessExpression(LoopChainMemberAccessExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopChainMethodCallExpression(LoopChainMethodCallExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopWhereExpression(LoopWhereExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLoopRunExpression(LoopRunExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSeparatorStatement(SeparatorStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchStatement(SwitchStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchStatementBegin(SwitchStatementBeginSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchStatementEnd(SwitchStatementEndSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchBranchStatement(SwitchBranchStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchDefaultStatement(SwitchDefaultStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTemplateDeclaration(TemplateDeclarationSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTemplateSignature(TemplateSignatureSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTemplateBody(TemplateBodySyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTemplateContentLine(TemplateContentLineSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTemplateContent(TemplateContentSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTemplateOutputx(TemplateOutputxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTemplateLineEnd(TemplateLineEndSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTemplateStatementStartEnd(TemplateStatementStartEndSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTemplateStatement(TemplateStatementSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeArgumentList(TypeArgumentListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPredefinedType(PredefinedTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeReferenceList(TypeReferenceListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrayType(ArrayTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrayItemType(ArrayItemTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNullableItemType(NullableItemTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitGenericType(GenericTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitExpressionList(ExpressionListSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVariableReference(VariableReferenceSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRankSpecifiers(RankSpecifiersSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRankSpecifier(RankSpecifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUnboundTypeName(UnboundTypeNameSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitGenericDimensionItem(GenericDimensionItemSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitExplicitAnonymousFunctionSignature(ExplicitAnonymousFunctionSignatureSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitImplicitAnonymousFunctionSignature(ImplicitAnonymousFunctionSignatureSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSingleParamAnonymousFunctionSignature(SingleParamAnonymousFunctionSignatureSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitExplicitParameter(ExplicitParameterSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitImplicitParameter(ImplicitParameterSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitThisExpression(ThisExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLiteralExpression(LiteralExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeofVoidExpression(TypeofVoidExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeofUnboundTypeExpression(TypeofUnboundTypeExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypeofTypeExpression(TypeofTypeExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDefaultValueExpression(DefaultValueExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNewObjectOrCollectionWithConstructorExpression(NewObjectOrCollectionWithConstructorExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIdentifierExpression(IdentifierExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitHasLoopExpression(HasLoopExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitElementAccessExpression(ElementAccessExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPredefinedTypeMemberAccessExpression(PredefinedTypeMemberAccessExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypecastExpression(TypecastExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitUnaryExpression(UnaryExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitPostExpression(PostExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitMultiplicationExpression(MultiplicationExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAdditionExpression(AdditionExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitRelationalExpression(RelationalExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTypecheckExpression(TypecheckExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitEqualityExpression(EqualityExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBitwiseAndExpression(BitwiseAndExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBitwiseXorExpression(BitwiseXorExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitBitwiseOrExpression(BitwiseOrExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLogicalAndExpression(LogicalAndExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLogicalXorExpression(LogicalXorExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLogicalOrExpression(LogicalOrExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitConditionalExpression(ConditionalExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitAssignmentExpression(AssignmentExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitLambdaExpression(LambdaExpressionSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
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
		
		public virtual void VisitNumberLiteral(NumberLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitIntegerLiteralx(IntegerLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDecimalLiteralx(DecimalLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitScientificLiteralx(ScientificLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDateOrTimeLiteral(DateOrTimeLiteralSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDateTimeOffsetLiteralx(DateTimeOffsetLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDateTimeLiteralx(DateTimeLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDateLiteralx(DateLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTimeLiteralx(TimeLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitCharLiteralx(CharLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitStringLiteralx(StringLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitGuidLiteralx(GuidLiteralxSyntax node)
		{
		    this.DefaultVisit(node);
		}
	}

	//GenerateDetailedSyntaxVisitor()

	public interface ITestLexerModeSyntaxVisitor<TArg, TResult> 
	{
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument);
		
		TResult VisitGeneratorDeclaration(GeneratorDeclarationSyntax node, TArg argument);
		
		TResult VisitUsingNamespaceDeclaration(UsingNamespaceDeclarationSyntax node, TArg argument);
		
		TResult VisitUsingGeneratorDeclaration(UsingGeneratorDeclarationSyntax node, TArg argument);
		
		TResult VisitConfigDeclaration(ConfigDeclarationSyntax node, TArg argument);
		
		TResult VisitConfigPropertyDeclaration(ConfigPropertyDeclarationSyntax node, TArg argument);
		
		TResult VisitConfigPropertyGroupDeclaration(ConfigPropertyGroupDeclarationSyntax node, TArg argument);
		
		TResult VisitMethodDeclaration(MethodDeclarationSyntax node, TArg argument);
		
		TResult VisitExternFunctionDeclaration(ExternFunctionDeclarationSyntax node, TArg argument);
		
		TResult VisitFunctionDeclaration(FunctionDeclarationSyntax node, TArg argument);
		
		TResult VisitFunctionSignature(FunctionSignatureSyntax node, TArg argument);
		
		TResult VisitParamList(ParamListSyntax node, TArg argument);
		
		TResult VisitParameter(ParameterSyntax node, TArg argument);
		
		TResult VisitBody(BodySyntax node, TArg argument);
		
		TResult VisitStatement(StatementSyntax node, TArg argument);
		
		TResult VisitSingleStatement(SingleStatementSyntax node, TArg argument);
		
		TResult VisitSingleStatementSemicolon(SingleStatementSemicolonSyntax node, TArg argument);
		
		TResult VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node, TArg argument);
		
		TResult VisitVariableDeclarationExpression(VariableDeclarationExpressionSyntax node, TArg argument);
		
		TResult VisitVariableDeclarationItem(VariableDeclarationItemSyntax node, TArg argument);
		
		TResult VisitVoidStatement(VoidStatementSyntax node, TArg argument);
		
		TResult VisitReturnStatement(ReturnStatementSyntax node, TArg argument);
		
		TResult VisitExpressionStatement(ExpressionStatementSyntax node, TArg argument);
		
		TResult VisitIfStatement(IfStatementSyntax node, TArg argument);
		
		TResult VisitElseIfStatementBody(ElseIfStatementBodySyntax node, TArg argument);
		
		TResult VisitIfStatementElseBody(IfStatementElseBodySyntax node, TArg argument);
		
		TResult VisitIfStatementBegin(IfStatementBeginSyntax node, TArg argument);
		
		TResult VisitElseIfStatement(ElseIfStatementSyntax node, TArg argument);
		
		TResult VisitIfStatementElse(IfStatementElseSyntax node, TArg argument);
		
		TResult VisitIfStatementEnd(IfStatementEndSyntax node, TArg argument);
		
		TResult VisitForStatement(ForStatementSyntax node, TArg argument);
		
		TResult VisitForStatementBegin(ForStatementBeginSyntax node, TArg argument);
		
		TResult VisitForStatementEnd(ForStatementEndSyntax node, TArg argument);
		
		TResult VisitForInitStatement(ForInitStatementSyntax node, TArg argument);
		
		TResult VisitWhileStatement(WhileStatementSyntax node, TArg argument);
		
		TResult VisitWhileStatementBegin(WhileStatementBeginSyntax node, TArg argument);
		
		TResult VisitWhileStatementEnd(WhileStatementEndSyntax node, TArg argument);
		
		TResult VisitWhileRunExpression(WhileRunExpressionSyntax node, TArg argument);
		
		TResult VisitRepeatStatement(RepeatStatementSyntax node, TArg argument);
		
		TResult VisitRepeatStatementBegin(RepeatStatementBeginSyntax node, TArg argument);
		
		TResult VisitRepeatStatementEnd(RepeatStatementEndSyntax node, TArg argument);
		
		TResult VisitRepeatRunExpression(RepeatRunExpressionSyntax node, TArg argument);
		
		TResult VisitLoopStatement(LoopStatementSyntax node, TArg argument);
		
		TResult VisitLoopStatementBegin(LoopStatementBeginSyntax node, TArg argument);
		
		TResult VisitLoopStatementEnd(LoopStatementEndSyntax node, TArg argument);
		
		TResult VisitLoopChain(LoopChainSyntax node, TArg argument);
		
		TResult VisitLoopChainItem(LoopChainItemSyntax node, TArg argument);
		
		TResult VisitLoopChainTypeofExpression(LoopChainTypeofExpressionSyntax node, TArg argument);
		
		TResult VisitLoopChainIdentifierExpression(LoopChainIdentifierExpressionSyntax node, TArg argument);
		
		TResult VisitLoopChainMemberAccessExpression(LoopChainMemberAccessExpressionSyntax node, TArg argument);
		
		TResult VisitLoopChainMethodCallExpression(LoopChainMethodCallExpressionSyntax node, TArg argument);
		
		TResult VisitLoopWhereExpression(LoopWhereExpressionSyntax node, TArg argument);
		
		TResult VisitLoopRunExpression(LoopRunExpressionSyntax node, TArg argument);
		
		TResult VisitSeparatorStatement(SeparatorStatementSyntax node, TArg argument);
		
		TResult VisitSwitchStatement(SwitchStatementSyntax node, TArg argument);
		
		TResult VisitSwitchStatementBegin(SwitchStatementBeginSyntax node, TArg argument);
		
		TResult VisitSwitchStatementEnd(SwitchStatementEndSyntax node, TArg argument);
		
		TResult VisitSwitchBranchStatement(SwitchBranchStatementSyntax node, TArg argument);
		
		TResult VisitSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node, TArg argument);
		
		TResult VisitSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node, TArg argument);
		
		TResult VisitSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node, TArg argument);
		
		TResult VisitSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node, TArg argument);
		
		TResult VisitSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node, TArg argument);
		
		TResult VisitSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node, TArg argument);
		
		TResult VisitSwitchDefaultStatement(SwitchDefaultStatementSyntax node, TArg argument);
		
		TResult VisitSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node, TArg argument);
		
		TResult VisitTemplateDeclaration(TemplateDeclarationSyntax node, TArg argument);
		
		TResult VisitTemplateSignature(TemplateSignatureSyntax node, TArg argument);
		
		TResult VisitTemplateBody(TemplateBodySyntax node, TArg argument);
		
		TResult VisitTemplateContentLine(TemplateContentLineSyntax node, TArg argument);
		
		TResult VisitTemplateContent(TemplateContentSyntax node, TArg argument);
		
		TResult VisitTemplateOutputx(TemplateOutputxSyntax node, TArg argument);
		
		TResult VisitTemplateLineEnd(TemplateLineEndSyntax node, TArg argument);
		
		TResult VisitTemplateStatementStartEnd(TemplateStatementStartEndSyntax node, TArg argument);
		
		TResult VisitTemplateStatement(TemplateStatementSyntax node, TArg argument);
		
		TResult VisitTypeArgumentList(TypeArgumentListSyntax node, TArg argument);
		
		TResult VisitPredefinedType(PredefinedTypeSyntax node, TArg argument);
		
		TResult VisitTypeReferenceList(TypeReferenceListSyntax node, TArg argument);
		
		TResult VisitTypeReference(TypeReferenceSyntax node, TArg argument);
		
		TResult VisitArrayType(ArrayTypeSyntax node, TArg argument);
		
		TResult VisitArrayItemType(ArrayItemTypeSyntax node, TArg argument);
		
		TResult VisitNullableType(NullableTypeSyntax node, TArg argument);
		
		TResult VisitNullableItemType(NullableItemTypeSyntax node, TArg argument);
		
		TResult VisitGenericType(GenericTypeSyntax node, TArg argument);
		
		TResult VisitSimpleType(SimpleTypeSyntax node, TArg argument);
		
		TResult VisitVoidType(VoidTypeSyntax node, TArg argument);
		
		TResult VisitReturnType(ReturnTypeSyntax node, TArg argument);
		
		TResult VisitExpressionList(ExpressionListSyntax node, TArg argument);
		
		TResult VisitVariableReference(VariableReferenceSyntax node, TArg argument);
		
		TResult VisitRankSpecifiers(RankSpecifiersSyntax node, TArg argument);
		
		TResult VisitRankSpecifier(RankSpecifierSyntax node, TArg argument);
		
		TResult VisitUnboundTypeName(UnboundTypeNameSyntax node, TArg argument);
		
		TResult VisitGenericDimensionItem(GenericDimensionItemSyntax node, TArg argument);
		
		TResult VisitGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node, TArg argument);
		
		TResult VisitExplicitAnonymousFunctionSignature(ExplicitAnonymousFunctionSignatureSyntax node, TArg argument);
		
		TResult VisitImplicitAnonymousFunctionSignature(ImplicitAnonymousFunctionSignatureSyntax node, TArg argument);
		
		TResult VisitSingleParamAnonymousFunctionSignature(SingleParamAnonymousFunctionSignatureSyntax node, TArg argument);
		
		TResult VisitExplicitParameter(ExplicitParameterSyntax node, TArg argument);
		
		TResult VisitImplicitParameter(ImplicitParameterSyntax node, TArg argument);
		
		TResult VisitThisExpression(ThisExpressionSyntax node, TArg argument);
		
		TResult VisitLiteralExpression(LiteralExpressionSyntax node, TArg argument);
		
		TResult VisitTypeofVoidExpression(TypeofVoidExpressionSyntax node, TArg argument);
		
		TResult VisitTypeofUnboundTypeExpression(TypeofUnboundTypeExpressionSyntax node, TArg argument);
		
		TResult VisitTypeofTypeExpression(TypeofTypeExpressionSyntax node, TArg argument);
		
		TResult VisitDefaultValueExpression(DefaultValueExpressionSyntax node, TArg argument);
		
		TResult VisitNewObjectOrCollectionWithConstructorExpression(NewObjectOrCollectionWithConstructorExpressionSyntax node, TArg argument);
		
		TResult VisitIdentifierExpression(IdentifierExpressionSyntax node, TArg argument);
		
		TResult VisitHasLoopExpression(HasLoopExpressionSyntax node, TArg argument);
		
		TResult VisitParenthesizedExpression(ParenthesizedExpressionSyntax node, TArg argument);
		
		TResult VisitElementAccessExpression(ElementAccessExpressionSyntax node, TArg argument);
		
		TResult VisitFunctionCallExpression(FunctionCallExpressionSyntax node, TArg argument);
		
		TResult VisitPredefinedTypeMemberAccessExpression(PredefinedTypeMemberAccessExpressionSyntax node, TArg argument);
		
		TResult VisitMemberAccessExpression(MemberAccessExpressionSyntax node, TArg argument);
		
		TResult VisitTypecastExpression(TypecastExpressionSyntax node, TArg argument);
		
		TResult VisitUnaryExpression(UnaryExpressionSyntax node, TArg argument);
		
		TResult VisitPostExpression(PostExpressionSyntax node, TArg argument);
		
		TResult VisitMultiplicationExpression(MultiplicationExpressionSyntax node, TArg argument);
		
		TResult VisitAdditionExpression(AdditionExpressionSyntax node, TArg argument);
		
		TResult VisitRelationalExpression(RelationalExpressionSyntax node, TArg argument);
		
		TResult VisitTypecheckExpression(TypecheckExpressionSyntax node, TArg argument);
		
		TResult VisitEqualityExpression(EqualityExpressionSyntax node, TArg argument);
		
		TResult VisitBitwiseAndExpression(BitwiseAndExpressionSyntax node, TArg argument);
		
		TResult VisitBitwiseXorExpression(BitwiseXorExpressionSyntax node, TArg argument);
		
		TResult VisitBitwiseOrExpression(BitwiseOrExpressionSyntax node, TArg argument);
		
		TResult VisitLogicalAndExpression(LogicalAndExpressionSyntax node, TArg argument);
		
		TResult VisitLogicalXorExpression(LogicalXorExpressionSyntax node, TArg argument);
		
		TResult VisitLogicalOrExpression(LogicalOrExpressionSyntax node, TArg argument);
		
		TResult VisitConditionalExpression(ConditionalExpressionSyntax node, TArg argument);
		
		TResult VisitAssignmentExpression(AssignmentExpressionSyntax node, TArg argument);
		
		TResult VisitLambdaExpression(LambdaExpressionSyntax node, TArg argument);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument);
		
		TResult VisitIdentifierList(IdentifierListSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
		TResult VisitLiteral(LiteralSyntax node, TArg argument);
		
		TResult VisitNullLiteral(NullLiteralSyntax node, TArg argument);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node, TArg argument);
		
		TResult VisitNumberLiteral(NumberLiteralSyntax node, TArg argument);
		
		TResult VisitIntegerLiteralx(IntegerLiteralxSyntax node, TArg argument);
		
		TResult VisitDecimalLiteralx(DecimalLiteralxSyntax node, TArg argument);
		
		TResult VisitScientificLiteralx(ScientificLiteralxSyntax node, TArg argument);
		
		TResult VisitDateOrTimeLiteral(DateOrTimeLiteralSyntax node, TArg argument);
		
		TResult VisitDateTimeOffsetLiteralx(DateTimeOffsetLiteralxSyntax node, TArg argument);
		
		TResult VisitDateTimeLiteralx(DateTimeLiteralxSyntax node, TArg argument);
		
		TResult VisitDateLiteralx(DateLiteralxSyntax node, TArg argument);
		
		TResult VisitTimeLiteralx(TimeLiteralxSyntax node, TArg argument);
		
		TResult VisitCharLiteralx(CharLiteralxSyntax node, TArg argument);
		
		TResult VisitStringLiteralx(StringLiteralxSyntax node, TArg argument);
		
		TResult VisitGuidLiteralx(GuidLiteralxSyntax node, TArg argument);
	}
	
	public class TestLexerModeSyntaxVisitor<TArg, TResult> : SyntaxVisitor<TArg, TResult>, ITestLexerModeSyntaxVisitor<TArg, TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitGeneratorDeclaration(GeneratorDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUsingNamespaceDeclaration(UsingNamespaceDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUsingGeneratorDeclaration(UsingGeneratorDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitConfigDeclaration(ConfigDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitConfigPropertyDeclaration(ConfigPropertyDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitConfigPropertyGroupDeclaration(ConfigPropertyGroupDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMethodDeclaration(MethodDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitExternFunctionDeclaration(ExternFunctionDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFunctionDeclaration(FunctionDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFunctionSignature(FunctionSignatureSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParamList(ParamListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParameter(ParameterSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBody(BodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStatement(StatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSingleStatement(SingleStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSingleStatementSemicolon(SingleStatementSemicolonSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVariableDeclarationExpression(VariableDeclarationExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVariableDeclarationItem(VariableDeclarationItemSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVoidStatement(VoidStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitReturnStatement(ReturnStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitExpressionStatement(ExpressionStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIfStatement(IfStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElseIfStatementBody(ElseIfStatementBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIfStatementElseBody(IfStatementElseBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIfStatementBegin(IfStatementBeginSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElseIfStatement(ElseIfStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIfStatementElse(IfStatementElseSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIfStatementEnd(IfStatementEndSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitForStatement(ForStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitForStatementBegin(ForStatementBeginSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitForStatementEnd(ForStatementEndSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitForInitStatement(ForInitStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWhileStatement(WhileStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWhileStatementBegin(WhileStatementBeginSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWhileStatementEnd(WhileStatementEndSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitWhileRunExpression(WhileRunExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRepeatStatement(RepeatStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRepeatStatementBegin(RepeatStatementBeginSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRepeatStatementEnd(RepeatStatementEndSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRepeatRunExpression(RepeatRunExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopStatement(LoopStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopStatementBegin(LoopStatementBeginSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopStatementEnd(LoopStatementEndSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopChain(LoopChainSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopChainItem(LoopChainItemSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopChainTypeofExpression(LoopChainTypeofExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopChainIdentifierExpression(LoopChainIdentifierExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopChainMemberAccessExpression(LoopChainMemberAccessExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopChainMethodCallExpression(LoopChainMethodCallExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopWhereExpression(LoopWhereExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLoopRunExpression(LoopRunExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSeparatorStatement(SeparatorStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchStatement(SwitchStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchStatementBegin(SwitchStatementBeginSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchStatementEnd(SwitchStatementEndSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchBranchStatement(SwitchBranchStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchDefaultStatement(SwitchDefaultStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTemplateDeclaration(TemplateDeclarationSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTemplateSignature(TemplateSignatureSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTemplateBody(TemplateBodySyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTemplateContentLine(TemplateContentLineSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTemplateContent(TemplateContentSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTemplateOutputx(TemplateOutputxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTemplateLineEnd(TemplateLineEndSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTemplateStatementStartEnd(TemplateStatementStartEndSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTemplateStatement(TemplateStatementSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeArgumentList(TypeArgumentListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPredefinedType(PredefinedTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeReferenceList(TypeReferenceListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeReference(TypeReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrayType(ArrayTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrayItemType(ArrayItemTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNullableType(NullableTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNullableItemType(NullableItemTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitGenericType(GenericTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSimpleType(SimpleTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVoidType(VoidTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitReturnType(ReturnTypeSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitExpressionList(ExpressionListSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVariableReference(VariableReferenceSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRankSpecifiers(RankSpecifiersSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRankSpecifier(RankSpecifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUnboundTypeName(UnboundTypeNameSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitGenericDimensionItem(GenericDimensionItemSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitExplicitAnonymousFunctionSignature(ExplicitAnonymousFunctionSignatureSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitImplicitAnonymousFunctionSignature(ImplicitAnonymousFunctionSignatureSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSingleParamAnonymousFunctionSignature(SingleParamAnonymousFunctionSignatureSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitExplicitParameter(ExplicitParameterSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitImplicitParameter(ImplicitParameterSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitThisExpression(ThisExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLiteralExpression(LiteralExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeofVoidExpression(TypeofVoidExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeofUnboundTypeExpression(TypeofUnboundTypeExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypeofTypeExpression(TypeofTypeExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDefaultValueExpression(DefaultValueExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNewObjectOrCollectionWithConstructorExpression(NewObjectOrCollectionWithConstructorExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIdentifierExpression(IdentifierExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitHasLoopExpression(HasLoopExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitParenthesizedExpression(ParenthesizedExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitElementAccessExpression(ElementAccessExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitFunctionCallExpression(FunctionCallExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPredefinedTypeMemberAccessExpression(PredefinedTypeMemberAccessExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMemberAccessExpression(MemberAccessExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypecastExpression(TypecastExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitUnaryExpression(UnaryExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitPostExpression(PostExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitMultiplicationExpression(MultiplicationExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAdditionExpression(AdditionExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitRelationalExpression(RelationalExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTypecheckExpression(TypecheckExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitEqualityExpression(EqualityExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBitwiseAndExpression(BitwiseAndExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBitwiseXorExpression(BitwiseXorExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitBitwiseOrExpression(BitwiseOrExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLogicalAndExpression(LogicalAndExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLogicalXorExpression(LogicalXorExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLogicalOrExpression(LogicalOrExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitConditionalExpression(ConditionalExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitAssignmentExpression(AssignmentExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitLambdaExpression(LambdaExpressionSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument)
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
		
		public virtual TResult VisitNumberLiteral(NumberLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitIntegerLiteralx(IntegerLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDecimalLiteralx(DecimalLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitScientificLiteralx(ScientificLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDateOrTimeLiteral(DateOrTimeLiteralSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDateTimeOffsetLiteralx(DateTimeOffsetLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDateTimeLiteralx(DateTimeLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDateLiteralx(DateLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTimeLiteralx(TimeLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitCharLiteralx(CharLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitStringLiteralx(StringLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitGuidLiteralx(GuidLiteralxSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
	}

	public interface ITestLexerModeSyntaxVisitor<TResult> 
	{
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
		
		TResult VisitGeneratorDeclaration(GeneratorDeclarationSyntax node);
		
		TResult VisitUsingNamespaceDeclaration(UsingNamespaceDeclarationSyntax node);
		
		TResult VisitUsingGeneratorDeclaration(UsingGeneratorDeclarationSyntax node);
		
		TResult VisitConfigDeclaration(ConfigDeclarationSyntax node);
		
		TResult VisitConfigPropertyDeclaration(ConfigPropertyDeclarationSyntax node);
		
		TResult VisitConfigPropertyGroupDeclaration(ConfigPropertyGroupDeclarationSyntax node);
		
		TResult VisitMethodDeclaration(MethodDeclarationSyntax node);
		
		TResult VisitExternFunctionDeclaration(ExternFunctionDeclarationSyntax node);
		
		TResult VisitFunctionDeclaration(FunctionDeclarationSyntax node);
		
		TResult VisitFunctionSignature(FunctionSignatureSyntax node);
		
		TResult VisitParamList(ParamListSyntax node);
		
		TResult VisitParameter(ParameterSyntax node);
		
		TResult VisitBody(BodySyntax node);
		
		TResult VisitStatement(StatementSyntax node);
		
		TResult VisitSingleStatement(SingleStatementSyntax node);
		
		TResult VisitSingleStatementSemicolon(SingleStatementSemicolonSyntax node);
		
		TResult VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node);
		
		TResult VisitVariableDeclarationExpression(VariableDeclarationExpressionSyntax node);
		
		TResult VisitVariableDeclarationItem(VariableDeclarationItemSyntax node);
		
		TResult VisitVoidStatement(VoidStatementSyntax node);
		
		TResult VisitReturnStatement(ReturnStatementSyntax node);
		
		TResult VisitExpressionStatement(ExpressionStatementSyntax node);
		
		TResult VisitIfStatement(IfStatementSyntax node);
		
		TResult VisitElseIfStatementBody(ElseIfStatementBodySyntax node);
		
		TResult VisitIfStatementElseBody(IfStatementElseBodySyntax node);
		
		TResult VisitIfStatementBegin(IfStatementBeginSyntax node);
		
		TResult VisitElseIfStatement(ElseIfStatementSyntax node);
		
		TResult VisitIfStatementElse(IfStatementElseSyntax node);
		
		TResult VisitIfStatementEnd(IfStatementEndSyntax node);
		
		TResult VisitForStatement(ForStatementSyntax node);
		
		TResult VisitForStatementBegin(ForStatementBeginSyntax node);
		
		TResult VisitForStatementEnd(ForStatementEndSyntax node);
		
		TResult VisitForInitStatement(ForInitStatementSyntax node);
		
		TResult VisitWhileStatement(WhileStatementSyntax node);
		
		TResult VisitWhileStatementBegin(WhileStatementBeginSyntax node);
		
		TResult VisitWhileStatementEnd(WhileStatementEndSyntax node);
		
		TResult VisitWhileRunExpression(WhileRunExpressionSyntax node);
		
		TResult VisitRepeatStatement(RepeatStatementSyntax node);
		
		TResult VisitRepeatStatementBegin(RepeatStatementBeginSyntax node);
		
		TResult VisitRepeatStatementEnd(RepeatStatementEndSyntax node);
		
		TResult VisitRepeatRunExpression(RepeatRunExpressionSyntax node);
		
		TResult VisitLoopStatement(LoopStatementSyntax node);
		
		TResult VisitLoopStatementBegin(LoopStatementBeginSyntax node);
		
		TResult VisitLoopStatementEnd(LoopStatementEndSyntax node);
		
		TResult VisitLoopChain(LoopChainSyntax node);
		
		TResult VisitLoopChainItem(LoopChainItemSyntax node);
		
		TResult VisitLoopChainTypeofExpression(LoopChainTypeofExpressionSyntax node);
		
		TResult VisitLoopChainIdentifierExpression(LoopChainIdentifierExpressionSyntax node);
		
		TResult VisitLoopChainMemberAccessExpression(LoopChainMemberAccessExpressionSyntax node);
		
		TResult VisitLoopChainMethodCallExpression(LoopChainMethodCallExpressionSyntax node);
		
		TResult VisitLoopWhereExpression(LoopWhereExpressionSyntax node);
		
		TResult VisitLoopRunExpression(LoopRunExpressionSyntax node);
		
		TResult VisitSeparatorStatement(SeparatorStatementSyntax node);
		
		TResult VisitSwitchStatement(SwitchStatementSyntax node);
		
		TResult VisitSwitchStatementBegin(SwitchStatementBeginSyntax node);
		
		TResult VisitSwitchStatementEnd(SwitchStatementEndSyntax node);
		
		TResult VisitSwitchBranchStatement(SwitchBranchStatementSyntax node);
		
		TResult VisitSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node);
		
		TResult VisitSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node);
		
		TResult VisitSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node);
		
		TResult VisitSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node);
		
		TResult VisitSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node);
		
		TResult VisitSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node);
		
		TResult VisitSwitchDefaultStatement(SwitchDefaultStatementSyntax node);
		
		TResult VisitSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node);
		
		TResult VisitTemplateDeclaration(TemplateDeclarationSyntax node);
		
		TResult VisitTemplateSignature(TemplateSignatureSyntax node);
		
		TResult VisitTemplateBody(TemplateBodySyntax node);
		
		TResult VisitTemplateContentLine(TemplateContentLineSyntax node);
		
		TResult VisitTemplateContent(TemplateContentSyntax node);
		
		TResult VisitTemplateOutputx(TemplateOutputxSyntax node);
		
		TResult VisitTemplateLineEnd(TemplateLineEndSyntax node);
		
		TResult VisitTemplateStatementStartEnd(TemplateStatementStartEndSyntax node);
		
		TResult VisitTemplateStatement(TemplateStatementSyntax node);
		
		TResult VisitTypeArgumentList(TypeArgumentListSyntax node);
		
		TResult VisitPredefinedType(PredefinedTypeSyntax node);
		
		TResult VisitTypeReferenceList(TypeReferenceListSyntax node);
		
		TResult VisitTypeReference(TypeReferenceSyntax node);
		
		TResult VisitArrayType(ArrayTypeSyntax node);
		
		TResult VisitArrayItemType(ArrayItemTypeSyntax node);
		
		TResult VisitNullableType(NullableTypeSyntax node);
		
		TResult VisitNullableItemType(NullableItemTypeSyntax node);
		
		TResult VisitGenericType(GenericTypeSyntax node);
		
		TResult VisitSimpleType(SimpleTypeSyntax node);
		
		TResult VisitVoidType(VoidTypeSyntax node);
		
		TResult VisitReturnType(ReturnTypeSyntax node);
		
		TResult VisitExpressionList(ExpressionListSyntax node);
		
		TResult VisitVariableReference(VariableReferenceSyntax node);
		
		TResult VisitRankSpecifiers(RankSpecifiersSyntax node);
		
		TResult VisitRankSpecifier(RankSpecifierSyntax node);
		
		TResult VisitUnboundTypeName(UnboundTypeNameSyntax node);
		
		TResult VisitGenericDimensionItem(GenericDimensionItemSyntax node);
		
		TResult VisitGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node);
		
		TResult VisitExplicitAnonymousFunctionSignature(ExplicitAnonymousFunctionSignatureSyntax node);
		
		TResult VisitImplicitAnonymousFunctionSignature(ImplicitAnonymousFunctionSignatureSyntax node);
		
		TResult VisitSingleParamAnonymousFunctionSignature(SingleParamAnonymousFunctionSignatureSyntax node);
		
		TResult VisitExplicitParameter(ExplicitParameterSyntax node);
		
		TResult VisitImplicitParameter(ImplicitParameterSyntax node);
		
		TResult VisitThisExpression(ThisExpressionSyntax node);
		
		TResult VisitLiteralExpression(LiteralExpressionSyntax node);
		
		TResult VisitTypeofVoidExpression(TypeofVoidExpressionSyntax node);
		
		TResult VisitTypeofUnboundTypeExpression(TypeofUnboundTypeExpressionSyntax node);
		
		TResult VisitTypeofTypeExpression(TypeofTypeExpressionSyntax node);
		
		TResult VisitDefaultValueExpression(DefaultValueExpressionSyntax node);
		
		TResult VisitNewObjectOrCollectionWithConstructorExpression(NewObjectOrCollectionWithConstructorExpressionSyntax node);
		
		TResult VisitIdentifierExpression(IdentifierExpressionSyntax node);
		
		TResult VisitHasLoopExpression(HasLoopExpressionSyntax node);
		
		TResult VisitParenthesizedExpression(ParenthesizedExpressionSyntax node);
		
		TResult VisitElementAccessExpression(ElementAccessExpressionSyntax node);
		
		TResult VisitFunctionCallExpression(FunctionCallExpressionSyntax node);
		
		TResult VisitPredefinedTypeMemberAccessExpression(PredefinedTypeMemberAccessExpressionSyntax node);
		
		TResult VisitMemberAccessExpression(MemberAccessExpressionSyntax node);
		
		TResult VisitTypecastExpression(TypecastExpressionSyntax node);
		
		TResult VisitUnaryExpression(UnaryExpressionSyntax node);
		
		TResult VisitPostExpression(PostExpressionSyntax node);
		
		TResult VisitMultiplicationExpression(MultiplicationExpressionSyntax node);
		
		TResult VisitAdditionExpression(AdditionExpressionSyntax node);
		
		TResult VisitRelationalExpression(RelationalExpressionSyntax node);
		
		TResult VisitTypecheckExpression(TypecheckExpressionSyntax node);
		
		TResult VisitEqualityExpression(EqualityExpressionSyntax node);
		
		TResult VisitBitwiseAndExpression(BitwiseAndExpressionSyntax node);
		
		TResult VisitBitwiseXorExpression(BitwiseXorExpressionSyntax node);
		
		TResult VisitBitwiseOrExpression(BitwiseOrExpressionSyntax node);
		
		TResult VisitLogicalAndExpression(LogicalAndExpressionSyntax node);
		
		TResult VisitLogicalXorExpression(LogicalXorExpressionSyntax node);
		
		TResult VisitLogicalOrExpression(LogicalOrExpressionSyntax node);
		
		TResult VisitConditionalExpression(ConditionalExpressionSyntax node);
		
		TResult VisitAssignmentExpression(AssignmentExpressionSyntax node);
		
		TResult VisitLambdaExpression(LambdaExpressionSyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitIdentifierList(IdentifierListSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitLiteral(LiteralSyntax node);
		
		TResult VisitNullLiteral(NullLiteralSyntax node);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		TResult VisitNumberLiteral(NumberLiteralSyntax node);
		
		TResult VisitIntegerLiteralx(IntegerLiteralxSyntax node);
		
		TResult VisitDecimalLiteralx(DecimalLiteralxSyntax node);
		
		TResult VisitScientificLiteralx(ScientificLiteralxSyntax node);
		
		TResult VisitDateOrTimeLiteral(DateOrTimeLiteralSyntax node);
		
		TResult VisitDateTimeOffsetLiteralx(DateTimeOffsetLiteralxSyntax node);
		
		TResult VisitDateTimeLiteralx(DateTimeLiteralxSyntax node);
		
		TResult VisitDateLiteralx(DateLiteralxSyntax node);
		
		TResult VisitTimeLiteralx(TimeLiteralxSyntax node);
		
		TResult VisitCharLiteralx(CharLiteralxSyntax node);
		
		TResult VisitStringLiteralx(StringLiteralxSyntax node);
		
		TResult VisitGuidLiteralx(GuidLiteralxSyntax node);
	}
	
	public class TestLexerModeSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, ITestLexerModeSyntaxVisitor<TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitGeneratorDeclaration(GeneratorDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUsingNamespaceDeclaration(UsingNamespaceDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUsingGeneratorDeclaration(UsingGeneratorDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitConfigDeclaration(ConfigDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitConfigPropertyDeclaration(ConfigPropertyDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitConfigPropertyGroupDeclaration(ConfigPropertyGroupDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMethodDeclaration(MethodDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitExternFunctionDeclaration(ExternFunctionDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFunctionDeclaration(FunctionDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFunctionSignature(FunctionSignatureSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParamList(ParamListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParameter(ParameterSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBody(BodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStatement(StatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSingleStatement(SingleStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSingleStatementSemicolon(SingleStatementSemicolonSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVariableDeclarationExpression(VariableDeclarationExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVariableDeclarationItem(VariableDeclarationItemSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVoidStatement(VoidStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitReturnStatement(ReturnStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitExpressionStatement(ExpressionStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIfStatement(IfStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElseIfStatementBody(ElseIfStatementBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIfStatementElseBody(IfStatementElseBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIfStatementBegin(IfStatementBeginSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElseIfStatement(ElseIfStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIfStatementElse(IfStatementElseSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIfStatementEnd(IfStatementEndSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitForStatement(ForStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitForStatementBegin(ForStatementBeginSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitForStatementEnd(ForStatementEndSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitForInitStatement(ForInitStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWhileStatement(WhileStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWhileStatementBegin(WhileStatementBeginSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWhileStatementEnd(WhileStatementEndSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitWhileRunExpression(WhileRunExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRepeatStatement(RepeatStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRepeatStatementBegin(RepeatStatementBeginSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRepeatStatementEnd(RepeatStatementEndSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRepeatRunExpression(RepeatRunExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopStatement(LoopStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopStatementBegin(LoopStatementBeginSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopStatementEnd(LoopStatementEndSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopChain(LoopChainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopChainItem(LoopChainItemSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopChainTypeofExpression(LoopChainTypeofExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopChainIdentifierExpression(LoopChainIdentifierExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopChainMemberAccessExpression(LoopChainMemberAccessExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopChainMethodCallExpression(LoopChainMethodCallExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopWhereExpression(LoopWhereExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLoopRunExpression(LoopRunExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSeparatorStatement(SeparatorStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchStatement(SwitchStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchStatementBegin(SwitchStatementBeginSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchStatementEnd(SwitchStatementEndSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchBranchStatement(SwitchBranchStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchDefaultStatement(SwitchDefaultStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTemplateDeclaration(TemplateDeclarationSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTemplateSignature(TemplateSignatureSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTemplateBody(TemplateBodySyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTemplateContentLine(TemplateContentLineSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTemplateContent(TemplateContentSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTemplateOutputx(TemplateOutputxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTemplateLineEnd(TemplateLineEndSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTemplateStatementStartEnd(TemplateStatementStartEndSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTemplateStatement(TemplateStatementSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeArgumentList(TypeArgumentListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPredefinedType(PredefinedTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeReferenceList(TypeReferenceListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeReference(TypeReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrayType(ArrayTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrayItemType(ArrayItemTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNullableType(NullableTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNullableItemType(NullableItemTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitGenericType(GenericTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSimpleType(SimpleTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVoidType(VoidTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitReturnType(ReturnTypeSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitExpressionList(ExpressionListSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVariableReference(VariableReferenceSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRankSpecifiers(RankSpecifiersSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRankSpecifier(RankSpecifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUnboundTypeName(UnboundTypeNameSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitGenericDimensionItem(GenericDimensionItemSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitExplicitAnonymousFunctionSignature(ExplicitAnonymousFunctionSignatureSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitImplicitAnonymousFunctionSignature(ImplicitAnonymousFunctionSignatureSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSingleParamAnonymousFunctionSignature(SingleParamAnonymousFunctionSignatureSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitExplicitParameter(ExplicitParameterSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitImplicitParameter(ImplicitParameterSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitThisExpression(ThisExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLiteralExpression(LiteralExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeofVoidExpression(TypeofVoidExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeofUnboundTypeExpression(TypeofUnboundTypeExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypeofTypeExpression(TypeofTypeExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDefaultValueExpression(DefaultValueExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNewObjectOrCollectionWithConstructorExpression(NewObjectOrCollectionWithConstructorExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIdentifierExpression(IdentifierExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitHasLoopExpression(HasLoopExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitElementAccessExpression(ElementAccessExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPredefinedTypeMemberAccessExpression(PredefinedTypeMemberAccessExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypecastExpression(TypecastExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitUnaryExpression(UnaryExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitPostExpression(PostExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitMultiplicationExpression(MultiplicationExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAdditionExpression(AdditionExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitRelationalExpression(RelationalExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTypecheckExpression(TypecheckExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitEqualityExpression(EqualityExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBitwiseAndExpression(BitwiseAndExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBitwiseXorExpression(BitwiseXorExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitBitwiseOrExpression(BitwiseOrExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLogicalAndExpression(LogicalAndExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLogicalXorExpression(LogicalXorExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLogicalOrExpression(LogicalOrExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitConditionalExpression(ConditionalExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitAssignmentExpression(AssignmentExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitLambdaExpression(LambdaExpressionSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitQualifiedName(QualifiedNameSyntax node)
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
		
		public virtual TResult VisitNumberLiteral(NumberLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitIntegerLiteralx(IntegerLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDecimalLiteralx(DecimalLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitScientificLiteralx(ScientificLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDateOrTimeLiteral(DateOrTimeLiteralSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDateTimeOffsetLiteralx(DateTimeOffsetLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDateTimeLiteralx(DateTimeLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDateLiteralx(DateLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTimeLiteralx(TimeLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitCharLiteralx(CharLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitStringLiteralx(StringLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitGuidLiteralx(GuidLiteralxSyntax node)
		{
		    return this.DefaultVisit(node);
		}
	}

	public class TestLexerModeSyntaxRewriter : SyntaxRewriter, ITestLexerModeSyntaxVisitor<SyntaxNode>
	{
	    public TestLexerModeSyntaxRewriter(bool visitIntoStructuredTrivia = false)
			: base(TestLexerModeLanguage.Instance, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var namespaceDeclaration = (NamespaceDeclarationSyntax)this.Visit(node.NamespaceDeclaration);
		    var generatorDeclaration = (GeneratorDeclarationSyntax)this.Visit(node.GeneratorDeclaration);
		    var usingDeclaration = this.VisitList(node.UsingDeclaration);
		    var configDeclaration = (ConfigDeclarationSyntax)this.Visit(node.ConfigDeclaration);
		    var methodDeclaration = this.VisitList(node.MethodDeclaration);
		    var eOF = this.VisitToken(node.EndOfFileToken);
			return node.Update(namespaceDeclaration, generatorDeclaration, usingDeclaration, configDeclaration, methodDeclaration, eOF);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kNamespace, qualifiedName, tSemicolon);
		}
		
		public virtual SyntaxNode VisitGeneratorDeclaration(GeneratorDeclarationSyntax node)
		{
		    var kGenerator = this.VisitToken(node.KGenerator);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tColon = this.VisitToken(node.TColon);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var kFor = this.VisitToken(node.KFor);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kGenerator, identifier, tColon, qualifiedName, kFor, typeReference, tSemicolon);
		}
		
		public virtual SyntaxNode VisitUsingNamespaceDeclaration(UsingNamespaceDeclarationSyntax node)
		{
		    var kUsing = this.VisitToken(node.KUsing);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kUsing, qualifiedName, tSemicolon);
		}
		
		public virtual SyntaxNode VisitUsingGeneratorDeclaration(UsingGeneratorDeclarationSyntax node)
		{
		    var kUsing = this.VisitToken(node.KUsing);
		    var kGenerator = this.VisitToken(node.KGenerator);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kUsing, kGenerator, qualifiedName, identifier, tSemicolon);
		}
		
		public virtual SyntaxNode VisitConfigDeclaration(ConfigDeclarationSyntax node)
		{
		    var startProperties = this.VisitToken(node.StartProperties);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var configProperty = this.VisitList(node.ConfigProperty);
		    var kEnd = this.VisitToken(node.KEnd);
		    var endProperties = this.VisitToken(node.EndProperties);
			return node.Update(startProperties, identifier, configProperty, kEnd, endProperties);
		}
		
		public virtual SyntaxNode VisitConfigPropertyDeclaration(ConfigPropertyDeclarationSyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tAssign = this.VisitToken(node.TAssign);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(typeReference, identifier, tAssign, expression, tSemicolon);
		}
		
		public virtual SyntaxNode VisitConfigPropertyGroupDeclaration(ConfigPropertyGroupDeclarationSyntax node)
		{
		    var startProperties = this.VisitToken(node.StartProperties);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var configProperty = this.VisitList(node.ConfigProperty);
		    var kEnd = this.VisitToken(node.KEnd);
		    var endProperties = this.VisitToken(node.EndProperties);
			return node.Update(startProperties, identifier, configProperty, kEnd, endProperties);
		}
		
		public virtual SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
		{
			var oldFunctionDeclaration = node.FunctionDeclaration;
			if (oldFunctionDeclaration != null)
			{
			    var newFunctionDeclaration = (FunctionDeclarationSyntax)this.Visit(oldFunctionDeclaration);
				return node.Update(newFunctionDeclaration);
			}
			var oldTemplateDeclaration = node.TemplateDeclaration;
			if (oldTemplateDeclaration != null)
			{
			    var newTemplateDeclaration = (TemplateDeclarationSyntax)this.Visit(oldTemplateDeclaration);
				return node.Update(newTemplateDeclaration);
			}
			var oldExternFunctionDeclaration = node.ExternFunctionDeclaration;
			if (oldExternFunctionDeclaration != null)
			{
			    var newExternFunctionDeclaration = (ExternFunctionDeclarationSyntax)this.Visit(oldExternFunctionDeclaration);
				return node.Update(newExternFunctionDeclaration);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitExternFunctionDeclaration(ExternFunctionDeclarationSyntax node)
		{
		    var kExtern = this.VisitToken(node.KExtern);
		    var functionSignature = (FunctionSignatureSyntax)this.Visit(node.FunctionSignature);
			return node.Update(kExtern, functionSignature);
		}
		
		public virtual SyntaxNode VisitFunctionDeclaration(FunctionDeclarationSyntax node)
		{
		    var functionSignature = (FunctionSignatureSyntax)this.Visit(node.FunctionSignature);
		    var body = (BodySyntax)this.Visit(node.Body);
		    var kEnd = this.VisitToken(node.KEnd);
		    var kFunction = this.VisitToken(node.KFunction);
			return node.Update(functionSignature, body, kEnd, kFunction);
		}
		
		public virtual SyntaxNode VisitFunctionSignature(FunctionSignatureSyntax node)
		{
		    var kFunction = this.VisitToken(node.KFunction);
		    var returnType = (ReturnTypeSyntax)this.Visit(node.ReturnType);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var typeArgumentList = (TypeArgumentListSyntax)this.Visit(node.TypeArgumentList);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var paramList = (ParamListSyntax)this.Visit(node.ParamList);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kFunction, returnType, identifier, typeArgumentList, tOpenParenthesis, paramList, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitParamList(ParamListSyntax node)
		{
		    var parameter = this.VisitList(node.Parameter);
			return node.Update(parameter);
		}
		
		public virtual SyntaxNode VisitParameter(ParameterSyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tAssign = this.VisitToken(node.TAssign);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(typeReference, identifier, tAssign, expression);
		}
		
		public virtual SyntaxNode VisitBody(BodySyntax node)
		{
		    var statement = this.VisitList(node.Statement);
			return node.Update(statement);
		}
		
		public virtual SyntaxNode VisitStatement(StatementSyntax node)
		{
			var oldSingleStatementSemicolon = node.SingleStatementSemicolon;
			if (oldSingleStatementSemicolon != null)
			{
			    var newSingleStatementSemicolon = (SingleStatementSemicolonSyntax)this.Visit(oldSingleStatementSemicolon);
				return node.Update(newSingleStatementSemicolon);
			}
			var oldIfStatement = node.IfStatement;
			if (oldIfStatement != null)
			{
			    var newIfStatement = (IfStatementSyntax)this.Visit(oldIfStatement);
				return node.Update(newIfStatement);
			}
			var oldForStatement = node.ForStatement;
			if (oldForStatement != null)
			{
			    var newForStatement = (ForStatementSyntax)this.Visit(oldForStatement);
				return node.Update(newForStatement);
			}
			var oldWhileStatement = node.WhileStatement;
			if (oldWhileStatement != null)
			{
			    var newWhileStatement = (WhileStatementSyntax)this.Visit(oldWhileStatement);
				return node.Update(newWhileStatement);
			}
			var oldRepeatStatement = node.RepeatStatement;
			if (oldRepeatStatement != null)
			{
			    var newRepeatStatement = (RepeatStatementSyntax)this.Visit(oldRepeatStatement);
				return node.Update(newRepeatStatement);
			}
			var oldLoopStatement = node.LoopStatement;
			if (oldLoopStatement != null)
			{
			    var newLoopStatement = (LoopStatementSyntax)this.Visit(oldLoopStatement);
				return node.Update(newLoopStatement);
			}
			var oldSwitchStatement = node.SwitchStatement;
			if (oldSwitchStatement != null)
			{
			    var newSwitchStatement = (SwitchStatementSyntax)this.Visit(oldSwitchStatement);
				return node.Update(newSwitchStatement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSingleStatement(SingleStatementSyntax node)
		{
			var oldVariableDeclarationStatement = node.VariableDeclarationStatement;
			if (oldVariableDeclarationStatement != null)
			{
			    var newVariableDeclarationStatement = (VariableDeclarationStatementSyntax)this.Visit(oldVariableDeclarationStatement);
				return node.Update(newVariableDeclarationStatement);
			}
			var oldReturnStatement = node.ReturnStatement;
			if (oldReturnStatement != null)
			{
			    var newReturnStatement = (ReturnStatementSyntax)this.Visit(oldReturnStatement);
				return node.Update(newReturnStatement);
			}
			var oldExpressionStatement = node.ExpressionStatement;
			if (oldExpressionStatement != null)
			{
			    var newExpressionStatement = (ExpressionStatementSyntax)this.Visit(oldExpressionStatement);
				return node.Update(newExpressionStatement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSingleStatementSemicolon(SingleStatementSemicolonSyntax node)
		{
		    var singleStatement = (SingleStatementSyntax)this.Visit(node.SingleStatement);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(singleStatement, tSemicolon);
		}
		
		public virtual SyntaxNode VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
		{
		    var variableDeclarationExpression = (VariableDeclarationExpressionSyntax)this.Visit(node.VariableDeclarationExpression);
			return node.Update(variableDeclarationExpression);
		}
		
		public virtual SyntaxNode VisitVariableDeclarationExpression(VariableDeclarationExpressionSyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var variableDeclarationItem = this.VisitList(node.VariableDeclarationItem);
			return node.Update(typeReference, variableDeclarationItem);
		}
		
		public virtual SyntaxNode VisitVariableDeclarationItem(VariableDeclarationItemSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tAssign = this.VisitToken(node.TAssign);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(identifier, tAssign, expression);
		}
		
		public virtual SyntaxNode VisitVoidStatement(VoidStatementSyntax node)
		{
		    var kVoid = this.VisitToken(node.KVoid);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(kVoid, expression);
		}
		
		public virtual SyntaxNode VisitReturnStatement(ReturnStatementSyntax node)
		{
		    var kReturn = this.VisitToken(node.KReturn);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(kReturn, expression);
		}
		
		public virtual SyntaxNode VisitExpressionStatement(ExpressionStatementSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(expression);
		}
		
		public virtual SyntaxNode VisitIfStatement(IfStatementSyntax node)
		{
		    var ifStatementBegin = (IfStatementBeginSyntax)this.Visit(node.IfStatementBegin);
		    var body = (BodySyntax)this.Visit(node.Body);
		    var elseIfStatementBody = this.VisitList(node.ElseIfStatementBody);
		    var ifStatementElseBody = (IfStatementElseBodySyntax)this.Visit(node.IfStatementElseBody);
		    var ifStatementEnd = (IfStatementEndSyntax)this.Visit(node.IfStatementEnd);
			return node.Update(ifStatementBegin, body, elseIfStatementBody, ifStatementElseBody, ifStatementEnd);
		}
		
		public virtual SyntaxNode VisitElseIfStatementBody(ElseIfStatementBodySyntax node)
		{
		    var elseIfStatement = (ElseIfStatementSyntax)this.Visit(node.ElseIfStatement);
		    var body = (BodySyntax)this.Visit(node.Body);
			return node.Update(elseIfStatement, body);
		}
		
		public virtual SyntaxNode VisitIfStatementElseBody(IfStatementElseBodySyntax node)
		{
		    var ifStatementElse = (IfStatementElseSyntax)this.Visit(node.IfStatementElse);
		    var body = (BodySyntax)this.Visit(node.Body);
			return node.Update(ifStatementElse, body);
		}
		
		public virtual SyntaxNode VisitIfStatementBegin(IfStatementBeginSyntax node)
		{
		    var kIf = this.VisitToken(node.KIf);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kIf, tOpenParenthesis, expression, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitElseIfStatement(ElseIfStatementSyntax node)
		{
		    var kElse = this.VisitToken(node.KElse);
		    var kIf = this.VisitToken(node.KIf);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kElse, kIf, tOpenParenthesis, expression, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitIfStatementElse(IfStatementElseSyntax node)
		{
		    var kElse = this.VisitToken(node.KElse);
			return node.Update(kElse);
		}
		
		public virtual SyntaxNode VisitIfStatementEnd(IfStatementEndSyntax node)
		{
		    var kEnd = this.VisitToken(node.KEnd);
		    var kIf = this.VisitToken(node.KIf);
			return node.Update(kEnd, kIf);
		}
		
		public virtual SyntaxNode VisitForStatement(ForStatementSyntax node)
		{
		    var forStatementBegin = (ForStatementBeginSyntax)this.Visit(node.ForStatementBegin);
		    var body = (BodySyntax)this.Visit(node.Body);
		    var forStatementEnd = (ForStatementEndSyntax)this.Visit(node.ForStatementEnd);
			return node.Update(forStatementBegin, body, forStatementEnd);
		}
		
		public virtual SyntaxNode VisitForStatementBegin(ForStatementBeginSyntax node)
		{
		    var kFor = this.VisitToken(node.KFor);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var forInitStatement = (ForInitStatementSyntax)this.Visit(node.ForInitStatement);
		    var semi1 = this.VisitToken(node.Semi1);
		    var endExpression = (ExpressionListSyntax)this.Visit(node.EndExpression);
		    var semi2 = this.VisitToken(node.Semi2);
		    var stepExpression = (ExpressionListSyntax)this.Visit(node.StepExpression);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kFor, tOpenParenthesis, forInitStatement, semi1, endExpression, semi2, stepExpression, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitForStatementEnd(ForStatementEndSyntax node)
		{
		    var kEnd = this.VisitToken(node.KEnd);
		    var kFor = this.VisitToken(node.KFor);
			return node.Update(kEnd, kFor);
		}
		
		public virtual SyntaxNode VisitForInitStatement(ForInitStatementSyntax node)
		{
			var oldVariableDeclarationExpression = node.VariableDeclarationExpression;
			if (oldVariableDeclarationExpression != null)
			{
			    var newVariableDeclarationExpression = (VariableDeclarationExpressionSyntax)this.Visit(oldVariableDeclarationExpression);
				return node.Update(newVariableDeclarationExpression);
			}
			var oldExpressionList = node.ExpressionList;
			if (oldExpressionList != null)
			{
			    var newExpressionList = (ExpressionListSyntax)this.Visit(oldExpressionList);
				return node.Update(newExpressionList);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitWhileStatement(WhileStatementSyntax node)
		{
		    var whileStatementBegin = (WhileStatementBeginSyntax)this.Visit(node.WhileStatementBegin);
		    var body = (BodySyntax)this.Visit(node.Body);
		    var whileStatementEnd = (WhileStatementEndSyntax)this.Visit(node.WhileStatementEnd);
			return node.Update(whileStatementBegin, body, whileStatementEnd);
		}
		
		public virtual SyntaxNode VisitWhileStatementBegin(WhileStatementBeginSyntax node)
		{
		    var kWhile = this.VisitToken(node.KWhile);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kWhile, tOpenParenthesis, expression, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitWhileStatementEnd(WhileStatementEndSyntax node)
		{
		    var kEnd = this.VisitToken(node.KEnd);
		    var kWhile = this.VisitToken(node.KWhile);
			return node.Update(kEnd, kWhile);
		}
		
		public virtual SyntaxNode VisitWhileRunExpression(WhileRunExpressionSyntax node)
		{
		    var separatorStatement = (SeparatorStatementSyntax)this.Visit(node.SeparatorStatement);
			return node.Update(separatorStatement);
		}
		
		public virtual SyntaxNode VisitRepeatStatement(RepeatStatementSyntax node)
		{
		    var repeatStatementBegin = (RepeatStatementBeginSyntax)this.Visit(node.RepeatStatementBegin);
		    var body = (BodySyntax)this.Visit(node.Body);
		    var repeatStatementEnd = (RepeatStatementEndSyntax)this.Visit(node.RepeatStatementEnd);
			return node.Update(repeatStatementBegin, body, repeatStatementEnd);
		}
		
		public virtual SyntaxNode VisitRepeatStatementBegin(RepeatStatementBeginSyntax node)
		{
		    var kRepeat = this.VisitToken(node.KRepeat);
			return node.Update(kRepeat);
		}
		
		public virtual SyntaxNode VisitRepeatStatementEnd(RepeatStatementEndSyntax node)
		{
		    var kUntil = this.VisitToken(node.KUntil);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kUntil, tOpenParenthesis, expression, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitRepeatRunExpression(RepeatRunExpressionSyntax node)
		{
		    var separatorStatement = (SeparatorStatementSyntax)this.Visit(node.SeparatorStatement);
			return node.Update(separatorStatement);
		}
		
		public virtual SyntaxNode VisitLoopStatement(LoopStatementSyntax node)
		{
		    var loopStatementBegin = (LoopStatementBeginSyntax)this.Visit(node.LoopStatementBegin);
		    var body = (BodySyntax)this.Visit(node.Body);
		    var loopStatementEnd = (LoopStatementEndSyntax)this.Visit(node.LoopStatementEnd);
			return node.Update(loopStatementBegin, body, loopStatementEnd);
		}
		
		public virtual SyntaxNode VisitLoopStatementBegin(LoopStatementBeginSyntax node)
		{
		    var kLoop = this.VisitToken(node.KLoop);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var loopChain = (LoopChainSyntax)this.Visit(node.LoopChain);
		    var loopWhereExpression = (LoopWhereExpressionSyntax)this.Visit(node.LoopWhereExpression);
		    var loopRunExpression = (LoopRunExpressionSyntax)this.Visit(node.LoopRunExpression);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kLoop, tOpenParenthesis, loopChain, loopWhereExpression, loopRunExpression, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitLoopStatementEnd(LoopStatementEndSyntax node)
		{
		    var kEnd = this.VisitToken(node.KEnd);
		    var kLoop = this.VisitToken(node.KLoop);
			return node.Update(kEnd, kLoop);
		}
		
		public virtual SyntaxNode VisitLoopChain(LoopChainSyntax node)
		{
		    var loopChainItem = this.VisitList(node.LoopChainItem);
			return node.Update(loopChainItem);
		}
		
		public virtual SyntaxNode VisitLoopChainItem(LoopChainItemSyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tColon = this.VisitToken(node.TColon);
		    var loopChainExpression = (LoopChainExpressionSyntax)this.Visit(node.LoopChainExpression);
			return node.Update(typeReference, identifier, tColon, loopChainExpression);
		}
		
		public virtual SyntaxNode VisitLoopChainTypeofExpression(LoopChainTypeofExpressionSyntax node)
		{
		    var kTypeof = this.VisitToken(node.KTypeof);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitLoopChainIdentifierExpression(LoopChainIdentifierExpressionSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var typeArgumentList = (TypeArgumentListSyntax)this.Visit(node.TypeArgumentList);
			return node.Update(identifier, typeArgumentList);
		}
		
		public virtual SyntaxNode VisitLoopChainMemberAccessExpression(LoopChainMemberAccessExpressionSyntax node)
		{
		    var loopChainExpression = (LoopChainExpressionSyntax)this.Visit(node.LoopChainExpression);
		    var tDot = this.VisitToken(node.TDot);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var typeArgumentList = (TypeArgumentListSyntax)this.Visit(node.TypeArgumentList);
			return node.Update(loopChainExpression, tDot, identifier, typeArgumentList);
		}
		
		public virtual SyntaxNode VisitLoopChainMethodCallExpression(LoopChainMethodCallExpressionSyntax node)
		{
		    var loopChainExpression = (LoopChainExpressionSyntax)this.Visit(node.LoopChainExpression);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var expressionList = (ExpressionListSyntax)this.Visit(node.ExpressionList);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(loopChainExpression, tOpenParenthesis, expressionList, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitLoopWhereExpression(LoopWhereExpressionSyntax node)
		{
		    var kWhere = this.VisitToken(node.KWhere);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(kWhere, expression);
		}
		
		public virtual SyntaxNode VisitLoopRunExpression(LoopRunExpressionSyntax node)
		{
		    var separatorStatement = (SeparatorStatementSyntax)this.Visit(node.SeparatorStatement);
			return node.Update(separatorStatement);
		}
		
		public virtual SyntaxNode VisitSeparatorStatement(SeparatorStatementSyntax node)
		{
		    var tSemicolon = this.VisitToken(node.TSemicolon);
		    var kSeparator = this.VisitToken(node.KSeparator);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tAssign = this.VisitToken(node.TAssign);
		    var stringLiteralx = (StringLiteralxSyntax)this.Visit(node.StringLiteralx);
			return node.Update(tSemicolon, kSeparator, identifier, tAssign, stringLiteralx);
		}
		
		public virtual SyntaxNode VisitSwitchStatement(SwitchStatementSyntax node)
		{
		    var switchStatementBegin = (SwitchStatementBeginSyntax)this.Visit(node.SwitchStatementBegin);
		    var switchBranchStatement = this.VisitList(node.SwitchBranchStatement);
		    var switchDefaultStatement = (SwitchDefaultStatementSyntax)this.Visit(node.SwitchDefaultStatement);
		    var switchStatementEnd = (SwitchStatementEndSyntax)this.Visit(node.SwitchStatementEnd);
			return node.Update(switchStatementBegin, switchBranchStatement, switchDefaultStatement, switchStatementEnd);
		}
		
		public virtual SyntaxNode VisitSwitchStatementBegin(SwitchStatementBeginSyntax node)
		{
		    var kSwitch = this.VisitToken(node.KSwitch);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kSwitch, tOpenParenthesis, expression, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitSwitchStatementEnd(SwitchStatementEndSyntax node)
		{
		    var kEnd = this.VisitToken(node.KEnd);
		    var kSwitch = this.VisitToken(node.KSwitch);
			return node.Update(kEnd, kSwitch);
		}
		
		public virtual SyntaxNode VisitSwitchBranchStatement(SwitchBranchStatementSyntax node)
		{
		    var switchBranchHeadStatement = (SwitchBranchHeadStatementSyntax)this.Visit(node.SwitchBranchHeadStatement);
		    var body = (BodySyntax)this.Visit(node.Body);
			return node.Update(switchBranchHeadStatement, body);
		}
		
		public virtual SyntaxNode VisitSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node)
		{
			var oldSwitchCaseOrTypeIsHeadStatements = node.SwitchCaseOrTypeIsHeadStatements;
			if (oldSwitchCaseOrTypeIsHeadStatements != null)
			{
			    var newSwitchCaseOrTypeIsHeadStatements = (SwitchCaseOrTypeIsHeadStatementsSyntax)this.Visit(oldSwitchCaseOrTypeIsHeadStatements);
				return node.Update(newSwitchCaseOrTypeIsHeadStatements);
			}
			var oldSwitchTypeAsHeadStatement = node.SwitchTypeAsHeadStatement;
			if (oldSwitchTypeAsHeadStatement != null)
			{
			    var newSwitchTypeAsHeadStatement = (SwitchTypeAsHeadStatementSyntax)this.Visit(oldSwitchTypeAsHeadStatement);
				return node.Update(newSwitchTypeAsHeadStatement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node)
		{
		    var switchCaseOrTypeIsHeadStatement = this.VisitList(node.SwitchCaseOrTypeIsHeadStatement);
			return node.Update(switchCaseOrTypeIsHeadStatement);
		}
		
		public virtual SyntaxNode VisitSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node)
		{
			var oldSwitchCaseHeadStatement = node.SwitchCaseHeadStatement;
			if (oldSwitchCaseHeadStatement != null)
			{
			    var newSwitchCaseHeadStatement = (SwitchCaseHeadStatementSyntax)this.Visit(oldSwitchCaseHeadStatement);
				return node.Update(newSwitchCaseHeadStatement);
			}
			var oldSwitchTypeIsHeadStatement = node.SwitchTypeIsHeadStatement;
			if (oldSwitchTypeIsHeadStatement != null)
			{
			    var newSwitchTypeIsHeadStatement = (SwitchTypeIsHeadStatementSyntax)this.Visit(oldSwitchTypeIsHeadStatement);
				return node.Update(newSwitchTypeIsHeadStatement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node)
		{
		    var kCase = this.VisitToken(node.KCase);
		    var expressionList = (ExpressionListSyntax)this.Visit(node.ExpressionList);
		    var tColon = this.VisitToken(node.TColon);
			return node.Update(kCase, expressionList, tColon);
		}
		
		public virtual SyntaxNode VisitSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node)
		{
		    var kType = this.VisitToken(node.KType);
		    var kIs = this.VisitToken(node.KIs);
		    var typeReferenceList = (TypeReferenceListSyntax)this.Visit(node.TypeReferenceList);
		    var tColon = this.VisitToken(node.TColon);
			return node.Update(kType, kIs, typeReferenceList, tColon);
		}
		
		public virtual SyntaxNode VisitSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node)
		{
		    var kType = this.VisitToken(node.KType);
		    var kAs = this.VisitToken(node.KAs);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tColon = this.VisitToken(node.TColon);
			return node.Update(kType, kAs, typeReference, tColon);
		}
		
		public virtual SyntaxNode VisitSwitchDefaultStatement(SwitchDefaultStatementSyntax node)
		{
		    var switchDefaultHeadStatement = (SwitchDefaultHeadStatementSyntax)this.Visit(node.SwitchDefaultHeadStatement);
		    var body = (BodySyntax)this.Visit(node.Body);
			return node.Update(switchDefaultHeadStatement, body);
		}
		
		public virtual SyntaxNode VisitSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node)
		{
		    var kDefault = this.VisitToken(node.KDefault);
		    var tColon = this.VisitToken(node.TColon);
			return node.Update(kDefault, tColon);
		}
		
		public virtual SyntaxNode VisitTemplateDeclaration(TemplateDeclarationSyntax node)
		{
		    var templateSignature = (TemplateSignatureSyntax)this.Visit(node.TemplateSignature);
		    var templateBody = (TemplateBodySyntax)this.Visit(node.TemplateBody);
		    var kEndTemplate = this.VisitToken(node.KEndTemplate);
			return node.Update(templateSignature, templateBody, kEndTemplate);
		}
		
		public virtual SyntaxNode VisitTemplateSignature(TemplateSignatureSyntax node)
		{
		    var kTemplate = this.VisitToken(node.KTemplate);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var paramList = (ParamListSyntax)this.Visit(node.ParamList);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kTemplate, identifier, tOpenParenthesis, paramList, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitTemplateBody(TemplateBodySyntax node)
		{
		    var templateContentLine = this.VisitList(node.TemplateContentLine);
			return node.Update(templateContentLine);
		}
		
		public virtual SyntaxNode VisitTemplateContentLine(TemplateContentLineSyntax node)
		{
		    var templateContent = this.VisitList(node.TemplateContent);
		    var templateLineEnd = (TemplateLineEndSyntax)this.Visit(node.TemplateLineEnd);
			return node.Update(templateContent, templateLineEnd);
		}
		
		public virtual SyntaxNode VisitTemplateContent(TemplateContentSyntax node)
		{
			var oldTemplateOutputx = node.TemplateOutputx;
			if (oldTemplateOutputx != null)
			{
			    var newTemplateOutputx = (TemplateOutputxSyntax)this.Visit(oldTemplateOutputx);
				return node.Update(newTemplateOutputx);
			}
			var oldTemplateStatementStartEnd = node.TemplateStatementStartEnd;
			if (oldTemplateStatementStartEnd != null)
			{
			    var newTemplateStatementStartEnd = (TemplateStatementStartEndSyntax)this.Visit(oldTemplateStatementStartEnd);
				return node.Update(newTemplateStatementStartEnd);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTemplateOutputx(TemplateOutputxSyntax node)
		{
		    var templateOutput = this.VisitToken(node.TemplateOutput);
			return node.Update(templateOutput);
		}
		
		public virtual SyntaxNode VisitTemplateLineEnd(TemplateLineEndSyntax node)
		{
		    var templateLineEnd = this.VisitToken(node.TemplateLineEnd);
			return node.Update(templateLineEnd);
		}
		
		public virtual SyntaxNode VisitTemplateStatementStartEnd(TemplateStatementStartEndSyntax node)
		{
		    var templateStatementStart = this.VisitToken(node.TemplateStatementStart);
		    var templateStatement = (TemplateStatementSyntax)this.Visit(node.TemplateStatement);
		    var templateStatementEnd = this.VisitToken(node.TemplateStatementEnd);
			return node.Update(templateStatementStart, templateStatement, templateStatementEnd);
		}
		
		public virtual SyntaxNode VisitTemplateStatement(TemplateStatementSyntax node)
		{
			var oldVoidStatement = node.VoidStatement;
			if (oldVoidStatement != null)
			{
			    var newVoidStatement = (VoidStatementSyntax)this.Visit(oldVoidStatement);
				return node.Update(newVoidStatement);
			}
			var oldVariableDeclarationStatement = node.VariableDeclarationStatement;
			if (oldVariableDeclarationStatement != null)
			{
			    var newVariableDeclarationStatement = (VariableDeclarationStatementSyntax)this.Visit(oldVariableDeclarationStatement);
				return node.Update(newVariableDeclarationStatement);
			}
			var oldExpressionStatement = node.ExpressionStatement;
			if (oldExpressionStatement != null)
			{
			    var newExpressionStatement = (ExpressionStatementSyntax)this.Visit(oldExpressionStatement);
				return node.Update(newExpressionStatement);
			}
			var oldIfStatementBegin = node.IfStatementBegin;
			if (oldIfStatementBegin != null)
			{
			    var newIfStatementBegin = (IfStatementBeginSyntax)this.Visit(oldIfStatementBegin);
				return node.Update(newIfStatementBegin);
			}
			var oldElseIfStatement = node.ElseIfStatement;
			if (oldElseIfStatement != null)
			{
			    var newElseIfStatement = (ElseIfStatementSyntax)this.Visit(oldElseIfStatement);
				return node.Update(newElseIfStatement);
			}
			var oldIfStatementElse = node.IfStatementElse;
			if (oldIfStatementElse != null)
			{
			    var newIfStatementElse = (IfStatementElseSyntax)this.Visit(oldIfStatementElse);
				return node.Update(newIfStatementElse);
			}
			var oldIfStatementEnd = node.IfStatementEnd;
			if (oldIfStatementEnd != null)
			{
			    var newIfStatementEnd = (IfStatementEndSyntax)this.Visit(oldIfStatementEnd);
				return node.Update(newIfStatementEnd);
			}
			var oldForStatementBegin = node.ForStatementBegin;
			if (oldForStatementBegin != null)
			{
			    var newForStatementBegin = (ForStatementBeginSyntax)this.Visit(oldForStatementBegin);
				return node.Update(newForStatementBegin);
			}
			var oldForStatementEnd = node.ForStatementEnd;
			if (oldForStatementEnd != null)
			{
			    var newForStatementEnd = (ForStatementEndSyntax)this.Visit(oldForStatementEnd);
				return node.Update(newForStatementEnd);
			}
			var oldWhileStatementBegin = node.WhileStatementBegin;
			if (oldWhileStatementBegin != null)
			{
			    var newWhileStatementBegin = (WhileStatementBeginSyntax)this.Visit(oldWhileStatementBegin);
				return node.Update(newWhileStatementBegin);
			}
			var oldWhileStatementEnd = node.WhileStatementEnd;
			if (oldWhileStatementEnd != null)
			{
			    var newWhileStatementEnd = (WhileStatementEndSyntax)this.Visit(oldWhileStatementEnd);
				return node.Update(newWhileStatementEnd);
			}
			var oldRepeatStatementBegin = node.RepeatStatementBegin;
			if (oldRepeatStatementBegin != null)
			{
			    var newRepeatStatementBegin = (RepeatStatementBeginSyntax)this.Visit(oldRepeatStatementBegin);
				return node.Update(newRepeatStatementBegin);
			}
			var oldRepeatStatementEnd = node.RepeatStatementEnd;
			if (oldRepeatStatementEnd != null)
			{
			    var newRepeatStatementEnd = (RepeatStatementEndSyntax)this.Visit(oldRepeatStatementEnd);
				return node.Update(newRepeatStatementEnd);
			}
			var oldLoopStatementBegin = node.LoopStatementBegin;
			if (oldLoopStatementBegin != null)
			{
			    var newLoopStatementBegin = (LoopStatementBeginSyntax)this.Visit(oldLoopStatementBegin);
				return node.Update(newLoopStatementBegin);
			}
			var oldLoopStatementEnd = node.LoopStatementEnd;
			if (oldLoopStatementEnd != null)
			{
			    var newLoopStatementEnd = (LoopStatementEndSyntax)this.Visit(oldLoopStatementEnd);
				return node.Update(newLoopStatementEnd);
			}
			var oldSwitchStatementBegin = node.SwitchStatementBegin;
			if (oldSwitchStatementBegin != null)
			{
			    var newSwitchStatementBegin = (SwitchStatementBeginSyntax)this.Visit(oldSwitchStatementBegin);
				return node.Update(newSwitchStatementBegin);
			}
			var oldSwitchStatementEnd = node.SwitchStatementEnd;
			if (oldSwitchStatementEnd != null)
			{
			    var newSwitchStatementEnd = (SwitchStatementEndSyntax)this.Visit(oldSwitchStatementEnd);
				return node.Update(newSwitchStatementEnd);
			}
			var oldSwitchBranchHeadStatement = node.SwitchBranchHeadStatement;
			if (oldSwitchBranchHeadStatement != null)
			{
			    var newSwitchBranchHeadStatement = (SwitchBranchHeadStatementSyntax)this.Visit(oldSwitchBranchHeadStatement);
				return node.Update(newSwitchBranchHeadStatement);
			}
			var oldSwitchDefaultHeadStatement = node.SwitchDefaultHeadStatement;
			if (oldSwitchDefaultHeadStatement != null)
			{
			    var newSwitchDefaultHeadStatement = (SwitchDefaultHeadStatementSyntax)this.Visit(oldSwitchDefaultHeadStatement);
				return node.Update(newSwitchDefaultHeadStatement);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTypeArgumentList(TypeArgumentListSyntax node)
		{
		    var tLessThan = this.VisitToken(node.TLessThan);
		    var typeReferenceList = (TypeReferenceListSyntax)this.Visit(node.TypeReferenceList);
		    var tGreaterThan = this.VisitToken(node.TGreaterThan);
			return node.Update(tLessThan, typeReferenceList, tGreaterThan);
		}
		
		public virtual SyntaxNode VisitPredefinedType(PredefinedTypeSyntax node)
		{
		    var predefinedType = this.VisitToken(node.PredefinedType);
			return node.Update(predefinedType);
		}
		
		public virtual SyntaxNode VisitTypeReferenceList(TypeReferenceListSyntax node)
		{
		    var typeReference = this.VisitList(node.TypeReference);
			return node.Update(typeReference);
		}
		
		public virtual SyntaxNode VisitTypeReference(TypeReferenceSyntax node)
		{
			var oldArrayType = node.ArrayType;
			if (oldArrayType != null)
			{
			    var newArrayType = (ArrayTypeSyntax)this.Visit(oldArrayType);
				return node.Update(newArrayType);
			}
			var oldNullableType = node.NullableType;
			if (oldNullableType != null)
			{
			    var newNullableType = (NullableTypeSyntax)this.Visit(oldNullableType);
				return node.Update(newNullableType);
			}
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
		
		public virtual SyntaxNode VisitArrayType(ArrayTypeSyntax node)
		{
		    var arrayItemType = (ArrayItemTypeSyntax)this.Visit(node.ArrayItemType);
		    var rankSpecifiers = (RankSpecifiersSyntax)this.Visit(node.RankSpecifiers);
			return node.Update(arrayItemType, rankSpecifiers);
		}
		
		public virtual SyntaxNode VisitArrayItemType(ArrayItemTypeSyntax node)
		{
			var oldNullableType = node.NullableType;
			if (oldNullableType != null)
			{
			    var newNullableType = (NullableTypeSyntax)this.Visit(oldNullableType);
				return node.Update(newNullableType);
			}
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
		
		public virtual SyntaxNode VisitNullableType(NullableTypeSyntax node)
		{
		    var nullableItemType = (NullableItemTypeSyntax)this.Visit(node.NullableItemType);
		    var tQuestion = this.VisitToken(node.TQuestion);
			return node.Update(nullableItemType, tQuestion);
		}
		
		public virtual SyntaxNode VisitNullableItemType(NullableItemTypeSyntax node)
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
		
		public virtual SyntaxNode VisitGenericType(GenericTypeSyntax node)
		{
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var typeArgumentList = (TypeArgumentListSyntax)this.Visit(node.TypeArgumentList);
			return node.Update(qualifiedName, typeArgumentList);
		}
		
		public virtual SyntaxNode VisitSimpleType(SimpleTypeSyntax node)
		{
			var oldQualifiedName = node.QualifiedName;
			if (oldQualifiedName != null)
			{
			    var newQualifiedName = (QualifiedNameSyntax)this.Visit(oldQualifiedName);
				return node.Update(newQualifiedName);
			}
			var oldPredefinedType = node.PredefinedType;
			if (oldPredefinedType != null)
			{
			    var newPredefinedType = (PredefinedTypeSyntax)this.Visit(oldPredefinedType);
				return node.Update(newPredefinedType);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVoidType(VoidTypeSyntax node)
		{
		    var kVoid = this.VisitToken(node.KVoid);
			return node.Update(kVoid);
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
		
		public virtual SyntaxNode VisitExpressionList(ExpressionListSyntax node)
		{
		    var expression = this.VisitList(node.Expression);
			return node.Update(expression);
		}
		
		public virtual SyntaxNode VisitVariableReference(VariableReferenceSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(expression);
		}
		
		public virtual SyntaxNode VisitRankSpecifiers(RankSpecifiersSyntax node)
		{
		    var rankSpecifier = this.VisitList(node.RankSpecifier);
			return node.Update(rankSpecifier);
		}
		
		public virtual SyntaxNode VisitRankSpecifier(RankSpecifierSyntax node)
		{
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var tComma = this.VisitList(node.TComma);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(tOpenBracket, tComma, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitUnboundTypeName(UnboundTypeNameSyntax node)
		{
		    var genericDimensionItem = this.VisitList(node.GenericDimensionItem);
			return node.Update(genericDimensionItem);
		}
		
		public virtual SyntaxNode VisitGenericDimensionItem(GenericDimensionItemSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var genericDimensionSpecifier = (GenericDimensionSpecifierSyntax)this.Visit(node.GenericDimensionSpecifier);
			return node.Update(identifier, genericDimensionSpecifier);
		}
		
		public virtual SyntaxNode VisitGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node)
		{
		    var tLessThan = this.VisitToken(node.TLessThan);
		    var tComma = this.VisitList(node.TComma);
		    var tGreaterThan = this.VisitToken(node.TGreaterThan);
			return node.Update(tLessThan, tComma, tGreaterThan);
		}
		
		public virtual SyntaxNode VisitExplicitAnonymousFunctionSignature(ExplicitAnonymousFunctionSignatureSyntax node)
		{
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var explicitParameter = this.VisitList(node.ExplicitParameter);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(tOpenParenthesis, explicitParameter, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitImplicitAnonymousFunctionSignature(ImplicitAnonymousFunctionSignatureSyntax node)
		{
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var implicitParameter = this.VisitList(node.ImplicitParameter);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(tOpenParenthesis, implicitParameter, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitSingleParamAnonymousFunctionSignature(SingleParamAnonymousFunctionSignatureSyntax node)
		{
		    var implicitParameter = (ImplicitParameterSyntax)this.Visit(node.ImplicitParameter);
			return node.Update(implicitParameter);
		}
		
		public virtual SyntaxNode VisitExplicitParameter(ExplicitParameterSyntax node)
		{
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(typeReference, identifier);
		}
		
		public virtual SyntaxNode VisitImplicitParameter(ImplicitParameterSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitThisExpression(ThisExpressionSyntax node)
		{
		    var kThis = this.VisitToken(node.KThis);
			return node.Update(kThis);
		}
		
		public virtual SyntaxNode VisitLiteralExpression(LiteralExpressionSyntax node)
		{
		    var literal = (LiteralSyntax)this.Visit(node.Literal);
			return node.Update(literal);
		}
		
		public virtual SyntaxNode VisitTypeofVoidExpression(TypeofVoidExpressionSyntax node)
		{
		    var kTypeof = this.VisitToken(node.KTypeof);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var kVoid = this.VisitToken(node.KVoid);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kTypeof, tOpenParenthesis, kVoid, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitTypeofUnboundTypeExpression(TypeofUnboundTypeExpressionSyntax node)
		{
		    var kTypeof = this.VisitToken(node.KTypeof);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var unboundTypeName = (UnboundTypeNameSyntax)this.Visit(node.UnboundTypeName);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kTypeof, tOpenParenthesis, unboundTypeName, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitTypeofTypeExpression(TypeofTypeExpressionSyntax node)
		{
		    var kTypeof = this.VisitToken(node.KTypeof);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitDefaultValueExpression(DefaultValueExpressionSyntax node)
		{
		    var kDefault = this.VisitToken(node.KDefault);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kDefault, tOpenParenthesis, typeReference, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitNewObjectOrCollectionWithConstructorExpression(NewObjectOrCollectionWithConstructorExpressionSyntax node)
		{
		    var kNew = this.VisitToken(node.KNew);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var expressionList = (ExpressionListSyntax)this.Visit(node.ExpressionList);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kNew, typeReference, tOpenParenthesis, expressionList, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitIdentifierExpression(IdentifierExpressionSyntax node)
		{
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var typeArgumentList = (TypeArgumentListSyntax)this.Visit(node.TypeArgumentList);
			return node.Update(identifier, typeArgumentList);
		}
		
		public virtual SyntaxNode VisitHasLoopExpression(HasLoopExpressionSyntax node)
		{
		    var kHasLoop = this.VisitToken(node.KHasLoop);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var loopChain = (LoopChainSyntax)this.Visit(node.LoopChain);
		    var loopWhereExpression = (LoopWhereExpressionSyntax)this.Visit(node.LoopWhereExpression);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(kHasLoop, tOpenParenthesis, loopChain, loopWhereExpression, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
		{
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(tOpenParenthesis, expression, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitElementAccessExpression(ElementAccessExpressionSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tOpenBracket = this.VisitToken(node.TOpenBracket);
		    var expressionList = (ExpressionListSyntax)this.Visit(node.ExpressionList);
		    var tCloseBracket = this.VisitToken(node.TCloseBracket);
			return node.Update(expression, tOpenBracket, expressionList, tCloseBracket);
		}
		
		public virtual SyntaxNode VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var expressionList = (ExpressionListSyntax)this.Visit(node.ExpressionList);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
			return node.Update(expression, tOpenParenthesis, expressionList, tCloseParenthesis);
		}
		
		public virtual SyntaxNode VisitPredefinedTypeMemberAccessExpression(PredefinedTypeMemberAccessExpressionSyntax node)
		{
		    var predefinedType = (PredefinedTypeSyntax)this.Visit(node.PredefinedType);
		    var tDot = this.VisitToken(node.TDot);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var typeArgumentList = (TypeArgumentListSyntax)this.Visit(node.TypeArgumentList);
			return node.Update(predefinedType, tDot, identifier, typeArgumentList);
		}
		
		public virtual SyntaxNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var tDot = this.VisitToken(node.TDot);
		    var identifier = (IdentifierSyntax)this.Visit(node.Identifier);
		    var typeArgumentList = (TypeArgumentListSyntax)this.Visit(node.TypeArgumentList);
			return node.Update(expression, tDot, identifier, typeArgumentList);
		}
		
		public virtual SyntaxNode VisitTypecastExpression(TypecastExpressionSyntax node)
		{
		    var tOpenParenthesis = this.VisitToken(node.TOpenParenthesis);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
		    var tCloseParenthesis = this.VisitToken(node.TCloseParenthesis);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(tOpenParenthesis, typeReference, tCloseParenthesis, expression);
		}
		
		public virtual SyntaxNode VisitUnaryExpression(UnaryExpressionSyntax node)
		{
		    var op = this.VisitToken(node.Op);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(op, expression);
		}
		
		public virtual SyntaxNode VisitPostExpression(PostExpressionSyntax node)
		{
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
		    var op = this.VisitToken(node.Op);
			return node.Update(expression, op);
		}
		
		public virtual SyntaxNode VisitMultiplicationExpression(MultiplicationExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var op = this.VisitToken(node.Op);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, op, right);
		}
		
		public virtual SyntaxNode VisitAdditionExpression(AdditionExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var op = this.VisitToken(node.Op);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, op, right);
		}
		
		public virtual SyntaxNode VisitRelationalExpression(RelationalExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var op = this.VisitToken(node.Op);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, op, right);
		}
		
		public virtual SyntaxNode VisitTypecheckExpression(TypecheckExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var op = this.VisitToken(node.Op);
		    var typeReference = (TypeReferenceSyntax)this.Visit(node.TypeReference);
			return node.Update(left, op, typeReference);
		}
		
		public virtual SyntaxNode VisitEqualityExpression(EqualityExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var op = this.VisitToken(node.Op);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, op, right);
		}
		
		public virtual SyntaxNode VisitBitwiseAndExpression(BitwiseAndExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tAmp = this.VisitToken(node.TAmp);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tAmp, right);
		}
		
		public virtual SyntaxNode VisitBitwiseXorExpression(BitwiseXorExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tHat = this.VisitToken(node.THat);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tHat, right);
		}
		
		public virtual SyntaxNode VisitBitwiseOrExpression(BitwiseOrExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tPipe = this.VisitToken(node.TPipe);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tPipe, right);
		}
		
		public virtual SyntaxNode VisitLogicalAndExpression(LogicalAndExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tAnd = this.VisitToken(node.TAnd);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tAnd, right);
		}
		
		public virtual SyntaxNode VisitLogicalXorExpression(LogicalXorExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tXor = this.VisitToken(node.TXor);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tXor, right);
		}
		
		public virtual SyntaxNode VisitLogicalOrExpression(LogicalOrExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var tOr = this.VisitToken(node.TOr);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, tOr, right);
		}
		
		public virtual SyntaxNode VisitConditionalExpression(ConditionalExpressionSyntax node)
		{
		    var condition = (ExpressionSyntax)this.Visit(node.Condition);
		    var tQuestion = this.VisitToken(node.TQuestion);
		    var thenBranch = (ExpressionSyntax)this.Visit(node.ThenBranch);
		    var tColon = this.VisitToken(node.TColon);
		    var elseBranch = (ExpressionSyntax)this.Visit(node.ElseBranch);
			return node.Update(condition, tQuestion, thenBranch, tColon, elseBranch);
		}
		
		public virtual SyntaxNode VisitAssignmentExpression(AssignmentExpressionSyntax node)
		{
		    var left = (ExpressionSyntax)this.Visit(node.Left);
		    var op = this.VisitToken(node.Op);
		    var right = (ExpressionSyntax)this.Visit(node.Right);
			return node.Update(left, op, right);
		}
		
		public virtual SyntaxNode VisitLambdaExpression(LambdaExpressionSyntax node)
		{
		    var anonymousFunctionSignature = (AnonymousFunctionSignatureSyntax)this.Visit(node.AnonymousFunctionSignature);
		    var tArrow = this.VisitToken(node.TArrow);
		    var expression = (ExpressionSyntax)this.Visit(node.Expression);
			return node.Update(anonymousFunctionSignature, tArrow, expression);
		}
		
		public virtual SyntaxNode VisitQualifiedName(QualifiedNameSyntax node)
		{
		    var identifier = this.VisitList(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitIdentifierList(IdentifierListSyntax node)
		{
		    var identifier = this.VisitList(node.Identifier);
			return node.Update(identifier);
		}
		
		public virtual SyntaxNode VisitIdentifier(IdentifierSyntax node)
		{
		    var identifierNormal = this.VisitToken(node.IdentifierNormal);
			return node.Update(identifierNormal);
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
			var oldNumberLiteral = node.NumberLiteral;
			if (oldNumberLiteral != null)
			{
			    var newNumberLiteral = (NumberLiteralSyntax)this.Visit(oldNumberLiteral);
				return node.Update(newNumberLiteral);
			}
			var oldDateOrTimeLiteral = node.DateOrTimeLiteral;
			if (oldDateOrTimeLiteral != null)
			{
			    var newDateOrTimeLiteral = (DateOrTimeLiteralSyntax)this.Visit(oldDateOrTimeLiteral);
				return node.Update(newDateOrTimeLiteral);
			}
			var oldCharLiteralx = node.CharLiteralx;
			if (oldCharLiteralx != null)
			{
			    var newCharLiteralx = (CharLiteralxSyntax)this.Visit(oldCharLiteralx);
				return node.Update(newCharLiteralx);
			}
			var oldStringLiteralx = node.StringLiteralx;
			if (oldStringLiteralx != null)
			{
			    var newStringLiteralx = (StringLiteralxSyntax)this.Visit(oldStringLiteralx);
				return node.Update(newStringLiteralx);
			}
			var oldGuidLiteralx = node.GuidLiteralx;
			if (oldGuidLiteralx != null)
			{
			    var newGuidLiteralx = (GuidLiteralxSyntax)this.Visit(oldGuidLiteralx);
				return node.Update(newGuidLiteralx);
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
		
		public virtual SyntaxNode VisitNumberLiteral(NumberLiteralSyntax node)
		{
			var oldIntegerLiteralx = node.IntegerLiteralx;
			if (oldIntegerLiteralx != null)
			{
			    var newIntegerLiteralx = (IntegerLiteralxSyntax)this.Visit(oldIntegerLiteralx);
				return node.Update(newIntegerLiteralx);
			}
			var oldDecimalLiteralx = node.DecimalLiteralx;
			if (oldDecimalLiteralx != null)
			{
			    var newDecimalLiteralx = (DecimalLiteralxSyntax)this.Visit(oldDecimalLiteralx);
				return node.Update(newDecimalLiteralx);
			}
			var oldScientificLiteralx = node.ScientificLiteralx;
			if (oldScientificLiteralx != null)
			{
			    var newScientificLiteralx = (ScientificLiteralxSyntax)this.Visit(oldScientificLiteralx);
				return node.Update(newScientificLiteralx);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitIntegerLiteralx(IntegerLiteralxSyntax node)
		{
		    var integerLiteral = this.VisitToken(node.IntegerLiteral);
			return node.Update(integerLiteral);
		}
		
		public virtual SyntaxNode VisitDecimalLiteralx(DecimalLiteralxSyntax node)
		{
		    var decimalLiteral = this.VisitToken(node.DecimalLiteral);
			return node.Update(decimalLiteral);
		}
		
		public virtual SyntaxNode VisitScientificLiteralx(ScientificLiteralxSyntax node)
		{
		    var scientificLiteral = this.VisitToken(node.ScientificLiteral);
			return node.Update(scientificLiteral);
		}
		
		public virtual SyntaxNode VisitDateOrTimeLiteral(DateOrTimeLiteralSyntax node)
		{
			var oldDateTimeLiteralx = node.DateTimeLiteralx;
			if (oldDateTimeLiteralx != null)
			{
			    var newDateTimeLiteralx = (DateTimeLiteralxSyntax)this.Visit(oldDateTimeLiteralx);
				return node.Update(newDateTimeLiteralx);
			}
			var oldDateTimeOffsetLiteralx = node.DateTimeOffsetLiteralx;
			if (oldDateTimeOffsetLiteralx != null)
			{
			    var newDateTimeOffsetLiteralx = (DateTimeOffsetLiteralxSyntax)this.Visit(oldDateTimeOffsetLiteralx);
				return node.Update(newDateTimeOffsetLiteralx);
			}
			var oldDateLiteralx = node.DateLiteralx;
			if (oldDateLiteralx != null)
			{
			    var newDateLiteralx = (DateLiteralxSyntax)this.Visit(oldDateLiteralx);
				return node.Update(newDateLiteralx);
			}
			var oldTimeLiteralx = node.TimeLiteralx;
			if (oldTimeLiteralx != null)
			{
			    var newTimeLiteralx = (TimeLiteralxSyntax)this.Visit(oldTimeLiteralx);
				return node.Update(newTimeLiteralx);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitDateTimeOffsetLiteralx(DateTimeOffsetLiteralxSyntax node)
		{
		    var dateTimeOffsetLiteral = this.VisitToken(node.DateTimeOffsetLiteral);
			return node.Update(dateTimeOffsetLiteral);
		}
		
		public virtual SyntaxNode VisitDateTimeLiteralx(DateTimeLiteralxSyntax node)
		{
		    var dateTimeLiteral = this.VisitToken(node.DateTimeLiteral);
			return node.Update(dateTimeLiteral);
		}
		
		public virtual SyntaxNode VisitDateLiteralx(DateLiteralxSyntax node)
		{
		    var dateLiteral = this.VisitToken(node.DateLiteral);
			return node.Update(dateLiteral);
		}
		
		public virtual SyntaxNode VisitTimeLiteralx(TimeLiteralxSyntax node)
		{
		    var timeLiteral = this.VisitToken(node.TimeLiteral);
			return node.Update(timeLiteral);
		}
		
		public virtual SyntaxNode VisitCharLiteralx(CharLiteralxSyntax node)
		{
		    var charLiteral = this.VisitToken(node.CharLiteral);
			return node.Update(charLiteral);
		}
		
		public virtual SyntaxNode VisitStringLiteralx(StringLiteralxSyntax node)
		{
		    var stringLiteralx = this.VisitToken(node.StringLiteralx);
			return node.Update(stringLiteralx);
		}
		
		public virtual SyntaxNode VisitGuidLiteralx(GuidLiteralxSyntax node)
		{
		    var guidLiteral = this.VisitToken(node.GuidLiteral);
			return node.Update(guidLiteral);
		}
	}

	public class TestLexerModeSyntaxFactory : SyntaxFactory
	{
		internal TestLexerModeSyntaxFactory(TestLexerModeInternalSyntaxFactory internalSyntaxFactory) 
			: base(internalSyntaxFactory)
		{
		}
		public new TestLexerModeLanguage Language => TestLexerModeLanguage.Instance;
		protected override Language LanguageCore => this.Language;
	    public override LanguageParseOptions DefaultParseOptions => TestLexerModeParseOptions.Default;
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public TestLexerModeSyntaxTree SyntaxTree(SyntaxNode root, TestLexerModeParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return TestLexerModeSyntaxTree.Create((TestLexerModeSyntaxNode)root, (TestLexerModeParseOptions)options, path, null, encoding);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public TestLexerModeSyntaxTree ParseSyntaxTree(
			string text,
			TestLexerModeParseOptions options = null,
			string path = "",
			Encoding encoding = null,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (TestLexerModeSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public TestLexerModeSyntaxTree ParseSyntaxTree(
			SourceText text,
			TestLexerModeParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (TestLexerModeSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
		protected override LanguageSyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return TestLexerModeSyntaxTree.ParseText(text, (TestLexerModeParseOptions)options, path, cancellationToken);
		}
	
		public override LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return TestLexerModeSyntaxTree.Create((TestLexerModeSyntaxNode)root, (TestLexerModeParseOptions)options, path, null, encoding);
		}
	
	    public override SyntaxNode CreateStructure(SyntaxTrivia trivia)
	    {
	        if (trivia != null && trivia.UnderlyingNode is GreenStructuredSyntaxTrivia structuredTrivia)
	        {
	            return structuredTrivia.Structure.CreateRed();
	        }
	        else
	        {
	            return null;
	        }
	    }
	
	
	    public SyntaxToken TOpenBracket(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TOpenBracket(text));
	    }
	
	    public SyntaxToken TOpenBracket(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TOpenBracket(text, value));
	    }
	
	    public SyntaxToken TAsterisk(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TAsterisk(text));
	    }
	
	    public SyntaxToken TAsterisk(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TAsterisk(text, value));
	    }
	
	    public SyntaxToken IdentifierNormal(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text));
	    }
	
	    public SyntaxToken IdentifierNormal(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text, value));
	    }
	
	    public SyntaxToken IntegerLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(text));
	    }
	
	    public SyntaxToken IntegerLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.IntegerLiteral(text, value));
	    }
	
	    public SyntaxToken DecimalLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(text));
	    }
	
	    public SyntaxToken DecimalLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.DecimalLiteral(text, value));
	    }
	
	    public SyntaxToken ScientificLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(text));
	    }
	
	    public SyntaxToken ScientificLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.ScientificLiteral(text, value));
	    }
	
	    public SyntaxToken DateTimeOffsetLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateTimeOffsetLiteral(text));
	    }
	
	    public SyntaxToken DateTimeOffsetLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateTimeOffsetLiteral(text, value));
	    }
	
	    public SyntaxToken DateTimeLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateTimeLiteral(text));
	    }
	
	    public SyntaxToken DateTimeLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateTimeLiteral(text, value));
	    }
	
	    public SyntaxToken DateLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateLiteral(text));
	    }
	
	    public SyntaxToken DateLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateLiteral(text, value));
	    }
	
	    public SyntaxToken TimeLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TimeLiteral(text));
	    }
	
	    public SyntaxToken TimeLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TimeLiteral(text, value));
	    }
	
	    public SyntaxToken CharLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.CharLiteral(text));
	    }
	
	    public SyntaxToken CharLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.CharLiteral(text, value));
	    }
	
	    public SyntaxToken RegularStringLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.RegularStringLiteral(text));
	    }
	
	    public SyntaxToken RegularStringLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.RegularStringLiteral(text, value));
	    }
	
	    public SyntaxToken GuidLiteral(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.GuidLiteral(text));
	    }
	
	    public SyntaxToken GuidLiteral(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.GuidLiteral(text, value));
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text));
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value));
	    }
	
	    public SyntaxToken LWhitespace(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LWhitespace(text));
	    }
	
	    public SyntaxToken LWhitespace(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LWhitespace(text, value));
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LCrLf(text));
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value));
	    }
	
	    public SyntaxToken LLineBreak(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LLineBreak(text));
	    }
	
	    public SyntaxToken LLineBreak(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LLineBreak(text, value));
	    }
	
	    public SyntaxToken LLineComment(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LLineComment(text));
	    }
	
	    public SyntaxToken LLineComment(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LLineComment(text, value));
	    }
	
	    public SyntaxToken LMultiLineComment(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LMultiLineComment(text));
	    }
	
	    public SyntaxToken LMultiLineComment(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.LMultiLineComment(text, value));
	    }
	
	    public SyntaxToken TH_TOpenParenthesis(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TH_TOpenParenthesis(text));
	    }
	
	    public SyntaxToken TH_TOpenParenthesis(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TH_TOpenParenthesis(text, value));
	    }
	
	    public SyntaxToken TH_TCloseParenthesis(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TH_TCloseParenthesis(text));
	    }
	
	    public SyntaxToken TH_TCloseParenthesis(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TH_TCloseParenthesis(text, value));
	    }
	
	    public SyntaxToken KEndTemplate(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.KEndTemplate(text));
	    }
	
	    public SyntaxToken KEndTemplate(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.KEndTemplate(text, value));
	    }
	
	    public SyntaxToken TemplateLineControl(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateLineControl(text));
	    }
	
	    public SyntaxToken TemplateLineControl(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateLineControl(text, value));
	    }
	
	    public SyntaxToken TemplateOutput(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateOutput(text));
	    }
	
	    public SyntaxToken TemplateOutput(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateOutput(text, value));
	    }
	
	    public SyntaxToken TemplateCrLf(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateCrLf(text));
	    }
	
	    public SyntaxToken TemplateCrLf(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateCrLf(text, value));
	    }
	
	    public SyntaxToken TemplateLineBreak(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateLineBreak(text));
	    }
	
	    public SyntaxToken TemplateLineBreak(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateLineBreak(text, value));
	    }
	
	    public SyntaxToken TemplateStatementStart(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatementStart(text));
	    }
	
	    public SyntaxToken TemplateStatementStart(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatementStart(text, value));
	    }
	
	    public SyntaxToken TemplateStatementEnd(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatementEnd(text));
	    }
	
	    public SyntaxToken TemplateStatementEnd(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatementEnd(text, value));
	    }
	
	    public SyntaxToken TS_TOpenBracket(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TS_TOpenBracket(text));
	    }
	
	    public SyntaxToken TS_TOpenBracket(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TS_TOpenBracket(text, value));
	    }
	
	    public SyntaxToken TS_TCloseBracket(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TS_TCloseBracket(text));
	    }
	
	    public SyntaxToken TS_TCloseBracket(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.TS_TCloseBracket(text, value));
	    }
	
	    public SyntaxToken COMMENT_START(string text)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.COMMENT_START(text));
	    }
	
	    public SyntaxToken COMMENT_START(string text, object value)
	    {
	        return new SyntaxToken(TestLexerModeLanguage.Instance.InternalSyntaxFactory.COMMENT_START(text, value));
	    }
		
		public MainSyntax Main(NamespaceDeclarationSyntax namespaceDeclaration, GeneratorDeclarationSyntax generatorDeclaration, SyntaxList<UsingDeclarationSyntax> usingDeclaration, ConfigDeclarationSyntax configDeclaration, SyntaxList<MethodDeclarationSyntax> methodDeclaration, SyntaxToken eOF)
		{
		    if (namespaceDeclaration == null) throw new ArgumentNullException(nameof(namespaceDeclaration));
		    if (generatorDeclaration == null) throw new ArgumentNullException(nameof(generatorDeclaration));
		    if (eOF == null) throw new ArgumentNullException(nameof(eOF));
		    if (eOF.GetKind() != TestLexerModeSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
		    return (MainSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Main((Syntax.InternalSyntax.NamespaceDeclarationGreen)namespaceDeclaration.Green, (Syntax.InternalSyntax.GeneratorDeclarationGreen)generatorDeclaration.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<UsingDeclarationGreen>(usingDeclaration.Node), configDeclaration == null ? null : (Syntax.InternalSyntax.ConfigDeclarationGreen)configDeclaration.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<MethodDeclarationGreen>(methodDeclaration.Node), (InternalSyntaxToken)eOF.Node).CreateRed();
		}
		
		public MainSyntax Main(NamespaceDeclarationSyntax namespaceDeclaration, GeneratorDeclarationSyntax generatorDeclaration, SyntaxToken eOF)
		{
			return this.Main(namespaceDeclaration, generatorDeclaration, default, default, default, eOF);
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, SyntaxToken tSemicolon)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLexerModeSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (NamespaceDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public NamespaceDeclarationSyntax NamespaceDeclaration(QualifiedNameSyntax qualifiedName)
		{
			return this.NamespaceDeclaration(this.Token(TestLexerModeSyntaxKind.KNamespace), qualifiedName, this.Token(TestLexerModeSyntaxKind.TSemicolon));
		}
		
		public GeneratorDeclarationSyntax GeneratorDeclaration(SyntaxToken kGenerator, IdentifierSyntax identifier, SyntaxToken tColon, QualifiedNameSyntax qualifiedName, SyntaxToken kFor, TypeReferenceSyntax typeReference, SyntaxToken tSemicolon)
		{
		    if (kGenerator == null) throw new ArgumentNullException(nameof(kGenerator));
		    if (kGenerator.GetKind() != TestLexerModeSyntaxKind.KGenerator) throw new ArgumentException(nameof(kGenerator));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tColon != null && tColon.GetKind() != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (kFor != null && kFor.GetKind() != TestLexerModeSyntaxKind.KFor) throw new ArgumentException(nameof(kFor));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (GeneratorDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.GeneratorDeclaration((InternalSyntaxToken)kGenerator.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tColon.Node, qualifiedName == null ? null : (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (InternalSyntaxToken)kFor.Node, typeReference == null ? null : (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public GeneratorDeclarationSyntax GeneratorDeclaration(IdentifierSyntax identifier)
		{
			return this.GeneratorDeclaration(this.Token(TestLexerModeSyntaxKind.KGenerator), identifier, default, default, default, default, this.Token(TestLexerModeSyntaxKind.TSemicolon));
		}
		
		public UsingNamespaceDeclarationSyntax UsingNamespaceDeclaration(SyntaxToken kUsing, QualifiedNameSyntax qualifiedName, SyntaxToken tSemicolon)
		{
		    if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
		    if (kUsing.GetKind() != TestLexerModeSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (UsingNamespaceDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.UsingNamespaceDeclaration((InternalSyntaxToken)kUsing.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public UsingNamespaceDeclarationSyntax UsingNamespaceDeclaration(QualifiedNameSyntax qualifiedName)
		{
			return this.UsingNamespaceDeclaration(this.Token(TestLexerModeSyntaxKind.KUsing), qualifiedName, this.Token(TestLexerModeSyntaxKind.TSemicolon));
		}
		
		public UsingGeneratorDeclarationSyntax UsingGeneratorDeclaration(SyntaxToken kUsing, SyntaxToken kGenerator, QualifiedNameSyntax qualifiedName, IdentifierSyntax identifier, SyntaxToken tSemicolon)
		{
		    if (kUsing == null) throw new ArgumentNullException(nameof(kUsing));
		    if (kUsing.GetKind() != TestLexerModeSyntaxKind.KUsing) throw new ArgumentException(nameof(kUsing));
		    if (kGenerator == null) throw new ArgumentNullException(nameof(kGenerator));
		    if (kGenerator.GetKind() != TestLexerModeSyntaxKind.KGenerator) throw new ArgumentException(nameof(kGenerator));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (UsingGeneratorDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.UsingGeneratorDeclaration((InternalSyntaxToken)kUsing.Node, (InternalSyntaxToken)kGenerator.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, identifier == null ? null : (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public UsingGeneratorDeclarationSyntax UsingGeneratorDeclaration(QualifiedNameSyntax qualifiedName)
		{
			return this.UsingGeneratorDeclaration(this.Token(TestLexerModeSyntaxKind.KUsing), this.Token(TestLexerModeSyntaxKind.KGenerator), qualifiedName, default, this.Token(TestLexerModeSyntaxKind.TSemicolon));
		}
		
		public ConfigDeclarationSyntax ConfigDeclaration(SyntaxToken startProperties, IdentifierSyntax identifier, SyntaxList<ConfigPropertySyntax> configProperty, SyntaxToken kEnd, SyntaxToken endProperties)
		{
		    if (startProperties == null) throw new ArgumentNullException(nameof(startProperties));
		    if (startProperties.GetKind() != TestLexerModeSyntaxKind.KProperties) throw new ArgumentException(nameof(startProperties));
		    if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
		    if (kEnd.GetKind() != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
		    if (endProperties == null) throw new ArgumentNullException(nameof(endProperties));
		    if (endProperties.GetKind() != TestLexerModeSyntaxKind.KProperties) throw new ArgumentException(nameof(endProperties));
		    return (ConfigDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ConfigDeclaration((InternalSyntaxToken)startProperties.Node, identifier == null ? null : (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ConfigPropertyGreen>(configProperty.Node), (InternalSyntaxToken)kEnd.Node, (InternalSyntaxToken)endProperties.Node).CreateRed();
		}
		
		public ConfigDeclarationSyntax ConfigDeclaration(SyntaxToken startProperties, SyntaxToken endProperties)
		{
			return this.ConfigDeclaration(startProperties, default, default, this.Token(TestLexerModeSyntaxKind.KEnd), endProperties);
		}
		
		public ConfigPropertyDeclarationSyntax ConfigPropertyDeclaration(TypeReferenceSyntax typeReference, IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression, SyntaxToken tSemicolon)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tAssign != null && tAssign.GetKind() != TestLexerModeSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (ConfigPropertyDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ConfigPropertyDeclaration((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tAssign.Node, expression == null ? null : (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public ConfigPropertyDeclarationSyntax ConfigPropertyDeclaration(TypeReferenceSyntax typeReference, IdentifierSyntax identifier)
		{
			return this.ConfigPropertyDeclaration(typeReference, identifier, default, default, this.Token(TestLexerModeSyntaxKind.TSemicolon));
		}
		
		public ConfigPropertyGroupDeclarationSyntax ConfigPropertyGroupDeclaration(SyntaxToken startProperties, IdentifierSyntax identifier, SyntaxList<ConfigPropertySyntax> configProperty, SyntaxToken kEnd, SyntaxToken endProperties)
		{
		    if (startProperties == null) throw new ArgumentNullException(nameof(startProperties));
		    if (startProperties.GetKind() != TestLexerModeSyntaxKind.KProperties) throw new ArgumentException(nameof(startProperties));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
		    if (kEnd.GetKind() != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
		    if (endProperties == null) throw new ArgumentNullException(nameof(endProperties));
		    if (endProperties.GetKind() != TestLexerModeSyntaxKind.KProperties) throw new ArgumentException(nameof(endProperties));
		    return (ConfigPropertyGroupDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ConfigPropertyGroupDeclaration((InternalSyntaxToken)startProperties.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ConfigPropertyGreen>(configProperty.Node), (InternalSyntaxToken)kEnd.Node, (InternalSyntaxToken)endProperties.Node).CreateRed();
		}
		
		public ConfigPropertyGroupDeclarationSyntax ConfigPropertyGroupDeclaration(SyntaxToken startProperties, IdentifierSyntax identifier, SyntaxToken endProperties)
		{
			return this.ConfigPropertyGroupDeclaration(startProperties, identifier, default, this.Token(TestLexerModeSyntaxKind.KEnd), endProperties);
		}
		
		public MethodDeclarationSyntax MethodDeclaration(FunctionDeclarationSyntax functionDeclaration)
		{
		    if (functionDeclaration == null) throw new ArgumentNullException(nameof(functionDeclaration));
		    return (MethodDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.MethodDeclaration((Syntax.InternalSyntax.FunctionDeclarationGreen)functionDeclaration.Green).CreateRed();
		}
		
		public MethodDeclarationSyntax MethodDeclaration(TemplateDeclarationSyntax templateDeclaration)
		{
		    if (templateDeclaration == null) throw new ArgumentNullException(nameof(templateDeclaration));
		    return (MethodDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.MethodDeclaration((Syntax.InternalSyntax.TemplateDeclarationGreen)templateDeclaration.Green).CreateRed();
		}
		
		public MethodDeclarationSyntax MethodDeclaration(ExternFunctionDeclarationSyntax externFunctionDeclaration)
		{
		    if (externFunctionDeclaration == null) throw new ArgumentNullException(nameof(externFunctionDeclaration));
		    return (MethodDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.MethodDeclaration((Syntax.InternalSyntax.ExternFunctionDeclarationGreen)externFunctionDeclaration.Green).CreateRed();
		}
		
		public ExternFunctionDeclarationSyntax ExternFunctionDeclaration(SyntaxToken kExtern, FunctionSignatureSyntax functionSignature)
		{
		    if (kExtern == null) throw new ArgumentNullException(nameof(kExtern));
		    if (kExtern.GetKind() != TestLexerModeSyntaxKind.KExtern) throw new ArgumentException(nameof(kExtern));
		    if (functionSignature == null) throw new ArgumentNullException(nameof(functionSignature));
		    return (ExternFunctionDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExternFunctionDeclaration((InternalSyntaxToken)kExtern.Node, (Syntax.InternalSyntax.FunctionSignatureGreen)functionSignature.Green).CreateRed();
		}
		
		public ExternFunctionDeclarationSyntax ExternFunctionDeclaration(FunctionSignatureSyntax functionSignature)
		{
			return this.ExternFunctionDeclaration(this.Token(TestLexerModeSyntaxKind.KExtern), functionSignature);
		}
		
		public FunctionDeclarationSyntax FunctionDeclaration(FunctionSignatureSyntax functionSignature, BodySyntax body, SyntaxToken kEnd, SyntaxToken kFunction)
		{
		    if (functionSignature == null) throw new ArgumentNullException(nameof(functionSignature));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
		    if (kEnd.GetKind() != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
		    if (kFunction == null) throw new ArgumentNullException(nameof(kFunction));
		    if (kFunction.GetKind() != TestLexerModeSyntaxKind.KFunction) throw new ArgumentException(nameof(kFunction));
		    return (FunctionDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.FunctionDeclaration((Syntax.InternalSyntax.FunctionSignatureGreen)functionSignature.Green, (Syntax.InternalSyntax.BodyGreen)body.Green, (InternalSyntaxToken)kEnd.Node, (InternalSyntaxToken)kFunction.Node).CreateRed();
		}
		
		public FunctionDeclarationSyntax FunctionDeclaration(FunctionSignatureSyntax functionSignature, BodySyntax body)
		{
			return this.FunctionDeclaration(functionSignature, body, this.Token(TestLexerModeSyntaxKind.KEnd), this.Token(TestLexerModeSyntaxKind.KFunction));
		}
		
		public FunctionSignatureSyntax FunctionSignature(SyntaxToken kFunction, ReturnTypeSyntax returnType, IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList, SyntaxToken tOpenParenthesis, ParamListSyntax paramList, SyntaxToken tCloseParenthesis)
		{
		    if (kFunction == null) throw new ArgumentNullException(nameof(kFunction));
		    if (kFunction.GetKind() != TestLexerModeSyntaxKind.KFunction) throw new ArgumentException(nameof(kFunction));
		    if (returnType == null) throw new ArgumentNullException(nameof(returnType));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (FunctionSignatureSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.FunctionSignature((InternalSyntaxToken)kFunction.Node, (Syntax.InternalSyntax.ReturnTypeGreen)returnType.Green, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, typeArgumentList == null ? null : (Syntax.InternalSyntax.TypeArgumentListGreen)typeArgumentList.Green, (InternalSyntaxToken)tOpenParenthesis.Node, paramList == null ? null : (Syntax.InternalSyntax.ParamListGreen)paramList.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public FunctionSignatureSyntax FunctionSignature(ReturnTypeSyntax returnType, IdentifierSyntax identifier)
		{
			return this.FunctionSignature(this.Token(TestLexerModeSyntaxKind.KFunction), returnType, identifier, default, this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public ParamListSyntax ParamList(SeparatedSyntaxList<ParameterSyntax> parameter)
		{
		    if (parameter == null) throw new ArgumentNullException(nameof(parameter));
		    return (ParamListSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ParamList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ParameterGreen>(parameter.Node)).CreateRed();
		}
		
		public ParameterSyntax Parameter(TypeReferenceSyntax typeReference, IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tAssign != null && tAssign.GetKind() != TestLexerModeSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    return (ParameterSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Parameter((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tAssign.Node, expression == null ? null : (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public ParameterSyntax Parameter(TypeReferenceSyntax typeReference, IdentifierSyntax identifier)
		{
			return this.Parameter(typeReference, identifier, default, default);
		}
		
		public BodySyntax Body(SyntaxList<StatementSyntax> statement)
		{
		    return (BodySyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Body(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<StatementGreen>(statement.Node)).CreateRed();
		}
		
		public BodySyntax Body()
		{
			return this.Body(default);
		}
		
		public StatementSyntax Statement(SingleStatementSemicolonSyntax singleStatementSemicolon)
		{
		    if (singleStatementSemicolon == null) throw new ArgumentNullException(nameof(singleStatementSemicolon));
		    return (StatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.SingleStatementSemicolonGreen)singleStatementSemicolon.Green).CreateRed();
		}
		
		public StatementSyntax Statement(IfStatementSyntax ifStatement)
		{
		    if (ifStatement == null) throw new ArgumentNullException(nameof(ifStatement));
		    return (StatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.IfStatementGreen)ifStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(ForStatementSyntax forStatement)
		{
		    if (forStatement == null) throw new ArgumentNullException(nameof(forStatement));
		    return (StatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.ForStatementGreen)forStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(WhileStatementSyntax whileStatement)
		{
		    if (whileStatement == null) throw new ArgumentNullException(nameof(whileStatement));
		    return (StatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.WhileStatementGreen)whileStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(RepeatStatementSyntax repeatStatement)
		{
		    if (repeatStatement == null) throw new ArgumentNullException(nameof(repeatStatement));
		    return (StatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.RepeatStatementGreen)repeatStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(LoopStatementSyntax loopStatement)
		{
		    if (loopStatement == null) throw new ArgumentNullException(nameof(loopStatement));
		    return (StatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.LoopStatementGreen)loopStatement.Green).CreateRed();
		}
		
		public StatementSyntax Statement(SwitchStatementSyntax switchStatement)
		{
		    if (switchStatement == null) throw new ArgumentNullException(nameof(switchStatement));
		    return (StatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Statement((Syntax.InternalSyntax.SwitchStatementGreen)switchStatement.Green).CreateRed();
		}
		
		public SingleStatementSyntax SingleStatement(VariableDeclarationStatementSyntax variableDeclarationStatement)
		{
		    if (variableDeclarationStatement == null) throw new ArgumentNullException(nameof(variableDeclarationStatement));
		    return (SingleStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleStatement((Syntax.InternalSyntax.VariableDeclarationStatementGreen)variableDeclarationStatement.Green).CreateRed();
		}
		
		public SingleStatementSyntax SingleStatement(ReturnStatementSyntax returnStatement)
		{
		    if (returnStatement == null) throw new ArgumentNullException(nameof(returnStatement));
		    return (SingleStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleStatement((Syntax.InternalSyntax.ReturnStatementGreen)returnStatement.Green).CreateRed();
		}
		
		public SingleStatementSyntax SingleStatement(ExpressionStatementSyntax expressionStatement)
		{
		    if (expressionStatement == null) throw new ArgumentNullException(nameof(expressionStatement));
		    return (SingleStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleStatement((Syntax.InternalSyntax.ExpressionStatementGreen)expressionStatement.Green).CreateRed();
		}
		
		public SingleStatementSemicolonSyntax SingleStatementSemicolon(SingleStatementSyntax singleStatement, SyntaxToken tSemicolon)
		{
		    if (singleStatement == null) throw new ArgumentNullException(nameof(singleStatement));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (SingleStatementSemicolonSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleStatementSemicolon((Syntax.InternalSyntax.SingleStatementGreen)singleStatement.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public SingleStatementSemicolonSyntax SingleStatementSemicolon(SingleStatementSyntax singleStatement)
		{
			return this.SingleStatementSemicolon(singleStatement, this.Token(TestLexerModeSyntaxKind.TSemicolon));
		}
		
		public VariableDeclarationStatementSyntax VariableDeclarationStatement(VariableDeclarationExpressionSyntax variableDeclarationExpression)
		{
		    if (variableDeclarationExpression == null) throw new ArgumentNullException(nameof(variableDeclarationExpression));
		    return (VariableDeclarationStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.VariableDeclarationStatement((Syntax.InternalSyntax.VariableDeclarationExpressionGreen)variableDeclarationExpression.Green).CreateRed();
		}
		
		public VariableDeclarationExpressionSyntax VariableDeclarationExpression(TypeReferenceSyntax typeReference, SeparatedSyntaxList<VariableDeclarationItemSyntax> variableDeclarationItem)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (variableDeclarationItem == null) throw new ArgumentNullException(nameof(variableDeclarationItem));
		    return (VariableDeclarationExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.VariableDeclarationExpression((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<VariableDeclarationItemGreen>(variableDeclarationItem.Node)).CreateRed();
		}
		
		public VariableDeclarationItemSyntax VariableDeclarationItem(IdentifierSyntax identifier, SyntaxToken tAssign, ExpressionSyntax expression)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tAssign != null && tAssign.GetKind() != TestLexerModeSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    return (VariableDeclarationItemSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.VariableDeclarationItem((Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tAssign.Node, expression == null ? null : (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public VariableDeclarationItemSyntax VariableDeclarationItem(IdentifierSyntax identifier)
		{
			return this.VariableDeclarationItem(identifier, default, default);
		}
		
		public VoidStatementSyntax VoidStatement(SyntaxToken kVoid, ExpressionSyntax expression)
		{
		    if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
		    if (kVoid.GetKind() != TestLexerModeSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (VoidStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.VoidStatement((InternalSyntaxToken)kVoid.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public VoidStatementSyntax VoidStatement(ExpressionSyntax expression)
		{
			return this.VoidStatement(this.Token(TestLexerModeSyntaxKind.KVoid), expression);
		}
		
		public ReturnStatementSyntax ReturnStatement(SyntaxToken kReturn, ExpressionSyntax expression)
		{
		    if (kReturn == null) throw new ArgumentNullException(nameof(kReturn));
		    if (kReturn.GetKind() != TestLexerModeSyntaxKind.KReturn) throw new ArgumentException(nameof(kReturn));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (ReturnStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ReturnStatement((InternalSyntaxToken)kReturn.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public ReturnStatementSyntax ReturnStatement(ExpressionSyntax expression)
		{
			return this.ReturnStatement(this.Token(TestLexerModeSyntaxKind.KReturn), expression);
		}
		
		public ExpressionStatementSyntax ExpressionStatement(ExpressionSyntax expression)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (ExpressionStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExpressionStatement((Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public IfStatementSyntax IfStatement(IfStatementBeginSyntax ifStatementBegin, BodySyntax body, SyntaxList<ElseIfStatementBodySyntax> elseIfStatementBody, IfStatementElseBodySyntax ifStatementElseBody, IfStatementEndSyntax ifStatementEnd)
		{
		    if (ifStatementBegin == null) throw new ArgumentNullException(nameof(ifStatementBegin));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    if (ifStatementEnd == null) throw new ArgumentNullException(nameof(ifStatementEnd));
		    return (IfStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatement((Syntax.InternalSyntax.IfStatementBeginGreen)ifStatementBegin.Green, (Syntax.InternalSyntax.BodyGreen)body.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<ElseIfStatementBodyGreen>(elseIfStatementBody.Node), ifStatementElseBody == null ? null : (Syntax.InternalSyntax.IfStatementElseBodyGreen)ifStatementElseBody.Green, (Syntax.InternalSyntax.IfStatementEndGreen)ifStatementEnd.Green).CreateRed();
		}
		
		public IfStatementSyntax IfStatement(IfStatementBeginSyntax ifStatementBegin, BodySyntax body, IfStatementEndSyntax ifStatementEnd)
		{
			return this.IfStatement(ifStatementBegin, body, default, default, ifStatementEnd);
		}
		
		public ElseIfStatementBodySyntax ElseIfStatementBody(ElseIfStatementSyntax elseIfStatement, BodySyntax body)
		{
		    if (elseIfStatement == null) throw new ArgumentNullException(nameof(elseIfStatement));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    return (ElseIfStatementBodySyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ElseIfStatementBody((Syntax.InternalSyntax.ElseIfStatementGreen)elseIfStatement.Green, (Syntax.InternalSyntax.BodyGreen)body.Green).CreateRed();
		}
		
		public IfStatementElseBodySyntax IfStatementElseBody(IfStatementElseSyntax ifStatementElse, BodySyntax body)
		{
		    if (ifStatementElse == null) throw new ArgumentNullException(nameof(ifStatementElse));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    return (IfStatementElseBodySyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatementElseBody((Syntax.InternalSyntax.IfStatementElseGreen)ifStatementElse.Green, (Syntax.InternalSyntax.BodyGreen)body.Green).CreateRed();
		}
		
		public IfStatementBeginSyntax IfStatementBegin(SyntaxToken kIf, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
		{
		    if (kIf == null) throw new ArgumentNullException(nameof(kIf));
		    if (kIf.GetKind() != TestLexerModeSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (IfStatementBeginSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatementBegin((InternalSyntaxToken)kIf.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public IfStatementBeginSyntax IfStatementBegin(ExpressionSyntax expression)
		{
			return this.IfStatementBegin(this.Token(TestLexerModeSyntaxKind.KIf), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), expression, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public ElseIfStatementSyntax ElseIfStatement(SyntaxToken kElse, SyntaxToken kIf, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
		{
		    if (kElse == null) throw new ArgumentNullException(nameof(kElse));
		    if (kElse.GetKind() != TestLexerModeSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
		    if (kIf == null) throw new ArgumentNullException(nameof(kIf));
		    if (kIf.GetKind() != TestLexerModeSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (ElseIfStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ElseIfStatement((InternalSyntaxToken)kElse.Node, (InternalSyntaxToken)kIf.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public ElseIfStatementSyntax ElseIfStatement(ExpressionSyntax expression)
		{
			return this.ElseIfStatement(this.Token(TestLexerModeSyntaxKind.KElse), this.Token(TestLexerModeSyntaxKind.KIf), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), expression, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public IfStatementElseSyntax IfStatementElse(SyntaxToken kElse)
		{
		    if (kElse == null) throw new ArgumentNullException(nameof(kElse));
		    if (kElse.GetKind() != TestLexerModeSyntaxKind.KElse) throw new ArgumentException(nameof(kElse));
		    return (IfStatementElseSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatementElse((InternalSyntaxToken)kElse.Node).CreateRed();
		}
		
		public IfStatementElseSyntax IfStatementElse()
		{
			return this.IfStatementElse(this.Token(TestLexerModeSyntaxKind.KElse));
		}
		
		public IfStatementEndSyntax IfStatementEnd(SyntaxToken kEnd, SyntaxToken kIf)
		{
		    if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
		    if (kEnd.GetKind() != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
		    if (kIf == null) throw new ArgumentNullException(nameof(kIf));
		    if (kIf.GetKind() != TestLexerModeSyntaxKind.KIf) throw new ArgumentException(nameof(kIf));
		    return (IfStatementEndSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.IfStatementEnd((InternalSyntaxToken)kEnd.Node, (InternalSyntaxToken)kIf.Node).CreateRed();
		}
		
		public IfStatementEndSyntax IfStatementEnd()
		{
			return this.IfStatementEnd(this.Token(TestLexerModeSyntaxKind.KEnd), this.Token(TestLexerModeSyntaxKind.KIf));
		}
		
		public ForStatementSyntax ForStatement(ForStatementBeginSyntax forStatementBegin, BodySyntax body, ForStatementEndSyntax forStatementEnd)
		{
		    if (forStatementBegin == null) throw new ArgumentNullException(nameof(forStatementBegin));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    if (forStatementEnd == null) throw new ArgumentNullException(nameof(forStatementEnd));
		    return (ForStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForStatement((Syntax.InternalSyntax.ForStatementBeginGreen)forStatementBegin.Green, (Syntax.InternalSyntax.BodyGreen)body.Green, (Syntax.InternalSyntax.ForStatementEndGreen)forStatementEnd.Green).CreateRed();
		}
		
		public ForStatementBeginSyntax ForStatementBegin(SyntaxToken kFor, SyntaxToken tOpenParenthesis, ForInitStatementSyntax forInitStatement, SyntaxToken semi1, ExpressionListSyntax endExpression, SyntaxToken semi2, ExpressionListSyntax stepExpression, SyntaxToken tCloseParenthesis)
		{
		    if (kFor == null) throw new ArgumentNullException(nameof(kFor));
		    if (kFor.GetKind() != TestLexerModeSyntaxKind.KFor) throw new ArgumentException(nameof(kFor));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (semi1 == null) throw new ArgumentNullException(nameof(semi1));
		    if (semi1.GetKind() != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(semi1));
		    if (semi2 == null) throw new ArgumentNullException(nameof(semi2));
		    if (semi2.GetKind() != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(semi2));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (ForStatementBeginSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForStatementBegin((InternalSyntaxToken)kFor.Node, (InternalSyntaxToken)tOpenParenthesis.Node, forInitStatement == null ? null : (Syntax.InternalSyntax.ForInitStatementGreen)forInitStatement.Green, (InternalSyntaxToken)semi1.Node, endExpression == null ? null : (Syntax.InternalSyntax.ExpressionListGreen)endExpression.Green, (InternalSyntaxToken)semi2.Node, stepExpression == null ? null : (Syntax.InternalSyntax.ExpressionListGreen)stepExpression.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public ForStatementBeginSyntax ForStatementBegin(SyntaxToken semi1, SyntaxToken semi2)
		{
			return this.ForStatementBegin(this.Token(TestLexerModeSyntaxKind.KFor), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), default, semi1, default, semi2, default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public ForStatementEndSyntax ForStatementEnd(SyntaxToken kEnd, SyntaxToken kFor)
		{
		    if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
		    if (kEnd.GetKind() != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
		    if (kFor == null) throw new ArgumentNullException(nameof(kFor));
		    if (kFor.GetKind() != TestLexerModeSyntaxKind.KFor) throw new ArgumentException(nameof(kFor));
		    return (ForStatementEndSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForStatementEnd((InternalSyntaxToken)kEnd.Node, (InternalSyntaxToken)kFor.Node).CreateRed();
		}
		
		public ForStatementEndSyntax ForStatementEnd()
		{
			return this.ForStatementEnd(this.Token(TestLexerModeSyntaxKind.KEnd), this.Token(TestLexerModeSyntaxKind.KFor));
		}
		
		public ForInitStatementSyntax ForInitStatement(VariableDeclarationExpressionSyntax variableDeclarationExpression)
		{
		    if (variableDeclarationExpression == null) throw new ArgumentNullException(nameof(variableDeclarationExpression));
		    return (ForInitStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForInitStatement((Syntax.InternalSyntax.VariableDeclarationExpressionGreen)variableDeclarationExpression.Green).CreateRed();
		}
		
		public ForInitStatementSyntax ForInitStatement(ExpressionListSyntax expressionList)
		{
		    if (expressionList == null) throw new ArgumentNullException(nameof(expressionList));
		    return (ForInitStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ForInitStatement((Syntax.InternalSyntax.ExpressionListGreen)expressionList.Green).CreateRed();
		}
		
		public WhileStatementSyntax WhileStatement(WhileStatementBeginSyntax whileStatementBegin, BodySyntax body, WhileStatementEndSyntax whileStatementEnd)
		{
		    if (whileStatementBegin == null) throw new ArgumentNullException(nameof(whileStatementBegin));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    if (whileStatementEnd == null) throw new ArgumentNullException(nameof(whileStatementEnd));
		    return (WhileStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.WhileStatement((Syntax.InternalSyntax.WhileStatementBeginGreen)whileStatementBegin.Green, (Syntax.InternalSyntax.BodyGreen)body.Green, (Syntax.InternalSyntax.WhileStatementEndGreen)whileStatementEnd.Green).CreateRed();
		}
		
		public WhileStatementBeginSyntax WhileStatementBegin(SyntaxToken kWhile, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
		{
		    if (kWhile == null) throw new ArgumentNullException(nameof(kWhile));
		    if (kWhile.GetKind() != TestLexerModeSyntaxKind.KWhile) throw new ArgumentException(nameof(kWhile));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (WhileStatementBeginSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.WhileStatementBegin((InternalSyntaxToken)kWhile.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public WhileStatementBeginSyntax WhileStatementBegin(ExpressionSyntax expression)
		{
			return this.WhileStatementBegin(this.Token(TestLexerModeSyntaxKind.KWhile), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), expression, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public WhileStatementEndSyntax WhileStatementEnd(SyntaxToken kEnd, SyntaxToken kWhile)
		{
		    if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
		    if (kEnd.GetKind() != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
		    if (kWhile == null) throw new ArgumentNullException(nameof(kWhile));
		    if (kWhile.GetKind() != TestLexerModeSyntaxKind.KWhile) throw new ArgumentException(nameof(kWhile));
		    return (WhileStatementEndSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.WhileStatementEnd((InternalSyntaxToken)kEnd.Node, (InternalSyntaxToken)kWhile.Node).CreateRed();
		}
		
		public WhileStatementEndSyntax WhileStatementEnd()
		{
			return this.WhileStatementEnd(this.Token(TestLexerModeSyntaxKind.KEnd), this.Token(TestLexerModeSyntaxKind.KWhile));
		}
		
		public WhileRunExpressionSyntax WhileRunExpression(SeparatorStatementSyntax separatorStatement)
		{
		    if (separatorStatement == null) throw new ArgumentNullException(nameof(separatorStatement));
		    return (WhileRunExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.WhileRunExpression((Syntax.InternalSyntax.SeparatorStatementGreen)separatorStatement.Green).CreateRed();
		}
		
		public RepeatStatementSyntax RepeatStatement(RepeatStatementBeginSyntax repeatStatementBegin, BodySyntax body, RepeatStatementEndSyntax repeatStatementEnd)
		{
		    if (repeatStatementBegin == null) throw new ArgumentNullException(nameof(repeatStatementBegin));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    if (repeatStatementEnd == null) throw new ArgumentNullException(nameof(repeatStatementEnd));
		    return (RepeatStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.RepeatStatement((Syntax.InternalSyntax.RepeatStatementBeginGreen)repeatStatementBegin.Green, (Syntax.InternalSyntax.BodyGreen)body.Green, (Syntax.InternalSyntax.RepeatStatementEndGreen)repeatStatementEnd.Green).CreateRed();
		}
		
		public RepeatStatementBeginSyntax RepeatStatementBegin(SyntaxToken kRepeat)
		{
		    if (kRepeat == null) throw new ArgumentNullException(nameof(kRepeat));
		    if (kRepeat.GetKind() != TestLexerModeSyntaxKind.KRepeat) throw new ArgumentException(nameof(kRepeat));
		    return (RepeatStatementBeginSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.RepeatStatementBegin((InternalSyntaxToken)kRepeat.Node).CreateRed();
		}
		
		public RepeatStatementBeginSyntax RepeatStatementBegin()
		{
			return this.RepeatStatementBegin(this.Token(TestLexerModeSyntaxKind.KRepeat));
		}
		
		public RepeatStatementEndSyntax RepeatStatementEnd(SyntaxToken kUntil, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
		{
		    if (kUntil == null) throw new ArgumentNullException(nameof(kUntil));
		    if (kUntil.GetKind() != TestLexerModeSyntaxKind.KUntil) throw new ArgumentException(nameof(kUntil));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (RepeatStatementEndSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.RepeatStatementEnd((InternalSyntaxToken)kUntil.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public RepeatStatementEndSyntax RepeatStatementEnd(ExpressionSyntax expression)
		{
			return this.RepeatStatementEnd(this.Token(TestLexerModeSyntaxKind.KUntil), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), expression, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public RepeatRunExpressionSyntax RepeatRunExpression(SeparatorStatementSyntax separatorStatement)
		{
		    if (separatorStatement == null) throw new ArgumentNullException(nameof(separatorStatement));
		    return (RepeatRunExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.RepeatRunExpression((Syntax.InternalSyntax.SeparatorStatementGreen)separatorStatement.Green).CreateRed();
		}
		
		public LoopStatementSyntax LoopStatement(LoopStatementBeginSyntax loopStatementBegin, BodySyntax body, LoopStatementEndSyntax loopStatementEnd)
		{
		    if (loopStatementBegin == null) throw new ArgumentNullException(nameof(loopStatementBegin));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    if (loopStatementEnd == null) throw new ArgumentNullException(nameof(loopStatementEnd));
		    return (LoopStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopStatement((Syntax.InternalSyntax.LoopStatementBeginGreen)loopStatementBegin.Green, (Syntax.InternalSyntax.BodyGreen)body.Green, (Syntax.InternalSyntax.LoopStatementEndGreen)loopStatementEnd.Green).CreateRed();
		}
		
		public LoopStatementBeginSyntax LoopStatementBegin(SyntaxToken kLoop, SyntaxToken tOpenParenthesis, LoopChainSyntax loopChain, LoopWhereExpressionSyntax loopWhereExpression, LoopRunExpressionSyntax loopRunExpression, SyntaxToken tCloseParenthesis)
		{
		    if (kLoop == null) throw new ArgumentNullException(nameof(kLoop));
		    if (kLoop.GetKind() != TestLexerModeSyntaxKind.KLoop) throw new ArgumentException(nameof(kLoop));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (loopChain == null) throw new ArgumentNullException(nameof(loopChain));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (LoopStatementBeginSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopStatementBegin((InternalSyntaxToken)kLoop.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.LoopChainGreen)loopChain.Green, loopWhereExpression == null ? null : (Syntax.InternalSyntax.LoopWhereExpressionGreen)loopWhereExpression.Green, loopRunExpression == null ? null : (Syntax.InternalSyntax.LoopRunExpressionGreen)loopRunExpression.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public LoopStatementBeginSyntax LoopStatementBegin(LoopChainSyntax loopChain)
		{
			return this.LoopStatementBegin(this.Token(TestLexerModeSyntaxKind.KLoop), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), loopChain, default, default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public LoopStatementEndSyntax LoopStatementEnd(SyntaxToken kEnd, SyntaxToken kLoop)
		{
		    if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
		    if (kEnd.GetKind() != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
		    if (kLoop == null) throw new ArgumentNullException(nameof(kLoop));
		    if (kLoop.GetKind() != TestLexerModeSyntaxKind.KLoop) throw new ArgumentException(nameof(kLoop));
		    return (LoopStatementEndSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopStatementEnd((InternalSyntaxToken)kEnd.Node, (InternalSyntaxToken)kLoop.Node).CreateRed();
		}
		
		public LoopStatementEndSyntax LoopStatementEnd()
		{
			return this.LoopStatementEnd(this.Token(TestLexerModeSyntaxKind.KEnd), this.Token(TestLexerModeSyntaxKind.KLoop));
		}
		
		public LoopChainSyntax LoopChain(SeparatedSyntaxList<LoopChainItemSyntax> loopChainItem)
		{
		    if (loopChainItem == null) throw new ArgumentNullException(nameof(loopChainItem));
		    return (LoopChainSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChain(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<LoopChainItemGreen>(loopChainItem.Node)).CreateRed();
		}
		
		public LoopChainItemSyntax LoopChainItem(TypeReferenceSyntax typeReference, IdentifierSyntax identifier, SyntaxToken tColon, LoopChainExpressionSyntax loopChainExpression)
		{
		    if (tColon != null && tColon.GetKind() != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (loopChainExpression == null) throw new ArgumentNullException(nameof(loopChainExpression));
		    return (LoopChainItemSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainItem(typeReference == null ? null : (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, identifier == null ? null : (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.LoopChainExpressionGreen)loopChainExpression.Green).CreateRed();
		}
		
		public LoopChainItemSyntax LoopChainItem(LoopChainExpressionSyntax loopChainExpression)
		{
			return this.LoopChainItem(default, default, default, loopChainExpression);
		}
		
		public LoopChainTypeofExpressionSyntax LoopChainTypeofExpression(SyntaxToken kTypeof, SyntaxToken tOpenParenthesis, TypeReferenceSyntax typeReference, SyntaxToken tCloseParenthesis)
		{
		    if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
		    if (kTypeof.GetKind() != TestLexerModeSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (LoopChainTypeofExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainTypeofExpression((InternalSyntaxToken)kTypeof.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public LoopChainTypeofExpressionSyntax LoopChainTypeofExpression(TypeReferenceSyntax typeReference)
		{
			return this.LoopChainTypeofExpression(this.Token(TestLexerModeSyntaxKind.KTypeof), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), typeReference, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public LoopChainIdentifierExpressionSyntax LoopChainIdentifierExpression(IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (LoopChainIdentifierExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainIdentifierExpression((Syntax.InternalSyntax.IdentifierGreen)identifier.Green, typeArgumentList == null ? null : (Syntax.InternalSyntax.TypeArgumentListGreen)typeArgumentList.Green).CreateRed();
		}
		
		public LoopChainIdentifierExpressionSyntax LoopChainIdentifierExpression(IdentifierSyntax identifier)
		{
			return this.LoopChainIdentifierExpression(identifier, default);
		}
		
		public LoopChainMemberAccessExpressionSyntax LoopChainMemberAccessExpression(LoopChainExpressionSyntax loopChainExpression, SyntaxToken tDot, IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
		{
		    if (loopChainExpression == null) throw new ArgumentNullException(nameof(loopChainExpression));
		    if (tDot == null) throw new ArgumentNullException(nameof(tDot));
		    if (tDot.GetKind() != TestLexerModeSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (LoopChainMemberAccessExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainMemberAccessExpression((Syntax.InternalSyntax.LoopChainExpressionGreen)loopChainExpression.Green, (InternalSyntaxToken)tDot.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, typeArgumentList == null ? null : (Syntax.InternalSyntax.TypeArgumentListGreen)typeArgumentList.Green).CreateRed();
		}
		
		public LoopChainMemberAccessExpressionSyntax LoopChainMemberAccessExpression(LoopChainExpressionSyntax loopChainExpression, IdentifierSyntax identifier)
		{
			return this.LoopChainMemberAccessExpression(loopChainExpression, this.Token(TestLexerModeSyntaxKind.TDot), identifier, default);
		}
		
		public LoopChainMethodCallExpressionSyntax LoopChainMethodCallExpression(LoopChainExpressionSyntax loopChainExpression, SyntaxToken tOpenParenthesis, ExpressionListSyntax expressionList, SyntaxToken tCloseParenthesis)
		{
		    if (loopChainExpression == null) throw new ArgumentNullException(nameof(loopChainExpression));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (LoopChainMethodCallExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopChainMethodCallExpression((Syntax.InternalSyntax.LoopChainExpressionGreen)loopChainExpression.Green, (InternalSyntaxToken)tOpenParenthesis.Node, expressionList == null ? null : (Syntax.InternalSyntax.ExpressionListGreen)expressionList.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public LoopChainMethodCallExpressionSyntax LoopChainMethodCallExpression(LoopChainExpressionSyntax loopChainExpression)
		{
			return this.LoopChainMethodCallExpression(loopChainExpression, this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public LoopWhereExpressionSyntax LoopWhereExpression(SyntaxToken kWhere, ExpressionSyntax expression)
		{
		    if (kWhere == null) throw new ArgumentNullException(nameof(kWhere));
		    if (kWhere.GetKind() != TestLexerModeSyntaxKind.KWhere) throw new ArgumentException(nameof(kWhere));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (LoopWhereExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopWhereExpression((InternalSyntaxToken)kWhere.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public LoopWhereExpressionSyntax LoopWhereExpression(ExpressionSyntax expression)
		{
			return this.LoopWhereExpression(this.Token(TestLexerModeSyntaxKind.KWhere), expression);
		}
		
		public LoopRunExpressionSyntax LoopRunExpression(SeparatorStatementSyntax separatorStatement)
		{
		    if (separatorStatement == null) throw new ArgumentNullException(nameof(separatorStatement));
		    return (LoopRunExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LoopRunExpression((Syntax.InternalSyntax.SeparatorStatementGreen)separatorStatement.Green).CreateRed();
		}
		
		public SeparatorStatementSyntax SeparatorStatement(SyntaxToken tSemicolon, SyntaxToken kSeparator, IdentifierSyntax identifier, SyntaxToken tAssign, StringLiteralxSyntax stringLiteralx)
		{
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLexerModeSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    if (kSeparator == null) throw new ArgumentNullException(nameof(kSeparator));
		    if (kSeparator.GetKind() != TestLexerModeSyntaxKind.KSeparator) throw new ArgumentException(nameof(kSeparator));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tAssign == null) throw new ArgumentNullException(nameof(tAssign));
		    if (tAssign.GetKind() != TestLexerModeSyntaxKind.TAssign) throw new ArgumentException(nameof(tAssign));
		    if (stringLiteralx == null) throw new ArgumentNullException(nameof(stringLiteralx));
		    return (SeparatorStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SeparatorStatement((InternalSyntaxToken)tSemicolon.Node, (InternalSyntaxToken)kSeparator.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tAssign.Node, (Syntax.InternalSyntax.StringLiteralxGreen)stringLiteralx.Green).CreateRed();
		}
		
		public SeparatorStatementSyntax SeparatorStatement(IdentifierSyntax identifier, StringLiteralxSyntax stringLiteralx)
		{
			return this.SeparatorStatement(this.Token(TestLexerModeSyntaxKind.TSemicolon), this.Token(TestLexerModeSyntaxKind.KSeparator), identifier, this.Token(TestLexerModeSyntaxKind.TAssign), stringLiteralx);
		}
		
		public SwitchStatementSyntax SwitchStatement(SwitchStatementBeginSyntax switchStatementBegin, SyntaxList<SwitchBranchStatementSyntax> switchBranchStatement, SwitchDefaultStatementSyntax switchDefaultStatement, SwitchStatementEndSyntax switchStatementEnd)
		{
		    if (switchStatementBegin == null) throw new ArgumentNullException(nameof(switchStatementBegin));
		    if (switchStatementEnd == null) throw new ArgumentNullException(nameof(switchStatementEnd));
		    return (SwitchStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchStatement((Syntax.InternalSyntax.SwitchStatementBeginGreen)switchStatementBegin.Green, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<SwitchBranchStatementGreen>(switchBranchStatement.Node), switchDefaultStatement == null ? null : (Syntax.InternalSyntax.SwitchDefaultStatementGreen)switchDefaultStatement.Green, (Syntax.InternalSyntax.SwitchStatementEndGreen)switchStatementEnd.Green).CreateRed();
		}
		
		public SwitchStatementSyntax SwitchStatement(SwitchStatementBeginSyntax switchStatementBegin, SwitchStatementEndSyntax switchStatementEnd)
		{
			return this.SwitchStatement(switchStatementBegin, default, default, switchStatementEnd);
		}
		
		public SwitchStatementBeginSyntax SwitchStatementBegin(SyntaxToken kSwitch, SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
		{
		    if (kSwitch == null) throw new ArgumentNullException(nameof(kSwitch));
		    if (kSwitch.GetKind() != TestLexerModeSyntaxKind.KSwitch) throw new ArgumentException(nameof(kSwitch));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (SwitchStatementBeginSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchStatementBegin((InternalSyntaxToken)kSwitch.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public SwitchStatementBeginSyntax SwitchStatementBegin(ExpressionSyntax expression)
		{
			return this.SwitchStatementBegin(this.Token(TestLexerModeSyntaxKind.KSwitch), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), expression, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public SwitchStatementEndSyntax SwitchStatementEnd(SyntaxToken kEnd, SyntaxToken kSwitch)
		{
		    if (kEnd == null) throw new ArgumentNullException(nameof(kEnd));
		    if (kEnd.GetKind() != TestLexerModeSyntaxKind.KEnd) throw new ArgumentException(nameof(kEnd));
		    if (kSwitch == null) throw new ArgumentNullException(nameof(kSwitch));
		    if (kSwitch.GetKind() != TestLexerModeSyntaxKind.KSwitch) throw new ArgumentException(nameof(kSwitch));
		    return (SwitchStatementEndSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchStatementEnd((InternalSyntaxToken)kEnd.Node, (InternalSyntaxToken)kSwitch.Node).CreateRed();
		}
		
		public SwitchStatementEndSyntax SwitchStatementEnd()
		{
			return this.SwitchStatementEnd(this.Token(TestLexerModeSyntaxKind.KEnd), this.Token(TestLexerModeSyntaxKind.KSwitch));
		}
		
		public SwitchBranchStatementSyntax SwitchBranchStatement(SwitchBranchHeadStatementSyntax switchBranchHeadStatement, BodySyntax body)
		{
		    if (switchBranchHeadStatement == null) throw new ArgumentNullException(nameof(switchBranchHeadStatement));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    return (SwitchBranchStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchBranchStatement((Syntax.InternalSyntax.SwitchBranchHeadStatementGreen)switchBranchHeadStatement.Green, (Syntax.InternalSyntax.BodyGreen)body.Green).CreateRed();
		}
		
		public SwitchBranchHeadStatementSyntax SwitchBranchHeadStatement(SwitchCaseOrTypeIsHeadStatementsSyntax switchCaseOrTypeIsHeadStatements)
		{
		    if (switchCaseOrTypeIsHeadStatements == null) throw new ArgumentNullException(nameof(switchCaseOrTypeIsHeadStatements));
		    return (SwitchBranchHeadStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchBranchHeadStatement((Syntax.InternalSyntax.SwitchCaseOrTypeIsHeadStatementsGreen)switchCaseOrTypeIsHeadStatements.Green).CreateRed();
		}
		
		public SwitchBranchHeadStatementSyntax SwitchBranchHeadStatement(SwitchTypeAsHeadStatementSyntax switchTypeAsHeadStatement)
		{
		    if (switchTypeAsHeadStatement == null) throw new ArgumentNullException(nameof(switchTypeAsHeadStatement));
		    return (SwitchBranchHeadStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchBranchHeadStatement((Syntax.InternalSyntax.SwitchTypeAsHeadStatementGreen)switchTypeAsHeadStatement.Green).CreateRed();
		}
		
		public SwitchCaseOrTypeIsHeadStatementsSyntax SwitchCaseOrTypeIsHeadStatements(SyntaxList<SwitchCaseOrTypeIsHeadStatementSyntax> switchCaseOrTypeIsHeadStatement)
		{
		    if (switchCaseOrTypeIsHeadStatement == null) throw new ArgumentNullException(nameof(switchCaseOrTypeIsHeadStatement));
		    return (SwitchCaseOrTypeIsHeadStatementsSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchCaseOrTypeIsHeadStatements(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<SwitchCaseOrTypeIsHeadStatementGreen>(switchCaseOrTypeIsHeadStatement.Node)).CreateRed();
		}
		
		public SwitchCaseOrTypeIsHeadStatementSyntax SwitchCaseOrTypeIsHeadStatement(SwitchCaseHeadStatementSyntax switchCaseHeadStatement)
		{
		    if (switchCaseHeadStatement == null) throw new ArgumentNullException(nameof(switchCaseHeadStatement));
		    return (SwitchCaseOrTypeIsHeadStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchCaseOrTypeIsHeadStatement((Syntax.InternalSyntax.SwitchCaseHeadStatementGreen)switchCaseHeadStatement.Green).CreateRed();
		}
		
		public SwitchCaseOrTypeIsHeadStatementSyntax SwitchCaseOrTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax switchTypeIsHeadStatement)
		{
		    if (switchTypeIsHeadStatement == null) throw new ArgumentNullException(nameof(switchTypeIsHeadStatement));
		    return (SwitchCaseOrTypeIsHeadStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchCaseOrTypeIsHeadStatement((Syntax.InternalSyntax.SwitchTypeIsHeadStatementGreen)switchTypeIsHeadStatement.Green).CreateRed();
		}
		
		public SwitchCaseHeadStatementSyntax SwitchCaseHeadStatement(SyntaxToken kCase, ExpressionListSyntax expressionList, SyntaxToken tColon)
		{
		    if (kCase == null) throw new ArgumentNullException(nameof(kCase));
		    if (kCase.GetKind() != TestLexerModeSyntaxKind.KCase) throw new ArgumentException(nameof(kCase));
		    if (expressionList == null) throw new ArgumentNullException(nameof(expressionList));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    return (SwitchCaseHeadStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchCaseHeadStatement((InternalSyntaxToken)kCase.Node, (Syntax.InternalSyntax.ExpressionListGreen)expressionList.Green, (InternalSyntaxToken)tColon.Node).CreateRed();
		}
		
		public SwitchCaseHeadStatementSyntax SwitchCaseHeadStatement(ExpressionListSyntax expressionList)
		{
			return this.SwitchCaseHeadStatement(this.Token(TestLexerModeSyntaxKind.KCase), expressionList, this.Token(TestLexerModeSyntaxKind.TColon));
		}
		
		public SwitchTypeIsHeadStatementSyntax SwitchTypeIsHeadStatement(SyntaxToken kType, SyntaxToken kIs, TypeReferenceListSyntax typeReferenceList, SyntaxToken tColon)
		{
		    if (kType == null) throw new ArgumentNullException(nameof(kType));
		    if (kType.GetKind() != TestLexerModeSyntaxKind.KType) throw new ArgumentException(nameof(kType));
		    if (kIs == null) throw new ArgumentNullException(nameof(kIs));
		    if (kIs.GetKind() != TestLexerModeSyntaxKind.KIs) throw new ArgumentException(nameof(kIs));
		    if (typeReferenceList == null) throw new ArgumentNullException(nameof(typeReferenceList));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    return (SwitchTypeIsHeadStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchTypeIsHeadStatement((InternalSyntaxToken)kType.Node, (InternalSyntaxToken)kIs.Node, (Syntax.InternalSyntax.TypeReferenceListGreen)typeReferenceList.Green, (InternalSyntaxToken)tColon.Node).CreateRed();
		}
		
		public SwitchTypeIsHeadStatementSyntax SwitchTypeIsHeadStatement(TypeReferenceListSyntax typeReferenceList)
		{
			return this.SwitchTypeIsHeadStatement(this.Token(TestLexerModeSyntaxKind.KType), this.Token(TestLexerModeSyntaxKind.KIs), typeReferenceList, this.Token(TestLexerModeSyntaxKind.TColon));
		}
		
		public SwitchTypeAsHeadStatementSyntax SwitchTypeAsHeadStatement(SyntaxToken kType, SyntaxToken kAs, TypeReferenceSyntax typeReference, SyntaxToken tColon)
		{
		    if (kType == null) throw new ArgumentNullException(nameof(kType));
		    if (kType.GetKind() != TestLexerModeSyntaxKind.KType) throw new ArgumentException(nameof(kType));
		    if (kAs == null) throw new ArgumentNullException(nameof(kAs));
		    if (kAs.GetKind() != TestLexerModeSyntaxKind.KAs) throw new ArgumentException(nameof(kAs));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    return (SwitchTypeAsHeadStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchTypeAsHeadStatement((InternalSyntaxToken)kType.Node, (InternalSyntaxToken)kAs.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tColon.Node).CreateRed();
		}
		
		public SwitchTypeAsHeadStatementSyntax SwitchTypeAsHeadStatement(TypeReferenceSyntax typeReference)
		{
			return this.SwitchTypeAsHeadStatement(this.Token(TestLexerModeSyntaxKind.KType), this.Token(TestLexerModeSyntaxKind.KAs), typeReference, this.Token(TestLexerModeSyntaxKind.TColon));
		}
		
		public SwitchDefaultStatementSyntax SwitchDefaultStatement(SwitchDefaultHeadStatementSyntax switchDefaultHeadStatement, BodySyntax body)
		{
		    if (switchDefaultHeadStatement == null) throw new ArgumentNullException(nameof(switchDefaultHeadStatement));
		    if (body == null) throw new ArgumentNullException(nameof(body));
		    return (SwitchDefaultStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchDefaultStatement((Syntax.InternalSyntax.SwitchDefaultHeadStatementGreen)switchDefaultHeadStatement.Green, (Syntax.InternalSyntax.BodyGreen)body.Green).CreateRed();
		}
		
		public SwitchDefaultHeadStatementSyntax SwitchDefaultHeadStatement(SyntaxToken kDefault, SyntaxToken tColon)
		{
		    if (kDefault == null) throw new ArgumentNullException(nameof(kDefault));
		    if (kDefault.GetKind() != TestLexerModeSyntaxKind.KDefault) throw new ArgumentException(nameof(kDefault));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    return (SwitchDefaultHeadStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SwitchDefaultHeadStatement((InternalSyntaxToken)kDefault.Node, (InternalSyntaxToken)tColon.Node).CreateRed();
		}
		
		public SwitchDefaultHeadStatementSyntax SwitchDefaultHeadStatement()
		{
			return this.SwitchDefaultHeadStatement(this.Token(TestLexerModeSyntaxKind.KDefault), this.Token(TestLexerModeSyntaxKind.TColon));
		}
		
		public TemplateDeclarationSyntax TemplateDeclaration(TemplateSignatureSyntax templateSignature, TemplateBodySyntax templateBody, SyntaxToken kEndTemplate)
		{
		    if (templateSignature == null) throw new ArgumentNullException(nameof(templateSignature));
		    if (templateBody == null) throw new ArgumentNullException(nameof(templateBody));
		    if (kEndTemplate == null) throw new ArgumentNullException(nameof(kEndTemplate));
		    if (kEndTemplate.GetKind() != TestLexerModeSyntaxKind.KEndTemplate) throw new ArgumentException(nameof(kEndTemplate));
		    return (TemplateDeclarationSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateDeclaration((Syntax.InternalSyntax.TemplateSignatureGreen)templateSignature.Green, (Syntax.InternalSyntax.TemplateBodyGreen)templateBody.Green, (InternalSyntaxToken)kEndTemplate.Node).CreateRed();
		}
		
		public TemplateSignatureSyntax TemplateSignature(SyntaxToken kTemplate, IdentifierSyntax identifier, SyntaxToken tOpenParenthesis, ParamListSyntax paramList, SyntaxToken tCloseParenthesis)
		{
		    if (kTemplate == null) throw new ArgumentNullException(nameof(kTemplate));
		    if (kTemplate.GetKind() != TestLexerModeSyntaxKind.KTemplate) throw new ArgumentException(nameof(kTemplate));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (TemplateSignatureSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateSignature((InternalSyntaxToken)kTemplate.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, (InternalSyntaxToken)tOpenParenthesis.Node, paramList == null ? null : (Syntax.InternalSyntax.ParamListGreen)paramList.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public TemplateSignatureSyntax TemplateSignature(IdentifierSyntax identifier)
		{
			return this.TemplateSignature(this.Token(TestLexerModeSyntaxKind.KTemplate), identifier, this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public TemplateBodySyntax TemplateBody(SyntaxList<TemplateContentLineSyntax> templateContentLine)
		{
		    return (TemplateBodySyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateBody(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<TemplateContentLineGreen>(templateContentLine.Node)).CreateRed();
		}
		
		public TemplateBodySyntax TemplateBody()
		{
			return this.TemplateBody(default);
		}
		
		public TemplateContentLineSyntax TemplateContentLine(SyntaxList<TemplateContentSyntax> templateContent, TemplateLineEndSyntax templateLineEnd)
		{
		    if (templateLineEnd == null) throw new ArgumentNullException(nameof(templateLineEnd));
		    return (TemplateContentLineSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateContentLine(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<TemplateContentGreen>(templateContent.Node), (Syntax.InternalSyntax.TemplateLineEndGreen)templateLineEnd.Green).CreateRed();
		}
		
		public TemplateContentLineSyntax TemplateContentLine(TemplateLineEndSyntax templateLineEnd)
		{
			return this.TemplateContentLine(default, templateLineEnd);
		}
		
		public TemplateContentSyntax TemplateContent(TemplateOutputxSyntax templateOutputx)
		{
		    if (templateOutputx == null) throw new ArgumentNullException(nameof(templateOutputx));
		    return (TemplateContentSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateContent((Syntax.InternalSyntax.TemplateOutputxGreen)templateOutputx.Green).CreateRed();
		}
		
		public TemplateContentSyntax TemplateContent(TemplateStatementStartEndSyntax templateStatementStartEnd)
		{
		    if (templateStatementStartEnd == null) throw new ArgumentNullException(nameof(templateStatementStartEnd));
		    return (TemplateContentSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateContent((Syntax.InternalSyntax.TemplateStatementStartEndGreen)templateStatementStartEnd.Green).CreateRed();
		}
		
		public TemplateOutputxSyntax TemplateOutputx(SyntaxToken templateOutput)
		{
		    if (templateOutput == null) throw new ArgumentNullException(nameof(templateOutput));
		    if (templateOutput.GetKind() != TestLexerModeSyntaxKind.TemplateOutput) throw new ArgumentException(nameof(templateOutput));
		    return (TemplateOutputxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateOutputx((InternalSyntaxToken)templateOutput.Node).CreateRed();
		}
		
		public TemplateLineEndSyntax TemplateLineEnd(SyntaxToken templateLineEnd)
		{
		    if (templateLineEnd == null) throw new ArgumentNullException(nameof(templateLineEnd));
		    return (TemplateLineEndSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateLineEnd((InternalSyntaxToken)templateLineEnd.Node).CreateRed();
		}
		
		public TemplateStatementStartEndSyntax TemplateStatementStartEnd(SyntaxToken templateStatementStart, TemplateStatementSyntax templateStatement, SyntaxToken templateStatementEnd)
		{
		    if (templateStatementStart == null) throw new ArgumentNullException(nameof(templateStatementStart));
		    if (templateStatementStart.GetKind() != TestLexerModeSyntaxKind.TemplateStatementStart) throw new ArgumentException(nameof(templateStatementStart));
		    if (templateStatementEnd == null) throw new ArgumentNullException(nameof(templateStatementEnd));
		    if (templateStatementEnd.GetKind() != TestLexerModeSyntaxKind.TemplateStatementEnd) throw new ArgumentException(nameof(templateStatementEnd));
		    return (TemplateStatementStartEndSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatementStartEnd((InternalSyntaxToken)templateStatementStart.Node, templateStatement == null ? null : (Syntax.InternalSyntax.TemplateStatementGreen)templateStatement.Green, (InternalSyntaxToken)templateStatementEnd.Node).CreateRed();
		}
		
		public TemplateStatementStartEndSyntax TemplateStatementStartEnd(SyntaxToken templateStatementStart, SyntaxToken templateStatementEnd)
		{
			return this.TemplateStatementStartEnd(templateStatementStart, default, templateStatementEnd);
		}
		
		public TemplateStatementSyntax TemplateStatement(VoidStatementSyntax voidStatement)
		{
		    if (voidStatement == null) throw new ArgumentNullException(nameof(voidStatement));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.VoidStatementGreen)voidStatement.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(VariableDeclarationStatementSyntax variableDeclarationStatement)
		{
		    if (variableDeclarationStatement == null) throw new ArgumentNullException(nameof(variableDeclarationStatement));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.VariableDeclarationStatementGreen)variableDeclarationStatement.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(ExpressionStatementSyntax expressionStatement)
		{
		    if (expressionStatement == null) throw new ArgumentNullException(nameof(expressionStatement));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.ExpressionStatementGreen)expressionStatement.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(IfStatementBeginSyntax ifStatementBegin)
		{
		    if (ifStatementBegin == null) throw new ArgumentNullException(nameof(ifStatementBegin));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.IfStatementBeginGreen)ifStatementBegin.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(ElseIfStatementSyntax elseIfStatement)
		{
		    if (elseIfStatement == null) throw new ArgumentNullException(nameof(elseIfStatement));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.ElseIfStatementGreen)elseIfStatement.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(IfStatementElseSyntax ifStatementElse)
		{
		    if (ifStatementElse == null) throw new ArgumentNullException(nameof(ifStatementElse));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.IfStatementElseGreen)ifStatementElse.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(IfStatementEndSyntax ifStatementEnd)
		{
		    if (ifStatementEnd == null) throw new ArgumentNullException(nameof(ifStatementEnd));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.IfStatementEndGreen)ifStatementEnd.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(ForStatementBeginSyntax forStatementBegin)
		{
		    if (forStatementBegin == null) throw new ArgumentNullException(nameof(forStatementBegin));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.ForStatementBeginGreen)forStatementBegin.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(ForStatementEndSyntax forStatementEnd)
		{
		    if (forStatementEnd == null) throw new ArgumentNullException(nameof(forStatementEnd));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.ForStatementEndGreen)forStatementEnd.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(WhileStatementBeginSyntax whileStatementBegin)
		{
		    if (whileStatementBegin == null) throw new ArgumentNullException(nameof(whileStatementBegin));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.WhileStatementBeginGreen)whileStatementBegin.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(WhileStatementEndSyntax whileStatementEnd)
		{
		    if (whileStatementEnd == null) throw new ArgumentNullException(nameof(whileStatementEnd));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.WhileStatementEndGreen)whileStatementEnd.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(RepeatStatementBeginSyntax repeatStatementBegin)
		{
		    if (repeatStatementBegin == null) throw new ArgumentNullException(nameof(repeatStatementBegin));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.RepeatStatementBeginGreen)repeatStatementBegin.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(RepeatStatementEndSyntax repeatStatementEnd)
		{
		    if (repeatStatementEnd == null) throw new ArgumentNullException(nameof(repeatStatementEnd));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.RepeatStatementEndGreen)repeatStatementEnd.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(LoopStatementBeginSyntax loopStatementBegin)
		{
		    if (loopStatementBegin == null) throw new ArgumentNullException(nameof(loopStatementBegin));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.LoopStatementBeginGreen)loopStatementBegin.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(LoopStatementEndSyntax loopStatementEnd)
		{
		    if (loopStatementEnd == null) throw new ArgumentNullException(nameof(loopStatementEnd));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.LoopStatementEndGreen)loopStatementEnd.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(SwitchStatementBeginSyntax switchStatementBegin)
		{
		    if (switchStatementBegin == null) throw new ArgumentNullException(nameof(switchStatementBegin));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.SwitchStatementBeginGreen)switchStatementBegin.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(SwitchStatementEndSyntax switchStatementEnd)
		{
		    if (switchStatementEnd == null) throw new ArgumentNullException(nameof(switchStatementEnd));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.SwitchStatementEndGreen)switchStatementEnd.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(SwitchBranchHeadStatementSyntax switchBranchHeadStatement)
		{
		    if (switchBranchHeadStatement == null) throw new ArgumentNullException(nameof(switchBranchHeadStatement));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.SwitchBranchHeadStatementGreen)switchBranchHeadStatement.Green).CreateRed();
		}
		
		public TemplateStatementSyntax TemplateStatement(SwitchDefaultHeadStatementSyntax switchDefaultHeadStatement)
		{
		    if (switchDefaultHeadStatement == null) throw new ArgumentNullException(nameof(switchDefaultHeadStatement));
		    return (TemplateStatementSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TemplateStatement((Syntax.InternalSyntax.SwitchDefaultHeadStatementGreen)switchDefaultHeadStatement.Green).CreateRed();
		}
		
		public TypeArgumentListSyntax TypeArgumentList(SyntaxToken tLessThan, TypeReferenceListSyntax typeReferenceList, SyntaxToken tGreaterThan)
		{
		    if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
		    if (tLessThan.GetKind() != TestLexerModeSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
		    if (typeReferenceList == null) throw new ArgumentNullException(nameof(typeReferenceList));
		    if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
		    if (tGreaterThan.GetKind() != TestLexerModeSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
		    return (TypeArgumentListSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeArgumentList((InternalSyntaxToken)tLessThan.Node, (Syntax.InternalSyntax.TypeReferenceListGreen)typeReferenceList.Green, (InternalSyntaxToken)tGreaterThan.Node).CreateRed();
		}
		
		public TypeArgumentListSyntax TypeArgumentList(TypeReferenceListSyntax typeReferenceList)
		{
			return this.TypeArgumentList(this.Token(TestLexerModeSyntaxKind.TLessThan), typeReferenceList, this.Token(TestLexerModeSyntaxKind.TGreaterThan));
		}
		
		public PredefinedTypeSyntax PredefinedType(SyntaxToken predefinedType)
		{
		    if (predefinedType == null) throw new ArgumentNullException(nameof(predefinedType));
		    return (PredefinedTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.PredefinedType((InternalSyntaxToken)predefinedType.Node).CreateRed();
		}
		
		public TypeReferenceListSyntax TypeReferenceList(SeparatedSyntaxList<TypeReferenceSyntax> typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (TypeReferenceListSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReferenceList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<TypeReferenceGreen>(typeReference.Node)).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(ArrayTypeSyntax arrayType)
		{
		    if (arrayType == null) throw new ArgumentNullException(nameof(arrayType));
		    return (TypeReferenceSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.ArrayTypeGreen)arrayType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(NullableTypeSyntax nullableType)
		{
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
		    return (TypeReferenceSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.NullableTypeGreen)nullableType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(GenericTypeSyntax genericType)
		{
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
		    return (TypeReferenceSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.GenericTypeGreen)genericType.Green).CreateRed();
		}
		
		public TypeReferenceSyntax TypeReference(SimpleTypeSyntax simpleType)
		{
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    return (TypeReferenceSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeReference((Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green).CreateRed();
		}
		
		public ArrayTypeSyntax ArrayType(ArrayItemTypeSyntax arrayItemType, RankSpecifiersSyntax rankSpecifiers)
		{
		    if (arrayItemType == null) throw new ArgumentNullException(nameof(arrayItemType));
		    if (rankSpecifiers == null) throw new ArgumentNullException(nameof(rankSpecifiers));
		    return (ArrayTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ArrayType((Syntax.InternalSyntax.ArrayItemTypeGreen)arrayItemType.Green, (Syntax.InternalSyntax.RankSpecifiersGreen)rankSpecifiers.Green).CreateRed();
		}
		
		public ArrayItemTypeSyntax ArrayItemType(NullableTypeSyntax nullableType)
		{
		    if (nullableType == null) throw new ArgumentNullException(nameof(nullableType));
		    return (ArrayItemTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ArrayItemType((Syntax.InternalSyntax.NullableTypeGreen)nullableType.Green).CreateRed();
		}
		
		public ArrayItemTypeSyntax ArrayItemType(GenericTypeSyntax genericType)
		{
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
		    return (ArrayItemTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ArrayItemType((Syntax.InternalSyntax.GenericTypeGreen)genericType.Green).CreateRed();
		}
		
		public ArrayItemTypeSyntax ArrayItemType(SimpleTypeSyntax simpleType)
		{
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    return (ArrayItemTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ArrayItemType((Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green).CreateRed();
		}
		
		public NullableTypeSyntax NullableType(NullableItemTypeSyntax nullableItemType, SyntaxToken tQuestion)
		{
		    if (nullableItemType == null) throw new ArgumentNullException(nameof(nullableItemType));
		    if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
		    if (tQuestion.GetKind() != TestLexerModeSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
		    return (NullableTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.NullableType((Syntax.InternalSyntax.NullableItemTypeGreen)nullableItemType.Green, (InternalSyntaxToken)tQuestion.Node).CreateRed();
		}
		
		public NullableTypeSyntax NullableType(NullableItemTypeSyntax nullableItemType)
		{
			return this.NullableType(nullableItemType, this.Token(TestLexerModeSyntaxKind.TQuestion));
		}
		
		public NullableItemTypeSyntax NullableItemType(GenericTypeSyntax genericType)
		{
		    if (genericType == null) throw new ArgumentNullException(nameof(genericType));
		    return (NullableItemTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.NullableItemType((Syntax.InternalSyntax.GenericTypeGreen)genericType.Green).CreateRed();
		}
		
		public NullableItemTypeSyntax NullableItemType(SimpleTypeSyntax simpleType)
		{
		    if (simpleType == null) throw new ArgumentNullException(nameof(simpleType));
		    return (NullableItemTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.NullableItemType((Syntax.InternalSyntax.SimpleTypeGreen)simpleType.Green).CreateRed();
		}
		
		public GenericTypeSyntax GenericType(QualifiedNameSyntax qualifiedName, TypeArgumentListSyntax typeArgumentList)
		{
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (typeArgumentList == null) throw new ArgumentNullException(nameof(typeArgumentList));
		    return (GenericTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.GenericType((Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.TypeArgumentListGreen)typeArgumentList.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(QualifiedNameSyntax qualifiedName)
		{
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    return (SimpleTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green).CreateRed();
		}
		
		public SimpleTypeSyntax SimpleType(PredefinedTypeSyntax predefinedType)
		{
		    if (predefinedType == null) throw new ArgumentNullException(nameof(predefinedType));
		    return (SimpleTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SimpleType((Syntax.InternalSyntax.PredefinedTypeGreen)predefinedType.Green).CreateRed();
		}
		
		public VoidTypeSyntax VoidType(SyntaxToken kVoid)
		{
		    if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
		    if (kVoid.GetKind() != TestLexerModeSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
		    return (VoidTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.VoidType((InternalSyntaxToken)kVoid.Node).CreateRed();
		}
		
		public VoidTypeSyntax VoidType()
		{
			return this.VoidType(this.Token(TestLexerModeSyntaxKind.KVoid));
		}
		
		public ReturnTypeSyntax ReturnType(TypeReferenceSyntax typeReference)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (ReturnTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public ReturnTypeSyntax ReturnType(VoidTypeSyntax voidType)
		{
		    if (voidType == null) throw new ArgumentNullException(nameof(voidType));
		    return (ReturnTypeSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ReturnType((Syntax.InternalSyntax.VoidTypeGreen)voidType.Green).CreateRed();
		}
		
		public ExpressionListSyntax ExpressionList(SeparatedSyntaxList<ExpressionSyntax> expression)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (ExpressionListSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExpressionList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ExpressionGreen>(expression.Node)).CreateRed();
		}
		
		public VariableReferenceSyntax VariableReference(ExpressionSyntax expression)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (VariableReferenceSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.VariableReference((Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public RankSpecifiersSyntax RankSpecifiers(SyntaxList<RankSpecifierSyntax> rankSpecifier)
		{
		    if (rankSpecifier == null) throw new ArgumentNullException(nameof(rankSpecifier));
		    return (RankSpecifiersSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.RankSpecifiers(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<RankSpecifierGreen>(rankSpecifier.Node)).CreateRed();
		}
		
		public RankSpecifierSyntax RankSpecifier(SyntaxToken tOpenBracket, SyntaxTokenList tComma, SyntaxToken tCloseBracket)
		{
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != TestLexerModeSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != TestLexerModeSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (RankSpecifierSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.RankSpecifier((InternalSyntaxToken)tOpenBracket.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<InternalSyntaxToken>(tComma.Node), (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public RankSpecifierSyntax RankSpecifier(SyntaxToken tOpenBracket)
		{
			return this.RankSpecifier(tOpenBracket, default, this.Token(TestLexerModeSyntaxKind.TCloseBracket));
		}
		
		public UnboundTypeNameSyntax UnboundTypeName(SeparatedSyntaxList<GenericDimensionItemSyntax> genericDimensionItem)
		{
		    if (genericDimensionItem == null) throw new ArgumentNullException(nameof(genericDimensionItem));
		    return (UnboundTypeNameSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.UnboundTypeName(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<GenericDimensionItemGreen>(genericDimensionItem.Node)).CreateRed();
		}
		
		public GenericDimensionItemSyntax GenericDimensionItem(IdentifierSyntax identifier, GenericDimensionSpecifierSyntax genericDimensionSpecifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (GenericDimensionItemSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.GenericDimensionItem((Syntax.InternalSyntax.IdentifierGreen)identifier.Green, genericDimensionSpecifier == null ? null : (Syntax.InternalSyntax.GenericDimensionSpecifierGreen)genericDimensionSpecifier.Green).CreateRed();
		}
		
		public GenericDimensionItemSyntax GenericDimensionItem(IdentifierSyntax identifier)
		{
			return this.GenericDimensionItem(identifier, default);
		}
		
		public GenericDimensionSpecifierSyntax GenericDimensionSpecifier(SyntaxToken tLessThan, SyntaxTokenList tComma, SyntaxToken tGreaterThan)
		{
		    if (tLessThan == null) throw new ArgumentNullException(nameof(tLessThan));
		    if (tLessThan.GetKind() != TestLexerModeSyntaxKind.TLessThan) throw new ArgumentException(nameof(tLessThan));
		    if (tGreaterThan == null) throw new ArgumentNullException(nameof(tGreaterThan));
		    if (tGreaterThan.GetKind() != TestLexerModeSyntaxKind.TGreaterThan) throw new ArgumentException(nameof(tGreaterThan));
		    return (GenericDimensionSpecifierSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.GenericDimensionSpecifier((InternalSyntaxToken)tLessThan.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<InternalSyntaxToken>(tComma.Node), (InternalSyntaxToken)tGreaterThan.Node).CreateRed();
		}
		
		public GenericDimensionSpecifierSyntax GenericDimensionSpecifier()
		{
			return this.GenericDimensionSpecifier(this.Token(TestLexerModeSyntaxKind.TLessThan), default, this.Token(TestLexerModeSyntaxKind.TGreaterThan));
		}
		
		public ExplicitAnonymousFunctionSignatureSyntax ExplicitAnonymousFunctionSignature(SyntaxToken tOpenParenthesis, SeparatedSyntaxList<ExplicitParameterSyntax> explicitParameter, SyntaxToken tCloseParenthesis)
		{
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (ExplicitAnonymousFunctionSignatureSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExplicitAnonymousFunctionSignature((InternalSyntaxToken)tOpenParenthesis.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ExplicitParameterGreen>(explicitParameter.Node), (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public ExplicitAnonymousFunctionSignatureSyntax ExplicitAnonymousFunctionSignature()
		{
			return this.ExplicitAnonymousFunctionSignature(this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public ImplicitAnonymousFunctionSignatureSyntax ImplicitAnonymousFunctionSignature(SyntaxToken tOpenParenthesis, SeparatedSyntaxList<ImplicitParameterSyntax> implicitParameter, SyntaxToken tCloseParenthesis)
		{
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (ImplicitAnonymousFunctionSignatureSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ImplicitAnonymousFunctionSignature((InternalSyntaxToken)tOpenParenthesis.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<ImplicitParameterGreen>(implicitParameter.Node), (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public ImplicitAnonymousFunctionSignatureSyntax ImplicitAnonymousFunctionSignature()
		{
			return this.ImplicitAnonymousFunctionSignature(this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public SingleParamAnonymousFunctionSignatureSyntax SingleParamAnonymousFunctionSignature(ImplicitParameterSyntax implicitParameter)
		{
		    if (implicitParameter == null) throw new ArgumentNullException(nameof(implicitParameter));
		    return (SingleParamAnonymousFunctionSignatureSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.SingleParamAnonymousFunctionSignature((Syntax.InternalSyntax.ImplicitParameterGreen)implicitParameter.Green).CreateRed();
		}
		
		public ExplicitParameterSyntax ExplicitParameter(TypeReferenceSyntax typeReference, IdentifierSyntax identifier)
		{
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (ExplicitParameterSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ExplicitParameter((Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public ImplicitParameterSyntax ImplicitParameter(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (ImplicitParameterSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ImplicitParameter((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public ThisExpressionSyntax ThisExpression(SyntaxToken kThis)
		{
		    if (kThis == null) throw new ArgumentNullException(nameof(kThis));
		    if (kThis.GetKind() != TestLexerModeSyntaxKind.KThis) throw new ArgumentException(nameof(kThis));
		    return (ThisExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ThisExpression((InternalSyntaxToken)kThis.Node).CreateRed();
		}
		
		public ThisExpressionSyntax ThisExpression()
		{
			return this.ThisExpression(this.Token(TestLexerModeSyntaxKind.KThis));
		}
		
		public LiteralExpressionSyntax LiteralExpression(LiteralSyntax literal)
		{
		    if (literal == null) throw new ArgumentNullException(nameof(literal));
		    return (LiteralExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LiteralExpression((Syntax.InternalSyntax.LiteralGreen)literal.Green).CreateRed();
		}
		
		public TypeofVoidExpressionSyntax TypeofVoidExpression(SyntaxToken kTypeof, SyntaxToken tOpenParenthesis, SyntaxToken kVoid, SyntaxToken tCloseParenthesis)
		{
		    if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
		    if (kTypeof.GetKind() != TestLexerModeSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (kVoid == null) throw new ArgumentNullException(nameof(kVoid));
		    if (kVoid.GetKind() != TestLexerModeSyntaxKind.KVoid) throw new ArgumentException(nameof(kVoid));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (TypeofVoidExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeofVoidExpression((InternalSyntaxToken)kTypeof.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (InternalSyntaxToken)kVoid.Node, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public TypeofVoidExpressionSyntax TypeofVoidExpression()
		{
			return this.TypeofVoidExpression(this.Token(TestLexerModeSyntaxKind.KTypeof), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), this.Token(TestLexerModeSyntaxKind.KVoid), this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public TypeofUnboundTypeExpressionSyntax TypeofUnboundTypeExpression(SyntaxToken kTypeof, SyntaxToken tOpenParenthesis, UnboundTypeNameSyntax unboundTypeName, SyntaxToken tCloseParenthesis)
		{
		    if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
		    if (kTypeof.GetKind() != TestLexerModeSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (unboundTypeName == null) throw new ArgumentNullException(nameof(unboundTypeName));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (TypeofUnboundTypeExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeofUnboundTypeExpression((InternalSyntaxToken)kTypeof.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.UnboundTypeNameGreen)unboundTypeName.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public TypeofUnboundTypeExpressionSyntax TypeofUnboundTypeExpression(UnboundTypeNameSyntax unboundTypeName)
		{
			return this.TypeofUnboundTypeExpression(this.Token(TestLexerModeSyntaxKind.KTypeof), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), unboundTypeName, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public TypeofTypeExpressionSyntax TypeofTypeExpression(SyntaxToken kTypeof, SyntaxToken tOpenParenthesis, TypeReferenceSyntax typeReference, SyntaxToken tCloseParenthesis)
		{
		    if (kTypeof == null) throw new ArgumentNullException(nameof(kTypeof));
		    if (kTypeof.GetKind() != TestLexerModeSyntaxKind.KTypeof) throw new ArgumentException(nameof(kTypeof));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (TypeofTypeExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypeofTypeExpression((InternalSyntaxToken)kTypeof.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public TypeofTypeExpressionSyntax TypeofTypeExpression(TypeReferenceSyntax typeReference)
		{
			return this.TypeofTypeExpression(this.Token(TestLexerModeSyntaxKind.KTypeof), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), typeReference, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public DefaultValueExpressionSyntax DefaultValueExpression(SyntaxToken kDefault, SyntaxToken tOpenParenthesis, TypeReferenceSyntax typeReference, SyntaxToken tCloseParenthesis)
		{
		    if (kDefault == null) throw new ArgumentNullException(nameof(kDefault));
		    if (kDefault.GetKind() != TestLexerModeSyntaxKind.KDefault) throw new ArgumentException(nameof(kDefault));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (DefaultValueExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.DefaultValueExpression((InternalSyntaxToken)kDefault.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public DefaultValueExpressionSyntax DefaultValueExpression(TypeReferenceSyntax typeReference)
		{
			return this.DefaultValueExpression(this.Token(TestLexerModeSyntaxKind.KDefault), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), typeReference, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public NewObjectOrCollectionWithConstructorExpressionSyntax NewObjectOrCollectionWithConstructorExpression(SyntaxToken kNew, TypeReferenceSyntax typeReference, SyntaxToken tOpenParenthesis, ExpressionListSyntax expressionList, SyntaxToken tCloseParenthesis)
		{
		    if (kNew == null) throw new ArgumentNullException(nameof(kNew));
		    if (kNew.GetKind() != TestLexerModeSyntaxKind.KNew) throw new ArgumentException(nameof(kNew));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (NewObjectOrCollectionWithConstructorExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.NewObjectOrCollectionWithConstructorExpression((InternalSyntaxToken)kNew.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tOpenParenthesis.Node, expressionList == null ? null : (Syntax.InternalSyntax.ExpressionListGreen)expressionList.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public NewObjectOrCollectionWithConstructorExpressionSyntax NewObjectOrCollectionWithConstructorExpression(TypeReferenceSyntax typeReference)
		{
			return this.NewObjectOrCollectionWithConstructorExpression(this.Token(TestLexerModeSyntaxKind.KNew), typeReference, this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public IdentifierExpressionSyntax IdentifierExpression(IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.IdentifierExpression((Syntax.InternalSyntax.IdentifierGreen)identifier.Green, typeArgumentList == null ? null : (Syntax.InternalSyntax.TypeArgumentListGreen)typeArgumentList.Green).CreateRed();
		}
		
		public IdentifierExpressionSyntax IdentifierExpression(IdentifierSyntax identifier)
		{
			return this.IdentifierExpression(identifier, default);
		}
		
		public HasLoopExpressionSyntax HasLoopExpression(SyntaxToken kHasLoop, SyntaxToken tOpenParenthesis, LoopChainSyntax loopChain, LoopWhereExpressionSyntax loopWhereExpression, SyntaxToken tCloseParenthesis)
		{
		    if (kHasLoop == null) throw new ArgumentNullException(nameof(kHasLoop));
		    if (kHasLoop.GetKind() != TestLexerModeSyntaxKind.KHasLoop) throw new ArgumentException(nameof(kHasLoop));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (loopChain == null) throw new ArgumentNullException(nameof(loopChain));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (HasLoopExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.HasLoopExpression((InternalSyntaxToken)kHasLoop.Node, (InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.LoopChainGreen)loopChain.Green, loopWhereExpression == null ? null : (Syntax.InternalSyntax.LoopWhereExpressionGreen)loopWhereExpression.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public HasLoopExpressionSyntax HasLoopExpression(LoopChainSyntax loopChain)
		{
			return this.HasLoopExpression(this.Token(TestLexerModeSyntaxKind.KHasLoop), this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), loopChain, default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public ParenthesizedExpressionSyntax ParenthesizedExpression(SyntaxToken tOpenParenthesis, ExpressionSyntax expression, SyntaxToken tCloseParenthesis)
		{
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (ParenthesizedExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ParenthesizedExpression((InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public ParenthesizedExpressionSyntax ParenthesizedExpression(ExpressionSyntax expression)
		{
			return this.ParenthesizedExpression(this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), expression, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public ElementAccessExpressionSyntax ElementAccessExpression(ExpressionSyntax expression, SyntaxToken tOpenBracket, ExpressionListSyntax expressionList, SyntaxToken tCloseBracket)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tOpenBracket == null) throw new ArgumentNullException(nameof(tOpenBracket));
		    if (tOpenBracket.GetKind() != TestLexerModeSyntaxKind.TOpenBracket) throw new ArgumentException(nameof(tOpenBracket));
		    if (expressionList == null) throw new ArgumentNullException(nameof(expressionList));
		    if (tCloseBracket == null) throw new ArgumentNullException(nameof(tCloseBracket));
		    if (tCloseBracket.GetKind() != TestLexerModeSyntaxKind.TCloseBracket) throw new ArgumentException(nameof(tCloseBracket));
		    return (ElementAccessExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ElementAccessExpression((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tOpenBracket.Node, (Syntax.InternalSyntax.ExpressionListGreen)expressionList.Green, (InternalSyntaxToken)tCloseBracket.Node).CreateRed();
		}
		
		public ElementAccessExpressionSyntax ElementAccessExpression(ExpressionSyntax expression, SyntaxToken tOpenBracket, ExpressionListSyntax expressionList)
		{
			return this.ElementAccessExpression(expression, tOpenBracket, expressionList, this.Token(TestLexerModeSyntaxKind.TCloseBracket));
		}
		
		public FunctionCallExpressionSyntax FunctionCallExpression(ExpressionSyntax expression, SyntaxToken tOpenParenthesis, ExpressionListSyntax expressionList, SyntaxToken tCloseParenthesis)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    return (FunctionCallExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.FunctionCallExpression((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tOpenParenthesis.Node, expressionList == null ? null : (Syntax.InternalSyntax.ExpressionListGreen)expressionList.Green, (InternalSyntaxToken)tCloseParenthesis.Node).CreateRed();
		}
		
		public FunctionCallExpressionSyntax FunctionCallExpression(ExpressionSyntax expression)
		{
			return this.FunctionCallExpression(expression, this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), default, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis));
		}
		
		public PredefinedTypeMemberAccessExpressionSyntax PredefinedTypeMemberAccessExpression(PredefinedTypeSyntax predefinedType, SyntaxToken tDot, IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
		{
		    if (predefinedType == null) throw new ArgumentNullException(nameof(predefinedType));
		    if (tDot == null) throw new ArgumentNullException(nameof(tDot));
		    if (tDot.GetKind() != TestLexerModeSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (PredefinedTypeMemberAccessExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.PredefinedTypeMemberAccessExpression((Syntax.InternalSyntax.PredefinedTypeGreen)predefinedType.Green, (InternalSyntaxToken)tDot.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, typeArgumentList == null ? null : (Syntax.InternalSyntax.TypeArgumentListGreen)typeArgumentList.Green).CreateRed();
		}
		
		public PredefinedTypeMemberAccessExpressionSyntax PredefinedTypeMemberAccessExpression(PredefinedTypeSyntax predefinedType, IdentifierSyntax identifier)
		{
			return this.PredefinedTypeMemberAccessExpression(predefinedType, this.Token(TestLexerModeSyntaxKind.TDot), identifier, default);
		}
		
		public MemberAccessExpressionSyntax MemberAccessExpression(ExpressionSyntax expression, SyntaxToken tDot, IdentifierSyntax identifier, TypeArgumentListSyntax typeArgumentList)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (tDot == null) throw new ArgumentNullException(nameof(tDot));
		    if (tDot.GetKind() != TestLexerModeSyntaxKind.TDot) throw new ArgumentException(nameof(tDot));
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (MemberAccessExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.MemberAccessExpression((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)tDot.Node, (Syntax.InternalSyntax.IdentifierGreen)identifier.Green, typeArgumentList == null ? null : (Syntax.InternalSyntax.TypeArgumentListGreen)typeArgumentList.Green).CreateRed();
		}
		
		public MemberAccessExpressionSyntax MemberAccessExpression(ExpressionSyntax expression, IdentifierSyntax identifier)
		{
			return this.MemberAccessExpression(expression, this.Token(TestLexerModeSyntaxKind.TDot), identifier, default);
		}
		
		public TypecastExpressionSyntax TypecastExpression(SyntaxToken tOpenParenthesis, TypeReferenceSyntax typeReference, SyntaxToken tCloseParenthesis, ExpressionSyntax expression)
		{
		    if (tOpenParenthesis == null) throw new ArgumentNullException(nameof(tOpenParenthesis));
		    if (tOpenParenthesis.GetKind() != TestLexerModeSyntaxKind.TOpenParenthesis) throw new ArgumentException(nameof(tOpenParenthesis));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    if (tCloseParenthesis == null) throw new ArgumentNullException(nameof(tCloseParenthesis));
		    if (tCloseParenthesis.GetKind() != TestLexerModeSyntaxKind.TCloseParenthesis) throw new ArgumentException(nameof(tCloseParenthesis));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (TypecastExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypecastExpression((InternalSyntaxToken)tOpenParenthesis.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green, (InternalSyntaxToken)tCloseParenthesis.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public TypecastExpressionSyntax TypecastExpression(TypeReferenceSyntax typeReference, ExpressionSyntax expression)
		{
			return this.TypecastExpression(this.Token(TestLexerModeSyntaxKind.TOpenParenthesis), typeReference, this.Token(TestLexerModeSyntaxKind.TCloseParenthesis), expression);
		}
		
		public UnaryExpressionSyntax UnaryExpression(SyntaxToken op, ExpressionSyntax expression)
		{
		    if (op == null) throw new ArgumentNullException(nameof(op));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (UnaryExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.UnaryExpression((InternalSyntaxToken)op.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public PostExpressionSyntax PostExpression(ExpressionSyntax expression, SyntaxToken op)
		{
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    if (op == null) throw new ArgumentNullException(nameof(op));
		    return (PostExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.PostExpression((Syntax.InternalSyntax.ExpressionGreen)expression.Green, (InternalSyntaxToken)op.Node).CreateRed();
		}
		
		public MultiplicationExpressionSyntax MultiplicationExpression(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (op == null) throw new ArgumentNullException(nameof(op));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (MultiplicationExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.MultiplicationExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)op.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public AdditionExpressionSyntax AdditionExpression(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (op == null) throw new ArgumentNullException(nameof(op));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (AdditionExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.AdditionExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)op.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public RelationalExpressionSyntax RelationalExpression(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (op == null) throw new ArgumentNullException(nameof(op));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (RelationalExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.RelationalExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)op.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public TypecheckExpressionSyntax TypecheckExpression(ExpressionSyntax left, SyntaxToken op, TypeReferenceSyntax typeReference)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (op == null) throw new ArgumentNullException(nameof(op));
		    if (typeReference == null) throw new ArgumentNullException(nameof(typeReference));
		    return (TypecheckExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TypecheckExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)op.Node, (Syntax.InternalSyntax.TypeReferenceGreen)typeReference.Green).CreateRed();
		}
		
		public EqualityExpressionSyntax EqualityExpression(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (op == null) throw new ArgumentNullException(nameof(op));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (EqualityExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.EqualityExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)op.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public BitwiseAndExpressionSyntax BitwiseAndExpression(ExpressionSyntax left, SyntaxToken tAmp, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tAmp == null) throw new ArgumentNullException(nameof(tAmp));
		    if (tAmp.GetKind() != TestLexerModeSyntaxKind.TAmp) throw new ArgumentException(nameof(tAmp));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (BitwiseAndExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.BitwiseAndExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tAmp.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public BitwiseAndExpressionSyntax BitwiseAndExpression(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.BitwiseAndExpression(left, this.Token(TestLexerModeSyntaxKind.TAmp), right);
		}
		
		public BitwiseXorExpressionSyntax BitwiseXorExpression(ExpressionSyntax left, SyntaxToken tHat, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tHat == null) throw new ArgumentNullException(nameof(tHat));
		    if (tHat.GetKind() != TestLexerModeSyntaxKind.THat) throw new ArgumentException(nameof(tHat));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (BitwiseXorExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.BitwiseXorExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tHat.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public BitwiseXorExpressionSyntax BitwiseXorExpression(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.BitwiseXorExpression(left, this.Token(TestLexerModeSyntaxKind.THat), right);
		}
		
		public BitwiseOrExpressionSyntax BitwiseOrExpression(ExpressionSyntax left, SyntaxToken tPipe, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tPipe == null) throw new ArgumentNullException(nameof(tPipe));
		    if (tPipe.GetKind() != TestLexerModeSyntaxKind.TPipe) throw new ArgumentException(nameof(tPipe));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (BitwiseOrExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.BitwiseOrExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tPipe.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public BitwiseOrExpressionSyntax BitwiseOrExpression(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.BitwiseOrExpression(left, this.Token(TestLexerModeSyntaxKind.TPipe), right);
		}
		
		public LogicalAndExpressionSyntax LogicalAndExpression(ExpressionSyntax left, SyntaxToken tAnd, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tAnd == null) throw new ArgumentNullException(nameof(tAnd));
		    if (tAnd.GetKind() != TestLexerModeSyntaxKind.TAnd) throw new ArgumentException(nameof(tAnd));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (LogicalAndExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LogicalAndExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tAnd.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public LogicalAndExpressionSyntax LogicalAndExpression(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.LogicalAndExpression(left, this.Token(TestLexerModeSyntaxKind.TAnd), right);
		}
		
		public LogicalXorExpressionSyntax LogicalXorExpression(ExpressionSyntax left, SyntaxToken tXor, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tXor == null) throw new ArgumentNullException(nameof(tXor));
		    if (tXor.GetKind() != TestLexerModeSyntaxKind.TXor) throw new ArgumentException(nameof(tXor));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (LogicalXorExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LogicalXorExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tXor.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public LogicalXorExpressionSyntax LogicalXorExpression(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.LogicalXorExpression(left, this.Token(TestLexerModeSyntaxKind.TXor), right);
		}
		
		public LogicalOrExpressionSyntax LogicalOrExpression(ExpressionSyntax left, SyntaxToken tOr, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (tOr == null) throw new ArgumentNullException(nameof(tOr));
		    if (tOr.GetKind() != TestLexerModeSyntaxKind.TOr) throw new ArgumentException(nameof(tOr));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (LogicalOrExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LogicalOrExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)tOr.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public LogicalOrExpressionSyntax LogicalOrExpression(ExpressionSyntax left, ExpressionSyntax right)
		{
			return this.LogicalOrExpression(left, this.Token(TestLexerModeSyntaxKind.TOr), right);
		}
		
		public ConditionalExpressionSyntax ConditionalExpression(ExpressionSyntax condition, SyntaxToken tQuestion, ExpressionSyntax thenBranch, SyntaxToken tColon, ExpressionSyntax elseBranch)
		{
		    if (condition == null) throw new ArgumentNullException(nameof(condition));
		    if (tQuestion == null) throw new ArgumentNullException(nameof(tQuestion));
		    if (tQuestion.GetKind() != TestLexerModeSyntaxKind.TQuestion) throw new ArgumentException(nameof(tQuestion));
		    if (thenBranch == null) throw new ArgumentNullException(nameof(thenBranch));
		    if (tColon == null) throw new ArgumentNullException(nameof(tColon));
		    if (tColon.GetKind() != TestLexerModeSyntaxKind.TColon) throw new ArgumentException(nameof(tColon));
		    if (elseBranch == null) throw new ArgumentNullException(nameof(elseBranch));
		    return (ConditionalExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ConditionalExpression((Syntax.InternalSyntax.ExpressionGreen)condition.Green, (InternalSyntaxToken)tQuestion.Node, (Syntax.InternalSyntax.ExpressionGreen)thenBranch.Green, (InternalSyntaxToken)tColon.Node, (Syntax.InternalSyntax.ExpressionGreen)elseBranch.Green).CreateRed();
		}
		
		public ConditionalExpressionSyntax ConditionalExpression(ExpressionSyntax condition, ExpressionSyntax thenBranch, ExpressionSyntax elseBranch)
		{
			return this.ConditionalExpression(condition, this.Token(TestLexerModeSyntaxKind.TQuestion), thenBranch, this.Token(TestLexerModeSyntaxKind.TColon), elseBranch);
		}
		
		public AssignmentExpressionSyntax AssignmentExpression(ExpressionSyntax left, SyntaxToken op, ExpressionSyntax right)
		{
		    if (left == null) throw new ArgumentNullException(nameof(left));
		    if (op == null) throw new ArgumentNullException(nameof(op));
		    if (right == null) throw new ArgumentNullException(nameof(right));
		    return (AssignmentExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.AssignmentExpression((Syntax.InternalSyntax.ExpressionGreen)left.Green, (InternalSyntaxToken)op.Node, (Syntax.InternalSyntax.ExpressionGreen)right.Green).CreateRed();
		}
		
		public LambdaExpressionSyntax LambdaExpression(AnonymousFunctionSignatureSyntax anonymousFunctionSignature, SyntaxToken tArrow, ExpressionSyntax expression)
		{
		    if (anonymousFunctionSignature == null) throw new ArgumentNullException(nameof(anonymousFunctionSignature));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLexerModeSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (expression == null) throw new ArgumentNullException(nameof(expression));
		    return (LambdaExpressionSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.LambdaExpression((Syntax.InternalSyntax.AnonymousFunctionSignatureGreen)anonymousFunctionSignature.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.ExpressionGreen)expression.Green).CreateRed();
		}
		
		public LambdaExpressionSyntax LambdaExpression(AnonymousFunctionSignatureSyntax anonymousFunctionSignature, ExpressionSyntax expression)
		{
			return this.LambdaExpression(anonymousFunctionSignature, this.Token(TestLexerModeSyntaxKind.TArrow), expression);
		}
		
		public QualifiedNameSyntax QualifiedName(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifiedNameSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.QualifiedName(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public IdentifierListSyntax IdentifierList(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierListSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.IdentifierList(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public IdentifierSyntax Identifier(SyntaxToken identifierNormal)
		{
		    if (identifierNormal == null) throw new ArgumentNullException(nameof(identifierNormal));
		    if (identifierNormal.GetKind() != TestLexerModeSyntaxKind.IdentifierNormal) throw new ArgumentException(nameof(identifierNormal));
		    return (IdentifierSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)identifierNormal.Node).CreateRed();
		}
		
		public LiteralSyntax Literal(NullLiteralSyntax nullLiteral)
		{
		    if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
		    return (LiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.NullLiteralGreen)nullLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(BooleanLiteralSyntax booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (LiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(NumberLiteralSyntax numberLiteral)
		{
		    if (numberLiteral == null) throw new ArgumentNullException(nameof(numberLiteral));
		    return (LiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.NumberLiteralGreen)numberLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(DateOrTimeLiteralSyntax dateOrTimeLiteral)
		{
		    if (dateOrTimeLiteral == null) throw new ArgumentNullException(nameof(dateOrTimeLiteral));
		    return (LiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.DateOrTimeLiteralGreen)dateOrTimeLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(CharLiteralxSyntax charLiteralx)
		{
		    if (charLiteralx == null) throw new ArgumentNullException(nameof(charLiteralx));
		    return (LiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.CharLiteralxGreen)charLiteralx.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(StringLiteralxSyntax stringLiteralx)
		{
		    if (stringLiteralx == null) throw new ArgumentNullException(nameof(stringLiteralx));
		    return (LiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.StringLiteralxGreen)stringLiteralx.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(GuidLiteralxSyntax guidLiteralx)
		{
		    if (guidLiteralx == null) throw new ArgumentNullException(nameof(guidLiteralx));
		    return (LiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.GuidLiteralxGreen)guidLiteralx.Green).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral(SyntaxToken kNull)
		{
		    if (kNull == null) throw new ArgumentNullException(nameof(kNull));
		    if (kNull.GetKind() != TestLexerModeSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
		    return (NullLiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.NullLiteral((InternalSyntaxToken)kNull.Node).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral()
		{
			return this.NullLiteral(this.Token(TestLexerModeSyntaxKind.KNull));
		}
		
		public BooleanLiteralSyntax BooleanLiteral(SyntaxToken booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (BooleanLiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.BooleanLiteral((InternalSyntaxToken)booleanLiteral.Node).CreateRed();
		}
		
		public NumberLiteralSyntax NumberLiteral(IntegerLiteralxSyntax integerLiteralx)
		{
		    if (integerLiteralx == null) throw new ArgumentNullException(nameof(integerLiteralx));
		    return (NumberLiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.NumberLiteral((Syntax.InternalSyntax.IntegerLiteralxGreen)integerLiteralx.Green).CreateRed();
		}
		
		public NumberLiteralSyntax NumberLiteral(DecimalLiteralxSyntax decimalLiteralx)
		{
		    if (decimalLiteralx == null) throw new ArgumentNullException(nameof(decimalLiteralx));
		    return (NumberLiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.NumberLiteral((Syntax.InternalSyntax.DecimalLiteralxGreen)decimalLiteralx.Green).CreateRed();
		}
		
		public NumberLiteralSyntax NumberLiteral(ScientificLiteralxSyntax scientificLiteralx)
		{
		    if (scientificLiteralx == null) throw new ArgumentNullException(nameof(scientificLiteralx));
		    return (NumberLiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.NumberLiteral((Syntax.InternalSyntax.ScientificLiteralxGreen)scientificLiteralx.Green).CreateRed();
		}
		
		public IntegerLiteralxSyntax IntegerLiteralx(SyntaxToken integerLiteral)
		{
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    if (integerLiteral.GetKind() != TestLexerModeSyntaxKind.IntegerLiteral) throw new ArgumentException(nameof(integerLiteral));
		    return (IntegerLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.IntegerLiteralx((InternalSyntaxToken)integerLiteral.Node).CreateRed();
		}
		
		public DecimalLiteralxSyntax DecimalLiteralx(SyntaxToken decimalLiteral)
		{
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
		    if (decimalLiteral.GetKind() != TestLexerModeSyntaxKind.DecimalLiteral) throw new ArgumentException(nameof(decimalLiteral));
		    return (DecimalLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.DecimalLiteralx((InternalSyntaxToken)decimalLiteral.Node).CreateRed();
		}
		
		public ScientificLiteralxSyntax ScientificLiteralx(SyntaxToken scientificLiteral)
		{
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
		    if (scientificLiteral.GetKind() != TestLexerModeSyntaxKind.ScientificLiteral) throw new ArgumentException(nameof(scientificLiteral));
		    return (ScientificLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.ScientificLiteralx((InternalSyntaxToken)scientificLiteral.Node).CreateRed();
		}
		
		public DateOrTimeLiteralSyntax DateOrTimeLiteral(DateTimeLiteralxSyntax dateTimeLiteralx)
		{
		    if (dateTimeLiteralx == null) throw new ArgumentNullException(nameof(dateTimeLiteralx));
		    return (DateOrTimeLiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateOrTimeLiteral((Syntax.InternalSyntax.DateTimeLiteralxGreen)dateTimeLiteralx.Green).CreateRed();
		}
		
		public DateOrTimeLiteralSyntax DateOrTimeLiteral(DateTimeOffsetLiteralxSyntax dateTimeOffsetLiteralx)
		{
		    if (dateTimeOffsetLiteralx == null) throw new ArgumentNullException(nameof(dateTimeOffsetLiteralx));
		    return (DateOrTimeLiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateOrTimeLiteral((Syntax.InternalSyntax.DateTimeOffsetLiteralxGreen)dateTimeOffsetLiteralx.Green).CreateRed();
		}
		
		public DateOrTimeLiteralSyntax DateOrTimeLiteral(DateLiteralxSyntax dateLiteralx)
		{
		    if (dateLiteralx == null) throw new ArgumentNullException(nameof(dateLiteralx));
		    return (DateOrTimeLiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateOrTimeLiteral((Syntax.InternalSyntax.DateLiteralxGreen)dateLiteralx.Green).CreateRed();
		}
		
		public DateOrTimeLiteralSyntax DateOrTimeLiteral(TimeLiteralxSyntax timeLiteralx)
		{
		    if (timeLiteralx == null) throw new ArgumentNullException(nameof(timeLiteralx));
		    return (DateOrTimeLiteralSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateOrTimeLiteral((Syntax.InternalSyntax.TimeLiteralxGreen)timeLiteralx.Green).CreateRed();
		}
		
		public DateTimeOffsetLiteralxSyntax DateTimeOffsetLiteralx(SyntaxToken dateTimeOffsetLiteral)
		{
		    if (dateTimeOffsetLiteral == null) throw new ArgumentNullException(nameof(dateTimeOffsetLiteral));
		    if (dateTimeOffsetLiteral.GetKind() != TestLexerModeSyntaxKind.DateTimeOffsetLiteral) throw new ArgumentException(nameof(dateTimeOffsetLiteral));
		    return (DateTimeOffsetLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateTimeOffsetLiteralx((InternalSyntaxToken)dateTimeOffsetLiteral.Node).CreateRed();
		}
		
		public DateTimeLiteralxSyntax DateTimeLiteralx(SyntaxToken dateTimeLiteral)
		{
		    if (dateTimeLiteral == null) throw new ArgumentNullException(nameof(dateTimeLiteral));
		    if (dateTimeLiteral.GetKind() != TestLexerModeSyntaxKind.DateTimeLiteral) throw new ArgumentException(nameof(dateTimeLiteral));
		    return (DateTimeLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateTimeLiteralx((InternalSyntaxToken)dateTimeLiteral.Node).CreateRed();
		}
		
		public DateLiteralxSyntax DateLiteralx(SyntaxToken dateLiteral)
		{
		    if (dateLiteral == null) throw new ArgumentNullException(nameof(dateLiteral));
		    if (dateLiteral.GetKind() != TestLexerModeSyntaxKind.DateLiteral) throw new ArgumentException(nameof(dateLiteral));
		    return (DateLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.DateLiteralx((InternalSyntaxToken)dateLiteral.Node).CreateRed();
		}
		
		public TimeLiteralxSyntax TimeLiteralx(SyntaxToken timeLiteral)
		{
		    if (timeLiteral == null) throw new ArgumentNullException(nameof(timeLiteral));
		    if (timeLiteral.GetKind() != TestLexerModeSyntaxKind.TimeLiteral) throw new ArgumentException(nameof(timeLiteral));
		    return (TimeLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.TimeLiteralx((InternalSyntaxToken)timeLiteral.Node).CreateRed();
		}
		
		public CharLiteralxSyntax CharLiteralx(SyntaxToken charLiteral)
		{
		    if (charLiteral == null) throw new ArgumentNullException(nameof(charLiteral));
		    if (charLiteral.GetKind() != TestLexerModeSyntaxKind.CharLiteral) throw new ArgumentException(nameof(charLiteral));
		    return (CharLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.CharLiteralx((InternalSyntaxToken)charLiteral.Node).CreateRed();
		}
		
		public StringLiteralxSyntax StringLiteralx(SyntaxToken stringLiteralx)
		{
		    if (stringLiteralx == null) throw new ArgumentNullException(nameof(stringLiteralx));
		    return (StringLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.StringLiteralx((InternalSyntaxToken)stringLiteralx.Node).CreateRed();
		}
		
		public GuidLiteralxSyntax GuidLiteralx(SyntaxToken guidLiteral)
		{
		    if (guidLiteral == null) throw new ArgumentNullException(nameof(guidLiteral));
		    if (guidLiteral.GetKind() != TestLexerModeSyntaxKind.GuidLiteral) throw new ArgumentException(nameof(guidLiteral));
		    return (GuidLiteralxSyntax)TestLexerModeLanguage.Instance.InternalSyntaxFactory.GuidLiteralx((InternalSyntaxToken)guidLiteral.Node).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(NamespaceDeclarationSyntax),
				typeof(GeneratorDeclarationSyntax),
				typeof(UsingNamespaceDeclarationSyntax),
				typeof(UsingGeneratorDeclarationSyntax),
				typeof(ConfigDeclarationSyntax),
				typeof(ConfigPropertyDeclarationSyntax),
				typeof(ConfigPropertyGroupDeclarationSyntax),
				typeof(MethodDeclarationSyntax),
				typeof(ExternFunctionDeclarationSyntax),
				typeof(FunctionDeclarationSyntax),
				typeof(FunctionSignatureSyntax),
				typeof(ParamListSyntax),
				typeof(ParameterSyntax),
				typeof(BodySyntax),
				typeof(StatementSyntax),
				typeof(SingleStatementSyntax),
				typeof(SingleStatementSemicolonSyntax),
				typeof(VariableDeclarationStatementSyntax),
				typeof(VariableDeclarationExpressionSyntax),
				typeof(VariableDeclarationItemSyntax),
				typeof(VoidStatementSyntax),
				typeof(ReturnStatementSyntax),
				typeof(ExpressionStatementSyntax),
				typeof(IfStatementSyntax),
				typeof(ElseIfStatementBodySyntax),
				typeof(IfStatementElseBodySyntax),
				typeof(IfStatementBeginSyntax),
				typeof(ElseIfStatementSyntax),
				typeof(IfStatementElseSyntax),
				typeof(IfStatementEndSyntax),
				typeof(ForStatementSyntax),
				typeof(ForStatementBeginSyntax),
				typeof(ForStatementEndSyntax),
				typeof(ForInitStatementSyntax),
				typeof(WhileStatementSyntax),
				typeof(WhileStatementBeginSyntax),
				typeof(WhileStatementEndSyntax),
				typeof(WhileRunExpressionSyntax),
				typeof(RepeatStatementSyntax),
				typeof(RepeatStatementBeginSyntax),
				typeof(RepeatStatementEndSyntax),
				typeof(RepeatRunExpressionSyntax),
				typeof(LoopStatementSyntax),
				typeof(LoopStatementBeginSyntax),
				typeof(LoopStatementEndSyntax),
				typeof(LoopChainSyntax),
				typeof(LoopChainItemSyntax),
				typeof(LoopChainTypeofExpressionSyntax),
				typeof(LoopChainIdentifierExpressionSyntax),
				typeof(LoopChainMemberAccessExpressionSyntax),
				typeof(LoopChainMethodCallExpressionSyntax),
				typeof(LoopWhereExpressionSyntax),
				typeof(LoopRunExpressionSyntax),
				typeof(SeparatorStatementSyntax),
				typeof(SwitchStatementSyntax),
				typeof(SwitchStatementBeginSyntax),
				typeof(SwitchStatementEndSyntax),
				typeof(SwitchBranchStatementSyntax),
				typeof(SwitchBranchHeadStatementSyntax),
				typeof(SwitchCaseOrTypeIsHeadStatementsSyntax),
				typeof(SwitchCaseOrTypeIsHeadStatementSyntax),
				typeof(SwitchCaseHeadStatementSyntax),
				typeof(SwitchTypeIsHeadStatementSyntax),
				typeof(SwitchTypeAsHeadStatementSyntax),
				typeof(SwitchDefaultStatementSyntax),
				typeof(SwitchDefaultHeadStatementSyntax),
				typeof(TemplateDeclarationSyntax),
				typeof(TemplateSignatureSyntax),
				typeof(TemplateBodySyntax),
				typeof(TemplateContentLineSyntax),
				typeof(TemplateContentSyntax),
				typeof(TemplateOutputxSyntax),
				typeof(TemplateLineEndSyntax),
				typeof(TemplateStatementStartEndSyntax),
				typeof(TemplateStatementSyntax),
				typeof(TypeArgumentListSyntax),
				typeof(PredefinedTypeSyntax),
				typeof(TypeReferenceListSyntax),
				typeof(TypeReferenceSyntax),
				typeof(ArrayTypeSyntax),
				typeof(ArrayItemTypeSyntax),
				typeof(NullableTypeSyntax),
				typeof(NullableItemTypeSyntax),
				typeof(GenericTypeSyntax),
				typeof(SimpleTypeSyntax),
				typeof(VoidTypeSyntax),
				typeof(ReturnTypeSyntax),
				typeof(ExpressionListSyntax),
				typeof(VariableReferenceSyntax),
				typeof(RankSpecifiersSyntax),
				typeof(RankSpecifierSyntax),
				typeof(UnboundTypeNameSyntax),
				typeof(GenericDimensionItemSyntax),
				typeof(GenericDimensionSpecifierSyntax),
				typeof(ExplicitAnonymousFunctionSignatureSyntax),
				typeof(ImplicitAnonymousFunctionSignatureSyntax),
				typeof(SingleParamAnonymousFunctionSignatureSyntax),
				typeof(ExplicitParameterSyntax),
				typeof(ImplicitParameterSyntax),
				typeof(ThisExpressionSyntax),
				typeof(LiteralExpressionSyntax),
				typeof(TypeofVoidExpressionSyntax),
				typeof(TypeofUnboundTypeExpressionSyntax),
				typeof(TypeofTypeExpressionSyntax),
				typeof(DefaultValueExpressionSyntax),
				typeof(NewObjectOrCollectionWithConstructorExpressionSyntax),
				typeof(IdentifierExpressionSyntax),
				typeof(HasLoopExpressionSyntax),
				typeof(ParenthesizedExpressionSyntax),
				typeof(ElementAccessExpressionSyntax),
				typeof(FunctionCallExpressionSyntax),
				typeof(PredefinedTypeMemberAccessExpressionSyntax),
				typeof(MemberAccessExpressionSyntax),
				typeof(TypecastExpressionSyntax),
				typeof(UnaryExpressionSyntax),
				typeof(PostExpressionSyntax),
				typeof(MultiplicationExpressionSyntax),
				typeof(AdditionExpressionSyntax),
				typeof(RelationalExpressionSyntax),
				typeof(TypecheckExpressionSyntax),
				typeof(EqualityExpressionSyntax),
				typeof(BitwiseAndExpressionSyntax),
				typeof(BitwiseXorExpressionSyntax),
				typeof(BitwiseOrExpressionSyntax),
				typeof(LogicalAndExpressionSyntax),
				typeof(LogicalXorExpressionSyntax),
				typeof(LogicalOrExpressionSyntax),
				typeof(ConditionalExpressionSyntax),
				typeof(AssignmentExpressionSyntax),
				typeof(LambdaExpressionSyntax),
				typeof(QualifiedNameSyntax),
				typeof(IdentifierListSyntax),
				typeof(IdentifierSyntax),
				typeof(LiteralSyntax),
				typeof(NullLiteralSyntax),
				typeof(BooleanLiteralSyntax),
				typeof(NumberLiteralSyntax),
				typeof(IntegerLiteralxSyntax),
				typeof(DecimalLiteralxSyntax),
				typeof(ScientificLiteralxSyntax),
				typeof(DateOrTimeLiteralSyntax),
				typeof(DateTimeOffsetLiteralxSyntax),
				typeof(DateTimeLiteralxSyntax),
				typeof(DateLiteralxSyntax),
				typeof(TimeLiteralxSyntax),
				typeof(CharLiteralxSyntax),
				typeof(StringLiteralxSyntax),
				typeof(GuidLiteralxSyntax),
			};
		}
	}
}

