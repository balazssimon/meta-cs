using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

namespace MetaDslx.VisualStudio.Soal.Syntax
{
	public enum SoalTokenKind : int
	{
		None = 0,
		Comment,
		Identifier,
		Keyword,
		Number,
		String,
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

	public class SoalSyntaxFacts : SyntaxFacts
	{
		public static readonly SoalSyntaxFacts Instance = new SoalSyntaxFacts();

		protected override int DefaultEndOfLineSyntaxKindCore
		{
			get { return (int)SoalSyntaxKind.LCrLf; }
		}

		protected override int DefaultWhitespaceSyntaxKindCore
		{
			get { return (int)SoalSyntaxKind.LWhiteSpace; }
		}

		public override bool IsToken(int rawKind)
		{
			return this.IsToken((SoalSyntaxKind)rawKind);
		}

		public bool IsToken(SoalSyntaxKind kind)
		{
			switch (kind)
			{
				case SoalSyntaxKind.Eof:
				case SoalSyntaxKind.KNamespace:
				case SoalSyntaxKind.KEnum:
				case SoalSyntaxKind.KException:
				case SoalSyntaxKind.KStruct:
				case SoalSyntaxKind.KInterface:
				case SoalSyntaxKind.KThrows:
				case SoalSyntaxKind.KOneway:
				case SoalSyntaxKind.KReturn:
				case SoalSyntaxKind.KBinding:
				case SoalSyntaxKind.KTransport:
				case SoalSyntaxKind.KEncoding:
				case SoalSyntaxKind.KProtocol:
				case SoalSyntaxKind.KEndpoint:
				case SoalSyntaxKind.KAddress:
				case SoalSyntaxKind.KDatabase:
				case SoalSyntaxKind.KEntity:
				case SoalSyntaxKind.KAbstract:
				case SoalSyntaxKind.KComponent:
				case SoalSyntaxKind.KComposite:
				case SoalSyntaxKind.KReference:
				case SoalSyntaxKind.KService:
				case SoalSyntaxKind.KWire:
				case SoalSyntaxKind.KTo:
				case SoalSyntaxKind.KImplementation:
				case SoalSyntaxKind.KLanguage:
				case SoalSyntaxKind.KAssembly:
				case SoalSyntaxKind.KDeployment:
				case SoalSyntaxKind.KEnvironment:
				case SoalSyntaxKind.KRuntime:
				case SoalSyntaxKind.KNull:
				case SoalSyntaxKind.KTrue:
				case SoalSyntaxKind.KFalse:
				case SoalSyntaxKind.KObject:
				case SoalSyntaxKind.KString:
				case SoalSyntaxKind.KInt:
				case SoalSyntaxKind.KLong:
				case SoalSyntaxKind.KFloat:
				case SoalSyntaxKind.KDouble:
				case SoalSyntaxKind.KByte:
				case SoalSyntaxKind.KBool:
				case SoalSyntaxKind.KAny:
				case SoalSyntaxKind.KTypeof:
				case SoalSyntaxKind.KVoid:
				case SoalSyntaxKind.TSemicolon:
				case SoalSyntaxKind.TColon:
				case SoalSyntaxKind.TDot:
				case SoalSyntaxKind.TComma:
				case SoalSyntaxKind.TAssign:
				case SoalSyntaxKind.TOpenParen:
				case SoalSyntaxKind.TCloseParen:
				case SoalSyntaxKind.TOpenBracket:
				case SoalSyntaxKind.TCloseBracket:
				case SoalSyntaxKind.TOpenBrace:
				case SoalSyntaxKind.TCloseBrace:
				case SoalSyntaxKind.TLessThan:
				case SoalSyntaxKind.TGreaterThan:
				case SoalSyntaxKind.TQuestion:
				case SoalSyntaxKind.TQuestionQuestion:
				case SoalSyntaxKind.TAmpersand:
				case SoalSyntaxKind.THat:
				case SoalSyntaxKind.TBar:
				case SoalSyntaxKind.TAndAlso:
				case SoalSyntaxKind.TOrElse:
				case SoalSyntaxKind.TPlusPlus:
				case SoalSyntaxKind.TMinusMinus:
				case SoalSyntaxKind.TPlus:
				case SoalSyntaxKind.TMinus:
				case SoalSyntaxKind.TTilde:
				case SoalSyntaxKind.TExclamation:
				case SoalSyntaxKind.TSlash:
				case SoalSyntaxKind.TAsterisk:
				case SoalSyntaxKind.TPercent:
				case SoalSyntaxKind.TLessThanOrEqual:
				case SoalSyntaxKind.TGreaterThanOrEqual:
				case SoalSyntaxKind.TEqual:
				case SoalSyntaxKind.TNotEqual:
				case SoalSyntaxKind.TAsteriskAssign:
				case SoalSyntaxKind.TSlashAssign:
				case SoalSyntaxKind.TPercentAssign:
				case SoalSyntaxKind.TPlusAssign:
				case SoalSyntaxKind.TMinusAssign:
				case SoalSyntaxKind.TLeftShiftAssign:
				case SoalSyntaxKind.TRightShiftAssign:
				case SoalSyntaxKind.TAmpersandAssign:
				case SoalSyntaxKind.THatAssign:
				case SoalSyntaxKind.TBarAssign:
				case SoalSyntaxKind.IDate:
				case SoalSyntaxKind.ITime:
				case SoalSyntaxKind.IDateTime:
				case SoalSyntaxKind.ITimeSpan:
				case SoalSyntaxKind.IVersion:
				case SoalSyntaxKind.IStyle:
				case SoalSyntaxKind.IMTOM:
				case SoalSyntaxKind.ISSL:
				case SoalSyntaxKind.IHTTP:
				case SoalSyntaxKind.IREST:
				case SoalSyntaxKind.IWebSocket:
				case SoalSyntaxKind.ISOAP:
				case SoalSyntaxKind.IXML:
				case SoalSyntaxKind.IJSON:
				case SoalSyntaxKind.IClientAuthentication:
				case SoalSyntaxKind.IWsAddressing:
				case SoalSyntaxKind.IdentifierNormal:
				case SoalSyntaxKind.IdentifierVerbatim:
				case SoalSyntaxKind.LInteger:
				case SoalSyntaxKind.LDecimal:
				case SoalSyntaxKind.LScientific:
				case SoalSyntaxKind.LDateTimeOffset:
				case SoalSyntaxKind.LDateTime:
				case SoalSyntaxKind.LDate:
				case SoalSyntaxKind.LTime:
				case SoalSyntaxKind.LRegularString:
				case SoalSyntaxKind.LGuid:
				case SoalSyntaxKind.LUtf8Bom:
				case SoalSyntaxKind.LWhiteSpace:
				case SoalSyntaxKind.LCrLf:
				case SoalSyntaxKind.LLineEnd:
				case SoalSyntaxKind.LSingleLineComment:
				case SoalSyntaxKind.LMultiLineComment:
				case SoalSyntaxKind.LDoubleQuoteVerbatimString:
				case SoalSyntaxKind.LSingleQuoteVerbatimString:
				case SoalSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case SoalSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case SoalSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(int rawKind)
		{
			return this.IsFixedToken((SoalSyntaxKind)rawKind);
		}

		public bool IsFixedToken(SoalSyntaxKind kind)
		{
			switch (kind)
			{
				case SoalSyntaxKind.Eof:
				case SoalSyntaxKind.KNamespace:
				case SoalSyntaxKind.KEnum:
				case SoalSyntaxKind.KException:
				case SoalSyntaxKind.KStruct:
				case SoalSyntaxKind.KInterface:
				case SoalSyntaxKind.KThrows:
				case SoalSyntaxKind.KOneway:
				case SoalSyntaxKind.KReturn:
				case SoalSyntaxKind.KBinding:
				case SoalSyntaxKind.KTransport:
				case SoalSyntaxKind.KEncoding:
				case SoalSyntaxKind.KProtocol:
				case SoalSyntaxKind.KEndpoint:
				case SoalSyntaxKind.KAddress:
				case SoalSyntaxKind.KDatabase:
				case SoalSyntaxKind.KEntity:
				case SoalSyntaxKind.KAbstract:
				case SoalSyntaxKind.KComponent:
				case SoalSyntaxKind.KComposite:
				case SoalSyntaxKind.KReference:
				case SoalSyntaxKind.KService:
				case SoalSyntaxKind.KWire:
				case SoalSyntaxKind.KTo:
				case SoalSyntaxKind.KImplementation:
				case SoalSyntaxKind.KLanguage:
				case SoalSyntaxKind.KAssembly:
				case SoalSyntaxKind.KDeployment:
				case SoalSyntaxKind.KEnvironment:
				case SoalSyntaxKind.KRuntime:
				case SoalSyntaxKind.KNull:
				case SoalSyntaxKind.KTrue:
				case SoalSyntaxKind.KFalse:
				case SoalSyntaxKind.KObject:
				case SoalSyntaxKind.KString:
				case SoalSyntaxKind.KInt:
				case SoalSyntaxKind.KLong:
				case SoalSyntaxKind.KFloat:
				case SoalSyntaxKind.KDouble:
				case SoalSyntaxKind.KByte:
				case SoalSyntaxKind.KBool:
				case SoalSyntaxKind.KAny:
				case SoalSyntaxKind.KTypeof:
				case SoalSyntaxKind.KVoid:
				case SoalSyntaxKind.TSemicolon:
				case SoalSyntaxKind.TColon:
				case SoalSyntaxKind.TDot:
				case SoalSyntaxKind.TComma:
				case SoalSyntaxKind.TAssign:
				case SoalSyntaxKind.TOpenParen:
				case SoalSyntaxKind.TCloseParen:
				case SoalSyntaxKind.TOpenBracket:
				case SoalSyntaxKind.TCloseBracket:
				case SoalSyntaxKind.TOpenBrace:
				case SoalSyntaxKind.TCloseBrace:
				case SoalSyntaxKind.TLessThan:
				case SoalSyntaxKind.TGreaterThan:
				case SoalSyntaxKind.TQuestion:
				case SoalSyntaxKind.TQuestionQuestion:
				case SoalSyntaxKind.TAmpersand:
				case SoalSyntaxKind.THat:
				case SoalSyntaxKind.TBar:
				case SoalSyntaxKind.TAndAlso:
				case SoalSyntaxKind.TOrElse:
				case SoalSyntaxKind.TPlusPlus:
				case SoalSyntaxKind.TMinusMinus:
				case SoalSyntaxKind.TPlus:
				case SoalSyntaxKind.TMinus:
				case SoalSyntaxKind.TTilde:
				case SoalSyntaxKind.TExclamation:
				case SoalSyntaxKind.TSlash:
				case SoalSyntaxKind.TPercent:
				case SoalSyntaxKind.TLessThanOrEqual:
				case SoalSyntaxKind.TGreaterThanOrEqual:
				case SoalSyntaxKind.TEqual:
				case SoalSyntaxKind.TNotEqual:
				case SoalSyntaxKind.TAsteriskAssign:
				case SoalSyntaxKind.TSlashAssign:
				case SoalSyntaxKind.TPercentAssign:
				case SoalSyntaxKind.TPlusAssign:
				case SoalSyntaxKind.TMinusAssign:
				case SoalSyntaxKind.TLeftShiftAssign:
				case SoalSyntaxKind.TRightShiftAssign:
				case SoalSyntaxKind.TAmpersandAssign:
				case SoalSyntaxKind.THatAssign:
				case SoalSyntaxKind.TBarAssign:
				case SoalSyntaxKind.IDate:
				case SoalSyntaxKind.ITime:
				case SoalSyntaxKind.IDateTime:
				case SoalSyntaxKind.ITimeSpan:
				case SoalSyntaxKind.IVersion:
				case SoalSyntaxKind.IStyle:
				case SoalSyntaxKind.IMTOM:
				case SoalSyntaxKind.ISSL:
				case SoalSyntaxKind.IHTTP:
				case SoalSyntaxKind.IREST:
				case SoalSyntaxKind.IWebSocket:
				case SoalSyntaxKind.ISOAP:
				case SoalSyntaxKind.IXML:
				case SoalSyntaxKind.IJSON:
				case SoalSyntaxKind.IClientAuthentication:
				case SoalSyntaxKind.IWsAddressing:
				case SoalSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case SoalSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case SoalSyntaxKind.LCommentStart:
				case SoalSyntaxKind.LDoubleQuoteVerbatimString:
				case SoalSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}

		public override string GetText(int rawKind)
		{
			return this.GetText((SoalSyntaxKind)rawKind);
		}

		public string GetText(SoalSyntaxKind kind)
		{
			switch (kind)
			{
				case SoalSyntaxKind.KNamespace:
					return "namespace";
				case SoalSyntaxKind.KEnum:
					return "enum";
				case SoalSyntaxKind.KException:
					return "exception";
				case SoalSyntaxKind.KStruct:
					return "struct";
				case SoalSyntaxKind.KInterface:
					return "interface";
				case SoalSyntaxKind.KThrows:
					return "throws";
				case SoalSyntaxKind.KOneway:
					return "oneway";
				case SoalSyntaxKind.KReturn:
					return "return";
				case SoalSyntaxKind.KBinding:
					return "binding";
				case SoalSyntaxKind.KTransport:
					return "transport";
				case SoalSyntaxKind.KEncoding:
					return "encoding";
				case SoalSyntaxKind.KProtocol:
					return "protocol";
				case SoalSyntaxKind.KEndpoint:
					return "endpoint";
				case SoalSyntaxKind.KAddress:
					return "address";
				case SoalSyntaxKind.KDatabase:
					return "database";
				case SoalSyntaxKind.KEntity:
					return "entity";
				case SoalSyntaxKind.KAbstract:
					return "abstract";
				case SoalSyntaxKind.KComponent:
					return "component";
				case SoalSyntaxKind.KComposite:
					return "composite";
				case SoalSyntaxKind.KReference:
					return "reference";
				case SoalSyntaxKind.KService:
					return "service";
				case SoalSyntaxKind.KWire:
					return "wire";
				case SoalSyntaxKind.KTo:
					return "to";
				case SoalSyntaxKind.KImplementation:
					return "implementation";
				case SoalSyntaxKind.KLanguage:
					return "language";
				case SoalSyntaxKind.KAssembly:
					return "assembly";
				case SoalSyntaxKind.KDeployment:
					return "deployment";
				case SoalSyntaxKind.KEnvironment:
					return "environment";
				case SoalSyntaxKind.KRuntime:
					return "runtime";
				case SoalSyntaxKind.KNull:
					return "null";
				case SoalSyntaxKind.KTrue:
					return "true";
				case SoalSyntaxKind.KFalse:
					return "false";
				case SoalSyntaxKind.KObject:
					return "object";
				case SoalSyntaxKind.KString:
					return "string";
				case SoalSyntaxKind.KInt:
					return "int";
				case SoalSyntaxKind.KLong:
					return "long";
				case SoalSyntaxKind.KFloat:
					return "float";
				case SoalSyntaxKind.KDouble:
					return "double";
				case SoalSyntaxKind.KByte:
					return "byte";
				case SoalSyntaxKind.KBool:
					return "bool";
				case SoalSyntaxKind.KAny:
					return "any";
				case SoalSyntaxKind.KTypeof:
					return "typeof";
				case SoalSyntaxKind.KVoid:
					return "void";
				case SoalSyntaxKind.TSemicolon:
					return ";";
				case SoalSyntaxKind.TColon:
					return ":";
				case SoalSyntaxKind.TDot:
					return ".";
				case SoalSyntaxKind.TComma:
					return ",";
				case SoalSyntaxKind.TAssign:
					return "=";
				case SoalSyntaxKind.TOpenParen:
					return "(";
				case SoalSyntaxKind.TCloseParen:
					return ")";
				case SoalSyntaxKind.TOpenBracket:
					return "[";
				case SoalSyntaxKind.TCloseBracket:
					return "]";
				case SoalSyntaxKind.TOpenBrace:
					return "{";
				case SoalSyntaxKind.TCloseBrace:
					return "}";
				case SoalSyntaxKind.TLessThan:
					return "<";
				case SoalSyntaxKind.TGreaterThan:
					return ">";
				case SoalSyntaxKind.TQuestion:
					return "?";
				case SoalSyntaxKind.TQuestionQuestion:
					return "??";
				case SoalSyntaxKind.TAmpersand:
					return "&";
				case SoalSyntaxKind.THat:
					return "^";
				case SoalSyntaxKind.TBar:
					return "|";
				case SoalSyntaxKind.TAndAlso:
					return "&&";
				case SoalSyntaxKind.TOrElse:
					return "||";
				case SoalSyntaxKind.TPlusPlus:
					return "++";
				case SoalSyntaxKind.TMinusMinus:
					return "--";
				case SoalSyntaxKind.TPlus:
					return "+";
				case SoalSyntaxKind.TMinus:
					return "-";
				case SoalSyntaxKind.TTilde:
					return "~";
				case SoalSyntaxKind.TExclamation:
					return "!";
				case SoalSyntaxKind.TSlash:
					return "/";
				case SoalSyntaxKind.TPercent:
					return "%";
				case SoalSyntaxKind.TLessThanOrEqual:
					return "<=";
				case SoalSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case SoalSyntaxKind.TEqual:
					return "==";
				case SoalSyntaxKind.TNotEqual:
					return "!=";
				case SoalSyntaxKind.TAsteriskAssign:
					return "*=";
				case SoalSyntaxKind.TSlashAssign:
					return "/=";
				case SoalSyntaxKind.TPercentAssign:
					return "%=";
				case SoalSyntaxKind.TPlusAssign:
					return "+=";
				case SoalSyntaxKind.TMinusAssign:
					return "-=";
				case SoalSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case SoalSyntaxKind.TRightShiftAssign:
					return ">>=";
				case SoalSyntaxKind.TAmpersandAssign:
					return "&=";
				case SoalSyntaxKind.THatAssign:
					return "^=";
				case SoalSyntaxKind.TBarAssign:
					return "|=";
				case SoalSyntaxKind.IDate:
					return "Date";
				case SoalSyntaxKind.ITime:
					return "Time";
				case SoalSyntaxKind.IDateTime:
					return "DateTime";
				case SoalSyntaxKind.ITimeSpan:
					return "TimeSpan";
				case SoalSyntaxKind.IVersion:
					return "Version";
				case SoalSyntaxKind.IStyle:
					return "Style";
				case SoalSyntaxKind.IMTOM:
					return "MTOM";
				case SoalSyntaxKind.ISSL:
					return "SSL";
				case SoalSyntaxKind.IHTTP:
					return "HTTP";
				case SoalSyntaxKind.IREST:
					return "REST";
				case SoalSyntaxKind.IWebSocket:
					return "WebSocket";
				case SoalSyntaxKind.ISOAP:
					return "SOAP";
				case SoalSyntaxKind.IXML:
					return "XML";
				case SoalSyntaxKind.IJSON:
					return "JSON";
				case SoalSyntaxKind.IClientAuthentication:
					return "ClientAuthentication";
				case SoalSyntaxKind.IWsAddressing:
					return "WsAddressing";
				case SoalSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case SoalSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case SoalSyntaxKind.LCommentStart:
					return "/*";
				case SoalSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case SoalSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public SoalSyntaxKind GetKind(string text)
		{
			switch (text)
			{
				case "namespace":
					return SoalSyntaxKind.KNamespace;
				case "enum":
					return SoalSyntaxKind.KEnum;
				case "exception":
					return SoalSyntaxKind.KException;
				case "struct":
					return SoalSyntaxKind.KStruct;
				case "interface":
					return SoalSyntaxKind.KInterface;
				case "throws":
					return SoalSyntaxKind.KThrows;
				case "oneway":
					return SoalSyntaxKind.KOneway;
				case "return":
					return SoalSyntaxKind.KReturn;
				case "binding":
					return SoalSyntaxKind.KBinding;
				case "transport":
					return SoalSyntaxKind.KTransport;
				case "encoding":
					return SoalSyntaxKind.KEncoding;
				case "protocol":
					return SoalSyntaxKind.KProtocol;
				case "endpoint":
					return SoalSyntaxKind.KEndpoint;
				case "address":
					return SoalSyntaxKind.KAddress;
				case "database":
					return SoalSyntaxKind.KDatabase;
				case "entity":
					return SoalSyntaxKind.KEntity;
				case "abstract":
					return SoalSyntaxKind.KAbstract;
				case "component":
					return SoalSyntaxKind.KComponent;
				case "composite":
					return SoalSyntaxKind.KComposite;
				case "reference":
					return SoalSyntaxKind.KReference;
				case "service":
					return SoalSyntaxKind.KService;
				case "wire":
					return SoalSyntaxKind.KWire;
				case "to":
					return SoalSyntaxKind.KTo;
				case "implementation":
					return SoalSyntaxKind.KImplementation;
				case "language":
					return SoalSyntaxKind.KLanguage;
				case "assembly":
					return SoalSyntaxKind.KAssembly;
				case "deployment":
					return SoalSyntaxKind.KDeployment;
				case "environment":
					return SoalSyntaxKind.KEnvironment;
				case "runtime":
					return SoalSyntaxKind.KRuntime;
				case "null":
					return SoalSyntaxKind.KNull;
				case "true":
					return SoalSyntaxKind.KTrue;
				case "false":
					return SoalSyntaxKind.KFalse;
				case "object":
					return SoalSyntaxKind.KObject;
				case "string":
					return SoalSyntaxKind.KString;
				case "int":
					return SoalSyntaxKind.KInt;
				case "long":
					return SoalSyntaxKind.KLong;
				case "float":
					return SoalSyntaxKind.KFloat;
				case "double":
					return SoalSyntaxKind.KDouble;
				case "byte":
					return SoalSyntaxKind.KByte;
				case "bool":
					return SoalSyntaxKind.KBool;
				case "any":
					return SoalSyntaxKind.KAny;
				case "typeof":
					return SoalSyntaxKind.KTypeof;
				case "void":
					return SoalSyntaxKind.KVoid;
				case ";":
					return SoalSyntaxKind.TSemicolon;
				case ":":
					return SoalSyntaxKind.TColon;
				case ".":
					return SoalSyntaxKind.TDot;
				case ",":
					return SoalSyntaxKind.TComma;
				case "=":
					return SoalSyntaxKind.TAssign;
				case "(":
					return SoalSyntaxKind.TOpenParen;
				case ")":
					return SoalSyntaxKind.TCloseParen;
				case "[":
					return SoalSyntaxKind.TOpenBracket;
				case "]":
					return SoalSyntaxKind.TCloseBracket;
				case "{":
					return SoalSyntaxKind.TOpenBrace;
				case "}":
					return SoalSyntaxKind.TCloseBrace;
				case "<":
					return SoalSyntaxKind.TLessThan;
				case ">":
					return SoalSyntaxKind.TGreaterThan;
				case "?":
					return SoalSyntaxKind.TQuestion;
				case "??":
					return SoalSyntaxKind.TQuestionQuestion;
				case "&":
					return SoalSyntaxKind.TAmpersand;
				case "^":
					return SoalSyntaxKind.THat;
				case "|":
					return SoalSyntaxKind.TBar;
				case "&&":
					return SoalSyntaxKind.TAndAlso;
				case "||":
					return SoalSyntaxKind.TOrElse;
				case "++":
					return SoalSyntaxKind.TPlusPlus;
				case "--":
					return SoalSyntaxKind.TMinusMinus;
				case "+":
					return SoalSyntaxKind.TPlus;
				case "-":
					return SoalSyntaxKind.TMinus;
				case "~":
					return SoalSyntaxKind.TTilde;
				case "!":
					return SoalSyntaxKind.TExclamation;
				case "/":
					return SoalSyntaxKind.TSlash;
				case "%":
					return SoalSyntaxKind.TPercent;
				case "<=":
					return SoalSyntaxKind.TLessThanOrEqual;
				case ">=":
					return SoalSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return SoalSyntaxKind.TEqual;
				case "!=":
					return SoalSyntaxKind.TNotEqual;
				case "*=":
					return SoalSyntaxKind.TAsteriskAssign;
				case "/=":
					return SoalSyntaxKind.TSlashAssign;
				case "%=":
					return SoalSyntaxKind.TPercentAssign;
				case "+=":
					return SoalSyntaxKind.TPlusAssign;
				case "-=":
					return SoalSyntaxKind.TMinusAssign;
				case "<<=":
					return SoalSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return SoalSyntaxKind.TRightShiftAssign;
				case "&=":
					return SoalSyntaxKind.TAmpersandAssign;
				case "^=":
					return SoalSyntaxKind.THatAssign;
				case "|=":
					return SoalSyntaxKind.TBarAssign;
				case "Date":
					return SoalSyntaxKind.IDate;
				case "Time":
					return SoalSyntaxKind.ITime;
				case "DateTime":
					return SoalSyntaxKind.IDateTime;
				case "TimeSpan":
					return SoalSyntaxKind.ITimeSpan;
				case "Version":
					return SoalSyntaxKind.IVersion;
				case "Style":
					return SoalSyntaxKind.IStyle;
				case "MTOM":
					return SoalSyntaxKind.IMTOM;
				case "SSL":
					return SoalSyntaxKind.ISSL;
				case "HTTP":
					return SoalSyntaxKind.IHTTP;
				case "REST":
					return SoalSyntaxKind.IREST;
				case "WebSocket":
					return SoalSyntaxKind.IWebSocket;
				case "SOAP":
					return SoalSyntaxKind.ISOAP;
				case "XML":
					return SoalSyntaxKind.IXML;
				case "JSON":
					return SoalSyntaxKind.IJSON;
				case "ClientAuthentication":
					return SoalSyntaxKind.IClientAuthentication;
				case "WsAddressing":
					return SoalSyntaxKind.IWsAddressing;
				case "@\"":
					return SoalSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return SoalSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return SoalSyntaxKind.LCommentStart;
				case "\"":
					return SoalSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return SoalSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return SoalSyntaxKind.None;
			}
		}

		public override string GetKindText(int rawKind)
		{
			return this.GetKindText((SoalSyntaxKind)rawKind);
		}

		public string GetKindText(SoalSyntaxKind kind)
		{
			return kind.ToString();
		}

		public override bool IsTriviaWithEndOfLine(int rawKind)
		{
			return this.IsTriviaWithEndOfLine((SoalSyntaxKind)rawKind);
		}

		public bool IsTriviaWithEndOfLine(SoalSyntaxKind kind)
		{
			switch(kind)
			{
				case SoalSyntaxKind.LCrLf:
					return true;
				case SoalSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}

		public bool IsKeyword(int rawKind)
		{
			return this.IsKeyword((SoalSyntaxKind)rawKind);
		}

		public bool IsKeyword(SoalSyntaxKind kind)
		{
			switch(kind)
			{
				case SoalSyntaxKind.KNamespace:
				case SoalSyntaxKind.KEnum:
				case SoalSyntaxKind.KException:
				case SoalSyntaxKind.KStruct:
				case SoalSyntaxKind.KInterface:
				case SoalSyntaxKind.KThrows:
				case SoalSyntaxKind.KOneway:
				case SoalSyntaxKind.KReturn:
				case SoalSyntaxKind.KBinding:
				case SoalSyntaxKind.KTransport:
				case SoalSyntaxKind.KEncoding:
				case SoalSyntaxKind.KProtocol:
				case SoalSyntaxKind.KEndpoint:
				case SoalSyntaxKind.KAddress:
				case SoalSyntaxKind.KDatabase:
				case SoalSyntaxKind.KEntity:
				case SoalSyntaxKind.KAbstract:
				case SoalSyntaxKind.KComponent:
				case SoalSyntaxKind.KComposite:
				case SoalSyntaxKind.KReference:
				case SoalSyntaxKind.KService:
				case SoalSyntaxKind.KWire:
				case SoalSyntaxKind.KTo:
				case SoalSyntaxKind.KImplementation:
				case SoalSyntaxKind.KLanguage:
				case SoalSyntaxKind.KAssembly:
				case SoalSyntaxKind.KDeployment:
				case SoalSyntaxKind.KEnvironment:
				case SoalSyntaxKind.KRuntime:
				case SoalSyntaxKind.KNull:
				case SoalSyntaxKind.KTrue:
				case SoalSyntaxKind.KFalse:
				case SoalSyntaxKind.KObject:
				case SoalSyntaxKind.KString:
				case SoalSyntaxKind.KInt:
				case SoalSyntaxKind.KLong:
				case SoalSyntaxKind.KFloat:
				case SoalSyntaxKind.KDouble:
				case SoalSyntaxKind.KByte:
				case SoalSyntaxKind.KBool:
				case SoalSyntaxKind.KAny:
				case SoalSyntaxKind.KTypeof:
				case SoalSyntaxKind.KVoid:
					return true;
				default:
					return false;
			}
		}
		public bool IsIdentifier(int rawKind)
		{
			return this.IsIdentifier((SoalSyntaxKind)rawKind);
		}

		public bool IsIdentifier(SoalSyntaxKind kind)
		{
			switch(kind)
			{
				case SoalSyntaxKind.IdentifierNormal:
					return true;
				case SoalSyntaxKind.IdentifierVerbatim:
					return true;
				default:
					return false;
			}
		}
		public bool IsNumber(int rawKind)
		{
			return this.IsNumber((SoalSyntaxKind)rawKind);
		}

		public bool IsNumber(SoalSyntaxKind kind)
		{
			switch(kind)
			{
				case SoalSyntaxKind.LInteger:
					return true;
				case SoalSyntaxKind.LDecimal:
					return true;
				case SoalSyntaxKind.LScientific:
					return true;
				case SoalSyntaxKind.LDateTimeOffset:
					return true;
				case SoalSyntaxKind.LDateTime:
					return true;
				case SoalSyntaxKind.LDate:
					return true;
				case SoalSyntaxKind.LTime:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(int rawKind)
		{
			return this.IsString((SoalSyntaxKind)rawKind);
		}

		public bool IsString(SoalSyntaxKind kind)
		{
			switch(kind)
			{
				case SoalSyntaxKind.LRegularString:
					return true;
				case SoalSyntaxKind.LGuid:
					return true;
				case SoalSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case SoalSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(int rawKind)
		{
			return this.IsWhitespace((SoalSyntaxKind)rawKind);
		}

		public bool IsWhitespace(SoalSyntaxKind kind)
		{
			switch(kind)
			{
				case SoalSyntaxKind.LUtf8Bom:
					return true;
				case SoalSyntaxKind.LWhiteSpace:
					return true;
				case SoalSyntaxKind.LCrLf:
					return true;
				case SoalSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsComment(int rawKind)
		{
			return this.IsComment((SoalSyntaxKind)rawKind);
		}

		public bool IsComment(SoalSyntaxKind kind)
		{
			switch(kind)
			{
				case SoalSyntaxKind.LSingleLineComment:
					return true;
				case SoalSyntaxKind.LMultiLineComment:
					return true;
				default:
					return false;
			}
		}

		public SoalTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((SoalSyntaxKind)rawKind);
		}

		public SoalTokenKind GetTokenKind(SoalSyntaxKind kind)
		{
			switch(kind)
			{
				case SoalSyntaxKind.KNamespace:
				case SoalSyntaxKind.KEnum:
				case SoalSyntaxKind.KException:
				case SoalSyntaxKind.KStruct:
				case SoalSyntaxKind.KInterface:
				case SoalSyntaxKind.KThrows:
				case SoalSyntaxKind.KOneway:
				case SoalSyntaxKind.KReturn:
				case SoalSyntaxKind.KBinding:
				case SoalSyntaxKind.KTransport:
				case SoalSyntaxKind.KEncoding:
				case SoalSyntaxKind.KProtocol:
				case SoalSyntaxKind.KEndpoint:
				case SoalSyntaxKind.KAddress:
				case SoalSyntaxKind.KDatabase:
				case SoalSyntaxKind.KEntity:
				case SoalSyntaxKind.KAbstract:
				case SoalSyntaxKind.KComponent:
				case SoalSyntaxKind.KComposite:
				case SoalSyntaxKind.KReference:
				case SoalSyntaxKind.KService:
				case SoalSyntaxKind.KWire:
				case SoalSyntaxKind.KTo:
				case SoalSyntaxKind.KImplementation:
				case SoalSyntaxKind.KLanguage:
				case SoalSyntaxKind.KAssembly:
				case SoalSyntaxKind.KDeployment:
				case SoalSyntaxKind.KEnvironment:
				case SoalSyntaxKind.KRuntime:
				case SoalSyntaxKind.KNull:
				case SoalSyntaxKind.KTrue:
				case SoalSyntaxKind.KFalse:
				case SoalSyntaxKind.KObject:
				case SoalSyntaxKind.KString:
				case SoalSyntaxKind.KInt:
				case SoalSyntaxKind.KLong:
				case SoalSyntaxKind.KFloat:
				case SoalSyntaxKind.KDouble:
				case SoalSyntaxKind.KByte:
				case SoalSyntaxKind.KBool:
				case SoalSyntaxKind.KAny:
				case SoalSyntaxKind.KTypeof:
				case SoalSyntaxKind.KVoid:
					return SoalTokenKind.Keyword;
				case SoalSyntaxKind.IdentifierNormal:
					return SoalTokenKind.Identifier;
				case SoalSyntaxKind.IdentifierVerbatim:
					return SoalTokenKind.Identifier;
				case SoalSyntaxKind.LInteger:
					return SoalTokenKind.Number;
				case SoalSyntaxKind.LDecimal:
					return SoalTokenKind.Number;
				case SoalSyntaxKind.LScientific:
					return SoalTokenKind.Number;
				case SoalSyntaxKind.LDateTimeOffset:
					return SoalTokenKind.Number;
				case SoalSyntaxKind.LDateTime:
					return SoalTokenKind.Number;
				case SoalSyntaxKind.LDate:
					return SoalTokenKind.Number;
				case SoalSyntaxKind.LTime:
					return SoalTokenKind.Number;
				case SoalSyntaxKind.LRegularString:
					return SoalTokenKind.String;
				case SoalSyntaxKind.LGuid:
					return SoalTokenKind.String;
				case SoalSyntaxKind.LUtf8Bom:
					return SoalTokenKind.Whitespace;
				case SoalSyntaxKind.LWhiteSpace:
					return SoalTokenKind.Whitespace;
				case SoalSyntaxKind.LCrLf:
					return SoalTokenKind.Whitespace;
				case SoalSyntaxKind.LLineEnd:
					return SoalTokenKind.Whitespace;
				case SoalSyntaxKind.LSingleLineComment:
					return SoalTokenKind.Comment;
				case SoalSyntaxKind.LMultiLineComment:
					return SoalTokenKind.Comment;
				case SoalSyntaxKind.LDoubleQuoteVerbatimString:
					return SoalTokenKind.String;
				case SoalSyntaxKind.LSingleQuoteVerbatimString:
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
					return SoalTokenKind.Comment;
				case SoalLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return SoalTokenKind.String;
				case SoalLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return SoalTokenKind.String;
				default:
					return SoalTokenKind.None;
			}
		}
	}
}

