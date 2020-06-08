// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace PilV2.Syntax
{
	public enum PilTokenKind : int
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

	public enum PilLexerMode : int
	{
		None = 0,
		DEFAULT_MODE = 0
	}

	public class PilTokensSyntaxFacts : SyntaxFacts
	{
        public PilTokensSyntaxFacts() 
            : base(typeof(PilTokensSyntaxKind))
        {
        }

        protected PilTokensSyntaxFacts(Type syntaxKindType) 
            : base(syntaxKindType)
        {
        }

        public override SyntaxKind DefaultWhitespaceKind => (PilTokensSyntaxKind)PilTokensSyntaxKind.LWhiteSpace;
        public override SyntaxKind DefaultEndOfLineKind => (PilTokensSyntaxKind)PilTokensSyntaxKind.LCrLf;
        public override SyntaxKind DefaultSeparatorKind => (PilTokensSyntaxKind)PilTokensSyntaxKind.TComma;
        public override SyntaxKind DefaultIdentifierKind => (PilTokensSyntaxKind)PilTokensSyntaxKind.LIdentifier;

		public override bool IsToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case PilTokensSyntaxKind.Eof:
				case PilTokensSyntaxKind.KTypeDef:
				case PilTokensSyntaxKind.KEnum:
				case PilTokensSyntaxKind.KFunction:
				case PilTokensSyntaxKind.KEndFunction:
				case PilTokensSyntaxKind.KResult:
				case PilTokensSyntaxKind.KFork:
				case PilTokensSyntaxKind.KEndFork:
				case PilTokensSyntaxKind.KCase:
				case PilTokensSyntaxKind.KElse:
				case PilTokensSyntaxKind.KIf:
				case PilTokensSyntaxKind.KEndIf:
				case PilTokensSyntaxKind.KQuery:
				case PilTokensSyntaxKind.KEndQuery:
				case PilTokensSyntaxKind.KPulse:
				case PilTokensSyntaxKind.KStatic:
				case PilTokensSyntaxKind.KObject:
				case PilTokensSyntaxKind.KEndObject:
				case PilTokensSyntaxKind.KTrigger:
				case PilTokensSyntaxKind.KInput:
				case PilTokensSyntaxKind.KOnAccepted:
				case PilTokensSyntaxKind.KOnRefused:
				case PilTokensSyntaxKind.KOnCancel:
				case PilTokensSyntaxKind.KAssert:
				case PilTokensSyntaxKind.KRequest:
				case PilTokensSyntaxKind.KAccept:
				case PilTokensSyntaxKind.KRefuse:
				case PilTokensSyntaxKind.KCancel:
				case PilTokensSyntaxKind.KVar:
				case PilTokensSyntaxKind.KParam:
				case PilTokensSyntaxKind.KUndo:
				case PilTokensSyntaxKind.KTrue:
				case PilTokensSyntaxKind.KFalse:
				case PilTokensSyntaxKind.KInt:
				case PilTokensSyntaxKind.KBool:
				case PilTokensSyntaxKind.KString:
				case PilTokensSyntaxKind.KObjectType:
				case PilTokensSyntaxKind.KIn:
				case PilTokensSyntaxKind.KNull:
				case PilTokensSyntaxKind.TSemicolon:
				case PilTokensSyntaxKind.TColon:
				case PilTokensSyntaxKind.TDot:
				case PilTokensSyntaxKind.TComma:
				case PilTokensSyntaxKind.TAssign:
				case PilTokensSyntaxKind.TOpenParen:
				case PilTokensSyntaxKind.TCloseParen:
				case PilTokensSyntaxKind.TOpenBracket:
				case PilTokensSyntaxKind.TCloseBracket:
				case PilTokensSyntaxKind.TOpenBrace:
				case PilTokensSyntaxKind.TCloseBrace:
				case PilTokensSyntaxKind.TLessThan:
				case PilTokensSyntaxKind.TGreaterThan:
				case PilTokensSyntaxKind.TQuestion:
				case PilTokensSyntaxKind.TQuestionQuestion:
				case PilTokensSyntaxKind.TAmpersand:
				case PilTokensSyntaxKind.THat:
				case PilTokensSyntaxKind.TBar:
				case PilTokensSyntaxKind.TAndAlso:
				case PilTokensSyntaxKind.TOrElse:
				case PilTokensSyntaxKind.TPlusPlus:
				case PilTokensSyntaxKind.TMinusMinus:
				case PilTokensSyntaxKind.TPlus:
				case PilTokensSyntaxKind.TMinus:
				case PilTokensSyntaxKind.TTilde:
				case PilTokensSyntaxKind.TExclamation:
				case PilTokensSyntaxKind.TSlash:
				case PilTokensSyntaxKind.TAsterisk:
				case PilTokensSyntaxKind.TPercent:
				case PilTokensSyntaxKind.TLessThanOrEqual:
				case PilTokensSyntaxKind.TGreaterThanOrEqual:
				case PilTokensSyntaxKind.TEqual:
				case PilTokensSyntaxKind.TNotEqual:
				case PilTokensSyntaxKind.TAsteriskAssign:
				case PilTokensSyntaxKind.TSlashAssign:
				case PilTokensSyntaxKind.TPercentAssign:
				case PilTokensSyntaxKind.TPlusAssign:
				case PilTokensSyntaxKind.TMinusAssign:
				case PilTokensSyntaxKind.TLeftShiftAssign:
				case PilTokensSyntaxKind.TRightShiftAssign:
				case PilTokensSyntaxKind.TAmpersandAssign:
				case PilTokensSyntaxKind.THatAssign:
				case PilTokensSyntaxKind.TBarAssign:
				case PilTokensSyntaxKind.LIdentifier:
				case PilTokensSyntaxKind.LInteger:
				case PilTokensSyntaxKind.LDecimal:
				case PilTokensSyntaxKind.LScientific:
				case PilTokensSyntaxKind.LString:
				case PilTokensSyntaxKind.LUtf8Bom:
				case PilTokensSyntaxKind.LWhiteSpace:
				case PilTokensSyntaxKind.LCrLf:
				case PilTokensSyntaxKind.LLineEnd:
				case PilTokensSyntaxKind.LSingleLineComment:
				case PilTokensSyntaxKind.LMultiLineComment:
					return true;
				default:
					return false;
			}
		}

		public override bool IsFixedToken(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case PilTokensSyntaxKind.KTypeDef:
				case PilTokensSyntaxKind.KEnum:
				case PilTokensSyntaxKind.KFunction:
				case PilTokensSyntaxKind.KEndFunction:
				case PilTokensSyntaxKind.KResult:
				case PilTokensSyntaxKind.KFork:
				case PilTokensSyntaxKind.KEndFork:
				case PilTokensSyntaxKind.KCase:
				case PilTokensSyntaxKind.KElse:
				case PilTokensSyntaxKind.KIf:
				case PilTokensSyntaxKind.KEndIf:
				case PilTokensSyntaxKind.KQuery:
				case PilTokensSyntaxKind.KEndQuery:
				case PilTokensSyntaxKind.KPulse:
				case PilTokensSyntaxKind.KStatic:
				case PilTokensSyntaxKind.KObject:
				case PilTokensSyntaxKind.KEndObject:
				case PilTokensSyntaxKind.KTrigger:
				case PilTokensSyntaxKind.KInput:
				case PilTokensSyntaxKind.KOnAccepted:
				case PilTokensSyntaxKind.KOnRefused:
				case PilTokensSyntaxKind.KOnCancel:
				case PilTokensSyntaxKind.KAssert:
				case PilTokensSyntaxKind.KRequest:
				case PilTokensSyntaxKind.KAccept:
				case PilTokensSyntaxKind.KRefuse:
				case PilTokensSyntaxKind.KCancel:
				case PilTokensSyntaxKind.KVar:
				case PilTokensSyntaxKind.KParam:
				case PilTokensSyntaxKind.KUndo:
				case PilTokensSyntaxKind.KTrue:
				case PilTokensSyntaxKind.KFalse:
				case PilTokensSyntaxKind.KInt:
				case PilTokensSyntaxKind.KBool:
				case PilTokensSyntaxKind.KString:
				case PilTokensSyntaxKind.KObjectType:
				case PilTokensSyntaxKind.KIn:
				case PilTokensSyntaxKind.KNull:
				case PilTokensSyntaxKind.TSemicolon:
				case PilTokensSyntaxKind.TColon:
				case PilTokensSyntaxKind.TDot:
				case PilTokensSyntaxKind.TComma:
				case PilTokensSyntaxKind.TAssign:
				case PilTokensSyntaxKind.TOpenParen:
				case PilTokensSyntaxKind.TCloseParen:
				case PilTokensSyntaxKind.TOpenBracket:
				case PilTokensSyntaxKind.TCloseBracket:
				case PilTokensSyntaxKind.TOpenBrace:
				case PilTokensSyntaxKind.TCloseBrace:
				case PilTokensSyntaxKind.TLessThan:
				case PilTokensSyntaxKind.TGreaterThan:
				case PilTokensSyntaxKind.TQuestion:
				case PilTokensSyntaxKind.TQuestionQuestion:
				case PilTokensSyntaxKind.TAmpersand:
				case PilTokensSyntaxKind.THat:
				case PilTokensSyntaxKind.TBar:
				case PilTokensSyntaxKind.TAndAlso:
				case PilTokensSyntaxKind.TOrElse:
				case PilTokensSyntaxKind.TPlusPlus:
				case PilTokensSyntaxKind.TMinusMinus:
				case PilTokensSyntaxKind.TPlus:
				case PilTokensSyntaxKind.TMinus:
				case PilTokensSyntaxKind.TTilde:
				case PilTokensSyntaxKind.TExclamation:
				case PilTokensSyntaxKind.TSlash:
				case PilTokensSyntaxKind.TAsterisk:
				case PilTokensSyntaxKind.TPercent:
				case PilTokensSyntaxKind.TLessThanOrEqual:
				case PilTokensSyntaxKind.TGreaterThanOrEqual:
				case PilTokensSyntaxKind.TEqual:
				case PilTokensSyntaxKind.TNotEqual:
				case PilTokensSyntaxKind.TAsteriskAssign:
				case PilTokensSyntaxKind.TSlashAssign:
				case PilTokensSyntaxKind.TPercentAssign:
				case PilTokensSyntaxKind.TPlusAssign:
				case PilTokensSyntaxKind.TMinusAssign:
				case PilTokensSyntaxKind.TLeftShiftAssign:
				case PilTokensSyntaxKind.TRightShiftAssign:
				case PilTokensSyntaxKind.TAmpersandAssign:
				case PilTokensSyntaxKind.THatAssign:
				case PilTokensSyntaxKind.TBarAssign:
					return true;
				default:
					return false;
			}
		}

		public override SyntaxKind GetFixedTokenKind(string text)
		{
			switch (text)
			{
				case "TYPE":
					return PilTokensSyntaxKind.KTypeDef;
				case "ENUM":
					return PilTokensSyntaxKind.KEnum;
				case "FUNCTION":
					return PilTokensSyntaxKind.KFunction;
				case "EFUNCTION":
					return PilTokensSyntaxKind.KEndFunction;
				case "RESULT":
					return PilTokensSyntaxKind.KResult;
				case "FORK":
					return PilTokensSyntaxKind.KFork;
				case "EFORK":
					return PilTokensSyntaxKind.KEndFork;
				case "CASE":
					return PilTokensSyntaxKind.KCase;
				case "ELSE":
					return PilTokensSyntaxKind.KElse;
				case "IF":
					return PilTokensSyntaxKind.KIf;
				case "EIF":
					return PilTokensSyntaxKind.KEndIf;
				case "QUERY":
					return PilTokensSyntaxKind.KQuery;
				case "EQUERY":
					return PilTokensSyntaxKind.KEndQuery;
				case "PULSE":
					return PilTokensSyntaxKind.KPulse;
				case "STATIC":
					return PilTokensSyntaxKind.KStatic;
				case "OBJECT":
					return PilTokensSyntaxKind.KObject;
				case "EOBJECT":
					return PilTokensSyntaxKind.KEndObject;
				case "TRIGGER":
					return PilTokensSyntaxKind.KTrigger;
				case "INPUT":
					return PilTokensSyntaxKind.KInput;
				case "ON_ACCEPTED":
					return PilTokensSyntaxKind.KOnAccepted;
				case "ON_REFUSED":
					return PilTokensSyntaxKind.KOnRefused;
				case "ON_CANCELLED":
					return PilTokensSyntaxKind.KOnCancel;
				case "ASSERT":
					return PilTokensSyntaxKind.KAssert;
				case "REQ":
					return PilTokensSyntaxKind.KRequest;
				case "ACCEPT":
					return PilTokensSyntaxKind.KAccept;
				case "REFUSE":
					return PilTokensSyntaxKind.KRefuse;
				case "CANCEL":
					return PilTokensSyntaxKind.KCancel;
				case "VAR":
					return PilTokensSyntaxKind.KVar;
				case "PARAM":
					return PilTokensSyntaxKind.KParam;
				case "UNDO":
					return PilTokensSyntaxKind.KUndo;
				case "TRUE":
					return PilTokensSyntaxKind.KTrue;
				case "FALSE":
					return PilTokensSyntaxKind.KFalse;
				case "int":
					return PilTokensSyntaxKind.KInt;
				case "bool":
					return PilTokensSyntaxKind.KBool;
				case "string":
					return PilTokensSyntaxKind.KString;
				case "object":
					return PilTokensSyntaxKind.KObjectType;
				case "in":
					return PilTokensSyntaxKind.KIn;
				case "NULL":
					return PilTokensSyntaxKind.KNull;
				case ";":
					return PilTokensSyntaxKind.TSemicolon;
				case ":":
					return PilTokensSyntaxKind.TColon;
				case ".":
					return PilTokensSyntaxKind.TDot;
				case ",":
					return PilTokensSyntaxKind.TComma;
				case ":=":
					return PilTokensSyntaxKind.TAssign;
				case "(":
					return PilTokensSyntaxKind.TOpenParen;
				case ")":
					return PilTokensSyntaxKind.TCloseParen;
				case "[":
					return PilTokensSyntaxKind.TOpenBracket;
				case "]":
					return PilTokensSyntaxKind.TCloseBracket;
				case "{":
					return PilTokensSyntaxKind.TOpenBrace;
				case "}":
					return PilTokensSyntaxKind.TCloseBrace;
				case "<":
					return PilTokensSyntaxKind.TLessThan;
				case ">":
					return PilTokensSyntaxKind.TGreaterThan;
				case "?":
					return PilTokensSyntaxKind.TQuestion;
				case "??":
					return PilTokensSyntaxKind.TQuestionQuestion;
				case "&":
					return PilTokensSyntaxKind.TAmpersand;
				case "^":
					return PilTokensSyntaxKind.THat;
				case "|":
					return PilTokensSyntaxKind.TBar;
				case "&&":
					return PilTokensSyntaxKind.TAndAlso;
				case "||":
					return PilTokensSyntaxKind.TOrElse;
				case "++":
					return PilTokensSyntaxKind.TPlusPlus;
				case "--":
					return PilTokensSyntaxKind.TMinusMinus;
				case "+":
					return PilTokensSyntaxKind.TPlus;
				case "-":
					return PilTokensSyntaxKind.TMinus;
				case "~":
					return PilTokensSyntaxKind.TTilde;
				case "!":
					return PilTokensSyntaxKind.TExclamation;
				case "/":
					return PilTokensSyntaxKind.TSlash;
				case "*":
					return PilTokensSyntaxKind.TAsterisk;
				case "%":
					return PilTokensSyntaxKind.TPercent;
				case "<=":
					return PilTokensSyntaxKind.TLessThanOrEqual;
				case ">=":
					return PilTokensSyntaxKind.TGreaterThanOrEqual;
				case "=":
					return PilTokensSyntaxKind.TEqual;
				case "!=":
					return PilTokensSyntaxKind.TNotEqual;
				case "*=":
					return PilTokensSyntaxKind.TAsteriskAssign;
				case "/=":
					return PilTokensSyntaxKind.TSlashAssign;
				case "%=":
					return PilTokensSyntaxKind.TPercentAssign;
				case "+=":
					return PilTokensSyntaxKind.TPlusAssign;
				case "-=":
					return PilTokensSyntaxKind.TMinusAssign;
				case "<<=":
					return PilTokensSyntaxKind.TLeftShiftAssign;
				case ">>=":
					return PilTokensSyntaxKind.TRightShiftAssign;
				case "&=":
					return PilTokensSyntaxKind.TAmpersandAssign;
				case "^=":
					return PilTokensSyntaxKind.THatAssign;
				case "|=":
					return PilTokensSyntaxKind.TBarAssign;
				default:
					return PilTokensSyntaxKind.None;
			}
		}

		public override string GetText(SyntaxKind kind)
		{
			switch (kind.Switch())
			{
				case PilTokensSyntaxKind.KTypeDef:
					return "TYPE";
				case PilTokensSyntaxKind.KEnum:
					return "ENUM";
				case PilTokensSyntaxKind.KFunction:
					return "FUNCTION";
				case PilTokensSyntaxKind.KEndFunction:
					return "EFUNCTION";
				case PilTokensSyntaxKind.KResult:
					return "RESULT";
				case PilTokensSyntaxKind.KFork:
					return "FORK";
				case PilTokensSyntaxKind.KEndFork:
					return "EFORK";
				case PilTokensSyntaxKind.KCase:
					return "CASE";
				case PilTokensSyntaxKind.KElse:
					return "ELSE";
				case PilTokensSyntaxKind.KIf:
					return "IF";
				case PilTokensSyntaxKind.KEndIf:
					return "EIF";
				case PilTokensSyntaxKind.KQuery:
					return "QUERY";
				case PilTokensSyntaxKind.KEndQuery:
					return "EQUERY";
				case PilTokensSyntaxKind.KPulse:
					return "PULSE";
				case PilTokensSyntaxKind.KStatic:
					return "STATIC";
				case PilTokensSyntaxKind.KObject:
					return "OBJECT";
				case PilTokensSyntaxKind.KEndObject:
					return "EOBJECT";
				case PilTokensSyntaxKind.KTrigger:
					return "TRIGGER";
				case PilTokensSyntaxKind.KInput:
					return "INPUT";
				case PilTokensSyntaxKind.KOnAccepted:
					return "ON_ACCEPTED";
				case PilTokensSyntaxKind.KOnRefused:
					return "ON_REFUSED";
				case PilTokensSyntaxKind.KOnCancel:
					return "ON_CANCELLED";
				case PilTokensSyntaxKind.KAssert:
					return "ASSERT";
				case PilTokensSyntaxKind.KRequest:
					return "REQ";
				case PilTokensSyntaxKind.KAccept:
					return "ACCEPT";
				case PilTokensSyntaxKind.KRefuse:
					return "REFUSE";
				case PilTokensSyntaxKind.KCancel:
					return "CANCEL";
				case PilTokensSyntaxKind.KVar:
					return "VAR";
				case PilTokensSyntaxKind.KParam:
					return "PARAM";
				case PilTokensSyntaxKind.KUndo:
					return "UNDO";
				case PilTokensSyntaxKind.KTrue:
					return "TRUE";
				case PilTokensSyntaxKind.KFalse:
					return "FALSE";
				case PilTokensSyntaxKind.KInt:
					return "int";
				case PilTokensSyntaxKind.KBool:
					return "bool";
				case PilTokensSyntaxKind.KString:
					return "string";
				case PilTokensSyntaxKind.KObjectType:
					return "object";
				case PilTokensSyntaxKind.KIn:
					return "in";
				case PilTokensSyntaxKind.KNull:
					return "NULL";
				case PilTokensSyntaxKind.TSemicolon:
					return ";";
				case PilTokensSyntaxKind.TColon:
					return ":";
				case PilTokensSyntaxKind.TDot:
					return ".";
				case PilTokensSyntaxKind.TComma:
					return ",";
				case PilTokensSyntaxKind.TAssign:
					return ":=";
				case PilTokensSyntaxKind.TOpenParen:
					return "(";
				case PilTokensSyntaxKind.TCloseParen:
					return ")";
				case PilTokensSyntaxKind.TOpenBracket:
					return "[";
				case PilTokensSyntaxKind.TCloseBracket:
					return "]";
				case PilTokensSyntaxKind.TOpenBrace:
					return "{";
				case PilTokensSyntaxKind.TCloseBrace:
					return "}";
				case PilTokensSyntaxKind.TLessThan:
					return "<";
				case PilTokensSyntaxKind.TGreaterThan:
					return ">";
				case PilTokensSyntaxKind.TQuestion:
					return "?";
				case PilTokensSyntaxKind.TQuestionQuestion:
					return "??";
				case PilTokensSyntaxKind.TAmpersand:
					return "&";
				case PilTokensSyntaxKind.THat:
					return "^";
				case PilTokensSyntaxKind.TBar:
					return "|";
				case PilTokensSyntaxKind.TAndAlso:
					return "&&";
				case PilTokensSyntaxKind.TOrElse:
					return "||";
				case PilTokensSyntaxKind.TPlusPlus:
					return "++";
				case PilTokensSyntaxKind.TMinusMinus:
					return "--";
				case PilTokensSyntaxKind.TPlus:
					return "+";
				case PilTokensSyntaxKind.TMinus:
					return "-";
				case PilTokensSyntaxKind.TTilde:
					return "~";
				case PilTokensSyntaxKind.TExclamation:
					return "!";
				case PilTokensSyntaxKind.TSlash:
					return "/";
				case PilTokensSyntaxKind.TAsterisk:
					return "*";
				case PilTokensSyntaxKind.TPercent:
					return "%";
				case PilTokensSyntaxKind.TLessThanOrEqual:
					return "<=";
				case PilTokensSyntaxKind.TGreaterThanOrEqual:
					return ">=";
				case PilTokensSyntaxKind.TEqual:
					return "=";
				case PilTokensSyntaxKind.TNotEqual:
					return "!=";
				case PilTokensSyntaxKind.TAsteriskAssign:
					return "*=";
				case PilTokensSyntaxKind.TSlashAssign:
					return "/=";
				case PilTokensSyntaxKind.TPercentAssign:
					return "%=";
				case PilTokensSyntaxKind.TPlusAssign:
					return "+=";
				case PilTokensSyntaxKind.TMinusAssign:
					return "-=";
				case PilTokensSyntaxKind.TLeftShiftAssign:
					return "<<=";
				case PilTokensSyntaxKind.TRightShiftAssign:
					return ">>=";
				case PilTokensSyntaxKind.TAmpersandAssign:
					return "&=";
				case PilTokensSyntaxKind.THatAssign:
					return "^=";
				case PilTokensSyntaxKind.TBarAssign:
					return "|=";
				default:
					return string.Empty;
			}
		}

		public PilTokenKind GetTokenKind(int rawKind)
		{
			return this.GetTokenKind(EnumObject.FromIntUnsafe<PilTokensSyntaxKind>(rawKind));
		}

		public PilTokenKind GetTokenKind(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case PilTokensSyntaxKind.KTypeDef:
				case PilTokensSyntaxKind.KEnum:
				case PilTokensSyntaxKind.KFunction:
				case PilTokensSyntaxKind.KEndFunction:
				case PilTokensSyntaxKind.KResult:
				case PilTokensSyntaxKind.KFork:
				case PilTokensSyntaxKind.KEndFork:
				case PilTokensSyntaxKind.KCase:
				case PilTokensSyntaxKind.KElse:
				case PilTokensSyntaxKind.KIf:
				case PilTokensSyntaxKind.KEndIf:
				case PilTokensSyntaxKind.KQuery:
				case PilTokensSyntaxKind.KEndQuery:
				case PilTokensSyntaxKind.KPulse:
				case PilTokensSyntaxKind.KStatic:
				case PilTokensSyntaxKind.KObject:
				case PilTokensSyntaxKind.KEndObject:
				case PilTokensSyntaxKind.KTrigger:
				case PilTokensSyntaxKind.KInput:
				case PilTokensSyntaxKind.KOnAccepted:
				case PilTokensSyntaxKind.KOnRefused:
				case PilTokensSyntaxKind.KOnCancel:
				case PilTokensSyntaxKind.KAssert:
				case PilTokensSyntaxKind.KRequest:
				case PilTokensSyntaxKind.KAccept:
				case PilTokensSyntaxKind.KRefuse:
				case PilTokensSyntaxKind.KCancel:
				case PilTokensSyntaxKind.KVar:
				case PilTokensSyntaxKind.KParam:
				case PilTokensSyntaxKind.KUndo:
				case PilTokensSyntaxKind.KTrue:
				case PilTokensSyntaxKind.KFalse:
				case PilTokensSyntaxKind.KInt:
				case PilTokensSyntaxKind.KBool:
				case PilTokensSyntaxKind.KString:
				case PilTokensSyntaxKind.KObjectType:
				case PilTokensSyntaxKind.KIn:
				case PilTokensSyntaxKind.KNull:
					return PilTokenKind.ReservedKeyword;
				case PilTokensSyntaxKind.LIdentifier:
					return PilTokenKind.Identifier;
				case PilTokensSyntaxKind.LInteger:
					return PilTokenKind.Number;
				case PilTokensSyntaxKind.LDecimal:
					return PilTokenKind.Number;
				case PilTokensSyntaxKind.LScientific:
					return PilTokenKind.Number;
				case PilTokensSyntaxKind.LString:
					return PilTokenKind.String;
				case PilTokensSyntaxKind.LUtf8Bom:
					return PilTokenKind.Whitespace;
				case PilTokensSyntaxKind.LWhiteSpace:
					return PilTokenKind.Whitespace;
				case PilTokensSyntaxKind.LCrLf:
					return PilTokenKind.Whitespace;
				case PilTokensSyntaxKind.LLineEnd:
					return PilTokenKind.Whitespace;
				case PilTokensSyntaxKind.LSingleLineComment:
					return PilTokenKind.GeneralComment;
				default:
					return PilTokenKind.None;
			}
		}

		public PilTokenKind GetModeTokenKind(int rawKind)
		{
			return this.GetModeTokenKind((PilLexerMode)rawKind);
		}

		public PilTokenKind GetModeTokenKind(PilLexerMode kind)
		{
			switch(kind)
			{
				default:
					return PilTokenKind.None;
			}
		}

		public override bool IsTriviaWithEndOfLine(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case PilTokensSyntaxKind.LCrLf:
					return true;
				case PilTokensSyntaxKind.LLineEnd:
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
				case PilTokensSyntaxKind.KTypeDef:
				case PilTokensSyntaxKind.KEnum:
				case PilTokensSyntaxKind.KFunction:
				case PilTokensSyntaxKind.KEndFunction:
				case PilTokensSyntaxKind.KResult:
				case PilTokensSyntaxKind.KFork:
				case PilTokensSyntaxKind.KEndFork:
				case PilTokensSyntaxKind.KCase:
				case PilTokensSyntaxKind.KElse:
				case PilTokensSyntaxKind.KIf:
				case PilTokensSyntaxKind.KEndIf:
				case PilTokensSyntaxKind.KQuery:
				case PilTokensSyntaxKind.KEndQuery:
				case PilTokensSyntaxKind.KPulse:
				case PilTokensSyntaxKind.KStatic:
				case PilTokensSyntaxKind.KObject:
				case PilTokensSyntaxKind.KEndObject:
				case PilTokensSyntaxKind.KTrigger:
				case PilTokensSyntaxKind.KInput:
				case PilTokensSyntaxKind.KOnAccepted:
				case PilTokensSyntaxKind.KOnRefused:
				case PilTokensSyntaxKind.KOnCancel:
				case PilTokensSyntaxKind.KAssert:
				case PilTokensSyntaxKind.KRequest:
				case PilTokensSyntaxKind.KAccept:
				case PilTokensSyntaxKind.KRefuse:
				case PilTokensSyntaxKind.KCancel:
				case PilTokensSyntaxKind.KVar:
				case PilTokensSyntaxKind.KParam:
				case PilTokensSyntaxKind.KUndo:
				case PilTokensSyntaxKind.KTrue:
				case PilTokensSyntaxKind.KFalse:
				case PilTokensSyntaxKind.KInt:
				case PilTokensSyntaxKind.KBool:
				case PilTokensSyntaxKind.KString:
				case PilTokensSyntaxKind.KObjectType:
				case PilTokensSyntaxKind.KIn:
				case PilTokensSyntaxKind.KNull:
					return true;
				default:
					return false;
			}
		}

        public override IEnumerable<SyntaxKind> GetReservedKeywordKinds()
        {
				yield return PilTokensSyntaxKind.KTypeDef;
				yield return PilTokensSyntaxKind.KEnum;
				yield return PilTokensSyntaxKind.KFunction;
				yield return PilTokensSyntaxKind.KEndFunction;
				yield return PilTokensSyntaxKind.KResult;
				yield return PilTokensSyntaxKind.KFork;
				yield return PilTokensSyntaxKind.KEndFork;
				yield return PilTokensSyntaxKind.KCase;
				yield return PilTokensSyntaxKind.KElse;
				yield return PilTokensSyntaxKind.KIf;
				yield return PilTokensSyntaxKind.KEndIf;
				yield return PilTokensSyntaxKind.KQuery;
				yield return PilTokensSyntaxKind.KEndQuery;
				yield return PilTokensSyntaxKind.KPulse;
				yield return PilTokensSyntaxKind.KStatic;
				yield return PilTokensSyntaxKind.KObject;
				yield return PilTokensSyntaxKind.KEndObject;
				yield return PilTokensSyntaxKind.KTrigger;
				yield return PilTokensSyntaxKind.KInput;
				yield return PilTokensSyntaxKind.KOnAccepted;
				yield return PilTokensSyntaxKind.KOnRefused;
				yield return PilTokensSyntaxKind.KOnCancel;
				yield return PilTokensSyntaxKind.KAssert;
				yield return PilTokensSyntaxKind.KRequest;
				yield return PilTokensSyntaxKind.KAccept;
				yield return PilTokensSyntaxKind.KRefuse;
				yield return PilTokensSyntaxKind.KCancel;
				yield return PilTokensSyntaxKind.KVar;
				yield return PilTokensSyntaxKind.KParam;
				yield return PilTokensSyntaxKind.KUndo;
				yield return PilTokensSyntaxKind.KTrue;
				yield return PilTokensSyntaxKind.KFalse;
				yield return PilTokensSyntaxKind.KInt;
				yield return PilTokensSyntaxKind.KBool;
				yield return PilTokensSyntaxKind.KString;
				yield return PilTokensSyntaxKind.KObjectType;
				yield return PilTokensSyntaxKind.KIn;
				yield return PilTokensSyntaxKind.KNull;
        }

        public override SyntaxKind GetReservedKeywordKind(string text)
        {
			switch(text)
			{
				case "TYPE":
					return PilTokensSyntaxKind.KTypeDef;
				case "ENUM":
					return PilTokensSyntaxKind.KEnum;
				case "FUNCTION":
					return PilTokensSyntaxKind.KFunction;
				case "EFUNCTION":
					return PilTokensSyntaxKind.KEndFunction;
				case "RESULT":
					return PilTokensSyntaxKind.KResult;
				case "FORK":
					return PilTokensSyntaxKind.KFork;
				case "EFORK":
					return PilTokensSyntaxKind.KEndFork;
				case "CASE":
					return PilTokensSyntaxKind.KCase;
				case "ELSE":
					return PilTokensSyntaxKind.KElse;
				case "IF":
					return PilTokensSyntaxKind.KIf;
				case "EIF":
					return PilTokensSyntaxKind.KEndIf;
				case "QUERY":
					return PilTokensSyntaxKind.KQuery;
				case "EQUERY":
					return PilTokensSyntaxKind.KEndQuery;
				case "PULSE":
					return PilTokensSyntaxKind.KPulse;
				case "STATIC":
					return PilTokensSyntaxKind.KStatic;
				case "OBJECT":
					return PilTokensSyntaxKind.KObject;
				case "EOBJECT":
					return PilTokensSyntaxKind.KEndObject;
				case "TRIGGER":
					return PilTokensSyntaxKind.KTrigger;
				case "INPUT":
					return PilTokensSyntaxKind.KInput;
				case "ON_ACCEPTED":
					return PilTokensSyntaxKind.KOnAccepted;
				case "ON_REFUSED":
					return PilTokensSyntaxKind.KOnRefused;
				case "ON_CANCELLED":
					return PilTokensSyntaxKind.KOnCancel;
				case "ASSERT":
					return PilTokensSyntaxKind.KAssert;
				case "REQ":
					return PilTokensSyntaxKind.KRequest;
				case "ACCEPT":
					return PilTokensSyntaxKind.KAccept;
				case "REFUSE":
					return PilTokensSyntaxKind.KRefuse;
				case "CANCEL":
					return PilTokensSyntaxKind.KCancel;
				case "VAR":
					return PilTokensSyntaxKind.KVar;
				case "PARAM":
					return PilTokensSyntaxKind.KParam;
				case "UNDO":
					return PilTokensSyntaxKind.KUndo;
				case "TRUE":
					return PilTokensSyntaxKind.KTrue;
				case "FALSE":
					return PilTokensSyntaxKind.KFalse;
				case "int":
					return PilTokensSyntaxKind.KInt;
				case "bool":
					return PilTokensSyntaxKind.KBool;
				case "string":
					return PilTokensSyntaxKind.KString;
				case "object":
					return PilTokensSyntaxKind.KObjectType;
				case "in":
					return PilTokensSyntaxKind.KIn;
				case "NULL":
					return PilTokensSyntaxKind.KNull;
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
				case PilTokensSyntaxKind.LIdentifier:
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
				case PilTokensSyntaxKind.LInteger:
					return true;
				case PilTokensSyntaxKind.LDecimal:
					return true;
				case PilTokensSyntaxKind.LScientific:
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
				case PilTokensSyntaxKind.LString:
					return true;
				default:
					return false;
			}
		}
		public bool IsWhitespace(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case PilTokensSyntaxKind.LUtf8Bom:
					return true;
				case PilTokensSyntaxKind.LWhiteSpace:
					return true;
				case PilTokensSyntaxKind.LCrLf:
					return true;
				case PilTokensSyntaxKind.LLineEnd:
					return true;
				default:
					return false;
			}
		}
		public bool IsGeneralComment(SyntaxKind kind)
		{
			switch(kind.Switch())
			{
				case PilTokensSyntaxKind.LSingleLineComment:
					return true;
				default:
					return false;
			}
		}
	}
}

