using System.Threading;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Meta
{
	public enum MetaModelTokenKind
	{
		None,
		Keyword,
		Identifier,
		Number,
		String,
		Whitespace,
		Comment
	}

	public class MetaModelSyntaxFacts : SyntaxFacts
	{
		internal static readonly MetaModelSyntaxFacts Instance = new MetaModelSyntaxFacts();

		protected override int DefaultEndOfLineSyntaxKindCore
		{
			get { return (int)MetaModelSyntaxKind.LCrLf; }
		}

		protected override int DefaultWhitespaceSyntaxKindCore
		{
			get { return (int)MetaModelSyntaxKind.LWhiteSpace; }
		}

		public override bool IsToken(int rawKind)
		{
			return this.IsToken((MetaModelSyntaxKind)rawKind);
		}

		public bool IsToken(MetaModelSyntaxKind kind)
		{
			switch (kind)
			{
				case MetaModelSyntaxKind.Eof:
				case MetaModelSyntaxKind.KNamespace:
				case MetaModelSyntaxKind.KUsing:
				case MetaModelSyntaxKind.KMetamodel:
				case MetaModelSyntaxKind.KExtern:
				case MetaModelSyntaxKind.KTypeDef:
				case MetaModelSyntaxKind.KAbstract:
				case MetaModelSyntaxKind.KClass:
				case MetaModelSyntaxKind.KEnum:
				case MetaModelSyntaxKind.KAssociation:
				case MetaModelSyntaxKind.KContainment:
				case MetaModelSyntaxKind.KWith:
				case MetaModelSyntaxKind.KNew:
				case MetaModelSyntaxKind.KNull:
				case MetaModelSyntaxKind.KTrue:
				case MetaModelSyntaxKind.KFalse:
				case MetaModelSyntaxKind.KVoid:
				case MetaModelSyntaxKind.KObject:
				case MetaModelSyntaxKind.KSymbol:
				case MetaModelSyntaxKind.KString:
				case MetaModelSyntaxKind.KInt:
				case MetaModelSyntaxKind.KLong:
				case MetaModelSyntaxKind.KFloat:
				case MetaModelSyntaxKind.KDouble:
				case MetaModelSyntaxKind.KByte:
				case MetaModelSyntaxKind.KBool:
				case MetaModelSyntaxKind.KList:
				case MetaModelSyntaxKind.KAny:
				case MetaModelSyntaxKind.KNone:
				case MetaModelSyntaxKind.KError:
				case MetaModelSyntaxKind.KSet:
				case MetaModelSyntaxKind.KMultiList:
				case MetaModelSyntaxKind.KMultiSet:
				case MetaModelSyntaxKind.KThis:
				case MetaModelSyntaxKind.KTypeof:
				case MetaModelSyntaxKind.KAs:
				case MetaModelSyntaxKind.KIs:
				case MetaModelSyntaxKind.KBase:
				case MetaModelSyntaxKind.KConst:
				case MetaModelSyntaxKind.KRedefines:
				case MetaModelSyntaxKind.KSubsets:
				case MetaModelSyntaxKind.KReadonly:
				case MetaModelSyntaxKind.KLazy:
				case MetaModelSyntaxKind.KSynthetized:
				case MetaModelSyntaxKind.KInherited:
				case MetaModelSyntaxKind.KDerived:
				case MetaModelSyntaxKind.KStatic:
				case MetaModelSyntaxKind.TSemicolon:
				case MetaModelSyntaxKind.TColon:
				case MetaModelSyntaxKind.TDot:
				case MetaModelSyntaxKind.TComma:
				case MetaModelSyntaxKind.TAssign:
				case MetaModelSyntaxKind.TOpenParen:
				case MetaModelSyntaxKind.TCloseParen:
				case MetaModelSyntaxKind.TOpenBracket:
				case MetaModelSyntaxKind.TCloseBracket:
				case MetaModelSyntaxKind.TOpenBrace:
				case MetaModelSyntaxKind.TCloseBrace:
				case MetaModelSyntaxKind.TLessThan:
				case MetaModelSyntaxKind.TGreaterThan:
				case MetaModelSyntaxKind.TQuestion:
				case MetaModelSyntaxKind.TQuestionQuestion:
				case MetaModelSyntaxKind.TAmpersand:
				case MetaModelSyntaxKind.THat:
				case MetaModelSyntaxKind.TBar:
				case MetaModelSyntaxKind.TAndAlso:
				case MetaModelSyntaxKind.TOrElse:
				case MetaModelSyntaxKind.TPlusPlus:
				case MetaModelSyntaxKind.TMinusMinus:
				case MetaModelSyntaxKind.TPlus:
				case MetaModelSyntaxKind.TMinus:
				case MetaModelSyntaxKind.TTilde:
				case MetaModelSyntaxKind.TExclamation:
				case MetaModelSyntaxKind.TSlash:
				case MetaModelSyntaxKind.TAsterisk:
				case MetaModelSyntaxKind.TPercent:
				case MetaModelSyntaxKind.TLessThanOrEqual:
				case MetaModelSyntaxKind.TGreaterThanOrEqual:
				case MetaModelSyntaxKind.TEqual:
				case MetaModelSyntaxKind.TNotEqual:
				case MetaModelSyntaxKind.TAsteriskAssign:
				case MetaModelSyntaxKind.TSlashAssign:
				case MetaModelSyntaxKind.TPercentAssign:
				case MetaModelSyntaxKind.TPlusAssign:
				case MetaModelSyntaxKind.TMinusAssign:
				case MetaModelSyntaxKind.TLeftShiftAssign:
				case MetaModelSyntaxKind.TRightShiftAssign:
				case MetaModelSyntaxKind.TAmpersandAssign:
				case MetaModelSyntaxKind.THatAssign:
				case MetaModelSyntaxKind.TBarAssign:
				case MetaModelSyntaxKind.IUri:
				case MetaModelSyntaxKind.IdentifierNormal:
				case MetaModelSyntaxKind.IdentifierVerbatim:
				case MetaModelSyntaxKind.LInteger:
				case MetaModelSyntaxKind.LDecimal:
				case MetaModelSyntaxKind.LScientific:
				case MetaModelSyntaxKind.LDateTimeOffset:
				case MetaModelSyntaxKind.LDateTime:
				case MetaModelSyntaxKind.LDate:
				case MetaModelSyntaxKind.LTime:
				case MetaModelSyntaxKind.LRegularString:
				case MetaModelSyntaxKind.LGuid:
				case MetaModelSyntaxKind.LUtf8Bom:
				case MetaModelSyntaxKind.LWhiteSpace:
				case MetaModelSyntaxKind.LCrLf:
				case MetaModelSyntaxKind.LLineEnd:
				case MetaModelSyntaxKind.LSingleLineComment:
				case MetaModelSyntaxKind.LComment:
				case MetaModelSyntaxKind.LDoubleQuoteVerbatimString:
				case MetaModelSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(int rawKind)
		{
			return this.IsFixedToken((MetaModelSyntaxKind)rawKind);
		}

		public bool IsFixedToken(MetaModelSyntaxKind kind)
		{
			switch (kind)
			{
				case MetaModelSyntaxKind.Eof:
				case MetaModelSyntaxKind.KNamespace:
				case MetaModelSyntaxKind.KUsing:
				case MetaModelSyntaxKind.KMetamodel:
				case MetaModelSyntaxKind.KExtern:
				case MetaModelSyntaxKind.KTypeDef:
				case MetaModelSyntaxKind.KAbstract:
				case MetaModelSyntaxKind.KClass:
				case MetaModelSyntaxKind.KEnum:
				case MetaModelSyntaxKind.KAssociation:
				case MetaModelSyntaxKind.KContainment:
				case MetaModelSyntaxKind.KWith:
				case MetaModelSyntaxKind.KNew:
				case MetaModelSyntaxKind.KNull:
				case MetaModelSyntaxKind.KTrue:
				case MetaModelSyntaxKind.KFalse:
				case MetaModelSyntaxKind.KVoid:
				case MetaModelSyntaxKind.KObject:
				case MetaModelSyntaxKind.KSymbol:
				case MetaModelSyntaxKind.KString:
				case MetaModelSyntaxKind.KInt:
				case MetaModelSyntaxKind.KLong:
				case MetaModelSyntaxKind.KFloat:
				case MetaModelSyntaxKind.KDouble:
				case MetaModelSyntaxKind.KByte:
				case MetaModelSyntaxKind.KBool:
				case MetaModelSyntaxKind.KList:
				case MetaModelSyntaxKind.KAny:
				case MetaModelSyntaxKind.KNone:
				case MetaModelSyntaxKind.KError:
				case MetaModelSyntaxKind.KSet:
				case MetaModelSyntaxKind.KMultiList:
				case MetaModelSyntaxKind.KMultiSet:
				case MetaModelSyntaxKind.KThis:
				case MetaModelSyntaxKind.KTypeof:
				case MetaModelSyntaxKind.KAs:
				case MetaModelSyntaxKind.KIs:
				case MetaModelSyntaxKind.KBase:
				case MetaModelSyntaxKind.KConst:
				case MetaModelSyntaxKind.KRedefines:
				case MetaModelSyntaxKind.KSubsets:
				case MetaModelSyntaxKind.KReadonly:
				case MetaModelSyntaxKind.KLazy:
				case MetaModelSyntaxKind.KSynthetized:
				case MetaModelSyntaxKind.KInherited:
				case MetaModelSyntaxKind.KDerived:
				case MetaModelSyntaxKind.KStatic:
				case MetaModelSyntaxKind.TSemicolon:
				case MetaModelSyntaxKind.TColon:
				case MetaModelSyntaxKind.TDot:
				case MetaModelSyntaxKind.TComma:
				case MetaModelSyntaxKind.TAssign:
				case MetaModelSyntaxKind.TOpenParen:
				case MetaModelSyntaxKind.TCloseParen:
				case MetaModelSyntaxKind.TOpenBracket:
				case MetaModelSyntaxKind.TCloseBracket:
				case MetaModelSyntaxKind.TOpenBrace:
				case MetaModelSyntaxKind.TCloseBrace:
				case MetaModelSyntaxKind.TLessThan:
				case MetaModelSyntaxKind.TGreaterThan:
				case MetaModelSyntaxKind.TQuestion:
				case MetaModelSyntaxKind.TQuestionQuestion:
				case MetaModelSyntaxKind.TAmpersand:
				case MetaModelSyntaxKind.THat:
				case MetaModelSyntaxKind.TBar:
				case MetaModelSyntaxKind.TAndAlso:
				case MetaModelSyntaxKind.TOrElse:
				case MetaModelSyntaxKind.TPlusPlus:
				case MetaModelSyntaxKind.TMinusMinus:
				case MetaModelSyntaxKind.TPlus:
				case MetaModelSyntaxKind.TMinus:
				case MetaModelSyntaxKind.TTilde:
				case MetaModelSyntaxKind.TExclamation:
				case MetaModelSyntaxKind.TSlash:
				case MetaModelSyntaxKind.TAsterisk:
				case MetaModelSyntaxKind.TPercent:
				case MetaModelSyntaxKind.TLessThanOrEqual:
				case MetaModelSyntaxKind.TGreaterThanOrEqual:
				case MetaModelSyntaxKind.TEqual:
				case MetaModelSyntaxKind.TNotEqual:
				case MetaModelSyntaxKind.TAsteriskAssign:
				case MetaModelSyntaxKind.TSlashAssign:
				case MetaModelSyntaxKind.TPercentAssign:
				case MetaModelSyntaxKind.TPlusAssign:
				case MetaModelSyntaxKind.TMinusAssign:
				case MetaModelSyntaxKind.TLeftShiftAssign:
				case MetaModelSyntaxKind.TRightShiftAssign:
				case MetaModelSyntaxKind.TAmpersandAssign:
				case MetaModelSyntaxKind.THatAssign:
				case MetaModelSyntaxKind.TBarAssign:
				case MetaModelSyntaxKind.IUri:
					return true;
				default:
					return false;
			}
		}

		public override string GetText(int rawKind)
		{
			return this.GetText((MetaModelSyntaxKind)rawKind);
		}

		public string GetText(MetaModelSyntaxKind kind)
		{
			switch (kind)
			{
				case MetaModelSyntaxKind.KNamespace:
					return "namespace";
				case MetaModelSyntaxKind.KUsing:
					return "using";
				case MetaModelSyntaxKind.KMetamodel:
					return "metamodel";
				case MetaModelSyntaxKind.KExtern:
					return "extern";
				case MetaModelSyntaxKind.KTypeDef:
					return "typedef";
				case MetaModelSyntaxKind.KAbstract:
					return "abstract";
				case MetaModelSyntaxKind.KClass:
					return "class";
				case MetaModelSyntaxKind.KEnum:
					return "enum";
				case MetaModelSyntaxKind.KAssociation:
					return "association";
				case MetaModelSyntaxKind.KContainment:
					return "containment";
				case MetaModelSyntaxKind.KWith:
					return "with";
				case MetaModelSyntaxKind.KNew:
					return "new";
				case MetaModelSyntaxKind.KNull:
					return "null";
				case MetaModelSyntaxKind.KTrue:
					return "true";
				case MetaModelSyntaxKind.KFalse:
					return "false";
				case MetaModelSyntaxKind.KVoid:
					return "void";
				case MetaModelSyntaxKind.KObject:
					return "object";
				case MetaModelSyntaxKind.KSymbol:
					return "symbol";
				case MetaModelSyntaxKind.KString:
					return "string";
				case MetaModelSyntaxKind.KInt:
					return "int";
				case MetaModelSyntaxKind.KLong:
					return "long";
				case MetaModelSyntaxKind.KFloat:
					return "float";
				case MetaModelSyntaxKind.KDouble:
					return "double";
				case MetaModelSyntaxKind.KByte:
					return "byte";
				case MetaModelSyntaxKind.KBool:
					return "bool";
				case MetaModelSyntaxKind.KList:
					return "list";
				case MetaModelSyntaxKind.KAny:
					return "any";
				case MetaModelSyntaxKind.KNone:
					return "none";
				case MetaModelSyntaxKind.KError:
					return "error";
				case MetaModelSyntaxKind.KSet:
					return "set";
				case MetaModelSyntaxKind.KMultiList:
					return "multi_list";
				case MetaModelSyntaxKind.KMultiSet:
					return "multi_set";
				case MetaModelSyntaxKind.KThis:
					return "this";
				case MetaModelSyntaxKind.KTypeof:
					return "typeof";
				case MetaModelSyntaxKind.KAs:
					return "as";
				case MetaModelSyntaxKind.KIs:
					return "is";
				case MetaModelSyntaxKind.KBase:
					return "base";
				case MetaModelSyntaxKind.KConst:
					return "const";
				case MetaModelSyntaxKind.KRedefines:
					return "redefines";
				case MetaModelSyntaxKind.KSubsets:
					return "subsets";
				case MetaModelSyntaxKind.KReadonly:
					return "readonly";
				case MetaModelSyntaxKind.KLazy:
					return "lazy";
				case MetaModelSyntaxKind.KSynthetized:
					return "synthetized";
				case MetaModelSyntaxKind.KInherited:
					return "inherited";
				case MetaModelSyntaxKind.KDerived:
					return "derived";
				case MetaModelSyntaxKind.KStatic:
					return "static";
				case MetaModelSyntaxKind.TSemicolon:
					return ";";
				case MetaModelSyntaxKind.TColon:
					return ":";
				case MetaModelSyntaxKind.TDot:
					return ".";
				case MetaModelSyntaxKind.TComma:
					return ",";
				case MetaModelSyntaxKind.TAssign:
					return "=";
				case MetaModelSyntaxKind.TOpenParen:
					return "(";
				case MetaModelSyntaxKind.TCloseParen:
					return ")";
				case MetaModelSyntaxKind.TOpenBracket:
					return "[";
				case MetaModelSyntaxKind.TCloseBracket:
					return "]";
				case MetaModelSyntaxKind.TOpenBrace:
					return "{";
				case MetaModelSyntaxKind.TCloseBrace:
					return "}";
				case MetaModelSyntaxKind.TLessThan:
					return "<";
				case MetaModelSyntaxKind.TGreaterThan:
					return ">";
				case MetaModelSyntaxKind.TQuestion:
					return "?";
				case MetaModelSyntaxKind.TQuestionQuestion:
					return "??";
				case MetaModelSyntaxKind.TAmpersand:
					return "&";
				case MetaModelSyntaxKind.THat:
					return "^";
				case MetaModelSyntaxKind.TBar:
					return "|";
				case MetaModelSyntaxKind.TAndAlso:
					return "&&";
				case MetaModelSyntaxKind.TOrElse:
					return "||";
				case MetaModelSyntaxKind.TPlusPlus:
					return "++";
				case MetaModelSyntaxKind.TMinusMinus:
					return "--";
				case MetaModelSyntaxKind.TPlus:
					return "+";
				case MetaModelSyntaxKind.TMinus:
					return "-";
				case MetaModelSyntaxKind.TTilde:
					return "~";
				case MetaModelSyntaxKind.TExclamation:
					return "!";
				case MetaModelSyntaxKind.TSlash:
					return "/";
				case MetaModelSyntaxKind.TAsterisk:
					return "*";
				case MetaModelSyntaxKind.TPercent:
					return "%";
				case MetaModelSyntaxKind.TLessThanOrEqual:
					return "<=";
				case MetaModelSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case MetaModelSyntaxKind.TEqual:
					return "==";
				case MetaModelSyntaxKind.TNotEqual:
					return "!=";
				case MetaModelSyntaxKind.TAsteriskAssign:
					return "*=";
				case MetaModelSyntaxKind.TSlashAssign:
					return "/=";
				case MetaModelSyntaxKind.TPercentAssign:
					return "%=";
				case MetaModelSyntaxKind.TPlusAssign:
					return "+=";
				case MetaModelSyntaxKind.TMinusAssign:
					return "-=";
				case MetaModelSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case MetaModelSyntaxKind.TRightShiftAssign:
					return ">>=";
				case MetaModelSyntaxKind.TAmpersandAssign:
					return "&=";
				case MetaModelSyntaxKind.THatAssign:
					return "^=";
				case MetaModelSyntaxKind.TBarAssign:
					return "|=";
				case MetaModelSyntaxKind.IUri:
					return "Uri";
				default:
					return string.Empty;
			}
		}

		public MetaModelSyntaxKind GetKind(string text)
		{
			switch (text)
			{
				case "namespace":
					return MetaModelSyntaxKind.KNamespace;
				case "using":
					return MetaModelSyntaxKind.KUsing;
				case "metamodel":
					return MetaModelSyntaxKind.KMetamodel;
				case "extern":
					return MetaModelSyntaxKind.KExtern;
				case "typedef":
					return MetaModelSyntaxKind.KTypeDef;
				case "abstract":
					return MetaModelSyntaxKind.KAbstract;
				case "class":
					return MetaModelSyntaxKind.KClass;
				case "enum":
					return MetaModelSyntaxKind.KEnum;
				case "association":
					return MetaModelSyntaxKind.KAssociation;
				case "containment":
					return MetaModelSyntaxKind.KContainment;
				case "with":
					return MetaModelSyntaxKind.KWith;
				case "new":
					return MetaModelSyntaxKind.KNew;
				case "null":
					return MetaModelSyntaxKind.KNull;
				case "true":
					return MetaModelSyntaxKind.KTrue;
				case "false":
					return MetaModelSyntaxKind.KFalse;
				case "void":
					return MetaModelSyntaxKind.KVoid;
				case "object":
					return MetaModelSyntaxKind.KObject;
				case "symbol":
					return MetaModelSyntaxKind.KSymbol;
				case "string":
					return MetaModelSyntaxKind.KString;
				case "int":
					return MetaModelSyntaxKind.KInt;
				case "long":
					return MetaModelSyntaxKind.KLong;
				case "float":
					return MetaModelSyntaxKind.KFloat;
				case "double":
					return MetaModelSyntaxKind.KDouble;
				case "byte":
					return MetaModelSyntaxKind.KByte;
				case "bool":
					return MetaModelSyntaxKind.KBool;
				case "list":
					return MetaModelSyntaxKind.KList;
				case "any":
					return MetaModelSyntaxKind.KAny;
				case "none":
					return MetaModelSyntaxKind.KNone;
				case "error":
					return MetaModelSyntaxKind.KError;
				case "set":
					return MetaModelSyntaxKind.KSet;
				case "multi_list":
					return MetaModelSyntaxKind.KMultiList;
				case "multi_set":
					return MetaModelSyntaxKind.KMultiSet;
				case "this":
					return MetaModelSyntaxKind.KThis;
				case "typeof":
					return MetaModelSyntaxKind.KTypeof;
				case "as":
					return MetaModelSyntaxKind.KAs;
				case "is":
					return MetaModelSyntaxKind.KIs;
				case "base":
					return MetaModelSyntaxKind.KBase;
				case "const":
					return MetaModelSyntaxKind.KConst;
				case "redefines":
					return MetaModelSyntaxKind.KRedefines;
				case "subsets":
					return MetaModelSyntaxKind.KSubsets;
				case "readonly":
					return MetaModelSyntaxKind.KReadonly;
				case "lazy":
					return MetaModelSyntaxKind.KLazy;
				case "synthetized":
					return MetaModelSyntaxKind.KSynthetized;
				case "inherited":
					return MetaModelSyntaxKind.KInherited;
				case "derived":
					return MetaModelSyntaxKind.KDerived;
				case "static":
					return MetaModelSyntaxKind.KStatic;
				case ";":
					return MetaModelSyntaxKind.TSemicolon;
				case ":":
					return MetaModelSyntaxKind.TColon;
				case ".":
					return MetaModelSyntaxKind.TDot;
				case ",":
					return MetaModelSyntaxKind.TComma;
				case "=":
					return MetaModelSyntaxKind.TAssign;
				case "(":
					return MetaModelSyntaxKind.TOpenParen;
				case ")":
					return MetaModelSyntaxKind.TCloseParen;
				case "[":
					return MetaModelSyntaxKind.TOpenBracket;
				case "]":
					return MetaModelSyntaxKind.TCloseBracket;
				case "{":
					return MetaModelSyntaxKind.TOpenBrace;
				case "}":
					return MetaModelSyntaxKind.TCloseBrace;
				case "<":
					return MetaModelSyntaxKind.TLessThan;
				case ">":
					return MetaModelSyntaxKind.TGreaterThan;
				case "?":
					return MetaModelSyntaxKind.TQuestion;
				case "??":
					return MetaModelSyntaxKind.TQuestionQuestion;
				case "&":
					return MetaModelSyntaxKind.TAmpersand;
				case "^":
					return MetaModelSyntaxKind.THat;
				case "|":
					return MetaModelSyntaxKind.TBar;
				case "&&":
					return MetaModelSyntaxKind.TAndAlso;
				case "||":
					return MetaModelSyntaxKind.TOrElse;
				case "++":
					return MetaModelSyntaxKind.TPlusPlus;
				case "--":
					return MetaModelSyntaxKind.TMinusMinus;
				case "+":
					return MetaModelSyntaxKind.TPlus;
				case "-":
					return MetaModelSyntaxKind.TMinus;
				case "~":
					return MetaModelSyntaxKind.TTilde;
				case "!":
					return MetaModelSyntaxKind.TExclamation;
				case "/":
					return MetaModelSyntaxKind.TSlash;
				case "*":
					return MetaModelSyntaxKind.TAsterisk;
				case "%":
					return MetaModelSyntaxKind.TPercent;
				case "<=":
					return MetaModelSyntaxKind.TLessThanOrEqual;
				case ">=":
					return MetaModelSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return MetaModelSyntaxKind.TEqual;
				case "!=":
					return MetaModelSyntaxKind.TNotEqual;
				case "*=":
					return MetaModelSyntaxKind.TAsteriskAssign;
				case "/=":
					return MetaModelSyntaxKind.TSlashAssign;
				case "%=":
					return MetaModelSyntaxKind.TPercentAssign;
				case "+=":
					return MetaModelSyntaxKind.TPlusAssign;
				case "-=":
					return MetaModelSyntaxKind.TMinusAssign;
				case "<<=":
					return MetaModelSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return MetaModelSyntaxKind.TRightShiftAssign;
				case "&=":
					return MetaModelSyntaxKind.TAmpersandAssign;
				case "^=":
					return MetaModelSyntaxKind.THatAssign;
				case "|=":
					return MetaModelSyntaxKind.TBarAssign;
				case "Uri":
					return MetaModelSyntaxKind.IUri;
				default:
					return MetaModelSyntaxKind.None;
			}
		}

		public override string GetKindText(int rawKind)
		{
			return this.GetKindText((MetaModelSyntaxKind)rawKind);
		}

		public string GetKindText(MetaModelSyntaxKind kind)
		{
			return kind.ToString();
		}

		public override bool IsTriviaWithEndOfLine(int rawKind)
		{
			return this.IsTriviaWithEndOfLine((MetaModelSyntaxKind)rawKind);
		}

		public bool IsTriviaWithEndOfLine(MetaModelSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaModelSyntaxKind.LCrLf:
					return true;
				case MetaModelSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}

		public bool IsKeyword(int rawKind)
		{
			return this.IsKeyword((MetaModelSyntaxKind)rawKind);
		}

		public bool IsKeyword(MetaModelSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaModelSyntaxKind.KNamespace:
				case MetaModelSyntaxKind.KUsing:
				case MetaModelSyntaxKind.KMetamodel:
				case MetaModelSyntaxKind.KExtern:
				case MetaModelSyntaxKind.KTypeDef:
				case MetaModelSyntaxKind.KAbstract:
				case MetaModelSyntaxKind.KClass:
				case MetaModelSyntaxKind.KEnum:
				case MetaModelSyntaxKind.KAssociation:
				case MetaModelSyntaxKind.KContainment:
				case MetaModelSyntaxKind.KWith:
				case MetaModelSyntaxKind.KNew:
				case MetaModelSyntaxKind.KNull:
				case MetaModelSyntaxKind.KTrue:
				case MetaModelSyntaxKind.KFalse:
				case MetaModelSyntaxKind.KVoid:
				case MetaModelSyntaxKind.KObject:
				case MetaModelSyntaxKind.KSymbol:
				case MetaModelSyntaxKind.KString:
				case MetaModelSyntaxKind.KInt:
				case MetaModelSyntaxKind.KLong:
				case MetaModelSyntaxKind.KFloat:
				case MetaModelSyntaxKind.KDouble:
				case MetaModelSyntaxKind.KByte:
				case MetaModelSyntaxKind.KBool:
				case MetaModelSyntaxKind.KList:
				case MetaModelSyntaxKind.KAny:
				case MetaModelSyntaxKind.KNone:
				case MetaModelSyntaxKind.KError:
				case MetaModelSyntaxKind.KSet:
				case MetaModelSyntaxKind.KMultiList:
				case MetaModelSyntaxKind.KMultiSet:
				case MetaModelSyntaxKind.KThis:
				case MetaModelSyntaxKind.KTypeof:
				case MetaModelSyntaxKind.KAs:
				case MetaModelSyntaxKind.KIs:
				case MetaModelSyntaxKind.KBase:
				case MetaModelSyntaxKind.KConst:
				case MetaModelSyntaxKind.KRedefines:
				case MetaModelSyntaxKind.KSubsets:
				case MetaModelSyntaxKind.KReadonly:
				case MetaModelSyntaxKind.KLazy:
				case MetaModelSyntaxKind.KSynthetized:
				case MetaModelSyntaxKind.KInherited:
				case MetaModelSyntaxKind.KDerived:
				case MetaModelSyntaxKind.KStatic:
					return true;
				default:
					return false;
			}
		}
		public bool IsIdentifier(int rawKind)
		{
			return this.IsIdentifier((MetaModelSyntaxKind)rawKind);
		}

		public bool IsIdentifier(MetaModelSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaModelSyntaxKind.IdentifierNormal:
					return true;
				default:
					return false;
			}
		}
		public bool IsNumber(int rawKind)
		{
			return this.IsNumber((MetaModelSyntaxKind)rawKind);
		}

		public bool IsNumber(MetaModelSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaModelSyntaxKind.LInteger:
					return true;
				case MetaModelSyntaxKind.LDecimal:
					return true;
				case MetaModelSyntaxKind.LScientific:
					return true;
				case MetaModelSyntaxKind.LDateTimeOffset:
					return true;
				case MetaModelSyntaxKind.LDateTime:
					return true;
				case MetaModelSyntaxKind.LDate:
					return true;
				case MetaModelSyntaxKind.LTime:
					return true;
				default:
					return false;
			}
		}
		public bool IsString(int rawKind)
		{
			return this.IsString((MetaModelSyntaxKind)rawKind);
		}

		public bool IsString(MetaModelSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaModelSyntaxKind.LRegularString:
					return true;
				case MetaModelSyntaxKind.LGuid:
					return true;
				case MetaModelSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case MetaModelSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(int rawKind)
		{
			return this.IsWhitespace((MetaModelSyntaxKind)rawKind);
		}

		public bool IsWhitespace(MetaModelSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaModelSyntaxKind.LUtf8Bom:
					return true;
				case MetaModelSyntaxKind.LWhiteSpace:
					return true;
				case MetaModelSyntaxKind.LCrLf:
					return true;
				case MetaModelSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsComment(int rawKind)
		{
			return this.IsComment((MetaModelSyntaxKind)rawKind);
		}

		public bool IsComment(MetaModelSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaModelSyntaxKind.LSingleLineComment:
					return true;
				case MetaModelSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}

		public MetaModelTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind((MetaModelSyntaxKind)rawKind);
		}

		public MetaModelTokenKind GetTokenKind(MetaModelSyntaxKind kind)
		{
			switch(kind)
			{
				case MetaModelSyntaxKind.KNamespace:
				case MetaModelSyntaxKind.KUsing:
				case MetaModelSyntaxKind.KMetamodel:
				case MetaModelSyntaxKind.KExtern:
				case MetaModelSyntaxKind.KTypeDef:
				case MetaModelSyntaxKind.KAbstract:
				case MetaModelSyntaxKind.KClass:
				case MetaModelSyntaxKind.KEnum:
				case MetaModelSyntaxKind.KAssociation:
				case MetaModelSyntaxKind.KContainment:
				case MetaModelSyntaxKind.KWith:
				case MetaModelSyntaxKind.KNew:
				case MetaModelSyntaxKind.KNull:
				case MetaModelSyntaxKind.KTrue:
				case MetaModelSyntaxKind.KFalse:
				case MetaModelSyntaxKind.KVoid:
				case MetaModelSyntaxKind.KObject:
				case MetaModelSyntaxKind.KSymbol:
				case MetaModelSyntaxKind.KString:
				case MetaModelSyntaxKind.KInt:
				case MetaModelSyntaxKind.KLong:
				case MetaModelSyntaxKind.KFloat:
				case MetaModelSyntaxKind.KDouble:
				case MetaModelSyntaxKind.KByte:
				case MetaModelSyntaxKind.KBool:
				case MetaModelSyntaxKind.KList:
				case MetaModelSyntaxKind.KAny:
				case MetaModelSyntaxKind.KNone:
				case MetaModelSyntaxKind.KError:
				case MetaModelSyntaxKind.KSet:
				case MetaModelSyntaxKind.KMultiList:
				case MetaModelSyntaxKind.KMultiSet:
				case MetaModelSyntaxKind.KThis:
				case MetaModelSyntaxKind.KTypeof:
				case MetaModelSyntaxKind.KAs:
				case MetaModelSyntaxKind.KIs:
				case MetaModelSyntaxKind.KBase:
				case MetaModelSyntaxKind.KConst:
				case MetaModelSyntaxKind.KRedefines:
				case MetaModelSyntaxKind.KSubsets:
				case MetaModelSyntaxKind.KReadonly:
				case MetaModelSyntaxKind.KLazy:
				case MetaModelSyntaxKind.KSynthetized:
				case MetaModelSyntaxKind.KInherited:
				case MetaModelSyntaxKind.KDerived:
				case MetaModelSyntaxKind.KStatic:
					return MetaModelTokenKind.Keyword;
				case MetaModelSyntaxKind.IdentifierNormal:
					return MetaModelTokenKind.Identifier;
				case MetaModelSyntaxKind.LInteger:
					return MetaModelTokenKind.Number;
				case MetaModelSyntaxKind.LDecimal:
					return MetaModelTokenKind.Number;
				case MetaModelSyntaxKind.LScientific:
					return MetaModelTokenKind.Number;
				case MetaModelSyntaxKind.LDateTimeOffset:
					return MetaModelTokenKind.Number;
				case MetaModelSyntaxKind.LDateTime:
					return MetaModelTokenKind.Number;
				case MetaModelSyntaxKind.LDate:
					return MetaModelTokenKind.Number;
				case MetaModelSyntaxKind.LTime:
					return MetaModelTokenKind.Number;
				case MetaModelSyntaxKind.LRegularString:
					return MetaModelTokenKind.String;
				case MetaModelSyntaxKind.LGuid:
					return MetaModelTokenKind.String;
				case MetaModelSyntaxKind.LUtf8Bom:
					return MetaModelTokenKind.Whitespace;
				case MetaModelSyntaxKind.LWhiteSpace:
					return MetaModelTokenKind.Whitespace;
				case MetaModelSyntaxKind.LCrLf:
					return MetaModelTokenKind.Whitespace;
				case MetaModelSyntaxKind.LLineEnd:
					return MetaModelTokenKind.Whitespace;
				case MetaModelSyntaxKind.LSingleLineComment:
					return MetaModelTokenKind.Comment;
				case MetaModelSyntaxKind.LComment:
					return MetaModelTokenKind.Comment;
				case MetaModelSyntaxKind.LDoubleQuoteVerbatimString:
					return MetaModelTokenKind.String;
				case MetaModelSyntaxKind.LSingleQuoteVerbatimString:
					return MetaModelTokenKind.String;
				default:
					return MetaModelTokenKind.None;
			}
		}
	}
}

