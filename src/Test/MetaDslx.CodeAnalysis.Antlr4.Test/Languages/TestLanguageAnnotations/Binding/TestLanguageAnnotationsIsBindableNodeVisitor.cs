// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Symbols;

using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Binding
{
	// Make sure to keep this in sync with TestLanguageAnnotationsBoundNodeFactoryVisitor
    public class TestLanguageAnnotationsIsBindableNodeVisitor : IsBindableNodeVisitor, ITestLanguageAnnotationsSyntaxVisitor<bool>
    {
        public TestLanguageAnnotationsIsBindableNodeVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

		
		public bool VisitMain(MainSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Test != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Test.Node))
					{
						foreach (var item in node.Test)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest(TestSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Test01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test01))
						{
							if (this.Visit(node.Test01)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test01)) return true;
					}
				}
				if (node.Test02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test02))
						{
							if (this.Visit(node.Test02)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test02)) return true;
					}
				}
				if (node.Test03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test03))
						{
							if (this.Visit(node.Test03)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test03)) return true;
					}
				}
				if (node.Test04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test04))
						{
							if (this.Visit(node.Test04)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test04)) return true;
					}
				}
				if (node.Test05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test05))
						{
							if (this.Visit(node.Test05)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test05)) return true;
					}
				}
				if (node.Test06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test06))
						{
							if (this.Visit(node.Test06)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test06)) return true;
					}
				}
				if (node.Test07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test07))
						{
							if (this.Visit(node.Test07)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test07)) return true;
					}
				}
				if (node.Test08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test08))
						{
							if (this.Visit(node.Test08)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test08)) return true;
					}
				}
				if (node.Test09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test09))
						{
							if (this.Visit(node.Test09)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test09)) return true;
					}
				}
				if (node.Test10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test10))
						{
							if (this.Visit(node.Test10)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test10)) return true;
					}
				}
				if (node.Test11 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Test11))
						{
							if (this.Visit(node.Test11)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Test11)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest01(Test01Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration01))
						{
							if (this.Visit(node.NamespaceDeclaration01)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration01)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration01(NamespaceDeclaration01Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody01))
						{
							if (this.Visit(node.NamespaceBody01)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody01)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody01(NamespaceBody01Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration01 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration01.Node))
					{
						foreach (var item in node.Declaration01)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration01(Declaration01Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Vertex01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex01))
						{
							if (this.Visit(node.Vertex01)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex01)) return true;
					}
				}
				if (node.Arrow01 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow01))
						{
							if (this.Visit(node.Arrow01)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow01)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex01(Vertex01Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow01(Arrow01Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Source)) return true;
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Target)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest02(Test02Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration02))
						{
							if (this.Visit(node.NamespaceDeclaration02)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration02)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration02(NamespaceDeclaration02Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody02))
						{
							if (this.Visit(node.NamespaceBody02)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody02)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody02(NamespaceBody02Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration02 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration02.Node))
					{
						foreach (var item in node.Declaration02)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration02(Declaration02Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Vertex02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex02))
						{
							if (this.Visit(node.Vertex02)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex02)) return true;
					}
				}
				if (node.Arrow02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow02))
						{
							if (this.Visit(node.Arrow02)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow02)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex02(Vertex02Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow02(Arrow02Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source02))
						{
							if (this.Visit(node.Source02)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Source02)) return true;
					}
				}
				if (node.Target02 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target02))
						{
							if (this.Visit(node.Target02)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Target02)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSource02(Source02Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							if (this.Visit(node.Qualifier)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTarget02(Target02Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							if (this.Visit(node.Qualifier)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest03(Test03Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration03))
						{
							if (this.Visit(node.NamespaceDeclaration03)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration03)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration03(NamespaceDeclaration03Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody03))
						{
							if (this.Visit(node.NamespaceBody03)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody03)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody03(NamespaceBody03Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration03 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration03.Node))
					{
						foreach (var item in node.Declaration03)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration03(Declaration03Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Vertex03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex03))
						{
							if (this.Visit(node.Vertex03)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex03)) return true;
					}
				}
				if (node.Arrow03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow03))
						{
							if (this.Visit(node.Arrow03)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow03)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex03(Vertex03Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow03(Arrow03Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source03))
						{
							if (this.Visit(node.Source03)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Source03)) return true;
					}
				}
				if (node.Target03 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target03))
						{
							if (this.Visit(node.Target03)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Target03)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSource03(Source03Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTarget03(Target03Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest04(Test04Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration04))
						{
							if (this.Visit(node.NamespaceDeclaration04)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration04)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration04(NamespaceDeclaration04Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody04))
						{
							if (this.Visit(node.NamespaceBody04)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody04)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody04(NamespaceBody04Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration04 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration04.Node))
					{
						foreach (var item in node.Declaration04)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration04(Declaration04Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Vertex04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex04))
						{
							if (this.Visit(node.Vertex04)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex04)) return true;
					}
				}
				if (node.Arrow04 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow04))
						{
							if (this.Visit(node.Arrow04)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow04)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex04(Vertex04Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow04(Arrow04Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Source)) return true;
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Target)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest05(Test05Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration05))
						{
							if (this.Visit(node.NamespaceDeclaration05)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration05)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration05(NamespaceDeclaration05Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody05))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody05)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody05(NamespaceBody05Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Declaration05 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration05.Node))
					{
						foreach (var item in node.Declaration05)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration05(Declaration05Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Vertex05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex05))
						{
							if (this.Visit(node.Vertex05)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex05)) return true;
					}
				}
				if (node.Arrow05 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow05))
						{
							if (this.Visit(node.Arrow05)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow05)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex05(Vertex05Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow05(Arrow05Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Source)) return true;
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Target)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest06(Test06Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration06))
						{
							if (this.Visit(node.NamespaceDeclaration06)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration06)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration06(NamespaceDeclaration06Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody06))
						{
							if (this.Visit(node.NamespaceBody06)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody06)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody06(NamespaceBody06Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration06 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration06.Node))
					{
						foreach (var item in node.Declaration06)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration06(Declaration06Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Vertex06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex06))
						{
							if (this.Visit(node.Vertex06)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex06)) return true;
					}
				}
				if (node.Arrow06 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow06))
						{
							if (this.Visit(node.Arrow06)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow06)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex06(Vertex06Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow06(Arrow06Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Source)) return true;
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Target)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest07(Test07Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration07))
						{
							if (this.Visit(node.NamespaceDeclaration07)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration07)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration07(NamespaceDeclaration07Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody07))
						{
							if (this.Visit(node.NamespaceBody07)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody07)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody07(NamespaceBody07Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration07 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration07.Node))
					{
						foreach (var item in node.Declaration07)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration07(Declaration07Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Vertex07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex07))
						{
							if (this.Visit(node.Vertex07)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex07)) return true;
					}
				}
				if (node.Arrow07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow07))
						{
							if (this.Visit(node.Arrow07)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow07)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex07(Vertex07Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow07(Arrow07Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source07))
						{
							if (this.Visit(node.Source07)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Source07)) return true;
					}
				}
				if (node.Target07 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target07))
						{
							if (this.Visit(node.Target07)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Target07)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSource07(Source07Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTarget07(Target07Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest08(Test08Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration08))
						{
							if (this.Visit(node.NamespaceDeclaration08)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration08)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration08(NamespaceDeclaration08Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody08))
						{
							if (this.Visit(node.NamespaceBody08)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody08)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody08(NamespaceBody08Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration08 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration08.Node))
					{
						foreach (var item in node.Declaration08)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration08(Declaration08Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Vertex08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex08))
						{
							if (this.Visit(node.Vertex08)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex08)) return true;
					}
				}
				if (node.Arrow08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow08))
						{
							if (this.Visit(node.Arrow08)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow08)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex08(Vertex08Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow08(Arrow08Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source08))
						{
							if (this.Visit(node.Source08)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Source08)) return true;
					}
				}
				if (node.Target08 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target08))
						{
							if (this.Visit(node.Target08)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Target08)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSource08(Source08Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTarget08(Target08Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest09(Test09Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration09))
						{
							if (this.Visit(node.NamespaceDeclaration09)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration09)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration09(NamespaceDeclaration09Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody09))
						{
							if (this.Visit(node.NamespaceBody09)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody09)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody09(NamespaceBody09Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration09 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration09.Node))
					{
						foreach (var item in node.Declaration09)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration09(Declaration09Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Vertex09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex09))
						{
							if (this.Visit(node.Vertex09)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex09)) return true;
					}
				}
				if (node.Arrow09 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow09))
						{
							if (this.Visit(node.Arrow09)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow09)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex09(Vertex09Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow09(Arrow09Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Source)) return true;
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Target)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest10(Test10Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration10))
						{
							if (this.Visit(node.NamespaceDeclaration10)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration10)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration10(NamespaceDeclaration10Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody10))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody10)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody10(NamespaceBody10Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Declaration10 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration10.Node))
					{
						foreach (var item in node.Declaration10)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration10(Declaration10Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Vertex10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex10))
						{
							if (this.Visit(node.Vertex10)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex10)) return true;
					}
				}
				if (node.Arrow10 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow10))
						{
							if (this.Visit(node.Arrow10)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow10)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex10(Vertex10Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow10(Arrow10Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Source)) return true;
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Target)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTest11(Test11Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration11 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration11.Node))
					{
						foreach (var item in node.NamespaceDeclaration11)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceDeclaration11(NamespaceDeclaration11Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.QualifiedName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QualifiedName))
						{
							if (this.Visit(node.QualifiedName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QualifiedName)) return true;
					}
				}
				if (node.NamespaceBody11 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody11))
						{
							if (this.Visit(node.NamespaceBody11)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody11)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody11(NamespaceBody11Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Declaration11 != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration11.Node))
					{
						foreach (var item in node.Declaration11)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDeclaration11(Declaration11Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Vertex11 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Vertex11))
						{
							if (this.Visit(node.Vertex11)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Vertex11)) return true;
					}
				}
				if (node.Arrow11 != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow11))
						{
							if (this.Visit(node.Arrow11)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Arrow11)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVertex11(Vertex11Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitArrow11(Arrow11Syntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Source)) return true;
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Target)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitName(NameSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							if (this.Visit(node.Identifier)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Identifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQualifiedName(QualifiedNameSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Qualifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Qualifier))
						{
							if (this.Visit(node.Qualifier)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Qualifier)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQualifier(QualifierSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				if (node.Identifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Identifier.Node))
					{
						foreach (var item in node.Identifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitIdentifier(IdentifierSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitLiteral(LiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NullLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NullLiteral))
						{
							if (this.Visit(node.NullLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NullLiteral)) return true;
					}
				}
				if (node.BooleanLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BooleanLiteral))
						{
							if (this.Visit(node.BooleanLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BooleanLiteral)) return true;
					}
				}
				if (node.IntegerLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.IntegerLiteral))
						{
							if (this.Visit(node.IntegerLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.IntegerLiteral)) return true;
					}
				}
				if (node.DecimalLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DecimalLiteral))
						{
							if (this.Visit(node.DecimalLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DecimalLiteral)) return true;
					}
				}
				if (node.ScientificLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ScientificLiteral))
						{
							if (this.Visit(node.ScientificLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ScientificLiteral)) return true;
					}
				}
				if (node.StringLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
						{
							if (this.Visit(node.StringLiteral)) return true;
						}
					}
					else
					{
						if (this.Visit(node.StringLiteral)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNullLiteral(NullLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitStringLiteral(StringLiteralSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode) 
				{
					return true;
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
    }
}

