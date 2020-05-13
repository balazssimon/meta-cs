// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Symbols;

using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Binding
{
	public class TestLanguageAnnotationsDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, ITestLanguageAnnotationsSyntaxVisitor
	{
        protected TestLanguageAnnotationsDeclarationTreeBuilderVisitor(TestLanguageAnnotationsSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            TestLanguageAnnotationsSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new TestLanguageAnnotationsDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }
		
		public virtual void VisitMain(MainSyntax node)
		{
			if (node.Test != null)
			{
				foreach (var child in node.Test)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitTest(TestSyntax node)
		{
			this.Visit(node.Test01);
			this.Visit(node.Test02);
			this.Visit(node.Test03);
			this.Visit(node.Test04);
			this.Visit(node.Test05);
			this.Visit(node.Test06);
			this.Visit(node.Test07);
			this.Visit(node.Test08);
			this.Visit(node.Test09);
			this.Visit(node.Test10);
			this.Visit(node.Test11);
		}
		
		public virtual void VisitTest01(Test01Syntax node)
		{
			this.Visit(node.NamespaceDeclaration01);
		}
		
		public virtual void VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody01);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody01(NamespaceBody01Syntax node)
		{
			this.BeginScope(node);
			try
			{
				this.BeginProperty(node, name: "Declarations");
				try
				{
					if (node.Declaration01 != null)
					{
						foreach (var child in node.Declaration01)
						{
							this.Visit(child);
						}
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration01(Declaration01Syntax node)
		{
			this.Visit(node.Vertex01);
			this.Visit(node.Arrow01);
		}
		
		public virtual void VisitVertex01(Vertex01Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Vertex));
			try
			{
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitArrow01(Arrow01Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Arrow));
			try
			{
				this.BeginProperty(node.Source, name: "Source");
				try
				{
					this.BeginSymbolUse(node.Source, types: ImmutableArray.Create(typeof(Vertex)));
					try
					{
						this.Visit(node.Source);
					}
					finally
					{
						this.EndSymbolUse();
					}
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Target, name: "Target");
				try
				{
					this.BeginSymbolUse(node.Target, types: ImmutableArray.Create(typeof(Vertex)));
					try
					{
						this.Visit(node.Target);
					}
					finally
					{
						this.EndSymbolUse();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTest02(Test02Syntax node)
		{
			this.Visit(node.NamespaceDeclaration02);
		}
		
		public virtual void VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody02);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody02(NamespaceBody02Syntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.Declaration02 != null)
				{
					foreach (var child in node.Declaration02)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration02(Declaration02Syntax node)
		{
			this.Visit(node.Vertex02);
			this.Visit(node.Arrow02);
		}
		
		public virtual void VisitVertex02(Vertex02Syntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Vertex));
				try
				{
					this.Visit(node.Name);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitArrow02(Arrow02Syntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Arrow));
				try
				{
					this.Visit(node.Source02);
					this.Visit(node.Target02);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitSource02(Source02Syntax node)
		{
			this.BeginProperty(node, name: "Source");
			try
			{
				this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(Vertex)));
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndSymbolUse();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTarget02(Target02Syntax node)
		{
			this.BeginProperty(node, name: "Target");
			try
			{
				this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(Vertex)));
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndSymbolUse();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTest03(Test03Syntax node)
		{
			this.Visit(node.NamespaceDeclaration03);
		}
		
		public virtual void VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody03);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody03(NamespaceBody03Syntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.Declaration03 != null)
				{
					foreach (var child in node.Declaration03)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration03(Declaration03Syntax node)
		{
			this.Visit(node.Vertex03);
			this.Visit(node.Arrow03);
		}
		
		public virtual void VisitVertex03(Vertex03Syntax node)
		{
			this.BeginProperty(node.Name, name: "Declarations");
			try
			{
				this.BeginSymbolDef(node.Name, type: typeof(Vertex));
				try
				{
					this.Visit(node.Name);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitArrow03(Arrow03Syntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Arrow));
				try
				{
					this.Visit(node.Source03);
					this.Visit(node.Target03);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitSource03(Source03Syntax node)
		{
			this.BeginProperty(node.Qualifier, name: "Source");
			try
			{
				this.BeginSymbolUse(node.Qualifier, types: ImmutableArray.Create(typeof(Vertex)));
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndSymbolUse();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTarget03(Target03Syntax node)
		{
			this.BeginProperty(node.Qualifier, name: "Target");
			try
			{
				this.BeginSymbolUse(node.Qualifier, types: ImmutableArray.Create(typeof(Vertex)));
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndSymbolUse();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTest04(Test04Syntax node)
		{
			this.Visit(node.NamespaceDeclaration04);
		}
		
		public virtual void VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody04);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody04(NamespaceBody04Syntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.Declaration04 != null)
				{
					foreach (var child in node.Declaration04)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration04(Declaration04Syntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.Visit(node.Vertex04);
				this.Visit(node.Arrow04);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitVertex04(Vertex04Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Vertex));
			try
			{
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitArrow04(Arrow04Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Arrow));
			try
			{
				this.BeginProperty(node.Source, name: "Source");
				try
				{
					this.BeginSymbolUse(node.Source, types: ImmutableArray.Create(typeof(Vertex)));
					try
					{
						this.Visit(node.Source);
					}
					finally
					{
						this.EndSymbolUse();
					}
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Target, name: "Target");
				try
				{
					this.BeginSymbolUse(node.Target, types: ImmutableArray.Create(typeof(Vertex)));
					try
					{
						this.Visit(node.Target);
					}
					finally
					{
						this.EndSymbolUse();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTest05(Test05Syntax node)
		{
			this.Visit(node.NamespaceDeclaration05);
		}
		
		public virtual void VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.BeginScope(node.NamespaceBody05);
				try
				{
					this.BeginProperty(node.NamespaceBody05, name: "Declarations");
					try
					{
						this.Visit(node.NamespaceBody05);
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndScope();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody05(NamespaceBody05Syntax node)
		{
			if (node.Declaration05 != null)
			{
				foreach (var child in node.Declaration05)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitDeclaration05(Declaration05Syntax node)
		{
			this.Visit(node.Vertex05);
			this.Visit(node.Arrow05);
		}
		
		public virtual void VisitVertex05(Vertex05Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Vertex));
			try
			{
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitArrow05(Arrow05Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Arrow));
			try
			{
				this.BeginProperty(node.Source, name: "Source");
				try
				{
					this.BeginSymbolUse(node.Source, types: ImmutableArray.Create(typeof(Vertex)));
					try
					{
						this.Visit(node.Source);
					}
					finally
					{
						this.EndSymbolUse();
					}
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Target, name: "Target");
				try
				{
					this.BeginSymbolUse(node.Target, types: ImmutableArray.Create(typeof(Vertex)));
					try
					{
						this.Visit(node.Target);
					}
					finally
					{
						this.EndSymbolUse();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTest06(Test06Syntax node)
		{
			this.Visit(node.NamespaceDeclaration06);
		}
		
		public virtual void VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody06);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody06(NamespaceBody06Syntax node)
		{
			this.BeginScope(node);
			try
			{
				this.BeginProperty(node, name: "Declarations");
				try
				{
					if (node.Declaration06 != null)
					{
						foreach (var child in node.Declaration06)
						{
							this.Visit(child);
						}
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration06(Declaration06Syntax node)
		{
			this.Visit(node.Vertex06);
			this.Visit(node.Arrow06);
		}
		
		public virtual void VisitVertex06(Vertex06Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Vertex), merge: true);
			try
			{
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitArrow06(Arrow06Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Arrow));
			try
			{
				this.BeginProperty(node.Source, name: "Source");
				try
				{
					this.BeginProperty(node.Source, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
					try
					{
						this.BeginSymbolDef(node.Source, type: typeof(Vertex), merge: true);
						try
						{
							this.Visit(node.Source);
						}
						finally
						{
							this.EndSymbolDef();
						}
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Target, name: "Target");
				try
				{
					this.BeginProperty(node.Target, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
					try
					{
						this.BeginSymbolDef(node.Target, type: typeof(Vertex), merge: true);
						try
						{
							this.Visit(node.Target);
						}
						finally
						{
							this.EndSymbolDef();
						}
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTest07(Test07Syntax node)
		{
			this.Visit(node.NamespaceDeclaration07);
		}
		
		public virtual void VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody07);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody07(NamespaceBody07Syntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.Declaration07 != null)
				{
					foreach (var child in node.Declaration07)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration07(Declaration07Syntax node)
		{
			this.Visit(node.Vertex07);
			this.Visit(node.Arrow07);
		}
		
		public virtual void VisitVertex07(Vertex07Syntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Vertex), merge: true);
				try
				{
					this.Visit(node.Name);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitArrow07(Arrow07Syntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Arrow));
				try
				{
					this.Visit(node.Source07);
					this.Visit(node.Target07);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitSource07(Source07Syntax node)
		{
			this.BeginProperty(node, name: "Source");
			try
			{
				this.BeginProperty(node, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
				try
				{
					this.BeginSymbolDef(node, type: typeof(Vertex), merge: true);
					try
					{
						this.Visit(node.Name);
					}
					finally
					{
						this.EndSymbolDef();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTarget07(Target07Syntax node)
		{
			this.BeginProperty(node, name: "Target");
			try
			{
				this.BeginProperty(node, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
				try
				{
					this.BeginSymbolDef(node, type: typeof(Vertex), merge: true);
					try
					{
						this.Visit(node.Name);
					}
					finally
					{
						this.EndSymbolDef();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTest08(Test08Syntax node)
		{
			this.Visit(node.NamespaceDeclaration08);
		}
		
		public virtual void VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody08);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody08(NamespaceBody08Syntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.Declaration08 != null)
				{
					foreach (var child in node.Declaration08)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration08(Declaration08Syntax node)
		{
			this.Visit(node.Vertex08);
			this.Visit(node.Arrow08);
		}
		
		public virtual void VisitVertex08(Vertex08Syntax node)
		{
			this.BeginProperty(node.Name, name: "Declarations");
			try
			{
				this.BeginSymbolDef(node.Name, type: typeof(Vertex), merge: true);
				try
				{
					this.Visit(node.Name);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitArrow08(Arrow08Syntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Arrow));
				try
				{
					this.Visit(node.Source08);
					this.Visit(node.Target08);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitSource08(Source08Syntax node)
		{
			this.BeginProperty(node.Name, name: "Source");
			try
			{
				this.BeginProperty(node.Name, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
				try
				{
					this.BeginSymbolDef(node.Name, type: typeof(Vertex), merge: true);
					try
					{
						this.Visit(node.Name);
					}
					finally
					{
						this.EndSymbolDef();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTarget08(Target08Syntax node)
		{
			this.BeginProperty(node.Name, name: "Target");
			try
			{
				this.BeginProperty(node.Name, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
				try
				{
					this.BeginSymbolDef(node.Name, type: typeof(Vertex), merge: true);
					try
					{
						this.Visit(node.Name);
					}
					finally
					{
						this.EndSymbolDef();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTest09(Test09Syntax node)
		{
			this.Visit(node.NamespaceDeclaration09);
		}
		
		public virtual void VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody09);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody09(NamespaceBody09Syntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.Declaration09 != null)
				{
					foreach (var child in node.Declaration09)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration09(Declaration09Syntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.Visit(node.Vertex09);
				this.Visit(node.Arrow09);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitVertex09(Vertex09Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Vertex), merge: true);
			try
			{
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitArrow09(Arrow09Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Arrow));
			try
			{
				this.BeginProperty(node.Source, name: "Source");
				try
				{
					this.BeginProperty(node.Source, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
					try
					{
						this.BeginSymbolDef(node.Source, type: typeof(Vertex), merge: true);
						try
						{
							this.Visit(node.Source);
						}
						finally
						{
							this.EndSymbolDef();
						}
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Target, name: "Target");
				try
				{
					this.BeginProperty(node.Target, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
					try
					{
						this.BeginSymbolDef(node.Target, type: typeof(Vertex), merge: true);
						try
						{
							this.Visit(node.Target);
						}
						finally
						{
							this.EndSymbolDef();
						}
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTest10(Test10Syntax node)
		{
			this.Visit(node.NamespaceDeclaration10);
		}
		
		public virtual void VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.BeginScope(node.NamespaceBody10);
				try
				{
					this.BeginProperty(node.NamespaceBody10, name: "Declarations");
					try
					{
						this.Visit(node.NamespaceBody10);
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndScope();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody10(NamespaceBody10Syntax node)
		{
			if (node.Declaration10 != null)
			{
				foreach (var child in node.Declaration10)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitDeclaration10(Declaration10Syntax node)
		{
			this.Visit(node.Vertex10);
			this.Visit(node.Arrow10);
		}
		
		public virtual void VisitVertex10(Vertex10Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Vertex), merge: true);
			try
			{
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitArrow10(Arrow10Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Arrow));
			try
			{
				this.BeginProperty(node.Source, name: "Source");
				try
				{
					this.BeginProperty(node.Source, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
					try
					{
						this.BeginSymbolDef(node.Source, type: typeof(Vertex), merge: true);
						try
						{
							this.Visit(node.Source);
						}
						finally
						{
							this.EndSymbolDef();
						}
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Target, name: "Target");
				try
				{
					this.BeginProperty(node.Target, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
					try
					{
						this.BeginSymbolDef(node.Target, type: typeof(Vertex), merge: true);
						try
						{
							this.Visit(node.Target);
						}
						finally
						{
							this.EndSymbolDef();
						}
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTest11(Test11Syntax node)
		{
			if (node.NamespaceDeclaration11 != null)
			{
				foreach (var child in node.NamespaceDeclaration11)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody11);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody11(NamespaceBody11Syntax node)
		{
			this.BeginScope(node);
			try
			{
				this.BeginProperty(node, name: "Declarations");
				try
				{
					if (node.Declaration11 != null)
					{
						foreach (var child in node.Declaration11)
						{
							this.Visit(child);
						}
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration11(Declaration11Syntax node)
		{
			this.Visit(node.Vertex11);
			this.Visit(node.Arrow11);
		}
		
		public virtual void VisitVertex11(Vertex11Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Vertex));
			try
			{
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitArrow11(Arrow11Syntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Arrow));
			try
			{
				this.BeginProperty(node.Source, name: "Source");
				try
				{
					this.BeginSymbolUse(node.Source, types: ImmutableArray.Create(typeof(Vertex)));
					try
					{
						this.Visit(node.Source);
					}
					finally
					{
						this.EndSymbolUse();
					}
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Target, name: "Target");
				try
				{
					this.BeginSymbolUse(node.Target, types: ImmutableArray.Create(typeof(Vertex)));
					try
					{
						this.Visit(node.Target);
					}
					finally
					{
						this.EndSymbolUse();
					}
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName(node);
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.BeginName(node);
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
			this.BeginQualifier(node);
			try
			{
				if (node.Identifier != null)
				{
					foreach (var child in node.Identifier)
					{
						this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndQualifier();
			}
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
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
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
		}
	}
}

