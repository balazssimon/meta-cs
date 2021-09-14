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
namespace MetaDslx.Languages.Core.Syntax.InternalSyntax
{
    public class CoreSyntaxParser : Antlr4SyntaxParser
    {
        private readonly Antlr4ToRoslynVisitor _visitor;
        public CoreSyntaxParser(
            SourceText text,
            CoreParseOptions options,
            CoreSyntaxNode oldTree, 
			ParseData oldParseData,
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
            : base(CoreLanguage.Instance, text, options, oldTree, oldParseData, changes, cancellationToken)
        {
            _visitor = new Antlr4ToRoslynVisitor(this);
        }
        protected new CoreParser Antlr4Parser => (CoreParser)base.Antlr4Parser;
		public override LanguageSyntaxNode Parse()
		{
			BeginRoot();
            ParserState state = null;
			var green = this.ParseMain(ref state);
			EndRoot(ref green);
			var red = (CoreSyntaxNode)green.CreateRed();
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
		
		internal CoreParser.MainContext _Antlr4ParseMain()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.MainContext context = null;
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
					context = new CoreParser.MainContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseUsingNamespace(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.usingNamespace();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseUsingNamespace(UsingNamespaceSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.UsingNamespaceContext _Antlr4ParseUsingNamespace()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.UsingNamespaceContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseUsingNamespace(CurrentNode as UsingNamespaceSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseUsingNamespace();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.UsingNamespaceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.statement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseStatement(StatementSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.StatementContext _Antlr4ParseStatement()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.StatementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseStatement(CurrentNode as StatementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.StatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseBlockStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.blockStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseBlockStatement(BlockStatementSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.BlockStatementContext _Antlr4ParseBlockStatement()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.BlockStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseBlockStatement(CurrentNode as BlockStatementSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseBlockStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.BlockStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.expression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseExpression(ExpressionSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ExpressionContext _Antlr4ParseExpression(int precedence)
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseExpression(CurrentNode as ExpressionSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseExpression(precedence);
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseArgumentList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.argumentList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArgumentList(ArgumentListSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ArgumentListContext _Antlr4ParseArgumentList()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ArgumentListContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseArgumentList(CurrentNode as ArgumentListSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseArgumentList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ArgumentListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseArgumentExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.argumentExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArgumentExpression(ArgumentExpressionSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ArgumentExpressionContext _Antlr4ParseArgumentExpression()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ArgumentExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseArgumentExpression(CurrentNode as ArgumentExpressionSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseArgumentExpression();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ArgumentExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseInitializerExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.initializerExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseInitializerExpression(InitializerExpressionSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.InitializerExpressionContext _Antlr4ParseInitializerExpression()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.InitializerExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseInitializerExpression(CurrentNode as InitializerExpressionSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseInitializerExpression();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.InitializerExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseFieldInitializerExpressions(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.fieldInitializerExpressions();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFieldInitializerExpressions(FieldInitializerExpressionsSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.FieldInitializerExpressionsContext _Antlr4ParseFieldInitializerExpressions()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.FieldInitializerExpressionsContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseFieldInitializerExpressions(CurrentNode as FieldInitializerExpressionsSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseFieldInitializerExpressions();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.FieldInitializerExpressionsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseFieldInitializerExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.fieldInitializerExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFieldInitializerExpression(FieldInitializerExpressionSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.FieldInitializerExpressionContext _Antlr4ParseFieldInitializerExpression()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.FieldInitializerExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseFieldInitializerExpression(CurrentNode as FieldInitializerExpressionSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseFieldInitializerExpression();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.FieldInitializerExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseCollectionInitializerExpressions(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.collectionInitializerExpressions();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.CollectionInitializerExpressionsContext _Antlr4ParseCollectionInitializerExpressions()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.CollectionInitializerExpressionsContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseCollectionInitializerExpressions(CurrentNode as CollectionInitializerExpressionsSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseCollectionInitializerExpressions();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.CollectionInitializerExpressionsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseDictionaryInitializerExpressions(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.dictionaryInitializerExpressions();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.DictionaryInitializerExpressionsContext _Antlr4ParseDictionaryInitializerExpressions()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.DictionaryInitializerExpressionsContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseDictionaryInitializerExpressions(CurrentNode as DictionaryInitializerExpressionsSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseDictionaryInitializerExpressions();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.DictionaryInitializerExpressionsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseDictionaryInitializerExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.dictionaryInitializerExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.DictionaryInitializerExpressionContext _Antlr4ParseDictionaryInitializerExpression()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.DictionaryInitializerExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseDictionaryInitializerExpression(CurrentNode as DictionaryInitializerExpressionSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseDictionaryInitializerExpression();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.DictionaryInitializerExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLambdaSignature(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lambdaSignature();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLambdaSignature(LambdaSignatureSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.LambdaSignatureContext _Antlr4ParseLambdaSignature()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.LambdaSignatureContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLambdaSignature(CurrentNode as LambdaSignatureSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLambdaSignature();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.LambdaSignatureContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseImplicitLambdaSignature(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.implicitLambdaSignature();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseImplicitLambdaSignature(ImplicitLambdaSignatureSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ImplicitLambdaSignatureContext _Antlr4ParseImplicitLambdaSignature()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ImplicitLambdaSignatureContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseImplicitLambdaSignature(CurrentNode as ImplicitLambdaSignatureSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseImplicitLambdaSignature();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ImplicitLambdaSignatureContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseImplicitParameterList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.implicitParameterList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseImplicitParameterList(ImplicitParameterListSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ImplicitParameterListContext _Antlr4ParseImplicitParameterList()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ImplicitParameterListContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseImplicitParameterList(CurrentNode as ImplicitParameterListSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseImplicitParameterList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ImplicitParameterListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseImplicitParameter(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.implicitParameter();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseImplicitParameter(ImplicitParameterSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ImplicitParameterContext _Antlr4ParseImplicitParameter()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ImplicitParameterContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseImplicitParameter(CurrentNode as ImplicitParameterSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseImplicitParameter();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ImplicitParameterContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseExplicitLambdaSignature(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.explicitLambdaSignature();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseExplicitLambdaSignature(ExplicitLambdaSignatureSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ExplicitLambdaSignatureContext _Antlr4ParseExplicitLambdaSignature()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ExplicitLambdaSignatureContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseExplicitLambdaSignature(CurrentNode as ExplicitLambdaSignatureSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseExplicitLambdaSignature();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ExplicitLambdaSignatureContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseExplicitParameterList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.explicitParameterList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseExplicitParameterList(ExplicitParameterListSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ExplicitParameterListContext _Antlr4ParseExplicitParameterList()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ExplicitParameterListContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseExplicitParameterList(CurrentNode as ExplicitParameterListSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseExplicitParameterList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ExplicitParameterListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseExplicitParameter(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.explicitParameter();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseExplicitParameter(ExplicitParameterSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ExplicitParameterContext _Antlr4ParseExplicitParameter()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ExplicitParameterContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseExplicitParameter(CurrentNode as ExplicitParameterSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseExplicitParameter();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ExplicitParameterContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLambdaBody(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.lambdaBody();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLambdaBody(LambdaBodySyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.LambdaBodyContext _Antlr4ParseLambdaBody()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.LambdaBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLambdaBody(CurrentNode as LambdaBodySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLambdaBody();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.LambdaBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseDotOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.dotOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDotOperator(DotOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.DotOperatorContext _Antlr4ParseDotOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.DotOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseDotOperator(CurrentNode as DotOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseDotOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.DotOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseIndexerOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.indexerOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIndexerOperator(IndexerOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.IndexerOperatorContext _Antlr4ParseIndexerOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.IndexerOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseIndexerOperator(CurrentNode as IndexerOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseIndexerOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.IndexerOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParsePostfixOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.postfixOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePostfixOperator(PostfixOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.PostfixOperatorContext _Antlr4ParsePostfixOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.PostfixOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReusePostfixOperator(CurrentNode as PostfixOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParsePostfixOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.PostfixOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseUnaryOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.unaryOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseUnaryOperator(UnaryOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.UnaryOperatorContext _Antlr4ParseUnaryOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.UnaryOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseUnaryOperator(CurrentNode as UnaryOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseUnaryOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.UnaryOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseMultiplicativeOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.multiplicativeOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMultiplicativeOperator(MultiplicativeOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.MultiplicativeOperatorContext _Antlr4ParseMultiplicativeOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.MultiplicativeOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMultiplicativeOperator(CurrentNode as MultiplicativeOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMultiplicativeOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.MultiplicativeOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseAdditiveOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.additiveOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAdditiveOperator(AdditiveOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.AdditiveOperatorContext _Antlr4ParseAdditiveOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.AdditiveOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseAdditiveOperator(CurrentNode as AdditiveOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseAdditiveOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.AdditiveOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseShiftOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.shiftOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseShiftOperator(ShiftOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ShiftOperatorContext _Antlr4ParseShiftOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ShiftOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseShiftOperator(CurrentNode as ShiftOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseShiftOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ShiftOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLeftShiftOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.leftShiftOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLeftShiftOperator(LeftShiftOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.LeftShiftOperatorContext _Antlr4ParseLeftShiftOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.LeftShiftOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLeftShiftOperator(CurrentNode as LeftShiftOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLeftShiftOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.LeftShiftOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseRightShiftOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.rightShiftOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRightShiftOperator(RightShiftOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.RightShiftOperatorContext _Antlr4ParseRightShiftOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.RightShiftOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseRightShiftOperator(CurrentNode as RightShiftOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseRightShiftOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.RightShiftOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseRelationalOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.relationalOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRelationalOperator(RelationalOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.RelationalOperatorContext _Antlr4ParseRelationalOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.RelationalOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseRelationalOperator(CurrentNode as RelationalOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseRelationalOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.RelationalOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseEqualityOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.equalityOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEqualityOperator(EqualityOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.EqualityOperatorContext _Antlr4ParseEqualityOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.EqualityOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseEqualityOperator(CurrentNode as EqualityOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseEqualityOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.EqualityOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseCompoundAssignmentOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.compoundAssignmentOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.CompoundAssignmentOperatorContext _Antlr4ParseCompoundAssignmentOperator()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.CompoundAssignmentOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseCompoundAssignmentOperator(CurrentNode as CompoundAssignmentOperatorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseCompoundAssignmentOperator();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.CompoundAssignmentOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseReturnType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.returnType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseReturnType(ReturnTypeSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.ReturnTypeContext _Antlr4ParseReturnType()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ReturnTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseReturnType(CurrentNode as ReturnTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseReturnType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.ReturnTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseTypeReference(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typeReference();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypeReference(TypeReferenceSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.TypeReferenceContext _Antlr4ParseTypeReference(int precedence)
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.TypeReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseTypeReference(CurrentNode as TypeReferenceSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeReference(precedence);
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.TypeReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseNamedType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namedType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamedType(NamedTypeSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.NamedTypeContext _Antlr4ParseNamedType()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.NamedTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseNamedType(CurrentNode as NamedTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamedType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.NamedTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseGenericTypeArguments(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.genericTypeArguments();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGenericTypeArguments(GenericTypeArgumentsSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.GenericTypeArgumentsContext _Antlr4ParseGenericTypeArguments()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.GenericTypeArgumentsContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseGenericTypeArguments(CurrentNode as GenericTypeArgumentsSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseGenericTypeArguments();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.GenericTypeArgumentsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseGenericTypeArgument(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.genericTypeArgument();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGenericTypeArgument(GenericTypeArgumentSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.GenericTypeArgumentContext _Antlr4ParseGenericTypeArgument()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.GenericTypeArgumentContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseGenericTypeArgument(CurrentNode as GenericTypeArgumentSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseGenericTypeArgument();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.GenericTypeArgumentContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParsePrimitiveType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.primitiveType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePrimitiveType(PrimitiveTypeSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.PrimitiveTypeContext _Antlr4ParsePrimitiveType()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.PrimitiveTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReusePrimitiveType(CurrentNode as PrimitiveTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParsePrimitiveType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.PrimitiveTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseVoidType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.voidType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVoidType(VoidTypeSyntax node)
		{
			return node != null;
		}
		
		internal CoreParser.VoidTypeContext _Antlr4ParseVoidType()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.VoidTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseVoidType(CurrentNode as VoidTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseVoidType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new CoreParser.VoidTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.NameContext _Antlr4ParseName()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.NameContext context = null;
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
					context = new CoreParser.NameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.QualifiedNameContext _Antlr4ParseQualifiedName()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.QualifiedNameContext context = null;
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
					context = new CoreParser.QualifiedNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.QualifierContext _Antlr4ParseQualifier()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.QualifierContext context = null;
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
					context = new CoreParser.QualifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.IdentifierContext _Antlr4ParseIdentifier()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.IdentifierContext context = null;
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
					context = new CoreParser.IdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.LiteralContext _Antlr4ParseLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.LiteralContext context = null;
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
					context = new CoreParser.LiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.NullLiteralContext _Antlr4ParseNullLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.NullLiteralContext context = null;
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
					context = new CoreParser.NullLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.BooleanLiteralContext _Antlr4ParseBooleanLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.BooleanLiteralContext context = null;
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
					context = new CoreParser.BooleanLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.IntegerLiteralContext _Antlr4ParseIntegerLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.IntegerLiteralContext context = null;
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
					context = new CoreParser.IntegerLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.DecimalLiteralContext _Antlr4ParseDecimalLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.DecimalLiteralContext context = null;
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
					context = new CoreParser.DecimalLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.ScientificLiteralContext _Antlr4ParseScientificLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.ScientificLiteralContext context = null;
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
					context = new CoreParser.ScientificLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal CoreParser.StringLiteralContext _Antlr4ParseStringLiteral()
		{
			BeginNode();
		    bool cached = false;
		    CoreParser.StringLiteralContext context = null;
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
					context = new CoreParser.StringLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
        private class Antlr4ToRoslynVisitor : CoreParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.
			private readonly CoreInternalSyntaxFactory _factory;
            private readonly CoreSyntaxParser _syntaxParser;
            public Antlr4ToRoslynVisitor(CoreSyntaxParser syntaxParser)
            {
				_factory = (CoreInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                _syntaxParser = syntaxParser;
            }
            private GreenNode VisitTerminal(IToken token, CoreSyntaxKind kind)
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
            private GreenNode VisitTerminal(ITerminalNode node, CoreSyntaxKind kind)
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
			
			public override GreenNode VisitMain(CoreParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
			    CoreParser.UsingNamespaceContext[] usingNamespaceContext = context.usingNamespace();
			    var usingNamespaceBuilder = _pool.Allocate<UsingNamespaceGreen>();
			    for (int i = 0; i < usingNamespaceContext.Length; i++)
			    {
			        usingNamespaceBuilder.Add((UsingNamespaceGreen)this.Visit(usingNamespaceContext[i]));
			    }
				var usingNamespace = usingNamespaceBuilder.ToList();
				_pool.Free(usingNamespaceBuilder);
			    CoreParser.StatementContext[] statementContext = context.statement();
			    var statementBuilder = _pool.Allocate<StatementGreen>();
			    for (int i = 0; i < statementContext.Length; i++)
			    {
			        statementBuilder.Add((StatementGreen)this.Visit(statementContext[i]));
			    }
				var statement = statementBuilder.ToList();
				_pool.Free(statementBuilder);
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), CoreSyntaxKind.Eof);
				return _factory.Main(usingNamespace, statement, eOF);
			}
			
			public override GreenNode VisitUsingNamespace(CoreParser.UsingNamespaceContext context)
			{
				if (context == null) return UsingNamespaceGreen.__Missing;
				InternalSyntaxToken kUsing = (InternalSyntaxToken)this.VisitTerminal(context.KUsing(), CoreSyntaxKind.KUsing);
				CoreParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				CoreParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), CoreSyntaxKind.TSemicolon);
				return _factory.UsingNamespace(kUsing, name, tAssign, qualifier, tSemicolon);
			}
			
			public override GreenNode VisitStatement(CoreParser.StatementContext context)
			{
				if (context == null) return StatementGreen.__Missing;
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), CoreSyntaxKind.TSemicolon);
				return _factory.Statement(expression, tSemicolon);
			}
			
			public override GreenNode VisitBlockStatement(CoreParser.BlockStatementContext context)
			{
				if (context == null) return BlockStatementGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), CoreSyntaxKind.TOpenBrace);
			    CoreParser.StatementContext[] statementContext = context.statement();
			    var statementBuilder = _pool.Allocate<StatementGreen>();
			    for (int i = 0; i < statementContext.Length; i++)
			    {
			        statementBuilder.Add((StatementGreen)this.Visit(statementContext[i]));
			    }
				var statement = statementBuilder.ToList();
				_pool.Free(statementBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), CoreSyntaxKind.TCloseBrace);
				return _factory.BlockStatement(tOpenBrace, statement, tCloseBrace);
			}
			
			public override GreenNode VisitParenthesizedExpr(CoreParser.ParenthesizedExprContext context)
			{
				if (context == null) return ParenthesizedExprGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				return _factory.ParenthesizedExpr(tOpenParen, expression, tCloseParen);
			}
			
			public override GreenNode VisitDefaultExpr(CoreParser.DefaultExprContext context)
			{
				if (context == null) return DefaultExprGreen.__Missing;
				InternalSyntaxToken kDefault = (InternalSyntaxToken)this.VisitTerminal(context.KDefault(), CoreSyntaxKind.KDefault);
				return _factory.DefaultExpr(kDefault);
			}
			
			public override GreenNode VisitThisExpr(CoreParser.ThisExprContext context)
			{
				if (context == null) return ThisExprGreen.__Missing;
				InternalSyntaxToken kThis = (InternalSyntaxToken)this.VisitTerminal(context.KThis(), CoreSyntaxKind.KThis);
				return _factory.ThisExpr(kThis);
			}
			
			public override GreenNode VisitBaseExpr(CoreParser.BaseExprContext context)
			{
				if (context == null) return BaseExprGreen.__Missing;
				InternalSyntaxToken kBase = (InternalSyntaxToken)this.VisitTerminal(context.KBase(), CoreSyntaxKind.KBase);
				return _factory.BaseExpr(kBase);
			}
			
			public override GreenNode VisitLiteralExpr(CoreParser.LiteralExprContext context)
			{
				if (context == null) return LiteralExprGreen.__Missing;
				CoreParser.LiteralContext literalContext = context.literal();
				LiteralGreen literal = null;
				if (literalContext != null) literal = (LiteralGreen)this.Visit(literalContext);
				if (literal == null) literal = LiteralGreen.__Missing;
				return _factory.LiteralExpr(literal);
			}
			
			public override GreenNode VisitIdentifierExpr(CoreParser.IdentifierExprContext context)
			{
				if (context == null) return IdentifierExprGreen.__Missing;
				CoreParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				CoreParser.GenericTypeArgumentsContext genericTypeArgumentsContext = context.genericTypeArguments();
				GenericTypeArgumentsGreen genericTypeArguments = null;
				if (genericTypeArgumentsContext != null) genericTypeArguments = (GenericTypeArgumentsGreen)this.Visit(genericTypeArgumentsContext);
				return _factory.IdentifierExpr(identifier, genericTypeArguments);
			}
			
			public override GreenNode VisitQualifierExpr(CoreParser.QualifierExprContext context)
			{
				if (context == null) return QualifierExprGreen.__Missing;
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				CoreParser.DotOperatorContext dotOperatorContext = context.dotOperator();
				DotOperatorGreen dotOperator = null;
				if (dotOperatorContext != null) dotOperator = (DotOperatorGreen)this.Visit(dotOperatorContext);
				if (dotOperator == null) dotOperator = DotOperatorGreen.__Missing;
				CoreParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				CoreParser.GenericTypeArgumentsContext genericTypeArgumentsContext = context.genericTypeArguments();
				GenericTypeArgumentsGreen genericTypeArguments = null;
				if (genericTypeArgumentsContext != null) genericTypeArguments = (GenericTypeArgumentsGreen)this.Visit(genericTypeArgumentsContext);
				return _factory.QualifierExpr(expression, dotOperator, identifier, genericTypeArguments);
			}
			
			public override GreenNode VisitIndexerExpr(CoreParser.IndexerExprContext context)
			{
				if (context == null) return IndexerExprGreen.__Missing;
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				CoreParser.IndexerOperatorContext indexerOperatorContext = context.indexerOperator();
				IndexerOperatorGreen indexerOperator = null;
				if (indexerOperatorContext != null) indexerOperator = (IndexerOperatorGreen)this.Visit(indexerOperatorContext);
				if (indexerOperator == null) indexerOperator = IndexerOperatorGreen.__Missing;
				CoreParser.ArgumentListContext argumentListContext = context.argumentList();
				ArgumentListGreen argumentList = null;
				if (argumentListContext != null) argumentList = (ArgumentListGreen)this.Visit(argumentListContext);
				if (argumentList == null) argumentList = ArgumentListGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), CoreSyntaxKind.TCloseBracket);
				return _factory.IndexerExpr(expression, indexerOperator, argumentList, tCloseBracket);
			}
			
			public override GreenNode VisitInvocationExpr(CoreParser.InvocationExprContext context)
			{
				if (context == null) return InvocationExprGreen.__Missing;
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
				CoreParser.ArgumentListContext argumentListContext = context.argumentList();
				ArgumentListGreen argumentList = null;
				if (argumentListContext != null) argumentList = (ArgumentListGreen)this.Visit(argumentListContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				return _factory.InvocationExpr(expression, tOpenParen, argumentList, tCloseParen);
			}
			
			public override GreenNode VisitTypeofExpr(CoreParser.TypeofExprContext context)
			{
				if (context == null) return TypeofExprGreen.__Missing;
				InternalSyntaxToken kTypeof = (InternalSyntaxToken)this.VisitTerminal(context.KTypeof(), CoreSyntaxKind.KTypeof);
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				return _factory.TypeofExpr(kTypeof, tOpenParen, typeReference, tCloseParen);
			}
			
			public override GreenNode VisitNameofExpr(CoreParser.NameofExprContext context)
			{
				if (context == null) return NameofExprGreen.__Missing;
				InternalSyntaxToken kNameof = (InternalSyntaxToken)this.VisitTerminal(context.KNameof(), CoreSyntaxKind.KNameof);
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				return _factory.NameofExpr(kNameof, tOpenParen, expression, tCloseParen);
			}
			
			public override GreenNode VisitSizeofExpr(CoreParser.SizeofExprContext context)
			{
				if (context == null) return SizeofExprGreen.__Missing;
				InternalSyntaxToken kSizeof = (InternalSyntaxToken)this.VisitTerminal(context.KSizeof(), CoreSyntaxKind.KSizeof);
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				return _factory.SizeofExpr(kSizeof, tOpenParen, typeReference, tCloseParen);
			}
			
			public override GreenNode VisitCheckedExpr(CoreParser.CheckedExprContext context)
			{
				if (context == null) return CheckedExprGreen.__Missing;
				InternalSyntaxToken kChecked = (InternalSyntaxToken)this.VisitTerminal(context.KChecked(), CoreSyntaxKind.KChecked);
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				return _factory.CheckedExpr(kChecked, tOpenParen, expression, tCloseParen);
			}
			
			public override GreenNode VisitUncheckedExpr(CoreParser.UncheckedExprContext context)
			{
				if (context == null) return UncheckedExprGreen.__Missing;
				InternalSyntaxToken kUnchecked = (InternalSyntaxToken)this.VisitTerminal(context.KUnchecked(), CoreSyntaxKind.KUnchecked);
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				return _factory.UncheckedExpr(kUnchecked, tOpenParen, expression, tCloseParen);
			}
			
			public override GreenNode VisitNewExpr(CoreParser.NewExprContext context)
			{
				if (context == null) return NewExprGreen.__Missing;
				InternalSyntaxToken kNew = (InternalSyntaxToken)this.VisitTerminal(context.KNew(), CoreSyntaxKind.KNew);
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
				CoreParser.ArgumentListContext argumentListContext = context.argumentList();
				ArgumentListGreen argumentList = null;
				if (argumentListContext != null) argumentList = (ArgumentListGreen)this.Visit(argumentListContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				CoreParser.InitializerExpressionContext initializerExpressionContext = context.initializerExpression();
				InitializerExpressionGreen initializerExpression = null;
				if (initializerExpressionContext != null) initializerExpression = (InitializerExpressionGreen)this.Visit(initializerExpressionContext);
				return _factory.NewExpr(kNew, typeReference, tOpenParen, argumentList, tCloseParen, initializerExpression);
			}
			
			public override GreenNode VisitPostfixUnaryExpr(CoreParser.PostfixUnaryExprContext context)
			{
				if (context == null) return PostfixUnaryExprGreen.__Missing;
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				CoreParser.PostfixOperatorContext postfixOperatorContext = context.postfixOperator();
				PostfixOperatorGreen postfixOperator = null;
				if (postfixOperatorContext != null) postfixOperator = (PostfixOperatorGreen)this.Visit(postfixOperatorContext);
				if (postfixOperator == null) postfixOperator = PostfixOperatorGreen.__Missing;
				return _factory.PostfixUnaryExpr(expression, postfixOperator);
			}
			
			public override GreenNode VisitUnaryExpr(CoreParser.UnaryExprContext context)
			{
				if (context == null) return UnaryExprGreen.__Missing;
				CoreParser.UnaryOperatorContext unaryOperatorContext = context.unaryOperator();
				UnaryOperatorGreen unaryOperator = null;
				if (unaryOperatorContext != null) unaryOperator = (UnaryOperatorGreen)this.Visit(unaryOperatorContext);
				if (unaryOperator == null) unaryOperator = UnaryOperatorGreen.__Missing;
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.UnaryExpr(unaryOperator, expression);
			}
			
			public override GreenNode VisitTypeCastExpr(CoreParser.TypeCastExprContext context)
			{
				if (context == null) return TypeCastExprGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.TypeCastExpr(tOpenParen, typeReference, tCloseParen, expression);
			}
			
			public override GreenNode VisitMultExpr(CoreParser.MultExprContext context)
			{
				if (context == null) return MultExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				CoreParser.MultiplicativeOperatorContext multiplicativeOperatorContext = context.multiplicativeOperator();
				MultiplicativeOperatorGreen multiplicativeOperator = null;
				if (multiplicativeOperatorContext != null) multiplicativeOperator = (MultiplicativeOperatorGreen)this.Visit(multiplicativeOperatorContext);
				if (multiplicativeOperator == null) multiplicativeOperator = MultiplicativeOperatorGreen.__Missing;
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.MultExpr(left, multiplicativeOperator, right);
			}
			
			public override GreenNode VisitAddExpr(CoreParser.AddExprContext context)
			{
				if (context == null) return AddExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				CoreParser.AdditiveOperatorContext additiveOperatorContext = context.additiveOperator();
				AdditiveOperatorGreen additiveOperator = null;
				if (additiveOperatorContext != null) additiveOperator = (AdditiveOperatorGreen)this.Visit(additiveOperatorContext);
				if (additiveOperator == null) additiveOperator = AdditiveOperatorGreen.__Missing;
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.AddExpr(left, additiveOperator, right);
			}
			
			public override GreenNode VisitShiftExpr(CoreParser.ShiftExprContext context)
			{
				if (context == null) return ShiftExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				CoreParser.ShiftOperatorContext shiftOperatorContext = context.shiftOperator();
				ShiftOperatorGreen shiftOperator = null;
				if (shiftOperatorContext != null) shiftOperator = (ShiftOperatorGreen)this.Visit(shiftOperatorContext);
				if (shiftOperator == null) shiftOperator = ShiftOperatorGreen.__Missing;
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.ShiftExpr(left, shiftOperator, right);
			}
			
			public override GreenNode VisitRelExpr(CoreParser.RelExprContext context)
			{
				if (context == null) return RelExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				CoreParser.RelationalOperatorContext relationalOperatorContext = context.relationalOperator();
				RelationalOperatorGreen relationalOperator = null;
				if (relationalOperatorContext != null) relationalOperator = (RelationalOperatorGreen)this.Visit(relationalOperatorContext);
				if (relationalOperator == null) relationalOperator = RelationalOperatorGreen.__Missing;
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.RelExpr(left, relationalOperator, right);
			}
			
			public override GreenNode VisitTypeIsExpr(CoreParser.TypeIsExprContext context)
			{
				if (context == null) return TypeIsExprGreen.__Missing;
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken kIs = (InternalSyntaxToken)this.VisitTerminal(context.KIs(), CoreSyntaxKind.KIs);
				InternalSyntaxToken kNot = (InternalSyntaxToken)this.VisitTerminal(context.KNot());
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				return _factory.TypeIsExpr(expression, kIs, kNot, typeReference);
			}
			
			public override GreenNode VisitTypeAsExpr(CoreParser.TypeAsExprContext context)
			{
				if (context == null) return TypeAsExprGreen.__Missing;
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken kAs = (InternalSyntaxToken)this.VisitTerminal(context.KAs(), CoreSyntaxKind.KAs);
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				return _factory.TypeAsExpr(expression, kAs, typeReference);
			}
			
			public override GreenNode VisitEqExpr(CoreParser.EqExprContext context)
			{
				if (context == null) return EqExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				CoreParser.EqualityOperatorContext equalityOperatorContext = context.equalityOperator();
				EqualityOperatorGreen equalityOperator = null;
				if (equalityOperatorContext != null) equalityOperator = (EqualityOperatorGreen)this.Visit(equalityOperatorContext);
				if (equalityOperator == null) equalityOperator = EqualityOperatorGreen.__Missing;
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.EqExpr(left, equalityOperator, right);
			}
			
			public override GreenNode VisitAndExpr(CoreParser.AndExprContext context)
			{
				if (context == null) return AndExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tAmpersand = (InternalSyntaxToken)this.VisitTerminal(context.TAmpersand(), CoreSyntaxKind.TAmpersand);
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.AndExpr(left, tAmpersand, right);
			}
			
			public override GreenNode VisitXorExpr(CoreParser.XorExprContext context)
			{
				if (context == null) return XorExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tHat = (InternalSyntaxToken)this.VisitTerminal(context.THat(), CoreSyntaxKind.THat);
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.XorExpr(left, tHat, right);
			}
			
			public override GreenNode VisitOrExpr(CoreParser.OrExprContext context)
			{
				if (context == null) return OrExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tBar = (InternalSyntaxToken)this.VisitTerminal(context.TBar(), CoreSyntaxKind.TBar);
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.OrExpr(left, tBar, right);
			}
			
			public override GreenNode VisitAndAlsoExpr(CoreParser.AndAlsoExprContext context)
			{
				if (context == null) return AndAlsoExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tAndAlso = (InternalSyntaxToken)this.VisitTerminal(context.TAndAlso(), CoreSyntaxKind.TAndAlso);
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.AndAlsoExpr(left, tAndAlso, right);
			}
			
			public override GreenNode VisitOrElseExpr(CoreParser.OrElseExprContext context)
			{
				if (context == null) return OrElseExprGreen.__Missing;
				CoreParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tOrElse = (InternalSyntaxToken)this.VisitTerminal(context.TOrElse(), CoreSyntaxKind.TOrElse);
				CoreParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.OrElseExpr(left, tOrElse, right);
			}
			
			public override GreenNode VisitCoalExpr(CoreParser.CoalExprContext context)
			{
				if (context == null) return CoalExprGreen.__Missing;
				CoreParser.ExpressionContext valueContext = context.value;
				ExpressionGreen value = null;
				if (valueContext != null) value = (ExpressionGreen)this.Visit(valueContext);
				if (value == null) value = ExpressionGreen.__Missing;
				InternalSyntaxToken tQuestionQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestionQuestion(), CoreSyntaxKind.TQuestionQuestion);
				CoreParser.ExpressionContext whenNullContext = context.whenNull;
				ExpressionGreen whenNull = null;
				if (whenNullContext != null) whenNull = (ExpressionGreen)this.Visit(whenNullContext);
				if (whenNull == null) whenNull = ExpressionGreen.__Missing;
				return _factory.CoalExpr(value, tQuestionQuestion, whenNull);
			}
			
			public override GreenNode VisitCondExpr(CoreParser.CondExprContext context)
			{
				if (context == null) return CondExprGreen.__Missing;
				CoreParser.ExpressionContext conditionContext = context.condition;
				ExpressionGreen condition = null;
				if (conditionContext != null) condition = (ExpressionGreen)this.Visit(conditionContext);
				if (condition == null) condition = ExpressionGreen.__Missing;
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion(), CoreSyntaxKind.TQuestion);
				CoreParser.ExpressionContext whenTrueContext = context.whenTrue;
				ExpressionGreen whenTrue = null;
				if (whenTrueContext != null) whenTrue = (ExpressionGreen)this.Visit(whenTrueContext);
				if (whenTrue == null) whenTrue = ExpressionGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), CoreSyntaxKind.TColon);
				CoreParser.ExpressionContext whenFalseContext = context.whenFalse;
				ExpressionGreen whenFalse = null;
				if (whenFalseContext != null) whenFalse = (ExpressionGreen)this.Visit(whenFalseContext);
				if (whenFalse == null) whenFalse = ExpressionGreen.__Missing;
				return _factory.CondExpr(condition, tQuestion, whenTrue, tColon, whenFalse);
			}
			
			public override GreenNode VisitAssignExpr(CoreParser.AssignExprContext context)
			{
				if (context == null) return AssignExprGreen.__Missing;
				CoreParser.ExpressionContext targetContext = context.target;
				ExpressionGreen target = null;
				if (targetContext != null) target = (ExpressionGreen)this.Visit(targetContext);
				if (target == null) target = ExpressionGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), CoreSyntaxKind.TAssign);
				CoreParser.ExpressionContext valueContext = context.value;
				ExpressionGreen value = null;
				if (valueContext != null) value = (ExpressionGreen)this.Visit(valueContext);
				if (value == null) value = ExpressionGreen.__Missing;
				return _factory.AssignExpr(target, tAssign, value);
			}
			
			public override GreenNode VisitCompAssignExpr(CoreParser.CompAssignExprContext context)
			{
				if (context == null) return CompAssignExprGreen.__Missing;
				CoreParser.ExpressionContext targetContext = context.target;
				ExpressionGreen target = null;
				if (targetContext != null) target = (ExpressionGreen)this.Visit(targetContext);
				if (target == null) target = ExpressionGreen.__Missing;
				CoreParser.CompoundAssignmentOperatorContext compoundAssignmentOperatorContext = context.compoundAssignmentOperator();
				CompoundAssignmentOperatorGreen compoundAssignmentOperator = null;
				if (compoundAssignmentOperatorContext != null) compoundAssignmentOperator = (CompoundAssignmentOperatorGreen)this.Visit(compoundAssignmentOperatorContext);
				if (compoundAssignmentOperator == null) compoundAssignmentOperator = CompoundAssignmentOperatorGreen.__Missing;
				CoreParser.ExpressionContext valueContext = context.value;
				ExpressionGreen value = null;
				if (valueContext != null) value = (ExpressionGreen)this.Visit(valueContext);
				if (value == null) value = ExpressionGreen.__Missing;
				return _factory.CompAssignExpr(target, compoundAssignmentOperator, value);
			}
			
			public override GreenNode VisitLambdaExpr(CoreParser.LambdaExprContext context)
			{
				if (context == null) return LambdaExprGreen.__Missing;
				CoreParser.LambdaSignatureContext lambdaSignatureContext = context.lambdaSignature();
				LambdaSignatureGreen lambdaSignature = null;
				if (lambdaSignatureContext != null) lambdaSignature = (LambdaSignatureGreen)this.Visit(lambdaSignatureContext);
				if (lambdaSignature == null) lambdaSignature = LambdaSignatureGreen.__Missing;
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), CoreSyntaxKind.TArrow);
				CoreParser.LambdaBodyContext lambdaBodyContext = context.lambdaBody();
				LambdaBodyGreen lambdaBody = null;
				if (lambdaBodyContext != null) lambdaBody = (LambdaBodyGreen)this.Visit(lambdaBodyContext);
				if (lambdaBody == null) lambdaBody = LambdaBodyGreen.__Missing;
				return _factory.LambdaExpr(lambdaSignature, tArrow, lambdaBody);
			}
			
			public override GreenNode VisitArgumentList(CoreParser.ArgumentListContext context)
			{
				if (context == null) return ArgumentListGreen.__Missing;
			    CoreParser.ArgumentExpressionContext[] argumentExpressionContext = context.argumentExpression();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var argumentExpressionBuilder = _pool.AllocateSeparated<ArgumentExpressionGreen>();
			    for (int i = 0; i < argumentExpressionContext.Length; i++)
			    {
			        argumentExpressionBuilder.Add((ArgumentExpressionGreen)this.Visit(argumentExpressionContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            argumentExpressionBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], CoreSyntaxKind.TComma));
			        }
			    }
				var argumentExpression = argumentExpressionBuilder.ToList();
				_pool.Free(argumentExpressionBuilder);
				return _factory.ArgumentList(argumentExpression);
			}
			
			public override GreenNode VisitArgumentExpression(CoreParser.ArgumentExpressionContext context)
			{
				if (context == null) return ArgumentExpressionGreen.__Missing;
				CoreParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.ArgumentExpression(name, tColon, expression);
			}
			
			public override GreenNode VisitInitializerExpression(CoreParser.InitializerExpressionContext context)
			{
				if (context == null) return InitializerExpressionGreen.__Missing;
				CoreParser.FieldInitializerExpressionsContext fieldInitializerExpressionsContext = context.fieldInitializerExpressions();
				if (fieldInitializerExpressionsContext != null) 
				{
					return _factory.InitializerExpression((FieldInitializerExpressionsGreen)this.Visit(fieldInitializerExpressionsContext));
				}
				CoreParser.CollectionInitializerExpressionsContext collectionInitializerExpressionsContext = context.collectionInitializerExpressions();
				if (collectionInitializerExpressionsContext != null) 
				{
					return _factory.InitializerExpression((CollectionInitializerExpressionsGreen)this.Visit(collectionInitializerExpressionsContext));
				}
				CoreParser.DictionaryInitializerExpressionsContext dictionaryInitializerExpressionsContext = context.dictionaryInitializerExpressions();
				if (dictionaryInitializerExpressionsContext != null) 
				{
					return _factory.InitializerExpression((DictionaryInitializerExpressionsGreen)this.Visit(dictionaryInitializerExpressionsContext));
				}
				return InitializerExpressionGreen.__Missing;
			}
			
			public override GreenNode VisitFieldInitializerExpressions(CoreParser.FieldInitializerExpressionsContext context)
			{
				if (context == null) return FieldInitializerExpressionsGreen.__Missing;
			    CoreParser.FieldInitializerExpressionContext[] fieldInitializerExpressionContext = context.fieldInitializerExpression();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var fieldInitializerExpressionBuilder = _pool.AllocateSeparated<FieldInitializerExpressionGreen>();
			    for (int i = 0; i < fieldInitializerExpressionContext.Length; i++)
			    {
			        fieldInitializerExpressionBuilder.Add((FieldInitializerExpressionGreen)this.Visit(fieldInitializerExpressionContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            fieldInitializerExpressionBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], CoreSyntaxKind.TComma));
			        }
			    }
				var fieldInitializerExpression = fieldInitializerExpressionBuilder.ToList();
				_pool.Free(fieldInitializerExpressionBuilder);
				return _factory.FieldInitializerExpressions(fieldInitializerExpression);
			}
			
			public override GreenNode VisitFieldInitializerExpression(CoreParser.FieldInitializerExpressionContext context)
			{
				if (context == null) return FieldInitializerExpressionGreen.__Missing;
				CoreParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), CoreSyntaxKind.TAssign);
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.FieldInitializerExpression(identifier, tAssign, expression);
			}
			
			public override GreenNode VisitCollectionInitializerExpressions(CoreParser.CollectionInitializerExpressionsContext context)
			{
				if (context == null) return CollectionInitializerExpressionsGreen.__Missing;
			    CoreParser.ExpressionContext[] expressionContext = context.expression();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var expressionBuilder = _pool.AllocateSeparated<ExpressionGreen>();
			    for (int i = 0; i < expressionContext.Length; i++)
			    {
			        expressionBuilder.Add((ExpressionGreen)this.Visit(expressionContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            expressionBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], CoreSyntaxKind.TComma));
			        }
			    }
				var expression = expressionBuilder.ToList();
				_pool.Free(expressionBuilder);
				return _factory.CollectionInitializerExpressions(expression);
			}
			
			public override GreenNode VisitDictionaryInitializerExpressions(CoreParser.DictionaryInitializerExpressionsContext context)
			{
				if (context == null) return DictionaryInitializerExpressionsGreen.__Missing;
			    CoreParser.DictionaryInitializerExpressionContext[] dictionaryInitializerExpressionContext = context.dictionaryInitializerExpression();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var dictionaryInitializerExpressionBuilder = _pool.AllocateSeparated<DictionaryInitializerExpressionGreen>();
			    for (int i = 0; i < dictionaryInitializerExpressionContext.Length; i++)
			    {
			        dictionaryInitializerExpressionBuilder.Add((DictionaryInitializerExpressionGreen)this.Visit(dictionaryInitializerExpressionContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            dictionaryInitializerExpressionBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], CoreSyntaxKind.TComma));
			        }
			    }
				var dictionaryInitializerExpression = dictionaryInitializerExpressionBuilder.ToList();
				_pool.Free(dictionaryInitializerExpressionBuilder);
				return _factory.DictionaryInitializerExpressions(dictionaryInitializerExpression);
			}
			
			public override GreenNode VisitDictionaryInitializerExpression(CoreParser.DictionaryInitializerExpressionContext context)
			{
				if (context == null) return DictionaryInitializerExpressionGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), CoreSyntaxKind.TOpenBracket);
				CoreParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), CoreSyntaxKind.TCloseBracket);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), CoreSyntaxKind.TAssign);
				CoreParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.DictionaryInitializerExpression(tOpenBracket, identifier, tCloseBracket, tAssign, expression);
			}
			
			public override GreenNode VisitLambdaSignature(CoreParser.LambdaSignatureContext context)
			{
				if (context == null) return LambdaSignatureGreen.__Missing;
				CoreParser.ImplicitLambdaSignatureContext implicitLambdaSignatureContext = context.implicitLambdaSignature();
				if (implicitLambdaSignatureContext != null) 
				{
					return _factory.LambdaSignature((ImplicitLambdaSignatureGreen)this.Visit(implicitLambdaSignatureContext));
				}
				CoreParser.ExplicitLambdaSignatureContext explicitLambdaSignatureContext = context.explicitLambdaSignature();
				if (explicitLambdaSignatureContext != null) 
				{
					return _factory.LambdaSignature((ExplicitLambdaSignatureGreen)this.Visit(explicitLambdaSignatureContext));
				}
				return LambdaSignatureGreen.__Missing;
			}
			
			public override GreenNode VisitImplicitLambdaSignature(CoreParser.ImplicitLambdaSignatureContext context)
			{
				if (context == null) return ImplicitLambdaSignatureGreen.__Missing;
				CoreParser.ImplicitParameterContext implicitParameterContext = context.implicitParameter();
				if (implicitParameterContext != null) 
				{
					return _factory.ImplicitLambdaSignature((ImplicitParameterGreen)this.Visit(implicitParameterContext));
				}
				CoreParser.ImplicitParameterListContext implicitParameterListContext = context.implicitParameterList();
				if (implicitParameterListContext != null) 
				{
					return _factory.ImplicitLambdaSignature((ImplicitParameterListGreen)this.Visit(implicitParameterListContext));
				}
				return ImplicitLambdaSignatureGreen.__Missing;
			}
			
			public override GreenNode VisitImplicitParameterList(CoreParser.ImplicitParameterListContext context)
			{
				if (context == null) return ImplicitParameterListGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
			    CoreParser.ImplicitParameterContext[] implicitParameterContext = context.implicitParameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var implicitParameterBuilder = _pool.AllocateSeparated<ImplicitParameterGreen>();
			    for (int i = 0; i < implicitParameterContext.Length; i++)
			    {
			        implicitParameterBuilder.Add((ImplicitParameterGreen)this.Visit(implicitParameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            implicitParameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], CoreSyntaxKind.TComma));
			        }
			    }
				var implicitParameter = implicitParameterBuilder.ToList();
				_pool.Free(implicitParameterBuilder);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				return _factory.ImplicitParameterList(tOpenParen, implicitParameter, tCloseParen);
			}
			
			public override GreenNode VisitImplicitParameter(CoreParser.ImplicitParameterContext context)
			{
				if (context == null) return ImplicitParameterGreen.__Missing;
				CoreParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.ImplicitParameter(name);
			}
			
			public override GreenNode VisitExplicitLambdaSignature(CoreParser.ExplicitLambdaSignatureContext context)
			{
				if (context == null) return ExplicitLambdaSignatureGreen.__Missing;
				CoreParser.ExplicitParameterListContext explicitParameterListContext = context.explicitParameterList();
				ExplicitParameterListGreen explicitParameterList = null;
				if (explicitParameterListContext != null) explicitParameterList = (ExplicitParameterListGreen)this.Visit(explicitParameterListContext);
				if (explicitParameterList == null) explicitParameterList = ExplicitParameterListGreen.__Missing;
				return _factory.ExplicitLambdaSignature(explicitParameterList);
			}
			
			public override GreenNode VisitExplicitParameterList(CoreParser.ExplicitParameterListContext context)
			{
				if (context == null) return ExplicitParameterListGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), CoreSyntaxKind.TOpenParen);
			    CoreParser.ExplicitParameterContext[] explicitParameterContext = context.explicitParameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var explicitParameterBuilder = _pool.AllocateSeparated<ExplicitParameterGreen>();
			    for (int i = 0; i < explicitParameterContext.Length; i++)
			    {
			        explicitParameterBuilder.Add((ExplicitParameterGreen)this.Visit(explicitParameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            explicitParameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], CoreSyntaxKind.TComma));
			        }
			    }
				var explicitParameter = explicitParameterBuilder.ToList();
				_pool.Free(explicitParameterBuilder);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), CoreSyntaxKind.TCloseParen);
				return _factory.ExplicitParameterList(tOpenParen, explicitParameter, tCloseParen);
			}
			
			public override GreenNode VisitExplicitParameter(CoreParser.ExplicitParameterContext context)
			{
				if (context == null) return ExplicitParameterGreen.__Missing;
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				CoreParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.ExplicitParameter(typeReference, name);
			}
			
			public override GreenNode VisitLambdaBody(CoreParser.LambdaBodyContext context)
			{
				if (context == null) return LambdaBodyGreen.__Missing;
				CoreParser.ExpressionContext expressionContext = context.expression();
				if (expressionContext != null) 
				{
					return _factory.LambdaBody((ExpressionGreen)this.Visit(expressionContext));
				}
				CoreParser.BlockStatementContext blockStatementContext = context.blockStatement();
				if (blockStatementContext != null) 
				{
					return _factory.LambdaBody((BlockStatementGreen)this.Visit(blockStatementContext));
				}
				return LambdaBodyGreen.__Missing;
			}
			
			public override GreenNode VisitDotOperator(CoreParser.DotOperatorContext context)
			{
				if (context == null) return DotOperatorGreen.__Missing;
				InternalSyntaxToken dotOperator = null;
				if (context.TDot() != null)
				{
					dotOperator = (InternalSyntaxToken)this.VisitTerminal(context.TDot());
				}
				else 	if (context.TQuestionDot() != null)
				{
					dotOperator = (InternalSyntaxToken)this.VisitTerminal(context.TQuestionDot());
				}
				else
				{
					dotOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.DotOperator(dotOperator);
			}
			
			public override GreenNode VisitIndexerOperator(CoreParser.IndexerOperatorContext context)
			{
				if (context == null) return IndexerOperatorGreen.__Missing;
				InternalSyntaxToken indexerOperator = null;
				if (context.TOpenBracket() != null)
				{
					indexerOperator = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket());
				}
				else 	if (context.TQuestionOpenBracket() != null)
				{
					indexerOperator = (InternalSyntaxToken)this.VisitTerminal(context.TQuestionOpenBracket());
				}
				else
				{
					indexerOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.IndexerOperator(indexerOperator);
			}
			
			public override GreenNode VisitPostfixOperator(CoreParser.PostfixOperatorContext context)
			{
				if (context == null) return PostfixOperatorGreen.__Missing;
				InternalSyntaxToken postfixOperator = null;
				if (context.TPlusPlus() != null)
				{
					postfixOperator = (InternalSyntaxToken)this.VisitTerminal(context.TPlusPlus());
				}
				else 	if (context.TMinusMinus() != null)
				{
					postfixOperator = (InternalSyntaxToken)this.VisitTerminal(context.TMinusMinus());
				}
				else 	if (context.TExclamation() != null)
				{
					postfixOperator = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				}
				else
				{
					postfixOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.PostfixOperator(postfixOperator);
			}
			
			public override GreenNode VisitUnaryOperator(CoreParser.UnaryOperatorContext context)
			{
				if (context == null) return UnaryOperatorGreen.__Missing;
				InternalSyntaxToken unaryOperator = null;
				if (context.TPlus() != null)
				{
					unaryOperator = (InternalSyntaxToken)this.VisitTerminal(context.TPlus());
				}
				else 	if (context.TMinus() != null)
				{
					unaryOperator = (InternalSyntaxToken)this.VisitTerminal(context.TMinus());
				}
				else 	if (context.TExclamation() != null)
				{
					unaryOperator = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				}
				else 	if (context.TTilde() != null)
				{
					unaryOperator = (InternalSyntaxToken)this.VisitTerminal(context.TTilde());
				}
				else 	if (context.TPlusPlus() != null)
				{
					unaryOperator = (InternalSyntaxToken)this.VisitTerminal(context.TPlusPlus());
				}
				else 	if (context.TMinusMinus() != null)
				{
					unaryOperator = (InternalSyntaxToken)this.VisitTerminal(context.TMinusMinus());
				}
				else 	if (context.THat() != null)
				{
					unaryOperator = (InternalSyntaxToken)this.VisitTerminal(context.THat());
				}
				else
				{
					unaryOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.UnaryOperator(unaryOperator);
			}
			
			public override GreenNode VisitMultiplicativeOperator(CoreParser.MultiplicativeOperatorContext context)
			{
				if (context == null) return MultiplicativeOperatorGreen.__Missing;
				InternalSyntaxToken multiplicativeOperator = null;
				if (context.TAsterisk() != null)
				{
					multiplicativeOperator = (InternalSyntaxToken)this.VisitTerminal(context.TAsterisk());
				}
				else 	if (context.TSlash() != null)
				{
					multiplicativeOperator = (InternalSyntaxToken)this.VisitTerminal(context.TSlash());
				}
				else 	if (context.TPercent() != null)
				{
					multiplicativeOperator = (InternalSyntaxToken)this.VisitTerminal(context.TPercent());
				}
				else
				{
					multiplicativeOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.MultiplicativeOperator(multiplicativeOperator);
			}
			
			public override GreenNode VisitAdditiveOperator(CoreParser.AdditiveOperatorContext context)
			{
				if (context == null) return AdditiveOperatorGreen.__Missing;
				InternalSyntaxToken additiveOperator = null;
				if (context.TPlus() != null)
				{
					additiveOperator = (InternalSyntaxToken)this.VisitTerminal(context.TPlus());
				}
				else 	if (context.TMinus() != null)
				{
					additiveOperator = (InternalSyntaxToken)this.VisitTerminal(context.TMinus());
				}
				else
				{
					additiveOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.AdditiveOperator(additiveOperator);
			}
			
			public override GreenNode VisitShiftOperator(CoreParser.ShiftOperatorContext context)
			{
				if (context == null) return ShiftOperatorGreen.__Missing;
				CoreParser.LeftShiftOperatorContext leftShiftOperatorContext = context.leftShiftOperator();
				if (leftShiftOperatorContext != null) 
				{
					return _factory.ShiftOperator((LeftShiftOperatorGreen)this.Visit(leftShiftOperatorContext));
				}
				CoreParser.RightShiftOperatorContext rightShiftOperatorContext = context.rightShiftOperator();
				if (rightShiftOperatorContext != null) 
				{
					return _factory.ShiftOperator((RightShiftOperatorGreen)this.Visit(rightShiftOperatorContext));
				}
				return ShiftOperatorGreen.__Missing;
			}
			
			public override GreenNode VisitLeftShiftOperator(CoreParser.LeftShiftOperatorContext context)
			{
				if (context == null) return LeftShiftOperatorGreen.__Missing;
				InternalSyntaxToken first = (InternalSyntaxToken)this.VisitTerminal(context.first, CoreSyntaxKind.TLessThan);
				InternalSyntaxToken second = (InternalSyntaxToken)this.VisitTerminal(context.second, CoreSyntaxKind.TLessThan);
				return _factory.LeftShiftOperator(first, second);
			}
			
			public override GreenNode VisitRightShiftOperator(CoreParser.RightShiftOperatorContext context)
			{
				if (context == null) return RightShiftOperatorGreen.__Missing;
				InternalSyntaxToken first = (InternalSyntaxToken)this.VisitTerminal(context.first, CoreSyntaxKind.TLessThan);
				InternalSyntaxToken second = (InternalSyntaxToken)this.VisitTerminal(context.second, CoreSyntaxKind.TLessThan);
				return _factory.RightShiftOperator(first, second);
			}
			
			public override GreenNode VisitRelationalOperator(CoreParser.RelationalOperatorContext context)
			{
				if (context == null) return RelationalOperatorGreen.__Missing;
				InternalSyntaxToken relationalOperator = null;
				if (context.TLessThan() != null)
				{
					relationalOperator = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan());
				}
				else 	if (context.TGreaterThan() != null)
				{
					relationalOperator = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan());
				}
				else 	if (context.TLessThanOrEqual() != null)
				{
					relationalOperator = (InternalSyntaxToken)this.VisitTerminal(context.TLessThanOrEqual());
				}
				else 	if (context.TGreaterThanOrEqual() != null)
				{
					relationalOperator = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThanOrEqual());
				}
				else
				{
					relationalOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.RelationalOperator(relationalOperator);
			}
			
			public override GreenNode VisitEqualityOperator(CoreParser.EqualityOperatorContext context)
			{
				if (context == null) return EqualityOperatorGreen.__Missing;
				InternalSyntaxToken equalityOperator = null;
				if (context.TEqual() != null)
				{
					equalityOperator = (InternalSyntaxToken)this.VisitTerminal(context.TEqual());
				}
				else 	if (context.TNotEqual() != null)
				{
					equalityOperator = (InternalSyntaxToken)this.VisitTerminal(context.TNotEqual());
				}
				else
				{
					equalityOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.EqualityOperator(equalityOperator);
			}
			
			public override GreenNode VisitCompoundAssignmentOperator(CoreParser.CompoundAssignmentOperatorContext context)
			{
				if (context == null) return CompoundAssignmentOperatorGreen.__Missing;
				InternalSyntaxToken compoundAssignmentOperator = null;
				if (context.TPlusAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.TPlusAssign());
				}
				else 	if (context.TMinusAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.TMinusAssign());
				}
				else 	if (context.TAsteriskAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.TAsteriskAssign());
				}
				else 	if (context.TSlashAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.TSlashAssign());
				}
				else 	if (context.TPercentAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.TPercentAssign());
				}
				else 	if (context.TAmpersandAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.TAmpersandAssign());
				}
				else 	if (context.THatAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.THatAssign());
				}
				else 	if (context.TBarAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.TBarAssign());
				}
				else 	if (context.TLeftShiftAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.TLeftShiftAssign());
				}
				else 	if (context.TRightShiftAssign() != null)
				{
					compoundAssignmentOperator = (InternalSyntaxToken)this.VisitTerminal(context.TRightShiftAssign());
				}
				else
				{
					compoundAssignmentOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.CompoundAssignmentOperator(compoundAssignmentOperator);
			}
			
			public override GreenNode VisitReturnType(CoreParser.ReturnTypeContext context)
			{
				if (context == null) return ReturnTypeGreen.__Missing;
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return _factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext));
				}
				CoreParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return _factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext));
				}
				return ReturnTypeGreen.__Missing;
			}
			
			public override GreenNode VisitPrimitiveTypeRef(CoreParser.PrimitiveTypeRefContext context)
			{
				if (context == null) return PrimitiveTypeRefGreen.__Missing;
				CoreParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				PrimitiveTypeGreen primitiveType = null;
				if (primitiveTypeContext != null) primitiveType = (PrimitiveTypeGreen)this.Visit(primitiveTypeContext);
				if (primitiveType == null) primitiveType = PrimitiveTypeGreen.__Missing;
				return _factory.PrimitiveTypeRef(primitiveType);
			}
			
			public override GreenNode VisitGenericTypeRef(CoreParser.GenericTypeRefContext context)
			{
				if (context == null) return GenericTypeRefGreen.__Missing;
				CoreParser.NamedTypeContext namedTypeContext = context.namedType();
				NamedTypeGreen namedType = null;
				if (namedTypeContext != null) namedType = (NamedTypeGreen)this.Visit(namedTypeContext);
				if (namedType == null) namedType = NamedTypeGreen.__Missing;
				CoreParser.GenericTypeArgumentsContext genericTypeArgumentsContext = context.genericTypeArguments();
				GenericTypeArgumentsGreen genericTypeArguments = null;
				if (genericTypeArgumentsContext != null) genericTypeArguments = (GenericTypeArgumentsGreen)this.Visit(genericTypeArgumentsContext);
				if (genericTypeArguments == null) genericTypeArguments = GenericTypeArgumentsGreen.__Missing;
				return _factory.GenericTypeRef(namedType, genericTypeArguments);
			}
			
			public override GreenNode VisitNamedTypeRef(CoreParser.NamedTypeRefContext context)
			{
				if (context == null) return NamedTypeRefGreen.__Missing;
				CoreParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.NamedTypeRef(qualifier);
			}
			
			public override GreenNode VisitArrayTypeRef(CoreParser.ArrayTypeRefContext context)
			{
				if (context == null) return ArrayTypeRefGreen.__Missing;
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), CoreSyntaxKind.TOpenBracket);
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), CoreSyntaxKind.TCloseBracket);
				return _factory.ArrayTypeRef(typeReference, tOpenBracket, tCloseBracket);
			}
			
			public override GreenNode VisitNullableTypeRef(CoreParser.NullableTypeRefContext context)
			{
				if (context == null) return NullableTypeRefGreen.__Missing;
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion(), CoreSyntaxKind.TQuestion);
				return _factory.NullableTypeRef(typeReference, tQuestion);
			}
			
			public override GreenNode VisitNamedType(CoreParser.NamedTypeContext context)
			{
				if (context == null) return NamedTypeGreen.__Missing;
				CoreParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.NamedType(qualifier);
			}
			
			public override GreenNode VisitGenericTypeArguments(CoreParser.GenericTypeArgumentsContext context)
			{
				if (context == null) return GenericTypeArgumentsGreen.__Missing;
				InternalSyntaxToken tLessThan = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan(), CoreSyntaxKind.TLessThan);
			    CoreParser.GenericTypeArgumentContext[] genericTypeArgumentContext = context.genericTypeArgument();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var genericTypeArgumentBuilder = _pool.AllocateSeparated<GenericTypeArgumentGreen>();
			    for (int i = 0; i < genericTypeArgumentContext.Length; i++)
			    {
			        genericTypeArgumentBuilder.Add((GenericTypeArgumentGreen)this.Visit(genericTypeArgumentContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            genericTypeArgumentBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], CoreSyntaxKind.TComma));
			        }
			    }
				var genericTypeArgument = genericTypeArgumentBuilder.ToList();
				_pool.Free(genericTypeArgumentBuilder);
				InternalSyntaxToken tGreaterThan = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan(), CoreSyntaxKind.TGreaterThan);
				return _factory.GenericTypeArguments(tLessThan, genericTypeArgument, tGreaterThan);
			}
			
			public override GreenNode VisitGenericTypeArgument(CoreParser.GenericTypeArgumentContext context)
			{
				if (context == null) return GenericTypeArgumentGreen.__Missing;
				CoreParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				return _factory.GenericTypeArgument(typeReference);
			}
			
			public override GreenNode VisitPrimitiveType(CoreParser.PrimitiveTypeContext context)
			{
				if (context == null) return PrimitiveTypeGreen.__Missing;
				InternalSyntaxToken primitiveType = null;
				if (context.KObject() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KObject());
				}
				else 	if (context.KBool() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KBool());
				}
				else 	if (context.KChar() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KChar());
				}
				else 	if (context.KSByte() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KSByte());
				}
				else 	if (context.KByte() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KByte());
				}
				else 	if (context.KShort() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KShort());
				}
				else 	if (context.KUShort() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KUShort());
				}
				else 	if (context.KInt() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KInt());
				}
				else 	if (context.KUInt() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KUInt());
				}
				else 	if (context.KLong() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KLong());
				}
				else 	if (context.KULong() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KULong());
				}
				else 	if (context.KDecimal() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KDecimal());
				}
				else 	if (context.KFloat() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KFloat());
				}
				else 	if (context.KDouble() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KDouble());
				}
				else 	if (context.KString() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KString());
				}
				else
				{
					primitiveType = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.PrimitiveType(primitiveType);
			}
			
			public override GreenNode VisitVoidType(CoreParser.VoidTypeContext context)
			{
				if (context == null) return VoidTypeGreen.__Missing;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid(), CoreSyntaxKind.KVoid);
				return _factory.VoidType(kVoid);
			}
			
			public override GreenNode VisitName(CoreParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				CoreParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.Name(identifier);
			}
			
			public override GreenNode VisitQualifiedName(CoreParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
				CoreParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.QualifiedName(qualifier);
			}
			
			public override GreenNode VisitQualifier(CoreParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    CoreParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], CoreSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitIdentifier(CoreParser.IdentifierContext context)
			{
				if (context == null) return IdentifierGreen.__Missing;
				InternalSyntaxToken identifier = null;
				if (context.IdentifierNormal() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierNormal());
				}
				else 	if (context.IdentifierVerbatim() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierVerbatim());
				}
				else
				{
					identifier = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.Identifier(identifier);
			}
			
			public override GreenNode VisitLiteral(CoreParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				CoreParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return _factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				CoreParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return _factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				CoreParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return _factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				CoreParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return _factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				CoreParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return _factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				CoreParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return _factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(CoreParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), CoreSyntaxKind.KNull);
				return _factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(CoreParser.BooleanLiteralContext context)
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
			
			public override GreenNode VisitIntegerLiteral(CoreParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), CoreSyntaxKind.LInteger);
				return _factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(CoreParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), CoreSyntaxKind.LDecimal);
				return _factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(CoreParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), CoreSyntaxKind.LScientific);
				return _factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(CoreParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken lRegularString = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString(), CoreSyntaxKind.LRegularString);
				return _factory.StringLiteral(lRegularString);
			}
        }
    }
    public partial class CoreParser
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
		
		internal class UsingNamespaceContext_Cached : UsingNamespaceContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public UsingNamespaceContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class StatementContext_Cached : StatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public StatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class BlockStatementContext_Cached : BlockStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public BlockStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ExpressionContext_Cached : ExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ArgumentListContext_Cached : ArgumentListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ArgumentListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ArgumentExpressionContext_Cached : ArgumentExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ArgumentExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class InitializerExpressionContext_Cached : InitializerExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public InitializerExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FieldInitializerExpressionsContext_Cached : FieldInitializerExpressionsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FieldInitializerExpressionsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FieldInitializerExpressionContext_Cached : FieldInitializerExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FieldInitializerExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CollectionInitializerExpressionsContext_Cached : CollectionInitializerExpressionsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CollectionInitializerExpressionsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DictionaryInitializerExpressionsContext_Cached : DictionaryInitializerExpressionsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DictionaryInitializerExpressionsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DictionaryInitializerExpressionContext_Cached : DictionaryInitializerExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DictionaryInitializerExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LambdaSignatureContext_Cached : LambdaSignatureContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LambdaSignatureContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ImplicitLambdaSignatureContext_Cached : ImplicitLambdaSignatureContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ImplicitLambdaSignatureContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ImplicitParameterListContext_Cached : ImplicitParameterListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ImplicitParameterListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ImplicitParameterContext_Cached : ImplicitParameterContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ImplicitParameterContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ExplicitLambdaSignatureContext_Cached : ExplicitLambdaSignatureContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ExplicitLambdaSignatureContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ExplicitParameterListContext_Cached : ExplicitParameterListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ExplicitParameterListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ExplicitParameterContext_Cached : ExplicitParameterContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ExplicitParameterContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LambdaBodyContext_Cached : LambdaBodyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LambdaBodyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DotOperatorContext_Cached : DotOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DotOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IndexerOperatorContext_Cached : IndexerOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IndexerOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class PostfixOperatorContext_Cached : PostfixOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PostfixOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class UnaryOperatorContext_Cached : UnaryOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public UnaryOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class MultiplicativeOperatorContext_Cached : MultiplicativeOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MultiplicativeOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AdditiveOperatorContext_Cached : AdditiveOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AdditiveOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ShiftOperatorContext_Cached : ShiftOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ShiftOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LeftShiftOperatorContext_Cached : LeftShiftOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LeftShiftOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RightShiftOperatorContext_Cached : RightShiftOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RightShiftOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RelationalOperatorContext_Cached : RelationalOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RelationalOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EqualityOperatorContext_Cached : EqualityOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EqualityOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CompoundAssignmentOperatorContext_Cached : CompoundAssignmentOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CompoundAssignmentOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ReturnTypeContext_Cached : ReturnTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ReturnTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypeReferenceContext_Cached : TypeReferenceContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypeReferenceContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamedTypeContext_Cached : NamedTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamedTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class GenericTypeArgumentsContext_Cached : GenericTypeArgumentsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GenericTypeArgumentsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class GenericTypeArgumentContext_Cached : GenericTypeArgumentContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GenericTypeArgumentContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class PrimitiveTypeContext_Cached : PrimitiveTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PrimitiveTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class VoidTypeContext_Cached : VoidTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public VoidTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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

