// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
using MetaDslx.Languages.Compiler;
using MetaDslx.Languages.Compiler.Syntax;
using MetaDslx.Languages.Compiler.Symbols;

//using MetaDslx.Languages.Core.Model;
using MetaDslx.Languages.Compiler.Model;

namespace MetaDslx.Languages.Compiler.Binding
{
    public class CompilerBinderFactoryVisitor : BinderFactoryVisitor, ICompilerSyntaxVisitor<Binder>
    {
		public static object UseRuleDeclarations = new object();
		public static object UseTAssign = new object();
		public static object UseTQuestionAssign = new object();
		public static object UseTNegatedAssign = new object();
		public static object UseTPlusAssign = new object();
		public static object UseTNonGreedyZeroOrOne = new object();
		public static object UseTNonGreedyZeroOrMore = new object();
		public static object UseTNonGreedyOneOrMore = new object();
		public static object UseTZeroOrOne = new object();
		public static object UseTZeroOrMore = new object();
		public static object UseTOneOrMore = new object();
		public static object UseStringLiteral = new object();
		public static object UseIdentifier = new object();
		public static object UseStart = new object();
		public static object UseEnd = new object();
		public static object UseGrammarDeclaration = new object();
		public static object UseName = new object();
		public static object UseRuleDeclaration = new object();
		public static object UseParserRuleDeclaration = new object();
		public static object UseLexerRuleDeclaration = new object();
		public static object UseParserRuleName = new object();
		public static object UseParserRuleAlternative = new object();
		public static object UseParserRuleAlternativeElement = new object();
		public static object UseEofElement = new object();
		public static object UseParserNegatedElement = new object();
		public static object Use = new object();
		public static object UseElementName = new object();
		public static object UseAssign = new object();
		public static object UseParserRuleElement = new object();
		public static object UseMultiplicity = new object();
		public static object UseFixedElement = new object();
		public static object UseParserRuleReference = new object();
		public static object UseParserRuleBlock = new object();
		public static object UseLexerRuleName = new object();
		public static object UseLexerRuleAlternative = new object();
		public static object UseLexerRuleAlternativeElement = new object();
		public static object UseLexerNegatedElement = new object();
		public static object UseLexerRangeElement = new object();
		public static object UseWildcardElement = new object();
		public static object UseLexerRuleReference = new object();
		public static object UseLexerRuleBlock = new object();
		public static object UseNullLiteral = new object();
		public static object UseBooleanLiteral = new object();
		public static object UseIntegerLiteral = new object();
		public static object UseDecimalLiteral = new object();
		public static object UseScientificLiteral = new object();
		public static object UseParserMultiElement = new object();
		public static object UseLexerMultiElement = new object();
		public static object UseLexerRuleElement = new object();

        public CompilerBinderFactoryVisitor(CompilerBinderFactory binderFactory)
			: base(binderFactory)
        {

        }

		public new CompilerBinderFactory BinderFactory => (CompilerBinderFactory)base.BinderFactory;

        public Binder VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax parent)
        {
            return null;
        }

		
		public Binder VisitMain(MainSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
			    return this.GetCompilationUnitBinder(parent, inUsing: IsInUsing(parent), inScript: InScript);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
			    resultBinder = this.GetCompilationUnitBinder(parent, inUsing: IsInUsing(parent), inScript: InScript);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitGrammarDeclaration(GrammarDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.RuleDeclarations)) use = UseRuleDeclarations;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Grammar));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseRuleDeclarations)
				{
					resultBinder = this.BinderFactory.CreateScopeBinder(resultBinder, parent.RuleDeclarations);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRuleDeclarations(RuleDeclarationsSyntax parent)
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
		
		public Binder VisitRuleDeclaration(RuleDeclarationSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Rules");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleDeclaration(ParserRuleDeclarationSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRule));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleAlternative(ParserRuleAlternativeSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Alternatives");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RuleAlternative));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEofElement(EofElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Elements");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RuleElement));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Element");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(EofElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Elements");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RuleElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParserMultiElement(ParserMultiElementSyntax parent)
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
		
		public Binder VisitAssign(AssignSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Assign)) use = UseAssign;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "AssignmentOperator");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseAssign)
				{
					switch (parent.Assign.GetKind().Switch())
					{
						case CompilerSyntaxKind.TAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Assign, value: AssignmentOperator.Assign);
							break;
						case CompilerSyntaxKind.TQuestionAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Assign, value: AssignmentOperator.QuestionAssign);
							break;
						case CompilerSyntaxKind.TNegatedAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Assign, value: AssignmentOperator.NegatedAssign);
							break;
						case CompilerSyntaxKind.TPlusAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Assign, value: AssignmentOperator.PlusAssign);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitMultiplicity(MultiplicitySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Multiplicity)) use = UseMultiplicity;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Multiplicity");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseMultiplicity)
				{
					switch (parent.Multiplicity.GetKind().Switch())
					{
						case CompilerSyntaxKind.TNonGreedyZeroOrOne:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Multiplicity, value: Multiplicity.NonGreedyZeroOrOne);
							break;
						case CompilerSyntaxKind.TNonGreedyZeroOrMore:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Multiplicity, value: Multiplicity.NonGreedyZeroOrMore);
							break;
						case CompilerSyntaxKind.TNonGreedyOneOrMore:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Multiplicity, value: Multiplicity.NonGreedyOneOrMore);
							break;
						case CompilerSyntaxKind.TZeroOrOne:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Multiplicity, value: Multiplicity.ZeroOrOne);
							break;
						case CompilerSyntaxKind.TZeroOrMore:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Multiplicity, value: Multiplicity.ZeroOrMore);
							break;
						case CompilerSyntaxKind.TOneOrMore:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Multiplicity, value: Multiplicity.OneOrMore);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitParserNegatedElement(ParserNegatedElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "IsNegated", value: true);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleElement(ParserRuleElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Element");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitFixedElement(FixedElementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.StringLiteral)) use = UseStringLiteral;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(FixedElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.StringLiteral, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleReference(ParserRuleReferenceSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Identifier)) use = UseIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RuleReference));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Identifier, name: "Rule");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Identifier, types: ImmutableArray.Create(typeof(Rule)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleBlock(ParserRuleBlockSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RuleBlock));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRule));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleAlternative(LexerRuleAlternativeSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Alternatives");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RuleAlternative));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Elements");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RuleElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerMultiElement(LexerMultiElementSyntax parent)
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
		
		public Binder VisitLexerNegatedElement(LexerNegatedElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "IsNegated", value: true);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRangeElement(LexerRangeElementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Start)) use = UseStart;
				if (LookupPosition.IsInNode(this.Position, parent.End)) use = UseEnd;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RangeElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseStart)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Start, name: "Start");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseEnd)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.End, name: "End");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleElement(LexerRuleElementSyntax parent)
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
		
		public Binder VisitWildcardElement(WildcardElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(WildcardElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleReference(LexerRuleReferenceSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Identifier)) use = UseIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RuleReference));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Identifier, name: "Rule");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Identifier, types: ImmutableArray.Create(typeof(LexerRule)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleBlock(LexerRuleBlockSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(RuleBlock));
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
				resultBinder = this.BinderFactory.CreateNameBinder(resultBinder, parent);
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
				resultBinder = this.BinderFactory.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleName(LexerRuleNameSyntax parent)
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
				resultBinder = this.BinderFactory.CreateNameBinder(resultBinder, parent);
				resultBinder = this.BinderFactory.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleName(ParserRuleNameSyntax parent)
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
				resultBinder = this.BinderFactory.CreateNameBinder(resultBinder, parent);
				resultBinder = this.BinderFactory.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitElementName(ElementNameSyntax parent)
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
				resultBinder = this.BinderFactory.CreateNameBinder(resultBinder, parent);
				resultBinder = this.BinderFactory.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLiteral(LiteralSyntax parent)
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
		
		public Binder VisitNullLiteral(NullLiteralSyntax parent)
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
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBooleanLiteral(BooleanLiteralSyntax parent)
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
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIntegerLiteral(IntegerLiteralSyntax parent)
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
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDecimalLiteral(DecimalLiteralSyntax parent)
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
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitScientificLiteral(ScientificLiteralSyntax parent)
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
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStringLiteral(StringLiteralSyntax parent)
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
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
    }
}

