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
using WebSequenceDiagramsModel.Syntax;
using WebSequenceDiagramsModel.Symbols;

namespace WebSequenceDiagramsModel.Binding
{
    public class SequenceBinderFactoryVisitor : BinderFactoryVisitor, ISequenceSyntaxVisitor<Binder>
    {
		public static object UseSource = new object();
		public static object UseType = new object();
		public static object UseTarget = new object();
		public static object UseText = new object();
		public static object UseLifeLineName = new object();
		public static object UseCondition = new object();
		public static object UseRefText = new object();
		public static object UseSourceType = new object();
		public static object UseMessage = new object();
		public static object UseTargetType = new object();
		public static object UseTSync = new object();
		public static object UseTAsync = new object();
		public static object UseTReturn = new object();
		public static object UseTCreate = new object();
		public static object UseInteraction = new object();
		public static object UseDeclaration = new object();
		public static object UseDestroy = new object();
		public static object UseArrow = new object();
		public static object UseAlt = new object();
		public static object UseOpt = new object();
		public static object UseLoop = new object();
		public static object UseRef = new object();
		public static object UseName = new object();
		public static object UseAltFragment = new object();
		public static object UseElseFragment = new object();
		public static object UseRefInput = new object();
		public static object UseRefOutput = new object();
		public static object UseLine = new object();
		public static object UseArrowType = new object();
		public static object UseIdentifier = new object();
		public static object UseTitle = new object();
		public static object UseFragmentBody = new object();
		public static object UseLoopFragment = new object();
		public static object UseOptFragment = new object();
		public static object UseSimpleRefFragment = new object();
		public static object UseMessageRefFragment = new object();

        public SequenceBinderFactoryVisitor(BinderFactory symbolBuilder)
			: base(symbolBuilder)
        {

        }

        /// <summary>
        /// Returns binder that binds usings and aliases 
        /// </summary>
        /// <param name="unit">
        /// Specify <see cref="LanguageSyntaxNode"/> imports in the corresponding syntax node, or
        /// <see cref="CompilationUnitSyntax"/> for top-level imports.
        /// </param>
        /// <param name="inUsing">True if the binder will be used to bind a using directive.</param>
        public override Binder GetImportsBinder(LanguageSyntaxNode unit, bool inUsing)
        {
            if (unit.Kind == SequenceSyntaxKind.Main)
            {
                return this.GetCompilationUnitBinder(unit, inUsing: inUsing, inScript: InScript);
            }
            else
            {
                // TODO:MetaDslx - non-compilation-unit imports
                return null;
            }
        }

		
		public Binder VisitMain(MainSyntax parent)
		{
			return this.GetCompilationUnitBinder(parent, inUsing: IsInUsing(parent), inScript: InScript);
		}
		
		public Binder VisitInteraction(InteractionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Interaction));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTitleLine(TitleLineSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDeclarationLine(DeclarationLineSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDeclaration(DeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateScopeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTitle(TitleSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitArrow(ArrowSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Source)) use = UseSource;
				if (LookupPosition.IsInNode(this.Position, parent.Type)) use = UseType;
				if (LookupPosition.IsInNode(this.Position, parent.Target)) use = UseTarget;
				if (LookupPosition.IsInNode(this.Position, parent.Text)) use = UseText;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Message));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseSource)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Source, name: "Source");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Type, name: "Kind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTarget)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Target, name: "Target");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseText)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Text, name: "Text");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Text);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDestroy(DestroySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.LifeLineName)) use = UseLifeLineName;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Destroy));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLifeLineName)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.LifeLineName, name: "Lifeline");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAlt(AltSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.MultiFragment));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitAltFragment(AltFragmentSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Fragments");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Fragment));
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Kind", value: FragmentKind.Alt);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCondition)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Condition, name: "Text");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Condition);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitElseFragment(ElseFragmentSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Fragments");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Fragment));
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Kind", value: FragmentKind.Else);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCondition)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Condition, name: "Text");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Condition);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLoop(LoopSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Fragment));
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Kind", value: FragmentKind.Loop);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLoopFragment(LoopFragmentSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCondition)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Condition, name: "Text");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Condition);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitOpt(OptSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Fragment));
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Kind", value: FragmentKind.Opt);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitOptFragment(OptFragmentSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCondition)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Condition, name: "Text");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Condition);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRef(RefSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Declarations");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.RefFragment));
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Kind", value: FragmentKind.Ref);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSimpleRefFragment(SimpleRefFragmentSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.RefText)) use = UseRefText;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseRefText)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.RefText, name: "Text");
					resultBinder = this.CreateValueBinder(resultBinder, parent.RefText);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitMessageRefFragment(MessageRefFragmentSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitRefInput(RefInputSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Source)) use = UseSource;
				if (LookupPosition.IsInNode(this.Position, parent.SourceType)) use = UseSourceType;
				if (LookupPosition.IsInNode(this.Position, parent.Message)) use = UseMessage;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Input");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Message));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseSource)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Source, name: "Source");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseSourceType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.SourceType, name: "Kind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseMessage)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Message, name: "Text");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Message);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRefOutput(RefOutputSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TargetType)) use = UseTargetType;
				if (LookupPosition.IsInNode(this.Position, parent.Target)) use = UseTarget;
				if (LookupPosition.IsInNode(this.Position, parent.Message)) use = UseMessage;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Output");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Message));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTargetType)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TargetType, name: "Kind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTarget)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Target, name: "Target");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseMessage)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Message, name: "Text");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Message);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFragmentBody(FragmentBodySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnd(EndSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNote(NoteSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSingleLineNote(SingleLineNoteSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMultiLineNote(MultiLineNoteSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSimpleBody(SimpleBodySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSimpleLine(SimpleLineSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitArrowType(ArrowTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLifeLineName(LifeLineNameSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Declarations", owner: SymbolPropertyOwner.CurrentScope);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, symbolType: typeof(Symbols.Lifeline), merge: true);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitName(NameSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateNameBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIdentifier(IdentifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitText(TextSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIdentifierPart(IdentifierPartSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
    }
}

