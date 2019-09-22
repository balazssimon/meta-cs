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
using Microsoft.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;
using WebSequenceDiagramsModel.Syntax;
using WebSequenceDiagramsModel.Symbols;

namespace WebSequenceDiagramsModel.Binding
{
	// Make sure to keep this in sync with SequenceIsBindableNodeVisitor
    public class SequenceBoundNodeFactoryVisitor : BoundNodeFactoryVisitor, ISequenceSyntaxVisitor<ArrayBuilder<object>, BoundNode>
    {
        public SequenceBoundNodeFactoryVisitor(BoundTree boundTree)
			: base(boundTree)
        {

        }

		
		public BoundNode VisitMain(MainSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (node.Interaction != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Interaction))
						{
							this.Visit(node.Interaction, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Interaction, childBoundNodesForParent);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitInteraction(InteractionSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Line != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Line.Node))
					{
						foreach (var item in node.Line)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), symbolType: typeof(Symbols.Interaction), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTitleLine(TitleLineSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (node.Title != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Title))
						{
							this.Visit(node.Title, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Title, childBoundNodesForParent);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclarationLine(DeclarationLineSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (node.Declaration != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Declaration))
						{
							this.Visit(node.Declaration, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Declaration, childBoundNodesForParent);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDeclaration(DeclarationSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Destroy != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Destroy))
						{
							this.Visit(node.Destroy, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Destroy, childBoundNodes);
					}
				}
				if (node.Arrow != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Arrow))
						{
							this.Visit(node.Arrow, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Arrow, childBoundNodes);
					}
				}
				if (node.Alt != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Alt))
						{
							this.Visit(node.Alt, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Alt, childBoundNodes);
					}
				}
				if (node.Opt != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Opt))
						{
							this.Visit(node.Opt, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Opt, childBoundNodes);
					}
				}
				if (node.Loop != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Loop))
						{
							this.Visit(node.Loop, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Loop, childBoundNodes);
					}
				}
				if (node.Ref != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Ref))
						{
							this.Visit(node.Ref, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Ref, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundScope(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitTitle(TitleSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodesForParent);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrow(ArrowSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Source, childBoundNodesOfSource);
							BoundNode boundSource;
							boundSource = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), name: "Source", node.Source, false);
							childBoundNodes.Add(boundSource);
						}
					}
					else
					{
						childBoundNodes.Add(node.Source);
					}
				}
				if (node.Type != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Type))
						{
							var childBoundNodesOfType = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Type, childBoundNodesOfType);
							BoundNode boundType;
							boundType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfType.ToImmutableAndFree(), name: "Kind", node.Type, false);
							childBoundNodes.Add(boundType);
						}
					}
					else
					{
						childBoundNodes.Add(node.Type);
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Target, childBoundNodesOfTarget);
							BoundNode boundTarget;
							boundTarget = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), name: "Target", node.Target, false);
							childBoundNodes.Add(boundTarget);
						}
					}
					else
					{
						childBoundNodes.Add(node.Target);
					}
				}
				if (node.Text != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Text))
						{
							var childBoundNodesOfText = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Text, childBoundNodesOfText);
							BoundNode boundText;
							boundText = this.CreateBoundValue(this.BoundTree, childBoundNodesOfText.ToImmutableAndFree(), node.Text, false);
							boundText = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundText), name: "Text", node.Text, false);
							childBoundNodes.Add(boundText);
						}
					}
					else
					{
						childBoundNodes.Add(node.Text);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), symbolType: typeof(Symbols.Message), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitDestroy(DestroySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.LifeLineName != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.LifeLineName))
						{
							var childBoundNodesOfLifeLineName = ArrayBuilder<object>.GetInstance();
							this.Visit(node.LifeLineName, childBoundNodesOfLifeLineName);
							BoundNode boundLifeLineName;
							boundLifeLineName = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfLifeLineName.ToImmutableAndFree(), name: "Lifeline", node.LifeLineName, false);
							childBoundNodes.Add(boundLifeLineName);
						}
					}
					else
					{
						childBoundNodes.Add(node.LifeLineName);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), symbolType: typeof(Symbols.Destroy), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitAlt(AltSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.AltFragment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.AltFragment))
						{
							this.Visit(node.AltFragment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.AltFragment, childBoundNodes);
					}
				}
				if (node.ElseFragment != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.ElseFragment.Node))
					{
						foreach (var item in node.ElseFragment)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodes);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), symbolType: typeof(Symbols.MultiFragment), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitAltFragment(AltFragmentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							var childBoundNodesOfCondition = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Condition, childBoundNodesOfCondition);
							BoundNode boundCondition;
							boundCondition = this.CreateBoundValue(this.BoundTree, childBoundNodesOfCondition.ToImmutableAndFree(), node.Condition, false);
							boundCondition = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundCondition), name: "Text", node.Condition, false);
							childBoundNodes.Add(boundCondition);
						}
					}
					else
					{
						childBoundNodes.Add(node.Condition);
					}
				}
				if (node.FragmentBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FragmentBody))
						{
							this.Visit(node.FragmentBody, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.FragmentBody, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Kind", value: FragmentKind.Alt, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, ImmutableArray.Create<object>(resultNode), symbolType: typeof(Symbols.Fragment), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Fragments", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitElseFragment(ElseFragmentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							var childBoundNodesOfCondition = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Condition, childBoundNodesOfCondition);
							BoundNode boundCondition;
							boundCondition = this.CreateBoundValue(this.BoundTree, childBoundNodesOfCondition.ToImmutableAndFree(), node.Condition, false);
							boundCondition = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundCondition), name: "Text", node.Condition, false);
							childBoundNodes.Add(boundCondition);
						}
					}
					else
					{
						childBoundNodes.Add(node.Condition);
					}
				}
				if (node.FragmentBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FragmentBody))
						{
							this.Visit(node.FragmentBody, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.FragmentBody, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Kind", value: FragmentKind.Else, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, ImmutableArray.Create<object>(resultNode), symbolType: typeof(Symbols.Fragment), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Fragments", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoop(LoopSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.LoopFragment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.LoopFragment))
						{
							this.Visit(node.LoopFragment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.LoopFragment, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Kind", value: FragmentKind.Loop, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, ImmutableArray.Create<object>(resultNode), symbolType: typeof(Symbols.Fragment), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLoopFragment(LoopFragmentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							var childBoundNodesOfCondition = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Condition, childBoundNodesOfCondition);
							BoundNode boundCondition;
							boundCondition = this.CreateBoundValue(this.BoundTree, childBoundNodesOfCondition.ToImmutableAndFree(), node.Condition, false);
							boundCondition = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundCondition), name: "Text", node.Condition, false);
							childBoundNodesForParent.Add(boundCondition);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Condition);
					}
				}
				if (node.FragmentBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FragmentBody))
						{
							this.Visit(node.FragmentBody, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.FragmentBody, childBoundNodesForParent);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitOpt(OptSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.OptFragment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.OptFragment))
						{
							this.Visit(node.OptFragment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.OptFragment, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Kind", value: FragmentKind.Opt, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, ImmutableArray.Create<object>(resultNode), symbolType: typeof(Symbols.Fragment), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitOptFragment(OptFragmentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (node.Condition != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Condition))
						{
							var childBoundNodesOfCondition = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Condition, childBoundNodesOfCondition);
							BoundNode boundCondition;
							boundCondition = this.CreateBoundValue(this.BoundTree, childBoundNodesOfCondition.ToImmutableAndFree(), node.Condition, false);
							boundCondition = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundCondition), name: "Text", node.Condition, false);
							childBoundNodesForParent.Add(boundCondition);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.Condition);
					}
				}
				if (node.FragmentBody != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.FragmentBody))
						{
							this.Visit(node.FragmentBody, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.FragmentBody, childBoundNodesForParent);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRef(RefSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.SimpleRefFragment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SimpleRefFragment))
						{
							this.Visit(node.SimpleRefFragment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.SimpleRefFragment, childBoundNodes);
					}
				}
				if (node.MessageRefFragment != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.MessageRefFragment))
						{
							this.Visit(node.MessageRefFragment, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.MessageRefFragment, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundProperty(this.BoundTree, childBoundNodes.ToImmutableAndFree(), name: "Kind", value: FragmentKind.Ref, syntax: node, hasErrors: false);
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, ImmutableArray.Create<object>(resultNode), symbolType: typeof(Symbols.RefFragment), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Declarations", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSimpleRefFragment(SimpleRefFragmentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (node.RefText != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RefText))
						{
							var childBoundNodesOfRefText = ArrayBuilder<object>.GetInstance();
							this.Visit(node.RefText, childBoundNodesOfRefText);
							BoundNode boundRefText;
							boundRefText = this.CreateBoundValue(this.BoundTree, childBoundNodesOfRefText.ToImmutableAndFree(), node.RefText, false);
							boundRefText = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundRefText), name: "Text", node.RefText, false);
							childBoundNodesForParent.Add(boundRefText);
						}
					}
					else
					{
						childBoundNodesForParent.Add(node.RefText);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitMessageRefFragment(MessageRefFragmentSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (node.RefInput != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RefInput))
						{
							this.Visit(node.RefInput, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.RefInput, childBoundNodesForParent);
					}
				}
				if (node.RefOutput != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.RefOutput))
						{
							this.Visit(node.RefOutput, childBoundNodesForParent);
						}
					}
					else
					{
						this.Visit(node.RefOutput, childBoundNodesForParent);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRefInput(RefInputSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Source != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Source))
						{
							var childBoundNodesOfSource = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Source, childBoundNodesOfSource);
							BoundNode boundSource;
							boundSource = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfSource.ToImmutableAndFree(), name: "Source", node.Source, false);
							childBoundNodes.Add(boundSource);
						}
					}
					else
					{
						childBoundNodes.Add(node.Source);
					}
				}
				if (node.SourceType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.SourceType))
						{
							var childBoundNodesOfSourceType = ArrayBuilder<object>.GetInstance();
							this.Visit(node.SourceType, childBoundNodesOfSourceType);
							BoundNode boundSourceType;
							boundSourceType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfSourceType.ToImmutableAndFree(), name: "Kind", node.SourceType, false);
							childBoundNodes.Add(boundSourceType);
						}
					}
					else
					{
						childBoundNodes.Add(node.SourceType);
					}
				}
				if (node.Message != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Message))
						{
							var childBoundNodesOfMessage = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Message, childBoundNodesOfMessage);
							BoundNode boundMessage;
							boundMessage = this.CreateBoundValue(this.BoundTree, childBoundNodesOfMessage.ToImmutableAndFree(), node.Message, false);
							boundMessage = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundMessage), name: "Text", node.Message, false);
							childBoundNodes.Add(boundMessage);
						}
					}
					else
					{
						childBoundNodes.Add(node.Message);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), symbolType: typeof(Symbols.Message), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Input", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitRefOutput(RefOutputSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.TargetType != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.TargetType))
						{
							var childBoundNodesOfTargetType = ArrayBuilder<object>.GetInstance();
							this.Visit(node.TargetType, childBoundNodesOfTargetType);
							BoundNode boundTargetType;
							boundTargetType = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTargetType.ToImmutableAndFree(), name: "Kind", node.TargetType, false);
							childBoundNodes.Add(boundTargetType);
						}
					}
					else
					{
						childBoundNodes.Add(node.TargetType);
					}
				}
				if (node.Target != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Target))
						{
							var childBoundNodesOfTarget = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Target, childBoundNodesOfTarget);
							BoundNode boundTarget;
							boundTarget = this.CreateBoundProperty(this.BoundTree, childBoundNodesOfTarget.ToImmutableAndFree(), name: "Target", node.Target, false);
							childBoundNodes.Add(boundTarget);
						}
					}
					else
					{
						childBoundNodes.Add(node.Target);
					}
				}
				if (node.Message != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Message))
						{
							var childBoundNodesOfMessage = ArrayBuilder<object>.GetInstance();
							this.Visit(node.Message, childBoundNodesOfMessage);
							BoundNode boundMessage;
							boundMessage = this.CreateBoundValue(this.BoundTree, childBoundNodesOfMessage.ToImmutableAndFree(), node.Message, false);
							boundMessage = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(boundMessage), name: "Text", node.Message, false);
							childBoundNodes.Add(boundMessage);
						}
					}
					else
					{
						childBoundNodes.Add(node.Message);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), symbolType: typeof(Symbols.Message), syntax: node, hasErrors: false);
					resultNode = this.CreateBoundProperty(this.BoundTree, ImmutableArray.Create<object>(resultNode), name: "Output", syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitFragmentBody(FragmentBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (node.Line != null)
				{
					if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, node.Line.Node))
					{
						foreach (var item in node.Line)
						{
							if (state != BoundNodeFactoryState.InParent || LookupPosition.IsInNode(this.Position, item))
							{
								this.Visit(item, childBoundNodesForParent);
							}
						}
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitEnd(EndSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitNote(NoteSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSingleLineNote(SingleLineNoteSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitMultiLineNote(MultiLineNoteSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSimpleBody(SimpleBodySyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitSimpleLine(SimpleLineSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitArrowType(ArrowTypeSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InNode || (state == BoundNodeFactoryState.InParent && LookupPosition.IsInNode(this.Position, node.ArrowType)))
				{
					switch (node.ArrowType.GetKind().Switch())
					{
						case SequenceSyntaxKind.TSync:
							BoundNode boundTSync;
							boundTSync = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: MessageKind.Sync, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTSync);
							break;
						case SequenceSyntaxKind.TAsync:
							BoundNode boundTAsync;
							boundTAsync = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: MessageKind.Async, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTAsync);
							break;
						case SequenceSyntaxKind.TReturn:
							BoundNode boundTReturn;
							boundTReturn = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: MessageKind.Return, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTReturn);
							break;
						case SequenceSyntaxKind.TCreate:
							BoundNode boundTCreate;
							boundTCreate = this.CreateBoundValue(this.BoundTree, ImmutableArray<object>.Empty, value: MessageKind.Create, syntax: node, hasErrors: false);
							childBoundNodesForParent.Add(boundTCreate);
							break;
						default:
							break;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitLifeLineName(LifeLineNameSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Name != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Name))
						{
							this.Visit(node.Name, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Name, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundSymbolDef(this.BoundTree, childBoundNodes.ToImmutableAndFree(), symbolType: typeof(Symbols.Lifeline), merge: true, syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitName(NameSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (node.Identifier != null)
				{
					if (state == BoundNodeFactoryState.InParent)
					{
						if (LookupPosition.IsInNode(this.Position, node.Identifier))
						{
							this.Visit(node.Identifier, childBoundNodes);
						}
					}
					else
					{
						this.Visit(node.Identifier, childBoundNodes);
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundName(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIdentifier(IdentifierSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
					else
					{
						childBoundNodesForParent.Add(node);
						return null;
					}
				}
				var childBoundNodes = ArrayBuilder<object>.GetInstance();
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode);
					if (childBoundNodes.Count == 1 && childBoundNodes[0] is BoundNode) return (BoundNode)childBoundNodes[0];
					else return null;
				}
				else if (state == BoundNodeFactoryState.InNode)
				{
					BoundNode resultNode;
					resultNode = this.CreateBoundIdentifier(this.BoundTree, childBoundNodes.ToImmutableAndFree(), syntax: node, hasErrors: false);
					childBoundNodesForParent.Add(resultNode); 
					return resultNode;
				}
				else
				{
					Debug.Assert(false);
					childBoundNodesForParent.Add(node);
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitText(TextSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
		
		public BoundNode VisitIdentifierPart(IdentifierPartSyntax node, ArrayBuilder<object> childBoundNodesForParent)
		{
			if (node == null || node.IsMissing) return null;
			var state = this.State;
			if (this.State == BoundNodeFactoryState.InParent) this.State = BoundNodeFactoryState.InNode;
			else if (this.State == BoundNodeFactoryState.InNode) this.State = BoundNodeFactoryState.InChild;
			try
			{
				if (state == BoundNodeFactoryState.InChild)
				{
					if (this.BoundTree.TryGetBoundNode(node, out BoundNode cachedBoundNode))
					{
						childBoundNodesForParent.Add(cachedBoundNode);
						return cachedBoundNode;
					}
				}
				if (state == BoundNodeFactoryState.InParent)
				{
					Debug.Assert(childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode);
					if (childBoundNodesForParent.Count == 1 && childBoundNodesForParent[0] is BoundNode) return (BoundNode)childBoundNodesForParent[0];
					else return null;
				}
				else
				{
					return null;
				}
			}
			finally
			{
				this.State = state;
			}
		}
    }
}

