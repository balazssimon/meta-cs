// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax
{
	public enum TestIncrementalCompilationTokenKind : int
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

	public enum TestIncrementalCompilationLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0,
		LMultilineComment = 1,
		DOUBLEQUOTE_VERBATIM_STRING = 2,
		SINGLEQUOTE_VERBATIM_STRING = 3
	}

	public class TestIncrementalCompilationTokensSyntaxFacts : SyntaxFacts
	{
        public TestIncrementalCompilationTokensSyntaxFacts() 
            : base(typeof(TestIncrementalCompilationTokensSyntaxKind))
        {
        }

        protected TestIncrementalCompilationTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (TestIncrementalCompilationTokensSyntaxKind)TestIncrementalCompilationTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (TestIncrementalCompilationTokensSyntaxKind)TestIncrementalCompilationTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (TestIncrementalCompilationTokensSyntaxKind)TestIncrementalCompilationTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (TestIncrementalCompilationTokensSyntaxKind)TestIncrementalCompilationTokensSyntaxKind.IdentifierNormal;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestIncrementalCompilationTokensSyntaxKind.Eof:
				case TestIncrementalCompilationTokensSyntaxKind.KNamespace:
				case TestIncrementalCompilationTokensSyntaxKind.KUsing:
				case TestIncrementalCompilationTokensSyntaxKind.KMetamodel:
				case TestIncrementalCompilationTokensSyntaxKind.KExtern:
				case TestIncrementalCompilationTokensSyntaxKind.KTypeDef:
				case TestIncrementalCompilationTokensSyntaxKind.KAbstract:
				case TestIncrementalCompilationTokensSyntaxKind.KClass:
				case TestIncrementalCompilationTokensSyntaxKind.KStruct:
				case TestIncrementalCompilationTokensSyntaxKind.KEnum:
				case TestIncrementalCompilationTokensSyntaxKind.KAssociation:
				case TestIncrementalCompilationTokensSyntaxKind.KContainment:
				case TestIncrementalCompilationTokensSyntaxKind.KWith:
				case TestIncrementalCompilationTokensSyntaxKind.KNew:
				case TestIncrementalCompilationTokensSyntaxKind.KNull:
				case TestIncrementalCompilationTokensSyntaxKind.KTrue:
				case TestIncrementalCompilationTokensSyntaxKind.KFalse:
				case TestIncrementalCompilationTokensSyntaxKind.KVoid:
				case TestIncrementalCompilationTokensSyntaxKind.KObject:
				case TestIncrementalCompilationTokensSyntaxKind.KSymbol:
				case TestIncrementalCompilationTokensSyntaxKind.KString:
				case TestIncrementalCompilationTokensSyntaxKind.KInt:
				case TestIncrementalCompilationTokensSyntaxKind.KLong:
				case TestIncrementalCompilationTokensSyntaxKind.KFloat:
				case TestIncrementalCompilationTokensSyntaxKind.KDouble:
				case TestIncrementalCompilationTokensSyntaxKind.KByte:
				case TestIncrementalCompilationTokensSyntaxKind.KBool:
				case TestIncrementalCompilationTokensSyntaxKind.KList:
				case TestIncrementalCompilationTokensSyntaxKind.KAny:
				case TestIncrementalCompilationTokensSyntaxKind.KNone:
				case TestIncrementalCompilationTokensSyntaxKind.KError:
				case TestIncrementalCompilationTokensSyntaxKind.KSet:
				case TestIncrementalCompilationTokensSyntaxKind.KMultiList:
				case TestIncrementalCompilationTokensSyntaxKind.KMultiSet:
				case TestIncrementalCompilationTokensSyntaxKind.KThis:
				case TestIncrementalCompilationTokensSyntaxKind.KTypeof:
				case TestIncrementalCompilationTokensSyntaxKind.KAs:
				case TestIncrementalCompilationTokensSyntaxKind.KIs:
				case TestIncrementalCompilationTokensSyntaxKind.KBase:
				case TestIncrementalCompilationTokensSyntaxKind.KConst:
				case TestIncrementalCompilationTokensSyntaxKind.KRedefines:
				case TestIncrementalCompilationTokensSyntaxKind.KSubsets:
				case TestIncrementalCompilationTokensSyntaxKind.KReadonly:
				case TestIncrementalCompilationTokensSyntaxKind.KLazy:
				case TestIncrementalCompilationTokensSyntaxKind.KSynthetized:
				case TestIncrementalCompilationTokensSyntaxKind.KInherited:
				case TestIncrementalCompilationTokensSyntaxKind.KDerived:
				case TestIncrementalCompilationTokensSyntaxKind.KUnion:
				case TestIncrementalCompilationTokensSyntaxKind.KBuilder:
				case TestIncrementalCompilationTokensSyntaxKind.KStatic:
				case TestIncrementalCompilationTokensSyntaxKind.TSemicolon:
				case TestIncrementalCompilationTokensSyntaxKind.TColon:
				case TestIncrementalCompilationTokensSyntaxKind.TDot:
				case TestIncrementalCompilationTokensSyntaxKind.TComma:
				case TestIncrementalCompilationTokensSyntaxKind.TAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TOpenParen:
				case TestIncrementalCompilationTokensSyntaxKind.TCloseParen:
				case TestIncrementalCompilationTokensSyntaxKind.TOpenBracket:
				case TestIncrementalCompilationTokensSyntaxKind.TCloseBracket:
				case TestIncrementalCompilationTokensSyntaxKind.TOpenBrace:
				case TestIncrementalCompilationTokensSyntaxKind.TCloseBrace:
				case TestIncrementalCompilationTokensSyntaxKind.TLessThan:
				case TestIncrementalCompilationTokensSyntaxKind.TGreaterThan:
				case TestIncrementalCompilationTokensSyntaxKind.TQuestion:
				case TestIncrementalCompilationTokensSyntaxKind.TQuestionQuestion:
				case TestIncrementalCompilationTokensSyntaxKind.TAmpersand:
				case TestIncrementalCompilationTokensSyntaxKind.THat:
				case TestIncrementalCompilationTokensSyntaxKind.TBar:
				case TestIncrementalCompilationTokensSyntaxKind.TAndAlso:
				case TestIncrementalCompilationTokensSyntaxKind.TOrElse:
				case TestIncrementalCompilationTokensSyntaxKind.TPlusPlus:
				case TestIncrementalCompilationTokensSyntaxKind.TMinusMinus:
				case TestIncrementalCompilationTokensSyntaxKind.TPlus:
				case TestIncrementalCompilationTokensSyntaxKind.TMinus:
				case TestIncrementalCompilationTokensSyntaxKind.TTilde:
				case TestIncrementalCompilationTokensSyntaxKind.TExclamation:
				case TestIncrementalCompilationTokensSyntaxKind.TSlash:
				case TestIncrementalCompilationTokensSyntaxKind.TAsterisk:
				case TestIncrementalCompilationTokensSyntaxKind.TPercent:
				case TestIncrementalCompilationTokensSyntaxKind.TLessThanOrEqual:
				case TestIncrementalCompilationTokensSyntaxKind.TGreaterThanOrEqual:
				case TestIncrementalCompilationTokensSyntaxKind.TEqual:
				case TestIncrementalCompilationTokensSyntaxKind.TNotEqual:
				case TestIncrementalCompilationTokensSyntaxKind.TAsteriskAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TSlashAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TPercentAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TPlusAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TMinusAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TLeftShiftAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TRightShiftAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TAmpersandAssign:
				case TestIncrementalCompilationTokensSyntaxKind.THatAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TBarAssign:
				case TestIncrementalCompilationTokensSyntaxKind.IUri:
				case TestIncrementalCompilationTokensSyntaxKind.IPrefix:
				case TestIncrementalCompilationTokensSyntaxKind.IdentifierNormal:
				case TestIncrementalCompilationTokensSyntaxKind.IdentifierVerbatim:
				case TestIncrementalCompilationTokensSyntaxKind.LInteger:
				case TestIncrementalCompilationTokensSyntaxKind.LDecimal:
				case TestIncrementalCompilationTokensSyntaxKind.LScientific:
				case TestIncrementalCompilationTokensSyntaxKind.LDateTimeOffset:
				case TestIncrementalCompilationTokensSyntaxKind.LDateTime:
				case TestIncrementalCompilationTokensSyntaxKind.LDate:
				case TestIncrementalCompilationTokensSyntaxKind.LTime:
				case TestIncrementalCompilationTokensSyntaxKind.LRegularString:
				case TestIncrementalCompilationTokensSyntaxKind.LGuid:
				case TestIncrementalCompilationTokensSyntaxKind.LUtf8Bom:
				case TestIncrementalCompilationTokensSyntaxKind.LWhiteSpace:
				case TestIncrementalCompilationTokensSyntaxKind.LCrLf:
				case TestIncrementalCompilationTokensSyntaxKind.LLineEnd:
				case TestIncrementalCompilationTokensSyntaxKind.LSingleLineComment:
				case TestIncrementalCompilationTokensSyntaxKind.LComment:
				case TestIncrementalCompilationTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case TestIncrementalCompilationTokensSyntaxKind.LSingleQuoteVerbatimString:
				case TestIncrementalCompilationTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case TestIncrementalCompilationTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case TestIncrementalCompilationTokensSyntaxKind.LCommentStart:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestIncrementalCompilationTokensSyntaxKind.KNamespace:
				case TestIncrementalCompilationTokensSyntaxKind.KUsing:
				case TestIncrementalCompilationTokensSyntaxKind.KMetamodel:
				case TestIncrementalCompilationTokensSyntaxKind.KExtern:
				case TestIncrementalCompilationTokensSyntaxKind.KTypeDef:
				case TestIncrementalCompilationTokensSyntaxKind.KAbstract:
				case TestIncrementalCompilationTokensSyntaxKind.KClass:
				case TestIncrementalCompilationTokensSyntaxKind.KStruct:
				case TestIncrementalCompilationTokensSyntaxKind.KEnum:
				case TestIncrementalCompilationTokensSyntaxKind.KAssociation:
				case TestIncrementalCompilationTokensSyntaxKind.KContainment:
				case TestIncrementalCompilationTokensSyntaxKind.KWith:
				case TestIncrementalCompilationTokensSyntaxKind.KNew:
				case TestIncrementalCompilationTokensSyntaxKind.KNull:
				case TestIncrementalCompilationTokensSyntaxKind.KTrue:
				case TestIncrementalCompilationTokensSyntaxKind.KFalse:
				case TestIncrementalCompilationTokensSyntaxKind.KVoid:
				case TestIncrementalCompilationTokensSyntaxKind.KObject:
				case TestIncrementalCompilationTokensSyntaxKind.KSymbol:
				case TestIncrementalCompilationTokensSyntaxKind.KString:
				case TestIncrementalCompilationTokensSyntaxKind.KInt:
				case TestIncrementalCompilationTokensSyntaxKind.KLong:
				case TestIncrementalCompilationTokensSyntaxKind.KFloat:
				case TestIncrementalCompilationTokensSyntaxKind.KDouble:
				case TestIncrementalCompilationTokensSyntaxKind.KByte:
				case TestIncrementalCompilationTokensSyntaxKind.KBool:
				case TestIncrementalCompilationTokensSyntaxKind.KList:
				case TestIncrementalCompilationTokensSyntaxKind.KAny:
				case TestIncrementalCompilationTokensSyntaxKind.KNone:
				case TestIncrementalCompilationTokensSyntaxKind.KError:
				case TestIncrementalCompilationTokensSyntaxKind.KSet:
				case TestIncrementalCompilationTokensSyntaxKind.KMultiList:
				case TestIncrementalCompilationTokensSyntaxKind.KMultiSet:
				case TestIncrementalCompilationTokensSyntaxKind.KThis:
				case TestIncrementalCompilationTokensSyntaxKind.KTypeof:
				case TestIncrementalCompilationTokensSyntaxKind.KAs:
				case TestIncrementalCompilationTokensSyntaxKind.KIs:
				case TestIncrementalCompilationTokensSyntaxKind.KBase:
				case TestIncrementalCompilationTokensSyntaxKind.KConst:
				case TestIncrementalCompilationTokensSyntaxKind.KRedefines:
				case TestIncrementalCompilationTokensSyntaxKind.KSubsets:
				case TestIncrementalCompilationTokensSyntaxKind.KReadonly:
				case TestIncrementalCompilationTokensSyntaxKind.KLazy:
				case TestIncrementalCompilationTokensSyntaxKind.KSynthetized:
				case TestIncrementalCompilationTokensSyntaxKind.KInherited:
				case TestIncrementalCompilationTokensSyntaxKind.KDerived:
				case TestIncrementalCompilationTokensSyntaxKind.KUnion:
				case TestIncrementalCompilationTokensSyntaxKind.KBuilder:
				case TestIncrementalCompilationTokensSyntaxKind.KStatic:
				case TestIncrementalCompilationTokensSyntaxKind.TSemicolon:
				case TestIncrementalCompilationTokensSyntaxKind.TColon:
				case TestIncrementalCompilationTokensSyntaxKind.TDot:
				case TestIncrementalCompilationTokensSyntaxKind.TComma:
				case TestIncrementalCompilationTokensSyntaxKind.TAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TOpenParen:
				case TestIncrementalCompilationTokensSyntaxKind.TCloseParen:
				case TestIncrementalCompilationTokensSyntaxKind.TOpenBracket:
				case TestIncrementalCompilationTokensSyntaxKind.TCloseBracket:
				case TestIncrementalCompilationTokensSyntaxKind.TOpenBrace:
				case TestIncrementalCompilationTokensSyntaxKind.TCloseBrace:
				case TestIncrementalCompilationTokensSyntaxKind.TLessThan:
				case TestIncrementalCompilationTokensSyntaxKind.TGreaterThan:
				case TestIncrementalCompilationTokensSyntaxKind.TQuestion:
				case TestIncrementalCompilationTokensSyntaxKind.TQuestionQuestion:
				case TestIncrementalCompilationTokensSyntaxKind.TAmpersand:
				case TestIncrementalCompilationTokensSyntaxKind.THat:
				case TestIncrementalCompilationTokensSyntaxKind.TBar:
				case TestIncrementalCompilationTokensSyntaxKind.TAndAlso:
				case TestIncrementalCompilationTokensSyntaxKind.TOrElse:
				case TestIncrementalCompilationTokensSyntaxKind.TPlusPlus:
				case TestIncrementalCompilationTokensSyntaxKind.TMinusMinus:
				case TestIncrementalCompilationTokensSyntaxKind.TPlus:
				case TestIncrementalCompilationTokensSyntaxKind.TMinus:
				case TestIncrementalCompilationTokensSyntaxKind.TTilde:
				case TestIncrementalCompilationTokensSyntaxKind.TExclamation:
				case TestIncrementalCompilationTokensSyntaxKind.TSlash:
				case TestIncrementalCompilationTokensSyntaxKind.TPercent:
				case TestIncrementalCompilationTokensSyntaxKind.TLessThanOrEqual:
				case TestIncrementalCompilationTokensSyntaxKind.TGreaterThanOrEqual:
				case TestIncrementalCompilationTokensSyntaxKind.TEqual:
				case TestIncrementalCompilationTokensSyntaxKind.TNotEqual:
				case TestIncrementalCompilationTokensSyntaxKind.TAsteriskAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TSlashAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TPercentAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TPlusAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TMinusAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TLeftShiftAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TRightShiftAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TAmpersandAssign:
				case TestIncrementalCompilationTokensSyntaxKind.THatAssign:
				case TestIncrementalCompilationTokensSyntaxKind.TBarAssign:
				case TestIncrementalCompilationTokensSyntaxKind.IUri:
				case TestIncrementalCompilationTokensSyntaxKind.IPrefix:
				case TestIncrementalCompilationTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
				case TestIncrementalCompilationTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
				case TestIncrementalCompilationTokensSyntaxKind.LCommentStart:
				case TestIncrementalCompilationTokensSyntaxKind.LDoubleQuoteVerbatimString:
				case TestIncrementalCompilationTokensSyntaxKind.LSingleQuoteVerbatimString:
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
					return TestIncrementalCompilationTokensSyntaxKind.KNamespace;
				case "using":
					return TestIncrementalCompilationTokensSyntaxKind.KUsing;
				case "metamodel":
					return TestIncrementalCompilationTokensSyntaxKind.KMetamodel;
				case "extern":
					return TestIncrementalCompilationTokensSyntaxKind.KExtern;
				case "typedef":
					return TestIncrementalCompilationTokensSyntaxKind.KTypeDef;
				case "abstract":
					return TestIncrementalCompilationTokensSyntaxKind.KAbstract;
				case "class":
					return TestIncrementalCompilationTokensSyntaxKind.KClass;
				case "struct":
					return TestIncrementalCompilationTokensSyntaxKind.KStruct;
				case "enum":
					return TestIncrementalCompilationTokensSyntaxKind.KEnum;
				case "association":
					return TestIncrementalCompilationTokensSyntaxKind.KAssociation;
				case "containment":
					return TestIncrementalCompilationTokensSyntaxKind.KContainment;
				case "with":
					return TestIncrementalCompilationTokensSyntaxKind.KWith;
				case "new":
					return TestIncrementalCompilationTokensSyntaxKind.KNew;
				case "null":
					return TestIncrementalCompilationTokensSyntaxKind.KNull;
				case "true":
					return TestIncrementalCompilationTokensSyntaxKind.KTrue;
				case "false":
					return TestIncrementalCompilationTokensSyntaxKind.KFalse;
				case "void":
					return TestIncrementalCompilationTokensSyntaxKind.KVoid;
				case "object":
					return TestIncrementalCompilationTokensSyntaxKind.KObject;
				case "symbol":
					return TestIncrementalCompilationTokensSyntaxKind.KSymbol;
				case "string":
					return TestIncrementalCompilationTokensSyntaxKind.KString;
				case "int":
					return TestIncrementalCompilationTokensSyntaxKind.KInt;
				case "long":
					return TestIncrementalCompilationTokensSyntaxKind.KLong;
				case "float":
					return TestIncrementalCompilationTokensSyntaxKind.KFloat;
				case "double":
					return TestIncrementalCompilationTokensSyntaxKind.KDouble;
				case "byte":
					return TestIncrementalCompilationTokensSyntaxKind.KByte;
				case "bool":
					return TestIncrementalCompilationTokensSyntaxKind.KBool;
				case "list":
					return TestIncrementalCompilationTokensSyntaxKind.KList;
				case "any":
					return TestIncrementalCompilationTokensSyntaxKind.KAny;
				case "none":
					return TestIncrementalCompilationTokensSyntaxKind.KNone;
				case "error":
					return TestIncrementalCompilationTokensSyntaxKind.KError;
				case "set":
					return TestIncrementalCompilationTokensSyntaxKind.KSet;
				case "multi_list":
					return TestIncrementalCompilationTokensSyntaxKind.KMultiList;
				case "multi_set":
					return TestIncrementalCompilationTokensSyntaxKind.KMultiSet;
				case "this":
					return TestIncrementalCompilationTokensSyntaxKind.KThis;
				case "typeof":
					return TestIncrementalCompilationTokensSyntaxKind.KTypeof;
				case "as":
					return TestIncrementalCompilationTokensSyntaxKind.KAs;
				case "is":
					return TestIncrementalCompilationTokensSyntaxKind.KIs;
				case "base":
					return TestIncrementalCompilationTokensSyntaxKind.KBase;
				case "const":
					return TestIncrementalCompilationTokensSyntaxKind.KConst;
				case "redefines":
					return TestIncrementalCompilationTokensSyntaxKind.KRedefines;
				case "subsets":
					return TestIncrementalCompilationTokensSyntaxKind.KSubsets;
				case "readonly":
					return TestIncrementalCompilationTokensSyntaxKind.KReadonly;
				case "lazy":
					return TestIncrementalCompilationTokensSyntaxKind.KLazy;
				case "synthetized":
					return TestIncrementalCompilationTokensSyntaxKind.KSynthetized;
				case "inherited":
					return TestIncrementalCompilationTokensSyntaxKind.KInherited;
				case "derived":
					return TestIncrementalCompilationTokensSyntaxKind.KDerived;
				case "union":
					return TestIncrementalCompilationTokensSyntaxKind.KUnion;
				case "builder":
					return TestIncrementalCompilationTokensSyntaxKind.KBuilder;
				case "static":
					return TestIncrementalCompilationTokensSyntaxKind.KStatic;
				case ";":
					return TestIncrementalCompilationTokensSyntaxKind.TSemicolon;
				case ":":
					return TestIncrementalCompilationTokensSyntaxKind.TColon;
				case ".":
					return TestIncrementalCompilationTokensSyntaxKind.TDot;
				case ",":
					return TestIncrementalCompilationTokensSyntaxKind.TComma;
				case "=":
					return TestIncrementalCompilationTokensSyntaxKind.TAssign;
				case "(":
					return TestIncrementalCompilationTokensSyntaxKind.TOpenParen;
				case ")":
					return TestIncrementalCompilationTokensSyntaxKind.TCloseParen;
				case "[":
					return TestIncrementalCompilationTokensSyntaxKind.TOpenBracket;
				case "]":
					return TestIncrementalCompilationTokensSyntaxKind.TCloseBracket;
				case "{":
					return TestIncrementalCompilationTokensSyntaxKind.TOpenBrace;
				case "}":
					return TestIncrementalCompilationTokensSyntaxKind.TCloseBrace;
				case "<":
					return TestIncrementalCompilationTokensSyntaxKind.TLessThan;
				case ">":
					return TestIncrementalCompilationTokensSyntaxKind.TGreaterThan;
				case "?":
					return TestIncrementalCompilationTokensSyntaxKind.TQuestion;
				case "??":
					return TestIncrementalCompilationTokensSyntaxKind.TQuestionQuestion;
				case "&":
					return TestIncrementalCompilationTokensSyntaxKind.TAmpersand;
				case "^":
					return TestIncrementalCompilationTokensSyntaxKind.THat;
				case "|":
					return TestIncrementalCompilationTokensSyntaxKind.TBar;
				case "&&":
					return TestIncrementalCompilationTokensSyntaxKind.TAndAlso;
				case "||":
					return TestIncrementalCompilationTokensSyntaxKind.TOrElse;
				case "++":
					return TestIncrementalCompilationTokensSyntaxKind.TPlusPlus;
				case "--":
					return TestIncrementalCompilationTokensSyntaxKind.TMinusMinus;
				case "+":
					return TestIncrementalCompilationTokensSyntaxKind.TPlus;
				case "-":
					return TestIncrementalCompilationTokensSyntaxKind.TMinus;
				case "~":
					return TestIncrementalCompilationTokensSyntaxKind.TTilde;
				case "!":
					return TestIncrementalCompilationTokensSyntaxKind.TExclamation;
				case "/":
					return TestIncrementalCompilationTokensSyntaxKind.TSlash;
				case "%":
					return TestIncrementalCompilationTokensSyntaxKind.TPercent;
				case "<=":
					return TestIncrementalCompilationTokensSyntaxKind.TLessThanOrEqual;
				case ">=":
					return TestIncrementalCompilationTokensSyntaxKind.TGreaterThanOrEqual;
				case "==":
					return TestIncrementalCompilationTokensSyntaxKind.TEqual;
				case "!=":
					return TestIncrementalCompilationTokensSyntaxKind.TNotEqual;
				case "*=":
					return TestIncrementalCompilationTokensSyntaxKind.TAsteriskAssign;
				case "/=":
					return TestIncrementalCompilationTokensSyntaxKind.TSlashAssign;
				case "%=":
					return TestIncrementalCompilationTokensSyntaxKind.TPercentAssign;
				case "+=":
					return TestIncrementalCompilationTokensSyntaxKind.TPlusAssign;
				case "-=":
					return TestIncrementalCompilationTokensSyntaxKind.TMinusAssign;
				case "<<=":
					return TestIncrementalCompilationTokensSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return TestIncrementalCompilationTokensSyntaxKind.TRightShiftAssign;
				case "&=":
					return TestIncrementalCompilationTokensSyntaxKind.TAmpersandAssign;
				case "^=":
					return TestIncrementalCompilationTokensSyntaxKind.THatAssign;
				case "|=":
					return TestIncrementalCompilationTokensSyntaxKind.TBarAssign;
				case "Uri":
					return TestIncrementalCompilationTokensSyntaxKind.IUri;
				case "Prefix":
					return TestIncrementalCompilationTokensSyntaxKind.IPrefix;
				case "@\"":
					return TestIncrementalCompilationTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart;
				case "@\'":
					return TestIncrementalCompilationTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart;
				case "/*":
					return TestIncrementalCompilationTokensSyntaxKind.LCommentStart;
				case "\"":
					return TestIncrementalCompilationTokensSyntaxKind.LDoubleQuoteVerbatimString;
				case "\'":
					return TestIncrementalCompilationTokensSyntaxKind.LSingleQuoteVerbatimString;
				default:
					return TestIncrementalCompilationTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case TestIncrementalCompilationTokensSyntaxKind.KNamespace:
					return "namespace";
				case TestIncrementalCompilationTokensSyntaxKind.KUsing:
					return "using";
				case TestIncrementalCompilationTokensSyntaxKind.KMetamodel:
					return "metamodel";
				case TestIncrementalCompilationTokensSyntaxKind.KExtern:
					return "extern";
				case TestIncrementalCompilationTokensSyntaxKind.KTypeDef:
					return "typedef";
				case TestIncrementalCompilationTokensSyntaxKind.KAbstract:
					return "abstract";
				case TestIncrementalCompilationTokensSyntaxKind.KClass:
					return "class";
				case TestIncrementalCompilationTokensSyntaxKind.KStruct:
					return "struct";
				case TestIncrementalCompilationTokensSyntaxKind.KEnum:
					return "enum";
				case TestIncrementalCompilationTokensSyntaxKind.KAssociation:
					return "association";
				case TestIncrementalCompilationTokensSyntaxKind.KContainment:
					return "containment";
				case TestIncrementalCompilationTokensSyntaxKind.KWith:
					return "with";
				case TestIncrementalCompilationTokensSyntaxKind.KNew:
					return "new";
				case TestIncrementalCompilationTokensSyntaxKind.KNull:
					return "null";
				case TestIncrementalCompilationTokensSyntaxKind.KTrue:
					return "true";
				case TestIncrementalCompilationTokensSyntaxKind.KFalse:
					return "false";
				case TestIncrementalCompilationTokensSyntaxKind.KVoid:
					return "void";
				case TestIncrementalCompilationTokensSyntaxKind.KObject:
					return "object";
				case TestIncrementalCompilationTokensSyntaxKind.KSymbol:
					return "symbol";
				case TestIncrementalCompilationTokensSyntaxKind.KString:
					return "string";
				case TestIncrementalCompilationTokensSyntaxKind.KInt:
					return "int";
				case TestIncrementalCompilationTokensSyntaxKind.KLong:
					return "long";
				case TestIncrementalCompilationTokensSyntaxKind.KFloat:
					return "float";
				case TestIncrementalCompilationTokensSyntaxKind.KDouble:
					return "double";
				case TestIncrementalCompilationTokensSyntaxKind.KByte:
					return "byte";
				case TestIncrementalCompilationTokensSyntaxKind.KBool:
					return "bool";
				case TestIncrementalCompilationTokensSyntaxKind.KList:
					return "list";
				case TestIncrementalCompilationTokensSyntaxKind.KAny:
					return "any";
				case TestIncrementalCompilationTokensSyntaxKind.KNone:
					return "none";
				case TestIncrementalCompilationTokensSyntaxKind.KError:
					return "error";
				case TestIncrementalCompilationTokensSyntaxKind.KSet:
					return "set";
				case TestIncrementalCompilationTokensSyntaxKind.KMultiList:
					return "multi_list";
				case TestIncrementalCompilationTokensSyntaxKind.KMultiSet:
					return "multi_set";
				case TestIncrementalCompilationTokensSyntaxKind.KThis:
					return "this";
				case TestIncrementalCompilationTokensSyntaxKind.KTypeof:
					return "typeof";
				case TestIncrementalCompilationTokensSyntaxKind.KAs:
					return "as";
				case TestIncrementalCompilationTokensSyntaxKind.KIs:
					return "is";
				case TestIncrementalCompilationTokensSyntaxKind.KBase:
					return "base";
				case TestIncrementalCompilationTokensSyntaxKind.KConst:
					return "const";
				case TestIncrementalCompilationTokensSyntaxKind.KRedefines:
					return "redefines";
				case TestIncrementalCompilationTokensSyntaxKind.KSubsets:
					return "subsets";
				case TestIncrementalCompilationTokensSyntaxKind.KReadonly:
					return "readonly";
				case TestIncrementalCompilationTokensSyntaxKind.KLazy:
					return "lazy";
				case TestIncrementalCompilationTokensSyntaxKind.KSynthetized:
					return "synthetized";
				case TestIncrementalCompilationTokensSyntaxKind.KInherited:
					return "inherited";
				case TestIncrementalCompilationTokensSyntaxKind.KDerived:
					return "derived";
				case TestIncrementalCompilationTokensSyntaxKind.KUnion:
					return "union";
				case TestIncrementalCompilationTokensSyntaxKind.KBuilder:
					return "builder";
				case TestIncrementalCompilationTokensSyntaxKind.KStatic:
					return "static";
				case TestIncrementalCompilationTokensSyntaxKind.TSemicolon:
					return ";";
				case TestIncrementalCompilationTokensSyntaxKind.TColon:
					return ":";
				case TestIncrementalCompilationTokensSyntaxKind.TDot:
					return ".";
				case TestIncrementalCompilationTokensSyntaxKind.TComma:
					return ",";
				case TestIncrementalCompilationTokensSyntaxKind.TAssign:
					return "=";
				case TestIncrementalCompilationTokensSyntaxKind.TOpenParen:
					return "(";
				case TestIncrementalCompilationTokensSyntaxKind.TCloseParen:
					return ")";
				case TestIncrementalCompilationTokensSyntaxKind.TOpenBracket:
					return "[";
				case TestIncrementalCompilationTokensSyntaxKind.TCloseBracket:
					return "]";
				case TestIncrementalCompilationTokensSyntaxKind.TOpenBrace:
					return "{";
				case TestIncrementalCompilationTokensSyntaxKind.TCloseBrace:
					return "}";
				case TestIncrementalCompilationTokensSyntaxKind.TLessThan:
					return "<";
				case TestIncrementalCompilationTokensSyntaxKind.TGreaterThan:
					return ">";
				case TestIncrementalCompilationTokensSyntaxKind.TQuestion:
					return "?";
				case TestIncrementalCompilationTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case TestIncrementalCompilationTokensSyntaxKind.TAmpersand:
					return "&";
				case TestIncrementalCompilationTokensSyntaxKind.THat:
					return "^";
				case TestIncrementalCompilationTokensSyntaxKind.TBar:
					return "|";
				case TestIncrementalCompilationTokensSyntaxKind.TAndAlso:
					return "&&";
				case TestIncrementalCompilationTokensSyntaxKind.TOrElse:
					return "||";
				case TestIncrementalCompilationTokensSyntaxKind.TPlusPlus:
					return "++";
				case TestIncrementalCompilationTokensSyntaxKind.TMinusMinus:
					return "--";
				case TestIncrementalCompilationTokensSyntaxKind.TPlus:
					return "+";
				case TestIncrementalCompilationTokensSyntaxKind.TMinus:
					return "-";
				case TestIncrementalCompilationTokensSyntaxKind.TTilde:
					return "~";
				case TestIncrementalCompilationTokensSyntaxKind.TExclamation:
					return "!";
				case TestIncrementalCompilationTokensSyntaxKind.TSlash:
					return "/";
				case TestIncrementalCompilationTokensSyntaxKind.TPercent:
					return "%";
				case TestIncrementalCompilationTokensSyntaxKind.TLessThanOrEqual:
					return "<=";
				case TestIncrementalCompilationTokensSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case TestIncrementalCompilationTokensSyntaxKind.TEqual:
					return "==";
				case TestIncrementalCompilationTokensSyntaxKind.TNotEqual:
					return "!=";
				case TestIncrementalCompilationTokensSyntaxKind.TAsteriskAssign:
					return "*=";
				case TestIncrementalCompilationTokensSyntaxKind.TSlashAssign:
					return "/=";
				case TestIncrementalCompilationTokensSyntaxKind.TPercentAssign:
					return "%=";
				case TestIncrementalCompilationTokensSyntaxKind.TPlusAssign:
					return "+=";
				case TestIncrementalCompilationTokensSyntaxKind.TMinusAssign:
					return "-=";
				case TestIncrementalCompilationTokensSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case TestIncrementalCompilationTokensSyntaxKind.TRightShiftAssign:
					return ">>=";
				case TestIncrementalCompilationTokensSyntaxKind.TAmpersandAssign:
					return "&=";
				case TestIncrementalCompilationTokensSyntaxKind.THatAssign:
					return "^=";
				case TestIncrementalCompilationTokensSyntaxKind.TBarAssign:
					return "|=";
				case TestIncrementalCompilationTokensSyntaxKind.IUri:
					return "Uri";
				case TestIncrementalCompilationTokensSyntaxKind.IPrefix:
					return "Prefix";
				case TestIncrementalCompilationTokensSyntaxKind.DoubleQuoteVerbatimStringLiteralStart:
					return "@\"";
				case TestIncrementalCompilationTokensSyntaxKind.SingleQuoteVerbatimStringLiteralStart:
					return "@\'";
				case TestIncrementalCompilationTokensSyntaxKind.LCommentStart:
					return "/*";
				case TestIncrementalCompilationTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return "\"";
				case TestIncrementalCompilationTokensSyntaxKind.LSingleQuoteVerbatimString:
					return "\'";
				default:
					return string.Empty;
			}
		}

		public TestIncrementalCompilationTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<TestIncrementalCompilationTokensSyntaxKind>(rawKind));
		}

		public TestIncrementalCompilationTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestIncrementalCompilationTokensSyntaxKind.KNamespace:
				case TestIncrementalCompilationTokensSyntaxKind.KUsing:
				case TestIncrementalCompilationTokensSyntaxKind.KMetamodel:
				case TestIncrementalCompilationTokensSyntaxKind.KExtern:
				case TestIncrementalCompilationTokensSyntaxKind.KTypeDef:
				case TestIncrementalCompilationTokensSyntaxKind.KAbstract:
				case TestIncrementalCompilationTokensSyntaxKind.KClass:
				case TestIncrementalCompilationTokensSyntaxKind.KStruct:
				case TestIncrementalCompilationTokensSyntaxKind.KEnum:
				case TestIncrementalCompilationTokensSyntaxKind.KAssociation:
				case TestIncrementalCompilationTokensSyntaxKind.KContainment:
				case TestIncrementalCompilationTokensSyntaxKind.KWith:
				case TestIncrementalCompilationTokensSyntaxKind.KNew:
				case TestIncrementalCompilationTokensSyntaxKind.KNull:
				case TestIncrementalCompilationTokensSyntaxKind.KTrue:
				case TestIncrementalCompilationTokensSyntaxKind.KFalse:
				case TestIncrementalCompilationTokensSyntaxKind.KVoid:
				case TestIncrementalCompilationTokensSyntaxKind.KObject:
				case TestIncrementalCompilationTokensSyntaxKind.KSymbol:
				case TestIncrementalCompilationTokensSyntaxKind.KString:
				case TestIncrementalCompilationTokensSyntaxKind.KInt:
				case TestIncrementalCompilationTokensSyntaxKind.KLong:
				case TestIncrementalCompilationTokensSyntaxKind.KFloat:
				case TestIncrementalCompilationTokensSyntaxKind.KDouble:
				case TestIncrementalCompilationTokensSyntaxKind.KByte:
				case TestIncrementalCompilationTokensSyntaxKind.KBool:
				case TestIncrementalCompilationTokensSyntaxKind.KList:
				case TestIncrementalCompilationTokensSyntaxKind.KAny:
				case TestIncrementalCompilationTokensSyntaxKind.KNone:
				case TestIncrementalCompilationTokensSyntaxKind.KError:
				case TestIncrementalCompilationTokensSyntaxKind.KSet:
				case TestIncrementalCompilationTokensSyntaxKind.KMultiList:
				case TestIncrementalCompilationTokensSyntaxKind.KMultiSet:
				case TestIncrementalCompilationTokensSyntaxKind.KThis:
				case TestIncrementalCompilationTokensSyntaxKind.KTypeof:
				case TestIncrementalCompilationTokensSyntaxKind.KAs:
				case TestIncrementalCompilationTokensSyntaxKind.KIs:
				case TestIncrementalCompilationTokensSyntaxKind.KBase:
				case TestIncrementalCompilationTokensSyntaxKind.KConst:
				case TestIncrementalCompilationTokensSyntaxKind.KRedefines:
				case TestIncrementalCompilationTokensSyntaxKind.KSubsets:
				case TestIncrementalCompilationTokensSyntaxKind.KReadonly:
				case TestIncrementalCompilationTokensSyntaxKind.KLazy:
				case TestIncrementalCompilationTokensSyntaxKind.KSynthetized:
				case TestIncrementalCompilationTokensSyntaxKind.KInherited:
				case TestIncrementalCompilationTokensSyntaxKind.KDerived:
				case TestIncrementalCompilationTokensSyntaxKind.KUnion:
				case TestIncrementalCompilationTokensSyntaxKind.KBuilder:
				case TestIncrementalCompilationTokensSyntaxKind.KStatic:
					return TestIncrementalCompilationTokenKind.ReservedKeyword;
				case TestIncrementalCompilationTokensSyntaxKind.IdentifierNormal:
					return TestIncrementalCompilationTokenKind.Identifier;
				case TestIncrementalCompilationTokensSyntaxKind.LInteger:
					return TestIncrementalCompilationTokenKind.Number;
				case TestIncrementalCompilationTokensSyntaxKind.LDecimal:
					return TestIncrementalCompilationTokenKind.Number;
				case TestIncrementalCompilationTokensSyntaxKind.LScientific:
					return TestIncrementalCompilationTokenKind.Number;
				case TestIncrementalCompilationTokensSyntaxKind.LDateTimeOffset:
					return TestIncrementalCompilationTokenKind.Number;
				case TestIncrementalCompilationTokensSyntaxKind.LDateTime:
					return TestIncrementalCompilationTokenKind.Number;
				case TestIncrementalCompilationTokensSyntaxKind.LDate:
					return TestIncrementalCompilationTokenKind.Number;
				case TestIncrementalCompilationTokensSyntaxKind.LTime:
					return TestIncrementalCompilationTokenKind.Number;
				case TestIncrementalCompilationTokensSyntaxKind.LRegularString:
					return TestIncrementalCompilationTokenKind.String;
				case TestIncrementalCompilationTokensSyntaxKind.LGuid:
					return TestIncrementalCompilationTokenKind.String;
				case TestIncrementalCompilationTokensSyntaxKind.LUtf8Bom:
					return TestIncrementalCompilationTokenKind.Whitespace;
				case TestIncrementalCompilationTokensSyntaxKind.LWhiteSpace:
					return TestIncrementalCompilationTokenKind.Whitespace;
				case TestIncrementalCompilationTokensSyntaxKind.LCrLf:
					return TestIncrementalCompilationTokenKind.Whitespace;
				case TestIncrementalCompilationTokensSyntaxKind.LLineEnd:
					return TestIncrementalCompilationTokenKind.Whitespace;
				case TestIncrementalCompilationTokensSyntaxKind.LSingleLineComment:
					return TestIncrementalCompilationTokenKind.GeneralComment;
				case TestIncrementalCompilationTokensSyntaxKind.LComment:
					return TestIncrementalCompilationTokenKind.GeneralComment;
				case TestIncrementalCompilationTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return TestIncrementalCompilationTokenKind.String;
				case TestIncrementalCompilationTokensSyntaxKind.LSingleQuoteVerbatimString:
					return TestIncrementalCompilationTokenKind.String;
				default:
					return TestIncrementalCompilationTokenKind.None;
			}
		}

		public TestIncrementalCompilationTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((TestIncrementalCompilationLexerMode)rawKind);
		}

		public TestIncrementalCompilationTokenKind GetModeTokenKind(TestIncrementalCompilationLexerMode kind)
		{
			switch(kind)
			{
				case TestIncrementalCompilationLexerMode.LMultilineComment:
					return TestIncrementalCompilationTokenKind.GeneralComment;
				case TestIncrementalCompilationLexerMode.DOUBLEQUOTE_VERBATIM_STRING:
					return TestIncrementalCompilationTokenKind.String;
				case TestIncrementalCompilationLexerMode.SINGLEQUOTE_VERBATIM_STRING:
					return TestIncrementalCompilationTokenKind.String;
				default:
					return TestIncrementalCompilationTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestIncrementalCompilationTokensSyntaxKind.LCrLf:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LLineEnd:
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
				case TestIncrementalCompilationTokensSyntaxKind.KNamespace:
				case TestIncrementalCompilationTokensSyntaxKind.KUsing:
				case TestIncrementalCompilationTokensSyntaxKind.KMetamodel:
				case TestIncrementalCompilationTokensSyntaxKind.KExtern:
				case TestIncrementalCompilationTokensSyntaxKind.KTypeDef:
				case TestIncrementalCompilationTokensSyntaxKind.KAbstract:
				case TestIncrementalCompilationTokensSyntaxKind.KClass:
				case TestIncrementalCompilationTokensSyntaxKind.KStruct:
				case TestIncrementalCompilationTokensSyntaxKind.KEnum:
				case TestIncrementalCompilationTokensSyntaxKind.KAssociation:
				case TestIncrementalCompilationTokensSyntaxKind.KContainment:
				case TestIncrementalCompilationTokensSyntaxKind.KWith:
				case TestIncrementalCompilationTokensSyntaxKind.KNew:
				case TestIncrementalCompilationTokensSyntaxKind.KNull:
				case TestIncrementalCompilationTokensSyntaxKind.KTrue:
				case TestIncrementalCompilationTokensSyntaxKind.KFalse:
				case TestIncrementalCompilationTokensSyntaxKind.KVoid:
				case TestIncrementalCompilationTokensSyntaxKind.KObject:
				case TestIncrementalCompilationTokensSyntaxKind.KSymbol:
				case TestIncrementalCompilationTokensSyntaxKind.KString:
				case TestIncrementalCompilationTokensSyntaxKind.KInt:
				case TestIncrementalCompilationTokensSyntaxKind.KLong:
				case TestIncrementalCompilationTokensSyntaxKind.KFloat:
				case TestIncrementalCompilationTokensSyntaxKind.KDouble:
				case TestIncrementalCompilationTokensSyntaxKind.KByte:
				case TestIncrementalCompilationTokensSyntaxKind.KBool:
				case TestIncrementalCompilationTokensSyntaxKind.KList:
				case TestIncrementalCompilationTokensSyntaxKind.KAny:
				case TestIncrementalCompilationTokensSyntaxKind.KNone:
				case TestIncrementalCompilationTokensSyntaxKind.KError:
				case TestIncrementalCompilationTokensSyntaxKind.KSet:
				case TestIncrementalCompilationTokensSyntaxKind.KMultiList:
				case TestIncrementalCompilationTokensSyntaxKind.KMultiSet:
				case TestIncrementalCompilationTokensSyntaxKind.KThis:
				case TestIncrementalCompilationTokensSyntaxKind.KTypeof:
				case TestIncrementalCompilationTokensSyntaxKind.KAs:
				case TestIncrementalCompilationTokensSyntaxKind.KIs:
				case TestIncrementalCompilationTokensSyntaxKind.KBase:
				case TestIncrementalCompilationTokensSyntaxKind.KConst:
				case TestIncrementalCompilationTokensSyntaxKind.KRedefines:
				case TestIncrementalCompilationTokensSyntaxKind.KSubsets:
				case TestIncrementalCompilationTokensSyntaxKind.KReadonly:
				case TestIncrementalCompilationTokensSyntaxKind.KLazy:
				case TestIncrementalCompilationTokensSyntaxKind.KSynthetized:
				case TestIncrementalCompilationTokensSyntaxKind.KInherited:
				case TestIncrementalCompilationTokensSyntaxKind.KDerived:
				case TestIncrementalCompilationTokensSyntaxKind.KUnion:
				case TestIncrementalCompilationTokensSyntaxKind.KBuilder:
				case TestIncrementalCompilationTokensSyntaxKind.KStatic:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return TestIncrementalCompilationTokensSyntaxKind.KNamespace;
				yield return TestIncrementalCompilationTokensSyntaxKind.KUsing;
				yield return TestIncrementalCompilationTokensSyntaxKind.KMetamodel;
				yield return TestIncrementalCompilationTokensSyntaxKind.KExtern;
				yield return TestIncrementalCompilationTokensSyntaxKind.KTypeDef;
				yield return TestIncrementalCompilationTokensSyntaxKind.KAbstract;
				yield return TestIncrementalCompilationTokensSyntaxKind.KClass;
				yield return TestIncrementalCompilationTokensSyntaxKind.KStruct;
				yield return TestIncrementalCompilationTokensSyntaxKind.KEnum;
				yield return TestIncrementalCompilationTokensSyntaxKind.KAssociation;
				yield return TestIncrementalCompilationTokensSyntaxKind.KContainment;
				yield return TestIncrementalCompilationTokensSyntaxKind.KWith;
				yield return TestIncrementalCompilationTokensSyntaxKind.KNew;
				yield return TestIncrementalCompilationTokensSyntaxKind.KNull;
				yield return TestIncrementalCompilationTokensSyntaxKind.KTrue;
				yield return TestIncrementalCompilationTokensSyntaxKind.KFalse;
				yield return TestIncrementalCompilationTokensSyntaxKind.KVoid;
				yield return TestIncrementalCompilationTokensSyntaxKind.KObject;
				yield return TestIncrementalCompilationTokensSyntaxKind.KSymbol;
				yield return TestIncrementalCompilationTokensSyntaxKind.KString;
				yield return TestIncrementalCompilationTokensSyntaxKind.KInt;
				yield return TestIncrementalCompilationTokensSyntaxKind.KLong;
				yield return TestIncrementalCompilationTokensSyntaxKind.KFloat;
				yield return TestIncrementalCompilationTokensSyntaxKind.KDouble;
				yield return TestIncrementalCompilationTokensSyntaxKind.KByte;
				yield return TestIncrementalCompilationTokensSyntaxKind.KBool;
				yield return TestIncrementalCompilationTokensSyntaxKind.KList;
				yield return TestIncrementalCompilationTokensSyntaxKind.KAny;
				yield return TestIncrementalCompilationTokensSyntaxKind.KNone;
				yield return TestIncrementalCompilationTokensSyntaxKind.KError;
				yield return TestIncrementalCompilationTokensSyntaxKind.KSet;
				yield return TestIncrementalCompilationTokensSyntaxKind.KMultiList;
				yield return TestIncrementalCompilationTokensSyntaxKind.KMultiSet;
				yield return TestIncrementalCompilationTokensSyntaxKind.KThis;
				yield return TestIncrementalCompilationTokensSyntaxKind.KTypeof;
				yield return TestIncrementalCompilationTokensSyntaxKind.KAs;
				yield return TestIncrementalCompilationTokensSyntaxKind.KIs;
				yield return TestIncrementalCompilationTokensSyntaxKind.KBase;
				yield return TestIncrementalCompilationTokensSyntaxKind.KConst;
				yield return TestIncrementalCompilationTokensSyntaxKind.KRedefines;
				yield return TestIncrementalCompilationTokensSyntaxKind.KSubsets;
				yield return TestIncrementalCompilationTokensSyntaxKind.KReadonly;
				yield return TestIncrementalCompilationTokensSyntaxKind.KLazy;
				yield return TestIncrementalCompilationTokensSyntaxKind.KSynthetized;
				yield return TestIncrementalCompilationTokensSyntaxKind.KInherited;
				yield return TestIncrementalCompilationTokensSyntaxKind.KDerived;
				yield return TestIncrementalCompilationTokensSyntaxKind.KUnion;
				yield return TestIncrementalCompilationTokensSyntaxKind.KBuilder;
				yield return TestIncrementalCompilationTokensSyntaxKind.KStatic;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "namespace":
					return TestIncrementalCompilationTokensSyntaxKind.KNamespace;
				case "using":
					return TestIncrementalCompilationTokensSyntaxKind.KUsing;
				case "metamodel":
					return TestIncrementalCompilationTokensSyntaxKind.KMetamodel;
				case "extern":
					return TestIncrementalCompilationTokensSyntaxKind.KExtern;
				case "typedef":
					return TestIncrementalCompilationTokensSyntaxKind.KTypeDef;
				case "abstract":
					return TestIncrementalCompilationTokensSyntaxKind.KAbstract;
				case "class":
					return TestIncrementalCompilationTokensSyntaxKind.KClass;
				case "struct":
					return TestIncrementalCompilationTokensSyntaxKind.KStruct;
				case "enum":
					return TestIncrementalCompilationTokensSyntaxKind.KEnum;
				case "association":
					return TestIncrementalCompilationTokensSyntaxKind.KAssociation;
				case "containment":
					return TestIncrementalCompilationTokensSyntaxKind.KContainment;
				case "with":
					return TestIncrementalCompilationTokensSyntaxKind.KWith;
				case "new":
					return TestIncrementalCompilationTokensSyntaxKind.KNew;
				case "null":
					return TestIncrementalCompilationTokensSyntaxKind.KNull;
				case "true":
					return TestIncrementalCompilationTokensSyntaxKind.KTrue;
				case "false":
					return TestIncrementalCompilationTokensSyntaxKind.KFalse;
				case "void":
					return TestIncrementalCompilationTokensSyntaxKind.KVoid;
				case "object":
					return TestIncrementalCompilationTokensSyntaxKind.KObject;
				case "symbol":
					return TestIncrementalCompilationTokensSyntaxKind.KSymbol;
				case "string":
					return TestIncrementalCompilationTokensSyntaxKind.KString;
				case "int":
					return TestIncrementalCompilationTokensSyntaxKind.KInt;
				case "long":
					return TestIncrementalCompilationTokensSyntaxKind.KLong;
				case "float":
					return TestIncrementalCompilationTokensSyntaxKind.KFloat;
				case "double":
					return TestIncrementalCompilationTokensSyntaxKind.KDouble;
				case "byte":
					return TestIncrementalCompilationTokensSyntaxKind.KByte;
				case "bool":
					return TestIncrementalCompilationTokensSyntaxKind.KBool;
				case "list":
					return TestIncrementalCompilationTokensSyntaxKind.KList;
				case "any":
					return TestIncrementalCompilationTokensSyntaxKind.KAny;
				case "none":
					return TestIncrementalCompilationTokensSyntaxKind.KNone;
				case "error":
					return TestIncrementalCompilationTokensSyntaxKind.KError;
				case "set":
					return TestIncrementalCompilationTokensSyntaxKind.KSet;
				case "multi_list":
					return TestIncrementalCompilationTokensSyntaxKind.KMultiList;
				case "multi_set":
					return TestIncrementalCompilationTokensSyntaxKind.KMultiSet;
				case "this":
					return TestIncrementalCompilationTokensSyntaxKind.KThis;
				case "typeof":
					return TestIncrementalCompilationTokensSyntaxKind.KTypeof;
				case "as":
					return TestIncrementalCompilationTokensSyntaxKind.KAs;
				case "is":
					return TestIncrementalCompilationTokensSyntaxKind.KIs;
				case "base":
					return TestIncrementalCompilationTokensSyntaxKind.KBase;
				case "const":
					return TestIncrementalCompilationTokensSyntaxKind.KConst;
				case "redefines":
					return TestIncrementalCompilationTokensSyntaxKind.KRedefines;
				case "subsets":
					return TestIncrementalCompilationTokensSyntaxKind.KSubsets;
				case "readonly":
					return TestIncrementalCompilationTokensSyntaxKind.KReadonly;
				case "lazy":
					return TestIncrementalCompilationTokensSyntaxKind.KLazy;
				case "synthetized":
					return TestIncrementalCompilationTokensSyntaxKind.KSynthetized;
				case "inherited":
					return TestIncrementalCompilationTokensSyntaxKind.KInherited;
				case "derived":
					return TestIncrementalCompilationTokensSyntaxKind.KDerived;
				case "union":
					return TestIncrementalCompilationTokensSyntaxKind.KUnion;
				case "builder":
					return TestIncrementalCompilationTokensSyntaxKind.KBuilder;
				case "static":
					return TestIncrementalCompilationTokensSyntaxKind.KStatic;
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
				case TestIncrementalCompilationTokensSyntaxKind.IdentifierNormal:
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
				case TestIncrementalCompilationTokensSyntaxKind.LInteger:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LDecimal:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LScientific:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LDateTimeOffset:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LDateTime:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LDate:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LTime:
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
				case TestIncrementalCompilationTokensSyntaxKind.LRegularString:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LGuid:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LDoubleQuoteVerbatimString:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LSingleQuoteVerbatimString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestIncrementalCompilationTokensSyntaxKind.LUtf8Bom:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LWhiteSpace:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LCrLf:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case TestIncrementalCompilationTokensSyntaxKind.LSingleLineComment:
					return true;
				case TestIncrementalCompilationTokensSyntaxKind.LComment:
					return true;
				default:
					return false;
			}
		}
	}
}

