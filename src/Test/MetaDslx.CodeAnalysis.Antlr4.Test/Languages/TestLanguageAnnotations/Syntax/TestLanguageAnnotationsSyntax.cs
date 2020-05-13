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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax
{
    public abstract class TestLanguageAnnotationsSyntaxNode : LanguageSyntaxNode
    {
        protected TestLanguageAnnotationsSyntaxNode(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
            : base(green, syntaxTree, position)
        {
        }

        protected TestLanguageAnnotationsSyntaxNode(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
            : base(green, parent, position)
        {
        }

        public new TestLanguageAnnotationsLanguage Language => TestLanguageAnnotationsLanguage.Instance;
        protected override Language LanguageCore => this.Language;
        public new TestLanguageAnnotationsSyntaxKind Kind => (TestLanguageAnnotationsSyntaxKind)this.RawKind;
        protected override SyntaxKind KindCore => this.Kind;

        protected override SyntaxTree CreateSyntaxTreeForRoot()
        {
            return TestLanguageAnnotationsSyntaxTree.CreateWithoutClone(this);
        }

        public override TResult Accept<TArg, TResult>(SyntaxVisitor<TArg, TResult> visitor, TArg argument)
        {
            if (visitor is ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> typedVisitor) return this.Accept(typedVisitor, argument);
            else return visitor.DefaultVisit(this, argument);
        }

        public abstract TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument);

        public override TResult Accept<TResult>(SyntaxVisitor<TResult> visitor)
        {
            if (visitor is ITestLanguageAnnotationsSyntaxVisitor<TResult> typedVisitor) return this.Accept(typedVisitor);
            else return visitor.DefaultVisit(this);
        }

        public abstract TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor);

        public override void Accept(SyntaxVisitor visitor)
        {
            if (visitor is ITestLanguageAnnotationsSyntaxVisitor typedVisitor) this.Accept(typedVisitor);
            else visitor.DefaultVisit(this);
        }
        public abstract void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor);
    }

	
	public sealed class MainSyntax : TestLanguageAnnotationsSyntaxNode, ICompilationUnitSyntax
	{
	    private SyntaxNode test;
	
	    public MainSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public MainSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxList<TestSyntax> Test 
		{ 
			get
			{
				var red = this.GetRed(ref this.test, 0);
				if (red != null) return new SyntaxList<TestSyntax>(red);
				return default;
			} 
		}
	    public SyntaxToken EndOfFileToken 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.MainGreen)this.Green;
				var greenToken = green.EndOfFileToken;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(1), this.GetChildIndex(1));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.test, 0);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.test;
				default: return null;
	        }
	    }
	
	    public MainSyntax WithTest(SyntaxList<TestSyntax> test)
		{
			return this.Update(Test, this.EndOfFileToken);
		}
	
	    public MainSyntax AddTest(params TestSyntax[] test)
		{
			return this.WithTest(this.Test.AddRange(test));
		}
	
	    public MainSyntax WithEndOfFileToken(SyntaxToken eOF)
		{
			return this.Update(this.Test, EndOfFileToken);
		}
	
	    public MainSyntax Update(SyntaxList<TestSyntax> test, SyntaxToken eOF)
	    {
	        if (this.Test != test ||
				this.EndOfFileToken != eOF)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Main(test, eOF);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (MainSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitMain(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitMain(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitMain(this);
	    }
	}
	
	public sealed class TestSyntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Test01Syntax test01;
	    private Test02Syntax test02;
	    private Test03Syntax test03;
	    private Test04Syntax test04;
	    private Test05Syntax test05;
	    private Test06Syntax test06;
	    private Test07Syntax test07;
	    private Test08Syntax test08;
	    private Test09Syntax test09;
	    private Test10Syntax test10;
	    private Test11Syntax test11;
	
	    public TestSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public TestSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Test01Syntax Test01 
		{ 
			get { return this.GetRed(ref this.test01, 0); } 
		}
	    public Test02Syntax Test02 
		{ 
			get { return this.GetRed(ref this.test02, 1); } 
		}
	    public Test03Syntax Test03 
		{ 
			get { return this.GetRed(ref this.test03, 2); } 
		}
	    public Test04Syntax Test04 
		{ 
			get { return this.GetRed(ref this.test04, 3); } 
		}
	    public Test05Syntax Test05 
		{ 
			get { return this.GetRed(ref this.test05, 4); } 
		}
	    public Test06Syntax Test06 
		{ 
			get { return this.GetRed(ref this.test06, 5); } 
		}
	    public Test07Syntax Test07 
		{ 
			get { return this.GetRed(ref this.test07, 6); } 
		}
	    public Test08Syntax Test08 
		{ 
			get { return this.GetRed(ref this.test08, 7); } 
		}
	    public Test09Syntax Test09 
		{ 
			get { return this.GetRed(ref this.test09, 8); } 
		}
	    public Test10Syntax Test10 
		{ 
			get { return this.GetRed(ref this.test10, 9); } 
		}
	    public Test11Syntax Test11 
		{ 
			get { return this.GetRed(ref this.test11, 10); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.test01, 0);
				case 1: return this.GetRed(ref this.test02, 1);
				case 2: return this.GetRed(ref this.test03, 2);
				case 3: return this.GetRed(ref this.test04, 3);
				case 4: return this.GetRed(ref this.test05, 4);
				case 5: return this.GetRed(ref this.test06, 5);
				case 6: return this.GetRed(ref this.test07, 6);
				case 7: return this.GetRed(ref this.test08, 7);
				case 8: return this.GetRed(ref this.test09, 8);
				case 9: return this.GetRed(ref this.test10, 9);
				case 10: return this.GetRed(ref this.test11, 10);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.test01;
				case 1: return this.test02;
				case 2: return this.test03;
				case 3: return this.test04;
				case 4: return this.test05;
				case 5: return this.test06;
				case 6: return this.test07;
				case 7: return this.test08;
				case 8: return this.test09;
				case 9: return this.test10;
				case 10: return this.test11;
				default: return null;
	        }
	    }
	
	    public TestSyntax WithTest01(Test01Syntax test01)
		{
			return this.Update(test01);
		}
	
	    public TestSyntax WithTest02(Test02Syntax test02)
		{
			return this.Update(test02);
		}
	
	    public TestSyntax WithTest03(Test03Syntax test03)
		{
			return this.Update(test03);
		}
	
	    public TestSyntax WithTest04(Test04Syntax test04)
		{
			return this.Update(test04);
		}
	
	    public TestSyntax WithTest05(Test05Syntax test05)
		{
			return this.Update(test05);
		}
	
	    public TestSyntax WithTest06(Test06Syntax test06)
		{
			return this.Update(test06);
		}
	
	    public TestSyntax WithTest07(Test07Syntax test07)
		{
			return this.Update(test07);
		}
	
	    public TestSyntax WithTest08(Test08Syntax test08)
		{
			return this.Update(test08);
		}
	
	    public TestSyntax WithTest09(Test09Syntax test09)
		{
			return this.Update(test09);
		}
	
	    public TestSyntax WithTest10(Test10Syntax test10)
		{
			return this.Update(test10);
		}
	
	    public TestSyntax WithTest11(Test11Syntax test11)
		{
			return this.Update(test11);
		}
	
	    public TestSyntax Update(Test01Syntax test01)
	    {
	        if (this.Test01 != test01)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test01);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test02Syntax test02)
	    {
	        if (this.Test02 != test02)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test02);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test03Syntax test03)
	    {
	        if (this.Test03 != test03)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test03);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test04Syntax test04)
	    {
	        if (this.Test04 != test04)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test04);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test05Syntax test05)
	    {
	        if (this.Test05 != test05)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test05);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test06Syntax test06)
	    {
	        if (this.Test06 != test06)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test06);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test07Syntax test07)
	    {
	        if (this.Test07 != test07)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test07);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test08Syntax test08)
	    {
	        if (this.Test08 != test08)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test08);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test09Syntax test09)
	    {
	        if (this.Test09 != test09)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test09);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test10Syntax test10)
	    {
	        if (this.Test10 != test10)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test10);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public TestSyntax Update(Test11Syntax test11)
	    {
	        if (this.Test11 != test11)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test(test11);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (TestSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest(this);
	    }
	}
	
	public sealed class Test01Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration01Syntax namespaceDeclaration01;
	
	    public Test01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest01 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test01Green)this.Green;
				var greenToken = green.KTest01;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration01Syntax NamespaceDeclaration01 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration01, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration01, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration01;
				default: return null;
	        }
	    }
	
	    public Test01Syntax WithKTest01(SyntaxToken kTest01)
		{
			return this.Update(KTest01, this.NamespaceDeclaration01);
		}
	
	    public Test01Syntax WithNamespaceDeclaration01(NamespaceDeclaration01Syntax namespaceDeclaration01)
		{
			return this.Update(this.KTest01, NamespaceDeclaration01);
		}
	
	    public Test01Syntax Update(SyntaxToken kTest01, NamespaceDeclaration01Syntax namespaceDeclaration01)
	    {
	        if (this.KTest01 != kTest01 ||
				this.NamespaceDeclaration01 != namespaceDeclaration01)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test01(kTest01, namespaceDeclaration01);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test01Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest01(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest01(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest01(this);
	    }
	}
	
	public sealed class NamespaceDeclaration01Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody01Syntax namespaceBody01;
	
	    public NamespaceDeclaration01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration01Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody01Syntax NamespaceBody01 
		{ 
			get { return this.GetRed(ref this.namespaceBody01, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody01, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody01;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration01Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody01);
		}
	
	    public NamespaceDeclaration01Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody01);
		}
	
	    public NamespaceDeclaration01Syntax WithNamespaceBody01(NamespaceBody01Syntax namespaceBody01)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody01);
		}
	
	    public NamespaceDeclaration01Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody01Syntax namespaceBody01)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody01 != namespaceBody01)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration01(kNamespace, qualifiedName, namespaceBody01);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration01Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration01(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration01(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration01(this);
	    }
	}
	
	public sealed class NamespaceBody01Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration01;
	
	    public NamespaceBody01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody01Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration01Syntax> Declaration01 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration01, 1);
				if (red != null) return new SyntaxList<Declaration01Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody01Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration01, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration01;
				default: return null;
	        }
	    }
	
	    public NamespaceBody01Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration01, this.TCloseBrace);
		}
	
	    public NamespaceBody01Syntax WithDeclaration01(SyntaxList<Declaration01Syntax> declaration01)
		{
			return this.Update(this.TOpenBrace, Declaration01, this.TCloseBrace);
		}
	
	    public NamespaceBody01Syntax AddDeclaration01(params Declaration01Syntax[] declaration01)
		{
			return this.WithDeclaration01(this.Declaration01.AddRange(declaration01));
		}
	
	    public NamespaceBody01Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration01, TCloseBrace);
		}
	
	    public NamespaceBody01Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration01Syntax> declaration01, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration01 != declaration01 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody01(tOpenBrace, declaration01, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody01Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody01(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody01(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody01(this);
	    }
	}
	
	public sealed class Declaration01Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex01Syntax vertex01;
	    private Arrow01Syntax arrow01;
	
	    public Declaration01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex01Syntax Vertex01 
		{ 
			get { return this.GetRed(ref this.vertex01, 0); } 
		}
	    public Arrow01Syntax Arrow01 
		{ 
			get { return this.GetRed(ref this.arrow01, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex01, 0);
				case 1: return this.GetRed(ref this.arrow01, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex01;
				case 1: return this.arrow01;
				default: return null;
	        }
	    }
	
	    public Declaration01Syntax WithVertex01(Vertex01Syntax vertex01)
		{
			return this.Update(vertex01);
		}
	
	    public Declaration01Syntax WithArrow01(Arrow01Syntax arrow01)
		{
			return this.Update(arrow01);
		}
	
	    public Declaration01Syntax Update(Vertex01Syntax vertex01)
	    {
	        if (this.Vertex01 != vertex01)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration01(vertex01);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration01Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration01Syntax Update(Arrow01Syntax arrow01)
	    {
	        if (this.Arrow01 != arrow01)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration01(arrow01);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration01Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration01(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration01(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration01(this);
	    }
	}
	
	public sealed class Vertex01Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex01Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex01Green)this.Green;
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
	
	    public Vertex01Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex01Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex01Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex01Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex01(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex01Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex01(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex01(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex01(this);
	    }
	}
	
	public sealed class Arrow01Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifierSyntax source;
	    private QualifierSyntax target;
	
	    public Arrow01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow01Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow01Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow01Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow01Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source, 1);
				case 3: return this.GetRed(ref this.target, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source;
				case 3: return this.target;
				default: return null;
	        }
	    }
	
	    public Arrow01Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow01Syntax WithSource(QualifierSyntax source)
		{
			return this.Update(this.KArrow, Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow01Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source, TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow01Syntax WithTarget(QualifierSyntax target)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, Target, this.TSemicolon);
		}
	
	    public Arrow01Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, this.Target, TSemicolon);
		}
	
	    public Arrow01Syntax Update(SyntaxToken kArrow, QualifierSyntax source, SyntaxToken tArrow, QualifierSyntax target, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow01(kArrow, source, tArrow, target, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow01Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow01(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow01(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow01(this);
	    }
	}
	
	public sealed class Test02Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration02Syntax namespaceDeclaration02;
	
	    public Test02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest02 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test02Green)this.Green;
				var greenToken = green.KTest02;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration02Syntax NamespaceDeclaration02 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration02, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration02, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration02;
				default: return null;
	        }
	    }
	
	    public Test02Syntax WithKTest02(SyntaxToken kTest02)
		{
			return this.Update(KTest02, this.NamespaceDeclaration02);
		}
	
	    public Test02Syntax WithNamespaceDeclaration02(NamespaceDeclaration02Syntax namespaceDeclaration02)
		{
			return this.Update(this.KTest02, NamespaceDeclaration02);
		}
	
	    public Test02Syntax Update(SyntaxToken kTest02, NamespaceDeclaration02Syntax namespaceDeclaration02)
	    {
	        if (this.KTest02 != kTest02 ||
				this.NamespaceDeclaration02 != namespaceDeclaration02)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test02(kTest02, namespaceDeclaration02);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test02Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest02(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest02(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest02(this);
	    }
	}
	
	public sealed class NamespaceDeclaration02Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody02Syntax namespaceBody02;
	
	    public NamespaceDeclaration02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration02Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody02Syntax NamespaceBody02 
		{ 
			get { return this.GetRed(ref this.namespaceBody02, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody02, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody02;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration02Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody02);
		}
	
	    public NamespaceDeclaration02Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody02);
		}
	
	    public NamespaceDeclaration02Syntax WithNamespaceBody02(NamespaceBody02Syntax namespaceBody02)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody02);
		}
	
	    public NamespaceDeclaration02Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody02Syntax namespaceBody02)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody02 != namespaceBody02)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration02(kNamespace, qualifiedName, namespaceBody02);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration02Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration02(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration02(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration02(this);
	    }
	}
	
	public sealed class NamespaceBody02Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration02;
	
	    public NamespaceBody02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody02Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration02Syntax> Declaration02 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration02, 1);
				if (red != null) return new SyntaxList<Declaration02Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody02Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration02, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration02;
				default: return null;
	        }
	    }
	
	    public NamespaceBody02Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration02, this.TCloseBrace);
		}
	
	    public NamespaceBody02Syntax WithDeclaration02(SyntaxList<Declaration02Syntax> declaration02)
		{
			return this.Update(this.TOpenBrace, Declaration02, this.TCloseBrace);
		}
	
	    public NamespaceBody02Syntax AddDeclaration02(params Declaration02Syntax[] declaration02)
		{
			return this.WithDeclaration02(this.Declaration02.AddRange(declaration02));
		}
	
	    public NamespaceBody02Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration02, TCloseBrace);
		}
	
	    public NamespaceBody02Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration02Syntax> declaration02, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration02 != declaration02 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody02(tOpenBrace, declaration02, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody02Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody02(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody02(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody02(this);
	    }
	}
	
	public sealed class Declaration02Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex02Syntax vertex02;
	    private Arrow02Syntax arrow02;
	
	    public Declaration02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex02Syntax Vertex02 
		{ 
			get { return this.GetRed(ref this.vertex02, 0); } 
		}
	    public Arrow02Syntax Arrow02 
		{ 
			get { return this.GetRed(ref this.arrow02, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex02, 0);
				case 1: return this.GetRed(ref this.arrow02, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex02;
				case 1: return this.arrow02;
				default: return null;
	        }
	    }
	
	    public Declaration02Syntax WithVertex02(Vertex02Syntax vertex02)
		{
			return this.Update(vertex02);
		}
	
	    public Declaration02Syntax WithArrow02(Arrow02Syntax arrow02)
		{
			return this.Update(arrow02);
		}
	
	    public Declaration02Syntax Update(Vertex02Syntax vertex02)
	    {
	        if (this.Vertex02 != vertex02)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration02(vertex02);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration02Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration02Syntax Update(Arrow02Syntax arrow02)
	    {
	        if (this.Arrow02 != arrow02)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration02(arrow02);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration02Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration02(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration02(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration02(this);
	    }
	}
	
	public sealed class Vertex02Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex02Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex02Green)this.Green;
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
	
	    public Vertex02Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex02Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex02Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex02Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex02(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex02Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex02(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex02(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex02(this);
	    }
	}
	
	public sealed class Arrow02Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Source02Syntax source02;
	    private Target02Syntax target02;
	
	    public Arrow02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow02Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public Source02Syntax Source02 
		{ 
			get { return this.GetRed(ref this.source02, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow02Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public Target02Syntax Target02 
		{ 
			get { return this.GetRed(ref this.target02, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow02Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source02, 1);
				case 3: return this.GetRed(ref this.target02, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source02;
				case 3: return this.target02;
				default: return null;
	        }
	    }
	
	    public Arrow02Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source02, this.TArrow, this.Target02, this.TSemicolon);
		}
	
	    public Arrow02Syntax WithSource02(Source02Syntax source02)
		{
			return this.Update(this.KArrow, Source02, this.TArrow, this.Target02, this.TSemicolon);
		}
	
	    public Arrow02Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source02, TArrow, this.Target02, this.TSemicolon);
		}
	
	    public Arrow02Syntax WithTarget02(Target02Syntax target02)
		{
			return this.Update(this.KArrow, this.Source02, this.TArrow, Target02, this.TSemicolon);
		}
	
	    public Arrow02Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source02, this.TArrow, this.Target02, TSemicolon);
		}
	
	    public Arrow02Syntax Update(SyntaxToken kArrow, Source02Syntax source02, SyntaxToken tArrow, Target02Syntax target02, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source02 != source02 ||
				this.TArrow != tArrow ||
				this.Target02 != target02 ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow02(kArrow, source02, tArrow, target02, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow02Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow02(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow02(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow02(this);
	    }
	}
	
	public sealed class Source02Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public Source02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Source02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	
	    public Source02Syntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public Source02Syntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Source02(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Source02Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSource02(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSource02(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitSource02(this);
	    }
	}
	
	public sealed class Target02Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public Target02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Target02Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	
	    public Target02Syntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public Target02Syntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Target02(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Target02Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTarget02(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTarget02(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTarget02(this);
	    }
	}
	
	public sealed class Test03Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration03Syntax namespaceDeclaration03;
	
	    public Test03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest03 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test03Green)this.Green;
				var greenToken = green.KTest03;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration03Syntax NamespaceDeclaration03 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration03, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration03, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration03;
				default: return null;
	        }
	    }
	
	    public Test03Syntax WithKTest03(SyntaxToken kTest03)
		{
			return this.Update(KTest03, this.NamespaceDeclaration03);
		}
	
	    public Test03Syntax WithNamespaceDeclaration03(NamespaceDeclaration03Syntax namespaceDeclaration03)
		{
			return this.Update(this.KTest03, NamespaceDeclaration03);
		}
	
	    public Test03Syntax Update(SyntaxToken kTest03, NamespaceDeclaration03Syntax namespaceDeclaration03)
	    {
	        if (this.KTest03 != kTest03 ||
				this.NamespaceDeclaration03 != namespaceDeclaration03)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test03(kTest03, namespaceDeclaration03);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test03Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest03(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest03(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest03(this);
	    }
	}
	
	public sealed class NamespaceDeclaration03Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody03Syntax namespaceBody03;
	
	    public NamespaceDeclaration03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration03Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody03Syntax NamespaceBody03 
		{ 
			get { return this.GetRed(ref this.namespaceBody03, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody03, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody03;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration03Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody03);
		}
	
	    public NamespaceDeclaration03Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody03);
		}
	
	    public NamespaceDeclaration03Syntax WithNamespaceBody03(NamespaceBody03Syntax namespaceBody03)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody03);
		}
	
	    public NamespaceDeclaration03Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody03Syntax namespaceBody03)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody03 != namespaceBody03)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration03(kNamespace, qualifiedName, namespaceBody03);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration03Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration03(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration03(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration03(this);
	    }
	}
	
	public sealed class NamespaceBody03Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration03;
	
	    public NamespaceBody03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody03Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration03Syntax> Declaration03 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration03, 1);
				if (red != null) return new SyntaxList<Declaration03Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody03Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration03, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration03;
				default: return null;
	        }
	    }
	
	    public NamespaceBody03Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration03, this.TCloseBrace);
		}
	
	    public NamespaceBody03Syntax WithDeclaration03(SyntaxList<Declaration03Syntax> declaration03)
		{
			return this.Update(this.TOpenBrace, Declaration03, this.TCloseBrace);
		}
	
	    public NamespaceBody03Syntax AddDeclaration03(params Declaration03Syntax[] declaration03)
		{
			return this.WithDeclaration03(this.Declaration03.AddRange(declaration03));
		}
	
	    public NamespaceBody03Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration03, TCloseBrace);
		}
	
	    public NamespaceBody03Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration03Syntax> declaration03, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration03 != declaration03 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody03(tOpenBrace, declaration03, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody03Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody03(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody03(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody03(this);
	    }
	}
	
	public sealed class Declaration03Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex03Syntax vertex03;
	    private Arrow03Syntax arrow03;
	
	    public Declaration03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex03Syntax Vertex03 
		{ 
			get { return this.GetRed(ref this.vertex03, 0); } 
		}
	    public Arrow03Syntax Arrow03 
		{ 
			get { return this.GetRed(ref this.arrow03, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex03, 0);
				case 1: return this.GetRed(ref this.arrow03, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex03;
				case 1: return this.arrow03;
				default: return null;
	        }
	    }
	
	    public Declaration03Syntax WithVertex03(Vertex03Syntax vertex03)
		{
			return this.Update(vertex03);
		}
	
	    public Declaration03Syntax WithArrow03(Arrow03Syntax arrow03)
		{
			return this.Update(arrow03);
		}
	
	    public Declaration03Syntax Update(Vertex03Syntax vertex03)
	    {
	        if (this.Vertex03 != vertex03)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration03(vertex03);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration03Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration03Syntax Update(Arrow03Syntax arrow03)
	    {
	        if (this.Arrow03 != arrow03)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration03(arrow03);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration03Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration03(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration03(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration03(this);
	    }
	}
	
	public sealed class Vertex03Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex03Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex03Green)this.Green;
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
	
	    public Vertex03Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex03Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex03Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex03Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex03(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex03Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex03(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex03(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex03(this);
	    }
	}
	
	public sealed class Arrow03Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Source03Syntax source03;
	    private Target03Syntax target03;
	
	    public Arrow03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow03Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public Source03Syntax Source03 
		{ 
			get { return this.GetRed(ref this.source03, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow03Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public Target03Syntax Target03 
		{ 
			get { return this.GetRed(ref this.target03, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow03Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source03, 1);
				case 3: return this.GetRed(ref this.target03, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source03;
				case 3: return this.target03;
				default: return null;
	        }
	    }
	
	    public Arrow03Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source03, this.TArrow, this.Target03, this.TSemicolon);
		}
	
	    public Arrow03Syntax WithSource03(Source03Syntax source03)
		{
			return this.Update(this.KArrow, Source03, this.TArrow, this.Target03, this.TSemicolon);
		}
	
	    public Arrow03Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source03, TArrow, this.Target03, this.TSemicolon);
		}
	
	    public Arrow03Syntax WithTarget03(Target03Syntax target03)
		{
			return this.Update(this.KArrow, this.Source03, this.TArrow, Target03, this.TSemicolon);
		}
	
	    public Arrow03Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source03, this.TArrow, this.Target03, TSemicolon);
		}
	
	    public Arrow03Syntax Update(SyntaxToken kArrow, Source03Syntax source03, SyntaxToken tArrow, Target03Syntax target03, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source03 != source03 ||
				this.TArrow != tArrow ||
				this.Target03 != target03 ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow03(kArrow, source03, tArrow, target03, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow03Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow03(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow03(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow03(this);
	    }
	}
	
	public sealed class Source03Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public Source03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Source03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	
	    public Source03Syntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public Source03Syntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Source03(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Source03Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSource03(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSource03(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitSource03(this);
	    }
	}
	
	public sealed class Target03Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public Target03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Target03Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	
	    public Target03Syntax WithQualifier(QualifierSyntax qualifier)
		{
			return this.Update(Qualifier);
		}
	
	    public Target03Syntax Update(QualifierSyntax qualifier)
	    {
	        if (this.Qualifier != qualifier)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Target03(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Target03Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTarget03(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTarget03(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTarget03(this);
	    }
	}
	
	public sealed class Test04Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration04Syntax namespaceDeclaration04;
	
	    public Test04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest04 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test04Green)this.Green;
				var greenToken = green.KTest04;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration04Syntax NamespaceDeclaration04 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration04, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration04, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration04;
				default: return null;
	        }
	    }
	
	    public Test04Syntax WithKTest04(SyntaxToken kTest04)
		{
			return this.Update(KTest04, this.NamespaceDeclaration04);
		}
	
	    public Test04Syntax WithNamespaceDeclaration04(NamespaceDeclaration04Syntax namespaceDeclaration04)
		{
			return this.Update(this.KTest04, NamespaceDeclaration04);
		}
	
	    public Test04Syntax Update(SyntaxToken kTest04, NamespaceDeclaration04Syntax namespaceDeclaration04)
	    {
	        if (this.KTest04 != kTest04 ||
				this.NamespaceDeclaration04 != namespaceDeclaration04)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test04(kTest04, namespaceDeclaration04);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test04Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest04(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest04(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest04(this);
	    }
	}
	
	public sealed class NamespaceDeclaration04Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody04Syntax namespaceBody04;
	
	    public NamespaceDeclaration04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration04Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody04Syntax NamespaceBody04 
		{ 
			get { return this.GetRed(ref this.namespaceBody04, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody04, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody04;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration04Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody04);
		}
	
	    public NamespaceDeclaration04Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody04);
		}
	
	    public NamespaceDeclaration04Syntax WithNamespaceBody04(NamespaceBody04Syntax namespaceBody04)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody04);
		}
	
	    public NamespaceDeclaration04Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody04Syntax namespaceBody04)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody04 != namespaceBody04)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration04(kNamespace, qualifiedName, namespaceBody04);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration04Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration04(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration04(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration04(this);
	    }
	}
	
	public sealed class NamespaceBody04Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration04;
	
	    public NamespaceBody04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody04Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration04Syntax> Declaration04 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration04, 1);
				if (red != null) return new SyntaxList<Declaration04Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody04Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration04, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration04;
				default: return null;
	        }
	    }
	
	    public NamespaceBody04Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration04, this.TCloseBrace);
		}
	
	    public NamespaceBody04Syntax WithDeclaration04(SyntaxList<Declaration04Syntax> declaration04)
		{
			return this.Update(this.TOpenBrace, Declaration04, this.TCloseBrace);
		}
	
	    public NamespaceBody04Syntax AddDeclaration04(params Declaration04Syntax[] declaration04)
		{
			return this.WithDeclaration04(this.Declaration04.AddRange(declaration04));
		}
	
	    public NamespaceBody04Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration04, TCloseBrace);
		}
	
	    public NamespaceBody04Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration04Syntax> declaration04, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration04 != declaration04 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody04(tOpenBrace, declaration04, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody04Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody04(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody04(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody04(this);
	    }
	}
	
	public sealed class Declaration04Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex04Syntax vertex04;
	    private Arrow04Syntax arrow04;
	
	    public Declaration04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex04Syntax Vertex04 
		{ 
			get { return this.GetRed(ref this.vertex04, 0); } 
		}
	    public Arrow04Syntax Arrow04 
		{ 
			get { return this.GetRed(ref this.arrow04, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex04, 0);
				case 1: return this.GetRed(ref this.arrow04, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex04;
				case 1: return this.arrow04;
				default: return null;
	        }
	    }
	
	    public Declaration04Syntax WithVertex04(Vertex04Syntax vertex04)
		{
			return this.Update(vertex04);
		}
	
	    public Declaration04Syntax WithArrow04(Arrow04Syntax arrow04)
		{
			return this.Update(arrow04);
		}
	
	    public Declaration04Syntax Update(Vertex04Syntax vertex04)
	    {
	        if (this.Vertex04 != vertex04)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration04(vertex04);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration04Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration04Syntax Update(Arrow04Syntax arrow04)
	    {
	        if (this.Arrow04 != arrow04)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration04(arrow04);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration04Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration04(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration04(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration04(this);
	    }
	}
	
	public sealed class Vertex04Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex04Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex04Green)this.Green;
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
	
	    public Vertex04Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex04Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex04Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex04Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex04(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex04Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex04(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex04(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex04(this);
	    }
	}
	
	public sealed class Arrow04Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifierSyntax source;
	    private QualifierSyntax target;
	
	    public Arrow04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow04Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow04Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow04Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow04Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source, 1);
				case 3: return this.GetRed(ref this.target, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source;
				case 3: return this.target;
				default: return null;
	        }
	    }
	
	    public Arrow04Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow04Syntax WithSource(QualifierSyntax source)
		{
			return this.Update(this.KArrow, Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow04Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source, TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow04Syntax WithTarget(QualifierSyntax target)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, Target, this.TSemicolon);
		}
	
	    public Arrow04Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, this.Target, TSemicolon);
		}
	
	    public Arrow04Syntax Update(SyntaxToken kArrow, QualifierSyntax source, SyntaxToken tArrow, QualifierSyntax target, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow04(kArrow, source, tArrow, target, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow04Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow04(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow04(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow04(this);
	    }
	}
	
	public sealed class Test05Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration05Syntax namespaceDeclaration05;
	
	    public Test05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest05 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test05Green)this.Green;
				var greenToken = green.KTest05;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration05Syntax NamespaceDeclaration05 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration05, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration05, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration05;
				default: return null;
	        }
	    }
	
	    public Test05Syntax WithKTest05(SyntaxToken kTest05)
		{
			return this.Update(KTest05, this.NamespaceDeclaration05);
		}
	
	    public Test05Syntax WithNamespaceDeclaration05(NamespaceDeclaration05Syntax namespaceDeclaration05)
		{
			return this.Update(this.KTest05, NamespaceDeclaration05);
		}
	
	    public Test05Syntax Update(SyntaxToken kTest05, NamespaceDeclaration05Syntax namespaceDeclaration05)
	    {
	        if (this.KTest05 != kTest05 ||
				this.NamespaceDeclaration05 != namespaceDeclaration05)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test05(kTest05, namespaceDeclaration05);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test05Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest05(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest05(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest05(this);
	    }
	}
	
	public sealed class NamespaceDeclaration05Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody05Syntax namespaceBody05;
	
	    public NamespaceDeclaration05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration05Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody05Syntax NamespaceBody05 
		{ 
			get { return this.GetRed(ref this.namespaceBody05, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody05, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody05;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration05Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody05);
		}
	
	    public NamespaceDeclaration05Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody05);
		}
	
	    public NamespaceDeclaration05Syntax WithNamespaceBody05(NamespaceBody05Syntax namespaceBody05)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody05);
		}
	
	    public NamespaceDeclaration05Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody05Syntax namespaceBody05)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody05 != namespaceBody05)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration05(kNamespace, qualifiedName, namespaceBody05);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration05Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration05(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration05(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration05(this);
	    }
	}
	
	public sealed class NamespaceBody05Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration05;
	
	    public NamespaceBody05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody05Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration05Syntax> Declaration05 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration05, 1);
				if (red != null) return new SyntaxList<Declaration05Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody05Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration05, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration05;
				default: return null;
	        }
	    }
	
	    public NamespaceBody05Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration05, this.TCloseBrace);
		}
	
	    public NamespaceBody05Syntax WithDeclaration05(SyntaxList<Declaration05Syntax> declaration05)
		{
			return this.Update(this.TOpenBrace, Declaration05, this.TCloseBrace);
		}
	
	    public NamespaceBody05Syntax AddDeclaration05(params Declaration05Syntax[] declaration05)
		{
			return this.WithDeclaration05(this.Declaration05.AddRange(declaration05));
		}
	
	    public NamespaceBody05Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration05, TCloseBrace);
		}
	
	    public NamespaceBody05Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration05Syntax> declaration05, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration05 != declaration05 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody05(tOpenBrace, declaration05, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody05Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody05(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody05(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody05(this);
	    }
	}
	
	public sealed class Declaration05Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex05Syntax vertex05;
	    private Arrow05Syntax arrow05;
	
	    public Declaration05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex05Syntax Vertex05 
		{ 
			get { return this.GetRed(ref this.vertex05, 0); } 
		}
	    public Arrow05Syntax Arrow05 
		{ 
			get { return this.GetRed(ref this.arrow05, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex05, 0);
				case 1: return this.GetRed(ref this.arrow05, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex05;
				case 1: return this.arrow05;
				default: return null;
	        }
	    }
	
	    public Declaration05Syntax WithVertex05(Vertex05Syntax vertex05)
		{
			return this.Update(vertex05);
		}
	
	    public Declaration05Syntax WithArrow05(Arrow05Syntax arrow05)
		{
			return this.Update(arrow05);
		}
	
	    public Declaration05Syntax Update(Vertex05Syntax vertex05)
	    {
	        if (this.Vertex05 != vertex05)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration05(vertex05);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration05Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration05Syntax Update(Arrow05Syntax arrow05)
	    {
	        if (this.Arrow05 != arrow05)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration05(arrow05);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration05Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration05(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration05(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration05(this);
	    }
	}
	
	public sealed class Vertex05Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex05Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex05Green)this.Green;
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
	
	    public Vertex05Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex05Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex05Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex05Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex05(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex05Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex05(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex05(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex05(this);
	    }
	}
	
	public sealed class Arrow05Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifierSyntax source;
	    private QualifierSyntax target;
	
	    public Arrow05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow05Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow05Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifierSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow05Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifierSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow05Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source, 1);
				case 3: return this.GetRed(ref this.target, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source;
				case 3: return this.target;
				default: return null;
	        }
	    }
	
	    public Arrow05Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow05Syntax WithSource(QualifierSyntax source)
		{
			return this.Update(this.KArrow, Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow05Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source, TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow05Syntax WithTarget(QualifierSyntax target)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, Target, this.TSemicolon);
		}
	
	    public Arrow05Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, this.Target, TSemicolon);
		}
	
	    public Arrow05Syntax Update(SyntaxToken kArrow, QualifierSyntax source, SyntaxToken tArrow, QualifierSyntax target, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow05(kArrow, source, tArrow, target, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow05Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow05(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow05(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow05(this);
	    }
	}
	
	public sealed class Test06Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration06Syntax namespaceDeclaration06;
	
	    public Test06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest06 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test06Green)this.Green;
				var greenToken = green.KTest06;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration06Syntax NamespaceDeclaration06 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration06, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration06, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration06;
				default: return null;
	        }
	    }
	
	    public Test06Syntax WithKTest06(SyntaxToken kTest06)
		{
			return this.Update(KTest06, this.NamespaceDeclaration06);
		}
	
	    public Test06Syntax WithNamespaceDeclaration06(NamespaceDeclaration06Syntax namespaceDeclaration06)
		{
			return this.Update(this.KTest06, NamespaceDeclaration06);
		}
	
	    public Test06Syntax Update(SyntaxToken kTest06, NamespaceDeclaration06Syntax namespaceDeclaration06)
	    {
	        if (this.KTest06 != kTest06 ||
				this.NamespaceDeclaration06 != namespaceDeclaration06)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test06(kTest06, namespaceDeclaration06);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test06Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest06(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest06(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest06(this);
	    }
	}
	
	public sealed class NamespaceDeclaration06Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody06Syntax namespaceBody06;
	
	    public NamespaceDeclaration06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration06Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody06Syntax NamespaceBody06 
		{ 
			get { return this.GetRed(ref this.namespaceBody06, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody06, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody06;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration06Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody06);
		}
	
	    public NamespaceDeclaration06Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody06);
		}
	
	    public NamespaceDeclaration06Syntax WithNamespaceBody06(NamespaceBody06Syntax namespaceBody06)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody06);
		}
	
	    public NamespaceDeclaration06Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody06Syntax namespaceBody06)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody06 != namespaceBody06)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration06(kNamespace, qualifiedName, namespaceBody06);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration06Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration06(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration06(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration06(this);
	    }
	}
	
	public sealed class NamespaceBody06Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration06;
	
	    public NamespaceBody06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody06Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration06Syntax> Declaration06 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration06, 1);
				if (red != null) return new SyntaxList<Declaration06Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody06Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration06, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration06;
				default: return null;
	        }
	    }
	
	    public NamespaceBody06Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration06, this.TCloseBrace);
		}
	
	    public NamespaceBody06Syntax WithDeclaration06(SyntaxList<Declaration06Syntax> declaration06)
		{
			return this.Update(this.TOpenBrace, Declaration06, this.TCloseBrace);
		}
	
	    public NamespaceBody06Syntax AddDeclaration06(params Declaration06Syntax[] declaration06)
		{
			return this.WithDeclaration06(this.Declaration06.AddRange(declaration06));
		}
	
	    public NamespaceBody06Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration06, TCloseBrace);
		}
	
	    public NamespaceBody06Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration06Syntax> declaration06, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration06 != declaration06 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody06(tOpenBrace, declaration06, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody06Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody06(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody06(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody06(this);
	    }
	}
	
	public sealed class Declaration06Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex06Syntax vertex06;
	    private Arrow06Syntax arrow06;
	
	    public Declaration06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex06Syntax Vertex06 
		{ 
			get { return this.GetRed(ref this.vertex06, 0); } 
		}
	    public Arrow06Syntax Arrow06 
		{ 
			get { return this.GetRed(ref this.arrow06, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex06, 0);
				case 1: return this.GetRed(ref this.arrow06, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex06;
				case 1: return this.arrow06;
				default: return null;
	        }
	    }
	
	    public Declaration06Syntax WithVertex06(Vertex06Syntax vertex06)
		{
			return this.Update(vertex06);
		}
	
	    public Declaration06Syntax WithArrow06(Arrow06Syntax arrow06)
		{
			return this.Update(arrow06);
		}
	
	    public Declaration06Syntax Update(Vertex06Syntax vertex06)
	    {
	        if (this.Vertex06 != vertex06)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration06(vertex06);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration06Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration06Syntax Update(Arrow06Syntax arrow06)
	    {
	        if (this.Arrow06 != arrow06)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration06(arrow06);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration06Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration06(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration06(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration06(this);
	    }
	}
	
	public sealed class Vertex06Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex06Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex06Green)this.Green;
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
	
	    public Vertex06Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex06Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex06Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex06Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex06(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex06Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex06(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex06(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex06(this);
	    }
	}
	
	public sealed class Arrow06Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax source;
	    private NameSyntax target;
	
	    public Arrow06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow06Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow06Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow06Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public NameSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow06Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source, 1);
				case 3: return this.GetRed(ref this.target, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source;
				case 3: return this.target;
				default: return null;
	        }
	    }
	
	    public Arrow06Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow06Syntax WithSource(NameSyntax source)
		{
			return this.Update(this.KArrow, Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow06Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source, TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow06Syntax WithTarget(NameSyntax target)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, Target, this.TSemicolon);
		}
	
	    public Arrow06Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, this.Target, TSemicolon);
		}
	
	    public Arrow06Syntax Update(SyntaxToken kArrow, NameSyntax source, SyntaxToken tArrow, NameSyntax target, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow06(kArrow, source, tArrow, target, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow06Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow06(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow06(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow06(this);
	    }
	}
	
	public sealed class Test07Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration07Syntax namespaceDeclaration07;
	
	    public Test07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest07 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test07Green)this.Green;
				var greenToken = green.KTest07;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration07Syntax NamespaceDeclaration07 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration07, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration07, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration07;
				default: return null;
	        }
	    }
	
	    public Test07Syntax WithKTest07(SyntaxToken kTest07)
		{
			return this.Update(KTest07, this.NamespaceDeclaration07);
		}
	
	    public Test07Syntax WithNamespaceDeclaration07(NamespaceDeclaration07Syntax namespaceDeclaration07)
		{
			return this.Update(this.KTest07, NamespaceDeclaration07);
		}
	
	    public Test07Syntax Update(SyntaxToken kTest07, NamespaceDeclaration07Syntax namespaceDeclaration07)
	    {
	        if (this.KTest07 != kTest07 ||
				this.NamespaceDeclaration07 != namespaceDeclaration07)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test07(kTest07, namespaceDeclaration07);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test07Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest07(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest07(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest07(this);
	    }
	}
	
	public sealed class NamespaceDeclaration07Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody07Syntax namespaceBody07;
	
	    public NamespaceDeclaration07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration07Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody07Syntax NamespaceBody07 
		{ 
			get { return this.GetRed(ref this.namespaceBody07, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody07, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody07;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration07Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody07);
		}
	
	    public NamespaceDeclaration07Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody07);
		}
	
	    public NamespaceDeclaration07Syntax WithNamespaceBody07(NamespaceBody07Syntax namespaceBody07)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody07);
		}
	
	    public NamespaceDeclaration07Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody07Syntax namespaceBody07)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody07 != namespaceBody07)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration07(kNamespace, qualifiedName, namespaceBody07);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration07Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration07(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration07(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration07(this);
	    }
	}
	
	public sealed class NamespaceBody07Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration07;
	
	    public NamespaceBody07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody07Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration07Syntax> Declaration07 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration07, 1);
				if (red != null) return new SyntaxList<Declaration07Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody07Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration07, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration07;
				default: return null;
	        }
	    }
	
	    public NamespaceBody07Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration07, this.TCloseBrace);
		}
	
	    public NamespaceBody07Syntax WithDeclaration07(SyntaxList<Declaration07Syntax> declaration07)
		{
			return this.Update(this.TOpenBrace, Declaration07, this.TCloseBrace);
		}
	
	    public NamespaceBody07Syntax AddDeclaration07(params Declaration07Syntax[] declaration07)
		{
			return this.WithDeclaration07(this.Declaration07.AddRange(declaration07));
		}
	
	    public NamespaceBody07Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration07, TCloseBrace);
		}
	
	    public NamespaceBody07Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration07Syntax> declaration07, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration07 != declaration07 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody07(tOpenBrace, declaration07, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody07Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody07(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody07(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody07(this);
	    }
	}
	
	public sealed class Declaration07Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex07Syntax vertex07;
	    private Arrow07Syntax arrow07;
	
	    public Declaration07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex07Syntax Vertex07 
		{ 
			get { return this.GetRed(ref this.vertex07, 0); } 
		}
	    public Arrow07Syntax Arrow07 
		{ 
			get { return this.GetRed(ref this.arrow07, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex07, 0);
				case 1: return this.GetRed(ref this.arrow07, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex07;
				case 1: return this.arrow07;
				default: return null;
	        }
	    }
	
	    public Declaration07Syntax WithVertex07(Vertex07Syntax vertex07)
		{
			return this.Update(vertex07);
		}
	
	    public Declaration07Syntax WithArrow07(Arrow07Syntax arrow07)
		{
			return this.Update(arrow07);
		}
	
	    public Declaration07Syntax Update(Vertex07Syntax vertex07)
	    {
	        if (this.Vertex07 != vertex07)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration07(vertex07);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration07Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration07Syntax Update(Arrow07Syntax arrow07)
	    {
	        if (this.Arrow07 != arrow07)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration07(arrow07);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration07Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration07(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration07(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration07(this);
	    }
	}
	
	public sealed class Vertex07Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex07Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex07Green)this.Green;
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
	
	    public Vertex07Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex07Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex07Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex07Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex07(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex07Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex07(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex07(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex07(this);
	    }
	}
	
	public sealed class Arrow07Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Source07Syntax source07;
	    private Target07Syntax target07;
	
	    public Arrow07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow07Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public Source07Syntax Source07 
		{ 
			get { return this.GetRed(ref this.source07, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow07Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public Target07Syntax Target07 
		{ 
			get { return this.GetRed(ref this.target07, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow07Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source07, 1);
				case 3: return this.GetRed(ref this.target07, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source07;
				case 3: return this.target07;
				default: return null;
	        }
	    }
	
	    public Arrow07Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source07, this.TArrow, this.Target07, this.TSemicolon);
		}
	
	    public Arrow07Syntax WithSource07(Source07Syntax source07)
		{
			return this.Update(this.KArrow, Source07, this.TArrow, this.Target07, this.TSemicolon);
		}
	
	    public Arrow07Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source07, TArrow, this.Target07, this.TSemicolon);
		}
	
	    public Arrow07Syntax WithTarget07(Target07Syntax target07)
		{
			return this.Update(this.KArrow, this.Source07, this.TArrow, Target07, this.TSemicolon);
		}
	
	    public Arrow07Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source07, this.TArrow, this.Target07, TSemicolon);
		}
	
	    public Arrow07Syntax Update(SyntaxToken kArrow, Source07Syntax source07, SyntaxToken tArrow, Target07Syntax target07, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source07 != source07 ||
				this.TArrow != tArrow ||
				this.Target07 != target07 ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow07(kArrow, source07, tArrow, target07, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow07Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow07(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow07(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow07(this);
	    }
	}
	
	public sealed class Source07Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Source07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Source07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	
	    public Source07Syntax WithName(NameSyntax name)
		{
			return this.Update(Name);
		}
	
	    public Source07Syntax Update(NameSyntax name)
	    {
	        if (this.Name != name)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Source07(name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Source07Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSource07(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSource07(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitSource07(this);
	    }
	}
	
	public sealed class Target07Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Target07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Target07Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	
	    public Target07Syntax WithName(NameSyntax name)
		{
			return this.Update(Name);
		}
	
	    public Target07Syntax Update(NameSyntax name)
	    {
	        if (this.Name != name)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Target07(name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Target07Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTarget07(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTarget07(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTarget07(this);
	    }
	}
	
	public sealed class Test08Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration08Syntax namespaceDeclaration08;
	
	    public Test08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest08 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test08Green)this.Green;
				var greenToken = green.KTest08;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration08Syntax NamespaceDeclaration08 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration08, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration08, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration08;
				default: return null;
	        }
	    }
	
	    public Test08Syntax WithKTest08(SyntaxToken kTest08)
		{
			return this.Update(KTest08, this.NamespaceDeclaration08);
		}
	
	    public Test08Syntax WithNamespaceDeclaration08(NamespaceDeclaration08Syntax namespaceDeclaration08)
		{
			return this.Update(this.KTest08, NamespaceDeclaration08);
		}
	
	    public Test08Syntax Update(SyntaxToken kTest08, NamespaceDeclaration08Syntax namespaceDeclaration08)
	    {
	        if (this.KTest08 != kTest08 ||
				this.NamespaceDeclaration08 != namespaceDeclaration08)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test08(kTest08, namespaceDeclaration08);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test08Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest08(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest08(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest08(this);
	    }
	}
	
	public sealed class NamespaceDeclaration08Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody08Syntax namespaceBody08;
	
	    public NamespaceDeclaration08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration08Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody08Syntax NamespaceBody08 
		{ 
			get { return this.GetRed(ref this.namespaceBody08, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody08, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody08;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration08Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody08);
		}
	
	    public NamespaceDeclaration08Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody08);
		}
	
	    public NamespaceDeclaration08Syntax WithNamespaceBody08(NamespaceBody08Syntax namespaceBody08)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody08);
		}
	
	    public NamespaceDeclaration08Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody08Syntax namespaceBody08)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody08 != namespaceBody08)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration08(kNamespace, qualifiedName, namespaceBody08);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration08Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration08(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration08(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration08(this);
	    }
	}
	
	public sealed class NamespaceBody08Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration08;
	
	    public NamespaceBody08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody08Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration08Syntax> Declaration08 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration08, 1);
				if (red != null) return new SyntaxList<Declaration08Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody08Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration08, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration08;
				default: return null;
	        }
	    }
	
	    public NamespaceBody08Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration08, this.TCloseBrace);
		}
	
	    public NamespaceBody08Syntax WithDeclaration08(SyntaxList<Declaration08Syntax> declaration08)
		{
			return this.Update(this.TOpenBrace, Declaration08, this.TCloseBrace);
		}
	
	    public NamespaceBody08Syntax AddDeclaration08(params Declaration08Syntax[] declaration08)
		{
			return this.WithDeclaration08(this.Declaration08.AddRange(declaration08));
		}
	
	    public NamespaceBody08Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration08, TCloseBrace);
		}
	
	    public NamespaceBody08Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration08Syntax> declaration08, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration08 != declaration08 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody08(tOpenBrace, declaration08, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody08Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody08(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody08(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody08(this);
	    }
	}
	
	public sealed class Declaration08Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex08Syntax vertex08;
	    private Arrow08Syntax arrow08;
	
	    public Declaration08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex08Syntax Vertex08 
		{ 
			get { return this.GetRed(ref this.vertex08, 0); } 
		}
	    public Arrow08Syntax Arrow08 
		{ 
			get { return this.GetRed(ref this.arrow08, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex08, 0);
				case 1: return this.GetRed(ref this.arrow08, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex08;
				case 1: return this.arrow08;
				default: return null;
	        }
	    }
	
	    public Declaration08Syntax WithVertex08(Vertex08Syntax vertex08)
		{
			return this.Update(vertex08);
		}
	
	    public Declaration08Syntax WithArrow08(Arrow08Syntax arrow08)
		{
			return this.Update(arrow08);
		}
	
	    public Declaration08Syntax Update(Vertex08Syntax vertex08)
	    {
	        if (this.Vertex08 != vertex08)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration08(vertex08);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration08Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration08Syntax Update(Arrow08Syntax arrow08)
	    {
	        if (this.Arrow08 != arrow08)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration08(arrow08);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration08Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration08(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration08(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration08(this);
	    }
	}
	
	public sealed class Vertex08Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex08Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex08Green)this.Green;
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
	
	    public Vertex08Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex08Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex08Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex08Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex08(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex08Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex08(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex08(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex08(this);
	    }
	}
	
	public sealed class Arrow08Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Source08Syntax source08;
	    private Target08Syntax target08;
	
	    public Arrow08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow08Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public Source08Syntax Source08 
		{ 
			get { return this.GetRed(ref this.source08, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow08Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public Target08Syntax Target08 
		{ 
			get { return this.GetRed(ref this.target08, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow08Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source08, 1);
				case 3: return this.GetRed(ref this.target08, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source08;
				case 3: return this.target08;
				default: return null;
	        }
	    }
	
	    public Arrow08Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source08, this.TArrow, this.Target08, this.TSemicolon);
		}
	
	    public Arrow08Syntax WithSource08(Source08Syntax source08)
		{
			return this.Update(this.KArrow, Source08, this.TArrow, this.Target08, this.TSemicolon);
		}
	
	    public Arrow08Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source08, TArrow, this.Target08, this.TSemicolon);
		}
	
	    public Arrow08Syntax WithTarget08(Target08Syntax target08)
		{
			return this.Update(this.KArrow, this.Source08, this.TArrow, Target08, this.TSemicolon);
		}
	
	    public Arrow08Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source08, this.TArrow, this.Target08, TSemicolon);
		}
	
	    public Arrow08Syntax Update(SyntaxToken kArrow, Source08Syntax source08, SyntaxToken tArrow, Target08Syntax target08, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source08 != source08 ||
				this.TArrow != tArrow ||
				this.Target08 != target08 ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow08(kArrow, source08, tArrow, target08, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow08Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow08(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow08(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow08(this);
	    }
	}
	
	public sealed class Source08Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Source08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Source08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	
	    public Source08Syntax WithName(NameSyntax name)
		{
			return this.Update(Name);
		}
	
	    public Source08Syntax Update(NameSyntax name)
	    {
	        if (this.Name != name)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Source08(name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Source08Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitSource08(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitSource08(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitSource08(this);
	    }
	}
	
	public sealed class Target08Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Target08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Target08Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	
	    public Target08Syntax WithName(NameSyntax name)
		{
			return this.Update(Name);
		}
	
	    public Target08Syntax Update(NameSyntax name)
	    {
	        if (this.Name != name)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Target08(name);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Target08Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTarget08(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTarget08(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTarget08(this);
	    }
	}
	
	public sealed class Test09Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration09Syntax namespaceDeclaration09;
	
	    public Test09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest09 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test09Green)this.Green;
				var greenToken = green.KTest09;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration09Syntax NamespaceDeclaration09 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration09, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration09, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration09;
				default: return null;
	        }
	    }
	
	    public Test09Syntax WithKTest09(SyntaxToken kTest09)
		{
			return this.Update(KTest09, this.NamespaceDeclaration09);
		}
	
	    public Test09Syntax WithNamespaceDeclaration09(NamespaceDeclaration09Syntax namespaceDeclaration09)
		{
			return this.Update(this.KTest09, NamespaceDeclaration09);
		}
	
	    public Test09Syntax Update(SyntaxToken kTest09, NamespaceDeclaration09Syntax namespaceDeclaration09)
	    {
	        if (this.KTest09 != kTest09 ||
				this.NamespaceDeclaration09 != namespaceDeclaration09)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test09(kTest09, namespaceDeclaration09);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test09Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest09(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest09(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest09(this);
	    }
	}
	
	public sealed class NamespaceDeclaration09Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody09Syntax namespaceBody09;
	
	    public NamespaceDeclaration09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration09Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody09Syntax NamespaceBody09 
		{ 
			get { return this.GetRed(ref this.namespaceBody09, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody09, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody09;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration09Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody09);
		}
	
	    public NamespaceDeclaration09Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody09);
		}
	
	    public NamespaceDeclaration09Syntax WithNamespaceBody09(NamespaceBody09Syntax namespaceBody09)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody09);
		}
	
	    public NamespaceDeclaration09Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody09Syntax namespaceBody09)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody09 != namespaceBody09)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration09(kNamespace, qualifiedName, namespaceBody09);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration09Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration09(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration09(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration09(this);
	    }
	}
	
	public sealed class NamespaceBody09Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration09;
	
	    public NamespaceBody09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody09Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration09Syntax> Declaration09 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration09, 1);
				if (red != null) return new SyntaxList<Declaration09Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody09Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration09, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration09;
				default: return null;
	        }
	    }
	
	    public NamespaceBody09Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration09, this.TCloseBrace);
		}
	
	    public NamespaceBody09Syntax WithDeclaration09(SyntaxList<Declaration09Syntax> declaration09)
		{
			return this.Update(this.TOpenBrace, Declaration09, this.TCloseBrace);
		}
	
	    public NamespaceBody09Syntax AddDeclaration09(params Declaration09Syntax[] declaration09)
		{
			return this.WithDeclaration09(this.Declaration09.AddRange(declaration09));
		}
	
	    public NamespaceBody09Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration09, TCloseBrace);
		}
	
	    public NamespaceBody09Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration09Syntax> declaration09, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration09 != declaration09 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody09(tOpenBrace, declaration09, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody09Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody09(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody09(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody09(this);
	    }
	}
	
	public sealed class Declaration09Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex09Syntax vertex09;
	    private Arrow09Syntax arrow09;
	
	    public Declaration09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex09Syntax Vertex09 
		{ 
			get { return this.GetRed(ref this.vertex09, 0); } 
		}
	    public Arrow09Syntax Arrow09 
		{ 
			get { return this.GetRed(ref this.arrow09, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex09, 0);
				case 1: return this.GetRed(ref this.arrow09, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex09;
				case 1: return this.arrow09;
				default: return null;
	        }
	    }
	
	    public Declaration09Syntax WithVertex09(Vertex09Syntax vertex09)
		{
			return this.Update(vertex09);
		}
	
	    public Declaration09Syntax WithArrow09(Arrow09Syntax arrow09)
		{
			return this.Update(arrow09);
		}
	
	    public Declaration09Syntax Update(Vertex09Syntax vertex09)
	    {
	        if (this.Vertex09 != vertex09)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration09(vertex09);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration09Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration09Syntax Update(Arrow09Syntax arrow09)
	    {
	        if (this.Arrow09 != arrow09)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration09(arrow09);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration09Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration09(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration09(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration09(this);
	    }
	}
	
	public sealed class Vertex09Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex09Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex09Green)this.Green;
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
	
	    public Vertex09Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex09Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex09Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex09Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex09(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex09Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex09(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex09(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex09(this);
	    }
	}
	
	public sealed class Arrow09Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax source;
	    private NameSyntax target;
	
	    public Arrow09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow09Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow09Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow09Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public NameSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow09Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source, 1);
				case 3: return this.GetRed(ref this.target, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source;
				case 3: return this.target;
				default: return null;
	        }
	    }
	
	    public Arrow09Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow09Syntax WithSource(NameSyntax source)
		{
			return this.Update(this.KArrow, Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow09Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source, TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow09Syntax WithTarget(NameSyntax target)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, Target, this.TSemicolon);
		}
	
	    public Arrow09Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, this.Target, TSemicolon);
		}
	
	    public Arrow09Syntax Update(SyntaxToken kArrow, NameSyntax source, SyntaxToken tArrow, NameSyntax target, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow09(kArrow, source, tArrow, target, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow09Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow09(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow09(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow09(this);
	    }
	}
	
	public sealed class Test10Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NamespaceDeclaration10Syntax namespaceDeclaration10;
	
	    public Test10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest10 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test10Green)this.Green;
				var greenToken = green.KTest10;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NamespaceDeclaration10Syntax NamespaceDeclaration10 
		{ 
			get { return this.GetRed(ref this.namespaceDeclaration10, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration10, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration10;
				default: return null;
	        }
	    }
	
	    public Test10Syntax WithKTest10(SyntaxToken kTest10)
		{
			return this.Update(KTest10, this.NamespaceDeclaration10);
		}
	
	    public Test10Syntax WithNamespaceDeclaration10(NamespaceDeclaration10Syntax namespaceDeclaration10)
		{
			return this.Update(this.KTest10, NamespaceDeclaration10);
		}
	
	    public Test10Syntax Update(SyntaxToken kTest10, NamespaceDeclaration10Syntax namespaceDeclaration10)
	    {
	        if (this.KTest10 != kTest10 ||
				this.NamespaceDeclaration10 != namespaceDeclaration10)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test10(kTest10, namespaceDeclaration10);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test10Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest10(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest10(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest10(this);
	    }
	}
	
	public sealed class NamespaceDeclaration10Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody10Syntax namespaceBody10;
	
	    public NamespaceDeclaration10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration10Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody10Syntax NamespaceBody10 
		{ 
			get { return this.GetRed(ref this.namespaceBody10, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody10, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody10;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration10Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody10);
		}
	
	    public NamespaceDeclaration10Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody10);
		}
	
	    public NamespaceDeclaration10Syntax WithNamespaceBody10(NamespaceBody10Syntax namespaceBody10)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody10);
		}
	
	    public NamespaceDeclaration10Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody10Syntax namespaceBody10)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody10 != namespaceBody10)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration10(kNamespace, qualifiedName, namespaceBody10);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration10Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration10(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration10(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration10(this);
	    }
	}
	
	public sealed class NamespaceBody10Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration10;
	
	    public NamespaceBody10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody10Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration10Syntax> Declaration10 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration10, 1);
				if (red != null) return new SyntaxList<Declaration10Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody10Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration10, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration10;
				default: return null;
	        }
	    }
	
	    public NamespaceBody10Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration10, this.TCloseBrace);
		}
	
	    public NamespaceBody10Syntax WithDeclaration10(SyntaxList<Declaration10Syntax> declaration10)
		{
			return this.Update(this.TOpenBrace, Declaration10, this.TCloseBrace);
		}
	
	    public NamespaceBody10Syntax AddDeclaration10(params Declaration10Syntax[] declaration10)
		{
			return this.WithDeclaration10(this.Declaration10.AddRange(declaration10));
		}
	
	    public NamespaceBody10Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration10, TCloseBrace);
		}
	
	    public NamespaceBody10Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration10Syntax> declaration10, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration10 != declaration10 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody10(tOpenBrace, declaration10, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody10Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody10(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody10(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody10(this);
	    }
	}
	
	public sealed class Declaration10Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex10Syntax vertex10;
	    private Arrow10Syntax arrow10;
	
	    public Declaration10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex10Syntax Vertex10 
		{ 
			get { return this.GetRed(ref this.vertex10, 0); } 
		}
	    public Arrow10Syntax Arrow10 
		{ 
			get { return this.GetRed(ref this.arrow10, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex10, 0);
				case 1: return this.GetRed(ref this.arrow10, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex10;
				case 1: return this.arrow10;
				default: return null;
	        }
	    }
	
	    public Declaration10Syntax WithVertex10(Vertex10Syntax vertex10)
		{
			return this.Update(vertex10);
		}
	
	    public Declaration10Syntax WithArrow10(Arrow10Syntax arrow10)
		{
			return this.Update(arrow10);
		}
	
	    public Declaration10Syntax Update(Vertex10Syntax vertex10)
	    {
	        if (this.Vertex10 != vertex10)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration10(vertex10);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration10Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration10Syntax Update(Arrow10Syntax arrow10)
	    {
	        if (this.Arrow10 != arrow10)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration10(arrow10);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration10Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration10(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration10(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration10(this);
	    }
	}
	
	public sealed class Vertex10Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex10Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex10Green)this.Green;
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
	
	    public Vertex10Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex10Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex10Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex10Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex10(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex10Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex10(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex10(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex10(this);
	    }
	}
	
	public sealed class Arrow10Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax source;
	    private NameSyntax target;
	
	    public Arrow10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow10Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow10Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public NameSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow10Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public NameSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow10Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source, 1);
				case 3: return this.GetRed(ref this.target, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source;
				case 3: return this.target;
				default: return null;
	        }
	    }
	
	    public Arrow10Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow10Syntax WithSource(NameSyntax source)
		{
			return this.Update(this.KArrow, Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow10Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source, TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow10Syntax WithTarget(NameSyntax target)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, Target, this.TSemicolon);
		}
	
	    public Arrow10Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, this.Target, TSemicolon);
		}
	
	    public Arrow10Syntax Update(SyntaxToken kArrow, NameSyntax source, SyntaxToken tArrow, NameSyntax target, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow10(kArrow, source, tArrow, target, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow10Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow10(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow10(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow10(this);
	    }
	}
	
	public sealed class Test11Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode namespaceDeclaration11;
	
	    public Test11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Test11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KTest11 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Test11Green)this.Green;
				var greenToken = green.KTest11;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<NamespaceDeclaration11Syntax> NamespaceDeclaration11 
		{ 
			get
			{
				var red = this.GetRed(ref this.namespaceDeclaration11, 1);
				if (red != null) return new SyntaxList<NamespaceDeclaration11Syntax>(red);
				return default;
			} 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.namespaceDeclaration11, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.namespaceDeclaration11;
				default: return null;
	        }
	    }
	
	    public Test11Syntax WithKTest11(SyntaxToken kTest11)
		{
			return this.Update(KTest11, this.NamespaceDeclaration11);
		}
	
	    public Test11Syntax WithNamespaceDeclaration11(SyntaxList<NamespaceDeclaration11Syntax> namespaceDeclaration11)
		{
			return this.Update(this.KTest11, NamespaceDeclaration11);
		}
	
	    public Test11Syntax AddNamespaceDeclaration11(params NamespaceDeclaration11Syntax[] namespaceDeclaration11)
		{
			return this.WithNamespaceDeclaration11(this.NamespaceDeclaration11.AddRange(namespaceDeclaration11));
		}
	
	    public Test11Syntax Update(SyntaxToken kTest11, SyntaxList<NamespaceDeclaration11Syntax> namespaceDeclaration11)
	    {
	        if (this.KTest11 != kTest11 ||
				this.NamespaceDeclaration11 != namespaceDeclaration11)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Test11(kTest11, namespaceDeclaration11);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Test11Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitTest11(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitTest11(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitTest11(this);
	    }
	}
	
	public sealed class NamespaceDeclaration11Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax qualifiedName;
	    private NamespaceBody11Syntax namespaceBody11;
	
	    public NamespaceDeclaration11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceDeclaration11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNamespace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceDeclaration11Green)this.Green;
				var greenToken = green.KNamespace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax QualifiedName 
		{ 
			get { return this.GetRed(ref this.qualifiedName, 1); } 
		}
	    public NamespaceBody11Syntax NamespaceBody11 
		{ 
			get { return this.GetRed(ref this.namespaceBody11, 2); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.qualifiedName, 1);
				case 2: return this.GetRed(ref this.namespaceBody11, 2);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.qualifiedName;
				case 2: return this.namespaceBody11;
				default: return null;
	        }
	    }
	
	    public NamespaceDeclaration11Syntax WithKNamespace(SyntaxToken kNamespace)
		{
			return this.Update(KNamespace, this.QualifiedName, this.NamespaceBody11);
		}
	
	    public NamespaceDeclaration11Syntax WithQualifiedName(QualifiedNameSyntax qualifiedName)
		{
			return this.Update(this.KNamespace, QualifiedName, this.NamespaceBody11);
		}
	
	    public NamespaceDeclaration11Syntax WithNamespaceBody11(NamespaceBody11Syntax namespaceBody11)
		{
			return this.Update(this.KNamespace, this.QualifiedName, NamespaceBody11);
		}
	
	    public NamespaceDeclaration11Syntax Update(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody11Syntax namespaceBody11)
	    {
	        if (this.KNamespace != kNamespace ||
				this.QualifiedName != qualifiedName ||
				this.NamespaceBody11 != namespaceBody11)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceDeclaration11(kNamespace, qualifiedName, namespaceBody11);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceDeclaration11Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceDeclaration11(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceDeclaration11(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceDeclaration11(this);
	    }
	}
	
	public sealed class NamespaceBody11Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode declaration11;
	
	    public NamespaceBody11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NamespaceBody11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken TOpenBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody11Green)this.Green;
				var greenToken = green.TOpenBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public SyntaxList<Declaration11Syntax> Declaration11 
		{ 
			get
			{
				var red = this.GetRed(ref this.declaration11, 1);
				if (red != null) return new SyntaxList<Declaration11Syntax>(red);
				return default;
			} 
		}
	    public SyntaxToken TCloseBrace 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NamespaceBody11Green)this.Green;
				var greenToken = green.TCloseBrace;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.declaration11, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.declaration11;
				default: return null;
	        }
	    }
	
	    public NamespaceBody11Syntax WithTOpenBrace(SyntaxToken tOpenBrace)
		{
			return this.Update(TOpenBrace, this.Declaration11, this.TCloseBrace);
		}
	
	    public NamespaceBody11Syntax WithDeclaration11(SyntaxList<Declaration11Syntax> declaration11)
		{
			return this.Update(this.TOpenBrace, Declaration11, this.TCloseBrace);
		}
	
	    public NamespaceBody11Syntax AddDeclaration11(params Declaration11Syntax[] declaration11)
		{
			return this.WithDeclaration11(this.Declaration11.AddRange(declaration11));
		}
	
	    public NamespaceBody11Syntax WithTCloseBrace(SyntaxToken tCloseBrace)
		{
			return this.Update(this.TOpenBrace, this.Declaration11, TCloseBrace);
		}
	
	    public NamespaceBody11Syntax Update(SyntaxToken tOpenBrace, SyntaxList<Declaration11Syntax> declaration11, SyntaxToken tCloseBrace)
	    {
	        if (this.TOpenBrace != tOpenBrace ||
				this.Declaration11 != declaration11 ||
				this.TCloseBrace != tCloseBrace)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NamespaceBody11(tOpenBrace, declaration11, tCloseBrace);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NamespaceBody11Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNamespaceBody11(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespaceBody11(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNamespaceBody11(this);
	    }
	}
	
	public sealed class Declaration11Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private Vertex11Syntax vertex11;
	    private Arrow11Syntax arrow11;
	
	    public Declaration11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Declaration11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public Vertex11Syntax Vertex11 
		{ 
			get { return this.GetRed(ref this.vertex11, 0); } 
		}
	    public Arrow11Syntax Arrow11 
		{ 
			get { return this.GetRed(ref this.arrow11, 1); } 
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.GetRed(ref this.vertex11, 0);
				case 1: return this.GetRed(ref this.arrow11, 1);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 0: return this.vertex11;
				case 1: return this.arrow11;
				default: return null;
	        }
	    }
	
	    public Declaration11Syntax WithVertex11(Vertex11Syntax vertex11)
		{
			return this.Update(vertex11);
		}
	
	    public Declaration11Syntax WithArrow11(Arrow11Syntax arrow11)
		{
			return this.Update(arrow11);
		}
	
	    public Declaration11Syntax Update(Vertex11Syntax vertex11)
	    {
	        if (this.Vertex11 != vertex11)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration11(vertex11);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration11Syntax)newNode;
	        }
	        return this;
	    }
	
	    public Declaration11Syntax Update(Arrow11Syntax arrow11)
	    {
	        if (this.Arrow11 != arrow11)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Declaration11(arrow11);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Declaration11Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDeclaration11(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDeclaration11(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDeclaration11(this);
	    }
	}
	
	public sealed class Vertex11Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NameSyntax name;
	
	    public Vertex11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Vertex11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KVertex 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex11Green)this.Green;
				var greenToken = green.KVertex;
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
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Vertex11Green)this.Green;
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
	
	    public Vertex11Syntax WithKVertex(SyntaxToken kVertex)
		{
			return this.Update(KVertex, this.Name, this.TSemicolon);
		}
	
	    public Vertex11Syntax WithName(NameSyntax name)
		{
			return this.Update(this.KVertex, Name, this.TSemicolon);
		}
	
	    public Vertex11Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KVertex, this.Name, TSemicolon);
		}
	
	    public Vertex11Syntax Update(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
	    {
	        if (this.KVertex != kVertex ||
				this.Name != name ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Vertex11(kVertex, name, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Vertex11Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitVertex11(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitVertex11(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitVertex11(this);
	    }
	}
	
	public sealed class Arrow11Syntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifiedNameSyntax source;
	    private QualifiedNameSyntax target;
	
	    public Arrow11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public Arrow11Syntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow11Green)this.Green;
				var greenToken = green.KArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(0), this.GetChildIndex(0));
			}
		}
	    public QualifiedNameSyntax Source 
		{ 
			get { return this.GetRed(ref this.source, 1); } 
		}
	    public SyntaxToken TArrow 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow11Green)this.Green;
				var greenToken = green.TArrow;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(2), this.GetChildIndex(2));
			}
		}
	    public QualifiedNameSyntax Target 
		{ 
			get { return this.GetRed(ref this.target, 3); } 
		}
	    public SyntaxToken TSemicolon 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.Arrow11Green)this.Green;
				var greenToken = green.TSemicolon;
				return new SyntaxToken(this, greenToken, this.GetChildPosition(4), this.GetChildIndex(4));
			}
		}
	
	    public override SyntaxNode GetNodeSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.GetRed(ref this.source, 1);
				case 3: return this.GetRed(ref this.target, 3);
				default: return null;
	        }
	    }
	
	    public override SyntaxNode GetCachedSlot(int index)
	    {
	        switch (index)
	        {
				case 1: return this.source;
				case 3: return this.target;
				default: return null;
	        }
	    }
	
	    public Arrow11Syntax WithKArrow(SyntaxToken kArrow)
		{
			return this.Update(KArrow, this.Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow11Syntax WithSource(QualifiedNameSyntax source)
		{
			return this.Update(this.KArrow, Source, this.TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow11Syntax WithTArrow(SyntaxToken tArrow)
		{
			return this.Update(this.KArrow, this.Source, TArrow, this.Target, this.TSemicolon);
		}
	
	    public Arrow11Syntax WithTarget(QualifiedNameSyntax target)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, Target, this.TSemicolon);
		}
	
	    public Arrow11Syntax WithTSemicolon(SyntaxToken tSemicolon)
		{
			return this.Update(this.KArrow, this.Source, this.TArrow, this.Target, TSemicolon);
		}
	
	    public Arrow11Syntax Update(SyntaxToken kArrow, QualifiedNameSyntax source, SyntaxToken tArrow, QualifiedNameSyntax target, SyntaxToken tSemicolon)
	    {
	        if (this.KArrow != kArrow ||
				this.Source != source ||
				this.TArrow != tArrow ||
				this.Target != target ||
				this.TSemicolon != tSemicolon)
	        {
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Arrow11(kArrow, source, tArrow, target, tSemicolon);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (Arrow11Syntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitArrow11(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitArrow11(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitArrow11(this);
	    }
	}
	
	public sealed class NameSyntax : TestLanguageAnnotationsSyntaxNode
	{
	    private IdentifierSyntax identifier;
	
	    public NameSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NameSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Name(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitName(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitName(this);
	    }
	}
	
	public sealed class QualifiedNameSyntax : TestLanguageAnnotationsSyntaxNode
	{
	    private QualifierSyntax qualifier;
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifiedNameSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.QualifiedName(qualifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifiedNameSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifiedName(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifiedName(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifiedName(this);
	    }
	}
	
	public sealed class QualifierSyntax : TestLanguageAnnotationsSyntaxNode
	{
	    private SyntaxNode identifier;
	
	    public QualifierSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public QualifierSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Qualifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (QualifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitQualifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitQualifier(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitQualifier(this);
	    }
	}
	
	public sealed class IdentifierSyntax : TestLanguageAnnotationsSyntaxNode
	{
	
	    public IdentifierSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IdentifierSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken Identifier 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.IdentifierGreen)this.Green;
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Identifier(identifier);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IdentifierSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIdentifier(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIdentifier(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitIdentifier(this);
	    }
	}
	
	public sealed class LiteralSyntax : TestLanguageAnnotationsSyntaxNode
	{
	    private NullLiteralSyntax nullLiteral;
	    private BooleanLiteralSyntax booleanLiteral;
	    private IntegerLiteralSyntax integerLiteral;
	    private DecimalLiteralSyntax decimalLiteral;
	    private ScientificLiteralSyntax scientificLiteral;
	    private StringLiteralSyntax stringLiteral;
	
	    public LiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public LiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Literal(nullLiteral);
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Literal(booleanLiteral);
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Literal(integerLiteral);
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Literal(decimalLiteral);
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Literal(scientificLiteral);
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.Literal(stringLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (LiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitLiteral(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitLiteral(this);
	    }
	}
	
	public sealed class NullLiteralSyntax : TestLanguageAnnotationsSyntaxNode
	{
	
	    public NullLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public NullLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken KNull 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.NullLiteralGreen)this.Green;
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.NullLiteral(kNull);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (NullLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitNullLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitNullLiteral(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitNullLiteral(this);
	    }
	}
	
	public sealed class BooleanLiteralSyntax : TestLanguageAnnotationsSyntaxNode
	{
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public BooleanLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken BooleanLiteral 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.BooleanLiteralGreen)this.Green;
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.BooleanLiteral(booleanLiteral);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (BooleanLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitBooleanLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitBooleanLiteral(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitBooleanLiteral(this);
	    }
	}
	
	public sealed class IntegerLiteralSyntax : TestLanguageAnnotationsSyntaxNode
	{
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public IntegerLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LInteger 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.IntegerLiteralGreen)this.Green;
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.IntegerLiteral(lInteger);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (IntegerLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitIntegerLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitIntegerLiteral(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitIntegerLiteral(this);
	    }
	}
	
	public sealed class DecimalLiteralSyntax : TestLanguageAnnotationsSyntaxNode
	{
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public DecimalLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LDecimal 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.DecimalLiteralGreen)this.Green;
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.DecimalLiteral(lDecimal);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (DecimalLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitDecimalLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitDecimalLiteral(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitDecimalLiteral(this);
	    }
	}
	
	public sealed class ScientificLiteralSyntax : TestLanguageAnnotationsSyntaxNode
	{
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public ScientificLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LScientific 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.ScientificLiteralGreen)this.Green;
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.ScientificLiteral(lScientific);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (ScientificLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitScientificLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitScientificLiteral(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitScientificLiteral(this);
	    }
	}
	
	public sealed class StringLiteralSyntax : TestLanguageAnnotationsSyntaxNode
	{
	
	    public StringLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxTree syntaxTree, int position)
	        : base(green, syntaxTree, position)
	    {
	    }
	
	    public StringLiteralSyntax(InternalSyntaxNode green, TestLanguageAnnotationsSyntaxNode parent, int position)
	        : base(green, parent, position)
	    {
	    }
	
	    public SyntaxToken LRegularString 
		{ 
			get 
			{ 
				var green = (global::MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax.StringLiteralGreen)this.Green;
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
	            var newNode = TestLanguageAnnotationsLanguage.Instance.SyntaxFactory.StringLiteral(lRegularString);
	            var annotations = this.GetAnnotations();
	            if (annotations != null && annotations.Length > 0)
	               newNode = newNode.WithAnnotations(annotations);
				return (StringLiteralSyntax)newNode;
	        }
	        return this;
	    }
	
	    public override TResult Accept<TArg, TResult>(ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> visitor, TArg argument)
	    {
	        return visitor.VisitStringLiteral(this, argument);
	    }
	
	    public override TResult Accept<TResult>(ITestLanguageAnnotationsSyntaxVisitor<TResult> visitor)
	    {
	        return visitor.VisitStringLiteral(this);
	    }
	
	    public override void Accept(ITestLanguageAnnotationsSyntaxVisitor visitor)
	    {
	        visitor.VisitStringLiteral(this);
	    }
	}
}

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations
{
    using System.Threading;
    using Microsoft.CodeAnalysis.Text;
	using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax;
    using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax;

	public interface ITestLanguageAnnotationsSyntaxVisitor
	{
		
		void VisitMain(MainSyntax node);
		
		void VisitTest(TestSyntax node);
		
		void VisitTest01(Test01Syntax node);
		
		void VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node);
		
		void VisitNamespaceBody01(NamespaceBody01Syntax node);
		
		void VisitDeclaration01(Declaration01Syntax node);
		
		void VisitVertex01(Vertex01Syntax node);
		
		void VisitArrow01(Arrow01Syntax node);
		
		void VisitTest02(Test02Syntax node);
		
		void VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node);
		
		void VisitNamespaceBody02(NamespaceBody02Syntax node);
		
		void VisitDeclaration02(Declaration02Syntax node);
		
		void VisitVertex02(Vertex02Syntax node);
		
		void VisitArrow02(Arrow02Syntax node);
		
		void VisitSource02(Source02Syntax node);
		
		void VisitTarget02(Target02Syntax node);
		
		void VisitTest03(Test03Syntax node);
		
		void VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node);
		
		void VisitNamespaceBody03(NamespaceBody03Syntax node);
		
		void VisitDeclaration03(Declaration03Syntax node);
		
		void VisitVertex03(Vertex03Syntax node);
		
		void VisitArrow03(Arrow03Syntax node);
		
		void VisitSource03(Source03Syntax node);
		
		void VisitTarget03(Target03Syntax node);
		
		void VisitTest04(Test04Syntax node);
		
		void VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node);
		
		void VisitNamespaceBody04(NamespaceBody04Syntax node);
		
		void VisitDeclaration04(Declaration04Syntax node);
		
		void VisitVertex04(Vertex04Syntax node);
		
		void VisitArrow04(Arrow04Syntax node);
		
		void VisitTest05(Test05Syntax node);
		
		void VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node);
		
		void VisitNamespaceBody05(NamespaceBody05Syntax node);
		
		void VisitDeclaration05(Declaration05Syntax node);
		
		void VisitVertex05(Vertex05Syntax node);
		
		void VisitArrow05(Arrow05Syntax node);
		
		void VisitTest06(Test06Syntax node);
		
		void VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node);
		
		void VisitNamespaceBody06(NamespaceBody06Syntax node);
		
		void VisitDeclaration06(Declaration06Syntax node);
		
		void VisitVertex06(Vertex06Syntax node);
		
		void VisitArrow06(Arrow06Syntax node);
		
		void VisitTest07(Test07Syntax node);
		
		void VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node);
		
		void VisitNamespaceBody07(NamespaceBody07Syntax node);
		
		void VisitDeclaration07(Declaration07Syntax node);
		
		void VisitVertex07(Vertex07Syntax node);
		
		void VisitArrow07(Arrow07Syntax node);
		
		void VisitSource07(Source07Syntax node);
		
		void VisitTarget07(Target07Syntax node);
		
		void VisitTest08(Test08Syntax node);
		
		void VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node);
		
		void VisitNamespaceBody08(NamespaceBody08Syntax node);
		
		void VisitDeclaration08(Declaration08Syntax node);
		
		void VisitVertex08(Vertex08Syntax node);
		
		void VisitArrow08(Arrow08Syntax node);
		
		void VisitSource08(Source08Syntax node);
		
		void VisitTarget08(Target08Syntax node);
		
		void VisitTest09(Test09Syntax node);
		
		void VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node);
		
		void VisitNamespaceBody09(NamespaceBody09Syntax node);
		
		void VisitDeclaration09(Declaration09Syntax node);
		
		void VisitVertex09(Vertex09Syntax node);
		
		void VisitArrow09(Arrow09Syntax node);
		
		void VisitTest10(Test10Syntax node);
		
		void VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node);
		
		void VisitNamespaceBody10(NamespaceBody10Syntax node);
		
		void VisitDeclaration10(Declaration10Syntax node);
		
		void VisitVertex10(Vertex10Syntax node);
		
		void VisitArrow10(Arrow10Syntax node);
		
		void VisitTest11(Test11Syntax node);
		
		void VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node);
		
		void VisitNamespaceBody11(NamespaceBody11Syntax node);
		
		void VisitDeclaration11(Declaration11Syntax node);
		
		void VisitVertex11(Vertex11Syntax node);
		
		void VisitArrow11(Arrow11Syntax node);
		
		void VisitName(NameSyntax node);
		
		void VisitQualifiedName(QualifiedNameSyntax node);
		
		void VisitQualifier(QualifierSyntax node);
		
		void VisitIdentifier(IdentifierSyntax node);
		
		void VisitLiteral(LiteralSyntax node);
		
		void VisitNullLiteral(NullLiteralSyntax node);
		
		void VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		void VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		void VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		void VisitScientificLiteral(ScientificLiteralSyntax node);
		
		void VisitStringLiteral(StringLiteralSyntax node);
	}
	
	public class TestLanguageAnnotationsSyntaxVisitor : SyntaxVisitor, ITestLanguageAnnotationsSyntaxVisitor
	{
		
		public virtual void VisitMain(MainSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest(TestSyntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest01(Test01Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody01(NamespaceBody01Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration01(Declaration01Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex01(Vertex01Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow01(Arrow01Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest02(Test02Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody02(NamespaceBody02Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration02(Declaration02Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex02(Vertex02Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow02(Arrow02Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSource02(Source02Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTarget02(Target02Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest03(Test03Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody03(NamespaceBody03Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration03(Declaration03Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex03(Vertex03Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow03(Arrow03Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSource03(Source03Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTarget03(Target03Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest04(Test04Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody04(NamespaceBody04Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration04(Declaration04Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex04(Vertex04Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow04(Arrow04Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest05(Test05Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody05(NamespaceBody05Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration05(Declaration05Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex05(Vertex05Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow05(Arrow05Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest06(Test06Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody06(NamespaceBody06Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration06(Declaration06Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex06(Vertex06Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow06(Arrow06Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest07(Test07Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody07(NamespaceBody07Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration07(Declaration07Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex07(Vertex07Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow07(Arrow07Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSource07(Source07Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTarget07(Target07Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest08(Test08Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody08(NamespaceBody08Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration08(Declaration08Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex08(Vertex08Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow08(Arrow08Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitSource08(Source08Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTarget08(Target08Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest09(Test09Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody09(NamespaceBody09Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration09(Declaration09Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex09(Vertex09Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow09(Arrow09Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest10(Test10Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody10(NamespaceBody10Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration10(Declaration10Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex10(Vertex10Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow10(Arrow10Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitTest11(Test11Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitNamespaceBody11(NamespaceBody11Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitDeclaration11(Declaration11Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitVertex11(Vertex11Syntax node)
		{
		    this.DefaultVisit(node);
		}
		
		public virtual void VisitArrow11(Arrow11Syntax node)
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

	public interface ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult> 
	{
		
		TResult VisitMain(MainSyntax node, TArg argument);
		
		TResult VisitTest(TestSyntax node, TArg argument);
		
		TResult VisitTest01(Test01Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node, TArg argument);
		
		TResult VisitNamespaceBody01(NamespaceBody01Syntax node, TArg argument);
		
		TResult VisitDeclaration01(Declaration01Syntax node, TArg argument);
		
		TResult VisitVertex01(Vertex01Syntax node, TArg argument);
		
		TResult VisitArrow01(Arrow01Syntax node, TArg argument);
		
		TResult VisitTest02(Test02Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node, TArg argument);
		
		TResult VisitNamespaceBody02(NamespaceBody02Syntax node, TArg argument);
		
		TResult VisitDeclaration02(Declaration02Syntax node, TArg argument);
		
		TResult VisitVertex02(Vertex02Syntax node, TArg argument);
		
		TResult VisitArrow02(Arrow02Syntax node, TArg argument);
		
		TResult VisitSource02(Source02Syntax node, TArg argument);
		
		TResult VisitTarget02(Target02Syntax node, TArg argument);
		
		TResult VisitTest03(Test03Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node, TArg argument);
		
		TResult VisitNamespaceBody03(NamespaceBody03Syntax node, TArg argument);
		
		TResult VisitDeclaration03(Declaration03Syntax node, TArg argument);
		
		TResult VisitVertex03(Vertex03Syntax node, TArg argument);
		
		TResult VisitArrow03(Arrow03Syntax node, TArg argument);
		
		TResult VisitSource03(Source03Syntax node, TArg argument);
		
		TResult VisitTarget03(Target03Syntax node, TArg argument);
		
		TResult VisitTest04(Test04Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node, TArg argument);
		
		TResult VisitNamespaceBody04(NamespaceBody04Syntax node, TArg argument);
		
		TResult VisitDeclaration04(Declaration04Syntax node, TArg argument);
		
		TResult VisitVertex04(Vertex04Syntax node, TArg argument);
		
		TResult VisitArrow04(Arrow04Syntax node, TArg argument);
		
		TResult VisitTest05(Test05Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node, TArg argument);
		
		TResult VisitNamespaceBody05(NamespaceBody05Syntax node, TArg argument);
		
		TResult VisitDeclaration05(Declaration05Syntax node, TArg argument);
		
		TResult VisitVertex05(Vertex05Syntax node, TArg argument);
		
		TResult VisitArrow05(Arrow05Syntax node, TArg argument);
		
		TResult VisitTest06(Test06Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node, TArg argument);
		
		TResult VisitNamespaceBody06(NamespaceBody06Syntax node, TArg argument);
		
		TResult VisitDeclaration06(Declaration06Syntax node, TArg argument);
		
		TResult VisitVertex06(Vertex06Syntax node, TArg argument);
		
		TResult VisitArrow06(Arrow06Syntax node, TArg argument);
		
		TResult VisitTest07(Test07Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node, TArg argument);
		
		TResult VisitNamespaceBody07(NamespaceBody07Syntax node, TArg argument);
		
		TResult VisitDeclaration07(Declaration07Syntax node, TArg argument);
		
		TResult VisitVertex07(Vertex07Syntax node, TArg argument);
		
		TResult VisitArrow07(Arrow07Syntax node, TArg argument);
		
		TResult VisitSource07(Source07Syntax node, TArg argument);
		
		TResult VisitTarget07(Target07Syntax node, TArg argument);
		
		TResult VisitTest08(Test08Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node, TArg argument);
		
		TResult VisitNamespaceBody08(NamespaceBody08Syntax node, TArg argument);
		
		TResult VisitDeclaration08(Declaration08Syntax node, TArg argument);
		
		TResult VisitVertex08(Vertex08Syntax node, TArg argument);
		
		TResult VisitArrow08(Arrow08Syntax node, TArg argument);
		
		TResult VisitSource08(Source08Syntax node, TArg argument);
		
		TResult VisitTarget08(Target08Syntax node, TArg argument);
		
		TResult VisitTest09(Test09Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node, TArg argument);
		
		TResult VisitNamespaceBody09(NamespaceBody09Syntax node, TArg argument);
		
		TResult VisitDeclaration09(Declaration09Syntax node, TArg argument);
		
		TResult VisitVertex09(Vertex09Syntax node, TArg argument);
		
		TResult VisitArrow09(Arrow09Syntax node, TArg argument);
		
		TResult VisitTest10(Test10Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node, TArg argument);
		
		TResult VisitNamespaceBody10(NamespaceBody10Syntax node, TArg argument);
		
		TResult VisitDeclaration10(Declaration10Syntax node, TArg argument);
		
		TResult VisitVertex10(Vertex10Syntax node, TArg argument);
		
		TResult VisitArrow10(Arrow10Syntax node, TArg argument);
		
		TResult VisitTest11(Test11Syntax node, TArg argument);
		
		TResult VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node, TArg argument);
		
		TResult VisitNamespaceBody11(NamespaceBody11Syntax node, TArg argument);
		
		TResult VisitDeclaration11(Declaration11Syntax node, TArg argument);
		
		TResult VisitVertex11(Vertex11Syntax node, TArg argument);
		
		TResult VisitArrow11(Arrow11Syntax node, TArg argument);
		
		TResult VisitName(NameSyntax node, TArg argument);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node, TArg argument);
		
		TResult VisitQualifier(QualifierSyntax node, TArg argument);
		
		TResult VisitIdentifier(IdentifierSyntax node, TArg argument);
		
		TResult VisitLiteral(LiteralSyntax node, TArg argument);
		
		TResult VisitNullLiteral(NullLiteralSyntax node, TArg argument);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node, TArg argument);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node, TArg argument);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node, TArg argument);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node, TArg argument);
		
		TResult VisitStringLiteral(StringLiteralSyntax node, TArg argument);
	}
	
	public class TestLanguageAnnotationsSyntaxVisitor<TArg, TResult> : SyntaxVisitor<TArg, TResult>, ITestLanguageAnnotationsSyntaxVisitor<TArg, TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest(TestSyntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest01(Test01Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody01(NamespaceBody01Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration01(Declaration01Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex01(Vertex01Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow01(Arrow01Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest02(Test02Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody02(NamespaceBody02Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration02(Declaration02Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex02(Vertex02Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow02(Arrow02Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSource02(Source02Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTarget02(Target02Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest03(Test03Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody03(NamespaceBody03Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration03(Declaration03Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex03(Vertex03Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow03(Arrow03Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSource03(Source03Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTarget03(Target03Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest04(Test04Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody04(NamespaceBody04Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration04(Declaration04Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex04(Vertex04Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow04(Arrow04Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest05(Test05Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody05(NamespaceBody05Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration05(Declaration05Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex05(Vertex05Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow05(Arrow05Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest06(Test06Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody06(NamespaceBody06Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration06(Declaration06Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex06(Vertex06Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow06(Arrow06Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest07(Test07Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody07(NamespaceBody07Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration07(Declaration07Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex07(Vertex07Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow07(Arrow07Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSource07(Source07Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTarget07(Target07Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest08(Test08Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody08(NamespaceBody08Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration08(Declaration08Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex08(Vertex08Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow08(Arrow08Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitSource08(Source08Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTarget08(Target08Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest09(Test09Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody09(NamespaceBody09Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration09(Declaration09Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex09(Vertex09Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow09(Arrow09Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest10(Test10Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody10(NamespaceBody10Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration10(Declaration10Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex10(Vertex10Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow10(Arrow10Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitTest11(Test11Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitNamespaceBody11(NamespaceBody11Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitDeclaration11(Declaration11Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitVertex11(Vertex11Syntax node, TArg argument)
		{
		    return this.DefaultVisit(node, argument);
		}
		
		public virtual TResult VisitArrow11(Arrow11Syntax node, TArg argument)
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

	public interface ITestLanguageAnnotationsSyntaxVisitor<TResult> 
	{
		
		TResult VisitMain(MainSyntax node);
		
		TResult VisitTest(TestSyntax node);
		
		TResult VisitTest01(Test01Syntax node);
		
		TResult VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node);
		
		TResult VisitNamespaceBody01(NamespaceBody01Syntax node);
		
		TResult VisitDeclaration01(Declaration01Syntax node);
		
		TResult VisitVertex01(Vertex01Syntax node);
		
		TResult VisitArrow01(Arrow01Syntax node);
		
		TResult VisitTest02(Test02Syntax node);
		
		TResult VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node);
		
		TResult VisitNamespaceBody02(NamespaceBody02Syntax node);
		
		TResult VisitDeclaration02(Declaration02Syntax node);
		
		TResult VisitVertex02(Vertex02Syntax node);
		
		TResult VisitArrow02(Arrow02Syntax node);
		
		TResult VisitSource02(Source02Syntax node);
		
		TResult VisitTarget02(Target02Syntax node);
		
		TResult VisitTest03(Test03Syntax node);
		
		TResult VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node);
		
		TResult VisitNamespaceBody03(NamespaceBody03Syntax node);
		
		TResult VisitDeclaration03(Declaration03Syntax node);
		
		TResult VisitVertex03(Vertex03Syntax node);
		
		TResult VisitArrow03(Arrow03Syntax node);
		
		TResult VisitSource03(Source03Syntax node);
		
		TResult VisitTarget03(Target03Syntax node);
		
		TResult VisitTest04(Test04Syntax node);
		
		TResult VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node);
		
		TResult VisitNamespaceBody04(NamespaceBody04Syntax node);
		
		TResult VisitDeclaration04(Declaration04Syntax node);
		
		TResult VisitVertex04(Vertex04Syntax node);
		
		TResult VisitArrow04(Arrow04Syntax node);
		
		TResult VisitTest05(Test05Syntax node);
		
		TResult VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node);
		
		TResult VisitNamespaceBody05(NamespaceBody05Syntax node);
		
		TResult VisitDeclaration05(Declaration05Syntax node);
		
		TResult VisitVertex05(Vertex05Syntax node);
		
		TResult VisitArrow05(Arrow05Syntax node);
		
		TResult VisitTest06(Test06Syntax node);
		
		TResult VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node);
		
		TResult VisitNamespaceBody06(NamespaceBody06Syntax node);
		
		TResult VisitDeclaration06(Declaration06Syntax node);
		
		TResult VisitVertex06(Vertex06Syntax node);
		
		TResult VisitArrow06(Arrow06Syntax node);
		
		TResult VisitTest07(Test07Syntax node);
		
		TResult VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node);
		
		TResult VisitNamespaceBody07(NamespaceBody07Syntax node);
		
		TResult VisitDeclaration07(Declaration07Syntax node);
		
		TResult VisitVertex07(Vertex07Syntax node);
		
		TResult VisitArrow07(Arrow07Syntax node);
		
		TResult VisitSource07(Source07Syntax node);
		
		TResult VisitTarget07(Target07Syntax node);
		
		TResult VisitTest08(Test08Syntax node);
		
		TResult VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node);
		
		TResult VisitNamespaceBody08(NamespaceBody08Syntax node);
		
		TResult VisitDeclaration08(Declaration08Syntax node);
		
		TResult VisitVertex08(Vertex08Syntax node);
		
		TResult VisitArrow08(Arrow08Syntax node);
		
		TResult VisitSource08(Source08Syntax node);
		
		TResult VisitTarget08(Target08Syntax node);
		
		TResult VisitTest09(Test09Syntax node);
		
		TResult VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node);
		
		TResult VisitNamespaceBody09(NamespaceBody09Syntax node);
		
		TResult VisitDeclaration09(Declaration09Syntax node);
		
		TResult VisitVertex09(Vertex09Syntax node);
		
		TResult VisitArrow09(Arrow09Syntax node);
		
		TResult VisitTest10(Test10Syntax node);
		
		TResult VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node);
		
		TResult VisitNamespaceBody10(NamespaceBody10Syntax node);
		
		TResult VisitDeclaration10(Declaration10Syntax node);
		
		TResult VisitVertex10(Vertex10Syntax node);
		
		TResult VisitArrow10(Arrow10Syntax node);
		
		TResult VisitTest11(Test11Syntax node);
		
		TResult VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node);
		
		TResult VisitNamespaceBody11(NamespaceBody11Syntax node);
		
		TResult VisitDeclaration11(Declaration11Syntax node);
		
		TResult VisitVertex11(Vertex11Syntax node);
		
		TResult VisitArrow11(Arrow11Syntax node);
		
		TResult VisitName(NameSyntax node);
		
		TResult VisitQualifiedName(QualifiedNameSyntax node);
		
		TResult VisitQualifier(QualifierSyntax node);
		
		TResult VisitIdentifier(IdentifierSyntax node);
		
		TResult VisitLiteral(LiteralSyntax node);
		
		TResult VisitNullLiteral(NullLiteralSyntax node);
		
		TResult VisitBooleanLiteral(BooleanLiteralSyntax node);
		
		TResult VisitIntegerLiteral(IntegerLiteralSyntax node);
		
		TResult VisitDecimalLiteral(DecimalLiteralSyntax node);
		
		TResult VisitScientificLiteral(ScientificLiteralSyntax node);
		
		TResult VisitStringLiteral(StringLiteralSyntax node);
	}
	
	public class TestLanguageAnnotationsSyntaxVisitor<TResult> : SyntaxVisitor<TResult>, ITestLanguageAnnotationsSyntaxVisitor<TResult>
	{
		
		public virtual TResult VisitMain(MainSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest(TestSyntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest01(Test01Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody01(NamespaceBody01Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration01(Declaration01Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex01(Vertex01Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow01(Arrow01Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest02(Test02Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody02(NamespaceBody02Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration02(Declaration02Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex02(Vertex02Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow02(Arrow02Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSource02(Source02Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTarget02(Target02Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest03(Test03Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody03(NamespaceBody03Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration03(Declaration03Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex03(Vertex03Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow03(Arrow03Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSource03(Source03Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTarget03(Target03Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest04(Test04Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody04(NamespaceBody04Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration04(Declaration04Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex04(Vertex04Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow04(Arrow04Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest05(Test05Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody05(NamespaceBody05Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration05(Declaration05Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex05(Vertex05Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow05(Arrow05Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest06(Test06Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody06(NamespaceBody06Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration06(Declaration06Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex06(Vertex06Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow06(Arrow06Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest07(Test07Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody07(NamespaceBody07Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration07(Declaration07Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex07(Vertex07Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow07(Arrow07Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSource07(Source07Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTarget07(Target07Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest08(Test08Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody08(NamespaceBody08Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration08(Declaration08Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex08(Vertex08Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow08(Arrow08Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitSource08(Source08Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTarget08(Target08Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest09(Test09Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody09(NamespaceBody09Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration09(Declaration09Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex09(Vertex09Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow09(Arrow09Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest10(Test10Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody10(NamespaceBody10Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration10(Declaration10Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex10(Vertex10Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow10(Arrow10Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitTest11(Test11Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitNamespaceBody11(NamespaceBody11Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitDeclaration11(Declaration11Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitVertex11(Vertex11Syntax node)
		{
		    return this.DefaultVisit(node);
		}
		
		public virtual TResult VisitArrow11(Arrow11Syntax node)
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

	public class TestLanguageAnnotationsSyntaxRewriter : SyntaxRewriter, ITestLanguageAnnotationsSyntaxVisitor<SyntaxNode>
	{
	    public TestLanguageAnnotationsSyntaxRewriter(bool visitIntoStructuredTrivia = false)
			: base(TestLanguageAnnotationsLanguage.Instance, visitIntoStructuredTrivia)
	    {
	    }
		
		public virtual SyntaxNode VisitMain(MainSyntax node)
		{
		    var test = this.VisitList(node.Test);
		    var eOF = this.VisitToken(node.EndOfFileToken);
			return node.Update(test, eOF);
		}
		
		public virtual SyntaxNode VisitTest(TestSyntax node)
		{
			var oldTest01 = node.Test01;
			if (oldTest01 != null)
			{
			    var newTest01 = (Test01Syntax)this.Visit(oldTest01);
				return node.Update(newTest01);
			}
			var oldTest02 = node.Test02;
			if (oldTest02 != null)
			{
			    var newTest02 = (Test02Syntax)this.Visit(oldTest02);
				return node.Update(newTest02);
			}
			var oldTest03 = node.Test03;
			if (oldTest03 != null)
			{
			    var newTest03 = (Test03Syntax)this.Visit(oldTest03);
				return node.Update(newTest03);
			}
			var oldTest04 = node.Test04;
			if (oldTest04 != null)
			{
			    var newTest04 = (Test04Syntax)this.Visit(oldTest04);
				return node.Update(newTest04);
			}
			var oldTest05 = node.Test05;
			if (oldTest05 != null)
			{
			    var newTest05 = (Test05Syntax)this.Visit(oldTest05);
				return node.Update(newTest05);
			}
			var oldTest06 = node.Test06;
			if (oldTest06 != null)
			{
			    var newTest06 = (Test06Syntax)this.Visit(oldTest06);
				return node.Update(newTest06);
			}
			var oldTest07 = node.Test07;
			if (oldTest07 != null)
			{
			    var newTest07 = (Test07Syntax)this.Visit(oldTest07);
				return node.Update(newTest07);
			}
			var oldTest08 = node.Test08;
			if (oldTest08 != null)
			{
			    var newTest08 = (Test08Syntax)this.Visit(oldTest08);
				return node.Update(newTest08);
			}
			var oldTest09 = node.Test09;
			if (oldTest09 != null)
			{
			    var newTest09 = (Test09Syntax)this.Visit(oldTest09);
				return node.Update(newTest09);
			}
			var oldTest10 = node.Test10;
			if (oldTest10 != null)
			{
			    var newTest10 = (Test10Syntax)this.Visit(oldTest10);
				return node.Update(newTest10);
			}
			var oldTest11 = node.Test11;
			if (oldTest11 != null)
			{
			    var newTest11 = (Test11Syntax)this.Visit(oldTest11);
				return node.Update(newTest11);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitTest01(Test01Syntax node)
		{
		    var kTest01 = this.VisitToken(node.KTest01);
		    var namespaceDeclaration01 = (NamespaceDeclaration01Syntax)this.Visit(node.NamespaceDeclaration01);
			return node.Update(kTest01, namespaceDeclaration01);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody01 = (NamespaceBody01Syntax)this.Visit(node.NamespaceBody01);
			return node.Update(kNamespace, qualifiedName, namespaceBody01);
		}
		
		public virtual SyntaxNode VisitNamespaceBody01(NamespaceBody01Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration01 = this.VisitList(node.Declaration01);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration01, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration01(Declaration01Syntax node)
		{
			var oldVertex01 = node.Vertex01;
			if (oldVertex01 != null)
			{
			    var newVertex01 = (Vertex01Syntax)this.Visit(oldVertex01);
				return node.Update(newVertex01);
			}
			var oldArrow01 = node.Arrow01;
			if (oldArrow01 != null)
			{
			    var newArrow01 = (Arrow01Syntax)this.Visit(oldArrow01);
				return node.Update(newArrow01);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex01(Vertex01Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow01(Arrow01Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source = (QualifierSyntax)this.Visit(node.Source);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target = (QualifierSyntax)this.Visit(node.Target);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source, tArrow, target, tSemicolon);
		}
		
		public virtual SyntaxNode VisitTest02(Test02Syntax node)
		{
		    var kTest02 = this.VisitToken(node.KTest02);
		    var namespaceDeclaration02 = (NamespaceDeclaration02Syntax)this.Visit(node.NamespaceDeclaration02);
			return node.Update(kTest02, namespaceDeclaration02);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody02 = (NamespaceBody02Syntax)this.Visit(node.NamespaceBody02);
			return node.Update(kNamespace, qualifiedName, namespaceBody02);
		}
		
		public virtual SyntaxNode VisitNamespaceBody02(NamespaceBody02Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration02 = this.VisitList(node.Declaration02);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration02, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration02(Declaration02Syntax node)
		{
			var oldVertex02 = node.Vertex02;
			if (oldVertex02 != null)
			{
			    var newVertex02 = (Vertex02Syntax)this.Visit(oldVertex02);
				return node.Update(newVertex02);
			}
			var oldArrow02 = node.Arrow02;
			if (oldArrow02 != null)
			{
			    var newArrow02 = (Arrow02Syntax)this.Visit(oldArrow02);
				return node.Update(newArrow02);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex02(Vertex02Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow02(Arrow02Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source02 = (Source02Syntax)this.Visit(node.Source02);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target02 = (Target02Syntax)this.Visit(node.Target02);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source02, tArrow, target02, tSemicolon);
		}
		
		public virtual SyntaxNode VisitSource02(Source02Syntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitTarget02(Target02Syntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitTest03(Test03Syntax node)
		{
		    var kTest03 = this.VisitToken(node.KTest03);
		    var namespaceDeclaration03 = (NamespaceDeclaration03Syntax)this.Visit(node.NamespaceDeclaration03);
			return node.Update(kTest03, namespaceDeclaration03);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody03 = (NamespaceBody03Syntax)this.Visit(node.NamespaceBody03);
			return node.Update(kNamespace, qualifiedName, namespaceBody03);
		}
		
		public virtual SyntaxNode VisitNamespaceBody03(NamespaceBody03Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration03 = this.VisitList(node.Declaration03);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration03, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration03(Declaration03Syntax node)
		{
			var oldVertex03 = node.Vertex03;
			if (oldVertex03 != null)
			{
			    var newVertex03 = (Vertex03Syntax)this.Visit(oldVertex03);
				return node.Update(newVertex03);
			}
			var oldArrow03 = node.Arrow03;
			if (oldArrow03 != null)
			{
			    var newArrow03 = (Arrow03Syntax)this.Visit(oldArrow03);
				return node.Update(newArrow03);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex03(Vertex03Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow03(Arrow03Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source03 = (Source03Syntax)this.Visit(node.Source03);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target03 = (Target03Syntax)this.Visit(node.Target03);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source03, tArrow, target03, tSemicolon);
		}
		
		public virtual SyntaxNode VisitSource03(Source03Syntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitTarget03(Target03Syntax node)
		{
		    var qualifier = (QualifierSyntax)this.Visit(node.Qualifier);
			return node.Update(qualifier);
		}
		
		public virtual SyntaxNode VisitTest04(Test04Syntax node)
		{
		    var kTest04 = this.VisitToken(node.KTest04);
		    var namespaceDeclaration04 = (NamespaceDeclaration04Syntax)this.Visit(node.NamespaceDeclaration04);
			return node.Update(kTest04, namespaceDeclaration04);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody04 = (NamespaceBody04Syntax)this.Visit(node.NamespaceBody04);
			return node.Update(kNamespace, qualifiedName, namespaceBody04);
		}
		
		public virtual SyntaxNode VisitNamespaceBody04(NamespaceBody04Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration04 = this.VisitList(node.Declaration04);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration04, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration04(Declaration04Syntax node)
		{
			var oldVertex04 = node.Vertex04;
			if (oldVertex04 != null)
			{
			    var newVertex04 = (Vertex04Syntax)this.Visit(oldVertex04);
				return node.Update(newVertex04);
			}
			var oldArrow04 = node.Arrow04;
			if (oldArrow04 != null)
			{
			    var newArrow04 = (Arrow04Syntax)this.Visit(oldArrow04);
				return node.Update(newArrow04);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex04(Vertex04Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow04(Arrow04Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source = (QualifierSyntax)this.Visit(node.Source);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target = (QualifierSyntax)this.Visit(node.Target);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source, tArrow, target, tSemicolon);
		}
		
		public virtual SyntaxNode VisitTest05(Test05Syntax node)
		{
		    var kTest05 = this.VisitToken(node.KTest05);
		    var namespaceDeclaration05 = (NamespaceDeclaration05Syntax)this.Visit(node.NamespaceDeclaration05);
			return node.Update(kTest05, namespaceDeclaration05);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody05 = (NamespaceBody05Syntax)this.Visit(node.NamespaceBody05);
			return node.Update(kNamespace, qualifiedName, namespaceBody05);
		}
		
		public virtual SyntaxNode VisitNamespaceBody05(NamespaceBody05Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration05 = this.VisitList(node.Declaration05);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration05, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration05(Declaration05Syntax node)
		{
			var oldVertex05 = node.Vertex05;
			if (oldVertex05 != null)
			{
			    var newVertex05 = (Vertex05Syntax)this.Visit(oldVertex05);
				return node.Update(newVertex05);
			}
			var oldArrow05 = node.Arrow05;
			if (oldArrow05 != null)
			{
			    var newArrow05 = (Arrow05Syntax)this.Visit(oldArrow05);
				return node.Update(newArrow05);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex05(Vertex05Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow05(Arrow05Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source = (QualifierSyntax)this.Visit(node.Source);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target = (QualifierSyntax)this.Visit(node.Target);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source, tArrow, target, tSemicolon);
		}
		
		public virtual SyntaxNode VisitTest06(Test06Syntax node)
		{
		    var kTest06 = this.VisitToken(node.KTest06);
		    var namespaceDeclaration06 = (NamespaceDeclaration06Syntax)this.Visit(node.NamespaceDeclaration06);
			return node.Update(kTest06, namespaceDeclaration06);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody06 = (NamespaceBody06Syntax)this.Visit(node.NamespaceBody06);
			return node.Update(kNamespace, qualifiedName, namespaceBody06);
		}
		
		public virtual SyntaxNode VisitNamespaceBody06(NamespaceBody06Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration06 = this.VisitList(node.Declaration06);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration06, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration06(Declaration06Syntax node)
		{
			var oldVertex06 = node.Vertex06;
			if (oldVertex06 != null)
			{
			    var newVertex06 = (Vertex06Syntax)this.Visit(oldVertex06);
				return node.Update(newVertex06);
			}
			var oldArrow06 = node.Arrow06;
			if (oldArrow06 != null)
			{
			    var newArrow06 = (Arrow06Syntax)this.Visit(oldArrow06);
				return node.Update(newArrow06);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex06(Vertex06Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow06(Arrow06Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source = (NameSyntax)this.Visit(node.Source);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target = (NameSyntax)this.Visit(node.Target);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source, tArrow, target, tSemicolon);
		}
		
		public virtual SyntaxNode VisitTest07(Test07Syntax node)
		{
		    var kTest07 = this.VisitToken(node.KTest07);
		    var namespaceDeclaration07 = (NamespaceDeclaration07Syntax)this.Visit(node.NamespaceDeclaration07);
			return node.Update(kTest07, namespaceDeclaration07);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody07 = (NamespaceBody07Syntax)this.Visit(node.NamespaceBody07);
			return node.Update(kNamespace, qualifiedName, namespaceBody07);
		}
		
		public virtual SyntaxNode VisitNamespaceBody07(NamespaceBody07Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration07 = this.VisitList(node.Declaration07);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration07, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration07(Declaration07Syntax node)
		{
			var oldVertex07 = node.Vertex07;
			if (oldVertex07 != null)
			{
			    var newVertex07 = (Vertex07Syntax)this.Visit(oldVertex07);
				return node.Update(newVertex07);
			}
			var oldArrow07 = node.Arrow07;
			if (oldArrow07 != null)
			{
			    var newArrow07 = (Arrow07Syntax)this.Visit(oldArrow07);
				return node.Update(newArrow07);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex07(Vertex07Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow07(Arrow07Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source07 = (Source07Syntax)this.Visit(node.Source07);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target07 = (Target07Syntax)this.Visit(node.Target07);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source07, tArrow, target07, tSemicolon);
		}
		
		public virtual SyntaxNode VisitSource07(Source07Syntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(name);
		}
		
		public virtual SyntaxNode VisitTarget07(Target07Syntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(name);
		}
		
		public virtual SyntaxNode VisitTest08(Test08Syntax node)
		{
		    var kTest08 = this.VisitToken(node.KTest08);
		    var namespaceDeclaration08 = (NamespaceDeclaration08Syntax)this.Visit(node.NamespaceDeclaration08);
			return node.Update(kTest08, namespaceDeclaration08);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody08 = (NamespaceBody08Syntax)this.Visit(node.NamespaceBody08);
			return node.Update(kNamespace, qualifiedName, namespaceBody08);
		}
		
		public virtual SyntaxNode VisitNamespaceBody08(NamespaceBody08Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration08 = this.VisitList(node.Declaration08);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration08, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration08(Declaration08Syntax node)
		{
			var oldVertex08 = node.Vertex08;
			if (oldVertex08 != null)
			{
			    var newVertex08 = (Vertex08Syntax)this.Visit(oldVertex08);
				return node.Update(newVertex08);
			}
			var oldArrow08 = node.Arrow08;
			if (oldArrow08 != null)
			{
			    var newArrow08 = (Arrow08Syntax)this.Visit(oldArrow08);
				return node.Update(newArrow08);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex08(Vertex08Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow08(Arrow08Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source08 = (Source08Syntax)this.Visit(node.Source08);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target08 = (Target08Syntax)this.Visit(node.Target08);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source08, tArrow, target08, tSemicolon);
		}
		
		public virtual SyntaxNode VisitSource08(Source08Syntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(name);
		}
		
		public virtual SyntaxNode VisitTarget08(Target08Syntax node)
		{
		    var name = (NameSyntax)this.Visit(node.Name);
			return node.Update(name);
		}
		
		public virtual SyntaxNode VisitTest09(Test09Syntax node)
		{
		    var kTest09 = this.VisitToken(node.KTest09);
		    var namespaceDeclaration09 = (NamespaceDeclaration09Syntax)this.Visit(node.NamespaceDeclaration09);
			return node.Update(kTest09, namespaceDeclaration09);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody09 = (NamespaceBody09Syntax)this.Visit(node.NamespaceBody09);
			return node.Update(kNamespace, qualifiedName, namespaceBody09);
		}
		
		public virtual SyntaxNode VisitNamespaceBody09(NamespaceBody09Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration09 = this.VisitList(node.Declaration09);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration09, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration09(Declaration09Syntax node)
		{
			var oldVertex09 = node.Vertex09;
			if (oldVertex09 != null)
			{
			    var newVertex09 = (Vertex09Syntax)this.Visit(oldVertex09);
				return node.Update(newVertex09);
			}
			var oldArrow09 = node.Arrow09;
			if (oldArrow09 != null)
			{
			    var newArrow09 = (Arrow09Syntax)this.Visit(oldArrow09);
				return node.Update(newArrow09);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex09(Vertex09Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow09(Arrow09Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source = (NameSyntax)this.Visit(node.Source);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target = (NameSyntax)this.Visit(node.Target);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source, tArrow, target, tSemicolon);
		}
		
		public virtual SyntaxNode VisitTest10(Test10Syntax node)
		{
		    var kTest10 = this.VisitToken(node.KTest10);
		    var namespaceDeclaration10 = (NamespaceDeclaration10Syntax)this.Visit(node.NamespaceDeclaration10);
			return node.Update(kTest10, namespaceDeclaration10);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody10 = (NamespaceBody10Syntax)this.Visit(node.NamespaceBody10);
			return node.Update(kNamespace, qualifiedName, namespaceBody10);
		}
		
		public virtual SyntaxNode VisitNamespaceBody10(NamespaceBody10Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration10 = this.VisitList(node.Declaration10);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration10, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration10(Declaration10Syntax node)
		{
			var oldVertex10 = node.Vertex10;
			if (oldVertex10 != null)
			{
			    var newVertex10 = (Vertex10Syntax)this.Visit(oldVertex10);
				return node.Update(newVertex10);
			}
			var oldArrow10 = node.Arrow10;
			if (oldArrow10 != null)
			{
			    var newArrow10 = (Arrow10Syntax)this.Visit(oldArrow10);
				return node.Update(newArrow10);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex10(Vertex10Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow10(Arrow10Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source = (NameSyntax)this.Visit(node.Source);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target = (NameSyntax)this.Visit(node.Target);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source, tArrow, target, tSemicolon);
		}
		
		public virtual SyntaxNode VisitTest11(Test11Syntax node)
		{
		    var kTest11 = this.VisitToken(node.KTest11);
		    var namespaceDeclaration11 = this.VisitList(node.NamespaceDeclaration11);
			return node.Update(kTest11, namespaceDeclaration11);
		}
		
		public virtual SyntaxNode VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node)
		{
		    var kNamespace = this.VisitToken(node.KNamespace);
		    var qualifiedName = (QualifiedNameSyntax)this.Visit(node.QualifiedName);
		    var namespaceBody11 = (NamespaceBody11Syntax)this.Visit(node.NamespaceBody11);
			return node.Update(kNamespace, qualifiedName, namespaceBody11);
		}
		
		public virtual SyntaxNode VisitNamespaceBody11(NamespaceBody11Syntax node)
		{
		    var tOpenBrace = this.VisitToken(node.TOpenBrace);
		    var declaration11 = this.VisitList(node.Declaration11);
		    var tCloseBrace = this.VisitToken(node.TCloseBrace);
			return node.Update(tOpenBrace, declaration11, tCloseBrace);
		}
		
		public virtual SyntaxNode VisitDeclaration11(Declaration11Syntax node)
		{
			var oldVertex11 = node.Vertex11;
			if (oldVertex11 != null)
			{
			    var newVertex11 = (Vertex11Syntax)this.Visit(oldVertex11);
				return node.Update(newVertex11);
			}
			var oldArrow11 = node.Arrow11;
			if (oldArrow11 != null)
			{
			    var newArrow11 = (Arrow11Syntax)this.Visit(oldArrow11);
				return node.Update(newArrow11);
			}
			return node;   
		}
		
		public virtual SyntaxNode VisitVertex11(Vertex11Syntax node)
		{
		    var kVertex = this.VisitToken(node.KVertex);
		    var name = (NameSyntax)this.Visit(node.Name);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kVertex, name, tSemicolon);
		}
		
		public virtual SyntaxNode VisitArrow11(Arrow11Syntax node)
		{
		    var kArrow = this.VisitToken(node.KArrow);
		    var source = (QualifiedNameSyntax)this.Visit(node.Source);
		    var tArrow = this.VisitToken(node.TArrow);
		    var target = (QualifiedNameSyntax)this.Visit(node.Target);
		    var tSemicolon = this.VisitToken(node.TSemicolon);
			return node.Update(kArrow, source, tArrow, target, tSemicolon);
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

	public class TestLanguageAnnotationsSyntaxFactory : SyntaxFactory
	{
		internal TestLanguageAnnotationsSyntaxFactory(TestLanguageAnnotationsInternalSyntaxFactory internalSyntaxFactory) 
			: base(internalSyntaxFactory)
		{
		}
		public new TestLanguageAnnotationsLanguage Language => TestLanguageAnnotationsLanguage.Instance;
		protected override Language LanguageCore => this.Language;
	    public override LanguageParseOptions DefaultParseOptions => TestLanguageAnnotationsParseOptions.Default;
		/// <summary>
		/// Create a new syntax tree from a syntax node.
		/// </summary>
		public TestLanguageAnnotationsSyntaxTree SyntaxTree(SyntaxNode root, TestLanguageAnnotationsParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return TestLanguageAnnotationsSyntaxTree.Create((TestLanguageAnnotationsSyntaxNode)root, (TestLanguageAnnotationsParseOptions)options, path, null, encoding);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public TestLanguageAnnotationsSyntaxTree ParseSyntaxTree(
			string text,
			TestLanguageAnnotationsParseOptions options = null,
			string path = "",
			Encoding encoding = null,
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (TestLanguageAnnotationsSyntaxTree)this.ParseSyntaxTreeCore(SourceText.From(text, encoding), options, path, cancellationToken);
		}
		/// <summary>
		/// Produces a syntax tree by parsing the source text.
		/// </summary>
		public TestLanguageAnnotationsSyntaxTree ParseSyntaxTree(
			SourceText text,
			TestLanguageAnnotationsParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return (TestLanguageAnnotationsSyntaxTree)this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
		}
		protected override LanguageSyntaxTree ParseSyntaxTreeCore(
			SourceText text,
			ParseOptions options = null,
			string path = "",
			CancellationToken cancellationToken = default(CancellationToken))
		{
			return TestLanguageAnnotationsSyntaxTree.ParseText(text, (TestLanguageAnnotationsParseOptions)options, path, cancellationToken);
		}
	
		public override LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
		{
			return TestLanguageAnnotationsSyntaxTree.Create((TestLanguageAnnotationsSyntaxNode)root, (TestLanguageAnnotationsParseOptions)options, path, null, encoding);
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
	
	
	    public SyntaxToken TAsterisk(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.TAsterisk(text));
	    }
	
	    public SyntaxToken TAsterisk(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.TAsterisk(text, value));
	    }
	
	    public SyntaxToken IdentifierNormal(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text));
	    }
	
	    public SyntaxToken IdentifierNormal(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.IdentifierNormal(text, value));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text));
	    }
	
	    public SyntaxToken IdentifierVerbatim(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.IdentifierVerbatim(text, value));
	    }
	
	    public SyntaxToken LInteger(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LInteger(text));
	    }
	
	    public SyntaxToken LInteger(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LInteger(text, value));
	    }
	
	    public SyntaxToken LDecimal(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LDecimal(text));
	    }
	
	    public SyntaxToken LDecimal(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LDecimal(text, value));
	    }
	
	    public SyntaxToken LScientific(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LScientific(text));
	    }
	
	    public SyntaxToken LScientific(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LScientific(text, value));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text));
	    }
	
	    public SyntaxToken LDateTimeOffset(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LDateTimeOffset(text, value));
	    }
	
	    public SyntaxToken LDateTime(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LDateTime(text));
	    }
	
	    public SyntaxToken LDateTime(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LDateTime(text, value));
	    }
	
	    public SyntaxToken LDate(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LDate(text));
	    }
	
	    public SyntaxToken LDate(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LDate(text, value));
	    }
	
	    public SyntaxToken LTime(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LTime(text));
	    }
	
	    public SyntaxToken LTime(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LTime(text, value));
	    }
	
	    public SyntaxToken LRegularString(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LRegularString(text));
	    }
	
	    public SyntaxToken LRegularString(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LRegularString(text, value));
	    }
	
	    public SyntaxToken LGuid(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LGuid(text));
	    }
	
	    public SyntaxToken LGuid(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LGuid(text, value));
	    }
	
	    public SyntaxToken LUtf8Bom(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text));
	    }
	
	    public SyntaxToken LUtf8Bom(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LUtf8Bom(text, value));
	    }
	
	    public SyntaxToken LWhiteSpace(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text));
	    }
	
	    public SyntaxToken LWhiteSpace(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LWhiteSpace(text, value));
	    }
	
	    public SyntaxToken LCrLf(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LCrLf(text));
	    }
	
	    public SyntaxToken LCrLf(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LCrLf(text, value));
	    }
	
	    public SyntaxToken LLineEnd(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LLineEnd(text));
	    }
	
	    public SyntaxToken LLineEnd(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LLineEnd(text, value));
	    }
	
	    public SyntaxToken LSingleLineComment(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text));
	    }
	
	    public SyntaxToken LSingleLineComment(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LSingleLineComment(text, value));
	    }
	
	    public SyntaxToken LComment(string text)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LComment(text));
	    }
	
	    public SyntaxToken LComment(string text, object value)
	    {
	        return new SyntaxToken(TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.LComment(text, value));
	    }
		
		public MainSyntax Main(SyntaxList<TestSyntax> test, SyntaxToken eOF)
		{
		    if (eOF == null) throw new ArgumentNullException(nameof(eOF));
		    if (eOF.GetKind() != TestLanguageAnnotationsSyntaxKind.Eof) throw new ArgumentException(nameof(eOF));
		    return (MainSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Main(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<TestGreen>(test.Node), (InternalSyntaxToken)eOF.Node).CreateRed();
		}
		
		public MainSyntax Main(SyntaxToken eOF)
		{
			return this.Main(default, eOF);
		}
		
		public TestSyntax Test(Test01Syntax test01)
		{
		    if (test01 == null) throw new ArgumentNullException(nameof(test01));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test01Green)test01.Green).CreateRed();
		}
		
		public TestSyntax Test(Test02Syntax test02)
		{
		    if (test02 == null) throw new ArgumentNullException(nameof(test02));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test02Green)test02.Green).CreateRed();
		}
		
		public TestSyntax Test(Test03Syntax test03)
		{
		    if (test03 == null) throw new ArgumentNullException(nameof(test03));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test03Green)test03.Green).CreateRed();
		}
		
		public TestSyntax Test(Test04Syntax test04)
		{
		    if (test04 == null) throw new ArgumentNullException(nameof(test04));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test04Green)test04.Green).CreateRed();
		}
		
		public TestSyntax Test(Test05Syntax test05)
		{
		    if (test05 == null) throw new ArgumentNullException(nameof(test05));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test05Green)test05.Green).CreateRed();
		}
		
		public TestSyntax Test(Test06Syntax test06)
		{
		    if (test06 == null) throw new ArgumentNullException(nameof(test06));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test06Green)test06.Green).CreateRed();
		}
		
		public TestSyntax Test(Test07Syntax test07)
		{
		    if (test07 == null) throw new ArgumentNullException(nameof(test07));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test07Green)test07.Green).CreateRed();
		}
		
		public TestSyntax Test(Test08Syntax test08)
		{
		    if (test08 == null) throw new ArgumentNullException(nameof(test08));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test08Green)test08.Green).CreateRed();
		}
		
		public TestSyntax Test(Test09Syntax test09)
		{
		    if (test09 == null) throw new ArgumentNullException(nameof(test09));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test09Green)test09.Green).CreateRed();
		}
		
		public TestSyntax Test(Test10Syntax test10)
		{
		    if (test10 == null) throw new ArgumentNullException(nameof(test10));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test10Green)test10.Green).CreateRed();
		}
		
		public TestSyntax Test(Test11Syntax test11)
		{
		    if (test11 == null) throw new ArgumentNullException(nameof(test11));
		    return (TestSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test((Syntax.InternalSyntax.Test11Green)test11.Green).CreateRed();
		}
		
		public Test01Syntax Test01(SyntaxToken kTest01, NamespaceDeclaration01Syntax namespaceDeclaration01)
		{
		    if (kTest01 == null) throw new ArgumentNullException(nameof(kTest01));
		    if (kTest01.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest01) throw new ArgumentException(nameof(kTest01));
		    if (namespaceDeclaration01 == null) throw new ArgumentNullException(nameof(namespaceDeclaration01));
		    return (Test01Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test01((InternalSyntaxToken)kTest01.Node, (Syntax.InternalSyntax.NamespaceDeclaration01Green)namespaceDeclaration01.Green).CreateRed();
		}
		
		public Test01Syntax Test01(NamespaceDeclaration01Syntax namespaceDeclaration01)
		{
			return this.Test01(this.Token(TestLanguageAnnotationsSyntaxKind.KTest01), namespaceDeclaration01);
		}
		
		public NamespaceDeclaration01Syntax NamespaceDeclaration01(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody01Syntax namespaceBody01)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody01 == null) throw new ArgumentNullException(nameof(namespaceBody01));
		    return (NamespaceDeclaration01Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration01((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody01Green)namespaceBody01.Green).CreateRed();
		}
		
		public NamespaceDeclaration01Syntax NamespaceDeclaration01(QualifiedNameSyntax qualifiedName, NamespaceBody01Syntax namespaceBody01)
		{
			return this.NamespaceDeclaration01(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody01);
		}
		
		public NamespaceBody01Syntax NamespaceBody01(SyntaxToken tOpenBrace, SyntaxList<Declaration01Syntax> declaration01, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody01Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody01((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration01Green>(declaration01.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody01Syntax NamespaceBody01()
		{
			return this.NamespaceBody01(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration01Syntax Declaration01(Vertex01Syntax vertex01)
		{
		    if (vertex01 == null) throw new ArgumentNullException(nameof(vertex01));
		    return (Declaration01Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration01((Syntax.InternalSyntax.Vertex01Green)vertex01.Green).CreateRed();
		}
		
		public Declaration01Syntax Declaration01(Arrow01Syntax arrow01)
		{
		    if (arrow01 == null) throw new ArgumentNullException(nameof(arrow01));
		    return (Declaration01Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration01((Syntax.InternalSyntax.Arrow01Green)arrow01.Green).CreateRed();
		}
		
		public Vertex01Syntax Vertex01(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex01Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex01((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex01Syntax Vertex01(NameSyntax name)
		{
			return this.Vertex01(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow01Syntax Arrow01(SyntaxToken kArrow, QualifierSyntax source, SyntaxToken tArrow, QualifierSyntax target, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow01Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow01((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.QualifierGreen)source.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.QualifierGreen)target.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow01Syntax Arrow01(QualifierSyntax source, QualifierSyntax target)
		{
			return this.Arrow01(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Test02Syntax Test02(SyntaxToken kTest02, NamespaceDeclaration02Syntax namespaceDeclaration02)
		{
		    if (kTest02 == null) throw new ArgumentNullException(nameof(kTest02));
		    if (kTest02.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest02) throw new ArgumentException(nameof(kTest02));
		    if (namespaceDeclaration02 == null) throw new ArgumentNullException(nameof(namespaceDeclaration02));
		    return (Test02Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test02((InternalSyntaxToken)kTest02.Node, (Syntax.InternalSyntax.NamespaceDeclaration02Green)namespaceDeclaration02.Green).CreateRed();
		}
		
		public Test02Syntax Test02(NamespaceDeclaration02Syntax namespaceDeclaration02)
		{
			return this.Test02(this.Token(TestLanguageAnnotationsSyntaxKind.KTest02), namespaceDeclaration02);
		}
		
		public NamespaceDeclaration02Syntax NamespaceDeclaration02(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody02Syntax namespaceBody02)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody02 == null) throw new ArgumentNullException(nameof(namespaceBody02));
		    return (NamespaceDeclaration02Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration02((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody02Green)namespaceBody02.Green).CreateRed();
		}
		
		public NamespaceDeclaration02Syntax NamespaceDeclaration02(QualifiedNameSyntax qualifiedName, NamespaceBody02Syntax namespaceBody02)
		{
			return this.NamespaceDeclaration02(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody02);
		}
		
		public NamespaceBody02Syntax NamespaceBody02(SyntaxToken tOpenBrace, SyntaxList<Declaration02Syntax> declaration02, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody02Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody02((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration02Green>(declaration02.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody02Syntax NamespaceBody02()
		{
			return this.NamespaceBody02(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration02Syntax Declaration02(Vertex02Syntax vertex02)
		{
		    if (vertex02 == null) throw new ArgumentNullException(nameof(vertex02));
		    return (Declaration02Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration02((Syntax.InternalSyntax.Vertex02Green)vertex02.Green).CreateRed();
		}
		
		public Declaration02Syntax Declaration02(Arrow02Syntax arrow02)
		{
		    if (arrow02 == null) throw new ArgumentNullException(nameof(arrow02));
		    return (Declaration02Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration02((Syntax.InternalSyntax.Arrow02Green)arrow02.Green).CreateRed();
		}
		
		public Vertex02Syntax Vertex02(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex02Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex02((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex02Syntax Vertex02(NameSyntax name)
		{
			return this.Vertex02(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow02Syntax Arrow02(SyntaxToken kArrow, Source02Syntax source02, SyntaxToken tArrow, Target02Syntax target02, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source02 == null) throw new ArgumentNullException(nameof(source02));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target02 == null) throw new ArgumentNullException(nameof(target02));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow02Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow02((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.Source02Green)source02.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.Target02Green)target02.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow02Syntax Arrow02(Source02Syntax source02, Target02Syntax target02)
		{
			return this.Arrow02(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source02, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target02, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Source02Syntax Source02(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (Source02Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Source02((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public Target02Syntax Target02(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (Target02Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Target02((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public Test03Syntax Test03(SyntaxToken kTest03, NamespaceDeclaration03Syntax namespaceDeclaration03)
		{
		    if (kTest03 == null) throw new ArgumentNullException(nameof(kTest03));
		    if (kTest03.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest03) throw new ArgumentException(nameof(kTest03));
		    if (namespaceDeclaration03 == null) throw new ArgumentNullException(nameof(namespaceDeclaration03));
		    return (Test03Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test03((InternalSyntaxToken)kTest03.Node, (Syntax.InternalSyntax.NamespaceDeclaration03Green)namespaceDeclaration03.Green).CreateRed();
		}
		
		public Test03Syntax Test03(NamespaceDeclaration03Syntax namespaceDeclaration03)
		{
			return this.Test03(this.Token(TestLanguageAnnotationsSyntaxKind.KTest03), namespaceDeclaration03);
		}
		
		public NamespaceDeclaration03Syntax NamespaceDeclaration03(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody03Syntax namespaceBody03)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody03 == null) throw new ArgumentNullException(nameof(namespaceBody03));
		    return (NamespaceDeclaration03Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration03((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody03Green)namespaceBody03.Green).CreateRed();
		}
		
		public NamespaceDeclaration03Syntax NamespaceDeclaration03(QualifiedNameSyntax qualifiedName, NamespaceBody03Syntax namespaceBody03)
		{
			return this.NamespaceDeclaration03(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody03);
		}
		
		public NamespaceBody03Syntax NamespaceBody03(SyntaxToken tOpenBrace, SyntaxList<Declaration03Syntax> declaration03, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody03Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody03((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration03Green>(declaration03.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody03Syntax NamespaceBody03()
		{
			return this.NamespaceBody03(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration03Syntax Declaration03(Vertex03Syntax vertex03)
		{
		    if (vertex03 == null) throw new ArgumentNullException(nameof(vertex03));
		    return (Declaration03Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration03((Syntax.InternalSyntax.Vertex03Green)vertex03.Green).CreateRed();
		}
		
		public Declaration03Syntax Declaration03(Arrow03Syntax arrow03)
		{
		    if (arrow03 == null) throw new ArgumentNullException(nameof(arrow03));
		    return (Declaration03Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration03((Syntax.InternalSyntax.Arrow03Green)arrow03.Green).CreateRed();
		}
		
		public Vertex03Syntax Vertex03(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex03Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex03((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex03Syntax Vertex03(NameSyntax name)
		{
			return this.Vertex03(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow03Syntax Arrow03(SyntaxToken kArrow, Source03Syntax source03, SyntaxToken tArrow, Target03Syntax target03, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source03 == null) throw new ArgumentNullException(nameof(source03));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target03 == null) throw new ArgumentNullException(nameof(target03));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow03Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow03((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.Source03Green)source03.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.Target03Green)target03.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow03Syntax Arrow03(Source03Syntax source03, Target03Syntax target03)
		{
			return this.Arrow03(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source03, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target03, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Source03Syntax Source03(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (Source03Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Source03((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public Target03Syntax Target03(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (Target03Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Target03((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public Test04Syntax Test04(SyntaxToken kTest04, NamespaceDeclaration04Syntax namespaceDeclaration04)
		{
		    if (kTest04 == null) throw new ArgumentNullException(nameof(kTest04));
		    if (kTest04.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest04) throw new ArgumentException(nameof(kTest04));
		    if (namespaceDeclaration04 == null) throw new ArgumentNullException(nameof(namespaceDeclaration04));
		    return (Test04Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test04((InternalSyntaxToken)kTest04.Node, (Syntax.InternalSyntax.NamespaceDeclaration04Green)namespaceDeclaration04.Green).CreateRed();
		}
		
		public Test04Syntax Test04(NamespaceDeclaration04Syntax namespaceDeclaration04)
		{
			return this.Test04(this.Token(TestLanguageAnnotationsSyntaxKind.KTest04), namespaceDeclaration04);
		}
		
		public NamespaceDeclaration04Syntax NamespaceDeclaration04(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody04Syntax namespaceBody04)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody04 == null) throw new ArgumentNullException(nameof(namespaceBody04));
		    return (NamespaceDeclaration04Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration04((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody04Green)namespaceBody04.Green).CreateRed();
		}
		
		public NamespaceDeclaration04Syntax NamespaceDeclaration04(QualifiedNameSyntax qualifiedName, NamespaceBody04Syntax namespaceBody04)
		{
			return this.NamespaceDeclaration04(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody04);
		}
		
		public NamespaceBody04Syntax NamespaceBody04(SyntaxToken tOpenBrace, SyntaxList<Declaration04Syntax> declaration04, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody04Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody04((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration04Green>(declaration04.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody04Syntax NamespaceBody04()
		{
			return this.NamespaceBody04(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration04Syntax Declaration04(Vertex04Syntax vertex04)
		{
		    if (vertex04 == null) throw new ArgumentNullException(nameof(vertex04));
		    return (Declaration04Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration04((Syntax.InternalSyntax.Vertex04Green)vertex04.Green).CreateRed();
		}
		
		public Declaration04Syntax Declaration04(Arrow04Syntax arrow04)
		{
		    if (arrow04 == null) throw new ArgumentNullException(nameof(arrow04));
		    return (Declaration04Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration04((Syntax.InternalSyntax.Arrow04Green)arrow04.Green).CreateRed();
		}
		
		public Vertex04Syntax Vertex04(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex04Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex04((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex04Syntax Vertex04(NameSyntax name)
		{
			return this.Vertex04(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow04Syntax Arrow04(SyntaxToken kArrow, QualifierSyntax source, SyntaxToken tArrow, QualifierSyntax target, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow04Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow04((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.QualifierGreen)source.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.QualifierGreen)target.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow04Syntax Arrow04(QualifierSyntax source, QualifierSyntax target)
		{
			return this.Arrow04(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Test05Syntax Test05(SyntaxToken kTest05, NamespaceDeclaration05Syntax namespaceDeclaration05)
		{
		    if (kTest05 == null) throw new ArgumentNullException(nameof(kTest05));
		    if (kTest05.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest05) throw new ArgumentException(nameof(kTest05));
		    if (namespaceDeclaration05 == null) throw new ArgumentNullException(nameof(namespaceDeclaration05));
		    return (Test05Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test05((InternalSyntaxToken)kTest05.Node, (Syntax.InternalSyntax.NamespaceDeclaration05Green)namespaceDeclaration05.Green).CreateRed();
		}
		
		public Test05Syntax Test05(NamespaceDeclaration05Syntax namespaceDeclaration05)
		{
			return this.Test05(this.Token(TestLanguageAnnotationsSyntaxKind.KTest05), namespaceDeclaration05);
		}
		
		public NamespaceDeclaration05Syntax NamespaceDeclaration05(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody05Syntax namespaceBody05)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody05 == null) throw new ArgumentNullException(nameof(namespaceBody05));
		    return (NamespaceDeclaration05Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration05((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody05Green)namespaceBody05.Green).CreateRed();
		}
		
		public NamespaceDeclaration05Syntax NamespaceDeclaration05(QualifiedNameSyntax qualifiedName, NamespaceBody05Syntax namespaceBody05)
		{
			return this.NamespaceDeclaration05(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody05);
		}
		
		public NamespaceBody05Syntax NamespaceBody05(SyntaxToken tOpenBrace, SyntaxList<Declaration05Syntax> declaration05, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody05Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody05((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration05Green>(declaration05.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody05Syntax NamespaceBody05()
		{
			return this.NamespaceBody05(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration05Syntax Declaration05(Vertex05Syntax vertex05)
		{
		    if (vertex05 == null) throw new ArgumentNullException(nameof(vertex05));
		    return (Declaration05Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration05((Syntax.InternalSyntax.Vertex05Green)vertex05.Green).CreateRed();
		}
		
		public Declaration05Syntax Declaration05(Arrow05Syntax arrow05)
		{
		    if (arrow05 == null) throw new ArgumentNullException(nameof(arrow05));
		    return (Declaration05Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration05((Syntax.InternalSyntax.Arrow05Green)arrow05.Green).CreateRed();
		}
		
		public Vertex05Syntax Vertex05(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex05Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex05((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex05Syntax Vertex05(NameSyntax name)
		{
			return this.Vertex05(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow05Syntax Arrow05(SyntaxToken kArrow, QualifierSyntax source, SyntaxToken tArrow, QualifierSyntax target, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow05Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow05((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.QualifierGreen)source.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.QualifierGreen)target.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow05Syntax Arrow05(QualifierSyntax source, QualifierSyntax target)
		{
			return this.Arrow05(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Test06Syntax Test06(SyntaxToken kTest06, NamespaceDeclaration06Syntax namespaceDeclaration06)
		{
		    if (kTest06 == null) throw new ArgumentNullException(nameof(kTest06));
		    if (kTest06.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest06) throw new ArgumentException(nameof(kTest06));
		    if (namespaceDeclaration06 == null) throw new ArgumentNullException(nameof(namespaceDeclaration06));
		    return (Test06Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test06((InternalSyntaxToken)kTest06.Node, (Syntax.InternalSyntax.NamespaceDeclaration06Green)namespaceDeclaration06.Green).CreateRed();
		}
		
		public Test06Syntax Test06(NamespaceDeclaration06Syntax namespaceDeclaration06)
		{
			return this.Test06(this.Token(TestLanguageAnnotationsSyntaxKind.KTest06), namespaceDeclaration06);
		}
		
		public NamespaceDeclaration06Syntax NamespaceDeclaration06(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody06Syntax namespaceBody06)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody06 == null) throw new ArgumentNullException(nameof(namespaceBody06));
		    return (NamespaceDeclaration06Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration06((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody06Green)namespaceBody06.Green).CreateRed();
		}
		
		public NamespaceDeclaration06Syntax NamespaceDeclaration06(QualifiedNameSyntax qualifiedName, NamespaceBody06Syntax namespaceBody06)
		{
			return this.NamespaceDeclaration06(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody06);
		}
		
		public NamespaceBody06Syntax NamespaceBody06(SyntaxToken tOpenBrace, SyntaxList<Declaration06Syntax> declaration06, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody06Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody06((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration06Green>(declaration06.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody06Syntax NamespaceBody06()
		{
			return this.NamespaceBody06(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration06Syntax Declaration06(Vertex06Syntax vertex06)
		{
		    if (vertex06 == null) throw new ArgumentNullException(nameof(vertex06));
		    return (Declaration06Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration06((Syntax.InternalSyntax.Vertex06Green)vertex06.Green).CreateRed();
		}
		
		public Declaration06Syntax Declaration06(Arrow06Syntax arrow06)
		{
		    if (arrow06 == null) throw new ArgumentNullException(nameof(arrow06));
		    return (Declaration06Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration06((Syntax.InternalSyntax.Arrow06Green)arrow06.Green).CreateRed();
		}
		
		public Vertex06Syntax Vertex06(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex06Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex06((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex06Syntax Vertex06(NameSyntax name)
		{
			return this.Vertex06(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow06Syntax Arrow06(SyntaxToken kArrow, NameSyntax source, SyntaxToken tArrow, NameSyntax target, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow06Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow06((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.NameGreen)source.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.NameGreen)target.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow06Syntax Arrow06(NameSyntax source, NameSyntax target)
		{
			return this.Arrow06(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Test07Syntax Test07(SyntaxToken kTest07, NamespaceDeclaration07Syntax namespaceDeclaration07)
		{
		    if (kTest07 == null) throw new ArgumentNullException(nameof(kTest07));
		    if (kTest07.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest07) throw new ArgumentException(nameof(kTest07));
		    if (namespaceDeclaration07 == null) throw new ArgumentNullException(nameof(namespaceDeclaration07));
		    return (Test07Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test07((InternalSyntaxToken)kTest07.Node, (Syntax.InternalSyntax.NamespaceDeclaration07Green)namespaceDeclaration07.Green).CreateRed();
		}
		
		public Test07Syntax Test07(NamespaceDeclaration07Syntax namespaceDeclaration07)
		{
			return this.Test07(this.Token(TestLanguageAnnotationsSyntaxKind.KTest07), namespaceDeclaration07);
		}
		
		public NamespaceDeclaration07Syntax NamespaceDeclaration07(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody07Syntax namespaceBody07)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody07 == null) throw new ArgumentNullException(nameof(namespaceBody07));
		    return (NamespaceDeclaration07Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration07((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody07Green)namespaceBody07.Green).CreateRed();
		}
		
		public NamespaceDeclaration07Syntax NamespaceDeclaration07(QualifiedNameSyntax qualifiedName, NamespaceBody07Syntax namespaceBody07)
		{
			return this.NamespaceDeclaration07(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody07);
		}
		
		public NamespaceBody07Syntax NamespaceBody07(SyntaxToken tOpenBrace, SyntaxList<Declaration07Syntax> declaration07, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody07Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody07((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration07Green>(declaration07.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody07Syntax NamespaceBody07()
		{
			return this.NamespaceBody07(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration07Syntax Declaration07(Vertex07Syntax vertex07)
		{
		    if (vertex07 == null) throw new ArgumentNullException(nameof(vertex07));
		    return (Declaration07Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration07((Syntax.InternalSyntax.Vertex07Green)vertex07.Green).CreateRed();
		}
		
		public Declaration07Syntax Declaration07(Arrow07Syntax arrow07)
		{
		    if (arrow07 == null) throw new ArgumentNullException(nameof(arrow07));
		    return (Declaration07Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration07((Syntax.InternalSyntax.Arrow07Green)arrow07.Green).CreateRed();
		}
		
		public Vertex07Syntax Vertex07(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex07Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex07((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex07Syntax Vertex07(NameSyntax name)
		{
			return this.Vertex07(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow07Syntax Arrow07(SyntaxToken kArrow, Source07Syntax source07, SyntaxToken tArrow, Target07Syntax target07, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source07 == null) throw new ArgumentNullException(nameof(source07));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target07 == null) throw new ArgumentNullException(nameof(target07));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow07Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow07((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.Source07Green)source07.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.Target07Green)target07.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow07Syntax Arrow07(Source07Syntax source07, Target07Syntax target07)
		{
			return this.Arrow07(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source07, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target07, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Source07Syntax Source07(NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (Source07Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Source07((Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public Target07Syntax Target07(NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (Target07Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Target07((Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public Test08Syntax Test08(SyntaxToken kTest08, NamespaceDeclaration08Syntax namespaceDeclaration08)
		{
		    if (kTest08 == null) throw new ArgumentNullException(nameof(kTest08));
		    if (kTest08.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest08) throw new ArgumentException(nameof(kTest08));
		    if (namespaceDeclaration08 == null) throw new ArgumentNullException(nameof(namespaceDeclaration08));
		    return (Test08Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test08((InternalSyntaxToken)kTest08.Node, (Syntax.InternalSyntax.NamespaceDeclaration08Green)namespaceDeclaration08.Green).CreateRed();
		}
		
		public Test08Syntax Test08(NamespaceDeclaration08Syntax namespaceDeclaration08)
		{
			return this.Test08(this.Token(TestLanguageAnnotationsSyntaxKind.KTest08), namespaceDeclaration08);
		}
		
		public NamespaceDeclaration08Syntax NamespaceDeclaration08(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody08Syntax namespaceBody08)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody08 == null) throw new ArgumentNullException(nameof(namespaceBody08));
		    return (NamespaceDeclaration08Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration08((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody08Green)namespaceBody08.Green).CreateRed();
		}
		
		public NamespaceDeclaration08Syntax NamespaceDeclaration08(QualifiedNameSyntax qualifiedName, NamespaceBody08Syntax namespaceBody08)
		{
			return this.NamespaceDeclaration08(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody08);
		}
		
		public NamespaceBody08Syntax NamespaceBody08(SyntaxToken tOpenBrace, SyntaxList<Declaration08Syntax> declaration08, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody08Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody08((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration08Green>(declaration08.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody08Syntax NamespaceBody08()
		{
			return this.NamespaceBody08(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration08Syntax Declaration08(Vertex08Syntax vertex08)
		{
		    if (vertex08 == null) throw new ArgumentNullException(nameof(vertex08));
		    return (Declaration08Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration08((Syntax.InternalSyntax.Vertex08Green)vertex08.Green).CreateRed();
		}
		
		public Declaration08Syntax Declaration08(Arrow08Syntax arrow08)
		{
		    if (arrow08 == null) throw new ArgumentNullException(nameof(arrow08));
		    return (Declaration08Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration08((Syntax.InternalSyntax.Arrow08Green)arrow08.Green).CreateRed();
		}
		
		public Vertex08Syntax Vertex08(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex08Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex08((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex08Syntax Vertex08(NameSyntax name)
		{
			return this.Vertex08(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow08Syntax Arrow08(SyntaxToken kArrow, Source08Syntax source08, SyntaxToken tArrow, Target08Syntax target08, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source08 == null) throw new ArgumentNullException(nameof(source08));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target08 == null) throw new ArgumentNullException(nameof(target08));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow08Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow08((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.Source08Green)source08.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.Target08Green)target08.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow08Syntax Arrow08(Source08Syntax source08, Target08Syntax target08)
		{
			return this.Arrow08(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source08, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target08, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Source08Syntax Source08(NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (Source08Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Source08((Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public Target08Syntax Target08(NameSyntax name)
		{
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    return (Target08Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Target08((Syntax.InternalSyntax.NameGreen)name.Green).CreateRed();
		}
		
		public Test09Syntax Test09(SyntaxToken kTest09, NamespaceDeclaration09Syntax namespaceDeclaration09)
		{
		    if (kTest09 == null) throw new ArgumentNullException(nameof(kTest09));
		    if (kTest09.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest09) throw new ArgumentException(nameof(kTest09));
		    if (namespaceDeclaration09 == null) throw new ArgumentNullException(nameof(namespaceDeclaration09));
		    return (Test09Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test09((InternalSyntaxToken)kTest09.Node, (Syntax.InternalSyntax.NamespaceDeclaration09Green)namespaceDeclaration09.Green).CreateRed();
		}
		
		public Test09Syntax Test09(NamespaceDeclaration09Syntax namespaceDeclaration09)
		{
			return this.Test09(this.Token(TestLanguageAnnotationsSyntaxKind.KTest09), namespaceDeclaration09);
		}
		
		public NamespaceDeclaration09Syntax NamespaceDeclaration09(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody09Syntax namespaceBody09)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody09 == null) throw new ArgumentNullException(nameof(namespaceBody09));
		    return (NamespaceDeclaration09Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration09((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody09Green)namespaceBody09.Green).CreateRed();
		}
		
		public NamespaceDeclaration09Syntax NamespaceDeclaration09(QualifiedNameSyntax qualifiedName, NamespaceBody09Syntax namespaceBody09)
		{
			return this.NamespaceDeclaration09(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody09);
		}
		
		public NamespaceBody09Syntax NamespaceBody09(SyntaxToken tOpenBrace, SyntaxList<Declaration09Syntax> declaration09, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody09Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody09((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration09Green>(declaration09.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody09Syntax NamespaceBody09()
		{
			return this.NamespaceBody09(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration09Syntax Declaration09(Vertex09Syntax vertex09)
		{
		    if (vertex09 == null) throw new ArgumentNullException(nameof(vertex09));
		    return (Declaration09Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration09((Syntax.InternalSyntax.Vertex09Green)vertex09.Green).CreateRed();
		}
		
		public Declaration09Syntax Declaration09(Arrow09Syntax arrow09)
		{
		    if (arrow09 == null) throw new ArgumentNullException(nameof(arrow09));
		    return (Declaration09Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration09((Syntax.InternalSyntax.Arrow09Green)arrow09.Green).CreateRed();
		}
		
		public Vertex09Syntax Vertex09(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex09Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex09((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex09Syntax Vertex09(NameSyntax name)
		{
			return this.Vertex09(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow09Syntax Arrow09(SyntaxToken kArrow, NameSyntax source, SyntaxToken tArrow, NameSyntax target, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow09Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow09((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.NameGreen)source.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.NameGreen)target.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow09Syntax Arrow09(NameSyntax source, NameSyntax target)
		{
			return this.Arrow09(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Test10Syntax Test10(SyntaxToken kTest10, NamespaceDeclaration10Syntax namespaceDeclaration10)
		{
		    if (kTest10 == null) throw new ArgumentNullException(nameof(kTest10));
		    if (kTest10.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest10) throw new ArgumentException(nameof(kTest10));
		    if (namespaceDeclaration10 == null) throw new ArgumentNullException(nameof(namespaceDeclaration10));
		    return (Test10Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test10((InternalSyntaxToken)kTest10.Node, (Syntax.InternalSyntax.NamespaceDeclaration10Green)namespaceDeclaration10.Green).CreateRed();
		}
		
		public Test10Syntax Test10(NamespaceDeclaration10Syntax namespaceDeclaration10)
		{
			return this.Test10(this.Token(TestLanguageAnnotationsSyntaxKind.KTest10), namespaceDeclaration10);
		}
		
		public NamespaceDeclaration10Syntax NamespaceDeclaration10(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody10Syntax namespaceBody10)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody10 == null) throw new ArgumentNullException(nameof(namespaceBody10));
		    return (NamespaceDeclaration10Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration10((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody10Green)namespaceBody10.Green).CreateRed();
		}
		
		public NamespaceDeclaration10Syntax NamespaceDeclaration10(QualifiedNameSyntax qualifiedName, NamespaceBody10Syntax namespaceBody10)
		{
			return this.NamespaceDeclaration10(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody10);
		}
		
		public NamespaceBody10Syntax NamespaceBody10(SyntaxToken tOpenBrace, SyntaxList<Declaration10Syntax> declaration10, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody10Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody10((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration10Green>(declaration10.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody10Syntax NamespaceBody10()
		{
			return this.NamespaceBody10(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration10Syntax Declaration10(Vertex10Syntax vertex10)
		{
		    if (vertex10 == null) throw new ArgumentNullException(nameof(vertex10));
		    return (Declaration10Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration10((Syntax.InternalSyntax.Vertex10Green)vertex10.Green).CreateRed();
		}
		
		public Declaration10Syntax Declaration10(Arrow10Syntax arrow10)
		{
		    if (arrow10 == null) throw new ArgumentNullException(nameof(arrow10));
		    return (Declaration10Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration10((Syntax.InternalSyntax.Arrow10Green)arrow10.Green).CreateRed();
		}
		
		public Vertex10Syntax Vertex10(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex10Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex10((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex10Syntax Vertex10(NameSyntax name)
		{
			return this.Vertex10(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow10Syntax Arrow10(SyntaxToken kArrow, NameSyntax source, SyntaxToken tArrow, NameSyntax target, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow10Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow10((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.NameGreen)source.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.NameGreen)target.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow10Syntax Arrow10(NameSyntax source, NameSyntax target)
		{
			return this.Arrow10(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Test11Syntax Test11(SyntaxToken kTest11, SyntaxList<NamespaceDeclaration11Syntax> namespaceDeclaration11)
		{
		    if (kTest11 == null) throw new ArgumentNullException(nameof(kTest11));
		    if (kTest11.GetKind() != TestLanguageAnnotationsSyntaxKind.KTest11) throw new ArgumentException(nameof(kTest11));
		    return (Test11Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Test11((InternalSyntaxToken)kTest11.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<NamespaceDeclaration11Green>(namespaceDeclaration11.Node)).CreateRed();
		}
		
		public Test11Syntax Test11()
		{
			return this.Test11(this.Token(TestLanguageAnnotationsSyntaxKind.KTest11), default);
		}
		
		public NamespaceDeclaration11Syntax NamespaceDeclaration11(SyntaxToken kNamespace, QualifiedNameSyntax qualifiedName, NamespaceBody11Syntax namespaceBody11)
		{
		    if (kNamespace == null) throw new ArgumentNullException(nameof(kNamespace));
		    if (kNamespace.GetKind() != TestLanguageAnnotationsSyntaxKind.KNamespace) throw new ArgumentException(nameof(kNamespace));
		    if (qualifiedName == null) throw new ArgumentNullException(nameof(qualifiedName));
		    if (namespaceBody11 == null) throw new ArgumentNullException(nameof(namespaceBody11));
		    return (NamespaceDeclaration11Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceDeclaration11((InternalSyntaxToken)kNamespace.Node, (Syntax.InternalSyntax.QualifiedNameGreen)qualifiedName.Green, (Syntax.InternalSyntax.NamespaceBody11Green)namespaceBody11.Green).CreateRed();
		}
		
		public NamespaceDeclaration11Syntax NamespaceDeclaration11(QualifiedNameSyntax qualifiedName, NamespaceBody11Syntax namespaceBody11)
		{
			return this.NamespaceDeclaration11(this.Token(TestLanguageAnnotationsSyntaxKind.KNamespace), qualifiedName, namespaceBody11);
		}
		
		public NamespaceBody11Syntax NamespaceBody11(SyntaxToken tOpenBrace, SyntaxList<Declaration11Syntax> declaration11, SyntaxToken tCloseBrace)
		{
		    if (tOpenBrace == null) throw new ArgumentNullException(nameof(tOpenBrace));
		    if (tOpenBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TOpenBrace) throw new ArgumentException(nameof(tOpenBrace));
		    if (tCloseBrace == null) throw new ArgumentNullException(nameof(tCloseBrace));
		    if (tCloseBrace.GetKind() != TestLanguageAnnotationsSyntaxKind.TCloseBrace) throw new ArgumentException(nameof(tCloseBrace));
		    return (NamespaceBody11Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NamespaceBody11((InternalSyntaxToken)tOpenBrace.Node, Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenList<Declaration11Green>(declaration11.Node), (InternalSyntaxToken)tCloseBrace.Node).CreateRed();
		}
		
		public NamespaceBody11Syntax NamespaceBody11()
		{
			return this.NamespaceBody11(this.Token(TestLanguageAnnotationsSyntaxKind.TOpenBrace), default, this.Token(TestLanguageAnnotationsSyntaxKind.TCloseBrace));
		}
		
		public Declaration11Syntax Declaration11(Vertex11Syntax vertex11)
		{
		    if (vertex11 == null) throw new ArgumentNullException(nameof(vertex11));
		    return (Declaration11Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration11((Syntax.InternalSyntax.Vertex11Green)vertex11.Green).CreateRed();
		}
		
		public Declaration11Syntax Declaration11(Arrow11Syntax arrow11)
		{
		    if (arrow11 == null) throw new ArgumentNullException(nameof(arrow11));
		    return (Declaration11Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Declaration11((Syntax.InternalSyntax.Arrow11Green)arrow11.Green).CreateRed();
		}
		
		public Vertex11Syntax Vertex11(SyntaxToken kVertex, NameSyntax name, SyntaxToken tSemicolon)
		{
		    if (kVertex == null) throw new ArgumentNullException(nameof(kVertex));
		    if (kVertex.GetKind() != TestLanguageAnnotationsSyntaxKind.KVertex) throw new ArgumentException(nameof(kVertex));
		    if (name == null) throw new ArgumentNullException(nameof(name));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Vertex11Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Vertex11((InternalSyntaxToken)kVertex.Node, (Syntax.InternalSyntax.NameGreen)name.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Vertex11Syntax Vertex11(NameSyntax name)
		{
			return this.Vertex11(this.Token(TestLanguageAnnotationsSyntaxKind.KVertex), name, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public Arrow11Syntax Arrow11(SyntaxToken kArrow, QualifiedNameSyntax source, SyntaxToken tArrow, QualifiedNameSyntax target, SyntaxToken tSemicolon)
		{
		    if (kArrow == null) throw new ArgumentNullException(nameof(kArrow));
		    if (kArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.KArrow) throw new ArgumentException(nameof(kArrow));
		    if (source == null) throw new ArgumentNullException(nameof(source));
		    if (tArrow == null) throw new ArgumentNullException(nameof(tArrow));
		    if (tArrow.GetKind() != TestLanguageAnnotationsSyntaxKind.TArrow) throw new ArgumentException(nameof(tArrow));
		    if (target == null) throw new ArgumentNullException(nameof(target));
		    if (tSemicolon == null) throw new ArgumentNullException(nameof(tSemicolon));
		    if (tSemicolon.GetKind() != TestLanguageAnnotationsSyntaxKind.TSemicolon) throw new ArgumentException(nameof(tSemicolon));
		    return (Arrow11Syntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Arrow11((InternalSyntaxToken)kArrow.Node, (Syntax.InternalSyntax.QualifiedNameGreen)source.Green, (InternalSyntaxToken)tArrow.Node, (Syntax.InternalSyntax.QualifiedNameGreen)target.Green, (InternalSyntaxToken)tSemicolon.Node).CreateRed();
		}
		
		public Arrow11Syntax Arrow11(QualifiedNameSyntax source, QualifiedNameSyntax target)
		{
			return this.Arrow11(this.Token(TestLanguageAnnotationsSyntaxKind.KArrow), source, this.Token(TestLanguageAnnotationsSyntaxKind.TArrow), target, this.Token(TestLanguageAnnotationsSyntaxKind.TSemicolon));
		}
		
		public NameSyntax Name(IdentifierSyntax identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (NameSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Name((Syntax.InternalSyntax.IdentifierGreen)identifier.Green).CreateRed();
		}
		
		public QualifiedNameSyntax QualifiedName(QualifierSyntax qualifier)
		{
		    if (qualifier == null) throw new ArgumentNullException(nameof(qualifier));
		    return (QualifiedNameSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.QualifiedName((Syntax.InternalSyntax.QualifierGreen)qualifier.Green).CreateRed();
		}
		
		public QualifierSyntax Qualifier(SeparatedSyntaxList<IdentifierSyntax> identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (QualifierSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Qualifier(Microsoft.CodeAnalysis.Syntax.InternalSyntax.GreenNodeExtensions.ToGreenSeparatedList<IdentifierGreen>(identifier.Node)).CreateRed();
		}
		
		public IdentifierSyntax Identifier(SyntaxToken identifier)
		{
		    if (identifier == null) throw new ArgumentNullException(nameof(identifier));
		    return (IdentifierSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Identifier((InternalSyntaxToken)identifier.Node).CreateRed();
		}
		
		public LiteralSyntax Literal(NullLiteralSyntax nullLiteral)
		{
		    if (nullLiteral == null) throw new ArgumentNullException(nameof(nullLiteral));
		    return (LiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.NullLiteralGreen)nullLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(BooleanLiteralSyntax booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (LiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.BooleanLiteralGreen)booleanLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(IntegerLiteralSyntax integerLiteral)
		{
		    if (integerLiteral == null) throw new ArgumentNullException(nameof(integerLiteral));
		    return (LiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.IntegerLiteralGreen)integerLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(DecimalLiteralSyntax decimalLiteral)
		{
		    if (decimalLiteral == null) throw new ArgumentNullException(nameof(decimalLiteral));
		    return (LiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.DecimalLiteralGreen)decimalLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(ScientificLiteralSyntax scientificLiteral)
		{
		    if (scientificLiteral == null) throw new ArgumentNullException(nameof(scientificLiteral));
		    return (LiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.ScientificLiteralGreen)scientificLiteral.Green).CreateRed();
		}
		
		public LiteralSyntax Literal(StringLiteralSyntax stringLiteral)
		{
		    if (stringLiteral == null) throw new ArgumentNullException(nameof(stringLiteral));
		    return (LiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.Literal((Syntax.InternalSyntax.StringLiteralGreen)stringLiteral.Green).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral(SyntaxToken kNull)
		{
		    if (kNull == null) throw new ArgumentNullException(nameof(kNull));
		    if (kNull.GetKind() != TestLanguageAnnotationsSyntaxKind.KNull) throw new ArgumentException(nameof(kNull));
		    return (NullLiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.NullLiteral((InternalSyntaxToken)kNull.Node).CreateRed();
		}
		
		public NullLiteralSyntax NullLiteral()
		{
			return this.NullLiteral(this.Token(TestLanguageAnnotationsSyntaxKind.KNull));
		}
		
		public BooleanLiteralSyntax BooleanLiteral(SyntaxToken booleanLiteral)
		{
		    if (booleanLiteral == null) throw new ArgumentNullException(nameof(booleanLiteral));
		    return (BooleanLiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.BooleanLiteral((InternalSyntaxToken)booleanLiteral.Node).CreateRed();
		}
		
		public IntegerLiteralSyntax IntegerLiteral(SyntaxToken lInteger)
		{
		    if (lInteger == null) throw new ArgumentNullException(nameof(lInteger));
		    if (lInteger.GetKind() != TestLanguageAnnotationsSyntaxKind.LInteger) throw new ArgumentException(nameof(lInteger));
		    return (IntegerLiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.IntegerLiteral((InternalSyntaxToken)lInteger.Node).CreateRed();
		}
		
		public DecimalLiteralSyntax DecimalLiteral(SyntaxToken lDecimal)
		{
		    if (lDecimal == null) throw new ArgumentNullException(nameof(lDecimal));
		    if (lDecimal.GetKind() != TestLanguageAnnotationsSyntaxKind.LDecimal) throw new ArgumentException(nameof(lDecimal));
		    return (DecimalLiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.DecimalLiteral((InternalSyntaxToken)lDecimal.Node).CreateRed();
		}
		
		public ScientificLiteralSyntax ScientificLiteral(SyntaxToken lScientific)
		{
		    if (lScientific == null) throw new ArgumentNullException(nameof(lScientific));
		    if (lScientific.GetKind() != TestLanguageAnnotationsSyntaxKind.LScientific) throw new ArgumentException(nameof(lScientific));
		    return (ScientificLiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.ScientificLiteral((InternalSyntaxToken)lScientific.Node).CreateRed();
		}
		
		public StringLiteralSyntax StringLiteral(SyntaxToken lRegularString)
		{
		    if (lRegularString == null) throw new ArgumentNullException(nameof(lRegularString));
		    if (lRegularString.GetKind() != TestLanguageAnnotationsSyntaxKind.LRegularString) throw new ArgumentException(nameof(lRegularString));
		    return (StringLiteralSyntax)TestLanguageAnnotationsLanguage.Instance.InternalSyntaxFactory.StringLiteral((InternalSyntaxToken)lRegularString.Node).CreateRed();
		}
	
	    internal static IEnumerable<Type> GetNodeTypes()
	    {
	        return new Type[] {
				typeof(MainSyntax),
				typeof(TestSyntax),
				typeof(Test01Syntax),
				typeof(NamespaceDeclaration01Syntax),
				typeof(NamespaceBody01Syntax),
				typeof(Declaration01Syntax),
				typeof(Vertex01Syntax),
				typeof(Arrow01Syntax),
				typeof(Test02Syntax),
				typeof(NamespaceDeclaration02Syntax),
				typeof(NamespaceBody02Syntax),
				typeof(Declaration02Syntax),
				typeof(Vertex02Syntax),
				typeof(Arrow02Syntax),
				typeof(Source02Syntax),
				typeof(Target02Syntax),
				typeof(Test03Syntax),
				typeof(NamespaceDeclaration03Syntax),
				typeof(NamespaceBody03Syntax),
				typeof(Declaration03Syntax),
				typeof(Vertex03Syntax),
				typeof(Arrow03Syntax),
				typeof(Source03Syntax),
				typeof(Target03Syntax),
				typeof(Test04Syntax),
				typeof(NamespaceDeclaration04Syntax),
				typeof(NamespaceBody04Syntax),
				typeof(Declaration04Syntax),
				typeof(Vertex04Syntax),
				typeof(Arrow04Syntax),
				typeof(Test05Syntax),
				typeof(NamespaceDeclaration05Syntax),
				typeof(NamespaceBody05Syntax),
				typeof(Declaration05Syntax),
				typeof(Vertex05Syntax),
				typeof(Arrow05Syntax),
				typeof(Test06Syntax),
				typeof(NamespaceDeclaration06Syntax),
				typeof(NamespaceBody06Syntax),
				typeof(Declaration06Syntax),
				typeof(Vertex06Syntax),
				typeof(Arrow06Syntax),
				typeof(Test07Syntax),
				typeof(NamespaceDeclaration07Syntax),
				typeof(NamespaceBody07Syntax),
				typeof(Declaration07Syntax),
				typeof(Vertex07Syntax),
				typeof(Arrow07Syntax),
				typeof(Source07Syntax),
				typeof(Target07Syntax),
				typeof(Test08Syntax),
				typeof(NamespaceDeclaration08Syntax),
				typeof(NamespaceBody08Syntax),
				typeof(Declaration08Syntax),
				typeof(Vertex08Syntax),
				typeof(Arrow08Syntax),
				typeof(Source08Syntax),
				typeof(Target08Syntax),
				typeof(Test09Syntax),
				typeof(NamespaceDeclaration09Syntax),
				typeof(NamespaceBody09Syntax),
				typeof(Declaration09Syntax),
				typeof(Vertex09Syntax),
				typeof(Arrow09Syntax),
				typeof(Test10Syntax),
				typeof(NamespaceDeclaration10Syntax),
				typeof(NamespaceBody10Syntax),
				typeof(Declaration10Syntax),
				typeof(Vertex10Syntax),
				typeof(Arrow10Syntax),
				typeof(Test11Syntax),
				typeof(NamespaceDeclaration11Syntax),
				typeof(NamespaceBody11Syntax),
				typeof(Declaration11Syntax),
				typeof(Vertex11Syntax),
				typeof(Arrow11Syntax),
				typeof(NameSyntax),
				typeof(QualifiedNameSyntax),
				typeof(QualifierSyntax),
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

