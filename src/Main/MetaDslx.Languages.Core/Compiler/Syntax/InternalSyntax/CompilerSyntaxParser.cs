// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
namespace MetaDslx.Languages.Compiler.Syntax.InternalSyntax
{
    public class CompilerSyntaxParser : Antlr4SyntaxParser
    {
        private readonly Antlr4ToRoslynVisitor _visitor;
        public CompilerSyntaxParser(
            SourceText text,
            CompilerParseOptions options,
            CompilerSyntaxNode oldTree, 
			ParseData oldParseData,
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
            : base(CompilerLanguage.Instance, text, options, oldTree, oldParseData, changes, cancellationToken)
        {
            _visitor = new Antlr4ToRoslynVisitor(this);
        }
        protected new CompilerParser Antlr4Parser => (CompilerParser)base.Antlr4Parser;
		public override LanguageSyntaxNode Parse()
		{
			BeginRoot();
            ParserState state = null;
			var green = this.ParseMain(ref state);
			EndRoot(ref green);
			var red = (CompilerSyntaxNode)green.CreateRed();
			return red;
		}
		public GreenNode ParseMain(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
		        var context = this.IsIncremental ? this.Antlr4Parser.main() : _Antlr4ParseMain();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMain(MainSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.MainContext _Antlr4ParseMain()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.MainContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMain(CurrentNode as MainSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMain();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.MainContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseGrammarDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.grammarDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGrammarDeclaration(GrammarDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.GrammarDeclarationContext _Antlr4ParseGrammarDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.GrammarDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseGrammarDeclaration(CurrentNode as GrammarDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseGrammarDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.GrammarDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseRuleDeclarations(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.ruleDeclarations();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRuleDeclarations(RuleDeclarationsSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.RuleDeclarationsContext _Antlr4ParseRuleDeclarations()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.RuleDeclarationsContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseRuleDeclarations(CurrentNode as RuleDeclarationsSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseRuleDeclarations();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.RuleDeclarationsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseRuleDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.ruleDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRuleDeclaration(RuleDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.RuleDeclarationContext _Antlr4ParseRuleDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.RuleDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseRuleDeclaration(CurrentNode as RuleDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseRuleDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.RuleDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleDeclaration(ParserRuleDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleDeclarationContext _Antlr4ParseParserRuleDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleDeclaration(CurrentNode as ParserRuleDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleAlternative(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleAlternative();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleAlternative(ParserRuleAlternativeSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleAlternativeContext _Antlr4ParseParserRuleAlternative()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleAlternativeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleAlternative(CurrentNode as ParserRuleAlternativeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleAlternative();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleAlternativeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseEofElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.eofElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEofElement(EofElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.EofElementContext _Antlr4ParseEofElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.EofElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseEofElement(CurrentNode as EofElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseEofElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.EofElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleAlternativeElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleAlternativeElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleAlternativeElement(ParserRuleAlternativeElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleAlternativeElementContext _Antlr4ParseParserRuleAlternativeElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleAlternativeElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleAlternativeElement(CurrentNode as ParserRuleAlternativeElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleAlternativeElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleAlternativeElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserMultiElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserMultiElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserMultiElement(ParserMultiElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserMultiElementContext _Antlr4ParseParserMultiElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserMultiElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserMultiElement(CurrentNode as ParserMultiElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserMultiElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserMultiElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseAssign(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.assign();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAssign(AssignSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.AssignContext _Antlr4ParseAssign()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.AssignContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseAssign(CurrentNode as AssignSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseAssign();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.AssignContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseMultiplicity(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.multiplicity();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMultiplicity(MultiplicitySyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.MultiplicityContext _Antlr4ParseMultiplicity()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.MultiplicityContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMultiplicity(CurrentNode as MultiplicitySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMultiplicity();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.MultiplicityContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserNegatedElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserNegatedElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserNegatedElement(ParserNegatedElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserNegatedElementContext _Antlr4ParseParserNegatedElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserNegatedElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserNegatedElement(CurrentNode as ParserNegatedElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserNegatedElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserNegatedElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleElement(ParserRuleElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleElementContext _Antlr4ParseParserRuleElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleElement(CurrentNode as ParserRuleElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseFixedElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.fixedElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFixedElement(FixedElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.FixedElementContext _Antlr4ParseFixedElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.FixedElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseFixedElement(CurrentNode as FixedElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseFixedElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.FixedElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleReference(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleReference();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleReference(ParserRuleReferenceSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleReferenceContext _Antlr4ParseParserRuleReference()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleReference(CurrentNode as ParserRuleReferenceSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleReference();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleBlock(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleBlock();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleBlock(ParserRuleBlockSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleBlockContext _Antlr4ParseParserRuleBlock()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleBlockContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleBlock(CurrentNode as ParserRuleBlockSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleBlock();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleBlockContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleDeclaration(LexerRuleDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleDeclarationContext _Antlr4ParseLexerRuleDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleDeclaration(CurrentNode as LexerRuleDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleAlternative(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleAlternative();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleAlternative(LexerRuleAlternativeSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleAlternativeContext _Antlr4ParseLexerRuleAlternative()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleAlternativeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleAlternative(CurrentNode as LexerRuleAlternativeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleAlternative();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleAlternativeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleAlternativeElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleAlternativeElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleAlternativeElement(LexerRuleAlternativeElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleAlternativeElementContext _Antlr4ParseLexerRuleAlternativeElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleAlternativeElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleAlternativeElement(CurrentNode as LexerRuleAlternativeElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleAlternativeElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleAlternativeElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerMultiElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerMultiElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerMultiElement(LexerMultiElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerMultiElementContext _Antlr4ParseLexerMultiElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerMultiElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerMultiElement(CurrentNode as LexerMultiElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerMultiElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerMultiElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerNegatedElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerNegatedElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerNegatedElement(LexerNegatedElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerNegatedElementContext _Antlr4ParseLexerNegatedElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerNegatedElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerNegatedElement(CurrentNode as LexerNegatedElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerNegatedElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerNegatedElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRangeElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRangeElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRangeElement(LexerRangeElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRangeElementContext _Antlr4ParseLexerRangeElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRangeElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRangeElement(CurrentNode as LexerRangeElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRangeElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRangeElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleElement(LexerRuleElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleElementContext _Antlr4ParseLexerRuleElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleElement(CurrentNode as LexerRuleElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseWildcardElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.wildcardElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseWildcardElement(WildcardElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.WildcardElementContext _Antlr4ParseWildcardElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.WildcardElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseWildcardElement(CurrentNode as WildcardElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseWildcardElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.WildcardElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleReference(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleReference();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleReference(LexerRuleReferenceSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleReferenceContext _Antlr4ParseLexerRuleReference()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleReference(CurrentNode as LexerRuleReferenceSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleReference();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleBlock(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleBlock();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleBlock(LexerRuleBlockSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleBlockContext _Antlr4ParseLexerRuleBlock()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleBlockContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleBlock(CurrentNode as LexerRuleBlockSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleBlock();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleBlockContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseName(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.name();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseName(NameSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.NameContext _Antlr4ParseName()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.NameContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseName(CurrentNode as NameSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseName();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.NameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseIdentifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.identifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIdentifier(IdentifierSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.IdentifierContext _Antlr4ParseIdentifier()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.IdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseIdentifier(CurrentNode as IdentifierSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseIdentifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.IdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleName(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleName();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleName(LexerRuleNameSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleNameContext _Antlr4ParseLexerRuleName()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleNameContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleName(CurrentNode as LexerRuleNameSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleName();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleName(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleName();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleName(ParserRuleNameSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleNameContext _Antlr4ParseParserRuleName()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleNameContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleName(CurrentNode as ParserRuleNameSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleName();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseElementName(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.elementName();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseElementName(ElementNameSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ElementNameContext _Antlr4ParseElementName()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ElementNameContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseElementName(CurrentNode as ElementNameSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseElementName();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ElementNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.literal();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLiteral(LiteralSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LiteralContext _Antlr4ParseLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLiteral(CurrentNode as LiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseNullLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.nullLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNullLiteral(NullLiteralSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.NullLiteralContext _Antlr4ParseNullLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.NullLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseNullLiteral(CurrentNode as NullLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseNullLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.NullLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseBooleanLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.booleanLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseBooleanLiteral(BooleanLiteralSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.BooleanLiteralContext _Antlr4ParseBooleanLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.BooleanLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseBooleanLiteral(CurrentNode as BooleanLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseBooleanLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.BooleanLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseIntegerLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.integerLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIntegerLiteral(IntegerLiteralSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.IntegerLiteralContext _Antlr4ParseIntegerLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.IntegerLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseIntegerLiteral(CurrentNode as IntegerLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseIntegerLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.IntegerLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseDecimalLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.decimalLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDecimalLiteral(DecimalLiteralSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.DecimalLiteralContext _Antlr4ParseDecimalLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.DecimalLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseDecimalLiteral(CurrentNode as DecimalLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseDecimalLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.DecimalLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseScientificLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.scientificLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseScientificLiteral(ScientificLiteralSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ScientificLiteralContext _Antlr4ParseScientificLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ScientificLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseScientificLiteral(CurrentNode as ScientificLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseScientificLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ScientificLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseStringLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.stringLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseStringLiteral(StringLiteralSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.StringLiteralContext _Antlr4ParseStringLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.StringLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseStringLiteral(CurrentNode as StringLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseStringLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.StringLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
        private class Antlr4ToRoslynVisitor : CompilerParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.
			private readonly CompilerInternalSyntaxFactory _factory;
            private readonly CompilerSyntaxParser _syntaxParser;
            public Antlr4ToRoslynVisitor(CompilerSyntaxParser syntaxParser)
            {
				_factory = (CompilerInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                _syntaxParser = syntaxParser;
            }
            private GreenNode VisitTerminal(IToken token, CompilerSyntaxKind kind)
            {
				if (kind == SyntaxKind.Eof)
				{
					return _syntaxParser.EatToken();
				}
				if (token == null)
				{
					if (kind != null)
					{
						return _factory.MissingToken(kind);
					}
					else
					{
						return null;
					}
				}
                var green = ((IncrementalToken)token).GreenToken;
				Debug.Assert(kind == null || green.Kind == kind);
				return green;
            }
            public GreenNode VisitTerminal(IToken token)
            {
				return VisitTerminal(token, null);
            }
            private GreenNode VisitTerminal(ITerminalNode node, CompilerSyntaxKind kind)
            {
				if (kind == SyntaxKind.Eof)
				{
					return _syntaxParser.EatToken();
				}
                if (node == null || node.Symbol == null)
				{
					if (kind != null)
					{
						return _factory.MissingToken(kind);
					}
					else
					{
						return null;
					}
				}
				var green = ((IncrementalToken)node.Symbol).GreenToken;
				Debug.Assert(kind == null || green.Kind == kind);
				return green;
			}
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                return VisitTerminal(node, null);
            }
			public override GreenNode Visit(IParseTree tree)
			{
                if (tree is ICachedRuleContext cached)
                {
                    return cached.CachedNode;
                }
				else if (tree is ParserRuleContext context)
                {
                    if (_syntaxParser.TryGetGreenNode(context, out var existingGreenNode)) return existingGreenNode;
    				return base.Visit(tree);
                }
                else
                {
                    return base.Visit(tree);
                }
			}
			
			public override GreenNode VisitMain(CompilerParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
				CompilerParser.GrammarDeclarationContext grammarDeclarationContext = context.grammarDeclaration();
				GrammarDeclarationGreen grammarDeclaration = null;
				if (grammarDeclarationContext != null) grammarDeclaration = (GrammarDeclarationGreen)this.Visit(grammarDeclarationContext);
				if (grammarDeclaration == null) grammarDeclaration = GrammarDeclarationGreen.__Missing;
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), CompilerSyntaxKind.Eof);
				return _factory.Main(grammarDeclaration, eOF);
			}
			
			public override GreenNode VisitGrammarDeclaration(CompilerParser.GrammarDeclarationContext context)
			{
				if (context == null) return GrammarDeclarationGreen.__Missing;
				InternalSyntaxToken kGrammar = (InternalSyntaxToken)this.VisitTerminal(context.KGrammar(), CompilerSyntaxKind.KGrammar);
				CompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), CompilerSyntaxKind.TSemicolon);
				CompilerParser.RuleDeclarationsContext ruleDeclarationsContext = context.ruleDeclarations();
				RuleDeclarationsGreen ruleDeclarations = null;
				if (ruleDeclarationsContext != null) ruleDeclarations = (RuleDeclarationsGreen)this.Visit(ruleDeclarationsContext);
				if (ruleDeclarations == null) ruleDeclarations = RuleDeclarationsGreen.__Missing;
				return _factory.GrammarDeclaration(kGrammar, name, tSemicolon, ruleDeclarations);
			}
			
			public override GreenNode VisitRuleDeclarations(CompilerParser.RuleDeclarationsContext context)
			{
				if (context == null) return RuleDeclarationsGreen.__Missing;
			    CompilerParser.RuleDeclarationContext[] ruleDeclarationContext = context.ruleDeclaration();
			    var ruleDeclarationBuilder = _pool.Allocate<RuleDeclarationGreen>();
			    for (int i = 0; i < ruleDeclarationContext.Length; i++)
			    {
			        ruleDeclarationBuilder.Add((RuleDeclarationGreen)this.Visit(ruleDeclarationContext[i]));
			    }
				var ruleDeclaration = ruleDeclarationBuilder.ToList();
				_pool.Free(ruleDeclarationBuilder);
				return _factory.RuleDeclarations(ruleDeclaration);
			}
			
			public override GreenNode VisitRuleDeclaration(CompilerParser.RuleDeclarationContext context)
			{
				if (context == null) return RuleDeclarationGreen.__Missing;
				CompilerParser.ParserRuleDeclarationContext parserRuleDeclarationContext = context.parserRuleDeclaration();
				if (parserRuleDeclarationContext != null) 
				{
					return _factory.RuleDeclaration((ParserRuleDeclarationGreen)this.Visit(parserRuleDeclarationContext));
				}
				CompilerParser.LexerRuleDeclarationContext lexerRuleDeclarationContext = context.lexerRuleDeclaration();
				if (lexerRuleDeclarationContext != null) 
				{
					return _factory.RuleDeclaration((LexerRuleDeclarationGreen)this.Visit(lexerRuleDeclarationContext));
				}
				return RuleDeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitParserRuleDeclaration(CompilerParser.ParserRuleDeclarationContext context)
			{
				if (context == null) return ParserRuleDeclarationGreen.__Missing;
				CompilerParser.ParserRuleNameContext parserRuleNameContext = context.parserRuleName();
				ParserRuleNameGreen parserRuleName = null;
				if (parserRuleNameContext != null) parserRuleName = (ParserRuleNameGreen)this.Visit(parserRuleNameContext);
				if (parserRuleName == null) parserRuleName = ParserRuleNameGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), CompilerSyntaxKind.TColon);
			    CompilerParser.ParserRuleAlternativeContext[] parserRuleAlternativeContext = context.parserRuleAlternative();
			    ITerminalNode[] tBarContext = context.TBar();
			    var parserRuleAlternativeBuilder = _pool.AllocateSeparated<ParserRuleAlternativeGreen>();
			    for (int i = 0; i < parserRuleAlternativeContext.Length; i++)
			    {
			        parserRuleAlternativeBuilder.Add((ParserRuleAlternativeGreen)this.Visit(parserRuleAlternativeContext[i]));
			        if (i < tBarContext.Length)
			        {
			            parserRuleAlternativeBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tBarContext[i], CompilerSyntaxKind.TBar));
			        }
			    }
				var parserRuleAlternative = parserRuleAlternativeBuilder.ToList();
				_pool.Free(parserRuleAlternativeBuilder);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), CompilerSyntaxKind.TSemicolon);
				return _factory.ParserRuleDeclaration(parserRuleName, tColon, parserRuleAlternative, tSemicolon);
			}
			
			public override GreenNode VisitParserRuleAlternative(CompilerParser.ParserRuleAlternativeContext context)
			{
				if (context == null) return ParserRuleAlternativeGreen.__Missing;
			    CompilerParser.ParserRuleAlternativeElementContext[] parserRuleAlternativeElementContext = context.parserRuleAlternativeElement();
			    var parserRuleAlternativeElementBuilder = _pool.Allocate<ParserRuleAlternativeElementGreen>();
			    for (int i = 0; i < parserRuleAlternativeElementContext.Length; i++)
			    {
			        parserRuleAlternativeElementBuilder.Add((ParserRuleAlternativeElementGreen)this.Visit(parserRuleAlternativeElementContext[i]));
			    }
				var parserRuleAlternativeElement = parserRuleAlternativeElementBuilder.ToList();
				_pool.Free(parserRuleAlternativeElementBuilder);
				CompilerParser.EofElementContext eofElementContext = context.eofElement();
				EofElementGreen eofElement = null;
				if (eofElementContext != null) eofElement = (EofElementGreen)this.Visit(eofElementContext);
				return _factory.ParserRuleAlternative(parserRuleAlternativeElement, eofElement);
			}
			
			public override GreenNode VisitEofElement(CompilerParser.EofElementContext context)
			{
				if (context == null) return EofElementGreen.__Missing;
				InternalSyntaxToken kEof = (InternalSyntaxToken)this.VisitTerminal(context.KEof(), CompilerSyntaxKind.KEof);
				return _factory.EofElement(kEof);
			}
			
			public override GreenNode VisitParserRuleAlternativeElement(CompilerParser.ParserRuleAlternativeElementContext context)
			{
				if (context == null) return ParserRuleAlternativeElementGreen.__Missing;
				CompilerParser.ParserMultiElementContext parserMultiElementContext = context.parserMultiElement();
				if (parserMultiElementContext != null) 
				{
					return _factory.ParserRuleAlternativeElement((ParserMultiElementGreen)this.Visit(parserMultiElementContext));
				}
				CompilerParser.ParserNegatedElementContext parserNegatedElementContext = context.parserNegatedElement();
				if (parserNegatedElementContext != null) 
				{
					return _factory.ParserRuleAlternativeElement((ParserNegatedElementGreen)this.Visit(parserNegatedElementContext));
				}
				return ParserRuleAlternativeElementGreen.__Missing;
			}
			
			public override GreenNode VisitParserMultiElement(CompilerParser.ParserMultiElementContext context)
			{
				if (context == null) return ParserMultiElementGreen.__Missing;
				CompilerParser.ElementNameContext elementNameContext = context.elementName();
				ElementNameGreen elementName = null;
				if (elementNameContext != null) elementName = (ElementNameGreen)this.Visit(elementNameContext);
				CompilerParser.AssignContext assignContext = context.assign();
				AssignGreen assign = null;
				if (assignContext != null) assign = (AssignGreen)this.Visit(assignContext);
				CompilerParser.ParserRuleElementContext parserRuleElementContext = context.parserRuleElement();
				ParserRuleElementGreen parserRuleElement = null;
				if (parserRuleElementContext != null) parserRuleElement = (ParserRuleElementGreen)this.Visit(parserRuleElementContext);
				if (parserRuleElement == null) parserRuleElement = ParserRuleElementGreen.__Missing;
				CompilerParser.MultiplicityContext multiplicityContext = context.multiplicity();
				MultiplicityGreen multiplicity = null;
				if (multiplicityContext != null) multiplicity = (MultiplicityGreen)this.Visit(multiplicityContext);
				return _factory.ParserMultiElement(elementName, assign, parserRuleElement, multiplicity);
			}
			
			public override GreenNode VisitAssign(CompilerParser.AssignContext context)
			{
				if (context == null) return AssignGreen.__Missing;
				InternalSyntaxToken assign = null;
				if (context.TAssign() != null)
				{
					assign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				}
				else 	if (context.TQuestionAssign() != null)
				{
					assign = (InternalSyntaxToken)this.VisitTerminal(context.TQuestionAssign());
				}
				else 	if (context.TNegatedAssign() != null)
				{
					assign = (InternalSyntaxToken)this.VisitTerminal(context.TNegatedAssign());
				}
				else 	if (context.TPlusAssign() != null)
				{
					assign = (InternalSyntaxToken)this.VisitTerminal(context.TPlusAssign());
				}
				else
				{
					assign = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.Assign(assign);
			}
			
			public override GreenNode VisitMultiplicity(CompilerParser.MultiplicityContext context)
			{
				if (context == null) return MultiplicityGreen.__Missing;
				InternalSyntaxToken multiplicity = null;
				if (context.TNonGreedyZeroOrOne() != null)
				{
					multiplicity = (InternalSyntaxToken)this.VisitTerminal(context.TNonGreedyZeroOrOne());
				}
				else 	if (context.TNonGreedyZeroOrMore() != null)
				{
					multiplicity = (InternalSyntaxToken)this.VisitTerminal(context.TNonGreedyZeroOrMore());
				}
				else 	if (context.TNonGreedyOneOrMore() != null)
				{
					multiplicity = (InternalSyntaxToken)this.VisitTerminal(context.TNonGreedyOneOrMore());
				}
				else 	if (context.TZeroOrOne() != null)
				{
					multiplicity = (InternalSyntaxToken)this.VisitTerminal(context.TZeroOrOne());
				}
				else 	if (context.TZeroOrMore() != null)
				{
					multiplicity = (InternalSyntaxToken)this.VisitTerminal(context.TZeroOrMore());
				}
				else 	if (context.TOneOrMore() != null)
				{
					multiplicity = (InternalSyntaxToken)this.VisitTerminal(context.TOneOrMore());
				}
				else
				{
					multiplicity = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.Multiplicity(multiplicity);
			}
			
			public override GreenNode VisitParserNegatedElement(CompilerParser.ParserNegatedElementContext context)
			{
				if (context == null) return ParserNegatedElementGreen.__Missing;
				InternalSyntaxToken tNegate = (InternalSyntaxToken)this.VisitTerminal(context.TNegate(), CompilerSyntaxKind.TNegate);
				CompilerParser.ParserRuleElementContext parserRuleElementContext = context.parserRuleElement();
				ParserRuleElementGreen parserRuleElement = null;
				if (parserRuleElementContext != null) parserRuleElement = (ParserRuleElementGreen)this.Visit(parserRuleElementContext);
				if (parserRuleElement == null) parserRuleElement = ParserRuleElementGreen.__Missing;
				return _factory.ParserNegatedElement(tNegate, parserRuleElement);
			}
			
			public override GreenNode VisitParserRuleElement(CompilerParser.ParserRuleElementContext context)
			{
				if (context == null) return ParserRuleElementGreen.__Missing;
				CompilerParser.FixedElementContext fixedElementContext = context.fixedElement();
				if (fixedElementContext != null) 
				{
					return _factory.ParserRuleElement((FixedElementGreen)this.Visit(fixedElementContext));
				}
				CompilerParser.ParserRuleReferenceContext parserRuleReferenceContext = context.parserRuleReference();
				if (parserRuleReferenceContext != null) 
				{
					return _factory.ParserRuleElement((ParserRuleReferenceGreen)this.Visit(parserRuleReferenceContext));
				}
				CompilerParser.ParserRuleBlockContext parserRuleBlockContext = context.parserRuleBlock();
				if (parserRuleBlockContext != null) 
				{
					return _factory.ParserRuleElement((ParserRuleBlockGreen)this.Visit(parserRuleBlockContext));
				}
				return ParserRuleElementGreen.__Missing;
			}
			
			public override GreenNode VisitFixedElement(CompilerParser.FixedElementContext context)
			{
				if (context == null) return FixedElementGreen.__Missing;
				CompilerParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.FixedElement(stringLiteral);
			}
			
			public override GreenNode VisitParserRuleReference(CompilerParser.ParserRuleReferenceContext context)
			{
				if (context == null) return ParserRuleReferenceGreen.__Missing;
				CompilerParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.ParserRuleReference(identifier);
			}
			
			public override GreenNode VisitParserRuleBlock(CompilerParser.ParserRuleBlockContext context)
			{
				if (context == null) return ParserRuleBlockGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CompilerSyntaxKind.TOpenParen);
			    CompilerParser.ParserRuleAlternativeContext[] parserRuleAlternativeContext = context.parserRuleAlternative();
			    ITerminalNode[] tBarContext = context.TBar();
			    var parserRuleAlternativeBuilder = _pool.AllocateSeparated<ParserRuleAlternativeGreen>();
			    for (int i = 0; i < parserRuleAlternativeContext.Length; i++)
			    {
			        parserRuleAlternativeBuilder.Add((ParserRuleAlternativeGreen)this.Visit(parserRuleAlternativeContext[i]));
			        if (i < tBarContext.Length)
			        {
			            parserRuleAlternativeBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tBarContext[i], CompilerSyntaxKind.TBar));
			        }
			    }
				var parserRuleAlternative = parserRuleAlternativeBuilder.ToList();
				_pool.Free(parserRuleAlternativeBuilder);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CompilerSyntaxKind.TCloseParen);
				return _factory.ParserRuleBlock(tOpenParen, parserRuleAlternative, tCloseParen);
			}
			
			public override GreenNode VisitLexerRuleDeclaration(CompilerParser.LexerRuleDeclarationContext context)
			{
				if (context == null) return LexerRuleDeclarationGreen.__Missing;
				CompilerParser.LexerRuleNameContext lexerRuleNameContext = context.lexerRuleName();
				LexerRuleNameGreen lexerRuleName = null;
				if (lexerRuleNameContext != null) lexerRuleName = (LexerRuleNameGreen)this.Visit(lexerRuleNameContext);
				if (lexerRuleName == null) lexerRuleName = LexerRuleNameGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), CompilerSyntaxKind.TColon);
			    CompilerParser.LexerRuleAlternativeContext[] lexerRuleAlternativeContext = context.lexerRuleAlternative();
			    ITerminalNode[] tBarContext = context.TBar();
			    var lexerRuleAlternativeBuilder = _pool.AllocateSeparated<LexerRuleAlternativeGreen>();
			    for (int i = 0; i < lexerRuleAlternativeContext.Length; i++)
			    {
			        lexerRuleAlternativeBuilder.Add((LexerRuleAlternativeGreen)this.Visit(lexerRuleAlternativeContext[i]));
			        if (i < tBarContext.Length)
			        {
			            lexerRuleAlternativeBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tBarContext[i], CompilerSyntaxKind.TBar));
			        }
			    }
				var lexerRuleAlternative = lexerRuleAlternativeBuilder.ToList();
				_pool.Free(lexerRuleAlternativeBuilder);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), CompilerSyntaxKind.TSemicolon);
				return _factory.LexerRuleDeclaration(lexerRuleName, tColon, lexerRuleAlternative, tSemicolon);
			}
			
			public override GreenNode VisitLexerRuleAlternative(CompilerParser.LexerRuleAlternativeContext context)
			{
				if (context == null) return LexerRuleAlternativeGreen.__Missing;
			    CompilerParser.LexerRuleAlternativeElementContext[] lexerRuleAlternativeElementContext = context.lexerRuleAlternativeElement();
			    var lexerRuleAlternativeElementBuilder = _pool.Allocate<LexerRuleAlternativeElementGreen>();
			    for (int i = 0; i < lexerRuleAlternativeElementContext.Length; i++)
			    {
			        lexerRuleAlternativeElementBuilder.Add((LexerRuleAlternativeElementGreen)this.Visit(lexerRuleAlternativeElementContext[i]));
			    }
				var lexerRuleAlternativeElement = lexerRuleAlternativeElementBuilder.ToList();
				_pool.Free(lexerRuleAlternativeElementBuilder);
				return _factory.LexerRuleAlternative(lexerRuleAlternativeElement);
			}
			
			public override GreenNode VisitLexerRuleAlternativeElement(CompilerParser.LexerRuleAlternativeElementContext context)
			{
				if (context == null) return LexerRuleAlternativeElementGreen.__Missing;
				CompilerParser.LexerMultiElementContext lexerMultiElementContext = context.lexerMultiElement();
				if (lexerMultiElementContext != null) 
				{
					return _factory.LexerRuleAlternativeElement((LexerMultiElementGreen)this.Visit(lexerMultiElementContext));
				}
				CompilerParser.LexerNegatedElementContext lexerNegatedElementContext = context.lexerNegatedElement();
				if (lexerNegatedElementContext != null) 
				{
					return _factory.LexerRuleAlternativeElement((LexerNegatedElementGreen)this.Visit(lexerNegatedElementContext));
				}
				CompilerParser.LexerRangeElementContext lexerRangeElementContext = context.lexerRangeElement();
				if (lexerRangeElementContext != null) 
				{
					return _factory.LexerRuleAlternativeElement((LexerRangeElementGreen)this.Visit(lexerRangeElementContext));
				}
				return LexerRuleAlternativeElementGreen.__Missing;
			}
			
			public override GreenNode VisitLexerMultiElement(CompilerParser.LexerMultiElementContext context)
			{
				if (context == null) return LexerMultiElementGreen.__Missing;
				CompilerParser.LexerRuleElementContext lexerRuleElementContext = context.lexerRuleElement();
				LexerRuleElementGreen lexerRuleElement = null;
				if (lexerRuleElementContext != null) lexerRuleElement = (LexerRuleElementGreen)this.Visit(lexerRuleElementContext);
				if (lexerRuleElement == null) lexerRuleElement = LexerRuleElementGreen.__Missing;
				CompilerParser.MultiplicityContext multiplicityContext = context.multiplicity();
				MultiplicityGreen multiplicity = null;
				if (multiplicityContext != null) multiplicity = (MultiplicityGreen)this.Visit(multiplicityContext);
				return _factory.LexerMultiElement(lexerRuleElement, multiplicity);
			}
			
			public override GreenNode VisitLexerNegatedElement(CompilerParser.LexerNegatedElementContext context)
			{
				if (context == null) return LexerNegatedElementGreen.__Missing;
				InternalSyntaxToken tNegate = (InternalSyntaxToken)this.VisitTerminal(context.TNegate(), CompilerSyntaxKind.TNegate);
				CompilerParser.LexerRuleElementContext lexerRuleElementContext = context.lexerRuleElement();
				LexerRuleElementGreen lexerRuleElement = null;
				if (lexerRuleElementContext != null) lexerRuleElement = (LexerRuleElementGreen)this.Visit(lexerRuleElementContext);
				if (lexerRuleElement == null) lexerRuleElement = LexerRuleElementGreen.__Missing;
				return _factory.LexerNegatedElement(tNegate, lexerRuleElement);
			}
			
			public override GreenNode VisitLexerRangeElement(CompilerParser.LexerRangeElementContext context)
			{
				if (context == null) return LexerRangeElementGreen.__Missing;
				CompilerParser.FixedElementContext startContext = context.start;
				FixedElementGreen start = null;
				if (startContext != null) start = (FixedElementGreen)this.Visit(startContext);
				if (start == null) start = FixedElementGreen.__Missing;
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), CompilerSyntaxKind.TArrow);
				CompilerParser.FixedElementContext endContext = context.end;
				FixedElementGreen end = null;
				if (endContext != null) end = (FixedElementGreen)this.Visit(endContext);
				if (end == null) end = FixedElementGreen.__Missing;
				return _factory.LexerRangeElement(start, tArrow, end);
			}
			
			public override GreenNode VisitLexerRuleElement(CompilerParser.LexerRuleElementContext context)
			{
				if (context == null) return LexerRuleElementGreen.__Missing;
				CompilerParser.FixedElementContext fixedElementContext = context.fixedElement();
				if (fixedElementContext != null) 
				{
					return _factory.LexerRuleElement((FixedElementGreen)this.Visit(fixedElementContext));
				}
				CompilerParser.WildcardElementContext wildcardElementContext = context.wildcardElement();
				if (wildcardElementContext != null) 
				{
					return _factory.LexerRuleElement((WildcardElementGreen)this.Visit(wildcardElementContext));
				}
				CompilerParser.LexerRuleReferenceContext lexerRuleReferenceContext = context.lexerRuleReference();
				if (lexerRuleReferenceContext != null) 
				{
					return _factory.LexerRuleElement((LexerRuleReferenceGreen)this.Visit(lexerRuleReferenceContext));
				}
				CompilerParser.LexerRuleBlockContext lexerRuleBlockContext = context.lexerRuleBlock();
				if (lexerRuleBlockContext != null) 
				{
					return _factory.LexerRuleElement((LexerRuleBlockGreen)this.Visit(lexerRuleBlockContext));
				}
				return LexerRuleElementGreen.__Missing;
			}
			
			public override GreenNode VisitWildcardElement(CompilerParser.WildcardElementContext context)
			{
				if (context == null) return WildcardElementGreen.__Missing;
				InternalSyntaxToken tDot = (InternalSyntaxToken)this.VisitTerminal(context.TDot(), CompilerSyntaxKind.TDot);
				return _factory.WildcardElement(tDot);
			}
			
			public override GreenNode VisitLexerRuleReference(CompilerParser.LexerRuleReferenceContext context)
			{
				if (context == null) return LexerRuleReferenceGreen.__Missing;
				CompilerParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.LexerRuleReference(identifier);
			}
			
			public override GreenNode VisitLexerRuleBlock(CompilerParser.LexerRuleBlockContext context)
			{
				if (context == null) return LexerRuleBlockGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CompilerSyntaxKind.TOpenParen);
			    CompilerParser.LexerRuleAlternativeContext[] lexerRuleAlternativeContext = context.lexerRuleAlternative();
			    ITerminalNode[] tBarContext = context.TBar();
			    var lexerRuleAlternativeBuilder = _pool.AllocateSeparated<LexerRuleAlternativeGreen>();
			    for (int i = 0; i < lexerRuleAlternativeContext.Length; i++)
			    {
			        lexerRuleAlternativeBuilder.Add((LexerRuleAlternativeGreen)this.Visit(lexerRuleAlternativeContext[i]));
			        if (i < tBarContext.Length)
			        {
			            lexerRuleAlternativeBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tBarContext[i], CompilerSyntaxKind.TBar));
			        }
			    }
				var lexerRuleAlternative = lexerRuleAlternativeBuilder.ToList();
				_pool.Free(lexerRuleAlternativeBuilder);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CompilerSyntaxKind.TCloseParen);
				return _factory.LexerRuleBlock(tOpenParen, lexerRuleAlternative, tCloseParen);
			}
			
			public override GreenNode VisitName(CompilerParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				CompilerParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.Name(identifier);
			}
			
			public override GreenNode VisitIdentifier(CompilerParser.IdentifierContext context)
			{
				if (context == null) return IdentifierGreen.__Missing;
				InternalSyntaxToken identifier = null;
				if (context.LexerIdentifier() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.LexerIdentifier());
				}
				else 	if (context.ParserIdentifier() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.ParserIdentifier());
				}
				else
				{
					identifier = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.Identifier(identifier);
			}
			
			public override GreenNode VisitLexerRuleName(CompilerParser.LexerRuleNameContext context)
			{
				if (context == null) return LexerRuleNameGreen.__Missing;
				InternalSyntaxToken lexerIdentifier = (InternalSyntaxToken)this.VisitTerminal(context.LexerIdentifier(), CompilerSyntaxKind.LexerIdentifier);
				return _factory.LexerRuleName(lexerIdentifier);
			}
			
			public override GreenNode VisitParserRuleName(CompilerParser.ParserRuleNameContext context)
			{
				if (context == null) return ParserRuleNameGreen.__Missing;
				InternalSyntaxToken parserIdentifier = (InternalSyntaxToken)this.VisitTerminal(context.ParserIdentifier(), CompilerSyntaxKind.ParserIdentifier);
				return _factory.ParserRuleName(parserIdentifier);
			}
			
			public override GreenNode VisitElementName(CompilerParser.ElementNameContext context)
			{
				if (context == null) return ElementNameGreen.__Missing;
				InternalSyntaxToken lexerIdentifier = (InternalSyntaxToken)this.VisitTerminal(context.LexerIdentifier(), CompilerSyntaxKind.LexerIdentifier);
				return _factory.ElementName(lexerIdentifier);
			}
			
			public override GreenNode VisitLiteral(CompilerParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				CompilerParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return _factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				CompilerParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return _factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				CompilerParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return _factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				CompilerParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return _factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				CompilerParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return _factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				CompilerParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return _factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(CompilerParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), CompilerSyntaxKind.KNull);
				return _factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(CompilerParser.BooleanLiteralContext context)
			{
				if (context == null) return BooleanLiteralGreen.__Missing;
				InternalSyntaxToken booleanLiteral = null;
				if (context.KTrue() != null)
				{
					booleanLiteral = (InternalSyntaxToken)this.VisitTerminal(context.KTrue());
				}
				else 	if (context.KFalse() != null)
				{
					booleanLiteral = (InternalSyntaxToken)this.VisitTerminal(context.KFalse());
				}
				else
				{
					booleanLiteral = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.BooleanLiteral(booleanLiteral);
			}
			
			public override GreenNode VisitIntegerLiteral(CompilerParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), CompilerSyntaxKind.LInteger);
				return _factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(CompilerParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), CompilerSyntaxKind.LDecimal);
				return _factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(CompilerParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), CompilerSyntaxKind.LScientific);
				return _factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(CompilerParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken lString = (InternalSyntaxToken)this.VisitTerminal(context.LString(), CompilerSyntaxKind.LString);
				return _factory.StringLiteral(lString);
			}
        }
    }
    public partial class CompilerParser
    {
		
		internal class MainContext_Cached : MainContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MainContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class GrammarDeclarationContext_Cached : GrammarDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GrammarDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RuleDeclarationsContext_Cached : RuleDeclarationsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RuleDeclarationsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RuleDeclarationContext_Cached : RuleDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RuleDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleDeclarationContext_Cached : ParserRuleDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleAlternativeContext_Cached : ParserRuleAlternativeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleAlternativeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EofElementContext_Cached : EofElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EofElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleAlternativeElementContext_Cached : ParserRuleAlternativeElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleAlternativeElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserMultiElementContext_Cached : ParserMultiElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserMultiElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AssignContext_Cached : AssignContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AssignContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class MultiplicityContext_Cached : MultiplicityContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MultiplicityContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserNegatedElementContext_Cached : ParserNegatedElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserNegatedElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleElementContext_Cached : ParserRuleElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FixedElementContext_Cached : FixedElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FixedElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleReferenceContext_Cached : ParserRuleReferenceContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleReferenceContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleBlockContext_Cached : ParserRuleBlockContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleBlockContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleDeclarationContext_Cached : LexerRuleDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleAlternativeContext_Cached : LexerRuleAlternativeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleAlternativeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleAlternativeElementContext_Cached : LexerRuleAlternativeElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleAlternativeElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerMultiElementContext_Cached : LexerMultiElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerMultiElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerNegatedElementContext_Cached : LexerNegatedElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerNegatedElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRangeElementContext_Cached : LexerRangeElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRangeElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleElementContext_Cached : LexerRuleElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class WildcardElementContext_Cached : WildcardElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public WildcardElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleReferenceContext_Cached : LexerRuleReferenceContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleReferenceContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleBlockContext_Cached : LexerRuleBlockContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleBlockContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NameContext_Cached : NameContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NameContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IdentifierContext_Cached : IdentifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IdentifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleNameContext_Cached : LexerRuleNameContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleNameContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleNameContext_Cached : ParserRuleNameContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleNameContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ElementNameContext_Cached : ElementNameContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ElementNameContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LiteralContext_Cached : LiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NullLiteralContext_Cached : NullLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NullLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class BooleanLiteralContext_Cached : BooleanLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public BooleanLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IntegerLiteralContext_Cached : IntegerLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IntegerLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DecimalLiteralContext_Cached : DecimalLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DecimalLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ScientificLiteralContext_Cached : ScientificLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ScientificLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class StringLiteralContext_Cached : StringLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public StringLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
    }
}

