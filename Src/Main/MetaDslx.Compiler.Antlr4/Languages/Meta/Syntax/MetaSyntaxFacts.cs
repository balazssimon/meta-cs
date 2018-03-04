using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;

namespace MetaDslx.Languages.Meta.Syntax
{
	public enum MetaTokenKind : int
	{
		None = 0,
		Comment,
		Identifier,
		Keyword,
		Number,
		String,
		Whitespace
	}

	public enum MetaLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		LMultilineComment = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class MetaSyntaxFacts : SyntaxFacts
	{
		public static readonly MetaSyntaxFacts Instance = new MetaSyntaxFacts();

		protected override int DefaultEndOfLineSyntaxKindCore
		{
			get { return (int)MetaSyntaxKind.LCrLf; }
		}

		protected override int DefaultWhitespaceSyntaxKindCore
		{
			get { return (int)MetaSyntaxKind.LWhiteSpace; }
		}

		public override bool IsToken(int rawKind)
		{
			return this.IsToken((MetaSyntaxKind)rawKind);
		}

		public bool IsToken(MetaSyntaxKind kind)
		{
			switch (kind)
			{
				case MetaSyntaxKind.Eof:
				case MetaSyntaxKind.KNamespace:
				case MetaSyntaxKind.KUsing:
				case MetaSyntaxKind.KMetamodel:
				case MetaSyntaxKind.KExtern:
				case MetaSyntaxKind.KTypeDef:
				case MetaSyntaxKind.KAbstract:
				case MetaSyntaxKind.KClass:
				case MetaSyntaxKind.KStruct:
				case MetaSyntaxKind.KEnum:
				case MetaSyntaxKind.KAssociation:
				case MetaSyntaxKind.KContainment:
				case MetaSyntaxKind.KWith:
				case MetaSyntaxKind.KNew:
				case MetaSyntaxKind.KNull:
				case MetaSyntaxKind.KTrue:
				case MetaSyntaxKind.KFalse:
				case MetaSyntaxKind.KVoid:
				case MetaSyntaxKind.KObject:
				case MetaSyntaxKind.KSymbol:
				case MetaSyntaxKind.KString:
				case MetaSyntaxKind.KInt:
				case MetaSyntaxKind.KLong:
				case MetaSyntaxKind.KFloat:
				case MetaSyntaxKind.KDouble:
				case MetaSyntaxKind.KByte:
				case MetaSyntaxKind.KBool:
				case MetaSyntaxKind.KList:
				case MetaSyntaxKind.KAny:
				case MetaSyntaxKind.KNone:
				case MetaSyntaxKind.KError:
				case MetaSyntaxKind.KSet:
				case MetaSyntaxKind.KMultiList:
				case MetaSyntaxKind.KMultiSet:
				case MetaSyntaxKind.KThis:
				case MetaSyntaxKind.KTypeof:
				case MetaSyntaxKind.KAs:
				case MetaSyntaxKind.KIs:
				case MetaSyntaxKind.KBase:
				case MetaSyntaxKind.KConst:
				case MetaSyntaxKind.KRedefines:
				case MetaSyntaxKind.KSubsets:
				case MetaSyntaxKind.KReadonly:
				case MetaSyntaxKind.KLazy:
				case MetaSyntaxKind.KSynthetized:
				case MetaSyntaxKind.KInherited:
				case MetaSyntaxKind.KDerived:
				case MetaSyntaxKind.KStatic:
				case MetaSyntaxKind.TSemicolon:
				case MetaSyntaxKind.TColon:
				case MetaSyntaxKind.TDot:
				case MetaSyntaxKind.TComma:
				case MetaSyntaxKind.TAssign:
				case MetaSyntaxKind.TOpenParen:
				case MetaSyntaxKind.TCloseParen:
				case MetaSyntaxKind.TOpenBracket:
				case MetaSyntaxKind.TCloseBracket:
				case MetaSyntaxKind.TOpenBrace:
				case MetaSyntaxKind.TCloseBrace:
				case MetaSyntaxKind.TLessThan:
				case MetaSyntaxKind.TGreaterThan:
				case MetaSyntaxKind.TQuestion:
				case MetaSyntaxKind.TQuestionQuestion:
				case MetaSyntaxKind.TAmpersand:
				case MetaSyntaxKind.THat:
				case MetaSyntaxKind.TBar:
				case MetaSyntaxKind.TAndAlso:
				case MetaSyntaxKind.TOrElse:
				case MetaSyntaxKind.TPlusPlus:
				case MetaSyntaxKind.TMinusMinus:
				case MetaSyntaxKind.TPlus:
				case MetaSyntaxKind.TMinus:
				case MetaSyntaxKind.TTilde:
				case MetaSyntaxKind.TExclamation:
				case MetaSyntaxKind.TSlash:
				case MetaSyntaxKind.TAsterisk:
				case MetaSyntaxKind.TPercent:
				case MetaSyntaxKind.TLessThanOrEqual:
				case MetaSyntaxKind.TGreaterThanOrEqual:
				case MetaSyntaxKind.TEqual:
				case MetaSyntaxKind.TNotEqual:
				case MetaSyntaxKind.TAsteriskAssign:
				case MetaSyntaxKind.TSlashAssign:
				case MetaSyntaxKind.TPercentAssign:
				case MetaSyntaxKind.TPlusAssign:
				case MetaSyntaxKind.TMinusAssign:
				case MetaSyntaxKind.TLeftShiftAssign:
				case MetaSyntaxKind.TRightShiftAssign:
				case MetaSyntaxKind.TAmpersandAssign:
				case MetaSyntaxKind.THatAssign:
				case MetaSyntaxKind.TBarAssign:
				case MetaSyntaxKind.IUri:
				case MetaSyntaxKind.IdentifierNormal:
				case MetaSyntaxKind.IdentifierVerbatim:
				case MetaSyntaxKind.LInteger:
				case MetaSyntaxKind.LDecimal:
				case MetaSyntaxKind.LScientific:
				case MetaSyntaxKind.LDateTimeOffset:
				case MetaSyntaxKind.LDateTime:
				case MetaSyntaxKind.LDate:
				case MetaSyntaxKind.LTime:
				case MetaSyntaxKind.LRegularString:
				case MetaSyntaxKind.LGuid:
				case MetaSyntaxKind.LUtf8Bom:
				case MetaSyntaxKind.LWhiteSpace:
				case MetaSyntaxKind.LCrLf:
				case MetaSyntaxKind.LLineEnd:
				case MetaSyntaxKind.LSingleLineComment:
				case MetaSyntaxKind.LComment:
				case MetaSyntaxKind.LDoubleQuoteVerbatimString:
				case MetaSyntaxKind.LSingleQuoteVerbatimString:
				case MetaSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case MetaSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(int rawKind)
		{
			return this.IsFixedToken((MetaSyntaxKind)rawKind);
		}

		public bool IsFixedToken(MetaSyntaxKind kind)
		{
			switch (kind)
			{
				case MetaSyntaxKind.Eof:
				case MetaSyntaxKind.KNamespace:
				case MetaSyntaxKind.KUsing:
				case MetaSyntaxKind.KMetamodel:
				case MetaSyntaxKind.KExtern:
				case MetaSyntaxKind.KTypeDef:
				case MetaSyntaxKind.KAbstract:
				case MetaSyntaxKind.KClass:
				case MetaSyntaxKind.KStruct:
				case MetaSyntaxKind.KEnum:
				case MetaSyntaxKind.KAssociation:
				case MetaSyntaxKind.KContainment:
				case MetaSyntaxKind.KWith:
				case MetaSyntaxKind.KNew:
				case MetaSyntaxKind.KNull:
				case MetaSyntaxKind.KTrue:
				case MetaSyntaxKind.KFalse:
				case MetaSyntaxKind.KVoid:
				case MetaSyntaxKind.KObject:
				case MetaSyntaxKind.KSymbol:
				case MetaSyntaxKind.KString:
				case MetaSyntaxKind.KInt:
				case MetaSyntaxKind.KLong:
				case MetaSyntaxKind.KFloat:
				case MetaSyntaxKind.KDouble:
				case MetaSyntaxKind.KByte:
				case MetaSyntaxKind.KBool:
				case MetaSyntaxKind.KList:
				case MetaSyntaxKind.KAny:
				case MetaSyntaxKind.KNone:
				case MetaSyntaxKind.KError:
				case MetaSyntaxKind.KSet:
				case MetaSyntaxKind.KMultiList:
				case MetaSyntaxKind.KMultiSet:
				case MetaSyntaxKind.KThis:
				case MetaSyntaxKind.KTypeof:
				case MetaSyntaxKind.KAs:
				case MetaSyntaxKind.KIs:
				case MetaSyntaxKind.KBase:
				case MetaSyntaxKind.KConst:
				case MetaSyntaxKind.KRedefines:
				case MetaSyntaxKind.KSubsets:
				case MetaSyntaxKind.KReadonly:
				case MetaSyntaxKind.KLazy:
				case MetaSyntaxKind.KSynthetized:
				case MetaSyntaxKind.KInherited:
				case MetaSyntaxKind.KDerived:
				case MetaSyntaxKind.KStatic:
				case MetaSyntaxKind.TSemicolon:
				case MetaSyntaxKind.TColon:
				case MetaSyntaxKind.TDot:
				case MetaSyntaxKind.TComma:
				case MetaSyntaxKind.TAssign:
				case MetaSyntaxKind.TOpenParen:
				case MetaSyntaxKind.TCloseParen:
				case MetaSyntaxKind.TOpenBracket:
				case MetaSyntaxKind.TCloseBracket:
				case MetaSyntaxKind.TOpenBrace:
				case MetaSyntaxKind.TCloseBrace:
				case MetaSyntaxKind.TLessThan:
				case MetaSyntaxKind.TGreaterThan:
				case MetaSyntaxKind.TQuestion:
				case MetaSyntaxKind.TQuestionQuestion:
				case MetaSyntaxKind.TAmpersand:
				case MetaSyntaxKind.THat:
				case MetaSyntaxKind.TBar:
				case MetaSyntaxKind.TAndAlso:
				case MetaSyntaxKind.TOrElse:
				case MetaSyntaxKind.TPlusPlus:
				case MetaSyntaxKind.TMinusMinus:
				case MetaSyntaxKind.TPlus:
				case MetaSyntaxKind.TMinus:
				case MetaSyntaxKind.TTilde:
				case MetaSyntaxKind.TExclamation:
				case MetaSyntaxKind.TSlash:
				case MetaSyntaxKind.TPercent:
				case MetaSyntaxKind.TLessThanOrEqual:
				case MetaSyntaxKind.TGreaterThanOrEqual:
				case MetaSyntaxKind.TEqual:
				case MetaSyntaxKind.TNotEqual:
				case MetaSyntaxKind.TAsteriskAssign:
				case MetaSyntaxKind.TSlashAssign:
				case MetaSyntaxKind.TPercentAssign:
				case MetaSyntaxKind.TPlusAssign:
				case MetaSyntaxKind.TMinusAssign:
				case MetaSyntaxKind.TLeftShiftAssign:
				case MetaSyntaxKind.TRightShiftAssign:
				case MetaSyntaxKind.TAmpersandAssign:
				case MetaSyntaxKind.THatAssign:
				case MetaSyntaxKind.TBarAssign:
				case MetaSyntaxKind.IUri:
				case MetaSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case MetaSyntaxKind.LCommentStart:
				case MetaSyntaxKind.LDoubleQuoteVerbatimString:
				case MetaSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}

		public override string GetText(int rawKind)
		{
			return this.GetText((MetaSyntaxKind)rawKind);
		}

		public string GetText(MetaSyntaxKind kind)
		{
			switch (kind)
			{
				case MetaSyntaxKind.KNamespace:
					return "namespace";
				case MetaSyntaxKind.KUsing:
					return "using";
				case MetaSyntaxKind.KMetamodel:
					return "metamodel";
				case MetaSyntaxKind.KExtern:
					return "extern";
				case MetaSyntaxKind.KTypeDef:
					return "typedef";
				case MetaSyntaxKind.KAbstract:
					return "abstract";
				case MetaSyntaxKind.KClass:
					return "class";
				case MetaSyntaxKind.KStruct:
					return "struct";
				case MetaSyntaxKind.KEnum:
					return "enum";
				case MetaSyntaxKind.KAssociation:
					return "association";
				case MetaSyntaxKind.KContainment:
					return "containment";
				case MetaSyntaxKind.KWith:
					return "with";
				case MetaSyntaxKind.KNew:
					return "new";
				case MetaSyntaxKind.KNull:
					return "null";
				case MetaSyntaxKind.KTrue:
					return "true";
				case MetaSyntaxKind.KFalse:
					return "false";
				case MetaSyntaxKind.KVoid:
					return "void";
				case MetaSyntaxKind.KObject:
					return "object";
				case MetaSyntaxKind.KSymbol:
					return "symbol";
				case MetaSyntaxKind.KString:
					return "string";
				case MetaSyntaxKind.KInt:
					return "int";
				case MetaSyntaxKind.KLong:
					return "long";
				case MetaSyntaxKind.KFloat:
					return "float";
				case MetaSyntaxKind.KDouble:
					return "double";
				case MetaSyntaxKind.KByte:
					return "byte";
				case MetaSyntaxKind.KBool:
					return "bool";
				case MetaSyntaxKind.KList:
					return "list";
				case MetaSyntaxKind.KAny:
					return "any";
				case MetaSyntaxKind.KNone:
					return "none";
				case MetaSyntaxKind.KError:
					return "error";
				case MetaSyntaxKind.KSet:
					return "set";
				case MetaSyntaxKind.KMultiList:
					return "multi_list";
				case MetaSyntaxKind.KMultiSet:
					return "multi_set";
				case MetaSyntaxKind.KThis:
					return "this";
				case MetaSyntaxKind.KTypeof:
					return "typeof";
				case MetaSyntaxKind.KAs:
					return "as";
				case MetaSyntaxKind.KIs:
					return "is";
				case MetaSyntaxKind.KBase:
					return "base";
				case MetaSyntaxKind.KConst:
					return "const";
				case MetaSyntaxKind.KRedefines:
					return "redefines";
				case MetaSyntaxKind.KSubsets:
					return "subsets";
				case MetaSyntaxKind.KReadonly:
					return "readonly";
				case MetaSyntaxKind.KLazy:
					return "lazy";
				case MetaSyntaxKind.KSynthetized:
					return "synthetized";
				case MetaSyntaxKind.KInherited:
					return "inherited";
				case MetaSyntaxKind.KDerived:
					return "derived";
				case MetaSyntaxKind.KStatic:
					return "static";
				case MetaSyntaxKind.TSemicolon:
					return ";";
				case MetaSyntaxKind.TColon:
					return ":";
				case MetaSyntaxKind.TDot:
					return ".";
				case MetaSyntaxKind.TComma:
					return ",";
				case MetaSyntaxKind.TAssign:
					return "=";
				case MetaSyntaxKind.TOpenParen:
					return "(";
				case MetaSyntaxKind.TCloseParen:
					return ")";
				case MetaSyntaxKind.TOpenBracket:
					return "[";
				case MetaSyntaxKind.TCloseBracket:
					return "]";
				case MetaSyntaxKind.TOpenBrace:
					return "{";
				case MetaSyntaxKind.TCloseBrace:
					return "}";
				case MetaSyntaxKind.TLessThan:
					return "<";
				case MetaSyntaxKind.TGreaterThan:
					return ">";
				case MetaSyntaxKind.TQuestion:
					return "?";
				case MetaSyntaxKind.TQuestionQuestion:
					return "??";
				case MetaSyntaxKind.TAmpersand:
					return "&";
				case MetaSyntaxKind.THat:
					return "^";
				case MetaSyntaxKind.TBar:
					return "|";
				case MetaSyntaxKind.TAndAlso:
					return "&&";
				case MetaSyntaxKind.TOrElse:
					return "||";
				case MetaSyntaxKind.TPlusPlus:
					return "++";
				case MetaSyntaxKind.TMinusMinus:
					return "--";
				case MetaSyntaxKind.TPlus:
					return "+";
				case MetaSyntaxKind.TMinus:
					return "-";
				case MetaSyntaxKind.TTilde:
					return "~";
				case MetaSyntaxKind.TExclamation:
					return "!";
				case MetaSyntaxKind.TSlash:
					return "/";
				case MetaSyntaxKind.TPercent:
					return "%";
				case MetaSyntaxKind.TLessThanOrEqual:
					return "<=";
				case MetaSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case MetaSyntaxKind.TEqual:
					return "==";
				case MetaSyntaxKind.TNotEqual:
					return "!=";
				case MetaSyntaxKind.TAsteriskAssign:
					return "*=";
				case MetaSyntaxKind.TSlashAssign:
					return "/=";
				case MetaSyntaxKind.TPercentAssign:
					return "%=";
				case MetaSyntaxKind.TPlusAssign:
					return "+=";
				case MetaSyntaxKind.TMinusAssign:
					return "-=";
				case MetaSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case MetaSyntaxKind.TRightShiftAssign:
					return ">>=";
				case MetaSyntaxKind.TAmpersandAssign:
					return "&=";
				case MetaSyntaxKind.THatAssign:
					return "^=";
				case MetaSyntaxKind.TBarAssign:
					return "|=";
				case MetaSyntaxKind.IUri:
					return "Uri";
				case MetaSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case MetaSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case MetaSyntaxKind.LCommentStart:
					return "/*";
				case MetaSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case MetaSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public MetaSyntaxKind GetKind(string text)
		{
			switch (text)
			{
				case "namespace":
					return MetaSyntaxKind.KNamespace;
				case "using":
					return MetaSyntaxKind.KUsing;
				case "metamodel":
					return MetaSyntaxKind.KMetamodel;
				case "extern":
					return MetaSyntaxKind.KExtern;
				case "typedef":
					return MetaSyntaxKind.KTypeDef;
				case "abstract":
					return MetaSyntaxKind.KAbstract;
				case "class":
					return MetaSyntaxKind.KClass;
				case "struct":
					return MetaSyntaxKind.KStruct;
				case "enum":
					return MetaSyntaxKind.KEnum;
				case "association":
					return MetaSyntaxKind.KAssociation;
				case "containment":
					return MetaSyntaxKind.KContainment;
				case "with":
					return MetaSyntaxKind.KWith;
				case "new":
					return MetaSyntaxKind.KNew;
				case "null":
					return MetaSyntaxKind.KNull;
				case "true":
					return MetaSyntaxKind.KTrue;
				case "false":
					return MetaSyntaxKind.KFalse;
				case "void":
					return MetaSyntaxKind.KVoid;
				case "object":
					return MetaSyntaxKind.KObject;
				case "symbol":
					return MetaSyntaxKind.KSymbol;
				case "string":
					return MetaSyntaxKind.KString;
				case "int":
					return MetaSyntaxKind.KInt;
				case "long":
					return MetaSyntaxKind.KLong;
				case "float":
					return MetaSyntaxKind.KFloat;
				case "double":
					return MetaSyntaxKind.KDouble;
				case "byte":
					return MetaSyntaxKind.KByte;
				case "bool":
					return MetaSyntaxKind.KBool;
				case "list":
					return MetaSyntaxKind.KList;
				case "any":
					return MetaSyntaxKind.KAny;
				case "none":
					return MetaSyntaxKind.KNone;
				case "error":
					return MetaSyntaxKind.KError;
				case "set":
					return MetaSyntaxKind.KSet;
				case "multi_list":
					return MetaSyntaxKind.KMultiList;
				case "multi_set":
					return MetaSyntaxKind.KMultiSet;
				case "this":
					return MetaSyntaxKind.KThis;
				case "typeof":
					return MetaSyntaxKind.KTypeof;
				case "as":
					return MetaSyntaxKind.KAs;
				case "is":
					return MetaSyntaxKind.KIs;
				case "base":
					return MetaSyntaxKind.KBase;
				case "const":
					return MetaSyntaxKind.KConst;
				case "redefines":
					return MetaSyntaxKind.KRedefines;
				case "subsets":
					return MetaSyntaxKind.KSubsets;
				case "readonly":
					return MetaSyntaxKind.KReadonly;
				case "lazy":
					return MetaSyntaxKind.KLazy;
				case "synthetized":
					return MetaSyntaxKind.KSynthetized;
				case "inherited":
					return MetaSyntaxKind.KInherited;
				case "derived":
					return MetaSyntaxKind.KDerived;
				case "static":
					return MetaSyntaxKind.KStatic;
				case ";":
					return MetaSyntaxKind.TSemicolon;
				case ":":
					return MetaSyntaxKind.TColon;
				case ".":
					return MetaSyntaxKind.TDot;
				case ",":
					return MetaSyntaxKind.TComma;
				case "=":
					return MetaSyntaxKind.TAssign;
				case "(":
					return MetaSyntaxKind.TOpenParen;
				case ")":
					return MetaSyntaxKind.TCloseParen;
				case "[":
					return MetaSyntaxKind.TOpenBracket;
				case "]":
					return MetaSyntaxKind.TCloseBracket;
				case "{":
					return MetaSyntaxKind.TOpenBrace;
				case "}":
					return MetaSyntaxKind.TCloseBrace;
				case "<":
					return MetaSyntaxKind.TLessThan;
				case ">":
					return MetaSyntaxKind.TGreaterThan;
				case "?":
					return MetaSyntaxKind.TQuestion;
				case "??":
					return MetaSyntaxKind.TQuestionQuestion;
				case "&":
					return MetaSyntaxKind.TAmpersand;
				case "^":
					return MetaSyntaxKind.THat;
				case "|":
					return MetaSyntaxKind.TBar;
				case "&&":
					return MetaSyntaxKind.TAndAlso;
				case "||":
					return MetaSyntaxKind.TOrElse;
				case "++":
					return MetaSyntaxKind.TPlusPlus;
				case "--":
					return MetaSyntaxKind.TMinusMinus;
				case "+":
					return MetaSyntaxKind.TPlus;
				case "-":
					return MetaSyntaxKind.TMinus;
				case "~":
					return MetaSyntaxKind.TTilde;
				case "!":
					return MetaSyntaxKind.TExclamation;
				case "/":
					return MetaSyntaxKind.TSlash;
				case "%":
					return MetaSyntaxKind.TPercent;
				case "<=":
					return MetaSyntaxKind.TLessThanOrEqual;
				case ">=":
					return MetaSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return MetaSyntaxKind.TEqual;
				case "!=":
					return MetaSyntaxKind.TNotEqual;
				case "*=":
					return MetaSyntaxKind.TAsteriskAssign;
				case "/=":
					return MetaSyntaxKind.TSlashAssign;
				case "%=":
					return MetaSyntaxKind.TPercentAssign;
				case "+=":
					return MetaSyntaxKind.TPlusAssign;
				case "-=":
					return MetaSyntaxKind.TMinusAssign;
				case "<<=":
					return MetaSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return MetaSyntaxKind.TRightShiftAssign;
				case "&=":
					return MetaSyntaxKind.TAmpersandAssign;
				case "^=":
					return MetaSyntaxKind.THatAssign;
				case "|=":
					return MetaSyntaxKind.TBarAssign;
				case "Uri":
					return MetaSyntaxKind.IUri;
				case "@\"":
					return MetaSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return MetaSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return MetaSyntaxKind.LCommentStart;
				case "\"":
					return MetaSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return MetaSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return MetaSyntaxKind.None;
			}
		}

		public override string GetKindText(int rawKind)
		{
			return this.GetKindText((MetaSyntaxKind)rawKind);
		}

		public string GetKindText(MetaSyntaxKind kind)
		{
			return kind.ToString();
		}

		public override bool IsTriviaWithEndOfLine(int rawKind)
		{
			return this.IsTriviaWithEndOfLine((MetaSyntaxKind)rawKind);
		}

		public bool IsTriviaWithEndOfLine(MetaSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaSyntaxKind.LCrLf:
					return true;
				case MetaSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}

		public bool IsKeyword(int rawKind)
		{
			return this.IsKeyword((MetaSyntaxKind)rawKind);
		}

		public bool IsKeyword(MetaSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaSyntaxKind.KNamespace:
				case MetaSyntaxKind.KUsing:
				case MetaSyntaxKind.KMetamodel:
				case MetaSyntaxKind.KExtern:
				case MetaSyntaxKind.KTypeDef:
				case MetaSyntaxKind.KAbstract:
				case MetaSyntaxKind.KClass:
				case MetaSyntaxKind.KStruct:
				case MetaSyntaxKind.KEnum:
				case MetaSyntaxKind.KAssociation:
				case MetaSyntaxKind.KContainment:
				case MetaSyntaxKind.KWith:
				case MetaSyntaxKind.KNew:
				case MetaSyntaxKind.KNull:
				case MetaSyntaxKind.KTrue:
				case MetaSyntaxKind.KFalse:
				case MetaSyntaxKind.KVoid:
				case MetaSyntaxKind.KObject:
				case MetaSyntaxKind.KSymbol:
				case MetaSyntaxKind.KString:
				case MetaSyntaxKind.KInt:
				case MetaSyntaxKind.KLong:
				case MetaSyntaxKind.KFloat:
				case MetaSyntaxKind.KDouble:
				case MetaSyntaxKind.KByte:
				case MetaSyntaxKind.KBool:
				case MetaSyntaxKind.KList:
				case MetaSyntaxKind.KAny:
				case MetaSyntaxKind.KNone:
				case MetaSyntaxKind.KError:
				case MetaSyntaxKind.KSet:
				case MetaSyntaxKind.KMultiList:
				case MetaSyntaxKind.KMultiSet:
				case MetaSyntaxKind.KThis:
				case MetaSyntaxKind.KTypeof:
				case MetaSyntaxKind.KAs:
				case MetaSyntaxKind.KIs:
				case MetaSyntaxKind.KBase:
				case MetaSyntaxKind.KConst:
				case MetaSyntaxKind.KRedefines:
				case MetaSyntaxKind.KSubsets:
				case MetaSyntaxKind.KReadonly:
				case MetaSyntaxKind.KLazy:
				case MetaSyntaxKind.KSynthetized:
				case MetaSyntaxKind.KInherited:
				case MetaSyntaxKind.KDerived:
				case MetaSyntaxKind.KStatic:
					return true;
				default:
					return false;
			}
		}
		public bool IsIdentifier(int rawKind)
		{
			return this.IsIdentifier((MetaSyntaxKind)rawKind);
		}

		public bool IsIdentifier(MetaSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaSyntaxKind.IdentifierNormal:
					return true;
				default:
					return false;
			}
		}
		public bool IsNumber(int rawKind)
		{
			return this.IsNumber((MetaSyntaxKind)rawKind);
		}

		public bool IsNumber(MetaSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaSyntaxKind.LInteger:
					return true;
				case MetaSyntaxKind.LDecimal:
					return true;
				case MetaSyntaxKind.LScientific:
					return true;
				case MetaSyntaxKind.LDateTimeOffset:
					return true;
				case MetaSyntaxKind.LDateTime:
					return true;
				case MetaSyntaxKind.LDate:
					return true;
				case MetaSyntaxKind.LTime:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(int rawKind)
		{
			return this.IsString((MetaSyntaxKind)rawKind);
		}

		public bool IsString(MetaSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaSyntaxKind.LRegularString:
					return true;
				case MetaSyntaxKind.LGuid:
					return true;
				case MetaSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case MetaSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(int rawKind)
		{
			return this.IsWhitespace((MetaSyntaxKind)rawKind);
		}

		public bool IsWhitespace(MetaSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaSyntaxKind.LUtf8Bom:
					return true;
				case MetaSyntaxKind.LWhiteSpace:
					return true;
				case MetaSyntaxKind.LCrLf:
					return true;
				case MetaSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsComment(int rawKind)
		{
			return this.IsComment((MetaSyntaxKind)rawKind);
		}

		public bool IsComment(MetaSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaSyntaxKind.LSingleLineComment:
					return true;
				case MetaSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}

		public MetaTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((MetaSyntaxKind)rawKind);
		}

		public MetaTokenKind GetTokenKind(MetaSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaSyntaxKind.KNamespace:
				case MetaSyntaxKind.KUsing:
				case MetaSyntaxKind.KMetamodel:
				case MetaSyntaxKind.KExtern:
				case MetaSyntaxKind.KTypeDef:
				case MetaSyntaxKind.KAbstract:
				case MetaSyntaxKind.KClass:
				case MetaSyntaxKind.KStruct:
				case MetaSyntaxKind.KEnum:
				case MetaSyntaxKind.KAssociation:
				case MetaSyntaxKind.KContainment:
				case MetaSyntaxKind.KWith:
				case MetaSyntaxKind.KNew:
				case MetaSyntaxKind.KNull:
				case MetaSyntaxKind.KTrue:
				case MetaSyntaxKind.KFalse:
				case MetaSyntaxKind.KVoid:
				case MetaSyntaxKind.KObject:
				case MetaSyntaxKind.KSymbol:
				case MetaSyntaxKind.KString:
				case MetaSyntaxKind.KInt:
				case MetaSyntaxKind.KLong:
				case MetaSyntaxKind.KFloat:
				case MetaSyntaxKind.KDouble:
				case MetaSyntaxKind.KByte:
				case MetaSyntaxKind.KBool:
				case MetaSyntaxKind.KList:
				case MetaSyntaxKind.KAny:
				case MetaSyntaxKind.KNone:
				case MetaSyntaxKind.KError:
				case MetaSyntaxKind.KSet:
				case MetaSyntaxKind.KMultiList:
				case MetaSyntaxKind.KMultiSet:
				case MetaSyntaxKind.KThis:
				case MetaSyntaxKind.KTypeof:
				case MetaSyntaxKind.KAs:
				case MetaSyntaxKind.KIs:
				case MetaSyntaxKind.KBase:
				case MetaSyntaxKind.KConst:
				case MetaSyntaxKind.KRedefines:
				case MetaSyntaxKind.KSubsets:
				case MetaSyntaxKind.KReadonly:
				case MetaSyntaxKind.KLazy:
				case MetaSyntaxKind.KSynthetized:
				case MetaSyntaxKind.KInherited:
				case MetaSyntaxKind.KDerived:
				case MetaSyntaxKind.KStatic:
					return MetaTokenKind.Keyword;
				case MetaSyntaxKind.IdentifierNormal:
					return MetaTokenKind.Identifier;
				case MetaSyntaxKind.LInteger:
					return MetaTokenKind.Number;
				case MetaSyntaxKind.LDecimal:
					return MetaTokenKind.Number;
				case MetaSyntaxKind.LScientific:
					return MetaTokenKind.Number;
				case MetaSyntaxKind.LDateTimeOffset:
					return MetaTokenKind.Number;
				case MetaSyntaxKind.LDateTime:
					return MetaTokenKind.Number;
				case MetaSyntaxKind.LDate:
					return MetaTokenKind.Number;
				case MetaSyntaxKind.LTime:
					return MetaTokenKind.Number;
				case MetaSyntaxKind.LRegularString:
					return MetaTokenKind.String;
				case MetaSyntaxKind.LGuid:
					return MetaTokenKind.String;
				case MetaSyntaxKind.LUtf8Bom:
					return MetaTokenKind.Whitespace;
				case MetaSyntaxKind.LWhiteSpace:
					return MetaTokenKind.Whitespace;
				case MetaSyntaxKind.LCrLf:
					return MetaTokenKind.Whitespace;
				case MetaSyntaxKind.LLineEnd:
					return MetaTokenKind.Whitespace;
				case MetaSyntaxKind.LSingleLineComment:
					return MetaTokenKind.Comment;
				case MetaSyntaxKind.LComment:
					return MetaTokenKind.Comment;
				case MetaSyntaxKind.LDoubleQuoteVerbatimString:
					return MetaTokenKind.String;
				case MetaSyntaxKind.LSingleQuoteVerbatimString:
					return MetaTokenKind.String;
				default:
					return MetaTokenKind.None;
			}
		}

		public MetaTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((MetaLexerMode)rawKind);
		}

		public MetaTokenKind GetModeTokenKind(MetaLexerMode kind)
		{
			switch(kind)
			{
				case MetaLexerMode.LMultilineComment:
					return MetaTokenKind.Comment;
				case MetaLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return MetaTokenKind.String;
				case MetaLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return MetaTokenKind.String;
				default:
					return MetaTokenKind.None;
			}
		}
	}
}

