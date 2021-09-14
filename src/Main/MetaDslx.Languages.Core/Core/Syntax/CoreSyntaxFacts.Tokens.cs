// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Core.Syntax
{
	public enum CoreTokenKind : int
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

	public enum CoreLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		LMultilineComment = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class CoreTokensSyntaxFacts : SyntaxFacts
	{
        public CoreTokensSyntaxFacts() 
            : base(typeof(CoreTokensSyntaxKind))
        {
        }

        protected CoreTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (CoreTokensSyntaxKind)CoreTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (CoreTokensSyntaxKind)CoreTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (CoreTokensSyntaxKind)CoreTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (CoreTokensSyntaxKind)CoreTokensSyntaxKind.IdentifierNormal;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case CoreTokensSyntaxKind.Eof:
				case CoreTokensSyntaxKind.KNamespace:
				case CoreTokensSyntaxKind.KUsing:
				case CoreTokensSyntaxKind.KExtern:
				case CoreTokensSyntaxKind.KAbstract:
				case CoreTokensSyntaxKind.KInterface:
				case CoreTokensSyntaxKind.KClass:
				case CoreTokensSyntaxKind.KStruct:
				case CoreTokensSyntaxKind.KEnum:
				case CoreTokensSyntaxKind.KNew:
				case CoreTokensSyntaxKind.KNull:
				case CoreTokensSyntaxKind.KTrue:
				case CoreTokensSyntaxKind.KFalse:
				case CoreTokensSyntaxKind.KObject:
				case CoreTokensSyntaxKind.KVoid:
				case CoreTokensSyntaxKind.KBool:
				case CoreTokensSyntaxKind.KChar:
				case CoreTokensSyntaxKind.KSByte:
				case CoreTokensSyntaxKind.KByte:
				case CoreTokensSyntaxKind.KShort:
				case CoreTokensSyntaxKind.KUShort:
				case CoreTokensSyntaxKind.KInt:
				case CoreTokensSyntaxKind.KUInt:
				case CoreTokensSyntaxKind.KLong:
				case CoreTokensSyntaxKind.KULong:
				case CoreTokensSyntaxKind.KDecimal:
				case CoreTokensSyntaxKind.KFloat:
				case CoreTokensSyntaxKind.KDouble:
				case CoreTokensSyntaxKind.KString:
				case CoreTokensSyntaxKind.KTypeof:
				case CoreTokensSyntaxKind.KNameof:
				case CoreTokensSyntaxKind.KSizeof:
				case CoreTokensSyntaxKind.KDefault:
				case CoreTokensSyntaxKind.KChecked:
				case CoreTokensSyntaxKind.KUnchecked:
				case CoreTokensSyntaxKind.KAs:
				case CoreTokensSyntaxKind.KIs:
				case CoreTokensSyntaxKind.KNot:
				case CoreTokensSyntaxKind.KThis:
				case CoreTokensSyntaxKind.KBase:
				case CoreTokensSyntaxKind.KConst:
				case CoreTokensSyntaxKind.KReadonly:
				case CoreTokensSyntaxKind.KStatic:
				case CoreTokensSyntaxKind.TSemicolon:
				case CoreTokensSyntaxKind.TColon:
				case CoreTokensSyntaxKind.TDot:
				case CoreTokensSyntaxKind.TComma:
				case CoreTokensSyntaxKind.TAssign:
				case CoreTokensSyntaxKind.TOpenParen:
				case CoreTokensSyntaxKind.TCloseParen:
				case CoreTokensSyntaxKind.TOpenBracket:
				case CoreTokensSyntaxKind.TCloseBracket:
				case CoreTokensSyntaxKind.TOpenBrace:
				case CoreTokensSyntaxKind.TCloseBrace:
				case CoreTokensSyntaxKind.TLessThan:
				case CoreTokensSyntaxKind.TGreaterThan:
				case CoreTokensSyntaxKind.TQuestion:
				case CoreTokensSyntaxKind.TQuestionDot:
				case CoreTokensSyntaxKind.TQuestionOpenBracket:
				case CoreTokensSyntaxKind.TQuestionQuestion:
				case CoreTokensSyntaxKind.TAmpersand:
				case CoreTokensSyntaxKind.THat:
				case CoreTokensSyntaxKind.TBar:
				case CoreTokensSyntaxKind.TAndAlso:
				case CoreTokensSyntaxKind.TOrElse:
				case CoreTokensSyntaxKind.TPlusPlus:
				case CoreTokensSyntaxKind.TMinusMinus:
				case CoreTokensSyntaxKind.TPlus:
				case CoreTokensSyntaxKind.TMinus:
				case CoreTokensSyntaxKind.TTilde:
				case CoreTokensSyntaxKind.TExclamation:
				case CoreTokensSyntaxKind.TSlash:
				case CoreTokensSyntaxKind.TAsterisk:
				case CoreTokensSyntaxKind.TPercent:
				case CoreTokensSyntaxKind.TLessThanOrEqual:
				case CoreTokensSyntaxKind.TGreaterThanOrEqual:
				case CoreTokensSyntaxKind.TEqual:
				case CoreTokensSyntaxKind.TNotEqual:
				case CoreTokensSyntaxKind.TAsteriskAssign:
				case CoreTokensSyntaxKind.TSlashAssign:
				case CoreTokensSyntaxKind.TPercentAssign:
				case CoreTokensSyntaxKind.TPlusAssign:
				case CoreTokensSyntaxKind.TMinusAssign:
				case CoreTokensSyntaxKind.TLeftShiftAssign:
				case CoreTokensSyntaxKind.TRightShiftAssign:
				case CoreTokensSyntaxKind.TAmpersandAssign:
				case CoreTokensSyntaxKind.THatAssign:
				case CoreTokensSyntaxKind.TBarAssign:
				case CoreTokensSyntaxKind.IdentifierNormal:
				case CoreTokensSyntaxKind.IdentifierVerbatim:
				case CoreTokensSyntaxKind.LInteger:
				case CoreTokensSyntaxKind.LDecimal:
				case CoreTokensSyntaxKind.LScientific:
				case CoreTokensSyntaxKind.LDateTimeOffset:
				case CoreTokensSyntaxKind.LDateTime:
				case CoreTokensSyntaxKind.LDate:
				case CoreTokensSyntaxKind.LTime:
				case CoreTokensSyntaxKind.LRegularString:
				case CoreTokensSyntaxKind.LGuid:
				case CoreTokensSyntaxKind.LUtf8Bom:
				case CoreTokensSyntaxKind.LWhiteSpace:
				case CoreTokensSyntaxKind.LCrLf:
				case CoreTokensSyntaxKind.LLineEnd:
				case CoreTokensSyntaxKind.LSingleLineComment:
				case CoreTokensSyntaxKind.LComment:
				case CoreTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case CoreTokensSyntaxKind.LSingleQuoteVerbatimString:
				case CoreTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case CoreTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case CoreTokensSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case CoreTokensSyntaxKind.KNamespace:
				case CoreTokensSyntaxKind.KUsing:
				case CoreTokensSyntaxKind.KExtern:
				case CoreTokensSyntaxKind.KAbstract:
				case CoreTokensSyntaxKind.KInterface:
				case CoreTokensSyntaxKind.KClass:
				case CoreTokensSyntaxKind.KStruct:
				case CoreTokensSyntaxKind.KEnum:
				case CoreTokensSyntaxKind.KNew:
				case CoreTokensSyntaxKind.KNull:
				case CoreTokensSyntaxKind.KTrue:
				case CoreTokensSyntaxKind.KFalse:
				case CoreTokensSyntaxKind.KObject:
				case CoreTokensSyntaxKind.KVoid:
				case CoreTokensSyntaxKind.KBool:
				case CoreTokensSyntaxKind.KChar:
				case CoreTokensSyntaxKind.KSByte:
				case CoreTokensSyntaxKind.KByte:
				case CoreTokensSyntaxKind.KShort:
				case CoreTokensSyntaxKind.KUShort:
				case CoreTokensSyntaxKind.KInt:
				case CoreTokensSyntaxKind.KUInt:
				case CoreTokensSyntaxKind.KLong:
				case CoreTokensSyntaxKind.KULong:
				case CoreTokensSyntaxKind.KDecimal:
				case CoreTokensSyntaxKind.KFloat:
				case CoreTokensSyntaxKind.KDouble:
				case CoreTokensSyntaxKind.KString:
				case CoreTokensSyntaxKind.KTypeof:
				case CoreTokensSyntaxKind.KNameof:
				case CoreTokensSyntaxKind.KSizeof:
				case CoreTokensSyntaxKind.KDefault:
				case CoreTokensSyntaxKind.KChecked:
				case CoreTokensSyntaxKind.KUnchecked:
				case CoreTokensSyntaxKind.KAs:
				case CoreTokensSyntaxKind.KIs:
				case CoreTokensSyntaxKind.KNot:
				case CoreTokensSyntaxKind.KThis:
				case CoreTokensSyntaxKind.KBase:
				case CoreTokensSyntaxKind.KConst:
				case CoreTokensSyntaxKind.KReadonly:
				case CoreTokensSyntaxKind.KStatic:
				case CoreTokensSyntaxKind.TSemicolon:
				case CoreTokensSyntaxKind.TColon:
				case CoreTokensSyntaxKind.TDot:
				case CoreTokensSyntaxKind.TComma:
				case CoreTokensSyntaxKind.TAssign:
				case CoreTokensSyntaxKind.TOpenParen:
				case CoreTokensSyntaxKind.TCloseParen:
				case CoreTokensSyntaxKind.TOpenBracket:
				case CoreTokensSyntaxKind.TCloseBracket:
				case CoreTokensSyntaxKind.TOpenBrace:
				case CoreTokensSyntaxKind.TCloseBrace:
				case CoreTokensSyntaxKind.TLessThan:
				case CoreTokensSyntaxKind.TGreaterThan:
				case CoreTokensSyntaxKind.TQuestion:
				case CoreTokensSyntaxKind.TQuestionDot:
				case CoreTokensSyntaxKind.TQuestionOpenBracket:
				case CoreTokensSyntaxKind.TQuestionQuestion:
				case CoreTokensSyntaxKind.TAmpersand:
				case CoreTokensSyntaxKind.THat:
				case CoreTokensSyntaxKind.TBar:
				case CoreTokensSyntaxKind.TAndAlso:
				case CoreTokensSyntaxKind.TOrElse:
				case CoreTokensSyntaxKind.TPlusPlus:
				case CoreTokensSyntaxKind.TMinusMinus:
				case CoreTokensSyntaxKind.TPlus:
				case CoreTokensSyntaxKind.TMinus:
				case CoreTokensSyntaxKind.TTilde:
				case CoreTokensSyntaxKind.TExclamation:
				case CoreTokensSyntaxKind.TSlash:
				case CoreTokensSyntaxKind.TPercent:
				case CoreTokensSyntaxKind.TLessThanOrEqual:
				case CoreTokensSyntaxKind.TGreaterThanOrEqual:
				case CoreTokensSyntaxKind.TEqual:
				case CoreTokensSyntaxKind.TNotEqual:
				case CoreTokensSyntaxKind.TAsteriskAssign:
				case CoreTokensSyntaxKind.TSlashAssign:
				case CoreTokensSyntaxKind.TPercentAssign:
				case CoreTokensSyntaxKind.TPlusAssign:
				case CoreTokensSyntaxKind.TMinusAssign:
				case CoreTokensSyntaxKind.TLeftShiftAssign:
				case CoreTokensSyntaxKind.TRightShiftAssign:
				case CoreTokensSyntaxKind.TAmpersandAssign:
				case CoreTokensSyntaxKind.THatAssign:
				case CoreTokensSyntaxKind.TBarAssign:
				case CoreTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case CoreTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case CoreTokensSyntaxKind.LCommentStart:
				case CoreTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case CoreTokensSyntaxKind.LSingleQuoteVerbatimString:
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
					return CoreTokensSyntaxKind.KNamespace;
				case "using":
					return CoreTokensSyntaxKind.KUsing;
				case "extern":
					return CoreTokensSyntaxKind.KExtern;
				case "abstract":
					return CoreTokensSyntaxKind.KAbstract;
				case "interface":
					return CoreTokensSyntaxKind.KInterface;
				case "class":
					return CoreTokensSyntaxKind.KClass;
				case "struct":
					return CoreTokensSyntaxKind.KStruct;
				case "enum":
					return CoreTokensSyntaxKind.KEnum;
				case "new":
					return CoreTokensSyntaxKind.KNew;
				case "null":
					return CoreTokensSyntaxKind.KNull;
				case "true":
					return CoreTokensSyntaxKind.KTrue;
				case "false":
					return CoreTokensSyntaxKind.KFalse;
				case "object":
					return CoreTokensSyntaxKind.KObject;
				case "void":
					return CoreTokensSyntaxKind.KVoid;
				case "bool":
					return CoreTokensSyntaxKind.KBool;
				case "char":
					return CoreTokensSyntaxKind.KChar;
				case "sbyte":
					return CoreTokensSyntaxKind.KSByte;
				case "byte":
					return CoreTokensSyntaxKind.KByte;
				case "short":
					return CoreTokensSyntaxKind.KShort;
				case "ushort":
					return CoreTokensSyntaxKind.KUShort;
				case "int":
					return CoreTokensSyntaxKind.KInt;
				case "uint":
					return CoreTokensSyntaxKind.KUInt;
				case "long":
					return CoreTokensSyntaxKind.KLong;
				case "ulong":
					return CoreTokensSyntaxKind.KULong;
				case "decimal":
					return CoreTokensSyntaxKind.KDecimal;
				case "float":
					return CoreTokensSyntaxKind.KFloat;
				case "double":
					return CoreTokensSyntaxKind.KDouble;
				case "string":
					return CoreTokensSyntaxKind.KString;
				case "typeof":
					return CoreTokensSyntaxKind.KTypeof;
				case "nameof":
					return CoreTokensSyntaxKind.KNameof;
				case "sizeof":
					return CoreTokensSyntaxKind.KSizeof;
				case "default":
					return CoreTokensSyntaxKind.KDefault;
				case "checked":
					return CoreTokensSyntaxKind.KChecked;
				case "unchecked":
					return CoreTokensSyntaxKind.KUnchecked;
				case "as":
					return CoreTokensSyntaxKind.KAs;
				case "is":
					return CoreTokensSyntaxKind.KIs;
				case "not":
					return CoreTokensSyntaxKind.KNot;
				case "this":
					return CoreTokensSyntaxKind.KThis;
				case "base":
					return CoreTokensSyntaxKind.KBase;
				case "const":
					return CoreTokensSyntaxKind.KConst;
				case "readonly":
					return CoreTokensSyntaxKind.KReadonly;
				case "static":
					return CoreTokensSyntaxKind.KStatic;
				case ";":
					return CoreTokensSyntaxKind.TSemicolon;
				case ":":
					return CoreTokensSyntaxKind.TColon;
				case ".":
					return CoreTokensSyntaxKind.TDot;
				case ",":
					return CoreTokensSyntaxKind.TComma;
				case "=":
					return CoreTokensSyntaxKind.TAssign;
				case "(":
					return CoreTokensSyntaxKind.TOpenParen;
				case ")":
					return CoreTokensSyntaxKind.TCloseParen;
				case "[":
					return CoreTokensSyntaxKind.TOpenBracket;
				case "]":
					return CoreTokensSyntaxKind.TCloseBracket;
				case "{":
					return CoreTokensSyntaxKind.TOpenBrace;
				case "}":
					return CoreTokensSyntaxKind.TCloseBrace;
				case "<":
					return CoreTokensSyntaxKind.TLessThan;
				case ">":
					return CoreTokensSyntaxKind.TGreaterThan;
				case "?":
					return CoreTokensSyntaxKind.TQuestion;
				case "?.":
					return CoreTokensSyntaxKind.TQuestionDot;
				case "?[":
					return CoreTokensSyntaxKind.TQuestionOpenBracket;
				case "??":
					return CoreTokensSyntaxKind.TQuestionQuestion;
				case "&":
					return CoreTokensSyntaxKind.TAmpersand;
				case "^":
					return CoreTokensSyntaxKind.THat;
				case "|":
					return CoreTokensSyntaxKind.TBar;
				case "&&":
					return CoreTokensSyntaxKind.TAndAlso;
				case "||":
					return CoreTokensSyntaxKind.TOrElse;
				case "++":
					return CoreTokensSyntaxKind.TPlusPlus;
				case "--":
					return CoreTokensSyntaxKind.TMinusMinus;
				case "+":
					return CoreTokensSyntaxKind.TPlus;
				case "-":
					return CoreTokensSyntaxKind.TMinus;
				case "~":
					return CoreTokensSyntaxKind.TTilde;
				case "!":
					return CoreTokensSyntaxKind.TExclamation;
				case "/":
					return CoreTokensSyntaxKind.TSlash;
				case "%":
					return CoreTokensSyntaxKind.TPercent;
				case "<=":
					return CoreTokensSyntaxKind.TLessThanOrEqual;
				case ">=":
					return CoreTokensSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return CoreTokensSyntaxKind.TEqual;
				case "!=":
					return CoreTokensSyntaxKind.TNotEqual;
				case "*=":
					return CoreTokensSyntaxKind.TAsteriskAssign;
				case "/=":
					return CoreTokensSyntaxKind.TSlashAssign;
				case "%=":
					return CoreTokensSyntaxKind.TPercentAssign;
				case "+=":
					return CoreTokensSyntaxKind.TPlusAssign;
				case "-=":
					return CoreTokensSyntaxKind.TMinusAssign;
				case "<<=":
					return CoreTokensSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return CoreTokensSyntaxKind.TRightShiftAssign;
				case "&=":
					return CoreTokensSyntaxKind.TAmpersandAssign;
				case "^=":
					return CoreTokensSyntaxKind.THatAssign;
				case "|=":
					return CoreTokensSyntaxKind.TBarAssign;
				case "@\"":
					return CoreTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return CoreTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return CoreTokensSyntaxKind.LCommentStart;
				case "\"":
					return CoreTokensSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return CoreTokensSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return CoreTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case CoreTokensSyntaxKind.KNamespace:
					return "namespace";
				case CoreTokensSyntaxKind.KUsing:
					return "using";
				case CoreTokensSyntaxKind.KExtern:
					return "extern";
				case CoreTokensSyntaxKind.KAbstract:
					return "abstract";
				case CoreTokensSyntaxKind.KInterface:
					return "interface";
				case CoreTokensSyntaxKind.KClass:
					return "class";
				case CoreTokensSyntaxKind.KStruct:
					return "struct";
				case CoreTokensSyntaxKind.KEnum:
					return "enum";
				case CoreTokensSyntaxKind.KNew:
					return "new";
				case CoreTokensSyntaxKind.KNull:
					return "null";
				case CoreTokensSyntaxKind.KTrue:
					return "true";
				case CoreTokensSyntaxKind.KFalse:
					return "false";
				case CoreTokensSyntaxKind.KObject:
					return "object";
				case CoreTokensSyntaxKind.KVoid:
					return "void";
				case CoreTokensSyntaxKind.KBool:
					return "bool";
				case CoreTokensSyntaxKind.KChar:
					return "char";
				case CoreTokensSyntaxKind.KSByte:
					return "sbyte";
				case CoreTokensSyntaxKind.KByte:
					return "byte";
				case CoreTokensSyntaxKind.KShort:
					return "short";
				case CoreTokensSyntaxKind.KUShort:
					return "ushort";
				case CoreTokensSyntaxKind.KInt:
					return "int";
				case CoreTokensSyntaxKind.KUInt:
					return "uint";
				case CoreTokensSyntaxKind.KLong:
					return "long";
				case CoreTokensSyntaxKind.KULong:
					return "ulong";
				case CoreTokensSyntaxKind.KDecimal:
					return "decimal";
				case CoreTokensSyntaxKind.KFloat:
					return "float";
				case CoreTokensSyntaxKind.KDouble:
					return "double";
				case CoreTokensSyntaxKind.KString:
					return "string";
				case CoreTokensSyntaxKind.KTypeof:
					return "typeof";
				case CoreTokensSyntaxKind.KNameof:
					return "nameof";
				case CoreTokensSyntaxKind.KSizeof:
					return "sizeof";
				case CoreTokensSyntaxKind.KDefault:
					return "default";
				case CoreTokensSyntaxKind.KChecked:
					return "checked";
				case CoreTokensSyntaxKind.KUnchecked:
					return "unchecked";
				case CoreTokensSyntaxKind.KAs:
					return "as";
				case CoreTokensSyntaxKind.KIs:
					return "is";
				case CoreTokensSyntaxKind.KNot:
					return "not";
				case CoreTokensSyntaxKind.KThis:
					return "this";
				case CoreTokensSyntaxKind.KBase:
					return "base";
				case CoreTokensSyntaxKind.KConst:
					return "const";
				case CoreTokensSyntaxKind.KReadonly:
					return "readonly";
				case CoreTokensSyntaxKind.KStatic:
					return "static";
				case CoreTokensSyntaxKind.TSemicolon:
					return ";";
				case CoreTokensSyntaxKind.TColon:
					return ":";
				case CoreTokensSyntaxKind.TDot:
					return ".";
				case CoreTokensSyntaxKind.TComma:
					return ",";
				case CoreTokensSyntaxKind.TAssign:
					return "=";
				case CoreTokensSyntaxKind.TOpenParen:
					return "(";
				case CoreTokensSyntaxKind.TCloseParen:
					return ")";
				case CoreTokensSyntaxKind.TOpenBracket:
					return "[";
				case CoreTokensSyntaxKind.TCloseBracket:
					return "]";
				case CoreTokensSyntaxKind.TOpenBrace:
					return "{";
				case CoreTokensSyntaxKind.TCloseBrace:
					return "}";
				case CoreTokensSyntaxKind.TLessThan:
					return "<";
				case CoreTokensSyntaxKind.TGreaterThan:
					return ">";
				case CoreTokensSyntaxKind.TQuestion:
					return "?";
				case CoreTokensSyntaxKind.TQuestionDot:
					return "?.";
				case CoreTokensSyntaxKind.TQuestionOpenBracket:
					return "?[";
				case CoreTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case CoreTokensSyntaxKind.TAmpersand:
					return "&";
				case CoreTokensSyntaxKind.THat:
					return "^";
				case CoreTokensSyntaxKind.TBar:
					return "|";
				case CoreTokensSyntaxKind.TAndAlso:
					return "&&";
				case CoreTokensSyntaxKind.TOrElse:
					return "||";
				case CoreTokensSyntaxKind.TPlusPlus:
					return "++";
				case CoreTokensSyntaxKind.TMinusMinus:
					return "--";
				case CoreTokensSyntaxKind.TPlus:
					return "+";
				case CoreTokensSyntaxKind.TMinus:
					return "-";
				case CoreTokensSyntaxKind.TTilde:
					return "~";
				case CoreTokensSyntaxKind.TExclamation:
					return "!";
				case CoreTokensSyntaxKind.TSlash:
					return "/";
				case CoreTokensSyntaxKind.TPercent:
					return "%";
				case CoreTokensSyntaxKind.TLessThanOrEqual:
					return "<=";
				case CoreTokensSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case CoreTokensSyntaxKind.TEqual:
					return "==";
				case CoreTokensSyntaxKind.TNotEqual:
					return "!=";
				case CoreTokensSyntaxKind.TAsteriskAssign:
					return "*=";
				case CoreTokensSyntaxKind.TSlashAssign:
					return "/=";
				case CoreTokensSyntaxKind.TPercentAssign:
					return "%=";
				case CoreTokensSyntaxKind.TPlusAssign:
					return "+=";
				case CoreTokensSyntaxKind.TMinusAssign:
					return "-=";
				case CoreTokensSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case CoreTokensSyntaxKind.TRightShiftAssign:
					return ">>=";
				case CoreTokensSyntaxKind.TAmpersandAssign:
					return "&=";
				case CoreTokensSyntaxKind.THatAssign:
					return "^=";
				case CoreTokensSyntaxKind.TBarAssign:
					return "|=";
				case CoreTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case CoreTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case CoreTokensSyntaxKind.LCommentStart:
					return "/*";
				case CoreTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case CoreTokensSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public CoreTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<CoreTokensSyntaxKind>(rawKind));
		}

		public CoreTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CoreTokensSyntaxKind.KNamespace:
				case CoreTokensSyntaxKind.KUsing:
				case CoreTokensSyntaxKind.KExtern:
				case CoreTokensSyntaxKind.KAbstract:
				case CoreTokensSyntaxKind.KInterface:
				case CoreTokensSyntaxKind.KClass:
				case CoreTokensSyntaxKind.KStruct:
				case CoreTokensSyntaxKind.KEnum:
				case CoreTokensSyntaxKind.KNew:
				case CoreTokensSyntaxKind.KNull:
				case CoreTokensSyntaxKind.KTrue:
				case CoreTokensSyntaxKind.KFalse:
				case CoreTokensSyntaxKind.KObject:
				case CoreTokensSyntaxKind.KVoid:
				case CoreTokensSyntaxKind.KBool:
				case CoreTokensSyntaxKind.KChar:
				case CoreTokensSyntaxKind.KSByte:
				case CoreTokensSyntaxKind.KByte:
				case CoreTokensSyntaxKind.KShort:
				case CoreTokensSyntaxKind.KUShort:
				case CoreTokensSyntaxKind.KInt:
				case CoreTokensSyntaxKind.KUInt:
				case CoreTokensSyntaxKind.KLong:
				case CoreTokensSyntaxKind.KULong:
				case CoreTokensSyntaxKind.KDecimal:
				case CoreTokensSyntaxKind.KFloat:
				case CoreTokensSyntaxKind.KDouble:
				case CoreTokensSyntaxKind.KString:
				case CoreTokensSyntaxKind.KTypeof:
				case CoreTokensSyntaxKind.KNameof:
				case CoreTokensSyntaxKind.KSizeof:
				case CoreTokensSyntaxKind.KDefault:
				case CoreTokensSyntaxKind.KChecked:
				case CoreTokensSyntaxKind.KUnchecked:
				case CoreTokensSyntaxKind.KAs:
				case CoreTokensSyntaxKind.KIs:
				case CoreTokensSyntaxKind.KNot:
				case CoreTokensSyntaxKind.KThis:
				case CoreTokensSyntaxKind.KBase:
				case CoreTokensSyntaxKind.KConst:
				case CoreTokensSyntaxKind.KReadonly:
				case CoreTokensSyntaxKind.KStatic:
					return CoreTokenKind.ReservedKeyword;
				case CoreTokensSyntaxKind.IdentifierNormal:
					return CoreTokenKind.Identifier;
				case CoreTokensSyntaxKind.LInteger:
					return CoreTokenKind.Number;
				case CoreTokensSyntaxKind.LDecimal:
					return CoreTokenKind.Number;
				case CoreTokensSyntaxKind.LScientific:
					return CoreTokenKind.Number;
				case CoreTokensSyntaxKind.LDateTimeOffset:
					return CoreTokenKind.Number;
				case CoreTokensSyntaxKind.LDateTime:
					return CoreTokenKind.Number;
				case CoreTokensSyntaxKind.LDate:
					return CoreTokenKind.Number;
				case CoreTokensSyntaxKind.LTime:
					return CoreTokenKind.Number;
				case CoreTokensSyntaxKind.LRegularString:
					return CoreTokenKind.String;
				case CoreTokensSyntaxKind.LGuid:
					return CoreTokenKind.String;
				case CoreTokensSyntaxKind.LUtf8Bom:
					return CoreTokenKind.Whitespace;
				case CoreTokensSyntaxKind.LWhiteSpace:
					return CoreTokenKind.Whitespace;
				case CoreTokensSyntaxKind.LCrLf:
					return CoreTokenKind.Whitespace;
				case CoreTokensSyntaxKind.LLineEnd:
					return CoreTokenKind.Whitespace;
				case CoreTokensSyntaxKind.LSingleLineComment:
					return CoreTokenKind.GeneralComment;
				case CoreTokensSyntaxKind.LComment:
					return CoreTokenKind.GeneralComment;
				case CoreTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return CoreTokenKind.String;
				case CoreTokensSyntaxKind.LSingleQuoteVerbatimString:
					return CoreTokenKind.String;
				default:
					return CoreTokenKind.None;
			}
		}

		public CoreTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((CoreLexerMode)rawKind);
		}

		public CoreTokenKind GetModeTokenKind(CoreLexerMode kind)
		{
			switch(kind)
			{
				case CoreLexerMode.LMultilineComment:
					return CoreTokenKind.GeneralComment;
				case CoreLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return CoreTokenKind.String;
				case CoreLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return CoreTokenKind.String;
				default:
					return CoreTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CoreTokensSyntaxKind.LCrLf:
					return true;
				case CoreTokensSyntaxKind.LLineEnd:
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
				case CoreTokensSyntaxKind.KNamespace:
				case CoreTokensSyntaxKind.KUsing:
				case CoreTokensSyntaxKind.KExtern:
				case CoreTokensSyntaxKind.KAbstract:
				case CoreTokensSyntaxKind.KInterface:
				case CoreTokensSyntaxKind.KClass:
				case CoreTokensSyntaxKind.KStruct:
				case CoreTokensSyntaxKind.KEnum:
				case CoreTokensSyntaxKind.KNew:
				case CoreTokensSyntaxKind.KNull:
				case CoreTokensSyntaxKind.KTrue:
				case CoreTokensSyntaxKind.KFalse:
				case CoreTokensSyntaxKind.KObject:
				case CoreTokensSyntaxKind.KVoid:
				case CoreTokensSyntaxKind.KBool:
				case CoreTokensSyntaxKind.KChar:
				case CoreTokensSyntaxKind.KSByte:
				case CoreTokensSyntaxKind.KByte:
				case CoreTokensSyntaxKind.KShort:
				case CoreTokensSyntaxKind.KUShort:
				case CoreTokensSyntaxKind.KInt:
				case CoreTokensSyntaxKind.KUInt:
				case CoreTokensSyntaxKind.KLong:
				case CoreTokensSyntaxKind.KULong:
				case CoreTokensSyntaxKind.KDecimal:
				case CoreTokensSyntaxKind.KFloat:
				case CoreTokensSyntaxKind.KDouble:
				case CoreTokensSyntaxKind.KString:
				case CoreTokensSyntaxKind.KTypeof:
				case CoreTokensSyntaxKind.KNameof:
				case CoreTokensSyntaxKind.KSizeof:
				case CoreTokensSyntaxKind.KDefault:
				case CoreTokensSyntaxKind.KChecked:
				case CoreTokensSyntaxKind.KUnchecked:
				case CoreTokensSyntaxKind.KAs:
				case CoreTokensSyntaxKind.KIs:
				case CoreTokensSyntaxKind.KNot:
				case CoreTokensSyntaxKind.KThis:
				case CoreTokensSyntaxKind.KBase:
				case CoreTokensSyntaxKind.KConst:
				case CoreTokensSyntaxKind.KReadonly:
				case CoreTokensSyntaxKind.KStatic:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return CoreTokensSyntaxKind.KNamespace;
				yield return CoreTokensSyntaxKind.KUsing;
				yield return CoreTokensSyntaxKind.KExtern;
				yield return CoreTokensSyntaxKind.KAbstract;
				yield return CoreTokensSyntaxKind.KInterface;
				yield return CoreTokensSyntaxKind.KClass;
				yield return CoreTokensSyntaxKind.KStruct;
				yield return CoreTokensSyntaxKind.KEnum;
				yield return CoreTokensSyntaxKind.KNew;
				yield return CoreTokensSyntaxKind.KNull;
				yield return CoreTokensSyntaxKind.KTrue;
				yield return CoreTokensSyntaxKind.KFalse;
				yield return CoreTokensSyntaxKind.KObject;
				yield return CoreTokensSyntaxKind.KVoid;
				yield return CoreTokensSyntaxKind.KBool;
				yield return CoreTokensSyntaxKind.KChar;
				yield return CoreTokensSyntaxKind.KSByte;
				yield return CoreTokensSyntaxKind.KByte;
				yield return CoreTokensSyntaxKind.KShort;
				yield return CoreTokensSyntaxKind.KUShort;
				yield return CoreTokensSyntaxKind.KInt;
				yield return CoreTokensSyntaxKind.KUInt;
				yield return CoreTokensSyntaxKind.KLong;
				yield return CoreTokensSyntaxKind.KULong;
				yield return CoreTokensSyntaxKind.KDecimal;
				yield return CoreTokensSyntaxKind.KFloat;
				yield return CoreTokensSyntaxKind.KDouble;
				yield return CoreTokensSyntaxKind.KString;
				yield return CoreTokensSyntaxKind.KTypeof;
				yield return CoreTokensSyntaxKind.KNameof;
				yield return CoreTokensSyntaxKind.KSizeof;
				yield return CoreTokensSyntaxKind.KDefault;
				yield return CoreTokensSyntaxKind.KChecked;
				yield return CoreTokensSyntaxKind.KUnchecked;
				yield return CoreTokensSyntaxKind.KAs;
				yield return CoreTokensSyntaxKind.KIs;
				yield return CoreTokensSyntaxKind.KNot;
				yield return CoreTokensSyntaxKind.KThis;
				yield return CoreTokensSyntaxKind.KBase;
				yield return CoreTokensSyntaxKind.KConst;
				yield return CoreTokensSyntaxKind.KReadonly;
				yield return CoreTokensSyntaxKind.KStatic;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return CoreTokensSyntaxKind.KNamespace;
				case "using":
					return CoreTokensSyntaxKind.KUsing;
				case "extern":
					return CoreTokensSyntaxKind.KExtern;
				case "abstract":
					return CoreTokensSyntaxKind.KAbstract;
				case "interface":
					return CoreTokensSyntaxKind.KInterface;
				case "class":
					return CoreTokensSyntaxKind.KClass;
				case "struct":
					return CoreTokensSyntaxKind.KStruct;
				case "enum":
					return CoreTokensSyntaxKind.KEnum;
				case "new":
					return CoreTokensSyntaxKind.KNew;
				case "null":
					return CoreTokensSyntaxKind.KNull;
				case "true":
					return CoreTokensSyntaxKind.KTrue;
				case "false":
					return CoreTokensSyntaxKind.KFalse;
				case "object":
					return CoreTokensSyntaxKind.KObject;
				case "void":
					return CoreTokensSyntaxKind.KVoid;
				case "bool":
					return CoreTokensSyntaxKind.KBool;
				case "char":
					return CoreTokensSyntaxKind.KChar;
				case "sbyte":
					return CoreTokensSyntaxKind.KSByte;
				case "byte":
					return CoreTokensSyntaxKind.KByte;
				case "short":
					return CoreTokensSyntaxKind.KShort;
				case "ushort":
					return CoreTokensSyntaxKind.KUShort;
				case "int":
					return CoreTokensSyntaxKind.KInt;
				case "uint":
					return CoreTokensSyntaxKind.KUInt;
				case "long":
					return CoreTokensSyntaxKind.KLong;
				case "ulong":
					return CoreTokensSyntaxKind.KULong;
				case "decimal":
					return CoreTokensSyntaxKind.KDecimal;
				case "float":
					return CoreTokensSyntaxKind.KFloat;
				case "double":
					return CoreTokensSyntaxKind.KDouble;
				case "string":
					return CoreTokensSyntaxKind.KString;
				case "typeof":
					return CoreTokensSyntaxKind.KTypeof;
				case "nameof":
					return CoreTokensSyntaxKind.KNameof;
				case "sizeof":
					return CoreTokensSyntaxKind.KSizeof;
				case "default":
					return CoreTokensSyntaxKind.KDefault;
				case "checked":
					return CoreTokensSyntaxKind.KChecked;
				case "unchecked":
					return CoreTokensSyntaxKind.KUnchecked;
				case "as":
					return CoreTokensSyntaxKind.KAs;
				case "is":
					return CoreTokensSyntaxKind.KIs;
				case "not":
					return CoreTokensSyntaxKind.KNot;
				case "this":
					return CoreTokensSyntaxKind.KThis;
				case "base":
					return CoreTokensSyntaxKind.KBase;
				case "const":
					return CoreTokensSyntaxKind.KConst;
				case "readonly":
					return CoreTokensSyntaxKind.KReadonly;
				case "static":
					return CoreTokensSyntaxKind.KStatic;
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
				case CoreTokensSyntaxKind.IdentifierNormal:
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
				case CoreTokensSyntaxKind.LInteger:
					return true;
				case CoreTokensSyntaxKind.LDecimal:
					return true;
				case CoreTokensSyntaxKind.LScientific:
					return true;
				case CoreTokensSyntaxKind.LDateTimeOffset:
					return true;
				case CoreTokensSyntaxKind.LDateTime:
					return true;
				case CoreTokensSyntaxKind.LDate:
					return true;
				case CoreTokensSyntaxKind.LTime:
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
				case CoreTokensSyntaxKind.LRegularString:
					return true;
				case CoreTokensSyntaxKind.LGuid:
					return true;
				case CoreTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case CoreTokensSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CoreTokensSyntaxKind.LUtf8Bom:
					return true;
				case CoreTokensSyntaxKind.LWhiteSpace:
					return true;
				case CoreTokensSyntaxKind.LCrLf:
					return true;
				case CoreTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case CoreTokensSyntaxKind.LSingleLineComment:
					return true;
				case CoreTokensSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}
	}
}

