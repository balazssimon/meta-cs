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
namespace PilV2.Syntax.InternalSyntax
{
    public class PilSyntaxParser : Antlr4SyntaxParser
    {
        private readonly Antlr4ToRoslynVisitor _visitor;
        public PilSyntaxParser(
            SourceText text,
            PilParseOptions options,
            PilSyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
            : base(PilLanguage.Instance, text, options, oldTree, changes, cancellationToken)
        {
            _visitor = new Antlr4ToRoslynVisitor(this);
        }
        protected PilParser Antlr4Parser => (PilParser)this.Parser;
		public override LanguageSyntaxNode Parse()
		{
			BeginRoot();
            ParserState state = null;
			var green = this.ParseMain(ref state);
			EndRoot(ref green);
			var red = (PilSyntaxNode)green.CreateRed();
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
		
		internal PilParser.MainContext _Antlr4ParseMain()
		{
			BeginNode();
		    PilParser.MainContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMain(CurrentNode as MainSyntax))
				{
					green = EatNode();
					context = new PilParser.MainContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration(DeclarationSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.DeclarationContext _Antlr4ParseDeclaration()
		{
			BeginNode();
		    PilParser.DeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration(CurrentNode as DeclarationSyntax))
				{
					green = EatNode();
					context = new PilParser.DeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration();
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
		
		public GreenNode ParseTypeDefDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typeDefDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypeDefDeclaration(TypeDefDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.TypeDefDeclarationContext _Antlr4ParseTypeDefDeclaration()
		{
			BeginNode();
		    PilParser.TypeDefDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeDefDeclaration(CurrentNode as TypeDefDeclarationSyntax))
				{
					green = EatNode();
					context = new PilParser.TypeDefDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeDefDeclaration();
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
		
		public GreenNode ParseExternalParameterDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.externalParameterDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseExternalParameterDeclaration(ExternalParameterDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ExternalParameterDeclarationContext _Antlr4ParseExternalParameterDeclaration()
		{
			BeginNode();
		    PilParser.ExternalParameterDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseExternalParameterDeclaration(CurrentNode as ExternalParameterDeclarationSyntax))
				{
					green = EatNode();
					context = new PilParser.ExternalParameterDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseExternalParameterDeclaration();
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
		
		public GreenNode ParseEnumDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.enumDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEnumDeclaration(EnumDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.EnumDeclarationContext _Antlr4ParseEnumDeclaration()
		{
			BeginNode();
		    PilParser.EnumDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumDeclaration(CurrentNode as EnumDeclarationSyntax))
				{
					green = EatNode();
					context = new PilParser.EnumDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseEnumDeclaration();
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
		
		public GreenNode ParseEnumLiterals(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.enumLiterals();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEnumLiterals(EnumLiteralsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.EnumLiteralsContext _Antlr4ParseEnumLiterals()
		{
			BeginNode();
		    PilParser.EnumLiteralsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumLiterals(CurrentNode as EnumLiteralsSyntax))
				{
					green = EatNode();
					context = new PilParser.EnumLiteralsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseEnumLiterals();
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
		
		public GreenNode ParseEnumLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.enumLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEnumLiteral(EnumLiteralSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.EnumLiteralContext _Antlr4ParseEnumLiteral()
		{
			BeginNode();
		    PilParser.EnumLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumLiteral(CurrentNode as EnumLiteralSyntax))
				{
					green = EatNode();
					context = new PilParser.EnumLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseEnumLiteral();
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
		
		public GreenNode ParseObjectDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.objectDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseObjectDeclaration(ObjectDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ObjectDeclarationContext _Antlr4ParseObjectDeclaration()
		{
			BeginNode();
		    PilParser.ObjectDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseObjectDeclaration(CurrentNode as ObjectDeclarationSyntax))
				{
					green = EatNode();
					context = new PilParser.ObjectDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseObjectDeclaration();
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
		
		public GreenNode ParseObjectHeader(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.objectHeader();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseObjectHeader(ObjectHeaderSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ObjectHeaderContext _Antlr4ParseObjectHeader()
		{
			BeginNode();
		    PilParser.ObjectHeaderContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseObjectHeader(CurrentNode as ObjectHeaderSyntax))
				{
					green = EatNode();
					context = new PilParser.ObjectHeaderContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseObjectHeader();
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
		
		public GreenNode ParsePorts(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.ports();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePorts(PortsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.PortsContext _Antlr4ParsePorts()
		{
			BeginNode();
		    PilParser.PortsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReusePorts(CurrentNode as PortsSyntax))
				{
					green = EatNode();
					context = new PilParser.PortsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParsePorts();
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
		
		public GreenNode ParsePort(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.port();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePort(PortSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.PortContext _Antlr4ParsePort()
		{
			BeginNode();
		    PilParser.PortContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReusePort(CurrentNode as PortSyntax))
				{
					green = EatNode();
					context = new PilParser.PortContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParsePort();
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
		
		public GreenNode ParseObjectExternalParameters(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.objectExternalParameters();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseObjectExternalParameters(ObjectExternalParametersSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ObjectExternalParametersContext _Antlr4ParseObjectExternalParameters()
		{
			BeginNode();
		    PilParser.ObjectExternalParametersContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseObjectExternalParameters(CurrentNode as ObjectExternalParametersSyntax))
				{
					green = EatNode();
					context = new PilParser.ObjectExternalParametersContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseObjectExternalParameters();
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
		
		public GreenNode ParseObjectFields(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.objectFields();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseObjectFields(ObjectFieldsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ObjectFieldsContext _Antlr4ParseObjectFields()
		{
			BeginNode();
		    PilParser.ObjectFieldsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseObjectFields(CurrentNode as ObjectFieldsSyntax))
				{
					green = EatNode();
					context = new PilParser.ObjectFieldsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseObjectFields();
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
		
		public GreenNode ParseObjectFunctions(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.objectFunctions();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseObjectFunctions(ObjectFunctionsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ObjectFunctionsContext _Antlr4ParseObjectFunctions()
		{
			BeginNode();
		    PilParser.ObjectFunctionsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseObjectFunctions(CurrentNode as ObjectFunctionsSyntax))
				{
					green = EatNode();
					context = new PilParser.ObjectFunctionsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseObjectFunctions();
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
		
		internal PilParser.FunctionDeclarationContext _Antlr4ParseFunctionDeclaration()
		{
			BeginNode();
		    PilParser.FunctionDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFunctionDeclaration(CurrentNode as FunctionDeclarationSyntax))
				{
					green = EatNode();
					context = new PilParser.FunctionDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseFunctionHeader(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.functionHeader();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFunctionHeader(FunctionHeaderSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.FunctionHeaderContext _Antlr4ParseFunctionHeader()
		{
			BeginNode();
		    PilParser.FunctionHeaderContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFunctionHeader(CurrentNode as FunctionHeaderSyntax))
				{
					green = EatNode();
					context = new PilParser.FunctionHeaderContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseFunctionHeader();
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
		
		public GreenNode ParseFunctionParams(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.functionParams();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFunctionParams(FunctionParamsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.FunctionParamsContext _Antlr4ParseFunctionParams()
		{
			BeginNode();
		    PilParser.FunctionParamsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFunctionParams(CurrentNode as FunctionParamsSyntax))
				{
					green = EatNode();
					context = new PilParser.FunctionParamsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseFunctionParams();
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
		
		public GreenNode ParseParam(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.param();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParam(ParamSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ParamContext _Antlr4ParseParam()
		{
			BeginNode();
		    PilParser.ParamContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseParam(CurrentNode as ParamSyntax))
				{
					green = EatNode();
					context = new PilParser.ParamContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseParam();
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
		
		public GreenNode ParseQueryDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryDeclaration(QueryDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryDeclarationContext _Antlr4ParseQueryDeclaration()
		{
			BeginNode();
		    PilParser.QueryDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryDeclaration(CurrentNode as QueryDeclarationSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryDeclaration();
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
		
		public GreenNode ParseQueryHeader(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryHeader();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryHeader(QueryHeaderSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryHeaderContext _Antlr4ParseQueryHeader()
		{
			BeginNode();
		    PilParser.QueryHeaderContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryHeader(CurrentNode as QueryHeaderSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryHeaderContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryHeader();
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
		
		public GreenNode ParseQueryRequestParams(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryRequestParams();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryRequestParams(QueryRequestParamsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryRequestParamsContext _Antlr4ParseQueryRequestParams()
		{
			BeginNode();
		    PilParser.QueryRequestParamsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryRequestParams(CurrentNode as QueryRequestParamsSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryRequestParamsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryRequestParams();
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
		
		public GreenNode ParseQueryAcceptParams(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryAcceptParams();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryAcceptParams(QueryAcceptParamsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryAcceptParamsContext _Antlr4ParseQueryAcceptParams()
		{
			BeginNode();
		    PilParser.QueryAcceptParamsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryAcceptParams(CurrentNode as QueryAcceptParamsSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryAcceptParamsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryAcceptParams();
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
		
		public GreenNode ParseQueryRefuseParams(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryRefuseParams();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryRefuseParams(QueryRefuseParamsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryRefuseParamsContext _Antlr4ParseQueryRefuseParams()
		{
			BeginNode();
		    PilParser.QueryRefuseParamsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryRefuseParams(CurrentNode as QueryRefuseParamsSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryRefuseParamsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryRefuseParams();
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
		
		public GreenNode ParseQueryCancelParams(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryCancelParams();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryCancelParams(QueryCancelParamsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryCancelParamsContext _Antlr4ParseQueryCancelParams()
		{
			BeginNode();
		    PilParser.QueryCancelParamsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryCancelParams(CurrentNode as QueryCancelParamsSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryCancelParamsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryCancelParams();
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
		
		public GreenNode ParseQueryExternalParameters(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryExternalParameters();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryExternalParameters(QueryExternalParametersSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryExternalParametersContext _Antlr4ParseQueryExternalParameters()
		{
			BeginNode();
		    PilParser.QueryExternalParametersContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryExternalParameters(CurrentNode as QueryExternalParametersSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryExternalParametersContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryExternalParameters();
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
		
		public GreenNode ParseQueryField(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryField();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryField(QueryFieldSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryFieldContext _Antlr4ParseQueryField()
		{
			BeginNode();
		    PilParser.QueryFieldContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryField(CurrentNode as QueryFieldSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryFieldContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryField();
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
		
		public GreenNode ParseQueryFunction(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryFunction();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryFunction(QueryFunctionSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryFunctionContext _Antlr4ParseQueryFunction()
		{
			BeginNode();
		    PilParser.QueryFunctionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryFunction(CurrentNode as QueryFunctionSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryFunctionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryFunction();
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
		
		public GreenNode ParseQueryObject(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryObject();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryObject(QueryObjectSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryObjectContext _Antlr4ParseQueryObject()
		{
			BeginNode();
		    PilParser.QueryObjectContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryObject(CurrentNode as QueryObjectSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryObjectContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryObject();
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
		
		public GreenNode ParseQueryObjectField(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryObjectField();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryObjectField(QueryObjectFieldSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryObjectFieldContext _Antlr4ParseQueryObjectField()
		{
			BeginNode();
		    PilParser.QueryObjectFieldContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryObjectField(CurrentNode as QueryObjectFieldSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryObjectFieldContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryObjectField();
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
		
		public GreenNode ParseQueryObjectFunction(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryObjectFunction();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryObjectFunction(QueryObjectFunctionSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryObjectFunctionContext _Antlr4ParseQueryObjectFunction()
		{
			BeginNode();
		    PilParser.QueryObjectFunctionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryObjectFunction(CurrentNode as QueryObjectFunctionSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryObjectFunctionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryObjectFunction();
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
		
		public GreenNode ParseQueryObjectEvent(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.queryObjectEvent();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQueryObjectEvent(QueryObjectEventSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QueryObjectEventContext _Antlr4ParseQueryObjectEvent()
		{
			BeginNode();
		    PilParser.QueryObjectEventContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQueryObjectEvent(CurrentNode as QueryObjectEventSyntax))
				{
					green = EatNode();
					context = new PilParser.QueryObjectEventContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQueryObjectEvent();
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
		
		public GreenNode ParseInput(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.input();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseInput(InputSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.InputContext _Antlr4ParseInput()
		{
			BeginNode();
		    PilParser.InputContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseInput(CurrentNode as InputSyntax))
				{
					green = EatNode();
					context = new PilParser.InputContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseInput();
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
		
		public GreenNode ParseInputPortList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.inputPortList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseInputPortList(InputPortListSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.InputPortListContext _Antlr4ParseInputPortList()
		{
			BeginNode();
		    PilParser.InputPortListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseInputPortList(CurrentNode as InputPortListSyntax))
				{
					green = EatNode();
					context = new PilParser.InputPortListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseInputPortList();
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
		
		public GreenNode ParseInputPort(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.inputPort();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseInputPort(InputPortSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.InputPortContext _Antlr4ParseInputPort()
		{
			BeginNode();
		    PilParser.InputPortContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseInputPort(CurrentNode as InputPortSyntax))
				{
					green = EatNode();
					context = new PilParser.InputPortContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseInputPort();
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
		
		public GreenNode ParseTrigger(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.trigger();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTrigger(TriggerSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.TriggerContext _Antlr4ParseTrigger()
		{
			BeginNode();
		    PilParser.TriggerContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTrigger(CurrentNode as TriggerSyntax))
				{
					green = EatNode();
					context = new PilParser.TriggerContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTrigger();
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
		
		public GreenNode ParseTriggerVarList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.triggerVarList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTriggerVarList(TriggerVarListSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.TriggerVarListContext _Antlr4ParseTriggerVarList()
		{
			BeginNode();
		    PilParser.TriggerVarListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTriggerVarList(CurrentNode as TriggerVarListSyntax))
				{
					green = EatNode();
					context = new PilParser.TriggerVarListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTriggerVarList();
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
		
		public GreenNode ParseTriggerVar(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.triggerVar();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTriggerVar(TriggerVarSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.TriggerVarContext _Antlr4ParseTriggerVar()
		{
			BeginNode();
		    PilParser.TriggerVarContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTriggerVar(CurrentNode as TriggerVarSyntax))
				{
					green = EatNode();
					context = new PilParser.TriggerVarContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTriggerVar();
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
		
		public GreenNode ParseStatements(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.statements();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseStatements(StatementsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.StatementsContext _Antlr4ParseStatements()
		{
			BeginNode();
		    PilParser.StatementsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseStatements(CurrentNode as StatementsSyntax))
				{
					green = EatNode();
					context = new PilParser.StatementsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseStatements();
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
		
		internal PilParser.StatementContext _Antlr4ParseStatement()
		{
			BeginNode();
		    PilParser.StatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseStatement(CurrentNode as StatementSyntax))
				{
					green = EatNode();
					context = new PilParser.StatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseForkStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.forkStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseForkStatement(ForkStatementSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ForkStatementContext _Antlr4ParseForkStatement()
		{
			BeginNode();
		    PilParser.ForkStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseForkStatement(CurrentNode as ForkStatementSyntax))
				{
					green = EatNode();
					context = new PilParser.ForkStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseForkStatement();
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
		
		public GreenNode ParseCaseBranch(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.caseBranch();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCaseBranch(CaseBranchSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.CaseBranchContext _Antlr4ParseCaseBranch()
		{
			BeginNode();
		    PilParser.CaseBranchContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseCaseBranch(CurrentNode as CaseBranchSyntax))
				{
					green = EatNode();
					context = new PilParser.CaseBranchContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseCaseBranch();
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
		
		public GreenNode ParseElseBranch(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.elseBranch();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseElseBranch(ElseBranchSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ElseBranchContext _Antlr4ParseElseBranch()
		{
			BeginNode();
		    PilParser.ElseBranchContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseElseBranch(CurrentNode as ElseBranchSyntax))
				{
					green = EatNode();
					context = new PilParser.ElseBranchContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseElseBranch();
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
		
		internal PilParser.IfStatementContext _Antlr4ParseIfStatement()
		{
			BeginNode();
		    PilParser.IfStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIfStatement(CurrentNode as IfStatementSyntax))
				{
					green = EatNode();
					context = new PilParser.IfStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseIfBranch(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.ifBranch();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIfBranch(IfBranchSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.IfBranchContext _Antlr4ParseIfBranch()
		{
			BeginNode();
		    PilParser.IfBranchContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIfBranch(CurrentNode as IfBranchSyntax))
				{
					green = EatNode();
					context = new PilParser.IfBranchContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseIfBranch();
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
		
		public GreenNode ParseElseIfBranch(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.elseIfBranch();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseElseIfBranch(ElseIfBranchSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ElseIfBranchContext _Antlr4ParseElseIfBranch()
		{
			BeginNode();
		    PilParser.ElseIfBranchContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseElseIfBranch(CurrentNode as ElseIfBranchSyntax))
				{
					green = EatNode();
					context = new PilParser.ElseIfBranchContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseElseIfBranch();
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
		
		public GreenNode ParseRequestStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.requestStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRequestStatement(RequestStatementSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.RequestStatementContext _Antlr4ParseRequestStatement()
		{
			BeginNode();
		    PilParser.RequestStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRequestStatement(CurrentNode as RequestStatementSyntax))
				{
					green = EatNode();
					context = new PilParser.RequestStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseRequestStatement();
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
		
		public GreenNode ParseCallRequest(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.callRequest();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCallRequest(CallRequestSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.CallRequestContext _Antlr4ParseCallRequest()
		{
			BeginNode();
		    PilParser.CallRequestContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseCallRequest(CurrentNode as CallRequestSyntax))
				{
					green = EatNode();
					context = new PilParser.CallRequestContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseCallRequest();
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
		
		public GreenNode ParseRequestArguments(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.requestArguments();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRequestArguments(RequestArgumentsSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.RequestArgumentsContext _Antlr4ParseRequestArguments()
		{
			BeginNode();
		    PilParser.RequestArgumentsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRequestArguments(CurrentNode as RequestArgumentsSyntax))
				{
					green = EatNode();
					context = new PilParser.RequestArgumentsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseRequestArguments();
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
		
		public GreenNode ParseResponseStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.responseStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseResponseStatement(ResponseStatementSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ResponseStatementContext _Antlr4ParseResponseStatement()
		{
			BeginNode();
		    PilParser.ResponseStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseResponseStatement(CurrentNode as ResponseStatementSyntax))
				{
					green = EatNode();
					context = new PilParser.ResponseStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseResponseStatement();
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
		
		public GreenNode ParseCancelStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.cancelStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCancelStatement(CancelStatementSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.CancelStatementContext _Antlr4ParseCancelStatement()
		{
			BeginNode();
		    PilParser.CancelStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseCancelStatement(CurrentNode as CancelStatementSyntax))
				{
					green = EatNode();
					context = new PilParser.CancelStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseCancelStatement();
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
		
		public GreenNode ParseAssertion(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.assertion();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAssertion(AssertionSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.AssertionContext _Antlr4ParseAssertion()
		{
			BeginNode();
		    PilParser.AssertionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseAssertion(CurrentNode as AssertionSyntax))
				{
					green = EatNode();
					context = new PilParser.AssertionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseAssertion();
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
		
		public GreenNode ParseResponseStatementKind(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.responseStatementKind();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseResponseStatementKind(ResponseStatementKindSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ResponseStatementKindContext _Antlr4ParseResponseStatementKind()
		{
			BeginNode();
		    PilParser.ResponseStatementKindContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseResponseStatementKind(CurrentNode as ResponseStatementKindSyntax))
				{
					green = EatNode();
					context = new PilParser.ResponseStatementKindContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseResponseStatementKind();
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
		
		public GreenNode ParseCancelStatementKind(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.cancelStatementKind();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCancelStatementKind(CancelStatementKindSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.CancelStatementKindContext _Antlr4ParseCancelStatementKind()
		{
			BeginNode();
		    PilParser.CancelStatementKindContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseCancelStatementKind(CurrentNode as CancelStatementKindSyntax))
				{
					green = EatNode();
					context = new PilParser.CancelStatementKindContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseCancelStatementKind();
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
		
		public GreenNode ParseForkRequestStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.forkRequestStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseForkRequestStatement(ForkRequestStatementSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ForkRequestStatementContext _Antlr4ParseForkRequestStatement()
		{
			BeginNode();
		    PilParser.ForkRequestStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseForkRequestStatement(CurrentNode as ForkRequestStatementSyntax))
				{
					green = EatNode();
					context = new PilParser.ForkRequestStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseForkRequestStatement();
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
		
		public GreenNode ParseForkRequestVariable(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.forkRequestVariable();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseForkRequestVariable(ForkRequestVariableSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ForkRequestVariableContext _Antlr4ParseForkRequestVariable()
		{
			BeginNode();
		    PilParser.ForkRequestVariableContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseForkRequestVariable(CurrentNode as ForkRequestVariableSyntax))
				{
					green = EatNode();
					context = new PilParser.ForkRequestVariableContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseForkRequestVariable();
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
		
		public GreenNode ParseForkRequestIdentifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.forkRequestIdentifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseForkRequestIdentifier(ForkRequestIdentifierSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ForkRequestIdentifierContext _Antlr4ParseForkRequestIdentifier()
		{
			BeginNode();
		    PilParser.ForkRequestIdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseForkRequestIdentifier(CurrentNode as ForkRequestIdentifierSyntax))
				{
					green = EatNode();
					context = new PilParser.ForkRequestIdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseForkRequestIdentifier();
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
		
		public GreenNode ParseAcceptBranch(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.acceptBranch();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAcceptBranch(AcceptBranchSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.AcceptBranchContext _Antlr4ParseAcceptBranch()
		{
			BeginNode();
		    PilParser.AcceptBranchContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseAcceptBranch(CurrentNode as AcceptBranchSyntax))
				{
					green = EatNode();
					context = new PilParser.AcceptBranchContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseAcceptBranch();
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
		
		public GreenNode ParseRefuseBranch(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.refuseBranch();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRefuseBranch(RefuseBranchSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.RefuseBranchContext _Antlr4ParseRefuseBranch()
		{
			BeginNode();
		    PilParser.RefuseBranchContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRefuseBranch(CurrentNode as RefuseBranchSyntax))
				{
					green = EatNode();
					context = new PilParser.RefuseBranchContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseRefuseBranch();
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
		
		public GreenNode ParseCancelBranch(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.cancelBranch();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCancelBranch(CancelBranchSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.CancelBranchContext _Antlr4ParseCancelBranch()
		{
			BeginNode();
		    PilParser.CancelBranchContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseCancelBranch(CurrentNode as CancelBranchSyntax))
				{
					green = EatNode();
					context = new PilParser.CancelBranchContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseCancelBranch();
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
		
		internal PilParser.VariableDeclarationStatementContext _Antlr4ParseVariableDeclarationStatement()
		{
			BeginNode();
		    PilParser.VariableDeclarationStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVariableDeclarationStatement(CurrentNode as VariableDeclarationStatementSyntax))
				{
					green = EatNode();
					context = new PilParser.VariableDeclarationStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseVariableDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.variableDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVariableDeclaration(VariableDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.VariableDeclarationContext _Antlr4ParseVariableDeclaration()
		{
			BeginNode();
		    PilParser.VariableDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVariableDeclaration(CurrentNode as VariableDeclarationSyntax))
				{
					green = EatNode();
					context = new PilParser.VariableDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVariableDeclaration();
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
		
		public GreenNode ParseAssignmentStatement(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.assignmentStatement();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAssignmentStatement(AssignmentStatementSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.AssignmentStatementContext _Antlr4ParseAssignmentStatement()
		{
			BeginNode();
		    PilParser.AssignmentStatementContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseAssignmentStatement(CurrentNode as AssignmentStatementSyntax))
				{
					green = EatNode();
					context = new PilParser.AssignmentStatementContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseAssignmentStatement();
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
		
		public GreenNode ParseLeftSide(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.leftSide();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLeftSide(LeftSideSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.LeftSideContext _Antlr4ParseLeftSide()
		{
			BeginNode();
		    PilParser.LeftSideContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLeftSide(CurrentNode as LeftSideSyntax))
				{
					green = EatNode();
					context = new PilParser.LeftSideContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseLeftSide();
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
		
		internal PilParser.ExpressionListContext _Antlr4ParseExpressionList()
		{
			BeginNode();
		    PilParser.ExpressionListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseExpressionList(CurrentNode as ExpressionListSyntax))
				{
					green = EatNode();
					context = new PilParser.ExpressionListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal PilParser.ExpressionContext _Antlr4ParseExpression()
		{
			BeginNode();
		    PilParser.ExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseExpression(CurrentNode as ExpressionSyntax))
				{
					green = EatNode();
					context = new PilParser.ExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseExpression();
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
		
		public GreenNode ParseArithmeticExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arithmeticExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArithmeticExpression(ArithmeticExpressionSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ArithmeticExpressionContext _Antlr4ParseArithmeticExpression(int precedence)
		{
			BeginNode();
		    PilParser.ArithmeticExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArithmeticExpression(CurrentNode as ArithmeticExpressionSyntax))
				{
					green = EatNode();
					context = new PilParser.ArithmeticExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArithmeticExpression(precedence);
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
		
		public GreenNode ParseOpMulDiv(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.opMulDiv();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseOpMulDiv(OpMulDivSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.OpMulDivContext _Antlr4ParseOpMulDiv()
		{
			BeginNode();
		    PilParser.OpMulDivContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOpMulDiv(CurrentNode as OpMulDivSyntax))
				{
					green = EatNode();
					context = new PilParser.OpMulDivContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseOpMulDiv();
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
		
		public GreenNode ParseOpAddSub(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.opAddSub();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseOpAddSub(OpAddSubSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.OpAddSubContext _Antlr4ParseOpAddSub()
		{
			BeginNode();
		    PilParser.OpAddSubContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOpAddSub(CurrentNode as OpAddSubSyntax))
				{
					green = EatNode();
					context = new PilParser.OpAddSubContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseOpAddSub();
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
		
		public GreenNode ParseArithmeticExpressionTerminator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arithmeticExpressionTerminator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArithmeticExpressionTerminator(ArithmeticExpressionTerminatorSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ArithmeticExpressionTerminatorContext _Antlr4ParseArithmeticExpressionTerminator()
		{
			BeginNode();
		    PilParser.ArithmeticExpressionTerminatorContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArithmeticExpressionTerminator(CurrentNode as ArithmeticExpressionTerminatorSyntax))
				{
					green = EatNode();
					context = new PilParser.ArithmeticExpressionTerminatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArithmeticExpressionTerminator();
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
		
		public GreenNode ParseOpMinus(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.opMinus();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseOpMinus(OpMinusSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.OpMinusContext _Antlr4ParseOpMinus()
		{
			BeginNode();
		    PilParser.OpMinusContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOpMinus(CurrentNode as OpMinusSyntax))
				{
					green = EatNode();
					context = new PilParser.OpMinusContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseOpMinus();
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
		
		public GreenNode ParseConditionalExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.conditionalExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseConditionalExpression(ConditionalExpressionSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ConditionalExpressionContext _Antlr4ParseConditionalExpression(int precedence)
		{
			BeginNode();
		    PilParser.ConditionalExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseConditionalExpression(CurrentNode as ConditionalExpressionSyntax))
				{
					green = EatNode();
					context = new PilParser.ConditionalExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseConditionalExpression(precedence);
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
		
		public GreenNode ParseAndAlsoOp(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.andAlsoOp();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAndAlsoOp(AndAlsoOpSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.AndAlsoOpContext _Antlr4ParseAndAlsoOp()
		{
			BeginNode();
		    PilParser.AndAlsoOpContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseAndAlsoOp(CurrentNode as AndAlsoOpSyntax))
				{
					green = EatNode();
					context = new PilParser.AndAlsoOpContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseAndAlsoOp();
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
		
		public GreenNode ParseOrElseOp(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.orElseOp();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseOrElseOp(OrElseOpSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.OrElseOpContext _Antlr4ParseOrElseOp()
		{
			BeginNode();
		    PilParser.OrElseOpContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOrElseOp(CurrentNode as OrElseOpSyntax))
				{
					green = EatNode();
					context = new PilParser.OrElseOpContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseOrElseOp();
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
		
		public GreenNode ParseOpExcl(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.opExcl();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseOpExcl(OpExclSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.OpExclContext _Antlr4ParseOpExcl()
		{
			BeginNode();
		    PilParser.OpExclContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOpExcl(CurrentNode as OpExclSyntax))
				{
					green = EatNode();
					context = new PilParser.OpExclContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseOpExcl();
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
		
		public GreenNode ParseConditionalExpressionTerminator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.conditionalExpressionTerminator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseConditionalExpressionTerminator(ConditionalExpressionTerminatorSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ConditionalExpressionTerminatorContext _Antlr4ParseConditionalExpressionTerminator()
		{
			BeginNode();
		    PilParser.ConditionalExpressionTerminatorContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseConditionalExpressionTerminator(CurrentNode as ConditionalExpressionTerminatorSyntax))
				{
					green = EatNode();
					context = new PilParser.ConditionalExpressionTerminatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseConditionalExpressionTerminator();
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
		
		public GreenNode ParseComparisonExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.comparisonExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseComparisonExpression(ComparisonExpressionSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ComparisonExpressionContext _Antlr4ParseComparisonExpression()
		{
			BeginNode();
		    PilParser.ComparisonExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseComparisonExpression(CurrentNode as ComparisonExpressionSyntax))
				{
					green = EatNode();
					context = new PilParser.ComparisonExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseComparisonExpression();
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
		
		public GreenNode ParseComparisonOperator(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.comparisonOperator();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseComparisonOperator(ComparisonOperatorSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ComparisonOperatorContext _Antlr4ParseComparisonOperator()
		{
			BeginNode();
		    PilParser.ComparisonOperatorContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseComparisonOperator(CurrentNode as ComparisonOperatorSyntax))
				{
					green = EatNode();
					context = new PilParser.ComparisonOperatorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseComparisonOperator();
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
		
		public GreenNode ParseElementOfExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.elementOfExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseElementOfExpression(ElementOfExpressionSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ElementOfExpressionContext _Antlr4ParseElementOfExpression()
		{
			BeginNode();
		    PilParser.ElementOfExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseElementOfExpression(CurrentNode as ElementOfExpressionSyntax))
				{
					green = EatNode();
					context = new PilParser.ElementOfExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseElementOfExpression();
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
		
		public GreenNode ParseElementOfValueList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.elementOfValueList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseElementOfValueList(ElementOfValueListSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ElementOfValueListContext _Antlr4ParseElementOfValueList()
		{
			BeginNode();
		    PilParser.ElementOfValueListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseElementOfValueList(CurrentNode as ElementOfValueListSyntax))
				{
					green = EatNode();
					context = new PilParser.ElementOfValueListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseElementOfValueList();
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
		
		public GreenNode ParseElementOfValue(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.elementOfValue();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseElementOfValue(ElementOfValueSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ElementOfValueContext _Antlr4ParseElementOfValue()
		{
			BeginNode();
		    PilParser.ElementOfValueContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseElementOfValue(CurrentNode as ElementOfValueSyntax))
				{
					green = EatNode();
					context = new PilParser.ElementOfValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseElementOfValue();
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
		
		public GreenNode ParseTerminalExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.terminalExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTerminalExpression(TerminalExpressionSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.TerminalExpressionContext _Antlr4ParseTerminalExpression()
		{
			BeginNode();
		    PilParser.TerminalExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTerminalExpression(CurrentNode as TerminalExpressionSyntax))
				{
					green = EatNode();
					context = new PilParser.TerminalExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTerminalExpression();
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
		
		public GreenNode ParseFunctionCallExpression(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.functionCallExpression();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFunctionCallExpression(FunctionCallExpressionSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.FunctionCallExpressionContext _Antlr4ParseFunctionCallExpression()
		{
			BeginNode();
		    PilParser.FunctionCallExpressionContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFunctionCallExpression(CurrentNode as FunctionCallExpressionSyntax))
				{
					green = EatNode();
					context = new PilParser.FunctionCallExpressionContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseFunctionCallExpression();
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
		
		internal PilParser.VariableReferenceContext _Antlr4ParseVariableReference()
		{
			BeginNode();
		    PilParser.VariableReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVariableReference(CurrentNode as VariableReferenceSyntax))
				{
					green = EatNode();
					context = new PilParser.VariableReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseVariableReferenceIdentifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.variableReferenceIdentifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.VariableReferenceIdentifierContext _Antlr4ParseVariableReferenceIdentifier()
		{
			BeginNode();
		    PilParser.VariableReferenceIdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVariableReferenceIdentifier(CurrentNode as VariableReferenceIdentifierSyntax))
				{
					green = EatNode();
					context = new PilParser.VariableReferenceIdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVariableReferenceIdentifier();
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
		
		public GreenNode ParseComment(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.comment();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseComment(CommentSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.CommentContext _Antlr4ParseComment()
		{
			BeginNode();
		    PilParser.CommentContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseComment(CurrentNode as CommentSyntax))
				{
					green = EatNode();
					context = new PilParser.CommentContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseComment();
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
		
		internal PilParser.LiteralContext _Antlr4ParseLiteral()
		{
			BeginNode();
		    PilParser.LiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLiteral(CurrentNode as LiteralSyntax))
				{
					green = EatNode();
					context = new PilParser.LiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal PilParser.TypeReferenceContext _Antlr4ParseTypeReference()
		{
			BeginNode();
		    PilParser.TypeReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeReference(CurrentNode as TypeReferenceSyntax))
				{
					green = EatNode();
					context = new PilParser.TypeReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseBuiltInType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.builtInType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseBuiltInType(BuiltInTypeSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.BuiltInTypeContext _Antlr4ParseBuiltInType()
		{
			BeginNode();
		    PilParser.BuiltInTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseBuiltInType(CurrentNode as BuiltInTypeSyntax))
				{
					green = EatNode();
					context = new PilParser.BuiltInTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseBuiltInType();
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
		
		public GreenNode ParseQualifierList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.qualifierList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQualifierList(QualifierListSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.QualifierListContext _Antlr4ParseQualifierList()
		{
			BeginNode();
		    PilParser.QualifierListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQualifierList(CurrentNode as QualifierListSyntax))
				{
					green = EatNode();
					context = new PilParser.QualifierListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseQualifierList();
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
		
		internal PilParser.QualifierContext _Antlr4ParseQualifier()
		{
			BeginNode();
		    PilParser.QualifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQualifier(CurrentNode as QualifierSyntax))
				{
					green = EatNode();
					context = new PilParser.QualifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal PilParser.NameContext _Antlr4ParseName()
		{
			BeginNode();
		    PilParser.NameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseName(CurrentNode as NameSyntax))
				{
					green = EatNode();
					context = new PilParser.NameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal PilParser.IdentifierListContext _Antlr4ParseIdentifierList()
		{
			BeginNode();
		    PilParser.IdentifierListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIdentifierList(CurrentNode as IdentifierListSyntax))
				{
					green = EatNode();
					context = new PilParser.IdentifierListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal PilParser.IdentifierContext _Antlr4ParseIdentifier()
		{
			BeginNode();
		    PilParser.IdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIdentifier(CurrentNode as IdentifierSyntax))
				{
					green = EatNode();
					context = new PilParser.IdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseResultIdentifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.resultIdentifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseResultIdentifier(ResultIdentifierSyntax node)
		{
			return node != null;
		}
		
		internal PilParser.ResultIdentifierContext _Antlr4ParseResultIdentifier()
		{
			BeginNode();
		    PilParser.ResultIdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseResultIdentifier(CurrentNode as ResultIdentifierSyntax))
				{
					green = EatNode();
					context = new PilParser.ResultIdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseResultIdentifier();
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
		
        private class Antlr4ToRoslynVisitor : PilParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.
			private readonly PilInternalSyntaxFactory _factory;
            private readonly PilSyntaxParser _syntaxParser;
            public Antlr4ToRoslynVisitor(PilSyntaxParser syntaxParser)
            {
				_factory = (PilInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                _syntaxParser = syntaxParser;
            }
            private GreenNode VisitTerminal(IToken token, PilSyntaxKind kind)
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
            private GreenNode VisitTerminal(ITerminalNode node, PilSyntaxKind kind)
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
			
			public override GreenNode VisitMain(PilParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
			    PilParser.DeclarationContext[] declarationContext = context.declaration();
			    var declarationBuilder = _pool.Allocate<DeclarationGreen>();
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				var declaration = declarationBuilder.ToList();
				_pool.Free(declarationBuilder);
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), PilSyntaxKind.Eof);
				return _factory.Main(declaration, eOF);
			}
			
			public override GreenNode VisitDeclaration(PilParser.DeclarationContext context)
			{
				if (context == null) return DeclarationGreen.__Missing;
				PilParser.TypeDefDeclarationContext typeDefDeclarationContext = context.typeDefDeclaration();
				if (typeDefDeclarationContext != null) 
				{
					return _factory.Declaration((TypeDefDeclarationGreen)this.Visit(typeDefDeclarationContext));
				}
				PilParser.ExternalParameterDeclarationContext externalParameterDeclarationContext = context.externalParameterDeclaration();
				if (externalParameterDeclarationContext != null) 
				{
					return _factory.Declaration((ExternalParameterDeclarationGreen)this.Visit(externalParameterDeclarationContext));
				}
				PilParser.EnumDeclarationContext enumDeclarationContext = context.enumDeclaration();
				if (enumDeclarationContext != null) 
				{
					return _factory.Declaration((EnumDeclarationGreen)this.Visit(enumDeclarationContext));
				}
				PilParser.ObjectDeclarationContext objectDeclarationContext = context.objectDeclaration();
				if (objectDeclarationContext != null) 
				{
					return _factory.Declaration((ObjectDeclarationGreen)this.Visit(objectDeclarationContext));
				}
				PilParser.FunctionDeclarationContext functionDeclarationContext = context.functionDeclaration();
				if (functionDeclarationContext != null) 
				{
					return _factory.Declaration((FunctionDeclarationGreen)this.Visit(functionDeclarationContext));
				}
				PilParser.QueryDeclarationContext queryDeclarationContext = context.queryDeclaration();
				if (queryDeclarationContext != null) 
				{
					return _factory.Declaration((QueryDeclarationGreen)this.Visit(queryDeclarationContext));
				}
				return DeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitTypeDefDeclaration(PilParser.TypeDefDeclarationContext context)
			{
				if (context == null) return TypeDefDeclarationGreen.__Missing;
				InternalSyntaxToken kTypeDef = (InternalSyntaxToken)this.VisitTerminal(context.KTypeDef(), PilSyntaxKind.KTypeDef);
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), PilSyntaxKind.TColon);
				PilParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				return _factory.TypeDefDeclaration(kTypeDef, name, tColon, typeReference, tSemicolon);
			}
			
			public override GreenNode VisitExternalParameterDeclaration(PilParser.ExternalParameterDeclarationContext context)
			{
				if (context == null) return ExternalParameterDeclarationGreen.__Missing;
				InternalSyntaxToken kParam = (InternalSyntaxToken)this.VisitTerminal(context.KParam(), PilSyntaxKind.KParam);
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), PilSyntaxKind.TColon);
				PilParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				PilParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				return _factory.ExternalParameterDeclaration(kParam, name, tColon, typeReference, tAssign, expression, tSemicolon);
			}
			
			public override GreenNode VisitEnumDeclaration(PilParser.EnumDeclarationContext context)
			{
				if (context == null) return EnumDeclarationGreen.__Missing;
				InternalSyntaxToken kEnum = (InternalSyntaxToken)this.VisitTerminal(context.KEnum(), PilSyntaxKind.KEnum);
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), PilSyntaxKind.TOpenBracket);
				PilParser.EnumLiteralsContext enumLiteralsContext = context.enumLiterals();
				EnumLiteralsGreen enumLiterals = null;
				if (enumLiteralsContext != null) enumLiterals = (EnumLiteralsGreen)this.Visit(enumLiteralsContext);
				if (enumLiterals == null) enumLiterals = EnumLiteralsGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), PilSyntaxKind.TCloseBracket);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				return _factory.EnumDeclaration(kEnum, name, tOpenBracket, enumLiterals, tCloseBracket, tSemicolon);
			}
			
			public override GreenNode VisitEnumLiterals(PilParser.EnumLiteralsContext context)
			{
				if (context == null) return EnumLiteralsGreen.__Missing;
			    PilParser.EnumLiteralContext[] enumLiteralContext = context.enumLiteral();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var enumLiteralBuilder = _pool.AllocateSeparated<EnumLiteralGreen>();
			    for (int i = 0; i < enumLiteralContext.Length; i++)
			    {
			        enumLiteralBuilder.Add((EnumLiteralGreen)this.Visit(enumLiteralContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            enumLiteralBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var enumLiteral = enumLiteralBuilder.ToList();
				_pool.Free(enumLiteralBuilder);
				return _factory.EnumLiterals(enumLiteral);
			}
			
			public override GreenNode VisitEnumLiteral(PilParser.EnumLiteralContext context)
			{
				if (context == null) return EnumLiteralGreen.__Missing;
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.EnumLiteral(name);
			}
			
			public override GreenNode VisitObjectDeclaration(PilParser.ObjectDeclarationContext context)
			{
				if (context == null) return ObjectDeclarationGreen.__Missing;
				InternalSyntaxToken kObject = (InternalSyntaxToken)this.VisitTerminal(context.KObject(), PilSyntaxKind.KObject);
				PilParser.ObjectHeaderContext objectHeaderContext = context.objectHeader();
				ObjectHeaderGreen objectHeader = null;
				if (objectHeaderContext != null) objectHeader = (ObjectHeaderGreen)this.Visit(objectHeaderContext);
				if (objectHeader == null) objectHeader = ObjectHeaderGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				PilParser.ObjectExternalParametersContext objectExternalParametersContext = context.objectExternalParameters();
				ObjectExternalParametersGreen objectExternalParameters = null;
				if (objectExternalParametersContext != null) objectExternalParameters = (ObjectExternalParametersGreen)this.Visit(objectExternalParametersContext);
				if (objectExternalParameters == null) objectExternalParameters = ObjectExternalParametersGreen.__Missing;
				PilParser.ObjectFieldsContext objectFieldsContext = context.objectFields();
				ObjectFieldsGreen objectFields = null;
				if (objectFieldsContext != null) objectFields = (ObjectFieldsGreen)this.Visit(objectFieldsContext);
				if (objectFields == null) objectFields = ObjectFieldsGreen.__Missing;
				PilParser.ObjectFunctionsContext objectFunctionsContext = context.objectFunctions();
				ObjectFunctionsGreen objectFunctions = null;
				if (objectFunctionsContext != null) objectFunctions = (ObjectFunctionsGreen)this.Visit(objectFunctionsContext);
				if (objectFunctions == null) objectFunctions = ObjectFunctionsGreen.__Missing;
				InternalSyntaxToken kEndObject = (InternalSyntaxToken)this.VisitTerminal(context.KEndObject(), PilSyntaxKind.KEndObject);
				return _factory.ObjectDeclaration(kObject, objectHeader, tSemicolon, objectExternalParameters, objectFields, objectFunctions, kEndObject);
			}
			
			public override GreenNode VisitObjectHeader(PilParser.ObjectHeaderContext context)
			{
				if (context == null) return ObjectHeaderGreen.__Missing;
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), PilSyntaxKind.TOpenParen);
				PilParser.PortsContext portsContext = context.ports();
				PortsGreen ports = null;
				if (portsContext != null) ports = (PortsGreen)this.Visit(portsContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), PilSyntaxKind.TCloseParen);
				return _factory.ObjectHeader(name, tOpenParen, ports, tCloseParen);
			}
			
			public override GreenNode VisitPorts(PilParser.PortsContext context)
			{
				if (context == null) return PortsGreen.__Missing;
			    PilParser.PortContext[] portContext = context.port();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var portBuilder = _pool.AllocateSeparated<PortGreen>();
			    for (int i = 0; i < portContext.Length; i++)
			    {
			        portBuilder.Add((PortGreen)this.Visit(portContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            portBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var port = portBuilder.ToList();
				_pool.Free(portBuilder);
				return _factory.Ports(port);
			}
			
			public override GreenNode VisitPort(PilParser.PortContext context)
			{
				if (context == null) return PortGreen.__Missing;
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.Port(name);
			}
			
			public override GreenNode VisitObjectExternalParameters(PilParser.ObjectExternalParametersContext context)
			{
				if (context == null) return ObjectExternalParametersGreen.__Missing;
			    PilParser.ExternalParameterDeclarationContext[] externalParameterDeclarationContext = context.externalParameterDeclaration();
			    var externalParameterDeclarationBuilder = _pool.Allocate<ExternalParameterDeclarationGreen>();
			    for (int i = 0; i < externalParameterDeclarationContext.Length; i++)
			    {
			        externalParameterDeclarationBuilder.Add((ExternalParameterDeclarationGreen)this.Visit(externalParameterDeclarationContext[i]));
			    }
				var externalParameterDeclaration = externalParameterDeclarationBuilder.ToList();
				_pool.Free(externalParameterDeclarationBuilder);
				return _factory.ObjectExternalParameters(externalParameterDeclaration);
			}
			
			public override GreenNode VisitObjectFields(PilParser.ObjectFieldsContext context)
			{
				if (context == null) return ObjectFieldsGreen.__Missing;
			    PilParser.VariableDeclarationContext[] variableDeclarationContext = context.variableDeclaration();
			    var variableDeclarationBuilder = _pool.Allocate<VariableDeclarationGreen>();
			    for (int i = 0; i < variableDeclarationContext.Length; i++)
			    {
			        variableDeclarationBuilder.Add((VariableDeclarationGreen)this.Visit(variableDeclarationContext[i]));
			    }
				var variableDeclaration = variableDeclarationBuilder.ToList();
				_pool.Free(variableDeclarationBuilder);
				return _factory.ObjectFields(variableDeclaration);
			}
			
			public override GreenNode VisitObjectFunctions(PilParser.ObjectFunctionsContext context)
			{
				if (context == null) return ObjectFunctionsGreen.__Missing;
			    PilParser.FunctionDeclarationContext[] functionDeclarationContext = context.functionDeclaration();
			    var functionDeclarationBuilder = _pool.Allocate<FunctionDeclarationGreen>();
			    for (int i = 0; i < functionDeclarationContext.Length; i++)
			    {
			        functionDeclarationBuilder.Add((FunctionDeclarationGreen)this.Visit(functionDeclarationContext[i]));
			    }
				var functionDeclaration = functionDeclarationBuilder.ToList();
				_pool.Free(functionDeclarationBuilder);
				return _factory.ObjectFunctions(functionDeclaration);
			}
			
			public override GreenNode VisitFunctionDeclaration(PilParser.FunctionDeclarationContext context)
			{
				if (context == null) return FunctionDeclarationGreen.__Missing;
				InternalSyntaxToken kFunction = (InternalSyntaxToken)this.VisitTerminal(context.KFunction(), PilSyntaxKind.KFunction);
				PilParser.FunctionHeaderContext functionHeaderContext = context.functionHeader();
				FunctionHeaderGreen functionHeader = null;
				if (functionHeaderContext != null) functionHeader = (FunctionHeaderGreen)this.Visit(functionHeaderContext);
				if (functionHeader == null) functionHeader = FunctionHeaderGreen.__Missing;
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				PilParser.StatementsContext statementsContext = context.statements();
				StatementsGreen statements = null;
				if (statementsContext != null) statements = (StatementsGreen)this.Visit(statementsContext);
				InternalSyntaxToken kEndFunction = (InternalSyntaxToken)this.VisitTerminal(context.KEndFunction(), PilSyntaxKind.KEndFunction);
				return _factory.FunctionDeclaration(kFunction, functionHeader, comment, tSemicolon, statements, kEndFunction);
			}
			
			public override GreenNode VisitFunctionHeader(PilParser.FunctionHeaderContext context)
			{
				if (context == null) return FunctionHeaderGreen.__Missing;
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), PilSyntaxKind.TOpenParen);
				PilParser.FunctionParamsContext functionParamsContext = context.functionParams();
				FunctionParamsGreen functionParams = null;
				if (functionParamsContext != null) functionParams = (FunctionParamsGreen)this.Visit(functionParamsContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), PilSyntaxKind.TCloseParen);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), PilSyntaxKind.TColon);
				PilParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				return _factory.FunctionHeader(name, tOpenParen, functionParams, tCloseParen, tColon, typeReference);
			}
			
			public override GreenNode VisitFunctionParams(PilParser.FunctionParamsContext context)
			{
				if (context == null) return FunctionParamsGreen.__Missing;
			    PilParser.ParamContext[] paramContext = context.param();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var paramBuilder = _pool.AllocateSeparated<ParamGreen>();
			    for (int i = 0; i < paramContext.Length; i++)
			    {
			        paramBuilder.Add((ParamGreen)this.Visit(paramContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            paramBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var param = paramBuilder.ToList();
				_pool.Free(paramBuilder);
				return _factory.FunctionParams(param);
			}
			
			public override GreenNode VisitParam(PilParser.ParamContext context)
			{
				if (context == null) return ParamGreen.__Missing;
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), PilSyntaxKind.TColon);
				PilParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				return _factory.Param(name, tColon, typeReference);
			}
			
			public override GreenNode VisitQueryDeclaration(PilParser.QueryDeclarationContext context)
			{
				if (context == null) return QueryDeclarationGreen.__Missing;
				InternalSyntaxToken kQuery = (InternalSyntaxToken)this.VisitTerminal(context.KQuery(), PilSyntaxKind.KQuery);
				PilParser.QueryHeaderContext queryHeaderContext = context.queryHeader();
				QueryHeaderGreen queryHeader = null;
				if (queryHeaderContext != null) queryHeader = (QueryHeaderGreen)this.Visit(queryHeaderContext);
				if (queryHeader == null) queryHeader = QueryHeaderGreen.__Missing;
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken startQuerySemicolon = (InternalSyntaxToken)this.VisitTerminal(context.startQuerySemicolon, PilSyntaxKind.TSemicolon);
			    PilParser.QueryExternalParametersContext[] queryExternalParametersContext = context.queryExternalParameters();
			    var queryExternalParametersBuilder = _pool.Allocate<QueryExternalParametersGreen>();
			    for (int i = 0; i < queryExternalParametersContext.Length; i++)
			    {
			        queryExternalParametersBuilder.Add((QueryExternalParametersGreen)this.Visit(queryExternalParametersContext[i]));
			    }
				var queryExternalParameters = queryExternalParametersBuilder.ToList();
				_pool.Free(queryExternalParametersBuilder);
			    PilParser.QueryFieldContext[] queryFieldContext = context.queryField();
			    var queryFieldBuilder = _pool.Allocate<QueryFieldGreen>();
			    for (int i = 0; i < queryFieldContext.Length; i++)
			    {
			        queryFieldBuilder.Add((QueryFieldGreen)this.Visit(queryFieldContext[i]));
			    }
				var queryField = queryFieldBuilder.ToList();
				_pool.Free(queryFieldBuilder);
			    PilParser.FunctionDeclarationContext[] functionDeclarationContext = context.functionDeclaration();
			    var functionDeclarationBuilder = _pool.Allocate<FunctionDeclarationGreen>();
			    for (int i = 0; i < functionDeclarationContext.Length; i++)
			    {
			        functionDeclarationBuilder.Add((FunctionDeclarationGreen)this.Visit(functionDeclarationContext[i]));
			    }
				var functionDeclaration = functionDeclarationBuilder.ToList();
				_pool.Free(functionDeclarationBuilder);
			    PilParser.QueryObjectContext[] queryObjectContext = context.queryObject();
			    var queryObjectBuilder = _pool.Allocate<QueryObjectGreen>();
			    for (int i = 0; i < queryObjectContext.Length; i++)
			    {
			        queryObjectBuilder.Add((QueryObjectGreen)this.Visit(queryObjectContext[i]));
			    }
				var queryObject = queryObjectBuilder.ToList();
				_pool.Free(queryObjectBuilder);
				InternalSyntaxToken kEndQuery = (InternalSyntaxToken)this.VisitTerminal(context.KEndQuery(), PilSyntaxKind.KEndQuery);
				PilParser.IdentifierContext endNameContext = context.endName;
				IdentifierGreen endName = null;
				if (endNameContext != null) endName = (IdentifierGreen)this.Visit(endNameContext);
				InternalSyntaxToken endQuerySemicolon = (InternalSyntaxToken)this.VisitTerminal(context.endQuerySemicolon, PilSyntaxKind.TSemicolon);
				return _factory.QueryDeclaration(kQuery, queryHeader, comment, startQuerySemicolon, queryExternalParameters, queryField, functionDeclaration, queryObject, kEndQuery, endName, endQuerySemicolon);
			}
			
			public override GreenNode VisitQueryHeader(PilParser.QueryHeaderContext context)
			{
				if (context == null) return QueryHeaderGreen.__Missing;
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), PilSyntaxKind.TOpenParen);
				PilParser.QueryRequestParamsContext queryRequestParamsContext = context.queryRequestParams();
				QueryRequestParamsGreen queryRequestParams = null;
				if (queryRequestParamsContext != null) queryRequestParams = (QueryRequestParamsGreen)this.Visit(queryRequestParamsContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), PilSyntaxKind.TCloseParen);
				return _factory.QueryHeader(name, tOpenParen, queryRequestParams, tCloseParen);
			}
			
			public override GreenNode VisitQueryRequestParams(PilParser.QueryRequestParamsContext context)
			{
				if (context == null) return QueryRequestParamsGreen.__Missing;
				InternalSyntaxToken kRequest = (InternalSyntaxToken)this.VisitTerminal(context.KRequest());
			    PilParser.ParamContext[] paramContext = context.param();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var paramBuilder = _pool.AllocateSeparated<ParamGreen>();
			    for (int i = 0; i < paramContext.Length; i++)
			    {
			        paramBuilder.Add((ParamGreen)this.Visit(paramContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            paramBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var param = paramBuilder.ToList();
				_pool.Free(paramBuilder);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return _factory.QueryRequestParams(kRequest, param, tSemicolon);
			}
			
			public override GreenNode VisitQueryAcceptParams(PilParser.QueryAcceptParamsContext context)
			{
				if (context == null) return QueryAcceptParamsGreen.__Missing;
				InternalSyntaxToken kAccept = (InternalSyntaxToken)this.VisitTerminal(context.KAccept(), PilSyntaxKind.KAccept);
			    PilParser.ParamContext[] paramContext = context.param();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var paramBuilder = _pool.AllocateSeparated<ParamGreen>();
			    for (int i = 0; i < paramContext.Length; i++)
			    {
			        paramBuilder.Add((ParamGreen)this.Visit(paramContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            paramBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var param = paramBuilder.ToList();
				_pool.Free(paramBuilder);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return _factory.QueryAcceptParams(kAccept, param, tSemicolon);
			}
			
			public override GreenNode VisitQueryRefuseParams(PilParser.QueryRefuseParamsContext context)
			{
				if (context == null) return QueryRefuseParamsGreen.__Missing;
				InternalSyntaxToken kRefuse = (InternalSyntaxToken)this.VisitTerminal(context.KRefuse(), PilSyntaxKind.KRefuse);
			    PilParser.ParamContext[] paramContext = context.param();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var paramBuilder = _pool.AllocateSeparated<ParamGreen>();
			    for (int i = 0; i < paramContext.Length; i++)
			    {
			        paramBuilder.Add((ParamGreen)this.Visit(paramContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            paramBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var param = paramBuilder.ToList();
				_pool.Free(paramBuilder);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return _factory.QueryRefuseParams(kRefuse, param, tSemicolon);
			}
			
			public override GreenNode VisitQueryCancelParams(PilParser.QueryCancelParamsContext context)
			{
				if (context == null) return QueryCancelParamsGreen.__Missing;
				InternalSyntaxToken kCancel = (InternalSyntaxToken)this.VisitTerminal(context.KCancel(), PilSyntaxKind.KCancel);
			    PilParser.ParamContext[] paramContext = context.param();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var paramBuilder = _pool.AllocateSeparated<ParamGreen>();
			    for (int i = 0; i < paramContext.Length; i++)
			    {
			        paramBuilder.Add((ParamGreen)this.Visit(paramContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            paramBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var param = paramBuilder.ToList();
				_pool.Free(paramBuilder);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return _factory.QueryCancelParams(kCancel, param, tSemicolon);
			}
			
			public override GreenNode VisitQueryExternalParameters(PilParser.QueryExternalParametersContext context)
			{
				if (context == null) return QueryExternalParametersGreen.__Missing;
				PilParser.ExternalParameterDeclarationContext externalParameterDeclarationContext = context.externalParameterDeclaration();
				ExternalParameterDeclarationGreen externalParameterDeclaration = null;
				if (externalParameterDeclarationContext != null) externalParameterDeclaration = (ExternalParameterDeclarationGreen)this.Visit(externalParameterDeclarationContext);
				if (externalParameterDeclaration == null) externalParameterDeclaration = ExternalParameterDeclarationGreen.__Missing;
				return _factory.QueryExternalParameters(externalParameterDeclaration);
			}
			
			public override GreenNode VisitQueryField(PilParser.QueryFieldContext context)
			{
				if (context == null) return QueryFieldGreen.__Missing;
				PilParser.VariableDeclarationContext variableDeclarationContext = context.variableDeclaration();
				VariableDeclarationGreen variableDeclaration = null;
				if (variableDeclarationContext != null) variableDeclaration = (VariableDeclarationGreen)this.Visit(variableDeclarationContext);
				if (variableDeclaration == null) variableDeclaration = VariableDeclarationGreen.__Missing;
				return _factory.QueryField(variableDeclaration);
			}
			
			public override GreenNode VisitQueryFunction(PilParser.QueryFunctionContext context)
			{
				if (context == null) return QueryFunctionGreen.__Missing;
				PilParser.FunctionDeclarationContext functionDeclarationContext = context.functionDeclaration();
				FunctionDeclarationGreen functionDeclaration = null;
				if (functionDeclarationContext != null) functionDeclaration = (FunctionDeclarationGreen)this.Visit(functionDeclarationContext);
				if (functionDeclaration == null) functionDeclaration = FunctionDeclarationGreen.__Missing;
				return _factory.QueryFunction(functionDeclaration);
			}
			
			public override GreenNode VisitQueryObject(PilParser.QueryObjectContext context)
			{
				if (context == null) return QueryObjectGreen.__Missing;
				InternalSyntaxToken kObject = (InternalSyntaxToken)this.VisitTerminal(context.KObject(), PilSyntaxKind.KObject);
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken startObjectSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.startObjectSemicolon, PilSyntaxKind.TSemicolon);
			    PilParser.QueryObjectFieldContext[] queryObjectFieldContext = context.queryObjectField();
			    var queryObjectFieldBuilder = _pool.Allocate<QueryObjectFieldGreen>();
			    for (int i = 0; i < queryObjectFieldContext.Length; i++)
			    {
			        queryObjectFieldBuilder.Add((QueryObjectFieldGreen)this.Visit(queryObjectFieldContext[i]));
			    }
				var queryObjectField = queryObjectFieldBuilder.ToList();
				_pool.Free(queryObjectFieldBuilder);
			    PilParser.QueryObjectFunctionContext[] queryObjectFunctionContext = context.queryObjectFunction();
			    var queryObjectFunctionBuilder = _pool.Allocate<QueryObjectFunctionGreen>();
			    for (int i = 0; i < queryObjectFunctionContext.Length; i++)
			    {
			        queryObjectFunctionBuilder.Add((QueryObjectFunctionGreen)this.Visit(queryObjectFunctionContext[i]));
			    }
				var queryObjectFunction = queryObjectFunctionBuilder.ToList();
				_pool.Free(queryObjectFunctionBuilder);
			    PilParser.QueryObjectEventContext[] queryObjectEventContext = context.queryObjectEvent();
			    var queryObjectEventBuilder = _pool.Allocate<QueryObjectEventGreen>();
			    for (int i = 0; i < queryObjectEventContext.Length; i++)
			    {
			        queryObjectEventBuilder.Add((QueryObjectEventGreen)this.Visit(queryObjectEventContext[i]));
			    }
				var queryObjectEvent = queryObjectEventBuilder.ToList();
				_pool.Free(queryObjectEventBuilder);
				InternalSyntaxToken kEndObject = (InternalSyntaxToken)this.VisitTerminal(context.KEndObject(), PilSyntaxKind.KEndObject);
				PilParser.IdentifierContext endNameContext = context.endName;
				IdentifierGreen endName = null;
				if (endNameContext != null) endName = (IdentifierGreen)this.Visit(endNameContext);
				InternalSyntaxToken endObjectSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.endObjectSemicolon, PilSyntaxKind.TSemicolon);
				return _factory.QueryObject(kObject, name, comment, startObjectSemicolon, queryObjectField, queryObjectFunction, queryObjectEvent, kEndObject, endName, endObjectSemicolon);
			}
			
			public override GreenNode VisitQueryObjectField(PilParser.QueryObjectFieldContext context)
			{
				if (context == null) return QueryObjectFieldGreen.__Missing;
				PilParser.VariableDeclarationContext variableDeclarationContext = context.variableDeclaration();
				VariableDeclarationGreen variableDeclaration = null;
				if (variableDeclarationContext != null) variableDeclaration = (VariableDeclarationGreen)this.Visit(variableDeclarationContext);
				if (variableDeclaration == null) variableDeclaration = VariableDeclarationGreen.__Missing;
				return _factory.QueryObjectField(variableDeclaration);
			}
			
			public override GreenNode VisitQueryObjectFunction(PilParser.QueryObjectFunctionContext context)
			{
				if (context == null) return QueryObjectFunctionGreen.__Missing;
				PilParser.FunctionDeclarationContext functionDeclarationContext = context.functionDeclaration();
				FunctionDeclarationGreen functionDeclaration = null;
				if (functionDeclarationContext != null) functionDeclaration = (FunctionDeclarationGreen)this.Visit(functionDeclarationContext);
				if (functionDeclaration == null) functionDeclaration = FunctionDeclarationGreen.__Missing;
				return _factory.QueryObjectFunction(functionDeclaration);
			}
			
			public override GreenNode VisitQueryObjectEvent(PilParser.QueryObjectEventContext context)
			{
				if (context == null) return QueryObjectEventGreen.__Missing;
				PilParser.InputContext inputContext = context.input();
				if (inputContext != null) 
				{
					return _factory.QueryObjectEvent((InputGreen)this.Visit(inputContext));
				}
				PilParser.TriggerContext triggerContext = context.trigger();
				if (triggerContext != null) 
				{
					return _factory.QueryObjectEvent((TriggerGreen)this.Visit(triggerContext));
				}
				return QueryObjectEventGreen.__Missing;
			}
			
			public override GreenNode VisitInput(PilParser.InputContext context)
			{
				if (context == null) return InputGreen.__Missing;
				InternalSyntaxToken kInput = (InternalSyntaxToken)this.VisitTerminal(context.KInput(), PilSyntaxKind.KInput);
				PilParser.InputPortListContext inputPortListContext = context.inputPortList();
				InputPortListGreen inputPortList = null;
				if (inputPortListContext != null) inputPortList = (InputPortListGreen)this.Visit(inputPortListContext);
				if (inputPortList == null) inputPortList = InputPortListGreen.__Missing;
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				PilParser.StatementsContext statementsContext = context.statements();
				StatementsGreen statements = null;
				if (statementsContext != null) statements = (StatementsGreen)this.Visit(statementsContext);
				return _factory.Input(kInput, inputPortList, comment, tSemicolon, statements);
			}
			
			public override GreenNode VisitInputPortList(PilParser.InputPortListContext context)
			{
				if (context == null) return InputPortListGreen.__Missing;
			    PilParser.InputPortContext[] inputPortContext = context.inputPort();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var inputPortBuilder = _pool.AllocateSeparated<InputPortGreen>();
			    for (int i = 0; i < inputPortContext.Length; i++)
			    {
			        inputPortBuilder.Add((InputPortGreen)this.Visit(inputPortContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            inputPortBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var inputPort = inputPortBuilder.ToList();
				_pool.Free(inputPortBuilder);
				return _factory.InputPortList(inputPort);
			}
			
			public override GreenNode VisitInputPort(PilParser.InputPortContext context)
			{
				if (context == null) return InputPortGreen.__Missing;
				PilParser.IdentifierContext portNameContext = context.portName;
				IdentifierGreen portName = null;
				if (portNameContext != null) portName = (IdentifierGreen)this.Visit(portNameContext);
				if (portName == null) portName = IdentifierGreen.__Missing;
				InternalSyntaxToken tDot = (InternalSyntaxToken)this.VisitTerminal(context.TDot());
				PilParser.IdentifierContext queryNameContext = context.queryName;
				IdentifierGreen queryName = null;
				if (queryNameContext != null) queryName = (IdentifierGreen)this.Visit(queryNameContext);
				return _factory.InputPort(portName, tDot, queryName);
			}
			
			public override GreenNode VisitTrigger(PilParser.TriggerContext context)
			{
				if (context == null) return TriggerGreen.__Missing;
				InternalSyntaxToken kTrigger = (InternalSyntaxToken)this.VisitTerminal(context.KTrigger(), PilSyntaxKind.KTrigger);
				PilParser.TriggerVarListContext triggerVarListContext = context.triggerVarList();
				TriggerVarListGreen triggerVarList = null;
				if (triggerVarListContext != null) triggerVarList = (TriggerVarListGreen)this.Visit(triggerVarListContext);
				if (triggerVarList == null) triggerVarList = TriggerVarListGreen.__Missing;
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				PilParser.StatementsContext statementsContext = context.statements();
				StatementsGreen statements = null;
				if (statementsContext != null) statements = (StatementsGreen)this.Visit(statementsContext);
				return _factory.Trigger(kTrigger, triggerVarList, comment, tSemicolon, statements);
			}
			
			public override GreenNode VisitTriggerVarList(PilParser.TriggerVarListContext context)
			{
				if (context == null) return TriggerVarListGreen.__Missing;
			    PilParser.TriggerVarContext[] triggerVarContext = context.triggerVar();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var triggerVarBuilder = _pool.AllocateSeparated<TriggerVarGreen>();
			    for (int i = 0; i < triggerVarContext.Length; i++)
			    {
			        triggerVarBuilder.Add((TriggerVarGreen)this.Visit(triggerVarContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            triggerVarBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var triggerVar = triggerVarBuilder.ToList();
				_pool.Free(triggerVarBuilder);
				return _factory.TriggerVarList(triggerVar);
			}
			
			public override GreenNode VisitTriggerVar(PilParser.TriggerVarContext context)
			{
				if (context == null) return TriggerVarGreen.__Missing;
				PilParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.TriggerVar(identifier);
			}
			
			public override GreenNode VisitStatements(PilParser.StatementsContext context)
			{
				if (context == null) return StatementsGreen.__Missing;
			    PilParser.StatementContext[] statementContext = context.statement();
			    var statementBuilder = _pool.Allocate<StatementGreen>();
			    for (int i = 0; i < statementContext.Length; i++)
			    {
			        statementBuilder.Add((StatementGreen)this.Visit(statementContext[i]));
			    }
				var statement = statementBuilder.ToList();
				_pool.Free(statementBuilder);
				return _factory.Statements(statement);
			}
			
			public override GreenNode VisitStatement(PilParser.StatementContext context)
			{
				if (context == null) return StatementGreen.__Missing;
				PilParser.VariableDeclarationStatementContext variableDeclarationStatementContext = context.variableDeclarationStatement();
				if (variableDeclarationStatementContext != null) 
				{
					return _factory.Statement((VariableDeclarationStatementGreen)this.Visit(variableDeclarationStatementContext));
				}
				PilParser.RequestStatementContext requestStatementContext = context.requestStatement();
				if (requestStatementContext != null) 
				{
					return _factory.Statement((RequestStatementGreen)this.Visit(requestStatementContext));
				}
				PilParser.ForkStatementContext forkStatementContext = context.forkStatement();
				if (forkStatementContext != null) 
				{
					return _factory.Statement((ForkStatementGreen)this.Visit(forkStatementContext));
				}
				PilParser.ForkRequestStatementContext forkRequestStatementContext = context.forkRequestStatement();
				if (forkRequestStatementContext != null) 
				{
					return _factory.Statement((ForkRequestStatementGreen)this.Visit(forkRequestStatementContext));
				}
				PilParser.IfStatementContext ifStatementContext = context.ifStatement();
				if (ifStatementContext != null) 
				{
					return _factory.Statement((IfStatementGreen)this.Visit(ifStatementContext));
				}
				PilParser.ResponseStatementContext responseStatementContext = context.responseStatement();
				if (responseStatementContext != null) 
				{
					return _factory.Statement((ResponseStatementGreen)this.Visit(responseStatementContext));
				}
				PilParser.CancelStatementContext cancelStatementContext = context.cancelStatement();
				if (cancelStatementContext != null) 
				{
					return _factory.Statement((CancelStatementGreen)this.Visit(cancelStatementContext));
				}
				PilParser.AssignmentStatementContext assignmentStatementContext = context.assignmentStatement();
				if (assignmentStatementContext != null) 
				{
					return _factory.Statement((AssignmentStatementGreen)this.Visit(assignmentStatementContext));
				}
				return StatementGreen.__Missing;
			}
			
			public override GreenNode VisitForkStatement(PilParser.ForkStatementContext context)
			{
				if (context == null) return ForkStatementGreen.__Missing;
				InternalSyntaxToken kFork = (InternalSyntaxToken)this.VisitTerminal(context.KFork(), PilSyntaxKind.KFork);
				PilParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
			    PilParser.CaseBranchContext[] caseBranchContext = context.caseBranch();
			    var caseBranchBuilder = _pool.Allocate<CaseBranchGreen>();
			    for (int i = 0; i < caseBranchContext.Length; i++)
			    {
			        caseBranchBuilder.Add((CaseBranchGreen)this.Visit(caseBranchContext[i]));
			    }
				var caseBranch = caseBranchBuilder.ToList();
				_pool.Free(caseBranchBuilder);
				PilParser.ElseBranchContext elseBranchContext = context.elseBranch();
				ElseBranchGreen elseBranch = null;
				if (elseBranchContext != null) elseBranch = (ElseBranchGreen)this.Visit(elseBranchContext);
				InternalSyntaxToken kEndFork = (InternalSyntaxToken)this.VisitTerminal(context.KEndFork(), PilSyntaxKind.KEndFork);
				return _factory.ForkStatement(kFork, expression, caseBranch, elseBranch, kEndFork);
			}
			
			public override GreenNode VisitCaseBranch(PilParser.CaseBranchContext context)
			{
				if (context == null) return CaseBranchGreen.__Missing;
				InternalSyntaxToken kCase = (InternalSyntaxToken)this.VisitTerminal(context.KCase(), PilSyntaxKind.KCase);
				PilParser.ExpressionContext conditionContext = context.condition;
				ExpressionGreen condition = null;
				if (conditionContext != null) condition = (ExpressionGreen)this.Visit(conditionContext);
				if (condition == null) condition = ExpressionGreen.__Missing;
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				PilParser.StatementsContext statementsContext = context.statements();
				StatementsGreen statements = null;
				if (statementsContext != null) statements = (StatementsGreen)this.Visit(statementsContext);
				return _factory.CaseBranch(kCase, condition, comment, tSemicolon, statements);
			}
			
			public override GreenNode VisitElseBranch(PilParser.ElseBranchContext context)
			{
				if (context == null) return ElseBranchGreen.__Missing;
				InternalSyntaxToken kElse = (InternalSyntaxToken)this.VisitTerminal(context.KElse(), PilSyntaxKind.KElse);
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				PilParser.StatementsContext statementsContext = context.statements();
				StatementsGreen statements = null;
				if (statementsContext != null) statements = (StatementsGreen)this.Visit(statementsContext);
				return _factory.ElseBranch(kElse, comment, statements);
			}
			
			public override GreenNode VisitIfStatement(PilParser.IfStatementContext context)
			{
				if (context == null) return IfStatementGreen.__Missing;
				InternalSyntaxToken kIf = (InternalSyntaxToken)this.VisitTerminal(context.KIf(), PilSyntaxKind.KIf);
				PilParser.IfBranchContext ifBranchContext = context.ifBranch();
				IfBranchGreen ifBranch = null;
				if (ifBranchContext != null) ifBranch = (IfBranchGreen)this.Visit(ifBranchContext);
				if (ifBranch == null) ifBranch = IfBranchGreen.__Missing;
			    PilParser.ElseIfBranchContext[] elseIfBranchContext = context.elseIfBranch();
			    var elseIfBranchBuilder = _pool.Allocate<ElseIfBranchGreen>();
			    for (int i = 0; i < elseIfBranchContext.Length; i++)
			    {
			        elseIfBranchBuilder.Add((ElseIfBranchGreen)this.Visit(elseIfBranchContext[i]));
			    }
				var elseIfBranch = elseIfBranchBuilder.ToList();
				_pool.Free(elseIfBranchBuilder);
			    PilParser.ElseBranchContext[] elseBranchContext = context.elseBranch();
			    var elseBranchBuilder = _pool.Allocate<ElseBranchGreen>();
			    for (int i = 0; i < elseBranchContext.Length; i++)
			    {
			        elseBranchBuilder.Add((ElseBranchGreen)this.Visit(elseBranchContext[i]));
			    }
				var elseBranch = elseBranchBuilder.ToList();
				_pool.Free(elseBranchBuilder);
				InternalSyntaxToken kEndIf = (InternalSyntaxToken)this.VisitTerminal(context.KEndIf(), PilSyntaxKind.KEndIf);
				return _factory.IfStatement(kIf, ifBranch, elseIfBranch, elseBranch, kEndIf);
			}
			
			public override GreenNode VisitIfBranch(PilParser.IfBranchContext context)
			{
				if (context == null) return IfBranchGreen.__Missing;
				PilParser.ConditionalExpressionContext conditionalExpressionContext = context.conditionalExpression();
				ConditionalExpressionGreen conditionalExpression = null;
				if (conditionalExpressionContext != null) conditionalExpression = (ConditionalExpressionGreen)this.Visit(conditionalExpressionContext);
				if (conditionalExpression == null) conditionalExpression = ConditionalExpressionGreen.__Missing;
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				PilParser.StatementsContext statementsContext = context.statements();
				StatementsGreen statements = null;
				if (statementsContext != null) statements = (StatementsGreen)this.Visit(statementsContext);
				return _factory.IfBranch(conditionalExpression, comment, tSemicolon, statements);
			}
			
			public override GreenNode VisitElseIfBranch(PilParser.ElseIfBranchContext context)
			{
				if (context == null) return ElseIfBranchGreen.__Missing;
				InternalSyntaxToken kElse = (InternalSyntaxToken)this.VisitTerminal(context.KElse(), PilSyntaxKind.KElse);
				InternalSyntaxToken kIf = (InternalSyntaxToken)this.VisitTerminal(context.KIf(), PilSyntaxKind.KIf);
				PilParser.IfBranchContext ifBranchContext = context.ifBranch();
				IfBranchGreen ifBranch = null;
				if (ifBranchContext != null) ifBranch = (IfBranchGreen)this.Visit(ifBranchContext);
				if (ifBranch == null) ifBranch = IfBranchGreen.__Missing;
				return _factory.ElseIfBranch(kElse, kIf, ifBranch);
			}
			
			public override GreenNode VisitRequestStatement(PilParser.RequestStatementContext context)
			{
				if (context == null) return RequestStatementGreen.__Missing;
				PilParser.LeftSideContext leftSideContext = context.leftSide();
				LeftSideGreen leftSide = null;
				if (leftSideContext != null) leftSide = (LeftSideGreen)this.Visit(leftSideContext);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				PilParser.CallRequestContext callRequestContext = context.callRequest();
				CallRequestGreen callRequest = null;
				if (callRequestContext != null) callRequest = (CallRequestGreen)this.Visit(callRequestContext);
				if (callRequest == null) callRequest = CallRequestGreen.__Missing;
				PilParser.AssertionContext assertionContext = context.assertion();
				AssertionGreen assertion = null;
				if (assertionContext != null) assertion = (AssertionGreen)this.Visit(assertionContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				return _factory.RequestStatement(leftSide, tAssign, callRequest, assertion, tSemicolon);
			}
			
			public override GreenNode VisitCallRequest(PilParser.CallRequestContext context)
			{
				if (context == null) return CallRequestGreen.__Missing;
				InternalSyntaxToken kRequest = (InternalSyntaxToken)this.VisitTerminal(context.KRequest(), PilSyntaxKind.KRequest);
				PilParser.IdentifierContext portNameContext = context.portName;
				IdentifierGreen portName = null;
				if (portNameContext != null) portName = (IdentifierGreen)this.Visit(portNameContext);
				if (portName == null) portName = IdentifierGreen.__Missing;
				InternalSyntaxToken tDot = (InternalSyntaxToken)this.VisitTerminal(context.TDot());
				PilParser.IdentifierContext queryNameContext = context.queryName;
				IdentifierGreen queryName = null;
				if (queryNameContext != null) queryName = (IdentifierGreen)this.Visit(queryNameContext);
				PilParser.RequestArgumentsContext requestArgumentsContext = context.requestArguments();
				RequestArgumentsGreen requestArguments = null;
				if (requestArgumentsContext != null) requestArguments = (RequestArgumentsGreen)this.Visit(requestArgumentsContext);
				return _factory.CallRequest(kRequest, portName, tDot, queryName, requestArguments);
			}
			
			public override GreenNode VisitRequestArguments(PilParser.RequestArgumentsContext context)
			{
				if (context == null) return RequestArgumentsGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), PilSyntaxKind.TOpenParen);
				PilParser.ExpressionListContext expressionListContext = context.expressionList();
				ExpressionListGreen expressionList = null;
				if (expressionListContext != null) expressionList = (ExpressionListGreen)this.Visit(expressionListContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), PilSyntaxKind.TCloseParen);
				return _factory.RequestArguments(tOpenParen, expressionList, tCloseParen);
			}
			
			public override GreenNode VisitResponseStatement(PilParser.ResponseStatementContext context)
			{
				if (context == null) return ResponseStatementGreen.__Missing;
				PilParser.ResponseStatementKindContext responseStatementKindContext = context.responseStatementKind();
				ResponseStatementKindGreen responseStatementKind = null;
				if (responseStatementKindContext != null) responseStatementKind = (ResponseStatementKindGreen)this.Visit(responseStatementKindContext);
				if (responseStatementKind == null) responseStatementKind = ResponseStatementKindGreen.__Missing;
				PilParser.AssertionContext assertionContext = context.assertion();
				AssertionGreen assertion = null;
				if (assertionContext != null) assertion = (AssertionGreen)this.Visit(assertionContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				return _factory.ResponseStatement(responseStatementKind, assertion, tSemicolon);
			}
			
			public override GreenNode VisitCancelStatement(PilParser.CancelStatementContext context)
			{
				if (context == null) return CancelStatementGreen.__Missing;
				PilParser.CancelStatementKindContext cancelStatementKindContext = context.cancelStatementKind();
				CancelStatementKindGreen cancelStatementKind = null;
				if (cancelStatementKindContext != null) cancelStatementKind = (CancelStatementKindGreen)this.Visit(cancelStatementKindContext);
				if (cancelStatementKind == null) cancelStatementKind = CancelStatementKindGreen.__Missing;
				PilParser.IdentifierContext portNameContext = context.portName;
				IdentifierGreen portName = null;
				if (portNameContext != null) portName = (IdentifierGreen)this.Visit(portNameContext);
				PilParser.AssertionContext assertionContext = context.assertion();
				AssertionGreen assertion = null;
				if (assertionContext != null) assertion = (AssertionGreen)this.Visit(assertionContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				return _factory.CancelStatement(cancelStatementKind, portName, assertion, tSemicolon);
			}
			
			public override GreenNode VisitAssertion(PilParser.AssertionContext context)
			{
				if (context == null) return AssertionGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), PilSyntaxKind.TColon);
				PilParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				return _factory.Assertion(tColon, expression, comment);
			}
			
			public override GreenNode VisitResponseStatementKind(PilParser.ResponseStatementKindContext context)
			{
				if (context == null) return ResponseStatementKindGreen.__Missing;
				InternalSyntaxToken responseStatementKind = null;
				if (context.KAccept() != null)
				{
					responseStatementKind = (InternalSyntaxToken)this.VisitTerminal(context.KAccept());
				}
				else 	if (context.KRefuse() != null)
				{
					responseStatementKind = (InternalSyntaxToken)this.VisitTerminal(context.KRefuse());
				}
				else
				{
					responseStatementKind = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.ResponseStatementKind(responseStatementKind);
			}
			
			public override GreenNode VisitCancelStatementKind(PilParser.CancelStatementKindContext context)
			{
				if (context == null) return CancelStatementKindGreen.__Missing;
				InternalSyntaxToken kCancel = (InternalSyntaxToken)this.VisitTerminal(context.KCancel(), PilSyntaxKind.KCancel);
				return _factory.CancelStatementKind(kCancel);
			}
			
			public override GreenNode VisitForkRequestStatement(PilParser.ForkRequestStatementContext context)
			{
				if (context == null) return ForkRequestStatementGreen.__Missing;
				InternalSyntaxToken kFork = (InternalSyntaxToken)this.VisitTerminal(context.KFork(), PilSyntaxKind.KFork);
				PilParser.ForkRequestVariableContext forkRequestVariableContext = context.forkRequestVariable();
				ForkRequestVariableGreen forkRequestVariable = null;
				if (forkRequestVariableContext != null) forkRequestVariable = (ForkRequestVariableGreen)this.Visit(forkRequestVariableContext);
				if (forkRequestVariable == null) forkRequestVariable = ForkRequestVariableGreen.__Missing;
				PilParser.AcceptBranchContext acceptBranchContext = context.acceptBranch();
				AcceptBranchGreen acceptBranch = null;
				if (acceptBranchContext != null) acceptBranch = (AcceptBranchGreen)this.Visit(acceptBranchContext);
				PilParser.RefuseBranchContext refuseBranchContext = context.refuseBranch();
				RefuseBranchGreen refuseBranch = null;
				if (refuseBranchContext != null) refuseBranch = (RefuseBranchGreen)this.Visit(refuseBranchContext);
				PilParser.CancelBranchContext cancelBranchContext = context.cancelBranch();
				CancelBranchGreen cancelBranch = null;
				if (cancelBranchContext != null) cancelBranch = (CancelBranchGreen)this.Visit(cancelBranchContext);
				InternalSyntaxToken kEndFork = (InternalSyntaxToken)this.VisitTerminal(context.KEndFork(), PilSyntaxKind.KEndFork);
				return _factory.ForkRequestStatement(kFork, forkRequestVariable, acceptBranch, refuseBranch, cancelBranch, kEndFork);
			}
			
			public override GreenNode VisitForkRequestVariable(PilParser.ForkRequestVariableContext context)
			{
				if (context == null) return ForkRequestVariableGreen.__Missing;
				PilParser.ForkRequestIdentifierContext forkRequestIdentifierContext = context.forkRequestIdentifier();
				if (forkRequestIdentifierContext != null) 
				{
					return _factory.ForkRequestVariable((ForkRequestIdentifierGreen)this.Visit(forkRequestIdentifierContext));
				}
				PilParser.RequestStatementContext requestStatementContext = context.requestStatement();
				if (requestStatementContext != null) 
				{
					return _factory.ForkRequestVariable((RequestStatementGreen)this.Visit(requestStatementContext));
				}
				return ForkRequestVariableGreen.__Missing;
			}
			
			public override GreenNode VisitForkRequestIdentifier(PilParser.ForkRequestIdentifierContext context)
			{
				if (context == null) return ForkRequestIdentifierGreen.__Missing;
				PilParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				return _factory.ForkRequestIdentifier(identifier, tSemicolon);
			}
			
			public override GreenNode VisitAcceptBranch(PilParser.AcceptBranchContext context)
			{
				if (context == null) return AcceptBranchGreen.__Missing;
				InternalSyntaxToken kCase = (InternalSyntaxToken)this.VisitTerminal(context.KCase(), PilSyntaxKind.KCase);
				InternalSyntaxToken kAccept = (InternalSyntaxToken)this.VisitTerminal(context.KAccept(), PilSyntaxKind.KAccept);
				PilParser.ExpressionContext conditionContext = context.condition;
				ExpressionGreen condition = null;
				if (conditionContext != null) condition = (ExpressionGreen)this.Visit(conditionContext);
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				PilParser.StatementsContext statementsContext = context.statements();
				StatementsGreen statements = null;
				if (statementsContext != null) statements = (StatementsGreen)this.Visit(statementsContext);
				return _factory.AcceptBranch(kCase, kAccept, condition, comment, tSemicolon, statements);
			}
			
			public override GreenNode VisitRefuseBranch(PilParser.RefuseBranchContext context)
			{
				if (context == null) return RefuseBranchGreen.__Missing;
				InternalSyntaxToken kCase = (InternalSyntaxToken)this.VisitTerminal(context.KCase(), PilSyntaxKind.KCase);
				InternalSyntaxToken kRefuse = (InternalSyntaxToken)this.VisitTerminal(context.KRefuse(), PilSyntaxKind.KRefuse);
				PilParser.ExpressionContext conditionContext = context.condition;
				ExpressionGreen condition = null;
				if (conditionContext != null) condition = (ExpressionGreen)this.Visit(conditionContext);
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				PilParser.StatementsContext statementsContext = context.statements();
				StatementsGreen statements = null;
				if (statementsContext != null) statements = (StatementsGreen)this.Visit(statementsContext);
				return _factory.RefuseBranch(kCase, kRefuse, condition, comment, tSemicolon, statements);
			}
			
			public override GreenNode VisitCancelBranch(PilParser.CancelBranchContext context)
			{
				if (context == null) return CancelBranchGreen.__Missing;
				InternalSyntaxToken kCase = (InternalSyntaxToken)this.VisitTerminal(context.KCase(), PilSyntaxKind.KCase);
				InternalSyntaxToken kCancel = (InternalSyntaxToken)this.VisitTerminal(context.KCancel(), PilSyntaxKind.KCancel);
				PilParser.ExpressionContext conditionContext = context.condition;
				ExpressionGreen condition = null;
				if (conditionContext != null) condition = (ExpressionGreen)this.Visit(conditionContext);
				PilParser.CommentContext commentContext = context.comment();
				CommentGreen comment = null;
				if (commentContext != null) comment = (CommentGreen)this.Visit(commentContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				PilParser.StatementsContext statementsContext = context.statements();
				StatementsGreen statements = null;
				if (statementsContext != null) statements = (StatementsGreen)this.Visit(statementsContext);
				return _factory.CancelBranch(kCase, kCancel, condition, comment, tSemicolon, statements);
			}
			
			public override GreenNode VisitVariableDeclarationStatement(PilParser.VariableDeclarationStatementContext context)
			{
				if (context == null) return VariableDeclarationStatementGreen.__Missing;
				PilParser.VariableDeclarationContext variableDeclarationContext = context.variableDeclaration();
				VariableDeclarationGreen variableDeclaration = null;
				if (variableDeclarationContext != null) variableDeclaration = (VariableDeclarationGreen)this.Visit(variableDeclarationContext);
				if (variableDeclaration == null) variableDeclaration = VariableDeclarationGreen.__Missing;
				return _factory.VariableDeclarationStatement(variableDeclaration);
			}
			
			public override GreenNode VisitVariableDeclaration(PilParser.VariableDeclarationContext context)
			{
				if (context == null) return VariableDeclarationGreen.__Missing;
				InternalSyntaxToken kVar = (InternalSyntaxToken)this.VisitTerminal(context.KVar(), PilSyntaxKind.KVar);
				PilParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), PilSyntaxKind.TColon);
				PilParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				PilParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null) expression = (ExpressionGreen)this.Visit(expressionContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				return _factory.VariableDeclaration(kVar, name, tColon, typeReference, tAssign, expression, tSemicolon);
			}
			
			public override GreenNode VisitAssignmentStatement(PilParser.AssignmentStatementContext context)
			{
				if (context == null) return AssignmentStatementGreen.__Missing;
				PilParser.LeftSideContext leftSideContext = context.leftSide();
				LeftSideGreen leftSide = null;
				if (leftSideContext != null) leftSide = (LeftSideGreen)this.Visit(leftSideContext);
				if (leftSide == null) leftSide = LeftSideGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), PilSyntaxKind.TAssign);
				PilParser.ExpressionContext valueContext = context.value;
				ExpressionGreen value = null;
				if (valueContext != null) value = (ExpressionGreen)this.Visit(valueContext);
				if (value == null) value = ExpressionGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), PilSyntaxKind.TSemicolon);
				return _factory.AssignmentStatement(leftSide, tAssign, value, tSemicolon);
			}
			
			public override GreenNode VisitLeftSide(PilParser.LeftSideContext context)
			{
				if (context == null) return LeftSideGreen.__Missing;
				PilParser.IdentifierContext identifierContext = context.identifier();
				if (identifierContext != null) 
				{
					return _factory.LeftSide((IdentifierGreen)this.Visit(identifierContext));
				}
				PilParser.ResultIdentifierContext resultIdentifierContext = context.resultIdentifier();
				if (resultIdentifierContext != null) 
				{
					return _factory.LeftSide((ResultIdentifierGreen)this.Visit(resultIdentifierContext));
				}
				return LeftSideGreen.__Missing;
			}
			
			public override GreenNode VisitExpressionList(PilParser.ExpressionListContext context)
			{
				if (context == null) return ExpressionListGreen.__Missing;
			    PilParser.ExpressionContext[] expressionContext = context.expression();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var expressionBuilder = _pool.AllocateSeparated<ExpressionGreen>();
			    for (int i = 0; i < expressionContext.Length; i++)
			    {
			        expressionBuilder.Add((ExpressionGreen)this.Visit(expressionContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            expressionBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var expression = expressionBuilder.ToList();
				_pool.Free(expressionBuilder);
				return _factory.ExpressionList(expression);
			}
			
			public override GreenNode VisitExpression(PilParser.ExpressionContext context)
			{
				if (context == null) return ExpressionGreen.__Missing;
				PilParser.ArithmeticExpressionContext arithmeticExpressionContext = context.arithmeticExpression();
				if (arithmeticExpressionContext != null) 
				{
					return _factory.Expression((ArithmeticExpressionGreen)this.Visit(arithmeticExpressionContext));
				}
				PilParser.ConditionalExpressionContext conditionalExpressionContext = context.conditionalExpression();
				if (conditionalExpressionContext != null) 
				{
					return _factory.Expression((ConditionalExpressionGreen)this.Visit(conditionalExpressionContext));
				}
				return ExpressionGreen.__Missing;
			}
			
			public override GreenNode VisitMulDivExpression(PilParser.MulDivExpressionContext context)
			{
				if (context == null) return MulDivExpressionGreen.__Missing;
				PilParser.ArithmeticExpressionContext leftContext = context.left;
				ArithmeticExpressionGreen left = null;
				if (leftContext != null) left = (ArithmeticExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ArithmeticExpressionGreen.__Missing;
				PilParser.OpMulDivContext opMulDivContext = context.opMulDiv();
				OpMulDivGreen opMulDiv = null;
				if (opMulDivContext != null) opMulDiv = (OpMulDivGreen)this.Visit(opMulDivContext);
				if (opMulDiv == null) opMulDiv = OpMulDivGreen.__Missing;
				PilParser.ArithmeticExpressionContext rightContext = context.right;
				ArithmeticExpressionGreen right = null;
				if (rightContext != null) right = (ArithmeticExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ArithmeticExpressionGreen.__Missing;
				return _factory.MulDivExpression(left, opMulDiv, right);
			}
			
			public override GreenNode VisitPlusMinusExpression(PilParser.PlusMinusExpressionContext context)
			{
				if (context == null) return PlusMinusExpressionGreen.__Missing;
				PilParser.ArithmeticExpressionContext leftContext = context.left;
				ArithmeticExpressionGreen left = null;
				if (leftContext != null) left = (ArithmeticExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ArithmeticExpressionGreen.__Missing;
				PilParser.OpAddSubContext opAddSubContext = context.opAddSub();
				OpAddSubGreen opAddSub = null;
				if (opAddSubContext != null) opAddSub = (OpAddSubGreen)this.Visit(opAddSubContext);
				if (opAddSub == null) opAddSub = OpAddSubGreen.__Missing;
				PilParser.ArithmeticExpressionContext rightContext = context.right;
				ArithmeticExpressionGreen right = null;
				if (rightContext != null) right = (ArithmeticExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ArithmeticExpressionGreen.__Missing;
				return _factory.PlusMinusExpression(left, opAddSub, right);
			}
			
			public override GreenNode VisitNegateExpression(PilParser.NegateExpressionContext context)
			{
				if (context == null) return NegateExpressionGreen.__Missing;
				PilParser.OpMinusContext opMinusContext = context.opMinus();
				OpMinusGreen opMinus = null;
				if (opMinusContext != null) opMinus = (OpMinusGreen)this.Visit(opMinusContext);
				if (opMinus == null) opMinus = OpMinusGreen.__Missing;
				PilParser.ArithmeticExpressionTerminatorContext arithmeticExpressionTerminatorContext = context.arithmeticExpressionTerminator();
				ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator = null;
				if (arithmeticExpressionTerminatorContext != null) arithmeticExpressionTerminator = (ArithmeticExpressionTerminatorGreen)this.Visit(arithmeticExpressionTerminatorContext);
				if (arithmeticExpressionTerminator == null) arithmeticExpressionTerminator = ArithmeticExpressionTerminatorGreen.__Missing;
				return _factory.NegateExpression(opMinus, arithmeticExpressionTerminator);
			}
			
			public override GreenNode VisitSimpleArithmeticExpression(PilParser.SimpleArithmeticExpressionContext context)
			{
				if (context == null) return SimpleArithmeticExpressionGreen.__Missing;
				PilParser.ArithmeticExpressionTerminatorContext arithmeticExpressionTerminatorContext = context.arithmeticExpressionTerminator();
				ArithmeticExpressionTerminatorGreen arithmeticExpressionTerminator = null;
				if (arithmeticExpressionTerminatorContext != null) arithmeticExpressionTerminator = (ArithmeticExpressionTerminatorGreen)this.Visit(arithmeticExpressionTerminatorContext);
				if (arithmeticExpressionTerminator == null) arithmeticExpressionTerminator = ArithmeticExpressionTerminatorGreen.__Missing;
				return _factory.SimpleArithmeticExpression(arithmeticExpressionTerminator);
			}
			
			public override GreenNode VisitOpMulDiv(PilParser.OpMulDivContext context)
			{
				if (context == null) return OpMulDivGreen.__Missing;
				InternalSyntaxToken opMulDiv = null;
				if (context.TAsterisk() != null)
				{
					opMulDiv = (InternalSyntaxToken)this.VisitTerminal(context.TAsterisk());
				}
				else 	if (context.TSlash() != null)
				{
					opMulDiv = (InternalSyntaxToken)this.VisitTerminal(context.TSlash());
				}
				else
				{
					opMulDiv = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.OpMulDiv(opMulDiv);
			}
			
			public override GreenNode VisitOpAddSub(PilParser.OpAddSubContext context)
			{
				if (context == null) return OpAddSubGreen.__Missing;
				InternalSyntaxToken opAddSub = null;
				if (context.TPlus() != null)
				{
					opAddSub = (InternalSyntaxToken)this.VisitTerminal(context.TPlus());
				}
				else 	if (context.TMinus() != null)
				{
					opAddSub = (InternalSyntaxToken)this.VisitTerminal(context.TMinus());
				}
				else
				{
					opAddSub = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.OpAddSub(opAddSub);
			}
			
			public override GreenNode VisitParenArithmeticExpression(PilParser.ParenArithmeticExpressionContext context)
			{
				if (context == null) return ParenArithmeticExpressionGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), PilSyntaxKind.TOpenParen);
				PilParser.ArithmeticExpressionContext arithmeticExpressionContext = context.arithmeticExpression();
				ArithmeticExpressionGreen arithmeticExpression = null;
				if (arithmeticExpressionContext != null) arithmeticExpression = (ArithmeticExpressionGreen)this.Visit(arithmeticExpressionContext);
				if (arithmeticExpression == null) arithmeticExpression = ArithmeticExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), PilSyntaxKind.TCloseParen);
				return _factory.ParenArithmeticExpression(tOpenParen, arithmeticExpression, tCloseParen);
			}
			
			public override GreenNode VisitTerminalArithmeticExpression(PilParser.TerminalArithmeticExpressionContext context)
			{
				if (context == null) return TerminalArithmeticExpressionGreen.__Missing;
				PilParser.TerminalExpressionContext terminalExpressionContext = context.terminalExpression();
				TerminalExpressionGreen terminalExpression = null;
				if (terminalExpressionContext != null) terminalExpression = (TerminalExpressionGreen)this.Visit(terminalExpressionContext);
				if (terminalExpression == null) terminalExpression = TerminalExpressionGreen.__Missing;
				return _factory.TerminalArithmeticExpression(terminalExpression);
			}
			
			public override GreenNode VisitOpMinus(PilParser.OpMinusContext context)
			{
				if (context == null) return OpMinusGreen.__Missing;
				InternalSyntaxToken tMinus = (InternalSyntaxToken)this.VisitTerminal(context.TMinus(), PilSyntaxKind.TMinus);
				return _factory.OpMinus(tMinus);
			}
			
			public override GreenNode VisitAndExpression(PilParser.AndExpressionContext context)
			{
				if (context == null) return AndExpressionGreen.__Missing;
				PilParser.ConditionalExpressionContext leftContext = context.left;
				ConditionalExpressionGreen left = null;
				if (leftContext != null) left = (ConditionalExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ConditionalExpressionGreen.__Missing;
				PilParser.AndAlsoOpContext andAlsoOpContext = context.andAlsoOp();
				AndAlsoOpGreen andAlsoOp = null;
				if (andAlsoOpContext != null) andAlsoOp = (AndAlsoOpGreen)this.Visit(andAlsoOpContext);
				if (andAlsoOp == null) andAlsoOp = AndAlsoOpGreen.__Missing;
				PilParser.ConditionalExpressionContext rightContext = context.right;
				ConditionalExpressionGreen right = null;
				if (rightContext != null) right = (ConditionalExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ConditionalExpressionGreen.__Missing;
				return _factory.AndExpression(left, andAlsoOp, right);
			}
			
			public override GreenNode VisitOrExpression(PilParser.OrExpressionContext context)
			{
				if (context == null) return OrExpressionGreen.__Missing;
				PilParser.ConditionalExpressionContext leftContext = context.left;
				ConditionalExpressionGreen left = null;
				if (leftContext != null) left = (ConditionalExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ConditionalExpressionGreen.__Missing;
				PilParser.OrElseOpContext orElseOpContext = context.orElseOp();
				OrElseOpGreen orElseOp = null;
				if (orElseOpContext != null) orElseOp = (OrElseOpGreen)this.Visit(orElseOpContext);
				if (orElseOp == null) orElseOp = OrElseOpGreen.__Missing;
				PilParser.ConditionalExpressionContext rightContext = context.right;
				ConditionalExpressionGreen right = null;
				if (rightContext != null) right = (ConditionalExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ConditionalExpressionGreen.__Missing;
				return _factory.OrExpression(left, orElseOp, right);
			}
			
			public override GreenNode VisitNotExpression(PilParser.NotExpressionContext context)
			{
				if (context == null) return NotExpressionGreen.__Missing;
				PilParser.OpExclContext opExclContext = context.opExcl();
				OpExclGreen opExcl = null;
				if (opExclContext != null) opExcl = (OpExclGreen)this.Visit(opExclContext);
				if (opExcl == null) opExcl = OpExclGreen.__Missing;
				PilParser.ConditionalExpressionTerminatorContext conditionalExpressionTerminatorContext = context.conditionalExpressionTerminator();
				ConditionalExpressionTerminatorGreen conditionalExpressionTerminator = null;
				if (conditionalExpressionTerminatorContext != null) conditionalExpressionTerminator = (ConditionalExpressionTerminatorGreen)this.Visit(conditionalExpressionTerminatorContext);
				if (conditionalExpressionTerminator == null) conditionalExpressionTerminator = ConditionalExpressionTerminatorGreen.__Missing;
				return _factory.NotExpression(opExcl, conditionalExpressionTerminator);
			}
			
			public override GreenNode VisitSimpleConditionalExpression(PilParser.SimpleConditionalExpressionContext context)
			{
				if (context == null) return SimpleConditionalExpressionGreen.__Missing;
				PilParser.ConditionalExpressionTerminatorContext conditionalExpressionTerminatorContext = context.conditionalExpressionTerminator();
				ConditionalExpressionTerminatorGreen conditionalExpressionTerminator = null;
				if (conditionalExpressionTerminatorContext != null) conditionalExpressionTerminator = (ConditionalExpressionTerminatorGreen)this.Visit(conditionalExpressionTerminatorContext);
				if (conditionalExpressionTerminator == null) conditionalExpressionTerminator = ConditionalExpressionTerminatorGreen.__Missing;
				return _factory.SimpleConditionalExpression(conditionalExpressionTerminator);
			}
			
			public override GreenNode VisitAndAlsoOp(PilParser.AndAlsoOpContext context)
			{
				if (context == null) return AndAlsoOpGreen.__Missing;
				InternalSyntaxToken tAndAlso = (InternalSyntaxToken)this.VisitTerminal(context.TAndAlso(), PilSyntaxKind.TAndAlso);
				return _factory.AndAlsoOp(tAndAlso);
			}
			
			public override GreenNode VisitOrElseOp(PilParser.OrElseOpContext context)
			{
				if (context == null) return OrElseOpGreen.__Missing;
				InternalSyntaxToken tOrElse = (InternalSyntaxToken)this.VisitTerminal(context.TOrElse(), PilSyntaxKind.TOrElse);
				return _factory.OrElseOp(tOrElse);
			}
			
			public override GreenNode VisitOpExcl(PilParser.OpExclContext context)
			{
				if (context == null) return OpExclGreen.__Missing;
				InternalSyntaxToken tExclamation = (InternalSyntaxToken)this.VisitTerminal(context.TExclamation(), PilSyntaxKind.TExclamation);
				return _factory.OpExcl(tExclamation);
			}
			
			public override GreenNode VisitParenConditionalExpression(PilParser.ParenConditionalExpressionContext context)
			{
				if (context == null) return ParenConditionalExpressionGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), PilSyntaxKind.TOpenParen);
				PilParser.ConditionalExpressionContext conditionalExpressionContext = context.conditionalExpression();
				ConditionalExpressionGreen conditionalExpression = null;
				if (conditionalExpressionContext != null) conditionalExpression = (ConditionalExpressionGreen)this.Visit(conditionalExpressionContext);
				if (conditionalExpression == null) conditionalExpression = ConditionalExpressionGreen.__Missing;
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), PilSyntaxKind.TCloseParen);
				return _factory.ParenConditionalExpression(tOpenParen, conditionalExpression, tCloseParen);
			}
			
			public override GreenNode VisitElementOfConditionalExpression(PilParser.ElementOfConditionalExpressionContext context)
			{
				if (context == null) return ElementOfConditionalExpressionGreen.__Missing;
				PilParser.ElementOfExpressionContext elementOfExpressionContext = context.elementOfExpression();
				ElementOfExpressionGreen elementOfExpression = null;
				if (elementOfExpressionContext != null) elementOfExpression = (ElementOfExpressionGreen)this.Visit(elementOfExpressionContext);
				if (elementOfExpression == null) elementOfExpression = ElementOfExpressionGreen.__Missing;
				return _factory.ElementOfConditionalExpression(elementOfExpression);
			}
			
			public override GreenNode VisitComparisonConditionalExpression(PilParser.ComparisonConditionalExpressionContext context)
			{
				if (context == null) return ComparisonConditionalExpressionGreen.__Missing;
				PilParser.ComparisonExpressionContext comparisonExpressionContext = context.comparisonExpression();
				ComparisonExpressionGreen comparisonExpression = null;
				if (comparisonExpressionContext != null) comparisonExpression = (ComparisonExpressionGreen)this.Visit(comparisonExpressionContext);
				if (comparisonExpression == null) comparisonExpression = ComparisonExpressionGreen.__Missing;
				return _factory.ComparisonConditionalExpression(comparisonExpression);
			}
			
			public override GreenNode VisitTerminalComparisonExpression(PilParser.TerminalComparisonExpressionContext context)
			{
				if (context == null) return TerminalComparisonExpressionGreen.__Missing;
				PilParser.TerminalExpressionContext terminalExpressionContext = context.terminalExpression();
				TerminalExpressionGreen terminalExpression = null;
				if (terminalExpressionContext != null) terminalExpression = (TerminalExpressionGreen)this.Visit(terminalExpressionContext);
				if (terminalExpression == null) terminalExpression = TerminalExpressionGreen.__Missing;
				return _factory.TerminalComparisonExpression(terminalExpression);
			}
			
			public override GreenNode VisitComparisonExpression(PilParser.ComparisonExpressionContext context)
			{
				if (context == null) return ComparisonExpressionGreen.__Missing;
				PilParser.ArithmeticExpressionContext leftContext = context.left;
				ArithmeticExpressionGreen left = null;
				if (leftContext != null) left = (ArithmeticExpressionGreen)this.Visit(leftContext);
				if (left == null) left = ArithmeticExpressionGreen.__Missing;
				PilParser.ComparisonOperatorContext opContext = context.op;
				ComparisonOperatorGreen op = null;
				if (opContext != null) op = (ComparisonOperatorGreen)this.Visit(opContext);
				if (op == null) op = ComparisonOperatorGreen.__Missing;
				PilParser.ArithmeticExpressionContext rightContext = context.right;
				ArithmeticExpressionGreen right = null;
				if (rightContext != null) right = (ArithmeticExpressionGreen)this.Visit(rightContext);
				if (right == null) right = ArithmeticExpressionGreen.__Missing;
				return _factory.ComparisonExpression(left, op, right);
			}
			
			public override GreenNode VisitComparisonOperator(PilParser.ComparisonOperatorContext context)
			{
				if (context == null) return ComparisonOperatorGreen.__Missing;
				InternalSyntaxToken comparisonOperator = null;
				if (context.TEqual() != null)
				{
					comparisonOperator = (InternalSyntaxToken)this.VisitTerminal(context.TEqual());
				}
				else 	if (context.TNotEqual() != null)
				{
					comparisonOperator = (InternalSyntaxToken)this.VisitTerminal(context.TNotEqual());
				}
				else 	if (context.TLessThan() != null)
				{
					comparisonOperator = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan());
				}
				else 	if (context.TGreaterThan() != null)
				{
					comparisonOperator = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan());
				}
				else 	if (context.TLessThanOrEqual() != null)
				{
					comparisonOperator = (InternalSyntaxToken)this.VisitTerminal(context.TLessThanOrEqual());
				}
				else 	if (context.TGreaterThanOrEqual() != null)
				{
					comparisonOperator = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThanOrEqual());
				}
				else
				{
					comparisonOperator = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.ComparisonOperator(comparisonOperator);
			}
			
			public override GreenNode VisitElementOfExpression(PilParser.ElementOfExpressionContext context)
			{
				if (context == null) return ElementOfExpressionGreen.__Missing;
				PilParser.TerminalExpressionContext terminalExpressionContext = context.terminalExpression();
				TerminalExpressionGreen terminalExpression = null;
				if (terminalExpressionContext != null) terminalExpression = (TerminalExpressionGreen)this.Visit(terminalExpressionContext);
				if (terminalExpression == null) terminalExpression = TerminalExpressionGreen.__Missing;
				InternalSyntaxToken kIn = (InternalSyntaxToken)this.VisitTerminal(context.KIn(), PilSyntaxKind.KIn);
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), PilSyntaxKind.TOpenBracket);
				PilParser.ElementOfValueListContext elementOfValueListContext = context.elementOfValueList();
				ElementOfValueListGreen elementOfValueList = null;
				if (elementOfValueListContext != null) elementOfValueList = (ElementOfValueListGreen)this.Visit(elementOfValueListContext);
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), PilSyntaxKind.TCloseBracket);
				return _factory.ElementOfExpression(terminalExpression, kIn, tOpenBracket, elementOfValueList, tCloseBracket);
			}
			
			public override GreenNode VisitElementOfValueList(PilParser.ElementOfValueListContext context)
			{
				if (context == null) return ElementOfValueListGreen.__Missing;
			    PilParser.ElementOfValueContext[] elementOfValueContext = context.elementOfValue();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var elementOfValueBuilder = _pool.AllocateSeparated<ElementOfValueGreen>();
			    for (int i = 0; i < elementOfValueContext.Length; i++)
			    {
			        elementOfValueBuilder.Add((ElementOfValueGreen)this.Visit(elementOfValueContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            elementOfValueBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var elementOfValue = elementOfValueBuilder.ToList();
				_pool.Free(elementOfValueBuilder);
				return _factory.ElementOfValueList(elementOfValue);
			}
			
			public override GreenNode VisitElementOfValue(PilParser.ElementOfValueContext context)
			{
				if (context == null) return ElementOfValueGreen.__Missing;
				PilParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.ElementOfValue(identifier);
			}
			
			public override GreenNode VisitTerminalExpression(PilParser.TerminalExpressionContext context)
			{
				if (context == null) return TerminalExpressionGreen.__Missing;
				PilParser.VariableReferenceContext variableReferenceContext = context.variableReference();
				if (variableReferenceContext != null) 
				{
					return _factory.TerminalExpression((VariableReferenceGreen)this.Visit(variableReferenceContext));
				}
				PilParser.FunctionCallExpressionContext functionCallExpressionContext = context.functionCallExpression();
				if (functionCallExpressionContext != null) 
				{
					return _factory.TerminalExpression((FunctionCallExpressionGreen)this.Visit(functionCallExpressionContext));
				}
				PilParser.LiteralContext literalContext = context.literal();
				if (literalContext != null) 
				{
					return _factory.TerminalExpression((LiteralGreen)this.Visit(literalContext));
				}
				return TerminalExpressionGreen.__Missing;
			}
			
			public override GreenNode VisitFunctionCallExpression(PilParser.FunctionCallExpressionContext context)
			{
				if (context == null) return FunctionCallExpressionGreen.__Missing;
				PilParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), PilSyntaxKind.TOpenParen);
				PilParser.ExpressionListContext expressionListContext = context.expressionList();
				ExpressionListGreen expressionList = null;
				if (expressionListContext != null) expressionList = (ExpressionListGreen)this.Visit(expressionListContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), PilSyntaxKind.TCloseParen);
				return _factory.FunctionCallExpression(identifier, tOpenParen, expressionList, tCloseParen);
			}
			
			public override GreenNode VisitVariableReference(PilParser.VariableReferenceContext context)
			{
				if (context == null) return VariableReferenceGreen.__Missing;
			    PilParser.VariableReferenceIdentifierContext[] variableReferenceIdentifierContext = context.variableReferenceIdentifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var variableReferenceIdentifierBuilder = _pool.AllocateSeparated<VariableReferenceIdentifierGreen>();
			    for (int i = 0; i < variableReferenceIdentifierContext.Length; i++)
			    {
			        variableReferenceIdentifierBuilder.Add((VariableReferenceIdentifierGreen)this.Visit(variableReferenceIdentifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            variableReferenceIdentifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], PilSyntaxKind.TDot));
			        }
			    }
				var variableReferenceIdentifier = variableReferenceIdentifierBuilder.ToList();
				_pool.Free(variableReferenceIdentifierBuilder);
				return _factory.VariableReference(variableReferenceIdentifier);
			}
			
			public override GreenNode VisitVariableReferenceIdentifier(PilParser.VariableReferenceIdentifierContext context)
			{
				if (context == null) return VariableReferenceIdentifierGreen.__Missing;
				PilParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.VariableReferenceIdentifier(identifier);
			}
			
			public override GreenNode VisitComment(PilParser.CommentContext context)
			{
				if (context == null) return CommentGreen.__Missing;
				InternalSyntaxToken lString = (InternalSyntaxToken)this.VisitTerminal(context.LString(), PilSyntaxKind.LString);
				return _factory.Comment(lString);
			}
			
			public override GreenNode VisitLiteral(PilParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				InternalSyntaxToken literal = null;
				if (context.LInteger() != null)
				{
					literal = (InternalSyntaxToken)this.VisitTerminal(context.LInteger());
				}
				else 	if (context.KTrue() != null)
				{
					literal = (InternalSyntaxToken)this.VisitTerminal(context.KTrue());
				}
				else 	if (context.KFalse() != null)
				{
					literal = (InternalSyntaxToken)this.VisitTerminal(context.KFalse());
				}
				else 	if (context.KNull() != null)
				{
					literal = (InternalSyntaxToken)this.VisitTerminal(context.KNull());
				}
				else
				{
					literal = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.Literal(literal);
			}
			
			public override GreenNode VisitTypeReference(PilParser.TypeReferenceContext context)
			{
				if (context == null) return TypeReferenceGreen.__Missing;
				PilParser.BuiltInTypeContext builtInTypeContext = context.builtInType();
				if (builtInTypeContext != null) 
				{
					return _factory.TypeReference((BuiltInTypeGreen)this.Visit(builtInTypeContext));
				}
				PilParser.IdentifierContext identifierContext = context.identifier();
				if (identifierContext != null) 
				{
					return _factory.TypeReference((IdentifierGreen)this.Visit(identifierContext));
				}
				return TypeReferenceGreen.__Missing;
			}
			
			public override GreenNode VisitBuiltInType(PilParser.BuiltInTypeContext context)
			{
				if (context == null) return BuiltInTypeGreen.__Missing;
				InternalSyntaxToken builtInType = null;
				if (context.KBool() != null)
				{
					builtInType = (InternalSyntaxToken)this.VisitTerminal(context.KBool());
				}
				else 	if (context.KInt() != null)
				{
					builtInType = (InternalSyntaxToken)this.VisitTerminal(context.KInt());
				}
				else 	if (context.KString() != null)
				{
					builtInType = (InternalSyntaxToken)this.VisitTerminal(context.KString());
				}
				else 	if (context.KObjectType() != null)
				{
					builtInType = (InternalSyntaxToken)this.VisitTerminal(context.KObjectType());
				}
				else
				{
					builtInType = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.BuiltInType(builtInType);
			}
			
			public override GreenNode VisitQualifierList(PilParser.QualifierListContext context)
			{
				if (context == null) return QualifierListGreen.__Missing;
			    PilParser.QualifierContext[] qualifierContext = context.qualifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var qualifierBuilder = _pool.AllocateSeparated<QualifierGreen>();
			    for (int i = 0; i < qualifierContext.Length; i++)
			    {
			        qualifierBuilder.Add((QualifierGreen)this.Visit(qualifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            qualifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var qualifier = qualifierBuilder.ToList();
				_pool.Free(qualifierBuilder);
				return _factory.QualifierList(qualifier);
			}
			
			public override GreenNode VisitQualifier(PilParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    PilParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], PilSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitName(PilParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				PilParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.Name(identifier);
			}
			
			public override GreenNode VisitIdentifierList(PilParser.IdentifierListContext context)
			{
				if (context == null) return IdentifierListGreen.__Missing;
			    PilParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], PilSyntaxKind.TComma));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.IdentifierList(identifier);
			}
			
			public override GreenNode VisitIdentifier(PilParser.IdentifierContext context)
			{
				if (context == null) return IdentifierGreen.__Missing;
				InternalSyntaxToken lIdentifier = (InternalSyntaxToken)this.VisitTerminal(context.LIdentifier(), PilSyntaxKind.LIdentifier);
				return _factory.Identifier(lIdentifier);
			}
			
			public override GreenNode VisitResultIdentifier(PilParser.ResultIdentifierContext context)
			{
				if (context == null) return ResultIdentifierGreen.__Missing;
				InternalSyntaxToken kResult = (InternalSyntaxToken)this.VisitTerminal(context.KResult(), PilSyntaxKind.KResult);
				return _factory.ResultIdentifier(kResult);
			}
        }
    }
    public partial class PilParser
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
		
		internal class DeclarationContext_Cached : DeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypeDefDeclarationContext_Cached : TypeDefDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypeDefDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ExternalParameterDeclarationContext_Cached : ExternalParameterDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ExternalParameterDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EnumDeclarationContext_Cached : EnumDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EnumDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EnumLiteralsContext_Cached : EnumLiteralsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EnumLiteralsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EnumLiteralContext_Cached : EnumLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EnumLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ObjectDeclarationContext_Cached : ObjectDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ObjectDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ObjectHeaderContext_Cached : ObjectHeaderContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ObjectHeaderContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class PortsContext_Cached : PortsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PortsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class PortContext_Cached : PortContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PortContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ObjectExternalParametersContext_Cached : ObjectExternalParametersContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ObjectExternalParametersContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ObjectFieldsContext_Cached : ObjectFieldsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ObjectFieldsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ObjectFunctionsContext_Cached : ObjectFunctionsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ObjectFunctionsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class FunctionHeaderContext_Cached : FunctionHeaderContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FunctionHeaderContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FunctionParamsContext_Cached : FunctionParamsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FunctionParamsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParamContext_Cached : ParamContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParamContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryDeclarationContext_Cached : QueryDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryHeaderContext_Cached : QueryHeaderContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryHeaderContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryRequestParamsContext_Cached : QueryRequestParamsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryRequestParamsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryAcceptParamsContext_Cached : QueryAcceptParamsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryAcceptParamsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryRefuseParamsContext_Cached : QueryRefuseParamsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryRefuseParamsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryCancelParamsContext_Cached : QueryCancelParamsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryCancelParamsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryExternalParametersContext_Cached : QueryExternalParametersContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryExternalParametersContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryFieldContext_Cached : QueryFieldContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryFieldContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryFunctionContext_Cached : QueryFunctionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryFunctionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryObjectContext_Cached : QueryObjectContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryObjectContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryObjectFieldContext_Cached : QueryObjectFieldContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryObjectFieldContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryObjectFunctionContext_Cached : QueryObjectFunctionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryObjectFunctionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QueryObjectEventContext_Cached : QueryObjectEventContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QueryObjectEventContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class InputContext_Cached : InputContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public InputContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class InputPortListContext_Cached : InputPortListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public InputPortListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class InputPortContext_Cached : InputPortContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public InputPortContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TriggerContext_Cached : TriggerContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TriggerContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TriggerVarListContext_Cached : TriggerVarListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TriggerVarListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TriggerVarContext_Cached : TriggerVarContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TriggerVarContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class StatementsContext_Cached : StatementsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public StatementsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ForkStatementContext_Cached : ForkStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ForkStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CaseBranchContext_Cached : CaseBranchContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CaseBranchContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ElseBranchContext_Cached : ElseBranchContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ElseBranchContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class IfBranchContext_Cached : IfBranchContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IfBranchContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ElseIfBranchContext_Cached : ElseIfBranchContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ElseIfBranchContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RequestStatementContext_Cached : RequestStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RequestStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CallRequestContext_Cached : CallRequestContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CallRequestContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RequestArgumentsContext_Cached : RequestArgumentsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RequestArgumentsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ResponseStatementContext_Cached : ResponseStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ResponseStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CancelStatementContext_Cached : CancelStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CancelStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AssertionContext_Cached : AssertionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AssertionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ResponseStatementKindContext_Cached : ResponseStatementKindContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ResponseStatementKindContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CancelStatementKindContext_Cached : CancelStatementKindContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CancelStatementKindContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ForkRequestStatementContext_Cached : ForkRequestStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ForkRequestStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ForkRequestVariableContext_Cached : ForkRequestVariableContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ForkRequestVariableContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ForkRequestIdentifierContext_Cached : ForkRequestIdentifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ForkRequestIdentifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AcceptBranchContext_Cached : AcceptBranchContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AcceptBranchContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RefuseBranchContext_Cached : RefuseBranchContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RefuseBranchContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CancelBranchContext_Cached : CancelBranchContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CancelBranchContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class VariableDeclarationContext_Cached : VariableDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public VariableDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AssignmentStatementContext_Cached : AssignmentStatementContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AssignmentStatementContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LeftSideContext_Cached : LeftSideContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LeftSideContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ArithmeticExpressionContext_Cached : ArithmeticExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ArithmeticExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class OpMulDivContext_Cached : OpMulDivContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public OpMulDivContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class OpAddSubContext_Cached : OpAddSubContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public OpAddSubContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ArithmeticExpressionTerminatorContext_Cached : ArithmeticExpressionTerminatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ArithmeticExpressionTerminatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class OpMinusContext_Cached : OpMinusContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public OpMinusContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ConditionalExpressionContext_Cached : ConditionalExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ConditionalExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AndAlsoOpContext_Cached : AndAlsoOpContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AndAlsoOpContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class OrElseOpContext_Cached : OrElseOpContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public OrElseOpContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class OpExclContext_Cached : OpExclContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public OpExclContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ConditionalExpressionTerminatorContext_Cached : ConditionalExpressionTerminatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ConditionalExpressionTerminatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ComparisonExpressionContext_Cached : ComparisonExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ComparisonExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ComparisonOperatorContext_Cached : ComparisonOperatorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ComparisonOperatorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ElementOfExpressionContext_Cached : ElementOfExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ElementOfExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ElementOfValueListContext_Cached : ElementOfValueListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ElementOfValueListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ElementOfValueContext_Cached : ElementOfValueContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ElementOfValueContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TerminalExpressionContext_Cached : TerminalExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TerminalExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FunctionCallExpressionContext_Cached : FunctionCallExpressionContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FunctionCallExpressionContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class VariableReferenceIdentifierContext_Cached : VariableReferenceIdentifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public VariableReferenceIdentifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CommentContext_Cached : CommentContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CommentContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class BuiltInTypeContext_Cached : BuiltInTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public BuiltInTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QualifierListContext_Cached : QualifierListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QualifierListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ResultIdentifierContext_Cached : ResultIdentifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ResultIdentifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
    }
}

