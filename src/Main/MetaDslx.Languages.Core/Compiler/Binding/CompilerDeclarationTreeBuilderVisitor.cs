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
			if (node.NamespaceDeclaration != null)
			{
			    this.Visit(node.NamespaceDeclaration);
			}
		}
		
		public virtual void VisitAnnotation(AnnotationSyntax node)
		{
			this.BeginProperty(node, name: "Annotations");
			try
			{
				this.BeginDefine(node, type: typeof(Annotation));
				try
				{
					if (node.Name != null)
					{
					    this.Visit(node.Name);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(Annotation));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Annotations");
			}
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			try
			{
				if (node.QualifiedName != null)
				{
				    this.Visit(node.QualifiedName);
				}
				if (node.NamespaceBody != null)
				{
				    this.Visit(node.NamespaceBody);
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(Namespace), nestingProperty: "Members", merge: true);
			}
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.UsingDeclaration != null)
				{
					foreach (var child in node.UsingDeclaration)
					{
				        this.Visit(child);
					}
				}
				if (node.GrammarDeclaration != null)
				{
				    this.Visit(node.GrammarDeclaration);
				}
			}
			finally
			{
				this.EndScope(node);
			}
		}
		
		public virtual void VisitGrammarDeclaration(GrammarDeclarationSyntax node)
		{
			this.BeginProperty(node, name: "Members");
			try
			{
				this.BeginDefine(node, type: typeof(Grammar));
				try
				{
					if (node.Annotation != null)
					{
						foreach (var child in node.Annotation)
						{
					        this.Visit(child);
						}
					}
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
			finally
			{
				this.EndProperty(node, name: "Members");
			}
		}
		
		public virtual void VisitUsingDeclaration(UsingDeclarationSyntax node)
		{
			this.BeginImport(node);
			try
			{
				if (node.Name != null)
				{
				    this.Visit(node.Name);
				}
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndImport(node);
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
			if (node.ParserRuleAlt != null)
			{
			    this.Visit(node.ParserRuleAlt);
			}
			if (node.ParserRuleSimple != null)
			{
			    this.Visit(node.ParserRuleSimple);
			}
		}
		
		public virtual void VisitParserRuleAlt(ParserRuleAltSyntax node)
		{
			this.BeginDefine(node, type: typeof(ParserRuleAlt));
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
				        this.Visit(child);
					}
				}
				if (node.ParserRuleName != null)
				{
				    this.Visit(node.ParserRuleName);
				}
				if (node.Qualifier != null)
				{
				    this.BeginProperty(node.Qualifier, name: "DefinedModelObject");
				    try
				    {
				    	this.BeginUse(node.Qualifier, types: ImmutableArray.Create(typeof(System.Type)));
				    	try
				    	{
				    		this.Visit(node.Qualifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Qualifier, types: ImmutableArray.Create(typeof(System.Type)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Qualifier, name: "DefinedModelObject");
				    }
				}
				if (node.ParserRuleAltRef != null)
				{
					foreach (var child in node.ParserRuleAltRef)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ParserRuleAlt));
			}
		}
		
		public virtual void VisitParserRuleAltRef(ParserRuleAltRefSyntax node)
		{
			this.BeginProperty(node, name: "Alternatives");
			try
			{
				if (node.ParserRuleIdentifier != null)
				{
				    this.BeginUse(node.ParserRuleIdentifier, types: ImmutableArray.Create(typeof(ParserRule)));
				    try
				    {
				    	this.Visit(node.ParserRuleIdentifier);
				    }
				    finally
				    {
				    	this.EndUse(node.ParserRuleIdentifier, types: ImmutableArray.Create(typeof(ParserRule)));
				    }
				}
			}
			finally
			{
				this.EndProperty(node, name: "Alternatives");
			}
		}
		
		public virtual void VisitParserRuleSimple(ParserRuleSimpleSyntax node)
		{
			this.BeginDefine(node, type: typeof(ParserRuleSimple));
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
				        this.Visit(child);
					}
				}
				if (node.ParserRuleName != null)
				{
				    this.Visit(node.ParserRuleName);
				}
				if (node.Qualifier != null)
				{
				    this.BeginProperty(node.Qualifier, name: "DefinedModelObject");
				    try
				    {
				    	this.BeginUse(node.Qualifier, types: ImmutableArray.Create(typeof(System.Type)));
				    	try
				    	{
				    		this.Visit(node.Qualifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Qualifier, types: ImmutableArray.Create(typeof(System.Type)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Qualifier, name: "DefinedModelObject");
				    }
				}
				if (node.ParserRuleNamedElement != null)
				{
					foreach (var child in node.ParserRuleNamedElement)
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
				this.EndDefine(node, type: typeof(ParserRuleSimple));
			}
		}
		
		public virtual void VisitEofElement(EofElementSyntax node)
		{
			this.BeginProperty(node, name: "Elements");
			try
			{
				this.BeginDefine(node, type: typeof(ParserRuleNamedElement));
				try
				{
					this.BeginProperty(node, name: "Element");
					try
					{
						this.BeginDefine(node, type: typeof(ParserRuleEofElement));
						try
						{
						}
						finally
						{
							this.EndDefine(node, type: typeof(ParserRuleEofElement));
						}
					}
					finally
					{
						this.EndProperty(node, name: "Element");
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(ParserRuleNamedElement));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Elements");
			}
		}
		
		public virtual void VisitParserRuleNamedElement(ParserRuleNamedElementSyntax node)
		{
			this.BeginProperty(node, name: "Elements");
			try
			{
				this.BeginDefine(node, type: typeof(ParserRuleNamedElement));
				try
				{
					if (node.Annotation != null)
					{
						foreach (var child in node.Annotation)
						{
					        this.Visit(child);
						}
					}
					if (node.ElementName != null)
					{
					    this.Visit(node.ElementName);
					}
					if (node.Assign != null)
					{
					    this.Visit(node.Assign);
					}
					if (node.ParserNegatedElement != null)
					{
					    this.Visit(node.ParserNegatedElement);
					}
					if (node.Multiplicity != null)
					{
					    this.Visit(node.Multiplicity);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(ParserRuleNamedElement));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Elements");
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
			if (node.TNegate.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
			{
			    this.BeginProperty(node.TNegate, name: "IsNegated", value: true);
			    try
			    {
			    	this.Visit(node.TNegate);
			    }
			    finally
			    {
			    	this.EndProperty(node.TNegate, name: "IsNegated", value: true);
			    }
			}
			if (node.ParserRuleElement != null)
			{
			    this.Visit(node.ParserRuleElement);
			}
		}
		
		public virtual void VisitParserRuleElement(ParserRuleElementSyntax node)
		{
			this.BeginProperty(node, name: "Element");
			try
			{
				if (node.ParserRuleFixedElement != null)
				{
				    this.Visit(node.ParserRuleFixedElement);
				}
				if (node.ParserRuleReference != null)
				{
				    this.Visit(node.ParserRuleReference);
				}
				if (node.ParserRuleWildcardElement != null)
				{
				    this.Visit(node.ParserRuleWildcardElement);
				}
				if (node.ParserRuleBlockElement != null)
				{
				    this.Visit(node.ParserRuleBlockElement);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Element");
			}
		}
		
		public virtual void VisitParserRuleFixedElement(ParserRuleFixedElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(ParserRuleFixedElement));
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
				        this.Visit(child);
					}
				}
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
				this.EndDefine(node, type: typeof(ParserRuleFixedElement));
			}
		}
		
		public virtual void VisitParserRuleWildcardElement(ParserRuleWildcardElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(ParserRuleWildcardElement));
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ParserRuleWildcardElement));
			}
		}
		
		public virtual void VisitParserRuleReference(ParserRuleReferenceSyntax node)
		{
			this.BeginDefine(node, type: typeof(ParserRuleReferenceElement));
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
				        this.Visit(child);
					}
				}
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
				this.EndDefine(node, type: typeof(ParserRuleReferenceElement));
			}
		}
		
		public virtual void VisitParserRuleBlockElement(ParserRuleBlockElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(ParserRuleBlockElement));
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
				        this.Visit(child);
					}
				}
				if (node.ParserRuleNamedElement != null)
				{
					foreach (var child in node.ParserRuleNamedElement)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(ParserRuleBlockElement));
			}
		}
		
		public virtual void VisitLexerRuleDeclaration(LexerRuleDeclarationSyntax node)
		{
			this.BeginDefine(node, type: typeof(LexerRule));
			try
			{
				if (node.Annotation != null)
				{
					foreach (var child in node.Annotation)
					{
				        this.Visit(child);
					}
				}
				if (node.Modifier != null)
				{
				    switch (node.Modifier.GetKind().Switch())
				    {
				    	case CompilerSyntaxKind.KHidden:
				    		this.BeginProperty(node.Modifier, name: "IsHidden", value: true);
				    		try
				    		{
				    			this.Visit(node.Modifier);
				    		}
				    		finally
				    		{
				    			this.EndProperty(node.Modifier, name: "IsHidden", value: true);
				    		}
				    		break;
				    	case CompilerSyntaxKind.KFragment:
				    		this.BeginProperty(node.Modifier, name: "IsFragment", value: true);
				    		try
				    		{
				    			this.Visit(node.Modifier);
				    		}
				    		finally
				    		{
				    			this.EndProperty(node.Modifier, name: "IsFragment", value: true);
				    		}
				    		break;
				    	default:
				    		break;
				    }
				}
				if (node.LexerRuleName != null)
				{
				    this.Visit(node.LexerRuleName);
				}
				if (node.Qualifier != null)
				{
				    this.BeginProperty(node.Qualifier, name: "ValueType");
				    try
				    {
				    	this.BeginUse(node.Qualifier, types: ImmutableArray.Create(typeof(System.Type)));
				    	try
				    	{
				    		this.Visit(node.Qualifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.Qualifier, types: ImmutableArray.Create(typeof(System.Type)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.Qualifier, name: "ValueType");
				    }
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
				this.BeginDefine(node, type: typeof(LexerRuleAlternative));
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
					this.EndDefine(node, type: typeof(LexerRuleAlternative));
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
				this.BeginDefine(node, type: typeof(LexerRuleAlternativeElement));
				try
				{
					if (node.TNegate.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
					{
					    this.BeginProperty(node.TNegate, name: "IsNegated", value: true);
					    try
					    {
					    	this.Visit(node.TNegate);
					    }
					    finally
					    {
					    	this.EndProperty(node.TNegate, name: "IsNegated", value: true);
					    }
					}
					if (node.LexerRuleElement != null)
					{
					    this.Visit(node.LexerRuleElement);
					}
					if (node.Multiplicity != null)
					{
					    this.Visit(node.Multiplicity);
					}
				}
				finally
				{
					this.EndDefine(node, type: typeof(LexerRuleAlternativeElement));
				}
			}
			finally
			{
				this.EndProperty(node, name: "Elements");
			}
		}
		
		public virtual void VisitLexerRuleElement(LexerRuleElementSyntax node)
		{
			this.BeginProperty(node, name: "Element");
			try
			{
				if (node.LexerRuleReferenceElement != null)
				{
				    this.Visit(node.LexerRuleReferenceElement);
				}
				if (node.LexerRuleFixedStringElement != null)
				{
				    this.Visit(node.LexerRuleFixedStringElement);
				}
				if (node.LexerRuleFixedCharElement != null)
				{
				    this.Visit(node.LexerRuleFixedCharElement);
				}
				if (node.LexerRuleWildcardElement != null)
				{
				    this.Visit(node.LexerRuleWildcardElement);
				}
				if (node.LexerRuleBlockElement != null)
				{
				    this.Visit(node.LexerRuleBlockElement);
				}
				if (node.LexerRuleRangeElement != null)
				{
				    this.Visit(node.LexerRuleRangeElement);
				}
			}
			finally
			{
				this.EndProperty(node, name: "Element");
			}
		}
		
		public virtual void VisitLexerRuleReferenceElement(LexerRuleReferenceElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(LexerRuleReferenceElement));
			try
			{
				if (node.LexerRuleIdentifier != null)
				{
				    this.BeginProperty(node.LexerRuleIdentifier, name: "Rule");
				    try
				    {
				    	this.BeginUse(node.LexerRuleIdentifier, types: ImmutableArray.Create(typeof(LexerRule)));
				    	try
				    	{
				    		this.Visit(node.LexerRuleIdentifier);
				    	}
				    	finally
				    	{
				    		this.EndUse(node.LexerRuleIdentifier, types: ImmutableArray.Create(typeof(LexerRule)));
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.LexerRuleIdentifier, name: "Rule");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(LexerRuleReferenceElement));
			}
		}
		
		public virtual void VisitLexerRuleWildcardElement(LexerRuleWildcardElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(LexerRuleWildcardElement));
			try
			{
			}
			finally
			{
				this.EndDefine(node, type: typeof(LexerRuleWildcardElement));
			}
		}
		
		public virtual void VisitLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(LexerRuleFixedStringElement));
			try
			{
				if (node.LString.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.LString, name: "Value");
				    try
				    {
				    	this.BeginValue(node.LString);
				    	try
				    	{
				    		this.Visit(node.LString);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.LString);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.LString, name: "Value");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(LexerRuleFixedStringElement));
			}
		}
		
		public virtual void VisitLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(LexerRuleFixedCharElement));
			try
			{
				if (node.LCharacter.GetKind() != MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None)
				{
				    this.BeginProperty(node.LCharacter, name: "Value");
				    try
				    {
				    	this.BeginValue(node.LCharacter);
				    	try
				    	{
				    		this.Visit(node.LCharacter);
				    	}
				    	finally
				    	{
				    		this.EndValue(node.LCharacter);
				    	}
				    }
				    finally
				    {
				    	this.EndProperty(node.LCharacter, name: "Value");
				    }
				}
			}
			finally
			{
				this.EndDefine(node, type: typeof(LexerRuleFixedCharElement));
			}
		}
		
		public virtual void VisitLexerRuleBlockElement(LexerRuleBlockElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(LexerRuleBlockElement));
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
				this.EndDefine(node, type: typeof(LexerRuleBlockElement));
			}
		}
		
		public virtual void VisitLexerRuleRangeElement(LexerRuleRangeElementSyntax node)
		{
			this.BeginDefine(node, type: typeof(LexerRuleRangeElement));
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
				this.EndDefine(node, type: typeof(LexerRuleRangeElement));
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
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.BeginName(node);
			try
			{
				if (node.Qualifier != null)
				{
				    this.Visit(node.Qualifier);
				}
			}
			finally
			{
				this.EndName(node);
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
				this.EndQualifier(node);
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
		
		public virtual void VisitLexerRuleIdentifier(LexerRuleIdentifierSyntax node)
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
		
		public virtual void VisitParserRuleIdentifier(ParserRuleIdentifierSyntax node)
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
		
		public virtual void VisitCharLiteral(CharLiteralSyntax node)
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

