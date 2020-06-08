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
using PilV2;
using PilV2.Syntax;
using PilV2.Symbols;

namespace PilV2.Binding
{
	// Make sure to keep this in sync with PilBoundNodeFactoryVisitor
    public class PilIsBindableNodeVisitor : IsBindableNodeVisitor, IPilSyntaxVisitor<bool>
    {
        public PilIsBindableNodeVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

		public virtual bool VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node)
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
				if (node.TypeDefDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TypeDefDeclaration))
						{
							if (this.Visit(node.TypeDefDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TypeDefDeclaration)) return true;
					}
				}
				if (node.ExternalParameterDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ExternalParameterDeclaration))
						{
							if (this.Visit(node.ExternalParameterDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ExternalParameterDeclaration)) return true;
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
				if (node.ObjectDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectDeclaration))
						{
							if (this.Visit(node.ObjectDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ObjectDeclaration)) return true;
					}
				}
				if (node.FunctionDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionDeclaration))
						{
							if (this.Visit(node.FunctionDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.FunctionDeclaration)) return true;
					}
				}
				if (node.QueryDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryDeclaration))
						{
							if (this.Visit(node.QueryDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QueryDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTypeDefDeclaration(TypeDefDeclarationSyntax node)
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
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node)
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
				if (node.Expression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Expression))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Expression)) return true;
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
				if (node.EnumLiterals != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EnumLiterals))
						{
							if (this.Visit(node.EnumLiterals)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EnumLiterals)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitEnumLiterals(EnumLiteralsSyntax node)
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
				if (node.EnumLiteral != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.EnumLiteral.Node))
					{
						foreach (var item in node.EnumLiteral)
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
		
		public bool VisitEnumLiteral(EnumLiteralSyntax node)
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
		
		public bool VisitObjectDeclaration(ObjectDeclarationSyntax node)
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
				if (node.ObjectHeader != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectHeader))
						{
							if (this.Visit(node.ObjectHeader)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ObjectHeader)) return true;
					}
				}
				if (node.ObjectExternalParameters != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectExternalParameters))
						{
							if (this.Visit(node.ObjectExternalParameters)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ObjectExternalParameters)) return true;
					}
				}
				if (node.ObjectFields != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectFields))
						{
							if (this.Visit(node.ObjectFields)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ObjectFields)) return true;
					}
				}
				if (node.ObjectFunctions != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ObjectFunctions))
						{
							if (this.Visit(node.ObjectFunctions)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ObjectFunctions)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitObjectHeader(ObjectHeaderSyntax node)
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
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.Ports != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Ports))
						{
							if (this.Visit(node.Ports)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Ports)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitPorts(PortsSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Port != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Port.Node))
					{
						foreach (var item in node.Port)
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
		
		public bool VisitPort(PortSyntax node)
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
		
		public bool VisitObjectExternalParameters(ObjectExternalParametersSyntax node)
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
				if (node.ExternalParameterDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ExternalParameterDeclaration.Node))
					{
						foreach (var item in node.ExternalParameterDeclaration)
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
		
		public bool VisitObjectFields(ObjectFieldsSyntax node)
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
				if (node.VariableDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.VariableDeclaration.Node))
					{
						foreach (var item in node.VariableDeclaration)
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
		
		public bool VisitObjectFunctions(ObjectFunctionsSyntax node)
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
				if (node.FunctionDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.FunctionDeclaration.Node))
					{
						foreach (var item in node.FunctionDeclaration)
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
		
		public bool VisitFunctionDeclaration(FunctionDeclarationSyntax node)
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
				if (node.FunctionHeader != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionHeader))
						{
							if (this.Visit(node.FunctionHeader)) return true;
						}
					}
					else
					{
						if (this.Visit(node.FunctionHeader)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							if (this.Visit(node.Statements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Statements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitFunctionHeader(FunctionHeaderSyntax node)
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
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.FunctionParams != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionParams))
						{
							if (this.Visit(node.FunctionParams)) return true;
						}
					}
					else
					{
						if (this.Visit(node.FunctionParams)) return true;
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
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitFunctionParams(FunctionParamsSyntax node)
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
		
		public bool VisitParam(ParamSyntax node)
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
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQueryDeclaration(QueryDeclarationSyntax node)
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
				if (node.QueryHeader != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryHeader))
						{
							if (this.Visit(node.QueryHeader)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QueryHeader)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.QueryExternalParameters != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryExternalParameters.Node))
					{
						foreach (var item in node.QueryExternalParameters)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.QueryField != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryField.Node))
					{
						foreach (var item in node.QueryField)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.FunctionDeclaration != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.FunctionDeclaration.Node))
					{
						foreach (var item in node.FunctionDeclaration)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.QueryObject != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryObject.Node))
					{
						foreach (var item in node.QueryObject)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.EndName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EndName))
						{
							if (this.Visit(node.EndName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EndName)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQueryHeader(QueryHeaderSyntax node)
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
							if (this.Visit(node.Name)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Name)) return true;
					}
				}
				if (node.QueryRequestParams != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryRequestParams))
						{
							if (this.Visit(node.QueryRequestParams)) return true;
						}
					}
					else
					{
						if (this.Visit(node.QueryRequestParams)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQueryRequestParams(QueryRequestParamsSyntax node)
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
		
		public bool VisitQueryAcceptParams(QueryAcceptParamsSyntax node)
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
		
		public bool VisitQueryRefuseParams(QueryRefuseParamsSyntax node)
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
		
		public bool VisitQueryCancelParams(QueryCancelParamsSyntax node)
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
				if (node.Param != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Param.Node))
					{
						foreach (var item in node.Param)
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
		
		public bool VisitQueryExternalParameters(QueryExternalParametersSyntax node)
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
				if (node.ExternalParameterDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ExternalParameterDeclaration))
						{
							if (this.Visit(node.ExternalParameterDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ExternalParameterDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQueryField(QueryFieldSyntax node)
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
				if (node.VariableDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableDeclaration))
						{
							if (this.Visit(node.VariableDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.VariableDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQueryFunction(QueryFunctionSyntax node)
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
				if (node.FunctionDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionDeclaration))
						{
							if (this.Visit(node.FunctionDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.FunctionDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQueryObject(QueryObjectSyntax node)
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
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.QueryObjectField != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryObjectField.Node))
					{
						foreach (var item in node.QueryObjectField)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.QueryObjectFunction != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryObjectFunction.Node))
					{
						foreach (var item in node.QueryObjectFunction)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.QueryObjectEvent != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.QueryObjectEvent.Node))
					{
						foreach (var item in node.QueryObjectEvent)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.EndName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.EndName))
						{
							if (this.Visit(node.EndName)) return true;
						}
					}
					else
					{
						if (this.Visit(node.EndName)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQueryObjectField(QueryObjectFieldSyntax node)
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
				if (node.VariableDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableDeclaration))
						{
							if (this.Visit(node.VariableDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.VariableDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQueryObjectFunction(QueryObjectFunctionSyntax node)
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
				if (node.FunctionDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionDeclaration))
						{
							if (this.Visit(node.FunctionDeclaration)) return true;
						}
					}
					else
					{
						if (this.Visit(node.FunctionDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitQueryObjectEvent(QueryObjectEventSyntax node)
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
				if (node.Input != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Input))
						{
							if (this.Visit(node.Input)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Input)) return true;
					}
				}
				if (node.Trigger != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Trigger))
						{
							if (this.Visit(node.Trigger)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Trigger)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitInput(InputSyntax node)
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
				if (node.InputPortList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.InputPortList))
						{
							if (this.Visit(node.InputPortList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.InputPortList)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							if (this.Visit(node.Statements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Statements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitInputPortList(InputPortListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.InputPort != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.InputPort.Node))
					{
						foreach (var item in node.InputPort)
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
		
		public bool VisitInputPort(InputPortSyntax node)
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
				if (node.PortName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PortName))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.PortName)) return true;
					}
				}
				if (node.QueryName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryName))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.QueryName)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTrigger(TriggerSyntax node)
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
				if (node.TriggerVarList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TriggerVarList))
						{
							if (this.Visit(node.TriggerVarList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TriggerVarList)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							if (this.Visit(node.Statements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Statements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTriggerVarList(TriggerVarListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.TriggerVar != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.TriggerVar.Node))
					{
						foreach (var item in node.TriggerVar)
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
		
		public bool VisitTriggerVar(TriggerVarSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							return true;
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
		
		public bool VisitStatements(StatementsSyntax node)
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
				if (node.Statement != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Statement.Node))
					{
						foreach (var item in node.Statement)
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
		
		public bool VisitStatement(StatementSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.VariableDeclarationStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableDeclarationStatement))
						{
							if (this.Visit(node.VariableDeclarationStatement)) return true;
						}
					}
					else
					{
						if (this.Visit(node.VariableDeclarationStatement)) return true;
					}
				}
				if (node.RequestStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RequestStatement))
						{
							if (this.Visit(node.RequestStatement)) return true;
						}
					}
					else
					{
						if (this.Visit(node.RequestStatement)) return true;
					}
				}
				if (node.ForkStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ForkStatement))
						{
							if (this.Visit(node.ForkStatement)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ForkStatement)) return true;
					}
				}
				if (node.ForkRequestStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ForkRequestStatement))
						{
							if (this.Visit(node.ForkRequestStatement)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ForkRequestStatement)) return true;
					}
				}
				if (node.IfStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.IfStatement))
						{
							if (this.Visit(node.IfStatement)) return true;
						}
					}
					else
					{
						if (this.Visit(node.IfStatement)) return true;
					}
				}
				if (node.ResponseStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ResponseStatement))
						{
							if (this.Visit(node.ResponseStatement)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ResponseStatement)) return true;
					}
				}
				if (node.CancelStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CancelStatement))
						{
							if (this.Visit(node.CancelStatement)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CancelStatement)) return true;
					}
				}
				if (node.AssignmentStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AssignmentStatement))
						{
							if (this.Visit(node.AssignmentStatement)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AssignmentStatement)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitForkStatement(ForkStatementSyntax node)
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
				if (node.Expression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Expression))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Expression)) return true;
					}
				}
				if (node.CaseBranch != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.CaseBranch.Node))
					{
						foreach (var item in node.CaseBranch)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.ElseBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ElseBranch))
						{
							if (this.Visit(node.ElseBranch)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ElseBranch)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCaseBranch(CaseBranchSyntax node)
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
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Condition)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							if (this.Visit(node.Statements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Statements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitElseBranch(ElseBranchSyntax node)
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
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							if (this.Visit(node.Statements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Statements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitIfStatement(IfStatementSyntax node)
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
				if (node.IfBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.IfBranch))
						{
							if (this.Visit(node.IfBranch)) return true;
						}
					}
					else
					{
						if (this.Visit(node.IfBranch)) return true;
					}
				}
				if (node.ElseIfBranch != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ElseIfBranch.Node))
					{
						foreach (var item in node.ElseIfBranch)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								if (this.Visit(item)) return true;
							}
						}
					}
				}
				if (node.ElseBranch != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ElseBranch.Node))
					{
						foreach (var item in node.ElseBranch)
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
		
		public bool VisitIfBranch(IfBranchSyntax node)
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
				if (node.ConditionalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpression))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ConditionalExpression)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							if (this.Visit(node.Statements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Statements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitElseIfBranch(ElseIfBranchSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.IfBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.IfBranch))
						{
							if (this.Visit(node.IfBranch)) return true;
						}
					}
					else
					{
						if (this.Visit(node.IfBranch)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitRequestStatement(RequestStatementSyntax node)
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
				if (node.LeftSide != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.LeftSide))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.LeftSide)) return true;
					}
				}
				if (node.CallRequest != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CallRequest))
						{
							if (this.Visit(node.CallRequest)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CallRequest)) return true;
					}
				}
				if (node.Assertion != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Assertion))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Assertion)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCallRequest(CallRequestSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.PortName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PortName))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.PortName)) return true;
					}
				}
				if (node.QueryName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.QueryName))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.QueryName)) return true;
					}
				}
				if (node.RequestArguments != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RequestArguments))
						{
							if (this.Visit(node.RequestArguments)) return true;
						}
					}
					else
					{
						if (this.Visit(node.RequestArguments)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitRequestArguments(RequestArgumentsSyntax node)
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
				if (node.ExpressionList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ExpressionList))
						{
							if (this.Visit(node.ExpressionList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ExpressionList)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitResponseStatement(ResponseStatementSyntax node)
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
				if (node.ResponseStatementKind != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ResponseStatementKind))
						{
							if (this.Visit(node.ResponseStatementKind)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ResponseStatementKind)) return true;
					}
				}
				if (node.Assertion != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Assertion))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Assertion)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCancelStatement(CancelStatementSyntax node)
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
				if (node.CancelStatementKind != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CancelStatementKind))
						{
							if (this.Visit(node.CancelStatementKind)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CancelStatementKind)) return true;
					}
				}
				if (node.PortName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.PortName))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.PortName)) return true;
					}
				}
				if (node.Assertion != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Assertion))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Assertion)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAssertion(AssertionSyntax node)
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
				if (node.Expression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Expression))
						{
							if (this.Visit(node.Expression)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Expression)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitResponseStatementKind(ResponseStatementKindSyntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.ResponseStatementKind)))
				{
					switch (node.ResponseStatementKind.GetKind().Switch())
					{
						case PilSyntaxKind.KAccept:
						case PilSyntaxKind.KRefuse:
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
		
		public bool VisitCancelStatementKind(CancelStatementKindSyntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KCancel)))
				{
					if (node.KCancel.GetKind() == PilSyntaxKind.KCancel)
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
		
		public bool VisitForkRequestStatement(ForkRequestStatementSyntax node)
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
				if (node.ForkRequestVariable != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ForkRequestVariable))
						{
							if (this.Visit(node.ForkRequestVariable)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ForkRequestVariable)) return true;
					}
				}
				if (node.AcceptBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AcceptBranch))
						{
							if (this.Visit(node.AcceptBranch)) return true;
						}
					}
					else
					{
						if (this.Visit(node.AcceptBranch)) return true;
					}
				}
				if (node.RefuseBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RefuseBranch))
						{
							if (this.Visit(node.RefuseBranch)) return true;
						}
					}
					else
					{
						if (this.Visit(node.RefuseBranch)) return true;
					}
				}
				if (node.CancelBranch != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.CancelBranch))
						{
							if (this.Visit(node.CancelBranch)) return true;
						}
					}
					else
					{
						if (this.Visit(node.CancelBranch)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitForkRequestVariable(ForkRequestVariableSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ForkRequestIdentifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ForkRequestIdentifier))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ForkRequestIdentifier)) return true;
					}
				}
				if (node.RequestStatement != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RequestStatement))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.RequestStatement)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							return true;
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
		
		public bool VisitAcceptBranch(AcceptBranchSyntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KAccept)))
				{
					if (node.KAccept.GetKind() == PilSyntaxKind.KAccept)
					{
						return true;
					}
				}
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Condition)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							if (this.Visit(node.Statements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Statements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitRefuseBranch(RefuseBranchSyntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KRefuse)))
				{
					if (node.KRefuse.GetKind() == PilSyntaxKind.KRefuse)
					{
						return true;
					}
				}
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Condition)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							if (this.Visit(node.Statements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Statements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitCancelBranch(CancelBranchSyntax node)
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
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.KCancel)))
				{
					if (node.KCancel.GetKind() == PilSyntaxKind.KCancel)
					{
						return true;
					}
				}
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Condition)) return true;
					}
				}
				if (node.Comment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Comment))
						{
							if (this.Visit(node.Comment)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Comment)) return true;
					}
				}
				if (node.Statements != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Statements))
						{
							if (this.Visit(node.Statements)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Statements)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
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
				if (node.VariableDeclaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableDeclaration))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.VariableDeclaration)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVariableDeclaration(VariableDeclarationSyntax node)
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
				if (node.Expression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Expression))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Expression)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAssignmentStatement(AssignmentStatementSyntax node)
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
				if (node.LeftSide != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.LeftSide))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.LeftSide)) return true;
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
		
		public bool VisitLeftSide(LeftSideSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
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
		
		public bool VisitExpressionList(ExpressionListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.Expression != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Expression.Node))
					{
						foreach (var item in node.Expression)
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
		
		public bool VisitExpression(ExpressionSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ArithmeticExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArithmeticExpression))
						{
							if (this.Visit(node.ArithmeticExpression)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ArithmeticExpression)) return true;
					}
				}
				if (node.ConditionalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpression))
						{
							if (this.Visit(node.ConditionalExpression)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ConditionalExpression)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitMulDivExpression(MulDivExpressionSyntax node)
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Left)) return true;
					}
				}
				if (node.OpMulDiv != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OpMulDiv))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.OpMulDiv)) return true;
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Right)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitPlusMinusExpression(PlusMinusExpressionSyntax node)
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Left)) return true;
					}
				}
				if (node.OpAddSub != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OpAddSub))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.OpAddSub)) return true;
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Right)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNegateExpression(NegateExpressionSyntax node)
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
				if (node.OpMinus != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OpMinus))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.OpMinus)) return true;
					}
				}
				if (node.ArithmeticExpressionTerminator != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArithmeticExpressionTerminator))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ArithmeticExpressionTerminator)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ArithmeticExpressionTerminator != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArithmeticExpressionTerminator))
						{
							if (this.Visit(node.ArithmeticExpressionTerminator)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ArithmeticExpressionTerminator)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitOpMulDiv(OpMulDivSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.OpMulDiv)))
				{
					switch (node.OpMulDiv.GetKind().Switch())
					{
						case PilSyntaxKind.TAsterisk:
						case PilSyntaxKind.TSlash:
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
		
		public bool VisitOpAddSub(OpAddSubSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.OpAddSub)))
				{
					switch (node.OpAddSub.GetKind().Switch())
					{
						case PilSyntaxKind.TPlus:
						case PilSyntaxKind.TMinus:
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
		
		public bool VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node)
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
				if (node.ArithmeticExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ArithmeticExpression))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ArithmeticExpression)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.TerminalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TerminalExpression))
						{
							if (this.Visit(node.TerminalExpression)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TerminalExpression)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitOpMinus(OpMinusSyntax node)
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
		
		public bool VisitAndExpression(AndExpressionSyntax node)
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Left)) return true;
					}
				}
				if (node.AndAlsoOp != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AndAlsoOp))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.AndAlsoOp)) return true;
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Right)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitOrExpression(OrExpressionSyntax node)
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Left)) return true;
					}
				}
				if (node.OrElseOp != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OrElseOp))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.OrElseOp)) return true;
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Right)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitNotExpression(NotExpressionSyntax node)
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
				if (node.OpExcl != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OpExcl))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.OpExcl)) return true;
					}
				}
				if (node.ConditionalExpressionTerminator != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpressionTerminator))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ConditionalExpressionTerminator)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ConditionalExpressionTerminator != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpressionTerminator))
						{
							if (this.Visit(node.ConditionalExpressionTerminator)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ConditionalExpressionTerminator)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitAndAlsoOp(AndAlsoOpSyntax node)
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
		
		public bool VisitOrElseOp(OrElseOpSyntax node)
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
		
		public bool VisitOpExcl(OpExclSyntax node)
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
		
		public bool VisitParenConditionalExpression(ParenConditionalExpressionSyntax node)
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
				if (node.ConditionalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ConditionalExpression))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ConditionalExpression)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ElementOfExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ElementOfExpression))
						{
							if (this.Visit(node.ElementOfExpression)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ElementOfExpression)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ComparisonExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ComparisonExpression))
						{
							if (this.Visit(node.ComparisonExpression)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ComparisonExpression)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.TerminalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TerminalExpression))
						{
							if (this.Visit(node.TerminalExpression)) return true;
						}
					}
					else
					{
						if (this.Visit(node.TerminalExpression)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComparisonExpression(ComparisonExpressionSyntax node)
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
				if (node.Left != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Left))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Left)) return true;
					}
				}
				if (node.Op != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Op))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Op)) return true;
					}
				}
				if (node.Right != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Right))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Right)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitComparisonOperator(ComparisonOperatorSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.ComparisonOperator)))
				{
					switch (node.ComparisonOperator.GetKind().Switch())
					{
						case PilSyntaxKind.TEqual:
						case PilSyntaxKind.TNotEqual:
						case PilSyntaxKind.TLessThan:
						case PilSyntaxKind.TGreaterThan:
						case PilSyntaxKind.TLessThanOrEqual:
						case PilSyntaxKind.TGreaterThanOrEqual:
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
		
		public bool VisitElementOfExpression(ElementOfExpressionSyntax node)
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
				if (node.TerminalExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TerminalExpression))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.TerminalExpression)) return true;
					}
				}
				if (node.ElementOfValueList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ElementOfValueList))
						{
							if (this.Visit(node.ElementOfValueList)) return true;
						}
					}
					else
					{
						if (this.Visit(node.ElementOfValueList)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitElementOfValueList(ElementOfValueListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.ElementOfValue != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ElementOfValue.Node))
					{
						foreach (var item in node.ElementOfValue)
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
		
		public bool VisitElementOfValue(ElementOfValueSyntax node)
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
		
		public bool VisitTerminalExpression(TerminalExpressionSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				if (node.VariableReference != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.VariableReference))
						{
							if (this.Visit(node.VariableReference)) return true;
						}
					}
					else
					{
						if (this.Visit(node.VariableReference)) return true;
					}
				}
				if (node.FunctionCallExpression != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FunctionCallExpression))
						{
							if (this.Visit(node.FunctionCallExpression)) return true;
						}
					}
					else
					{
						if (this.Visit(node.FunctionCallExpression)) return true;
					}
				}
				if (node.Literal != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Literal))
						{
							if (this.Visit(node.Literal)) return true;
						}
					}
					else
					{
						if (this.Visit(node.Literal)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
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
							return true;
						}
					}
					else
					{
						if (this.Visit(node.Identifier)) return true;
					}
				}
				if (node.ExpressionList != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.ExpressionList))
						{
							return true;
						}
					}
					else
					{
						if (this.Visit(node.ExpressionList)) return true;
					}
				}
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
		
		public bool VisitVariableReference(VariableReferenceSyntax node)
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
				if (node.VariableReferenceIdentifier != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.VariableReferenceIdentifier.Node))
					{
						foreach (var item in node.VariableReferenceIdentifier)
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
		
		public bool VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node)
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
							return true;
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
		
		public bool VisitComment(CommentSyntax node)
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
				if (node.BuiltInType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.BuiltInType))
						{
							if (this.Visit(node.BuiltInType)) return true;
						}
					}
					else
					{
						if (this.Visit(node.BuiltInType)) return true;
					}
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
		
		public bool VisitBuiltInType(BuiltInTypeSyntax node)
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
		
		public bool VisitQualifierList(QualifierListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
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
		
		public bool VisitIdentifierList(IdentifierListSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
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
		
		public bool VisitResultIdentifier(ResultIdentifierSyntax node)
		{
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild) return false;
				return false;
			}
			finally
			{
				this.State = state;
			}
		}
    }
}

