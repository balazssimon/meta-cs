// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Meta.Syntax
{
	public enum MetaTokenKind : int
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

	public enum MetaLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		LMultilineComment = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class MetaTokensSyntaxFacts : SyntaxFacts
	{
        public MetaTokensSyntaxFacts() 
            : base(typeof(MetaTokensSyntaxKind))
        {
        }

        protected MetaTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (MetaTokensSyntaxKind)MetaTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (MetaTokensSyntaxKind)MetaTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (MetaTokensSyntaxKind)MetaTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (MetaTokensSyntaxKind)MetaTokensSyntaxKind.IdentifierNormal;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaTokensSyntaxKind.Eof:
				case MetaTokensSyntaxKind.KNamespace:
				case MetaTokensSyntaxKind.KUsing:
				case MetaTokensSyntaxKind.KMetamodel:
				case MetaTokensSyntaxKind.KExtern:
				case MetaTokensSyntaxKind.KTypeDef:
				case MetaTokensSyntaxKind.KAbstract:
				case MetaTokensSyntaxKind.KClass:
				case MetaTokensSyntaxKind.KStruct:
				case MetaTokensSyntaxKind.KEnum:
				case MetaTokensSyntaxKind.KAssociation:
				case MetaTokensSyntaxKind.KContainment:
				case MetaTokensSyntaxKind.KWith:
				case MetaTokensSyntaxKind.KNew:
				case MetaTokensSyntaxKind.KNull:
				case MetaTokensSyntaxKind.KTrue:
				case MetaTokensSyntaxKind.KFalse:
				case MetaTokensSyntaxKind.KVoid:
				case MetaTokensSyntaxKind.KObject:
				case MetaTokensSyntaxKind.KSymbol:
				case MetaTokensSyntaxKind.KString:
				case MetaTokensSyntaxKind.KInt:
				case MetaTokensSyntaxKind.KLong:
				case MetaTokensSyntaxKind.KFloat:
				case MetaTokensSyntaxKind.KDouble:
				case MetaTokensSyntaxKind.KByte:
				case MetaTokensSyntaxKind.KBool:
				case MetaTokensSyntaxKind.KList:
				case MetaTokensSyntaxKind.KAny:
				case MetaTokensSyntaxKind.KNone:
				case MetaTokensSyntaxKind.KError:
				case MetaTokensSyntaxKind.KSet:
				case MetaTokensSyntaxKind.KMultiList:
				case MetaTokensSyntaxKind.KMultiSet:
				case MetaTokensSyntaxKind.KThis:
				case MetaTokensSyntaxKind.KTypeof:
				case MetaTokensSyntaxKind.KAs:
				case MetaTokensSyntaxKind.KIs:
				case MetaTokensSyntaxKind.KBase:
				case MetaTokensSyntaxKind.KConst:
				case MetaTokensSyntaxKind.KRedefines:
				case MetaTokensSyntaxKind.KSubsets:
				case MetaTokensSyntaxKind.KReadonly:
				case MetaTokensSyntaxKind.KLazy:
				case MetaTokensSyntaxKind.KSynthetized:
				case MetaTokensSyntaxKind.KInherited:
				case MetaTokensSyntaxKind.KDerived:
				case MetaTokensSyntaxKind.KUnion:
				case MetaTokensSyntaxKind.KBuilder:
				case MetaTokensSyntaxKind.KStatic:
				case MetaTokensSyntaxKind.TSemicolon:
				case MetaTokensSyntaxKind.TColon:
				case MetaTokensSyntaxKind.TDot:
				case MetaTokensSyntaxKind.TComma:
				case MetaTokensSyntaxKind.TAssign:
				case MetaTokensSyntaxKind.TOpenParen:
				case MetaTokensSyntaxKind.TCloseParen:
				case MetaTokensSyntaxKind.TOpenBracket:
				case MetaTokensSyntaxKind.TCloseBracket:
				case MetaTokensSyntaxKind.TOpenBrace:
				case MetaTokensSyntaxKind.TCloseBrace:
				case MetaTokensSyntaxKind.TLessThan:
				case MetaTokensSyntaxKind.TGreaterThan:
				case MetaTokensSyntaxKind.TQuestion:
				case MetaTokensSyntaxKind.TQuestionQuestion:
				case MetaTokensSyntaxKind.TAmpersand:
				case MetaTokensSyntaxKind.THat:
				case MetaTokensSyntaxKind.TBar:
				case MetaTokensSyntaxKind.TAndAlso:
				case MetaTokensSyntaxKind.TOrElse:
				case MetaTokensSyntaxKind.TPlusPlus:
				case MetaTokensSyntaxKind.TMinusMinus:
				case MetaTokensSyntaxKind.TPlus:
				case MetaTokensSyntaxKind.TMinus:
				case MetaTokensSyntaxKind.TTilde:
				case MetaTokensSyntaxKind.TExclamation:
				case MetaTokensSyntaxKind.TSlash:
				case MetaTokensSyntaxKind.TAsterisk:
				case MetaTokensSyntaxKind.TPercent:
				case MetaTokensSyntaxKind.TLessThanOrEqual:
				case MetaTokensSyntaxKind.TGreaterThanOrEqual:
				case MetaTokensSyntaxKind.TEqual:
				case MetaTokensSyntaxKind.TNotEqual:
				case MetaTokensSyntaxKind.TAsteriskAssign:
				case MetaTokensSyntaxKind.TSlashAssign:
				case MetaTokensSyntaxKind.TPercentAssign:
				case MetaTokensSyntaxKind.TPlusAssign:
				case MetaTokensSyntaxKind.TMinusAssign:
				case MetaTokensSyntaxKind.TLeftShiftAssign:
				case MetaTokensSyntaxKind.TRightShiftAssign:
				case MetaTokensSyntaxKind.TAmpersandAssign:
				case MetaTokensSyntaxKind.THatAssign:
				case MetaTokensSyntaxKind.TBarAssign:
				case MetaTokensSyntaxKind.IUri:
				case MetaTokensSyntaxKind.IdentifierNormal:
				case MetaTokensSyntaxKind.IdentifierVerbatim:
				case MetaTokensSyntaxKind.LInteger:
				case MetaTokensSyntaxKind.LDecimal:
				case MetaTokensSyntaxKind.LScientific:
				case MetaTokensSyntaxKind.LDateTimeOffset:
				case MetaTokensSyntaxKind.LDateTime:
				case MetaTokensSyntaxKind.LDate:
				case MetaTokensSyntaxKind.LTime:
				case MetaTokensSyntaxKind.LRegularString:
				case MetaTokensSyntaxKind.LGuid:
				case MetaTokensSyntaxKind.LUtf8Bom:
				case MetaTokensSyntaxKind.LWhiteSpace:
				case MetaTokensSyntaxKind.LCrLf:
				case MetaTokensSyntaxKind.LLineEnd:
				case MetaTokensSyntaxKind.LSingleLineComment:
				case MetaTokensSyntaxKind.LComment:
				case MetaTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case MetaTokensSyntaxKind.LSingleQuoteVerbatimString:
				case MetaTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case MetaTokensSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaTokensSyntaxKind.KNamespace:
				case MetaTokensSyntaxKind.KUsing:
				case MetaTokensSyntaxKind.KMetamodel:
				case MetaTokensSyntaxKind.KExtern:
				case MetaTokensSyntaxKind.KTypeDef:
				case MetaTokensSyntaxKind.KAbstract:
				case MetaTokensSyntaxKind.KClass:
				case MetaTokensSyntaxKind.KStruct:
				case MetaTokensSyntaxKind.KEnum:
				case MetaTokensSyntaxKind.KAssociation:
				case MetaTokensSyntaxKind.KContainment:
				case MetaTokensSyntaxKind.KWith:
				case MetaTokensSyntaxKind.KNew:
				case MetaTokensSyntaxKind.KNull:
				case MetaTokensSyntaxKind.KTrue:
				case MetaTokensSyntaxKind.KFalse:
				case MetaTokensSyntaxKind.KVoid:
				case MetaTokensSyntaxKind.KObject:
				case MetaTokensSyntaxKind.KSymbol:
				case MetaTokensSyntaxKind.KString:
				case MetaTokensSyntaxKind.KInt:
				case MetaTokensSyntaxKind.KLong:
				case MetaTokensSyntaxKind.KFloat:
				case MetaTokensSyntaxKind.KDouble:
				case MetaTokensSyntaxKind.KByte:
				case MetaTokensSyntaxKind.KBool:
				case MetaTokensSyntaxKind.KList:
				case MetaTokensSyntaxKind.KAny:
				case MetaTokensSyntaxKind.KNone:
				case MetaTokensSyntaxKind.KError:
				case MetaTokensSyntaxKind.KSet:
				case MetaTokensSyntaxKind.KMultiList:
				case MetaTokensSyntaxKind.KMultiSet:
				case MetaTokensSyntaxKind.KThis:
				case MetaTokensSyntaxKind.KTypeof:
				case MetaTokensSyntaxKind.KAs:
				case MetaTokensSyntaxKind.KIs:
				case MetaTokensSyntaxKind.KBase:
				case MetaTokensSyntaxKind.KConst:
				case MetaTokensSyntaxKind.KRedefines:
				case MetaTokensSyntaxKind.KSubsets:
				case MetaTokensSyntaxKind.KReadonly:
				case MetaTokensSyntaxKind.KLazy:
				case MetaTokensSyntaxKind.KSynthetized:
				case MetaTokensSyntaxKind.KInherited:
				case MetaTokensSyntaxKind.KDerived:
				case MetaTokensSyntaxKind.KUnion:
				case MetaTokensSyntaxKind.KBuilder:
				case MetaTokensSyntaxKind.KStatic:
				case MetaTokensSyntaxKind.TSemicolon:
				case MetaTokensSyntaxKind.TColon:
				case MetaTokensSyntaxKind.TDot:
				case MetaTokensSyntaxKind.TComma:
				case MetaTokensSyntaxKind.TAssign:
				case MetaTokensSyntaxKind.TOpenParen:
				case MetaTokensSyntaxKind.TCloseParen:
				case MetaTokensSyntaxKind.TOpenBracket:
				case MetaTokensSyntaxKind.TCloseBracket:
				case MetaTokensSyntaxKind.TOpenBrace:
				case MetaTokensSyntaxKind.TCloseBrace:
				case MetaTokensSyntaxKind.TLessThan:
				case MetaTokensSyntaxKind.TGreaterThan:
				case MetaTokensSyntaxKind.TQuestion:
				case MetaTokensSyntaxKind.TQuestionQuestion:
				case MetaTokensSyntaxKind.TAmpersand:
				case MetaTokensSyntaxKind.THat:
				case MetaTokensSyntaxKind.TBar:
				case MetaTokensSyntaxKind.TAndAlso:
				case MetaTokensSyntaxKind.TOrElse:
				case MetaTokensSyntaxKind.TPlusPlus:
				case MetaTokensSyntaxKind.TMinusMinus:
				case MetaTokensSyntaxKind.TPlus:
				case MetaTokensSyntaxKind.TMinus:
				case MetaTokensSyntaxKind.TTilde:
				case MetaTokensSyntaxKind.TExclamation:
				case MetaTokensSyntaxKind.TSlash:
				case MetaTokensSyntaxKind.TPercent:
				case MetaTokensSyntaxKind.TLessThanOrEqual:
				case MetaTokensSyntaxKind.TGreaterThanOrEqual:
				case MetaTokensSyntaxKind.TEqual:
				case MetaTokensSyntaxKind.TNotEqual:
				case MetaTokensSyntaxKind.TAsteriskAssign:
				case MetaTokensSyntaxKind.TSlashAssign:
				case MetaTokensSyntaxKind.TPercentAssign:
				case MetaTokensSyntaxKind.TPlusAssign:
				case MetaTokensSyntaxKind.TMinusAssign:
				case MetaTokensSyntaxKind.TLeftShiftAssign:
				case MetaTokensSyntaxKind.TRightShiftAssign:
				case MetaTokensSyntaxKind.TAmpersandAssign:
				case MetaTokensSyntaxKind.THatAssign:
				case MetaTokensSyntaxKind.TBarAssign:
				case MetaTokensSyntaxKind.IUri:
				case MetaTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case MetaTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case MetaTokensSyntaxKind.LCommentStart:
				case MetaTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case MetaTokensSyntaxKind.LSingleQuoteVerbatimString:
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
					return MetaTokensSyntaxKind.KNamespace;
				case "using":
					return MetaTokensSyntaxKind.KUsing;
				case "metamodel":
					return MetaTokensSyntaxKind.KMetamodel;
				case "extern":
					return MetaTokensSyntaxKind.KExtern;
				case "typedef":
					return MetaTokensSyntaxKind.KTypeDef;
				case "abstract":
					return MetaTokensSyntaxKind.KAbstract;
				case "class":
					return MetaTokensSyntaxKind.KClass;
				case "struct":
					return MetaTokensSyntaxKind.KStruct;
				case "enum":
					return MetaTokensSyntaxKind.KEnum;
				case "association":
					return MetaTokensSyntaxKind.KAssociation;
				case "containment":
					return MetaTokensSyntaxKind.KContainment;
				case "with":
					return MetaTokensSyntaxKind.KWith;
				case "new":
					return MetaTokensSyntaxKind.KNew;
				case "null":
					return MetaTokensSyntaxKind.KNull;
				case "true":
					return MetaTokensSyntaxKind.KTrue;
				case "false":
					return MetaTokensSyntaxKind.KFalse;
				case "void":
					return MetaTokensSyntaxKind.KVoid;
				case "object":
					return MetaTokensSyntaxKind.KObject;
				case "symbol":
					return MetaTokensSyntaxKind.KSymbol;
				case "string":
					return MetaTokensSyntaxKind.KString;
				case "int":
					return MetaTokensSyntaxKind.KInt;
				case "long":
					return MetaTokensSyntaxKind.KLong;
				case "float":
					return MetaTokensSyntaxKind.KFloat;
				case "double":
					return MetaTokensSyntaxKind.KDouble;
				case "byte":
					return MetaTokensSyntaxKind.KByte;
				case "bool":
					return MetaTokensSyntaxKind.KBool;
				case "list":
					return MetaTokensSyntaxKind.KList;
				case "any":
					return MetaTokensSyntaxKind.KAny;
				case "none":
					return MetaTokensSyntaxKind.KNone;
				case "error":
					return MetaTokensSyntaxKind.KError;
				case "set":
					return MetaTokensSyntaxKind.KSet;
				case "multi_list":
					return MetaTokensSyntaxKind.KMultiList;
				case "multi_set":
					return MetaTokensSyntaxKind.KMultiSet;
				case "this":
					return MetaTokensSyntaxKind.KThis;
				case "typeof":
					return MetaTokensSyntaxKind.KTypeof;
				case "as":
					return MetaTokensSyntaxKind.KAs;
				case "is":
					return MetaTokensSyntaxKind.KIs;
				case "base":
					return MetaTokensSyntaxKind.KBase;
				case "const":
					return MetaTokensSyntaxKind.KConst;
				case "redefines":
					return MetaTokensSyntaxKind.KRedefines;
				case "subsets":
					return MetaTokensSyntaxKind.KSubsets;
				case "readonly":
					return MetaTokensSyntaxKind.KReadonly;
				case "lazy":
					return MetaTokensSyntaxKind.KLazy;
				case "synthetized":
					return MetaTokensSyntaxKind.KSynthetized;
				case "inherited":
					return MetaTokensSyntaxKind.KInherited;
				case "derived":
					return MetaTokensSyntaxKind.KDerived;
				case "union":
					return MetaTokensSyntaxKind.KUnion;
				case "builder":
					return MetaTokensSyntaxKind.KBuilder;
				case "static":
					return MetaTokensSyntaxKind.KStatic;
				case ";":
					return MetaTokensSyntaxKind.TSemicolon;
				case ":":
					return MetaTokensSyntaxKind.TColon;
				case ".":
					return MetaTokensSyntaxKind.TDot;
				case ",":
					return MetaTokensSyntaxKind.TComma;
				case "=":
					return MetaTokensSyntaxKind.TAssign;
				case "(":
					return MetaTokensSyntaxKind.TOpenParen;
				case ")":
					return MetaTokensSyntaxKind.TCloseParen;
				case "[":
					return MetaTokensSyntaxKind.TOpenBracket;
				case "]":
					return MetaTokensSyntaxKind.TCloseBracket;
				case "{":
					return MetaTokensSyntaxKind.TOpenBrace;
				case "}":
					return MetaTokensSyntaxKind.TCloseBrace;
				case "<":
					return MetaTokensSyntaxKind.TLessThan;
				case ">":
					return MetaTokensSyntaxKind.TGreaterThan;
				case "?":
					return MetaTokensSyntaxKind.TQuestion;
				case "??":
					return MetaTokensSyntaxKind.TQuestionQuestion;
				case "&":
					return MetaTokensSyntaxKind.TAmpersand;
				case "^":
					return MetaTokensSyntaxKind.THat;
				case "|":
					return MetaTokensSyntaxKind.TBar;
				case "&&":
					return MetaTokensSyntaxKind.TAndAlso;
				case "||":
					return MetaTokensSyntaxKind.TOrElse;
				case "++":
					return MetaTokensSyntaxKind.TPlusPlus;
				case "--":
					return MetaTokensSyntaxKind.TMinusMinus;
				case "+":
					return MetaTokensSyntaxKind.TPlus;
				case "-":
					return MetaTokensSyntaxKind.TMinus;
				case "~":
					return MetaTokensSyntaxKind.TTilde;
				case "!":
					return MetaTokensSyntaxKind.TExclamation;
				case "/":
					return MetaTokensSyntaxKind.TSlash;
				case "%":
					return MetaTokensSyntaxKind.TPercent;
				case "<=":
					return MetaTokensSyntaxKind.TLessThanOrEqual;
				case ">=":
					return MetaTokensSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return MetaTokensSyntaxKind.TEqual;
				case "!=":
					return MetaTokensSyntaxKind.TNotEqual;
				case "*=":
					return MetaTokensSyntaxKind.TAsteriskAssign;
				case "/=":
					return MetaTokensSyntaxKind.TSlashAssign;
				case "%=":
					return MetaTokensSyntaxKind.TPercentAssign;
				case "+=":
					return MetaTokensSyntaxKind.TPlusAssign;
				case "-=":
					return MetaTokensSyntaxKind.TMinusAssign;
				case "<<=":
					return MetaTokensSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return MetaTokensSyntaxKind.TRightShiftAssign;
				case "&=":
					return MetaTokensSyntaxKind.TAmpersandAssign;
				case "^=":
					return MetaTokensSyntaxKind.THatAssign;
				case "|=":
					return MetaTokensSyntaxKind.TBarAssign;
				case "Uri":
					return MetaTokensSyntaxKind.IUri;
				case "@\"":
					return MetaTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return MetaTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return MetaTokensSyntaxKind.LCommentStart;
				case "\"":
					return MetaTokensSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return MetaTokensSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return MetaTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case MetaTokensSyntaxKind.KNamespace:
					return "namespace";
				case MetaTokensSyntaxKind.KUsing:
					return "using";
				case MetaTokensSyntaxKind.KMetamodel:
					return "metamodel";
				case MetaTokensSyntaxKind.KExtern:
					return "extern";
				case MetaTokensSyntaxKind.KTypeDef:
					return "typedef";
				case MetaTokensSyntaxKind.KAbstract:
					return "abstract";
				case MetaTokensSyntaxKind.KClass:
					return "class";
				case MetaTokensSyntaxKind.KStruct:
					return "struct";
				case MetaTokensSyntaxKind.KEnum:
					return "enum";
				case MetaTokensSyntaxKind.KAssociation:
					return "association";
				case MetaTokensSyntaxKind.KContainment:
					return "containment";
				case MetaTokensSyntaxKind.KWith:
					return "with";
				case MetaTokensSyntaxKind.KNew:
					return "new";
				case MetaTokensSyntaxKind.KNull:
					return "null";
				case MetaTokensSyntaxKind.KTrue:
					return "true";
				case MetaTokensSyntaxKind.KFalse:
					return "false";
				case MetaTokensSyntaxKind.KVoid:
					return "void";
				case MetaTokensSyntaxKind.KObject:
					return "object";
				case MetaTokensSyntaxKind.KSymbol:
					return "symbol";
				case MetaTokensSyntaxKind.KString:
					return "string";
				case MetaTokensSyntaxKind.KInt:
					return "int";
				case MetaTokensSyntaxKind.KLong:
					return "long";
				case MetaTokensSyntaxKind.KFloat:
					return "float";
				case MetaTokensSyntaxKind.KDouble:
					return "double";
				case MetaTokensSyntaxKind.KByte:
					return "byte";
				case MetaTokensSyntaxKind.KBool:
					return "bool";
				case MetaTokensSyntaxKind.KList:
					return "list";
				case MetaTokensSyntaxKind.KAny:
					return "any";
				case MetaTokensSyntaxKind.KNone:
					return "none";
				case MetaTokensSyntaxKind.KError:
					return "error";
				case MetaTokensSyntaxKind.KSet:
					return "set";
				case MetaTokensSyntaxKind.KMultiList:
					return "multi_list";
				case MetaTokensSyntaxKind.KMultiSet:
					return "multi_set";
				case MetaTokensSyntaxKind.KThis:
					return "this";
				case MetaTokensSyntaxKind.KTypeof:
					return "typeof";
				case MetaTokensSyntaxKind.KAs:
					return "as";
				case MetaTokensSyntaxKind.KIs:
					return "is";
				case MetaTokensSyntaxKind.KBase:
					return "base";
				case MetaTokensSyntaxKind.KConst:
					return "const";
				case MetaTokensSyntaxKind.KRedefines:
					return "redefines";
				case MetaTokensSyntaxKind.KSubsets:
					return "subsets";
				case MetaTokensSyntaxKind.KReadonly:
					return "readonly";
				case MetaTokensSyntaxKind.KLazy:
					return "lazy";
				case MetaTokensSyntaxKind.KSynthetized:
					return "synthetized";
				case MetaTokensSyntaxKind.KInherited:
					return "inherited";
				case MetaTokensSyntaxKind.KDerived:
					return "derived";
				case MetaTokensSyntaxKind.KUnion:
					return "union";
				case MetaTokensSyntaxKind.KBuilder:
					return "builder";
				case MetaTokensSyntaxKind.KStatic:
					return "static";
				case MetaTokensSyntaxKind.TSemicolon:
					return ";";
				case MetaTokensSyntaxKind.TColon:
					return ":";
				case MetaTokensSyntaxKind.TDot:
					return ".";
				case MetaTokensSyntaxKind.TComma:
					return ",";
				case MetaTokensSyntaxKind.TAssign:
					return "=";
				case MetaTokensSyntaxKind.TOpenParen:
					return "(";
				case MetaTokensSyntaxKind.TCloseParen:
					return ")";
				case MetaTokensSyntaxKind.TOpenBracket:
					return "[";
				case MetaTokensSyntaxKind.TCloseBracket:
					return "]";
				case MetaTokensSyntaxKind.TOpenBrace:
					return "{";
				case MetaTokensSyntaxKind.TCloseBrace:
					return "}";
				case MetaTokensSyntaxKind.TLessThan:
					return "<";
				case MetaTokensSyntaxKind.TGreaterThan:
					return ">";
				case MetaTokensSyntaxKind.TQuestion:
					return "?";
				case MetaTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case MetaTokensSyntaxKind.TAmpersand:
					return "&";
				case MetaTokensSyntaxKind.THat:
					return "^";
				case MetaTokensSyntaxKind.TBar:
					return "|";
				case MetaTokensSyntaxKind.TAndAlso:
					return "&&";
				case MetaTokensSyntaxKind.TOrElse:
					return "||";
				case MetaTokensSyntaxKind.TPlusPlus:
					return "++";
				case MetaTokensSyntaxKind.TMinusMinus:
					return "--";
				case MetaTokensSyntaxKind.TPlus:
					return "+";
				case MetaTokensSyntaxKind.TMinus:
					return "-";
				case MetaTokensSyntaxKind.TTilde:
					return "~";
				case MetaTokensSyntaxKind.TExclamation:
					return "!";
				case MetaTokensSyntaxKind.TSlash:
					return "/";
				case MetaTokensSyntaxKind.TPercent:
					return "%";
				case MetaTokensSyntaxKind.TLessThanOrEqual:
					return "<=";
				case MetaTokensSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case MetaTokensSyntaxKind.TEqual:
					return "==";
				case MetaTokensSyntaxKind.TNotEqual:
					return "!=";
				case MetaTokensSyntaxKind.TAsteriskAssign:
					return "*=";
				case MetaTokensSyntaxKind.TSlashAssign:
					return "/=";
				case MetaTokensSyntaxKind.TPercentAssign:
					return "%=";
				case MetaTokensSyntaxKind.TPlusAssign:
					return "+=";
				case MetaTokensSyntaxKind.TMinusAssign:
					return "-=";
				case MetaTokensSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case MetaTokensSyntaxKind.TRightShiftAssign:
					return ">>=";
				case MetaTokensSyntaxKind.TAmpersandAssign:
					return "&=";
				case MetaTokensSyntaxKind.THatAssign:
					return "^=";
				case MetaTokensSyntaxKind.TBarAssign:
					return "|=";
				case MetaTokensSyntaxKind.IUri:
					return "Uri";
				case MetaTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case MetaTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case MetaTokensSyntaxKind.LCommentStart:
					return "/*";
				case MetaTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case MetaTokensSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public MetaTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<MetaTokensSyntaxKind>(rawKind));
		}

		public MetaTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaTokensSyntaxKind.KNamespace:
				case MetaTokensSyntaxKind.KUsing:
				case MetaTokensSyntaxKind.KMetamodel:
				case MetaTokensSyntaxKind.KExtern:
				case MetaTokensSyntaxKind.KTypeDef:
				case MetaTokensSyntaxKind.KAbstract:
				case MetaTokensSyntaxKind.KClass:
				case MetaTokensSyntaxKind.KStruct:
				case MetaTokensSyntaxKind.KEnum:
				case MetaTokensSyntaxKind.KAssociation:
				case MetaTokensSyntaxKind.KContainment:
				case MetaTokensSyntaxKind.KWith:
				case MetaTokensSyntaxKind.KNew:
				case MetaTokensSyntaxKind.KNull:
				case MetaTokensSyntaxKind.KTrue:
				case MetaTokensSyntaxKind.KFalse:
				case MetaTokensSyntaxKind.KVoid:
				case MetaTokensSyntaxKind.KObject:
				case MetaTokensSyntaxKind.KSymbol:
				case MetaTokensSyntaxKind.KString:
				case MetaTokensSyntaxKind.KInt:
				case MetaTokensSyntaxKind.KLong:
				case MetaTokensSyntaxKind.KFloat:
				case MetaTokensSyntaxKind.KDouble:
				case MetaTokensSyntaxKind.KByte:
				case MetaTokensSyntaxKind.KBool:
				case MetaTokensSyntaxKind.KList:
				case MetaTokensSyntaxKind.KAny:
				case MetaTokensSyntaxKind.KNone:
				case MetaTokensSyntaxKind.KError:
				case MetaTokensSyntaxKind.KSet:
				case MetaTokensSyntaxKind.KMultiList:
				case MetaTokensSyntaxKind.KMultiSet:
				case MetaTokensSyntaxKind.KThis:
				case MetaTokensSyntaxKind.KTypeof:
				case MetaTokensSyntaxKind.KAs:
				case MetaTokensSyntaxKind.KIs:
				case MetaTokensSyntaxKind.KBase:
				case MetaTokensSyntaxKind.KConst:
				case MetaTokensSyntaxKind.KRedefines:
				case MetaTokensSyntaxKind.KSubsets:
				case MetaTokensSyntaxKind.KReadonly:
				case MetaTokensSyntaxKind.KLazy:
				case MetaTokensSyntaxKind.KSynthetized:
				case MetaTokensSyntaxKind.KInherited:
				case MetaTokensSyntaxKind.KDerived:
				case MetaTokensSyntaxKind.KUnion:
				case MetaTokensSyntaxKind.KBuilder:
				case MetaTokensSyntaxKind.KStatic:
					return MetaTokenKind.ReservedKeyword;
				case MetaTokensSyntaxKind.IdentifierNormal:
					return MetaTokenKind.Identifier;
				case MetaTokensSyntaxKind.LInteger:
					return MetaTokenKind.Number;
				case MetaTokensSyntaxKind.LDecimal:
					return MetaTokenKind.Number;
				case MetaTokensSyntaxKind.LScientific:
					return MetaTokenKind.Number;
				case MetaTokensSyntaxKind.LDateTimeOffset:
					return MetaTokenKind.Number;
				case MetaTokensSyntaxKind.LDateTime:
					return MetaTokenKind.Number;
				case MetaTokensSyntaxKind.LDate:
					return MetaTokenKind.Number;
				case MetaTokensSyntaxKind.LTime:
					return MetaTokenKind.Number;
				case MetaTokensSyntaxKind.LRegularString:
					return MetaTokenKind.String;
				case MetaTokensSyntaxKind.LGuid:
					return MetaTokenKind.String;
				case MetaTokensSyntaxKind.LUtf8Bom:
					return MetaTokenKind.Whitespace;
				case MetaTokensSyntaxKind.LWhiteSpace:
					return MetaTokenKind.Whitespace;
				case MetaTokensSyntaxKind.LCrLf:
					return MetaTokenKind.Whitespace;
				case MetaTokensSyntaxKind.LLineEnd:
					return MetaTokenKind.Whitespace;
				case MetaTokensSyntaxKind.LSingleLineComment:
					return MetaTokenKind.GeneralComment;
				case MetaTokensSyntaxKind.LComment:
					return MetaTokenKind.GeneralComment;
				case MetaTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return MetaTokenKind.String;
				case MetaTokensSyntaxKind.LSingleQuoteVerbatimString:
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
					return MetaTokenKind.GeneralComment;
				case MetaLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return MetaTokenKind.String;
				case MetaLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return MetaTokenKind.String;
				default:
					return MetaTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaTokensSyntaxKind.LCrLf:
					return true;
				case MetaTokensSyntaxKind.LLineEnd:
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
				case MetaTokensSyntaxKind.KNamespace:
				case MetaTokensSyntaxKind.KUsing:
				case MetaTokensSyntaxKind.KMetamodel:
				case MetaTokensSyntaxKind.KExtern:
				case MetaTokensSyntaxKind.KTypeDef:
				case MetaTokensSyntaxKind.KAbstract:
				case MetaTokensSyntaxKind.KClass:
				case MetaTokensSyntaxKind.KStruct:
				case MetaTokensSyntaxKind.KEnum:
				case MetaTokensSyntaxKind.KAssociation:
				case MetaTokensSyntaxKind.KContainment:
				case MetaTokensSyntaxKind.KWith:
				case MetaTokensSyntaxKind.KNew:
				case MetaTokensSyntaxKind.KNull:
				case MetaTokensSyntaxKind.KTrue:
				case MetaTokensSyntaxKind.KFalse:
				case MetaTokensSyntaxKind.KVoid:
				case MetaTokensSyntaxKind.KObject:
				case MetaTokensSyntaxKind.KSymbol:
				case MetaTokensSyntaxKind.KString:
				case MetaTokensSyntaxKind.KInt:
				case MetaTokensSyntaxKind.KLong:
				case MetaTokensSyntaxKind.KFloat:
				case MetaTokensSyntaxKind.KDouble:
				case MetaTokensSyntaxKind.KByte:
				case MetaTokensSyntaxKind.KBool:
				case MetaTokensSyntaxKind.KList:
				case MetaTokensSyntaxKind.KAny:
				case MetaTokensSyntaxKind.KNone:
				case MetaTokensSyntaxKind.KError:
				case MetaTokensSyntaxKind.KSet:
				case MetaTokensSyntaxKind.KMultiList:
				case MetaTokensSyntaxKind.KMultiSet:
				case MetaTokensSyntaxKind.KThis:
				case MetaTokensSyntaxKind.KTypeof:
				case MetaTokensSyntaxKind.KAs:
				case MetaTokensSyntaxKind.KIs:
				case MetaTokensSyntaxKind.KBase:
				case MetaTokensSyntaxKind.KConst:
				case MetaTokensSyntaxKind.KRedefines:
				case MetaTokensSyntaxKind.KSubsets:
				case MetaTokensSyntaxKind.KReadonly:
				case MetaTokensSyntaxKind.KLazy:
				case MetaTokensSyntaxKind.KSynthetized:
				case MetaTokensSyntaxKind.KInherited:
				case MetaTokensSyntaxKind.KDerived:
				case MetaTokensSyntaxKind.KUnion:
				case MetaTokensSyntaxKind.KBuilder:
				case MetaTokensSyntaxKind.KStatic:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return MetaTokensSyntaxKind.KNamespace;
				yield return MetaTokensSyntaxKind.KUsing;
				yield return MetaTokensSyntaxKind.KMetamodel;
				yield return MetaTokensSyntaxKind.KExtern;
				yield return MetaTokensSyntaxKind.KTypeDef;
				yield return MetaTokensSyntaxKind.KAbstract;
				yield return MetaTokensSyntaxKind.KClass;
				yield return MetaTokensSyntaxKind.KStruct;
				yield return MetaTokensSyntaxKind.KEnum;
				yield return MetaTokensSyntaxKind.KAssociation;
				yield return MetaTokensSyntaxKind.KContainment;
				yield return MetaTokensSyntaxKind.KWith;
				yield return MetaTokensSyntaxKind.KNew;
				yield return MetaTokensSyntaxKind.KNull;
				yield return MetaTokensSyntaxKind.KTrue;
				yield return MetaTokensSyntaxKind.KFalse;
				yield return MetaTokensSyntaxKind.KVoid;
				yield return MetaTokensSyntaxKind.KObject;
				yield return MetaTokensSyntaxKind.KSymbol;
				yield return MetaTokensSyntaxKind.KString;
				yield return MetaTokensSyntaxKind.KInt;
				yield return MetaTokensSyntaxKind.KLong;
				yield return MetaTokensSyntaxKind.KFloat;
				yield return MetaTokensSyntaxKind.KDouble;
				yield return MetaTokensSyntaxKind.KByte;
				yield return MetaTokensSyntaxKind.KBool;
				yield return MetaTokensSyntaxKind.KList;
				yield return MetaTokensSyntaxKind.KAny;
				yield return MetaTokensSyntaxKind.KNone;
				yield return MetaTokensSyntaxKind.KError;
				yield return MetaTokensSyntaxKind.KSet;
				yield return MetaTokensSyntaxKind.KMultiList;
				yield return MetaTokensSyntaxKind.KMultiSet;
				yield return MetaTokensSyntaxKind.KThis;
				yield return MetaTokensSyntaxKind.KTypeof;
				yield return MetaTokensSyntaxKind.KAs;
				yield return MetaTokensSyntaxKind.KIs;
				yield return MetaTokensSyntaxKind.KBase;
				yield return MetaTokensSyntaxKind.KConst;
				yield return MetaTokensSyntaxKind.KRedefines;
				yield return MetaTokensSyntaxKind.KSubsets;
				yield return MetaTokensSyntaxKind.KReadonly;
				yield return MetaTokensSyntaxKind.KLazy;
				yield return MetaTokensSyntaxKind.KSynthetized;
				yield return MetaTokensSyntaxKind.KInherited;
				yield return MetaTokensSyntaxKind.KDerived;
				yield return MetaTokensSyntaxKind.KUnion;
				yield return MetaTokensSyntaxKind.KBuilder;
				yield return MetaTokensSyntaxKind.KStatic;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return MetaTokensSyntaxKind.KNamespace;
				case "using":
					return MetaTokensSyntaxKind.KUsing;
				case "metamodel":
					return MetaTokensSyntaxKind.KMetamodel;
				case "extern":
					return MetaTokensSyntaxKind.KExtern;
				case "typedef":
					return MetaTokensSyntaxKind.KTypeDef;
				case "abstract":
					return MetaTokensSyntaxKind.KAbstract;
				case "class":
					return MetaTokensSyntaxKind.KClass;
				case "struct":
					return MetaTokensSyntaxKind.KStruct;
				case "enum":
					return MetaTokensSyntaxKind.KEnum;
				case "association":
					return MetaTokensSyntaxKind.KAssociation;
				case "containment":
					return MetaTokensSyntaxKind.KContainment;
				case "with":
					return MetaTokensSyntaxKind.KWith;
				case "new":
					return MetaTokensSyntaxKind.KNew;
				case "null":
					return MetaTokensSyntaxKind.KNull;
				case "true":
					return MetaTokensSyntaxKind.KTrue;
				case "false":
					return MetaTokensSyntaxKind.KFalse;
				case "void":
					return MetaTokensSyntaxKind.KVoid;
				case "object":
					return MetaTokensSyntaxKind.KObject;
				case "symbol":
					return MetaTokensSyntaxKind.KSymbol;
				case "string":
					return MetaTokensSyntaxKind.KString;
				case "int":
					return MetaTokensSyntaxKind.KInt;
				case "long":
					return MetaTokensSyntaxKind.KLong;
				case "float":
					return MetaTokensSyntaxKind.KFloat;
				case "double":
					return MetaTokensSyntaxKind.KDouble;
				case "byte":
					return MetaTokensSyntaxKind.KByte;
				case "bool":
					return MetaTokensSyntaxKind.KBool;
				case "list":
					return MetaTokensSyntaxKind.KList;
				case "any":
					return MetaTokensSyntaxKind.KAny;
				case "none":
					return MetaTokensSyntaxKind.KNone;
				case "error":
					return MetaTokensSyntaxKind.KError;
				case "set":
					return MetaTokensSyntaxKind.KSet;
				case "multi_list":
					return MetaTokensSyntaxKind.KMultiList;
				case "multi_set":
					return MetaTokensSyntaxKind.KMultiSet;
				case "this":
					return MetaTokensSyntaxKind.KThis;
				case "typeof":
					return MetaTokensSyntaxKind.KTypeof;
				case "as":
					return MetaTokensSyntaxKind.KAs;
				case "is":
					return MetaTokensSyntaxKind.KIs;
				case "base":
					return MetaTokensSyntaxKind.KBase;
				case "const":
					return MetaTokensSyntaxKind.KConst;
				case "redefines":
					return MetaTokensSyntaxKind.KRedefines;
				case "subsets":
					return MetaTokensSyntaxKind.KSubsets;
				case "readonly":
					return MetaTokensSyntaxKind.KReadonly;
				case "lazy":
					return MetaTokensSyntaxKind.KLazy;
				case "synthetized":
					return MetaTokensSyntaxKind.KSynthetized;
				case "inherited":
					return MetaTokensSyntaxKind.KInherited;
				case "derived":
					return MetaTokensSyntaxKind.KDerived;
				case "union":
					return MetaTokensSyntaxKind.KUnion;
				case "builder":
					return MetaTokensSyntaxKind.KBuilder;
				case "static":
					return MetaTokensSyntaxKind.KStatic;
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
				case MetaTokensSyntaxKind.IdentifierNormal:
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
				case MetaTokensSyntaxKind.LInteger:
					return true;
				case MetaTokensSyntaxKind.LDecimal:
					return true;
				case MetaTokensSyntaxKind.LScientific:
					return true;
				case MetaTokensSyntaxKind.LDateTimeOffset:
					return true;
				case MetaTokensSyntaxKind.LDateTime:
					return true;
				case MetaTokensSyntaxKind.LDate:
					return true;
				case MetaTokensSyntaxKind.LTime:
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
				case MetaTokensSyntaxKind.LRegularString:
					return true;
				case MetaTokensSyntaxKind.LGuid:
					return true;
				case MetaTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case MetaTokensSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaTokensSyntaxKind.LUtf8Bom:
					return true;
				case MetaTokensSyntaxKind.LWhiteSpace:
					return true;
				case MetaTokensSyntaxKind.LCrLf:
					return true;
				case MetaTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case MetaTokensSyntaxKind.LSingleLineComment:
					return true;
				case MetaTokensSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}
	}
}

