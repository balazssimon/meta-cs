//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Balazs\source\repos\meta-cs\src\Main\MetaDslx.CodeAnalysis.Antlr4\Languages\Antlr4Roslyn\Syntax\InternalSyntax\LexBasic.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class LexBasic : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		DUMMY_TO_FIX_LEX_BASIC_GENERATION_ERROR=1;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"Ws", "Hws", "Vws", "BlockComment", "DocComment", "LineComment", "EscSeq", 
		"EscAny", "UnicodeEsc", "DecimalNumeral", "HexDigit", "DecDigit", "BoolLiteral", 
		"CharLiteral", "SQuoteLiteral", "DQuoteLiteral", "USQuoteLiteral", "NameChar", 
		"NameStartChar", "Int", "Esc", "Colon", "DColon", "SQuote", "DQuote", 
		"LParen", "RParen", "LBrace", "RBrace", "LBrack", "RBrack", "RArrow", 
		"Lt", "Gt", "Equal", "Question", "Star", "Plus", "PlusAssign", "Underscore", 
		"Pipe", "Dollar", "Comma", "Semi", "Dot", "Range", "At", "Pound", "Tilde"
	};


	public LexBasic(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public LexBasic(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
	};
	private static readonly string[] _SymbolicNames = {
		null, "DUMMY_TO_FIX_LEX_BASIC_GENERATION_ERROR"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "LexBasic.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static LexBasic() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x3', '\x130', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x4', ',', '\t', 
		',', '\x4', '-', '\t', '-', '\x4', '.', '\t', '.', '\x4', '/', '\t', '/', 
		'\x4', '\x30', '\t', '\x30', '\x4', '\x31', '\t', '\x31', '\x4', '\x32', 
		'\t', '\x32', '\x3', '\x2', '\x3', '\x2', '\x5', '\x2', 'h', '\n', '\x2', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\a', '\x5', 'r', '\n', '\x5', 
		'\f', '\x5', '\xE', '\x5', 'u', '\v', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x5', '\x5', 'z', '\n', '\x5', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\a', '\x6', '\x81', '\n', '\x6', 
		'\f', '\x6', '\xE', '\x6', '\x84', '\v', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x5', '\x6', '\x89', '\n', '\x6', '\x3', '\a', '\x3', '\a', 
		'\x3', '\a', '\x3', '\a', '\a', '\a', '\x8F', '\n', '\a', '\f', '\a', 
		'\xE', '\a', '\x92', '\v', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x3', '\b', '\x3', '\b', '\x5', '\b', '\x99', '\n', '\b', '\x3', '\t', 
		'\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x5', '\n', '\xA3', '\n', '\n', '\x5', '\n', '\xA5', 
		'\n', '\n', '\x5', '\n', '\xA7', '\n', '\n', '\x5', '\n', '\xA9', '\n', 
		'\n', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\a', '\v', '\xAE', '\n', 
		'\v', '\f', '\v', '\xE', '\v', '\xB1', '\v', '\v', '\x5', '\v', '\xB3', 
		'\n', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x5', '\xE', '\xC2', 
		'\n', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x5', '\xF', '\xC7', 
		'\n', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x10', '\a', '\x10', '\xCE', '\n', '\x10', '\f', '\x10', '\xE', 
		'\x10', '\xD1', '\v', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x11', '\a', '\x11', '\xD8', '\n', '\x11', '\f', 
		'\x11', '\xE', '\x11', '\xDB', '\v', '\x11', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\a', '\x12', '\xE2', '\n', 
		'\x12', '\f', '\x12', '\xE', '\x12', '\xE5', '\v', '\x12', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x5', '\x13', '\xEB', '\n', 
		'\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', 
		'\x17', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x19', '\x3', 
		'\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1E', '\x3', 
		'\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', '!', 
		'\x3', '!', '\x3', '!', '\x3', '\"', '\x3', '\"', '\x3', '#', '\x3', '#', 
		'\x3', '$', '\x3', '$', '\x3', '%', '\x3', '%', '\x3', '&', '\x3', '&', 
		'\x3', '\'', '\x3', '\'', '\x3', '(', '\x3', '(', '\x3', '(', '\x3', ')', 
		'\x3', ')', '\x3', '*', '\x3', '*', '\x3', '+', '\x3', '+', '\x3', ',', 
		'\x3', ',', '\x3', '-', '\x3', '-', '\x3', '.', '\x3', '.', '\x3', '/', 
		'\x3', '/', '\x3', '/', '\x3', '\x30', '\x3', '\x30', '\x3', '\x31', '\x3', 
		'\x31', '\x3', '\x32', '\x3', '\x32', '\x4', 's', '\x82', '\x2', '\x33', 
		'\x3', '\x2', '\x5', '\x2', '\a', '\x2', '\t', '\x2', '\v', '\x2', '\r', 
		'\x2', '\xF', '\x2', '\x11', '\x2', '\x13', '\x2', '\x15', '\x2', '\x17', 
		'\x2', '\x19', '\x2', '\x1B', '\x2', '\x1D', '\x2', '\x1F', '\x2', '!', 
		'\x2', '#', '\x2', '%', '\x2', '\'', '\x2', ')', '\x2', '+', '\x2', '-', 
		'\x2', '/', '\x2', '\x31', '\x2', '\x33', '\x2', '\x35', '\x2', '\x37', 
		'\x2', '\x39', '\x2', ';', '\x2', '=', '\x2', '?', '\x2', '\x41', '\x2', 
		'\x43', '\x2', '\x45', '\x2', 'G', '\x2', 'I', '\x2', 'K', '\x2', 'M', 
		'\x2', 'O', '\x2', 'Q', '\x2', 'S', '\x2', 'U', '\x2', 'W', '\x2', 'Y', 
		'\x2', '[', '\x2', ']', '\x2', '_', '\x2', '\x61', '\x2', '\x63', '\x2', 
		'\x3', '\x2', '\r', '\x4', '\x2', '\v', '\v', '\"', '\"', '\x4', '\x2', 
		'\f', '\f', '\xE', '\xF', '\x4', '\x2', '\f', '\f', '\xF', '\xF', '\n', 
		'\x2', '$', '$', ')', ')', '^', '^', '\x64', '\x64', 'h', 'h', 'p', 'p', 
		't', 't', 'v', 'v', '\x3', '\x2', '\x33', ';', '\x5', '\x2', '\x32', ';', 
		'\x43', 'H', '\x63', 'h', '\x3', '\x2', '\x32', ';', '\x6', '\x2', '\f', 
		'\f', '\xF', '\xF', ')', ')', '^', '^', '\x6', '\x2', '\f', '\f', '\xF', 
		'\xF', '$', '$', '^', '^', '\x5', '\x2', '\xB9', '\xB9', '\x302', '\x371', 
		'\x2041', '\x2042', '\xF', '\x2', '\x43', '\\', '\x63', '|', '\xC2', '\xD8', 
		'\xDA', '\xF8', '\xFA', '\x301', '\x372', '\x37F', '\x381', '\x2001', 
		'\x200E', '\x200F', '\x2072', '\x2191', '\x2C02', '\x2FF1', '\x3003', 
		'\xD801', '\xF902', '\xFDD1', '\xFDF2', '\xFFFF', '\x2', '\x118', '\x3', 
		'g', '\x3', '\x2', '\x2', '\x2', '\x5', 'i', '\x3', '\x2', '\x2', '\x2', 
		'\a', 'k', '\x3', '\x2', '\x2', '\x2', '\t', 'm', '\x3', '\x2', '\x2', 
		'\x2', '\v', '{', '\x3', '\x2', '\x2', '\x2', '\r', '\x8A', '\x3', '\x2', 
		'\x2', '\x2', '\xF', '\x93', '\x3', '\x2', '\x2', '\x2', '\x11', '\x9A', 
		'\x3', '\x2', '\x2', '\x2', '\x13', '\x9D', '\x3', '\x2', '\x2', '\x2', 
		'\x15', '\xB2', '\x3', '\x2', '\x2', '\x2', '\x17', '\xB4', '\x3', '\x2', 
		'\x2', '\x2', '\x19', '\xB6', '\x3', '\x2', '\x2', '\x2', '\x1B', '\xC1', 
		'\x3', '\x2', '\x2', '\x2', '\x1D', '\xC3', '\x3', '\x2', '\x2', '\x2', 
		'\x1F', '\xCA', '\x3', '\x2', '\x2', '\x2', '!', '\xD4', '\x3', '\x2', 
		'\x2', '\x2', '#', '\xDE', '\x3', '\x2', '\x2', '\x2', '%', '\xEA', '\x3', 
		'\x2', '\x2', '\x2', '\'', '\xEC', '\x3', '\x2', '\x2', '\x2', ')', '\xEE', 
		'\x3', '\x2', '\x2', '\x2', '+', '\xF2', '\x3', '\x2', '\x2', '\x2', '-', 
		'\xF4', '\x3', '\x2', '\x2', '\x2', '/', '\xF6', '\x3', '\x2', '\x2', 
		'\x2', '\x31', '\xF9', '\x3', '\x2', '\x2', '\x2', '\x33', '\xFB', '\x3', 
		'\x2', '\x2', '\x2', '\x35', '\xFD', '\x3', '\x2', '\x2', '\x2', '\x37', 
		'\xFF', '\x3', '\x2', '\x2', '\x2', '\x39', '\x101', '\x3', '\x2', '\x2', 
		'\x2', ';', '\x103', '\x3', '\x2', '\x2', '\x2', '=', '\x105', '\x3', 
		'\x2', '\x2', '\x2', '?', '\x107', '\x3', '\x2', '\x2', '\x2', '\x41', 
		'\x109', '\x3', '\x2', '\x2', '\x2', '\x43', '\x10C', '\x3', '\x2', '\x2', 
		'\x2', '\x45', '\x10E', '\x3', '\x2', '\x2', '\x2', 'G', '\x110', '\x3', 
		'\x2', '\x2', '\x2', 'I', '\x112', '\x3', '\x2', '\x2', '\x2', 'K', '\x114', 
		'\x3', '\x2', '\x2', '\x2', 'M', '\x116', '\x3', '\x2', '\x2', '\x2', 
		'O', '\x118', '\x3', '\x2', '\x2', '\x2', 'Q', '\x11B', '\x3', '\x2', 
		'\x2', '\x2', 'S', '\x11D', '\x3', '\x2', '\x2', '\x2', 'U', '\x11F', 
		'\x3', '\x2', '\x2', '\x2', 'W', '\x121', '\x3', '\x2', '\x2', '\x2', 
		'Y', '\x123', '\x3', '\x2', '\x2', '\x2', '[', '\x125', '\x3', '\x2', 
		'\x2', '\x2', ']', '\x127', '\x3', '\x2', '\x2', '\x2', '_', '\x12A', 
		'\x3', '\x2', '\x2', '\x2', '\x61', '\x12C', '\x3', '\x2', '\x2', '\x2', 
		'\x63', '\x12E', '\x3', '\x2', '\x2', '\x2', '\x65', 'h', '\x5', '\x5', 
		'\x3', '\x2', '\x66', 'h', '\x5', '\a', '\x4', '\x2', 'g', '\x65', '\x3', 
		'\x2', '\x2', '\x2', 'g', '\x66', '\x3', '\x2', '\x2', '\x2', 'h', '\x4', 
		'\x3', '\x2', '\x2', '\x2', 'i', 'j', '\t', '\x2', '\x2', '\x2', 'j', 
		'\x6', '\x3', '\x2', '\x2', '\x2', 'k', 'l', '\t', '\x3', '\x2', '\x2', 
		'l', '\b', '\x3', '\x2', '\x2', '\x2', 'm', 'n', '\a', '\x31', '\x2', 
		'\x2', 'n', 'o', '\a', ',', '\x2', '\x2', 'o', 's', '\x3', '\x2', '\x2', 
		'\x2', 'p', 'r', '\v', '\x2', '\x2', '\x2', 'q', 'p', '\x3', '\x2', '\x2', 
		'\x2', 'r', 'u', '\x3', '\x2', '\x2', '\x2', 's', 't', '\x3', '\x2', '\x2', 
		'\x2', 's', 'q', '\x3', '\x2', '\x2', '\x2', 't', 'y', '\x3', '\x2', '\x2', 
		'\x2', 'u', 's', '\x3', '\x2', '\x2', '\x2', 'v', 'w', '\a', ',', '\x2', 
		'\x2', 'w', 'z', '\a', '\x31', '\x2', '\x2', 'x', 'z', '\a', '\x2', '\x2', 
		'\x3', 'y', 'v', '\x3', '\x2', '\x2', '\x2', 'y', 'x', '\x3', '\x2', '\x2', 
		'\x2', 'z', '\n', '\x3', '\x2', '\x2', '\x2', '{', '|', '\a', '\x31', 
		'\x2', '\x2', '|', '}', '\a', ',', '\x2', '\x2', '}', '~', '\a', ',', 
		'\x2', '\x2', '~', '\x82', '\x3', '\x2', '\x2', '\x2', '\x7F', '\x81', 
		'\v', '\x2', '\x2', '\x2', '\x80', '\x7F', '\x3', '\x2', '\x2', '\x2', 
		'\x81', '\x84', '\x3', '\x2', '\x2', '\x2', '\x82', '\x83', '\x3', '\x2', 
		'\x2', '\x2', '\x82', '\x80', '\x3', '\x2', '\x2', '\x2', '\x83', '\x88', 
		'\x3', '\x2', '\x2', '\x2', '\x84', '\x82', '\x3', '\x2', '\x2', '\x2', 
		'\x85', '\x86', '\a', ',', '\x2', '\x2', '\x86', '\x89', '\a', '\x31', 
		'\x2', '\x2', '\x87', '\x89', '\a', '\x2', '\x2', '\x3', '\x88', '\x85', 
		'\x3', '\x2', '\x2', '\x2', '\x88', '\x87', '\x3', '\x2', '\x2', '\x2', 
		'\x89', '\f', '\x3', '\x2', '\x2', '\x2', '\x8A', '\x8B', '\a', '\x31', 
		'\x2', '\x2', '\x8B', '\x8C', '\a', '\x31', '\x2', '\x2', '\x8C', '\x90', 
		'\x3', '\x2', '\x2', '\x2', '\x8D', '\x8F', '\n', '\x4', '\x2', '\x2', 
		'\x8E', '\x8D', '\x3', '\x2', '\x2', '\x2', '\x8F', '\x92', '\x3', '\x2', 
		'\x2', '\x2', '\x90', '\x8E', '\x3', '\x2', '\x2', '\x2', '\x90', '\x91', 
		'\x3', '\x2', '\x2', '\x2', '\x91', '\xE', '\x3', '\x2', '\x2', '\x2', 
		'\x92', '\x90', '\x3', '\x2', '\x2', '\x2', '\x93', '\x98', '\x5', '+', 
		'\x16', '\x2', '\x94', '\x99', '\t', '\x5', '\x2', '\x2', '\x95', '\x99', 
		'\x5', '\x13', '\n', '\x2', '\x96', '\x99', '\v', '\x2', '\x2', '\x2', 
		'\x97', '\x99', '\a', '\x2', '\x2', '\x3', '\x98', '\x94', '\x3', '\x2', 
		'\x2', '\x2', '\x98', '\x95', '\x3', '\x2', '\x2', '\x2', '\x98', '\x96', 
		'\x3', '\x2', '\x2', '\x2', '\x98', '\x97', '\x3', '\x2', '\x2', '\x2', 
		'\x99', '\x10', '\x3', '\x2', '\x2', '\x2', '\x9A', '\x9B', '\x5', '+', 
		'\x16', '\x2', '\x9B', '\x9C', '\v', '\x2', '\x2', '\x2', '\x9C', '\x12', 
		'\x3', '\x2', '\x2', '\x2', '\x9D', '\xA8', '\a', 'w', '\x2', '\x2', '\x9E', 
		'\xA6', '\x5', '\x17', '\f', '\x2', '\x9F', '\xA4', '\x5', '\x17', '\f', 
		'\x2', '\xA0', '\xA2', '\x5', '\x17', '\f', '\x2', '\xA1', '\xA3', '\x5', 
		'\x17', '\f', '\x2', '\xA2', '\xA1', '\x3', '\x2', '\x2', '\x2', '\xA2', 
		'\xA3', '\x3', '\x2', '\x2', '\x2', '\xA3', '\xA5', '\x3', '\x2', '\x2', 
		'\x2', '\xA4', '\xA0', '\x3', '\x2', '\x2', '\x2', '\xA4', '\xA5', '\x3', 
		'\x2', '\x2', '\x2', '\xA5', '\xA7', '\x3', '\x2', '\x2', '\x2', '\xA6', 
		'\x9F', '\x3', '\x2', '\x2', '\x2', '\xA6', '\xA7', '\x3', '\x2', '\x2', 
		'\x2', '\xA7', '\xA9', '\x3', '\x2', '\x2', '\x2', '\xA8', '\x9E', '\x3', 
		'\x2', '\x2', '\x2', '\xA8', '\xA9', '\x3', '\x2', '\x2', '\x2', '\xA9', 
		'\x14', '\x3', '\x2', '\x2', '\x2', '\xAA', '\xB3', '\a', '\x32', '\x2', 
		'\x2', '\xAB', '\xAF', '\t', '\x6', '\x2', '\x2', '\xAC', '\xAE', '\x5', 
		'\x19', '\r', '\x2', '\xAD', '\xAC', '\x3', '\x2', '\x2', '\x2', '\xAE', 
		'\xB1', '\x3', '\x2', '\x2', '\x2', '\xAF', '\xAD', '\x3', '\x2', '\x2', 
		'\x2', '\xAF', '\xB0', '\x3', '\x2', '\x2', '\x2', '\xB0', '\xB3', '\x3', 
		'\x2', '\x2', '\x2', '\xB1', '\xAF', '\x3', '\x2', '\x2', '\x2', '\xB2', 
		'\xAA', '\x3', '\x2', '\x2', '\x2', '\xB2', '\xAB', '\x3', '\x2', '\x2', 
		'\x2', '\xB3', '\x16', '\x3', '\x2', '\x2', '\x2', '\xB4', '\xB5', '\t', 
		'\a', '\x2', '\x2', '\xB5', '\x18', '\x3', '\x2', '\x2', '\x2', '\xB6', 
		'\xB7', '\t', '\b', '\x2', '\x2', '\xB7', '\x1A', '\x3', '\x2', '\x2', 
		'\x2', '\xB8', '\xB9', '\a', 'v', '\x2', '\x2', '\xB9', '\xBA', '\a', 
		't', '\x2', '\x2', '\xBA', '\xBB', '\a', 'w', '\x2', '\x2', '\xBB', '\xC2', 
		'\a', 'g', '\x2', '\x2', '\xBC', '\xBD', '\a', 'h', '\x2', '\x2', '\xBD', 
		'\xBE', '\a', '\x63', '\x2', '\x2', '\xBE', '\xBF', '\a', 'n', '\x2', 
		'\x2', '\xBF', '\xC0', '\a', 'u', '\x2', '\x2', '\xC0', '\xC2', '\a', 
		'g', '\x2', '\x2', '\xC1', '\xB8', '\x3', '\x2', '\x2', '\x2', '\xC1', 
		'\xBC', '\x3', '\x2', '\x2', '\x2', '\xC2', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', '\xC3', '\xC6', '\x5', '\x31', '\x19', '\x2', '\xC4', '\xC7', '\x5', 
		'\xF', '\b', '\x2', '\xC5', '\xC7', '\n', '\t', '\x2', '\x2', '\xC6', 
		'\xC4', '\x3', '\x2', '\x2', '\x2', '\xC6', '\xC5', '\x3', '\x2', '\x2', 
		'\x2', '\xC7', '\xC8', '\x3', '\x2', '\x2', '\x2', '\xC8', '\xC9', '\x5', 
		'\x31', '\x19', '\x2', '\xC9', '\x1E', '\x3', '\x2', '\x2', '\x2', '\xCA', 
		'\xCF', '\x5', '\x31', '\x19', '\x2', '\xCB', '\xCE', '\x5', '\xF', '\b', 
		'\x2', '\xCC', '\xCE', '\n', '\t', '\x2', '\x2', '\xCD', '\xCB', '\x3', 
		'\x2', '\x2', '\x2', '\xCD', '\xCC', '\x3', '\x2', '\x2', '\x2', '\xCE', 
		'\xD1', '\x3', '\x2', '\x2', '\x2', '\xCF', '\xCD', '\x3', '\x2', '\x2', 
		'\x2', '\xCF', '\xD0', '\x3', '\x2', '\x2', '\x2', '\xD0', '\xD2', '\x3', 
		'\x2', '\x2', '\x2', '\xD1', '\xCF', '\x3', '\x2', '\x2', '\x2', '\xD2', 
		'\xD3', '\x5', '\x31', '\x19', '\x2', '\xD3', ' ', '\x3', '\x2', '\x2', 
		'\x2', '\xD4', '\xD9', '\x5', '\x33', '\x1A', '\x2', '\xD5', '\xD8', '\x5', 
		'\xF', '\b', '\x2', '\xD6', '\xD8', '\n', '\n', '\x2', '\x2', '\xD7', 
		'\xD5', '\x3', '\x2', '\x2', '\x2', '\xD7', '\xD6', '\x3', '\x2', '\x2', 
		'\x2', '\xD8', '\xDB', '\x3', '\x2', '\x2', '\x2', '\xD9', '\xD7', '\x3', 
		'\x2', '\x2', '\x2', '\xD9', '\xDA', '\x3', '\x2', '\x2', '\x2', '\xDA', 
		'\xDC', '\x3', '\x2', '\x2', '\x2', '\xDB', '\xD9', '\x3', '\x2', '\x2', 
		'\x2', '\xDC', '\xDD', '\x5', '\x33', '\x1A', '\x2', '\xDD', '\"', '\x3', 
		'\x2', '\x2', '\x2', '\xDE', '\xE3', '\x5', '\x31', '\x19', '\x2', '\xDF', 
		'\xE2', '\x5', '\xF', '\b', '\x2', '\xE0', '\xE2', '\n', '\t', '\x2', 
		'\x2', '\xE1', '\xDF', '\x3', '\x2', '\x2', '\x2', '\xE1', '\xE0', '\x3', 
		'\x2', '\x2', '\x2', '\xE2', '\xE5', '\x3', '\x2', '\x2', '\x2', '\xE3', 
		'\xE1', '\x3', '\x2', '\x2', '\x2', '\xE3', '\xE4', '\x3', '\x2', '\x2', 
		'\x2', '\xE4', '$', '\x3', '\x2', '\x2', '\x2', '\xE5', '\xE3', '\x3', 
		'\x2', '\x2', '\x2', '\xE6', '\xEB', '\x5', '\'', '\x14', '\x2', '\xE7', 
		'\xEB', '\x4', '\x32', ';', '\x2', '\xE8', '\xEB', '\x5', 'Q', ')', '\x2', 
		'\xE9', '\xEB', '\t', '\v', '\x2', '\x2', '\xEA', '\xE6', '\x3', '\x2', 
		'\x2', '\x2', '\xEA', '\xE7', '\x3', '\x2', '\x2', '\x2', '\xEA', '\xE8', 
		'\x3', '\x2', '\x2', '\x2', '\xEA', '\xE9', '\x3', '\x2', '\x2', '\x2', 
		'\xEB', '&', '\x3', '\x2', '\x2', '\x2', '\xEC', '\xED', '\t', '\f', '\x2', 
		'\x2', '\xED', '(', '\x3', '\x2', '\x2', '\x2', '\xEE', '\xEF', '\a', 
		'k', '\x2', '\x2', '\xEF', '\xF0', '\a', 'p', '\x2', '\x2', '\xF0', '\xF1', 
		'\a', 'v', '\x2', '\x2', '\xF1', '*', '\x3', '\x2', '\x2', '\x2', '\xF2', 
		'\xF3', '\a', '^', '\x2', '\x2', '\xF3', ',', '\x3', '\x2', '\x2', '\x2', 
		'\xF4', '\xF5', '\a', '<', '\x2', '\x2', '\xF5', '.', '\x3', '\x2', '\x2', 
		'\x2', '\xF6', '\xF7', '\a', '<', '\x2', '\x2', '\xF7', '\xF8', '\a', 
		'<', '\x2', '\x2', '\xF8', '\x30', '\x3', '\x2', '\x2', '\x2', '\xF9', 
		'\xFA', '\a', ')', '\x2', '\x2', '\xFA', '\x32', '\x3', '\x2', '\x2', 
		'\x2', '\xFB', '\xFC', '\a', '$', '\x2', '\x2', '\xFC', '\x34', '\x3', 
		'\x2', '\x2', '\x2', '\xFD', '\xFE', '\a', '*', '\x2', '\x2', '\xFE', 
		'\x36', '\x3', '\x2', '\x2', '\x2', '\xFF', '\x100', '\a', '+', '\x2', 
		'\x2', '\x100', '\x38', '\x3', '\x2', '\x2', '\x2', '\x101', '\x102', 
		'\a', '}', '\x2', '\x2', '\x102', ':', '\x3', '\x2', '\x2', '\x2', '\x103', 
		'\x104', '\a', '\x7F', '\x2', '\x2', '\x104', '<', '\x3', '\x2', '\x2', 
		'\x2', '\x105', '\x106', '\a', ']', '\x2', '\x2', '\x106', '>', '\x3', 
		'\x2', '\x2', '\x2', '\x107', '\x108', '\a', '_', '\x2', '\x2', '\x108', 
		'@', '\x3', '\x2', '\x2', '\x2', '\x109', '\x10A', '\a', '/', '\x2', '\x2', 
		'\x10A', '\x10B', '\a', '@', '\x2', '\x2', '\x10B', '\x42', '\x3', '\x2', 
		'\x2', '\x2', '\x10C', '\x10D', '\a', '>', '\x2', '\x2', '\x10D', '\x44', 
		'\x3', '\x2', '\x2', '\x2', '\x10E', '\x10F', '\a', '@', '\x2', '\x2', 
		'\x10F', '\x46', '\x3', '\x2', '\x2', '\x2', '\x110', '\x111', '\a', '?', 
		'\x2', '\x2', '\x111', 'H', '\x3', '\x2', '\x2', '\x2', '\x112', '\x113', 
		'\a', '\x41', '\x2', '\x2', '\x113', 'J', '\x3', '\x2', '\x2', '\x2', 
		'\x114', '\x115', '\a', ',', '\x2', '\x2', '\x115', 'L', '\x3', '\x2', 
		'\x2', '\x2', '\x116', '\x117', '\a', '-', '\x2', '\x2', '\x117', 'N', 
		'\x3', '\x2', '\x2', '\x2', '\x118', '\x119', '\a', '-', '\x2', '\x2', 
		'\x119', '\x11A', '\a', '?', '\x2', '\x2', '\x11A', 'P', '\x3', '\x2', 
		'\x2', '\x2', '\x11B', '\x11C', '\a', '\x61', '\x2', '\x2', '\x11C', 'R', 
		'\x3', '\x2', '\x2', '\x2', '\x11D', '\x11E', '\a', '~', '\x2', '\x2', 
		'\x11E', 'T', '\x3', '\x2', '\x2', '\x2', '\x11F', '\x120', '\a', '&', 
		'\x2', '\x2', '\x120', 'V', '\x3', '\x2', '\x2', '\x2', '\x121', '\x122', 
		'\a', '.', '\x2', '\x2', '\x122', 'X', '\x3', '\x2', '\x2', '\x2', '\x123', 
		'\x124', '\a', '=', '\x2', '\x2', '\x124', 'Z', '\x3', '\x2', '\x2', '\x2', 
		'\x125', '\x126', '\a', '\x30', '\x2', '\x2', '\x126', '\\', '\x3', '\x2', 
		'\x2', '\x2', '\x127', '\x128', '\a', '\x30', '\x2', '\x2', '\x128', '\x129', 
		'\a', '\x30', '\x2', '\x2', '\x129', '^', '\x3', '\x2', '\x2', '\x2', 
		'\x12A', '\x12B', '\a', '\x42', '\x2', '\x2', '\x12B', '`', '\x3', '\x2', 
		'\x2', '\x2', '\x12C', '\x12D', '\a', '%', '\x2', '\x2', '\x12D', '\x62', 
		'\x3', '\x2', '\x2', '\x2', '\x12E', '\x12F', '\a', '\x80', '\x2', '\x2', 
		'\x12F', '\x64', '\x3', '\x2', '\x2', '\x2', '\x19', '\x2', 'g', 's', 
		'y', '\x82', '\x88', '\x90', '\x98', '\xA2', '\xA4', '\xA6', '\xA8', '\xAF', 
		'\xB2', '\xC1', '\xC6', '\xCD', '\xCF', '\xD7', '\xD9', '\xE1', '\xE3', 
		'\xEA', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
