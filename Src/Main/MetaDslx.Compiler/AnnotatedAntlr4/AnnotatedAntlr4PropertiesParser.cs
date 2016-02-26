//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\balaz\AppData\Local\Temp\21gz4dhl.25l\AnnotatedAntlr4PropertiesParser.g4 by ANTLR 4.5.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace MetaDslx.Compiler {
using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.1")]
[System.CLSCompliant(false)]
public partial class AnnotatedAntlr4PropertiesParser : Parser {
	public const int
		LINE_COMMENT=1, TRUE=2, FALSE=3, NULL=4, COLON=5, COLONCOLON=6, COMMA=7, 
		SEMI=8, LPAREN=9, RPAREN=10, LT=11, GT=12, ASSIGN=13, QUESTION=14, STAR=15, 
		PLUS=16, OR=17, DOLLAR=18, DOT=19, AT=20, POUND=21, NOT=22, LBRACE=23, 
		RBRACE=24, LBRACKET=25, RBRACKET=26, ID=27, INTEGER_LITERAL=28, DECIMAL_LITERAL=29, 
		SCIENTIFIC_LITERAL=30, STRING_LITERAL=31, UNTERMINATED_STRING_LITERAL=32, 
		WS=33, ERRCHAR=34, DOC_COMMENT=35, BLOCK_COMMENT=36;
	public const int
		RULE_propertiesBlock = 0, RULE_propertyAssignment = 1, RULE_qualifiedProperty = 2, 
		RULE_propertySelector = 3, RULE_expressionList = 4, RULE_expression = 5, 
		RULE_functionCall = 6, RULE_literal = 7, RULE_identifier = 8, RULE_booleanLiteral = 9, 
		RULE_nullLiteral = 10;
	public static readonly string[] ruleNames = {
		"propertiesBlock", "propertyAssignment", "qualifiedProperty", "propertySelector", 
		"expressionList", "expression", "functionCall", "literal", "identifier", 
		"booleanLiteral", "nullLiteral"
	};

	private static readonly string[] _LiteralNames = {
		null, null, "'true'", "'false'", "'null'", "':'", "'::'", "','", "';'", 
		"'('", "')'", "'<'", "'>'", "'='", "'?'", null, "'+'", "'|'", "'$'", "'.'", 
		"'@'", "'#'", "'~'", "'{'", "'}'", "'['", "']'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "LINE_COMMENT", "TRUE", "FALSE", "NULL", "COLON", "COLONCOLON", 
		"COMMA", "SEMI", "LPAREN", "RPAREN", "LT", "GT", "ASSIGN", "QUESTION", 
		"STAR", "PLUS", "OR", "DOLLAR", "DOT", "AT", "POUND", "NOT", "LBRACE", 
		"RBRACE", "LBRACKET", "RBRACKET", "ID", "INTEGER_LITERAL", "DECIMAL_LITERAL", 
		"SCIENTIFIC_LITERAL", "STRING_LITERAL", "UNTERMINATED_STRING_LITERAL", 
		"WS", "ERRCHAR", "DOC_COMMENT", "BLOCK_COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "AnnotatedAntlr4PropertiesParser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public AnnotatedAntlr4PropertiesParser(ITokenStream input)
		: base(input)
	{
		Interpreter = new ParserATNSimulator(this,_ATN);
	}
	public partial class PropertiesBlockContext : ParserRuleContext {
		public ITerminalNode LBRACE() { return GetToken(AnnotatedAntlr4PropertiesParser.LBRACE, 0); }
		public ITerminalNode RBRACE() { return GetToken(AnnotatedAntlr4PropertiesParser.RBRACE, 0); }
		public ITerminalNode Eof() { return GetToken(AnnotatedAntlr4PropertiesParser.Eof, 0); }
		public PropertyAssignmentContext[] propertyAssignment() {
			return GetRuleContexts<PropertyAssignmentContext>();
		}
		public PropertyAssignmentContext propertyAssignment(int i) {
			return GetRuleContext<PropertyAssignmentContext>(i);
		}
		public PropertiesBlockContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_propertiesBlock; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterPropertiesBlock(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitPropertiesBlock(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPropertiesBlock(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PropertiesBlockContext propertiesBlock() {
		PropertiesBlockContext _localctx = new PropertiesBlockContext(Context, State);
		EnterRule(_localctx, 0, RULE_propertiesBlock);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 22; Match(LBRACE);
			State = 26;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==ID) {
				{
				{
				State = 23; propertyAssignment();
				}
				}
				State = 28;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			State = 29; Match(RBRACE);
			State = 30; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PropertyAssignmentContext : ParserRuleContext {
		public QualifiedPropertyContext qualifiedProperty() {
			return GetRuleContext<QualifiedPropertyContext>(0);
		}
		public ITerminalNode ASSIGN() { return GetToken(AnnotatedAntlr4PropertiesParser.ASSIGN, 0); }
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ITerminalNode SEMI() { return GetToken(AnnotatedAntlr4PropertiesParser.SEMI, 0); }
		public PropertyAssignmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_propertyAssignment; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterPropertyAssignment(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitPropertyAssignment(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPropertyAssignment(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PropertyAssignmentContext propertyAssignment() {
		PropertyAssignmentContext _localctx = new PropertyAssignmentContext(Context, State);
		EnterRule(_localctx, 2, RULE_propertyAssignment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 32; qualifiedProperty();
			State = 33; Match(ASSIGN);
			State = 34; expression();
			State = 35; Match(SEMI);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class QualifiedPropertyContext : ParserRuleContext {
		public IdentifierContext scope;
		public PropertySelectorContext[] propertySelector() {
			return GetRuleContexts<PropertySelectorContext>();
		}
		public PropertySelectorContext propertySelector(int i) {
			return GetRuleContext<PropertySelectorContext>(i);
		}
		public ITerminalNode COLONCOLON() { return GetToken(AnnotatedAntlr4PropertiesParser.COLONCOLON, 0); }
		public ITerminalNode[] DOT() { return GetTokens(AnnotatedAntlr4PropertiesParser.DOT); }
		public ITerminalNode DOT(int i) {
			return GetToken(AnnotatedAntlr4PropertiesParser.DOT, i);
		}
		public IdentifierContext identifier() {
			return GetRuleContext<IdentifierContext>(0);
		}
		public QualifiedPropertyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_qualifiedProperty; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterQualifiedProperty(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitQualifiedProperty(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitQualifiedProperty(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public QualifiedPropertyContext qualifiedProperty() {
		QualifiedPropertyContext _localctx = new QualifiedPropertyContext(Context, State);
		EnterRule(_localctx, 4, RULE_qualifiedProperty);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 40;
			switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
			case 1:
				{
				State = 37; _localctx.scope = identifier();
				State = 38; Match(COLONCOLON);
				}
				break;
			}
			State = 42; propertySelector();
			State = 47;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==DOT) {
				{
				{
				State = 43; Match(DOT);
				State = 44; propertySelector();
				}
				}
				State = 49;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PropertySelectorContext : ParserRuleContext {
		public IdentifierContext name;
		public IdentifierContext selector;
		public IdentifierContext[] identifier() {
			return GetRuleContexts<IdentifierContext>();
		}
		public IdentifierContext identifier(int i) {
			return GetRuleContext<IdentifierContext>(i);
		}
		public ITerminalNode LBRACKET() { return GetToken(AnnotatedAntlr4PropertiesParser.LBRACKET, 0); }
		public ITerminalNode RBRACKET() { return GetToken(AnnotatedAntlr4PropertiesParser.RBRACKET, 0); }
		public PropertySelectorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_propertySelector; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterPropertySelector(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitPropertySelector(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPropertySelector(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PropertySelectorContext propertySelector() {
		PropertySelectorContext _localctx = new PropertySelectorContext(Context, State);
		EnterRule(_localctx, 6, RULE_propertySelector);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 50; _localctx.name = identifier();
			State = 55;
			_la = TokenStream.La(1);
			if (_la==LBRACKET) {
				{
				State = 51; Match(LBRACKET);
				State = 52; _localctx.selector = identifier();
				State = 53; Match(RBRACKET);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionListContext : ParserRuleContext {
		public ITerminalNode LPAREN() { return GetToken(AnnotatedAntlr4PropertiesParser.LPAREN, 0); }
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public ITerminalNode RPAREN() { return GetToken(AnnotatedAntlr4PropertiesParser.RPAREN, 0); }
		public ITerminalNode[] COMMA() { return GetTokens(AnnotatedAntlr4PropertiesParser.COMMA); }
		public ITerminalNode COMMA(int i) {
			return GetToken(AnnotatedAntlr4PropertiesParser.COMMA, i);
		}
		public ExpressionListContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expressionList; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterExpressionList(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitExpressionList(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpressionList(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionListContext expressionList() {
		ExpressionListContext _localctx = new ExpressionListContext(Context, State);
		EnterRule(_localctx, 8, RULE_expressionList);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 57; Match(LPAREN);
			State = 58; expression();
			State = 63;
			ErrorHandler.Sync(this);
			_la = TokenStream.La(1);
			while (_la==COMMA) {
				{
				{
				State = 59; Match(COMMA);
				State = 60; expression();
				}
				}
				State = 65;
				ErrorHandler.Sync(this);
				_la = TokenStream.La(1);
			}
			State = 66; Match(RPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public LiteralContext literal() {
			return GetRuleContext<LiteralContext>(0);
		}
		public QualifiedPropertyContext qualifiedProperty() {
			return GetRuleContext<QualifiedPropertyContext>(0);
		}
		public FunctionCallContext functionCall() {
			return GetRuleContext<FunctionCallContext>(0);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterExpression(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitExpression(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpression(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		ExpressionContext _localctx = new ExpressionContext(Context, State);
		EnterRule(_localctx, 10, RULE_expression);
		try {
			State = 71;
			switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 68; literal();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 69; qualifiedProperty();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 70; functionCall();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FunctionCallContext : ParserRuleContext {
		public IdentifierContext identifier() {
			return GetRuleContext<IdentifierContext>(0);
		}
		public ExpressionListContext expressionList() {
			return GetRuleContext<ExpressionListContext>(0);
		}
		public FunctionCallContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_functionCall; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterFunctionCall(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitFunctionCall(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFunctionCall(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FunctionCallContext functionCall() {
		FunctionCallContext _localctx = new FunctionCallContext(Context, State);
		EnterRule(_localctx, 12, RULE_functionCall);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 73; identifier();
			State = 74; expressionList();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LiteralContext : ParserRuleContext {
		public NullLiteralContext nullLiteral() {
			return GetRuleContext<NullLiteralContext>(0);
		}
		public BooleanLiteralContext booleanLiteral() {
			return GetRuleContext<BooleanLiteralContext>(0);
		}
		public ITerminalNode INTEGER_LITERAL() { return GetToken(AnnotatedAntlr4PropertiesParser.INTEGER_LITERAL, 0); }
		public ITerminalNode SCIENTIFIC_LITERAL() { return GetToken(AnnotatedAntlr4PropertiesParser.SCIENTIFIC_LITERAL, 0); }
		public ITerminalNode STRING_LITERAL() { return GetToken(AnnotatedAntlr4PropertiesParser.STRING_LITERAL, 0); }
		public LiteralContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_literal; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterLiteral(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitLiteral(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLiteral(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LiteralContext literal() {
		LiteralContext _localctx = new LiteralContext(Context, State);
		EnterRule(_localctx, 14, RULE_literal);
		try {
			State = 81;
			switch (TokenStream.La(1)) {
			case NULL:
				EnterOuterAlt(_localctx, 1);
				{
				State = 76; nullLiteral();
				}
				break;
			case TRUE:
			case FALSE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 77; booleanLiteral();
				}
				break;
			case INTEGER_LITERAL:
				EnterOuterAlt(_localctx, 3);
				{
				State = 78; Match(INTEGER_LITERAL);
				}
				break;
			case SCIENTIFIC_LITERAL:
				EnterOuterAlt(_localctx, 4);
				{
				State = 79; Match(SCIENTIFIC_LITERAL);
				}
				break;
			case STRING_LITERAL:
				EnterOuterAlt(_localctx, 5);
				{
				State = 80; Match(STRING_LITERAL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class IdentifierContext : ParserRuleContext {
		public ITerminalNode ID() { return GetToken(AnnotatedAntlr4PropertiesParser.ID, 0); }
		public IdentifierContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_identifier; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterIdentifier(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitIdentifier(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIdentifier(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public IdentifierContext identifier() {
		IdentifierContext _localctx = new IdentifierContext(Context, State);
		EnterRule(_localctx, 16, RULE_identifier);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 83; Match(ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BooleanLiteralContext : ParserRuleContext {
		public ITerminalNode TRUE() { return GetToken(AnnotatedAntlr4PropertiesParser.TRUE, 0); }
		public ITerminalNode FALSE() { return GetToken(AnnotatedAntlr4PropertiesParser.FALSE, 0); }
		public BooleanLiteralContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_booleanLiteral; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterBooleanLiteral(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitBooleanLiteral(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBooleanLiteral(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BooleanLiteralContext booleanLiteral() {
		BooleanLiteralContext _localctx = new BooleanLiteralContext(Context, State);
		EnterRule(_localctx, 18, RULE_booleanLiteral);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 85;
			_la = TokenStream.La(1);
			if ( !(_la==TRUE || _la==FALSE) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class NullLiteralContext : ParserRuleContext {
		public ITerminalNode NULL() { return GetToken(AnnotatedAntlr4PropertiesParser.NULL, 0); }
		public NullLiteralContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_nullLiteral; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.EnterNullLiteral(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAnnotatedAntlr4PropertiesParserListener typedListener = listener as IAnnotatedAntlr4PropertiesParserListener;
			if (typedListener != null) typedListener.ExitNullLiteral(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IAnnotatedAntlr4PropertiesParserVisitor<TResult> typedVisitor = visitor as IAnnotatedAntlr4PropertiesParserVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNullLiteral(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public NullLiteralContext nullLiteral() {
		NullLiteralContext _localctx = new NullLiteralContext(Context, State);
		EnterRule(_localctx, 20, RULE_nullLiteral);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 87; Match(NULL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public static readonly string _serializedATN =
		"\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x3&\\\x4\x2\t\x2\x4"+
		"\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4\t\t\t\x4"+
		"\n\t\n\x4\v\t\v\x4\f\t\f\x3\x2\x3\x2\a\x2\x1B\n\x2\f\x2\xE\x2\x1E\v\x2"+
		"\x3\x2\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4\x5"+
		"\x4+\n\x4\x3\x4\x3\x4\x3\x4\a\x4\x30\n\x4\f\x4\xE\x4\x33\v\x4\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x5\x5:\n\x5\x3\x6\x3\x6\x3\x6\x3\x6\a\x6@\n\x6\f"+
		"\x6\xE\x6\x43\v\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x5\aJ\n\a\x3\b\x3\b\x3\b"+
		"\x3\t\x3\t\x3\t\x3\t\x3\t\x5\tT\n\t\x3\n\x3\n\x3\v\x3\v\x3\f\x3\f\x3\f"+
		"\x2\x2\r\x2\x4\x6\b\n\f\xE\x10\x12\x14\x16\x2\x3\x3\x2\x4\x5[\x2\x18\x3"+
		"\x2\x2\x2\x4\"\x3\x2\x2\x2\x6*\x3\x2\x2\x2\b\x34\x3\x2\x2\x2\n;\x3\x2"+
		"\x2\x2\fI\x3\x2\x2\x2\xEK\x3\x2\x2\x2\x10S\x3\x2\x2\x2\x12U\x3\x2\x2\x2"+
		"\x14W\x3\x2\x2\x2\x16Y\x3\x2\x2\x2\x18\x1C\a\x19\x2\x2\x19\x1B\x5\x4\x3"+
		"\x2\x1A\x19\x3\x2\x2\x2\x1B\x1E\x3\x2\x2\x2\x1C\x1A\x3\x2\x2\x2\x1C\x1D"+
		"\x3\x2\x2\x2\x1D\x1F\x3\x2\x2\x2\x1E\x1C\x3\x2\x2\x2\x1F \a\x1A\x2\x2"+
		" !\a\x2\x2\x3!\x3\x3\x2\x2\x2\"#\x5\x6\x4\x2#$\a\xF\x2\x2$%\x5\f\a\x2"+
		"%&\a\n\x2\x2&\x5\x3\x2\x2\x2\'(\x5\x12\n\x2()\a\b\x2\x2)+\x3\x2\x2\x2"+
		"*\'\x3\x2\x2\x2*+\x3\x2\x2\x2+,\x3\x2\x2\x2,\x31\x5\b\x5\x2-.\a\x15\x2"+
		"\x2.\x30\x5\b\x5\x2/-\x3\x2\x2\x2\x30\x33\x3\x2\x2\x2\x31/\x3\x2\x2\x2"+
		"\x31\x32\x3\x2\x2\x2\x32\a\x3\x2\x2\x2\x33\x31\x3\x2\x2\x2\x34\x39\x5"+
		"\x12\n\x2\x35\x36\a\x1B\x2\x2\x36\x37\x5\x12\n\x2\x37\x38\a\x1C\x2\x2"+
		"\x38:\x3\x2\x2\x2\x39\x35\x3\x2\x2\x2\x39:\x3\x2\x2\x2:\t\x3\x2\x2\x2"+
		";<\a\v\x2\x2<\x41\x5\f\a\x2=>\a\t\x2\x2>@\x5\f\a\x2?=\x3\x2\x2\x2@\x43"+
		"\x3\x2\x2\x2\x41?\x3\x2\x2\x2\x41\x42\x3\x2\x2\x2\x42\x44\x3\x2\x2\x2"+
		"\x43\x41\x3\x2\x2\x2\x44\x45\a\f\x2\x2\x45\v\x3\x2\x2\x2\x46J\x5\x10\t"+
		"\x2GJ\x5\x6\x4\x2HJ\x5\xE\b\x2I\x46\x3\x2\x2\x2IG\x3\x2\x2\x2IH\x3\x2"+
		"\x2\x2J\r\x3\x2\x2\x2KL\x5\x12\n\x2LM\x5\n\x6\x2M\xF\x3\x2\x2\x2NT\x5"+
		"\x16\f\x2OT\x5\x14\v\x2PT\a\x1E\x2\x2QT\a \x2\x2RT\a!\x2\x2SN\x3\x2\x2"+
		"\x2SO\x3\x2\x2\x2SP\x3\x2\x2\x2SQ\x3\x2\x2\x2SR\x3\x2\x2\x2T\x11\x3\x2"+
		"\x2\x2UV\a\x1D\x2\x2V\x13\x3\x2\x2\x2WX\t\x2\x2\x2X\x15\x3\x2\x2\x2YZ"+
		"\a\x6\x2\x2Z\x17\x3\x2\x2\x2\t\x1C*\x31\x39\x41IS";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace MetaDslx.Compiler
