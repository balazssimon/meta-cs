// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaCompiler.Syntax
{
	public enum MetaCompilerTokenKind : int
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

	public enum MetaCompilerLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		LMultilineComment = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class MetaCompilerTokensSyntaxFacts : SyntaxFacts
	{
        public MetaCompilerTokensSyntaxFacts() 
            : base(typeof(MetaCompilerTokensSyntaxKind))
        {
        }

        protected MetaCompilerTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (MetaCompilerTokensSyntaxKind)MetaCompilerTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (MetaCompilerTokensSyntaxKind)MetaCompilerTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (MetaCompilerTokensSyntaxKind)MetaCompilerTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (MetaCompilerTokensSyntaxKind)MetaCompilerTokensSyntaxKind.IdentifierNormal;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaCompilerTokensSyntaxKind.Eof:
				case MetaCompilerTokensSyntaxKind.KNamespace:
				case MetaCompilerTokensSyntaxKind.KUsing:
				case MetaCompilerTokensSyntaxKind.KCompiler:
				case MetaCompilerTokensSyntaxKind.KSymbol:
				case MetaCompilerTokensSyntaxKind.KBinder:
				case MetaCompilerTokensSyntaxKind.KExtern:
				case MetaCompilerTokensSyntaxKind.KTypeDef:
				case MetaCompilerTokensSyntaxKind.KAbstract:
				case MetaCompilerTokensSyntaxKind.KClass:
				case MetaCompilerTokensSyntaxKind.KStruct:
				case MetaCompilerTokensSyntaxKind.KEnum:
				case MetaCompilerTokensSyntaxKind.KContainment:
				case MetaCompilerTokensSyntaxKind.KNew:
				case MetaCompilerTokensSyntaxKind.KNull:
				case MetaCompilerTokensSyntaxKind.KTrue:
				case MetaCompilerTokensSyntaxKind.KFalse:
				case MetaCompilerTokensSyntaxKind.KVoid:
				case MetaCompilerTokensSyntaxKind.KObject:
				case MetaCompilerTokensSyntaxKind.KString:
				case MetaCompilerTokensSyntaxKind.KInt:
				case MetaCompilerTokensSyntaxKind.KLong:
				case MetaCompilerTokensSyntaxKind.KFloat:
				case MetaCompilerTokensSyntaxKind.KDouble:
				case MetaCompilerTokensSyntaxKind.KByte:
				case MetaCompilerTokensSyntaxKind.KBool:
				case MetaCompilerTokensSyntaxKind.KThis:
				case MetaCompilerTokensSyntaxKind.KTypeof:
				case MetaCompilerTokensSyntaxKind.KAs:
				case MetaCompilerTokensSyntaxKind.KIs:
				case MetaCompilerTokensSyntaxKind.KBase:
				case MetaCompilerTokensSyntaxKind.KConst:
				case MetaCompilerTokensSyntaxKind.KReadonly:
				case MetaCompilerTokensSyntaxKind.KLazy:
				case MetaCompilerTokensSyntaxKind.KDerived:
				case MetaCompilerTokensSyntaxKind.KLocked:
				case MetaCompilerTokensSyntaxKind.KPhase:
				case MetaCompilerTokensSyntaxKind.KJoins:
				case MetaCompilerTokensSyntaxKind.KAfter:
				case MetaCompilerTokensSyntaxKind.KBefore:
				case MetaCompilerTokensSyntaxKind.KStatic:
				case MetaCompilerTokensSyntaxKind.TSemicolon:
				case MetaCompilerTokensSyntaxKind.TColon:
				case MetaCompilerTokensSyntaxKind.TDot:
				case MetaCompilerTokensSyntaxKind.TComma:
				case MetaCompilerTokensSyntaxKind.TAssign:
				case MetaCompilerTokensSyntaxKind.TOpenParen:
				case MetaCompilerTokensSyntaxKind.TCloseParen:
				case MetaCompilerTokensSyntaxKind.TOpenBracket:
				case MetaCompilerTokensSyntaxKind.TCloseBracket:
				case MetaCompilerTokensSyntaxKind.TOpenBrace:
				case MetaCompilerTokensSyntaxKind.TCloseBrace:
				case MetaCompilerTokensSyntaxKind.TLessThan:
				case MetaCompilerTokensSyntaxKind.TGreaterThan:
				case MetaCompilerTokensSyntaxKind.TQuestion:
				case MetaCompilerTokensSyntaxKind.TQuestionQuestion:
				case MetaCompilerTokensSyntaxKind.TAmpersand:
				case MetaCompilerTokensSyntaxKind.THat:
				case MetaCompilerTokensSyntaxKind.TBar:
				case MetaCompilerTokensSyntaxKind.TAndAlso:
				case MetaCompilerTokensSyntaxKind.TOrElse:
				case MetaCompilerTokensSyntaxKind.TPlusPlus:
				case MetaCompilerTokensSyntaxKind.TMinusMinus:
				case MetaCompilerTokensSyntaxKind.TPlus:
				case MetaCompilerTokensSyntaxKind.TMinus:
				case MetaCompilerTokensSyntaxKind.TTilde:
				case MetaCompilerTokensSyntaxKind.TExclamation:
				case MetaCompilerTokensSyntaxKind.TSlash:
				case MetaCompilerTokensSyntaxKind.TAsterisk:
				case MetaCompilerTokensSyntaxKind.TPercent:
				case MetaCompilerTokensSyntaxKind.TLessThanOrEqual:
				case MetaCompilerTokensSyntaxKind.TGreaterThanOrEqual:
				case MetaCompilerTokensSyntaxKind.TEqual:
				case MetaCompilerTokensSyntaxKind.TNotEqual:
				case MetaCompilerTokensSyntaxKind.TAsteriskAssign:
				case MetaCompilerTokensSyntaxKind.TSlashAssign:
				case MetaCompilerTokensSyntaxKind.TPercentAssign:
				case MetaCompilerTokensSyntaxKind.TPlusAssign:
				case MetaCompilerTokensSyntaxKind.TMinusAssign:
				case MetaCompilerTokensSyntaxKind.TLeftShiftAssign:
				case MetaCompilerTokensSyntaxKind.TRightShiftAssign:
				case MetaCompilerTokensSyntaxKind.TAmpersandAssign:
				case MetaCompilerTokensSyntaxKind.THatAssign:
				case MetaCompilerTokensSyntaxKind.TBarAssign:
				case MetaCompilerTokensSyntaxKind.IdentifierNormal:
				case MetaCompilerTokensSyntaxKind.IdentifierVerbatim:
				case MetaCompilerTokensSyntaxKind.LInteger:
				case MetaCompilerTokensSyntaxKind.LDecimal:
				case MetaCompilerTokensSyntaxKind.LScientific:
				case MetaCompilerTokensSyntaxKind.LDateTimeOffset:
				case MetaCompilerTokensSyntaxKind.LDateTime:
				case MetaCompilerTokensSyntaxKind.LDate:
				case MetaCompilerTokensSyntaxKind.LTime:
				case MetaCompilerTokensSyntaxKind.LRegularString:
				case MetaCompilerTokensSyntaxKind.LGuid:
				case MetaCompilerTokensSyntaxKind.LUtf8Bom:
				case MetaCompilerTokensSyntaxKind.LWhiteSpace:
				case MetaCompilerTokensSyntaxKind.LCrLf:
				case MetaCompilerTokensSyntaxKind.LLineEnd:
				case MetaCompilerTokensSyntaxKind.LSingleLineComment:
				case MetaCompilerTokensSyntaxKind.LComment:
				case MetaCompilerTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case MetaCompilerTokensSyntaxKind.LSingleQuoteVerbatimString:
				case MetaCompilerTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaCompilerTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case MetaCompilerTokensSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaCompilerTokensSyntaxKind.KNamespace:
				case MetaCompilerTokensSyntaxKind.KUsing:
				case MetaCompilerTokensSyntaxKind.KCompiler:
				case MetaCompilerTokensSyntaxKind.KSymbol:
				case MetaCompilerTokensSyntaxKind.KBinder:
				case MetaCompilerTokensSyntaxKind.KExtern:
				case MetaCompilerTokensSyntaxKind.KTypeDef:
				case MetaCompilerTokensSyntaxKind.KAbstract:
				case MetaCompilerTokensSyntaxKind.KClass:
				case MetaCompilerTokensSyntaxKind.KStruct:
				case MetaCompilerTokensSyntaxKind.KEnum:
				case MetaCompilerTokensSyntaxKind.KContainment:
				case MetaCompilerTokensSyntaxKind.KNew:
				case MetaCompilerTokensSyntaxKind.KNull:
				case MetaCompilerTokensSyntaxKind.KTrue:
				case MetaCompilerTokensSyntaxKind.KFalse:
				case MetaCompilerTokensSyntaxKind.KVoid:
				case MetaCompilerTokensSyntaxKind.KObject:
				case MetaCompilerTokensSyntaxKind.KString:
				case MetaCompilerTokensSyntaxKind.KInt:
				case MetaCompilerTokensSyntaxKind.KLong:
				case MetaCompilerTokensSyntaxKind.KFloat:
				case MetaCompilerTokensSyntaxKind.KDouble:
				case MetaCompilerTokensSyntaxKind.KByte:
				case MetaCompilerTokensSyntaxKind.KBool:
				case MetaCompilerTokensSyntaxKind.KThis:
				case MetaCompilerTokensSyntaxKind.KTypeof:
				case MetaCompilerTokensSyntaxKind.KAs:
				case MetaCompilerTokensSyntaxKind.KIs:
				case MetaCompilerTokensSyntaxKind.KBase:
				case MetaCompilerTokensSyntaxKind.KConst:
				case MetaCompilerTokensSyntaxKind.KReadonly:
				case MetaCompilerTokensSyntaxKind.KLazy:
				case MetaCompilerTokensSyntaxKind.KDerived:
				case MetaCompilerTokensSyntaxKind.KLocked:
				case MetaCompilerTokensSyntaxKind.KPhase:
				case MetaCompilerTokensSyntaxKind.KJoins:
				case MetaCompilerTokensSyntaxKind.KAfter:
				case MetaCompilerTokensSyntaxKind.KBefore:
				case MetaCompilerTokensSyntaxKind.KStatic:
				case MetaCompilerTokensSyntaxKind.TSemicolon:
				case MetaCompilerTokensSyntaxKind.TColon:
				case MetaCompilerTokensSyntaxKind.TDot:
				case MetaCompilerTokensSyntaxKind.TComma:
				case MetaCompilerTokensSyntaxKind.TAssign:
				case MetaCompilerTokensSyntaxKind.TOpenParen:
				case MetaCompilerTokensSyntaxKind.TCloseParen:
				case MetaCompilerTokensSyntaxKind.TOpenBracket:
				case MetaCompilerTokensSyntaxKind.TCloseBracket:
				case MetaCompilerTokensSyntaxKind.TOpenBrace:
				case MetaCompilerTokensSyntaxKind.TCloseBrace:
				case MetaCompilerTokensSyntaxKind.TLessThan:
				case MetaCompilerTokensSyntaxKind.TGreaterThan:
				case MetaCompilerTokensSyntaxKind.TQuestion:
				case MetaCompilerTokensSyntaxKind.TQuestionQuestion:
				case MetaCompilerTokensSyntaxKind.TAmpersand:
				case MetaCompilerTokensSyntaxKind.THat:
				case MetaCompilerTokensSyntaxKind.TBar:
				case MetaCompilerTokensSyntaxKind.TAndAlso:
				case MetaCompilerTokensSyntaxKind.TOrElse:
				case MetaCompilerTokensSyntaxKind.TPlusPlus:
				case MetaCompilerTokensSyntaxKind.TMinusMinus:
				case MetaCompilerTokensSyntaxKind.TPlus:
				case MetaCompilerTokensSyntaxKind.TMinus:
				case MetaCompilerTokensSyntaxKind.TTilde:
				case MetaCompilerTokensSyntaxKind.TExclamation:
				case MetaCompilerTokensSyntaxKind.TSlash:
				case MetaCompilerTokensSyntaxKind.TPercent:
				case MetaCompilerTokensSyntaxKind.TLessThanOrEqual:
				case MetaCompilerTokensSyntaxKind.TGreaterThanOrEqual:
				case MetaCompilerTokensSyntaxKind.TEqual:
				case MetaCompilerTokensSyntaxKind.TNotEqual:
				case MetaCompilerTokensSyntaxKind.TAsteriskAssign:
				case MetaCompilerTokensSyntaxKind.TSlashAssign:
				case MetaCompilerTokensSyntaxKind.TPercentAssign:
				case MetaCompilerTokensSyntaxKind.TPlusAssign:
				case MetaCompilerTokensSyntaxKind.TMinusAssign:
				case MetaCompilerTokensSyntaxKind.TLeftShiftAssign:
				case MetaCompilerTokensSyntaxKind.TRightShiftAssign:
				case MetaCompilerTokensSyntaxKind.TAmpersandAssign:
				case MetaCompilerTokensSyntaxKind.THatAssign:
				case MetaCompilerTokensSyntaxKind.TBarAssign:
				case MetaCompilerTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaCompilerTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case MetaCompilerTokensSyntaxKind.LCommentStart:
				case MetaCompilerTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case MetaCompilerTokensSyntaxKind.LSingleQuoteVerbatimString:
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
					return MetaCompilerTokensSyntaxKind.KNamespace;
				case "using":
					return MetaCompilerTokensSyntaxKind.KUsing;
				case "compiler":
					return MetaCompilerTokensSyntaxKind.KCompiler;
				case "symbol":
					return MetaCompilerTokensSyntaxKind.KSymbol;
				case "binder":
					return MetaCompilerTokensSyntaxKind.KBinder;
				case "extern":
					return MetaCompilerTokensSyntaxKind.KExtern;
				case "typedef":
					return MetaCompilerTokensSyntaxKind.KTypeDef;
				case "abstract":
					return MetaCompilerTokensSyntaxKind.KAbstract;
				case "class":
					return MetaCompilerTokensSyntaxKind.KClass;
				case "struct":
					return MetaCompilerTokensSyntaxKind.KStruct;
				case "enum":
					return MetaCompilerTokensSyntaxKind.KEnum;
				case "containment":
					return MetaCompilerTokensSyntaxKind.KContainment;
				case "new":
					return MetaCompilerTokensSyntaxKind.KNew;
				case "null":
					return MetaCompilerTokensSyntaxKind.KNull;
				case "true":
					return MetaCompilerTokensSyntaxKind.KTrue;
				case "false":
					return MetaCompilerTokensSyntaxKind.KFalse;
				case "void":
					return MetaCompilerTokensSyntaxKind.KVoid;
				case "object":
					return MetaCompilerTokensSyntaxKind.KObject;
				case "string":
					return MetaCompilerTokensSyntaxKind.KString;
				case "int":
					return MetaCompilerTokensSyntaxKind.KInt;
				case "long":
					return MetaCompilerTokensSyntaxKind.KLong;
				case "float":
					return MetaCompilerTokensSyntaxKind.KFloat;
				case "double":
					return MetaCompilerTokensSyntaxKind.KDouble;
				case "byte":
					return MetaCompilerTokensSyntaxKind.KByte;
				case "bool":
					return MetaCompilerTokensSyntaxKind.KBool;
				case "this":
					return MetaCompilerTokensSyntaxKind.KThis;
				case "typeof":
					return MetaCompilerTokensSyntaxKind.KTypeof;
				case "as":
					return MetaCompilerTokensSyntaxKind.KAs;
				case "is":
					return MetaCompilerTokensSyntaxKind.KIs;
				case "base":
					return MetaCompilerTokensSyntaxKind.KBase;
				case "const":
					return MetaCompilerTokensSyntaxKind.KConst;
				case "readonly":
					return MetaCompilerTokensSyntaxKind.KReadonly;
				case "lazy":
					return MetaCompilerTokensSyntaxKind.KLazy;
				case "derived":
					return MetaCompilerTokensSyntaxKind.KDerived;
				case "locked":
					return MetaCompilerTokensSyntaxKind.KLocked;
				case "phase":
					return MetaCompilerTokensSyntaxKind.KPhase;
				case "joins":
					return MetaCompilerTokensSyntaxKind.KJoins;
				case "after":
					return MetaCompilerTokensSyntaxKind.KAfter;
				case "before":
					return MetaCompilerTokensSyntaxKind.KBefore;
				case "static":
					return MetaCompilerTokensSyntaxKind.KStatic;
				case ";":
					return MetaCompilerTokensSyntaxKind.TSemicolon;
				case ":":
					return MetaCompilerTokensSyntaxKind.TColon;
				case ".":
					return MetaCompilerTokensSyntaxKind.TDot;
				case ",":
					return MetaCompilerTokensSyntaxKind.TComma;
				case "=":
					return MetaCompilerTokensSyntaxKind.TAssign;
				case "(":
					return MetaCompilerTokensSyntaxKind.TOpenParen;
				case ")":
					return MetaCompilerTokensSyntaxKind.TCloseParen;
				case "[":
					return MetaCompilerTokensSyntaxKind.TOpenBracket;
				case "]":
					return MetaCompilerTokensSyntaxKind.TCloseBracket;
				case "{":
					return MetaCompilerTokensSyntaxKind.TOpenBrace;
				case "}":
					return MetaCompilerTokensSyntaxKind.TCloseBrace;
				case "<":
					return MetaCompilerTokensSyntaxKind.TLessThan;
				case ">":
					return MetaCompilerTokensSyntaxKind.TGreaterThan;
				case "?":
					return MetaCompilerTokensSyntaxKind.TQuestion;
				case "??":
					return MetaCompilerTokensSyntaxKind.TQuestionQuestion;
				case "&":
					return MetaCompilerTokensSyntaxKind.TAmpersand;
				case "^":
					return MetaCompilerTokensSyntaxKind.THat;
				case "|":
					return MetaCompilerTokensSyntaxKind.TBar;
				case "&&":
					return MetaCompilerTokensSyntaxKind.TAndAlso;
				case "||":
					return MetaCompilerTokensSyntaxKind.TOrElse;
				case "++":
					return MetaCompilerTokensSyntaxKind.TPlusPlus;
				case "--":
					return MetaCompilerTokensSyntaxKind.TMinusMinus;
				case "+":
					return MetaCompilerTokensSyntaxKind.TPlus;
				case "-":
					return MetaCompilerTokensSyntaxKind.TMinus;
				case "~":
					return MetaCompilerTokensSyntaxKind.TTilde;
				case "!":
					return MetaCompilerTokensSyntaxKind.TExclamation;
				case "/":
					return MetaCompilerTokensSyntaxKind.TSlash;
				case "%":
					return MetaCompilerTokensSyntaxKind.TPercent;
				case "<=":
					return MetaCompilerTokensSyntaxKind.TLessThanOrEqual;
				case ">=":
					return MetaCompilerTokensSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return MetaCompilerTokensSyntaxKind.TEqual;
				case "!=":
					return MetaCompilerTokensSyntaxKind.TNotEqual;
				case "*=":
					return MetaCompilerTokensSyntaxKind.TAsteriskAssign;
				case "/=":
					return MetaCompilerTokensSyntaxKind.TSlashAssign;
				case "%=":
					return MetaCompilerTokensSyntaxKind.TPercentAssign;
				case "+=":
					return MetaCompilerTokensSyntaxKind.TPlusAssign;
				case "-=":
					return MetaCompilerTokensSyntaxKind.TMinusAssign;
				case "<<=":
					return MetaCompilerTokensSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return MetaCompilerTokensSyntaxKind.TRightShiftAssign;
				case "&=":
					return MetaCompilerTokensSyntaxKind.TAmpersandAssign;
				case "^=":
					return MetaCompilerTokensSyntaxKind.THatAssign;
				case "|=":
					return MetaCompilerTokensSyntaxKind.TBarAssign;
				case "@\"":
					return MetaCompilerTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return MetaCompilerTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return MetaCompilerTokensSyntaxKind.LCommentStart;
				case "\"":
					return MetaCompilerTokensSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return MetaCompilerTokensSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return MetaCompilerTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaCompilerTokensSyntaxKind.KNamespace:
					return "namespace";
				case MetaCompilerTokensSyntaxKind.KUsing:
					return "using";
				case MetaCompilerTokensSyntaxKind.KCompiler:
					return "compiler";
				case MetaCompilerTokensSyntaxKind.KSymbol:
					return "symbol";
				case MetaCompilerTokensSyntaxKind.KBinder:
					return "binder";
				case MetaCompilerTokensSyntaxKind.KExtern:
					return "extern";
				case MetaCompilerTokensSyntaxKind.KTypeDef:
					return "typedef";
				case MetaCompilerTokensSyntaxKind.KAbstract:
					return "abstract";
				case MetaCompilerTokensSyntaxKind.KClass:
					return "class";
				case MetaCompilerTokensSyntaxKind.KStruct:
					return "struct";
				case MetaCompilerTokensSyntaxKind.KEnum:
					return "enum";
				case MetaCompilerTokensSyntaxKind.KContainment:
					return "containment";
				case MetaCompilerTokensSyntaxKind.KNew:
					return "new";
				case MetaCompilerTokensSyntaxKind.KNull:
					return "null";
				case MetaCompilerTokensSyntaxKind.KTrue:
					return "true";
				case MetaCompilerTokensSyntaxKind.KFalse:
					return "false";
				case MetaCompilerTokensSyntaxKind.KVoid:
					return "void";
				case MetaCompilerTokensSyntaxKind.KObject:
					return "object";
				case MetaCompilerTokensSyntaxKind.KString:
					return "string";
				case MetaCompilerTokensSyntaxKind.KInt:
					return "int";
				case MetaCompilerTokensSyntaxKind.KLong:
					return "long";
				case MetaCompilerTokensSyntaxKind.KFloat:
					return "float";
				case MetaCompilerTokensSyntaxKind.KDouble:
					return "double";
				case MetaCompilerTokensSyntaxKind.KByte:
					return "byte";
				case MetaCompilerTokensSyntaxKind.KBool:
					return "bool";
				case MetaCompilerTokensSyntaxKind.KThis:
					return "this";
				case MetaCompilerTokensSyntaxKind.KTypeof:
					return "typeof";
				case MetaCompilerTokensSyntaxKind.KAs:
					return "as";
				case MetaCompilerTokensSyntaxKind.KIs:
					return "is";
				case MetaCompilerTokensSyntaxKind.KBase:
					return "base";
				case MetaCompilerTokensSyntaxKind.KConst:
					return "const";
				case MetaCompilerTokensSyntaxKind.KReadonly:
					return "readonly";
				case MetaCompilerTokensSyntaxKind.KLazy:
					return "lazy";
				case MetaCompilerTokensSyntaxKind.KDerived:
					return "derived";
				case MetaCompilerTokensSyntaxKind.KLocked:
					return "locked";
				case MetaCompilerTokensSyntaxKind.KPhase:
					return "phase";
				case MetaCompilerTokensSyntaxKind.KJoins:
					return "joins";
				case MetaCompilerTokensSyntaxKind.KAfter:
					return "after";
				case MetaCompilerTokensSyntaxKind.KBefore:
					return "before";
				case MetaCompilerTokensSyntaxKind.KStatic:
					return "static";
				case MetaCompilerTokensSyntaxKind.TSemicolon:
					return ";";
				case MetaCompilerTokensSyntaxKind.TColon:
					return ":";
				case MetaCompilerTokensSyntaxKind.TDot:
					return ".";
				case MetaCompilerTokensSyntaxKind.TComma:
					return ",";
				case MetaCompilerTokensSyntaxKind.TAssign:
					return "=";
				case MetaCompilerTokensSyntaxKind.TOpenParen:
					return "(";
				case MetaCompilerTokensSyntaxKind.TCloseParen:
					return ")";
				case MetaCompilerTokensSyntaxKind.TOpenBracket:
					return "[";
				case MetaCompilerTokensSyntaxKind.TCloseBracket:
					return "]";
				case MetaCompilerTokensSyntaxKind.TOpenBrace:
					return "{";
				case MetaCompilerTokensSyntaxKind.TCloseBrace:
					return "}";
				case MetaCompilerTokensSyntaxKind.TLessThan:
					return "<";
				case MetaCompilerTokensSyntaxKind.TGreaterThan:
					return ">";
				case MetaCompilerTokensSyntaxKind.TQuestion:
					return "?";
				case MetaCompilerTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case MetaCompilerTokensSyntaxKind.TAmpersand:
					return "&";
				case MetaCompilerTokensSyntaxKind.THat:
					return "^";
				case MetaCompilerTokensSyntaxKind.TBar:
					return "|";
				case MetaCompilerTokensSyntaxKind.TAndAlso:
					return "&&";
				case MetaCompilerTokensSyntaxKind.TOrElse:
					return "||";
				case MetaCompilerTokensSyntaxKind.TPlusPlus:
					return "++";
				case MetaCompilerTokensSyntaxKind.TMinusMinus:
					return "--";
				case MetaCompilerTokensSyntaxKind.TPlus:
					return "+";
				case MetaCompilerTokensSyntaxKind.TMinus:
					return "-";
				case MetaCompilerTokensSyntaxKind.TTilde:
					return "~";
				case MetaCompilerTokensSyntaxKind.TExclamation:
					return "!";
				case MetaCompilerTokensSyntaxKind.TSlash:
					return "/";
				case MetaCompilerTokensSyntaxKind.TPercent:
					return "%";
				case MetaCompilerTokensSyntaxKind.TLessThanOrEqual:
					return "<=";
				case MetaCompilerTokensSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case MetaCompilerTokensSyntaxKind.TEqual:
					return "==";
				case MetaCompilerTokensSyntaxKind.TNotEqual:
					return "!=";
				case MetaCompilerTokensSyntaxKind.TAsteriskAssign:
					return "*=";
				case MetaCompilerTokensSyntaxKind.TSlashAssign:
					return "/=";
				case MetaCompilerTokensSyntaxKind.TPercentAssign:
					return "%=";
				case MetaCompilerTokensSyntaxKind.TPlusAssign:
					return "+=";
				case MetaCompilerTokensSyntaxKind.TMinusAssign:
					return "-=";
				case MetaCompilerTokensSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case MetaCompilerTokensSyntaxKind.TRightShiftAssign:
					return ">>=";
				case MetaCompilerTokensSyntaxKind.TAmpersandAssign:
					return "&=";
				case MetaCompilerTokensSyntaxKind.THatAssign:
					return "^=";
				case MetaCompilerTokensSyntaxKind.TBarAssign:
					return "|=";
				case MetaCompilerTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case MetaCompilerTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case MetaCompilerTokensSyntaxKind.LCommentStart:
					return "/*";
				case MetaCompilerTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case MetaCompilerTokensSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public MetaCompilerTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<MetaCompilerTokensSyntaxKind>(rawKind));
		}

		public MetaCompilerTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaCompilerTokensSyntaxKind.KNamespace:
				case MetaCompilerTokensSyntaxKind.KUsing:
				case MetaCompilerTokensSyntaxKind.KCompiler:
				case MetaCompilerTokensSyntaxKind.KSymbol:
				case MetaCompilerTokensSyntaxKind.KBinder:
				case MetaCompilerTokensSyntaxKind.KExtern:
				case MetaCompilerTokensSyntaxKind.KTypeDef:
				case MetaCompilerTokensSyntaxKind.KAbstract:
				case MetaCompilerTokensSyntaxKind.KClass:
				case MetaCompilerTokensSyntaxKind.KStruct:
				case MetaCompilerTokensSyntaxKind.KEnum:
				case MetaCompilerTokensSyntaxKind.KContainment:
				case MetaCompilerTokensSyntaxKind.KNew:
				case MetaCompilerTokensSyntaxKind.KNull:
				case MetaCompilerTokensSyntaxKind.KTrue:
				case MetaCompilerTokensSyntaxKind.KFalse:
				case MetaCompilerTokensSyntaxKind.KVoid:
				case MetaCompilerTokensSyntaxKind.KObject:
				case MetaCompilerTokensSyntaxKind.KString:
				case MetaCompilerTokensSyntaxKind.KInt:
				case MetaCompilerTokensSyntaxKind.KLong:
				case MetaCompilerTokensSyntaxKind.KFloat:
				case MetaCompilerTokensSyntaxKind.KDouble:
				case MetaCompilerTokensSyntaxKind.KByte:
				case MetaCompilerTokensSyntaxKind.KBool:
				case MetaCompilerTokensSyntaxKind.KThis:
				case MetaCompilerTokensSyntaxKind.KTypeof:
				case MetaCompilerTokensSyntaxKind.KAs:
				case MetaCompilerTokensSyntaxKind.KIs:
				case MetaCompilerTokensSyntaxKind.KBase:
				case MetaCompilerTokensSyntaxKind.KConst:
				case MetaCompilerTokensSyntaxKind.KReadonly:
				case MetaCompilerTokensSyntaxKind.KLazy:
				case MetaCompilerTokensSyntaxKind.KDerived:
				case MetaCompilerTokensSyntaxKind.KLocked:
				case MetaCompilerTokensSyntaxKind.KPhase:
				case MetaCompilerTokensSyntaxKind.KJoins:
				case MetaCompilerTokensSyntaxKind.KAfter:
				case MetaCompilerTokensSyntaxKind.KBefore:
				case MetaCompilerTokensSyntaxKind.KStatic:
					return MetaCompilerTokenKind.ReservedKeyword;
				case MetaCompilerTokensSyntaxKind.IdentifierNormal:
					return MetaCompilerTokenKind.Identifier;
				case MetaCompilerTokensSyntaxKind.LInteger:
					return MetaCompilerTokenKind.Number;
				case MetaCompilerTokensSyntaxKind.LDecimal:
					return MetaCompilerTokenKind.Number;
				case MetaCompilerTokensSyntaxKind.LScientific:
					return MetaCompilerTokenKind.Number;
				case MetaCompilerTokensSyntaxKind.LDateTimeOffset:
					return MetaCompilerTokenKind.Number;
				case MetaCompilerTokensSyntaxKind.LDateTime:
					return MetaCompilerTokenKind.Number;
				case MetaCompilerTokensSyntaxKind.LDate:
					return MetaCompilerTokenKind.Number;
				case MetaCompilerTokensSyntaxKind.LTime:
					return MetaCompilerTokenKind.Number;
				case MetaCompilerTokensSyntaxKind.LRegularString:
					return MetaCompilerTokenKind.String;
				case MetaCompilerTokensSyntaxKind.LGuid:
					return MetaCompilerTokenKind.String;
				case MetaCompilerTokensSyntaxKind.LUtf8Bom:
					return MetaCompilerTokenKind.Whitespace;
				case MetaCompilerTokensSyntaxKind.LWhiteSpace:
					return MetaCompilerTokenKind.Whitespace;
				case MetaCompilerTokensSyntaxKind.LCrLf:
					return MetaCompilerTokenKind.Whitespace;
				case MetaCompilerTokensSyntaxKind.LLineEnd:
					return MetaCompilerTokenKind.Whitespace;
				case MetaCompilerTokensSyntaxKind.LSingleLineComment:
					return MetaCompilerTokenKind.GeneralComment;
				case MetaCompilerTokensSyntaxKind.LComment:
					return MetaCompilerTokenKind.GeneralComment;
				case MetaCompilerTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return MetaCompilerTokenKind.String;
				case MetaCompilerTokensSyntaxKind.LSingleQuoteVerbatimString:
					return MetaCompilerTokenKind.String;
				default:
					return MetaCompilerTokenKind.None;
			}
		}

		public MetaCompilerTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((MetaCompilerLexerMode)rawKind);
		}

		public MetaCompilerTokenKind GetModeTokenKind(MetaCompilerLexerMode kind)
		{
			switch(kind)
			{
				case MetaCompilerLexerMode.LMultilineComment:
					return MetaCompilerTokenKind.GeneralComment;
				case MetaCompilerLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return MetaCompilerTokenKind.String;
				case MetaCompilerLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return MetaCompilerTokenKind.String;
				default:
					return MetaCompilerTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaCompilerTokensSyntaxKind.LCrLf:
					return true;
				case MetaCompilerTokensSyntaxKind.LLineEnd:
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
				case MetaCompilerTokensSyntaxKind.KNamespace:
				case MetaCompilerTokensSyntaxKind.KUsing:
				case MetaCompilerTokensSyntaxKind.KCompiler:
				case MetaCompilerTokensSyntaxKind.KSymbol:
				case MetaCompilerTokensSyntaxKind.KBinder:
				case MetaCompilerTokensSyntaxKind.KExtern:
				case MetaCompilerTokensSyntaxKind.KTypeDef:
				case MetaCompilerTokensSyntaxKind.KAbstract:
				case MetaCompilerTokensSyntaxKind.KClass:
				case MetaCompilerTokensSyntaxKind.KStruct:
				case MetaCompilerTokensSyntaxKind.KEnum:
				case MetaCompilerTokensSyntaxKind.KContainment:
				case MetaCompilerTokensSyntaxKind.KNew:
				case MetaCompilerTokensSyntaxKind.KNull:
				case MetaCompilerTokensSyntaxKind.KTrue:
				case MetaCompilerTokensSyntaxKind.KFalse:
				case MetaCompilerTokensSyntaxKind.KVoid:
				case MetaCompilerTokensSyntaxKind.KObject:
				case MetaCompilerTokensSyntaxKind.KString:
				case MetaCompilerTokensSyntaxKind.KInt:
				case MetaCompilerTokensSyntaxKind.KLong:
				case MetaCompilerTokensSyntaxKind.KFloat:
				case MetaCompilerTokensSyntaxKind.KDouble:
				case MetaCompilerTokensSyntaxKind.KByte:
				case MetaCompilerTokensSyntaxKind.KBool:
				case MetaCompilerTokensSyntaxKind.KThis:
				case MetaCompilerTokensSyntaxKind.KTypeof:
				case MetaCompilerTokensSyntaxKind.KAs:
				case MetaCompilerTokensSyntaxKind.KIs:
				case MetaCompilerTokensSyntaxKind.KBase:
				case MetaCompilerTokensSyntaxKind.KConst:
				case MetaCompilerTokensSyntaxKind.KReadonly:
				case MetaCompilerTokensSyntaxKind.KLazy:
				case MetaCompilerTokensSyntaxKind.KDerived:
				case MetaCompilerTokensSyntaxKind.KLocked:
				case MetaCompilerTokensSyntaxKind.KPhase:
				case MetaCompilerTokensSyntaxKind.KJoins:
				case MetaCompilerTokensSyntaxKind.KAfter:
				case MetaCompilerTokensSyntaxKind.KBefore:
				case MetaCompilerTokensSyntaxKind.KStatic:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return MetaCompilerTokensSyntaxKind.KNamespace;
				yield return MetaCompilerTokensSyntaxKind.KUsing;
				yield return MetaCompilerTokensSyntaxKind.KCompiler;
				yield return MetaCompilerTokensSyntaxKind.KSymbol;
				yield return MetaCompilerTokensSyntaxKind.KBinder;
				yield return MetaCompilerTokensSyntaxKind.KExtern;
				yield return MetaCompilerTokensSyntaxKind.KTypeDef;
				yield return MetaCompilerTokensSyntaxKind.KAbstract;
				yield return MetaCompilerTokensSyntaxKind.KClass;
				yield return MetaCompilerTokensSyntaxKind.KStruct;
				yield return MetaCompilerTokensSyntaxKind.KEnum;
				yield return MetaCompilerTokensSyntaxKind.KContainment;
				yield return MetaCompilerTokensSyntaxKind.KNew;
				yield return MetaCompilerTokensSyntaxKind.KNull;
				yield return MetaCompilerTokensSyntaxKind.KTrue;
				yield return MetaCompilerTokensSyntaxKind.KFalse;
				yield return MetaCompilerTokensSyntaxKind.KVoid;
				yield return MetaCompilerTokensSyntaxKind.KObject;
				yield return MetaCompilerTokensSyntaxKind.KString;
				yield return MetaCompilerTokensSyntaxKind.KInt;
				yield return MetaCompilerTokensSyntaxKind.KLong;
				yield return MetaCompilerTokensSyntaxKind.KFloat;
				yield return MetaCompilerTokensSyntaxKind.KDouble;
				yield return MetaCompilerTokensSyntaxKind.KByte;
				yield return MetaCompilerTokensSyntaxKind.KBool;
				yield return MetaCompilerTokensSyntaxKind.KThis;
				yield return MetaCompilerTokensSyntaxKind.KTypeof;
				yield return MetaCompilerTokensSyntaxKind.KAs;
				yield return MetaCompilerTokensSyntaxKind.KIs;
				yield return MetaCompilerTokensSyntaxKind.KBase;
				yield return MetaCompilerTokensSyntaxKind.KConst;
				yield return MetaCompilerTokensSyntaxKind.KReadonly;
				yield return MetaCompilerTokensSyntaxKind.KLazy;
				yield return MetaCompilerTokensSyntaxKind.KDerived;
				yield return MetaCompilerTokensSyntaxKind.KLocked;
				yield return MetaCompilerTokensSyntaxKind.KPhase;
				yield return MetaCompilerTokensSyntaxKind.KJoins;
				yield return MetaCompilerTokensSyntaxKind.KAfter;
				yield return MetaCompilerTokensSyntaxKind.KBefore;
				yield return MetaCompilerTokensSyntaxKind.KStatic;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return MetaCompilerTokensSyntaxKind.KNamespace;
				case "using":
					return MetaCompilerTokensSyntaxKind.KUsing;
				case "compiler":
					return MetaCompilerTokensSyntaxKind.KCompiler;
				case "symbol":
					return MetaCompilerTokensSyntaxKind.KSymbol;
				case "binder":
					return MetaCompilerTokensSyntaxKind.KBinder;
				case "extern":
					return MetaCompilerTokensSyntaxKind.KExtern;
				case "typedef":
					return MetaCompilerTokensSyntaxKind.KTypeDef;
				case "abstract":
					return MetaCompilerTokensSyntaxKind.KAbstract;
				case "class":
					return MetaCompilerTokensSyntaxKind.KClass;
				case "struct":
					return MetaCompilerTokensSyntaxKind.KStruct;
				case "enum":
					return MetaCompilerTokensSyntaxKind.KEnum;
				case "containment":
					return MetaCompilerTokensSyntaxKind.KContainment;
				case "new":
					return MetaCompilerTokensSyntaxKind.KNew;
				case "null":
					return MetaCompilerTokensSyntaxKind.KNull;
				case "true":
					return MetaCompilerTokensSyntaxKind.KTrue;
				case "false":
					return MetaCompilerTokensSyntaxKind.KFalse;
				case "void":
					return MetaCompilerTokensSyntaxKind.KVoid;
				case "object":
					return MetaCompilerTokensSyntaxKind.KObject;
				case "string":
					return MetaCompilerTokensSyntaxKind.KString;
				case "int":
					return MetaCompilerTokensSyntaxKind.KInt;
				case "long":
					return MetaCompilerTokensSyntaxKind.KLong;
				case "float":
					return MetaCompilerTokensSyntaxKind.KFloat;
				case "double":
					return MetaCompilerTokensSyntaxKind.KDouble;
				case "byte":
					return MetaCompilerTokensSyntaxKind.KByte;
				case "bool":
					return MetaCompilerTokensSyntaxKind.KBool;
				case "this":
					return MetaCompilerTokensSyntaxKind.KThis;
				case "typeof":
					return MetaCompilerTokensSyntaxKind.KTypeof;
				case "as":
					return MetaCompilerTokensSyntaxKind.KAs;
				case "is":
					return MetaCompilerTokensSyntaxKind.KIs;
				case "base":
					return MetaCompilerTokensSyntaxKind.KBase;
				case "const":
					return MetaCompilerTokensSyntaxKind.KConst;
				case "readonly":
					return MetaCompilerTokensSyntaxKind.KReadonly;
				case "lazy":
					return MetaCompilerTokensSyntaxKind.KLazy;
				case "derived":
					return MetaCompilerTokensSyntaxKind.KDerived;
				case "locked":
					return MetaCompilerTokensSyntaxKind.KLocked;
				case "phase":
					return MetaCompilerTokensSyntaxKind.KPhase;
				case "joins":
					return MetaCompilerTokensSyntaxKind.KJoins;
				case "after":
					return MetaCompilerTokensSyntaxKind.KAfter;
				case "before":
					return MetaCompilerTokensSyntaxKind.KBefore;
				case "static":
					return MetaCompilerTokensSyntaxKind.KStatic;
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
				case MetaCompilerTokensSyntaxKind.IdentifierNormal:
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
				case MetaCompilerTokensSyntaxKind.LInteger:
					return true;
				case MetaCompilerTokensSyntaxKind.LDecimal:
					return true;
				case MetaCompilerTokensSyntaxKind.LScientific:
					return true;
				case MetaCompilerTokensSyntaxKind.LDateTimeOffset:
					return true;
				case MetaCompilerTokensSyntaxKind.LDateTime:
					return true;
				case MetaCompilerTokensSyntaxKind.LDate:
					return true;
				case MetaCompilerTokensSyntaxKind.LTime:
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
				case MetaCompilerTokensSyntaxKind.LRegularString:
					return true;
				case MetaCompilerTokensSyntaxKind.LGuid:
					return true;
				case MetaCompilerTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case MetaCompilerTokensSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaCompilerTokensSyntaxKind.LUtf8Bom:
					return true;
				case MetaCompilerTokensSyntaxKind.LWhiteSpace:
					return true;
				case MetaCompilerTokensSyntaxKind.LCrLf:
					return true;
				case MetaCompilerTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaCompilerTokensSyntaxKind.LSingleLineComment:
					return true;
				case MetaCompilerTokensSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}
	}
}

