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

using MetaDslx.Languages.Compiler.Model;

namespace MetaDslx.Languages.Compiler.Binding
{
    public class CompilerBinderFactoryVisitor : BinderFactoryVisitor, ICompilerSyntaxVisitor<Binder>
    {
		public static object UseRuleDeclarations = new object();
		public static object UseQualifier = new object();
		public static object UseParserRuleIdentifier = new object();
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
		public static object UseTNegate = new object();
		public static object UseStringLiteral = new object();
		public static object UseIdentifier = new object();
		public static object UseKHidden = new object();
		public static object UseKFragment = new object();
		public static object UseLexerRuleIdentifier = new object();
		public static object UseLString = new object();
		public static object UseLCharacter = new object();
		public static object UseStart = new object();
		public static object UseEnd = new object();
		public static object UseNamespaceDeclaration = new object();
		public static object UseName = new object();
		public static object UseQualifiedName = new object();
		public static object UseNamespaceBody = new object();
		public static object UseUsingDeclaration = new object();
		public static object UseGrammarDeclaration = new object();
		public static object UseAnnotation = new object();
		public static object Use = new object();
		public static object UseRuleDeclaration = new object();
		public static object UseLexerRuleDeclaration = new object();
		public static object UseParserRuleAlt = new object();
		public static object UseParserRuleSimple = new object();
		public static object UseParserRuleName = new object();
		public static object UseParserRuleAltRef = new object();
		public static object UseParserRuleNamedElement = new object();
		public static object UseEofElement = new object();
		public static object UseElementName = new object();
		public static object UseAssign = new object();
		public static object UseMultiplicity = new object();
		public static object UseParserRuleElement = new object();
		public static object UseParserRuleFixedElement = new object();
		public static object UseParserRuleReference = new object();
		public static object UseParserRuleWildcardElement = new object();
		public static object UseParserRuleBlockElement = new object();
		public static object UseModifier = new object();
		public static object UseLexerRuleName = new object();
		public static object UseLexerRuleAlternative = new object();
		public static object UseLexerRuleAlternativeElement = new object();
		public static object UseLexerRuleElement = new object();
		public static object UseLexerRuleReferenceElement = new object();
		public static object UseLexerRuleFixedStringElement = new object();
		public static object UseLexerRuleFixedCharElement = new object();
		public static object UseLexerRuleWildcardElement = new object();
		public static object UseLexerRuleBlockElement = new object();
		public static object UseLexerRuleRangeElement = new object();
		public static object UseNullLiteral = new object();
		public static object UseBooleanLiteral = new object();
		public static object UseIntegerLiteral = new object();
		public static object UseDecimalLiteral = new object();
		public static object UseScientificLiteral = new object();
		public static object UseParserRuleDeclaration = new object();
		public static object UseParserNegatedElement = new object();

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
		
		public Binder VisitAnnotation(AnnotationSyntax parent)
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Annotations");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Annotation));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNamespaceDeclaration(NamespaceDeclarationSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Namespace), nestingProperty: "Members", merge: true);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNamespaceBody(NamespaceBodySyntax parent)
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
				resultBinder = this.BinderFactory.CreateScopeBinder(resultBinder, parent);
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Members");
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
		
		public Binder VisitUsingDeclaration(UsingDeclarationSyntax parent)
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
				resultBinder = this.BinderFactory.CreateImportBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
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
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleAlt(ParserRuleAltSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRuleAlt));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Qualifier, name: "DefinedModelObject");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Qualifier, types: ImmutableArray.Create(typeof(System.Type)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleAltRef(ParserRuleAltRefSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.ParserRuleIdentifier)) use = UseParserRuleIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Alternatives");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseParserRuleIdentifier)
				{
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.ParserRuleIdentifier, types: ImmutableArray.Create(typeof(ParserRule)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleSimple(ParserRuleSimpleSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRuleSimple));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Qualifier, name: "DefinedModelObject");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Qualifier, types: ImmutableArray.Create(typeof(System.Type)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRuleNamedElement));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Element");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRuleEofElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleNamedElement(ParserRuleNamedElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRuleNamedElement));
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
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TNegate)) use = UseTNegate;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTNegate)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TNegate, name: "IsNegated", value: true);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
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
		
		public Binder VisitParserRuleFixedElement(ParserRuleFixedElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRuleFixedElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseStringLiteral)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.StringLiteral, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitParserRuleWildcardElement(ParserRuleWildcardElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRuleWildcardElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRuleReferenceElement));
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
		
		public Binder VisitParserRuleBlockElement(ParserRuleBlockElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParserRuleBlockElement));
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
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Modifier)) use = UseModifier;
				if (LookupPosition.IsInNode(this.Position, parent.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRule));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseModifier)
				{
					switch (parent.Modifier.GetKind().Switch())
					{
						case CompilerSyntaxKind.KHidden:
							resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Modifier, name: "IsHidden", value: true);
							break;
						case CompilerSyntaxKind.KFragment:
							resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Modifier, name: "IsFragment", value: true);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseQualifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Qualifier, name: "ValueType");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Qualifier, types: ImmutableArray.Create(typeof(System.Type)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRuleAlternative));
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
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TNegate)) use = UseTNegate;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Elements");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRuleAlternativeElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTNegate)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TNegate, name: "IsNegated", value: true);
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
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Element");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleReferenceElement(LexerRuleReferenceElementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.LexerRuleIdentifier)) use = UseLexerRuleIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRuleReferenceElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLexerRuleIdentifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.LexerRuleIdentifier, name: "Rule");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.LexerRuleIdentifier, types: ImmutableArray.Create(typeof(LexerRule)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleWildcardElement(LexerRuleWildcardElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRuleWildcardElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.LString)) use = UseLString;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRuleFixedStringElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLString)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.LString, name: "Value");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.LString);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.LCharacter)) use = UseLCharacter;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRuleFixedCharElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLCharacter)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.LCharacter, name: "Value");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.LCharacter);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleBlockElement(LexerRuleBlockElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRuleBlockElement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLexerRuleRangeElement(LexerRuleRangeElementSyntax parent)
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
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LexerRuleRangeElement));
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
		
		public Binder VisitQualifiedName(QualifiedNameSyntax parent)
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
		
		public Binder VisitQualifier(QualifierSyntax parent)
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
				resultBinder = this.BinderFactory.CreateQualifierBinder(resultBinder, parent);
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
		
		public Binder VisitLexerRuleIdentifier(LexerRuleIdentifierSyntax parent)
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
		
		public Binder VisitParserRuleIdentifier(ParserRuleIdentifierSyntax parent)
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
		
		public Binder VisitCharLiteral(CharLiteralSyntax parent)
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

