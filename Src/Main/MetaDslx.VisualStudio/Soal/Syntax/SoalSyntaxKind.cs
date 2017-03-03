// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;

namespace MetaDslx.VisualStudio.Soal.Syntax
{
	public enum SoalSyntaxKind : int
	{
        None                          = SyntaxKind.None,
        List                          = SyntaxKind.List,
        BadToken                      = SyntaxKind.BadToken,
        Eof                           = SyntaxKind.Eof,

		// Tokens:
		KNamespace = 1,
		KEnum = 2,
		KException = 3,
		KStruct = 4,
		KInterface = 5,
		KThrows = 6,
		KOneway = 7,
		KReturn = 8,
		KBinding = 9,
		KTransport = 10,
		KEncoding = 11,
		KProtocol = 12,
		KEndpoint = 13,
		KAddress = 14,
		KDatabase = 15,
		KEntity = 16,
		KAbstract = 17,
		KComponent = 18,
		KComposite = 19,
		KReference = 20,
		KService = 21,
		KWire = 22,
		KTo = 23,
		KImplementation = 24,
		KLanguage = 25,
		KAssembly = 26,
		KDeployment = 27,
		KEnvironment = 28,
		KRuntime = 29,
		KNull = 30,
		KTrue = 31,
		KFalse = 32,
		KObject = 33,
		KString = 34,
		KInt = 35,
		KLong = 36,
		KFloat = 37,
		KDouble = 38,
		KByte = 39,
		KBool = 40,
		KAny = 41,
		KTypeof = 42,
		KVoid = 43,
		TSemicolon = 44,
		TColon = 45,
		TDot = 46,
		TComma = 47,
		TAssign = 48,
		TOpenParen = 49,
		TCloseParen = 50,
		TOpenBracket = 51,
		TCloseBracket = 52,
		TOpenBrace = 53,
		TCloseBrace = 54,
		TLessThan = 55,
		TGreaterThan = 56,
		TQuestion = 57,
		TQuestionQuestion = 58,
		TAmpersand = 59,
		THat = 60,
		TBar = 61,
		TAndAlso = 62,
		TOrElse = 63,
		TPlusPlus = 64,
		TMinusMinus = 65,
		TPlus = 66,
		TMinus = 67,
		TTilde = 68,
		TExclamation = 69,
		TSlash = 70,
		TAsterisk = 71,
		TPercent = 72,
		TLessThanOrEqual = 73,
		TGreaterThanOrEqual = 74,
		TEqual = 75,
		TNotEqual = 76,
		TAsteriskAssign = 77,
		TSlashAssign = 78,
		TPercentAssign = 79,
		TPlusAssign = 80,
		TMinusAssign = 81,
		TLeftShiftAssign = 82,
		TRightShiftAssign = 83,
		TAmpersandAssign = 84,
		THatAssign = 85,
		TBarAssign = 86,
		IDate = 87,
		ITime = 88,
		IDateTime = 89,
		ITimeSpan = 90,
		IVersion = 91,
		IStyle = 92,
		IMTOM = 93,
		ISSL = 94,
		IHTTP = 95,
		IREST = 96,
		IWebSocket = 97,
		ISOAP = 98,
		IXML = 99,
		IJSON = 100,
		IClientAuthentication = 101,
		IWsAddressing = 102,
		IdentifierNormal = 103,
		IdentifierVerbatim = 104,
		LInteger = 105,
		LDecimal = 106,
		LScientific = 107,
		LDateTimeOffset = 108,
		LDateTime = 109,
		LDate = 110,
		LTime = 111,
		LRegularString = 112,
		LGuid = 113,
		LUtf8Bom = 114,
		LWhiteSpace = 115,
		LCrLf = 116,
		LLineEnd = 117,
		LSingleLineComment = 118,
		COMMENT = 119,
		LDoubleQuoteVerbatimString = 120,
		LSingleQuoteVerbatimString = 121,
		DoubleQuoteVerbatimStringLiteralStart = 122,
		SingleQuoteVerbatimStringLiteralStart = 123,
		LastTokenSyntaxKind = 123,

		// Rules:
	}
}

