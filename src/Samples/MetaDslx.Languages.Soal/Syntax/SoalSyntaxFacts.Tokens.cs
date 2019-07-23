// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Soal.Syntax
{
	public enum SoalTokenKind : int
	{
		None = 0,
		ContextualKeyword,
		DocumentationCommentTrivia,
		ExternAliasDirective,
		FixedToken,
		GeneralComment,
		GeneralCommentTrivia,
		Identifier,
		Number,
		PreprocessorContextualKeyword,
		PreprocessorDirective,
		PreprocessorKeyword,
		ReservedKeyword,
		String,
		Token,
		Trivia,
		Whitespace
	}

	public enum SoalLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		MULTILINE_COMMENT = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class SoalTokensSyntaxFacts : SyntaxFacts
	{
        public SoalTokensSyntaxFacts() 
            : base(typeof(SoalTokensSyntaxKind))
        {
        }

        protected SoalTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (SoalTokensSyntaxKind)SoalTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (SoalTokensSyntaxKind)SoalTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (SoalTokensSyntaxKind)SoalTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (SoalTokensSyntaxKind)SoalTokensSyntaxKind.IdentifierNormal;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case SoalTokensSyntaxKind.Eof:
				case SoalTokensSyntaxKind.KNamespace:
				case SoalTokensSyntaxKind.KEnum:
				case SoalTokensSyntaxKind.KException:
				case SoalTokensSyntaxKind.KStruct:
				case SoalTokensSyntaxKind.KInterface:
				case SoalTokensSyntaxKind.KThrows:
				case SoalTokensSyntaxKind.KOneway:
				case SoalTokensSyntaxKind.KReturn:
				case SoalTokensSyntaxKind.KBinding:
				case SoalTokensSyntaxKind.KTransport:
				case SoalTokensSyntaxKind.KEncoding:
				case SoalTokensSyntaxKind.KProtocol:
				case SoalTokensSyntaxKind.KEndpoint:
				case SoalTokensSyntaxKind.KAddress:
				case SoalTokensSyntaxKind.KDatabase:
				case SoalTokensSyntaxKind.KEntity:
				case SoalTokensSyntaxKind.KAbstract:
				case SoalTokensSyntaxKind.KComponent:
				case SoalTokensSyntaxKind.KComposite:
				case SoalTokensSyntaxKind.KReference:
				case SoalTokensSyntaxKind.KService:
				case SoalTokensSyntaxKind.KWire:
				case SoalTokensSyntaxKind.KTo:
				case SoalTokensSyntaxKind.KImplementation:
				case SoalTokensSyntaxKind.KLanguage:
				case SoalTokensSyntaxKind.KAssembly:
				case SoalTokensSyntaxKind.KDeployment:
				case SoalTokensSyntaxKind.KEnvironment:
				case SoalTokensSyntaxKind.KRuntime:
				case SoalTokensSyntaxKind.KNull:
				case SoalTokensSyntaxKind.KTrue:
				case SoalTokensSyntaxKind.KFalse:
				case SoalTokensSyntaxKind.KObject:
				case SoalTokensSyntaxKind.KString:
				case SoalTokensSyntaxKind.KInt:
				case SoalTokensSyntaxKind.KLong:
				case SoalTokensSyntaxKind.KFloat:
				case SoalTokensSyntaxKind.KDouble:
				case SoalTokensSyntaxKind.KByte:
				case SoalTokensSyntaxKind.KBool:
				case SoalTokensSyntaxKind.KAny:
				case SoalTokensSyntaxKind.KTypeof:
				case SoalTokensSyntaxKind.KVoid:
				case SoalTokensSyntaxKind.TSemicolon:
				case SoalTokensSyntaxKind.TColon:
				case SoalTokensSyntaxKind.TDot:
				case SoalTokensSyntaxKind.TComma:
				case SoalTokensSyntaxKind.TAssign:
				case SoalTokensSyntaxKind.TOpenParen:
				case SoalTokensSyntaxKind.TCloseParen:
				case SoalTokensSyntaxKind.TOpenBracket:
				case SoalTokensSyntaxKind.TCloseBracket:
				case SoalTokensSyntaxKind.TOpenBrace:
				case SoalTokensSyntaxKind.TCloseBrace:
				case SoalTokensSyntaxKind.TLessThan:
				case SoalTokensSyntaxKind.TGreaterThan:
				case SoalTokensSyntaxKind.TQuestion:
				case SoalTokensSyntaxKind.TQuestionQuestion:
				case SoalTokensSyntaxKind.TAmpersand:
				case SoalTokensSyntaxKind.THat:
				case SoalTokensSyntaxKind.TBar:
				case SoalTokensSyntaxKind.TAndAlso:
				case SoalTokensSyntaxKind.TOrElse:
				case SoalTokensSyntaxKind.TPlusPlus:
				case SoalTokensSyntaxKind.TMinusMinus:
				case SoalTokensSyntaxKind.TPlus:
				case SoalTokensSyntaxKind.TMinus:
				case SoalTokensSyntaxKind.TTilde:
				case SoalTokensSyntaxKind.TExclamation:
				case SoalTokensSyntaxKind.TSlash:
				case SoalTokensSyntaxKind.TAsterisk:
				case SoalTokensSyntaxKind.TPercent:
				case SoalTokensSyntaxKind.TLessThanOrEqual:
				case SoalTokensSyntaxKind.TGreaterThanOrEqual:
				case SoalTokensSyntaxKind.TEqual:
				case SoalTokensSyntaxKind.TNotEqual:
				case SoalTokensSyntaxKind.TAsteriskAssign:
				case SoalTokensSyntaxKind.TSlashAssign:
				case SoalTokensSyntaxKind.TPercentAssign:
				case SoalTokensSyntaxKind.TPlusAssign:
				case SoalTokensSyntaxKind.TMinusAssign:
				case SoalTokensSyntaxKind.TLeftShiftAssign:
				case SoalTokensSyntaxKind.TRightShiftAssign:
				case SoalTokensSyntaxKind.TAmpersandAssign:
				case SoalTokensSyntaxKind.THatAssign:
				case SoalTokensSyntaxKind.TBarAssign:
				case SoalTokensSyntaxKind.IDate:
				case SoalTokensSyntaxKind.ITime:
				case SoalTokensSyntaxKind.IDateTime:
				case SoalTokensSyntaxKind.ITimeSpan:
				case SoalTokensSyntaxKind.IVersion:
				case SoalTokensSyntaxKind.IStyle:
				case SoalTokensSyntaxKind.IMTOM:
				case SoalTokensSyntaxKind.ISSL:
				case SoalTokensSyntaxKind.IHTTP:
				case SoalTokensSyntaxKind.IREST:
				case SoalTokensSyntaxKind.IWebSocket:
				case SoalTokensSyntaxKind.ISOAP:
				case SoalTokensSyntaxKind.IXML:
				case SoalTokensSyntaxKind.IJSON:
				case SoalTokensSyntaxKind.IClientAuthentication:
				case SoalTokensSyntaxKind.IWsAddressing:
				case SoalTokensSyntaxKind.IdentifierNormal:
				case SoalTokensSyntaxKind.IdentifierVerbatim:
				case SoalTokensSyntaxKind.LInteger:
				case SoalTokensSyntaxKind.LDecimal:
				case SoalTokensSyntaxKind.LScientific:
				case SoalTokensSyntaxKind.LDateTimeOffset:
				case SoalTokensSyntaxKind.LDateTime:
				case SoalTokensSyntaxKind.LDate:
				case SoalTokensSyntaxKind.LTime:
				case SoalTokensSyntaxKind.LRegularString:
				case SoalTokensSyntaxKind.LGuid:
				case SoalTokensSyntaxKind.LUtf8Bom:
				case SoalTokensSyntaxKind.LWhiteSpace:
				case SoalTokensSyntaxKind.LCrLf:
				case SoalTokensSyntaxKind.LLineEnd:
				case SoalTokensSyntaxKind.LSingleLineComment:
				case SoalTokensSyntaxKind.LMultiLineComment:
				case SoalTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case SoalTokensSyntaxKind.LSingleQuoteVerbatimString:
				case SoalTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case SoalTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case SoalTokensSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case SoalTokensSyntaxKind.KNamespace:
				case SoalTokensSyntaxKind.KEnum:
				case SoalTokensSyntaxKind.KException:
				case SoalTokensSyntaxKind.KStruct:
				case SoalTokensSyntaxKind.KInterface:
				case SoalTokensSyntaxKind.KThrows:
				case SoalTokensSyntaxKind.KOneway:
				case SoalTokensSyntaxKind.KReturn:
				case SoalTokensSyntaxKind.KBinding:
				case SoalTokensSyntaxKind.KTransport:
				case SoalTokensSyntaxKind.KEncoding:
				case SoalTokensSyntaxKind.KProtocol:
				case SoalTokensSyntaxKind.KEndpoint:
				case SoalTokensSyntaxKind.KAddress:
				case SoalTokensSyntaxKind.KDatabase:
				case SoalTokensSyntaxKind.KEntity:
				case SoalTokensSyntaxKind.KAbstract:
				case SoalTokensSyntaxKind.KComponent:
				case SoalTokensSyntaxKind.KComposite:
				case SoalTokensSyntaxKind.KReference:
				case SoalTokensSyntaxKind.KService:
				case SoalTokensSyntaxKind.KWire:
				case SoalTokensSyntaxKind.KTo:
				case SoalTokensSyntaxKind.KImplementation:
				case SoalTokensSyntaxKind.KLanguage:
				case SoalTokensSyntaxKind.KAssembly:
				case SoalTokensSyntaxKind.KDeployment:
				case SoalTokensSyntaxKind.KEnvironment:
				case SoalTokensSyntaxKind.KRuntime:
				case SoalTokensSyntaxKind.KNull:
				case SoalTokensSyntaxKind.KTrue:
				case SoalTokensSyntaxKind.KFalse:
				case SoalTokensSyntaxKind.KObject:
				case SoalTokensSyntaxKind.KString:
				case SoalTokensSyntaxKind.KInt:
				case SoalTokensSyntaxKind.KLong:
				case SoalTokensSyntaxKind.KFloat:
				case SoalTokensSyntaxKind.KDouble:
				case SoalTokensSyntaxKind.KByte:
				case SoalTokensSyntaxKind.KBool:
				case SoalTokensSyntaxKind.KAny:
				case SoalTokensSyntaxKind.KTypeof:
				case SoalTokensSyntaxKind.KVoid:
				case SoalTokensSyntaxKind.TSemicolon:
				case SoalTokensSyntaxKind.TColon:
				case SoalTokensSyntaxKind.TDot:
				case SoalTokensSyntaxKind.TComma:
				case SoalTokensSyntaxKind.TAssign:
				case SoalTokensSyntaxKind.TOpenParen:
				case SoalTokensSyntaxKind.TCloseParen:
				case SoalTokensSyntaxKind.TOpenBracket:
				case SoalTokensSyntaxKind.TCloseBracket:
				case SoalTokensSyntaxKind.TOpenBrace:
				case SoalTokensSyntaxKind.TCloseBrace:
				case SoalTokensSyntaxKind.TLessThan:
				case SoalTokensSyntaxKind.TGreaterThan:
				case SoalTokensSyntaxKind.TQuestion:
				case SoalTokensSyntaxKind.TQuestionQuestion:
				case SoalTokensSyntaxKind.TAmpersand:
				case SoalTokensSyntaxKind.THat:
				case SoalTokensSyntaxKind.TBar:
				case SoalTokensSyntaxKind.TAndAlso:
				case SoalTokensSyntaxKind.TOrElse:
				case SoalTokensSyntaxKind.TPlusPlus:
				case SoalTokensSyntaxKind.TMinusMinus:
				case SoalTokensSyntaxKind.TPlus:
				case SoalTokensSyntaxKind.TMinus:
				case SoalTokensSyntaxKind.TTilde:
				case SoalTokensSyntaxKind.TExclamation:
				case SoalTokensSyntaxKind.TSlash:
				case SoalTokensSyntaxKind.TPercent:
				case SoalTokensSyntaxKind.TLessThanOrEqual:
				case SoalTokensSyntaxKind.TGreaterThanOrEqual:
				case SoalTokensSyntaxKind.TEqual:
				case SoalTokensSyntaxKind.TNotEqual:
				case SoalTokensSyntaxKind.TAsteriskAssign:
				case SoalTokensSyntaxKind.TSlashAssign:
				case SoalTokensSyntaxKind.TPercentAssign:
				case SoalTokensSyntaxKind.TPlusAssign:
				case SoalTokensSyntaxKind.TMinusAssign:
				case SoalTokensSyntaxKind.TLeftShiftAssign:
				case SoalTokensSyntaxKind.TRightShiftAssign:
				case SoalTokensSyntaxKind.TAmpersandAssign:
				case SoalTokensSyntaxKind.THatAssign:
				case SoalTokensSyntaxKind.TBarAssign:
				case SoalTokensSyntaxKind.IDate:
				case SoalTokensSyntaxKind.ITime:
				case SoalTokensSyntaxKind.IDateTime:
				case SoalTokensSyntaxKind.ITimeSpan:
				case SoalTokensSyntaxKind.IVersion:
				case SoalTokensSyntaxKind.IStyle:
				case SoalTokensSyntaxKind.IMTOM:
				case SoalTokensSyntaxKind.ISSL:
				case SoalTokensSyntaxKind.IHTTP:
				case SoalTokensSyntaxKind.IREST:
				case SoalTokensSyntaxKind.IWebSocket:
				case SoalTokensSyntaxKind.ISOAP:
				case SoalTokensSyntaxKind.IXML:
				case SoalTokensSyntaxKind.IJSON:
				case SoalTokensSyntaxKind.IClientAuthentication:
				case SoalTokensSyntaxKind.IWsAddressing:
				case SoalTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case SoalTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case SoalTokensSyntaxKind.LCommentStart:
				case SoalTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case SoalTokensSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}

		public override SyntaxKind GetFixedTokenKind(string text)
		{
			switch (text)
			{
				case "namespace":
					return SoalTokensSyntaxKind.KNamespace;
				case "enum":
					return SoalTokensSyntaxKind.KEnum;
				case "exception":
					return SoalTokensSyntaxKind.KException;
				case "struct":
					return SoalTokensSyntaxKind.KStruct;
				case "interface":
					return SoalTokensSyntaxKind.KInterface;
				case "throws":
					return SoalTokensSyntaxKind.KThrows;
				case "oneway":
					return SoalTokensSyntaxKind.KOneway;
				case "return":
					return SoalTokensSyntaxKind.KReturn;
				case "binding":
					return SoalTokensSyntaxKind.KBinding;
				case "transport":
					return SoalTokensSyntaxKind.KTransport;
				case "encoding":
					return SoalTokensSyntaxKind.KEncoding;
				case "protocol":
					return SoalTokensSyntaxKind.KProtocol;
				case "endpoint":
					return SoalTokensSyntaxKind.KEndpoint;
				case "address":
					return SoalTokensSyntaxKind.KAddress;
				case "database":
					return SoalTokensSyntaxKind.KDatabase;
				case "entity":
					return SoalTokensSyntaxKind.KEntity;
				case "abstract":
					return SoalTokensSyntaxKind.KAbstract;
				case "component":
					return SoalTokensSyntaxKind.KComponent;
				case "composite":
					return SoalTokensSyntaxKind.KComposite;
				case "reference":
					return SoalTokensSyntaxKind.KReference;
				case "service":
					return SoalTokensSyntaxKind.KService;
				case "wire":
					return SoalTokensSyntaxKind.KWire;
				case "to":
					return SoalTokensSyntaxKind.KTo;
				case "implementation":
					return SoalTokensSyntaxKind.KImplementation;
				case "language":
					return SoalTokensSyntaxKind.KLanguage;
				case "assembly":
					return SoalTokensSyntaxKind.KAssembly;
				case "deployment":
					return SoalTokensSyntaxKind.KDeployment;
				case "environment":
					return SoalTokensSyntaxKind.KEnvironment;
				case "runtime":
					return SoalTokensSyntaxKind.KRuntime;
				case "null":
					return SoalTokensSyntaxKind.KNull;
				case "true":
					return SoalTokensSyntaxKind.KTrue;
				case "false":
					return SoalTokensSyntaxKind.KFalse;
				case "object":
					return SoalTokensSyntaxKind.KObject;
				case "string":
					return SoalTokensSyntaxKind.KString;
				case "int":
					return SoalTokensSyntaxKind.KInt;
				case "long":
					return SoalTokensSyntaxKind.KLong;
				case "float":
					return SoalTokensSyntaxKind.KFloat;
				case "double":
					return SoalTokensSyntaxKind.KDouble;
				case "byte":
					return SoalTokensSyntaxKind.KByte;
				case "bool":
					return SoalTokensSyntaxKind.KBool;
				case "any":
					return SoalTokensSyntaxKind.KAny;
				case "typeof":
					return SoalTokensSyntaxKind.KTypeof;
				case "void":
					return SoalTokensSyntaxKind.KVoid;
				case ";":
					return SoalTokensSyntaxKind.TSemicolon;
				case ":":
					return SoalTokensSyntaxKind.TColon;
				case ".":
					return SoalTokensSyntaxKind.TDot;
				case ",":
					return SoalTokensSyntaxKind.TComma;
				case "=":
					return SoalTokensSyntaxKind.TAssign;
				case "(":
					return SoalTokensSyntaxKind.TOpenParen;
				case ")":
					return SoalTokensSyntaxKind.TCloseParen;
				case "[":
					return SoalTokensSyntaxKind.TOpenBracket;
				case "]":
					return SoalTokensSyntaxKind.TCloseBracket;
				case "{":
					return SoalTokensSyntaxKind.TOpenBrace;
				case "}":
					return SoalTokensSyntaxKind.TCloseBrace;
				case "<":
					return SoalTokensSyntaxKind.TLessThan;
				case ">":
					return SoalTokensSyntaxKind.TGreaterThan;
				case "?":
					return SoalTokensSyntaxKind.TQuestion;
				case "??":
					return SoalTokensSyntaxKind.TQuestionQuestion;
				case "&":
					return SoalTokensSyntaxKind.TAmpersand;
				case "^":
					return SoalTokensSyntaxKind.THat;
				case "|":
					return SoalTokensSyntaxKind.TBar;
				case "&&":
					return SoalTokensSyntaxKind.TAndAlso;
				case "||":
					return SoalTokensSyntaxKind.TOrElse;
				case "++":
					return SoalTokensSyntaxKind.TPlusPlus;
				case "--":
					return SoalTokensSyntaxKind.TMinusMinus;
				case "+":
					return SoalTokensSyntaxKind.TPlus;
				case "-":
					return SoalTokensSyntaxKind.TMinus;
				case "~":
					return SoalTokensSyntaxKind.TTilde;
				case "!":
					return SoalTokensSyntaxKind.TExclamation;
				case "/":
					return SoalTokensSyntaxKind.TSlash;
				case "%":
					return SoalTokensSyntaxKind.TPercent;
				case "<=":
					return SoalTokensSyntaxKind.TLessThanOrEqual;
				case ">=":
					return SoalTokensSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return SoalTokensSyntaxKind.TEqual;
				case "!=":
					return SoalTokensSyntaxKind.TNotEqual;
				case "*=":
					return SoalTokensSyntaxKind.TAsteriskAssign;
				case "/=":
					return SoalTokensSyntaxKind.TSlashAssign;
				case "%=":
					return SoalTokensSyntaxKind.TPercentAssign;
				case "+=":
					return SoalTokensSyntaxKind.TPlusAssign;
				case "-=":
					return SoalTokensSyntaxKind.TMinusAssign;
				case "<<=":
					return SoalTokensSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return SoalTokensSyntaxKind.TRightShiftAssign;
				case "&=":
					return SoalTokensSyntaxKind.TAmpersandAssign;
				case "^=":
					return SoalTokensSyntaxKind.THatAssign;
				case "|=":
					return SoalTokensSyntaxKind.TBarAssign;
				case "Date":
					return SoalTokensSyntaxKind.IDate;
				case "Time":
					return SoalTokensSyntaxKind.ITime;
				case "DateTime":
					return SoalTokensSyntaxKind.IDateTime;
				case "TimeSpan":
					return SoalTokensSyntaxKind.ITimeSpan;
				case "Version":
					return SoalTokensSyntaxKind.IVersion;
				case "Style":
					return SoalTokensSyntaxKind.IStyle;
				case "MTOM":
					return SoalTokensSyntaxKind.IMTOM;
				case "SSL":
					return SoalTokensSyntaxKind.ISSL;
				case "HTTP":
					return SoalTokensSyntaxKind.IHTTP;
				case "REST":
					return SoalTokensSyntaxKind.IREST;
				case "WebSocket":
					return SoalTokensSyntaxKind.IWebSocket;
				case "SOAP":
					return SoalTokensSyntaxKind.ISOAP;
				case "XML":
					return SoalTokensSyntaxKind.IXML;
				case "JSON":
					return SoalTokensSyntaxKind.IJSON;
				case "ClientAuthentication":
					return SoalTokensSyntaxKind.IClientAuthentication;
				case "WsAddressing":
					return SoalTokensSyntaxKind.IWsAddressing;
				case "@\"":
					return SoalTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return SoalTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return SoalTokensSyntaxKind.LCommentStart;
				case "\"":
					return SoalTokensSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return SoalTokensSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return SoalTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case SoalTokensSyntaxKind.KNamespace:
					return "namespace";
				case SoalTokensSyntaxKind.KEnum:
					return "enum";
				case SoalTokensSyntaxKind.KException:
					return "exception";
				case SoalTokensSyntaxKind.KStruct:
					return "struct";
				case SoalTokensSyntaxKind.KInterface:
					return "interface";
				case SoalTokensSyntaxKind.KThrows:
					return "throws";
				case SoalTokensSyntaxKind.KOneway:
					return "oneway";
				case SoalTokensSyntaxKind.KReturn:
					return "return";
				case SoalTokensSyntaxKind.KBinding:
					return "binding";
				case SoalTokensSyntaxKind.KTransport:
					return "transport";
				case SoalTokensSyntaxKind.KEncoding:
					return "encoding";
				case SoalTokensSyntaxKind.KProtocol:
					return "protocol";
				case SoalTokensSyntaxKind.KEndpoint:
					return "endpoint";
				case SoalTokensSyntaxKind.KAddress:
					return "address";
				case SoalTokensSyntaxKind.KDatabase:
					return "database";
				case SoalTokensSyntaxKind.KEntity:
					return "entity";
				case SoalTokensSyntaxKind.KAbstract:
					return "abstract";
				case SoalTokensSyntaxKind.KComponent:
					return "component";
				case SoalTokensSyntaxKind.KComposite:
					return "composite";
				case SoalTokensSyntaxKind.KReference:
					return "reference";
				case SoalTokensSyntaxKind.KService:
					return "service";
				case SoalTokensSyntaxKind.KWire:
					return "wire";
				case SoalTokensSyntaxKind.KTo:
					return "to";
				case SoalTokensSyntaxKind.KImplementation:
					return "implementation";
				case SoalTokensSyntaxKind.KLanguage:
					return "language";
				case SoalTokensSyntaxKind.KAssembly:
					return "assembly";
				case SoalTokensSyntaxKind.KDeployment:
					return "deployment";
				case SoalTokensSyntaxKind.KEnvironment:
					return "environment";
				case SoalTokensSyntaxKind.KRuntime:
					return "runtime";
				case SoalTokensSyntaxKind.KNull:
					return "null";
				case SoalTokensSyntaxKind.KTrue:
					return "true";
				case SoalTokensSyntaxKind.KFalse:
					return "false";
				case SoalTokensSyntaxKind.KObject:
					return "object";
				case SoalTokensSyntaxKind.KString:
					return "string";
				case SoalTokensSyntaxKind.KInt:
					return "int";
				case SoalTokensSyntaxKind.KLong:
					return "long";
				case SoalTokensSyntaxKind.KFloat:
					return "float";
				case SoalTokensSyntaxKind.KDouble:
					return "double";
				case SoalTokensSyntaxKind.KByte:
					return "byte";
				case SoalTokensSyntaxKind.KBool:
					return "bool";
				case SoalTokensSyntaxKind.KAny:
					return "any";
				case SoalTokensSyntaxKind.KTypeof:
					return "typeof";
				case SoalTokensSyntaxKind.KVoid:
					return "void";
				case SoalTokensSyntaxKind.TSemicolon:
					return ";";
				case SoalTokensSyntaxKind.TColon:
					return ":";
				case SoalTokensSyntaxKind.TDot:
					return ".";
				case SoalTokensSyntaxKind.TComma:
					return ",";
				case SoalTokensSyntaxKind.TAssign:
					return "=";
				case SoalTokensSyntaxKind.TOpenParen:
					return "(";
				case SoalTokensSyntaxKind.TCloseParen:
					return ")";
				case SoalTokensSyntaxKind.TOpenBracket:
					return "[";
				case SoalTokensSyntaxKind.TCloseBracket:
					return "]";
				case SoalTokensSyntaxKind.TOpenBrace:
					return "{";
				case SoalTokensSyntaxKind.TCloseBrace:
					return "}";
				case SoalTokensSyntaxKind.TLessThan:
					return "<";
				case SoalTokensSyntaxKind.TGreaterThan:
					return ">";
				case SoalTokensSyntaxKind.TQuestion:
					return "?";
				case SoalTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case SoalTokensSyntaxKind.TAmpersand:
					return "&";
				case SoalTokensSyntaxKind.THat:
					return "^";
				case SoalTokensSyntaxKind.TBar:
					return "|";
				case SoalTokensSyntaxKind.TAndAlso:
					return "&&";
				case SoalTokensSyntaxKind.TOrElse:
					return "||";
				case SoalTokensSyntaxKind.TPlusPlus:
					return "++";
				case SoalTokensSyntaxKind.TMinusMinus:
					return "--";
				case SoalTokensSyntaxKind.TPlus:
					return "+";
				case SoalTokensSyntaxKind.TMinus:
					return "-";
				case SoalTokensSyntaxKind.TTilde:
					return "~";
				case SoalTokensSyntaxKind.TExclamation:
					return "!";
				case SoalTokensSyntaxKind.TSlash:
					return "/";
				case SoalTokensSyntaxKind.TPercent:
					return "%";
				case SoalTokensSyntaxKind.TLessThanOrEqual:
					return "<=";
				case SoalTokensSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case SoalTokensSyntaxKind.TEqual:
					return "==";
				case SoalTokensSyntaxKind.TNotEqual:
					return "!=";
				case SoalTokensSyntaxKind.TAsteriskAssign:
					return "*=";
				case SoalTokensSyntaxKind.TSlashAssign:
					return "/=";
				case SoalTokensSyntaxKind.TPercentAssign:
					return "%=";
				case SoalTokensSyntaxKind.TPlusAssign:
					return "+=";
				case SoalTokensSyntaxKind.TMinusAssign:
					return "-=";
				case SoalTokensSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case SoalTokensSyntaxKind.TRightShiftAssign:
					return ">>=";
				case SoalTokensSyntaxKind.TAmpersandAssign:
					return "&=";
				case SoalTokensSyntaxKind.THatAssign:
					return "^=";
				case SoalTokensSyntaxKind.TBarAssign:
					return "|=";
				case SoalTokensSyntaxKind.IDate:
					return "Date";
				case SoalTokensSyntaxKind.ITime:
					return "Time";
				case SoalTokensSyntaxKind.IDateTime:
					return "DateTime";
				case SoalTokensSyntaxKind.ITimeSpan:
					return "TimeSpan";
				case SoalTokensSyntaxKind.IVersion:
					return "Version";
				case SoalTokensSyntaxKind.IStyle:
					return "Style";
				case SoalTokensSyntaxKind.IMTOM:
					return "MTOM";
				case SoalTokensSyntaxKind.ISSL:
					return "SSL";
				case SoalTokensSyntaxKind.IHTTP:
					return "HTTP";
				case SoalTokensSyntaxKind.IREST:
					return "REST";
				case SoalTokensSyntaxKind.IWebSocket:
					return "WebSocket";
				case SoalTokensSyntaxKind.ISOAP:
					return "SOAP";
				case SoalTokensSyntaxKind.IXML:
					return "XML";
				case SoalTokensSyntaxKind.IJSON:
					return "JSON";
				case SoalTokensSyntaxKind.IClientAuthentication:
					return "ClientAuthentication";
				case SoalTokensSyntaxKind.IWsAddressing:
					return "WsAddressing";
				case SoalTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case SoalTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case SoalTokensSyntaxKind.LCommentStart:
					return "/*";
				case SoalTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case SoalTokensSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public SoalTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<SoalTokensSyntaxKind>(rawKind));
		}

		public SoalTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SoalTokensSyntaxKind.KNamespace:
				case SoalTokensSyntaxKind.KEnum:
				case SoalTokensSyntaxKind.KException:
				case SoalTokensSyntaxKind.KStruct:
				case SoalTokensSyntaxKind.KInterface:
				case SoalTokensSyntaxKind.KThrows:
				case SoalTokensSyntaxKind.KOneway:
				case SoalTokensSyntaxKind.KReturn:
				case SoalTokensSyntaxKind.KBinding:
				case SoalTokensSyntaxKind.KTransport:
				case SoalTokensSyntaxKind.KEncoding:
				case SoalTokensSyntaxKind.KProtocol:
				case SoalTokensSyntaxKind.KEndpoint:
				case SoalTokensSyntaxKind.KAddress:
				case SoalTokensSyntaxKind.KDatabase:
				case SoalTokensSyntaxKind.KEntity:
				case SoalTokensSyntaxKind.KAbstract:
				case SoalTokensSyntaxKind.KComponent:
				case SoalTokensSyntaxKind.KComposite:
				case SoalTokensSyntaxKind.KReference:
				case SoalTokensSyntaxKind.KService:
				case SoalTokensSyntaxKind.KWire:
				case SoalTokensSyntaxKind.KTo:
				case SoalTokensSyntaxKind.KImplementation:
				case SoalTokensSyntaxKind.KLanguage:
				case SoalTokensSyntaxKind.KAssembly:
				case SoalTokensSyntaxKind.KDeployment:
				case SoalTokensSyntaxKind.KEnvironment:
				case SoalTokensSyntaxKind.KRuntime:
				case SoalTokensSyntaxKind.KNull:
				case SoalTokensSyntaxKind.KTrue:
				case SoalTokensSyntaxKind.KFalse:
				case SoalTokensSyntaxKind.KObject:
				case SoalTokensSyntaxKind.KString:
				case SoalTokensSyntaxKind.KInt:
				case SoalTokensSyntaxKind.KLong:
				case SoalTokensSyntaxKind.KFloat:
				case SoalTokensSyntaxKind.KDouble:
				case SoalTokensSyntaxKind.KByte:
				case SoalTokensSyntaxKind.KBool:
				case SoalTokensSyntaxKind.KAny:
				case SoalTokensSyntaxKind.KTypeof:
				case SoalTokensSyntaxKind.KVoid:
					return SoalTokenKind.ReservedKeyword;
				case SoalTokensSyntaxKind.IdentifierNormal:
					return SoalTokenKind.Identifier;
				case SoalTokensSyntaxKind.IdentifierVerbatim:
					return SoalTokenKind.Identifier;
				case SoalTokensSyntaxKind.LInteger:
					return SoalTokenKind.Number;
				case SoalTokensSyntaxKind.LDecimal:
					return SoalTokenKind.Number;
				case SoalTokensSyntaxKind.LScientific:
					return SoalTokenKind.Number;
				case SoalTokensSyntaxKind.LDateTimeOffset:
					return SoalTokenKind.Number;
				case SoalTokensSyntaxKind.LDateTime:
					return SoalTokenKind.Number;
				case SoalTokensSyntaxKind.LDate:
					return SoalTokenKind.Number;
				case SoalTokensSyntaxKind.LTime:
					return SoalTokenKind.Number;
				case SoalTokensSyntaxKind.LRegularString:
					return SoalTokenKind.String;
				case SoalTokensSyntaxKind.LGuid:
					return SoalTokenKind.String;
				case SoalTokensSyntaxKind.LUtf8Bom:
					return SoalTokenKind.Whitespace;
				case SoalTokensSyntaxKind.LWhiteSpace:
					return SoalTokenKind.Whitespace;
				case SoalTokensSyntaxKind.LCrLf:
					return SoalTokenKind.Whitespace;
				case SoalTokensSyntaxKind.LLineEnd:
					return SoalTokenKind.Whitespace;
				case SoalTokensSyntaxKind.LSingleLineComment:
					return SoalTokenKind.GeneralComment;
				case SoalTokensSyntaxKind.LMultiLineComment:
					return SoalTokenKind.GeneralComment;
				case SoalTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return SoalTokenKind.String;
				case SoalTokensSyntaxKind.LSingleQuoteVerbatimString:
					return SoalTokenKind.String;
				default:
					return SoalTokenKind.None;
			}
		}

		public SoalTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((SoalLexerMode)rawKind);
		}

		public SoalTokenKind GetModeTokenKind(SoalLexerMode kind)
		{
			switch(kind)
			{
				case SoalLexerMode.MULTILINE_COMMENT:
					return SoalTokenKind.GeneralComment;
				case SoalLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return SoalTokenKind.String;
				case SoalLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return SoalTokenKind.String;
				default:
					return SoalTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SoalTokensSyntaxKind.LCrLf:
					return true;
				case SoalTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}

		public override bool IsTrivia(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsReservedKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SoalTokensSyntaxKind.KNamespace:
				case SoalTokensSyntaxKind.KEnum:
				case SoalTokensSyntaxKind.KException:
				case SoalTokensSyntaxKind.KStruct:
				case SoalTokensSyntaxKind.KInterface:
				case SoalTokensSyntaxKind.KThrows:
				case SoalTokensSyntaxKind.KOneway:
				case SoalTokensSyntaxKind.KReturn:
				case SoalTokensSyntaxKind.KBinding:
				case SoalTokensSyntaxKind.KTransport:
				case SoalTokensSyntaxKind.KEncoding:
				case SoalTokensSyntaxKind.KProtocol:
				case SoalTokensSyntaxKind.KEndpoint:
				case SoalTokensSyntaxKind.KAddress:
				case SoalTokensSyntaxKind.KDatabase:
				case SoalTokensSyntaxKind.KEntity:
				case SoalTokensSyntaxKind.KAbstract:
				case SoalTokensSyntaxKind.KComponent:
				case SoalTokensSyntaxKind.KComposite:
				case SoalTokensSyntaxKind.KReference:
				case SoalTokensSyntaxKind.KService:
				case SoalTokensSyntaxKind.KWire:
				case SoalTokensSyntaxKind.KTo:
				case SoalTokensSyntaxKind.KImplementation:
				case SoalTokensSyntaxKind.KLanguage:
				case SoalTokensSyntaxKind.KAssembly:
				case SoalTokensSyntaxKind.KDeployment:
				case SoalTokensSyntaxKind.KEnvironment:
				case SoalTokensSyntaxKind.KRuntime:
				case SoalTokensSyntaxKind.KNull:
				case SoalTokensSyntaxKind.KTrue:
				case SoalTokensSyntaxKind.KFalse:
				case SoalTokensSyntaxKind.KObject:
				case SoalTokensSyntaxKind.KString:
				case SoalTokensSyntaxKind.KInt:
				case SoalTokensSyntaxKind.KLong:
				case SoalTokensSyntaxKind.KFloat:
				case SoalTokensSyntaxKind.KDouble:
				case SoalTokensSyntaxKind.KByte:
				case SoalTokensSyntaxKind.KBool:
				case SoalTokensSyntaxKind.KAny:
				case SoalTokensSyntaxKind.KTypeof:
				case SoalTokensSyntaxKind.KVoid:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return SoalTokensSyntaxKind.KNamespace;
				yield return SoalTokensSyntaxKind.KEnum;
				yield return SoalTokensSyntaxKind.KException;
				yield return SoalTokensSyntaxKind.KStruct;
				yield return SoalTokensSyntaxKind.KInterface;
				yield return SoalTokensSyntaxKind.KThrows;
				yield return SoalTokensSyntaxKind.KOneway;
				yield return SoalTokensSyntaxKind.KReturn;
				yield return SoalTokensSyntaxKind.KBinding;
				yield return SoalTokensSyntaxKind.KTransport;
				yield return SoalTokensSyntaxKind.KEncoding;
				yield return SoalTokensSyntaxKind.KProtocol;
				yield return SoalTokensSyntaxKind.KEndpoint;
				yield return SoalTokensSyntaxKind.KAddress;
				yield return SoalTokensSyntaxKind.KDatabase;
				yield return SoalTokensSyntaxKind.KEntity;
				yield return SoalTokensSyntaxKind.KAbstract;
				yield return SoalTokensSyntaxKind.KComponent;
				yield return SoalTokensSyntaxKind.KComposite;
				yield return SoalTokensSyntaxKind.KReference;
				yield return SoalTokensSyntaxKind.KService;
				yield return SoalTokensSyntaxKind.KWire;
				yield return SoalTokensSyntaxKind.KTo;
				yield return SoalTokensSyntaxKind.KImplementation;
				yield return SoalTokensSyntaxKind.KLanguage;
				yield return SoalTokensSyntaxKind.KAssembly;
				yield return SoalTokensSyntaxKind.KDeployment;
				yield return SoalTokensSyntaxKind.KEnvironment;
				yield return SoalTokensSyntaxKind.KRuntime;
				yield return SoalTokensSyntaxKind.KNull;
				yield return SoalTokensSyntaxKind.KTrue;
				yield return SoalTokensSyntaxKind.KFalse;
				yield return SoalTokensSyntaxKind.KObject;
				yield return SoalTokensSyntaxKind.KString;
				yield return SoalTokensSyntaxKind.KInt;
				yield return SoalTokensSyntaxKind.KLong;
				yield return SoalTokensSyntaxKind.KFloat;
				yield return SoalTokensSyntaxKind.KDouble;
				yield return SoalTokensSyntaxKind.KByte;
				yield return SoalTokensSyntaxKind.KBool;
				yield return SoalTokensSyntaxKind.KAny;
				yield return SoalTokensSyntaxKind.KTypeof;
				yield return SoalTokensSyntaxKind.KVoid;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return SoalTokensSyntaxKind.KNamespace;
				case "enum":
					return SoalTokensSyntaxKind.KEnum;
				case "exception":
					return SoalTokensSyntaxKind.KException;
				case "struct":
					return SoalTokensSyntaxKind.KStruct;
				case "interface":
					return SoalTokensSyntaxKind.KInterface;
				case "throws":
					return SoalTokensSyntaxKind.KThrows;
				case "oneway":
					return SoalTokensSyntaxKind.KOneway;
				case "return":
					return SoalTokensSyntaxKind.KReturn;
				case "binding":
					return SoalTokensSyntaxKind.KBinding;
				case "transport":
					return SoalTokensSyntaxKind.KTransport;
				case "encoding":
					return SoalTokensSyntaxKind.KEncoding;
				case "protocol":
					return SoalTokensSyntaxKind.KProtocol;
				case "endpoint":
					return SoalTokensSyntaxKind.KEndpoint;
				case "address":
					return SoalTokensSyntaxKind.KAddress;
				case "database":
					return SoalTokensSyntaxKind.KDatabase;
				case "entity":
					return SoalTokensSyntaxKind.KEntity;
				case "abstract":
					return SoalTokensSyntaxKind.KAbstract;
				case "component":
					return SoalTokensSyntaxKind.KComponent;
				case "composite":
					return SoalTokensSyntaxKind.KComposite;
				case "reference":
					return SoalTokensSyntaxKind.KReference;
				case "service":
					return SoalTokensSyntaxKind.KService;
				case "wire":
					return SoalTokensSyntaxKind.KWire;
				case "to":
					return SoalTokensSyntaxKind.KTo;
				case "implementation":
					return SoalTokensSyntaxKind.KImplementation;
				case "language":
					return SoalTokensSyntaxKind.KLanguage;
				case "assembly":
					return SoalTokensSyntaxKind.KAssembly;
				case "deployment":
					return SoalTokensSyntaxKind.KDeployment;
				case "environment":
					return SoalTokensSyntaxKind.KEnvironment;
				case "runtime":
					return SoalTokensSyntaxKind.KRuntime;
				case "null":
					return SoalTokensSyntaxKind.KNull;
				case "true":
					return SoalTokensSyntaxKind.KTrue;
				case "false":
					return SoalTokensSyntaxKind.KFalse;
				case "object":
					return SoalTokensSyntaxKind.KObject;
				case "string":
					return SoalTokensSyntaxKind.KString;
				case "int":
					return SoalTokensSyntaxKind.KInt;
				case "long":
					return SoalTokensSyntaxKind.KLong;
				case "float":
					return SoalTokensSyntaxKind.KFloat;
				case "double":
					return SoalTokensSyntaxKind.KDouble;
				case "byte":
					return SoalTokensSyntaxKind.KByte;
				case "bool":
					return SoalTokensSyntaxKind.KBool;
				case "any":
					return SoalTokensSyntaxKind.KAny;
				case "typeof":
					return SoalTokensSyntaxKind.KTypeof;
				case "void":
					return SoalTokensSyntaxKind.KVoid;
				default:
					return SyntaxKind.None;
			}
        }
		public override bool IsContextualKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetContextualKeywordKinds()
        {
			yield break;
        }

        public override SyntaxKind GetContextualKeywordKind(string text)
        {
			switch(text)
			{
				default:
					return SyntaxKind.None;
			}
        }
		public override bool IsPreprocessorKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsPreprocessorContextualKeyword(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsPreprocessorDirective(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsIdentifier(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SoalTokensSyntaxKind.IdentifierNormal:
					return true;
				case SoalTokensSyntaxKind.IdentifierVerbatim:
					return true;
				default:
					return false;
			}
		}
		public override bool IsGeneralCommentTrivia(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public override bool IsDocumentationCommentTrivia(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public bool IsNumber(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SoalTokensSyntaxKind.LInteger:
					return true;
				case SoalTokensSyntaxKind.LDecimal:
					return true;
				case SoalTokensSyntaxKind.LScientific:
					return true;
				case SoalTokensSyntaxKind.LDateTimeOffset:
					return true;
				case SoalTokensSyntaxKind.LDateTime:
					return true;
				case SoalTokensSyntaxKind.LDate:
					return true;
				case SoalTokensSyntaxKind.LTime:
					return true;
				default:
					return false;
			}
		}
		public override bool IsExternAliasDirective(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				default:
					return false;
			}
		}
		public bool IsString(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SoalTokensSyntaxKind.LRegularString:
					return true;
				case SoalTokensSyntaxKind.LGuid:
					return true;
				case SoalTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case SoalTokensSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SoalTokensSyntaxKind.LUtf8Bom:
					return true;
				case SoalTokensSyntaxKind.LWhiteSpace:
					return true;
				case SoalTokensSyntaxKind.LCrLf:
					return true;
				case SoalTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case SoalTokensSyntaxKind.LSingleLineComment:
					return true;
				case SoalTokensSyntaxKind.LMultiLineComment:
					return true;
				default:
					return false;
			}
		}
	}
}

