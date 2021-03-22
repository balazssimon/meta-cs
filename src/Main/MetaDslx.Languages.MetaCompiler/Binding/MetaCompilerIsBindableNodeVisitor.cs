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
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;
using MetaDslx.Languages.MetaCompiler;
using MetaDslx.Languages.MetaCompiler.Syntax;
using MetaDslx.Languages.MetaCompiler.Symbols;

using MetaDslx.Languages.MetaCompiler.Model;

namespace MetaDslx.Languages.MetaCompiler.Binding
{
	// Make sure to keep this in sync with MetaCompilerBoundNodeFactoryVisitor
    public class MetaCompilerIsBindableNodeVisitor : IsBindableNodeVisitor, IMetaCompilerSyntaxVisitor<bool>
    {
        public MetaCompilerIsBindableNodeVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

		public virtual bool VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node)
		{
            return false;
		}

		
		public bool VisitMain(MainSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.NamespaceDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceDeclaration))
						{
							if (this.Visit(node.NamespaceDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceDeclaration)) return true;
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
		
		public bool VisitAttribute(AttributeSyntax node)
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
		
		public bool VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
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
				if (node.NamespaceBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NamespaceBody))
						{
							if (this.Visit(node.NamespaceBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NamespaceBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNamespaceBody(NamespaceBodySyntax node)
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
				if (node.Declaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Declaration.Node))
					{
						foreach (var item in node.Declaration)
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
		
		public bool VisitDeclaration(DeclarationSyntax node)
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
				if (node.TypedefDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypedefDeclaration))
						{
							if (this.Visit(node.TypedefDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TypedefDeclaration)) return true;
					}
				}
				if (node.CompilerDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CompilerDeclaration))
						{
							if (this.Visit(node.CompilerDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CompilerDeclaration)) return true;
					}
				}
				if (node.PhaseDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PhaseDeclaration))
						{
							if (this.Visit(node.PhaseDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.PhaseDeclaration)) return true;
					}
				}
				if (node.EnumDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumDeclaration))
						{
							if (this.Visit(node.EnumDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EnumDeclaration)) return true;
					}
				}
				if (node.ClassDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassDeclaration))
						{
							if (this.Visit(node.ClassDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ClassDeclaration)) return true;
					}
				}
				if (node.SymbolDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SymbolDeclaration))
						{
							if (this.Visit(node.SymbolDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SymbolDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCompilerDeclaration(CompilerDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
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
		
		public bool VisitPhaseDeclaration(PhaseDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.Locked != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Locked))
						{
							if (this.Visit(node.Locked)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Locked)) return true;
					}
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
				if (node.PhaseJoin != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PhaseJoin))
						{
							if (this.Visit(node.PhaseJoin)) return true;
						}
					}
					else
					{
						if (this.Visit(node.PhaseJoin)) return true;
					}
				}
				if (node.AfterPhases != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AfterPhases))
						{
							if (this.Visit(node.AfterPhases)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AfterPhases)) return true;
					}
				}
				if (node.BeforePhases != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BeforePhases))
						{
							if (this.Visit(node.BeforePhases)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BeforePhases)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitLocked(LockedSyntax node)
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
		
		public bool VisitPhaseJoin(PhaseJoinSyntax node)
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
				if (node.PhaseRef != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PhaseRef))
						{
							if (this.Visit(node.PhaseRef)) return true;
						}
					}
					else
					{
						if (this.Visit(node.PhaseRef)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAfterPhases(AfterPhasesSyntax node)
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
				if (node.PhaseRef != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.PhaseRef.Node))
					{
						foreach (var item in node.PhaseRef)
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
		
		public bool VisitBeforePhases(BeforePhasesSyntax node)
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
				if (node.PhaseRef != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.PhaseRef.Node))
					{
						foreach (var item in node.PhaseRef)
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
		
		public bool VisitPhaseRef(PhaseRefSyntax node)
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
		
		public bool VisitEnumDeclaration(EnumDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
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
				if (node.EnumBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumBody))
						{
							if (this.Visit(node.EnumBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EnumBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEnumBody(EnumBodySyntax node)
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
				if (node.EnumValues != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumValues))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.EnumValues)) return true;
					}
				}
				if (node.EnumMemberDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumMemberDeclaration.Node))
					{
						foreach (var item in node.EnumMemberDeclaration)
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
		
		public bool VisitEnumValues(EnumValuesSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.EnumValue != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumValue.Node))
					{
						foreach (var item in node.EnumValue)
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
		
		public bool VisitEnumValue(EnumValueSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
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
		
		public bool VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.OperationDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.OperationDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVisibility(VisibilitySyntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.Visibility)))
				{
					switch (node.Visibility.GetKind().Switch())
					{
						case MetaCompilerSyntaxKind.KPrivate:
						case MetaCompilerSyntaxKind.KProtected:
						case MetaCompilerSyntaxKind.KPublic:
						case MetaCompilerSyntaxKind.KInternal:
							return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitClassDeclaration(ClassDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.Visibility != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visibility))
						{
							if (this.Visit(node.Visibility)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Visibility)) return true;
					}
				}
				if (node.ClassModifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassModifier.Node))
					{
						foreach (var item in node.ClassModifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.Class_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Class_))
						{
							if (this.Visit(node.Class_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Class_)) return true;
					}
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
				if (node.ClassAncestors != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassAncestors))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ClassAncestors)) return true;
					}
				}
				if (node.ClassBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassBody))
						{
							if (this.Visit(node.ClassBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ClassBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitClassModifier(ClassModifierSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Abstract_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Abstract_))
						{
							if (this.Visit(node.Abstract_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Abstract_)) return true;
					}
				}
				if (node.Sealed_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Sealed_))
						{
							if (this.Visit(node.Sealed_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Sealed_)) return true;
					}
				}
				if (node.Partial_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Partial_))
						{
							if (this.Visit(node.Partial_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Partial_)) return true;
					}
				}
				if (node.Static_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Static_))
						{
							if (this.Visit(node.Static_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Static_)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitClassAncestors(ClassAncestorsSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ClassAncestor != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassAncestor.Node))
					{
						foreach (var item in node.ClassAncestor)
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
		
		public bool VisitClassAncestor(ClassAncestorSyntax node)
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
		
		public bool VisitClassBody(ClassBodySyntax node)
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
				if (node.ClassPhases != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassPhases))
						{
							if (this.Visit(node.ClassPhases)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ClassPhases)) return true;
					}
				}
				if (node.ClassMemberDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassMemberDeclaration.Node))
					{
						foreach (var item in node.ClassMemberDeclaration)
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
		
		public bool VisitClassPhases(ClassPhasesSyntax node)
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
				if (node.PhaseRef != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.PhaseRef.Node))
					{
						foreach (var item in node.PhaseRef)
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
		
		public bool VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.FieldDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FieldDeclaration))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.FieldDeclaration)) return true;
					}
				}
				if (node.OperationDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OperationDeclaration))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.OperationDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitClass_(Class_Syntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KClass)))
				{
					if (node.KClass.GetKind() == MetaCompilerSyntaxKind.KClass)
					{
						return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSymbolDeclaration(SymbolDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.Visibility != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visibility))
						{
							if (this.Visit(node.Visibility)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Visibility)) return true;
					}
				}
				if (node.Visit_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visit_))
						{
							if (this.Visit(node.Visit_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Visit_)) return true;
					}
				}
				if (node.ClassModifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ClassModifier.Node))
					{
						foreach (var item in node.ClassModifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.Symbol_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Symbol_))
						{
							if (this.Visit(node.Symbol_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Symbol_)) return true;
					}
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
				if (node.ClassAncestors != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassAncestors))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ClassAncestors)) return true;
					}
				}
				if (node.ClassBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassBody))
						{
							if (this.Visit(node.ClassBody)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ClassBody)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSymbol_(Symbol_Syntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KSymbol)))
				{
					if (node.KSymbol.GetKind() == MetaCompilerSyntaxKind.KSymbol)
					{
						return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitFieldDeclaration(FieldDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.Visibility != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visibility))
						{
							if (this.Visit(node.Visibility)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Visibility)) return true;
					}
				}
				if (node.MemberModifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.MemberModifier.Node))
					{
						foreach (var item in node.MemberModifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.FieldContainment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FieldContainment))
						{
							if (this.Visit(node.FieldContainment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.FieldContainment)) return true;
					}
				}
				if (node.FieldKind != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FieldKind))
						{
							if (this.Visit(node.FieldKind)) return true;
						}
					}
					else
					{
						if (this.Visit(node.FieldKind)) return true;
					}
				}
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeReference)) return true;
					}
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
				if (node.DefaultValue != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DefaultValue))
						{
							if (this.Visit(node.DefaultValue)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DefaultValue)) return true;
					}
				}
				if (node.Phase != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Phase))
						{
							if (this.Visit(node.Phase)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Phase)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitFieldContainment(FieldContainmentSyntax node)
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
		
		public bool VisitFieldKind(FieldKindSyntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.FieldKind)))
				{
					switch (node.FieldKind.GetKind().Switch())
					{
						case MetaCompilerSyntaxKind.KReadonly:
						case MetaCompilerSyntaxKind.KLazy:
						case MetaCompilerSyntaxKind.KDerived:
							return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitMemberModifier(MemberModifierSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Partial_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Partial_))
						{
							if (this.Visit(node.Partial_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Partial_)) return true;
					}
				}
				if (node.Static_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Static_))
						{
							if (this.Visit(node.Static_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Static_)) return true;
					}
				}
				if (node.Virtual_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Virtual_))
						{
							if (this.Visit(node.Virtual_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Virtual_)) return true;
					}
				}
				if (node.Abstract_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Abstract_))
						{
							if (this.Visit(node.Abstract_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Abstract_)) return true;
					}
				}
				if (node.Sealed_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Sealed_))
						{
							if (this.Visit(node.Sealed_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Sealed_)) return true;
					}
				}
				if (node.New_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.New_))
						{
							if (this.Visit(node.New_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.New_)) return true;
					}
				}
				if (node.Override_ != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Override_))
						{
							if (this.Visit(node.Override_)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Override_)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDefaultValue(DefaultValueSyntax node)
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
				if (node.StringLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
						{
							return true;
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
		
		public bool VisitPhase(PhaseSyntax node)
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
				if (node.PhaseRef != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PhaseRef))
						{
							if (this.Visit(node.PhaseRef)) return true;
						}
					}
					else
					{
						if (this.Visit(node.PhaseRef)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNameUseList(NameUseListSyntax node)
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
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Qualifier.Node))
					{
						foreach (var item in node.Qualifier)
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
		
		public bool VisitTypedefDeclaration(TypedefDeclarationSyntax node)
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
				if (node.TypedefValue != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypedefValue))
						{
							if (this.Visit(node.TypedefValue)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TypedefValue)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTypedefValue(TypedefValueSyntax node)
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
				if (node.StringLiteral != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.StringLiteral))
						{
							return true;
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
		
		public bool VisitReturnType(ReturnTypeSyntax node)
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
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							if (this.Visit(node.TypeReference)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeReference)) return true;
					}
				}
				if (node.VoidType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VoidType))
						{
							if (this.Visit(node.VoidType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.VoidType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTypeOfReference(TypeOfReferenceSyntax node)
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
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							if (this.Visit(node.TypeReference)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeReference)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTypeReference(TypeReferenceSyntax node)
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
				if (node.SimpleOrDictionaryType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleOrDictionaryType))
						{
							if (this.Visit(node.SimpleOrDictionaryType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SimpleOrDictionaryType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.SimpleOrArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleOrArrayType))
						{
							if (this.Visit(node.SimpleOrArrayType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SimpleOrArrayType)) return true;
					}
				}
				if (node.DictionaryType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DictionaryType))
						{
							if (this.Visit(node.DictionaryType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DictionaryType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.SimpleOrGenericType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleOrGenericType))
						{
							if (this.Visit(node.SimpleOrGenericType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SimpleOrGenericType)) return true;
					}
				}
				if (node.ArrayType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArrayType))
						{
							if (this.Visit(node.ArrayType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ArrayType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.SimpleType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleType))
						{
							if (this.Visit(node.SimpleType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.SimpleType)) return true;
					}
				}
				if (node.GenericType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.GenericType))
						{
							if (this.Visit(node.GenericType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.GenericType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSimpleType(SimpleTypeSyntax node)
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
				if (node.PrimitiveType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PrimitiveType))
						{
							if (this.Visit(node.PrimitiveType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.PrimitiveType)) return true;
					}
				}
				if (node.ObjectType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectType))
						{
							if (this.Visit(node.ObjectType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ObjectType)) return true;
					}
				}
				if (node.NullableType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.NullableType))
						{
							if (this.Visit(node.NullableType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.NullableType)) return true;
					}
				}
				if (node.ClassType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassType))
						{
							if (this.Visit(node.ClassType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ClassType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitClassType(ClassTypeSyntax node)
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
		
		public bool VisitObjectType(ObjectTypeSyntax node)
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
		
		public bool VisitPrimitiveType(PrimitiveTypeSyntax node)
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
		
		public bool VisitVoidType(VoidTypeSyntax node)
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
		
		public bool VisitNullableType(NullableTypeSyntax node)
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
				if (node.PrimitiveType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PrimitiveType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.PrimitiveType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitGenericType(GenericTypeSyntax node)
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
				if (node.ClassType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ClassType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ClassType)) return true;
					}
				}
				if (node.TypeArguments != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeArguments))
						{
							if (this.Visit(node.TypeArguments)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeArguments)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTypeArguments(TypeArgumentsSyntax node)
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
				if (node.TypeReference != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TypeReference.Node))
					{
						foreach (var item in node.TypeReference)
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
		
		public bool VisitArrayType(ArrayTypeSyntax node)
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
				if (node.SimpleOrGenericType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleOrGenericType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.SimpleOrGenericType)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitDictionaryType(DictionaryTypeSyntax node)
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
				if (node.Key != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Key))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Key)) return true;
					}
				}
				if (node.Value != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Value))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Value)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitOperationDeclaration(OperationDeclarationSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.Visibility != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Visibility))
						{
							if (this.Visit(node.Visibility)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Visibility)) return true;
					}
				}
				if (node.MemberModifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.MemberModifier.Node))
					{
						foreach (var item in node.MemberModifier)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.ReturnType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ReturnType))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ReturnType)) return true;
					}
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
				if (node.ParameterList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ParameterList))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ParameterList)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitParameterList(ParameterListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Parameter != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Parameter.Node))
					{
						foreach (var item in node.Parameter)
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
		
		public bool VisitParameter(ParameterSyntax node)
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
				if (node.Attribute != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Attribute.Node))
					{
						foreach (var item in node.Attribute)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.TypeReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeReference))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeReference)) return true;
					}
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
				if (node.DefaultValue != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.DefaultValue))
						{
							if (this.Visit(node.DefaultValue)) return true;
						}
					}
					else
					{
						if (this.Visit(node.DefaultValue)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitStatic_(Static_Syntax node)
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
		
		public bool VisitBase_(Base_Syntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KBase)))
				{
					if (node.KBase.GetKind() == MetaCompilerSyntaxKind.KBase)
					{
						return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitMeta_(Meta_Syntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KMeta)))
				{
					if (node.KMeta.GetKind() == MetaCompilerSyntaxKind.KMeta)
					{
						return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSource_(Source_Syntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KSource)))
				{
					if (node.KSource.GetKind() == MetaCompilerSyntaxKind.KSource)
					{
						return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVisit_(Visit_Syntax node)
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
		
		public bool VisitPartial_(Partial_Syntax node)
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
		
		public bool VisitAbstract_(Abstract_Syntax node)
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
		
		public bool VisitVirtual_(Virtual_Syntax node)
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
		
		public bool VisitSealed_(Sealed_Syntax node)
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
		
		public bool VisitOverride_(Override_Syntax node)
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
		
		public bool VisitNew_(New_Syntax node)
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

