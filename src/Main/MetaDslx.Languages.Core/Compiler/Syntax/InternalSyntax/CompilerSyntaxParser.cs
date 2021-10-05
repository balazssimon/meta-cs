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
		public GreenNode ParseAnnotation(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.annotation();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAnnotation(AnnotationSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.AnnotationContext _Antlr4ParseAnnotation()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.AnnotationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseAnnotation(CurrentNode as AnnotationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseAnnotation();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.AnnotationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseNamespaceDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.NamespaceDeclarationContext _Antlr4ParseNamespaceDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.NamespaceDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseNamespaceDeclaration(CurrentNode as NamespaceDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.NamespaceDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseNamespaceBody(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody(NamespaceBodySyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.NamespaceBodyContext _Antlr4ParseNamespaceBody()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.NamespaceBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseNamespaceBody(CurrentNode as NamespaceBodySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.NamespaceBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		public GreenNode ParseUsingDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.usingDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseUsingDeclaration(UsingDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.UsingDeclarationContext _Antlr4ParseUsingDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.UsingDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseUsingDeclaration(CurrentNode as UsingDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseUsingDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.UsingDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		public GreenNode ParseParserRuleAlt(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleAlt();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleAlt(ParserRuleAltSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleAltContext _Antlr4ParseParserRuleAlt()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleAltContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleAlt(CurrentNode as ParserRuleAltSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleAlt();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleAltContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleAltRef(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleAltRef();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleAltRef(ParserRuleAltRefSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleAltRefContext _Antlr4ParseParserRuleAltRef()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleAltRefContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleAltRef(CurrentNode as ParserRuleAltRefSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleAltRef();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleAltRefContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleSimple(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleSimple();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleSimple(ParserRuleSimpleSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleSimpleContext _Antlr4ParseParserRuleSimple()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleSimpleContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleSimple(CurrentNode as ParserRuleSimpleSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleSimple();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleSimpleContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		public GreenNode ParseParserRuleNamedElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleNamedElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleNamedElement(ParserRuleNamedElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleNamedElementContext _Antlr4ParseParserRuleNamedElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleNamedElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleNamedElement(CurrentNode as ParserRuleNamedElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleNamedElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleNamedElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		public GreenNode ParseParserRuleFixedElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleFixedElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleFixedElement(ParserRuleFixedElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleFixedElementContext _Antlr4ParseParserRuleFixedElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleFixedElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleFixedElement(CurrentNode as ParserRuleFixedElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleFixedElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleFixedElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleWildcardElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleWildcardElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleWildcardElement(ParserRuleWildcardElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleWildcardElementContext _Antlr4ParseParserRuleWildcardElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleWildcardElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleWildcardElement(CurrentNode as ParserRuleWildcardElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleWildcardElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleWildcardElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		public GreenNode ParseParserRuleBlockElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleBlockElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleBlockElement(ParserRuleBlockElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleBlockElementContext _Antlr4ParseParserRuleBlockElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleBlockElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleBlockElement(CurrentNode as ParserRuleBlockElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleBlockElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleBlockElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		public GreenNode ParseLexerRuleReferenceElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleReferenceElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleReferenceElement(LexerRuleReferenceElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleReferenceElementContext _Antlr4ParseLexerRuleReferenceElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleReferenceElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleReferenceElement(CurrentNode as LexerRuleReferenceElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleReferenceElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleReferenceElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleWildcardElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleWildcardElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleWildcardElement(LexerRuleWildcardElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleWildcardElementContext _Antlr4ParseLexerRuleWildcardElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleWildcardElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleWildcardElement(CurrentNode as LexerRuleWildcardElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleWildcardElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleWildcardElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleFixedStringElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleFixedStringElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleFixedStringElement(LexerRuleFixedStringElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleFixedStringElementContext _Antlr4ParseLexerRuleFixedStringElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleFixedStringElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleFixedStringElement(CurrentNode as LexerRuleFixedStringElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleFixedStringElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleFixedStringElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleFixedCharElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleFixedCharElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleFixedCharElement(LexerRuleFixedCharElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleFixedCharElementContext _Antlr4ParseLexerRuleFixedCharElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleFixedCharElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleFixedCharElement(CurrentNode as LexerRuleFixedCharElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleFixedCharElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleFixedCharElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleBlockElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleBlockElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleBlockElement(LexerRuleBlockElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleBlockElementContext _Antlr4ParseLexerRuleBlockElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleBlockElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleBlockElement(CurrentNode as LexerRuleBlockElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleBlockElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleBlockElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLexerRuleRangeElement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleRangeElement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleRangeElement(LexerRuleRangeElementSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleRangeElementContext _Antlr4ParseLexerRuleRangeElement()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleRangeElementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleRangeElement(CurrentNode as LexerRuleRangeElementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleRangeElement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleRangeElementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		public GreenNode ParseQualifiedName(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.qualifiedName();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQualifiedName(QualifiedNameSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.QualifiedNameContext _Antlr4ParseQualifiedName()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.QualifiedNameContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseQualifiedName(CurrentNode as QualifiedNameSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseQualifiedName();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.QualifiedNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseQualifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.qualifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQualifier(QualifierSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.QualifierContext _Antlr4ParseQualifier()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.QualifierContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseQualifier(CurrentNode as QualifierSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseQualifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.QualifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		public GreenNode ParseLexerRuleIdentifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lexerRuleIdentifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLexerRuleIdentifier(LexerRuleIdentifierSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.LexerRuleIdentifierContext _Antlr4ParseLexerRuleIdentifier()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.LexerRuleIdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLexerRuleIdentifier(CurrentNode as LexerRuleIdentifierSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLexerRuleIdentifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.LexerRuleIdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParserRuleIdentifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parserRuleIdentifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParserRuleIdentifier(ParserRuleIdentifierSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.ParserRuleIdentifierContext _Antlr4ParseParserRuleIdentifier()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.ParserRuleIdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParserRuleIdentifier(CurrentNode as ParserRuleIdentifierSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParserRuleIdentifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.ParserRuleIdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		public GreenNode ParseCharLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.charLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCharLiteral(CharLiteralSyntax node)
		{
			return node != null;
		}
		
		internal CompilerParser.CharLiteralContext _Antlr4ParseCharLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CompilerParser.CharLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseCharLiteral(CurrentNode as CharLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseCharLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CompilerParser.CharLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
				CompilerParser.NamespaceDeclarationContext namespaceDeclarationContext = context.namespaceDeclaration();
				NamespaceDeclarationGreen namespaceDeclaration = null;
				if (namespaceDeclarationContext != null) namespaceDeclaration = (NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext);
				if (namespaceDeclaration == null) namespaceDeclaration = NamespaceDeclarationGreen.__Missing;
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), CompilerSyntaxKind.Eof);
				return _factory.Main(namespaceDeclaration, eOF);
			}
			
			public override GreenNode VisitAnnotation(CompilerParser.AnnotationContext context)
			{
				if (context == null) return AnnotationGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), CompilerSyntaxKind.TOpenBracket);
				CompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), CompilerSyntaxKind.TCloseBracket);
				return _factory.Annotation(tOpenBracket, name, tCloseBracket);
			}
			
			public override GreenNode VisitNamespaceDeclaration(CompilerParser.NamespaceDeclarationContext context)
			{
				if (context == null) return NamespaceDeclarationGreen.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), CompilerSyntaxKind.KNamespace);
				CompilerParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null) qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				if (qualifiedName == null) qualifiedName = QualifiedNameGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), CompilerSyntaxKind.TSemicolon);
				CompilerParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null) namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				if (namespaceBody == null) namespaceBody = NamespaceBodyGreen.__Missing;
				return _factory.NamespaceDeclaration(kNamespace, qualifiedName, tSemicolon, namespaceBody);
			}
			
			public override GreenNode VisitNamespaceBody(CompilerParser.NamespaceBodyContext context)
			{
				if (context == null) return NamespaceBodyGreen.__Missing;
			    CompilerParser.UsingDeclarationContext[] usingDeclarationContext = context.usingDeclaration();
			    var usingDeclarationBuilder = _pool.Allocate<UsingDeclarationGreen>();
			    for (int i = 0; i < usingDeclarationContext.Length; i++)
			    {
			        usingDeclarationBuilder.Add((UsingDeclarationGreen)this.Visit(usingDeclarationContext[i]));
			    }
				var usingDeclaration = usingDeclarationBuilder.ToList();
				_pool.Free(usingDeclarationBuilder);
				CompilerParser.GrammarDeclarationContext grammarDeclarationContext = context.grammarDeclaration();
				GrammarDeclarationGreen grammarDeclaration = null;
				if (grammarDeclarationContext != null) grammarDeclaration = (GrammarDeclarationGreen)this.Visit(grammarDeclarationContext);
				if (grammarDeclaration == null) grammarDeclaration = GrammarDeclarationGreen.__Missing;
				return _factory.NamespaceBody(usingDeclaration, grammarDeclaration);
			}
			
			public override GreenNode VisitGrammarDeclaration(CompilerParser.GrammarDeclarationContext context)
			{
				if (context == null) return GrammarDeclarationGreen.__Missing;
			    CompilerParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
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
				return _factory.GrammarDeclaration(annotation, kGrammar, name, tSemicolon, ruleDeclarations);
			}
			
			public override GreenNode VisitUsingDeclaration(CompilerParser.UsingDeclarationContext context)
			{
				if (context == null) return UsingDeclarationGreen.__Missing;
				InternalSyntaxToken kUsing = (InternalSyntaxToken)this.VisitTerminal(context.KUsing(), CompilerSyntaxKind.KUsing);
				CompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				CompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), CompilerSyntaxKind.TSemicolon);
				return _factory.UsingDeclaration(kUsing, name, tAssign, qualifier, tSemicolon);
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
				CompilerParser.ParserRuleAltContext parserRuleAltContext = context.parserRuleAlt();
				if (parserRuleAltContext != null) 
				{
					return _factory.ParserRuleDeclaration((ParserRuleAltGreen)this.Visit(parserRuleAltContext));
				}
				CompilerParser.ParserRuleSimpleContext parserRuleSimpleContext = context.parserRuleSimple();
				if (parserRuleSimpleContext != null) 
				{
					return _factory.ParserRuleDeclaration((ParserRuleSimpleGreen)this.Visit(parserRuleSimpleContext));
				}
				return ParserRuleDeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitParserRuleAlt(CompilerParser.ParserRuleAltContext context)
			{
				if (context == null) return ParserRuleAltGreen.__Missing;
			    CompilerParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				CompilerParser.ParserRuleNameContext parserRuleNameContext = context.parserRuleName();
				ParserRuleNameGreen parserRuleName = null;
				if (parserRuleNameContext != null) parserRuleName = (ParserRuleNameGreen)this.Visit(parserRuleNameContext);
				if (parserRuleName == null) parserRuleName = ParserRuleNameGreen.__Missing;
				InternalSyntaxToken kDefines = (InternalSyntaxToken)this.VisitTerminal(context.KDefines());
				CompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), CompilerSyntaxKind.TColon);
			    CompilerParser.ParserRuleAltRefContext[] parserRuleAltRefContext = context.parserRuleAltRef();
			    ITerminalNode[] tBarContext = context.TBar();
			    var parserRuleAltRefBuilder = _pool.AllocateSeparated<ParserRuleAltRefGreen>();
			    for (int i = 0; i < parserRuleAltRefContext.Length; i++)
			    {
			        parserRuleAltRefBuilder.Add((ParserRuleAltRefGreen)this.Visit(parserRuleAltRefContext[i]));
			        if (i < tBarContext.Length)
			        {
			            parserRuleAltRefBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tBarContext[i], CompilerSyntaxKind.TBar));
			        }
			    }
				var parserRuleAltRef = parserRuleAltRefBuilder.ToList();
				_pool.Free(parserRuleAltRefBuilder);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), CompilerSyntaxKind.TSemicolon);
				return _factory.ParserRuleAlt(annotation, parserRuleName, kDefines, qualifier, tColon, parserRuleAltRef, tSemicolon);
			}
			
			public override GreenNode VisitParserRuleAltRef(CompilerParser.ParserRuleAltRefContext context)
			{
				if (context == null) return ParserRuleAltRefGreen.__Missing;
				CompilerParser.ParserRuleIdentifierContext parserRuleIdentifierContext = context.parserRuleIdentifier();
				ParserRuleIdentifierGreen parserRuleIdentifier = null;
				if (parserRuleIdentifierContext != null) parserRuleIdentifier = (ParserRuleIdentifierGreen)this.Visit(parserRuleIdentifierContext);
				if (parserRuleIdentifier == null) parserRuleIdentifier = ParserRuleIdentifierGreen.__Missing;
				return _factory.ParserRuleAltRef(parserRuleIdentifier);
			}
			
			public override GreenNode VisitParserRuleSimple(CompilerParser.ParserRuleSimpleContext context)
			{
				if (context == null) return ParserRuleSimpleGreen.__Missing;
			    CompilerParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				CompilerParser.ParserRuleNameContext parserRuleNameContext = context.parserRuleName();
				ParserRuleNameGreen parserRuleName = null;
				if (parserRuleNameContext != null) parserRuleName = (ParserRuleNameGreen)this.Visit(parserRuleNameContext);
				if (parserRuleName == null) parserRuleName = ParserRuleNameGreen.__Missing;
				InternalSyntaxToken kDefines = (InternalSyntaxToken)this.VisitTerminal(context.KDefines());
				CompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), CompilerSyntaxKind.TColon);
			    CompilerParser.ParserRuleNamedElementContext[] parserRuleNamedElementContext = context.parserRuleNamedElement();
			    var parserRuleNamedElementBuilder = _pool.Allocate<ParserRuleNamedElementGreen>();
			    for (int i = 0; i < parserRuleNamedElementContext.Length; i++)
			    {
			        parserRuleNamedElementBuilder.Add((ParserRuleNamedElementGreen)this.Visit(parserRuleNamedElementContext[i]));
			    }
				var parserRuleNamedElement = parserRuleNamedElementBuilder.ToList();
				_pool.Free(parserRuleNamedElementBuilder);
				CompilerParser.EofElementContext eofElementContext = context.eofElement();
				EofElementGreen eofElement = null;
				if (eofElementContext != null) eofElement = (EofElementGreen)this.Visit(eofElementContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), CompilerSyntaxKind.TSemicolon);
				return _factory.ParserRuleSimple(annotation, parserRuleName, kDefines, qualifier, tColon, parserRuleNamedElement, eofElement, tSemicolon);
			}
			
			public override GreenNode VisitEofElement(CompilerParser.EofElementContext context)
			{
				if (context == null) return EofElementGreen.__Missing;
				InternalSyntaxToken kEof = (InternalSyntaxToken)this.VisitTerminal(context.KEof(), CompilerSyntaxKind.KEof);
				return _factory.EofElement(kEof);
			}
			
			public override GreenNode VisitParserRuleNamedElement(CompilerParser.ParserRuleNamedElementContext context)
			{
				if (context == null) return ParserRuleNamedElementGreen.__Missing;
			    CompilerParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				CompilerParser.ElementNameContext elementNameContext = context.elementName();
				ElementNameGreen elementName = null;
				if (elementNameContext != null) elementName = (ElementNameGreen)this.Visit(elementNameContext);
				CompilerParser.AssignContext assignContext = context.assign();
				AssignGreen assign = null;
				if (assignContext != null) assign = (AssignGreen)this.Visit(assignContext);
				CompilerParser.ParserNegatedElementContext parserNegatedElementContext = context.parserNegatedElement();
				ParserNegatedElementGreen parserNegatedElement = null;
				if (parserNegatedElementContext != null) parserNegatedElement = (ParserNegatedElementGreen)this.Visit(parserNegatedElementContext);
				if (parserNegatedElement == null) parserNegatedElement = ParserNegatedElementGreen.__Missing;
				CompilerParser.MultiplicityContext multiplicityContext = context.multiplicity();
				MultiplicityGreen multiplicity = null;
				if (multiplicityContext != null) multiplicity = (MultiplicityGreen)this.Visit(multiplicityContext);
				return _factory.ParserRuleNamedElement(annotation, elementName, assign, parserNegatedElement, multiplicity);
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
				InternalSyntaxToken tNegate = (InternalSyntaxToken)this.VisitTerminal(context.TNegate());
				CompilerParser.ParserRuleElementContext parserRuleElementContext = context.parserRuleElement();
				ParserRuleElementGreen parserRuleElement = null;
				if (parserRuleElementContext != null) parserRuleElement = (ParserRuleElementGreen)this.Visit(parserRuleElementContext);
				if (parserRuleElement == null) parserRuleElement = ParserRuleElementGreen.__Missing;
				return _factory.ParserNegatedElement(tNegate, parserRuleElement);
			}
			
			public override GreenNode VisitParserRuleElement(CompilerParser.ParserRuleElementContext context)
			{
				if (context == null) return ParserRuleElementGreen.__Missing;
				CompilerParser.ParserRuleFixedElementContext parserRuleFixedElementContext = context.parserRuleFixedElement();
				if (parserRuleFixedElementContext != null) 
				{
					return _factory.ParserRuleElement((ParserRuleFixedElementGreen)this.Visit(parserRuleFixedElementContext));
				}
				CompilerParser.ParserRuleReferenceContext parserRuleReferenceContext = context.parserRuleReference();
				if (parserRuleReferenceContext != null) 
				{
					return _factory.ParserRuleElement((ParserRuleReferenceGreen)this.Visit(parserRuleReferenceContext));
				}
				CompilerParser.ParserRuleWildcardElementContext parserRuleWildcardElementContext = context.parserRuleWildcardElement();
				if (parserRuleWildcardElementContext != null) 
				{
					return _factory.ParserRuleElement((ParserRuleWildcardElementGreen)this.Visit(parserRuleWildcardElementContext));
				}
				CompilerParser.ParserRuleBlockElementContext parserRuleBlockElementContext = context.parserRuleBlockElement();
				if (parserRuleBlockElementContext != null) 
				{
					return _factory.ParserRuleElement((ParserRuleBlockElementGreen)this.Visit(parserRuleBlockElementContext));
				}
				return ParserRuleElementGreen.__Missing;
			}
			
			public override GreenNode VisitParserRuleFixedElement(CompilerParser.ParserRuleFixedElementContext context)
			{
				if (context == null) return ParserRuleFixedElementGreen.__Missing;
			    CompilerParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				CompilerParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.ParserRuleFixedElement(annotation, stringLiteral);
			}
			
			public override GreenNode VisitParserRuleWildcardElement(CompilerParser.ParserRuleWildcardElementContext context)
			{
				if (context == null) return ParserRuleWildcardElementGreen.__Missing;
			    CompilerParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				InternalSyntaxToken tDot = (InternalSyntaxToken)this.VisitTerminal(context.TDot(), CompilerSyntaxKind.TDot);
				return _factory.ParserRuleWildcardElement(annotation, tDot);
			}
			
			public override GreenNode VisitParserRuleReference(CompilerParser.ParserRuleReferenceContext context)
			{
				if (context == null) return ParserRuleReferenceGreen.__Missing;
			    CompilerParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				CompilerParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.ParserRuleReference(annotation, identifier);
			}
			
			public override GreenNode VisitParserRuleBlockElement(CompilerParser.ParserRuleBlockElementContext context)
			{
				if (context == null) return ParserRuleBlockElementGreen.__Missing;
			    CompilerParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CompilerSyntaxKind.TOpenParen);
			    CompilerParser.ParserRuleNamedElementContext[] parserRuleNamedElementContext = context.parserRuleNamedElement();
			    var parserRuleNamedElementBuilder = _pool.Allocate<ParserRuleNamedElementGreen>();
			    for (int i = 0; i < parserRuleNamedElementContext.Length; i++)
			    {
			        parserRuleNamedElementBuilder.Add((ParserRuleNamedElementGreen)this.Visit(parserRuleNamedElementContext[i]));
			    }
				var parserRuleNamedElement = parserRuleNamedElementBuilder.ToList();
				_pool.Free(parserRuleNamedElementBuilder);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CompilerSyntaxKind.TCloseParen);
				return _factory.ParserRuleBlockElement(annotation, tOpenParen, parserRuleNamedElement, tCloseParen);
			}
			
			public override GreenNode VisitLexerRuleDeclaration(CompilerParser.LexerRuleDeclarationContext context)
			{
				if (context == null) return LexerRuleDeclarationGreen.__Missing;
			    CompilerParser.AnnotationContext[] annotationContext = context.annotation();
			    var annotationBuilder = _pool.Allocate<AnnotationGreen>();
			    for (int i = 0; i < annotationContext.Length; i++)
			    {
			        annotationBuilder.Add((AnnotationGreen)this.Visit(annotationContext[i]));
			    }
				var annotation = annotationBuilder.ToList();
				_pool.Free(annotationBuilder);
				InternalSyntaxToken modifier = null;
				if (context.KHidden() != null)
				{
					modifier = (InternalSyntaxToken)this.VisitTerminal(context.KHidden());
				}
				else 	if (context.KFragment() != null)
				{
					modifier = (InternalSyntaxToken)this.VisitTerminal(context.KFragment());
				}
				CompilerParser.LexerRuleNameContext lexerRuleNameContext = context.lexerRuleName();
				LexerRuleNameGreen lexerRuleName = null;
				if (lexerRuleNameContext != null) lexerRuleName = (LexerRuleNameGreen)this.Visit(lexerRuleNameContext);
				if (lexerRuleName == null) lexerRuleName = LexerRuleNameGreen.__Missing;
				InternalSyntaxToken kReturns = (InternalSyntaxToken)this.VisitTerminal(context.KReturns());
				CompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
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
				return _factory.LexerRuleDeclaration(annotation, modifier, lexerRuleName, kReturns, qualifier, tColon, lexerRuleAlternative, tSemicolon);
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
				InternalSyntaxToken tNegate = (InternalSyntaxToken)this.VisitTerminal(context.TNegate());
				CompilerParser.LexerRuleElementContext lexerRuleElementContext = context.lexerRuleElement();
				LexerRuleElementGreen lexerRuleElement = null;
				if (lexerRuleElementContext != null) lexerRuleElement = (LexerRuleElementGreen)this.Visit(lexerRuleElementContext);
				if (lexerRuleElement == null) lexerRuleElement = LexerRuleElementGreen.__Missing;
				CompilerParser.MultiplicityContext multiplicityContext = context.multiplicity();
				MultiplicityGreen multiplicity = null;
				if (multiplicityContext != null) multiplicity = (MultiplicityGreen)this.Visit(multiplicityContext);
				return _factory.LexerRuleAlternativeElement(tNegate, lexerRuleElement, multiplicity);
			}
			
			public override GreenNode VisitLexerRuleElement(CompilerParser.LexerRuleElementContext context)
			{
				if (context == null) return LexerRuleElementGreen.__Missing;
				CompilerParser.LexerRuleReferenceElementContext lexerRuleReferenceElementContext = context.lexerRuleReferenceElement();
				if (lexerRuleReferenceElementContext != null) 
				{
					return _factory.LexerRuleElement((LexerRuleReferenceElementGreen)this.Visit(lexerRuleReferenceElementContext));
				}
				CompilerParser.LexerRuleFixedStringElementContext lexerRuleFixedStringElementContext = context.lexerRuleFixedStringElement();
				if (lexerRuleFixedStringElementContext != null) 
				{
					return _factory.LexerRuleElement((LexerRuleFixedStringElementGreen)this.Visit(lexerRuleFixedStringElementContext));
				}
				CompilerParser.LexerRuleFixedCharElementContext lexerRuleFixedCharElementContext = context.lexerRuleFixedCharElement();
				if (lexerRuleFixedCharElementContext != null) 
				{
					return _factory.LexerRuleElement((LexerRuleFixedCharElementGreen)this.Visit(lexerRuleFixedCharElementContext));
				}
				CompilerParser.LexerRuleWildcardElementContext lexerRuleWildcardElementContext = context.lexerRuleWildcardElement();
				if (lexerRuleWildcardElementContext != null) 
				{
					return _factory.LexerRuleElement((LexerRuleWildcardElementGreen)this.Visit(lexerRuleWildcardElementContext));
				}
				CompilerParser.LexerRuleBlockElementContext lexerRuleBlockElementContext = context.lexerRuleBlockElement();
				if (lexerRuleBlockElementContext != null) 
				{
					return _factory.LexerRuleElement((LexerRuleBlockElementGreen)this.Visit(lexerRuleBlockElementContext));
				}
				CompilerParser.LexerRuleRangeElementContext lexerRuleRangeElementContext = context.lexerRuleRangeElement();
				if (lexerRuleRangeElementContext != null) 
				{
					return _factory.LexerRuleElement((LexerRuleRangeElementGreen)this.Visit(lexerRuleRangeElementContext));
				}
				return LexerRuleElementGreen.__Missing;
			}
			
			public override GreenNode VisitLexerRuleReferenceElement(CompilerParser.LexerRuleReferenceElementContext context)
			{
				if (context == null) return LexerRuleReferenceElementGreen.__Missing;
				CompilerParser.LexerRuleIdentifierContext lexerRuleIdentifierContext = context.lexerRuleIdentifier();
				LexerRuleIdentifierGreen lexerRuleIdentifier = null;
				if (lexerRuleIdentifierContext != null) lexerRuleIdentifier = (LexerRuleIdentifierGreen)this.Visit(lexerRuleIdentifierContext);
				if (lexerRuleIdentifier == null) lexerRuleIdentifier = LexerRuleIdentifierGreen.__Missing;
				return _factory.LexerRuleReferenceElement(lexerRuleIdentifier);
			}
			
			public override GreenNode VisitLexerRuleWildcardElement(CompilerParser.LexerRuleWildcardElementContext context)
			{
				if (context == null) return LexerRuleWildcardElementGreen.__Missing;
				InternalSyntaxToken tDot = (InternalSyntaxToken)this.VisitTerminal(context.TDot(), CompilerSyntaxKind.TDot);
				return _factory.LexerRuleWildcardElement(tDot);
			}
			
			public override GreenNode VisitLexerRuleFixedStringElement(CompilerParser.LexerRuleFixedStringElementContext context)
			{
				if (context == null) return LexerRuleFixedStringElementGreen.__Missing;
				InternalSyntaxToken lString = (InternalSyntaxToken)this.VisitTerminal(context.LString(), CompilerSyntaxKind.LString);
				return _factory.LexerRuleFixedStringElement(lString);
			}
			
			public override GreenNode VisitLexerRuleFixedCharElement(CompilerParser.LexerRuleFixedCharElementContext context)
			{
				if (context == null) return LexerRuleFixedCharElementGreen.__Missing;
				InternalSyntaxToken lCharacter = (InternalSyntaxToken)this.VisitTerminal(context.LCharacter(), CompilerSyntaxKind.LCharacter);
				return _factory.LexerRuleFixedCharElement(lCharacter);
			}
			
			public override GreenNode VisitLexerRuleBlockElement(CompilerParser.LexerRuleBlockElementContext context)
			{
				if (context == null) return LexerRuleBlockElementGreen.__Missing;
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
				return _factory.LexerRuleBlockElement(tOpenParen, lexerRuleAlternative, tCloseParen);
			}
			
			public override GreenNode VisitLexerRuleRangeElement(CompilerParser.LexerRuleRangeElementContext context)
			{
				if (context == null) return LexerRuleRangeElementGreen.__Missing;
				CompilerParser.LexerRuleFixedCharElementContext startContext = context.start;
				LexerRuleFixedCharElementGreen start = null;
				if (startContext != null) start = (LexerRuleFixedCharElementGreen)this.Visit(startContext);
				if (start == null) start = LexerRuleFixedCharElementGreen.__Missing;
				InternalSyntaxToken tDotDot = (InternalSyntaxToken)this.VisitTerminal(context.TDotDot(), CompilerSyntaxKind.TDotDot);
				CompilerParser.LexerRuleFixedCharElementContext endContext = context.end;
				LexerRuleFixedCharElementGreen end = null;
				if (endContext != null) end = (LexerRuleFixedCharElementGreen)this.Visit(endContext);
				if (end == null) end = LexerRuleFixedCharElementGreen.__Missing;
				return _factory.LexerRuleRangeElement(start, tDotDot, end);
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
			
			public override GreenNode VisitQualifiedName(CompilerParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
				CompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.QualifiedName(qualifier);
			}
			
			public override GreenNode VisitQualifier(CompilerParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    CompilerParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], CompilerSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.Qualifier(identifier);
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
			
			public override GreenNode VisitLexerRuleIdentifier(CompilerParser.LexerRuleIdentifierContext context)
			{
				if (context == null) return LexerRuleIdentifierGreen.__Missing;
				InternalSyntaxToken lexerIdentifier = (InternalSyntaxToken)this.VisitTerminal(context.LexerIdentifier(), CompilerSyntaxKind.LexerIdentifier);
				return _factory.LexerRuleIdentifier(lexerIdentifier);
			}
			
			public override GreenNode VisitParserRuleIdentifier(CompilerParser.ParserRuleIdentifierContext context)
			{
				if (context == null) return ParserRuleIdentifierGreen.__Missing;
				InternalSyntaxToken parserIdentifier = (InternalSyntaxToken)this.VisitTerminal(context.ParserIdentifier(), CompilerSyntaxKind.ParserIdentifier);
				return _factory.ParserRuleIdentifier(parserIdentifier);
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
				InternalSyntaxToken elementName = null;
				if (context.ParserIdentifier() != null)
				{
					elementName = (InternalSyntaxToken)this.VisitTerminal(context.ParserIdentifier());
				}
				else 	if (context.IgnoredIdentifier() != null)
				{
					elementName = (InternalSyntaxToken)this.VisitTerminal(context.IgnoredIdentifier());
				}
				else
				{
					elementName = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.ElementName(elementName);
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
			
			public override GreenNode VisitCharLiteral(CompilerParser.CharLiteralContext context)
			{
				if (context == null) return CharLiteralGreen.__Missing;
				InternalSyntaxToken lCharacter = (InternalSyntaxToken)this.VisitTerminal(context.LCharacter(), CompilerSyntaxKind.LCharacter);
				return _factory.CharLiteral(lCharacter);
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
		
		internal class AnnotationContext_Cached : AnnotationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AnnotationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclarationContext_Cached : NamespaceDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBodyContext_Cached : NamespaceBodyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBodyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class UsingDeclarationContext_Cached : UsingDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public UsingDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ParserRuleAltContext_Cached : ParserRuleAltContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleAltContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleAltRefContext_Cached : ParserRuleAltRefContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleAltRefContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleSimpleContext_Cached : ParserRuleSimpleContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleSimpleContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ParserRuleNamedElementContext_Cached : ParserRuleNamedElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleNamedElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ParserRuleFixedElementContext_Cached : ParserRuleFixedElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleFixedElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleWildcardElementContext_Cached : ParserRuleWildcardElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleWildcardElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ParserRuleBlockElementContext_Cached : ParserRuleBlockElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleBlockElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class LexerRuleReferenceElementContext_Cached : LexerRuleReferenceElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleReferenceElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleWildcardElementContext_Cached : LexerRuleWildcardElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleWildcardElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleFixedStringElementContext_Cached : LexerRuleFixedStringElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleFixedStringElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleFixedCharElementContext_Cached : LexerRuleFixedCharElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleFixedCharElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleBlockElementContext_Cached : LexerRuleBlockElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleBlockElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LexerRuleRangeElementContext_Cached : LexerRuleRangeElementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleRangeElementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class QualifiedNameContext_Cached : QualifiedNameContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QualifiedNameContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QualifierContext_Cached : QualifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QualifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class LexerRuleIdentifierContext_Cached : LexerRuleIdentifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LexerRuleIdentifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParserRuleIdentifierContext_Cached : ParserRuleIdentifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParserRuleIdentifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class CharLiteralContext_Cached : CharLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CharLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
    }
}

