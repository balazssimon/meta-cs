// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using WebSequenceDiagramsModel.Syntax;

namespace WebSequenceDiagramsModel.Binding
{
	public class SequenceDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, ISequenceSyntaxVisitor
	{
        protected SequenceDeclarationTreeBuilderVisitor(SequenceSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            SequenceSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new SequenceDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.Visit(node.Interaction);
		}
		
		public virtual void VisitInteraction(InteractionSyntax node)
		{
			this.BeginSymbolDef(node, symbolType: typeof(Symbols.Interaction));
			try
			{
				this.BeginScope(node);
				try
				{
					if (node.Line != null)
					{
						foreach (var child in node.Line)
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
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitLine(LineSyntax node)
		{
			this.Visit(node.Declaration);
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.Visit(node.Title);
				this.Visit(node.Destroy);
				this.Visit(node.Arrow);
				this.Visit(node.Alt);
				this.Visit(node.Opt);
				this.Visit(node.Loop);
				this.Visit(node.Ref);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTitle(TitleSyntax node)
		{
			this.BeginProperty(node.Text, name: "Name");
			try
			{
				this.Visit(node.Text);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitArrow(ArrowSyntax node)
		{
			this.BeginSymbolDef(node, symbolType: typeof(Symbols.Message));
			try
			{
				this.BeginProperty(node.Source, name: "Source");
				try
				{
					this.Visit(node.Source);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Type, name: "Kind");
				try
				{
					this.Visit(node.Type);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Target, name: "Target");
				try
				{
					this.Visit(node.Target);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Text, name: "Text");
				try
				{
					this.Visit(node.Text);
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
		
		public virtual void VisitDestroy(DestroySyntax node)
		{
			this.BeginSymbolDef(node, symbolType: typeof(Symbols.Destroy));
			try
			{
				this.BeginProperty(node.LifeLineName, name: "Lifeline");
				try
				{
					this.Visit(node.LifeLineName);
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
		
		public virtual void VisitAlt(AltSyntax node)
		{
			this.BeginSymbolDef(node, symbolType: typeof(Symbols.MultiFragment));
			try
			{
				this.BeginProperty(node, name: "Fragments");
				try
				{
					this.Visit(node.AltFragment);
					if (node.ElseFragment != null)
					{
						foreach (var child in node.ElseFragment)
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
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitAltFragment(AltFragmentSyntax node)
		{
			this.BeginSymbolDef(node, symbolType: typeof(Symbols.Fragment));
			try
			{
				this.BeginProperty(node, name: "Kind", value: Symbols.FragmentKind.Alt);
				try
				{
					this.BeginProperty(node.Condition, name: "Text");
					try
					{
						this.Visit(node.Condition);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.FragmentBody);
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
		
		public virtual void VisitElseFragment(ElseFragmentSyntax node)
		{
			this.BeginSymbolDef(node, symbolType: typeof(Symbols.Fragment));
			try
			{
				this.BeginProperty(node, name: "Kind", value: Symbols.FragmentKind.Else);
				try
				{
					this.BeginProperty(node.Condition, name: "Text");
					try
					{
						this.Visit(node.Condition);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.FragmentBody);
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
		
		public virtual void VisitLoop(LoopSyntax node)
		{
			this.BeginSymbolDef(node, symbolType: typeof(Symbols.Fragment));
			try
			{
				this.BeginProperty(node, name: "Kind", value: Symbols.FragmentKind.Loop);
				try
				{
					this.Visit(node.LoopFragment);
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
		
		public virtual void VisitLoopFragment(LoopFragmentSyntax node)
		{
			this.BeginProperty(node.Condition, name: "Text");
			try
			{
				this.Visit(node.Condition);
			}
			finally
			{
				this.EndProperty();
			}
			this.Visit(node.FragmentBody);
		}
		
		public virtual void VisitOpt(OptSyntax node)
		{
			this.BeginSymbolDef(node, symbolType: typeof(Symbols.Fragment));
			try
			{
				this.BeginProperty(node, name: "Kind", value: Symbols.FragmentKind.Opt);
				try
				{
					this.Visit(node.OptFragment);
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
		
		public virtual void VisitOptFragment(OptFragmentSyntax node)
		{
			this.BeginProperty(node.Condition, name: "Text");
			try
			{
				this.Visit(node.Condition);
			}
			finally
			{
				this.EndProperty();
			}
			this.Visit(node.FragmentBody);
		}
		
		public virtual void VisitRef(RefSyntax node)
		{
			this.BeginSymbolDef(node, symbolType: typeof(Symbols.RefFragment));
			try
			{
				this.BeginProperty(node, name: "Kind", value: Symbols.FragmentKind.Ref);
				try
				{
					this.Visit(node.SimpleRefFragment);
					this.Visit(node.MessageRefFragment);
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
		
		public virtual void VisitSimpleRefFragment(SimpleRefFragmentSyntax node)
		{
			this.BeginProperty(node.SimpleBody, name: "Text");
			try
			{
				this.Visit(node.SimpleBody);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitMessageRefFragment(MessageRefFragmentSyntax node)
		{
			this.Visit(node.RefInput);
			this.BeginProperty(node.SimpleBody, name: "Text");
			try
			{
				this.Visit(node.SimpleBody);
			}
			finally
			{
				this.EndProperty();
			}
			this.Visit(node.RefOutput);
		}
		
		public virtual void VisitRefInput(RefInputSyntax node)
		{
			this.BeginProperty(node, name: "Input");
			try
			{
				this.BeginSymbolDef(node, symbolType: typeof(Symbols.Message));
				try
				{
					this.BeginProperty(node.Source, name: "Source");
					try
					{
						this.Visit(node.Source);
					}
					finally
					{
						this.EndProperty();
					}
					this.BeginProperty(node.SourceType, name: "Kind");
					try
					{
						this.Visit(node.SourceType);
					}
					finally
					{
						this.EndProperty();
					}
					this.BeginProperty(node.Message, name: "Text");
					try
					{
						this.Visit(node.Message);
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
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitRefOutput(RefOutputSyntax node)
		{
			this.BeginProperty(node, name: "Output");
			try
			{
				this.BeginSymbolDef(node, symbolType: typeof(Symbols.Message));
				try
				{
					this.BeginProperty(node.TargetType, name: "Kind");
					try
					{
						this.Visit(node.TargetType);
					}
					finally
					{
						this.EndProperty();
					}
					this.BeginProperty(node.Target, name: "Target");
					try
					{
						this.Visit(node.Target);
					}
					finally
					{
						this.EndProperty();
					}
					this.BeginProperty(node.Message, name: "Text");
					try
					{
						this.Visit(node.Message);
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
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitFragmentBody(FragmentBodySyntax node)
		{
			if (node.Line != null)
			{
				foreach (var child in node.Line)
				{
					this.Visit(child);
				}
			}
		}
		
		public virtual void VisitEnd(EndSyntax node)
		{
		}
		
		public virtual void VisitNote(NoteSyntax node)
		{
		}
		
		public virtual void VisitSingleLineNote(SingleLineNoteSyntax node)
		{
		}
		
		public virtual void VisitMultiLineNote(MultiLineNoteSyntax node)
		{
		}
		
		public virtual void VisitSimpleBody(SimpleBodySyntax node)
		{
		}
		
		public virtual void VisitSimpleLine(SimpleLineSyntax node)
		{
		}
		
		public virtual void VisitArrowType(ArrowTypeSyntax node)
		{
			switch (node.ArrowType.GetKind().Switch())
			{
				case SequenceSyntaxKind.TSync:
					break;
				case SequenceSyntaxKind.TAsync:
					break;
				case SequenceSyntaxKind.TReturn:
					break;
				case SequenceSyntaxKind.TCreate:
					break;
				default:
					break;
			}
		}
		
		public virtual void VisitLifeLineName(LifeLineNameSyntax node)
		{
			this.BeginProperty(node, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
			try
			{
				this.BeginSymbolDef(node, symbolType: typeof(Symbols.Lifeline), merge: true);
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
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitText(TextSyntax node)
		{
		}
		
		public virtual void VisitIdentifierPart(IdentifierPartSyntax node)
		{
		}
	}
}

