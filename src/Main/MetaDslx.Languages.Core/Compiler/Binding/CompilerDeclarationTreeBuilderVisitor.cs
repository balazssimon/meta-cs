// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.Languages.Compiler;
using MetaDslx.Languages.Compiler.Syntax;
using MetaDslx.Languages.Compiler.Symbols;

//using MetaDslx.Languages.Core.Model;
using MetaDslx.Languages.Compiler.Model;

namespace MetaDslx.Languages.Compiler.Binding
{
	public class CompilerDeclarationTreeBuilderVisitor : MetaDslx.CodeAnalysis.Declarations.DeclarationTreeBuilderVisitor, ICompilerSyntaxVisitor
	{
        protected CompilerDeclarationTreeBuilderVisitor(CompilerSyntaxTree syntaxTree, MetaDslx.CodeAnalysis.Symbols.SymbolFacts symbolFacts, string scriptClassName, bool isSubmission)
            : base(syntaxTree, symbolFacts, scriptClassName, isSubmission)
        {
        }

        public static MetaDslx.CodeAnalysis.Declarations.RootSingleDeclaration ForTree(
            CompilerSyntaxTree syntaxTree,
            MetaDslx.CodeAnalysis.Symbols.SymbolFacts symbolFacts,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new CompilerDeclarationTreeBuilderVisitor(syntaxTree, symbolFacts, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }


		public virtual void VisitSkippedTokensTrivia(CompilerSkippedTokensTriviaSyntax node)
		{
		}
		
		public virtual void VisitMain(MainSyntax node)
		{
			if (node.GrammarDeclaration != null)
			{
			    this.Visit(node.GrammarDeclaration);
			}
		}
		
		public virtual void VisitGrammarDeclaration(GrammarDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(Grammar));
			try
			{
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.RuleDeclarations != null)
				{
				    this.BeginScope(node.RuleDeclarations);
				    try
				    {
				    	this.Visit(node.RuleDeclarations);
				    }
				    finally
				    {
				    	this.EndScope(node.RuleDeclarations);
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(Grammar));
			}
		}
		
		public virtual void VisitRuleDeclarations(RuleDeclarationsSyntax node)
		{
			if (node.RuleDeclaration != null)
			{
				foreach (var child in node.RuleDeclaration)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitRuleDeclaration(RuleDeclarationSyntax node)
		{
			this.BeginProperty(node, name: "Rules");
			try
			{
				if (node.ParserRuleDeclaration != null)
				{
				    this.Visit(node.ParserRuleDeclaration);
				}
				if (node.LexerRuleDeclaration != null)
				{
				    this.Visit(node.LexerRuleDeclaration);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Rules");
			}
		}
		
		public virtual void VisitParserRuleDeclaration(ParserRuleDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(ParserRule));
			try
			{
				if (node.ParserRuleName != null)
				{
				    this.Visit(node.ParserRuleName);
				}
				if (node.ParserRuleAlternative != null)
				{
					foreach (var child in node.ParserRuleAlternative)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ParserRule));
			}
		}
		
		public virtual void VisitParserRuleAlternative(ParserRuleAlternativeSyntax node)
		{
			this.BeginProperty(node, name: "Alternatives");
			try
			{
				this.BeginDefine(node, type: typeof(RuleAlternative));
				try
				{
					if (node.ParserRuleAlternativeElement != null)
					{
						foreach (var child in node.ParserRuleAlternativeElement)
						{
					        this.Visit(child);
						}
					}
					if (node.EofElement != null)
					{
					    this.Visit(node.EofElement);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(RuleAlternative));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Alternatives");
			}
		}
		
		public virtual void VisitEofElement(EofElementSyntax node)
		{
			this.BeginProperty(node, name: "Elements");
			try
			{
				this.BeginDefine(node, type: typeof(RuleElement));
				try
				{
					this.BeginProperty(node, name: "Element");
					try
					{
						this.BeginDefine(node, type: typeof(EofElement));
						try
						{
						}
						finally
						{
							this.EndDefine(node, type: typeof(EofElement));
						}
					}
					finally
					{
						this.EndProperty(node, name: "Element");
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(RuleElement));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Elements");
			}
		}
		
		public virtual void VisitParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax node)
		{
			this.BeginProperty(node, name: "Elements");
			try
			{
				this.BeginDefine(node, type: typeof(RuleElement));
				try
				{
					if (node.ParserMultiElement != null)
					{
					    this.Visit(node.ParserMultiElement);
					}
					if (node.ParserNegatedElement != null)
					{
					    this.Visit(node.ParserNegatedElement);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(RuleElement));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Elements");
			}
		}
		
		public virtual void VisitParserMultiElement(ParserMultiElementSyntax node)
		{
			if (node.ElementName != null)
			{
			    this.Visit(node.ElementName);
			}
			if (node.Assign != null)
			{
			    this.Visit(node.Assign);
			}
			if (node.ParserRuleElement != null)
			{
			    this.Visit(node.ParserRuleElement);
			}
			if (node.Multiplicity != null)
			{
			    this.Visit(node.Multiplicity);
			}
		}
		
		public virtual void VisitAssign(AssignSyntax node)
		{
			this.BeginProperty(node, name: "AssignmentOperator");
			try
			{
				if (node.Assign != null)
				{
				    switch (node.Assign.GetKind().Switch())
				    {
				    	case CompilerSyntaxKind.TAssign:
				    		this.BeginValue(node.Assign, value: AssignmentOperator.Assign);
				    		try
				    		{
				    			this.Visit(node.Assign);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Assign, value: AssignmentOperator.Assign);
				    		}
				    		break;
				    	case CompilerSyntaxKind.TQuestionAssign:
				    		this.BeginValue(node.Assign, value: AssignmentOperator.QuestionAssign);
				    		try
				    		{
				    			this.Visit(node.Assign);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Assign, value: AssignmentOperator.QuestionAssign);
				    		}
				    		break;
				    	case CompilerSyntaxKind.TNegatedAssign:
				    		this.BeginValue(node.Assign, value: AssignmentOperator.NegatedAssign);
				    		try
				    		{
				    			this.Visit(node.Assign);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Assign, value: AssignmentOperator.NegatedAssign);
				    		}
				    		break;
				    	case CompilerSyntaxKind.TPlusAssign:
				    		this.BeginValue(node.Assign, value: AssignmentOperator.PlusAssign);
				    		try
				    		{
				    			this.Visit(node.Assign);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Assign, value: AssignmentOperator.PlusAssign);
				    		}
				    		break;
				    	default:
				    		break;
				    }
				}
			}
			finally
			{
				this.EndProperty(node, name: "AssignmentOperator");
			}
		}
		
		public virtual void VisitMultiplicity(MultiplicitySyntax node)
		{
			this.BeginProperty(node, name: "Multiplicity");
			try
			{
				if (node.Multiplicity != null)
				{
				    switch (node.Multiplicity.GetKind().Switch())
				    {
				    	case CompilerSyntaxKind.TNonGreedyZeroOrOne:
				    		this.BeginValue(node.Multiplicity, value: Multiplicity.NonGreedyZeroOrOne);
				    		try
				    		{
				    			this.Visit(node.Multiplicity);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Multiplicity, value: Multiplicity.NonGreedyZeroOrOne);
				    		}
				    		break;
				    	case CompilerSyntaxKind.TNonGreedyZeroOrMore:
				    		this.BeginValue(node.Multiplicity, value: Multiplicity.NonGreedyZeroOrMore);
				    		try
				    		{
				    			this.Visit(node.Multiplicity);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Multiplicity, value: Multiplicity.NonGreedyZeroOrMore);
				    		}
				    		break;
				    	case CompilerSyntaxKind.TNonGreedyOneOrMore:
				    		this.BeginValue(node.Multiplicity, value: Multiplicity.NonGreedyOneOrMore);
				    		try
				    		{
				    			this.Visit(node.Multiplicity);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Multiplicity, value: Multiplicity.NonGreedyOneOrMore);
				    		}
				    		break;
				    	case CompilerSyntaxKind.TZeroOrOne:
				    		this.BeginValue(node.Multiplicity, value: Multiplicity.ZeroOrOne);
				    		try
				    		{
				    			this.Visit(node.Multiplicity);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Multiplicity, value: Multiplicity.ZeroOrOne);
				    		}
				    		break;
				    	case CompilerSyntaxKind.TZeroOrMore:
				    		this.BeginValue(node.Multiplicity, value: Multiplicity.ZeroOrMore);
				    		try
				    		{
				    			this.Visit(node.Multiplicity);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Multiplicity, value: Multiplicity.ZeroOrMore);
				    		}
				    		break;
				    	case CompilerSyntaxKind.TOneOrMore:
				    		this.BeginValue(node.Multiplicity, value: Multiplicity.OneOrMore);
				    		try
				    		{
				    			this.Visit(node.Multiplicity);
				    		}
				    		finally
				    		{
				    			this.EndValue(node.Multiplicity, value: Multiplicity.OneOrMore);
				    		}
				    		break;
				    	default:
				    		break;
				    }
				}
			}
			finally
			{
				this.EndProperty(node, name: "Multiplicity");
			}
		}
		
		public virtual void VisitParserNegatedElement(ParserNegatedElementSyntax node)
		{
			this.BeginProperty(node, name: "IsNegated", value: true);
			try
			{
				if (node.ParserRuleElement != null)
				{
				    this.Visit(node.ParserRuleElement);
				}
			}
			finally
			{
				this.EndProperty(node, name: "IsNegated", value: true);
			}
		}
		
		public virtual void VisitParserRuleElement(ParserRuleElementSyntax node)
		{
			this.BeginProperty(node, name: "Element");
			try
			{
				if (node.FixedElement != null)
				{
				    this.Visit(node.FixedElement);
				}
				if (node.ParserRuleReference != null)
				{
				    this.Visit(node.ParserRuleReference);
				}
				if (node.ParserRuleBlock != null)
				{
				    this.Visit(node.ParserRuleBlock);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Element");
			}
		}
		
		public virtual void VisitFixedElement(FixedElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(FixedElement));
			try
			{
				if (node.StringLiteral != null)
				{
				    this.BeginProperty(node.StringLiteral, name: "Value");
				    try
				    {
				    	this.Visit(node.StringLiteral);
				    }
				    finally
				    {
				    	this.EndProperty(node.StringLiteral, name: "Value");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(FixedElement));
			}
		}
		
		public virtual void VisitParserRuleReference(ParserRuleReferenceSyntax node)
		{
			this.BeginDefine(node, type: typeof(RuleReference));
			try
			{
				if (node.Identifier != null)
				{
				    this.BeginProperty(node.Identifier, name: "Rule");
				    try
				    {
				    	this.BeginUse(node.Identifier, types: ImmutableArray.Create(typeof(Rule)));
				    	try
				    	{
				    		this.Visit(node.Identifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Identifier, types: ImmutableArray.Create(typeof(Rule)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Identifier, name: "Rule");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(RuleReference));
			}
		}
		
		public virtual void VisitParserRuleBlock(ParserRuleBlockSyntax node)
		{
			this.BeginDefine(node, type: typeof(RuleBlock));
			try
			{
				if (node.ParserRuleAlternative != null)
				{
					foreach (var child in node.ParserRuleAlternative)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(RuleBlock));
			}
		}
		
		public virtual void VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(LexerRule));
			try
			{
				if (node.LexerRuleName != null)
				{
				    this.Visit(node.LexerRuleName);
				}
				if (node.LexerRuleAlternative != null)
				{
					foreach (var child in node.LexerRuleAlternative)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(LexerRule));
			}
		}
		
		public virtual void VisitLexerRuleAlternative(LexerRuleAlternativeSyntax node)
		{
			this.BeginProperty(node, name: "Alternatives");
			try
			{
				this.BeginDefine(node, type: typeof(RuleAlternative));
				try
				{
					if (node.LexerRuleAlternativeElement != null)
					{
						foreach (var child in node.LexerRuleAlternativeElement)
						{
					        this.Visit(child);
						}
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(RuleAlternative));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Alternatives");
			}
		}
		
		public virtual void VisitLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node)
		{
			this.BeginProperty(node, name: "Elements");
			try
			{
				this.BeginDefine(node, type: typeof(RuleElement));
				try
				{
					if (node.LexerMultiElement != null)
					{
					    this.Visit(node.LexerMultiElement);
					}
					if (node.LexerNegatedElement != null)
					{
					    this.Visit(node.LexerNegatedElement);
					}
					if (node.LexerRangeElement != null)
					{
					    this.Visit(node.LexerRangeElement);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(RuleElement));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Elements");
			}
		}
		
		public virtual void VisitLexerMultiElement(LexerMultiElementSyntax node)
		{
			if (node.LexerRuleElement != null)
			{
			    this.Visit(node.LexerRuleElement);
			}
			if (node.Multiplicity != null)
			{
			    this.Visit(node.Multiplicity);
			}
		}
		
		public virtual void VisitLexerNegatedElement(LexerNegatedElementSyntax node)
		{
			this.BeginProperty(node, name: "IsNegated", value: true);
			try
			{
				if (node.LexerRuleElement != null)
				{
				    this.Visit(node.LexerRuleElement);
				}
			}
			finally
			{
				this.EndProperty(node, name: "IsNegated", value: true);
			}
		}
		
		public virtual void VisitLexerRangeElement(LexerRangeElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(RangeElement));
			try
			{
				if (node.Start != null)
				{
				    this.BeginProperty(node.Start, name: "Start");
				    try
				    {
				    	this.Visit(node.Start);
				    }
				    finally
				    {
				    	this.EndProperty(node.Start, name: "Start");
				    }
				}
				if (node.End != null)
				{
				    this.BeginProperty(node.End, name: "End");
				    try
				    {
				    	this.Visit(node.End);
				    }
				    finally
				    {
				    	this.EndProperty(node.End, name: "End");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(RangeElement));
			}
		}
		
		public virtual void VisitLexerRuleElement(LexerRuleElementSyntax node)
		{
			if (node.FixedElement != null)
			{
			    this.Visit(node.FixedElement);
			}
			if (node.WildcardElement != null)
			{
			    this.Visit(node.WildcardElement);
			}
			if (node.LexerRuleReference != null)
			{
			    this.Visit(node.LexerRuleReference);
			}
			if (node.LexerRuleBlock != null)
			{
			    this.Visit(node.LexerRuleBlock);
			}
		}
		
		public virtual void VisitWildcardElement(WildcardElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(WildcardElement));
			try
			{
			}
			finally
			{
				this.EndDefine(node, type: typeof(WildcardElement));
			}
		}
		
		public virtual void VisitLexerRuleReference(LexerRuleReferenceSyntax node)
		{
			this.BeginDefine(node, type: typeof(RuleReference));
			try
			{
				if (node.Identifier != null)
				{
				    this.BeginProperty(node.Identifier, name: "Rule");
				    try
				    {
				    	this.BeginUse(node.Identifier, types: ImmutableArray.Create(typeof(LexerRule)));
				    	try
				    	{
				    		this.Visit(node.Identifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Identifier, types: ImmutableArray.Create(typeof(LexerRule)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Identifier, name: "Rule");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(RuleReference));
			}
		}
		
		public virtual void VisitLexerRuleBlock(LexerRuleBlockSyntax node)
		{
			this.BeginDefine(node, type: typeof(RuleBlock));
			try
			{
				if (node.LexerRuleAlternative != null)
				{
					foreach (var child in node.LexerRuleAlternative)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(RuleBlock));
			}
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName(node);
			try
			{
				if (node.Identifier != null)
				{
				    this.Visit(node.Identifier);
				}
			}
			finally
			{
				this.EndName(node);
			}
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			this.BeginIdentifier(node);
			try
			{
			}
			finally
			{
				this.EndIdentifier(node);
			}
		}
		
		public virtual void VisitLexerRuleName(LexerRuleNameSyntax node)
		{
			this.BeginName(node);
			try
			{
				this.BeginIdentifier(node);
				try
				{
				}
				finally
				{
					this.EndIdentifier(node);
				}
			}
			finally
			{
				this.EndName(node);
			}
		}
		
		public virtual void VisitParserRuleName(ParserRuleNameSyntax node)
		{
			this.BeginName(node);
			try
			{
				this.BeginIdentifier(node);
				try
				{
				}
				finally
				{
					this.EndIdentifier(node);
				}
			}
			finally
			{
				this.EndName(node);
			}
		}
		
		public virtual void VisitElementName(ElementNameSyntax node)
		{
			this.BeginName(node);
			try
			{
				this.BeginIdentifier(node);
				try
				{
				}
				finally
				{
					this.EndIdentifier(node);
				}
			}
			finally
			{
				this.EndName(node);
			}
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
			if (node.NullLiteral != null)
			{
			    this.Visit(node.NullLiteral);
			}
			if (node.BooleanLiteral != null)
			{
			    this.Visit(node.BooleanLiteral);
			}
			if (node.IntegerLiteral != null)
			{
			    this.Visit(node.IntegerLiteral);
			}
			if (node.DecimalLiteral != null)
			{
			    this.Visit(node.DecimalLiteral);
			}
			if (node.ScientificLiteral != null)
			{
			    this.Visit(node.ScientificLiteral);
			}
			if (node.StringLiteral != null)
			{
			    this.Visit(node.StringLiteral);
			}
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
			this.BeginValue(node);
			try
			{
			}
			finally
			{
				this.EndValue(node);
			}
		}
	}
}

