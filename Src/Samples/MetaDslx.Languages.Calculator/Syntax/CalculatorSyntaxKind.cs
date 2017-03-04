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

namespace MetaDslx.Languages.Calculator.Syntax
{
	public enum CalculatorSyntaxKind : int
	{
        None                          = SyntaxKind.None,
        List                          = SyntaxKind.List,
        BadToken                      = SyntaxKind.BadToken,
        Eof                           = SyntaxKind.Eof,

		// Tokens:
		TSemicolon = 1,
		TOpenParen = 2,
		TCloseParen = 3,
		TComma = 4,
		TAssign = 5,
		TAdd = 6,
		TSub = 7,
		TMul = 8,
		TDiv = 9,
		KPrint = 10,
		LString = 11,
		LId = 12,
		LInt = 13,
		LUtf8Bom = 14,
		LWhitespace = 15,
		LEndl = 16,
		LComment = 17,
		LastTokenSyntaxKind = 17,

		// Rules:
		Main,
		StatementLine,
		Statement,
		Assignment,
		ParenExpression,
		MulOrDivExpression,
		AddOrSubExpression,
		PrintExpression,
		ValueExpression,
		Args,
		Value,
		Identifier,
		String,
		Integer,
		Arg,
	}
}

