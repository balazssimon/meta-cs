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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax
{
    public class TestLexerModeSyntaxParser : Antlr4SyntaxParser
    {
        private readonly Antlr4ToRoslynVisitor _visitor;
        public TestLexerModeSyntaxParser(
            SourceText text,
            TestLexerModeParseOptions options,
            TestLexerModeSyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
            : base(TestLexerModeLanguage.Instance, text, options, oldTree, changes, cancellationToken)
        {
            _visitor = new Antlr4ToRoslynVisitor(this);
        }
        protected TestLexerModeParser Antlr4Parser => (TestLexerModeParser)this.Parser;
		public override LanguageSyntaxNode Parse()
		{
			BeginRoot();
            ParserState state = null;
			var green = this.ParseMain(ref state);
			EndRoot(ref green);
			var red = (TestLexerModeSyntaxNode)green.CreateRed();
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
		
		internal TestLexerModeParser.MainContext _Antlr4ParseMain()
		{
			BeginNode();
		    TestLexerModeParser.MainContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMain(CurrentNode as MainSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.MainContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseMain();
		            ((ITokenStream)this).Consume(); // Consume EOF, since ANTLR4 does not do that.
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestLexerModeParser.NamespaceDeclarationContext _Antlr4ParseNamespaceDeclaration()
		{
			BeginNode();
		    TestLexerModeParser.NamespaceDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration(CurrentNode as NamespaceDeclarationSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.NamespaceDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseGeneratorDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.generatorDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGeneratorDeclaration(GeneratorDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.GeneratorDeclarationContext _Antlr4ParseGeneratorDeclaration()
		{
			BeginNode();
		    TestLexerModeParser.GeneratorDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseGeneratorDeclaration(CurrentNode as GeneratorDeclarationSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.GeneratorDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseGeneratorDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestLexerModeParser.UsingDeclarationContext _Antlr4ParseUsingDeclaration()
		{
			BeginNode();
		    TestLexerModeParser.UsingDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseUsingDeclaration(CurrentNode as UsingDeclarationSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.UsingDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseConfigDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.configDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseConfigDeclaration(ConfigDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ConfigDeclarationContext _Antlr4ParseConfigDeclaration()
		{
			BeginNode();
		    TestLexerModeParser.ConfigDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseConfigDeclaration(CurrentNode as ConfigDeclarationSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ConfigDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseConfigDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseConfigProperty(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.configProperty();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseConfigProperty(ConfigPropertySyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ConfigPropertyContext _Antlr4ParseConfigProperty()
		{
			BeginNode();
		    TestLexerModeParser.ConfigPropertyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseConfigProperty(CurrentNode as ConfigPropertySyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ConfigPropertyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseConfigProperty();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseMethodDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.methodDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMethodDeclaration(MethodDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.MethodDeclarationContext _Antlr4ParseMethodDeclaration()
		{
			BeginNode();
		    TestLexerModeParser.MethodDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMethodDeclaration(CurrentNode as MethodDeclarationSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.MethodDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseMethodDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseExternFunctionDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.externFunctionDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseExternFunctionDeclaration(ExternFunctionDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ExternFunctionDeclarationContext _Antlr4ParseExternFunctionDeclaration()
		{
			BeginNode();
		    TestLexerModeParser.ExternFunctionDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseExternFunctionDeclaration(CurrentNode as ExternFunctionDeclarationSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ExternFunctionDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseExternFunctionDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseFunctionDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.functionDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFunctionDeclaration(FunctionDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.FunctionDeclarationContext _Antlr4ParseFunctionDeclaration()
		{
			BeginNode();
		    TestLexerModeParser.FunctionDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFunctionDeclaration(CurrentNode as FunctionDeclarationSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.FunctionDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseFunctionDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseFunctionSignature(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.functionSignature();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFunctionSignature(FunctionSignatureSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.FunctionSignatureContext _Antlr4ParseFunctionSignature()
		{
			BeginNode();
		    TestLexerModeParser.FunctionSignatureContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFunctionSignature(CurrentNode as FunctionSignatureSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.FunctionSignatureContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseFunctionSignature();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseParamList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.paramList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParamList(ParamListSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ParamListContext _Antlr4ParseParamList()
		{
			BeginNode();
		    TestLexerModeParser.ParamListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseParamList(CurrentNode as ParamListSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ParamListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseParamList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseParameter(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parameter();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParameter(ParameterSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ParameterContext _Antlr4ParseParameter()
		{
			BeginNode();
		    TestLexerModeParser.ParameterContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseParameter(CurrentNode as ParameterSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ParameterContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseParameter();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseBody(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.body();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseBody(BodySyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.BodyContext _Antlr4ParseBody()
		{
			BeginNode();
		    TestLexerModeParser.BodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseBody(CurrentNode as BodySyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.BodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseBody();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestLexerModeParser.StatementContext _Antlr4ParseStatement()
		{
			BeginNode();
		    TestLexerModeParser.StatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseStatement(CurrentNode as StatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.StatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSingleStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.singleStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSingleStatement(SingleStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SingleStatementContext _Antlr4ParseSingleStatement()
		{
			BeginNode();
		    TestLexerModeParser.SingleStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSingleStatement(CurrentNode as SingleStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SingleStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSingleStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSingleStatementSemicolon(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.singleStatementSemicolon();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSingleStatementSemicolon(SingleStatementSemicolonSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SingleStatementSemicolonContext _Antlr4ParseSingleStatementSemicolon()
		{
			BeginNode();
		    TestLexerModeParser.SingleStatementSemicolonContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSingleStatementSemicolon(CurrentNode as SingleStatementSemicolonSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SingleStatementSemicolonContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSingleStatementSemicolon();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseVariableDeclarationStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.variableDeclarationStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.VariableDeclarationStatementContext _Antlr4ParseVariableDeclarationStatement()
		{
			BeginNode();
		    TestLexerModeParser.VariableDeclarationStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVariableDeclarationStatement(CurrentNode as VariableDeclarationStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.VariableDeclarationStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVariableDeclarationStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseVariableDeclarationExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.variableDeclarationExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVariableDeclarationExpression(VariableDeclarationExpressionSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.VariableDeclarationExpressionContext _Antlr4ParseVariableDeclarationExpression()
		{
			BeginNode();
		    TestLexerModeParser.VariableDeclarationExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVariableDeclarationExpression(CurrentNode as VariableDeclarationExpressionSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.VariableDeclarationExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVariableDeclarationExpression();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseVariableDeclarationItem(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.variableDeclarationItem();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVariableDeclarationItem(VariableDeclarationItemSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.VariableDeclarationItemContext _Antlr4ParseVariableDeclarationItem()
		{
			BeginNode();
		    TestLexerModeParser.VariableDeclarationItemContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVariableDeclarationItem(CurrentNode as VariableDeclarationItemSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.VariableDeclarationItemContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVariableDeclarationItem();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseVoidStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.voidStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVoidStatement(VoidStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.VoidStatementContext _Antlr4ParseVoidStatement()
		{
			BeginNode();
		    TestLexerModeParser.VoidStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVoidStatement(CurrentNode as VoidStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.VoidStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVoidStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseReturnStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.returnStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseReturnStatement(ReturnStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ReturnStatementContext _Antlr4ParseReturnStatement()
		{
			BeginNode();
		    TestLexerModeParser.ReturnStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseReturnStatement(CurrentNode as ReturnStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ReturnStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseReturnStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseExpressionStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.expressionStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseExpressionStatement(ExpressionStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ExpressionStatementContext _Antlr4ParseExpressionStatement()
		{
			BeginNode();
		    TestLexerModeParser.ExpressionStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseExpressionStatement(CurrentNode as ExpressionStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ExpressionStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseExpressionStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseIfStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.ifStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIfStatement(IfStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.IfStatementContext _Antlr4ParseIfStatement()
		{
			BeginNode();
		    TestLexerModeParser.IfStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIfStatement(CurrentNode as IfStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.IfStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseIfStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseElseIfStatementBody(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.elseIfStatementBody();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseElseIfStatementBody(ElseIfStatementBodySyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ElseIfStatementBodyContext _Antlr4ParseElseIfStatementBody()
		{
			BeginNode();
		    TestLexerModeParser.ElseIfStatementBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseElseIfStatementBody(CurrentNode as ElseIfStatementBodySyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ElseIfStatementBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseElseIfStatementBody();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseIfStatementElseBody(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.ifStatementElseBody();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIfStatementElseBody(IfStatementElseBodySyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.IfStatementElseBodyContext _Antlr4ParseIfStatementElseBody()
		{
			BeginNode();
		    TestLexerModeParser.IfStatementElseBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIfStatementElseBody(CurrentNode as IfStatementElseBodySyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.IfStatementElseBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseIfStatementElseBody();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseIfStatementBegin(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.ifStatementBegin();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIfStatementBegin(IfStatementBeginSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.IfStatementBeginContext _Antlr4ParseIfStatementBegin()
		{
			BeginNode();
		    TestLexerModeParser.IfStatementBeginContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIfStatementBegin(CurrentNode as IfStatementBeginSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.IfStatementBeginContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseIfStatementBegin();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseElseIfStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.elseIfStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseElseIfStatement(ElseIfStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ElseIfStatementContext _Antlr4ParseElseIfStatement()
		{
			BeginNode();
		    TestLexerModeParser.ElseIfStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseElseIfStatement(CurrentNode as ElseIfStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ElseIfStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseElseIfStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseIfStatementElse(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.ifStatementElse();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIfStatementElse(IfStatementElseSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.IfStatementElseContext _Antlr4ParseIfStatementElse()
		{
			BeginNode();
		    TestLexerModeParser.IfStatementElseContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIfStatementElse(CurrentNode as IfStatementElseSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.IfStatementElseContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseIfStatementElse();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseIfStatementEnd(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.ifStatementEnd();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIfStatementEnd(IfStatementEndSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.IfStatementEndContext _Antlr4ParseIfStatementEnd()
		{
			BeginNode();
		    TestLexerModeParser.IfStatementEndContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIfStatementEnd(CurrentNode as IfStatementEndSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.IfStatementEndContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseIfStatementEnd();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseForStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.forStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseForStatement(ForStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ForStatementContext _Antlr4ParseForStatement()
		{
			BeginNode();
		    TestLexerModeParser.ForStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseForStatement(CurrentNode as ForStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ForStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseForStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseForStatementBegin(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.forStatementBegin();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseForStatementBegin(ForStatementBeginSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ForStatementBeginContext _Antlr4ParseForStatementBegin()
		{
			BeginNode();
		    TestLexerModeParser.ForStatementBeginContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseForStatementBegin(CurrentNode as ForStatementBeginSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ForStatementBeginContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseForStatementBegin();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseForStatementEnd(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.forStatementEnd();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseForStatementEnd(ForStatementEndSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ForStatementEndContext _Antlr4ParseForStatementEnd()
		{
			BeginNode();
		    TestLexerModeParser.ForStatementEndContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseForStatementEnd(CurrentNode as ForStatementEndSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ForStatementEndContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseForStatementEnd();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseForInitStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.forInitStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseForInitStatement(ForInitStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ForInitStatementContext _Antlr4ParseForInitStatement()
		{
			BeginNode();
		    TestLexerModeParser.ForInitStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseForInitStatement(CurrentNode as ForInitStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ForInitStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseForInitStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseWhileStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.whileStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseWhileStatement(WhileStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.WhileStatementContext _Antlr4ParseWhileStatement()
		{
			BeginNode();
		    TestLexerModeParser.WhileStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseWhileStatement(CurrentNode as WhileStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.WhileStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseWhileStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseWhileStatementBegin(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.whileStatementBegin();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseWhileStatementBegin(WhileStatementBeginSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.WhileStatementBeginContext _Antlr4ParseWhileStatementBegin()
		{
			BeginNode();
		    TestLexerModeParser.WhileStatementBeginContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseWhileStatementBegin(CurrentNode as WhileStatementBeginSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.WhileStatementBeginContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseWhileStatementBegin();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseWhileStatementEnd(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.whileStatementEnd();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseWhileStatementEnd(WhileStatementEndSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.WhileStatementEndContext _Antlr4ParseWhileStatementEnd()
		{
			BeginNode();
		    TestLexerModeParser.WhileStatementEndContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseWhileStatementEnd(CurrentNode as WhileStatementEndSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.WhileStatementEndContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseWhileStatementEnd();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseWhileRunExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.whileRunExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseWhileRunExpression(WhileRunExpressionSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.WhileRunExpressionContext _Antlr4ParseWhileRunExpression()
		{
			BeginNode();
		    TestLexerModeParser.WhileRunExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseWhileRunExpression(CurrentNode as WhileRunExpressionSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.WhileRunExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseWhileRunExpression();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseRepeatStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.repeatStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRepeatStatement(RepeatStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.RepeatStatementContext _Antlr4ParseRepeatStatement()
		{
			BeginNode();
		    TestLexerModeParser.RepeatStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRepeatStatement(CurrentNode as RepeatStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.RepeatStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseRepeatStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseRepeatStatementBegin(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.repeatStatementBegin();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRepeatStatementBegin(RepeatStatementBeginSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.RepeatStatementBeginContext _Antlr4ParseRepeatStatementBegin()
		{
			BeginNode();
		    TestLexerModeParser.RepeatStatementBeginContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRepeatStatementBegin(CurrentNode as RepeatStatementBeginSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.RepeatStatementBeginContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseRepeatStatementBegin();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseRepeatStatementEnd(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.repeatStatementEnd();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRepeatStatementEnd(RepeatStatementEndSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.RepeatStatementEndContext _Antlr4ParseRepeatStatementEnd()
		{
			BeginNode();
		    TestLexerModeParser.RepeatStatementEndContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRepeatStatementEnd(CurrentNode as RepeatStatementEndSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.RepeatStatementEndContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseRepeatStatementEnd();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseRepeatRunExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.repeatRunExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRepeatRunExpression(RepeatRunExpressionSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.RepeatRunExpressionContext _Antlr4ParseRepeatRunExpression()
		{
			BeginNode();
		    TestLexerModeParser.RepeatRunExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRepeatRunExpression(CurrentNode as RepeatRunExpressionSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.RepeatRunExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseRepeatRunExpression();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseLoopStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.loopStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLoopStatement(LoopStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.LoopStatementContext _Antlr4ParseLoopStatement()
		{
			BeginNode();
		    TestLexerModeParser.LoopStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLoopStatement(CurrentNode as LoopStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.LoopStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseLoopStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseLoopStatementBegin(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.loopStatementBegin();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLoopStatementBegin(LoopStatementBeginSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.LoopStatementBeginContext _Antlr4ParseLoopStatementBegin()
		{
			BeginNode();
		    TestLexerModeParser.LoopStatementBeginContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLoopStatementBegin(CurrentNode as LoopStatementBeginSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.LoopStatementBeginContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseLoopStatementBegin();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseLoopStatementEnd(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.loopStatementEnd();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLoopStatementEnd(LoopStatementEndSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.LoopStatementEndContext _Antlr4ParseLoopStatementEnd()
		{
			BeginNode();
		    TestLexerModeParser.LoopStatementEndContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLoopStatementEnd(CurrentNode as LoopStatementEndSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.LoopStatementEndContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseLoopStatementEnd();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseLoopChain(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.loopChain();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLoopChain(LoopChainSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.LoopChainContext _Antlr4ParseLoopChain()
		{
			BeginNode();
		    TestLexerModeParser.LoopChainContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLoopChain(CurrentNode as LoopChainSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.LoopChainContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseLoopChain();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseLoopChainItem(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.loopChainItem();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLoopChainItem(LoopChainItemSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.LoopChainItemContext _Antlr4ParseLoopChainItem()
		{
			BeginNode();
		    TestLexerModeParser.LoopChainItemContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLoopChainItem(CurrentNode as LoopChainItemSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.LoopChainItemContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseLoopChainItem();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseLoopChainExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.loopChainExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLoopChainExpression(LoopChainExpressionSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.LoopChainExpressionContext _Antlr4ParseLoopChainExpression(int precedence)
		{
			BeginNode();
		    TestLexerModeParser.LoopChainExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLoopChainExpression(CurrentNode as LoopChainExpressionSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.LoopChainExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseLoopChainExpression(precedence);
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseLoopWhereExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.loopWhereExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLoopWhereExpression(LoopWhereExpressionSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.LoopWhereExpressionContext _Antlr4ParseLoopWhereExpression()
		{
			BeginNode();
		    TestLexerModeParser.LoopWhereExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLoopWhereExpression(CurrentNode as LoopWhereExpressionSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.LoopWhereExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseLoopWhereExpression();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseLoopRunExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.loopRunExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLoopRunExpression(LoopRunExpressionSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.LoopRunExpressionContext _Antlr4ParseLoopRunExpression()
		{
			BeginNode();
		    TestLexerModeParser.LoopRunExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLoopRunExpression(CurrentNode as LoopRunExpressionSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.LoopRunExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseLoopRunExpression();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSeparatorStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.separatorStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSeparatorStatement(SeparatorStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SeparatorStatementContext _Antlr4ParseSeparatorStatement()
		{
			BeginNode();
		    TestLexerModeParser.SeparatorStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSeparatorStatement(CurrentNode as SeparatorStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SeparatorStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSeparatorStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchStatement(SwitchStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchStatementContext _Antlr4ParseSwitchStatement()
		{
			BeginNode();
		    TestLexerModeParser.SwitchStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchStatement(CurrentNode as SwitchStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchStatementBegin(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchStatementBegin();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchStatementBegin(SwitchStatementBeginSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchStatementBeginContext _Antlr4ParseSwitchStatementBegin()
		{
			BeginNode();
		    TestLexerModeParser.SwitchStatementBeginContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchStatementBegin(CurrentNode as SwitchStatementBeginSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchStatementBeginContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchStatementBegin();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchStatementEnd(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchStatementEnd();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchStatementEnd(SwitchStatementEndSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchStatementEndContext _Antlr4ParseSwitchStatementEnd()
		{
			BeginNode();
		    TestLexerModeParser.SwitchStatementEndContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchStatementEnd(CurrentNode as SwitchStatementEndSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchStatementEndContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchStatementEnd();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchBranchStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchBranchStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchBranchStatement(SwitchBranchStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchBranchStatementContext _Antlr4ParseSwitchBranchStatement()
		{
			BeginNode();
		    TestLexerModeParser.SwitchBranchStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchBranchStatement(CurrentNode as SwitchBranchStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchBranchStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchBranchStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchBranchHeadStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchBranchHeadStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchBranchHeadStatement(SwitchBranchHeadStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchBranchHeadStatementContext _Antlr4ParseSwitchBranchHeadStatement()
		{
			BeginNode();
		    TestLexerModeParser.SwitchBranchHeadStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchBranchHeadStatement(CurrentNode as SwitchBranchHeadStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchBranchHeadStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchBranchHeadStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchCaseOrTypeIsHeadStatements(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchCaseOrTypeIsHeadStatements();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchCaseOrTypeIsHeadStatements(SwitchCaseOrTypeIsHeadStatementsSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementsContext _Antlr4ParseSwitchCaseOrTypeIsHeadStatements()
		{
			BeginNode();
		    TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchCaseOrTypeIsHeadStatements(CurrentNode as SwitchCaseOrTypeIsHeadStatementsSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchCaseOrTypeIsHeadStatements();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchCaseOrTypeIsHeadStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchCaseOrTypeIsHeadStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchCaseOrTypeIsHeadStatement(SwitchCaseOrTypeIsHeadStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementContext _Antlr4ParseSwitchCaseOrTypeIsHeadStatement()
		{
			BeginNode();
		    TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchCaseOrTypeIsHeadStatement(CurrentNode as SwitchCaseOrTypeIsHeadStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchCaseOrTypeIsHeadStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchCaseHeadStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchCaseHeadStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchCaseHeadStatement(SwitchCaseHeadStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchCaseHeadStatementContext _Antlr4ParseSwitchCaseHeadStatement()
		{
			BeginNode();
		    TestLexerModeParser.SwitchCaseHeadStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchCaseHeadStatement(CurrentNode as SwitchCaseHeadStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchCaseHeadStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchCaseHeadStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchTypeIsHeadStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchTypeIsHeadStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchTypeIsHeadStatement(SwitchTypeIsHeadStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchTypeIsHeadStatementContext _Antlr4ParseSwitchTypeIsHeadStatement()
		{
			BeginNode();
		    TestLexerModeParser.SwitchTypeIsHeadStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchTypeIsHeadStatement(CurrentNode as SwitchTypeIsHeadStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchTypeIsHeadStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchTypeIsHeadStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchTypeAsHeadStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchTypeAsHeadStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchTypeAsHeadStatement(SwitchTypeAsHeadStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchTypeAsHeadStatementContext _Antlr4ParseSwitchTypeAsHeadStatement()
		{
			BeginNode();
		    TestLexerModeParser.SwitchTypeAsHeadStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchTypeAsHeadStatement(CurrentNode as SwitchTypeAsHeadStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchTypeAsHeadStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchTypeAsHeadStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchDefaultStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchDefaultStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchDefaultStatement(SwitchDefaultStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchDefaultStatementContext _Antlr4ParseSwitchDefaultStatement()
		{
			BeginNode();
		    TestLexerModeParser.SwitchDefaultStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchDefaultStatement(CurrentNode as SwitchDefaultStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchDefaultStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchDefaultStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSwitchDefaultHeadStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.switchDefaultHeadStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSwitchDefaultHeadStatement(SwitchDefaultHeadStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SwitchDefaultHeadStatementContext _Antlr4ParseSwitchDefaultHeadStatement()
		{
			BeginNode();
		    TestLexerModeParser.SwitchDefaultHeadStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSwitchDefaultHeadStatement(CurrentNode as SwitchDefaultHeadStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SwitchDefaultHeadStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSwitchDefaultHeadStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTemplateDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.templateDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTemplateDeclaration(TemplateDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TemplateDeclarationContext _Antlr4ParseTemplateDeclaration()
		{
			BeginNode();
		    TestLexerModeParser.TemplateDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTemplateDeclaration(CurrentNode as TemplateDeclarationSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TemplateDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTemplateDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTemplateSignature(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.templateSignature();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTemplateSignature(TemplateSignatureSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TemplateSignatureContext _Antlr4ParseTemplateSignature()
		{
			BeginNode();
		    TestLexerModeParser.TemplateSignatureContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTemplateSignature(CurrentNode as TemplateSignatureSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TemplateSignatureContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTemplateSignature();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTemplateBody(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.templateBody();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTemplateBody(TemplateBodySyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TemplateBodyContext _Antlr4ParseTemplateBody()
		{
			BeginNode();
		    TestLexerModeParser.TemplateBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTemplateBody(CurrentNode as TemplateBodySyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TemplateBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTemplateBody();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTemplateContentLine(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.templateContentLine();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTemplateContentLine(TemplateContentLineSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TemplateContentLineContext _Antlr4ParseTemplateContentLine()
		{
			BeginNode();
		    TestLexerModeParser.TemplateContentLineContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTemplateContentLine(CurrentNode as TemplateContentLineSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TemplateContentLineContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTemplateContentLine();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTemplateContent(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.templateContent();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTemplateContent(TemplateContentSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TemplateContentContext _Antlr4ParseTemplateContent()
		{
			BeginNode();
		    TestLexerModeParser.TemplateContentContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTemplateContent(CurrentNode as TemplateContentSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TemplateContentContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTemplateContent();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTemplateOutput(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.templateOutput();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTemplateOutput(TemplateOutputSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TemplateOutputContext _Antlr4ParseTemplateOutput()
		{
			BeginNode();
		    TestLexerModeParser.TemplateOutputContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTemplateOutput(CurrentNode as TemplateOutputSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TemplateOutputContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTemplateOutput();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTemplateLineEnd(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.templateLineEnd();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTemplateLineEnd(TemplateLineEndSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TemplateLineEndContext _Antlr4ParseTemplateLineEnd()
		{
			BeginNode();
		    TestLexerModeParser.TemplateLineEndContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTemplateLineEnd(CurrentNode as TemplateLineEndSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TemplateLineEndContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTemplateLineEnd();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTemplateStatementStartEnd(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.templateStatementStartEnd();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTemplateStatementStartEnd(TemplateStatementStartEndSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TemplateStatementStartEndContext _Antlr4ParseTemplateStatementStartEnd()
		{
			BeginNode();
		    TestLexerModeParser.TemplateStatementStartEndContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTemplateStatementStartEnd(CurrentNode as TemplateStatementStartEndSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TemplateStatementStartEndContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTemplateStatementStartEnd();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTemplateStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.templateStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTemplateStatement(TemplateStatementSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TemplateStatementContext _Antlr4ParseTemplateStatement()
		{
			BeginNode();
		    TestLexerModeParser.TemplateStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTemplateStatement(CurrentNode as TemplateStatementSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TemplateStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTemplateStatement();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTypeArgumentList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typeArgumentList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypeArgumentList(TypeArgumentListSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TypeArgumentListContext _Antlr4ParseTypeArgumentList()
		{
			BeginNode();
		    TestLexerModeParser.TypeArgumentListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeArgumentList(CurrentNode as TypeArgumentListSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TypeArgumentListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeArgumentList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParsePredefinedType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.predefinedType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePredefinedType(PredefinedTypeSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.PredefinedTypeContext _Antlr4ParsePredefinedType()
		{
			BeginNode();
		    TestLexerModeParser.PredefinedTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReusePredefinedType(CurrentNode as PredefinedTypeSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.PredefinedTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParsePredefinedType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTypeReferenceList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typeReferenceList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypeReferenceList(TypeReferenceListSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TypeReferenceListContext _Antlr4ParseTypeReferenceList()
		{
			BeginNode();
		    TestLexerModeParser.TypeReferenceListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeReferenceList(CurrentNode as TypeReferenceListSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TypeReferenceListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeReferenceList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestLexerModeParser.TypeReferenceContext _Antlr4ParseTypeReference()
		{
			BeginNode();
		    TestLexerModeParser.TypeReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeReference(CurrentNode as TypeReferenceSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TypeReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeReference();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseArrayType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrayType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrayType(ArrayTypeSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ArrayTypeContext _Antlr4ParseArrayType()
		{
			BeginNode();
		    TestLexerModeParser.ArrayTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrayType(CurrentNode as ArrayTypeSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ArrayTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrayType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseArrayItemType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrayItemType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrayItemType(ArrayItemTypeSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ArrayItemTypeContext _Antlr4ParseArrayItemType()
		{
			BeginNode();
		    TestLexerModeParser.ArrayItemTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrayItemType(CurrentNode as ArrayItemTypeSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ArrayItemTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrayItemType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseNullableType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.nullableType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNullableType(NullableTypeSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.NullableTypeContext _Antlr4ParseNullableType()
		{
			BeginNode();
		    TestLexerModeParser.NullableTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNullableType(CurrentNode as NullableTypeSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.NullableTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNullableType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseNullableItemType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.nullableItemType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNullableItemType(NullableItemTypeSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.NullableItemTypeContext _Antlr4ParseNullableItemType()
		{
			BeginNode();
		    TestLexerModeParser.NullableItemTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNullableItemType(CurrentNode as NullableItemTypeSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.NullableItemTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNullableItemType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseGenericType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.genericType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGenericType(GenericTypeSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.GenericTypeContext _Antlr4ParseGenericType()
		{
			BeginNode();
		    TestLexerModeParser.GenericTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseGenericType(CurrentNode as GenericTypeSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.GenericTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseGenericType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseSimpleType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.simpleType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSimpleType(SimpleTypeSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.SimpleTypeContext _Antlr4ParseSimpleType()
		{
			BeginNode();
		    TestLexerModeParser.SimpleTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSimpleType(CurrentNode as SimpleTypeSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.SimpleTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSimpleType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestLexerModeParser.VoidTypeContext _Antlr4ParseVoidType()
		{
			BeginNode();
		    TestLexerModeParser.VoidTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVoidType(CurrentNode as VoidTypeSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.VoidTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.ReturnTypeContext _Antlr4ParseReturnType()
		{
			BeginNode();
		    TestLexerModeParser.ReturnTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseReturnType(CurrentNode as ReturnTypeSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ReturnTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseExpressionList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.expressionList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseExpressionList(ExpressionListSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.ExpressionListContext _Antlr4ParseExpressionList()
		{
			BeginNode();
		    TestLexerModeParser.ExpressionListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseExpressionList(CurrentNode as ExpressionListSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ExpressionListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseExpressionList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseVariableReference(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.variableReference();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVariableReference(VariableReferenceSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.VariableReferenceContext _Antlr4ParseVariableReference()
		{
			BeginNode();
		    TestLexerModeParser.VariableReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVariableReference(CurrentNode as VariableReferenceSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.VariableReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVariableReference();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseRankSpecifiers(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.rankSpecifiers();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRankSpecifiers(RankSpecifiersSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.RankSpecifiersContext _Antlr4ParseRankSpecifiers()
		{
			BeginNode();
		    TestLexerModeParser.RankSpecifiersContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRankSpecifiers(CurrentNode as RankSpecifiersSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.RankSpecifiersContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseRankSpecifiers();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseRankSpecifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.rankSpecifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRankSpecifier(RankSpecifierSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.RankSpecifierContext _Antlr4ParseRankSpecifier()
		{
			BeginNode();
		    TestLexerModeParser.RankSpecifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRankSpecifier(CurrentNode as RankSpecifierSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.RankSpecifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseRankSpecifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseUnboundTypeName(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.unboundTypeName();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseUnboundTypeName(UnboundTypeNameSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.UnboundTypeNameContext _Antlr4ParseUnboundTypeName()
		{
			BeginNode();
		    TestLexerModeParser.UnboundTypeNameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseUnboundTypeName(CurrentNode as UnboundTypeNameSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.UnboundTypeNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseUnboundTypeName();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseGenericDimensionItem(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.genericDimensionItem();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGenericDimensionItem(GenericDimensionItemSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.GenericDimensionItemContext _Antlr4ParseGenericDimensionItem()
		{
			BeginNode();
		    TestLexerModeParser.GenericDimensionItemContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseGenericDimensionItem(CurrentNode as GenericDimensionItemSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.GenericDimensionItemContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseGenericDimensionItem();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseGenericDimensionSpecifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.genericDimensionSpecifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGenericDimensionSpecifier(GenericDimensionSpecifierSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.GenericDimensionSpecifierContext _Antlr4ParseGenericDimensionSpecifier()
		{
			BeginNode();
		    TestLexerModeParser.GenericDimensionSpecifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseGenericDimensionSpecifier(CurrentNode as GenericDimensionSpecifierSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.GenericDimensionSpecifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseGenericDimensionSpecifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseAnonymousFunctionSignature(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.anonymousFunctionSignature();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAnonymousFunctionSignature(AnonymousFunctionSignatureSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.AnonymousFunctionSignatureContext _Antlr4ParseAnonymousFunctionSignature()
		{
			BeginNode();
		    TestLexerModeParser.AnonymousFunctionSignatureContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseAnonymousFunctionSignature(CurrentNode as AnonymousFunctionSignatureSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.AnonymousFunctionSignatureContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseAnonymousFunctionSignature();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestLexerModeParser.ExplicitParameterContext _Antlr4ParseExplicitParameter()
		{
			BeginNode();
		    TestLexerModeParser.ExplicitParameterContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseExplicitParameter(CurrentNode as ExplicitParameterSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ExplicitParameterContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.ImplicitParameterContext _Antlr4ParseImplicitParameter()
		{
			BeginNode();
		    TestLexerModeParser.ImplicitParameterContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseImplicitParameter(CurrentNode as ImplicitParameterSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ImplicitParameterContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.ExpressionContext _Antlr4ParseExpression(int precedence)
		{
			BeginNode();
		    TestLexerModeParser.ExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseExpression(CurrentNode as ExpressionSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.QualifiedNameContext _Antlr4ParseQualifiedName()
		{
			BeginNode();
		    TestLexerModeParser.QualifiedNameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQualifiedName(CurrentNode as QualifiedNameSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.QualifiedNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseIdentifierList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.identifierList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIdentifierList(IdentifierListSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.IdentifierListContext _Antlr4ParseIdentifierList()
		{
			BeginNode();
		    TestLexerModeParser.IdentifierListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIdentifierList(CurrentNode as IdentifierListSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.IdentifierListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseIdentifierList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestLexerModeParser.IdentifierContext _Antlr4ParseIdentifier()
		{
			BeginNode();
		    TestLexerModeParser.IdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIdentifier(CurrentNode as IdentifierSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.IdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.LiteralContext _Antlr4ParseLiteral()
		{
			BeginNode();
		    TestLexerModeParser.LiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLiteral(CurrentNode as LiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.LiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.NullLiteralContext _Antlr4ParseNullLiteral()
		{
			BeginNode();
		    TestLexerModeParser.NullLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNullLiteral(CurrentNode as NullLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.NullLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.BooleanLiteralContext _Antlr4ParseBooleanLiteral()
		{
			BeginNode();
		    TestLexerModeParser.BooleanLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseBooleanLiteral(CurrentNode as BooleanLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.BooleanLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseNumberLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.numberLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNumberLiteral(NumberLiteralSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.NumberLiteralContext _Antlr4ParseNumberLiteral()
		{
			BeginNode();
		    TestLexerModeParser.NumberLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNumberLiteral(CurrentNode as NumberLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.NumberLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNumberLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestLexerModeParser.IntegerLiteralContext _Antlr4ParseIntegerLiteral()
		{
			BeginNode();
		    TestLexerModeParser.IntegerLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIntegerLiteral(CurrentNode as IntegerLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.IntegerLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.DecimalLiteralContext _Antlr4ParseDecimalLiteral()
		{
			BeginNode();
		    TestLexerModeParser.DecimalLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDecimalLiteral(CurrentNode as DecimalLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.DecimalLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.ScientificLiteralContext _Antlr4ParseScientificLiteral()
		{
			BeginNode();
		    TestLexerModeParser.ScientificLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseScientificLiteral(CurrentNode as ScientificLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.ScientificLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseDateOrTimeLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.dateOrTimeLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDateOrTimeLiteral(DateOrTimeLiteralSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.DateOrTimeLiteralContext _Antlr4ParseDateOrTimeLiteral()
		{
			BeginNode();
		    TestLexerModeParser.DateOrTimeLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDateOrTimeLiteral(CurrentNode as DateOrTimeLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.DateOrTimeLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDateOrTimeLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseDateTimeOffsetLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.dateTimeOffsetLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDateTimeOffsetLiteral(DateTimeOffsetLiteralSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.DateTimeOffsetLiteralContext _Antlr4ParseDateTimeOffsetLiteral()
		{
			BeginNode();
		    TestLexerModeParser.DateTimeOffsetLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDateTimeOffsetLiteral(CurrentNode as DateTimeOffsetLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.DateTimeOffsetLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDateTimeOffsetLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseDateTimeLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.dateTimeLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDateTimeLiteral(DateTimeLiteralSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.DateTimeLiteralContext _Antlr4ParseDateTimeLiteral()
		{
			BeginNode();
		    TestLexerModeParser.DateTimeLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDateTimeLiteral(CurrentNode as DateTimeLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.DateTimeLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDateTimeLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseDateLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.dateLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDateLiteral(DateLiteralSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.DateLiteralContext _Antlr4ParseDateLiteral()
		{
			BeginNode();
		    TestLexerModeParser.DateLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDateLiteral(CurrentNode as DateLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.DateLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDateLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseTimeLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.timeLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTimeLiteral(TimeLiteralSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.TimeLiteralContext _Antlr4ParseTimeLiteral()
		{
			BeginNode();
		    TestLexerModeParser.TimeLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTimeLiteral(CurrentNode as TimeLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.TimeLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTimeLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestLexerModeParser.CharLiteralContext _Antlr4ParseCharLiteral()
		{
			BeginNode();
		    TestLexerModeParser.CharLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseCharLiteral(CurrentNode as CharLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.CharLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestLexerModeParser.StringLiteralContext _Antlr4ParseStringLiteral()
		{
			BeginNode();
		    TestLexerModeParser.StringLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseStringLiteral(CurrentNode as StringLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.StringLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
		public GreenNode ParseGuidLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.guidLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGuidLiteral(GuidLiteralSyntax node)
		{
			return node != null;
		}
		
		internal TestLexerModeParser.GuidLiteralContext _Antlr4ParseGuidLiteral()
		{
			BeginNode();
		    TestLexerModeParser.GuidLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseGuidLiteral(CurrentNode as GuidLiteralSyntax))
				{
					green = EatNode();
					context = new TestLexerModeParser.GuidLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseGuidLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
        private class Antlr4ToRoslynVisitor : TestLexerModeParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.
			private readonly TestLexerModeInternalSyntaxFactory _factory;
            private readonly TestLexerModeSyntaxParser _syntaxParser;
            public Antlr4ToRoslynVisitor(TestLexerModeSyntaxParser syntaxParser)
            {
				_factory = (TestLexerModeInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                _syntaxParser = syntaxParser;
            }
            private GreenNode VisitTerminal(IToken token, TestLexerModeSyntaxKind kind)
            {
				if (token == null || (token.Type == TokenConstants.Eof && kind != SyntaxKind.Eof))
				{
					if (kind != null) return _factory.MissingToken(kind);
					else return null;
				}
                var green = ((IncrementalToken)token).GreenToken;
				Debug.Assert(kind == null || green.Kind == kind);
				return green;
            }
            public GreenNode VisitTerminal(IToken token)
            {
				return VisitTerminal(token, null);
            }
            private GreenNode VisitTerminal(ITerminalNode node, TestLexerModeSyntaxKind kind)
            {
                if (node == null || node.Symbol == null || (node.Symbol.Type == TokenConstants.Eof && kind != SyntaxKind.Eof))
				{
					if (kind != null) return _factory.MissingToken(kind);
					else return null;
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
			
			public override GreenNode VisitMain(TestLexerModeParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
				TestLexerModeParser.NamespaceDeclarationContext namespaceDeclarationContext = context.namespaceDeclaration();
				NamespaceDeclarationGreen namespaceDeclaration = null;
				if (namespaceDeclarationContext != null) namespaceDeclaration = (NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext);
				if (namespaceDeclaration == null) namespaceDeclaration = NamespaceDeclarationGreen.__Missing;
				TestLexerModeParser.GeneratorDeclarationContext generatorDeclarationContext = context.generatorDeclaration();
				GeneratorDeclarationGreen generatorDeclaration = null;
				if (generatorDeclarationContext != null) generatorDeclaration = (GeneratorDeclarationGreen)this.Visit(generatorDeclarationContext);
				if (generatorDeclaration == null) generatorDeclaration = GeneratorDeclarationGreen.__Missing;
			    TestLexerModeParser.UsingDeclarationContext[] usingDeclarationContext = context.usingDeclaration();
			    var usingDeclarationBuilder = _pool.Allocate<UsingDeclarationGreen>();
			    for (int i = 0; i < usingDeclarationContext.Length; i++)
			    {
			        usingDeclarationBuilder.Add((UsingDeclarationGreen)this.Visit(usingDeclarationContext[i]));
			    }
				var usingDeclaration = usingDeclarationBuilder.ToList();
				_pool.Free(usingDeclarationBuilder);
				TestLexerModeParser.ConfigDeclarationContext configDeclarationContext = context.configDeclaration();
				ConfigDeclarationGreen configDeclaration = null;
				if (configDeclarationContext != null) configDeclaration = (ConfigDeclarationGreen)this.Visit(configDeclarationContext);
			    TestLexerModeParser.MethodDeclarationContext[] methodDeclarationContext = context.methodDeclaration();
			    var methodDeclarationBuilder = _pool.Allocate<MethodDeclarationGreen>();
			    for (int i = 0; i < methodDeclarationContext.Length; i++)
			    {
			        methodDeclarationBuilder.Add((MethodDeclarationGreen)this.Visit(methodDeclarationContext[i]));
			    }
				var methodDeclaration = methodDeclarationBuilder.ToList();
				_pool.Free(methodDeclarationBuilder);
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), TestLexerModeSyntaxKind.Eof);
				return _factory.Main(namespaceDeclaration, generatorDeclaration, usingDeclaration, configDeclaration, methodDeclaration, eOF);
			}
			
			public override GreenNode VisitNamespaceDeclaration(TestLexerModeParser.NamespaceDeclarationContext context)
			{
				if (context == null) return NamespaceDeclarationGreen.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLexerModeSyntaxKind.KNamespace);
				TestLexerModeParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null) qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				if (qualifiedName == null) qualifiedName = QualifiedNameGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLexerModeSyntaxKind.TSemicolon);
				return _factory.NamespaceDeclaration(kNamespace, qualifiedName, tSemicolon);
			}
			
			public override GreenNode VisitGeneratorDeclaration(TestLexerModeParser.GeneratorDeclarationContext context)
			{
				if (context == null) return GeneratorDeclarationGreen.__Missing;
				InternalSyntaxToken kGenerator = (InternalSyntaxToken)this.VisitTerminal(context.KGenerator(), TestLexerModeSyntaxKind.KGenerator);
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				TestLexerModeParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null) qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				InternalSyntaxToken kFor = (InternalSyntaxToken)this.VisitTerminal(context.KFor());
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLexerModeSyntaxKind.TSemicolon);
				return _factory.GeneratorDeclaration(kGenerator, identifier, tColon, qualifiedName, kFor, typeReference, tSemicolon);
			}
			
			public override GreenNode VisitUsingNamespaceDeclaration(TestLexerModeParser.UsingNamespaceDeclarationContext context)
			{
				if (context == null) return UsingNamespaceDeclarationGreen.__Missing;
				InternalSyntaxToken kUsing = (InternalSyntaxToken)this.VisitTerminal(context.KUsing(), TestLexerModeSyntaxKind.KUsing);
				TestLexerModeParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null) qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				if (qualifiedName == null) qualifiedName = QualifiedNameGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLexerModeSyntaxKind.TSemicolon);
				return _factory.UsingNamespaceDeclaration(kUsing, qualifiedName, tSemicolon);
			}
			
			public override GreenNode VisitUsingGeneratorDeclaration(TestLexerModeParser.UsingGeneratorDeclarationContext context)
			{
				if (context == null) return UsingGeneratorDeclarationGreen.__Missing;
				InternalSyntaxToken kUsing = (InternalSyntaxToken)this.VisitTerminal(context.KUsing(), TestLexerModeSyntaxKind.KUsing);
				InternalSyntaxToken kGenerator = (InternalSyntaxToken)this.VisitTerminal(context.KGenerator(), TestLexerModeSyntaxKind.KGenerator);
				TestLexerModeParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null) qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				if (qualifiedName == null) qualifiedName = QualifiedNameGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLexerModeSyntaxKind.TSemicolon);
				return _factory.UsingGeneratorDeclaration(kUsing, kGenerator, qualifiedName, identifier, tSemicolon);
			}
			
			public override GreenNode VisitConfigDeclaration(TestLexerModeParser.ConfigDeclarationContext context)
			{
				if (context == null) return ConfigDeclarationGreen.__Missing;
				InternalSyntaxToken startProperties = (InternalSyntaxToken)this.VisitTerminal(context.startProperties, TestLexerModeSyntaxKind.KProperties);
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
			    TestLexerModeParser.ConfigPropertyContext[] configPropertyContext = context.configProperty();
			    var configPropertyBuilder = _pool.Allocate<ConfigPropertyGreen>();
			    for (int i = 0; i < configPropertyContext.Length; i++)
			    {
			        configPropertyBuilder.Add((ConfigPropertyGreen)this.Visit(configPropertyContext[i]));
			    }
				var configProperty = configPropertyBuilder.ToList();
				_pool.Free(configPropertyBuilder);
				InternalSyntaxToken kEnd = (InternalSyntaxToken)this.VisitTerminal(context.KEnd(), TestLexerModeSyntaxKind.KEnd);
				InternalSyntaxToken endProperties = (InternalSyntaxToken)this.VisitTerminal(context.endProperties, TestLexerModeSyntaxKind.KProperties);
				return _factory.ConfigDeclaration(startProperties, identifier, configProperty, kEnd, endProperties);
			}
			
			public override GreenNode VisitConfigPropertyDeclaration(TestLexerModeParser.ConfigPropertyDeclarationContext context)
			{
				if (context == null) return ConfigPropertyDeclarationGreen.__Missing;
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLexerModeSyntaxKind.TSemicolon);
				return _factory.ConfigPropertyDeclaration(typeReference, identifier, tAssign, expression, tSemicolon);
			}
			
			public override GreenNode VisitConfigPropertyGroupDeclaration(TestLexerModeParser.ConfigPropertyGroupDeclarationContext context)
			{
				if (context == null) return ConfigPropertyGroupDeclarationGreen.__Missing;
				InternalSyntaxToken startProperties = (InternalSyntaxToken)this.VisitTerminal(context.startProperties, TestLexerModeSyntaxKind.KProperties);
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
			    TestLexerModeParser.ConfigPropertyContext[] configPropertyContext = context.configProperty();
			    var configPropertyBuilder = _pool.Allocate<ConfigPropertyGreen>();
			    for (int i = 0; i < configPropertyContext.Length; i++)
			    {
			        configPropertyBuilder.Add((ConfigPropertyGreen)this.Visit(configPropertyContext[i]));
			    }
				var configProperty = configPropertyBuilder.ToList();
				_pool.Free(configPropertyBuilder);
				InternalSyntaxToken kEnd = (InternalSyntaxToken)this.VisitTerminal(context.KEnd(), TestLexerModeSyntaxKind.KEnd);
				InternalSyntaxToken endProperties = (InternalSyntaxToken)this.VisitTerminal(context.endProperties, TestLexerModeSyntaxKind.KProperties);
				return _factory.ConfigPropertyGroupDeclaration(startProperties, identifier, configProperty, kEnd, endProperties);
			}
			
			public override GreenNode VisitMethodDeclaration(TestLexerModeParser.MethodDeclarationContext context)
			{
				if (context == null) return MethodDeclarationGreen.__Missing;
				TestLexerModeParser.FunctionDeclarationContext functionDeclarationContext = context.functionDeclaration();
				if (functionDeclarationContext != null) 
				{
					return _factory.MethodDeclaration((FunctionDeclarationGreen)this.Visit(functionDeclarationContext));
				}
				TestLexerModeParser.TemplateDeclarationContext templateDeclarationContext = context.templateDeclaration();
				if (templateDeclarationContext != null) 
				{
					return _factory.MethodDeclaration((TemplateDeclarationGreen)this.Visit(templateDeclarationContext));
				}
				TestLexerModeParser.ExternFunctionDeclarationContext externFunctionDeclarationContext = context.externFunctionDeclaration();
				if (externFunctionDeclarationContext != null) 
				{
					return _factory.MethodDeclaration((ExternFunctionDeclarationGreen)this.Visit(externFunctionDeclarationContext));
				}
				return MethodDeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitExternFunctionDeclaration(TestLexerModeParser.ExternFunctionDeclarationContext context)
			{
				if (context == null) return ExternFunctionDeclarationGreen.__Missing;
				InternalSyntaxToken kExtern = (InternalSyntaxToken)this.VisitTerminal(context.KExtern(), TestLexerModeSyntaxKind.KExtern);
				TestLexerModeParser.FunctionSignatureContext functionSignatureContext = context.functionSignature();
				FunctionSignatureGreen functionSignature = null;
				if (functionSignatureContext != null) functionSignature = (FunctionSignatureGreen)this.Visit(functionSignatureContext);
				if (functionSignature == null) functionSignature = FunctionSignatureGreen.__Missing;
				return _factory.ExternFunctionDeclaration(kExtern, functionSignature);
			}
			
			public override GreenNode VisitFunctionDeclaration(TestLexerModeParser.FunctionDeclarationContext context)
			{
				if (context == null) return FunctionDeclarationGreen.__Missing;
				TestLexerModeParser.FunctionSignatureContext functionSignatureContext = context.functionSignature();
				FunctionSignatureGreen functionSignature = null;
				if (functionSignatureContext != null) functionSignature = (FunctionSignatureGreen)this.Visit(functionSignatureContext);
				if (functionSignature == null) functionSignature = FunctionSignatureGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
				InternalSyntaxToken kEnd = (InternalSyntaxToken)this.VisitTerminal(context.KEnd(), TestLexerModeSyntaxKind.KEnd);
				InternalSyntaxToken kFunction = (InternalSyntaxToken)this.VisitTerminal(context.KFunction(), TestLexerModeSyntaxKind.KFunction);
				return _factory.FunctionDeclaration(functionSignature, body, kEnd, kFunction);
			}
			
			public override GreenNode VisitFunctionSignature(TestLexerModeParser.FunctionSignatureContext context)
			{
				if (context == null) return FunctionSignatureGreen.__Missing;
				InternalSyntaxToken kFunction = (InternalSyntaxToken)this.VisitTerminal(context.KFunction(), TestLexerModeSyntaxKind.KFunction);
				TestLexerModeParser.ReturnTypeContext returnTypeContext = context.returnType();
				ReturnTypeGreen returnType = null;
				if (returnTypeContext != null) returnType = (ReturnTypeGreen)this.Visit(returnTypeContext);
				if (returnType == null) returnType = ReturnTypeGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				TestLexerModeParser.TypeArgumentListContext typeArgumentListContext = context.typeArgumentList();
				TypeArgumentListGreen typeArgumentList = null;
				if (typeArgumentListContext != null) typeArgumentList = (TypeArgumentListGreen)this.Visit(typeArgumentListContext);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ParamListContext paramListContext = context.paramList();
				ParamListGreen paramList = null;
				if (paramListContext != null) paramList = (ParamListGreen)this.Visit(paramListContext);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.FunctionSignature(kFunction, returnType, identifier, typeArgumentList, tOpenParenthesis, paramList, tCloseParenthesis);
			}
			
			public override GreenNode VisitParamList(TestLexerModeParser.ParamListContext context)
			{
				if (context == null) return ParamListGreen.__Missing;
			    TestLexerModeParser.ParameterContext[] parameterContext = context.parameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var parameterBuilder = _pool.AllocateSeparated<ParameterGreen>();
			    for (int i = 0; i < parameterContext.Length; i++)
			    {
			        parameterBuilder.Add((ParameterGreen)this.Visit(parameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            parameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestLexerModeSyntaxKind.TComma));
			        }
			    }
				var parameter = parameterBuilder.ToList();
				_pool.Free(parameterBuilder);
				return _factory.ParamList(parameter);
			}
			
			public override GreenNode VisitParameter(TestLexerModeParser.ParameterContext context)
			{
				if (context == null) return ParameterGreen.__Missing;
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				return _factory.Parameter(typeReference, identifier, tAssign, expression);
			}
			
			public override GreenNode VisitBody(TestLexerModeParser.BodyContext context)
			{
				if (context == null) return BodyGreen.__Missing;
			    TestLexerModeParser.StatementContext[] statementContext = context.statement();
			    var statementBuilder = _pool.Allocate<StatementGreen>();
			    for (int i = 0; i < statementContext.Length; i++)
			    {
			        statementBuilder.Add((StatementGreen)this.Visit(statementContext[i]));
			    }
				var statement = statementBuilder.ToList();
				_pool.Free(statementBuilder);
				return _factory.Body(statement);
			}
			
			public override GreenNode VisitStatement(TestLexerModeParser.StatementContext context)
			{
				if (context == null) return StatementGreen.__Missing;
				TestLexerModeParser.SingleStatementSemicolonContext singleStatementSemicolonContext = context.singleStatementSemicolon();
				if (singleStatementSemicolonContext != null) 
				{
					return _factory.Statement((SingleStatementSemicolonGreen)this.Visit(singleStatementSemicolonContext));
				}
				TestLexerModeParser.IfStatementContext ifStatementContext = context.ifStatement();
				if (ifStatementContext != null) 
				{
					return _factory.Statement((IfStatementGreen)this.Visit(ifStatementContext));
				}
				TestLexerModeParser.ForStatementContext forStatementContext = context.forStatement();
				if (forStatementContext != null) 
				{
					return _factory.Statement((ForStatementGreen)this.Visit(forStatementContext));
				}
				TestLexerModeParser.WhileStatementContext whileStatementContext = context.whileStatement();
				if (whileStatementContext != null) 
				{
					return _factory.Statement((WhileStatementGreen)this.Visit(whileStatementContext));
				}
				TestLexerModeParser.RepeatStatementContext repeatStatementContext = context.repeatStatement();
				if (repeatStatementContext != null) 
				{
					return _factory.Statement((RepeatStatementGreen)this.Visit(repeatStatementContext));
				}
				TestLexerModeParser.LoopStatementContext loopStatementContext = context.loopStatement();
				if (loopStatementContext != null) 
				{
					return _factory.Statement((LoopStatementGreen)this.Visit(loopStatementContext));
				}
				TestLexerModeParser.SwitchStatementContext switchStatementContext = context.switchStatement();
				if (switchStatementContext != null) 
				{
					return _factory.Statement((SwitchStatementGreen)this.Visit(switchStatementContext));
				}
				return StatementGreen.__Missing;
			}
			
			public override GreenNode VisitSingleStatement(TestLexerModeParser.SingleStatementContext context)
			{
				if (context == null) return SingleStatementGreen.__Missing;
				TestLexerModeParser.VariableDeclarationStatementContext variableDeclarationStatementContext = context.variableDeclarationStatement();
				if (variableDeclarationStatementContext != null) 
				{
					return _factory.SingleStatement((VariableDeclarationStatementGreen)this.Visit(variableDeclarationStatementContext));
				}
				TestLexerModeParser.ReturnStatementContext returnStatementContext = context.returnStatement();
				if (returnStatementContext != null) 
				{
					return _factory.SingleStatement((ReturnStatementGreen)this.Visit(returnStatementContext));
				}
				TestLexerModeParser.ExpressionStatementContext expressionStatementContext = context.expressionStatement();
				if (expressionStatementContext != null) 
				{
					return _factory.SingleStatement((ExpressionStatementGreen)this.Visit(expressionStatementContext));
				}
				return SingleStatementGreen.__Missing;
			}
			
			public override GreenNode VisitSingleStatementSemicolon(TestLexerModeParser.SingleStatementSemicolonContext context)
			{
				if (context == null) return SingleStatementSemicolonGreen.__Missing;
				TestLexerModeParser.SingleStatementContext singleStatementContext = context.singleStatement();
				SingleStatementGreen singleStatement = null;
				if (singleStatementContext != null) singleStatement = (SingleStatementGreen)this.Visit(singleStatementContext);
				if (singleStatement == null) singleStatement = SingleStatementGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLexerModeSyntaxKind.TSemicolon);
				return _factory.SingleStatementSemicolon(singleStatement, tSemicolon);
			}
			
			public override GreenNode VisitVariableDeclarationStatement(TestLexerModeParser.VariableDeclarationStatementContext context)
			{
				if (context == null) return VariableDeclarationStatementGreen.__Missing;
				TestLexerModeParser.VariableDeclarationExpressionContext variableDeclarationExpressionContext = context.variableDeclarationExpression();
				VariableDeclarationExpressionGreen variableDeclarationExpression = null;
				if (variableDeclarationExpressionContext != null) variableDeclarationExpression = (VariableDeclarationExpressionGreen)this.Visit(variableDeclarationExpressionContext);
				if (variableDeclarationExpression == null) variableDeclarationExpression = VariableDeclarationExpressionGreen.__Missing;
				return _factory.VariableDeclarationStatement(variableDeclarationExpression);
			}
			
			public override GreenNode VisitVariableDeclarationExpression(TestLexerModeParser.VariableDeclarationExpressionContext context)
			{
				if (context == null) return VariableDeclarationExpressionGreen.__Missing;
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
			    TestLexerModeParser.VariableDeclarationItemContext[] variableDeclarationItemContext = context.variableDeclarationItem();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var variableDeclarationItemBuilder = _pool.AllocateSeparated<VariableDeclarationItemGreen>();
			    for (int i = 0; i < variableDeclarationItemContext.Length; i++)
			    {
			        variableDeclarationItemBuilder.Add((VariableDeclarationItemGreen)this.Visit(variableDeclarationItemContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            variableDeclarationItemBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestLexerModeSyntaxKind.TComma));
			        }
			    }
				var variableDeclarationItem = variableDeclarationItemBuilder.ToList();
				_pool.Free(variableDeclarationItemBuilder);
				return _factory.VariableDeclarationExpression(typeReference, variableDeclarationItem);
			}
			
			public override GreenNode VisitVariableDeclarationItem(TestLexerModeParser.VariableDeclarationItemContext context)
			{
				if (context == null) return VariableDeclarationItemGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				return _factory.VariableDeclarationItem(identifier, tAssign, expression);
			}
			
			public override GreenNode VisitVoidStatement(TestLexerModeParser.VoidStatementContext context)
			{
				if (context == null) return VoidStatementGreen.__Missing;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid(), TestLexerModeSyntaxKind.KVoid);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.VoidStatement(kVoid, expression);
			}
			
			public override GreenNode VisitReturnStatement(TestLexerModeParser.ReturnStatementContext context)
			{
				if (context == null) return ReturnStatementGreen.__Missing;
				InternalSyntaxToken kReturn = (InternalSyntaxToken)this.VisitTerminal(context.KReturn(), TestLexerModeSyntaxKind.KReturn);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.ReturnStatement(kReturn, expression);
			}
			
			public override GreenNode VisitExpressionStatement(TestLexerModeParser.ExpressionStatementContext context)
			{
				if (context == null) return ExpressionStatementGreen.__Missing;
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.ExpressionStatement(expression);
			}
			
			public override GreenNode VisitIfStatement(TestLexerModeParser.IfStatementContext context)
			{
				if (context == null) return IfStatementGreen.__Missing;
				TestLexerModeParser.IfStatementBeginContext ifStatementBeginContext = context.ifStatementBegin();
				IfStatementBeginGreen ifStatementBegin = null;
				if (ifStatementBeginContext != null) ifStatementBegin = (IfStatementBeginGreen)this.Visit(ifStatementBeginContext);
				if (ifStatementBegin == null) ifStatementBegin = IfStatementBeginGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
			    TestLexerModeParser.ElseIfStatementBodyContext[] elseIfStatementBodyContext = context.elseIfStatementBody();
			    var elseIfStatementBodyBuilder = _pool.Allocate<ElseIfStatementBodyGreen>();
			    for (int i = 0; i < elseIfStatementBodyContext.Length; i++)
			    {
			        elseIfStatementBodyBuilder.Add((ElseIfStatementBodyGreen)this.Visit(elseIfStatementBodyContext[i]));
			    }
				var elseIfStatementBody = elseIfStatementBodyBuilder.ToList();
				_pool.Free(elseIfStatementBodyBuilder);
				TestLexerModeParser.IfStatementElseBodyContext ifStatementElseBodyContext = context.ifStatementElseBody();
				IfStatementElseBodyGreen ifStatementElseBody = null;
				if (ifStatementElseBodyContext != null) ifStatementElseBody = (IfStatementElseBodyGreen)this.Visit(ifStatementElseBodyContext);
				TestLexerModeParser.IfStatementEndContext ifStatementEndContext = context.ifStatementEnd();
				IfStatementEndGreen ifStatementEnd = null;
				if (ifStatementEndContext != null) ifStatementEnd = (IfStatementEndGreen)this.Visit(ifStatementEndContext);
				if (ifStatementEnd == null) ifStatementEnd = IfStatementEndGreen.__Missing;
				return _factory.IfStatement(ifStatementBegin, body, elseIfStatementBody, ifStatementElseBody, ifStatementEnd);
			}
			
			public override GreenNode VisitElseIfStatementBody(TestLexerModeParser.ElseIfStatementBodyContext context)
			{
				if (context == null) return ElseIfStatementBodyGreen.__Missing;
				TestLexerModeParser.ElseIfStatementContext elseIfStatementContext = context.elseIfStatement();
				ElseIfStatementGreen elseIfStatement = null;
				if (elseIfStatementContext != null) elseIfStatement = (ElseIfStatementGreen)this.Visit(elseIfStatementContext);
				if (elseIfStatement == null) elseIfStatement = ElseIfStatementGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
				return _factory.ElseIfStatementBody(elseIfStatement, body);
			}
			
			public override GreenNode VisitIfStatementElseBody(TestLexerModeParser.IfStatementElseBodyContext context)
			{
				if (context == null) return IfStatementElseBodyGreen.__Missing;
				TestLexerModeParser.IfStatementElseContext ifStatementElseContext = context.ifStatementElse();
				IfStatementElseGreen ifStatementElse = null;
				if (ifStatementElseContext != null) ifStatementElse = (IfStatementElseGreen)this.Visit(ifStatementElseContext);
				if (ifStatementElse == null) ifStatementElse = IfStatementElseGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
				return _factory.IfStatementElseBody(ifStatementElse, body);
			}
			
			public override GreenNode VisitIfStatementBegin(TestLexerModeParser.IfStatementBeginContext context)
			{
				if (context == null) return IfStatementBeginGreen.__Missing;
				InternalSyntaxToken kIf = (InternalSyntaxToken)this.VisitTerminal(context.KIf(), TestLexerModeSyntaxKind.KIf);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.IfStatementBegin(kIf, tOpenParenthesis, expression, tCloseParenthesis);
			}
			
			public override GreenNode VisitElseIfStatement(TestLexerModeParser.ElseIfStatementContext context)
			{
				if (context == null) return ElseIfStatementGreen.__Missing;
				InternalSyntaxToken kElse = (InternalSyntaxToken)this.VisitTerminal(context.KElse(), TestLexerModeSyntaxKind.KElse);
				InternalSyntaxToken kIf = (InternalSyntaxToken)this.VisitTerminal(context.KIf(), TestLexerModeSyntaxKind.KIf);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.ElseIfStatement(kElse, kIf, tOpenParenthesis, expression, tCloseParenthesis);
			}
			
			public override GreenNode VisitIfStatementElse(TestLexerModeParser.IfStatementElseContext context)
			{
				if (context == null) return IfStatementElseGreen.__Missing;
				InternalSyntaxToken kElse = (InternalSyntaxToken)this.VisitTerminal(context.KElse(), TestLexerModeSyntaxKind.KElse);
				return _factory.IfStatementElse(kElse);
			}
			
			public override GreenNode VisitIfStatementEnd(TestLexerModeParser.IfStatementEndContext context)
			{
				if (context == null) return IfStatementEndGreen.__Missing;
				InternalSyntaxToken kEnd = (InternalSyntaxToken)this.VisitTerminal(context.KEnd(), TestLexerModeSyntaxKind.KEnd);
				InternalSyntaxToken kIf = (InternalSyntaxToken)this.VisitTerminal(context.KIf(), TestLexerModeSyntaxKind.KIf);
				return _factory.IfStatementEnd(kEnd, kIf);
			}
			
			public override GreenNode VisitForStatement(TestLexerModeParser.ForStatementContext context)
			{
				if (context == null) return ForStatementGreen.__Missing;
				TestLexerModeParser.ForStatementBeginContext forStatementBeginContext = context.forStatementBegin();
				ForStatementBeginGreen forStatementBegin = null;
				if (forStatementBeginContext != null) forStatementBegin = (ForStatementBeginGreen)this.Visit(forStatementBeginContext);
				if (forStatementBegin == null) forStatementBegin = ForStatementBeginGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
				TestLexerModeParser.ForStatementEndContext forStatementEndContext = context.forStatementEnd();
				ForStatementEndGreen forStatementEnd = null;
				if (forStatementEndContext != null) forStatementEnd = (ForStatementEndGreen)this.Visit(forStatementEndContext);
				if (forStatementEnd == null) forStatementEnd = ForStatementEndGreen.__Missing;
				return _factory.ForStatement(forStatementBegin, body, forStatementEnd);
			}
			
			public override GreenNode VisitForStatementBegin(TestLexerModeParser.ForStatementBeginContext context)
			{
				if (context == null) return ForStatementBeginGreen.__Missing;
				InternalSyntaxToken kFor = (InternalSyntaxToken)this.VisitTerminal(context.KFor(), TestLexerModeSyntaxKind.KFor);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ForInitStatementContext forInitStatementContext = context.forInitStatement();
				ForInitStatementGreen forInitStatement = null;
				if (forInitStatementContext != null) forInitStatement = (ForInitStatementGreen)this.Visit(forInitStatementContext);
				InternalSyntaxToken semi1 = (InternalSyntaxToken)this.VisitTerminal(context.semi1, TestLexerModeSyntaxKind.TSemicolon);
				TestLexerModeParser.ExpressionListContext endExpressionContext = context.endExpression;
				ExpressionListGreen endExpression = null;
				if (endExpressionContext != null) endExpression = (ExpressionListGreen)this.Visit(endExpressionContext);
				InternalSyntaxToken semi2 = (InternalSyntaxToken)this.VisitTerminal(context.semi2, TestLexerModeSyntaxKind.TSemicolon);
				TestLexerModeParser.ExpressionListContext stepExpressionContext = context.stepExpression;
				ExpressionListGreen stepExpression = null;
				if (stepExpressionContext != null) stepExpression = (ExpressionListGreen)this.Visit(stepExpressionContext);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.ForStatementBegin(kFor, tOpenParenthesis, forInitStatement, semi1, endExpression, semi2, stepExpression, tCloseParenthesis);
			}
			
			public override GreenNode VisitForStatementEnd(TestLexerModeParser.ForStatementEndContext context)
			{
				if (context == null) return ForStatementEndGreen.__Missing;
				InternalSyntaxToken kEnd = (InternalSyntaxToken)this.VisitTerminal(context.KEnd(), TestLexerModeSyntaxKind.KEnd);
				InternalSyntaxToken kFor = (InternalSyntaxToken)this.VisitTerminal(context.KFor(), TestLexerModeSyntaxKind.KFor);
				return _factory.ForStatementEnd(kEnd, kFor);
			}
			
			public override GreenNode VisitForInitStatement(TestLexerModeParser.ForInitStatementContext context)
			{
				if (context == null) return ForInitStatementGreen.__Missing;
				TestLexerModeParser.VariableDeclarationExpressionContext variableDeclarationExpressionContext = context.variableDeclarationExpression();
				if (variableDeclarationExpressionContext != null) 
				{
					return _factory.ForInitStatement((VariableDeclarationExpressionGreen)this.Visit(variableDeclarationExpressionContext));
				}
				TestLexerModeParser.ExpressionListContext expressionListContext = context.expressionList();
				if (expressionListContext != null) 
				{
					return _factory.ForInitStatement((ExpressionListGreen)this.Visit(expressionListContext));
				}
				return ForInitStatementGreen.__Missing;
			}
			
			public override GreenNode VisitWhileStatement(TestLexerModeParser.WhileStatementContext context)
			{
				if (context == null) return WhileStatementGreen.__Missing;
				TestLexerModeParser.WhileStatementBeginContext whileStatementBeginContext = context.whileStatementBegin();
				WhileStatementBeginGreen whileStatementBegin = null;
				if (whileStatementBeginContext != null) whileStatementBegin = (WhileStatementBeginGreen)this.Visit(whileStatementBeginContext);
				if (whileStatementBegin == null) whileStatementBegin = WhileStatementBeginGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
				TestLexerModeParser.WhileStatementEndContext whileStatementEndContext = context.whileStatementEnd();
				WhileStatementEndGreen whileStatementEnd = null;
				if (whileStatementEndContext != null) whileStatementEnd = (WhileStatementEndGreen)this.Visit(whileStatementEndContext);
				if (whileStatementEnd == null) whileStatementEnd = WhileStatementEndGreen.__Missing;
				return _factory.WhileStatement(whileStatementBegin, body, whileStatementEnd);
			}
			
			public override GreenNode VisitWhileStatementBegin(TestLexerModeParser.WhileStatementBeginContext context)
			{
				if (context == null) return WhileStatementBeginGreen.__Missing;
				InternalSyntaxToken kWhile = (InternalSyntaxToken)this.VisitTerminal(context.KWhile(), TestLexerModeSyntaxKind.KWhile);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.WhileStatementBegin(kWhile, tOpenParenthesis, expression, tCloseParenthesis);
			}
			
			public override GreenNode VisitWhileStatementEnd(TestLexerModeParser.WhileStatementEndContext context)
			{
				if (context == null) return WhileStatementEndGreen.__Missing;
				InternalSyntaxToken kEnd = (InternalSyntaxToken)this.VisitTerminal(context.KEnd(), TestLexerModeSyntaxKind.KEnd);
				InternalSyntaxToken kWhile = (InternalSyntaxToken)this.VisitTerminal(context.KWhile(), TestLexerModeSyntaxKind.KWhile);
				return _factory.WhileStatementEnd(kEnd, kWhile);
			}
			
			public override GreenNode VisitWhileRunExpression(TestLexerModeParser.WhileRunExpressionContext context)
			{
				if (context == null) return WhileRunExpressionGreen.__Missing;
				TestLexerModeParser.SeparatorStatementContext separatorStatementContext = context.separatorStatement();
				SeparatorStatementGreen separatorStatement = null;
				if (separatorStatementContext != null) separatorStatement = (SeparatorStatementGreen)this.Visit(separatorStatementContext);
				if (separatorStatement == null) separatorStatement = SeparatorStatementGreen.__Missing;
				return _factory.WhileRunExpression(separatorStatement);
			}
			
			public override GreenNode VisitRepeatStatement(TestLexerModeParser.RepeatStatementContext context)
			{
				if (context == null) return RepeatStatementGreen.__Missing;
				TestLexerModeParser.RepeatStatementBeginContext repeatStatementBeginContext = context.repeatStatementBegin();
				RepeatStatementBeginGreen repeatStatementBegin = null;
				if (repeatStatementBeginContext != null) repeatStatementBegin = (RepeatStatementBeginGreen)this.Visit(repeatStatementBeginContext);
				if (repeatStatementBegin == null) repeatStatementBegin = RepeatStatementBeginGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
				TestLexerModeParser.RepeatStatementEndContext repeatStatementEndContext = context.repeatStatementEnd();
				RepeatStatementEndGreen repeatStatementEnd = null;
				if (repeatStatementEndContext != null) repeatStatementEnd = (RepeatStatementEndGreen)this.Visit(repeatStatementEndContext);
				if (repeatStatementEnd == null) repeatStatementEnd = RepeatStatementEndGreen.__Missing;
				return _factory.RepeatStatement(repeatStatementBegin, body, repeatStatementEnd);
			}
			
			public override GreenNode VisitRepeatStatementBegin(TestLexerModeParser.RepeatStatementBeginContext context)
			{
				if (context == null) return RepeatStatementBeginGreen.__Missing;
				InternalSyntaxToken kRepeat = (InternalSyntaxToken)this.VisitTerminal(context.KRepeat(), TestLexerModeSyntaxKind.KRepeat);
				return _factory.RepeatStatementBegin(kRepeat);
			}
			
			public override GreenNode VisitRepeatStatementEnd(TestLexerModeParser.RepeatStatementEndContext context)
			{
				if (context == null) return RepeatStatementEndGreen.__Missing;
				InternalSyntaxToken kUntil = (InternalSyntaxToken)this.VisitTerminal(context.KUntil(), TestLexerModeSyntaxKind.KUntil);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.RepeatStatementEnd(kUntil, tOpenParenthesis, expression, tCloseParenthesis);
			}
			
			public override GreenNode VisitRepeatRunExpression(TestLexerModeParser.RepeatRunExpressionContext context)
			{
				if (context == null) return RepeatRunExpressionGreen.__Missing;
				TestLexerModeParser.SeparatorStatementContext separatorStatementContext = context.separatorStatement();
				SeparatorStatementGreen separatorStatement = null;
				if (separatorStatementContext != null) separatorStatement = (SeparatorStatementGreen)this.Visit(separatorStatementContext);
				if (separatorStatement == null) separatorStatement = SeparatorStatementGreen.__Missing;
				return _factory.RepeatRunExpression(separatorStatement);
			}
			
			public override GreenNode VisitLoopStatement(TestLexerModeParser.LoopStatementContext context)
			{
				if (context == null) return LoopStatementGreen.__Missing;
				TestLexerModeParser.LoopStatementBeginContext loopStatementBeginContext = context.loopStatementBegin();
				LoopStatementBeginGreen loopStatementBegin = null;
				if (loopStatementBeginContext != null) loopStatementBegin = (LoopStatementBeginGreen)this.Visit(loopStatementBeginContext);
				if (loopStatementBegin == null) loopStatementBegin = LoopStatementBeginGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
				TestLexerModeParser.LoopStatementEndContext loopStatementEndContext = context.loopStatementEnd();
				LoopStatementEndGreen loopStatementEnd = null;
				if (loopStatementEndContext != null) loopStatementEnd = (LoopStatementEndGreen)this.Visit(loopStatementEndContext);
				if (loopStatementEnd == null) loopStatementEnd = LoopStatementEndGreen.__Missing;
				return _factory.LoopStatement(loopStatementBegin, body, loopStatementEnd);
			}
			
			public override GreenNode VisitLoopStatementBegin(TestLexerModeParser.LoopStatementBeginContext context)
			{
				if (context == null) return LoopStatementBeginGreen.__Missing;
				InternalSyntaxToken kLoop = (InternalSyntaxToken)this.VisitTerminal(context.KLoop(), TestLexerModeSyntaxKind.KLoop);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.LoopChainContext loopChainContext = context.loopChain();
				LoopChainGreen loopChain = null;
				if (loopChainContext != null) loopChain = (LoopChainGreen)this.Visit(loopChainContext);
				if (loopChain == null) loopChain = LoopChainGreen.__Missing;
				TestLexerModeParser.LoopWhereExpressionContext loopWhereExpressionContext = context.loopWhereExpression();
				LoopWhereExpressionGreen loopWhereExpression = null;
				if (loopWhereExpressionContext != null) loopWhereExpression = (LoopWhereExpressionGreen)this.Visit(loopWhereExpressionContext);
				TestLexerModeParser.LoopRunExpressionContext loopRunExpressionContext = context.loopRunExpression();
				LoopRunExpressionGreen loopRunExpression = null;
				if (loopRunExpressionContext != null) loopRunExpression = (LoopRunExpressionGreen)this.Visit(loopRunExpressionContext);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.LoopStatementBegin(kLoop, tOpenParenthesis, loopChain, loopWhereExpression, loopRunExpression, tCloseParenthesis);
			}
			
			public override GreenNode VisitLoopStatementEnd(TestLexerModeParser.LoopStatementEndContext context)
			{
				if (context == null) return LoopStatementEndGreen.__Missing;
				InternalSyntaxToken kEnd = (InternalSyntaxToken)this.VisitTerminal(context.KEnd(), TestLexerModeSyntaxKind.KEnd);
				InternalSyntaxToken kLoop = (InternalSyntaxToken)this.VisitTerminal(context.KLoop(), TestLexerModeSyntaxKind.KLoop);
				return _factory.LoopStatementEnd(kEnd, kLoop);
			}
			
			public override GreenNode VisitLoopChain(TestLexerModeParser.LoopChainContext context)
			{
				if (context == null) return LoopChainGreen.__Missing;
			    TestLexerModeParser.LoopChainItemContext[] loopChainItemContext = context.loopChainItem();
			    ITerminalNode[] tSingleArrowContext = context.TSingleArrow();
			    var loopChainItemBuilder = _pool.AllocateSeparated<LoopChainItemGreen>();
			    for (int i = 0; i < loopChainItemContext.Length; i++)
			    {
			        loopChainItemBuilder.Add((LoopChainItemGreen)this.Visit(loopChainItemContext[i]));
			        if (i < tSingleArrowContext.Length)
			        {
			            loopChainItemBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tSingleArrowContext[i], TestLexerModeSyntaxKind.TSingleArrow));
			        }
			    }
				var loopChainItem = loopChainItemBuilder.ToList();
				_pool.Free(loopChainItemBuilder);
				return _factory.LoopChain(loopChainItem);
			}
			
			public override GreenNode VisitLoopChainItem(TestLexerModeParser.LoopChainItemContext context)
			{
				if (context == null) return LoopChainItemGreen.__Missing;
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				TestLexerModeParser.LoopChainExpressionContext loopChainExpressionContext = context.loopChainExpression();
				LoopChainExpressionGreen loopChainExpression = null;
				if (loopChainExpressionContext != null) loopChainExpression = (LoopChainExpressionGreen)this.Visit(loopChainExpressionContext);
				if (loopChainExpression == null) loopChainExpression = LoopChainExpressionGreen.__Missing;
				return _factory.LoopChainItem(typeReference, identifier, tColon, loopChainExpression);
			}
			
			public override GreenNode VisitLoopChainTypeofExpression(TestLexerModeParser.LoopChainTypeofExpressionContext context)
			{
				if (context == null) return LoopChainTypeofExpressionGreen.__Missing;
				InternalSyntaxToken kTypeof = (InternalSyntaxToken)this.VisitTerminal(context.KTypeof(), TestLexerModeSyntaxKind.KTypeof);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.LoopChainTypeofExpression(kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
			}
			
			public override GreenNode VisitLoopChainIdentifierExpression(TestLexerModeParser.LoopChainIdentifierExpressionContext context)
			{
				if (context == null) return LoopChainIdentifierExpressionGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				TestLexerModeParser.TypeArgumentListContext typeArgumentListContext = context.typeArgumentList();
				TypeArgumentListGreen typeArgumentList = null;
				if (typeArgumentListContext != null) typeArgumentList = (TypeArgumentListGreen)this.Visit(typeArgumentListContext);
				return _factory.LoopChainIdentifierExpression(identifier, typeArgumentList);
			}
			
			public override GreenNode VisitLoopChainMemberAccessExpression(TestLexerModeParser.LoopChainMemberAccessExpressionContext context)
			{
				if (context == null) return LoopChainMemberAccessExpressionGreen.__Missing;
				TestLexerModeParser.LoopChainExpressionContext loopChainExpressionContext = context.loopChainExpression();
				LoopChainExpressionGreen loopChainExpression = null;
				if (loopChainExpressionContext != null) loopChainExpression = (LoopChainExpressionGreen)this.Visit(loopChainExpressionContext);
				if (loopChainExpression == null) loopChainExpression = LoopChainExpressionGreen.__Missing;
				InternalSyntaxToken tDot = (InternalSyntaxToken)this.VisitTerminal(context.TDot(), TestLexerModeSyntaxKind.TDot);
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				TestLexerModeParser.TypeArgumentListContext typeArgumentListContext = context.typeArgumentList();
				TypeArgumentListGreen typeArgumentList = null;
				if (typeArgumentListContext != null) typeArgumentList = (TypeArgumentListGreen)this.Visit(typeArgumentListContext);
				return _factory.LoopChainMemberAccessExpression(loopChainExpression, tDot, identifier, typeArgumentList);
			}
			
			public override GreenNode VisitLoopChainMethodCallExpression(TestLexerModeParser.LoopChainMethodCallExpressionContext context)
			{
				if (context == null) return LoopChainMethodCallExpressionGreen.__Missing;
				TestLexerModeParser.LoopChainExpressionContext loopChainExpressionContext = context.loopChainExpression();
				LoopChainExpressionGreen loopChainExpression = null;
				if (loopChainExpressionContext != null) loopChainExpression = (LoopChainExpressionGreen)this.Visit(loopChainExpressionContext);
				if (loopChainExpression == null) loopChainExpression = LoopChainExpressionGreen.__Missing;
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ExpressionListContext expressionListContext = context.expressionList();
				ExpressionListGreen expressionList = null;
				if (expressionListContext != null) expressionList = (ExpressionListGreen)this.Visit(expressionListContext);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.LoopChainMethodCallExpression(loopChainExpression, tOpenParenthesis, expressionList, tCloseParenthesis);
			}
			
			public override GreenNode VisitLoopWhereExpression(TestLexerModeParser.LoopWhereExpressionContext context)
			{
				if (context == null) return LoopWhereExpressionGreen.__Missing;
				InternalSyntaxToken kWhere = (InternalSyntaxToken)this.VisitTerminal(context.KWhere(), TestLexerModeSyntaxKind.KWhere);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.LoopWhereExpression(kWhere, expression);
			}
			
			public override GreenNode VisitLoopRunExpression(TestLexerModeParser.LoopRunExpressionContext context)
			{
				if (context == null) return LoopRunExpressionGreen.__Missing;
				TestLexerModeParser.SeparatorStatementContext separatorStatementContext = context.separatorStatement();
				SeparatorStatementGreen separatorStatement = null;
				if (separatorStatementContext != null) separatorStatement = (SeparatorStatementGreen)this.Visit(separatorStatementContext);
				if (separatorStatement == null) separatorStatement = SeparatorStatementGreen.__Missing;
				return _factory.LoopRunExpression(separatorStatement);
			}
			
			public override GreenNode VisitSeparatorStatement(TestLexerModeParser.SeparatorStatementContext context)
			{
				if (context == null) return SeparatorStatementGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLexerModeSyntaxKind.TSemicolon);
				InternalSyntaxToken kSeparator = (InternalSyntaxToken)this.VisitTerminal(context.KSeparator(), TestLexerModeSyntaxKind.KSeparator);
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), TestLexerModeSyntaxKind.TAssign);
				TestLexerModeParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.SeparatorStatement(tSemicolon, kSeparator, identifier, tAssign, stringLiteral);
			}
			
			public override GreenNode VisitSwitchStatement(TestLexerModeParser.SwitchStatementContext context)
			{
				if (context == null) return SwitchStatementGreen.__Missing;
				TestLexerModeParser.SwitchStatementBeginContext switchStatementBeginContext = context.switchStatementBegin();
				SwitchStatementBeginGreen switchStatementBegin = null;
				if (switchStatementBeginContext != null) switchStatementBegin = (SwitchStatementBeginGreen)this.Visit(switchStatementBeginContext);
				if (switchStatementBegin == null) switchStatementBegin = SwitchStatementBeginGreen.__Missing;
			    TestLexerModeParser.SwitchBranchStatementContext[] switchBranchStatementContext = context.switchBranchStatement();
			    var switchBranchStatementBuilder = _pool.Allocate<SwitchBranchStatementGreen>();
			    for (int i = 0; i < switchBranchStatementContext.Length; i++)
			    {
			        switchBranchStatementBuilder.Add((SwitchBranchStatementGreen)this.Visit(switchBranchStatementContext[i]));
			    }
				var switchBranchStatement = switchBranchStatementBuilder.ToList();
				_pool.Free(switchBranchStatementBuilder);
				TestLexerModeParser.SwitchDefaultStatementContext switchDefaultStatementContext = context.switchDefaultStatement();
				SwitchDefaultStatementGreen switchDefaultStatement = null;
				if (switchDefaultStatementContext != null) switchDefaultStatement = (SwitchDefaultStatementGreen)this.Visit(switchDefaultStatementContext);
				TestLexerModeParser.SwitchStatementEndContext switchStatementEndContext = context.switchStatementEnd();
				SwitchStatementEndGreen switchStatementEnd = null;
				if (switchStatementEndContext != null) switchStatementEnd = (SwitchStatementEndGreen)this.Visit(switchStatementEndContext);
				if (switchStatementEnd == null) switchStatementEnd = SwitchStatementEndGreen.__Missing;
				return _factory.SwitchStatement(switchStatementBegin, switchBranchStatement, switchDefaultStatement, switchStatementEnd);
			}
			
			public override GreenNode VisitSwitchStatementBegin(TestLexerModeParser.SwitchStatementBeginContext context)
			{
				if (context == null) return SwitchStatementBeginGreen.__Missing;
				InternalSyntaxToken kSwitch = (InternalSyntaxToken)this.VisitTerminal(context.KSwitch(), TestLexerModeSyntaxKind.KSwitch);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.SwitchStatementBegin(kSwitch, tOpenParenthesis, expression, tCloseParenthesis);
			}
			
			public override GreenNode VisitSwitchStatementEnd(TestLexerModeParser.SwitchStatementEndContext context)
			{
				if (context == null) return SwitchStatementEndGreen.__Missing;
				InternalSyntaxToken kEnd = (InternalSyntaxToken)this.VisitTerminal(context.KEnd(), TestLexerModeSyntaxKind.KEnd);
				InternalSyntaxToken kSwitch = (InternalSyntaxToken)this.VisitTerminal(context.KSwitch(), TestLexerModeSyntaxKind.KSwitch);
				return _factory.SwitchStatementEnd(kEnd, kSwitch);
			}
			
			public override GreenNode VisitSwitchBranchStatement(TestLexerModeParser.SwitchBranchStatementContext context)
			{
				if (context == null) return SwitchBranchStatementGreen.__Missing;
				TestLexerModeParser.SwitchBranchHeadStatementContext switchBranchHeadStatementContext = context.switchBranchHeadStatement();
				SwitchBranchHeadStatementGreen switchBranchHeadStatement = null;
				if (switchBranchHeadStatementContext != null) switchBranchHeadStatement = (SwitchBranchHeadStatementGreen)this.Visit(switchBranchHeadStatementContext);
				if (switchBranchHeadStatement == null) switchBranchHeadStatement = SwitchBranchHeadStatementGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
				return _factory.SwitchBranchStatement(switchBranchHeadStatement, body);
			}
			
			public override GreenNode VisitSwitchBranchHeadStatement(TestLexerModeParser.SwitchBranchHeadStatementContext context)
			{
				if (context == null) return SwitchBranchHeadStatementGreen.__Missing;
				TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementsContext switchCaseOrTypeIsHeadStatementsContext = context.switchCaseOrTypeIsHeadStatements();
				if (switchCaseOrTypeIsHeadStatementsContext != null) 
				{
					return _factory.SwitchBranchHeadStatement((SwitchCaseOrTypeIsHeadStatementsGreen)this.Visit(switchCaseOrTypeIsHeadStatementsContext));
				}
				TestLexerModeParser.SwitchTypeAsHeadStatementContext switchTypeAsHeadStatementContext = context.switchTypeAsHeadStatement();
				if (switchTypeAsHeadStatementContext != null) 
				{
					return _factory.SwitchBranchHeadStatement((SwitchTypeAsHeadStatementGreen)this.Visit(switchTypeAsHeadStatementContext));
				}
				return SwitchBranchHeadStatementGreen.__Missing;
			}
			
			public override GreenNode VisitSwitchCaseOrTypeIsHeadStatements(TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementsContext context)
			{
				if (context == null) return SwitchCaseOrTypeIsHeadStatementsGreen.__Missing;
			    TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementContext[] switchCaseOrTypeIsHeadStatementContext = context.switchCaseOrTypeIsHeadStatement();
			    var switchCaseOrTypeIsHeadStatementBuilder = _pool.Allocate<SwitchCaseOrTypeIsHeadStatementGreen>();
			    for (int i = 0; i < switchCaseOrTypeIsHeadStatementContext.Length; i++)
			    {
			        switchCaseOrTypeIsHeadStatementBuilder.Add((SwitchCaseOrTypeIsHeadStatementGreen)this.Visit(switchCaseOrTypeIsHeadStatementContext[i]));
			    }
				var switchCaseOrTypeIsHeadStatement = switchCaseOrTypeIsHeadStatementBuilder.ToList();
				_pool.Free(switchCaseOrTypeIsHeadStatementBuilder);
				return _factory.SwitchCaseOrTypeIsHeadStatements(switchCaseOrTypeIsHeadStatement);
			}
			
			public override GreenNode VisitSwitchCaseOrTypeIsHeadStatement(TestLexerModeParser.SwitchCaseOrTypeIsHeadStatementContext context)
			{
				if (context == null) return SwitchCaseOrTypeIsHeadStatementGreen.__Missing;
				TestLexerModeParser.SwitchCaseHeadStatementContext switchCaseHeadStatementContext = context.switchCaseHeadStatement();
				if (switchCaseHeadStatementContext != null) 
				{
					return _factory.SwitchCaseOrTypeIsHeadStatement((SwitchCaseHeadStatementGreen)this.Visit(switchCaseHeadStatementContext));
				}
				TestLexerModeParser.SwitchTypeIsHeadStatementContext switchTypeIsHeadStatementContext = context.switchTypeIsHeadStatement();
				if (switchTypeIsHeadStatementContext != null) 
				{
					return _factory.SwitchCaseOrTypeIsHeadStatement((SwitchTypeIsHeadStatementGreen)this.Visit(switchTypeIsHeadStatementContext));
				}
				return SwitchCaseOrTypeIsHeadStatementGreen.__Missing;
			}
			
			public override GreenNode VisitSwitchCaseHeadStatement(TestLexerModeParser.SwitchCaseHeadStatementContext context)
			{
				if (context == null) return SwitchCaseHeadStatementGreen.__Missing;
				InternalSyntaxToken kCase = (InternalSyntaxToken)this.VisitTerminal(context.KCase(), TestLexerModeSyntaxKind.KCase);
				TestLexerModeParser.ExpressionListContext expressionListContext = context.expressionList();
				ExpressionListGreen expressionList = null;
				if (expressionListContext != null) expressionList = (ExpressionListGreen)this.Visit(expressionListContext);
				if (expressionList == null) expressionList = ExpressionListGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), TestLexerModeSyntaxKind.TColon);
				return _factory.SwitchCaseHeadStatement(kCase, expressionList, tColon);
			}
			
			public override GreenNode VisitSwitchTypeIsHeadStatement(TestLexerModeParser.SwitchTypeIsHeadStatementContext context)
			{
				if (context == null) return SwitchTypeIsHeadStatementGreen.__Missing;
				InternalSyntaxToken kType = (InternalSyntaxToken)this.VisitTerminal(context.KType(), TestLexerModeSyntaxKind.KType);
				InternalSyntaxToken kIs = (InternalSyntaxToken)this.VisitTerminal(context.KIs(), TestLexerModeSyntaxKind.KIs);
				TestLexerModeParser.TypeReferenceListContext typeReferenceListContext = context.typeReferenceList();
				TypeReferenceListGreen typeReferenceList = null;
				if (typeReferenceListContext != null) typeReferenceList = (TypeReferenceListGreen)this.Visit(typeReferenceListContext);
				if (typeReferenceList == null) typeReferenceList = TypeReferenceListGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), TestLexerModeSyntaxKind.TColon);
				return _factory.SwitchTypeIsHeadStatement(kType, kIs, typeReferenceList, tColon);
			}
			
			public override GreenNode VisitSwitchTypeAsHeadStatement(TestLexerModeParser.SwitchTypeAsHeadStatementContext context)
			{
				if (context == null) return SwitchTypeAsHeadStatementGreen.__Missing;
				InternalSyntaxToken kType = (InternalSyntaxToken)this.VisitTerminal(context.KType(), TestLexerModeSyntaxKind.KType);
				InternalSyntaxToken kAs = (InternalSyntaxToken)this.VisitTerminal(context.KAs(), TestLexerModeSyntaxKind.KAs);
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), TestLexerModeSyntaxKind.TColon);
				return _factory.SwitchTypeAsHeadStatement(kType, kAs, typeReference, tColon);
			}
			
			public override GreenNode VisitSwitchDefaultStatement(TestLexerModeParser.SwitchDefaultStatementContext context)
			{
				if (context == null) return SwitchDefaultStatementGreen.__Missing;
				TestLexerModeParser.SwitchDefaultHeadStatementContext switchDefaultHeadStatementContext = context.switchDefaultHeadStatement();
				SwitchDefaultHeadStatementGreen switchDefaultHeadStatement = null;
				if (switchDefaultHeadStatementContext != null) switchDefaultHeadStatement = (SwitchDefaultHeadStatementGreen)this.Visit(switchDefaultHeadStatementContext);
				if (switchDefaultHeadStatement == null) switchDefaultHeadStatement = SwitchDefaultHeadStatementGreen.__Missing;
				TestLexerModeParser.BodyContext bodyContext = context.body();
				BodyGreen body = null;
				if (bodyContext != null) body = (BodyGreen)this.Visit(bodyContext);
				if (body == null) body = BodyGreen.__Missing;
				return _factory.SwitchDefaultStatement(switchDefaultHeadStatement, body);
			}
			
			public override GreenNode VisitSwitchDefaultHeadStatement(TestLexerModeParser.SwitchDefaultHeadStatementContext context)
			{
				if (context == null) return SwitchDefaultHeadStatementGreen.__Missing;
				InternalSyntaxToken kDefault = (InternalSyntaxToken)this.VisitTerminal(context.KDefault(), TestLexerModeSyntaxKind.KDefault);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), TestLexerModeSyntaxKind.TColon);
				return _factory.SwitchDefaultHeadStatement(kDefault, tColon);
			}
			
			public override GreenNode VisitTemplateDeclaration(TestLexerModeParser.TemplateDeclarationContext context)
			{
				if (context == null) return TemplateDeclarationGreen.__Missing;
				TestLexerModeParser.TemplateSignatureContext templateSignatureContext = context.templateSignature();
				TemplateSignatureGreen templateSignature = null;
				if (templateSignatureContext != null) templateSignature = (TemplateSignatureGreen)this.Visit(templateSignatureContext);
				if (templateSignature == null) templateSignature = TemplateSignatureGreen.__Missing;
				TestLexerModeParser.TemplateBodyContext templateBodyContext = context.templateBody();
				TemplateBodyGreen templateBody = null;
				if (templateBodyContext != null) templateBody = (TemplateBodyGreen)this.Visit(templateBodyContext);
				if (templateBody == null) templateBody = TemplateBodyGreen.__Missing;
				InternalSyntaxToken kEndTemplate = (InternalSyntaxToken)this.VisitTerminal(context.KEndTemplate(), TestLexerModeSyntaxKind.KEndTemplate);
				return _factory.TemplateDeclaration(templateSignature, templateBody, kEndTemplate);
			}
			
			public override GreenNode VisitTemplateSignature(TestLexerModeParser.TemplateSignatureContext context)
			{
				if (context == null) return TemplateSignatureGreen.__Missing;
				InternalSyntaxToken kTemplate = (InternalSyntaxToken)this.VisitTerminal(context.KTemplate(), TestLexerModeSyntaxKind.KTemplate);
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ParamListContext paramListContext = context.paramList();
				ParamListGreen paramList = null;
				if (paramListContext != null) paramList = (ParamListGreen)this.Visit(paramListContext);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.TemplateSignature(kTemplate, identifier, tOpenParenthesis, paramList, tCloseParenthesis);
			}
			
			public override GreenNode VisitTemplateBody(TestLexerModeParser.TemplateBodyContext context)
			{
				if (context == null) return TemplateBodyGreen.__Missing;
			    TestLexerModeParser.TemplateContentLineContext[] templateContentLineContext = context.templateContentLine();
			    var templateContentLineBuilder = _pool.Allocate<TemplateContentLineGreen>();
			    for (int i = 0; i < templateContentLineContext.Length; i++)
			    {
			        templateContentLineBuilder.Add((TemplateContentLineGreen)this.Visit(templateContentLineContext[i]));
			    }
				var templateContentLine = templateContentLineBuilder.ToList();
				_pool.Free(templateContentLineBuilder);
				return _factory.TemplateBody(templateContentLine);
			}
			
			public override GreenNode VisitTemplateContentLine(TestLexerModeParser.TemplateContentLineContext context)
			{
				if (context == null) return TemplateContentLineGreen.__Missing;
			    TestLexerModeParser.TemplateContentContext[] templateContentContext = context.templateContent();
			    var templateContentBuilder = _pool.Allocate<TemplateContentGreen>();
			    for (int i = 0; i < templateContentContext.Length; i++)
			    {
			        templateContentBuilder.Add((TemplateContentGreen)this.Visit(templateContentContext[i]));
			    }
				var templateContent = templateContentBuilder.ToList();
				_pool.Free(templateContentBuilder);
				TestLexerModeParser.TemplateLineEndContext templateLineEndContext = context.templateLineEnd();
				TemplateLineEndGreen templateLineEnd = null;
				if (templateLineEndContext != null) templateLineEnd = (TemplateLineEndGreen)this.Visit(templateLineEndContext);
				if (templateLineEnd == null) templateLineEnd = TemplateLineEndGreen.__Missing;
				return _factory.TemplateContentLine(templateContent, templateLineEnd);
			}
			
			public override GreenNode VisitTemplateContent(TestLexerModeParser.TemplateContentContext context)
			{
				if (context == null) return TemplateContentGreen.__Missing;
				TestLexerModeParser.TemplateOutputContext templateOutputContext = context.templateOutput();
				if (templateOutputContext != null) 
				{
					return _factory.TemplateContent((TemplateOutputGreen)this.Visit(templateOutputContext));
				}
				TestLexerModeParser.TemplateStatementStartEndContext templateStatementStartEndContext = context.templateStatementStartEnd();
				if (templateStatementStartEndContext != null) 
				{
					return _factory.TemplateContent((TemplateStatementStartEndGreen)this.Visit(templateStatementStartEndContext));
				}
				return TemplateContentGreen.__Missing;
			}
			
			public override GreenNode VisitTemplateOutput(TestLexerModeParser.TemplateOutputContext context)
			{
				if (context == null) return TemplateOutputGreen.__Missing;
				InternalSyntaxToken lTemplateOutput = (InternalSyntaxToken)this.VisitTerminal(context.LTemplateOutput(), TestLexerModeSyntaxKind.LTemplateOutput);
				return _factory.TemplateOutput(lTemplateOutput);
			}
			
			public override GreenNode VisitTemplateLineEnd(TestLexerModeParser.TemplateLineEndContext context)
			{
				if (context == null) return TemplateLineEndGreen.__Missing;
				InternalSyntaxToken templateLineEnd = null;
				if (context.LTemplateCrLf() != null)
				{
					templateLineEnd = (InternalSyntaxToken)this.VisitTerminal(context.LTemplateCrLf());
				}
				else 	if (context.LTemplateLineBreak() != null)
				{
					templateLineEnd = (InternalSyntaxToken)this.VisitTerminal(context.LTemplateLineBreak());
				}
				else 	if (context.LTemplateLineControl() != null)
				{
					templateLineEnd = (InternalSyntaxToken)this.VisitTerminal(context.LTemplateLineControl());
				}
				else
				{
					templateLineEnd = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.TemplateLineEnd(templateLineEnd);
			}
			
			public override GreenNode VisitTemplateStatementStartEnd(TestLexerModeParser.TemplateStatementStartEndContext context)
			{
				if (context == null) return TemplateStatementStartEndGreen.__Missing;
				InternalSyntaxToken tTemplateStatementStart = (InternalSyntaxToken)this.VisitTerminal(context.TTemplateStatementStart(), TestLexerModeSyntaxKind.TTemplateStatementStart);
				TestLexerModeParser.TemplateStatementContext templateStatementContext = context.templateStatement();
				TemplateStatementGreen templateStatement = null;
				if (templateStatementContext != null) templateStatement = (TemplateStatementGreen)this.Visit(templateStatementContext);
				InternalSyntaxToken tTemplateStatementEnd = (InternalSyntaxToken)this.VisitTerminal(context.TTemplateStatementEnd(), TestLexerModeSyntaxKind.TTemplateStatementEnd);
				return _factory.TemplateStatementStartEnd(tTemplateStatementStart, templateStatement, tTemplateStatementEnd);
			}
			
			public override GreenNode VisitTemplateStatement(TestLexerModeParser.TemplateStatementContext context)
			{
				if (context == null) return TemplateStatementGreen.__Missing;
				TestLexerModeParser.VoidStatementContext voidStatementContext = context.voidStatement();
				if (voidStatementContext != null) 
				{
					return _factory.TemplateStatement((VoidStatementGreen)this.Visit(voidStatementContext));
				}
				TestLexerModeParser.VariableDeclarationStatementContext variableDeclarationStatementContext = context.variableDeclarationStatement();
				if (variableDeclarationStatementContext != null) 
				{
					return _factory.TemplateStatement((VariableDeclarationStatementGreen)this.Visit(variableDeclarationStatementContext));
				}
				TestLexerModeParser.ExpressionStatementContext expressionStatementContext = context.expressionStatement();
				if (expressionStatementContext != null) 
				{
					return _factory.TemplateStatement((ExpressionStatementGreen)this.Visit(expressionStatementContext));
				}
				TestLexerModeParser.IfStatementBeginContext ifStatementBeginContext = context.ifStatementBegin();
				if (ifStatementBeginContext != null) 
				{
					return _factory.TemplateStatement((IfStatementBeginGreen)this.Visit(ifStatementBeginContext));
				}
				TestLexerModeParser.ElseIfStatementContext elseIfStatementContext = context.elseIfStatement();
				if (elseIfStatementContext != null) 
				{
					return _factory.TemplateStatement((ElseIfStatementGreen)this.Visit(elseIfStatementContext));
				}
				TestLexerModeParser.IfStatementElseContext ifStatementElseContext = context.ifStatementElse();
				if (ifStatementElseContext != null) 
				{
					return _factory.TemplateStatement((IfStatementElseGreen)this.Visit(ifStatementElseContext));
				}
				TestLexerModeParser.IfStatementEndContext ifStatementEndContext = context.ifStatementEnd();
				if (ifStatementEndContext != null) 
				{
					return _factory.TemplateStatement((IfStatementEndGreen)this.Visit(ifStatementEndContext));
				}
				TestLexerModeParser.ForStatementBeginContext forStatementBeginContext = context.forStatementBegin();
				if (forStatementBeginContext != null) 
				{
					return _factory.TemplateStatement((ForStatementBeginGreen)this.Visit(forStatementBeginContext));
				}
				TestLexerModeParser.ForStatementEndContext forStatementEndContext = context.forStatementEnd();
				if (forStatementEndContext != null) 
				{
					return _factory.TemplateStatement((ForStatementEndGreen)this.Visit(forStatementEndContext));
				}
				TestLexerModeParser.WhileStatementBeginContext whileStatementBeginContext = context.whileStatementBegin();
				if (whileStatementBeginContext != null) 
				{
					return _factory.TemplateStatement((WhileStatementBeginGreen)this.Visit(whileStatementBeginContext));
				}
				TestLexerModeParser.WhileStatementEndContext whileStatementEndContext = context.whileStatementEnd();
				if (whileStatementEndContext != null) 
				{
					return _factory.TemplateStatement((WhileStatementEndGreen)this.Visit(whileStatementEndContext));
				}
				TestLexerModeParser.RepeatStatementBeginContext repeatStatementBeginContext = context.repeatStatementBegin();
				if (repeatStatementBeginContext != null) 
				{
					return _factory.TemplateStatement((RepeatStatementBeginGreen)this.Visit(repeatStatementBeginContext));
				}
				TestLexerModeParser.RepeatStatementEndContext repeatStatementEndContext = context.repeatStatementEnd();
				if (repeatStatementEndContext != null) 
				{
					return _factory.TemplateStatement((RepeatStatementEndGreen)this.Visit(repeatStatementEndContext));
				}
				TestLexerModeParser.LoopStatementBeginContext loopStatementBeginContext = context.loopStatementBegin();
				if (loopStatementBeginContext != null) 
				{
					return _factory.TemplateStatement((LoopStatementBeginGreen)this.Visit(loopStatementBeginContext));
				}
				TestLexerModeParser.LoopStatementEndContext loopStatementEndContext = context.loopStatementEnd();
				if (loopStatementEndContext != null) 
				{
					return _factory.TemplateStatement((LoopStatementEndGreen)this.Visit(loopStatementEndContext));
				}
				TestLexerModeParser.SwitchStatementBeginContext switchStatementBeginContext = context.switchStatementBegin();
				if (switchStatementBeginContext != null) 
				{
					return _factory.TemplateStatement((SwitchStatementBeginGreen)this.Visit(switchStatementBeginContext));
				}
				TestLexerModeParser.SwitchStatementEndContext switchStatementEndContext = context.switchStatementEnd();
				if (switchStatementEndContext != null) 
				{
					return _factory.TemplateStatement((SwitchStatementEndGreen)this.Visit(switchStatementEndContext));
				}
				TestLexerModeParser.SwitchBranchHeadStatementContext switchBranchHeadStatementContext = context.switchBranchHeadStatement();
				if (switchBranchHeadStatementContext != null) 
				{
					return _factory.TemplateStatement((SwitchBranchHeadStatementGreen)this.Visit(switchBranchHeadStatementContext));
				}
				TestLexerModeParser.SwitchDefaultHeadStatementContext switchDefaultHeadStatementContext = context.switchDefaultHeadStatement();
				if (switchDefaultHeadStatementContext != null) 
				{
					return _factory.TemplateStatement((SwitchDefaultHeadStatementGreen)this.Visit(switchDefaultHeadStatementContext));
				}
				return TemplateStatementGreen.__Missing;
			}
			
			public override GreenNode VisitTypeArgumentList(TestLexerModeParser.TypeArgumentListContext context)
			{
				if (context == null) return TypeArgumentListGreen.__Missing;
				InternalSyntaxToken tLessThan = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan(), TestLexerModeSyntaxKind.TLessThan);
				TestLexerModeParser.TypeReferenceListContext typeReferenceListContext = context.typeReferenceList();
				TypeReferenceListGreen typeReferenceList = null;
				if (typeReferenceListContext != null) typeReferenceList = (TypeReferenceListGreen)this.Visit(typeReferenceListContext);
				if (typeReferenceList == null) typeReferenceList = TypeReferenceListGreen.__Missing;
				InternalSyntaxToken tGreaterThan = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan(), TestLexerModeSyntaxKind.TGreaterThan);
				return _factory.TypeArgumentList(tLessThan, typeReferenceList, tGreaterThan);
			}
			
			public override GreenNode VisitPredefinedType(TestLexerModeParser.PredefinedTypeContext context)
			{
				if (context == null) return PredefinedTypeGreen.__Missing;
				InternalSyntaxToken predefinedType = null;
				if (context.KBool() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KBool());
				}
				else 	if (context.KByte() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KByte());
				}
				else 	if (context.KChar() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KChar());
				}
				else 	if (context.KDecimal() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KDecimal());
				}
				else 	if (context.KDouble() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KDouble());
				}
				else 	if (context.KFloat() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KFloat());
				}
				else 	if (context.KInt() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KInt());
				}
				else 	if (context.KLong() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KLong());
				}
				else 	if (context.KObject() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KObject());
				}
				else 	if (context.KSByte() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KSByte());
				}
				else 	if (context.KShort() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KShort());
				}
				else 	if (context.KString() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KString());
				}
				else 	if (context.KUInt() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KUInt());
				}
				else 	if (context.KULong() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KULong());
				}
				else 	if (context.KUShort() != null)
				{
					predefinedType = (InternalSyntaxToken)this.VisitTerminal(context.KUShort());
				}
				else
				{
					predefinedType = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.PredefinedType(predefinedType);
			}
			
			public override GreenNode VisitTypeReferenceList(TestLexerModeParser.TypeReferenceListContext context)
			{
				if (context == null) return TypeReferenceListGreen.__Missing;
			    TestLexerModeParser.TypeReferenceContext[] typeReferenceContext = context.typeReference();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var typeReferenceBuilder = _pool.AllocateSeparated<TypeReferenceGreen>();
			    for (int i = 0; i < typeReferenceContext.Length; i++)
			    {
			        typeReferenceBuilder.Add((TypeReferenceGreen)this.Visit(typeReferenceContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            typeReferenceBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestLexerModeSyntaxKind.TComma));
			        }
			    }
				var typeReference = typeReferenceBuilder.ToList();
				_pool.Free(typeReferenceBuilder);
				return _factory.TypeReferenceList(typeReference);
			}
			
			public override GreenNode VisitTypeReference(TestLexerModeParser.TypeReferenceContext context)
			{
				if (context == null) return TypeReferenceGreen.__Missing;
				TestLexerModeParser.ArrayTypeContext arrayTypeContext = context.arrayType();
				if (arrayTypeContext != null) 
				{
					return _factory.TypeReference((ArrayTypeGreen)this.Visit(arrayTypeContext));
				}
				TestLexerModeParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					return _factory.TypeReference((NullableTypeGreen)this.Visit(nullableTypeContext));
				}
				TestLexerModeParser.GenericTypeContext genericTypeContext = context.genericType();
				if (genericTypeContext != null) 
				{
					return _factory.TypeReference((GenericTypeGreen)this.Visit(genericTypeContext));
				}
				TestLexerModeParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return _factory.TypeReference((SimpleTypeGreen)this.Visit(simpleTypeContext));
				}
				return TypeReferenceGreen.__Missing;
			}
			
			public override GreenNode VisitArrayType(TestLexerModeParser.ArrayTypeContext context)
			{
				if (context == null) return ArrayTypeGreen.__Missing;
				TestLexerModeParser.ArrayItemTypeContext arrayItemTypeContext = context.arrayItemType();
				ArrayItemTypeGreen arrayItemType = null;
				if (arrayItemTypeContext != null) arrayItemType = (ArrayItemTypeGreen)this.Visit(arrayItemTypeContext);
				if (arrayItemType == null) arrayItemType = ArrayItemTypeGreen.__Missing;
				TestLexerModeParser.RankSpecifiersContext rankSpecifiersContext = context.rankSpecifiers();
				RankSpecifiersGreen rankSpecifiers = null;
				if (rankSpecifiersContext != null) rankSpecifiers = (RankSpecifiersGreen)this.Visit(rankSpecifiersContext);
				if (rankSpecifiers == null) rankSpecifiers = RankSpecifiersGreen.__Missing;
				return _factory.ArrayType(arrayItemType, rankSpecifiers);
			}
			
			public override GreenNode VisitArrayItemType(TestLexerModeParser.ArrayItemTypeContext context)
			{
				if (context == null) return ArrayItemTypeGreen.__Missing;
				TestLexerModeParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					return _factory.ArrayItemType((NullableTypeGreen)this.Visit(nullableTypeContext));
				}
				TestLexerModeParser.GenericTypeContext genericTypeContext = context.genericType();
				if (genericTypeContext != null) 
				{
					return _factory.ArrayItemType((GenericTypeGreen)this.Visit(genericTypeContext));
				}
				TestLexerModeParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return _factory.ArrayItemType((SimpleTypeGreen)this.Visit(simpleTypeContext));
				}
				return ArrayItemTypeGreen.__Missing;
			}
			
			public override GreenNode VisitNullableType(TestLexerModeParser.NullableTypeContext context)
			{
				if (context == null) return NullableTypeGreen.__Missing;
				TestLexerModeParser.NullableItemTypeContext nullableItemTypeContext = context.nullableItemType();
				NullableItemTypeGreen nullableItemType = null;
				if (nullableItemTypeContext != null) nullableItemType = (NullableItemTypeGreen)this.Visit(nullableItemTypeContext);
				if (nullableItemType == null) nullableItemType = NullableItemTypeGreen.__Missing;
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion(), TestLexerModeSyntaxKind.TQuestion);
				return _factory.NullableType(nullableItemType, tQuestion);
			}
			
			public override GreenNode VisitNullableItemType(TestLexerModeParser.NullableItemTypeContext context)
			{
				if (context == null) return NullableItemTypeGreen.__Missing;
				TestLexerModeParser.GenericTypeContext genericTypeContext = context.genericType();
				if (genericTypeContext != null) 
				{
					return _factory.NullableItemType((GenericTypeGreen)this.Visit(genericTypeContext));
				}
				TestLexerModeParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return _factory.NullableItemType((SimpleTypeGreen)this.Visit(simpleTypeContext));
				}
				return NullableItemTypeGreen.__Missing;
			}
			
			public override GreenNode VisitGenericType(TestLexerModeParser.GenericTypeContext context)
			{
				if (context == null) return GenericTypeGreen.__Missing;
				TestLexerModeParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null) qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				if (qualifiedName == null) qualifiedName = QualifiedNameGreen.__Missing;
				TestLexerModeParser.TypeArgumentListContext typeArgumentListContext = context.typeArgumentList();
				TypeArgumentListGreen typeArgumentList = null;
				if (typeArgumentListContext != null) typeArgumentList = (TypeArgumentListGreen)this.Visit(typeArgumentListContext);
				if (typeArgumentList == null) typeArgumentList = TypeArgumentListGreen.__Missing;
				return _factory.GenericType(qualifiedName, typeArgumentList);
			}
			
			public override GreenNode VisitSimpleType(TestLexerModeParser.SimpleTypeContext context)
			{
				if (context == null) return SimpleTypeGreen.__Missing;
				TestLexerModeParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				if (qualifiedNameContext != null) 
				{
					return _factory.SimpleType((QualifiedNameGreen)this.Visit(qualifiedNameContext));
				}
				TestLexerModeParser.PredefinedTypeContext predefinedTypeContext = context.predefinedType();
				if (predefinedTypeContext != null) 
				{
					return _factory.SimpleType((PredefinedTypeGreen)this.Visit(predefinedTypeContext));
				}
				return SimpleTypeGreen.__Missing;
			}
			
			public override GreenNode VisitVoidType(TestLexerModeParser.VoidTypeContext context)
			{
				if (context == null) return VoidTypeGreen.__Missing;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid(), TestLexerModeSyntaxKind.KVoid);
				return _factory.VoidType(kVoid);
			}
			
			public override GreenNode VisitReturnType(TestLexerModeParser.ReturnTypeContext context)
			{
				if (context == null) return ReturnTypeGreen.__Missing;
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return _factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext));
				}
				TestLexerModeParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return _factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext));
				}
				return ReturnTypeGreen.__Missing;
			}
			
			public override GreenNode VisitExpressionList(TestLexerModeParser.ExpressionListContext context)
			{
				if (context == null) return ExpressionListGreen.__Missing;
			    TestLexerModeParser.ExpressionContext[] expressionContext = context.expression();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var expressionBuilder = _pool.AllocateSeparated<ExpressionGreen>();
			    for (int i = 0; i < expressionContext.Length; i++)
			    {
			        expressionBuilder.Add((ExpressionGreen)this.Visit(expressionContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            expressionBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestLexerModeSyntaxKind.TComma));
			        }
			    }
				var expression = expressionBuilder.ToList();
				_pool.Free(expressionBuilder);
				return _factory.ExpressionList(expression);
			}
			
			public override GreenNode VisitVariableReference(TestLexerModeParser.VariableReferenceContext context)
			{
				if (context == null) return VariableReferenceGreen.__Missing;
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.VariableReference(expression);
			}
			
			public override GreenNode VisitRankSpecifiers(TestLexerModeParser.RankSpecifiersContext context)
			{
				if (context == null) return RankSpecifiersGreen.__Missing;
			    TestLexerModeParser.RankSpecifierContext[] rankSpecifierContext = context.rankSpecifier();
			    var rankSpecifierBuilder = _pool.Allocate<RankSpecifierGreen>();
			    for (int i = 0; i < rankSpecifierContext.Length; i++)
			    {
			        rankSpecifierBuilder.Add((RankSpecifierGreen)this.Visit(rankSpecifierContext[i]));
			    }
				var rankSpecifier = rankSpecifierBuilder.ToList();
				_pool.Free(rankSpecifierBuilder);
				return _factory.RankSpecifiers(rankSpecifier);
			}
			
			public override GreenNode VisitRankSpecifier(TestLexerModeParser.RankSpecifierContext context)
			{
				if (context == null) return RankSpecifierGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), TestLexerModeSyntaxKind.TOpenBracket);
			    ITerminalNode[] tCommaContext = context.TComma();
			    var tCommaBuilder = _pool.Allocate<InternalSyntaxToken>();
			    for (int i = 0; i < tCommaContext.Length; i++)
			    {
			        tCommaBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestLexerModeSyntaxKind.TComma));
			    }
				var tComma = tCommaBuilder.ToList();
				_pool.Free(tCommaBuilder);
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), TestLexerModeSyntaxKind.TCloseBracket);
				return _factory.RankSpecifier(tOpenBracket, tComma, tCloseBracket);
			}
			
			public override GreenNode VisitUnboundTypeName(TestLexerModeParser.UnboundTypeNameContext context)
			{
				if (context == null) return UnboundTypeNameGreen.__Missing;
			    TestLexerModeParser.GenericDimensionItemContext[] genericDimensionItemContext = context.genericDimensionItem();
			    ITerminalNode[] tDotContext = context.TDot();
			    var genericDimensionItemBuilder = _pool.AllocateSeparated<GenericDimensionItemGreen>();
			    for (int i = 0; i < genericDimensionItemContext.Length; i++)
			    {
			        genericDimensionItemBuilder.Add((GenericDimensionItemGreen)this.Visit(genericDimensionItemContext[i]));
			        if (i < tDotContext.Length)
			        {
			            genericDimensionItemBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], TestLexerModeSyntaxKind.TDot));
			        }
			    }
				var genericDimensionItem = genericDimensionItemBuilder.ToList();
				_pool.Free(genericDimensionItemBuilder);
				return _factory.UnboundTypeName(genericDimensionItem);
			}
			
			public override GreenNode VisitGenericDimensionItem(TestLexerModeParser.GenericDimensionItemContext context)
			{
				if (context == null) return GenericDimensionItemGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				TestLexerModeParser.GenericDimensionSpecifierContext genericDimensionSpecifierContext = context.genericDimensionSpecifier();
				GenericDimensionSpecifierGreen genericDimensionSpecifier = null;
				if (genericDimensionSpecifierContext != null) genericDimensionSpecifier = (GenericDimensionSpecifierGreen)this.Visit(genericDimensionSpecifierContext);
				return _factory.GenericDimensionItem(identifier, genericDimensionSpecifier);
			}
			
			public override GreenNode VisitGenericDimensionSpecifier(TestLexerModeParser.GenericDimensionSpecifierContext context)
			{
				if (context == null) return GenericDimensionSpecifierGreen.__Missing;
				InternalSyntaxToken tLessThan = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan(), TestLexerModeSyntaxKind.TLessThan);
			    ITerminalNode[] tCommaContext = context.TComma();
			    var tCommaBuilder = _pool.Allocate<InternalSyntaxToken>();
			    for (int i = 0; i < tCommaContext.Length; i++)
			    {
			        tCommaBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestLexerModeSyntaxKind.TComma));
			    }
				var tComma = tCommaBuilder.ToList();
				_pool.Free(tCommaBuilder);
				InternalSyntaxToken tGreaterThan = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan(), TestLexerModeSyntaxKind.TGreaterThan);
				return _factory.GenericDimensionSpecifier(tLessThan, tComma, tGreaterThan);
			}
			
			public override GreenNode VisitExplicitAnonymousFunctionSignature(TestLexerModeParser.ExplicitAnonymousFunctionSignatureContext context)
			{
				if (context == null) return ExplicitAnonymousFunctionSignatureGreen.__Missing;
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
			    TestLexerModeParser.ExplicitParameterContext[] explicitParameterContext = context.explicitParameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var explicitParameterBuilder = _pool.AllocateSeparated<ExplicitParameterGreen>();
			    for (int i = 0; i < explicitParameterContext.Length; i++)
			    {
			        explicitParameterBuilder.Add((ExplicitParameterGreen)this.Visit(explicitParameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            explicitParameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestLexerModeSyntaxKind.TComma));
			        }
			    }
				var explicitParameter = explicitParameterBuilder.ToList();
				_pool.Free(explicitParameterBuilder);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.ExplicitAnonymousFunctionSignature(tOpenParenthesis, explicitParameter, tCloseParenthesis);
			}
			
			public override GreenNode VisitImplicitAnonymousFunctionSignature(TestLexerModeParser.ImplicitAnonymousFunctionSignatureContext context)
			{
				if (context == null) return ImplicitAnonymousFunctionSignatureGreen.__Missing;
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
			    TestLexerModeParser.ImplicitParameterContext[] implicitParameterContext = context.implicitParameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var implicitParameterBuilder = _pool.AllocateSeparated<ImplicitParameterGreen>();
			    for (int i = 0; i < implicitParameterContext.Length; i++)
			    {
			        implicitParameterBuilder.Add((ImplicitParameterGreen)this.Visit(implicitParameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            implicitParameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestLexerModeSyntaxKind.TComma));
			        }
			    }
				var implicitParameter = implicitParameterBuilder.ToList();
				_pool.Free(implicitParameterBuilder);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.ImplicitAnonymousFunctionSignature(tOpenParenthesis, implicitParameter, tCloseParenthesis);
			}
			
			public override GreenNode VisitSingleParamAnonymousFunctionSignature(TestLexerModeParser.SingleParamAnonymousFunctionSignatureContext context)
			{
				if (context == null) return SingleParamAnonymousFunctionSignatureGreen.__Missing;
				TestLexerModeParser.ImplicitParameterContext implicitParameterContext = context.implicitParameter();
				ImplicitParameterGreen implicitParameter = null;
				if (implicitParameterContext != null) implicitParameter = (ImplicitParameterGreen)this.Visit(implicitParameterContext);
				if (implicitParameter == null) implicitParameter = ImplicitParameterGreen.__Missing;
				return _factory.SingleParamAnonymousFunctionSignature(implicitParameter);
			}
			
			public override GreenNode VisitExplicitParameter(TestLexerModeParser.ExplicitParameterContext context)
			{
				if (context == null) return ExplicitParameterGreen.__Missing;
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.ExplicitParameter(typeReference, identifier);
			}
			
			public override GreenNode VisitImplicitParameter(TestLexerModeParser.ImplicitParameterContext context)
			{
				if (context == null) return ImplicitParameterGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.ImplicitParameter(identifier);
			}
			
			public override GreenNode VisitThisExpression(TestLexerModeParser.ThisExpressionContext context)
			{
				if (context == null) return ThisExpressionGreen.__Missing;
				InternalSyntaxToken kThis = (InternalSyntaxToken)this.VisitTerminal(context.KThis(), TestLexerModeSyntaxKind.KThis);
				return _factory.ThisExpression(kThis);
			}
			
			public override GreenNode VisitLiteralExpression(TestLexerModeParser.LiteralExpressionContext context)
			{
				if (context == null) return LiteralExpressionGreen.__Missing;
				TestLexerModeParser.LiteralContext literalContext = context.literal();
				LiteralGreen literal = null;
				if (literalContext != null) literal = (LiteralGreen)this.Visit(literalContext);
				if (literal == null) literal = LiteralGreen.__Missing;
				return _factory.LiteralExpression(literal);
			}
			
			public override GreenNode VisitTypeofVoidExpression(TestLexerModeParser.TypeofVoidExpressionContext context)
			{
				if (context == null) return TypeofVoidExpressionGreen.__Missing;
				InternalSyntaxToken kTypeof = (InternalSyntaxToken)this.VisitTerminal(context.KTypeof(), TestLexerModeSyntaxKind.KTypeof);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid(), TestLexerModeSyntaxKind.KVoid);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.TypeofVoidExpression(kTypeof, tOpenParenthesis, kVoid, tCloseParenthesis);
			}
			
			public override GreenNode VisitTypeofUnboundTypeExpression(TestLexerModeParser.TypeofUnboundTypeExpressionContext context)
			{
				if (context == null) return TypeofUnboundTypeExpressionGreen.__Missing;
				InternalSyntaxToken kTypeof = (InternalSyntaxToken)this.VisitTerminal(context.KTypeof(), TestLexerModeSyntaxKind.KTypeof);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.UnboundTypeNameContext unboundTypeNameContext = context.unboundTypeName();
				UnboundTypeNameGreen unboundTypeName = null;
				if (unboundTypeNameContext != null) unboundTypeName = (UnboundTypeNameGreen)this.Visit(unboundTypeNameContext);
				if (unboundTypeName == null) unboundTypeName = UnboundTypeNameGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.TypeofUnboundTypeExpression(kTypeof, tOpenParenthesis, unboundTypeName, tCloseParenthesis);
			}
			
			public override GreenNode VisitTypeofTypeExpression(TestLexerModeParser.TypeofTypeExpressionContext context)
			{
				if (context == null) return TypeofTypeExpressionGreen.__Missing;
				InternalSyntaxToken kTypeof = (InternalSyntaxToken)this.VisitTerminal(context.KTypeof(), TestLexerModeSyntaxKind.KTypeof);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.TypeofTypeExpression(kTypeof, tOpenParenthesis, typeReference, tCloseParenthesis);
			}
			
			public override GreenNode VisitDefaultValueExpression(TestLexerModeParser.DefaultValueExpressionContext context)
			{
				if (context == null) return DefaultValueExpressionGreen.__Missing;
				InternalSyntaxToken kDefault = (InternalSyntaxToken)this.VisitTerminal(context.KDefault(), TestLexerModeSyntaxKind.KDefault);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.DefaultValueExpression(kDefault, tOpenParenthesis, typeReference, tCloseParenthesis);
			}
			
			public override GreenNode VisitNewObjectOrCollectionWithConstructorExpression(TestLexerModeParser.NewObjectOrCollectionWithConstructorExpressionContext context)
			{
				if (context == null) return NewObjectOrCollectionWithConstructorExpressionGreen.__Missing;
				InternalSyntaxToken kNew = (InternalSyntaxToken)this.VisitTerminal(context.KNew(), TestLexerModeSyntaxKind.KNew);
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ExpressionListContext expressionListContext = context.expressionList();
				ExpressionListGreen expressionList = null;
				if (expressionListContext != null) expressionList = (ExpressionListGreen)this.Visit(expressionListContext);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.NewObjectOrCollectionWithConstructorExpression(kNew, typeReference, tOpenParenthesis, expressionList, tCloseParenthesis);
			}
			
			public override GreenNode VisitIdentifierExpression(TestLexerModeParser.IdentifierExpressionContext context)
			{
				if (context == null) return IdentifierExpressionGreen.__Missing;
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				TestLexerModeParser.TypeArgumentListContext typeArgumentListContext = context.typeArgumentList();
				TypeArgumentListGreen typeArgumentList = null;
				if (typeArgumentListContext != null) typeArgumentList = (TypeArgumentListGreen)this.Visit(typeArgumentListContext);
				return _factory.IdentifierExpression(identifier, typeArgumentList);
			}
			
			public override GreenNode VisitHasLoopExpression(TestLexerModeParser.HasLoopExpressionContext context)
			{
				if (context == null) return HasLoopExpressionGreen.__Missing;
				InternalSyntaxToken kHasLoop = (InternalSyntaxToken)this.VisitTerminal(context.KHasLoop(), TestLexerModeSyntaxKind.KHasLoop);
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.LoopChainContext loopChainContext = context.loopChain();
				LoopChainGreen loopChain = null;
				if (loopChainContext != null) loopChain = (LoopChainGreen)this.Visit(loopChainContext);
				if (loopChain == null) loopChain = LoopChainGreen.__Missing;
				TestLexerModeParser.LoopWhereExpressionContext loopWhereExpressionContext = context.loopWhereExpression();
				LoopWhereExpressionGreen loopWhereExpression = null;
				if (loopWhereExpressionContext != null) loopWhereExpression = (LoopWhereExpressionGreen)this.Visit(loopWhereExpressionContext);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.HasLoopExpression(kHasLoop, tOpenParenthesis, loopChain, loopWhereExpression, tCloseParenthesis);
			}
			
			public override GreenNode VisitParenthesizedExpression(TestLexerModeParser.ParenthesizedExpressionContext context)
			{
				if (context == null) return ParenthesizedExpressionGreen.__Missing;
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.ParenthesizedExpression(tOpenParenthesis, expression, tCloseParenthesis);
			}
			
			public override GreenNode VisitElementAccessExpression(TestLexerModeParser.ElementAccessExpressionContext context)
			{
				if (context == null) return ElementAccessExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), TestLexerModeSyntaxKind.TOpenBracket);
				TestLexerModeParser.ExpressionListContext expressionListContext = context.expressionList();
				ExpressionListGreen expressionList = null;
				if (expressionListContext != null) expressionList = (ExpressionListGreen)this.Visit(expressionListContext);
				if (expressionList == null) expressionList = ExpressionListGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), TestLexerModeSyntaxKind.TCloseBracket);
				return _factory.ElementAccessExpression(expression, tOpenBracket, expressionList, tCloseBracket);
			}
			
			public override GreenNode VisitFunctionCallExpression(TestLexerModeParser.FunctionCallExpressionContext context)
			{
				if (context == null) return FunctionCallExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.ExpressionListContext expressionListContext = context.expressionList();
				ExpressionListGreen expressionList = null;
				if (expressionListContext != null) expressionList = (ExpressionListGreen)this.Visit(expressionListContext);
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				return _factory.FunctionCallExpression(expression, tOpenParenthesis, expressionList, tCloseParenthesis);
			}
			
			public override GreenNode VisitPredefinedTypeMemberAccessExpression(TestLexerModeParser.PredefinedTypeMemberAccessExpressionContext context)
			{
				if (context == null) return PredefinedTypeMemberAccessExpressionGreen.__Missing;
				TestLexerModeParser.PredefinedTypeContext predefinedTypeContext = context.predefinedType();
				PredefinedTypeGreen predefinedType = null;
				if (predefinedTypeContext != null) predefinedType = (PredefinedTypeGreen)this.Visit(predefinedTypeContext);
				if (predefinedType == null) predefinedType = PredefinedTypeGreen.__Missing;
				InternalSyntaxToken tDot = (InternalSyntaxToken)this.VisitTerminal(context.TDot(), TestLexerModeSyntaxKind.TDot);
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				TestLexerModeParser.TypeArgumentListContext typeArgumentListContext = context.typeArgumentList();
				TypeArgumentListGreen typeArgumentList = null;
				if (typeArgumentListContext != null) typeArgumentList = (TypeArgumentListGreen)this.Visit(typeArgumentListContext);
				return _factory.PredefinedTypeMemberAccessExpression(predefinedType, tDot, identifier, typeArgumentList);
			}
			
			public override GreenNode VisitMemberAccessExpression(TestLexerModeParser.MemberAccessExpressionContext context)
			{
				if (context == null) return MemberAccessExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken tDot = (InternalSyntaxToken)this.VisitTerminal(context.TDot(), TestLexerModeSyntaxKind.TDot);
				TestLexerModeParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				TestLexerModeParser.TypeArgumentListContext typeArgumentListContext = context.typeArgumentList();
				TypeArgumentListGreen typeArgumentList = null;
				if (typeArgumentListContext != null) typeArgumentList = (TypeArgumentListGreen)this.Visit(typeArgumentListContext);
				return _factory.MemberAccessExpression(expression, tDot, identifier, typeArgumentList);
			}
			
			public override GreenNode VisitTypecastExpression(TestLexerModeParser.TypecastExpressionContext context)
			{
				if (context == null) return TypecastExpressionGreen.__Missing;
				InternalSyntaxToken tOpenParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParenthesis(), TestLexerModeSyntaxKind.TOpenParenthesis);
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tCloseParenthesis = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParenthesis(), TestLexerModeSyntaxKind.TCloseParenthesis);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.TypecastExpression(tOpenParenthesis, typeReference, tCloseParenthesis, expression);
			}
			
			public override GreenNode VisitUnaryExpression(TestLexerModeParser.UnaryExpressionContext context)
			{
				if (context == null) return UnaryExpressionGreen.__Missing;
				InternalSyntaxToken op = null;
				if (context.TPlus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TPlus());
				}
				else 	if (context.TMinus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TMinus());
				}
				else 	if (context.TExclamation() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation());
				}
				else 	if (context.TTilde() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TTilde());
				}
				else 	if (context.TPlusPlus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TPlusPlus());
				}
				else 	if (context.TMinusMinus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TMinusMinus());
				}
				else
				{
					op = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.UnaryExpression(op, expression);
			}
			
			public override GreenNode VisitPostExpression(TestLexerModeParser.PostExpressionContext context)
			{
				if (context == null) return PostExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				InternalSyntaxToken op = null;
				if (context.TPlusPlus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TPlusPlus());
				}
				else 	if (context.TMinusMinus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TMinusMinus());
				}
				else
				{
					op = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.PostExpression(expression, op);
			}
			
			public override GreenNode VisitMultiplicationExpression(TestLexerModeParser.MultiplicationExpressionContext context)
			{
				if (context == null) return MultiplicationExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken op = null;
				if (context.TAsterisk() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAsterisk());
				}
				else 	if (context.TSlash() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TSlash());
				}
				else 	if (context.TPercent() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TPercent());
				}
				else
				{
					op = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.MultiplicationExpression(left, op, right);
			}
			
			public override GreenNode VisitAdditionExpression(TestLexerModeParser.AdditionExpressionContext context)
			{
				if (context == null) return AdditionExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken op = null;
				if (context.TPlus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TPlus());
				}
				else 	if (context.TMinus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TMinus());
				}
				else
				{
					op = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.AdditionExpression(left, op, right);
			}
			
			public override GreenNode VisitRelationalExpression(TestLexerModeParser.RelationalExpressionContext context)
			{
				if (context == null) return RelationalExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken op = null;
				if (context.TLessThan() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan());
				}
				else 	if (context.TGreaterThan() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan());
				}
				else 	if (context.TLessThanOrEquals() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TLessThanOrEquals());
				}
				else 	if (context.TGreaterThanOrEquals() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThanOrEquals());
				}
				else
				{
					op = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.RelationalExpression(left, op, right);
			}
			
			public override GreenNode VisitTypecheckExpression(TestLexerModeParser.TypecheckExpressionContext context)
			{
				if (context == null) return TypecheckExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken op = null;
				if (context.KIs() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.KIs());
				}
				else 	if (context.KAs() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.KAs());
				}
				else
				{
					op = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				TestLexerModeParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				return _factory.TypecheckExpression(left, op, typeReference);
			}
			
			public override GreenNode VisitEqualityExpression(TestLexerModeParser.EqualityExpressionContext context)
			{
				if (context == null) return EqualityExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken op = null;
				if (context.TEquals() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TEquals());
				}
				else 	if (context.TNotEquals() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TNotEquals());
				}
				else
				{
					op = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.EqualityExpression(left, op, right);
			}
			
			public override GreenNode VisitBitwiseAndExpression(TestLexerModeParser.BitwiseAndExpressionContext context)
			{
				if (context == null) return BitwiseAndExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tAmp = (InternalSyntaxToken)this.VisitTerminal(context.TAmp(), TestLexerModeSyntaxKind.TAmp);
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.BitwiseAndExpression(left, tAmp, right);
			}
			
			public override GreenNode VisitBitwiseXorExpression(TestLexerModeParser.BitwiseXorExpressionContext context)
			{
				if (context == null) return BitwiseXorExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tHat = (InternalSyntaxToken)this.VisitTerminal(context.THat(), TestLexerModeSyntaxKind.THat);
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.BitwiseXorExpression(left, tHat, right);
			}
			
			public override GreenNode VisitBitwiseOrExpression(TestLexerModeParser.BitwiseOrExpressionContext context)
			{
				if (context == null) return BitwiseOrExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tPipe = (InternalSyntaxToken)this.VisitTerminal(context.TPipe(), TestLexerModeSyntaxKind.TPipe);
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.BitwiseOrExpression(left, tPipe, right);
			}
			
			public override GreenNode VisitLogicalAndExpression(TestLexerModeParser.LogicalAndExpressionContext context)
			{
				if (context == null) return LogicalAndExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tAnd = (InternalSyntaxToken)this.VisitTerminal(context.TAnd(), TestLexerModeSyntaxKind.TAnd);
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.LogicalAndExpression(left, tAnd, right);
			}
			
			public override GreenNode VisitLogicalXorExpression(TestLexerModeParser.LogicalXorExpressionContext context)
			{
				if (context == null) return LogicalXorExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tXor = (InternalSyntaxToken)this.VisitTerminal(context.TXor(), TestLexerModeSyntaxKind.TXor);
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.LogicalXorExpression(left, tXor, right);
			}
			
			public override GreenNode VisitLogicalOrExpression(TestLexerModeParser.LogicalOrExpressionContext context)
			{
				if (context == null) return LogicalOrExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken tOr = (InternalSyntaxToken)this.VisitTerminal(context.TOr(), TestLexerModeSyntaxKind.TOr);
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.LogicalOrExpression(left, tOr, right);
			}
			
			public override GreenNode VisitConditionalExpression(TestLexerModeParser.ConditionalExpressionContext context)
			{
				if (context == null) return ConditionalExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext conditionContext = context.condition;
				ExpressionGreen condition = null;
				if (conditionContext != null) condition = (ExpressionGreen)this.Visit(conditionContext);
				if (condition == null) condition = ExpressionGreen.__Missing;
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion(), TestLexerModeSyntaxKind.TQuestion);
				TestLexerModeParser.ExpressionContext thenBranchContext = context.thenBranch;
				ExpressionGreen thenBranch = null;
				if (thenBranchContext != null) thenBranch = (ExpressionGreen)this.Visit(thenBranchContext);
				if (thenBranch == null) thenBranch = ExpressionGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), TestLexerModeSyntaxKind.TColon);
				TestLexerModeParser.ExpressionContext elseBranchContext = context.elseBranch;
				ExpressionGreen elseBranch = null;
				if (elseBranchContext != null) elseBranch = (ExpressionGreen)this.Visit(elseBranchContext);
				if (elseBranch == null) elseBranch = ExpressionGreen.__Missing;
				return _factory.ConditionalExpression(condition, tQuestion, thenBranch, tColon, elseBranch);
			}
			
			public override GreenNode VisitAssignmentExpression(TestLexerModeParser.AssignmentExpressionContext context)
			{
				if (context == null) return AssignmentExpressionGreen.__Missing;
				TestLexerModeParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null) left = (ExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ExpressionGreen.__Missing;
				InternalSyntaxToken op = null;
				if (context.TAssign() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				}
				else 	if (context.TAssignPlus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignPlus());
				}
				else 	if (context.TAssignMinus() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignMinus());
				}
				else 	if (context.TAssignAsterisk() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignAsterisk());
				}
				else 	if (context.TAssignSlash() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignSlash());
				}
				else 	if (context.TAssignPercent() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignPercent());
				}
				else 	if (context.TAssignAmp() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignAmp());
				}
				else 	if (context.TAssignPipe() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignPipe());
				}
				else 	if (context.TAssignHat() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignHat());
				}
				else 	if (context.TAssignLeftShift() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignLeftShift());
				}
				else 	if (context.TAssignRightShift() != null)
				{
					op = (InternalSyntaxToken)this.VisitTerminal(context.TAssignRightShift());
				}
				else
				{
					op = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				TestLexerModeParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null) right = (ExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ExpressionGreen.__Missing;
				return _factory.AssignmentExpression(left, op, right);
			}
			
			public override GreenNode VisitLambdaExpression(TestLexerModeParser.LambdaExpressionContext context)
			{
				if (context == null) return LambdaExpressionGreen.__Missing;
				TestLexerModeParser.AnonymousFunctionSignatureContext anonymousFunctionSignatureContext = context.anonymousFunctionSignature();
				AnonymousFunctionSignatureGreen anonymousFunctionSignature = null;
				if (anonymousFunctionSignatureContext != null) anonymousFunctionSignature = (AnonymousFunctionSignatureGreen)this.Visit(anonymousFunctionSignatureContext);
				if (anonymousFunctionSignature == null) anonymousFunctionSignature = AnonymousFunctionSignatureGreen.__Missing;
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLexerModeSyntaxKind.TArrow);
				TestLexerModeParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				if (expression == null) expression = ExpressionGreen.__Missing;
				return _factory.LambdaExpression(anonymousFunctionSignature, tArrow, expression);
			}
			
			public override GreenNode VisitQualifiedName(TestLexerModeParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
			    TestLexerModeParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], TestLexerModeSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.QualifiedName(identifier);
			}
			
			public override GreenNode VisitIdentifierList(TestLexerModeParser.IdentifierListContext context)
			{
				if (context == null) return IdentifierListGreen.__Missing;
			    TestLexerModeParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestLexerModeSyntaxKind.TComma));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.IdentifierList(identifier);
			}
			
			public override GreenNode VisitIdentifier(TestLexerModeParser.IdentifierContext context)
			{
				if (context == null) return IdentifierGreen.__Missing;
				InternalSyntaxToken identifierNormal = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierNormal(), TestLexerModeSyntaxKind.IdentifierNormal);
				return _factory.Identifier(identifierNormal);
			}
			
			public override GreenNode VisitLiteral(TestLexerModeParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				TestLexerModeParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return _factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				TestLexerModeParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return _factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				TestLexerModeParser.NumberLiteralContext numberLiteralContext = context.numberLiteral();
				if (numberLiteralContext != null) 
				{
					return _factory.Literal((NumberLiteralGreen)this.Visit(numberLiteralContext));
				}
				TestLexerModeParser.DateOrTimeLiteralContext dateOrTimeLiteralContext = context.dateOrTimeLiteral();
				if (dateOrTimeLiteralContext != null) 
				{
					return _factory.Literal((DateOrTimeLiteralGreen)this.Visit(dateOrTimeLiteralContext));
				}
				TestLexerModeParser.CharLiteralContext charLiteralContext = context.charLiteral();
				if (charLiteralContext != null) 
				{
					return _factory.Literal((CharLiteralGreen)this.Visit(charLiteralContext));
				}
				TestLexerModeParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return _factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				TestLexerModeParser.GuidLiteralContext guidLiteralContext = context.guidLiteral();
				if (guidLiteralContext != null) 
				{
					return _factory.Literal((GuidLiteralGreen)this.Visit(guidLiteralContext));
				}
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(TestLexerModeParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), TestLexerModeSyntaxKind.KNull);
				return _factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(TestLexerModeParser.BooleanLiteralContext context)
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
			
			public override GreenNode VisitNumberLiteral(TestLexerModeParser.NumberLiteralContext context)
			{
				if (context == null) return NumberLiteralGreen.__Missing;
				TestLexerModeParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return _factory.NumberLiteral((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				TestLexerModeParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return _factory.NumberLiteral((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				TestLexerModeParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return _factory.NumberLiteral((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				return NumberLiteralGreen.__Missing;
			}
			
			public override GreenNode VisitIntegerLiteral(TestLexerModeParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), TestLexerModeSyntaxKind.LInteger);
				return _factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(TestLexerModeParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), TestLexerModeSyntaxKind.LDecimal);
				return _factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(TestLexerModeParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), TestLexerModeSyntaxKind.LScientific);
				return _factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitDateOrTimeLiteral(TestLexerModeParser.DateOrTimeLiteralContext context)
			{
				if (context == null) return DateOrTimeLiteralGreen.__Missing;
				TestLexerModeParser.DateTimeLiteralContext dateTimeLiteralContext = context.dateTimeLiteral();
				if (dateTimeLiteralContext != null) 
				{
					return _factory.DateOrTimeLiteral((DateTimeLiteralGreen)this.Visit(dateTimeLiteralContext));
				}
				TestLexerModeParser.DateTimeOffsetLiteralContext dateTimeOffsetLiteralContext = context.dateTimeOffsetLiteral();
				if (dateTimeOffsetLiteralContext != null) 
				{
					return _factory.DateOrTimeLiteral((DateTimeOffsetLiteralGreen)this.Visit(dateTimeOffsetLiteralContext));
				}
				TestLexerModeParser.DateLiteralContext dateLiteralContext = context.dateLiteral();
				if (dateLiteralContext != null) 
				{
					return _factory.DateOrTimeLiteral((DateLiteralGreen)this.Visit(dateLiteralContext));
				}
				TestLexerModeParser.TimeLiteralContext timeLiteralContext = context.timeLiteral();
				if (timeLiteralContext != null) 
				{
					return _factory.DateOrTimeLiteral((TimeLiteralGreen)this.Visit(timeLiteralContext));
				}
				return DateOrTimeLiteralGreen.__Missing;
			}
			
			public override GreenNode VisitDateTimeOffsetLiteral(TestLexerModeParser.DateTimeOffsetLiteralContext context)
			{
				if (context == null) return DateTimeOffsetLiteralGreen.__Missing;
				InternalSyntaxToken lDateTimeOffset = (InternalSyntaxToken)this.VisitTerminal(context.LDateTimeOffset(), TestLexerModeSyntaxKind.LDateTimeOffset);
				return _factory.DateTimeOffsetLiteral(lDateTimeOffset);
			}
			
			public override GreenNode VisitDateTimeLiteral(TestLexerModeParser.DateTimeLiteralContext context)
			{
				if (context == null) return DateTimeLiteralGreen.__Missing;
				InternalSyntaxToken lDateTime = (InternalSyntaxToken)this.VisitTerminal(context.LDateTime(), TestLexerModeSyntaxKind.LDateTime);
				return _factory.DateTimeLiteral(lDateTime);
			}
			
			public override GreenNode VisitDateLiteral(TestLexerModeParser.DateLiteralContext context)
			{
				if (context == null) return DateLiteralGreen.__Missing;
				InternalSyntaxToken lDate = (InternalSyntaxToken)this.VisitTerminal(context.LDate(), TestLexerModeSyntaxKind.LDate);
				return _factory.DateLiteral(lDate);
			}
			
			public override GreenNode VisitTimeLiteral(TestLexerModeParser.TimeLiteralContext context)
			{
				if (context == null) return TimeLiteralGreen.__Missing;
				InternalSyntaxToken lTime = (InternalSyntaxToken)this.VisitTerminal(context.LTime(), TestLexerModeSyntaxKind.LTime);
				return _factory.TimeLiteral(lTime);
			}
			
			public override GreenNode VisitCharLiteral(TestLexerModeParser.CharLiteralContext context)
			{
				if (context == null) return CharLiteralGreen.__Missing;
				InternalSyntaxToken lChar = (InternalSyntaxToken)this.VisitTerminal(context.LChar(), TestLexerModeSyntaxKind.LChar);
				return _factory.CharLiteral(lChar);
			}
			
			public override GreenNode VisitStringLiteral(TestLexerModeParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken stringLiteral = null;
				if (context.LRegularString() != null)
				{
					stringLiteral = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString());
				}
				else 	if (context.LDoubleQuoteVerbatimString() != null)
				{
					stringLiteral = (InternalSyntaxToken)this.VisitTerminal(context.LDoubleQuoteVerbatimString());
				}
				else
				{
					stringLiteral = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.StringLiteral(stringLiteral);
			}
			
			public override GreenNode VisitGuidLiteral(TestLexerModeParser.GuidLiteralContext context)
			{
				if (context == null) return GuidLiteralGreen.__Missing;
				InternalSyntaxToken lGuid = (InternalSyntaxToken)this.VisitTerminal(context.LGuid(), TestLexerModeSyntaxKind.LGuid);
				return _factory.GuidLiteral(lGuid);
			}
        }
    }
    public partial class TestLexerModeParser
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
		
		internal class GeneratorDeclarationContext_Cached : GeneratorDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GeneratorDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ConfigDeclarationContext_Cached : ConfigDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ConfigDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ConfigPropertyContext_Cached : ConfigPropertyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ConfigPropertyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class MethodDeclarationContext_Cached : MethodDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MethodDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ExternFunctionDeclarationContext_Cached : ExternFunctionDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ExternFunctionDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FunctionDeclarationContext_Cached : FunctionDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FunctionDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FunctionSignatureContext_Cached : FunctionSignatureContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FunctionSignatureContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParamListContext_Cached : ParamListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParamListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParameterContext_Cached : ParameterContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParameterContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class BodyContext_Cached : BodyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public BodyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class SingleStatementContext_Cached : SingleStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SingleStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SingleStatementSemicolonContext_Cached : SingleStatementSemicolonContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SingleStatementSemicolonContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class VariableDeclarationStatementContext_Cached : VariableDeclarationStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public VariableDeclarationStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class VariableDeclarationExpressionContext_Cached : VariableDeclarationExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public VariableDeclarationExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class VariableDeclarationItemContext_Cached : VariableDeclarationItemContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public VariableDeclarationItemContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class VoidStatementContext_Cached : VoidStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public VoidStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ReturnStatementContext_Cached : ReturnStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ReturnStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ExpressionStatementContext_Cached : ExpressionStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ExpressionStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IfStatementContext_Cached : IfStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IfStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ElseIfStatementBodyContext_Cached : ElseIfStatementBodyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ElseIfStatementBodyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IfStatementElseBodyContext_Cached : IfStatementElseBodyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IfStatementElseBodyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IfStatementBeginContext_Cached : IfStatementBeginContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IfStatementBeginContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ElseIfStatementContext_Cached : ElseIfStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ElseIfStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IfStatementElseContext_Cached : IfStatementElseContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IfStatementElseContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IfStatementEndContext_Cached : IfStatementEndContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IfStatementEndContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ForStatementContext_Cached : ForStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ForStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ForStatementBeginContext_Cached : ForStatementBeginContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ForStatementBeginContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ForStatementEndContext_Cached : ForStatementEndContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ForStatementEndContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ForInitStatementContext_Cached : ForInitStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ForInitStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class WhileStatementContext_Cached : WhileStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public WhileStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class WhileStatementBeginContext_Cached : WhileStatementBeginContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public WhileStatementBeginContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class WhileStatementEndContext_Cached : WhileStatementEndContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public WhileStatementEndContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class WhileRunExpressionContext_Cached : WhileRunExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public WhileRunExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RepeatStatementContext_Cached : RepeatStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RepeatStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RepeatStatementBeginContext_Cached : RepeatStatementBeginContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RepeatStatementBeginContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RepeatStatementEndContext_Cached : RepeatStatementEndContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RepeatStatementEndContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RepeatRunExpressionContext_Cached : RepeatRunExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RepeatRunExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LoopStatementContext_Cached : LoopStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LoopStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LoopStatementBeginContext_Cached : LoopStatementBeginContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LoopStatementBeginContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LoopStatementEndContext_Cached : LoopStatementEndContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LoopStatementEndContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LoopChainContext_Cached : LoopChainContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LoopChainContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LoopChainItemContext_Cached : LoopChainItemContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LoopChainItemContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LoopChainExpressionContext_Cached : LoopChainExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LoopChainExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LoopWhereExpressionContext_Cached : LoopWhereExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LoopWhereExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LoopRunExpressionContext_Cached : LoopRunExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LoopRunExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SeparatorStatementContext_Cached : SeparatorStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SeparatorStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchStatementContext_Cached : SwitchStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchStatementBeginContext_Cached : SwitchStatementBeginContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchStatementBeginContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchStatementEndContext_Cached : SwitchStatementEndContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchStatementEndContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchBranchStatementContext_Cached : SwitchBranchStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchBranchStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchBranchHeadStatementContext_Cached : SwitchBranchHeadStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchBranchHeadStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchCaseOrTypeIsHeadStatementsContext_Cached : SwitchCaseOrTypeIsHeadStatementsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchCaseOrTypeIsHeadStatementsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchCaseOrTypeIsHeadStatementContext_Cached : SwitchCaseOrTypeIsHeadStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchCaseOrTypeIsHeadStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchCaseHeadStatementContext_Cached : SwitchCaseHeadStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchCaseHeadStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchTypeIsHeadStatementContext_Cached : SwitchTypeIsHeadStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchTypeIsHeadStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchTypeAsHeadStatementContext_Cached : SwitchTypeAsHeadStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchTypeAsHeadStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchDefaultStatementContext_Cached : SwitchDefaultStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchDefaultStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SwitchDefaultHeadStatementContext_Cached : SwitchDefaultHeadStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SwitchDefaultHeadStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TemplateDeclarationContext_Cached : TemplateDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TemplateDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TemplateSignatureContext_Cached : TemplateSignatureContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TemplateSignatureContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TemplateBodyContext_Cached : TemplateBodyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TemplateBodyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TemplateContentLineContext_Cached : TemplateContentLineContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TemplateContentLineContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TemplateContentContext_Cached : TemplateContentContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TemplateContentContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TemplateOutputContext_Cached : TemplateOutputContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TemplateOutputContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TemplateLineEndContext_Cached : TemplateLineEndContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TemplateLineEndContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TemplateStatementStartEndContext_Cached : TemplateStatementStartEndContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TemplateStatementStartEndContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TemplateStatementContext_Cached : TemplateStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TemplateStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypeArgumentListContext_Cached : TypeArgumentListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypeArgumentListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class PredefinedTypeContext_Cached : PredefinedTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PredefinedTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypeReferenceListContext_Cached : TypeReferenceListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypeReferenceListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ArrayTypeContext_Cached : ArrayTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ArrayTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ArrayItemTypeContext_Cached : ArrayItemTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ArrayItemTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NullableTypeContext_Cached : NullableTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NullableTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NullableItemTypeContext_Cached : NullableItemTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NullableItemTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class GenericTypeContext_Cached : GenericTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GenericTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SimpleTypeContext_Cached : SimpleTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SimpleTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ExpressionListContext_Cached : ExpressionListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ExpressionListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class VariableReferenceContext_Cached : VariableReferenceContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public VariableReferenceContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RankSpecifiersContext_Cached : RankSpecifiersContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RankSpecifiersContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RankSpecifierContext_Cached : RankSpecifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RankSpecifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class UnboundTypeNameContext_Cached : UnboundTypeNameContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public UnboundTypeNameContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class GenericDimensionItemContext_Cached : GenericDimensionItemContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GenericDimensionItemContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class GenericDimensionSpecifierContext_Cached : GenericDimensionSpecifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GenericDimensionSpecifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AnonymousFunctionSignatureContext_Cached : AnonymousFunctionSignatureContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AnonymousFunctionSignatureContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class IdentifierListContext_Cached : IdentifierListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IdentifierListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class NumberLiteralContext_Cached : NumberLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NumberLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class DateOrTimeLiteralContext_Cached : DateOrTimeLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DateOrTimeLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DateTimeOffsetLiteralContext_Cached : DateTimeOffsetLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DateTimeOffsetLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DateTimeLiteralContext_Cached : DateTimeLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DateTimeLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DateLiteralContext_Cached : DateLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DateLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TimeLiteralContext_Cached : TimeLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TimeLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class GuidLiteralContext_Cached : GuidLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GuidLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
    }
}

